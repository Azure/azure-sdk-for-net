// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if NET6_0_OR_GREATER
using System;
using System.Collections.Generic;
using System.IO.Hashing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Tests;
using Google.Protobuf;
using Grpc.Core;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.ServiceBus.Grpc;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Grpc;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;
using static System.Net.Mime.MediaTypeNames;

namespace Microsoft.Azure.WebJobs.Host.EndToEndTests
{
    public class ServiceBusGrpcSessionEndToEndTests : ServiceBusGrpcEndToEndTestsBase
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
            Assert.AreEqual(ServiceBusBindToSessionMessageAndAbandon.TimeSpan, abandonedMessage.ApplicationProperties["timespan"]);
            Assert.AreEqual(ServiceBusBindToSessionMessageAndAbandon.Uri, abandonedMessage.ApplicationProperties["uri"]);
            Assert.That(abandonedMessage.ApplicationProperties["datetime"], Is.EqualTo(ServiceBusBindToSessionMessageAndAbandon.DateTimeNow).Within(TimeSpan.FromMilliseconds(1)));
            Assert.That(abandonedMessage.ApplicationProperties["datetimeoffset"], Is.EqualTo(ServiceBusBindToSessionMessageAndAbandon.DateTimeOffsetNow).Within(TimeSpan.FromMilliseconds(1)));
            Assert.AreEqual(ServiceBusBindToSessionMessageAndAbandon.Guid, abandonedMessage.ApplicationProperties["guid"]);
            Assert.IsEmpty(provider.ActionsCache);
        }

        [Test]
        public async Task BindToSessionMessageAndSetAndGet()
        {
            var host = BuildHost<ServiceBusBindToSessionMessageAndSetAndGet>();
            var settlementImpl = host.Services.GetRequiredService<SettlementService>();
            var provider = host.Services.GetRequiredService<MessagingProvider>();
            ServiceBusBindToSessionMessageAndSetAndGet.SettlementService = settlementImpl;
            await using ServiceBusClient client = new ServiceBusClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);

            using (host)
            {
                var message = new ServiceBusMessage("foobar") { SessionId = "sessionId" };
                var sender = client.CreateSender(FirstQueueScope.QueueName);
                await sender.SendMessageAsync(message);

                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.True(result);
            }
        }

        [Test]
        public async Task BindToSessionMessageAndSetAndGetBinaryData()
        {
            var host = BuildHost<ServiceBusBindToSessionMessageAndSetAndGetBinaryData>();
            var settlementImpl = host.Services.GetRequiredService<SettlementService>();
            var provider = host.Services.GetRequiredService<MessagingProvider>();
            ServiceBusBindToSessionMessageAndSetAndGetBinaryData.SettlementService = settlementImpl;
            await using ServiceBusClient client = new ServiceBusClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);

            using (host)
            {
                byte[] predefinedData = { 0x48, 0x65 };
                var message = new ServiceBusMessage(BinaryData.FromBytes(predefinedData)) { SessionId = "sessionId" };
                var sender = client.CreateSender(FirstQueueScope.QueueName);
                await sender.SendMessageAsync(message);

                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.True(result);
            }
        }

        [Test]
        public async Task BindToSessionMessageAndReleaseSession()
        {
            var host = BuildHost<ServiceBusBindToSessionMessageAndReleaseSession>();
            var settlementImpl = host.Services.GetRequiredService<SettlementService>();
            var provider = host.Services.GetRequiredService<MessagingProvider>();
            ServiceBusBindToSessionMessageAndReleaseSession.SettlementService = settlementImpl;
            await using ServiceBusClient client = new ServiceBusClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);

            using (host)
            {
                var message = new ServiceBusMessage("foobar") { SessionId = "sessionId" };
                var sender = client.CreateSender(FirstQueueScope.QueueName);
                await sender.SendMessageAsync(message);

                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.True(result);
            }
            Assert.IsEmpty(provider.SessionActionsCache);
        }

        [Test]
        public async Task BindToSessionMessageAndRenewSession()
        {
            var host = BuildHost<ServiceBusBindToSessionMessageAndRenewSessionLock>();
            var settlementImpl = host.Services.GetRequiredService<SettlementService>();
            var provider = host.Services.GetRequiredService<MessagingProvider>();
            ServiceBusBindToSessionMessageAndRenewSessionLock.SettlementService = settlementImpl;
            await using ServiceBusClient client = new ServiceBusClient(ServiceBusTestEnvironment.Instance.ServiceBusConnectionString);

            using (host)
            {
                var message = new ServiceBusMessage("foobar") { SessionId = "sessionId" };
                var sender = client.CreateSender(FirstQueueScope.QueueName);
                await sender.SendMessageAsync(message);

                bool result = _waitHandle1.WaitOne(SBTimeoutMills);
                Assert.True(result);
            }
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
                        PropertiesToModify = EncodeDictionary(new Dictionary<string, object> {{ "key", 42}})
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
                        PropertiesToModify = EncodeDictionary(new Dictionary<string, object> {{ "key", true}})
                    },
                    new MockServerCallContext());
                var deferredMessage = (await receiveActions.ReceiveDeferredMessagesAsync(
                    new[] { message.SequenceNumber })).Single();
                Assert.AreEqual("foobar", deferredMessage.Body.ToString());
                Assert.IsTrue((bool)deferredMessage.ApplicationProperties["key"]);
                _waitHandle1.Set();
            }
        }

        public class ServiceBusBindToSessionMessageAndRenewMessageLock
        {
            internal static SettlementService SettlementService { get; set; }
            public static async Task BindToMessage(
                [ServiceBusTrigger(FirstQueueNameKey, IsSessionsEnabled = true)] ServiceBusReceivedMessage message, ServiceBusReceiveActions receiveActions)
            {
                Assert.AreEqual("foobar", message.Body.ToString());
                await SettlementService.RenewMessageLock(
                    new RenewMessageLockRequest
                    {
                        Locktoken = message.LockToken,
                    },
                    new MockServerCallContext());
                _waitHandle1.Set();
            }
        }

        public class ServiceBusBindToSessionMessageAndSetAndGet
        {
            internal static SettlementService SettlementService { get; set; }
            public static async Task BindToMessage(
                [ServiceBusTrigger(FirstQueueNameKey, IsSessionsEnabled = true)] ServiceBusReceivedMessage message, ServiceBusReceiveActions receiveActions)
            {
                Assert.AreEqual("foobar", message.Body.ToString());
                await SettlementService.SetSessionState(
                    new SetSessionStateRequest
                    {
                        SessionId = message.SessionId,
                        SessionState = ByteString.CopyFromUtf8(message.Body.ToString())
                    },
                    new MockServerCallContext()
                 );
                var test = await SettlementService.GetSessionState(
                    new GetSessionStateRequest
                    {
                        SessionId = message.SessionId,
                    },
                    new MockServerCallContext());
                Assert.IsNotEmpty(test.SessionState);
                Assert.AreEqual("foobar", message.Body.ToString());
                _waitHandle1.Set();
            }
        }

        public class ServiceBusBindToSessionMessageAndSetAndGetBinaryData
        {
            internal static SettlementService SettlementService { get; set; }
            public static async Task BindToMessage(
                [ServiceBusTrigger(FirstQueueNameKey, IsSessionsEnabled = true)] ServiceBusReceivedMessage message, ServiceBusReceiveActions receiveActions)
            {
                byte[] predefinedData = { 0x48, 0x65 };
                Assert.AreEqual(predefinedData, message.Body.ToArray());
                await SettlementService.SetSessionState(
                    new SetSessionStateRequest
                    {
                        SessionId = message.SessionId,
                        SessionState = ByteString.CopyFrom(predefinedData)
                    },
                    new MockServerCallContext()
                 );
                var test = await SettlementService.GetSessionState(
                    new GetSessionStateRequest
                    {
                        SessionId = message.SessionId,
                    },
                    new MockServerCallContext());
                Assert.IsNotEmpty(test.SessionState);
                Assert.AreEqual(predefinedData, message.Body.ToArray());
                _waitHandle1.Set();
            }
        }

        public class ServiceBusBindToSessionMessageAndReleaseSession
        {
            internal static SettlementService SettlementService { get; set; }
            public static async Task BindToMessage(
                [ServiceBusTrigger(FirstQueueNameKey, IsSessionsEnabled = true)] ServiceBusReceivedMessage message, ServiceBusReceiveActions receiveActions)
            {
                Assert.AreEqual("foobar", message.Body.ToString());
                await SettlementService.ReleaseSession(
                    new ReleaseSessionRequest
                    {
                        SessionId = message.SessionId
                    },
                    new MockServerCallContext()
                );
                Assert.AreEqual("foobar", message.Body.ToString());
                _waitHandle1.Set();
            }
        }

        public class ServiceBusBindToSessionMessageAndRenewSessionLock
        {
            internal static SettlementService SettlementService { get; set; }
            public static async Task BindToMessage(
                [ServiceBusTrigger(FirstQueueNameKey, IsSessionsEnabled = true)] ServiceBusReceivedMessage message, ServiceBusReceiveActions receiveActions)
            {
                Assert.AreEqual("foobar", message.Body.ToString());
                // Check when the session lock is set to expire
                var lockedUntil = message.LockedUntil;

                // Renew the session lock
                await SettlementService.RenewSessionLock(
                    new RenewSessionLockRequest
                    {
                        SessionId = message.SessionId
                    },
                    new MockServerCallContext()
                );
                _waitHandle1.Set();
            }
        }

        public class ServiceBusBindToSessionMessageAndAbandon
        {
            internal static DateTime DateTimeNow { get; } = DateTime.UtcNow;
            internal static DateTimeOffset DateTimeOffsetNow { get; } = DateTimeOffset.UtcNow;
            internal static Guid Guid { get; } = Guid.NewGuid();
            internal static Uri Uri { get; } = new Uri("http://nonExistingServiceBusWebsite.com");
            internal static TimeSpan TimeSpan { get; } = TimeSpan.FromSeconds(60);

            internal static SettlementService SettlementService { get; set; }
            public static async Task BindToMessage(
                [ServiceBusTrigger(FirstQueueNameKey, IsSessionsEnabled = true)] ServiceBusReceivedMessage message, ServiceBusReceiveActions receiveActions)
            {
                Assert.AreEqual("foobar", message.Body.ToString());
                await SettlementService.Abandon(
                    new AbandonRequest
                    {
                        Locktoken = message.LockToken,
                        PropertiesToModify = EncodeDictionary(new Dictionary<string, object>
                        {
                            { "timespan", TimeSpan },
                            { "uri", Uri },
                            { "datetime", DateTimeNow },
                            { "datetimeoffset", DateTimeOffsetNow },
                            { "guid", Guid },
                        })
                    },
                    new MockServerCallContext());
                _waitHandle1.Set();
            }
        }
    }
}
#endif