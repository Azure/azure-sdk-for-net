// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core.Amqp;
using Azure.Messaging.EventHubs.Amqp;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="AmqpSystemProperties" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class AmqpSystemPropertiesTests
    {
        /// <summary>
        ///   Validates the dictionary operations against the set of well-known
        ///   items from the AMQP message properties section.
        /// </summary>
        ///
        [Test]
        public void PropertiesSectionItemsAreIncluded()
        {
            var message = CreatePopulatedDataBodyMessage();
            var systemProps = new AmqpSystemProperties(message);

            // Set the expected values for well-known property section items.

            message.Properties.MessageId = new AmqpMessageId("test");
            message.Properties.UserId = new byte[] { 0x33, 0x44 };
            message.Properties.To = new AmqpAddress("http://www.omgcats.com");
            message.Properties.Subject = "test-subject";
            message.Properties.ReplyTo = new AmqpAddress("http://some.place.ext");
            message.Properties.CorrelationId = new AmqpMessageId("corr");
            message.Properties.ContentType = "text/plain";
            message.Properties.ContentEncoding = "UTF-8";
            message.Properties.AbsoluteExpiryTime = new DateTimeOffset(2015, 10, 27, 00, 00, 00, TimeSpan.Zero);
            message.Properties.CreationTime = new DateTimeOffset(2012, 03, 04, 08, 00, 00, TimeSpan.Zero);
            message.Properties.GroupId = "bluebirds";
            message.Properties.GroupSequence = 3;
            message.Properties.ReplyToGroupId = "7";

            // Validate that the properties are present.

            Assert.That(systemProps.ContainsKey(Properties.MessageIdName), Is.True, "The message identifier should be included.");
            Assert.That(systemProps.ContainsKey(Properties.UserIdName), Is.True, "The user identifier should be included.");
            Assert.That(systemProps.ContainsKey(Properties.ToName), Is.True, "The \"to\" property should be included.");
            Assert.That(systemProps.ContainsKey(Properties.SubjectName), Is.True, "The subject should be included.");
            Assert.That(systemProps.ContainsKey(Properties.ReplyToName), Is.True, "The \"reply to\" property should be included.");
            Assert.That(systemProps.ContainsKey(Properties.CorrelationIdName), Is.True, "The correlation identifier should be included.");
            Assert.That(systemProps.ContainsKey(Properties.ContentTypeName), Is.True, "The content type should be included.");
            Assert.That(systemProps.ContainsKey(Properties.ContentEncodingName), Is.True, "The content encoding should be included.");
            Assert.That(systemProps.ContainsKey(Properties.AbsoluteExpiryTimeName), Is.True, "The expiration time should be included.");
            Assert.That(systemProps.ContainsKey(Properties.CreationTimeName), Is.True, "The creation time should be included.");
            Assert.That(systemProps.ContainsKey(Properties.GroupIdName), Is.True, "The group identifier should be included.");
            Assert.That(systemProps.ContainsKey(Properties.GroupSequenceName), Is.True, "The group sequence should be included.");
            Assert.That(systemProps.ContainsKey(Properties.ReplyToGroupIdName), Is.True, "The reply-to group identifier should be included.");

            // Validate that the properties match.

            Assert.That(systemProps[Properties.MessageIdName], Is.EqualTo(message.Properties.MessageId.ToString()), "The message identifier should match.");
            Assert.That(systemProps[Properties.UserIdName], Is.EqualTo(message.Properties.UserId), "The user identifier should match.");
            Assert.That(systemProps[Properties.ToName], Is.EqualTo(message.Properties.To.ToString()), "The \"to\" property should match.");
            Assert.That(systemProps[Properties.SubjectName], Is.EqualTo(message.Properties.Subject), "The subject should match.");
            Assert.That(systemProps[Properties.ReplyToName], Is.EqualTo(message.Properties.ReplyTo.ToString()), "The \"reply to\" property should match.");
            Assert.That(systemProps[Properties.CorrelationIdName], Is.EqualTo(message.Properties.CorrelationId.ToString()), "The correlation identifier should match.");
            Assert.That(systemProps[Properties.ContentTypeName], Is.EqualTo(message.Properties.ContentType), "The content type should match.");
            Assert.That(systemProps[Properties.ContentEncodingName], Is.EqualTo(message.Properties.ContentEncoding), "The content encoding should match.");
            Assert.That(systemProps[Properties.AbsoluteExpiryTimeName], Is.EqualTo(message.Properties.AbsoluteExpiryTime), "The expiration time should match.");
            Assert.That(systemProps[Properties.CreationTimeName], Is.EqualTo(message.Properties.CreationTime), "The creation time should match.");
            Assert.That(systemProps[Properties.GroupIdName], Is.EqualTo(message.Properties.GroupId), "The group identifier should match.");
            Assert.That(systemProps[Properties.GroupSequenceName], Is.EqualTo(message.Properties.GroupSequence), "The group sequence should match.");
            Assert.That(systemProps[Properties.ReplyToGroupIdName], Is.EqualTo(message.Properties.ReplyToGroupId), "The reply-to group identifier should match.");
        }

        /// <summary>
        ///   Validates the dictionary operations against the set of well-known
        ///   items from the AMQP message annotations section.
        /// </summary>
        ///
        [Test]
        public void MessageAnnotationSectionItemsAreIncluded()
        {
            var message = CreatePopulatedDataBodyMessage();
            var systemProps = new AmqpSystemProperties(message);

            // Set the expected values for well-known property section items.

            message.MessageAnnotations.Clear();
            message.MessageAnnotations.Add("first", "one");
            message.MessageAnnotations.Add("second", 2);
            message.MessageAnnotations.Add("third", new object());

            // Validate that the properties are present and match.

            foreach (var key in message.MessageAnnotations.Keys)
            {
                Assert.That(systemProps.ContainsKey(key), Is.True, $"The delivery annotation key, { key }, should be included.");
                Assert.That(systemProps[key], Is.EqualTo(message.MessageAnnotations[key]), $"The delivery annotation key, { key }, should match.");
            }
        }

        /// <summary>
        ///   Validates basic dictionary operations.
        /// </summary>
        ///
        [Test]
        public void KeyOperationsWorkWhenNotEmpty()
        {
            var message = CreateEmptydDataBodyMessage();
            var systemProps = new AmqpSystemProperties(message);

            message.Properties.MessageId = new AmqpMessageId("test");
            message.MessageAnnotations.Add("first", "one");

            var unexpectedKey = Guid.NewGuid().ToString();
            var expectedKeys = new HashSet<string> { Properties.MessageIdName };

            foreach (var key in message.MessageAnnotations.Keys)
            {
                expectedKeys.Add(key);
            }

            // Key counts are correct.

            Assert.That(systemProps.Count, Is.EqualTo(expectedKeys.Count), "The number of items was incorrect.");

            // Expected keys are returned by ContainsKey.

            foreach (var key in expectedKeys)
            {
                Assert.That(systemProps.ContainsKey(key), Is.True, $"The key, { key }, was not contained.");
            }

            // Unexpected keys are not returned by ContainsKey.

            Assert.That(systemProps.ContainsKey(unexpectedKey), Is.False, "The unexpected key was contained.");

            // Enumerated keys match the expected set.

            foreach (var key in systemProps.Keys)
            {
                Assert.That(expectedKeys.Contains(key), $"The key, { key }, was in the properties but is unexpected.");
            }
        }

        /// <summary>
        ///   Validates basic dictionary operations.
        /// </summary>
        ///
        [Test]
        public void ValueOperationsWorkWhenNotEmpty()
        {
            var message = CreateEmptydDataBodyMessage();
            var systemProps = new AmqpSystemProperties(message);

            message.Properties.MessageId = new AmqpMessageId("test");
            message.MessageAnnotations.Add("first", "one");

            var unexpectedKey = Guid.NewGuid().ToString();
            var expectedValues = new HashSet<object> { message.Properties.MessageId.ToString() };

            foreach (var value in message.MessageAnnotations.Values)
            {
                expectedValues.Add(value switch
                {
                    AmqpMessageId id => id.ToString(),
                    AmqpAddress address => address.ToString(),
                    _ => value
                });
            }

            // Count

            Assert.That(systemProps.Count, Is.EqualTo(expectedValues.Count), "The number of items was incorrect.");

            // System property values are correct.

            Assert.That(systemProps[Properties.MessageIdName], Is.EqualTo(message.Properties.MessageId.ToString()), "The message identifier did not match when read through the indexer.");
            Assert.That(systemProps.TryGetValue(Properties.MessageIdName, out var messageId), Is.True, "The message identifier was not contained when read through TryGetValue.");
            Assert.That(messageId, Is.EqualTo(message.Properties.MessageId.ToString()), "The message identifier did not match when read through TryGetValue.");

            // Message annotation values are correct.

            foreach (var key in message.MessageAnnotations.Keys)
            {
                Assert.That(systemProps[key], Is.EqualTo(message.MessageAnnotations[key]), $"The message annotation, { key }, did not match when read through the indexer.");
                Assert.That(systemProps.TryGetValue(key, out var currentValue), Is.True, $"The message annotation, { key }, was not contained when read through TryGetValue.");
                Assert.That(currentValue, Is.EqualTo(message.MessageAnnotations[key]), $"The message annotation, { key }, did not match when read through TryGetValue.");
            }

            // Unexpected values are not returned.

            Assert.That(() => systemProps[unexpectedKey], Throws.InstanceOf<KeyNotFoundException>(), "The unexpected key should result in an exception when read through the indexer.");
            Assert.That(systemProps.TryGetValue(unexpectedKey, out var unexpectedValue), Is.False, "The unexpected key should not succeed for TryGetValue.");

            // Enumerated Values match the expected set.

            foreach (var value in systemProps.Values)
            {
                Assert.That(expectedValues.Contains(value), Is.True, $"The value, { value }, was in the properties but is unexpected.");
            }
        }

        /// <summary>
        ///   Validates basic dictionary operation for the normalized enqueue time.
        /// </summary>
        ///
        [Test]
        public void ValueOperationsNormalizeEnqueuedTime()
        {
            var message = CreateEmptydDataBodyMessage();
            var systemKey = AmqpProperty.EnqueuedTime.ToString();

            var systemProps = new AmqpSystemProperties(message);
            message.MessageAnnotations.Add(systemKey, new DateTime(2015, 10, 15, 0, 0, 0));

            var expectedValue = message.GetEnqueuedTime(default);

            Assert.That(systemProps[systemKey], Is.EqualTo(expectedValue), "The enqueued time did not match when read through the indexer.");
            Assert.That(systemProps.TryGetValue(systemKey, out var enqueueTime), Is.True, "The enqueued time was not contained when read through TryGetValue.");
            Assert.That(enqueueTime, Is.EqualTo(expectedValue), "The enqueued time did not match when read through TryGetValue.");

            // Message annotation values are correct.

            var key = systemProps.Keys.Single();
            Assert.That(key, Is.EqualTo(systemKey), "The key should be the same as the enqueued time key.");
            Assert.That(systemProps[key], Is.EqualTo(expectedValue), $"The message annotation, {key}, did not match when read through the indexer.");

            // Value set should contain the enqueued time.

            Assert.That(systemProps.Values.Single(), Is.EqualTo(expectedValue), "The enqueued time did not match when read through the Values set.");
        }

        /// <summary>
        ///   Validates basic dictionary operation for the normalized sequence number.
        /// </summary>
        ///
        [Test]
        [TestCase(12345)]
        [TestCase(12345L)]
        [TestCase("12345")]
        public void ValueOperationsNormalizeSequenceNumber(object sequenceSource)
        {
            var message = CreateEmptydDataBodyMessage();
            var systemKey = AmqpProperty.SequenceNumber.ToString();

            var systemProps = new AmqpSystemProperties(message);
            message.MessageAnnotations.Add(systemKey, sequenceSource);

            var expectedValue = message.GetSequenceNumber(default);

            Assert.That(systemProps[systemKey], Is.EqualTo(expectedValue), "The sequence number did not match when read through the indexer.");
            Assert.That(systemProps.TryGetValue(systemKey, out var enqueueTime), Is.True, "The sequence number was not contained when read through TryGetValue.");
            Assert.That(enqueueTime, Is.EqualTo(expectedValue), "The sequence number did not match when read through TryGetValue.");

            // Message annotation values are correct.

            var key = systemProps.Keys.Single();
            Assert.That(key, Is.EqualTo(systemKey), "The key should be the same as the sequence number key.");
            Assert.That(systemProps[key], Is.EqualTo(expectedValue), $"The message annotation, {key}, did not match when read through the indexer.");

            // Value set should contain the sequence number.

            Assert.That(systemProps.Values.Single(), Is.EqualTo(expectedValue), "The sequence number did not match when read through the Values set.");
        }

        /// <summary>
        ///   Validates basic dictionary operations.
        /// </summary>
        ///
        [Test]
        public void EnumeratorsWorkWhenNotEmpty()
        {
            var message = CreateEmptydDataBodyMessage();
            var systemProps = new AmqpSystemProperties(message);

            message.Properties.MessageId = new AmqpMessageId("test");
            message.MessageAnnotations.Add("first", "one");

            var expectedItems = new Dictionary<string, object>
            {
                { Properties.MessageIdName, message.Properties.MessageId.ToString() }
            };

            foreach (var item in message.MessageAnnotations)
            {
                expectedItems.Add(item.Key, item.Value switch
                {
                    AmqpMessageId id => id.ToString(),
                    AmqpAddress address => address.ToString(),
                    _ => item.Value
                });
            }

            // Count

            Assert.That(systemProps.Count, Is.EqualTo(expectedItems.Count), "The number of items was incorrect.");

            // Enumerated Values match the expected set.

           foreach (var item in systemProps)
            {
                Assert.That(expectedItems.ContainsKey(item.Key), Is.True, $"The item with key, { item.Key }, was in the properties but is unexpected.");
                Assert.That(item.Value, Is.EqualTo(expectedItems[item.Key]), $"The item with key, { item.Key }, did not match the expected value.");
            }
        }

        /// <summary>
        ///   Validates basic dictionary operations.
        /// </summary>
        ///
        [Test]
        public void KeyOperationsWorkWhenEmpty()
        {
            var message = CreateEmptydDataBodyMessage();
            var systemProps = new AmqpSystemProperties(message);
            var unexpectedKey = Guid.NewGuid().ToString();

            // Key counts are correct.

            Assert.That(systemProps.Count, Is.EqualTo(0), "The number of items was incorrect.");

            // Unexpected keys are not returned by ContainsKey.

            Assert.That(systemProps.ContainsKey(unexpectedKey), Is.False, "The unexpected key was contained.");

            // Enumerated keys are empty

            foreach (var key in systemProps.Keys)
            {
                Assert.Fail($"The key, { key }, was found in the set that should be empty.");
            }
        }

        /// <summary>
        ///   Validates basic dictionary operations.
        /// </summary>
        ///
        [Test]
        public void ValueOperationsWorkWhenEmpty()
        {
            var message = CreateEmptydDataBodyMessage();
            var systemProps = new AmqpSystemProperties(message);
            var unexpectedKey = Guid.NewGuid().ToString();

            // Count

            Assert.That(systemProps.Count, Is.EqualTo(0), "The number of items was incorrect.");

            // Unexpected values are not returned.

            Assert.That(() => systemProps[unexpectedKey], Throws.InstanceOf<KeyNotFoundException>(), "The unexpected key should result in an exception when read through the indexer.");
            Assert.That(systemProps.TryGetValue(unexpectedKey, out var unexpectedValue), Is.False, "The unexpected key should not succeed for TryGetValue.");

            // Enumerated Values are empty.

            foreach (var value in systemProps.Values)
            {
                Assert.Fail($"The value, { value }, was found in the set that should be empty.");
            }
        }

        /// <summary>
        ///   Validates basic dictionary operations.
        /// </summary>
        ///
        [Test]
        public void EnumeratorsWorkWhenEmpty()
        {
            var message = CreateEmptydDataBodyMessage();
            var systemProps = new AmqpSystemProperties(message);

            // Count

            Assert.That(systemProps.Count, Is.EqualTo(0), "The number of items was incorrect.");

            // Enumerated Values are empty.

           foreach (var item in systemProps)
            {
                Assert.Fail($"The key, { item.Key }, was found in the set that should be empty.");
            }
        }

        /// <summary>
        ///   Creates a fully populated message with a consistent set of
        ///   test data.
        /// </summary>
        ///
        /// <returns>The populated message.</returns>
        ///
        private static AmqpAnnotatedMessage CreatePopulatedDataBodyMessage()
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
        ///   test data.
        /// </summary>
        ///
        /// <returns>The populated message.</returns>
        ///
        private static AmqpAnnotatedMessage CreateEmptydDataBodyMessage()
        {
            var body = AmqpMessageBody.FromData(new[] { (ReadOnlyMemory<byte>)Array.Empty<byte>() });
            var message = new AmqpAnnotatedMessage(body);

            return message;
        }
    }
}
