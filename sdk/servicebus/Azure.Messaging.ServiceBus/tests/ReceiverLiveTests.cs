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
                await sender.SendRangeAsync(GetMessages(10));

                var receiver = new QueueReceiverClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                await foreach (var item in receiver.ReceiveBatchAsync(10))
                    Assert.AreEqual(item.SystemProperties.DeliveryCount, 1);
            }
        }

        [Test]
        public async Task ReceiveMessagesInReceiveAndDeleteMode()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var sender = new QueueSenderClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName);
                await sender.SendRangeAsync(GetMessages(10));

                var clientOptions = new QueueReceiverClientOptions()
                {
                    ReceiveMode = ReceiveMode.ReceiveAndDelete,
                };
                var receiver = new QueueReceiverClient(TestEnvironment.ServiceBusConnectionString, scope.QueueName, clientOptions);
                await foreach (var item in receiver.ReceiveBatchAsync(10))
                    Console.Write(item.Body + " ");

                var message = receiver.PeekAsync();
                Assert.IsNull(message.Result);
            }
        }
    }
}
