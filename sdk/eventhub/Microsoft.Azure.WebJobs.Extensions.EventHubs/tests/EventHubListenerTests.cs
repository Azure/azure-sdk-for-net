// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor;
using Microsoft.Azure.WebJobs.EventHubs.Listeners;
using Microsoft.Azure.WebJobs.EventHubs.Processor;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Listeners;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.EventHubs.UnitTests
{
    public class EventHubListenerTests
    {
        [TestCase(1, 100)]
        [TestCase(4, 25)]
        [TestCase(8, 12)]
        [TestCase(32, 3)]
        [TestCase(128, 0)]
        public async Task ProcessEvents_SingleDispatch_CheckpointsCorrectly(int batchCheckpointFrequency, int expected)
        {
            var partitionContext = EventHubTests.GetPartitionContext();
            var checkpoints = 0;
            var options = new EventHubOptions
            {
                BatchCheckpointFrequency = batchCheckpointFrequency
            };
            var processor = new Mock<EventProcessorHost>(MockBehavior.Strict);
            processor.Setup(p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>())).Callback(() =>
            {
                checkpoints++;
            }).Returns(Task.CompletedTask);
            partitionContext.ProcessorHost = processor.Object;

            var loggerMock = new Mock<ILogger>();
            var executor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            executor.Setup(p => p.TryExecuteAsync(It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>())).ReturnsAsync(new FunctionResult(true));
            var eventProcessor = new EventHubListener.PartitionProcessor(options, executor.Object, loggerMock.Object, true);

            for (int i = 0; i < 100; i++)
            {
                List<EventData> events = new List<EventData>() { new EventData(new byte[0]) };
                await eventProcessor.ProcessEventsAsync(partitionContext, events, CancellationToken.None);
            }

            Assert.AreEqual(expected, checkpoints);
        }

        [TestCase(1, 100)]
        [TestCase(4, 25)]
        [TestCase(8, 12)]
        [TestCase(32, 3)]
        [TestCase(128, 0)]
        public async Task ProcessEvents_MultipleDispatch_CheckpointsCorrectly(int batchCheckpointFrequency, int expected)
        {
            var partitionContext = EventHubTests.GetPartitionContext();
            var options = new EventHubOptions
            {
                BatchCheckpointFrequency = batchCheckpointFrequency
            };

            var processor = new Mock<EventProcessorHost>(MockBehavior.Strict);
            processor.Setup(p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            partitionContext.ProcessorHost = processor.Object;

            var loggerMock = new Mock<ILogger>();
            var executor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            executor.Setup(p => p.TryExecuteAsync(It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>())).ReturnsAsync(new FunctionResult(true));
            var eventProcessor = new EventHubListener.PartitionProcessor(options, executor.Object, loggerMock.Object, false);

            for (int i = 0; i < 100; i++)
            {
                List<EventData> events = new List<EventData>() { new EventData(new byte[0]), new EventData(new byte[0]), new EventData(new byte[0]) };
                await eventProcessor.ProcessEventsAsync(partitionContext, events, CancellationToken.None);
            }

            processor.Verify(
                p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>()),
                Times.Exactly(expected));
        }

        [TestCase(1, 30)]
        [TestCase(5, 6)]
        [TestCase(10, 3)]
        [TestCase(30, 1)]
        [TestCase(35, 0)]
        public async Task ProcessEvents_MultipleDispatch_MinBatch_CheckpointsCorrectly(int batchCheckpointFrequency, int expected)
        {
            var partitionContext = EventHubTests.GetPartitionContext();
            var options = new EventHubOptions
            {
                BatchCheckpointFrequency = batchCheckpointFrequency,
                MinEventBatchSize = 10
            };

            var processor = new Mock<EventProcessorHost>(MockBehavior.Strict);
            processor.Setup(p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            partitionContext.ProcessorHost = processor.Object;

            var loggerMock = new Mock<ILogger>();
            var executor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            executor.Setup(p => p.TryExecuteAsync(It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>())).ReturnsAsync(new FunctionResult(true));

            var eventProcessor = new EventHubListener.PartitionProcessor(options, executor.Object, loggerMock.Object, false);

            for (int i = 0; i < 60; i++)
            {
                List<EventData> events = new List<EventData>() { new EventData("event1"), new EventData("event2"), new EventData("event3"), new EventData("event4"), new EventData("event5") };
                await eventProcessor.ProcessEventsAsync(partitionContext, events, CancellationToken.None);
            }

            processor.Verify(
                p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>()),
                Times.Exactly(expected));
        }

        /// <summary>
        /// Even if some events in a batch fail, we still checkpoint. Event error handling
        /// is the responsibility of user function code.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ProcessEvents_Failure_Checkpoints()
        {
            var partitionContext = EventHubTests.GetPartitionContext();
            var options = new EventHubOptions();

            var processor = new Mock<EventProcessorHost>(MockBehavior.Strict);
            processor.Setup(p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            partitionContext.ProcessorHost = processor.Object;

            List<EventData> events = new List<EventData>();
            List<FunctionResult> results = new List<FunctionResult>();
            for (int i = 0; i < 10; i++)
            {
                events.Add(new EventData(new byte[0]));
                var succeeded = i > 7 ? false : true;
                results.Add(new FunctionResult(succeeded));
            }

            var executor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            int execution = 0;
            executor.Setup(p => p.TryExecuteAsync(It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>())).ReturnsAsync(() =>
            {
                var result = results[execution++];
                return result;
            });

            var loggerMock = new Mock<ILogger>();

            var eventProcessor = new EventHubListener.PartitionProcessor(options, executor.Object, loggerMock.Object, true);

            await eventProcessor.ProcessEventsAsync(partitionContext, events, CancellationToken.None);

            processor.Verify(
                p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [Test]
        public async Task CloseAsync_Shutdown_DoesNotCheckpoint()
        {
            var partitionContext = EventHubTests.GetPartitionContext();
            var options = new EventHubOptions();

            var processor = new Mock<EventProcessorHost>(MockBehavior.Strict);
            processor.Setup(p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            partitionContext.ProcessorHost = processor.Object;

            var executor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            var loggerMock = new Mock<ILogger>();
            var eventProcessor = new EventHubListener.PartitionProcessor(options, executor.Object, loggerMock.Object, true);

            await eventProcessor.CloseAsync(partitionContext, ProcessingStoppedReason.Shutdown);

            processor.Verify(
                p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>()),
                Times.Never);
        }

        [Test]
        public async Task Partition_OwnershipLost_DropsEvents()
        {
            var partitionContext = EventHubTests.GetPartitionContext();
            var options = new EventHubOptions();

            var processor = new Mock<EventProcessorHost>(MockBehavior.Strict);
            processor.Setup(p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            partitionContext.ProcessorHost = processor.Object;

            var executor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            var loggerMock = new Mock<ILogger>();
            var eventProcessor = new EventHubListener.PartitionProcessor(options, executor.Object, loggerMock.Object, true);
            var mockStoredEvents = new Queue<EventData>();
            mockStoredEvents.Enqueue(new EventData("E1"));
            eventProcessor.CachedEventsManager.CachedEvents = mockStoredEvents;

            await eventProcessor.CloseAsync(partitionContext, ProcessingStoppedReason.OwnershipLost);

            Assert.IsFalse(eventProcessor.CachedEventsManager.HasCachedEvents);
        }

        [Test]
        public async Task ProcessErrorsAsync_LoggedAsError()
        {
            var partitionContext = EventHubTests.GetPartitionContext(partitionId: "123", eventHubPath: "abc", owner: "def");
            var options = new EventHubOptions();
            var executor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            var testLogger = new TestLogger("Test");
            var eventProcessor = new EventHubListener.PartitionProcessor(options, executor.Object, testLogger, true);

            var ex = new InvalidOperationException("My InvalidOperationException!");

            await eventProcessor.ProcessErrorAsync(partitionContext, ex);
            var msg = testLogger.GetLogMessages().Single();
            StringAssert.IsMatch("Processing error \\(Partition Id: '123', Owner: '[\\w\\d-]+', EventHubPath: 'abc'\\).", msg.FormattedMessage);
            Assert.IsInstanceOf<InvalidOperationException>(msg.Exception);
            Assert.AreEqual(LogLevel.Error, msg.Level);
        }

        [Test]
        public async Task ProcessErrorsAsync_RebalancingExceptions_LoggedAsInformation()
        {
            var partitionContext = EventHubTests.GetPartitionContext(partitionId: "123", eventHubPath: "abc", owner: "def");
            var options = new EventHubOptions();
            var executor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            var testLogger = new TestLogger("Test");
            var eventProcessor = new EventHubListener.PartitionProcessor(options, executor.Object, testLogger, true);

            var disconnectedEx = new EventHubsException(true, "My ReceiverDisconnectedException!", EventHubsException.FailureReason.ConsumerDisconnected);

            await eventProcessor.ProcessErrorAsync(partitionContext, disconnectedEx);
            var msg = testLogger.GetLogMessages().Single();
            StringAssert.IsMatch("Processing error \\(Partition Id: '123', Owner: '[\\w\\d-]+', EventHubPath: 'abc'\\). An exception of type 'EventHubsException' was thrown. This exception type is typically a result of Event Hub processor rebalancing or a transient error and can be safely ignored.", msg.FormattedMessage);
            Assert.NotNull(msg.Exception);
            Assert.AreEqual(LogLevel.Information, msg.Level);

            testLogger.ClearLogMessages();

            var leaseLostEx = new EventHubsException(true, "My LeaseLostException!", EventHubsException.FailureReason.ConsumerDisconnected);

            await eventProcessor.ProcessErrorAsync(partitionContext, leaseLostEx);
            msg = testLogger.GetLogMessages().Single();
            StringAssert.IsMatch("Processing error \\(Partition Id: '123', Owner: '[\\w\\d-]+', EventHubPath: 'abc'\\). An exception of type 'EventHubsException' was thrown. This exception type is typically a result of Event Hub processor rebalancing or a transient error and can be safely ignored.", msg.FormattedMessage);
            Assert.NotNull(msg.Exception);
            Assert.AreEqual(LogLevel.Information, msg.Level);
        }

        [Test]
        public void GetMonitor_ReturnsExpectedValue()
        {
            var functionId = "FunctionId";
            var eventHubName = "EventHubName";
            var consumerGroup = "ConsumerGroup";
            var host = new EventProcessorHost(consumerGroup,
                "Endpoint=sb://test.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=",
                eventHubName,
                new EventProcessorOptions(),
                3,null);

            var consumerClientMock = new Mock<IEventHubConsumerClient>();
            consumerClientMock.SetupGet(c => c.ConsumerGroup).Returns(consumerGroup);
            consumerClientMock.SetupGet(c => c.EventHubName).Returns(eventHubName);

            var listener = new EventHubListener(
                                    functionId,
                                    Mock.Of<ITriggeredFunctionExecutor>(),
                                    host,
                                    false,
                                    consumerClientMock.Object,
                                    Mock.Of<BlobCheckpointStoreInternal>(),
                                    new EventHubOptions(),
                                    Mock.Of<LoggerFactory>());

            IScaleMonitor scaleMonitor = listener.GetMonitor();

            Assert.AreEqual(typeof(EventHubsScaleMonitor), scaleMonitor.GetType());
            Assert.AreEqual($"{functionId}-EventHubTrigger-{eventHubName}-{consumerGroup}".ToLower(), scaleMonitor.Descriptor.Id);

            var scaleMonitor2 = listener.GetMonitor();

            Assert.AreSame(scaleMonitor, scaleMonitor2);
        }

        [Test]
        public void Dispose_StopsTheProcessor()
        {
            var functionId = "FunctionId";
            var eventHubName = "EventHubName";
            var consumerGroup = "ConsumerGroup";
            var host = new Mock<EventProcessorHost>(consumerGroup,
                "Endpoint=sb://test.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=",
                eventHubName,
                new EventProcessorOptions(),
                3,null);
            host.Setup(h => h.StopProcessingAsync(CancellationToken.None)).Returns(Task.CompletedTask);

            var consumerClientMock = new Mock<IEventHubConsumerClient>();
            consumerClientMock.SetupGet(c => c.ConsumerGroup).Returns(consumerGroup);
            consumerClientMock.SetupGet(c => c.EventHubName).Returns(eventHubName);

            var listener = new EventHubListener(
                functionId,
                Mock.Of<ITriggeredFunctionExecutor>(),
                host.Object,
                false,
                consumerClientMock.Object,
                Mock.Of<BlobCheckpointStoreInternal>(),
                new EventHubOptions(),
                Mock.Of<LoggerFactory>());

            (listener as IListener).Dispose();
            host.Verify(h => h.StopProcessingAsync(CancellationToken.None), Times.Once);

            (listener as IListener).Cancel();
            host.Verify(h => h.StopProcessingAsync(CancellationToken.None), Times.Exactly(2));
        }

        [Test]
        public async Task ProcessEvents_CancellationToken_CancelsExecution()
        {
            var partitionContext = EventHubTests.GetPartitionContext();
            var options = new EventHubOptions();
            var processor = new Mock<EventProcessorHost>(MockBehavior.Strict);
            processor.Setup(p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            partitionContext.ProcessorHost = processor.Object;

            var loggerMock = new Mock<ILogger>();
            var executor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            executor.Setup(p => p.TryExecuteAsync(It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>()))
            .Callback<TriggeredFunctionData, CancellationToken>(async (TriggeredFunctionData triggeredFunctionData, CancellationToken cancellationToken) =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(100);
                }
            })
            .ReturnsAsync(new FunctionResult(true));
            var eventProcessor = new EventHubListener.PartitionProcessor(options, executor.Object, loggerMock.Object, true);
            List<EventData> events = new List<EventData>() { new EventData(new byte[0]) };
            CancellationTokenSource source = new CancellationTokenSource();
            // Start another thread to cancel execution
            _ = Task.Run(async () =>
            {
                await Task.Delay(500);
            });
            await eventProcessor.ProcessEventsAsync(partitionContext, events, source.Token);
        }
    }
}
