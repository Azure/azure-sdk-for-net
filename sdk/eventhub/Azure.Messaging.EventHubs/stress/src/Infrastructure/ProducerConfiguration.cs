// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventHubs.Stress
{
    internal class ProducerConfiguration
    {
        public string EventHubsConnectionString;
        public string EventHub;
        public string InstrumentationKey;

        // For initial printing purposes ONLY, number of partitions is not configurable after deployment

        public string NumPartitions;

        // Test Run Configurations

        public int DurationInHours = 1;

        // Publishing Configurations

        public int ProducerCount = 2;
        public int ConcurrentSends = 5;
        public int PublishingBodyMinBytes = 100;
        public int PublishingBodyRegularMaxBytes = 757760;
        public int LargeMessageRandomFactorPercent = 50;
        public TimeSpan SendTimeout = TimeSpan.FromMinutes(3);
        public TimeSpan? ProducerPublishingDelay = TimeSpan.FromMilliseconds(4000);

        // EventProducerTest only

        public int PublishBatchSize = 50;

        // BufferedProducerTest only

        public int EventEnqueueListSize = 50;
    }
}