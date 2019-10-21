// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Processor;
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

            yield return new object[] { new ReadableOptionsMock("consumerGroup", Mock.Of<PartitionManager>(), connectionString), "connection string with default options" };
            yield return new object[] { new ReadableOptionsMock("consumerGroup", Mock.Of<PartitionManager>(), connectionString, null), "connection string with explicit null options" };
            yield return new object[] { new ReadableOptionsMock("consumerGroup", Mock.Of<PartitionManager>(), "namespace", "hub", Mock.Of<TokenCredential>()), "namespace with default options" };
            yield return new object[] { new ReadableOptionsMock("consumerGroup", Mock.Of<PartitionManager>(), "namespace", "hub", Mock.Of<TokenCredential>(), null), "namespace with explicit null options" };
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
            Assert.That(() => new EventProcessorClient(consumerGroup, Mock.Of<PartitionManager>(), "dummyConnection", new EventProcessorClientOptions()), Throws.InstanceOf<ArgumentException>(), "The connection string constructor should validate the consumer group.");
            Assert.That(() => new EventProcessorClient(consumerGroup, Mock.Of<PartitionManager>(), "dummyNamespace", "dummyEventHub", Mock.Of<TokenCredential>(), new EventProcessorClientOptions()), Throws.InstanceOf<ArgumentException>(), "The namespace constructor should validate the consumer group.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessorClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesThePartitionManager()
        {
            Assert.That(() => new EventProcessorClient("consumerGroup", null, "dummyConnection", new EventProcessorClientOptions()), Throws.InstanceOf<ArgumentException>(), "The connection string constructor should validate the event processor store.");
            Assert.That(() => new EventProcessorClient("consumerGroup", null, "dummyNamespace", "dummyEventHub", Mock.Of<TokenCredential>(), new EventProcessorClientOptions()), Throws.InstanceOf<ArgumentException>(), "The namespace constructor should validate the event processor store.");
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
            Assert.That(() => new EventProcessorClient(EventHubConsumerClient.DefaultConsumerGroupName, Mock.Of<PartitionManager>(), connectionString), Throws.InstanceOf<ArgumentException>(), "The constructor without options should ensure a connection string.");
            Assert.That(() => new EventProcessorClient(EventHubConsumerClient.DefaultConsumerGroupName, Mock.Of<PartitionManager>(), connectionString, "dummy", new EventProcessorClientOptions()), Throws.InstanceOf<ArgumentException>(), "The constructor with options should ensure a connection string.");
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
            Assert.That(() => new EventProcessorClient(EventHubConsumerClient.DefaultConsumerGroupName, Mock.Of<PartitionManager>(), constructorArgument, "dummy", Mock.Of<TokenCredential>()), Throws.InstanceOf<ArgumentException>());
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
            Assert.That(() => new EventProcessorClient(EventHubConsumerClient.DefaultConsumerGroupName, Mock.Of<PartitionManager>(), "namespace", constructorArgument, Mock.Of<TokenCredential>()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheCredential()
        {
            Assert.That(() => new EventProcessorClient(EventHubConsumerClient.DefaultConsumerGroupName, Mock.Of<PartitionManager>(), "namespace", "hubName", default(TokenCredential)), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorSetsTheRetryPolicy()
        {
            var expected = Mock.Of<EventHubRetryPolicy>();
            var options = new EventProcessorClientOptions { RetryOptions = new RetryOptions { CustomRetryPolicy = expected } };
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var processor = new EventProcessorClient(EventHubConsumerClient.DefaultConsumerGroupName, Mock.Of<PartitionManager>(), connectionString, options);

            Assert.That(GetRetryPolicy(processor), Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void NamespaceConstructorSetsTheRetryPolicy()
        {
            var expected = Mock.Of<EventHubRetryPolicy>();
            var options = new EventProcessorClientOptions { RetryOptions = new RetryOptions { CustomRetryPolicy = expected } };
            var processor = new EventProcessorClient(EventHubConsumerClient.DefaultConsumerGroupName, Mock.Of<PartitionManager>(), "namespace", "hubName", Mock.Of<TokenCredential>(), options);

            Assert.That(GetRetryPolicy(processor), Is.SameAs(expected));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessorClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorCreatesDefaultOptionsCases))]
        public void ConstructorCreatesDefaultOptions(ReadableOptionsMock eventProcessor,
                                                     string constructorDescription)
        {
            var defaultOptions = new EventProcessorClientOptions();
            EventProcessorClientOptions options = eventProcessor.Options;

            Assert.That(options, Is.Not.Null, $"The { constructorDescription } constructor should have set default options.");
            Assert.That(options, Is.Not.SameAs(defaultOptions), $"The { constructorDescription } constructor should not have the same options instance.");
            Assert.That(options.MaximumReceiveWaitTime, Is.EqualTo(defaultOptions.MaximumReceiveWaitTime), $"The { constructorDescription } constructor should have the correct maximum receive wait time.");
            Assert.That(options.TrackLastEnqueuedEventInformation, Is.EqualTo(defaultOptions.TrackLastEnqueuedEventInformation), $"The { constructorDescription } constructor should default tracking of last event information.");
            Assert.That(options.ConnectionOptions.TransportType, Is.EqualTo(defaultOptions.ConnectionOptions.TransportType), $"The { constructorDescription } constructor should have a default set of connection options.");
            Assert.That(options.RetryOptions.IsEquivalentTo(defaultOptions.RetryOptions), Is.True, $"The { constructorDescription } constructor should have a default set of retry options.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessorClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorClonesOptions()
        {
            var options = new EventProcessorClientOptions
            {
                MaximumReceiveWaitTime = TimeSpan.FromMinutes(65),
                RetryOptions = new RetryOptions { TryTimeout = TimeSpan.FromMinutes(1), Delay = TimeSpan.FromMinutes(4) },
                ConnectionOptions = new EventHubConnectionOptions { TransportType = TransportType.AmqpWebSockets }
            };

            var eventProcessor = new ReadableOptionsMock("consumerGroup", Mock.Of<PartitionManager>(), "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub", options);
            EventProcessorClientOptions clonedOptions = eventProcessor.Options;

            Assert.That(clonedOptions, Is.Not.Null, "The constructor should have set the options.");
            Assert.That(clonedOptions, Is.Not.SameAs(options), "The constructor should have cloned the options.");
            Assert.That(clonedOptions.MaximumReceiveWaitTime, Is.EqualTo(options.MaximumReceiveWaitTime), "The constructor should have the correct maximum receive wait time.");
            Assert.That(clonedOptions.TrackLastEnqueuedEventInformation, Is.EqualTo(options.TrackLastEnqueuedEventInformation), "The tracking of last event information of the clone should match.");
            Assert.That(clonedOptions.ConnectionOptions.TransportType, Is.EqualTo(options.ConnectionOptions.TransportType), "The connection options of the clone should copy properties.");
            Assert.That(clonedOptions.ConnectionOptions, Is.Not.SameAs(options.ConnectionOptions), "The connection options of the clone should be a copy, not the same instance.");
            Assert.That(clonedOptions.RetryOptions.IsEquivalentTo(options.RetryOptions), Is.True, "The retry options of the clone should be considered equal.");
            Assert.That(clonedOptions.RetryOptions, Is.Not.SameAs(options.RetryOptions), "The retry options of the clone should be a copy, not the same instance.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessorClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void NamespaceConstructorClonesOptions()
        {
            var options = new EventProcessorClientOptions
            {
                MaximumReceiveWaitTime = TimeSpan.FromMinutes(65),
                RetryOptions = new RetryOptions { TryTimeout = TimeSpan.FromMinutes(1), Delay = TimeSpan.FromMinutes(4) },
                ConnectionOptions = new EventHubConnectionOptions { TransportType = TransportType.AmqpWebSockets }
            };

            var eventProcessor = new ReadableOptionsMock("consumerGroup", Mock.Of<PartitionManager>(), "namespace", "hub", Mock.Of<TokenCredential>(), options);
            EventProcessorClientOptions clonedOptions = eventProcessor.Options;

            Assert.That(clonedOptions, Is.Not.Null, "The constructor should have set the options.");
            Assert.That(clonedOptions, Is.Not.SameAs(options), "The constructor should have cloned the options.");
            Assert.That(clonedOptions.MaximumReceiveWaitTime, Is.EqualTo(options.MaximumReceiveWaitTime), "The constructor should have the correct maximum receive wait time.");
            Assert.That(clonedOptions.TrackLastEnqueuedEventInformation, Is.EqualTo(options.TrackLastEnqueuedEventInformation), "The tracking of last event information of the clone should match.");
            Assert.That(clonedOptions.ConnectionOptions.TransportType, Is.EqualTo(options.ConnectionOptions.TransportType), "The connection options of the clone should copy properties.");
            Assert.That(clonedOptions.ConnectionOptions, Is.Not.SameAs(options.ConnectionOptions), "The connection options of the clone should be a copy, not the same instance.");
            Assert.That(clonedOptions.RetryOptions.IsEquivalentTo(options.RetryOptions), Is.True, "The retry options of the clone should be considered equal.");
            Assert.That(clonedOptions.RetryOptions, Is.Not.SameAs(options.RetryOptions), "The retry options of the clone should be a copy, not the same instance.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessorClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorCreatesTheIdentifier()
        {
            var eventProcessor = new EventProcessorClient("consumerGroup", Mock.Of<PartitionManager>(), "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub");

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
            var eventProcessor = new EventProcessorClient("consumerGroup", Mock.Of<PartitionManager>(), "namespace", "hub", Mock.Of<TokenCredential>());

            Assert.That(eventProcessor.Identifier, Is.Not.Null);
            Assert.That(eventProcessor.Identifier, Is.Not.Empty);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.FullyQualifiedNamespace" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void ProcessorDelegatesForTheFullyQualifiedNamespaceName()
        {
            var expected = "SomeNamespace";
            var mockConnection = new MockConnection(expected);
            var processor = new EventProcessorClient(EventHubConsumerClient.DefaultConsumerGroupName, Mock.Of<PartitionManager>(), mockConnection, default);

            Assert.That(processor.FullyQualifiedNamespace, Is.EqualTo(expected));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.EventHubName" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void ConsumerDelegatesForTheEventHubName()
        {
            var expected = "EventHubName";
            var mockConnection = new MockConnection(eventHubName: expected);
            var processor = new EventProcessorClient(EventHubConsumerClient.DefaultConsumerGroupName, Mock.Of<PartitionManager>(), mockConnection, default);

            Assert.That(processor.EventHubName, Is.EqualTo(expected));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessorClient.StartAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void StartAsyncValidatesProcessEventsAsync()
        {
            var processor = new EventProcessorClient("consumerGroup", Mock.Of<PartitionManager>(), new MockConnection(), default);
            processor.ProcessExceptionAsync = (context, exception) => Task.CompletedTask;

            Assert.That(async () => await processor.StartAsync(), Throws.InstanceOf<InvalidOperationException>().And.Message.Contains(nameof(EventProcessorClient.ProcessEventsAsync)));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessorClient.StartAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void StartAsyncValidatesProcessExceptionAsync()
        {
            var processor = new EventProcessorClient("consumerGroup", Mock.Of<PartitionManager>(), new MockConnection(), default);
            processor.ProcessEventsAsync = (context, events) => Task.CompletedTask;

            Assert.That(async () => await processor.StartAsync(), Throws.InstanceOf<InvalidOperationException>().And.Message.Contains(nameof(EventProcessorClient.ProcessExceptionAsync)));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessorClient.StartAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task StartAsyncStartsTheEventProcessorWhenProcessingHandlerPropertiesAreSet()
        {
            var processor = new EventProcessorClient("consumerGroup", Mock.Of<PartitionManager>(), new MockConnection(), default);

            processor.ProcessEventsAsync = (context, events) => Task.CompletedTask;
            processor.ProcessExceptionAsync = (context, exception) => Task.CompletedTask;

            Assert.That(async () => await processor.StartAsync(), Throws.Nothing);

            await processor.StopAsync();
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessorClient" /> properties.
        /// </summary>
        ///
        [Test]
        public async Task HandlerPropertiesCannotBeSetWhenEventProcessorIsRunning()
        {
            var processor = new EventProcessorClient("consumerGroup", Mock.Of<PartitionManager>(), new MockConnection(), default);

            processor.ProcessEventsAsync = (context, events) => Task.CompletedTask;
            processor.ProcessExceptionAsync = (context, exception) => Task.CompletedTask;

            await processor.StartAsync();

            Assert.That(() => processor.InitializeProcessingForPartitionAsync = ((context) => Task.CompletedTask), Throws.InstanceOf<InvalidOperationException>());
            Assert.That(() => processor.ProcessingForPartitionStoppedAsync = ((context, reason) => Task.CompletedTask), Throws.InstanceOf<InvalidOperationException>());
            Assert.That(() => processor.ProcessEventsAsync = ((context, events) => Task.CompletedTask), Throws.InstanceOf<InvalidOperationException>());
            Assert.That(() => processor.ProcessExceptionAsync = ((context, exception) => Task.CompletedTask), Throws.InstanceOf<InvalidOperationException>());

            await processor.StopAsync();
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventProcessorClient" /> properties.
        /// </summary>
        ///
        [Test]
        public async Task HandlerPropertiesCanBeSetAfterEventProcessorHasStopped()
        {
            var processor = new EventProcessorClient("consumerGroup", Mock.Of<PartitionManager>(), new MockConnection(), default);

            processor.ProcessEventsAsync = (context, events) => Task.CompletedTask;
            processor.ProcessExceptionAsync = (context, exception) => Task.CompletedTask;

            await processor.StartAsync();
            await processor.StopAsync();

            Assert.That(() => processor.InitializeProcessingForPartitionAsync = ((context) => Task.CompletedTask), Throws.Nothing);
            Assert.That(() => processor.ProcessingForPartitionStoppedAsync = ((context, reason) => Task.CompletedTask), Throws.Nothing);
            Assert.That(() => processor.ProcessEventsAsync = ((context, events) => Task.CompletedTask), Throws.Nothing);
            Assert.That(() => processor.ProcessExceptionAsync = ((context, exception) => Task.CompletedTask), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncClosesTheConnectionWhenOwned()
        {
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var processor = new EventProcessorClient(EventHubConsumerClient.DefaultConsumerGroupName, Mock.Of<PartitionManager>(), connectionString);

            await processor.CloseAsync();

            var connection = GetConnection(processor);
            Assert.That(connection.Closed, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.Close" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloseClosesTheConnectionWhenOwned()
        {
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var processor = new EventProcessorClient(EventHubConsumerClient.DefaultConsumerGroupName, Mock.Of<PartitionManager>(), connectionString);

            processor.Close();

            var connection = GetConnection(processor);
            Assert.That(connection.Closed, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClient.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncDoesNotCloseTheConnectionWhenNotOwned()
        {
            var connection = new MockConnection();
            var processor = new EventProcessorClient(EventHubConsumerClient.DefaultConsumerGroupName, Mock.Of<PartitionManager>(), connection, default);

            await processor.CloseAsync();
            Assert.That(connection.Closed, Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducer.Close" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloseDoesNotCloseTheConnectionWhenNotOwned()
        {
            var connection = new MockConnection();
            var processor = new EventProcessorClient(EventHubConsumerClient.DefaultConsumerGroupName, Mock.Of<PartitionManager>(), connection, default);

            processor.Close();
            Assert.That(connection.Closed, Is.False);
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
        private static EventHubRetryPolicy GetRetryPolicy(EventProcessorClient client) =>
            (EventHubRetryPolicy)
                typeof(EventProcessorClient)
                    .GetProperty("RetryPolicy", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(client);

        /// <summary>
        ///   Allows for the options used by the event processor to be exposed for testing purposes.
        /// </summary>
        ///
        public class ReadableOptionsMock : EventProcessorClient
        {
            public EventProcessorClientOptions Options =>
                typeof(EventProcessorClient)
                    .GetProperty(nameof(Options), BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(this) as EventProcessorClientOptions;

            public ReadableOptionsMock(string consumerGroup,
                                       PartitionManager partitionManager,
                                       string connectionString,
                                       EventProcessorClientOptions options = default) : base(consumerGroup, partitionManager, connectionString, options)
            {
            }

            public ReadableOptionsMock(string consumerGroup,
                                       PartitionManager partitionManager,
                                       string fullyQualifiedNamespace,
                                       string eventHubName,
                                       TokenCredential credential,
                                       EventProcessorClientOptions options = default) : base(consumerGroup, partitionManager, fullyQualifiedNamespace, eventHubName, credential, options)
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
                                  string eventHubName = "fakeEventHub") : base(namespaceName, eventHubName, Mock.Of<TokenCredential>())
            {
                FullyQualifiedNamespace = namespaceName;
                EventHubName = eventHubName;
            }

            internal override TransportClient CreateTransportClient(string fullyQualifiedNamespace, string eventHubName, TokenCredential credential, EventHubConnectionOptions options)
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
