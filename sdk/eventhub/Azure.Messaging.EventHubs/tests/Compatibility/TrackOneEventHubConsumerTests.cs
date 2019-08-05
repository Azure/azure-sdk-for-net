// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Compatibility;
using Moq;
using NUnit.Framework;
using TrackOne;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="TrackOneEventHubConsumer" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class TrackOneEventHubConsumerTests
    {
        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheReceiverFactory()
        {
            Assert.That(() => new TrackOneEventHubConsumer(null, Mock.Of<EventHubRetryPolicy>()), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheRetryPolicy()
        {
            Assert.That(() => new TrackOneEventHubConsumer(_ => default(TrackOne.PartitionReceiver), null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverIsConstructedCorrectly()
        {
            var consumerGroup = "$TestThing";
            var partition = "123";
            var position = EventPosition.FromEnqueuedTime(DateTimeOffset.Parse("2015-10-25T12:00:00Z"));
            var priority = 8765;
            var identifier = "ThisIsAnAwesomeConsumer!";
            var retryPolicy = Mock.Of<EventHubRetryPolicy>();
            var mock = new ObservableReceiverMock(new ClientMock(), consumerGroup, partition, TrackOne.EventPosition.FromEnqueuedTime(position.EnqueuedTime.Value.UtcDateTime), priority, new ReceiverOptions { Identifier = identifier });
            var consumer = new TrackOneEventHubConsumer(_ => mock, retryPolicy);

            // Invoke an operation to force the consumer to be lazily instantiated.  Otherwise,
            // construction does not happen.

            await consumer.ReceiveAsync(0, TimeSpan.Zero, default);

            Assert.That(mock.ConstructedWith.ConsumerGroup, Is.EqualTo(consumerGroup), "The consumer group should match.");
            Assert.That(mock.ConstructedWith.Partition, Is.EqualTo(partition), "The partition should match.");
            Assert.That(TrackOneComparer.IsEventPositionEquivalent(mock.ConstructedWith.Position, position), Is.True, "The starting event position should match.");
            Assert.That(mock.ConstructedWith.Priority, Is.EqualTo(priority), "The ownerlevel should match.");
            Assert.That(mock.ConstructedWith.Options.Identifier, Is.EqualTo(identifier), "The consumer identifier should match.");

            var consumerRetry = GetRetryPolicy(consumer);
            Assert.That(consumerRetry, Is.SameAs(retryPolicy), "The consumer retry instance should match.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public async Task ReceiveAsyncForwardsParameters()
        {
            var maximumEventCount = 666;
            var maximumWaitTime = TimeSpan.FromMilliseconds(17);
            var mock = new ObservableReceiverMock(new ClientMock(), "$Default", "0", TrackOne.EventPosition.FromEnd(), null, new ReceiverOptions());
            var consumer = new TrackOneEventHubConsumer(_ => mock, Mock.Of<EventHubRetryPolicy>());

            await consumer.ReceiveAsync(maximumEventCount, maximumWaitTime, CancellationToken.None);

            Assert.That(mock.ReceiveInvokeWith.MaxCount, Is.EqualTo(maximumEventCount), "The maximum event count should match.");
            Assert.That(mock.ReceiveInvokeWith.WaitTime, Is.EqualTo(maximumWaitTime), "The maximum wait time should match.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public async Task ReceiveAsyncSendsAnEmptyEnumerableWhenThereAreNoEvents()
        {
            var mock = new ObservableReceiverMock(new ClientMock(), "$Default", "0", TrackOne.EventPosition.FromEnd(), null, new ReceiverOptions());
            var consumer = new TrackOneEventHubConsumer(_ => mock, Mock.Of<EventHubRetryPolicy>());
            var results = await consumer.ReceiveAsync(10, default, default);

            Assert.That(results, Is.Not.Null, "There should have been an enumerable returned.");
            Assert.That(results.Any(), Is.False, "The result enumerable should have been empty.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public async Task ReceiveAsyncTransformsResults()
        {
            var mock = new ObservableReceiverMock(new ClientMock(), "$Default", "0", TrackOne.EventPosition.FromEnd(), null, new ReceiverOptions());
            var consumer = new TrackOneEventHubConsumer(_ => mock, Mock.Of<EventHubRetryPolicy>());

            mock.ReceiveResult = new List<TrackOne.EventData>
            {
                new TrackOne.EventData(new byte[] { 0x33, 0x66 }),
                new TrackOne.EventData(Encoding.UTF8.GetBytes("Oh! Hello, there!"))
            };

            mock.ReceiveResult[0].SystemProperties = new TrackOne.EventData.SystemPropertiesCollection(1234, DateTime.Parse("2015-10-27T12:00:00Z").ToUniversalTime(), "6", "key");
            mock.ReceiveResult[1].SystemProperties = new TrackOne.EventData.SystemPropertiesCollection(6666, DateTime.Parse("1974-12-09T20:00:00Z").ToUniversalTime(), "24", null);
            mock.ReceiveResult[1].Properties["test"] = "this is a test!";

            var results = await consumer.ReceiveAsync(10, default, default);
            var index = 0;

            foreach (var result in results)
            {
                Assert.That(TrackOneComparer.IsEventDataEquivalent(mock.ReceiveResult[index], result), Is.True, $"The transformed result at index { index } did not match the source result.");
                ++index;
            }

            Assert.That(index, Is.EqualTo(mock.ReceiveResult.Count), "There should have been the same number of translated results as there were source results.");

        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubConsumer.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncDoesNotDelegateIfTheReceiverWasNotCreated()
        {
            var mock = new ObservableReceiverMock(new ClientMock(), "$Default", "0", TrackOne.EventPosition.FromEnd(), null, new ReceiverOptions());
            var consumer = new TrackOneEventHubConsumer(_ => mock, Mock.Of<EventHubRetryPolicy>());

            await consumer.CloseAsync(default);
            Assert.That(mock.WasCloseAsyncInvoked, Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubConsumer.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncDelegatesToTheReceiver()
        {
            var mock = new ObservableReceiverMock(new ClientMock(), "$Default", "0", TrackOne.EventPosition.FromEnd(), null, new ReceiverOptions());
            var consumer = new TrackOneEventHubConsumer(_ => mock, Mock.Of<EventHubRetryPolicy>());

            // Invoke an operation to force the consumer to be lazily instantiated.  Otherwise,
            // Close does not delegate the call.

            await consumer.ReceiveAsync(0, TimeSpan.Zero, default);
            await consumer.CloseAsync(default);
            Assert.That(mock.WasCloseAsyncInvoked, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubConsumer.UpdateRetryPolicy" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ProducerUpdatesTheRetryPolicyWhenTheSenderIsNotCreated()
        {
            var newRetryPolicy = Mock.Of<EventHubRetryPolicy>();
            var mock = new ObservableReceiverMock(new ClientMock(), "$Default", "0", TrackOne.EventPosition.FromEnd(), null, new ReceiverOptions());
            var consumer = new TrackOneEventHubConsumer(_ => mock, newRetryPolicy);

            consumer.UpdateRetryPolicy(newRetryPolicy);

            var consumerRetry = GetRetryPolicy(consumer);
            Assert.That(consumerRetry, Is.SameAs(newRetryPolicy), "The consumer retry instance should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubConsumer.UpdateRetryPolicy" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ProduerUpdatesTheRetryPolicyWhenTheSenderIsCreated()
        {
            var newRetryPolicy = Mock.Of<EventHubRetryPolicy>();
            var mock = new ObservableReceiverMock(new ClientMock(), "$Default", "0", TrackOne.EventPosition.FromEnd(), null, new ReceiverOptions());
            var consumer = new TrackOneEventHubConsumer(_ => mock, newRetryPolicy);

            // Invoke an operation to force the consumer to be lazily instantiated.  Otherwise,
            // Close does not delegate the call.

            await consumer.ReceiveAsync(0, TimeSpan.Zero, default);
            consumer.UpdateRetryPolicy(newRetryPolicy);

            var consumerRetry = GetRetryPolicy(consumer);
            Assert.That(consumerRetry, Is.SameAs(newRetryPolicy), "The consumer retry instance should match.");
            Assert.That(mock.RetryPolicy, Is.TypeOf<TrackOneRetryPolicy>(), "The track one client retry policy should be a custom compatibility wrapper.");

            var trackOnePolicy = GetSourcePolicy((TrackOneRetryPolicy)mock.RetryPolicy);
            Assert.That(trackOnePolicy, Is.SameAs(newRetryPolicy), "The new retry policy should have been used as the source for the compatibility wrapper.");
        }

        /// <summary>
        ///   Gets the retry policy from a <see cref="TrackOneEventHubConsumer" />
        ///   by accessing its private field.
        /// </summary>
        ///
        /// <param name="consumer">The consumer to retrieve the retry policy from.</param>
        ///
        /// <returns>The retry policy</returns>
        ///
        private static EventHubRetryPolicy GetRetryPolicy(TrackOneEventHubConsumer consumer) =>
            (EventHubRetryPolicy)
                typeof(TrackOneEventHubConsumer)
                    .GetField("_retryPolicy", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(consumer);

        /// <summary>
        ///   Gets the retry policy used as the source of a <see cref="TrackOneRetryPolicy" />
        ///   by accessing its private field.
        /// </summary>
        ///
        /// <param name="policy">The policy to retrieve the source policy from.</param>
        ///
        /// <returns>The retry policy</returns>
        ///
        private static EventHubRetryPolicy GetSourcePolicy(TrackOneRetryPolicy policy) =>
            (EventHubRetryPolicy)
                typeof(TrackOneRetryPolicy)
                    .GetField("_sourcePolicy", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(policy);


        /// <summary>
        ///   Allows for observation of operations performed by the consumer for testing purposes.
        /// </summary>
        ///
        private class ObservableReceiverMock : PartitionReceiver
        {
            public bool WasCloseAsyncInvoked;
            public (int MaxCount, TimeSpan WaitTime) ReceiveInvokeWith;
            public (string ConsumerGroup, string Partition, TrackOne.EventPosition Position, long? Priority, ReceiverOptions Options) ConstructedWith;

            public IList<TrackOne.EventData> ReceiveResult = null;

            public ObservableReceiverMock(TrackOne.EventHubClient eventHubClient,
                                          string consumerGroupName,
                                          string partitionId,
                                          TrackOne.EventPosition eventPosition,
                                          long? priority,
                                          ReceiverOptions options) : base(eventHubClient, consumerGroupName, partitionId, eventPosition, priority, options)
            {
                ConstructedWith = (consumerGroupName, partitionId, eventPosition, priority, options);
            }

            protected override Task OnCloseAsync()
            {
                WasCloseAsyncInvoked = true;
                return Task.CompletedTask;
            }

            protected override Task<IList<TrackOne.EventData>> OnReceiveAsync(int maxMessageCount, TimeSpan waitTime)
            {
                ReceiveInvokeWith = (maxMessageCount, waitTime);
                return Task.FromResult(ReceiveResult);
            }

            protected override void OnSetReceiveHandler(IPartitionReceiveHandler receiveHandler, bool invokeWhenNoEvents) => throw new NotImplementedException();
        }

        /// <summary>
        ///   Allows easy creation of a non-functioning client for testing purposes.
        /// </summary>
        ///
        private class ClientMock : TrackOne.EventHubClient
        {
            public ClientMock() : base(new TrackOne.EventHubsConnectionStringBuilder(new Uri("http://my.hub.com"), "aPath", "keyName", "KEY!"))
            {
            }

            protected override Task OnCloseAsync() => Task.CompletedTask;
            protected override PartitionReceiver OnCreateReceiver(string consumerGroupName, string partitionId, TrackOne.EventPosition eventPosition, long? epoch, ReceiverOptions consumerOptions) => default;
            protected override Task<EventHubPartitionRuntimeInformation> OnGetPartitionRuntimeInformationAsync(string partitionId) => Task.FromResult(default(EventHubPartitionRuntimeInformation));
            protected override Task<EventHubRuntimeInformation> OnGetRuntimeInformationAsync() => Task.FromResult(default(EventHubRuntimeInformation));
            internal override EventDataSender OnCreateEventSender(string partitionId) => default;
        }
    }
}
