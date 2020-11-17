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
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Listeners;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Listeners;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Queues;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.Host.Timers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues
{
    public class QueueListenerTests : LiveTestBase<WebJobsTestEnvironment>
    {
        private Mock<QueueClient> _mockQueue;
        private QueueListener _listener;
        private Mock<QueueProcessor> _mockQueueProcessor;
        private Mock<ITriggerExecutor<QueueMessage>> _mockTriggerExecutor;
        private QueueMessage _queueMessage;
        private ILoggerFactory _loggerFactory;
        private TestLoggerProvider _loggerProvider;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Fixture = new TestFixture();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Fixture.Dispose();
        }

        [SetUp]
        public void SetUp()
        {
            _mockQueue = new Mock<QueueClient>(new Uri("https://test.queue.core.windows.net/testqueue"), null);
            _mockQueue.Setup(x => x.Name).Returns("testqueue");

            _mockTriggerExecutor = new Mock<ITriggerExecutor<QueueMessage>>(MockBehavior.Strict);
            Mock<IWebJobsExceptionHandler> mockExceptionDispatcher = new Mock<IWebJobsExceptionHandler>(MockBehavior.Strict);
            _loggerFactory = new LoggerFactory();
            _loggerProvider = new TestLoggerProvider();
            _loggerFactory.AddProvider(_loggerProvider);
            QueuesOptions queuesOptions = new QueuesOptions();
            QueueProcessorOptions context = new QueueProcessorOptions(_mockQueue.Object, _loggerFactory, queuesOptions);

            _mockQueueProcessor = new Mock<QueueProcessor>(MockBehavior.Strict, context);
            QueuesOptions queueConfig = new QueuesOptions
            {
                MaxDequeueCount = 5
            };

            _listener = new QueueListener(_mockQueue.Object, null, _mockTriggerExecutor.Object, mockExceptionDispatcher.Object, _loggerFactory, null, queueConfig, _mockQueueProcessor.Object, new FunctionDescriptor { Id = "TestFunction" });
            _queueMessage = QueuesModelFactory.QueueMessage("TestId", "TestPopReceipt", "TestMessage", 0);
        }

        public TestFixture Fixture { get; set; }

        [Test]
        public void ScaleMonitor_Id_ReturnsExpectedValue()
        {
            Assert.AreEqual("testfunction-queuetrigger-testqueue", _listener.Descriptor.Id);
        }

        [Test]
        public async Task GetMetrics_ReturnsExpectedResult()
        {
            var queuesOptions = new QueuesOptions();
            Mock<ITriggerExecutor<QueueMessage>> mockTriggerExecutor = new Mock<ITriggerExecutor<QueueMessage>>(MockBehavior.Strict);
            var queueProcessorFactory = new DefaultQueueProcessorFactory();
            var queueProcessor = QueueListenerFactory.CreateQueueProcessor(Fixture.Queue, null, _loggerFactory, queueProcessorFactory, queuesOptions, null);
            QueueListener listener = new QueueListener(Fixture.Queue, null, mockTriggerExecutor.Object, new WebJobsExceptionHandler(null),
                _loggerFactory, null, queuesOptions, queueProcessor, new FunctionDescriptor { Id = "TestFunction" });

            var metrics = await listener.GetMetricsAsync();

            Assert.AreEqual(0, metrics.QueueLength);
            Assert.AreEqual(TimeSpan.Zero, metrics.QueueTime);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            // add some test messages
            for (int i = 0; i < 5; i++)
            {
                await Fixture.Queue.SendMessageAsync($"Message {i}");
            }

            await Task.Delay(TimeSpan.FromSeconds(5));

            metrics = await listener.GetMetricsAsync();

            Assert.AreEqual(5, metrics.QueueLength);
            Assert.True(metrics.QueueTime.Ticks > 0);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            // verify non-generic interface works as expected
            metrics = (QueueTriggerMetrics)(await ((IScaleMonitor)listener).GetMetricsAsync());
            Assert.AreEqual(5, metrics.QueueLength);
        }

        [Test]
        public async Task GetMetrics_HandlesStorageExceptions()
        {
            var exception = new RequestFailedException(
                500,
                "Things are very wrong.",
                default,
                new Exception());

            _mockQueue.Setup(p => p.GetPropertiesAsync(It.IsAny<CancellationToken>())).Throws(exception);

            var metrics = await _listener.GetMetricsAsync();

            Assert.AreEqual(0, metrics.QueueLength);
            Assert.AreEqual(TimeSpan.Zero, metrics.QueueTime);
            Assert.AreNotEqual(default(DateTime), metrics.Timestamp);

            var warning = _loggerProvider.GetAllLogMessages().Single(p => p.Level == Microsoft.Extensions.Logging.LogLevel.Warning);
            Assert.AreEqual("Error querying for queue scale status: Things are very wrong.", warning.FormattedMessage);
        }

        [Test]
        public void GetScaleStatus_NoMetrics_ReturnsVote_None()
        {
            var context = new ScaleStatusContext<QueueTriggerMetrics>
            {
                WorkerCount = 1
            };

            var status = _listener.GetScaleStatus(context);
            Assert.AreEqual(ScaleVote.None, status.Vote);

            // verify the non-generic implementation works properly
            status = ((IScaleMonitor)_listener).GetScaleStatus(context);
            Assert.AreEqual(ScaleVote.None, status.Vote);
        }

        [Test]
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

            Assert.AreEqual(ScaleVote.ScaleOut, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.AreEqual(Microsoft.Extensions.Logging.LogLevel.Information, log.Level);
            Assert.AreEqual("QueueLength (2900) > workerCount (1) * 1,000", log.FormattedMessage);
            log = logs[1];
            Assert.AreEqual(Microsoft.Extensions.Logging.LogLevel.Information, log.Level);
            Assert.AreEqual($"Length of queue (testqueue, 2900) is too high relative to the number of instances (1).", log.FormattedMessage);

            // verify again with a non generic context instance
            var context2 = new ScaleStatusContext
            {
                WorkerCount = 1,
                Metrics = queueTriggerMetrics
            };
            status = ((IScaleMonitor)_listener).GetScaleStatus(context2);
            Assert.AreEqual(ScaleVote.ScaleOut, status.Vote);
        }

        [Test]
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

            Assert.AreEqual(ScaleVote.ScaleOut, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.AreEqual(Microsoft.Extensions.Logging.LogLevel.Information, log.Level);
            Assert.AreEqual("Queue length is increasing for 'testqueue'", log.FormattedMessage);
        }

        [Test]
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

            Assert.AreEqual(ScaleVote.ScaleOut, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.AreEqual(Microsoft.Extensions.Logging.LogLevel.Information, log.Level);
            Assert.AreEqual("Queue time is increasing for 'testqueue'", log.FormattedMessage);
        }

        [Test]
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

            Assert.AreEqual(ScaleVote.ScaleIn, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.AreEqual(Microsoft.Extensions.Logging.LogLevel.Information, log.Level);
            Assert.AreEqual("Queue length is decreasing for 'testqueue'", log.FormattedMessage);
        }

        [Test]
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

            Assert.AreEqual(ScaleVote.ScaleIn, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.AreEqual(Microsoft.Extensions.Logging.LogLevel.Information, log.Level);
            Assert.AreEqual("Queue time is decreasing for 'testqueue'", log.FormattedMessage);
        }

        [Test]
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

            Assert.AreEqual(ScaleVote.None, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.AreEqual(Microsoft.Extensions.Logging.LogLevel.Information, log.Level);
            Assert.AreEqual("Queue 'testqueue' is steady", log.FormattedMessage);
        }

        [Test]
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

            Assert.AreEqual(ScaleVote.ScaleIn, status.Vote);

            var logs = _loggerProvider.GetAllLogMessages().ToArray();
            var log = logs[0];
            Assert.AreEqual(Microsoft.Extensions.Logging.LogLevel.Information, log.Level);
            Assert.AreEqual("Queue 'testqueue' is idle", log.FormattedMessage);
        }

        [Test]
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

            Assert.AreEqual(ScaleVote.None, status.Vote);
        }

        [Test]
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
            var queueProcessor = QueueListenerFactory.CreateQueueProcessor(queue, poisonQueue, NullLoggerFactory.Instance, queueProcessorFactory, queuesOptions, null);

            QueueListener listener = new QueueListener(queue, poisonQueue, mockTriggerExecutor.Object, new WebJobsExceptionHandler(null),
                NullLoggerFactory.Instance, null, queuesOptions, queueProcessor, new FunctionDescriptor { Id = "TestFunction" });

            mockTriggerExecutor
                .Setup(m => m.ExecuteAsync(It.IsAny<QueueMessage>(), CancellationToken.None))
                .ReturnsAsync(new FunctionResult(false));

            await listener.ProcessMessageAsync(messageFromCloud, TimeSpan.FromMinutes(10), CancellationToken.None);

            // pull the message and process it again (to have it go through the poison queue flow)
            messageFromCloud = (await queue.ReceiveMessagesAsync(1)).Value.FirstOrDefault();
            Assert.AreEqual(2, messageFromCloud.DequeueCount);

            await listener.ProcessMessageAsync(messageFromCloud, TimeSpan.FromMinutes(10), CancellationToken.None);

            // Make sure the message was processed and deleted.
            QueueProperties queueProperties = await queue.GetPropertiesAsync();
            Assert.AreEqual(0, queueProperties.ApproximateMessagesCount);

            // The Listener has inserted a message to the poison queue.
            QueueProperties poisonQueueProperties = await poisonQueue.GetPropertiesAsync();
            Assert.AreEqual(1, poisonQueueProperties.ApproximateMessagesCount);

            mockTriggerExecutor.Verify(m => m.ExecuteAsync(It.IsAny<QueueMessage>(), CancellationToken.None), Times.Exactly(2));
        }

        [Test]
        public async Task RenewedQueueMessage_DeletesCorrectly()
        {
            QueueClient queue = Fixture.CreateNewQueue();

            Mock<ITriggerExecutor<QueueMessage>> mockTriggerExecutor = new Mock<ITriggerExecutor<QueueMessage>>(MockBehavior.Strict);

            string messageContent = Guid.NewGuid().ToString();
            await queue.SendMessageAsync(messageContent);
            QueueMessage messageFromCloud = await queue.ReceiveMessageAsync();

            var queuesOptions = new QueuesOptions();
            var queueProcessorFactory = new DefaultQueueProcessorFactory();
            var queueProcessor = QueueListenerFactory.CreateQueueProcessor(queue, null, _loggerFactory, queueProcessorFactory, queuesOptions, null);
            QueueListener listener = new QueueListener(queue, null, mockTriggerExecutor.Object, new WebJobsExceptionHandler(null),
                _loggerFactory, null, queuesOptions, queueProcessor, new FunctionDescriptor { Id = "TestFunction" });

            listener.MinimumVisibilityRenewalInterval = TimeSpan.FromSeconds(1);

            // Set up a function that sleeps to allow renewal
            mockTriggerExecutor
                .Setup(m => m.ExecuteAsync(It.Is<QueueMessage>(msg => msg.DequeueCount == 1), CancellationToken.None))
                .ReturnsAsync(() =>
                {
                    Thread.Sleep(4000);
                    return new FunctionResult(true);
                });

            // Renewal should happen at 2 seconds
            await listener.ProcessMessageAsync(messageFromCloud, TimeSpan.FromSeconds(4), CancellationToken.None);

            // Make sure the message was processed and deleted.
            await Task.Delay(TimeSpan.FromSeconds(10));
            messageFromCloud = await queue.ReceiveMessageAsync();
            Assert.IsNull(messageFromCloud);
        }

        [Test]
        public void CreateQueueProcessor_CreatesProcessorCorrectly()
        {
            QueueClient poisonQueue = Mock.Of<QueueClient>();
            bool poisonMessageHandlerInvoked = false;
            Mock<IMessageEnqueuedWatcher> watcherMock = new Mock<IMessageEnqueuedWatcher>();
            watcherMock.Setup(x => x.Notify(It.IsAny<string>())).Callback(() => poisonMessageHandlerInvoked = true);
            Mock<IQueueProcessorFactory> mockQueueProcessorFactory = new Mock<IQueueProcessorFactory>(MockBehavior.Strict);
            QueuesOptions queueConfig = new QueuesOptions
            {
                MaxDequeueCount = 7
            };
            QueueProcessor expectedQueueProcessor = null;
            bool processorFactoryInvoked = false;

            // create for a host queue - don't expect custom factory to be invoked
            QueueClient queue = new QueueClient(new Uri(string.Format("https://test.queue.core.windows.net/{0}", HostQueueNames.GetHostQueueName("12345"))));
            QueueProcessor queueProcessor = QueueListenerFactory.CreateQueueProcessor(queue, poisonQueue, _loggerFactory, mockQueueProcessorFactory.Object, queueConfig, watcherMock.Object) as QueueProcessor;
            Assert.False(processorFactoryInvoked);
            Assert.AreNotSame(expectedQueueProcessor, queueProcessor);
            queueProcessor.OnMessageAddedToPoisonQueue(new PoisonMessageEventArgs(null, poisonQueue));
            Assert.True(poisonMessageHandlerInvoked);

            QueueProcessorOptions processorFactoryContext = null;
            mockQueueProcessorFactory.Setup(p => p.Create(It.IsAny<QueueProcessorOptions>()))
                .Callback<QueueProcessorOptions>((mockProcessorContext) =>
                {
                    processorFactoryInvoked = true;

                    Assert.AreSame(queue, mockProcessorContext.Queue);
                    Assert.AreSame(poisonQueue, mockProcessorContext.PoisonQueue);
                    Assert.AreEqual(queueConfig.MaxDequeueCount, mockProcessorContext.Options.MaxDequeueCount);
                    Assert.NotNull(mockProcessorContext.Logger);

                    processorFactoryContext = mockProcessorContext;
                })
                .Returns(() =>
                {
                    expectedQueueProcessor = new QueueProcessor(processorFactoryContext);
                    return expectedQueueProcessor;
                });

            // create for application queue - expect processor factory to be invoked
            poisonMessageHandlerInvoked = false;
            processorFactoryInvoked = false;
            queue = new QueueClient(new Uri("https://test.queue.core.windows.net/testqueue"));
            queueProcessor = QueueListenerFactory.CreateQueueProcessor(queue, poisonQueue, _loggerFactory, mockQueueProcessorFactory.Object, queueConfig, watcherMock.Object) as QueueProcessor;
            Assert.True(processorFactoryInvoked);
            Assert.AreSame(expectedQueueProcessor, queueProcessor);
            queueProcessor.OnMessageAddedToPoisonQueue(new PoisonMessageEventArgs(null, poisonQueue));
            Assert.True(poisonMessageHandlerInvoked);

            // if poison message watcher not specified, event not subscribed to
            poisonMessageHandlerInvoked = false;
            processorFactoryInvoked = false;
            queueProcessor = QueueListenerFactory.CreateQueueProcessor(queue, poisonQueue, _loggerFactory, mockQueueProcessorFactory.Object, queueConfig, null) as QueueProcessor;
            Assert.True(processorFactoryInvoked);
            Assert.AreSame(expectedQueueProcessor, queueProcessor);
            queueProcessor.OnMessageAddedToPoisonQueue(new PoisonMessageEventArgs(null, poisonQueue));
            Assert.False(poisonMessageHandlerInvoked);
        }

        [Test]
        public async Task ProcessMessageAsync_Success()
        {
            CancellationToken cancellationToken = new CancellationToken();
            FunctionResult result = new FunctionResult(true);
            _mockQueueProcessor.Setup(p => p.BeginProcessingMessageAsync(_queueMessage, cancellationToken)).ReturnsAsync(true);
            _mockTriggerExecutor.Setup(p => p.ExecuteAsync(_queueMessage, cancellationToken)).ReturnsAsync(result);
            _mockQueueProcessor.Setup(p => p.CompleteProcessingMessageAsync(_queueMessage, result, It.IsNotIn(cancellationToken))).Returns(Task.FromResult(true));

            await _listener.ProcessMessageAsync(_queueMessage, TimeSpan.FromMinutes(10), cancellationToken);
        }

        [Test]
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
            Assert.NotNull(result);
            await result.Wait;
        }

        [Test]
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

        [Test]
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

        [Test]
        public async Task ProcessMessageAsync_QueueBeginProcessingMessageReturnsFalse_MessageNotProcessed()
        {
            CancellationToken cancellationToken = new CancellationToken();
            _mockQueueProcessor.Setup(p => p.BeginProcessingMessageAsync(_queueMessage, cancellationToken)).ReturnsAsync(false);

            await _listener.ProcessMessageAsync(_queueMessage, TimeSpan.FromMinutes(10), cancellationToken);
        }

        [Test]
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
                        b.AddAzureStorageQueues();
                    })
                    .Build();

                var queueServiceClientProvider = host.Services.GetRequiredService<QueueServiceClientProvider>();
                QueueClient = queueServiceClientProvider.GetHost();

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
