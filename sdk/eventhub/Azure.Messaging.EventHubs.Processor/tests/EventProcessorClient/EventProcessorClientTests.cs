// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Core;
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
            Assert.That(() => new EventProcessorClient(Mock.Of<PartitionManager>(), consumerGroup, "dummyConnection", new EventProcessorClientOptions()), Throws.InstanceOf<ArgumentException>(), "The connection string constructor should validate the consumer group.");
            Assert.That(() => new EventProcessorClient(Mock.Of<PartitionManager>(), consumerGroup, "dummyNamespace", "dummyEventHub", credential.Object, new EventProcessorClientOptions()), Throws.InstanceOf<ArgumentException>(), "The namespace constructor should validate the consumer group.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessorClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesThePartitionManager()
        {
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net");
            Assert.That(() => new EventProcessorClient(null, "consumerGroup", "dummyConnection", new EventProcessorClientOptions()), Throws.InstanceOf<ArgumentException>(), "The connection string constructor should validate the event processor store.");
            Assert.That(() => new EventProcessorClient(null, "consumerGroup", "dummyNamespace", "dummyEventHub", credential.Object, new EventProcessorClientOptions()), Throws.InstanceOf<ArgumentException>(), "The namespace constructor should validate the event processor store.");
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
            Assert.That(() => new EventProcessorClient(Mock.Of<PartitionManager>(), EventHubConsumerClient.DefaultConsumerGroupName, connectionString), Throws.InstanceOf<ArgumentException>(), "The constructor without options should ensure a connection string.");
            Assert.That(() => new EventProcessorClient(Mock.Of<PartitionManager>(), EventHubConsumerClient.DefaultConsumerGroupName, connectionString, "dummy", new EventProcessorClientOptions()), Throws.InstanceOf<ArgumentException>(), "The constructor with options should ensure a connection string.");
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
            Assert.That(() => new EventProcessorClient(Mock.Of<PartitionManager>(), EventHubConsumerClient.DefaultConsumerGroupName, constructorArgument, "dummy", credential.Object), Throws.InstanceOf<ArgumentException>());
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
            Assert.That(() => new EventProcessorClient(Mock.Of<PartitionManager>(), EventHubConsumerClient.DefaultConsumerGroupName, "namespace", constructorArgument, credential.Object), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheCredential()
        {
            Assert.That(() => new EventProcessorClient(Mock.Of<PartitionManager>(), EventHubConsumerClient.DefaultConsumerGroupName, "namespace", "hubName", default(TokenCredential)), Throws.ArgumentNullException);
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
            var processor = new EventProcessorClient(Mock.Of<PartitionManager>(), EventHubConsumerClient.DefaultConsumerGroupName, connectionString, options);

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
            var processor = new EventProcessorClient(Mock.Of<PartitionManager>(), EventHubConsumerClient.DefaultConsumerGroupName, "namespace", "hubName", credential.Object, options);

            Assert.That(GetRetryPolicy(processor), Is.SameAs(expected));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessorClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorCreatesTheIdentifier()
        {
            var eventProcessor = new EventProcessorClient(Mock.Of<PartitionManager>(), "consumerGroup", "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub");

            Assert.That(eventProcessor.Identifier, Is.Not.Null);
            Assert.That(eventProcessor.Identifier, Is.Not.Empty);
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessorClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void NamespaceConstructorCreatesTheIdentifier()
        {
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net");
            var eventProcessor = new EventProcessorClient(Mock.Of<PartitionManager>(), "consumerGroup", "namespace", "hub", credential.Object);

            Assert.That(eventProcessor.Identifier, Is.Not.Null);
            Assert.That(eventProcessor.Identifier, Is.Not.Empty);
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessorClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorCopiesTheIdentifier()
        {
            var clientOptions = new EventProcessorClientOptions { Identifier = Guid.NewGuid().ToString() };
            var eventProcessor = new EventProcessorClient(Mock.Of<PartitionManager>(), "consumerGroup", "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub", clientOptions);

            Assert.That(eventProcessor.Identifier, Is.EqualTo(clientOptions.Identifier));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessorClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void NamespaceConstructorCopiesTheIdentifier()
        {
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net");
            var clientOptions = new EventProcessorClientOptions { Identifier = Guid.NewGuid().ToString() };
            var eventProcessor = new EventProcessorClient(Mock.Of<PartitionManager>(), "consumerGroup", "namespace", "hub", credential.Object, clientOptions);

            Assert.That(eventProcessor.Identifier, Is.EqualTo(clientOptions.Identifier));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessorClient.StartAsync" />
        ///    method.
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
        ///    Verifies functionality of the <see cref="EventProcessorClient.StartAsync" />
        ///    method.
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
        ///    Verifies functionality of the <see cref="EventProcessorClient.StartAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task StartAsyncStartsTheEventProcessorWhenProcessingHandlerPropertiesAreSet()
        {
            var processor = new EventProcessorClient(Mock.Of<PartitionManager>(), "consumerGroup", "namespace", "eventHub", () => new MockConnection(), default);

            processor.ProcessEventAsync += eventArgs => Task.CompletedTask;
            processor.ProcessErrorAsync += eventArgs => Task.CompletedTask;

            Assert.That(async () => await processor.StartProcessingAsync(), Throws.Nothing);

            await processor.StopProcessingAsync();
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessorClient" /> properties.
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
        ///    Verifies functionality of the <see cref="EventProcessorClient" /> properties.
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
        ///   Retrieves the Connection for the processor client using its private accessor.
        /// </summary>
        ///
        private static EventHubConnection GetConnection(EventProcessorClient client) =>
            (EventHubConnection)
                typeof(EventProcessorClient)
                    .GetProperty("Connection", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(client);

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
        ///   Allows for the options used by the event processor to be exposed for testing purposes.
        /// </summary>
        ///
        public class ReadableOptionsMock : EventProcessorClient
        {
            public EventProcessorClientOptions ClientOptions =>
                typeof(EventProcessorClient)
                    .GetProperty(nameof(ClientOptions), BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(this) as EventProcessorClientOptions;

            public ReadableOptionsMock(PartitionManager partitionManager,
                                       string consumerGroup,
                                       string connectionString,
                                       EventProcessorClientOptions clientOptions = default) : base(partitionManager, consumerGroup, connectionString, clientOptions)
            {
            }

            public ReadableOptionsMock(PartitionManager partitionManager,
                                       string consumerGroup,
                                       string fullyQualifiedNamespace,
                                       string eventHubName,
                                       TokenCredential credential,
                                       EventProcessorClientOptions clientOptions = default) : base(partitionManager, consumerGroup, fullyQualifiedNamespace, eventHubName, credential, clientOptions)
            {
            }
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

            internal override TransportClient CreateTransportClient(string fullyQualifiedNamespace, string eventHubName, EventHubTokenCredential credential, EventHubConnectionOptions options)
            {
                var client = new Mock<TransportClient>();

                client
                    .Setup(client => client.ServiceEndpoint)
                    .Returns(new Uri($"amgp://{ fullyQualifiedNamespace}.com/{eventHubName}"));

                return client.Object;
            }
        }
    }
}
