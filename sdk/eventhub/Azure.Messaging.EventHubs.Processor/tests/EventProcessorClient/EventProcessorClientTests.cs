// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Processor;
using Azure.Messaging.EventHubs.Processor.Diagnostics;
using Azure.Messaging.EventHubs.Processor.Tests;
using Azure.Storage.Blobs;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventProcessorClient" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventProcessorClientTests
    {
        /// <summary>
        ///   Provides test cases for the constructor tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ConstructorCreatesDefaultOptionsCases()
        {
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net");

            yield return new object[] { new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", connectionString), "connection string with default options" };
            yield return new object[] { new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", connectionString, default(EventProcessorClientOptions)), "connection string with explicit null options" };
            yield return new object[] { new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "namespace", "hub", credential.Object), "namespace with default options" };
            yield return new object[] { new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "namespace", "hub", credential.Object, default(EventProcessorClientOptions)), "namespace with explicit null options" };
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheConsumerGroup(string consumerGroup)
        {
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net");
            Assert.That(() => new EventProcessorClient(Mock.Of<BlobContainerClient>(), consumerGroup, "dummyConnection", new EventProcessorClientOptions()), Throws.InstanceOf<ArgumentException>(), "The connection string constructor should validate the consumer group.");
            Assert.That(() => new EventProcessorClient(Mock.Of<BlobContainerClient>(), consumerGroup, "dummyNamespace", "dummyEventHub", credential.Object, new EventProcessorClientOptions()), Throws.InstanceOf<ArgumentException>(), "The namespace constructor should validate the consumer group.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheBlobContainerClient()
        {
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net");
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake";

            Assert.That(() => new EventProcessorClient(null, "consumerGroup", fakeConnection, new EventProcessorClientOptions()), Throws.InstanceOf<ArgumentNullException>(), "The connection string constructor should validate the blob container client.");
            Assert.That(() => new EventProcessorClient(null, "consumerGroup", "dummyNamespace", "dummyEventHub", credential.Object, new EventProcessorClientOptions()), Throws.InstanceOf<ArgumentNullException>(), "The namespace constructor should validate the blob container client.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheConnectionString(string connectionString)
        {
            Assert.That(() => new EventProcessorClient(Mock.Of<BlobContainerClient>(), EventHubConsumerClient.DefaultConsumerGroupName, connectionString), Throws.InstanceOf<ArgumentException>(), "The constructor without options should ensure a connection string.");
            Assert.That(() => new EventProcessorClient(Mock.Of<BlobContainerClient>(), EventHubConsumerClient.DefaultConsumerGroupName, connectionString, "dummy", new EventProcessorClientOptions()), Throws.InstanceOf<ArgumentException>(), "The constructor with options should ensure a connection string.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheNamespace(string constructorArgument)
        {
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net");
            Assert.That(() => new EventProcessorClient(Mock.Of<BlobContainerClient>(), EventHubConsumerClient.DefaultConsumerGroupName, constructorArgument, "dummy", credential.Object), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheEventHub(string constructorArgument)
        {
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net");
            Assert.That(() => new EventProcessorClient(Mock.Of<BlobContainerClient>(), EventHubConsumerClient.DefaultConsumerGroupName, "namespace", constructorArgument, credential.Object), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheCredential()
        {
            Assert.That(() => new EventProcessorClient(Mock.Of<BlobContainerClient>(), EventHubConsumerClient.DefaultConsumerGroupName, "namespace", "hubName", default(TokenCredential)), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorSetsTheRetryPolicy()
        {
            var expected = Mock.Of<EventHubsRetryPolicy>();
            var options = new EventProcessorClientOptions { RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = expected } };
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var processor = new EventProcessorClient(Mock.Of<BlobContainerClient>(), EventHubConsumerClient.DefaultConsumerGroupName, connectionString, options);

            Assert.That(GetRetryPolicy(processor), Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void NamespaceConstructorSetsTheRetryPolicy()
        {
            var expected = Mock.Of<EventHubsRetryPolicy>();
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net");
            var options = new EventProcessorClientOptions { RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = expected } };
            var processor = new EventProcessorClient(Mock.Of<BlobContainerClient>(), EventHubConsumerClient.DefaultConsumerGroupName, "namespace", "hubName", credential.Object, options);

            Assert.That(GetRetryPolicy(processor), Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorCreatesDefaultOptionsCases))]
        public void ConstructorCreatesDefaultOptions(EventProcessorClient eventProcessor,
                                                     string constructorDescription)
        {
            var defaultOptions = new EventProcessorClientOptions();
            var consumerOptions = GetProcessingConsumerOptions(eventProcessor);
            var readOptions = GetProcessingReadEventOptions(eventProcessor);
            var connectionOptions = GetConnectionOptionsSample(eventProcessor);

            Assert.That(consumerOptions, Is.Not.Null, $"The { constructorDescription } constructor should have set the processing consumer options.");
            Assert.That(readOptions, Is.Not.Null, $"The { constructorDescription } constructor should have set the processing read event options.");

            Assert.That(readOptions.TrackLastEnqueuedEventProperties, Is.EqualTo(defaultOptions.TrackLastEnqueuedEventProperties), $"The { constructorDescription } constructor should default tracking of last event information.");
            Assert.That(readOptions.MaximumWaitTime, Is.EqualTo(defaultOptions.MaximumWaitTime), $"The { constructorDescription } constructor should have set the correct maximum wait time.");
            Assert.That(consumerOptions.RetryOptions.IsEquivalentTo(defaultOptions.RetryOptions), Is.True, $"The { constructorDescription } constructor should have set the correct retry options.");
            Assert.That(connectionOptions.TransportType, Is.EqualTo(defaultOptions.ConnectionOptions.TransportType), $"The { constructorDescription } constructor should have a default set of connection options.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorCreatesTheProcessingConsumerOptions()
        {
            var options = new EventProcessorClientOptions
            {
                RetryOptions = new EventHubsRetryOptions { TryTimeout = TimeSpan.FromMinutes(1), Delay = TimeSpan.FromMinutes(4) }
            };

            var eventProcessor = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub", options);
            var consumerOptions = GetProcessingConsumerOptions(eventProcessor);

            Assert.That(consumerOptions, Is.Not.Null, "The constructor should have set the processing consumer options.");
            Assert.That(consumerOptions.RetryOptions.IsEquivalentTo(options.RetryOptions), Is.True, "The retry options of the processing consumer options should be considered equal.");
            Assert.That(consumerOptions.RetryOptions, Is.Not.SameAs(options.RetryOptions), "The constructor should have cloned the retry options.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void NamespaceConstructorCreatesTheProcessingConsumerOptions()
        {
            var options = new EventProcessorClientOptions
            {
                RetryOptions = new EventHubsRetryOptions { TryTimeout = TimeSpan.FromMinutes(1), Delay = TimeSpan.FromMinutes(4) }
            };

            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net");
            var eventProcessor = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "namespace", "hub", credential.Object, options);
            var consumerOptions = GetProcessingConsumerOptions(eventProcessor);

            Assert.That(consumerOptions, Is.Not.Null, "The constructor should have set the processing consumer options.");
            Assert.That(consumerOptions.RetryOptions.IsEquivalentTo(options.RetryOptions), Is.True, "The retry options of the processing consumer options should be considered equal.");
            Assert.That(consumerOptions.RetryOptions, Is.Not.SameAs(options.RetryOptions), "The constructor should have cloned the retry options.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorCreatesTheProcessingReadEventOptions()
        {
            var options = new EventProcessorClientOptions
            {
                TrackLastEnqueuedEventProperties = false,
                MaximumWaitTime = TimeSpan.FromMinutes(65)
            };

            var eventProcessor = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub", options);
            var readOptions = GetProcessingReadEventOptions(eventProcessor);

            Assert.That(readOptions, Is.Not.Null, "The constructor should have set the processing read event options.");
            Assert.That(readOptions.TrackLastEnqueuedEventProperties, Is.EqualTo(options.TrackLastEnqueuedEventProperties), "The tracking of last event information of the processing read event options should match.");
            Assert.That(readOptions.MaximumWaitTime, Is.EqualTo(options.MaximumWaitTime), "The constructor should have set the correct maximum wait time.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void NamespaceConstructorCreatesTheProcessingReadEventOptions()
        {
            var options = new EventProcessorClientOptions
            {
                TrackLastEnqueuedEventProperties = false,
                MaximumWaitTime = TimeSpan.FromMinutes(65)
            };

            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net");
            var eventProcessor = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "namespace", "hub", credential.Object, options);
            var readOptions = GetProcessingReadEventOptions(eventProcessor);

            Assert.That(readOptions, Is.Not.Null, "The constructor should have set the processing read event options.");
            Assert.That(readOptions.TrackLastEnqueuedEventProperties, Is.EqualTo(options.TrackLastEnqueuedEventProperties), "The tracking of last event information of the processing read event options should match.");
            Assert.That(readOptions.MaximumWaitTime, Is.EqualTo(options.MaximumWaitTime), "The constructor should have set the correct maximum wait time.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorClonesTheConnectionOptions()
        {
            var expectedTransportType = EventHubsTransportType.AmqpWebSockets;
            var otherTransportType = EventHubsTransportType.AmqpTcp;

            var options = new EventProcessorClientOptions
            {
                ConnectionOptions = new EventHubConnectionOptions { TransportType = expectedTransportType }
            };

            var eventProcessor = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub", options);

            // Simply retrieving the options from an inner connection won't be enough to prove the processor clones
            // its connection options because the cloning step also happens in the EventHubConnection constructor.
            // For this reason, we will change the transport type and verify that it won't affect the returned
            // connection options.

            options.ConnectionOptions.TransportType = otherTransportType;

            var connectionOptions = GetConnectionOptionsSample(eventProcessor);

            Assert.That(connectionOptions.TransportType, Is.EqualTo(expectedTransportType), $"The connection options should have been cloned.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void NamespaceConstructorClonesTheConnectionOptions()
        {
            var expectedTransportType = EventHubsTransportType.AmqpWebSockets;
            var otherTransportType = EventHubsTransportType.AmqpTcp;

            var options = new EventProcessorClientOptions
            {
                ConnectionOptions = new EventHubConnectionOptions { TransportType = expectedTransportType }
            };

            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net");
            var eventProcessor = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "namespace", "hub", credential.Object, options);

            // Simply retrieving the options from an inner connection won't be enough to prove the processor clones
            // its connection options because the cloning step also happens in the EventHubConnection constructor.
            // For this reason, we will change the transport type and verify that it won't affect the returned
            // connection options.

            options.ConnectionOptions.TransportType = otherTransportType;

            var connectionOptions = GetConnectionOptionsSample(eventProcessor);

            Assert.That(connectionOptions.TransportType, Is.EqualTo(expectedTransportType), $"The connection options should have been cloned.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorSetsTheIdentifier()
        {
            var options = new EventProcessorClientOptions
            {
                Identifier = Guid.NewGuid().ToString()
            };

            var eventProcessor = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub", options);

            Assert.That(eventProcessor.Identifier, Is.Not.Null);
            Assert.That(eventProcessor.Identifier, Is.EqualTo(options.Identifier));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void NamespaceConstructorSetsTheIdentifier()
        {
            var options = new EventProcessorClientOptions
            {
                Identifier = Guid.NewGuid().ToString()
            };

            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net");
            var eventProcessor = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "namespace", "hub", credential.Object, options);

            Assert.That(eventProcessor.Identifier, Is.Not.Null);
            Assert.That(eventProcessor.Identifier, Is.EqualTo(options.Identifier));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConnectionStringConstructorCreatesTheIdentifierWhenNotSpecified(string identifier)
        {
            var options = new EventProcessorClientOptions
            {
                Identifier = identifier
            };

            var eventProcessor = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub", options);

            Assert.That(eventProcessor.Identifier, Is.Not.Null);
            Assert.That(eventProcessor.Identifier, Is.Not.Empty);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void NamespaceConstructorCreatesTheIdentifierWhenNotSpecified(string identifier)
        {
            var options = new EventProcessorClientOptions
            {
                Identifier = identifier
            };

            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net");
            var eventProcessor = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "namespace", "hub", credential.Object, options);

            Assert.That(eventProcessor.Identifier, Is.Not.Null);
            Assert.That(eventProcessor.Identifier, Is.Not.Empty);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorCopiesTheIdentifier()
        {
            var clientOptions = new EventProcessorClientOptions { Identifier = Guid.NewGuid().ToString() };
            var eventProcessor = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub", clientOptions);

            Assert.That(eventProcessor.Identifier, Is.EqualTo(clientOptions.Identifier));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void NamespaceConstructorCopiesTheIdentifier()
        {
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net");
            var clientOptions = new EventProcessorClientOptions { Identifier = Guid.NewGuid().ToString() };
            var eventProcessor = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "namespace", "hub", credential.Object, clientOptions);

            Assert.That(eventProcessor.Identifier, Is.EqualTo(clientOptions.Identifier));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.StartAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void StartAsyncValidatesProcessEventsAsync()
        {
            var processor = new EventProcessorClient(Mock.Of<PartitionManager>(), "consumerGroup", "namespace", "eventHub", () => new MockConnection(), default);
            processor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            Assert.That(async () => await processor.StartProcessingAsync(), Throws.InstanceOf<InvalidOperationException>().And.Message.Contains(nameof(EventProcessorClient.ProcessEventAsync)));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.StartAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void StartAsyncValidatesProcessExceptionAsync()
        {
            var processor = new EventProcessorClient(Mock.Of<PartitionManager>(), "consumerGroup", "namespace", "eventHub", () => new MockConnection(), default);
            processor.ProcessEventAsync += eventArgs => Task.CompletedTask;

            Assert.That(async () => await processor.StartProcessingAsync(), Throws.InstanceOf<InvalidOperationException>().And.Message.Contains(nameof(EventProcessorClient.ProcessErrorAsync)));
        }

        /// <summary>
        ///   Verify logs for the <see cref="EventProcessorClient" />.
        /// </summary>
        ///
        [Test]
        public async Task VerifiesEventProcessorLogs()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            string[] partitionIds = {"0"};

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(partitionIds));

            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<PartitionManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default);

            var mockLog = new Mock<EventProcessorEventSource>();
            mockProcessor.CallBase = true;
            mockProcessor.Object.Logger = mockLog.Object;

            mockProcessor
                .Setup(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<EventHubConnection>(),
                    It.IsAny<EventHubConsumerClientOptions>()))
                .Returns(mockConsumer.Object);

            mockProcessor.Object.ProcessEventAsync += eventArgs => Task.CompletedTask;
            mockProcessor.Object.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            Assert.That(async () => await mockProcessor.Object.StartProcessingAsync(), Throws.Nothing);

            await mockProcessor.Object.StopProcessingAsync();

            mockLog.Verify(m => m.EventProcessorStart(mockProcessor.Object.Identifier));
            mockLog.Verify(m => m.EventProcessorStopStart(mockProcessor.Object.Identifier));
            mockLog.Verify(m => m.RenewOwnershipStart(mockProcessor.Object.Identifier));
            mockLog.Verify(m => m.RenewOwnershipComplete(mockProcessor.Object.Identifier));
            mockLog.Verify(m => m.ClaimOwnershipStart(partitionIds[0]));
            mockLog.Verify(m => m.UpdateCheckpointStart(partitionIds[0]));
            mockLog.Verify(m => m.UpdateCheckpointComplete(partitionIds[0]));
            mockLog.Verify(m => m.EventProcessorStopComplete(mockProcessor.Object.Identifier));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.StartAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task StartAsyncStartsTheEventProcessorWhenProcessingHandlerPropertiesAreSet()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Array.Empty<string>()));

            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<PartitionManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<EventHubConnection>(),
                    It.IsAny<EventHubConsumerClientOptions>()))
                .Returns(mockConsumer.Object);

            mockProcessor.Object.ProcessEventAsync += eventArgs => Task.CompletedTask;
            mockProcessor.Object.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            Assert.That(async () => await mockProcessor.Object.StartProcessingAsync(), Throws.Nothing);

            await mockProcessor.Object.StopProcessingAsync();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.ProcessErrorAsync" />
        ///   event.
        /// </summary>
        ///
        [Test]
        public async Task ProcessErrorAsyncDoesNotBlockStopping()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new Mock<EventProcessorClient>(new MockCheckPointStorage(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ThrowsAsync(new InvalidCastException());

            mockConsumer
                .Setup(consumer => consumer.ReadEventsFromPartitionAsync(
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<ReadEventOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns<string, EventPosition, ReadEventOptions, CancellationToken>((partition, position, options, token) => MockPartitionEventEnumerable(20, token));

            mockProcessor
                .Setup(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<EventHubConnection>(),
                    It.IsAny<EventHubConsumerClientOptions>()))
                .Returns(mockConsumer.Object);

            mockProcessor.Object.ProcessEventAsync += eventArgs => Task.CompletedTask;

            // Create a handler that does not complete in a reasonable amount of time.  To ensure that the
            // test does not hang for the duration, set a timeout to force completion after a shorter period
            // of time.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var completionSource = new TaskCompletionSource<bool>();

            mockProcessor.Object.ProcessErrorAsync += async eventArgs =>
            {
                completionSource.SetResult(true);
                await Task.Delay(TimeSpan.FromMinutes(3), cancellationSource.Token);
            };

            // Start the processor and wait for the event handler to be triggered.

            await mockProcessor.Object.StartProcessingAsync();
            await completionSource.Task;

            // Stop the processor and ensure that it does not block on the handler.

            Assert.That(async () => await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token), Throws.Nothing, "The processor should stop without a problem.");
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.ProcessErrorAsync" />
        ///   event.
        /// </summary>
        ///
        [Test]
        public async Task ProcessErrorAsyncCanStopTheEventProcessorClient()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new Mock<EventProcessorClient>(new MockCheckPointStorage(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ThrowsAsync(new InvalidCastException());

            mockConsumer
                .Setup(consumer => consumer.ReadEventsFromPartitionAsync(
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<ReadEventOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns<string, EventPosition, ReadEventOptions, CancellationToken>((partition, position, options, token) => MockPartitionEventEnumerable(20, token));

            mockProcessor
                .Setup(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<EventHubConnection>(),
                    It.IsAny<EventHubConsumerClientOptions>()))
                .Returns(mockConsumer.Object);

            mockProcessor.Object.ProcessEventAsync += eventArgs => Task.CompletedTask;

            var completionSource = new TaskCompletionSource<bool>();

            mockProcessor.Object.ProcessErrorAsync += async eventArgs =>
            {
                await mockProcessor.Object.StopProcessingAsync();
                completionSource.SetResult(true);
            };

            // Start the processor and wait for the event handler to be triggered.

            await mockProcessor.Object.StartProcessingAsync();
            await completionSource.Task;

            // Ensure that the processor has been stopped.

            Assert.That(mockProcessor.Object.IsRunning, Is.False, "The processor should have stopped.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.ProcessEventAsync" />
        ///   event.
        /// </summary>
        ///
        [Test]
        public async Task ProcessEventAsyncReceivesAnEmptyPartitionContextForNoData()
        {
            var partitionId = "expectedPartition";
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new Mock<EventProcessorClient>(new MockCheckPointStorage(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new[] { partitionId }));

            mockConsumer
                .Setup(consumer => consumer.ReadEventsFromPartitionAsync(
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<ReadEventOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns<string, EventPosition, ReadEventOptions, CancellationToken>((partition, position, options, token) => MockEmptyPartitionEventEnumerable(5, token));

            mockProcessor
                .Setup(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<EventHubConnection>(),
                    It.IsAny<EventHubConsumerClientOptions>()))
                .Returns(mockConsumer.Object);

            mockProcessor.Object.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            var completionSource = new TaskCompletionSource<bool>();
            var emptyEventArgs = default(ProcessEventArgs);

            mockProcessor.Object.ProcessEventAsync += eventArgs =>
            {
                emptyEventArgs = eventArgs;
                completionSource.SetResult(true);

                return Task.CompletedTask;
            };

            // Start the processor and wait for the event handler to be triggered.

            await mockProcessor.Object.StartProcessingAsync();
            await completionSource.Task;
            await mockProcessor.Object.StopProcessingAsync();

            // Validate the empty event arguments.

            Assert.That(emptyEventArgs, Is.Not.Null, "The event arguments should have been populated.");
            Assert.That(emptyEventArgs.Data, Is.Null, "The event arguments should not have an event available.");
            Assert.That(emptyEventArgs.Partition, Is.Not.Null, "The event arguments should have a partition context.");
            Assert.That(emptyEventArgs.Partition.PartitionId, Is.EqualTo(partitionId), "The partition identifier should match.");
            Assert.That(() => emptyEventArgs.Partition.ReadLastEnqueuedEventProperties(), Throws.InstanceOf<InvalidOperationException>(), "The last event properties should not be available.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> properties.
        /// </summary>
        ///
        [Test]
        [Ignore("Update to match new event behavior.")]
        public async Task HandlerPropertiesCannotBeSetWhenEventProcessorIsRunning()
        {
            var processor = new EventProcessorClient(Mock.Of<PartitionManager>(), "consumerGroup", "namespace", "eventHub", () => new MockConnection(), default);

            processor.ProcessEventAsync += eventArgs => Task.CompletedTask;
            processor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            await processor.StartProcessingAsync();

            Assert.That(() => processor.PartitionInitializingAsync += eventArgs => Task.CompletedTask, Throws.InstanceOf<InvalidOperationException>());
            Assert.That(() => processor.PartitionClosingAsync += eventArgs => Task.CompletedTask, Throws.InstanceOf<InvalidOperationException>());
            Assert.That(() => processor.ProcessEventAsync += eventArgs => Task.CompletedTask, Throws.InstanceOf<InvalidOperationException>());
            Assert.That(() => processor.ProcessErrorAsync += eventArgs => Task.CompletedTask, Throws.InstanceOf<InvalidOperationException>());

            await processor.StopProcessingAsync();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> properties.
        /// </summary>
        ///
        [Test]
        [Ignore("Update to match new event behavior.")]
        public async Task HandlerPropertiesCanBeSetAfterEventProcessorHasStopped()
        {
            var processor = new EventProcessorClient(Mock.Of<PartitionManager>(), "consumerGroup", "namespace", "eventHub", () => new MockConnection(), default);

            processor.ProcessEventAsync += eventArgs => Task.CompletedTask;
            processor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            await processor.StartProcessingAsync();
            await processor.StopProcessingAsync();

            Assert.That(() => processor.PartitionInitializingAsync += eventArgs => Task.CompletedTask, Throws.Nothing);
            Assert.That(() => processor.PartitionClosingAsync += eventArgs => Task.CompletedTask, Throws.Nothing);
            Assert.That(() => processor.ProcessEventAsync += eventArgs => Task.CompletedTask, Throws.Nothing);
            Assert.That(() => processor.ProcessErrorAsync += eventArgs => Task.CompletedTask, Throws.Nothing);
        }

        /// <summary>
        ///   Retrieves the RetryPolicy for the processor client using its private accessor.
        /// </summary>
        ///
        private static EventHubsRetryPolicy GetRetryPolicy(EventProcessorClient client) =>
            (EventHubsRetryPolicy)
                typeof(EventProcessorClient)
                    .GetProperty("RetryPolicy", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(client);

        /// <summary>
        ///   Retrieves the ProcessingConsumerOptions for the processor client using its private accessor.
        /// </summary>
        ///
        private static EventHubConsumerClientOptions GetProcessingConsumerOptions(EventProcessorClient client) =>
            (EventHubConsumerClientOptions)
            typeof(EventProcessorClient)
                .GetProperty("ProcessingConsumerOptions", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(client);

        /// <summary>
        ///   Retrieves the ProcessingReadEventOptions for the processor client using its private accessor.
        /// </summary>
        ///
        private static ReadEventOptions GetProcessingReadEventOptions(EventProcessorClient client) =>
            (ReadEventOptions)
            typeof(EventProcessorClient)
                .GetProperty("ProcessingReadEventOptions", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(client);

        /// <summary>
        ///   Creates a connection using a processor client's ConnectionFactory and returns its ConnectionOptions.
        /// </summary>
        ///
        private static EventHubConnectionOptions GetConnectionOptionsSample(EventProcessorClient client)
        {
            var connectionFactory = (Func<EventHubConnection>)typeof(EventProcessorClient)
                .GetProperty("ConnectionFactory", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(client);

            var connection = connectionFactory();

            return (EventHubConnectionOptions)typeof(EventHubConnection)
                .GetProperty("Options", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(connection);
        }

        /// <summary>
        ///   Creates a mock async enumerable to simulate reading events from a partition.
        /// </summary>
        ///
        private static async IAsyncEnumerable<PartitionEvent> MockPartitionEventEnumerable(int eventCount,
                                                                                           [EnumeratorCancellation]CancellationToken cancellationToken)
        {
            for (var index = 0; index < eventCount; ++index)
            {
                if (cancellationToken.IsCancellationRequested)
                { break; }
                await Task.Delay(25).ConfigureAwait(false);
                yield return new PartitionEvent(new MockPartitionContext("fake"), new EventData(Encoding.UTF8.GetBytes($"Event { index }")));
            }

            yield break;
        }

        /// <summary>
        ///   Creates a mock async enumerable to simulate reading events from a partition.
        /// </summary>
        ///
        private static async IAsyncEnumerable<PartitionEvent> MockEmptyPartitionEventEnumerable(int eventCount,
                                                                                                [EnumeratorCancellation]CancellationToken cancellationToken)
        {
            for (var index = 0; index < eventCount; ++index)
            {
                if (cancellationToken.IsCancellationRequested)
                { break; }
                await Task.Delay(25).ConfigureAwait(false);
                yield return new PartitionEvent();
            }

            yield break;
        }

        /// <summary>
        ///   Serves as a non-functional connection for testing consumer functionality.
        /// </summary>
        ///
        private class MockConnection : EventHubConnection
        {
            public MockConnection(string namespaceName = "fakeNamespace",
                                  string eventHubName = "fakeEventHub") : base(namespaceName, eventHubName, CreateCredentials())
            {
            }

            private static EventHubTokenCredential CreateCredentials()
            {
                return new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net").Object;
            }
        }

        /// <summary>
        ///   Serves a mock context for a partition.
        /// </summary>
        ///
        private class MockPartitionContext : PartitionContext
        {
            public MockPartitionContext(string partitionId) : base(partitionId)
            {
            }
        }
    }
}
