// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Core;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventHubProducer" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class EventHubProducerTests
    {
        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheProducer()
        {
            Assert.That(() => new EventHubProducer(null, "dummy", new EventHubProducerOptions(), Mock.Of<EventHubRetryPolicy>()), Throws.ArgumentNullException);
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
            Assert.That(() => new EventHubProducer(new ObservableTransportProducerMock(), eventHubName, new EventHubProducerOptions(), Mock.Of<EventHubRetryPolicy>()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheOptions()
        {
            Assert.That(() => new EventHubProducer(new ObservableTransportProducerMock(), "dummy", null, Mock.Of<EventHubRetryPolicy>()), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheDefaultRetryPolicy()
        {
            Assert.That(() => new EventHubProducer(new ObservableTransportProducerMock(), "dummy", new EventHubProducerOptions(), null), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase("123")]
        [TestCase(" ")]
        [TestCase("someValue")]
        public void ConstructorSetsTheEventHubName(string eventHubName)
        {
            var producer = new EventHubProducer(new ObservableTransportProducerMock(), eventHubName, new EventHubProducerOptions(), Mock.Of<EventHubRetryPolicy>());
            Assert.That(producer.EventHubName, Is.EqualTo(eventHubName));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorSetsTheRetryPolicy()
        {
            var retryPolicy = Mock.Of<EventHubRetryPolicy>();
            var producer = new EventHubProducer(new ObservableTransportProducerMock(), "path", new EventHubProducerOptions(), retryPolicy);
            Assert.That(producer.RetryPolicy, Is.SameAs(retryPolicy));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducer.RetryPolicy" />
        ///   setter.
        /// </summary>
        ///
        [Test]
        public void SettingTheRetryUpdatesState()
        {
            var retryOptions = new RetryOptions
            {
                Delay = TimeSpan.FromSeconds(1),
                MaximumDelay = TimeSpan.FromSeconds(2),
                TryTimeout = TimeSpan.FromSeconds(3),
                MaximumRetries = 4,
                Mode = RetryMode.Fixed
            };

            var customRetry = Mock.Of<EventHubRetryPolicy>();
            var producerOptions = new EventHubProducerOptions { RetryOptions = retryOptions };
            var producer = new EventHubProducer(new ObservableTransportProducerMock(), "dummy", producerOptions, new BasicRetryPolicy(retryOptions));

            Assert.That(producer.RetryPolicy, Is.InstanceOf<BasicRetryPolicy>(), "The retry policy should have been created from options");

            producer.RetryPolicy = customRetry;
            Assert.That(producer.RetryPolicy, Is.SameAs(customRetry), "The custom retry policy should have been set.");

            var activeOptions = (EventHubProducerOptions)
                typeof(EventHubProducer)
                    .GetProperty("Options", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(producer);

            Assert.That(activeOptions.RetryOptions, Is.Null, "Setting a custom policy should clear the retry options.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducer.RetryPolicy" />
        ///   setter.
        /// </summary>
        ///
        [Test]
        public void SettingTheRetryUpdatesTheTransportProducer()
        {
            var customRetry = Mock.Of<EventHubRetryPolicy>();
            var transportProducer = new ObservableTransportProducerMock();
            var producerOptions = new EventHubProducerOptions();
            var producer = new EventHubProducer(transportProducer, "dummy", producerOptions, Mock.Of<EventHubRetryPolicy>());

            producer.RetryPolicy = customRetry;
            Assert.That(transportProducer.UpdateRetryPolicyCalledWith, Is.SameAs(customRetry), "The custom retry policy should have been passed to the transport producer.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducer.SendAsync"/>
        /// </summary>
        ///
        [Test]
        public void SendSingleWithoutOptionsRequiresAnEvent()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducer(transportProducer, "dummy", new EventHubProducerOptions(), Mock.Of<EventHubRetryPolicy>());

            Assert.That(async () => await producer.SendAsync(default(EventData)), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducer.SendAsync"/>
        /// </summary>
        ///
        [Test]
        public void SendSingleRequiresAnEvent()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducer(transportProducer, "dummy", new EventHubProducerOptions(), Mock.Of<EventHubRetryPolicy>());

            Assert.That(async () => await producer.SendAsync(default(EventData), new SendOptions()), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducer.SendAsync"/>
        /// </summary>
        ///
        [Test]
        public async Task SendSingleWithoutOptionsDelegatesToBatchSend()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new Mock<EventHubProducer> { CallBase = true };

            producer
                .Setup(instance => instance.SendAsync(It.Is<IEnumerable<EventData>>(value => value.Count() == 1), It.IsAny<SendOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask)
                .Verifiable("The single send should delegate to the batch send.");

            await producer.Object.SendAsync(new EventData(new byte[] { 0x22 }));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducer.SendAsync"/>
        /// </summary>
        ///
        [Test]
        public async Task SendSingleWitOptionsDelegatesToBatchSend()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new Mock<EventHubProducer> { CallBase = true };

            producer
                .Setup(instance => instance.SendAsync(It.Is<IEnumerable<EventData>>(value => value.Count() == 1), It.IsAny<SendOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask)
                .Verifiable("The single send should delegate to the batch send.");

            await producer.Object.SendAsync(new EventData(new byte[] { 0x22 }), new SendOptions());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducer.SendAsync"/>
        /// </summary>
        ///
        [Test]
        public void SendWithoutOptionsRequiresEvents()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducer(transportProducer, "dummy", new EventHubProducerOptions(), Mock.Of<EventHubRetryPolicy>());

            Assert.That(async () => await producer.SendAsync(default(IEnumerable<EventData>)), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducer.SendAsync"/>
        /// </summary>
        ///
        [Test]
        public void SendRequiresEvents()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducer(transportProducer, "dummy", new EventHubProducerOptions(), Mock.Of<EventHubRetryPolicy>());

            Assert.That(async () => await producer.SendAsync(default(IEnumerable<EventData>), new SendOptions()), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducer.SendAsync"/>
        /// </summary>
        ///
        [Test]
        public void SendRequiresTheBatch()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducer(transportProducer, "dummy", new EventHubProducerOptions(), Mock.Of<EventHubRetryPolicy>());

            Assert.That(async () => await producer.SendAsync(default(EventDataBatch)), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducer.SendAsync"/>
        /// </summary>
        ///
        [Test]
        public void SendAllowsAPartitionHashKey()
        {
            var sendOptions = new SendOptions { PartitionKey = "testKey" };
            var events = new[] { new EventData(new byte[] { 0x44, 0x66, 0x88 }) };
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducer(transportProducer, "dummy", new EventHubProducerOptions(), Mock.Of<EventHubRetryPolicy>());

            Assert.That(async () => await producer.SendAsync(events, sendOptions), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducer.SendAsync"/>
        /// </summary>
        ///
        [Test]
        public void SendAllowsAPartitionHashKeyWithABatch()
        {
            var batchOptions = new BatchOptions { PartitionKey = "testKey" };
            var batch = new EventDataBatch(new MockTransportBatch(), batchOptions);
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducer(transportProducer, "dummy", new EventHubProducerOptions(), Mock.Of<EventHubRetryPolicy>());

            Assert.That(async () => await producer.SendAsync(batch), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducer.SendAsync"/>
        /// </summary>
        ///
        [Test]
        public void SendForASpecificPartitionDoesNotAllowAPartitionHashKey()
        {
            var sendOptions = new SendOptions { PartitionKey = "testKey" };
            var events = new[] { new EventData(new byte[] { 0x44, 0x66, 0x88 }) };
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducer(transportProducer, "dummy", new EventHubProducerOptions { PartitionId = "1" }, Mock.Of<EventHubRetryPolicy>());

            Assert.That(async () => await producer.SendAsync(events, sendOptions), Throws.InvalidOperationException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducer.SendAsync"/>
        /// </summary>
        ///
        [Test]
        public void SendForASpecificPartitionDoesNotAllowAPartitionHashKeyWithABatch()
        {
            var batchOptions = new BatchOptions { PartitionKey = "testKey" };
            var batch = new EventDataBatch(new MockTransportBatch(), batchOptions);
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducer(transportProducer, "dummy", new EventHubProducerOptions { PartitionId = "1" }, Mock.Of<EventHubRetryPolicy>());

            Assert.That(async () => await producer.SendAsync(batch), Throws.InvalidOperationException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducer.SendAsync"/>
        /// </summary>
        ///
        [Test]
        public async Task SendWithoutOptionsInvokesTheTransportProducer()
        {
            var events = Mock.Of<IEnumerable<EventData>>();
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducer(transportProducer, "dummy", new EventHubProducerOptions(), Mock.Of<EventHubRetryPolicy>());

            await producer.SendAsync(events);

            (var calledWithEvents, var calledWithOptions) = transportProducer.SendCalledWith;

            Assert.That(calledWithEvents, Is.SameAs(events), "The events should be the same instance.");
            Assert.That(calledWithOptions, Is.Not.Null, "A default set of options should be used.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducer.SendAsync"/>
        /// </summary>
        ///
        [Test]
        public async Task SendInvokesTheTransportProducer()
        {
            var events = Mock.Of<IEnumerable<EventData>>();
            var options = new SendOptions();
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducer(transportProducer, "dummy", new EventHubProducerOptions(), Mock.Of<EventHubRetryPolicy>());

            await producer.SendAsync(events, options);

            (var calledWithEvents, var calledWithOptions) = transportProducer.SendCalledWith;

            Assert.That(calledWithEvents, Is.SameAs(events), "The events should be the same instance.");
            Assert.That(calledWithOptions, Is.SameAs(options), "The options should be the same instance");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducer.SendAsync"/>
        /// </summary>
        ///
        [Test]
        public async Task SendInvokesTheTransportProducerWithABatch()
        {
            var batchOptions = new BatchOptions { PartitionKey = "testKey" };
            var batch = new EventDataBatch(new MockTransportBatch(), batchOptions);
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducer(transportProducer, "dummy", new EventHubProducerOptions(), Mock.Of<EventHubRetryPolicy>());

            await producer.SendAsync(batch);
            Assert.That(transportProducer.SendBatchCalledWith, Is.SameAs(batch), "The batch should be the same instance.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducer.CreateBatchAsync"/>
        /// </summary>
        ///
        [Test]
        public void CreateBatchForASpecificPartitionDoesNotAllowAPartitionHashKey()
        {
            var batchOptions = new BatchOptions { PartitionKey = "testKey" };
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducer(transportProducer, "dummy", new EventHubProducerOptions { PartitionId = "1" }, Mock.Of<EventHubRetryPolicy>());

            Assert.That(async () => await producer.CreateBatchAsync(batchOptions), Throws.InvalidOperationException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducer.CreateBatchAsync"/>
        /// </summary>
        ///
        [Test]
        public async Task CreateBatchInvokesTheTransportProducer()
        {
            var batchOptions = new BatchOptions { PartitionKey = "Hi", MaximumizeInBytes = 9999 };
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducer(transportProducer, "dummy", new EventHubProducerOptions(), Mock.Of<EventHubRetryPolicy>());

            await producer.CreateBatchAsync(batchOptions);

            Assert.That(transportProducer.CreateBatchCalledWith, Is.Not.Null, "The batch creation should have passed options.");
            Assert.That(transportProducer.CreateBatchCalledWith, Is.Not.SameAs(batchOptions), "The options should have been cloned.");
            Assert.That(transportProducer.CreateBatchCalledWith.PartitionKey, Is.EqualTo(batchOptions.PartitionKey), "The partition key should match.");
            Assert.That(transportProducer.CreateBatchCalledWith.MaximumizeInBytes, Is.EqualTo(batchOptions.MaximumizeInBytes), "The maximum size should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducer.CreateBatchAsync"/>
        /// </summary>
        ///
        [Test]
        public async Task CreateBatchDefaultsBatchOptions()
        {
            var expectedOptions = new BatchOptions();
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducer(transportProducer, "dummy", new EventHubProducerOptions(), Mock.Of<EventHubRetryPolicy>());

            await producer.CreateBatchAsync();

            Assert.That(transportProducer.CreateBatchCalledWith, Is.Not.Null, "The batch creation should have passed options.");
            Assert.That(transportProducer.CreateBatchCalledWith, Is.Not.SameAs(expectedOptions), "The options should have been cloned.");
            Assert.That(transportProducer.CreateBatchCalledWith.PartitionKey, Is.EqualTo(expectedOptions.PartitionKey), "The partition key should match.");
            Assert.That(transportProducer.CreateBatchCalledWith.MaximumizeInBytes, Is.EqualTo(expectedOptions.MaximumizeInBytes), "The maximum size should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducer.CreateBatchAsync"/>
        /// </summary>
        ///
        [Test]
        public async Task CreateBatchSetsTheSendOptionsForTheEventBatch()
        {
            var batchOptions = new BatchOptions { PartitionKey = "Hi", MaximumizeInBytes = 9999 };
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducer(transportProducer, "dummy", new EventHubProducerOptions(), Mock.Of<EventHubRetryPolicy>());
            var eventBatch = await producer.CreateBatchAsync(batchOptions);

            Assert.That(eventBatch.SendOptions, Is.SameAs(transportProducer.CreateBatchCalledWith), "The batch options should have used for the send options.");
            ;
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducer.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncClosesTheTransportProducer()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducer(transportProducer, "dummy", new EventHubProducerOptions(), Mock.Of<EventHubRetryPolicy>());

            await producer.CloseAsync();

            Assert.That(transportProducer.WasCloseCalled, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducer.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloseClosesTheTransportProducer()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducer(transportProducer, "dummy", new EventHubProducerOptions(), Mock.Of<EventHubRetryPolicy>());

            producer.Close();

            Assert.That(transportProducer.WasCloseCalled, Is.True);
        }

        /// <summary>
        ///   Allows for observation of operations performed by the producer for testing purposes.
        /// </summary>
        ///
        private class ObservableTransportProducerMock : TransportEventHubProducer
        {
            public bool WasCloseCalled = false;
            public EventHubRetryPolicy UpdateRetryPolicyCalledWith;
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

            public override void UpdateRetryPolicy(EventHubRetryPolicy newRetryPolicy)
            {
                UpdateRetryPolicyCalledWith = newRetryPolicy;
            }

            public override Task<TransportEventBatch> CreateBatchAsync(BatchOptions options,
                                                                       CancellationToken cancellationToken)
            {
                CreateBatchCalledWith = options;
                return Task.FromResult((TransportEventBatch)new MockTransportBatch());
            }

            public override Task CloseAsync(CancellationToken cancellationToken)
            {
                WasCloseCalled = true;
                return Task.CompletedTask;
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
