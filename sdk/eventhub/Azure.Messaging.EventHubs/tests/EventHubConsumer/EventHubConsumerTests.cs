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
    ///   The suite of tests for the <see cref="EventHubConsumer" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    public class EventHubConsumerTests
    {
        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheConsumer()
        {
            Assert.That(() => new EventHubConsumer(null, "dummy", EventHubConsumer.DefaultConsumerGroup, "0", EventPosition.Latest, new EventHubConsumerOptions()), Throws.ArgumentNullException);
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
            Assert.That(() => new EventHubConsumer(new ObservableTransportConsumerMock(), eventHub, EventHubConsumer.DefaultConsumerGroup, "0", EventPosition.Earliest, new EventHubConsumerOptions()), Throws.InstanceOf<ArgumentException>());
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
            Assert.That(() => new EventHubConsumer(new ObservableTransportConsumerMock(), "dummy", EventHubConsumer.DefaultConsumerGroup, partition, EventPosition.Earliest, new EventHubConsumerOptions()), Throws.InstanceOf<ArgumentException>());
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
            Assert.That(() => new EventHubConsumer(new ObservableTransportConsumerMock(), "dummy", consumerGroup, "1332", EventPosition.Earliest, new EventHubConsumerOptions()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheEventPosition()
        {
            Assert.That(() => new EventHubConsumer(new ObservableTransportConsumerMock(), "dummy", EventHubConsumer.DefaultConsumerGroup, "1234", null, new EventHubConsumerOptions()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheOptions()
        {
            Assert.That(() => new EventHubConsumer(new ObservableTransportConsumerMock(), "dummy", EventHubConsumer.DefaultConsumerGroup, "0", EventPosition.Latest, null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorSetsThePartition()
        {
            var partition = "aPartition";
            var transportConsumer = new ObservableTransportConsumerMock();
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroup, partition, EventPosition.FromSequenceNumber(1), new EventHubConsumerOptions());

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
        public void ConstructorSetsThePriority(long? priority)
        {
            var options = new EventHubConsumerOptions
            {
                OwnerLevel = priority
            };

            var transportConsumer = new ObservableTransportConsumerMock();
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroup, "0", EventPosition.FromOffset(65), options);

            Assert.That(consumer.OwnerLevel, Is.EqualTo(priority));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorSetsTheStartingPosition()
        {
            var expectedPosition = EventPosition.FromSequenceNumber(5641);
            var transportConsumer = new ObservableTransportConsumerMock();
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroup, "0", expectedPosition, new EventHubConsumerOptions());

            Assert.That(consumer.StartingPosition, Is.EqualTo(expectedPosition));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorSetsTheConsumerGroup()
        {
            var consumerGroup = "SomeGroup";
            var transportConsumer = new ObservableTransportConsumerMock();
            var consumer = new EventHubConsumer(transportConsumer, "dummy", consumerGroup, "0", EventPosition.Latest, new EventHubConsumerOptions());

            Assert.That(consumer.ConsumerGroup, Is.EqualTo(consumerGroup));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumer.CloseAsync" />
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
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroup, "0", EventPosition.Latest, new EventHubConsumerOptions());
            var cancellation = new CancellationTokenSource();
            var expectedWaitTime = TimeSpan.FromDays(1);

            Assert.That(async () => await consumer.ReceiveAsync(maximumMessageCount, expectedWaitTime, cancellation.Token), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumer.CloseAsync" />
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
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroup, "0", EventPosition.Latest, new EventHubConsumerOptions());
            var cancellation = new CancellationTokenSource();
            var expectedWaitTime = TimeSpan.FromMilliseconds(timeSpanDelta);

            Assert.That(async () => await consumer.ReceiveAsync(32, expectedWaitTime, cancellation.Token), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumer.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ReceiveAsyncInvokesTheTransportConsumer()
        {
            var options = new EventHubConsumerOptions { DefaultMaximumReceiveWaitTime = TimeSpan.FromMilliseconds(8) };
            var transportConsumer = new ObservableTransportConsumerMock();
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroup, "0", EventPosition.Latest, options);
            var cancellation = new CancellationTokenSource();
            var expectedMessageCount = 45;

            await consumer.ReceiveAsync(expectedMessageCount, null, cancellation.Token);

            (var actualMessageCount, var actualWaitTime) = transportConsumer.ReceiveCalledWithParameters;

            Assert.That(actualMessageCount, Is.EqualTo(expectedMessageCount), "The message counts should match.");
            Assert.That(actualWaitTime, Is.EqualTo(options.DefaultMaximumReceiveWaitTime), "The wait time should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumer.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncClosesTheTransportConsumer()
        {
            var transportConsumer = new ObservableTransportConsumerMock();
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroup, "0", EventPosition.Latest, new EventHubConsumerOptions());

            await consumer.CloseAsync();

            Assert.That(transportConsumer.WasCloseCalled, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumer.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloseClosesTheTransportConsumer()
        {
            var transportConsumer = new ObservableTransportConsumerMock();
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroup, "0", EventPosition.Latest, new EventHubConsumerOptions());

            consumer.Close();

            Assert.That(transportConsumer.WasCloseCalled, Is.True);
        }

        /// <summary>
        ///   Allows for observation of operations performed by the consumer for testing purposes.
        /// </summary>
        ///
        private class ObservableTransportConsumerMock : TransportEventHubConsumer
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
