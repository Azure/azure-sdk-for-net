using System;

namespace EventProducerTest
{
    internal class TestConfiguration
    {
        // Connection info

        public string EventHubsConnectionString;
        public string EventHub;

        // Publishing

        public int ProducerCount = 2;
        public int ConcurrentSends = 5;
        public int PublishBatchSize = 50;
        public int PublishingBodyMinBytes = 100;
        public int PublishingBodyRegularMaxBytes = 757760;
        public int LargeMessageRandomFactorPercent = 50;
        public TimeSpan SendTimeout = TimeSpan.FromMinutes(3);
        public TimeSpan? PublishingDelay = TimeSpan.FromMilliseconds(15);
    }
}