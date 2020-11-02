// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Xunit;

using static Microsoft.Azure.EventHubs.EventData;

namespace Microsoft.Azure.WebJobs.EventHubs.UnitTests
{
    public class EventHubAsyncCollectorTests
    {
        [Fact]
        public void NullArgumentCheck()
        {
            Assert.Throws<ArgumentNullException>(() => new EventHubAsyncCollector(null, null));
        }

        public EventData CreateEvent(byte[] body, string partitionKey)
        {
            var data = new EventData(body);
            IDictionary<string, object> sysProps = TestHelpers.New<SystemPropertiesCollection>();
            sysProps["x-opt-partition-key"] = partitionKey;
            TestHelpers.SetField(data, "SystemProperties", sysProps);
            return data;
        }

        [Fact]
        public async Task SendMultiplePartitions()
        {
            var collector = new TestEventHubAsyncCollector();

            await collector.AddAsync(this.CreateEvent(new byte[] { 1 }, "pk1"));
            await collector.AddAsync(CreateEvent(new byte[] { 2 }, "pk2"));

            // Not physically sent yet since we haven't flushed
            Assert.Empty(collector.SentEvents);

            await collector.FlushAsync();

            // Partitions aren't flushed in a specific order.
            Assert.Equal(2, collector.SentEvents.Count);
            var items = collector.SentEvents.ToArray();

            var item0 = items[0];
            var item1 = items[1];
            Assert.Equal(3, item0[0] + item1[0]); // either order.
        }

        [Fact]
        public async Task NotSentUntilFlushed()
        {
            var collector = new TestEventHubAsyncCollector();

            await collector.FlushAsync(); // should be nop.

            var payload = new byte[] { 1, 2, 3 };
            var e1 = new EventData(payload);
            await collector.AddAsync(e1);

            // Not physically sent yet since we haven't flushed
            Assert.Empty(collector.SentEvents);

            await collector.FlushAsync();
            Assert.Single(collector.SentEvents);
            Assert.Equal(payload, collector.SentEvents[0]);
        }

        // If we send enough events, that will eventually tip over and flush.
        [Fact]
        public async Task FlushAfterLotsOfSmallEvents()
        {
            var collector = new TestEventHubAsyncCollector();

            // Sending a bunch of little events
            for (int i = 0; i < 150; i++)
            {
                var e1 = new EventData(new byte[] { 1, 2, 3 });
                await collector.AddAsync(e1);
            }

            Assert.True(collector.SentEvents.Count > 0);
        }

        // If we send enough events, that will eventually tip over and flush.
        [Fact]
        public async Task FlushAfterSizeThreshold()
        {
            var collector = new TestEventHubAsyncCollector();

            // Trip the 1024k EventHub limit.
            for (int i = 0; i < 50; i++)
            {
                var e1 = new EventData(new byte[10 * 1024]);
                await collector.AddAsync(e1);
            }

            // Not yet
            Assert.Empty(collector.SentEvents);

            // This will push it over the theshold
            for (int i = 0; i < 60; i++)
            {
                var e1 = new EventData(new byte[10 * 1024]);
                await collector.AddAsync(e1);
            }

            Assert.True(collector.SentEvents.Count > 0);
        }

        [Fact]
        public async Task CantSentGiantEvent()
        {
            var collector = new TestEventHubAsyncCollector();

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
                Assert.Contains("Event is too large", e.Message);
            }

            // Verify we didn't queue anything
            await collector.FlushAsync();
            Assert.Empty(collector.SentEvents);
        }

        [Fact]
        public async Task CantSendNullEvent()
        {
            var collector = new TestEventHubAsyncCollector();

            await Assert.ThrowsAsync<ArgumentNullException>(
                async () => await collector.AddAsync(null));
        }

        // Send lots of events from multiple threads and ensure that all events are precisely accounted for.
        [Fact]
        public async Task SendLotsOfEvents()
        {
            var collector = new TestEventHubAsyncCollector();

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
            for (int i = 0; i < 100; i++)
            {
                await collector.AddAsync(new EventData(ignoreBytes));
            }

            // Verify that every event we sent is accounted for; and that there are no duplicates.
            int count = 0;
            foreach (var payloadBytes in collector.SentEvents)
            {
                count++;
                var payloadStr = Encoding.UTF8.GetString(payloadBytes);
                if (payloadStr == ignore)
                {
                    continue;
                }

                if (!expected.Remove(payloadStr))
                {
                    // Already removed!
                    Assert.False(true, "event payload occured multiple times");
                }
            }

            Assert.Empty(expected); // Some events where missed.
        }

        internal class TestEventHubAsyncCollector : EventHubAsyncCollector
        {
            private static EventHubClient testClient = EventHubClient.CreateFromConnectionString(FakeConnectionString1);

            // EventData is disposed after sending. So track raw bytes; not the actual EventData.
            private List<byte[]> sentEvents = new List<byte[]>();

            // A fake connection string for event hubs. This just needs to parse. It won't actually get invoked.
            private const string FakeConnectionString = "Endpoint=sb://test89123-ns-x.servicebus.windows.net/;SharedAccessKeyName=ReceiveRule;SharedAccessKey=secretkey;EntityPath=path2";

            public TestEventHubAsyncCollector()
                : base(TestClient, null)
            {
            }

            public static EventHubClient TestClient { get => testClient; set => testClient = value; }

            public static string FakeConnectionString1 => FakeConnectionString;

            public List<byte[]> SentEvents { get => sentEvents; set => sentEvents = value; }

            protected override Task SendBatchAsync(IEnumerable<EventData> batch)
            {
                // Assert they all have the same partition key (could be null)
                var partitionKey = batch.First().SystemProperties?.PartitionKey;
                foreach (var e in batch)
                {
                    Assert.Equal(partitionKey, e.SystemProperties?.PartitionKey);
                }

                lock (SentEvents)
                {
                    foreach (var e in batch)
                    {
                        var payloadBytes = e.Body.Array;
                        Assert.NotNull(payloadBytes);
                        SentEvents.Add(payloadBytes);
                    }
                }

                return Task.FromResult(0);
            }
        }
    } // end class
}
