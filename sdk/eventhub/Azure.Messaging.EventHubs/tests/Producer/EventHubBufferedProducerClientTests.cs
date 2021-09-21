// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
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
            var bufferedProducer = new EventHubBufferedProducerClient(mockProducer.Object);

            Func<SendEventBatchSucceededEventArgs, Task> successHandler = args => Task.CompletedTask;
            Func<SendEventBatchFailedEventArgs, Task> failHandler = args => Task.CompletedTask;

            bufferedProducer.SendEventBatchSucceededAsync += successHandler;
            bufferedProducer.SendEventBatchFailedAsync += failHandler;

            bufferedProducer.IsPublishing = true;

            Assert.That(() => bufferedProducer.SendEventBatchSucceededAsync -= successHandler, Throws.InstanceOf<NotSupportedException>(), "The success handler should not allow unregistering when publishing is active.");
            Assert.That(() => bufferedProducer.SendEventBatchFailedAsync -= failHandler, Throws.InstanceOf<NotSupportedException>(), "The failure handler should not allow unregistering when publishing is active.");
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

            mockBufferedProducer.Object.IsPublishing = false;
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

            mockBufferedProducer.Object.IsPublishing = true;
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

            mockBufferedProducer.Object.IsPublishing = true;
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
            mockBufferedProducer.Object.IsPublishing = true;

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
            mockBufferedProducer.Object.IsPublishing = true;

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
        public async Task CloseLogsErrorsIndependently()
        {
            var expectedNamespace = "fakeNS";
            var expectedEventHub = "fakeHub";
            var expectedIdentifier = "abc123";
            var expectedCloseErrorMessage = "OMG WTF BBQ!";
            var expectedFlushErrorMessage = "Did you know flushing swirls the water in the opposite direction in Australia?";
            var mockLogger = new Mock<EventHubsEventSource>();
            var mockProducer = new Mock<EventHubProducerClient>(expectedNamespace, expectedEventHub, Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = expectedIdentifier });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockBufferedProducer.Object.Logger = mockLogger.Object;
            mockBufferedProducer.Object.IsPublishing = true;

            mockProducer
                .Setup(producer => producer.CloseAsync(It.IsAny<CancellationToken>()))
                .ThrowsAsync(new FormatException(expectedCloseErrorMessage));

            mockBufferedProducer
                .Setup(producer => producer.FlushInternalAsync(It.IsAny<CancellationToken>()))
                .ThrowsAsync(new NotFiniteNumberException(expectedFlushErrorMessage, 123));

            await mockBufferedProducer.Object.CloseAsync().IgnoreExceptions();

            mockLogger
                .Verify(log => log.ClientCloseError(
                    nameof(EventHubBufferedProducerClient),
                    expectedEventHub,
                    expectedIdentifier,
                    expectedCloseErrorMessage),
                Times.Once);

            mockLogger
                .Verify(log => log.ClientCloseError(
                    nameof(EventHubBufferedProducerClient),
                    expectedEventHub,
                    expectedIdentifier,
                    expectedFlushErrorMessage),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubBufferedProducerClient.CloseAsync" />.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CloseTakesNoActionWhenCalledMultipleTimes(bool flush)
        {
            var expectedNamespace = "fakeNS";
            var expectedEventHub = "fakeHub";
            var expectedIdentifier = "abc123";
            var mockProducer = new Mock<EventHubProducerClient>(expectedNamespace, expectedEventHub, Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = expectedIdentifier });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            mockBufferedProducer.Object.IsPublishing = true;

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
        public async Task FlushAsyncValidatesNotClosed()
        {
            var mockProducer = new Mock<EventHubProducerClient>("fakeNS", "fakeHub", Mock.Of<TokenCredential>(), new EventHubProducerClientOptions { Identifier = "abc123" });
            var mockBufferedProducer = new Mock<EventHubBufferedProducerClient>(mockProducer.Object, default(EventHubBufferedProducerClientOptions)) { CallBase = true };

            await mockBufferedProducer.Object.CloseAsync(true);

            Assert.That(async () => await mockBufferedProducer.Object.FlushAsync(), Throws.InstanceOf<EventHubsException>(), "Flush should ensure the client is not closed.");
            mockBufferedProducer.Verify(producer => producer.FlushInternalAsync(CancellationToken.None), Times.Never);
        }
    }
}
