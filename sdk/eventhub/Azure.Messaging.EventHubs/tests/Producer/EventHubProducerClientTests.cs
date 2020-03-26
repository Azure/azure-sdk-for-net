// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Producer;
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
        [TestCase("sb://test.place.com")]
        public void ConstructorValidatesTheNamespace(string constructorArgument)
        {
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net");
            Assert.That(() => new EventHubProducerClient(constructorArgument, "dummy", credential.Object), Throws.InstanceOf<ArgumentException>());
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
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net");
            Assert.That(() => new EventHubProducerClient("namespace", constructorArgument, credential.Object), Throws.InstanceOf<ArgumentException>());
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
            var expected = Mock.Of<EventHubsRetryPolicy>();
            var options = new EventHubProducerClientOptions { RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = expected } };
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
            var expected = Mock.Of<EventHubsRetryPolicy>();
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net");
            var options = new EventHubProducerClientOptions { RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = expected } };
            var producer = new EventHubProducerClient("namespace", "eventHub", credential.Object, options);

            Assert.That(GetRetryPolicy(producer), Is.SameAs(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionConstructorSetsTheRetryPolicy()
        {
            var expected = Mock.Of<EventHubsRetryPolicy>();
            var options = new EventHubProducerClientOptions { RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = expected } };
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
            var credential = new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net");
            var expected = new EventHubProducerClientOptions().RetryOptions;
            var producer = new EventHubProducerClient("namespace", "eventHub", credential.Object);

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
        public void ProducerDelegatesForTheFullyQualifiedNamespace()
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
            var retryPolicy = Mock.Of<EventHubsRetryPolicy>();
            var options = new EventHubProducerClientOptions { RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = retryPolicy } };
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
            var retryPolicy = Mock.Of<EventHubsRetryPolicy>();
            var options = new EventHubProducerClientOptions { RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = retryPolicy } };
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
            var retryPolicy = Mock.Of<EventHubsRetryPolicy>();
            var options = new EventHubProducerClientOptions { RetryOptions = new EventHubsRetryOptions { CustomRetryPolicy = retryPolicy } };
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
            Assert.That(async () => await producer.SendAsync(default(EventData), new SendEventOptions()), Throws.ArgumentNullException);
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
                .Setup(instance => instance.SendAsync(It.Is<IEnumerable<EventData>>(value => value.Count() == 1), It.IsAny<SendEventOptions>(), It.IsAny<CancellationToken>()))
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
                .Setup(instance => instance.SendAsync(It.Is<IEnumerable<EventData>>(value => value.Count() == 1), It.IsAny<SendEventOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask)
                .Verifiable("The single send should delegate to the batch send.");

            await producer.Object.SendAsync(new EventData(new byte[] { 0x22 }), new SendEventOptions());
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
            var producer = new EventHubProducerClient(new MockConnection(() => transportProducer));

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
            var producer = new EventHubProducerClient(new MockConnection(() => transportProducer));

            Assert.That(async () => await producer.SendAsync(default(IEnumerable<EventData>), new SendEventOptions()), Throws.ArgumentNullException);
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
            var producer = new EventHubProducerClient(new MockConnection(() => transportProducer));

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
            var sendOptions = new SendEventOptions { PartitionKey = "testKey" };
            var events = new[] { new EventData(new byte[] { 0x44, 0x66, 0x88 }) };
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(() => transportProducer));

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
            var batchOptions = new CreateBatchOptions { PartitionKey = "testKey" };
            var batch = new EventDataBatch(new MockTransportBatch(), "ns", "eh", batchOptions.ToSendOptions());
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(() => transportProducer));

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
            var sendOptions = new SendEventOptions { PartitionKey = "testKey", PartitionId = "1" };
            var events = new[] { new EventData(new byte[] { 0x44, 0x66, 0x88 }) };
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(() => transportProducer));

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
            var batchOptions = new CreateBatchOptions { PartitionKey = "testKey", PartitionId = "1" };
            var batch = new EventDataBatch(new MockTransportBatch(), "ns", "eh", batchOptions.ToSendOptions());
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(() => transportProducer));

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
            var producer = new EventHubProducerClient(new MockConnection(() => transportProducer));

            await producer.SendAsync(events);

            (IEnumerable<EventData> calledWithEvents, SendEventOptions calledWithOptions) = transportProducer.SendCalledWith;

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
            var options = new SendEventOptions();
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(() => transportProducer));

            await producer.SendAsync(events, options);

            (IEnumerable<EventData> calledWithEvents, SendEventOptions calledWithOptions) = transportProducer.SendCalledWith;

            Assert.That(calledWithEvents, Is.EquivalentTo(events), "The events should contain same elements.");
            Assert.That(calledWithOptions, Is.SameAs(options), "The options should be the same instance");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendManageLockingTheBatch()
        {
            var batchOptions = new CreateBatchOptions { PartitionKey = "testKey" };
            var batch = new EventDataBatch(new MockTransportBatch(), "ns", "eh", batchOptions.ToSendOptions());
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(() => transportProducer));

            await producer.SendAsync(batch);
            Assert.That(transportProducer.SendBatchCalledWith, Is.SameAs(batch), "The batch should be the same instance.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.SendAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendInvokesTheTransportProducerWithABatch()
        {
            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(TimeSpan.FromSeconds(15));

            var batchOptions = new CreateBatchOptions { PartitionKey = "testKey" };
            var completionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var mockTransportBatch = new Mock<TransportEventBatch>();
            var mockTransportProducer = new Mock<TransportProducer>();
            var batch = new EventDataBatch(mockTransportBatch.Object, "ns", "eh", batchOptions.ToSendOptions());
            var producer = new EventHubProducerClient(new MockConnection(() => mockTransportProducer.Object));

            mockTransportBatch
                .Setup(transport => transport.TryAdd(It.IsAny<EventData>()))
                .Returns(true);

            mockTransportProducer
                .Setup(transport => transport.SendAsync(It.IsAny<EventDataBatch>(), It.IsAny<CancellationToken>()))
                .Returns(async () => await Task.WhenAny(completionSource.Task, Task.Delay(Timeout.Infinite, cancellationSource.Token)));

            Assert.That(batch.TryAdd(new EventData(Array.Empty<byte>())), Is.True, "The batch should not be locked before sending.");
            var sendTask = producer.SendAsync(batch);

            Assert.That(() => batch.TryAdd(new EventData(Array.Empty<byte>())), Throws.InstanceOf<InvalidOperationException>(), "The batch should be locked while sending.");
            completionSource.TrySetResult(true);

            await sendTask;
            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The cancellation token should not have been signaled.");
            Assert.That(batch.TryAdd(new EventData(Array.Empty<byte>())), Is.True, "The batch should not be locked after sending.");

            cancellationSource.Cancel();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.CreateBatchAsync"/>
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateBatchForASpecificPartitionDoesNotAllowAPartitionHashKey()
        {
            var batchOptions = new CreateBatchOptions { PartitionKey = "testKey", PartitionId = "1" };
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(() => transportProducer));

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
            var batchOptions = new CreateBatchOptions { PartitionKey = "Hi", MaximumSizeInBytes = 9999 };
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(() => transportProducer));

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
            var expectedOptions = new CreateBatchOptions();
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(() => transportProducer));

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
            var batchOptions = new CreateBatchOptions { PartitionKey = "Hi", MaximumSizeInBytes = 9999 };
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducerClient(new MockConnection(() => transportProducer));
            var eventBatch = await producer.CreateBatchAsync(batchOptions);

            Assert.That(eventBatch.SendOptions.PartitionId, Is.EqualTo(transportProducer.CreateBatchCalledWith.PartitionId), "The batch options should have used for the send options, but the partition identifier didn't match.");
            Assert.That(eventBatch.SendOptions.PartitionKey, Is.EqualTo(transportProducer.CreateBatchCalledWith.PartitionKey), "The batch options should have used for the send options, but the partition key didn't match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncClosesTheTransportProducers()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var mockFirstBatch = new EventDataBatch(new MockTransportBatch(), "ns", "eh", new SendEventOptions { PartitionId = "1" });
            var mockSecondBatch = new EventDataBatch(new MockTransportBatch(), "ns", "eh", new SendEventOptions { PartitionId = "2" });
            var producer = new EventHubProducerClient(new MockConnection(() => transportProducer));

            try
            { await producer.SendAsync(mockFirstBatch); }
            catch { }
            try
            { await producer.SendAsync(mockSecondBatch); }
            catch { }

            await producer.CloseAsync();

            Assert.That(transportProducer.WasCloseCalled, Is.True);
            Assert.That(transportProducer.CloseCallCount, Is.EqualTo(3));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClient.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncSurfacesExceptionsForTransportConsumers()
        {
            var mockTransportProducer = new Mock<TransportProducer>();
            var mockConnection = new MockConnection(() => mockTransportProducer.Object);
            var mockBatch = new EventDataBatch(new MockTransportBatch(), "ns", "eh", new SendEventOptions { PartitionId = "1" });
            var producer = new EventHubProducerClient(mockConnection);

            mockTransportProducer
                .Setup(producer => producer.CloseAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromException(new InvalidCastException()));

            try
            { await producer.SendAsync(mockBatch); }
            catch { }

            Assert.That(async () => await producer.CloseAsync(), Throws.InstanceOf<InvalidCastException>());
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
            Assert.That(connection.IsClosed, Is.True);
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
            var connection = new MockConnection(() => transportProducer);
            var producer = new EventHubProducerClient(connection);

            await producer.CloseAsync();
            Assert.That(connection.IsClosed, Is.False);
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
        private static EventHubsRetryPolicy GetRetryPolicy(EventHubProducerClient producer) =>
            (EventHubsRetryPolicy)
                typeof(EventHubProducerClient)
                    .GetProperty("RetryPolicy", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(producer);

        /// <summary>
        ///   Allows for observation of operations performed by the producer for testing purposes.
        /// </summary>
        ///
        private class ObservableTransportProducerMock : TransportProducer
        {
            public int CloseCallCount = 0;
            public bool WasCloseCalled = false;
            public (IEnumerable<EventData>, SendEventOptions) SendCalledWith;
            public EventDataBatch SendBatchCalledWith;
            public CreateBatchOptions CreateBatchCalledWith;

            public override Task SendAsync(IEnumerable<EventData> events,
                                           SendEventOptions sendOptions,
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

            public override ValueTask<TransportEventBatch> CreateBatchAsync(CreateBatchOptions options,
                                                                            CancellationToken cancellationToken)
            {
                CreateBatchCalledWith = options;
                return new ValueTask<TransportEventBatch>(Task.FromResult((TransportEventBatch)new MockTransportBatch()));
            }

            public override Task CloseAsync(CancellationToken cancellationToken)
            {
                WasCloseCalled = true;
                ++CloseCallCount;
                return Task.CompletedTask;
            }
        }

        /// <summary>
        ///   Serves as a non-functional connection for testing producer functionality.
        /// </summary>
        ///
        private class MockConnection : EventHubConnection
        {
            public EventHubsRetryPolicy GetPropertiesInvokedWith = null;
            public EventHubsRetryPolicy GetPartitionIdsInvokedWith = null;
            public EventHubsRetryPolicy GetPartitionPropertiesInvokedWith = null;
            public Func<TransportProducer> TransportProducerFactory = () => Mock.Of<TransportProducer>();

            public bool WasClosed = false;

            public MockConnection(string namespaceName = "fakeNamespace",
                                  string eventHubName = "fakeEventHub") : base(namespaceName, eventHubName, new Mock<EventHubTokenCredential>(Mock.Of<TokenCredential>(), "{namespace}.servicebus.windows.net").Object)
            {
            }

            public MockConnection(Func<TransportProducer> transportProducerFactory,
                                  string namespaceName,
                                  string eventHubName) : this(namespaceName, eventHubName)
            {
                TransportProducerFactory = transportProducerFactory;
            }

            public MockConnection(Func<TransportProducer> transportProducerFactory) : this(transportProducerFactory, "fakeNamespace", "fakeEventHub")
            {
            }

            internal override Task<EventHubProperties> GetPropertiesAsync(EventHubsRetryPolicy retryPolicy,
                                                                        CancellationToken cancellationToken = default)
            {
                GetPropertiesInvokedWith = retryPolicy;
                return Task.FromResult(new EventHubProperties(EventHubName, DateTimeOffset.Parse("2015-10-27T00:00:00Z"), new string[] { "0", "1" }));
            }

            internal override async Task<string[]> GetPartitionIdsAsync(EventHubsRetryPolicy retryPolicy,
                                                                        CancellationToken cancellationToken = default)
            {
                GetPartitionIdsInvokedWith = retryPolicy;
                return await base.GetPartitionIdsAsync(retryPolicy, cancellationToken);
            }

            internal override Task<PartitionProperties> GetPartitionPropertiesAsync(string partitionId,
                                                                                    EventHubsRetryPolicy retryPolicy,
                                                                                    CancellationToken cancellationToken = default)
            {
                GetPartitionPropertiesInvokedWith = retryPolicy;
                return Task.FromResult(default(PartitionProperties));
            }

            internal override TransportProducer CreateTransportProducer(string partitionId,
                                                                        EventHubsRetryPolicy retryPolicy) => TransportProducerFactory();

            internal override TransportClient CreateTransportClient(string fullyQualifiedNamespace, string eventHubName, EventHubTokenCredential credential, EventHubConnectionOptions options)
            {
                var client = new Mock<TransportClient>();

                client
                    .Setup(client => client.ServiceEndpoint)
                    .Returns(new Uri($"amgp://{ fullyQualifiedNamespace }.com/{ eventHubName }"));

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
