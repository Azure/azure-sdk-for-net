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

   public class ReceiverTests : ClientTestBase
    {
        [Fact]
        [DisplayTestMethodName]
        async Task PartitionReceiverReceive()
        {
            string partitionId = "1";
            string payloadString = "Hello EventHub!";

            TestUtility.Log("Receiving Events via PartitionReceiver.ReceiveAsync");
            var sendEvent = new EventData(Encoding.UTF8.GetBytes(payloadString));
            var receivedEvent = await SendAndReceiveEventAsync(partitionId, sendEvent);
            Assert.True(Encoding.UTF8.GetString(receivedEvent.Body.Array) == payloadString, "Received payload string isn't the same as sent payload string.");
        }

        [Fact]
        [DisplayTestMethodName]
        async Task CreateReceiverWithEndOfStream()
        {
            // Randomly pick one of the available partitons.
            var partitionId = this.PartitionIds[new Random().Next(this.PartitionIds.Count())];
            TestUtility.Log($"Randomly picked partition {partitionId}");

            var partitionSender = this.EventHubClient.CreatePartitionSender(partitionId);

            // Send couple of messages before creating an EndOfStream receiver.
            // We are not expecting to receive these messages would be sent before receiver creation.
            for (int i = 0; i < 10; i++)
            {
                var ed = new EventData(new byte[1]);
                await partitionSender.SendAsync(ed);
            }

            // Create a new receiver which will start reading from the end of the stream.
            TestUtility.Log($"Creating a new receiver with offset EndOFStream");
            var receiver = this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, partitionId, EventPosition.FromEnd());

            try
            {
                // Attemp to receive the message. This should return only 1 message.
                var receiveTask = receiver.ReceiveAsync(100);

                // Send a new message which is expected to go to the end of stream.
                // We are expecting to receive only this message.
                // Wait 5 seconds before sending to avoid race.
                await Task.Delay(5000);
                var eventToReceive = new EventData(new byte[1]);
                eventToReceive.Properties["stamp"] = Guid.NewGuid().ToString();
                await partitionSender.SendAsync(eventToReceive);

                // Complete asyncy receive task.
                var receivedMessages = await receiveTask;

                // We should have received only 1 message from this call.
                Assert.True(receivedMessages.Count() == 1, $"Didn't receive 1 message. Received {receivedMessages.Count()} messages(s).");

                // Check stamp.
                Assert.True(receivedMessages.Single().Properties["stamp"].ToString() == eventToReceive.Properties["stamp"].ToString()
                    , "Stamps didn't match on the message sent and received!");

                TestUtility.Log("Received correct message as expected.");

                // Next receive on this partition shouldn't return any more messages.
                receivedMessages = await receiver.ReceiveAsync(100, TimeSpan.FromSeconds(15));
                Assert.True(receivedMessages == null, $"Received messages at the end.");
            }
            finally
            {
                await partitionSender.CloseAsync();
                await receiver.CloseAsync();
            }
        }

        [Fact]
        [DisplayTestMethodName]
        async Task CreateReceiverWithOffset()
        {
            // Randomly pick one of the available partitons.
            var partitionId = this.PartitionIds[new Random().Next(this.PartitionIds.Count())];
            TestUtility.Log($"Randomly picked partition {partitionId}");

            // Send and receive a message to identify the end of stream.
            var pInfo = await this.EventHubClient.GetPartitionRuntimeInformationAsync(partitionId);

            // Send a new message which is expected to go to the end of stream.
            // We are expecting to receive only this message.
            var eventSent = new EventData(new byte[1]);
            eventSent.Properties["stamp"] = Guid.NewGuid().ToString();
            await this.EventHubClient.CreatePartitionSender(partitionId).SendAsync(eventSent);

            // Create a new receiver which will start reading from the last message on the stream.
            TestUtility.Log($"Creating a new receiver with offset {pInfo.LastEnqueuedOffset}");
            var receiver = this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, partitionId, EventPosition.FromOffset(pInfo.LastEnqueuedOffset));

            try
            {
                var receivedMessages = await receiver.ReceiveAsync(100);

                // We should have received only 1 message from this call.
                Assert.True(receivedMessages.Count() == 1, $"Didn't receive 1 message. Received {receivedMessages.Count()} messages(s).");

                // Check stamp.
                Assert.True(receivedMessages.Single().Properties["stamp"].ToString() == eventSent.Properties["stamp"].ToString()
                    , "Stamps didn't match on the message sent and received!");

                TestUtility.Log("Received correct message as expected.");

                // Next receive on this partition shouldn't return any more messages.
                receivedMessages = await receiver.ReceiveAsync(100, TimeSpan.FromSeconds(15));
                Assert.True(receivedMessages == null, $"Received messages at the end.");
            }
            finally
            {
                await receiver.CloseAsync();
            }
        }

        [Fact]
        [DisplayTestMethodName]
        async Task CreateReceiverWithInclusiveOffset()
        {
            // Randomly pick one of the available partitons.
            var partitionId = this.PartitionIds[new Random().Next(this.PartitionIds.Count())];
            TestUtility.Log($"Randomly picked partition {partitionId}");

            await TestUtility.SendToPartitionAsync(this.EventHubClient, partitionId, $"{partitionId} event.");

            // Find out where to start reading on the partition.
            var pInfo = await this.EventHubClient.GetPartitionRuntimeInformationAsync(partitionId);

            // Send a message which is expected to go to the end of stream.
            // We are expecting to receive this message as well.
            await TestUtility.SendToPartitionAsync(this.EventHubClient, partitionId, $"{partitionId} event.");

            // Create a new receiver which will start reading from the last message on the stream.
            TestUtility.Log($"Creating a new receiver with offset {pInfo.LastEnqueuedOffset}");
            var receiver = this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, partitionId, EventPosition.FromOffset(pInfo.LastEnqueuedOffset, true));

            try
            {
                var receivedMessages =  await ReceiveAllMessagesAsync(receiver);

                // We should have received only 1 message from this call.
                Assert.True(receivedMessages.Count() == 2, $"Didn't receive 2 messages. Received {receivedMessages.Count()} messages(s).");

                // Next receive on this partition shouldn't return any more messages.
                var expectNull = await receiver.ReceiveAsync(100, TimeSpan.FromSeconds(15));
                Assert.True(expectNull == null, $"Received messages at the end.");
            }
            finally
            {
                await receiver.CloseAsync();
            }
        }

        [Fact]
        [DisplayTestMethodName]
        async Task CreateReceiverWithDateTime()
        {
            // Randomly pick one of the available partitons.
            var partitionId = this.PartitionIds[new Random().Next(this.PartitionIds.Count())];
            TestUtility.Log($"Randomly picked partition {partitionId}");

            // Send and receive a message to identify the end of stream.
            var pInfo = await this.EventHubClient.GetPartitionRuntimeInformationAsync(partitionId);

            // Send a new message which is expected to go to the end of stream.
            // We are expecting to receive only this message.
            var eventSent = new EventData(new byte[1]);
            eventSent.Properties["stamp"] = Guid.NewGuid().ToString();
            await this.EventHubClient.CreatePartitionSender(partitionId).SendAsync(eventSent);

            // Create a new receiver which will start reading from the last message on the stream.
            TestUtility.Log($"Creating a new receiver with date-time {pInfo.LastEnqueuedTimeUtc}");
            var receiver = this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, partitionId, EventPosition.FromEnqueuedTime(pInfo.LastEnqueuedTimeUtc));

            try
            {
                var receivedMessages = await receiver.ReceiveAsync(100);

                // We should have received only 1 message from this call.
                Assert.True(receivedMessages.Count() == 1, $"Didn't receive 1 message. Received {receivedMessages.Count()} messages(s).");

                // Check stamp.
                Assert.True(receivedMessages.Single().Properties["stamp"].ToString() == eventSent.Properties["stamp"].ToString()
                    , "Stamps didn't match on the message sent and received!");

                TestUtility.Log("Received correct message as expected.");

                // Next receive on this partition shouldn't return any more messages.
                receivedMessages = await receiver.ReceiveAsync(100, TimeSpan.FromSeconds(15));
                Assert.True(receivedMessages == null, $"Received messages at the end.");
            }
            finally
            {
                await receiver.CloseAsync();
            }
        }

        [DisplayTestMethodName]
        async Task CreateReceiverWithSequenceNumber()
        {
            // Randomly pick one of the available partitons.
            var partitionId = this.PartitionIds[new Random().Next(this.PartitionIds.Count())];
            TestUtility.Log($"Randomly picked partition {partitionId}");

            // Send and receive a message to identify the end of stream.
            var pInfo = await this.EventHubClient.GetPartitionRuntimeInformationAsync(partitionId);

            // Send a new message which is expected to go to the end of stream.
            // We are expecting to receive only this message.
            var eventSent = new EventData(new byte[1]);
            eventSent.Properties["stamp"] = Guid.NewGuid().ToString();
            await this.EventHubClient.CreatePartitionSender(partitionId).SendAsync(eventSent);

            // Create a new receiver which will start reading from the last message on the stream.
            TestUtility.Log($"Creating a new receiver with sequence number {pInfo.LastEnqueuedSequenceNumber}");
            var receiver = this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, partitionId, EventPosition.FromSequenceNumber(pInfo.LastEnqueuedSequenceNumber));

            try
            {
                var receivedMessages = await receiver.ReceiveAsync(100);

                // We should have received only 1 message from this call.
                Assert.True(receivedMessages.Count() == 1, $"Didn't receive 1 message. Received {receivedMessages.Count()} messages(s).");

                // Check stamp.
                Assert.True(receivedMessages.Single().Properties["stamp"].ToString() == eventSent.Properties["stamp"].ToString()
                    , "Stamps didn't match on the message sent and received!");

                TestUtility.Log("Received correct message as expected.");

                // Next receive on this partition shouldn't return any more messages.
                receivedMessages = await receiver.ReceiveAsync(100, TimeSpan.FromSeconds(15));
                Assert.True(receivedMessages == null, $"Received messages at the end.");
            }
            finally
            {
                await receiver.CloseAsync();
            }
        }

        [DisplayTestMethodName]
        async Task CreateReceiverWithInclusiveSequenceNumber()
        {
            // Randomly pick one of the available partitons.
            var partitionId = this.PartitionIds[new Random().Next(this.PartitionIds.Count())];
            TestUtility.Log($"Randomly picked partition {partitionId}");

            await TestUtility.SendToPartitionAsync(this.EventHubClient, partitionId, $"{partitionId} event.");

            // Find out where to start reading on the partition.
            var pInfo = await this.EventHubClient.GetPartitionRuntimeInformationAsync(partitionId);

            // Send a message which is expected to go to the end of stream.
            // We are expecting to receive this message as well.
            await TestUtility.SendToPartitionAsync(this.EventHubClient, partitionId, $"{partitionId} event.");

            // Create a new receiver which will start reading from the last message on the stream.
            TestUtility.Log($"Creating a new receiver with sequence number {pInfo.LastEnqueuedSequenceNumber}");
            var receiver = this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, partitionId, EventPosition.FromSequenceNumber(pInfo .LastEnqueuedSequenceNumber, true));

            try
            {
                var receivedMessages = await receiver.ReceiveAsync(100);

                // We should have received only 1 message from this call.
                Assert.True(receivedMessages.Count() == 2, $"Didn't receive 2 messages. Received {receivedMessages.Count()} messages(s).");

                // Next receive on this partition shouldn't return any more messages.
                receivedMessages = await receiver.ReceiveAsync(100, TimeSpan.FromSeconds(15));
                Assert.True(receivedMessages == null, $"Received messages at the end.");
            }
            finally
            {
                await receiver.CloseAsync();
            }
        }

        [Fact]
        [DisplayTestMethodName]
        async Task PartitionReceiverReceiveBatch()
        {
            const int MaxBatchSize = 5;
            TestUtility.Log("Receiving Events via PartitionReceiver.ReceiveAsync(BatchSize)");
            const string partitionId = "0";
            PartitionSender partitionSender = this.EventHubClient.CreatePartitionSender(partitionId);
            PartitionReceiver partitionReceiver = this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, partitionId, EventPosition.FromEnqueuedTime(DateTime.UtcNow.AddMinutes(-10)));

            try
            {
                int eventCount = 20;
                TestUtility.Log($"Sending {eventCount} events to Partition {partitionId}");
                var sendEvents = new List<EventData>(eventCount);
                for (int i = 0; i < eventCount; i++)
                {
                    sendEvents.Add(new EventData(Encoding.UTF8.GetBytes($"Hello EventHub! Message {i}")));
                }
                await partitionSender.SendAsync(sendEvents);

                int maxReceivedBatchSize = 0;
                while (true)
                {
                    IEnumerable<EventData> partition1Events = await partitionReceiver.ReceiveAsync(MaxBatchSize);
                    int receivedEventCount = partition1Events != null ? partition1Events.Count() : 0;
                    TestUtility.Log($"Received {receivedEventCount} event(s)");

                    if (partition1Events == null)
                    {
                        break;
                    }

                    maxReceivedBatchSize = Math.Max(maxReceivedBatchSize, receivedEventCount);
                }

                Assert.True(maxReceivedBatchSize == MaxBatchSize, $"A max batch size of {MaxBatchSize} events was not honored! Actual {maxReceivedBatchSize}.");
            }
            finally
            {
                await partitionReceiver.CloseAsync();
                await partitionSender.CloseAsync();
            }
        }

        [Fact]
        [DisplayTestMethodName]
        async Task PartitionReceiverEpochReceive()
        {
            TestUtility.Log("Testing EpochReceiver semantics");
            var epochReceiver1 = this.EventHubClient.CreateEpochReceiver(PartitionReceiver.DefaultConsumerGroupName, "1", EventPosition.FromStart(), 1);
            var epochReceiver2 = this.EventHubClient.CreateEpochReceiver(PartitionReceiver.DefaultConsumerGroupName, "1", EventPosition.FromStart(), 2);
            try
            {
                // Read the events from Epoch 1 Receiver until we're at the end of the stream
                TestUtility.Log("Starting epoch 1 receiver");
                IEnumerable<EventData> events;
                do
                {
                    events = await epochReceiver1.ReceiveAsync(10);
                    var count = events?.Count() ?? 0;
                }
                while (events != null);

                TestUtility.Log("Starting epoch 2 receiver");
                var epoch2ReceiveTask = epochReceiver2.ReceiveAsync(10);

                DateTime stopTime = DateTime.UtcNow.AddSeconds(30);
                do
                {
                    events = await epochReceiver1.ReceiveAsync(10);
                    var count = events?.Count() ?? 0;
                    TestUtility.Log($"Epoch 1 receiver got {count} event(s)");
                }
                while (DateTime.UtcNow < stopTime);

                throw new InvalidOperationException("Epoch 1 receiver should have encountered an exception by now!");
            }
            catch (ReceiverDisconnectedException disconnectedException)
            {
                TestUtility.Log($"Received expected exception {disconnectedException.GetType()}: {disconnectedException.Message}");

                try
                {
                    await epochReceiver1.ReceiveAsync(10);
                    throw new InvalidOperationException("Epoch 1 receiver should throw ReceiverDisconnectedException here too!");
                }
                catch (ReceiverDisconnectedException e)
                {
                    TestUtility.Log($"Received expected exception {e.GetType()}");
                }
            }
            finally
            {
                await epochReceiver1.CloseAsync();
                await epochReceiver2.CloseAsync();
            }
        }

        [Fact]
        [DisplayTestMethodName]
        async Task CreateNonEpochReceiverAfterEpochReceiver()
        {
            var epochReceiver = this.EventHubClient.CreateEpochReceiver(PartitionReceiver.DefaultConsumerGroupName, "1", EventPosition.FromStart(), 1);
            var nonEpochReceiver = this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, "1", EventPosition.FromStart());

            try
            {
                TestUtility.Log("Starting epoch receiver");
                await epochReceiver.ReceiveAsync(10);

                await Task.Delay(TimeSpan.FromSeconds(10));

                try
                {
                    TestUtility.Log("Starting nonepoch receiver, this should fail");
                    await nonEpochReceiver.ReceiveAsync(10);
                    throw new InvalidOperationException("Non-Epoch receiver should have encountered an exception by now!");
                }
                catch (ReceiverDisconnectedException ex) when (ex.Message.Contains("non-epoch receiver is not allowed"))
                {
                    TestUtility.Log($"Received expected exception {ex.GetType()}: {ex.Message}");
                }
            }
            finally
            {
                await epochReceiver.CloseAsync();
                await nonEpochReceiver.CloseAsync();
            }
        }

        [Fact]
        [DisplayTestMethodName]
        async Task CreateEpochReceiverAfterNonEpochReceiver()
        {
            var nonEpochReceiver = this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, "1", EventPosition.FromStart());
            var epochReceiver = this.EventHubClient.CreateEpochReceiver(PartitionReceiver.DefaultConsumerGroupName, "1", EventPosition.FromStart(), 1);

            try
            {
                TestUtility.Log("Starting nonepoch receiver");
                await nonEpochReceiver.ReceiveAsync(10);

                await Task.Delay(TimeSpan.FromSeconds(10));

                TestUtility.Log("Starting epoch receiver");
                await epochReceiver.ReceiveAsync(10);

                await Task.Delay(TimeSpan.FromSeconds(10));

                try
                {
                    TestUtility.Log("Restarting nonepoch receiver, this should fail");
                    await nonEpochReceiver.ReceiveAsync(10);
                    throw new InvalidOperationException("Non-Epoch receiver should have encountered an exception by now!");
                }
                catch (ReceiverDisconnectedException ex) when (ex.Message.Contains("non-epoch receiver is not allowed"))
                {
                    TestUtility.Log($"Received expected exception {ex.GetType()}: {ex.Message}");
                }
            }
            finally
            {
                await epochReceiver.CloseAsync();
                await nonEpochReceiver.CloseAsync();
            }
        }

        [Fact]
        [DisplayTestMethodName]
        async Task CloseReceiverClient()
        {
            var pSender = this.EventHubClient.CreatePartitionSender("0");
            var pReceiver = this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, "0", EventPosition.FromStart());

            try
            {
                TestUtility.Log("Sending single event to partition 0");
                var eventData = new EventData(Encoding.UTF8.GetBytes("Hello EventHub!"));
                await pSender.SendAsync(eventData);

                TestUtility.Log("Receiving the event.");
                var events = await pReceiver.ReceiveAsync(1);
                Assert.True(events != null && events.Count() == 1, "Failed to receive 1 event");
            }
            finally
            {
                TestUtility.Log("Closing partition receiver");
                await pReceiver.CloseAsync();
            }

            await Assert.ThrowsAsync<ObjectDisposedException>(async () =>
            {
                TestUtility.Log("Receiving another event from partition 0 on the closed receiver, this should fail");
                await pReceiver.ReceiveAsync(1);
                throw new InvalidOperationException("Receive should have failed");
            });
        }

        [Fact]
        [DisplayTestMethodName]
        async Task ReceiverIdentifier()
        {
            List<PartitionReceiver> receivers = new List<PartitionReceiver>();

            try
            {
                for (int i=0; i < 5; i++)
                {
                    TestUtility.Log($"Creating receiver {i}");
                    var newReceiver = this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, "1", EventPosition.FromStart(),
                        new ReceiverOptions()
                        {
                            Identifier = $"receiver{i}"
                        });

                    // Issue a receive call so link will become active.
                    await newReceiver.ReceiveAsync(10);
                    receivers.Add(newReceiver);
                }

                try
                {
                    // Attempt to create 6th receiver. This should fail.
                    var failReceiver = this.EventHubClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, "1", EventPosition.FromStart());
                    await failReceiver.ReceiveAsync(10);
                    throw new InvalidOperationException("6th receiver should have encountered QuotaExceededException.");
                }
                catch (QuotaExceededException ex)
                {
                    TestUtility.Log($"Received expected exception {ex.GetType()}: {ex.Message}");
                    foreach (var receiver in receivers)
                    {
                        Assert.True(ex.Message.Contains(receiver.Identifier), $"QuotaExceededException message is missing receiver identifier '{receiver.Identifier}'");
                    }
                }
            }
            finally
            {
                // Close all receivers.
                foreach (var receiver in receivers)
                {
                    await receiver.CloseAsync();
                }
            }
        }
    }
}
