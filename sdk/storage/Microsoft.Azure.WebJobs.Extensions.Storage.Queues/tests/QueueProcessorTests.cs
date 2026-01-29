// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.TestFramework;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues
{
    public class QueueProcessorTests : LiveTestBase<WebJobsTestEnvironment>
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
            QueueProcessorOptions context = new QueueProcessorOptions(_queue, null, _queuesOptions);
            _processor = new QueueProcessor(context);
        }

        [Test]
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
            QueueProcessorOptions context = new QueueProcessorOptions(_queue, null, options);
            QueueProcessor localProcessor = new QueueProcessor(context);

            Assert.That(localProcessor.QueuesOptions.BatchSize, Is.EqualTo(options.BatchSize));
            Assert.That(localProcessor.QueuesOptions.MaxDequeueCount, Is.EqualTo(options.MaxDequeueCount));
            Assert.That(localProcessor.QueuesOptions.NewBatchThreshold, Is.EqualTo(options.NewBatchThreshold));
            Assert.That(localProcessor.QueuesOptions.VisibilityTimeout, Is.EqualTo(options.VisibilityTimeout));
            Assert.That(localProcessor.QueuesOptions.MaxPollingInterval, Is.EqualTo(options.MaxPollingInterval));
        }

        [Test]
        public async Task CompleteProcessingMessageAsync_Success_DeletesMessage()
        {
            await _queue.SendMessageAsync("Test Message");

            QueueMessage message = (await _queue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();

            FunctionResult result = new FunctionResult(true);
            await _processor.CompleteProcessingMessageAsync(message, result, CancellationToken.None);

            message = (await _queue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
            Assert.That(message, Is.Null);
        }

        [Test]
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
            Assert.That(message, Is.Not.Null);
            Assert.That(message.MessageId, Is.EqualTo(id));
        }

        [Test]
        public async Task CompleteProcessingMessageAsync_MaxDequeueCountExceeded_MovesMessageToPoisonQueue()
        {
            ILoggerFactory loggerFactory = new LoggerFactory();
            var provider = new TestLoggerProvider();
            loggerFactory.AddProvider(provider);
            QueueProcessorOptions context = new QueueProcessorOptions(_queue, loggerFactory, _queuesOptions, _poisonQueue);
            QueueProcessor localProcessor = new QueueProcessor(context);

            bool poisonMessageHandlerCalled = false;
            localProcessor.MessageAddedToPoisonQueueAsync += (sender, e) =>
                {
                    Assert.That(localProcessor, Is.SameAs(sender));
                    Assert.That(e.PoisonQueue, Is.SameAs(_poisonQueue));
                    Assert.That(e.Message, Is.Not.Null);
                    poisonMessageHandlerCalled = true;
                    return Task.CompletedTask;
                };

            string messageContent = Guid.NewGuid().ToString();
            QueueMessage message = null;
            await _queue.SendMessageAsync(messageContent);

            FunctionResult result = new FunctionResult(false);
            for (int i = 0; i < context.Options.MaxDequeueCount; i++)
            {
                message = (await _queue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
                await localProcessor.CompleteProcessingMessageAsync(message, result, CancellationToken.None);
            }

            message = (await _queue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
            Assert.That(message, Is.Null);

            QueueMessage poisonMessage = (await _poisonQueue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
            Assert.That(poisonMessage, Is.Not.Null);
            Assert.That(poisonMessage.MessageText, Is.EqualTo(messageContent));
            Assert.That(poisonMessageHandlerCalled, Is.True);

            var categories = provider.GetAllLogMessages().Select(p => p.Category);
            Assert.That(categories, Has.Member("Microsoft.Azure.WebJobs.Host.Queues.QueueProcessor"));
        }

        [Test]
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

            QueueProcessorOptions context = new QueueProcessorOptions(queueClientMock.Object, null, queuesOptions, _poisonQueue);
            QueueProcessor localProcessor = new QueueProcessor(context);

            string messageContent = Guid.NewGuid().ToString();
            await _queue.SendMessageAsync(messageContent);

            var functionResult = new FunctionResult(false);
            QueueMessage message = (await _queue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
            await localProcessor.CompleteProcessingMessageAsync(message, functionResult, CancellationToken.None);

            Assert.That(updatedVisibilityTimeout, Is.EqualTo(queuesOptions.VisibilityTimeout));
        }

        [Test]
        public async Task BeginProcessingMessageAsync_MaxDequeueCountExceeded_MovesMessageToPoisonQueue()
        {
            QueueProcessorOptions context = new QueueProcessorOptions(_queue, null, _queuesOptions, _poisonQueue);
            QueueProcessor localProcessor = new QueueProcessor(context);

            bool poisonMessageHandlerCalled = false;
            localProcessor.MessageAddedToPoisonQueueAsync += (sender, e) =>
            {
                Assert.That(localProcessor, Is.SameAs(sender));
                Assert.That(e.PoisonQueue, Is.SameAs(_poisonQueue));
                Assert.That(e.Message, Is.Not.Null);
                poisonMessageHandlerCalled = true;
                return Task.CompletedTask;
            };

            string messageContent = Guid.NewGuid().ToString();
            await _queue.SendMessageAsync(messageContent);
            QueueMessage messageFromCloud = (await _queue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
            for (int i = 0; i < context.Options.MaxDequeueCount; i++)
            {
                await _queue.UpdateMessageAsync(messageFromCloud.MessageId, messageFromCloud.PopReceipt, visibilityTimeout: TimeSpan.FromMilliseconds(0));
                messageFromCloud = (await _queue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
            }

            Assert.That(messageFromCloud.DequeueCount, Is.EqualTo(6));
            bool continueProcessing = await localProcessor.BeginProcessingMessageAsync(messageFromCloud, CancellationToken.None);
            Assert.That(continueProcessing, Is.False);

            QueueMessage poisonMessage = (await _poisonQueue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
            Assert.That(poisonMessage, Is.Not.Null);
            Assert.That(poisonMessage.MessageText, Is.EqualTo(messageContent));
            Assert.That(poisonMessageHandlerCalled, Is.True);
        }

        public class TestFixture : IDisposable
        {
            private const string TestQueuePrefix = "queueprocessortests";

            public TestFixture()
            {
                IHost host = new HostBuilder()
                    .ConfigureDefaultTestHost(b =>
                    {
                        b.AddAzureStorageQueues();
                    })
                    .Build();

                var queueServiceClientProvider = host.Services.GetService<QueueServiceClientProvider>();
                QueueServiceClient client = queueServiceClientProvider.GetHost();
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
