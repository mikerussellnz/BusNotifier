using System.Collections.Generic;

namespace BusNotifier {
    public interface IBackend {
        List<Stop> RequestListOfStopsForRoute(Route route);
        List<Route> RequestListOfRoutes();
        StopData RequestDataForStopAndRouteNumber(string stopNumber, string routeNumber);
    }
}