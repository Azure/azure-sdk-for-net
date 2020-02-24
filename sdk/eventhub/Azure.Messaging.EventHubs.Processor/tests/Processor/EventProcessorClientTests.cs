// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Consumer;
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
            Assert.That(readOptions.OwnerLevel, Is.EqualTo(0), "The constructor should have set the owner level as 0.");
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
        ///   Verifies functionality of the <see cref="EventProcessorClient" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorPassesTheRetryPolicyToStorageManager()
        {
            var expected = Mock.Of<EventHubsRetryPolicy>();
            var clientOptions = new EventProcessorClientOptions { RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = expected } };
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var eventProcessor = new EventProcessorClient(Mock.Of<BlobContainerClient>(), EventHubConsumerClient.DefaultConsumerGroupName, connectionString, clientOptions);

            var storageManager = GetStorageManager(eventProcessor);
            var retryPolicy = GetStorageManagerRetryPolicy(storageManager);

            Assert.That(retryPolicy, Is.EqualTo(expected));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void NamespaceConstructorPassesTheRetryPolicyToStorageManager()
        {
            var expected = Mock.Of<EventHubsRetryPolicy>();
            var clientOptions = new EventProcessorClientOptions { RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = expected } };
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net");
            var eventProcessor = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "namespace", "hub", credential.Object, clientOptions);

            var storageManager = GetStorageManager(eventProcessor);
            var retryPolicy = GetStorageManagerRetryPolicy(storageManager);

            Assert.That(retryPolicy, Is.EqualTo(expected));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.StartProcessingAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void StartProcessingAsyncValidatesProcessEventsAsync()
        {
            var processor = new EventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", () => new MockConnection(), default);
            processor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            Assert.That(async () => await processor.StartProcessingAsync(), Throws.InstanceOf<InvalidOperationException>().And.Message.Contains(nameof(EventProcessorClient.ProcessEventAsync)));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.StartProcessingAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void StartProcessingAsyncValidatesProcessExceptionAsync()
        {
            var processor = new EventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", () => new MockConnection(), default);
            processor.ProcessEventAsync += eventArgs => Task.CompletedTask;

            Assert.That(async () => await processor.StartProcessingAsync(), Throws.InstanceOf<InvalidOperationException>().And.Message.Contains(nameof(EventProcessorClient.ProcessErrorAsync)));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.StartProcessingAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task StartProcessingAsyncStartsTheEventProcessorWhenProcessingHandlerPropertiesAreSet()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, default) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Array.Empty<string>()));

            mockProcessor
                .Setup(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<EventHubConnection>(),
                    It.IsAny<EventHubConsumerClientOptions>()))
                .Returns(mockConsumer.Object);

            mockProcessor.Object.ProcessEventAsync += eventArgs => Task.CompletedTask;
            mockProcessor.Object.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            using var cancellationSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            Assert.That(async () => await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token), Throws.Nothing);

            await mockProcessor.Object.StopProcessingAsync();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.StartProcessingAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task StartProcessingAsyncDoesNothingWhenProcessorIsAlreadyRunning()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, default) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Array.Empty<string>()));

            // CreateConsumer is called as soon as the background processor running task starts. After the first call,
            // we'll try calling StartProcessingAsync again and make sure no other task has started by monitoring
            // CreateConsumer calls.

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<EventHubConnection>(),
                    It.IsAny<EventHubConsumerClientOptions>()))
                .Callback(() =>
                {
                    completionSource.SetResult(true);
                })
                .Returns(mockConsumer.Object);

            mockProcessor.Object.ProcessEventAsync += eventArgs => Task.CompletedTask;
            mockProcessor.Object.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            // To ensure that the test does not hang for the duration, set a timeout to force completion
            // after a shorter period of time.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);

            while (!completionSource.Task.IsCompleted
                && !cancellationSource.IsCancellationRequested)
            {
                await Task.Delay(25);
            }

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");

            mockProcessor
                .Verify(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<EventHubConnection>(),
                    It.IsAny<EventHubConsumerClientOptions>()), Times.Once(), "Only one background running task should have been spawned.");
        }

        /// <summary>
        ///   Verifies that an <see cref="EventProcessorClient" /> invokes partition load balancing
        ///   after <see cref="EventProcessorClient.StartProcessingAsync" /> is called.
        /// </summary>
        ///
        [Test]
        public async Task StartProcessingAsyncStartsLoadbalancer()
        {
            const int NumberOfPartitions = 3;
            var mockLoadbalancer = new Mock<PartitionLoadBalancer>();
            mockLoadbalancer.SetupAllProperties();
            mockLoadbalancer.Object.LoadBalanceInterval = TimeSpan.FromSeconds(1);
            Func<EventHubConnection> connectionFactory = () => new MockConnection();
            var connection = connectionFactory();
            var storageManager = new MockCheckPointStorage((s) => Console.WriteLine(s));
            var processor = new MockEventProcessorClient(
                storageManager,
                connectionFactory: connectionFactory,
                loadBalancer: mockLoadbalancer.Object);

            await processor.StartProcessingAsync();

            // Starting the processor should call the PartitionLoadBalancer.

            mockLoadbalancer.Verify(m => m.RunLoadBalancingAsync(It.Is<string[]>(p => p.Length == NumberOfPartitions), It.IsAny<CancellationToken>()));

            await processor.StopProcessingAsync(CancellationToken.None);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.StartProcessingAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void AlreadyCancelledTokenMakesStartProcessingAsyncThrow()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, default) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Array.Empty<string>()));

            mockProcessor
                .Setup(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<EventHubConnection>(),
                    It.IsAny<EventHubConsumerClientOptions>()))
                .Returns(mockConsumer.Object);

            mockProcessor.Object.ProcessEventAsync += eventArgs => Task.CompletedTask;
            mockProcessor.Object.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(async () => await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.StartProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void AlreadyCancelledTokenMakesStartProcessingThrow()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, default) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Array.Empty<string>()));

            mockProcessor
                .Setup(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<EventHubConnection>(),
                    It.IsAny<EventHubConsumerClientOptions>()))
                .Returns(mockConsumer.Object);

            mockProcessor.Object.ProcessEventAsync += eventArgs => Task.CompletedTask;
            mockProcessor.Object.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => mockProcessor.Object.StartProcessing(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.StopProcessingAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task StopProcessingAsyncResetsFailedState()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, default) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Array.Empty<string>()));

            // Force an exception to be thrown as soon as the background running task starts.

            var firstRun = true;
            var expectedException = new Exception();

            mockProcessor
                .Setup(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<EventHubConnection>(),
                    It.IsAny<EventHubConsumerClientOptions>()))
                .Returns(() =>
                {
                    if (firstRun)
                    {
                        firstRun = false;
                        throw expectedException;
                    }

                    return mockConsumer.Object;
                });

            mockProcessor.Object.ProcessEventAsync += eventArgs => Task.CompletedTask;
            mockProcessor.Object.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            // To ensure that the test does not hang for the duration, set a timeout to force completion
            // after a shorter period of time.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);

            Assert.That(mockProcessor.Object.IsRunning, Is.False, "The failed processor should not be running anymore.");

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);

            Assert.That(mockProcessor.Object.IsRunning, Is.False, "StartProcessingAsync should not be able to reset processor state.");

            var capturedException = default(Exception);

            try
            {
                await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);
            }
            catch (Exception ex)
            {
                capturedException = ex;
            }

            Assert.That(capturedException, Is.EqualTo(expectedException), "The captured and expected exceptions do not match.");

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);

            Assert.That(mockProcessor.Object.IsRunning, Is.True, "The processor state should have been reset by StopProcessingAsync.");

            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.StopProcessingAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task StopProcessingAsyncDoesNothingWhenProcessorIsNotRunning()
        {
            var mockStorage = new Mock<MockCheckPointStorage>(default(Action<string>)) { CallBase = true };
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new InjectableEventSourceProcessorMock(mockStorage.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, mockConsumer.Object);

            // Ownership claim attempts with an empty owner identifier are actually relinquish requests. This should happen once
            // when the processor is stopping. We don't really care whether the relinquish attempt has succeeded or not, so just
            // return a null.

            var relinquishAttempts = 0;

            mockStorage
                .Setup(storage => storage.ClaimOwnershipAsync(
                    It.Is<IEnumerable<PartitionOwnership>>(ownershipEnumerable =>
                        ownershipEnumerable.Any(ownership => string.IsNullOrEmpty(ownership.OwnerIdentifier))),
                    It.IsAny<CancellationToken>()))
                .Callback<IEnumerable<PartitionOwnership>, CancellationToken>((ownershipEnumerable, token) =>
                {
                    Interlocked.Increment(ref relinquishAttempts);
                })
                .Returns(Task.FromResult(default(IEnumerable<PartitionOwnership>)));

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new[] { "0" }));

            mockConsumer
                .Setup(consumer => consumer.ReadEventsFromPartitionAsync(
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<ReadEventOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns<string, EventPosition, ReadEventOptions, CancellationToken>((partition, position, options, token) =>
                    MockEmptyPartitionEventEnumerable(1, token));

            var closingHandlerCalls = 0;

            mockProcessor.PartitionClosingAsync += eventArgs =>
            {
                Interlocked.Increment(ref closingHandlerCalls);
                return Task.CompletedTask;
            };

            // Wait until processing has started before stopping the processor. This way we can ensure the closing
            // handler will be triggered.

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            mockProcessor.ProcessEventAsync += eventArgs =>
            {
                completionSource.SetResult(true);
                return Task.CompletedTask;
            };

            mockProcessor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            // To ensure that the test does not hang for the duration, set a timeout to force completion
            // after a shorter period of time.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            await mockProcessor.StartProcessingAsync(cancellationSource.Token);

            while (!completionSource.Task.IsCompleted
                && !cancellationSource.IsCancellationRequested)
            {
                await Task.Delay(25);
            }

            await mockProcessor.StopProcessingAsync(cancellationSource.Token);
            await mockProcessor.StopProcessingAsync(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");
            Assert.That(closingHandlerCalls, Is.EqualTo(1), "The closing handler should not have been called again.");
            Assert.That(relinquishAttempts, Is.EqualTo(1), "No more relinquish attempts should have been made after the first one.");
        }

        /// <summary>
        ///   Verifies that partitions owned by an <see cref="EventProcessorClient" /> are immediately available to be claimed by another processor
        ///   after <see cref="EventProcessorClient.StopProcessingAsync" /> is called.
        /// </summary>
        ///
        [Test]
        public async Task StopProcessingAsyncStopsLoadbalancer()
        {
            var mockLoadbalancer = new Mock<PartitionLoadBalancer>();
            mockLoadbalancer.SetupAllProperties();
            mockLoadbalancer.Object.LoadBalanceInterval = TimeSpan.FromSeconds(1);
            Func<EventHubConnection> connectionFactory = () => new MockConnection();
            var connection = connectionFactory();
            var storageManager = new MockCheckPointStorage((s) => Console.WriteLine(s));
            var processor = new MockEventProcessorClient(
                storageManager,
                connectionFactory: connectionFactory,
                loadBalancer: mockLoadbalancer.Object);

            await processor.StartProcessingAsync();
            await processor.StopProcessingAsync();

            // Stopping the processor should stop the PartitionLoadBalancer.

            mockLoadbalancer.Verify(m => m.RelinquishOwnershipAsync(It.IsAny<CancellationToken>()));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.StopProcessingAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [Ignore("Test failing during nightly runs. (Tracked by: #10067)")]
        public async Task StopProcessingAsyncStopsProcessingForEveryPartition()
        {
            var maximumWaitTimeInMilli = 100;
            var processorOptions = new EventProcessorClientOptions { MaximumWaitTime = TimeSpan.FromMilliseconds(maximumWaitTimeInMilli) };
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new InjectableEventSourceProcessorMock(new MockCheckPointStorage(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), processorOptions, mockConsumer.Object);

            var partitionIds = new[] { "0", "1" };

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(partitionIds));

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var partitionsBeingProcessed = 0;

            // Use the ReadEventsFromPartitionAsync method to notify when all partitions have started being processed.

            mockConsumer
                .Setup(consumer => consumer.ReadEventsFromPartitionAsync(
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<ReadEventOptions>(),
                    It.IsAny<CancellationToken>()))
                .Callback(() =>
                {
                    if (Interlocked.Increment(ref partitionsBeingProcessed) >= partitionIds.Length)
                    {
                        completionSource.TrySetResult(true);
                    }
                })
                .Returns<string, EventPosition, ReadEventOptions, CancellationToken>((partition, position, options, token) =>
                    MockEndlessPartitionEventEnumerable(options.MaximumWaitTime, token));

            var hasReceivedEventsWhileNotRunning = false;

            // Use the process event handler to track events received after the processor has stopped.

            mockProcessor.ProcessEventAsync += eventArgs =>
            {
                if (!mockProcessor.IsRunning)
                {
                    hasReceivedEventsWhileNotRunning = true;
                }

                return Task.CompletedTask;
            };

            mockProcessor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            // Establish timed cancellation to ensure that the test doesn't hang.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            await mockProcessor.StartProcessingAsync(cancellationSource.Token);

            while (!completionSource.Task.IsCompleted
                && !cancellationSource.IsCancellationRequested)
            {
                await Task.Delay(25);
            }

            await mockProcessor.StopProcessingAsync(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");

            // Wait a bit to give the stopped processor the chance to trigger the event handler. This scenario is not expected.

            await Task.Delay(5 * maximumWaitTimeInMilli);

            Assert.That(hasReceivedEventsWhileNotRunning, Is.False, "The processor should not have received events while not running.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.StopProcessingAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task StopProcessingAsyncShouldSurfaceBackgroundRunningTaskException()
        {
            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, default) { CallBase = true };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            mockProcessor
                .Setup(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<EventHubConnection>(),
                    It.IsAny<EventHubConsumerClientOptions>()))
                .Callback(() => completionSource.SetResult(true))
                .Throws(new Exception());

            mockProcessor.Object.ProcessEventAsync += eventArgs => Task.CompletedTask;
            mockProcessor.Object.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            // To ensure that the test does not hang for the duration, set a timeout to force completion
            // after a shorter period of time.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            await Task.WhenAny(Task.Delay(-1, cancellationSource.Token), completionSource.Task);

            Assert.That(async () => await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token), Throws.Exception, "An exception should have been thrown when creating the consumer.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.StopProcessingAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task AlreadyCancelledTokenMakesStopProcessingAsyncThrow()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, default) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Array.Empty<string>()));

            mockProcessor
                .Setup(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<EventHubConnection>(),
                    It.IsAny<EventHubConsumerClientOptions>()))
                .Returns(mockConsumer.Object);

            mockProcessor.Object.ProcessEventAsync += eventArgs => Task.CompletedTask;
            mockProcessor.Object.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            await mockProcessor.Object.StartProcessingAsync();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(async () => await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.StopProcessing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void AlreadyCancelledTokenMakesStopProcessingThrow()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, default) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Array.Empty<string>()));

            mockProcessor
                .Setup(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<EventHubConnection>(),
                    It.IsAny<EventHubConsumerClientOptions>()))
                .Returns(mockConsumer.Object);

            mockProcessor.Object.ProcessEventAsync += eventArgs => Task.CompletedTask;
            mockProcessor.Object.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            mockProcessor.Object.StartProcessing();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => mockProcessor.Object.StopProcessing(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.StartProcessingAsync" />
        ///   and <see cref="EventProcessorClient.StopProcessingAsync" /> methods.
        /// </summary>
        ///
        [Test]
        public async Task SupportsStartProcessingAfterStop()
        {
            var partitionId = "expectedPartition";
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new InjectableEventSourceProcessorMock(new MockCheckPointStorage(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, mockConsumer.Object);

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new[] { partitionId }));

            mockConsumer
                .Setup(consumer => consumer.ReadEventsFromPartitionAsync(
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<ReadEventOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns<string, EventPosition, ReadEventOptions, CancellationToken>((partition, position, options, token) => MockEmptyPartitionEventEnumerable(1, token));

            mockProcessor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var isProcessEventHandlerInvoked = false;

            mockProcessor.ProcessEventAsync += eventArgs =>
            {
                isProcessEventHandlerInvoked = true;
                completionSource.SetResult(true);

                return Task.CompletedTask;
            };

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            Assert.That(mockProcessor.IsRunning, Is.False);

            await mockProcessor.StartProcessingAsync(cancellationSource.Token);
            await completionSource.Task;

            Assert.That(mockProcessor.IsRunning, Is.True);
            Assert.That(isProcessEventHandlerInvoked, Is.EqualTo(true));

            await mockProcessor.StopProcessingAsync(cancellationSource.Token);

            isProcessEventHandlerInvoked = false;
            completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");
            Assert.That(mockProcessor.IsRunning, Is.False);

            await mockProcessor.StartProcessingAsync(cancellationSource.Token);
            await completionSource.Task;

            Assert.That(mockProcessor.IsRunning, Is.True);
            Assert.That(isProcessEventHandlerInvoked, Is.EqualTo(true));

            await mockProcessor.StopProcessingAsync(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");
            Assert.That(mockProcessor.IsRunning, Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.StartProcessing" />
        ///   and <see cref="EventProcessorClient.StopProcessing" /> methods.
        /// </summary>
        ///
        [Test]
        public void StartAndStopProcessingShouldStartAndStopProcessors()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, default) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Array.Empty<string>()));

            mockProcessor
                .Setup(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<EventHubConnection>(),
                    It.IsAny<EventHubConsumerClientOptions>()))
                .Returns(mockConsumer.Object);

            mockProcessor.Object.ProcessEventAsync += eventArgs => Task.CompletedTask;
            mockProcessor.Object.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            Assert.That(mockProcessor.Object.IsRunning, Is.False);

            mockProcessor.Object.StartProcessing(cancellationSource.Token);

            Assert.That(mockProcessor.Object.IsRunning, Is.True);

            mockProcessor.Object.StopProcessing(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");
            Assert.That(mockProcessor.Object.IsRunning, Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> events.
        /// </summary>
        ///
        [Test]
        public void CannotAddNullHandler()
        {
            var processor = new EventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", () => new MockConnection(), default);

            Assert.That(() => processor.PartitionInitializingAsync += null, Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => processor.PartitionClosingAsync += null, Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => processor.ProcessEventAsync += null, Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => processor.ProcessErrorAsync += null, Throws.InstanceOf<ArgumentNullException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> events.
        /// </summary>
        ///
        [Test]
        public void CannotAddTwoHandlersToTheSameEvent()
        {
            var processor = new EventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", () => new MockConnection(), default);

            processor.PartitionInitializingAsync += eventArgs => Task.CompletedTask;
            processor.PartitionClosingAsync += eventArgs => Task.CompletedTask;
            processor.ProcessEventAsync += eventArgs => Task.CompletedTask;
            processor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            Assert.That(() => processor.PartitionInitializingAsync += eventArgs => Task.CompletedTask, Throws.InstanceOf<NotSupportedException>());
            Assert.That(() => processor.PartitionClosingAsync += eventArgs => Task.CompletedTask, Throws.InstanceOf<NotSupportedException>());
            Assert.That(() => processor.ProcessEventAsync += eventArgs => Task.CompletedTask, Throws.InstanceOf<NotSupportedException>());
            Assert.That(() => processor.ProcessErrorAsync += eventArgs => Task.CompletedTask, Throws.InstanceOf<NotSupportedException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> events.
        /// </summary>
        ///
        [Test]
        public void CannotRemoveHandlerThatHasNotBeenAdded()
        {
            var processor = new EventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", () => new MockConnection(), default);

            // First scenario: no handler has been set.

            Assert.That(() => processor.PartitionInitializingAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>());
            Assert.That(() => processor.PartitionClosingAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>());
            Assert.That(() => processor.ProcessEventAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>());
            Assert.That(() => processor.ProcessErrorAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>());

            // Second scenario: there is a handler set, but it's not the one we are trying to remove.

            processor.PartitionInitializingAsync += eventArgs => Task.CompletedTask;
            processor.PartitionClosingAsync += eventArgs => Task.CompletedTask;
            processor.ProcessEventAsync += eventArgs => Task.CompletedTask;
            processor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            Assert.That(() => processor.PartitionInitializingAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>());
            Assert.That(() => processor.PartitionClosingAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>());
            Assert.That(() => processor.ProcessEventAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>());
            Assert.That(() => processor.ProcessErrorAsync -= eventArgs => Task.CompletedTask, Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> events.
        /// </summary>
        ///
        [Test]
        public void CanRemoveHandlerThatHasBeenAdded()
        {
            var processor = new EventProcessorClient(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", () => new MockConnection(), default);

            Func<PartitionInitializingEventArgs, Task> initHandler = eventArgs => Task.CompletedTask;
            Func<PartitionClosingEventArgs, Task> closeHandler = eventArgs => Task.CompletedTask;
            Func<ProcessEventArgs, Task> eventHandler = eventArgs => Task.CompletedTask;
            Func<ProcessErrorEventArgs, Task> errorHandler = eventArgs => Task.CompletedTask;

            processor.PartitionInitializingAsync += initHandler;
            processor.PartitionClosingAsync += closeHandler;
            processor.ProcessEventAsync += eventHandler;
            processor.ProcessErrorAsync += errorHandler;

            Assert.That(() => processor.PartitionInitializingAsync -= initHandler, Throws.Nothing);
            Assert.That(() => processor.PartitionClosingAsync -= closeHandler, Throws.Nothing);
            Assert.That(() => processor.ProcessEventAsync -= eventHandler, Throws.Nothing);
            Assert.That(() => processor.ProcessErrorAsync -= errorHandler, Throws.Nothing);

            // Assert that handlers can be added again.

            Assert.That(() => processor.PartitionInitializingAsync += initHandler, Throws.Nothing);
            Assert.That(() => processor.PartitionClosingAsync += closeHandler, Throws.Nothing);
            Assert.That(() => processor.ProcessEventAsync += eventHandler, Throws.Nothing);
            Assert.That(() => processor.ProcessErrorAsync += errorHandler, Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> events.
        /// </summary>
        ///
        [Test]
        public async Task CannotAddHandlerWhileProcessorIsRunning()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, default) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Array.Empty<string>()));

            mockProcessor
                .Setup(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<EventHubConnection>(),
                    It.IsAny<EventHubConsumerClientOptions>()))
                .Returns(mockConsumer.Object);

            mockProcessor.Object.ProcessEventAsync += eventArgs => Task.CompletedTask;
            mockProcessor.Object.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);

            Assert.That(() => mockProcessor.Object.PartitionInitializingAsync += eventArgs => Task.CompletedTask, Throws.InstanceOf<InvalidOperationException>());
            Assert.That(() => mockProcessor.Object.PartitionClosingAsync += eventArgs => Task.CompletedTask, Throws.InstanceOf<InvalidOperationException>());

            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);

            // Once stopped, the processor should allow handlers to be added again.

            Assert.That(() => mockProcessor.Object.PartitionInitializingAsync += eventArgs => Task.CompletedTask, Throws.Nothing);
            Assert.That(() => mockProcessor.Object.PartitionClosingAsync += eventArgs => Task.CompletedTask, Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> events.
        /// </summary>
        ///
        [Test]
        public async Task CannotRemoveHandlerWhileProcessorIsRunning()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, default) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Array.Empty<string>()));

            mockProcessor
                .Setup(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<EventHubConnection>(),
                    It.IsAny<EventHubConsumerClientOptions>()))
                .Returns(mockConsumer.Object);


            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            Func<PartitionInitializingEventArgs, Task> initHandler = eventArgs => Task.CompletedTask;
            Func<PartitionClosingEventArgs, Task> closeHandler = eventArgs => Task.CompletedTask;
            Func<ProcessEventArgs, Task> eventHandler = eventArgs => Task.CompletedTask;
            Func<ProcessErrorEventArgs, Task> errorHandler = eventArgs => Task.CompletedTask;

            mockProcessor.Object.PartitionInitializingAsync += initHandler;
            mockProcessor.Object.PartitionClosingAsync += closeHandler;
            mockProcessor.Object.ProcessEventAsync += eventHandler;
            mockProcessor.Object.ProcessErrorAsync += errorHandler;

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);

            Assert.That(() => mockProcessor.Object.PartitionInitializingAsync -= initHandler, Throws.InstanceOf<InvalidOperationException>());
            Assert.That(() => mockProcessor.Object.PartitionClosingAsync -= closeHandler, Throws.InstanceOf<InvalidOperationException>());
            Assert.That(() => mockProcessor.Object.ProcessEventAsync -= eventHandler, Throws.InstanceOf<InvalidOperationException>());
            Assert.That(() => mockProcessor.Object.ProcessErrorAsync -= errorHandler, Throws.InstanceOf<InvalidOperationException>());

            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);

            // Once stopped, the processor should allow handlers to be removed again.

            Assert.That(() => mockProcessor.Object.PartitionInitializingAsync -= initHandler, Throws.Nothing);
            Assert.That(() => mockProcessor.Object.PartitionClosingAsync -= closeHandler, Throws.Nothing);
            Assert.That(() => mockProcessor.Object.ProcessEventAsync -= eventHandler, Throws.Nothing);
            Assert.That(() => mockProcessor.Object.ProcessErrorAsync -= errorHandler, Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.IsRunning" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public async Task IsRunningReturnsTrueWhileStopProcessingAsyncIsNotCalled()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, default) { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(Array.Empty<string>()));

            mockProcessor
                .Setup(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<EventHubConnection>(),
                    It.IsAny<EventHubConsumerClientOptions>()))
                .Returns(mockConsumer.Object);

            mockProcessor.Object.ProcessEventAsync += eventArgs => Task.CompletedTask;
            mockProcessor.Object.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            Assert.That(mockProcessor.Object.IsRunning, Is.False);

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);

            Assert.That(mockProcessor.Object.IsRunning, Is.True);

            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);

            Assert.That(mockProcessor.Object.IsRunning, Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.IsRunning" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public async Task IsRunningReturnsFalseWhenLoadBalancingTaskFails()
        {
            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, default) { CallBase = true };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            // This should be called right before the first load balancing cycle.

            mockProcessor
                .Setup(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<EventHubConnection>(),
                    It.IsAny<EventHubConsumerClientOptions>()))
                .Callback(() => completionSource.SetResult(true))
                .Throws(new Exception());

            mockProcessor.Object.ProcessEventAsync += eventArgs => Task.CompletedTask;
            mockProcessor.Object.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            // To ensure that the test does not hang for the duration, set a timeout to force completion
            // after a shorter period of time.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            await mockProcessor.Object.StartProcessingAsync();
            await Task.WhenAny(Task.Delay(-1, cancellationSource.Token), completionSource.Task);

            // Capture the value of IsRunning before stopping the processor.  We are doing this to make sure
            // we stop the processor properly even in case of failure.

            var isRunning = mockProcessor.Object.IsRunning;

            // Stop the processor and ensure that it does not block on the handler.

            Assert.That(async () => await mockProcessor.Object.StopProcessingAsync(), Throws.Exception, "An exception should have been thrown when creating the consumer.");
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");

            Assert.That(isRunning, Is.False, "IsRunning should return false when the load balancing task fails.");
        }

        /// <summary>
        ///   Verify logs for the <see cref="EventProcessorClient" />.
        /// </summary>
        ///
        [Test]
        public async Task VerifiesEventProcessorLogs()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            string[] partitionIds = { "0" };

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(partitionIds));

            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, default);

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

            using var cancellationSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));

            Assert.That(async () => await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token), Throws.Nothing);
            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);

            mockLog.Verify(m => m.EventProcessorStart(mockProcessor.Object.Identifier));
            mockLog.Verify(m => m.EventProcessorStopStart(mockProcessor.Object.Identifier));
            mockLog.Verify(m => m.EventProcessorStopComplete(mockProcessor.Object.Identifier));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.PartitionInitializingAsync" />
        ///   event.
        /// </summary>
        ///
        [Test]
        public async Task PartitionInitializingAsyncIsTriggeredWhenPartitionProcessingIsStarting()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new InjectableEventSourceProcessorMock(new MockCheckPointStorage(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, mockConsumer.Object);

            var partitionIds = new[] { "0", "1" };

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(partitionIds));

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var partitionsBeingProcessed = 0;

            // Use the ReadEventsFromPartitionAsync method to notify when all partitions have started being processed.

            mockConsumer
                .Setup(consumer => consumer.ReadEventsFromPartitionAsync(
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<ReadEventOptions>(),
                    It.IsAny<CancellationToken>()))
                .Callback(() =>
                {
                    if (Interlocked.Increment(ref partitionsBeingProcessed) == partitionIds.Length)
                    {
                        completionSource.SetResult(true);
                    }
                })
                .Returns<string, EventPosition, ReadEventOptions, CancellationToken>((partition, position, options, token) =>
                    MockEndlessPartitionEventEnumerable(options.MaximumWaitTime, token));

            // Use the init handler to keep track of the partitions that have been initialized.

            var initializingEventArgs = new ConcurrentBag<PartitionInitializingEventArgs>();

            mockProcessor.PartitionInitializingAsync += eventArgs =>
            {
                initializingEventArgs.Add(eventArgs);
                return Task.CompletedTask;
            };

            mockProcessor.ProcessEventAsync += eventArgs => Task.CompletedTask;

            mockProcessor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            // Establish timed cancellation to ensure that the test doesn't hang.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            await mockProcessor.StartProcessingAsync(cancellationSource.Token);

            while (!completionSource.Task.IsCompleted
                && !cancellationSource.IsCancellationRequested)
            {
                await Task.Delay(25);
            }

            await mockProcessor.StopProcessingAsync(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");

            var initializingEventArgsList = initializingEventArgs.ToList();

            Assert.That(initializingEventArgsList.Count, Is.EqualTo(partitionIds.Length), $"The initializing handler should have been called { partitionIds.Length } times.");

            foreach (var partitionId in partitionIds)
            {
                Assert.That(initializingEventArgsList.Any(args => args.PartitionId == partitionId), Is.True, $"The initializing handler should have been triggered with partitionId = '{ partitionId }'.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.PartitionInitializingAsync" />
        ///   event.
        /// </summary>
        ///
        [Test]
        public async Task PartitionInitializingAsyncIsCalledWhenPartitionProcessingTaskFails()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new InjectableEventSourceProcessorMock(new MockCheckPointStorage(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, mockConsumer.Object);

            var partitionId = "0";

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new[] { partitionId }));

            // We will force an exception when running a partition processing task.

            mockProcessor.RunPartitionProcessingException = new Exception();

            // Keep track of how many times we call the init handler. If we call it for a second time,
            // it means a new processing task has started.

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var initHandlerCalls = 0;
            var capturedPartitionId = default(string);

            mockProcessor.PartitionInitializingAsync += eventArgs =>
            {
                if (Interlocked.Increment(ref initHandlerCalls) == 2)
                {
                    capturedPartitionId = eventArgs.PartitionId;
                    completionSource.SetResult(true);
                }

                return Task.CompletedTask;
            };

            mockProcessor.ProcessEventAsync += eventArgs => Task.CompletedTask;

            mockProcessor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            // Establish timed cancellation to ensure that the test doesn't hang.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            await mockProcessor.StartProcessingAsync(cancellationSource.Token);

            while (!completionSource.Task.IsCompleted
                && !cancellationSource.IsCancellationRequested)
            {
                await Task.Delay(25);
            }

            await mockProcessor.StopProcessingAsync(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");
            Assert.That(capturedPartitionId, Is.EqualTo(partitionId), "The associated partition id does not match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.PartitionInitializingAsync" />
        ///   event.
        /// </summary>
        ///
        [Test]
        [Ignore("Test failing during nightly runs. (Tracked by: #10067)")]
        public async Task PartitionInitializingAsyncTokenIsCanceledWhenStopProcessingAsyncIsCalled()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new InjectableEventSourceProcessorMock(new MockCheckPointStorage(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, mockConsumer.Object);

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new[] { "0" }));

            // We'll wait until the init handler is called and capture its token.

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var capturedToken = default(CancellationToken);

            mockProcessor.PartitionInitializingAsync += eventArgs =>
            {
                capturedToken = eventArgs.CancellationToken;
                completionSource.SetResult(true);

                return Task.CompletedTask;
            };

            mockProcessor.ProcessEventAsync += eventArgs => Task.CompletedTask;

            mockProcessor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            // Establish timed cancellation to ensure that the test doesn't hang.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            await mockProcessor.StartProcessingAsync(cancellationSource.Token);

            while (!completionSource.Task.IsCompleted
                && !cancellationSource.IsCancellationRequested)
            {
                await Task.Delay(25);
            }

            Assert.That(capturedToken.IsCancellationRequested, Is.False, "The token in the handler should not have been canceled yet.");

            await mockProcessor.StopProcessingAsync(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");
            Assert.That(capturedToken.IsCancellationRequested, Is.True, "The token in the handler should have been canceled.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.PartitionClosingAsync" />
        ///   event.
        /// </summary>
        ///
        [Test]
        [Ignore("Test failing during nightly runs. (Tracked by: #10067)")]
        public async Task PartitionClosingAsyncIsCalledWithShutdownReasonWhenStoppingTheProcessor()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new InjectableEventSourceProcessorMock(new MockCheckPointStorage(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, mockConsumer.Object);

            var partitionIds = new[] { "0", "1" };

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(partitionIds));

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var partitionsBeingProcessed = 0;

            // Use the ReadEventsFromPartitionAsync method to notify when all partitions have started being processed.

            mockConsumer
                .Setup(consumer => consumer.ReadEventsFromPartitionAsync(
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<ReadEventOptions>(),
                    It.IsAny<CancellationToken>()))
                .Callback(() =>
                {
                    if (Interlocked.Increment(ref partitionsBeingProcessed) == partitionIds.Length)
                    {
                        completionSource.SetResult(true);
                    }
                })
                .Returns<string, EventPosition, ReadEventOptions, CancellationToken>((partition, position, options, token) =>
                    MockEndlessPartitionEventEnumerable(options.MaximumWaitTime, token));

            // Use the close handler to keep track of the partitions that have been closed.

            var closingEventArgs = new ConcurrentBag<PartitionClosingEventArgs>();

            mockProcessor.PartitionClosingAsync += eventArgs =>
            {
                closingEventArgs.Add(eventArgs);
                return Task.CompletedTask;
            };

            mockProcessor.ProcessEventAsync += eventArgs => Task.CompletedTask;

            mockProcessor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            // Establish timed cancellation to ensure that the test doesn't hang.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            await mockProcessor.StartProcessingAsync(cancellationSource.Token);

            while (!completionSource.Task.IsCompleted
                && !cancellationSource.IsCancellationRequested)
            {
                await Task.Delay(25);
            }

            await mockProcessor.StopProcessingAsync(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");

            var closingEventArgsList = closingEventArgs.ToList();

            Assert.That(closingEventArgsList.Count, Is.EqualTo(partitionIds.Length), $"The closing handler should have been called { partitionIds.Length } times.");

            foreach (var partitionId in partitionIds)
            {
                Assert.That(closingEventArgsList.Any(args => args.PartitionId == partitionId), Is.True, $"The closing handler should have been triggered with partitionId = '{ partitionId }'.");
            }

            foreach (var eventArgs in closingEventArgsList)
            {
                Assert.That(eventArgs.Reason, Is.EqualTo(ProcessingStoppedReason.Shutdown), $"The partition '{ eventArgs.PartitionId }' should have stopped processing with the correct reason.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.PartitionClosingAsync" />
        ///   event.
        /// </summary>
        ///
        [Test]
        [Ignore("Flaky test. (Tracked by: #10015)")]
        public async Task PartitionClosingAsyncIsCalledWithOwnershipLostReasonWhenStoppingTheFailedProcessor()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new InjectableEventSourceProcessorMock(new MockCheckPointStorage(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, mockConsumer.Object);

            var partitionIds = new[] { "0", "1" };
            var faultedPartitionId = partitionIds.Last();

            mockProcessor.ShouldIgnoreTestRunnerException = (partitionId, position, token) => partitionId != faultedPartitionId;

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(partitionIds));

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var partitionsBeingProcessed = 0;

            // Use the ReadEventsFromPartitionAsync method to notify when all partitions have started being processed. If the partition is faulted,
            // throw.

            mockConsumer
                .Setup(consumer => consumer.ReadEventsFromPartitionAsync(
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<ReadEventOptions>(),
                    It.IsAny<CancellationToken>()))
                .Callback(() =>
                {
                    if (Interlocked.Increment(ref partitionsBeingProcessed) == partitionIds.Length)
                    {
                        completionSource.SetResult(true);
                    }
                })
                .Returns<string, EventPosition, ReadEventOptions, CancellationToken>((partition, position, options, token) =>
                {
                    if (partition == faultedPartitionId)
                    {
                        throw new Exception();
                    }

                    return MockEndlessPartitionEventEnumerable(options.MaximumWaitTime, token);
                });

            // Use the close handler to keep track of the partitions that have been closed.

            var closingEventArgs = new ConcurrentDictionary<string, PartitionClosingEventArgs>();

            mockProcessor.PartitionClosingAsync += eventArgs =>
            {
                closingEventArgs[eventArgs.PartitionId] = eventArgs;
                return Task.CompletedTask;
            };

            mockProcessor.ProcessEventAsync += eventArgs => Task.CompletedTask;

            mockProcessor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            // Establish timed cancellation to ensure that the test doesn't hang.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            await mockProcessor.StartProcessingAsync(cancellationSource.Token);
            await completionSource.Task;
            await mockProcessor.StopProcessingAsync(cancellationSource.Token);

            // Wait until we have data for every partition. Give up after token cancellation so the test
            // doesn't hang.

            while (closingEventArgs.Count < partitionIds.Length
                && !cancellationSource.IsCancellationRequested)
            {
                await Task.Delay(25);
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");

            foreach (var partitionId in partitionIds)
            {
                var eventArgs = default(PartitionClosingEventArgs);
                var expectedReason = (partitionId == faultedPartitionId) ? ProcessingStoppedReason.OwnershipLost : ProcessingStoppedReason.Shutdown;

                Assert.That(closingEventArgs.TryGetValue(partitionId, out eventArgs), Is.True, $"The partition '{ partitionId }' should have triggered the closing handler.");
                Assert.That(eventArgs.Reason, Is.EqualTo(expectedReason), $"Stop reason in '{ partitionId }' is incorrect.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.PartitionClosingAsync" />
        ///   event.
        /// </summary>
        ///
        [Test]
        public async Task PartitionClosingAsyncIsCalledWhenPartitionProcessingTaskFails()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new InjectableEventSourceProcessorMock(new MockCheckPointStorage(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, mockConsumer.Object);

            var partitionId = "0";

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new[] { partitionId }));

            // We will force an exception when running a partition processing task.

            mockProcessor.RunPartitionProcessingException = new Exception();

            // We'll wait until the closing handler is called. If it's called before we stop
            // the processor, it means the failed task has stopped as expected.

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var capturedEventArgs = default(PartitionClosingEventArgs);

            mockProcessor.PartitionClosingAsync += eventArgs =>
            {
                if (completionSource.TrySetResult(true))
                {
                    capturedEventArgs = eventArgs;
                }

                return Task.CompletedTask;
            };

            mockProcessor.ProcessEventAsync += eventArgs => Task.CompletedTask;

            mockProcessor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            // Establish timed cancellation to ensure that the test doesn't hang.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            await mockProcessor.StartProcessingAsync(cancellationSource.Token);

            while (!completionSource.Task.IsCompleted
                && !cancellationSource.IsCancellationRequested)
            {
                await Task.Delay(25);
            }

            await mockProcessor.StopProcessingAsync(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");
            Assert.That(capturedEventArgs, Is.Not.Null, "The error event args should have been captured.");
            Assert.That(capturedEventArgs.PartitionId, Is.EqualTo(partitionId), "The associated partition id does not match.");
            Assert.That(capturedEventArgs.Reason, Is.EqualTo(ProcessingStoppedReason.OwnershipLost), "Stop reason is incorrect.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.PartitionClosingAsync" />
        ///   event.
        /// </summary>
        ///
        [Test]
        [Ignore("Failing test. (Tracked by: #10015)")]
        public async Task PartitionClosingAsyncTokenIsCanceledWhenStopProcessingAsyncIsCalled()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new InjectableEventSourceProcessorMock(new MockCheckPointStorage(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, mockConsumer.Object);

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new[] { "0" }));

            // We will force an exception when running a partition processing task.

            mockProcessor.RunPartitionProcessingException = new Exception();

            // We'll wait until the closing handler is called and capture its token.

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var capturedToken = default(CancellationToken);

            mockProcessor.PartitionClosingAsync += eventArgs =>
            {
                if (completionSource.TrySetResult(true))
                {
                    capturedToken = eventArgs.CancellationToken;
                }

                return Task.CompletedTask;
            };

            mockProcessor.ProcessEventAsync += eventArgs => Task.CompletedTask;

            mockProcessor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            // Establish timed cancellation to ensure that the test doesn't hang.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            await mockProcessor.StartProcessingAsync(cancellationSource.Token);

            while (!completionSource.Task.IsCompleted
                && !cancellationSource.IsCancellationRequested)
            {
                await Task.Delay(25);
            }

            Assert.That(capturedToken.IsCancellationRequested, Is.False, "The token in the handler should not have been canceled yet.");

            await mockProcessor.StopProcessingAsync(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");
            Assert.That(capturedToken.IsCancellationRequested, Is.True, "The token in the handler should have been canceled.");
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
            var mockProcessor = new InjectableEventSourceProcessorMock(new MockCheckPointStorage(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, mockConsumer.Object);

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new[] { partitionId }));

            mockConsumer
                .Setup(consumer => consumer.ReadEventsFromPartitionAsync(
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<ReadEventOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns<string, EventPosition, ReadEventOptions, CancellationToken>((partition, position, options, token) => MockEmptyPartitionEventEnumerable(1, token));

            mockProcessor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var emptyEventArgs = default(ProcessEventArgs);

            mockProcessor.ProcessEventAsync += eventArgs =>
            {
                emptyEventArgs = eventArgs;
                completionSource.TrySetResult(true);

                return Task.CompletedTask;
            };

            // Start the processor and wait for the event handler to be triggered.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            await mockProcessor.StartProcessingAsync(cancellationSource.Token);
            await completionSource.Task;
            await mockProcessor.StopProcessingAsync(cancellationSource.Token);

            // Validate the empty event arguments.

            Assert.That(emptyEventArgs, Is.Not.Null, "The event arguments should have been populated.");
            Assert.That(emptyEventArgs.Data, Is.Null, "The event arguments should not have an event available.");
            Assert.That(emptyEventArgs.Partition, Is.Not.Null, "The event arguments should have a partition context.");
            Assert.That(emptyEventArgs.Partition.PartitionId, Is.EqualTo(partitionId), "The partition identifier should match.");
            Assert.That(() => emptyEventArgs.Partition.ReadLastEnqueuedEventProperties(), Throws.InstanceOf<InvalidOperationException>(), "The last event properties should not be available.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.ProcessEventAsync" />
        ///   event.
        /// </summary>
        ///
        [Test]
        public async Task ProcessEventAsyncIsNotTriggeredWhenThereIsNoMaximumWaitTime()
        {
            const int testDurationInCycles = 8;

            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockStorage = new Mock<MockCheckPointStorage>(default(Action<string>)) { CallBase = true };
            var mockProcessor = new InjectableEventSourceProcessorMock(mockStorage.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, mockConsumer.Object);

            // We'll run multiple cycles, so keeping the default load balance interval (10s) would take too much time.

            mockProcessor.LoadBalancer.LoadBalanceInterval = TimeSpan.FromMilliseconds(500);

            // We are making the assumption that a single GetPartitionIds call is made every cycle, so we'll
            // use it to count the total of cycles.

            var cycles = 0;

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Callback(() => cycles++)
                .Returns(Task.FromResult(new[] { "0" }));

            mockConsumer
                .Setup(consumer => consumer.ReadEventsFromPartitionAsync(
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<ReadEventOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns<string, EventPosition, ReadEventOptions, CancellationToken>((partition, position, options, token) => MockEndlessPartitionEventEnumerable(options.MaximumWaitTime, token));

            mockProcessor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            var wasHandlerCalled = false;

            mockProcessor.ProcessEventAsync += eventArgs =>
            {
                wasHandlerCalled = true;
                return Task.CompletedTask;
            };

            // Start the processor and wait for the specified amount of cycles.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            await mockProcessor.StartProcessingAsync(cancellationSource.Token);

            while (cycles < testDurationInCycles
                && !cancellationSource.IsCancellationRequested)
            {
                await Task.Delay(25);
            }

            await mockProcessor.StopProcessingAsync(cancellationSource.Token);

            // The handler should not have been called.

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");
            Assert.That(wasHandlerCalled, Is.False, "The handler should not have been called.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.ProcessEventAsync" />
        ///   event.
        /// </summary>
        ///
        [Test]
        public async Task ProcessHandlerTriggersForEveryReceivedEvent()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new InjectableEventSourceProcessorMock(new MockCheckPointStorage(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, mockConsumer.Object);

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new[] { "0" }));

            var numberOfEvents = 5;

            mockConsumer
                .Setup(consumer => consumer.ReadEventsFromPartitionAsync(
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<ReadEventOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns<string, EventPosition, ReadEventOptions, CancellationToken>((partition, position, options, token) => MockPartitionEventEnumerable(numberOfEvents, token));

            mockProcessor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            var processEventTriggerCount = 0;

            mockProcessor.ProcessEventAsync += eventArgs =>
            {
                processEventTriggerCount++;

                if (processEventTriggerCount == numberOfEvents)
                {
                    completionSource.SetResult(true);
                }

                return Task.CompletedTask;
            };

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            // Start the processor and wait for the event handler to be triggered.

            await mockProcessor.StartProcessingAsync(cancellationSource.Token);
            await completionSource.Task;

            Assert.That(numberOfEvents, Is.EqualTo(processEventTriggerCount));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.ProcessEventAsync" />
        ///   event.
        /// </summary>
        ///
        [Test]
        public async Task ProcessEventAsyncTokenIsCanceledWhenStopProcessingAsyncIsCalled()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new InjectableEventSourceProcessorMock(new MockCheckPointStorage(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, mockConsumer.Object);

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new[] { "0" }));

            mockConsumer
                .Setup(consumer => consumer.ReadEventsFromPartitionAsync(
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<ReadEventOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns<string, EventPosition, ReadEventOptions, CancellationToken>((partition, position, options, token) =>
                    MockEmptyPartitionEventEnumerable(1, token));

            // We'll wait until the process handler is called and capture its token.

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var capturedToken = default(CancellationToken);

            mockProcessor.ProcessEventAsync += eventArgs =>
            {
                capturedToken = eventArgs.CancellationToken;
                completionSource.SetResult(true);

                return Task.CompletedTask;
            };

            mockProcessor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            // Establish timed cancellation to ensure that the test doesn't hang.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            await mockProcessor.StartProcessingAsync(cancellationSource.Token);

            while (!completionSource.Task.IsCompleted
                && !cancellationSource.IsCancellationRequested)
            {
                await Task.Delay(25);
            }

            Assert.That(capturedToken.IsCancellationRequested, Is.False, "The token in the handler should not have been canceled yet.");

            await mockProcessor.StopProcessingAsync(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");
            Assert.That(capturedToken.IsCancellationRequested, Is.True, "The token in the handler should have been canceled.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.ProcessErrorAsync" />
        ///   event.
        /// </summary>
        ///
        [Test]
        [Ignore("Failing test. (Tracked by: #10015)")]
        public async Task ProcessErrorAsyncIsTriggeredWithCorrectArgumentsWhenOwnershipClaimFails()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockStorage = new Mock<MockCheckPointStorage>(default(Action<string>)) { CallBase = true };
            var mockProcessor = new InjectableEventSourceProcessorMock(mockStorage.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, mockConsumer.Object);

            var partitionId = "0";

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new[] { partitionId }));

            mockConsumer
                .Setup(consumer => consumer.ReadEventsFromPartitionAsync(
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<ReadEventOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns<string, EventPosition, ReadEventOptions, CancellationToken>((partition, position, options, token) =>
                    MockEndlessPartitionEventEnumerable(options.MaximumWaitTime, token));

            var expectedExceptionReference = new Exception();

            // When the mock storage intercepts a call to ClaimOwnershipAsync with a single object, it means we have found a claim attempt.
            // We will force an exception and catch it with the error handler.

            mockStorage
                .Setup(storage => storage.ClaimOwnershipAsync(
                    It.Is<IEnumerable<PartitionOwnership>>(ownershipEnumerable => ownershipEnumerable.Count() == 1),
                    It.IsAny<CancellationToken>()))
                .Throws(expectedExceptionReference);

            mockProcessor.ProcessEventAsync += eventArgs => Task.CompletedTask;

            var capturedEventArgs = default(ProcessErrorEventArgs);
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            mockProcessor.ProcessErrorAsync += eventArgs =>
            {
                capturedEventArgs = eventArgs;
                completionSource.TrySetResult(true);

                return Task.CompletedTask;
            };

            // Establish timed cancellation to ensure that the test doesn't hang.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            await mockProcessor.StartProcessingAsync(cancellationSource.Token);

            while (!completionSource.Task.IsCompleted
                && !cancellationSource.IsCancellationRequested)
            {
                await Task.Delay(25);
            }

            Assert.That(capturedEventArgs, Is.Not.Null, "The error event args should have been captured.");
            Assert.That(capturedEventArgs.CancellationToken.IsCancellationRequested, Is.False, "The token in the handler should not have been canceled yet.");

            await mockProcessor.StopProcessingAsync(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");
            Assert.That(capturedEventArgs.Operation, Is.EqualTo(Resources.OperationClaimOwnership), "The captured Operation string is not correct.");
            Assert.That(capturedEventArgs.Exception, Is.EqualTo(expectedExceptionReference), "The captured and expected exceptions do not match.");
            Assert.That(capturedEventArgs.PartitionId, Is.EqualTo(partitionId), "The associated partition id does not match.");
            Assert.That(capturedEventArgs.CancellationToken.IsCancellationRequested, Is.True, "The token in the handler should have been canceled.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.ProcessErrorAsync" />
        ///   event.
        /// </summary>
        ///
        [Test]
        [Ignore("Test failing during nightly runs. (Tracked by: #10067)")]
        public async Task ProcessErrorAsyncIsTriggeredWithCorrectArgumentsWhenOwnershipRenewalFails()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockStorage = new Mock<MockCheckPointStorage>(default(Action<string>)) { CallBase = true };
            var mockProcessor = new InjectableEventSourceProcessorMock(mockStorage.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, mockConsumer.Object);

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new[] { "0" }));

            mockConsumer
                .Setup(consumer => consumer.ReadEventsFromPartitionAsync(
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<ReadEventOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns<string, EventPosition, ReadEventOptions, CancellationToken>((partition, position, options, token) =>
                    MockEndlessPartitionEventEnumerable(options.MaximumWaitTime, token));

            var partitionHasBeenClaimed = false;
            var expectedExceptionReference = new Exception();

            // When the mock storage intercepts a call to ClaimOwnershipAsync after the partition has been claimed, it means we have found a renewal attempt.
            // We will force an exception and catch it with the error handler.

            mockStorage
                .Setup(storage => storage.ClaimOwnershipAsync(
                    It.Is<IEnumerable<PartitionOwnership>>(ownershipEnumerable => partitionHasBeenClaimed && ownershipEnumerable.All(ownership => ownership.OwnerIdentifier == mockProcessor.Identifier)),
                    It.IsAny<CancellationToken>()))
                .Throws(expectedExceptionReference);

            mockProcessor.PartitionInitializingAsync += eventArgs =>
            {
                partitionHasBeenClaimed = true;
                return Task.CompletedTask;
            };

            mockProcessor.ProcessEventAsync += eventArgs => Task.CompletedTask;

            var capturedEventArgs = default(ProcessErrorEventArgs);
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            mockProcessor.ProcessErrorAsync += eventArgs =>
            {
                capturedEventArgs = eventArgs;
                completionSource.TrySetResult(true);

                return Task.CompletedTask;
            };

            // Establish timed cancellation to ensure that the test doesn't hang.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            await mockProcessor.StartProcessingAsync(cancellationSource.Token);

            while (!completionSource.Task.IsCompleted
                && !cancellationSource.IsCancellationRequested)
            {
                await Task.Delay(25);
            }

            Assert.That(capturedEventArgs, Is.Not.Null, "The error event args should have been captured.");
            Assert.That(capturedEventArgs.CancellationToken.IsCancellationRequested, Is.False, "The token in the handler should not have been canceled yet.");

            await mockProcessor.StopProcessingAsync(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");
            Assert.That(capturedEventArgs.Operation, Is.EqualTo(Resources.OperationRenewOwnership), "The captured Operation string is not correct.");
            Assert.That(capturedEventArgs.Exception, Is.EqualTo(expectedExceptionReference), "The captured and expected exceptions do not match.");
            Assert.That(capturedEventArgs.PartitionId, Is.Null, "There should be no partition id associated with the renewal attempt failure.");
            Assert.That(capturedEventArgs.CancellationToken.IsCancellationRequested, Is.True, "The token in the handler should have been canceled.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.ProcessErrorAsync" />
        ///   event.
        /// </summary>
        ///
        [Test]
        public async Task ProcessErrorAsyncIsTriggeredWithCorrectArgumentsWhenListOwnershipFails()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockStorage = new Mock<MockCheckPointStorage>(default(Action<string>)) { CallBase = true };
            var mockProcessor = new InjectableEventSourceProcessorMock(mockStorage.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, mockConsumer.Object);

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new[] { "0" }));

            var expectedExceptionReference = new Exception();

            // We will force an exception and catch it with the error handler.

            mockStorage
                .Setup(storage => storage.ListOwnershipAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .Throws(expectedExceptionReference);

            mockProcessor.ProcessEventAsync += eventArgs => Task.CompletedTask;

            var capturedEventArgs = default(ProcessErrorEventArgs);
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            mockProcessor.ProcessErrorAsync += eventArgs =>
            {
                capturedEventArgs = eventArgs;
                completionSource.TrySetResult(true);

                return Task.CompletedTask;
            };

            // Establish timed cancellation to ensure that the test doesn't hang.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            await mockProcessor.StartProcessingAsync(cancellationSource.Token);

            while (!completionSource.Task.IsCompleted
                && !cancellationSource.IsCancellationRequested)
            {
                await Task.Delay(25);
            }

            Assert.That(capturedEventArgs, Is.Not.Null, "The error event args should have been captured.");
            Assert.That(capturedEventArgs.CancellationToken.IsCancellationRequested, Is.False, "The token in the handler should not have been canceled yet.");

            await mockProcessor.StopProcessingAsync(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");
            Assert.That(capturedEventArgs.Operation, Is.EqualTo(Resources.OperationListOwnership), "The captured Operation string is not correct.");
            Assert.That(capturedEventArgs.Exception, Is.EqualTo(expectedExceptionReference), "The captured and expected exceptions do not match.");
            Assert.That(capturedEventArgs.PartitionId, Is.Null, "There should be no partition id associated with the list ownership failure.");
            Assert.That(capturedEventArgs.CancellationToken.IsCancellationRequested, Is.True, "The token in the handler should have been canceled.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.ProcessErrorAsync" />
        ///   event.
        /// </summary>
        ///
        [Test]
        public async Task ProcessErrorAsyncIsTriggeredWithCorrectArgumentsWhenGetPartitionIdsFails()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new InjectableEventSourceProcessorMock(new MockCheckPointStorage(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, mockConsumer.Object);

            var expectedExceptionReference = new Exception();

            // We will force an exception and catch it with the error handler.

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Throws(expectedExceptionReference);

            mockProcessor.ProcessEventAsync += eventArgs => Task.CompletedTask;

            var capturedEventArgs = default(ProcessErrorEventArgs);
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            mockProcessor.ProcessErrorAsync += eventArgs =>
            {
                capturedEventArgs = eventArgs;
                completionSource.TrySetResult(true);

                return Task.CompletedTask;
            };

            // Establish timed cancellation to ensure that the test doesn't hang.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            await mockProcessor.StartProcessingAsync(cancellationSource.Token);

            while (!completionSource.Task.IsCompleted
                && !cancellationSource.IsCancellationRequested)
            {
                await Task.Delay(25);
            }

            Assert.That(capturedEventArgs, Is.Not.Null, "The error event args should have been captured.");
            Assert.That(capturedEventArgs.CancellationToken.IsCancellationRequested, Is.False, "The token in the handler should not have been canceled yet.");

            await mockProcessor.StopProcessingAsync(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");
            Assert.That(capturedEventArgs.Operation, Is.EqualTo(Resources.OperationGetPartitionIds), "The captured Operation string is not correct.");
            Assert.That(capturedEventArgs.Exception, Is.EqualTo(expectedExceptionReference), "The captured and expected exceptions do not match.");
            Assert.That(capturedEventArgs.PartitionId, Is.Null, "There should be no partition id associated with the get partition ids failure.");
            Assert.That(capturedEventArgs.CancellationToken.IsCancellationRequested, Is.True, "The token in the handler should have been canceled.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.ProcessErrorAsync" />
        ///   event.
        /// </summary>
        ///
        [Test]
        public async Task ProcessErrorAsyncIsTriggeredWithCorrectArgumentsWhenListCheckpointsFails()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockStorage = new Mock<MockCheckPointStorage>(default(Action<string>)) { CallBase = true };
            var mockProcessor = new InjectableEventSourceProcessorMock(mockStorage.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, mockConsumer.Object);

            var partitionId = "0";

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new[] { partitionId }));

            var expectedExceptionReference = new Exception();

            // We will force an exception and catch it with the error handler.

            mockStorage
                .Setup(storage => storage.ListCheckpointsAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .Throws(expectedExceptionReference);

            mockProcessor.ProcessEventAsync += eventArgs => Task.CompletedTask;

            var capturedEventArgs = default(ProcessErrorEventArgs);
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            mockProcessor.ProcessErrorAsync += eventArgs =>
            {
                capturedEventArgs = eventArgs;
                completionSource.TrySetResult(true);

                return Task.CompletedTask;
            };

            // Establish timed cancellation to ensure that the test doesn't hang.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            await mockProcessor.StartProcessingAsync(cancellationSource.Token);

            while (!completionSource.Task.IsCompleted
                && !cancellationSource.IsCancellationRequested)
            {
                await Task.Delay(25);
            }

            Assert.That(capturedEventArgs, Is.Not.Null, "The error event args should have been captured.");
            Assert.That(capturedEventArgs.CancellationToken.IsCancellationRequested, Is.False, "The token in the handler should not have been canceled yet.");

            await mockProcessor.StopProcessingAsync(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");
            Assert.That(capturedEventArgs.Operation, Is.EqualTo(Resources.OperationListCheckpoints), "The captured Operation string is not correct.");
            Assert.That(capturedEventArgs.Exception, Is.EqualTo(expectedExceptionReference), "The captured and expected exceptions do not match.");
            Assert.That(capturedEventArgs.PartitionId, Is.EqualTo(partitionId), "The associated partition id does not match.");
            Assert.That(capturedEventArgs.CancellationToken.IsCancellationRequested, Is.True, "The token in the handler should have been canceled.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.ProcessErrorAsync" />
        ///   event.
        /// </summary>
        ///
        [Test]
        public async Task ProcessErrorAsyncIsTriggeredWithCorrectArgumentsWhenPartitionProcessingFails()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new InjectableEventSourceProcessorMock(new MockCheckPointStorage(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, mockConsumer.Object);

            var partitionId = "0";

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new[] { partitionId }));

            var expectedExceptionReference = new Exception();

            // We will force an exception and catch it with the error handler.

            mockProcessor.RunPartitionProcessingException = expectedExceptionReference;

            mockProcessor.ProcessEventAsync += eventArgs => Task.CompletedTask;

            var capturedEventArgs = default(ProcessErrorEventArgs);
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            mockProcessor.ProcessErrorAsync += eventArgs =>
            {
                if (completionSource.TrySetResult(true))
                {
                    capturedEventArgs = eventArgs;
                }

                return Task.CompletedTask;
            };

            // Establish timed cancellation to ensure that the test doesn't hang.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            await mockProcessor.StartProcessingAsync(cancellationSource.Token);

            while (!completionSource.Task.IsCompleted
                && !cancellationSource.IsCancellationRequested)
            {
                await Task.Delay(25);
            }

            Assert.That(capturedEventArgs, Is.Not.Null, "The error event args should have been captured.");
            Assert.That(capturedEventArgs.CancellationToken.IsCancellationRequested, Is.False, "The token in the handler should not have been canceled yet.");

            await mockProcessor.StopProcessingAsync(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");
            Assert.That(capturedEventArgs.Operation, Is.EqualTo(Resources.OperationReadEvents), "The captured Operation string is not correct.");
            Assert.That(capturedEventArgs.Exception, Is.EqualTo(expectedExceptionReference), "The captured and expected exceptions do not match.");
            Assert.That(capturedEventArgs.PartitionId, Is.EqualTo(partitionId), "The associated partition id does not match.");
            Assert.That(capturedEventArgs.CancellationToken.IsCancellationRequested, Is.True, "The token in the handler should have been canceled.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.ProcessErrorAsync" />
        ///   event.
        /// </summary>
        ///
        [Test]
        [Ignore("Test failing during nightly runs. (Tracked by: #10067)")]
        public async Task ProcessErrorAsyncIsNotTriggeredWhenRelinquishingOwnershipFails()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockStorage = new Mock<MockCheckPointStorage>(default(Action<string>)) { CallBase = true };
            var mockProcessor = new InjectableEventSourceProcessorMock(mockStorage.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, mockConsumer.Object);

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new[] { "0" }));

            mockConsumer
                .Setup(consumer => consumer.ReadEventsFromPartitionAsync(
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<ReadEventOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns<string, EventPosition, ReadEventOptions, CancellationToken>((partition, position, options, token) =>
                    MockEndlessPartitionEventEnumerable(options.MaximumWaitTime, token));

            var expectedExceptionReference = new Exception();

            // When the mock storage intercepts a call to ClaimOwnershipAsync with no owner id, it means we have found a relinquish attempt.
            // We will force an exception and catch it with the error handler.

            mockStorage
                .Setup(storage => storage.ClaimOwnershipAsync(
                    It.Is<IEnumerable<PartitionOwnership>>(ownershipEnumerable => ownershipEnumerable.Any(ownership => string.IsNullOrEmpty(ownership.OwnerIdentifier))),
                    It.IsAny<CancellationToken>()))
                .Throws(expectedExceptionReference);

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            // We can stop processing once the partition has been claimed.

            mockProcessor.PartitionInitializingAsync += eventArgs =>
            {
                completionSource.SetResult(true);
                return Task.CompletedTask;
            };

            mockProcessor.ProcessEventAsync += eventArgs => Task.CompletedTask;

            var hasCalledProcessError = false;

            mockProcessor.ProcessErrorAsync += eventArgs =>
            {
                hasCalledProcessError = true;
                return Task.CompletedTask;
            };

            // Establish timed cancellation to ensure that the test doesn't hang.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            await mockProcessor.StartProcessingAsync(cancellationSource.Token);

            while (!completionSource.Task.IsCompleted
                && !cancellationSource.IsCancellationRequested)
            {
                await Task.Delay(25);
            }

            var capturedException = default(Exception);

            try
            {
                await mockProcessor.StopProcessingAsync(cancellationSource.Token);
            }
            catch (Exception ex)
            {
                capturedException = ex;
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");

            Assert.That(capturedException, Is.Not.Null, "An exception should have be thrown when stopping the processor.");
            Assert.That(capturedException, Is.EqualTo(expectedExceptionReference), "The captured and expected exceptions do not match.");
            Assert.That(hasCalledProcessError, Is.False, "The error handler should not have been triggered.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.ProcessErrorAsync" />
        ///   event.
        /// </summary>
        ///
        [Test]
        [Ignore("Test failing during nightly runs. (Tracked by: #10067)")]
        public async Task ProcessErrorAsyncIsNotTriggeredWhenUpdateCheckpointFails()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockStorage = new Mock<MockCheckPointStorage>(default(Action<string>)) { CallBase = true };
            var mockProcessor = new InjectableEventSourceProcessorMock(mockStorage.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, mockConsumer.Object);

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new[] { "0" }));

            mockConsumer
                .Setup(consumer => consumer.ReadEventsFromPartitionAsync(
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<ReadEventOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns<string, EventPosition, ReadEventOptions, CancellationToken>((partition, position, options, token) => MockPartitionEventEnumerable(1, token));

            var expectedExceptionReference = new Exception();

            // We will force an exception and catch it with a catch block.

            mockStorage
                .Setup(storage => storage.UpdateCheckpointAsync(
                    It.IsAny<Checkpoint>(),
                    It.IsAny<CancellationToken>()))
                .Throws(expectedExceptionReference);

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var capturedException = default(Exception);

            mockProcessor.ProcessEventAsync += async eventArgs =>
            {
                try
                {
                    await eventArgs.UpdateCheckpointAsync();
                }
                catch (Exception ex)
                {
                    capturedException = ex;
                }

                completionSource.SetResult(true);
            };

            var hasCalledProcessError = false;

            mockProcessor.ProcessErrorAsync += eventArgs =>
            {
                hasCalledProcessError = true;
                return Task.CompletedTask;
            };

            // Establish timed cancellation to ensure that the test doesn't hang.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            await mockProcessor.StartProcessingAsync(cancellationSource.Token);

            while (!completionSource.Task.IsCompleted
                && !cancellationSource.IsCancellationRequested)
            {
                await Task.Delay(25);
            }

            Assert.That(mockProcessor.IsRunning, Is.True, "The processor should not have stopped working.");

            await mockProcessor.StopProcessingAsync(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");

            Assert.That(capturedException, Is.Not.Null, "An exception should have be thrown when updating the checkpoint.");
            Assert.That(capturedException, Is.EqualTo(expectedExceptionReference), "The captured and expected exceptions do not match.");
            Assert.That(hasCalledProcessError, Is.False, "The error handler should not have been triggered.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.ProcessErrorAsync" />
        ///   event.
        /// </summary>
        ///
        [Test]
        public async Task ProcessErrorAsyncIsNotTriggeredWhenPartitionInitializingAsyncFails()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new InjectableEventSourceProcessorMock(new MockCheckPointStorage(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, mockConsumer.Object);

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new[] { "0" }));

            var expectedExceptionReference = new Exception();
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            mockProcessor.PartitionInitializingAsync += eventArgs =>
            {
                completionSource.SetResult(true);
                throw expectedExceptionReference;
            };

            mockProcessor.ProcessEventAsync += eventArgs => Task.CompletedTask;

            var hasCalledProcessError = false;

            mockProcessor.ProcessErrorAsync += eventArgs =>
            {
                hasCalledProcessError = true;
                return Task.CompletedTask;
            };

            // Establish timed cancellation to ensure that the test doesn't hang.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            await mockProcessor.StartProcessingAsync(cancellationSource.Token);

            while (!completionSource.Task.IsCompleted
                && !cancellationSource.IsCancellationRequested)
            {
                await Task.Delay(25);
            }

            var capturedException = default(Exception);

            try
            {
                await mockProcessor.StopProcessingAsync(cancellationSource.Token);
            }
            catch (Exception ex)
            {
                capturedException = ex;
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");

            Assert.That(capturedException, Is.Not.Null, "An exception should have be thrown when stopping the processor.");
            Assert.That(capturedException, Is.EqualTo(expectedExceptionReference), "The captured and expected exceptions do not match.");
            Assert.That(hasCalledProcessError, Is.False, "The error handler should not have been triggered.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.ProcessErrorAsync" />
        ///   event.
        /// </summary>
        ///
        [Test]
        [Ignore("Not implemented yet. (Tracked by #9228)")]
        public async Task ProcessErrorAsyncIsNotTriggeredWhenProcessEventAsyncFails()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new InjectableEventSourceProcessorMock(new MockCheckPointStorage(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, mockConsumer.Object);

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new[] { "0" }));

            mockConsumer
                .Setup(consumer => consumer.ReadEventsFromPartitionAsync(
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<ReadEventOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns<string, EventPosition, ReadEventOptions, CancellationToken>((partition, position, options, token) =>
                    MockEndlessPartitionEventEnumerable(options.MaximumWaitTime, token));

            var expectedExceptionReference = new Exception();
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            mockProcessor.ProcessEventAsync += eventArgs =>
            {
                completionSource.SetResult(true);
                throw expectedExceptionReference;
            };

            var hasCalledProcessError = false;

            mockProcessor.ProcessErrorAsync += eventArgs =>
            {
                hasCalledProcessError = true;
                return Task.CompletedTask;
            };

            // Establish timed cancellation to ensure that the test doesn't hang.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            await mockProcessor.StartProcessingAsync(cancellationSource.Token);

            while (!completionSource.Task.IsCompleted
                && !cancellationSource.IsCancellationRequested)
            {
                await Task.Delay(25);
            }

            var capturedException = default(Exception);

            try
            {
                await mockProcessor.StopProcessingAsync(cancellationSource.Token);
            }
            catch (Exception ex)
            {
                capturedException = ex;
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");

            Assert.That(capturedException, Is.Not.Null, "An exception should have be thrown when stopping the processor.");
            Assert.That(capturedException, Is.EqualTo(expectedExceptionReference), "The captured and expected exceptions do not match.");
            Assert.That(hasCalledProcessError, Is.False, "The error handler should not have been triggered.");
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
            var mockProcessor = new InjectableEventSourceProcessorMock(new MockCheckPointStorage(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, mockConsumer.Object);

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

            mockProcessor.ProcessEventAsync += eventArgs => Task.CompletedTask;

            // Create a handler that does not complete in a reasonable amount of time.  To ensure that the
            // test does not hang for the duration, set a timeout to force completion after a shorter period
            // of time.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            mockProcessor.ProcessErrorAsync += async eventArgs =>
            {
                completionSource.SetResult(true);
                await Task.Delay(TimeSpan.FromMinutes(3), cancellationSource.Token);
            };

            // Start the processor and wait for the event handler to be triggered.

            await mockProcessor.StartProcessingAsync();
            await completionSource.Task;

            // Stop the processor and ensure that it does not block on the handler.

            Assert.That(async () => await mockProcessor.StopProcessingAsync(cancellationSource.Token), Throws.Nothing, "The processor should stop without a problem.");
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
            var mockProcessor = new InjectableEventSourceProcessorMock(new MockCheckPointStorage(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, mockConsumer.Object);

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

            mockProcessor.ProcessEventAsync += eventArgs => Task.CompletedTask;

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            mockProcessor.ProcessErrorAsync += async eventArgs =>
            {
                await mockProcessor.StopProcessingAsync(cancellationSource.Token);
                completionSource.SetResult(true);
            };

            // Start the processor and wait for the event handler to be triggered.

            await mockProcessor.StartProcessingAsync(cancellationSource.Token);
            await completionSource.Task;

            // Ensure that the processor has been stopped.

            Assert.That(mockProcessor.IsRunning, Is.False, "The processor should have stopped.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" />
        ///   when resuming from a previous checkpoint.
        /// </summary>
        ///
        [Test]
        public async Task ProcessingStartsWithTheNextEventAfterTheCheckpoint()
        {
            var fqNamespace = "namespace";
            var eventHub = "hub";
            var consumerGroup = "consumerGroup";
            var partitionId = "3";
            var checkpointOffset = 5631;
            var checkpoint = new Checkpoint(fqNamespace, eventHub, consumerGroup, partitionId, checkpointOffset, 0);
            var mockStorage = new MockCheckPointStorage();
            var mockConsumer = new Mock<EventHubConsumerClient>(consumerGroup, Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new InjectableEventSourceProcessorMock(mockStorage, consumerGroup, fqNamespace, eventHub, Mock.Of<Func<EventHubConnection>>(), default, mockConsumer.Object);
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            mockStorage
                .Checkpoints.Add((fqNamespace, eventHub, consumerGroup, partitionId), checkpoint);

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { partitionId });

            mockConsumer
                .Setup(consumer => consumer.ReadEventsFromPartitionAsync(
                    partitionId,
                    EventPosition.FromOffset(checkpointOffset, false),
                    It.IsAny<ReadEventOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns<string, EventPosition, ReadEventOptions, CancellationToken>((partition, position, options, token) => MockPartitionEventEnumerable(20, token))
                .Callback(() => completionSource.SetResult(true))
                .Verifiable("The consumer should have been asked to read using the expected offset.");

            mockProcessor.ProcessEventAsync += eventArgs => Task.CompletedTask;
            mockProcessor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            // Start processing and wait for the consumer to be invoked.  Set a cancellation for backup to ensure
            // that the test completes deterministically.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            await mockProcessor.StartProcessingAsync(cancellationSource.Token);
            await Task.WhenAny(Task.Delay(-1, cancellationSource.Token), completionSource.Task);
            await mockProcessor.StopProcessingAsync(cancellationSource.Token);

            // Validate that the consumer was invoked and that cancellation did not take place.

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");
            mockConsumer.VerifyAll();

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" />
        ///   when resuming from a previous checkpoint.
        /// </summary>
        ///
        [Test]
        public async Task ProcessingStartsWithTheExactDefaultPositionWithNoCheckpoint()
        {
            var fqNamespace = "namespace";
            var eventHub = "hub";
            var consumerGroup = "consumerGroup";
            var partitionId = "3";
            var defaultPosition = EventPosition.FromSequenceNumber(88724);
            var mockStorage = new MockCheckPointStorage();
            var mockConsumer = new Mock<EventHubConsumerClient>(consumerGroup, Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new InjectableEventSourceProcessorMock(mockStorage, consumerGroup, fqNamespace, eventHub, Mock.Of<Func<EventHubConnection>>(), default, mockConsumer.Object);
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { partitionId });

            mockConsumer
                .Setup(consumer => consumer.ReadEventsFromPartitionAsync(
                    partitionId,
                    defaultPosition,
                    It.IsAny<ReadEventOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns<string, EventPosition, ReadEventOptions, CancellationToken>((partition, position, options, token) => MockPartitionEventEnumerable(20, token))
                .Callback(() => completionSource.SetResult(true))
                .Verifiable("The consumer should have been asked to read using the expected offset.");

            mockProcessor.ProcessEventAsync += eventArgs => Task.CompletedTask;
            mockProcessor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            mockProcessor.PartitionInitializingAsync += eventArgs =>
            {
                eventArgs.DefaultStartingPosition = defaultPosition;
                return Task.CompletedTask;
            };

            // Start processing and wait for the consumer to be invoked.  Set a cancellation for backup to ensure
            // that the test completes deterministically.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            await mockProcessor.StartProcessingAsync(cancellationSource.Token);
            await Task.WhenAny(Task.Delay(-1, cancellationSource.Token), completionSource.Task);
            await mockProcessor.StopProcessingAsync(cancellationSource.Token);

            // Validate that the consumer was invoked and that cancellation did not take place.

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");
            mockConsumer.VerifyAll();

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.ProcessEventAsync" />
        ///   handler's <see cref="ProcessEventArgs.UpdateCheckpointAsync" /> method.
        /// </summary>
        ///
        [Test]
        public async Task WhenProcessEventTriggersWithNoDataUpdateCheckpointThrows()
        {
            var partitionId = "expectedPartition";
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new InjectableEventSourceProcessorMock(new MockCheckPointStorage(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, mockConsumer.Object);

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

            mockProcessor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var emptyEventArgs = default(ProcessEventArgs);

            mockProcessor.ProcessEventAsync += eventArgs =>
            {
                emptyEventArgs = eventArgs;

                Assert.That(async () => await eventArgs.UpdateCheckpointAsync(), Throws.InstanceOf<InvalidOperationException>(), "An exception should have been thrown when ProcessEventAsync triggers with no data.");

                completionSource.SetResult(true);

                return Task.CompletedTask;
            };

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            await mockProcessor.StartProcessingAsync(cancellationSource.Token);
            await completionSource.Task;
            await mockProcessor.StopProcessingAsync(cancellationSource.Token);

            // Validate the empty event arguments.

            Assert.That(emptyEventArgs, Is.Not.Null, "The event arguments should have been populated.");
            Assert.That(emptyEventArgs.Data, Is.Null, "The event arguments should not have an event available.");
            Assert.That(emptyEventArgs.Partition, Is.Not.Null, "The event arguments should have a partition context.");
            Assert.That(emptyEventArgs.Partition.PartitionId, Is.EqualTo(partitionId), "The partition identifier should match.");
            Assert.That(() => emptyEventArgs.Partition.ReadLastEnqueuedEventProperties(), Throws.InstanceOf<InvalidOperationException>(), "The last event properties should not be available.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.ProcessEventAsync" />
        ///   handler's <see cref="ProcessEventArgs.UpdateCheckpointAsync" /> method.
        /// </summary>
        ///
        [Test]
        public async Task AlreadyCancelledTokenMakesUpdateCheckpointThrow()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new InjectableEventSourceProcessorMock(new MockCheckPointStorage(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, mockConsumer.Object);

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new[] { "0", "1" }));

            mockConsumer
                .Setup(consumer => consumer.ReadEventsFromPartitionAsync(
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<ReadEventOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns<string, EventPosition, ReadEventOptions, CancellationToken>((partition, position, options, token) => MockPartitionEventEnumerable(5, token));

            mockProcessor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

            mockProcessor.ProcessEventAsync += eventArgs =>
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.Cancel();

                Assert.That(async () => await eventArgs.UpdateCheckpointAsync(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());

                completionSource.SetResult(true);

                return Task.CompletedTask;
            };

            await mockProcessor.StartProcessingAsync();
            await completionSource.Task;
            await mockProcessor.StopProcessingAsync();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.ToString" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ToStringReturnsStringContainingProcessorIdentifier()
        {
            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<StorageManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, default) { CallBase = true };
            var stringContaingIdentifier = mockProcessor.Object.ToString();

            Assert.That(stringContaingIdentifier.Contains(mockProcessor.Object.Identifier), Is.True, "ToString() should return a string that contains the processor's identifier");
        }

        /// <summary>
        ///   Verifies that processor stops processing partition it doesn't own anymore.
        /// </summary>
        ///
        [Test]
        [Ignore("Unstable test. (Tracked by: #10067)")]
        public async Task ProcessorStopsProcessingPartitionItDoesNotOwnAnymore()
        {
            const int NumberOfPartitions = 2;
            Func<EventHubConnection> connectionFactory = () => new MockConnection();
            var connection = connectionFactory();
            var storageManager = new MockCheckPointStorage((s) => Console.WriteLine(s));
            var processor1 = new MockEventProcessorClient(
                storageManager,
                connectionFactory: connectionFactory,
                numberOfPartitions: NumberOfPartitions,
                clientOptions: default);
            var processor2 = new MockEventProcessorClient(
                storageManager,
                connectionFactory: connectionFactory,
                numberOfPartitions: NumberOfPartitions,
                clientOptions: default);

            // Establish timed cancellation to ensure that the test doesn't hang.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(45));
            processor1.LoadBalancer.LoadBalanceInterval = TimeSpan.FromMilliseconds(100);

            // Ownership should start empty.

            var completeOwnership = await storageManager.ListOwnershipAsync(processor1.FullyQualifiedNamespace, processor1.EventHubName, processor1.ConsumerGroup, cancellationSource.Token);
            Assert.That(completeOwnership.Any(), Is.False);

            // Start the processor so that the processor claims a random partition until none are left.

            await processor1.StartProcessingAsync(cancellationSource.Token);
            await processor1.WaitStabilization();

            completeOwnership = await storageManager.ListOwnershipAsync(processor1.FullyQualifiedNamespace, processor1.EventHubName, processor1.ConsumerGroup, cancellationSource.Token);

            // All partitions are owned by Processor1.

            Assert.That(completeOwnership.Count(p => p.OwnerIdentifier.Equals(processor1.Identifier)), Is.EqualTo(NumberOfPartitions));

            // Start Processor2 so that it will steal 1 partition from processor1.

            await processor2.StartProcessingAsync(cancellationSource.Token);
            await processor2.WaitStabilization();

            completeOwnership = await storageManager.ListOwnershipAsync(processor1.FullyQualifiedNamespace, processor1.EventHubName, processor1.ConsumerGroup, cancellationSource.Token);

            // Now both processors own 1 partition.

            Assert.That(completeOwnership.ElementAt(0).OwnerIdentifier, Is.Not.EqualTo(completeOwnership.ElementAt(1).OwnerIdentifier));

            // processor1 stopped processing partition it doesn't own anymore with OwnershipLost reason.

            Assert.That(processor1.StopReasons.Values.First, Is.EqualTo(ProcessingStoppedReason.OwnershipLost));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" />
        ///   load balance cycle.
        /// </summary>
        ///
        [Test]
        public async Task ProcessorRenewsItsOwnershipEveryCycle()
        {
            const int testDurationInCycles = 4;

            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockStorage = new Mock<MockCheckPointStorage>(default(Action<string>)) { CallBase = true };
            var mockProcessor = new InjectableEventSourceProcessorMock(mockStorage.Object, "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default, mockConsumer.Object);

            // We'll run multiple cycles, so keeping the default load balance interval (10s) would take too much time.

            mockProcessor.LoadBalancer.LoadBalanceInterval = TimeSpan.FromMilliseconds(500);

            // We are making the assumption that a single GetPartitionIds call is made every cycle, so we'll
            // use it to count the total of cycles.

            var cycles = 0;

            mockConsumer
                .Setup(consumer => consumer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Callback(() => cycles++)
                .Returns(Task.FromResult(new[] { "0" }));

            mockConsumer
                .Setup(consumer => consumer.ReadEventsFromPartitionAsync(
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<ReadEventOptions>(),
                    It.IsAny<CancellationToken>()))
                .Returns<string, EventPosition, ReadEventOptions, CancellationToken>((partition, position, options, token) =>
                    MockEndlessPartitionEventEnumerable(options.MaximumWaitTime, token));

            // When the mock storage intercepts a call to ClaimOwnershipAsync with at least one object, it means we have found a claim attempt.
            // The processor could also be relinquishing ownership, so make sure it has a valid owner id.

            var renewals = 0;

            mockStorage
                .Setup(storage => storage.ClaimOwnershipAsync(
                    It.Is<IEnumerable<PartitionOwnership>>(ownershipEnumerable => ownershipEnumerable.Any(ownership => !string.IsNullOrEmpty(ownership.OwnerIdentifier))),
                    It.IsAny<CancellationToken>()))
                .Callback(() => renewals++);

            mockProcessor.ProcessEventAsync += eventArgs => Task.CompletedTask;
            mockProcessor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            // Establish timed cancellation to ensure that the test doesn't hang.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            await mockProcessor.StartProcessingAsync(cancellationSource.Token);

            while (cycles < testDurationInCycles
                && !cancellationSource.IsCancellationRequested)
            {
                await Task.Delay(25);
            }

            await mockProcessor.StopProcessingAsync(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");
            Assert.That(renewals, Is.EqualTo(cycles).Within(1));
        }

        /// <summary>
        ///   Retrieves the StorageManager for the processor client using its private accessor.
        /// </summary>
        ///
        private static BlobsCheckpointStore GetStorageManager(EventProcessorClient client) =>
            (BlobsCheckpointStore)
            typeof(EventProcessorClient)
                .GetProperty("StorageManager", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(client);

        /// <summary>
        ///   Retrieves the RetryPolicy for the storage manager using its private accessor.
        /// </summary>
        ///
        private static EventHubsRetryPolicy GetStorageManagerRetryPolicy(BlobsCheckpointStore storageManager) =>
            (EventHubsRetryPolicy)
            typeof(BlobsCheckpointStore)
                .GetProperty("RetryPolicy", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(storageManager);

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
                await Task.Delay(5);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                // If offset and sequence number are not set, the processor will throw an exception when updating
                // checkpoint.

                var eventData = new EventDataMock(Encoding.UTF8.GetBytes($"Event { index }"), index, index);
                yield return new PartitionEvent(new MockPartitionContext("fake"), eventData);
            }

            await Task.CompletedTask;
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
                await Task.Delay(5);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                yield return new PartitionEvent();
            }

            await Task.CompletedTask;
        }

        /// <summary>
        ///   Allows for injecting an offset and a sequence number to the Event Data creation.
        /// </summary>
        ///
        private class EventDataMock : EventData
        {
            public EventDataMock(ReadOnlyMemory<byte> eventBody,
                                 long sequenceNumber,
                                 long offset) : base(eventBody, sequenceNumber: sequenceNumber, offset: offset)
            {
            }
        }

        /// <summary>
        ///   Allows for injecting a consumer client to use as the source of events to be processed.
        /// </summary>
        ///
        private class InjectableEventSourceProcessorMock : EventProcessorClient
        {
            public Func<string, EventPosition, CancellationToken, bool> ShouldIgnoreTestRunnerException = (id, pos, token) => true;

            public Exception RunPartitionProcessingException;

            private EventHubConsumerClient _consumer;

            public InjectableEventSourceProcessorMock(StorageManager storageManager,
                                                      string consumerGroup,
                                                      string fullyQualifiedNamespace,
                                                      string eventHubName,
                                                      Func<EventHubConnection> connectionFactory,
                                                      EventProcessorClientOptions clientOptions,
                                                      EventHubConsumerClient eventSourceConsumer) : base(storageManager, consumerGroup, fullyQualifiedNamespace, eventHubName, connectionFactory, clientOptions)
            {
                Argument.AssertNotNull(eventSourceConsumer, nameof(eventSourceConsumer));
                _consumer = eventSourceConsumer;
            }

            internal override EventHubConsumerClient CreateConsumer(string consumerGroup,
                                                                    EventHubConnection connection,
                                                                    EventHubConsumerClientOptions options) => _consumer;

            internal override async Task RunPartitionProcessingAsync(string partitionId, EventPosition startingPosition, CancellationToken cancellationToken)
            {
                // There are a few scenarios in which we want to throw from RunPartitionProcessingAsync.
                // The NullReferenceException thrown by the test runner overwrites the exception we are
                // expecting, so this workaround is necessary.

                if (RunPartitionProcessingException != null)
                {
                    throw RunPartitionProcessingException;
                }

                try
                {
                    await base.RunPartitionProcessingAsync(partitionId, startingPosition, cancellationToken).ConfigureAwait(false);
                }
                catch (NullReferenceException ex)
                    when ((ShouldIgnoreTestRunnerException(partitionId, startingPosition, cancellationToken))
                        && (string.Equals(ex.Source, "Microsoft.Bcl.AsyncInterfaces", StringComparison.OrdinalIgnoreCase)))
                {
                    // This is a test-specific error that occurs when stopping and using a mocked event source.
                    // This scenario does not occur outside of the NUnit runner environment.  To ensure that
                    // tests have parity with real-world scenarios, guard against the "not real" exception here.
                }
            }
        }

        /// <summary>
        ///   Creates a mock async enumerable to simulate reading events from a partition.
        /// </summary>
        ///
        private static async IAsyncEnumerable<PartitionEvent> MockEndlessPartitionEventEnumerable(TimeSpan? maximumWaitTime,
                                                                                                  [EnumeratorCancellation]CancellationToken cancellationToken)
        {
            if (!maximumWaitTime.HasValue)
            {
                await Task.Delay(Timeout.Infinite, cancellationToken).ConfigureAwait(false);
            }

            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(maximumWaitTime.Value, cancellationToken).ConfigureAwait(false);
                yield return new PartitionEvent();
            }

            throw new TaskCanceledException();
        }

        /// <summary>
        ///   Serves as a non-functional connection for testing processor functionality.
        /// </summary>
        ///
        private class MockConnection : EventHubConnection
        {
            public MockConnection(string namespaceName = "fakeNamespace",
                                  string eventHubName = "fakeEventHub",
                                  EventHubConnectionOptions options = null) : base(namespaceName, eventHubName, CreateCredentials(), options)
            { }

            private static EventHubTokenCredential CreateCredentials()
            {
                return new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net").Object;
            }
        }

        /// <summary>
        ///   Serves as a mock <see cref="PartitionContext" />.
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
