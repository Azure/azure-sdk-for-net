﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Xunit;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using System.Linq;

namespace Microsoft.Azure.WebJobs.Host.FunctionalTests
{
    [Trait("SecretsRequired", "true")]
    public class QueueProcessorTests : IClassFixture<QueueProcessorTests.TestFixture>
    {
        private QueueServiceClient _queueServiceClient;
        private QueueClient _queue;
        private QueueClient _poisonQueue;
        private QueueProcessor _processor;
        private QueuesOptions _queuesOptions;

        public QueueProcessorTests(TestFixture fixture)
        {
            _queueServiceClient = fixture.QueueClient;
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
            await _queue.SendMessageAsync("Test Message");

            QueueMessage message = (await _queue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();

            FunctionResult result = new FunctionResult(true);
            await _processor.CompleteProcessingMessageAsync(message, result, CancellationToken.None);

            message = (await _queue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
            Assert.Null(message);
        }

        [Fact]
        public async Task CompleteProcessingMessageAsync_FailureWithoutPoisonQueue_DoesNotDeleteMessage()
        {
            await _queue.SendMessageAsync("Test Message");

            QueueMessage message = (await _queue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
            string id = message.MessageId;

            FunctionResult result = new FunctionResult(false);
            await _processor.CompleteProcessingMessageAsync(message, result, CancellationToken.None);

            // make the message visible again so we can verify it wasn't deleted
            // TODO (kasobol-msft) fix after https://github.com/Azure/azure-sdk-for-net/issues/14243 is resolved.
            await _queue.UpdateMessageAsync(message.MessageId, message.PopReceipt, message.MessageText, visibilityTimeout: TimeSpan.Zero);

            message = (await _queue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
            Assert.NotNull(message);
            Assert.Equal(id, message.MessageId);
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
            QueueMessage message = null;
            await _queue.SendMessageAsync(messageContent);

            FunctionResult result = new FunctionResult(false);
            for (int i = 0; i < context.MaxDequeueCount; i++)
            {
                message = (await _queue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
                await localProcessor.CompleteProcessingMessageAsync(message, result, CancellationToken.None);
            }

            message = (await _queue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
            Assert.Null(message);

            QueueMessage poisonMessage = (await _poisonQueue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
            Assert.NotNull(poisonMessage);
            Assert.Equal(messageContent, poisonMessage.MessageText);
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
            await _queue.SendMessageAsync(messageContent);

            var functionResult = new FunctionResult(false);
            QueueMessage message = (await _queue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
            await localProcessor.CompleteProcessingMessageAsync(message, functionResult, CancellationToken.None);

            //var delta = message.NextVisibleOn - DateTime.UtcNow;
            //Assert.True(delta.Value.TotalMinutes > 4);
            // TODO (kasobol-msft) This doesn't seem to do what this test is trying to assert. check this later.
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
            await _queue.SendMessageAsync(messageContent);
            QueueMessage messageFromCloud = (await _queue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
            for (int i = 0; i < context.MaxDequeueCount; i++)
            {
                // TODO (kasobol-msft) fix after https://github.com/Azure/azure-sdk-for-net/issues/14243 is resolved.
                await _queue.UpdateMessageAsync(messageFromCloud.MessageId, messageFromCloud.PopReceipt, messageFromCloud.MessageText, visibilityTimeout: TimeSpan.FromMilliseconds(0));
                messageFromCloud = (await _queue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
            }

            Assert.Equal(6, messageFromCloud.DequeueCount);
            bool continueProcessing = await localProcessor.BeginProcessingMessageAsync(messageFromCloud, CancellationToken.None);
            Assert.False(continueProcessing);

            QueueMessage poisonMessage = (await _poisonQueue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
            Assert.NotNull(poisonMessage);
            Assert.Equal(messageContent, poisonMessage.MessageText);
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
                QueueServiceClient client = task.CreateQueueServiceClient();
                QueueClient = client;

                string queueName = string.Format("{0}-{1}", TestQueuePrefix, Guid.NewGuid());
                Queue = client.GetQueueClient(queueName);
                Queue.CreateIfNotExists();

                string poisonQueueName = string.Format("{0}-poison", queueName);
                PoisonQueue = client.GetQueueClient(poisonQueueName);
                PoisonQueue.CreateIfNotExists();
            }

            public QueueClient Queue
            {
                get;
                private set;
            }

            public QueueClient PoisonQueue
            {
                get;
                private set;
            }

            public QueueServiceClient QueueClient
            {
                get;
                private set;
            }

            public void Dispose()
            {
                var result = QueueClient.GetQueues(prefix: TestQueuePrefix);
                var tasks = new List<Task>();

                foreach (var queue in result)
                {
                    tasks.Add(QueueClient.GetQueueClient(queue.Name).DeleteAsync());
                }

                Task.WaitAll(tasks.ToArray());
            }
        }
    }
}
