// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Azure.Storage.Test;
using NUnit.Framework;

#pragma warning disable CA2007
#pragma warning disable IDE0007
#pragma warning disable IDE0059 // Value assigned to symbol is never used.  Keeping all these for the sake of the sample.

namespace Azure.Storage.Samples
{
    [TestFixture]
    public partial class QueueSamples
    {
        [Test]
        [Category("Live")]
        public async Task QueueSample()
        {
            // Instantiate a new QueueServiceClient using a connection string.
            QueueServiceClient queueServiceClient = new QueueServiceClient(TestConfigurations.DefaultTargetTenant.ConnectionString);

            // Instantiate a new QueueClient
            QueueClient queueClient = queueServiceClient.GetQueueClient($"myqueue-{Guid.NewGuid()}");
            try
            {
                // Create your new Queue in the service
                await queueClient.CreateAsync();

                // List Queues
                await foreach (QueueItem queue in queueServiceClient.GetQueuesAsync())
                {
                    Console.WriteLine(queue.Name);
                }
            }
            finally
            {
                // Delete your Queue in the service
                await queueClient.DeleteAsync();
            }
        }

        [Test]
        [Category("Live")]
        public async Task MessageSample()
        {
            // Instantiate a new QueueServiceClient using a connection string.
            QueueServiceClient queueServiceClient = new QueueServiceClient(TestConfigurations.DefaultTargetTenant.ConnectionString);

            // Instantiate a new QueueClient
            QueueClient queueClient = queueServiceClient.GetQueueClient($"myqueue2-{Guid.NewGuid()}");
            try
            {
                // Create your new Queue in the service
                await queueClient.CreateAsync();

                // Instantiate a new MessagesClient
                // Enqueue a message to the queue
                Response<EnqueuedMessage> enqueueResponse = await queueClient.EnqueueMessageAsync("my message");

                // Peek message
                Response<IEnumerable<PeekedMessage>> peekResponse = await queueClient.PeekMessagesAsync();

                // Update message
                await queueClient.UpdateMessageAsync("new message", enqueueResponse.Value.MessageId, enqueueResponse.Value.PopReceipt);

                // Dequeue message
                Response<IEnumerable<DequeuedMessage>> dequeueResponse = await queueClient.DequeueMessagesAsync();

                // Delete Message
                await queueClient.DeleteMessageAsync(enqueueResponse.Value.MessageId, dequeueResponse.Value.First().PopReceipt);
            }
            finally
            {
                // Delete your Queue in the service
                await queueClient.DeleteAsync();
            }
        }
    }
}

#pragma warning restore CA2007
#pragma warning restore IDE0007
#pragma warning restore IDE0059
