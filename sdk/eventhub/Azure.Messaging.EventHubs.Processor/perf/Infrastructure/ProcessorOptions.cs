// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using CommandLine;

namespace Azure.Messaging.EventHubs.Processor.Perf.Infrastructure
{
    public class ProcessorOptions : PerfOptions
    {
        [Option("cache-event-count", HelpText = "Value of EventProcessorClientOptions.CacheEventCount")]
        public int? CacheEventCount { get; set; }

        [Option("checkpoint-interval", HelpText = "Interval between checkpoints (in number of events).  Default is no checkpoints.")]
        public int? CheckpointInterval { get; set; }

        [Option("load-balancing-strategy", Default = LoadBalancingStrategy.Greedy,
                HelpText = "Value of EventProcessorClientOptions.LoadBalancingStrategy")]
        public LoadBalancingStrategy LoadBalancingStrategy { get; set; }

        [Option("maximum-wait-time", HelpText = "Value of EventProcessorClientOptions.MaximumWaitTime (in ms)")]
        public int? MaximumWaitTimeMs { get; set; }

        [Option("prefetch-count", HelpText = "Value of EventProcessorClientOptions.PrefetchCount")]
        public int? PrefetchCount { get; set; }

        [Option("processing-delay", HelpText = "Delay when processing each event (in ms)")]
        public int? ProcessingDelayMs { get; set; }

        [Option("processing-delay-strategy", Default = ProcessingDelayStrategy.Sleep,
                HelpText = "Whether to sleep or spin during processing delay")]
        public ProcessingDelayStrategy ProcessingDelayStrategy { get; set; }
    }
}
