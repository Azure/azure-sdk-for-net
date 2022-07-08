// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using CommandLine;

namespace Azure.Messaging.EventHubs.Processor.Perf.Infrastructure
{
    /// <summary>
    ///   The set of command-line options valid for event processor performance tests.
    /// </summary>
    ///
    /// <seealso cref="PerfOptions" />
    ///
    public class ProcessorOptions : PerfOptions
    {
        /// <summary>
        ///   The maximum number of events that will be read from the Event Hubs service and held in a local memory
        ///   cache when reading is active and events are being emitted to an enumerator for processing.
        /// </summary>
        ///
        /// <value>
        ///   The <see cref="CacheEventCount" /> is a control that developers can use to help tune performance for the specific
        ///   needs of an application, given its expected size of events, throughput needs, and expected scenarios for using
        ///   Event Hubs.
        /// </value>
        ///
        [Option("cache-event-count", HelpText = "Value of EventProcessorClientOptions.CacheEventCount")]
        public int? CacheEventCount { get; set; }

        /// <summary>
        ///   The strategy that an event processor will use to make decisions about partition ownership when performing
        ///   load balancing to share work with other event processors.
        /// </summary>
        ///
        /// <value>If not specified, the <see cref="LoadBalancingStrategy.Greedy" /> strategy will be used.</value>
        ///
        [Option("load-balancing-strategy", Default = LoadBalancingStrategy.Greedy, HelpText = "Value of EventProcessorClientOptions.LoadBalancingStrategy")]
        public LoadBalancingStrategy LoadBalancingStrategy { get; set; }

        /// <summary>
        ///   The maximum amount of time to wait for an event to become available for a given partition before emitting
        ///   an empty event.
        /// </summary>
        ///
        /// <value>
        ///   If <c>null</c>, the processor will wait indefinitely for an event to become available; otherwise, a value will
        ///   always be emitted within this interval, whether an event was available or not.
        /// </value>
        ///
        [Option("maximum-wait-time", HelpText = "Value of EventProcessorClientOptions.MaximumWaitTime (in ms)")]
        public int? MaximumWaitTimeMs { get; set; }

        /// <summary>
        ///   The number of events that will be eagerly requested from the Event Hubs service and queued locally without regard to
        ///   whether a read operation is currently active, intended to help maximize throughput by allowing events to be read from
        ///   from a local cache rather than waiting on a service request.
        /// </summary>
        ///
        /// <value>
        ///   The <see cref="PrefetchCount" /> is a control that developers can use to help tune performance for the specific
        ///   needs of an application, given its expected size of events, throughput needs, and expected scenarios for using
        ///   Event Hubs.
        /// </value>
        ///
        [Option("prefetch-count", HelpText = "Value of EventProcessorClientOptions.PrefetchCount")]
        public int? PrefetchCount { get; set; }

        /// <summary>
        ///   The number of events to receive before writing a checkpoint.
        /// </summary>
        ///
        /// <value>
        ///   If <c>null</c>, no checkpoints will be written.
        /// </value>
        ///
        [Option("checkpoint-interval", HelpText = "Interval between checkpoints (in number of events).  Default is no checkpoints.")]
        public int? CheckpointInterval { get; set; }

        /// <summary>
        ///   The amount of time to delay when processing each event.  This is intended to simulate the work that an
        ///   application would perform in real-world use.
        /// </summary>
        ///
        [Option("processing-delay", HelpText = "Delay when processing each event (in ms)")]
        public int? ProcessingDelayMs { get; set; }

        /// <summary>
        ///   The strategy to use when simulating a processing delay.
        /// </summary>
        ///
        /// <value>
        ///   The strategy has an impact on the precision of timing; when spinning, timing is
        ///   more accurate due to the dependency on the scheduler when sleeping.
        /// </value>
        ///
        [Option("processing-delay-strategy", Default = ProcessingDelayStrategy.Sleep, HelpText = "Whether to sleep or spin during processing delay")]
        public ProcessingDelayStrategy ProcessingDelayStrategy { get; set; }

        /// <summary>
        ///   The number of partitions that the Event Hub used for testing should have.
        /// </summary>
        ///
        [Option("partition-count", Default = 4, HelpText = "The number of partitions that the Event Hub should have.")]
        public int PartitionCount { get; set; }

        /// <summary>
        ///   The number of events to see the Event Hub with, distributed evenly across its partitions.
        /// </summary>
        ///
        [Option("event-seed-count", Default = 200_000, HelpText = "The number of events to seed the Event Hub with.")]
        public int EventSeedCount { get; set; }

        /// <summary>
        ///   The size of the event body, in bytes, for the events to be processed.
        /// </summary>
        ///
        [Option("body-size", HelpText = "Size of event body (in bytes)")]
        public int EventBodySize { get; set; }
    }
}
