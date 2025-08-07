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
using Azure.Core.Shared;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Producer;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventHubProducerClient" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventHubProducerClientTests
    {
        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheConnectionStringIsPopulated(string connectionString)
        {
            Assert.That(() => new EventHubProducerClient(connectionString, "dummy"), Throws.InstanceOf<ArgumentException>(), "The constructor without options should ensure a connection string.");
            Assert.That(() => new EventHubProducerClient(connectionString, "dummy", new EventHubProducerClientOptions()), Throws.InstanceOf<ArgumentException>(), "The constructor with options should ensure a connection string.");
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
            Assert.That(() => new EventHubProducerClient(connectionString), Throws.ArgumentException.And.Message.StartsWith(Resources.MissingConnectionInformation));
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

            Assert.That(() => new EventHubProducerClient(connectionString, eventHubName), Throws.ArgumentException.And.Message.StartsWith(Resources.OnlyOneEventHubNameMayBeSpecified));
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

            Assert.That(() => new EventHubProducerClient(connectionString, eventHubName), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("[192.168.1.1]")]
        public void ConstructorValidatesTheNamespace(string constructorArgument)
        {
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            Assert.That(() => new EventHubProducerClient(constructorArgument, "dummy", credential.Object), Throws.InstanceOf<ArgumentException>(), "The token credential constructor should validate.");
            Assert.That(() => new EventHubProducerClient(constructorArgument, "dummy", new AzureNamedKeyCredential("key", "value")), Throws.InstanceOf<ArgumentException>(), "The shared key credential constructor should validate.");
            Assert.That(() => new EventHubProducerClient(constructorArgument, "dummy", new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value)), Throws.InstanceOf<ArgumentException>(), "The SAS credential constructor should validate.");
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
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            Assert.That(() => new EventHubProducerClient("namespace", constructorArgument, credential.Object), Throws.InstanceOf<ArgumentException>(), "The token credential constructor should validate.");
            Assert.That(() => new EventHubProducerClient("namespace", constructorArgument, new AzureNamedKeyCredential("key", "value")), Throws.InstanceOf<ArgumentException>(), "The shared key credential constructor should validate.");
            Assert.That(() => new EventHubProducerClient("namespace", constructorArgument, new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value)), Throws.InstanceOf<ArgumentException>(), "The SAS credential constructor should validate.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheCredential()
        {
            Assert.That(() => new EventHubProducerClient("namespace", "hubName", default(TokenCredential)), Throws.ArgumentNullException, "The token credential constructor should validate.");
            Assert.That(() => new EventHubProducerClient("namespace", "hubName", default(AzureNamedKeyCredential)), Throws.ArgumentNullException, "The shared key credential constructor should validate.");
            Assert.That(() => new EventHubProducerClient("namespace", "hubName", default(AzureSasCredential)), Throws.InstanceOf<ArgumentException>(), "The SAS credential constructor should validate.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheConnection()
        {
            Assert.That(() => new EventHubProducerClient(default(EventHubConnection)), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorSetsTheRetryPolicy()
        {
            var expected = Mock.Of<EventHubsRetryPolicy>();
            var options = new EventHubProducerClientOptions { RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = expected } };
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var producer = new EventHubProducerClient(connectionString, options);

            Assert.That(GetRetryPolicy(producer), Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void TokenCredentialConstructorSetsTheRetryPolicy()
        {
            var expected = Mock.Of<EventHubsRetryPolicy>();
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var options = new EventHubProducerClientOptions { RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = expected } };
            var producer = new EventHubProducerClient("namespace", "eventHub", credential.Object, options);

            Assert.That(GetRetryPolicy(producer), Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void SharedKeyCredentialConstructorSetsTheRetryPolicy()
        {
            var expected = Mock.Of<EventHubsRetryPolicy>();
            var credential = new AzureNamedKeyCredential("key", "value");
            var options = new EventHubProducerClientOptions { RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = expected } };
            var producer = new EventHubProducerClient("namespace", "eventHub", credential, options);

            Assert.That(GetRetryPolicy(producer), Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void SasCredentialConstructorSetsTheRetryPolicy()
        {
            var expected = Mock.Of<EventHubsRetryPolicy>();
            var credential = new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value);
            var options = new EventHubProducerClientOptions { RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = expected } };
            var producer = new EventHubProducerClient("namespace", "eventHub", credential, options);

            Assert.That(GetRetryPolicy(producer), Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionConstructorSetsTheRetryPolicy()
        {
            var expected = Mock.Of<EventHubsRetryPolicy>();
            var options = new EventHubProducerClientOptions { RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = expected } };
            var mockConnection = new MockConnection();
            var producer = new EventHubProducerClient(mockConnection, options);

            Assert.That(GetRetryPolicy(producer), Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorSetsTheIdentifier()
        {
            var expected = "Test-Identifier";
            var options = new EventHubProducerClientOptions { Identifier = expected };
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var producer = new EventHubProducerClient(connectionString, options);

            Assert.That(producer.Identifier, Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void TokenCredentialConstructorSetsTheIdentifier()
        {
            var expected = "Test-Identifier";
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var options = new EventHubProducerClientOptions { Identifier = expected };
            var producer = new EventHubProducerClient("namespace", "eventHub", credential.Object, options);

            Assert.That(producer.Identifier, Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void SharedKeyCredentialConstructorSetsTheIdentifier()
        {
            var expected = "Test-Identifier";
            var credential = new AzureNamedKeyCredential("key", "value");
            var options = new EventHubProducerClientOptions { Identifier = expected };
            var producer = new EventHubProducerClient("namespace", "eventHub", credential, options);

            Assert.That(producer.Identifier, Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void SasCredentialConstructorSetsTheIdentifier()
        {
            var expected = "Test-Identifier";
            var credential = new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value);
            var options = new EventHubProducerClientOptions { Identifier = expected };
            var producer = new EventHubProducerClient("namespace", "eventHub", credential, options);

            Assert.That(producer.Identifier, Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionConstructorSetsTheIdentifier()
        {
            var expected = "Test-Identifier";
            var options = new EventHubProducerClientOptions { Identifier = expected };
            var mockConnection = new MockConnection();
            var producer = new EventHubProducerClient(mockConnection, options);

            Assert.That(producer.Identifier, Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorCreatesDefaultOptions()
        {
            var expected = new EventHubProducerClientOptions().RetryOptions;
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";

            var producer = new EventHubProducerClient(connectionString);
            Assert.That(producer.Identifier, Is.Not.Null.And.Not.Empty, "A default identifier should have been generated.");

            var policy = GetRetryPolicy(producer);
            Assert.That(policy, Is.Not.Null, "There should have been a retry policy set.");
            Assert.That(policy, Is.InstanceOf<BasicRetryPolicy>(), "The default retry policy should be a basic policy.");

            var actual = ((BasicRetryPolicy)policy).Options;
            Assert.That(actual.IsEquivalentTo(expected), Is.True, "The default retry policy should be based on the default retry options.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void TokenCredentialsConstructorCreatesDefaultOptions()
        {
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var expected = new EventHubProducerClientOptions().RetryOptions;

            var producer = new EventHubProducerClient("namespace", "eventHub", credential.Object);
            Assert.That(producer.Identifier, Is.Not.Null.And.Not.Empty, "A default identifier should have been generated.");

            var policy = GetRetryPolicy(producer);
            Assert.That(policy, Is.Not.Null, "There should have been a retry policy set.");
            Assert.That(policy, Is.InstanceOf<BasicRetryPolicy>(), "The default retry policy should be a basic policy.");

            var actual = ((BasicRetryPolicy)policy).Options;
            Assert.That(actual.IsEquivalentTo(expected), Is.True, "The default retry policy should be based on the default retry options.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void SharedKeyCredentialsConstructorCreatesDefaultOptions()
        {
            var credential = new AzureNamedKeyCredential("key", "value");
            var expected = new EventHubProducerClientOptions().RetryOptions;

            var producer = new EventHubProducerClient("namespace", "eventHub", credential);
            Assert.That(producer.Identifier, Is.Not.Null.And.Not.Empty, "A default identifier should have been generated.");

            var policy = GetRetryPolicy(producer);
            Assert.That(policy, Is.Not.Null, "There should have been a retry policy set.");
            Assert.That(policy, Is.InstanceOf<BasicRetryPolicy>(), "The default retry policy should be a basic policy.");

            var actual = ((BasicRetryPolicy)policy).Options;
            Assert.That(actual.IsEquivalentTo(expected), Is.True, "The default retry policy should be based on the default retry options.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void SasCredentialsConstructorCreatesDefaultOptions()
        {
            var credential = new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value);
            var expected = new EventHubProducerClientOptions().RetryOptions;

            var producer = new EventHubProducerClient("namespace", "eventHub", credential);
            Assert.That(producer.Identifier, Is.Not.Null.And.Not.Empty, "A default identifier should have been generated.");

            var policy = GetRetryPolicy(producer);
            Assert.That(policy, Is.Not.Null, "There should have been a retry policy set.");
            Assert.That(policy, Is.InstanceOf<BasicRetryPolicy>(), "The default retry policy should be a basic policy.");

            var actual = ((BasicRetryPolicy)policy).Options;
            Assert.That(actual.IsEquivalentTo(expected), Is.True, "The default retry policy should be based on the default retry options.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionConstructorCreatesDefaultOptions()
        {
            var expected = new EventHubProducerClientOptions().RetryOptions;
            var mockConnection = new MockConnection();

            var producer = new EventHubProducerClient(mockConnection);
            Assert.That(producer.Identifier, Is.Not.Null.And.Not.Empty, "A default identifier should have been generated.");

            var policy = GetRetryPolicy(producer);
            Assert.That(policy, Is.Not.Null, "There should have been a retry policy set.");
            Assert.That(policy, Is.InstanceOf<BasicRetryPolicy>(), "The default retry policy should be a basic policy.");

            var actual = ((BasicRetryPolicy)policy).Options;
            Assert.That(actual.IsEquivalentTo(expected), Is.True, "The default retry policy should be based on the default retry options.");
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
            var producer = new EventHubProducerClient(namespaceUri, "eventHub", credential);

            Assert.That(producer.FullyQualifiedNamespace, Is.EqualTo(host), "The constructor should parse the namespace from the URI");
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
            var producer = new EventHubProducerClient(namespaceUri, "eventHub", credential);

            Assert.That(producer.FullyQualifiedNamespace, Is.EqualTo(host), "The constructor should parse the namespace from the URI");
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
            var producer = new EventHubProducerClient(namespaceUri, "eventHub", credential);

            Assert.That(producer.FullyQualifiedNamespace, Is.EqualTo(host), "The constructor should parse the namespace from the URI");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.FullyQualifiedNamespace" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void ProducerDelegatesForTheFullyQualifiedNamespace()
        {
            var expected = "SomeNamespace";
            var mockConnection = new MockConnection(expected);
            var producer = new EventHubProducerClient(mockConnection);
            Assert.That(producer.FullyQualifiedNamespace, Is.EqualTo(expected));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.EventHubName" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void ProducerDelegatesForTheEventHubName()
        {
            var expected = "EventHubName";
            var mockConnection = new MockConnection(eventHubName: expected);
            var producer = new EventHubProducerClient(mockConnection);
            Assert.That(producer.EventHubName, Is.EqualTo(expected));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.GetEventHubPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetEventHubPropertiesAsyncUsesTheRetryPolicy()
        {
            var mockConnection = new MockConnection();
            var retryPolicy = Mock.Of<EventHubsRetryPolicy>();
            var options = new EventHubProducerClientOptions { RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = retryPolicy } };
            var producer = new EventHubProducerClient(mockConnection, options);

            await producer.GetEventHubPropertiesAsync();
            Assert.That(mockConnection.GetPropertiesInvokedWith, Is.SameAs(retryPolicy), "Either the call was not delegated or the retry policy was not passed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.GetPartitionIdsAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetPartitionIdsUsesTheRetryPolicy()
        {
            var mockConnection = new MockConnection();
            var retryPolicy = Mock.Of<EventHubsRetryPolicy>();
            var options = new EventHubProducerClientOptions { RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = retryPolicy } };
            var producer = new EventHubProducerClient(mockConnection, options);

            await producer.GetPartitionIdsAsync();
            Assert.That(mockConnection.GetPartitionIdsInvokedWith, Is.SameAs(retryPolicy), "Either the call was not delegated or the retry policy was not passed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.GetPartitionPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetPartitionPropertiesUsesTheRetryPolicy()
        {
            var mockConnection = new MockConnection();
            var retryPolicy = Mock.Of<EventHubsRetryPolicy>();
            var options = new EventHubProducerClientOptions { RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = retryPolicy } };
            var producer = new EventHubProducerClient(mockConnection, options);

            await producer.GetPartitionPropertiesAsync("1");
            Assert.That(mockConnection.GetPartitionPropertiesInvokedWith, Is.SameAs(retryPolicy), "Either the call was not delegated or the retry policy was not passed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.GetPartitionPublishingPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ReadPartitionPublishingPropertiesAsyncValidatesNotClosed()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var producer = new EventHubProducerClient(connectionString);
            await producer.CloseAsync(cancellationSource.Token);

            Assert.That(async () => await producer.GetPartitionPublishingPropertiesAsync("0", cancellationSource.Token), Throws.InstanceOf<EventHubsException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.GetPartitionPublishingPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ReadPartitionPublishingPropertiesAsyncValidatesThePartition(string partitionId)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var producer = new EventHubProducerClient(new MockConnection());
            Assert.That(async () => await producer.GetPartitionPublishingPropertiesAsync(partitionId, cancellationSource.Token), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.GetPartitionPublishingPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ReadPartitionPublishingPropertiesAsyncInitializesPartitionState()
        {
            var expectedPartition = "5";
            var expectedProperties = new PartitionPublishingProperties(true, 123, 456, 798);
            var mockTransport = new Mock<TransportProducer>();
            var connection = new MockConnection(() => mockTransport.Object);

            var clientOptions = new EventHubProducerClientOptions
            {
                EnableIdempotentPartitions = true
            };

            clientOptions.PartitionOptions.Add("0", new PartitionPublishingOptions());
            clientOptions.PartitionOptions.Add("1", new PartitionPublishingOptions());

            clientOptions.PartitionOptions.Add(expectedPartition, new PartitionPublishingOptions
            {
                ProducerGroupId = 999,
                OwnerLevel = 999,
                StartingSequenceNumber = 999
            });

            var producer = new EventHubProducerClient(connection, clientOptions);

            mockTransport
                .Setup(transportProducer => transportProducer.ReadInitializationPublishingPropertiesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedProperties)
                .Verifiable();

            var partitionStateCollection = GetPartitionState(producer);
            Assert.That(partitionStateCollection, Is.Not.Null, "The collection for partition state should have been initialized with the client.");

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            await producer.GetPartitionPublishingPropertiesAsync(expectedPartition, cancellationSource.Token);

            Assert.That(partitionStateCollection.TryGetValue(expectedPartition, out var partitionState), Is.True, "The state collection should have an entry for the partition.");
            Assert.That(partitionState.ProducerGroupId, Is.EqualTo(expectedProperties.ProducerGroupId), "The producer group should match.");
            Assert.That(partitionState.OwnerLevel, Is.EqualTo(expectedProperties.OwnerLevel), "The owner level should match.");
            Assert.That(partitionState.LastPublishedSequenceNumber, Is.EqualTo(expectedProperties.LastPublishedSequenceNumber), "The sequence number should match.");

            mockTransport.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.GetPartitionPublishingPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ReadPartitionPublishingPropertiesAsyncReturnsPartitionStateWhenIdempotentPublishingEnabled()
        {
            var expectedPartition = "5";
            var expectedProperties = new PartitionPublishingProperties(true, 123, 456, 798);
            var mockTransport = new Mock<TransportProducer>();
            var connection = new MockConnection(() => mockTransport.Object);

            var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions
            {
                EnableIdempotentPartitions = true
            });

            var partitionStateCollection = GetPartitionState(producer);
            Assert.That(partitionStateCollection, Is.Not.Null, "The collection for partition state should have been initialized with the client.");

            partitionStateCollection[expectedPartition] = new PartitionPublishingState(expectedPartition)
            {
                ProducerGroupId = expectedProperties.ProducerGroupId,
                OwnerLevel = expectedProperties.OwnerLevel,
                LastPublishedSequenceNumber = expectedProperties.LastPublishedSequenceNumber
            };

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var readProperties = await producer.GetPartitionPublishingPropertiesAsync(expectedPartition, cancellationSource.Token);

            Assert.That(readProperties, Is.Not.Null, "The read properties should have been created.");
            Assert.That(readProperties.ProducerGroupId, Is.EqualTo(expectedProperties.ProducerGroupId), "The producer group should match.");
            Assert.That(readProperties.OwnerLevel, Is.EqualTo(expectedProperties.OwnerLevel), "The owner level should match.");
            Assert.That(readProperties.LastPublishedSequenceNumber, Is.EqualTo(expectedProperties.LastPublishedSequenceNumber), "The sequence number should match.");

            mockTransport
                .Verify(transportProducer => transportProducer.ReadInitializationPublishingPropertiesAsync(
                    It.IsAny<CancellationToken>()),
                Times.Never,
                "Partition state should not have been initialized twice.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.GetPartitionPublishingPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ReadPartitionPublishingPropertiesAsyncReturnsEmptyPartitionStateWhenIdempotentPublishingDisabled()
        {
            var expectedPartition = "5";
            var expectedProperties = PartitionPublishingProperties.Empty;
            var mockTransport = new Mock<TransportProducer>();
            var connection = new MockConnection(() => mockTransport.Object);

            var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions
            {
                EnableIdempotentPartitions = false
            });

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var readProperties = await producer.GetPartitionPublishingPropertiesAsync(expectedPartition, cancellationSource.Token);

            Assert.That(readProperties, Is.Not.Null, "The read properties should have been created.");
            Assert.That(readProperties.ProducerGroupId, Is.EqualTo(expectedProperties.ProducerGroupId), "The producer group should match.");
            Assert.That(readProperties.OwnerLevel, Is.EqualTo(expectedProperties.OwnerLevel), "The owner level should match.");
            Assert.That(readProperties.LastPublishedSequenceNumber, Is.EqualTo(expectedProperties.LastPublishedSequenceNumber), "The sequence number should match.");

            mockTransport
                .Verify(transportProducer => transportProducer.ReadInitializationPublishingPropertiesAsync(
                    It.IsAny<CancellationToken>()),
                Times.Never,
                "Partition state should not have been initialized.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendWithoutOptionsRequiresEvents()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(() => transportProducer));

            Assert.That(async () => await producer.SendAsync(default(IEnumerable<EventData>)), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendRequiresEvents()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(() => transportProducer));

            Assert.That(async () => await producer.SendAsync(default(IEnumerable<EventData>), new SendEventOptions()), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendRequiresTheBatch()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(() => transportProducer));

            Assert.That(async () => await producer.SendAsync(default(EventDataBatch)), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendAllowsAPartitionHashKey()
        {
            var sendOptions = new SendEventOptions { PartitionKey = "testKey" };
            var events = new[] { new EventData(new byte[] { 0x44, 0x66, 0x88 }) };
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(() => transportProducer));

            Assert.That(async () => await producer.SendAsync(events, sendOptions), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendAllowsAPartitionHashKeyWithABatch()
        {
            var batchOptions = new CreateBatchOptions { PartitionKey = "testKey" };
            using var batch = EventHubsModelFactory.EventDataBatch(long.MaxValue, new List<EventData>(), batchOptions);

            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(() => transportProducer));

            Assert.That(async () => await producer.SendAsync(batch), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendForASpecificPartitionDoesNotAllowAPartitionHashKey()
        {
            var sendOptions = new SendEventOptions { PartitionKey = "testKey", PartitionId = "1" };
            var events = new[] { new EventData(new byte[] { 0x44, 0x66, 0x88 }) };
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(() => transportProducer));

            Assert.That(async () => await producer.SendAsync(events, sendOptions), Throws.InvalidOperationException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendForASpecificPartitionDoesNotAllowAPartitionHashKeyWithABatch()
        {
            var batchOptions = new CreateBatchOptions { PartitionKey = "testKey", PartitionId = "1" };
            using var batch = EventHubsModelFactory.EventDataBatch(long.MaxValue, new List<EventData>(), batchOptions);

            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(() => transportProducer));

            Assert.That(async () => await producer.SendAsync(batch), Throws.InvalidOperationException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendWithoutOptionsInvokesTheTransportProducer()
        {
            var events = new[] { new EventData(new BinaryData(Array.Empty<byte>())) };
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(() => transportProducer));

            await producer.SendAsync(events);

            (IEnumerable<EventData> calledWithEvents, SendEventOptions calledWithOptions) = transportProducer.SendCalledWith;

            Assert.That(calledWithEvents, Is.EquivalentTo(events), "The events should contain same elements.");
            Assert.That(calledWithOptions, Is.Not.Null, "A default set of options should be used.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendInvokesTheTransportProducer()
        {
            var events = new[] { new EventData(new BinaryData(Array.Empty<byte>())) };
            var options = new SendEventOptions();
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(() => transportProducer));

            await producer.SendAsync(events, options);

            (IEnumerable<EventData> calledWithEvents, SendEventOptions calledWithOptions) = transportProducer.SendCalledWith;

            Assert.That(calledWithEvents, Is.EquivalentTo(events), "The events should contain same elements.");
            Assert.That(calledWithOptions, Is.Not.SameAs(options), "The options should not be the same instance.");
            Assert.That(calledWithOptions.PartitionId, Is.EqualTo(options.PartitionId), "The partition id of the options should match.");
            Assert.That(calledWithOptions.PartitionKey, Is.SameAs(options.PartitionKey), "The partition key of the options should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendInvokesTheTransportProducerWithABatch()
        {
            var batchOptions = new CreateBatchOptions { PartitionKey = "testKey" };
            using var batch = EventHubsModelFactory.EventDataBatch(long.MaxValue, EventGenerator.CreateEvents(1).ToList(), batchOptions);

            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(() => transportProducer));

            await producer.SendAsync(batch);
            Assert.That(transportProducer.SendBatchCalledWith, Is.SameAs(batch), "The batch should be the same instance.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendIdempotentRequiresThePartition()
        {
            var events = EventGenerator.CreateEvents(5);
            var transportProducer = new ObservableTransportProducerMock();
            var connection = new MockConnection(() => transportProducer);

            var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions
            {
                EnableIdempotentPartitions = true
            });

            Assert.That(async () => await producer.SendAsync(events), Throws.InstanceOf<InvalidOperationException>(), "Idempotent publishing requires the send options.");

            var sendOptions = new SendEventOptions();
            Assert.That(async () => await producer.SendAsync(events, sendOptions), Throws.InstanceOf<InvalidOperationException>(), "Automatic routing cannot be used with idempotent publishing.");

            sendOptions.PartitionKey = "Still not allowed";
            Assert.That(async () => await producer.SendAsync(events, sendOptions), Throws.InstanceOf<InvalidOperationException>(), "A partition key cannot be used with idempotent publishing.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendIdempotentDoesNotAllowResending()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var connection = new MockConnection(() => transportProducer);

            var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions
            {
                EnableIdempotentPartitions = true
            });

            var events = EventGenerator.CreateEvents(5).Select(item =>
            {
                item.PendingPublishSequenceNumber = 5;
                item.CommitPublishingState();

                return item;
            });

            var sendOptions = new SendEventOptions { PartitionId = "0" };
            Assert.That(async () => await producer.SendAsync(events, sendOptions), Throws.InstanceOf<InvalidOperationException>(), "Resending of events cannot be done with idempotent publishing.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendIdempotentCreatesTheTransportWithTheCorrectOptions()
        {
            var expectedPartition = "5";
            var eventCount = 1;
            var expectedProperties = new PartitionPublishingProperties(true, 123, 456, 798);
            var expectedLastSequence = expectedProperties.LastPublishedSequenceNumber + eventCount;
            var expectedOptions = new PartitionPublishingOptions();
            var requestedOptions = default(PartitionPublishingOptions);
            var requestedFeatures = TransportProducerFeatures.None;
            var sendOptions = new SendEventOptions { PartitionId = expectedPartition };
            var events = EventGenerator.CreateEvents(eventCount);
            var mockTransport = new Mock<TransportProducer>();

            expectedOptions.ProducerGroupId = expectedProperties.ProducerGroupId;
            expectedOptions.OwnerLevel = expectedProperties.OwnerLevel;
            expectedOptions.StartingSequenceNumber = expectedOptions.StartingSequenceNumber;

            var clientOptions = new EventHubProducerClientOptions
            {
                EnableIdempotentPartitions = true
            };

            clientOptions.PartitionOptions.Add(expectedPartition, expectedOptions);
            clientOptions.PartitionOptions.Add("0", new PartitionPublishingOptions());
            clientOptions.PartitionOptions.Add("1", new PartitionPublishingOptions());

            var connection = new MockConnection((partition, identifier, feature, options, retry) =>
            {
                requestedFeatures = feature;
                requestedOptions = options;

                return mockTransport.Object;
            });

            var producer = new EventHubProducerClient(connection, clientOptions);

            mockTransport
                .Setup(transportProducer => transportProducer.ReadInitializationPublishingPropertiesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedProperties)
                .Verifiable();

            await producer.SendAsync(events, sendOptions);

            Assert.That(requestedFeatures, Is.EqualTo(TransportProducerFeatures.IdempotentPublishing), "The idempotent feature should have been requested.");
            Assert.That(requestedOptions.ProducerGroupId, Is.EqualTo(expectedOptions.ProducerGroupId), "The wrong producer group option was used to create the transport client.");
            Assert.That(requestedOptions.OwnerLevel, Is.EqualTo(expectedOptions.OwnerLevel), "The wrong owner level option was used to create the transport client.");
            Assert.That(requestedOptions.StartingSequenceNumber, Is.EqualTo(expectedOptions.StartingSequenceNumber), "The wrong sequence number option was used to create the transport client.");

            mockTransport.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendIdempotentInitializesPartitionState()
        {
            var expectedPartition = "5";
            var eventCount = 1;
            var expectedProperties = new PartitionPublishingProperties(true, 123, 456, 798);
            var expectedLastSequence = expectedProperties.LastPublishedSequenceNumber + eventCount;
            var events = EventGenerator.CreateEvents(eventCount);
            var sendOptions = new SendEventOptions { PartitionId = expectedPartition };
            var mockTransport = new Mock<TransportProducer>();
            var connection = new MockConnection(() => mockTransport.Object);

            var clientOptions = new EventHubProducerClientOptions
            {
                EnableIdempotentPartitions = true
            };

            clientOptions.PartitionOptions.Add("0", new PartitionPublishingOptions());
            clientOptions.PartitionOptions.Add("1", new PartitionPublishingOptions());

            clientOptions.PartitionOptions.Add(expectedPartition, new PartitionPublishingOptions
            {
                ProducerGroupId = 999,
                OwnerLevel = 999,
                StartingSequenceNumber = 999
            });

            var producer = new EventHubProducerClient(connection, clientOptions);

            mockTransport
                .Setup(transportProducer => transportProducer.ReadInitializationPublishingPropertiesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedProperties)
                .Verifiable();

            var partitionStateCollection = GetPartitionState(producer);
            Assert.That(partitionStateCollection, Is.Not.Null, "The collection for partition state should have been initialized with the client.");

            await producer.SendAsync(events, sendOptions);

            Assert.That(partitionStateCollection.TryGetValue(expectedPartition, out var partitionState), Is.True, "The state collection should have an entry for the partition.");
            Assert.That(partitionState.ProducerGroupId, Is.EqualTo(expectedProperties.ProducerGroupId), "The producer group should match.");
            Assert.That(partitionState.OwnerLevel, Is.EqualTo(expectedProperties.OwnerLevel), "The owner level should match.");
            Assert.That(partitionState.LastPublishedSequenceNumber, Is.EqualTo(expectedLastSequence), "The sequence number should match.");

            mockTransport.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendIdempotentFailsIfPartitionStateCannotBeInitialized()
        {
            var expectedPartition = "5";
            var expectedProperties = new PartitionPublishingProperties(true, null, null, null);
            var events = EventGenerator.CreateEvents(1);
            var sendOptions = new SendEventOptions { PartitionId = expectedPartition };
            var mockTransport = new Mock<TransportProducer>();
            var connection = new MockConnection(() => mockTransport.Object);

            var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions
            {
                EnableIdempotentPartitions = true
            });

            mockTransport
                .Setup(transportProducer => transportProducer.ReadInitializationPublishingPropertiesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedProperties)
                .Verifiable();

            var partitionStateCollection = GetPartitionState(producer);
            Assert.That(partitionStateCollection, Is.Not.Null, "The collection for partition state should have been initialized with the client.");

            Assert.That(async () => await producer.SendAsync(events, sendOptions),
                Throws.InstanceOf<EventHubsException>().With.Property("Reason").EqualTo(EventHubsException.FailureReason.InvalidClientState),
                "The client should not allow an uninitialized partition state.");

            mockTransport.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendIdempotentHonorsCancellationIfSetWhenCalled()
        {
            var expectedPartition = "5";
            var events = EventGenerator.CreateEvents(1);
            var sendOptions = new SendEventOptions { PartitionId = expectedPartition };
            var mockTransport = new Mock<TransportProducer>();
            var connection = new MockConnection(() => mockTransport.Object);

            var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions
            {
                EnableIdempotentPartitions = true
            });

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(async () => await producer.SendAsync(events, sendOptions, cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendIdempotentHonorsCancellationIfSetWhenInitializingPartitionState()
        {
            var expectedPartition = "5";
            var expectedProperties = new PartitionPublishingProperties(true, 123, 456, 798);
            var events = EventGenerator.CreateEvents(1);
            var sendOptions = new SendEventOptions { PartitionId = expectedPartition };
            var mockTransport = new Mock<TransportProducer>();
            var connection = new MockConnection(() => mockTransport.Object);

            var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions
            {
                EnableIdempotentPartitions = true
            });

            using var cancellationSource = new CancellationTokenSource();

            mockTransport
                .Setup(transportProducer => transportProducer.ReadInitializationPublishingPropertiesAsync(It.IsAny<CancellationToken>()))
                .Callback(() => cancellationSource.Cancel())
                .ReturnsAsync(expectedProperties)
                .Verifiable();

            Assert.That(async () => await producer.SendAsync(events, sendOptions, cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
            mockTransport.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendIdempotentAppliesSequenceNumbers()
        {
            var expectedPartition = "5";
            var eventCount = 5;
            var startingSequence = 435;
            var expectedProperties = new PartitionPublishingProperties(true, 123, 456, startingSequence);
            var events = EventGenerator.CreateEvents(eventCount).ToArray();
            var sendOptions = new SendEventOptions { PartitionId = expectedPartition };
            var mockTransport = new Mock<TransportProducer>();
            var connection = new MockConnection(() => mockTransport.Object);

            var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions
            {
                EnableIdempotentPartitions = true
            });

            mockTransport
                .Setup(transportProducer => transportProducer.ReadInitializationPublishingPropertiesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedProperties);

            mockTransport
                .Setup(transportProducer => transportProducer.SendAsync(It.IsAny<IReadOnlyCollection<EventData>>(), It.IsAny<SendEventOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask)
                .Verifiable("The events should have been sent using the transport producer.");

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            await producer.SendAsync(events, sendOptions);

            for (var index = 0; index < events.Length; ++index)
            {
                Assert.That(events[index].PublishedSequenceNumber, Is.EqualTo(startingSequence + 1 + index), $"The event in position `{ index }` was not in the proper sequence.");
                Assert.That(events[index].PendingPublishSequenceNumber, Is.Null, $"The event in position `{ index }` should not have a pending sequence number remaining.");
            }

            var partitionStateCollection = GetPartitionState(producer);
            Assert.That(partitionStateCollection, Is.Not.Null, "The collection for partition state should have been initialized with the client.");
            Assert.That(partitionStateCollection.TryGetValue(expectedPartition, out var partitionState), Is.True, "The state collection should have an entry for the partition.");
            Assert.That(partitionState.LastPublishedSequenceNumber, Is.EqualTo(startingSequence + events.Length), "The sequence number for partition state should have been updated.");

            mockTransport.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendIdempotentRollsOverSequenceNumbersToZero()
        {
            var expectedPartition = "5";
            var eventCount = 5;
            var startingSequence = int.MaxValue;
            var expectedProperties = new PartitionPublishingProperties(true, 123, 456, startingSequence);
            var events = EventGenerator.CreateEvents(eventCount).ToArray();
            var sendOptions = new SendEventOptions { PartitionId = expectedPartition };
            var mockTransport = new Mock<TransportProducer>();
            var connection = new MockConnection(() => mockTransport.Object);

            var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions
            {
                EnableIdempotentPartitions = true
            });

            mockTransport
                .Setup(transportProducer => transportProducer.ReadInitializationPublishingPropertiesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedProperties);

            mockTransport
                .Setup(transportProducer => transportProducer.SendAsync(It.IsAny<IReadOnlyCollection<EventData>>(), It.IsAny<SendEventOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask)
                .Verifiable("The events should have been sent using the transport producer.");

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            await producer.SendAsync(events, sendOptions, cancellationSource.Token);

            for (var index = 0; index < events.Length; ++index)
            {
                Assert.That(events[index].PublishedSequenceNumber, Is.EqualTo(index), $"The event in position `{ index }` was not in the proper sequence.");
                Assert.That(events[index].PendingPublishSequenceNumber, Is.Null, $"The event in position `{ index }` should not have a pending sequence number remaining.");
            }

            var partitionStateCollection = GetPartitionState(producer);
            Assert.That(partitionStateCollection, Is.Not.Null, "The collection for partition state should have been initialized with the client.");
            Assert.That(partitionStateCollection.TryGetValue(expectedPartition, out var partitionState), Is.True, "The state collection should have an entry for the partition.");
            Assert.That(partitionState.LastPublishedSequenceNumber, Is.EqualTo(events.Length - 1), "The sequence number for partition state should have been updated.");

            mockTransport.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendIdempotentRollsBackSequenceNumbersOnFailure()
        {
            var expectedPartition = "5";
            var eventCount = 5;
            var startingSequence = 435;
            var expectedProperties = new PartitionPublishingProperties(true, 123, 456, startingSequence);
            var events = EventGenerator.CreateEvents(eventCount).ToArray();
            var sendOptions = new SendEventOptions { PartitionId = expectedPartition };
            var mockTransport = new Mock<TransportProducer>();
            var connection = new MockConnection(() => mockTransport.Object);

            var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions
            {
                EnableIdempotentPartitions = true
            });

            mockTransport
                .Setup(transportProducer => transportProducer.ReadInitializationPublishingPropertiesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedProperties);

            mockTransport
                .Setup(transportProducer => transportProducer.SendAsync(It.IsAny<IReadOnlyCollection<EventData>>(), It.IsAny<SendEventOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromException(new OverflowException()));

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            Assert.That(async () => await producer.SendAsync(events, sendOptions, cancellationSource.Token), Throws.Exception, "The send operation should have failed.");

            for (var index = 0; index < events.Length; ++index)
            {
                Assert.That(events[index].PublishedSequenceNumber, Is.Null, $"The event in position `{ index }`should not have a sequence number.");
                Assert.That(events[index].PendingPublishSequenceNumber, Is.Null, $"The event in position `{ index }` should not have a pending sequence number remaining.");
            }

            var partitionStateCollection = GetPartitionState(producer);
            Assert.That(partitionStateCollection, Is.Not.Null, "The collection for partition state should have been initialized with the client.");
            Assert.That(partitionStateCollection.TryGetValue(expectedPartition, out var partitionState), Is.True, "The state collection should have an entry for the partition.");
            Assert.That(partitionState.LastPublishedSequenceNumber, Is.Null, "The sequence number for partition state should have been reset.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendIdempotentUpdatesProducerGroupIdOnFailure()
        {
            var expectedPartition = "5";
            var eventCount = 5;
            var startingSequence = 435;
            var expectedProperties = new PartitionPublishingProperties(true, 123, 456, startingSequence);
            var events = EventGenerator.CreateEvents(eventCount).ToArray();
            var sendOptions = new SendEventOptions { PartitionId = expectedPartition };
            var mockTransport = new Mock<TransportProducer>();
            var connection = new MockConnection(() => mockTransport.Object);

            var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions
            {
                EnableIdempotentPartitions = true
            });

            mockTransport
                .Setup(transportProducer => transportProducer.ReadInitializationPublishingPropertiesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedProperties);

            mockTransport
                .Setup(transportProducer => transportProducer.SendAsync(It.IsAny<IReadOnlyCollection<EventData>>(), It.IsAny<SendEventOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromException(new OverflowException()));

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            Assert.That(async () => await producer.SendAsync(events, sendOptions, cancellationSource.Token), Throws.Exception, "The send operation should have failed.");

            var partitionStateCollection = GetPartitionState(producer);
            Assert.That(partitionStateCollection, Is.Not.Null, "The collection for partition state should have been initialized with the client.");
            Assert.That(partitionStateCollection.TryGetValue(expectedPartition, out var partitionState), Is.True, "The state collection should have an entry for the partition.");
            Assert.That(partitionState.ProducerGroupId, Is.Not.EqualTo(expectedProperties.ProducerGroupId), "The producer group identifier in partition state should have been changed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendIdempotentExpiresTheTransportProducerOnFailure()
        {
            var expectedPartition = "5";
            var eventCount = 5;
            var startingSequence = 435;
            var expectedProperties = new PartitionPublishingProperties(true, 123, 456, startingSequence);
            var events = EventGenerator.CreateEvents(eventCount).ToArray();
            var sendOptions = new SendEventOptions { PartitionId = expectedPartition };
            var mockTransport = new Mock<TransportProducer>();
            var connection = new MockConnection(() => mockTransport.Object);
            var mockTransportProducerPool = new MockTransportProducerPool(mockTransport.Object, connection, new BasicRetryPolicy(new EventHubsRetryOptions()));
            var producer = new EventHubProducerClient(connection, mockTransport.Object, mockTransportProducerPool, new EventHubProducerClientOptions { EnableIdempotentPartitions = true });

            mockTransport
                .Setup(transportProducer => transportProducer.ReadInitializationPublishingPropertiesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedProperties);

            mockTransport
                .Setup(transportProducer => transportProducer.SendAsync(It.IsAny<IReadOnlyCollection<EventData>>(), It.IsAny<SendEventOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromException(new OverflowException()));

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            Assert.That(async () => await producer.SendAsync(events, sendOptions, cancellationSource.Token), Throws.Exception, "The send operation should have failed.");
            Assert.That(mockTransportProducerPool.ExpirePooledProducerAsyncWasCalled, Is.True, "The transport producer should have been expired.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendIdempotentOrdersConcurrentRequests()
        {
            var expectedPartition = "5";
            var eventCount = 5;
            var startingSequence = 435;
            var expectedProperties = new PartitionPublishingProperties(true, 123, 456, startingSequence);
            var sendOptions = new SendEventOptions { PartitionId = expectedPartition };
            var mockTransport = new Mock<TransportProducer>();
            var connection = new MockConnection(() => mockTransport.Object);

            var events = new[]
            {
                EventGenerator.CreateEvents(eventCount).ToArray(),
                EventGenerator.CreateEvents(eventCount).ToArray(),
                EventGenerator.CreateEvents(eventCount).ToArray()
            };

            var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions
            {
                EnableIdempotentPartitions = true
            });

            mockTransport
                .Setup(transportProducer => transportProducer.ReadInitializationPublishingPropertiesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedProperties);

            // Each send operation will wait less time before completing to give later operations an
            // advantage to complete first if synchronization does not take place properly.

            var sendCountdown = events.Length;

            mockTransport
                .Setup(transportProducer => transportProducer.SendAsync(It.IsAny<IReadOnlyCollection<EventData>>(), It.IsAny<SendEventOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.Delay(TimeSpan.FromMilliseconds(150 * (--sendCountdown))));

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            await Task.WhenAll(events.Select(batch => producer.SendAsync(batch, sendOptions)));

            var eventPosition = 0;

            foreach (var batch in events)
            {
                for (var index = 0; index < batch.Length; ++index)
                {
                    ++eventPosition;

                    Assert.That(batch[index].PublishedSequenceNumber, Is.EqualTo(startingSequence + eventPosition), $"The event in position `{ eventPosition }` was not in the proper sequence.");
                    Assert.That(batch[index].PendingPublishSequenceNumber, Is.Null, $"The event in position `{ eventPosition }` should not have a pending sequence number remaining.");
                }
            }

            var partitionStateCollection = GetPartitionState(producer);
            Assert.That(partitionStateCollection, Is.Not.Null, "The collection for partition state should have been initialized with the client.");
            Assert.That(partitionStateCollection.TryGetValue(expectedPartition, out var partitionState), Is.True, "The state collection should have an entry for the partition.");
            Assert.That(partitionState.LastPublishedSequenceNumber, Is.EqualTo(startingSequence + (events.Length * eventCount)), "The sequence number for partition state should have been updated.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendIdempotentAllowsConcurrentRequestsToDifferentPartitions()
        {
            var eventCount = 5;
            var startingSequence = 435;
            var expectedProperties = new PartitionPublishingProperties(true, 123, 456, startingSequence);
            var mockTransport = new Mock<TransportProducer>();
            var connection = new MockConnection(() => mockTransport.Object);

            var events = new[]
            {
                EventGenerator.CreateEvents(eventCount).ToArray(),
                EventGenerator.CreateEvents(eventCount).ToArray(),
                EventGenerator.CreateEvents(eventCount).ToArray()
            };

            var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions
            {
                EnableIdempotentPartitions = true
            });

            mockTransport
                .Setup(transportProducer => transportProducer.ReadInitializationPublishingPropertiesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedProperties);

            // Each send operation will wait less time before completing to give later operations an
            // advantage to complete first if synchronization does not take place properly.

            var sendCountdown = events.Length;

            mockTransport
                .Setup(transportProducer => transportProducer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Returns(Task.Delay(TimeSpan.FromMilliseconds(150 * (--sendCountdown))));

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partition = 0L;
            await Task.WhenAll(events.Select(batch => producer.SendAsync(batch, new SendEventOptions { PartitionId = Interlocked.Increment(ref partition).ToString() })));

            for (var batchIndex = 0; batchIndex < events.Length; ++batchIndex)
            {
                var batch = events[batchIndex];

                for (var index = 0; index < batch.Length; ++index)
                {
                    Assert.That(batch[index].PublishedSequenceNumber, Is.EqualTo(startingSequence + 1 + index), $"The event in batch `{ batchIndex }` position `{ index }` was not in the proper sequence.");
                }
            }

            var partitionStateCollection = GetPartitionState(producer);
            Assert.That(partitionStateCollection, Is.Not.Null, "The collection for partition state should have been initialized with the client.");

            foreach (var stateKey in partitionStateCollection.Keys)
            {
                Assert.That(partitionStateCollection.TryGetValue(stateKey, out var partitionState), Is.True, $"The state collection should have an entry for the partition `{ stateKey }`.");
                Assert.That(partitionState.LastPublishedSequenceNumber, Is.EqualTo(startingSequence + eventCount), $"The sequence number for partition `{ stateKey }` state should have been updated.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendIdempotentRequiresThePartitionWithABatch()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var connection = new MockConnection(() => transportProducer);
            var eventList = EventGenerator.CreateEvents(2).ToList();

            var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions
            {
                EnableIdempotentPartitions = true
            });

            using var batch = EventHubsModelFactory.EventDataBatch(long.MaxValue, eventList);
            Assert.That(async () => await producer.SendAsync(batch), Throws.InstanceOf<InvalidOperationException>(), "Automatic routing cannot be used with idempotent publishing.");

            var batchOptions = new CreateBatchOptions { PartitionKey = "testKey" };
            using var newBatch = EventHubsModelFactory.EventDataBatch(long.MaxValue, eventList, batchOptions);
            Assert.That(async () => await producer.SendAsync(newBatch), Throws.InstanceOf<InvalidOperationException>(), "A partition key cannot be used with idempotent publishing.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendIdempotentDoesNotAllowResendingWithAPublishedBatch()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var connection = new MockConnection(() => transportProducer);

            var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions
            {
                EnableIdempotentPartitions = true
            });

            var events = EventGenerator.CreateEvents(5).ToList();
            using var batch = EventHubsModelFactory.EventDataBatch(long.MaxValue, events, new CreateBatchOptions { PartitionId = "0" });

            batch.ApplyBatchSequencing(0, null, null);
            Assert.That(async () => await producer.SendAsync(batch), Throws.InstanceOf<InvalidOperationException>(), "Resending of events cannot be done with idempotent publishing.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendIdempotentCreatesTheTransportWithTheCorrectOptionsWithABatch()
        {
            var expectedPartition = "5";
            var eventCount = 1;
            var expectedProperties = new PartitionPublishingProperties(true, 123, 456, 798);
            var expectedLastSequence = expectedProperties.LastPublishedSequenceNumber + eventCount;
            var expectedOptions = new PartitionPublishingOptions();
            var requestedOptions = default(PartitionPublishingOptions);
            var requestedFeatures = TransportProducerFeatures.None;
            var mockTransport = new Mock<TransportProducer>();

            using var batch = EventHubsModelFactory.EventDataBatch(long.MaxValue, EventGenerator.CreateEvents(eventCount).ToList(), new CreateBatchOptions { PartitionId = expectedPartition });

            expectedOptions.ProducerGroupId = expectedProperties.ProducerGroupId;
            expectedOptions.OwnerLevel = expectedProperties.OwnerLevel;
            expectedOptions.StartingSequenceNumber = expectedOptions.StartingSequenceNumber;

            var clientOptions = new EventHubProducerClientOptions
            {
                EnableIdempotentPartitions = true
            };

            clientOptions.PartitionOptions.Add(expectedPartition, expectedOptions);
            clientOptions.PartitionOptions.Add("0", new PartitionPublishingOptions());
            clientOptions.PartitionOptions.Add("1", new PartitionPublishingOptions());

            var connection = new MockConnection((partition, identifier, feature, options, retry) =>
            {
                requestedFeatures = feature;
                requestedOptions = options;

                return mockTransport.Object;
            });

            var producer = new EventHubProducerClient(connection, clientOptions);

            mockTransport
                .Setup(transportProducer => transportProducer.ReadInitializationPublishingPropertiesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedProperties)
                .Verifiable();

            await producer.SendAsync(batch);

            Assert.That(requestedFeatures, Is.EqualTo(TransportProducerFeatures.IdempotentPublishing), "The idempotent feature should have been requested.");
            Assert.That(requestedOptions.ProducerGroupId, Is.EqualTo(expectedOptions.ProducerGroupId), "The wrong producer group option was used to create the transport client.");
            Assert.That(requestedOptions.OwnerLevel, Is.EqualTo(expectedOptions.OwnerLevel), "The wrong owner level option was used to create the transport client.");
            Assert.That(requestedOptions.StartingSequenceNumber, Is.EqualTo(expectedOptions.StartingSequenceNumber), "The wrong sequence number option was used to create the transport client.");

            mockTransport.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendIdempotentInitializesPartitionStateWithABatch()
        {
            var expectedPartition = "5";
            var eventCount = 1;
            var expectedProperties = new PartitionPublishingProperties(true, 123, 456, 798);
            var expectedLastSequence = expectedProperties.LastPublishedSequenceNumber + eventCount;
            var mockTransport = new Mock<TransportProducer>();
            var connection = new MockConnection(() => mockTransport.Object);

            using var batch = EventHubsModelFactory.EventDataBatch(long.MaxValue, EventGenerator.CreateEvents(1).ToList(), new CreateBatchOptions { PartitionId = expectedPartition });

            var clientOptions = new EventHubProducerClientOptions
            {
                EnableIdempotentPartitions = true
            };

            clientOptions.PartitionOptions.Add("0", new PartitionPublishingOptions());
            clientOptions.PartitionOptions.Add("1", new PartitionPublishingOptions());

            clientOptions.PartitionOptions.Add(expectedPartition, new PartitionPublishingOptions
            {
                ProducerGroupId = 999,
                OwnerLevel = 999,
                StartingSequenceNumber = 999
            });

            var producer = new EventHubProducerClient(connection, clientOptions);

            mockTransport
                .Setup(transportProducer => transportProducer.ReadInitializationPublishingPropertiesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedProperties)
                .Verifiable();

            var partitionStateCollection = GetPartitionState(producer);
            Assert.That(partitionStateCollection, Is.Not.Null, "The collection for partition state should have been initialized with the client.");

            await producer.SendAsync(batch);

            Assert.That(partitionStateCollection.TryGetValue(expectedPartition, out var partitionState), Is.True, "The state collection should have an entry for the partition.");
            Assert.That(partitionState.ProducerGroupId, Is.EqualTo(expectedProperties.ProducerGroupId), "The producer group should match.");
            Assert.That(partitionState.OwnerLevel, Is.EqualTo(expectedProperties.OwnerLevel), "The owner level should match.");
            Assert.That(partitionState.LastPublishedSequenceNumber, Is.EqualTo(expectedLastSequence), "The sequence number should match.");

            mockTransport.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendIdempotentFailsIfPartitionStateCannotBeInitializedWithABatch()
        {
            var expectedPartition = "5";
            var expectedProperties = new PartitionPublishingProperties(true, null, null, null);
            var mockTransport = new Mock<TransportProducer>();
            var connection = new MockConnection(() => mockTransport.Object);

            using var batch = EventHubsModelFactory.EventDataBatch(long.MaxValue, EventGenerator.CreateEvents(1).ToList(), new CreateBatchOptions { PartitionId = expectedPartition });

            var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions
            {
                EnableIdempotentPartitions = true
            });

            mockTransport
                .Setup(transportProducer => transportProducer.ReadInitializationPublishingPropertiesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedProperties);

            var partitionStateCollection = GetPartitionState(producer);
            Assert.That(partitionStateCollection, Is.Not.Null, "The collection for partition state should have been initialized with the client.");

            Assert.That(async () => await producer.SendAsync(batch),
                Throws.InstanceOf<EventHubsException>().With.Property("Reason").EqualTo(EventHubsException.FailureReason.InvalidClientState),
                "The client should not allow an uninitialized partition state.");

            mockTransport.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendIdempotentHonorsCancellationIfSetWhenCalledWithABatch()
        {
            var expectedPartition = "5";
            var mockTransport = new Mock<TransportProducer>();
            var connection = new MockConnection(() => mockTransport.Object);

            using var batch = EventHubsModelFactory.EventDataBatch(long.MaxValue, EventGenerator.CreateEvents(1).ToList(), new CreateBatchOptions { PartitionId = expectedPartition });;

            var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions
            {
                EnableIdempotentPartitions = true
            });

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(async () => await producer.SendAsync(batch, cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendIdempotentHonorsCancellationIfSetWhenInitializingPartitionStateWithABatch()
        {
            var expectedPartition = "5";
            var expectedProperties = new PartitionPublishingProperties(true, 123, 456, 798);
            var mockTransport = new Mock<TransportProducer>();
            var connection = new MockConnection(() => mockTransport.Object);

            using var batch = EventHubsModelFactory.EventDataBatch(long.MaxValue, EventGenerator.CreateEvents(1).ToList(), new CreateBatchOptions { PartitionId = expectedPartition });

            var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions
            {
                EnableIdempotentPartitions = true
            });

            using var cancellationSource = new CancellationTokenSource();

            mockTransport
                .Setup(transportProducer => transportProducer.ReadInitializationPublishingPropertiesAsync(It.IsAny<CancellationToken>()))
                .Callback(() => cancellationSource.Cancel())
                .ReturnsAsync(expectedProperties)
                .Verifiable();

            var partitionStateCollection = GetPartitionState(producer);
            Assert.That(partitionStateCollection, Is.Not.Null, "The collection for partition state should have been initialized with the client.");

            Assert.That(async () => await producer.SendAsync(batch, cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
            mockTransport.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendIdempotentAppliesSequenceNumbersWithABatch()
        {
            var expectedPartition = "5";
            var eventCount = 6;
            var startingSequence = 435;
            var expectedProperties = new PartitionPublishingProperties(true, 123, 456, startingSequence);
            var mockTransport = new Mock<TransportProducer>();
            var connection = new MockConnection(() => mockTransport.Object);

            var events = EventGenerator.CreateEvents(eventCount).ToList();
            using var batch = EventHubsModelFactory.EventDataBatch(long.MaxValue, events, new CreateBatchOptions { PartitionId = expectedPartition });

            var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions
            {
                EnableIdempotentPartitions = true
            });

            mockTransport
                .Setup(transportProducer => transportProducer.ReadInitializationPublishingPropertiesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedProperties);

            mockTransport
                .Setup(transportProducer => transportProducer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask)
                .Verifiable("The events should have been sent using the transport producer.");

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            await producer.SendAsync(batch, cancellationSource.Token);
            Assert.That(batch.StartingPublishedSequenceNumber, Is.EqualTo(startingSequence + 1), "The batch did not have the correct starting sequence number.");

            var partitionStateCollection = GetPartitionState(producer);
            Assert.That(partitionStateCollection, Is.Not.Null, "The collection for partition state should have been initialized with the client.");
            Assert.That(partitionStateCollection.TryGetValue(expectedPartition, out var partitionState), Is.True, "The state collection should have an entry for the partition.");
            Assert.That(partitionState.LastPublishedSequenceNumber, Is.EqualTo(startingSequence + batch.Count), "The sequence number for partition state should have been updated.");

            mockTransport.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendIdempotentRollsBackSequenceNumbersOnFailureWithABatch()
        {
            var expectedPartition = "5";
            var eventCount = 6;
            var startingSequence = 435;
            var expectedProperties = new PartitionPublishingProperties(true, 123, 456, startingSequence);
            var mockTransport = new Mock<TransportProducer>();
            var connection = new MockConnection(() => mockTransport.Object);

            var events = EventGenerator.CreateEvents(eventCount).ToList();
            using var batch = EventHubsModelFactory.EventDataBatch(long.MaxValue, events, new CreateBatchOptions { PartitionId = expectedPartition });

            var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions
            {
                EnableIdempotentPartitions = true
            });

            mockTransport
                .Setup(transportProducer => transportProducer.ReadInitializationPublishingPropertiesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedProperties);

            mockTransport
                .Setup(transportProducer => transportProducer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromException(new OverflowException()));

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            Assert.That(async () => await producer.SendAsync(batch, cancellationSource.Token), Throws.Exception, "The send operation should have failed.");
            Assert.That(batch.StartingPublishedSequenceNumber, Is.Null, "The batch should not have a starting sequence number.");

            var partitionStateCollection = GetPartitionState(producer);
            Assert.That(partitionStateCollection, Is.Not.Null, "The collection for partition state should have been initialized with the client.");
            Assert.That(partitionStateCollection.TryGetValue(expectedPartition, out var partitionState), Is.True, "The state collection should have an entry for the partition.");
            Assert.That(partitionState.LastPublishedSequenceNumber, Is.Null, "The sequence number for partition state should have been reset.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendIdempotentUpdatesProducerGroupIdOnFailureWithABatch()
        {
            var expectedPartition = "5";
            var eventCount = 5;
            var startingSequence = 435;
            var expectedProperties = new PartitionPublishingProperties(true, 123, 456, startingSequence);
            var mockTransport = new Mock<TransportProducer>();
            var connection = new MockConnection(() => mockTransport.Object);

            var events = EventGenerator.CreateEvents(eventCount).ToList();
            using var batch = EventHubsModelFactory.EventDataBatch(long.MaxValue, events, new CreateBatchOptions { PartitionId = expectedPartition });

            var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions
            {
                EnableIdempotentPartitions = true
            });

            mockTransport
                .Setup(transportProducer => transportProducer.ReadInitializationPublishingPropertiesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedProperties);

            mockTransport
                .Setup(transportProducer => transportProducer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromException(new OverflowException()));

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            Assert.That(async () => await producer.SendAsync(batch, cancellationSource.Token), Throws.Exception, "The send operation should have failed.");

            var partitionStateCollection = GetPartitionState(producer);
            Assert.That(partitionStateCollection, Is.Not.Null, "The collection for partition state should have been initialized with the client.");
            Assert.That(partitionStateCollection.TryGetValue(expectedPartition, out var partitionState), Is.True, "The state collection should have an entry for the partition.");
            Assert.That(partitionState.ProducerGroupId, Is.Not.EqualTo(expectedProperties.ProducerGroupId), "The producer group identifier in partition state should have been changed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendIdempotentExpiresTheTransportProducerOnFailureWithABatch()
        {
            var expectedPartition = "5";
            var eventCount = 5;
            var startingSequence = 435;
            var expectedProperties = new PartitionPublishingProperties(true, 123, 456, startingSequence);
            var mockTransport = new Mock<TransportProducer>();
            var connection = new MockConnection(() => mockTransport.Object);
            var mockTransportProducerPool = new MockTransportProducerPool(mockTransport.Object, connection, new BasicRetryPolicy(new EventHubsRetryOptions()));
            var producer = new EventHubProducerClient(connection, mockTransport.Object, mockTransportProducerPool, new EventHubProducerClientOptions { EnableIdempotentPartitions = true });

            var events = EventGenerator.CreateEvents(eventCount).ToList();
            using var batch = EventHubsModelFactory.EventDataBatch(long.MaxValue, events, new CreateBatchOptions { PartitionId = expectedPartition });

            mockTransport
                .Setup(transportProducer => transportProducer.ReadInitializationPublishingPropertiesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedProperties);

            mockTransport
                .Setup(transportProducer => transportProducer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromException(new OverflowException()));

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            Assert.That(async () => await producer.SendAsync(batch, cancellationSource.Token), Throws.Exception, "The send operation should have failed.");
            Assert.That(mockTransportProducerPool.ExpirePooledProducerAsyncWasCalled, Is.True, "The transport producer should have been expired.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendIdempotentOrdersConcurrentRequestsWithABatch()
        {
            var expectedPartition = "5";
            var eventCount = 5;
            var startingSequence = 435;
            var expectedProperties = new PartitionPublishingProperties(true, 123, 456, startingSequence);
            var mockTransport = new Mock<TransportProducer>();
            var connection = new MockConnection(() => mockTransport.Object);

            var batches = new[]
            {
                EventHubsModelFactory.EventDataBatch(long.MaxValue, EventGenerator.CreateEvents(eventCount).ToList(), new CreateBatchOptions { PartitionId = expectedPartition }),
                EventHubsModelFactory.EventDataBatch(long.MaxValue, EventGenerator.CreateEvents(eventCount).ToList(), new CreateBatchOptions { PartitionId = expectedPartition }),
                EventHubsModelFactory.EventDataBatch(long.MaxValue, EventGenerator.CreateEvents(eventCount).ToList(), new CreateBatchOptions { PartitionId = expectedPartition })
            };

            var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions
            {
                EnableIdempotentPartitions = true
            });

            mockTransport
                .Setup(transportProducer => transportProducer.ReadInitializationPublishingPropertiesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedProperties);

            try
            {
            // Each send operation will wait less time before completing to give later operations an
                // advantage to complete first if synchronization does not take place properly.

                var sendCountdown = batches.Length;

                mockTransport
                    .Setup(transportProducer => transportProducer.SendAsync(It.IsAny<IReadOnlyCollection<EventData>>(), It.IsAny<SendEventOptions>(), It.IsAny<CancellationToken>()))
                    .Returns(Task.Delay(TimeSpan.FromMilliseconds(150 * (--sendCountdown))));

                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                await Task.WhenAll(batches.Select(batch => producer.SendAsync(batch)));

                for (var index = 0; index < batches.Length; ++index)
                {
                    var batch = batches[index];
                    Assert.That(batch.StartingPublishedSequenceNumber, Is.EqualTo(startingSequence + 1 + (index * eventCount)), $"The batch in position `{ index }` did not have the correct starting sequence number.");
                }

                var partitionStateCollection = GetPartitionState(producer);
                Assert.That(partitionStateCollection, Is.Not.Null, "The collection for partition state should have been initialized with the client.");
                Assert.That(partitionStateCollection.TryGetValue(expectedPartition, out var partitionState), Is.True, "The state collection should have an entry for the partition.");
                Assert.That(partitionState.LastPublishedSequenceNumber, Is.EqualTo(startingSequence + (batches.Length * eventCount)), "The sequence number for partition state should have been updated.");
            }
            finally
            {
                foreach (var batch in batches)
                {
                    batch.Dispose();
                }
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendIdempotentAllowsConcurrentRequestsToDifferentPartitionsWithABatch()
        {
            var eventCount = 5;
            var startingSequence = 435;
            var partition = 0;
            var expectedProperties = new PartitionPublishingProperties(true, 123, 456, startingSequence);
            var mockTransport = new Mock<TransportProducer>();
            var connection = new MockConnection(() => mockTransport.Object);

            var batches = new[]
            {
                EventHubsModelFactory.EventDataBatch(long.MaxValue, EventGenerator.CreateEvents(eventCount).ToList(), new CreateBatchOptions { PartitionId = (++partition).ToString() }),
                EventHubsModelFactory.EventDataBatch(long.MaxValue, EventGenerator.CreateEvents(eventCount).ToList(), new CreateBatchOptions { PartitionId = (++partition).ToString() }),
                EventHubsModelFactory.EventDataBatch(long.MaxValue, EventGenerator.CreateEvents(eventCount).ToList(), new CreateBatchOptions { PartitionId = (++partition).ToString() })
            };

            var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions
            {
                EnableIdempotentPartitions = true
            });

            mockTransport
                .Setup(transportProducer => transportProducer.ReadInitializationPublishingPropertiesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedProperties);

            try
            {
                // Each send operation will wait less time before completing to give later operations an
                // advantage to complete first if synchronization does not take place properly.

                var sendCountdown = batches.Length;

                mockTransport
                    .Setup(transportProducer => transportProducer.SendAsync(It.IsAny<IReadOnlyCollection<EventData>>(), It.IsAny<SendEventOptions>(), It.IsAny<CancellationToken>()))
                    .Returns(Task.Delay(TimeSpan.FromMilliseconds(150 * (--sendCountdown))));

                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                await Task.WhenAll(batches.Select(batch => producer.SendAsync(batch)));

                for (var index = 0; index < batches.Length; ++index)
                {
                    var batch = batches[index];
                    Assert.That(batch.StartingPublishedSequenceNumber, Is.EqualTo(startingSequence + 1), $"The batch in position `{ index }` did not have the correct starting sequence number.");
                }

                var partitionStateCollection = GetPartitionState(producer);
                Assert.That(partitionStateCollection, Is.Not.Null, "The collection for partition state should have been initialized with the client.");

                foreach (var stateKey in partitionStateCollection.Keys)
                {
                    Assert.That(partitionStateCollection.TryGetValue(stateKey, out var partitionState), Is.True, $"The state collection should have an entry for the partition `{ stateKey }`.");
                    Assert.That(partitionState.LastPublishedSequenceNumber, Is.EqualTo(startingSequence + eventCount), $"The sequence number for partition `{ stateKey }` state should have been updated.");
                }
            }
            finally
            {
                foreach (var batch in batches)
                {
                    batch.Dispose();
                }
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendManagesLockingTheBatch()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var batchOptions = new CreateBatchOptions { PartitionKey = "testKey" };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockTransportBatch = new Mock<TransportEventBatch>();
            var mockTransportProducer = new Mock<TransportProducer>();
            var batch = new EventDataBatch(mockTransportBatch.Object, "ns", "eh", batchOptions, new MessagingClientDiagnostics("mock", "mock", "mock", "mock", "mock"));
            var producer = new EventHubProducerClient(new MockConnection(() => mockTransportProducer.Object));

            mockTransportBatch
                .Setup(transport => transport.TryAdd(It.IsAny<EventData>()))
                .Returns(true);

            mockTransportBatch
                .Setup(transport => transport.Count)
                .Returns(1);

            mockTransportProducer
                .Setup(transport => transport.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Returns(async () => await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token)));

            Assert.That(batch.TryAdd(new EventData(new BinaryData(Array.Empty<byte>()))), Is.True, "The batch should not be locked before sending.");
            var sendTask = producer.SendAsync(batch);

            Assert.That(() => batch.TryAdd(new EventData(new BinaryData(Array.Empty<byte>()))), Throws.InstanceOf<InvalidOperationException>(), "The batch should be locked while sending.");
            completionSource.TrySetResult(true);

            await sendTask;
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            Assert.That(batch.TryAdd(new EventData(new BinaryData(Array.Empty<byte>()))), Is.True, "The batch should not be locked after sending.");

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.CreateBatchAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateBatchForASpecificPartitionDoesNotAllowAPartitionHashKey()
        {
            var batchOptions = new CreateBatchOptions { PartitionKey = "testKey", PartitionId = "1" };
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(() => transportProducer));

            Assert.That(async () => await producer.CreateBatchAsync(batchOptions), Throws.InvalidOperationException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.CreateBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateBatchInvokesTheTransportProducer()
        {
            var batchOptions = new CreateBatchOptions { PartitionKey = "Hi", MaximumSizeInBytes = 9999 };
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(() => transportProducer));

            await producer.CreateBatchAsync(batchOptions);

            Assert.That(transportProducer.CreateBatchCalledWith, Is.Not.Null, "The batch creation should have passed options.");
            Assert.That(transportProducer.CreateBatchCalledWith, Is.Not.SameAs(batchOptions), "The options should have been cloned.");
            Assert.That(transportProducer.CreateBatchCalledWith.PartitionKey, Is.EqualTo(batchOptions.PartitionKey), "The partition key should match.");
            Assert.That(transportProducer.CreateBatchCalledWith.MaximumSizeInBytes, Is.EqualTo(batchOptions.MaximumSizeInBytes), "The maximum size should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.CreateBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateBatchDefaultsBatchOptions()
        {
            var expectedOptions = new CreateBatchOptions();
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(() => transportProducer));

            await producer.CreateBatchAsync();

            Assert.That(transportProducer.CreateBatchCalledWith, Is.Not.Null, "The batch creation should have passed options.");
            Assert.That(transportProducer.CreateBatchCalledWith, Is.Not.SameAs(expectedOptions), "The options should have been cloned.");
            Assert.That(transportProducer.CreateBatchCalledWith.PartitionKey, Is.EqualTo(expectedOptions.PartitionKey), "The partition key should match.");
            Assert.That(transportProducer.CreateBatchCalledWith.MaximumSizeInBytes, Is.EqualTo(expectedOptions.MaximumSizeInBytes), "The maximum size should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.CreateBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateBatchSetsTheSendOptionsForTheEventBatch()
        {
            var batchOptions = new CreateBatchOptions { PartitionKey = "Hi", MaximumSizeInBytes = 9999 };
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(() => transportProducer));
            var eventBatch = await producer.CreateBatchAsync(batchOptions);

            Assert.That(eventBatch.SendOptions.PartitionId, Is.EqualTo(transportProducer.CreateBatchCalledWith.PartitionId), "The batch options should have used for the send options, but the partition identifier didn't match.");
            Assert.That(eventBatch.SendOptions.PartitionKey, Is.EqualTo(transportProducer.CreateBatchCalledWith.PartitionKey), "The batch options should have used for the send options, but the partition key didn't match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncClosesTheTransportProducers()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(() => transportProducer));

            using var mockFirstBatch = EventHubsModelFactory.EventDataBatch(long.MaxValue, EventGenerator.CreateEvents(1).ToList(), new CreateBatchOptions { PartitionId = "1" });
            using var mockSecondBatch = EventHubsModelFactory.EventDataBatch(long.MaxValue, EventGenerator.CreateEvents(1).ToList(), new CreateBatchOptions { PartitionId = "2" });

            await producer.SendAsync(mockFirstBatch).IgnoreExceptions();
            await producer.SendAsync(mockSecondBatch).IgnoreExceptions();
            await producer.CloseAsync();

            Assert.That(transportProducer.WasCloseCalled, Is.True);
            Assert.That(transportProducer.CloseCallCount, Is.EqualTo(3));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncSurfacesExceptionsForTransportProducers()
        {
            var mockTransportProducer = new Mock<TransportProducer>();
            var mockConnection = new MockConnection(() => mockTransportProducer.Object);
            var mockTransportProducerPool = new Mock<TransportProducerPool>();
            var producer = new EventHubProducerClient(mockConnection, mockTransportProducer.Object, mockTransportProducerPool.Object);

            using var mockBatch = EventHubsModelFactory.EventDataBatch(long.MaxValue, new List<EventData>(), new CreateBatchOptions { PartitionId = "1" });

            mockTransportProducerPool
                .Setup(pool => pool.CloseAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromException(new InvalidCastException()));

            await producer.SendAsync(mockBatch).IgnoreExceptions();
            Assert.That(async () => await producer.CloseAsync(), Throws.InstanceOf<InvalidCastException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncClosesTheConnectionWhenOwned()
        {
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var producer = new EventHubProducerClient(connectionString);

            await producer.CloseAsync();

            var connection = GetConnection(producer);
            Assert.That(connection.IsClosed, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncDoesNotCloseTheConnectionWhenNotOwned()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var connection = new MockConnection(() => transportProducer);
            var producer = new EventHubProducerClient(connection);

            await producer.CloseAsync();
            Assert.That(connection.IsClosed, Is.False);
        }

        /// <summary>
        ///   Verifies that when calling <see cref="EventHubProducerClient.SendAsync" />
        ///   a <see cref="TransportProducer"/> is taken from a <see cref="TransportProducerPool" />
        ///   when a partition id is specified.
        /// </summary>
        ///
        [Test]
        public async Task EventHubProducerClientShouldPickAnItemFromPool()
        {
            var options = new SendEventOptions { PartitionId = "0" };
            var transportProducer = new ObservableTransportProducerMock();
            var eventHubConnection = new MockConnection(() => transportProducer);
            var retryPolicy = new EventHubProducerClientOptions().RetryOptions.ToRetryPolicy();
            var mockTransportProducerPool = new MockTransportProducerPool(new ObservableTransportProducerMock(), eventHubConnection, retryPolicy);
            var mockPooledProducer = mockTransportProducerPool.GetPooledProducer(options.PartitionId) as MockPooledProducer;
            var producerClient = new EventHubProducerClient(eventHubConnection, transportProducer, mockTransportProducerPool);
            var events = new EventData[0];

            await producerClient.SendAsync(events, options);
            Assert.That(mockTransportProducerPool.GetPooledProducerWasCalled, Is.True, $"The method { nameof(TransportProducerPool.GetPooledProducer) } should have been called.");
        }

        /// <summary>
        ///   Verifies that when calling <see cref="EventHubProducerClient.SendAsync" /> for batches
        ///   a <see cref="TransportProducer"/> is taken from a <see cref="TransportProducerPool" /> when a partition id is specified.
        /// </summary>
        ///
        [Test]
        public async Task EventHubProducerClientShouldPickAnItemFromPoolWithABatch()
        {
            var batchOptions = new CreateBatchOptions { PartitionId = "0" };
            var transportProducer = new ObservableTransportProducerMock();
            var eventHubConnection = new MockConnection(() => transportProducer);
            var retryPolicy = new EventHubProducerClientOptions().RetryOptions.ToRetryPolicy();
            var mockTransportProducerPool = new MockTransportProducerPool(new ObservableTransportProducerMock(), eventHubConnection, retryPolicy);
            var mockPooledProducer = mockTransportProducerPool.GetPooledProducer(batchOptions.PartitionId) as MockPooledProducer;
            var producerClient = new EventHubProducerClient(eventHubConnection, transportProducer, mockTransportProducerPool);

            using var batch = EventHubsModelFactory.EventDataBatch(long.MaxValue, new List<EventData>(), batchOptions);

            await producerClient.SendAsync(batch);
            Assert.That(mockTransportProducerPool.GetPooledProducerWasCalled, Is.True, $"The method { nameof(TransportProducerPool.GetPooledProducer) } should have been called (for a batch).");
        }

        /// <summary>
        ///   Verifies that a <see cref="TransportProducerPool.PooledProducer.DisposeAsync()" /> is called
        ///   to signal the usage of a <see cref="TransportProducerPool.PooledProducer"/> has ended.
        /// </summary>
        ///
        /// <remarks>
        ///   Users of a <see cref="TransportProducerPool"/>, such as <see cref="EventHubProducerClient.SendAsync(EventData, CancellationToken)"/>,
        ///   can signal their usage of a <see cref="TransportProducerPool.PooledProducer"/> has ended
        ///   by invoking <see cref="TransportProducerPool.PooledProducer.DisposeAsync"/>.
        /// </remarks>
        ///
        [Test]
        public async Task EventHubProducerClientShouldCloseAProducerWithABatch()
        {
            var batchOptions = new CreateBatchOptions { PartitionId = "0" };
            var transportProducer = new ObservableTransportProducerMock();
            var eventHubConnection = new MockConnection(() => transportProducer);
            var retryPolicy = new EventHubProducerClientOptions().RetryOptions.ToRetryPolicy();
            var mockTransportProducerPool = new MockTransportProducerPool(new ObservableTransportProducerMock(), eventHubConnection, retryPolicy);
            var mockPooledProducer = mockTransportProducerPool.GetPooledProducer(batchOptions.PartitionId) as MockPooledProducer;
            var producerClient = new EventHubProducerClient(eventHubConnection, transportProducer, mockTransportProducerPool);

            using var batch = EventHubsModelFactory.EventDataBatch(long.MaxValue, EventGenerator.CreateEvents(1).ToList(), batchOptions);
            await producerClient.SendAsync(batch);

            Assert.That(mockPooledProducer.WasClosed, Is.True, $"A { nameof(TransportProducerPool.PooledProducer) } should be closed when disposed.");
        }

        /// <summary>
        ///   Verifies that a <see cref="TransportProducerPool.PooledProducer.DisposeAsync()" /> is called
        ///   to signal the usage of a <see cref="TransportProducerPool.PooledProducer"/> has ended.
        /// </summary>
        ///
        /// <remarks>
        ///   Users of a <see cref="TransportProducerPool"/>, such as <see cref="EventHubProducerClient.SendAsync(EventDataBatch, CancellationToken)"/>,
        ///   can signal their usage of a <see cref="TransportProducerPool.PooledProducer"/> has ended
        ///   by invoking <see cref="TransportProducerPool.PooledProducer.DisposeAsync"/>.
        /// </remarks>
        ///
        [Test]
        public async Task EventHubProducerClientShouldCloseAProducer()
        {
            var options = new SendEventOptions { PartitionId = "0" };
            var events = new[] { new EventData(new BinaryData(Array.Empty<byte>())) };
            var transportProducer = new ObservableTransportProducerMock();
            var eventHubConnection = new MockConnection(() => transportProducer);
            var retryPolicy = new EventHubProducerClientOptions().RetryOptions.ToRetryPolicy();
            var mockTransportProducerPool = new MockTransportProducerPool(new ObservableTransportProducerMock(), eventHubConnection, retryPolicy);
            var mockPooledProducer = mockTransportProducerPool.GetPooledProducer(options.PartitionId) as MockPooledProducer;
            var producerClient = new EventHubProducerClient(eventHubConnection, transportProducer, mockTransportProducerPool);

            await producerClient.SendAsync(events, options);
            Assert.That(mockPooledProducer.WasClosed, Is.True, $"A { nameof(TransportProducerPool.PooledProducer) } should be closed when disposed (for a batch).");
        }

        /// <summary>
        ///   Verifies that an <see cref="EventHubProducerClient" /> retries sending an
        ///   event if a partition producer returned by the pool was closed due to a race condition between an
        ///   AMQP operation and a request to close a client.
        /// </summary>
        ///
        [Test]
        public void EventHubProducerClientShouldRetrySending()
        {
            var options = new SendEventOptions { PartitionId = "0" };
            var transportProducer = new Mock<TransportProducer>();
            var eventHubConnection = new MockConnection(() => transportProducer.Object);
            var retryPolicy = new EventHubProducerClientOptions().RetryOptions.ToRetryPolicy();
            var mockTransportProducerPool = new MockTransportProducerPool(transportProducer.Object, eventHubConnection, retryPolicy);
            var mockPooledProducer = mockTransportProducerPool.GetPooledProducer(options.PartitionId) as MockPooledProducer;
            var producerClient = new EventHubProducerClient(eventHubConnection, transportProducer.Object, mockTransportProducerPool);
            var events = new[] { new EventData(new BinaryData(Array.Empty<byte>())) };

            transportProducer
                .Setup(transportProducer => transportProducer.SendAsync(It.IsAny<IReadOnlyCollection<EventData>>(),
                                                                        It.IsAny<SendEventOptions>(),
                                                                        It.IsAny<CancellationToken>()))
                .Throws(new EventHubsException(false, "test", EventHubsException.FailureReason.ClientClosed));

            transportProducer
                .SetupGet(transportProducer => transportProducer.IsClosed)
                .Returns(true);

            Assert.That(async () => await producerClient.SendAsync(events, options), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));

            transportProducer.Verify(t => t.SendAsync(It.IsAny<IReadOnlyCollection<EventData>>(),
                                                      It.IsAny<SendEventOptions>(),
                                                      It.IsAny<CancellationToken>()),
                                     Times.Exactly(EventHubProducerClient.MaximumCreateProducerAttempts),
                                     $"The retry logic should have called { nameof(TransportProducer.SendAsync) } { EventHubProducerClient.MaximumCreateProducerAttempts } times.");
        }

        /// <summary>
        ///   Verifies that an <see cref="EventHubProducerClient" /> retries sending an
        ///   event if a partition producer returned by the pool was closed due to a race condition between an
        ///   AMQP operation and a request to close a client.
        /// </summary>
        ///
        [Test]
        public void EventHubProducerClientShouldRetrySendingWithABatch()
        {
            var batchOptions = new CreateBatchOptions { PartitionId = "0" };
            var transportProducer = new Mock<TransportProducer>();
            var eventHubConnection = new MockConnection(() => transportProducer.Object);
            var retryPolicy = new EventHubProducerClientOptions().RetryOptions.ToRetryPolicy();
            var mockTransportProducerPool = new MockTransportProducerPool(transportProducer.Object, eventHubConnection, retryPolicy);
            var producerClient = new EventHubProducerClient(eventHubConnection, transportProducer.Object, mockTransportProducerPool);

            transportProducer
                .Setup(transportProducer => transportProducer.SendAsync(It.IsAny<EventDataBatch>(),
                                                                        It.IsAny<CancellationToken>()))
                .Throws(new EventHubsException(false, "test", EventHubsException.FailureReason.ClientClosed));

            transportProducer
                .SetupGet(transportProducer => transportProducer.IsClosed)
                .Returns(true);

            using var batch = EventHubsModelFactory.EventDataBatch(long.MaxValue, EventGenerator.CreateEvents(1).ToList(), batchOptions);
            Assert.That(async () => await producerClient.SendAsync(batch), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));

            transportProducer.Verify(t => t.SendAsync(It.IsAny<EventDataBatch>(),
                                                      It.IsAny<CancellationToken>()),
                                     Times.Exactly(EventHubProducerClient.MaximumCreateProducerAttempts),
                                     $"The retry logic should have called { nameof(TransportProducer.SendAsync) } { EventHubProducerClient.MaximumCreateProducerAttempts } times (for a batch).");
        }

        /// <summary>
        ///   Verifies that the retry logic does not loop endlessly.
        /// </summary>
        ///
        [Test]
        public void RetryLogicEnds()
        {
            var options = new SendEventOptions { PartitionId = "0" };
            var events = new EventData[0];
            var transportProducer = new Mock<TransportProducer>();
            var eventHubConnection = new MockConnection(() => transportProducer.Object);
            var retryPolicy = new EventHubProducerClientOptions().RetryOptions.ToRetryPolicy();
            var mockTransportProducerPool = new MockTransportProducerPool(new ObservableTransportProducerMock(), eventHubConnection, retryPolicy);
            var mockPooledProducer = mockTransportProducerPool.GetPooledProducer(options.PartitionId) as MockPooledProducer;
            var producerClient = new EventHubProducerClient(eventHubConnection, transportProducer.Object, mockTransportProducerPool);
            var numberOfCalls = 0;

            transportProducer
                .Setup(transportProducer => transportProducer.SendAsync(It.IsAny<IReadOnlyCollection<EventData>>(),
                                                                        It.IsAny<SendEventOptions>(),
                                                                        It.IsAny<CancellationToken>()))
                .Callback(() =>
                {
                    if (++numberOfCalls < EventHubProducerClient.MaximumCreateProducerAttempts)
                    {
                        throw new EventHubsException(false, string.Empty, EventHubsException.FailureReason.ClientClosed);
                    }
                })
                .Returns(Task.CompletedTask);

            Assert.That(async () => await producerClient.SendAsync(events, options), Throws.Nothing, $"The retry logic should not run endlessly.");
        }

        /// <summary>
        ///   Verifies that the retry logic does not loop endlessly for batches.
        /// </summary>
        ///
        [Test]
        public void RetryLogicEndsWithABatch()
        {
            var batchOptions = new CreateBatchOptions { PartitionId = "0" };
            var transportProducer = new Mock<TransportProducer>();
            var eventHubConnection = new MockConnection(() => transportProducer.Object);
            var retryPolicy = new EventHubProducerClientOptions().RetryOptions.ToRetryPolicy();
            var mockTransportProducerPool = new MockTransportProducerPool(new ObservableTransportProducerMock(), eventHubConnection, retryPolicy);
            var mockPooledProducer = mockTransportProducerPool.GetPooledProducer(batchOptions.PartitionId) as MockPooledProducer;
            var producerClient = new EventHubProducerClient(eventHubConnection, transportProducer.Object, mockTransportProducerPool);
            var numberOfCalls = 0;

            transportProducer
                .Setup(transportProducer => transportProducer.SendAsync(It.IsAny<EventDataBatch>(),
                                                                        It.IsAny<CancellationToken>()))
                .Callback(() =>
                {
                    if (++numberOfCalls < EventHubProducerClient.MaximumCreateProducerAttempts)
                    {
                        throw new EventHubsException(false, string.Empty, EventHubsException.FailureReason.ClientClosed);
                    }
                })
                .Returns(Task.CompletedTask);

            using var batch = EventHubsModelFactory.EventDataBatch(long.MaxValue, new List<EventData>(), batchOptions);
            Assert.That(async () => await producerClient.SendAsync(batch), Throws.Nothing, $"The retry logic should not run endlessly (for a batch).");
        }

        /// <summary>
        ///   Retry logic does not kick-in for the main-stream scenario (i.e. partition id is null).
        /// </summary>
        ///
        [Test]
        public void RetryLogicDoesNotStartWhenPartitionIdIsNull()
        {
            var options = new SendEventOptions { PartitionId = "0" };
            var events = new[] { new EventData(new BinaryData(Array.Empty<byte>())) };
            var transportProducer = new Mock<TransportProducer>();
            var eventHubConnection = new MockConnection(() => transportProducer.Object);
            var retryPolicy = new EventHubProducerClientOptions().RetryOptions.ToRetryPolicy();
            var mockTransportProducerPool = new MockTransportProducerPool(transportProducer.Object, eventHubConnection, retryPolicy);
            var mockPooledProducer = mockTransportProducerPool.GetPooledProducer(options.PartitionId) as MockPooledProducer;
            var producerClient = new EventHubProducerClient(eventHubConnection, transportProducer.Object, mockTransportProducerPool);

            transportProducer
                .Setup(transportProducer => transportProducer.SendAsync(It.IsAny<IReadOnlyCollection<EventData>>(),
                                                                        It.IsAny<SendEventOptions>(),
                                                                        It.IsAny<CancellationToken>()))
                .Throws(new EventHubsException(false, "test", EventHubsException.FailureReason.ClientClosed));

            Assert.That(async () => await producerClient.SendAsync(events, options), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));

            transportProducer.Verify(t => t.SendAsync(It.IsAny<IReadOnlyCollection<EventData>>(),
                                                      It.IsAny<SendEventOptions>(),
                                                      It.IsAny<CancellationToken>()),
                                     Times.Once,
                                     $"The retry logic should not start when the partition id is null.");
        }

        /// <summary>
        ///   Retry logic does not kick-in for the main-stream scenario (i.e. partition id is null).
        /// </summary>
        ///
        [Test]
        public void RetryLogicDoesNotStartWhenPartitionIdIsNullWithABatch()
        {
            var batchOptions = new CreateBatchOptions { PartitionId = "0" };
            var transportProducer = new Mock<TransportProducer>();
            var eventHubConnection = new MockConnection(() => transportProducer.Object);
            var retryPolicy = new EventHubProducerClientOptions().RetryOptions.ToRetryPolicy();
            var mockTransportProducerPool = new MockTransportProducerPool(transportProducer.Object, eventHubConnection, retryPolicy);
            var mockPooledProducer = mockTransportProducerPool.GetPooledProducer(batchOptions.PartitionId) as MockPooledProducer;
            var producerClient = new EventHubProducerClient(eventHubConnection, transportProducer.Object, mockTransportProducerPool);

            transportProducer
                .Setup(transportProducer => transportProducer.SendAsync(It.IsAny<EventDataBatch>(),
                                                                        It.IsAny<CancellationToken>()))
                .Throws(new EventHubsException(false, "test", EventHubsException.FailureReason.ClientClosed));

            using var batch = EventHubsModelFactory.EventDataBatch(long.MaxValue, EventGenerator.CreateEvents(1).ToList(), batchOptions);
            Assert.That(async () => await producerClient.SendAsync(batch), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));

            transportProducer.Verify(t => t.SendAsync(It.IsAny<EventDataBatch>(),
                                                      It.IsAny<CancellationToken>()),
                                     Times.Once,
                                     $"The retry logic should not start when the partition id is null (for a batch).");
        }

        /// <summary>
        ///   Retry logic starts only when the <see cref="EventHubConnection"/> owned by an <see cref="EventHubProducerClient"/> is open.
        /// </summary>
        ///
        [Test]
        public async Task RetryLogicDoesNotWorkForClosedConnections()
        {
            var options = new SendEventOptions { PartitionId = "0" };
            var events = new[] { new EventData(new BinaryData(Array.Empty<byte>())) };
            var transportProducer = new Mock<TransportProducer>();
            var eventHubConnection = new MockConnection(() => transportProducer.Object);
            var retryPolicy = new EventHubProducerClientOptions().RetryOptions.ToRetryPolicy();
            var mockTransportProducerPool = new MockTransportProducerPool(transportProducer.Object, eventHubConnection, retryPolicy);
            var mockPooledProducer = mockTransportProducerPool.GetPooledProducer(options.PartitionId) as MockPooledProducer;
            var producerClient = new EventHubProducerClient(eventHubConnection, transportProducer.Object, mockTransportProducerPool);

            transportProducer
                .Setup(transportProducer => transportProducer.SendAsync(It.IsAny<IReadOnlyCollection<EventData>>(),
                                                                        It.IsAny<SendEventOptions>(),
                                                                        It.IsAny<CancellationToken>()))
                .Throws(new EventHubsException(false, "test", EventHubsException.FailureReason.ClientClosed));

            transportProducer
                .SetupGet(transportProducer => transportProducer.IsClosed)
                .Returns(true);

            await eventHubConnection.CloseAsync(CancellationToken.None);

            Assert.That(async () => await producerClient.SendAsync(events, options), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));

            transportProducer.Verify(t => t.SendAsync(It.IsAny<IReadOnlyCollection<EventData>>(),
                                                      It.IsAny<SendEventOptions>(),
                                                      It.IsAny<CancellationToken>()),
                                     Times.Once,
                                     $"The retry logic should not start when the { nameof(EventHubConnection) } was closed.");
        }

        /// <summary>
        ///   Retry logic starts only when the <see cref="EventHubConnection"/> owned by an <see cref="EventHubProducerClient"/> is open.
        /// </summary>
        ///
        [Test]
        public async Task RetryLogicDoesNotWorkForClosedConnectionsWithABatch()
        {
            var batchOptions = new CreateBatchOptions { PartitionId = "0" };
            var transportProducer = new Mock<TransportProducer>();
            var eventHubConnection = new MockConnection(() => transportProducer.Object);
            var retryPolicy = new EventHubProducerClientOptions().RetryOptions.ToRetryPolicy();
            var mockTransportProducerPool = new MockTransportProducerPool(transportProducer.Object, eventHubConnection, retryPolicy);
            var mockPooledProducer = mockTransportProducerPool.GetPooledProducer(batchOptions.PartitionId) as MockPooledProducer;
            var producerClient = new EventHubProducerClient(eventHubConnection, transportProducer.Object, mockTransportProducerPool);

            transportProducer
                .Setup(transportProducer => transportProducer.SendAsync(It.IsAny<EventDataBatch>(),
                                                                        It.IsAny<CancellationToken>()))
                .Throws(new EventHubsException(false, "test", EventHubsException.FailureReason.ClientClosed));

            transportProducer
                .SetupGet(transportProducer => transportProducer.IsClosed)
                .Returns(true);

            using var batch = EventHubsModelFactory.EventDataBatch(long.MaxValue, EventGenerator.CreateEvents(1).ToList(), batchOptions);

            await eventHubConnection.CloseAsync(CancellationToken.None);
            Assert.That(async () => await producerClient.SendAsync(batch), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));

            transportProducer.Verify(t => t.SendAsync(It.IsAny<EventDataBatch>(),
                                                      It.IsAny<CancellationToken>()),
                                     Times.Once,
                                     $"The retry logic should not start when the { nameof(EventHubConnection) } was closed (for a batch).");
        }

        /// <summary>
        ///   Retry logic starts only when the an <see cref="EventHubProducerClient"/> is open.
        /// </summary>
        ///
        [Test]
        public void RetryLogicDoesNotWorkForClosedEventHubProducerClients()
        {
            var options = new SendEventOptions { PartitionId = "0" };
            var events = new[] { new EventData(new BinaryData(Array.Empty<byte>())) };
            var transportProducer = new Mock<TransportProducer>();
            var eventHubConnection = new MockConnection(() => transportProducer.Object);
            var retryPolicy = new EventHubProducerClientOptions().RetryOptions.ToRetryPolicy();
            var mockTransportProducerPool = new MockTransportProducerPool(transportProducer.Object, eventHubConnection, retryPolicy);
            var mockPooledProducer = mockTransportProducerPool.GetPooledProducer(options.PartitionId) as MockPooledProducer;
            var producerClient = new EventHubProducerClient(eventHubConnection, transportProducer.Object, mockTransportProducerPool);

            transportProducer
                .Setup(transportProducer => transportProducer.SendAsync(It.IsAny<IReadOnlyCollection<EventData>>(),
                                                                        It.IsAny<SendEventOptions>(),
                                                                        It.IsAny<CancellationToken>()))
                .Throws(new EventHubsException(false, "test", EventHubsException.FailureReason.ClientClosed));

            transportProducer
                .SetupGet(transportProducer => transportProducer.IsClosed)
                .Returns(true);

            SetIsClosed(producerClient, true);

            Assert.That(async () => await producerClient.SendAsync(events, options), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));

            transportProducer.Verify(t => t.SendAsync(It.IsAny<IReadOnlyCollection<EventData>>(),
                                                      It.IsAny<SendEventOptions>(),
                                                      It.IsAny<CancellationToken>()),
                                     Times.Once,
                                     $"The retry logic should not start when a { nameof(TransportProducer) } was closed.");
        }

        /// <summary>
        ///   Retry logic starts only when the an <see cref="EventHubProducerClient"/> is open.
        /// </summary>
        ///
        [Test]
        public void RetryLogicDoesNotWorkForClosedEventHubProducerClientsWithABatch()
        {
            var batchOptions = new CreateBatchOptions { PartitionId = "0" };
            var transportProducer = new Mock<TransportProducer>();
            var eventHubConnection = new MockConnection(() => transportProducer.Object);
            var retryPolicy = new EventHubProducerClientOptions().RetryOptions.ToRetryPolicy();
            var mockTransportProducerPool = new MockTransportProducerPool(transportProducer.Object, eventHubConnection, retryPolicy);
            var mockPooledProducer = mockTransportProducerPool.GetPooledProducer(batchOptions.PartitionId) as MockPooledProducer;
            var producerClient = new EventHubProducerClient(eventHubConnection, transportProducer.Object, mockTransportProducerPool);

            transportProducer
                .Setup(transportProducer => transportProducer.SendAsync(It.IsAny<EventDataBatch>(),
                                                                        It.IsAny<CancellationToken>()))
                .Throws(new EventHubsException(false, "test", EventHubsException.FailureReason.ClientClosed));

            transportProducer
                .SetupGet(transportProducer => transportProducer.IsClosed)
                .Returns(true);

            SetIsClosed(producerClient, true);

            using var batch = EventHubsModelFactory.EventDataBatch(long.MaxValue, EventGenerator.CreateEvents(1).ToList(), batchOptions);
            Assert.That(async () => await producerClient.SendAsync(batch), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));

            transportProducer.Verify(t => t.SendAsync(It.IsAny<EventDataBatch>(),
                                                      It.IsAny<CancellationToken>()),
                                     Times.Once,
                                     $"The retry logic should not start when a { nameof(TransportProducer) } was closed (for a batch).");
        }

        /// <summary>
        ///   Retry logic would not start after a cancellation is requested.
        /// </summary>
        ///
        [Test]
        public void RetryLogicShouldNotStartWhenCancellationTriggered()
        {
            var options = new SendEventOptions { PartitionId = "0" };
            var events = new[] { new EventData(new BinaryData(Array.Empty<byte>())) };
            var transportProducer = new Mock<TransportProducer>();
            var eventHubConnection = new MockConnection(() => transportProducer.Object);
            var retryPolicy = new EventHubProducerClientOptions().RetryOptions.ToRetryPolicy();
            var mockTransportProducerPool = new MockTransportProducerPool(transportProducer.Object, eventHubConnection, retryPolicy);
            var producerClient = new EventHubProducerClient(eventHubConnection, transportProducer.Object, mockTransportProducerPool);
            var cancellationTokenSource = new CancellationTokenSource();

            cancellationTokenSource.Cancel();

            Assert.That(async () => await producerClient.SendAsync(events, options, cancellationTokenSource.Token), Throws.InstanceOf<OperationCanceledException>());

            transportProducer.Verify(t => t.SendAsync(It.IsAny<IReadOnlyCollection<EventData>>(),
                                                      It.IsAny<SendEventOptions>(),
                                                      It.IsAny<CancellationToken>()),
                                     Times.Never,
                                     "The retry logic should not start when cancellation is triggered.");
        }

        /// <summary>
        ///   Retry logic would not start after a cancellation is requested.
        /// </summary>
        ///
        [Test]
        public void RetryLogicShouldNotStartWhenCancellationTriggeredWithABatch()
        {
            var batchOptions = new CreateBatchOptions { PartitionId = "0" };
            var transportProducer = new Mock<TransportProducer>();
            var eventHubConnection = new MockConnection(() => transportProducer.Object);
            var retryPolicy = new EventHubProducerClientOptions().RetryOptions.ToRetryPolicy();
            var mockTransportProducerPool = new MockTransportProducerPool(transportProducer.Object, eventHubConnection, retryPolicy);
            var mockPooledProducer = mockTransportProducerPool.GetPooledProducer(batchOptions.PartitionId) as MockPooledProducer;
            var producerClient = new EventHubProducerClient(eventHubConnection, transportProducer.Object, mockTransportProducerPool);
            var cancellationTokenSource = new CancellationTokenSource();

            cancellationTokenSource.Cancel();

            using var batch = EventHubsModelFactory.EventDataBatch(long.MaxValue, EventGenerator.CreateEvents(1).ToList(), batchOptions);
            Assert.That(async () => await producerClient.SendAsync(batch, cancellationTokenSource.Token), Throws.InstanceOf<OperationCanceledException>());

            transportProducer.Verify(t => t.SendAsync(It.IsAny<EventDataBatch>(),
                                                      It.IsAny<CancellationToken>()),
                                     Times.Never,
                                     "The retry logic should not start when cancellation is triggered (for a batch).");
        }

        /// <summary>
        ///   Retry logic will end if a <see cref="OperationCanceledException"/> is thrown
        ///   by <see cref="TransportProducer.SendAsync(IEnumerable{EventData}, SendEventOptions, CancellationToken)"/> and will rethrow the
        ///   exception.
        /// </summary>
        ///
        [Test]
        public void RetryLogicDetectsAnEmbeddedAmqpErrorForOperationCanceled()
        {
            var options = new SendEventOptions { PartitionId = "0" };
            var events = new[] { new EventData(new BinaryData(Array.Empty<byte>())) };
            var transportProducer = new Mock<TransportProducer>();
            var eventHubConnection = new MockConnection(() => transportProducer.Object);
            var retryPolicy = new EventHubProducerClientOptions().RetryOptions.ToRetryPolicy();
            var mockTransportProducerPool = new MockTransportProducerPool(transportProducer.Object, eventHubConnection, retryPolicy);
            var producerClient = new EventHubProducerClient(eventHubConnection, transportProducer.Object, mockTransportProducerPool);
            var embeddedException = new OperationCanceledException("", new ArgumentNullException());
            var cancellationTokenSource = new CancellationTokenSource();

            transportProducer
                .Setup(transportProducer => transportProducer.SendAsync(events, It.Is<SendEventOptions>(paramOptions => paramOptions.PartitionId == options.PartitionId), cancellationTokenSource.Token))
                .Throws(embeddedException);

            Assert.That(async () => await producerClient.SendAsync(events, options, cancellationTokenSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        /// <summary>
        ///   Retry logic will end if a <see cref="OperationCanceledException"/> is thrown
        ///   by <see cref="TransportProducer.SendAsync(EventDataBatch, CancellationToken)"/> and will rethrow the
        ///   exception.
        /// </summary>
        ///
        [Test]
        public void RetryLogicDetectsAnEmbeddedAmqpErrorForOperationCanceledWithABatch()
        {
            var batchOptions = new CreateBatchOptions { PartitionId = "0" };
            var transportProducer = new Mock<TransportProducer>();
            var eventHubConnection = new MockConnection(() => transportProducer.Object);
            var retryPolicy = new EventHubProducerClientOptions().RetryOptions.ToRetryPolicy();
            var mockTransportProducerPool = new MockTransportProducerPool(transportProducer.Object, eventHubConnection, retryPolicy);
            var mockPooledProducer = mockTransportProducerPool.GetPooledProducer(batchOptions.PartitionId) as MockPooledProducer;
            var producerClient = new EventHubProducerClient(eventHubConnection, transportProducer.Object, mockTransportProducerPool);
            var embeddedException = new OperationCanceledException("", new ArgumentNullException());
            var cancellationTokenSource = new CancellationTokenSource();

            using var batch = EventHubsModelFactory.EventDataBatch(long.MaxValue, EventGenerator.CreateEvents(1).ToList(), batchOptions);

            transportProducer
                .Setup(transportProducer => transportProducer.SendAsync(batch, cancellationTokenSource.Token))
                .Throws(embeddedException);

            Assert.That(async () => await producerClient.SendAsync(batch, cancellationTokenSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        /// <summary>
        ///   Retrieves the Connection for the producer using its private accessor.
        /// </summary>
        ///
        private static EventHubConnection GetConnection(EventHubProducerClient producer) =>
            (EventHubConnection)
                typeof(EventHubProducerClient)
                    .GetProperty("Connection", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(producer);

        /// <summary>
        ///   Retrieves the RetryPolicy for the producer using its private accessor.
        /// </summary>
        ///
        private static EventHubsRetryPolicy GetRetryPolicy(EventHubProducerClient producer) =>
            (EventHubsRetryPolicy)
                typeof(EventHubProducerClient)
                    .GetProperty("RetryPolicy", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(producer);

        /// <summary>
        ///   Retrieves the PartitionState for the producer using its private accessor.
        /// </summary>
        ///
        private static ConcurrentDictionary<string, PartitionPublishingState> GetPartitionState(EventHubProducerClient producer) =>
            (ConcurrentDictionary<string, PartitionPublishingState>)
                typeof(EventHubProducerClient)
                    .GetProperty("PartitionState", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(producer);

        /// <summary>
        ///   Sets <see cref="EventHubProducerClient.IsClosed"/> property using its protected accessor.
        /// </summary>
        ///
        /// <param name="producer">The <see cref="EventHubProducerClient"/> that should be set to closed.</param>
        /// <param name="isClosed">The value for the<see cref="EventHubProducerClient.IsClosed"/> property.</param>
        ///
        private static void SetIsClosed(EventHubProducerClient producer,
                                        bool isClosed) =>
                typeof(EventHubProducerClient)
                    .GetProperty("IsClosed")
                    .GetSetMethod(true)
                    .Invoke(producer, new object[] { isClosed });

        /// <summary>
        ///   Allows for observation of operations performed by the producer for testing purposes.
        /// </summary>
        ///
        private class ObservableTransportProducerMock : TransportProducer
        {
            public int CloseCallCount = 0;
            public bool WasCloseCalled = false;
            public (IEnumerable<EventData>, SendEventOptions) SendCalledWith;
            public EventDataBatch SendBatchCalledWith;
            public CreateBatchOptions CreateBatchCalledWith;

            public override Task SendAsync(IReadOnlyCollection<EventData> events,
                                           SendEventOptions sendOptions,
                                           CancellationToken cancellationToken)
            {
                SendCalledWith = (events, sendOptions);
                return Task.CompletedTask;
            }

            public override Task SendAsync(EventDataBatch batch,
                                           CancellationToken cancellationToken)
            {
                SendBatchCalledWith = batch;
                return Task.CompletedTask;
            }

            public override ValueTask<TransportEventBatch> CreateBatchAsync(CreateBatchOptions options,
                                                                            CancellationToken cancellationToken)
            {
                CreateBatchCalledWith = options;
                return new ValueTask<TransportEventBatch>(Task.FromResult(Mock.Of<TransportEventBatch>()));
            }

            public override ValueTask<PartitionPublishingProperties> ReadInitializationPublishingPropertiesAsync(CancellationToken cancellationToken) => throw new NotImplementedException();

            public override Task CloseAsync(CancellationToken cancellationToken)
            {
                WasCloseCalled = true;
                ++CloseCallCount;
                return Task.CompletedTask;
            }
        }

        /// <summary>
        ///   Serves as a non-functional connection for testing producer functionality.
        /// </summary>
        ///
        private class MockConnection : EventHubConnection
        {
            public EventHubsRetryPolicy GetPropertiesInvokedWith = null;
            public EventHubsRetryPolicy GetPartitionIdsInvokedWith = null;
            public EventHubsRetryPolicy GetPartitionPropertiesInvokedWith = null;
            public Mock<TransportClient> InnerClientMock = null;
            public bool WasClosed = false;

            public Func<string, string, TransportProducerFeatures, PartitionPublishingOptions, EventHubsRetryPolicy, TransportProducer> TransportProducerFactory =
                (partition, identifier, features, options, retry) => Mock.Of<TransportProducer>();

            public MockConnection(string namespaceName = "fakeNamespace",
                                  string eventHubName = "fakeEventHub") : base(namespaceName, eventHubName, new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>()).Object)
            {
            }

            public MockConnection(Func<string, string, TransportProducerFeatures, PartitionPublishingOptions, EventHubsRetryPolicy, TransportProducer> transportProducerFactory,
                                  string namespaceName,
                                  string eventHubName) : this(namespaceName, eventHubName)
            {
                TransportProducerFactory = transportProducerFactory;
            }

            public MockConnection(Func<TransportProducer> transportProducerFactory,
                                  string namespaceName,
                                  string eventHubName) : this((partition, identifier, features, options, retry) => transportProducerFactory(), namespaceName, eventHubName)
            {
            }

            public MockConnection(Func<string, string, TransportProducerFeatures, PartitionPublishingOptions, EventHubsRetryPolicy, TransportProducer> transportProducerFactory)
                : this(transportProducerFactory, "fakeNamespace", "fakeEventHub")
            {
            }

            public MockConnection(Func<TransportProducer> transportProducerFactory) : this(transportProducerFactory, "fakeNamespace", "fakeEventHub")
            {
            }

            internal override Task<EventHubProperties> GetPropertiesAsync(EventHubsRetryPolicy retryPolicy,
                                                                          CancellationToken cancellationToken = default)
            {
                GetPropertiesInvokedWith = retryPolicy;
                return Task.FromResult(new EventHubProperties(EventHubName, DateTimeOffset.Parse("2015-10-27T00:00:00Z"), new string[] { "0", "1" }, false));
            }

            internal override async Task<string[]> GetPartitionIdsAsync(EventHubsRetryPolicy retryPolicy,
                                                                        CancellationToken cancellationToken = default)
            {
                GetPartitionIdsInvokedWith = retryPolicy;
                return await base.GetPartitionIdsAsync(retryPolicy, cancellationToken);
            }

            internal override Task<PartitionProperties> GetPartitionPropertiesAsync(string partitionId,
                                                                                    EventHubsRetryPolicy retryPolicy,
                                                                                    CancellationToken cancellationToken = default)
            {
                GetPartitionPropertiesInvokedWith = retryPolicy;
                return Task.FromResult(default(PartitionProperties));
            }

            internal override TransportProducer CreateTransportProducer(string partitionId,
                                                                        string producerIdentifier,
                                                                        TransportProducerFeatures requestedFeatures,
                                                                        PartitionPublishingOptions partitionOptions,
                                                                        EventHubsRetryPolicy retryPolicy) => TransportProducerFactory(partitionId, producerIdentifier, requestedFeatures, partitionOptions, retryPolicy);

            internal override TransportClient CreateTransportClient(string fullyQualifiedNamespace,
                                                                    string eventHubName,
                                                                    TimeSpan operationTimeout,
                                                                    EventHubTokenCredential credential,
                                                                    EventHubConnectionOptions options,
                                                                    bool useTls = true)
            {
                InnerClientMock = new Mock<TransportClient>();

                InnerClientMock
                    .Setup(client => client.ServiceEndpoint)
                    .Returns(new Uri($"amgp://{ fullyQualifiedNamespace }.com/{ eventHubName }"));

                return InnerClientMock.Object;
            }

            public override Task CloseAsync(CancellationToken cancellationToken = default)
            {
                InnerClientMock.Setup(client => client.IsClosed)
                               .Returns(true);

                return Task.CompletedTask;
            }
        }

        /// <summary>
        ///   Allows for observation of operations performed by the producer for testing purposes.
        /// </summary>
        ///
        private class MockPooledProducer : TransportProducerPool.PooledProducer
        {
            public bool WasClosed { get; set; } = false;

            public MockPooledProducer(TransportProducer transportProducer) : base(transportProducer, (_) => Task.CompletedTask)
            {
            }

            public override ValueTask DisposeAsync()
            {
                WasClosed = true;
                return new ValueTask(Task.CompletedTask);
            }
        }

        /// <summary>
        ///   Allows for observation of operations performed by the producer for testing purposes.
        /// </summary>
        ///
        private class MockTransportProducerPool : TransportProducerPool
        {
            public bool GetPooledProducerWasCalled { get; set; }
            public bool ExpirePooledProducerAsyncWasCalled { get; set; }

            public MockPooledProducer MockPooledProducer { get; }

            public MockTransportProducerPool(TransportProducer transportProducer,
                                             EventHubConnection connection,
                                             EventHubsRetryPolicy retryPolicy,
                                             ConcurrentDictionary<string, PoolItem> pool = default,
                                             TimeSpan? expirationInterval = default) : base(partition => connection.CreateTransportProducer(partition, null, TransportProducerFeatures.None, null, retryPolicy), pool, expirationInterval)
            {
                MockPooledProducer = new MockPooledProducer(transportProducer);
            }

            public override PooledProducer GetPooledProducer(string partitionId,
                                                             TimeSpan? removeAfterDuration = default)
            {
                GetPooledProducerWasCalled = true;
                return MockPooledProducer;
            }

            public override Task ExpirePooledProducerAsync(string partitionId, bool forceClose = false)
            {
                ExpirePooledProducerAsyncWasCalled = true;
                return Task.CompletedTask;
            }
        }
    }
}
