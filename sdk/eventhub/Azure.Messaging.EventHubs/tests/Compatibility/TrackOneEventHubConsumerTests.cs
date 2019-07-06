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
    ///   The suite of tests for the <see cref="TrackOneEventHubConsumer" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class TrackOneEventHubConsumerTests
    {
        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheReceiverFactory()
        {
            Assert.That(() => new TrackOneEventHubConsumer(null), Throws.ArgumentNullException);
        }

        /// <summary
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverIsConstructedCorrectly()
        {
            var consumerGroup = "$TestThing";
            var partition = "123";
            var position = EventPosition.FromEnqueuedTime(DateTime.Parse("2015-10-25T12:00:00Z"));
            var priority = 8765;
            var identifier = "ThisIsAnAwesomeConsumer!";
            var mock = new ObservableReceiverMock(new ClientMock(), consumerGroup, partition, TrackOne.EventPosition.FromEnqueuedTime(position.EnqueuedTime.Value.UtcDateTime), priority, new ReceiverOptions { Identifier = identifier });
            var consumer = new TrackOneEventHubConsumer(() => mock);

            // Invoke an operation to force the consumer to be lazily instantiated.  Otherwise,
            // construction does not happen.

            await consumer.ReceiveAsync(0, TimeSpan.Zero, default);

            Assert.That(mock.ConstructedWith.ConsumerGroup, Is.EqualTo(consumerGroup), "The consumer group should match.");
            Assert.That(mock.ConstructedWith.Partition, Is.EqualTo(partition), "The partition should match.");
            Assert.That(TrackOneComparer.IsEventPositionEquivalent(mock.ConstructedWith.Position, position), Is.True, "The starting event position should match.");
            Assert.That(mock.ConstructedWith.Priority, Is.EqualTo(priority), "The ownerlevel should match.");
            Assert.That(mock.ConstructedWith.Options.Identifier, Is.EqualTo(identifier), "The consumer identifier should match.");
        }

        /// <summary
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public async Task ReceiveAsyncForwardsParameters()
        {
            var maximumEventCount = 666;
            var maximumWaitTime = TimeSpan.FromMilliseconds(17);
            var mock = new ObservableReceiverMock(new ClientMock(), "$Default", "0", TrackOne.EventPosition.FromEnd(), null, new ReceiverOptions());
            var consumer = new TrackOneEventHubConsumer(() => mock);

            await consumer.ReceiveAsync(maximumEventCount, maximumWaitTime, CancellationToken.None);

            Assert.That(mock.ReceiveInvokeWith.MaxCount, Is.EqualTo(maximumEventCount), "The maximum event count should match.");
            Assert.That(mock.ReceiveInvokeWith.WaitTime, Is.EqualTo(maximumWaitTime), "The maximum wait time should match.");
        }

        /// <summary
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public async Task ReceiveAsyncSendsAnEmptyEnumerableWhenThereAreNoEvents()
        {
            var mock = new ObservableReceiverMock(new ClientMock(), "$Default", "0", TrackOne.EventPosition.FromEnd(), null, new ReceiverOptions());
            var consumer = new TrackOneEventHubConsumer(() => mock);
            var results = await consumer.ReceiveAsync(10, default, default);

            Assert.That(results, Is.Not.Null, "There should have been an enumerable returned.");
            Assert.That(results.Any(), Is.False, "The result enumerable should have been empty.");
        }

        /// <summary
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public async Task ReceiveAsyncTransformsResults()
        {
            var mock = new ObservableReceiverMock(new ClientMock(), "$Default", "0", TrackOne.EventPosition.FromEnd(), null, new ReceiverOptions());
            var consumer = new TrackOneEventHubConsumer(() => mock);

            mock.ReceiveResult = new List<TrackOne.EventData>
            {
                new TrackOne.EventData(new byte[] { 0x33, 0x66 }),
                new TrackOne.EventData(Encoding.UTF8.GetBytes("Oh! Hello, there!"))
            };

            mock.ReceiveResult[0].SystemProperties = new TrackOne.EventData.SystemPropertiesCollection(1234, DateTime.Parse("2015-10-27T12:00:00Z"), "6", "key");
            mock.ReceiveResult[1].SystemProperties = new TrackOne.EventData.SystemPropertiesCollection(6666, DateTime.Parse("1974-12-09T20:00:00Z"), "24", null);
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
            var consumer = new TrackOneEventHubConsumer(() => mock);

            await consumer.CloseAsync(default);
            Assert.That(mock.WasCloseAsyncInvoked, Is.False);
        }

        /// <summary
        ///   Verifies functionality of the <see cref="TrackOneEventHubConsumer.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncDelegatesToTheReceiver()
        {
            var mock = new ObservableReceiverMock(new ClientMock(), "$Default", "0", TrackOne.EventPosition.FromEnd(), null, new ReceiverOptions());
            var consumer = new TrackOneEventHubConsumer(() => mock);

            // Invoke an operation to force the consumer to be lazily instantiated.  Otherwise,
            // Close does not delegate the call.

            await consumer.ReceiveAsync(0, TimeSpan.Zero, default);
            await consumer.CloseAsync(default);
            Assert.That(mock.WasCloseAsyncInvoked, Is.True);
        }

        /// <summary>
        ///   Allows for observation of operations performed by the consumer for testing purposes.
        /// </summary>
        ///
        private class ObservableReceiverMock : TrackOne.PartitionReceiver
        {
            public bool WasCloseAsyncInvoked;
            public (int MaxCount, TimeSpan WaitTime) ReceiveInvokeWith;
            public (string ConsumerGroup, string Partition, TrackOne.EventPosition Position, long? Priority, TrackOne.ReceiverOptions Options) ConstructedWith;

            public IList<TrackOne.EventData> ReceiveResult = null;

            public ObservableReceiverMock(TrackOne.EventHubClient eventHubClient,
                                          string consumerGroupName,
                                          string partitionId,
                                          TrackOne.EventPosition eventPosition,
                                          long? priority,
                                          TrackOne.ReceiverOptions options) : base(eventHubClient, consumerGroupName, partitionId, eventPosition, priority, options)
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
