// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    [TestFixture]
    public class EventProcessorTests
    {
        /// <summary>An empty event batch to use for mocking.</summary>
        private readonly IReadOnlyList<EventData> EmptyBatch = new List<EventData>(0);

        /// <summary>
        ///   Provides test cases for the constructor tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ConstructorCreatesDefaultOptionsCases()
        {
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var connectionStringNoHub = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123";
            var credential = Mock.Of<TokenCredential>();

            yield return new object[] { new ProcessorConstructorMock(99, "consumerGroup", connectionString), "connection string with default options" };
            yield return new object[] { new ProcessorConstructorMock(99, "consumerGroup", connectionStringNoHub, "hub", default), "connection string with default options" };
            yield return new object[] { new ProcessorConstructorMock(99, "consumerGroup", "namespace", "hub", credential, default(EventProcessorOptions)), "namespace with explicit null options" };
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(-100)]
        [TestCase(-10)]
        [TestCase(-1)]
        [TestCase(0)]
        public void ConstructorValidatesTheEventBatchMaximumCount(int constructorArgument)
        {
            Assert.That(() => new ProcessorConstructorMock(constructorArgument, "dummyGroup", "dummyConnection", new EventProcessorOptions()), Throws.InstanceOf<ArgumentException>(), "The connection string constructor should validate the maximum batch size.");
            Assert.That(() => new ProcessorConstructorMock(constructorArgument, "dummyGroup", "dummyNamespace", "dummyEventHub", Mock.Of<TokenCredential>(), new EventProcessorOptions()), Throws.InstanceOf<ArgumentException>(), "The namespace constructor should validate the maximum batch size.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheConsumerGroup(string constructorArgument)
        {
            Assert.That(() => new ProcessorConstructorMock(1, constructorArgument, "dummyConnection", new EventProcessorOptions()), Throws.InstanceOf<ArgumentException>(), "The connection string constructor should validate the consumer group.");
            Assert.That(() => new ProcessorConstructorMock(1, constructorArgument, "dummyNamespace", "dummyEventHub", Mock.Of<TokenCredential>(), new EventProcessorOptions()), Throws.InstanceOf<ArgumentException>(), "The namespace constructor should validate the consumer group.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheConnectionString(string connectionString)
        {
            Assert.That(() => new ProcessorConstructorMock(1, EventHubConsumerClient.DefaultConsumerGroupName, connectionString), Throws.InstanceOf<ArgumentException>(), "The constructor without options should ensure a connection string.");
            Assert.That(() => new ProcessorConstructorMock(1, EventHubConsumerClient.DefaultConsumerGroupName, connectionString, "dummy", new EventProcessorOptions()), Throws.InstanceOf<ArgumentException>(), "The constructor with options should ensure a connection string.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("sb://namespace.place.com")]
        public void ConstructorValidatesTheNamespace(string constructorArgument)
        {
            Assert.That(() => new ProcessorConstructorMock(1, EventHubConsumerClient.DefaultConsumerGroupName, constructorArgument, "dummy", Mock.Of<TokenCredential>()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheEventHub(string constructorArgument)
        {
            Assert.That(() => new ProcessorConstructorMock(100, EventHubConsumerClient.DefaultConsumerGroupName, "namespace", constructorArgument, Mock.Of<TokenCredential>()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheCredential()
        {
            Assert.That(() => new ProcessorConstructorMock(5, EventHubConsumerClient.DefaultConsumerGroupName, "namespace", "hubName", default(TokenCredential)), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorCreatesDefaultOptionsCases))]
        public void ConstructorCreatesDefaultOptions(ProcessorConstructorMock eventProcessor,
                                                     string constructorDescription)
        {
            var defaultOptions = new EventProcessorOptions();
            var connectionOptions = GetConnectionOptions(eventProcessor);

            Assert.That(connectionOptions.TransportType, Is.EqualTo(defaultOptions.ConnectionOptions.TransportType), $"The { constructorDescription } constructor should have a default set of connection options.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorClonesTheConnectionOptions()
        {
            var expectedTransportType = EventHubsTransportType.AmqpWebSockets;
            var otherTransportType = EventHubsTransportType.AmqpTcp;

            var options = new EventProcessorOptions
            {
                ConnectionOptions = new EventHubConnectionOptions { TransportType = expectedTransportType }
            };

            var eventProcessor = new ProcessorConstructorMock(1, "consumerGroup", "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub", options);

            // Simply retrieving the options from an inner connection won't be enough to prove the processor clones
            // its connection options because the cloning step also happens in the EventHubConnection constructor.
            // For this reason, we will change the transport type and verify that it won't affect the returned
            // connection options.

            options.ConnectionOptions.TransportType = otherTransportType;

            var connectionOptions = GetConnectionOptions(eventProcessor);
            Assert.That(connectionOptions.TransportType, Is.EqualTo(expectedTransportType), $"The connection options should have been cloned.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void NamespaceConstructorClonesTheConnectionOptions()
        {
            var expectedTransportType = EventHubsTransportType.AmqpWebSockets;
            var otherTransportType = EventHubsTransportType.AmqpTcp;

            var options = new EventProcessorOptions
            {
                ConnectionOptions = new EventHubConnectionOptions { TransportType = expectedTransportType }
            };

            var eventProcessor = new ProcessorConstructorMock(11, "consumerGroup", "namespace", "hub", Mock.Of<TokenCredential>(), options);

            // Simply retrieving the options from an inner connection won't be enough to prove the processor clones
            // its connection options because the cloning step also happens in the EventHubConnection constructor.
            // For this reason, we will change the transport type and verify that it won't affect the returned
            // connection options.

            options.ConnectionOptions.TransportType = otherTransportType;

            var connectionOptions = GetConnectionOptions(eventProcessor);
            Assert.That(connectionOptions.TransportType, Is.EqualTo(expectedTransportType), $"The connection options should have been cloned.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorSetsTheIdentifier()
        {
            var options = new EventProcessorOptions
            {
                Identifier = Guid.NewGuid().ToString()
            };

            var eventProcessor = new ProcessorConstructorMock(72, "consumerGroup", "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub", options);

            Assert.That(eventProcessor.Identifier, Is.Not.Null);
            Assert.That(eventProcessor.Identifier, Is.EqualTo(options.Identifier));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void NamespaceConstructorSetsTheIdentifier()
        {
            var options = new EventProcessorOptions
            {
                Identifier = Guid.NewGuid().ToString()
            };

            var eventProcessor = new ProcessorConstructorMock(65, "consumerGroup", "namespace", "hub", Mock.Of<TokenCredential>(), options);

            Assert.That(eventProcessor.Identifier, Is.Not.Null);
            Assert.That(eventProcessor.Identifier, Is.EqualTo(options.Identifier));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConnectionStringConstructorCreatesTheIdentifierWhenNotSpecified(string identifier)
        {
            var options = new EventProcessorOptions
            {
                Identifier = identifier
            };

            var eventProcessor = new ProcessorConstructorMock(34, "consumerGroup", "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub", options);

            Assert.That(eventProcessor.Identifier, Is.Not.Null);
            Assert.That(eventProcessor.Identifier, Is.Not.Empty);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void NamespaceConstructorCreatesTheIdentifierWhenNotSpecified(string identifier)
        {
            var options = new EventProcessorOptions
            {
                Identifier = identifier
            };

            var eventProcessor = new ProcessorConstructorMock(665, "consumerGroup", "namespace", "hub", Mock.Of<TokenCredential>(), options);

            Assert.That(eventProcessor.Identifier, Is.Not.Null);
            Assert.That(eventProcessor.Identifier, Is.Not.Empty);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StartProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void StartProcessingRespectsACancelledToken(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            if (async)
            {
                Assert.That(async () => await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>(), "The asynchronous call should have been canceled.");
            }
            else
            {
                Assert.That(() => mockProcessor.Object.StartProcessing(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>(), "The synchronous call should have been canceled.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StartProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartProcessingStartsTheProcessing(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(Mock.Of<EventHubConnection>());

            if (async)
            {
                await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            }
            else
            {
                mockProcessor.Object.StartProcessing(cancellationSource.Token);
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            Assert.That(mockProcessor.Object.IsRunning, Is.True, "The processor should report that it is running.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor status should report that it is running.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object).IsCompleted, Is.False, "The task for processing should be active.");
            mockProcessor.Verify(processor => processor.CreateConnection(), Times.Once);

            // Shut the processor down to ensure resource clean-up, but ignore any errors since it isn't the
            // subject of this test.

            try
            { await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token); }
            catch { }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StartProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartProcessingDoesNotAttemptToStartWhenRunning(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(Mock.Of<EventHubConnection>());

            if (async)
            {
                await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            }
            else
            {
                mockProcessor.Object.StartProcessing(cancellationSource.Token);
            }

            Assert.That(mockProcessor.Object.IsRunning, Is.True, "The processor should report that it is running.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor status should report that it is running.");

            // The processor is confirmed running; attempt to start again.

            if (async)
            {
                await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            }
            else
            {
                mockProcessor.Object.StartProcessing(cancellationSource.Token);
            }

            // Only a single connection should have been created.

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            mockProcessor.Verify(processor => processor.CreateConnection(), Times.Once);

            // Shut the processor down to ensure resource clean-up, but ignore any errors since it isn't the
            // subject of this test.

            try
            { await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token); }
            catch { }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StartProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartProcessingLogsNormalStartup(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var mockEventSource = new Mock<EventHubsEventSource>() { CallBase = true };
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor.Object.Logger = mockEventSource.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(Mock.Of<EventHubConnection>());

            if (async)
            {
                await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            }
            else
            {
                mockProcessor.Object.StartProcessing(cancellationSource.Token);
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockEventSource
                .Verify(log => log.EventProcessorStart(
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup),
                Times.Once);

            mockEventSource
                .Verify(log => log.EventProcessorStartComplete(
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup),
                Times.Once);

            // Shut the processor down to ensure resource clean-up, but ignore any errors since it isn't the
            // subject of this test.

            try
            { await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token); }
            catch { }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StartProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StartProcessingLogsErrorDuringStartup(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var mockEventSource = new Mock<EventHubsEventSource>() { CallBase = true };
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockEventSource
                .Setup(log => log.EventProcessorStart(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .Callback(() => cancellationSource.Cancel());

            mockProcessor.Object.Logger = mockEventSource.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(Mock.Of<EventHubConnection>());

            if (async)
            {
                Assert.That(async () => await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>(), "Task cancellation should have been injected while starting.");
            }
            else
            {
                Assert.That(() => mockProcessor.Object.StartProcessing(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>(), "Task cancellation should have been injected while starting.");
            }

            mockEventSource
                .Verify(log => log.EventProcessorStart(
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup),
                Times.Once);

            mockEventSource
                .Verify(log => log.EventProcessorStartError(
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup,
                    It.IsAny<string>()),
                Times.Once);

            mockEventSource
                .Verify(log => log.EventProcessorStartComplete(
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup),
                Times.Once);

            // Shut the processor down to ensure resource clean-up, but ignore any errors since it isn't the
            // subject of this test.

            try
            { await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token); }
            catch { }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StopProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void StopProcessingRespectsACancelledToken(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            if (async)
            {
                Assert.That(async () => await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>(), "The asynchronous call should have been canceled.");
            }
            else
            {
                Assert.That(() => mockProcessor.Object.StopProcessing(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>(), "The synchronous call should have been canceled.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StopProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StopProcessingStopsProcessing(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(Mock.Of<EventHubConnection>());

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.IsRunning, Is.True, "The processor should report that it is running.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor status should report that it is running.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object).IsCompleted, Is.False, "The task for processing should be active.");

            if (async)
            {
                await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);
            }
            else
            {
                mockProcessor.Object.StopProcessing(cancellationSource.Token);
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            Assert.That(mockProcessor.Object.IsRunning, Is.False, "The processor should report that it is stopped.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.NotRunning), "The processor status should report that it is not running.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object), Is.Null, "There should be no active task for processing.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StopProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void StopProcessingIsSafeToCallWhenNotProcessing(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            if (async)
            {
                Assert.That(async () => await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token), Throws.Nothing, "The asynchronous stop processing should be safe to call when not processing.");
                Assert.That(async () => await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token), Throws.Nothing, "The asynchronous stop processing should be safe to call when not processing.");
            }
            else
            {
                Assert.That(() => mockProcessor.Object.StopProcessing(cancellationSource.Token), Throws.Nothing, "The synchronous stop processing should be safe to call when not processing.");
                Assert.That(() => mockProcessor.Object.StopProcessing(cancellationSource.Token), Throws.Nothing, "The synchronous stop processing should be safe to call when not processing.");
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            Assert.That(mockProcessor.Object.IsRunning, Is.False, "The processor should report that it is stopped.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.NotRunning), "The processor status should report that it is running.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object), Is.Null, "There should be no active task for processing.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StopProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StopProcessingIsSafeToCallAfterStopping(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(Mock.Of<EventHubConnection>());

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.IsRunning, Is.True, "The processor should report that it is running.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor status should report that it is running.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object).IsCompleted, Is.False, "The task for processing should be active.");

            if (async)
            {
                await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);
            }
            else
            {
                mockProcessor.Object.StopProcessing(cancellationSource.Token);
            }

            Assert.That(mockProcessor.Object.IsRunning, Is.False, "The processor should report that it is stopped.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.NotRunning), "The processor status should report that it is not running.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object), Is.Null, "There should be no active task for processing.");

            if (async)
            {
                Assert.That(async () => await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token), Throws.Nothing, "The asynchronous stop processing should be safe to call when not processing.");
                Assert.That(async () => await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token), Throws.Nothing, "The asynchronous stop processing should be safe to call when not processing.");
            }
            else
            {
                Assert.That(() => mockProcessor.Object.StopProcessing(cancellationSource.Token), Throws.Nothing, "The synchronous stop processing should be safe to call when not processing.");
                Assert.That(() => mockProcessor.Object.StopProcessing(cancellationSource.Token), Throws.Nothing, "The synchronous stop processing should be safe to call when not processing.");
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been triggered.");
            Assert.That(mockProcessor.Object.IsRunning, Is.False, "The processor should report that it is stopped.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.NotRunning), "The processor status should report that it is not running.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object), Is.Null, "There should be no active task for processing.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StopProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StopProcessingSurfacesExceptions(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var expectedException = new DivideByZeroException("BOOM!");
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Callback(() => completionSource.TrySetResult(true))
                .Throws(expectedException);

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            await completionSource.Task;

            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Faulted), "The processor status should report that it is in a faulted state.");

            if (async)
            {
                Assert.That(async () => await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token), Throws.Exception.SameAs(expectedException), "The asynchronous close call should bubble the exception.");
            }
            else
            {
                Assert.That(() => mockProcessor.Object.StopProcessing(cancellationSource.Token), Throws.Exception.SameAs(expectedException), "The synchronous close call should bubble the exception.");
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation source should not have been triggered.");
            Assert.That(mockProcessor.Object.IsRunning, Is.False, "The processor should report that it is stopped.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.NotRunning), "The processor status should report that it is not running.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object), Is.Null, "There should be no active task for processing.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StopProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StopProcessingResetsState(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var expectedException = new DivideByZeroException("BOOM!");
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor
                .SetupSequence(processor => processor.CreateConnection())
                .Throws(expectedException)
                .Returns(default(EventHubConnection));

            // Starting the processor should result in an exception on the first call, which should leave it in a faulted state.

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.IsRunning, Is.False, "The start call should have triggered an exception.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Faulted), "The processor status should report that it is faulted.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object).IsFaulted, Is.True, "The task for processing should be faulted.");

            // The processor should not reset the faulted state when calling start a second time.

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.IsRunning, Is.False, "The start call should not have been able to reset the failure state.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object).IsFaulted, Is.True, "The task for processing should be faulted.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object).IsFaulted, Is.True, "The task for processing should be faulted.");

            // Stopping the processor should clear the faulted state, as well as surface the fault.

            if (async)
            {
                Assert.That(async () => await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token), Throws.Exception.SameAs(expectedException), "The asynchronous close call should bubble the exception.");
            }
            else
            {
                Assert.That(() => mockProcessor.Object.StopProcessing(cancellationSource.Token), Throws.Exception.SameAs(expectedException), "The synchronous close call should bubble the exception.");
            }

            Assert.That(GetRunningProcessorTask(mockProcessor.Object), Is.Null, "There should be no active task for processing.");

            // After stopping, the processor state should be reset and it should be able to start.

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.IsRunning, Is.True, "The start call should succeed after stopping to reset the state.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor status should report that it is running.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object).IsCompleted, Is.False, "The task for processing should be active.");

            // Shut down the processor now that it is running and confirm that the second shutdown resets state.

            if (async)
            {
                await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);
            }
            else
            {
                mockProcessor.Object.StopProcessing(cancellationSource.Token);
            }

            Assert.That(mockProcessor.Object.IsRunning, Is.False, "The processor should report that it is stopped.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.NotRunning), "The processor status should report that it is not running.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object), Is.Null, "There should be no active task for processing.");

            // Ensure that the cancellation token used to prevent test hangs didn't get signaled, which could invalidate the
            // test results.

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation source should not have been triggered.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StopProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StopProcessingLogsNormalShutdown(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var mockEventSource = new Mock<EventHubsEventSource>() { CallBase = true };
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor.Object.Logger = mockEventSource.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(Mock.Of<EventHubConnection>());

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.IsRunning, Is.True, "The processor should have started.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor status should report that it is running.");

            if (async)
            {
                await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);
            }
            else
            {
                mockProcessor.Object.StopProcessing(cancellationSource.Token);
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.NotRunning), "The processor status should report that it is not running.");

            mockEventSource
                .Verify(log => log.EventProcessorStop(
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup),
                Times.Once);

            mockEventSource
                .Verify(log => log.EventProcessorStopComplete(
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StopProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StopProcessingLogsErrorDuringShutdown(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var mockEventSource = new Mock<EventHubsEventSource>() { CallBase = true };
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockEventSource
                .Setup(log => log.EventProcessorStop(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .Callback(() => cancellationSource.Cancel());

            mockProcessor.Object.Logger = mockEventSource.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(default(EventHubConnection));

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.IsRunning, Is.True, "The processor should be running.");
            Assert.That(mockProcessor.Object.Status, Is.EqualTo(EventProcessorStatus.Running), "The processor status should report that it is running.");

            if (async)
            {
                Assert.That(async () => await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>(), "The asynchronous close call should encounter an exception.");
            }
            else
            {
                Assert.That(() => mockProcessor.Object.StopProcessing(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>(), "The synchronous close call should encounter an exception.");
            }

            mockEventSource
                .Verify(log => log.EventProcessorStop(
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup),
                Times.Once);

            mockEventSource
               .Verify(log => log.EventProcessorStopError(
                   mockProcessor.Object.Identifier,
                   mockProcessor.Object.EventHubName,
                   mockProcessor.Object.ConsumerGroup,
                   It.IsAny<string>()),
               Times.Once);

            mockEventSource
                .Verify(log => log.EventProcessorStopComplete(
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.StopProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task StopProcessingLogsFaultedTaskDuringShutdown(bool async)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var expectedException = new DivideByZeroException("BOOM!");
            var mockEventSource = new Mock<EventHubsEventSource>() { CallBase = true };
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(4, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor.Object.Logger = mockEventSource.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Throws(expectedException);

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.IsRunning, Is.False, "The processor should have faulted during startup.");
            Assert.That(GetRunningProcessorTask(mockProcessor.Object).IsFaulted, Is.True, "The task for processing should be faulted.");

            if (async)
            {
                Assert.That(async () => await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token), Throws.Exception, "The asynchronous close call should encounter an exception.");
            }
            else
            {
                Assert.That(() => mockProcessor.Object.StopProcessing(cancellationSource.Token), Throws.Exception, "The synchronous close call should encounter an exception.");
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockEventSource
                .Verify(log => log.EventProcessorStop(
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup),
                Times.Once);

            mockEventSource
               .Verify(log => log.EventProcessorTaskError(
                   mockProcessor.Object.Identifier,
                   mockProcessor.Object.EventHubName,
                   mockProcessor.Object.ConsumerGroup,
                   expectedException.Message),
               Times.Once);

            mockEventSource
                .Verify(log => log.EventProcessorStopComplete(
                    mockProcessor.Object.Identifier,
                    mockProcessor.Object.EventHubName,
                    mockProcessor.Object.ConsumerGroup),
                Times.Once);
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
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var eventBatch = new[] { new EventData(Array.Empty<byte>()), new EventData(Array.Empty<byte>()) };
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
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

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
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

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
        public void ProcessEventBatchAsyncWrapsErrors()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

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
            Assert.That(() => mockProcessor.Object.CreatePartitionProcessor(new EventProcessorPartition(), EventPosition.Earliest, cancellationSource), Throws.InstanceOf<TaskCanceledException>());
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
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = Mock.Of<TransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>()))
                .Returns(mockConsumer);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(new EventProcessorPartition(), EventPosition.Earliest, cancellationSource);
            Assert.That(partitionProcessor.CancellationSource, Is.SameAs(cancellationSource));

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreatePartitionProcessorDoesNotAllowReadingLastEventPropertiesWithNoOption()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false };
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = Mock.Of<TransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>()))
                .Returns(mockConsumer);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(new EventProcessorPartition(), EventPosition.Earliest, cancellationSource);
            Assert.That(() => partitionProcessor.ReadLastEnqueuedEventProperties(), Throws.InstanceOf<InvalidOperationException>().And.Message.EqualTo(Resources.TrackLastEnqueuedEventPropertiesNotSet));

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreatePartitionProcessorDoesNotAllowReadingLastEventPropertiesWithNoConsumer()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = true };
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>()))
                .Returns(default(TransportConsumer));

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(new EventProcessorPartition(), EventPosition.Earliest, cancellationSource);
            Assert.That(() => partitionProcessor.ReadLastEnqueuedEventProperties(), Throws.InstanceOf<InvalidOperationException>().And.Message.EqualTo(Resources.ClientNeededForThisInformationNotAvailable));

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
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = true };
            var lastEvent = new EventData(Array.Empty<byte>(), lastPartitionSequenceNumber: 123, lastPartitionOffset: 887, lastPartitionEnqueuedTime: DateTimeOffset.Parse("2015-10-27T12:00:00Z"), lastPartitionPropertiesRetrievalTime: DateTimeOffset.Parse("2021-03-04T08:30:00Z"));
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConsumer.Object.SetLastEvent(lastEvent);

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .Callback(() => completionSource.TrySetResult(true))
                .ReturnsAsync(EmptyBatch);

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>()))
                .Returns(mockConsumer.Object);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(new EventProcessorPartition(), EventPosition.Earliest, cancellationSource);

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
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var retryOptions = new EventHubsRetryOptions { MaximumRetries = 0, MaximumDelay = TimeSpan.FromMilliseconds(5) };
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = true, RetryOptions = retryOptions };
            var lastEvent = new EventData(Array.Empty<byte>(), lastPartitionSequenceNumber: 123, lastPartitionOffset: 887, lastPartitionEnqueuedTime: DateTimeOffset.Parse("2015-10-27T12:00:00Z"), lastPartitionPropertiesRetrievalTime: DateTimeOffset.Parse("2021-03-04T08:30:00Z"));
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var badMockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConsumer.Object.SetLastEvent(lastEvent);

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
                .SetupSequence(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>()))
                .Returns(badMockConsumer.Object)
                .Returns(mockConsumer.Object);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(new EventProcessorPartition(), EventPosition.Earliest, cancellationSource);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            var lastEventProperties = partitionProcessor.ReadLastEnqueuedEventProperties();
            Assert.That(lastEventProperties, Is.EqualTo(new LastEnqueuedEventProperties(lastEvent)));

            cancellationSource.Cancel();

            mockProcessor
                .Verify(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    mockConnection,
                    It.IsAny<EventProcessorOptions>()),
                Times.AtLeast(2));
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
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var partition = new EventProcessorPartition { PartitionId = "99" };
            var position = EventPosition.FromOffset(12);
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<EventData> { new EventData(Array.Empty<byte>()), new EventData(Array.Empty<byte>()) })
                .Callback(() => completionSource.TrySetResult(true));

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>()))
                .Returns(mockConsumer.Object);

            mockProcessor
                .Setup(processor => processor.ProcessEventBatchAsync(partition, It.IsAny<IReadOnlyList<EventData>>(), It.IsAny<bool>(), cancellationSource.Token))
                .Returns(Task.CompletedTask);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, position, cancellationSource);

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
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var partition = new EventProcessorPartition { PartitionId = "99" };
            var position = EventPosition.FromOffset(12);
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<EventData> { new EventData(Array.Empty<byte>()), new EventData(Array.Empty<byte>()) })
                .Callback(() => completionSource.TrySetResult(true));

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>()))
                .Returns(mockConsumer.Object);

            mockProcessor
                 .Setup(processor => processor.ProcessEventBatchAsync(partition, It.IsAny<IReadOnlyList<EventData>>(), It.IsAny<bool>(), cancellationSource.Token))
                 .Returns(Task.CompletedTask);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, position, cancellationSource);

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
        public async Task CreatePartitionProcessorProcessingTaskDispatchesEvents()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

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
                .ReturnsAsync(new List<EventData> { new EventData(Array.Empty<byte>()), new EventData(Array.Empty<byte>()) });

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>()))
                .Returns(mockConsumer.Object);

            mockProcessor
                 .Setup(processor => processor.ProcessEventBatchAsync(partition, It.IsAny<IReadOnlyList<EventData>>(), It.IsAny<bool>(), cancellationSource.Token))
                 .Returns(Task.CompletedTask)
                 .Callback(() => completionSource.TrySetResult(true));

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, position, cancellationSource);

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
        public async Task CreatePartitionProcessorProcessingTaskDispatchesExceptions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

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
                .SetupSequence(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>()))
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

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, position, cancellationSource);
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
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

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
                .SetupSequence(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>()))
                .Returns(mockConsumer.Object)
                .Returns(Mock.Of<TransportConsumer>());

            mockProcessor
                 .Setup(processor => processor.ProcessEventBatchAsync(partition, It.IsAny<IReadOnlyList<EventData>>(), It.IsAny<bool>(), cancellationSource.Token))
                 .Returns(Task.CompletedTask);

            mockLogger
               .Setup(log => log.EventProcessorPartitionProcessingError(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
               .Callback(() => errorCompletion.TrySetResult(true));

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, position, cancellationSource);
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
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

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
                .SetupSequence(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>()))
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

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, position, cancellationSource);
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
        public async Task CreatePartitionProcessorProcessingTaskDoesNotDispatchDeveloperCodeExceptions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

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
                .ReturnsAsync(new List<EventData> { new EventData(Array.Empty<byte>()), new EventData(Array.Empty<byte>()) });

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>()))
                .Returns(mockConsumer.Object);

            mockProcessor
                 .Setup(processor => processor.ProcessEventBatchAsync(partition, It.IsAny<IReadOnlyList<EventData>>(), It.IsAny<bool>(), cancellationSource.Token))
                 .Callback(() => completionSource.TrySetResult(true))
                 .Throws(expectedException);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, position, cancellationSource);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            // Allow for a small delay because error processing is a background task, just to give it time to trigger.

            await Task.Delay(250);

            mockProcessor
                .Protected()
                .Verify("OnProcessingErrorAsync", Times.Never(),
                     expectedException,
                     partition,
                     ItExpr.IsAny<string>(),
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
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

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
                .ReturnsAsync(new List<EventData> { new EventData(Array.Empty<byte>()), new EventData(Array.Empty<byte>()) });

            mockProcessor.Object.Logger = mockLogger.Object;

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>()))
                .Returns(mockConsumer.Object);

            mockProcessor
                 .Setup(processor => processor.ProcessEventBatchAsync(partition, It.IsAny<IReadOnlyList<EventData>>(), It.IsAny<bool>(), cancellationSource.Token))
                 .Callback(() => completionSource.TrySetResult(true))
                 .Throws(expectedException);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, position, cancellationSource);

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
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

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
                .ReturnsAsync(new List<EventData> { new EventData(Array.Empty<byte>()), new EventData(Array.Empty<byte>()) });

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>()))
                .Returns(mockConsumer.Object);

            mockProcessor
                 .Setup(processor => processor.ProcessEventBatchAsync(partition, It.IsAny<IReadOnlyList<EventData>>(), It.IsAny<bool>(), cancellationSource.Token))
                 .Callback(() => completionSource.TrySetResult(true))
                 .Throws(developerException);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, position, cancellationSource);

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
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

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
                .SetupSequence(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>()))
                .Returns(mockConsumer.Object)
                .Returns(() =>
                {
                    completionSource.TrySetResult(true);
                    return Mock.Of<TransportConsumer>();
                });

            mockProcessor
                 .Setup(processor => processor.ProcessEventBatchAsync(partition, It.IsAny<IReadOnlyList<EventData>>(), It.IsAny<bool>(), cancellationSource.Token))
                 .Returns(Task.CompletedTask);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, position, cancellationSource);

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
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

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
                .SetupSequence(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>()))
                .Returns(badMockConsumer.Object)
                .Returns(() =>
                {
                    completionSource.TrySetResult(true);
                    return mockConsumer.Object;
                });

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(new EventProcessorPartition(), EventPosition.Earliest, cancellationSource);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            cancellationSource.Cancel();

            mockProcessor
                .Verify(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    mockConnection,
                    It.IsAny<EventProcessorOptions>()),
                Times.AtLeast(2));
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
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var retryOptions = new EventHubsRetryOptions { MaximumRetries = 0, MaximumDelay = TimeSpan.FromMilliseconds(5) };
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false, RetryOptions = retryOptions };
            var partition = new EventProcessorPartition { PartitionId = "4" };
            var lastEventBatch = new List<EventData> { new EventData(Array.Empty<byte>()), new EventData(Array.Empty<byte>(), offset: 9987) };
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
                .ReturnsAsync(new List<EventData> { new EventData(Array.Empty<byte>()) })
                .ReturnsAsync(lastEventBatch)
                .Throws(new DllNotFoundException());

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .SetupSequence(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>()))
                .Returns(badMockConsumer.Object)
                .Returns(() =>
                {
                    completionSource.TrySetResult(true);
                    return mockConsumer.Object;
                });

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, initialStartingPosition, cancellationSource);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            cancellationSource.Cancel();

            mockProcessor
                .Verify(processor => processor.CreateConsumer(
                    mockProcessor.Object.ConsumerGroup,
                    partition.PartitionId,
                    initialStartingPosition,
                    mockConnection,
                    It.IsAny<EventProcessorOptions>()),
                Times.Once);

            mockProcessor
                .Verify(processor => processor.CreateConsumer(
                    mockProcessor.Object.ConsumerGroup,
                    partition.PartitionId,
                    EventPosition.FromOffset(lastEventBatch.Last().Offset, false),
                    mockConnection,
                    It.IsAny<EventProcessorOptions>()),
                Times.Once);
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
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(20));

            var expectedException = new TaskCanceledException("Like the others, but this one is special!");
            var retryOptions = new EventHubsRetryOptions { MaximumRetries = 0, MaximumDelay = TimeSpan.FromMilliseconds(5) };
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
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>()))
                .Returns(mockConsumer.Object)
                .Callback(() => completionSource.TrySetResult(true));

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(new EventProcessorPartition(), EventPosition.Earliest, cancellationSource);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            cancellationSource.Cancel();
            Assert.That(async () => await partitionProcessor.ProcessingTask, Throws.TypeOf(expectedException.GetType()).And.Message.EqualTo(expectedException.Message), "The exception should have been surfaced by the task.");

            mockProcessor
                .Verify(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    mockConnection,
                    It.IsAny<EventProcessorOptions>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}.CreatePartitionProcessor" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [Ignore("Test unstable in CI; requires investigation")]
        public async Task CreatePartitionProcessorProcessingTaskWrapsAnOperationCanceledExceptionAndConsidersItFatal()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var expectedException = new OperationCanceledException("STAHP!");
            var retryOptions = new EventHubsRetryOptions { MaximumRetries = 0, MaximumDelay = TimeSpan.FromMilliseconds(5) };
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
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>()))
                .Returns(mockConsumer.Object)
                .Callback(() => completionSource.TrySetResult(true));

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(new EventProcessorPartition(), EventPosition.Earliest, cancellationSource);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            cancellationSource.Cancel();
            Assert.That(async () => await partitionProcessor.ProcessingTask, Throws.InstanceOf<TaskCanceledException>().And.InnerException.EqualTo(expectedException), "The wrapped exception should have been surfaced by the task.");

            mockProcessor
                .Verify(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    mockConnection,
                    It.IsAny<EventProcessorOptions>()),
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
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var retryOptions = new EventHubsRetryOptions { MaximumRetries = 0, MaximumDelay = TimeSpan.FromMilliseconds(5) };
            var options = new EventProcessorOptions { TrackLastEnqueuedEventProperties = false, RetryOptions = retryOptions };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockConnection = Mock.Of<EventHubConnection>();
            var mockConsumer = new Mock<SettableTransportConsumer>();
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(5, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), options) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(EmptyBatch)
                .Callback(() =>
                {
                    completionSource.TrySetResult(true);
                });

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Returns(mockConnection);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>()))
                .Returns(mockConsumer.Object);

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(new EventProcessorPartition(), EventPosition.Earliest, cancellationSource);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            cancellationSource.Cancel();
            Assert.That(async () => await partitionProcessor.ProcessingTask, Throws.InstanceOf<TaskCanceledException>(), "The cancellation should have been surfaced by the task.");

            mockProcessor
                .Verify(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    mockConnection,
                    It.IsAny<EventProcessorOptions>()),
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
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

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
                .SetupSequence(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>()))
                .Returns(badMockConsumer.Object)
                .Returns(() =>
                {
                    completionSource.TrySetResult(true);
                    return mockConsumer.Object;
                });

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(new EventProcessorPartition(), EventPosition.Earliest, cancellationSource);

            await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            cancellationSource.Cancel();

            mockProcessor
                .Verify(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    mockConnection,
                    It.IsAny<EventProcessorOptions>()),
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
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

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
                .SetupSequence(processor => processor.CreateConsumer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventPosition>(), mockConnection, It.IsAny<EventProcessorOptions>()))
                .Returns(badMockConsumer.Object)
                .Returns(() =>
                {
                    completionSource.TrySetResult(true);
                    return mockConsumer.Object;
                });

            var partitionProcessor = mockProcessor.Object.CreatePartitionProcessor(partition, EventPosition.Earliest, cancellationSource);

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
        ///   Verifies functionality of the <see cref="StorageManager" />
        ///   used by the processor.
        /// </summary>
        ///
        [Test]
        public async Task ProcessorStorageManagerDelegatesCalls()
        {
            var listCheckpointsDelegated = false;
            var listOwnershipDelegated = false;
            var claimOwnershipDelegated = false;
            var fqNamespace = "fqns";
            var eventHub = "eh";
            var consumerGroup = "cg";
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(25, consumerGroup, fqNamespace, eventHub, Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor
                .Protected()
                .Setup<Task<IEnumerable<EventProcessorCheckpoint>>>("ListCheckpointsAsync", ItExpr.IsAny<CancellationToken>())
                .Callback(() => listCheckpointsDelegated = true)
                .Returns(Task.FromResult(default(IEnumerable<EventProcessorCheckpoint>)));

            mockProcessor
                .Protected()
                .Setup<Task<IEnumerable<EventProcessorPartitionOwnership>>>("ListOwnershipAsync", ItExpr.IsAny<CancellationToken>())
                .Callback(() => listOwnershipDelegated = true)
                .Returns(Task.FromResult(default(IEnumerable<EventProcessorPartitionOwnership>)));

            mockProcessor
                .Protected()
                .Setup<Task<IEnumerable<EventProcessorPartitionOwnership>>>("ClaimOwnershipAsync", ItExpr.IsAny<IEnumerable<EventProcessorPartitionOwnership>>(), ItExpr.IsAny<CancellationToken>())
                .Callback(() => claimOwnershipDelegated = true)
                .Returns(Task.FromResult(default(IEnumerable<EventProcessorPartitionOwnership>)));

            var storageManager = mockProcessor.Object.CreateStorageManager(mockProcessor.Object);
            Assert.That(storageManager, Is.Not.Null, "The storage manager should have been created.");

            await storageManager.ListCheckpointsAsync("na", "na", "na", CancellationToken.None);
            Assert.That(listCheckpointsDelegated, Is.True, $"The call to { nameof(storageManager.ListCheckpointsAsync) } should have been delegated.");

            await storageManager.ListOwnershipAsync("na", "na", "na", CancellationToken.None);
            Assert.That(listOwnershipDelegated, Is.True, $"The call to { nameof(storageManager.ListOwnershipAsync) } should have been delegated.");

            await storageManager.ClaimOwnershipAsync(default(IEnumerable<EventProcessorPartitionOwnership>), CancellationToken.None);
            Assert.That(claimOwnershipDelegated, Is.True, $"The call to { nameof(storageManager.ClaimOwnershipAsync) } should have been delegated.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="StorageManager" />
        ///   used by the processor.
        /// </summary>
        ///
        [Test]
        public void ProcessorStorageManagerDoesNotAllowCheckpointUpdate()
        {
            var fqNamespace = "fqns";
            var eventHub = "eh";
            var consumerGroup = "cg";
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(25, consumerGroup, fqNamespace, eventHub, Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            var storageManager = mockProcessor.Object.CreateStorageManager(mockProcessor.Object);
            Assert.That(storageManager, Is.Not.Null, "The storage manager should have been created.");

            Assert.That(() => storageManager.UpdateCheckpointAsync(new EventProcessorCheckpoint(), new EventData(Array.Empty<byte>()), CancellationToken.None), Throws.InstanceOf<NotImplementedException>(), "Calling to update checkpoints should not be implemented.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public async Task ProcessorLoadBalancerUsesTheExpectedStorageManager()
        {
            var fqNamespace = "fqns";
            var eventHub = "eh";
            var consumerGroup = "cg";
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(25, consumerGroup, fqNamespace, eventHub, Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };
            var loadBalancer = GetLoadBalancer(mockProcessor.Object);

            Assert.That(loadBalancer, Is.Not.Null, "The load balancer should have been created.");
            await loadBalancer.RelinquishOwnershipAsync(CancellationToken.None);

            mockProcessor
                .Protected()
                .Verify<Task<IEnumerable<EventProcessorPartitionOwnership>>>("ClaimOwnershipAsync", Times.Once(), ItExpr.IsAny<IEnumerable<EventProcessorPartitionOwnership>>(), ItExpr.IsAny<CancellationToken>());
        }

        /// <summary>
        ///   Retrieves the load balancer for an event processor instance, using its private accessor.
        /// </summary>
        ///
        /// <typeparam name="T">The partition type to which the processor is bound.</typeparam>
        ///
        /// <param name="processor">The processor instance to operate on.</param>
        ///
        /// <returns>The load balancer used by the processor.</returns>
        ///
        private static PartitionLoadBalancer GetLoadBalancer<T>(EventProcessor<T> processor) where T : EventProcessorPartition, new() =>
            (PartitionLoadBalancer)
                typeof(EventProcessor<T>)
                    .GetProperty("LoadBalancer", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(processor);

        /// <summary>
        ///   Creates a connection using a processor client's ConnectionFactory and returns its ConnectionOptions.
        /// </summary>
        ///
        /// <typeparam name="T">The partition type to which the processor is bound.</typeparam>
        ///
        /// <param name="processor">The processor instance to operate on.</param>
        ///
        /// <returns>The set of options used by the connection.</returns>
        ///
        private static EventHubConnectionOptions GetConnectionOptions<T>(EventProcessor<T> processor) where T : EventProcessorPartition, new() =>
            (EventHubConnectionOptions)
                typeof(EventHubConnection)
                    .GetProperty("Options", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(processor.CreateConnection());

        /// <summary>
        ///   Retrieves the task used to track the processor's activity when running, using its private accessor.
        /// </summary>
        ///
        /// <typeparam name="T">The partition type to which the processor is bound.</typeparam>
        ///
        /// <param name="processor">The processor instance to operate on.</param>
        ///
        /// <returns>The task for tracking the processor's activity when running.</returns>
        ///
        private static Task GetRunningProcessorTask<T>(EventProcessor<T> processor) where T : EventProcessorPartition, new() =>
            (Task)
                typeof(EventProcessor<T>)
                    .GetField("_runningProcessorTask", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(processor);

        /// <summary>
        ///   A basic mock of the event processor, allowing for testing of specific base class
        ///   functionality.
        /// </summary>
        ///
        public class ProcessorConstructorMock : EventProcessor<EventProcessorPartition>
        {
            public ProcessorConstructorMock(int eventBatchMaximumCount,
                                            string consumerGroup,
                                            string connectionString,
                                            EventProcessorOptions options = default) : base(eventBatchMaximumCount, consumerGroup, connectionString, options) { }

            public ProcessorConstructorMock(int eventBatchMaximumCount,
                                            string consumerGroup,
                                            string connectionString,
                                            string eventHubName,
                                            EventProcessorOptions options = default) : base(eventBatchMaximumCount, consumerGroup, connectionString, eventHubName, options) { }

            public ProcessorConstructorMock(int eventBatchMaximumCount,
                                            string consumerGroup,
                                            string fullyQualifiedNamespace,
                                            string eventHubName,
                                            TokenCredential credential,
                                            EventProcessorOptions options = default) : base(eventBatchMaximumCount, consumerGroup, fullyQualifiedNamespace, eventHubName, credential, options) { }

            protected override Task<IEnumerable<EventProcessorPartitionOwnership>> ClaimOwnershipAsync(IEnumerable<EventProcessorPartitionOwnership> desiredOwnership, CancellationToken cancellationToken) => throw new NotImplementedException();
            protected override Task<IEnumerable<EventProcessorCheckpoint>> ListCheckpointsAsync(CancellationToken cancellationToken) => throw new NotImplementedException();
            protected override Task<IEnumerable<EventProcessorPartitionOwnership>> ListOwnershipAsync(CancellationToken cancellationToken) => throw new NotImplementedException();
            protected override Task OnProcessingErrorAsync(Exception exception, EventProcessorPartition partition, string operationDescription, CancellationToken cancellationToken) => throw new NotImplementedException();
            protected override Task OnProcessingEventBatchAsync(IEnumerable<EventData> events, EventProcessorPartition partition, CancellationToken cancellationToken) => throw new NotImplementedException();
        }

        /// <summary>
        ///   A shim for the transport consumer, allowing setting of base class
        ///   protected properties.
        /// </summary>
        ///
        internal class SettableTransportConsumer : TransportConsumer
        {
            public void SetLastEvent(EventData lastEvent) => LastReceivedEvent = lastEvent;
            public override Task CloseAsync(CancellationToken cancellationToken) => throw new NotImplementedException();
            public override Task<IReadOnlyList<EventData>> ReceiveAsync(int maximumMessageCount, TimeSpan? maximumWaitTime, CancellationToken cancellationToken) => throw new NotImplementedException();
        }
    }
}
