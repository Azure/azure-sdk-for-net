// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Messaging.ServiceBus.Administration;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Samples
{
    public class Sample21_AutoForwardIntoSession : ServiceBusLiveTestBase
    {
        [Test]
        public async Task AutoForwardIntoSessionQueue()
        {
            string adminTopicName = Guid.NewGuid().ToString("D").Substring(0, 8);
            string adminSubscriptionName = Guid.NewGuid().ToString("D").Substring(0, 8);
            string adminQueueName = Guid.NewGuid().ToString("D").Substring(0, 8);
            string adminFullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;

            try
            {
                #region Snippet:ServiceBusAutoForwardIntoSessionQueue
#if SNIPPET
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string topicName = "<topic_name>";
                string subscriptionName = "<subscription_name>";
                string queueName = "<session_queue_name>";

                var adminClient = new ServiceBusAdministrationClient(fullyQualifiedNamespace, new DefaultAzureCredential());
                await using var client = new ServiceBusClient(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
                string fullyQualifiedNamespace = adminFullyQualifiedNamespace;
                string topicName = adminTopicName;
                string subscriptionName = adminSubscriptionName;
                string queueName = adminQueueName;

                var adminClient = new ServiceBusAdministrationClient(fullyQualifiedNamespace, TestEnvironment.Credential);
                await using var client = new ServiceBusClient(fullyQualifiedNamespace, TestEnvironment.Credential);
#endif
                // The destination is a session-enabled queue. Consumers read it with a
                // session receiver, which gives them per-session FIFO ordering and lets
                // the messages live in the queue's own storage instead of the topic.
                await adminClient.CreateQueueAsync(new CreateQueueOptions(queueName)
                {
                    RequiresSession = true,
                    EnablePartitioning = false
                });

                // The source is a topic with a regular (non-session) subscription that
                // auto-forwards into the session queue. The subscription is only a
                // conduit - nothing consumes it directly - so it does not need sessions
                // enabled, and a single entity cannot have both RequiresSession and
                // ForwardTo set. SupportOrdering must be enabled on the topic to
                // guarantee that messages reach the subscription in the order they were
                // sent; it defaults to false. Both entities are left non-partitioned,
                // because ordering is only guaranteed for non-partitioned entities.
                await adminClient.CreateTopicAsync(new CreateTopicOptions(topicName)
                {
                    SupportOrdering = true,
                    EnablePartitioning = false
                });
                await adminClient.CreateSubscriptionAsync(new CreateSubscriptionOptions(topicName, subscriptionName)
                {
                    ForwardTo = queueName
                });

                // Send interleaved messages for two sessions. Every message must carry a
                // SessionId: the session ID is preserved across the auto-forward, and a
                // message without one is dead-lettered on the subscription because a
                // session-enabled entity only accepts messages that have a session ID.
                ServiceBusSender sender = client.CreateSender(topicName);
                string[] sessionIds = { "session-1", "session-2" };
                var messages = new List<ServiceBusMessage>();
                for (int i = 0; i < 3; i++)
                {
                    foreach (string sessionId in sessionIds)
                    {
                        messages.Add(new ServiceBusMessage($"message-{i}")
                        {
                            SessionId = sessionId
                        });
                    }
                }
                await sender.SendMessagesAsync(messages);

                // Receive each session on its own session receiver. The receiver holds an
                // exclusive lock on one session and delivers that session's messages in
                // order, even though the two sessions were interleaved on the topic. Each
                // ReceiveMessageAsync waits up to maxWaitTime for the next message (the
                // forward is asynchronous); a null result means it did not arrive in time.
                var received = new List<ServiceBusReceivedMessage>();
                foreach (string sessionId in sessionIds)
                {
                    await using ServiceBusSessionReceiver receiver = await client.AcceptSessionAsync(queueName, sessionId);
                    for (int i = 0; i < 3; i++)
                    {
                        ServiceBusReceivedMessage message = await receiver.ReceiveMessageAsync(maxWaitTime: TimeSpan.FromSeconds(10));
                        if (message == null)
                        {
                            throw new InvalidOperationException(
                                $"Timed out waiting for a message on session '{sessionId}'.");
                        }

                        Console.WriteLine($"{message.SessionId}: {message.Body}");
                        await receiver.CompleteMessageAsync(message);
                        received.Add(message);
                    }
                }
                #endregion

                Assert.AreEqual(6, received.Count);
                foreach (string sessionId in sessionIds)
                {
                    List<ServiceBusReceivedMessage> sessionMessages = received.FindAll(m => m.SessionId == sessionId);
                    Assert.AreEqual(3, sessionMessages.Count);
                    for (int i = 0; i < sessionMessages.Count; i++)
                    {
                        Assert.AreEqual($"message-{i}", sessionMessages[i].Body.ToString());
                    }
                }
            }
            finally
            {
                var cleanup = new ServiceBusAdministrationClient(adminFullyQualifiedNamespace, TestEnvironment.Credential);
                await cleanup.DeleteTopicAsync(adminTopicName);
                await cleanup.DeleteQueueAsync(adminQueueName);
            }
        }
    }
}
