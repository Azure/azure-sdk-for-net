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
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Errors;
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
        ///   Verifies functionality of the <see cref="EventHubConsumer.SubscribeToEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SubscribeWithNoWaitTimeReturnsAnEnumerable()
        {
            var transportConsumer = new ObservableTransportConsumerMock();
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroupName, "0", EventPosition.Latest, new EventHubConsumerOptions(), Mock.Of<EventHubRetryPolicy>());
            var enumerable = consumer.SubscribeToEvents();

            Assert.That(enumerable, Is.Not.Null, "An enumerable should have been returned.");
            Assert.That(enumerable, Is.InstanceOf<IAsyncEnumerable<EventData>>(), "The enumerable should be of the correct type.");

            await using (var enumerator = enumerable.GetAsyncEnumerator())
            {
                Assert.That(enumerator, Is.Not.Null, "The enumerable should be able to produce an enumerator.");
                Assert.That(enumerator, Is.InstanceOf<IAsyncEnumerator<EventData>>(), "The enumerator should be of the correct type.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumer.SubscribeToEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SubscribeWithWaitTimeReturnsAnEnumerable()
        {
            var transportConsumer = new ObservableTransportConsumerMock();
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroupName, "0", EventPosition.Latest, new EventHubConsumerOptions(), Mock.Of<EventHubRetryPolicy>());
            var enumerable = consumer.SubscribeToEvents(TimeSpan.FromSeconds(15));

            Assert.That(enumerable, Is.Not.Null, "An enumerable should have been returned.");
            Assert.That(enumerable, Is.InstanceOf<IAsyncEnumerable<EventData>>(), "The enumerable should be of the correct type.");

            await using (var enumerator = enumerable.GetAsyncEnumerator())
            {
                Assert.That(enumerator, Is.Not.Null, "The enumerable should be able to produce an enumerator.");
                Assert.That(enumerator, Is.InstanceOf<IAsyncEnumerator<EventData>>(), "The enumerator should be of the correct type.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumer.SubscribeToEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SubscribeManagesActiveChannels()
        {
            var transportConsumer = new ObservableTransportConsumerMock();
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroupName, "0", EventPosition.Latest, new EventHubConsumerOptions(), Mock.Of<EventHubRetryPolicy>());
            var channels = GetActiveChannels(consumer);

            // Create the subscriptions in the background, wrapping each request in its own task.  The
            // goal is to ensure that channel creation can handle concurrent requests.

            var subscriptions = (await Task.WhenAll(
                Enumerable.Range(0, 10)
                .Select(index => Task.Run(() => consumer.SubscribeToEvents()))
            ).ConfigureAwait(false))
                .Select(enumerable => (ChannelEnumerableSubscription<EventData>)enumerable)
                .ToList();

            try
            {
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
        ///   Verifies functionality of the <see cref="EventHubConsumer.SubscribeToEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SubscribeManagesBackgroundPublishingWithOneSubscriber()
        {
            var transportConsumer = new ObservableTransportConsumerMock();
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroupName, "0", EventPosition.Latest, new EventHubConsumerOptions(), Mock.Of<EventHubRetryPolicy>());
            var publishing = GetIsPublishingActiveFlag(consumer);

            Assert.That(publishing, Is.False, "Background publishing should not start without a subscription.");

            await using (var subscription = (ChannelEnumerableSubscription<EventData>)consumer.SubscribeToEvents())
            {
                publishing = GetIsPublishingActiveFlag(consumer);
                Assert.That(publishing, Is.True, "Background publishing should be taking place when there is a subscriber.");
            }

            publishing = GetIsPublishingActiveFlag(consumer);
            Assert.That(publishing, Is.False, "Background publishing should stop when at the last unsubscribe.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumer.SubscribeToEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SubscribeManagesBackgroundPublishingWithMultipleSubscribers()
        {
            var transportConsumer = new PublishingTransportConsumerMock();
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroupName, "0", EventPosition.Latest, new EventHubConsumerOptions(), Mock.Of<EventHubRetryPolicy>());
            var publishing = GetIsPublishingActiveFlag(consumer);

            Assert.That(publishing, Is.False, "Background publishing should not start without a subscription.");

            await using (var subscription = (ChannelEnumerableSubscription<EventData>)consumer.SubscribeToEvents())
            {
                transportConsumer.StartPublishing();

                await using (var secondSubscription = (ChannelEnumerableSubscription<EventData>)consumer.SubscribeToEvents())
                await using (var thirdSubscription = (ChannelEnumerableSubscription<EventData>)consumer.SubscribeToEvents())
                {
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
        ///   Verifies functionality of the <see cref="EventHubConsumer.SubscribeToEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SubscribePublishesEmptyEnumerableIfCancelledBeforeSubscribe()
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
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroupName, "0", EventPosition.Latest, new EventHubConsumerOptions(), Mock.Of<EventHubRetryPolicy>());
            var receivedEvents = 0;

            using var cancellation = new CancellationTokenSource();
            cancellation.Cancel();

            await foreach (var eventData in consumer.SubscribeToEvents(cancellation.Token))
            {
                if (eventData == null)
                {
                    break;
                }

                ++receivedEvents;
            }

            Assert.That(cancellation.IsCancellationRequested, Is.True, "The cancellation should have been requested.");
            Assert.That(receivedEvents, Is.EqualTo(0), "There should have been no events received.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumer.SubscribeToEvents" />
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
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroupName, "0", EventPosition.Latest, new EventHubConsumerOptions(), Mock.Of<EventHubRetryPolicy>());
            var receivedEvents = new List<EventData>();

            using var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            await foreach (var eventData in consumer.SubscribeToEvents(cancellation.Token))
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
        ///   Verifies functionality of the <see cref="EventHubConsumer.SubscribeToEvents" />
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

            var transportConsumer = new PublishingTransportConsumerMock(events);
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroupName, "0", EventPosition.Latest, new EventHubConsumerOptions(), Mock.Of<EventHubRetryPolicy>());
            var firstSubscriberEvents = new List<EventData>();
            var secondSubscriberEvents = new List<EventData>();
            var firstCompletionSource = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);
            var secondCompletionSource = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);

            using var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(30));

            // Create the subscriptions explicitly for better determinism; they should subscribe at the same time
            // to ensure they receive the same set of events.

            await using (var firstSubscriber = (ChannelEnumerableSubscription<EventData>)consumer.SubscribeToEvents(cancellation.Token))
            await using (var secondSubscriber = (ChannelEnumerableSubscription<EventData>)consumer.SubscribeToEvents(cancellation.Token))
            {
                transportConsumer.StartPublishing();

                var firstSubscriberTask = Task.Run(async () =>
                {
                    await foreach (var eventData in firstSubscriber)
                    {
                        firstSubscriberEvents.Add(eventData);

                        if (firstSubscriberEvents.Count >= events.Count)
                        {
                            break;
                        }
                    }

                    await Task.Delay(250).ConfigureAwait(false);
                    firstCompletionSource.TrySetResult(0);

                }, cancellation.Token);

                var secondSubscriberTask = Task.Run(async () =>
                {
                    await foreach (var eventData in secondSubscriber)
                    {
                        secondSubscriberEvents.Add(eventData);

                        if (secondSubscriberEvents.Count >= events.Count)
                        {
                            break;
                        }
                    }

                    await Task.Delay(250).ConfigureAwait(false);
                    secondCompletionSource.TrySetResult(0);

                }, cancellation.Token);

                await Task.WhenAll(firstSubscriberTask, secondSubscriberTask, firstCompletionSource.Task, secondCompletionSource.Task).ConfigureAwait(false);
                Assert.That(cancellation.IsCancellationRequested, Is.False, "The iteration should have completed normally.");
            }

            Assert.That(firstSubscriberEvents, Is.EquivalentTo(events), "The received events for the first subscriber should match the published events.");
            Assert.That(secondSubscriberEvents, Is.EquivalentTo(events), "The received events for the second subscriber should match the published events.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumer.SubscribeToEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SubscribePublishesEventsWithOneSubscriberAndMultipleBatches()
        {
            var events = new List<EventData>();
            var transportConsumer = new PublishingTransportConsumerMock(events, true);
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroupName, "0", EventPosition.Latest, new EventHubConsumerOptions(), Mock.Of<EventHubRetryPolicy>());
            var receivedEvents = new List<EventData>();

            events.AddRange(
                Enumerable.Range(0, (GetBackgroundPublishReceiveBatchSize(consumer) * 3))
                    .Select(index => new EventData(Encoding.UTF8.GetBytes($"Event Number { index }")))
            );

            using var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            await foreach (var eventData in consumer.SubscribeToEvents(cancellation.Token))
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
        ///   Verifies functionality of the <see cref="EventHubConsumer.SubscribeToEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SubscribePublishesEventsWithMultipleSubscribersAndMultipleBatches()
        {
            var events = new List<EventData>();
            var transportConsumer = new PublishingTransportConsumerMock(events);
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroupName, "0", EventPosition.Latest, new EventHubConsumerOptions(), Mock.Of<EventHubRetryPolicy>());
            var firstSubscriberEvents = new List<EventData>();
            var secondSubscriberEvents = new List<EventData>();
            var firstCompletionSource = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);
            var secondCompletionSource = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);

            events.AddRange(
                Enumerable.Range(0, (GetBackgroundPublishReceiveBatchSize(consumer) * 3))
                    .Select(index => new EventData(Encoding.UTF8.GetBytes($"Event Number { index }")))
            );

            using var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(30));

            // Create the subscriptions explicitly for better determinism; they should subscribe at the same time
            // to ensure they receive the same set of events.

            await using (var firstSubscriber = (ChannelEnumerableSubscription<EventData>)consumer.SubscribeToEvents(cancellation.Token))
            await using (var secondSubscriber = (ChannelEnumerableSubscription<EventData>)consumer.SubscribeToEvents(cancellation.Token))
            {
                transportConsumer.StartPublishing();

                var firstSubscriberTask = Task.Run(async () =>
                {
                    await foreach (var eventData in firstSubscriber)
                    {
                        firstSubscriberEvents.Add(eventData);

                        if (firstSubscriberEvents.Count >= events.Count)
                        {
                            break;
                        }
                    }

                    await Task.Delay(250).ConfigureAwait(false);
                    firstCompletionSource.TrySetResult(0);

                }, cancellation.Token);

                var secondSubscriberTask = Task.Run(async () =>
                {
                    await foreach (var eventData in secondSubscriber)
                    {
                        secondSubscriberEvents.Add(eventData);

                        if (secondSubscriberEvents.Count >= events.Count)
                        {
                            break;
                        }
                    }

                    await Task.Delay(250).ConfigureAwait(false);
                    secondCompletionSource.TrySetResult(0);

                }, cancellation.Token);

                await Task.WhenAll(firstSubscriberTask, secondSubscriberTask, firstCompletionSource.Task, secondCompletionSource.Task).ConfigureAwait(false);
                Assert.That(cancellation.IsCancellationRequested, Is.False, "The iteration should have completed normally.");
            }

            Assert.That(firstSubscriberEvents, Is.EquivalentTo(events), "The received events for the first subscriber should match the published events.");
            Assert.That(secondSubscriberEvents, Is.EquivalentTo(events), "The received events for the second subscriber should match the published events.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumer.SubscribeToEvents" />
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
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroupName, "0", EventPosition.Latest, new EventHubConsumerOptions(), Mock.Of<EventHubRetryPolicy>());
            var activeChannels = GetActiveChannels(consumer);
            var receivedEvents = 0;

            using var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            await foreach (var eventData in consumer.SubscribeToEvents(cancellation.Token))
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
        ///   Verifies functionality of the <see cref="EventHubConsumer.SubscribeToEvents" />
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
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroupName, "0", EventPosition.Latest, new EventHubConsumerOptions(), Mock.Of<EventHubRetryPolicy>());
            var activeChannels = GetActiveChannels(consumer);
            var firstCompletionSource = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);
            var secondCompletionSource = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);
            var firstSubscriberEvents = new List<EventData>();
            var secondSubscriberEvents = new List<EventData>();

            using var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(30));

            // Create the subscriptions explicitly for better determinism; they should subscribe at the same time
            // to ensure they receive the same set of events.

            await using (var firstSubscriber = (ChannelEnumerableSubscription<EventData>)consumer.SubscribeToEvents(waitTime, cancellation.Token))
            await using (var secondSubscriber = (ChannelEnumerableSubscription<EventData>)consumer.SubscribeToEvents(waitTime, cancellation.Token))
            {
                var firstSubscriberTask = Task.Run(async () =>
                {
                    transportConsumer.StartPublishing();

                    await foreach (var eventData in firstSubscriber)
                    {
                        firstSubscriberEvents.Add(eventData);

                        if (firstSubscriberEvents.Count >= events.Count)
                        {
                            Assert.That(activeChannels.Count, Is.AtLeast(1).And.AtMost(2), "There should be a one active channel for each subscriber.");
                            break;
                        }
                    }

                    await Task.Delay(250).ConfigureAwait(false);
                    firstCompletionSource.TrySetResult(0);

                }, cancellation.Token);

                var secondSubscriberTask = Task.Run(async () =>
                {
                    await foreach (var eventData in secondSubscriber)
                    {
                        secondSubscriberEvents.Add(eventData);

                        if (secondSubscriberEvents.Count >= events.Count)
                        {
                            Assert.That(activeChannels.Count, Is.AtLeast(1).And.AtMost(2), "There should be a one active channel for each subscriber.");
                            break;
                        }
                    }

                    await Task.Delay(250).ConfigureAwait(false);
                    secondCompletionSource.TrySetResult(0);

                }, cancellation.Token);

                await Task.WhenAll(firstSubscriberTask, secondSubscriberTask, firstCompletionSource.Task, secondCompletionSource.Task).ConfigureAwait(false);
                Assert.That(cancellation.IsCancellationRequested, Is.False, "The iteration should have completed normally.");
            }

            Assert.That(activeChannels.Count, Is.EqualTo(0), "The iterator should unsubscribe when complete.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumer.SubscribeToEvents" />
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
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroupName, "0", EventPosition.Latest, new EventHubConsumerOptions(), Mock.Of<EventHubRetryPolicy>());
            var receivedEvents = new List<EventData>();
            var consecutiveEmptyCount = 0;

            using var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            await foreach (var eventData in consumer.SubscribeToEvents(maxWaitTime, cancellation.Token))
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
        ///   Verifies functionality of the <see cref="EventHubConsumer.SubscribeToEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SubscribeExpectsTaskCanceledException()
        {
            var transportConsumer = new ReceiveCallbackTransportConsumerMock((_max, _time) => throw new TaskCanceledException());
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroupName, "0", EventPosition.Latest, new EventHubConsumerOptions(), Mock.Of<EventHubRetryPolicy>());
            var receivedEvents = 0;

            using var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            await foreach (var eventData in consumer.SubscribeToEvents(cancellation.Token))
            {
                ++receivedEvents;
                break;
            }

            Assert.That(cancellation.IsCancellationRequested, Is.False, "The iteration should have completed normally.");
            Assert.That(receivedEvents, Is.EqualTo(0), "No events should have been received.");
            Assert.That(GetIsPublishingActiveFlag(consumer), Is.False, "The consumer should no longer be publishing.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumer.SubscribeToEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(NonFatalNotRetriableExceptionTestCases))]
        public void SubscribeSurfacesNonRetriableExceptions(Exception exception)
        {
            var transportConsumer = new ReceiveCallbackTransportConsumerMock((_max, _time) => throw exception);
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroupName, "0", EventPosition.Latest, new EventHubConsumerOptions(), Mock.Of<EventHubRetryPolicy>());
            var receivedEvents = 0;

            using var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            Func<Task> invoke = async () =>
            {
                await foreach (var eventData in consumer.SubscribeToEvents(cancellation.Token))
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
        ///   Verifies functionality of the <see cref="EventHubConsumer.SubscribeToEvents" />
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
            var transportConsumer = new ReceiveCallbackTransportConsumerMock(receiveCallback);
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroupName, "0", EventPosition.Latest, new EventHubConsumerOptions(), mockRetryPolicy.Object);
            var receivedEvents = 0;

            mockRetryPolicy
                .Setup(policy => policy.CalculateRetryDelay(It.Is<Exception>(value => value == exception), It.Is<int>(value => value <= maximumRetries)))
                .Returns(TimeSpan.FromMilliseconds(5));

            using var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            Func<Task> invoke = async () =>
            {
                await foreach (var eventData in consumer.SubscribeToEvents(cancellation.Token))
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
        ///   Verifies functionality of the <see cref="EventHubConsumer.SubscribeToEvents" />
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
            var transportConsumer = new ReceiveCallbackTransportConsumerMock(receiveCallback);
            var consumer = new EventHubConsumer(transportConsumer, "dummy", EventHubConsumer.DefaultConsumerGroupName, "0", EventPosition.Latest, new EventHubConsumerOptions(), mockRetryPolicy.Object);
            var receivedEvents = 0;

            mockRetryPolicy
                .Setup(policy => policy.CalculateRetryDelay(It.IsAny<Exception>(), It.IsAny<int>()))
                .Returns(default(TimeSpan?));

            using var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            Func<Task> invoke = async () =>
            {
                await foreach (var eventData in consumer.SubscribeToEvents(cancellation.Token))
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
        ///   Retrieves the active channels for a consumer, using its private field.
        /// </summary>
        ///
        /// <param name="consumer">The consumer to retrieve the channels for.</param>
        ///
        /// <returns>The set of active channels for the consumer.</returns>
        ///
        private ConcurrentDictionary<Guid, Channel<EventData>> GetActiveChannels(EventHubConsumer consumer) =>
            (ConcurrentDictionary<Guid, Channel<EventData>>)
                typeof(EventHubConsumer)
                    .GetField("ActiveChannels", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(consumer);

        /// <summary>
        ///   Retrieves the "is publishing" flag for a consumer, using its private field.
        /// </summary>
        ///
        /// <param name="consumer">The consumer to retrieve the channels for.</param>
        ///
        /// <returns>The flag that indicates whether or not a consumer is publishing events in the background.</returns>
        ///
        private bool GetIsPublishingActiveFlag(EventHubConsumer consumer) =>
            (bool)
                typeof(EventHubConsumer)
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
        private int GetBackgroundPublishReceiveBatchSize(EventHubConsumer consumer) =>
            (int)
                typeof(EventHubConsumer)
                    .GetField("BackgroundPublishReceiveBatchSize", BindingFlags.Static | BindingFlags.NonPublic)
                    .GetValue(consumer);

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
                return Task.FromResult(Enumerable.Empty<EventData>());
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

        /// <summary>
        ///   Allows for publishing a known set of events in response to receive calls
        ///   by the consumer for testing purposes.
        /// </summary>
        ///
        private class PublishingTransportConsumerMock : TransportEventHubConsumer
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

            public override void UpdateRetryPolicy(EventHubRetryPolicy newRetryPolicy) { }
        }

        /// <summary>
        ///   Allows for invoking a callback in response to receive calls
        ///   by the consumer for testing purposes.
        /// </summary>
        ///
        private class ReceiveCallbackTransportConsumerMock : TransportEventHubConsumer
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
                var results = ReceiveCallback(maximumMessageCount, maximumWaitTime);
                return Task.FromResult(results);
            }

            public override Task CloseAsync(CancellationToken cancellationToken) => Task.CompletedTask;

            public override void UpdateRetryPolicy(EventHubRetryPolicy newRetryPolicy) { }
        }
    }
}
