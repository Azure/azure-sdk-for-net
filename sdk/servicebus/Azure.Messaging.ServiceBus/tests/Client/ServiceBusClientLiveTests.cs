// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
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
        public async Task ClientCanConnectUsingSasCredential()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: true, enableSession: false))
            {
                var options = new ServiceBusClientOptions();
                var audience = ServiceBusConnection.BuildConnectionResource(options.TransportType, TestEnvironment.FullyQualifiedNamespace, scope.QueueName);
                var connectionString = TestEnvironment.BuildConnectionStringWithSharedAccessSignature(scope.QueueName, audience);
                var parsed = ServiceBusConnectionStringProperties.Parse(connectionString);
                var credential = new AzureSasCredential(parsed.SharedAccessSignature);

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
        public async Task ClientCanConnectUsingSharedKeyCredential()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: true, enableSession: false))
            {
                var options = new ServiceBusClientOptions();
                var audience = ServiceBusConnection.BuildConnectionResource(options.TransportType, TestEnvironment.FullyQualifiedNamespace, scope.QueueName);
                var credential = new AzureNamedKeyCredential(TestEnvironment.SharedAccessKeyName, TestEnvironment.SharedAccessKey);

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
        ///   Verifies that the <see cref="ServiceBusClient" /> is able to
        ///   connect to the Service Bus service.
        /// </summary>
        ///
        [Test]
        public async Task ClientCanConnectWithConnectionStringAndCustomIdentifier()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: true, enableSession: false))
            {
                var options = new ServiceBusClientOptions
                {
                    Identifier = "MyServiceBusClient<3"
                };
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

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetChildClientFromClosedParentClientThrows(bool useSessions)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: true, enableSession: useSessions))
            {
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var sender = client.CreateSender(scope.QueueName);

                var message = ServiceBusTestUtilities.GetMessage(useSessions ? "sessionId" : null);
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

                var message = ServiceBusTestUtilities.GetMessage(useSessions ? "sessionId" : null);
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

        [Test]
        public async Task AcceptNextSessionRespectsCancellation()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                var client = CreateClient(60);
                var duration = TimeSpan.FromSeconds(5);
                using var cancellationTokenSource = new CancellationTokenSource(duration);

                var start = DateTime.UtcNow;
                Assert.ThrowsAsync<TaskCanceledException>(async () => await client.AcceptNextSessionAsync(scope.QueueName, cancellationToken: cancellationTokenSource.Token));
                var stop = DateTime.UtcNow;

                Assert.Less(stop - start, duration.Add(duration));
                var sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(ServiceBusTestUtilities.GetMessage("sessionId"));

                start = DateTime.UtcNow;
                var receiver = await client.AcceptNextSessionAsync(scope.QueueName);
                stop = DateTime.UtcNow;
                Assert.Less(stop - start, duration.Add(duration));
            }
        }

        [Test]
        public async Task CanAcceptBlankSession()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                var client = CreateClient();
                var receiver = await client.AcceptSessionAsync(scope.QueueName, "");
                Assert.AreEqual("", receiver.SessionId);
            }
        }

        [Test]
        public async Task MetricsAreUpdatedCorrectly()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString, new ServiceBusClientOptions { EnableTransportMetrics = true });

                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                await sender.SendMessageAsync(new ServiceBusMessage());
                var metrics = client.GetTransportMetrics();
                var firstHeartBeat = metrics.LastHeartBeat;
                var firstOpen = metrics.LastConnectionOpen;
                Assert.GreaterOrEqual(firstOpen, firstHeartBeat);

                SimulateNetworkFailure(client);
                await sender.SendMessageAsync(new ServiceBusMessage());

                metrics = client.GetTransportMetrics();
                var secondOpen = metrics.LastConnectionOpen;
                Assert.Greater(secondOpen, firstOpen);

                SimulateNetworkFailure(client);
                var receiver = client.CreateReceiver(scope.QueueName);
                await receiver.ReceiveMessageAsync(TimeSpan.FromSeconds(30));

                metrics = client.GetTransportMetrics();
                var thirdOpen = metrics.LastConnectionOpen;
                Assert.Greater(thirdOpen, secondOpen);

                await client.DisposeAsync();
                // The close frame does not come back from the service before the DisposeAsync
                // call is returned.
                await Task.Delay(1000);
                metrics = client.GetTransportMetrics();
                Assert.Greater(metrics.LastConnectionClose, thirdOpen);
                Assert.Greater(metrics.LastHeartBeat, firstHeartBeat);
            }
        }

        [Test]
        public async Task MetricsInstanceIsNotMutated()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString, new ServiceBusClientOptions { EnableTransportMetrics = true });

                ServiceBusSender sender = client.CreateSender(scope.QueueName);

                await sender.SendMessageAsync(new ServiceBusMessage());
                var metrics = client.GetTransportMetrics();
                var firstHeartBeat = metrics.LastHeartBeat;
                var firstOpen = metrics.LastConnectionOpen;
                Assert.GreaterOrEqual(firstOpen, firstHeartBeat);

                SimulateNetworkFailure(client);
                await sender.SendMessageAsync(new ServiceBusMessage());
                Assert.AreEqual(firstOpen, metrics.LastConnectionOpen);

                await client.DisposeAsync();
                // The close frame does not come back from the service before the DisposeAsync
                // call is returned.
                await Task.Delay(500);
                Assert.IsNull(metrics.LastConnectionClose);
            }
        }
    }
}
