// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using Azure.Core.Amqp;
using Azure.Messaging.EventHubs.Amqp;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="AmqpAnnotatedMessageExtensions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class AmqpAnnotatedMessageExtensionsTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpAnnotatedMessageExtensions.Clone" />
        ///   method.
        /// </summary>
        [Test]
        public void CloneKnowsAllMembersOfAmqpAnnotatedMessage()
        {
            // This approach is inelegant and brute force, but allows us to detect
            // additional members added to the annotated message that we're not currently
            // cloning and avoid drift, since Azure.Core.Amqp is an external dependency.

            var knownMembers = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "Header",
                "Properties",
                "Footer",
                "DeliveryAnnotations",
                "MessageAnnotations",
                "ApplicationProperties"
            };

            var getterSetterProperties = typeof(AmqpAnnotatedMessage)
                .GetProperties(BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.SetProperty);

            foreach (var property in getterSetterProperties)
            {
                Assert.That(knownMembers.Contains(property.Name), $"The property: { property.Name } of AmqpAnnotatedMessage is not being cloned.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpAnnotatedMessageExtensions.Clone" />
        ///   method.
        /// </summary>
        [Test]
        public void CloneKnowsAllMembersOfAmqpMessageHeader()
        {
            // This approach is inelegant and brute force, but allows us to detect
            // additional members added to the annotated message that we're not currently
            // cloning and avoid drift, since Azure.Core.Amqp is an external dependency.

            var knownMembers = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "DeliveryCount",
                "Durable",
                "FirstAcquirer",
                "Priority",
                "TimeToLive"
            };

            var getterSetterProperties = typeof(AmqpMessageHeader)
                .GetProperties(BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.SetProperty);

            foreach (var property in getterSetterProperties)
            {
                Assert.That(knownMembers.Contains(property.Name), $"The property: { property.Name } of AmqpMessageHeader is not being cloned.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpAnnotatedMessageExtensions.Clone" />
        ///   method.
        /// </summary>
        [Test]
        public void CloneKnowsAllMembersOfAmqpMessageProperties()
        {
            // This approach is inelegant and brute force, but allows us to detect
            // additional members added to the annotated message that we're not currently
            // cloning and avoid drift, since Azure.Core.Amqp is an external dependency.

            var knownMembers = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "AbsoluteExpiryTime",
                "ContentEncoding",
                "ContentType",
                "CorrelationId",
                "CreationTime",
                "GroupId",
                "GroupSequence",
                "MessageId",
                "ReplyTo",
                "ReplyToGroupId",
                "Subject",
                "To",
                "UserId"
            };

            var getterSetterProperties = typeof(AmqpMessageProperties)
                .GetProperties(BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.SetProperty);

            foreach (var property in getterSetterProperties)
            {
                Assert.That(knownMembers.Contains(property.Name), $"The property: { property.Name } of AmqpMessageProperties is not being cloned.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpAnnotatedMessageExtensions.Clone" />
        ///   method.
        /// </summary>
        [Test]
        public void CloneCopiesTheFullMessage()
        {
            var source = CreateFullyPopulatedDataBodyMessage();
            var clone = source.Clone();

            // Body

            Assert.That(ReferenceEquals(clone.Body, source.Body), Is.False, "The message body should not be the same instance.");
            Assert.That(source.Body.TryGetData(out var sourceBody), Is.True, "The source should have a data body.");
            Assert.That(clone.Body.TryGetData(out var cloneBody), Is.True, "The clone should have a data body.");
            Assert.That(cloneBody, Is.EquivalentTo(sourceBody), "The body data should match.");

            // Header

            Assert.That(ReferenceEquals(clone.Header, source.Header), Is.False, "The message header should not be the same instance.");
            Assert.That(clone.Header, Is.Not.Null, "The message header should not be null.");

            foreach (var headerProperty in typeof(AmqpMessageHeader).GetProperties(BindingFlags.Public | BindingFlags.GetProperty))
            {
                Assert.That(headerProperty.GetValue(clone), Is.EqualTo(headerProperty.GetValue(source)), $"The header property: { headerProperty.Name } should match.");
            }

            // Properties

            Assert.That(ReferenceEquals(clone.Properties, source.Properties), Is.False, "The message properties should not be the same instance.");
            Assert.That(clone.Properties, Is.Not.Null, "The message properties should not be null.");

            foreach (var propertiesProperty in typeof(AmqpMessageProperties).GetProperties(BindingFlags.Public | BindingFlags.GetProperty))
            {
                Assert.That(propertiesProperty.GetValue(clone), Is.EqualTo(propertiesProperty.GetValue(source)), $"The message property: { propertiesProperty.Name } should match.");
            }

            // Footer

            Assert.That(ReferenceEquals(clone.Footer, source.Footer), Is.False, "The message footer should not be the same instance.");
            Assert.That(clone.Footer, Is.Not.Null, "The message footer should not be null.");
            Assert.That(clone.Footer, Is.EquivalentTo(source.Footer), "The message footer items should match.");

            // Delivery Annotations

            Assert.That(ReferenceEquals(clone.DeliveryAnnotations, source.DeliveryAnnotations), Is.False, "The message delivery annotations should not be the same instance.");
            Assert.That(clone.DeliveryAnnotations, Is.Not.Null, "The message delivery annotations should not be null.");
            Assert.That(clone.DeliveryAnnotations, Is.EquivalentTo(source.DeliveryAnnotations), "The message delivery annotation items should match.");

            // Message Annotations

            Assert.That(ReferenceEquals(clone.MessageAnnotations, source.MessageAnnotations), Is.False, "The message annotations should not be the same instance.");
            Assert.That(clone.MessageAnnotations, Is.Not.Null, "The message annotations should not be null.");
            Assert.That(clone.MessageAnnotations, Is.EquivalentTo(source.MessageAnnotations), "The message annotations items should match.");

            // ApplicationProperties

            Assert.That(ReferenceEquals(clone.ApplicationProperties, source.ApplicationProperties), Is.False, "The application properties should not be the same instance.");
            Assert.That(clone.ApplicationProperties, Is.Not.Null, "The application properties should not be null.");
            Assert.That(clone.ApplicationProperties, Is.EquivalentTo(source.ApplicationProperties), "The application property items should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpAnnotatedMessageExtensions.Clone" />
        ///   method.
        /// </summary>
        [Test]
        public void CloneDoesNotForceAllocationOfUnpopulatedSections()
        {
            var firstBody = new List<object> { 1, 2, 3 };
            var secondBody = new List<object> { 4, 5, 6 };
            var body = AmqpMessageBody.FromSequence(new[] { firstBody, secondBody });
            var source = new AmqpAnnotatedMessage(body);
            var clone = source.Clone();

            // Body

            Assert.That(ReferenceEquals(clone.Body, source.Body), Is.False, "The message body should not be the same instance.");
            Assert.That(source.Body.TryGetSequence(out var sourceBody), Is.True, "The source should have a sequence body.");
            Assert.That(clone.Body.TryGetSequence(out var cloneBody), Is.True, "The clone should have a sequence body.");
            Assert.That(cloneBody, Is.EquivalentTo(sourceBody), "The body data should match.");

            // Other sections

            Assert.That(clone.HasSection(AmqpMessageSection.Body), Is.True, "The body should be populated.");
            Assert.That(clone.HasSection(AmqpMessageSection.Header), Is.False, "The header should not be populated.");
            Assert.That(clone.HasSection(AmqpMessageSection.Properties), Is.False, "The properties should not be populated.");
            Assert.That(clone.HasSection(AmqpMessageSection.Footer), Is.False, "The footer should be populated.");
            Assert.That(clone.HasSection(AmqpMessageSection.DeliveryAnnotations), Is.False, "The delivery annotations should not be populated.");
            Assert.That(clone.HasSection(AmqpMessageSection.MessageAnnotations), Is.False, "The message annotations should not be populated.");
            Assert.That(clone.HasSection(AmqpMessageSection.ApplicationProperties), Is.False, "The application properties should not be populated.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpAnnotatedMessageExtensions.Clone" />
        ///   method.
        /// </summary>
        [Test]
        public void CloneAllocatesWhenSectionsArePopulated()
        {
            var body = AmqpMessageBody.FromValue("this is an awesome value!");
            var source = new AmqpAnnotatedMessage(body);
            source.Footer.Add("footOne", "1111");
            source.ApplicationProperties.Add("appProp", "1111");

            var clone = source.Clone();

            // Body

            Assert.That(ReferenceEquals(clone.Body, source.Body), Is.False, "The message body should not be the same instance.");
            Assert.That(source.Body.TryGetValue(out var sourceBody), Is.True, "The source should have a value body.");
            Assert.That(clone.Body.TryGetValue(out var cloneBody), Is.True, "The clone should have a value body.");
            Assert.That(cloneBody, Is.EqualTo(sourceBody), "The body data should match.");

            // Other sections

            Assert.That(clone.HasSection(AmqpMessageSection.Body), Is.True, "The body should be populated.");
            Assert.That(clone.HasSection(AmqpMessageSection.Footer), Is.True, "The footer should be populated.");
            Assert.That(clone.HasSection(AmqpMessageSection.ApplicationProperties), Is.True, "The application properties should be populated.");

            Assert.That(clone.HasSection(AmqpMessageSection.Header), Is.False, "The header should not be populated.");
            Assert.That(clone.HasSection(AmqpMessageSection.Properties), Is.False, "The properties should not be populated.");
            Assert.That(clone.HasSection(AmqpMessageSection.DeliveryAnnotations), Is.False, "The delivery annotations should not be populated.");
            Assert.That(clone.HasSection(AmqpMessageSection.MessageAnnotations), Is.False, "The message annotations should not be populated.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpAnnotatedMessageExtensions.Clone" />
        ///   method.
        /// </summary>
        [Test]
        public void CloneWorksWithNull() =>
            Assert.That(AmqpAnnotatedMessageExtensions.Clone(null), Is.Null);

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpAnnotatedMessageExtensions.GetEventBody" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetEventBodyRetrievesTheDataBody()
        {
            var payload = new byte[] { 0x10, 0x20, 0x30 };
            var body = AmqpMessageBody.FromData(new ReadOnlyMemory<byte>[1] { payload });
            var message = new AmqpAnnotatedMessage(body);
            var eventBody = message.GetEventBody();

            Assert.That(eventBody, Is.Not.Null, "The event body should be populated.");
            Assert.That(eventBody.ToArray(), Is.EquivalentTo(payload), "The event body should match the original payload.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpAnnotatedMessageExtensions.GetEventBody" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(AmqpMessageBodyType.Sequence)]
        [TestCase(AmqpMessageBodyType.Value)]
        public void GetEventBodyDoesNotAllowNonDataBodyTypes(AmqpMessageBodyType bodyType)
        {
            var body = bodyType switch
            {
                AmqpMessageBodyType.Sequence => AmqpMessageBody.FromSequence(new[] { new List<object> { 1, 2, 3 } }),
                AmqpMessageBodyType.Value => AmqpMessageBody.FromValue("This is a value"),
                _ => throw new ArgumentException($"Unsupported body type { bodyType }", nameof(bodyType))
            };

            var message = new AmqpAnnotatedMessage(body);
            Assert.That(() => message.GetEventBody(), Throws.InstanceOf<NotSupportedException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpAnnotatedMessageExtensions" />
        ///   methods related to reading system-owned properties.
        /// </summary>
        ///
        [Test]
        public void SystemPropertiesCanBeRead()
        {
            var sequenceNumber = 123L;
            var offset = "456L";
            var enqueueTime = new DateTimeOffset(2015, 10, 27, 00, 00, 00, TimeSpan.Zero);
            var partitionKey = "fake-key";
            var lastSequence = 321L;
            var lastOffset = "654L";
            var lastEnqueue = new DateTimeOffset(2012, 03, 04, 08, 00, 00, TimeSpan.Zero);
            var lastRetrieve = new DateTimeOffset(2020, 01, 01, 05, 15, 37, TimeSpan.Zero);
            var message = CreateDataBodyMessageWithSystemProperties(sequenceNumber, lastSequence, offset, lastOffset, partitionKey, enqueueTime, lastEnqueue, lastRetrieve);

            Assert.That(message.GetSequenceNumber(), Is.EqualTo(sequenceNumber), "The sequence number should match.");
            Assert.That(message.GetOffset(), Is.EqualTo(offset), "The offset should match.");
            Assert.That(message.GetEnqueuedTime(), Is.EqualTo(enqueueTime), "The enqueue time should match.");
            Assert.That(message.GetPartitionKey(), Is.EqualTo(partitionKey), "The partition key should match.");
            Assert.That(message.GetLastPartitionSequenceNumber(), Is.EqualTo(lastSequence), "The last sequence number should match.");
            Assert.That(message.GetLastPartitionOffset(), Is.EqualTo(lastOffset), "The last offset should match.");
            Assert.That(message.GetLastPartitionEnqueuedTime(), Is.EqualTo(lastEnqueue), "The last enqueue time should match.");
            Assert.That(message.GetLastPartitionPropertiesRetrievalTime(), Is.EqualTo(lastRetrieve), "The last retrieve time should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpAnnotatedMessageExtensions" />
        ///   methods related to reading system-owned properties.
        /// </summary>
        ///
        [Test]
        public void MessageIsPopulatedFromEventHubProperties()
        {
            var properties = new Dictionary<string, object>
            {
                { "Test", 1 },
                { "Second", "2" },
                { "Third", TimeSpan.FromSeconds(99) }
            };

            var sequenceNumber = 123L;
            var offset = "456L";
            var enqueueTime = new DateTimeOffset(2015, 10, 27, 00, 00, 00, TimeSpan.Zero);
            var partitionKey = "fake-key";
            var lastSequence = 321L;
            var lastOffset = "654L";
            var lastEnqueue = new DateTimeOffset(2012, 03, 04, 08, 00, 00, TimeSpan.Zero);
            var lastRetrieve = new DateTimeOffset(2020, 01, 01, 05, 15, 37, TimeSpan.Zero);

            var message = new AmqpAnnotatedMessage(AmqpMessageBody.FromData(new[] { (ReadOnlyMemory<byte>)Array.Empty<byte>() }));
            message.PopulateFromEventProperties(properties, sequenceNumber, offset, enqueueTime, partitionKey, lastSequence, lastOffset, lastEnqueue, lastRetrieve);

            Assert.That(message.ApplicationProperties, Is.EquivalentTo(properties), "The application properties should match.");
            Assert.That(message.GetSequenceNumber(), Is.EqualTo(sequenceNumber), "The sequence number should match.");
            Assert.That(message.GetOffset(), Is.EqualTo(offset), "The offset should match.");
            Assert.That(message.GetEnqueuedTime(), Is.EqualTo(enqueueTime), "The enqueue time should match.");
            Assert.That(message.GetPartitionKey(), Is.EqualTo(partitionKey), "The partition key should match.");
            Assert.That(message.GetLastPartitionSequenceNumber(), Is.EqualTo(lastSequence), "The last sequence number should match.");
            Assert.That(message.GetLastPartitionOffset(), Is.EqualTo(lastOffset), "The last offset should match.");
            Assert.That(message.GetLastPartitionEnqueuedTime(), Is.EqualTo(lastEnqueue), "The last enqueue time should match.");
            Assert.That(message.GetLastPartitionPropertiesRetrievalTime(), Is.EqualTo(lastRetrieve), "The last retrieve time should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpAnnotatedMessageExtensions" />
        ///   methods related to reading system-owned properties.
        /// </summary>
        ///
        [Test]
        public void SystemPropertiesReturnCustomDefaultValuesWhenNotInTheMessage()
        {
            var sequenceNumber = 123L;
            var offset = "456L";
            var enqueueTime = new DateTimeOffset(2015, 10, 27, 00, 00, 00, TimeSpan.Zero);
            var partitionKey = "fake-key";
            var lastSequence = 321L;
            var lastOffset = "654L";
            var lastEnqueue = new DateTimeOffset(2012, 03, 04, 08, 00, 00, TimeSpan.Zero);
            var lastRetrieve = new DateTimeOffset(2020, 01, 01, 05, 15, 37, TimeSpan.Zero);
            var message = CreateDataBodyMessageWithSystemProperties(default, default, default, default, default, default, default, default);

            Assert.That(message.GetSequenceNumber(sequenceNumber), Is.EqualTo(sequenceNumber), "The sequence number should match.");
            Assert.That(message.GetOffset(offset), Is.EqualTo(offset), "The offset should match.");
            Assert.That(message.GetEnqueuedTime(enqueueTime), Is.EqualTo(enqueueTime), "The enqueue time should match.");
            Assert.That(message.GetPartitionKey(partitionKey), Is.EqualTo(partitionKey), "The partition key should match.");
            Assert.That(message.GetLastPartitionSequenceNumber(lastSequence), Is.EqualTo(lastSequence), "The last sequence number should match.");
            Assert.That(message.GetLastPartitionOffset(lastOffset), Is.EqualTo(lastOffset), "The last offset should match.");
            Assert.That(message.GetLastPartitionEnqueuedTime(lastEnqueue), Is.EqualTo(lastEnqueue), "The last enqueue time should match.");
            Assert.That(message.GetLastPartitionPropertiesRetrievalTime(lastRetrieve), Is.EqualTo(lastRetrieve), "The last retrieve time should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpAnnotatedMessageExtensions" />
        ///   methods related to reading system-owned properties.
        /// </summary>
        ///
        [Test]
        public void SystemPropertiesReturnExpectedDefaultValuesWhenNotInTheMessageAndNoCustom()
        {
            var message = CreateDataBodyMessageWithSystemProperties(default, default, default, default, default, default, default, default);

            Assert.That(message.GetSequenceNumber(), Is.EqualTo(long.MinValue), "The sequence number should match.");
            Assert.That(message.GetOffset(), Is.EqualTo(null), "The offset should match.");
            Assert.That(message.GetEnqueuedTime(), Is.EqualTo(default(DateTimeOffset)), "The enqueue time should match.");
            Assert.That(message.GetPartitionKey(), Is.EqualTo(null), "The partition key should match.");
            Assert.That(message.GetLastPartitionSequenceNumber(), Is.EqualTo(null), "The last sequence number should match.");
            Assert.That(message.GetLastPartitionOffset(), Is.EqualTo(null), "The last offset should match.");
            Assert.That(message.GetLastPartitionEnqueuedTime(), Is.EqualTo(null), "The last enqueue time should match.");
            Assert.That(message.GetLastPartitionPropertiesRetrievalTime(), Is.EqualTo(null), "The last retrieve time should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpAnnotatedMessageExtensions" />
        ///   methods related to the partition key.
        /// </summary>
        ///
        [Test]
        public void PartitionKeyCanBeSet()
        {
            var partitionKey = "fake-key";
            var message = CreateFullyPopulatedDataBodyMessage();

            Assert.That(message.GetPartitionKey(), Is.Not.EqualTo(partitionKey), "The starting partition key should differ from the value being set.");

            message.SetPartitionKey(partitionKey);
            Assert.That(message.GetPartitionKey(), Is.EqualTo(partitionKey), "The partition key should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpAnnotatedMessageExtensions" />
        ///   methods related to the enqueue time.
        /// </summary>
        ///
        [Test]
        public void EnqueueTimeCanBeSet()
        {
            var enqueueTime = new DateTimeOffset(2015, 10, 27, 00, 00, 00, TimeSpan.Zero);
            var message = CreateFullyPopulatedDataBodyMessage();

            Assert.That(message.GetEnqueuedTime(), Is.Not.EqualTo(enqueueTime), "The starting enqueue time should differ from the value being set.");

            message.SetEnqueuedTime(enqueueTime);
            Assert.That(message.GetEnqueuedTime(), Is.EqualTo(enqueueTime), "The enqueue time should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpAnnotatedMessageExtensions.GetMessageAnnotationNormalizedValue" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetMessageAnnotationNormalizedValueReturnsNullWhenNoAnnotations()
        {
            var message = new AmqpAnnotatedMessage(AmqpMessageBody.FromData([ReadOnlyMemory<byte>.Empty]));
            var value = message.GetMessageAnnotationNormalizedValue("anyKey");
            Assert.That(value, Is.Null, "A missing annotation section should return null.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpAnnotatedMessageExtensions.GetMessageAnnotationNormalizedValue" />
        ///   method for enqueued time normalization.
        /// </summary>
        ///
        [Test]
        public void GetMessageAnnotationNormalizedValueNormalizesEnqueuedTime()
        {
            var key = AmqpProperty.EnqueuedTime.ToString();
            var expected = new DateTimeOffset(2024, 5, 19, 12, 0, 0, TimeSpan.Zero);
            var message = new AmqpAnnotatedMessage(AmqpMessageBody.FromData([ReadOnlyMemory<byte>.Empty]));
            message.MessageAnnotations.Add(key, expected.UtcDateTime);

            var value = message.GetMessageAnnotationNormalizedValue(key);
            Assert.That(value, Is.EqualTo(expected), "The enqueued time should be normalized to DateTimeOffset.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpAnnotatedMessageExtensions.GetMessageAnnotationNormalizedValue" />
        ///   method for sequence number normalization.
        /// </summary>
        ///
        [Test]
        [TestCase(42, 42L)]
        [TestCase(12345L, 12345L)]
        [TestCase("12345", 12345L)]
        public void GetMessageAnnotationNormalizedValueNormalizesSequenceNumber(object input,
                                                                                long expected)
        {
            var key = AmqpProperty.SequenceNumber.ToString();
            var message = new AmqpAnnotatedMessage(AmqpMessageBody.FromData([ReadOnlyMemory<byte>.Empty]));
            message.MessageAnnotations.Add(key, input);

            var value = message.GetMessageAnnotationNormalizedValue(key);
            Assert.That(value, Is.EqualTo(expected), "The sequence number should be normalized to long.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpAnnotatedMessageExtensions.GetMessageAnnotationNormalizedValue" />
        ///   method for AmqpMessageId normalization.
        /// </summary>
        ///
        [Test]
        public void GetMessageAnnotationNormalizedValueNormalizesAmqpMessageId()
        {
            var key = "customId";
            var id = new AmqpMessageId("id-123");
            var message = new AmqpAnnotatedMessage(AmqpMessageBody.FromData([ReadOnlyMemory<byte>.Empty]));
            message.MessageAnnotations.Add(key, id);

            var value = message.GetMessageAnnotationNormalizedValue(key);
            Assert.That(value, Is.EqualTo(id.ToString()), "The AmqpMessageId should be normalized to string.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpAnnotatedMessageExtensions.GetMessageAnnotationNormalizedValue" />
        ///   method for AmqpAddress normalization.
        /// </summary>
        ///
        [Test]
        public void GetMessageAnnotationNormalizedValueNormalizesAmqpAddress()
        {
            var key = "customAddress";
            var address = new AmqpAddress("amqps://test");
            var message = new AmqpAnnotatedMessage(AmqpMessageBody.FromData([ReadOnlyMemory<byte>.Empty]));
            message.MessageAnnotations.Add(key, address);

            var value = message.GetMessageAnnotationNormalizedValue(key);
            Assert.That(value, Is.EqualTo(address.ToString()), "The AmqpAddress should be normalized to string.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpAnnotatedMessageExtensions.GetMessageAnnotationNormalizedValue" />
        ///   method for pass through of other types.
        /// </summary>
        ///
        [Test]
        public void GetMessageAnnotationNormalizedValueReturnsRawValueForOtherTypes()
        {
            var key = "customInt";
            var message = new AmqpAnnotatedMessage(AmqpMessageBody.FromData([ReadOnlyMemory<byte>.Empty]));
            message.MessageAnnotations.Add(key, 42);

            var value = message.GetMessageAnnotationNormalizedValue(key);
            Assert.That(value, Is.EqualTo(42), "Other types should be returned as-is.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="AmqpAnnotatedMessageExtensions.GetMessageAnnotationNormalizedValue" />
        ///   method when the key is not present.
        /// </summary>
        ///
        [Test]
        public void GetMessageAnnotationNormalizedValueReturnsNullWhenKeyNotPresent()
        {
            var message = new AmqpAnnotatedMessage(AmqpMessageBody.FromData([ReadOnlyMemory<byte>.Empty]));
            message.MessageAnnotations.Add("someKey", "someValue");

            var value = message.GetMessageAnnotationNormalizedValue("otherKey");
            Assert.That(value, Is.Null, "A missing key should return null.");
        }

        /// <summary>
        ///   Creates a fully populated message with a consistent set of
        ///   test data.
        /// </summary>
        ///
        /// <returns>The populated message.</returns>
        ///
        private static AmqpAnnotatedMessage CreateFullyPopulatedDataBodyMessage()
        {
            var body = AmqpMessageBody.FromData(new[] { (ReadOnlyMemory<byte>)Array.Empty<byte>() });
            var message = new AmqpAnnotatedMessage(body);

            // Header

            message.Header.DeliveryCount = 99;
            message.Header.Durable = true;
            message.Header.FirstAcquirer = true;
            message.Header.Priority = 123;
            message.Header.TimeToLive = TimeSpan.FromSeconds(10);

            // Properties

            message.Properties.AbsoluteExpiryTime = new DateTimeOffset(2015, 10, 27, 00, 00, 00, TimeSpan.Zero);
            message.Properties.ContentEncoding = "fake";
            message.Properties.ContentType = "test/unit";
            message.Properties.CorrelationId = new AmqpMessageId("red-5");
            message.Properties.CreationTime = new DateTimeOffset(2012, 03, 04, 08, 00, 00, 00, TimeSpan.Zero);
            message.Properties.GroupId = "mine!";
            message.Properties.GroupSequence = 555;
            message.Properties.MessageId = new AmqpMessageId("red-leader");
            message.Properties.ReplyTo = new AmqpAddress("amqps://some.namespace.com");
            message.Properties.ReplyToGroupId = "not-mine!";
            message.Properties.Subject = "We tried to copy an AMQP message.  You won't believe what happened next!";
            message.Properties.To = new AmqpAddress("https://some.url.com");
            message.Properties.UserId = new byte[] { 0x11, 0x22 };

            // Footer

            message.Footer.Add("one", "1111");
            message.Footer.Add("two", "2222");

            // Delivery Annotations

            message.DeliveryAnnotations.Add("three", "3333");

            // Message Annotations

            message.MessageAnnotations.Add("four", "4444");
            message.MessageAnnotations.Add("five", "5555");
            message.MessageAnnotations.Add("six", "6666");

            // Application Properties

            message.ApplicationProperties.Add("seven", "7777");

            return message;
        }

        /// <summary>
        ///   Creates a fully populated message with a consistent set of
        ///   test data and the specified set of system properties.
        /// </summary>
        ///
        /// <param name="sequenceNumber">The sequence number of the event; if null, this will not be populated.</param>
        /// <param name="lastSequenceNumber">The sequence number that was last enqueued in the partition; if null, this will not be populated.</param>
        /// <param name="offset">The offset of the event; if null, this will not be populated.</param>
        /// <param name="lastOffset">The offset that was last enqueued in the partition; if null, this will not be populated.</param>
        /// <param name="partitionKey">The partition key of the event; if null, this will not be populated.</param>
        /// <param name="enqueueTime">The time that the event was enqueued in the partition; if null, this will not be populated.</param>
        /// <param name="lastEnqueueTime">The time that an event was last enqueued in the partition; if null, this will not be populated.</param>
        /// <param name="lastRetrieveTime">The time that the information about the last event enqueued in the partition was reported; if null, this will not be populated.</param>
        ///
        /// <returns>The populated message.</returns>
        ///
        private static AmqpAnnotatedMessage CreateDataBodyMessageWithSystemProperties(long? sequenceNumber,
                                                                                      long? lastSequenceNumber,
                                                                                      string offset,
                                                                                      string lastOffset,
                                                                                      string partitionKey,
                                                                                      DateTimeOffset? enqueueTime,
                                                                                      DateTimeOffset? lastEnqueueTime,
                                                                                      DateTimeOffset? lastRetrieveTime)
        {
            var message = CreateFullyPopulatedDataBodyMessage();

            // Expected properties for all messages read from the service.

            if (sequenceNumber.HasValue)
            {
                message.MessageAnnotations.Add(AmqpProperty.SequenceNumber.ToString(), sequenceNumber.Value);
            }

            if (!string.IsNullOrEmpty(offset))
            {
                message.MessageAnnotations.Add(AmqpProperty.Offset.ToString(), offset);
            }

            if (enqueueTime.HasValue)
            {
                message.MessageAnnotations.Add(AmqpProperty.EnqueuedTime.ToString(), enqueueTime.Value);
            }

            // Optional properties for all messages read from the service.

            if (!string.IsNullOrEmpty(partitionKey))
            {
                message.MessageAnnotations.Add(AmqpProperty.PartitionKey.ToString(), partitionKey);
            }

            // Expected properties when tracking of the last enqueued event is enabled.

            if (lastSequenceNumber.HasValue)
            {
                message.DeliveryAnnotations.Add(AmqpProperty.PartitionLastEnqueuedSequenceNumber.ToString(), lastSequenceNumber.Value);
            }

            if (!string.IsNullOrEmpty(lastOffset))
            {
                message.DeliveryAnnotations.Add(AmqpProperty.PartitionLastEnqueuedOffset.ToString(), lastOffset);
            }

            if (lastEnqueueTime.HasValue)
            {
                message.DeliveryAnnotations.Add(AmqpProperty.PartitionLastEnqueuedTimeUtc.ToString(), lastEnqueueTime.Value);
            }

            if (lastRetrieveTime.HasValue)
            {
                message.DeliveryAnnotations.Add(AmqpProperty.LastPartitionPropertiesRetrievalTimeUtc.ToString(), lastRetrieveTime.Value);
            }

            return message;
        }
    }
}
