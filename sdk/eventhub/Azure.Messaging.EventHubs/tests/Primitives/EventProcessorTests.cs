// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Consumer;
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
        /// <summary>
        ///   Provides test cases for the constructor tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ConstructorCreatesDefaultOptionsCases()
        {
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var connectionStringNoHub = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123";
            var credential = Mock.Of<TokenCredential>();

            yield return new object[] { new BasicProcessorMock(99, "consumerGroup", connectionString), "connection string with default options" };
            yield return new object[] { new BasicProcessorMock(99, "consumerGroup", connectionStringNoHub, "hub", default), "connection string with default options" };
            yield return new object[] { new BasicProcessorMock(99, "consumerGroup", "namespace", "hub", credential, default(EventProcessorOptions)), "namespace with explicit null options" };
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
            Assert.That(() => new BasicProcessorMock(constructorArgument, "dummyGroup", "dummyConnection", new EventProcessorOptions()), Throws.InstanceOf<ArgumentException>(), "The connection string constructor should validate the maximum batch size.");
            Assert.That(() => new BasicProcessorMock(constructorArgument, "dummyGroup", "dummyNamespace", "dummyEventHub", Mock.Of<TokenCredential>(), new EventProcessorOptions()), Throws.InstanceOf<ArgumentException>(), "The namespace constructor should validate the maximum batch size.");
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
            Assert.That(() => new BasicProcessorMock(1, constructorArgument, "dummyConnection", new EventProcessorOptions()), Throws.InstanceOf<ArgumentException>(), "The connection string constructor should validate the consumer group.");
            Assert.That(() => new BasicProcessorMock(1, constructorArgument, "dummyNamespace", "dummyEventHub", Mock.Of<TokenCredential>(), new EventProcessorOptions()), Throws.InstanceOf<ArgumentException>(), "The namespace constructor should validate the consumer group.");
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
            Assert.That(() => new BasicProcessorMock(1, EventHubConsumerClient.DefaultConsumerGroupName, connectionString), Throws.InstanceOf<ArgumentException>(), "The constructor without options should ensure a connection string.");
            Assert.That(() => new BasicProcessorMock(1, EventHubConsumerClient.DefaultConsumerGroupName, connectionString, "dummy", new EventProcessorOptions()), Throws.InstanceOf<ArgumentException>(), "The constructor with options should ensure a connection string.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheNamespace(string constructorArgument)
        {
            Assert.That(() => new BasicProcessorMock(1, EventHubConsumerClient.DefaultConsumerGroupName, constructorArgument, "dummy", Mock.Of<TokenCredential>()), Throws.InstanceOf<ArgumentException>());
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
            Assert.That(() => new BasicProcessorMock(100, EventHubConsumerClient.DefaultConsumerGroupName, "namespace", constructorArgument, Mock.Of<TokenCredential>()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheCredential()
        {
            Assert.That(() => new BasicProcessorMock(5, EventHubConsumerClient.DefaultConsumerGroupName, "namespace", "hubName", default(TokenCredential)), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorCreatesDefaultOptionsCases))]
        public void ConstructorCreatesDefaultOptions(BasicProcessorMock eventProcessor,
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

            var eventProcessor = new BasicProcessorMock(1, "consumerGroup", "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub", options);

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

            var eventProcessor = new BasicProcessorMock(11, "consumerGroup", "namespace", "hub", Mock.Of<TokenCredential>(), options);

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

            var eventProcessor = new BasicProcessorMock(72, "consumerGroup", "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub", options);

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

            var eventProcessor = new BasicProcessorMock(65, "consumerGroup", "namespace", "hub", Mock.Of<TokenCredential>(), options);

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

            var eventProcessor = new BasicProcessorMock(34, "consumerGroup", "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub", options);

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

            var eventProcessor = new BasicProcessorMock(665, "consumerGroup", "namespace", "hub", Mock.Of<TokenCredential>(), options);

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
        public void StartProcessingRespectsACanceledToken(bool async)
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
        public void StopProcessingRespectsACanceledToken(bool async)
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
            var mockProcessor = new Mock<EventProcessor<EventProcessorPartition>>(65, "consumerGroup", "namespace", "eventHub", Mock.Of<TokenCredential>(), default(EventProcessorOptions)) { CallBase = true };

            mockProcessor
                .Setup(processor => processor.CreateConnection())
                .Throws(expectedException);

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);

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
            Assert.That(GetRunningProcessorTask(mockProcessor.Object).IsFaulted, Is.True, "The task for processing should be faulted.");

            // The processor should not reset the faulted state when calling start a second time.

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            Assert.That(mockProcessor.Object.IsRunning, Is.False, "The start call should not have been able to reset the failure state.");
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

            if (async)
            {
                await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);
            }
            else
            {
                mockProcessor.Object.StopProcessing(cancellationSource.Token);
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

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
               .Verify(log => log.EventProcessingTaskError(
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
        public class BasicProcessorMock : EventProcessor<EventProcessorPartition>
        {
            public BasicProcessorMock(int eventBatchMaximumCount,
                                      string consumerGroup,
                                      string connectionString,
                                      EventProcessorOptions options = default) : base(eventBatchMaximumCount, consumerGroup, connectionString, options) { }

            public BasicProcessorMock(int eventBatchMaximumCount,
                                      string consumerGroup,
                                      string connectionString,
                                      string eventHubName,
                                      EventProcessorOptions options = default) : base(eventBatchMaximumCount, consumerGroup, connectionString, eventHubName, options) { }

            public BasicProcessorMock(int eventBatchMaximumCount,
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
    }
}
