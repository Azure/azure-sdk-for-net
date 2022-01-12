// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using CommandLine;

namespace Azure.Messaging.EventHubs.Perf
{
    /// <summary>
    ///   The set of command-line options for partition-based Event Hubs performance tests.
    /// </summary>
    ///
    public class EventHubsPartitionOptions : EventHubsOptions
    {
        /// <summary>
        ///   The number of partitions to test against.
        /// </summary>
        ///
        /// <value>If set to -1, all available partitions will be used.</value>
        ///
        [Option("partitions", Default = 1, HelpText = "Number of partitions to publish. -1 publishes to all partitions.")]
        public int Partitions { get; set; }

        /// <summary>
        ///   Indicates whether all partitions should be used rather than constraining to a subset.
        /// </summary>
        ///
        /// <value><c>true</c> if all partitions should be used; otherwise, <c>false</c>.</value>
        ///
        public bool ShouldUseAllPartitions => Partitions == -1;
    }
}
