// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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
    [Parallelizable(ParallelScope.Children)]
    public class EventHubProducerTests
    {
        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheProducer()
        {
            Assert.That(() => new EventHubProducer(null, "dummy", new EventHubProducerOptions()), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheEventHubPath(string eventHubPath)
        {
            Assert.That(() => new EventHubProducer(new ObservableTransportProducerMock(), eventHubPath, new EventHubProducerOptions()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheOptions()
        {
            Assert.That(() => new EventHubProducer(new ObservableTransportProducerMock(), "dummy", null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase("123")]
        [TestCase(" ")]
        [TestCase("someValue")]
        public void ConstructorSetsTheEventHubPath(string eventHubPath)
        {
            var producer = new EventHubProducer(new ObservableTransportProducerMock(), eventHubPath, new EventHubProducerOptions());
            Assert.That(producer.EventHubPath, Is.EqualTo(eventHubPath));
        }

        /// <summary>
        ///   Verifies finctionality of the <see cref="EventHubProducer.SendAsync"/>
        /// </summary>
        ///
        [Test]
        public void SendSingleWithoutOptionsRequiresAnEvent()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducer(transportProducer, "dummy", new EventHubProducerOptions());

            Assert.That(async () => await producer.SendAsync(default(EventData)), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies finctionality of the <see cref="EventHubProducer.SendAsync"/>
        /// </summary>
        ///
        [Test]
        public void SendSingleRequiresAnEvent()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducer(transportProducer, "dummy", new EventHubProducerOptions());

            Assert.That(async () => await producer.SendAsync(default(EventData), new SendOptions()), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies finctionality of the <see cref="EventHubProducer.SendAsync"/>
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
        ///   Verifies finctionality of the <see cref="EventHubProducer.SendAsync"/>
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
        ///   Verifies finctionality of the <see cref="EventHubProducer.SendAsync"/>
        /// </summary>
        ///
        [Test]
        public void SendWithoutOptionsRequiresEvents()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducer(transportProducer, "dummy", new EventHubProducerOptions());

            Assert.That(async () => await producer.SendAsync(default(IEnumerable<EventData>)), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies finctionality of the <see cref="EventHubProducer.SendAsync"/>
        /// </summary>
        ///
        [Test]
        public void SendRequiresEvents()
        {
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducer(transportProducer, "dummy", new EventHubProducerOptions());

            Assert.That(async () => await producer.SendAsync(default(IEnumerable<EventData>), new SendOptions()), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies finctionality of the <see cref="EventHubProducer.SendAsync"/>
        /// </summary>
        ///
        [Test]
        public void SendAllowsAPartitionHashKey()
        {
            var batchingOptions = new SendOptions { PartitionKey = "testKey" };
            var events = new[] { new EventData(new byte[] { 0x44, 0x66, 0x88 }) };
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducer(transportProducer, "dummy", new EventHubProducerOptions());

            Assert.That(async () => await producer.SendAsync(events, batchingOptions), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies finctionality of the <see cref="EventHubProducer.SendAsync"/>
        /// </summary>
        ///
        [Test]
        public void SendForASpecificPartitionDoesNotAllowAPartitionHashKey()
        {
            var batchingOptions = new SendOptions { PartitionKey = "testKey" };
            var events = new[] { new EventData(new byte[] { 0x44, 0x66, 0x88 }) };
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducer(transportProducer, "dummy", new EventHubProducerOptions { PartitionId = "1" });

            Assert.That(async () => await producer.SendAsync(events, batchingOptions), Throws.InvalidOperationException);
        }

        /// <summary>
        ///   Verifies finctionality of the <see cref="EventHubProducer.SendAsync"/>
        /// </summary>
        ///
        [Test]
        public async Task SendWithoutOptionsInvokesTheTransportProducer()
        {
            var events = Mock.Of<IEnumerable<EventData>>();
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducer(transportProducer, "dummy", new EventHubProducerOptions());

            await producer.SendAsync(events);

            (var calledWithEvents, var calledWithOptions) = transportProducer.SendCalledWithParameters;

            Assert.That(calledWithEvents, Is.SameAs(events), "The events should be the same instance.");
            Assert.That(calledWithOptions, Is.Not.Null, "A default set of options should be used.");
        }

        /// <summary>
        ///   Verifies finctionality of the <see cref="EventHubProducer.SendAsync"/>
        /// </summary>
        ///
        [Test]
        public async Task SendInvokesTheTransportProducer()
        {
            var events = Mock.Of<IEnumerable<EventData>>();
            var options = new SendOptions();
            var transportProducer = new ObservableTransportProducerMock();
            var producer = new EventHubProducer(transportProducer, "dummy", new EventHubProducerOptions());

            await producer.SendAsync(events, options);

            (var calledWithEvents, var calledWithOptions) = transportProducer.SendCalledWithParameters;

            Assert.That(calledWithEvents, Is.SameAs(events), "The events should be the same instance.");
            Assert.That(calledWithOptions, Is.SameAs(options), "The options should be the same instance");
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
            var producer = new EventHubProducer(transportProducer, "dummy", new EventHubProducerOptions());

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
            var producer = new EventHubProducer(transportProducer, "dummy", new EventHubProducerOptions());

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
            public (IEnumerable<EventData>, SendOptions) SendCalledWithParameters;

            public override Task SendAsync(IEnumerable<EventData> events,
                                           SendOptions batchOptions,
                                           CancellationToken cancellationToken)
            {
                SendCalledWithParameters = (events, batchOptions);
                return Task.CompletedTask;
            }

            public override Task CloseAsync(CancellationToken cancellationToken)
            {
                WasCloseCalled = true;
                return Task.CompletedTask;
            }
        }
    }
}
