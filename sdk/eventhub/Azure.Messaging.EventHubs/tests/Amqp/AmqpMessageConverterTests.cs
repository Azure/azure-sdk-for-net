// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using Azure.Messaging.EventHubs.Amqp;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="AmqpMessageConverter" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class AmqpMessageConverterTests
    {
        /// <summary>
        ///  The set of test cases for known described type properties.
        /// </summary>
        public static IEnumerable<object[]> DescribedTypePropertyTestCases()
        {
            Func<object, object> TranslateValue = value =>
            {
                switch (value)
                {
                    case DateTimeOffset offset:
                        return offset.Ticks;

                    case TimeSpan timespan:
                        return timespan.Ticks;

                    default:
                        return value;
                }
            };

            yield return new object[] { AmqpProperty.Uri, new Uri("https://www.cheetoes.zomg"), TranslateValue };
            yield return new object[] { AmqpProperty.DateTimeOffset, DateTimeOffset.Parse("2015-10-27T12:00:00Z"), TranslateValue };
            yield return new object[] { AmqpProperty.TimeSpan, TimeSpan.FromHours(6), TranslateValue };
        }

        /// <summary>
        ///  The set of test cases for known described type properties.
        /// </summary>
        ///
        public static IEnumerable<object[]> StreamPropertyTestCases()
        {
            var contents = new byte[] { 0x55, 0x66, 0x99, 0xAA };

            yield return new object[] { new MemoryStream(contents, false), contents };
            yield return new object[] { new BufferedStream(new MemoryStream(contents, false), 512), contents };
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateMessageFromEvent" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateMessageFromEventValidatesTheSource()
        {
            var converter = new AmqpMessageConverter();
            Assert.That(() => converter.CreateMessageFromEvent(null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateMessageFromEvent" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CreateMessageFromEventAllowsNoPartitionKey(string partitionKey)
        {
            var converter = new AmqpMessageConverter();
            Assert.That(() => converter.CreateMessageFromEvent(new EventData(new byte[] { 0x11 }), partitionKey), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateMessageFromEvent" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateMessageFromEventPopulatesTheBody()
        {
            var body = new byte[] { 0x11, 0x22, 0x33 };
            var eventData = new EventData(body);
            var converter = new AmqpMessageConverter();

            using var message = converter.CreateMessageFromEvent(eventData);
            Assert.That(message, Is.Not.Null, "The AMQP message should have been created.");
            Assert.That(message.DataBody, Is.Not.Null, "The AMQP message should a body.");

            var messageData = message.DataBody.ToList();
            Assert.That(messageData.Count, Is.EqualTo(1), "The AMQP message should a single data body.");
            Assert.That(messageData[0].Value, Is.EqualTo(eventData.Body.ToArray()), "The AMQP message data should match the event body.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateMessageFromEvent" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("a-key-that-is-for-partitions")]
        public void CreateMessageFromEventProperlySetsThePartitionKeyAnnotation(string partitionKey)
        {
            var body = new byte[] { 0x11, 0x22, 0x33 };
            var eventData = new EventData(body);
            var converter = new AmqpMessageConverter();

            using var message = converter.CreateMessageFromEvent(eventData, partitionKey);
            Assert.That(message, Is.Not.Null, "The AMQP message should have been created.");
            Assert.That(message.MessageAnnotations.Map.TryGetValue(AmqpAnnotation.PartitionKey, out object annotationPartionKey), Is.EqualTo(!String.IsNullOrEmpty(partitionKey)), "The partition key annotation was not correctly set.");

            if (!String.IsNullOrEmpty(partitionKey))
            {
                Assert.That(annotationPartionKey, Is.EqualTo(partitionKey), "The partition key annotation should match.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateMessageFromEvent" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateMessageFromEventPopulatesSimpleApplicationProperties()
        {
            var propertyValues = new object[]
            {
                (byte)0x22,
                (sbyte)0x11,
                (Int16)5,
                (Int32)27,
                (Int64)1122334,
                (UInt16)12,
                (UInt32)24,
                (UInt64)9955,
                (Single)4.3,
                (Double)3.4,
                (Decimal)7.893,
                Guid.NewGuid(),
                DateTime.Parse("2015-10-27T12:00:00Z"),
                true,
                'x',
                "hello"
            };

            var eventData = new EventData(new byte[] { 0x11, 0x22, 0x33 })
            {
                Properties = propertyValues.ToDictionary(value => $"{ value.GetType().Name }Property", value => value)
            };

            using var message = new AmqpMessageConverter().CreateMessageFromEvent(eventData);

            Assert.That(message, Is.Not.Null, "The AMQP message should have been created.");
            Assert.That(message.DataBody, Is.Not.Null, "The AMQP message should a body.");
            Assert.That(message.ApplicationProperties, Is.Not.Null, "The AMQP message should have a set of application properties.");

            // The collection comparisons built into the test assertions do not recognize
            // the property sets as equivalent, but a manual inspection proves the properties exist
            // in both.

            foreach (var property in eventData.Properties.Keys)
            {
                var containsValue = message.ApplicationProperties.Map.TryGetValue(property, out object value);

                Assert.That(containsValue, Is.True, $"The message properties did not contain: [{ property }]");
                Assert.That(value, Is.EqualTo(eventData.Properties[property]), $"The property value did not match for: [{ property }]");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateMessageFromEvent" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(DescribedTypePropertyTestCases))]
        public void CreateMessageFromEventTranslatesDescribedApplicationProperties(object typeDescriptor,
                                                                                   object propertyValueRaw,
                                                                                   Func<object, object> propertyValueAccessor)
        {
            var eventData = new EventData(new byte[] { 0x11, 0x22, 0x33 })
            {
                Properties = new Dictionary<string, object> { { "TestProp", propertyValueRaw } }
            };

            using var message = new AmqpMessageConverter().CreateMessageFromEvent(eventData);

            Assert.That(message, Is.Not.Null, "The AMQP message should have been created.");
            Assert.That(message.DataBody, Is.Not.Null, "The AMQP message should a body.");
            Assert.That(message.ApplicationProperties, Is.Not.Null, "The AMQP message should have a set of application properties.");

            var propertyKey = eventData.Properties.Keys.First();
            var propertyValue = propertyValueAccessor(eventData.Properties[propertyKey]);
            var containsValue = message.ApplicationProperties.Map.TryGetValue(propertyKey, out DescribedType describedValue);

            Assert.That(containsValue, Is.True, "The message properties did not contain the property.");
            Assert.That(describedValue.Value, Is.EqualTo(propertyValue), "The property value did not match.");
            Assert.That(describedValue.Descriptor, Is.EqualTo(typeDescriptor), "The message property descriptor was incorrect.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateMessageFromEvent" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(StreamPropertyTestCases))]
        public void CreateMessageFromEventTranslatesStreamApplicationProperties(object propertyStream,
                                                                                byte[] contents)
        {
            var eventData = new EventData(new byte[] { 0x11, 0x22, 0x33 })
            {
                Properties = new Dictionary<string, object> { { "TestProp", propertyStream } }
            };

            using var message = new AmqpMessageConverter().CreateMessageFromEvent(eventData);

            Assert.That(message, Is.Not.Null, "The AMQP message should have been created.");
            Assert.That(message.DataBody, Is.Not.Null, "The AMQP message should a body.");
            Assert.That(message.ApplicationProperties, Is.Not.Null, "The AMQP message should have a set of application properties.");

            var propertyKey = eventData.Properties.Keys.First();
            var containsValue = message.ApplicationProperties.Map.TryGetValue(propertyKey, out object streamValue);

            Assert.That(containsValue, Is.True, "The message properties did not contain the property.");
            Assert.That(streamValue, Is.InstanceOf<ArraySegment<byte>>(), "The message property stream was not read correctly.");
            Assert.That(((ArraySegment<byte>)streamValue).ToArray(), Is.EqualTo(contents), "The property value did not match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateMessageFromEvent" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateMessageFromEventFailsForUnknownApplicationPropertyType()
        {
            var eventData = new EventData(new byte[] { 0x11, 0x22, 0x33 })
            {
                Properties = new Dictionary<string, object> { { "TestProperty", new RankException() } }
            };

            Assert.That(() => new AmqpMessageConverter().CreateMessageFromEvent(eventData), Throws.InstanceOf<SerializationException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateMessageFromEvent" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateMessageFromEventAllowsAnEmptyEvent()
        {
            var eventData = new EventData(ReadOnlyMemory<byte>.Empty);
            Assert.That(() => new AmqpMessageConverter().CreateMessageFromEvent(eventData), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateMessageFromEvent" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateMessageFromEventAllowsEmptyEventWithAProperty()
        {
            var eventData = new EventData(new byte[0]);
            eventData.Properties["Test"] = 1;

            Assert.That(() => new AmqpMessageConverter().CreateMessageFromEvent(eventData), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateMessageFromEvent" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateMessageFromEventAllowsEmptyEventWithAPartitionKey()
        {
            var eventData = new EventData(new byte[0]);
            Assert.That(() => new AmqpMessageConverter().CreateMessageFromEvent(eventData, "annotation"), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateBatchFromEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateBatchFromEventsValidatesTheSource()
        {
            var converter = new AmqpMessageConverter();
            Assert.That(() => converter.CreateBatchFromEvents(null, "anything"), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateBatchFromEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CreateBatchFromEventsAllowsNoPartitionKey(string partitionKey)
        {
            var events = new[] { new EventData(new byte[] { 0x11, 0x22, 0x33 }) };
            Assert.That(() => new AmqpMessageConverter().CreateBatchFromEvents(events, partitionKey), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateBatchFromEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("a-key-that-is-for-partitions")]
        public void CreateBatchFromEventsWithOneMessagePopulatesEnvelopeProperties(string partitionKey)
        {
            var eventData = new EventData(new byte[] { 0x11, 0x22, 0x33 });
            var converter = new AmqpMessageConverter();

            using var message = converter.CreateBatchFromEvents(new[] { eventData }, partitionKey);
            Assert.That(message, Is.Not.Null, "The batch envelope should have been created.");
            Assert.That(message.Batchable, Is.True, "The batch envelope should be set to batchable.");
            Assert.That(message.MessageFormat, Is.EqualTo(AmqpConstants.AmqpBatchedMessageFormat), "The batch envelope should have a batchable format.");
            Assert.That(message.DataBody, Is.Not.Null, "The batch envelope should a body.");
            Assert.That(message.DataBody.ToList().Count, Is.EqualTo(1), "The batch envelope should contain a single event in the body.");
            Assert.That(message.MessageAnnotations.Map.TryGetValue(AmqpAnnotation.PartitionKey, out string partitionKeyAnnotation), Is.EqualTo(!String.IsNullOrEmpty(partitionKey)), "There should be an annotation if a partition key was present.");

            if (!String.IsNullOrEmpty(partitionKey))
            {
                Assert.That(partitionKeyAnnotation, Is.EqualTo(partitionKey), "The partition key annotation should match.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateBatchFromEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("a-key-that-is-for-partitions")]
        public void CreateBatchFromEventsWithMultipleEventsMessagePopulatesEnvelopeProperties(string partitionKey)
        {
            var events = new[]
            {
                new EventData(new byte[] { 0x11, 0x22, 0x33 }),
                new EventData(new byte[] { 0x44, 0x55, 0x66 })
            };

            using var message = new AmqpMessageConverter().CreateBatchFromEvents(events, partitionKey);
            Assert.That(message, Is.Not.Null, "The batch envelope should have been created.");
            Assert.That(message.Batchable, Is.True, "The batch envelope should be marked as batchable.");
            Assert.That(message.MessageFormat, Is.EqualTo(AmqpConstants.AmqpBatchedMessageFormat), "The batch envelope should be marked with a batchable format.");
            Assert.That(message.DataBody, Is.Not.Null, "The batch envelope should a body.");
            Assert.That(message.DataBody.ToList().Count, Is.EqualTo(events.Length), "The batch envelope should contain each batch event in the body.");
            Assert.That(message.MessageAnnotations.Map.TryGetValue(AmqpAnnotation.PartitionKey, out string partitionKeyAnnotation), Is.EqualTo(!String.IsNullOrEmpty(partitionKey)), "There should be an annotation if a partition key was present.");

            if (!String.IsNullOrEmpty(partitionKey))
            {
                Assert.That(partitionKeyAnnotation, Is.EqualTo(partitionKey), "The partition key annotation should match.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateBatchFromEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateBatchFromEventWithOneEventUsesItForTheEnvelope()
        {
            var body = new byte[] { 0x11, 0x22, 0x33 };
            var property = 65;

            var eventData = new EventData(body)
            {
                Properties = new Dictionary<string, object> { { nameof(property), property } }
            };

            using var message = new AmqpMessageConverter().CreateBatchFromEvents(new[] { eventData }, "Something");
            Assert.That(message, Is.Not.Null, "The batch envelope should have been created.");
            Assert.That(message.DataBody, Is.Not.Null, "The batch envelope should a body.");

            var messageData = message.DataBody.ToList();
            Assert.That(messageData.Count, Is.EqualTo(1), "The batch envelope should a single data body.");
            Assert.That(messageData[0].Value, Is.EqualTo(eventData.Body.ToArray()), "The batch envelope data should match the event body.");

            Assert.That(message.ApplicationProperties.Map.TryGetValue(nameof(property), out object propertyValue), Is.True, "The application property should exist in the batch.");
            Assert.That(propertyValue, Is.EqualTo(property), "The application property value should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateBatchFromEvents" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateBatchFromEventsWithMultipleEventsPopulatesTheEnvelopeBody()
        {
            using var firstEventStream = new MemoryStream(new byte[] { 0x37, 0x39 });
            using var secondEventStream = new MemoryStream(new byte[] { 0x73, 0x93 });

            var firstEvent = new EventData(new byte[] { 0x11, 0x22, 0x33 })
            {
                Properties = new Dictionary<string, object> { { nameof(MemoryStream), firstEventStream } }
            };

            var secondEvent = new EventData(new byte[] { 0x44, 0x55, 0x66 })
            {
                Properties = new Dictionary<string, object> { { nameof(MemoryStream), secondEventStream } }
            };

            var events = new[] { firstEvent, secondEvent };
            var converter = new AmqpMessageConverter();

            using var message = converter.CreateBatchFromEvents(events, null);
            Assert.That(message, Is.Not.Null, "The batch envelope should have been created.");
            Assert.That(message.DataBody, Is.Not.Null, "The batch envelope should a body.");

            var messageData = message.DataBody.ToList();
            Assert.That(messageData.Count, Is.EqualTo(events.Length), "The batch envelope should contain each batch event in the body.");

            // Reset the position for the stream properties, so that they
            // can be read for translation again.

            firstEventStream.Position = 0;
            secondEventStream.Position = 0;

            for (var index = 0; index < events.Length; ++index)
            {
                var eventMessage = converter.CreateMessageFromEvent(events[index]);
                eventMessage.Batchable = true;

                using var memoryStream = new MemoryStream();
                using var eventStream = eventMessage.ToStream();

                eventStream.CopyTo(memoryStream);
                var expected = memoryStream.ToArray();
                var actual = ((ArraySegment<byte>)messageData[index].Value).ToArray();

                Assert.That(actual, Is.EqualTo(expected), $"The batch body for message { index } should match the serialized event.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateBatchFromEvents" />
        ///   method.
        /// </summary>
        [Test]
        public void CreateBatchFromEventsWithMultipleEventsAssignsThePartitionKeyToBodyMessages()
        {
            var partitionKey = "sOmE-kEY";
            var firstEvent = new EventData(new byte[] { 0x11, 0x22, 0x33 });
            var secondEvent = new EventData(new byte[] { 0x44, 0x55, 0x66 });
            var events = new[] { firstEvent, secondEvent };
            var converter = new AmqpMessageConverter();

            using var message = converter.CreateBatchFromEvents(events, partitionKey);
            Assert.That(message, Is.Not.Null, "The batch envelope should have been created.");
            Assert.That(message.DataBody, Is.Not.Null, "The batch envelope should a body.");

            var messageData = message.DataBody.ToList();
            Assert.That(messageData.Count, Is.EqualTo(events.Length), "The batch envelope should contain each batch event in the body.");

            for (var index = 0; index < events.Length; ++index)
            {
                var eventMessage = converter.CreateMessageFromEvent(events[index]);
                eventMessage.Batchable = true;
                eventMessage.MessageAnnotations.Map[AmqpAnnotation.PartitionKey] = partitionKey;

                using var memoryStream = new MemoryStream();
                using var eventStream = eventMessage.ToStream();

                eventStream.CopyTo(memoryStream);
                var expected = memoryStream.ToArray();
                var actual = ((ArraySegment<byte>)messageData[index].Value).ToArray();

                Assert.That(actual, Is.EqualTo(expected), $"The batch body for message { index } should match the serialized event.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateBatchFromMessages" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateBatchFromMessagesValidatesTheSource()
        {
            var converter = new AmqpMessageConverter();
            Assert.That(() => converter.CreateBatchFromMessages(null, "anything"), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateBatchFromMessages" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CreateBatchFromMessagesAllowNoPartitionKey(string partitionKey)
        {
            var converter = new AmqpMessageConverter();
            Assert.That(() => converter.CreateBatchFromMessages(new[] { AmqpMessage.Create() }, partitionKey), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateBatchFromMessages" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("a-key-that-is-for-partitions")]
        public void CreateBatchFromMessagesWithOneMessagePopulatesEnvelopeProperties(string partitionKey)
        {
            var eventData = new EventData(new byte[] { 0x11, 0x22, 0x33 });
            var converter = new AmqpMessageConverter();

            using var source = converter.CreateMessageFromEvent(eventData);
            using var batchEnvelope = converter.CreateBatchFromMessages(new[] { source }, partitionKey);
            Assert.That(batchEnvelope, Is.Not.Null, "The batch envelope should have been created.");
            Assert.That(batchEnvelope.Batchable, Is.True, "The batch envelope should be set to batchable.");
            Assert.That(batchEnvelope.MessageFormat, Is.EqualTo(AmqpConstants.AmqpBatchedMessageFormat), "The batch envelope should have a batchable format.");
            Assert.That(batchEnvelope.DataBody, Is.Not.Null, "The batch envelope should a body.");
            Assert.That(batchEnvelope.DataBody.ToList().Count, Is.EqualTo(1), "The batch envelope should contain a single event in the body.");
            Assert.That(batchEnvelope.MessageAnnotations.Map.TryGetValue(AmqpAnnotation.PartitionKey, out string partitionKeyAnnotation), Is.EqualTo(!String.IsNullOrEmpty(partitionKey)), "There should be an annotation if a partition key was present.");

            if (!String.IsNullOrEmpty(partitionKey))
            {
                Assert.That(partitionKeyAnnotation, Is.EqualTo(partitionKey), "The partition key annotation should match.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateBatchFromMessages" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("a-key-that-is-for-partitions")]
        public void CreateBatchFromMessagesWithMultipleEventsMessagePopulatesEnvelopeProperties(string partitionKey)
        {
            var converter = new AmqpMessageConverter();
            using var first = converter.CreateMessageFromEvent(new EventData(new byte[] { 0x11, 0x22, 0x33 }));
            using var second = converter.CreateMessageFromEvent(new EventData(new byte[] { 0x44, 0x55, 0x66 }));
            var source = new[] { first, second };

            using var batchEnvelope = converter.CreateBatchFromMessages(source, partitionKey);
            Assert.That(batchEnvelope, Is.Not.Null, "The batch envelope should have been created.");
            Assert.That(batchEnvelope.Batchable, Is.True, "The batch envelope should be marked as batchable.");
            Assert.That(batchEnvelope.MessageFormat, Is.EqualTo(AmqpConstants.AmqpBatchedMessageFormat), "The batch envelope should be marked with a batchable format.");
            Assert.That(batchEnvelope.DataBody, Is.Not.Null, "The batch envelope should a body.");
            Assert.That(batchEnvelope.DataBody.ToList().Count, Is.EqualTo(source.Length), "The batch envelope should contain each batch event in the body.");
            Assert.That(batchEnvelope.MessageAnnotations.Map.TryGetValue(AmqpAnnotation.PartitionKey, out string partitionKeyAnnotation), Is.EqualTo(!String.IsNullOrEmpty(partitionKey)), "There should be an annotation if a partition key was present.");

            if (!String.IsNullOrEmpty(partitionKey))
            {
                Assert.That(partitionKeyAnnotation, Is.EqualTo(partitionKey), "The partition key annotation should match.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateBatchFromMessages" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateBatchFromMessagesWithOneEventUsesItForTheEnvelope()
        {
            var converter = new AmqpMessageConverter();
            var body = new byte[] { 0x11, 0x22, 0x33 };
            var property = 65;

            var eventData = new EventData(body)
            {
                Properties = new Dictionary<string, object> { { nameof(property), property } }
            };

            using var source = converter.CreateMessageFromEvent(eventData);
            using var batchEnvelope = converter.CreateBatchFromMessages(new[] { source }, "Something");
            Assert.That(batchEnvelope, Is.Not.Null, "The batch envelope should have been created.");
            Assert.That(batchEnvelope.DataBody, Is.Not.Null, "The batch envelope should a body.");

            var messageData = batchEnvelope.DataBody.ToList();
            Assert.That(messageData.Count, Is.EqualTo(1), "The batch envelope should a single data body.");
            Assert.That(messageData[0].Value, Is.EqualTo(eventData.Body.ToArray()), "The batch envelope data should match the event body.");

            Assert.That(batchEnvelope.ApplicationProperties.Map.TryGetValue(nameof(property), out object propertyValue), Is.True, "The application property should exist in the batch.");
            Assert.That(propertyValue, Is.EqualTo(property), "The application property value should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateBatchFromMessages" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateBatchFromMessagesWithMultipleEventsPopulatesTheEnvelopeBody()
        {
            using var firstEventStream = new MemoryStream(new byte[] { 0x37, 0x39 });
            using var secondEventStream = new MemoryStream(new byte[] { 0x73, 0x93 });

            var converter = new AmqpMessageConverter();

            var firstEvent = new EventData(new byte[] { 0x11, 0x22, 0x33 })
            {
                Properties = new Dictionary<string, object> { { nameof(MemoryStream), firstEventStream } }
            };

            var secondEvent = new EventData(new byte[] { 0x44, 0x55, 0x66 })
            {
                Properties = new Dictionary<string, object> { { nameof(MemoryStream), secondEventStream } }
            };

            using var firstMessage = converter.CreateMessageFromEvent(firstEvent);
            using var secondMessage = converter.CreateMessageFromEvent(secondEvent);
            var source = new[] { firstMessage, secondMessage };

            using var batchEnvelope = converter.CreateBatchFromMessages(source, null);
            Assert.That(batchEnvelope, Is.Not.Null, "The batch envelope should have been created.");
            Assert.That(batchEnvelope.DataBody, Is.Not.Null, "The batch envelope should a body.");

            var messageData = batchEnvelope.DataBody.ToList();
            Assert.That(messageData.Count, Is.EqualTo(source.Length), "The batch envelope should contain each batch event in the body.");

            // Reset the position for the stream properties, so that they
            // can be read for translation again.

            firstEventStream.Position = 0;
            secondEventStream.Position = 0;

            for (var index = 0; index < source.Length; ++index)
            {
                var eventMessage = source[index];
                eventMessage.Batchable = true;

                using var memoryStream = new MemoryStream();
                using var eventStream = eventMessage.ToStream();

                eventStream.CopyTo(memoryStream);
                var expected = memoryStream.ToArray();
                var actual = ((ArraySegment<byte>)messageData[index].Value).ToArray();

                Assert.That(actual, Is.EqualTo(expected), $"The batch body for message { index } should match the serialized event.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateBatchFromMessages" />
        ///   method.
        /// </summary>
        [Test]
        public void CreateBatchFromMessagesWithMultipleEventsAssignsThePartitionKeyToBodyMessages()
        {
            var partitionKey = "sOmE-kEY";
            var firstEvent = new EventData(new byte[] { 0x11, 0x22, 0x33 });
            var secondEvent = new EventData(new byte[] { 0x44, 0x55, 0x66 });
            var converter = new AmqpMessageConverter();

            using var firstMessage = converter.CreateMessageFromEvent(firstEvent, partitionKey);
            using var secondMessage = converter.CreateMessageFromEvent(secondEvent, partitionKey);


            var source = new[] { firstMessage, secondMessage };

            using var batchEnvelope = converter.CreateBatchFromMessages(source, partitionKey);
            Assert.That(batchEnvelope, Is.Not.Null, "The batch envelope should have been created.");
            Assert.That(batchEnvelope.DataBody, Is.Not.Null, "The batch envelope should a body.");

            var messageData = batchEnvelope.DataBody.ToList();
            Assert.That(messageData.Count, Is.EqualTo(source.Length), "The batch envelope should contain each batch event in the body.");

            for (var index = 0; index < source.Length; ++index)
            {
                var eventMessage = source[index];
                eventMessage.Batchable = true;

                using var memoryStream = new MemoryStream();
                using var eventStream = eventMessage.ToStream();

                eventStream.CopyTo(memoryStream);
                var expected = memoryStream.ToArray();
                var actual = ((ArraySegment<byte>)messageData[index].Value).ToArray();

                Assert.That(actual, Is.EqualTo(expected), $"The batch body for message { index } should match the serialized event.");
            }
        }
    }
}
