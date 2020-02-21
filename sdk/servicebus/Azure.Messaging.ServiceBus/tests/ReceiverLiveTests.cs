// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
                await using var sender = new QueueSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var messageCt = 10;

                IEnumerable<ServiceBusMessage> sentMessages = GetMessages(messageCt);
                await sender.SendRangeAsync(sentMessages);

                await using var receiver = new QueueReceiverClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);

                Dictionary<string, string> sentMessageIdToLabel = new Dictionary<string, string>();
                foreach (ServiceBusMessage message in sentMessages)
                {
                    sentMessageIdToLabel.Add(message.MessageId, Encoding.Default.GetString(message.Body));
                }
                IAsyncEnumerable<ServiceBusMessage> peekedMessages = receiver.PeekRangeAsync(
                    maxMessages: messageCt);

                var ct = 0;
                await foreach (ServiceBusMessage peekedMessage in peekedMessages)
                {
                    var peekedText = Encoding.Default.GetString(peekedMessage.Body);
                    //var sentText = sentMessageIdToLabel[peekedMessage.MessageId];

                    //sentMessageIdToLabel.Remove(peekedMessage.MessageId);
                    //Assert.AreEqual(sentText, peekedText);

                    TestContext.Progress.WriteLine($"{peekedMessage.Label}: {peekedText}");
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
                await using var sender = new QueueSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var messageCount = 10;
                IEnumerable<ServiceBusMessage> messages = GetMessages(messageCount);
                await sender.SendRangeAsync(messages);

                var receiver = new QueueReceiverClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var receivedMessageCount = 0;
                var messageEnum = messages.GetEnumerator();

                await foreach (var item in receiver.ReceiveBatchAsync(messageCount))
                {
                    receivedMessageCount++;
                    messageEnum.MoveNext();
                    Assert.AreEqual(item.MessageId, messageEnum.Current.MessageId);
                    Assert.AreEqual(item.SystemProperties.DeliveryCount, 1);
                }
                Assert.AreEqual(receivedMessageCount, messageCount);

                messageEnum.Reset();
                IAsyncEnumerable<ServiceBusMessage> peekMessages = receiver.PeekRangeAsync(messageCount);
                await foreach (var item in peekMessages)
                {
                    messageEnum.MoveNext();
                    Assert.AreEqual(item.MessageId, messageEnum.Current.MessageId);
                }
            }
        }

        [Test]
        public async Task CompleteMessages()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var sender = new QueueSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var messageCount = 10;
                IEnumerable<ServiceBusMessage> messages = GetMessages(messageCount);
                await sender.SendRangeAsync(messages);

                var receiver = new QueueReceiverClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var receivedMessageCount = 0;
                var messageEnum = messages.GetEnumerator();

                await foreach (var item in receiver.ReceiveBatchAsync(messageCount))
                {
                    receivedMessageCount++;
                    messageEnum.MoveNext();
                    Assert.AreEqual(item.MessageId, messageEnum.Current.MessageId);
                    await receiver.CompleteAsync(item.SystemProperties.LockToken);
                }
                Assert.AreEqual(receivedMessageCount, messageCount);

                var message = receiver.PeekAsync();
                Assert.IsNull(message.Result);
            }
        }

        [Test]
        public async Task AbandonMessages()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var sender = new QueueSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var messageCount = 10;
                IEnumerable<ServiceBusMessage> messages = GetMessages(messageCount);
                await sender.SendRangeAsync(messages);

                var receiver = new QueueReceiverClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var receivedMessageCount = 0;
                var messageEnum = messages.GetEnumerator();

                await foreach (var item in receiver.ReceiveBatchAsync(messageCount))
                {
                    receivedMessageCount++;
                    messageEnum.MoveNext();
                    Assert.AreEqual(item.MessageId, messageEnum.Current.MessageId);
                    await receiver.AbandonAsync(item.SystemProperties.LockToken);
                    Assert.AreEqual(item.SystemProperties.DeliveryCount, 1);
                }
                Assert.AreEqual(receivedMessageCount, messageCount);

                messageEnum.Reset();
                receivedMessageCount = 0;
                IAsyncEnumerable<ServiceBusMessage> peekMessages = receiver.PeekRangeAsync(messageCount);
                await foreach (var item in peekMessages)
                {
                    receivedMessageCount++;
                    messageEnum.MoveNext();
                    Assert.AreEqual(item.MessageId, messageEnum.Current.MessageId);
                }
                Assert.AreEqual(receivedMessageCount, messageCount);
            }
        }

        [Test]
        public async Task DeadLetterMessages()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var sender = new QueueSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var messageCount = 10;
                IEnumerable<ServiceBusMessage> messages = GetMessages(messageCount);
                await sender.SendRangeAsync(messages);

                var receiver = new QueueReceiverClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var receivedMessageCount = 0;
                var messageEnum = messages.GetEnumerator();

                await foreach (var item in receiver.ReceiveBatchAsync(messageCount))
                {
                    receivedMessageCount++;
                    messageEnum.MoveNext();
                    Assert.AreEqual(item.MessageId, messageEnum.Current.MessageId);
                    await receiver.DeadLetterAsync(item.SystemProperties.LockToken);
                }
                Assert.AreEqual(receivedMessageCount, messageCount);

                var message = receiver.PeekAsync();
                Assert.IsNull(message.Result);

                messageEnum.Reset();
                receivedMessageCount = 0;
                var deadLetterReceiver = new QueueReceiverClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName + "/$DeadLetterQueue");

                await foreach (var item in deadLetterReceiver.ReceiveBatchAsync(messageCount))
                {
                    receivedMessageCount++;
                    messageEnum.MoveNext();
                    Assert.AreEqual(item.MessageId, messageEnum.Current.MessageId);
                    await deadLetterReceiver.CompleteAsync(item.SystemProperties.LockToken);
                }
                Assert.AreEqual(receivedMessageCount, messageCount);

                var deadLetterMessage = deadLetterReceiver.PeekAsync();
                Assert.IsNull(deadLetterMessage.Result);
            }
        }

        [Test]
        public async Task DeferMessages()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var sender = new QueueSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var messageCount = 10;
                IEnumerable<ServiceBusMessage> messages = GetMessages(messageCount);
                await sender.SendRangeAsync(messages);

                var receiver = new QueueReceiverClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var receivedMessageCount = 0;
                var messageEnum = messages.GetEnumerator();

                await foreach (var item in receiver.ReceiveBatchAsync(messageCount))
                {
                    receivedMessageCount++;
                    messageEnum.MoveNext();
                    Assert.AreEqual(item.MessageId, messageEnum.Current.MessageId);
                    await receiver.DeferAsync(item.SystemProperties.LockToken);
                }
                Assert.AreEqual(receivedMessageCount, messageCount);

                // TODO: Call ReceiveDeferredMessageAsync() to verify the messages
            }
        }

        [Test]
        public async Task ReceiveMessagesInReceiveAndDeleteMode()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var sender = new QueueSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var messageCount = 10;
                IEnumerable<ServiceBusMessage> messages = GetMessages(messageCount);
                await sender.SendRangeAsync(messages);

                var clientOptions = new QueueReceiverClientOptions()
                {
                    ReceiveMode = ReceiveMode.ReceiveAndDelete,
                };
                var receiver = new QueueReceiverClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName, clientOptions);
                var receivedMessageCount = 0;
                var messageEnum = messages.GetEnumerator();

                await foreach (var item in receiver.ReceiveBatchAsync(messageCount))
                {
                    messageEnum.MoveNext();
                    Assert.AreEqual(item.MessageId, messageEnum.Current.MessageId);
                    receivedMessageCount++;
                }
                Assert.AreEqual(receivedMessageCount, messageCount);

                var message = receiver.PeekAsync();
                Assert.IsNull(message.Result);
            }
        }
    }
}
