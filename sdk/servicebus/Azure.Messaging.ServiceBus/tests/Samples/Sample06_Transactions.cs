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
                var client = GetClient();
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
                var client = GetClient();
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
    }
}
