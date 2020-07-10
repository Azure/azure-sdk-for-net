// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Client
{
    public class ServiceBusClientLiveTests : ServiceBusLiveTestBase
    {
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetChildClientFromClosedParentClientThrows(bool useSessions)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: true, enableSession: useSessions))
            {
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var sender = client.CreateSender(scope.QueueName);

                var message = GetMessage(useSessions ? "sessionId" : null);
                await sender.SendMessageAsync(message);
                await sender.DisposeAsync();
                ServiceBusReceiver receiver;
                if (!useSessions)
                {
                    receiver = client.CreateReceiver(scope.QueueName);
                }
                else
                {
                    receiver = await client.CreateSessionReceiverAsync(scope.QueueName);
                }
                var receivedMessage = await receiver.ReceiveMessageAsync().ConfigureAwait(false);
                Assert.AreEqual(message.Body.ToString(), receivedMessage.Body.ToString());

                await client.DisposeAsync();
                Assert.IsTrue(client.IsDisposed);
                if (!useSessions)
                {
                    Assert.Throws<ObjectDisposedException>(() => client.CreateReceiver(scope.QueueName));
                    Assert.Throws<ObjectDisposedException>(() => client.CreateReceiver(scope.QueueName, scope.QueueName));
                    Assert.Throws<ObjectDisposedException>(() => client.CreateSender(scope.QueueName));
                }
                else
                {
                    Assert.ThrowsAsync<ObjectDisposedException>(async () => await client.CreateSessionReceiverAsync(scope.QueueName));
                    Assert.ThrowsAsync<ObjectDisposedException>(async () => await client.CreateSessionReceiverAsync(
                        scope.QueueName,
                        new ServiceBusSessionReceiverOptions { SessionId = "sessionId" }));
                }
                Assert.Throws<ObjectDisposedException>(() => client.CreateProcessor(scope.QueueName));
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetChildClientFromParentSucceedsOnOpenConnection(bool useSessions)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: true, enableSession: useSessions))
            {
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var sender = client.CreateSender(scope.QueueName);

                var message = GetMessage(useSessions ? "sessionId" : null);
                await sender.SendMessageAsync(message);
                await sender.DisposeAsync();
                ServiceBusReceiver receiver;
                if (!useSessions)
                {
                    receiver = client.CreateReceiver(scope.QueueName);
                }
                else
                {
                    receiver = await client.CreateSessionReceiverAsync(scope.QueueName);
                }
                var receivedMessage = await receiver.ReceiveMessageAsync().ConfigureAwait(false);
                Assert.AreEqual(message.Body.ToString(), receivedMessage.Body.ToString());

                if (!useSessions)
                {
                    client.CreateReceiver(scope.QueueName);
                    client.CreateReceiver(scope.QueueName, scope.QueueName);
                    client.CreateSender(scope.QueueName);
                }
                else
                {
                    // close old receiver so we can get session lock
                    await receiver.DisposeAsync();
                    await client.CreateSessionReceiverAsync(scope.QueueName);
                }
                client.CreateProcessor(scope.QueueName);
            }
        }
    }
}
