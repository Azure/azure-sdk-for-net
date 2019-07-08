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
    [Parallelizable(ParallelScope.Children)]
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
                DefaultTimeout = TimeSpan.FromHours(2),
                Retry = new ExponentialRetry(TimeSpan.FromMinutes(10), TimeSpan.FromHours(1), 24),
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
            Assert.That(() => new EventHubClient(fakeConnection, "eventHub"), Throws.Nothing, "The constructor without options should not require the conection string event hub");
            Assert.That(() => new EventHubClient(fakeConnection, "eventHub", new EventHubClientOptions()), Throws.Nothing, "The constructor with options should not require the conection string event hub");
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
                                                          string eventHubPath,
                                                          TokenCredential credential)
        {
            Assert.That(() => new EventHubClient(host, eventHubPath, credential), Throws.InstanceOf<ArgumentException>());
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
            Assert.That(options.DefaultTimeout, Is.EqualTo(defaultOptions.DefaultTimeout), $"The { constructorDescription } constructor should have the correct default timeout.");
            Assert.That(options.Proxy, Is.EqualTo(defaultOptions.Proxy), $"The { constructorDescription } constructor should have the correct proxy.");
            Assert.That(ExponentialRetry.HaveSameConfiguration((ExponentialRetry)options.Retry, (ExponentialRetry)defaultOptions.Retry), $"The { constructorDescription } constructor should have the correct retry.");
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
            Assert.That(options.DefaultTimeout, Is.EqualTo(constructorOptions.DefaultTimeout), $"The { constructorDescription } constructor should have the correct default timeout.");
            Assert.That(options.Proxy, Is.EqualTo(constructorOptions.Proxy), $"The { constructorDescription } constructor should have the correct proxy.");
            Assert.That(ExponentialRetry.HaveSameConfiguration((ExponentialRetry)options.Retry, (ExponentialRetry)constructorOptions.Retry), $"The { constructorDescription } constructor should have the correct retry.");
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

            Assert.That(client.EventHubPath, Is.EqualTo(entityPath));
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

            Assert.That(client.EventHubPath, Is.EqualTo(entityPath));
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

            Assert.That(client.EventHubPath, Is.EqualTo(entityPath));
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
            Assert.That(() => new EventHubClient("host", "path", Mock.Of<TokenCredential>(), invalidOptions), Throws.ArgumentException, "The cexpanded argument onstructor should validate client options");
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
            Assert.That(options.DefaultTimeout, Is.EqualTo(defaultOptions.DefaultTimeout), $"The { constructorDescription } constructor should have the correct default timeout.");
            Assert.That(options.Proxy, Is.EqualTo(defaultOptions.Proxy), $"The { constructorDescription } constructor should have the correct proxy.");
            Assert.That(ExponentialRetry.HaveSameConfiguration((ExponentialRetry)options.Retry, (ExponentialRetry)defaultOptions.Retry), $"The { constructorDescription } constructor should have the correct retry.");
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
            Assert.That(options.DefaultTimeout, Is.EqualTo(constructorOptions.DefaultTimeout), $"The { constructorDescription } constructor should have the correct default timeout.");
            Assert.That(options.Proxy, Is.EqualTo(constructorOptions.Proxy), $"The { constructorDescription } constructor should have the correct proxy.");
            Assert.That(ExponentialRetry.HaveSameConfiguration((ExponentialRetry)options.Retry, (ExponentialRetry)constructorOptions.Retry), $"The { constructorDescription } constructor should have the correct retry.");
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

            Assert.That(() => client.BuildTransportClient(host, path, credential, options), Throws.Nothing);
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

            Assert.That(() => client.BuildTransportClient(host, path, credential, options), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient.CreateProducer" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void CreateProducerCreatesDefaultWhenNoOptionsArePassed()
        {
            var clientOptions = new EventHubClientOptions
            {
                Retry = new ExponentialRetry(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(3), 5),
                DefaultTimeout = TimeSpan.FromHours(24)
            };

            var expected = new EventHubProducerOptions
            {
                Retry = clientOptions.Retry,
                Timeout = clientOptions.DefaultTimeout
            };

            var connectionString = "Endpoint=value.com;SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]";
            var mockClient = new ReadableOptionsMock(connectionString, clientOptions);

            mockClient.CreateProducer();

            Assert.That(mockClient.ProducerOptions, Is.Not.Null, "The producer options should have been set.");
            Assert.That(mockClient.ProducerOptions.PartitionId, Is.EqualTo(expected.PartitionId), "The partition identifiers should match.");
            Assert.That(ExponentialRetry.HaveSameConfiguration((ExponentialRetry)mockClient.ProducerOptions.Retry, (ExponentialRetry)expected.Retry), "The retries should match.");
            Assert.That(mockClient.ProducerOptions.TimeoutOrDefault, Is.EqualTo(expected.TimeoutOrDefault), "The timeouts should match.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient.CreateProducer" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void CreateProducerCreatesDefaultWhenOptionsAreNotSet()
        {
            var clientOptions = new EventHubClientOptions
            {
                Retry = new ExponentialRetry(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(3), 5),
                DefaultTimeout = TimeSpan.FromHours(24)
            };

            var producerOptions = new EventHubProducerOptions
            {
                PartitionId = "123",
                Retry = null,
                Timeout = TimeSpan.Zero
            };

            var expected = new EventHubProducerOptions
            {
                PartitionId = producerOptions.PartitionId,
                Retry = clientOptions.Retry,
                Timeout = clientOptions.DefaultTimeout
            };

            var connectionString = "Endpoint=value.com;SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]";
            var mockClient = new ReadableOptionsMock(connectionString, clientOptions);

            mockClient.CreateProducer(producerOptions);

            Assert.That(mockClient.ProducerOptions, Is.Not.Null, "The producer options should have been set.");
            Assert.That(mockClient.ProducerOptions, Is.Not.SameAs(producerOptions), "The options should have been cloned.");
            Assert.That(mockClient.ProducerOptions.PartitionId, Is.EqualTo(expected.PartitionId), "The partition identifiers should match.");
            Assert.That(ExponentialRetry.HaveSameConfiguration((ExponentialRetry)mockClient.ProducerOptions.Retry, (ExponentialRetry)expected.Retry), "The retries should match.");
            Assert.That(mockClient.ProducerOptions.TimeoutOrDefault, Is.EqualTo(expected.TimeoutOrDefault), "The timeouts should match.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient.CreateConsumer" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void CreateConsumerCreatesDefaultWhenNoOptionsArePassed()
        {
            var clientOptions = new EventHubClientOptions
            {
                Retry = new ExponentialRetry(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(3), 5),
                DefaultTimeout = TimeSpan.FromHours(24)
            };

            var expectedOptions = new EventHubConsumerOptions
            {
                Retry = clientOptions.Retry,
                DefaultMaximumReceiveWaitTime = clientOptions.DefaultTimeout

            };

            var expectedConsumerGroup = EventHubConsumer.DefaultConsumerGroupName;
            var expectedPartition = "56767";
            var expectedPosition = EventPosition.FromEnqueuedTime(DateTime.Parse("2015-10-27T12:00:00Z"));
            var connectionString = "Endpoint=value.com;SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]";
            var mockClient = new ReadableOptionsMock(connectionString, clientOptions);

            mockClient.CreateConsumer(expectedConsumerGroup, expectedPartition, expectedPosition);
            var actualOptions = mockClient.ConsumerOptions;

            Assert.That(actualOptions, Is.Not.Null, "The consumer options should have been set.");
            Assert.That(actualOptions.OwnerLevel, Is.EqualTo(expectedOptions.OwnerLevel), "The owner levels should match.");
            Assert.That(actualOptions.Identifier, Is.EqualTo(expectedOptions.Identifier), "The identifiers should match.");
            Assert.That(actualOptions.PrefetchCount, Is.EqualTo(expectedOptions.PrefetchCount), "The prefetch counts should match.");
            Assert.That(ExponentialRetry.HaveSameConfiguration((ExponentialRetry)actualOptions.Retry, (ExponentialRetry)expectedOptions.Retry), "The retries should match.");
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
            var clientOptions = new EventHubClientOptions
            {
                Retry = new ExponentialRetry(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(3), 5),
                DefaultTimeout = TimeSpan.FromHours(24)
            };

            var expectedOptions = new EventHubConsumerOptions
            {
                OwnerLevel = 251,
                Identifier = "Bob",
                PrefetchCount = 600,
                Retry = clientOptions.Retry,
                DefaultMaximumReceiveWaitTime = clientOptions.DefaultTimeout

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
            Assert.That(ExponentialRetry.HaveSameConfiguration((ExponentialRetry)actualOptions.Retry, (ExponentialRetry)expectedOptions.Retry), "The retries should match.");
            Assert.That(actualOptions.MaximumReceiveWaitTimeOrDefault, Is.EqualTo(expectedOptions.MaximumReceiveWaitTimeOrDefault), "The wait times should match.");
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
            var expectedOptions = new EventHubProducerOptions { Retry = Retry.Default };

            client.CreateProducer(expectedOptions);
            var actualOptions = transportClient.CreateProducerCalledWithOptions;

            Assert.That(actualOptions, Is.Not.Null, "The producer options should have been set.");
            Assert.That(actualOptions.PartitionId, Is.EqualTo(expectedOptions.PartitionId), "The partition identifiers should match.");
            Assert.That(ExponentialRetry.HaveSameConfiguration((ExponentialRetry)actualOptions.Retry, (ExponentialRetry)expectedOptions.Retry), "The retries should match.");
            Assert.That(actualOptions.TimeoutOrDefault, Is.EqualTo(expectedOptions.TimeoutOrDefault), "The timeouts should match.");
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
            var expectedOptions = new EventHubConsumerOptions { Retry = Retry.Default };
            var expectedPosition = EventPosition.FromOffset(65);
            var expectedPartition = "2123";
            var expectedConsumerGroup = EventHubConsumer.DefaultConsumerGroupName;

            client.CreateConsumer(expectedConsumerGroup, expectedPartition, expectedPosition, expectedOptions);
            (var actualConsumerGroup, var actualPartition, var actualPosition, var actualOptions) = transportClient.CreateConsumerCalledWith;

            Assert.That(actualPartition, Is.EqualTo(expectedPartition), "The partition should have been passed.");
            Assert.That(actualConsumerGroup, Is.EqualTo(expectedConsumerGroup), "The consumer groups should match.");
            Assert.That(actualPosition.Offset, Is.EqualTo(expectedPosition.Offset), "The event position to receive should match.");
            Assert.That(actualOptions, Is.Not.Null, "The consumer options should have been set.");
            Assert.That(actualPosition.Offset, Is.EqualTo(expectedPosition.Offset), "The event position to receive should match.");
            Assert.That(actualOptions.OwnerLevel, Is.EqualTo(expectedOptions.OwnerLevel), "The owner levels should match.");
            Assert.That(actualOptions.Identifier, Is.EqualTo(expectedOptions.Identifier), "The identifiers should match.");
            Assert.That(actualOptions.PrefetchCount, Is.EqualTo(expectedOptions.PrefetchCount), "The prefetch counts should match.");
            Assert.That(ExponentialRetry.HaveSameConfiguration((ExponentialRetry)actualOptions.Retry, (ExponentialRetry)expectedOptions.Retry), "The retries should match.");
            Assert.That(actualOptions.MaximumReceiveWaitTimeOrDefault, Is.EqualTo(expectedOptions.MaximumReceiveWaitTimeOrDefault), "The wait times should match.");
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
                                     string eventHubPath) =>
             typeof(EventHubClient)
                 .GetMethod("BuildResource", BindingFlags.Static | BindingFlags.NonPublic)
                 .Invoke(client, new object[] { transportType, host, eventHubPath }) as string;

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
            public EventHubProducerOptions ProducerOptions => _transportClient.CreateProducerCalledWithOptions;
            public EventHubConsumerOptions ConsumerOptions => _transportClient.CreateConsumerCalledWith.Options;

            private ObservableTransportClientMock _transportClient;

            public ReadableOptionsMock(string connectionString,
                                       EventHubClientOptions clientOptions = default) : base(connectionString, clientOptions)
            {
            }

            public ReadableOptionsMock(string host,
                                       string eventHubPath,
                                       TokenCredential credential,
                                       EventHubClientOptions clientOptions = default) : base(host, eventHubPath, credential, clientOptions)
            {
            }

            internal override TransportEventHubClient BuildTransportClient(string host, string eventHubPath, TokenCredential credential, EventHubClientOptions options)
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
                                       string eventHubPath,
                                       TokenCredential credential,
                                       EventHubClientOptions clientOptions = default) : base(host, eventHubPath, credential, clientOptions)
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
                                                 string eventHubPath,
                                                 TokenCredential credential,
                                                 EventHubClientOptions clientOptions = default) : base(host, eventHubPath, credential, clientOptions)
            {
                TransportClient = transportClient;
                SetTransportClient(transportClient);
            }

            internal override TransportEventHubClient BuildTransportClient(string host, string eventHubPath, TokenCredential credential, EventHubClientOptions options) => TransportClient;

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
            public (string ConsumerGroup, string Partition, EventPosition position, EventHubConsumerOptions Options) CreateConsumerCalledWith;
            public EventHubProducerOptions CreateProducerCalledWithOptions;
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

            public override EventHubProducer CreateProducer(EventHubProducerOptions producerOptions = default)
            {
                CreateProducerCalledWithOptions = producerOptions;
                return default(EventHubProducer);
            }

            public override EventHubConsumer CreateConsumer(string consumerGroup, string partitionId, EventPosition eventPosition, EventHubConsumerOptions consumerOptions)
            {
                CreateConsumerCalledWith = (consumerGroup, partitionId, eventPosition, consumerOptions);
                return default(EventHubConsumer);
            }

            public override Task CloseAsync(CancellationToken cancellationToken)
            {
                WasCloseCalled = true;
                return Task.CompletedTask;
            }
        }
    }
}
