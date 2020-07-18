// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;
using Azure.Messaging.EventHubs.Primitives;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="PartitionReceiver" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class PartitionReceiverTests
    {
        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheConsumerGroup(string consumerGroup)
        {
            Assert.That(() => new PartitionReceiver(consumerGroup, "pid", EventPosition.Earliest, "cs"), Throws.InstanceOf<ArgumentException>(), "The connection string constructor without event hub should perform validation.");
            Assert.That(() => new PartitionReceiver(consumerGroup, "pid", EventPosition.Earliest, "cs", "eh"), Throws.InstanceOf<ArgumentException>(), "The connection string constructor with event hub should perform validation.");
            Assert.That(() => new PartitionReceiver(consumerGroup, "pid", EventPosition.Earliest, "fqns", "eh", Mock.Of<TokenCredential>()), Throws.InstanceOf<ArgumentException>(), "The namespace constructor should perform validation.");
            Assert.That(() => new PartitionReceiver(consumerGroup, "pid", EventPosition.Earliest, Mock.Of<EventHubConnection>()), Throws.InstanceOf<ArgumentException>(), "The connection constructor should perform validation.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesThePartitionId(string partitionId)
        {
            Assert.That(() => new PartitionReceiver("cg", partitionId, EventPosition.Earliest, "cs"), Throws.InstanceOf<ArgumentException>(), "The connection string constructor without event hub should perform validation.");
            Assert.That(() => new PartitionReceiver("cg", partitionId, EventPosition.Earliest, "cs", "eh"), Throws.InstanceOf<ArgumentException>(), "The connection string constructor with event hub should perform validation.");
            Assert.That(() => new PartitionReceiver("cg", partitionId, EventPosition.Earliest, "fqns", "eh", Mock.Of<TokenCredential>()), Throws.InstanceOf<ArgumentException>(), "The namespace constructor should perform validation.");
            Assert.That(() => new PartitionReceiver("cg", partitionId, EventPosition.Earliest, Mock.Of<EventHubConnection>()), Throws.InstanceOf<ArgumentException>(), "The connection constructor should perform validation.");
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
            Assert.That(() => new PartitionReceiver("cg", "pid", EventPosition.Earliest, connectionString), Throws.InstanceOf<ArgumentException>(), "The constructor without event hub should perform validation.");
            Assert.That(() => new PartitionReceiver("cg", "pid", EventPosition.Earliest, connectionString, "eh"), Throws.InstanceOf<ArgumentException>(), "The constructor with event hub should perform validation.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("amqps://namespace.windows.servicebus.net")]
        public void ConstructorValidatesTheFullyQualifiedNamespace(string fullyQualifiedNamespace)
        {
            Assert.That(() => new PartitionReceiver("cg", "pid", EventPosition.Earliest, fullyQualifiedNamespace, "eh", Mock.Of<TokenCredential>()), Throws.InstanceOf<ArgumentException>(), "The constructor should perform validation.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheEventHubName(string eventHubName)
        {
            Assert.That(() => new PartitionReceiver("cg", "pid", EventPosition.Earliest, "fqns", eventHubName, Mock.Of<TokenCredential>()), Throws.InstanceOf<ArgumentException>(), "The constructor should perform validation.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheCredential()
        {
            Assert.That(() => new PartitionReceiver("cg", "pid", EventPosition.Earliest, "fqns", "eh", default(TokenCredential)), Throws.InstanceOf<ArgumentNullException>(), "The constructor should perform validation.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheConnection()
        {
            Assert.That(() => new PartitionReceiver("cg", "pid", EventPosition.Earliest, default(EventHubConnection)), Throws.InstanceOf<ArgumentNullException>(), "The constructor should perform validation.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorSetsTheRetryPolicy()
        {
            var expected = Mock.Of<EventHubsRetryPolicy>();
            var options = new PartitionReceiverOptions { RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = expected } };
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, connectionString, options);

            Assert.That(GetRetryPolicy(receiver), Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ExpandedConstructorSetsTheRetryPolicy()
        {
            var expected = Mock.Of<EventHubsRetryPolicy>();
            var options = new PartitionReceiverOptions { RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = expected } };
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, "fqns", "eh", Mock.Of<TokenCredential>(), options);

            Assert.That(GetRetryPolicy(receiver), Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionConstructorSetsTheRetryPolicy()
        {
            var expected = Mock.Of<EventHubsRetryPolicy>();
            var options = new PartitionReceiverOptions { RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = expected } };
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, Mock.Of<EventHubConnection>(), options);

            Assert.That(GetRetryPolicy(receiver), Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorSetsTheDefaultMaximumWaitTime()
        {
            var expected = TimeSpan.FromMinutes(1);
            var options = new PartitionReceiverOptions { DefaultMaximumReceiveWaitTime = expected };
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, connectionString, options);

            Assert.That(GetDefaultMaximumWaitTime(receiver), Is.EqualTo(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ExpandedConstructorSetsTheDefaultMaximumWaitTime()
        {
            var expected = TimeSpan.FromMinutes(1);
            var options = new PartitionReceiverOptions { DefaultMaximumReceiveWaitTime = expected };
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, "fqns", "eh", Mock.Of<TokenCredential>(), options);

            Assert.That(GetDefaultMaximumWaitTime(receiver), Is.EqualTo(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionConstructorSetsTheDefaultMaximumWaitTime()
        {
            var expected = (TimeSpan?)null;
            var options = new PartitionReceiverOptions { DefaultMaximumReceiveWaitTime = expected };
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, Mock.Of<EventHubConnection>(), options);

            Assert.That(GetDefaultMaximumWaitTime(receiver), Is.EqualTo(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorCreatesTheTransportConsumer()
        {
            var expectedRetryPolicy = Mock.Of<EventHubsRetryPolicy>();
            var expectedOptions = new PartitionReceiverOptions
            {
                RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = expectedRetryPolicy },
                OwnerLevel = 99,
                PrefetchCount = 42,
                TrackLastEnqueuedEventProperties = false
            };
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var receiver = new ObservableConsumerPartitionReceiver("cg", "pid", EventPosition.Earliest, connectionString, expectedOptions);

            Assert.That(receiver.TransportConsumerCreatedWithConsumerGroup, Is.EqualTo(receiver.ConsumerGroup), "The constructor should have used the correct consumer group.");
            Assert.That(receiver.TransportConsumerCreatedWithPartitionId, Is.EqualTo(receiver.PartitionId), "The constructor should have used the correct partition id.");
            Assert.That(receiver.TransportConsumerCreatedWithEventPosition, Is.EqualTo(receiver.InitialPosition), "The constructor should have used the correct initial position.");
            Assert.That(receiver.TransportConsumerCreatedWithRetryPolicy, Is.SameAs(expectedRetryPolicy), "The constructor should have used the correct retry policy.");
            Assert.That(receiver.TransportConsumerCreatedWithOptions, Is.Not.SameAs(expectedOptions), "The constructor should have cloned the options.");
            Assert.That(receiver.TransportConsumerCreatedWithOptions.TrackLastEnqueuedEventProperties, Is.EqualTo(expectedOptions.TrackLastEnqueuedEventProperties), "The constructor should have used the correct track last enqueued event properties.");
            Assert.That(receiver.TransportConsumerCreatedWithOptions.OwnerLevel, Is.EqualTo(expectedOptions.OwnerLevel), "The constructor should have used the correct owner level.");
            Assert.That(receiver.TransportConsumerCreatedWithOptions.PrefetchCount, Is.EqualTo(expectedOptions.PrefetchCount), "The constructor should have used the correct prefetch count.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ExpandedConstructorCreatesTheTransportConsumer()
        {
            var expectedRetryPolicy = Mock.Of<EventHubsRetryPolicy>();
            var expectedOptions = new PartitionReceiverOptions
            {
                RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = expectedRetryPolicy },
                OwnerLevel = 99,
                PrefetchCount = 42,
                TrackLastEnqueuedEventProperties = false
            };
            var receiver = new ObservableConsumerPartitionReceiver("cg", "pid", EventPosition.Earliest, "fqns", "eh", Mock.Of<TokenCredential>(), expectedOptions);

            Assert.That(receiver.TransportConsumerCreatedWithConsumerGroup, Is.EqualTo(receiver.ConsumerGroup), "The constructor should have used the correct consumer group.");
            Assert.That(receiver.TransportConsumerCreatedWithPartitionId, Is.EqualTo(receiver.PartitionId), "The constructor should have used the correct partition id.");
            Assert.That(receiver.TransportConsumerCreatedWithEventPosition, Is.EqualTo(receiver.InitialPosition), "The constructor should have used the correct initial position.");
            Assert.That(receiver.TransportConsumerCreatedWithRetryPolicy, Is.SameAs(expectedRetryPolicy), "The constructor should have used the correct retry policy.");
            Assert.That(receiver.TransportConsumerCreatedWithOptions, Is.Not.SameAs(expectedOptions), "The constructor should have cloned the options.");
            Assert.That(receiver.TransportConsumerCreatedWithOptions.TrackLastEnqueuedEventProperties, Is.EqualTo(expectedOptions.TrackLastEnqueuedEventProperties), "The constructor should have used the correct track last enqueued event properties.");
            Assert.That(receiver.TransportConsumerCreatedWithOptions.OwnerLevel, Is.EqualTo(expectedOptions.OwnerLevel), "The constructor should have used the correct owner level.");
            Assert.That(receiver.TransportConsumerCreatedWithOptions.PrefetchCount, Is.EqualTo(expectedOptions.PrefetchCount), "The constructor should have used the correct prefetch count.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionConstructorCreatesTheTransportConsumer()
        {
            var expectedRetryPolicy = Mock.Of<EventHubsRetryPolicy>();
            var expectedOptions = new PartitionReceiverOptions
            {
                RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = expectedRetryPolicy },
                OwnerLevel = 99,
                PrefetchCount = 42,
                TrackLastEnqueuedEventProperties = false
            };
            var receiver = new ObservableConsumerPartitionReceiver("cg", "pid", EventPosition.Earliest, Mock.Of<EventHubConnection>(), expectedOptions);

            Assert.That(receiver.TransportConsumerCreatedWithConsumerGroup, Is.EqualTo(receiver.ConsumerGroup), "The constructor should have used the correct consumer group.");
            Assert.That(receiver.TransportConsumerCreatedWithPartitionId, Is.EqualTo(receiver.PartitionId), "The constructor should have used the correct partition id.");
            Assert.That(receiver.TransportConsumerCreatedWithEventPosition, Is.EqualTo(receiver.InitialPosition), "The constructor should have used the correct initial position.");
            Assert.That(receiver.TransportConsumerCreatedWithRetryPolicy, Is.SameAs(expectedRetryPolicy), "The constructor should have used the correct retry policy.");
            Assert.That(receiver.TransportConsumerCreatedWithOptions, Is.Not.SameAs(expectedOptions), "The constructor should have cloned the options.");
            Assert.That(receiver.TransportConsumerCreatedWithOptions.TrackLastEnqueuedEventProperties, Is.EqualTo(expectedOptions.TrackLastEnqueuedEventProperties), "The constructor should have used the correct track last enqueued event properties.");
            Assert.That(receiver.TransportConsumerCreatedWithOptions.OwnerLevel, Is.EqualTo(expectedOptions.OwnerLevel), "The constructor should have used the correct owner level.");
            Assert.That(receiver.TransportConsumerCreatedWithOptions.PrefetchCount, Is.EqualTo(expectedOptions.PrefetchCount), "The constructor should have used the correct prefetch count.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorCreatesDefaultOptions()
        {
            var defaultOptions = new PartitionReceiverOptions();
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var receiver = new ObservableConsumerPartitionReceiver("cg", "pid", EventPosition.Earliest, connectionString);
            var options = receiver.TransportConsumerCreatedWithOptions;

            Assert.That(options.ConnectionOptions.TransportType, Is.EqualTo(defaultOptions.ConnectionOptions.TransportType), $"The constructor should have set the correct connection type.");
            Assert.That(options.ConnectionOptions.Proxy, Is.EqualTo(defaultOptions.ConnectionOptions.Proxy), $"The constructor should have set the correct proxy.");
            Assert.That(options.RetryOptions.IsEquivalentTo(defaultOptions.RetryOptions), Is.True, $"The retry options should be equivalent.");
            Assert.That(options.DefaultMaximumReceiveWaitTime, Is.EqualTo(defaultOptions.DefaultMaximumReceiveWaitTime), "The constructor should have set the correct default maximum receive wait time.");
            Assert.That(options.OwnerLevel, Is.EqualTo(defaultOptions.OwnerLevel), "The constructor should have set the correct owner level.");
            Assert.That(options.PrefetchCount, Is.EqualTo(defaultOptions.PrefetchCount), "The constructor should have set the correct prefetch count.");
            Assert.That(options.TrackLastEnqueuedEventProperties, Is.EqualTo(defaultOptions.TrackLastEnqueuedEventProperties), "The constructor should have set the correct track last enqueued event properties.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ExpandedConstructorCreatesDefaultOptions()
        {
            var defaultOptions = new PartitionReceiverOptions();
            var receiver = new ObservableConsumerPartitionReceiver("cg", "pid", EventPosition.Earliest, "fqns", "eh", Mock.Of<TokenCredential>());
            var options = receiver.TransportConsumerCreatedWithOptions;

            Assert.That(options.ConnectionOptions.TransportType, Is.EqualTo(defaultOptions.ConnectionOptions.TransportType), $"The constructor should have set the correct connection type.");
            Assert.That(options.ConnectionOptions.Proxy, Is.EqualTo(defaultOptions.ConnectionOptions.Proxy), $"The constructor should have set the correct proxy.");
            Assert.That(options.RetryOptions.IsEquivalentTo(defaultOptions.RetryOptions), Is.True, $"The retry options should be equivalent.");
            Assert.That(options.DefaultMaximumReceiveWaitTime, Is.EqualTo(defaultOptions.DefaultMaximumReceiveWaitTime), "The constructor should have set the correct default maximum receive wait time.");
            Assert.That(options.OwnerLevel, Is.EqualTo(defaultOptions.OwnerLevel), "The constructor should have set the correct owner level.");
            Assert.That(options.PrefetchCount, Is.EqualTo(defaultOptions.PrefetchCount), "The constructor should have set the correct prefetch count.");
            Assert.That(options.TrackLastEnqueuedEventProperties, Is.EqualTo(defaultOptions.TrackLastEnqueuedEventProperties), "The constructor should have set the correct track last enqueued event properties.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionConstructorCreatesDefaultOptions()
        {
            var defaultOptions = new PartitionReceiverOptions();
            var receiver = new ObservableConsumerPartitionReceiver("cg", "pid", EventPosition.Earliest, Mock.Of<EventHubConnection>());
            var options = receiver.TransportConsumerCreatedWithOptions;

            Assert.That(options.ConnectionOptions.TransportType, Is.EqualTo(defaultOptions.ConnectionOptions.TransportType), $"The constructor should have set the correct connection type.");
            Assert.That(options.ConnectionOptions.Proxy, Is.EqualTo(defaultOptions.ConnectionOptions.Proxy), $"The constructor should have set the correct proxy.");
            Assert.That(options.RetryOptions.IsEquivalentTo(defaultOptions.RetryOptions), Is.True, $"The retry options should be equivalent.");
            Assert.That(options.DefaultMaximumReceiveWaitTime, Is.EqualTo(defaultOptions.DefaultMaximumReceiveWaitTime), "The constructor should have set the correct default maximum receive wait time.");
            Assert.That(options.OwnerLevel, Is.EqualTo(defaultOptions.OwnerLevel), "The constructor should have set the correct owner level.");
            Assert.That(options.PrefetchCount, Is.EqualTo(defaultOptions.PrefetchCount), "The constructor should have set the correct prefetch count.");
            Assert.That(options.TrackLastEnqueuedEventProperties, Is.EqualTo(defaultOptions.TrackLastEnqueuedEventProperties), "The constructor should have set the correct track last enqueued event properties.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorSetsTheConsumerGroup()
        {
            var consumerGroup = "SomeGroup";
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var receiver = new PartitionReceiver(consumerGroup, "pid", EventPosition.Earliest, connectionString);

            Assert.That(receiver.ConsumerGroup, Is.EqualTo(consumerGroup));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ExpandedConstructorSetsTheConsumerGroup()
        {
            var consumerGroup = "SomeGroup";
            var receiver = new PartitionReceiver(consumerGroup, "pid", EventPosition.Earliest, "fqns", "eh", Mock.Of<TokenCredential>());

            Assert.That(receiver.ConsumerGroup, Is.EqualTo(consumerGroup));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionConstructorSetsTheConsumerGroup()
        {
            var consumerGroup = "SomeGroup";
            var receiver = new PartitionReceiver(consumerGroup, "pid", EventPosition.Earliest, Mock.Of<EventHubConnection>());

            Assert.That(receiver.ConsumerGroup, Is.EqualTo(consumerGroup));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorSetsThePartitionId()
        {
            var partitionId = "partitionId";
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var receiver = new PartitionReceiver("cg", partitionId, EventPosition.Earliest, connectionString);

            Assert.That(receiver.PartitionId, Is.EqualTo(partitionId));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ExpandedConstructorSetsThePartitionId()
        {
            var partitionId = "partitionId";
            var receiver = new PartitionReceiver("cg", partitionId, EventPosition.Earliest, "fqns", "eh", Mock.Of<TokenCredential>());

            Assert.That(receiver.PartitionId, Is.EqualTo(partitionId));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionConstructorSetsThePartitionId()
        {
            var partitionId = "partitionId";
            var receiver = new PartitionReceiver("cg", partitionId, EventPosition.Earliest, Mock.Of<EventHubConnection>());

            Assert.That(receiver.PartitionId, Is.EqualTo(partitionId));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorSetsTheInitialPosition()
        {
            var expectedPosition = EventPosition.FromOffset(999);
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var receiver = new PartitionReceiver("cg", "pid", expectedPosition, connectionString);

            Assert.That(receiver.InitialPosition, Is.EqualTo(expectedPosition));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ExpandedConstructorSetsTheInitialPosition()
        {
            var expectedPosition = EventPosition.FromOffset(999);
            var receiver = new PartitionReceiver("cg", "pid", expectedPosition, "fqns", "eh", Mock.Of<TokenCredential>());

            Assert.That(receiver.InitialPosition, Is.EqualTo(expectedPosition));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionConstructorSetsTheInitialPosition()
        {
            var expectedPosition = EventPosition.FromOffset(999);
            var receiver = new PartitionReceiver("cg", "pid", expectedPosition, Mock.Of<EventHubConnection>());

            Assert.That(receiver.InitialPosition, Is.EqualTo(expectedPosition));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.FullyQualifiedNamespace" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void PartitionReceiverDelegatesForTheFullyQualifiedNamespace()
        {
            var expected = "SomeNamespace";
            var mockConnection = new EventHubConnection(expected, "eh", Mock.Of<TokenCredential>());
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, mockConnection);

            Assert.That(receiver.FullyQualifiedNamespace, Is.EqualTo(expected));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.EventHubName" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void PartitionReceiverDelegatesForTheEventHubName()
        {
            var expected = "EventHubName";
            var mockConnection = new EventHubConnection("fqns", expected, Mock.Of<TokenCredential>());
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, mockConnection);

            Assert.That(receiver.EventHubName, Is.EqualTo(expected));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.CreateTransportConsumer"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateTransportConsumerDelegatesToTheConnection()
        {
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var mockConnection = new Mock<EventHubConnection>(connectionString);
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, mockConnection.Object);

            var expectedConsumerGroup = "consumerGroup";
            var expectedPartitionId = "partitionId";
            var expectedPosition = EventPosition.FromOffset(55);
            var expectedRetryPolicy = Mock.Of<EventHubsRetryPolicy>();
            var expectedOptions = new PartitionReceiverOptions
            {
                OwnerLevel = 99,
                PrefetchCount = 42,
                TrackLastEnqueuedEventProperties = false
            };

            receiver.CreateTransportConsumer(expectedConsumerGroup, expectedPartitionId, expectedPosition, expectedRetryPolicy, expectedOptions);

            mockConnection
                .Verify(connection => connection.CreateTransportConsumer(
                    expectedConsumerGroup,
                    expectedPartitionId,
                    expectedPosition,
                    expectedRetryPolicy,
                    expectedOptions.TrackLastEnqueuedEventProperties,
                    expectedOptions.OwnerLevel,
                    (uint?)expectedOptions.PrefetchCount),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.ReadLastEnqueuedEventProperties" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ReadLastEnqueuedEventPropertiesDelegatesToTheTransportConsumer()
        {
            var lastEvent = new EventData
            (
                eventBody: Array.Empty<byte>(),
                lastPartitionSequenceNumber: 1234,
                lastPartitionOffset: 42,
                lastPartitionEnqueuedTime: DateTimeOffset.Parse("2015-10-27T00:00:00Z"),
                lastPartitionPropertiesRetrievalTime: DateTimeOffset.Parse("2012-03-04T08:42Z")
            );

            var options = new PartitionReceiverOptions { TrackLastEnqueuedEventProperties = true };
            var mockConsumer = new LastEventConsumerMock(lastEvent);
            var mockConnection = new Mock<EventHubConnection>();

            mockConnection
                .Setup(connection => connection.CreateTransportConsumer(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<EventHubsRetryPolicy>(),
                    It.IsAny<bool>(),
                    It.IsAny<long?>(),
                    It.IsAny<uint?>()))
                .Returns(mockConsumer);

            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, mockConnection.Object);
            var information = receiver.ReadLastEnqueuedEventProperties();

            Assert.That(information.SequenceNumber, Is.EqualTo(lastEvent.LastPartitionSequenceNumber), "The sequence number should match.");
            Assert.That(information.Offset, Is.EqualTo(lastEvent.LastPartitionOffset), "The offset should match.");
            Assert.That(information.EnqueuedTime, Is.EqualTo(lastEvent.LastPartitionEnqueuedTime), "The last enqueue time should match.");
            Assert.That(information.LastReceivedTime, Is.EqualTo(lastEvent.LastPartitionPropertiesRetrievalTime), "The retrieval time should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.ReadLastEnqueuedEventProperties" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ReadLastEnqueuedEventPropertiesAllowsTheOperationWhenTheOptionIsUnset()
        {
            var defaultProperties = new LastEnqueuedEventProperties();
            var options = new PartitionReceiverOptions { TrackLastEnqueuedEventProperties = false };
            var mockConsumer = new Mock<TransportConsumer>();
            var mockConnection = new Mock<EventHubConnection>();

            mockConnection
                .Setup(connection => connection.CreateTransportConsumer(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<EventHubsRetryPolicy>(),
                    It.IsAny<bool>(),
                    It.IsAny<long?>(),
                    It.IsAny<uint?>()))
                .Returns(mockConsumer.Object);

            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, mockConnection.Object);
            var information = receiver.ReadLastEnqueuedEventProperties();

            Assert.That(information.SequenceNumber, Is.EqualTo(defaultProperties.SequenceNumber), "The sequence number should match.");
            Assert.That(information.Offset, Is.EqualTo(defaultProperties.Offset), "The offset should match.");
            Assert.That(information.EnqueuedTime, Is.EqualTo(defaultProperties.EnqueuedTime), "The last enqueue time should match.");
            Assert.That(information.LastReceivedTime, Is.EqualTo(defaultProperties.LastReceivedTime), "The retrieval time should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.GetPartitionPropertiesAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetPartitionPropertiesDelegatesToTheConnection()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var mockConnection = new Mock<EventHubConnection>();
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, mockConnection.Object);

            await receiver.GetPartitionPropertiesAsync(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockConnection
                .Verify(connection => connection.GetPartitionPropertiesAsync(
                    receiver.PartitionId,
                    It.IsAny<EventHubsRetryPolicy>(),
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.GetPartitionPropertiesAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetPartitionPropertiesUsesTheRetryPolicy()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var mockConnection = new Mock<EventHubConnection>();
            var retryPolicy = Mock.Of<EventHubsRetryPolicy>();
            var options = new PartitionReceiverOptions { RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = retryPolicy } };
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, mockConnection.Object, options);

            await receiver.GetPartitionPropertiesAsync(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockConnection
                .Verify(connection => connection.GetPartitionPropertiesAsync(
                    It.IsAny<string>(),
                    retryPolicy,
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.GetPartitionPropertiesAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetPartitionPropertiesUsesTheCancellationToken()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var mockConnection = new Mock<EventHubConnection>();
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, mockConnection.Object);

            await receiver.GetPartitionPropertiesAsync(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockConnection
                .Verify(connection => connection.GetPartitionPropertiesAsync(
                    It.IsAny<string>(),
                    It.IsAny<EventHubsRetryPolicy>(),
                    cancellationSource.Token),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.GetPartitionPropertiesAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetPartitionPropertiesFailsWhenPartitionReceiverIsClosed()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, connectionString);

            await receiver.CloseAsync(cancellationSource.Token);

            Assert.That(async () => await receiver.GetPartitionPropertiesAsync(cancellationSource.Token), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.ReceiveBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        public void ReceiveBatchAsyncValidatesTheMaximumEventCount(int maximumEventCount)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, connectionString);

            Assert.That(async () => await receiver.ReceiveBatchAsync(maximumEventCount, TimeSpan.Zero, cancellationSource.Token), Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.ReceiveBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        public void ReceiveBatchAsyncValidatesTheMaximumWaitTime(int waitTimeSeconds)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, connectionString);

            Assert.That(async () => await receiver.ReceiveBatchAsync(1, TimeSpan.FromSeconds(waitTimeSeconds), cancellationSource.Token), Throws.InstanceOf<ArgumentOutOfRangeException>());
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.ReceiveBatchAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ReceiveBatchAsyncFailsWhenPartitionReceiverIsClosed()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, connectionString);

            await receiver.CloseAsync(cancellationSource.Token);

            Assert.That(async () => await receiver.ReceiveBatchAsync(1, TimeSpan.Zero, cancellationSource.Token), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.ReceiveBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ReceiveBatchAsyncRespectsTheCancellationToken()
        {
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, connectionString);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(async () => await receiver.ReceiveBatchAsync(1, TimeSpan.Zero, cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.ReceiveBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ReceiveBatchAsyncDelegatesToTheTransportConsumer()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedMaximumCount = 50;
            var expectedWaitTime = TimeSpan.FromMilliseconds(23);
            var mockConsumer = new Mock<TransportConsumer>();
            var mockConnection = new Mock<EventHubConnection>();

            mockConnection
                .Setup(connection => connection.CreateTransportConsumer(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<EventHubsRetryPolicy>(),
                    It.IsAny<bool>(),
                    It.IsAny<long?>(),
                    It.IsAny<uint?>()))
                .Returns(mockConsumer.Object);

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Array.Empty<EventData>());

            await using var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, mockConnection.Object);
            await receiver.ReceiveBatchAsync(expectedMaximumCount, expectedWaitTime, CancellationToken.None);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockConsumer
                .Verify(consumer => consumer.ReceiveAsync(
                    expectedMaximumCount,
                    expectedWaitTime,
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.ReceiveBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ReceiveBatchAsyncUsesTheDefaultMaximumReceiveWaitTimeWhenNoWaitTimeIsSpecified()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedMaximumCount = 50;
            var expectedWaitTime = TimeSpan.FromMilliseconds(23);
            var options = new PartitionReceiverOptions { DefaultMaximumReceiveWaitTime = expectedWaitTime };
            var mockConsumer = new Mock<TransportConsumer>();
            var mockConnection = new Mock<EventHubConnection>();

            mockConnection
                .Setup(connection => connection.CreateTransportConsumer(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<EventHubsRetryPolicy>(),
                    It.IsAny<bool>(),
                    It.IsAny<long?>(),
                    It.IsAny<uint?>()))
                .Returns(mockConsumer.Object);

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Array.Empty<EventData>());

            await using var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, mockConnection.Object, options);
            await receiver.ReceiveBatchAsync(expectedMaximumCount, CancellationToken.None);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockConsumer
                .Verify(consumer => consumer.ReceiveAsync(
                    expectedMaximumCount,
                    expectedWaitTime,
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.ReceiveBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ReceiveBatchAsyncRespectsTheDefaultMaximumWaitTimeBeingUnset()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedMaximumCount = 50;
            var options = new PartitionReceiverOptions { DefaultMaximumReceiveWaitTime = default };
            var mockConsumer = new Mock<TransportConsumer>();
            var mockConnection = new Mock<EventHubConnection>();

            mockConnection
                .Setup(connection => connection.CreateTransportConsumer(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<EventHubsRetryPolicy>(),
                    It.IsAny<bool>(),
                    It.IsAny<long?>(),
                    It.IsAny<uint?>()))
                .Returns(mockConsumer.Object);

            mockConsumer
                .Setup(consumer => consumer.ReceiveAsync(It.IsAny<int>(), It.IsAny<TimeSpan?>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Array.Empty<EventData>());

            await using var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, mockConnection.Object, options);
            await receiver.ReceiveBatchAsync(expectedMaximumCount, CancellationToken.None);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockConsumer
                .Verify(consumer => consumer.ReceiveAsync(
                    expectedMaximumCount,
                    default(TimeSpan?),
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncMarksTheClientAsClosed()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, connectionString);

            Assert.That(receiver.IsClosed, Is.False);

            await receiver.CloseAsync(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            Assert.That(receiver.IsClosed, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncClosesTheTransportConsumer()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var mockConsumer = new Mock<TransportConsumer>();
            var mockConnection = new Mock<EventHubConnection>(connectionString);
            var mockEventSource = new Mock<EventHubsEventSource>() { CallBase = true };

            mockConnection
                .Setup(connection => connection.CreateTransportConsumer(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<EventHubsRetryPolicy>(),
                    It.IsAny<bool>(),
                    It.IsAny<long?>(),
                    It.IsAny<uint?>()))
                .Returns(mockConsumer.Object);

            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, mockConnection.Object);

            await receiver.CloseAsync(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockConsumer
                .Verify(consumer => consumer.CloseAsync(
                    CancellationToken.None),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloseAsyncSurfacesExceptionsForTheTransportConsumer()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedException = new InsufficientMemoryException("This message is expected.");
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var mockConsumer = new Mock<TransportConsumer>();
            var mockConnection = new Mock<EventHubConnection>(connectionString);

            mockConsumer
                .Setup(consumer => consumer.CloseAsync(
                    It.IsAny<CancellationToken>()))
                .Throws(expectedException);

            mockConnection
                .Setup(connection => connection.CreateTransportConsumer(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<EventHubsRetryPolicy>(),
                    It.IsAny<bool>(),
                    It.IsAny<long?>(),
                    It.IsAny<uint?>()))
                .Returns(mockConsumer.Object);

            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, mockConnection.Object);

            Assert.That(async () => await receiver.CloseAsync(cancellationSource.Token), Throws.TypeOf(expectedException.GetType()).And.EqualTo(expectedException));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            Assert.That(receiver.IsClosed, Is.True, "The partition receiver should have been closed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncClosesTheConnectionWhenOwned()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, connectionString);

            await receiver.CloseAsync(cancellationSource.Token);

            var connection = GetConnection(receiver);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            Assert.That(connection.IsClosed, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncDoesNotCloseTheConnectionWhenNotOwned()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var connection = new EventHubConnection(connectionString);
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, connection);

            await receiver.CloseAsync(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            Assert.That(connection.IsClosed, Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloseAsyncRespectsTheCancellationToken()
        {
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, connectionString);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(async () => await receiver.CloseAsync(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
            Assert.That(receiver.IsClosed, Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncLogsNormalClose()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123";
            var eventHubName = "somehub";
            var mockConsumer = new Mock<TransportConsumer>();
            var mockConnection = new Mock<EventHubConnection>(connectionString, eventHubName);
            var mockEventSource = new Mock<EventHubsEventSource>() { CallBase = true };

            mockConnection
                .Setup(connection => connection.CreateTransportConsumer(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<EventHubsRetryPolicy>(),
                    It.IsAny<bool>(),
                    It.IsAny<long?>(),
                    It.IsAny<uint?>()))
                .Returns(mockConsumer.Object);

            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, mockConnection.Object);

            receiver.Logger = mockEventSource.Object;

            await receiver.CloseAsync(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockEventSource
                .Verify(log => log.ClientCloseStart(
                    nameof(PartitionReceiver),
                    eventHubName,
                    It.IsAny<string>()),
                Times.Once);

            mockEventSource
                .Verify(log => log.ClientCloseComplete(
                    nameof(PartitionReceiver),
                    eventHubName,
                    It.IsAny<string>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncLogsErrorDuringClose()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedException = new InsufficientMemoryException("This message is expected.");
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123";
            var eventHubName = "somehub";
            var mockConsumer = new Mock<TransportConsumer>();
            var mockConnection = new Mock<EventHubConnection>(connectionString, eventHubName);
            var mockEventSource = new Mock<EventHubsEventSource>() { CallBase = true };

            mockConsumer
                .Setup(consumer => consumer.CloseAsync(
                    It.IsAny<CancellationToken>()))
                .Throws(expectedException);

            mockConnection
                .Setup(connection => connection.CreateTransportConsumer(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<EventHubsRetryPolicy>(),
                    It.IsAny<bool>(),
                    It.IsAny<long?>(),
                    It.IsAny<uint?>()))
                .Returns(mockConsumer.Object);

            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, mockConnection.Object);

            receiver.Logger = mockEventSource.Object;

            try
            {
                await receiver.CloseAsync(cancellationSource.Token);
            }
            catch (InsufficientMemoryException)
            {
                // This exception is expected.
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockEventSource
                .Verify(log => log.ClientCloseStart(
                    nameof(PartitionReceiver),
                    eventHubName,
                    It.IsAny<string>()),
                Times.Once);

            mockEventSource
                .Verify(log => log.ClientCloseError(
                    nameof(PartitionReceiver),
                    eventHubName,
                    It.IsAny<string>(),
                    expectedException.Message),
                Times.Once);

            mockEventSource
                .Verify(log => log.ClientCloseComplete(
                    nameof(PartitionReceiver),
                    eventHubName,
                    It.IsAny<string>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.DisposeAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task DisposeAsyncDelegatesToCloseAsync()
        {
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var mockReceiver = new Mock<PartitionReceiver>("cg", "pid", EventPosition.Earliest, connectionString, default(PartitionReceiverOptions)) { CallBase = true };

            await mockReceiver.Object.DisposeAsync();

            mockReceiver
                .Verify(receiver => receiver.CloseAsync(
                    CancellationToken.None),
                Times.Once);
        }

        /// <summary>
        ///   Retrieves the Connection for the partition receiver using its private accessor.
        /// </summary>
        ///
        private static EventHubConnection GetConnection(PartitionReceiver partitionReceiver) =>
            (EventHubConnection)
                typeof(PartitionReceiver)
                    .GetProperty("Connection", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(partitionReceiver);

        /// <summary>
        ///   Retrieves the RetryPolicy for the partition receiver using its private accessor.
        /// </summary>
        ///
        private static EventHubsRetryPolicy GetRetryPolicy(PartitionReceiver partitionReceiver) =>
            (EventHubsRetryPolicy)
                typeof(PartitionReceiver)
                    .GetProperty("RetryPolicy", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(partitionReceiver);

        /// <summary>
        ///   Retrieves the DefaultMaximumWaitTime for the partition receiver using its private accessor.
        /// </summary>
        ///
        private static TimeSpan? GetDefaultMaximumWaitTime(PartitionReceiver partitionReceiver) =>
            (TimeSpan?)
                typeof(PartitionReceiver)
                    .GetProperty("DefaultMaximumWaitTime", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(partitionReceiver);

        /// <summary>
        ///   Allows the observation of the creation of a <see cref="TransportConsumer"/>
        ///   for testing purposes.
        /// </summary>
        ///
        private class ObservableConsumerPartitionReceiver : PartitionReceiver
        {
            public string TransportConsumerCreatedWithConsumerGroup { get; private set; }
            public string TransportConsumerCreatedWithPartitionId { get; private set; }
            public EventPosition TransportConsumerCreatedWithEventPosition { get; private set; }
            public EventHubsRetryPolicy TransportConsumerCreatedWithRetryPolicy { get; private set; }
            public PartitionReceiverOptions TransportConsumerCreatedWithOptions { get; private set; }

            public ObservableConsumerPartitionReceiver(string consumerGroup,
                                                       string partitionId,
                                                       EventPosition eventPosition,
                                                       string connectionString) : base(consumerGroup, partitionId, eventPosition, connectionString)
            {
            }

            public ObservableConsumerPartitionReceiver(string consumerGroup,
                                                       string partitionId,
                                                       EventPosition eventPosition,
                                                       string connectionString,
                                                       PartitionReceiverOptions options) : base(consumerGroup, partitionId, eventPosition, connectionString, options)
            {
            }

            public ObservableConsumerPartitionReceiver(string consumerGroup,
                                                       string partitionId,
                                                       EventPosition eventPosition,
                                                       string fullyQualifiedNamespace,
                                                       string eventHubName,
                                                       TokenCredential credential) : base(consumerGroup, partitionId, eventPosition, fullyQualifiedNamespace, eventHubName, credential)
            {
            }

            public ObservableConsumerPartitionReceiver(string consumerGroup,
                                                       string partitionId,
                                                       EventPosition eventPosition,
                                                       string fullyQualifiedNamespace,
                                                       string eventHubName,
                                                       TokenCredential credential,
                                                       PartitionReceiverOptions options) : base(consumerGroup, partitionId, eventPosition, fullyQualifiedNamespace, eventHubName, credential, options)
            {
            }

            public ObservableConsumerPartitionReceiver(string consumerGroup,
                                                       string partitionId,
                                                       EventPosition eventPosition,
                                                       EventHubConnection connection) : base(consumerGroup, partitionId, eventPosition, connection)
            {
            }

            public ObservableConsumerPartitionReceiver(string consumerGroup,
                                                       string partitionId,
                                                       EventPosition eventPosition,
                                                       EventHubConnection connection,
                                                       PartitionReceiverOptions options) : base(consumerGroup, partitionId, eventPosition, connection, options)
            {
            }

            internal override TransportConsumer CreateTransportConsumer(string consumerGroup,
                                                                        string partitionId,
                                                                        EventPosition eventPosition,
                                                                        EventHubsRetryPolicy retryPolicy,
                                                                        PartitionReceiverOptions options)
            {
                TransportConsumerCreatedWithConsumerGroup = consumerGroup;
                TransportConsumerCreatedWithPartitionId = partitionId;
                TransportConsumerCreatedWithEventPosition = eventPosition;
                TransportConsumerCreatedWithRetryPolicy = retryPolicy;
                TransportConsumerCreatedWithOptions = options;

                return base.CreateTransportConsumer(consumerGroup, partitionId, eventPosition, retryPolicy, options);
            }
        }

        /// <summary>
        ///   Allows for setting the last received event by the consumer
        ///   for testing purposes.
        /// </summary>
        ///
        private class LastEventConsumerMock : TransportConsumer
        {
            public LastEventConsumerMock(EventData lastEvent)
            {
                LastReceivedEvent = lastEvent;
            }

            public override Task<IReadOnlyList<EventData>> ReceiveAsync(int maximumMessageCount, TimeSpan? maximumWaitTime, CancellationToken cancellationToken) => throw new NotImplementedException();
            public override Task CloseAsync(CancellationToken cancellationToken) => throw new NotImplementedException();
        }
    }
}
