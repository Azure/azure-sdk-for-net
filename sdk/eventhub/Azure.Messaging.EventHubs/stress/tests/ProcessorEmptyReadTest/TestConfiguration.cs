using System;

namespace ProcessorEmptyReadTest
{
    internal class TestConfiguration
    {
        // Connection info

        public string EventHubsConnectionString;
        public string EventHub;
        public string StorageConnectionString;
        public string BlobContainer;

        // Reading

        public int ProcessorCount = 1;
        public int EventReadLimitMinutes = 60;
        public TimeSpan ReadTimeout = TimeSpan.FromMinutes(1);
        public TimeSpan? ReadWaitTime = TimeSpan.FromMilliseconds(100);
    }
}