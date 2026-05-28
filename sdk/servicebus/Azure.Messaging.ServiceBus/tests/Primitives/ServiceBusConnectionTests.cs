// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Authorization;
using Azure.Messaging.ServiceBus.Core;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="ServiceBusConnection" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class ServiceBusConnectionTests
    {
        /// <summary>
        ///   Provides the invalid test cases for the constructor tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ConstructorTokenCredentialInvalidCases()
        {
            var credential = new Mock<ServiceBusTokenCredential>(Mock.Of<TokenCredential>());

            yield return new object[] { null, credential.Object };
            yield return new object[] { "", credential.Object };
            yield return new object[] { "FakeNamespace", null };
            yield return new object[] { "sb://fakenamspace.com", credential.Object };
        }

        /// <summary>
        ///   Provides the invalid test cases for the constructor tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ConstructorSharedKeyCredentialInvalidCases()
        {
            var credential = new AzureNamedKeyCredential("keyName", "keyValue");

            yield return new object[] { null, credential };
            yield return new object[] { "", credential };
            yield return new object[] { "FakeNamespace", null };
            yield return new object[] { "sb://fakenamspace.com", credential };
        }

        /// <summary>
        ///   Provides the invalid test cases for the constructor tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ConstructorSasCredentialInvalidCases()
        {
            var signature = new SharedAccessSignature("amqp://fake.resource.com", "fakeName", "fakeKey");
            var credential = new AzureSasCredential(signature.Value);

            yield return new object[] { null, credential };
            yield return new object[] { "", credential };
            yield return new object[] { "FakeNamespace", null };
            yield return new object[] { "sb://fakenamspace.com", credential };
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
        ///   Provides the test cases for valid credential types.
        /// </summary>
        ///
        public static IEnumerable<object[]> ValidCredentialCases()
        {
            yield return new object[] { Mock.Of<TokenCredential>() };
            yield return new object[] { new AzureNamedKeyCredential("fake", "fake") };
            yield return new object[] { new AzureSasCredential(new SharedAccessSignature("sb://this.is.fake/fakehub", "fake", "fake").Value) };
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorRequiresConnectionString(string connectionString)
        {
            Assert.That(() => new ServiceBusConnection(connectionString, new ServiceBusClientOptions()), Throws.InstanceOf<ArgumentException>(), "The constructor with options and no event hub should perform validation.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCase("SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]")]
        [TestCase("SharedAccessSignature=[value];EntityPath=[value]")]
        [TestCase("SharedAccessSignature=[value]")]
        [TestCase("Endpoint=value.com;SharedAccessKey=[value];EntityPath=[value]")]
        [TestCase("Endpoint=value.com;SharedAccessKeyName=[value];EntityPath=[value]")]
        [TestCase("HostName=value.azure-devices.net;SharedAccessKeyName=[value];SharedAccessKey=[value]")]
        [TestCase("HostName=value.azure-devices.net;SharedAccessKeyName=[value];SharedAccessKey=[value];EntityPath=[value]")]
        public void ConstructorValidatesConnectionStringForMissingInformation(string connectionString)
        {
            Assert.That(() => new ServiceBusConnection(connectionString, new ServiceBusClientOptions()), Throws.ArgumentException);
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]

        [TestCase("Endpoint=value.azure-devices.net;SharedAccessKeyName=[value];SharedAccessSignature=[sas];EntityPath=[value]")]
        [TestCase("Endpoint=value.azure-devices.net;SharedAccessKey=[value];SharedAccessSignature=[sas];EntityPath=[value]")]
        [TestCase("Endpoint=value.azure-devices.net;SharedAccessKeyName=[value];SharedAccessKey=[value];SharedAccessSignature=[sas];EntityPath=[value]")]
        public void ConstructorValidatesConnectionStringForDuplicateAuthorization(string connectionString)
        {
            Assert.That(() => new ServiceBusConnection(connectionString, new ServiceBusClientOptions()), Throws.ArgumentException);
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorTokenCredentialInvalidCases))]
        public void ConstructorValidatesExpandedArgumentsForTokenCredential(string fullyQualifiedNamespace,
                                                                            TokenCredential credential)
        {
            Assert.That(() => new ServiceBusConnection(fullyQualifiedNamespace, credential, new ServiceBusClientOptions()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorSharedKeyCredentialInvalidCases))]
        public void ConstructorValidatesExpandedArgumentsForSharedKeyCredential(string fullyQualifiedNamespace,
                                                                                AzureNamedKeyCredential credential)
        {
            Assert.That(() => new ServiceBusConnection(fullyQualifiedNamespace, credential, new ServiceBusClientOptions()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ConstructorSasCredentialInvalidCases))]
        public void ConstructorValidatesExpandedArgumentsForSasCredential(string fullyQualifiedNamespace,
                                                                          AzureSasCredential credential)
        {
            Assert.That(() => new ServiceBusConnection(fullyQualifiedNamespace, credential, new ServiceBusClientOptions()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithConnectionStringValidatesOptions()
        {
            var fakeConnection = "Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake";
            var invalidOptions = new ServiceBusClientOptions { TransportType = ServiceBusTransportType.AmqpTcp, WebProxy = Mock.Of<IWebProxy>() };

            Assert.That(() => new ServiceBusConnection(fakeConnection, invalidOptions), Throws.ArgumentException, "The connection string constructor should validate client options");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithExpandedArgumentsValidatesOptions()
        {
            var token = new Mock<ServiceBusTokenCredential>(Mock.Of<TokenCredential>());
            var invalidOptions = new ServiceBusClientOptions { TransportType = ServiceBusTransportType.AmqpTcp, WebProxy = Mock.Of<IWebProxy>() };
            Assert.That(() => new ServiceBusConnection("fullyQualifiedNamespace", Mock.Of<TokenCredential>(), invalidOptions), Throws.ArgumentException, "The expanded argument constructor should validate client options");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithConnectionStringCreatesTheTransportClient()
        {
            var connection = new ServiceBusConnection("Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real]", new ServiceBusClientOptions());
            Assert.That(connection.InnerClient, Is.Not.Null);
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithConnectionStringUsingSharedAccessSignatureCreatesTheCorrectTransportCredential()
        {
            var sasToken = new SharedAccessSignature("hub", "root", "abc1234").Value;
            var connection = new ObservableTransportClientMock($"Endpoint=sb://not-real.servicebus.windows.net/;EntityPath=fake;SharedAccessSignature={ sasToken }", new ServiceBusClientOptions());

            Assert.That(connection.TransportClientCredential, Is.Not.Null, "The transport client should have been given a credential.");
            Assert.That(connection.TransportClientCredential.GetToken(default, default).Token, Is.EqualTo(sasToken), "The transport client credential should use the provided SAS token.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithConnectionStringAndDevelopmentEmulatorDoesNotUseTls()
        {
            var endpoint = new Uri("sb://localhost:1234", UriKind.Absolute);
            var fakeConnection = $"Endpoint={ endpoint };SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=ehName;UseDevelopmentEmulator=true";
            var connection = new ReadableTransportOptionsMock(fakeConnection);

            Assert.That(connection.UseTls.HasValue, Is.True, "The connection should have initialized the TLS flag.");
            Assert.That(connection.UseTls.Value, Is.False, "The options should not use TLS for the development emulator.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithConnectionStringAnNoDevelopmentEmulatorUsesTls()
        {
            var endpoint = new Uri("sb://localhost:1234", UriKind.Absolute);
            var fakeConnection = $"Endpoint={ endpoint };SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=ehName";
            var connection = new ReadableTransportOptionsMock(fakeConnection);

            Assert.That(connection.UseTls.HasValue, Is.True, "The connection should have initialized the TLS flag.");
            Assert.That(connection.UseTls.Value, Is.True, "The options should use TLS for communcating with the service.");
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithTokenCredentialCreatesTheTransportClient()
        {
            var fullyQualifiedNamespace = "my.ServiceBus.com";
            var keyName = "aWonderfulKey";
            var key = "ABC4223";
            var resource = $"amqps://{ fullyQualifiedNamespace }";
            var options = new ServiceBusClientOptions { TransportType = ServiceBusTransportType.AmqpTcp };
            var signature = new SharedAccessSignature(resource, keyName, key);
            var connection = new ServiceBusConnection(fullyQualifiedNamespace, new SharedAccessCredential(signature), options);

            Assert.That(connection.InnerClient, Is.Not.Null);
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithSharedKeyCredentialCreatesTheTransportClient()
        {
            var fullyQualifiedNamespace = "my.ServiceBus.com";
            var keyName = "aWonderfulKey";
            var key = "ABC4223";
            var options = new ServiceBusClientOptions { TransportType = ServiceBusTransportType.AmqpTcp };
            var credential = new AzureNamedKeyCredential(keyName, key);
            var connection = new ServiceBusConnection(fullyQualifiedNamespace, credential, options);

            Assert.That(connection.InnerClient, Is.Not.Null);
        }

        /// <summary>
        ///    Verifies functionality of the <see cref="ServiceBusConnection" />
        ///    constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorWithSasCredentialCreatesTheTransportClient()
        {
            var fullyQualifiedNamespace = "my.ServiceBus.com";
            var keyName = "aWonderfulKey";
            var key = "ABC4223";
            var options = new ServiceBusClientOptions { TransportType = ServiceBusTransportType.AmqpTcp };
            var signature = new SharedAccessSignature($"amqps://{ fullyQualifiedNamespace }", keyName, key);
            var credential = new AzureSasCredential(signature.Value);
            var connection = new ServiceBusConnection(fullyQualifiedNamespace, credential, options);

            Assert.That(connection.InnerClient, Is.Not.Null);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ServiceBusConnection.CreateTransportClient" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ValidConnectionTypeCases))]
        public void BuildTransportClientAllowsLegalConnectionTypes(ServiceBusTransportType connectionType)
        {
            var fullyQualifiedNamespace = "my.ServiceBus.com";
            var keyName = "aWonderfulKey";
            var key = "ABC4223";
            var resource = $"amqps://{ fullyQualifiedNamespace }";
            var options = new ServiceBusClientOptions { TransportType = connectionType };
            var signature = new SharedAccessSignature(resource, keyName, key);
            var credential = new SharedAccessCredential(signature);
            var ServiceBusCredential = new ServiceBusTokenCredential(credential);
            var connection = new ServiceBusConnection(fullyQualifiedNamespace, credential, new ServiceBusClientOptions());

            Assert.That(() => connection.CreateTransportClient(ServiceBusCredential, options), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ServiceBusConnection.CreateTransportClient" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void BuildTransportClientRejectsInvalidConnectionTypes()
        {
            var fullyQualifiedNamespace = "my.servicebus.com";
            var keyName = "aWonderfulKey";
            var key = "ABC4223";
            var resource = $"amqps://{ fullyQualifiedNamespace }";
            var connectionType = (ServiceBusTransportType)int.MinValue;
            var options = new ServiceBusClientOptions { TransportType = connectionType };
            var signature = new SharedAccessSignature(resource, keyName, key);
            var credential = new SharedAccessCredential(signature);
            var ServiceBusCredential = new ServiceBusTokenCredential(credential);
            var connection = new ServiceBusConnection(fullyQualifiedNamespace, credential, new ServiceBusClientOptions());

            Assert.That(() => connection.CreateTransportClient(ServiceBusCredential, options), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ServiceBusConnection.DisposeAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task DisposeAsyncDelegatesToCloseAsync()
        {
            ObservableOperationsMock capturedClient;

            await using (var client = new ObservableOperationsMock("Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake", new ServiceBusClientOptions()))
            {
                capturedClient = client;
            }

            Assert.That(capturedClient.WasCloseAsyncCalled, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ServiceBusConnection.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncClosesTheTransportClient()
        {
            var connection = new ObservableTransportClientMock("Endpoint=sb://not-real.servicebus.windows.net/;SharedAccessKeyName=DummyKey;SharedAccessKey=[not_real];EntityPath=fake", new ServiceBusClientOptions());

            await connection.CloseAsync();
            Assert.That(connection.TransportClient.WasCloseCalled, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ServiceBusConnection.BuildResource" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void BuildConnectionResource()
        {
            var fullyQualifiedNamespace = "my.ServiceBus.com";
            var path = "someHub/";
            var resource = ServiceBusConnection.BuildConnectionResource(ServiceBusTransportType.AmqpWebSockets, fullyQualifiedNamespace, path);

            Assert.That(resource, Is.Not.Null.Or.Empty, "The resource should have been populated.");
            Assert.That(resource, Is.EqualTo(resource.ToLowerInvariant()), "The resource should have been normalized to lower case.");

            var uri = new Uri(resource, UriKind.Absolute);

            Assert.That(uri.AbsolutePath.StartsWith("/"), Is.True, "The resource path have been normalized to begin with a trailing slash.");
            Assert.That(uri.AbsolutePath.EndsWith("/"), Is.False, "The resource path have been normalized to not end with a trailing slash.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ServiceBusConnection.BuildConnectionSignatureAuthorizationResource" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void BuildConnectionResourceConstructsFromNamespaceAndPath()
        {
            var fullyQualifiedNamespace = "my.servicebus.com";
            var path = "someHub";
            var expectedPath = $"/{ path.ToLowerInvariant() }";
            var resource = ServiceBusConnection.BuildConnectionResource(ServiceBusTransportType.AmqpTcp, fullyQualifiedNamespace, path);

            Assert.That(resource, Is.Not.Null.Or.Empty, "The resource should have been populated.");

            var uri = new Uri(resource, UriKind.Absolute);

            Assert.That(uri.Host, Is.EqualTo(fullyQualifiedNamespace), "The resource should match the host.");
            Assert.That(uri.AbsolutePath, Is.EqualTo(expectedPath), "The resource path should match the Event Hub path.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ServiceBusConnection.CreateFromCredential" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ValidCredentialCases))]
        public void CreateWithCredentialAllowsKnownCredentialTypes(object credential)
        {
            var options = new ServiceBusClientOptions();
            var connection = ServiceBusConnection.CreateWithCredential("fqns", credential, options);

            Assert.That(connection, Is.Not.Null, "A connection should have been created.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ServiceBusConnection.CreateFromCredential" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateWithCredentialDisallowsUnknownCredentialTypes()
        {
            var credential = new object();
            var options = new ServiceBusClientOptions();

            Assert.That(() => ServiceBusConnection.CreateWithCredential("fqns", credential, options), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Allows for the options used by the client to be exposed for testing purposes.
        /// </summary>
        ///
        internal class ReadableTransportOptionsMock : ServiceBusConnection
        {
            public ServiceBusClientOptions TransportClientOptions;

            public bool? UseTls;

            private ObservableTransportClient _transportClient;

            public ReadableTransportOptionsMock(string connectionString,
                                       ServiceBusClientOptions clientOptions = default) : base(connectionString, clientOptions ?? new())
            {
            }

            public ReadableTransportOptionsMock(string fullyQualifiedNamespace,
                                       TokenCredential credential,
                                       ServiceBusClientOptions clientOptions = default) : base(fullyQualifiedNamespace, credential, clientOptions ?? new())
            {
            }

            public ReadableTransportOptionsMock(string fullyQualifiedNamespace,
                                       AzureNamedKeyCredential credential,
                                       ServiceBusClientOptions clientOptions = default) : base(fullyQualifiedNamespace, credential, clientOptions ?? new())
            {
            }

            public ReadableTransportOptionsMock(string fullyQualifiedNamespace,
                                       AzureSasCredential credential,
                                       ServiceBusClientOptions clientOptions = default) : base(fullyQualifiedNamespace, credential, clientOptions ?? new())
            {
            }

            internal override TransportClient CreateTransportClient(ServiceBusTokenCredential credential, ServiceBusClientOptions options, bool useTls = true)
            {
                UseTls = useTls;
                TransportClientOptions = options;
                _transportClient = new ObservableTransportClient();
                return _transportClient;
            }
        }

        /// <summary>
        ///   Allows for the operations performed by the client to be observed for testing purposes.
        /// </summary>
        ///
        private class ObservableOperationsMock : ServiceBusConnection
        {
            public bool WasCloseAsyncCalled = false;

            public ObservableOperationsMock(string connectionString,
                                            ServiceBusClientOptions clientOptions) : base(connectionString, clientOptions)
            {
            }

            public ObservableOperationsMock(string fullyQualifiedNamespace,
                                            TokenCredential credential,
                                            ServiceBusClientOptions clientOptions) : base(fullyQualifiedNamespace, credential, clientOptions)
            {
            }

            public ObservableOperationsMock(string fullyQualifiedNamespace,
                                            AzureNamedKeyCredential credential,
                                            ServiceBusClientOptions clientOptions) : base(fullyQualifiedNamespace, credential, clientOptions)
            {
            }

            public ObservableOperationsMock(string fullyQualifiedNamespace,
                                            AzureSasCredential credential,
                                            ServiceBusClientOptions clientOptions) : base(fullyQualifiedNamespace, credential, clientOptions)
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
        private class ObservableTransportClientMock : ServiceBusConnection
        {
            public ObservableTransportClient TransportClient;
            public ServiceBusTokenCredential TransportClientCredential;

            public ObservableTransportClientMock(string connectionString,
                                                 ServiceBusClientOptions clientOptions = default) : base(connectionString, clientOptions)
            {
            }

            public ObservableTransportClientMock(string fullyQualifiedNamespace,
                                                 TokenCredential credential,
                                                 ServiceBusClientOptions clientOptions = default) : base(fullyQualifiedNamespace, credential, clientOptions)
            {
            }

            public ObservableTransportClientMock(string fullyQualifiedNamespace,
                                                 AzureNamedKeyCredential credential,
                                                 ServiceBusClientOptions clientOptions = default) : base(fullyQualifiedNamespace, credential, clientOptions)
            {
            }

            public ObservableTransportClientMock(string fullyQualifiedNamespace,
                                                 AzureSasCredential credential,
                                                 ServiceBusClientOptions clientOptions = default) : base(fullyQualifiedNamespace, credential, clientOptions)
            {
            }

            internal override TransportClient CreateTransportClient(ServiceBusTokenCredential credential,
                                                                    ServiceBusClientOptions options,
                                                                    bool useTls)
            {
                TransportClientCredential = credential;
                TransportClient ??= new();

                return TransportClient;
            }
        }

        /// <summary>
        ///   Allows for observation of operations performed by the client for testing purposes.
        /// </summary>
        ///
        private class ObservableTransportClient : TransportClient
        {
            public bool WasCloseCalled;

            public override Task CloseAsync(CancellationToken cancellationToken)
            {
                WasCloseCalled = true;
                return Task.CompletedTask;
            }

            public override TransportReceiver CreateReceiver(string entityPath, ServiceBusRetryPolicy retryPolicy,
                ServiceBusReceiveMode receiveMode, uint prefetchCount, string identifier, string sessionId, bool isSessionReceiver,
                bool isProcessor,
                CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public override TransportSender CreateSender(string entityPath, ServiceBusRetryPolicy retryPolicy, string identifier)
            {
                throw new NotImplementedException();
            }

            public override TransportRuleManager CreateRuleManager(string subscriptionPath, ServiceBusRetryPolicy retryPolicy, string identifier)
            {
                throw new NotImplementedException();
            }
        }
    }
}
