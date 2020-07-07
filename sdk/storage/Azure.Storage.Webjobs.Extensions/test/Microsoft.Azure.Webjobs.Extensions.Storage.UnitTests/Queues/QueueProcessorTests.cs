// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.Storage.Queue;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.FunctionalTests
{
    [Trait("SecretsRequired", "true")]
    public class QueueProcessorTests : IClassFixture<QueueProcessorTests.TestFixture>
    {
        private CloudQueue _queue;
        private CloudQueue _poisonQueue;
        private QueueProcessor _processor;
        private QueuesOptions _queuesOptions;

        public QueueProcessorTests(TestFixture fixture)
        {
            _queue = fixture.Queue;
            _poisonQueue = fixture.PoisonQueue;
            
            _queuesOptions = new QueuesOptions();
            QueueProcessorFactoryContext context = new QueueProcessorFactoryContext(_queue, null, _queuesOptions);
            _processor = new QueueProcessor(context);
        }

        [Fact]
        public void Constructor_DefaultsValues()
        {
            var options = new QueuesOptions
            {
                BatchSize = 32,
                MaxDequeueCount = 2,
                NewBatchThreshold = 100,
                VisibilityTimeout = TimeSpan.FromSeconds(30),
                MaxPollingInterval = TimeSpan.FromSeconds(15)
            };
            QueueProcessorFactoryContext context = new QueueProcessorFactoryContext(_queue, null, options);
            QueueProcessor localProcessor = new QueueProcessor(context);

            Assert.Equal(options.BatchSize, localProcessor.BatchSize);
            Assert.Equal(options.MaxDequeueCount, localProcessor.MaxDequeueCount);
            Assert.Equal(options.NewBatchThreshold, localProcessor.NewBatchThreshold);
            Assert.Equal(options.VisibilityTimeout, localProcessor.VisibilityTimeout);
            Assert.Equal(options.MaxPollingInterval, localProcessor.MaxPollingInterval);
        }

        [Fact]
        public async Task CompleteProcessingMessageAsync_Success_DeletesMessage()
        {
            CloudQueueMessage message = new CloudQueueMessage("Test Message");
            await _queue.AddMessageAsync(message, CancellationToken.None);

            message = await _queue.GetMessageAsync();

            FunctionResult result = new FunctionResult(true);
            await _processor.CompleteProcessingMessageAsync(message, result, CancellationToken.None);

            message = await _queue.GetMessageAsync();
            Assert.Null(message);
        }

        [Fact]
        public async Task CompleteProcessingMessageAsync_FailureWithoutPoisonQueue_DoesNotDeleteMessage()
        {
            CloudQueueMessage message = new CloudQueueMessage("Test Message");
            await _queue.AddMessageAsync(message, CancellationToken.None);

            message = await _queue.GetMessageAsync();
            string id = message.Id;

            FunctionResult result = new FunctionResult(false);
            await _processor.CompleteProcessingMessageAsync(message, result, CancellationToken.None);

            // make the message visible again so we can verify it wasn't deleted
            await _queue.UpdateMessageAsync(message, TimeSpan.Zero, MessageUpdateFields.Visibility);

            message = await _queue.GetMessageAsync();
            Assert.NotNull(message);
            Assert.Equal(id, message.Id);
        }

        [Fact]
        public async Task CompleteProcessingMessageAsync_MaxDequeueCountExceeded_MovesMessageToPoisonQueue()
        {
            QueueProcessorFactoryContext context = new QueueProcessorFactoryContext(_queue, null, _queuesOptions, _poisonQueue);
            QueueProcessor localProcessor = new QueueProcessor(context);

            bool poisonMessageHandlerCalled = false;
            localProcessor.MessageAddedToPoisonQueue += (sender, e) =>
                {
                    Assert.Same(sender, localProcessor);
                    Assert.Same(_poisonQueue, e.PoisonQueue);
                    Assert.NotNull(e.Message);
                    poisonMessageHandlerCalled = true;
                };

            string messageContent = Guid.NewGuid().ToString();
            CloudQueueMessage message = new CloudQueueMessage(messageContent);
            await _queue.AddMessageAsync(message, CancellationToken.None);

            FunctionResult result = new FunctionResult(false);
            for (int i = 0; i < context.MaxDequeueCount; i++)
            {
                message = await _queue.GetMessageAsync();
                await localProcessor.CompleteProcessingMessageAsync(message, result, CancellationToken.None);
            }

            message = await _queue.GetMessageAsync();
            Assert.Null(message);

            CloudQueueMessage poisonMessage = await _poisonQueue.GetMessageAsync();
            Assert.NotNull(poisonMessage);
            Assert.Equal(messageContent, poisonMessage.AsString);
            Assert.True(poisonMessageHandlerCalled);
        }

        [Fact]
        public async Task CompleteProcessingMessageAsync_Failure_AppliesVisibilityTimeout()
        {
            var queuesOptions = new QueuesOptions
            {
                // configure a non-zero visibility timeout
                VisibilityTimeout = TimeSpan.FromMinutes(5)
            };
            QueueProcessorFactoryContext context = new QueueProcessorFactoryContext(_queue, null, queuesOptions, _poisonQueue);
            QueueProcessor localProcessor = new QueueProcessor(context);

            string messageContent = Guid.NewGuid().ToString();
            CloudQueueMessage message = new CloudQueueMessage(messageContent);
            await _queue.AddMessageAsync(message, CancellationToken.None);

            var functionResult = new FunctionResult(false);
            message = await _queue.GetMessageAsync();
            await localProcessor.CompleteProcessingMessageAsync(message, functionResult, CancellationToken.None);

            var delta = message.NextVisibleTime - DateTime.UtcNow;
            Assert.True(delta.Value.TotalMinutes > 4);
        }

        [Fact]
        public async Task BeginProcessingMessageAsync_MaxDequeueCountExceeded_MovesMessageToPoisonQueue()
        {
            QueueProcessorFactoryContext context = new QueueProcessorFactoryContext(_queue, null, _queuesOptions, _poisonQueue);
            QueueProcessor localProcessor = new QueueProcessor(context);

            bool poisonMessageHandlerCalled = false;
            localProcessor.MessageAddedToPoisonQueue += (sender, e) =>
            {
                Assert.Same(sender, localProcessor);
                Assert.Same(_poisonQueue, e.PoisonQueue);
                Assert.NotNull(e.Message);
                poisonMessageHandlerCalled = true;
            };

            string messageContent = Guid.NewGuid().ToString();
            CloudQueueMessage message = new CloudQueueMessage(messageContent);
            await _queue.AddMessageAsync(message, CancellationToken.None);
            CloudQueueMessage messageFromCloud = await _queue.GetMessageAsync();
            for (int i = 0; i < context.MaxDequeueCount; i++)
            {
                await _queue.UpdateMessageAsync(messageFromCloud, TimeSpan.FromMilliseconds(0), MessageUpdateFields.Visibility, CancellationToken.None);
                messageFromCloud = await _queue.GetMessageAsync();
            }

            Assert.Equal(6, messageFromCloud.DequeueCount);
            bool continueProcessing = await localProcessor.BeginProcessingMessageAsync(messageFromCloud, CancellationToken.None);
            Assert.False(continueProcessing);

            CloudQueueMessage poisonMessage = await _poisonQueue.GetMessageAsync();
            Assert.NotNull(poisonMessage);
            Assert.Equal(messageContent, poisonMessage.AsString);
            Assert.True(poisonMessageHandlerCalled);
        }


        public class TestFixture : IDisposable
        {
            private const string TestQueuePrefix = "queueprocessortests";

            public TestFixture()
            {
                IHost host = new HostBuilder()
                    .ConfigureDefaultTestHost(b =>
                    {
                        b.AddAzureStorage();
                    })
                    .Build();

                var accountProvider = host.Services.GetService<StorageAccountProvider>();
                var task = accountProvider.GetHost();
                CloudQueueClient client = task.CreateCloudQueueClient();
                QueueClient = client;

                string queueName = string.Format("{0}-{1}", TestQueuePrefix, Guid.NewGuid());
                Queue = client.GetQueueReference(queueName);
                Queue.CreateIfNotExistsAsync(CancellationToken.None).Wait();

                string poisonQueueName = string.Format("{0}-poison", queueName);
                PoisonQueue = client.GetQueueReference(poisonQueueName);
                PoisonQueue.CreateIfNotExistsAsync(CancellationToken.None).Wait();
            }

            public CloudQueue Queue
            {
                get;
                private set;
            }

            public CloudQueue PoisonQueue
            {
                get;
                private set;
            }

            public CloudQueueClient QueueClient
            {
                get;
                private set;
            }

            public void Dispose()
            {
                var result = QueueClient.ListQueuesSegmentedAsync(TestQueuePrefix, null).Result;
                var tasks = new List<Task>();

                foreach (var queue in result.Results)
                {
                    tasks.Add(queue.DeleteAsync());
                }

                Task.WaitAll(tasks.ToArray());
            }
        }
    }
}
