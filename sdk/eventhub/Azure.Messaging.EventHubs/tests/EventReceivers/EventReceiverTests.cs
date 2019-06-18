// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Core;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventReceiver" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventReceiverTests
    {
        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheReceiver()
        {
            Assert.That(() => new EventReceiver(null, "dummy", "0", new EventReceiverOptions()), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheEventHub(string eventHub)
        {
            Assert.That(() => new EventReceiver(new ObservableTransportReceiverMock(), eventHub, "0", new EventReceiverOptions()), Throws.InstanceOf<ArgumentException>());
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
            Assert.That(() => new EventReceiver(new ObservableTransportReceiverMock(), "dummy", partition, new EventReceiverOptions()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheOptions()
        {
            Assert.That(() => new EventReceiver(new ObservableTransportReceiverMock(), "dummy", "0", null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorSetsThePartition()
        {
            var partition = "aPartition";
            var transportReceiver = new ObservableTransportReceiverMock();
            var receiver = new EventReceiver(transportReceiver, "dummy", partition, new EventReceiverOptions());

            Assert.That(receiver.PartitionId, Is.EqualTo(partition));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase(1)]
        [TestCase(32769)]
        public void ConstructorSetsThePriority(long? priority)
        {
            var options = new EventReceiverOptions
            {
                ExclusiveReceiverPriority = priority
            };

            var transportReceiver = new ObservableTransportReceiverMock();
            var receiver = new EventReceiver(transportReceiver, "dummy", "0", options);

            Assert.That(receiver.ExclusiveReceiverPriority, Is.EqualTo(priority));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorSetsTheStartingPosition()
        {
            var options = new EventReceiverOptions
            {
                BeginReceivingAt = EventPosition.FromSequenceNumber(12345, true)
            };

            var transportReceiver = new ObservableTransportReceiverMock();
            var receiver = new EventReceiver(transportReceiver, "dummy", "0", options);

            Assert.That(receiver.StartingPosition, Is.EqualTo(options.BeginReceivingAt));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorSetsTheConsumerGroup()
        {
            var options = new EventReceiverOptions
            {
                ConsumerGroup = "SomeGroup"
            };

            var transportReceiver = new ObservableTransportReceiverMock();
            var receiver = new EventReceiver(transportReceiver, "dummy", "0", options);

            Assert.That(receiver.ConsumerGroup, Is.EqualTo(options.ConsumerGroup));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventReceiver.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(-32767)]
        [TestCase(-1)]
        [TestCase(0)]
        public void ReceiveAsyncValidatesTheMaximumCount(int maximumMessageCount)
        {
            var transportReceiver = new ObservableTransportReceiverMock();
            var receiver = new EventReceiver(transportReceiver, "dummy", "0", new EventReceiverOptions());
            var cancellation = new CancellationTokenSource();
            var expectedWaitTime = TimeSpan.FromDays(1);

            Assert.That(async () => await receiver.ReceiveAsync(maximumMessageCount, expectedWaitTime, cancellation.Token), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventReceiver.CloseAsync" />
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
            var transportReceiver = new ObservableTransportReceiverMock();
            var receiver = new EventReceiver(transportReceiver, "dummy", "0", new EventReceiverOptions());
            var cancellation = new CancellationTokenSource();
            var expectedWaitTime = TimeSpan.FromMilliseconds(timeSpanDelta);

            Assert.That(async () => await receiver.ReceiveAsync(32, expectedWaitTime, cancellation.Token), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventReceiver.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ReceiveAsyncInvokesTheTransportReceiver()
        {
            var options = new EventReceiverOptions { DefaultMaximumReceiveWaitTime = TimeSpan.FromMilliseconds(8) };
            var transportReceiver = new ObservableTransportReceiverMock();
            var receiver = new EventReceiver(transportReceiver, "dummy", "0", options);
            var cancellation = new CancellationTokenSource();
            var expectedMessageCount = 45;

            await receiver.ReceiveAsync(expectedMessageCount, null, cancellation.Token);

            (var actualMessageCount, var actualWaitTime) = transportReceiver.ReceiveCalledWithParameters;

            Assert.That(actualMessageCount, Is.EqualTo(expectedMessageCount), "The message counts should match.");
            Assert.That(actualWaitTime, Is.EqualTo(options.DefaultMaximumReceiveWaitTime), "The wait time should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventReceiver.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncClosesTheTransportReceiver()
        {
            var transportReceiver = new ObservableTransportReceiverMock();
            var receiver = new EventReceiver(transportReceiver, "dummy", "0", new EventReceiverOptions());

            await receiver.CloseAsync();

            Assert.That(transportReceiver.WasCloseCalled, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventReceiver.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloseClosesTheTransportReceiver()
        {
            var transportReceiver = new ObservableTransportReceiverMock();
            var receiver = new EventReceiver(transportReceiver, "dummy", "0", new EventReceiverOptions());

            receiver.Close();

            Assert.That(transportReceiver.WasCloseCalled, Is.True);
        }

        /// <summary>
        ///   Allows for observation of operations performed by the receiver for testing purposes.
        /// </summary>
        ///
        private class ObservableTransportReceiverMock : TransportEventReceiver
        {
            public bool WasCloseCalled = false;
            public (int, TimeSpan?) ReceiveCalledWithParameters;

            public override Task<IEnumerable<EventData>> ReceiveAsync(int maximumMessageCount,
                                                                      TimeSpan? maximumWaitTime,
                                                                      CancellationToken cancellationToken)
            {
                ReceiveCalledWithParameters = (maximumMessageCount, maximumWaitTime);
                return Task.FromResult(default(IEnumerable<EventData>));
            }

            public override Task CloseAsync(CancellationToken cancellationToken)
            {
                WasCloseCalled = true;
                return Task.CompletedTask;
            }
        }
    }
}
