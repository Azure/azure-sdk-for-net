using System.Collections.Generic;

namespace Azure.Test.PerfStress
{
    internal class BenchmarkOutput
    {
        public List<BenchmarkMetadata> Metadata { get; } = new List<BenchmarkMetadata>();

        public List<BenchmarkMeasurement> Measurements { get; } = new List<BenchmarkMeasurement>();
    }
}
