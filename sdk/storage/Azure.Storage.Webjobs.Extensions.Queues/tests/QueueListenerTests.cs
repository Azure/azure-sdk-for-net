﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Azure.WebJobs.Host.Queues.Listeners;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Xunit;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Azure;
using Azure.Core.TestFramework;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Queues
{
    public class QueueListenerTests : IClassFixture<QueueListenerTests.TestFixture>
    {
        private Mock<QueueClient> _mockQueue;
        private QueueListener _listener;
        private Mock<QueueProcessor> _mockQueueProcessor;
        private Mock<ITriggerExecutor<QueueMessage>> _mockTriggerExecutor;
        private QueueMessage _queueMessage;
        private ILoggerFactory _loggerFactory;
        private TestLoggerProvider _loggerProvider;

        public QueueListenerTests(TestFixture fixture)
        {
            Fixture = fixture;

            _mockQueue = new Mock<QueueClient>(new Uri("https://test.queue.core.windows.net/testqueue"), null);
            _mockQueue.Setup(x => x.Name).Returns("testqueue");

            _mockTriggerExecutor = new Mock<ITriggerExecutor<QueueMessage>>(MockBehavior.Strict);
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
            _queueMessage = QueuesModelFactory.QueueMessage("TestId", "TestPopReceipt", "TestMessage", 0);
        }

        public TestFixture Fixture { get; set; }

        [LiveFact]
        public void ScaleMonitor_Id_ReturnsExpectedValue()
        {
            Assert.Equal("testfunction-queuetrigger-testqueue", _listener.Descriptor.Id);
        }

        [LiveFact]
        public async Task GetMetrics_ReturnsExpectedResult()
        {
            var queuesOptions = new QueuesOptions();
            Mock<ITriggerExecutor<QueueMessage>> mockTriggerExecutor = new Mock<ITriggerExecutor<QueueMessage>>(MockBehavior.Strict);
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
                await Fixture.Queue.SendMessageAsync($"Message {i}");
            }

            await Task.Delay(TimeSpan.FromSeconds(5));

            metrics = await listener.GetMetricsAsync();

            Assert.Equal(5, metrics.QueueLength);
            Assert.True(metrics.QueueTime.Ticks > 0);
            Assert.NotEqual(default(DateTime), metrics.Timestamp);

            // verify non-generic interface works as expected
            metrics = (QueueTriggerMetrics)(await ((IScaleMonitor)listener).GetMetricsAsync());
            Assert.Equal(5, metrics.QueueLength);
        }

        [LiveFact]
        public async Task GetMetrics_HandlesStorageExceptions()
        {
            var exception = new RequestFailedException(
                500,
                "Things are very wrong.",
                default,
                new Exception());

            _mockQueue.Setup(p => p.GetPropertiesAsync(It.IsAny<CancellationToken>())).Throws(exception);

            var metrics = await _listener.GetMetricsAsync();

            Assert.Equal(0, metrics.QueueLength);
            Assert.Equal(TimeSpan.Zero, metrics.QueueTime);
            Assert.NotEqual(default(DateTime), metrics.Timestamp);

            var warning = _loggerProvider.GetAllLogMessages().Single(p => p.Level == Microsoft.Extensions.Logging.LogLevel.Warning);
            Assert.Equal("Error querying for queue scale status: Things are very wrong.", warning.FormattedMessage);
        }

        [LiveFact]
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

        [LiveFact]
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

        [LiveFact]
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

        [LiveFact]
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

        [LiveFact]
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

        [LiveFact]
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

        [LiveFact]
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

        [LiveFact]
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

        [LiveFact]
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

        [LiveFact]
        public async Task UpdatedQueueMessage_RetainsOriginalProperties()
        {
            QueueClient queue = Fixture.CreateNewQueue();
            QueueClient poisonQueue = Fixture.CreateNewQueue();

            var queuesOptions = new QueuesOptions { MaxDequeueCount = 2 };

            Mock<ITriggerExecutor<QueueMessage>> mockTriggerExecutor = new Mock<ITriggerExecutor<QueueMessage>>(MockBehavior.Strict);

            string messageContent = Guid.NewGuid().ToString();
            await queue.SendMessageAsync(messageContent);
            QueueMessage messageFromCloud = (await queue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
            var queueProcessorFactory = new DefaultQueueProcessorFactory();

            QueueListener listener = new QueueListener(queue, poisonQueue, mockTriggerExecutor.Object, new WebJobsExceptionHandler(null),
                NullLoggerFactory.Instance, null, queuesOptions, queueProcessorFactory, new FunctionDescriptor { Id = "TestFunction" });

            mockTriggerExecutor
                .Setup(m => m.ExecuteAsync(It.IsAny<QueueMessage>(), CancellationToken.None))
                .ReturnsAsync(new FunctionResult(false));

            await listener.ProcessMessageAsync(messageFromCloud, TimeSpan.FromMinutes(10), CancellationToken.None);

            // pull the message and process it again (to have it go through the poison queue flow)
            messageFromCloud = (await queue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
            Assert.Equal(2, messageFromCloud.DequeueCount);

            await listener.ProcessMessageAsync(messageFromCloud, TimeSpan.FromMinutes(10), CancellationToken.None);

            // Make sure the message was processed and deleted.
            QueueProperties queueProperties = await queue.GetPropertiesAsync();
            Assert.Equal(0, queueProperties.ApproximateMessagesCount);

            // The Listener has inserted a message to the poison queue.
            QueueProperties poisonQueueProperties = await poisonQueue.GetPropertiesAsync();
            Assert.Equal(1, poisonQueueProperties.ApproximateMessagesCount);

            mockTriggerExecutor.Verify(m => m.ExecuteAsync(It.IsAny<QueueMessage>(), CancellationToken.None), Times.Exactly(2));
        }

        [Fact(Skip = "TODO (kasobol-msft) revisit this test if we put recordings in place, we don't use stateful message in V12")]
        public async Task RenewedQueueMessage_DeletesCorrectly()
        {
            QueueClient queue = Fixture.CreateNewQueue();

            Mock<ITriggerExecutor<QueueMessage>> mockTriggerExecutor = new Mock<ITriggerExecutor<QueueMessage>>(MockBehavior.Strict);

            string messageContent = Guid.NewGuid().ToString();
            await queue.SendMessageAsync(messageContent);
            QueueMessage messageFromCloud = (await queue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();

            QueueListener listener = new QueueListener(queue, null, mockTriggerExecutor.Object, new WebJobsExceptionHandler(null),
                _loggerFactory, null, new QueuesOptions(), new DefaultQueueProcessorFactory(), new FunctionDescriptor { Id = "TestFunction" });

            listener.MinimumVisibilityRenewalInterval = TimeSpan.FromSeconds(1);

            // Set up a function that sleeps to allow renewal
            mockTriggerExecutor
                .Setup(m => m.ExecuteAsync(It.Is<QueueMessage>(msg => msg.DequeueCount == 1), CancellationToken.None))
                .ReturnsAsync(() =>
                {
                    Thread.Sleep(4000);
                    return new FunctionResult(true);
                });

            var previousNextVisibleTime = messageFromCloud.NextVisibleOn;
            var previousPopReceipt = messageFromCloud.PopReceipt;

            // Renewal should happen at 2 seconds
            await listener.ProcessMessageAsync(messageFromCloud, TimeSpan.FromSeconds(4), CancellationToken.None);

            // Check to make sure the renewal occurred.
            Assert.NotEqual(messageFromCloud.NextVisibleOn, previousNextVisibleTime);
            Assert.NotEqual(messageFromCloud.PopReceipt, previousPopReceipt);

            // Make sure the message was processed and deleted.
            QueueProperties queueProperties = await queue.GetPropertiesAsync();
            Assert.Equal(0, queueProperties.ApproximateMessagesCount);
        }

        [LiveFact]
        public void CreateQueueProcessor_CreatesProcessorCorrectly()
        {
            QueueClient poisonQueue = null;
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
            QueueClient queue = new QueueClient(new Uri(string.Format("https://test.queue.core.windows.net/{0}", HostQueueNames.GetHostQueueName("12345"))));
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
            queue = new QueueClient(new Uri(string.Format("https://localhost/{0}", HostQueueNames.GetHostQueueName("12345"))));
            queueProcessor = QueueListener.CreateQueueProcessor(queue, poisonQueue, _loggerFactory, mockQueueProcessorFactory.Object, queueConfig, poisonMessageEventHandler);
            Assert.True(processorFactoryInvoked);
            Assert.Same(expectedQueueProcessor, queueProcessor);

            // create for application queue - expect processor factory to be invoked
            poisonMessageHandlerInvoked = false;
            processorFactoryInvoked = false;
            queue = new QueueClient(new Uri("https://test.queue.core.windows.net/testqueue"));
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

        [LiveFact]
        public async Task ProcessMessageAsync_Success()
        {
            CancellationToken cancellationToken = new CancellationToken();
            FunctionResult result = new FunctionResult(true);
            _mockQueueProcessor.Setup(p => p.BeginProcessingMessageAsync(_queueMessage, cancellationToken)).ReturnsAsync(true);
            _mockTriggerExecutor.Setup(p => p.ExecuteAsync(_queueMessage, cancellationToken)).ReturnsAsync(result);
            _mockQueueProcessor.Setup(p => p.CompleteProcessingMessageAsync(_queueMessage, result, It.IsNotIn(cancellationToken))).Returns(Task.FromResult(true));

            await _listener.ProcessMessageAsync(_queueMessage, TimeSpan.FromMinutes(10), cancellationToken);
        }

        [LiveFact]
        public async Task GetMessages_QueueCheckThrowsTransientError_ReturnsBackoffResult()
        {
            CancellationToken cancellationToken = new CancellationToken();
            _mockQueue.Setup(x => x.ExistsAsync(It.IsAny<CancellationToken>())).ReturnsAsync(Response.FromValue(true, null));
            var exception = new RequestFailedException(
                503,
                string.Empty,
                string.Empty,
                new Exception());

            _mockQueue.Setup(p => p.ReceiveMessagesAsync(It.IsAny<int>(), It.IsAny<TimeSpan>(), cancellationToken)).Throws(exception);

            var result = await _listener.ExecuteAsync(cancellationToken);
#pragma warning disable xUnit2002 // Do not use null check on value type
            Assert.NotNull(result);
#pragma warning restore xUnit2002 // Do not use null check on value type
            await result.Wait;
        }

        [LiveFact]
        public async Task GetMessages_ChecksQueueExistence_UntilQueueExists()
        {
            var cancellationToken = new CancellationToken();
            bool queueExists = false;
            _mockQueue.Setup(p => p.ExistsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => Response.FromValue(queueExists, new MockResponse(queueExists ? 200 : 404)));
            _mockQueue.Setup(p => p.ReceiveMessagesAsync(It.IsAny<int>(), It.IsAny<TimeSpan>(), cancellationToken))
                .ReturnsAsync(Response.FromValue(new QueueMessage[0], new MockResponse(200)));

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

            _mockQueue.Verify(p => p.ExistsAsync(It.IsAny<CancellationToken>()), Times.Exactly(numIterations - numFailedExistenceChecks));
            _mockQueue.Verify(p => p.ReceiveMessagesAsync(It.IsAny<int>(), It.IsAny<TimeSpan>(), cancellationToken), Times.Exactly(numIterations - numFailedExistenceChecks));
        }

        [LiveFact]
        public async Task GetMessages_ResetsQueueExistenceCheck_OnException()
        {
            var cancellationToken = new CancellationToken();
            _mockQueue.Setup(p => p.ExistsAsync(It.IsAny<CancellationToken>())).ReturnsAsync(() => Response.FromValue(true, null));
            var exception = new RequestFailedException(
                503,
                string.Empty,
                string.Empty,
                new Exception());
            _mockQueue.Setup(p => p.ReceiveMessagesAsync(It.IsAny<int>(), It.IsAny<TimeSpan>(), cancellationToken)).Throws(exception);

            for (int i = 0; i < 5; i++)
            {
                var result = await _listener.ExecuteAsync(cancellationToken);
                await result.Wait;
            }

            _mockQueue.Verify(p => p.ExistsAsync(It.IsAny<CancellationToken>()), Times.Exactly(5));
            _mockQueue.Verify(p => p.ReceiveMessagesAsync(It.IsAny<int>(), It.IsAny<TimeSpan>(), cancellationToken), Times.Exactly(5));
        }

        [LiveFact]
        public async Task ProcessMessageAsync_QueueBeginProcessingMessageReturnsFalse_MessageNotProcessed()
        {
            CancellationToken cancellationToken = new CancellationToken();
            _mockQueueProcessor.Setup(p => p.BeginProcessingMessageAsync(_queueMessage, cancellationToken)).ReturnsAsync(false);

            await _listener.ProcessMessageAsync(_queueMessage, TimeSpan.FromMinutes(10), cancellationToken);
        }

        [LiveFact]
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
                        b.AddAzureStorageBlobs().AddAzureStorageQueues();
                    })
                    .Build();

                var storageAccount = host.GetStorageAccount();
                QueueClient = storageAccount.CreateQueueServiceClient();

                string queueName = string.Format("{0}-{1}", TestQueuePrefix, Guid.NewGuid());
                Queue = QueueClient.GetQueueClient(queueName);
                Queue.CreateIfNotExistsAsync().Wait();

                string poisonQueueName = string.Format("{0}-poison", queueName);
                PoisonQueue = QueueClient.GetQueueClient(poisonQueueName);
                PoisonQueue.CreateIfNotExistsAsync().Wait();
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

            public QueueClient CreateNewQueue()
            {
                string queueName = string.Format("{0}-{1}", TestQueuePrefix, Guid.NewGuid());
                var queue = QueueClient.GetQueueClient(queueName);
                queue.CreateIfNotExistsAsync().Wait();
                return queue;
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
