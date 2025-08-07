// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Ignore Spelling: Accessor

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Azure.Core.Amqp;
using Azure.Messaging.EventHubs.Amqp;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;
using Microsoft.Azure.Amqp.Framing;
using NUnit.Framework;
using NUnit.Framework.Constraints;

using FramingData = Microsoft.Azure.Amqp.Framing.Data;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="AmqpMessageConverter" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class AmqpMessageConverterTests
    {
        /// <summary>
        ///  The set of test cases for known described type properties.
        /// </summary>
        ///
        public static IEnumerable<object[]> DescribedTypePropertyTestCases()
        {
            Func<object, object> TranslateValue = value =>
            {
                return value switch
                {
                    DateTimeOffset offset => offset.Ticks,

                    TimeSpan timespan => timespan.Ticks,

                    Uri uri => uri.AbsoluteUri,

                    _ => value,
                };
            };

            yield return new object[] { AmqpProperty.Descriptor.Uri, new Uri("https://www.cheetoes.zomg"), TranslateValue };
            yield return new object[] { AmqpProperty.Descriptor.DateTimeOffset, DateTimeOffset.Parse("2015-10-27T12:00:00Z"), TranslateValue };
            yield return new object[] { AmqpProperty.Descriptor.TimeSpan, TimeSpan.FromHours(6), TranslateValue };
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
        ///  The set of test cases for known described type properties.
        /// </summary>
        ///
        public static IEnumerable<object[]> BinaryPropertyTestCases()
        {
            var contents = new byte[] { 0x55, 0x66, 0x99, 0xAA };

            yield return new object[] { contents, contents };
            yield return new object[] { new ArraySegment<byte>(contents), contents };
        }

        /// <summary>
        ///  The set of test cases for optional publishing properties.
        /// </summary>
        ///
        public static IEnumerable<object[]> PublisherPropertyTestCases()
        {
            // The values represent the test arguments:
            //   - Pending Sequence Number (int?)
            //   - Pending Producer Group Id (long?)
            //   - Pending Owner Level (short?)

            yield return new object[] { (int?)123, (long?)456, (short?)789 };
            yield return new object[] { null, (long?)456, (short?)789 };
            yield return new object[] { (int?)123, null, (short?)789 };
            yield return new object[] { (int?)123, (long?)456, null };
            yield return new object[] { (int?)123, null, null };
            yield return new object[] { null, (long?)456, null };
            yield return new object[] { null, null, (short?)789 };
            yield return new object[] { null, null, null };
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

            using AmqpMessage message = converter.CreateMessageFromEvent(eventData);
            Assert.That(message, Is.Not.Null, "The AMQP message should have been created.");
            Assert.That(message.DataBody, Is.Not.Null, "The AMQP message should a body.");

            var messageData = message.DataBody.ToList();
            Assert.That(messageData.Count, Is.EqualTo(1), "The AMQP message should a single data body.");
            Assert.That(messageData[0].Value, Is.EqualTo(eventData.EventBody.ToArray()), "The AMQP message data should match the event body.");
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

            using AmqpMessage message = converter.CreateMessageFromEvent(eventData, partitionKey);
            Assert.That(message, Is.Not.Null, "The AMQP message should have been created.");
            Assert.That(message.MessageAnnotations.Map.TryGetValue(AmqpProperty.PartitionKey, out object annotationPartionKey), Is.EqualTo(!string.IsNullOrEmpty(partitionKey)), "The partition key annotation was not correctly set.");

            if (!string.IsNullOrEmpty(partitionKey))
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
                (short)5,
                (int)27,
                (long)1122334,
                (ushort)12,
                (uint)24,
                (ulong)9955,
                (float)4.3,
                (double)3.4,
                (decimal)7.893,
                Guid.NewGuid(),
                DateTime.Parse("2015-10-27T12:00:00Z"),
                true,
                'x',
                "hello"
            };

            var eventData = new EventData(
                eventBody: new BinaryData(new byte[] { 0x11, 0x22, 0x33 }),
                properties: propertyValues.ToDictionary(value => $"{ value.GetType().Name }Property", value => value));

            using AmqpMessage message = new AmqpMessageConverter().CreateMessageFromEvent(eventData);

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
        [TestCaseSource(nameof(PublisherPropertyTestCases))]
        public void CreateMessageFromEventPopulatesPublisherAnnotations(int? pendingSequenceNumber,
                                                                        long? pendingGroupId,
                                                                        short? pendingOwnerLevel)
        {
            var eventData = new EventData(new BinaryData(new byte[] { 0x11, 0x22, 0x33 }));
            eventData.PendingPublishSequenceNumber = pendingSequenceNumber;
            eventData.PendingProducerGroupId = pendingGroupId;
            eventData.PendingProducerOwnerLevel = pendingOwnerLevel;

            using AmqpMessage message = new AmqpMessageConverter().CreateMessageFromEvent(eventData);

            Assert.That(message, Is.Not.Null, "The AMQP message should have been created.");
            Assert.That(message.DataBody, Is.Not.Null, "The AMQP message should a body.");
            Assert.That(message.MessageAnnotations, Is.Not.Null, "The AMQP message annotations should be present.");

            // Each annotation should only be present if a value was assigned.

            if (pendingSequenceNumber.HasValue)
            {
                Assert.That(message.MessageAnnotations.Map[AmqpProperty.ProducerSequenceNumber], Is.EqualTo(eventData.PendingPublishSequenceNumber.Value), "The publishing sequence number should have been set.");
            }
            else
            {
                Assert.That(message.MessageAnnotations.Map.Any(item => item.Key.ToString() == AmqpProperty.ProducerSequenceNumber.Value), Is.False, "The publishing sequence number should not have been set.");
            }

            if (pendingGroupId.HasValue)
            {
                Assert.That(message.MessageAnnotations.Map[AmqpProperty.ProducerGroupId], Is.EqualTo(eventData.PendingProducerGroupId.Value), "The producer group should have been set.");
            }
            else
            {
                Assert.That(message.MessageAnnotations.Map.Any(item => item.Key.ToString() == AmqpProperty.ProducerGroupId.Value), Is.False, "The producer group should not have been set.");
            }

            if (pendingOwnerLevel.HasValue)
            {
                Assert.That(message.MessageAnnotations.Map[AmqpProperty.ProducerOwnerLevel], Is.EqualTo(eventData.PendingProducerOwnerLevel.Value), "The producer owner level should have been set.");
            }
            else
            {
                Assert.That(message.MessageAnnotations.Map.Any(item => item.Key.ToString() == AmqpProperty.ProducerOwnerLevel.Value), Is.False, "The producer owner level should not have been set.");
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
            var eventData = new EventData(
                eventBody: new BinaryData(new byte[] { 0x11, 0x22, 0x33 }),
                properties: new Dictionary<string, object> { { "TestProp", propertyValueRaw } });

            using AmqpMessage message = new AmqpMessageConverter().CreateMessageFromEvent(eventData);

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
            var eventData = new EventData(
                eventBody: new BinaryData(new byte[] { 0x11, 0x22, 0x33 }),
                properties: new Dictionary<string, object> { { "TestProp", propertyStream } });

            using AmqpMessage message = new AmqpMessageConverter().CreateMessageFromEvent(eventData);

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
        [TestCaseSource(nameof(BinaryPropertyTestCases))]
        public void CreateMessageFromEventTranslatesBinaryApplicationProperties(object property,
                                                                                object contents)
        {
            var eventData = new EventData(
                eventBody: new BinaryData(new byte[] { 0x11, 0x22, 0x33 }),
                properties: new Dictionary<string, object> { { "TestProp", property } });

            using AmqpMessage message = new AmqpMessageConverter().CreateMessageFromEvent(eventData);

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
            var eventData = new EventData(
                eventBody: new BinaryData(new byte[] { 0x11, 0x22, 0x33 }),
                properties: new Dictionary<string, object> { { "TestProperty", new RankException() } });

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
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateMessageFromEvent" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateMessageFromEventDoesNotTriggerPropertiesInstantiation()
        {
            var eventData = new EventData(ReadOnlyMemory<byte>.Empty);
            using var message = new AmqpMessageConverter().CreateMessageFromEvent(eventData);

            Assert.That(eventData.GetRawAmqpMessage().HasSection(AmqpMessageSection.ApplicationProperties), Is.False, "Translation should not have cause the properties dictionary to be instantiated.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateMessageFromEvent" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateMessageFromEventPopulatesTheHeader()
        {
            var sourceMessage = new AmqpAnnotatedMessage(AmqpMessageBody.FromData(new[] { ReadOnlyMemory<byte>.Empty }));
            sourceMessage.Header.DeliveryCount = 123;
            sourceMessage.Header.Durable = true;
            sourceMessage.Header.FirstAcquirer = true;
            sourceMessage.Header.Priority = 1;
            sourceMessage.Header.TimeToLive = TimeSpan.FromDays(2);

            var eventData = new EventData(sourceMessage);
            using var message = new AmqpMessageConverter().CreateMessageFromEvent(eventData);

            Assert.That(message, Is.Not.Null, "The AMQP message should have been created.");
            Assert.That(message.Sections.HasFlag(SectionFlag.Header), "The AMQP message should have a header section.");
            Assert.That(message.Header.DeliveryCount, Is.EqualTo(sourceMessage.Header.DeliveryCount), "The delivery count should match.");
            Assert.That(message.Header.Durable, Is.EqualTo(sourceMessage.Header.Durable), "The durable flag should match.");
            Assert.That(message.Header.FirstAcquirer, Is.EqualTo(sourceMessage.Header.FirstAcquirer), "The first acquirer flag should match.");
            Assert.That(message.Header.Priority, Is.EqualTo(sourceMessage.Header.Priority), "The priority should match.");
            Assert.That(message.Header.Ttl, Is.EqualTo(sourceMessage.Header.TimeToLive.Value.TotalMilliseconds), "The time to live should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateMessageFromEvent" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateMessageFromEventPopulatesTheProperties()
        {
            var sourceMessage = new AmqpAnnotatedMessage(AmqpMessageBody.FromData(new[] { ReadOnlyMemory<byte>.Empty }));
            sourceMessage.Properties.AbsoluteExpiryTime = new DateTimeOffset(2015, 10, 27, 0, 0 ,0 ,0, TimeSpan.Zero);
            sourceMessage.Properties.ContentEncoding = "utf-8";
            sourceMessage.Properties.ContentType = "test/unit";
            sourceMessage.Properties.CorrelationId = new AmqpMessageId("OU812");
            sourceMessage.Properties.CreationTime = new DateTimeOffset(2012, 3, 4, 8, 0, 0, 0, TimeSpan.Zero);
            sourceMessage.Properties.GroupId = "Red Squad";
            sourceMessage.Properties.GroupSequence = 76;
            sourceMessage.Properties.MessageId = new AmqpMessageId("Bob");
            sourceMessage.Properties.ReplyTo = new AmqpAddress("1407 Graymalkin Lane");
            sourceMessage.Properties.ReplyToGroupId = "Home";
            sourceMessage.Properties.Subject = "You'll never believe this weight loss secret!";
            sourceMessage.Properties.To = new AmqpAddress("http://some.server.com");
            sourceMessage.Properties.UserId = new byte[] { 0x11, 0x22 };

            var eventData = new EventData(sourceMessage);
            using var message = new AmqpMessageConverter().CreateMessageFromEvent(eventData);

            Assert.That(message, Is.Not.Null, "The AMQP message should have been created.");
            Assert.That(message.Sections.HasFlag(SectionFlag.Properties), "The AMQP message should have a properties section.");
            Assert.That(message.Properties.AbsoluteExpiryTime, Is.EqualTo(sourceMessage.Properties.AbsoluteExpiryTime.Value.UtcDateTime), "The expiry time should match.");
            Assert.That(message.Properties.ContentEncoding.ToString(), Is.EqualTo(sourceMessage.Properties.ContentEncoding), "The content encoding should match.");
            Assert.That(message.Properties.ContentType.ToString(), Is.EqualTo(sourceMessage.Properties.ContentType), "The content type should match.");
            Assert.That(message.Properties.CorrelationId.ToString(), Is.EqualTo(sourceMessage.Properties.CorrelationId.ToString()), "The correlation identifier should match.");
            Assert.That(message.Properties.CreationTime, Is.EqualTo(sourceMessage.Properties.CreationTime.Value.UtcDateTime), "The creation time should match.");
            Assert.That(message.Properties.GroupId, Is.EqualTo(sourceMessage.Properties.GroupId), "The group identifier should match.");
            Assert.That(message.Properties.GroupSequence, Is.EqualTo(sourceMessage.Properties.GroupSequence), "The group sequence should match.");
            Assert.That(message.Properties.MessageId.ToString(), Is.EqualTo(sourceMessage.Properties.MessageId.ToString()), "The message identifier should match.");
            Assert.That(message.Properties.ReplyTo.ToString(), Is.EqualTo(sourceMessage.Properties.ReplyTo.ToString()), "The reply-to address should match.");
            Assert.That(message.Properties.ReplyToGroupId, Is.EqualTo(sourceMessage.Properties.ReplyToGroupId), "The reply-to group identifier should match.");
            Assert.That(message.Properties.Subject, Is.EqualTo(sourceMessage.Properties.Subject), "The subject should match.");
            Assert.That(message.Properties.To.ToString(), Is.EqualTo(sourceMessage.Properties.To.ToString()), "The to address should match.");
            Assert.That(message.Properties.UserId.ToArray(), Is.EquivalentTo(sourceMessage.Properties.UserId.Value.ToArray()), "The user identifier should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateMessageFromEvent" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateMessageFromEventPopulatesMapSections()
        {
            var sourceMessage = new AmqpAnnotatedMessage(AmqpMessageBody.FromData(new[] { ReadOnlyMemory<byte>.Empty }));

            // Delivery Annotations

            sourceMessage.DeliveryAnnotations.Add("Three", 3);
            sourceMessage.DeliveryAnnotations.Add("Four", "4");

            // Message Annotations

            sourceMessage.MessageAnnotations.Add("Five", 5);
            sourceMessage.MessageAnnotations.Add("Six", "6");

            // Footer

            sourceMessage.Footer.Add("Seven", 7);
            sourceMessage.Footer.Add("Eight", "8");

            var eventData = new EventData(sourceMessage);
            using var message = new AmqpMessageConverter().CreateMessageFromEvent(eventData);

            Assert.That(message, Is.Not.Null, "The AMQP message should have been created.");
            Assert.That(message.Sections.HasFlag(SectionFlag.DeliveryAnnotations), "The AMQP message should have a delivery annotations section.");
            Assert.That(message.Sections.HasFlag(SectionFlag.MessageAnnotations), "The AMQP message should have a message annotations section.");
            Assert.That(message.Sections.HasFlag(SectionFlag.Footer), "The AMQP message should have a footer section.");

            void validateMap(AmqpMap map, IDictionary<string, object> expected, string mapName)
            {
                foreach (var item in map)
                {
                    Assert.That(expected.TryGetValue(item.Key.ToString(), out object expectedValue), Is.True, $"The { mapName } section map did not contain: [{ item.Key }]");
                    Assert.That(item.Value, Is.EqualTo(expectedValue), $"The { mapName } section map property value did not match for: [{ item.Key }]");
                }
            }

            validateMap(message.DeliveryAnnotations.Map, sourceMessage.DeliveryAnnotations, nameof(sourceMessage.DeliveryAnnotations));
            validateMap(message.MessageAnnotations.Map, sourceMessage.MessageAnnotations, nameof(sourceMessage.MessageAnnotations));
            validateMap(message.Footer.Map, sourceMessage.Footer, nameof(sourceMessage.Footer));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateMessageFromEvent" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateMessageFromEventPopulatesApplicationProperties()
        {
            var sourceMessage = new AmqpAnnotatedMessage(AmqpMessageBody.FromData(new[] { ReadOnlyMemory<byte>.Empty }));
            sourceMessage.ApplicationProperties.Add("Three", 3);
            sourceMessage.ApplicationProperties.Add("Four", "4");

            var eventData = new EventData(sourceMessage);
            using var message = new AmqpMessageConverter().CreateMessageFromEvent(eventData);

            Assert.That(message, Is.Not.Null, "The AMQP message should have been created.");
            Assert.That(message.Sections.HasFlag(SectionFlag.ApplicationProperties), "The AMQP message should have an application properties section.");

            foreach (var property in sourceMessage.ApplicationProperties.Keys)
            {
                var containsValue = message.ApplicationProperties.Map.TryGetValue(property, out object value);

                Assert.That(containsValue, Is.True, $"The application properties did not contain: [{ property }]");
                Assert.That(value, Is.EqualTo(eventData.Properties[property]), $"The application property value did not match for: [{ property }]");
            }
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
            var events = new List<EventData> { new EventData(new BinaryData(new byte[] { 0x11, 0x22, 0x33 })) };
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
            var eventData = new EventData(new BinaryData(new byte[] { 0x11, 0x22, 0x33 }));
            var converter = new AmqpMessageConverter();

            using AmqpMessage message = converter.CreateBatchFromEvents(new[] { eventData }, partitionKey);
            Assert.That(message, Is.Not.Null, "The batch envelope should have been created.");
            Assert.That(message.Batchable, Is.True, "The batch envelope should be set to batchable.");
            Assert.That(message.MessageFormat, Is.Null, "The batch envelope should be not be marked with a batchable format when created from one event.");
            Assert.That(message.DataBody, Is.Not.Null, "The batch envelope should a body.");
            Assert.That(message.DataBody.ToList().Count, Is.EqualTo(1), "The batch envelope should contain a single event in the body.");
            Assert.That(message.MessageAnnotations.Map.TryGetValue(AmqpProperty.PartitionKey, out string partitionKeyAnnotation), Is.EqualTo(!string.IsNullOrEmpty(partitionKey)), "There should be an annotation if a partition key was present.");

            if (!string.IsNullOrEmpty(partitionKey))
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
            EventData[] events = new[]
            {
                new EventData(new BinaryData(new byte[] { 0x11, 0x22, 0x33 })),
                new EventData(new byte[] { 0x44, 0x55, 0x66 })
            };

            using AmqpMessage message = new AmqpMessageConverter().CreateBatchFromEvents(events, partitionKey);
            Assert.That(message, Is.Not.Null, "The batch envelope should have been created.");
            Assert.That(message.Batchable, Is.True, "The batch envelope should be marked as batchable.");
            Assert.That(message.MessageFormat, Is.EqualTo(AmqpConstants.AmqpBatchedMessageFormat), "The batch envelope should be marked with a batchable format.");
            Assert.That(message.DataBody, Is.Not.Null, "The batch envelope should a body.");
            Assert.That(message.DataBody.ToList().Count, Is.EqualTo(events.Length), "The batch envelope should contain each batch event in the body.");
            Assert.That(message.MessageAnnotations.Map.TryGetValue(AmqpProperty.PartitionKey, out string partitionKeyAnnotation), Is.EqualTo(!string.IsNullOrEmpty(partitionKey)), "There should be an annotation if a partition key was present.");

            if (!string.IsNullOrEmpty(partitionKey))
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
            var body = new BinaryData(new byte[] { 0x11, 0x22, 0x33 });
            var property = 65;

            var eventData = new EventData(
                eventBody: body,
                properties: new Dictionary<string, object> { { nameof(property), property } });

            using AmqpMessage message = new AmqpMessageConverter().CreateBatchFromEvents(new[] { eventData }, "Something");
            Assert.That(message, Is.Not.Null, "The batch envelope should have been created.");
            Assert.That(message.DataBody, Is.Not.Null, "The batch envelope should a body.");

            var messageData = message.DataBody.ToList();
            Assert.That(messageData.Count, Is.EqualTo(1), "The batch envelope should a single data body.");
            Assert.That(messageData[0].Value, Is.EqualTo(eventData.EventBody.ToArray()), "The batch envelope data should match the event body.");

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

            var firstEvent = new EventData(
                eventBody: new BinaryData(new byte[] { 0x11, 0x22, 0x33 }),
                properties: new Dictionary<string, object> { { nameof(MemoryStream), firstEventStream } });

            var secondEvent = new EventData(
                eventBody: new BinaryData(new byte[] { 0x44, 0x55, 0x66 }),
                properties: new Dictionary<string, object> { { nameof(MemoryStream), secondEventStream } });

            EventData[] events = new[] { firstEvent, secondEvent };
            var converter = new AmqpMessageConverter();

            using AmqpMessage message = converter.CreateBatchFromEvents(events, null);
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
                AmqpMessage eventMessage = converter.CreateMessageFromEvent(events[index]);
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
            var firstEvent = new EventData(new BinaryData(new byte[] { 0x11, 0x22, 0x33 }));
            var secondEvent = new EventData(new byte[] { 0x44, 0x55, 0x66 });
            var events = new[] { firstEvent, secondEvent };
            var converter = new AmqpMessageConverter();

            using AmqpMessage message = converter.CreateBatchFromEvents(events, partitionKey);
            Assert.That(message, Is.Not.Null, "The batch envelope should have been created.");
            Assert.That(message.DataBody, Is.Not.Null, "The batch envelope should a body.");

            var messageData = message.DataBody.ToList();
            Assert.That(messageData.Count, Is.EqualTo(events.Length), "The batch envelope should contain each batch event in the body.");

            for (var index = 0; index < events.Length; ++index)
            {
                AmqpMessage eventMessage = converter.CreateMessageFromEvent(events[index]);
                eventMessage.Batchable = true;
                eventMessage.MessageAnnotations.Map[AmqpProperty.PartitionKey] = partitionKey;

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

            using var message = AmqpMessage.Create(new[] { new FramingData { Value = new ArraySegment<byte>(new byte[] { 0x11, 0x22 }) }});
            Assert.That(() => converter.CreateBatchFromMessages(new List<AmqpMessage> { message }, partitionKey), Throws.Nothing);
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
            var eventData = new EventData(new BinaryData(new byte[] { 0x11, 0x22, 0x33 }));
            var converter = new AmqpMessageConverter();

            using AmqpMessage source = converter.CreateMessageFromEvent(eventData);
            using AmqpMessage batchEnvelope = converter.CreateBatchFromMessages(new List<AmqpMessage> { source }, partitionKey);
            Assert.That(batchEnvelope, Is.Not.Null, "The batch envelope should have been created.");
            Assert.That(batchEnvelope.Batchable, Is.True, "The batch envelope should be set to batchable.");
            Assert.That(batchEnvelope.MessageFormat, Is.Null, "The batch envelope should be not be marked with a batchable format when created from one event.");
            Assert.That(batchEnvelope.DataBody, Is.Not.Null, "The batch envelope should a body.");
            Assert.That(batchEnvelope.DataBody.ToList().Count, Is.EqualTo(1), "The batch envelope should contain a single event in the body.");
            Assert.That(batchEnvelope.MessageAnnotations.Map.TryGetValue(AmqpProperty.PartitionKey, out string partitionKeyAnnotation), Is.EqualTo(!string.IsNullOrEmpty(partitionKey)), "There should be an annotation if a partition key was present.");

            if (!string.IsNullOrEmpty(partitionKey))
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
            using AmqpMessage first = converter.CreateMessageFromEvent(new EventData(new BinaryData(new byte[] { 0x11, 0x22, 0x33 })));
            using AmqpMessage second = converter.CreateMessageFromEvent(new EventData(new byte[] { 0x44, 0x55, 0x66 }));

            var source = new List<AmqpMessage> { first, second };
            using AmqpMessage batchEnvelope = converter.CreateBatchFromMessages(source, partitionKey);

            Assert.That(batchEnvelope, Is.Not.Null, "The batch envelope should have been created.");
            Assert.That(batchEnvelope.Batchable, Is.True, "The batch envelope should be marked as batchable.");
            Assert.That(batchEnvelope.MessageFormat, Is.EqualTo(AmqpConstants.AmqpBatchedMessageFormat), "The batch envelope should be marked with a batchable format.");
            Assert.That(batchEnvelope.DataBody, Is.Not.Null, "The batch envelope should a body.");
            Assert.That(batchEnvelope.DataBody.ToList().Count, Is.EqualTo(source.Count), "The batch envelope should contain each batch event in the body.");
            Assert.That(batchEnvelope.MessageAnnotations.Map.TryGetValue(AmqpProperty.PartitionKey, out string partitionKeyAnnotation), Is.EqualTo(!string.IsNullOrEmpty(partitionKey)), "There should be an annotation if a partition key was present.");

            if (!string.IsNullOrEmpty(partitionKey))
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
            var body = new BinaryData(new byte[] { 0x11, 0x22, 0x33 });
            var property = 65;

            var eventData = new EventData(
                eventBody: body,
                properties: new Dictionary<string, object> { { nameof(property), property } });

            using AmqpMessage source = converter.CreateMessageFromEvent(eventData);
            using AmqpMessage batchEnvelope = converter.CreateBatchFromMessages(new List<AmqpMessage> { source }, "Something");
            Assert.That(batchEnvelope, Is.Not.Null, "The batch envelope should have been created.");
            Assert.That(batchEnvelope.DataBody, Is.Not.Null, "The batch envelope should a body.");

            var messageData = batchEnvelope.DataBody.ToList();
            Assert.That(messageData.Count, Is.EqualTo(1), "The batch envelope should a single data body.");
            Assert.That(messageData[0].Value, Is.EqualTo(eventData.EventBody.ToArray()), "The batch envelope data should match the event body.");

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

            var firstEvent = new EventData(
                eventBody: new BinaryData(new byte[] { 0x11, 0x22, 0x33 }),
                properties: new Dictionary<string, object> { { nameof(MemoryStream), firstEventStream } });

            var secondEvent = new EventData(
                eventBody: new BinaryData(new byte[] { 0x44, 0x55, 0x66 }),
                properties: new Dictionary<string, object> { { nameof(MemoryStream), secondEventStream } });

            using AmqpMessage firstMessage = converter.CreateMessageFromEvent(firstEvent);
            using AmqpMessage secondMessage = converter.CreateMessageFromEvent(secondEvent);

            var source = new List<AmqpMessage> { firstMessage, secondMessage };
            using AmqpMessage batchEnvelope = converter.CreateBatchFromMessages(source, null);

            Assert.That(batchEnvelope, Is.Not.Null, "The batch envelope should have been created.");
            Assert.That(batchEnvelope.DataBody, Is.Not.Null, "The batch envelope should a body.");

            var messageData = batchEnvelope.DataBody.ToList();
            Assert.That(messageData.Count, Is.EqualTo(source.Count), "The batch envelope should contain each batch event in the body.");

            // Reset the position for the stream properties, so that they
            // can be read for translation again.

            firstEventStream.Position = 0;
            secondEventStream.Position = 0;

            for (var index = 0; index < source.Count; ++index)
            {
                AmqpMessage eventMessage = source[index];
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
            var firstEvent = new EventData(new BinaryData(new byte[] { 0x11, 0x22, 0x33 }));
            var secondEvent = new EventData(new byte[] { 0x44, 0x55, 0x66 });
            var converter = new AmqpMessageConverter();

            using AmqpMessage firstMessage = converter.CreateMessageFromEvent(firstEvent, partitionKey);
            using AmqpMessage secondMessage = converter.CreateMessageFromEvent(secondEvent, partitionKey);

            var source = new List<AmqpMessage> { firstMessage, secondMessage };
            using AmqpMessage batchEnvelope = converter.CreateBatchFromMessages(source, partitionKey);

            Assert.That(batchEnvelope, Is.Not.Null, "The batch envelope should have been created.");
            Assert.That(batchEnvelope.DataBody, Is.Not.Null, "The batch envelope should a body.");

            var messageData = batchEnvelope.DataBody.ToList();
            Assert.That(messageData.Count, Is.EqualTo(source.Count), "The batch envelope should contain each batch event in the body.");

            for (var index = 0; index < source.Count; ++index)
            {
                AmqpMessage eventMessage = source[index];
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
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateEventFromMessage" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateEventFromMessageValidatesTheSource()
        {
            var converter = new AmqpMessageConverter();
            Assert.That(() => converter.CreateEventFromMessage(null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateEventFromMessage" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateEventFromMessagePopulatesTheBody()
        {
            var body = new byte[] { 0x11, 0x22, 0x33 };
            using var message = AmqpMessage.Create(new Data { Value = body });

            var converter = new AmqpMessageConverter();
            EventData eventData = converter.CreateEventFromMessage(message);

            Assert.That(eventData, Is.Not.Null, "The event should have been created.");
            Assert.That(eventData.EventBody, Is.Not.Null, "The event should have a body.");
            Assert.That(eventData.EventBody.ToArray(), Is.EqualTo(body), "The body contents should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateEventFromMessage" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateEventFromMessagePopulatesSimpleApplicationProperties()
        {
            var propertyValues = new object[]
            {
                (byte)0x22,
                (sbyte)0x11,
                (short)5,
                (int)27,
                (long)1122334,
                (ushort)12,
                (uint)24,
                (ulong)9955,
                (float)4.3,
                (double)3.4,
                (decimal)7.893,
                Guid.NewGuid(),
                DateTime.Parse("2015-10-27T12:00:00Z"),
                true,
                'x',
                "hello"
            };

            var applicationProperties = propertyValues.ToDictionary(value => $"{ value.GetType().Name }Property", value => value);
            var dataBody = new Data { Value = new byte[] { 0x11, 0x22, 0x33 } };

            using var message = AmqpMessage.Create(dataBody);

            foreach (KeyValuePair<string, object> pair in applicationProperties)
            {
                message.ApplicationProperties.Map.Add(pair.Key, pair.Value);
            }

            var converter = new AmqpMessageConverter();
            EventData eventData = converter.CreateEventFromMessage(message);

            Assert.That(eventData, Is.Not.Null, "The event should have been created.");
            Assert.That(eventData.EventBody, Is.Not.Null, "The event should have a body.");
            Assert.That(eventData.Properties.Any(), Is.True, "The event should have a set of application properties.");

            // The collection comparisons built into the test assertions do not recognize
            // the property sets as equivalent, but a manual inspection proves the properties exist
            // in both.

            foreach (var property in applicationProperties.Keys)
            {
                var containsValue = eventData.Properties.TryGetValue(property, out object value);

                Assert.That(containsValue, Is.True, $"The event properties did not contain: [{ property }]");
                Assert.That(value, Is.EqualTo(applicationProperties[property]), $"The property value did not match for: [{ property }]");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateEventFromMessage" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(DescribedTypePropertyTestCases))]
        public void CreateEventFromMessagePopulateDescribedApplicationProperties(object typeDescriptor,
                                                                                 object propertyValueRaw,
                                                                                 Func<object, object> propertyValueAccessor)
        {
            var dataBody = new Data { Value = new byte[] { 0x11, 0x22, 0x33 } };
            using var message = AmqpMessage.Create(dataBody);

            var describedProperty = new DescribedType(typeDescriptor, propertyValueAccessor(propertyValueRaw));
            message.ApplicationProperties.Map.Add(typeDescriptor.ToString(), describedProperty);

            var converter = new AmqpMessageConverter();
            EventData eventData = converter.CreateEventFromMessage(message);

            Assert.That(eventData, Is.Not.Null, "The event should have been created.");
            Assert.That(eventData.EventBody, Is.Not.Null, "The event should have a body.");
            Assert.That(eventData.Properties.Any(), Is.True, "The event should have a set of application properties.");

            var containsValue = eventData.Properties.TryGetValue(typeDescriptor.ToString(), out object value);
            Assert.That(containsValue, Is.True, $"The event properties did not contain the described property.");
            Assert.That(value, Is.EqualTo(propertyValueRaw), $"The property value did not match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateEventFromMessage" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateEventFromMessagePopulatesAnArrayApplicationPropertyType()
        {
            var dataBody = new Data { Value = new byte[] { 0x11, 0x22, 0x33 } };
            using var message = AmqpMessage.Create(dataBody);

            var propertyKey = "Test";
            var propertyValue = new byte[] { 0x11, 0x15, 0xF8, 0x20 };
            message.ApplicationProperties.Map.Add(propertyKey, propertyValue);

            var converter = new AmqpMessageConverter();
            EventData eventData = converter.CreateEventFromMessage(message);

            Assert.That(eventData, Is.Not.Null, "The event should have been created.");
            Assert.That(eventData.EventBody, Is.Not.Null, "The event should have a body.");
            Assert.That(eventData.Properties.Any(), Is.True, "The event should have a set of application properties.");

            var containsValue = eventData.Properties.TryGetValue(propertyKey, out var eventValue);
            Assert.That(containsValue, Is.True, $"The event properties should contain the property.");
            Assert.That(eventValue, Is.EquivalentTo(propertyValue));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateEventFromMessage" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateEventFromMessagePopulatesAFullArraySegmentApplicationPropertyType()
        {
            var dataBody = new Data { Value = new byte[] { 0x11, 0x22, 0x33 } };
            using var message = AmqpMessage.Create(dataBody);

            var propertyKey = "Test";
            var propertyValue = new byte[] { 0x11, 0x15, 0xF8, 0x20 };
            message.ApplicationProperties.Map.Add(propertyKey, new ArraySegment<byte>(propertyValue));

            var converter = new AmqpMessageConverter();
            EventData eventData = converter.CreateEventFromMessage(message);

            Assert.That(eventData, Is.Not.Null, "The event should have been created.");
            Assert.That(eventData.EventBody, Is.Not.Null, "The event should have a body.");
            Assert.That(eventData.Properties.Any(), Is.True, "The event should have a set of application properties.");

            var containsValue = eventData.Properties.TryGetValue(propertyKey, out var eventValue);
            Assert.That(containsValue, Is.True, $"The event properties should contain the property.");
            Assert.That(eventValue, Is.EquivalentTo(propertyValue));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateEventFromMessage" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateEventFromMessagePopulatesAnArraySegmentApplicationPropertyType()
        {
            var dataBody = new Data { Value = new byte[] { 0x11, 0x22, 0x33 } };
            using var message = AmqpMessage.Create(dataBody);

            var propertyKey = "Test";
            var propertyValue = new byte[] { 0x11, 0x15, 0xF8, 0x20 };
            message.ApplicationProperties.Map.Add(propertyKey, new ArraySegment<byte>(propertyValue, 1, 2));

            var converter = new AmqpMessageConverter();
            EventData eventData = converter.CreateEventFromMessage(message);

            Assert.That(eventData, Is.Not.Null, "The event should have been created.");
            Assert.That(eventData.EventBody, Is.Not.Null, "The event should have a body.");
            Assert.That(eventData.Properties.Any(), Is.True, "The event should have a set of application properties.");

            var containsValue = eventData.Properties.TryGetValue(propertyKey, out var eventValue);
            Assert.That(containsValue, Is.True, $"The event properties should contain the property.");
            Assert.That(eventValue, Is.EquivalentTo(propertyValue.Skip(1).Take(2)));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateEventFromMessage" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateEventFromMessageDoesNotIncludeUnknownApplicationPropertyType()
        {
            var dataBody = new Data { Value = new byte[] { 0x11, 0x22, 0x33 } };
            using var message = AmqpMessage.Create(dataBody);

            var typeDescriptor = (AmqpSymbol)"INVALID";
            var describedProperty = new DescribedType(typeDescriptor, 1234);
            message.ApplicationProperties.Map.Add(typeDescriptor.ToString(), describedProperty);

            var converter = new AmqpMessageConverter();
            EventData eventData = converter.CreateEventFromMessage(message);

            Assert.That(eventData, Is.Not.Null, "The event should have been created.");
            Assert.That(eventData.EventBody, Is.Not.Null, "The event should have a body.");
            Assert.That(eventData.Properties.Any(), Is.False, "The event should not have a set of application properties.");

            var containsValue = eventData.Properties.TryGetValue(typeDescriptor.ToString(), out var _);
            Assert.That(containsValue, Is.False, $"The event properties should not contain the described property.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateEventFromMessage" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateEventFromMessagePopulatesTypedSystemProperties()
        {
            var offset = "123";
            var sequenceNumber = (long.MaxValue - 10);
            var enqueuedTime = DateTimeOffset.Parse("2015-10-27T12:00:00Z");
            var partitionKey = "OMG! partition!";

            var dataBody = new Data { Value = new byte[] { 0x11, 0x22, 0x33 } };
            using var message = AmqpMessage.Create(dataBody);

            message.ApplicationProperties.Map.Add("First", 1);
            message.ApplicationProperties.Map.Add("Second", "2");

            message.MessageAnnotations.Map.Add(AmqpProperty.Offset, offset);
            message.MessageAnnotations.Map.Add(AmqpProperty.SequenceNumber, sequenceNumber);
            message.MessageAnnotations.Map.Add(AmqpProperty.EnqueuedTime, enqueuedTime.Ticks);
            message.MessageAnnotations.Map.Add(AmqpProperty.PartitionKey, partitionKey);

            var converter = new AmqpMessageConverter();
            EventData eventData = converter.CreateEventFromMessage(message);

            Assert.That(eventData, Is.Not.Null, "The event should have been created.");
            Assert.That(eventData.EventBody, Is.Not.Null, "The event should have a body.");
            Assert.That(eventData.Properties.Count, Is.EqualTo(message.ApplicationProperties.Map.Count()), "The event should have a set of properties.");
            Assert.That(eventData.OffsetString, Is.EqualTo(offset), "The offset should match.");
            Assert.That(eventData.SequenceNumber, Is.EqualTo(sequenceNumber), "The sequence number should match.");
            Assert.That(eventData.EnqueuedTime, Is.EqualTo(enqueuedTime), "The enqueue time should match.");
            Assert.That(eventData.PartitionKey, Is.EqualTo(partitionKey), "The partition key should match.");
            Assert.That(eventData.LastPartitionOffset, Is.Null, "The last offset should not be set.");
            Assert.That(eventData.LastPartitionSequenceNumber.HasValue, Is.False, "The last sequence number should not be set.");
            Assert.That(eventData.LastPartitionEnqueuedTime.HasValue, Is.False, "The last enqueued time should not be set.");
            Assert.That(eventData.LastPartitionPropertiesRetrievalTime.HasValue, Is.False, "The last retrieval time should not be set.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateEventFromMessage" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateEventFromMessagePopulatesMappedSystemProperties()
        {
            var firstMessageAnnotation = 456;
            var secondMessageAnnotation = "hello";
            var subjectValue = "Test";

            var dataBody = new Data { Value = new byte[] { 0x11, 0x22, 0x33 } };
            using var message = AmqpMessage.Create(dataBody);

            message.ApplicationProperties.Map.Add("First", 1);
            message.ApplicationProperties.Map.Add("Second", "2");

            message.MessageAnnotations.Map.Add(nameof(firstMessageAnnotation), firstMessageAnnotation);
            message.MessageAnnotations.Map.Add(nameof(secondMessageAnnotation), secondMessageAnnotation);

            message.Properties.Subject = subjectValue;

            var converter = new AmqpMessageConverter();
            EventData eventData = converter.CreateEventFromMessage(message);

            Assert.That(eventData, Is.Not.Null, "The event should have been created.");
            Assert.That(eventData.EventBody, Is.Not.Null, "The event should have a body.");
            Assert.That(eventData.Properties.Count, Is.EqualTo(message.ApplicationProperties.Map.Count()), "The event should have a set of properties.");
            Assert.That(eventData.SystemProperties.ContainsKey(nameof(firstMessageAnnotation)), Is.True, "The first annotation should be in the system properties.");
            Assert.That(eventData.SystemProperties.ContainsKey(nameof(secondMessageAnnotation)), Is.True, "The second annotation should be in the system properties.");
            Assert.That(eventData.SystemProperties.ContainsKey(Properties.SubjectName), Is.True, "The message subject should be in the system properties.");
            Assert.That(eventData.SystemProperties[nameof(firstMessageAnnotation)], Is.EqualTo(firstMessageAnnotation), "The first annotation should match.");
            Assert.That(eventData.SystemProperties[nameof(secondMessageAnnotation)], Is.EqualTo(secondMessageAnnotation), "The second annotation should match.");
            Assert.That(eventData.SystemProperties[Properties.SubjectName], Is.EqualTo(subjectValue), "The message subject should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateEventFromMessage" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateEventFromMessagePopulatesTypedSystemPropertiesAndMetrics()
        {
            string offset = "123";
            var lastOffset = "987";
            var sequenceNumber = (long.MaxValue - 10);
            var lastSequenceNumber = (long.MaxValue - 100);
            var enqueuedTime = DateTimeOffset.Parse("2015-10-27T12:00:00Z");
            var lastEnqueuedTime = DateTimeOffset.Parse("2012-03-04T08:42:00Z");
            var lastRetrievalTime = DateTimeOffset.Parse("203-09-27T04:32:00Z");
            var partitionKey = "OMG! partition!";

            var dataBody = new Data { Value = new byte[] { 0x11, 0x22, 0x33 } };
            using var message = AmqpMessage.Create(dataBody);

            message.ApplicationProperties.Map.Add("First", 1);
            message.ApplicationProperties.Map.Add("Second", "2");

            message.MessageAnnotations.Map.Add(AmqpProperty.Offset, offset.ToString());
            message.MessageAnnotations.Map.Add(AmqpProperty.SequenceNumber, sequenceNumber);
            message.MessageAnnotations.Map.Add(AmqpProperty.EnqueuedTime, enqueuedTime.Ticks);
            message.MessageAnnotations.Map.Add(AmqpProperty.PartitionKey, partitionKey);

            message.DeliveryAnnotations.Map.Add(AmqpProperty.PartitionLastEnqueuedSequenceNumber, lastSequenceNumber);
            message.DeliveryAnnotations.Map.Add(AmqpProperty.PartitionLastEnqueuedOffset, lastOffset.ToString());
            message.DeliveryAnnotations.Map.Add(AmqpProperty.PartitionLastEnqueuedTimeUtc, lastEnqueuedTime.Ticks);
            message.DeliveryAnnotations.Map.Add(AmqpProperty.LastPartitionPropertiesRetrievalTimeUtc, lastRetrievalTime.Ticks);

            var converter = new AmqpMessageConverter();
            EventData eventData = converter.CreateEventFromMessage(message);

            Assert.That(eventData, Is.Not.Null, "The event should have been created.");
            Assert.That(eventData.EventBody, Is.Not.Null, "The event should have a body.");
            Assert.That(eventData.Properties.Count, Is.EqualTo(message.ApplicationProperties.Map.Count()), "The event should have a set of properties.");
            Assert.That(eventData.OffsetString, Is.EqualTo(offset), "The offset should match.");
            Assert.That(eventData.SequenceNumber, Is.EqualTo(sequenceNumber), "The sequence number should match.");
            Assert.That(eventData.EnqueuedTime, Is.EqualTo(enqueuedTime), "The enqueue time should match.");
            Assert.That(eventData.PartitionKey, Is.EqualTo(partitionKey), "The partition key should match.");
            Assert.That(eventData.LastPartitionOffset, Is.EqualTo(lastOffset), "The last offset should match.");
            Assert.That(eventData.LastPartitionSequenceNumber, Is.EqualTo(lastSequenceNumber), "The last sequence number should match.");
            Assert.That(eventData.LastPartitionEnqueuedTime, Is.EqualTo(lastEnqueuedTime), "The last enqueued time should match.");
            Assert.That(eventData.LastPartitionPropertiesRetrievalTime, Is.EqualTo(lastRetrievalTime), "The last retrieval time should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateEventFromMessage" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateEventFromMessagePopulatesEnqueueTimeFromDateTime()
        {
            var enqueuedTime = DateTimeOffset.Parse("2015-10-27T12:00:00Z");
            var lastEnqueuedTime = DateTimeOffset.Parse("2012-03-04T08:42:00Z");

            var dataBody = new Data { Value = new byte[] { 0x11, 0x22, 0x33 } };
            using var message = AmqpMessage.Create(dataBody);

            message.MessageAnnotations.Map.Add(AmqpProperty.EnqueuedTime, enqueuedTime.UtcDateTime);
            message.DeliveryAnnotations.Map.Add(AmqpProperty.PartitionLastEnqueuedTimeUtc, lastEnqueuedTime.UtcDateTime);

            var converter = new AmqpMessageConverter();
            EventData eventData = converter.CreateEventFromMessage(message);

            Assert.That(eventData, Is.Not.Null, "The event should have been created.");
            Assert.That(eventData.EnqueuedTime, Is.EqualTo(enqueuedTime), "The enqueue time should match.");
            Assert.That(eventData.LastPartitionEnqueuedTime, Is.EqualTo(lastEnqueuedTime), "The last enqueued time should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateEventFromMessage" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateEventFromMessagePopulatesEnqueueTimeFromTicks()
        {
            var enqueuedTime = DateTimeOffset.Parse("2015-10-27T12:00:00Z");
            var lastEnqueuedTime = DateTimeOffset.Parse("2012-03-04T08:42:00Z");

            var dataBody = new Data { Value = new byte[] { 0x11, 0x22, 0x33 } };
            using var message = AmqpMessage.Create(dataBody);

            message.MessageAnnotations.Map.Add(AmqpProperty.EnqueuedTime, enqueuedTime.UtcTicks);
            message.DeliveryAnnotations.Map.Add(AmqpProperty.PartitionLastEnqueuedTimeUtc, lastEnqueuedTime.UtcTicks);

            var converter = new AmqpMessageConverter();
            EventData eventData = converter.CreateEventFromMessage(message);

            Assert.That(eventData, Is.Not.Null, "The event should have been created.");
            Assert.That(eventData.EnqueuedTime, Is.EqualTo(enqueuedTime), "The enqueue time should match.");
            Assert.That(eventData.LastPartitionEnqueuedTime, Is.EqualTo(lastEnqueuedTime), "The last enqueued time should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateEventFromMessage" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateEventFromMessagePopulatesLastRetrievalTimeFromDateTime()
        {
            var lastRetrieval = DateTimeOffset.Parse("2012-03-04T08:42:00Z");
            var dataBody = new Data { Value = new byte[] { 0x11, 0x22, 0x33 } };

            using var message = AmqpMessage.Create(dataBody);

            message.DeliveryAnnotations.Map.Add(AmqpProperty.LastPartitionPropertiesRetrievalTimeUtc, lastRetrieval.UtcDateTime);

            var converter = new AmqpMessageConverter();
            EventData eventData = converter.CreateEventFromMessage(message);

            Assert.That(eventData, Is.Not.Null, "The event should have been created.");
            Assert.That(eventData.LastPartitionPropertiesRetrievalTime, Is.EqualTo(lastRetrieval), "The last retrieval time should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateEventFromMessage" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateEventFromMessagePopulatesLastRetrievalTimeFromTicks()
        {
            var lastRetrieval = DateTimeOffset.Parse("2012-03-04T08:42:00Z");
            var dataBody = new Data { Value = new byte[] { 0x11, 0x22, 0x33 } };

            using var message = AmqpMessage.Create(dataBody);

            message.DeliveryAnnotations.Map.Add(AmqpProperty.LastPartitionPropertiesRetrievalTimeUtc, lastRetrieval.UtcTicks);

            var converter = new AmqpMessageConverter();
            EventData eventData = converter.CreateEventFromMessage(message);

            Assert.That(eventData, Is.Not.Null, "The event should have been created.");
            Assert.That(eventData.LastPartitionPropertiesRetrievalTime, Is.EqualTo(lastRetrieval), "The last retrieval time should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateEventFromMessage" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateEventFromMessageAllowsAnEmptyMessage()
        {
            using var message = AmqpMessage.Create();
            Assert.That(() => new AmqpMessageConverter().CreateEventFromMessage(message), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateEventFromMessage" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateEventFromMessagePopulatesTheHeader()
        {
            var body = new byte[] { 0x11, 0x22, 0x33 };
            using var sourceMessage = AmqpMessage.Create(new Data { Value = body });
            sourceMessage.Header.DeliveryCount = 123;
            sourceMessage.Header.Durable = true;
            sourceMessage.Header.FirstAcquirer = true;
            sourceMessage.Header.Priority = 1;
            sourceMessage.Header.Ttl = (uint)TimeSpan.FromDays(2).TotalMilliseconds;

            var converter = new AmqpMessageConverter();
            var eventData = converter.CreateEventFromMessage(sourceMessage);
            var message = eventData.GetRawAmqpMessage();

            Assert.That(eventData, Is.Not.Null, "The event should have been created.");
            Assert.That(message.HasSection(AmqpMessageSection.Header), "The message should have a header section.");
            Assert.That(message.Header.DeliveryCount, Is.EqualTo(sourceMessage.Header.DeliveryCount), "The delivery count should match.");
            Assert.That(message.Header.Durable, Is.EqualTo(sourceMessage.Header.Durable), "The durable flag should match.");
            Assert.That(message.Header.FirstAcquirer, Is.EqualTo(sourceMessage.Header.FirstAcquirer), "The first acquirer flag should match.");
            Assert.That(message.Header.Priority, Is.EqualTo(sourceMessage.Header.Priority), "The priority should match.");
            Assert.That(message.Header.TimeToLive.Value.TotalMilliseconds, Is.EqualTo(sourceMessage.Header.Ttl), "The time to live should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateEventFromMessage" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateEventFromMessagePopulatesTheProperties()
        {
            var body = new byte[] { 0x11, 0x22, 0x33 };
            using var sourceMessage = AmqpMessage.Create(new Data { Value = body });
            sourceMessage.Properties.AbsoluteExpiryTime = new DateTimeOffset(2015, 10, 27, 0, 0 ,0 ,0, TimeSpan.Zero).UtcDateTime;
            sourceMessage.Properties.ContentEncoding = "utf-8";
            sourceMessage.Properties.ContentType = "test/unit";
            sourceMessage.Properties.CorrelationId = "OU812";
            sourceMessage.Properties.CreationTime = new DateTimeOffset(2012, 3, 4, 8, 0, 0, 0, TimeSpan.Zero).UtcDateTime;
            sourceMessage.Properties.GroupId = "Red Squad";
            sourceMessage.Properties.GroupSequence = 76;
            sourceMessage.Properties.MessageId = "Bob";
            sourceMessage.Properties.ReplyTo = "1407 Graymalkin Lane";
            sourceMessage.Properties.ReplyToGroupId = "Home";
            sourceMessage.Properties.Subject = "You'll never believe this weight loss secret!";
            sourceMessage.Properties.To = "http://some.server.com";
            sourceMessage.Properties.UserId = new ArraySegment<byte>(new byte[] { 0x11, 0x22 });

            var converter = new AmqpMessageConverter();
            var eventData = converter.CreateEventFromMessage(sourceMessage);
            var message = eventData.GetRawAmqpMessage();

            Assert.That(eventData, Is.Not.Null, "The event should have been created.");
            Assert.That(message.HasSection(AmqpMessageSection.Properties), "The message should have a properties section.");
            Assert.That(message.Properties.AbsoluteExpiryTime.Value.UtcDateTime, Is.EqualTo(sourceMessage.Properties.AbsoluteExpiryTime), "The expiry time should match.");
            Assert.That(message.Properties.ContentEncoding, Is.EqualTo(sourceMessage.Properties.ContentEncoding.ToString()), "The content encoding should match.");
            Assert.That(message.Properties.ContentType, Is.EqualTo(sourceMessage.Properties.ContentType.ToString()), "The content type should match.");
            Assert.That(message.Properties.CorrelationId.ToString(), Is.EqualTo(sourceMessage.Properties.CorrelationId.ToString()), "The correlation identifier should match.");
            Assert.That(message.Properties.CreationTime.Value.UtcDateTime, Is.EqualTo(sourceMessage.Properties.CreationTime), "The creation time should match.");
            Assert.That(message.Properties.GroupId, Is.EqualTo(sourceMessage.Properties.GroupId), "The group identifier should match.");
            Assert.That(message.Properties.GroupSequence, Is.EqualTo(sourceMessage.Properties.GroupSequence), "The group sequence should match.");
            Assert.That(message.Properties.MessageId.ToString(), Is.EqualTo(sourceMessage.Properties.MessageId.ToString()), "The message identifier should match.");
            Assert.That(message.Properties.ReplyTo.ToString(), Is.EqualTo(sourceMessage.Properties.ReplyTo.ToString()), "The reply-to address should match.");
            Assert.That(message.Properties.ReplyToGroupId, Is.EqualTo(sourceMessage.Properties.ReplyToGroupId), "The reply-to group identifier should match.");
            Assert.That(message.Properties.Subject, Is.EqualTo(sourceMessage.Properties.Subject), "The subject should match.");
            Assert.That(message.Properties.To.ToString(), Is.EqualTo(sourceMessage.Properties.To.ToString()), "The to address should match.");
            Assert.That(message.Properties.UserId.Value.ToArray(), Is.EquivalentTo(sourceMessage.Properties.UserId.ToArray()), "The user identifier should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateEventFromMessage" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateEventFromMessagePopulatesDictionaryProperties()
        {
            var body = new byte[] { 0x11, 0x22, 0x33 };
            using var sourceMessage = AmqpMessage.Create(new Data { Value = body });

            // Delivery Annotations

            sourceMessage.DeliveryAnnotations.Map.Add("Three", 3);
            sourceMessage.DeliveryAnnotations.Map.Add("Four", "4");

            // Message Annotations

            sourceMessage.MessageAnnotations.Map.Add("Five", 5);
            sourceMessage.MessageAnnotations.Map.Add("Six", "6");

            // Footer

            sourceMessage.Footer.Map.Add("Seven", 7);
            sourceMessage.Footer.Map.Add("Eight", "8");

            var converter = new AmqpMessageConverter();
            var eventData = converter.CreateEventFromMessage(sourceMessage);
            var message = eventData.GetRawAmqpMessage();

            Assert.That(eventData, Is.Not.Null, "The event should have been created.");
            Assert.That(message.HasSection(AmqpMessageSection.MessageAnnotations), "The message should have a message annotations section.");
            Assert.That(message.HasSection(AmqpMessageSection.DeliveryAnnotations), "The message should have a delivery annotations section.");
            Assert.That(message.HasSection(AmqpMessageSection.Footer), "The message should have a footer section.");

            void validateMap(AmqpMap expected, IDictionary<string, object> dictionary, string mapName)
            {
                foreach (var item in expected)
                {
                    Assert.That(dictionary.TryGetValue(item.Key.ToString(), out object expectedValue), Is.True, $"The { mapName } section map did not contain: [{ item.Key }]");
                    Assert.That(item.Value, Is.EqualTo(expectedValue), $"The { mapName } section map property value did not match for: [{ item.Key }]");
                }
            }

            validateMap(sourceMessage.DeliveryAnnotations.Map, message.DeliveryAnnotations, nameof(sourceMessage.DeliveryAnnotations));
            validateMap(sourceMessage.MessageAnnotations.Map, message.MessageAnnotations, nameof(sourceMessage.MessageAnnotations));
            validateMap(sourceMessage.Footer.Map, message.Footer, nameof(sourceMessage.Footer));
        }

        [Test]
        public void CreateEventFromMessageAllowsAnEmptyMessageWithProperties()
        {
            var propertyValue = "1";

            using var message = AmqpMessage.Create();
            message.ApplicationProperties.Map.Add("Test", propertyValue);
            message.MessageAnnotations.Map.Add(AmqpProperty.Offset, propertyValue);

            var eventData = new AmqpMessageConverter().CreateEventFromMessage(message);
            Assert.That(eventData, Is.Not.Null, "The event should have been created.");
            Assert.That(eventData.Properties.Count, Is.EqualTo(message.ApplicationProperties.Map.Count()), "There should have been properties present.");
            Assert.That(eventData.Properties.First().Value, Is.EqualTo(propertyValue), "The application property should have been populated.");
            Assert.That(eventData.OffsetString, Is.EqualTo(propertyValue), "The offset should have been populated.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateEventFromMessage" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateEventFromMessageDoesNotPopulatePropertiesByDefault()
        {
            var body = new byte[] { 0x11, 0x22, 0x33 };
            using var message = AmqpMessage.Create(new Data { Value = body } );

            var converter = new AmqpMessageConverter();
            var eventData = converter.CreateEventFromMessage(message);

            Assert.That(eventData, Is.Not.Null, "The event should have been created.");
            Assert.That(eventData.GetRawAmqpMessage().HasSection(AmqpMessageSection.ApplicationProperties), Is.False, "The event should not have application properties by default.");
            Assert.That(GetEventDataSystemPropertiesBackingStore(eventData), Is.Null, "The event should have a null system properties dictionary.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateMessageFromEvent" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ASimpleEventCanBeTranslatedToItself()
        {
            var sourceEvent = new EventData(
                eventBody: new BinaryData(new byte[] { 0x11, 0x22, 0x33 }),
                properties: new Dictionary<string, object> { { "Test", 1234 } });

            var converter = new AmqpMessageConverter();
            using AmqpMessage message = converter.CreateMessageFromEvent(sourceEvent);
            EventData eventData = converter.CreateEventFromMessage(message);

            Assert.That(message, Is.Not.Null, "The AMQP message should have been created.");
            Assert.That(eventData, Is.Not.Null, "The translated event should have been created.");
            Assert.That(eventData.IsEquivalentTo(sourceEvent), "The translated event should match the source event.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateMessageFromEvent" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void AComplexEventCanBeTranslatedToItself()
        {
            var sourceMessage = new AmqpAnnotatedMessage(AmqpMessageBody.FromData(new ReadOnlyMemory<byte>[] { new byte[] { 0x11, 0x22, 0x33 } }));
            var sourceEvent = new EventData(sourceMessage);

            // Header

            sourceMessage.Header.DeliveryCount = 123;
            sourceMessage.Header.Durable = true;
            sourceMessage.Header.FirstAcquirer = true;
            sourceMessage.Header.Priority = 1;
            sourceMessage.Header.TimeToLive = TimeSpan.FromDays(2);

            // Properties

            sourceMessage.Properties.AbsoluteExpiryTime = new DateTimeOffset(2015, 10, 27, 0, 0 ,0 ,0, TimeSpan.Zero);
            sourceMessage.Properties.ContentEncoding = "utf-8";
            sourceMessage.Properties.ContentType = "test/unit";
            sourceMessage.Properties.CorrelationId = new AmqpMessageId("OU812");
            sourceMessage.Properties.CreationTime = new DateTimeOffset(2012, 3, 4, 8, 0, 0, 0, TimeSpan.Zero);
            sourceMessage.Properties.GroupId = "Red Squad";
            sourceMessage.Properties.GroupSequence = 76;
            sourceMessage.Properties.MessageId = new AmqpMessageId("Bob");
            sourceMessage.Properties.ReplyTo = new AmqpAddress("1407 Graymalkin Lane");
            sourceMessage.Properties.ReplyToGroupId = "Home";
            sourceMessage.Properties.Subject = "You'll never believe this weight loss secret!";
            sourceMessage.Properties.To = new AmqpAddress("http://some.server.com");
            sourceMessage.Properties.UserId = new byte[] { 0x11, 0x22 };

            // Application Properties

            sourceMessage.ApplicationProperties.Add("One", TimeSpan.FromMinutes(5));
            sourceMessage.ApplicationProperties.Add("Two", 2);

            // Delivery Annotations

            sourceMessage.DeliveryAnnotations.Add("Three", 3);
            sourceMessage.DeliveryAnnotations.Add("Four", new DateTimeOffset(2015, 10, 27, 0, 0, 0, TimeSpan.Zero));

            // Message Annotations

            sourceMessage.MessageAnnotations.Add("Five", 5);
            sourceMessage.MessageAnnotations.Add("Six", 6.0f);

            // Footer

            sourceMessage.Footer.Add("Seven", 7);
            sourceMessage.Footer.Add("Eight", "8");

            var converter = new AmqpMessageConverter();
            using var tempMessage = converter.CreateMessageFromEvent(sourceEvent);
            var convertedEvent = converter.CreateEventFromMessage(tempMessage);
            var convertedMessage = convertedEvent.GetRawAmqpMessage();

            Assert.That(tempMessage, Is.Not.Null, "The temporary AMQP message should have been created.");
            Assert.That(convertedEvent, Is.Not.Null, "The translated event should have been created.");
            Assert.That(convertedMessage.GetEventBody().ToArray(), Is.EquivalentTo(sourceMessage.GetEventBody().ToArray()), "The data body should match.");
            Assert.That(convertedMessage.ApplicationProperties, Is.EquivalentTo(sourceMessage.ApplicationProperties), "The application properties should match.");
            Assert.That(convertedMessage.DeliveryAnnotations, Is.EquivalentTo(sourceMessage.DeliveryAnnotations), "The delivery annotations should match.");
            Assert.That(convertedMessage.MessageAnnotations, Is.EquivalentTo(sourceMessage.MessageAnnotations), "The message annotations should match.");
            Assert.That(convertedMessage.Footer, Is.EquivalentTo(sourceMessage.Footer), "The footer should match.");

            // Header

            Assert.That(convertedMessage.Header.DeliveryCount, Is.EqualTo(sourceMessage.Header.DeliveryCount), "The delivery count should match.");
            Assert.That(convertedMessage.Header.Durable, Is.EqualTo(sourceMessage.Header.Durable), "The durable flag should match.");
            Assert.That(convertedMessage.Header.FirstAcquirer, Is.EqualTo(sourceMessage.Header.FirstAcquirer), "The first acquirer flag should match.");
            Assert.That(convertedMessage.Header.Priority, Is.EqualTo(sourceMessage.Header.Priority), "The priority should match.");
            Assert.That(convertedMessage.Header.TimeToLive, Is.EqualTo(sourceMessage.Header.TimeToLive), "The time to live should match.");

            // Properties

            Assert.That(convertedMessage.Properties.AbsoluteExpiryTime!.Value.UtcDateTime, Is.EqualTo(tempMessage.Properties.CreationTime + sourceMessage.Header.TimeToLive), "The expiry time should be based on creation time and TimeToLive.");
            Assert.That(convertedMessage.Properties.ContentEncoding, Is.EqualTo(sourceMessage.Properties.ContentEncoding), "The content encoding should match.");
            Assert.That(convertedMessage.Properties.ContentType, Is.EqualTo(sourceMessage.Properties.ContentType), "The content type should match.");
            Assert.That(convertedMessage.Properties.CorrelationId, Is.EqualTo(sourceMessage.Properties.CorrelationId), "The correlation identifier should match.");
            Assert.That(convertedMessage.Properties.CreationTime!.Value.UtcDateTime, Is.EqualTo(tempMessage.Properties.CreationTime), "The creation time should match the computed creation time.");
            Assert.That(convertedMessage.Properties.GroupId, Is.EqualTo(sourceMessage.Properties.GroupId), "The group identifier should match.");
            Assert.That(convertedMessage.Properties.GroupSequence, Is.EqualTo(sourceMessage.Properties.GroupSequence), "The group sequence should match.");
            Assert.That(convertedMessage.Properties.MessageId, Is.EqualTo(sourceMessage.Properties.MessageId), "The message identifier should match.");
            Assert.That(convertedMessage.Properties.ReplyTo, Is.EqualTo(sourceMessage.Properties.ReplyTo), "The reply-to address should match.");
            Assert.That(convertedMessage.Properties.ReplyToGroupId, Is.EqualTo(sourceMessage.Properties.ReplyToGroupId), "The reply-to group identifier should match.");
            Assert.That(convertedMessage.Properties.Subject, Is.EqualTo(sourceMessage.Properties.Subject), "The subject should match.");
            Assert.That(convertedMessage.Properties.To, Is.EqualTo(sourceMessage.Properties.To), "The to address should match.");
            Assert.That(convertedMessage.Properties.UserId.Value.ToArray(), Is.EquivalentTo(sourceMessage.Properties.UserId.Value.ToArray()), "The user identifier should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateMessageFromEvent" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void AnEventWithValueBodyCanBeTranslatedToItself()
        {
            var sourceValue = new Dictionary<string, string> { { "key", "value" } };
            var sourceMessage = new AmqpAnnotatedMessage(AmqpMessageBody.FromValue(sourceValue));
            var sourceEvent = new EventData(sourceMessage);

            var converter = new AmqpMessageConverter();
            using var tempMessage = converter.CreateMessageFromEvent(sourceEvent);
            var convertedEvent = converter.CreateEventFromMessage(tempMessage);
            var convertedMessage = convertedEvent.GetRawAmqpMessage();

            Assert.That(tempMessage, Is.Not.Null, "The temporary AMQP message should have been created.");
            Assert.That(convertedEvent, Is.Not.Null, "The translated event should have been created.");
            Assert.That(convertedMessage.Body.TryGetValue(out var convertedValue), Is.True, "The message should have a value body.");
            Assert.That(convertedValue, Is.EquivalentTo(sourceValue), "The value body should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateMessageFromEvent" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void AnEventWithSequenceBodyCanBeTranslatedToItself()
        {
            var sourceValue = new[] { new List<object> { "1", 2 } };
            var sourceMessage = new AmqpAnnotatedMessage(AmqpMessageBody.FromSequence(sourceValue));
            var sourceEvent = new EventData(sourceMessage);

            var converter = new AmqpMessageConverter();
            using var tempMessage = converter.CreateMessageFromEvent(sourceEvent);
            var convertedEvent = converter.CreateEventFromMessage(tempMessage);
            var convertedMessage = convertedEvent.GetRawAmqpMessage();

            Assert.That(tempMessage, Is.Not.Null, "The temporary AMQP message should have been created.");
            Assert.That(convertedEvent, Is.Not.Null, "The translated event should have been created.");
            Assert.That(convertedMessage.Body.TryGetSequence(out var convertedValue), Is.True, "The message should have a value body.");

            Assert.That(sourceValue.Count, Is.EqualTo(1), "The source sequence should have one embedded list.");
            Assert.That(convertedValue.Count, Is.EqualTo(1), "The converted sequence should have one embedded list.");
            Assert.That(convertedValue.First(), Is.EquivalentTo(sourceValue.First()), "The sequence embedded list should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateMessageFromEvent" />
        ///   method. Specifically, verifies that the TimeToLive property is respected when no AbsoluteExpiryTime is present.
        /// </summary>
        ///
        [Test]
        public void AnEventWithTimeToLiveCanBeTranslatedToItself()
        {
            var sourceValue = new Dictionary<string, string> { { "key", "value" } };
            var sourceMessage = new AmqpAnnotatedMessage(AmqpMessageBody.FromValue(sourceValue));
            sourceMessage.Header.TimeToLive = TimeSpan.FromDays(2);
            var sourceEvent = new EventData(sourceMessage);

            var converter = new AmqpMessageConverter();
            using var tempMessage = converter.CreateMessageFromEvent(sourceEvent);
            var convertedEvent = converter.CreateEventFromMessage(tempMessage);
            var convertedMessage = convertedEvent.GetRawAmqpMessage();

            Assert.That(tempMessage, Is.Not.Null, "The temporary AMQP message should have been created.");
            Assert.That(convertedEvent, Is.Not.Null, "The translated event should have been created.");
            Assert.That(convertedMessage.Body.TryGetValue(out var convertedValue), Is.True, "The message should have a value body.");
            Assert.That(convertedValue, Is.EquivalentTo(sourceValue), "The value body should match.");
            Assert.That(convertedMessage.Header.TimeToLive, Is.EqualTo(sourceMessage.Header.TimeToLive));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateEventHubPropertiesRequest" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CreateEventHubPropertiesRequestValidatesTheEventHub(string eventHubName)
        {
            ExactTypeConstraint typeConstraint = eventHubName is null ? Throws.ArgumentNullException : Throws.ArgumentException;

            var converter = new AmqpMessageConverter();
            Assert.That(() => converter.CreateEventHubPropertiesRequest(eventHubName, "dummy"), typeConstraint);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateEventHubPropertiesRequest" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CreateEventHubPropertiesRequestValidatesTheToken(string token)
        {
            ExactTypeConstraint typeConstraint = token is null ? Throws.ArgumentNullException : Throws.ArgumentException;

            var converter = new AmqpMessageConverter();
            Assert.That(() => converter.CreateEventHubPropertiesRequest("dummy", token), typeConstraint);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateEventHubPropertiesRequest" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateEventHubPropertiesRequestCreatesTheRequest()
        {
            var eventHubName = "dummyName";
            var token = "dummyToken";
            var converter = new AmqpMessageConverter();

            using AmqpMessage request = converter.CreateEventHubPropertiesRequest(eventHubName, token);
            Assert.That(request, Is.Not.Null, "The request should have been created");
            Assert.That(request.ApplicationProperties, Is.Not.Null, "The request should have properties");

            Assert.That(request.ApplicationProperties.Map.TryGetValue<string>(AmqpManagement.ResourceNameKey, out var resourceName), Is.True, "The resource name should be specified");
            Assert.That(resourceName, Is.EqualTo(eventHubName), "The resource name should match");

            Assert.That(request.ApplicationProperties.Map.TryGetValue<string>(AmqpManagement.SecurityTokenKey, out var securityToken), Is.True, "The security token should be specified");
            Assert.That(securityToken, Is.EqualTo(token), "The security token should match");

            Assert.That(request.ApplicationProperties.Map.TryGetValue<string>(AmqpManagement.OperationKey, out var operation), Is.True, "The operation should be specified");
            Assert.That(operation, Is.EqualTo(AmqpManagement.ReadOperationValue), "The operation should match");

            Assert.That(request.ApplicationProperties.Map.TryGetValue<string>(AmqpManagement.ResourceTypeKey, out var resourceScope), Is.True, "The resource scope be specified");
            Assert.That(resourceScope, Is.EqualTo(AmqpManagement.EventHubResourceTypeValue), "The resource scope should match");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateEventHubPropertiesFromResponse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateEventHubPropertiesFromResponseValidatesTheResponse()
        {
            var converter = new AmqpMessageConverter();
            Assert.That(() => converter.CreateEventHubPropertiesFromResponse(null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateEventHubPropertiesFromResponse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateEventHubPropertiesFromResponseValidatesTheResponseDataIsPresent()
        {
            var converter = new AmqpMessageConverter();

            using var response = AmqpMessage.Create();
            Assert.That(() => converter.CreateEventHubPropertiesFromResponse(response), Throws.InstanceOf<InvalidOperationException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateEventHubPropertiesFromResponse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateEventHubPropertiesFromResponseValidatesTheResponseDataType()
        {
            var converter = new AmqpMessageConverter();

            using var response = AmqpMessage.Create(new FramingData { Value = new ArraySegment<byte>(new byte[] { 0x11, 0x22 }) });
            Assert.That(() => converter.CreateEventHubPropertiesFromResponse(response), Throws.InstanceOf<InvalidOperationException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreateEventHubPropertiesFromResponse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreateEventHubPropertiesFromResponseCreatesTheProperties()
        {
            var name = "SomeName";
            var created = DateTimeOffset.Parse("2015-10-27T00:00:00z");
            var identifiers = new[] { "0", "1", "2" };
            var converter = new AmqpMessageConverter();
            var body = new AmqpMap
            {
                { AmqpManagement.ResponseMap.Name, name },
                { AmqpManagement.ResponseMap.CreatedAt, created.UtcDateTime },
                { AmqpManagement.ResponseMap.PartitionIdentifiers, identifiers }
            };

            using var response = AmqpMessage.Create(new AmqpValue { Value = body });
            EventHubProperties properties = converter.CreateEventHubPropertiesFromResponse(response);

            Assert.That(properties, Is.Not.Null, "The properties should have been created");
            Assert.That(properties.Name, Is.EqualTo(name), "The name should match");
            Assert.That(properties.CreatedOn, Is.EqualTo(created), "The created date should match");
            Assert.That(properties.PartitionIds, Is.EquivalentTo(identifiers), "The set of partition identifiers should match");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreatePartitionPropertiesRequest" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CreatePartitionPropertiesRequestValidatesTheEventHub(string eventHubName)
        {
            ExactTypeConstraint typeConstraint = eventHubName is null ? Throws.ArgumentNullException : Throws.ArgumentException;

            var converter = new AmqpMessageConverter();
            Assert.That(() => converter.CreatePartitionPropertiesRequest(eventHubName, "0", "dummy"), typeConstraint);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreatePartitionPropertiesRequest" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CreatePartitionPropertiesRequestValidatesThePartition(string partition)
        {
            ExactTypeConstraint typeConstraint = partition is null ? Throws.ArgumentNullException : Throws.ArgumentException;

            var converter = new AmqpMessageConverter();
            Assert.That(() => converter.CreatePartitionPropertiesRequest("someHub", partition, "dummy"), typeConstraint);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreatePartitionPropertiesRequest" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CreatePartitionPropertiesRequestValidatesTheToken(string token)
        {
            ExactTypeConstraint typeConstraint = token is null ? Throws.ArgumentNullException : Throws.ArgumentException;

            var converter = new AmqpMessageConverter();
            Assert.That(() => converter.CreatePartitionPropertiesRequest("someHub", "0", token), typeConstraint);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreatePartitionPropertiesRequest" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreatePartitionPropertiesRequestRequestCreatesTheRequest()
        {
            var eventHubName = "dummyName";
            var partition = "2";
            var token = "dummyToken";
            var converter = new AmqpMessageConverter();

            using AmqpMessage request = converter.CreatePartitionPropertiesRequest(eventHubName, partition, token);
            Assert.That(request, Is.Not.Null, "The request should have been created");
            Assert.That(request.ApplicationProperties, Is.Not.Null, "The request should have properties");

            Assert.That(request.ApplicationProperties.Map.TryGetValue<string>(AmqpManagement.ResourceNameKey, out var resourceName), Is.True, "The resource name should be specified");
            Assert.That(resourceName, Is.EqualTo(eventHubName), "The resource name should match");

            Assert.That(request.ApplicationProperties.Map.TryGetValue<string>(AmqpManagement.PartitionNameKey, out var partitionId), Is.True, "The resource name should be specified");
            Assert.That(partitionId, Is.EqualTo(partition), "The partition should match");

            Assert.That(request.ApplicationProperties.Map.TryGetValue<string>(AmqpManagement.SecurityTokenKey, out var securityToken), Is.True, "The security token should be specified");
            Assert.That(securityToken, Is.EqualTo(token), "The security token should match");

            Assert.That(request.ApplicationProperties.Map.TryGetValue<string>(AmqpManagement.OperationKey, out var operation), Is.True, "The operation should be specified");
            Assert.That(operation, Is.EqualTo(AmqpManagement.ReadOperationValue), "The operation should match");

            Assert.That(request.ApplicationProperties.Map.TryGetValue<string>(AmqpManagement.ResourceTypeKey, out var resourceScope), Is.True, "The resource scope be specified");
            Assert.That(resourceScope, Is.EqualTo(AmqpManagement.PartitionResourceTypeValue), "The resource scope should match");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreatePartitionPropertiesFromResponse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreatePartitionPropertiesFromResponseValidatesTheResponse()
        {
            var converter = new AmqpMessageConverter();
            Assert.That(() => converter.CreatePartitionPropertiesFromResponse(null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreatePartitionPropertiesFromResponse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreatePartitionPropertiesFromResponseValidatesTheResponseDataIsPresent()
        {
            var converter = new AmqpMessageConverter();

            using var response = AmqpMessage.Create();
            Assert.That(() => converter.CreatePartitionPropertiesFromResponse(response), Throws.InstanceOf<InvalidOperationException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreatePartitionPropertiesFromResponse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreatePartitionPropertiesFromResponseValidatesTheResponseDataType()
        {
            var converter = new AmqpMessageConverter();

            using var response = AmqpMessage.Create(new FramingData { Value = new ArraySegment<byte>(new byte[] { 0x11, 0x22 }) });
            Assert.That(() => converter.CreatePartitionPropertiesFromResponse(response), Throws.InstanceOf<InvalidOperationException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.CreatePartitionPropertiesFromResponse" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CreatePartitionPropertiesFromResponseCreatesTheProperties()
        {
            var name = "SomeName";
            var partition = "55";
            var beginSequenceNumber = 555L;
            var lastSequenceNumber = 666L;
            var lastOffset = "777L";
            var lastEnqueueTime = DateTimeOffset.Parse("2015-10-27T00:00:00z");
            var isEmpty = false;
            var converter = new AmqpMessageConverter();
            var body = new AmqpMap
            {
                { AmqpManagement.ResponseMap.Name, name },
                { AmqpManagement.ResponseMap.PartitionIdentifier, partition },
                { AmqpManagement.ResponseMap.PartitionBeginSequenceNumber, beginSequenceNumber },
                { AmqpManagement.ResponseMap.PartitionLastEnqueuedSequenceNumber, lastSequenceNumber },
                { AmqpManagement.ResponseMap.PartitionLastEnqueuedOffset, lastOffset },
                { AmqpManagement.ResponseMap.PartitionLastEnqueuedTimeUtc, lastEnqueueTime.UtcDateTime },
                { AmqpManagement.ResponseMap.PartitionRuntimeInfoPartitionIsEmpty, isEmpty }
            };

            using var response = AmqpMessage.Create(new AmqpValue { Value = body });
            PartitionProperties properties = converter.CreatePartitionPropertiesFromResponse(response);

            Assert.That(properties, Is.Not.Null, "The properties should have been created");
            Assert.That(properties.EventHubName, Is.EqualTo(name), "The name should match");
            Assert.That(properties.Id, Is.EqualTo(partition), "The partition should match");
            Assert.That(properties.BeginningSequenceNumber, Is.EqualTo(beginSequenceNumber), "The beginning sequence number should match");
            Assert.That(properties.LastEnqueuedSequenceNumber, Is.EqualTo(lastSequenceNumber), "The last sequence number should match");
            Assert.That(properties.LastEnqueuedOffsetString, Is.EqualTo(lastOffset), "The offset should match");
            Assert.That(properties.LastEnqueuedTime, Is.EqualTo(lastEnqueueTime), "The last enqueued time should match");
            Assert.That(properties.IsEmpty, Is.EqualTo(isEmpty), "The empty flag should match");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.ApplyPublisherPropertiesToAmqpMessage" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(PublisherPropertyTestCases))]
        public void ApplyPublisherPropertiesToAmqpMessageUpdatesTheMessage(int? sequenceNumber,
                                                                          long? groupId,
                                                                          short? ownerLevel)
        {
            var converter = new AmqpMessageConverter();

            // Create an event and ensure that there are no pending publisher properties that would
            // interfere with tests.

            var eventData = new EventData(new BinaryData(new byte[] { 0x11, 0x22, 0x33 }));

            Assert.That(eventData.PendingPublishSequenceNumber, Is.Null, "There should not be a pending sequence number on the event.");
            Assert.That(eventData.PendingProducerGroupId, Is.Null, "There should not be a pending group id on the event.");
            Assert.That(eventData.PendingProducerOwnerLevel, Is.Null, "There should not be a pending owner level on the event.");

            // Translate the event to an AMQP message and ensure that it is in a valid form.

            using AmqpMessage message = converter.CreateMessageFromEvent(eventData);

            Assert.That(message, Is.Not.Null, "The AMQP message should have been created.");
            Assert.That(message.DataBody, Is.Not.Null, "The AMQP message should a body.");
            Assert.That(message.MessageAnnotations, Is.Not.Null, "The AMQP message annotations should be present.");
            Assert.That(message.MessageAnnotations.Map.Any(item => item.Key.ToString() == AmqpProperty.ProducerSequenceNumber.Value), Is.False, "The publishing sequence number should not have been set.");
            Assert.That(message.MessageAnnotations.Map.Any(item => item.Key.ToString() == AmqpProperty.ProducerGroupId.Value), Is.False, "The producer group should not have been set.");
            Assert.That(message.MessageAnnotations.Map.Any(item => item.Key.ToString() == AmqpProperty.ProducerOwnerLevel.Value), Is.False, "The producer owner level should not have been set.");

            // Apply the set of publisher properties and validate the outcome.

            converter.ApplyPublisherPropertiesToAmqpMessage(message,sequenceNumber, groupId, ownerLevel);

            if (sequenceNumber.HasValue)
            {
                Assert.That(message.MessageAnnotations.Map[AmqpProperty.ProducerSequenceNumber], Is.EqualTo(sequenceNumber.Value), "The publishing sequence number should have been set.");
            }
            else
            {
                Assert.That(message.MessageAnnotations.Map.Any(item => item.Key.ToString() == AmqpProperty.ProducerSequenceNumber.Value), Is.False, "The publishing sequence number should not have been set.");
            }

            if (groupId.HasValue)
            {
                Assert.That(message.MessageAnnotations.Map[AmqpProperty.ProducerGroupId], Is.EqualTo(groupId.Value), "The producer group should have been set.");
            }
            else
            {
                Assert.That(message.MessageAnnotations.Map.Any(item => item.Key.ToString() == AmqpProperty.ProducerGroupId.Value), Is.False, "The producer group should not have been set.");
            }

            if (ownerLevel.HasValue)
            {
                Assert.That(message.MessageAnnotations.Map[AmqpProperty.ProducerOwnerLevel], Is.EqualTo(ownerLevel.Value), "The producer owner level should have been set.");
            }
            else
            {
                Assert.That(message.MessageAnnotations.Map.Any(item => item.Key.ToString() == AmqpProperty.ProducerOwnerLevel.Value), Is.False, "The producer owner level should not have been set.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpMessageConverter.ApplyPublisherPropertiesToAmqpMessage" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void RemovePublishingPropertiesFromAmqpMessageUpdatesTheMessage()
        {
            var converter = new AmqpMessageConverter();
            var eventData = new EventData(new BinaryData(new byte[] { 0x11, 0x22, 0x33 }));

            // Create a message and apply publishing properties.

            using AmqpMessage message = converter.CreateMessageFromEvent(eventData);
            converter.ApplyPublisherPropertiesToAmqpMessage(message, 77, 92, 4);

            Assert.That(message.MessageAnnotations.Map.Any(item => item.Key.ToString() == AmqpProperty.ProducerSequenceNumber.Value), Is.True, "The publishing sequence number should have been set.");
            Assert.That(message.MessageAnnotations.Map.Any(item => item.Key.ToString() == AmqpProperty.ProducerGroupId.Value), Is.True, "The producer group should have been set.");
            Assert.That(message.MessageAnnotations.Map.Any(item => item.Key.ToString() == AmqpProperty.ProducerOwnerLevel.Value), Is.True, "The producer owner level should have been set.");

            // Remove the publishing properties and verify.

            converter.RemovePublishingPropertiesFromAmqpMessage(message);

            Assert.That(message.MessageAnnotations.Map.Any(item => item.Key.ToString() == AmqpProperty.ProducerSequenceNumber.Value), Is.False, "The publishing sequence number should not be set.");
            Assert.That(message.MessageAnnotations.Map.Any(item => item.Key.ToString() == AmqpProperty.ProducerGroupId.Value), Is.False, "The producer group should not be set.");
            Assert.That(message.MessageAnnotations.Map.Any(item => item.Key.ToString() == AmqpProperty.ProducerOwnerLevel.Value), Is.False, "The producer owner level should not be set.");
        }

        /// <summary>
        ///   Retrieves the backing store for the System Properties dictionary from the Event Data
        ///   type, using its private field.
        /// </summary>
        ///
        /// <param name="eventData">The instance to read the field from.</param>
        ///
        /// <returns>The backing store for the <see cref="EventData.SystemProperties" /> set.</returns>
        ///
        private static IReadOnlyDictionary<string, object> GetEventDataSystemPropertiesBackingStore(EventData eventData) =>
            (IReadOnlyDictionary<string, object>)
                typeof(EventData)
                    .GetField("_systemProperties", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(eventData);
    }
}
