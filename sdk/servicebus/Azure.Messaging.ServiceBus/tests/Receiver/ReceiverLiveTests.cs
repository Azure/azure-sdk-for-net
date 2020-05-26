﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Amqp.Framing;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Receiver
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

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                IEnumerable<ServiceBusMessage> sentMessages = AddMessages(batch, messageCt).AsEnumerable<ServiceBusMessage>();

                await sender.SendAsync(batch);

                await using var receiver = client.CreateReceiver(scope.QueueName);

                Dictionary<string, string> sentMessageIdToLabel = new Dictionary<string, string>();
                foreach (ServiceBusMessage message in sentMessages)
                {
                    sentMessageIdToLabel.Add(message.MessageId, Encoding.Default.GetString(message.Body.ToArray()));
                }

                var ct = 0;
                while (ct < messageCt)
                {
                    foreach (ServiceBusReceivedMessage peekedMessage in await receiver.PeekBatchAsync(
                    maxMessages: messageCt))
                    {
                        var peekedText = Encoding.Default.GetString(peekedMessage.Body.ToArray());
                        ct++;
                    }
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

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount).AsEnumerable<ServiceBusMessage>();

                await sender.SendAsync(batch);

                var receiver = client.CreateReceiver(scope.QueueName);
                var messageEnum = messages.GetEnumerator();
                var remainingMessages = messageCount;
                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveBatchAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        Assert.AreEqual(item.DeliveryCount, 1);
                    }
                }
                Assert.AreEqual(0, remainingMessages);
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

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount).AsEnumerable<ServiceBusMessage>();

                await sender.SendAsync(batch);

                var receiver = client.CreateReceiver(scope.QueueName);
                var messageEnum = messages.GetEnumerator();
                var remainingMessages = messageCount;

                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveBatchAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        await receiver.CompleteAsync(item.LockToken);
                    }
                }
                Assert.AreEqual(0, remainingMessages);

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

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount).AsEnumerable<ServiceBusMessage>();

                await sender.SendAsync(batch);

                var receiver = client.CreateReceiver(scope.QueueName);

                var messageEnum = messages.GetEnumerator();
                var remainingMessages = messageCount;
                IList<ServiceBusReceivedMessage> receivedMessages = new List<ServiceBusReceivedMessage>();
                while (remainingMessages > 0)
                {
                    foreach (var msg in await receiver.ReceiveBatchAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, msg.MessageId);
                        receivedMessages.Add(msg);
                        Assert.AreEqual(msg.DeliveryCount, 1);
                    }
                }

                Assert.AreEqual(0, remainingMessages);

                // don't abandon in the receive loop
                // as this would make the message available to be immediately received again
                foreach (var msg in receivedMessages)
                {
                    await receiver.AbandonAsync(msg);
                }
                messageEnum.Reset();
                var receivedMessageCount = 0;
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

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                IEnumerable<ServiceBusMessage> messages = GetMessages(messageCount);

                await sender.SendAsync(messages);

                var receiver = client.CreateReceiver(scope.QueueName);
                var remainingMessages = messageCount;
                var messageEnum = messages.GetEnumerator();

                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveBatchAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        await receiver.DeadLetterAsync(item.LockToken);
                    }
                }
                Assert.AreEqual(0, remainingMessages);

                var peekedMessage = receiver.PeekAsync();
                Assert.IsNull(peekedMessage.Result);

                messageEnum.Reset();
                string deadLetterQueuePath = EntityNameFormatter.FormatDeadLetterPath(scope.QueueName);
                var deadLetterReceiver = client.CreateReceiver(deadLetterQueuePath);
                remainingMessages = messageCount;

                while (remainingMessages > 0)
                {
                    foreach (var item in await deadLetterReceiver.ReceiveBatchAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        await deadLetterReceiver.CompleteAsync(item.LockToken);
                    }
                }
                Assert.AreEqual(0, remainingMessages);

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

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount).AsEnumerable<ServiceBusMessage>();

                await sender.SendAsync(batch);

                var receiver = client.CreateReceiver(scope.QueueName);
                var messageEnum = messages.GetEnumerator();
                IList<long> sequenceNumbers = new List<long>();
                var remainingMessages = messageCount;

                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveBatchAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        sequenceNumbers.Add(item.SequenceNumber);
                        await receiver.DeferAsync(item.LockToken);
                    }
                }
                Assert.AreEqual(0, remainingMessages);

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
        public async Task CanPeekADeferredMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                await sender.SendAsync(GetMessage());

                var receiver = client.CreateReceiver(scope.QueueName);
                var receivedMsg = await receiver.ReceiveAsync();

                await receiver.DeferAsync(receivedMsg);
                var peekedMsg = await receiver.PeekAsync();
                Assert.AreEqual(receivedMsg.MessageId, peekedMsg.MessageId);
                Assert.AreEqual(receivedMsg.SequenceNumber, peekedMsg.SequenceNumber);

                var deferredMsg = await receiver.ReceiveDeferredMessageAsync(peekedMsg.SequenceNumber);
                Assert.AreEqual(peekedMsg.MessageId, deferredMsg.MessageId);
                Assert.AreEqual(peekedMsg.SequenceNumber, deferredMsg.SequenceNumber);
            }
        }

        [Test]
        public async Task ReceiveMessagesInReceiveAndDeleteMode()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var messageCount = 10;

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount).AsEnumerable<ServiceBusMessage>();

                await sender.SendAsync(batch);

                var clientOptions = new ServiceBusReceiverOptions()
                {
                    ReceiveMode = ReceiveMode.ReceiveAndDelete,
                };
                var receiver = client.CreateReceiver(scope.QueueName, clientOptions);
                var messageEnum = messages.GetEnumerator();
                var remainingMessages = messageCount;
                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveBatchAsync(remainingMessages).ConfigureAwait(false))
                    {
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        remainingMessages--;
                    }
                }
                Assert.AreEqual(0, remainingMessages);

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
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                ServiceBusMessage sentMessage = GetMessage();
                await sender.SendAsync(sentMessage);

                var clientOptions = new ServiceBusReceiverOptions()
                {
                    ReceiveMode = ReceiveMode.ReceiveAndDelete,
                };
                var receiver = client.CreateReceiver(scope.QueueName, clientOptions);
                var receivedMessage = await receiver.ReceiveAsync();
                Assert.AreEqual(sentMessage.MessageId, receivedMessage.MessageId);

                var message = receiver.PeekAsync();
                Assert.IsNull(message.Result);
            }
        }

        [Test]
        public async Task ReceiverThrowsWhenUsingSessionEntity()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                ServiceBusMessage sentMessage = GetMessage("sessionId");
                await sender.SendAsync(sentMessage);

                var receiver = client.CreateReceiver(scope.QueueName);
                Assert.That(
                    async () => await receiver.ReceiveAsync(),
                    Throws.InstanceOf<InvalidOperationException>());
            }
        }

        [Test]
        public async Task RenewMessageLock()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                var messageCount = 1;
                ServiceBusMessage message = GetMessage();
                await sender.SendAsync(message);

                var receiver = client.CreateReceiver(scope.QueueName);
                ServiceBusReceivedMessage[] receivedMessages = (await receiver.ReceiveBatchAsync(messageCount)).ToArray();

                var receivedMessage = receivedMessages.First();
                var firstLockedUntilUtcTime = receivedMessage.LockedUntil;

                // Sleeping for 10 seconds...
                await Task.Delay(10000);

                await receiver.RenewMessageLockAsync(receivedMessage);

                Assert.True(receivedMessage.LockedUntil >= firstLockedUntilUtcTime + TimeSpan.FromSeconds(10));

                // Complete Messages
                await receiver.CompleteAsync(receivedMessage.LockToken);

                Assert.AreEqual(messageCount, receivedMessages.Length);
                Assert.AreEqual(message.MessageId, receivedMessage.MessageId);

                var peekedMessage = receiver.PeekAsync();
                Assert.IsNull(peekedMessage.Result);
            }
        }

        [Test]
        public async Task MaxWaitTimeRespected()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(
                    TestEnvironment.ServiceBusConnectionString,
                    new ServiceBusClientOptions
                    {
                        RetryOptions = new ServiceBusRetryOptions
                        {
                            TryTimeout = TimeSpan.FromSeconds(20)
                        }
                    });

                var receiver = client.CreateReceiver(scope.QueueName);
                var start = DateTimeOffset.UtcNow;
                var receivedMessage = await receiver.ReceiveAsync(TimeSpan.FromSeconds(5));
                var end = DateTimeOffset.UtcNow;
                Assert.IsNull(receivedMessage);
                var diff = end - start;
                Assert.IsTrue(diff.TotalSeconds < 10);

                start = DateTimeOffset.UtcNow;
                // no wait time specified => should default to TryTimeout
                receivedMessage = await receiver.ReceiveAsync();
                end = DateTimeOffset.UtcNow;
                Assert.IsNull(receivedMessage);
                diff = end - start;
                Assert.IsTrue(diff.TotalSeconds > 10);
            }
        }

        [Test]
        public async Task ThrowIfCompletePeekedMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                await sender.SendAsync(GetMessage());

                var receiver = client.CreateReceiver(scope.QueueName);

                var peekedMessage = await receiver.PeekAsync();

                Assert.That(
                    async () => await receiver.CompleteAsync(peekedMessage),
                    Throws.InstanceOf<InvalidOperationException>());
            }
        }

        [Test]
        public async Task ThrowIfAbandonPeekedMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                await sender.SendAsync(GetMessage());

                var receiver = client.CreateReceiver(scope.QueueName);

                var peekedMessage = await receiver.PeekAsync();

                Assert.That(
                    async () => await receiver.AbandonAsync(peekedMessage),
                    Throws.InstanceOf<InvalidOperationException>());
            }
        }

        [Test]
        public async Task ThrowIfDeferPeekedMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                await sender.SendAsync(GetMessage());

                var receiver = client.CreateReceiver(scope.QueueName);

                var peekedMessage = await receiver.PeekAsync();

                Assert.That(
                    async () => await receiver.DeferAsync(peekedMessage),
                    Throws.InstanceOf<InvalidOperationException>());
            }
        }

        [Test]
        public async Task ThrowIfDeadletterPeekedMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                await sender.SendAsync(GetMessage());

                var receiver = client.CreateReceiver(scope.QueueName);

                var peekedMessage = await receiver.PeekAsync();

                Assert.That(
                    async () => await receiver.DeadLetterAsync(peekedMessage),
                    Throws.InstanceOf<InvalidOperationException>());
            }
        }

        [Test]
        public async Task ThrowIfRenewlockOfPeekedMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                await sender.SendAsync(GetMessage());

                var receiver = client.CreateReceiver(scope.QueueName);

                var peekedMessage = await receiver.PeekAsync();

                Assert.That(
                    async () => await receiver.RenewMessageLockAsync(peekedMessage),
                    Throws.InstanceOf<InvalidOperationException>());
            }
        }
    }
}
