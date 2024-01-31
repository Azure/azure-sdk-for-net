// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;
using Azure.Messaging.EventHubs.Primitives;
using Moq;
using Moq.Protected;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventProcessor{TPartition}" />
    ///   class.
    /// </summary>
    ///
    /// <remarks>
    ///   This segment of the partial class depends on the types and members defined in the
    ///   <c>EventProcessorTests.cs</c> file.
    /// </remarks>
    ///
    public partial class EventProcessorTests
    {
        /// <summary>
        ///   The set of test cases for exceptions that may occur when the
        ///   transport consumer is closed.
        /// </summary>
        ///
        public static IEnumerable<object[]> ConsumerCloseExceptionTestCases()
        {
            yield return new object[] {  new EventHubsException("fake", "Close called", EventHubsException.FailureReason.ClientClosed) };
            yield return new object[] { new ObjectDisposedException("fake") };
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.ProcessEventBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ProcessEventBatchAsyncHonorsTheCancellationToken()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };
            Assert.That(() => mockProcessor.Object.ProcessEventBatchAsync(new EventProcessorPartition(), EmptyBatch, true, cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.ProcessEventBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ProcessEventBatchAsyncDelegatesToTheHandlerWhenTheBatchHasEvents()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var eventBatch = new[] { new EventData(new BinaryData(Array.Empty<byte>())), new EventData(new BinaryData(Array.Empty<byte>())) };
            var partition = new EventProcessorPartition { PartitionId = "123" };
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(67, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            await mockProcessor.Object.ProcessEventBatchAsync(partition, eventBatch, false, cancellationSource.Token);

            mockProcessor
                .Protected()
                .Verify("OnProcessingEventBatchAsync", Times.Once(), eventBatch, partition, cancellationSource.Token);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.ProcessEventBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ProcessEventBatchAsyncDelegatesToTheHandlerWhenEmptyBatchesAreToBeDispatched()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partition = new EventProcessorPartition { PartitionId = "123" };
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(67, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            await mockProcessor.Object.ProcessEventBatchAsync(partition, EmptyBatch, true, cancellationSource.Token);

            mockProcessor
                .Protected()
                .Verify("OnProcessingEventBatchAsync", Times.Once(), EmptyBatch, partition, cancellationSource.Token);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.ProcessEventBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ProcessEventBatchAsyncDoesNotInvokeTheHandlerWhenEmptyBatchesShouldNotBeDispatched()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partition = new EventProcessorPartition { PartitionId = "123" };
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(67, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            await mockProcessor.Object.ProcessEventBatchAsync(partition, EmptyBatch, false, cancellationSource.Token);

            mockProcessor
                .Protected()
                .Verify("OnProcessingEventBatchAsync", Times.Never(), EmptyBatch, partition, cancellationSource.Token);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.ProcessEventBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ProcessEventBatchAsyncLogsWhenBatchesAreDispatched()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var eventBatch = new[]
            {
                EventHubsModelFactory.EventData(new BinaryData(Array.Empty<byte>()), sequenceNumber: 12345),
                EventHubsModelFactory.EventData(new BinaryData(Array.Empty<byte>()), sequenceNumber: 67890),
            };

            var partition = new EventProcessorPartition { PartitionId = "123" };
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(67, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor.Object.Logger = mockLogger.Object;
            await mockProcessor.Object.ProcessEventBatchAsync(partition, eventBatch, false, cancellationSource.Token);

            mockLogger
                .Verify(logger => logger.EventProcessorProcessingHandlerStart(
                    partition.PartitionId,
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup,
                    It.IsAny<string>(),
                    eventBatch.Length,
                    eventBatch.First().SequenceNumber.ToString(),
                    eventBatch.Last().SequenceNumber.ToString()),
                Times.Once);

            mockLogger
                .Verify(logger => logger.EventProcessorProcessingHandlerComplete(
                    partition.PartitionId,
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup,
                    It.IsAny<string>(),
                    It.IsAny<double>(),
                    eventBatch.Length),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.ProcessEventBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ProcessEventBatchAsyncLogsErrorsWhenBatchesAreDispatched()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedException = new MissingFieldException("This should be logged!");
            var partition = new EventProcessorPartition { PartitionId = "123" };
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(67, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor
                .Protected()
                .Setup("OnProcessingEventBatchAsync", EmptyBatch, partition, cancellationSource.Token)
                .Throws(expectedException);

            mockProcessor.Object.Logger = mockLogger.Object;
            await mockProcessor.Object.ProcessEventBatchAsync(partition, EmptyBatch, true, cancellationSource.Token).IgnoreExceptions();

            mockLogger
                .Verify(logger => logger.EventProcessorProcessingHandlerError(
                    partition.PartitionId,
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup,
                    It.IsAny<string>(),
                    expectedException.Message),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.ProcessEventBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ProcessEventBatchAsyncWrapsErrors()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partition = new EventProcessorPartition { PartitionId = "123" };
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(67, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor
                .Protected()
                .Setup("OnProcessingEventBatchAsync", EmptyBatch, partition, cancellationSource.Token)
                .Throws(new MissingFieldException());

            Assert.That(async () => await mockProcessor.Object.ProcessEventBatchAsync(partition, EmptyBatch, true, cancellationSource.Token), Throws.InstanceOf<DeveloperCodeException>().And.Message.EqualTo(Resources.DeveloperCodeError));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreatePartitionProcessorHonorsTheCancellationToken()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };
            Assert.That(() => mockProcessor.Object.CreatePartitionProcessor(new EventProcessorPartition(), cancellationSource, EventPosition.Earliest), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreatePartitionProcessorPreservesTheCancellationSource()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = Mock.Of<TransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(mockConsumer);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(new EventProcessorPartition(), cancellationSource, EventPosition.Earliest);
            Assert.That(partitionProcessor.CancellationSource, Is.SameAs(cancellationSource));

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreatePartitionProcessorReadsEmptyLastEventPropertiesWithNoOption()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false };
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConsumer.Object.SetLastEvent(default(EventData));

            mockConsumer
                .SetupGet(consumer => consumer.IsClosed)
                .Returns(false);

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(EmptyBatch)
                .Callback(() => completionSource.TrySetResult(true));

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(mockConsumer.Object);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(new EventProcessorPartition(), cancellationSource, EventPosition.Earliest);
            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));

            var lastEventProperties = partitionProcessor.ReadLastEnqueuedEventProperties();
            Assert.That(lastEventProperties, Is.EqualTo(new LastEnqueuedEventProperties(mockConsumer.Object.LastReceivedEvent)));

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreatePartitionProcessorDoesNotAllowReadingLastEventPropertiesWithNoConsumer()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = true };
            var mockConsumer = new Mock<TransportConsumer>();
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConsumer
                .SetupGet(consumer => consumer.IsClosed)
                .Returns(true);

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Callback(() => completionSource.TrySetResult(true))
                .Returns(mockConsumer.Object);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(new EventProcessorPartition(), cancellationSource, EventPosition.Earliest);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            Assert.That(() => partitionProcessor.ReadLastEnqueuedEventProperties(), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreatePartitionProcessorCanReadLastEventProperties()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = true };
            var lastEvent = new EventData(new BinaryData(Array.Empty<byte>()), lastPartitionSequenceNumber: 123, lastPartitionOffset: 887, lastPartitionEnqueuedTime: DateTimeOffset.Parse("2015-10-27T12:00:00Z"), lastPartitionPropertiesRetrievalTime: DateTimeOffset.Parse("2021-03-04T08:30:00Z"));
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConsumer.Object.SetLastEvent(lastEvent);

            mockConsumer
                .SetupGet(consumer => consumer.IsClosed)
                .Returns(false);

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(EmptyBatch)
                .Callback(() => completionSource.TrySetResult(true));

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(mockConsumer.Object);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(new EventProcessorPartition(), cancellationSource, EventPosition.Earliest);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            var lastEventProperties = partitionProcessor.ReadLastEnqueuedEventProperties();
            Assert.That(lastEventProperties, Is.EqualTo(new LastEnqueuedEventProperties(lastEvent)));

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreatePartitionProcessorCanReadLastEventPropertiesWhenTheConsumerIsReplaced()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var retryOptions = new EventHubsRetryOptions { MaximumRetries = 0, MaximumDelay = TimeSpan.FromMilliseconds(5) };
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = true, RetryOptions = retryOptions };
            var lastEvent = new EventData(new BinaryData(Array.Empty<byte>()), lastPartitionSequenceNumber: 123, lastPartitionOffset: 887, lastPartitionEnqueuedTime: DateTimeOffset.Parse("2015-10-27T12:00:00Z"), lastPartitionPropertiesRetrievalTime: DateTimeOffset.Parse("2021-03-04T08:30:00Z"));
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var badMockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConsumer.Object.SetLastEvent(lastEvent);

            mockConsumer
                .SetupGet(consumer => consumer.IsClosed)
                .Returns(false);

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(EmptyBatch)
                .Callback(() => completionSource.TrySetResult(true));

            badMockConsumer
                .SetupGet(consumer => consumer.IsClosed)
                .Returns(false);

            badMockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .Throws(new DllNotFoundException());

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .SetupSequence(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(badMockConsumer.Object)
                .Returns(mockConsumer.Object);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(new EventProcessorPartition(), cancellationSource, EventPosition.Earliest);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            var lastEventProperties = partitionProcessor.ReadLastEnqueuedEventProperties();
            Assert.That(lastEventProperties, Is.EqualTo(new LastEnqueuedEventProperties(lastEvent)));

            cancellationSource.Cancel();

            mockProcessor
                .Verify(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    mockConnection,
                    It.IsAny<EventProcessorOptions>(),
                    It.IsAny<bool>()),
                Times.AtLeast(2));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreatePartitionProcessorCreatesTheTransportConsumer()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partition = new EventProcessorPartition { PartitionId = "99" };
            var position = EventPosition.FromOffset(12);
            var options = new EventProcessorOptions { Identifier = "fake", TrackLastEnqueuedEventProperties = false, PrefetchCount = 37, PrefetchSizeInBytes = 44, LoadBalancingUpdateInterval = TimeSpan.FromMinutes(1) };
            var expectedOwnerLevel = 0;
            var expectedInvalidationOnSteal = true;
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockConnection = new Mock<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<EventData> { new EventData(new BinaryData(Array.Empty<byte>())), new EventData(new BinaryData(Array.Empty<byte>())) })
                .Callback(() => completionSource.TrySetResult(true));

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection.Object);

            mockProcessor
                .Setup(processor => processor.ProcessEventBatchAsync(partition, It.IsAny<IReadOnlyList<EventData>>(), It.IsAny<bool>(), cancellationSource.Token))
                .Returns(Task.CompletedTask);

            mockConnection
                .Setup(connection => connection.CreateTransportConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), It.IsAny<EventHubsRetryPolicy>(), It.IsAny<bool>(), It.IsAny<bool>(), It.IsAny<long>(), It.IsAny<uint?>(), It.IsAny<long?>()))
                .Returns(mockConsumer.Object);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, cancellationSource, position);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockConnection
                .Verify(connection => connection.CreateTransportConsumer(
                    mockProcessor.Object.ConsumerGroup,
                    partition.PartitionId,
                    It.Is<string>(value => value.Contains(options.Identifier)),
                    position,
                    It.IsAny<EventHubsRetryPolicy>(),
                    options.TrackLastEnqueuedEventProperties,
                    expectedInvalidationOnSteal,
                    expectedOwnerLevel,
                    (uint?)options.PrefetchCount,
                    options.PrefetchSizeInBytes),
                Times.Once);

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreatePartitionProcessorStartsTheProcessingTask()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partition = new EventProcessorPartition { PartitionId = "99" };
            var position = EventPosition.FromOffset(12);
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<EventData> { new EventData(new BinaryData(Array.Empty<byte>())), new EventData(new BinaryData(Array.Empty<byte>())) })
                .Callback(() => completionSource.TrySetResult(true));

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(mockConsumer.Object);

            mockProcessor
                .Setup(processor => processor.ProcessEventBatchAsync(partition, It.IsAny<IReadOnlyList<EventData>>(), It.IsAny<bool>(), cancellationSource.Token))
                .Returns(Task.CompletedTask);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, cancellationSource, position);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            Assert.That(partitionProcessor.ProcessingTask, Is.Not.Null, "There should be a processing task present.");
            Assert.That(partitionProcessor.ProcessingTask.IsCompleted, Is.False, "The processing task should not be completed.");

            mockConsumer
                 .Verify(consumer => consumer.ReceiveAsync(
                     It.IsAny<int>(),
                     It.IsAny<TimeSpan?>(),
                     It.IsAny<CancellationToken>()),
                  Times.AtLeastOnce);

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreatePartitionProcessorProcessingTaskRespectsCancellation()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partition = new EventProcessorPartition { PartitionId = "99" };
            var position = EventPosition.FromOffset(12);
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<EventData> { new EventData(new BinaryData(Array.Empty<byte>())), new EventData(new BinaryData(Array.Empty<byte>())) })
                .Callback(() => completionSource.TrySetResult(true));

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(mockConsumer.Object);

            mockProcessor
                 .Setup(processor => processor.ProcessEventBatchAsync(partition, It.IsAny<IReadOnlyList<EventData>>(), It.IsAny<bool>(), cancellationSource.Token))
                 .Returns(Task.CompletedTask);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, cancellationSource, position);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            Assert.That(partitionProcessor.ProcessingTask, Is.Not.Null, "There should be a processing task present.");
            Assert.That(partitionProcessor.ProcessingTask.IsCompleted, Is.False, "The processing task should not be completed.");

            cancellationSource.Cancel();
            Assert.That(async () => await partitionProcessor.ProcessingTask, Throws.InstanceOf<TaskCanceledException>(), "The processing task should honor a cancellation request.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreatePartitionProcessorProcessingTaskClosesTheConsumerOnCancellation()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partition = new EventProcessorPartition { PartitionId = "99" };
            var position = EventPosition.FromOffset(12);
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false };
            var receiveCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var closeCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var logCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockLogger
                .Setup(log => log.EventProcessorPartitionProcessingStopConsumerClose(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .Callback(() => logCompletionSource.TrySetResult(true))
                .Verifiable();

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .Callback(() => receiveCompletionSource.TrySetResult(true))
                .Returns(async () =>
                {
                    await closeCompletionSource.Task;
                    throw new EventHubsException(mockProcessor.Object.EventHubName, "Close called", EventHubsException.FailureReason.ClientClosed);
                });

            mockConsumer
                .Setup(consumer => consumer.CloseAsync(It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    closeCompletionSource.TrySetResult(true);
                    return Task.CompletedTask;
                });

            mockProcessor.Object.Logger = mockLogger.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(mockConsumer.Object);

            mockProcessor
                 .Setup(processor => processor.ProcessEventBatchAsync(partition, It.IsAny<IReadOnlyList<EventData>>(), It.IsAny<bool>(), cancellationSource.Token))
                 .Returns(Task.CompletedTask);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, cancellationSource, position);

            await Task.WhenAny(receiveCompletionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            Assert.That(partitionProcessor.ProcessingTask, Is.Not.Null, "There should be a processing task present.");
            Assert.That(partitionProcessor.ProcessingTask.IsCompleted, Is.False, "The processing task should not be completed.");

            cancellationSource.Cancel();

            using var waitCancellation = new CancellationTokenSource(options.RetryOptions.TryTimeout);
            var completedTask = await Task.WhenAny(logCompletionSource.Task, Task.Delay(Timeout.Infinite, waitCancellation.Token));

            Assert.That(completedTask, Is.SameAs(logCompletionSource.Task), "The consumer close event should have been logged before the timeout expired.");
            Assert.That(async () => await partitionProcessor.ProcessingTask, Throws.InstanceOf<TaskCanceledException>(), "The processing task should have been canceled and not throw the receive exception.");

            // This may get called multiple times due to the race condition.

            mockConsumer
                .Verify(consumer => consumer.CloseAsync(
                    It.IsAny<CancellationToken>()),
                Times.AtLeast(2));

            mockConsumer
                .Verify(consumer => consumer.ReceiveAsync(
                    It.IsAny<int>(),
                    It.IsAny<TimeSpan?>(),
                    It.IsAny<CancellationToken>()),
                Times.Once);

            mockLogger
                .Verify(log => log.EventProcessorPartitionProcessingError(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()),
                Times.Never);

            mockLogger.VerifyAll();

            // Cancel the wait cancellation token just in case the timer hasn't
            // completed yet.

            waitCancellation.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConsumerCloseExceptionTestCases))]
        public async Task CreatePartitionProcessorProcessingTaskDoesNotInvokeTheErrorHandlerOnCancellation(Exception consumerCloseException)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partition = new EventProcessorPartition { PartitionId = "99" };
            var position = EventPosition.FromOffset(12);
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false };
            var receiveCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var closeCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var logCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockLogger
                .Setup(log => log.EventProcessorPartitionProcessingStopConsumerClose(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .Callback(() => logCompletionSource.TrySetResult(true))
                .Verifiable();

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .Callback(() => receiveCompletionSource.TrySetResult(true))
                .Returns(async () =>
                {
                    await closeCompletionSource.Task;
                    throw consumerCloseException;
                });

            mockConsumer
                .Setup(consumer => consumer.CloseAsync(It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    closeCompletionSource.TrySetResult(true);
                    return Task.CompletedTask;
                });

            mockProcessor.Object.Logger = mockLogger.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(mockConsumer.Object);

            mockProcessor
                 .Setup(processor => processor.ProcessEventBatchAsync(partition, It.IsAny<IReadOnlyList<EventData>>(), It.IsAny<bool>(), cancellationSource.Token))
                 .Returns(Task.CompletedTask);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, cancellationSource, position);

            await Task.WhenAny(receiveCompletionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            Assert.That(partitionProcessor.ProcessingTask, Is.Not.Null, "There should be a processing task present.");
            Assert.That(partitionProcessor.ProcessingTask.IsCompleted, Is.False, "The processing task should not be completed.");

            cancellationSource.Cancel();

            using var waitCancellation = new CancellationTokenSource(options.RetryOptions.TryTimeout);
            var completedTask = await Task.WhenAny(logCompletionSource.Task, Task.Delay(Timeout.Infinite, waitCancellation.Token));

            Assert.That(completedTask, Is.SameAs(logCompletionSource.Task), "The consumer close event should have been logged before the timeout expired.");
            Assert.That(async () => await partitionProcessor.ProcessingTask, Throws.InstanceOf<TaskCanceledException>(), "The processing task should have been canceled and not throw the receive exception.");

            mockProcessor
                .Protected()
                .Verify("OnProcessingErrorAsync", Times.Never(),
                    ItExpr.IsAny<Exception>(),
                    ItExpr.IsAny<EventProcessorPartition>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<CancellationToken>());

            // Cancel the wait cancellation token just in case the timer hasn't
            // completed yet.

            waitCancellation.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreatePartitionProcessorProcessingTaskDispatchesEvents()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partition = new EventProcessorPartition { PartitionId = "99" };
            var position = EventPosition.FromOffset(12);
            var retryOptions = new EventHubsRetryOptions { MaximumRetries = 0, MaximumDelay = TimeSpan.FromMilliseconds(5) };
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false, RetryOptions = retryOptions };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<EventData> { new EventData(new BinaryData(Array.Empty<byte>())), new EventData(new BinaryData(Array.Empty<byte>())) });

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(mockConsumer.Object);

            mockProcessor
                 .Setup(processor => processor.ProcessEventBatchAsync(partition, It.IsAny<IReadOnlyList<EventData>>(), It.IsAny<bool>(), cancellationSource.Token))
                 .Returns(Task.CompletedTask)
                 .Callback(() => completionSource.TrySetResult(true));

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, cancellationSource, position);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockProcessor
                 .Verify(processor => processor.ProcessEventBatchAsync(
                     partition,
                     It.IsAny<IReadOnlyList<EventData>>(),
                     It.IsAny<bool>(),
                     cancellationSource.Token),
                 Times.AtLeastOnce);

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreatePartitionProcessorProcessingLogsEachCycle()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var startdDateString = "start-date";
            var endDateString = "end-date";
            var startSequenceNumber = "4444";
            var endSequenceNumber = "8888";
            var partition = new EventProcessorPartition { PartitionId = "99" };
            var position = EventPosition.FromOffset(12);
            var retryOptions = new EventHubsRetryOptions { MaximumRetries = 0, MaximumDelay = TimeSpan.FromMilliseconds(5) };
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false, RetryOptions = retryOptions };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            var eventBatch = new List<EventData>
            {
                EventHubsModelFactory.EventData(new BinaryData(Array.Empty<byte>()), offset: 0, sequenceNumber: long.Parse(startSequenceNumber)),
                EventHubsModelFactory.EventData(new BinaryData(Array.Empty<byte>()), offset: 1, sequenceNumber: long.Parse(endSequenceNumber))
            };

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(eventBatch);

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(mockConsumer.Object);

            mockLogger
                .SetupSequence(logger => logger.GetLogFormattedUtcNow())
                .Returns(startdDateString)
                .Returns(endDateString);

            mockLogger
                .Setup(logger => logger.EventProcessorPartitionProcessingCycleComplete(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<int>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<double>()))
                .Callback(() => completionSource.TrySetResult(true));

            mockProcessor.Object.Logger = mockLogger.Object;

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, cancellationSource, position);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockProcessor
                 .Verify(processor => processor.ProcessEventBatchAsync(
                     partition,
                     It.IsAny<IReadOnlyList<EventData>>(),
                     It.IsAny<bool>(),
                     cancellationSource.Token),
                 Times.AtLeastOnce);

            mockLogger
                .Verify(logger => logger.EventProcessorPartitionProcessingCycleComplete(
                    partition.PartitionId,
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup,
                    eventBatch.Count,
                    startSequenceNumber,
                    endSequenceNumber,
                    startdDateString,
                    endDateString,
                    It.IsAny<double>()),
                Times.AtLeastOnce);

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreatePartitionProcessorProcessingTaskDispatchesExceptionsWhenCreatingTheConnectionFails()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedException = new DivideByZeroException();
            var partition = new EventProcessorPartition { PartitionId = "99" };
            var position = EventPosition.FromOffset(12);
            var retryOptions = new EventHubsRetryOptions { MaximumRetries = 0, MaximumDelay = TimeSpan.FromMilliseconds(5) };
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false, RetryOptions = retryOptions };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Throws(expectedException);

            mockProcessor
                .Protected()
                .Setup<Task<EventProcessorCheckpoint>>("GetCheckpointAsync",
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.FromResult(default(EventProcessorCheckpoint)));

            mockProcessor
               .Protected()
               .Setup<Task>("OnProcessingErrorAsync", expectedException, ItExpr.IsAny<EventProcessorPartition>(), ItExpr.IsAny<string>(), ItExpr.IsAny<CancellationToken>())
               .Callback(() => completionSource.TrySetResult(true))
               .Returns(Task.CompletedTask);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, cancellationSource);
            Assert.That(async () => await partitionProcessor.ProcessingTask, Throws.Exception.EqualTo(expectedException), "The processing task should fail.");

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockProcessor
                .Protected()
                .Verify("OnProcessingErrorAsync", Times.Once(),
                     expectedException,
                     partition,
                     Resources.OperationReadEvents,
                     CancellationToken.None);

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreatePartitionProcessorProcessingTaskDispatchesExceptions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedException = new DivideByZeroException();
            var partition = new EventProcessorPartition { PartitionId = "99" };
            var position = EventPosition.FromOffset(12);
            var retryOptions = new EventHubsRetryOptions { MaximumRetries = 0, MaximumDelay = TimeSpan.FromMilliseconds(5) };
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false, RetryOptions = retryOptions };
            var receiveCompletion = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var errorCompletion = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .Callback(() => receiveCompletion.TrySetResult(true))
                .Throws(expectedException);

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .SetupSequence(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(mockConsumer.Object)
                .Returns(Mock.Of<TransportConsumer>());

            mockProcessor
                 .Setup(processor => processor.ProcessEventBatchAsync(partition, It.IsAny<IReadOnlyList<EventData>>(), It.IsAny<bool>(), cancellationSource.Token))
                 .Returns(Task.CompletedTask);

            mockProcessor
               .Protected()
               .Setup<Task>("OnProcessingErrorAsync", expectedException, ItExpr.IsAny<EventProcessorPartition>(), ItExpr.IsAny<string>(), ItExpr.IsAny<CancellationToken>())
               .Callback(() => errorCompletion.TrySetResult(true))
               .Returns(Task.CompletedTask);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, cancellationSource, position);
            var completionSources = Task.WhenAll(receiveCompletion.Task, errorCompletion.Task);

            await Task.WhenAny(completionSources, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockProcessor
                .Protected()
                .Verify("OnProcessingErrorAsync", Times.Once(),
                     expectedException,
                     partition,
                     Resources.OperationReadEvents,
                     CancellationToken.None);

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreatePartitionProcessorProcessingTaskLogsExceptions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedException = new DivideByZeroException("OMG FAIL!");
            var partition = new EventProcessorPartition { PartitionId = "99" };
            var position = EventPosition.FromOffset(12);
            var retryOptions = new EventHubsRetryOptions { MaximumRetries = 0, MaximumDelay = TimeSpan.FromMilliseconds(5) };
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false, RetryOptions = retryOptions };
            var receiveCompletion = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var errorCompletion = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .Callback(() => receiveCompletion.TrySetResult(true))
                .Throws(expectedException);

            mockProcessor.Object.Logger = mockLogger.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .SetupSequence(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(mockConsumer.Object)
                .Returns(Mock.Of<TransportConsumer>());

            mockProcessor
                 .Setup(processor => processor.ProcessEventBatchAsync(partition, It.IsAny<IReadOnlyList<EventData>>(), It.IsAny<bool>(), cancellationSource.Token))
                 .Returns(Task.CompletedTask);

            mockLogger
               .Setup(log => log.EventProcessorPartitionProcessingError(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
               .Callback(() => errorCompletion.TrySetResult(true));

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, cancellationSource, position);
            var completionSources = Task.WhenAll(receiveCompletion.Task, errorCompletion.Task);

            await Task.WhenAny(completionSources, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockLogger
               .Verify(log => log.EventProcessorPartitionProcessingError(
                   partition.PartitionId,
                   mockProcessor.Object.Identifier,
                   mockProcessor.Object.EventHubName,
                   mockProcessor.Object.ConsumerGroup,
                   expectedException.Message),
                Times.Once);

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreatePartitionProcessorProcessingTaskSurfacesExceptions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedException = new DivideByZeroException("I'm special!");
            var partition = new EventProcessorPartition { PartitionId = "99" };
            var position = EventPosition.FromOffset(12);
            var retryOptions = new EventHubsRetryOptions { MaximumRetries = 0, MaximumDelay = TimeSpan.FromMilliseconds(5) };
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false, RetryOptions = retryOptions };
            var receiveCompletion = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var errorCompletion = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .Callback(() => receiveCompletion.TrySetResult(true))
                .Throws(expectedException);

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .SetupSequence(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(mockConsumer.Object)
                .Returns(Mock.Of<TransportConsumer>());

            mockProcessor
                 .Setup(processor => processor.ProcessEventBatchAsync(partition, It.IsAny<IReadOnlyList<EventData>>(), It.IsAny<bool>(), cancellationSource.Token))
                 .Returns(Task.CompletedTask);

            mockProcessor
               .Protected()
               .Setup<Task>("OnProcessingErrorAsync", expectedException, ItExpr.IsAny<EventProcessorPartition>(), ItExpr.IsAny<string>(), ItExpr.IsAny<CancellationToken>())
               .Callback(() => errorCompletion.TrySetResult(true))
               .Returns(Task.CompletedTask);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, cancellationSource, position);
            var completionSources = Task.WhenAll(receiveCompletion.Task, errorCompletion.Task);

            await Task.WhenAny(completionSources, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            cancellationSource.Cancel();
            Assert.That(async () => await partitionProcessor.ProcessingTask, Throws.TypeOf(expectedException.GetType()).And.EqualTo(expectedException), "The exception should have been surfaced by the task.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreatePartitionProcessorProcessingTaskWarnsForDeveloperCodeExceptions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedException = new DeveloperCodeException(new DivideByZeroException());
            var partition = new EventProcessorPartition { PartitionId = "99" };
            var position = EventPosition.FromOffset(12);
            var retryOptions = new EventHubsRetryOptions { MaximumRetries = 1, MaximumDelay = TimeSpan.FromMilliseconds(5) };
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false, RetryOptions = retryOptions };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<EventData> { new EventData(new BinaryData(Array.Empty<byte>())), new EventData(new BinaryData(Array.Empty<byte>())) });

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(mockConsumer.Object);

            mockProcessor
                 .Setup(processor => processor.ProcessEventBatchAsync(partition, It.IsAny<IReadOnlyList<EventData>>(), It.IsAny<bool>(), cancellationSource.Token))
                 .Callback(() => completionSource.TrySetResult(true))
                 .Throws(expectedException);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, cancellationSource, position);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            // Allow for a small delay because error processing is a background task, just to give it time to trigger.

            await Task.Delay(250);

            mockProcessor
                .Protected()
                .Verify("OnProcessingErrorAsync", Times.Once(),
                     ItExpr.Is<EventHubsException>(ex =>
                         ex.IsTransient == false
                         && ex.Message.Contains(Resources.DeveloperCodeEventProcessingError)
                         && ex.InnerException == expectedException.InnerException),
                     partition,
                     Resources.OperationEventProcessingDeveloperCode,
                     ItExpr.IsAny<CancellationToken>());

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreatePartitionProcessorProcessingTaskLogsDeveloperCodeExceptions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedException = new DeveloperCodeException(new DivideByZeroException("Yay, I'm on the inside!"));
            var partition = new EventProcessorPartition { PartitionId = "99" };
            var position = EventPosition.FromOffset(12);
            var retryOptions = new EventHubsRetryOptions { MaximumRetries = 1, MaximumDelay = TimeSpan.FromMilliseconds(5) };
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false, RetryOptions = retryOptions };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<EventData> { new EventData(new BinaryData(Array.Empty<byte>())), new EventData(new BinaryData(Array.Empty<byte>())) });

            mockProcessor.Object.Logger = mockLogger.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(mockConsumer.Object);

            mockProcessor
                 .Setup(processor => processor.ProcessEventBatchAsync(partition, It.IsAny<IReadOnlyList<EventData>>(), It.IsAny<bool>(), cancellationSource.Token))
                 .Callback(() => completionSource.TrySetResult(true))
                 .Throws(expectedException);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, cancellationSource, position);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            // Allow for a small delay because error processing is a background task, just to give it time to trigger.

            await Task.Delay(250);

            mockLogger
                .Verify(log => log.EventProcessorPartitionProcessingError(
                    partition.PartitionId,
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup,
                    It.Is<string>(value => value.Contains(expectedException.InnerException.Message))),
                 Times.Once);

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreatePartitionProcessorProcessingTaskSurfacesDeveloperCodeExceptions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedException = new InvalidOperationException("BOOM!");
            var developerException = new DeveloperCodeException(expectedException);
            var partition = new EventProcessorPartition { PartitionId = "99" };
            var position = EventPosition.FromOffset(12);
            var retryOptions = new EventHubsRetryOptions { MaximumRetries = 1, MaximumDelay = TimeSpan.FromMilliseconds(5) };
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false, RetryOptions = retryOptions };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<EventData> { new EventData(new BinaryData(Array.Empty<byte>())), new EventData(new BinaryData(Array.Empty<byte>())) });

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(mockConsumer.Object);

            mockProcessor
                 .Setup(processor => processor.ProcessEventBatchAsync(partition, It.IsAny<IReadOnlyList<EventData>>(), It.IsAny<bool>(), cancellationSource.Token))
                 .Callback(() => completionSource.TrySetResult(true))
                 .Throws(developerException);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, cancellationSource, position);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            cancellationSource.Cancel();
            Assert.That(async () => await partitionProcessor.ProcessingTask, Throws.TypeOf(expectedException.GetType()).And.EqualTo(expectedException), "The inner exception should have been surfaced by the task.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreatePartitionProcessorProcessingTaskHonorsTheRetryPolicy()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedException = new EventHubsException(true, "frank", "BOOM!", EventHubsException.FailureReason.GeneralError);
            var partition = new EventProcessorPartition { PartitionId = "99" };
            var position = EventPosition.FromOffset(12);
            var retryOptions = new EventHubsRetryOptions { MaximumRetries = 2, MaximumDelay = TimeSpan.FromMilliseconds(15) };
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false, RetryOptions = retryOptions };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .Throws(expectedException);

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .SetupSequence(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(mockConsumer.Object)
                .Returns(() =>
                {
                    completionSource.TrySetResult(true);
                    return Mock.Of<TransportConsumer>();
                });

            mockProcessor
                 .Setup(processor => processor.ProcessEventBatchAsync(partition, It.IsAny<IReadOnlyList<EventData>>(), It.IsAny<bool>(), cancellationSource.Token))
                 .Returns(Task.CompletedTask);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, cancellationSource, position);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockConsumer
                 .Verify(consumer => consumer.ReceiveAsync(
                     It.IsAny<int>(),
                     It.IsAny<TimeSpan?>(),
                     It.IsAny<CancellationToken>()),
                 Times.Exactly(retryOptions.MaximumRetries + 1));

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreatePartitionProcessorProcessingTaskReplacesTheConsumerOnFailure()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var retryOptions = new EventHubsRetryOptions { MaximumRetries = 0, MaximumDelay = TimeSpan.FromMilliseconds(5) };
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false, RetryOptions = retryOptions };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var badMockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .Callback(() => completionSource.TrySetResult(true))
                .ReturnsAsync(EmptyBatch);

            badMockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .Throws(new DllNotFoundException());

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .SetupSequence(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(badMockConsumer.Object)
                .Returns(mockConsumer.Object);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(new EventProcessorPartition(), cancellationSource, EventPosition.Earliest);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            cancellationSource.Cancel();

            mockProcessor
                .Verify(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    mockConnection,
                    It.IsAny<EventProcessorOptions>(),
                    It.IsAny<bool>()),
                Times.AtLeast(2));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreatePartitionProcessorProcessingTaskDoesNotReplaceTheConsumerWhenThePartitionIsStolen()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var retryOptions = new EventHubsRetryOptions { MaximumRetries = 0, MaximumDelay = TimeSpan.FromMilliseconds(5) };
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false, RetryOptions = retryOptions };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .Callback(() => completionSource.TrySetResult(true))
                .Throws(new EventHubsException("fake", "OMG WTF", EventHubsException.FailureReason.ConsumerDisconnected));

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(mockConsumer.Object);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(new EventProcessorPartition(), cancellationSource, EventPosition.Earliest);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            cancellationSource.Cancel();

            mockProcessor
                .Verify(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    mockConnection,
                    It.IsAny<EventProcessorOptions>(),
                    It.IsAny<bool>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreatePartitionProcessorProcessingTaskDoesNotInvokeTheErrorHandlerWhenThePartitionIsStolen()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var retryOptions = new EventHubsRetryOptions { MaximumRetries = 0, MaximumDelay = TimeSpan.FromMilliseconds(5) };
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false, RetryOptions = retryOptions };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .Callback(() => completionSource.TrySetResult(true))
                .Throws(new EventHubsException("fake", "OMG WTF", EventHubsException.FailureReason.ConsumerDisconnected));

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(mockConsumer.Object);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(new EventProcessorPartition(), cancellationSource, EventPosition.Earliest);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            cancellationSource.Cancel();

            mockProcessor
                .Protected()
                .Verify("OnProcessingErrorAsync", Times.Never(),
                    ItExpr.IsAny<Exception>(),
                    ItExpr.IsAny<EventProcessorPartition>(),
                    ItExpr.IsAny<string>(),
                    ItExpr.IsAny<CancellationToken>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreatePartitionProcessorProcessingReportsWhenThePartitionIsStolen()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var retryOptions = new EventHubsRetryOptions { MaximumRetries = 0, MaximumDelay = TimeSpan.FromMilliseconds(5) };
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false, RetryOptions = retryOptions };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var mockLoadBalancer = new Mock<PartitionLoadBalancer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options, mockLoadBalancer.Object) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .Throws(new EventHubsException("fake", "OMG WTF", EventHubsException.FailureReason.ConsumerDisconnected));

            mockLoadBalancer
                .Setup(lb => lb.ReportPartitionStolen(It.IsAny<string>()))
                .Callback(() => completionSource.TrySetResult(true));

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(mockConsumer.Object);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(new EventProcessorPartition(), cancellationSource, EventPosition.Earliest);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            cancellationSource.Cancel();

            mockLoadBalancer
                .Verify(lb => lb.ReportPartitionStolen(
                    It.IsAny<string>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreatePartitionProcessorProcessingTaskStartsTheConsumerAtTheCorrectEventWhenReplaced()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var retryOptions = new EventHubsRetryOptions { MaximumRetries = 0, MaximumDelay = TimeSpan.FromMilliseconds(5) };
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false, RetryOptions = retryOptions };
            var partition = new EventProcessorPartition { PartitionId = "4" };
            var lastEventBatch = new List<EventData> { new EventData(new BinaryData(Array.Empty<byte>())), new EventData(new BinaryData(Array.Empty<byte>()), offset: 9987) };
            var initialStartingPosition = EventPosition.FromSequenceNumber(332);
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var badMockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(EmptyBatch);

            badMockConsumer
                .SetupSequence(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<EventData> { new EventData(new BinaryData(Array.Empty<byte>())) })
                .ReturnsAsync(lastEventBatch)
                .Throws(new DllNotFoundException());

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .SetupSequence(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(badMockConsumer.Object)
                .Returns(() =>
                {
                    completionSource.TrySetResult(true);
                    return mockConsumer.Object;
                });

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, cancellationSource, initialStartingPosition);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            cancellationSource.Cancel();

            mockProcessor
                .Verify(processor => processor.CreateConsumer(
                    mockProcessor.Object.ConsumerGroup,
                    partition.PartitionId,
                    It.IsAny<string>(),
                    initialStartingPosition,
                    mockConnection,
                    It.IsAny<EventProcessorOptions>(),
                    It.IsAny<bool>()),
                Times.Once);

            mockProcessor
                .Verify(processor => processor.CreateConsumer(
                    mockProcessor.Object.ConsumerGroup,
                    partition.PartitionId,
                    It.IsAny<string>(),
                    EventPosition.FromOffset(lastEventBatch.Last().Offset, false),
                    mockConnection,
                    It.IsAny<EventProcessorOptions>(),
                    It.IsAny<bool>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreatePartitionProcessorProcessingTaskLogsTheStartingPosition()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partition = new EventProcessorPartition { PartitionId = "4" };
            var expectedEventPosition = EventPosition.FromSequenceNumber(332);
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), new EventProcessorOptions()) { CallBase = true };

            mockLogger
                .Setup(log => log.EventProcessorPartitionProcessingEventPositionDetermined(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), false, null, null))
                .Callback(() => completionSource.TrySetResult(true));

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(EmptyBatch);

            mockProcessor.Object.Logger = mockLogger.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(mockConsumer.Object);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, cancellationSource, expectedEventPosition);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockLogger
                .Verify(log => log.EventProcessorPartitionProcessingEventPositionDetermined(
                    partition.PartitionId,
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup,
                    expectedEventPosition.ToString(),
                    false,
                    null, // no checkpoint was used
                    null), // no checkpoint was used
                Times.Once);

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreatePartitionProcessorProcessingTaskDoesNotReplaceTheConsumerOnFatalExceptions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedException = new TaskCanceledException("Like the others, but this one is special!");
            var retryOptions = new EventHubsRetryOptions { MaximumRetries = 0, MaximumDelay = TimeSpan.FromMilliseconds(5) };
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false, RetryOptions = retryOptions };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .Callback(() => completionSource.TrySetResult(true))
                .Throws(expectedException);

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(mockConsumer.Object);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(new EventProcessorPartition(), cancellationSource, EventPosition.Earliest);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            cancellationSource.Cancel();
            Assert.That(async () => await partitionProcessor.ProcessingTask, Throws.TypeOf(expectedException.GetType()).And.Message.EqualTo(expectedException.Message), "The exception should have been surfaced by the task.");

            mockProcessor
                .Verify(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    mockConnection,
                    It.IsAny<EventProcessorOptions>(),
                    It.IsAny<bool>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreatePartitionProcessorProcessingTaskWrapsAnOperationCanceledExceptionAndConsidersItFatal()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedException = new OperationCanceledException("STAHP!");
            var retryOptions = new EventHubsRetryOptions { MaximumRetries = 0, MaximumDelay = TimeSpan.FromMilliseconds(5) };
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false, RetryOptions = retryOptions };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .Callback(() => completionSource.TrySetResult(true))
                .Throws(expectedException);

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(mockConsumer.Object);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(new EventProcessorPartition(), cancellationSource, EventPosition.Earliest);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            cancellationSource.Cancel();
            Assert.That(async () => await partitionProcessor.ProcessingTask, Throws.InstanceOf<TaskCanceledException>().And.InnerException.EqualTo(expectedException), "The wrapped exception should have been surfaced by the task.");

            mockProcessor
                .Verify(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    mockConnection,
                    It.IsAny<EventProcessorOptions>(),
                    It.IsAny<bool>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreatePartitionProcessorProcessingTaskDoesNotReplaceTheConsumerWhenCancellationRequested()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var retryOptions = new EventHubsRetryOptions { MaximumRetries = 0, MaximumDelay = TimeSpan.FromMilliseconds(5) };
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false, RetryOptions = retryOptions };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(EmptyBatch)
                .Callback(() => completionSource.TrySetResult(true));

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(mockConsumer.Object);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(new EventProcessorPartition(), cancellationSource, EventPosition.Earliest);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            cancellationSource.Cancel();
            Assert.That(async () => await partitionProcessor.ProcessingTask, Throws.InstanceOf<TaskCanceledException>(), "The cancellation should have been surfaced by the task.");

            mockProcessor
                .Verify(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    mockConnection,
                    It.IsAny<EventProcessorOptions>(),
                    It.IsAny<bool>()),
                Times.Once);

            mockConsumer
                .Verify(consumer => consumer.ReceiveAsync(
                    It.IsAny<int>(),
                    It.IsAny<TimeSpan?>(),
                    It.IsAny<CancellationToken>()),
                Times.AtLeastOnce);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreatePartitionProcessorProcessingTaskClosesTheConsumerWhenItIsReplaced()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var retryOptions = new EventHubsRetryOptions { MaximumRetries = 0, MaximumDelay = TimeSpan.FromMilliseconds(5) };
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false, RetryOptions = retryOptions };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var badMockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(EmptyBatch);

            badMockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .Throws(new DllNotFoundException());

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .SetupSequence(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(badMockConsumer.Object)
                .Returns(() =>
                {
                    completionSource.TrySetResult(true);
                    return mockConsumer.Object;
                });

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(new EventProcessorPartition(), cancellationSource, EventPosition.Earliest);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            cancellationSource.Cancel();

            mockProcessor
                .Verify(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    mockConnection,
                    It.IsAny<EventProcessorOptions>(),
                    It.IsAny<bool>()),
                Times.AtLeast(2));

            badMockConsumer
                .Verify(consumer => consumer.CloseAsync(CancellationToken.None),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreatePartitionProcessorProcessingLogsWhenAnExceptionOccursClosingTheConsumer()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedException = new DataMisalignedException("This is bad and you should feel bad.");
            var partition = new EventProcessorPartition { PartitionId = "omgno" };
            var retryOptions = new EventHubsRetryOptions { MaximumRetries = 0, MaximumDelay = TimeSpan.FromMilliseconds(5) };
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false, RetryOptions = retryOptions };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var badMockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(EmptyBatch);

            badMockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .Throws(new DllNotFoundException());

            badMockConsumer
                .Setup(consumer => consumer.CloseAsync(It.IsAny<CancellationToken>()))
                .Throws(expectedException);

            mockProcessor.Object.Logger = mockLogger.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .SetupSequence(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(badMockConsumer.Object)
                .Returns(() =>
                {
                    completionSource.TrySetResult(true);
                    return mockConsumer.Object;
                });

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, cancellationSource, EventPosition.Earliest);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            cancellationSource.Cancel();

            badMockConsumer
                 .Verify(consumer => consumer.CloseAsync(CancellationToken.None),
                 Times.Once);

            mockLogger
                .Verify(log => log.EventProcessorPartitionProcessingError(
                    partition.PartitionId,
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup,
                    expectedException.Message),
                 Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreatePartitionProcessorProcessingLogsWarningForTokenCancellationErrors()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var firstCall = true;
            var partition = new EventProcessorPartition { PartitionId = "omgno" };
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false, RetryOptions = new EventHubsRetryOptions { MaximumRetries = 0, MaximumDelay = TimeSpan.FromMilliseconds(5) } };
            var handlerCompletion = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConsumer
                 .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                 .Returns(() => firstCall switch
                 {
                     true => Task.FromResult<IReadOnlyList<EventData>>(new List<EventData> { new EventData("Test") }),
                     false => Task.FromResult<IReadOnlyList<EventData>>(new List<EventData>())
                 });

            mockProcessor.Object.Logger = mockLogger.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .SetupSequence(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>(), It.IsAny<bool>()))
                .Returns(mockConsumer.Object);

            mockProcessor
                 .Setup(processor => processor.ProcessEventBatchAsync(It.IsAny<EventProcessorPartition>(), It.IsAny<IReadOnlyList<EventData>>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                 .Callback<EventProcessorPartition, IReadOnlyList<EventData>, bool, CancellationToken>((partition, events, dispatchEmpties, cancellationToken) =>
                 {
                     if (firstCall)
                     {
                         cancellationToken.Register(() => throw new DivideByZeroException());
                         handlerCompletion.TrySetResult(true);
                         firstCall = false;
                     }
                 })
                 .Returns(Task.CompletedTask);

            using var processorCancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationSource.Token, CancellationToken.None);
            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, processorCancellationSource, EventPosition.Earliest);

            Assert.That(() => GetActivePartitionProcessors(mockProcessor.Object).TryAdd(partition.PartitionId, partitionProcessor), Is.True, "The partition processor should have been registered for tracking.");

            await Task.WhenAny(handlerCompletion.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            Assert.That(async () => await InvokeStopProcessingPartitionAsync(mockProcessor.Object, partition.PartitionId, Processor.ProcessingStoppedReason.OwnershipLost, cancellationSource.Token), Throws.Nothing, "Processing should have been stopped.");
            Assert.That(partitionProcessor.CancellationSource.IsCancellationRequested, Is.True, "The partition processor should have been canceled.");

            mockLogger
                .Verify(log => log.PartitionProcessorStoppingCancellationWarning(
                    partition.PartitionId,
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup,
                    It.IsAny<string>()),
                Times.Once);

            cancellationSource.Cancel();
        }
    }
}
