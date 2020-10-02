// Copyright (c) Microsoft Corporation. All rights reserved.
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
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using System.Linq;
using Moq;
using Azure;
using Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Host.FunctionalTests
{
    public class QueueProcessorTests
    {
        private QueueServiceClient _queueServiceClient;
        private QueueClient _queue;
        private QueueClient _poisonQueue;
        private QueueProcessor _processor;
        private QueuesOptions _queuesOptions;
        private static QueueProcessorTests.TestFixture _fixture;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _fixture = new TestFixture();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _fixture.Dispose();
        }

        [SetUp]
        public void SetUp()
        {
            _queueServiceClient = _fixture.QueueClient;
            _queue = _fixture.Queue;
            _poisonQueue = _fixture.PoisonQueue;

            _queuesOptions = new QueuesOptions();
            QueueProcessorFactoryContext context = new QueueProcessorFactoryContext(_queue, null, _queuesOptions);
            _processor = new QueueProcessor(context);
        }

        [Test]
        [WebJobsLiveOnly]
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

            Assert.AreEqual(options.BatchSize, localProcessor.BatchSize);
            Assert.AreEqual(options.MaxDequeueCount, localProcessor.MaxDequeueCount);
            Assert.AreEqual(options.NewBatchThreshold, localProcessor.NewBatchThreshold);
            Assert.AreEqual(options.VisibilityTimeout, localProcessor.VisibilityTimeout);
            Assert.AreEqual(options.MaxPollingInterval, localProcessor.MaxPollingInterval);
        }

        [Test]
        [WebJobsLiveOnly]
        public async Task CompleteProcessingMessageAsync_Success_DeletesMessage()
        {
            await _queue.SendMessageAsync("Test Message");

            QueueMessage message = (await _queue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();

            FunctionResult result = new FunctionResult(true);
            await _processor.CompleteProcessingMessageAsync(message, result, CancellationToken.None);

            message = (await _queue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
            Assert.Null(message);
        }

        [Test]
        [WebJobsLiveOnly]
        public async Task CompleteProcessingMessageAsync_FailureWithoutPoisonQueue_DoesNotDeleteMessage()
        {
            await _queue.SendMessageAsync("Test Message");

            QueueMessage message = (await _queue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
            string id = message.MessageId;

            FunctionResult result = new FunctionResult(false);
            await _processor.CompleteProcessingMessageAsync(message, result, CancellationToken.None);

            // make the message visible again so we can verify it wasn't deleted
            await _queue.UpdateMessageAsync(message.MessageId, message.PopReceipt, visibilityTimeout: TimeSpan.Zero);

            message = (await _queue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
            Assert.NotNull(message);
            Assert.AreEqual(id, message.MessageId);
        }

        [Test]
        [WebJobsLiveOnly]
        public async Task CompleteProcessingMessageAsync_MaxDequeueCountExceeded_MovesMessageToPoisonQueue()
        {
            QueueProcessorFactoryContext context = new QueueProcessorFactoryContext(_queue, null, _queuesOptions, _poisonQueue);
            QueueProcessor localProcessor = new QueueProcessor(context);

            bool poisonMessageHandlerCalled = false;
            localProcessor.MessageAddedToPoisonQueue += (sender, e) =>
                {
                    Assert.AreSame(sender, localProcessor);
                    Assert.AreSame(_poisonQueue, e.PoisonQueue);
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
            Assert.AreEqual(messageContent, poisonMessage.MessageText);
            Assert.True(poisonMessageHandlerCalled);
        }

        [Test]
        [WebJobsLiveOnly]
        public async Task CompleteProcessingMessageAsync_Failure_AppliesVisibilityTimeout()
        {
            var queuesOptions = new QueuesOptions
            {
                // configure a non-zero visibility timeout
                VisibilityTimeout = TimeSpan.FromMinutes(5)
            };
            Mock<QueueClient> queueClientMock = new Mock<QueueClient>();
            TimeSpan updatedVisibilityTimeout = TimeSpan.Zero;

            queueClientMock.Setup(x => x.UpdateMessageAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<TimeSpan>(), It.IsAny<CancellationToken>()))
                .Callback((string messageId, string popReceipt, string messageText, TimeSpan visibilityTimeout, CancellationToken cancellationToken) =>
                {
                    updatedVisibilityTimeout = visibilityTimeout;
                })
                .ReturnsAsync(Response.FromValue(QueuesModelFactory.UpdateReceipt("x", DateTimeOffset.UtcNow.AddMinutes(5)), null));

            QueueProcessorFactoryContext context = new QueueProcessorFactoryContext(queueClientMock.Object, null, queuesOptions, _poisonQueue);
            QueueProcessor localProcessor = new QueueProcessor(context);

            string messageContent = Guid.NewGuid().ToString();
            await _queue.SendMessageAsync(messageContent);

            var functionResult = new FunctionResult(false);
            QueueMessage message = (await _queue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
            await localProcessor.CompleteProcessingMessageAsync(message, functionResult, CancellationToken.None);

            Assert.AreEqual(queuesOptions.VisibilityTimeout, updatedVisibilityTimeout);
        }

        [Test]
        [WebJobsLiveOnly]
        public async Task BeginProcessingMessageAsync_MaxDequeueCountExceeded_MovesMessageToPoisonQueue()
        {
            QueueProcessorFactoryContext context = new QueueProcessorFactoryContext(_queue, null, _queuesOptions, _poisonQueue);
            QueueProcessor localProcessor = new QueueProcessor(context);

            bool poisonMessageHandlerCalled = false;
            localProcessor.MessageAddedToPoisonQueue += (sender, e) =>
            {
                Assert.AreSame(sender, localProcessor);
                Assert.AreSame(_poisonQueue, e.PoisonQueue);
                Assert.NotNull(e.Message);
                poisonMessageHandlerCalled = true;
            };

            string messageContent = Guid.NewGuid().ToString();
            await _queue.SendMessageAsync(messageContent);
            QueueMessage messageFromCloud = (await _queue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
            for (int i = 0; i < context.MaxDequeueCount; i++)
            {
                await _queue.UpdateMessageAsync(messageFromCloud.MessageId, messageFromCloud.PopReceipt, visibilityTimeout: TimeSpan.FromMilliseconds(0));
                messageFromCloud = (await _queue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
            }

            Assert.AreEqual(6, messageFromCloud.DequeueCount);
            bool continueProcessing = await localProcessor.BeginProcessingMessageAsync(messageFromCloud, CancellationToken.None);
            Assert.False(continueProcessing);

            QueueMessage poisonMessage = (await _poisonQueue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
            Assert.NotNull(poisonMessage);
            Assert.AreEqual(messageContent, poisonMessage.MessageText);
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
                        b.AddAzureStorageBlobs().AddAzureStorageQueues();
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
