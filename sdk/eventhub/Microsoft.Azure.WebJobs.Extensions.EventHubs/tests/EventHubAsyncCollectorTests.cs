// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.EventHubs.UnitTests
{
    public class EventHubAsyncCollectorTests
    {
        [Test]
        public void NullArgumentCheck()
        {
            Assert.Throws<ArgumentNullException>(() => new EventHubAsyncCollector(null));
        }

        [Test]
        public async Task SendMultiplePartitions()
        {
            var client = new TestEventHubProducerClient();
            var collector = new EventHubAsyncCollector(client);

            await collector.AddAsync(new EventData(new byte[] { 1 }), "pk1");
            await collector.AddAsync(new EventData(new byte[] { 2 }), "pk2");

            // Not physically sent yet since we haven't flushed
            Assert.IsEmpty(client.SentBatches);

            await collector.FlushAsync();

            // Partitions aren't flushed in a specific order.
            Assert.AreEqual(2, client.SentBatches.Count);
            var batches = client.SentBatches;

            var item0 = batches[0].Events[0].Body.ToArray();
            var item1 = batches[1].Events[0].Body.ToArray();
            Assert.AreEqual(3, item0[0] + item1[0]); // either order.
        }

        [Test]
        public async Task NotSentUntilFlushed()
        {
            var client = new TestEventHubProducerClient();
            var collector = new EventHubAsyncCollector(client);

            await collector.FlushAsync(); // should be nop.

            var payload = new byte[] { 1, 2, 3 };
            var e1 = new EventData(payload);
            await collector.AddAsync(e1);

            // Not physically sent yet since we haven't flushed
            Assert.IsEmpty(client.SentBatches);

            await collector.FlushAsync();
            Assert.AreEqual(1, client.SentBatches.Count);
            Assert.AreEqual(payload, client.SentBatches[0].GetEventPayload(0));
        }

        // If we send enough events, that will eventually tip over and flush.
        [Test]
        public async Task FlushAfterLotsOfSmallEvents()
        {
            var client = new TestEventHubProducerClient(30000);
            var collector = new EventHubAsyncCollector(client);

            // Sending a bunch of little events
            for (int i = 0; i < 150; i++)
            {
                var e1 = new EventData(new byte[] { 1, 2, 3, 4, 5, 6 });
                await collector.AddAsync(e1);
            }

            Assert.True(client.SentBatches.Count > 0);
        }

        // If we send enough events, that will eventually tip over and flush.
        [Test]
        public async Task FlushAfterSizeThreshold()
        {
            var client = new TestEventHubProducerClient();
            var collector = new EventHubAsyncCollector(client);

            // Trip the 1024k EventHub limit.
            for (int i = 0; i < 50; i++)
            {
                var e1 = new EventData(new byte[10 * 1024]);
                await collector.AddAsync(e1);
            }

            // Not yet
            Assert.IsEmpty(client.SentBatches);

            // This will push it over the threshold
            for (int i = 0; i < 60; i++)
            {
                var e1 = new EventData(new byte[10 * 1024]);
                await collector.AddAsync(e1);
            }

            Assert.True(client.SentBatches.Count > 0);
        }

        [Test]
        public async Task CantSentGiantEvent()
        {
            var client = new TestEventHubProducerClient();
            var collector = new EventHubAsyncCollector(client);

            // event hub max is 1024k payload.
            var hugePayload = new byte[1200 * 1024];
            var e1 = new EventData(hugePayload);

            try
            {
                await collector.AddAsync(e1);
                Assert.False(true);
            }
            catch (InvalidOperationException e)
            {
                // Exact error message (and serialization byte size) is subject to change.
                StringAssert.Contains("Event is too large", e.Message);
            }

            // Verify we didn't queue anything
            await collector.FlushAsync();
            Assert.IsEmpty(client.SentBatches.Single().Events);
        }

        [Test]
        public void CantSendNullEvent()
        {
            var client = new TestEventHubProducerClient();
            var collector = new EventHubAsyncCollector(client);

            Assert.ThrowsAsync<ArgumentNullException>(
                async () => await collector.AddAsync(null));
        }

        // Send lots of events from multiple threads and ensure that all events are precisely accounted for.
        [Test]
        public async Task SendLotsOfEvents()
        {
            var client = new TestEventHubProducerClient();
            var collector = new EventHubAsyncCollector(client);

            int numEvents = 1000;
            int numThreads = 10;

            HashSet<string> expected = new HashSet<string>();

            // Send from different physical threads.
            Thread[] threads = new Thread[numThreads];
            for (int iThread = 0; iThread < numThreads; iThread++)
            {
                var x = iThread;
                threads[x] = new Thread(
                    () =>
                    {
                        for (int i = 0; i < numEvents; i++)
                        {
                            var idx = (x * numEvents) + i;
                            var payloadStr = idx.ToString();
                            var payload = Encoding.UTF8.GetBytes(payloadStr);
                            lock (expected)
                            {
                                expected.Add(payloadStr);
                            }
                            collector.AddAsync(new EventData(payload)).Wait();
                        }
                    });
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            // Add more events to trip flushing of the original batch without calling Flush()
            const string ignore = "ignore";
            byte[] ignoreBytes = Encoding.UTF8.GetBytes(ignore);
            for (int i = 0; i < 500; i++)
            {
                await collector.AddAsync(new EventData(ignoreBytes));
            }

            // Verify that every event we sent is accounted for; and that there are no duplicates.
            int count = 0;
            foreach (var sentBatch in client.SentBatches)
            {
                foreach (var sentEvent in sentBatch.Events)
                {
                    count++;
                    var payloadStr = Encoding.UTF8.GetString(sentEvent.Body.ToArray());
                    if (payloadStr == ignore)
                    {
                        continue;
                    }

                    if (!expected.Remove(payloadStr))
                    {
                        // Already removed!
                        Assert.False(true, "event payload occurred multiple times");
                    }
                }
            }

            Assert.IsEmpty(expected); // Some events where missed.
        }

        internal class TestEventHubProducerClient : IEventHubProducerClient
        {
            private readonly long _batchSize;

            public TestEventHubProducerClient(long batchSize = 1024 * 1024)
            {
                _batchSize = batchSize;
            }

            public List<TestEventDataBatch> CreatedBatches { get; } = new List<TestEventDataBatch>();
            public List<TestEventDataBatch> SentBatches { get; } = new List<TestEventDataBatch>();

            public Task<IEventDataBatch> CreateBatchAsync(CancellationToken cancellationToken) =>
                CreateBatchAsync(null, cancellationToken);

            public async Task<IEventDataBatch> CreateBatchAsync(CreateBatchOptions options, CancellationToken cancellationToken)
            {
                var batch = new TestEventDataBatch(_batchSize);

                lock (this)
                {
                    CreatedBatches.Add(batch);
                }

                await Task.Delay(1);

                return batch;
            }

            public async Task SendAsync(IEventDataBatch batch, CancellationToken cancellationToken)
            {
                lock (this)
                {
                    SentBatches.Add((TestEventDataBatch)batch);
                }

                await Task.Delay(1);
            }

            internal class TestEventDataBatch: IEventDataBatch
            {
                private readonly long _batchSize;

                public TestEventDataBatch(long batchSize)
                {
                    _batchSize = batchSize;
                }

                public long CurrentSizeInBytes { get; private set; }
                public List<EventData> Events { get; } = new List<EventData>();
                public int Count => Events.Count;
                public long MaximumSizeInBytes => _batchSize;

                public byte[] GetEventPayload(int i) => Events[i].Body.ToArray();

                public bool TryAdd(EventData eventData)
                {
                    var size = eventData.Body.Length + 400; // Reserve a somewhat random amount for protocol overhead.
                    lock (this)
                    {
                        if (size + CurrentSizeInBytes > MaximumSizeInBytes)
                        {
                            return false;
                        }

                        Events.Add(eventData);
                        CurrentSizeInBytes += size;

                        // Assert they all have the same partition key (could be null)
                        var partitionKey = Events.First().PartitionKey;
                        Assert.AreEqual(partitionKey, eventData.PartitionKey);

                        return true;
                    }
                }
            }
        }
    } // end class
}
