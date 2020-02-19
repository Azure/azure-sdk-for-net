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
                IEnumerable<ServiceBusMessage> messages = GetMessages(10);
                await sender.SendRangeAsync(messages);

                var receiver = new QueueReceiverClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                var messageCount = 0;
                var messageEnum = messages.GetEnumerator();

                await foreach (var item in receiver.ReceiveBatchAsync(10))
                {
                    messageCount++;
                    messageEnum.MoveNext();
                    Assert.AreEqual(item.MessageId, messageEnum.Current.MessageId);
                    Assert.AreEqual(item.SystemProperties.DeliveryCount, 1);
                }
                Assert.AreEqual(messageCount, 10);

                messageCount = 0;
                messageEnum.Reset();
                IAsyncEnumerable<ServiceBusMessage> peekMessages = receiver.PeekRangeAsync(10);
                await foreach (var item in peekMessages)
                {
                    messageEnum.MoveNext();
                    Assert.AreEqual(item.MessageId, messageEnum.Current.MessageId);
                    messageCount++;
                }
                Assert.AreEqual(messageCount, 10);
            }
        }

        [Test]
        public async Task ReceiveMessagesInReceiveAndDeleteMode()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var sender = new QueueSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                IEnumerable<ServiceBusMessage> messages = GetMessages(10);
                await sender.SendRangeAsync(messages);

                var messageEnum = messages.GetEnumerator();
                var clientOptions = new QueueReceiverClientOptions()
                {
                    ReceiveMode = ReceiveMode.ReceiveAndDelete,
                };
                var receiver = new QueueReceiverClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName, clientOptions);
                var messageCount = 0;

                await foreach (var item in receiver.ReceiveBatchAsync(10))
                {
                    messageEnum.MoveNext();
                    Assert.AreEqual(item.MessageId, messageEnum.Current.MessageId);
                    messageCount++;
                }
                Assert.AreEqual(messageCount, 10);

                var message = receiver.PeekAsync();
                Assert.IsNull(message.Result);
            }
        }
    }
}
