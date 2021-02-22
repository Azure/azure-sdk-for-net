// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Samples
{
    public class Sample06_Transactions : ServiceBusLiveTestBase
    {
        [Test]
        public async Task TransactionalSendAndComplete()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = CreateClient();
                string queueName = scope.QueueName;
                #region Snippet:ServiceBusTransactionalSend
                //@@ string connectionString = "<connection_string>";
                //@@ string queueName = "<queue_name>";
                // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
                //@@ await using var client = new ServiceBusClient(connectionString);
                ServiceBusSender sender = client.CreateSender(queueName);

                await sender.SendMessageAsync(new ServiceBusMessage(Encoding.UTF8.GetBytes("First")));
                ServiceBusReceiver receiver = client.CreateReceiver(queueName);
                ServiceBusReceivedMessage firstMessage = await receiver.ReceiveMessageAsync();
                using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await sender.SendMessageAsync(new ServiceBusMessage(Encoding.UTF8.GetBytes("Second")));
                    await receiver.CompleteMessageAsync(firstMessage);
                    ts.Complete();
                }
                #endregion

                ServiceBusReceivedMessage secondMessage = await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(5));

                Assert.NotNull(secondMessage);
                await receiver.CompleteMessageAsync(secondMessage);
            };
        }

        [Test]
        public async Task TransactionalSetSessionState()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                await using var client = CreateClient();
                string queueName = scope.QueueName;
                #region Snippet:ServiceBusTransactionalSetSessionState
                //@@ string connectionString = "<connection_string>";
                //@@ string queueName = "<queue_name>";
                // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
                //@@ await using var client = new ServiceBusClient(connectionString);
                ServiceBusSender sender = client.CreateSender(queueName);

                await sender.SendMessageAsync(new ServiceBusMessage("my message") { SessionId = "sessionId" });
                ServiceBusSessionReceiver receiver = await client.AcceptNextSessionAsync(queueName);
                ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

                var state = Encoding.UTF8.GetBytes("some state");
                using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await receiver.CompleteMessageAsync(receivedMessage);
                    await receiver.SetSessionStateAsync(new BinaryData(state));
                    ts.Complete();
                }
                #endregion
                var bytes = await receiver.GetSessionStateAsync();
                Assert.AreEqual(state, bytes.ToArray());
            };
        }

        [Test]
        public async Task TransactionGroup()
        {
            await using var client = CreateClient();
            await using var queueA = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false);
            await using var queueB = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false);
            await using var topicC = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false);

            #region Snippet:ServiceBusTransactionGroup

            // The first sender won't be part of our transaction group.
            ServiceBusSender senderA = client.CreateSender(queueA.QueueName);

            string transactionGroup = "myTxn";

            ServiceBusReceiver receiverA = client.CreateReceiver(queueA.QueueName, new ServiceBusReceiverOptions
            {
                TransactionGroup = transactionGroup
            });
            ServiceBusSender senderB = client.CreateSender(queueB.QueueName, new ServiceBusSenderOptions
            {
                TransactionGroup = transactionGroup
            });
            ServiceBusSender senderC = client.CreateSender(topicC.TopicName, new ServiceBusSenderOptions
            {
                TransactionGroup = transactionGroup
            });

            var message = new ServiceBusMessage();

            await senderA.SendMessageAsync(message);

            ServiceBusReceivedMessage receivedMessage = await receiverA.ReceiveMessageAsync();

            using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await receiverA.CompleteMessageAsync(receivedMessage);
                await senderB.SendMessageAsync(message);
                await senderC.SendMessageAsync(message);
                ts.Complete();
            }
            #endregion

            receivedMessage = await receiverA.ReceiveMessageAsync();
            Assert.IsNull(receivedMessage);
        }

        [Test]
        [Ignore("Only verifying that it compiles.")]
        public async Task TransactionGroupWrongOrder()
        {
            await using var client = CreateClient();
            await using var queueA = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false);
            await using var queueB = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false);
            await using var topicC = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false);

            #region Snippet:ServiceBusTransactionGroupWrongOrder
            // The first sender won't be part of our transaction group.
            ServiceBusSender senderA = client.CreateSender(queueA.QueueName);

            string transactionGroup = "myTxn";

            ServiceBusReceiver receiverA = client.CreateReceiver(queueA.QueueName, new ServiceBusReceiverOptions
            {
                TransactionGroup = transactionGroup
            });
            ServiceBusSender senderB = client.CreateSender(queueB.QueueName, new ServiceBusSenderOptions
            {
                TransactionGroup = transactionGroup
            });
            ServiceBusSender senderC = client.CreateSender(topicC.TopicName, new ServiceBusSenderOptions
            {
                TransactionGroup = transactionGroup
            });

            var message = new ServiceBusMessage();

            // SenderB becomes the entity through which subsequent "sends" are routed through.
            await senderB.SendMessageAsync(message);

            await senderA.SendMessageAsync(message);

            ServiceBusReceivedMessage receivedMessage = await receiverA.ReceiveMessageAsync();

            using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                // This will through an InvalidOperationException because a "receive" cannot be
                // routed through a different entity.
                await receiverA.CompleteMessageAsync(receivedMessage);
                await senderB.SendMessageAsync(message);
                await senderC.SendMessageAsync(message);
                ts.Complete();
            }
            #endregion

            receivedMessage = await receiverA.ReceiveMessageAsync();
            Assert.IsNull(receivedMessage);
        }
    }
}
