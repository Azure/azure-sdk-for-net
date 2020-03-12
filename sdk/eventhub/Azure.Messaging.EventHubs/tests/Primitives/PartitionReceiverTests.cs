// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;
using Azure.Messaging.EventHubs.Primitives;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="PartitionReceiver" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class PartitionReceiverTests
    {
        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheConsumerGroup(string consumerGroup)
        {
            Assert.That(() => new PartitionReceiver(consumerGroup, "pid", EventPosition.Earliest, "cs"), Throws.InstanceOf<ArgumentException>(), "The connection string constructor without event hub should perform validation.");
            Assert.That(() => new PartitionReceiver(consumerGroup, "pid", EventPosition.Earliest, "cs", "eh"), Throws.InstanceOf<ArgumentException>(), "The connection string constructor with event hub should perform validation.");
            Assert.That(() => new PartitionReceiver(consumerGroup, "pid", EventPosition.Earliest, "fqns", "eh", Mock.Of<TokenCredential>()), Throws.InstanceOf<ArgumentException>(), "The namespace constructor should perform validation.");
            Assert.That(() => new PartitionReceiver(consumerGroup, "pid", EventPosition.Earliest, Mock.Of<EventHubConnection>()), Throws.InstanceOf<ArgumentException>(), "The connection constructor should perform validation.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesThePartitionId(string partitionId)
        {
            Assert.That(() => new PartitionReceiver("cg", partitionId, EventPosition.Earliest, "cs"), Throws.InstanceOf<ArgumentException>(), "The connection string constructor without event hub should perform validation.");
            Assert.That(() => new PartitionReceiver("cg", partitionId, EventPosition.Earliest, "cs", "eh"), Throws.InstanceOf<ArgumentException>(), "The connection string constructor with event hub should perform validation.");
            Assert.That(() => new PartitionReceiver("cg", partitionId, EventPosition.Earliest, "fqns", "eh", Mock.Of<TokenCredential>()), Throws.InstanceOf<ArgumentException>(), "The namespace constructor should perform validation.");
            Assert.That(() => new PartitionReceiver("cg", partitionId, EventPosition.Earliest, Mock.Of<EventHubConnection>()), Throws.InstanceOf<ArgumentException>(), "The connection constructor should perform validation.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheConnectionString(string connectionString)
        {
            Assert.That(() => new PartitionReceiver("cg", "pid", EventPosition.Earliest, connectionString), Throws.InstanceOf<ArgumentException>(), "The constructor without event hub should perform validation.");
            Assert.That(() => new PartitionReceiver("cg", "pid", EventPosition.Earliest, connectionString, "eh"), Throws.InstanceOf<ArgumentException>(), "The constructor with event hub should perform validation.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheFullyQualifiedNamespace(string fullyQualifiedNamespace)
        {
            Assert.That(() => new PartitionReceiver("cg", "pid", EventPosition.Earliest, fullyQualifiedNamespace, "eh", Mock.Of<TokenCredential>()), Throws.InstanceOf<ArgumentException>(), "The constructor should perform validation.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheEventHubName(string eventHubName)
        {
            Assert.That(() => new PartitionReceiver("cg", "pid", EventPosition.Earliest, "fqns", eventHubName, Mock.Of<TokenCredential>()), Throws.InstanceOf<ArgumentException>(), "The constructor should perform validation.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheCredential()
        {
            Assert.That(() => new PartitionReceiver("cg", "pid", EventPosition.Earliest, "fqns", "eh", default(TokenCredential)), Throws.InstanceOf<ArgumentNullException>(), "The constructor should perform validation.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheConnection()
        {
            Assert.That(() => new PartitionReceiver("cg", "pid", EventPosition.Earliest, default(EventHubConnection)), Throws.InstanceOf<ArgumentNullException>(), "The constructor should perform validation.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorSetsTheRetryPolicy()
        {
            var expected = Mock.Of<EventHubsRetryPolicy>();
            var options = new PartitionReceiverOptions { RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = expected } };
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, connectionString, options);

            Assert.That(GetRetryPolicy(receiver), Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ExpandedConstructorSetsTheRetryPolicy()
        {
            var expected = Mock.Of<EventHubsRetryPolicy>();
            var options = new PartitionReceiverOptions { RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = expected } };
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, "fqns", "eh", Mock.Of<TokenCredential>(), options);

            Assert.That(GetRetryPolicy(receiver), Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionConstructorSetsTheRetryPolicy()
        {
            var expected = Mock.Of<EventHubsRetryPolicy>();
            var options = new PartitionReceiverOptions { RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = expected } };
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, Mock.Of<EventHubConnection>(), options);

            Assert.That(GetRetryPolicy(receiver), Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorCreatesDefaultOptions()
        {
            var expected = new PartitionReceiverOptions().RetryOptions;
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, connectionString);

            var policy = GetRetryPolicy(receiver);
            Assert.That(policy, Is.Not.Null, "There should have been a retry policy set.");
            Assert.That(policy, Is.InstanceOf<BasicRetryPolicy>(), "The default retry policy should be a basic policy.");

            var actual = ((BasicRetryPolicy)policy).Options;
            Assert.That(actual.IsEquivalentTo(expected), Is.True, "The default retry policy should be based on the default retry options.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ExpandedConstructorCreatesDefaultOptions()
        {
            var expected = new PartitionReceiverOptions().RetryOptions;
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, "fqns", "eh", Mock.Of<TokenCredential>());

            var policy = GetRetryPolicy(receiver);
            Assert.That(policy, Is.Not.Null, "There should have been a retry policy set.");
            Assert.That(policy, Is.InstanceOf<BasicRetryPolicy>(), "The default retry policy should be a basic policy.");

            var actual = ((BasicRetryPolicy)policy).Options;
            Assert.That(actual.IsEquivalentTo(expected), Is.True, "The default retry policy should be based on the default retry options.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionConstructorCreatesDefaultOptions()
        {
            var expected = new PartitionReceiverOptions().RetryOptions;
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, Mock.Of<EventHubConnection>());

            var policy = GetRetryPolicy(receiver);
            Assert.That(policy, Is.Not.Null, "There should have been a retry policy set.");
            Assert.That(policy, Is.InstanceOf<BasicRetryPolicy>(), "The default retry policy should be a basic policy.");

            var actual = ((BasicRetryPolicy)policy).Options;
            Assert.That(actual.IsEquivalentTo(expected), Is.True, "The default retry policy should be based on the default retry options.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorSetsTheConsumerGroup()
        {
            var consumerGroup = "SomeGroup";
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var receiver = new PartitionReceiver(consumerGroup, "pid", EventPosition.Earliest, connectionString);

            Assert.That(receiver.ConsumerGroup, Is.EqualTo(consumerGroup));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ExpandedConstructorSetsTheConsumerGroup()
        {
            var consumerGroup = "SomeGroup";
            var receiver = new PartitionReceiver(consumerGroup, "pid", EventPosition.Earliest, "fqns", "eh", Mock.Of<TokenCredential>());

            Assert.That(receiver.ConsumerGroup, Is.EqualTo(consumerGroup));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionConstructorSetsTheConsumerGroup()
        {
            var consumerGroup = "SomeGroup";
            var receiver = new PartitionReceiver(consumerGroup, "pid", EventPosition.Earliest, Mock.Of<EventHubConnection>());

            Assert.That(receiver.ConsumerGroup, Is.EqualTo(consumerGroup));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorSetsThePartitionId()
        {
            var partitionId = "partitionId";
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var receiver = new PartitionReceiver("cg", partitionId, EventPosition.Earliest, connectionString);

            Assert.That(receiver.PartitionId, Is.EqualTo(partitionId));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ExpandedConstructorSetsThePartitionId()
        {
            var partitionId = "partitionId";
            var receiver = new PartitionReceiver("cg", partitionId, EventPosition.Earliest, "fqns", "eh", Mock.Of<TokenCredential>());

            Assert.That(receiver.PartitionId, Is.EqualTo(partitionId));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionConstructorSetsThePartitionId()
        {
            var partitionId = "partitionId";
            var receiver = new PartitionReceiver("cg", partitionId, EventPosition.Earliest, Mock.Of<EventHubConnection>());

            Assert.That(receiver.PartitionId, Is.EqualTo(partitionId));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorSetsTheInitialPosition()
        {
            var expectedPosition = EventPosition.FromOffset(999);
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var receiver = new PartitionReceiver("cg", "pid", expectedPosition, connectionString);

            Assert.That(receiver.InitialPosition, Is.EqualTo(expectedPosition));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ExpandedConstructorSetsTheInitialPosition()
        {
            var expectedPosition = EventPosition.FromOffset(999);
            var receiver = new PartitionReceiver("cg", "pid", expectedPosition, "fqns", "eh", Mock.Of<TokenCredential>());

            Assert.That(receiver.InitialPosition, Is.EqualTo(expectedPosition));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionConstructorSetsTheInitialPosition()
        {
            var expectedPosition = EventPosition.FromOffset(999);
            var receiver = new PartitionReceiver("cg", "pid", expectedPosition, Mock.Of<EventHubConnection>());

            Assert.That(receiver.InitialPosition, Is.EqualTo(expectedPosition));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.FullyQualifiedNamespace" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void PartitionReceiverDelegatesForTheFullyQualifiedNamespace()
        {
            var expected = "SomeNamespace";
            var mockConnection = new EventHubConnection(expected, "eh", Mock.Of<TokenCredential>());
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, mockConnection);

            Assert.That(receiver.FullyQualifiedNamespace, Is.EqualTo(expected));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.EventHubName" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void PartitionReceiverDelegatesForTheEventHubName()
        {
            var expected = "EventHubName";
            var mockConnection = new EventHubConnection("fqns", expected, Mock.Of<TokenCredential>());
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, mockConnection);

            Assert.That(receiver.EventHubName, Is.EqualTo(expected));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.GetPartitionPropertiesAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetPartitionPropertiesUsesThePartitionId()
        {
            var mockConnection = new Mock<EventHubConnection>();
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, mockConnection.Object);

            mockConnection
                .Setup(connection => connection.GetPartitionPropertiesAsync(
                    It.IsAny<string>(),
                    It.IsAny<EventHubsRetryPolicy>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(default(PartitionProperties)));

            await receiver.GetPartitionPropertiesAsync();

            mockConnection
                .Verify(connection => connection.GetPartitionPropertiesAsync(
                    receiver.PartitionId,
                    It.IsAny<EventHubsRetryPolicy>(),
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.GetPartitionPropertiesAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetPartitionPropertiesUsesTheRetryPolicy()
        {
            var mockConnection = new Mock<EventHubConnection>();
            var retryPolicy = Mock.Of<EventHubsRetryPolicy>();
            var options = new PartitionReceiverOptions { RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = retryPolicy } };
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, mockConnection.Object, options);

            mockConnection
                .Setup(connection => connection.GetPartitionPropertiesAsync(
                    It.IsAny<string>(),
                    It.IsAny<EventHubsRetryPolicy>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(default(PartitionProperties)));

            await receiver.GetPartitionPropertiesAsync();

            mockConnection
                .Verify(connection => connection.GetPartitionPropertiesAsync(
                    It.IsAny<string>(),
                    retryPolicy,
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.GetPartitionPropertiesAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetPartitionPropertiesUsesTheCancellationToken()
        {
            var mockConnection = new Mock<EventHubConnection>();
            using var cancellationSource = new CancellationTokenSource();
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, mockConnection.Object);

            mockConnection
                .Setup(connection => connection.GetPartitionPropertiesAsync(
                    It.IsAny<string>(),
                    It.IsAny<EventHubsRetryPolicy>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(default(PartitionProperties)));

            await receiver.GetPartitionPropertiesAsync(cancellationSource.Token);

            mockConnection
                .Verify(connection => connection.GetPartitionPropertiesAsync(
                    It.IsAny<string>(),
                    It.IsAny<EventHubsRetryPolicy>(),
                    cancellationSource.Token),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.GetPartitionPropertiesAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetPartitionPropertiesFailsWhenPartitionReceiverIsClosed()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123";
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, connectionString, "someHub");

            await receiver.CloseAsync(cancellationSource.Token);

            Assert.That(async () => await receiver.GetPartitionPropertiesAsync(cancellationSource.Token), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncMarksTheClientAsClosed()
        {
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, connectionString);

            Assert.That(receiver.IsClosed, Is.False);

            await receiver.CloseAsync();

            Assert.That(receiver.IsClosed, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncClosesTheConnectionWhenOwned()
        {
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, connectionString);

            await receiver.CloseAsync();

            var connection = GetConnection(receiver);
            Assert.That(connection.IsClosed, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncDoesNotCloseTheConnectionWhenNotOwned()
        {
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var connection = new EventHubConnection(connectionString);
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, connection);

            await receiver.CloseAsync();
            Assert.That(connection.IsClosed, Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloseAsyncRespectsTheCancellationToken()
        {
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, connectionString);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(async () => await receiver.CloseAsync(cancellationSource.Token), Throws.InstanceOf<TaskCanceledException>());
            Assert.That(receiver.IsClosed, Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncLogsNormalClose()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123";
            var eventHubName = "someHub";
            var mockConnection = new Mock<EventHubConnection>(connectionString, eventHubName);
            var mockEventSource = new Mock<EventHubsEventSource>() { CallBase = true };
            var receiver = new PartitionReceiver("cg", "pid", EventPosition.Earliest, mockConnection.Object);

            receiver.Logger = mockEventSource.Object;

            await receiver.CloseAsync(cancellationSource.Token);

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockEventSource
                .Verify(log => log.ClientCloseStart(
                    typeof(PartitionReceiver),
                    eventHubName,
                    It.IsAny<string>()),
                Times.Once);

            mockEventSource
                .Verify(log => log.ClientCloseComplete(
                    typeof(PartitionReceiver),
                    eventHubName,
                    It.IsAny<string>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncLogsErrorDuringClose()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var expectedException = new InsufficientMemoryException("This message is expected.");
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123";
            var eventHubName = "someHub";
            var mockEventSource = new Mock<EventHubsEventSource>() { CallBase = true };
            var mockReceiver = new Mock<PartitionReceiver>("cg", "pid", EventPosition.Earliest, connectionString, eventHubName, default(PartitionReceiverOptions)) { CallBase = true };

            mockReceiver.Object.Logger = mockEventSource.Object;

            mockReceiver
                .SetupGet(receiver => receiver.OwnsConnection)
                .Throws(expectedException);

            try
            {
                await mockReceiver.Object.CloseAsync(cancellationSource.Token);
            }
            catch (InsufficientMemoryException)
            {
                // This exception is expected.
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");

            mockEventSource
                .Verify(log => log.ClientCloseStart(
                    typeof(PartitionReceiver),
                    eventHubName,
                    It.IsAny<string>()),
                Times.Once);

            mockEventSource
                .Verify(log => log.ClientCloseError(
                    typeof(PartitionReceiver),
                    eventHubName,
                    It.IsAny<string>(),
                    expectedException.Message),
                Times.Once);

            mockEventSource
                .Verify(log => log.ClientCloseComplete(
                    typeof(PartitionReceiver),
                    eventHubName,
                    It.IsAny<string>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.DisposeAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task DisposeAsyncDelegatesToCloseAsync()
        {
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var mockReceiver = new Mock<PartitionReceiver>("cg", "pid", EventPosition.Earliest, connectionString, default(PartitionReceiverOptions)) { CallBase = true };

            await mockReceiver.Object.DisposeAsync();

            mockReceiver
                .Verify(receiver => receiver.CloseAsync(
                    CancellationToken.None),
                Times.Once);
        }

        /// <summary>
        ///   Retrieves the Connection for the partition receiver using its private accessor.
        /// </summary>
        ///
        private static EventHubConnection GetConnection(PartitionReceiver partitionReceiver) =>
            (EventHubConnection)
                typeof(PartitionReceiver)
                    .GetProperty("Connection", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(partitionReceiver);

        /// <summary>
        ///   Retrieves the RetryPolicy for the partition receiver using its private accessor.
        /// </summary>
        ///
        private static EventHubsRetryPolicy GetRetryPolicy(PartitionReceiver partitionReceiver) =>
            (EventHubsRetryPolicy)
                typeof(PartitionReceiver)
                    .GetProperty("RetryPolicy", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(partitionReceiver);
    }
}
