// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;
using Microsoft.Azure.Amqp.Framing;
using NUnit.Framework;
using static Azure.Core.Amqp.Shared.AmqpAnnotatedMessageConverter;

namespace Azure.Core.Amqp.Tests
{
    public class AmqpAnnotatedMessageConverterTests
    {
        private static readonly object[] s_amqpValues =
        {
            "string",
            new List<string> {"first", "second"},
            'c',
            5,
            new int[] { 5 },
            long.MaxValue,
            new long[] { long.MaxValue },
            (byte) 1,
            (sbyte) 1,
            (short) 1,
            (ushort) 1,
            3.1415926,
            new double[] { 3.1415926 },
            new decimal(3.1415926),
            new decimal[] { new decimal(3.1415926) },
            DateTimeOffset.Parse("3/24/21", CultureInfo.InvariantCulture).UtcDateTime,
            new DateTime[] {DateTimeOffset.Parse("3/24/21", CultureInfo.InvariantCulture).UtcDateTime },
            DateTimeOffset.Parse("3/24/21", CultureInfo.InvariantCulture),
            new DateTimeOffset[] {DateTimeOffset.Parse("3/24/21", CultureInfo.InvariantCulture) },
            TimeSpan.FromSeconds(5),
            new TimeSpan[] {TimeSpan.FromSeconds(5)},
            new Uri("http://localHost"),
            new Uri[] { new Uri("http://localHost") },
            new Guid("55f239a6-5d50-4f6d-8f84-deed326e4554"),
            new Guid[] { new Guid("55f239a6-5d50-4f6d-8f84-deed326e4554"), new Guid("55f239a6-5d50-4f6d-8f84-deed326e4554") },
            new Dictionary<string, string> { { "key", "value" } },
            new Dictionary<string, char> {{ "key", 'c' }},
            new Dictionary<string, int> {{ "key", 5 }},
            new Dictionary<string, byte> {{ "key", 1 } },
            new Dictionary<string, sbyte> {{ "key", 1 } },
            new Dictionary<string, short> {{ "key", 1 } },
            new Dictionary<string, double> {{ "key", 3.1415926 } },
            new Dictionary<string, decimal> {{ "key", new decimal(3.1415926) } },
            new Dictionary<string, DateTime> {{ "key", DateTimeOffset.Parse("3/24/21", CultureInfo.InvariantCulture).UtcDateTime } },
            // for some reason dictionaries with DateTimeOffset, Timespan, or Uri values are not supported in AMQP lib
            // new Dictionary<string, DateTimeOffset> {{ "key", DateTimeOffset.Parse("3/24/21") } },
            // new Dictionary<string, TimeSpan> {{ "key", TimeSpan.FromSeconds(5) } },
            // new Dictionary<string, Uri> {{ "key", new Uri("http://localHost") } },
            new Dictionary<string, Guid> {{ "key", new Guid("55f239a6-5d50-4f6d-8f84-deed326e4554") } },
            new Dictionary<string, object> { { "key1", "value" }, { "key2", 2 } },
        };

        private static readonly object[] s_amqpSequences =
        {
            Enumerable.Repeat(new List<object> {"first", "second"}, 2),
            Enumerable.Repeat(new object[] {'c' }, 1),
            Enumerable.Repeat(new object[] { long.MaxValue }, 2),
            Enumerable.Repeat(new object[] { 1 }, 2),
            Enumerable.Repeat(new object[] { 3.1415926, true }, 2),
            Enumerable.Repeat(new object[] { DateTimeOffset.Parse("3/24/21", CultureInfo.InvariantCulture).UtcDateTime, true }, 2),
            new List<IList<object>> { new List<object> { "first", 1}, new List<object> { "second", 2 } }
        };

        public static readonly object[] s_simpleApplicationPropertyValues =
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

            yield return new object[] { (AmqpSymbol)AmqpMessageConstants.Uri, new Uri("https://www.cheetoes.zomg"), TranslateValue };
            yield return new object[] { (AmqpSymbol)AmqpMessageConstants.DateTimeOffset, DateTimeOffset.Parse("2015-10-27T12:00:00Z"), TranslateValue };
            yield return new object[] { (AmqpSymbol)AmqpMessageConstants.TimeSpan, TimeSpan.FromHours(6), TranslateValue };
        }

        public static IEnumerable<object[]> StreamPropertyTestCases()
        {
            var contents = new byte[] { 0x55, 0x66, 0x99, 0xAA };

            yield return new object[] { new MemoryStream(contents, false), contents };
            yield return new object[] { new BufferedStream(new MemoryStream(contents, false), 512), contents };
        }

        public static IEnumerable<object[]> BinaryPropertyTestCases()
        {
            var contents = new byte[] { 0x55, 0x66, 0x99, 0xAA };

            yield return new object[] { contents, contents };
            yield return new object[] { new ArraySegment<byte>(contents), contents };
        }

        [Test]
        public void CanRoundTripDataMessage()
        {
            var message = new AmqpAnnotatedMessage(AmqpMessageBody.FromData(new ReadOnlyMemory<byte>[] { Encoding.UTF8.GetBytes("some data") }));

            SetCommonProperties(message);

            message = AmqpAnnotatedMessage.FromBytes(message.ToBytes());
            Assert.AreEqual(AmqpMessageBodyType.Data, message.Body.BodyType);
            Assert.IsTrue(message.Body.TryGetData(out IEnumerable<ReadOnlyMemory<byte>> body));
            Assert.AreEqual("some data", Encoding.UTF8.GetString(body.First().ToArray()));

            AssertCommonProperties(message);
        }

        [Test]
        [TestCaseSource(nameof(s_amqpValues))]
        public void CanRoundTripValueBodyMessages(object value)
        {
            var message = new AmqpAnnotatedMessage(AmqpMessageBody.FromValue(value));
            DateTimeOffset time = DateTimeOffset.Now.AddDays(1);
            SetCommonProperties(message);

            message = AmqpAnnotatedMessage.FromBytes(message.ToBytes());

            Assert.IsTrue(message.Body.TryGetValue(out var receivedData));
            Assert.AreEqual(value, receivedData);
            AssertCommonProperties(message);
        }

        [Test]
        [TestCaseSource(nameof(s_amqpSequences))]
        public void CanRoundTripSequenceBodyMessages(IEnumerable<IList<object>> sequence)
        {
            var message = new AmqpAnnotatedMessage(AmqpMessageBody.FromSequence(sequence));
            SetCommonProperties(message);

            message = AmqpAnnotatedMessage.FromBytes(message.ToBytes());

            Assert.IsTrue(message.Body.TryGetSequence(out IEnumerable<IList<object>> receivedData));
            var outerEnum = receivedData.GetEnumerator();
            foreach (IList<object> seq in sequence)
            {
                outerEnum.MoveNext();
                var innerEnum = outerEnum.Current.GetEnumerator();
                foreach (object elem in seq)
                {
                    innerEnum.MoveNext();
                    Assert.AreEqual(elem, innerEnum.Current);
                }
            }
            AssertCommonProperties(message);
        }

        [Test]
        public void ToAmqpMessagePopulatesSimpleApplicationProperties()
        {
            var annotatedMessage = new AmqpAnnotatedMessage(AmqpMessageBody.FromData(new ReadOnlyMemory<byte>[] { new byte[] { 0x11, 0x22, 0x33 }}));

            foreach (var value in s_simpleApplicationPropertyValues)
            {
                annotatedMessage.ApplicationProperties.Add($"{value.GetType().Name }Property", value);
            }

            using AmqpMessage message = ToAmqpMessage(annotatedMessage);

            Assert.IsNotNull(message, "The AMQP message should have been created.");
            Assert.IsNotNull(message.ApplicationProperties, "The AMQP message should have a set of application properties.");

            // The collection comparisons built into the test assertions do not recognize
            // the property sets as equivalent, but a manual inspection proves the properties exist
            // in both.

            foreach (var property in annotatedMessage.ApplicationProperties.Keys)
            {
                var containsValue = message.ApplicationProperties.Map.TryGetValue(property, out object value);

                Assert.IsTrue(containsValue, $"The message properties did not contain: [{ property }]");
                Assert.That(value, Is.EqualTo(annotatedMessage.ApplicationProperties[property]), $"The property value did not match for: [{ property }]");
            }
        }

        [Test]
        [TestCase("http://www.server.com/path/stuff/thing.json")]
        [TestCase("/path/stuff/thing.json")]
        public void ToAmqpMessageHandlesRelativeAndAbsoluteUris(string uriValue)
        {
            var key = "UriProperty";
            var expectedUri = new Uri(uriValue, UriKind.RelativeOrAbsolute);

            var annotatedMessage = new AmqpAnnotatedMessage(AmqpMessageBody.FromData(new ReadOnlyMemory<byte>[] { new byte[] { 0x11, 0x22, 0x33 }}));
            annotatedMessage.ApplicationProperties.Add(key, expectedUri);

            using AmqpMessage message = ToAmqpMessage(annotatedMessage);

            Assert.IsNotNull(message, "The AMQP message should have been created.");
            Assert.IsNotNull(message.ApplicationProperties, "The AMQP message should have a set of application properties.");

            var containsValue = annotatedMessage.ApplicationProperties.TryGetValue(key, out object value);
            var uriProperty = value as Uri;

            Assert.IsTrue(containsValue, $"The message properties did not contain the Uri property");
            Assert.IsNotNull(uriProperty, "The property value was not a Uri.");
            Assert.AreEqual(expectedUri, uriProperty, "The property value did not match.");
        }

        [Test]
        public void FromAmqpMessagePopulatesSimpleApplicationProperties()
        {
            var applicationProperties = s_simpleApplicationPropertyValues.ToDictionary(value => $"{ value.GetType().Name }Property", value => value);
            var dataBody = new Data { Value = new byte[] { 0x11, 0x22, 0x33 } };

            using var message = AmqpMessage.Create(dataBody);

            foreach (KeyValuePair<string, object> pair in applicationProperties)
            {
                message.ApplicationProperties.Map.Add(pair.Key, pair.Value);
            }

            var annotatedMessage = FromAmqpMessage(message);

            Assert.NotNull(annotatedMessage, "The message should have been created.");
            Assert.IsTrue(annotatedMessage.ApplicationProperties.Any(), "The message should have a set of application properties.");

            // The collection comparisons built into the test assertions do not recognize
            // the property sets as equivalent, but a manual inspection proves the properties exist
            // in both.

            foreach (var property in applicationProperties.Keys)
            {
                var containsValue = annotatedMessage.ApplicationProperties.TryGetValue(property, out object value);

                Assert.IsTrue(containsValue, $"The message properties did not contain: [{ property }]");
                Assert.AreEqual(value, applicationProperties[property], $"The property value did not match for: [{ property }]");
            }
        }

        [Test]
        [TestCase("http://www.server.com/path/stuff/thing.json")]
        [TestCase("/path/stuff/thing.json")]
        public void FromAmqpMessageHandlesRelativeAndAbsoluteUris(string uriValue)
        {
            var key = "UriProperty";
            var expectedUri = new Uri(uriValue, UriKind.RelativeOrAbsolute);
            var dataBody = new Data { Value = new byte[] { 0x11, 0x22, 0x33 } };

            using var message = AmqpMessage.Create(dataBody);
            message.ApplicationProperties.Map.Add(key, new DescribedType((AmqpSymbol)AmqpMessageConstants.Uri, uriValue));

            var annotatedMessage = FromAmqpMessage(message);

            Assert.NotNull(annotatedMessage, "The message should have been created.");
            Assert.IsTrue(annotatedMessage.ApplicationProperties.Any(), "The message should have a set of application properties.");

            var containsValue = annotatedMessage.ApplicationProperties.TryGetValue(key, out object value);
            var uriProperty = value as Uri;

            Assert.IsTrue(containsValue, $"The message properties did not contain the Uri property");
            Assert.IsNotNull(uriProperty, "The property value was not a Uri.");
            Assert.AreEqual(expectedUri, uriProperty, "The property value did not match.");
        }

        [Test]
        [TestCaseSource(nameof(DescribedTypePropertyTestCases))]
        public void ToAmqpMessageTranslatesDescribedApplicationProperties(object typeDescriptor, object propertyValueRaw, Func<object, object> propertyValueAccessor)
        {
            var annotatedMessage = new AmqpAnnotatedMessage(AmqpMessageBody.FromData(new ReadOnlyMemory<byte>[] { new byte[] { 0x11, 0x22, 0x33 }}));
            annotatedMessage.ApplicationProperties.Add("TestProp", propertyValueRaw);

             using AmqpMessage message = ToAmqpMessage(annotatedMessage);

            Assert.IsNotNull(message, "The AMQP message should have been created.");
            Assert.IsNotNull(message.ApplicationProperties, "The AMQP message should have a set of application properties.");

            var propertyKey = annotatedMessage.ApplicationProperties.Keys.First();
            var propertyValue = propertyValueAccessor(annotatedMessage.ApplicationProperties[propertyKey]);
            var containsValue = message.ApplicationProperties.Map.TryGetValue(propertyKey, out DescribedType describedValue);

            Assert.True(containsValue, "The message properties did not contain the property.");
            Assert.AreEqual(describedValue.Value, propertyValue, "The property value did not match.");
            Assert.AreEqual(describedValue.Descriptor, typeDescriptor, "The message property descriptor was incorrect.");
        }

        [TestCaseSource(nameof(DescribedTypePropertyTestCases))]
        public void FromAmqpMessagePopulateDescribedApplicationProperties(object typeDescriptor, object propertyValueRaw, Func<object, object> propertyValueAccessor)
        {
            var dataBody = new Data { Value = new byte[] { 0x11, 0x22, 0x33 } };
            using var message = AmqpMessage.Create(dataBody);

            var describedProperty = new DescribedType(typeDescriptor, propertyValueAccessor(propertyValueRaw));
            message.ApplicationProperties.Map.Add(typeDescriptor.ToString(), describedProperty);

            var annotatedMessage = FromAmqpMessage(message);

            Assert.NotNull(annotatedMessage, "The message should have been created.");
            Assert.IsTrue(annotatedMessage.ApplicationProperties.Any(), "The message should have a set of application properties.");

            var containsValue = annotatedMessage.ApplicationProperties.TryGetValue(typeDescriptor.ToString(), out object value);
            Assert.IsTrue(containsValue, $"The event properties did not contain the described property.");
            Assert.AreEqual(value, propertyValueRaw, $"The property value did not match.");
        }

        [Test]
        [TestCaseSource(nameof(StreamPropertyTestCases))]
        public void ToAmqpMessageTranslatesStreamApplicationProperties(object propertyStream, byte[] contents)
        {
            var annotatedMessage = new AmqpAnnotatedMessage(AmqpMessageBody.FromData(new ReadOnlyMemory<byte>[] { new byte[] { 0x11, 0x22, 0x33 }}));
            annotatedMessage.ApplicationProperties.Add("TestProp", propertyStream);

            using AmqpMessage message = ToAmqpMessage(annotatedMessage);

            Assert.IsNotNull(message, "The AMQP message should have been created.");
            Assert.IsNotNull(message.ApplicationProperties, "The AMQP message should have a set of application properties.");

            var propertyKey = annotatedMessage.ApplicationProperties.Keys.First();
            var containsValue = message.ApplicationProperties.Map.TryGetValue(propertyKey, out object streamValue);

            Assert.IsTrue(containsValue, "The message properties did not contain the property.");
            Assert.IsInstanceOf<ArraySegment<byte>>(streamValue, "The message property stream was not read correctly.");
            Assert.AreEqual(((ArraySegment<byte>)streamValue).ToArray(), contents, "The property value did not match.");
        }

        [Test]
        [TestCaseSource(nameof(BinaryPropertyTestCases))]
        public void ToAmqpMessageTranslatesBinaryApplicationProperties(object property, object contents)
        {
            var annotatedMessage = new AmqpAnnotatedMessage(AmqpMessageBody.FromData(new ReadOnlyMemory<byte>[] { new byte[] { 0x11, 0x22, 0x33 }}));
            annotatedMessage.ApplicationProperties.Add("TestProp", property);

            using AmqpMessage message = ToAmqpMessage(annotatedMessage);

            Assert.IsNotNull(message, "The AMQP message should have been created.");
            Assert.IsNotNull(message.ApplicationProperties, "The AMQP message should have a set of application properties.");

            var propertyKey = annotatedMessage.ApplicationProperties.Keys.First();
            var containsValue = message.ApplicationProperties.Map.TryGetValue(propertyKey, out object streamValue);

            Assert.IsTrue(containsValue, "The message properties did not contain the property.");
            Assert.IsInstanceOf<ArraySegment<byte>>(streamValue, "The message property stream was not read correctly.");
            Assert.AreEqual(((ArraySegment<byte>)streamValue).ToArray(), contents, "The property value did not match.");
        }

        [Test]
        [TestCaseSource(nameof(BinaryPropertyTestCases))]
        public void FromAmqpMessagePopulatesBinaryApplicationProperties(object property, object contents)
        {
            var dataBody = new Data { Value = new byte[] { 0x11, 0x22, 0x33 } };
            using var message = AmqpMessage.Create(dataBody);

            var propertyKey = "Test";
            message.ApplicationProperties.Map.Add(propertyKey, property);

            var annotatedMessage = FromAmqpMessage(message);

            Assert.NotNull(annotatedMessage, "The message should have been created.");
            Assert.IsTrue(annotatedMessage.ApplicationProperties.Any(), "The message should have a set of application properties.");

            var containsValue = annotatedMessage.ApplicationProperties.TryGetValue(propertyKey, out var messageValue);
            Assert.IsTrue(containsValue, $"The message properties should contain the property.");
            Assert.AreEqual(messageValue, contents, "The property value was incorrect.");
        }

        [Test]
        public void FromAmqpMessagePopulatesPartialArraySegmentApplicationProperties()
        {
            var dataBody = new Data { Value = new byte[] { 0x11, 0x22, 0x33 } };
            using var message = AmqpMessage.Create(dataBody);

            var propertyKey = "Test";
            var propertyValue = new byte[] { 0x11, 0x15, 0xF8, 0x20 };
            message.ApplicationProperties.Map.Add(propertyKey, new ArraySegment<byte>(propertyValue, 1, 2));

            var annotatedMessage = FromAmqpMessage(message);

            Assert.NotNull(annotatedMessage, "The message should have been created.");
            Assert.IsTrue(annotatedMessage.ApplicationProperties.Any(), "The message should have a set of application properties.");

            var containsValue = annotatedMessage.ApplicationProperties.TryGetValue(propertyKey, out var messageValue);
            Assert.IsTrue(containsValue, $"The message properties should contain the property.");
            Assert.AreEqual(messageValue, propertyValue.Skip(1).Take(2), "The property value was incorrect.");
        }

        [Test]
        public void FromAmqpMessageDoesNotIncludeUnknownApplicationPropertyType()
        {
            var dataBody = new Data { Value = new byte[] { 0x11, 0x22, 0x33 } };
            using var message = AmqpMessage.Create(dataBody);

            var typeDescriptor = (AmqpSymbol)"INVALID";
            var describedProperty = new DescribedType(typeDescriptor, 1234);
            message.ApplicationProperties.Map.Add(typeDescriptor.ToString(), describedProperty);

            var annotatedMessage = FromAmqpMessage(message);

            Assert.NotNull(annotatedMessage, "The message should have been created.");
            Assert.IsFalse(annotatedMessage.ApplicationProperties.Any(), "The message should not have a set of application properties.");

            var containsValue = annotatedMessage.ApplicationProperties.TryGetValue(typeDescriptor.ToString(), out var messageValue);
            Assert.IsFalse(containsValue, "The message properties should not contain the described property.");
        }

        [Test]
        public void TimeToLiveIsOverriddenOnReceivedMessageByAbsoluteExpiryTime()
        {
            var amqpMessage =
                ToAmqpMessage(new AmqpAnnotatedMessage(AmqpMessageBody.FromValue(5)));

            amqpMessage.Properties.CreationTime = DateTime.UtcNow;
            amqpMessage.Properties.AbsoluteExpiryTime = DateTime.MaxValue;
            amqpMessage.Header.Ttl = (uint) TimeSpan.FromDays(49).TotalMilliseconds;

            var annotatedMessage = FromAmqpMessage(amqpMessage);

            // The expected TTL will disregard the TTL set on the header and instead calculate it based on expiry time and creation time.
            var expectedTtl = amqpMessage.Properties.AbsoluteExpiryTime - amqpMessage.Properties.CreationTime;
            Assert.AreEqual(expectedTtl, annotatedMessage.Header.TimeToLive);
        }

        [Test]
        public void TimeToLiveIsNotOverriddenWhenNoAbsoluteExpiryTimePresent()
        {
            var amqpMessage =
                ToAmqpMessage(new AmqpAnnotatedMessage(AmqpMessageBody.FromValue(5)));

            amqpMessage.Properties.CreationTime = DateTime.UtcNow;
            amqpMessage.Header.Ttl = (uint) TimeSpan.FromDays(49).TotalMilliseconds;

            var annotatedMessage = FromAmqpMessage(amqpMessage);

            Assert.AreEqual(TimeSpan.FromDays(49), annotatedMessage.Header.TimeToLive);
        }

        [Test]
        public void TimeToLiveRoundTripsCorrectlyWithGreaterThanMaxInt()
        {
            var input = new AmqpAnnotatedMessage(AmqpMessageBody.FromValue(5))
                {
                    Header =
                    {
                        TimeToLive = TimeSpan.FromDays(100)
                    }
                };
            var amqpMessage = ToAmqpMessage(input);

            Assert.AreEqual(uint.MaxValue, amqpMessage.Header.Ttl);
            Assert.AreEqual(amqpMessage.Properties.CreationTime + TimeSpan.FromDays(100), amqpMessage.Properties.AbsoluteExpiryTime);

            var output = FromAmqpMessage(amqpMessage);

            Assert.AreEqual(TimeSpan.FromDays(100), output.Header.TimeToLive);
            Assert.AreEqual(amqpMessage.Properties.CreationTime, output.Properties.CreationTime!.Value.UtcDateTime);
            Assert.AreEqual(amqpMessage.Properties.AbsoluteExpiryTime, output.Properties.AbsoluteExpiryTime!.Value.UtcDateTime);
        }

        [Test]
        public void AbsoluteExpiryTimeAndCreationTimeNotSetWhenNoTtl()
        {
            var input = new AmqpAnnotatedMessage(AmqpMessageBody.FromValue(5));
            var amqpMessage = ToAmqpMessage(input);

            Assert.IsNull(amqpMessage.Header.Ttl);
            Assert.IsNull(amqpMessage.Properties.CreationTime);
            Assert.IsNull(amqpMessage.Properties.AbsoluteExpiryTime);
        }

        [Test]
        public void AbsoluteExpiryTimeAndCreationTimeSetOnMessageWhenSetExplicitly()
        {
            var input = new AmqpAnnotatedMessage(AmqpMessageBody.FromValue(5));
            var now = DateTime.UtcNow;
            input.Properties.CreationTime = now;
            input.Properties.AbsoluteExpiryTime = now + TimeSpan.FromDays(1);
            var amqpMessage = ToAmqpMessage(input);

            Assert.IsNull(amqpMessage.Header.Ttl);
            Assert.AreEqual(now, amqpMessage.Properties.CreationTime);
            Assert.AreEqual(now + TimeSpan.FromDays(1), amqpMessage.Properties.AbsoluteExpiryTime);
        }

        [Test]
        public void AbsoluteExpiryTimeAndCreationTimeAreOverriddenBasedOnTtlWhenSending()
        {
            var input = new AmqpAnnotatedMessage(AmqpMessageBody.FromValue(5));
            var now = DateTimeOffset.UtcNow;
            input.Properties.CreationTime = now;
            input.Properties.AbsoluteExpiryTime = now + TimeSpan.FromDays(1);
            input.Header.TimeToLive = TimeSpan.FromDays(7);
            var amqpMessage = ToAmqpMessage(input);

            Assert.AreEqual(TimeSpan.FromDays(7).TotalMilliseconds, amqpMessage.Header.Ttl);
            Assert.AreEqual(amqpMessage.Properties.CreationTime + TimeSpan.FromDays(7), amqpMessage.Properties.AbsoluteExpiryTime);
        }

        private static void AssertCommonProperties(AmqpAnnotatedMessage message)
        {
            Assert.AreEqual("applicationValue", message.ApplicationProperties["applicationKey"]);
            Assert.AreEqual("deliveryValue", message.DeliveryAnnotations["deliveryKey"]);
            Assert.AreEqual("messageValue", message.MessageAnnotations["messageKey"]);
            Assert.AreEqual("footerValue", message.Footer["footerKey"]);
            Assert.AreEqual(1, message.Header.DeliveryCount);
            Assert.IsTrue(message.Header.Durable);
            Assert.IsTrue(message.Header.FirstAcquirer);
            Assert.AreEqual(1, message.Header.Priority);
            Assert.AreEqual(TimeSpan.FromSeconds(60), message.Header.TimeToLive);
            // because AMQP only has millisecond resolution, allow for up to a 1ms difference when round-tripping
            Assert.IsNotNull(message.Properties.CreationTime);
            // AbsoluteExpiryTime is set based on TTL and CreationTime for outgoing messages
            Assert.That(message.Properties.CreationTime + TimeSpan.FromSeconds(60), Is.EqualTo(message.Properties.AbsoluteExpiryTime.Value).Within(1).Milliseconds);
            Assert.AreEqual("compress", message.Properties.ContentEncoding);
            Assert.AreEqual("application/json", message.Properties.ContentType);
            Assert.AreEqual("correlationId", message.Properties.CorrelationId.ToString());
            Assert.AreEqual("groupId", message.Properties.GroupId);
            Assert.AreEqual(5, message.Properties.GroupSequence);
            Assert.AreEqual("messageId", message.Properties.MessageId.ToString());
            Assert.AreEqual("replyTo", message.Properties.ReplyTo.ToString());
            Assert.AreEqual("replyToGroupId", message.Properties.ReplyToGroupId);
            Assert.AreEqual("subject", message.Properties.Subject);
            Assert.AreEqual("to", message.Properties.To.ToString());
            Assert.AreEqual("userId", Encoding.UTF8.GetString(message.Properties.UserId.Value.ToArray()));
        }

        private static void SetCommonProperties(AmqpAnnotatedMessage message)
        {
            message.ApplicationProperties.Add("applicationKey", "applicationValue");
            message.DeliveryAnnotations.Add("deliveryKey", "deliveryValue");
            message.MessageAnnotations.Add("messageKey", "messageValue");
            message.Footer.Add("footerKey", "footerValue");
            message.Header.DeliveryCount = 1;
            message.Header.Durable = true;
            message.Header.FirstAcquirer = true;
            message.Header.Priority = 1;
            message.Header.TimeToLive = TimeSpan.FromSeconds(60);
            message.Properties.ContentEncoding = "compress";
            message.Properties.ContentType = "application/json";
            message.Properties.CorrelationId = new AmqpMessageId("correlationId");
            message.Properties.GroupId = "groupId";
            message.Properties.GroupSequence = 5;
            message.Properties.MessageId = new AmqpMessageId("messageId");
            message.Properties.ReplyTo = new AmqpAddress("replyTo");
            message.Properties.ReplyToGroupId = "replyToGroupId";
            message.Properties.Subject = "subject";
            message.Properties.To = new AmqpAddress("to");
            message.Properties.UserId = Encoding.UTF8.GetBytes("userId");
        }
    }
}
