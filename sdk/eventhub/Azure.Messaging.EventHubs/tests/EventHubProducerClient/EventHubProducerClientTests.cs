// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Metadata;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventHubProducerClient" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventHubProducerClientTests
    {
        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheConnectionString(string connectionString)
        {
            Assert.That(() => new EventHubProducerClient(connectionString, "dummy"), Throws.InstanceOf<ArgumentException>(), "The constructor without options should ensure a connection string.");
            Assert.That(() => new EventHubProducerClient(connectionString, "dummy", new EventHubProducerClientOptions()), Throws.InstanceOf<ArgumentException>(), "The constructor with options should ensure a connection string.");
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
            Assert.That(() => new EventHubProducerClient(constructorArgument, "dummy", Mock.Of<TokenCredential>()), Throws.InstanceOf<ArgumentException>());
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
            Assert.That(() => new EventHubProducerClient("namespace", constructorArgument, Mock.Of<TokenCredential>()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheCredential()
        {
            Assert.That(() => new EventHubProducerClient("namespace", "hubName", default(TokenCredential)), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheConnection()
        {
            Assert.That(() => new EventHubProducerClient(default(EventHubConnection)), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorSetsTheRetryPolicy()
        {
            var expected = Mock.Of<EventHubRetryPolicy>();
            var options = new EventHubProducerClientOptions { RetryOptions = new RetryOptions { CustomRetryPolicy = expected } };
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var producer = new EventHubProducerClient(connectionString, options);

            Assert.That(GetRetryPolicy(producer), Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ExpandedConstructorSetsTheRetryPolicy()
        {
            var expected = Mock.Of<EventHubRetryPolicy>();
            var options = new EventHubProducerClientOptions { RetryOptions = new RetryOptions { CustomRetryPolicy = expected } };
            var producer = new EventHubProducerClient("namespace", "eventHub", Mock.Of<TokenCredential>(), options);

            Assert.That(GetRetryPolicy(producer), Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionConstructorSetsTheRetryPolicy()
        {
            var expected = Mock.Of<EventHubRetryPolicy>();
            var options = new EventHubProducerClientOptions { RetryOptions = new RetryOptions { CustomRetryPolicy = expected } };
            var mockConnection = new MockConnection();
            var producer = new EventHubProducerClient(mockConnection, options);

            Assert.That(GetRetryPolicy(producer), Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionStringConstructorCreatesDefaultOptions()
        {
            var expected = new EventHubProducerClientOptions().RetryOptions;
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var producer = new EventHubProducerClient(connectionString);

            var policy = GetRetryPolicy(producer);
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
            var expected = new EventHubProducerClientOptions().RetryOptions;
            var producer = new EventHubProducerClient("namespace", "eventHub", Mock.Of<TokenCredential>());

            var policy = GetRetryPolicy(producer);
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
            var expected = new EventHubProducerClientOptions().RetryOptions;
            var mockConnection = new MockConnection();
            var producer = new EventHubProducerClient(mockConnection);

            var policy = GetRetryPolicy(producer);
            Assert.That(policy, Is.Not.Null, "There should have been a retry policy set.");
            Assert.That(policy, Is.InstanceOf<BasicRetryPolicy>(), "The default retry policy should be a basic policy.");

            var actual = ((BasicRetryPolicy)policy).Options;
            Assert.That(actual.IsEquivalentTo(expected), Is.True, "The default retry policy should be based on the default retry options.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.FullyQualifiedNamespace" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void ProducerDelegatesForTheFullyQualifiedNamespaceName()
        {
            var expected = "SomeNamespace";
            var mockConnection = new MockConnection(expected);
            var producer = new EventHubProducerClient(mockConnection);
            Assert.That(producer.FullyQualifiedNamespace, Is.EqualTo(expected));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.EventHubName" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void ProducerDelegatesForTheEventHubName()
        {
            var expected = "EventHubName";
            var mockConnection = new MockConnection(eventHubName: expected);
            var producer = new EventHubProducerClient(mockConnection);
            Assert.That(producer.EventHubName, Is.EqualTo(expected));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.GetEventHubPropertiesAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetEventHubPropertiesAsyncUsesTheRetryPolicy()
        {
            var mockConnection = new MockConnection();
            var retryPolicy = Mock.Of<EventHubRetryPolicy>();
            var options = new EventHubProducerClientOptions { RetryOptions = new RetryOptions { CustomRetryPolicy = retryPolicy } };
            var producer = new EventHubProducerClient(mockConnection, options);

            await producer.GetEventHubPropertiesAsync();
            Assert.That(mockConnection.GetPropertiesInvokedWith, Is.SameAs(retryPolicy), "Either the call was not delegated or the retry policy was not passed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.GetPartitionIdsAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetPartitionIdsUsesTheRetryPolicy()
        {
            var mockConnection = new MockConnection();
            var retryPolicy = Mock.Of<EventHubRetryPolicy>();
            var options = new EventHubProducerClientOptions { RetryOptions = new RetryOptions { CustomRetryPolicy = retryPolicy } };
            var producer = new EventHubProducerClient(mockConnection, options);

            await producer.GetPartitionIdsAsync();
            Assert.That(mockConnection.GetPartitionIdsInvokedWith, Is.SameAs(retryPolicy), "Either the call was not delegated or the retry policy was not passed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.GetPartitionPropertiesAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetPartitionPropertiesUsesTheRetryPolicy()
        {
            var mockConnection = new MockConnection();
            var retryPolicy = Mock.Of<EventHubRetryPolicy>();
            var options = new EventHubProducerClientOptions { RetryOptions = new RetryOptions { CustomRetryPolicy = retryPolicy } };
            var producer = new EventHubProducerClient(mockConnection, options);

            await producer.GetPartitionPropertiesAsync("1");
            Assert.That(mockConnection.GetPartitionPropertiesInvokedWith, Is.SameAs(retryPolicy), "Either the call was not delegated or the retry policy was not passed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendSingleWithoutOptionsRequiresAnEvent()
        {
            var producer = new EventHubProducerClient(new MockConnection());
            Assert.That(async () => await producer.SendAsync(default(EventData)), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendSingleRequiresAnEvent()
        {
            var producer = new EventHubProducerClient(new MockConnection());
            Assert.That(async () => await producer.SendAsync(default(EventData), new SendOptions()), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendSingleWithoutOptionsDelegatesToBatchSend()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new Mock<EventHubProducerClient> { CallBase = true };

            producer
                .Setup(instance => instance.SendAsync(It.Is<IEnumerable<EventData>>(value => value.Count() == 1), It.IsAny<SendOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask)
                .Verifiable("The single send should delegate to the batch send.");

            await producer.Object.SendAsync(new EventData(new byte[] { 0x22 }));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendSingleWitOptionsDelegatesToBatchSend()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new Mock<EventHubProducerClient> { CallBase = true };

            producer
                .Setup(instance => instance.SendAsync(It.Is<IEnumerable<EventData>>(value => value.Count() == 1), It.IsAny<SendOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask)
                .Verifiable("The single send should delegate to the batch send.");

            await producer.Object.SendAsync(new EventData(new byte[] { 0x22 }), new SendOptions());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendWithoutOptionsRequiresEvents()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(transportProducer));

            Assert.That(async () => await producer.SendAsync(default(IEnumerable<EventData>)), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendRequiresEvents()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(transportProducer));

            Assert.That(async () => await producer.SendAsync(default(IEnumerable<EventData>), new SendOptions()), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendRequiresTheBatch()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(transportProducer));

            Assert.That(async () => await producer.SendAsync(default(EventDataBatch)), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendAllowsAPartitionHashKey()
        {
            var sendOptions = new SendOptions { PartitionKey = "testKey" };
            var events = new[] { new EventData(new byte[] { 0x44, 0x66, 0x88 }) };
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(transportProducer));

            Assert.That(async () => await producer.SendAsync(events, sendOptions), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendAllowsAPartitionHashKeyWithABatch()
        {
            var batchOptions = new BatchOptions { PartitionKey = "testKey" };
            var batch = new EventDataBatch(new MockTransportBatch(), batchOptions);
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(transportProducer));

            Assert.That(async () => await producer.SendAsync(batch), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendForASpecificPartitionDoesNotAllowAPartitionHashKey()
        {
            var sendOptions = new SendOptions { PartitionKey = "testKey" };
            var events = new[] { new EventData(new byte[] { 0x44, 0x66, 0x88 }) };
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(transportProducer), new EventHubProducerClientOptions { PartitionId = "1" });

            Assert.That(async () => await producer.SendAsync(events, sendOptions), Throws.InvalidOperationException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SendForASpecificPartitionDoesNotAllowAPartitionHashKeyWithABatch()
        {
            var batchOptions = new BatchOptions { PartitionKey = "testKey" };
            var batch = new EventDataBatch(new MockTransportBatch(), batchOptions);
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(transportProducer), new EventHubProducerClientOptions { PartitionId = "1" });

            Assert.That(async () => await producer.SendAsync(batch), Throws.InvalidOperationException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendWithoutOptionsInvokesTheTransportProducer()
        {
            var events = new EventData[0];
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(transportProducer));

            await producer.SendAsync(events);

            (IEnumerable<EventData> calledWithEvents, SendOptions calledWithOptions) = transportProducer.SendCalledWith;

            Assert.That(calledWithEvents, Is.EquivalentTo(events), "The events should contain same elements.");
            Assert.That(calledWithOptions, Is.Not.Null, "A default set of options should be used.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendInvokesTheTransportProducer()
        {
            var events = new EventData[0];
            var options = new SendOptions();
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(transportProducer));

            await producer.SendAsync(events, options);

            (IEnumerable<EventData> calledWithEvents, SendOptions calledWithOptions) = transportProducer.SendCalledWith;

            Assert.That(calledWithEvents, Is.EquivalentTo(events), "The events should contain same elements.");
            Assert.That(calledWithOptions, Is.SameAs(options), "The options should be the same instance");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendInvokesTheTransportProducerWithABatch()
        {
            var batchOptions = new BatchOptions { PartitionKey = "testKey" };
            var batch = new EventDataBatch(new MockTransportBatch(), batchOptions);
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(transportProducer));

            await producer.SendAsync(batch);
            Assert.That(transportProducer.SendBatchCalledWith, Is.SameAs(batch), "The batch should be the same instance.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.CreateBatchAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateBatchForASpecificPartitionDoesNotAllowAPartitionHashKey()
        {
            var batchOptions = new BatchOptions { PartitionKey = "testKey" };
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(transportProducer), new EventHubProducerClientOptions { PartitionId = "1" });

            Assert.That(async () => await producer.CreateBatchAsync(batchOptions), Throws.InvalidOperationException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.CreateBatchAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateBatchInvokesTheTransportProducer()
        {
            var batchOptions = new BatchOptions { PartitionKey = "Hi", MaximumSizeInBytes = 9999 };
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(transportProducer));

            await producer.CreateBatchAsync(batchOptions);

            Assert.That(transportProducer.CreateBatchCalledWith, Is.Not.Null, "The batch creation should have passed options.");
            Assert.That(transportProducer.CreateBatchCalledWith, Is.Not.SameAs(batchOptions), "The options should have been cloned.");
            Assert.That(transportProducer.CreateBatchCalledWith.PartitionKey, Is.EqualTo(batchOptions.PartitionKey), "The partition key should match.");
            Assert.That(transportProducer.CreateBatchCalledWith.MaximumSizeInBytes, Is.EqualTo(batchOptions.MaximumSizeInBytes), "The maximum size should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.CreateBatchAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateBatchDefaultsBatchOptions()
        {
            var expectedOptions = new BatchOptions();
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(transportProducer));

            await producer.CreateBatchAsync();

            Assert.That(transportProducer.CreateBatchCalledWith, Is.Not.Null, "The batch creation should have passed options.");
            Assert.That(transportProducer.CreateBatchCalledWith, Is.Not.SameAs(expectedOptions), "The options should have been cloned.");
            Assert.That(transportProducer.CreateBatchCalledWith.PartitionKey, Is.EqualTo(expectedOptions.PartitionKey), "The partition key should match.");
            Assert.That(transportProducer.CreateBatchCalledWith.MaximumSizeInBytes, Is.EqualTo(expectedOptions.MaximumSizeInBytes), "The maximum size should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.CreateBatchAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateBatchSetsTheSendOptionsForTheEventBatch()
        {
            var batchOptions = new BatchOptions { PartitionKey = "Hi", MaximumSizeInBytes = 9999 };
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(transportProducer));
            var eventBatch = await producer.CreateBatchAsync(batchOptions);

            Assert.That(eventBatch.SendOptions, Is.SameAs(transportProducer.CreateBatchCalledWith), "The batch options should have used for the send options.");
            ;
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncClosesTheTransportProducer()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(transportProducer));

            await producer.CloseAsync();

            Assert.That(transportProducer.WasCloseCalled, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.Close" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloseClosesTheTransportProducer()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(transportProducer));

            producer.Close();

            Assert.That(transportProducer.WasCloseCalled, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncClosesTheConnectionWhenOwned()
        {
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var producer = new EventHubProducerClient(connectionString);

            await producer.CloseAsync();

            var connection = GetConnection(producer);
            Assert.That(connection.Closed, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.Close" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloseClosesTheConnectionWhenOwned()
        {
            var connectionString = "Endpoint=sb://somehost.com;SharedAccessKeyName=ABC;SharedAccessKey=123;EntityPath=somehub";
            var producer = new EventHubProducerClient(connectionString);

            producer.Close();

            var connection = GetConnection(producer);
            Assert.That(connection.Closed, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncDoesNotCloseTheConnectionWhenNotOwned()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var connection = new MockConnection(transportProducer);
            var producer = new EventHubProducerClient(connection);

            await producer.CloseAsync();
            Assert.That(connection.Closed, Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.Close" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloseDoesNotCloseTheConnectionWhenNotOwned()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var connection = new MockConnection(transportProducer);
            var producer = new EventHubProducerClient(connection);

            producer.Close();
            Assert.That(connection.Closed, Is.False);
        }

        /// <summary>
        ///   Retrieves the Connection for the producer using its private accessor.
        /// </summary>
        ///
        private static EventHubConnection GetConnection(EventHubProducerClient producer) =>
            (EventHubConnection)
                typeof(EventHubProducerClient)
                    .GetProperty("Connection", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(producer);

        /// <summary>
        ///   Retrieves the RetryPolicy for the producer using its private accessor.
        /// </summary>
        ///
        private static EventHubRetryPolicy GetRetryPolicy(EventHubProducerClient producer) =>
            (EventHubRetryPolicy)
                typeof(EventHubProducerClient)
                    .GetProperty("RetryPolicy", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(producer);

        /// <summary>
        ///   Allows for observation of operations performed by the producer for testing purposes.
        /// </summary>
        ///
        private class ObservableTransportProducerMock : TransportProducer
        {
            public bool WasCloseCalled = false;
            public (IEnumerable<EventData>, SendOptions) SendCalledWith;
            public EventDataBatch SendBatchCalledWith;
            public BatchOptions CreateBatchCalledWith;

            public override Task SendAsync(IEnumerable<EventData> events,
                                           SendOptions sendOptions,
                                           CancellationToken cancellationToken)
            {
                SendCalledWith = (events, sendOptions);
                return Task.CompletedTask;
            }
            public override Task SendAsync(EventDataBatch batch,
                                           CancellationToken cancellationToken)
            {
                SendBatchCalledWith = batch;
                return Task.CompletedTask;
            }

            public override ValueTask<TransportEventBatch> CreateBatchAsync(BatchOptions options,
                                                                            CancellationToken cancellationToken)
            {
                CreateBatchCalledWith = options;
                return new ValueTask<TransportEventBatch>(Task.FromResult((TransportEventBatch)new MockTransportBatch()));
            }

            public override Task CloseAsync(CancellationToken cancellationToken)
            {
                WasCloseCalled = true;
                return Task.CompletedTask;
            }
        }

        /// <summary>
        ///   Serves as a non-functional connection for testing producer functionality.
        /// </summary>
        ///
        private class MockConnection : EventHubConnection
        {
            public EventHubRetryPolicy GetPropertiesInvokedWith = null;
            public EventHubRetryPolicy GetPartitionIdsInvokedWith = null;
            public EventHubRetryPolicy GetPartitionPropertiesInvokedWith = null;
            public TransportProducer TransportProducer = Mock.Of<TransportProducer>();
            public bool WasClosed = false;

            public MockConnection(string namespaceName = "fakeNamespace",
                                  string eventHubName = "fakeEventHub") : base(namespaceName, eventHubName, Mock.Of<TokenCredential>())
            {
                FullyQualifiedNamespace = namespaceName;
                EventHubName = eventHubName;
            }

            public MockConnection(TransportProducer transportProducer,
                                  string namespaceName,
                                  string eventHubName) : this(namespaceName, eventHubName)
            {
                TransportProducer = transportProducer;
            }

            public MockConnection(TransportProducer transportProducer) : this(transportProducer, "fakeNamespace", "fakeEventHub")
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

            internal override TransportProducer CreateTransportProducer(EventHubProducerClientOptions producerOptions = default) => TransportProducer;

            internal override TransportClient CreateTransportClient(string fullyQualifiedNamespace, string eventHubName, TokenCredential credential, EventHubConnectionOptions options)
            {
                var client = new Mock<TransportClient>();

                client
                    .Setup(client => client.ServiceEndpoint)
                    .Returns(new Uri($"amgp://{ fullyQualifiedNamespace}.com/{eventHubName}"));

                return client.Object;
            }
        }

        /// <summary>
        ///   Serves as a non-functional transport event batch for satisfying the
        ///   non-null constraints of the <see cref="EventDataBatch" /> created by
        ///   the producer being tested.
        /// </summary>
        ///
        private class MockTransportBatch : TransportEventBatch
        {
            public override long MaximumSizeInBytes { get; }
            public override long SizeInBytes { get; }
            public override int Count { get; }
            public override bool TryAdd(EventData eventData) => throw new NotImplementedException();
            public override IEnumerable<T> AsEnumerable<T>() => throw new NotImplementedException();
            public override void Dispose() => throw new NotImplementedException();
        }
    }
}
