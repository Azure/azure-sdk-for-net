// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using CommandLine;

namespace Azure.Messaging.EventHubs.Perf
{
    /// <summary>
    ///   The set of command-line options valid for Event Hubs performance tests.
    /// </summary>
    ///
    public class EventHubsOptions : PerfOptions
    {
        /// <summary>
        ///   The size of the event body, in bytes.
        /// </summary>
        ///
        [Option("body-size", HelpText = "Size of event body (in bytes)")]
        public int BodySize { get; set; }

        /// <summary>
        ///   The number of events that should be included in each batch.
        /// </summary>
        ///
        [Option("batch-size", HelpText = "Events per batch")]
        public int BatchSize { get; set; }

        /// <summary>
        ///   The number of partitions that the Event Hub used for testing should have.
        /// </summary>
        ///
        [Option("partition-count", Default = 4, HelpText = "The number of partitions that the Event Hub should have.")]
        public int PartitionCount { get; set; }
    }
}
