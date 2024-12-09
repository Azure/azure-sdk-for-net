// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// Ignore Spelling: Checkpointing Rebalancing

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor;
using Azure.Messaging.EventHubs.Tests;
using Microsoft.Azure.WebJobs.EventHubs.Listeners;
using Microsoft.Azure.WebJobs.EventHubs.Processor;
using Microsoft.Azure.WebJobs.Host;
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
            var eventProcessor = new EventHubListener.PartitionProcessor(options, executor.Object, loggerMock.Object, true, default, default);

            for (int i = 0; i < 100; i++)
            {
                List<EventData> events = new List<EventData>() { new EventData(new byte[0]) };
                await eventProcessor.ProcessEventsAsync(partitionContext, events);
            }

            try
            {
                eventProcessor.Dispose();
            }
            catch (OperationCanceledException)
            {
                // Expected; ignore.
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
            var eventProcessor = new EventHubListener.PartitionProcessor(options, executor.Object, loggerMock.Object, false, default, default);

            for (int i = 0; i < 100; i++)
            {
                List<EventData> events = new List<EventData>() { new EventData(new byte[0]), new EventData(new byte[0]), new EventData(new byte[0]) };
                await eventProcessor.ProcessEventsAsync(partitionContext, events);
            }

            try
            {
                eventProcessor.Dispose();
            }
            catch (OperationCanceledException)
            {
                // Expected; ignore.
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
        public async Task ProcessEvents_MultipleDispatch_MinBatch_CheckpointsCorrectly_NoCheckpoint(int batchCheckpointFrequency, int expected)
        {
            var partitionContext = EventHubTests.GetPartitionContext();
            var options = new EventHubOptions
            {
                BatchCheckpointFrequency = batchCheckpointFrequency,
                MaxWaitTime = TimeSpan.FromSeconds(60),
                MinEventBatchSize = 10
            };

            var processor = new Mock<EventProcessorHost>(MockBehavior.Strict);
            processor.Setup(p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            processor.Setup(p => p.GetLastReadCheckpoint(partitionContext.PartitionId)).Returns(() => null);
            partitionContext.ProcessorHost = processor.Object;

            var loggerMock = new Mock<ILogger>();
            var executor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            executor.Setup(p => p.TryExecuteAsync(It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>())).ReturnsAsync(new FunctionResult(true));

            var eventProcessor = new EventHubListener.PartitionProcessor(options, executor.Object, loggerMock.Object, false, default, default);

            for (int i = 0; i < 60; i++)
            {
                List<EventData> events = new List<EventData>() { new EventData("event1"), new EventData("event2"), new EventData("event3"), new EventData("event4"), new EventData("event5") };
                await eventProcessor.ProcessEventsAsync(partitionContext, events);
            }

            try
            {
                eventProcessor.Dispose();
            }
            catch (OperationCanceledException)
            {
                // Expected; ignore.
            }

            // Because the first invocation will allow a partial batch due to the old checkpoint,
            // the last 5 events will remain in the cache after disposing and stopping the background task.
            Assert.NotNull(eventProcessor.CachedEventsManager);
            Assert.AreEqual(5, eventProcessor.CachedEventsManager.CachedEvents.Count);

            processor.Verify(
                p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>()),
                Times.Exactly(expected));

            processor.Verify(
                p => p.GetLastReadCheckpoint(partitionContext.PartitionId),
                Times.AtLeastOnce);
        }

        [TestCase(1, 30)]
        [TestCase(5, 6)]
        [TestCase(10, 3)]
        [TestCase(30, 1)]
        [TestCase(35, 0)]
        public async Task ProcessEvents_MultipleDispatch_MinBatch_CheckpointsCorrectly_RecentCheckpoint(int batchCheckpointFrequency, int expected)
        {
            var partitionContext = EventHubTests.GetPartitionContext();

            var options = new EventHubOptions
            {
                BatchCheckpointFrequency = batchCheckpointFrequency,
                MaxWaitTime = TimeSpan.FromSeconds(60),
                MinEventBatchSize = 10
            };

            var processor = new Mock<EventProcessorHost>(MockBehavior.Strict);
            processor.Setup(p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            processor.Setup(p => p.GetLastReadCheckpoint(partitionContext.PartitionId)).Returns(() => new CheckpointInfo("123:1:11", 45678, DateTimeOffset.UtcNow.Subtract(TimeSpan.FromSeconds(1))));
            partitionContext.ProcessorHost = processor.Object;

            var loggerMock = new Mock<ILogger>();
            var executor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            executor.Setup(p => p.TryExecuteAsync(It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>())).ReturnsAsync(new FunctionResult(true));

            var eventProcessor = new EventHubListener.PartitionProcessor(options, executor.Object, loggerMock.Object, false, default, default);

            for (int i = 0; i < 60; i++)
            {
                List<EventData> events = new List<EventData>() { new EventData("event1"), new EventData("event2"), new EventData("event3"), new EventData("event4"), new EventData("event5") };
                await eventProcessor.ProcessEventsAsync(partitionContext, events);
            }

            try
            {
                eventProcessor.Dispose();
            }
            catch (OperationCanceledException)
            {
                // Expected; ignore.
            }

            Assert.NotNull(eventProcessor.CachedEventsManager);
            Assert.AreEqual(0, eventProcessor.CachedEventsManager.CachedEvents.Count);

            processor.Verify(
                p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>()),
                Times.Exactly(expected));

            processor.Verify(
                p => p.GetLastReadCheckpoint(partitionContext.PartitionId),
                Times.AtLeastOnce);
        }

        [TestCase(1, 30)]
        [TestCase(5, 6)]
        [TestCase(10, 3)]
        [TestCase(30, 1)]
        [TestCase(35, 0)]
        public async Task ProcessEvents_MultipleDispatch_MinBatch_CheckpointsCorrectly_OldCheckpoint(int batchCheckpointFrequency, int expected)
        {
            var partitionContext = EventHubTests.GetPartitionContext();

            var options = new EventHubOptions
            {
                BatchCheckpointFrequency = batchCheckpointFrequency,
                MaxWaitTime = TimeSpan.FromSeconds(60),
                MinEventBatchSize = 10
            };

            var processor = new Mock<EventProcessorHost>(MockBehavior.Strict);
            processor.Setup(p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            processor.Setup(p => p.GetLastReadCheckpoint(partitionContext.PartitionId)).Returns(() => new CheckpointInfo("123", 45678, DateTimeOffset.UtcNow.Subtract(TimeSpan.FromHours(1))));
            partitionContext.ProcessorHost = processor.Object;

            var loggerMock = new Mock<ILogger>();
            var executor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            executor.Setup(p => p.TryExecuteAsync(It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>())).ReturnsAsync(new FunctionResult(true));

            var eventProcessor = new EventHubListener.PartitionProcessor(options, executor.Object, loggerMock.Object, false, default, default);

            for (int i = 0; i < 60; i++)
            {
                List<EventData> events = new List<EventData>() { new EventData("event1"), new EventData("event2"), new EventData("event3"), new EventData("event4"), new EventData("event5") };
                await eventProcessor.ProcessEventsAsync(partitionContext, events);
            }

            try
            {
                eventProcessor.Dispose();
            }
            catch (OperationCanceledException)
            {
                // Expected; ignore.
            }

            // Because the first invocation will allow a partial batch due to the old checkpoint,
            // the last 5 events will remain in the cache after disposing and stopping the background task.
            Assert.NotNull(eventProcessor.CachedEventsManager);
            Assert.AreEqual(5, eventProcessor.CachedEventsManager.CachedEvents.Count);

            processor.Verify(
                p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>()),
                Times.Exactly(expected));

            processor.Verify(
                p => p.GetLastReadCheckpoint(partitionContext.PartitionId),
                Times.AtLeastOnce);
        }

        [Test]
        public async Task ProcessEvents_MultipleDispatch_MinBatch_BackgroundInvokesPartialBatch()
        {
            var partitionContext = EventHubTests.GetPartitionContext();

            var options = new EventHubOptions
            {
                BatchCheckpointFrequency = 1,
                MaxWaitTime = TimeSpan.FromSeconds(20),
                MinEventBatchSize = 10
            };

            var processor = new Mock<EventProcessorHost>(MockBehavior.Strict);
            processor.Setup(p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            processor.Setup(p => p.GetLastReadCheckpoint(partitionContext.PartitionId)).Returns(() => new CheckpointInfo("123", 45678, DateTimeOffset.UtcNow.Subtract(TimeSpan.FromHours(1))));
            partitionContext.ProcessorHost = processor.Object;

            // Because the first invocation will allow a partial batch due to the old checkpoint,
            // the last 5 events will remain in the cache until the background task invokes.  We
            // expect to see 28 invocations with full batches and 2 partials.
            var expectedInvocations = 31;
            var invocations = 0;
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var loggerMock = new Mock<ILogger>();
            var executor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);

            executor
                .Setup(p => p.TryExecuteAsync(It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>()))
                .Callback(() =>
                {
                    if (++invocations == expectedInvocations)
                    {
                        completionSource.TrySetResult(true);
                    }
                })
                .ReturnsAsync(new FunctionResult(true));

            var eventProcessor = new EventHubListener.PartitionProcessor(options, executor.Object, loggerMock.Object, false, default, default);

            for (int i = 0; i < 60; i++)
            {
                List<EventData> events = new List<EventData>() { new EventData("event1"), new EventData("event2"), new EventData("event3"), new EventData("event4"), new EventData("event5") };
                await eventProcessor.ProcessEventsAsync(partitionContext, events);
            }

            await completionSource.Task.TimeoutAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            try
            {
                eventProcessor.Dispose();
            }
            catch (OperationCanceledException)
            {
                // Expected; ignore.
            }

            Assert.NotNull(eventProcessor.CachedEventsManager);
            Assert.AreEqual(eventProcessor.CachedEventsManager.CachedEvents.Count, 0);
        }

        [TestCase(1)]
        [TestCase(4)]
        [TestCase(8)]
        [TestCase(32)]
        [TestCase(128)]
        public async Task ProcessEvents_SingleDispatch_RespectsDisabledCheckpointing(int batchCheckpointFrequency)
        {
            var partitionContext = EventHubTests.GetPartitionContext();
            var options = new EventHubOptions
            {
                EnableCheckpointing = false,
                BatchCheckpointFrequency = batchCheckpointFrequency
            };
            var processor = new Mock<EventProcessorHost>(MockBehavior.Strict);
            processor.Setup(p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            partitionContext.ProcessorHost = processor.Object;

            var loggerMock = new Mock<ILogger>();
            var executor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            executor.Setup(p => p.TryExecuteAsync(It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>())).ReturnsAsync(new FunctionResult(true));
            var eventProcessor = new EventHubListener.PartitionProcessor(options, executor.Object, loggerMock.Object, true, default, default);

            for (int i = 0; i < 100; i++)
            {
                List<EventData> events = new List<EventData>() { new EventData(new byte[0]) };
                await eventProcessor.ProcessEventsAsync(partitionContext, events);

                // This value should never be set.
                Assert.False(partitionContext.PartitionContext.IsCheckpointingAfterInvocation);
            }

            try
            {
                eventProcessor.Dispose();
            }
            catch (OperationCanceledException)
            {
                // Expected; ignore.
            }

            processor.Verify(
                p => p.CheckpointAsync(It.IsAny<string>(), It.IsAny<EventData>(), It.IsAny<CancellationToken>()),
                Times.Never);
        }

        [TestCase(1)]
        [TestCase(4)]
        [TestCase(8)]
        [TestCase(32)]
        [TestCase(128)]
        public async Task ProcessEvents_MultipleDispatch_RespectsDisabledCheckpointing(int batchCheckpointFrequency)
        {
            var partitionContext = EventHubTests.GetPartitionContext();
            var options = new EventHubOptions
            {
                EnableCheckpointing = false,
                BatchCheckpointFrequency = batchCheckpointFrequency
            };

            var processor = new Mock<EventProcessorHost>(MockBehavior.Strict);
            processor.Setup(p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            partitionContext.ProcessorHost = processor.Object;

            var loggerMock = new Mock<ILogger>();
            var executor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            executor.Setup(p => p.TryExecuteAsync(It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>())).ReturnsAsync(new FunctionResult(true));
            var eventProcessor = new EventHubListener.PartitionProcessor(options, executor.Object, loggerMock.Object, false, default, default);

            for (int i = 0; i < 100; i++)
            {
                List<EventData> events = new List<EventData>() { new EventData(new byte[0]), new EventData(new byte[0]), new EventData(new byte[0]) };
                await eventProcessor.ProcessEventsAsync(partitionContext, events);

                // This value should never be set.
                Assert.False(partitionContext.PartitionContext.IsCheckpointingAfterInvocation);
            }

            try
            {
                eventProcessor.Dispose();
            }
            catch (OperationCanceledException)
            {
                // Expected; ignore.
            }

            processor.Verify(
                p => p.CheckpointAsync(It.IsAny<string>(), It.IsAny<EventData>(), It.IsAny<CancellationToken>()),
                Times.Never);
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

            var eventProcessor = new EventHubListener.PartitionProcessor(options, executor.Object, loggerMock.Object, true, default, default);

            await eventProcessor.ProcessEventsAsync(partitionContext, events);

            processor.Verify(
                p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>()),
                Times.Once);
        }

        /// <summary>
        /// If the partition processor token is signaled, we should NOT checkpoint as the partition ownership
        /// has been lost.
        /// </summary>
        [Test]
        public async Task ProcessEvents_OwnershipLost_DoesNotCheckpoint()
        {
            var partitionContext = EventHubTests.GetPartitionContext();
            var options = new EventHubOptions();

            var processor = new Mock<EventProcessorHost>(MockBehavior.Strict);
            processor.Setup(p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            processor.Setup(p => p.GetLastReadCheckpoint(It.IsAny<string>())).Returns(default(CheckpointInfo));

            partitionContext.ProcessorHost = processor.Object;
            var loggerMock = new Mock<ILogger>();
            var executor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);

            var eventProcessor = new EventHubListener.PartitionProcessor(options, executor.Object, loggerMock.Object, true, default, default);

            List<EventData> events = new List<EventData>();
            List<FunctionResult> results = new List<FunctionResult>();
            for (int i = 0; i < 10; i++)
            {
                events.Add(new EventData(new byte[0]));
                results.Add(new FunctionResult(true));
            }

            int execution = 0;

            executor.Setup(p => p.TryExecuteAsync(It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>())).ReturnsAsync(() =>
            {
                if (execution == 0)
                {
                    eventProcessor.CloseAsync(partitionContext, ProcessingStoppedReason.OwnershipLost).GetAwaiter().GetResult();
                }
                var result = results[execution++];
                return result;
            });

            await eventProcessor.ProcessEventsAsync(partitionContext, events);

            processor.Verify(
                p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>()),
                Times.Never);
        }

        /// <summary>
        /// If function execution succeeds when the function host is shutting down, we should checkpoint.
        /// </summary>
        [Test]
        public async Task ProcessEvents_Succeeds_ShuttingDown_DoesNotCheckpoint()
        {
            var partitionContext = EventHubTests.GetPartitionContext();
            var options = new EventHubOptions();

            var processor = new Mock<EventProcessorHost>(MockBehavior.Strict);
            processor.Setup(p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            processor.Setup(p => p.GetLastReadCheckpoint(It.IsAny<string>())).Returns(default(CheckpointInfo));
            partitionContext.ProcessorHost = processor.Object;

            List<EventData> events = new List<EventData>();
            List<FunctionResult> results = new List<FunctionResult>();
            for (int i = 0; i < 10; i++)
            {
                events.Add(new EventData(new byte[0]));
                results.Add(new FunctionResult(true));
            }

            var executor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            int execution = 0;
            var loggerMock = new Mock<ILogger>();
            var eventProcessor = new EventHubListener.PartitionProcessor(options, executor.Object, loggerMock.Object, true, default, default);

            executor.Setup(p => p.TryExecuteAsync(It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>())).ReturnsAsync(() =>
            {
                if (execution == 0)
                {
                    eventProcessor.CloseAsync(partitionContext, ProcessingStoppedReason.Shutdown).GetAwaiter().GetResult();
                }
                var result = results[execution++];
                return result;
            });

            await eventProcessor.ProcessEventsAsync(partitionContext, events);

            processor.Verify(
                p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>()),
                Times.Once);
        }

        /// <summary>
        /// If function execution fails when the function host is shutting down, we should checkpoint.
        /// </summary>
        [Test]
        public async Task ProcessEvents_Fails_ShuttingDown_DoesCheckpoint()
        {
            var partitionContext = EventHubTests.GetPartitionContext();
            var options = new EventHubOptions();

            var processor = new Mock<EventProcessorHost>(MockBehavior.Strict);
            processor.Setup(p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            processor.Setup(p => p.GetLastReadCheckpoint(It.IsAny<string>())).Returns(default(CheckpointInfo));
            partitionContext.ProcessorHost = processor.Object;

            List<EventData> events = new List<EventData>();
            List<FunctionResult> results = new List<FunctionResult>();
            for (int i = 0; i < 10; i++)
            {
                events.Add(new EventData(new byte[0]));
                results.Add(new FunctionResult(false));
            }

            var executor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            int execution = 0;
            var loggerMock = new Mock<ILogger>();
            var eventProcessor = new EventHubListener.PartitionProcessor(options, executor.Object, loggerMock.Object, true, default, default);

            executor.Setup(p => p.TryExecuteAsync(It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>())).ReturnsAsync(() =>
            {
                if (execution == 0)
                {
                    eventProcessor.CloseAsync(partitionContext, ProcessingStoppedReason.Shutdown).GetAwaiter().GetResult();
                }
                var result = results[execution++];
                return result;
            });

            await eventProcessor.ProcessEventsAsync(partitionContext, events);

            processor.Verify(
                p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>()),
                Times.Once);
        }

        /// <summary>
        /// If function execution succeeds when the listener is shutting down, we should not checkpoint.
        /// </summary>
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ProcessEvents_ListenerStopping_DoesNotCheckpoint(bool executionResult)
        {
            var partitionContext = EventHubTests.GetPartitionContext();
            var options = new EventHubOptions();

            using var listenerCancellationSource = new CancellationTokenSource();

            var processor = new Mock<EventProcessorHost>(MockBehavior.Strict);
            processor.Setup(p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            processor.Setup(p => p.GetLastReadCheckpoint(It.IsAny<string>())).Returns(default(CheckpointInfo));
            partitionContext.ProcessorHost = processor.Object;

            List<EventData> events = new List<EventData>();
            List<FunctionResult> results = new List<FunctionResult>();
            for (int i = 0; i < 10; i++)
            {
                events.Add(new EventData(new byte[0]));
                results.Add(new FunctionResult(executionResult));
            }

            var executor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            int execution = 0;
            var loggerMock = new Mock<ILogger>();
            var eventProcessor = new EventHubListener.PartitionProcessor(options, executor.Object, loggerMock.Object, true, listenerCancellationSource.Token, default);

            executor.Setup(p => p.TryExecuteAsync(It.IsAny<TriggeredFunctionData>(), It.IsAny<CancellationToken>())).ReturnsAsync(() =>
            {
                if (execution == 0)
                {
                    listenerCancellationSource.Cancel();
                }
                var result = results[execution++];
                return result;
            });

            await eventProcessor.ProcessEventsAsync(partitionContext, events);

            processor.Verify(
                p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>()),
                Times.Never);
        }

        [Test]
        public async Task CloseAsync_Shutdown_DoesNotCheckpoint()
        {
            var partitionContext = EventHubTests.GetPartitionContext();
            var options = new EventHubOptions();

            var processor = new Mock<EventProcessorHost>(MockBehavior.Strict);
            processor.Setup(p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            processor.Setup(p => p.GetLastReadCheckpoint(partitionContext.PartitionId)).Returns(() => null);
            partitionContext.ProcessorHost = processor.Object;

            var executor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            var loggerMock = new Mock<ILogger>();
            var eventProcessor = new EventHubListener.PartitionProcessor(options, executor.Object, loggerMock.Object, true, default, default);

            await eventProcessor.CloseAsync(partitionContext, ProcessingStoppedReason.Shutdown);

            processor.Verify(
                p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>()),
                Times.Never);
        }

        [Test]
        public async Task Partition_OwnershipLost_DropsEvents()
        {
            var partitionContext = EventHubTests.GetPartitionContext();
            var options = new EventHubOptions { MinEventBatchSize = 5 };

            var processor = new Mock<EventProcessorHost>(MockBehavior.Strict);
            processor.Setup(p => p.CheckpointAsync(partitionContext.PartitionId, It.IsAny<EventData>(), It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);
            processor.Setup(p => p.GetLastReadCheckpoint(partitionContext.PartitionId)).Returns(() => null);
            partitionContext.ProcessorHost = processor.Object;

            var executor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            var loggerMock = new Mock<ILogger>();
            var eventProcessor = new EventHubListener.PartitionProcessor(options, executor.Object, loggerMock.Object, true, default, default);
            var mockStoredEvents = new Queue<EventData>();
            mockStoredEvents.Enqueue(new EventData("E1"));
            eventProcessor.CachedEventsManager.CachedEvents = mockStoredEvents;

            await eventProcessor.CloseAsync(partitionContext, ProcessingStoppedReason.OwnershipLost);

            Assert.IsFalse(eventProcessor.CachedEventsManager.HasCachedEvents);
        }

        [Test]
        public async Task ProcessErrorsAsync_LoggedAsError()
        {
            var partitionContext = EventHubTests.GetPartitionContext(partitionId: "123", eventHubPath: "abc");
            var options = new EventHubOptions();
            var executor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            var testLogger = new TestLogger("Test");
            var eventProcessor = new EventHubListener.PartitionProcessor(options, executor.Object, testLogger, true, default, default);

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
            var partitionContext = EventHubTests.GetPartitionContext(partitionId: "123", eventHubPath: "abc");
            var options = new EventHubOptions();
            var executor = new Mock<ITriggeredFunctionExecutor>(MockBehavior.Strict);
            var testLogger = new TestLogger("Test");
            var eventProcessor = new EventHubListener.PartitionProcessor(options, executor.Object, testLogger, true, default, default);

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
                                    Mock.Of<LoggerFactory>(),
                                    Mock.Of<IDrainModeManager>());

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
                Mock.Of<LoggerFactory>(),
                Mock.Of<IDrainModeManager>());

            (listener as IListener).Dispose();
            host.Verify(h => h.StopProcessingAsync(CancellationToken.None), Times.Once);

            Assert.Throws<ObjectDisposedException>(() => (listener as IListener).Cancel());
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
            var eventProcessor = new EventHubListener.PartitionProcessor(options, executor.Object, loggerMock.Object, true, default, default);
            List<EventData> events = new List<EventData>() { new EventData(new byte[0]) };
            CancellationTokenSource source = new CancellationTokenSource();
            // Start another thread to cancel execution
            _ = Task.Run(async () =>
            {
                await Task.Delay(500);
            });
            await eventProcessor.ProcessEventsAsync(partitionContext, events);
        }
    }
}
