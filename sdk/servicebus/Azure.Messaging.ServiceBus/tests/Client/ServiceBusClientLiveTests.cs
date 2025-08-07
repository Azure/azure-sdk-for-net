// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
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

        /// <summary>
        ///   Verifies that the <see cref="ServiceBusClient" /> is able to
        ///   connect to the Service Bus service when the SSL certificate is accepted.
        /// </summary>
        ///
        [Test]
        public async Task ClientCanConnectWhenCustomValidationAcceptsTheCertificate()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var options = new ServiceBusClientOptions
                {
                    CertificateValidationCallback = (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) => true
                };

                await using (var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential, options))
                {
                    Assert.That(async () =>
                    {
                        ServiceBusReceiver receiver = null;

                        try
                        {
                            receiver = client.CreateReceiver(scope.QueueName);
                            await receiver.PeekMessageAsync().ConfigureAwait(false);
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
        ///   Verifies that the <see cref="ServiceBusClient" /> is unable to
        ///   connect to the Service Bus service when the SSL certificate is rejected.
        /// </summary>
        ///
        [Test]
        public async Task ClientCannotConnectWhenCustomValidationAcceptsTheCertificate()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var options = new ServiceBusClientOptions
                {
                    CertificateValidationCallback = (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) => false
                };

                await using (var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential, options))
                {
                    Assert.That(async () =>
                    {
                        ServiceBusReceiver receiver = null;

                        try
                        {
                            receiver = client.CreateReceiver(scope.QueueName);
                            await receiver.PeekMessageAsync().ConfigureAwait(false);
                        }
                        finally
                        {
                            await (receiver?.DisposeAsync() ?? new ValueTask());
                        }
                    }, Throws.InstanceOf<AuthenticationException>());
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
                var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
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
                var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
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
    }
}
