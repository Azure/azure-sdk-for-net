// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        ///   Verifies functionality of the <see cref="EventProcessorClient.StartAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task StartAsyncStartsTheEventProcessorWhenProcessingHandlerPropertiesAreSet()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<PartitionManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default) { CallBase = true };

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
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> properties.
        /// </summary>
        ///
        [Test]
        public void CannotAddNullHandler()
        {
            var processor = new EventProcessorClient(Mock.Of<PartitionManager>(), "consumerGroup", "namespace", "eventHub", () => new MockConnection(), default);

            Assert.That(() => processor.PartitionInitializingAsync += null, Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => processor.PartitionClosingAsync += null, Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => processor.ProcessEventAsync += null, Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => processor.ProcessErrorAsync += null, Throws.InstanceOf<ArgumentNullException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> properties.
        /// </summary>
        ///
        [Test]
        public void CannotAddTwoHandlersToTheSameEvent()
        {
            var processor = new EventProcessorClient(Mock.Of<PartitionManager>(), "consumerGroup", "namespace", "eventHub", () => new MockConnection(), default);

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
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> properties.
        /// </summary>
        ///
        [Test]
        public void CannotRemoveHandlerThatHasNotBeenAdded()
        {
            var processor = new EventProcessorClient(Mock.Of<PartitionManager>(), "consumerGroup", "namespace", "eventHub", () => new MockConnection(), default);

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
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> properties.
        /// </summary>
        ///
        [Test]
        public void CanRemoveHandlerThatHasBeenAdded()
        {
            var processor = new EventProcessorClient(Mock.Of<PartitionManager>(), "consumerGroup", "namespace", "eventHub", () => new MockConnection(), default);

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
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> properties.
        /// </summary>
        ///
        [Test]
        public async Task CannotAddHandlerWhileProcessorIsRunning()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<PartitionManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default) { CallBase = true };

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
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> properties.
        /// </summary>
        ///
        [Test]
        public async Task CannotRemoveHandlerWhileProcessorIsRunning()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<PartitionManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default) { CallBase = true };

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
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> properties.
        /// </summary>
        ///
        [Test]
        public async Task IsRunningReturnsTrueWhileStopProcessingAsyncIsNotCalled()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<PartitionManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default) { CallBase = true };

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
        ///   Verifies functionality of the <see cref="EventProcessorClient" /> properties.
        /// </summary>
        ///
        [Test]
        public async Task IsRunningReturnsFalseWhenLoadBalancingTaskFails()
        {
            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<PartitionManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default) { CallBase = true };
            var completionSource = new TaskCompletionSource<bool>();

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

            using var cancellationSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));

            Assert.That(async () => await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token), Throws.Nothing);
            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);

            mockLog.Verify(m => m.EventProcessorStart(mockProcessor.Object.Identifier));
            mockLog.Verify(m => m.RenewOwnershipStart(mockProcessor.Object.Identifier));
            mockLog.Verify(m => m.RenewOwnershipComplete(mockProcessor.Object.Identifier));
            mockLog.Verify(m => m.MinimumPartitionsPerEventProcessor(1));
            mockLog.Verify(m => m.ClaimOwnershipStart(partitionIds[0]));
            mockLog.Verify(m => m.EventProcessorStopStart(mockProcessor.Object.Identifier));
            mockLog.Verify(m => m.EventProcessorStopComplete(mockProcessor.Object.Identifier));
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

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            var completionSource = new TaskCompletionSource<bool>();

            mockProcessor.Object.ProcessErrorAsync += async eventArgs =>
            {
                await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);
                completionSource.SetResult(true);
            };

            // Start the processor and wait for the event handler to be triggered.

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
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

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));


            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            await completionSource.Task;
            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);

            // Validate the empty event arguments.

            Assert.That(emptyEventArgs, Is.Not.Null, "The event arguments should have been populated.");
            Assert.That(emptyEventArgs.Data, Is.Null, "The event arguments should not have an event available.");
            Assert.That(emptyEventArgs.Partition, Is.Not.Null, "The event arguments should have a partition context.");
            Assert.That(emptyEventArgs.Partition.PartitionId, Is.EqualTo(partitionId), "The partition identifier should match.");
            Assert.That(() => emptyEventArgs.Partition.ReadLastEnqueuedEventProperties(), Throws.InstanceOf<InvalidOperationException>(), "The last event properties should not be available.");
        }

        /// <summary>
        ///   Verifies that partitions owned by an <see cref="EventProcessorClient" /> are immediately available to be claimed by another processor
        ///   after <see cref="StopProcessingAsync" /> is called.
        /// </summary>
        ///
        [Test]
        public async Task StoppedClientRelinquishesPartitionOwnershipOtherClientsConsiderThemClaimableImmediately()
        {
            const int NumberOfPartitions = 3;
            Func<EventHubConnection> connectionFactory = () => new MockConnection();
            var connection = connectionFactory();
            var partitionManager = new MockCheckPointStorage((s) => Console.WriteLine(s));
            var processor1 = new MockEventProcessorClient(
                partitionManager,
                connectionFactory: connectionFactory,
                numberOfPartitions: NumberOfPartitions,
                clientOptions: default);
            var processor2 = new MockEventProcessorClient(
                partitionManager,
                connectionFactory: connectionFactory,
                numberOfPartitions: NumberOfPartitions,
                clientOptions: default);

            // Establish timed cancellation to ensure that the test doesn't hang.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(45));

            // Ownership should start empty.

            var completeOwnership = await partitionManager.ListOwnershipAsync(processor1.FullyQualifiedNamespace, processor1.EventHubName, processor1.ConsumerGroup, cancellationSource.Token);
            Assert.That(completeOwnership.Any(), Is.False);

            // Start the processor so that the processor claims a random partition until none are left.

            await processor1.StartProcessingAsync(cancellationSource.Token);
            await processor1.WaitStabilization();

            completeOwnership = await partitionManager.ListOwnershipAsync(processor1.FullyQualifiedNamespace, processor1.EventHubName, processor1.ConsumerGroup, cancellationSource.Token);

            // All partitions are owned by Processor1.

            Assert.That(completeOwnership.Count(p => p.OwnerIdentifier.Equals(processor1.Identifier)), Is.EqualTo(NumberOfPartitions));

            // Stopping the processor should relinquish all partition ownership.

            await processor1.StopProcessingAsync(cancellationSource.Token);

            completeOwnership = await partitionManager.ListOwnershipAsync(processor1.FullyQualifiedNamespace, processor1.EventHubName, processor1.ConsumerGroup, cancellationSource.Token);

            // No partitions are owned by Processor1.

            Assert.That(completeOwnership.Count(p => p.OwnerIdentifier.Equals(processor1.Identifier)), Is.EqualTo(0));

            // Start Processor2 so that the processor claims a random partition until none are left.
            // All partitions should be immediately claimable even though they were just claimed by the Processor1.

            await processor2.StartProcessingAsync(cancellationSource.Token);
            await processor2.WaitStabilization();

            completeOwnership = await partitionManager.ListOwnershipAsync(processor1.FullyQualifiedNamespace, processor1.EventHubName, processor1.ConsumerGroup, cancellationSource.Token);

            // All partitions are owned by Processor2.

            Assert.That(completeOwnership.Count(p => p.OwnerIdentifier.Equals(processor2.Identifier)), Is.EqualTo(NumberOfPartitions));

            await processor2.StopProcessingAsync(cancellationSource.Token);
        }

        /// <summary>
        ///   Verifies that claimable partitions are claimed by an <see cref="EventProcessorClient" /> after <see cref="StartProcessingAsync" /> is called.
        /// </summary>
        ///
        [Test]
        public async Task FindAndClaimOwnershipAsyncClaimsAllClaimablePartitions()
        {
            const int NumberOfPartitions = 3;
            Func<EventHubConnection> connectionFactory = () => new MockConnection();
            var connection = connectionFactory();
            var partitionManager = new MockCheckPointStorage((s) => Console.WriteLine(s));
            var processor = new MockEventProcessorClient(
                partitionManager,
                connectionFactory: connectionFactory,
                numberOfPartitions: NumberOfPartitions,
                clientOptions: default);

            // Establish timed cancellation to ensure that the test doesn't hang.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            // ownership should start empty.

            var completeOwnership = await partitionManager.ListOwnershipAsync(processor.FullyQualifiedNamespace, processor.EventHubName, processor.ConsumerGroup, cancellationSource.Token);
            Assert.That(completeOwnership.Count(), Is.EqualTo(0));

            // Start the processor so that the processor claims a random partition until none are left.

            await processor.StartProcessingAsync(cancellationSource.Token);
            await processor.WaitStabilization();

            completeOwnership = await partitionManager.ListOwnershipAsync(processor.FullyQualifiedNamespace, processor.EventHubName, processor.ConsumerGroup);

            Assert.That(completeOwnership.Count(), Is.EqualTo(NumberOfPartitions));

            await processor.StopProcessingAsync(cancellationSource.Token);
        }

        /// <summary>
        ///   Verifies that partitions ownership load balancing will direct an <see cref="EventProcessorClient" /> to claim ownership of a claimable partition
        ///   when it owns exactly the calculated MinimumOwnedPartitionsCount.
        /// </summary>
        ///
        [Test]
        public async Task FindAndClaimOwnershipAsyncClaimsPartitionsWhenOwnedEqualsMinimumOwnedPartitionsCount()
        {
            const int MinimumpartitionCount = 4;
            const int NumberOfPartitions = 13;
            Func<EventHubConnection> connectionFactory = () => new MockConnection();
            MockConnection connection = connectionFactory() as MockConnection;
            var partitionManager = new MockCheckPointStorage((s) => Console.WriteLine(s));
            var processor = new MockEventProcessorClient(
                partitionManager,
                connectionFactory: connectionFactory,
                numberOfPartitions: NumberOfPartitions,
                clientOptions: default);

            // Establish timed cancellation to ensure that the test doesn't hang.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(45));

            // Create partitions owned by this Processor.

            var processor1PartitionIds = Enumerable.Range(1, MinimumpartitionCount);
            var completeOwnership = processor.CreatePartitionOwnership(processor1PartitionIds.Select(i => i.ToString()), processor.Identifier);

            // Create partitions owned by a different Processor.

            var Processor2Id = Guid.NewGuid().ToString();
            var processor2PartitionIds = Enumerable.Range(processor1PartitionIds.Max() + 1, MinimumpartitionCount);
            completeOwnership = completeOwnership
                .Concat(processor.CreatePartitionOwnership(processor2PartitionIds.Select(i => i.ToString()), Processor2Id));

            // Create partitions owned by a different Processor.

            var Processor3Id = Guid.NewGuid().ToString();
            var processor3PartitionIds = Enumerable.Range(processor2PartitionIds.Max() + 1, MinimumpartitionCount);
            completeOwnership = completeOwnership
                .Concat(processor.CreatePartitionOwnership(processor3PartitionIds.Select(i => i.ToString()), Processor3Id));

            // Seed the partitionManager with all partitions.

            await partitionManager.ClaimOwnershipAsync(completeOwnership, cancellationSource.Token);

            var consumerClient = processor.CreateConsumer(processor.ConsumerGroup, connection, default);

            var claimablePartitionIds = (await consumerClient.GetPartitionIdsAsync())
                                            .Except(completeOwnership.Select(p => p.PartitionId));

            // Get owned partitions.

            var totalOwnedPartitions = await partitionManager.ListOwnershipAsync(processor.FullyQualifiedNamespace, processor.EventHubName, processor.ConsumerGroup, cancellationSource.Token);
            var ownedByProcessor1 = totalOwnedPartitions.Where(p => p.OwnerIdentifier == processor.Identifier);

            // Verify owned partitionIds match the owned partitions.

            Assert.That(ownedByProcessor1.Count(), Is.EqualTo(MinimumpartitionCount));
            Assert.That(ownedByProcessor1.Any(owned => claimablePartitionIds.Contains(owned.PartitionId)), Is.False);

            // Start the processor to claim ownership from of a Partition even though ownedPartitionCount == MinimumOwnedPartitionsCount.

            await processor.StartProcessingAsync(cancellationSource.Token);
            await processor.WaitStabilization();

            // Get owned partitions.

            totalOwnedPartitions = await partitionManager.ListOwnershipAsync(processor.FullyQualifiedNamespace, processor.EventHubName, processor.ConsumerGroup, cancellationSource.Token);
            ownedByProcessor1 = totalOwnedPartitions.Where(p => p.OwnerIdentifier == processor.Identifier);

            // Verify that we took ownership of the additional partition.

            Assert.That(ownedByProcessor1.Count(), Is.GreaterThan(MinimumpartitionCount));
            Assert.That(ownedByProcessor1.Any(owned => claimablePartitionIds.Contains(owned.PartitionId)), Is.True);

            await processor.StopProcessingAsync(cancellationSource.Token);
        }

        /// <summary>
        ///   Verifies that partitions ownership load balancing will direct an <see cref="EventProcessorClient" /> steal ownership of a partition
        ///   from another <see cref="EventProcessorClient" /> the other processor owns greater than the calculated MaximumOwnedPartitionsCount.
        /// </summary>
        ///
        [Test]
        public async Task FindAndClaimOwnershipAsyncStealsPartitionsWhenThisProcessorOwnsMinPartitionsAndOtherProcessorOwnsGreatherThanMaxPartitions()
        {
            const int MinimumpartitionCount = 4;
            const int MaximumpartitionCount = 5;
            const int NumberOfPartitions = 14;
            Func<EventHubConnection> connectionFactory = () => new MockConnection();
            MockConnection connection = connectionFactory() as MockConnection;
            var partitionManager = new MockCheckPointStorage((s) => Console.WriteLine(s));
            var processor = new MockEventProcessorClient(
                partitionManager,
                connectionFactory: connectionFactory,
                numberOfPartitions: NumberOfPartitions,
                clientOptions: default);

            // Establish timed cancellation to ensure that the test doesn't hang.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            // Create partitions owned by this Processor.

            var processor1PartitionIds = Enumerable.Range(1, MinimumpartitionCount);
            var completeOwnership = processor.CreatePartitionOwnership(processor1PartitionIds.Select(i => i.ToString()), processor.Identifier);

            // Create partitions owned by a different Processor.

            var Processor2Id = Guid.NewGuid().ToString();
            var processor2PartitionIds = Enumerable.Range(processor1PartitionIds.Max() + 1, MinimumpartitionCount);
            completeOwnership = completeOwnership
                .Concat(processor.CreatePartitionOwnership(processor2PartitionIds.Select(i => i.ToString()), Processor2Id));

            // Create partitions owned by a different Processor above the MaximumPartitionCount.

            var Processor3Id = Guid.NewGuid().ToString();
            var stealablePartitionIds = Enumerable.Range(processor2PartitionIds.Max() + 1, MaximumpartitionCount + 1);
            completeOwnership = completeOwnership
                .Concat(processor.CreatePartitionOwnership(stealablePartitionIds.Select(i => i.ToString()), Processor3Id));

            // Seed the partitionManager with the owned partitions.

            await partitionManager.ClaimOwnershipAsync(completeOwnership, cancellationSource.Token);

            // Get owned partitions.

            var totalOwnedPartitions = await partitionManager.ListOwnershipAsync(processor.FullyQualifiedNamespace, processor.EventHubName, processor.ConsumerGroup, cancellationSource.Token);
            var ownedByProcessor1 = totalOwnedPartitions.Where(p => p.OwnerIdentifier == processor.Identifier);
            var ownedByProcessor3 = totalOwnedPartitions.Where(p => p.OwnerIdentifier == Processor3Id);

            // Verify owned partitionIds match the owned partitions.

            Assert.That(ownedByProcessor1.Any(owned => stealablePartitionIds.Contains(int.Parse(owned.PartitionId))), Is.False);

            // Verify processor 3 has stealable partitions.

            Assert.That(ownedByProcessor3.Count(), Is.GreaterThan(MaximumpartitionCount));

            // Start the processor to steal ownership from of a when ownedPartitionCount == MinimumOwnedPartitionsCount but a processor owns > MaximumPartitionCount.

            await processor.StartProcessingAsync(cancellationSource.Token);
            await processor.WaitStabilization();

            // Get owned partitions.

            totalOwnedPartitions = await partitionManager.ListOwnershipAsync(processor.FullyQualifiedNamespace, processor.EventHubName, processor.ConsumerGroup);
            ownedByProcessor1 = totalOwnedPartitions.Where(p => p.OwnerIdentifier == processor.Identifier);
            ownedByProcessor3 = totalOwnedPartitions.Where(p => p.OwnerIdentifier == Processor3Id);

            // Verify that we took ownership of the additional partition.

            Assert.That(ownedByProcessor1.Any(owned => stealablePartitionIds.Contains(int.Parse(owned.PartitionId))), Is.True);

            // Verify processor 3 now does not own > MaximumPartitionCount.

            Assert.That(ownedByProcessor3.Count(), Is.EqualTo(MaximumpartitionCount));

            await processor.StopProcessingAsync(cancellationSource.Token);
        }

        /// <summary>
        ///   Verifies that partitions ownership load balancing will direct an <see cref="EventProcessorClient" /> steal ownership of a partition
        ///   from another <see cref="EventProcessorClient" /> the other processor owns exactly the calculated MaximumOwnedPartitionsCount.
        /// </summary>
        ///
        [Test]
        public async Task FindAndClaimOwnershipAsyncStealsPartitionsWhenThisProcessorOwnsLessThanMinPartitionsAndOtherProcessorOwnsMaxPartitions()
        {
            const int MinimumpartitionCount = 4;
            const int MaximumpartitionCount = 5;
            const int NumberOfPartitions = 12;
            Func<EventHubConnection> connectionFactory = () => new MockConnection();
            MockConnection connection = connectionFactory() as MockConnection;
            var partitionManager = new MockCheckPointStorage((s) => Console.WriteLine(s));
            var processor = new MockEventProcessorClient(
                partitionManager,
                connectionFactory: connectionFactory,
                numberOfPartitions: NumberOfPartitions,
                clientOptions: default);

            // Establish timed cancellation to ensure that the test doesn't hang.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            // Create more partitions owned by this Processor.

            var processor1PartitionIds = Enumerable.Range(1, MinimumpartitionCount - 1);
            var completeOwnership = processor.CreatePartitionOwnership(processor1PartitionIds.Select(i => i.ToString()), processor.Identifier);

            // Create more partitions owned by a different Processor.

            var Processor2Id = Guid.NewGuid().ToString();
            var processor2PartitionIds = Enumerable.Range(processor1PartitionIds.Max() + 1, MinimumpartitionCount);
            completeOwnership = completeOwnership
                .Concat(processor.CreatePartitionOwnership(processor2PartitionIds.Select(i => i.ToString()), Processor2Id));

            // Create more partitions owned by a different Processor above the MaximumPartitionCount.

            var Processor3Id = Guid.NewGuid().ToString();
            var stealablePartitionIds = Enumerable.Range(processor2PartitionIds.Max() + 1, MaximumpartitionCount);
            completeOwnership = completeOwnership
                .Concat(processor.CreatePartitionOwnership(stealablePartitionIds.Select(i => i.ToString()), Processor3Id));

            // Seed the partitionManager with the owned partitions.

            await partitionManager.ClaimOwnershipAsync(completeOwnership);

            // Get owned partitions.

            var totalOwnedPartitions = await partitionManager.ListOwnershipAsync(processor.FullyQualifiedNamespace, processor.EventHubName, processor.ConsumerGroup, cancellationSource.Token);
            var ownedByProcessor1 = totalOwnedPartitions.Where(p => p.OwnerIdentifier == processor.Identifier);
            var ownedByProcessor3 = totalOwnedPartitions.Where(p => p.OwnerIdentifier == Processor3Id);

            // Verify owned partitionIds match the owned partitions.

            Assert.That(ownedByProcessor1.Any(owned => stealablePartitionIds.Contains(int.Parse(owned.PartitionId))), Is.False);

            // Verify processor 3 has stealable partitions.

            Assert.That(ownedByProcessor3.Count(), Is.EqualTo(MaximumpartitionCount));

            // Start the processor to steal ownership from of a when ownedPartitionCount == MinimumOwnedPartitionsCount but a processor owns > MaximumPartitionCount.

            await processor.StartProcessingAsync(cancellationSource.Token);
            await processor.WaitStabilization();

            // Get owned partitions.

            totalOwnedPartitions = await partitionManager.ListOwnershipAsync(processor.FullyQualifiedNamespace, processor.EventHubName, processor.ConsumerGroup, cancellationSource.Token);
            ownedByProcessor1 = totalOwnedPartitions.Where(p => p.OwnerIdentifier == processor.Identifier);
            ownedByProcessor3 = totalOwnedPartitions.Where(p => p.OwnerIdentifier == Processor3Id);

            // Verify that we took ownership of the additional partition.

            Assert.That(ownedByProcessor1.Any(owned => stealablePartitionIds.Contains(int.Parse(owned.PartitionId))), Is.True);

            // Verify processor 3 now does not own > MaximumPartitionCount.

            Assert.That(ownedByProcessor3.Count(), Is.LessThan(MaximumpartitionCount));

            await processor.StopProcessingAsync(cancellationSource.Token);
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
            var mockProcessor = new Mock<EventProcessorClient>(mockStorage, consumerGroup, fqNamespace, eventHub, Mock.Of<Func<EventHubConnection>>(), default) { CallBase = true };
            var completionSource = new TaskCompletionSource<bool>();

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

            mockProcessor
                .Setup(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<EventHubConnection>(),
                    It.IsAny<EventHubConsumerClientOptions>()))
                .Returns(mockConsumer.Object);

            mockProcessor.Object.ProcessEventAsync += eventArgs => Task.CompletedTask;
            mockProcessor.Object.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            // Start processing and wait for the consumer to be invoked.  Set a cancellation for backup to ensure
            // that the test completes deterministically.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            await Task.WhenAny(Task.Delay(-1, cancellationSource.Token), completionSource.Task);
            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);

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
            var mockProcessor = new Mock<EventProcessorClient>(mockStorage, consumerGroup, fqNamespace, eventHub, Mock.Of<Func<EventHubConnection>>(), default) { CallBase = true };
            var completionSource = new TaskCompletionSource<bool>();

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

            mockProcessor
                .Setup(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<EventHubConnection>(),
                    It.IsAny<EventHubConsumerClientOptions>()))
                .Returns(mockConsumer.Object);

            mockProcessor.Object.ProcessEventAsync += eventArgs => Task.CompletedTask;
            mockProcessor.Object.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            mockProcessor.Object.PartitionInitializingAsync += eventArgs =>
            {
                eventArgs.DefaultStartingPosition = defaultPosition;
                return Task.CompletedTask;
            };

            // Start processing and wait for the consumer to be invoked.  Set a cancellation for backup to ensure
            // that the test completes deterministically.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            await Task.WhenAny(Task.Delay(-1, cancellationSource.Token), completionSource.Task);
            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);

            // Validate that the consumer was invoked and that cancellation did not take place.

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");
            mockConsumer.VerifyAll();

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.StartProcessingAsync(CancellationToken)" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void AlreadyCancelledTokenMakesStartProcessingAsyncThrow()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<PartitionManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default) { CallBase = true };

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
        ///   Verifies functionality of the <see cref="EventProcessorClient.StopProcessingAsync(CancellationToken)" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task AlreadyCancelledTokenMakesStopProcessingAsyncThrow()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<PartitionManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default) { CallBase = true };

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
        ///   Verifies functionality of the <see cref="EventProcessorClient.StartProcessing(CancellationToken)" />
        ///   methods.
        /// </summary>
        ///
        [Test]
        public void AlreadyCancelledTokenMakesStartProcessingThrow()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<PartitionManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default) { CallBase = true };

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
        ///   Verifies functionality of the <see cref="EventProcessorClient.StopProcessing(CancellationToken)" />
        ///   methods.
        /// </summary>
        ///
        [Test]
        public void AlreadyCancelledTokenMakesStopProcessingThrow()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<PartitionManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default) { CallBase = true };

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
        ///   Verifies functionality of the <see cref="EventProcessorClient.StartProcessing(CancellationToken)" />
        ///   and <see cref="EventProcessorClient.StopProcessing(CancellationToken)" /> methods.
        /// </summary>
        ///
        [Test]
        public void StartAndStopProcessingShouldStartAndStopProcessors()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<PartitionManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default) { CallBase = true };

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
        ///   Verifies functionality of the <see cref="EventProcessorClient.StartProcessingAsync(CancellationToken)" />
        ///   and <see cref="EventProcessorClient.StopProcessingAsync(CancellationToken)" /> methods.
        /// </summary>
        ///
        [Test]
        public async Task SupportsStartProcessingAfterStop()
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
                .Returns<string, EventPosition, ReadEventOptions, CancellationToken>((partition, position, options, token) => MockEmptyPartitionEventEnumerable(1, token));

            mockProcessor
                .Setup(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<EventHubConnection>(),
                    It.IsAny<EventHubConsumerClientOptions>()))
                .Returns(mockConsumer.Object);

            mockProcessor.Object.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            var completionSource = new TaskCompletionSource<bool>();
            var isProcessEventHandlerInvoked = false;

            mockProcessor.Object.ProcessEventAsync += eventArgs =>
            {
                isProcessEventHandlerInvoked = true;
                completionSource.SetResult(true);

                return Task.CompletedTask;
            };

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            Assert.That(mockProcessor.Object.IsRunning, Is.False);

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            await completionSource.Task;

            Assert.That(mockProcessor.Object.IsRunning, Is.True);
            Assert.That(isProcessEventHandlerInvoked, Is.EqualTo(true));

            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);

            isProcessEventHandlerInvoked = false;
            completionSource = new TaskCompletionSource<bool>();

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");
            Assert.That(mockProcessor.Object.IsRunning, Is.False);

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            await completionSource.Task;

            Assert.That(mockProcessor.Object.IsRunning, Is.True);
            Assert.That(isProcessEventHandlerInvoked, Is.EqualTo(true));

            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The processor should have stopped without cancellation.");
            Assert.That(mockProcessor.Object.IsRunning, Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.StopProcessingAsync(CancellationToken)" /> method.
        /// </summary>
        ///
        [Test]
        public async Task StopProcessingShouldSurfaceLoadBalancingException()
        {
            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<PartitionManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default) { CallBase = true };
            var completionSource = new TaskCompletionSource<bool>();

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
        ///   Verifies functionality of the <see cref="EventProcessorClient" />.
        /// </summary>
        ///
        [Test]
        public void ToStingReturnsStringContainingProcessorIdentifier()
        {
            var mockProcessor = new Mock<EventProcessorClient>(Mock.Of<PartitionManager>(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default) { CallBase = true };
            var stringContaingIdentifier = mockProcessor.Object.ToString();

            Assert.That(stringContaingIdentifier.Contains(mockProcessor.Object.Identifier), Is.True, "ToString() should return a string that contains the processor's identifier");
        }

        /// <summary>
        ///   Verifies that processor stops processing partition it doesn't own anymore.
        /// </summary>
        ///
        [Test]
        public async Task ProcessorStopsProcessingParitionItDoesNotOwnAnymore()
        {
            const int NumberOfPartitions = 2;
            Func<EventHubConnection> connectionFactory = () => new MockConnection();
            var connection = connectionFactory();
            var partitionManager = new MockCheckPointStorage((s) => Console.WriteLine(s));
            var processor1 = new MockEventProcessorClient(
                partitionManager,
                connectionFactory: connectionFactory,
                numberOfPartitions: NumberOfPartitions,
                clientOptions: default);
            var processor2 = new MockEventProcessorClient(
                partitionManager,
                connectionFactory: connectionFactory,
                numberOfPartitions: NumberOfPartitions,
                clientOptions: default);

            // Establish timed cancellation to ensure that the test doesn't hang.

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(45));

            // Ownership should start empty.

            var completeOwnership = await partitionManager.ListOwnershipAsync(processor1.FullyQualifiedNamespace, processor1.EventHubName, processor1.ConsumerGroup, cancellationSource.Token);
            Assert.That(completeOwnership.Any(), Is.False);

            // Start the processor so that the processor claims a random partition until none are left.

            await processor1.StartProcessingAsync(cancellationSource.Token);
            await processor1.WaitStabilization();

            completeOwnership = await partitionManager.ListOwnershipAsync(processor1.FullyQualifiedNamespace, processor1.EventHubName, processor1.ConsumerGroup, cancellationSource.Token);

            // All partitions are owned by Processor1.

            Assert.That(completeOwnership.Count(p => p.OwnerIdentifier.Equals(processor1.Identifier)), Is.EqualTo(NumberOfPartitions));

            // Start Processor2 so that the it will steal 1 partition from processor1.

            await processor2.StartProcessingAsync(cancellationSource.Token);
            await processor2.WaitStabilization();

            completeOwnership = await partitionManager.ListOwnershipAsync(processor1.FullyQualifiedNamespace, processor1.EventHubName, processor1.ConsumerGroup, cancellationSource.Token);

            // Now both processors own 1 partition

            Assert.That(completeOwnership.ElementAt(0).OwnerIdentifier, Is.Not.EqualTo(completeOwnership.ElementAt(1).OwnerIdentifier));

            // processor1 stopped processing partition it donesn't own anymore with OwnershipLost reason.

            Assert.That(processor1.StopReasons.Values.First, Is.EqualTo(ProcessingStoppedReason.OwnershipLost));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.ProcessEventAsync" />
        ///   handler UpdateCheckpointAsync method.
        /// </summary>
        ///
        [Test]
        public async Task WhenProcessEventTriggersWithNoDataUpdateCheckpointThrow()
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

                Assert.That(async () => await eventArgs.UpdateCheckpointAsync(), Throws.InstanceOf<InvalidOperationException>(), "An exception should have been thrown When ProcessEventAsync triggers with no data.");

                completionSource.SetResult(true);

                return Task.CompletedTask;
            };

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(30));

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            await completionSource.Task;
            await mockProcessor.Object.StopProcessingAsync(cancellationSource.Token);

            // Validate the empty event arguments.

            Assert.That(emptyEventArgs, Is.Not.Null, "The event arguments should have been populated.");
            Assert.That(emptyEventArgs.Data, Is.Null, "The event arguments should not have an event available.");
            Assert.That(emptyEventArgs.Partition, Is.Not.Null, "The event arguments should have a partition context.");
            Assert.That(emptyEventArgs.Partition.PartitionId, Is.EqualTo(partitionId), "The partition identifier should match.");
            Assert.That(() => emptyEventArgs.Partition.ReadLastEnqueuedEventProperties(), Throws.InstanceOf<InvalidOperationException>(), "The last event properties should not be available.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.ProcessEventAsync" />
        ///   handler UpdateCheckpointAsync method.
        /// </summary>
        ///
        [Test]
        public async Task AlreadyCancelledTokenMakesUpdateCheckpointThrow()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new Mock<EventProcessorClient>(new MockCheckPointStorage(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default) { CallBase = true };

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

            mockProcessor
                .Setup(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<EventHubConnection>(),
                    It.IsAny<EventHubConsumerClientOptions>()))
                .Returns(mockConsumer.Object);

            mockProcessor.Object.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            var completionSource = new TaskCompletionSource<bool>();

            mockProcessor.Object.ProcessEventAsync += eventArgs =>
            {
                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.Cancel();

                Assert.That(async () => await eventArgs.UpdateCheckpointAsync(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());

                completionSource.SetResult(true);

                return Task.CompletedTask;
            };

            await mockProcessor.Object.StartProcessingAsync();
            await completionSource.Task;
            await mockProcessor.Object.StopProcessingAsync();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.ProcessEventAsync" />
        ///   event.
        /// </summary>
        ///
        [Test]
        public async Task ProcessHanderTriggersForEveryReceivedEvent()
        {
            var mockConsumer = new Mock<EventHubConsumerClient>("consumerGroup", Mock.Of<EventHubConnection>(), default);
            var mockProcessor = new Mock<EventProcessorClient>(new MockCheckPointStorage(), "consumerGroup", "namespace", "eventHub", Mock.Of<Func<EventHubConnection>>(), default) { CallBase = true };

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

            mockProcessor
                .Setup(processor => processor.CreateConsumer(
                    It.IsAny<string>(),
                    It.IsAny<EventHubConnection>(),
                    It.IsAny<EventHubConsumerClientOptions>()))
                .Returns(mockConsumer.Object);

            mockProcessor.Object.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            var completionSource = new TaskCompletionSource<bool>();

            var processEventTriggerCount = 0;

            mockProcessor.Object.ProcessEventAsync += eventArgs =>
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

            await mockProcessor.Object.StartProcessingAsync(cancellationSource.Token);
            await completionSource.Task;

            Assert.That(numberOfEvents, Is.EqualTo(processEventTriggerCount));
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
                                  string eventHubName = "fakeEventHub",
                                  EventHubConnectionOptions options = null) : base(namespaceName, eventHubName, CreateCredentials(), options)
            { }

            private static EventHubTokenCredential CreateCredentials()
            {
                return new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net").Object;
            }
        }

        /// <summary>
        ///   Serves as a mock <see cref="EventHubProperties" />.
        /// </summary>
        ///
        private class MockEventHubProperties : EventHubProperties
        {
            public MockEventHubProperties(string name,
                                          DateTimeOffset createdOn,
                                          string[] partitionIds) : base(name, createdOn, partitionIds)
            { }
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
