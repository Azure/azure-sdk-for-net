// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Messaging.EventHubs.Amqp;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;
using Azure.Messaging.EventHubs.Producer;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventHubBufferedProducerClient" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventHubBufferedProducerClientTests
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
            Assert.That(() => new EventHubBufferedProducerClient(connectionString, "dummy"), Throws.InstanceOf<ArgumentException>(), "The constructor without options should ensure a connection string.");
            Assert.That(() => new EventHubBufferedProducerClient(connectionString, "dummy", new EventHubBufferedProducerClientOptions()), Throws.InstanceOf<ArgumentException>(), "The constructor with options should ensure a connection string.");
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
            Assert.That(() => new EventHubBufferedProducerClient(connectionString), Throws.ArgumentException.And.Message.StartsWith(Resources.MissingConnectionInformation));
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

            Assert.That(() => new EventHubBufferedProducerClient(connectionString, eventHubName), Throws.ArgumentException.And.Message.StartsWith(Resources.OnlyOneEventHubNameMayBeSpecified));
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

            Assert.That(() => new EventHubBufferedProducerClient(connectionString, eventHubName), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("[156]")]
        public void ConstructorValidatesTheNamespace(string constructorArgument)
        {
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            Assert.That(() => new EventHubBufferedProducerClient(constructorArgument, "dummy", credential.Object), Throws.InstanceOf<ArgumentException>(), "The token credential constructor should validate.");
            Assert.That(() => new EventHubBufferedProducerClient(constructorArgument, "dummy", new AzureNamedKeyCredential("key", "value")), Throws.InstanceOf<ArgumentException>(), "The shared key credential constructor should validate.");
            Assert.That(() => new EventHubBufferedProducerClient(constructorArgument, "dummy", new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value)), Throws.InstanceOf<ArgumentException>(), "The SAS credential constructor should validate.");
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
            Assert.That(() => new EventHubBufferedProducerClient("namespace", constructorArgument, credential.Object), Throws.InstanceOf<ArgumentException>(), "The token credential constructor should validate.");
            Assert.That(() => new EventHubBufferedProducerClient("namespace", constructorArgument, new AzureNamedKeyCredential("key", "value")), Throws.InstanceOf<ArgumentException>(), "The shared key credential constructor should validate.");
            Assert.That(() => new EventHubBufferedProducerClient("namespace", constructorArgument, new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value)), Throws.InstanceOf<ArgumentException>(), "The SAS credential constructor should validate.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheCredential()
        {
            Assert.That(() => new EventHubBufferedProducerClient("namespace", "hubName", default(TokenCredential)), Throws.ArgumentNullException, "The token credential constructor should validate.");
            Assert.That(() => new EventHubBufferedProducerClient("namespace", "hubName", default(AzureNamedKeyCredential)), Throws.ArgumentNullException, "The shared key credential constructor should validate.");
            Assert.That(() => new EventHubBufferedProducerClient("namespace", "hubName", default(AzureSasCredential)), Throws.InstanceOf<ArgumentException>(), "The SAS credential constructor should validate.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheConnection()
        {
            Assert.That(() => new EventHubBufferedProducerClient(default(EventHubConnection)), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorSetsDelegatedProperties()
        {
            var expectedIdentifier = "Test-Identifier";
            var expectedNamespace = "testns.namespace.com";
            var expectedEventHub = "testHub";
            var connectionString = $"Endpoint=sb://{ expectedNamespace };SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath={ expectedEventHub }";
            var options = new EventHubBufferedProducerClientOptions { Identifier = expectedIdentifier };
            var producer = new EventHubBufferedProducerClient(connectionString, options);

            Assert.That(producer.Identifier, Is.EqualTo(expectedIdentifier), "The identifier should have been initialized.");
            Assert.That(producer.FullyQualifiedNamespace, Is.EqualTo(expectedNamespace), "The fully qualified namespace should have been initialized.");
            Assert.That(producer.EventHubName, Is.EqualTo(expectedEventHub), "The event hub name should have been initialized.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringAndEventHubConstructorSetsDelegatedProperties()
        {
            var expectedIdentifier = "Test-Identifier";
            var expectedNamespace = "testns.namespace.com";
            var expectedEventHub = "testHub";
            var connectionString = $"Endpoint=sb://{ expectedNamespace };SharedAccessKeyName=ABC;SharedAccessKey=123";
            var options = new EventHubBufferedProducerClientOptions { Identifier = expectedIdentifier };
            var producer = new EventHubBufferedProducerClient(connectionString, expectedEventHub, options);

            Assert.That(producer.Identifier, Is.EqualTo(expectedIdentifier), "The identifier should have been initialized.");
            Assert.That(producer.FullyQualifiedNamespace, Is.EqualTo(expectedNamespace), "The fully qualified namespace should have been initialized.");
            Assert.That(producer.EventHubName, Is.EqualTo(expectedEventHub), "The event hub name should have been initialized.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void TokenCredentialConstructorSetsDelegatedProperties()
        {
            var expectedIdentifier = "Test-Identifier";
            var expectedNamespace = "testns.namespace.com";
            var expectedEventHub = "testHub";
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>());
            var options = new EventHubBufferedProducerClientOptions { Identifier = expectedIdentifier };
            var producer = new EventHubBufferedProducerClient(expectedNamespace, expectedEventHub, credential.Object, options);

            Assert.That(producer.Identifier, Is.EqualTo(expectedIdentifier), "The identifier should have been initialized.");
            Assert.That(producer.FullyQualifiedNamespace, Is.EqualTo(expectedNamespace), "The fully qualified namespace should have been initialized.");
            Assert.That(producer.EventHubName, Is.EqualTo(expectedEventHub), "The event hub name should have been initialized.");
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
            var producer = new EventHubBufferedProducerClient(namespaceUri, "dummy", credential);

            Assert.That(producer.FullyQualifiedNamespace, Is.EqualTo(host), "The constructor should parse the namespace from the URI");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void SharedKeyCredentialConstructorSetsDelegatedProperties()
        {
            var expectedIdentifier = "Test-Identifier";
            var expectedNamespace = "testns.namespace.com";
            var expectedEventHub = "testHub";
            var credential = new AzureNamedKeyCredential("key", "value");
            var options = new EventHubBufferedProducerClientOptions { Identifier = expectedIdentifier };
            var producer = new EventHubBufferedProducerClient(expectedNamespace, expectedEventHub, credential, options);

            Assert.That(producer.Identifier, Is.EqualTo(expectedIdentifier), "The identifier should have been initialized.");
            Assert.That(producer.FullyQualifiedNamespace, Is.EqualTo(expectedNamespace), "The fully qualified namespace should have been initialized.");
            Assert.That(producer.EventHubName, Is.EqualTo(expectedEventHub), "The event hub name should have been initialized.");
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
            var producer = new EventHubBufferedProducerClient(namespaceUri, "dummy", credential);

            Assert.That(producer.FullyQualifiedNamespace, Is.EqualTo(host), "The constructor should parse the namespace from the URI");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void SasCredentialConstructorSetsDelegatedProperties()
        {
            var expectedIdentifier = "Test-Identifier";
            var expectedNamespace = "testns.namespace.com";
            var expectedEventHub = "testHub";
            var credential = new AzureSasCredential(new SharedAccessSignature("sb://this.is.Fake/blah", "key", "value").Value);
            var options = new EventHubBufferedProducerClientOptions { Identifier = expectedIdentifier };
            var producer = new EventHubBufferedProducerClient(expectedNamespace, expectedEventHub, credential, options);

            Assert.That(producer.Identifier, Is.EqualTo(expectedIdentifier), "The identifier should have been initialized.");
            Assert.That(producer.FullyQualifiedNamespace, Is.EqualTo(expectedNamespace), "The fully qualified namespace should have been initialized.");
            Assert.That(producer.EventHubName, Is.EqualTo(expectedEventHub), "The event hub name should have been initialized.");
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
            var producer = new EventHubBufferedProducerClient(namespaceUri, "dummy", credential);

            Assert.That(producer.FullyQualifiedNamespace, Is.EqualTo(host), "The constructor should parse the namespace from the URI");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionConstructorSetsDelegatedProperties()
        {
            var expectedIdentifier = "Test-Identifier";
            var expectedNamespace = "testns.namespace.com";
            var expectedEventHub = "testHub";
            var options = new EventHubBufferedProducerClientOptions { Identifier = expectedIdentifier };
            var connection = new EventHubConnection(expectedNamespace, expectedEventHub, Mock.Of<TokenCredential>());
            var producer = new EventHubBufferedProducerClient(connection, options);

            Assert.That(producer.Identifier, Is.EqualTo(expectedIdentifier), "The identifier should have been initialized.");
            Assert.That(producer.FullyQualifiedNamespace, Is.EqualTo(expectedNamespace), "The fully qualified namespace should have been initialized.");
            Assert.That(producer.EventHubName, Is.EqualTo(expectedEventHub), "The event hub name should have been initialized.");
        }

        /// <summary>
        ///   Verifies functionality of GetEventHubPropertiesAsync.
        /// </summary>
        ///
        [Test]
        public void GetEventHubPropertiesAsyncValidatesClosed()
        {
            using var cancellationSource = new CancellationTokenSource();

            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            bufferedProducer.IsClosed = true;
            Assert.That(async () => await bufferedProducer.GetEventHubPropertiesAsync(cancellationSource.Token), Throws.InstanceOf<EventHubsException>());
        }

        /// <summary>
        ///   Verifies functionality of GetEventHubPropertiesAsync.
        /// </summary>
        ///
        [Test]
        public async Task GetEventHubPropertiesAsyncIsDelegated()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            await bufferedProducer.GetEventHubPropertiesAsync(cancellationSource.Token);
            mockProducer.Verify(producer => producer.GetEventHubPropertiesAsync(cancellationSource.Token), Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of GetPartitionIdsAsync.
        /// </summary>
        ///
        [Test]
        public void GetPartitionIdsAsyncValidatesClosed()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            bufferedProducer.IsClosed = true;
            Assert.That(async () => await bufferedProducer.GetPartitionIdsAsync(cancellationSource.Token), Throws.InstanceOf<EventHubsException>());
        }

        /// <summary>
        ///   Verifies functionality of GetPartitionIdsAsync.
        /// </summary>
        ///
        [Test]
        public async Task GetPartitionIdsAsyncIsDelegated()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { "0 "});

            await bufferedProducer.GetPartitionIdsAsync(cancellationSource.Token);
            mockProducer.Verify(producer => producer.GetPartitionIdsAsync(cancellationSource.Token), Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of GetPartitionIdsAsync.
        /// </summary>
        ///
        [Test]
        public void GetPartitionPropertiesAsyncValidatesClosed()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            bufferedProducer.IsClosed = true;
            Assert.That(async () => await bufferedProducer.GetPartitionPropertiesAsync("0", cancellationSource.Token), Throws.InstanceOf<EventHubsException>());
        }

        /// <summary>
        ///   Verifies functionality of GetPartitionPropertiesAsync.
        /// </summary>
        ///
        [Test]
        public async Task GetPartitionPropertiesAsyncIsDelegated()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedPartition = "0";
            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            mockProducer
                .Setup(producer => producer.GetPartitionPropertiesAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new PartitionProperties("test", "1", true, 12345, 6789, 22, new DateTimeOffset(2015, 10, 27, 0, 0, 0, TimeSpan.Zero)));

            await bufferedProducer.GetPartitionPropertiesAsync(expectedPartition, cancellationSource.Token);
            mockProducer.Verify(producer => producer.GetPartitionPropertiesAsync(expectedPartition, cancellationSource.Token), Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient" /> events.
        /// </summary>
        ///
        [Test]
        public void NullEventHandlersAreNotAllowed()
        {
            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            Assert.That(() => bufferedProducer.SendEventBatchSucceededAsync += null, Throws.InstanceOf<ArgumentNullException>(), "The success handler should not allow null.");
            Assert.That(() => bufferedProducer.SendEventBatchFailedAsync += null, Throws.InstanceOf<ArgumentNullException>(), "The failure handler should not allow null.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient" /> events.
        /// </summary>
        ///
        [Test]
        public void OnlyOneEventHandlerIsAllowed()
        {
            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            bufferedProducer.SendEventBatchSucceededAsync += args => Task.CompletedTask;
            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;

            Assert.That(() => bufferedProducer.SendEventBatchSucceededAsync += args => Task.CompletedTask, Throws.InstanceOf<NotSupportedException>(), "The success handler should only allow one handler registration.");
            Assert.That(() => bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask, Throws.InstanceOf<NotSupportedException>(), "The failure handler should only allow one handler registration.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient" /> events.
        /// </summary>
        ///
        [Test]
        public void CannotUnRegisterHandlersWhenPublishingIsActive()
        {
            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            Func<SendEventBatchSucceededEventArgs, Task> successHandler = args => Task.CompletedTask;
            Func<SendEventBatchFailedEventArgs, Task> failHandler = args => Task.CompletedTask;

            mockBufferedProducer.Object.SendEventBatchSucceededAsync += successHandler;
            mockBufferedProducer.Object.SendEventBatchFailedAsync += failHandler;

            SetHandlerLocked(mockBufferedProducer.Object, true);
            Assert.That(() => mockBufferedProducer.Object.SendEventBatchSucceededAsync -= successHandler, Throws.InstanceOf<InvalidOperationException>(), "The success handler should not allow unregistering when publishing is active.");
            Assert.That(() => mockBufferedProducer.Object.SendEventBatchFailedAsync -= failHandler, Throws.InstanceOf<InvalidOperationException>(), "The failure handler should not allow unregistering when publishing is active.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient" /> events.
        /// </summary>
        ///
        [Test]
        public void CannotUnregisterEventHandlersWhenNotSet()
        {
            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            Assert.That(() => bufferedProducer.SendEventBatchSucceededAsync -= args => Task.CompletedTask, Throws.InstanceOf<ArgumentException>(), "The success handler should not allow removing an unset handler.");
            Assert.That(() => bufferedProducer.SendEventBatchFailedAsync -= args => Task.CompletedTask, Throws.InstanceOf<ArgumentException>(), "The failure handler should not allow removing an unset handler.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient" /> events.
        /// </summary>
        ///
        [Test]
        public void CannotUnregisterEventHandlerDelegateThatIsNotRegistered()
        {
            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            bufferedProducer.SendEventBatchSucceededAsync += args => Task.CompletedTask;
            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;

            Assert.That(() => bufferedProducer.SendEventBatchSucceededAsync -= args => Task.CompletedTask, Throws.InstanceOf<ArgumentException>(), "The success handler should not allow removing an unregistered delegate.");
            Assert.That(() => bufferedProducer.SendEventBatchFailedAsync -= args => Task.CompletedTask, Throws.InstanceOf<ArgumentException>(), "The failure handler should not allow removing an unregistered delegate.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient" /> events.
        /// </summary>
        ///
        [Test]
        public void RegisteredEventHandlersCanBeUnregistered()
        {
            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            Func<SendEventBatchSucceededEventArgs, Task> successHandler = args => Task.CompletedTask;
            Func<SendEventBatchFailedEventArgs, Task> failHandler = args => Task.CompletedTask;

            bufferedProducer.SendEventBatchSucceededAsync += successHandler;
            bufferedProducer.SendEventBatchFailedAsync += failHandler;

            Assert.That(() => bufferedProducer.SendEventBatchSucceededAsync -= successHandler, Throws.Nothing, "The success handler should allow removing the registered delegate.");
            Assert.That(() => bufferedProducer.SendEventBatchFailedAsync -= failHandler, Throws.Nothing, "The failure handler should allow removing the registered delegate.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.DisposeAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task DisposeDelegatesToCloseWithFlush()
        {
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>("fqNamespace", "eventHub", Mock.Of<TokenCredential>(), null)
            {
                CallBase = true
            };

            mockBufferedProducer
                .Setup(producer => producer.CloseAsync(It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

           await mockBufferedProducer.Object.DisposeAsync();

           mockBufferedProducer
               .Verify(producer => producer.CloseAsync(true, default), Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.DisposeAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task DisposeIsSafeToCallMultipleTimes()
        {
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>("fqNamespace", "eventHub", Mock.Of<TokenCredential>(), null)
            {
                CallBase = true
            };

            mockBufferedProducer
                .Setup(producer => producer.CloseAsync(It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

           await mockBufferedProducer.Object.DisposeAsync();

           Assert.That(async () => await mockBufferedProducer.Object.DisposeAsync(), Throws.Nothing, "It should e safe to dispose the producer twice.");
           Assert.That(async () => await mockBufferedProducer.Object.DisposeAsync(), Throws.Nothing, "It should e safe to dispose the producer more than twice.");

           mockBufferedProducer
               .Verify(producer => producer.CloseAsync(true, default), Times.Exactly(3));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.CloseAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncFlushesWhenSet()
        {
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockBufferedProducer
                .SetupGet(producer => producer.IsPublishing)
                .Returns(true);

            await mockBufferedProducer.Object.CloseAsync(true);

            mockBufferedProducer.Verify(producer => producer.FlushInternalAsync(CancellationToken.None), Times.Once);
            mockBufferedProducer.Verify(producer => producer.ClearInternal(It.IsAny<CancellationToken>()), Times.Never);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.CloseAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncClearsWhenFlushNotSet()
        {
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockBufferedProducer
                .SetupGet(producer => producer.IsPublishing)
                .Returns(true);

            await mockBufferedProducer.Object.CloseAsync(false);

            mockBufferedProducer.Verify(producer => producer.ClearInternal(CancellationToken.None), Times.Once);
            mockBufferedProducer.Verify(producer => producer.FlushInternalAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.CloseAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncClosesTheProducer()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            await bufferedProducer.CloseAsync(false, cancellationSource.Token);
            mockProducer.Verify(producer => producer.CloseAsync(CancellationToken.None), Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.CloseAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncClearsPartitionState()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            bufferedProducer.ActivePartitionStateMap["0"] = new EventHubBufferedProducerClient.PartitionPublishingState("0", new EventHubBufferedProducerClientOptions());
            bufferedProducer.ActivePartitionStateMap["7"] = new EventHubBufferedProducerClient.PartitionPublishingState("7", new EventHubBufferedProducerClientOptions());

            await bufferedProducer.CloseAsync(false, cancellationSource.Token);
            Assert.That(bufferedProducer.ActivePartitionStateMap.Count, Is.EqualTo(0), "The partition state map should have been cleared.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.CloseAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncUnregistersTheEventHandlers()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            Func<SendEventBatchSucceededEventArgs, Task> successHandler = args => Task.CompletedTask;
            Func<SendEventBatchFailedEventArgs, Task> failHandler = args => Task.CompletedTask;

            bufferedProducer.SendEventBatchSucceededAsync += successHandler;
            bufferedProducer.SendEventBatchFailedAsync += failHandler;

            await bufferedProducer.CloseAsync(false, cancellationSource.Token);

            // The handlers should have been unregistered; attempting to do so again should cause
            // an exception.

            Assert.That(() => bufferedProducer.SendEventBatchSucceededAsync -= successHandler, Throws.InstanceOf<ArgumentException>(), "The success handler should have already been unregistered.");
            Assert.That(() => bufferedProducer.SendEventBatchFailedAsync -= failHandler, Throws.InstanceOf<ArgumentException>(), "The failure handler should have already been unregistered.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.CloseAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task CloseLogsTheOperation()
        {
            var expectedNamespace = "fakeNS";
            var expectedEventHub = "fakeHub";
            var expectedIdentifier = "abc123";
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>(expectedNamespace, expectedEventHub, Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = expectedIdentifier });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockBufferedProducer.Object.Logger = mockLogger.Object;
            await mockBufferedProducer.Object.CloseAsync();

            mockLogger
                .Verify(log => log.ClientCloseStart(
                    nameof(EventHubBufferedProducerClient),
                    expectedEventHub,
                    expectedIdentifier),
                Times.Once);

            mockLogger
                .Verify(log => log.ClientCloseComplete(
                    nameof(EventHubBufferedProducerClient),
                    expectedEventHub,
                    expectedIdentifier),
                Times.Once);

            mockLogger
                .Verify(log => log.ClientCloseError(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()),
                Times.Never);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.CloseAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task CloseLogsAnErrorClosingTheProducer()
        {
            var expectedNamespace = "fakeNS";
            var expectedEventHub = "fakeHub";
            var expectedIdentifier = "abc123";
            var expectedErrorMessage = "OMG WTF BBQ!";
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>(expectedNamespace, expectedEventHub, Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = expectedIdentifier });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockBufferedProducer.Object.Logger = mockLogger.Object;

            mockProducer
                .Setup(producer => producer.CloseAsync(It.IsAny<CancellationToken>()))
                .ThrowsAsync(new NotFiniteNumberException(expectedErrorMessage, 123));

            await mockBufferedProducer.Object.CloseAsync().IgnoreExceptions();

            mockLogger
                .Verify(log => log.ClientCloseError(
                    nameof(EventHubBufferedProducerClient),
                    expectedEventHub,
                    expectedIdentifier,
                    expectedErrorMessage),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.CloseAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task CloseLogsAnErrorWhenFlushFails()
        {
            var expectedNamespace = "fakeNS";
            var expectedEventHub = "fakeHub";
            var expectedIdentifier = "abc123";
            var expectedErrorMessage = "OMG WTF BBQ!";
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>(expectedNamespace, expectedEventHub, Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = expectedIdentifier });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockBufferedProducer.Object.Logger = mockLogger.Object;

            mockBufferedProducer
                .SetupGet(producer => producer.IsPublishing)
                .Returns(true);

            mockBufferedProducer
                .Setup(producer => producer.FlushInternalAsync(It.IsAny<CancellationToken>()))
                .ThrowsAsync(new NotFiniteNumberException(expectedErrorMessage, 123));

            await mockBufferedProducer.Object.CloseAsync().IgnoreExceptions();

            mockLogger
                .Verify(log => log.ClientCloseError(
                    nameof(EventHubBufferedProducerClient),
                    expectedEventHub,
                    expectedIdentifier,
                    expectedErrorMessage),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.CloseAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task CloseLogsAnErrorWhenClearFails()
        {
            var expectedNamespace = "fakeNS";
            var expectedEventHub = "fakeHub";
            var expectedIdentifier = "abc123";
            var expectedErrorMessage = "OMG WTF BBQ!";
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>(expectedNamespace, expectedEventHub, Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = expectedIdentifier });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockBufferedProducer.Object.Logger = mockLogger.Object;

            mockBufferedProducer
                .SetupGet(producer => producer.IsPublishing)
                .Returns(true);

            mockBufferedProducer
                .Setup(producer => producer.ClearInternal(It.IsAny<CancellationToken>()))
                .Throws(new NotFiniteNumberException(expectedErrorMessage, 123));

            await mockBufferedProducer.Object.CloseAsync(false).IgnoreExceptions();

            mockLogger
                .Verify(log => log.ClientCloseError(
                    nameof(EventHubBufferedProducerClient),
                    expectedEventHub,
                    expectedIdentifier,
                    expectedErrorMessage),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.CloseAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task CloseLogsAnErrorWhenClosingTheProducerFails()
        {
            var expectedNamespace = "fakeNS";
            var expectedEventHub = "fakeHub";
            var expectedIdentifier = "abc123";
            var expectedCloseErrorMessage = "OMG WTF BBQ!";
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>(expectedNamespace, expectedEventHub, Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = expectedIdentifier });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockBufferedProducer.Object.Logger = mockLogger.Object;

            mockBufferedProducer
                .SetupGet(producer => producer.IsPublishing)
                .Returns(true);

            mockProducer
                .Setup(producer => producer.CloseAsync(It.IsAny<CancellationToken>()))
                .ThrowsAsync(new FormatException(expectedCloseErrorMessage));

            mockBufferedProducer
                .Setup(producer => producer.FlushInternalAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            await mockBufferedProducer.Object.CloseAsync().IgnoreExceptions();

            mockLogger
                .Verify(log => log.ClientCloseError(
                    nameof(EventHubBufferedProducerClient),
                    expectedEventHub,
                    expectedIdentifier,
                    expectedCloseErrorMessage),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.CloseAsync" />.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CloseIsSafeToCallMultipleTimes(bool flush)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedNamespace = "fakeNS";
            var expectedEventHub = "fakeHub";
            var expectedIdentifier = "abc123";
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockBackgroundTask = Task.Delay(Timeout.Infinite, cancellationSource.Token);
            var mockProducer = new Mock<EventHubProducerClient>(expectedNamespace, expectedEventHub, Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = expectedIdentifier });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockBufferedProducer.Object.Logger = mockLogger.Object;

            // Setting a running background task will cause the producer to identify IsPublishing as true.

            SetBackgroundManagementTask(mockBufferedProducer.Object, mockBackgroundTask);
            Assert.That(mockBufferedProducer.Object.IsPublishing, Is.True, "The producer should report that it is publishing.");

            // Hook the log that indicates StopProcessing has been called; this should cancel the mock publishing task to allow
            // close to complete.

            mockLogger
                .Setup(log => log.BufferedProducerBackgroundProcessingStop(It.IsAny<string>(), It.IsAny<string>()))
                .Callback(cancellationSource.Cancel);

            mockBufferedProducer.Object.SendEventBatchSucceededAsync += args => Task.CompletedTask;
            mockBufferedProducer.Object.SendEventBatchFailedAsync += args => Task.CompletedTask;

            await mockBufferedProducer.Object.CloseAsync(flush);
            Assert.That(mockBufferedProducer.Object.IsClosed, Is.True, "The producer should be closed.");

            Assert.That(async () => await mockBufferedProducer.Object.CloseAsync(flush), Throws.Nothing, "It should e safe to close the producer twice.");
            Assert.That(async () => await mockBufferedProducer.Object.CloseAsync(flush), Throws.Nothing, "It should e safe to close the producer more than twice.");
            Assert.That(mockBufferedProducer.Object.IsClosed, Is.True, "The producer should still be closed after multiple calls.");

            if (flush)
            {
                mockBufferedProducer.Verify(producer => producer.FlushInternalAsync(It.IsAny<CancellationToken>()), Times.Once);
                mockBufferedProducer.Verify(producer => producer.ClearInternal(It.IsAny<CancellationToken>()), Times.Never);
            }
            else
            {
                mockBufferedProducer.Verify(producer => producer.FlushInternalAsync(It.IsAny<CancellationToken>()), Times.Never);
                mockBufferedProducer.Verify(producer => producer.ClearInternal(It.IsAny<CancellationToken>()), Times.Once);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.CloseAsync" />.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void CloseIsSafeToCallConcurrently(bool flush)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedNamespace = "fakeNS";
            var expectedEventHub = "fakeHub";
            var expectedIdentifier = "abc123";
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockBackgroundTask = Task.Delay(Timeout.Infinite, cancellationSource.Token);
            var mockProducer = new Mock<EventHubProducerClient>(expectedNamespace, expectedEventHub, Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = expectedIdentifier });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockBufferedProducer.Object.Logger = mockLogger.Object;

            // Setting a running background task will cause the producer to identify IsPublishing as true.

            SetBackgroundManagementTask(mockBufferedProducer.Object, mockBackgroundTask);
            Assert.That(mockBufferedProducer.Object.IsPublishing, Is.True, "The producer should report that it is publishing.");

            // Hook the log that indicates StopProcessing has been called; this should cancel the mock publishing task to allow
            // close to complete.

            mockLogger
                .Setup(log => log.BufferedProducerBackgroundProcessingStop(It.IsAny<string>(), It.IsAny<string>()))
                .Callback(cancellationSource.Cancel);

            mockBufferedProducer.Object.SendEventBatchSucceededAsync += args => Task.CompletedTask;
            mockBufferedProducer.Object.SendEventBatchFailedAsync += args => Task.CompletedTask;

            var whenAllTask = Task.WhenAll(mockBufferedProducer.Object.CloseAsync(flush), mockBufferedProducer.Object.CloseAsync(flush));

            Assert.That(async () => await whenAllTask, Throws.Nothing, "Concurrent execution of CloseAsync should not cause an error.");
            Assert.That(mockBufferedProducer.Object.IsClosed, Is.True, "The producer should be closed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.CloseAsync" />.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CloseStopsPublishing(bool flush)
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitions = new[] { "0", "1", "2", "3" };
            var mockProducer = new Mock<EventHubProducerClient>("fakeNs", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(partitions));

            try
            {
                await InvokeStartPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token);
                await mockBufferedProducer.Object.CloseAsync(flush);

                Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
                Assert.That(mockBufferedProducer.Object.IsClosed, Is.True, "The producer should be closed.");
                Assert.That(mockBufferedProducer.Object.IsPublishing, Is.False, "The producer should report that it is not publishing.");
                Assert.That(GetBackgroundPublishingTask(mockBufferedProducer.Object).IsCompleted, Is.True, "The publishing task should have been completed.");
            }
            finally
            {
                await InvokeStopPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.FlushAsync" /> method.
        /// </summary>
        ///
        [Test]
        public async Task FlushAsyncDelegatesToFlushInternalAsync()
        {
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            await mockBufferedProducer.Object.FlushAsync();
            mockBufferedProducer.Verify(producer => producer.FlushInternalAsync(CancellationToken.None), Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.FlushAsync" /> method.
        /// </summary>
        ///
        [Test]
        public void FlushAsyncValidatesNotClosed()
        {
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockBufferedProducer.Object.IsClosed = true;

            Assert.That(async () => await mockBufferedProducer.Object.FlushAsync(), Throws.InstanceOf<EventHubsException>(), "Flush should ensure the client is not closed.");
            mockBufferedProducer.Verify(producer => producer.FlushInternalAsync(CancellationToken.None), Times.Never);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.FlushAsync" /> method.
        /// </summary>
        ///
        [Test]
        public async Task FlushAsyncLogsTheOperation()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var options = new EventHubBufferedProducerClientOptions();
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockBufferedProducer
                .Setup(producer => producer.DrainAndPublishPartitionEvents(
                    It.IsAny<EventHubBufferedProducerClient.PartitionPublishingState>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            mockBufferedProducer.Object.Logger = mockLogger.Object;

            // Flush and verify.

            await mockBufferedProducer.Object.FlushAsync(cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");

            mockLogger
                .Verify(log => log.BufferedProducerFlushStart(
                    mockBufferedProducer.Object.Identifier,
                    mockBufferedProducer.Object.EventHubName,
                    It.IsAny<string>()),
                Times.Once);

            mockLogger
                .Verify(log => log.BufferedProducerFlushComplete(
                    mockBufferedProducer.Object.Identifier,
                    mockBufferedProducer.Object.EventHubName,
                    It.IsAny<string>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.FlushAsync" /> method.
        /// </summary>
        ///
        [Test]
        public void FlushAsyncLogsErrors()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedException = new ArithmeticException("Y no add right?");
            var options = new EventHubBufferedProducerClientOptions();
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState("5", options) { BufferedEventCount = 1 };
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockBufferedProducer
                .Setup(producer => producer.DrainAndPublishPartitionEvents(
                    It.IsAny<EventHubBufferedProducerClient.PartitionPublishingState>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .Throws(expectedException);

            mockBufferedProducer.Object.ActivePartitionStateMap[partitionState.PartitionId] = partitionState;
            mockBufferedProducer.Object.Logger = mockLogger.Object;

            // Flush and verify.

            Assert.That(async () => await mockBufferedProducer.Object.FlushAsync(cancellationSource.Token), Throws.TypeOf(expectedException.GetType()).And.Message.EqualTo(expectedException.Message), "The Flush operation should throw.");
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");

            mockLogger
                .Verify(log => log.BufferedProducerFlushError(
                    mockBufferedProducer.Object.Identifier,
                    mockBufferedProducer.Object.EventHubName,
                    It.IsAny<string>(),
                    expectedException.Message),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.FlushAsync" /> method.
        /// </summary>
        ///
        [Test]
        public async Task FlushAsyncStopsPublishing()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitions = new[] { "0", "1", "2", "3" };
            var options = new EventHubBufferedProducerClientOptions();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(partitions));

            mockBufferedProducer
                .Setup(producer => producer.DrainAndPublishPartitionEvents(
                    It.IsAny<EventHubBufferedProducerClient.PartitionPublishingState>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            try
            {
                await InvokeStartPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token);

                foreach (var partition in partitions)
                {
                    mockBufferedProducer.Object.ActivePartitionStateMap[partition] = new EventHubBufferedProducerClient.PartitionPublishingState(partition, options) { BufferedEventCount = 1 };
                }

                await mockBufferedProducer.Object.FlushAsync(cancellationSource.Token);

                Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
                Assert.That(mockBufferedProducer.Object.IsPublishing, Is.False, "The producer should report that it is not publishing.");
                Assert.That(GetBackgroundPublishingTask(mockBufferedProducer.Object).IsCompleted, Is.True, "The publishing task should have been completed.");
            }
            finally
            {
                await InvokeStopPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.FlushAsync" /> method.
        /// </summary>
        ///
        [Test]
        public async Task FlushAsyncDoesNotDrainWhenNoPartitionsAreMapped()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var options = new EventHubBufferedProducerClientOptions();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockBufferedProducer
                .Setup(producer => producer.DrainAndPublishPartitionEvents(
                    It.IsAny<EventHubBufferedProducerClient.PartitionPublishingState>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // Flush and verify.

            await mockBufferedProducer.Object.FlushAsync(cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");

            mockBufferedProducer
                .Verify(producer => producer.DrainAndPublishPartitionEvents(
                    It.IsAny<EventHubBufferedProducerClient.PartitionPublishingState>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.FlushAsync" /> method.
        /// </summary>
        ///
        [Test]
        public async Task FlushAsyncDoesNotDrainWhenNoPartitionsHaveNoEvents()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var options = new EventHubBufferedProducerClientOptions();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockBufferedProducer
                .Setup(producer => producer.DrainAndPublishPartitionEvents(
                    It.IsAny<EventHubBufferedProducerClient.PartitionPublishingState>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            foreach (var partition in new[] { "0", "1", "2" })
            {
                mockBufferedProducer.Object.ActivePartitionStateMap[partition] = new EventHubBufferedProducerClient.PartitionPublishingState(partition, options) { BufferedEventCount = 0 };
            }

            // Flush and verify.

            await mockBufferedProducer.Object.FlushAsync(cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");

            mockBufferedProducer
                .Verify(producer => producer.DrainAndPublishPartitionEvents(
                    It.IsAny<EventHubBufferedProducerClient.PartitionPublishingState>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.FlushAsync" /> method.
        /// </summary>
        ///
        [Test]
        public async Task FlushAsyncDrainsPartitions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitions = new[] { "0", "1", "2", "3" };
            var options = new EventHubBufferedProducerClientOptions();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockBufferedProducer
                .Setup(producer => producer.DrainAndPublishPartitionEvents(
                    It.IsAny<EventHubBufferedProducerClient.PartitionPublishingState>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            foreach (var partition in partitions)
            {
                mockBufferedProducer.Object.ActivePartitionStateMap[partition] = new EventHubBufferedProducerClient.PartitionPublishingState(partition, options) { BufferedEventCount = 1 };
            }

            // Flush and verify.

            await mockBufferedProducer.Object.FlushAsync(cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");

            mockBufferedProducer
                .Verify(producer => producer.DrainAndPublishPartitionEvents(
                    It.Is<EventHubBufferedProducerClient.PartitionPublishingState>(value => partitions.Any(item => item == value.PartitionId)),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()),
                Times.Exactly(partitions.Length));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.FlushAsync" /> method.
        /// </summary>
        ///
        [Test]
        public async Task FlushAsyncInvokesTheSuccessHandlerAndWaitsForCompletion()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedPartition = "4";
            var expectedEvents = EventGenerator.CreateSmallEvents(10).ToList();
            var batchedEvents = new List<EventData>();
            var handlerArgs = default(SendEventBatchSucceededEventArgs);
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventHubBufferedProducerClientOptions { MaximumWaitTime = EventHubsTestEnvironment.Instance.TestExecutionTimeLimit };
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { expectedPartition, "6" });

            mockProducer
                .Setup(producer => producer.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns<CreateBatchOptions, CancellationToken>((options, token) => new ValueTask<EventDataBatch>(EventHubsModelFactory.EventDataBatch(1_048_576, batchedEvents, options, _ => batchedEvents.Count < expectedEvents.Count)));

            mockProducer
                .Setup(producer => producer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            mockBufferedProducer.Object.ActivePartitionStateMap[expectedPartition] = partitionState;

            // Wire up the handler.

            mockBufferedProducer.Object.SendEventBatchSucceededAsync += async args =>
            {
                handlerArgs = args;
                batchedEvents.Clear();

                await Task.Delay(250);
                completionSource.TrySetResult(true);
            };

            // Enqueue the events that need to be published.

            foreach (var eventData in expectedEvents)
            {
                await partitionState.PendingEventsWriter.WriteAsync(eventData, cancellationSource.Token);
                partitionState.BufferedEventCount += 1;
            }

            // Flush and verify.

            await mockBufferedProducer.Object.FlushAsync(cancellationSource.Token).AwaitWithCancellation(cancellationSource.Token);
            await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
            Assert.That(partitionState.BufferedEventCount, Is.EqualTo(0), "The buffered event count for the partition should reflect all events having been published.");
            Assert.That(handlerArgs.PartitionId, Is.EqualTo(expectedPartition), "The partition should have been set for the handler arguments.");
            Assert.That(handlerArgs.EventBatch.Count, Is.EqualTo(expectedEvents.Count), "The number of events in the handler arguments should match.");

            mockBufferedProducer
                .Verify(producer => producer.DrainAndPublishPartitionEvents(
                    It.IsAny<EventHubBufferedProducerClient.PartitionPublishingState>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.FlushAsync" /> method.
        /// </summary>
        ///
        [Test]
        public async Task FlushAsyncInvokesTheFailureHandlerAndWaitsForCompletion()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedPartition = "4";
            var expectedException = new AccessViolationException();
            var expectedEvents = EventGenerator.CreateSmallEvents(10).ToList();
            var batchedEvents = new List<EventData>();
            var handlerArgs = default(SendEventBatchFailedEventArgs);
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventHubBufferedProducerClientOptions { MaximumWaitTime = EventHubsTestEnvironment.Instance.TestExecutionTimeLimit };
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { expectedPartition, "6" });

            mockProducer
                .Setup(producer => producer.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns<CreateBatchOptions, CancellationToken>((options, token) => new ValueTask<EventDataBatch>(EventHubsModelFactory.EventDataBatch(1_048_576, batchedEvents, options, _ => batchedEvents.Count < expectedEvents.Count)));

            mockProducer
                .Setup(producer => producer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(expectedException);

            mockBufferedProducer.Object.ActivePartitionStateMap[expectedPartition] = partitionState;

            // Wire up the handler.

            mockBufferedProducer.Object.SendEventBatchFailedAsync += async args =>
            {
                handlerArgs = args;
                batchedEvents.Clear();

                await Task.Delay(250);
                completionSource.TrySetResult(true);
            };

            // Enqueue the events that need to be published.

            foreach (var eventData in expectedEvents)
            {
                await partitionState.PendingEventsWriter.WriteAsync(eventData, cancellationSource.Token);
                partitionState.BufferedEventCount += 1;
            }

            // Flush and verify.

            await mockBufferedProducer.Object.FlushAsync(cancellationSource.Token).AwaitWithCancellation(cancellationSource.Token);
            await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
            Assert.That(partitionState.BufferedEventCount, Is.EqualTo(0), "The buffered event count for the partition should reflect all events having been published.");
            Assert.That(handlerArgs.PartitionId, Is.EqualTo(expectedPartition), "The partition should have been set for the handler arguments.");
            Assert.That(handlerArgs.EventBatch.Count, Is.EqualTo(expectedEvents.Count), "The number of events in the handler arguments should match.");
            Assert.That(handlerArgs.Exception, Is.EqualTo(expectedException), "The observed exception should match.");

            mockBufferedProducer
                .Verify(producer => producer.DrainAndPublishPartitionEvents(
                    It.IsAny<EventHubBufferedProducerClient.PartitionPublishingState>(),
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.FlushAsync" /> method.
        /// </summary>
        ///
        [Test]
        public async Task FlushAsyncToleratesExceptionsInTheSuccessHandler()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedPartition = "4";
            var expectedEvents = EventGenerator.CreateSmallEvents(10).ToList();
            var handlerWasCalled = false;
            var batchedEvents = new List<EventData>();
            var options = new EventHubBufferedProducerClientOptions { MaximumWaitTime = EventHubsTestEnvironment.Instance.TestExecutionTimeLimit };
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { expectedPartition, "6" });

            mockProducer
                .Setup(producer => producer.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns<CreateBatchOptions, CancellationToken>((options, token) => new ValueTask<EventDataBatch>(EventHubsModelFactory.EventDataBatch(1_048_576, batchedEvents, options, _ => batchedEvents.Count < expectedEvents.Count)));

            mockProducer
                .Setup(producer => producer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            mockBufferedProducer.Object.ActivePartitionStateMap[expectedPartition] = partitionState;

            // Wire up the handler.

            mockBufferedProducer.Object.SendEventBatchSucceededAsync += args =>
            {
                batchedEvents.Clear();
                handlerWasCalled = true;

                throw new AmbiguousMatchException("I was actually thinking of the 3 of clubs.");
            };

            // Enqueue the events that need to be published.

            foreach (var eventData in expectedEvents)
            {
                await partitionState.PendingEventsWriter.WriteAsync(eventData, cancellationSource.Token);
                partitionState.BufferedEventCount += 1;
            }

            // Flush and verify.

            Assert.That(async () => await mockBufferedProducer.Object.FlushAsync(cancellationSource.Token).AwaitWithCancellation(cancellationSource.Token), Throws.Nothing);
            Assert.That(handlerWasCalled, Is.True, "The success handler should have been called.");
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.FlushAsync" /> method.
        /// </summary>
        ///
        [Test]
        public async Task FlushAsyncToleratesExceptionsInTheFailureHandler()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedPartition = "4";
            var expectedEvents = EventGenerator.CreateSmallEvents(10).ToList();
            var handlerWasCalled = false;
            var batchedEvents = new List<EventData>();
            var options = new EventHubBufferedProducerClientOptions { MaximumWaitTime = EventHubsTestEnvironment.Instance.TestExecutionTimeLimit };
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { expectedPartition, "6" });

            mockProducer
                .Setup(producer => producer.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns<CreateBatchOptions, CancellationToken>((options, token) => new ValueTask<EventDataBatch>(EventHubsModelFactory.EventDataBatch(1_048_576, batchedEvents, options, _ => batchedEvents.Count < expectedEvents.Count)));

            mockProducer
                .Setup(producer => producer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new AccessViolationException());

            mockBufferedProducer.Object.ActivePartitionStateMap[expectedPartition] = partitionState;

            // Wire up the handler.

            mockBufferedProducer.Object.SendEventBatchFailedAsync += args =>
            {
                batchedEvents.Clear();
                handlerWasCalled = true;

                throw new BadImageFormatException("I've seen better selfies...");
            };

            // Enqueue the events that need to be published.

            foreach (var eventData in expectedEvents)
            {
                await partitionState.PendingEventsWriter.WriteAsync(eventData, cancellationSource.Token);
                partitionState.BufferedEventCount += 1;
            }

            // Flush and verify.

            Assert.That(async () => await mockBufferedProducer.Object.FlushAsync(cancellationSource.Token).AwaitWithCancellation(cancellationSource.Token), Throws.Nothing);
            Assert.That(handlerWasCalled, Is.True, "The success handler should have been called.");
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.FlushAsync" /> method.
        /// </summary>
        ///
        [Test]
        public async Task FlushAsyncAllowsEventsToBeEnqueuedAfterCompletion()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "7";
            var partitions = new[] { partitionId };
            var events = new[] { new EventData("One"), new EventData("Two") };
            var mockPartitionResolver = new Mock<PartitionResolver>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockPartitionResolver
                .Setup(resolver => resolver.AssignRoundRobin(It.IsAny<string[]>()))
                .Returns(partitionId);

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitions);

            mockBufferedProducer
                .Setup(producer => producer.PublishBatchToPartition(
                    It.IsAny<EventHubBufferedProducerClient.PartitionPublishingState>(),
                    It.IsAny<bool>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            mockBufferedProducer.Object.PartitionResolver = mockPartitionResolver.Object;
            mockBufferedProducer.Object.SendEventBatchFailedAsync += args => Task.CompletedTask;

            try
            {
                var enqueuedCount = await mockBufferedProducer.Object.EnqueueEventsAsync(events, cancellationSource.Token);
                Assert.That(mockBufferedProducer.Object.ActivePartitionStateMap.TryGetValue(partitionId, out var partitionPublisher), Is.True, "A publisher should have been registered for the partition.");

                Assert.That(enqueuedCount, Is.EqualTo(events.Length), "The return value should indicate that the correct number of events were enqueued.");
                Assert.That(mockBufferedProducer.Object.TotalBufferedEventCount, Is.EqualTo(events.Length), "The total event count should indicate that the correct number of events were enqueued.");
                Assert.That(mockBufferedProducer.Object.GetBufferedEventCount(partitionId), Is.EqualTo(events.Length), "The partition event count should indicate that the correct number of events were enqueued.");

                await mockBufferedProducer.Object.FlushAsync(cancellationSource.Token);
                Assert.That(async () => await mockBufferedProducer.Object.EnqueueEventsAsync(new[] { new EventData("Three"), new EventData("Four") }, cancellationSource.Token), Throws.Nothing, "It should be possible to enqueue events after flushing.");
            }
            finally
            {
                await mockBufferedProducer.Object.CloseAsync(false).IgnoreExceptions();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.ClearInternal" /> method.
        /// </summary>
        ///
        [Test]
        public void ClearInternalLogsTheOperation()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var options = new EventHubBufferedProducerClientOptions();
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockBufferedProducer.Object.Logger = mockLogger.Object;

            // Clear and verify.

            mockBufferedProducer.Object.ClearInternal(cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");

            mockLogger
                .Verify(log => log.BufferedProducerClearStart(
                    mockBufferedProducer.Object.Identifier,
                    mockBufferedProducer.Object.EventHubName,
                    It.IsAny<string>()),
                Times.Once);

            mockLogger
                .Verify(log => log.BufferedProducerClearComplete(
                    mockBufferedProducer.Object.Identifier,
                    mockBufferedProducer.Object.EventHubName,
                    It.IsAny<string>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.ClearInternal" /> method.
        /// </summary>
        ///
        [Test]
        public void ClearInternalLogsErrors()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            var options = new EventHubBufferedProducerClientOptions();
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState("5", options) { BufferedEventCount = 1 };
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockBufferedProducer.Object.ActivePartitionStateMap[partitionState.PartitionId] = partitionState;
            mockBufferedProducer.Object.Logger = mockLogger.Object;

            // Flush and verify.

            Assert.That(() => mockBufferedProducer.Object.ClearInternal(cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>(), "The Flush operation should throw for cancellation.");

            mockLogger
                .Verify(log => log.BufferedProducerClearError(
                    mockBufferedProducer.Object.Identifier,
                    mockBufferedProducer.Object.EventHubName,
                    It.IsAny<string>(),
                    It.IsAny<string>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.ClearInternal" /> method.
        /// </summary>
        ///
        [Test]
        public async Task ClearInternalClearsPartitions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitions = new[] { "0", "1", "2", "3" };
            var options = new EventHubBufferedProducerClientOptions();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            foreach (var partition in partitions)
            {
                mockBufferedProducer.Object.ActivePartitionStateMap[partition] = new EventHubBufferedProducerClient.PartitionPublishingState(partition, options) { BufferedEventCount = 1 };
                await mockBufferedProducer.Object.ActivePartitionStateMap[partition].PendingEventsWriter.WriteAsync(new EventData("Test"), cancellationSource.Token);
            }

            // Clear and verify.

            mockBufferedProducer.Object.ClearInternal(cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");

            foreach (var partition in partitions)
            {
                Assert.That(mockBufferedProducer.Object.ActivePartitionStateMap[partition].BufferedEventCount, Is.EqualTo(0), $"Partition: [{ partition }] should have been cleared, but has a count.");
                Assert.That(mockBufferedProducer.Object.ActivePartitionStateMap[partition].TryReadEvent(out _), Is.False, $"Partition: [{ partition }] should have been cleared, but had an event.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the non-public <c>StartPublishingAsync</c>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void StartPublishingAsyncRespectsCancellation()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            Assert.That(async () => await InvokeStartPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the non-public <c>StartPublishingAsync</c>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task StartPublishingThrowsTaskCanceledExceptionAsEventHubsException()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var options = new EventHubProducerClientOptions { RetryOptions = new EventHubsRetryOptions { TryTimeout = TimeSpan.FromSeconds(1) } };

            var mockConnection = new Mock<EventHubConnection>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), default);
            mockConnection.Setup(connection => connection.GetPartitionIdsAsync(
                It.IsAny<EventHubsRetryPolicy>(),
                It.IsAny<CancellationToken>()))
            .ThrowsAsync(new TaskCanceledException());
            var connection = mockConnection.Object;

            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" }) { CallBase = true };
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            await Task.Yield();
            var thrownException = Assert.ThrowsAsync<EventHubsException>(async () => await InvokeStartPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token), "The attempt to start publishing should have surfaced an exception.");
            Assert.True(thrownException.IsTransient, "Exception thrown should be transient");
            Assert.That(thrownException.Reason, Is.EqualTo(EventHubsException.FailureReason.ServiceTimeout), "Exception thrown should have a reason of ServiceCommunicationProblem.");
        }

        /// <summary>
        ///   Verifies functionality of the non-public <c>StartPublishingAsync</c>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task StartPublishingAsyncInspectsPartitions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            try
            {
                await InvokeStartPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token);
            }
            finally
            {
                await InvokeStopPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token).IgnoreExceptions();
            }

            mockProducer
                .Verify(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()),
                Times.AtLeastOnce());
        }

        /// <summary>
        ///   Verifies functionality of the non-public <c>StartPublishingAsync</c>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task StartPublishingAsyncLogsTheOperation()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var mockEventSource = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockBufferedProducer.Object.Logger = mockEventSource.Object;

            try
            {
                await InvokeStartPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token);
            }
            finally
            {
                await InvokeStopPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token).IgnoreExceptions();
            }

            mockEventSource
                .Verify(log => log.BufferedProducerBackgroundProcessingStart(
                    mockProducer.Object.Identifier,
                    mockProducer.Object.EventHubName),
                Times.Once);

            mockEventSource
                .Verify(log => log.BufferedProducerBackgroundProcessingStartComplete(
                    mockProducer.Object.Identifier,
                    mockProducer.Object.EventHubName),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the non-public <c>StartPublishingAsync</c>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void StartPublishingAsyncSurfacesAndLogsErrors()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedErrorMessage = "OMG, It broke!";
            var expectedException = new DivideByZeroException(expectedErrorMessage);
            var mockEventSource = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockBufferedProducer.Object.Logger = mockEventSource.Object;

            mockBufferedProducer
                .Setup(producer => producer.IsPublishing)
                .Throws(expectedException)
                .Verifiable("Partition identifiers should have been requested");

            Assert.That(async () => await InvokeStartPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token), Throws.TypeOf(expectedException.GetType()), "The attempt to start publishing should have surfaced an exception.");

            mockEventSource
                .Verify(log => log.BufferedProducerBackgroundProcessingStartError(
                    mockProducer.Object.Identifier,
                    mockProducer.Object.EventHubName,
                    expectedErrorMessage),
                Times.Once);

            mockBufferedProducer.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the non-public <c>StopPublishingAsync</c>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void StopPublishingAsyncRespectsCancellation()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            Assert.That(async () => await InvokeStopPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the non-public <c>StopPublishingAsync</c>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task StopPublishingAsyncLogsTheOperation()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var mockEventSource = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockBufferedProducer.Object.Logger = mockEventSource.Object;

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { "0", "1" });

            await InvokeStartPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token);
            await InvokeStopPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token);

            mockEventSource
                .Verify(log => log.BufferedProducerBackgroundProcessingStop(
                    mockProducer.Object.Identifier,
                    mockProducer.Object.EventHubName),
                Times.Once);

            mockEventSource
                .Verify(log => log.BufferedProducerBackgroundProcessingStopComplete(
                    mockProducer.Object.Identifier,
                    mockProducer.Object.EventHubName),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the non-public <c>StopPublishingAsync</c>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void StopPublishingAsyncSurfacesAndLogsErrors()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedErrorMessage = "OMG, It broke!";
            var expectedException = new DivideByZeroException(expectedErrorMessage);
            var mockEventSource = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockBufferedProducer.Object.Logger = mockEventSource.Object;

            SetBackgroundManagementTask(mockBufferedProducer.Object, Task.FromException(expectedException));
            Assert.That(async () => await InvokeStopPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token), Throws.TypeOf(expectedException.GetType()), "The attempt to stop publishing should have surfaced an exception.");

            mockEventSource
                .Verify(log => log.BufferedProducerBackgroundProcessingStopError(
                    mockProducer.Object.Identifier,
                    mockProducer.Object.EventHubName,
                    expectedErrorMessage),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventsAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task EnqueueEventsAsyncWithoutOptionsDelegatesToTheOptionsOverload()
        {
            using var cancellationSource = new CancellationTokenSource();

            var expectedEvents = new[] { new EventData("One"), new EventData("Two") };
            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockBufferedProducer
                .Setup(producer => producer.EnqueueEventsAsync(It.IsAny<IEnumerable<EventData>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(1));

            await mockBufferedProducer.Object.EnqueueEventsAsync(expectedEvents, cancellationSource.Token);

            mockBufferedProducer
                .Verify(producer => producer.EnqueueEventsAsync(expectedEvents, cancellationSource.Token),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventsAsync" />.
        /// </summary>
        ///
        [Test]
        public void EnqueueEventsAsyncValidatesNotClosed()
        {
            using var cancellationSource = new CancellationTokenSource();

            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            bufferedProducer.IsClosed = true;
            Assert.That(async () => await bufferedProducer.EnqueueEventsAsync(new[] { new EventData("Dummy") }, cancellationSource.Token), Throws.InstanceOf<EventHubsException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventsAsync" />.
        /// </summary>
        ///
        [Test]
        public void EnqueueEventsAsyncValidatesEvents()
        {
            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;
            Assert.That(async () => await bufferedProducer.EnqueueEventsAsync(null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventsAsync" />.
        /// </summary>
        ///
        [Test]
        public void EnqueueEventsAsyncValidatesOptions()
        {
            var events = new[] { new EventData("One"), new EventData("Two") };
            var invalidOptions = new EnqueueEventOptions { PartitionId = "1", PartitionKey = "key" };
            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;
            Assert.That(async () => await bufferedProducer.EnqueueEventsAsync(events, invalidOptions), Throws.InstanceOf<InvalidOperationException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task EnqueueEventAsyncValidatesThePartition()
        {
            var invalidOptions = new EnqueueEventOptions { PartitionId = "1" };
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { "0" });

            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;

            try
            {
                Assert.That(async () => await bufferedProducer.EnqueueEventsAsync(new[] { new EventData("One"), new EventData("Two") }, invalidOptions), Throws.InstanceOf<InvalidOperationException>());
            }
            finally
            {
                await bufferedProducer.CloseAsync(false).IgnoreExceptions();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventsAsync" />.
        /// </summary>
        ///
        [Test]
        public void EnqueueEventsAsyncValidatesFailHandler()
        {
            var events = new[] { new EventData("One"), new EventData("Two") };
            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            Assert.That(async () => await bufferedProducer.EnqueueEventsAsync(events), Throws.InstanceOf<InvalidOperationException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventsAsync" />.
        /// </summary>
        ///
        [Test]
        public void EnqueueEventsAsyncHonorsCancellation()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            var events = new[] { new EventData("One"), new EventData("Two") };
            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;
            Assert.That(async () => await bufferedProducer.EnqueueEventsAsync(events, cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventsAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task EnqueueEventsAsyncLocksHandlers()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var events = new[] { new EventData("One"), new EventData("Two") };
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { "0", "1" });

            Func<SendEventBatchSucceededEventArgs, Task> successHandler = args => Task.CompletedTask;
            Func<SendEventBatchFailedEventArgs, Task> failHandler = args => Task.CompletedTask;

            try
            {
                bufferedProducer.SendEventBatchSucceededAsync += successHandler;
                bufferedProducer.SendEventBatchFailedAsync += failHandler;

                await bufferedProducer.EnqueueEventsAsync(events, cancellationSource.Token);

                Assert.That(() => bufferedProducer.SendEventBatchSucceededAsync -= successHandler, Throws.InstanceOf<InvalidOperationException>());
                Assert.That(() => bufferedProducer.SendEventBatchFailedAsync -= failHandler, Throws.InstanceOf<InvalidOperationException>());
            }
            finally
            {
                await bufferedProducer.CloseAsync(false).IgnoreExceptions();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventsAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task EnqueueEventsAsyncStartsPublishing()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var events = new[] { new EventData("One"), new EventData("Two") };
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { "0", "1" });

            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;
            Assert.That(bufferedProducer.IsPublishing, Is.False, "Publishing should not start until an event is enqueued.");

            try
            {
                await bufferedProducer.EnqueueEventsAsync(events, cancellationSource.Token);
                Assert.That(bufferedProducer.IsPublishing, Is.True, "Publishing should have started when the first event was enqueued.");
            }
            finally
            {
                await bufferedProducer.CloseAsync(false).IgnoreExceptions();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventsAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task EnqueueEventsAsyncEnqueuesForAutomaticRouting()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "7";
            var partitions = new[] { partitionId };
            var events = new[] { new EventData("One"), new EventData("Two") };
            var mockPartitionResolver = new Mock<PartitionResolver>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockPartitionResolver
                .Setup(resolver => resolver.AssignRoundRobin(It.IsAny<string[]>()))
                .Returns(partitionId);

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitions);

            mockBufferedProducer
                .Setup(producer => producer.PublishBatchToPartition(
                    It.IsAny<EventHubBufferedProducerClient.PartitionPublishingState>(),
                    It.IsAny<bool>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            mockBufferedProducer.Object.PartitionResolver = mockPartitionResolver.Object;
            mockBufferedProducer.Object.SendEventBatchFailedAsync += args => Task.CompletedTask;

            try
            {
                var enqueuedCount = await mockBufferedProducer.Object.EnqueueEventsAsync(events, cancellationSource.Token);
                Assert.That(mockBufferedProducer.Object.ActivePartitionStateMap.TryGetValue(partitionId, out var partitionPublisher), Is.True, "A publisher should have been registered for the partition.");

                Assert.That(enqueuedCount, Is.EqualTo(events.Length), "The return value should indicate that the correct number of events were enqueued.");
                Assert.That(mockBufferedProducer.Object.TotalBufferedEventCount, Is.EqualTo(events.Length), "The total event count should indicate that the correct number of events were enqueued.");
                Assert.That(mockBufferedProducer.Object.GetBufferedEventCount(partitionId), Is.EqualTo(events.Length), "The partition event count should indicate that the correct number of events were enqueued.");

                var readEventCount = 0;

                while (readEventCount < events.Length)
                {
                    if (partitionPublisher.TryReadEvent(out var readEvent))
                    {
                        ++readEventCount;

                        Assert.That(events.SingleOrDefault(item => item.EventBody.ToString() == readEvent.EventBody.ToString()), Is.Not.Null, $"The event with body: [{ readEvent.EventBody }] was not in the source.");
                        Assert.That(readEvent.GetRawAmqpMessage().GetPartitionKey(null), Is.Null, $"The partition key should not have been set for the event with body: [{ readEvent.EventBody }].");
                    }

                    await Task.Delay(10, cancellationSource.Token);
                }

                Assert.That(readEventCount, Is.EqualTo(events.Length), "The number of events read should match the source length.");
            }
            finally
            {
                await mockBufferedProducer.Object.CloseAsync(false).IgnoreExceptions();
            }

            mockPartitionResolver
                .Verify(resolver => resolver.AssignRoundRobin(partitions), Times.Exactly(events.Length));

            mockPartitionResolver
                .Verify(resolver => resolver.AssignForPartitionKey(
                    It.IsAny<string>(),
                    It.IsAny<string[]>()),
                Times.Never);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventsAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task EnqueueEventsAsyncEnqueuesWithAPartitionKey()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "3";
            var partitions = new[] { partitionId };
            var partitionKey = "test-key";
            var events = new[] { new EventData("One"), new EventData("Two") };
            var mockPartitionResolver = new Mock<PartitionResolver>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockPartitionResolver
                .Setup(resolver => resolver.AssignForPartitionKey(It.IsAny<string>(), It.IsAny<string[]>()))
                .Returns(partitionId);

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitions);

            mockBufferedProducer
                .Setup(producer => producer.PublishBatchToPartition(
                    It.IsAny<EventHubBufferedProducerClient.PartitionPublishingState>(),
                    It.IsAny<bool>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            mockBufferedProducer.Object.PartitionResolver = mockPartitionResolver.Object;
            mockBufferedProducer.Object.SendEventBatchFailedAsync += args => Task.CompletedTask;

            try
            {
                var options = new EnqueueEventOptions { PartitionKey = partitionKey };
                var enqueuedCount = await mockBufferedProducer.Object.EnqueueEventsAsync(events, options, cancellationSource.Token);

                Assert.That(mockBufferedProducer.Object.ActivePartitionStateMap.TryGetValue(partitionId, out var partitionPublisher), Is.True, "A publisher should have been registered for the partition.");
                Assert.That(enqueuedCount, Is.EqualTo(events.Length), "The return value should indicate that the correct number of events were enqueued.");
                Assert.That(mockBufferedProducer.Object.TotalBufferedEventCount, Is.EqualTo(events.Length), "The total event count should indicate that the correct number of events were enqueued.");
                Assert.That(mockBufferedProducer.Object.GetBufferedEventCount(partitionId), Is.EqualTo(events.Length), "The partition event count should indicate that the correct number of events were enqueued.");

                var readEventCount = 0;

                while (readEventCount < events.Length)
                {
                    if (partitionPublisher.TryReadEvent(out var readEvent))
                    {
                        ++readEventCount;

                        Assert.That(events.SingleOrDefault(item => item.EventBody.ToString() == readEvent.EventBody.ToString()), Is.Not.Null, $"The event with body: [{ readEvent.EventBody }] was not in the source.");
                        Assert.That(readEvent.GetRawAmqpMessage().GetPartitionKey(null), Is.EqualTo(partitionKey), $"The partition key should have been preserved for the event with body: [{ readEvent.EventBody }].");
                    }

                    await Task.Delay(10, cancellationSource.Token);
                }

                Assert.That(readEventCount, Is.EqualTo(events.Length), "The number of events read should match the source length.");
            }
            finally
            {
                await mockBufferedProducer.Object.CloseAsync(false).IgnoreExceptions();
            }

            mockPartitionResolver
                .Verify(resolver => resolver.AssignRoundRobin(It.IsAny<string[]>()), Times.Never);

            mockPartitionResolver
                .Verify(resolver => resolver.AssignForPartitionKey(partitionKey, partitions), Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventsAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task EnqueueEventsAsyncEnqueuesWithAPartitionAssignment()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "2";
            var events = new[] { new EventData("One"), new EventData("Two") };
            var mockPartitionResolver = new Mock<PartitionResolver>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { "0", partitionId, "1" });

            mockBufferedProducer
                .Setup(producer => producer.PublishBatchToPartition(
                    It.IsAny<EventHubBufferedProducerClient.PartitionPublishingState>(),
                    It.IsAny<bool>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            mockBufferedProducer.Object.PartitionResolver = mockPartitionResolver.Object;
            mockBufferedProducer.Object.SendEventBatchFailedAsync += args => Task.CompletedTask;

            try
            {
                var options = new EnqueueEventOptions { PartitionId = partitionId };
                var enqueuedCount = await mockBufferedProducer.Object.EnqueueEventsAsync(events, options, cancellationSource.Token);

                Assert.That(mockBufferedProducer.Object.ActivePartitionStateMap.TryGetValue(partitionId, out var partitionPublisher), Is.True, "A publisher should have been registered for the partition.");
                Assert.That(enqueuedCount, Is.EqualTo(events.Length), "The return value should indicate that the correct number of events were enqueued.");
                Assert.That(mockBufferedProducer.Object.TotalBufferedEventCount, Is.EqualTo(events.Length), "The total event count should indicate that the correct number of events were enqueued.");
                Assert.That(mockBufferedProducer.Object.GetBufferedEventCount(partitionId), Is.EqualTo(events.Length), "The partition event count should indicate that the correct number of events were enqueued.");

                var readEventCount = 0;

                while (readEventCount < events.Length)
                {
                    if (partitionPublisher.TryReadEvent(out var readEvent))
                    {
                        ++readEventCount;

                        Assert.That(events.SingleOrDefault(item => item.EventBody.ToString() == readEvent.EventBody.ToString()), Is.Not.Null, $"The event with body: [{ readEvent.EventBody }] was not in the source.");
                        Assert.That(readEvent.GetRawAmqpMessage().GetPartitionKey(null), Is.Null, $"The partition key should not have been set for the event with body: [{ readEvent.EventBody }].");
                    }

                    await Task.Delay(10, cancellationSource.Token);
                }

                Assert.That(readEventCount, Is.EqualTo(events.Length), "The number of events read should match the source length.");
            }
            finally
            {
                await mockBufferedProducer.Object.CloseAsync(false).IgnoreExceptions();
            }

            mockPartitionResolver
                .Verify(resolver => resolver.AssignRoundRobin(It.IsAny<string[]>()), Times.Never);

            mockPartitionResolver
                .Verify(resolver => resolver.AssignForPartitionKey(
                    It.IsAny<string>(),
                    It.IsAny<string[]>()),
                Times.Never);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventsAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task EnqueueEventsAsyncWaitsWhenFull()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "4";
            var events = new[] { new EventData("One"), new EventData("Two") };
            var options = new EventHubBufferedProducerClientOptions { MaximumEventBufferLengthPerPartition = 1 };
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducerOptions = new EventHubBufferedProducerClientOptions { MaximumEventBufferLengthPerPartition = 1 };
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, bufferedProducerOptions) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { partitionId });

            mockBufferedProducer
                .Setup(producer => producer.PublishBatchToPartition(
                    It.IsAny<EventHubBufferedProducerClient.PartitionPublishingState>(),
                    It.IsAny<bool>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            mockBufferedProducer.Object.SendEventBatchFailedAsync += args => Task.CompletedTask;

            try
            {
                // This enqueue will cause the channel to be considered full and block additional enqueues.

                await mockBufferedProducer.Object.EnqueueEventsAsync(new[] { new EventData("Blocker") }, cancellationSource.Token);

                // Start the task to enqueue events, then delay and ensure that it is still not completed.

                var enqueueTask = mockBufferedProducer.Object.EnqueueEventsAsync(events, cancellationSource.Token);
                await Task.Delay(TimeSpan.FromSeconds(1), cancellationSource.Token);

                Assert.That(enqueueTask.IsCompleted, Is.False, "The enqueue task should not be completed.");
                Assert.That(mockBufferedProducer.Object.ActivePartitionStateMap.TryGetValue(partitionId, out var partitionPublisher), Is.True, "A publisher should have been registered for the partition.");

                // Read the blocking event to clear room.  This event shouldn't be in the expected list.

                var readEventCount = 0;

                Assert.That(partitionPublisher.TryReadEvent(out var blockerEvent), Is.True, "The blocking event should be available to read immediately.");
                Assert.That(events.SingleOrDefault(item => item.EventBody.ToString() == blockerEvent.EventBody.ToString()), Is.Null, $"The blocking event should not be in the source.");

                while (readEventCount < events.Length)
                {
                    if (partitionPublisher.TryReadEvent(out var readEvent))
                    {
                        ++readEventCount;

                        Assert.That(events.SingleOrDefault(item => item.EventBody.ToString() == readEvent.EventBody.ToString()), Is.Not.Null, $"The event with body: [{ readEvent.EventBody }] was not in the source.");
                        Assert.That(readEvent.GetRawAmqpMessage().GetPartitionKey(null), Is.Null, $"The partition key should not have been set for the event with body: [{ readEvent.EventBody }].");
                    }

                    await Task.Delay(10, cancellationSource.Token);
                }

                await enqueueTask;
                Assert.That(readEventCount, Is.EqualTo(events.Length), "The number of events read should match the source length.");
            }
            finally
            {
                await mockBufferedProducer.Object.CloseAsync(false).IgnoreExceptions();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventsAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task EnqueueEventsAsyncLogsTheOperationForAutomaticRouting()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "7";
            var events = new[] { new EventData("One"), new EventData("Two") };
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { partitionId });

            bufferedProducer.Logger = mockLogger.Object;
            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;

            try
            {
                await bufferedProducer.EnqueueEventsAsync(events, cancellationSource.Token);

                mockLogger
                    .Verify(log => log.BufferedProducerEventEnqueueStart(
                        mockProducer.Object.Identifier,
                        mockProducer.Object.EventHubName,
                        string.Empty,
                        It.IsAny<string>()),
                    Times.Once);

                mockLogger
                    .Verify(log => log.BufferedProducerEventEnqueueComplete(
                        mockProducer.Object.Identifier,
                        mockProducer.Object.EventHubName,
                        string.Empty,
                        It.IsAny<string>()),
                    Times.Once);

                mockLogger
                    .Verify(log => log.BufferedProducerEventEnqueued(
                        mockProducer.Object.Identifier,
                        mockProducer.Object.EventHubName,
                        string.Empty,
                        partitionId,
                        It.IsAny<string>(),
                        It.IsAny<int>()),
                    Times.Exactly(events.Length));
            }
            finally
            {
                await bufferedProducer.CloseAsync(false).IgnoreExceptions();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventsAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task EnqueueEventsAsyncLogsTheOperationForAPartitionKey()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "7";
            var events = new[] { new EventData("One"), new EventData("Two") };
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { partitionId });

            bufferedProducer.Logger = mockLogger.Object;
            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;

            try
            {
                var options = new EnqueueEventOptions { PartitionKey = "some-key" };
                await bufferedProducer.EnqueueEventsAsync(events, options, cancellationSource.Token);

                mockLogger
                    .Verify(log => log.BufferedProducerEventEnqueueStart(
                        mockProducer.Object.Identifier,
                        mockProducer.Object.EventHubName,
                        options.PartitionKey,
                        It.IsAny<string>()),
                    Times.Once);

                mockLogger
                    .Verify(log => log.BufferedProducerEventEnqueueComplete(
                        mockProducer.Object.Identifier,
                        mockProducer.Object.EventHubName,
                        options.PartitionKey,
                        It.IsAny<string>()),
                    Times.Once);

                mockLogger
                    .Verify(log => log.BufferedProducerEventEnqueued(
                        mockProducer.Object.Identifier,
                        mockProducer.Object.EventHubName,
                        options.PartitionKey,
                        partitionId,
                        It.IsAny<string>(),
                        It.IsAny<int>()),
                    Times.Exactly(events.Length));
            }
            finally
            {
                await bufferedProducer.CloseAsync(false).IgnoreExceptions();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventsAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task EnqueueEventsAsyncLogsTheOperationForAPartitionId()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "7";
            var events = new[] { new EventData("One"), new EventData("Two") };
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { partitionId });

            bufferedProducer.Logger = mockLogger.Object;
            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;

            try
            {
                var options = new EnqueueEventOptions { PartitionId = partitionId };
                await bufferedProducer.EnqueueEventsAsync(events, options, cancellationSource.Token);

                mockLogger
                    .Verify(log => log.BufferedProducerEventEnqueueStart(
                        mockProducer.Object.Identifier,
                        mockProducer.Object.EventHubName,
                        partitionId,
                        It.IsAny<string>()),
                    Times.Once);

                mockLogger
                    .Verify(log => log.BufferedProducerEventEnqueueComplete(
                        mockProducer.Object.Identifier,
                        mockProducer.Object.EventHubName,
                        partitionId,
                        It.IsAny<string>()),
                    Times.Once);

                mockLogger
                    .Verify(log => log.BufferedProducerEventEnqueued(
                        mockProducer.Object.Identifier,
                        mockProducer.Object.EventHubName,
                        options.PartitionId,
                        options.PartitionId,
                        It.IsAny<string>(),
                        It.IsAny<int>()),
                    Times.Exactly(events.Length));
            }
            finally
            {
                await bufferedProducer.CloseAsync(false).IgnoreExceptions();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventsAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task EnqueueEventsAsyncLogsAndSurfacesExceptions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "7";
            var expectedExceptionMessage = "OMG, It totally failed!";
            var expectedException = new DivideByZeroException(expectedExceptionMessage);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { partitionId });

            bufferedProducer.Logger = mockLogger.Object;
            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;

            IEnumerable<EventData> eventGenerator()
            {
                yield return new EventData("One");
                yield return new EventData("Two");
                throw expectedException;
            }

            try
            {
                var options = new EnqueueEventOptions { PartitionKey = "some-key" };
                Assert.That(async () => await bufferedProducer.EnqueueEventsAsync(eventGenerator(), options, cancellationSource.Token), Throws.InstanceOf(expectedException.GetType()), "An exception should have been surfaced.");

                mockLogger
                    .Verify(log => log.BufferedProducerEventEnqueueError(
                        mockProducer.Object.Identifier,
                        mockProducer.Object.EventHubName,
                        options.PartitionKey,
                        It.IsAny<string>(),
                        expectedExceptionMessage),
                    Times.Once);
            }
            finally
            {
                await bufferedProducer.CloseAsync(false).IgnoreExceptions();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventsAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task EnqueueEventsAsyncTracksTheBufferedEventCounts()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var firstPartitionId = "4";
            var secondPartitionId = "1";
            var events = new[] { new EventData("One"), new EventData("Two") };
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { firstPartitionId, secondPartitionId });

            mockBufferedProducer
                .Setup(producer => producer.PublishBatchToPartition(
                    It.IsAny<EventHubBufferedProducerClient.PartitionPublishingState>(),
                    It.IsAny<bool>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            mockBufferedProducer.Object.SendEventBatchFailedAsync += args => Task.CompletedTask;

            try
            {
                Assert.That(mockBufferedProducer.Object.TotalBufferedEventCount, Is.EqualTo(0), "No events have been enqueued yet.");

                var options = new EnqueueEventOptions { PartitionId = firstPartitionId };
                var count = await mockBufferedProducer.Object.EnqueueEventsAsync(new[] { new EventData("One") }, options, cancellationSource.Token);
                Assert.That(count, Is.EqualTo(1), "One event has been enqueued.");
                Assert.That(mockBufferedProducer.Object.GetBufferedEventCount(firstPartitionId), Is.EqualTo(1), $"One event has been enqueued for { firstPartitionId }.");
                Assert.That(mockBufferedProducer.Object.TotalBufferedEventCount, Is.EqualTo(count), "The count returned by enqueue and the total count should match.");

                options.PartitionId = secondPartitionId;
                count = await mockBufferedProducer.Object.EnqueueEventsAsync(new[] { new EventData("Two") }, options, cancellationSource.Token);
                Assert.That(count, Is.EqualTo(2), "Two events have been enqueued.");
                Assert.That(mockBufferedProducer.Object.GetBufferedEventCount(secondPartitionId), Is.EqualTo(1), $"One event has been enqueued for { secondPartitionId }.");
                Assert.That(mockBufferedProducer.Object.TotalBufferedEventCount, Is.EqualTo(count), "The count returned by enqueue and the total count should match.");

                options.PartitionId = secondPartitionId;
                count = await mockBufferedProducer.Object.EnqueueEventsAsync(new[] { new EventData("Three") }, options, cancellationSource.Token);
                Assert.That(count, Is.EqualTo(3), "Three events have been enqueued.");
                Assert.That(mockBufferedProducer.Object.GetBufferedEventCount(secondPartitionId), Is.EqualTo(2), $"Two events have been enqueued for { secondPartitionId }.");
                Assert.That(mockBufferedProducer.Object.TotalBufferedEventCount, Is.EqualTo(count), "The count returned by enqueue and the total count should match.");
            }
            finally
            {
                await mockBufferedProducer.Object.CloseAsync(false).IgnoreExceptions();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task EnqueueEventAsyncWithoutOptionsDelegatesToTheOptionsOverload()
        {
            using var cancellationSource = new CancellationTokenSource();

            var expectedEvent = new EventData("One");
            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockBufferedProducer
                .Setup(producer => producer.EnqueueEventAsync(It.IsAny<EventData>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(1));

            await mockBufferedProducer.Object.EnqueueEventAsync(expectedEvent, cancellationSource.Token);

            mockBufferedProducer
                .Verify(producer => producer.EnqueueEventAsync(expectedEvent, cancellationSource.Token),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventsAsync" />.
        /// </summary>
        ///
        [Test]
        public void EnqueueEventAsyncValidatesNotClosed()
        {
            using var cancellationSource = new CancellationTokenSource();

            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            bufferedProducer.IsClosed = true;
            Assert.That(async () => await bufferedProducer.EnqueueEventAsync(new EventData("Dummy"), cancellationSource.Token), Throws.InstanceOf<EventHubsException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventAsync" />.
        /// </summary>
        ///
        [Test]
        public void EnqueueEventAsyncValidatesEvents()
        {
            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;
            Assert.That(async () => await bufferedProducer.EnqueueEventAsync(null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventAsync" />.
        /// </summary>
        ///
        [Test]
        public void EnqueueEventAsyncValidatesOptions()
        {
            var invalidOptions = new EnqueueEventOptions { PartitionId = "1", PartitionKey = "key" };
            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;
            Assert.That(async () => await bufferedProducer.EnqueueEventAsync(new EventData("One"), invalidOptions), Throws.InstanceOf<InvalidOperationException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task EnqueueEventsAsyncValidatesThePartition()
        {
            var invalidOptions = new EnqueueEventOptions { PartitionId = "1" };
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { "0" });

            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;

            try
            {
                Assert.That(async () => await bufferedProducer.EnqueueEventAsync(new EventData("One"), invalidOptions), Throws.InstanceOf<InvalidOperationException>());
            }
            finally
            {
                await bufferedProducer.CloseAsync(false).IgnoreExceptions();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventAsync" />.
        /// </summary>
        ///
        [Test]
        public void EnqueueEventAsyncValidatesFailHandler()
        {
            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            Assert.That(async () => await bufferedProducer.EnqueueEventAsync(new EventData("One")), Throws.InstanceOf<InvalidOperationException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventAsync" />.
        /// </summary>
        ///
        [Test]
        public void EnqueueEventAsyncHonorsCancellation()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;
            Assert.That(async () => await bufferedProducer.EnqueueEventAsync(new EventData("One"), cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task EnqueueEventAsyncLocksHandlers()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { "0", "1" });

            Func<SendEventBatchSucceededEventArgs, Task> successHandler = args => Task.CompletedTask;
            Func<SendEventBatchFailedEventArgs, Task> failHandler = args => Task.CompletedTask;

            try
            {
                bufferedProducer.SendEventBatchSucceededAsync += successHandler;
                bufferedProducer.SendEventBatchFailedAsync += failHandler;

                await bufferedProducer.EnqueueEventAsync(new EventData("One"), cancellationSource.Token);

                Assert.That(() => bufferedProducer.SendEventBatchSucceededAsync -= successHandler, Throws.InstanceOf<InvalidOperationException>());
                Assert.That(() => bufferedProducer.SendEventBatchFailedAsync -= failHandler, Throws.InstanceOf<InvalidOperationException>());
            }
            finally
            {
                await bufferedProducer.CloseAsync(false).IgnoreExceptions();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task EnqueueEventAsyncStartsPublishing()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { "0", "1" });

            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;
            Assert.That(bufferedProducer.IsPublishing, Is.False, "Publishing should not start until an event is enqueued.");

            try
            {
                await bufferedProducer.EnqueueEventAsync(new EventData("One"), cancellationSource.Token);
                Assert.That(bufferedProducer.IsPublishing, Is.True, "Publishing should have started when the first event was enqueued.");
            }
            finally
            {
                await bufferedProducer.CloseAsync(false).IgnoreExceptions();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task EnqueueEventAsyncEnqueuesForAutomaticRouting()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "7";
            var partitions = new[] { partitionId };
            var expectedEvent = new EventData("One");
            var mockPartitionResolver = new Mock<PartitionResolver>();
            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockPartitionResolver
                .Setup(resolver => resolver.AssignRoundRobin(It.IsAny<string[]>()))
                .Returns(partitionId);

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitions);

            mockBufferedProducer
                .Setup(producer => producer.PublishBatchToPartition(
                    It.IsAny<EventHubBufferedProducerClient.PartitionPublishingState>(),
                    It.IsAny<bool>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            mockBufferedProducer.Object.PartitionResolver = mockPartitionResolver.Object;
            mockBufferedProducer.Object.SendEventBatchFailedAsync += args => Task.CompletedTask;

            try
            {
                var enqueuedCount = await mockBufferedProducer.Object.EnqueueEventAsync(expectedEvent, cancellationSource.Token);
                Assert.That(mockBufferedProducer.Object.ActivePartitionStateMap.TryGetValue(partitionId, out var partitionPublisher), Is.True, "A publisher should have been registered for the partition.");

                Assert.That(enqueuedCount, Is.EqualTo(1), "The return value should indicate that a single event was enqueued.");
                Assert.That(mockBufferedProducer.Object.TotalBufferedEventCount, Is.EqualTo(1), "The total event count should indicate that a single event was enqueued.");
                Assert.That(mockBufferedProducer.Object.GetBufferedEventCount(partitionId), Is.EqualTo(1), "The partition event count should indicate that a single event was enqueued.");

                var readEventCount = 0;

                while (readEventCount < 1)
                {
                    if (partitionPublisher.TryReadEvent(out var readEvent))
                    {
                        ++readEventCount;

                        Assert.That(expectedEvent.EventBody.ToString(), Is.EqualTo(readEvent.EventBody.ToString()), $"The event with body: [{ readEvent.EventBody }] was not enqueued.");
                        Assert.That(readEvent.GetRawAmqpMessage().GetPartitionKey(null), Is.Null, $"The partition key should not have been set for the event with body: [{ readEvent.EventBody }].");
                    }

                    await Task.Delay(10, cancellationSource.Token);
                }

                Assert.That(readEventCount, Is.EqualTo(1), "A single event should have been enqueued.");
            }
            finally
            {
                await mockBufferedProducer.Object.CloseAsync(false).IgnoreExceptions();
            }

            mockPartitionResolver
                .Verify(resolver => resolver.AssignRoundRobin(partitions), Times.Once);

            mockPartitionResolver
                .Verify(resolver => resolver.AssignForPartitionKey(
                    It.IsAny<string>(),
                    It.IsAny<string[]>()),
                Times.Never);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task EnqueueEventAsyncEnqueuesWithAPartitionKey()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "3";
            var partitions = new[] { partitionId };
            var partitionKey = "test-key";
            var expectedEvent = new EventData("One");
            var mockPartitionResolver = new Mock<PartitionResolver>();
            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockPartitionResolver
                .Setup(resolver => resolver.AssignForPartitionKey(It.IsAny<string>(), It.IsAny<string[]>()))
                .Returns(partitionId);

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(partitions);

            mockBufferedProducer
                .Setup(producer => producer.PublishBatchToPartition(
                    It.IsAny<EventHubBufferedProducerClient.PartitionPublishingState>(),
                    It.IsAny<bool>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            mockBufferedProducer.Object.PartitionResolver = mockPartitionResolver.Object;
            mockBufferedProducer.Object.SendEventBatchFailedAsync += args => Task.CompletedTask;

            try
            {
                var options = new EnqueueEventOptions { PartitionKey = partitionKey };
                var enqueuedCount = await mockBufferedProducer.Object.EnqueueEventAsync(expectedEvent, options, cancellationSource.Token);

                Assert.That(mockBufferedProducer.Object.ActivePartitionStateMap.TryGetValue(partitionId, out var partitionPublisher), Is.True, "A publisher should have been registered for the partition.");
                Assert.That(enqueuedCount, Is.EqualTo(1), "The return value should indicate that a single event was enqueued.");
                Assert.That(mockBufferedProducer.Object.TotalBufferedEventCount, Is.EqualTo(1), "The total event count should indicate that a single event was enqueued.");
                Assert.That(mockBufferedProducer.Object.GetBufferedEventCount(partitionId), Is.EqualTo(1), "The partition event count should indicate that a single event was enqueued.");

                var readEventCount = 0;

                while (readEventCount < 1)
                {
                    if (partitionPublisher.TryReadEvent(out var readEvent))
                    {
                        ++readEventCount;

                        Assert.That(expectedEvent.EventBody.ToString(), Is.EqualTo(readEvent.EventBody.ToString()), $"The event with body: [{ readEvent.EventBody }] was not enqueued.");
                        Assert.That(readEvent.GetRawAmqpMessage().GetPartitionKey(null), Is.EqualTo(partitionKey), $"The partition key should have been preserved for the event with body: [{ readEvent.EventBody }].");
                    }

                    await Task.Delay(10, cancellationSource.Token);
                }

                Assert.That(readEventCount, Is.EqualTo(1), "A single event should have been enqueued.");
            }
            finally
            {
                await mockBufferedProducer.Object.CloseAsync(false).IgnoreExceptions();
            }

            mockPartitionResolver
                .Verify(resolver => resolver.AssignRoundRobin(It.IsAny<string[]>()), Times.Never);

            mockPartitionResolver
                .Verify(resolver => resolver.AssignForPartitionKey(partitionKey, partitions), Times.Once);
        }

         /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task EnqueueEventAsyncEnqueuesWithAPartitionAssignment()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "2";
            var expectedEvent = new EventData("One");
            var mockPartitionResolver = new Mock<PartitionResolver>();
            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { "0", partitionId, "1" });

            mockBufferedProducer
                .Setup(producer => producer.PublishBatchToPartition(
                    It.IsAny<EventHubBufferedProducerClient.PartitionPublishingState>(),
                    It.IsAny<bool>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            mockBufferedProducer.Object.PartitionResolver = mockPartitionResolver.Object;
            mockBufferedProducer.Object.SendEventBatchFailedAsync += args => Task.CompletedTask;

            try
            {
                var options = new EnqueueEventOptions { PartitionId = partitionId };
                var enqueuedCount = await mockBufferedProducer.Object.EnqueueEventAsync(expectedEvent, options, cancellationSource.Token);

                Assert.That(mockBufferedProducer.Object.ActivePartitionStateMap.TryGetValue(partitionId, out var partitionPublisher), Is.True, "A publisher should have been registered for the partition.");
                Assert.That(enqueuedCount, Is.EqualTo(1), "The return value should indicate that a single event was enqueued.");
                Assert.That(mockBufferedProducer.Object.TotalBufferedEventCount, Is.EqualTo(1), "The total event count should indicate that a single event was enqueued.");
                Assert.That(mockBufferedProducer.Object.GetBufferedEventCount(partitionId), Is.EqualTo(1), "The partition event count should indicate that a single event was enqueued.");

                var readEventCount = 0;

                while (readEventCount < 1)
                {
                    if (partitionPublisher.TryReadEvent(out var readEvent))
                    {
                        ++readEventCount;

                        Assert.That(expectedEvent.EventBody.ToString(), Is.EqualTo(readEvent.EventBody.ToString()), $"The event with body: [{ readEvent.EventBody }] was not enqueued.");
                        Assert.That(readEvent.GetRawAmqpMessage().GetPartitionKey(null), Is.Null, $"The partition key should not have been set for the event with body: [{ readEvent.EventBody }].");
                    }

                    await Task.Delay(10, cancellationSource.Token);
                }

                Assert.That(readEventCount, Is.EqualTo(1), "A single event should have been enqueued.");
            }
            finally
            {
                await mockBufferedProducer.Object.CloseAsync(false).IgnoreExceptions();
            }

            mockPartitionResolver
                .Verify(resolver => resolver.AssignRoundRobin(It.IsAny<string[]>()), Times.Never);

            mockPartitionResolver
                .Verify(resolver => resolver.AssignForPartitionKey(
                    It.IsAny<string>(),
                    It.IsAny<string[]>()),
                Times.Never);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task EnqueueEventAsyncWaitsWhenFull()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "4";
            var blockerEvent = new EventData("Blocker");
            var expectedEvent = new EventData("One");
            var options = new EventHubBufferedProducerClientOptions { MaximumEventBufferLengthPerPartition = 1 };
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducerOptions = new EventHubBufferedProducerClientOptions { MaximumEventBufferLengthPerPartition = 1 };
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, bufferedProducerOptions) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { partitionId });

            mockBufferedProducer
                .Setup(producer => producer.PublishBatchToPartition(
                    It.IsAny<EventHubBufferedProducerClient.PartitionPublishingState>(),
                    It.IsAny<bool>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            mockBufferedProducer.Object.SendEventBatchFailedAsync += args => Task.CompletedTask;

            try
            {
                // This enqueue will cause the channel to be considered full and block additional enqueues.

                await mockBufferedProducer.Object.EnqueueEventAsync(blockerEvent, cancellationSource.Token);

                // Start the task to enqueue events, then delay and ensure that it is still not completed.

                var enqueueTask = mockBufferedProducer.Object.EnqueueEventAsync(expectedEvent, cancellationSource.Token);
                await Task.Delay(TimeSpan.FromSeconds(1), cancellationSource.Token);

                Assert.That(enqueueTask.IsCompleted, Is.False, "The enqueue task should not be completed.");
                Assert.That(mockBufferedProducer.Object.ActivePartitionStateMap.TryGetValue(partitionId, out var partitionPublisher), Is.True, "A publisher should have been registered for the partition.");

                // Read the blocking event to clear room.  This event shouldn't be in the expected list.

                Assert.That(partitionPublisher.TryReadEvent(out var readBlockerEvent), Is.True, "The blocking event should be available to read immediately.");
                Assert.That(blockerEvent.EventBody.ToString(), Is.EqualTo(readBlockerEvent.EventBody.ToString()), $"The event with body: [{ readBlockerEvent.EventBody }] was not enqueued.");

                var readEventCount = 0;

                while (readEventCount < 1)
                {
                    if (partitionPublisher.TryReadEvent(out var readEvent))
                    {
                        ++readEventCount;

                        Assert.That(expectedEvent.EventBody.ToString(), Is.EqualTo(readEvent.EventBody.ToString()), $"The event with body: [{ readEvent.EventBody }] was not enqueued.");
                        Assert.That(readEvent.GetRawAmqpMessage().GetPartitionKey(null), Is.Null, $"The partition key should not have been set for the event with body: [{ readEvent.EventBody }].");
                    }

                    await Task.Delay(10, cancellationSource.Token);
                }

                Assert.That(readEventCount, Is.EqualTo(1), "An event should have been available to read.");

                await enqueueTask;
                Assert.That(partitionPublisher.TryReadEvent(out _), Is.False, "Other than the blocker, a single event should have been enqueued.");
            }
            finally
            {
                await mockBufferedProducer.Object.CloseAsync(false).IgnoreExceptions();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task EnqueueEventAsyncLogsTheOperationForAutomaticRouting()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "7";
            var expectedEvent = new EventData("One");
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { partitionId });

            bufferedProducer.Logger = mockLogger.Object;
            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;

            try
            {
                await bufferedProducer.EnqueueEventAsync(expectedEvent, cancellationSource.Token);

                mockLogger
                    .Verify(log => log.BufferedProducerEventEnqueueStart(
                        mockProducer.Object.Identifier,
                        mockProducer.Object.EventHubName,
                        string.Empty,
                        It.IsAny<string>()),
                    Times.Once);

                mockLogger
                    .Verify(log => log.BufferedProducerEventEnqueueComplete(
                        mockProducer.Object.Identifier,
                        mockProducer.Object.EventHubName,
                        string.Empty,
                        It.IsAny<string>()),
                    Times.Once);

                mockLogger
                    .Verify(log => log.BufferedProducerEventEnqueued(
                        mockProducer.Object.Identifier,
                        mockProducer.Object.EventHubName,
                        string.Empty,
                        partitionId,
                        It.IsAny<string>(),
                        It.IsAny<int>()),
                    Times.Once);
            }
            finally
            {
                await bufferedProducer.CloseAsync(false).IgnoreExceptions();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task EnqueueEventAsyncLogsTheOperationForAPartitionKey()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "7";
            var expectedEvent = new EventData("One");
            var mockLogger = new Mock<EventHubsEventSource>();
            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { partitionId });

            bufferedProducer.Logger = mockLogger.Object;
            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;

            try
            {
                var options = new EnqueueEventOptions { PartitionKey = "some-key" };
                await bufferedProducer.EnqueueEventAsync(expectedEvent, options, cancellationSource.Token);

                mockLogger
                    .Verify(log => log.BufferedProducerEventEnqueueStart(
                        mockProducer.Object.Identifier,
                        mockProducer.Object.EventHubName,
                        options.PartitionKey,
                        It.IsAny<string>()),
                    Times.Once);

                mockLogger
                    .Verify(log => log.BufferedProducerEventEnqueueComplete(
                        mockProducer.Object.Identifier,
                        mockProducer.Object.EventHubName,
                        options.PartitionKey,
                        It.IsAny<string>()),
                    Times.Once);

                mockLogger
                    .Verify(log => log.BufferedProducerEventEnqueued(
                        mockProducer.Object.Identifier,
                        mockProducer.Object.EventHubName,
                        options.PartitionKey,
                        partitionId,
                        It.IsAny<string>(),
                        It.IsAny<int>()),
                    Times.Once);
            }
            finally
            {
                await bufferedProducer.CloseAsync(false).IgnoreExceptions();
            }
        }

         /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task EnqueueEventAsyncLogsTheOperationForAPartitionId()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "7";
            var expectedEvent = new EventData("One");
            var mockLogger = new Mock<EventHubsEventSource>();
            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { partitionId });

            bufferedProducer.Logger = mockLogger.Object;
            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;

            try
            {
                var options = new EnqueueEventOptions { PartitionId = partitionId };
                await bufferedProducer.EnqueueEventAsync(expectedEvent, options, cancellationSource.Token);

                mockLogger
                    .Verify(log => log.BufferedProducerEventEnqueueStart(
                        mockProducer.Object.Identifier,
                        mockProducer.Object.EventHubName,
                        partitionId,
                        It.IsAny<string>()),
                    Times.Once);

                mockLogger
                    .Verify(log => log.BufferedProducerEventEnqueueComplete(
                        mockProducer.Object.Identifier,
                        mockProducer.Object.EventHubName,
                        partitionId,
                        It.IsAny<string>()),
                    Times.Once);

                mockLogger
                    .Verify(log => log.BufferedProducerEventEnqueued(
                        mockProducer.Object.Identifier,
                        mockProducer.Object.EventHubName,
                        options.PartitionId,
                        options.PartitionId,
                        It.IsAny<string>(),
                        It.IsAny<int>()),
                    Times.Once);
            }
            finally
            {
                await bufferedProducer.CloseAsync(false).IgnoreExceptions();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task EnqueueEventAsyncLogsAndSurfacesExceptions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "7";
            var expectedExceptionMessage = "The channel has been closed.";
            var mockLogger = new Mock<EventHubsEventSource>();
            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { partitionId });

            bufferedProducer.Logger = mockLogger.Object;
            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;

            try
            {
                // Create the partition publisher for the lone partition and close it's writer.  This
                // will result in a ChannelClosedException("The channel has been closed.") when the
                // enqueue takes place.

                var partitionPublisher = new EventHubBufferedProducerClient.PartitionPublishingState(partitionId, new EventHubBufferedProducerClientOptions());
                partitionPublisher.PendingEventsWriter.TryComplete();

                bufferedProducer.ActivePartitionStateMap[partitionId] = partitionPublisher;

                var options = new EnqueueEventOptions { PartitionKey = "some-key" };
                Assert.That(async () => await bufferedProducer.EnqueueEventAsync(new EventData("Two"), options, cancellationSource.Token), Throws.InstanceOf<ChannelClosedException>(), "An exception should have been surfaced.");

                mockLogger
                    .Verify(log => log.BufferedProducerEventEnqueueError(
                        mockProducer.Object.Identifier,
                        mockProducer.Object.EventHubName,
                        options.PartitionKey,
                        It.IsAny<string>(),
                        expectedExceptionMessage),
                    Times.Once);
            }
            finally
            {
                await bufferedProducer.CloseAsync(false).IgnoreExceptions();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventAsync" />.
        /// </summary>
        ///
        [Test]
        public async Task EnqueueEventAsyncTracksTheBufferedEventCounts()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var firstPartitionId = "4";
            var secondPartitionId = "1";
            var events = new[] { new EventData("One"), new EventData("Two") };
            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { firstPartitionId, secondPartitionId });

            mockBufferedProducer
                .Setup(producer => producer.PublishBatchToPartition(
                    It.IsAny<EventHubBufferedProducerClient.PartitionPublishingState>(),
                    It.IsAny<bool>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            mockBufferedProducer.Object.SendEventBatchFailedAsync += args => Task.CompletedTask;

            try
            {
                Assert.That(mockBufferedProducer.Object.TotalBufferedEventCount, Is.EqualTo(0), "No events have been enqueued yet.");

                var options = new EnqueueEventOptions { PartitionId = firstPartitionId };
                var count = await mockBufferedProducer.Object.EnqueueEventAsync(new EventData("One"), options, cancellationSource.Token);
                Assert.That(count, Is.EqualTo(1), "One event has been enqueued.");
                Assert.That(mockBufferedProducer.Object.GetBufferedEventCount(firstPartitionId), Is.EqualTo(1), $"One event has been enqueued for { firstPartitionId }.");
                Assert.That(mockBufferedProducer.Object.TotalBufferedEventCount, Is.EqualTo(count), "The count returned by enqueue and the total count should match.");

                options.PartitionId = secondPartitionId;
                count = await mockBufferedProducer.Object.EnqueueEventAsync(new EventData("Two"), options, cancellationSource.Token);
                Assert.That(count, Is.EqualTo(2), "Two events have been enqueued.");
                Assert.That(mockBufferedProducer.Object.GetBufferedEventCount(secondPartitionId), Is.EqualTo(1), $"One event has been enqueued for { secondPartitionId }.");
                Assert.That(mockBufferedProducer.Object.TotalBufferedEventCount, Is.EqualTo(count), "The count returned by enqueue and the total count should match.");

                options.PartitionId = secondPartitionId;
                count = await mockBufferedProducer.Object.EnqueueEventAsync(new EventData("Three"), options, cancellationSource.Token);
                Assert.That(count, Is.EqualTo(3), "Three events have been enqueued.");
                Assert.That(mockBufferedProducer.Object.GetBufferedEventCount(secondPartitionId), Is.EqualTo(2), $"Two events have been enqueued for { secondPartitionId }.");
                Assert.That(mockBufferedProducer.Object.TotalBufferedEventCount, Is.EqualTo(count), "The count returned by enqueue and the total count should match.");
            }
            finally
            {
                await mockBufferedProducer.Object.CloseAsync(false).IgnoreExceptions();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.GetBufferedEventCount" />.
        /// </summary>
        ///
        [Test]
        public void GetBufferedEventCountValidatesNotClosed()
        {
            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            bufferedProducer.IsClosed = true;
            Assert.That(() => bufferedProducer.GetBufferedEventCount("0"), Throws.InstanceOf<EventHubsException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.GetBufferedEventCount" />.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void GetBufferedEventCountValidatesThePartitionId(string partitionId)
        {
            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            Assert.That(() => bufferedProducer.GetBufferedEventCount(partitionId), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundManagementTaskInitializesAndRefreshesThePartitions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionRequsts = 0;
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { "0", "1" })
                .Callback(() =>
                {
                   if (++partitionRequsts >= 2)
                   {
                       completionSource.TrySetResult(true);
                   }
                });

            // Set a short background interval to ensure a multiple ticks so that partitions are initialized and
            // refreshed at least once.

            mockBufferedProducer.Object.BackgroundManagementInterval = TimeSpan.FromMilliseconds(25);

            try
            {
                await InvokeStartPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token);
                await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);
            }
            finally
            {
                await InvokeStopPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token).IgnoreExceptions();
            }

            // Because timing is non-deterministic, the exact number of calls cannot be known.  Ensure that at least
            // the initialization and one refresh happened.

            mockProducer
                .Verify(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()),
                Times.AtLeast(2));
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundManagementTaskHonorsItsInterval()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedInterval = TimeSpan.FromMilliseconds(250);
            var expectedPartitionRequests = 3;
            var partitionRequsts = 0;
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { "0", "1" })
                .Callback(() =>
                {
                   if (++partitionRequsts >= 2)
                   {
                       completionSource.TrySetResult(true);
                   }
                });

            // Set a short background interval to ensure that it runs multiple times.

            mockBufferedProducer.Object.BackgroundManagementInterval = expectedInterval;

            try
            {
                await InvokeStartPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token);

                // Await the second call to get partition information, so that it is known the management task
                // is running.  After, wait for a few iterations, ensuring some extra padding to account for imprecise timing.

                await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);
                await Task.Delay(TimeSpan.FromMilliseconds(expectedInterval.TotalMilliseconds * (expectedPartitionRequests + 2)), cancellationSource.Token);
            }
            finally
            {
                await InvokeStopPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token).IgnoreExceptions();
            }

            // The first call will be in StartPublishingAsync, the rest will be part of the management loop.

            mockProducer
                .Verify(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()),
                Times.AtLeast(expectedPartitionRequests));
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundManagementTaskStartsThePublishingTaskAndLogs()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedInterval = TimeSpan.FromMilliseconds(250);
            var partitionRequsts = 0;
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

           mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { "0", "1" })
                .Callback(() =>
                {
                   if (++partitionRequsts >= 2)
                   {
                       completionSource.TrySetResult(true);
                   }
                });

             mockBufferedProducer.Object.Logger = mockLogger.Object;
             mockBufferedProducer.Object.BackgroundManagementInterval = expectedInterval;

            try
            {
                await InvokeStartPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token);
                await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);

                Assert.That(GetBackgroundPublishingTask(mockBufferedProducer.Object), Is.Not.Null, "The publishing task should have been started.");
            }
            finally
            {
                await InvokeStopPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token).IgnoreExceptions();
            }

            mockLogger
              .Verify(log => log.BufferedProducerPublishingTaskInitialStart(
                  mockBufferedProducer.Object.Identifier,
                  mockBufferedProducer.Object.EventHubName),
              Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundManagementTaskDetectsPublishingTaskFailuresAndLogs()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedErrorMessage = "This is an error that we expect.";
            var initialCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var faultCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { "0", "1" });

            mockLogger
              .Setup(log => log.BufferedProducerPublishingTaskInitialStart(It.IsAny<string>(), It.IsAny<string>()))
              .Callback(() => initialCompletionSource.TrySetResult(true));

            mockLogger
                .Setup(log => log.BufferedProducerPublishingTaskError(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Callback(() => faultCompletionSource.TrySetResult(true));

             mockBufferedProducer.Object.Logger = mockLogger.Object;
             mockBufferedProducer.Object.BackgroundManagementInterval = TimeSpan.FromMilliseconds(250);

            try
            {
                await InvokeStartPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token);
                await initialCompletionSource.Task.AwaitWithCancellation(cancellationSource.Token);

                SetBackgroundPublishingTask(mockBufferedProducer.Object, Task.FromException(new DivideByZeroException(expectedErrorMessage)));
                await faultCompletionSource.Task.AwaitWithCancellation(cancellationSource.Token);
            }
            finally
            {
                await InvokeStopPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token).IgnoreExceptions();
            }

            // Since the exact timing of the background loop is unknown,
            // the faulted task may still be set when publishing is stopped.
            // Allow for one or two log invocations, in case the task is not
            // reset before the shutdown sequence.

            mockLogger
              .Verify(log => log.BufferedProducerPublishingTaskError(
                  mockBufferedProducer.Object.Identifier,
                  mockBufferedProducer.Object.EventHubName,
                  expectedErrorMessage),
              Times.Between(1, 2, Moq.Range.Inclusive));
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundManagementTaskRestartsThePublishingTaskAfterFailuresAndLogs()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var faultInjected = false;
            var initialCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var restartedCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { "0", "1" });

            mockLogger
              .Setup(log => log.BufferedProducerPublishingTaskInitialStart(It.IsAny<string>(), It.IsAny<string>()))
              .Callback(() => initialCompletionSource.TrySetResult(true));

            mockLogger
                .Setup(log => log.BufferedProducerPublishingTaskError(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Callback(() => faultInjected = true);

            mockLogger
                .Setup(log => log.BufferedProducerPublishingTaskRestart(It.IsAny<string>(), It.IsAny<string>()))
                .Callback(() =>
                {
                    if (faultInjected)
                    {
                        restartedCompletionSource.TrySetResult(true);
                    }
                });

             mockBufferedProducer.Object.Logger = mockLogger.Object;
             mockBufferedProducer.Object.BackgroundManagementInterval = TimeSpan.FromMilliseconds(250);

            try
            {
                await InvokeStartPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token);
                await initialCompletionSource.Task.AwaitWithCancellation(cancellationSource.Token);

                var faultedTask = Task.FromException(new DivideByZeroException());
                SetBackgroundPublishingTask(mockBufferedProducer.Object, faultedTask);

                await restartedCompletionSource.Task.AwaitWithCancellation(cancellationSource.Token);
                Assert.That(GetBackgroundPublishingTask(mockBufferedProducer.Object), Is.Not.SameAs(faultedTask), "The faulted task should have been replaced on restart.");
            }
            finally
            {
                await InvokeStopPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token).IgnoreExceptions();
            }

            // Since the exact timing of the background loop is unknown,
            // the faulted task may still be set when publishing is stopped.
            // Allow for one or two log invocations, in case the task is not
            // reset before the shutdown sequence.

            mockLogger
              .Verify(log => log.BufferedProducerPublishingTaskRestart(
                  mockBufferedProducer.Object.Identifier,
                  mockBufferedProducer.Object.EventHubName),
              Times.AtLeastOnce);
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundManagementTaskLogsFailures()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionRequsts = 0;
            var expectedErrorMessage = "This is an error that we expect.";
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Callback(() =>
                {
                   if (++partitionRequsts >= 2)
                   {
                       completionSource.TrySetResult(true);
                   }
                })
                .Returns(() =>
                {
                    if (partitionRequsts < 2)
                    {
                        return Task.FromResult(new[] { "0", "1" });
                    }

                    throw new FormatException(expectedErrorMessage);
                });

            mockBufferedProducer.Object.Logger = mockLogger.Object;
            mockBufferedProducer.Object.BackgroundManagementInterval = TimeSpan.FromMilliseconds(250);

            try
            {
                await InvokeStartPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token);
                await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);
            }
            finally
            {
                await InvokeStopPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token).IgnoreExceptions();
            }

            // Since the exact number of iterations performed is unknown,
            // validate that the error was observed as least once.

            mockLogger
                .Verify(log => log.BufferedProducerManagementTaskError(
                    mockBufferedProducer.Object.Identifier,
                    mockBufferedProducer.Object.EventHubName,
                    expectedErrorMessage),
                Times.AtLeastOnce);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsBufferedProducerClient.PartitionPublishingState" />
        ///   internal abstraction.
        /// </summary>
        ///
        [Test]
        public async Task PartitionPublishingStateReadsFromTheChannel()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partition = "7";
            var options = new EventHubBufferedProducerClientOptions();
            var expectedEvents = EventGenerator.CreateSmallEvents(25).ToList();

            using var publishingState = new EventHubBufferedProducerClient.PartitionPublishingState(partition, options);

            // Write to the channel.

            foreach (var writeEvent in expectedEvents)
            {
                await publishingState.PendingEventsWriter.WriteAsync(writeEvent, cancellationSource.Token);
            }

            // Read events and validate.

            var readEvents = new List<EventData>(expectedEvents.Count);

            while (publishingState.TryReadEvent(out var readEvent))
            {
                readEvents.Add(readEvent);
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
            Assert.That(readEvents.Count, Is.EqualTo(expectedEvents.Count), "The number of events read should match.");
            Assert.That(readEvents, Is.EquivalentTo(expectedEvents), "Events that were buffered should have been read back.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsBufferedProducerClient.PartitionPublishingState" />
        ///   internal abstraction.
        /// </summary>
        ///
        [Test]
        public void PartitionPublishingStateReadsFromTheStash()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partition = "7";
            var options = new EventHubBufferedProducerClientOptions();
            var expectedEvents = EventGenerator.CreateSmallEvents(10).ToList();

            using var publishingState = new EventHubBufferedProducerClient.PartitionPublishingState(partition, options);

            // Write to the stash.

            foreach (var writeEvent in expectedEvents)
            {
                publishingState.StashEvent(writeEvent);
            }

            // Read events and validate.

            var readEvents = new List<EventData>(expectedEvents.Count);

            while (publishingState.TryReadEvent(out var readEvent))
            {
                readEvents.Add(readEvent);
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
            Assert.That(readEvents.Count, Is.EqualTo(expectedEvents.Count), "The number of events read should match.");
            Assert.That(readEvents, Is.EquivalentTo(expectedEvents), "The read events should match the written events.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubsBufferedProducerClient.PartitionPublishingState" />
        ///   internal abstraction.
        /// </summary>
        ///
        [Test]
        public async Task PartitionPublishingStatePrefersTheStash()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partition = "7";
            var options = new EventHubBufferedProducerClientOptions();
            var sourceEvents = EventGenerator.CreateSmallEvents(25).ToList();
            var stashEvents = new List<EventData>();
            var channelEvents = new List<EventData>();

            using var publishingState = new EventHubBufferedProducerClient.PartitionPublishingState(partition, options);

            // Randomize the event order.

            var stash = true;

            foreach (var sourceEvent in sourceEvents)
            {
                if (stash)
                {
                    stashEvents.Add(sourceEvent);
                }
                else
                {
                    channelEvents.Add(sourceEvent);
                }

                stash = !stash;
            }

            // Write to the channel.

            foreach (var writeEvent in channelEvents)
            {
                await publishingState.PendingEventsWriter.WriteAsync(writeEvent, cancellationSource.Token);
            }

            // Write to the stash.

            foreach (var writeEvent in stashEvents)
            {
                publishingState.StashEvent(writeEvent);
            }

            // Read events and validate.

            var readEventCount = 0;

            while (publishingState.TryReadEvent(out var readEvent))
            {
                ++readEventCount;

                if (readEventCount <= stashEvents.Count)
                {
                    Assert.That(stashEvents.SingleOrDefault(item => item.EventBody.ToString() == readEvent.EventBody.ToString()), Is.Not.Null, $"The event with body: [{ readEvent.EventBody }] was not in the stash.");
                }
                else
                {
                    Assert.That(channelEvents.SingleOrDefault(item => item.EventBody.ToString() == readEvent.EventBody.ToString()), Is.Not.Null, $"The event with body: [{ readEvent.EventBody }] was not in the channel.");
                }

                cancellationSource.Token.ThrowIfCancellationRequested();
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
            Assert.That(readEventCount, Is.EqualTo(stashEvents.Count + channelEvents.Count), "The number of events read should match the source length.");
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task PublishBatchToPartitionPublishesEvents()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var publishedEventsCount = 0;
            var expectedPartition = "4";
            var extraEvent = EventGenerator.CreateSmallEvents(1).First();
            var expectedEvents = EventGenerator.CreateSmallEvents(10).ToList();
            var publishedEvents = new List<EventData>();
            var options = new EventHubBufferedProducerClientOptions { MaximumWaitTime = EventHubsTestEnvironment.Instance.TestExecutionTimeLimit };
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { expectedPartition, "6" });

            mockProducer
                .Setup(producer => producer.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns<CreateBatchOptions, CancellationToken>((options, token) => new ValueTask<EventDataBatch>(EventHubsModelFactory.EventDataBatch(1_048_576, publishedEvents, options, _ => publishedEvents.Count < expectedEvents.Count)));

            mockProducer
                .Setup(producer => producer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Callback<EventDataBatch, CancellationToken>((batch, token) => publishedEventsCount = batch.Count)
                .Returns(Task.CompletedTask);

            // Enqueue the events that are expected to be returned.

            foreach (var eventData in expectedEvents)
            {
                await partitionState.PendingEventsWriter.WriteAsync(eventData, cancellationSource.Token);
                partitionState.BufferedEventCount += 1;
            }

            // Enqueue the extra events that will trigger the batch being considered as full.

            await partitionState.PendingEventsWriter.WriteAsync(extraEvent, cancellationSource.Token);
            partitionState.BufferedEventCount += 1;

            // Publish and verify.

            await mockBufferedProducer.Object.PublishBatchToPartition(partitionState, false, cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
            Assert.That(partitionState.BufferedEventCount, Is.EqualTo(1), "The buffered event count for the partition should have been decremented, but the extra event should remain.");
            Assert.That(publishedEventsCount, Is.EqualTo(expectedEvents.Count), "The number of events published should match.");

            // Adding to the batch results in cloning the events; the data should match but the
            // reference will differ.

            for (var index = 0; index < publishedEvents.Count; ++index)
            {
                Assert.That(publishedEvents[index].IsEquivalentTo(expectedEvents[index]), Is.True, $"The event at index: [{ index }] did not match the expected event.");
            }

            mockProducer
                .Verify(producer => producer.SendAsync(
                    It.Is<EventDataBatch>(value => value.SendOptions.PartitionId == expectedPartition),
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task PublishBatchToPartitionPublishesEventsWithNoWaitTime()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var publishedEventsCount = 0;
            var expectedPartition = "4";
            var extraEvent = EventGenerator.CreateSmallEvents(1).First();
            var expectedEvents = EventGenerator.CreateSmallEvents(10).ToList();
            var publishedEvents = new List<EventData>();
            var options = new EventHubBufferedProducerClientOptions { MaximumWaitTime = null };
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { expectedPartition, "6" });

            mockProducer
                .Setup(producer => producer.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns<CreateBatchOptions, CancellationToken>((options, token) => new ValueTask<EventDataBatch>(EventHubsModelFactory.EventDataBatch(1_048_576, publishedEvents, options, _ => publishedEvents.Count < expectedEvents.Count)));

            mockProducer
                .Setup(producer => producer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Callback<EventDataBatch, CancellationToken>((batch, token) => publishedEventsCount = batch.Count)
                .Returns(Task.CompletedTask);

            // Start the publishing task; it should wait for a full batch before completing.

            var publishingTask = mockBufferedProducer.Object.PublishBatchToPartition(partitionState, false, cancellationSource.Token);

            // Enqueue the events that are expected to be returned with a small delay between them.

            foreach (var eventData in expectedEvents)
            {
                await partitionState.PendingEventsWriter.WriteAsync(eventData, cancellationSource.Token);
                partitionState.BufferedEventCount += 1;

                await Task.Delay(25);
            }

            // Enqueue the extra events that will trigger the batch being considered as full.

            await partitionState.PendingEventsWriter.WriteAsync(extraEvent, cancellationSource.Token);
            partitionState.BufferedEventCount += 1;

            // The extra event should cause publishing to happen; wait for the task to complete and verify.

            await publishingTask;

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
            Assert.That(partitionState.BufferedEventCount, Is.EqualTo(1), "The buffered event count for the partition should have been decremented, but the extra event should remain.");
            Assert.That(publishedEventsCount, Is.EqualTo(expectedEvents.Count), "The number of events published should match.");

            // Adding to the batch results in cloning the events; the data should match but the
            // reference will differ.

            for (var index = 0; index < publishedEvents.Count; ++index)
            {
                Assert.That(publishedEvents[index].IsEquivalentTo(expectedEvents[index]), Is.True, $"The event at index: [{ index }] did not match the expected event.");
            }

            mockProducer
                .Verify(producer => producer.SendAsync(
                    It.Is<EventDataBatch>(value => value.SendOptions.PartitionId == expectedPartition),
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task PublishBatchToPartitionRespectsTheWaitTime()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var publishedEventsCount = 0;
            var expectedPartition = "4";
            var extraEvent = EventGenerator.CreateSmallEvents(1).First();
            var expectedEvents = EventGenerator.CreateSmallEvents(10).ToList();
            var publishedEvents = new List<EventData>();
            var options = new EventHubBufferedProducerClientOptions { MaximumWaitTime = TimeSpan.FromMilliseconds(350) };
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { expectedPartition, "6" });

            mockProducer
                .Setup(producer => producer.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns<CreateBatchOptions, CancellationToken>((options, token) => new ValueTask<EventDataBatch>(EventHubsModelFactory.EventDataBatch(1_048_576, publishedEvents, options, _ => true)));

            mockProducer
                .Setup(producer => producer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Callback<EventDataBatch, CancellationToken>((batch, token) => publishedEventsCount = batch.Count)
                .Returns(Task.CompletedTask);

            // Enqueue the events that are expected to be returned with a small delay between them.

            foreach (var eventData in expectedEvents)
            {
                await partitionState.PendingEventsWriter.WriteAsync(eventData, cancellationSource.Token);
                partitionState.BufferedEventCount += 1;
            }

            // Start the publishing task; it should wait for a full batch before completing.

            var publishingTask = mockBufferedProducer.Object.PublishBatchToPartition(partitionState, false, cancellationSource.Token);

            // Wait for longer than the wait time before enqueuing the extra event.  The batch will accept it, but the
            // wait time will have elapsed before it was available and it should not be included in the batch.

            await Task.Delay(TimeSpan.FromMilliseconds(options.MaximumWaitTime.Value.TotalMilliseconds * 1.5));

            await partitionState.PendingEventsWriter.WriteAsync(extraEvent, cancellationSource.Token);
            partitionState.BufferedEventCount += 1;

            // The extra event should cause publishing to happen; wait for the task to complete and verify.

            await publishingTask;

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
            Assert.That(partitionState.BufferedEventCount, Is.EqualTo(1), "The buffered event count for the partition should have been decremented, but the extra event should remain.");
            Assert.That(publishedEventsCount, Is.EqualTo(expectedEvents.Count), "The number of events published should match.");

            // Adding to the batch results in cloning the events; the data should match but the
            // reference will differ.

            for (var index = 0; index < publishedEvents.Count; ++index)
            {
                Assert.That(publishedEvents[index].IsEquivalentTo(expectedEvents[index]), Is.True, $"The event at index: [{ index }] did not match the expected event.");
            }

            mockProducer
                .Verify(producer => producer.SendAsync(
                    It.Is<EventDataBatch>(value => value.SendOptions.PartitionId == expectedPartition),
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task PublishBatchToPartitionDoesNotPublishIfNoEventsWereBuffered()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var publishedEventsCount = 0;
            var expectedPartition = "4";
            var options = new EventHubBufferedProducerClientOptions { MaximumWaitTime = TimeSpan.FromMilliseconds(150) };
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { expectedPartition, "6" });

            mockProducer
                .Setup(producer => producer.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns<CreateBatchOptions, CancellationToken>((options, token) => new ValueTask<EventDataBatch>(EventHubsModelFactory.EventDataBatch(1_048_576, new List<EventData>(), options)));

            mockProducer
                .Setup(producer => producer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Callback<EventDataBatch, CancellationToken>((batch, token) => publishedEventsCount = batch.Count)
                .Returns(Task.CompletedTask);

            // Publish and verify.

            await mockBufferedProducer.Object.PublishBatchToPartition(partitionState, false, cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
            Assert.That(partitionState.BufferedEventCount, Is.EqualTo(0), "No events should be buffered.");
            Assert.That(publishedEventsCount, Is.EqualTo(0), "No events should have been published.");

            mockProducer
                .Verify(producer => producer.SendAsync(
                    It.IsAny<EventDataBatch>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task PublishBatchToPartitionDoesInvokeTheHandlersIfNoEventsWereBuffered()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedPartition = "4";
            var successHandlerInvoked = false;
            var failureHandlerInvoked = false;
            var options = new EventHubBufferedProducerClientOptions { MaximumWaitTime = TimeSpan.FromMilliseconds(150) };
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { expectedPartition, "6" });

            mockProducer
                .Setup(producer => producer.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns<CreateBatchOptions, CancellationToken>((options, token) => new ValueTask<EventDataBatch>(EventHubsModelFactory.EventDataBatch(1_048_576, new List<EventData>(), options)));

            mockProducer
                .Setup(producer => producer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // Wire up the handler.

            mockBufferedProducer.Object.SendEventBatchSucceededAsync += args =>
            {
                successHandlerInvoked = true;
                return Task.CompletedTask;
            };

            mockBufferedProducer.Object.SendEventBatchFailedAsync += args =>
            {
                failureHandlerInvoked = true;
                return Task.CompletedTask;
            };

            // Publish and verify.

            await mockBufferedProducer.Object.PublishBatchToPartition(partitionState, false, cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
            Assert.That(partitionState.BufferedEventCount, Is.EqualTo(0), "No events should be buffered.");
            Assert.That(successHandlerInvoked, Is.False, "The success handler should not be invoked when no events were published.");
            Assert.That(failureHandlerInvoked, Is.False, "The failure handler should not be invoked when no events were published.");
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task PublishBatchToPartitionInvokesTheHandlerWhenPublishingSucceeds()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var publishedEventsCount = 0;
            var expectedPartition = "4";
            var extraEvent = EventGenerator.CreateSmallEvents(1).First();
            var expectedEvents = EventGenerator.CreateSmallEvents(10).ToList();
            var batchedEvents = new List<EventData>();
            var handlerArgs = default(SendEventBatchSucceededEventArgs);
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventHubBufferedProducerClientOptions { MaximumWaitTime = EventHubsTestEnvironment.Instance.TestExecutionTimeLimit };
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { expectedPartition, "6" });

            mockProducer
                .Setup(producer => producer.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns<CreateBatchOptions, CancellationToken>((options, token) => new ValueTask<EventDataBatch>(EventHubsModelFactory.EventDataBatch(1_048_576, batchedEvents, options, _ => batchedEvents.Count < expectedEvents.Count)));

            mockProducer
                .Setup(producer => producer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Callback<EventDataBatch, CancellationToken>((batch, token) => publishedEventsCount = batch.Count)
                .Returns(Task.CompletedTask);

            // Wire up the handler.

            mockBufferedProducer.Object.SendEventBatchSucceededAsync += args =>
            {
                handlerArgs = args;
                completionSource.TrySetResult(true);
                return Task.CompletedTask;
            };

            // Enqueue the events that are expected to be returned.

            foreach (var eventData in expectedEvents)
            {
                await partitionState.PendingEventsWriter.WriteAsync(eventData, cancellationSource.Token);
                partitionState.BufferedEventCount += 1;
            }

            // Enqueue the extra events that will trigger the batch being considered as full.

            await partitionState.PendingEventsWriter.WriteAsync(extraEvent, cancellationSource.Token);
            partitionState.BufferedEventCount += 1;

            // Publish and verify.

            await mockBufferedProducer.Object.PublishBatchToPartition(partitionState, false, cancellationSource.Token);
            await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
            Assert.That(partitionState.BufferedEventCount, Is.EqualTo(1), "The buffered event count for the partition should have been decremented, but the extra event should remain.");
            Assert.That(handlerArgs.PartitionId, Is.EqualTo(expectedPartition), "The partition should have been set for the handler arguments.");
            Assert.That(handlerArgs.EventBatch.Count, Is.EqualTo(expectedEvents.Count), "The number of events in the handler arguments should match.");

            // Adding to the batch results in cloning the events; the data should match but the
            // reference will differ.

            for (var index = 0; index < handlerArgs.EventBatch.Count; ++index)
            {
                Assert.That(handlerArgs.EventBatch[index].IsEquivalentTo(expectedEvents[index]), Is.True, $"The event at index: [{ index }] did not match the expected event.");
            }

            mockProducer
                .Verify(producer => producer.SendAsync(
                    It.Is<EventDataBatch>(value => value.SendOptions.PartitionId == expectedPartition),
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task PublishBatchToPartitionInvokesTheHandlerWhenPublishingFails()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedPartition = "4";
            var expectedException = new DivideByZeroException("Uh oh.  Did I do that?");
            var extraEvent = EventGenerator.CreateSmallEvents(1).First();
            var expectedEvents = EventGenerator.CreateSmallEvents(10).ToList();
            var batchedEvents = new List<EventData>();
            var handlerArgs = default(SendEventBatchFailedEventArgs);
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventHubBufferedProducerClientOptions { MaximumWaitTime = EventHubsTestEnvironment.Instance.TestExecutionTimeLimit };
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { expectedPartition, "6" });

            mockProducer
                .Setup(producer => producer.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns<CreateBatchOptions, CancellationToken>((options, token) => new ValueTask<EventDataBatch>(EventHubsModelFactory.EventDataBatch(1_048_576, batchedEvents, options, _ => batchedEvents.Count < expectedEvents.Count)));

            mockProducer
                .Setup(producer => producer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Throws(expectedException);

            // Wire up the handler.

            mockBufferedProducer.Object.SendEventBatchFailedAsync += args =>
            {
                handlerArgs = args;
                completionSource.TrySetResult(true);
                return Task.CompletedTask;
            };

            // Enqueue the events that are expected to be returned.

            foreach (var eventData in expectedEvents)
            {
                await partitionState.PendingEventsWriter.WriteAsync(eventData, cancellationSource.Token);
                partitionState.BufferedEventCount += 1;
            }

            // Enqueue the extra events that will trigger the batch being considered as full.

            await partitionState.PendingEventsWriter.WriteAsync(extraEvent, cancellationSource.Token);
            partitionState.BufferedEventCount += 1;

            // Publish and verify.

            await mockBufferedProducer.Object.PublishBatchToPartition(partitionState, false, cancellationSource.Token);
            await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
            Assert.That(handlerArgs.PartitionId, Is.EqualTo(expectedPartition), "The partition should have been set for the handler arguments.");
            Assert.That(handlerArgs.Exception, Is.SameAs(expectedException), "The exception should have been set for the handler arguments.");
            Assert.That(handlerArgs.EventBatch.Count, Is.EqualTo(expectedEvents.Count), "The number of events in the handler arguments should match.");

            // Adding to the batch results in cloning the events; the data should match but the
            // reference will differ.

            for (var index = 0; index < handlerArgs.EventBatch.Count; ++index)
            {
                Assert.That(handlerArgs.EventBatch[index].IsEquivalentTo(expectedEvents[index]), Is.True, $"The event at index: [{ index }] did not match the expected event.");
            }

            mockProducer
                .Verify(producer => producer.SendAsync(
                    It.Is<EventDataBatch>(value => value.SendOptions.PartitionId == expectedPartition),
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task PublishBatchToPartitionInvokesTheHandlerWhenPublishingIsCanceled()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            using var publishCancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationSource.Token);

            var expectedPartition = "4";
            var extraEvent = EventGenerator.CreateSmallEvents(1).First();
            var expectedEvents = EventGenerator.CreateSmallEvents(10).ToList();
            var batchedEvents = new List<EventData>();
            var handlerArgs = default(SendEventBatchFailedEventArgs);
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventHubBufferedProducerClientOptions { MaximumWaitTime = EventHubsTestEnvironment.Instance.TestExecutionTimeLimit };
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { expectedPartition, "6" });

            mockProducer
                .Setup(producer => producer.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns<CreateBatchOptions, CancellationToken>((options, token) => new ValueTask<EventDataBatch>(EventHubsModelFactory.EventDataBatch(1_048_576, batchedEvents, options, _ => batchedEvents.Count < expectedEvents.Count)));

            mockProducer
                .Setup(producer => producer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Callback(() => publishCancellationSource.Cancel())
                .Throws(new TaskCanceledException());

            // Wire up the handler.

            mockBufferedProducer.Object.SendEventBatchFailedAsync += args =>
            {
                handlerArgs = args;
                completionSource.TrySetResult(true);
                return Task.CompletedTask;
            };

            // Enqueue the events that are expected to be returned.

            foreach (var eventData in expectedEvents)
            {
                await partitionState.PendingEventsWriter.WriteAsync(eventData, cancellationSource.Token);
                partitionState.BufferedEventCount += 1;
            }

            // Enqueue the extra events that will trigger the batch being considered as full.

            await partitionState.PendingEventsWriter.WriteAsync(extraEvent, cancellationSource.Token);
            partitionState.BufferedEventCount += 1;

            // Publish and verify

            await mockBufferedProducer.Object.PublishBatchToPartition(partitionState, false, publishCancellationSource.Token);
            await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
            Assert.That(publishCancellationSource.IsCancellationRequested, Is.True, "Publishing cancellation should have been requested.");
            Assert.That(handlerArgs.PartitionId, Is.EqualTo(expectedPartition), "The partition should have been set for the handler arguments.");
            Assert.That(handlerArgs.Exception, Is.InstanceOf<TaskCanceledException>(), "The exception should have been set for the handler arguments.");
            Assert.That(handlerArgs.EventBatch.Count, Is.EqualTo(expectedEvents.Count), "The number of events in the handler arguments should match.");

            // Adding to the batch results in cloning the events; the data should match but the
            // reference will differ.

            for (var index = 0; index < handlerArgs.EventBatch.Count; ++index)
            {
                Assert.That(handlerArgs.EventBatch[index].IsEquivalentTo(expectedEvents[index]), Is.True, $"The event at index: [{ index }] did not match the expected event.");
            }

            mockProducer
                .Verify(producer => producer.SendAsync(
                    It.Is<EventDataBatch>(value => value.SendOptions.PartitionId == expectedPartition),
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task PublishBatchToPartitionDoesNotInvokesTheHandlerWhenCreatingTheBatchIsCanceled()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            using var publishCancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationSource.Token);

            var expectedPartition = "4";
            var extraEvent = EventGenerator.CreateSmallEvents(1).First();
            var bufferedEvents = EventGenerator.CreateSmallEvents(10).ToList();
            var handlerInvoked = false;
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventHubBufferedProducerClientOptions { MaximumWaitTime = EventHubsTestEnvironment.Instance.TestExecutionTimeLimit };
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { expectedPartition, "6" });

            mockProducer
                .Setup(producer => producer.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Callback(() => publishCancellationSource.Cancel())
                .Throws(new TaskCanceledException());

            mockProducer
                .Setup(producer => producer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // Wire up the handler.

            mockBufferedProducer.Object.SendEventBatchFailedAsync += args =>
            {
                handlerInvoked = true;
                return Task.CompletedTask;
            };

            // Set the completion source when cancellation is requested.

            publishCancellationSource.Token.Register(() => completionSource.TrySetResult(true));

            // Enqueue the events that are expected to be returned.

            foreach (var eventData in bufferedEvents)
            {
                await partitionState.PendingEventsWriter.WriteAsync(eventData, cancellationSource.Token);
                partitionState.BufferedEventCount += 1;
            }

            // Enqueue the extra events that will trigger the batch being considered as full.

            await partitionState.PendingEventsWriter.WriteAsync(extraEvent, cancellationSource.Token);
            partitionState.BufferedEventCount += 1;

            // Publish and verify

            await mockBufferedProducer.Object.PublishBatchToPartition(partitionState, false, publishCancellationSource.Token);
            await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
            Assert.That(publishCancellationSource.IsCancellationRequested, Is.True, "Publishing cancellation should have been requested.");
            Assert.That(partitionState.BufferedEventCount, Is.EqualTo(bufferedEvents.Count + 1), "The number of events in the buffer should not have changed.");
            Assert.That(handlerInvoked, Is.False, "The handler should not have been invoked because no events were batched at the time of cancellation.");
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task PublishBatchToPartitionInvokesTheHandlerWhenBatchBuildingIsCanceled()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            using var publishCancellationSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationSource.Token);

            var expectedPartition = "4";
            var expectedEvents = EventGenerator.CreateSmallEvents(5).ToList();
            var batchedEvents = new List<EventData>();
            var handlerArgs = default(SendEventBatchFailedEventArgs);
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventHubBufferedProducerClientOptions { MaximumWaitTime = EventHubsTestEnvironment.Instance.TestExecutionTimeLimit };
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            // Cancel when the first event is added to the batch.  This will not be respected until
            // the buffered events are drained and the wait delay takes place. To ensure that condition
            // is met, never consider the batch full.

            bool addToBatch(EventData _)
            {
                publishCancellationSource.Cancel();
                return true;
            }

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { expectedPartition, "6" });

            mockProducer
                .Setup(producer => producer.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns<CreateBatchOptions, CancellationToken>((options, token) => new ValueTask<EventDataBatch>(EventHubsModelFactory.EventDataBatch(1_048_576, batchedEvents, options, addToBatch)));

            mockProducer
                .Setup(producer => producer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Callback(() => publishCancellationSource.Cancel())
                .Throws(new TaskCanceledException());

            // Wire up the handler.

            mockBufferedProducer.Object.SendEventBatchFailedAsync += args =>
            {
                handlerArgs = args;
                completionSource.TrySetResult(true);
                return Task.CompletedTask;
            };

            // Enqueue the events that are expected to be returned.

            foreach (var eventData in expectedEvents)
            {
                await partitionState.PendingEventsWriter.WriteAsync(eventData, cancellationSource.Token);
                partitionState.BufferedEventCount += 1;
            }

            // Publish and verify

            await mockBufferedProducer.Object.PublishBatchToPartition(partitionState, false, publishCancellationSource.Token);
            await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
            Assert.That(publishCancellationSource.IsCancellationRequested, Is.True, "Publishing cancellation should have been requested.");
            Assert.That(handlerArgs.PartitionId, Is.EqualTo(expectedPartition), "The partition should have been set for the handler arguments.");
            Assert.That(handlerArgs.Exception, Is.InstanceOf<TaskCanceledException>(), "The exception should have been set for the handler arguments.");
            Assert.That(handlerArgs.EventBatch.Count, Is.EqualTo(expectedEvents.Count), "The number of events in the handler arguments should match.");

            // Adding to the batch results in cloning the events; the data should match but the
            // reference will differ.

            for (var index = 0; index < handlerArgs.EventBatch.Count; ++index)
            {
                Assert.That(handlerArgs.EventBatch[index].IsEquivalentTo(expectedEvents[index]), Is.True, $"The event at index: [{ index }] did not match the expected event.");
            }

            mockProducer
                .Verify(producer => producer.SendAsync(
                    It.IsAny<EventDataBatch>(),
                    It.IsAny<CancellationToken>()),
                Times.Never);
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task PublishBatchToPartitionFailsAnEventTooLargeToPublish()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedPartition = "4";
            var poisonEvent = EventGenerator.CreateEventFromBody(new byte[] { 0x65, 0x66, 0x67 });
            var handlerArgs = default(SendEventBatchFailedEventArgs);
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventHubBufferedProducerClientOptions { MaximumWaitTime = EventHubsTestEnvironment.Instance.TestExecutionTimeLimit };
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { expectedPartition, "6" });

            mockProducer
                .Setup(producer => producer.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns<CreateBatchOptions, CancellationToken>((options, token) => new ValueTask<EventDataBatch>(EventHubsModelFactory.EventDataBatch(1, new List<EventData>(), options, _ => false)));

            mockProducer
                .Setup(producer => producer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // Wire up the handler.

            mockBufferedProducer.Object.SendEventBatchFailedAsync += args =>
            {
                handlerArgs = args;
                completionSource.TrySetResult(true);
                return Task.CompletedTask;
            };

            // Enqueue the poison event.

            await partitionState.PendingEventsWriter.WriteAsync(poisonEvent, cancellationSource.Token);
            partitionState.BufferedEventCount += 1;

            // Publish and verify.

            await mockBufferedProducer.Object.PublishBatchToPartition(partitionState, false, cancellationSource.Token);
            await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
            Assert.That(partitionState.BufferedEventCount, Is.EqualTo(0), "There should be no events in the buffer.");
            Assert.That(handlerArgs.PartitionId, Is.EqualTo(expectedPartition), "The partition should have been set for the handler arguments.");
            Assert.That(handlerArgs.EventBatch.Count, Is.EqualTo(1), "Only the poison event should be in the handler arguments.");
            Assert.That(handlerArgs.Exception, Is.Not.Null, "An exception should have been set in the handler arguments.");
            Assert.That(handlerArgs.Exception, Is.InstanceOf<EventHubsException>(), "The exception reported should be an EventHubsException.");

            var eventHubsException = (EventHubsException)handlerArgs.Exception;
            Assert.That(eventHubsException.Reason, Is.EqualTo(EventHubsException.FailureReason.MessageSizeExceeded), "The exception should indicate that the message is too large.");
            Assert.That(eventHubsException.IsTransient, Is.False, "The exception should not be transient.");

            mockProducer
                .Verify(producer => producer.SendAsync(
                    It.Is<EventDataBatch>(value => value.SendOptions.PartitionId == expectedPartition),
                    It.IsAny<CancellationToken>()),
                Times.Never);
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task PublishBatchToPartitionRetriesWhenThrottled()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedPartition = "4";
            var throttled = false;
            var throttleException = new EventHubsException("fake", "Throttle!", EventHubsException.FailureReason.ServiceBusy);
            var terminalException = new DivideByZeroException("Uh oh.  Did I do that?");
            var extraEvent = EventGenerator.CreateSmallEvents(1).First();
            var expectedEvents = EventGenerator.CreateSmallEvents(2).ToList();
            var batchedEvents = new List<EventData>();
            var handlerArgs = default(SendEventBatchFailedEventArgs);
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var noRetryOptions = new EventHubsRetryOptions { MaximumRetries = 0 };
            var options = new EventHubBufferedProducerClientOptions { MaximumWaitTime = EventHubsTestEnvironment.Instance.TestExecutionTimeLimit, RetryOptions = noRetryOptions };
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { expectedPartition, "6" });

            mockProducer
                .Setup(producer => producer.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns<CreateBatchOptions, CancellationToken>((options, token) => new ValueTask<EventDataBatch>(EventHubsModelFactory.EventDataBatch(1_048_576, batchedEvents, options, _ => batchedEvents.Count < expectedEvents.Count)));

            mockProducer
                .Setup(producer => producer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                   if (!throttled)
                   {
                       throttled = true;
                       throw throttleException;
                   }

                   throw terminalException;
                });

            // Wire up the handler.

            mockBufferedProducer.Object.SendEventBatchFailedAsync += args =>
            {
                handlerArgs = args;
                completionSource.TrySetResult(true);
                return Task.CompletedTask;
            };

            // Enqueue the events that are expected to be returned.

            foreach (var eventData in expectedEvents)
            {
                await partitionState.PendingEventsWriter.WriteAsync(eventData, cancellationSource.Token);
                partitionState.BufferedEventCount += 1;
            }

            // Enqueue the extra events that will trigger the batch being considered as full.

            await partitionState.PendingEventsWriter.WriteAsync(extraEvent, cancellationSource.Token);
            partitionState.BufferedEventCount += 1;

            // Publish and verify.

            await mockBufferedProducer.Object.PublishBatchToPartition(partitionState, false, cancellationSource.Token);
            await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
            Assert.That(throttled, Is.True, "The first send call should have throttled.");
            Assert.That(handlerArgs.Exception, Is.SameAs(terminalException), "The terminal exception should have triggered a final failure.");

            mockProducer
                .Verify(producer => producer.SendAsync(
                    It.Is<EventDataBatch>(value => value.SendOptions.PartitionId == expectedPartition),
                    It.IsAny<CancellationToken>()),
                Times.Exactly(2));
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task PublishBatchToPartitionLogsTheOperation()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var publishedEventsCount = 0;
            var expectedPartition = "4";
            var extraEvent = EventGenerator.CreateSmallEvents(1).First();
            var expectedEvents = EventGenerator.CreateSmallEvents(10).ToList();
            var bufferedEvents = new List<EventData>();
            var options = new EventHubBufferedProducerClientOptions { MaximumWaitTime = TimeSpan.FromMilliseconds(150) };
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { expectedPartition, "6" });

            mockProducer
                .Setup(producer => producer.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns<CreateBatchOptions, CancellationToken>((options, token) => new ValueTask<EventDataBatch>(EventHubsModelFactory.EventDataBatch(1_048_576, bufferedEvents, options, _ => bufferedEvents.Count < expectedEvents.Count)));

            mockProducer
                .Setup(producer => producer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Callback<EventDataBatch, CancellationToken>((batch, token) => publishedEventsCount = batch.Count)
                .Returns(Task.CompletedTask);

            mockBufferedProducer.Object.Logger = mockLogger.Object;

            // Enqueue the events that are expected to be returned.

            foreach (var eventData in expectedEvents)
            {
                await partitionState.PendingEventsWriter.WriteAsync(eventData, cancellationSource.Token);
                partitionState.BufferedEventCount += 1;
            }

            // Enqueue the extra events that will trigger the batch being considered as full.

            await partitionState.PendingEventsWriter.WriteAsync(extraEvent, cancellationSource.Token);
            partitionState.BufferedEventCount += 1;

            // Publish and verify.

            await mockBufferedProducer.Object.PublishBatchToPartition(partitionState, false, cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
            Assert.That(publishedEventsCount, Is.EqualTo(expectedEvents.Count), "The number of events published should match.");

            mockLogger
                .Verify(log => log.BufferedProducerEventBatchPublishStart(
                    mockBufferedProducer.Object.Identifier,
                    mockBufferedProducer.Object.EventHubName,
                    expectedPartition,
                    It.IsAny<string>()),
                Times.Once);

            mockLogger
                .Verify(log => log.BufferedProducerEventBatchPublishComplete(
                    mockBufferedProducer.Object.Identifier,
                    mockBufferedProducer.Object.EventHubName,
                    expectedPartition,
                    It.IsAny<string>(),
                    publishedEventsCount,
                    It.IsAny<double>()),
                Times.Once);

            mockLogger
                .Verify(log => log.BufferedProducerEventBatchPublishEventAdded(
                    mockBufferedProducer.Object.Identifier,
                    mockBufferedProducer.Object.EventHubName,
                    expectedPartition,
                    It.IsAny<string>(),
                    It.Is<int>(value => value <= publishedEventsCount),
                    It.IsAny<double>()),
                Times.Exactly(publishedEventsCount));
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task PublishBatchToPartitionLogsWhenNoEventsAreRead()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var publishedEventsCount = 0;
            var expectedPartition = "4";
            var bufferedEvents = new List<EventData>();
            var options = new EventHubBufferedProducerClientOptions { MaximumWaitTime = TimeSpan.FromMilliseconds(250) };
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { expectedPartition, "6" });

            mockProducer
                .Setup(producer => producer.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns<CreateBatchOptions, CancellationToken>((options, token) => new ValueTask<EventDataBatch>(EventHubsModelFactory.EventDataBatch(1_048_576, bufferedEvents, options)));

            mockProducer
                .Setup(producer => producer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Callback<EventDataBatch, CancellationToken>((batch, token) => publishedEventsCount = batch.Count)
                .Returns(Task.CompletedTask);

            mockBufferedProducer.Object.Logger = mockLogger.Object;

            // Publish and verify.

            await mockBufferedProducer.Object.PublishBatchToPartition(partitionState, false, cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
            Assert.That(publishedEventsCount, Is.EqualTo(0), "No events should have been published.");

            // The exact number of iterations for the wait time is non-deterministic; ensure at least
            // one "no event read" entry was logged.

            mockLogger
                .Verify(log => log.BufferedProducerEventBatchPublishNoEventRead(
                    mockBufferedProducer.Object.Identifier,
                    mockBufferedProducer.Object.EventHubName,
                    expectedPartition,
                    It.IsAny<string>(),
                    It.IsAny<double>(),
                    It.IsAny<double>()),
                Times.AtLeastOnce);
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task PublishBatchToPartitionLogsWhenPublishingFails()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedPartition = "4";
            var expectedException = new DivideByZeroException("Uh oh.  Did I do that?");
            var extraEvent = EventGenerator.CreateSmallEvents(1).First();
            var expectedEvents = EventGenerator.CreateSmallEvents(10).ToList();
            var batchedEvents = new List<EventData>();
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventHubBufferedProducerClientOptions { MaximumWaitTime = EventHubsTestEnvironment.Instance.TestExecutionTimeLimit };
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { expectedPartition, "6" });

            mockProducer
                .Setup(producer => producer.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns<CreateBatchOptions, CancellationToken>((options, token) => new ValueTask<EventDataBatch>(EventHubsModelFactory.EventDataBatch(1_048_576, batchedEvents, options, _ => batchedEvents.Count < expectedEvents.Count)));

            mockProducer
                .Setup(producer => producer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Throws(expectedException);

            mockBufferedProducer.Object.Logger = mockLogger.Object;

            // Wire up the handler.

            mockBufferedProducer.Object.SendEventBatchFailedAsync += args =>
            {
                completionSource.TrySetResult(true);
                return Task.CompletedTask;
            };

            // Enqueue the events that are expected to be returned.

            foreach (var eventData in expectedEvents)
            {
                await partitionState.PendingEventsWriter.WriteAsync(eventData, cancellationSource.Token);
                partitionState.BufferedEventCount += 1;
            }

            // Enqueue the extra events that will trigger the batch being considered as full.

            await partitionState.PendingEventsWriter.WriteAsync(extraEvent, cancellationSource.Token);
            partitionState.BufferedEventCount += 1;

            // Publish and verify.

            await mockBufferedProducer.Object.PublishBatchToPartition(partitionState, false, cancellationSource.Token);
            await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");

            mockLogger
                .Verify(log => log.BufferedProducerEventBatchPublishError(
                    mockBufferedProducer.Object.Identifier,
                    mockBufferedProducer.Object.EventHubName,
                    expectedPartition,
                    It.IsAny<string>(),
                    expectedException.Message),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task PublishBatchToPartitionLogsAnEventTooLargeToPublish()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedPartition = "4";
            var poisonEvent = EventGenerator.CreateEventFromBody(new byte[] { 0x65, 0x66, 0x67 });
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventHubBufferedProducerClientOptions { MaximumWaitTime = EventHubsTestEnvironment.Instance.TestExecutionTimeLimit };
            var mockLogger = new Mock<EventHubsEventSource>();
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { expectedPartition, "6" });

            mockProducer
                .Setup(producer => producer.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns<CreateBatchOptions, CancellationToken>((options, token) => new ValueTask<EventDataBatch>(EventHubsModelFactory.EventDataBatch(1, new List<EventData>(), options, _ => false)));

            mockProducer
                .Setup(producer => producer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            mockBufferedProducer.Object.Logger = mockLogger.Object;

            // Wire up the handler.

            mockBufferedProducer.Object.SendEventBatchFailedAsync += args =>
            {
                completionSource.TrySetResult(true);
                return Task.CompletedTask;
            };

            // Enqueue the poison event.

            await partitionState.PendingEventsWriter.WriteAsync(poisonEvent, cancellationSource.Token);
            partitionState.BufferedEventCount += 1;

            // Publish and verify.

            await mockBufferedProducer.Object.PublishBatchToPartition(partitionState, false, cancellationSource.Token);
            await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
            Assert.That(partitionState.BufferedEventCount, Is.EqualTo(0), "There should be no events in the buffer.");

            mockLogger
                .Verify(log => log.BufferedProducerEventBatchPublishError(
                    mockBufferedProducer.Object.Identifier,
                    mockBufferedProducer.Object.EventHubName,
                    expectedPartition,
                    It.IsAny<string>(),
                    It.IsAny<string>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task PublishBatchToPartitionLogsWhenThrottled()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedPartition = "4";
            var throttled = false;
            var throttleException = new EventHubsException("fake", "Throttle!", EventHubsException.FailureReason.ServiceBusy);
            var terminalException = new DivideByZeroException("Uh oh.  Did I do that?");
            var extraEvent = EventGenerator.CreateSmallEvents(1).First();
            var expectedEvents = EventGenerator.CreateSmallEvents(2).ToList();
            var batchedEvents = new List<EventData>();
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var noRetryOptions = new EventHubsRetryOptions { MaximumRetries = 0 };
            var options = new EventHubBufferedProducerClientOptions { MaximumWaitTime = EventHubsTestEnvironment.Instance.TestExecutionTimeLimit, RetryOptions = noRetryOptions };
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { expectedPartition, "6" });

            mockProducer
                .Setup(producer => producer.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns<CreateBatchOptions, CancellationToken>((options, token) => new ValueTask<EventDataBatch>(EventHubsModelFactory.EventDataBatch(1_048_576, batchedEvents, options, _ => batchedEvents.Count < expectedEvents.Count)));

            mockProducer
                .Setup(producer => producer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Returns(() =>
                {
                    if (!throttled)
                    {
                        throttled = true;
                        throw throttleException;
                    }

                    throw terminalException;
                });

            mockBufferedProducer.Object.Logger = mockLogger.Object;

            // Wire up the handler.

            mockBufferedProducer.Object.SendEventBatchFailedAsync += args =>
            {
                completionSource.TrySetResult(true);
                return Task.CompletedTask;
            };

            // Enqueue the events that are expected to be returned.

            foreach (var eventData in expectedEvents)
            {
                await partitionState.PendingEventsWriter.WriteAsync(eventData, cancellationSource.Token);
                partitionState.BufferedEventCount += 1;
            }

            // Enqueue the extra events that will trigger the batch being considered as full.

            await partitionState.PendingEventsWriter.WriteAsync(extraEvent, cancellationSource.Token);
            partitionState.BufferedEventCount += 1;

            // Publish and verify.

            await mockBufferedProducer.Object.PublishBatchToPartition(partitionState, false, cancellationSource.Token);
            await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
            Assert.That(throttled, Is.True, "The first send call should have throttled.");

            mockLogger
                .Verify(log => log.BufferedProducerThrottleDelay(
                    mockBufferedProducer.Object.Identifier,
                    mockBufferedProducer.Object.EventHubName,
                    expectedPartition,
                    It.IsAny<string>(),
                    It.IsAny<double>(),
                    1),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundPublishingTaskPublishesForOnePartition()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedPartition = "4";
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventHubBufferedProducerClientOptions { MaximumConcurrentSends = 1, MaximumConcurrentSendsPerPartition = 1 };
            var state = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { expectedPartition });

            mockBufferedProducer
                .Setup(producer => producer.PublishBatchToPartition(It.IsAny<EventHubBufferedProducerClient.PartitionPublishingState>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .Callback<EventHubBufferedProducerClient.PartitionPublishingState, bool, CancellationToken>((state, releaseFlag, token) =>
                {
                    while (state.TryReadEvent(out _)) {}
                    state.BufferedEventCount = 0;

                    if (releaseFlag)
                    {
                        state.PartitionGuard.Release();
                    }

                    completionSource.TrySetResult(true);
                })
                .Returns(Task.CompletedTask);

            mockBufferedProducer.Object.ActivePartitionStateMap[expectedPartition] = state;

            try
            {
                // Start publishing.

                await InvokeStartPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token);

                // Enqueue an event and wait for it to be published.

                await state.PendingEventsWriter.WriteAsync(new EventData("single"), cancellationSource.Token);
                state.BufferedEventCount = 1;

                await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);
            }
            finally
            {
                await InvokeStopPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token).IgnoreExceptions();
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
            Assert.That(state.BufferedEventCount, Is.EqualTo(0), "There should be no events in the buffer.");

            mockBufferedProducer
                .Verify(producer => producer.PublishBatchToPartition(
                    state,
                    true,
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundPublishingTaskPublishesForMultiplePartitions()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var publishCount = 0;
            var validPartitions = new[] { "5", "8", "11", "frank" };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventHubBufferedProducerClientOptions { MaximumConcurrentSends = validPartitions.Length, MaximumConcurrentSendsPerPartition = 1 };
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(validPartitions);

            mockBufferedProducer
                .Setup(producer => producer.PublishBatchToPartition(It.IsAny<EventHubBufferedProducerClient.PartitionPublishingState>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .Callback<EventHubBufferedProducerClient.PartitionPublishingState, bool, CancellationToken>((state, releaseFlag, token) =>
                {
                    while (state.TryReadEvent(out _)) {}
                    state.BufferedEventCount = 0;

                    if (releaseFlag)
                    {
                        state.PartitionGuard.Release();
                    }

                    if (Interlocked.Increment(ref publishCount) >= validPartitions.Length)
                    {
                        completionSource.TrySetResult(true);
                    }
                })
                .Returns(Task.CompletedTask);

            // Create a buffered event for each partition.

            foreach (var partition in validPartitions)
            {
                var state = new EventHubBufferedProducerClient.PartitionPublishingState(partition, options);
                mockBufferedProducer.Object.ActivePartitionStateMap[partition] = state;

                await state.PendingEventsWriter.WriteAsync(new EventData($"single-for-{ partition }"), cancellationSource.Token);
                state.BufferedEventCount = 1;
            }

            // Since enqueue was bypassed, set the total buffered count to match the
            // partition state.

            SetTotalBufferedEventCount(mockBufferedProducer.Object, validPartitions.Length);

            try
            {
                // Start publishing and wait for publishing to complete.

                await InvokeStartPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token);
                await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);
            }
            finally
            {
                await InvokeStopPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token).IgnoreExceptions();
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");

            foreach (var partition in validPartitions)
            {
                var state = mockBufferedProducer.Object.ActivePartitionStateMap[partition];
                Assert.That(state.BufferedEventCount, Is.EqualTo(0), $"There should be no events in the buffer for partition: [{ partition }].");
            }

            mockBufferedProducer
                .Verify(producer => producer.PublishBatchToPartition(
                    It.Is<EventHubBufferedProducerClient.PartitionPublishingState>(value => validPartitions.Any(item => item == value.PartitionId)),
                    true,
                    It.IsAny<CancellationToken>()),
                Times.Exactly(validPartitions.Length));
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundPublishingTaskPublishesWithMultiplePasses()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var eventsPerPartition = 3;
            var validPartitions = new[] { "5", "8", "11", "frank" };
            var publishCount = 0;
            var expectedPublishCount = validPartitions.Length * eventsPerPartition;
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventHubBufferedProducerClientOptions { MaximumConcurrentSends = validPartitions.Length, MaximumConcurrentSendsPerPartition = 1 };
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(validPartitions);

            mockBufferedProducer
                .Setup(producer => producer.PublishBatchToPartition(It.IsAny<EventHubBufferedProducerClient.PartitionPublishingState>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .Callback<EventHubBufferedProducerClient.PartitionPublishingState, bool, CancellationToken>((state, releaseFlag, token) =>
                {
                    state.TryReadEvent(out _);
                    --state.BufferedEventCount;

                    if (releaseFlag)
                    {
                        state.PartitionGuard.Release();
                    }

                    if (Interlocked.Increment(ref publishCount) >= expectedPublishCount)
                    {
                        completionSource.TrySetResult(true);
                    }
                })
                .Returns(Task.CompletedTask);

             // Create a buffered event for each partition.

            foreach (var partition in validPartitions)
            {
                var state = new EventHubBufferedProducerClient.PartitionPublishingState(partition, options);
                mockBufferedProducer.Object.ActivePartitionStateMap[partition] = state;

                for (int index = 0; index < eventsPerPartition; ++index)
                {
                    await state.PendingEventsWriter.WriteAsync(new EventData($"{ index }-for-{ partition }"), cancellationSource.Token);
                    ++state.BufferedEventCount;
                }
            }

            // Since enqueue was bypassed, set the total buffered count to match the
            // partition state.

            SetTotalBufferedEventCount(mockBufferedProducer.Object, validPartitions.Length);

            try
            {
                // Start publishing and wait for publishing to complete.

                await InvokeStartPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token);
                await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);
            }
            finally
            {
                await InvokeStopPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token).IgnoreExceptions();
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");

            foreach (var partition in validPartitions)
            {
                var state = mockBufferedProducer.Object.ActivePartitionStateMap[partition];
                Assert.That(state.BufferedEventCount, Is.EqualTo(0), $"There should be no events in the buffer for partition: [{ partition }].");
            }

            mockBufferedProducer
                .Verify(producer => producer.PublishBatchToPartition(
                    It.Is<EventHubBufferedProducerClient.PartitionPublishingState>(value => validPartitions.Any(item => item == value.PartitionId)),
                    true,
                    It.IsAny<CancellationToken>()),
                Times.Exactly(expectedPublishCount));
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundPublishingTaskPublishesWithLimitedConcurrentSends()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var eventsPerPartition = 3;
            var validPartitions = new[] { "5", "8", "11", "frank" };
            var concurentSends = (int)Math.Floor(validPartitions.Length / 2.0);
            var publishCount = 0;
            var expectedPublishCount = validPartitions.Length * eventsPerPartition;
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventHubBufferedProducerClientOptions { MaximumConcurrentSends = concurentSends, MaximumConcurrentSendsPerPartition = 1 };
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(validPartitions);

            mockBufferedProducer
                .Setup(producer => producer.PublishBatchToPartition(It.IsAny<EventHubBufferedProducerClient.PartitionPublishingState>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .Callback<EventHubBufferedProducerClient.PartitionPublishingState, bool, CancellationToken>((state, releaseFlag, token) =>
                {
                    state.TryReadEvent(out _);
                    --state.BufferedEventCount;

                    if (releaseFlag)
                    {
                        state.PartitionGuard.Release();
                    }

                    if (Interlocked.Increment(ref publishCount) >= expectedPublishCount)
                    {
                        completionSource.TrySetResult(true);
                    }
                })
                .Returns(Task.CompletedTask);

             // Create a buffered event for each partition.

            foreach (var partition in validPartitions)
            {
                var state = new EventHubBufferedProducerClient.PartitionPublishingState(partition, options);
                mockBufferedProducer.Object.ActivePartitionStateMap[partition] = state;

                for (int index = 0; index < eventsPerPartition; ++index)
                {
                    await state.PendingEventsWriter.WriteAsync(new EventData($"{ index }-for-{ partition }"), cancellationSource.Token);
                    ++state.BufferedEventCount;
                }
            }

            // Since enqueue was bypassed, set the total buffered count to match the
            // partition state.

            SetTotalBufferedEventCount(mockBufferedProducer.Object, expectedPublishCount);

            try
            {
                // Start publishing and wait for publishing to complete.

                await InvokeStartPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token);
                await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);
            }
            finally
            {
                await InvokeStopPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token).IgnoreExceptions();
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");

            foreach (var partition in validPartitions)
            {
                var state = mockBufferedProducer.Object.ActivePartitionStateMap[partition];
                Assert.That(state.BufferedEventCount, Is.EqualTo(0), $"There should be no events in the buffer for partition: [{ partition }].");
            }

            mockBufferedProducer
                .Verify(producer => producer.PublishBatchToPartition(
                    It.Is<EventHubBufferedProducerClient.PartitionPublishingState>(value => validPartitions.Any(item => item == value.PartitionId)),
                    true,
                    It.IsAny<CancellationToken>()),
                Times.Exactly(expectedPublishCount));
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundPublishingTaskPublishesWithConcurrentSendsPerPartition()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var eventsPerPartition = 8;
            var concurrentSendsPerPartition = 3;
            var validPartitions = new[] { "5", "8", "11", "frank" };
            var concurentSends = (validPartitions.Length * concurrentSendsPerPartition);
            var publishCount = 0;
            var expectedPublishCount = validPartitions.Length * eventsPerPartition;
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventHubBufferedProducerClientOptions { MaximumConcurrentSends = concurentSends, MaximumConcurrentSendsPerPartition = concurrentSendsPerPartition };
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(validPartitions);

            mockBufferedProducer
                .Setup(producer => producer.PublishBatchToPartition(It.IsAny<EventHubBufferedProducerClient.PartitionPublishingState>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .Callback<EventHubBufferedProducerClient.PartitionPublishingState, bool, CancellationToken>((state, releaseFlag, token) =>
                {
                    state.TryReadEvent(out _);
                    Interlocked.Decrement(ref state.BufferedEventCount);

                    if (releaseFlag)
                    {
                        state.PartitionGuard.Release();
                    }

                    if (Interlocked.Increment(ref publishCount) >= expectedPublishCount)
                    {
                        completionSource.TrySetResult(true);
                    }
                })
                .Returns(Task.CompletedTask);

             // Create a buffered event for each partition.

            foreach (var partition in validPartitions)
            {
                var state = new EventHubBufferedProducerClient.PartitionPublishingState(partition, options);
                mockBufferedProducer.Object.ActivePartitionStateMap[partition] = state;

                for (int index = 0; index < eventsPerPartition; ++index)
                {
                    await state.PendingEventsWriter.WriteAsync(new EventData($"{ index }-for-{ partition }"), cancellationSource.Token);
                    ++state.BufferedEventCount;
                }
            }

            // Since enqueue was bypassed, set the total buffered count to match the
            // partition state.

            SetTotalBufferedEventCount(mockBufferedProducer.Object, expectedPublishCount);

            try
            {
                // Start publishing and wait for publishing to complete.

                await InvokeStartPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token);
                await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);
            }
            finally
            {
                await InvokeStopPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token).IgnoreExceptions();
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");

            foreach (var partition in validPartitions)
            {
                var state = mockBufferedProducer.Object.ActivePartitionStateMap[partition];
                Assert.That(state.BufferedEventCount, Is.EqualTo(0), $"There should be no events in the buffer for partition: [{ partition }].");
            }

            mockBufferedProducer
                .Verify(producer => producer.PublishBatchToPartition(
                    It.Is<EventHubBufferedProducerClient.PartitionPublishingState>(value => validPartitions.Any(item => item == value.PartitionId)),
                    true,
                    It.IsAny<CancellationToken>()),
                Times.Exactly(expectedPublishCount));
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundPublishingTaskPublishesAfterAnEmptyBufferIdle()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var eventsPerPartition = 8;
            var concurrentSendsPerPartition = 3;
            var validPartitions = new[] { "5", "8", "11", "frank" };
            var concurentSends = (validPartitions.Length * concurrentSendsPerPartition);
            var publishCount = 0;
            var expectedPublishCount = validPartitions.Length * eventsPerPartition;
            var initialPublishCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var delayPublishCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var idleCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventHubBufferedProducerClientOptions { MaximumConcurrentSends = concurentSends, MaximumConcurrentSendsPerPartition = concurrentSendsPerPartition };
            var mockLogger = new Mock<EventHubsEventSource>();
            var connection = new EventHubConnection("fakeNS", "fakeHub", Mock.Of<TokenCredential>());
            var mockProducer = new Mock<EventHubProducerClient>(connection, new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockLogger
                .Setup(log => log.BufferedProducerIdleStart(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()))
                .Callback(() => idleCompletionSource.TrySetResult(true));

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(validPartitions);

            mockBufferedProducer
                .Setup(producer => producer.PublishBatchToPartition(It.IsAny<EventHubBufferedProducerClient.PartitionPublishingState>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .Callback<EventHubBufferedProducerClient.PartitionPublishingState, bool, CancellationToken>((state, releaseFlag, token) =>
                {
                    state.TryReadEvent(out _);
                    Interlocked.Decrement(ref state.BufferedEventCount);

                    if (releaseFlag)
                    {
                        state.PartitionGuard.Release();
                    }

                    if (Interlocked.Increment(ref publishCount) == expectedPublishCount)
                    {
                        SetTotalBufferedEventCount(mockBufferedProducer.Object, 0);
                        initialPublishCompletionSource.TrySetResult(true);
                    }

                    if (publishCount > expectedPublishCount)
                    {
                        delayPublishCompletionSource.TrySetResult(true);
                    }
                })
                .Returns(Task.CompletedTask);

            mockBufferedProducer.Object.Logger = mockLogger.Object;
            mockBufferedProducer.Object.SendEventBatchFailedAsync += args => Task.CompletedTask;

            // Enqueue events into each partition.

            foreach (var partition in validPartitions)
            {
                for (int index = 0; index < eventsPerPartition; ++index)
                {
                    await mockBufferedProducer.Object.EnqueueEventAsync(new EventData($"{index}-for-{partition}"), cancellationSource.Token);
                }
            }

            try
            {
                // Start publishing and wait for the initial set of publishing to complete.

                await InvokeStartPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token);
                await initialPublishCompletionSource.Task.AwaitWithCancellation(cancellationSource.Token);

                // Delay to give the background task time to reach a blocking state, then publish a follow-up
                // event and wait for it to be completed.

                await idleCompletionSource.Task.AwaitWithCancellation(cancellationSource.Token);
                await Task.Delay(TimeSpan.FromSeconds(2), cancellationSource.Token);

                await mockBufferedProducer.Object.EnqueueEventAsync(new EventData("Delay event"), cancellationSource.Token);
                await delayPublishCompletionSource.Task.AwaitWithCancellation(cancellationSource.Token);
            }
            finally
            {
                await InvokeStopPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token).IgnoreExceptions();
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");

            foreach (var partition in validPartitions)
            {
                var state = mockBufferedProducer.Object.ActivePartitionStateMap[partition];
                Assert.That(state.BufferedEventCount, Is.EqualTo(0), $"There should be no events in the buffer for partition: [{partition}].");
            }

            mockBufferedProducer
                .Verify(producer => producer.PublishBatchToPartition(
                    It.Is<EventHubBufferedProducerClient.PartitionPublishingState>(value => validPartitions.Any(item => item == value.PartitionId)),
                    true,
                    It.IsAny<CancellationToken>()),
                Times.Exactly(expectedPublishCount + 1));

            mockLogger
                .Verify(log => log.BufferedProducerIdleComplete(
                    mockBufferedProducer.Object.Identifier,
                    mockBufferedProducer.Object.EventHubName,
                    It.IsAny<string>(),
                    It.IsAny<double>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundPublishingTaskAwaitsActiveOperationsWhenCanceledAndLogs()
        {
            using var executionLimitCancellationSource = new CancellationTokenSource();
            using var cancellationSource = CancellationTokenSource.CreateLinkedTokenSource(executionLimitCancellationSource.Token);
            executionLimitCancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var startCount = 0;
            var finishCount = 0;
            var validPartitions = new[] { "5", "8", "11", "frank" };
            var startedCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var finishedCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventHubBufferedProducerClientOptions { MaximumConcurrentSends = validPartitions.Length, MaximumConcurrentSendsPerPartition = 1 };
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(validPartitions);

            mockBufferedProducer
                .Setup(producer => producer.PublishBatchToPartition(It.IsAny<EventHubBufferedProducerClient.PartitionPublishingState>(), It.IsAny<bool>(), It.IsAny<CancellationToken>()))
                .Callback<EventHubBufferedProducerClient.PartitionPublishingState, bool, CancellationToken>(async (state, releaseFlag, token) =>
                {
                    if (Interlocked.Increment(ref startCount) >= validPartitions.Length)
                    {
                        startedCompletionSource.TrySetResult(true);
                    }

                    try
                    {
                        await Task.Delay(Timeout.InfiniteTimeSpan, cancellationSource.Token).ConfigureAwait(false);
                    }
                    catch (OperationCanceledException)
                    {
                        // Expected; do nothing.
                    }

                    state.BufferedEventCount = 0;
                    while (state.TryReadEvent(out _)) {}

                    if (releaseFlag)
                    {
                        state.PartitionGuard.Release();
                    }

                    if (Interlocked.Increment(ref finishCount) >= validPartitions.Length)
                    {
                        finishedCompletionSource.TrySetResult(true);
                    }
                })
                .Returns(finishedCompletionSource.Task);

            mockBufferedProducer.Object.Logger = mockLogger.Object;

            // Create a buffered event for each partition.

            foreach (var partition in validPartitions)
            {
                var state = new EventHubBufferedProducerClient.PartitionPublishingState(partition, options);
                mockBufferedProducer.Object.ActivePartitionStateMap[partition] = state;

                await state.PendingEventsWriter.WriteAsync(new EventData($"single-for-{ partition }"), executionLimitCancellationSource.Token);
                state.BufferedEventCount = 1;
            }

            // Since enqueue was bypassed, set the total buffered count to match the
            // partition state.

            SetTotalBufferedEventCount(mockBufferedProducer.Object, validPartitions.Length);

            try
            {
                // Start publishing and validate that publishing does not complete right away.

                await InvokeStartPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token);
                await startedCompletionSource.Task.AwaitWithCancellation(cancellationSource.Token);
                await Task.Delay(500);

                Assert.That(executionLimitCancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested for the test time limit.");
                Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
                Assert.That(finishedCompletionSource.Task.IsCompleted, Is.False, "Publishing should not complete until cancellation is requested.");

                cancellationSource.Cancel();
                await finishedCompletionSource.Task.AwaitWithCancellation(executionLimitCancellationSource.Token);
            }
            finally
            {
                await InvokeStopPublishingAsync(mockBufferedProducer.Object, executionLimitCancellationSource.Token).AwaitWithCancellation(executionLimitCancellationSource.Token);
            }

            Assert.That(executionLimitCancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested for the test time limit.");
            Assert.That(cancellationSource.IsCancellationRequested, Is.True, "Cancellation should have been requested.");

            foreach (var partition in validPartitions)
            {
                var state = mockBufferedProducer.Object.ActivePartitionStateMap[partition];
                Assert.That(Volatile.Read(ref state.BufferedEventCount), Is.EqualTo(0), $"There should be no events in the buffer for partition: [{ partition }].");
            }

            mockLogger
                .Verify(log => log.BufferedProducerPublishingAwaitAllStart(
                    mockBufferedProducer.Object.Identifier,
                    mockBufferedProducer.Object.EventHubName,
                    It.Is<int>(value => value <= options.MaximumConcurrentSends),
                    It.IsAny<string>()),
                Times.Once);

            mockLogger
                .Verify(log => log.BufferedProducerPublishingAwaitAllComplete(
                    mockBufferedProducer.Object.Identifier,
                    mockBufferedProducer.Object.EventHubName,
                    It.Is<int>(value => value <= options.MaximumConcurrentSends),
                    It.IsAny<string>(),
                    It.IsAny<double>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundPublishingTaskLogsTheOperation()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedPartition = "0";
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventHubBufferedProducerClientOptions { MaximumWaitTime = null };
            var publishingState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { expectedPartition, "1" });

            mockBufferedProducer
                .Setup(producer => producer.PublishBatchToPartition(
                    It.IsAny<EventHubBufferedProducerClient.PartitionPublishingState>(),
                    It.IsAny<bool>(),
                    It.IsAny<CancellationToken>()))
                .Callback(() => completionSource.TrySetResult(true))
                .Returns(Task.CompletedTask);

            mockBufferedProducer.Object.Logger = mockLogger.Object;
            mockBufferedProducer.Object.ActivePartitionStateMap[expectedPartition] = publishingState;

            try
            {
                publishingState.BufferedEventCount = 1;

                await InvokeStartPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token);
                await completionSource.Task.AwaitWithCancellation(cancellationSource.Token);

                Assert.That(GetBackgroundPublishingTask(mockBufferedProducer.Object), Is.Not.Null, "The publishing task should have been started.");
            }
            finally
            {
                await InvokeStopPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token).IgnoreExceptions();
            }

            mockLogger
              .Verify(log => log.BufferedProducerPublishingManagementStart(
                  mockBufferedProducer.Object.Identifier,
                  mockBufferedProducer.Object.EventHubName,
                  It.IsAny<string>()),
              Times.Once);

            mockLogger
              .Verify(log => log.BufferedProducerPublishingManagementComplete(
                  mockBufferedProducer.Object.Identifier,
                  mockBufferedProducer.Object.EventHubName,
                  It.IsAny<string>()),
              Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the background management task.
        /// </summary>
        ///
        [Test]
        public async Task BackgroundPublishingTaskLogsErrors()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedPartition = "0";
            var expectedException = new DivideByZeroException("Boom!");
            var startCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var publishCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventHubBufferedProducerClientOptions { MaximumWaitTime = null };
            var publishingState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockLogger
                .Setup(log => log.BufferedProducerPublishingManagementError(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Callback(() => publishCompletionSource.TrySetResult(true));

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { expectedPartition, "1" });

            mockBufferedProducer
                .Setup(producer => producer.PublishBatchToPartition(
                    It.IsAny<EventHubBufferedProducerClient.PartitionPublishingState>(),
                    It.IsAny<bool>(),
                    It.IsAny<CancellationToken>()))
                .Callback(() => startCompletionSource.TrySetResult(true))
                .Throws(expectedException);

            mockBufferedProducer.Object.Logger = mockLogger.Object;
            mockBufferedProducer.Object.ActivePartitionStateMap[expectedPartition] = publishingState;

            try
            {
                publishingState.BufferedEventCount = 1;

                await InvokeStartPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token);
                await startCompletionSource.Task.AwaitWithCancellation(cancellationSource.Token);

                Assert.That(GetBackgroundPublishingTask(mockBufferedProducer.Object), Is.Not.Null, "The publishing task should have been started.");
            }
            finally
            {
                await InvokeStopPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token).IgnoreExceptions();
                await publishCompletionSource.Task.AwaitWithCancellation(cancellationSource.Token);
            }

            mockLogger
              .Verify(log => log.BufferedProducerPublishingManagementError(
                  mockBufferedProducer.Object.Identifier,
                  mockBufferedProducer.Object.EventHubName,
                  It.IsAny<string>(),
                  expectedException.Message),
              Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.DrainAndPublishPartitionEvents" /> method.
        /// </summary>
        ///
        [Test]
        public async Task DrainAndPublishPartitionEventsPublishshesOneBatch()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var publishedEventsCount = 0;
            var expectedPartition = "4";
            var expectedEvents = EventGenerator.CreateSmallEvents(10).ToList();
            var publishedEvents = new List<EventData>();
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventHubBufferedProducerClientOptions();
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns<CreateBatchOptions, CancellationToken>((options, token) => new ValueTask<EventDataBatch>(EventHubsModelFactory.EventDataBatch(1_048_576, new List<EventData>(), options)));

            mockProducer
                .Setup(producer => producer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Callback<EventDataBatch, CancellationToken>((batch, token) => publishedEventsCount = batch.Count)
                .Returns(Task.CompletedTask);

            mockBufferedProducer.Object.SendEventBatchSucceededAsync += args =>
            {
                publishedEvents.AddRange(args.EventBatch);
                completionSource.TrySetResult(true);

                return Task.CompletedTask;
            };

            // Enqueue the events that are expected to be returned.

            foreach (var eventData in expectedEvents)
            {
                await partitionState.PendingEventsWriter.WriteAsync(eventData, cancellationSource.Token);
                partitionState.BufferedEventCount += 1;
            }

            // Drain and verify.

            await mockBufferedProducer.Object.DrainAndPublishPartitionEvents(partitionState, null, cancellationSource.Token);
            await completionSource.Task;

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
            Assert.That(publishedEventsCount, Is.EqualTo(expectedEvents.Count), "The number of events published should match.");

            // Adding to the batch results in cloning the events; the data should match but the
            // reference will differ.

            for (var index = 0; index < publishedEvents.Count; ++index)
            {
                Assert.That(publishedEvents[index].IsEquivalentTo(expectedEvents[index]), Is.True, $"The event at index: [{ index }] did not match the expected event.");
            }

            mockProducer
                .Verify(producer => producer.SendAsync(
                    It.Is<EventDataBatch>(value => value.SendOptions.PartitionId == expectedPartition),
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.DrainAndPublishPartitionEvents" /> method.
        /// </summary>
        ///
        [Test]
        public async Task DrainAndPublishPartitionEventsPublishshesMultipleBatches()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedPublishCalls = 2;
            var expectedPartition = "4";
            var expectedEvents = EventGenerator.CreateSmallEvents(14).ToList();
            var createBatchCount = 0;
            var batchAddCallCount = 0;
            var publishedEventsCount = 0;
            var handlerCallCount = 0;
            var batchEvents = new List<EventData>();
            var publishedEvents = new List<EventData>();
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventHubBufferedProducerClientOptions();
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            bool isFull(EventData eventData) =>
                createBatchCount switch
                {
                    _ when ((createBatchCount == 1) && (++batchAddCallCount <= 10)) => true,
                    _ when (createBatchCount == 1) => false,
                    _ => true
                };

            mockProducer
                .Setup(producer => producer.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Callback(() => ++createBatchCount)
                .Returns<CreateBatchOptions, CancellationToken>((options, token) => new ValueTask<EventDataBatch>(EventHubsModelFactory.EventDataBatch(1_048_576, batchEvents, options, isFull)));

            mockProducer
                .Setup(producer => producer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Callback<EventDataBatch, CancellationToken>((batch, token) =>
                {
                    publishedEvents.AddRange(batchEvents);
                    publishedEventsCount += batchEvents.Count;
                    batchEvents.Clear();
                })
                .Returns(Task.CompletedTask);

            mockBufferedProducer.Object.SendEventBatchSucceededAsync += args =>
            {
                if (++handlerCallCount == expectedPublishCalls)
                {
                    completionSource.TrySetResult(true);
                }

                return Task.CompletedTask;
            };

            // Enqueue the events that are expected to be returned.

            foreach (var eventData in expectedEvents)
            {
                await partitionState.PendingEventsWriter.WriteAsync(eventData, cancellationSource.Token);
                partitionState.BufferedEventCount += 1;
            }

            // Drain and verify.

            await mockBufferedProducer.Object.DrainAndPublishPartitionEvents(partitionState, null, cancellationSource.Token);
            await completionSource.Task;

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
            Assert.That(publishedEventsCount, Is.EqualTo(expectedEvents.Count), "The number of events published should match.");
            Assert.That(handlerCallCount, Is.EqualTo(expectedPublishCalls), "The number of handler calls should match.");

            // Adding to the batch results in cloning the events; the data should match but the
            // reference will differ.

            for (var index = 0; index < publishedEvents.Count; ++index)
            {
                Assert.That(publishedEvents[index].IsEquivalentTo(expectedEvents[index]), Is.True, $"The event at index: [{ index }] did not match the expected event.");
            }

            mockProducer
                .Verify(producer => producer.SendAsync(
                    It.Is<EventDataBatch>(value => value.SendOptions.PartitionId == expectedPartition),
                    It.IsAny<CancellationToken>()),
                Times.Exactly(expectedPublishCalls));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.DrainAndPublishPartitionEvents" /> method.
        /// </summary>
        ///
        [Test]
        public async Task DrainAndPublishPartitionEventsClearsPartitionState()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedPartition = "4";
            var publishedEvents = new List<EventData>();
            var options = new EventHubBufferedProducerClientOptions();
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns<CreateBatchOptions, CancellationToken>((options, token) => new ValueTask<EventDataBatch>(EventHubsModelFactory.EventDataBatch(1_048_576, new List<EventData>(), options)));

            mockProducer
                .Setup(producer => producer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // Enqueue the events that are expected to be returned.

            await partitionState.PendingEventsWriter.WriteAsync(new EventData("wheee!"), cancellationSource.Token);
            partitionState.BufferedEventCount += 1;

            // Drain and verify.

            await mockBufferedProducer.Object.DrainAndPublishPartitionEvents(partitionState, null, cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
            Assert.That(partitionState.BufferedEventCount, Is.EqualTo(0), "The partition state should have been drained, but has a count.");
            Assert.That(partitionState.TryReadEvent(out _), Is.False, "The partition state should have been drained, but had an event.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.DrainAndPublishPartitionEvents" /> method.
        /// </summary>
        ///
        [Test]
        public async Task DrainAndPublishPartitionEventsIvokesTheHandlerWhenPublishingFails()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedPartition = "4";
            var expectedException = new AccessViolationException("My access has been violated.");
            var expectedEvents = EventGenerator.CreateSmallEvents(10).ToList();
            var capturedFailArgs = default(SendEventBatchFailedEventArgs);
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventHubBufferedProducerClientOptions();
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns<CreateBatchOptions, CancellationToken>((options, token) => new ValueTask<EventDataBatch>(EventHubsModelFactory.EventDataBatch(1_048_576, new List<EventData>(), options)));

            mockProducer
                .Setup(producer => producer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Throws(expectedException);

            mockBufferedProducer.Object.SendEventBatchFailedAsync += args =>
            {
                capturedFailArgs = args;
                completionSource.TrySetResult(true);
                return Task.CompletedTask;
            };

            // Enqueue the events that are expected to be returned.

            foreach (var eventData in expectedEvents)
            {
                await partitionState.PendingEventsWriter.WriteAsync(eventData, cancellationSource.Token);
                partitionState.BufferedEventCount += 1;
            }

            // Drain and verify.

            await mockBufferedProducer.Object.DrainAndPublishPartitionEvents(partitionState, null, cancellationSource.Token);
            await completionSource.Task;

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
            Assert.That(capturedFailArgs, Is.Not.Null, "A set of failure args should have been captured.");
            Assert.That(capturedFailArgs.EventBatch.Count, Is.EqualTo(expectedEvents.Count), "The number of events sent to the handler should match.");
            Assert.That(capturedFailArgs.Exception, Is.SameAs(expectedException), "The exception sent to the handler should match.");

            // Adding to the batch results in cloning the events; the data should match but the
            // reference will differ.

            for (var index = 0; index < capturedFailArgs.EventBatch.Count; ++index)
            {
                Assert.That(capturedFailArgs.EventBatch[index].IsEquivalentTo(expectedEvents[index]), Is.True, $"The event at index: [{ index }] did not match the expected event.");
            }

            mockProducer
                .Verify(producer => producer.SendAsync(
                    It.Is<EventDataBatch>(value => value.SendOptions.PartitionId == expectedPartition),
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.DrainAndPublishPartitionEvents" /> method.
        /// </summary>
        ///
        [Test]
        public async Task DrainAndPublishPartitionEventsFailsAnEventTooLargeToBePublished()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedPartition = "4";
            var expectedEvent = EventGenerator.CreateSmallEvents(1).First();
            var capturedFailArgs = default(SendEventBatchFailedEventArgs);
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var options = new EventHubBufferedProducerClientOptions();
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns<CreateBatchOptions, CancellationToken>((options, token) => new ValueTask<EventDataBatch>(EventHubsModelFactory.EventDataBatch(1_048_576, new List<EventData>(), options, _ => false)));

            mockProducer
                .Setup(producer => producer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            mockBufferedProducer.Object.SendEventBatchFailedAsync += args =>
            {
                capturedFailArgs = args;
                completionSource.TrySetResult(true);
                return Task.CompletedTask;
            };

            // Enqueue the events that are expected to be returned.

            await partitionState.PendingEventsWriter.WriteAsync(expectedEvent, cancellationSource.Token);
            partitionState.BufferedEventCount = 1;

            // Drain and verify.

            await mockBufferedProducer.Object.DrainAndPublishPartitionEvents(partitionState, null, cancellationSource.Token);
            await completionSource.Task;

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
            Assert.That(capturedFailArgs, Is.Not.Null, "A set of failure args should have been captured.");
            Assert.That(capturedFailArgs.EventBatch.Count, Is.EqualTo(1), "The number of events sent to the handler should match.");
            Assert.That(capturedFailArgs.EventBatch[0].IsEquivalentTo(expectedEvent), Is.True, "The failed event did not match the expected event.");

            var eventHubsException = (EventHubsException)capturedFailArgs.Exception;
            Assert.That(eventHubsException.Reason, Is.EqualTo(EventHubsException.FailureReason.MessageSizeExceeded), "The exception should indicate that the message is too large.");
            Assert.That(eventHubsException.IsTransient, Is.False, "The exception should not be transient.");

            mockProducer
                .Verify(producer => producer.SendAsync(
                    It.Is<EventDataBatch>(value => value.SendOptions.PartitionId == expectedPartition),
                    It.IsAny<CancellationToken>()),
                Times.Never);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.DrainAndPublishPartitionEvents" /> method.
        /// </summary>
        ///
        [Test]
        public async Task DrainAndPublishPartitionEventsLogsTheOperation()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedPartition = "4";
            var options = new EventHubBufferedProducerClientOptions();
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns<CreateBatchOptions, CancellationToken>((options, token) => new ValueTask<EventDataBatch>(EventHubsModelFactory.EventDataBatch(1_048_576, new List<EventData>(), options)));

            mockProducer
                .Setup(producer => producer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            mockBufferedProducer.Object.Logger = mockLogger.Object;

            // Drain and verify.

            await mockBufferedProducer.Object.DrainAndPublishPartitionEvents(partitionState, null, cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");

            mockLogger
                .Verify(log => log.BufferedProducerDrainStart(
                    mockBufferedProducer.Object.Identifier,
                    mockBufferedProducer.Object.EventHubName,
                    expectedPartition,
                    It.IsAny<string>()),
                Times.Once);

            mockLogger
                .Verify(log => log.BufferedProducerDrainComplete(
                    mockBufferedProducer.Object.Identifier,
                    mockBufferedProducer.Object.EventHubName,
                    expectedPartition,
                    It.IsAny<string>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of theDrainAndPublishPartitionEvents method.
        /// </summary>
        ///
        [Test]
        public async Task DrainAndPublishPartitionEventsLogsErrors()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var expectedPartition = "4";
            var expectedException = new DivideByZeroException("You have just created a black hole.");
            var options = new EventHubBufferedProducerClientOptions();
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Throws(expectedException);

            mockBufferedProducer.Object.Logger = mockLogger.Object;

            // Drain and verify.

            await mockBufferedProducer.Object.DrainAndPublishPartitionEvents(partitionState, null, cancellationSource.Token);
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");

            mockLogger
                .Verify(log => log.BufferedProducerDrainError(
                    mockBufferedProducer.Object.Identifier,
                    mockBufferedProducer.Object.EventHubName,
                    expectedPartition,
                    It.IsAny<string>(),
                    expectedException.Message),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.DrainAndPublishPartitionEvents" /> method.
        /// </summary>
        ///
        [Test]
        public async Task DrainAndPublishPartitionEventsLogsPublishingOperations()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var publishedEventsCount = 0;
            var expectedPartition = "4";
            var expectedEvents = EventGenerator.CreateSmallEvents(10).ToList();
            var options = new EventHubBufferedProducerClientOptions { MaximumWaitTime = TimeSpan.FromMilliseconds(150) };
            var partitionState = new EventHubBufferedProducerClient.PartitionPublishingState(expectedPartition, options);
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, options) { CallBase = true };

            mockProducer
                .Setup(producer => producer.CreateBatchAsync(It.IsAny<CreateBatchOptions>(), It.IsAny<CancellationToken>()))
                .Returns<CreateBatchOptions, CancellationToken>((options, token) => new ValueTask<EventDataBatch>(EventHubsModelFactory.EventDataBatch(1_048_576, new List<EventData>(), options)));

            mockProducer
                .Setup(producer => producer.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Callback<EventDataBatch, CancellationToken>((batch, token) => publishedEventsCount = batch.Count)
                .Returns(Task.CompletedTask);

            mockBufferedProducer.Object.Logger = mockLogger.Object;

            // Enqueue the events that are expected to be returned.

            foreach (var eventData in expectedEvents)
            {
                await partitionState.PendingEventsWriter.WriteAsync(eventData, cancellationSource.Token);
                partitionState.BufferedEventCount += 1;
            }

            // Drain and verify.

            await mockBufferedProducer.Object.DrainAndPublishPartitionEvents(partitionState, null, cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been requested.");
            Assert.That(publishedEventsCount, Is.EqualTo(expectedEvents.Count), "The number of events published should match.");

            mockLogger
                .Verify(log => log.BufferedProducerEventBatchPublishStart(
                    mockBufferedProducer.Object.Identifier,
                    mockBufferedProducer.Object.EventHubName,
                    expectedPartition,
                    It.IsAny<string>()),
                Times.Once);

            mockLogger
                .Verify(log => log.BufferedProducerEventBatchPublishComplete(
                    mockBufferedProducer.Object.Identifier,
                    mockBufferedProducer.Object.EventHubName,
                    expectedPartition,
                    It.IsAny<string>(),
                    publishedEventsCount,
                    It.IsAny<double>()),
                Times.Once);

            mockLogger
                .Verify(log => log.BufferedProducerEventBatchPublishEventAdded(
                    mockBufferedProducer.Object.Identifier,
                    mockBufferedProducer.Object.EventHubName,
                    expectedPartition,
                    It.IsAny<string>(),
                    It.Is<int>(value => value <= publishedEventsCount),
                    It.IsAny<double>()),
                Times.Exactly(publishedEventsCount));

            mockLogger
                .Verify(log => log.BufferedProducerEventBatchPublishNoEventRead(
                    mockBufferedProducer.Object.Identifier,
                    mockBufferedProducer.Object.EventHubName,
                    expectedPartition,
                    It.IsAny<string>(),
                    It.IsAny<double>(),
                    It.IsAny<double>()),
                Times.Once);
        }

        /// <summary>
        ///   Sets the non-public background management task field on the specified
        ///   client instance.
        /// </summary>
        ///
        private void SetBackgroundManagementTask(EventHubBufferedProducerClient client,
                                                 Task backgroundManagementTask) =>
            typeof(EventHubBufferedProducerClient)
                .GetField("_producerManagementTask", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(client, backgroundManagementTask);

        /// <summary>
        ///   Sets the non-public field for the count of total buffered events on the
        ///   specified client instance.
        /// </summary>
        ///
        private void SetTotalBufferedEventCount(EventHubBufferedProducerClient client,
                                                int bufferedEventCount) =>
            typeof(EventHubBufferedProducerClient)
                .GetField("_totalBufferedEventCount", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(client, bufferedEventCount);

        /// <summary>
        ///   Sets the non-public background publishing task field on the specified
        ///   client instance.
        /// </summary>
        ///
        private Task GetBackgroundPublishingTask(EventHubBufferedProducerClient client) =>
            (Task)
                typeof(EventHubBufferedProducerClient)
                    .GetField("_publishingTask", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(client);

        /// <summary>
        ///   Sets the non-public background publishing task field on the specified
        ///   client instance.
        /// </summary>
        ///
        private void SetBackgroundPublishingTask(EventHubBufferedProducerClient client,
                                                 Task backgroundPublishingTask) =>
            typeof(EventHubBufferedProducerClient)
                .GetField("_publishingTask", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(client, backgroundPublishingTask);

        /// <summary>
        ///   Sets the non-public sentinel flag that controls whether handler registrations are
        ///   locked for the specified client instance.
        /// </summary>
        ///
        private void SetHandlerLocked(EventHubBufferedProducerClient client,
                                      bool areHandlersLocked) =>
            typeof(EventHubBufferedProducerClient)
                .GetField("_areHandlersLocked", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(client, areHandlersLocked);

        /// <summary>
        ///   Invokes the non-public <c>StartPublishingAsync</c> method on the specified
        ///   client instance.
        /// </summary>
        ///
        private Task InvokeStartPublishingAsync(EventHubBufferedProducerClient client,
                                                CancellationToken cancellationToken = default) =>
           (Task)
               typeof(EventHubBufferedProducerClient)
               .GetMethod("StartPublishingAsync", BindingFlags.Instance | BindingFlags.NonPublic)
               .Invoke(client, new object[] { cancellationToken });

        /// <summary>
        ///   Invokes the non-public <c>InvokeStopPublishingAsync</c> method on the specified
        ///   client instance.
        /// </summary>
        ///
        private Task InvokeStopPublishingAsync(EventHubBufferedProducerClient client,
                                               CancellationToken cancellationToken = default,
                                               bool cancelActivePublishingOperations = false) =>
           (Task)
               typeof(EventHubBufferedProducerClient)
               .GetMethod("StopPublishingAsync", BindingFlags.Instance | BindingFlags.NonPublic)
               .Invoke(client, new object[] { cancelActivePublishingOperations, cancellationToken });
    }
}
