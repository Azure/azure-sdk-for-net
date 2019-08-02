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

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventHubClient" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class EventHubClientTests
    {
        /// <summary>
        ///   Provides the invalid test cases for the constructor tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ConstructorExpandedArgumentInvalidCases()
        {
            var credential = Mock.Of<TokenCredential>();

            yield return new object[] { null, "fakePath", credential };
            yield return new object[] { "", "fakePath", credential };
            yield return new object[] { "FakeHost", null, credential };
            yield return new object[] { "FakeHost", "", credential };
            yield return new object[] { "FakeHost", "FakePath", null };
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
            yield return new object[] { new ReadableOptionsMock("host", "path", Mock.Of<TokenCredential>()), "expanded argument" };
        }

        /// <summary>
        ///   Provides the invalid test cases for the constructor tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ConstructorClonesOptionsCases()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake";

            var options = new EventHubClientOptions
            {
                TransportType = TransportType.AmqpWebSockets,
                RetryOptions = new RetryOptions { MaximumRetries = 88, TryTimeout = TimeSpan.FromMinutes(58) },
                Proxy = Mock.Of<IWebProxy>()
            };

            yield return new object[] { new ReadableOptionsMock(fakeConnection, options), options, "connection string" };
            yield return new object[] { new ReadableOptionsMock("host", "path", Mock.Of<TokenCredential>(), options), options, "expanded argument" };
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
        ///    Verifies functionality of the <see cref="EventHubClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorRequiresConnectionString(string connectionString)
        {
            Assert.That(() => new EventHubClient(connectionString), Throws.ArgumentException, "The constructor without options should perform validation.");
            Assert.That(() => new EventHubClient(connectionString, "eventHub"), Throws.ArgumentException, "The constructor with the event hub without options should perform validation.");
            Assert.That(() => new EventHubClient(connectionString, "eventHub", new EventHubClientOptions()), Throws.ArgumentException, "The constructor with the event hub and options should perform validation.");
            Assert.That(() => new EventHubClient(connectionString, new EventHubClientOptions()), Throws.ArgumentException, "The constructor with options and no event hub should perform validation.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorDoesNotRequireOptionsWithConnectionString()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake";
            Assert.That(() => new EventHubClient(fakeConnection, default(EventHubClientOptions)), Throws.Nothing, "The constructor without the event hub should not require options");
            Assert.That(() => new EventHubClient(fakeConnection, null, default(EventHubClientOptions)), Throws.Nothing, "The constructor with the event hub should not require options");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorDoesNotRequireEventHubInConnectionStringWhenPassedSeparate()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real]";
            Assert.That(() => new EventHubClient(fakeConnection, "eventHub"), Throws.Nothing, "The constructor without options should not require the connection string event hub");
            Assert.That(() => new EventHubClient(fakeConnection, "eventHub", new EventHubClientOptions()), Throws.Nothing, "The constructor with options should not require the connection string event hub");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient" />
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
            Assert.That(() => new EventHubClient(connectionString), Throws.ArgumentException);
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructoNotAllowTheEventHubToBePassedTwice()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake";
            Assert.That(() => new EventHubClient(fakeConnection, "eventHub"), Throws.InstanceOf<ArgumentException>(), "The constructor without options should detect multiple Event Hubs");
            Assert.That(() => new EventHubClient(fakeConnection, "eventHub", new EventHubClientOptions()), Throws.InstanceOf<ArgumentException>(), "The constructor with options should detect multiple Event Hubs");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorExpandedArgumentInvalidCases))]
        public void ConstructorValidatesExpandedArguments(string host,
                                                          string eventHubName,
                                                          TokenCredential credential)
        {
            Assert.That(() => new EventHubClient(host, eventHubName, credential), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorCreatesDefaultOptionsCases))]
        public void ConstructorCreatesDefaultOptions(ReadableOptionsMock client,
                                                     string constructorDescription)
        {
            var defaultOptions = new EventHubClientOptions();
            var options = client.ClientOptions;

            Assert.That(options, Is.Not.Null, $"The { constructorDescription } constructor should have set default options.");
            Assert.That(options, Is.Not.SameAs(defaultOptions), $"The { constructorDescription } constructor should not have the same options instance.");
            Assert.That(options.TransportType, Is.EqualTo(defaultOptions.TransportType), $"The { constructorDescription } constructor should have the correct connection type.");
            Assert.That(options.Proxy, Is.EqualTo(defaultOptions.Proxy), $"The { constructorDescription } constructor should have the correct proxy.");
            Assert.That(options.RetryOptions.IsEquivalentTo(defaultOptions.RetryOptions), Is.True, $"The { constructorDescription } constructor should have the correct retry options.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorClonesOptionsCases))]
        public void ConstructorClonesOptions(ReadableOptionsMock client,
                                             EventHubClientOptions constructorOptions,
                                             string constructorDescription)
        {
            var options = client.ClientOptions;

            Assert.That(options, Is.Not.Null, $"The { constructorDescription } constructor should have set the options.");
            Assert.That(options, Is.Not.SameAs(constructorOptions), $"The { constructorDescription } constructor should have cloned the options.");
            Assert.That(options.TransportType, Is.EqualTo(constructorOptions.TransportType), $"The { constructorDescription } constructor should have the correct connection type.");
            Assert.That(options.Proxy, Is.EqualTo(constructorOptions.Proxy), $"The { constructorDescription } constructor should have the correct proxy.");
            Assert.That(options.RetryOptions.IsEquivalentTo(constructorOptions.RetryOptions), Is.True, $"The { constructorDescription } constructor should have the correct retry options.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithFullConnectionStringInitializesProperties()
        {
            var entityPath = "somePath";
            var fakeConnection = $"Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath={ entityPath }";
            var client = new EventHubClient(fakeConnection);

            Assert.That(client.EventHubName, Is.EqualTo(entityPath));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithConnectionStringAndEventHubInitializesProperties()
        {
            var entityPath = "somePath";
            var fakeConnection = $"Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real]";
            var client = new EventHubClient(fakeConnection, entityPath);

            Assert.That(client.EventHubName, Is.EqualTo(entityPath));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithExpandedArgumentsInitializesProperties()
        {
            var host = "host.windows.servicebus.net";
            var entityPath = "somePath";
            var credential = Mock.Of<TokenCredential>();
            var client = new EventHubClient(host, entityPath, credential);

            Assert.That(client.EventHubName, Is.EqualTo(entityPath));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithConnectionStringValidatesOptions()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake";
            var invalidOptions = new EventHubClientOptions { TransportType = TransportType.AmqpTcp, Proxy = Mock.Of<IWebProxy>() };

            Assert.That(() => new EventHubClient(fakeConnection, invalidOptions), Throws.ArgumentException, "The connection string constructor should validate client options");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithExpandedArgumentsValidatesOptions()
        {
            var invalidOptions = new EventHubClientOptions { TransportType = TransportType.AmqpTcp, Proxy = Mock.Of<IWebProxy>() };
            Assert.That(() => new EventHubClient("host", "path", Mock.Of<TokenCredential>(), invalidOptions), Throws.ArgumentException, "The expanded argument constructor should validate client options");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ContructorWithConnectionStringCreatesTheTransportClient()
        {

            var client = new EventHubClient("Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real]", "fake", new EventHubClientOptions());
            Assert.That(GetTransportClient(client), Is.Not.Null);
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ContructorWithExpandedArgumentsCreatesTheTransportClient()
        {
            var host = "my.eventhubs.com";
            var path = "some-hub";
            var keyName = "aWonderfulKey";
            var key = "ABC4223";
            var resource = $"amqps://{ host }/{ path }";
            var options = new EventHubClientOptions { TransportType = TransportType.AmqpTcp };
            var signature = new SharedAccessSignature(resource, keyName, key);
            var client = new EventHubClient(host, path, new SharedAccessSignatureCredential(signature), options);

            Assert.That(GetTransportClient(client), Is.Not.Null);
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient.BuildTransportClient" />
        ///    method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorCreatesDefaultOptionsCases))]
        public void TransportClientReceivesDefaultOptions(ReadableOptionsMock client,
                                                          string constructorDescription)
        {
            var defaultOptions = new EventHubClientOptions();
            var options = client.TransportClientOptions;

            Assert.That(options, Is.Not.Null, $"The { constructorDescription } constructor should have set default options.");
            Assert.That(options, Is.Not.SameAs(defaultOptions), $"The { constructorDescription } constructor should not have the same options instance.");
            Assert.That(options.TransportType, Is.EqualTo(defaultOptions.TransportType), $"The { constructorDescription } constructor should have the correct connection type.");
            Assert.That(options.Proxy, Is.EqualTo(defaultOptions.Proxy), $"The { constructorDescription } constructor should have the correct proxy.");
            Assert.That(options.RetryOptions.IsEquivalentTo(defaultOptions.RetryOptions), Is.True, $"The { constructorDescription } constructor should have the correct retry.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubClient.BuildTransportClient" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorClonesOptionsCases))]
        public void TransportClientReceivesClonedOptions(ReadableOptionsMock client,
                                                         EventHubClientOptions constructorOptions,
                                                         string constructorDescription)
        {
            var options = client.TransportClientOptions;

            Assert.That(options, Is.Not.Null, $"The { constructorDescription } constructor should have set the options.");
            Assert.That(options, Is.Not.SameAs(constructorOptions), $"The { constructorDescription } constructor should have cloned the options.");
            Assert.That(options.TransportType, Is.EqualTo(constructorOptions.TransportType), $"The { constructorDescription } constructor should have the correct connection type.");
            Assert.That(options.Proxy, Is.EqualTo(constructorOptions.Proxy), $"The { constructorDescription } constructor should have the correct proxy.");
            Assert.That(options.RetryOptions.IsEquivalentTo(constructorOptions.RetryOptions), Is.True, $"The { constructorDescription } constructor should have the correct retry.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubClient.BuildTransportClient" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ValidConnectionTypeCases))]
        public void BuildTransportClientAllowsLegalConnectionTypes(TransportType connectionType)
        {
            var host = "my.eventhubs.com";
            var path = "some-hub";
            var keyName = "aWonderfulKey";
            var key = "ABC4223";
            var resource = $"amqps://{ host }/{ path }";
            var options = new EventHubClientOptions { TransportType = connectionType };
            var signature = new SharedAccessSignature(resource, keyName, key);
            var credential = new SharedAccessSignatureCredential(signature);
            var client = new EventHubClient(host, path, credential);

            Assert.That(() => client.BuildTransportClient(host, path, credential, options, client.RetryPolicy), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubClient.BuildTransportClient" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void BuildTransportClientRejectsInvalidConnectionTypes()
        {
            var host = "my.eventhubs.com";
            var path = "some-hub";
            var keyName = "aWonderfulKey";
            var key = "ABC4223";
            var resource = $"amqps://{ host }/{ path }";
            var connectionType = (TransportType)Int32.MinValue;
            var options = new EventHubClientOptions { TransportType = connectionType };
            var signature = new SharedAccessSignature(resource, keyName, key);
            var credential = new SharedAccessSignatureCredential(signature);
            var client = new EventHubClient(host, path, credential);

            Assert.That(() => client.BuildTransportClient(host, path, credential, options, client.RetryPolicy), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient.CreateProducer" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void CreateProducerCreatesDefaultWhenNoOptionsArePassed()
        {
            var retryOptions = new RetryOptions
            {
                MaximumRetries = 99,
                MaximumDelay = TimeSpan.FromHours(72),
                Delay = TimeSpan.FromSeconds(27)
            };

            var clientOptions = new EventHubClientOptions
            {
                RetryOptions = retryOptions
            };

            var expected = new EventHubProducerOptions
            {
                RetryOptions = retryOptions
            };

            var connectionString = "Endpoint=value.com;SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]";
            var mockClient = new ReadableOptionsMock(connectionString, clientOptions);

            mockClient.CreateProducer();

            Assert.That(mockClient.ProducerOptions, Is.Not.Null, "The producer options should have been set.");
            Assert.That(mockClient.ProducerOptions.PartitionId, Is.EqualTo(expected.PartitionId), "The partition identifiers should match.");
            Assert.That(mockClient.ProducerOptions.RetryOptions.IsEquivalentTo(expected.RetryOptions), Is.True, "The retries should match.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient.CreateProducer" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void CreateProducerReceivesTheDefaultRetryPolicy()
        {
            var retryOptions = new RetryOptions
            {
                MaximumRetries = 99,
                MaximumDelay = TimeSpan.FromHours(72),
                Delay = TimeSpan.FromSeconds(27)
            };

            var clientOptions = new EventHubClientOptions
            {
                RetryOptions = retryOptions
            };

            var connectionString = "Endpoint=value.com;SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]";
            var mockClient = new ReadableOptionsMock(connectionString, clientOptions);

            mockClient.CreateProducer();

            Assert.That(mockClient.RetryPolicy, Is.Not.Null, "The client should have a retry policy set.");
            Assert.That(mockClient.ProducerDefaultRetry, Is.Not.Null, "The producer should have received a default retry policy.");
            Assert.That(mockClient.ProducerDefaultRetry, Is.SameAs(mockClient.RetryPolicy), "The client retry policy should have been used as the default.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient.CreateConsumer" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void CreateConsumerCreatesDefaultWhenNoOptionsArePassed()
        {
            var retryOptions = new RetryOptions
            {
                MaximumRetries = 99,
                MaximumDelay = TimeSpan.FromHours(72),
                Delay = TimeSpan.FromSeconds(27)
            };

            var clientOptions = new EventHubClientOptions
            {
                RetryOptions = retryOptions
            };

            var expectedOptions = new EventHubConsumerOptions
            {
                RetryOptions = retryOptions
            };

            var expectedConsumerGroup = EventHubConsumer.DefaultConsumerGroupName;
            var expectedPartition = "56767";
            var expectedPosition = EventPosition.FromEnqueuedTime(DateTimeOffset.Parse("2015-10-27T12:00:00Z"));
            var connectionString = "Endpoint=value.com;SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]";
            var mockClient = new ReadableOptionsMock(connectionString, clientOptions);

            mockClient.CreateConsumer(expectedConsumerGroup, expectedPartition, expectedPosition);
            var actualOptions = mockClient.ConsumerOptions;

            Assert.That(actualOptions, Is.Not.Null, "The consumer options should have been set.");
            Assert.That(actualOptions.OwnerLevel, Is.EqualTo(expectedOptions.OwnerLevel), "The owner levels should match.");
            Assert.That(actualOptions.Identifier, Is.EqualTo(expectedOptions.Identifier), "The identifiers should match.");
            Assert.That(actualOptions.PrefetchCount, Is.EqualTo(expectedOptions.PrefetchCount), "The prefetch counts should match.");
            Assert.That(actualOptions.RetryOptions.IsEquivalentTo(expectedOptions.RetryOptions), Is.True, "The retries should match.");
            Assert.That(actualOptions.MaximumReceiveWaitTimeOrDefault, Is.EqualTo(expectedOptions.MaximumReceiveWaitTimeOrDefault), "The wait times should match.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient.CreateConsumer" />
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

            var clientOptions = new EventHubClientOptions
            {
                RetryOptions = retryOptions
            };

            var expectedOptions = new EventHubConsumerOptions
            {
                OwnerLevel = 251,
                Identifier = "Bob",
                PrefetchCount = 600,
                RetryOptions = retryOptions,
                DefaultMaximumReceiveWaitTime = TimeSpan.FromSeconds(123)
            };

            var expectedConsumerGroup = "SomeGroup";
            var expectedPartition = "56767";
            var expectedPosition = EventPosition.FromSequenceNumber(123);
            var connectionString = "Endpoint=value.com;SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]";
            var mockClient = new ReadableOptionsMock(connectionString, clientOptions);

            mockClient.CreateConsumer(expectedConsumerGroup, expectedPartition, expectedPosition, expectedOptions);
            var actualOptions = mockClient.ConsumerOptions;

            Assert.That(actualOptions, Is.Not.Null, "The consumer options should have been set.");
            Assert.That(actualOptions, Is.Not.SameAs(expectedOptions), "A clone of the options should have been made.");
            Assert.That(actualOptions.OwnerLevel, Is.EqualTo(expectedOptions.OwnerLevel), "The owner levels should match.");
            Assert.That(actualOptions.Identifier, Is.EqualTo(expectedOptions.Identifier), "The identifiers should match.");
            Assert.That(actualOptions.PrefetchCount, Is.EqualTo(expectedOptions.PrefetchCount), "The prefetch counts should match.");
            Assert.That(actualOptions.RetryOptions.IsEquivalentTo(expectedOptions.RetryOptions), Is.True, "The retries should match.");
            Assert.That(actualOptions.MaximumReceiveWaitTimeOrDefault, Is.EqualTo(expectedOptions.MaximumReceiveWaitTimeOrDefault), "The wait times should match.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient.CreateConsumer" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void CreateConsumerReceivesTheDefaultRetryPolicy()
        {
            var retryOptions = new RetryOptions
            {
                MaximumRetries = 99,
                MaximumDelay = TimeSpan.FromHours(72),
                Delay = TimeSpan.FromSeconds(27)
            };

            var clientOptions = new EventHubClientOptions
            {
                RetryOptions = retryOptions
            };

            var connectionString = "Endpoint=value.com;SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]";
            var mockClient = new ReadableOptionsMock(connectionString, clientOptions);

            mockClient.CreateConsumer("bleh", "1", EventPosition.Earliest);

            Assert.That(mockClient.RetryPolicy, Is.Not.Null, "The client should have a retry policy set.");
            Assert.That(mockClient.ConsumerDefaultRetry, Is.Not.Null, "The consumer should have received a default retry policy.");
            Assert.That(mockClient.ConsumerDefaultRetry, Is.SameAs(mockClient.RetryPolicy), "The client retry policy should have been used as the default.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient.CreateConsumer" />
        ///    method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CreateConsumerRequiresConsumerGroup(string consumerGroup)
        {
            var client = new EventHubClient("Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real]", "fake", new EventHubClientOptions());
            Assert.That(() => client.CreateConsumer(consumerGroup, "partition1", EventPosition.Earliest), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient.CreateConsumer" />
        ///    method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CreateConsumerRequiresPartition(string partition)
        {
            var client = new EventHubClient("Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real]", "fake", new EventHubClientOptions());
            Assert.That(() => client.CreateConsumer("someGroup", partition, EventPosition.Earliest), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient.CreateConsumer" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void CreateConsumerRequiresEventPosition()
        {
            var client = new EventHubClient("Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real]", "fake", new EventHubClientOptions());
            Assert.That(() => client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, "123", null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubClient.CloseAsync" />
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
        ///   Verifies functionality of the <see cref="EventHubClient.DisposeAsync" />
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
        ///    Verifies functionality of the <see cref="EventHubClient.GetPartitionIdsAsync" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public async Task GetPartitionIdsAsyncDelegatesToGetProperties()
        {
            var date = DateTimeOffset.Parse("2015-10-27T12:00:00Z");
            var partitionIds = new[] { "first", "second", "third" };
            var properties = new EventHubProperties("dummy", date, partitionIds);
            var mockClient = new Mock<EventHubClient> { CallBase = true };

            mockClient
                .Setup(client => client.GetPropertiesAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(properties))
                .Verifiable("GetPropertiesAcync should have been delegated to.");

            var actual = await mockClient.Object.GetPartitionIdsAsync(CancellationToken.None);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.EqualTo(partitionIds));

            mockClient.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubClient.RetryPolicy" />
        ///   setter.
        /// </summary>
        ///
        [Test]
        public void SettingTheRetryPolicyUpdatesState()
        {
            var connectionString = "Endpoint=value.com;SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]";
            var clientOptions = new EventHubClientOptions();
            var mockClient = new ReadableOptionsMock(connectionString, clientOptions);

            var newRetry = Mock.Of<EventHubRetryPolicy>();
            mockClient.RetryPolicy = newRetry;

            Assert.That(mockClient.RetryPolicy, Is.SameAs(newRetry), "The client should have the correct retry policy set.");
            Assert.That(mockClient.ClientOptions.RetryOptions, Is.Null, "The retry options should have been cleared when a new retry policy is set.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubClient.RetryPolicy" />
        ///   setter.
        /// </summary>
        ///
        [Test]
        public void SettingTheRetryPolicyUpdatesTheTransportClient()
        {
            var newRetry = Mock.Of<EventHubRetryPolicy>();
            var transportClient = new ObservableTransportClientMock();
            var client = new InjectableTransportClientMock(transportClient, "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake");

            client.RetryPolicy = newRetry;
            Assert.That(transportClient.UpdateRetryPolicyCalledWith, Is.SameAs(newRetry), "The retry policy should have been passed as the update.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubClient.GetPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetPropertiesAsyncInvokesTheTransportClient()
        {
            var transportClient = new ObservableTransportClientMock();
            var client = new InjectableTransportClientMock(transportClient, "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake");

            await client.GetPropertiesAsync(CancellationToken.None);

            Assert.That(transportClient.WasGetPropertiesCalled, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubClient.GetPartitionPropertiesAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetPartitionPropertiesAsyncInvokesTheTransportClient()
        {
            var transportClient = new ObservableTransportClientMock();
            var client = new InjectableTransportClientMock(transportClient, "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake");
            var expectedId = "BB33";

            await client.GetPartitionPropertiesAsync(expectedId);

            Assert.That(transportClient.GetPartitionPropertiesCalledForId, Is.EqualTo(expectedId));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubClient.CreateProducer" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateProducerInvokesTheTransportClient()
        {
            var transportClient = new ObservableTransportClientMock();
            var client = new InjectableTransportClientMock(transportClient, "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake");
            var expectedOptions = new EventHubProducerOptions { RetryOptions = new RetryOptions { MaximumRetries = 6, TryTimeout = TimeSpan.FromMinutes(4) } };

            client.CreateProducer(expectedOptions);
            (var actualOptions, var actualDefaultRetry) = transportClient.CreateProducerCalledWith;

            Assert.That(actualOptions, Is.Not.Null, "The producer options should have been set.");
            Assert.That(actualOptions.PartitionId, Is.EqualTo(expectedOptions.PartitionId), "The partition identifiers should match.");
            Assert.That(actualOptions.RetryOptions.IsEquivalentTo(expectedOptions.RetryOptions), Is.True, "The retry options should match.");
            Assert.That(actualDefaultRetry, Is.SameAs(client.RetryPolicy), "The client retry policy should have been used as the default.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubClient.CreateConsumer" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateConsumerInvokesTheTransportClient()
        {
            var transportClient = new ObservableTransportClientMock();
            var client = new InjectableTransportClientMock(transportClient, "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake");
            var expectedOptions = new EventHubConsumerOptions { RetryOptions = new RetryOptions { MaximumRetries = 67 } };
            var expectedPosition = EventPosition.FromOffset(65);
            var expectedPartition = "2123";
            var expectedConsumerGroup = EventHubConsumer.DefaultConsumerGroupName;

            client.CreateConsumer(expectedConsumerGroup, expectedPartition, expectedPosition, expectedOptions);
            (var actualConsumerGroup, var actualPartition, var actualPosition, var actualOptions, var actualDefaultRetry) = transportClient.CreateConsumerCalledWith;

            Assert.That(actualPartition, Is.EqualTo(expectedPartition), "The partition should have been passed.");
            Assert.That(actualConsumerGroup, Is.EqualTo(expectedConsumerGroup), "The consumer groups should match.");
            Assert.That(actualPosition.Offset, Is.EqualTo(expectedPosition.Offset), "The event position to receive should match.");
            Assert.That(actualOptions, Is.Not.Null, "The consumer options should have been set.");
            Assert.That(actualPosition.Offset, Is.EqualTo(expectedPosition.Offset), "The event position to receive should match.");
            Assert.That(actualOptions.OwnerLevel, Is.EqualTo(expectedOptions.OwnerLevel), "The owner levels should match.");
            Assert.That(actualOptions.Identifier, Is.EqualTo(expectedOptions.Identifier), "The identifiers should match.");
            Assert.That(actualOptions.PrefetchCount, Is.EqualTo(expectedOptions.PrefetchCount), "The prefetch counts should match.");
            Assert.That(actualOptions.MaximumReceiveWaitTimeOrDefault, Is.EqualTo(expectedOptions.MaximumReceiveWaitTimeOrDefault), "The wait times should match.");
            Assert.That(actualDefaultRetry, Is.SameAs(client.RetryPolicy), "The client retry policy should have been used as the default.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubClient.CloseAsync" />
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
        ///   Verifies functionality of the <see cref="EventHubClient.CloseAsync" />
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
            var host = "my.eventhub.com";
            var path = "someHub/";
            var transportClient = new ObservableTransportClientMock();
            var client = new InjectableTransportClientMock(transportClient, "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake");
            var resource = BuildResource(client, TransportType.AmqpWebSockets, host, path);

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
        public void BuildResourceConstructsFromHostAndPath()
        {
            var host = "my.eventhub.com";
            var path = "someHub";
            var transportClient = new ObservableTransportClientMock();
            var client = new InjectableTransportClientMock(transportClient, "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake");
            var expectedPath = $"/{ path.ToLowerInvariant() }";
            var resource = BuildResource(client, TransportType.AmqpTcp, host, path);

            Assert.That(resource, Is.Not.Null.Or.Empty, "The resource should have been populated.");

            var uri = new Uri(resource, UriKind.Absolute);

            Assert.That(uri.Host, Is.EqualTo(host), "The resource should match the host.");
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
        private string BuildResource(EventHubClient client,
                                     TransportType transportType,
                                     string host,
                                     string eventHubName) =>
             typeof(EventHubClient)
                 .GetMethod("BuildResource", BindingFlags.Static | BindingFlags.NonPublic)
                 .Invoke(client, new object[] { transportType, host, eventHubName }) as string;

        /// <summary>
        ///   Provides a test shim for retrieving the transport client contained by an
        ///   Event Hub client instance.
        /// </summary>
        ///
        /// <param name="client">The client to retrieve the transport client of.</param>
        ///
        /// <returns>The transport client contained by the Event Hub client.</returns>
        ///
        private TransportEventHubClient GetTransportClient(EventHubClient client) =>
            typeof(EventHubClient)
                .GetProperty("InnerClient", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(client) as TransportEventHubClient;

        /// <summary>
        ///   Allows for the options used by the client to be exposed for testing purposes.
        /// </summary>
        ///
        public class ReadableOptionsMock : EventHubClient
        {
            public EventHubClientOptions ClientOptions =>
                typeof(EventHubClient)
                   .GetProperty(nameof(ClientOptions), BindingFlags.Instance | BindingFlags.NonPublic)
                   .GetValue(this) as EventHubClientOptions;

            public EventHubClientOptions TransportClientOptions;
            public EventHubProducerOptions ProducerOptions => _transportClient.CreateProducerCalledWith.Options;
            public EventHubRetryPolicy ProducerDefaultRetry => _transportClient.CreateProducerCalledWith.DefaultRetry;
            public EventHubConsumerOptions ConsumerOptions => _transportClient.CreateConsumerCalledWith.Options;
            public EventHubRetryPolicy ConsumerDefaultRetry => _transportClient.CreateConsumerCalledWith.DefaultRetry;

            private ObservableTransportClientMock _transportClient;

            public ReadableOptionsMock(string connectionString,
                                       EventHubClientOptions clientOptions = default) : base(connectionString, clientOptions)
            {
            }

            public ReadableOptionsMock(string host,
                                       string eventHubName,
                                       TokenCredential credential,
                                       EventHubClientOptions clientOptions = default) : base(host, eventHubName, credential, clientOptions)
            {
            }

            internal override TransportEventHubClient BuildTransportClient(string host, string eventHubName, TokenCredential credential, EventHubClientOptions options, EventHubRetryPolicy defaultRetry)
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
        public class ObservableOperationsMock : EventHubClient
        {
            public bool WasCloseAsyncCalled = false;

            public ObservableOperationsMock(string connectionString,
                                       EventHubClientOptions clientOptions = default) : base(connectionString, clientOptions)
            {
            }

            public ObservableOperationsMock(string host,
                                       string eventHubName,
                                       TokenCredential credential,
                                       EventHubClientOptions clientOptions = default) : base(host, eventHubName, credential, clientOptions)
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
        private class InjectableTransportClientMock : EventHubClient
        {
            public TransportEventHubClient TransportClient;

            public InjectableTransportClientMock(TransportEventHubClient transportClient,
                                                 string connectionString,
                                                 EventHubClientOptions clientOptions = default) : base(connectionString, clientOptions)
            {
                TransportClient = transportClient;
                SetTransportClient(transportClient);

            }

            public InjectableTransportClientMock(TransportEventHubClient transportClient,
                                                 string host,
                                                 string eventHubName,
                                                 TokenCredential credential,
                                                 EventHubClientOptions clientOptions = default) : base(host, eventHubName, credential, clientOptions)
            {
                TransportClient = transportClient;
                SetTransportClient(transportClient);
            }

            internal override TransportEventHubClient BuildTransportClient(string host,
                                                                           string eventHubName,
                                                                           TokenCredential credential,
                                                                           EventHubClientOptions options,
                                                                           EventHubRetryPolicy defaultRetry) => TransportClient;

            private void SetTransportClient(TransportEventHubClient transportClient) =>
                typeof(EventHubClient)
                    .GetProperty("InnerClient", BindingFlags.Instance | BindingFlags.NonPublic)
                    .SetValue(this, transportClient);

        }

        /// <summary>
        ///   Allows for observation of operations performed by the client for testing purposes.
        /// </summary>
        ///
        private class ObservableTransportClientMock : TransportEventHubClient
        {
            public (string ConsumerGroup, string Partition, EventPosition Position, EventHubConsumerOptions Options, EventHubRetryPolicy DefaultRetry) CreateConsumerCalledWith;
            public (EventHubProducerOptions Options, EventHubRetryPolicy DefaultRetry) CreateProducerCalledWith;
            public EventHubRetryPolicy UpdateRetryPolicyCalledWith;
            public string GetPartitionPropertiesCalledForId;
            public bool WasGetPropertiesCalled;
            public bool WasCloseCalled;

            public override Task<EventHubProperties> GetPropertiesAsync(CancellationToken cancellationToken = default)
            {
                WasGetPropertiesCalled = true;
                return Task.FromResult(default(EventHubProperties));
            }

            public override Task<PartitionProperties> GetPartitionPropertiesAsync(string partitionId,
                                                                                  CancellationToken cancellationToken = default)
            {
                GetPartitionPropertiesCalledForId = partitionId;
                return Task.FromResult(default(PartitionProperties));
            }

            public override EventHubProducer CreateProducer(EventHubProducerOptions producerOptions,
                                                            EventHubRetryPolicy defaultRetry)
            {
                CreateProducerCalledWith = (producerOptions, defaultRetry);
                return default(EventHubProducer);
            }

            public override EventHubConsumer CreateConsumer(string consumerGroup,
                                                            string partitionId,
                                                            EventPosition eventPosition,
                                                            EventHubConsumerOptions consumerOptions,
                                                            EventHubRetryPolicy defaultRetry)
            {
                CreateConsumerCalledWith = (consumerGroup, partitionId, eventPosition, consumerOptions, defaultRetry);
                return default(EventHubConsumer);
            }

            public override void UpdateRetryPolicy(EventHubRetryPolicy newRetryPolicy)
            {
                UpdateRetryPolicyCalledWith = newRetryPolicy;
            }

            public override Task CloseAsync(CancellationToken cancellationToken)
            {
                WasCloseCalled = true;
                return Task.CompletedTask;
            }
        }
    }
}
