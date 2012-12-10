using System.Collections.Generic;

namespace BusNotifier {
    public class RouteData {
		public string RouteId;
		public string DestinationName;
        public List<TripData> Trips = new List<TripData>();
    }
}
