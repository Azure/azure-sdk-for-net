// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public class SendTests : ClientTestBase
    {
        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task SendAndReceiveZeroLengthBody()
        {
            var targetPartition = "0";

            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);

                try
                {
                    using (var zeroBodyEventData = new EventData(new byte[0]))
                    {
                        var edReceived = await SendAndReceiveEventAsync(targetPartition, zeroBodyEventData, ehClient);

                        // Validate body.
                        Assert.True(edReceived.Body.Count == 0, $"Received event's body isn't zero byte long.");
                    }
                }
                finally
                {
                    await ehClient.CloseAsync();
                }
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task SendSingleEvent()
        {
            TestUtility.Log("Sending single Event via EventHubClient.SendAsync(EventData, string)");

            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);

                try
                {
                    using (var eventData = new EventData(Encoding.UTF8.GetBytes("Hello EventHub by partitionKey!")))
                    {
                        await ehClient.SendAsync(eventData, "SomePartitionKeyHere");
                    }
                }
                finally
                {
                    await ehClient.CloseAsync();
                }
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task SendBatch()
        {
            TestUtility.Log("Sending multiple Events via EventHubClient.SendAsync(IEnumerable<EventData>)");

            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);

                try
                {
                    using (var eventData1 = new EventData(Encoding.UTF8.GetBytes("Hello EventHub!")))
                    using (var eventData2 = new EventData(Encoding.UTF8.GetBytes("This is another message in the batch!")))
                    {
                        eventData2.Properties["ContosoEventType"] = "some value here";
                        await ehClient.SendAsync(new[] { eventData1, eventData2 });
                    }
                }
                finally
                {
                    await ehClient.CloseAsync();
                }
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task PartitionSenderSend()
        {
            TestUtility.Log("Sending single Event via PartitionSender.SendAsync(EventData)");

            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);
                var partitionSender1 = ehClient.CreatePartitionSender("1");

                try
                {
                    using (var eventData = new EventData(Encoding.UTF8.GetBytes("Hello again EventHub Partition 1!")))
                    {
                        await partitionSender1.SendAsync(eventData);
                    }
                }
                finally
                {
                    await Task.WhenAll(
                        partitionSender1?.CloseAsync(),
                        ehClient.CloseAsync());
                }
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task PartitionSenderSendBatch()
        {
            TestUtility.Log("Sending single Event via PartitionSender.SendAsync(IEnumerable<EventData>)");

            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);
                var partitionSender1 = ehClient.CreatePartitionSender("0");

                try
                {
                    using (var eventData1 = new EventData(Encoding.UTF8.GetBytes("Hello EventHub!")))
                    using (var eventData2 = new EventData(Encoding.UTF8.GetBytes("This is another message in the batch!")))
                    {
                        eventData2.Properties["ContosoEventType"] = "some value here";
                        await partitionSender1.SendAsync(new[] { eventData1, eventData2 });
                    }
                }
                finally
                {
                    await Task.WhenAll(
                        partitionSender1?.CloseAsync(),
                        ehClient.CloseAsync());
                }
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task SendAndReceiveArraySegmentEventData()
        {
            var targetPartition = "0";
            var byteArr = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);

                try
                {
                    using (var edToSend = new EventData(new ArraySegment<byte>(byteArr)))
                    {
                        var edReceived = await SendAndReceiveEventAsync(targetPartition, edToSend, ehClient);

                        // Validate array segment count.
                        Assert.True(edReceived.Body.Count == byteArr.Count(), $"Sent {byteArr.Count()} bytes and received {edReceived.Body.Count}");
                    }
                }
                finally
                {
                    await ehClient.CloseAsync();
                }
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task MultipleClientsSend()
        {
            var maxNumberOfClients = 100;
            var startGate = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            TestUtility.Log($"Starting {maxNumberOfClients} SendAsync tasks in parallel.");

            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var tasks = new List<Task>();

                for (var i = 0; i < maxNumberOfClients; i++)
                {
                    var task = Task.Run(async () =>
                    {
                        await startGate.Task;
                        var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                        var ehClient = EventHubClient.CreateFromConnectionString(connectionString);

                        try
                        {
                            await ehClient.SendAsync(new EventData(Encoding.UTF8.GetBytes("Hello EventHub!")));
                        }
                        finally
                        {
                            await ehClient.CloseAsync();
                        }
                    });

                    tasks.Add(task);
                }

                await Task.Delay(10000);
                startGate.TrySetResult(true);
                await Task.WhenAll(tasks);
            }

            TestUtility.Log("All Send tasks have completed.");
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task CloseSenderClient()
        {

            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);
                var pSender = ehClient.CreatePartitionSender("0");
                var pReceiver = ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, "0", EventPosition.FromStart());

                try
                {
                    TestUtility.Log("Sending single event to partition 0");
                    using (var eventData = new EventData(Encoding.UTF8.GetBytes("Hello EventHub!")))
                    {
                        await pSender.SendAsync(eventData);
                        TestUtility.Log("Closing partition sender");
                        await pSender.CloseAsync();
                    }

                    await Assert.ThrowsAsync<InvalidOperationException>(async () =>
                    {
                        TestUtility.Log("Sending another event to partition 0 on the closed sender, this should fail");
                        using (var eventData = new EventData(Encoding.UTF8.GetBytes("Hello EventHub!")))
                        {
                            await pSender.SendAsync(eventData);
                        }
                    });
                }
                finally
                {
                    await Task.WhenAll(
                        pReceiver.CloseAsync(),
                        ehClient.CloseAsync());
                }
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task SendBatchWithPartitionKey()
        {
            string targetPartitionKey = "this is the partition key";

            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);
                var receiver = default(PartitionReceiver);

                try
                {
                    // Mark end of each partition so that we can start reading from there.
                    var partitionIds = await this.GetPartitionsAsync(ehClient);
                    var partitions = await TestUtility.DiscoverEndOfStreamForPartitionsAsync(ehClient, partitionIds);

                    // Send a batch of 2 messages.
                    using (var eventData1 = new EventData(Guid.NewGuid().ToByteArray()))
                    using (var eventData2 = new EventData(Guid.NewGuid().ToByteArray()))
                    {
                        await ehClient.SendAsync(new[] { eventData1, eventData2 }, targetPartitionKey);
                    }

                    // Now find out the partition where our messages landed.
                    var targetPartition = "";
                    foreach (var pId in partitionIds)
                    {
                        var pInfo = await ehClient.GetPartitionRuntimeInformationAsync(pId);
                        if (pInfo.LastEnqueuedOffset != partitions[pId])
                        {
                            targetPartition = pId;
                            TestUtility.Log($"Batch landed on partition {targetPartition}");
                        }
                    }

                    // Confirm that we identified the partition with our messages.
                    Assert.True(targetPartition != "", "None of the partition offsets moved.");

                    // Receive all messages from target partition.
                    receiver = ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, targetPartition, EventPosition.FromOffset(partitions[targetPartition]));
                    var messages = await ReceiveAllMessagesAsync(receiver);

                    // Validate 2 messages received.
                    Assert.True(messages.Count == 2, $"Received {messages.Count} messages instead of 2.");

                    // Validate both messages carry correct partition id.
                    Assert.True(messages[0].SystemProperties.PartitionKey == targetPartitionKey,
                        $"First message returned partition key value '{messages[0].SystemProperties.PartitionKey}'");
                    Assert.True(messages[1].SystemProperties.PartitionKey == targetPartitionKey,
                        $"Second message returned partition key value '{messages[1].SystemProperties.PartitionKey}'");
                }
                finally
                {
                    await Task.WhenAll(
                        receiver?.CloseAsync(),
                        ehClient.CloseAsync());
                }
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task SendNonrescannableEnumerator()
        {
            int numberOfEvents = 10;
            string partitionId = "0";

            IEnumerable<EventData> GetBatch()
            {
                for (int i = 0; i < numberOfEvents; i++)
                {
                    yield return new EventData(Encoding.UTF8.GetBytes(i.ToString()));
                }
            }

            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);
                var ehSender = ehClient.CreatePartitionSender(partitionId);

                try
                {
                    // Mark end of each partition so that we can start reading from there.
                    var pInfo = await ehClient.GetPartitionRuntimeInformationAsync(partitionId);

                    // Send events provided by enumerator
                    var events = GetBatch();
                    await ehSender.SendAsync(events);

                    // Receive all messages from partition.
                    var receiver = ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, partitionId, EventPosition.FromOffset(pInfo.LastEnqueuedOffset));
                    var messages = await ReceiveAllMessagesAsync(receiver);

                    // All messages received.
                    Assert.True(messages.Count == numberOfEvents, $"Received { messages.Count } events.");

                    // Validate message contents.
                    for (int i = 0; i < numberOfEvents; i++)
                    {
                        var body = Encoding.UTF8.GetString(messages[i].Body.Array);
                        Assert.True(body == i.ToString(), $"Message body check failed for message { i }. Actual body: { body }.");
                    }
                }
                finally
                {
                    await Task.WhenAll(ehClient.CloseAsync());
                }
            }
        }

    }
}
