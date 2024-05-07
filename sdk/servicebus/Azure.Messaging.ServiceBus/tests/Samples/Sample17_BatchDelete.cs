// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
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
                string connectionString = "<connection_string>";
                string queueName = "<queue_name>";
#else
                string connectionString = TestEnvironment.ServiceBusConnectionString;
                string queueName = scope.QueueName;
#endif

                await using var client = new ServiceBusClient(connectionString);
                await using var receiver = client.CreateReceiver(queueName);

#if !SNIPPET
                await SendMessagesAsync(client, queueName, 100);
#endif
                // Delete all messages in the queue.
                int numberOfMessagesDeleted = await receiver.PurgeMessagesAsync();
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
                string connectionString = "<connection_string>";
                string queueName = "<queue_name>";
#else
                string connectionString = TestEnvironment.ServiceBusConnectionString;
                string queueName = scope.QueueName;
#endif

                await using var client = new ServiceBusClient(connectionString);
                await using var receiver = client.CreateReceiver(queueName);

#if !SNIPPET
                await SendMessagesAsync(client, queueName, 100);
#endif
                // Delete all messages in the queue that were enqueued more than a year ago.
                DateTimeOffset deleteBefore = DateTimeOffset.UtcNow.AddYears(-1);
                int numberOfMessagesDeleted = await receiver.PurgeMessagesAsync(deleteBefore);
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
                string connectionString = "<connection_string>";
                string queueName = "<queue_name>";
#else
                string connectionString = TestEnvironment.ServiceBusConnectionString;
                string queueName = scope.QueueName;
#endif

                await using var client = new ServiceBusClient(connectionString);
                await using var receiver = client.CreateReceiver(queueName);

#if !SNIPPET
                await SendMessagesAsync(client, queueName, 100);
#endif
                // Delete the oldest 50 messages in the queue.
                int maxBatchSize = 50;
                int numberOfMessagesDeleted = await receiver.DeleteMessagesAsync(maxBatchSize);
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
                string connectionString = "<connection_string>";
                string queueName = "<queue_name>";
#else
                string connectionString = TestEnvironment.ServiceBusConnectionString;
                string queueName = scope.QueueName;
#endif

                await using var client = new ServiceBusClient(connectionString);
                await using var receiver = client.CreateReceiver(queueName);

#if !SNIPPET
                await SendMessagesAsync(client, queueName, 100);
#endif
                // Delete the oldest 50 messages in the queue which were enqueued
                // more than a month ago.
                int maxBatchSize = 50;
                DateTimeOffset deleteBefore = DateTimeOffset.UtcNow.AddMonths(-1);

                int numberOfMessagesDeleted = await receiver.DeleteMessagesAsync(maxBatchSize, deleteBefore);
                #endregion
            }
        }
    }
}
