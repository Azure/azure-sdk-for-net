// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Amqp.Framing;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Receiver
{
    public class ReceiverLiveTests : ServiceBusLiveTestBase
    {
        [Test]
        public async Task PeekUsingConnectionStringWithSharedKey()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var messageCt = 10;

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                IEnumerable<ServiceBusMessage> sentMessages = AddMessages(batch, messageCt).AsEnumerable<ServiceBusMessage>();

                await sender.SendMessagesAsync(batch);

                await using var receiver = client.CreateReceiver(scope.QueueName);
                var messageEnum = sentMessages.GetEnumerator();

                var ct = 0;
                while (ct < messageCt)
                {
                    foreach (ServiceBusReceivedMessage peekedMessage in await receiver.PeekMessagesAsync(
                    maxMessages: messageCt))
                    {
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, peekedMessage.MessageId);
                        ct++;
                    }
                }
                Assert.AreEqual(messageCt, ct);
            }
        }

        [Test]
        public async Task PeekUsingConnectionStringWithSisgnature()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var options = new ServiceBusClientOptions();
                var audience = ServiceBusConnection.BuildConnectionResource(options.TransportType, TestEnvironment.FullyQualifiedNamespace, scope.QueueName);
                var connectionString = TestEnvironment.BuildConnectionStringWithSharedAccessSignature(scope.QueueName, audience);

                await using var client = new ServiceBusClient(connectionString, options);
                var messageCt = 10;

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                IEnumerable<ServiceBusMessage> sentMessages = AddMessages(batch, messageCt).AsEnumerable<ServiceBusMessage>();

                await sender.SendMessagesAsync(batch);

                await using var receiver = client.CreateReceiver(scope.QueueName);
                var messageEnum = sentMessages.GetEnumerator();

                var ct = 0;
                while (ct < messageCt)
                {
                    foreach (ServiceBusReceivedMessage peekedMessage in await receiver.PeekMessagesAsync(
                    maxMessages: messageCt))
                    {
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, peekedMessage.MessageId);
                        ct++;
                    }
                }
                Assert.AreEqual(messageCt, ct);
            }
        }

        [Test]
        public async Task PeekSingleMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                var msgs = GetMessages(2);
                await sender.SendMessagesAsync(msgs);
                var receiver = client.CreateReceiver(scope.QueueName);
                var message1 = await receiver.PeekMessageAsync();
                Assert.IsNotNull(message1.SequenceNumber);
                var message2 = await receiver.PeekMessageAsync(message1.SequenceNumber + 1);
                Assert.AreEqual(msgs[1].MessageId, message2.MessageId);
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
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount).AsEnumerable<ServiceBusMessage>();

                await sender.SendMessagesAsync(batch);

                var receiver = client.CreateReceiver(scope.QueueName);
                var messageEnum = messages.GetEnumerator();
                var remainingMessages = messageCount;
                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveMessagesAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        Assert.AreEqual(item.DeliveryCount, 1);
                    }
                }
                Assert.AreEqual(0, remainingMessages);
                messageEnum.Reset();
                foreach (var item in await receiver.PeekMessagesAsync(messageCount))
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
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount).AsEnumerable<ServiceBusMessage>();

                await sender.SendMessagesAsync(batch);

                var receiver = client.CreateReceiver(scope.QueueName);
                var messageEnum = messages.GetEnumerator();
                var remainingMessages = messageCount;

                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveMessagesAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        await receiver.CompleteMessageAsync(item.LockToken);
                    }
                }
                Assert.AreEqual(0, remainingMessages);

                var peekedMessage = receiver.PeekMessageAsync();
                Assert.IsNull(peekedMessage.Result);
            }
        }

        [Test]
        public async Task ReceiveIterator()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var messageCount = 10;

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                var messages = GetMessages(messageCount);
                var secondSet = GetMessages(messageCount);
                await sender.SendMessagesAsync(messages);
                _ = Task.Delay(TimeSpan.FromSeconds(30)).ContinueWith(
                    async _ => await sender.SendMessagesAsync(secondSet));

                var receiver = client.CreateReceiver(scope.QueueName);
                var cts = new CancellationTokenSource();
                cts.CancelAfter(TimeSpan.FromMinutes(1));
                messages.AddRange(secondSet);

                int ct = 0;
                try
                {
                    await foreach (var msg in receiver.ReceiveMessagesAsync(cts.Token))
                    {
                        Assert.AreEqual(messages[ct].MessageId, msg.MessageId);
                        await receiver.CompleteMessageAsync(msg.LockToken);
                        ct++;
                    }
                }
                catch (TaskCanceledException) { }
                Assert.AreEqual(messageCount * 2, ct);
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
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount).AsEnumerable<ServiceBusMessage>();

                await sender.SendMessagesAsync(batch);

                var receiver = client.CreateReceiver(scope.QueueName);

                var messageEnum = messages.GetEnumerator();
                var remainingMessages = messageCount;
                IList<ServiceBusReceivedMessage> receivedMessages = new List<ServiceBusReceivedMessage>();
                while (remainingMessages > 0)
                {
                    foreach (var msg in await receiver.ReceiveMessagesAsync(remainingMessages))
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
                    await receiver.AbandonMessageAsync(msg);
                }
                messageEnum.Reset();
                var receivedMessageCount = 0;
                foreach (var item in await receiver.PeekMessagesAsync(messageCount))
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

                await sender.SendMessagesAsync(messages);

                var receiver = client.CreateReceiver(scope.QueueName, new ServiceBusReceiverOptions
                {
                    PrefetchCount = 10
                });
                var remainingMessages = messageCount;
                var messageEnum = messages.GetEnumerator();

                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveMessagesAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        Assert.AreEqual(messageEnum.Current.Body.ToArray(), item.Body.ToArray());
                        await receiver.DeadLetterMessageAsync(item.LockToken);
                    }
                }
                Assert.AreEqual(0, remainingMessages);

                var peekedMessage = receiver.PeekMessageAsync();
                Assert.IsNull(peekedMessage.Result);

                messageEnum.Reset();
                string deadLetterQueuePath = EntityNameFormatter.FormatDeadLetterPath(scope.QueueName);
                var deadLetterReceiver = client.CreateReceiver(deadLetterQueuePath);
                remainingMessages = messageCount;

                while (remainingMessages > 0)
                {
                    foreach (var item in await deadLetterReceiver.ReceiveMessagesAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        await deadLetterReceiver.CompleteMessageAsync(item.LockToken);
                    }
                }
                Assert.AreEqual(0, remainingMessages);

                var deadLetterMessage = deadLetterReceiver.PeekMessageAsync();
                Assert.IsNull(deadLetterMessage.Result);
            }
        }

        [Test]
        public async Task DeferMessagesList()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var messageCount = 10;

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount).AsEnumerable<ServiceBusMessage>();

                await sender.SendMessagesAsync(batch);

                var receiver = client.CreateReceiver(scope.QueueName);
                var messageEnum = messages.GetEnumerator();
                IList<long> sequenceNumbers = new List<long>();
                var remainingMessages = messageCount;

                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveMessagesAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        sequenceNumbers.Add(item.SequenceNumber);
                        await receiver.DeferMessageAsync(item.LockToken);
                    }
                }
                Assert.AreEqual(0, remainingMessages);

                IReadOnlyList<ServiceBusReceivedMessage> deferredMessages = await receiver.ReceiveDeferredMessagesAsync(sequenceNumbers);

                var messageList = messages.ToList();
                Assert.AreEqual(messageList.Count, deferredMessages.Count);
                for (int i = 0; i < messageList.Count; i++)
                {
                    Assert.AreEqual(messageList[i].MessageId, deferredMessages[i].MessageId);
                    Assert.AreEqual(messageList[i].Body.ToArray(), deferredMessages[i].Body.ToArray());
                }

                // verify that looking up a non-existent sequence number will throw
                sequenceNumbers.Add(45);
                Assert.That(
                    async () => await receiver.ReceiveDeferredMessagesAsync(sequenceNumbers),
                    Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.MessageNotFound));

                // verify that an empty list can be passed
                deferredMessages = await receiver.ReceiveDeferredMessagesAsync(Array.Empty<long>());
                Assert.IsEmpty(deferredMessages);
            }
        }

        [Test]
        public async Task DeferMessagesArray()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var messageCount = 10;

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount).AsEnumerable<ServiceBusMessage>();

                await sender.SendMessagesAsync(batch);

                var receiver = client.CreateReceiver(scope.QueueName);
                var messageEnum = messages.GetEnumerator();
                long[] sequenceNumbers = new long[messageCount];
                var remainingMessages = messageCount;
                int idx = 0;
                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveMessagesAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        sequenceNumbers[idx++] = item.SequenceNumber;
                        await receiver.DeferMessageAsync(item.LockToken);
                    }
                }
                Assert.AreEqual(0, remainingMessages);

                IReadOnlyList<ServiceBusReceivedMessage> deferredMessages = await receiver.ReceiveDeferredMessagesAsync(sequenceNumbers);

                var messageList = messages.ToList();
                Assert.AreEqual(messageList.Count, deferredMessages.Count);
                for (int i = 0; i < messageList.Count; i++)
                {
                    Assert.AreEqual(messageList[i].MessageId, deferredMessages[i].MessageId);
                    Assert.AreEqual(messageList[i].Body.ToArray(), deferredMessages[i].Body.ToArray());
                }

                // verify that an empty array can be passed
                deferredMessages = await receiver.ReceiveDeferredMessagesAsync(Array.Empty<long>());
                Assert.IsEmpty(deferredMessages);
            }
        }

        [Test]
        public async Task DeferMessagesEnumerable()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var messageCount = 10;

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount).AsEnumerable<ServiceBusMessage>();

                await sender.SendMessagesAsync(batch);

                var receiver = client.CreateReceiver(scope.QueueName);
                var messageEnum = messages.GetEnumerator();
                long[] sequenceNumbers = new long[messageCount];
                var remainingMessages = messageCount;
                int idx = 0;
                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveMessagesAsync(remainingMessages))
                    {
                        remainingMessages--;
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        sequenceNumbers[idx++] = item.SequenceNumber;
                        await receiver.DeferMessageAsync(item.LockToken);
                    }
                }
                Assert.AreEqual(0, remainingMessages);

                IReadOnlyList<ServiceBusReceivedMessage> deferredMessages = await receiver.ReceiveDeferredMessagesAsync(GetEnumerable());

                IEnumerable<long> GetEnumerable()
                {
                    foreach (long seq in sequenceNumbers)
                    {
                        yield return seq;
                    }
                }

                var messageList = messages.ToList();
                Assert.AreEqual(messageList.Count, deferredMessages.Count);
                for (int i = 0; i < messageList.Count; i++)
                {
                    Assert.AreEqual(messageList[i].MessageId, deferredMessages[i].MessageId);
                    Assert.AreEqual(messageList[i].Body.ToArray(), deferredMessages[i].Body.ToArray());
                }

                // verify that an empty enumerable can be passed
                deferredMessages = await receiver.ReceiveDeferredMessagesAsync(Enumerable.Empty<long>());
                Assert.IsEmpty(deferredMessages);
            }
        }

        [Test]
        public async Task CanPeekADeferredMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                await sender.SendMessageAsync(GetMessage());

                var receiver = client.CreateReceiver(scope.QueueName);
                var receivedMsg = await receiver.ReceiveMessageAsync();

                await receiver.DeferMessageAsync(receivedMsg);
                var peekedMsg = await receiver.PeekMessageAsync();
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
                using ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();
                IEnumerable<ServiceBusMessage> messages = AddMessages(batch, messageCount).AsEnumerable<ServiceBusMessage>();

                await sender.SendMessagesAsync(batch);

                var clientOptions = new ServiceBusReceiverOptions()
                {
                    ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete,
                };
                var receiver = client.CreateReceiver(scope.QueueName, clientOptions);
                var messageEnum = messages.GetEnumerator();
                var remainingMessages = messageCount;
                while (remainingMessages > 0)
                {
                    foreach (var item in await receiver.ReceiveMessagesAsync(remainingMessages).ConfigureAwait(false))
                    {
                        messageEnum.MoveNext();
                        Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                        remainingMessages--;
                    }
                }
                Assert.AreEqual(0, remainingMessages);

                var peekedMessage = receiver.PeekMessageAsync();
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
                await sender.SendMessageAsync(sentMessage);

                var clientOptions = new ServiceBusReceiverOptions()
                {
                    ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete,
                };
                var receiver = client.CreateReceiver(scope.QueueName, clientOptions);
                var receivedMessage = await receiver.ReceiveMessageAsync();
                Assert.AreEqual(sentMessage.MessageId, receivedMessage.MessageId);

                var message = receiver.PeekMessageAsync();
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
                await sender.SendMessageAsync(sentMessage);

                var receiver = client.CreateReceiver(scope.QueueName);
                Assert.That(
                    async () => await receiver.ReceiveMessageAsync(),
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
                await sender.SendMessageAsync(message);

                var receiver = client.CreateReceiver(scope.QueueName);
                ServiceBusReceivedMessage[] receivedMessages = (await receiver.ReceiveMessagesAsync(messageCount)).ToArray();

                var receivedMessage = receivedMessages.First();
                var firstLockedUntilUtcTime = receivedMessage.LockedUntil;

                // Sleeping for 10 seconds...
                await Task.Delay(10000);

                await receiver.RenewMessageLockAsync(receivedMessage);

                Assert.True(receivedMessage.LockedUntil >= firstLockedUntilUtcTime + TimeSpan.FromSeconds(10));

                // Complete Messages
                await receiver.CompleteMessageAsync(receivedMessage.LockToken);

                Assert.AreEqual(messageCount, receivedMessages.Length);
                Assert.AreEqual(message.MessageId, receivedMessage.MessageId);

                var peekedMessage = receiver.PeekMessageAsync();
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
                            TryTimeout = TimeSpan.FromSeconds(20),
                            MaxRetries = 0
                        }
                    });

                var receiver = client.CreateReceiver(scope.QueueName);
                var start = DateTimeOffset.UtcNow;
                var receivedMessage = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(5));
                var end = DateTimeOffset.UtcNow;
                Assert.IsNull(receivedMessage);
                var diff = end - start;
                Assert.IsTrue(diff.TotalSeconds < 10);

                start = DateTimeOffset.UtcNow;
                // no wait time specified => should default to TryTimeout
                receivedMessage = await receiver.ReceiveMessageAsync();
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
                await sender.SendMessageAsync(GetMessage());

                var receiver = client.CreateReceiver(scope.QueueName);

                var peekedMessage = await receiver.PeekMessageAsync();

                Assert.That(
                    async () => await receiver.CompleteMessageAsync(peekedMessage),
                    Throws.InstanceOf<InvalidOperationException>().And.Property(nameof(InvalidOperationException.Message)).Contains("peeked message"));
            }
        }

        [Test]
        public async Task ThrowIfAbandonPeekedMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(GetMessage());

                var receiver = client.CreateReceiver(scope.QueueName);

                var peekedMessage = await receiver.PeekMessageAsync();

                Assert.That(
                    async () => await receiver.AbandonMessageAsync(peekedMessage),
                    Throws.InstanceOf<InvalidOperationException>().And.Property(nameof(InvalidOperationException.Message)).Contains("peeked message"));
            }
        }

        [Test]
        public async Task ThrowIfDeferPeekedMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(GetMessage());

                var receiver = client.CreateReceiver(scope.QueueName);

                var peekedMessage = await receiver.PeekMessageAsync();

                Assert.That(
                    async () => await receiver.DeferMessageAsync(peekedMessage),
                    Throws.InstanceOf<InvalidOperationException>().And.Property(nameof(InvalidOperationException.Message)).Contains("peeked message"));
            }
        }

        [Test]
        public async Task ThrowIfDeadletterPeekedMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(GetMessage());

                var receiver = client.CreateReceiver(scope.QueueName);

                var peekedMessage = await receiver.PeekMessageAsync();

                Assert.That(
                    async () => await receiver.DeadLetterMessageAsync(peekedMessage),
                    Throws.InstanceOf<InvalidOperationException>().And.Property(nameof(InvalidOperationException.Message)).Contains("peeked message"));
            }
        }

        [Test]
        public async Task ThrowIfSettleInReceiveAndDeleteMode()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(GetMessage());

                var receiver = client.CreateReceiver(
                    scope.QueueName,
                    new ServiceBusReceiverOptions { ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete });

                var peekedMessage = await receiver.PeekMessageAsync();

                Assert.That(
                    async () => await receiver.DeadLetterMessageAsync(peekedMessage),
                    Throws.InstanceOf<InvalidOperationException>().And.Property(nameof(InvalidOperationException.Message)).Contains("receive mode"));

                Assert.That(
                    async () => await receiver.DeferMessageAsync(peekedMessage),
                    Throws.InstanceOf<InvalidOperationException>().And.Property(nameof(InvalidOperationException.Message)).Contains("receive mode"));

                Assert.That(
                    async () => await receiver.CompleteMessageAsync(peekedMessage),
                    Throws.InstanceOf<InvalidOperationException>().And.Property(nameof(InvalidOperationException.Message)).Contains("receive mode"));

                Assert.That(
                    async () => await receiver.AbandonMessageAsync(peekedMessage),
                    Throws.InstanceOf<InvalidOperationException>().And.Property(nameof(InvalidOperationException.Message)).Contains("receive mode"));
            }
        }

        /// <summary>
        /// This test validates that we are not limited to 5k unsettled messages on the link, as we have updated
        /// the sessionSettings.IncomingWindow value to Int32.MaxValue in AmqpConnectionScope. Without this change, receivers
        /// would just stop receiving after 5k unsettled messages and would not throw an exception.
        /// </summary>
        [Test]
        public async Task CanHaveManyUnsettledMessages()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                int sentCount = 6000;
                int messagesPerBatch = 1000;

                await sender.SendMessagesAsync(new List<ServiceBusMessage>());

                for (int i = 0; i < sentCount/messagesPerBatch; i++)
                {
                    await sender.SendMessagesAsync(GetMessages(messagesPerBatch));
                }

                var receiver = client.CreateReceiver(scope.QueueName);

                var receivedCount = 0;
                while (receivedCount <= sentCount)
                {
                    var msgs = await receiver.ReceiveMessagesAsync(sentCount);
                    receivedCount += msgs.Count;
                }
            }
        }

        [Test]
        public async Task ThrowIfRenewlockOfPeekedMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusSender sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(GetMessage());

                var receiver = client.CreateReceiver(scope.QueueName);

                var peekedMessage = await receiver.PeekMessageAsync();

                Assert.That(
                    async () => await receiver.RenewMessageLockAsync(peekedMessage),
                    Throws.InstanceOf<InvalidOperationException>());
            }
        }
    }
}
