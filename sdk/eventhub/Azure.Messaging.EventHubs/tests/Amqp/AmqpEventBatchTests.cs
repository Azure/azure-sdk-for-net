// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Azure.Messaging.EventHubs.Amqp;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Producer;
using Microsoft.Azure.Amqp;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

using FramingData = Microsoft.Azure.Amqp.Framing.Data;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="AmqpEventBatch" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class AmqpEventBatchTests
    {
        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheMessageConverter()
        {
            Assert.That(() => new AmqpEventBatch(null, new CreateBatchOptions { MaximumSizeInBytes = 31 }, default), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheOptions()
        {
            var mockConverter = new InjectableMockConverter
            {
                CreateBatchFromEventsHandler = (_e, _p) => Mock.Of<AmqpMessage>()
            };

            Assert.That(() => new AmqpEventBatch(mockConverter, null, default), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheMaximumSize()
        {
            var mockConverter = new InjectableMockConverter
            {
                CreateBatchFromEventsHandler = (_e, _p) => Mock.Of<AmqpMessage>()
            };

            Assert.That(() => new AmqpEventBatch(mockConverter, new CreateBatchOptions { MaximumSizeInBytes = null }, default), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorSetsTheMaximumSize()
        {
            var maximumSize = 9943;
            var options = new CreateBatchOptions { MaximumSizeInBytes = maximumSize };

            var mockConverter = new InjectableMockConverter
            {
                CreateBatchFromMessagesHandler = (_e, _p) => Mock.Of<AmqpMessage>()
            };

            var batch = new AmqpEventBatch(mockConverter, options, default);
            Assert.That(batch.MaximumSizeInBytes, Is.EqualTo(maximumSize));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorInitializesTheSizeToABatchEnvelope()
        {
            var batchEnvelopeSize = 767;
            var mockMessage = new Mock<AmqpMessage>();
            var mockConverter = new InjectableMockConverter
            {
                CreateBatchFromMessagesHandler = (_e, _p) => mockMessage.Object
            };

            mockMessage
                .Setup(message => message.SerializedMessageSize)
                .Returns(batchEnvelopeSize);

            var batch = new AmqpEventBatch(mockConverter, new CreateBatchOptions { MaximumSizeInBytes = 27 }, default);
            Assert.That(batch.SizeInBytes, Is.EqualTo(batchEnvelopeSize));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventBatch.TryAdd" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TryAddValidatesTheEvent()
        {
            var mockConverter = new InjectableMockConverter
            {
                CreateBatchFromMessagesHandler = (_e, _p) => Mock.Of<AmqpMessage>()
            };

            var batch = new AmqpEventBatch(mockConverter, new CreateBatchOptions { MaximumSizeInBytes = 25 }, default);
            Assert.That(() => batch.TryAdd(null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventBatch.TryAdd" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TryAddValidatesNotDisposed()
        {
            var mockConverter = new InjectableMockConverter
            {
                CreateBatchFromMessagesHandler = (_e, _p) => Mock.Of<AmqpMessage>()
            };

            var batch = new AmqpEventBatch(mockConverter, new CreateBatchOptions { MaximumSizeInBytes = 25 }, default);
            batch.Dispose();

            Assert.That(() => batch.TryAdd(new EventData(new byte[0])), Throws.InstanceOf<ObjectDisposedException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventBatch.TryAdd" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TryAddDoesNotAcceptAnEventBiggerThanTheMaximumSize()
        {
            var maximumSize = 50;
            var batchEnvelopeSize = 0;
            var options = new CreateBatchOptions { MaximumSizeInBytes = maximumSize };
            var mockEnvelope = new Mock<AmqpMessage>();
            var mockEvent = new Mock<AmqpMessage>();
            var mockConverter = new InjectableMockConverter
            {
                CreateBatchFromMessagesHandler = (_e, _p) => mockEnvelope.Object,
                CreateMessageFromEventHandler = (_e, _p) => mockEvent.Object
            };

            mockEnvelope
                .Setup(message => message.SerializedMessageSize)
                .Returns(batchEnvelopeSize);

            mockEvent
                .Setup(message => message.SerializedMessageSize)
                .Returns(maximumSize);

            var batch = new AmqpEventBatch(mockConverter, options, default);

            Assert.That(batch.TryAdd(new EventData(new byte[0])), Is.False, "An event of the maximum size is too large due to the reserved overhead.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventBatch.TryAdd" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TryAddAcceptsAnEventSmallerThanTheMaximumSize()
        {
            var maximumSize = 50;
            var eventMessageSize = 40;
            var options = new CreateBatchOptions { MaximumSizeInBytes = maximumSize };
            var mockEnvelope = new Mock<AmqpMessage>();
            var mockEvent = new Mock<AmqpMessage>();
            var mockConverter = new InjectableMockConverter
            {
                CreateBatchFromMessagesHandler = (_e, _p) => mockEnvelope.Object,
                CreateMessageFromEventHandler = (_e, _p) => mockEvent.Object
            };

            mockEnvelope
                .Setup(message => message.SerializedMessageSize)
                .Returns(0);

            mockEvent
                .Setup(message => message.SerializedMessageSize)
                .Returns(eventMessageSize);

            var batch = new AmqpEventBatch(mockConverter, options, default);

            Assert.That(batch.TryAdd(new EventData(new byte[0])), Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventBatch.TryAdd" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TryAddAcceptEventsUntilTheMaximumSizeIsReached()
        {
            var currentIndex = -1;
            var maximumSize = 50;
            var options = new CreateBatchOptions { MaximumSizeInBytes = maximumSize };
            var eventMessages = new AmqpMessage[5];
            var mockEnvelope = new Mock<AmqpMessage>();
            var mockConverter = new InjectableMockConverter
            {
                CreateBatchFromMessagesHandler = (_e, _p) => mockEnvelope.Object,
                CreateMessageFromEventHandler = (_e, _p) => eventMessages[++currentIndex]
            };

            mockEnvelope
                .Setup(message => message.SerializedMessageSize)
                .Returns(0);

            // Fill the set of messages with ones that should fit, reserving the last spot
            // for one that will deterministically be rejected.

            for (var index = 0; index < eventMessages.Length; ++index)
            {
                var size = (index == eventMessages.Length - 1)
                    ? maximumSize
                    : (maximumSize / eventMessages.Length) - 8;

                var message = new Mock<AmqpMessage>();
                message.Setup(msg => msg.SerializedMessageSize).Returns(size);
                eventMessages[index] = message.Object;
            }

            var batch = new AmqpEventBatch(mockConverter, options, default);

            for (var index = 0; index < eventMessages.Length; ++index)
            {
                if (index == eventMessages.Length - 1)
                {
                    Assert.That(batch.TryAdd(new EventData(new byte[0])), Is.False, "The final addition should not fit in the available space.");
                }
                else
                {
                    Assert.That(batch.TryAdd(new EventData(new byte[0])), Is.True, $"The addition for index: { index } should fit and be accepted.");
                }
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventBatch.TryAdd" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TryAddSetsTheCount()
        {
            var currentIndex = -1;
            var options = new CreateBatchOptions { MaximumSizeInBytes = 5000 };
            var eventMessages = new AmqpMessage[5];
            var mockEnvelope = new Mock<AmqpMessage>();
            var mockConverter = new InjectableMockConverter
            {
                CreateBatchFromMessagesHandler = (_e, _p) => mockEnvelope.Object,
                CreateMessageFromEventHandler = (_e, _p) => eventMessages[++currentIndex]
            };

            mockEnvelope
                .Setup(message => message.SerializedMessageSize)
                .Returns(0);

            for (var index = 0; index < eventMessages.Length; ++index)
            {
                eventMessages[index] = AmqpMessage.Create(new FramingData { Value = new ArraySegment<byte>(new byte[] { 0x66 }) });
            }

            // Add the messages to the batch; all should be accepted.

            var batch = new AmqpEventBatch(mockConverter, options, default);

            for (var index = 0; index < eventMessages.Length; ++index)
            {
                Assert.That(batch.TryAdd(new EventData(new byte[0])), Is.True, $"The addition for index: { index } should fit and be accepted.");
            }

            Assert.That(batch.Count, Is.EqualTo(eventMessages.Length), "The count should have been set when the batch was updated.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventBatch.AsReadOnlyCollection{T}" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void AsReadOnlyCollectionValidatesTheTypeParameter()
        {
            var options = new CreateBatchOptions { MaximumSizeInBytes = 5000 };
            var mockEnvelope = new Mock<AmqpMessage>();
            var mockConverter = new InjectableMockConverter
            {
                CreateBatchFromMessagesHandler = (_e, _p) => mockEnvelope.Object
            };

            mockEnvelope
                .Setup(message => message.SerializedMessageSize)
                .Returns(0);

            var batch = new AmqpEventBatch(mockConverter, options, default);
            Assert.That(() => batch.AsReadOnlyCollection<EventData>(), Throws.InstanceOf<FormatException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventBatch.AsReadOnlyCollection{T}" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void AsReadOnlyCollectionReturnsTheEventsInMessageForm()
        {
            var currentIndex = -1;
            var maximumSize = 5000;
            var options = new CreateBatchOptions { MaximumSizeInBytes = maximumSize };
            var eventMessages = new AmqpMessage[5];
            var batchEvents = new EventData[5];
            var mockEnvelope = new Mock<AmqpMessage>();
            var mockConverter = new InjectableMockConverter
            {
                CreateBatchFromMessagesHandler = (_e, _p) => mockEnvelope.Object,
                CreateMessageFromEventHandler = (_e, _p) => eventMessages[++currentIndex]
            };

            mockEnvelope
                .Setup(message => message.SerializedMessageSize)
                .Returns(0);

            for (var index = 0; index < eventMessages.Length; ++index)
            {
                var message = new Mock<AmqpMessage>();
                message.Setup(msg => msg.SerializedMessageSize).Returns(50);
                eventMessages[index] = message.Object;
            }

            var batch = new AmqpEventBatch(mockConverter, options, default);

            for (var index = 0; index < eventMessages.Length; ++index)
            {
                batchEvents[index] = new EventData(new byte[0]);
                batch.TryAdd(batchEvents[index]);
            }

            var batchEnumerable = batch.AsReadOnlyCollection<AmqpMessage>();
            Assert.That(batchEnumerable, Is.Not.Null, "The batch enumerable should have been populated.");

            var batchEnumerableList = batchEnumerable.ToList();
            Assert.That(batchEnumerableList.Count, Is.EqualTo(batch.Count), "The wrong number of events was in the enumerable.");

            for (var index = 0; index < batchEvents.Length; ++index)
            {
                Assert.That(batchEnumerableList.Contains(eventMessages[index]), $"The event at index: { index } was not in the enumerable.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventBatch.Dispose" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void DisposeCleansUpBatchMessages()
        {
            var currentIndex = -1;
            var options = new CreateBatchOptions { MaximumSizeInBytes = 5000 };
            var eventMessages = new AmqpMessage[5];
            var mockEnvelope = new Mock<AmqpMessage>();
            var mockConverter = new InjectableMockConverter
            {
                CreateBatchFromMessagesHandler = (_e, _p) => mockEnvelope.Object,
                CreateMessageFromEventHandler = (_e, _p) => eventMessages[++currentIndex]
            };

            mockEnvelope
                .Setup(message => message.SerializedMessageSize)
                .Returns(0);

            for (var index = 0; index < eventMessages.Length; ++index)
            {
                eventMessages[index] = AmqpMessage.Create(new FramingData { Value = new ArraySegment<byte>(new byte[] { 0x66 }) });
            }

            // Add the messages to the batch; all should be accepted.

            var batch = new AmqpEventBatch(mockConverter, options, default);

            for (var index = 0; index < eventMessages.Length; ++index)
            {
                Assert.That(batch.TryAdd(new EventData(new byte[0])), Is.True, $"The addition for index: { index } should fit and be accepted.");
            }

            // Validate that the AMQP messages have not been disposed.

            for (var index = 0; index < eventMessages.Length; ++index)
            {
                Assert.That(() => eventMessages[index].ThrowIfDisposed(), Throws.Nothing, $"The message at index: { index } should not have been disposed.");
            }

            // Dispose the batch and verify that the messages held by the batch have been disposed.

            batch.Dispose();

            for (var index = 0; index < eventMessages.Length; ++index)
            {
                Assert.That(() => eventMessages[index].ThrowIfDisposed(), Throws.InstanceOf<ObjectDisposedException>(), $"The message at index: { index } should have been disposed.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventBatch.Clear" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ClearClearsTheCount()
        {
            var currentIndex = -1;
            var options = new CreateBatchOptions { MaximumSizeInBytes = 5000 };
            var eventMessages = new AmqpMessage[5];
            var mockEnvelope = new Mock<AmqpMessage>();
            var mockConverter = new InjectableMockConverter
            {
                CreateBatchFromMessagesHandler = (_e, _p) => mockEnvelope.Object,
                CreateMessageFromEventHandler = (_e, _p) => eventMessages[++currentIndex]
            };

            mockEnvelope
                .Setup(message => message.SerializedMessageSize)
                .Returns(0);

            for (var index = 0; index < eventMessages.Length; ++index)
            {
                eventMessages[index] = AmqpMessage.Create(new FramingData { Value = new ArraySegment<byte>(new byte[] { 0x66 }) });
            }

            // Add the messages to the batch; all should be accepted.

            var batch = new AmqpEventBatch(mockConverter, options, default);

            for (var index = 0; index < eventMessages.Length; ++index)
            {
                Assert.That(batch.TryAdd(new EventData(new byte[0])), Is.True, $"The addition for index: { index } should fit and be accepted.");
            }

            // Dispose the batch and verify that each message has also been disposed.

            batch.Clear();
            Assert.That(batch.Count, Is.EqualTo(0), "The count should have been cleared when the batch was disposed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventBatch.Clear" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ClearClearsTheSize()
        {
            var mockMessage = new Mock<AmqpMessage>();
            var mockConverter = new InjectableMockConverter
            {
                CreateBatchFromMessagesHandler = (_e, _p) => mockMessage.Object
            };

            mockMessage
                .Setup(message => message.SerializedMessageSize)
                .Returns(9959);

            var batch = new AmqpEventBatch(mockConverter, new CreateBatchOptions { MaximumSizeInBytes = 99 }, default);
            batch.Clear();

            Assert.That(batch.SizeInBytes, Is.EqualTo(GetReservedSize(batch)));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventBatch.Dispose" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void DisposeClearsTheCount()
        {
            var currentIndex = -1;
            var options = new CreateBatchOptions { MaximumSizeInBytes = 5000 };
            var eventMessages = new AmqpMessage[5];
            var mockEnvelope = new Mock<AmqpMessage>();
            var mockConverter = new InjectableMockConverter
            {
                CreateBatchFromMessagesHandler = (_e, _p) => mockEnvelope.Object,
                CreateMessageFromEventHandler = (_e, _p) => eventMessages[++currentIndex]
            };

            mockEnvelope
                .Setup(message => message.SerializedMessageSize)
                .Returns(0);

            for (var index = 0; index < eventMessages.Length; ++index)
            {
                eventMessages[index] = AmqpMessage.Create(new FramingData { Value = new ArraySegment<byte>(new byte[] { 0x66 }) });
            }

            // Add the messages to the batch; all should be accepted.

            var batch = new AmqpEventBatch(mockConverter, options, default);

            for (var index = 0; index < eventMessages.Length; ++index)
            {
                Assert.That(batch.TryAdd(new EventData(new byte[0])), Is.True, $"The addition for index: { index } should fit and be accepted.");
            }

            // Dispose the batch and verify that each message has also been disposed.

            batch.Dispose();
            Assert.That(batch.Count, Is.EqualTo(0), "The count should have been cleared when the batch was disposed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventBatch.Dispose" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void DisposeClearsTheSize()
        {
            var mockMessage = new Mock<AmqpMessage>();
            var mockConverter = new InjectableMockConverter
            {
                CreateBatchFromMessagesHandler = (_e, _p) => mockMessage.Object
            };

            mockMessage
                .Setup(message => message.SerializedMessageSize)
                .Returns(9959);

            var batch = new AmqpEventBatch(mockConverter, new CreateBatchOptions { MaximumSizeInBytes = 99 }, default);
            batch.Dispose();

            Assert.That(batch.SizeInBytes, Is.EqualTo(GetReservedSize(batch)));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventBatch.ApplyBatchSequencing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SequenceBatchAppliesPublishingProperties()
        {
            var expectedGroupId = 123;
            var expectedOwnerLevel = (short)6;
            var firstSequence = 0;
            var sequenceIndex = -1;
            var currentIndex = -1;
            var options = new CreateBatchOptions { MaximumSizeInBytes = 5000 };
            var eventMessages = new AmqpMessage[5];
            var mockEnvelope = new Mock<AmqpMessage>();
            var mockConverter = new InjectableMockConverter
            {
                CreateBatchFromMessagesHandler = (_e, _p) => mockEnvelope.Object,
                CreateMessageFromEventHandler = (_e, _p) => eventMessages[++currentIndex],

                ApplyPublisherPropertiesToAmqpMessageHandler = (message, sequence, group, owner) =>
                {
                    ++sequenceIndex;

                    Assert.That(sequence, Is.GreaterThan(firstSequence), $"The sequence number for index: { sequenceIndex } should be greater than the initial sequence number.");
                    Assert.That(group, Is.EqualTo(expectedGroupId), $"The group for index: { sequenceIndex } should match.");
                    Assert.That(owner, Is.EqualTo(expectedOwnerLevel), $"The owner for index: { sequenceIndex } should match.");
                }
            };

            mockEnvelope
                .Setup(message => message.SerializedMessageSize)
                .Returns(0);

            for (var index = 0; index < eventMessages.Length; ++index)
            {
                eventMessages[index] = AmqpMessage.Create(new FramingData { Value = new ArraySegment<byte>(new byte[] { 0x66 }) });
            }

            // Add the messages to the batch; all should be accepted.

            var batch = new AmqpEventBatch(mockConverter, options, default);

            for (var index = 0; index < eventMessages.Length; ++index)
            {
                Assert.That(batch.TryAdd(new EventData(new byte[0])), Is.True, $"The addition for index: { index } should fit and be accepted.");
            }

            // Sequence the batch and validate the final state.

            var lastSequence = batch.ApplyBatchSequencing(firstSequence, expectedGroupId, expectedOwnerLevel);
            Assert.That(lastSequence, Is.EqualTo(firstSequence + eventMessages.Length), "The final sequence number should indicate a 1-by-1 advancement.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventBatch.ApplyBatchSequencing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void SequenceBatchRollsOverSequenceNumbersToZero()
        {
            var options = new CreateBatchOptions { MaximumSizeInBytes = 5000 };
            var mockEnvelope = new Mock<AmqpMessage>();
            var mockConverter = new InjectableMockConverter
            {
                CreateBatchFromMessagesHandler = (_e, _p) => mockEnvelope.Object,
                CreateMessageFromEventHandler = (_e, _p) => AmqpMessage.Create(new FramingData { Value = new ArraySegment<byte>(new byte[] { 0x66 }) })
            };

            mockEnvelope
                .Setup(message => message.SerializedMessageSize)
                .Returns(0);

            // Add the messages to the batch; all should be accepted.

            var batch = new AmqpEventBatch(mockConverter, options, default);
            Assert.That(batch.TryAdd(new EventData(new byte[0])), Is.True, "The event should be accepted into the batch.");

            // Sequence the batch and validate the final state.

            var lastSequence = batch.ApplyBatchSequencing(int.MaxValue, null, null);
            Assert.That(lastSequence, Is.EqualTo(0), "The sequence number should wrap around to 0.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpEventBatch.ApplyBatchSequencing" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ResetBatchSequencingRemovesPublishingProperties()
        {
            var currentIndex = -1;
            var removeCount = 0;
            var options = new CreateBatchOptions { MaximumSizeInBytes = 5000 };
            var eventMessages = new AmqpMessage[5];
            var mockEnvelope = new Mock<AmqpMessage>();
            var mockConverter = new InjectableMockConverter
            {
                CreateBatchFromMessagesHandler = (_e, _p) => mockEnvelope.Object,
                CreateMessageFromEventHandler = (_e, _p) => eventMessages[++currentIndex],
                RemovePublishingPropertiesFromAmqpMessageHandler = (_m) => ++removeCount
            };

            mockEnvelope
                .Setup(message => message.SerializedMessageSize)
                .Returns(0);

            for (var index = 0; index < eventMessages.Length; ++index)
            {
                eventMessages[index] = AmqpMessage.Create(new FramingData { Value = new ArraySegment<byte>(new byte[] { 0x66 }) });
            }

            // Add the messages to the batch; all should be accepted.

            var batch = new AmqpEventBatch(mockConverter, options, default);

            for (var index = 0; index < eventMessages.Length; ++index)
            {
                Assert.That(batch.TryAdd(new EventData(new byte[0])), Is.True, $"The addition for index: { index } should fit and be accepted.");
            }

            // Sequence the batch and validate the final state.

            batch.ResetBatchSequencing();
            Assert.That(removeCount, Is.EqualTo(eventMessages.Length), "The publishing properties for each event should have been removed.");
        }

        /// <summary>
        ///   Reads the size reserved for AMQP message overhead in a batch using its private field.
        /// </summary>
        ///
        /// <param name="instance">The instance to consider.</param>
        ///
        /// <returns>The reserved size of the batch.</returns>
        ///
        private static long GetReservedSize(AmqpEventBatch instance) =>
            (long)
                typeof(AmqpEventBatch)
                    .GetField("_reservedOverheadBytes", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(instance);

        /// <summary>
        ///   Allows for control over AMQP message conversion for testing purposes.
        /// </summary>
        ///
        private class InjectableMockConverter : AmqpMessageConverter
        {
            public Func<EventData, string, AmqpMessage> CreateMessageFromEventHandler = (_e, _p) => null;
            public Func<IEnumerable<EventData>, string, AmqpMessage> CreateBatchFromEventsHandler = (_e, _p) => null;
            public Func<IEnumerable<AmqpMessage>, string, AmqpMessage> CreateBatchFromMessagesHandler = (_m, _p) => null;
            public Action<AmqpMessage, int?, long?, short?> ApplyPublisherPropertiesToAmqpMessageHandler = (_m, _s, _g, _o) => {};
            public Action<AmqpMessage> RemovePublishingPropertiesFromAmqpMessageHandler = _m => {};
            public override AmqpMessage CreateMessageFromEvent(EventData source, string partitionKey = null) => CreateMessageFromEventHandler(source, partitionKey);
            public override AmqpMessage CreateBatchFromEvents(IReadOnlyCollection<EventData> source, string partitionKey = null) => CreateBatchFromEventsHandler(source, partitionKey);
            public override AmqpMessage CreateBatchFromMessages(IReadOnlyCollection<AmqpMessage> source, string partitionKey = null) => CreateBatchFromMessagesHandler(source, partitionKey);
            public override void ApplyPublisherPropertiesToAmqpMessage(AmqpMessage message, int? sequenceNumber, long? groupId, short? ownerLevel) => ApplyPublisherPropertiesToAmqpMessageHandler(message, sequenceNumber, groupId, ownerLevel);
            public override void RemovePublishingPropertiesFromAmqpMessage(AmqpMessage message) => RemovePublishingPropertiesFromAmqpMessageHandler(message);
        }
    }
}
