// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Authorization;
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
            Assert.That(() => new PartitionReceiver(consumerGroup, "pid", EventPosition.Earliest, "fqns", "eh", Mock.Of<TokenCredential>()), Throws.InstanceOf<ArgumentException>(), "The token credential constructor should perform validation.");
            Assert.That(() => new PartitionReceiver(consumerGroup, "pid", EventPosition.Earliest, "fqns", "eh", new AzureNamedKeyCredential("key", "value")), Throws.InstanceOf<ArgumentException>(), "The shared key credential constructor should perform validation.");
            Assert.That(() => new PartitionReceiver(consumerGroup, "pid", EventPosition.Earliest, "fqns", "eh", new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value)), Throws.InstanceOf<ArgumentException>(), "The SAS credential constructor should perform validation.");
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
            Assert.That(() => new PartitionReceiver("cg", partitionId, EventPosition.Earliest, "fqns", "eh", Mock.Of<TokenCredential>()), Throws.InstanceOf<ArgumentException>(), "The token credential constructor should perform validation.");
            Assert.That(() => new PartitionReceiver("cg", partitionId, EventPosition.Earliest, "fqns", "eh", new AzureNamedKeyCredential("key", "value")), Throws.InstanceOf<ArgumentException>(), "The shared key credential constructor should perform validation.");
            Assert.That(() => new PartitionReceiver("cg", partitionId, EventPosition.Earliest, "fqns", "eh", new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value)), Throws.InstanceOf<ArgumentException>(), "The SAS credential constructor should perform validation.");
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
        [TestCase("[this.wont.work]")]
        public void ConstructorValidatesTheFullyQualifiedNamespace(string fullyQualifiedNamespace)
        {
            Assert.That(() => new PartitionReceiver("cg", "pid", EventPosition.Earliest, fullyQualifiedNamespace, "eh", Mock.Of<TokenCredential>()), Throws.InstanceOf<ArgumentException>(), "The token credential constructor should perform validation.");
            Assert.That(() => new PartitionReceiver("cg", "pid", EventPosition.Earliest, fullyQualifiedNamespace, "eh", new AzureNamedKeyCredential("key", "value")), Throws.InstanceOf<ArgumentException>(), "The shared key credential constructor should perform validation.");
            Assert.That(() => new PartitionReceiver("cg", "pid", EventPosition.Earliest, fullyQualifiedNamespace, "eh", new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value)), Throws.InstanceOf<ArgumentException>(), "The SAS credential constructor should perform validation.");
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
            Assert.That(() => new PartitionReceiver("cg", "pid", EventPosition.Earliest, "fqns", eventHubName, Mock.Of<TokenCredential>()), Throws.InstanceOf<ArgumentException>(), "The token credential constructor should perform validation.");
            Assert.That(() => new PartitionReceiver("cg", "pid", EventPosition.Earliest, "fqns", eventHubName, new AzureNamedKeyCredential("key", "value")), Throws.InstanceOf<ArgumentException>(), "The shared key credential constructor should perform validation.");
            Assert.That(() => new PartitionReceiver("cg", "pid", EventPosition.Earliest, "fqns", eventHubName, new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value)), Throws.InstanceOf<ArgumentException>(), "The SAS credential constructor should perform validation.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheCredential()
        {
            Assert.That(() => new PartitionReceiver("cg", "pid", EventPosition.Earliest, "fqns", "eh", default(TokenCredential)), Throws.InstanceOf<ArgumentNullException>(), "The token credential constructor should perform validation.");
            Assert.That(() => new PartitionReceiver("cg", "pid", EventPosition.Earliest, "fqns", "eh", default(AzureNamedKeyCredential)), Throws.InstanceOf<ArgumentNullException>(), "The shared key credential constructor should perform validation.");
            Assert.That(() => new PartitionReceiver("cg", "pid", EventPosition.Earliest, "fqns", "eh", default(AzureSasCredential)), Throws.InstanceOf<ArgumentNullException>(), "The SAS credential constructor should perform validation.");
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
        public void TokenCredentialConstructorSetsTheRetryPolicy()
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
        public void SharedKeyCredentialConstructorSetsTheRetryPolicy()
        {
            var expected = Mock.Of<EventHubsRetryPolicy>();
            var options = new PartitionReceiverOptions { RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = expected } };
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, "fqns", "eh", new AzureNamedKeyCredential("key", "value"), options);

            Assert.That(GetRetryPolicy(receiver), Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void SasCredentialConstructorSetsTheRetryPolicy()
        {
            var expected = Mock.Of<EventHubsRetryPolicy>();
            var options = new PartitionReceiverOptions { RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = expected } };
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, "fqns", "eh", new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value), options);

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
        public void ConnectionStringConstructorSetsTheIdentifier()
        {
            var expected = "Test-Identifier";
            var options = new PartitionReceiverOptions { Identifier = expected };
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, connectionString, options);

            Assert.That(receiver.Identifier, Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void TokenCredentialConstructorSetsTheIdentifier()
        {
            var expected = "Test-Identifier";
            var options = new PartitionReceiverOptions { Identifier = expected };
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, "fqns", "eh", Mock.Of<TokenCredential>(), options);

            Assert.That(receiver.Identifier, Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void SharedKeyCredentialConstructorSetsTheIdentifier()
        {
            var expected = "Test-Identifier";
            var options = new PartitionReceiverOptions { Identifier = expected };
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, "fqns", "eh", new AzureNamedKeyCredential("key", "value"), options);

            Assert.That(receiver.Identifier, Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void SasCredentialConstructorSetsTheIdentifier()
        {
            var expected = "Test-Identifier";
            var options = new PartitionReceiverOptions { Identifier = expected };
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, "fqns", "eh", new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value), options);

            Assert.That(receiver.Identifier, Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionConstructorSetsTheIdentifier()
        {
            var expected = "Test-Identifier";
            var options = new PartitionReceiverOptions { Identifier = expected };
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, Mock.Of<EventHubConnection>(), options);

            Assert.That(receiver.Identifier, Is.SameAs(expected));
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
        public void TokenCredentialConstructorSetsTheDefaultMaximumWaitTime()
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
        public void SharedKeyCredentialConstructorSetsTheDefaultMaximumWaitTime()
        {
            var expected = TimeSpan.FromMinutes(1);
            var options = new PartitionReceiverOptions { DefaultMaximumReceiveWaitTime = expected };
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, "fqns", "eh", new AzureNamedKeyCredential("key", "value"), options);

            Assert.That(GetDefaultMaximumWaitTime(receiver), Is.EqualTo(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void SasCredentialConstructorSetsTheDefaultMaximumWaitTime()
        {
            var expected = TimeSpan.FromMinutes(1);
            var options = new PartitionReceiverOptions { DefaultMaximumReceiveWaitTime = expected };
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, "fqns", "eh", new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value), options);

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
        public void ConnectionStringConstructorCreatesDefaultOptions()
        {
            var defaultOptions = new PartitionReceiverOptions();
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, connectionString);

            Assert.That(receiver.Identifier, Is.Not.Null.And.Not.Empty, "A default identifier should have been generated.");
            Assert.That(GetDefaultMaximumWaitTime(receiver), Is.EqualTo(defaultOptions.DefaultMaximumReceiveWaitTime), "The constructor should have set the correct default maximum receive wait time.");
            Assert.That(GetRetryOptions(receiver).IsEquivalentTo(defaultOptions.RetryOptions), Is.True, $"The retry options should be equivalent.");

            var connectionOptions = GetConnectionOptions(receiver);
            Assert.That(connectionOptions.TransportType, Is.EqualTo(defaultOptions.ConnectionOptions.TransportType), $"The constructor should have set the correct connection type.");
            Assert.That(connectionOptions.Proxy, Is.EqualTo(defaultOptions.ConnectionOptions.Proxy), $"The constructor should have set the correct proxy.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void TokenCredentialConstructorCreatesDefaultOptions()
        {
            var defaultOptions = new PartitionReceiverOptions();
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, "fqns", "eh", Mock.Of<TokenCredential>());

            Assert.That(receiver.Identifier, Is.Not.Null.And.Not.Empty, "A default identifier should have been generated.");
            Assert.That(GetDefaultMaximumWaitTime(receiver), Is.EqualTo(defaultOptions.DefaultMaximumReceiveWaitTime), "The constructor should have set the correct default maximum receive wait time.");
            Assert.That(GetRetryOptions(receiver).IsEquivalentTo(defaultOptions.RetryOptions), Is.True, $"The retry options should be equivalent.");

            var connectionOptions = GetConnectionOptions(receiver);
            Assert.That(connectionOptions.TransportType, Is.EqualTo(defaultOptions.ConnectionOptions.TransportType), $"The constructor should have set the correct connection type.");
            Assert.That(connectionOptions.Proxy, Is.EqualTo(defaultOptions.ConnectionOptions.Proxy), $"The constructor should have set the correct proxy.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void SharedKeyCredentialConstructorCreatesDefaultOptions()
        {
            var defaultOptions = new PartitionReceiverOptions();
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, "fqns", "eh", new AzureNamedKeyCredential("key", "value"));

            Assert.That(receiver.Identifier, Is.Not.Null.And.Not.Empty, "A default identifier should have been generated.");
            Assert.That(GetDefaultMaximumWaitTime(receiver), Is.EqualTo(defaultOptions.DefaultMaximumReceiveWaitTime), "The constructor should have set the correct default maximum receive wait time.");
            Assert.That(GetRetryOptions(receiver).IsEquivalentTo(defaultOptions.RetryOptions), Is.True, $"The retry options should be equivalent.");

            var connectionOptions = GetConnectionOptions(receiver);
            Assert.That(connectionOptions.TransportType, Is.EqualTo(defaultOptions.ConnectionOptions.TransportType), $"The constructor should have set the correct connection type.");
            Assert.That(connectionOptions.Proxy, Is.EqualTo(defaultOptions.ConnectionOptions.Proxy), $"The constructor should have set the correct proxy.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void SasCredentialConstructorCreatesDefaultOptions()
        {
            var defaultOptions = new PartitionReceiverOptions();
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, "fqns", "eh", new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value));

            Assert.That(receiver.Identifier, Is.Not.Null.And.Not.Empty, "A default identifier should have been generated.");
            Assert.That(GetDefaultMaximumWaitTime(receiver), Is.EqualTo(defaultOptions.DefaultMaximumReceiveWaitTime), "The constructor should have set the correct default maximum receive wait time.");
            Assert.That(GetRetryOptions(receiver).IsEquivalentTo(defaultOptions.RetryOptions), Is.True, $"The retry options should be equivalent.");

            var connectionOptions = GetConnectionOptions(receiver);
            Assert.That(connectionOptions.TransportType, Is.EqualTo(defaultOptions.ConnectionOptions.TransportType), $"The constructor should have set the correct connection type.");
            Assert.That(connectionOptions.Proxy, Is.EqualTo(defaultOptions.ConnectionOptions.Proxy), $"The constructor should have set the correct proxy.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionConstructorCreatesDefaultOptions()
        {
            var defaultOptions = new PartitionReceiverOptions();
            var mockConnection = new Mock<EventHubConnection>();
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, mockConnection.Object);

            Assert.That(receiver.Identifier, Is.Not.Null.And.Not.Empty, "A default identifier should have been generated.");
            Assert.That(GetDefaultMaximumWaitTime(receiver), Is.EqualTo(defaultOptions.DefaultMaximumReceiveWaitTime), "The constructor should have set the correct default maximum receive wait time.");
            Assert.That(GetRetryOptions(receiver).IsEquivalentTo(defaultOptions.RetryOptions), Is.True, $"The retry options should be equivalent.");

            mockConnection
                .Verify(connection => connection.CreateTransportConsumer(
                    receiver.ConsumerGroup,
                    receiver.PartitionId,
                    It.Is<string>(value => !string.IsNullOrEmpty(value)),
                    receiver.InitialPosition,
                    GetRetryPolicy(receiver),
                    defaultOptions.TrackLastEnqueuedEventProperties,
                    It.IsAny<bool>(),
                    defaultOptions.OwnerLevel,
                    (uint?)defaultOptions.PrefetchCount,
                    defaultOptions.PrefetchSizeInBytes),
                Times.Once);
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
        public void TokenCredentialConstructorSetsTheConsumerGroup()
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
        public void SharedKeyCredentialConstructorSetsTheConsumerGroup()
        {
            var consumerGroup = "SomeGroup";
            var receiver = new PartitionReceiver(consumerGroup, "pid", EventPosition.Earliest, "fqns", "eh", new AzureNamedKeyCredential("key", "value"));

            Assert.That(receiver.ConsumerGroup, Is.EqualTo(consumerGroup));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void SasCredentialConstructorSetsTheConsumerGroup()
        {
            var consumerGroup = "SomeGroup";
            var receiver = new PartitionReceiver(consumerGroup, "pid", EventPosition.Earliest, "fqns", "eh", new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value));

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
        public void TokenCredentialConstructorSetsThePartitionId()
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
        public void SharedKeyCredentialConstructorSetsThePartitionId()
        {
            var partitionId = "partitionId";
            var receiver = new PartitionReceiver("cg", partitionId, EventPosition.Earliest, "fqns", "eh", new AzureNamedKeyCredential("key", "value"));

            Assert.That(receiver.PartitionId, Is.EqualTo(partitionId));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void SasCredentialConstructorSetsThePartitionId()
        {
            var partitionId = "partitionId";
            var receiver = new PartitionReceiver("cg", partitionId, EventPosition.Earliest, "fqns", "eh", new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value));

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
        public void TokenCredentialConstructorSetsTheInitialPosition()
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
        public void SharedKeyCredentialConstructorSetsTheInitialPosition()
        {
            var expectedPosition = EventPosition.FromOffset(999);
            var receiver = new PartitionReceiver("cg", "pid", expectedPosition, "fqns", "eh", new AzureNamedKeyCredential("key", "value"));

            Assert.That(receiver.InitialPosition, Is.EqualTo(expectedPosition));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void SasCredentialConstructorSetsTheInitialPosition()
        {
            var expectedPosition = EventPosition.FromOffset(999);
            var receiver = new PartitionReceiver("cg", "pid", expectedPosition, "fqns", "eh", new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value));

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
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void TokenCredentialConstructorParsesNamespaceFromUri()
        {
            var credential = Mock.Of<TokenCredential>();
            var host = "mynamespace.servicebus.windows.net";
            var namespaceUri = $"sb://{ host }";
            var receiver = new PartitionReceiver("cg","pid", EventPosition.Earliest, namespaceUri, "eventHub", credential);

            Assert.That(receiver.FullyQualifiedNamespace, Is.EqualTo(host), "The constructor should parse the namespace from the URI");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void SharedKeyCredentialConstructorParsesNamespaceFromUri()
        {
            var credential = new AzureNamedKeyCredential("key", "value");
            var host = "mynamespace.servicebus.windows.net";
            var namespaceUri = $"sb://{ host }";
            var receiver = new PartitionReceiver("cg","pid", EventPosition.Earliest, namespaceUri, "eventHub", credential);

            Assert.That(receiver.FullyQualifiedNamespace, Is.EqualTo(host), "The constructor should parse the namespace from the URI");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void SasCredentialConstructorParsesNamespaceFromUri()
        {
            var credential = new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value);
            var host = "mynamespace.servicebus.windows.net";
            var namespaceUri = $"sb://{ host }";
            var receiver = new PartitionReceiver("cg","pid", EventPosition.Earliest, namespaceUri, "eventHub", credential);

            Assert.That(receiver.FullyQualifiedNamespace, Is.EqualTo(host), "The constructor should parse the namespace from the URI");
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

            var expectedConsumerGroup = "consumerGroup";
            var expectedPartitionId = "partitionId";
            var expectedIdentifier = "customIdent!fi3r!";
            var expectedPosition = EventPosition.FromOffset(55);
            var expectedInvalidateOnSteal = false;

            var expectedOptions = new PartitionReceiverOptions
            {
                Identifier = expectedIdentifier,
                OwnerLevel = 99,
                PrefetchCount = 42,
                PrefetchSizeInBytes = 43,
                TrackLastEnqueuedEventProperties = false
            };

            var receiver = new PartitionReceiver(expectedConsumerGroup, expectedPartitionId, expectedPosition, mockConnection.Object, expectedOptions);

            mockConnection
                .Verify(connection => connection.CreateTransportConsumer(
                    expectedConsumerGroup,
                    expectedPartitionId,
                    expectedIdentifier,
                    expectedPosition,
                    GetRetryPolicy(receiver),
                    expectedOptions.TrackLastEnqueuedEventProperties,
                    expectedInvalidateOnSteal,
                    expectedOptions.OwnerLevel,
                    (uint?)expectedOptions.PrefetchCount,
                    expectedOptions.PrefetchSizeInBytes),
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
                eventBody: new BinaryData(Array.Empty<byte>()),
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
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<EventHubsRetryPolicy>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<long?>(),
                    It.IsAny<uint?>(),
                    It.IsAny<long?>()))
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
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<EventHubsRetryPolicy>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<long?>(),
                    It.IsAny<uint?>(),
                    It.IsAny<long?>()))
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
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<EventHubsRetryPolicy>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<long?>(),
                    It.IsAny<uint?>(),
                    It.IsAny<long?>()))
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
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<EventHubsRetryPolicy>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<long?>(),
                    It.IsAny<uint?>(),
                    It.IsAny<long?>()))
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
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<EventHubsRetryPolicy>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<long?>(),
                    It.IsAny<uint?>(),
                    It.IsAny<long?>()))
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
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<EventHubsRetryPolicy>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<long?>(),
                    It.IsAny<uint?>(),
                    It.IsAny<long?>()))
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
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<EventHubsRetryPolicy>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<long?>(),
                    It.IsAny<uint?>(),
                    It.IsAny<long?>()))
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
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<EventHubsRetryPolicy>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<long?>(),
                    It.IsAny<uint?>(),
                    It.IsAny<long?>()))
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
                    It.IsAny<string>(),
                    It.IsAny<EventPosition>(),
                    It.IsAny<EventHubsRetryPolicy>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<long?>(),
                    It.IsAny<uint?>(),
                    It.IsAny<long?>()))
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
        ///   Retrieves the options for the connection of the partition receiver using its private accessor.
        /// </summary>
        ///
        private static EventHubConnectionOptions GetConnectionOptions(PartitionReceiver partitionReceiver) =>
            (EventHubConnectionOptions)
                typeof(EventHubConnection)
                    .GetProperty("Options", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(GetConnection(partitionReceiver));

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
        ///   Retrieves the retry options for the partition receiver using its private accessor.
        /// </summary>
        ///
        private static EventHubsRetryOptions GetRetryOptions(PartitionReceiver partitionReceiver) =>
            (GetRetryPolicy(partitionReceiver) as BasicRetryPolicy)?.Options;

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
