// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using CommandLine;

namespace Azure.Messaging.EventHubs.Perf
{
    public class EventHubsPartitionOptions : EventHubsOptions
    {
        [Option("partitions", Default = 1, HelpText = "Number of partitions to publish. -1 publishes to all partitions.")]
        public int Partitions { get; set; }
    }
}
