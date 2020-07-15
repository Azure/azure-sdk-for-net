// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using Azure.Core;
using Azure.Messaging.ServiceBus.Authorization;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Client
{
    public class ServiceBusClientTests
    {
        /// <summary>
        ///   Provides the invalid test cases for the constructor tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ConstructorExpandedArgumentInvalidCases()
        {
            var credential = new Mock<ServiceBusTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net");

            yield return new object[] { null, credential.Object };
            yield return new object[] { "", credential.Object };
            yield return new object[] { "FakeNamespace", null };
            yield return new object[] { "sb://fakenamspace.com", credential.Object };
        }

        /// <summary>
        ///   Provides test cases for the constructor tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ConstructorCreatesDefaultOptionsCases()
        {
            var credential = new Mock<ServiceBusTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net");
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
            var credential = new Mock<ServiceBusTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net");
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake";

            var options = new ServiceBusClientOptions
            {
                TransportType = ServiceBusTransportType.AmqpWebSockets,
                Proxy = Mock.Of<IWebProxy>()
            };

            yield return new object[] { new ReadableOptionsMock(fakeConnection, options), options, "connection string" };
            yield return new object[] { new ReadableOptionsMock("fullyQualifiedNamespace", credential.Object, options), options, "expanded argument" };
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
        public void ConstructorValidatesConnectionString(string connectionString)
        {
            Assert.That(() => new ServiceBusClient(connectionString), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorExpandedArgumentInvalidCases))]
        public void ConstructorValidatesExpandedArguments(string fullyQualifiedNamespace,
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
        [TestCaseSource(nameof(ConstructorCreatesDefaultOptionsCases))]
        public void ConstructorCreatesDefaultOptions(ReadableOptionsMock client,
                                                     string constructorDescription)
        {
            var defaultOptions = new ServiceBusClientOptions();
            ServiceBusClientOptions options = client.Options;

            Assert.That(options, Is.Not.Null, $"The { constructorDescription } constructor should have set default options.");
            Assert.That(options, Is.Not.SameAs(defaultOptions), $"The { constructorDescription } constructor should not have the same options instance.");
            Assert.That(options.TransportType, Is.EqualTo(defaultOptions.TransportType), $"The { constructorDescription } constructor should have the correct connection type.");
            Assert.That(options.Proxy, Is.EqualTo(defaultOptions.Proxy), $"The { constructorDescription } constructor should have the correct proxy.");
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

            Assert.That(options, Is.Not.Null, $"The { constructorDescription } constructor should have set the options.");
            Assert.That(options, Is.Not.SameAs(constructorOptions), $"The { constructorDescription } constructor should have cloned the options.");
            Assert.That(options.TransportType, Is.EqualTo(constructorOptions.TransportType), $"The { constructorDescription } constructor should have the correct connection type.");
            Assert.That(options.Proxy, Is.EqualTo(constructorOptions.Proxy), $"The { constructorDescription } constructor should have the correct proxy.");
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
            var invalidOptions = new ServiceBusClientOptions { TransportType = ServiceBusTransportType.AmqpTcp, Proxy = Mock.Of<IWebProxy>() };

            Assert.That(() => new ServiceBusClient(fakeConnection, invalidOptions), Throws.InstanceOf<ArgumentException>(), "The connection string constructor should validate client options");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusClient" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithExpandedArgumentsValidatesOptions()
        {
            var token = new Mock<ServiceBusTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net");
            var invalidOptions = new ServiceBusClientOptions { TransportType = ServiceBusTransportType.AmqpTcp, Proxy = Mock.Of<IWebProxy>() };
            Assert.That(() => new ServiceBusClient("fullyQualifiedNamespace", Mock.Of<TokenCredential>(), invalidOptions), Throws.InstanceOf<ArgumentException>(), "The expanded argument constructor should validate client options");
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
            var fakeConnection = $"Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath={ entityName }";
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
            var fakeConnection = $"Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath={ entityName }";
            ServiceBusClient client = new ServiceBusClient(fakeConnection);
            Assert.AreEqual("not-real.servicebus.windows.net", client.FullyQualifiedNamespace);
            Assert.IsNotNull(client.Identifier);
            Assert.IsFalse(client.IsDisposed);
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
        }
    }
}
