﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
                await using var sender = new ServiceBusSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var messageCt = 10;

                IEnumerable<ServiceBusMessage> sentMessages = GetMessages(messageCt);
                await sender.SendBatchAsync(sentMessages);

                await using var receiver = new ServiceBusReceiverClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);

                Dictionary<string, string> sentMessageIdToLabel = new Dictionary<string, string>();
                foreach (ServiceBusMessage message in sentMessages)
                {
                    sentMessageIdToLabel.Add(message.MessageId, Encoding.Default.GetString(message.Body));
                }

                var ct = 0;
                foreach (ServiceBusMessage peekedMessage in await receiver.PeekBatchAsync(
                    maxMessages: messageCt))
                {
                    var peekedText = Encoding.Default.GetString(peekedMessage.Body);
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
                await using var sender = new ServiceBusSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var messageCount = 10;
                IEnumerable<ServiceBusMessage> messages = GetMessages(messageCount);
                await sender.SendBatchAsync(messages);

                var receiver = new ServiceBusReceiverClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
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
                await using var sender = new ServiceBusSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var messageCount = 10;
                IEnumerable<ServiceBusMessage> messages = GetMessages(messageCount);
                await sender.SendBatchAsync(messages);

                var receiver = new ServiceBusReceiverClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
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

                var message = receiver.PeekAsync();
                Assert.IsNull(message.Result);
            }
        }

        [Test]
        public async Task AbandonMessages()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var sender = new ServiceBusSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var messageCount = 10;
                IEnumerable<ServiceBusMessage> messages = GetMessages(messageCount);
                await sender.SendBatchAsync(messages);

                var receiver = new ServiceBusReceiverClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
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
                await using var sender = new ServiceBusSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var messageCount = 10;
                IEnumerable<ServiceBusMessage> messages = GetMessages(messageCount);
                await sender.SendBatchAsync(messages);

                var receiver = new ServiceBusReceiverClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
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

                var message = receiver.PeekAsync();
                Assert.IsNull(message.Result);

                messageEnum.Reset();
                receivedMessageCount = 0;
                string deadLetterQueuePath = EntityNameFormatter.FormatDeadLetterPath(scope.QueueName);
                var deadLetterReceiver = new ServiceBusReceiverClient(TestEnvironment.ServiceBusConnectionString, deadLetterQueuePath);

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
                await using var sender = new ServiceBusSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var messageCount = 10;
                IEnumerable<ServiceBusMessage> messages = GetMessages(messageCount);
                await sender.SendBatchAsync(messages);

                var receiver = new ServiceBusReceiverClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var receivedMessageCount = 0;
                var messageEnum = messages.GetEnumerator();

                foreach (var item in await receiver.ReceiveBatchAsync(messageCount))
                {
                    receivedMessageCount++;
                    messageEnum.MoveNext();
                    Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                    await receiver.DeferAsync(item);
                }
                Assert.AreEqual(messageCount, receivedMessageCount);

                // TODO: Call ReceiveDeferredMessageAsync() to verify the messages
            }
        }

        [Test]
        public async Task ReceiveMessagesInReceiveAndDeleteMode()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var sender = new ServiceBusSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var messageCount = 10;
                IEnumerable<ServiceBusMessage> messages = GetMessages(messageCount);
                await sender.SendBatchAsync(messages);

                var clientOptions = new ServiceBusReceiverClientOptions()
                {
                    ReceiveMode = ReceiveMode.ReceiveAndDelete,
                };
                var receiver = new ServiceBusReceiverClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName, clientOptions);
                var receivedMessageCount = 0;
                var messageEnum = messages.GetEnumerator();

                foreach (var item in await receiver.ReceiveBatchAsync(messageCount).ConfigureAwait(false))
                {
                    messageEnum.MoveNext();
                    Assert.AreEqual(messageEnum.Current.MessageId, item.MessageId);
                    receivedMessageCount++;
                }
                Assert.AreEqual(messageCount, receivedMessageCount);

                var message = receiver.PeekAsync();
                Assert.IsNull(message.Result);
            }
        }

        [Test]
        public async Task RenewMessageLock()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var sender = new ServiceBusSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var messageCount = 1;
                IEnumerable<ServiceBusMessage> messages = GetMessages(messageCount);
                await sender.SendBatchAsync(messages);

                var receiver = new ServiceBusReceiverClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                ServiceBusReceivedMessage[] receivedMessages = (await receiver.ReceiveBatchAsync(messageCount)).ToArray();

                var message = receivedMessages.First();
                var firstLockedUntilUtcTime = message.LockedUntilUtc;

                // Sleeping for 10 seconds...
                await Task.Delay(10000);

                await receiver.RenewLockAsync(message);

                Assert.True(message.LockedUntilUtc >= firstLockedUntilUtcTime + TimeSpan.FromSeconds(10));

                // Complete Messages
                await receiver.CompleteAsync(message);

                var messageEnum = messages.GetEnumerator();
                messageEnum.MoveNext();

                Assert.AreEqual(messageCount, receivedMessages.Length);
                Assert.AreEqual(messageEnum.Current.MessageId, message.MessageId);

                var peekedMessage = receiver.PeekAsync();
                Assert.IsNull(peekedMessage.Result);
            }
        }
    }
}
