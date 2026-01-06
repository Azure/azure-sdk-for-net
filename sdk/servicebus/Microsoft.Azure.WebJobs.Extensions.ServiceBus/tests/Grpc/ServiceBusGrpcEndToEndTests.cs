// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if NET6_0_OR_GREATER
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Tests;
using Google.Protobuf;
using Grpc.Core;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;
using Microsoft.Azure.ServiceBus.Grpc;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Grpc;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Host.EndToEndTests
{
    public class ServiceBusGrpcEndToEndTests : ServiceBusGrpcEndToEndTestsBase
    {
        public ServiceBusGrpcEndToEndTests() : base(isSession: false)
        {
        }

        [Test]
        public async Task BindToMessageAndComplete()
        {
            var host = BuildHost<ServiceBusBindToMessageAndComplete>();
            var settlementImpl = host.Services.GetRequiredService<SettlementService>();
            var provider = host.Services.GetRequiredService<MessagingProvider>();
            ServiceBusBindToMessageAndComplete.SettlementService = settlementImpl;

            using (host)
            {
                var message = new ServiceBusMessage("foobar");
                await using ServiceBusClient client = new ServiceBusClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);
                var sender = client.CreateSender(FirstQueueScope.QueueName);
                await sender.SendMessageAsync(message);

                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.That(result, Is.True);
                await host.StopAsync();
            }
            Assert.That(provider.ActionsCache, Is.Empty);
        }

        [Test]
        public async Task BindToBatchAndComplete()
        {
            var host = BuildHost<ServiceBusBindToBatchAndComplete>();
            var settlementImpl = host.Services.GetRequiredService<SettlementService>();
            var provider = host.Services.GetRequiredService<MessagingProvider>();
            ServiceBusBindToBatchAndComplete.SettlementService = settlementImpl;

            using (host)
            {
                var message = new ServiceBusMessage("foobar");
                await using ServiceBusClient client = new ServiceBusClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);
                var sender = client.CreateSender(FirstQueueScope.QueueName);
                await sender.SendMessageAsync(message);

                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.That(result, Is.True);
                await host.StopAsync();
            }
            Assert.That(provider.ActionsCache, Is.Empty);
        }

        [Test]
        public async Task BindToMessageAndDeadletter()
        {
            var host = BuildHost<ServiceBusBindToMessageAndDeadletter>();
            var settlementImpl = host.Services.GetRequiredService<SettlementService>();
            var provider = host.Services.GetRequiredService<MessagingProvider>();
            ServiceBusBindToMessageAndDeadletter.SettlementService = settlementImpl;

            using (host)
            {
                var message = new ServiceBusMessage("foobar");
                await using ServiceBusClient client = new ServiceBusClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);
                var sender = client.CreateSender(FirstQueueScope.QueueName);
                await sender.SendMessageAsync(message);

                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.That(result, Is.True);
                await host.StopAsync();
            }
            Assert.That(provider.ActionsCache, Is.Empty);
        }

        [Test]
        public async Task BindToMessageAndDeadletterWithNoPropertiesToModify()
        {
            var host = BuildHost<ServiceBusBindToMessageAndDeadletterWithNoPropertiesToModify>();
            var settlementImpl = host.Services.GetRequiredService<SettlementService>();
            var provider = host.Services.GetRequiredService<MessagingProvider>();
            ServiceBusBindToMessageAndDeadletterWithNoPropertiesToModify.SettlementService = settlementImpl;

            using (host)
            {
                var message = new ServiceBusMessage("foobar");
                await using ServiceBusClient client = new ServiceBusClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);
                var sender = client.CreateSender(FirstQueueScope.QueueName);
                await sender.SendMessageAsync(message);

                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.That(result, Is.True);
                await host.StopAsync();
            }
            Assert.That(provider.ActionsCache, Is.Empty);
        }

        [Test]
        public async Task BindToBatchAndDeadletterExceptionValidation()
        {
            // this test expects errors so set skipValidation=true
            var host = BuildHost<ServiceBusBindToBatchAndDeadletter>(skipValidation: true);
            var settlementImpl = host.Services.GetRequiredService<SettlementService>();
            var provider = host.Services.GetRequiredService<MessagingProvider>();
            ServiceBusBindToBatchAndDeadletter.SettlementService = settlementImpl;

            using (host)
            {
                var message = new ServiceBusMessage("foobar");
                await using ServiceBusClient client = new ServiceBusClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);
                var sender = client.CreateSender(FirstQueueScope.QueueName);
                await sender.SendMessageAsync(message);

                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.That(result, Is.True);
                await host.StopAsync();
            }
            Assert.That(provider.ActionsCache, Is.Empty);
        }

        [Test]
        public async Task BindToMessageAndDefer()
        {
            var host = BuildHost<ServiceBusBindToMessageAndDefer>();
            var settlementImpl = host.Services.GetRequiredService<SettlementService>();
            var provider = host.Services.GetRequiredService<MessagingProvider>();
            ServiceBusBindToMessageAndDefer.SettlementService = settlementImpl;

            using (host)
            {
                var message = new ServiceBusMessage("foobar");
                await using ServiceBusClient client = new ServiceBusClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);
                var sender = client.CreateSender(FirstQueueScope.QueueName);
                await sender.SendMessageAsync(message);

                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.That(result, Is.True);
                await host.StopAsync();
            }
            Assert.That(provider.ActionsCache, Is.Empty);
        }

        [Test]
        public async Task BindToBatchAndDefer()
        {
            var host = BuildHost<ServiceBusBindToBatchAndDefer>();
            var settlementImpl = host.Services.GetRequiredService<SettlementService>();
            var provider = host.Services.GetRequiredService<MessagingProvider>();
            ServiceBusBindToBatchAndDefer.SettlementService = settlementImpl;

            using (host)
            {
                var message = new ServiceBusMessage("foobar");
                await using ServiceBusClient client = new ServiceBusClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);
                var sender = client.CreateSender(FirstQueueScope.QueueName);
                await sender.SendMessageAsync(message);

                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.That(result, Is.True);
                await host.StopAsync();
            }
            Assert.That(provider.ActionsCache, Is.Empty);
        }

        [Test]
        public async Task BindToMessageAndAbandon()
        {
            var host = BuildHost<ServiceBusBindToMessageAndAbandon>();
            var settlementImpl = host.Services.GetRequiredService<SettlementService>();
            var provider = host.Services.GetRequiredService<MessagingProvider>();
            ServiceBusBindToMessageAndAbandon.SettlementService = settlementImpl;
            await using ServiceBusClient client = new ServiceBusClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);

            using (host)
            {
                var message = new ServiceBusMessage("foobar");
                var sender = client.CreateSender(FirstQueueScope.QueueName);
                await sender.SendMessageAsync(message);

                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.That(result, Is.True);
            }

            var abandonedMessage = (await client.CreateReceiver(FirstQueueScope.QueueName).ReceiveMessagesAsync(1)).Single();
            Assert.Multiple(() =>
            {
                Assert.That(abandonedMessage.Body.ToString(), Is.EqualTo("foobar"));
                Assert.That(abandonedMessage.ApplicationProperties["key"], Is.EqualTo("value"));
                Assert.That(provider.ActionsCache, Is.Empty);
            });
        }

        [Test]
        public async Task BindToBatchAndAbandon()
        {
            var host = BuildHost<ServiceBusBindToBatchAndAbandon>();
            var settlementImpl = host.Services.GetRequiredService<SettlementService>();
            var provider = host.Services.GetRequiredService<MessagingProvider>();
            ServiceBusBindToBatchAndAbandon.SettlementService = settlementImpl;
            await using ServiceBusClient client = new ServiceBusClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);

            using (host)
            {
                var message = new ServiceBusMessage("foobar");
                var sender = client.CreateSender(FirstQueueScope.QueueName);
                await sender.SendMessageAsync(message);

                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.That(result, Is.True);
            }

            var abandonedMessage = (await client.CreateReceiver(FirstQueueScope.QueueName).ReceiveMessagesAsync(1)).Single();
            Assert.Multiple(() =>
            {
                Assert.That(abandonedMessage.Body.ToString(), Is.EqualTo("foobar"));
                Assert.That(abandonedMessage.ApplicationProperties["key"], Is.EqualTo("value"));
                Assert.That(provider.ActionsCache, Is.Empty);
            });
        }

        [Test]
        public async Task BindToMessageAndRenewMessageLock()
        {
            var host = BuildHost<ServiceBusBindToMessageAndRenewMessageLock>();
            var settlementImpl = host.Services.GetRequiredService<SettlementService>();
            var provider = host.Services.GetRequiredService<MessagingProvider>();
            ServiceBusBindToMessageAndRenewMessageLock.SettlementService = settlementImpl;
            await using ServiceBusClient client = new ServiceBusClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);

            using (host)
            {
                var message = new ServiceBusMessage("foobar");
                var sender = client.CreateSender(FirstQueueScope.QueueName);
                await sender.SendMessageAsync(message);

                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.That(result, Is.True);
            }
            Assert.That(provider.ActionsCache, Is.Empty);
        }

        public class ServiceBusBindToMessageAndComplete
        {
            internal static SettlementService SettlementService { get; set; }
            public static async Task BindToMessage(
                [ServiceBusTrigger(FirstQueueNameKey)] ServiceBusReceivedMessage message)
            {
                Assert.That(message.Body.ToString(), Is.EqualTo("foobar"));
                await SettlementService.Complete(new CompleteRequest() { Locktoken = message.LockToken }, new MockServerCallContext());
                _waitHandle1.Set();
            }
        }

        public class ServiceBusBindToBatchAndComplete
        {
            internal static SettlementService SettlementService { get; set; }
            public static async Task BindToMessage(
                [ServiceBusTrigger(FirstQueueNameKey)] ServiceBusReceivedMessage[] messages)
            {
                var message = messages.Single();
                Assert.That(message.Body.ToString(), Is.EqualTo("foobar"));
                await SettlementService.Complete(new CompleteRequest() { Locktoken = message.LockToken }, new MockServerCallContext());
                _waitHandle1.Set();
            }
        }

        public class ServiceBusBindToMessageAndDeadletter
        {
            internal static SettlementService SettlementService { get; set; }
            public static async Task BindToMessage(
                [ServiceBusTrigger(FirstQueueNameKey)] ServiceBusReceivedMessage message, ServiceBusClient client)
            {
                Assert.That(message.Body.ToString(), Is.EqualTo("foobar"));
                await SettlementService.Deadletter(
                    new DeadletterRequest()
                    {
                        Locktoken = message.LockToken,
                        DeadletterErrorDescription = "description",
                        DeadletterReason = "reason",
                        PropertiesToModify = EncodeDictionary(new Dictionary<string, object>{{ "key", 42}})
                    },
                    new MockServerCallContext());

                var receiver = client.CreateReceiver(FirstQueueScope.QueueName, new ServiceBusReceiverOptions {SubQueue = SubQueue.DeadLetter});
                var deadletterMessage = await receiver.ReceiveMessageAsync();
                Assert.Multiple(() =>
                {
                    Assert.That(deadletterMessage.Body.ToString(), Is.EqualTo("foobar"));
                    Assert.That(deadletterMessage.DeadLetterErrorDescription, Is.EqualTo("description"));
                    Assert.That(deadletterMessage.DeadLetterReason, Is.EqualTo("reason"));
                    Assert.That(deadletterMessage.ApplicationProperties["key"], Is.EqualTo(42));
                });
                _waitHandle1.Set();
            }
        }

        public class ServiceBusBindToMessageAndDeadletterWithNoPropertiesToModify
        {
            internal static SettlementService SettlementService { get; set; }
            public static async Task BindToMessage(
                [ServiceBusTrigger(FirstQueueNameKey)] ServiceBusReceivedMessage message, ServiceBusClient client)
            {
                Assert.That(message.Body.ToString(), Is.EqualTo("foobar"));
                await SettlementService.Deadletter(
                    new DeadletterRequest()
                    {
                        Locktoken = message.LockToken,
                        DeadletterErrorDescription = "description",
                        DeadletterReason = "reason"
                    },
                    new MockServerCallContext());

                var receiver = client.CreateReceiver(FirstQueueScope.QueueName, new ServiceBusReceiverOptions {SubQueue = SubQueue.DeadLetter});
                var deadletterMessage = await receiver.ReceiveMessageAsync();
                Assert.Multiple(() =>
                {
                    Assert.That(deadletterMessage.Body.ToString(), Is.EqualTo("foobar"));
                    Assert.That(deadletterMessage.DeadLetterErrorDescription, Is.EqualTo("description"));
                    Assert.That(deadletterMessage.DeadLetterReason, Is.EqualTo("reason"));
                });
                _waitHandle1.Set();
            }
        }

        public class ServiceBusBindToBatchAndDeadletter
        {
            internal static SettlementService SettlementService { get; set; }

            public static async Task BindToMessage(
                [ServiceBusTrigger(FirstQueueNameKey)] ServiceBusReceivedMessage[] messages, ServiceBusClient client)
            {
                var message = messages.Single();

                Assert.That(message.Body.ToString(), Is.EqualTo("foobar"));
                var dict = new Dictionary<string, object> { { "key", 42 } };
                var map = new AmqpMap(dict);
                var buffer = new ByteBuffer(200, true);
                AmqpCodec.EncodeMap(map, buffer);
                await SettlementService.Deadletter(
                    new DeadletterRequest()
                    {
                        Locktoken = message.LockToken,
                        DeadletterErrorDescription = "description",
                        DeadletterReason = "reason",
                        PropertiesToModify = ByteString.CopyFrom(buffer.Buffer)
                    },
                    new MockServerCallContext());

                var receiver = client.CreateReceiver(FirstQueueScope.QueueName,
                    new ServiceBusReceiverOptions { SubQueue = SubQueue.DeadLetter });
                var deadletterMessage = await receiver.ReceiveMessageAsync();
                Assert.Multiple(() =>
                {
                    Assert.That(deadletterMessage.Body.ToString(), Is.EqualTo("foobar"));
                    Assert.That(deadletterMessage.DeadLetterErrorDescription, Is.EqualTo("description"));
                    Assert.That(deadletterMessage.DeadLetterReason, Is.EqualTo("reason"));
                    Assert.That(deadletterMessage.ApplicationProperties["key"], Is.EqualTo(42));
                });

                var exception = Assert.ThrowsAsync<RpcException>(
                    async () =>
                        await SettlementService.Complete(
                            new CompleteRequest { Locktoken = message.LockToken },
                            new MockServerCallContext()));
                Assert.That(
                    exception.ToString(),
                    Does.Contain("Azure.Messaging.ServiceBus.ServiceBusException: The lock supplied is invalid."));

                exception = Assert.ThrowsAsync<RpcException>(
                    async () =>
                        await SettlementService.Defer(
                            new DeferRequest { Locktoken = message.LockToken },
                            new MockServerCallContext()));
                Assert.That(
                    exception.ToString(),
                    Does.Contain("Azure.Messaging.ServiceBus.ServiceBusException: The lock supplied is invalid."));

                exception = Assert.ThrowsAsync<RpcException>(
                    async () =>
                        await SettlementService.Deadletter(
                            new DeadletterRequest() { Locktoken = message.LockToken },
                            new MockServerCallContext()));
                Assert.That(
                    exception.ToString(),
                    Does.Contain("Azure.Messaging.ServiceBus.ServiceBusException: The lock supplied is invalid."));

                // The service doesn't throw when an already settled message gets abandoned over the mgmt link, so we won't
                // test for that here.

                _waitHandle1.Set();
            }
        }

        public class ServiceBusBindToMessageAndDefer
        {
            internal static SettlementService SettlementService { get; set; }
            public static async Task BindToMessage(
                [ServiceBusTrigger(FirstQueueNameKey)] ServiceBusReceivedMessage message, ServiceBusReceiveActions receiveActions)
            {
                Assert.That(message.Body.ToString(), Is.EqualTo("foobar"));
                await SettlementService.Defer(
                    new DeferRequest
                    {
                        Locktoken = message.LockToken,
                        PropertiesToModify = EncodeDictionary(new Dictionary<string, object>{{ "key", true}})
                    },
                    new MockServerCallContext());
                var deferredMessage = (await receiveActions.ReceiveDeferredMessagesAsync(
                    new[] { message.SequenceNumber })).Single();
                Assert.Multiple(() =>
                {
                    Assert.That(deferredMessage.Body.ToString(), Is.EqualTo("foobar"));
                    Assert.That((bool)deferredMessage.ApplicationProperties["key"], Is.True);
                });
                _waitHandle1.Set();
            }
        }

        public class ServiceBusBindToBatchAndDefer
        {
            internal static SettlementService SettlementService { get; set; }
            public static async Task BindToMessage(
                [ServiceBusTrigger(FirstQueueNameKey)] ServiceBusReceivedMessage[] messages, ServiceBusReceiveActions receiveActions)
            {
                var message = messages.Single();

                Assert.That(message.Body.ToString(), Is.EqualTo("foobar"));
                await SettlementService.Defer(
                    new DeferRequest
                    {
                        Locktoken = message.LockToken,
                        PropertiesToModify = EncodeDictionary(new Dictionary<string, object>{{ "key", true}})
                    },
                    new MockServerCallContext());
                var deferredMessage = (await receiveActions.ReceiveDeferredMessagesAsync(
                    new[] { message.SequenceNumber })).Single();
                Assert.Multiple(() =>
                {
                    Assert.That(deferredMessage.Body.ToString(), Is.EqualTo("foobar"));
                    Assert.That((bool)deferredMessage.ApplicationProperties["key"], Is.True);
                });
                _waitHandle1.Set();
            }
        }

        public class ServiceBusBindToMessageAndAbandon
        {
            internal static SettlementService SettlementService { get; set; }
            public static async Task BindToMessage(
                [ServiceBusTrigger(FirstQueueNameKey)] ServiceBusReceivedMessage message, ServiceBusReceiveActions receiveActions)
            {
                Assert.That(message.Body.ToString(), Is.EqualTo("foobar"));
                await SettlementService.Abandon(
                    new AbandonRequest
                    {
                        Locktoken = message.LockToken,
                        PropertiesToModify = EncodeDictionary(new Dictionary<string, object>{{ "key", "value"}})
                    },
                    new MockServerCallContext());
                _waitHandle1.Set();
            }
        }

        public class ServiceBusBindToBatchAndAbandon
        {
            internal static SettlementService SettlementService { get; set; }
            public static async Task BindToMessage(
                [ServiceBusTrigger(FirstQueueNameKey)] ServiceBusReceivedMessage[] messages, ServiceBusReceiveActions receiveActions)
            {
                var message = messages.Single();

                Assert.That(message.Body.ToString(), Is.EqualTo("foobar"));
                await SettlementService.Abandon(
                    new AbandonRequest
                    {
                        Locktoken = message.LockToken,
                        PropertiesToModify = EncodeDictionary(new Dictionary<string, object>{{ "key", "value"}})
                    },
                    new MockServerCallContext());
                _waitHandle1.Set();
            }
        }

        public class ServiceBusBindToMessageAndRenewMessageLock
        {
            internal static SettlementService SettlementService { get; set; }
            public static async Task BindToMessage(
                [ServiceBusTrigger(FirstQueueNameKey)] ServiceBusReceivedMessage message, ServiceBusReceiveActions receiveActions)
            {
                Assert.That(message.Body.ToString(), Is.EqualTo("foobar"));
                var lockedBefore = message.LockedUntil;
                await SettlementService.RenewMessageLock(
                    new RenewMessageLockRequest { Locktoken = message.LockToken },
                    new MockServerCallContext());
                _waitHandle1.Set();
            }
        }
    }
}
#endif