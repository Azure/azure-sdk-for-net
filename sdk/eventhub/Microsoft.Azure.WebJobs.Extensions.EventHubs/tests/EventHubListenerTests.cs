// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Storage.Blobs;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.EventHubs.Processor;
using Microsoft.Azure.WebJobs.EventHubs.Listeners;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.Scale;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Blob;
using Moq;
using Xunit;

namespace Microsoft.Azure.WebJobs.EventHubs.UnitTests
{
    public class EventHubListenerTests
    {
        [Theory]
        [InlineData(1, 100)]
        [InlineData(4, 25)]
        [InlineData(8, 12)]
        [InlineData(32, 3)]
        [InlineData(128, 0)]
        public async Task ProcessEvents_SingleDispatch_CheckpointsCorrectly(int batchCheckpointFrequency, int expected)
        {
            var partitionContext = EventHubTests.GetPartitionContext();
            var checkpoints = 0;
            var options = new EventHubOptions
            {
                BatchCheckpointFrequency = batchCheckpointFrequency
            };
            var checkpointer = new Mock<EventHubListener.ICheckpointer>(MockBehavior.Strict);
            checkpointer.Setup(p => p.CheckpointAsync(partitionContext)).Callback<PartitionContext>(c =>
            {
                checkpoints++;
            }).Returns(Task.CompletedTask);
            var loggerMock = new Mock<ILogger>();
            var executor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            executor.Setup(p => p.TryExecuteAsync(It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>())).ReturnsAsync(new FunctionResult(true));
            var eventProcessor = new EventHubListener.EventProcessor(options, executor.Object, loggerMock.Object, true, checkpointer.Object);

            for (int i = 0; i < 100; i++)
            {
                List<EventData> events = new List<EventData>() { new EventData(new byte[0]) };
                await eventProcessor.ProcessEventsAsync(partitionContext, events);
            }

            Assert.Equal(expected, checkpoints);
        }

        [Theory]
        [InlineData(1, 100)]
        [InlineData(4, 25)]
        [InlineData(8, 12)]
        [InlineData(32, 3)]
        [InlineData(128, 0)]
        public async Task ProcessEvents_MultipleDispatch_CheckpointsCorrectly(int batchCheckpointFrequency, int expected)
        {
            var partitionContext = EventHubTests.GetPartitionContext();
            var options = new EventHubOptions
            {
                BatchCheckpointFrequency = batchCheckpointFrequency
            };
            var checkpointer = new Mock<EventHubListener.ICheckpointer>(MockBehavior.Strict);
            checkpointer.Setup(p => p.CheckpointAsync(partitionContext)).Returns(Task.CompletedTask);
            var loggerMock = new Mock<ILogger>();
            var executor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            executor.Setup(p => p.TryExecuteAsync(It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>())).ReturnsAsync(new FunctionResult(true));
            var eventProcessor = new EventHubListener.EventProcessor(options, executor.Object, loggerMock.Object, false, checkpointer.Object);

            for (int i = 0; i < 100; i++)
            {
                List<EventData> events = new List<EventData>() { new EventData(new byte[0]), new EventData(new byte[0]), new EventData(new byte[0]) };
                await eventProcessor.ProcessEventsAsync(partitionContext, events);
            }

            checkpointer.Verify(p => p.CheckpointAsync(partitionContext), Times.Exactly(expected));
        }

        /// <summary>
        /// Even if some events in a batch fail, we still checkpoint. Event error handling
        /// is the responsiblity of user function code.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ProcessEvents_Failure_Checkpoints()
        {
            var partitionContext = EventHubTests.GetPartitionContext();
            var options = new EventHubOptions();
            var checkpointer = new Mock<EventHubListener.ICheckpointer>(MockBehavior.Strict);
            checkpointer.Setup(p => p.CheckpointAsync(partitionContext)).Returns(Task.CompletedTask);

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

            var eventProcessor = new EventHubListener.EventProcessor(options, executor.Object, loggerMock.Object, true, checkpointer.Object);

            await eventProcessor.ProcessEventsAsync(partitionContext, events);

            checkpointer.Verify(p => p.CheckpointAsync(partitionContext), Times.Once);
        }

        [Fact]
        public async Task CloseAsync_Shutdown_DoesNotCheckpoint()
        {
            var partitionContext = EventHubTests.GetPartitionContext();
            var options = new EventHubOptions();
            var checkpointer = new Mock<EventHubListener.ICheckpointer>(MockBehavior.Strict);
            var executor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            var loggerMock = new Mock<ILogger>();
            var eventProcessor = new EventHubListener.EventProcessor(options, executor.Object, loggerMock.Object, true, checkpointer.Object);

            await eventProcessor.CloseAsync(partitionContext, CloseReason.Shutdown);

            checkpointer.Verify(p => p.CheckpointAsync(partitionContext), Times.Never);
        }

        [Fact]
        public async Task ProcessErrorsAsync_LoggedAsError()
        {
            var partitionContext = EventHubTests.GetPartitionContext(partitionId: "123", eventHubPath: "abc", owner: "def");
            var options = new EventHubOptions();
            var checkpointer = new Mock<EventHubListener.ICheckpointer>(MockBehavior.Strict);
            var executor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            var testLogger = new TestLogger("Test");
            var eventProcessor = new EventHubListener.EventProcessor(options, executor.Object, testLogger, true, checkpointer.Object);

            var ex = new InvalidOperationException("My InvalidOperationException!");

            await eventProcessor.ProcessErrorAsync(partitionContext, ex);
            var msg = testLogger.GetLogMessages().Single();
            Assert.Equal("Processing error (Partition Id: '123', Owner: 'def', EventHubPath: 'abc').", msg.FormattedMessage);
            Assert.IsType<InvalidOperationException>(msg.Exception);
            Assert.Equal(LogLevel.Error, msg.Level);
        }

        [Fact]
        public async Task ProcessErrorsAsync_RebalancingExceptions_LoggedAsInformation()
        {
            var partitionContext = EventHubTests.GetPartitionContext(partitionId: "123", eventHubPath: "abc", owner: "def");
            var options = new EventHubOptions();
            var checkpointer = new Mock<EventHubListener.ICheckpointer>(MockBehavior.Strict);
            var executor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            var testLogger = new TestLogger("Test");
            var eventProcessor = new EventHubListener.EventProcessor(options, executor.Object, testLogger, true, checkpointer.Object);

            // ctor is private
            var constructor = typeof(ReceiverDisconnectedException)
                .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(string) }, null);
            ReceiverDisconnectedException disconnectedEx = (ReceiverDisconnectedException)constructor.Invoke(new[] { "My ReceiverDisconnectedException!" });

            await eventProcessor.ProcessErrorAsync(partitionContext, disconnectedEx);
            var msg = testLogger.GetLogMessages().Single();
            Assert.Equal("Processing error (Partition Id: '123', Owner: 'def', EventHubPath: 'abc'). An exception of type 'ReceiverDisconnectedException' was thrown. This exception type is typically a result of Event Hub processor rebalancing or a transient error and can be safely ignored.", msg.FormattedMessage);
            Assert.NotNull(msg.Exception);
            Assert.Equal(LogLevel.Information, msg.Level);

            testLogger.ClearLogMessages();

            // ctor is private
            constructor = typeof(LeaseLostException)
                .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(string), typeof(Exception) }, null);
            LeaseLostException leaseLostEx = (LeaseLostException)constructor.Invoke(new object[] { "My LeaseLostException!", new Exception() });

            await eventProcessor.ProcessErrorAsync(partitionContext, leaseLostEx);
            msg = testLogger.GetLogMessages().Single();
            Assert.Equal("Processing error (Partition Id: '123', Owner: 'def', EventHubPath: 'abc'). An exception of type 'LeaseLostException' was thrown. This exception type is typically a result of Event Hub processor rebalancing or a transient error and can be safely ignored.", msg.FormattedMessage);
            Assert.NotNull(msg.Exception);
            Assert.Equal(LogLevel.Information, msg.Level);
        }

        [Fact]
        public void GetMonitor_ReturnsExpectedValue()
        {
            var functionId = "FunctionId";
            var eventHubName = "EventHubName";
            var consumerGroup = "ConsumerGroup";
            var storageUri = new Uri("https://eventhubsteststorageaccount.blob.core.windows.net/");
            var testLogger = new TestLogger("Test");
            var listener = new EventHubListener(
                                    functionId,
                                    eventHubName,
                                    consumerGroup,
                                    "Endpoint=sb://test.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=abc123=",
                                    "DefaultEndpointsProtocol=https;AccountName=EventHubScaleMonitorFakeTestAccount;AccountKey=ABCDEFG;EndpointSuffix=core.windows.net",
                                    new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict).Object,
                                    null,
                                    false,
                                    new EventHubOptions(),
                                    testLogger,
                                    new Mock<BlobContainerClient>(MockBehavior.Strict, new Uri("https://eventhubsteststorageaccount.blob.core.windows.net/azure-webjobs-eventhub")).Object);

            IScaleMonitor scaleMonitor = listener.GetMonitor();

            Assert.Equal(typeof(EventHubsScaleMonitor), scaleMonitor.GetType());
            Assert.Equal($"{functionId}-EventHubTrigger-{eventHubName}-{consumerGroup}".ToLower(), scaleMonitor.Descriptor.Id);

            var scaleMonitor2 = listener.GetMonitor();

            Assert.Same(scaleMonitor, scaleMonitor2);
        }
    }
}
