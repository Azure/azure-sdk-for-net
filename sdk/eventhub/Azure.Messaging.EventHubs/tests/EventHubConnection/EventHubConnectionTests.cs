// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Metadata;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventHubConnection" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventHubConnectionTests
    {
        /// <summary>
        ///   Provides the invalid test cases for the constructor tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ConstructorExpandedArgumentInvalidCases()
        {
            TokenCredential credential = Mock.Of<TokenCredential>();

            yield return new object[] { null, "fakePath", credential };
            yield return new object[] { "", "fakePath", credential };
            yield return new object[] { "FakeNamespace", null, credential };
            yield return new object[] { "FakNamespace", "", credential };
            yield return new object[] { "FakeNamespace", "FakePath", null };
        }

        /// <summary>
        ///   Provides the invalid test cases for the constructor tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ConstructorCreatesDefaultOptionsCases()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake";

            yield return new object[] { new ReadableOptionsMock(fakeConnection), "simple connection string" };
            yield return new object[] { new ReadableOptionsMock(fakeConnection), "connection string with null options" };
            yield return new object[] { new ReadableOptionsMock("fullyQualifiedNamespace", "path", Mock.Of<TokenCredential>()), "expanded argument" };
        }

        /// <summary>
        ///   Provides the invalid test cases for the constructor tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ConstructorClonesOptionsCases()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake";

            var options = new EventHubConnectionOptions
            {
                TransportType = TransportType.AmqpWebSockets,
                Proxy = Mock.Of<IWebProxy>()
            };

            yield return new object[] { new ReadableOptionsMock(fakeConnection, options), options, "connection string" };
            yield return new object[] { new ReadableOptionsMock("fullyQualifiedNamespace", "path", Mock.Of<TokenCredential>(), options), options, "expanded argument" };
        }

        /// <summary>
        ///   Provides the test cases for valid connection types.
        /// </summary>
        ///
        public static IEnumerable<object[]> ValidConnectionTypeCases()
        {
            yield return new object[] { TransportType.AmqpTcp };
            yield return new object[] { TransportType.AmqpWebSockets };
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorRequiresConnectionString(string connectionString)
        {
            // Seems ExactTypeConstraints is not re-entrant.
            ExactTypeConstraint TypeConstraint() => connectionString is null ? Throws.ArgumentNullException : Throws.ArgumentException;

            Assert.That(() => new EventHubConnection(connectionString), TypeConstraint(), "The constructor without options should perform validation.");
            Assert.That(() => new EventHubConnection(connectionString, "eventHub"), TypeConstraint(), "The constructor with the event hub without options should perform validation.");
            Assert.That(() => new EventHubConnection(connectionString, "eventHub", new EventHubConnectionOptions()), TypeConstraint(), "The constructor with the event hub and options should perform validation.");
            Assert.That(() => new EventHubConnection(connectionString, new EventHubConnectionOptions()), TypeConstraint(), "The constructor with options and no event hub should perform validation.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorDoesNotRequireOptionsWithConnectionString()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake";
            Assert.That(() => new EventHubConnection(fakeConnection, default(EventHubConnectionOptions)), Throws.Nothing, "The constructor without the event hub should not require options");
            Assert.That(() => new EventHubConnection(fakeConnection, null, default(EventHubConnectionOptions)), Throws.Nothing, "The constructor with the event hub should not require options");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorDoesNotRequireEventHubInConnectionStringWhenPassedSeparate()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real]";
            Assert.That(() => new EventHubConnection(fakeConnection, "eventHub"), Throws.Nothing, "The constructor without options should not require the connection string event hub");
            Assert.That(() => new EventHubConnection(fakeConnection, "eventHub", new EventHubConnectionOptions()), Throws.Nothing, "The constructor with options should not require the connection string event hub");
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
        public void ConstructorValidatesConnectionString(string connectionString)
        {
            Assert.That(() => new EventHubConnection(connectionString), Throws.ArgumentException);
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorDoesNotAllowTheEventHubToBePassedTwiceIfDifferent()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake";
            Assert.That(() => new EventHubConnection(fakeConnection, "eventHub"), Throws.InstanceOf<ArgumentException>(), "The constructor without options should detect multiple different Event Hubs");
            Assert.That(() => new EventHubConnection(fakeConnection, "eventHub", new EventHubConnectionOptions()), Throws.InstanceOf<ArgumentException>(), "The constructor with options should detect multiple different Event Hubs");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorAllowsTheEventHubToBePassedTwiceIfEqual()
        {
            var eventHubName = "myHub";
            var fakeConnection = $"Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath={ eventHubName }";
            Assert.That(() => new EventHubConnection(fakeConnection, eventHubName), Throws.Nothing, "The constructor without options should allow the same Event Hub in multiple places");
            Assert.That(() => new EventHubConnection(fakeConnection, eventHubName, new EventHubConnectionOptions()), Throws.Nothing, "The constructor with options should allow the same Event Hub in multiple places");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorExpandedArgumentInvalidCases))]
        public void ConstructorValidatesExpandedArguments(string fullyQualifiedNamespace,
                                                          string eventHubName,
                                                          TokenCredential credential)
        {
            Assert.That(() => new EventHubConnection(fullyQualifiedNamespace, eventHubName, credential), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorCreatesDefaultOptionsCases))]
        public void ConstructorCreatesDefaultOptions(ReadableOptionsMock client,
                                                     string constructorDescription)
        {
            var defaultOptions = new EventHubConnectionOptions();
            EventHubConnectionOptions options = client.Options;

            Assert.That(options, Is.Not.Null, $"The { constructorDescription } constructor should have set default options.");
            Assert.That(options, Is.Not.SameAs(defaultOptions), $"The { constructorDescription } constructor should not have the same options instance.");
            Assert.That(options.TransportType, Is.EqualTo(defaultOptions.TransportType), $"The { constructorDescription } constructor should have the correct connection type.");
            Assert.That(options.Proxy, Is.EqualTo(defaultOptions.Proxy), $"The { constructorDescription } constructor should have the correct proxy.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorClonesOptionsCases))]
        public void ConstructorClonesOptions(ReadableOptionsMock client,
                                             EventHubConnectionOptions constructorOptions,
                                             string constructorDescription)
        {
            EventHubConnectionOptions options = client.Options;

            Assert.That(options, Is.Not.Null, $"The { constructorDescription } constructor should have set the options.");
            Assert.That(options, Is.Not.SameAs(constructorOptions), $"The { constructorDescription } constructor should have cloned the options.");
            Assert.That(options.TransportType, Is.EqualTo(constructorOptions.TransportType), $"The { constructorDescription } constructor should have the correct connection type.");
            Assert.That(options.Proxy, Is.EqualTo(constructorOptions.Proxy), $"The { constructorDescription } constructor should have the correct proxy.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithFullConnectionStringInitializesProperties()
        {
            var entityPath = "somePath";
            var fakeConnection = $"Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath={ entityPath }";
            var client = new EventHubConnection(fakeConnection);

            Assert.That(client.EventHubName, Is.EqualTo(entityPath));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithConnectionStringAndEventHubInitializesProperties()
        {
            var entityPath = "somePath";
            var fakeConnection = $"Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real]";
            var client = new EventHubConnection(fakeConnection, entityPath);

            Assert.That(client.EventHubName, Is.EqualTo(entityPath));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithExpandedArgumentsInitializesProperties()
        {
            var fullyQualifiedNamespace = "host.windows.servicebus.net";
            var entityPath = "somePath";
            TokenCredential credential = Mock.Of<TokenCredential>();
            var client = new EventHubConnection(fullyQualifiedNamespace, entityPath, credential);

            Assert.That(client.EventHubName, Is.EqualTo(entityPath));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithConnectionStringValidatesOptions()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake";
            var invalidOptions = new EventHubConnectionOptions { TransportType = TransportType.AmqpTcp, Proxy = Mock.Of<IWebProxy>() };

            Assert.That(() => new EventHubConnection(fakeConnection, invalidOptions), Throws.ArgumentException, "The connection string constructor should validate client options");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithExpandedArgumentsValidatesOptions()
        {
            var invalidOptions = new EventHubConnectionOptions { TransportType = TransportType.AmqpTcp, Proxy = Mock.Of<IWebProxy>() };
            Assert.That(() => new EventHubConnection("fullyQualifiedNamespace", "path", Mock.Of<TokenCredential>(), invalidOptions), Throws.ArgumentException, "The expanded argument constructor should validate client options");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ContructorWithConnectionStringCreatesTheTransportClient()
        {
            var client = new EventHubConnection("Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real]", "fake", new EventHubConnectionOptions());
            Assert.That(GetTransportClient(client), Is.Not.Null);
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ContructorWithExpandedArgumentsCreatesTheTransportClient()
        {
            var fullyQualifiedNamespace = "my.eventhubs.com";
            var path = "some-hub";
            var keyName = "aWonderfulKey";
            var key = "ABC4223";
            var resource = $"amqps://{ fullyQualifiedNamespace }/{ path }";
            var options = new EventHubConnectionOptions { TransportType = TransportType.AmqpTcp };
            var signature = new SharedAccessSignature(resource, keyName, key);
            var client = new EventHubConnection(fullyQualifiedNamespace, path, new SharedAccessSignatureCredential(signature), options);

            Assert.That(GetTransportClient(client), Is.Not.Null);
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection.CreateTransportClient" />
        ///    method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorCreatesDefaultOptionsCases))]
        public void TransportClientReceivesDefaultOptions(ReadableOptionsMock client,
                                                          string constructorDescription)
        {
            var defaultOptions = new EventHubConnectionOptions();
            EventHubConnectionOptions options = client.TransportClientOptions;

            Assert.That(options, Is.Not.Null, $"The { constructorDescription } constructor should have set default options.");
            Assert.That(options, Is.Not.SameAs(defaultOptions), $"The { constructorDescription } constructor should not have the same options instance.");
            Assert.That(options.TransportType, Is.EqualTo(defaultOptions.TransportType), $"The { constructorDescription } constructor should have the correct connection type.");
            Assert.That(options.Proxy, Is.EqualTo(defaultOptions.Proxy), $"The { constructorDescription } constructor should have the correct proxy.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConnection.CreateTransportClient" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorClonesOptionsCases))]
        public void TransportClientReceivesClonedOptions(ReadableOptionsMock client,
                                                         EventHubConnectionOptions constructorOptions,
                                                         string constructorDescription)
        {
            EventHubConnectionOptions options = client.TransportClientOptions;

            Assert.That(options, Is.Not.Null, $"The { constructorDescription } constructor should have set the options.");
            Assert.That(options, Is.Not.SameAs(constructorOptions), $"The { constructorDescription } constructor should have cloned the options.");
            Assert.That(options.TransportType, Is.EqualTo(constructorOptions.TransportType), $"The { constructorDescription } constructor should have the correct connection type.");
            Assert.That(options.Proxy, Is.EqualTo(constructorOptions.Proxy), $"The { constructorDescription } constructor should have the correct proxy.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConnection.CreateTransportClient" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ValidConnectionTypeCases))]
        public void BuildTransportClientAllowsLegalConnectionTypes(TransportType connectionType)
        {
            var fullyQualifiedNamespace = "my.eventhubs.com";
            var path = "some-hub";
            var keyName = "aWonderfulKey";
            var key = "ABC4223";
            var resource = $"amqps://{ fullyQualifiedNamespace }/{ path }";
            var options = new EventHubConnectionOptions { TransportType = connectionType };
            var signature = new SharedAccessSignature(resource, keyName, key);
            var credential = new SharedAccessSignatureCredential(signature);
            var client = new EventHubConnection(fullyQualifiedNamespace, path, credential);

            Assert.That(() => client.CreateTransportClient(fullyQualifiedNamespace, path, credential, options), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConnection.CreateTransportClient" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void BuildTransportClientRejectsInvalidConnectionTypes()
        {
            var fullyQualifiedNamespace = "my.eventhubs.com";
            var path = "some-hub";
            var keyName = "aWonderfulKey";
            var key = "ABC4223";
            var resource = $"amqps://{ fullyQualifiedNamespace }/{ path }";
            var connectionType = (TransportType)int.MinValue;
            var options = new EventHubConnectionOptions { TransportType = connectionType };
            var signature = new SharedAccessSignature(resource, keyName, key);
            var credential = new SharedAccessSignatureCredential(signature);
            var client = new EventHubConnection(fullyQualifiedNamespace, path, credential);

            Assert.That(() => client.CreateTransportClient(fullyQualifiedNamespace, path, credential, options), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection.CreateTransportProducer" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void CreateProducerCreatesDefaultWhenNoOptionsArePassed()
        {
            var expected = new EventHubProducerClientOptions();
            var connectionString = "Endpoint=value.com;SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]";
            var mockClient = new ReadableOptionsMock(connectionString, new EventHubConnectionOptions());

            mockClient.CreateTransportProducer();

            Assert.That(mockClient.ProducerOptions, Is.Not.Null, "The producer options should have been set.");
            Assert.That(mockClient.ProducerOptions.PartitionId, Is.EqualTo(expected.PartitionId), "The partition identifiers should match.");
            Assert.That(mockClient.ProducerOptions.RetryOptions.IsEquivalentTo(expected.RetryOptions), Is.True, "The retries should match.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection.CreateTransportConsumer" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void CreateConsumerCreatesDefaultWhenNoOptionsArePassed()
        {
            var expectedOptions = new EventHubConsumerClientOptions();
            var expectedConsumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            var expectedPartition = "56767";
            var expectedPosition = EventPosition.FromEnqueuedTime(DateTimeOffset.Parse("2015-10-27T12:00:00Z"));
            var connectionString = "Endpoint=value.com;SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]";
            var mockClient = new ReadableOptionsMock(connectionString, new EventHubConnectionOptions());

            mockClient.CreateTransportConsumer(expectedConsumerGroup, expectedPartition, expectedPosition);
            EventHubConsumerClientOptions actualOptions = mockClient.ConsumerOptions;

            Assert.That(actualOptions, Is.Not.Null, "The consumer options should have been set.");
            Assert.That(actualOptions.OwnerLevel, Is.EqualTo(expectedOptions.OwnerLevel), "The owner levels should match.");
            Assert.That(actualOptions.Identifier, Is.EqualTo(expectedOptions.Identifier), "The identifiers should match.");
            Assert.That(actualOptions.PrefetchCount, Is.EqualTo(expectedOptions.PrefetchCount), "The prefetch counts should match.");
            Assert.That(actualOptions.RetryOptions.IsEquivalentTo(expectedOptions.RetryOptions), Is.True, "The retries should match.");
            Assert.That(actualOptions.MaximumReceiveWaitTimeOrDefault, Is.EqualTo(expectedOptions.MaximumReceiveWaitTimeOrDefault), "The wait times should match.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection.CreateTransportConsumer" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void CreateConsumerCreatesDefaultWhenOptionsAreNotSet()
        {
            var retryOptions = new RetryOptions
            {
                MaximumRetries = 99,
                MaximumDelay = TimeSpan.FromHours(72),
                Delay = TimeSpan.FromSeconds(27)
            };

            var expectedOptions = new EventHubConsumerClientOptions
            {
                OwnerLevel = 251,
                Identifier = "Bob",
                PrefetchCount = 600,
                RetryOptions = retryOptions,
                DefaultMaximumReceiveWaitTime = TimeSpan.FromSeconds(123)
            };

            var clientOptions = new EventHubConnectionOptions();
            var expectedConsumerGroup = "SomeGroup";
            var expectedPartition = "56767";
            var expectedPosition = EventPosition.FromSequenceNumber(123);
            var connectionString = "Endpoint=value.com;SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]";
            var mockClient = new ReadableOptionsMock(connectionString, clientOptions);

            mockClient.CreateTransportConsumer(expectedConsumerGroup, expectedPartition, expectedPosition, expectedOptions);
            EventHubConsumerClientOptions actualOptions = mockClient.ConsumerOptions;

            Assert.That(actualOptions, Is.Not.Null, "The consumer options should have been set.");
            Assert.That(actualOptions, Is.Not.SameAs(expectedOptions), "A clone of the options should have been made.");
            Assert.That(actualOptions.OwnerLevel, Is.EqualTo(expectedOptions.OwnerLevel), "The owner levels should match.");
            Assert.That(actualOptions.Identifier, Is.EqualTo(expectedOptions.Identifier), "The identifiers should match.");
            Assert.That(actualOptions.PrefetchCount, Is.EqualTo(expectedOptions.PrefetchCount), "The prefetch counts should match.");
            Assert.That(actualOptions.RetryOptions.IsEquivalentTo(expectedOptions.RetryOptions), Is.True, "The retries should match.");
            Assert.That(actualOptions.MaximumReceiveWaitTimeOrDefault, Is.EqualTo(expectedOptions.MaximumReceiveWaitTimeOrDefault), "The wait times should match.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection.CreateTransportConsumer" />
        ///    method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CreateConsumerRequiresConsumerGroup(string consumerGroup)
        {
            var client = new EventHubConnection("Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real]", "fake", new EventHubConnectionOptions());
            Assert.That(() => client.CreateTransportConsumer(consumerGroup, "partition1", EventPosition.Earliest), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection.CreateTransportConsumer" />
        ///    method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CreateConsumerRequiresPartition(string partition)
        {
            var client = new EventHubConnection("Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real]", "fake", new EventHubConnectionOptions());
            Assert.That(() => client.CreateTransportConsumer("someGroup", partition, EventPosition.Earliest), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection.CreateTransportConsumer" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void CreateConsumerRequiresEventPosition()
        {
            var client = new EventHubConnection("Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real]", "fake", new EventHubConnectionOptions());
            Assert.That(() => client.CreateTransportConsumer(EventHubConsumerClient.DefaultConsumerGroupName, "123", null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConnection.Close" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloseDelegatesToCloseAsync()
        {
            var client = new ObservableOperationsMock("Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake");
            client.Close();

            Assert.That(client.WasCloseAsyncCalled, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConnection.DisposeAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task DisposeAsyncDelegatesToCloseAsync()
        {
            ObservableOperationsMock capturedClient;

            await using (var client = new ObservableOperationsMock("Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake"))
            {
                capturedClient = client;
            }

            Assert.That(capturedClient.WasCloseAsyncCalled, Is.True);
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection.GetPartitionIdsAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task GetPartitionIdsAsyncDelegatesToGetProperties()
        {
            var date = DateTimeOffset.Parse("2015-10-27T12:00:00Z");
            var partitionIds = new[] { "first", "second", "third" };
            var properties = new EventHubProperties("dummy", date, partitionIds);
            var mockClient = new Mock<EventHubConnection> { CallBase = true };

            mockClient
                .Setup(client => client.GetPropertiesAsync(
                    It.IsAny<EventHubRetryPolicy>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(properties))
                .Verifiable("GetPropertiesAcync should have been delegated to.");

            var actual = await mockClient.Object.GetPartitionIdsAsync(Mock.Of<EventHubRetryPolicy>(), CancellationToken.None);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.EqualTo(partitionIds));

            mockClient.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConnection.GetPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetPropertiesAsyncInvokesTheTransportClient()
        {
            var transportClient = new ObservableTransportClientMock();
            var client = new InjectableTransportClientMock(transportClient, "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake");

            await client.GetPropertiesAsync(Mock.Of<EventHubRetryPolicy>(), CancellationToken.None);

            Assert.That(transportClient.WasGetPropertiesCalled, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConnection.GetPartitionPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetPartitionPropertiesAsyncInvokesTheTransportClient()
        {
            var transportClient = new ObservableTransportClientMock();
            var client = new InjectableTransportClientMock(transportClient, "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake");
            var expectedId = "BB33";

            await client.GetPartitionPropertiesAsync(expectedId, Mock.Of<EventHubRetryPolicy>());

            Assert.That(transportClient.GetPartitionPropertiesCalledForId, Is.EqualTo(expectedId));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConnection.CreateTransportProducer" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateProducerInvokesTheTransportClient()
        {
            var transportClient = new ObservableTransportClientMock();
            var client = new InjectableTransportClientMock(transportClient, "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake");
            var expectedOptions = new EventHubProducerClientOptions { RetryOptions = new RetryOptions { MaximumRetries = 6, TryTimeout = TimeSpan.FromMinutes(4) } };

            client.CreateTransportProducer(expectedOptions);

            Assert.That(transportClient.CreateProducerCalledWith, Is.Not.Null, "The producer options should have been set.");
            Assert.That(transportClient.CreateProducerCalledWith.PartitionId, Is.EqualTo(expectedOptions.PartitionId), "The partition identifiers should match.");
            Assert.That(transportClient.CreateProducerCalledWith.RetryOptions.IsEquivalentTo(expectedOptions.RetryOptions), Is.True, "The retry options should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConnection.CreateTransportConsumer" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateConsumerInvokesTheTransportClient()
        {
            var transportClient = new ObservableTransportClientMock();
            var client = new InjectableTransportClientMock(transportClient, "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake");
            var expectedOptions = new EventHubConsumerClientOptions { RetryOptions = new RetryOptions { MaximumRetries = 67 } };
            var expectedPosition = EventPosition.FromOffset(65);
            var expectedPartition = "2123";
            var expectedConsumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

            client.CreateTransportConsumer(expectedConsumerGroup, expectedPartition, expectedPosition, expectedOptions);
            (var actualConsumerGroup, var actualPartition, EventPosition actualPosition, EventHubConsumerClientOptions actualOptions) = transportClient.CreateConsumerCalledWith;

            Assert.That(actualPartition, Is.EqualTo(expectedPartition), "The partition should have been passed.");
            Assert.That(actualConsumerGroup, Is.EqualTo(expectedConsumerGroup), "The consumer groups should match.");
            Assert.That(actualPosition.Offset, Is.EqualTo(expectedPosition.Offset), "The event position to receive should match.");
            Assert.That(actualOptions, Is.Not.Null, "The consumer options should have been set.");
            Assert.That(actualPosition.Offset, Is.EqualTo(expectedPosition.Offset), "The event position to receive should match.");
            Assert.That(actualOptions.OwnerLevel, Is.EqualTo(expectedOptions.OwnerLevel), "The owner levels should match.");
            Assert.That(actualOptions.Identifier, Is.EqualTo(expectedOptions.Identifier), "The identifiers should match.");
            Assert.That(actualOptions.PrefetchCount, Is.EqualTo(expectedOptions.PrefetchCount), "The prefetch counts should match.");
            Assert.That(actualOptions.MaximumReceiveWaitTimeOrDefault, Is.EqualTo(expectedOptions.MaximumReceiveWaitTimeOrDefault), "The wait times should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConnection.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncClosesTheTransportClient()
        {
            var transportClient = new ObservableTransportClientMock();
            var client = new InjectableTransportClientMock(transportClient, "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake");

            await client.CloseAsync();

            Assert.That(transportClient.WasCloseCalled, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConnection.Close" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloseClosesTheTransportClient()
        {
            var transportClient = new ObservableTransportClientMock();
            var client = new InjectableTransportClientMock(transportClient, "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake");

            client.Close();

            Assert.That(transportClient.WasCloseCalled, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsClient.BuildResource" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void BuildResourceNormalizesTheResource()
        {
            var fullyQualifiedNamespace = "my.eventhub.com";
            var path = "someHub/";
            var transportClient = new ObservableTransportClientMock();
            var client = new InjectableTransportClientMock(transportClient, "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake");
            var resource = BuildResource(client, TransportType.AmqpWebSockets, fullyQualifiedNamespace, path);

            Assert.That(resource, Is.Not.Null.Or.Empty, "The resource should have been populated.");
            Assert.That(resource, Is.EqualTo(resource.ToLowerInvariant()), "The resource should have been normalized to lower case.");

            var uri = new Uri(resource, UriKind.Absolute);

            Assert.That(uri.AbsolutePath.StartsWith("/"), Is.True, "The resource path have been normalized to begin with a trailing slash.");
            Assert.That(uri.AbsolutePath.EndsWith("/"), Is.False, "The resource path have been normalized to not end with a trailing slash.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsClient.BuildResource" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void BuildResourceConstructsFromNamespaceAndPath()
        {
            var fullyQualifiedNamespace = "my.eventhub.com";
            var path = "someHub";
            var transportClient = new ObservableTransportClientMock();
            var client = new InjectableTransportClientMock(transportClient, "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake");
            var expectedPath = $"/{ path.ToLowerInvariant() }";
            var resource = BuildResource(client, TransportType.AmqpTcp, fullyQualifiedNamespace, path);

            Assert.That(resource, Is.Not.Null.Or.Empty, "The resource should have been populated.");

            var uri = new Uri(resource, UriKind.Absolute);

            Assert.That(uri.Host, Is.EqualTo(fullyQualifiedNamespace), "The resource should match the host.");
            Assert.That(uri.AbsolutePath, Is.EqualTo(expectedPath), "The resource path should match the Event Hub path.");
        }

        /// <summary>
        ///   Provides a test shim for retrieving the credential that a client was
        ///   created with.
        /// </summary>
        ///
        /// <param name="client">The client to retrieve the credential for.</param>
        ///
        /// <returns>The credential with which the client was created.</returns>
        ///
        private string BuildResource(EventHubConnection client,
                                     TransportType transportType,
                                     string fullyQualifiedNamespace,
                                     string eventHubName) =>
             typeof(EventHubConnection)
                 .GetMethod("BuildAudienceResource", BindingFlags.Static | BindingFlags.NonPublic)
                 .Invoke(client, new object[] { transportType, fullyQualifiedNamespace, eventHubName }) as string;

        /// <summary>
        ///   Provides a test shim for retrieving the transport client contained by an
        ///   Event Hub client instance.
        /// </summary>
        ///
        /// <param name="client">The client to retrieve the transport client of.</param>
        ///
        /// <returns>The transport client contained by the Event Hub client.</returns>
        ///
        private TransportClient GetTransportClient(EventHubConnection client) =>
            typeof(EventHubConnection)
                .GetProperty("InnerClient", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(client) as TransportClient;

        /// <summary>
        ///   Allows for the options used by the client to be exposed for testing purposes.
        /// </summary>
        ///
        public class ReadableOptionsMock : EventHubConnection
        {
            public EventHubConnectionOptions Options =>
                typeof(EventHubConnection)
                   .GetProperty(nameof(Options), BindingFlags.Instance | BindingFlags.NonPublic)
                   .GetValue(this) as EventHubConnectionOptions;

            public EventHubConnectionOptions TransportClientOptions;
            public EventHubProducerClientOptions ProducerOptions => _transportClient.CreateProducerCalledWith;
            public EventHubConsumerClientOptions ConsumerOptions => _transportClient.CreateConsumerCalledWith.Options;

            private ObservableTransportClientMock _transportClient;

            public ReadableOptionsMock(string connectionString,
                                       EventHubConnectionOptions clientOptions = default) : base(connectionString, clientOptions)
            {
            }

            public ReadableOptionsMock(string fullyQualifiedNamespace,
                                       string eventHubName,
                                       TokenCredential credential,
                                       EventHubConnectionOptions clientOptions = default) : base(fullyQualifiedNamespace, eventHubName, credential, clientOptions)
            {
            }

            internal override TransportClient CreateTransportClient(string fullyQualifiedNamespace, string eventHubName, TokenCredential credential, EventHubConnectionOptions options)
            {
                TransportClientOptions = options;
                _transportClient = new ObservableTransportClientMock();
                return _transportClient;
            }
        }

        /// <summary>
        ///   Allows for the operations performed by the client to be observed for testing purposes.
        /// </summary>
        ///
        public class ObservableOperationsMock : EventHubConnection
        {
            public bool WasCloseAsyncCalled = false;

            public ObservableOperationsMock(string connectionString,
                                            EventHubConnectionOptions clientOptions = default) : base(connectionString, clientOptions)
            {
            }

            public ObservableOperationsMock(string fullyQualifiedNamespace,
                                            string eventHubName,
                                            TokenCredential credential,
                                            EventHubConnectionOptions clientOptions = default) : base(fullyQualifiedNamespace, eventHubName, credential, clientOptions)
            {
            }

            public override Task CloseAsync(CancellationToken cancellationToken = default)
            {
                WasCloseAsyncCalled = true;
                return base.CloseAsync(cancellationToken);
            }

        }

        /// <summary>
        ///   Allows for the transport client created the client to be injected for testing purposes.
        /// </summary>
        ///
        private class InjectableTransportClientMock : EventHubConnection
        {
            public TransportClient TransportClient;

            public InjectableTransportClientMock(TransportClient transportClient,
                                                 string connectionString,
                                                 EventHubConnectionOptions clientOptions = default) : base(connectionString, clientOptions)
            {
                TransportClient = transportClient;
                SetTransportClient(transportClient);

            }

            public InjectableTransportClientMock(TransportClient transportClient,
                                                 string fullyQualifiedNamespace,
                                                 string eventHubName,
                                                 TokenCredential credential,
                                                 EventHubConnectionOptions clientOptions = default) : base(fullyQualifiedNamespace, eventHubName, credential, clientOptions)
            {
                TransportClient = transportClient;
                SetTransportClient(transportClient);
            }

            internal override TransportClient CreateTransportClient(string fullyQualifiedNamespace,
                                                                   string eventHubName,
                                                                   TokenCredential credential,
                                                                   EventHubConnectionOptions options) => TransportClient;

            private void SetTransportClient(TransportClient transportClient) =>
                typeof(EventHubConnection)
                    .GetProperty("InnerClient", BindingFlags.Instance | BindingFlags.NonPublic)
                    .SetValue(this, transportClient);

        }

        /// <summary>
        ///   Allows for observation of operations performed by the client for testing purposes.
        /// </summary>
        ///
        private class ObservableTransportClientMock : TransportClient
        {
            public (string ConsumerGroup, string Partition, EventPosition Position, EventHubConsumerClientOptions Options) CreateConsumerCalledWith;
            public EventHubProducerClientOptions CreateProducerCalledWith;
            public string GetPartitionPropertiesCalledForId;
            public bool WasGetPropertiesCalled;
            public bool WasCloseCalled;

            public override Task<EventHubProperties> GetPropertiesAsync(EventHubRetryPolicy retryPolicy,
                                                                        CancellationToken cancellationToken = default)
            {
                WasGetPropertiesCalled = true;
                return Task.FromResult(default(EventHubProperties));
            }

            public override Task<PartitionProperties> GetPartitionPropertiesAsync(string partitionId,
                                                                                  EventHubRetryPolicy retryPolicy,
                                                                                  CancellationToken cancellationToken = default)
            {
                GetPartitionPropertiesCalledForId = partitionId;
                return Task.FromResult(default(PartitionProperties));
            }

            public override TransportProducer CreateProducer(EventHubProducerClientOptions producerOptions)
            {
                CreateProducerCalledWith = producerOptions;
                return default;
            }

            public override TransportConsumer CreateConsumer(string consumerGroup,
                                                             string partitionId,
                                                             EventPosition eventPosition,
                                                             EventHubConsumerClientOptions consumerOptions)
            {
                CreateConsumerCalledWith = (consumerGroup, partitionId, eventPosition, consumerOptions);
                return default;
            }

            public override Task CloseAsync(CancellationToken cancellationToken)
            {
                WasCloseCalled = true;
                return Task.CompletedTask;
            }
        }
    }
}
