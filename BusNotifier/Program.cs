using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BusNotifier {
    public class Program {
        private readonly NotifyIcon _notify = new NotifyIcon();
        private readonly Timer _timer = new Timer();
        private readonly IBackend _backend = new MetroInfoBackend();
        private readonly ContextMenu _menu = new ContextMenu();
        private TimeSpan _lastETA = TimeSpan.Zero;

        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new Program().Run();
            Application.Run();
        }

        public void Run() {
            _timer.Interval = 8000;
            _timer.Tick += _timer_Tick;
            _timer.Start();
            _notify.Visible = true;
            _notify.Icon = new Icon(GetType(), "TrayIcon.ico");
            _menu.MenuItems.Add(0, new MenuItem("Configure...", Configure_Click));
            _menu.MenuItems.Add(1, new MenuItem("Exit", Exit_Click));
            _notify.ContextMenu = _menu;
            _notify.MouseClick += _notify_MouseClick;
            RequestUpdate();
        }

        private void _notify_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Left) {
                return;
            }
            _notify.ShowBalloonTip(10);
        }

        private void _timer_Tick(object sender, EventArgs e) {
            RequestUpdate();
        }

        private void Exit_Click(object sender, EventArgs e) {
            _notify.Visible = false;
            Application.Exit();
        }

        private void Configure_Click(object sender, EventArgs e) {
            new ConfigurationDialog(_backend).ShowDialog();
            RequestUpdate();
        }

        private void RequestUpdate() {
            TooltipData data = new TooltipData();
            StopData eta = null;

            try {
                eta = _backend.RequestDataForStopAndRouteNumber(ConfigSettings.Default.StopNumber,
                                                                ConfigSettings.Default.RouteNumber);
                data = CreateToolTip(eta);
            } catch (Exception e) {
                data.Icon = ToolTipIcon.Error;
                data.Title = "Error Loading";
                data.Content = e.Message;
            }

            _notify.BalloonTipIcon = data.Icon;
            _notify.BalloonTipTitle = data.Title;
            _notify.BalloonTipText = data.Content;

            if (eta != null && eta.Routes.Count > 0) {
                RouteData routeData = eta.Routes.First();
                if (routeData.Trips.Count > 0) {
                    TripData nextTrip = routeData.Trips.OrderBy(z => z.ETA).FirstOrDefault();
                    if (nextTrip != null) {
                        if (ConfigSettings.Default.EnableAlerts && 
							(DateTime.Now.TimeOfDay >= TimeSpan.FromSeconds(ConfigSettings.Default.AlertStart)) &&
                            (DateTime.Now.TimeOfDay <= TimeSpan.FromSeconds(ConfigSettings.Default.AlertEnd)) &&
                            nextTrip.ETA.TotalMinutes <= ConfigSettings.Default.AlertWhenETA && 
                            nextTrip.ETA != _lastETA) {
                            _notify.ShowBalloonTip(10);
                            _lastETA = nextTrip.ETA;
                        }
                    }
                }
            }
        }

		private static TooltipData CreateToolTip(StopData arrivalData) {
            TooltipData tipData = new TooltipData {
                Icon = ToolTipIcon.Info
            };

            if (arrivalData.Routes.Count == 0) {
                tipData.Title = "No Routes";
                return tipData;
            }

            RouteData routeData = arrivalData.Routes.First();
            tipData.Title = "Route: " + routeData.RouteId + " - " + routeData.DestinationName;

            StringBuilder tip = new StringBuilder();

            if (routeData.Trips.Count == 0) {
                tip.AppendLine("No Trips");
                return tipData;
            }
            
            foreach (TripData trip in routeData.Trips) {
                tip.AppendLine("ETA: " + trip.ETA.TotalMinutes + " m.");
            }

            tip.AppendLine("Updated at: " + DateTime.Now.ToString("HH:mm:ss"));

            tipData.Content = tip.ToString();
            return tipData;
        }

    }
}
