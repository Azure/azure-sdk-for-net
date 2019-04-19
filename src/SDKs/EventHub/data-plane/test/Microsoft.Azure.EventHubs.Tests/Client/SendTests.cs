// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class SendTests : ClientTestBase
    {
        [Fact]
        [DisplayTestMethodName]
        async Task SendAndReceiveZeroLengthBody()
        {
            var targetPartition = "0";
            var zeroBodyEventData = new EventData(new byte[0]);
            var edReceived = await SendAndReceiveEventAsync(targetPartition, zeroBodyEventData);

            // Validate body.
            Assert.True(edReceived.Body.Count == 0, $"Received event's body isn't zero byte long.");
        }

        [Fact]
        [DisplayTestMethodName]
        Task SendSingleEvent()
        {
            TestUtility.Log("Sending single Event via EventHubClient.SendAsync(EventData, string)");
            var eventData = new EventData(Encoding.UTF8.GetBytes("Hello EventHub by partitionKey!"));
            return this.EventHubClient.SendAsync(eventData, "SomePartitionKeyHere");
        }

        [Fact]
        [DisplayTestMethodName]
        Task SendBatch()
        {
            TestUtility.Log("Sending multiple Events via EventHubClient.SendAsync(IEnumerable<EventData>)");
            var eventData1 = new EventData(Encoding.UTF8.GetBytes("Hello EventHub!"));
            var eventData2 = new EventData(Encoding.UTF8.GetBytes("This is another message in the batch!"));
            eventData2.Properties["ContosoEventType"] = "some value here";
            return this.EventHubClient.SendAsync(new[] { eventData1, eventData2 });
        }

        [Fact]
        [DisplayTestMethodName]
        async Task PartitionSenderSend()
        {
            TestUtility.Log("Sending single Event via PartitionSender.SendAsync(EventData)");
            PartitionSender partitionSender1 = this.EventHubClient.CreatePartitionSender("1");
            try
            {
                var eventData = new EventData(Encoding.UTF8.GetBytes("Hello again EventHub Partition 1!"));
                await partitionSender1.SendAsync(eventData);
            }
            finally
            {
                await partitionSender1.CloseAsync();
            }
        }

        [Fact]
        [DisplayTestMethodName]
        async Task PartitionSenderSendBatch()
        {
            TestUtility.Log("Sending single Event via PartitionSender.SendAsync(IEnumerable<EventData>)");
            PartitionSender partitionSender1 = this.EventHubClient.CreatePartitionSender("1");
            try
            {
                var eventData1 = new EventData(Encoding.UTF8.GetBytes("Hello EventHub!"));
                var eventData2 = new EventData(Encoding.UTF8.GetBytes("This is another message in the batch!"));
                eventData2.Properties["ContosoEventType"] = "some value here";
                await partitionSender1.SendAsync(new[] { eventData1, eventData2 });
            }
            finally
            {
                await partitionSender1.CloseAsync();
            }
        }

        [Fact]
        [DisplayTestMethodName]
        async Task SendAndReceiveArraySegmentEventData()
        {
            var targetPartition = "0";
            byte[] byteArr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var edToSend = new EventData(new ArraySegment<byte>(byteArr));
            var edReceived = await SendAndReceiveEventAsync(targetPartition, edToSend);

            // Validate array segment count.
            Assert.True(edReceived.Body.Count == byteArr.Count(), $"Sent {byteArr.Count()} bytes and received {edReceived.Body.Count}");
        }

        [Fact]
        [DisplayTestMethodName]
        async Task MultipleClientsSend()
        {
            var maxNumberOfClients = 100;
            var syncEvent = new ManualResetEventSlim(false);

            TestUtility.Log($"Starting {maxNumberOfClients} SendAsync tasks in parallel.");

            var tasks = new List<Task>();
            for (var i = 0; i < maxNumberOfClients; i++)
            {
                var task = Task.Run(async () =>
                {
                    syncEvent.Wait();
                    var ehClient = EventHubClient.CreateFromConnectionString(TestUtility.EventHubsConnectionString);
                    await ehClient.SendAsync(new EventData(Encoding.UTF8.GetBytes("Hello EventHub!")));
                });

                tasks.Add(task);
            }

            var waitForAccountToInitialize = Task.Delay(10000);
            await waitForAccountToInitialize;
            syncEvent.Set();
            await Task.WhenAll(tasks);

            TestUtility.Log("All Send tasks have completed.");
        }

        [Fact]
        [DisplayTestMethodName]
        async Task CloseSenderClient()
        {
            var pSender = this.EventHubClient.CreatePartitionSender("0");
            var pReceiver = this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, "0", EventPosition.FromStart());

            try
            {
                TestUtility.Log("Sending single event to partition 0");
                var eventData = new EventData(Encoding.UTF8.GetBytes("Hello EventHub!"));
                await pSender.SendAsync(eventData);

                TestUtility.Log("Closing partition sender");
                await pSender.CloseAsync();

                await Assert.ThrowsAsync<ObjectDisposedException>(async () =>
                {
                    TestUtility.Log("Sending another event to partition 0 on the closed sender, this should fail");
                    eventData = new EventData(Encoding.UTF8.GetBytes("Hello EventHub!"));
                    await pSender.SendAsync(eventData);
                    throw new InvalidOperationException("Send should have failed");
                });
            }
            finally
            {
                await pReceiver.CloseAsync();
            }
        }

        [Fact]
        [DisplayTestMethodName]
        async Task SendBatchWithPartitionKey()
        {
            string targetPartitionKey = "this is the partition key";

            // Mark end of each partition so that we can start reading from there.
            var partitions = await TestUtility.DiscoverEndOfStreamForPartitionsAsync(this.EventHubClient, this.PartitionIds);

            // Send a batch of 2 messages.
            var eventData1 = new EventData(Guid.NewGuid().ToByteArray());
            var eventData2 = new EventData(Guid.NewGuid().ToByteArray());
            await this.EventHubClient.SendAsync(new[] { eventData1, eventData2 }, targetPartitionKey);

            // Now find out the partition where our messages landed.
            var targetPartition = "";
            foreach (var pId in this.PartitionIds)
            {
                var pInfo = await this.EventHubClient.GetPartitionRuntimeInformationAsync(pId);
                if (pInfo.LastEnqueuedOffset != partitions[pId])
                {
                    targetPartition = pId;
                    TestUtility.Log($"Batch landed on partition {targetPartition}");
                }
            }

            // Confirm that we identified the partition with our messages.
            Assert.True(targetPartition != "", "None of the partition offsets moved.");

            // Receive all messages from target partition.
            var receiver = this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, targetPartition, EventPosition.FromOffset(partitions[targetPartition]));
            var messages = await ReceiveAllMessagesAsync(receiver);

            // Validate 2 messages received.
            Assert.True(messages.Count == 2, $"Received {messages.Count} messages instead of 2.");

            // Validate both messages carry correct partition id.
            Assert.True(messages[0].SystemProperties.PartitionKey == targetPartitionKey,
                $"First message returned partition key value '{messages[0].SystemProperties.PartitionKey}'");
            Assert.True(messages[1].SystemProperties.PartitionKey == targetPartitionKey,
                $"Second message returned partition key value '{messages[1].SystemProperties.PartitionKey}'");
        }
    }
}
