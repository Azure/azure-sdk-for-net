// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Errors;
using Azure.Messaging.EventHubs.Metadata;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventHubConsumerClient" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventHubConsumerClientTests
    {
        /// <summary>
        ///   Provides the test cases for non-fatal exceptions that are not retriable
        ///   when encountered in a subscription.
        /// </summary>
        ///
        public static IEnumerable<object[]> NonFatalNotRetriableExceptionTestCases()
        {
            yield return new object[] { new ConsumerDisconnectedException("Test", "Test") };
            yield return new object[] { new EventHubsResourceNotFoundException("Test", "Test") };
            yield return new object[] { new InvalidOperationException() };
            yield return new object[] { new NotSupportedException() };
            yield return new object[] { new NullReferenceException() };
            yield return new object[] { new ObjectDisposedException("dummy") };
        }

        /// <summary>
        ///   Provides the test cases for non-fatal exceptions that are retriable
        ///   when encountered in a subscription.
        /// </summary>
        ///
        public static IEnumerable<object[]> NonFatalRetriableExceptionTestCases()
        {
            yield return new object[] { new EventHubsException(true, "Test") };
            yield return new object[] { new EventHubsCommunicationException("Test", "Test") };
            yield return new object[] { new ServiceBusyException("Test", "Test") };
            yield return new object[] { new TimeoutException() };
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheConsumerGroup(string consumerGroup)
        {
            Assert.That(() => new EventHubConsumerClient(consumerGroup, "1332", EventPosition.Earliest, "dummyConnection", new EventHubConsumerClientOptions()), Throws.InstanceOf<ArgumentException>(), "The connection string constructor should validate the consumer group.");
            Assert.That(() => new EventHubConsumerClient(consumerGroup, "1332", EventPosition.Earliest, "dummyNamespace", "dummyEventHub", Mock.Of<TokenCredential>(), new EventHubConsumerClientOptions()), Throws.InstanceOf<ArgumentException>(), "The namespace constructor should validate the consumer group.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesThePartition(string partition)
        {
            Assert.That(() => new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, "dummyConnection", new EventHubConsumerClientOptions()), Throws.InstanceOf<ArgumentException>(), "The connection string constructor should validate the partition.");
            Assert.That(() => new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, "dummyNamespace", "dummyEventHub", Mock.Of<TokenCredential>(), new EventHubConsumerClientOptions()), Throws.InstanceOf<ArgumentException>(), "The namespace constructor should validate the partition.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheEventPosition()
        {
            Assert.That(() => new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "1234", null, "dummyConnection", new EventHubConsumerClientOptions()), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "1234", null, "dummyNamespace", "dummyEventHub", Mock.Of<TokenCredential>(), new EventHubConsumerClientOptions()), Throws.InstanceOf<ArgumentException>(), "The namespace constructor should validate the event position.");
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
            Assert.That(() => new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "1234", EventPosition.Earliest, connectionString), Throws.InstanceOf<ArgumentException>(), "The constructor without options should ensure a connection string.");
            Assert.That(() => new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "1234", EventPosition.Earliest, connectionString, "dummy", new EventHubConsumerClientOptions()), Throws.InstanceOf<ArgumentException>(), "The constructor with options should ensure a connection string.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheNamespace(string constructorArgument)
        {
            Assert.That(() => new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "1234", EventPosition.Earliest, constructorArgument, "dummy", Mock.Of<TokenCredential>()), Throws.InstanceOf<ArgumentException>());
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
            Assert.That(() => new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "1234", EventPosition.Earliest, "namespace", constructorArgument, Mock.Of<TokenCredential>()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheCredential()
        {
            Assert.That(() => new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "1234", EventPosition.Earliest, "namespace", "hubName", default(TokenCredential)), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheConnection()
        {
            Assert.That(() => new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "1234", EventPosition.Earliest, default(EventHubConnection)), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorSetsTheRetryPolicy()
        {
            var expected = Mock.Of<EventHubRetryPolicy>();
            var options = new EventHubConsumerClientOptions { RetryOptions = new RetryOptions { CustomRetryPolicy = expected } };
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.Earliest, connectionString, options);

            Assert.That(GetRetryPolicy(consumer), Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ExpandedConstructorSetsTheRetryPolicy()
        {
            var expected = Mock.Of<EventHubRetryPolicy>();
            var options = new EventHubConsumerClientOptions { RetryOptions = new RetryOptions { CustomRetryPolicy = expected } };
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.Earliest, "namespace", "hub", Mock.Of<TokenCredential>(), options);

            Assert.That(GetRetryPolicy(consumer), Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionConstructorSetsTheRetryPolicy()
        {
            var expected = Mock.Of<EventHubRetryPolicy>();
            var options = new EventHubConsumerClientOptions { RetryOptions = new RetryOptions { CustomRetryPolicy = expected } };
            var mockConnection = new MockConnection();
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.Earliest, mockConnection, options);

            Assert.That(GetRetryPolicy(consumer), Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorCreatesDefaultOptions()
        {
            var expected = new EventHubConsumerClientOptions().RetryOptions;
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.Earliest, connectionString);

            var policy = GetRetryPolicy(consumer);
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
            var expected = new EventHubConsumerClientOptions().RetryOptions;
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.Earliest, "some-namespace", "hubName", Mock.Of<TokenCredential>());

            var policy = GetRetryPolicy(consumer);
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
            var expected = new EventHubConsumerClientOptions().RetryOptions;
            var mockConnection = new MockConnection();
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.Earliest, mockConnection);

            var policy = GetRetryPolicy(consumer);
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
        public void ConnectionStringConstructorSetsThePartition()
        {
            var partition = "aPartition";
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, connectionString);

            Assert.That(consumer.PartitionId, Is.EqualTo(partition));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ExpandedConstructorSetsThePartition()
        {
            var partition = "aPartition";
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, "aNamespace", "underclothing", Mock.Of<TokenCredential>());

            Assert.That(consumer.PartitionId, Is.EqualTo(partition));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionConstructorSetsThePartition()
        {
            var partition = "aPartition";
            var mockConnection = new MockConnection();
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.Earliest, mockConnection);

            Assert.That(consumer.PartitionId, Is.EqualTo(partition));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase(1)]
        [TestCase(32769)]
        public void ConnectionStringConstructorSetsThePriority(long? priority)
        {
            var options = new EventHubConsumerClientOptions
            {
                OwnerLevel = priority
            };

            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.Earliest, connectionString, options);

            Assert.That(consumer.OwnerLevel, Is.EqualTo(priority));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase(1)]
        [TestCase(32769)]
        public void ExpandedConstructorSetsThePriority(long? priority)
        {
            var options = new EventHubConsumerClientOptions
            {
                OwnerLevel = priority
            };

            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.Earliest, "namespace-name", "hub-name", Mock.Of<TokenCredential>(), options);
            Assert.That(consumer.OwnerLevel, Is.EqualTo(priority));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase(1)]
        [TestCase(32769)]
        public void ConnectionConstructorSetsThePriority(long? priority)
        {
            var options = new EventHubConsumerClientOptions
            {
                OwnerLevel = priority
            };

            var mockConnection = new MockConnection();
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "2", EventPosition.Earliest, mockConnection, options);

            Assert.That(consumer.OwnerLevel, Is.EqualTo(priority));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorSetsTheStartingPosition()
        {
            var expectedPosition = EventPosition.FromSequenceNumber(5641);
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", expectedPosition, connectionString);


            Assert.That(consumer.StartingPosition, Is.EqualTo(expectedPosition));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ExpandedConstructorSetsTheStartingPosition()
        {
            var expectedPosition = EventPosition.FromSequenceNumber(5641);
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", expectedPosition, "namespace", "eventHub", Mock.Of<TokenCredential>());


            Assert.That(consumer.StartingPosition, Is.EqualTo(expectedPosition));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionConstructorSetsTheStartingPosition()
        {
            var expectedPosition = EventPosition.FromSequenceNumber(5641);
            var mockConnection = new MockConnection();
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "2", expectedPosition, mockConnection);

            Assert.That(consumer.StartingPosition, Is.EqualTo(expectedPosition));
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
            var consumer = new EventHubConsumerClient(consumerGroup, "0", EventPosition.Latest, connectionString);

            Assert.That(consumer.ConsumerGroup, Is.EqualTo(consumerGroup));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ExpandedConstructorSetsTheConsumerGroup()
        {
            var consumerGroup = "SomeGroup";
            var consumer = new EventHubConsumerClient(consumerGroup, "0", EventPosition.Latest, "namespace", "eventHub", Mock.Of<TokenCredential>());

            Assert.That(consumer.ConsumerGroup, Is.EqualTo(consumerGroup));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionConstructorSetsTheConsumerGroup()
        {
            var consumerGroup = "SomeGroup";
            var mockConnection = new MockConnection();
            var consumer = new EventHubConsumerClient(consumerGroup, "2", EventPosition.FromOffset(12), mockConnection);

            Assert.That(consumer.ConsumerGroup, Is.EqualTo(consumerGroup));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.FullyQualifiedNamespace" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void ConsumerDelegatesForTheFullyQualifiedNamespaceName()
        {
            var expected = "SomeNamespace";
            var mockConnection = new MockConnection(expected);
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.Earliest, mockConnection);

            Assert.That(consumer.FullyQualifiedNamespace, Is.EqualTo(expected));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.EventHubName" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void ConsumerDelegatesForTheEventHubName()
        {
            var expected = "EventHubName";
            var mockConnection = new MockConnection(eventHubName: expected);
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.Earliest, mockConnection);

            Assert.That(consumer.EventHubName, Is.EqualTo(expected));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.GetEventHubPropertiesAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetEventHubPropertiesAsyncUsesTheRetryPolicy()
        {
            var mockConnection = new MockConnection();
            var retryPolicy = Mock.Of<EventHubRetryPolicy>();
            var options = new EventHubConsumerClientOptions { RetryOptions = new RetryOptions { CustomRetryPolicy = retryPolicy } };
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.Earliest, mockConnection, options);

            await consumer.GetEventHubPropertiesAsync();
            Assert.That(mockConnection.GetPropertiesInvokedWith, Is.SameAs(retryPolicy), "Either the call was not delegated or the retry policy was not passed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.GetPartitionIdsAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetPartitionIdsUsesTheRetryPolicy()
        {
            var mockConnection = new MockConnection();
            var retryPolicy = Mock.Of<EventHubRetryPolicy>();
            var options = new EventHubConsumerClientOptions { RetryOptions = new RetryOptions { CustomRetryPolicy = retryPolicy } };
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.Earliest, mockConnection, options);

            await consumer.GetPartitionIdsAsync();
            Assert.That(mockConnection.GetPartitionIdsInvokedWith, Is.SameAs(retryPolicy), "Either the call was not delegated or the retry policy was not passed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.GetPartitionPropertiesAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetPartitionPropertiesUsesTheRetryPolicy()
        {
            var mockConnection = new MockConnection();
            var retryPolicy = Mock.Of<EventHubRetryPolicy>();
            var options = new EventHubConsumerClientOptions { RetryOptions = new RetryOptions { CustomRetryPolicy = retryPolicy } };
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.Earliest, mockConnection, options);

            await consumer.GetPartitionPropertiesAsync("1");
            Assert.That(mockConnection.GetPartitionPropertiesInvokedWith, Is.SameAs(retryPolicy), "Either the call was not delegated or the retry policy was not passed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.ReadLastEnqueuedEventInformation" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void ReadLastEnqueuedEventInformationRespectsTheTrackingEnabledFlag(bool trackingEnabled)
        {
            var consumerOptions = new EventHubConsumerClientOptions { TrackLastEnqueuedEventInformation = trackingEnabled };
            var mockConnection = new MockConnection();
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "2", EventPosition.FromOffset(12), mockConnection, consumerOptions);

            if (trackingEnabled)
            {
                var metrics = consumer.ReadLastEnqueuedEventInformation();
                Assert.That(metrics.EventHubName, Is.Not.Null.And.Not.Empty, "The Event Hub name should be present.");
                Assert.That(metrics.PartitionId, Is.Not.Null.And.Not.Empty, "The partition id should be present.");
            }
            else
            {
                Assert.That(() => consumer.ReadLastEnqueuedEventInformation(), Throws.TypeOf<InvalidOperationException>(), "Last enqueued event information cannot be read if tracking is not enabled.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.ReadLastEnqueuedEventInformation" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ReadLastEnqueuedEventInformationPopulatesFromTheLastReceivedEvent()
        {
            var lastEvent = new EventData
            (
                eventBody: Array.Empty<byte>(),
                lastPartitionSequenceNumber: 12345,
                lastPartitionOffset: 89101,
                lastPartitionEnqueuedTime: DateTimeOffset.Parse("2015-10-27T00:00:00Z"),
                lastPartitionInformationRetrievalTime: DateTimeOffset.Parse("2012-03-04T08:49:00Z")
            );

            var eventHub = "someHub";
            var partition = "PART";
            var consumerOptions = new EventHubConsumerClientOptions { TrackLastEnqueuedEventInformation = true };
            var transportMock = new ObservableTransportConsumerMock { LastReceivedEvent = lastEvent };
            var mockConnection = new MockConnection(transportMock, "namespace", eventHub);
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, partition, EventPosition.FromOffset(12), mockConnection, consumerOptions);
            var metrics = consumer.ReadLastEnqueuedEventInformation();

            Assert.That(metrics.EventHubName, Is.EqualTo(eventHub), "The Event Hub name should match.");
            Assert.That(metrics.PartitionId, Is.EqualTo(partition), "The partition id should match.");
            Assert.That(metrics.LastEnqueuedSequenceNumber, Is.EqualTo(lastEvent.LastPartitionSequenceNumber), "The sequence number should match.");
            Assert.That(metrics.LastEnqueuedOffset, Is.EqualTo(lastEvent.LastPartitionOffset), "The offset should match.");
            Assert.That(metrics.LastEnqueuedTime, Is.EqualTo(lastEvent.LastPartitionEnqueuedTime), "The enqueue time should match.");
            Assert.That(metrics.InformationReceived, Is.EqualTo(lastEvent.LastPartitionInformationRetrievalTime), "The retrieval time should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(-32767)]
        [TestCase(-1)]
        [TestCase(0)]
        public void ReceiveAsyncValidatesTheMaximumCount(int maximumMessageCount)
        {
            var transportConsumer = new ObservableTransportConsumerMock();
            var mockConnection = new MockConnection(transportConsumer);
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.FromOffset(12), mockConnection);
            var expectedWaitTime = TimeSpan.FromDays(1);

            using var cancellation = new CancellationTokenSource();
            Assert.That(async () => await consumer.ReceiveAsync(maximumMessageCount, expectedWaitTime, cancellation.Token), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(-1)]
        [TestCase(-100)]
        [TestCase(-1000)]
        [TestCase(-10000)]
        public void ReceiveAsyncValidatesTheMaximumWaitTime(int timeSpanDelta)
        {
            var transportConsumer = new ObservableTransportConsumerMock();
            var mockConnection = new MockConnection(transportConsumer);
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.FromOffset(12), mockConnection);
            var expectedWaitTime = TimeSpan.FromMilliseconds(timeSpanDelta);

            using var cancellation = new CancellationTokenSource();
            Assert.That(async () => await consumer.ReceiveAsync(32, expectedWaitTime, cancellation.Token), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ReceiveAsyncInvokesTheTransportConsumer()
        {
            var options = new EventHubConsumerClientOptions { DefaultMaximumReceiveWaitTime = TimeSpan.FromMilliseconds(8) };
            var transportConsumer = new ObservableTransportConsumerMock();
            var mockConnection = new MockConnection(transportConsumer);
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.FromOffset(12), mockConnection, options);
            var expectedMessageCount = 45;

            using var cancellation = new CancellationTokenSource();
            await consumer.ReceiveAsync(expectedMessageCount, null, cancellation.Token);

            (var actualMessageCount, TimeSpan? actualWaitTime) = transportConsumer.ReceiveCalledWith;

            Assert.That(actualMessageCount, Is.EqualTo(expectedMessageCount), "The message counts should match.");
            Assert.That(actualWaitTime, Is.EqualTo(options.DefaultMaximumReceiveWaitTime), "The wait time should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncClosesTheTransportConsumer()
        {
            var transportConsumer = new ObservableTransportConsumerMock();
            var mockConnection = new MockConnection(transportConsumer);
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.FromOffset(12), mockConnection);

            await consumer.CloseAsync();
            Assert.That(transportConsumer.WasCloseCalled, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloseClosesTheTransportConsumer()
        {
            var transportConsumer = new ObservableTransportConsumerMock();
            var mockConnection = new MockConnection(transportConsumer);
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.FromOffset(12), mockConnection);

            consumer.Close();
            Assert.That(transportConsumer.WasCloseCalled, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.SubscribeToEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SubscribeWithNoWaitTimeReturnsAnEnumerable()
        {
            var transportConsumer = new ObservableTransportConsumerMock();
            var mockConnection = new MockConnection(transportConsumer);
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.FromOffset(12), mockConnection);

            IAsyncEnumerable<EventData> enumerable = consumer.SubscribeToEvents();

            Assert.That(enumerable, Is.Not.Null, "An enumerable should have been returned.");
            Assert.That(enumerable, Is.InstanceOf<IAsyncEnumerable<EventData>>(), "The enumerable should be of the correct type.");

            await using (IAsyncEnumerator<EventData> enumerator = enumerable.GetAsyncEnumerator())
            {
                Assert.That(enumerator, Is.Not.Null, "The enumerable should be able to produce an enumerator.");
                Assert.That(enumerator, Is.InstanceOf<IAsyncEnumerator<EventData>>(), "The enumerator should be of the correct type.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.SubscribeToEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SubscribeWithWaitTimeReturnsAnEnumerable()
        {
            var transportConsumer = new ObservableTransportConsumerMock();
            var mockConnection = new MockConnection(transportConsumer);
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.FromOffset(12), mockConnection);

            IAsyncEnumerable<EventData> enumerable = consumer.SubscribeToEvents(TimeSpan.FromSeconds(15));

            Assert.That(enumerable, Is.Not.Null, "An enumerable should have been returned.");
            Assert.That(enumerable, Is.InstanceOf<IAsyncEnumerable<EventData>>(), "The enumerable should be of the correct type.");

            await using (IAsyncEnumerator<EventData> enumerator = enumerable.GetAsyncEnumerator())
            {
                Assert.That(enumerator, Is.Not.Null, "The enumerable should be able to produce an enumerator.");
                Assert.That(enumerator, Is.InstanceOf<IAsyncEnumerator<EventData>>(), "The enumerator should be of the correct type.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.SubscribeToEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SubscribeManagesActiveChannels()
        {
            var events = new List<EventData>
            {
               new EventData(Encoding.UTF8.GetBytes("One")),
               new EventData(Encoding.UTF8.GetBytes("Two")),
               new EventData(Encoding.UTF8.GetBytes("Three")),
               new EventData(Encoding.UTF8.GetBytes("Four")),
               new EventData(Encoding.UTF8.GetBytes("Five"))
            };

            var transportConsumer = new PublishingTransportConsumerMock(events, true);
            var mockConnection = new MockConnection(transportConsumer);
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.FromOffset(12), mockConnection);

            ConcurrentDictionary<Guid, Channel<EventData>> channels = GetActiveChannels(consumer);

            // Create the subscriptions in the background, wrapping each request in its own task.  The
            // goal is to ensure that channel creation can handle concurrent requests.

            var subscriptions = (await Task.WhenAll(
                Enumerable.Range(0, 10)
                .Select(index => Task.Run(() => consumer.SubscribeToEvents(TimeSpan.FromMilliseconds(5))))
            ).ConfigureAwait(false))
                .Select(enumerable => enumerable.GetAsyncEnumerator())
                .ToList();

            try
            {
                await Task.WhenAll(subscriptions.Select(subscription => subscription.MoveNextAsync().AsTask()).ToList());
                Assert.That(channels, Is.Not.Null, "The consumer should have a set of active channels.");
                Assert.That(channels.Count, Is.EqualTo(subscriptions.Count), "Each subscription should have an associated channel.");
            }
            finally
            {
                await Task.WhenAll(subscriptions.Select(subscription => Task.Run(async () => await subscription.DisposeAsync()))).ConfigureAwait(false);
            }

            Assert.That(channels, Is.Not.Null, "The consumer should have a set of active channels.");
            Assert.That(channels.Count, Is.EqualTo(0), "Channels should have been removed when subscriptions were removed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.SubscribeToEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SubscribeManagesBackgroundPublishingWithOneSubscriber()
        {
            var events = new List<EventData>
            {
               new EventData(Encoding.UTF8.GetBytes("One")),
               new EventData(Encoding.UTF8.GetBytes("Two")),
               new EventData(Encoding.UTF8.GetBytes("Three")),
               new EventData(Encoding.UTF8.GetBytes("Four")),
               new EventData(Encoding.UTF8.GetBytes("Five"))
            };

            var transportConsumer = new PublishingTransportConsumerMock(events, true);
            var mockConnection = new MockConnection(transportConsumer);
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.FromOffset(12), mockConnection);
            var publishing = GetIsPublishingActiveFlag(consumer);

            Assert.That(publishing, Is.False, "Background publishing should not start without a subscription.");

            await using (IAsyncEnumerator<EventData> enumerator = consumer.SubscribeToEvents(TimeSpan.FromMilliseconds(5)).GetAsyncEnumerator())
            {
                await enumerator.MoveNextAsync();
                publishing = GetIsPublishingActiveFlag(consumer);
                Assert.That(publishing, Is.True, "Background publishing should be taking place when there is a subscriber.");
            }

            publishing = GetIsPublishingActiveFlag(consumer);
            Assert.That(publishing, Is.False, "Background publishing should stop when at the last unsubscribe.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.SubscribeToEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SubscribeManagesBackgroundPublishingWithMultipleSubscribers()
        {
            var events = new List<EventData>
            {
               new EventData(Encoding.UTF8.GetBytes("One")),
               new EventData(Encoding.UTF8.GetBytes("Two")),
               new EventData(Encoding.UTF8.GetBytes("Three")),
               new EventData(Encoding.UTF8.GetBytes("Four")),
               new EventData(Encoding.UTF8.GetBytes("Five"))
            };

            var waitTime = TimeSpan.FromMilliseconds(5);
            var transportConsumer = new PublishingTransportConsumerMock(events, true);
            var mockConnection = new MockConnection(transportConsumer);
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.FromOffset(12), mockConnection);
            var publishing = GetIsPublishingActiveFlag(consumer);

            Assert.That(publishing, Is.False, "Background publishing should not start without a subscription.");

            await using (IAsyncEnumerator<EventData> firstEnumerator = consumer.SubscribeToEvents(waitTime).GetAsyncEnumerator())
            {
                await firstEnumerator.MoveNextAsync();

                await using (IAsyncEnumerator<EventData> secondEnumerator = consumer.SubscribeToEvents(waitTime).GetAsyncEnumerator())
                await using (IAsyncEnumerator<EventData> thirdEnumerator = consumer.SubscribeToEvents(waitTime).GetAsyncEnumerator())
                {
                    await Task.WhenAll(secondEnumerator.MoveNextAsync().AsTask(), thirdEnumerator.MoveNextAsync().AsTask());

                    publishing = GetIsPublishingActiveFlag(consumer);
                    Assert.That(publishing, Is.True, "Background publishing should be taking place when there are multiple subscribers.");
                }

                publishing = GetIsPublishingActiveFlag(consumer);
                Assert.That(publishing, Is.True, "Background publishing should be taking place when there is a single subscriber left.");
            }

            publishing = GetIsPublishingActiveFlag(consumer);
            Assert.That(publishing, Is.False, "Background publishing should stop when at the last unsubscribe.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.SubscribeToEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SubscribeThrowsIfCancelledBeforeSubscribe()
        {
            var events = new List<EventData>
            {
               new EventData(Encoding.UTF8.GetBytes("One")),
               new EventData(Encoding.UTF8.GetBytes("Two")),
               new EventData(Encoding.UTF8.GetBytes("Three")),
               new EventData(Encoding.UTF8.GetBytes("Four")),
               new EventData(Encoding.UTF8.GetBytes("Five"))
            };

            var transportConsumer = new PublishingTransportConsumerMock(events, true);
            var mockConnection = new MockConnection(transportConsumer);
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.FromOffset(12), mockConnection);
            var receivedEvents = 0;

            using var cancellation = new CancellationTokenSource();
            cancellation.Cancel();

            Assert.That(async () =>
            {
                await foreach (EventData eventData in consumer.SubscribeToEvents(cancellation.Token))
                {
                    if (eventData == null)
                    {
                        break;
                    }

                    ++receivedEvents;
                }
            }, Throws.InstanceOf<TaskCanceledException>(), "Subscribe should have indicated the token was not active.");

            Assert.That(cancellation.IsCancellationRequested, Is.True, "The cancellation should have been requested.");
            Assert.That(receivedEvents, Is.EqualTo(0), "There should have been no events received.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.SubscribeToEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SubscribePublishesEventsWithOneSubscriberAndSingleBatch()
        {
            var events = new List<EventData>
            {
                new EventData(Encoding.UTF8.GetBytes("One")),
                new EventData(Encoding.UTF8.GetBytes("Two")),
                new EventData(Encoding.UTF8.GetBytes("Three")),
                new EventData(Encoding.UTF8.GetBytes("Four")),
                new EventData(Encoding.UTF8.GetBytes("Five"))
            };

            var transportConsumer = new PublishingTransportConsumerMock(events, true);
            var mockConnection = new MockConnection(transportConsumer);
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.FromOffset(12), mockConnection);
            var receivedEvents = new List<EventData>();

            using var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(60));

            await foreach (EventData eventData in consumer.SubscribeToEvents(cancellation.Token))
            {
                receivedEvents.Add(eventData);

                if (receivedEvents.Count >= events.Count)
                {
                    break;
                }
            }

            Assert.That(cancellation.IsCancellationRequested, Is.False, "The iteration should have completed normally.");
            Assert.That(receivedEvents, Is.EquivalentTo(events), "The received events should match the published events.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.SubscribeToEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SubscribePublishesEventsWithMultipleSubscribersAndSingleBatch()
        {
            var events = new List<EventData>
            {
                new EventData(Encoding.UTF8.GetBytes("One")),
                new EventData(Encoding.UTF8.GetBytes("Two")),
                new EventData(Encoding.UTF8.GetBytes("Three")),
                new EventData(Encoding.UTF8.GetBytes("Four")),
                new EventData(Encoding.UTF8.GetBytes("Five"))
            };

            var waitTime = TimeSpan.FromMilliseconds(5);
            var transportConsumer = new PublishingTransportConsumerMock(events);
            var mockConnection = new MockConnection(transportConsumer);
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.FromOffset(12), mockConnection);
            var firstSubscriberEvents = new List<EventData>();
            var secondSubscriberEvents = new List<EventData>();
            var firstCompletionSource = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);
            var secondCompletionSource = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);
            var firstSubcriberReceiving = false;
            var secondSubscriberReceiving = false;

            void StartPublishingIfReady()
            {
                if (firstSubcriberReceiving && secondSubscriberReceiving)
                {
                    transportConsumer.StartPublishing();
                }
            }

            using var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(75));

            var firstSubscriberTask = Task.Run(async () =>
            {
                await foreach (EventData eventData in consumer.SubscribeToEvents(waitTime, cancellation.Token).ConfigureAwait(false))
                {
                    firstSubcriberReceiving = true;
                    StartPublishingIfReady();

                    if (eventData != null)
                    {
                        firstSubscriberEvents.Add(eventData);
                    }

                    if (firstSubscriberEvents.Count >= events.Count)
                    {
                        break;
                    }
                }

                firstCompletionSource.TrySetResult(0);

            }, cancellation.Token);

            var secondSubscriberTask = Task.Run(async () =>
            {
                await foreach (EventData eventData in consumer.SubscribeToEvents(waitTime, cancellation.Token).ConfigureAwait(false))
                {
                    secondSubscriberReceiving = true;
                    StartPublishingIfReady();

                    if (eventData != null)
                    {
                        secondSubscriberEvents.Add(eventData);
                    }

                    if (secondSubscriberEvents.Count >= events.Count)
                    {
                        break;
                    }
                }

                secondCompletionSource.TrySetResult(0);

            }, cancellation.Token);

            await Task.WhenAll(firstSubscriberTask, secondSubscriberTask, firstCompletionSource.Task, secondCompletionSource.Task).ConfigureAwait(false);
            Assert.That(cancellation.IsCancellationRequested, Is.False, "The iteration should have completed normally.");
            Assert.That(firstSubscriberEvents, Is.EquivalentTo(events), "The received events for the first subscriber should match the published events.");
            Assert.That(secondSubscriberEvents, Is.EquivalentTo(events), "The received events for the second subscriber should match the published events.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.SubscribeToEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SubscribePublishesEventsWithOneSubscriberAndMultipleBatches()
        {
            var events = new List<EventData>();
            var transportConsumer = new PublishingTransportConsumerMock(events, true);
            var mockConnection = new MockConnection(transportConsumer);
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.FromOffset(12), mockConnection);
            var receivedEvents = new List<EventData>();

            events.AddRange(
                Enumerable.Range(0, (GetBackgroundPublishReceiveBatchSize(consumer) * 3))
                    .Select(index => new EventData(Encoding.UTF8.GetBytes($"Event Number { index }")))
            );

            using var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(60));

            await foreach (EventData eventData in consumer.SubscribeToEvents(cancellation.Token))
            {
                receivedEvents.Add(eventData);

                if (receivedEvents.Count >= events.Count)
                {
                    break;
                }
            }

            Assert.That(cancellation.IsCancellationRequested, Is.False, "The iteration should have completed normally.");
            Assert.That(receivedEvents, Is.EquivalentTo(events), "The received events should match the published events.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.SubscribeToEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SubscribePublishesEventsWithMultipleSubscribersAndMultipleBatches()
        {
            var waitTime = TimeSpan.FromMilliseconds(5);
            var events = new List<EventData>();
            var transportConsumer = new PublishingTransportConsumerMock(events);
            var mockConnection = new MockConnection(transportConsumer);
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.FromOffset(12), mockConnection);
            var firstSubscriberEvents = new List<EventData>();
            var secondSubscriberEvents = new List<EventData>();
            var firstCompletionSource = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);
            var secondCompletionSource = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);
            var firstSubcriberReceiving = false;
            var secondSubscriberReceiving = false;

            events.AddRange(
                Enumerable.Range(0, (GetBackgroundPublishReceiveBatchSize(consumer) * 3))
                    .Select(index => new EventData(Encoding.UTF8.GetBytes($"Event Number { index }")))
            );

            void StartPublishingIfReady()
            {
                if (firstSubcriberReceiving && secondSubscriberReceiving)
                {
                    transportConsumer.StartPublishing();
                }
            }

            using var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(75));

            var firstSubscriberTask = Task.Run(async () =>
            {
                await foreach (EventData eventData in consumer.SubscribeToEvents(waitTime, cancellation.Token).ConfigureAwait(false))
                {
                    firstSubcriberReceiving = true;
                    StartPublishingIfReady();

                    if (eventData != null)
                    {
                        firstSubscriberEvents.Add(eventData);
                    }

                    if (firstSubscriberEvents.Count >= events.Count)
                    {
                        break;
                    }
                }

                firstCompletionSource.TrySetResult(0);

            }, cancellation.Token);

            var secondSubscriberTask = Task.Run(async () =>
            {
                await foreach (EventData eventData in consumer.SubscribeToEvents(waitTime, cancellation.Token).ConfigureAwait(false))
                {
                    secondSubscriberReceiving = true;
                    StartPublishingIfReady();

                    if (eventData != null)
                    {
                        secondSubscriberEvents.Add(eventData);
                    }

                    if (secondSubscriberEvents.Count >= events.Count)
                    {
                        break;
                    }
                }

                secondCompletionSource.TrySetResult(0);

            }, cancellation.Token);

            await Task.WhenAll(firstSubscriberTask, secondSubscriberTask, firstCompletionSource.Task, secondCompletionSource.Task).ConfigureAwait(false);
            Assert.That(cancellation.IsCancellationRequested, Is.False, "The iteration should have completed normally.");
            Assert.That(firstSubscriberEvents, Is.EquivalentTo(events), "The received events for the first subscriber should match the published events.");
            Assert.That(secondSubscriberEvents, Is.EquivalentTo(events), "The received events for the second subscriber should match the published events.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.SubscribeToEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task UnsubscribeHappensAfterIterationWithSingleSubcriber()
        {
            var events = new List<EventData>
            {
                new EventData(Encoding.UTF8.GetBytes("One")),
                new EventData(Encoding.UTF8.GetBytes("Two")),
                new EventData(Encoding.UTF8.GetBytes("Three")),
                new EventData(Encoding.UTF8.GetBytes("Four")),
                new EventData(Encoding.UTF8.GetBytes("Five"))
            };

            var transportConsumer = new PublishingTransportConsumerMock(events, true);
            var mockConnection = new MockConnection(transportConsumer);
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.FromOffset(12), mockConnection);
            var receivedEvents = 0;

            ConcurrentDictionary<Guid, Channel<EventData>> activeChannels = GetActiveChannels(consumer);

            using var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            await foreach (EventData eventData in consumer.SubscribeToEvents(cancellation.Token))
            {
                ++receivedEvents;

                if (receivedEvents >= events.Count)
                {
                    Assert.That(activeChannels.Count, Is.EqualTo(1), "There should be a single active channel for the subscriber.");
                    break;
                }
            }

            Assert.That(cancellation.IsCancellationRequested, Is.False, "The iteration should have completed normally.");
            Assert.That(activeChannels.Count, Is.EqualTo(0), "The iterator should unsubscribe when complete.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.SubscribeToEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task UnsubscribeHappensAfterIterationWithMultipleSubcribers()
        {
            var events = new List<EventData>
            {
                new EventData(Encoding.UTF8.GetBytes("One")),
                new EventData(Encoding.UTF8.GetBytes("Two")),
                new EventData(Encoding.UTF8.GetBytes("Three")),
                new EventData(Encoding.UTF8.GetBytes("Four")),
                new EventData(Encoding.UTF8.GetBytes("Five"))
            };

            var waitTime = TimeSpan.FromMilliseconds(5);
            var transportConsumer = new PublishingTransportConsumerMock(events);
            var mockConnection = new MockConnection(transportConsumer);
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.FromOffset(12), mockConnection);
            var firstCompletionSource = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);
            var secondCompletionSource = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);
            var firstIterations = 0;
            var secondIterations = 0;
            var firstSubcriberReceiving = false;
            var secondSubscriberReceiving = false;

            ConcurrentDictionary<Guid, Channel<EventData>> activeChannels = GetActiveChannels(consumer);

            void StartPublishingIfReady()
            {
                if (firstSubcriberReceiving && secondSubscriberReceiving)
                {
                    transportConsumer.StartPublishing();
                }
            }

            using var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(30));

            var firstSubscriberTask = Task.Run(async () =>
            {
                await foreach (EventData eventData in consumer.SubscribeToEvents(waitTime, cancellation.Token).ConfigureAwait(false))
                {
                    firstSubcriberReceiving = true;
                    StartPublishingIfReady();

                    if ((++firstIterations >= 2) && (transportConsumer.IsPublishingStarted))
                    {
                        Assert.That(activeChannels.Count, Is.AtLeast(1).And.AtMost(2), "There should be a one active channel for each subscriber.");
                        break;
                    }
                }

                firstCompletionSource.TrySetResult(0);

            }, cancellation.Token);

            var secondSubscriberTask = Task.Run(async () =>
            {
                await foreach (EventData eventData in consumer.SubscribeToEvents(waitTime, cancellation.Token).ConfigureAwait(false))
                {
                    secondSubscriberReceiving = true;
                    StartPublishingIfReady();

                    if ((++secondIterations >= 2) && (transportConsumer.IsPublishingStarted))
                    {
                        Assert.That(activeChannels.Count, Is.AtLeast(1).And.AtMost(2), "There should be a one active channel for each subscriber.");
                        break;
                    }
                }

                secondCompletionSource.TrySetResult(0);

            }, cancellation.Token);

            await Task.WhenAll(firstSubscriberTask, secondSubscriberTask, firstCompletionSource.Task, secondCompletionSource.Task).ConfigureAwait(false);
            Assert.That(cancellation.IsCancellationRequested, Is.False, "The iteration should have completed normally.");
            Assert.That(activeChannels.Count, Is.EqualTo(0), "The iterator should unsubscribe when complete.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.SubscribeToEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SubscribeRespectsWaitTimeWhenPublishingEvents()
        {
            var events = new List<EventData>
            {
                new EventData(Encoding.UTF8.GetBytes("One")),
                new EventData(Encoding.UTF8.GetBytes("Two")),
                new EventData(Encoding.UTF8.GetBytes("Three")),
                new EventData(Encoding.UTF8.GetBytes("Four")),
                new EventData(Encoding.UTF8.GetBytes("Five"))
            };

            var maxWaitTime = TimeSpan.FromMilliseconds(50);
            var publishDelay = maxWaitTime.Add(TimeSpan.FromMilliseconds(15));
            var transportConsumer = new PublishingTransportConsumerMock(events, true, () => publishDelay);
            var mockConnection = new MockConnection(transportConsumer);
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.FromOffset(12), mockConnection);
            var receivedEvents = new List<EventData>();
            var consecutiveEmptyCount = 0;

            using var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(100));

            await foreach (EventData eventData in consumer.SubscribeToEvents(maxWaitTime, cancellation.Token))
            {
                receivedEvents.Add(eventData);
                consecutiveEmptyCount = (eventData == null) ? consecutiveEmptyCount + 1 : 0;

                if (consecutiveEmptyCount > 1)
                {
                    break;
                }
            }

            // Because there is a random delay in the receive loop, the exact count of empty events cannot be predicted.  There
            // should be at least one total, but no more than one for each published event.

            Assert.That(cancellation.IsCancellationRequested, Is.False, "The iteration should have completed normally.");
            Assert.That(receivedEvents.Count, Is.AtLeast(events.Count + 1).And.LessThanOrEqualTo(events.Count * 2), "There should be empty events present due to the wait time.");
            Assert.That(receivedEvents.Where(item => item != null), Is.EquivalentTo(events), "The received events should match the published events when empty events are removed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.SubscribeToEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(typeof(ChannelClosedException))]
        [TestCase(typeof(ArithmeticException))]
        [TestCase(typeof(IndexOutOfRangeException))]
        public void SubscribePropagagesException(Type exceptionType)
        {
            var transportConsumer = new ReceiveCallbackTransportConsumerMock((_max, _time) => throw (Exception)Activator.CreateInstance(exceptionType));
            var mockConnection = new MockConnection(transportConsumer);
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.FromOffset(12), mockConnection);
            var receivedEvents = 0;

            using var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            Assert.That(async () =>
            {
                await foreach (EventData eventData in consumer.SubscribeToEvents(cancellation.Token))
                {
                    ++receivedEvents;
                    break;
                }
            }, Throws.TypeOf(exceptionType), "An exception during receive should be propagated by the iterator.");

            Assert.That(cancellation.IsCancellationRequested, Is.False, "The iteration should have completed normally.");
            Assert.That(receivedEvents, Is.EqualTo(0), "No events should have been received.");
            Assert.That(GetIsPublishingActiveFlag(consumer), Is.False, "The consumer should no longer be publishing.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.SubscribeToEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(typeof(TaskCanceledException))]
        [TestCase(typeof(OperationCanceledException))]
        public void SubscribeSurfacesCancelation(Type exceptionType)
        {
            var transportConsumer = new ReceiveCallbackTransportConsumerMock((_max, _time) => throw (Exception)Activator.CreateInstance(exceptionType));
            var mockConnection = new MockConnection(transportConsumer);
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.FromOffset(12), mockConnection);
            var receivedEvents = 0;

            using var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            Assert.That(async () =>
            {
                await foreach (EventData eventData in consumer.SubscribeToEvents(cancellation.Token))
                {
                    ++receivedEvents;
                    break;
                }
            }, Throws.InstanceOf<TaskCanceledException>(), "Cancellation should be surfaced as a TaskCanceledException");

            Assert.That(cancellation.IsCancellationRequested, Is.False, "The iteration should have completed normally.");
            Assert.That(receivedEvents, Is.EqualTo(0), "No events should have been received.");
            Assert.That(GetIsPublishingActiveFlag(consumer), Is.False, "The consumer should no longer be publishing.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.SubscribeToEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(NonFatalNotRetriableExceptionTestCases))]
        public void SubscribeSurfacesNonRetriableExceptions(Exception exception)
        {
            var transportConsumer = new ReceiveCallbackTransportConsumerMock((_max, _time) => throw exception);
            var mockConnection = new MockConnection(transportConsumer);
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.FromOffset(12), mockConnection);
            var receivedEvents = 0;

            using var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            Func<Task> invoke = async () =>
            {
                await foreach (EventData eventData in consumer.SubscribeToEvents(cancellation.Token))
                {
                    ++receivedEvents;
                    break;
                }
            };

            Assert.That(async () => await invoke(), Throws.TypeOf(exception.GetType()), "The enumerator should surface the exception.");
            Assert.That(cancellation.IsCancellationRequested, Is.False, "The iteration should have completed normally.");
            Assert.That(receivedEvents, Is.EqualTo(0), "No events should have been received.");
            Assert.That(GetIsPublishingActiveFlag(consumer), Is.False, "The consumer should no longer be publishing.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.SubscribeToEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(NonFatalRetriableExceptionTestCases))]
        public void SubscribeRetriesAndSurfacesRetriableExceptions(Exception exception)
        {
            const int maximumRetries = 2;

            var expectedReceiveCalls = (maximumRetries + 1);
            var receiveCalls = 0;

            Func<int, TimeSpan?, IEnumerable<EventData>> receiveCallback = (_max, _time) =>
            {
                ++receiveCalls;
                throw exception;
            };

            var mockRetryPolicy = new Mock<EventHubRetryPolicy>();
            var options = new EventHubConsumerClientOptions { RetryOptions = new RetryOptions { CustomRetryPolicy = mockRetryPolicy.Object } };
            var transportConsumer = new ReceiveCallbackTransportConsumerMock(receiveCallback);
            var mockConnection = new MockConnection(transportConsumer);
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.FromOffset(12), mockConnection, options);
            var receivedEvents = 0;

            mockRetryPolicy
                .Setup(policy => policy.CalculateRetryDelay(It.Is<Exception>(value => value == exception), It.Is<int>(value => value <= maximumRetries)))
                .Returns(TimeSpan.FromMilliseconds(5));

            using var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            Func<Task> invoke = async () =>
            {
                await foreach (EventData eventData in consumer.SubscribeToEvents(cancellation.Token))
                {
                    ++receivedEvents;
                    break;
                }
            };

            Assert.That(async () => await invoke(), Throws.TypeOf(exception.GetType()), "The enumerator should surface the exception.");
            Assert.That(cancellation.IsCancellationRequested, Is.False, "The iteration should have completed normally.");
            Assert.That(receiveCalls, Is.EqualTo(expectedReceiveCalls), "The retry policy should have been applied.");
            Assert.That(receivedEvents, Is.EqualTo(0), "No events should have been received.");
            Assert.That(GetIsPublishingActiveFlag(consumer), Is.False, "The consumer should no longer be publishing.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.SubscribeToEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(NonFatalRetriableExceptionTestCases))]
        public void SubscribeHonorsRetryPolicyForRetriableExceptions(Exception exception)
        {
            var receiveCalls = 0;

            Func<int, TimeSpan?, IEnumerable<EventData>> receiveCallback = (_max, _time) =>
            {
                ++receiveCalls;
                throw exception;
            };

            var mockRetryPolicy = new Mock<EventHubRetryPolicy>();
            var options = new EventHubConsumerClientOptions { RetryOptions = new RetryOptions { CustomRetryPolicy = mockRetryPolicy.Object } };
            var transportConsumer = new ReceiveCallbackTransportConsumerMock(receiveCallback);
            var mockConnection = new MockConnection(transportConsumer);
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.FromOffset(12), mockConnection, options);
            var receivedEvents = 0;

            mockRetryPolicy
                .Setup(policy => policy.CalculateRetryDelay(It.IsAny<Exception>(), It.IsAny<int>()))
                .Returns(default(TimeSpan?));

            using var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            Func<Task> invoke = async () =>
            {
                await foreach (EventData eventData in consumer.SubscribeToEvents(cancellation.Token))
                {
                    ++receivedEvents;
                    break;
                }
            };

            Assert.That(async () => await invoke(), Throws.TypeOf(exception.GetType()), "The enumerator should surface the exception.");
            Assert.That(cancellation.IsCancellationRequested, Is.False, "The iteration should have completed normally.");
            Assert.That(receiveCalls, Is.EqualTo(1), "The retry policy should have been respected.");
            Assert.That(receivedEvents, Is.EqualTo(0), "No events should have been received.");
            Assert.That(GetIsPublishingActiveFlag(consumer), Is.False, "The consumer should no longer be publishing.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncClosesTheTransportProducer()
        {
            var transportConsumer = new ObservableTransportConsumerMock();
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.Earliest, new MockConnection(transportConsumer));

            await consumer.CloseAsync();

            Assert.That(transportConsumer.WasCloseCalled, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.Close" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloseClosesTheTransportProducer()
        {
            var transportConsumer = new ObservableTransportConsumerMock();
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.Earliest, new MockConnection(transportConsumer));

            consumer.Close();

            Assert.That(transportConsumer.WasCloseCalled, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncClosesTheConnectionWhenOwned()
        {
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.Earliest, connectionString);

            await consumer.CloseAsync();

            var connection = GetConnection(consumer);
            Assert.That(connection.Closed, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.Close" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloseClosesTheConnectionWhenOwned()
        {
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.Earliest, connectionString);

            consumer.Close();

            var connection = GetConnection(consumer);
            Assert.That(connection.Closed, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClient.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncDoesNotCloseTheConnectionWhenNotOwned()
        {
            var transportConsumer = new ObservableTransportConsumerMock();
            var connection = new MockConnection(transportConsumer);
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.Earliest, connection);

            await consumer.CloseAsync();
            Assert.That(connection.Closed, Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducer.Close" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloseDoesNotCloseTheConnectionWhenNotOwned()
        {
            var transportConsumer = new ObservableTransportConsumerMock();
            var connection = new MockConnection(transportConsumer);
            var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, "0", EventPosition.Earliest, connection);

            consumer.Close();
            Assert.That(connection.Closed, Is.False);
        }

        /// <summary>
        ///   Retrieves the Connection for the consumer using its private accessor.
        /// </summary>
        ///
        private static EventHubConnection GetConnection(EventHubConsumerClient consumer) =>
            (EventHubConnection)
                typeof(EventHubConsumerClient)
                    .GetProperty("Connection", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(consumer);

        /// <summary>
        ///   Retrieves the RetryPolicy for the consumer using its private accessor.
        /// </summary>
        ///
        private static EventHubRetryPolicy GetRetryPolicy(EventHubConsumerClient consumer) =>
            (EventHubRetryPolicy)
                typeof(EventHubConsumerClient)
                    .GetProperty("RetryPolicy", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(consumer);

        /// <summary>
        ///   Retrieves the active channels for a consumer, using its private field.
        /// </summary>
        ///
        /// <param name="consumer">The consumer to retrieve the channels for.</param>
        ///
        /// <returns>The set of active channels for the consumer.</returns>
        ///
        private ConcurrentDictionary<Guid, Channel<EventData>> GetActiveChannels(EventHubConsumerClient consumer) =>
            (ConcurrentDictionary<Guid, Channel<EventData>>)
                typeof(EventHubConsumerClient)
                    .GetField("_activeChannels", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(consumer);

        /// <summary>
        ///   Retrieves the "is publishing" flag for a consumer, using its private field.
        /// </summary>
        ///
        /// <param name="consumer">The consumer to retrieve the channels for.</param>
        ///
        /// <returns>The flag that indicates whether or not a consumer is publishing events in the background.</returns>
        ///
        private bool GetIsPublishingActiveFlag(EventHubConsumerClient consumer) =>
            (bool)
                typeof(EventHubConsumerClient)
                    .GetField("_isPublishingActive", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(consumer);

        /// <summary>
        ///   Retrieves the number of background publish event batch size for a consumer, using its private field.
        /// </summary>
        ///
        /// <param name="consumer">The consumer to retrieve the channels for.</param>
        ///
        /// <returns>The size of the batch that is received when publishing events in the background.</returns>
        ///
        private int GetBackgroundPublishReceiveBatchSize(EventHubConsumerClient consumer) =>
            (int)
                typeof(EventHubConsumerClient)
                    .GetField("BackgroundPublishReceiveBatchSize", BindingFlags.Static | BindingFlags.NonPublic)
                    .GetValue(consumer);

        /// <summary>
        ///   Allows for observation of operations performed by the consumer for testing purposes.
        /// </summary>
        ///
        private class ObservableTransportConsumerMock : TransportConsumer
        {
            public bool WasCloseCalled = false;
            public (int, TimeSpan?) ReceiveCalledWith;

            public new EventData LastReceivedEvent
            {
                get => base.LastReceivedEvent;
                set => base.LastReceivedEvent = value;
            }

            public override Task<IEnumerable<EventData>> ReceiveAsync(int maximumMessageCount,
                                                                      TimeSpan? maximumWaitTime,
                                                                      CancellationToken cancellationToken)
            {
                ReceiveCalledWith = (maximumMessageCount, maximumWaitTime);
                return Task.FromResult(Enumerable.Empty<EventData>());
            }

            public override Task CloseAsync(CancellationToken cancellationToken)
            {
                WasCloseCalled = true;
                return Task.CompletedTask;
            }
        }

        /// <summary>
        ///   Allows for publishing a known set of events in response to receive calls
        ///   by the consumer for testing purposes.
        /// </summary>
        ///
        private class PublishingTransportConsumerMock : TransportConsumer
        {
            public bool IsPublishingStarted = false;
            public IList<EventData> EventsToPublish = new List<EventData>(0);
            public Func<TimeSpan?> PublishDelayCallback = () => null;
            public int PublishIndex = 0;

            public PublishingTransportConsumerMock(IList<EventData> eventsToPublish = null,
                                                   bool startPublishing = false,
                                                   Func<TimeSpan?> publishDelayCallback = null) : base()
            {
                if (eventsToPublish != null)
                {
                    EventsToPublish = eventsToPublish;
                }

                if (publishDelayCallback != null)
                {
                    PublishDelayCallback = publishDelayCallback;
                }

                IsPublishingStarted = startPublishing;
            }

            public void StartPublishing() => IsPublishingStarted = true;

            public override Task<IEnumerable<EventData>> ReceiveAsync(int maximumMessageCount, TimeSpan? maximumWaitTime, CancellationToken cancellationToken)
            {
                if (!IsPublishingStarted)
                {
                    return Task.FromResult(Enumerable.Empty<EventData>());
                }

                var stopWatch = Stopwatch.StartNew();
                PublishDelayCallback?.Invoke();
                stopWatch.Stop();

                if (((maximumWaitTime.HasValue) && (stopWatch.Elapsed >= maximumWaitTime)) || (PublishIndex >= EventsToPublish.Count))
                {
                    return Task.FromResult(Enumerable.Empty<EventData>());
                }

                var index = PublishIndex;

                if (index + maximumMessageCount > EventsToPublish.Count)
                {
                    maximumMessageCount = (EventsToPublish.Count - index);
                }

                PublishIndex = (index + maximumMessageCount);
                var source = EventsToPublish.Skip(index).Take(maximumMessageCount).ToList();

                return Task.FromResult((IEnumerable<EventData>)source);
            }

            public override Task CloseAsync(CancellationToken cancellationToken) => Task.CompletedTask;
        }

        /// <summary>
        ///   Allows for invoking a callback in response to receive calls
        ///   by the consumer for testing purposes.
        /// </summary>
        ///
        private class ReceiveCallbackTransportConsumerMock : TransportConsumer
        {
            public Func<int, TimeSpan?, IEnumerable<EventData>> ReceiveCallback = (_max, _wait) => Enumerable.Empty<EventData>();

            public ReceiveCallbackTransportConsumerMock(Func<int, TimeSpan?, IEnumerable<EventData>> receiveCallback = null) : base()
            {
                if (receiveCallback != null)
                {
                    ReceiveCallback = receiveCallback;
                }
            }

            public override Task<IEnumerable<EventData>> ReceiveAsync(int maximumMessageCount, TimeSpan? maximumWaitTime, CancellationToken cancellationToken)
            {
                IEnumerable<EventData> results = ReceiveCallback(maximumMessageCount, maximumWaitTime);
                return Task.FromResult(results);
            }

            public override Task CloseAsync(CancellationToken cancellationToken) => Task.CompletedTask;
        }

        /// <summary>
        ///   Serves as a non-functional connection for testing consumer functionality.
        /// </summary>
        ///
        private class MockConnection : EventHubConnection
        {
            public EventHubRetryPolicy GetPropertiesInvokedWith = null;
            public EventHubRetryPolicy GetPartitionIdsInvokedWith = null;
            public EventHubRetryPolicy GetPartitionPropertiesInvokedWith = null;
            public TransportConsumer TransportConsumer = Mock.Of<TransportConsumer>();
            public bool WasClosed = false;

            public MockConnection(string namespaceName = "fakeNamespace",
                                  string eventHubName = "fakeEventHub") : base(namespaceName, eventHubName, Mock.Of<TokenCredential>())
            {
                FullyQualifiedNamespace = namespaceName;
                EventHubName = eventHubName;
            }

            public MockConnection(TransportConsumer transportConsumer,
                                  string namespaceName,
                                  string eventHubName) : this(namespaceName, eventHubName)
            {
                TransportConsumer = transportConsumer;
            }

            public MockConnection(TransportConsumer transportConsumer) : this(transportConsumer, "fakeNamespace", "fakeEventHub")
            {
            }

            internal override Task<EventHubProperties> GetPropertiesAsync(EventHubRetryPolicy retryPolicy,
                                                                        CancellationToken cancellationToken = default)
            {
                GetPropertiesInvokedWith = retryPolicy;
                return Task.FromResult(new EventHubProperties(EventHubName, DateTimeOffset.Parse("2015-10-27T00:00:00Z"), new string[] { "0", "1" }));
            }

            internal async override Task<string[]> GetPartitionIdsAsync(EventHubRetryPolicy retryPolicy,
                                                                        CancellationToken cancellationToken = default)
            {
                GetPartitionIdsInvokedWith = retryPolicy;
                return await base.GetPartitionIdsAsync(retryPolicy, cancellationToken);
            }

            internal override Task<PartitionProperties> GetPartitionPropertiesAsync(string partitionId,
                                                                                    EventHubRetryPolicy retryPolicy,
                                                                                    CancellationToken cancellationToken = default)
            {
                GetPartitionPropertiesInvokedWith = retryPolicy;
                return Task.FromResult(default(PartitionProperties));
            }

            internal override TransportConsumer CreateTransportConsumer(string consumerGroup, string partitionId, EventPosition eventPosition, EventHubConsumerClientOptions consumerOptions) => TransportConsumer;

            internal override TransportClient CreateTransportClient(string fullyQualifiedNamespace, string eventHubName, TokenCredential credential, EventHubConnectionOptions options)
            {
                var client = new Mock<TransportClient>();

                client
                    .Setup(client => client.ServiceEndpoint)
                    .Returns(new Uri($"amgp://{ fullyQualifiedNamespace}.com/{eventHubName}"));

                return client.Object;
            }
        }
    }
}
