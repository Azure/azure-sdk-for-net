// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Samples
{
    public class Sample17_BatchDelete : ServiceBusLiveTestBase
    {
        [Test]
        public async Task PurgeMessages()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                #region Snippet:ServiceBusPurgeMessages
#if SNIPPET
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string queueName = "<queue_name>";
                await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
                string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
                string queueName = scope.QueueName;
                await using ServiceBusClient client = new(fullyQualifiedNamespace, TestEnvironment.Credential);
#endif
                await using ServiceBusReceiver receiver = client.CreateReceiver(queueName);

#if !SNIPPET
                await SendMessagesAsync(client, queueName, 100);
#endif
                // Delete all eligible messages in 500-message batches.
                PurgeMessagesResult result = await receiver.PurgeMessagesAsync();
                Console.WriteLine($"The service purged {result.DeletedCount} messages.");
                #endregion
            }
        }

        [Test]
        public async Task PurgeMessagesWithPremiumBatchSize()
        {
#if !SNIPPET
            Assert.Ignore("This sample requires a Premium namespace.");
#endif
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                #region Snippet:ServiceBusPurgeMessagesWithPremiumBatchSize
#if SNIPPET
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string queueName = "<queue_name>";
                await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
                string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
                string queueName = scope.QueueName;
                await using ServiceBusClient client = new(fullyQualifiedNamespace, TestEnvironment.Credential);
#endif
                int maxMessagesPerBatch = 4000;
                await using ServiceBusReceiver receiver = client.CreateReceiver(queueName);

#if !SNIPPET
                await SendMessagesAsync(client, queueName, 100);
#endif
                DateTimeOffset enqueueTimeThreshold = DateTimeOffset.UtcNow;

                // Premium supports up to 4,000 messages per request.
                PurgeMessagesResult result = await receiver.PurgeMessagesAsync(maxMessagesPerBatch, enqueueTimeThreshold);
                Console.WriteLine($"Purged {result.DeletedCount} messages enqueued before {enqueueTimeThreshold:O}.");
                #endregion
            }
        }

        [Test]
        public async Task PurgeMessagesFromSession()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: true))
            {
                #region Snippet:ServiceBusPurgeMessagesFromSession
#if SNIPPET
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string queueName = "<queue_name>";
                string sessionId = "<session_id>";
                await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
                string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
                string queueName = scope.QueueName;
                string sessionId = "session-1";
                await using ServiceBusClient client = new(fullyQualifiedNamespace, TestEnvironment.Credential);
#endif
#if !SNIPPET
                await using ServiceBusSender sender = client.CreateSender(queueName);
                await sender.SendMessageAsync(new ServiceBusMessage("session message") { SessionId = sessionId });
#endif
                await using ServiceBusSessionReceiver sessionReceiver = await client.AcceptSessionAsync(queueName, sessionId);
                PurgeMessagesResult result = await sessionReceiver.PurgeMessagesAsync();
                Console.WriteLine($"Removed {result.DeletedCount} messages from session {sessionId}.");
                #endregion
            }
        }

        [Test]
        public async Task PurgeMessagesByDate()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                #region Snippet:ServiceBusPurgeMessagesByDate
#if SNIPPET
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string queueName = "<queue_name>";;
                await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
                string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
                string queueName = scope.QueueName;
                await using ServiceBusClient client = new(fullyQualifiedNamespace, TestEnvironment.Credential);
#endif
                await using ServiceBusReceiver receiver = client.CreateReceiver(queueName);

#if !SNIPPET
                await SendMessagesAsync(client, queueName, 100);
#endif
                // Delete all messages in the queue that were enqueued more than a year ago.
                DateTimeOffset deleteBefore = DateTimeOffset.UtcNow.AddYears(-1);
                long numberOfMessagesDeleted = (await receiver.PurgeMessagesAsync(deleteBefore)).DeletedCount;
                #endregion
            }
        }

        [Test]
        public async Task DeleteMessages()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                #region Snippet:ServiceBusDeleteMessages
#if SNIPPET
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string queueName = "<queue_name>";
                await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
                string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
                string queueName = scope.QueueName;
                await using ServiceBusClient client = new(fullyQualifiedNamespace, TestEnvironment.Credential);
#endif
                await using ServiceBusReceiver receiver = client.CreateReceiver(queueName);

#if !SNIPPET
                await SendMessagesAsync(client, queueName, 100);
#endif
                // Large messages can cause the returned count to be lower than the requested count.
                int requestedCount = 50;
                DeleteMessagesResult result = await receiver.DeleteMessagesAsync(requestedCount);
                Console.WriteLine($"Requested {requestedCount}; the service deleted {result.DeletedCount}.");
                #endregion
            }
        }

        [Test]
        public async Task DeleteMessagesByDate()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                #region Snippet:ServiceBusDeleteMessagesByDate
#if SNIPPET
                string fullyQualifiedNamespace = "<fully_qualified_namespace>";
                string queueName = "<queue_name>";
                await using ServiceBusClient client = new(fullyQualifiedNamespace, new DefaultAzureCredential());
#else
                string fullyQualifiedNamespace = TestEnvironment.FullyQualifiedNamespace;
                string queueName = scope.QueueName;
                await using ServiceBusClient client = new(fullyQualifiedNamespace, TestEnvironment.Credential);
#endif
                await using ServiceBusReceiver receiver = client.CreateReceiver(queueName);

#if !SNIPPET
                await SendMessagesAsync(client, queueName, 100);
#endif
                // Delete the oldest 50 messages in the queue which were enqueued
                // more than a month ago.
                int maxBatchSize = 50;
                DateTimeOffset deleteBefore = DateTimeOffset.UtcNow.AddMonths(-1);

                int numberOfMessagesDeleted = (await receiver.DeleteMessagesAsync(maxBatchSize, deleteBefore)).DeletedCount;
                #endregion
            }
        }
    }
}
