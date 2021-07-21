﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using CommandLine;

namespace Azure.Messaging.EventHubs.Processor.Perf.Infrastructure
{
    public class ProcessorOptions : PerfOptions
    {
        [Option("loadBalancingStrategy")]
        public LoadBalancingStrategy LoadBalancingStrategy { get; set; } = LoadBalancingStrategy.Greedy;

        [Option("delayMilliseconds", HelpText = "Adds delay after each message received (for debugging)")]
        public int DelayMilliseconds { get; set; }
    }
}
