// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventHubs.Stress
{
    internal class TestConfig
    {
        // true if the given test should be run.
        public bool Run;

        // Resource Configurations

        public string EventHubsConnectionString;
        public string EventHub;
        public string InstrumentationKey;

        // Test Run Configurations

        public int DurationInHours = 120;

        // Publishing Configurations

        public int ConcurrentSends = 5;
        public int PublishingBodyMinBytes = 100;
        public int PublishingBodyRegularMaxBytes = 262144;
        public int LargeMessageRandomFactorPercent = 50;
        public TimeSpan SendTimeout = TimeSpan.FromMinutes(3);
        public TimeSpan? ProducerPublishingDelay = TimeSpan.FromMilliseconds(4000);
    }
}