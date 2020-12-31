// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Core;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Client
{
    public class ServiceBusClientLiveTests : ServiceBusLiveTestBase
    {
        /// <summary>
        ///   Verifies that the <see cref="EventHubConnection" /> is able to
        ///   connect to the Service Bus service.
        /// </summary>
        ///
        [Test]
        public async Task ClientCanConnectUsingSharedAccessSignatureConnectionString()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: true, enableSession: false))
            {
                var options = new ServiceBusClientOptions();
                var audience = ServiceBusConnection.BuildConnectionResource(options.TransportType, TestEnvironment.FullyQualifiedNamespace, scope.QueueName);
                var connectionString = TestEnvironment.BuildConnectionStringWithSharedAccessSignature(scope.QueueName, audience);

                await using (var client = new ServiceBusClient(connectionString, options))
                {
                    Assert.That(async () =>
                    {
                        ServiceBusReceiver receiver = null;

                        try
                        {
                            receiver = client.CreateReceiver(scope.QueueName);
                        }
                        finally
                        {
                            await (receiver?.DisposeAsync() ?? new ValueTask());
                        }
                    }, Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConnection" /> is able to
        ///   connect to the Service Bus service.
        /// </summary>
        ///
        [Test]
        public async Task ClientCanConnectUsingSharedKeyCredentialWithSignature()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: true, enableSession: false))
            {
                var options = new ServiceBusClientOptions();
                var audience = ServiceBusConnection.BuildConnectionResource(options.TransportType, TestEnvironment.FullyQualifiedNamespace, scope.QueueName);
                var connectionString = TestEnvironment.BuildConnectionStringWithSharedAccessSignature(scope.QueueName, audience);
                var parsed = ServiceBusConnectionStringProperties.Parse(connectionString);
                var credential = new ServiceBusSharedAccessKeyCredential(parsed.SharedAccessSignature);

                await using (var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, credential, options))
                {
                    Assert.That(async () =>
                    {
                        ServiceBusReceiver receiver = null;

                        try
                        {
                            receiver = client.CreateReceiver(scope.QueueName);
                        }
                        finally
                        {
                            await (receiver?.DisposeAsync() ?? new ValueTask());
                        }
                    }, Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConnection" /> is able to
        ///   connect to the Service Bus service.
        /// </summary>
        ///
        [Test]
        public async Task ClientCanConnectUsingSharedKeyCredentialWithSharedKey()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: true, enableSession: false))
            {
                var options = new ServiceBusClientOptions();
                var audience = ServiceBusConnection.BuildConnectionResource(options.TransportType, TestEnvironment.FullyQualifiedNamespace, scope.QueueName);
                var credential = new ServiceBusSharedAccessKeyCredential(TestEnvironment.SharedAccessKeyName, TestEnvironment.SharedAccessKey);

                await using (var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, credential, options))
                {
                    Assert.That(async () =>
                    {
                        ServiceBusReceiver receiver = null;

                        try
                        {
                            receiver = client.CreateReceiver(scope.QueueName);
                        }
                        finally
                        {
                            await (receiver?.DisposeAsync() ?? new ValueTask());
                        }
                    }, Throws.Nothing);
                }
            }
        }

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
                    receiver = await client.AcceptNextSessionAsync(scope.QueueName);
                }
                var receivedMessage = await receiver.ReceiveMessageAsync().ConfigureAwait(false);
                Assert.AreEqual(message.Body.ToString(), receivedMessage.Body.ToString());

                await client.DisposeAsync();
                Assert.IsTrue(client.IsClosed);
                if (!useSessions)
                {
                    Assert.Throws<ObjectDisposedException>(() => client.CreateReceiver(scope.QueueName));
                    Assert.Throws<ObjectDisposedException>(() => client.CreateReceiver(scope.QueueName, scope.QueueName));
                    Assert.Throws<ObjectDisposedException>(() => client.CreateSender(scope.QueueName));
                }
                else
                {
                    Assert.ThrowsAsync<ObjectDisposedException>(async () => await client.AcceptNextSessionAsync(scope.QueueName));
                    Assert.ThrowsAsync<ObjectDisposedException>(async () => await client.AcceptSessionAsync(
                        scope.QueueName,
                        "sessionId"));
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
                    receiver = await client.AcceptNextSessionAsync(scope.QueueName);
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
                    await client.AcceptNextSessionAsync(scope.QueueName);
                }
                client.CreateProcessor(scope.QueueName);
            }
        }
    }
}
