using System;
using System.Diagnostics;
using System.Threading;

namespace EventProducerTest
{
    internal class Metrics
    {
        // Environment statistics
        public long MemorySamples = 0;
        public long TotalMemoryUsed = 0;
        public long MemoryUsed = 0;
        public long PeakPhysicalMemory = 0;
        public long TotalAllocatedBytes = 0;
        public long GenerationZeroCollections = 0;
        public long GenerationOneCollections = 0;
        public long GenerationTwoCollections = 0;
        public TimeSpan TotalProcessorTime = TimeSpan.Zero;

        // Basic statistics
        public long PublishAttempts = 0;
        public long EventsPublished = 0;
        public long BatchesPublished = 0;
        public long TotalPublshedSizeBytes = 0;
        public double RunDurationMilliseconds = 0;

        // Exceptions
        public long CanceledSendExceptions = 0;
        public long SendExceptions = 0;
        public long TotalExceptions = 0;
        public long GeneralExceptions = 0;
        public long TimeoutExceptions = 0;
        public long CommunicationExceptions = 0;
        public long ServiceBusyExceptions = 0;
        public long ProducerRestarted = 0;

        public void UpdateEnvironmentStatistics(Process currentProcess)
        {
            var memoryUsed = GC.GetTotalMemory(false);

            Interlocked.Increment(ref MemorySamples);
            Interlocked.Add(ref TotalMemoryUsed, memoryUsed);
            Interlocked.Exchange(ref MemoryUsed, memoryUsed);
            Interlocked.Exchange(ref GenerationZeroCollections, GC.CollectionCount(0));
            Interlocked.Exchange(ref GenerationOneCollections, GC.CollectionCount(1));
            Interlocked.Exchange(ref GenerationTwoCollections, GC.CollectionCount(2));

            if (memoryUsed > Interlocked.Read(ref PeakPhysicalMemory))
            {
                Interlocked.Exchange(ref PeakPhysicalMemory, memoryUsed);
            }

            TotalProcessorTime = currentProcess.TotalProcessorTime;
        }
    }
}