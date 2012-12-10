namespace BusNotifier {
    public class Route {
        public string RouteNo;
        public string UniqueIdentifier;
        public string Name;

        public override string ToString() {
            return RouteNo + " - " + Name;
        }
    }
}
