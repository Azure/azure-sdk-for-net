// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Messaging.EventHubs.Stress
{
    internal class BufferedProducerTestConfig : TestConfig
    {
        // Test Configurations

        // The number of events to generate and enqueue during each iteration of PerformEnqueue
        public int EventEnqueueListSize = 50;
        public long MaximumEventListSize = 1_000_000;

        // Buffered Producer Configuration

        public TimeSpan MaxWaitTime = TimeSpan.FromSeconds(5);

        private static string[] _roles = { "bufferedpublisher", "bufferedpublisher" };
        public new List<string> Roles = new List<string>(_roles);
    }
}