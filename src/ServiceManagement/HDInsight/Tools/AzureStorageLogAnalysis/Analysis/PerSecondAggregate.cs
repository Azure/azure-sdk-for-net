namespace AzureLogTool
{
    //this is a class rather than a struct so we can easily do in-place updates 
    //(perhaps better would be a struct, call-by-ref and immutable semantics, but that seems overkill for current needs)
    internal class PerSecondAggregate
    {
        public PerSecondAggregate()
        {
        }

        public PerSecondAggregate(
            long secondSinceJobStart,
            double successMbps,
            double readMbps,
            double writeMbps,
            double throttleMbps,
            double failMbps,
            double totalMbps,
            double maxE2ELatency)
        {
            this.SecondsSinceJobStart = secondSinceJobStart;
            this.SuccessMbps = successMbps;
            this.ReadMbps = readMbps;
            this.WriteMbps = writeMbps;
            this.ThrottleMbps = throttleMbps;
            this.FailMbps = failMbps;
            this.TotalMbps = totalMbps;
            this.MaxE2ELatency = maxE2ELatency;
        }

        public double FailMbps { get; set; }

        public double MaxE2ELatency { get; set; }

        public double ReadMbps { get; set; }

        public double ReadMbpsMovingAv30Secs { get; set; }

        public double ReadMbpsMovingAv60Secs { get; set; }

        public long SecondsSinceJobStart { get; set; }

        public double SuccessMbps { get; set; }

        public double ThrottleMbps { get; set; }

        public double TotalMbps { get; set; }

        public double WriteMbps { get; set; }

        public double WriteMbpsMovingAv30Secs { get; set; }

        public double WriteMbpsMovingAv60Secs { get; set; }
    }
}
