// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Amqp;
using Azure.Messaging.EventHubs.Compatibility;
using Azure.Messaging.EventHubs.Core;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;
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
        ///   Verifies functionality of the <see cref="TrackOneEventHubProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendAsyncTransformsEventBatches()
        {
            var messages = new[]
            {
                AmqpMessage.Create(new Data { Value = new ArraySegment<byte>(new byte[] { 0x11 }) }),
                AmqpMessage.Create(new Data { Value = new ArraySegment<byte>(new byte[] { 0x22 }) }),
                AmqpMessage.Create(new Data { Value = new ArraySegment<byte>(new byte[] { 0x33 }) }),
            };

            var options = new BatchOptions { MaximumizeInBytes = 30 };
            var transportBatch = new TransportBatchMock { Messages = messages };
            var batch = new EventDataBatch(transportBatch, options);
            var mock = new ObservableSenderMock(new ClientMock(), null);
            var producer = new TrackOneEventHubProducer(_ => mock, Mock.Of<EventHubRetryPolicy>());

            await producer.SendAsync(batch, CancellationToken.None);
            Assert.That(mock.SendCalledWithParameters, Is.Not.Null, "The Send request should have been delegated.");

            var sentEvents = mock.SendCalledWithParameters.Events.ToArray();
            Assert.That(sentEvents.Length, Is.EqualTo(messages.Length), "The number of events sent should match the number of source events.");
            Assert.That(sentEvents.Where(evt => evt.AmqpMessage == null).Any(), Is.False, "The events should have had an AMQP message populated at transform.");

            var sentMessages = sentEvents.Select(evt => evt.AmqpMessage).ToList();

            for (var index = 0; index < messages.Length; ++index)
            {
                Assert.That(sentMessages.Contains(messages[index]), $"The message at index: { index } was not part of the set that was sent.");
            }

            foreach (var message in messages)
            {
                message.Dispose();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubProducer.SendAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task SendAsyncForwardsThePartitionHashKeyForBatches()
        {
            var messages = new[]
            {
                AmqpMessage.Create(new Data { Value = new ArraySegment<byte>(new byte[] { 0x11 }) }),
                AmqpMessage.Create(new Data { Value = new ArraySegment<byte>(new byte[] { 0x22 }) }),
                AmqpMessage.Create(new Data { Value = new ArraySegment<byte>(new byte[] { 0x33 }) }),
            };

            var expectedHashKey = "TestKEy";
            var options = new BatchOptions { MaximumizeInBytes = 30, PartitionKey = expectedHashKey };
            var transportBatch = new TransportBatchMock { Messages = messages };
            var batch = new EventDataBatch(transportBatch, options);
            var mock = new ObservableSenderMock(new ClientMock(), null);
            var producer = new TrackOneEventHubProducer(_ => mock, Mock.Of<EventHubRetryPolicy>());

            await producer.SendAsync(batch, CancellationToken.None);
            Assert.That(mock.SendCalledWithParameters, Is.Not.Null, "The Send request should have been delegated.");

            (_, var actualHashKey) = mock.SendCalledWithParameters;
            Assert.That(actualHashKey, Is.EqualTo(expectedHashKey), "The partition hash key should have been forwarded.");

            foreach (var message in messages)
            {
                message.Dispose();
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
        ///   Verifies functionality of the <see cref="TrackOneEventHubProducer.CreateBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateBatchAsyncValidatesTheOptions()
        {
            var mock = new ObservableSenderMock(new ClientMock(), null);
            var producer = new TrackOneEventHubProducer(_ => mock, Mock.Of<EventHubRetryPolicy>());

            Assert.That(async () => await producer.CreateBatchAsync(null, CancellationToken.None), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubProducer.CreateBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateBatchAsyncEnsuresLinkCreation()
        {
            var options = new BatchOptions();
            var mock = new ObservableSenderMock(new ClientMock(), null);
            var producer = new TrackOneEventHubProducer(_ => mock, Mock.Of<EventHubRetryPolicy>());

            await producer.CreateBatchAsync(options, default);
            Assert.That(mock.WasEnsureLinkInvoked, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubProducer.CreateBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateBatchAsyncDefaultsTheMaximumSizeWhenNotProvided()
        {
            var expectedMaximumSize = 512;
            var options = new BatchOptions { MaximumizeInBytes = null };
            var mock = new ObservableSenderMock(new ClientMock(), null, expectedMaximumSize);
            var producer = new TrackOneEventHubProducer(_ => mock, Mock.Of<EventHubRetryPolicy>());

            await producer.CreateBatchAsync(options, default);
            Assert.That(options.MaximumizeInBytes, Is.EqualTo(expectedMaximumSize));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubProducer.CreateBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateBatchAsyncRespectsTheMaximumSizeWhenProvided()
        {
            var expectedMaximumSize = 512;
            var options = new BatchOptions { MaximumizeInBytes = 512 };
            var mock = new ObservableSenderMock(new ClientMock(), null);
            var producer = new TrackOneEventHubProducer(_ => mock, Mock.Of<EventHubRetryPolicy>());

            await producer.CreateBatchAsync(options, default);
            Assert.That(options.MaximumizeInBytes, Is.EqualTo(expectedMaximumSize));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubProducer.CreateBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateBatchAsyncVerifiesTheMaximumSize()
        {
            var linkMaximumSize = 512;
            var options = new BatchOptions { MaximumizeInBytes = 1024 };
            var mock = new ObservableSenderMock(new ClientMock(), null, linkMaximumSize);
            var producer = new TrackOneEventHubProducer(_ => mock, Mock.Of<EventHubRetryPolicy>());

            Assert.That(async () => await producer.CreateBatchAsync(options, default), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneEventHubProducer.CreateBatchAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CreateBatchAsyncBuildsAnAmqpEventBatchWithTheOptions()
        {
            var options = new BatchOptions { MaximumizeInBytes = 512 };
            var mock = new ObservableSenderMock(new ClientMock(), null);
            var producer = new TrackOneEventHubProducer(_ => mock, Mock.Of<EventHubRetryPolicy>());
            var batch = await producer.CreateBatchAsync(options, default);

            Assert.That(batch, Is.Not.Null, "The created batch should be populated.");
            Assert.That(batch, Is.InstanceOf<AmqpEventBatch>(), $"The created batch should be an { nameof(AmqpEventBatch) }.");
            Assert.That(GetEventBatchOptions((AmqpEventBatch)batch), Is.SameAs(options), "the provided options should have been used.");
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
        ///   Gets set of batch options that a <see cref="AmqpEventBatch" /> is using
        ///   by accessing its private field.
        /// </summary>
        ///
        /// <param name="batch">The batch to retrieve the source policy from.</param>
        ///
        /// <returns>The batch options</returns>
        ///
        private static BatchOptions GetEventBatchOptions(AmqpEventBatch batch) =>
            (BatchOptions)
                typeof(AmqpEventBatch)
                    .GetProperty("Options", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(batch);

        /// <summary>
        ///   Allows for the transport event Batch created the client to be injected for testing purposes.
        /// </summary>
        ///
        private class TransportBatchMock : TransportEventBatch
        {
            public bool DisposeInvoked = false;
            public Type AsEnumerableCalledWith = null;
            public EventData TryAddCalledWith = null;
            public IEnumerable<AmqpMessage> Messages = null;

            public override long MaximumSizeInBytes { get; } = 200;
            public override long SizeInBytes { get; } = 100;
            public override int Count { get; } = 300;

            public override void Dispose()
            {
                DisposeInvoked = true;
            }

            public override bool TryAdd(EventData eventData)
            {
                TryAddCalledWith = eventData;
                return true;
            }

            public override IEnumerable<T> AsEnumerable<T>()
            {
                AsEnumerableCalledWith = typeof(T);
                return (IEnumerable<T>)Messages;
            }
        }

        /// <summary>
        ///   Allows for observation of operations performed by the producer for testing purposes.
        /// </summary>
        ///
        private class ObservableSenderMock : TrackOne.EventDataSender
        {
            public bool WasCloseAsyncInvoked;
            public bool WasEnsureLinkInvoked;
            public string ConstructedWithPartition;
            public (IEnumerable<TrackOne.EventData> Events, string PartitionKey) SendCalledWithParameters;

            private long maxMessageOverride;

            public ObservableSenderMock(TrackOne.EventHubClient eventHubClient, string partitionId, long maximumMessageSize = Int32.MaxValue) : base(eventHubClient, partitionId)
            {
                ConstructedWithPartition = partitionId;
                maxMessageOverride = maximumMessageSize;
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

            internal override ValueTask EnsureLinkAsync()
            {
                WasEnsureLinkInvoked = true;
                this.MaxMessageSize = maxMessageOverride;
                return new ValueTask();
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
