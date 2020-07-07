// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Azure.WebJobs.Host.Queues.Listeners;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using Moq;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Queues
{
    public class QueueListenerTests : IClassFixture<QueueListenerTests.TestFixture>
    {
        private Mock<CloudQueue> _mockQueue;
        private QueueListener _listener;
        private Mock<QueueProcessor> _mockQueueProcessor;
        private Mock<ITriggerExecutor<CloudQueueMessage>> _mockTriggerExecutor;
        private CloudQueueMessage _queueMessage;
        private ILoggerFactory _loggerFactory;
        private TestLoggerProvider _loggerProvider;

        public QueueListenerTests(TestFixture fixture)
        {
            Fixture = fixture;

            _mockQueue = new Mock<CloudQueue>(new Uri("https://test.queue.core.windows.net/testqueue"));

            _mockTriggerExecutor = new Mock<ITriggerExecutor<CloudQueueMessage>>(MockBehavior.Strict);
            Mock<IWebJobsExceptionHandler> mockExceptionDispatcher = new Mock<IWebJobsExceptionHandler>(MockBehavior.Strict);
            _loggerFactory = new LoggerFactory();
            _loggerProvider = new TestLoggerProvider();
            _loggerFactory.AddProvider(_loggerProvider);
            Mock<IQueueProcessorFactory> mockQueueProcessorFactory = new Mock<IQueueProcessorFactory>(MockBehavior.Strict);
            QueuesOptions queuesOptions = new QueuesOptions();
            QueueProcessorFactoryContext context = new QueueProcessorFactoryContext(_mockQueue.Object, _loggerFactory, queuesOptions);

            _mockQueueProcessor = new Mock<QueueProcessor>(MockBehavior.Strict, context);
            QueuesOptions queueConfig = new QueuesOptions
            {
                MaxDequeueCount = 5
            };

            mockQueueProcessorFactory.Setup(p => p.Create(It.IsAny<QueueProcessorFactoryContext>())).Returns(_mockQueueProcessor.Object);

            _listener = new QueueListener(_mockQueue.Object, null, _mockTriggerExecutor.Object, mockExceptionDispatcher.Object, _loggerFactory, null, queueConfig, mockQueueProcessorFactory.Object, new FunctionDescriptor { Id = "TestFunction" });
            _queueMessage = new CloudQueueMessage("TestMessage");
        }

        public TestFixture Fixture { get; set; }

        [Fact]
        public void ScaleMonitor_Id_ReturnsExpectedValue()
        {
            Assert.Equal("testfunction-queuetrigger-testqueue", _listener.Descriptor.Id);
        }

        [Fact]
        public async Task GetMetrics_ReturnsExpectedResult()
        {
            var queuesOptions = new QueuesOptions();
            Mock<ITriggerExecutor<CloudQueueMessage>> mockTriggerExecutor = new Mock<ITriggerExecutor<CloudQueueMessage>>(MockBehavior.Strict);
            var queueProcessorFactory = new DefaultQueueProcessorFactory();
            QueueListener listener = new QueueListener(Fixture.Queue, null, mockTriggerExecutor.Object, new WebJobsExceptionHandler(null),
                _loggerFactory, null, queuesOptions, queueProcessorFactory, new FunctionDescriptor { Id = "TestFunction" });

            var metrics = await listener.GetMetricsAsync();

            Assert.Equal(0, metrics.QueueLength);
            Assert.Equal(TimeSpan.Zero, metrics.QueueTime);
            Assert.NotEqual(default(DateTime), metrics.Timestamp);

            // add some test messages
            for (int i = 0; i < 5; i++)
            {
                await Fixture.Queue.AddMessageAsync(new CloudQueueMessage($"Message {i}"), null, null, null, null, CancellationToken.None);
            }

            await Task.Delay(25);

            metrics = await listener.GetMetricsAsync();

            Assert.Equal(5, metrics.QueueLength);
            Assert.True(metrics.QueueTime.Ticks > 0);
            Assert.NotEqual(default(DateTime), metrics.Timestamp);

            // verify non-generic interface works as expected
            metrics = (QueueTriggerMetrics)(await ((IScaleMonitor)listener).GetMetricsAsync());
            Assert.Equal(5, metrics.QueueLength);
        }

        [Fact]
        public async Task GetMetrics_HandlesStorageExceptions()
        {
            var exception = new StorageException(
                new RequestResult
                {
                    HttpStatusCode = 500
                },
                "Things are very wrong.",
                new Exception());

            _mockQueue.Setup(p => p.FetchAttributesAsync()).Throws(exception);

            var metrics = await _listener.GetMetricsAsync();

            Assert.Equal(0, metrics.QueueLength);
            Assert.Equal(TimeSpan.Zero, metrics.QueueTime);
            Assert.NotEqual(default(DateTime), metrics.Timestamp);

            var warning = _loggerProvider.GetAllLogMessages().Single(p => p.Level == Microsoft.Extensions.Logging.LogLevel.Warning);
            Assert.Equal("Error querying for queue scale status: Things are very wrong.", warning.FormattedMessage);
        }

        [Fact]
        public void GetScaleStatus_NoMetrics_ReturnsVote_None()
        {
            var context = new ScaleStatusContext<QueueTriggerMetrics>
            {
                WorkerCount = 1
            };

            var status = _listener.GetScaleStatus(context);
            Assert.Equal(ScaleVote.None, status.Vote);

            // verify the non-generic implementation works properly
            status = ((IScaleMonitor)_listener).GetScaleStatus(context);
            Assert.Equal(ScaleVote.None, status.Vote);
        }

        [Fact]
        public void GetScaleStatus_MessagesPerWorkerThresholdExceeded_ReturnsVote_ScaleOut()
        {
            var context = new ScaleStatusContext<QueueTriggerMetrics>
            {
                WorkerCount = 1
            };
            var timestamp = DateTime.UtcNow;
            var queueTriggerMetrics = new List<QueueTriggerMetrics>
            {
                new QueueTriggerMetrics { QueueLength = 2500, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 2505, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 2612, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 2700, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 2810, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 2900, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) }
            };
            context.Metrics = queueTriggerMetrics;

            var status = _listener.GetScaleStatus(context);

            Assert.Equal(ScaleVote.ScaleOut, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.Equal(Microsoft.Extensions.Logging.LogLevel.Information, log.Level);
            Assert.Equal("QueueLength (2900) > workerCount (1) * 1,000", log.FormattedMessage);
            log = logs[1];
            Assert.Equal(Microsoft.Extensions.Logging.LogLevel.Information, log.Level);
            Assert.Equal($"Length of queue (testqueue, 2900) is too high relative to the number of instances (1).", log.FormattedMessage);

            // verify again with a non generic context instance
            var context2 = new ScaleStatusContext
            {
                WorkerCount = 1,
                Metrics = queueTriggerMetrics
            };
            status = ((IScaleMonitor)_listener).GetScaleStatus(context2);
            Assert.Equal(ScaleVote.ScaleOut, status.Vote);
        }

        [Fact]
        public void GetScaleStatus_QueueLengthIncreasing_ReturnsVote_ScaleOut()
        {
            var context = new ScaleStatusContext<QueueTriggerMetrics>
            {
                WorkerCount = 1
            };
            var timestamp = DateTime.UtcNow;
            context.Metrics = new List<QueueTriggerMetrics>
            {
                new QueueTriggerMetrics { QueueLength = 10, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 20, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 40, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 80, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 100, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 150, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) }
            };

            var status = _listener.GetScaleStatus(context);

            Assert.Equal(ScaleVote.ScaleOut, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.Equal(Microsoft.Extensions.Logging.LogLevel.Information, log.Level);
            Assert.Equal("Queue length is increasing for 'testqueue'", log.FormattedMessage);
        }

        [Fact]
        public void GetScaleStatus_QueueTimeIncreasing_ReturnsVote_ScaleOut()
        {
            var context = new ScaleStatusContext<QueueTriggerMetrics>
            {
                WorkerCount = 1
            };
            var timestamp = DateTime.UtcNow;
            context.Metrics = new List<QueueTriggerMetrics>
            {
                new QueueTriggerMetrics { QueueLength = 100, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 100, QueueTime = TimeSpan.FromSeconds(2), Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 100, QueueTime = TimeSpan.FromSeconds(3), Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 100, QueueTime = TimeSpan.FromSeconds(4), Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 100, QueueTime = TimeSpan.FromSeconds(5), Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 100, QueueTime = TimeSpan.FromSeconds(6), Timestamp = timestamp.AddSeconds(15) }
            };

            var status = _listener.GetScaleStatus(context);

            Assert.Equal(ScaleVote.ScaleOut, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.Equal(Microsoft.Extensions.Logging.LogLevel.Information, log.Level);
            Assert.Equal("Queue time is increasing for 'testqueue'", log.FormattedMessage);
        }

        [Fact]
        public void GetScaleStatus_QueueLengthDecreasing_ReturnsVote_ScaleIn()
        {
            var context = new ScaleStatusContext<QueueTriggerMetrics>
            {
                WorkerCount = 5
            };
            var timestamp = DateTime.UtcNow;
            context.Metrics = new List<QueueTriggerMetrics>
            {
                new QueueTriggerMetrics { QueueLength = 150, QueueTime = TimeSpan.FromMilliseconds(400), Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 100, QueueTime = TimeSpan.FromMilliseconds(400), Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 80, QueueTime = TimeSpan.FromMilliseconds(400), Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 40, QueueTime = TimeSpan.FromMilliseconds(400), Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 20, QueueTime = TimeSpan.FromMilliseconds(400), Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 10, QueueTime = TimeSpan.FromMilliseconds(400), Timestamp = timestamp.AddSeconds(15) }
            };

            var status = _listener.GetScaleStatus(context);

            Assert.Equal(ScaleVote.ScaleIn, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.Equal(Microsoft.Extensions.Logging.LogLevel.Information, log.Level);
            Assert.Equal("Queue length is decreasing for 'testqueue'", log.FormattedMessage);
        }

        [Fact]
        public void GetScaleStatus_QueueTimeDecreasing_ReturnsVote_ScaleIn()
        {
            var context = new ScaleStatusContext<QueueTriggerMetrics>
            {
                WorkerCount = 1
            };
            var timestamp = DateTime.UtcNow;
            context.Metrics = new List<QueueTriggerMetrics>
            {
                new QueueTriggerMetrics { QueueLength = 100, QueueTime = TimeSpan.FromSeconds(5), Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 100, QueueTime = TimeSpan.FromSeconds(4), Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 100, QueueTime = TimeSpan.FromSeconds(3), Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 100, QueueTime = TimeSpan.FromSeconds(2), Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 100, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 100, QueueTime = TimeSpan.FromMilliseconds(100), Timestamp = timestamp.AddSeconds(15) }
            };

            var status = _listener.GetScaleStatus(context);

            Assert.Equal(ScaleVote.ScaleIn, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.Equal(Microsoft.Extensions.Logging.LogLevel.Information, log.Level);
            Assert.Equal("Queue time is decreasing for 'testqueue'", log.FormattedMessage);
        }

        [Fact]
        public void GetScaleStatus_QueueSteady_ReturnsVote_None()
        {
            var context = new ScaleStatusContext<QueueTriggerMetrics>
            {
                WorkerCount = 2
            };
            var timestamp = DateTime.UtcNow;
            context.Metrics = new List<QueueTriggerMetrics>
            {
                new QueueTriggerMetrics { QueueLength = 1500, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 1600, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 1400, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 1300, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 1700, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 1600, QueueTime = TimeSpan.FromSeconds(1), Timestamp = timestamp.AddSeconds(15) }
            };

            var status = _listener.GetScaleStatus(context);

            Assert.Equal(ScaleVote.None, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.Equal(Microsoft.Extensions.Logging.LogLevel.Information, log.Level);
            Assert.Equal("Queue 'testqueue' is steady", log.FormattedMessage);
        }

        [Fact]
        public void GetScaleStatus_QueueIdle_ReturnsVote_ScaleOut()
        {
            var context = new ScaleStatusContext<QueueTriggerMetrics>
            {
                WorkerCount = 3
            };
            var timestamp = DateTime.UtcNow;
            context.Metrics = new List<QueueTriggerMetrics>
            {
                new QueueTriggerMetrics { QueueLength = 0, QueueTime = TimeSpan.Zero, Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 0, QueueTime = TimeSpan.Zero, Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 0, QueueTime = TimeSpan.Zero, Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 0, QueueTime = TimeSpan.Zero, Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 0, QueueTime = TimeSpan.Zero, Timestamp = timestamp.AddSeconds(15) },
                new QueueTriggerMetrics { QueueLength = 0, QueueTime = TimeSpan.Zero, Timestamp = timestamp.AddSeconds(15) }
            };

            var status = _listener.GetScaleStatus(context);

            Assert.Equal(ScaleVote.ScaleIn, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.Equal(Microsoft.Extensions.Logging.LogLevel.Information, log.Level);
            Assert.Equal("Queue 'testqueue' is idle", log.FormattedMessage);
        }

        [Fact]
        public void GetScaleStatus_UnderSampleCountThreshold_ReturnsVote_None()
        {
            var context = new ScaleStatusContext<QueueTriggerMetrics>
            {
                WorkerCount = 1
            };
            context.Metrics = new List<QueueTriggerMetrics>
            {
                new QueueTriggerMetrics { QueueLength = 5, QueueTime = TimeSpan.FromSeconds(1), Timestamp = DateTime.UtcNow },
                new QueueTriggerMetrics { QueueLength = 10, QueueTime = TimeSpan.FromSeconds(1), Timestamp = DateTime.UtcNow }
            };

            var status = _listener.GetScaleStatus(context);

            Assert.Equal(ScaleVote.None, status.Vote);
        }

        [Fact]
        public async Task UpdatedQueueMessage_RetainsOriginalProperties()
        {
            CloudQueue queue = Fixture.CreateNewQueue();
            CloudQueue poisonQueue = Fixture.CreateNewQueue();

            var queuesOptions = new QueuesOptions { MaxDequeueCount = 2 };

            Mock<ITriggerExecutor<CloudQueueMessage>> mockTriggerExecutor = new Mock<ITriggerExecutor<CloudQueueMessage>>(MockBehavior.Strict);

            string messageContent = Guid.NewGuid().ToString();
            CloudQueueMessage message = new CloudQueueMessage(messageContent);
            await queue.AddMessageAsync(message, null, null, null, null, CancellationToken.None);
            CloudQueueMessage messageFromCloud = await queue.GetMessageAsync();
            var queueProcessorFactory = new DefaultQueueProcessorFactory();

            QueueListener listener = new QueueListener(queue, poisonQueue, mockTriggerExecutor.Object, new WebJobsExceptionHandler(null),
                NullLoggerFactory.Instance, null, queuesOptions, queueProcessorFactory, new FunctionDescriptor { Id = "TestFunction" });

            mockTriggerExecutor
                .Setup(m => m.ExecuteAsync(It.IsAny<CloudQueueMessage>(), CancellationToken.None))
                .ReturnsAsync(new FunctionResult(false));

            await listener.ProcessMessageAsync(messageFromCloud, TimeSpan.FromMinutes(10), CancellationToken.None);

            // pull the message and process it again (to have it go through the poison queue flow)
            messageFromCloud = await queue.GetMessageAsync();
            Assert.Equal(2, messageFromCloud.DequeueCount);

            await listener.ProcessMessageAsync(messageFromCloud, TimeSpan.FromMinutes(10), CancellationToken.None);

            // Make sure the message was processed and deleted.
            await queue.FetchAttributesAsync();
            Assert.Equal(0, queue.ApproximateMessageCount);

            // The Listener has inserted a message to the poison queue.
            await poisonQueue.FetchAttributesAsync();
            Assert.Equal(1, poisonQueue.ApproximateMessageCount);

            mockTriggerExecutor.Verify(m => m.ExecuteAsync(It.IsAny<CloudQueueMessage>(), CancellationToken.None), Times.Exactly(2));
        }

        [Fact]
        public async Task RenewedQueueMessage_DeletesCorrectly()
        {
            CloudQueue queue = Fixture.CreateNewQueue();

            Mock<ITriggerExecutor<CloudQueueMessage>> mockTriggerExecutor = new Mock<ITriggerExecutor<CloudQueueMessage>>(MockBehavior.Strict);

            string messageContent = Guid.NewGuid().ToString();
            CloudQueueMessage message = new CloudQueueMessage(messageContent);
            await queue.AddMessageAsync(message, null, null, null, null, CancellationToken.None);
            CloudQueueMessage messageFromCloud = await queue.GetMessageAsync();

            QueueListener listener = new QueueListener(queue, null, mockTriggerExecutor.Object, new WebJobsExceptionHandler(null),
                _loggerFactory, null, new QueuesOptions(), new DefaultQueueProcessorFactory(), new FunctionDescriptor { Id = "TestFunction" });

            listener.MinimumVisibilityRenewalInterval = TimeSpan.FromSeconds(1);

            // Set up a function that sleeps to allow renewal
            mockTriggerExecutor
                .Setup(m => m.ExecuteAsync(It.Is<CloudQueueMessage>(msg => msg.DequeueCount == 1), CancellationToken.None))
                .ReturnsAsync(() =>
                {
                    Thread.Sleep(4000);
                    return new FunctionResult(true);
                });

            var previousNextVisibleTime = messageFromCloud.NextVisibleTime;
            var previousPopReceipt = messageFromCloud.PopReceipt;

            // Renewal should happen at 2 seconds
            await listener.ProcessMessageAsync(messageFromCloud, TimeSpan.FromSeconds(4), CancellationToken.None);

            // Check to make sure the renewal occurred.
            Assert.NotEqual(messageFromCloud.NextVisibleTime, previousNextVisibleTime);
            Assert.NotEqual(messageFromCloud.PopReceipt, previousPopReceipt);

            // Make sure the message was processed and deleted.
            await queue.FetchAttributesAsync();
            Assert.Equal(0, queue.ApproximateMessageCount);
        }

        [Fact]
        public void CreateQueueProcessor_CreatesProcessorCorrectly()
        {
            CloudQueue poisonQueue = null;
            bool poisonMessageHandlerInvoked = false;
            EventHandler<PoisonMessageEventArgs> poisonMessageEventHandler = (sender, e) => { poisonMessageHandlerInvoked = true; };
            Mock<IQueueProcessorFactory> mockQueueProcessorFactory = new Mock<IQueueProcessorFactory>(MockBehavior.Strict);
            QueuesOptions queueConfig = new QueuesOptions
            {
                MaxDequeueCount = 7
            };
            QueueProcessor expectedQueueProcessor = null;
            bool processorFactoryInvoked = false;

            // create for a host queue - don't expect custom factory to be invoked
            CloudQueue queue = new CloudQueue(new Uri(string.Format("https://test.queue.core.windows.net/{0}", HostQueueNames.GetHostQueueName("12345"))));
            QueueProcessor queueProcessor = QueueListener.CreateQueueProcessor(queue, poisonQueue, _loggerFactory, mockQueueProcessorFactory.Object, queueConfig, poisonMessageEventHandler);
            Assert.False(processorFactoryInvoked);
            Assert.NotSame(expectedQueueProcessor, queueProcessor);
            queueProcessor.OnMessageAddedToPoisonQueue(new PoisonMessageEventArgs(null, poisonQueue));
            Assert.True(poisonMessageHandlerInvoked);

            QueueProcessorFactoryContext processorFactoryContext = null;
            mockQueueProcessorFactory.Setup(p => p.Create(It.IsAny<QueueProcessorFactoryContext>()))
                .Callback<QueueProcessorFactoryContext>((mockProcessorContext) =>
                {
                    processorFactoryInvoked = true;

                    Assert.Same(queue, mockProcessorContext.Queue);
                    Assert.Same(poisonQueue, mockProcessorContext.PoisonQueue);
                    Assert.Equal(queueConfig.MaxDequeueCount, mockProcessorContext.MaxDequeueCount);
                    Assert.NotNull(mockProcessorContext.Logger);

                    processorFactoryContext = mockProcessorContext;
                })
                .Returns(() =>
                {
                    expectedQueueProcessor = new QueueProcessor(processorFactoryContext);
                    return expectedQueueProcessor;
                });

            // when storage host is "localhost" we invoke the processor factory even for
            // host queues (this enables local test mocking)
            processorFactoryInvoked = false;
            queue = new CloudQueue(new Uri(string.Format("https://localhost/{0}", HostQueueNames.GetHostQueueName("12345"))));
            queueProcessor = QueueListener.CreateQueueProcessor(queue, poisonQueue, _loggerFactory, mockQueueProcessorFactory.Object, queueConfig, poisonMessageEventHandler);
            Assert.True(processorFactoryInvoked);
            Assert.Same(expectedQueueProcessor, queueProcessor);

            // create for application queue - expect processor factory to be invoked
            poisonMessageHandlerInvoked = false;
            processorFactoryInvoked = false;
            queue = new CloudQueue(new Uri("https://test.queue.core.windows.net/testqueue"));
            queueProcessor = QueueListener.CreateQueueProcessor(queue, poisonQueue, _loggerFactory, mockQueueProcessorFactory.Object, queueConfig, poisonMessageEventHandler);
            Assert.True(processorFactoryInvoked);
            Assert.Same(expectedQueueProcessor, queueProcessor);
            queueProcessor.OnMessageAddedToPoisonQueue(new PoisonMessageEventArgs(null, poisonQueue));
            Assert.True(poisonMessageHandlerInvoked);

            // if poison message watcher not specified, event not subscribed to
            poisonMessageHandlerInvoked = false;
            processorFactoryInvoked = false;
            queueProcessor = QueueListener.CreateQueueProcessor(queue, poisonQueue, _loggerFactory, mockQueueProcessorFactory.Object, queueConfig, null);
            Assert.True(processorFactoryInvoked);
            Assert.Same(expectedQueueProcessor, queueProcessor);
            queueProcessor.OnMessageAddedToPoisonQueue(new PoisonMessageEventArgs(null, poisonQueue));
            Assert.False(poisonMessageHandlerInvoked);
        }

        [Fact]
        public async Task ProcessMessageAsync_Success()
        {
            CancellationToken cancellationToken = new CancellationToken();
            FunctionResult result = new FunctionResult(true);
            _mockQueueProcessor.Setup(p => p.BeginProcessingMessageAsync(_queueMessage, cancellationToken)).ReturnsAsync(true);
            _mockTriggerExecutor.Setup(p => p.ExecuteAsync(_queueMessage, cancellationToken)).ReturnsAsync(result);
            _mockQueueProcessor.Setup(p => p.CompleteProcessingMessageAsync(_queueMessage, result, It.IsNotIn(cancellationToken))).Returns(Task.FromResult(true));

            await _listener.ProcessMessageAsync(_queueMessage, TimeSpan.FromMinutes(10), cancellationToken);
        }

        [Fact]
        public async Task GetMessages_QueueCheckThrowsTransientError_ReturnsBackoffResult()
        {
            CancellationToken cancellationToken = new CancellationToken();
            var exception = new StorageException(
                new RequestResult
                {
                    HttpStatusCode = 503
                },
                string.Empty,
                new Exception());

            _mockQueue.Setup(p => p.GetMessagesAsync(It.IsAny<int>(), It.IsAny<TimeSpan>(), null, null, cancellationToken)).Throws(exception);

            var result = await _listener.ExecuteAsync(cancellationToken);
            Assert.NotNull(result);
            await result.Wait;
        }

        [Fact]
        public async Task GetMessages_ChecksQueueExistence_UntilQueueExists()
        {
            var cancellationToken = new CancellationToken();
            bool queueExists = false;
            _mockQueue.Setup(p => p.ExistsAsync()).ReturnsAsync(() => queueExists);
            _mockQueue.Setup(p => p.GetMessagesAsync(It.IsAny<int>(), It.IsAny<TimeSpan>(), QueueListener.DefaultQueueRequestOptions, It.IsAny<OperationContext>(), cancellationToken)).ReturnsAsync(Enumerable.Empty<CloudQueueMessage>());

            int numIterations = 5;
            int numFailedExistenceChecks = 2;
            for (int i = 0; i < numIterations; i++)
            {
                if (i >= numFailedExistenceChecks)
                {
                    // after the second failed check, simulate the queue
                    // being added
                    queueExists = true;
                }

                var result = await _listener.ExecuteAsync(cancellationToken);
                await result.Wait;
            }

            _mockQueue.Verify(p => p.ExistsAsync(), Times.Exactly(numIterations - numFailedExistenceChecks));
            _mockQueue.Verify(p => p.GetMessagesAsync(It.IsAny<int>(), It.IsAny<TimeSpan>(), QueueListener.DefaultQueueRequestOptions, It.IsAny<OperationContext>(), cancellationToken), Times.Exactly(numIterations - numFailedExistenceChecks));
        }

        [Fact]
        public async Task GetMessages_ResetsQueueExistenceCheck_OnException()
        {
            var cancellationToken = new CancellationToken();
            _mockQueue.Setup(p => p.ExistsAsync()).ReturnsAsync(true);
            var exception = new StorageException(
                new RequestResult
                {
                    HttpStatusCode = 503
                },
                string.Empty, new Exception());
            _mockQueue.Setup(p => p.GetMessagesAsync(It.IsAny<int>(), It.IsAny<TimeSpan>(), QueueListener.DefaultQueueRequestOptions, It.IsAny<OperationContext>(), cancellationToken)).Throws(exception);

            for (int i = 0; i < 5; i++)
            {
                var result = await _listener.ExecuteAsync(cancellationToken);
                await result.Wait;
            }

            _mockQueue.Verify(p => p.ExistsAsync(), Times.Exactly(5));
            _mockQueue.Verify(p => p.GetMessagesAsync(It.IsAny<int>(), It.IsAny<TimeSpan>(), QueueListener.DefaultQueueRequestOptions, It.IsAny<OperationContext>(), cancellationToken), Times.Exactly(5));
        }

        [Fact]
        public async Task ProcessMessageAsync_QueueBeginProcessingMessageReturnsFalse_MessageNotProcessed()
        {
            CancellationToken cancellationToken = new CancellationToken();
            _mockQueueProcessor.Setup(p => p.BeginProcessingMessageAsync(_queueMessage, cancellationToken)).ReturnsAsync(false);

            await _listener.ProcessMessageAsync(_queueMessage, TimeSpan.FromMinutes(10), cancellationToken);
        }

        [Fact]
        public async Task ProcessMessageAsync_FunctionInvocationFails()
        {
            CancellationToken cancellationToken = new CancellationToken();
            FunctionResult result = new FunctionResult(false);
            _mockQueueProcessor.Setup(p => p.BeginProcessingMessageAsync(_queueMessage, cancellationToken)).ReturnsAsync(true);
            _mockTriggerExecutor.Setup(p => p.ExecuteAsync(_queueMessage, cancellationToken)).ReturnsAsync(result);
            _mockQueueProcessor.Setup(p => p.CompleteProcessingMessageAsync(_queueMessage, result, It.IsNotIn(cancellationToken))).Returns(Task.FromResult(true));

            await _listener.ProcessMessageAsync(_queueMessage, TimeSpan.FromMinutes(10), cancellationToken);
        }
        public class TestFixture : IDisposable
        {
            private const string TestQueuePrefix = "queuelistenertests";

            public TestFixture()
            {
                // Create a default host to get some default services
                IHost host = new HostBuilder()
                    .ConfigureDefaultTestHost(b =>
                    {
                        b.AddAzureStorage();
                    })
                    .Build();

                var storageAccount = host.GetStorageAccount();
                QueueClient = storageAccount.CreateCloudQueueClient();

                string queueName = string.Format("{0}-{1}", TestQueuePrefix, Guid.NewGuid());
                Queue = QueueClient.GetQueueReference(queueName);
                Queue.CreateIfNotExistsAsync(null, null, CancellationToken.None).Wait();

                string poisonQueueName = string.Format("{0}-poison", queueName);
                PoisonQueue = QueueClient.GetQueueReference(poisonQueueName);
                PoisonQueue.CreateIfNotExistsAsync(null, null, CancellationToken.None).Wait();
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

            public CloudQueue CreateNewQueue()
            {
                string queueName = string.Format("{0}-{1}", TestQueuePrefix, Guid.NewGuid());
                var queue = QueueClient.GetQueueReference(queueName);
                queue.CreateIfNotExistsAsync(null, null, CancellationToken.None).Wait();
                return queue;
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
