// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Client
{
    public class GetMessageSessionsLiveTests : ServiceBusLiveTestBase
    {
        [Test]
        public async Task GetMessageSessions_Queue_ReturnsActiveSessions()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(
                    TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);

                await using var sender = client.CreateSender(scope.QueueName);
                var sessionIds = new[] { "list-test-1", "list-test-2", "list-test-3" };

                // Send a message to each session
                foreach (var sessionId in sessionIds)
                {
                    await sender.SendMessageAsync(new ServiceBusMessage($"msg for {sessionId}")
                    {
                        SessionId = sessionId
                    });
                }

                // List sessions with active messages
                var result = new List<string>();
                await foreach (var s in client.GetMessageSessionsAsync(scope.QueueName))
                {
                    result.Add(s);
                }

                Assert.IsNotNull(result);
                foreach (var id in sessionIds)
                {
                    Assert.That(result, Does.Contain(id));
                }
            }
        }

        [Test]
        public async Task GetMessageSessions_Queue_EmptyReturnsEmpty()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(
                    TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);

                // No messages sent; should return empty
                var result = new List<string>();
                await foreach (var s in client.GetMessageSessionsAsync(scope.QueueName))
                {
                    result.Add(s);
                }

                Assert.IsNotNull(result);
                Assert.IsEmpty(result);
            }
        }

        [Test]
        public async Task GetMessageSessions_Subscription_ReturnsActiveSessions()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(
                enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(
                    TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);

                await using var sender = client.CreateSender(scope.TopicName);
                var sessionIds = new[] { "sub-session-1", "sub-session-2" };

                foreach (var sessionId in sessionIds)
                {
                    await sender.SendMessageAsync(new ServiceBusMessage($"msg for {sessionId}")
                    {
                        SessionId = sessionId
                    });
                }

                var result = new List<string>();
                await foreach (var s in client.GetMessageSessionsAsync(
                    scope.TopicName, scope.SubscriptionNames.First()))
                {
                    result.Add(s);
                }

                Assert.IsNotNull(result);
                foreach (var id in sessionIds)
                {
                    Assert.That(result, Does.Contain(id));
                }
            }
        }

        [Test]
        public async Task GetMessageSessions_WithUpdatedAfter()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(
                enablePartitioning: false, enableSession: true))
            {
                await using var client = new ServiceBusClient(
                    TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);

                // Capture the filter timestamp slightly in the past so the service-side
                // "updated after" filter is safely earlier than the session state update
                // time, even when service timestamp resolution or rounding is coarse.
                var beforeSend = DateTimeOffset.UtcNow.AddSeconds(-5);
                var sessionId = "time-filter-session";

                await using var sender = client.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(new ServiceBusMessage("time-filtered msg")
                {
                    SessionId = sessionId
                });

                // The service-side filter is "session state updated after <timestamp>",
                // so explicitly update the session state. Sending a message alone does
                // not necessarily register as a session state update on every entity.
                await using (ServiceBusSessionReceiver receiver = await client.AcceptSessionAsync(
                    scope.QueueName, sessionId))
                {
                    await receiver.SetSessionStateAsync(new BinaryData("updated-state"));
                }

                var result = new List<string>();
                await foreach (var s in client.GetMessageSessionsAsync(
                    scope.QueueName, beforeSend))
                {
                    result.Add(s);
                }

                Assert.IsNotNull(result);
                Assert.That(result, Does.Contain(sessionId));
            }
        }
    }
}
