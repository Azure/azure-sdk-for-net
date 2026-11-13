// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Samples
{
    public class Sample22_GetMessageSessions
    {
        [Test]
        public async Task GetMessageSessionsFromQueue()
        {
#if !SNIPPET
            Mock<ServiceBusClient> mockClient = new();
            mockClient
                .Setup(client => client.GetMessageSessionsAsync("queue", It.IsAny<CancellationToken>()))
                .Returns(GetSessions());
            List<string> received = new();
#endif
            #region Snippet:ServiceBusGetMessageSessionsFromQueue
#if SNIPPET
            string fullyQualifiedNamespace = "<fully_qualified_namespace>";
            string queueName = "<queue_name>";

            await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
            string queueName = "queue";
            ServiceBusClient client = mockClient.Object;
#endif

            await foreach (string sessionId in client.GetMessageSessionsAsync(queueName))
            {
                Console.WriteLine(sessionId);
#if !SNIPPET
                received.Add(sessionId);
#endif
            }
            #endregion
#if !SNIPPET
            Assert.That(received, Is.EqualTo(new[] { "session-1" }));
            mockClient.Verify(client => client.GetMessageSessionsAsync(queueName, It.IsAny<CancellationToken>()), Times.Once);
#endif
        }

        [Test]
        public async Task GetMessageSessionsFromSubscription()
        {
#if !SNIPPET
            Mock<ServiceBusClient> mockClient = new();
            mockClient
                .Setup(client => client.GetMessageSessionsAsync("topic", "subscription", It.IsAny<CancellationToken>()))
                .Returns(GetSessions());
            List<string> received = new();
#endif
            #region Snippet:ServiceBusGetMessageSessionsFromSubscription
#if SNIPPET
            string fullyQualifiedNamespace = "<fully_qualified_namespace>";
            string topicName = "<topic_name>";
            string subscriptionName = "<subscription_name>";

            await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
            string topicName = "topic";
            string subscriptionName = "subscription";
            ServiceBusClient client = mockClient.Object;
#endif

            await foreach (string sessionId in client.GetMessageSessionsAsync(topicName, subscriptionName))
            {
                Console.WriteLine(sessionId);
#if !SNIPPET
                received.Add(sessionId);
#endif
            }
            #endregion
#if !SNIPPET
            Assert.That(received, Is.EqualTo(new[] { "session-1" }));
            mockClient.Verify(client => client.GetMessageSessionsAsync(topicName, subscriptionName, It.IsAny<CancellationToken>()), Times.Once);
#endif
        }

        [Test]
        public async Task GetMessageSessionsUpdatedAfter()
        {
#if !SNIPPET
            Mock<ServiceBusClient> mockClient = new();
            mockClient
                .Setup(client => client.GetMessageSessionsAsync("queue", It.IsAny<DateTimeOffset>(), It.IsAny<CancellationToken>()))
                .Returns(GetSessions());
            List<string> received = new();
#endif
            #region Snippet:ServiceBusGetMessageSessionsUpdatedAfter
#if SNIPPET
            string fullyQualifiedNamespace = "<fully_qualified_namespace>";
            string queueName = "<queue_name>";

            await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
            string queueName = "queue";
            ServiceBusClient client = mockClient.Object;
#endif

            DateTimeOffset stateUpdatedAfter = DateTimeOffset.UtcNow.AddDays(-7);

            await foreach (string sessionId in client.GetMessageSessionsAsync(queueName, stateUpdatedAfter))
            {
                Console.WriteLine(sessionId);
#if !SNIPPET
                received.Add(sessionId);
#endif
            }
            #endregion
#if !SNIPPET
            Assert.That(received, Is.EqualTo(new[] { "session-1" }));
            mockClient.Verify(client => client.GetMessageSessionsAsync(queueName, stateUpdatedAfter, It.IsAny<CancellationToken>()), Times.Once);
#endif
        }

        private static async IAsyncEnumerable<string> GetSessions()
        {
            await Task.Yield();
            yield return "session-1";
        }
    }
}
