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
            Assert.That(() => new EventHubClient(connectionString, new EventHubClientOptions()), Throws.ArgumentException, "The constructor with options should perform validation.");
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
            Assert.That(() => new EventHubClient(fakeConnection, null), Throws.Nothing);
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
        public void ConstructorWithConnectionStringInitializesProperties()
        {
            var entityPath = "somePath";
            var fakeConnection = $"Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath={ entityPath }";
            var client = new EventHubClient(fakeConnection);

            Assert.That(client.EventHubPath, Is.EqualTo(entityPath));
            Assert.That(GetCredential(client), Is.Null);
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
            Assert.That(GetCredential(client), Is.EqualTo(credential));
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

            var client = new EventHubClient("Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake");
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
            var options = new EventHubClientOptions { TransportType = TransportType.AmqpTcp };
            var signature = new SharedAccessSignature(options.TransportType, host, path, keyName, key);
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
        public void TransportClientReceivesClonesOptions(ReadableOptionsMock client,
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
            var options = new EventHubClientOptions { TransportType = connectionType };
            var signature = new SharedAccessSignature(connectionType, host, path, keyName, key);
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
            var connectionType = (TransportType)Int32.MinValue;
            var options = new EventHubClientOptions { TransportType = connectionType };
            var signature = new SharedAccessSignature(TransportType.AmqpTcp, host, path, keyName, key);
            var credential = new SharedAccessSignatureCredential(signature);
            var client = new EventHubClient(host, path, credential);

            Assert.That(() => client.BuildTransportClient(host, path, credential, options), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient.CreateSender" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void CreateEventSenderCreatesDefaultWhenNoOptionsArePassed()
        {
            var clientOptions = new EventHubClientOptions
            {
                Retry = new ExponentialRetry(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(3), 5),
                DefaultTimeout = TimeSpan.FromHours(24)
            };

            var expected = new EventSenderOptions
            {
                Retry = clientOptions.Retry,
                Timeout = clientOptions.DefaultTimeout
            };

            var connectionString = "Endpoint=value.com;SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]";
            var mockClient = new ReadableOptionsMock(connectionString, clientOptions);

            mockClient.CreateSender();

            Assert.That(mockClient.SenderOptions, Is.Not.Null, "The sender options should have been set.");
            Assert.That(mockClient.SenderOptions.PartitionId, Is.EqualTo(expected.PartitionId), "The partition identifiers should match.");
            Assert.That(ExponentialRetry.HaveSameConfiguration((ExponentialRetry)mockClient.SenderOptions.Retry, (ExponentialRetry)expected.Retry), "The retries should match.");
            Assert.That(mockClient.SenderOptions.TimeoutOrDefault, Is.EqualTo(expected.TimeoutOrDefault), "The timeouts should match.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient.CreateSender" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void CreateEventSenderCreatesDefaultWhenOptionsAreNotSet()
        {
            var clientOptions = new EventHubClientOptions
            {
                Retry = new ExponentialRetry(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(3), 5),
                DefaultTimeout = TimeSpan.FromHours(24)
            };

            var senderOptions = new EventSenderOptions
            {
                PartitionId = "123",
                Retry = null,
                Timeout = TimeSpan.Zero
            };

            var expected = new EventSenderOptions
            {
                PartitionId = senderOptions.PartitionId,
                Retry = clientOptions.Retry,
                Timeout = clientOptions.DefaultTimeout
            };

            var connectionString = "Endpoint=value.com;SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]";
            var mockClient = new ReadableOptionsMock(connectionString, clientOptions);

            mockClient.CreateSender(senderOptions);

            Assert.That(mockClient.SenderOptions, Is.Not.Null, "The sender options should have been set.");
            Assert.That(mockClient.SenderOptions, Is.Not.SameAs(senderOptions), "The options should have been cloned.");
            Assert.That(mockClient.SenderOptions.PartitionId, Is.EqualTo(expected.PartitionId), "The partition identifiers should match.");
            Assert.That(ExponentialRetry.HaveSameConfiguration((ExponentialRetry)mockClient.SenderOptions.Retry, (ExponentialRetry)expected.Retry), "The retries should match.");
            Assert.That(mockClient.SenderOptions.TimeoutOrDefault, Is.EqualTo(expected.TimeoutOrDefault), "The timeouts should match.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient.CreatePartitionReceiver" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void CreatePartitionReceiverCreatesDefaultWhenNoOptionsArePassed()
        {
            var clientOptions = new EventHubClientOptions
            {
                Retry = new ExponentialRetry(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(3), 5),
                DefaultTimeout = TimeSpan.FromHours(24)
            };

            var expectedOptions = new EventReceiverOptions
            {
                Retry = clientOptions.Retry,
                DefaultMaximumReceiveWaitTime = clientOptions.DefaultTimeout

            };

            var expectedPartition = "56767";
            var connectionString = "Endpoint=value.com;SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]";
            var mockClient = new ReadableOptionsMock(connectionString, clientOptions);
            var receiver = mockClient.CreateReceiver(expectedPartition);
            var actualOptions = mockClient.ReceiverOptions;

            Assert.That(receiver.PartitionId, Is.EqualTo(expectedPartition), "The partition should match.");
            Assert.That(actualOptions, Is.Not.Null, "The receiver options should have been set.");
            Assert.That(actualOptions.BeginReceivingAt.Offset, Is.EqualTo(expectedOptions.BeginReceivingAt.Offset), "The beginning position to receive should match.");
            Assert.That(actualOptions.ConsumerGroup, Is.EqualTo(expectedOptions.ConsumerGroup), "The consumer groups should match.");
            Assert.That(actualOptions.ExclusiveReceiverPriority, Is.EqualTo(expectedOptions.ExclusiveReceiverPriority), "The exclusive priorities should match.");
            Assert.That(actualOptions.Identifier, Is.EqualTo(expectedOptions.Identifier), "The identifiers should match.");
            Assert.That(actualOptions.PrefetchCount, Is.EqualTo(expectedOptions.PrefetchCount), "The prefetch counts should match.");
            Assert.That(ExponentialRetry.HaveSameConfiguration((ExponentialRetry)actualOptions.Retry, (ExponentialRetry)expectedOptions.Retry), "The retries should match.");
            Assert.That(actualOptions.MaximumReceiveWaitTimeOrDefault, Is.EqualTo(expectedOptions.MaximumReceiveWaitTimeOrDefault), "The wait times should match.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubClient.CreatePartitionReceiver" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void CreatePartitionReceiverCreatesDefaultWhenOptionsAreNotSet()
        {
            var clientOptions = new EventHubClientOptions
            {
                Retry = new ExponentialRetry(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(3), 5),
                DefaultTimeout = TimeSpan.FromHours(24)
            };

            var expectedOptions = new EventReceiverOptions
            {
                BeginReceivingAt = EventPosition.FromOffset(65),
                ConsumerGroup = "SomeGroup",
                ExclusiveReceiverPriority = 251,
                Identifier = "Bob",
                PrefetchCount = 600,
                Retry = clientOptions.Retry,
                DefaultMaximumReceiveWaitTime = clientOptions.DefaultTimeout

            };

            var expectedPartition = "56767";
            var connectionString = "Endpoint=value.com;SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]";
            var mockClient = new ReadableOptionsMock(connectionString, clientOptions);
            var receiver = mockClient.CreateReceiver(expectedPartition, expectedOptions);
            var actualOptions = mockClient.ReceiverOptions;

            Assert.That(receiver.PartitionId, Is.EqualTo(expectedPartition), "The partition should match.");
            Assert.That(actualOptions, Is.Not.Null, "The receiver options should have been set.");
            Assert.That(actualOptions, Is.Not.SameAs(expectedOptions), "A clone of the options should have been made.");
            Assert.That(actualOptions.BeginReceivingAt.Offset, Is.EqualTo(expectedOptions.BeginReceivingAt.Offset), "The beginning position to receive should match.");
            Assert.That(actualOptions.ConsumerGroup, Is.EqualTo(expectedOptions.ConsumerGroup), "The consumer groups should match.");
            Assert.That(actualOptions.ExclusiveReceiverPriority, Is.EqualTo(expectedOptions.ExclusiveReceiverPriority), "The exclusive priorities should match.");
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
            var date = DateTimeOffset.Parse("2015-10-27T12:00:00Z").DateTime;
            var partitionIds = new[] { "first", "second", "third" };
            var properties = new EventHubProperties("dummy", date, partitionIds, date);
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
        ///   Provides a test shim for retrieving the credential that a client was
        ///   created with.
        /// </summary>
        ///
        /// <param name="client">The client to retrieve the credential for.</param>
        ///
        /// <returns>The credential with which the client was created.</returns>
        ///
        private TokenCredential GetCredential(EventHubClient client) =>
                    typeof(EventHubClient)
                        .GetProperty("Credential", BindingFlags.Instance | BindingFlags.NonPublic)
                        .GetValue(client) as TokenCredential;

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
            public EventSenderOptions SenderOptions => _transportClient.CreateSenderCalledWithOptions;
            public EventReceiverOptions ReceiverOptions;

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

            internal override EventReceiver BuildEventReceiver(TransportType connectionType, string eventHubPath, string partitionId, EventReceiverOptions options)
            {
                ReceiverOptions = options;
                return base.BuildEventReceiver(connectionType, eventHubPath, partitionId, options);
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
            public EventSenderOptions CreateSenderCalledWithOptions = default;
            public string GetPartitionPropertiesCalledForId = default;
            public bool WasGetPropertiesCalled = false;
            public bool WasCloseCalled = false;

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

            public override EventSender CreateSender(EventSenderOptions senderOptions = default)
            {
                CreateSenderCalledWithOptions = senderOptions;
                return default(EventSender);
            }

            public override Task CloseAsync(CancellationToken cancellationToken)
            {
                WasCloseCalled = true;
                return Task.CompletedTask;
            }
        }
    }
}
