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
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Producer;
using Moq;
using NUnit.Framework;

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
        public static IEnumerable<object[]> ConstructorTokenCredentialInvalidCases()
        {
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net");

            yield return new object[] { null, "fakePath", credential.Object };
            yield return new object[] { "", "fakePath", credential.Object };
            yield return new object[] { "FakeNamespace", null, credential.Object };
            yield return new object[] { "FakNamespace", "", credential.Object };
            yield return new object[] { "FakeNamespace", "FakePath", null };
            yield return new object[] { "sb://fakenamspace.com", "FakePath", credential.Object };
        }

        /// <summary>
        ///   Provides the invalid test cases for the constructor tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ConstructorSharedKeyCredentialInvalidCases()
        {
            var credential = new EventHubsSharedAccessKeyCredential("keyName", "keyValue");

            yield return new object[] { null, "fakePath", credential };
            yield return new object[] { "", "fakePath", credential };
            yield return new object[] { "FakeNamespace", null, credential };
            yield return new object[] { "FakNamespace", "", credential };
            yield return new object[] { "FakeNamespace", "FakePath", null };
            yield return new object[] { "sb://fakenamspace.com", "FakePath", credential };
        }

        /// <summary>
        ///   Provides test cases for the constructor tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ConstructorCreatesDefaultOptionsCases()
        {
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net");
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake";

            yield return new object[] { new ReadableOptionsMock(fakeConnection), "simple connection string" };
            yield return new object[] { new ReadableOptionsMock(fakeConnection), "connection string with null options" };
            yield return new object[] { new ReadableOptionsMock("fullyQualifiedNamespace", "path", credential.Object), "expanded argument" };
            yield return new object[] { new ReadableOptionsMock("fullyQualifiedNamespace", "path", new EventHubsSharedAccessKeyCredential("key", "value")), "expanded argument" };
        }

        /// <summary>
        ///   Provides test cases for the constructor tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ConstructorClonesOptionsCases()
        {
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net");
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake";

            var options = new EventHubConnectionOptions
            {
                TransportType = EventHubsTransportType.AmqpWebSockets,
                Proxy = Mock.Of<IWebProxy>()
            };

            yield return new object[] { new ReadableOptionsMock(fakeConnection, options), options, "connection string" };
            yield return new object[] { new ReadableOptionsMock("fullyQualifiedNamespace", "path", credential.Object, options), options, "expanded argument" };
            yield return new object[] { new ReadableOptionsMock("fullyQualifiedNamespace", "path", new EventHubsSharedAccessKeyCredential("key", "value"), options), options, "expanded argument" };
        }

        /// <summary>
        ///   Provides the test cases for valid connection types.
        /// </summary>
        ///
        public static IEnumerable<object[]> ValidConnectionTypeCases()
        {
            yield return new object[] { EventHubsTransportType.AmqpTcp };
            yield return new object[] { EventHubsTransportType.AmqpWebSockets };
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
            Assert.That(() => new EventHubConnection(connectionString), Throws.InstanceOf<ArgumentException>(), "The constructor without options should perform validation.");
            Assert.That(() => new EventHubConnection(connectionString, "eventHub"), Throws.InstanceOf<ArgumentException>(), "The constructor with the event hub without options should perform validation.");
            Assert.That(() => new EventHubConnection(connectionString, "eventHub", new EventHubConnectionOptions()), Throws.InstanceOf<ArgumentException>(), "The constructor with the event hub and options should perform validation.");
            Assert.That(() => new EventHubConnection(connectionString, new EventHubConnectionOptions()), Throws.InstanceOf<ArgumentException>(), "The constructor with options and no event hub should perform validation.");
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
        [TestCase("SharedAccessSignature=[value];EntityPath=[value]")]
        [TestCase("SharedAccessSignature=[value]")]
        [TestCase("Endpoint=value.com;SharedAccessKey=[value];EntityPath=[value]")]
        [TestCase("Endpoint=value.com;SharedAccessKeyName=[value];EntityPath=[value]")]
        [TestCase("Endpoint=value.com;SharedAccessKeyName=[value];SharedAccessKey=[value]")]
        [TestCase("HostName=value.azure-devices.net;SharedAccessKeyName=[value];SharedAccessKey=[value]")]
        [TestCase("HostName=value.azure-devices.net;SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]")]
        public void ConstructorValidatesConnectionStringForMissingInformation(string connectionString)
        {
            Assert.That(() => new EventHubConnection(connectionString), Throws.ArgumentException.And.Message.StartsWith(Resources.MissingConnectionInformation));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]

        [TestCase("Endpoint=value.azure-devices.net;SharedAccessKeyName=[value];SharedAccessSignature=[sas];EntityPath=[value]")]
        [TestCase("Endpoint=value.azure-devices.net;SharedAccessKey=[value];SharedAccessSignature=[sas];EntityPath=[value]")]
        [TestCase("Endpoint=value.azure-devices.net;SharedAccessKeyName=[value];SharedAccessKey=[value];SharedAccessSignature=[sas];EntityPath=[value]")]
        public void ConstructorValidatesConnectionStringForDuplicateAuthorization(string connectionString)
        {
            Assert.That(() => new EventHubConnection(connectionString), Throws.ArgumentException.And.Message.StartsWith(Resources.OnlyOneSharedAccessAuthorizationMayBeSpecified));
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
        [TestCaseSource(nameof(ConstructorTokenCredentialInvalidCases))]
        public void ConstructorValidatesExpandedArgumentsForTokenCredential(string fullyQualifiedNamespace,
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
        [TestCaseSource(nameof(ConstructorSharedKeyCredentialInvalidCases))]
        public void ConstructorValidatesExpandedArgumentsForSharedKeyCredential(string fullyQualifiedNamespace,
                                                                                string eventHubName,
                                                                                object credential)
        {
            Assert.That(() => new EventHubConnection(fullyQualifiedNamespace, eventHubName, (EventHubsSharedAccessKeyCredential)credential), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorCreatesDefaultOptionsCases))]
        public void ConstructorCreatesDefaultOptions(ReadableOptionsMock connection,
                                                     string constructorDescription)
        {
            var defaultOptions = new EventHubConnectionOptions();
            EventHubConnectionOptions options = connection.Options;

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
        public void ConstructorClonesOptions(ReadableOptionsMock connection,
                                             EventHubConnectionOptions constructorOptions,
                                             string constructorDescription)
        {
            EventHubConnectionOptions options = connection.Options;

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
            var connection = new EventHubConnection(fakeConnection);

            Assert.That(connection.EventHubName, Is.EqualTo(entityPath));
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
            var connection = new EventHubConnection(fakeConnection, entityPath);

            Assert.That(connection.EventHubName, Is.EqualTo(entityPath));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithTokenCredentialInitializesProperties()
        {
            var fullyQualifiedNamespace = "host.windows.servicebus.net";
            var entityPath = "somePath";
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net");
            var connection = new EventHubConnection(fullyQualifiedNamespace, entityPath, credential.Object);

            Assert.That(connection.EventHubName, Is.EqualTo(entityPath));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithSharedKeyCredentialInitializesProperties()
        {
            var fullyQualifiedNamespace = "host.windows.servicebus.net";
            var entityPath = "somePath";
            var credential = new EventHubsSharedAccessKeyCredential("key", "value");
            var connection = new EventHubConnection(fullyQualifiedNamespace, entityPath, credential);

            Assert.That(connection.EventHubName, Is.EqualTo(entityPath));
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
            var invalidOptions = new EventHubConnectionOptions { TransportType = EventHubsTransportType.AmqpTcp, Proxy = Mock.Of<IWebProxy>() };

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
            var token = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net");
            var invalidOptions = new EventHubConnectionOptions { TransportType = EventHubsTransportType.AmqpTcp, Proxy = Mock.Of<IWebProxy>() };
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
            var connection = new EventHubConnection("Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real]", "fake", new EventHubConnectionOptions());
            Assert.That(GetTransportClient(connection), Is.Not.Null);
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ContructorWithConnectionStringUsingSharedAccessSignatureCreatesTheCorrectTransportCredential()
        {
            var sasToken = new SharedAccessSignature("hub", "root", "abc1234").Value;
            var connection = new InjectableTransportClientMock(Mock.Of<TransportClient>(), $"Endpoint=sb://not-real.servicebus.windows.net/;EntityPath=fake;SharedAccessSignature={ sasToken }");

            Assert.That(connection.TransportClientCredential, Is.Not.Null, "The transport client should have been given a credential.");
            Assert.That(connection.TransportClientCredential.GetToken(default, default).Token, Is.EqualTo(sasToken), "The transport client credential should use the provided SAS token.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ContructorWithTokenCredentailCreatesTheTransportClient()
        {
            var fullyQualifiedNamespace = "my.eventhubs.com";
            var path = "some-hub";
            var keyName = "aWonderfulKey";
            var key = "ABC4223";
            var resource = $"amqps://{ fullyQualifiedNamespace }/{ path }";
            var options = new EventHubConnectionOptions { TransportType = EventHubsTransportType.AmqpTcp };
            var signature = new SharedAccessSignature(resource, keyName, key);
            var connection = new EventHubConnection(fullyQualifiedNamespace, path, new SharedAccessSignatureCredential(signature), options);

            Assert.That(GetTransportClient(connection), Is.Not.Null);
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ContructorWithSharedKeyCredentailCreatesTheTransportClient()
        {
            var fullyQualifiedNamespace = "my.eventhubs.com";
            var path = "some-hub";
            var keyName = "aWonderfulKey";
            var key = "ABC4223";
            var options = new EventHubConnectionOptions { TransportType = EventHubsTransportType.AmqpTcp };
            var credential = new EventHubsSharedAccessKeyCredential(keyName, key);
            var connection = new EventHubConnection(fullyQualifiedNamespace, path, credential, options);

            Assert.That(GetTransportClient(connection), Is.Not.Null);
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection.CreateTransportClient" />
        ///    method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorCreatesDefaultOptionsCases))]
        public void TransportClientReceivesDefaultOptions(ReadableOptionsMock connection,
                                                          string constructorDescription)
        {
            var defaultOptions = new EventHubConnectionOptions();
            EventHubConnectionOptions options = connection.TransportClientOptions;

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
        public void TransportClientReceivesClonedOptions(ReadableOptionsMock connection,
                                                         EventHubConnectionOptions constructorOptions,
                                                         string constructorDescription)
        {
            EventHubConnectionOptions options = connection.TransportClientOptions;

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
        public void BuildTransportClientAllowsLegalConnectionTypes(EventHubsTransportType connectionType)
        {
            var fullyQualifiedNamespace = "my.eventhubs.com";
            var path = "some-hub";
            var keyName = "aWonderfulKey";
            var key = "ABC4223";
            var resource = $"amqps://{ fullyQualifiedNamespace }/{ path }";
            var options = new EventHubConnectionOptions { TransportType = connectionType };
            var signature = new SharedAccessSignature(resource, keyName, key);
            var credential = new SharedAccessSignatureCredential(signature);
            var eventHubCredential = new EventHubTokenCredential(credential, resource);
            var connection = new EventHubConnection(fullyQualifiedNamespace, path, credential);

            Assert.That(() => connection.CreateTransportClient(fullyQualifiedNamespace, path, eventHubCredential, options), Throws.Nothing);
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
            var connectionType = (EventHubsTransportType)int.MinValue;
            var options = new EventHubConnectionOptions { TransportType = connectionType };
            var signature = new SharedAccessSignature(resource, keyName, key);
            var credential = new SharedAccessSignatureCredential(signature);
            var eventHubCredential = new EventHubTokenCredential(credential, resource);
            var connection = new EventHubConnection(fullyQualifiedNamespace, path, credential);

            Assert.That(() => connection.CreateTransportClient(fullyQualifiedNamespace, path, eventHubCredential, options), Throws.InstanceOf<ArgumentException>());
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
            var connection = new EventHubConnection("Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real]", "fake", new EventHubConnectionOptions());
            Assert.That(() => connection.CreateTransportConsumer(consumerGroup, "partition1", EventPosition.Earliest, Mock.Of<EventHubsRetryPolicy>()), Throws.InstanceOf<ArgumentException>());
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
            var connection = new EventHubConnection("Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real]", "fake", new EventHubConnectionOptions());
            Assert.That(() => connection.CreateTransportConsumer("someGroup", partition, EventPosition.Earliest, Mock.Of<EventHubsRetryPolicy>()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="EventHubConnection.CreateTransportConsumer" />
        ///    method.
        /// </summary>
        ///
        [Test]
        public void CreateConsumerRequiresRetryPolicy()
        {
            var connection = new EventHubConnection("Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real]", "fake", new EventHubConnectionOptions());
            Assert.That(() => connection.CreateTransportConsumer("someGroup", "0", EventPosition.Earliest, null), Throws.InstanceOf<ArgumentException>());
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
            var mockConnection = new Mock<EventHubConnection> { CallBase = true };

            mockConnection
                .Setup(connection => connection.GetPropertiesAsync(
                    It.IsAny<EventHubsRetryPolicy>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(properties))
                .Verifiable("GetPropertiesAcync should have been delegated to.");

            var actual = await mockConnection.Object.GetPartitionIdsAsync(Mock.Of<EventHubsRetryPolicy>(), CancellationToken.None);

            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.EqualTo(partitionIds));

            mockConnection.VerifyAll();
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
            var connection = new InjectableTransportClientMock(transportClient, "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake");

            await connection.GetPropertiesAsync(Mock.Of<EventHubsRetryPolicy>(), CancellationToken.None);

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
            var connection = new InjectableTransportClientMock(transportClient, "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake");
            var expectedId = "BB33";

            await connection.GetPartitionPropertiesAsync(expectedId, Mock.Of<EventHubsRetryPolicy>());

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
            var connection = new InjectableTransportClientMock(transportClient, "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake");
            var options = new EventHubProducerClientOptions { EnableIdempotentPartitions = true, RetryOptions = new EventHubsRetryOptions { MaximumRetries = 6, TryTimeout = TimeSpan.FromMinutes(4) } };
            var expectedFeatures = options.CreateFeatureFlags();
            var expectedPartitionOptions = new PartitionPublishingOptions { ProducerGroupId = 123 };
            var expectedRetry = options.RetryOptions.ToRetryPolicy();

            connection.CreateTransportProducer(null, expectedFeatures, expectedPartitionOptions, expectedRetry);

            Assert.That(transportClient.CreateProducerCalledWith, Is.Not.Null, "The producer options should have been set.");
            Assert.That(transportClient.CreateProducerCalledWith.PartitionId, Is.Null, "There should have been no partition specified.");
            Assert.That(transportClient.CreateProducerCalledWith.Features, Is.EqualTo(expectedFeatures), "The features should match.");
            Assert.That(transportClient.CreateProducerCalledWith.PartitionOptions, Is.Not.Null, "The partition options should have been specified.");
            Assert.That(transportClient.CreateProducerCalledWith.PartitionOptions, Is.SameAs(expectedPartitionOptions), "The partition options should match.");
            Assert.That(transportClient.CreateProducerCalledWith.RetryPolicy, Is.Not.Null, "The retry policy should have been specified.");
            Assert.That(transportClient.CreateProducerCalledWith.RetryPolicy, Is.SameAs(expectedRetry), "The retry policies should match.");
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
            var connection = new InjectableTransportClientMock(transportClient, "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake");
            var expectedPosition = EventPosition.FromOffset(65);
            var expectedPartition = "2123";
            var expectedConsumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
            var expectedRetryPolicy = new EventHubsRetryOptions { MaximumRetries = 67 }.ToRetryPolicy();
            var expectedTrackLastEnqueued = false;
            var expectedPrefetch = 99U;
            var expectedOwnerLevel = 123L;

            connection.CreateTransportConsumer(expectedConsumerGroup, expectedPartition, expectedPosition, expectedRetryPolicy, expectedTrackLastEnqueued, expectedOwnerLevel, expectedPrefetch);
            (var actualConsumerGroup, var actualPartition, EventPosition actualPosition, var actualRetry, var actualTrackLastEnqueued, var actualOwnerLevel, var actualPrefetch) = transportClient.CreateConsumerCalledWith;

            Assert.That(actualPartition, Is.EqualTo(expectedPartition), "The partition should have been passed.");
            Assert.That(actualConsumerGroup, Is.EqualTo(expectedConsumerGroup), "The consumer groups should match.");
            Assert.That(actualPosition.Offset, Is.EqualTo(expectedPosition.Offset), "The event position to receive should match.");
            Assert.That(actualRetry, Is.SameAs(expectedRetryPolicy), "The retryPolicy should match.");
            Assert.That(actualOwnerLevel, Is.EqualTo(expectedOwnerLevel), "The owner levels should match.");
            Assert.That(actualPrefetch, Is.EqualTo(expectedPrefetch), "The prefetch counts should match.");
            Assert.That(actualTrackLastEnqueued, Is.EqualTo(expectedTrackLastEnqueued), "The flag for tracking the last enqueued event should match.");
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
            var connection = new InjectableTransportClientMock(transportClient, "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake");

            await connection.CloseAsync();

            Assert.That(transportClient.WasCloseCalled, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsClient.BuildResource" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void BuildConnectionAudienceNormalizesTheResource()
        {
            var fullyQualifiedNamespace = "my.eventhub.com";
            var path = "someHub/";
            var transportClient = new ObservableTransportClientMock();
            var client = new InjectableTransportClientMock(transportClient, "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake");
            var resource = EventHubConnection.BuildConnectionAudience(EventHubsTransportType.AmqpWebSockets, fullyQualifiedNamespace, path);

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
        public void BuildConnectionAudienceConstructsFromNamespaceAndPath()
        {
            var fullyQualifiedNamespace = "my.eventhub.com";
            var path = "someHub";
            var transportClient = new ObservableTransportClientMock();
            var client = new InjectableTransportClientMock(transportClient, "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake");
            var expectedPath = $"/{ path.ToLowerInvariant() }";
            var resource = EventHubConnection.BuildConnectionAudience(EventHubsTransportType.AmqpTcp, fullyQualifiedNamespace, path);

            Assert.That(resource, Is.Not.Null.Or.Empty, "The resource should have been populated.");

            var uri = new Uri(resource, UriKind.Absolute);

            Assert.That(uri.Host, Is.EqualTo(fullyQualifiedNamespace), "The resource should match the host.");
            Assert.That(uri.AbsolutePath, Is.EqualTo(expectedPath), "The resource path should match the Event Hub path.");
        }

        /// <summary>
        ///   Provides a test shim for retrieving the transport client contained by an
        ///   Event Hub client instance.
        /// </summary>
        ///
        /// <param name="client">The client to retrieve the transport client of.</param>
        ///
        /// <returns>The transport client contained by the Event Hub connection.</returns>
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

            internal ReadableOptionsMock(string fullyQualifiedNamespace,
                                         string eventHubName,
                                         EventHubsSharedAccessKeyCredential credential,
                                         EventHubConnectionOptions clientOptions = default) : base(fullyQualifiedNamespace, eventHubName, credential, clientOptions)
            {
            }

            internal override TransportClient CreateTransportClient(string fullyQualifiedNamespace, string eventHubName, EventHubTokenCredential credential, EventHubConnectionOptions options)
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

            internal ObservableOperationsMock(string fullyQualifiedNamespace,
                                              string eventHubName,
                                              EventHubsSharedAccessKeyCredential credential,
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
            public EventHubTokenCredential TransportClientCredential;

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

            public InjectableTransportClientMock(TransportClient transportClient,
                                                 string fullyQualifiedNamespace,
                                                 string eventHubName,
                                                 EventHubsSharedAccessKeyCredential credential,
                                                 EventHubConnectionOptions clientOptions = default) : base(fullyQualifiedNamespace, eventHubName, credential, clientOptions)
            {
                TransportClient = transportClient;
                SetTransportClient(transportClient);
            }

            internal override TransportClient CreateTransportClient(string fullyQualifiedNamespace,
                                                                   string eventHubName,
                                                                   EventHubTokenCredential credential,
                                                                   EventHubConnectionOptions options)
            {
                TransportClientCredential = credential;
                return TransportClient;
            }

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
            public (string ConsumerGroup, string Partition, EventPosition Position, EventHubsRetryPolicy RetryPolicy, bool TrackLastEnqueued, long? OwnerLevel, uint? Prefetch) CreateConsumerCalledWith;
            public (string PartitionId, TransportProducerFeatures Features, PartitionPublishingOptions PartitionOptions, EventHubsRetryPolicy RetryPolicy) CreateProducerCalledWith;
            public string GetPartitionPropertiesCalledForId;
            public bool WasGetPropertiesCalled;
            public bool WasCloseCalled;

            public override Task<EventHubProperties> GetPropertiesAsync(EventHubsRetryPolicy retryPolicy,
                                                                        CancellationToken cancellationToken = default)
            {
                WasGetPropertiesCalled = true;
                return Task.FromResult(default(EventHubProperties));
            }

            public override Task<PartitionProperties> GetPartitionPropertiesAsync(string partitionId,
                                                                                  EventHubsRetryPolicy retryPolicy,
                                                                                  CancellationToken cancellationToken = default)
            {
                GetPartitionPropertiesCalledForId = partitionId;
                return Task.FromResult(default(PartitionProperties));
            }

            public override TransportProducer CreateProducer(string partitionId,
                                                             TransportProducerFeatures requestedFeatures,
                                                             PartitionPublishingOptions partitionOptions,
                                                             EventHubsRetryPolicy retryPolicy)
            {
                CreateProducerCalledWith = (partitionId, requestedFeatures, partitionOptions, retryPolicy);
                return default;
            }

            public override TransportConsumer CreateConsumer(string consumerGroup,
                                                             string partitionId,
                                                             EventPosition eventPosition,
                                                             EventHubsRetryPolicy retryPolicy,
                                                             bool trackLastEnqueuedEventProperties = true,
                                                             long? ownerLevel = default,
                                                             uint? prefetchCount = default,
                                                             long? prefechSize = default)
            {
                CreateConsumerCalledWith = (consumerGroup, partitionId, eventPosition, retryPolicy, trackLastEnqueuedEventProperties, ownerLevel, prefetchCount);
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
