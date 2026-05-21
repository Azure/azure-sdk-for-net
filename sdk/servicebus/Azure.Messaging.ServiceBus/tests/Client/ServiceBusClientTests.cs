// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Authorization;
using Azure.Messaging.ServiceBus.Core;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Client
{
    [TestFixture]
    public class ServiceBusClientTests
    {
        /// <summary>
        ///   Provides the invalid test cases for the constructor tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ConstructorTokenCredentialArgumentInvalidCases()
        {
            var credential = new Mock<ServiceBusTokenCredential>(Mock.Of<TokenCredential>());

            yield return new object[] { null, credential.Object };
            yield return new object[] { "", credential.Object };
            yield return new object[] { "FakeNamespace", null };
        }

        /// <summary>
        ///   Provides the invalid test cases for the constructor tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ConstructorSharedKeyCredentialArgumentInvalidCases()
        {
            var credential = new AzureNamedKeyCredential("name", "value");

            yield return new object[] { null, credential };
            yield return new object[] { "", credential };
            yield return new object[] { "FakeNamespace", null };
        }

        /// <summary>
        ///   Provides the invalid test cases for the constructor tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ConstructorSasCredentialArgumentInvalidCases()
        {
            var credential = new AzureSasCredential(new SharedAccessSignature("amqps://fake.namespace.com", "name", "value").Value);

            yield return new object[] { null, credential };
            yield return new object[] { "", credential };
            yield return new object[] { "FakeNamespace", null };
        }

        /// <summary>
        ///   Provides test cases for the constructor tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ConstructorCreatesDefaultOptionsCases()
        {
            var credential = new Mock<ServiceBusTokenCredential>(Mock.Of<TokenCredential>());
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake";

            yield return new object[] { new ReadableOptionsMock(fakeConnection), "simple connection string" };
            yield return new object[] { new ReadableOptionsMock(fakeConnection), "connection string with null options" };
            yield return new object[] { new ReadableOptionsMock("fullyQualifiedNamespace", credential.Object), "expanded argument" };
        }

        /// <summary>
        ///   Provides test cases for the constructor tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ConstructorClonesOptionsCases()
        {
            var credential = new Mock<ServiceBusTokenCredential>(Mock.Of<TokenCredential>());
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake";
            var fakeEndpoint = new Uri("sb://fake.com");

            var options = new ServiceBusClientOptions
            {
                TransportType = ServiceBusTransportType.AmqpWebSockets,
                WebProxy = Mock.Of<IWebProxy>(),
                CustomEndpointAddress = fakeEndpoint,
                Identifier = "MySBClient"
            };

            yield return new object[] { new ReadableOptionsMock(fakeConnection, options), options, "connection string" };
            yield return new object[] { new ReadableOptionsMock("fullyQualifiedNamespace", credential.Object, options), options, "expanded argument" };
        }

        /// <summary>
        ///   Provides test cases for the constructor tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ConstructorSetsIdentifierCases()
        {
            var credential = new Mock<ServiceBusTokenCredential>(Mock.Of<TokenCredential>());
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake";
            var fakeEndpoint = new Uri("sb://fake.com");

            var customIdOptions = new ServiceBusClientOptions
            {
                Identifier = "MyServiceBusClient-abcdefg"
            };

            yield return new object[] { new ReadableOptionsMock(fakeConnection, customIdOptions), customIdOptions, "connection string" };
            yield return new object[] { new ReadableOptionsMock("fullyQualifiedNamespace", credential.Object, customIdOptions), customIdOptions, "expanded argument" };
        }

        /// <summary>
        ///   Provides the test cases for valid connection types.
        /// </summary>
        ///
        public static IEnumerable<object[]> ValidConnectionTypeCases()
        {
            yield return new object[] { ServiceBusTransportType.AmqpTcp };
            yield return new object[] { ServiceBusTransportType.AmqpWebSockets };
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorRequiresConnectionString(string connectionString)
        {
            Assert.That(() => new ServiceBusClient(connectionString), Throws.InstanceOf<ArgumentException>(), "The constructor without options should perform validation.");
            Assert.That(() => new ServiceBusClient(connectionString, new ServiceBusClientOptions()), Throws.InstanceOf<ArgumentException>(), "The constructor with options should perform validation.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorDoesNotRequireOptionsWithConnectionString()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake";
            Assert.That(() => new ServiceBusClient(fakeConnection, default(ServiceBusClientOptions)), Throws.Nothing, "The constructor should not require options");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorDoesNotRequireEntityNameInConnectionString()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real]";
            Assert.That(() => new ServiceBusClient(fakeConnection), Throws.Nothing, "The constructor without options should not require the connection string with entity name");
            Assert.That(() => new ServiceBusClient(fakeConnection, new ServiceBusClientOptions()), Throws.Nothing, "The constructor with options should not require the connection string with entity name");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCase("SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]")]
        [TestCase("Endpoint=value.com;SharedAccessKey=[value];EntityPath=[value]")]
        [TestCase("Endpoint=value.com;SharedAccessKeyName=[value];EntityPath=[value]")]
        [TestCase("HostName=value.azure-devices.net;SharedAccessKeyName=[value];SharedAccessKey=[value]")]
        [TestCase("HostName=value.azure-devices.net;SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]")]
        [TestCase("HostName=value.azure-devices.net;SharedAccessKeyName=[value];SharedAccessSignature=[sas];EntityPath=[value]")]
        [TestCase("HostName=value.azure-devices.net;SharedAccessKey=[value];SharedAccessSignature=[sas];EntityPath=[value]")]
        public void ConstructorValidatesConnectionStringForMissingInformation(string connectionString)
        {
            Assert.That(() => new ServiceBusClient(connectionString), Throws.ArgumentException.And.Message.StartsWith(Resources.MissingConnectionInformation));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]

        [TestCase("Endpoint=value.azure-devices.net;SharedAccessKeyName=[value];SharedAccessKey=[value];SharedAccessSignature=[sas]")]
        public void ConstructorValidatesConnectionStringForDuplicateAuthorization(string connectionString)
        {
            Assert.That(() => new ServiceBusClient(connectionString), Throws.ArgumentException.And.Message.StartsWith(Resources.OnlyOneSharedAccessAuthorizationMayBeSpecified));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorTokenCredentialArgumentInvalidCases))]
        public void ConstructorValidatesTokenCredentialArguments(string fullyQualifiedNamespace,
                                                                 TokenCredential credential)
        {
            Assert.That(() => new ServiceBusClient(fullyQualifiedNamespace, credential), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorSharedKeyCredentialArgumentInvalidCases))]
        public void ConstructorValidatesSharedKeyArguments(string fullyQualifiedNamespace,
                                                           object credential)
        {
            Assert.That(() => new ServiceBusClient(fullyQualifiedNamespace, (AzureNamedKeyCredential)credential), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorSasCredentialArgumentInvalidCases))]
        public void ConstructorValidatesSasArguments(string fullyQualifiedNamespace,
                                                     object credential)
        {
            Assert.That(() => new ServiceBusClient(fullyQualifiedNamespace, (AzureSasCredential)credential), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorCreatesDefaultOptionsCases))]
        public void ConstructorCreatesDefaultOptions(ReadableOptionsMock client,
                                                     string constructorDescription)
        {
            var defaultOptions = new ServiceBusClientOptions();
            ServiceBusClientOptions options = client.Options;

            Assert.That(options, Is.Not.Null, $"The {constructorDescription} constructor should have set default options.");
            Assert.That(options, Is.Not.SameAs(defaultOptions), $"The {constructorDescription} constructor should not have the same options instance.");
            Assert.That(client.Identifier, Is.Not.Null, $"The {constructorDescription} constructor should have set the Identifier.");
            Assert.That(options.TransportType, Is.EqualTo(defaultOptions.TransportType), $"The {constructorDescription} constructor should have the correct connection type.");
            Assert.That(options.WebProxy, Is.EqualTo(defaultOptions.WebProxy), $"The {constructorDescription} constructor should have the correct proxy.");
            Assert.That(options.CustomEndpointAddress, Is.EqualTo(defaultOptions.CustomEndpointAddress), $"The {constructorDescription} constructor should have the correct custom endpoint.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorClonesOptionsCases))]
        public void ConstructorClonesOptions(ReadableOptionsMock client,
                                             ServiceBusClientOptions constructorOptions,
                                             string constructorDescription)
        {
            ServiceBusClientOptions options = client.Options;

            Assert.That(options, Is.Not.Null, $"The {constructorDescription} constructor should have set the options.");
            Assert.That(options, Is.Not.SameAs(constructorOptions), $"The {constructorDescription} constructor should have cloned the options.");
            Assert.That(options.Identifier, Is.EqualTo(constructorOptions.Identifier), $"The {constructorDescription} constructor should have the correct Identifier.");
            Assert.That(options.TransportType, Is.EqualTo(constructorOptions.TransportType), $"The {constructorDescription} constructor should have the correct connection type.");
            Assert.That(options.WebProxy, Is.EqualTo(constructorOptions.WebProxy), $"The {constructorDescription} constructor should have the correct proxy.");
            Assert.That(options.CustomEndpointAddress, Is.EqualTo(constructorOptions.CustomEndpointAddress), $"The {constructorDescription} constructor should have the correct custom endpoint.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorSetsIdentifierCases))]
        public void ConstructorSetsIdentifier(ReadableOptionsMock client,
                                             ServiceBusClientOptions constructorOptions,
                                             string constructorDescription)
        {
            ServiceBusClientOptions options = client.Options;

            Assert.That(options.Identifier, Is.EqualTo(constructorOptions.Identifier), $"The {constructorDescription} constructor should have set the custom identifier");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithConnectionStringValidatesOptions()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake";
            var invalidOptions = new ServiceBusClientOptions { TransportType = ServiceBusTransportType.AmqpTcp, WebProxy = Mock.Of<IWebProxy>() };

            Assert.That(() => new ServiceBusClient(fakeConnection, invalidOptions), Throws.InstanceOf<ArgumentException>(), "The connection string constructor should validate client options");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithTokenCredentialValidatesOptions()
        {
            var token = new Mock<ServiceBusTokenCredential>(Mock.Of<TokenCredential>());
            var invalidOptions = new ServiceBusClientOptions { TransportType = ServiceBusTransportType.AmqpTcp, WebProxy = Mock.Of<IWebProxy>() };

            Assert.That(() => new ServiceBusClient("fullyQualifiedNamespace", Mock.Of<TokenCredential>(), invalidOptions), Throws.InstanceOf<ArgumentException>(), "The expanded argument constructor should validate client options");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithSharedKeyCredentialValidatesOptions()
        {
            var token = new AzureNamedKeyCredential("key", "value");
            var invalidOptions = new ServiceBusClientOptions { TransportType = ServiceBusTransportType.AmqpTcp, WebProxy = Mock.Of<IWebProxy>() };

            Assert.That(() => new ServiceBusClient("fullyQualifiedNamespace", token, invalidOptions), Throws.InstanceOf<ArgumentException>(), "The expanded argument constructor should validate client options");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithSasCredentialValidatesOptions()
        {
            var signature = new SharedAccessSignature("sb://fake.thing.com", "fakeKey", "fakeValue");
            var token = new AzureSasCredential(signature.Value);
            var invalidOptions = new ServiceBusClientOptions { TransportType = ServiceBusTransportType.AmqpTcp, WebProxy = Mock.Of<IWebProxy>() };

            Assert.That(() => new ServiceBusClient("fullyQualifiedNamespace", token, invalidOptions), Throws.InstanceOf<ArgumentException>(), "The expanded argument constructor should validate client options");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithConnectionStringSetsTransportTypeFromOptions()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake";
            var options = new ServiceBusClientOptions { TransportType = ServiceBusTransportType.AmqpWebSockets };
            var client = new ServiceBusClient(fakeConnection, options);

            Assert.That(client.TransportType, Is.EqualTo(options.TransportType));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithTokenCredentialSetsTransportTypeFromOptions()
        {
            var token = new Mock<ServiceBusTokenCredential>(Mock.Of<TokenCredential>());
            var options = new ServiceBusClientOptions { TransportType = ServiceBusTransportType.AmqpWebSockets };
            var client = new ServiceBusClient("fullyQualifiedNamespace", Mock.Of<TokenCredential>(), options);

            Assert.That(client.TransportType, Is.EqualTo(options.TransportType));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithSharedKeyCredentialSetsTransportTypeFromOptions()
        {
            var token = new AzureNamedKeyCredential("key", "value");
            var options = new ServiceBusClientOptions { TransportType = ServiceBusTransportType.AmqpWebSockets };
            var client = new ServiceBusClient("fullyQualifiedNamespace", token, options);

            Assert.That(client.TransportType, Is.EqualTo(options.TransportType));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithSasCredentialSetsTransportTypeFromOptions()
        {
            var signature = new SharedAccessSignature("sb://fake.thing.com", "fakeKey", "fakeValue");
            var token = new AzureSasCredential(signature.Value);
            var options = new ServiceBusClientOptions { TransportType = ServiceBusTransportType.AmqpWebSockets };
            var client = new ServiceBusClient("fullyQualifiedNamespace", token, options);

            Assert.That(client.TransportType, Is.EqualTo(options.TransportType));
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithTokenCredentialParsesNamespaceFromUri()
        {
            var token = Mock.Of<TokenCredential>();
            var host = "mynamespace.servicebus.windows.net";
            var namespaceUri = $"sb://{host}";
            var client = new ServiceBusClient(namespaceUri, token);

            Assert.That(client.FullyQualifiedNamespace, Is.EqualTo(host), "The constructor should parse the namespace from the URI");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithSharedKeyCredentialParsesNamespaceFromUri()
        {
            var token = new AzureNamedKeyCredential("key", "value");
            var host = "mynamespace.servicebus.windows.net";
            var namespaceUri = $"sb://{host}";
            var client = new ServiceBusClient(namespaceUri, token);

            Assert.That(client.FullyQualifiedNamespace, Is.EqualTo(host), "The constructor should parse the namespace from the URI");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithSasCredentialParsesNamespaceFromUri()
        {
            var signature = new SharedAccessSignature("sb://fake.thing.com", "fakeKey", "fakeValue");
            var token = new AzureSasCredential(signature.Value);
            var host = "mynamespace.servicebus.windows.net";
            var namespaceUri = $"sb://{host}";
            var client = new ServiceBusClient(namespaceUri, token);

            Assert.That(client.FullyQualifiedNamespace, Is.EqualTo(host), "The constructor should parse the namespace from the URI");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusClient" />
        /// </summary>
        ///
        [Test]
        public void CreateSenderThrowsIfEntityNamesAreDifferent()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake";
            ServiceBusClient client = new ServiceBusClient(fakeConnection);
            Assert.That(() => client.CreateSender("queueName"), Throws.InstanceOf<ArgumentException>(), "Get sender should detect multiple different entity names");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusClient" />
        /// </summary>
        ///
        [Test]
        public void CreateSenderAllowsIfEntityNamesAreEqual()
        {
            var entityName = "myQueue";
            var fakeConnection = $"Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath={entityName}";
            ServiceBusClient client = new ServiceBusClient(fakeConnection);

            Assert.That(() => client.CreateSender(entityName), Throws.Nothing, "Get sender should allow the same entity name in multiple places");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusClient" />
        /// </summary>
        ///
        [Test]
        public void ValidateClientProperties()
        {
            var entityName = "myQueue";
            var fakeConnection = $"Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath={entityName}";
            ServiceBusClient client = new ServiceBusClient(fakeConnection);
            Assert.AreEqual("not-real.servicebus.windows.net", client.FullyQualifiedNamespace);
            Assert.IsNotNull(client.Identifier);
            Assert.IsFalse(client.IsClosed);
        }

        [Test]
        [TestCase("queue1", "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=queue1")]
        [TestCase("queue1", "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];")]
        [TestCase("topic1", "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];")]
        [TestCase("topic1/Subscriptions/sub1", "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];")]
        [TestCase("topic1/Subscriptions/sub1", "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=topic1")]
        [TestCase("topic1/Subscriptions/sub1", "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=topic1/Subscriptions/sub1")]
        public void ValidateEntityNameAllowsValidPaths(string entityName, string connectionString)
        {
            var client = new ServiceBusClient(connectionString);
            Assert.That(
                () => client.ValidateEntityName(entityName),
                Throws.Nothing);
        }

        [Test]
        [TestCase("queue1", "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=queue2")]
        [TestCase("topic1", "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=topic2")]
        [TestCase("topic1/Subscriptions", "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=topic1")]
        [TestCase("topic1/Subscriptions/", "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=topic1")]
        [TestCase("/Subscriptions/sub1", "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=sub1")]
        [TestCase("topic1/Subscriptions/sub1", "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=topic1/Subscriptions")]
        [TestCase("topic1/Subscriptions/sub1", "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=topic2")]
        [TestCase("topic1/Subscriptions/sub1", "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=topic1/Subscriptions/sub2")]
        [TestCase("topic1/Subscriptions/sub1", "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=topic2/Subscriptions/sub1")]
        public void ValidateEntityNameThrowsForInvalidPaths(string entityName, string connectionString)
        {
            var client = new ServiceBusClient(connectionString);
            Assert.That(
                () => client.ValidateEntityName(entityName),
                Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Allows for the options used by the client to be exposed for testing purposes.
        /// </summary>
        ///
        public class ReadableOptionsMock : ServiceBusClient
        {
            public ServiceBusClientOptions Options =>
               typeof(ServiceBusClient)
                  .GetField("_options", BindingFlags.Instance | BindingFlags.NonPublic)
                  .GetValue(this) as ServiceBusClientOptions;

            public ReadableOptionsMock(string connectionString,
                                       ServiceBusClientOptions clientOptions = default) : base(connectionString, clientOptions)
            {
            }

            public ReadableOptionsMock(string fullyQualifiedNamespace,
                                       TokenCredential credential,
                                       ServiceBusClientOptions clientOptions = default) : base(fullyQualifiedNamespace, credential, clientOptions)
            {
            }

            internal ReadableOptionsMock(string fullyQualifiedNamespace,
                                       AzureNamedKeyCredential credential,
                                       ServiceBusClientOptions clientOptions = default) : base(fullyQualifiedNamespace, credential, clientOptions)
            {
            }
        }

        [Test]
        public async Task GetMessageSessions_StopsWhenPageIsShorterThanPageSize()
        {
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);

            mockTransportReceiver.SetupSequence(receiver => receiver.GetMessageSessionsAsync(
                    It.IsAny<DateTime>(),
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { "s1", "s2" });

            var client = new ServiceBusClient(mockConnection.Object);

            var sessions = new List<string>();
            await foreach (var s in client.GetMessageSessionsAsync("queue"))
            {
                sessions.Add(s);
            }

            Assert.That(sessions, Is.EquivalentTo(new[] { "s1", "s2" }));
            mockTransportReceiver.Verify(receiver => receiver.GetMessageSessionsAsync(
                    It.IsAny<DateTime>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>()),
                Times.Once,
                "Pagination should stop when a page is shorter than the page size.");
        }

        [Test]
        public async Task GetMessageSessions_AggregatesResultsAcrossPages()
        {
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);

            // First page is full (100), second page is full (100), third is short (signals end).
            var fullPage1 = BuildSessionIds("a-", 100);
            var fullPage2 = BuildSessionIds("b-", 100);
            var shortPage = new[] { "tail-1", "tail-2" };

            mockTransportReceiver.SetupSequence(receiver => receiver.GetMessageSessionsAsync(
                    It.IsAny<DateTime>(),
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(fullPage1)
                .ReturnsAsync(fullPage2)
                .ReturnsAsync(shortPage);

            var client = new ServiceBusClient(mockConnection.Object);

            var sessions = new List<string>();
            await foreach (var s in client.GetMessageSessionsAsync("queue"))
            {
                sessions.Add(s);
            }

            Assert.That(sessions.Count, Is.EqualTo(202));
            Assert.That(sessions[0], Is.EqualTo("a-0"));
            Assert.That(sessions[100], Is.EqualTo("b-0"));
            Assert.That(sessions[200], Is.EqualTo("tail-1"));
        }

        [Test]
        public async Task GetMessageSessions_StopsOnEmptyPage()
        {
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);

            mockTransportReceiver.SetupSequence(receiver => receiver.GetMessageSessionsAsync(
                    It.IsAny<DateTime>(),
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(BuildSessionIds("p-", 100))
                .ReturnsAsync(Array.Empty<string>());

            var client = new ServiceBusClient(mockConnection.Object);

            var sessions = new List<string>();
            await foreach (var s in client.GetMessageSessionsAsync("queue"))
            {
                sessions.Add(s);
            }

            Assert.That(sessions.Count, Is.EqualTo(100));
            mockTransportReceiver.Verify(receiver => receiver.GetMessageSessionsAsync(
                    It.IsAny<DateTime>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>()),
                Times.Exactly(2),
                "Pagination should stop on the first empty page after a full page.");
        }

        [Test]
        public async Task GetMessageSessions_PassesUtcDateTimeMaxValueWhenNoUpdatedAfter()
        {
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);

            DateTime capturedTimestamp = default;
            mockTransportReceiver
                .Setup(receiver => receiver.GetMessageSessionsAsync(
                    It.IsAny<DateTime>(),
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .Callback<DateTime, int, int, CancellationToken>(
                    (lastUpdatedTime, _, _, _) => capturedTimestamp = lastUpdatedTime)
                .ReturnsAsync(Array.Empty<string>());

            var client = new ServiceBusClient(mockConnection.Object);

            await foreach (var _ in client.GetMessageSessionsAsync("queue"))
            {
            }

            // The no-filter overload must pass DateTime.MaxValue as the sentinel; the service interprets
            // this as 'all sessions with active messages'. The sentinel must also be UTC-kind so AMQP
            // timestamp encoding does not interpret it as local time. DateTime.Equals/NUnit Is.EqualTo
            // only compare Ticks, so Kind must be asserted explicitly.
            Assert.That(capturedTimestamp, Is.EqualTo(DateTime.SpecifyKind(DateTime.MaxValue, DateTimeKind.Utc)),
                "The no-filter overload must pass DateTime.MaxValue as the sentinel.");
            Assert.That(capturedTimestamp.Kind, Is.EqualTo(DateTimeKind.Utc),
                "The sentinel must be UTC-kind to avoid local-time interpretation during AMQP encoding.");
        }

        [Test]
        public async Task GetMessageSessions_Subscription_PassesFormattedSubscriptionPath()
        {
            const string topicName = "my-topic";
            const string subscriptionName = "my-subscription";
            var expectedEntityPath = EntityNameFormatter.FormatSubscriptionPath(topicName, subscriptionName);

            var mockTransportReceiver = new Mock<TransportReceiver>();

            // Capture the entityPath the client passes into CreateTransportReceiver.
            string capturedEntityPath = null;
            var mockConnection = ServiceBusTestUtilities.CreateMockConnection();

            mockConnection.Setup(
                connection => connection.CreateTransportReceiver(
                    It.IsAny<string>(),
                    It.IsAny<ServiceBusRetryPolicy>(),
                    It.IsAny<ServiceBusReceiveMode>(),
                    It.IsAny<uint>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<CancellationToken>()))
                .Callback<string, ServiceBusRetryPolicy, ServiceBusReceiveMode, uint, string, string, bool, bool, CancellationToken>(
                    (entityPath, _, _, _, _, _, _, _, _) => capturedEntityPath = entityPath)
                .Returns(mockTransportReceiver.Object);

            mockTransportReceiver
                .Setup(receiver => receiver.GetMessageSessionsAsync(
                    It.IsAny<DateTime>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Array.Empty<string>());

            var client = new ServiceBusClient(mockConnection.Object);

            await foreach (var _ in client.GetMessageSessionsAsync(topicName, subscriptionName))
            {
            }

            Assert.That(capturedEntityPath, Is.EqualTo(expectedEntityPath),
                "The subscription overload must format and pass the subscription entity path.");
            mockTransportReceiver.Verify(
                receiver => receiver.GetMessageSessionsAsync(
                    It.IsAny<DateTime>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>()),
                Times.AtLeastOnce,
                "The pagination loop must reach the transport receiver against the formatted subscription path.");
        }

        [Test]
        public async Task GetMessageSessions_ClosesReceiverAfterSuccess()
        {
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);

            mockTransportReceiver
                .Setup(receiver => receiver.GetMessageSessionsAsync(
                    It.IsAny<DateTime>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Array.Empty<string>());

            var client = new ServiceBusClient(mockConnection.Object);

            await foreach (var _ in client.GetMessageSessionsAsync("queue"))
            {
            }

            mockTransportReceiver.Verify(
                receiver => receiver.CloseAsync(It.IsAny<CancellationToken>()),
                Times.Once,
                "The transport receiver must be closed after a successful query.");
        }

        [Test]
        public void GetMessageSessions_ClosesReceiverWhenTransportThrows()
        {
            var mockTransportReceiver = new Mock<TransportReceiver>();
            var mockConnection = GetMockConnection(mockTransportReceiver);

            mockTransportReceiver
                .Setup(receiver => receiver.GetMessageSessionsAsync(
                    It.IsAny<DateTime>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new ServiceBusException(true, "transport boom"));

            var client = new ServiceBusClient(mockConnection.Object);

            Assert.ThrowsAsync<ServiceBusException>(async () =>
            {
                await foreach (var _ in client.GetMessageSessionsAsync("queue"))
                {
                }
            });

            mockTransportReceiver.Verify(
                receiver => receiver.CloseAsync(It.IsAny<CancellationToken>()),
                Times.Once,
                "The transport receiver must be closed even when the transport call throws.");
        }

        private static string[] BuildSessionIds(string prefix, int count)
        {
            var ids = new string[count];
            for (int i = 0; i < count; i++)
            {
                ids[i] = prefix + i;
            }
            return ids;
        }

        private static Mock<ServiceBusConnection> GetMockConnection(Mock<TransportReceiver> mockTransportReceiver)
        {
            var mockConnection = ServiceBusTestUtilities.CreateMockConnection();

            mockConnection.Setup(
                connection => connection.CreateTransportReceiver(
                    It.IsAny<string>(),
                    It.IsAny<ServiceBusRetryPolicy>(),
                    It.IsAny<ServiceBusReceiveMode>(),
                    It.IsAny<uint>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>(),
                    It.IsAny<CancellationToken>()))
                .Returns(mockTransportReceiver.Object);

            return mockConnection;
        }
    }
}
