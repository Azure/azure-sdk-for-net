// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Core;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventHubConsumer" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class EventHubConsumerTests
    {
        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheConsumer()
        {
            Assert.That(() => new EventHubConsumer(null, "dummy", EventHubConsumer.DefaultConsumerGroupName, "0", EventPosition.Latest, new EventHubConsumerOptions(), Mock.Of<EventHubRetryPolicy>()), Throws.ArgumentNullException);
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
            Assert.That(() => new EventHubConsumer(new ObservableTransportConsumerMock(), eventHub, EventHubConsumer.DefaultConsumerGroupName, "0", EventPosition.Earliest, new EventHubConsumerOptions(), Mock.Of<EventHubRetryPolicy>()), Throws.InstanceOf<ArgumentException>());
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
            Assert.That(() => new EventHubConsumer(new ObservableTransportConsumerMock(), "dummy", EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.Earliest, new EventHubConsumerOptions(), Mock.Of<EventHubRetryPolicy>()), Throws.InstanceOf<ArgumentException>());
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
            Assert.That(() => new EventHubConsumer(new ObservableTransportConsumerMock(), "dummy", consumerGroup, "1332", EventPosition.Earliest, new EventHubConsumerOptions(), Mock.Of<EventHubRetryPolicy>()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheEventPosition()
        {
            Assert.That(() => new EventHubConsumer(new ObservableTransportConsumerMock(), "dummy", EventHubConsumer.DefaultConsumerGroupName, "1234", null, new EventHubConsumerOptions(), Mock.Of<EventHubRetryPolicy>()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheOptions()
        {
            Assert.That(() => new EventHubConsumer(new ObservableTransportConsumerMock(), "dummy", EventHubConsumer.DefaultConsumerGroupName, "0", EventPosition.Latest, null, Mock.Of<EventHubRetryPolicy>()), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesThDefaultRetryPoicy()
        {
            Assert.That(() => new EventHubConsumer(new ObservableTransportConsumerMock(), "dummy", EventHubConsumer.DefaultConsumerGroupName, "0", EventPosition.Latest, new EventHubConsumerOptions(), null), Throws.ArgumentNullException);
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
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.FromSequenceNumber(1), new EventHubConsumerOptions(), Mock.Of<EventHubRetryPolicy>());

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
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroupName, "0", EventPosition.FromOffset(65), options, Mock.Of<EventHubRetryPolicy>());

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
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroupName, "0", expectedPosition, new EventHubConsumerOptions(), Mock.Of<EventHubRetryPolicy>());

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
            var consumer = new EventHubConsumer(transportConsumer, "dummy", consumerGroup, "0", EventPosition.Latest, new EventHubConsumerOptions(), Mock.Of<EventHubRetryPolicy>());

            Assert.That(consumer.ConsumerGroup, Is.EqualTo(consumerGroup));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorSetsTheRetryPolicy()
        {
            var retryPolicy = Mock.Of<EventHubRetryPolicy>();
            var transportConsumer = new ObservableTransportConsumerMock();
            var consumer = new EventHubConsumer(transportConsumer, "dummy", "consumerGroup", "0", EventPosition.Latest, new EventHubConsumerOptions(), retryPolicy);

            Assert.That(consumer.RetryPolicy, Is.SameAs(retryPolicy));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumer.RetryPolicy" />
        ///   setter.
        /// </summary>
        ///
        [Test]
        public void SettingTheRetryPolicyUpdatesState()
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
            var consumerOptions = new EventHubConsumerOptions { RetryOptions = retryOptions };
            var consumer = new EventHubConsumer(new ObservableTransportConsumerMock(), "dummy", "consumerGroup", "0", EventPosition.Latest, consumerOptions, new BasicRetryPolicy(retryOptions));

            Assert.That(consumer.RetryPolicy, Is.InstanceOf<BasicRetryPolicy>(), "The retry policy should have been created from options");

            consumer.RetryPolicy = customRetry;
            Assert.That(consumer.RetryPolicy, Is.SameAs(customRetry), "The custom retry policy should have been set.");

            var activeOptions = (EventHubConsumerOptions)
                typeof(EventHubConsumer)
                    .GetProperty("Options", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(consumer);

            Assert.That(activeOptions.RetryOptions, Is.Null, "Setting a custom policy should clear the retry options.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumer.RetryPolicy" />
        ///   setter.
        /// </summary>
        ///
        [Test]
        public void SettingTheRetryPolicyUpdatesTheTransportConsumer()
        {
            var customRetry = Mock.Of<EventHubRetryPolicy>();
            var transportConsumer = new ObservableTransportConsumerMock();
            var consumerOptions = new EventHubConsumerOptions();
            var consumer = new EventHubConsumer(transportConsumer, "dummy", "consumerGroup", "0", EventPosition.Latest, consumerOptions, Mock.Of<EventHubRetryPolicy>());

            consumer.RetryPolicy = customRetry;
            Assert.That(transportConsumer.UpdateRetryPolicyCalledWith, Is.SameAs(customRetry), "The custom retry policy should have been set.");
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
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroupName, "0", EventPosition.Latest, new EventHubConsumerOptions(), Mock.Of<EventHubRetryPolicy>());
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
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroupName, "0", EventPosition.Latest, new EventHubConsumerOptions(), Mock.Of<EventHubRetryPolicy>());
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
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroupName, "0", EventPosition.Latest, options, Mock.Of<EventHubRetryPolicy>());
            var cancellation = new CancellationTokenSource();
            var expectedMessageCount = 45;

            await consumer.ReceiveAsync(expectedMessageCount, null, cancellation.Token);

            (var actualMessageCount, var actualWaitTime) = transportConsumer.ReceiveCalledWith;

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
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroupName, "0", EventPosition.Latest, new EventHubConsumerOptions(), Mock.Of<EventHubRetryPolicy>());

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
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroupName, "0", EventPosition.Latest, new EventHubConsumerOptions(), Mock.Of<EventHubRetryPolicy>());

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
            public EventHubRetryPolicy UpdateRetryPolicyCalledWith;
            public (int, TimeSpan?) ReceiveCalledWith;

            public override Task<IEnumerable<EventData>> ReceiveAsync(int maximumMessageCount,
                                                                      TimeSpan? maximumWaitTime,
                                                                      CancellationToken cancellationToken)
            {
                ReceiveCalledWith = (maximumMessageCount, maximumWaitTime);
                return Task.FromResult(default(IEnumerable<EventData>));
            }

            public override void UpdateRetryPolicy(EventHubRetryPolicy newRetryPolicy)
            {
                UpdateRetryPolicyCalledWith = newRetryPolicy;
            }

            public override Task CloseAsync(CancellationToken cancellationToken)
            {
                WasCloseCalled = true;
                return Task.CompletedTask;
            }
        }
    }
}
