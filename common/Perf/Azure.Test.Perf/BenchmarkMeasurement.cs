// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Test.Perf
{
    internal class BenchmarkMeasurement
    {
        public DateTime Timestamp { get; internal set; }
        public string Name { get; internal set; }
        public object Value { get; internal set; }
    }
}
