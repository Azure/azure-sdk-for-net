// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Primitives;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventProcessor{TPartition}" />
    ///   class.
    /// </summary>
    ///
    /// <remarks>
    ///   This segment of the partial class depends on the types and members defined in the
    ///   <c>EventProcessorTests.cs</c> file.
    /// </remarks>
    ///
    public partial class EventProcessorTests
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

            yield return new object[] { new MinimalProcessorMock(99, "consumerGroup", connectionString), "connection string with default options" };
            yield return new object[] { new MinimalProcessorMock(99, "consumerGroup", connectionStringNoHub, "hub", default), "connection string with default options" };
            yield return new object[] { new MinimalProcessorMock(99, "consumerGroup", "namespace", "hub", credential, default(EventProcessorOptions)), "token credential with explicit null options" };
            yield return new object[] { new MinimalProcessorMock(99, "consumerGroup", "namespace", "hub", new AzureNamedKeyCredential("key", "value"), default(EventProcessorOptions)), "shared key credential with explicit null options" };
            yield return new object[] { new MinimalProcessorMock(99, "consumerGroup", "namespace", "hub", new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value), default(EventProcessorOptions)), "SAS credential with explicit null options" };
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
            Assert.That(() => new MinimalProcessorMock(constructorArgument, "dummyGroup", "dummyConnection", new EventProcessorOptions()), Throws.InstanceOf<ArgumentException>(), "The connection string constructor should validate the maximum batch size.");
            Assert.That(() => new MinimalProcessorMock(constructorArgument, "dummyGroup", "dummyNamespace", "dummyEventHub", Mock.Of<TokenCredential>(), new EventProcessorOptions()), Throws.InstanceOf<ArgumentException>(), "The token credential constructor should validate the maximum batch size.");
            Assert.That(() => new MinimalProcessorMock(constructorArgument, "dummyGroup", "dummyNamespace", "dummyEventHub", new AzureNamedKeyCredential("key", "value"), new EventProcessorOptions()), Throws.InstanceOf<ArgumentException>(), "The shared key credential constructor should validate the maximum batch size.");
            Assert.That(() => new MinimalProcessorMock(constructorArgument, "dummyGroup", "dummyNamespace", "dummyEventHub", new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value), new EventProcessorOptions()), Throws.InstanceOf<ArgumentException>(), "The SAS credential constructor should validate the maximum batch size.");
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
            Assert.That(() => new MinimalProcessorMock(1, constructorArgument, "dummyConnection", new EventProcessorOptions()), Throws.InstanceOf<ArgumentException>(), "The connection string constructor should validate the consumer group.");
            Assert.That(() => new MinimalProcessorMock(1, constructorArgument, "dummyNamespace", "dummyEventHub", Mock.Of<TokenCredential>(), new EventProcessorOptions()), Throws.InstanceOf<ArgumentException>(), "The token credential constructor should validate the consumer group.");
            Assert.That(() => new MinimalProcessorMock(1, constructorArgument, "dummyNamespace", "dummyEventHub", new AzureNamedKeyCredential("key", "value"), new EventProcessorOptions()), Throws.InstanceOf<ArgumentException>(), "The shared key credential constructor should validate the consumer group.");
            Assert.That(() => new MinimalProcessorMock(1, constructorArgument, "dummyNamespace", "dummyEventHub", new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value), new EventProcessorOptions()), Throws.InstanceOf<ArgumentException>(), "The SAS credential constructor should validate the consumer group.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheConnectionStringIsPopulated(string connectionString)
        {
            Assert.That(() => new MinimalProcessorMock(1, EventHubConsumerClient.DefaultConsumerGroupName, connectionString), Throws.InstanceOf<ArgumentException>(), "The constructor without options should ensure a connection string.");
            Assert.That(() => new MinimalProcessorMock(1, EventHubConsumerClient.DefaultConsumerGroupName, connectionString, "dummy", new EventProcessorOptions()), Throws.InstanceOf<ArgumentException>(), "The constructor with options should ensure a connection string.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCase("SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]")]
        [TestCase("Endpoint=value.com;SharedAccessKey=[value];EntityPath=[value]")]
        [TestCase("Endpoint=value.com;SharedAccessKeyName=[value];EntityPath=[value]")]
        [TestCase("Endpoint=value.com;SharedAccessKeyName=[value];SharedAccessKey=[value]")]
        [TestCase("HostName=value.azure-devices.net;SharedAccessKeyName=[value];SharedAccessKey=[value]")]
        [TestCase("HostName=value.azure-devices.net;SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]")]
        public void ConstructorValidatesConnectionString(string connectionString)
        {
            Assert.That(() => new MinimalProcessorMock(1, EventHubConsumerClient.DefaultConsumerGroupName, connectionString), Throws.ArgumentException.And.Message.StartsWith(Resources.MissingConnectionInformation));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorDetectsMultipleEventHubNamesFromTheConnectionString()
        {
            var eventHubName = "myHub";
            var connectionString = $"Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=[unique_fake]";

            Assert.That(() => new MinimalProcessorMock(1, EventHubConsumerClient.DefaultConsumerGroupName, connectionString, eventHubName), Throws.ArgumentException.And.Message.StartsWith(Resources.OnlyOneEventHubNameMayBeSpecified));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorAllowsMultipleEventHubNamesFromTheConnectionStringIfEqual()
        {
            var eventHubName = "myHub";
            var connectionString = $"Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath={ eventHubName }";

            Assert.That(() => new MinimalProcessorMock(1, EventHubConsumerClient.DefaultConsumerGroupName, connectionString, eventHubName), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("[1.2.3.4]")]
        public void ConstructorValidatesTheNamespace(string constructorArgument)
        {
            Assert.That(() => new MinimalProcessorMock(1, EventHubConsumerClient.DefaultConsumerGroupName, constructorArgument, "dummy", Mock.Of<TokenCredential>()), Throws.InstanceOf<ArgumentException>(), "The token credential constructor should validate.");
            Assert.That(() => new MinimalProcessorMock(1, EventHubConsumerClient.DefaultConsumerGroupName, constructorArgument, "dummy", new AzureNamedKeyCredential("key", "value")), Throws.InstanceOf<ArgumentException>(), "The shared key credential constructor should validate.");
            Assert.That(() => new MinimalProcessorMock(1, EventHubConsumerClient.DefaultConsumerGroupName, constructorArgument, "dummy", new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value)), Throws.InstanceOf<ArgumentException>(), "The SAS credential constructor should validate.");
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
            Assert.That(() => new MinimalProcessorMock(100, EventHubConsumerClient.DefaultConsumerGroupName, "namespace", constructorArgument, Mock.Of<TokenCredential>()), Throws.InstanceOf<ArgumentException>(), "The token credential constructor should validate.");
            Assert.That(() => new MinimalProcessorMock(100, EventHubConsumerClient.DefaultConsumerGroupName, "namespace", constructorArgument, new AzureNamedKeyCredential("key", "value")), Throws.InstanceOf<ArgumentException>(), "The shared key credential constructor should validate.");
            Assert.That(() => new MinimalProcessorMock(100, EventHubConsumerClient.DefaultConsumerGroupName, "namespace", constructorArgument, new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value)), Throws.InstanceOf<ArgumentException>(), "The SAS credential constructor should validate.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheCredential()
        {
            Assert.That(() => new MinimalProcessorMock(5, EventHubConsumerClient.DefaultConsumerGroupName, "namespace", "hubName", default(TokenCredential)), Throws.ArgumentNullException, "The token credential constructor should validate.");
            Assert.That(() => new MinimalProcessorMock(5, EventHubConsumerClient.DefaultConsumerGroupName, "namespace", "hubName", default(AzureNamedKeyCredential)), Throws.ArgumentNullException, "The shared key credential constructor should validate.");
            Assert.That(() => new MinimalProcessorMock(5, EventHubConsumerClient.DefaultConsumerGroupName, "namespace", "hubName", default(AzureSasCredential)), Throws.ArgumentNullException, "The SAS credential constructor should validate.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorCreatesDefaultOptionsCases))]
        public void ConstructorCreatesDefaultOptions(MinimalProcessorMock eventProcessor,
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

            var eventProcessor = new MinimalProcessorMock(1, "consumerGroup", "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub", options);

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
        public void TokenCredentialConstructorClonesTheConnectionOptions()
        {
            var expectedTransportType = EventHubsTransportType.AmqpWebSockets;
            var otherTransportType = EventHubsTransportType.AmqpTcp;

            var options = new EventProcessorOptions
            {
                ConnectionOptions = new EventHubConnectionOptions { TransportType = expectedTransportType }
            };

            var eventProcessor = new MinimalProcessorMock(11, "consumerGroup", "namespace", "hub", Mock.Of<TokenCredential>(), options);

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
        public void SharedKeyCredentialConstructorClonesTheConnectionOptions()
        {
            var expectedTransportType = EventHubsTransportType.AmqpWebSockets;
            var otherTransportType = EventHubsTransportType.AmqpTcp;

            var options = new EventProcessorOptions
            {
                ConnectionOptions = new EventHubConnectionOptions { TransportType = expectedTransportType }
            };

            var eventProcessor = new MinimalProcessorMock(11, "consumerGroup", "namespace", "hub", new AzureNamedKeyCredential("key", "value"), options);

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
        public void SasCredentialConstructorClonesTheConnectionOptions()
        {
            var expectedTransportType = EventHubsTransportType.AmqpWebSockets;
            var otherTransportType = EventHubsTransportType.AmqpTcp;

            var options = new EventProcessorOptions
            {
                ConnectionOptions = new EventHubConnectionOptions { TransportType = expectedTransportType }
            };

            var eventProcessor = new MinimalProcessorMock(11, "consumerGroup", "namespace", "hub", new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value), options);

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

            var eventProcessor = new MinimalProcessorMock(72, "consumerGroup", "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub", options);

            Assert.That(eventProcessor.Identifier, Is.Not.Null);
            Assert.That(eventProcessor.Identifier, Is.EqualTo(options.Identifier));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void TokenCredentialConstructorSetsTheIdentifier()
        {
            var options = new EventProcessorOptions
            {
                Identifier = Guid.NewGuid().ToString()
            };

            var eventProcessor = new MinimalProcessorMock(65, "consumerGroup", "namespace", "hub", Mock.Of<TokenCredential>(), options);

            Assert.That(eventProcessor.Identifier, Is.Not.Null);
            Assert.That(eventProcessor.Identifier, Is.EqualTo(options.Identifier));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void SharedKeyCredentialConstructorSetsTheIdentifier()
        {
            var options = new EventProcessorOptions
            {
                Identifier = Guid.NewGuid().ToString()
            };

            var eventProcessor = new MinimalProcessorMock(65, "consumerGroup", "namespace", "hub", new AzureNamedKeyCredential("key", "value"), options);

            Assert.That(eventProcessor.Identifier, Is.Not.Null);
            Assert.That(eventProcessor.Identifier, Is.EqualTo(options.Identifier));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessor{TPartition}" />
        ///   constructor.
        /// </summary>
        ///
        [Test]
        public void SasCredentialConstructorSetsTheIdentifier()
        {
            var options = new EventProcessorOptions
            {
                Identifier = Guid.NewGuid().ToString()
            };

            var eventProcessor = new MinimalProcessorMock(65, "consumerGroup", "namespace", "hub", new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value), options);

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

            var eventProcessor = new MinimalProcessorMock(34, "consumerGroup", "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub", options);

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
        public void TokenCredentialConstructorCreatesTheIdentifierWhenNotSpecified(string identifier)
        {
            var options = new EventProcessorOptions
            {
                Identifier = identifier
            };

            var eventProcessor = new MinimalProcessorMock(665, "consumerGroup", "namespace", "hub", Mock.Of<TokenCredential>(), options);

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
        public void SharedKeyCredentialConstructorCreatesTheIdentifierWhenNotSpecified(string identifier)
        {
            var options = new EventProcessorOptions
            {
                Identifier = identifier
            };

            var eventProcessor = new MinimalProcessorMock(665, "consumerGroup", "namespace", "hub", new AzureNamedKeyCredential("key", "value"), options);

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
        public void SasCredentialConstructorCreatesTheIdentifierWhenNotSpecified(string identifier)
        {
            var options = new EventProcessorOptions
            {
                Identifier = identifier
            };

            var eventProcessor = new MinimalProcessorMock(665, "consumerGroup", "namespace", "hub", new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value), options);

            Assert.That(eventProcessor.Identifier, Is.Not.Null);
            Assert.That(eventProcessor.Identifier, Is.Not.Empty);
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
            var eventProcessor = new MinimalProcessorMock(665, "consumerGroup", namespaceUri, "hub", credential);

            Assert.That(eventProcessor.FullyQualifiedNamespace, Is.EqualTo(host), "The constructor should parse the namespace from the URI");
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
            var eventProcessor = new MinimalProcessorMock(665, "consumerGroup", namespaceUri, "hub", credential);

            Assert.That(eventProcessor.FullyQualifiedNamespace, Is.EqualTo(host), "The constructor should parse the namespace from the URI");
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
            var eventProcessor = new MinimalProcessorMock(665, "consumerGroup", namespaceUri, "hub", credential);

            Assert.That(eventProcessor.FullyQualifiedNamespace, Is.EqualTo(host), "The constructor should parse the namespace from the URI");
        }
    }
}
