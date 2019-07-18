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
    ///   The suite of tests for the <see cref="TrackOneEventHubProducer" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class TrackOneEventHubProducerTests
    {
        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheProducerFactory()
        {
            Assert.That(() => new TrackOneEventHubProducer(null, Mock.Of<EventHubRetryPolicy>()), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheRetryPolicy()
        {
            Assert.That(() => new TrackOneEventHubProducer(_ => default(TrackOne.EventDataSender), null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public async Task ProducerIsConstructedCorrectly()
        {
            var partition = "123";
            var retryPolicy = Mock.Of<EventHubRetryPolicy>();
            var mock = new ObservableSenderMock(new ClientMock(), partition);
            var producer = new TrackOneEventHubProducer(_ => mock, retryPolicy);

            // Invoke an operation to force the producer to be lazily instantiated.  Otherwise,
            // construction does not happen.

            await producer.SendAsync(new[] { new EventData(new byte[] { 0x12, 0x22 }) }, new SendOptions(), default);
            Assert.That(mock.ConstructedWithPartition, Is.EqualTo(partition));

            var producerRetry = GetRetryPolicy(producer);
            Assert.That(producerRetry, Is.SameAs(retryPolicy), "The producer retry instance should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("someValue")]
        [TestCase(" ")]
        public async Task SendAsyncForwardsThePartitionHashKey(string expectedHashKey)
        {
            var options = new SendOptions { PartitionKey = expectedHashKey };
            var mock = new ObservableSenderMock(new ClientMock(), null);
            var producer = new TrackOneEventHubProducer(_ => mock, Mock.Of<EventHubRetryPolicy>());

            await producer.SendAsync(new[] { new EventData(new byte[] { 0x43 }) }, options, CancellationToken.None);
            Assert.That(mock.SendCalledWithParameters, Is.Not.Null, "The Send request should have been delegated.");

            (_, var actualHashKey) = mock.SendCalledWithParameters;
            Assert.That(actualHashKey, Is.EqualTo(expectedHashKey), "The partition hash key should have been forwarded.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendAsyncTransformsSimpleEvents()
        {
            var sourceEvents = new[]
            {
                new EventData(Encoding.UTF8.GetBytes("FirstValue")),
                new EventData(Encoding.UTF8.GetBytes("Second")),
                new EventData(new byte[] { 0x11, 0x22, 0x33 })
            };

            var options = new SendOptions();
            var mock = new ObservableSenderMock(new ClientMock(), null);
            var producer = new TrackOneEventHubProducer(_ => mock, Mock.Of<EventHubRetryPolicy>());

            await producer.SendAsync(sourceEvents, options, CancellationToken.None);
            Assert.That(mock.SendCalledWithParameters, Is.Not.Null, "The Send request should have been delegated.");

            var sentEvents = mock.SendCalledWithParameters.Events.ToArray();
            Assert.That(sentEvents.Length, Is.EqualTo(sourceEvents.Length), "The number of events sent should match the number of source events.");

            // The events should not only be structurally equivalent, the ordering of them should be preserved.  Compare the
            // sequence in order and validate that the events in each position are equivalent.

            for (var index = 0; index < sentEvents.Length; ++index)
            {
                Assert.That(TrackOneComparer.IsEventDataEquivalent(sentEvents[index], sourceEvents[index]), Is.True, $"The sequence of events sent should match; they differ at index: { index }");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendAsyncTransformsComplexEvents()
        {
            var sourceEvents = new[]
            {
                new EventData(Encoding.UTF8.GetBytes("FirstValue")),
                new EventData(Encoding.UTF8.GetBytes("Second")),
                new EventData(new byte[] { 0x11, 0x22, 0x33 })
            };

            for (var index = 0; index < sourceEvents.Length; ++index)
            {
                sourceEvents[index].Properties["type"] = typeof(TrackOneEventHubProducer).Name;
                sourceEvents[index].Properties["arbitrary"] = index;
            }

            var options = new SendOptions();
            var mock = new ObservableSenderMock(new ClientMock(), null);
            var producer = new TrackOneEventHubProducer(_ => mock, Mock.Of<EventHubRetryPolicy>());

            await producer.SendAsync(sourceEvents, options, CancellationToken.None);
            Assert.That(mock.SendCalledWithParameters, Is.Not.Null, "The Send request should have been delegated.");

            var sentEvents = mock.SendCalledWithParameters.Events.ToArray();
            Assert.That(sentEvents.Length, Is.EqualTo(sourceEvents.Length), "The number of events sent should match the number of source events.");

            // The events should not only be structurally equivalent, the ordering of them should be preserved.  Compare the
            // sequence in order and validate that the events in each position are equivalent.

            for (var index = 0; index < sentEvents.Length; ++index)
            {
                Assert.That(TrackOneComparer.IsEventDataEquivalent(sentEvents[index], sourceEvents[index]), Is.True, $"The sequence of events sent should match; they differ at index: { index }");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubProducer.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncDoesNotDelegateIfTheSenderWasNotCreated()
        {
            var mock = new ObservableSenderMock(new ClientMock(), null);
            var producer = new TrackOneEventHubProducer(_ => mock, Mock.Of<EventHubRetryPolicy>());

            await producer.CloseAsync(default);
            Assert.That(mock.WasCloseAsyncInvoked, Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubProducer.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncDelegatesToTheSender()
        {
            var mock = new ObservableSenderMock(new ClientMock(), null);
            var producer = new TrackOneEventHubProducer(_ => mock, Mock.Of<EventHubRetryPolicy>());

            // Invoke an operation to force the producer to be lazily instantiated.  Otherwise,
            // Close does not delegate the call.

            await producer.SendAsync(new[] { new EventData(new byte[] { 0x12, 0x22 }) }, new SendOptions(), default);
            await producer.CloseAsync(default);
            Assert.That(mock.WasCloseAsyncInvoked, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubProducer.UpdateRetryPolicy" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ProducerUpdatesTheRetryPolicyWhenTheSenderIsNotCreated()
        {
            var newRetryPolicy = Mock.Of<EventHubRetryPolicy>();
            var mock = new ObservableSenderMock(new ClientMock(), null);
            var producer = new TrackOneEventHubProducer(_ => mock, Mock.Of<EventHubRetryPolicy>());

            producer.UpdateRetryPolicy(newRetryPolicy);

            var producerRetry = GetRetryPolicy(producer);
            Assert.That(producerRetry, Is.SameAs(newRetryPolicy), "The producer retry instance should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubProducer.UpdateRetryPolicy" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ProduerUpdatesTheRetryPolicyWhenTheSenderIsCreated()
        {
            var newRetryPolicy = Mock.Of<EventHubRetryPolicy>();
            var mock = new ObservableSenderMock(new ClientMock(), null);
            var producer = new TrackOneEventHubProducer(_ => mock, Mock.Of<EventHubRetryPolicy>());

            // Invoke an operation to force the producer to be lazily instantiated.  Otherwise,
            // Close does not delegate the call.

            await producer.SendAsync(new[] { new EventData(new byte[] { 0x12, 0x22 }) }, new SendOptions(), default);
            producer.UpdateRetryPolicy(newRetryPolicy);

            var producerRetry = GetRetryPolicy(producer);
            Assert.That(producerRetry, Is.SameAs(newRetryPolicy), "The producer retry instance should match.");
            Assert.That(mock.RetryPolicy, Is.TypeOf<TrackOneRetryPolicy>(), "The track one client retry policy should be a custom compatibility wrapper.");

            var trackOnePolicy = GetSourcePolicy((TrackOneRetryPolicy)mock.RetryPolicy);
            Assert.That(trackOnePolicy, Is.SameAs(newRetryPolicy), "The new retry policy should have been used as the source for the compatibility wrapper.");
        }

        /// <summary>
        ///   Gets the retry policy from a <see cref="TrackOneEventHubProducer" />
        ///   by accessing its private field.
        /// </summary>
        ///
        /// <param name="producer">The producer to retrieve the retry policy from.</param>
        ///
        /// <returns>The retry policy</returns>
        ///
        private static EventHubRetryPolicy GetRetryPolicy(TrackOneEventHubProducer producer) =>
            (EventHubRetryPolicy)
                typeof(TrackOneEventHubProducer)
                    .GetField("_retryPolicy", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(producer);

        /// <summary>
        ///   Gets the retry policy used as the source of a <see cref="TrackOneRetryPolicy" />
        ///   by accessing its private field.
        /// </summary>
        ///
        /// <param name="policy">The ploicy to retrieve the source policy from.</param>
        ///
        /// <returns>The retry policy</returns>
        ///
        private static EventHubRetryPolicy GetSourcePolicy(TrackOneRetryPolicy policy) =>
            (EventHubRetryPolicy)
                typeof(TrackOneRetryPolicy)
                    .GetField("_sourcePolicy", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(policy);

        /// <summary>
        ///   Allows for observation of operations performed by the producer for testing purposes.
        /// </summary>
        ///
        private class ObservableSenderMock : TrackOne.EventDataSender
        {
            public bool WasCloseAsyncInvoked;
            public string ConstructedWithPartition;
            public (IEnumerable<TrackOne.EventData> Events, string PartitionKey) SendCalledWithParameters;

            public ObservableSenderMock(TrackOne.EventHubClient eventHubClient, string partitionId) : base(eventHubClient, partitionId)
            {
                ConstructedWithPartition = partitionId;
            }

            public override Task CloseAsync()
            {
                WasCloseAsyncInvoked = true;
                return Task.CompletedTask;
            }

            protected override Task OnSendAsync(IEnumerable<TrackOne.EventData> eventDatas, string partitionKey)
            {
                SendCalledWithParameters = (eventDatas, partitionKey);
                return Task.CompletedTask;
            }
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
