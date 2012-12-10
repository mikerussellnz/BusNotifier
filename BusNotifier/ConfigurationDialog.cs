using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BusNotifier {
    public partial class ConfigurationDialog : Form {
        private readonly IBackend _backend;

        public Route SelectedRoute {
            get { return (Route)cmboRoute.SelectedItem; }
        }

        public Stop SelectedStop {
            get { return (Stop)cmboStop.SelectedItem; }
        }

        public ConfigurationDialog(IBackend backend) {
            InitializeComponent();
            _backend = backend;
        }

        private void ConfigurationDialog_Load(object sender, EventArgs e) {
            List<Route> routes = _backend.RequestListOfRoutes();
            Route selectedRoute = routes.Where(z => z.UniqueIdentifier == ConfigSettings.Default.RouteUniqueIdentifier).FirstOrDefault();
            cmboRoute.DataSource = routes;
            cmboRoute.SelectedItem = selectedRoute;
            chkEnableAlerts.Checked = ConfigSettings.Default.EnableAlerts;
            nmAlertWhen.Value = ConfigSettings.Default.AlertWhenETA;
            
            TimeSpan start = TimeSpan.FromSeconds(ConfigSettings.Default.AlertStart);
            TimeSpan end = TimeSpan.FromSeconds(ConfigSettings.Default.AlertEnd);
            
            tmStart.Value = DateTime.Today.Add(start);
            tmEnd.Value = DateTime.Today.Add(end);
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            if (cmboRoute.SelectedItem == null || cmboStop.SelectedItem == null) {
                MessageBox.Show("Please select both a route and a stop.");
                return;
            }

            ConfigSettings.Default.StopNumber = SelectedStop.StopNo;
            ConfigSettings.Default.RouteNumber = SelectedRoute.RouteNo;
            ConfigSettings.Default.RouteUniqueIdentifier = SelectedRoute.UniqueIdentifier;
            ConfigSettings.Default.EnableAlerts = chkEnableAlerts.Checked;
            ConfigSettings.Default.AlertWhenETA = (uint)nmAlertWhen.Value;

            TimeSpan start = (tmStart.Value - tmStart.Value.Date);
            TimeSpan end = (tmEnd.Value - tmEnd.Value.Date);

            ConfigSettings.Default.AlertStart = (uint)start.TotalSeconds;
            ConfigSettings.Default.AlertEnd = (uint)end.TotalSeconds;
            ConfigSettings.Default.Save();
            Close();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e) {
            if (cmboRoute.SelectedItem == null) {
                return;
            }

            List<Stop> stops = _backend.RequestListOfStopsForRoute(SelectedRoute); 
            Stop selectedStop = null;

            if (SelectedRoute.RouteNo == ConfigSettings.Default.RouteNumber) {
                selectedStop = stops.Where(z => z.StopNo == ConfigSettings.Default.StopNumber).FirstOrDefault();
            }

            cmboStop.DataSource = stops;
            cmboStop.SelectedItem = selectedStop;
        }
    }
}
