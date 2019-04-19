// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class DataBatchTests : ClientTestBase
    {
        /// <summary>
        /// Utilizes EventDataBatch to send messages as the messages are batched up to max batch size.
        /// </summary>
        [Fact]
        [DisplayTestMethodName]
        async Task Basic()
        {
            await SendWithEventDataBatch();
        }

        /// <summary>
        /// Utilizes EventDataBatch to send small messages.
        /// </summary>
        [Fact]
        [DisplayTestMethodName]
        async Task SendSmallMessages()
        {
            await SendWithEventDataBatch(maxPayloadSize: 8, minimumNumberOfMessagesToSend: 50000);
        }

        /// <summary>
        /// Utilizes EventDataBatch to send large messages.
        /// </summary>
        [Fact]
        [DisplayTestMethodName]
        async Task SendLargeMessages()
        {
            await SendWithEventDataBatch(maxPayloadSize: 262000, minimumNumberOfMessagesToSend: 100);
        }

        /// <summary>
        /// Single message close to 1MB should work.
        /// </summary>
        [Fact]
        [DisplayTestMethodName]
        async Task AllowFirstMessageInBatch()
        {
            await SendWithEventDataBatch(maxPayloadSize: 900 * 1024 , minimumNumberOfMessagesToSend: 1);
        }

        /// <summary>
        /// Utilizes EventDataBatch to send messages as the messages are batched up to max batch size.
        /// This unit test sends with partition key.
        /// </summary>
        [Fact]
        [DisplayTestMethodName]
        async Task SendWithPartitionKey()
        {
            await SendWithEventDataBatch(Guid.NewGuid().ToString());
        }

        /// <summary>
        /// Client should not allow to send a batch with partition key on a partition sender.
        /// </summary>
        [Fact]
        [DisplayTestMethodName]
        async Task SendingPartitionKeyBatchOnPartitionSenderShouldFail()
        {
            var partitionSender = this.EventHubClient.CreatePartitionSender("0");
            var batchOptions = new BatchOptions()
            {
                PartitionKey = "this is the partition key"
            };
            var batcher = this.EventHubClient.CreateBatch(batchOptions);

            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                TestUtility.Log("Attempting to send a partition-key batch on partition sender. This should fail.");
                await partitionSender.SendAsync(batcher);
                throw new InvalidOperationException("SendAsync call should have failed");
            });
        }

        /// <summary>
        /// PartitionSender should not allow to create a batch with partition key defined.
        /// </summary>
        [Fact]
        [DisplayTestMethodName]
        async Task CreatingPartitionKeyBatchOnPartitionSenderShouldFail()
        {
            var partitionSender = this.EventHubClient.CreatePartitionSender("0");

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
            {
                TestUtility.Log("Attempting to create a partition-key batch on partition sender. This should fail.");
                partitionSender.CreateBatch(new BatchOptions()
                {
                    PartitionKey = "this is the key to fail"
                });
                throw new InvalidOperationException("CreateBatch call should have failed");
            });
        }

        protected async Task SendWithEventDataBatch(
            string partitionKey = null,
            int maxPayloadSize = 1024,
            int minimumNumberOfMessagesToSend = 1000)
        {
            var receivers = new List<PartitionReceiver>();

            // Create partition receivers starting from the end of the stream.
            TestUtility.Log("Discovering end of stream on each partition.");
            foreach (var partitionId in this.PartitionIds)
            {
                var lastEvent = await this.EventHubClient.GetPartitionRuntimeInformationAsync(partitionId);
                receivers.Add(this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, partitionId, EventPosition.FromOffset(lastEvent.LastEnqueuedOffset)));
            }

            try
            {
                // Start receicing messages now.
                var receiverTasks = new List<Task<List<EventData>>>();
                foreach (var receiver in receivers)
                {
                    receiverTasks.Add(ReceiveAllMessagesAsync(receiver));
                }

                // Create initial batcher.
                EventDataBatch batcher = null;

                // We will send a thousand messages where each message is 1K.
                var totalSent = 0;
                var rnd = new Random();
                TestUtility.Log("Starting to send.");
                do
                {
                    if (batcher == null)
                    {
                        // Exercise both CreateBatch overloads.
                        if (partitionKey != null)
                        {
                            batcher = this.EventHubClient.CreateBatch(new BatchOptions()
                            {
                                PartitionKey = partitionKey
                            });
                        }
                        else
                        {
                            batcher = this.EventHubClient.CreateBatch();
                        }
                    }

                    // Send random body size.
                    var ed = new EventData(new byte[rnd.Next(0, maxPayloadSize)]);
                    if (!batcher.TryAdd(ed) || totalSent + batcher.Count >= minimumNumberOfMessagesToSend)
                    {
                        await this.EventHubClient.SendAsync(batcher);
                        totalSent += batcher.Count;
                        TestUtility.Log($"Sent {batcher.Count} messages in the batch.");
                        batcher = null;
                    }
                } while (totalSent < minimumNumberOfMessagesToSend);

                TestUtility.Log($"{totalSent} messages sent in total.");

                var pReceived = await Task.WhenAll(receiverTasks);
                var totalReceived = pReceived.Sum(p => p.Count);
                TestUtility.Log($"{totalReceived} messages received in total.");

                // Sent at least a message?
                Assert.True(totalSent > 0, $"Client was not able to send any messages.");

                // All messages received?
                Assert.True(totalReceived == totalSent, $"Sent {totalSent}, but received {totalReceived} messages.");

                if (partitionKey != null)
                {
                    // Partition key is set then we expect all messages from the same partition.
                    Assert.True(pReceived.Count(p => p.Count > 0) == 1, "Received messsages from multiple partitions.");

                    // Find target partition.
                    var targetPartition = pReceived.Single(p => p.Count > 0);

                    // Validate partition key is delivered on all messages.
                    Assert.True(!targetPartition.Any(p => p.SystemProperties.PartitionKey != partitionKey), "Identified at least one event with a different partition key value.");
                }
            }
            finally
            {
                await Task.WhenAll(receivers.Select(r => r.CloseAsync()));
            }
        }
    }
}
