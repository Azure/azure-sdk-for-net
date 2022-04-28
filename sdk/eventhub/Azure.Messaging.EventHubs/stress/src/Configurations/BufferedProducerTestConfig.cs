// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventHubs.Stress
{
    internal class BufferedProducerTestConfig : TestConfig
    {
        // Test Configurations

        // The number of events to generate and enqueue during each iteration of PerformEnqueue
        public int EventEnqueueListSize = 50;
        public long MaximumEventListSize = 1000000;

        // Buffered Producer Configuration

        public TimeSpan MaxWaitTime = TimeSpan.FromMilliseconds(5000);
    }
}