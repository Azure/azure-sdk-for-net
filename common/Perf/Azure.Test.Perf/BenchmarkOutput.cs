// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Test.Perf
{
    internal class BenchmarkOutput
    {
        public List<BenchmarkMetadata> Metadata { get; } = new List<BenchmarkMetadata>();

        public List<BenchmarkMeasurement> Measurements { get; } = new List<BenchmarkMeasurement>();
    }
}
