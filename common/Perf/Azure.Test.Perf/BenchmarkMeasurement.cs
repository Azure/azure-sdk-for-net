using System;

namespace Azure.Test.PerfStress
{
    internal class BenchmarkMeasurement
    {
        public DateTime Timestamp { get; internal set; }
        public string Name { get; internal set; }
        public object Value { get; internal set; }
    }
}
