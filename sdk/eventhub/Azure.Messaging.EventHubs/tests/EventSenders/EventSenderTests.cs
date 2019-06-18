// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Core;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventSender" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventSenderTests
    {
        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheSender()
        {
            Assert.That(() => new EventSender(null, "dummy", new EventSenderOptions()), Throws.ArgumentNullException);
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
            Assert.That(() => new EventSender(new ObservableTransportSenderMock(), eventHubPath, new EventSenderOptions()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheOptions()
        {
            Assert.That(() => new EventSender(new ObservableTransportSenderMock(), "dummy", null), Throws.ArgumentNullException);
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
            var sender = new EventSender(new ObservableTransportSenderMock(), eventHubPath, new EventSenderOptions());
            Assert.That(sender.EventHubPath, Is.EqualTo(eventHubPath));
        }

        /// <summary>
        ///   Verifies finctionality of the <see cref="EventSender.SendAsync"/>
        /// </summary>
        ///
        [Test]
        public void SendWithoutOptionsRequiresEvents()
        {
            var transportSender = new ObservableTransportSenderMock();
            var sender = new EventSender(transportSender, "dummy", new EventSenderOptions());

            Assert.That(async () => await sender.SendAsync(null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies finctionality of the <see cref="EventSender.SendAsync"/>
        /// </summary>
        ///
        [Test]
        public void SendRequiresEvents()
        {
            var transportSender = new ObservableTransportSenderMock();
            var sender = new EventSender(transportSender, "dummy", new EventSenderOptions());

            Assert.That(async () => await sender.SendAsync(null, new EventBatchingOptions()), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies finctionality of the <see cref="EventSender.SendAsync"/>
        /// </summary>
        ///
        [Test]
        public void SendAllowsAPartitionHashKey()
        {
            var batchingOptions = new EventBatchingOptions { PartitionKey = "testKey" };
            var events = new[] { new EventData(new byte[] { 0x44, 0x66, 0x88 }) };
            var transportSender = new ObservableTransportSenderMock();
            var sender = new EventSender(transportSender, "dummy", new EventSenderOptions());

            Assert.That(async () => await sender.SendAsync(events, batchingOptions), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies finctionality of the <see cref="EventSender.SendAsync"/>
        /// </summary>
        ///
        [Test]
        public void SendForASpecificPartitionDoesNotAllowAPartitionHashKey()
        {
            var batchingOptions = new EventBatchingOptions { PartitionKey = "testKey" };
            var events = new[] { new EventData(new byte[] { 0x44, 0x66, 0x88 }) };
            var transportSender = new ObservableTransportSenderMock();
            var sender = new EventSender(transportSender, "dummy", new EventSenderOptions { PartitionId = "1" });

            Assert.That(async () => await sender.SendAsync(events, batchingOptions), Throws.InvalidOperationException);
        }

        /// <summary>
        ///   Verifies finctionality of the <see cref="EventSender.SendAsync"/>
        /// </summary>
        ///
        [Test]
        public async Task SendWithoutOptionsInvokesTheTransportSender()
        {
            var events = Mock.Of<IEnumerable<EventData>>();
            var transportSender = new ObservableTransportSenderMock();
            var sender = new EventSender(transportSender, "dummy", new EventSenderOptions());

            await sender.SendAsync(events);

            (var calledWithEvents, var calledWithOptions) = transportSender.SendCalledWithParameters;

            Assert.That(calledWithEvents, Is.SameAs(events), "The events should be the same instance.");
            Assert.That(calledWithOptions, Is.Not.Null, "A default set of options should be used.");
        }

        /// <summary>
        ///   Verifies finctionality of the <see cref="EventSender.SendAsync"/>
        /// </summary>
        ///
        [Test]
        public async Task SendInvokesTheTransportSender()
        {
            var events = Mock.Of<IEnumerable<EventData>>();
            var options = new EventBatchingOptions();
            var transportSender = new ObservableTransportSenderMock();
            var sender = new EventSender(transportSender, "dummy", new EventSenderOptions());

            await sender.SendAsync(events, options);

            (var calledWithEvents, var calledWithOptions) = transportSender.SendCalledWithParameters;

            Assert.That(calledWithEvents, Is.SameAs(events), "The events should be the same instance.");
            Assert.That(calledWithOptions, Is.SameAs(options), "The options should be the same instance");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventSender.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncClosesTheTransportSender()
        {
            var transportSender = new ObservableTransportSenderMock();
            var sender = new EventSender(transportSender, "dummy", new EventSenderOptions());

            await sender.CloseAsync();

            Assert.That(transportSender.WasCloseCalled, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventSender.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloseClosesTheTransportSender()
        {
            var transportSender = new ObservableTransportSenderMock();
            var sender = new EventSender(transportSender, "dummy", new EventSenderOptions());

            sender.Close();

            Assert.That(transportSender.WasCloseCalled, Is.True);
        }

        /// <summary>
        ///   Allows for observation of operations performed by the sender for testing purposes.
        /// </summary>
        ///
        private class ObservableTransportSenderMock : TransportEventSender
        {
            public bool WasCloseCalled = false;
            public (IEnumerable<EventData>, EventBatchingOptions) SendCalledWithParameters;

            public override Task SendAsync(IEnumerable<EventData> events,
                                           EventBatchingOptions batchOptions,
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
