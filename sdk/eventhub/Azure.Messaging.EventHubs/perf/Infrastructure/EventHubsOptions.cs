// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using CommandLine;

namespace Azure.Messaging.EventHubs.Perf
{
    public class EventHubsOptions : PerfOptions
    {
        [Option("body-size", HelpText = "Size of message body (in bytes)")]
        public int BodySize { get; set; }

        [Option("batch-size", HelpText = "Messages per batch")]
        public int BatchSize { get; set; }
    }
}
