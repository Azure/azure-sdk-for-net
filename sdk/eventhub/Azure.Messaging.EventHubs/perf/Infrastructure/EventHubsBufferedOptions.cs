// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using CommandLine;

namespace Azure.Messaging.EventHubs.Perf
{
    /// <summary>
    ///   The set of command-line options valid for Event Hubs performance tests.
    /// </summary>
    ///
    public class EventHubsBufferedOptions : EventHubsOptions
    {
        /// <summary>
        ///   The amount of time to wait for a batch to be built with events in the buffer before publishing
        ///   a partially full batch.
        /// </summary>
        ///
        /// <value>
        ///   The default wait time is 25 milliseconds.  For most real-world scenarios, it is recommended to allow
        ///   for at least 1 second in order to ensure a consistent publishing rate and optimal batch sizes.
        ///
        ///   <para>If <c>null</c>, batches will only be published when full unless <see cref="Producer.EventHubBufferedProducerClient.FlushAsync"/>
        ///   is called.</para>
        /// </value>
        ///
        [Option("max-wait-ms", Default = 25, HelpText = "The amount of time to wait for a batch to be built with events in the buffer before publishing a partially full batch.")]
        public int? MaximumWaitTimeMilliseconds { get; set; }

        /// <summary>
        ///   The total number of events that can be buffered for publishing at a given time for a given partition.  Once this capacity is reached, more
        ///   events can enqueued, the call for which will block until room is available.
        /// </summary>
        ///
        /// <value>
        ///   The default limit is 1500 queued events for each partition.
        /// </value>
        ///
        [Option("max-buffer-length", Default = 1500, HelpText = "The total number of events that can be buffered for publishing at a given time for a given partition.")]
        public int MaximumBufferLength { get; set; }

        /// <summary>
        ///   The total number of batches that may be sent concurrently, across all partitions.  This limit takes precedence over
        ///   the value specified in <see cref="MaximumConcurrentSendsPerPartition" />, ensuring this maximum is respected.
        /// </summary>
        ///
        /// <value>
        ///  If <c>null</c>, this will be set to the number of processors available in the host environment.
        /// </value>
        ///
        [Option("max-concurrent", Default = null, HelpText = "The total number of batches that may be sent concurrently, across all partitions.")]
        public int? MaximumConcurrentSends { get; set; }

        /// <summary>
        ///   The number of batches that may be sent concurrently for a given partition.  This option is superseded by
        ///   the value specified for <see cref="MaximumConcurrentSends" />, ensuring that limit is respected.
        /// </summary>
        ///
        /// <value>
        ///   By default, each partition will allow only one publishing operation to be active in
        ///   order to ensure that events are published in the order that they were enqueued.
        /// </value>
        ///
        /// <remarks>
        ///   When batches for the same partition are published concurrently, the ordering of events is not guaranteed.  If the order of events
        ///   must be maintained, <see cref="MaximumConcurrentSendsPerPartition" /> should not exceed 1.
        /// </remarks>
        ///
        [Option("max-concurrent-partition", Default = 1, HelpText = "TThe number of batches that may be sent concurrently for a given partition.")]
        public int MaximumConcurrentSendsPerPartition { get; set; }
    }
}
