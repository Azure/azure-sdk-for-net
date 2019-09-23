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

    public class MiscTests : ClientTestBase
    {
        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task PartitionKeyValidation()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var NumberOfMessagesToSend = 100;
                var totalReceived = 0;
                var partitionOffsets = new Dictionary<string, string>();
                var receivers = new List<PartitionReceiver>();
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);
                var partitions = await this.GetPartitionsAsync(ehClient);

                try
                {
                    // Discover the end of stream on each partition.
                    TestUtility.Log("Discovering end of stream on each partition.");
                    foreach (var partitionId in partitions)
                    {
                        var lastEvent = await ehClient.GetPartitionRuntimeInformationAsync(partitionId);
                        partitionOffsets.Add(partitionId, lastEvent.LastEnqueuedOffset);
                        TestUtility.Log($"Partition {partitionId} has last message with offset {lastEvent.LastEnqueuedOffset}");
                    }

                    // Now send a set of messages with different partition keys.
                    TestUtility.Log($"Sending {NumberOfMessagesToSend} messages.");
                    Random rnd = new Random();
                    for (int i = 0; i < NumberOfMessagesToSend; i++)
                    {
                        var partitionKey = rnd.Next(10);
                        await ehClient.SendAsync(new EventData(Encoding.UTF8.GetBytes("Hello EventHub!")), partitionKey.ToString());
                    }

                    // It is time to receive all messages that we just sent.
                    // Prepare partition key to partition map while receiving.
                    // Validation: All messages of a partition key should be received from a single partition.
                    TestUtility.Log("Starting to receive all messages from each partition.");
                    var receiveTasks = new Dictionary<string, Task<List<EventData>>>();

                    foreach (var partitionId in partitions)
                    {
                        var receiver = ehClient.CreateReceiver(
                            PartitionReceiver.DefaultConsumerGroupName,
                            partitionId,
                            EventPosition.FromOffset(partitionOffsets[partitionId]));

                        receivers.Add(receiver);
                        receiveTasks.Add(partitionId, ReceiveAllMessagesAsync(receiver));
                    }

                    var partitionMap = new Dictionary<string, string>();

                    foreach (var receiveTask in receiveTasks)
                    {
                        var partitionId = receiveTask.Key;
                        var messagesFromPartition = await receiveTask.Value;
                        totalReceived += messagesFromPartition.Count;

                        TestUtility.Log($"Received {messagesFromPartition.Count} messages from partition {partitionId}.");
                        foreach (var ed in messagesFromPartition)
                        {
                            var pk = ed.SystemProperties.PartitionKey;
                            if (partitionMap.ContainsKey(pk) && partitionMap[pk] != partitionId)
                            {
                                throw new Exception($"Received a message from partition {partitionId} with partition key {pk}, whereas the same key was observed on partition {partitionMap[pk]} before.");
                            }

                            partitionMap[pk] = partitionId;
                        }
                    }
                }
                finally
                {
                    await Task.WhenAll(receivers.Select(receiver => receiver.CloseAsync()));
                    await ehClient.CloseAsync();
                }

                Assert.True(totalReceived == NumberOfMessagesToSend,
                    $"Didn't receive the same number of messages that we sent. Sent: {NumberOfMessagesToSend}, Received: {totalReceived}");
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task SendAndReceiveLargeMessage()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var bodySize = 250 * 1024;
                var targetPartition = "0";
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);

                try
                {
                    using (var edToSend = new EventData(new byte[bodySize]))
                    {
                        TestUtility.Log($"Sending one message with body size {bodySize} bytes.");
                        var edReceived = await SendAndReceiveEventAsync(targetPartition, edToSend, ehClient);

                        // Validate body size.
                        Assert.True(edReceived.Body.Count == bodySize, $"Sent {bodySize} bytes and received {edReceived.Body.Count}");
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
        public async Task ClosingSenderEntity()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);
                var ehSender = ehClient.CreatePartitionSender("0");

                await ehSender.CloseAsync();
                Assert.True(ehSender.IsClosed, "ehSender.IsClosed is not true.");
                Assert.True(!ehClient.IsClosed, "ehClient.IsClosed is not false.");

                // Closing client at this point should be idempotent for child entity.
                await ehClient.CloseAsync();
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task ClosingReceiverEntity()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);
                var ehReceiver = ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, "0", EventPosition.FromStart());

                await ehReceiver.CloseAsync();
                Assert.True(ehReceiver.IsClosed, "ehReceiver.IsClosed is not true.");
                Assert.True(!ehClient.IsClosed, "ehClient.IsClosed is not false.");

                // Closing client at this point should be idempotent for child entity.
                await ehClient.CloseAsync();
            }
        }

        [Fact(Skip = "Test is unstable during nightly runs.  Tracking with #7435")]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task ClosingEventHubClientClosesSenderEntities()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);
                var ehSender0 = ehClient.CreatePartitionSender("0");
                var ehSender1 = ehClient.CreatePartitionSender("1");

                await ehClient.CloseAsync();
                Assert.True(ehSender0.IsClosed, "ehSender0.IsClosed is not true.");
                Assert.True(ehSender1.IsClosed, "ehSender1.IsClosed is not true.");
            }
        }

        [Fact(Skip = "Test is unstable during nightly runs.  Tracking with #7435")]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task ClosingEventHubClientClosesReceiverEntities()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestUtility.BuildEventHubsConnectionString(scope.EventHubName);
                var ehClient = EventHubClient.CreateFromConnectionString(connectionString);
                var ehReceiver = ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, "0", EventPosition.FromStart());
                var ehReceiverEpoch = ehClient.CreateEpochReceiver(PartitionReceiver.DefaultConsumerGroupName, "0", EventPosition.FromEnd(), 0);

                await ehClient.CloseAsync();
                Assert.True(ehReceiver.IsClosed, "ehReceiver.IsClosed is not true.");
                Assert.True(ehReceiverEpoch.IsClosed, "ehReceiverEpoch.IsClosed is not true.");
            }
        }
    }
}