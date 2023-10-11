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
    public class ServiceBusGrpcSessionEndToEndTests : WebJobsServiceBusTestBase
    {
        public ServiceBusGrpcSessionEndToEndTests() : base(isSession: true)
        {
        }

        [Test]
        public async Task BindToSessionMessageAndComplete()
        {
            var host = BuildHost<ServiceBusBindToSessionMessageAndComplete>();
            var settlementImpl = host.Services.GetRequiredService<SettlementService>();
            var provider = host.Services.GetRequiredService<MessagingProvider>();
            ServiceBusBindToSessionMessageAndComplete.SettlementService = settlementImpl;

            using (host)
            {
                var message = new ServiceBusMessage("foobar") {SessionId = "sessionId"};
                await using ServiceBusClient client = new ServiceBusClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);
                var sender = client.CreateSender(FirstQueueScope.QueueName);
                await sender.SendMessageAsync(message);

                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.True(result);
            }
            Assert.IsEmpty(provider.ActionsCache);
        }

        [Test]
        public async Task BindToSessionBatchAndComplete()
        {
            var host = BuildHost<ServiceBusBindToSessionBatchAndComplete>();
            var settlementImpl = host.Services.GetRequiredService<SettlementService>();
            var provider = host.Services.GetRequiredService<MessagingProvider>();
            ServiceBusBindToSessionBatchAndComplete.SettlementService = settlementImpl;

            using (host)
            {
                var message = new ServiceBusMessage("foobar") {SessionId = "sessionId"};
                await using ServiceBusClient client = new ServiceBusClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);
                var sender = client.CreateSender(FirstQueueScope.QueueName);
                await sender.SendMessageAsync(message);

                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.True(result);
            }
            Assert.IsEmpty(provider.ActionsCache);
        }

        [Test]
        public async Task BindToSessionMessageAndDeadletter()
        {
            var host = BuildHost<ServiceBusBindToSessionMessageAndDeadletter>();
            var settlementImpl = host.Services.GetRequiredService<SettlementService>();
            var provider = host.Services.GetRequiredService<MessagingProvider>();
            ServiceBusBindToSessionMessageAndDeadletter.SettlementService = settlementImpl;

            using (host)
            {
                var message = new ServiceBusMessage("foobar") {SessionId = "sessionId"};
                await using ServiceBusClient client = new ServiceBusClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);
                var sender = client.CreateSender(FirstQueueScope.QueueName);
                await sender.SendMessageAsync(message);

                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.True(result);
            }
            Assert.IsEmpty(provider.ActionsCache);
        }

        [Test]
        public async Task BindToSessionMessageAndDefer()
        {
            var host = BuildHost<ServiceBusBindToSessionMessageAndDefer>();
            var settlementImpl = host.Services.GetRequiredService<SettlementService>();
            var provider = host.Services.GetRequiredService<MessagingProvider>();
            ServiceBusBindToSessionMessageAndDefer.SettlementService = settlementImpl;

            using (host)
            {
                var message = new ServiceBusMessage("foobar") {SessionId = "sessionId"};
                await using ServiceBusClient client = new ServiceBusClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);
                var sender = client.CreateSender(FirstQueueScope.QueueName);
                await sender.SendMessageAsync(message);

                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.True(result);
            }
            Assert.IsEmpty(provider.ActionsCache);
        }

        [Test]
        public async Task BindToSessionMessageAndAbandon()
        {
            var host = BuildHost<ServiceBusBindToSessionMessageAndAbandon>();
            var settlementImpl = host.Services.GetRequiredService<SettlementService>();
            var provider = host.Services.GetRequiredService<MessagingProvider>();
            ServiceBusBindToSessionMessageAndAbandon.SettlementService = settlementImpl;
            await using ServiceBusClient client = new ServiceBusClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);

            using (host)
            {
                var message = new ServiceBusMessage("foobar") {SessionId = "sessionId"};
                var sender = client.CreateSender(FirstQueueScope.QueueName);
                await sender.SendMessageAsync(message);

                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.True(result);
            }

            var receiver = await client.AcceptNextSessionAsync(FirstQueueScope.QueueName);
            var abandonedMessage = (await receiver.ReceiveMessagesAsync(1)).Single();
            Assert.AreEqual("foobar", abandonedMessage.Body.ToString());
            Assert.AreEqual("value", abandonedMessage.ApplicationProperties["key"]);
            Assert.IsEmpty(provider.ActionsCache);
        }

        public class ServiceBusBindToSessionMessageAndComplete
        {
            internal static SettlementService SettlementService { get; set; }
            public static async Task BindToMessage(
                [ServiceBusTrigger(FirstQueueNameKey, IsSessionsEnabled = true)] ServiceBusReceivedMessage message)
            {
                Assert.AreEqual("foobar", message.Body.ToString());
                await SettlementService.Complete(new CompleteRequest() { Locktoken = message.LockToken }, new MockServerCallContext());
                _waitHandle1.Set();
            }
        }

        public class ServiceBusBindToSessionBatchAndComplete
        {
            internal static SettlementService SettlementService { get; set; }
            public static async Task BindToMessage(
                [ServiceBusTrigger(FirstQueueNameKey, IsSessionsEnabled = true)] ServiceBusReceivedMessage[] messages)
            {
                var message = messages.Single();
                Assert.AreEqual("foobar", message.Body.ToString());
                await SettlementService.Complete(new CompleteRequest() { Locktoken = message.LockToken }, new MockServerCallContext());
                _waitHandle1.Set();
            }
        }

        public class ServiceBusBindToSessionMessageAndDeadletter
        {
            internal static SettlementService SettlementService { get; set; }
            public static async Task BindToMessage(
                [ServiceBusTrigger(FirstQueueNameKey, IsSessionsEnabled = true)] ServiceBusReceivedMessage message, ServiceBusClient client)
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

        public class ServiceBusBindToSessionMessageAndDefer
        {
            internal static SettlementService SettlementService { get; set; }
            public static async Task BindToMessage(
                [ServiceBusTrigger(FirstQueueNameKey, IsSessionsEnabled = true)] ServiceBusReceivedMessage message, ServiceBusReceiveActions receiveActions)
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

        public class ServiceBusBindToSessionMessageAndAbandon
        {
            internal static SettlementService SettlementService { get; set; }
            public static async Task BindToMessage(
                [ServiceBusTrigger(FirstQueueNameKey, IsSessionsEnabled = true)] ServiceBusReceivedMessage message, ServiceBusReceiveActions receiveActions)
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