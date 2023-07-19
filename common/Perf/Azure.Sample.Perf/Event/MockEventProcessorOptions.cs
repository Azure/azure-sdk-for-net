// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using CommandLine;

namespace Azure.Sample.Perf.Event
{
    public class MockEventProcessorOptions : PerfOptions
    {
        [Option("error-after-seconds", HelpText = "Raise error after this number of seconds")]
        public int? ErrorAfterSeconds { get; set; }

        [Option("max-events-per-second", HelpText = "Maximum events per second across all partitions")]
        public int? MaxEventsPerSecond { get; set; }

        [Option("partitions", Default = 8)]
        public int Partitions { get; set; }
    }
}
