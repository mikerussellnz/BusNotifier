using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace BusNotifier {
    public class MetroInfoBackend : IBackend {
        private const string _rttUrl = "http://rtt.metroinfo.org.nz/rtt/public/utility/file.aspx?contenttype=SQLXML&Name=JPRoutePositionET.xml&PlatformTag={0}&rand={1}";
        private const string _dataUrl = "http://rtt.metroinfo.org.nz/RTT/Public/Utility/File.aspx?ContentType=SQLXML&Name=RoutePattern.xml";
        private readonly Random _random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
        private XmlDocument _cachedDoc;

        public List<Stop> RequestListOfStopsForRoute(Route route) {
            if (_cachedDoc == null) {
                _cachedDoc = new XmlDocument();
                _cachedDoc.Load(_dataUrl);
            }
            XmlDocument doc = _cachedDoc;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("jp", "urn:connexionz-co-nz");
            XmlNode xroute = doc.SelectSingleNode(string.Format("//jp:Pattern[@RouteTag={0}]", route.UniqueIdentifier), nsmgr);
            XmlNodeList xplatforms = xroute.SelectNodes("jp:Platform", nsmgr);

            Dictionary<string, Stop> platforms = new Dictionary<string, Stop>();

            foreach (XmlNode platform in xplatforms) {
            	platforms[platform.Attributes["PlatformTag"].Value] = new Stop() {
            		StopNo = platform.Attributes["PlatformTag"].Value,
            		StopLabel = platform.Attributes["PlatformNo"].Value,
                    Name = platform.Attributes["Name"].Value
                };
            }

            return platforms.Values.ToList();
        }


        public List<Route> RequestListOfRoutes() {
            if (_cachedDoc == null) {
                _cachedDoc = new XmlDocument();
                _cachedDoc.Load(_dataUrl);
            }
            XmlDocument doc = _cachedDoc;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("jp", "urn:connexionz-co-nz");
            XmlNodeList xroutes = doc.SelectNodes("//jp:Route", nsmgr);

            List<Route> routes = new List<Route>();

            foreach (XmlNode route in xroutes) {
                XmlNodeList destinations = route.SelectNodes("jp:Destination", nsmgr);

                foreach (XmlNode destination in destinations) {
                    XmlNode pattern = destination.SelectSingleNode("jp:Pattern", nsmgr);

                    routes.Add(new Route() {
                        UniqueIdentifier = pattern.Attributes["RouteTag"].Value,
                        RouteNo = route.Attributes["RouteNo"].Value,
                        Name = destination.Attributes["Name"].Value
                    });
                }
            }

            return routes;
        }

        public StopData RequestDataForStopAndRouteNumber(string stopNumber, string routeNumber) {
            StopData data = new StopData();

            XmlDocument doc = new XmlDocument();
            string url = string.Format(_rttUrl, stopNumber, _random.NextDouble());
            doc.Load(url);

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("jp", "urn:connexionz-co-nz:jp");

            XmlNode routeNode = doc.SelectSingleNode(string.Format("//jp:Route[@RouteNo={0}]", routeNumber), nsmgr);
            // if no routes, return now.
            if (routeNode == null) {
                return data;
            }

            XmlNode destinationNode = routeNode.SelectSingleNode("//jp:Destination", nsmgr);

            RouteData routeData = new RouteData() {
                RouteId = routeNode.Attributes["RouteNo"].Value,
                DestinationName = destinationNode.Attributes["Name"].Value
            };
            data.Routes.Add(routeData);

			XmlNodeList trips = routeNode.SelectNodes("descendant::jp:Trip", nsmgr);
            if (trips != null) {
                foreach (XmlNode trip in trips) {
                	routeData.Trips.Add(new TripData() {
                		TripId = trip.Attributes["TripNo"].Value,
                        ETA = TimeSpan.FromMinutes(uint.Parse(trip.Attributes["ETA"].Value))
                    });
                }
            }
            
            return data;
        }
    }
}
