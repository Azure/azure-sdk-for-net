// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Metadata;
using Azure.Storage.Blobs;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Processor.Tests
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
            var processor = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "namespace", "eventHub", () => new MockConnection(), default);
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
            var processor = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "namespace", "eventHub", () => new MockConnection(), default);
            processor.ProcessEventAsync += eventArgs => Task.CompletedTask;

            Assert.That(async () => await processor.StartProcessingAsync(), Throws.InstanceOf<InvalidOperationException>().And.Message.Contains(nameof(EventProcessorClient.ProcessErrorAsync)));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.StartAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task StartAsyncStartsTheEventProcessorWhenProcessingHandlerPropertiesAreSet()
        {
            var processor = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "namespace", "eventHub", () => new MockConnection(), default);

            processor.ProcessEventAsync += eventArgs => Task.CompletedTask;
            processor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            Assert.That(async () => await processor.StartProcessingAsync(), Throws.Nothing);

            await processor.StopProcessingAsync();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> properties.
        /// </summary>
        ///
        [Test]
        [Ignore("Update to match new event behavior.")]
        public async Task HandlerPropertiesCannotBeSetWhenEventProcessorIsRunning()
        {
            var processor = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "namespace", "eventHub", () => new MockConnection(), default);

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
            var processor = new EventProcessorClient(Mock.Of<BlobContainerClient>(), "consumerGroup", "namespace", "eventHub", () => new MockConnection(), default);

            processor.ProcessEventAsync += eventArgs => Task.CompletedTask;
            processor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            await processor.StartProcessingAsync();
            await processor.StopProcessingAsync();

            Assert.That(() => processor.PartitionInitializingAsync += eventArgs => Task.CompletedTask, Throws.Nothing);
            Assert.That(() => processor.PartitionClosingAsync += eventArgs => Task.CompletedTask, Throws.Nothing);
            Assert.That(() => processor.ProcessEventAsync += eventArgs => Task.CompletedTask, Throws.Nothing);
            Assert.That(() => processor.ProcessErrorAsync += eventArgs => Task.CompletedTask, Throws.Nothing);
        }

        [Test]
        public async Task StoppedClient_RelinquishesPartitionOwnerships_OtherClients_ConsiderThemClaimableImmediately()
        {
            const int NumberOfPartitions = 3;
            Func<EventHubConnection> connectionFactory = () => new MockConnection();
            var connection = connectionFactory();
            var partitionManager = new MockCheckPointStorage((s) => Console.WriteLine(s));
            var processor1 = new MockEventProcessorClient(
                Mock.Of<BlobContainerClient>(),
                connectionFactory: connectionFactory,
                numberOfPartitions: NumberOfPartitions,
                options: default)
            {
                StorageManager = new Lazy<PartitionManager>(() => partitionManager, LazyThreadSafetyMode.PublicationOnly)
            };
            var processor2 = new MockEventProcessorClient(
                Mock.Of<BlobContainerClient>(),
                connectionFactory: connectionFactory,
                numberOfPartitions: NumberOfPartitions,
                options: default)
            {
                StorageManager = new Lazy<PartitionManager>(() => partitionManager, LazyThreadSafetyMode.PublicationOnly)
            };

            // ownership should start empty
            var completeOwnership = await partitionManager.ListOwnershipAsync(processor1.FullyQualifiedNamespace, processor1.EventHubName, processor1.ConsumerGroup);
            Assert.AreEqual(0, completeOwnership.Count());

            // start the processor so that the processor claims a random partition until none are left
            await processor1.StartProcessingAsync();
            await processor1.WaitStabilization();

            completeOwnership = await partitionManager.ListOwnershipAsync(processor1.FullyQualifiedNamespace, processor1.EventHubName, processor1.ConsumerGroup);

            // All partitions are owned by Processor1
            Assert.AreEqual(NumberOfPartitions, completeOwnership.Count(p => p.OwnerIdentifier.Equals(processor1.Identifier)));

            // Stopping the processor should relinquish all partition ownerships
            await processor1.StopProcessingAsync();

            completeOwnership = await partitionManager.ListOwnershipAsync(processor1.FullyQualifiedNamespace, processor1.EventHubName, processor1.ConsumerGroup);

            // No partitions are owned by Processor1
            Assert.AreEqual(0, completeOwnership.Count(p => p.OwnerIdentifier.Equals(processor1.Identifier)));

            // start Processor2 so that the processor claims a random partition until none are left
            // All partitions should be immediately claimable even though they were just claimed by the Processor1
            await processor2.StartProcessingAsync();
            await processor2.WaitStabilization();

            completeOwnership = await partitionManager.ListOwnershipAsync(processor1.FullyQualifiedNamespace, processor1.EventHubName, processor1.ConsumerGroup);

            // All partitions are owned by Processor2
            Assert.AreEqual(NumberOfPartitions, completeOwnership.Count(p => p.OwnerIdentifier.Equals(processor2.Identifier)));

            await processor2.StopProcessingAsync();
        }

        [Test]
        public async Task FindAndClaimOwnershipAsync_ClaimsAllClaimablePartitions()
        {
            const int NumberOfPartitions = 3;
            Func<EventHubConnection> connectionFactory = () => new MockConnection();
            var connection = connectionFactory();
            var partitionManager = new MockCheckPointStorage((s) => Console.WriteLine(s));
            var processor = new MockEventProcessorClient(
                Mock.Of<BlobContainerClient>(),
                connectionFactory: connectionFactory,
                numberOfPartitions: NumberOfPartitions,
                options: default)
            {
                StorageManager = new Lazy<PartitionManager>(() => partitionManager, LazyThreadSafetyMode.PublicationOnly)
            };

            // ownership should start empty
            var completeOwnership = await partitionManager.ListOwnershipAsync(processor.FullyQualifiedNamespace, processor.EventHubName, processor.ConsumerGroup);
            Assert.AreEqual(0, completeOwnership.Count());

            // start the processor so that the processor claims a random partition until none are left
            await processor.StartProcessingAsync();
            await processor.WaitStabilization();

            completeOwnership = await partitionManager.ListOwnershipAsync(processor.FullyQualifiedNamespace, processor.EventHubName, processor.ConsumerGroup);

            Assert.AreEqual(NumberOfPartitions, completeOwnership.Count());

            await processor.StopProcessingAsync();
        }

        [Test]
        public async Task FindAndClaimOwnershipAsync_ClaimsPartitions_WhenOwned_Equals_MinimumOwnedPartitionsCount()
        {
            const int minimumParitionCount = 4;
            const int NumberOfPartitions = 13;
            Func<EventHubConnection> connectionFactory = () => new MockConnection();
            MockConnection connection = connectionFactory() as MockConnection;
            var partitionManager = new MockCheckPointStorage((s) => Console.WriteLine(s));
            var processor = new MockEventProcessorClient(
                Mock.Of<BlobContainerClient>(),
                connectionFactory: connectionFactory,
                numberOfPartitions: NumberOfPartitions,
                options: default)
            {
                StorageManager = new Lazy<PartitionManager>(() => partitionManager, LazyThreadSafetyMode.PublicationOnly)
            };

            Console.WriteLine($"Processor1 = {processor.Identifier}");

            // create partitions owned by this Processor
            var processor1PartitionIds = Enumerable.Range(1, minimumParitionCount);
            var completeOwnership = processor.CreatePartitionOwnerships(processor1PartitionIds.Select(i => i.ToString()), processor.Identifier);

            // create partitions owned by a different Processor
            var Processor2Id = Guid.NewGuid().ToString();
            var processor2PartitionIds = Enumerable.Range(processor1PartitionIds.Max() + 1, minimumParitionCount);
            completeOwnership = completeOwnership
                .Concat(processor.CreatePartitionOwnerships(processor2PartitionIds.Select(i => i.ToString()), Processor2Id));

            // create partitions owned by a different Processor
            var Processor3Id = Guid.NewGuid().ToString();
            var processor3PartitionIds = Enumerable.Range(processor2PartitionIds.Max() + 1, minimumParitionCount);
            completeOwnership = completeOwnership
                .Concat(processor.CreatePartitionOwnerships(processor3PartitionIds.Select(i => i.ToString()), Processor3Id));

            // seed the partitionManager with all partitions
            await partitionManager.ClaimOwnershipAsync(completeOwnership);

            var consumerClient = processor.CreateConsumer(processor.ConsumerGroup, connection, default);

            var claimablePartitionIds = (await consumerClient.GetPartitionIdsAsync())
                                            .Except(completeOwnership.Select(p => p.PartitionId));

            // get owned partitions
            var totalOwnedPartitions = await partitionManager.ListOwnershipAsync(processor.FullyQualifiedNamespace, processor.EventHubName, processor.ConsumerGroup);
            var ownedByProcessor1 = totalOwnedPartitions
                                        .Where(p => p.OwnerIdentifier == processor.Identifier);

            // verify owned partitionIds match the owned partitions
            Assert.AreEqual(minimumParitionCount, ownedByProcessor1.Count());
            Assert.IsFalse(ownedByProcessor1.Any(owned => claimablePartitionIds.Contains(owned.PartitionId)));

            // start the processor to claim owership from of a Partition even though ownedPartitionCount == minimumOwnedPartitionsCount
            await processor.StartProcessingAsync();
            await processor.WaitStabilization();

            // get owned partitions
            totalOwnedPartitions = await partitionManager.ListOwnershipAsync(processor.FullyQualifiedNamespace, processor.EventHubName, processor.ConsumerGroup);
            ownedByProcessor1 = totalOwnedPartitions
                                        .Where(p => p.OwnerIdentifier == processor.Identifier);

            //verify that we took ownership of the additional partition
            Assert.Greater(ownedByProcessor1.Count(), minimumParitionCount);
            Assert.IsTrue(ownedByProcessor1.Any(owned => claimablePartitionIds.Contains(owned.PartitionId)));

            await processor.StopProcessingAsync();
        }

        [Test]
        public async Task FindAndClaimOwnershipAsync_StealsPartitions_WhenThisProcessor_OwnsMinPartitions_AndOtherProcessorOwnsGreatherThanMaxPartitions()
        {
            const int minimumParitionCount = 4;
            const int maximumParitionCount = 5;
            const int NumberOfPartitions = 14;
            Func<EventHubConnection> connectionFactory = () => new MockConnection();
            MockConnection connection = connectionFactory() as MockConnection;
            var partitionManager = new MockCheckPointStorage((s) => Console.WriteLine(s));
            var processor = new MockEventProcessorClient(
                Mock.Of<BlobContainerClient>(),
                connectionFactory: connectionFactory,
                numberOfPartitions: NumberOfPartitions,
                options: default)
            {
                StorageManager = new Lazy<PartitionManager>(() => partitionManager, LazyThreadSafetyMode.PublicationOnly)
            };

            // create partitions owned by this Processor
            var processor1PartitionIds = Enumerable.Range(1, minimumParitionCount);
            var completeOwnership = processor.CreatePartitionOwnerships(processor1PartitionIds.Select(i => i.ToString()), processor.Identifier);

            // create partitions owned by a different Processor
            var Processor2Id = Guid.NewGuid().ToString();
            var processor2PartitionIds = Enumerable.Range(processor1PartitionIds.Max() + 1, minimumParitionCount);
            completeOwnership = completeOwnership
                .Concat(processor.CreatePartitionOwnerships(processor2PartitionIds.Select(i => i.ToString()), Processor2Id));

            // create partitions owned by a different Processor above the maximumPartitionCount
            var Processor3Id = Guid.NewGuid().ToString();
            var stealablePartitionIds = Enumerable.Range(processor2PartitionIds.Max() + 1, maximumParitionCount + 1);
            completeOwnership = completeOwnership
                .Concat(processor.CreatePartitionOwnerships(stealablePartitionIds.Select(i => i.ToString()), Processor3Id));

            // seed the partitionManager with the owned partitions
            await partitionManager.ClaimOwnershipAsync(completeOwnership);

            // get owned partitions
            var totalOwnedPartitions = await partitionManager.ListOwnershipAsync(processor.FullyQualifiedNamespace, processor.EventHubName, processor.ConsumerGroup);
            var ownedByProcessor1 = totalOwnedPartitions
                                        .Where(p => p.OwnerIdentifier == processor.Identifier);
            var ownedByProcessor3 = totalOwnedPartitions
                                        .Where(p => p.OwnerIdentifier == Processor3Id);

            // verify owned partitionIds match the owned partitions
            Assert.IsFalse(ownedByProcessor1.Any(owned => stealablePartitionIds.Contains(int.Parse(owned.PartitionId))));

            //verify processor 3 has stealable partitions
            Assert.Greater(ownedByProcessor3.Count(), maximumParitionCount);

            // start the processor to steal owership from of a when ownedPartitionCount == minimumOwnedPartitionsCount but a processor owns > maximumPartitionCount
            await processor.StartProcessingAsync();
            await processor.WaitStabilization();

            // get owned partitions
            totalOwnedPartitions = await partitionManager.ListOwnershipAsync(processor.FullyQualifiedNamespace, processor.EventHubName, processor.ConsumerGroup);
            ownedByProcessor1 = totalOwnedPartitions
                .Where(p => p.OwnerIdentifier == processor.Identifier);
            ownedByProcessor3 = totalOwnedPartitions
                .Where(p => p.OwnerIdentifier == Processor3Id);

            //verify that we took ownership of the additional partition
            Assert.IsTrue(ownedByProcessor1.Any(owned => stealablePartitionIds.Contains(int.Parse(owned.PartitionId))));

            //verify processor 3 now does not own > maximumPartitionCount
            Assert.AreEqual(maximumParitionCount, ownedByProcessor3.Count());

            await processor.StopProcessingAsync();
        }

        [Test]
        public async Task FindAndClaimOwnershipAsync_StealsPartitions_WhenThisProcessor_OwnsLessThanMinPartitions_AndOtherProcessor_OwnsMaxPartitions()
        {
            const int minimumParitionCount = 4;
            const int maximumParitionCount = 5;
            const int NumberOfPartitions = 12;
            Func<EventHubConnection> connectionFactory = () => new MockConnection();
            MockConnection connection = connectionFactory() as MockConnection;
            var partitionManager = new MockCheckPointStorage((s) => Console.WriteLine(s));
            var processor = new MockEventProcessorClient(
                Mock.Of<BlobContainerClient>(),
                connectionFactory: connectionFactory,
                numberOfPartitions: NumberOfPartitions,
                options: default)
            {
                StorageManager = new Lazy<PartitionManager>(() => partitionManager, LazyThreadSafetyMode.PublicationOnly)
            };

            // create more partitions owned by this Processor
            var processor1PartitionIds = Enumerable.Range(1, minimumParitionCount - 1);
            var completeOwnership = processor.CreatePartitionOwnerships(processor1PartitionIds.Select(i => i.ToString()), processor.Identifier);

            // create more partitions owned by a different Processor
            var Processor2Id = Guid.NewGuid().ToString();
            var processor2PartitionIds = Enumerable.Range(processor1PartitionIds.Max() + 1, minimumParitionCount);
            completeOwnership = completeOwnership
                .Concat(processor.CreatePartitionOwnerships(processor2PartitionIds.Select(i => i.ToString()), Processor2Id));

            // create more partitions owned by a different Processor above the maximumPartitionCount
            var Processor3Id = Guid.NewGuid().ToString();
            var stealablePartitionIds = Enumerable.Range(processor2PartitionIds.Max() + 1, maximumParitionCount);
            completeOwnership = completeOwnership
                .Concat(processor.CreatePartitionOwnerships(stealablePartitionIds.Select(i => i.ToString()), Processor3Id));

            // seed the partitionManager with the owned partitions
            await partitionManager.ClaimOwnershipAsync(completeOwnership);

            // get owned partitions
            var totalOwnedPartitions = await partitionManager.ListOwnershipAsync(processor.FullyQualifiedNamespace, processor.EventHubName, processor.ConsumerGroup);
            var ownedByProcessor1 = totalOwnedPartitions
                                        .Where(p => p.OwnerIdentifier == processor.Identifier);
            var ownedByProcessor3 = totalOwnedPartitions
                                        .Where(p => p.OwnerIdentifier == Processor3Id);

            // verify owned partitionIds match the owned partitions
            Assert.IsFalse(ownedByProcessor1.Any(owned => stealablePartitionIds.Contains(int.Parse(owned.PartitionId))));

            //verify processor 3 has stealable partitions
            Assert.AreEqual(maximumParitionCount, ownedByProcessor3.Count());

            // start the processor to steal owership from of a when ownedPartitionCount == minimumOwnedPartitionsCount but a processor owns > maximumPartitionCount
            await processor.StartProcessingAsync();
            await processor.WaitStabilization();

            // get owned partitions
            totalOwnedPartitions = await partitionManager.ListOwnershipAsync(processor.FullyQualifiedNamespace, processor.EventHubName, processor.ConsumerGroup);
            ownedByProcessor1 = totalOwnedPartitions
                .Where(p => p.OwnerIdentifier == processor.Identifier);
            ownedByProcessor3 = totalOwnedPartitions
                .Where(p => p.OwnerIdentifier == Processor3Id);

            //verify that we took ownership of the additional partition
            Assert.IsTrue(ownedByProcessor1.Any(owned => stealablePartitionIds.Contains(int.Parse(owned.PartitionId))));

            //verify processor 3 now does not own > maximumPartitionCount
            Assert.Less(ownedByProcessor3.Count(), maximumParitionCount);

            await processor.StopProcessingAsync();
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
        ///   Serves as a non-functional connection for testing consumer functionality.
        /// </summary>
        ///
        internal class MockConnection : EventHubConnection
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

        internal class MockEventHubProperties : EventHubProperties
        {
            public MockEventHubProperties(string name,
                                              DateTimeOffset createdOn,
                                              string[] partitionIds) : base(name, createdOn, partitionIds)
            { }

        }
    }
}
