// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Compatibility;
using NUnit.Framework;
using TrackOne;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="TrackOneEventSender" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class TrackOneEventSenderTests
    {
        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheSenderFactory()
        {
            Assert.That(() => new TrackOneEventSender(null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventSender.SendAsync" />
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
            var options = new EventBatchingOptions { PartitionKey = expectedHashKey };
            var mock = new ObservableSenderMock(new ClientMock(), null);
            var sender = new TrackOneEventSender(() => mock);

            await sender.SendAsync(new[] { new EventData(new byte[] { 0x43 }) }, options, CancellationToken.None);
            Assert.That(mock.SendCalledWithParameters, Is.Not.Null, "The Send request should have been delegated.");

            (_, var actualHashKey) = mock.SendCalledWithParameters;
            Assert.That(actualHashKey, Is.EqualTo(expectedHashKey), "The partition hash key should have been forwarded.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventSender.SendAsync" />
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

            var options = new EventBatchingOptions();
            var mock = new ObservableSenderMock(new ClientMock(), null);
            var sender = new TrackOneEventSender(() => mock);

            await sender.SendAsync(sourceEvents, options, CancellationToken.None);
            Assert.That(mock.SendCalledWithParameters, Is.Not.Null, "The Send request should have been delegated.");

            var sentEvents = mock.SendCalledWithParameters.Events.ToArray();
            Assert.That(sentEvents.Length, Is.EqualTo(sourceEvents.Length), "The number of events sent should match the number of source events.");

            // The events should not only be structurally equivilent, the ordering of them should be preserved.  Compare the
            // sequence in order and validate that the events in each position are equivilent.

            for (var index = 0; index < sentEvents.Length; ++index)
            {
                Assert.That(CompareEventData(sentEvents[index], sourceEvents[index]), Is.True, $"The sequence of events sent should match; they differ at index: { index }");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventSender.SendAsync" />
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
                sourceEvents[index].Properties["type"] = typeof(TrackOneEventSender).Name;
                sourceEvents[index].Properties["arbitrary"] = index;
            }

            var options = new EventBatchingOptions();
            var mock = new ObservableSenderMock(new ClientMock(), null);
            var sender = new TrackOneEventSender(() => mock);

            await sender.SendAsync(sourceEvents, options, CancellationToken.None);
            Assert.That(mock.SendCalledWithParameters, Is.Not.Null, "The Send request should have been delegated.");

            var sentEvents = mock.SendCalledWithParameters.Events.ToArray();
            Assert.That(sentEvents.Length, Is.EqualTo(sourceEvents.Length), "The number of events sent should match the number of source events.");

            // The events should not only be structurally equivilent, the ordering of them should be preserved.  Compare the
            // sequence in order and validate that the events in each position are equivilent.

            for (var index = 0; index < sentEvents.Length; ++index)
            {
                Assert.That(CompareEventData(sentEvents[index], sourceEvents[index]), Is.True, $"The sequence of events sent should match; they differ at index: { index }");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventSender.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncDoesNotDelegateIfTheSenderWasNotCreated()
        {
            var mock = new ObservableSenderMock(new ClientMock(), null);
            var sender = new TrackOneEventSender(() => mock);

            await sender.CloseAsync(default);
            Assert.That(mock.WasCloseAsyncInvoked, Is.False);
        }

        /// <summaryTrackOneEventSender
        ///   Verifies functionality of the <see cref="TrackOneEventHubClient.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncDelegatesToTheSender()
        {
            var mock = new ObservableSenderMock(new ClientMock(), null);
            var sender = new TrackOneEventSender(() => mock);

            // Invoke an operation to force the sender to be lazily instantiated.  Otherwise,
            // Close does not delegate the call.

            await sender.SendAsync(new[] { new EventData(new byte[] { 0x12, 0x22 }) }, new EventBatchingOptions(), default);
            await sender.CloseAsync(default);
            Assert.That(mock.WasCloseAsyncInvoked, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="CompareEventData" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void CompareEventDataDetectsDifferentBodies()
        {
            var trackOneEvent = new TrackOne.EventData(new byte[] { 0x22, 0x44 });
            var trackTwoEvent = new EventData(new byte[] { 0x11, 0x33 });

            Assert.That(CompareEventData(trackOneEvent, trackTwoEvent), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="CompareEventData" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void CompareEventDataDetectsDifferentProperties()
        {
            var body = new byte[] { 0x22, 0x44, 0x88 };
            var trackOneEvent = new TrackOne.EventData((byte[])body.Clone());
            var trackTwoEvent = new EventData((byte[])body.Clone());

            trackOneEvent.Properties["test"] = "trackOne";
            trackTwoEvent.Properties["test"] = "trackTwo";

            Assert.That(CompareEventData(trackOneEvent, trackTwoEvent), Is.False);
        }

        /// <summary>
        ///   Compares event data between its representations in track one and
        ///   track two to determine if the instances represent the same event.
        /// </summary>
        ///
        /// <param name="trackOneEvent">The track one event to consider.</param>
        /// <param name="trackTwoEvent">The track two event to consider.</param>
        ///
        /// <returns><c>true</c>, if the two events are structurally equivilent; otherwise, <c>false</c>.</returns>
        ///
        private bool CompareEventData(TrackOne.EventData trackOneEvent,
                                      EventData trackTwoEvent)
        {
            // If the events are the same instance, they're equal.  This should only happen
            // if both are null, since the types differ.

            if (Object.ReferenceEquals(trackOneEvent, trackTwoEvent))
            {
                return true;
            }

            // If one or the other is null, then they cannot be equal, since we know that
            // they are not both null.

            if ((trackOneEvent == null) || (trackTwoEvent == null))
            {
                return false;
            }

            // If the contents of each body is not equal, the events are not
            // equal.

            var trackOneBody = trackOneEvent.Body.ToArray();
            var trackTwoBody = trackTwoEvent.Body.ToArray();

            if (trackOneBody.Length != trackTwoBody.Length)
            {
                return false;
            }

            if (!Enumerable.SequenceEqual(trackOneBody, trackTwoBody))
            {
                return false;
            }

            // Since we know that the event bodies are equal, if the property sets are the same instance,
            // then we know that the events are equal.  This should only happen if both are null.

            if (Object.ReferenceEquals(trackOneEvent.Properties, trackTwoEvent.Properties))
            {
                return true;
            }

            // If either property is null, then the events are not equal, since we know that they are
            // not both null.

            if ((trackOneEvent.Properties == null) || (trackTwoEvent.Properties == null))
            {
                return false;
            }

            // The only meaningful comparison left is to ensure that the property sets are equivilent,
            // the outcome of this check is the final word on equality.

            if (trackOneEvent.Properties.Count != trackTwoEvent.Properties.Count)
            {
                return false;
            }

            return trackOneEvent.Properties.OrderBy(kvp => kvp.Key).SequenceEqual(trackTwoEvent.Properties.OrderBy(kvp => kvp.Key));
        }

        /// <summary>
        ///   Allows for observation of operations performed by the sender for testing purposes.
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
            protected override PartitionReceiver OnCreateReceiver(string consumerGroupName, string partitionId, TrackOne.EventPosition eventPosition, long? epoch, ReceiverOptions receiverOptions) => default;
            protected override Task<EventHubPartitionRuntimeInformation> OnGetPartitionRuntimeInformationAsync(string partitionId) => Task.FromResult(default(EventHubPartitionRuntimeInformation));
            protected override Task<EventHubRuntimeInformation> OnGetRuntimeInformationAsync() => Task.FromResult(default(EventHubRuntimeInformation));
            internal override EventDataSender OnCreateEventSender(string partitionId) => default;
        }
    }
}
