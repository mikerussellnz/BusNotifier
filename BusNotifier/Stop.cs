namespace BusNotifier {
    public class Stop {
        public string StopNo;
        public string Name;

        public override string ToString() {
            return StopNo + " - " + Name;
        }
    }
}
