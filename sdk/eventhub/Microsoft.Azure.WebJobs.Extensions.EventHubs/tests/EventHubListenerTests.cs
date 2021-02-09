// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
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
            var eventProcessor = new EventHubListener.EventProcessor(options, executor.Object, loggerMock.Object, true);

            for (int i = 0; i < 100; i++)
            {
                List<EventData> events = new List<EventData>() { new EventData(new byte[0]) };
                await eventProcessor.ProcessEventsAsync(partitionContext, events);
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
            var eventProcessor = new EventHubListener.EventProcessor(options, executor.Object, loggerMock.Object, false);

            for (int i = 0; i < 100; i++)
            {
                List<EventData> events = new List<EventData>() { new EventData(new byte[0]), new EventData(new byte[0]), new EventData(new byte[0]) };
                await eventProcessor.ProcessEventsAsync(partitionContext, events);
            }

            processor.Verify(
                p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>()),
                Times.Exactly(expected));
        }

        /// <summary>
        /// Even if some events in a batch fail, we still checkpoint. Event error handling
        /// is the responsiblity of user function code.
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

            var eventProcessor = new EventHubListener.EventProcessor(options, executor.Object, loggerMock.Object, true);

            await eventProcessor.ProcessEventsAsync(partitionContext, events);

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
            var eventProcessor = new EventHubListener.EventProcessor(options, executor.Object, loggerMock.Object, true);

            await eventProcessor.CloseAsync(partitionContext, ProcessingStoppedReason.Shutdown);

            processor.Verify(
                p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>()),
                Times.Never);
        }

        [Test]
        public async Task ProcessErrorsAsync_LoggedAsError()
        {
            var partitionContext = EventHubTests.GetPartitionContext(partitionId: "123", eventHubPath: "abc", owner: "def");
            var options = new EventHubOptions();
            var executor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            var testLogger = new TestLogger("Test");
            var eventProcessor = new EventHubListener.EventProcessor(options, executor.Object, testLogger, true);

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
            var eventProcessor = new EventHubListener.EventProcessor(options, executor.Object, testLogger, true);

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
            var testLogger = new TestLogger("Test");
            var host = new EventProcessorHost(consumerGroup,
                "Endpoint=sb://test.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=",
                eventHubName,
                new EventProcessorOptions(),
                3,
                false, null);

            var consumerClientMock = new Mock<IEventHubConsumerClient>();
            consumerClientMock.SetupGet(c => c.ConsumerGroup).Returns(consumerGroup);
            consumerClientMock.SetupGet(c => c.EventHubName).Returns(eventHubName);

            var listener = new EventHubListener(
                                    functionId,
                                    Mock.Of<ITriggeredFunctionExecutor>(),
                                    host,
                                    false,
                                    consumerClientMock.Object,
                                    Mock.Of<BlobsCheckpointStore>(),
                                    new EventHubOptions(),
                                    testLogger);

            IScaleMonitor scaleMonitor = listener.GetMonitor();

            Assert.AreEqual(typeof(EventHubsScaleMonitor), scaleMonitor.GetType());
            Assert.AreEqual($"{functionId}-EventHubTrigger-{eventHubName}-{consumerGroup}".ToLower(), scaleMonitor.Descriptor.Id);

            var scaleMonitor2 = listener.GetMonitor();

            Assert.AreSame(scaleMonitor, scaleMonitor2);
        }
    }
}
