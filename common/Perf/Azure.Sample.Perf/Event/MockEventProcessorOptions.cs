// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using CommandLine;

namespace Azure.Sample.Perf.Event
{
    public class MockEventProcessorOptions : PerfOptions
    {
        [Option("partitions", Default = 8)]
        public int Partitions { get; set; }

        [Option("max-events-per-second", Default = -1, HelpText = "Maximum events per second across all partitions. -1 means unlimited.")]
        public int MaxEventsPerSecond { get; set; }
    }
}
