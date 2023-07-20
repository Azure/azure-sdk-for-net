// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Reports;
using Perfolizer.Horology;

namespace Azure.Core.Perf
{
    internal class SerializationBenchmarkConfig : ManualConfig
    {
        public SerializationBenchmarkConfig()
        {
            SummaryStyle = SummaryStyle.Default
                .WithTimeUnit(TimeUnit.Microsecond)
                .WithSizeUnit(SizeUnit.KB);
        }
    }
}
