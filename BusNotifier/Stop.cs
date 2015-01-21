using System;

namespace BusNotifier {
    public class Stop {
        public string StopNo;
        public string Name;
		public string StopLabel;

    	public override string ToString() {
			return StopLabel + " - " + Name;
        }
    }
}
