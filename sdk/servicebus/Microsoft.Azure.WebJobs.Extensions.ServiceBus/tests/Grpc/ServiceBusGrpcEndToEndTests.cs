// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if NET6_0_OR_GREATER
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Tests;
using Grpc.Core;
using Microsoft.Azure.ServiceBus.Grpc;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Grpc;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Host.EndToEndTests
{
    public class ServiceBusGrpcEndToEndTests : WebJobsServiceBusTestBase
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
                Assert.True(result);
                await host.StopAsync();
            }
            Assert.IsEmpty(provider.ActionsCache);
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
                Assert.True(result);
                await host.StopAsync();
            }
            Assert.IsEmpty(provider.ActionsCache);
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
                Assert.True(result);
                await host.StopAsync();
            }
            Assert.IsEmpty(provider.ActionsCache);
        }

        [Test]
        public async Task BindToBatchAndDeadletter()
        {
            var host = BuildHost<ServiceBusBindToBatchAndDeadletter>();
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
                Assert.True(result);
                await host.StopAsync();
            }
            Assert.IsEmpty(provider.ActionsCache);
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
                Assert.True(result);
                await host.StopAsync();
            }
            Assert.IsEmpty(provider.ActionsCache);
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
                Assert.True(result);
                await host.StopAsync();
            }
            Assert.IsEmpty(provider.ActionsCache);
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
                Assert.True(result);
            }

            var abandonedMessage = (await client.CreateReceiver(FirstQueueScope.QueueName).ReceiveMessagesAsync(1)).Single();
            Assert.AreEqual("foobar", abandonedMessage.Body.ToString());
            Assert.AreEqual("value", abandonedMessage.ApplicationProperties["key"]);
            Assert.IsEmpty(provider.ActionsCache);
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
                Assert.True(result);
            }

            var abandonedMessage = (await client.CreateReceiver(FirstQueueScope.QueueName).ReceiveMessagesAsync(1)).Single();
            Assert.AreEqual("foobar", abandonedMessage.Body.ToString());
            Assert.AreEqual("value", abandonedMessage.ApplicationProperties["key"]);
            Assert.IsEmpty(provider.ActionsCache);
        }

        public class ServiceBusBindToMessageAndComplete
        {
            internal static SettlementService SettlementService { get; set; }
            public static async Task BindToMessage(
                [ServiceBusTrigger(FirstQueueNameKey)] ServiceBusReceivedMessage message)
            {
                Assert.AreEqual("foobar", message.Body.ToString());
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
                Assert.AreEqual("foobar", message.Body.ToString());
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
                Assert.AreEqual("foobar", message.Body.ToString());
                await SettlementService.Deadletter(
                    new DeadletterRequest()
                    {
                        Locktoken = message.LockToken,
                        DeadletterErrorDescription = "description",
                        DeadletterReason = "reason",
                        PropertiesToModify = {{ "key", new SettlementProperties { IntValue = 42} }}
                    },
                    new MockServerCallContext());

                var receiver = client.CreateReceiver(FirstQueueScope.QueueName, new ServiceBusReceiverOptions {SubQueue = SubQueue.DeadLetter});
                var deadletterMessage = await receiver.ReceiveMessageAsync();
                Assert.AreEqual("foobar", deadletterMessage.Body.ToString());
                Assert.AreEqual("description", deadletterMessage.DeadLetterErrorDescription);
                Assert.AreEqual("reason", deadletterMessage.DeadLetterReason);
                Assert.AreEqual(42, deadletterMessage.ApplicationProperties["key"]);
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

                Assert.AreEqual("foobar", message.Body.ToString());
                await SettlementService.Deadletter(
                    new DeadletterRequest()
                    {
                        Locktoken = message.LockToken,
                        DeadletterErrorDescription = "description",
                        DeadletterReason = "reason",
                        PropertiesToModify = { { "key", new SettlementProperties { IntValue = 42 } } }
                    },
                    new MockServerCallContext());

                var receiver = client.CreateReceiver(FirstQueueScope.QueueName,
                    new ServiceBusReceiverOptions { SubQueue = SubQueue.DeadLetter });
                var deadletterMessage = await receiver.ReceiveMessageAsync();
                Assert.AreEqual("foobar", deadletterMessage.Body.ToString());
                Assert.AreEqual("description", deadletterMessage.DeadLetterErrorDescription);
                Assert.AreEqual("reason", deadletterMessage.DeadLetterReason);
                Assert.AreEqual(42, deadletterMessage.ApplicationProperties["key"]);
                _waitHandle1.Set();
            }
        }

        public class ServiceBusBindToMessageAndDefer
        {
            internal static SettlementService SettlementService { get; set; }
            public static async Task BindToMessage(
                [ServiceBusTrigger(FirstQueueNameKey)] ServiceBusReceivedMessage message, ServiceBusReceiveActions receiveActions)
            {
                Assert.AreEqual("foobar", message.Body.ToString());
                await SettlementService.Defer(
                    new DeferRequest
                    {
                        Locktoken = message.LockToken,
                        PropertiesToModify = {{ "key", new SettlementProperties { BoolValue = true} }}
                    },
                    new MockServerCallContext());
                var deferredMessage = (await receiveActions.ReceiveDeferredMessagesAsync(
                    new[] { message.SequenceNumber })).Single();
                Assert.AreEqual("foobar", deferredMessage.Body.ToString());
                Assert.IsTrue((bool)deferredMessage.ApplicationProperties["key"]);
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

                Assert.AreEqual("foobar", message.Body.ToString());
                await SettlementService.Defer(
                    new DeferRequest
                    {
                        Locktoken = message.LockToken,
                        PropertiesToModify = {{ "key", new SettlementProperties { BoolValue = true} }}
                    },
                    new MockServerCallContext());
                var deferredMessage = (await receiveActions.ReceiveDeferredMessagesAsync(
                    new[] { message.SequenceNumber })).Single();
                Assert.AreEqual("foobar", deferredMessage.Body.ToString());
                Assert.IsTrue((bool)deferredMessage.ApplicationProperties["key"]);
                _waitHandle1.Set();
            }
        }

        public class ServiceBusBindToMessageAndAbandon
        {
            internal static SettlementService SettlementService { get; set; }
            public static async Task BindToMessage(
                [ServiceBusTrigger(FirstQueueNameKey)] ServiceBusReceivedMessage message, ServiceBusReceiveActions receiveActions)
            {
                Assert.AreEqual("foobar", message.Body.ToString());
                await SettlementService.Abandon(
                    new AbandonRequest
                    {
                        Locktoken = message.LockToken,
                        PropertiesToModify = {{ "key", new SettlementProperties { StringValue = "value"} }}
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

                Assert.AreEqual("foobar", message.Body.ToString());
                await SettlementService.Abandon(
                    new AbandonRequest
                    {
                        Locktoken = message.LockToken,
                        PropertiesToModify = {{ "key", new SettlementProperties { StringValue = "value"} }}
                    },
                    new MockServerCallContext());
                _waitHandle1.Set();
            }
        }

        internal class MockServerCallContext : ServerCallContext
        {
            protected override Task WriteResponseHeadersAsyncCore(Metadata responseHeaders)
            {
                throw new NotImplementedException();
            }

            protected override ContextPropagationToken CreatePropagationTokenCore(ContextPropagationOptions options)
            {
                throw new NotImplementedException();
            }

            protected override string MethodCore { get; }
            protected override string HostCore { get; }
            protected override string PeerCore { get; }
            protected override DateTime DeadlineCore { get; }
            protected override Metadata RequestHeadersCore { get; }
            protected override CancellationToken CancellationTokenCore { get; } = CancellationToken.None;
            protected override Metadata ResponseTrailersCore { get; }
            protected override Status StatusCore { get; set; }
            protected override WriteOptions WriteOptionsCore { get; set; }
            protected override AuthContext AuthContextCore { get; }
        }
    }
}
#endif