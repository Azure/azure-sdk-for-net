// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests
{
    public class ReceiverLiveTests : ServiceBusLiveTestBase
    {
        [Test]
        public async Task Peek()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var messageCt = 10;

                ServiceBusSender sender = client.GetSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                IEnumerable<ServiceBusMessage> sentMessages = AddMessages(batch, messageCt).AsEnumerable<ServiceBusMessage>();

                await sender.SendBatchAsync(batch);

                await using var receiver = client.GetReceiver(scope.QueueName);

                Dictionary<string, string> sentMessageIdToLabel = new Dictionary<string, string>();
                foreach (ServiceBusMessage message in sentMessages)
                {
                    sentMessageIdToLabel.Add(message.MessageId, Encoding.Default.GetString(message.Body.ToArray()));
                }

                var ct = 0;
                foreach (ServiceBusMessage peekedMessage in await receiver.PeekBatchAsync(
                    maxMessages: messageCt))
                {
                    var peekedText = Encoding.Default.GetString(peekedMessage.Body.ToArray());
                    ct++;
                }
                Assert.AreEqual(messageCt, ct);
            }
        }

        [Test]
        public async Task ReceiveMessagesInPeekLockMode()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var messageCount = 10;

                ServiceBusSender sender = client.GetSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount).AsEnumerable<ServiceBusMessage>();

                await sender.SendBatchAsync(batch);

                var receiver = client.GetReceiver(scope.QueueName);
                var receivedMessageCount = 0;
                var messageEnum = messages.GetEnumerator();

                foreach (var item in await receiver.ReceiveBatchAsync(messageCount))
                {
                    receivedMessageCount++;
                    messageEnum.MoveNext();
                    Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                    Assert.AreEqual(item.DeliveryCount, 1);
                }
                Assert.AreEqual(messageCount, receivedMessageCount);

                messageEnum.Reset();
                foreach (var item in await receiver.PeekBatchAsync(messageCount))
                {
                    messageEnum.MoveNext();
                    Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                }
            }
        }

        [Test]
        public async Task CompleteMessages()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var messageCount = 10;

                ServiceBusSender sender = client.GetSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount).AsEnumerable<ServiceBusMessage>();

                await sender.SendBatchAsync(batch);

                var receiver = client.GetReceiver(scope.QueueName);
                var receivedMessageCount = 0;
                var messageEnum = messages.GetEnumerator();

                foreach (var item in await receiver.ReceiveBatchAsync(messageCount))
                {
                    receivedMessageCount++;
                    messageEnum.MoveNext();
                    Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                    await receiver.CompleteAsync(item);
                }
                Assert.AreEqual(messageCount, receivedMessageCount);

                var peekedMessage = receiver.PeekAsync();
                Assert.IsNull(peekedMessage.Result);
            }
        }

        [Test]
        public async Task AbandonMessages()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var messageCount = 10;

                ServiceBusSender sender = client.GetSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount).AsEnumerable<ServiceBusMessage>();

                await sender.SendBatchAsync(batch);

                var receiver = client.GetReceiver(scope.QueueName);
                var receivedMessageCount = 0;
                var messageEnum = messages.GetEnumerator();

                foreach (var item in await receiver.ReceiveBatchAsync(messageCount))
                {
                    receivedMessageCount++;
                    messageEnum.MoveNext();
                    Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                    await receiver.AbandonAsync(item);
                    Assert.AreEqual(item.DeliveryCount, 1);
                }
                Assert.AreEqual(messageCount, receivedMessageCount);

                messageEnum.Reset();
                receivedMessageCount = 0;
                foreach (var item in await receiver.PeekBatchAsync(messageCount))
                {
                    receivedMessageCount++;
                    messageEnum.MoveNext();
                    Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                }
                Assert.AreEqual(messageCount, receivedMessageCount);
            }
        }

        [Test]
        public async Task DeadLetterMessages()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var messageCount = 10;

                ServiceBusSender sender = client.GetSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount).AsEnumerable<ServiceBusMessage>();

                await sender.SendBatchAsync(batch);

                var receiver = client.GetReceiver(scope.QueueName);
                var receivedMessageCount = 0;
                var messageEnum = messages.GetEnumerator();

                foreach (var item in await receiver.ReceiveBatchAsync(messageCount))
                {
                    receivedMessageCount++;
                    messageEnum.MoveNext();
                    Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                    await receiver.DeadLetterAsync(item);
                }
                Assert.AreEqual(messageCount, receivedMessageCount);

                var peekedMessage = receiver.PeekAsync();
                Assert.IsNull(peekedMessage.Result);

                messageEnum.Reset();
                receivedMessageCount = 0;
                string deadLetterQueuePath = EntityNameFormatter.FormatDeadLetterPath(scope.QueueName);
                var deadLetterReceiver = client.GetReceiver(deadLetterQueuePath);

                foreach (var item in await deadLetterReceiver.ReceiveBatchAsync(messageCount))
                {
                    receivedMessageCount++;
                    messageEnum.MoveNext();
                    Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                    await deadLetterReceiver.CompleteAsync(item);
                }
                Assert.AreEqual(messageCount, receivedMessageCount);

                var deadLetterMessage = deadLetterReceiver.PeekAsync();
                Assert.IsNull(deadLetterMessage.Result);
            }
        }

        [Test]
        public async Task DeferMessages()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var messageCount = 10;

                ServiceBusSender sender = client.GetSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount).AsEnumerable<ServiceBusMessage>();

                await sender.SendBatchAsync(batch);

                var receiver = client.GetReceiver(scope.QueueName);
                var receivedMessageCount = 0;
                var messageEnum = messages.GetEnumerator();
                IList<long> sequenceNumbers = new List<long>();

                foreach (var item in await receiver.ReceiveBatchAsync(messageCount))
                {
                    receivedMessageCount++;
                    messageEnum.MoveNext();
                    Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                    sequenceNumbers.Add(item.SequenceNumber);
                    await receiver.DeferAsync(item);
                }
                Assert.AreEqual(messageCount, receivedMessageCount);

                IList<ServiceBusReceivedMessage> deferedMessages = await receiver.ReceiveDeferredMessageBatchAsync(sequenceNumbers);

                var messageList = messages.ToList();
                Assert.AreEqual(messageList.Count, deferedMessages.Count);
                for (int i = 0; i < messageList.Count; i++)
                {
                    Assert.AreEqual(messageList[i].MessageId, deferedMessages[i].MessageId);
                }
            }
        }

        [Test]
        public async Task ReceiveMessagesInReceiveAndDeleteMode()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var messageCount = 10;

                ServiceBusSender sender = client.GetSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount).AsEnumerable<ServiceBusMessage>();

                await sender.SendBatchAsync(batch);

                var clientOptions = new ServiceBusReceiverOptions()
                {
                    ReceiveMode = ReceiveMode.ReceiveAndDelete,
                };
                var receiver = client.GetReceiver(scope.QueueName, clientOptions);
                var receivedMessageCount = 0;
                var messageEnum = messages.GetEnumerator();

                foreach (var item in await receiver.ReceiveBatchAsync(messageCount).ConfigureAwait(false))
                {
                    messageEnum.MoveNext();
                    Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                    receivedMessageCount++;
                }
                Assert.AreEqual(messageCount, receivedMessageCount);

                var peekedMessage = receiver.PeekAsync();
                Assert.IsNull(peekedMessage.Result);
            }
        }

        [Test]
        public async Task ReceiveSingleMessageInReceiveAndDeleteMode()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.GetSender(scope.QueueName);
                ServiceBusMessage sentMessage = GetMessage();
                await sender.SendAsync(sentMessage);

                var clientOptions = new ServiceBusReceiverOptions()
                {
                    ReceiveMode = ReceiveMode.ReceiveAndDelete,
                };
                var receiver = client.GetReceiver(scope.QueueName, clientOptions);
                var receivedMessage = await receiver.ReceiveAsync();
                Assert.AreEqual(sentMessage.MessageId, receivedMessage.MessageId);

                var message = receiver.PeekAsync();
                Assert.IsNull(message.Result);
            }
        }

        [Test]
        public async Task RenewMessageLock()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.GetSender(scope.QueueName);
                var messageCount = 1;
                ServiceBusMessage message = GetMessage();
                await sender.SendAsync(message);

                var receiver = client.GetReceiver(scope.QueueName);
                ServiceBusReceivedMessage[] receivedMessages = (await receiver.ReceiveBatchAsync(messageCount)).ToArray();

                var receivedMessage = receivedMessages.First();
                var firstLockedUntilUtcTime = receivedMessage.LockedUntilUtc;

                // Sleeping for 10 seconds...
                await Task.Delay(10000);

                await receiver.RenewLockAsync(receivedMessage);

                Assert.True(receivedMessage.LockedUntilUtc >= firstLockedUntilUtcTime + TimeSpan.FromSeconds(10));

                // Complete Messages
                await receiver.CompleteAsync(receivedMessage);

                Assert.AreEqual(messageCount, receivedMessages.Length);
                Assert.AreEqual(message.MessageId, receivedMessage.MessageId);

                var peekedMessage = receiver.PeekAsync();
                Assert.IsNull(peekedMessage.Result);
            }
        }
    }
}
