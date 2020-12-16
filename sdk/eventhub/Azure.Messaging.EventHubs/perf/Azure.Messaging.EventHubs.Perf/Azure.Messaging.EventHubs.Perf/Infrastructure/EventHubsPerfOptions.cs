// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using CommandLine;

namespace Azure.Test.Perf
{
    public class EventHubsPerfOptions : PerfOptions
    {
        [Option('e', "events", Default = 10, HelpText = "Size of the batch (in bytes)")]
        public long Events { get; set; }

        [Option('b', "batchSize", Default = null, HelpText = "Number of events to send in the batch")]
        public long? BatchSize { get; set; }
    }
}
