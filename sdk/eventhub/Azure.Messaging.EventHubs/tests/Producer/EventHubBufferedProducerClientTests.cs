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
using Azure.Messaging.EventHubs.Amqp;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Diagnostics;
using Azure.Messaging.EventHubs.Producer;
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
        [TestCase("sb://test.place.com")]
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

            var mockProducer = new Mock<EventHubProducerClient>();
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

            var mockProducer = new Mock<EventHubProducerClient>();
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

            var mockProducer = new Mock<EventHubProducerClient>();
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

            var mockProducer = new Mock<EventHubProducerClient>();
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

            var mockProducer = new Mock<EventHubProducerClient>();
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

            var expectedPartition = "0";
            var mockProducer = new Mock<EventHubProducerClient>();
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
            var mockProducer = new Mock<EventHubProducerClient>();
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
            var mockProducer = new Mock<EventHubProducerClient>();
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
            var mockProducer = new Mock<EventHubProducerClient>();
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
            var mockProducer = new Mock<EventHubProducerClient>();
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
            var mockProducer = new Mock<EventHubProducerClient>();
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
            var mockProducer = new Mock<EventHubProducerClient>();
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
        public async Task DisposIsSafeToCallMultipleTimes()
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
        public async Task CloseAsyncDoesNotFlushOrClearWhenNotPublishing()
        {
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockBufferedProducer
                .SetupGet(producer => producer.IsPublishing)
                .Returns(false);

            await mockBufferedProducer.Object.CloseAsync(true);

            mockBufferedProducer.Verify(producer => producer.FlushInternalAsync(It.IsAny<CancellationToken>()), Times.Never);
            mockBufferedProducer.Verify(producer => producer.ClearInternalAsync(It.IsAny<CancellationToken>()), Times.Never);
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
            mockBufferedProducer.Verify(producer => producer.ClearInternalAsync(It.IsAny<CancellationToken>()), Times.Never);
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

            mockBufferedProducer.Verify(producer => producer.ClearInternalAsync(CancellationToken.None), Times.Once);
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
        public async Task CloseAsyncUnregistersTheEventHandlers()
        {
            using var cancellationSource = new CancellationTokenSource();

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
                .Setup(producer => producer.ClearInternalAsync(It.IsAny<CancellationToken>()))
                .ThrowsAsync(new NotFiniteNumberException(expectedErrorMessage, 123));

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
        public async Task CloseAbortsOnFlushErrors()
        {
            var expectedNamespace = "fakeNS";
            var expectedEventHub = "fakeHub";
            var expectedIdentifier = "abc123";
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>(expectedNamespace, expectedEventHub, Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = expectedIdentifier });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockBufferedProducer.Object.Logger = mockLogger.Object;

            mockBufferedProducer
                .SetupGet(producer => producer.IsPublishing)
                .Returns(true);

            mockBufferedProducer
                .SetupSequence(producer => producer.FlushInternalAsync(It.IsAny<CancellationToken>()))
                .Throws(new NotFiniteNumberException("OH NOES!", 123))
                .Returns(Task.CompletedTask);

            Assert.That(async () => await mockBufferedProducer.Object.CloseAsync(), Throws.InstanceOf<NotFiniteNumberException>(), "Closing should have surfaced the flush exception.");
            Assert.That(mockBufferedProducer.Object.IsClosed, Is.False, "The producer should have aborted the close on flush failure.");

            mockLogger
                .Verify(log => log.BufferedProducerBackgroundProcessingStop(
                    It.IsAny<string>(),
                    It.IsAny<string>()),
                Times.Never,
                "There should have been no attempt to stop background processing.");

            await mockBufferedProducer.Object.CloseAsync();
            Assert.That(mockBufferedProducer.Object.IsClosed, Is.True, "The producer should have closed with flush success.");
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
                mockBufferedProducer.Verify(producer => producer.ClearInternalAsync(It.IsAny<CancellationToken>()), Times.Never);
            }
            else
            {
                mockBufferedProducer.Verify(producer => producer.FlushInternalAsync(It.IsAny<CancellationToken>()), Times.Never);
                mockBufferedProducer.Verify(producer => producer.ClearInternalAsync(It.IsAny<CancellationToken>()), Times.Once);
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.CloseAsync" />.
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
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.CloseAsync" />.
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

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .Throws(expectedException)
                .Verifiable("Partition identifiers should have been requested");

            Assert.That(async () => await InvokeStartPublishingAsync(mockBufferedProducer.Object, cancellationSource.Token), Throws.TypeOf(expectedException.GetType()), "The attempt to start publishing should have surfaced an exception.");

            mockEventSource
                .Verify(log => log.BufferedProducerBackgroundProcessingStartError(
                    mockProducer.Object.Identifier,
                    mockProducer.Object.EventHubName,
                    expectedErrorMessage),
                Times.Once);

            mockProducer.VerifyAll();
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
            var mockProducer = new Mock<EventHubProducerClient>();
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

            var mockProducer = new Mock<EventHubProducerClient>();
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
            var mockProducer = new Mock<EventHubProducerClient>();
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
            var mockProducer = new Mock<EventHubProducerClient>();
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;
            Assert.That(async () => await bufferedProducer.EnqueueEventsAsync(events, invalidOptions), Throws.InstanceOf<InvalidOperationException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventsAsync" />.
        /// </summary>
        ///
        [Test]
        public void EnqueueEventsAsyncValidatesFailHandler()
        {
            var events = new[] { new EventData("One"), new EventData("Two") };
            var mockProducer = new Mock<EventHubProducerClient>();
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
            var mockProducer = new Mock<EventHubProducerClient>();
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
            var events = new[] { new EventData("One"), new EventData("Two") };
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { partitionId });

            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;

            try
            {
                await bufferedProducer.EnqueueEventsAsync(events, cancellationSource.Token);
                Assert.That(bufferedProducer.ActivePartitionPublishers.TryGetValue(partitionId, out var partitionPublisher), Is.True, "A publisher should have been registered for the partition.");

                var readEventCount = 0;
                var reader = partitionPublisher.PendingEvents.Reader;

                while (reader.TryRead(out var readEvent))
                {
                    ++readEventCount;
                    Assert.That(events.SingleOrDefault(item => item.EventBody.ToString() == readEvent.EventBody.ToString()), Is.Not.Null, $"The event with body: [{ readEvent.EventBody }] was not in the source.");
                    Assert.That(readEvent.GetRawAmqpMessage().GetPartitionKey(null), Is.Null, $"The partition key should not have been set for the event with body: [{ readEvent.EventBody }].");
                }

                Assert.That(readEventCount, Is.EqualTo(events.Length), "The number of events read should match the source length.");
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
        public async Task EnqueueEventsAsyncEnqueuesWithAPartitionKey()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "3";
            var partitionKey = "test-key";
            var events = new[] { new EventData("One"), new EventData("Two") };
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { partitionId });

            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;

            try
            {
                var options = new EnqueueEventOptions { PartitionKey = partitionKey };
                await bufferedProducer.EnqueueEventsAsync(events, options, cancellationSource.Token);

                Assert.That(bufferedProducer.ActivePartitionPublishers.TryGetValue(partitionId, out var partitionPublisher), Is.True, "A publisher should have been registered for the partition.");

                var readEventCount = 0;
                var reader = partitionPublisher.PendingEvents.Reader;

                while (reader.TryRead(out var readEvent))
                {
                    ++readEventCount;
                    Assert.That(events.SingleOrDefault(item => item.EventBody.ToString() == readEvent.EventBody.ToString()), Is.Not.Null, $"The event with body: [{ readEvent.EventBody }] was not in the source.");
                    Assert.That(readEvent.GetRawAmqpMessage().GetPartitionKey(null), Is.EqualTo(partitionKey), $"The partition key should have been preserved for the event with body: [{ readEvent.EventBody }].");
                }

                Assert.That(readEventCount, Is.EqualTo(events.Length), "The number of events read should match the source length.");
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
        public async Task EnqueueEventsAsyncEnqueuesWithAPartitionAssignment()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "2";
            var events = new[] { new EventData("One"), new EventData("Two") };
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { "0", partitionId, "1" });

            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;

            try
            {
                var options = new EnqueueEventOptions { PartitionId = partitionId };
                await bufferedProducer.EnqueueEventsAsync(events, options, cancellationSource.Token);

                Assert.That(bufferedProducer.ActivePartitionPublishers.TryGetValue(partitionId, out var partitionPublisher), Is.True, "A publisher should have been registered for the partition.");

                var readEventCount = 0;
                var reader = partitionPublisher.PendingEvents.Reader;

                while (reader.TryRead(out var readEvent))
                {
                    ++readEventCount;
                    Assert.That(events.SingleOrDefault(item => item.EventBody.ToString() == readEvent.EventBody.ToString()), Is.Not.Null, $"The event with body: [{ readEvent.EventBody }] was not in the source.");
                    Assert.That(readEvent.GetRawAmqpMessage().GetPartitionKey(null), Is.Null, $"The partition key should not have been set for the event with body: [{ readEvent.EventBody }].");
                }

                Assert.That(readEventCount, Is.EqualTo(events.Length), "The number of events read should match the source length.");
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
        public async Task EnqueueEventsAsyncWaitsWhenFull()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "4";
            var events = new[] { new EventData("One"), new EventData("Two") };
            var options = new EventHubBufferedProducerClientOptions { MaximumEventBufferLengthPerPartition = 1 };
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducerOptions = new EventHubBufferedProducerClientOptions { MaximumEventBufferLengthPerPartition = 1 };
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object, bufferedProducerOptions);

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { partitionId });

            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;

            try
            {
                // This enqueue will cause the channel to be considered full and block additional enqueues.

                await bufferedProducer.EnqueueEventsAsync(new[] { new EventData("Blocker") }, cancellationSource.Token);

                // Start the task to enqueue events, then delay and ensure that it is still not completed.

                var enqueueTask = bufferedProducer.EnqueueEventsAsync(events, cancellationSource.Token);
                await Task.Delay(TimeSpan.FromSeconds(1), cancellationSource.Token);

                Assert.That(enqueueTask.IsCompleted, Is.False, "The enqueue task should not be completed.");
                Assert.That(bufferedProducer.ActivePartitionPublishers.TryGetValue(partitionId, out var partitionPublisher), Is.True, "A publisher should have been registered for the partition.");

                // Read the blocking event to clear room.  This event shouldn't be in the expected list.

                var readEventCount = 0;
                var reader = partitionPublisher.PendingEvents.Reader;

                Assert.That(reader.TryRead(out var blockerEvent), Is.True, "The blocking event should be available to read immediately.");
                Assert.That(events.SingleOrDefault(item => item.EventBody.ToString() == blockerEvent.EventBody.ToString()), Is.Null, $"The blocking event should not be in the source.");

                ++readEventCount;

                while (readEventCount < events.Length)
                {
                    var readEvent = await reader.ReadAsync(cancellationSource.Token);
                    ++readEventCount;

                    Assert.That(events.SingleOrDefault(item => item.EventBody.ToString() == readEvent.EventBody.ToString()), Is.Not.Null, $"The event with body: [{ readEvent.EventBody }] was not in the source.");
                    Assert.That(readEvent.GetRawAmqpMessage().GetPartitionKey(null), Is.Null, $"The partition key should not have been set for the event with body: [{ readEvent.EventBody }].");

                    cancellationSource.Token.ThrowIfCancellationRequested();
                }

                await enqueueTask;
                Assert.That(readEventCount, Is.EqualTo(events.Length), "The number of events read should match the source length.");
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
                    .Verify(log => log.EventEnqueueStart(
                        mockProducer.Object.EventHubName,
                        string.Empty,
                        It.IsAny<string>()),
                    Times.Once);

                mockLogger
                    .Verify(log => log.EventEnqueueComplete(
                        mockProducer.Object.EventHubName,
                        string.Empty,
                        It.IsAny<string>()),
                    Times.Once);

                mockLogger
                    .Verify(log => log.EventEnqueued(
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
                    .Verify(log => log.EventEnqueueStart(
                        mockProducer.Object.EventHubName,
                        options.PartitionKey,
                        It.IsAny<string>()),
                    Times.Once);

                mockLogger
                    .Verify(log => log.EventEnqueueComplete(
                        mockProducer.Object.EventHubName,
                        options.PartitionKey,
                        It.IsAny<string>()),
                    Times.Once);

                mockLogger
                    .Verify(log => log.EventEnqueued(
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
                    .Verify(log => log.EventEnqueueStart(
                        mockProducer.Object.EventHubName,
                        partitionId,
                        It.IsAny<string>()),
                    Times.Once);

                mockLogger
                    .Verify(log => log.EventEnqueueComplete(
                        mockProducer.Object.EventHubName,
                        partitionId,
                        It.IsAny<string>()),
                    Times.Once);

                mockLogger
                    .Verify(log => log.EventEnqueued(
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
                    .Verify(log => log.EventEnqueueError(
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
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { firstPartitionId, secondPartitionId });

            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;

            try
            {
                Assert.That(bufferedProducer.TotalBufferedEventCount, Is.EqualTo(0), "No events have been enqueued yet.");

                var options = new EnqueueEventOptions { PartitionId = firstPartitionId };
                var count = await bufferedProducer.EnqueueEventsAsync(new[] { new EventData("One") }, options, cancellationSource.Token);
                Assert.That(count, Is.EqualTo(1), "One event has been enqueued.");
                Assert.That(bufferedProducer.GetBufferedEventCount(firstPartitionId), Is.EqualTo(1), $"One event has been enqueued for { firstPartitionId }.");
                Assert.That(bufferedProducer.TotalBufferedEventCount, Is.EqualTo(count), "The count returned by enqueue and the total count should match.");

                options.PartitionId = secondPartitionId;
                count = await bufferedProducer.EnqueueEventsAsync(new[] { new EventData("Two") }, options, cancellationSource.Token);
                Assert.That(count, Is.EqualTo(2), "Two events have been enqueued.");
                Assert.That(bufferedProducer.GetBufferedEventCount(secondPartitionId), Is.EqualTo(1), $"One event has been enqueued for { secondPartitionId }.");
                Assert.That(bufferedProducer.TotalBufferedEventCount, Is.EqualTo(count), "The count returned by enqueue and the total count should match.");

                options.PartitionId = secondPartitionId;
                count = await bufferedProducer.EnqueueEventsAsync(new[] { new EventData("Three") }, options, cancellationSource.Token);
                Assert.That(count, Is.EqualTo(3), "Three events have been enqueued.");
                Assert.That(bufferedProducer.GetBufferedEventCount(secondPartitionId), Is.EqualTo(2), $"Two events have been enqueued for { secondPartitionId }.");
                Assert.That(bufferedProducer.TotalBufferedEventCount, Is.EqualTo(count), "The count returned by enqueue and the total count should match.");
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
        public async Task EnqueueEventAsyncWithoutOptionsDelegatesToTheOptionsOverload()
        {
            using var cancellationSource = new CancellationTokenSource();

            var expectedEvent = new EventData("One");
            var mockProducer = new Mock<EventHubProducerClient>();
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

            var mockProducer = new Mock<EventHubProducerClient>();
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
            var mockProducer = new Mock<EventHubProducerClient>();
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
            var mockProducer = new Mock<EventHubProducerClient>();
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;
            Assert.That(async () => await bufferedProducer.EnqueueEventAsync(new EventData("One"), invalidOptions), Throws.InstanceOf<InvalidOperationException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.EnqueueEventAsync" />.
        /// </summary>
        ///
        [Test]
        public void EnqueueEventAsyncValidatesFailHandler()
        {
            var mockProducer = new Mock<EventHubProducerClient>();
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

            var mockProducer = new Mock<EventHubProducerClient>();
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
            var expectedEvent = new EventData("One");
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { partitionId });

            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;

            try
            {
                await bufferedProducer.EnqueueEventAsync(expectedEvent, cancellationSource.Token);
                Assert.That(bufferedProducer.ActivePartitionPublishers.TryGetValue(partitionId, out var partitionPublisher), Is.True, "A publisher should have been registered for the partition.");

                var readEventCount = 0;
                var reader = partitionPublisher.PendingEvents.Reader;

                while (reader.TryRead(out var readEvent))
                {
                    ++readEventCount;
                    Assert.That(expectedEvent.EventBody.ToString(), Is.EqualTo(readEvent.EventBody.ToString()), $"The event with body: [{ readEvent.EventBody }] was not enqueued.");
                    Assert.That(readEvent.GetRawAmqpMessage().GetPartitionKey(null), Is.Null, $"The partition key should not have been set for the event with body: [{ readEvent.EventBody }].");
                }

                Assert.That(readEventCount, Is.EqualTo(1), "A single event should have been enqueued.");
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
        public async Task EnqueueEventAsyncEnqueuesWithAPartitionKey()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "3";
            var partitionKey = "test-key";
            var expectedEvent = new EventData("One");
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { partitionId });

            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;

            try
            {
                var options = new EnqueueEventOptions { PartitionKey = partitionKey };
                await bufferedProducer.EnqueueEventAsync(expectedEvent, options, cancellationSource.Token);

                Assert.That(bufferedProducer.ActivePartitionPublishers.TryGetValue(partitionId, out var partitionPublisher), Is.True, "A publisher should have been registered for the partition.");

                var readEventCount = 0;
                var reader = partitionPublisher.PendingEvents.Reader;

                while (reader.TryRead(out var readEvent))
                {
                    ++readEventCount;
                    Assert.That(expectedEvent.EventBody.ToString(), Is.EqualTo(readEvent.EventBody.ToString()), $"The event with body: [{ readEvent.EventBody }] was not enqueued.");
                    Assert.That(readEvent.GetRawAmqpMessage().GetPartitionKey(null), Is.EqualTo(partitionKey), $"The partition key should have been preserved for the event with body: [{ readEvent.EventBody }].");
                }

                Assert.That(readEventCount, Is.EqualTo(1), "A single event should have been enqueued.");
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
        public async Task EnqueueEventAsyncEnqueuesWithAPartitionAssignment()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partitionId = "2";
            var expectedEvent = new EventData("One");
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { "0", partitionId, "1" });

            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;

            try
            {
                var options = new EnqueueEventOptions { PartitionId = partitionId };
                await bufferedProducer.EnqueueEventAsync(expectedEvent, options, cancellationSource.Token);

                Assert.That(bufferedProducer.ActivePartitionPublishers.TryGetValue(partitionId, out var partitionPublisher), Is.True, "A publisher should have been registered for the partition.");

                var readEventCount = 0;
                var reader = partitionPublisher.PendingEvents.Reader;

                while (reader.TryRead(out var readEvent))
                {
                    ++readEventCount;
                    Assert.That(expectedEvent.EventBody.ToString(), Is.EqualTo(readEvent.EventBody.ToString()), $"The event with body: [{ readEvent.EventBody }] was not enqueued.");
                    Assert.That(readEvent.GetRawAmqpMessage().GetPartitionKey(null), Is.Null, $"The partition key should not have been set for the event with body: [{ readEvent.EventBody }].");
                }

                Assert.That(readEventCount, Is.EqualTo(1), "A single event should have been enqueued.");
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
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object, bufferedProducerOptions);

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { partitionId });

            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;

            try
            {
                // This enqueue will cause the channel to be considered full and block additional enqueues.

                await bufferedProducer.EnqueueEventAsync(blockerEvent, cancellationSource.Token);

                // Start the task to enqueue events, then delay and ensure that it is still not completed.

                var enqueueTask = bufferedProducer.EnqueueEventAsync(expectedEvent, cancellationSource.Token);
                await Task.Delay(TimeSpan.FromSeconds(1), cancellationSource.Token);

                Assert.That(enqueueTask.IsCompleted, Is.False, "The enqueue task should not be completed.");
                Assert.That(bufferedProducer.ActivePartitionPublishers.TryGetValue(partitionId, out var partitionPublisher), Is.True, "A publisher should have been registered for the partition.");

                // Read the blocking event to clear room.  This event shouldn't be in the expected list.

                var reader = partitionPublisher.PendingEvents.Reader;

                Assert.That(reader.TryRead(out var readBlockerEvent), Is.True, "The blocking event should be available to read immediately.");
                Assert.That(blockerEvent.EventBody.ToString(), Is.EqualTo(readBlockerEvent.EventBody.ToString()), $"The event with body: [{ readBlockerEvent.EventBody }] was not enqueued.");

                var readEvent = await reader.ReadAsync(cancellationSource.Token);

                Assert.That(expectedEvent.EventBody.ToString(), Is.EqualTo(readEvent.EventBody.ToString()), $"The event with body: [{ readEvent.EventBody }] was not enqueued.");
                Assert.That(readEvent.GetRawAmqpMessage().GetPartitionKey(null), Is.Null, $"The partition key should not have been set for the event with body: [{ readEvent.EventBody }].");

                await enqueueTask;
                Assert.That(reader.TryRead(out _), Is.False, "Other than the blocker, a single event should have been enqueued.");
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
                    .Verify(log => log.EventEnqueueStart(
                        mockProducer.Object.EventHubName,
                        string.Empty,
                        It.IsAny<string>()),
                    Times.Once);

                mockLogger
                    .Verify(log => log.EventEnqueueComplete(
                        mockProducer.Object.EventHubName,
                        string.Empty,
                        It.IsAny<string>()),
                    Times.Once);

                mockLogger
                    .Verify(log => log.EventEnqueued(
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
                await bufferedProducer.EnqueueEventAsync(expectedEvent, options, cancellationSource.Token);

                mockLogger
                    .Verify(log => log.EventEnqueueStart(
                        mockProducer.Object.EventHubName,
                        options.PartitionKey,
                        It.IsAny<string>()),
                    Times.Once);

                mockLogger
                    .Verify(log => log.EventEnqueueComplete(
                        mockProducer.Object.EventHubName,
                        options.PartitionKey,
                        It.IsAny<string>()),
                    Times.Once);

                mockLogger
                    .Verify(log => log.EventEnqueued(
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
                await bufferedProducer.EnqueueEventAsync(expectedEvent, options, cancellationSource.Token);

                mockLogger
                    .Verify(log => log.EventEnqueueStart(
                        mockProducer.Object.EventHubName,
                        partitionId,
                        It.IsAny<string>()),
                    Times.Once);

                mockLogger
                    .Verify(log => log.EventEnqueueComplete(
                        mockProducer.Object.EventHubName,
                        partitionId,
                        It.IsAny<string>()),
                    Times.Once);

                mockLogger
                    .Verify(log => log.EventEnqueued(
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
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
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

                var partitionPublisher = new EventHubBufferedProducerClient.PartitionPublisher(partitionId, new EventHubBufferedProducerClientOptions());
                partitionPublisher.PendingEvents.Writer.TryComplete();

                bufferedProducer.ActivePartitionPublishers[partitionId] = partitionPublisher;

                var options = new EnqueueEventOptions { PartitionKey = "some-key" };
                Assert.That(async () => await bufferedProducer.EnqueueEventAsync(new EventData("Two"), options, cancellationSource.Token), Throws.InstanceOf<ChannelClosedException>(), "An exception should have been surfaced.");

                mockLogger
                    .Verify(log => log.EventEnqueueError(
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
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            mockProducer
                .Setup(producer => producer.GetPartitionIdsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new[] { firstPartitionId, secondPartitionId });

            bufferedProducer.SendEventBatchFailedAsync += args => Task.CompletedTask;

            try
            {
                Assert.That(bufferedProducer.TotalBufferedEventCount, Is.EqualTo(0), "No events have been enqueued yet.");

                var options = new EnqueueEventOptions { PartitionId = firstPartitionId };
                var count = await bufferedProducer.EnqueueEventAsync(new EventData("One"), options, cancellationSource.Token);
                Assert.That(count, Is.EqualTo(1), "One event has been enqueued.");
                Assert.That(bufferedProducer.GetBufferedEventCount(firstPartitionId), Is.EqualTo(1), $"One event has been enqueued for { firstPartitionId }.");
                Assert.That(bufferedProducer.TotalBufferedEventCount, Is.EqualTo(count), "The count returned by enqueue and the total count should match.");

                options.PartitionId = secondPartitionId;
                count = await bufferedProducer.EnqueueEventAsync(new EventData("Two"), options, cancellationSource.Token);
                Assert.That(count, Is.EqualTo(2), "Two events have been enqueued.");
                Assert.That(bufferedProducer.GetBufferedEventCount(secondPartitionId), Is.EqualTo(1), $"One event has been enqueued for { secondPartitionId }.");
                Assert.That(bufferedProducer.TotalBufferedEventCount, Is.EqualTo(count), "The count returned by enqueue and the total count should match.");

                options.PartitionId = secondPartitionId;
                count = await bufferedProducer.EnqueueEventAsync(new EventData("Three"), options, cancellationSource.Token);
                Assert.That(count, Is.EqualTo(3), "Three events have been enqueued.");
                Assert.That(bufferedProducer.GetBufferedEventCount(secondPartitionId), Is.EqualTo(2), $"Two events have been enqueued for { secondPartitionId }.");
                Assert.That(bufferedProducer.TotalBufferedEventCount, Is.EqualTo(count), "The count returned by enqueue and the total count should match.");
            }
            finally
            {
                await bufferedProducer.CloseAsync(false).IgnoreExceptions();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.GetBufferedEventCount" />.
        /// </summary>
        ///
        [Test]
        public void GetBufferedEventCountValidatesNotClosed()
        {
            var mockProducer = new Mock<EventHubProducerClient>();
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
            var mockProducer = new Mock<EventHubProducerClient>();
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            Assert.That(() => bufferedProducer.GetBufferedEventCount(partitionId), Throws.InstanceOf<ArgumentException>());
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
                                               CancellationToken cancellationToken = default) =>
           (Task)
               typeof(EventHubBufferedProducerClient)
               .GetMethod("StopPublishingAsync", BindingFlags.Instance | BindingFlags.NonPublic)
               .Invoke(client, new object[] { cancellationToken });
    }
}
