// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Azure.Identity;
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
                #region Snippet:ServiceBusTransactionalSend
#if SNIPPET
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string queueName = "<queue_name>";
                // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
                await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
                await using ServiceBusClient client = CreateClient();
                string queueName = scope.QueueName;
#endif
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
                #region Snippet:ServiceBusTransactionalSetSessionState
#if SNIPPET
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string queueName = "<queue_name>";
                // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
                await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
                await using ServiceBusClient client = CreateClient();
                string queueName = scope.QueueName;
#endif
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
        public async Task CrossEntityTransaction()
        {
            await using var queueA = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false);
            await using var queueB = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false);
            await using var topicC = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false);

            #region Snippet:ServiceBusCrossEntityTransaction
#if SNIPPET
            string fullyQualifiedNamespace = "<fully_qualified_namespace>";
            ServiceBusClientOptions options = new(){ EnableCrossEntityTransactions = true };
            await using ServiceBusClient client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential(), options);

            ServiceBusReceiver receiverA = client.CreateReceiver("queueA");
            ServiceBusSender senderB = client.CreateSender("queueB");
            ServiceBusSender senderC = client.CreateSender("topicC");
#else
            await using ServiceBusClient client = new(
                TestEnvironment.FullyQualifiedNamespace,
                TestEnvironment.Credential,
                new ServiceBusClientOptions
                {
                    EnableCrossEntityTransactions = true
                });
            ServiceBusSender senderA = client.CreateSender(queueA.QueueName);
            await senderA.SendMessageAsync(new ServiceBusMessage());

            ServiceBusReceiver receiverA = client.CreateReceiver(queueA.QueueName);
            ServiceBusSender senderB = client.CreateSender(queueB.QueueName);
            ServiceBusSender senderC = client.CreateSender(topicC.TopicName);
#endif

            ServiceBusReceivedMessage receivedMessage = await receiverA.ReceiveMessageAsync();

            using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await receiverA.CompleteMessageAsync(receivedMessage);
                await senderB.SendMessageAsync(new ServiceBusMessage());
                await senderC.SendMessageAsync(new ServiceBusMessage());
                ts.Complete();
            }
            #endregion

            receivedMessage = await receiverA.ReceiveMessageAsync(TimeSpan.FromSeconds(5));
            Assert.IsNull(receivedMessage);
        }

        [Test]
        [Ignore("Only verifying that it compiles.")]
        public async Task CrossEntityTransactionWrongOrder()
        {
            await using var queueA = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false);
            await using var queueB = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false);
            await using var topicC = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false);

            #region Snippet:ServiceBusCrossEntityTransactionWrongOrder
#if SNIPPET
            string fullyQualifiedNamespace = "<fully_qualified_namespace>";
            ServiceBusClientOptions options = new(){ EnableCrossEntityTransactions = true };
            await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential(), options);

            ServiceBusReceiver receiverA = client.CreateReceiver("queueA");
            ServiceBusSender senderB = client.CreateSender("queueB");
            ServiceBusSender senderC = client.CreateSender("topicC");
#else
            await using ServiceBusClient client = new(
                TestEnvironment.FullyQualifiedNamespace,
                TestEnvironment.Credential,
                new()
                {
                    EnableCrossEntityTransactions = true
                });

            ServiceBusSender senderA = client.CreateSender(queueA.QueueName);
            await senderA.SendMessageAsync(new ServiceBusMessage());

            ServiceBusReceiver receiverA = client.CreateReceiver(queueA.QueueName);
            ServiceBusSender senderB = client.CreateSender(queueB.QueueName);
            ServiceBusSender senderC = client.CreateSender(topicC.TopicName);
#endif

            // SenderB becomes the entity through which subsequent "sends" are routed through, since it is the first
            // entity on which an operation is performed with the cross-entity transaction client.
            await senderB.SendMessageAsync(new ServiceBusMessage());

            ServiceBusReceivedMessage receivedMessage = await receiverA.ReceiveMessageAsync();

            using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                // This will throw an InvalidOperationException because a "receive" cannot be
                // routed through a different entity.
                await receiverA.CompleteMessageAsync(receivedMessage);
                await senderB.SendMessageAsync(new ServiceBusMessage());
                await senderC.SendMessageAsync(new ServiceBusMessage());
                ts.Complete();
            }
            #endregion

            receivedMessage = await receiverA.ReceiveMessageAsync();
            Assert.IsNull(receivedMessage);
        }
    }
}
