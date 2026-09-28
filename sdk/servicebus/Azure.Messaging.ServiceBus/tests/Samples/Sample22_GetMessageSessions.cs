// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Samples
{
    public class Sample22_GetMessageSessions : ServiceBusLiveTestBase
    {
        [Test]
        public async Task GetMessageSessionsFromQueue()
        {
            await using var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true);
            string expectedSessionId = Guid.NewGuid().ToString();
            await using (var senderClient = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential))
            {
                await using ServiceBusSender sender = senderClient.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(new ServiceBusMessage("message") { SessionId = expectedSessionId });
            }

            #region Snippet:ServiceBusGetMessageSessionsFromQueue
#if SNIPPET
            string fullyQualifiedNamespace = "<fully_qualified_namespace>";
            string queueName = "<queue_name>";
            var credential = new DefaultAzureCredential();
#else
            string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
            string queueName = scope.QueueName;
            var credential = TestEnvironment.Credential;
#endif
            await using ServiceBusClient client = new(fullyQualifiedNamespace, credential);

            var sessionIds = new List<string>();
            await foreach (string sessionId in client.GetMessageSessionsAsync(queueName))
            {
                Console.WriteLine(sessionId);
                sessionIds.Add(sessionId);
            }
            #endregion

            Assert.That(sessionIds, Does.Contain(expectedSessionId));
        }

        [Test]
        public async Task GetMessageSessionsFromSubscription()
        {
            await using var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: true);
            string expectedSessionId = Guid.NewGuid().ToString();
            await using (var senderClient = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential))
            {
                await using ServiceBusSender sender = senderClient.CreateSender(scope.TopicName);
                await sender.SendMessageAsync(new ServiceBusMessage("message") { SessionId = expectedSessionId });
            }

            #region Snippet:ServiceBusGetMessageSessionsFromSubscription
#if SNIPPET
            string fullyQualifiedNamespace = "<fully_qualified_namespace>";
            string topicName = "<topic_name>";
            string subscriptionName = "<subscription_name>";
            var credential = new DefaultAzureCredential();
#else
            string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
            string topicName = scope.TopicName;
            string subscriptionName = scope.SubscriptionNames.First();
            var credential = TestEnvironment.Credential;
#endif
            await using ServiceBusClient client = new(fullyQualifiedNamespace, credential);

            var sessionIds = new List<string>();
            await foreach (string sessionId in client.GetMessageSessionsAsync(topicName, subscriptionName))
            {
                Console.WriteLine(sessionId);
                sessionIds.Add(sessionId);
            }
            #endregion

            Assert.That(sessionIds, Does.Contain(expectedSessionId));
        }

        [Test]
        public async Task GetMessageSessionsUpdatedAfter()
        {
            await using var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true);
            string expectedSessionId = Guid.NewGuid().ToString();
            await using (var stateClient = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential))
            {
                await using ServiceBusSender sender = stateClient.CreateSender(scope.QueueName);
                await sender.SendMessageAsync(new ServiceBusMessage("message") { SessionId = expectedSessionId });
                await using ServiceBusSessionReceiver receiver = await stateClient.AcceptSessionAsync(scope.QueueName, expectedSessionId);
                await receiver.SetSessionStateAsync(new BinaryData("recent state"));
            }

            #region Snippet:ServiceBusGetMessageSessionsUpdatedAfter
#if SNIPPET
            string fullyQualifiedNamespace = "<fully_qualified_namespace>";
            string queueName = "<queue_name>";
            var credential = new DefaultAzureCredential();
#else
            string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
            string queueName = scope.QueueName;
            var credential = TestEnvironment.Credential;
#endif
            await using ServiceBusClient client = new(fullyQualifiedNamespace, credential);

            DateTimeOffset stateUpdatedAfter = DateTimeOffset.UtcNow.AddDays(-7);

            var sessionIds = new List<string>();
            await foreach (string sessionId in client.GetMessageSessionsAsync(queueName, stateUpdatedAfter))
            {
                Console.WriteLine(sessionId);
                sessionIds.Add(sessionId);
            }
            #endregion

            Assert.That(sessionIds, Does.Contain(expectedSessionId));
        }
    }
}
