// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Azure.Messaging.EventHubs.Amqp;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;
using Azure.Messaging.EventHubs.Producer;
using Microsoft.Azure.Amqp;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

using FramingData = Microsoft.Azure.Amqp.Framing.Data;

namespace Azure.Messaging.EventHubs.Tests
{
   /// <summary>
        ///   The suite of tests for the <see cref="IdempotentAmqpEventBatch" />
        ///   class.
        /// </summary>
        ///
    [TestFixture]
    public class IdempotentAmqpEventBatchTests
    {
        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheMessageConverter()
        {
            Assert.That(() => new IdempotentAmqpEventBatch(null, new CreateBatchOptions { MaximumSizeInBytes = 31 }, default), Throws.ArgumentNullException);
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

            Assert.That(() => new IdempotentAmqpEventBatch(mockConverter, null, default), Throws.ArgumentNullException);
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

            Assert.That(() => new IdempotentAmqpEventBatch(mockConverter, new CreateBatchOptions { MaximumSizeInBytes = null }, default), Throws.ArgumentNullException);
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
            var mockEnvelope = new Mock<AmqpMessage>();

            var mockConverter = new InjectableMockConverter
            {
                CreateBatchFromMessagesHandler = (_e, _p) => mockEnvelope.Object,
                CreateMessageFromEventHandler = (_e, _p) => AmqpMessage.Create(new FramingData { Value = new ArraySegment<byte>(new byte[] { 0x66 }) })
            };

            mockEnvelope
                .Setup(message => message.SerializedMessageSize)
                .Returns(0);

            var batch = new IdempotentAmqpEventBatch(mockConverter, options, default);
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
            var mockEnvelope = new Mock<AmqpMessage>();

            var mockConverter = new InjectableMockConverter
            {
                CreateBatchFromMessagesHandler = (_e, _p) => mockEnvelope.Object,
                CreateMessageFromEventHandler = (_e, _p) => AmqpMessage.Create(new FramingData { Value = new ArraySegment<byte>(new byte[] { 0x66 }) })
            };

            mockEnvelope
                .Setup(message => message.SerializedMessageSize)
                .Returns(batchEnvelopeSize);

            var batch = new IdempotentAmqpEventBatch(mockConverter, new CreateBatchOptions { MaximumSizeInBytes = 27 }, default);
            Assert.That(batch.SizeInBytes, Is.EqualTo(batchEnvelopeSize));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="IdempotentAmqpEventBatch.TryAdd" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TryAddValidatesTheEvent()
        {
            var mockEnvelope = new Mock<AmqpMessage>();

            var mockConverter = new InjectableMockConverter
            {
                CreateBatchFromMessagesHandler = (_e, _p) => mockEnvelope.Object,
                CreateMessageFromEventHandler = (_e, _p) => AmqpMessage.Create(new FramingData { Value = new ArraySegment<byte>(new byte[] { 0x66 }) })
            };

            mockEnvelope
                .Setup(message => message.SerializedMessageSize)
                .Returns(0);

            var batch = new IdempotentAmqpEventBatch(mockConverter, new CreateBatchOptions { MaximumSizeInBytes = 25 }, default);
            Assert.That(() => batch.TryAdd(null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="IdempotentAmqpEventBatch.TryAdd" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TryAddValidatesNotDisposed()
        {
            var mockEnvelope = new Mock<AmqpMessage>();

            var mockConverter = new InjectableMockConverter
            {
                CreateBatchFromMessagesHandler = (_e, _p) => mockEnvelope.Object,
                CreateMessageFromEventHandler = (_e, _p) => AmqpMessage.Create(new FramingData { Value = new ArraySegment<byte>(new byte[] { 0x66 }) })
            };

            mockEnvelope
                .Setup(message => message.SerializedMessageSize)
                .Returns(0);

            var batch = new IdempotentAmqpEventBatch(mockConverter, new CreateBatchOptions { MaximumSizeInBytes = 25 }, default);
            batch.Dispose();

            Assert.That(() => batch.TryAdd(new EventData(new byte[0])), Throws.InstanceOf<ObjectDisposedException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="IdempotentAmqpEventBatch.TryAdd" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(TransportProducerFeatures.None)]
        [TestCase(TransportProducerFeatures.IdempotentPublishing)]
        public void TryAddMeasuresIdempotentProperties(byte activeFeatures)
        {
            var maximumSize = 50;
            var batchEnvelopeSize = 0;
            var capturedSequence = default(int?);
            var capturedGroupId = default(long?);
            var capturedOwnerLevel = default(short?);
            var options = new CreateBatchOptions { MaximumSizeInBytes = maximumSize };
            var mockEnvelope = new Mock<AmqpMessage>();
            var mockEvent = new Mock<AmqpMessage>();

            var mockConverter = new InjectableMockConverter
            {
                CreateBatchFromMessagesHandler = (_e, _p) => mockEnvelope.Object,

                CreateMessageFromEventHandler = (_e, _p) =>
                {
                    capturedSequence = _e.PendingPublishSequenceNumber;
                    capturedGroupId = _e.PendingProducerGroupId;
                    capturedOwnerLevel = _e.PendingProducerOwnerLevel;
                    return mockEvent.Object;
                }
            };

            mockEnvelope
                .Setup(message => message.SerializedMessageSize)
                .Returns(batchEnvelopeSize);

            mockEvent
                .Setup(message => message.SerializedMessageSize)
                .Returns(maximumSize);

            var batch = new IdempotentAmqpEventBatch(mockConverter, options, (TransportProducerFeatures)activeFeatures);
            batch.TryAdd(EventGenerator.CreateEvents(1).Single());

            Assert.That(capturedSequence, Is.Not.Null, "The sequence should not be null.");
            Assert.That(capturedGroupId, Is.Not.Null, "The group identifier should not be null.");
            Assert.That(capturedOwnerLevel, Is.Not.Null, "The owner level should not be null.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="IdempotentAmqpEventBatch.TryAdd" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TryAddResetsPublishingState()
        {
            var maximumSize = 50;
            var batchEnvelopeSize = 0;
            var capturedEvent = default(EventData);
            var options = new CreateBatchOptions { MaximumSizeInBytes = maximumSize };
            var mockEnvelope = new Mock<AmqpMessage>();
            var mockEvent = new Mock<AmqpMessage>();

            var mockConverter = new InjectableMockConverter
            {
                CreateBatchFromMessagesHandler = (_e, _p) => mockEnvelope.Object,

                CreateMessageFromEventHandler = (_e, _p) =>
                {
                    capturedEvent = _e;
                    return mockEvent.Object;
                }
            };

            mockEnvelope
                .Setup(message => message.SerializedMessageSize)
                .Returns(batchEnvelopeSize);

            mockEvent
                .Setup(message => message.SerializedMessageSize)
                .Returns(maximumSize);

            var batch = new IdempotentAmqpEventBatch(mockConverter, options, TransportProducerFeatures.IdempotentPublishing);
            batch.TryAdd(EventGenerator.CreateEvents(1).Single());

            Assert.That(capturedEvent.PublishedSequenceNumber, Is.Null, "The final sequence should not have been set.");
            Assert.That(capturedEvent.PendingPublishSequenceNumber, Is.Null, "The pending sequence was not cleared.");
            Assert.That(capturedEvent.PendingProducerGroupId, Is.Null, "The group identifier was not cleared.");
            Assert.That(capturedEvent.PendingProducerOwnerLevel, Is.Null, "The owner level was not cleared.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="IdempotentAmqpEventBatch.TryAdd" />
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

            var batch = new IdempotentAmqpEventBatch(mockConverter, options, default);

            Assert.That(batch.TryAdd(new EventData(new byte[0])), Is.False, "An event of the maximum size is too large due to the reserved overhead.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="IdempotentAmqpEventBatch.TryAdd" />
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

            var batch = new IdempotentAmqpEventBatch(mockConverter, options, default);

            Assert.That(batch.TryAdd(new EventData(new byte[0])), Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="IdempotentAmqpEventBatch.TryAdd" />
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

            var batch = new IdempotentAmqpEventBatch(mockConverter, options, default);

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
        ///   Verifies functionality of the <see cref="IdempotentAmqpEventBatch.TryAdd" />
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

            var batch = new IdempotentAmqpEventBatch(mockConverter, options, default);

            for (var index = 0; index < eventMessages.Length; ++index)
            {
                Assert.That(batch.TryAdd(new EventData(new byte[0])), Is.True, $"The addition for index: { index } should fit and be accepted.");
            }

            Assert.That(batch.Count, Is.EqualTo(eventMessages.Length), "The count should have been set when the batch was updated.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="IdempotentAmqpEventBatch.TryAdd" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void TryAddClonesTheEvent()
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

            var batch = new IdempotentAmqpEventBatch(mockConverter, options, default);
            var eventData = new EventData(new byte[] { 0x21 });

            Assert.That(batch.TryAdd(eventData), Is.True, "The event should have been accepted.");
            Assert.That(batch.Count, Is.EqualTo(1), "The batch should contain only the single event.");

            var batchEvent = batch.AsReadOnlyCollection<EventData>().Single();

            Assert.That(batchEvent.IsEquivalentTo(eventData), Is.True, "The event data should have been passed with delegation.");
            Assert.That(batchEvent, Is.Not.SameAs(eventData), "The event data should have been cloned.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="IdempotentAmqpEventBatch.AsReadOnlyCollection{T}" />
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

            var batch = new IdempotentAmqpEventBatch(mockConverter, options, default);
            Assert.That(() => batch.AsReadOnlyCollection<object>(), Throws.InstanceOf<FormatException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="IdempotentAmqpEventBatch.AsReadOnlyCollection{T}" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void AsReadOnlyCollectionReturnsTheEvents()
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

            var batch = new IdempotentAmqpEventBatch(mockConverter, options, default);

            for (var index = 0; index < eventMessages.Length; ++index)
            {
                batchEvents[index] = new EventData(new byte[0]) { MessageId = index.ToString() };
                batch.TryAdd(batchEvents[index]);
            }

            var batchCollection = batch.AsReadOnlyCollection<EventData>();

            Assert.That(batchCollection, Is.Not.Null, "The batch collection should have been populated.");
            Assert.That(batchCollection.Count, Is.EqualTo(batch.Count), "The wrong number of events was in the collection.");

            foreach (var batchEvent in batchEvents)
            {
                var collectionEvent = batchCollection.FirstOrDefault(evt => evt.MessageId == batchEvent.MessageId);
                Assert.That(collectionEvent, Is.Not.Null, $"Event: { batchEvent.MessageId } should have been returned in the collection.");

                // The source event has not been instrumented; the event accepted into the batch has been.  Reset
                // the collection event for comparison.

                EventDataInstrumentation.ResetEvent(collectionEvent);
                Assert.That(collectionEvent.IsEquivalentTo(batchEvent), $"Event: { batchEvent.MessageId } was did not contain the expected data.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="IdempotentAmqpEventBatch.AsReadOnlyCollection{T}" />
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

            var batch = new IdempotentAmqpEventBatch(mockConverter, options, default);

            for (var index = 0; index < eventMessages.Length; ++index)
            {
                batchEvents[index] = new EventData(new byte[0]);
                batch.TryAdd(batchEvents[index]);
            }

            // Reset the current index for the messages; conversion will be attempted again
            // for enumeration and the same set of AMQP messages should be produced as when
            // TryAdd performed measurement.

            currentIndex = -1;

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
        ///   Verifies functionality of the <see cref="IdempotentAmqpEventBatch.AsReadOnlyCollection{T}" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void AsReadOnlyCollectionCleansUpPreviouslyReturnedMessages()
        {
            var index = 0;
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

            var batch = new IdempotentAmqpEventBatch(mockConverter, options, default);

            for (index = 0; index < 5; ++index)
            {
                Assert.That(batch.TryAdd(new EventData(new byte[0])), Is.True, $"The addition for index: { index } should fit and be accepted.");
            }

            // Request the AMQP messages for the batch and validate they have not been disposed.

            var eventMessages = batch.AsReadOnlyCollection<AmqpMessage>();
            index = 0;

            foreach (var message in eventMessages)
            {
                Assert.That(() => message.ThrowIfDisposed(), Throws.Nothing, $"The message at index: { index } should not have been disposed.");
                ++index;
            }

            // Request a new set of messages and verify that the previously returned messages have been disposed.

            var secondMessages = batch.AsReadOnlyCollection<AmqpMessage>();
            index = 0;

            foreach (var message in eventMessages)
            {
                Assert.That(() => message.ThrowIfDisposed(), Throws.InstanceOf<ObjectDisposedException>(), $"The message at index: { index } should have been disposed.");
                ++index;
            }

            // Clean up the second enumerable return.

            foreach (var message in secondMessages)
            {
                message.Dispose();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="IdempotentAmqpEventBatch.AsReadOnlyCollection{T}" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void AsReadOnlyCollectionReflectsEventDataUpdates()
        {
            var options = new CreateBatchOptions { MaximumSizeInBytes = 5000 };

            // Add the messages to the batch; all should be accepted.

            var batch = new IdempotentAmqpEventBatch(new AmqpMessageConverter(), options, default);

            for (var index = 0; index < 5; ++index)
            {
                Assert.That(batch.TryAdd(new EventData(new byte[0])), Is.True, $"The addition for index: { index } should fit and be accepted.");
            }

            // Request the AMQP messages for the batch then manipulate the underlying events.

            var eventMessages = batch.AsReadOnlyCollection<AmqpMessage>().ToList();

            foreach (var eventData in batch.AsReadOnlyCollection<EventData>())
            {
                eventData.PendingPublishSequenceNumber = int.MaxValue;
                eventData.PendingProducerOwnerLevel = short.MaxValue;
                eventData.PendingProducerGroupId = short.MaxValue;

                eventData.Properties.Add("Test", new string('X', 800));
            }

            // Request a new set of messages and verify that the size of each message has increased.

            var secondMessages = batch.AsReadOnlyCollection<AmqpMessage>().ToList();
            Assert.That(eventMessages.Count, Is.EqualTo(secondMessages.Count), "The number of AMQP messages in each set should have the same count.");

            for (var index = 0; index < eventMessages.Count; ++index)
            {
                Assert.That(secondMessages[index].SerializedMessageSize, Is.GreaterThan(eventMessages[index].SerializedMessageSize), $"The message for index: { index } should be larger than before the events were modified.");
            }

            // Clean up the messages

            foreach (var message in eventMessages)
            {
                message.Dispose();
            }

            foreach (var message in secondMessages)
            {
                message.Dispose();
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="IdempotentAmqpEventBatch.TryAdd" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void MessagesAreDisposedAfterMeasuring()
        {
            var currentIndex = -1;
            var options = new CreateBatchOptions { MaximumSizeInBytes = 5000 };
            var eventMessages = new AmqpMessage[5];
            var mockEnvelope = new Mock<AmqpMessage>();
            var mockConverter = new InjectableMockConverter
            {
                CreateBatchFromMessagesHandler = (_e, _p) => mockEnvelope.Object,
                CreateBatchFromEventsHandler = (_e, _p) => mockEnvelope.Object,
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

            var batch = new IdempotentAmqpEventBatch(mockConverter, options, default);

            for (var index = 0; index < eventMessages.Length; ++index)
            {
                Assert.That(batch.TryAdd(new EventData(new byte[0])), Is.True, $"The addition for index: { index } should fit and be accepted.");
            }

            // Verify that each message returned for measuring was disposed.

            for (var index = 0; index < eventMessages.Length; ++index)
            {
                Assert.That(() => eventMessages[index].ThrowIfDisposed(), Throws.InstanceOf<ObjectDisposedException>(), $"The message at index: { index } should have been disposed.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="IdempotentAmqpEventBatch.Clear" />
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

            var batch = new IdempotentAmqpEventBatch(mockConverter, options, default);

            for (var index = 0; index < eventMessages.Length; ++index)
            {
                Assert.That(batch.TryAdd(new EventData(new byte[0])), Is.True, $"The addition for index: { index } should fit and be accepted.");
            }

            // Dispose the batch and verify that each message has also been disposed.

            batch.Clear();
            Assert.That(batch.Count, Is.EqualTo(0), "The count should have been cleared when the batch was disposed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="IdempotentAmqpEventBatch.Clear" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ClearClearsTheSize()
        {
            var mockMessage = new Mock<AmqpMessage>();
            var mockConverter = new InjectableMockConverter
            {
                CreateBatchFromMessagesHandler = (_e, _p) => mockMessage.Object,
                CreateMessageFromEventHandler = (_e, _p) => AmqpMessage.Create(new FramingData { Value = new ArraySegment<byte>(new byte[] { 0x66 }) })
            };

            mockMessage
                .Setup(message => message.SerializedMessageSize)
                .Returns(9959);

            var batch = new IdempotentAmqpEventBatch(mockConverter, new CreateBatchOptions { MaximumSizeInBytes = 99 }, default);
            batch.Clear();

            Assert.That(batch.SizeInBytes, Is.EqualTo(GetReservedSize(batch)));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="IdempotentAmqpEventBatch.Dispose" />
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

            var batch = new IdempotentAmqpEventBatch(mockConverter, options, default);

            for (var index = 0; index < eventMessages.Length; ++index)
            {
                Assert.That(batch.TryAdd(new EventData(new byte[0])), Is.True, $"The addition for index: { index } should fit and be accepted.");
            }

            // Dispose the batch and verify that each message has also been disposed.

            batch.Dispose();
            Assert.That(batch.Count, Is.EqualTo(0), "The count should have been cleared when the batch was disposed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="IdempotentAmqpEventBatch.Dispose" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void DisposeClearsTheSize()
        {
            var mockMessage = new Mock<AmqpMessage>();
            var mockConverter = new InjectableMockConverter
            {
                CreateBatchFromMessagesHandler = (_e, _p) => mockMessage.Object,
                CreateMessageFromEventHandler = (_e, _p) => AmqpMessage.Create(new FramingData { Value = new ArraySegment<byte>(new byte[] { 0x66 }) })
            };

            mockMessage
                .Setup(message => message.SerializedMessageSize)
                .Returns(9959);

            var batch = new IdempotentAmqpEventBatch(mockConverter, new CreateBatchOptions { MaximumSizeInBytes = 99 }, default);
            batch.Dispose();

            Assert.That(batch.SizeInBytes, Is.EqualTo(GetReservedSize(batch)));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="IdempotentAmqpEventBatch.Dispose" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void DisposeCleansUpReturnedMessages()
        {
            var index = 0;
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

            var batch = new IdempotentAmqpEventBatch(mockConverter, options, default);

            for (index = 0; index < 5; ++index)
            {
                Assert.That(batch.TryAdd(new EventData(new byte[0])), Is.True, $"The addition for index: { index } should fit and be accepted.");
            }

            // Request the AMQP messages for the batch and validate they have not been disposed.

            var eventMessages = batch.AsReadOnlyCollection<AmqpMessage>();
            index = 0;

            foreach (var message in eventMessages)
            {
                Assert.That(() => message.ThrowIfDisposed(), Throws.Nothing, $"The message at index: { index } should not have been disposed.");
                ++index;
            }

            // Dispose the batch and verify that the messages held by the batch have been disposed.

            batch.Dispose();
            index = 0;

            foreach (var message in eventMessages)
            {
                Assert.That(() => message.ThrowIfDisposed(), Throws.InstanceOf<ObjectDisposedException>(), $"The message at index: { index } should have been disposed.");
                ++index;
            }
        }

        /// <summary>
        ///   Reads the size reserved for AMQP message overhead in a batch using its private field.
        /// </summary>
        ///
        /// <param name="instance">The instance to consider.</param>
        ///
        /// <returns>The reserved size of the batch.</returns>
        ///
        private static long GetReservedSize(IdempotentAmqpEventBatch instance) =>
            (long)
                typeof(AmqpTransportEventBatch)
                    .GetProperty("ReservedOverheadBytes", BindingFlags.Instance | BindingFlags.NonPublic)
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
            public override AmqpMessage CreateMessageFromEvent(EventData source, string partitionKey = null) => CreateMessageFromEventHandler(source, partitionKey);
            public override AmqpMessage CreateBatchFromEvents(IReadOnlyCollection<EventData> source, string partitionKey = null) => CreateBatchFromEventsHandler(source, partitionKey);
            public override AmqpMessage CreateBatchFromMessages(IReadOnlyCollection<AmqpMessage> source, string partitionKey = null) => CreateBatchFromMessagesHandler(source, partitionKey);
        }
    }
}
