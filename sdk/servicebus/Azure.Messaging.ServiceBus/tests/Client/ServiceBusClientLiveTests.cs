// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
                var sender = client.GetSender(scope.QueueName);

                var message = GetMessage(useSessions ? "sessionId" : null);
                await sender.SendAsync(message);
                await sender.DisposeAsync();
                ServiceBusReceiver receiver;
                if (!useSessions)
                {
                    receiver = client.GetReceiver(scope.QueueName);
                }
                else
                {
                    receiver = await client.GetSessionReceiverAsync(scope.QueueName);
                }
                var receivedMessage = await receiver.ReceiveAsync().ConfigureAwait(false);
                Assert.True(Encoding.UTF8.GetString(receivedMessage.Body.ToArray()) == Encoding.UTF8.GetString(message.Body.ToArray()));

                await client.DisposeAsync();
                if (!useSessions)
                {
                    Assert.Throws<ObjectDisposedException>(() => client.GetReceiver(scope.QueueName));
                    Assert.Throws<ObjectDisposedException>(() => client.GetReceiver(scope.QueueName, scope.QueueName));
                    Assert.Throws<ObjectDisposedException>(() => client.GetSender(scope.QueueName));
                }
                else
                {
                    Assert.ThrowsAsync<ObjectDisposedException>(async () => await client.GetSessionReceiverAsync(scope.QueueName));
                    Assert.ThrowsAsync<ObjectDisposedException>(async () => await client.GetSessionReceiverAsync(scope.QueueName, sessionId: scope.QueueName));
                }
                Assert.Throws<ObjectDisposedException>(() => client.GetProcessor(scope.QueueName));
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
                var sender = client.GetSender(scope.QueueName);

                var message = GetMessage(useSessions ? "sessionId" : null);
                await sender.SendAsync(message);
                await sender.DisposeAsync();
                ServiceBusReceiver receiver;
                if (!useSessions)
                {
                    receiver = client.GetReceiver(scope.QueueName);
                }
                else
                {
                    receiver = await client.GetSessionReceiverAsync(scope.QueueName);
                }
                var receivedMessage = await receiver.ReceiveAsync().ConfigureAwait(false);
                Assert.True(Encoding.UTF8.GetString(receivedMessage.Body.ToArray()) == Encoding.UTF8.GetString(message.Body.ToArray()));

                if (!useSessions)
                {
                    client.GetReceiver(scope.QueueName);
                    client.GetReceiver(scope.QueueName, scope.QueueName);
                    client.GetSender(scope.QueueName);
                }
                else
                {
                    // close old receiver so we can get session lock
                    await receiver.DisposeAsync();
                    await client.GetSessionReceiverAsync(scope.QueueName);
                }
                client.GetProcessor(scope.QueueName);
            }
        }
    }
}
