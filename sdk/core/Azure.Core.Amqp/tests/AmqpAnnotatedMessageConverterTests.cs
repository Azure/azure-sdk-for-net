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
            Assert.That(message.Body.BodyType, Is.EqualTo(AmqpMessageBodyType.Data));
            Assert.That(message.Body.TryGetData(out IEnumerable<ReadOnlyMemory<byte>> body), Is.True);
            Assert.That(Encoding.UTF8.GetString(body.First().ToArray()), Is.EqualTo("some data"));

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

            Assert.That(message.Body.TryGetValue(out var receivedData), Is.True);
            Assert.That(receivedData, Is.EqualTo(value));
            AssertCommonProperties(message);
        }

        [Test]
        [TestCaseSource(nameof(s_amqpSequences))]
        public void CanRoundTripSequenceBodyMessages(IEnumerable<IList<object>> sequence)
        {
            var message = new AmqpAnnotatedMessage(AmqpMessageBody.FromSequence(sequence));
            SetCommonProperties(message);

            message = AmqpAnnotatedMessage.FromBytes(message.ToBytes());

            Assert.That(message.Body.TryGetSequence(out IEnumerable<IList<object>> receivedData), Is.True);
            var outerEnum = receivedData.GetEnumerator();
            foreach (IList<object> seq in sequence)
            {
                outerEnum.MoveNext();
                var innerEnum = outerEnum.Current.GetEnumerator();
                foreach (object elem in seq)
                {
                    innerEnum.MoveNext();
                    Assert.That(innerEnum.Current, Is.EqualTo(elem));
                }
            }
            AssertCommonProperties(message);
        }

        [Test]
        public void ToAmqpMessagePopulatesSimpleApplicationProperties()
        {
            var annotatedMessage = new AmqpAnnotatedMessage(AmqpMessageBody.FromData(new ReadOnlyMemory<byte>[] { new byte[] { 0x11, 0x22, 0x33 } }));

            foreach (var value in s_simpleApplicationPropertyValues)
            {
                annotatedMessage.ApplicationProperties.Add($"{value.GetType().Name}Property", value);
            }

            using AmqpMessage message = ToAmqpMessage(annotatedMessage);

            Assert.That(message, Is.Not.Null, "The AMQP message should have been created.");
            Assert.That(message.ApplicationProperties, Is.Not.Null, "The AMQP message should have a set of application properties.");

            // The collection comparisons built into the test assertions do not recognize
            // the property sets as equivalent, but a manual inspection proves the properties exist
            // in both.

            foreach (var property in annotatedMessage.ApplicationProperties.Keys)
            {
                var containsValue = message.ApplicationProperties.Map.TryGetValue(property, out object value);

                Assert.That(containsValue, Is.True, $"The message properties did not contain: [{property}]");
                Assert.That(value, Is.EqualTo(annotatedMessage.ApplicationProperties[property]), $"The property value did not match for: [{property}]");
            }
        }

        [Test]
        [TestCase("http://www.server.com/path/stuff/thing.json")]
        [TestCase("/path/stuff/thing.json")]
        public void ToAmqpMessageHandlesRelativeAndAbsoluteUris(string uriValue)
        {
            var key = "UriProperty";
            var expectedUri = new Uri(uriValue, UriKind.RelativeOrAbsolute);

            var annotatedMessage = new AmqpAnnotatedMessage(AmqpMessageBody.FromData(new ReadOnlyMemory<byte>[] { new byte[] { 0x11, 0x22, 0x33 } }));
            annotatedMessage.ApplicationProperties.Add(key, expectedUri);

            using AmqpMessage message = ToAmqpMessage(annotatedMessage);

            Assert.That(message, Is.Not.Null, "The AMQP message should have been created.");
            Assert.That(message.ApplicationProperties, Is.Not.Null, "The AMQP message should have a set of application properties.");

            var containsValue = annotatedMessage.ApplicationProperties.TryGetValue(key, out object value);
            var uriProperty = value as Uri;

            Assert.That(containsValue, Is.True, $"The message properties did not contain the Uri property");
            Assert.That(uriProperty, Is.Not.Null, "The property value was not a Uri.");
            Assert.That(uriProperty, Is.EqualTo(expectedUri), "The property value did not match.");
        }

        [Test]
        public void FromAmqpMessagePopulatesSimpleApplicationProperties()
        {
            var applicationProperties = s_simpleApplicationPropertyValues.ToDictionary(value => $"{value.GetType().Name}Property", value => value);
            var dataBody = new Data { Value = new byte[] { 0x11, 0x22, 0x33 } };

            using var message = AmqpMessage.Create(dataBody);

            foreach (KeyValuePair<string, object> pair in applicationProperties)
            {
                message.ApplicationProperties.Map.Add(pair.Key, pair.Value);
            }

            var annotatedMessage = FromAmqpMessage(message);

            Assert.That(annotatedMessage, Is.Not.Null, "The message should have been created.");
            Assert.That(annotatedMessage.ApplicationProperties.Any(), Is.True, "The message should have a set of application properties.");

            // The collection comparisons built into the test assertions do not recognize
            // the property sets as equivalent, but a manual inspection proves the properties exist
            // in both.

            foreach (var property in applicationProperties.Keys)
            {
                var containsValue = annotatedMessage.ApplicationProperties.TryGetValue(property, out object value);

                Assert.That(containsValue, Is.True, $"The message properties did not contain: [{property}]");
                Assert.That(applicationProperties[property], Is.EqualTo(value), $"The property value did not match for: [{property}]");
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

            Assert.That(annotatedMessage, Is.Not.Null, "The message should have been created.");
            Assert.That(annotatedMessage.ApplicationProperties.Any(), Is.True, "The message should have a set of application properties.");

            var containsValue = annotatedMessage.ApplicationProperties.TryGetValue(key, out object value);
            var uriProperty = value as Uri;

            Assert.That(containsValue, Is.True, $"The message properties did not contain the Uri property");
            Assert.That(uriProperty, Is.Not.Null, "The property value was not a Uri.");
            Assert.That(uriProperty, Is.EqualTo(expectedUri), "The property value did not match.");
        }

        [Test]
        [TestCaseSource(nameof(DescribedTypePropertyTestCases))]
        public void ToAmqpMessageTranslatesDescribedApplicationProperties(object typeDescriptor, object propertyValueRaw, Func<object, object> propertyValueAccessor)
        {
            var annotatedMessage = new AmqpAnnotatedMessage(AmqpMessageBody.FromData(new ReadOnlyMemory<byte>[] { new byte[] { 0x11, 0x22, 0x33 } }));
            annotatedMessage.ApplicationProperties.Add("TestProp", propertyValueRaw);

            using AmqpMessage message = ToAmqpMessage(annotatedMessage);

            Assert.That(message, Is.Not.Null, "The AMQP message should have been created.");
            Assert.That(message.ApplicationProperties, Is.Not.Null, "The AMQP message should have a set of application properties.");

            var propertyKey = annotatedMessage.ApplicationProperties.Keys.First();
            var propertyValue = propertyValueAccessor(annotatedMessage.ApplicationProperties[propertyKey]);
            var containsValue = message.ApplicationProperties.Map.TryGetValue(propertyKey, out DescribedType describedValue);

            Assert.That(containsValue, Is.True, "The message properties did not contain the property.");
            Assert.That(propertyValue, Is.EqualTo(describedValue.Value), "The property value did not match.");
            Assert.That(typeDescriptor, Is.EqualTo(describedValue.Descriptor), "The message property descriptor was incorrect.");
        }

        [TestCaseSource(nameof(DescribedTypePropertyTestCases))]
        public void FromAmqpMessagePopulateDescribedApplicationProperties(object typeDescriptor, object propertyValueRaw, Func<object, object> propertyValueAccessor)
        {
            var dataBody = new Data { Value = new byte[] { 0x11, 0x22, 0x33 } };
            using var message = AmqpMessage.Create(dataBody);

            var describedProperty = new DescribedType(typeDescriptor, propertyValueAccessor(propertyValueRaw));
            message.ApplicationProperties.Map.Add(typeDescriptor.ToString(), describedProperty);

            var annotatedMessage = FromAmqpMessage(message);

            Assert.That(annotatedMessage, Is.Not.Null, "The message should have been created.");
            Assert.That(annotatedMessage.ApplicationProperties.Any(), Is.True, "The message should have a set of application properties.");

            var containsValue = annotatedMessage.ApplicationProperties.TryGetValue(typeDescriptor.ToString(), out object value);
            Assert.That(containsValue, Is.True, $"The event properties did not contain the described property.");
            Assert.That(propertyValueRaw, Is.EqualTo(value), $"The property value did not match.");
        }

        [Test]
        [TestCaseSource(nameof(StreamPropertyTestCases))]
        public void ToAmqpMessageTranslatesStreamApplicationProperties(object propertyStream, byte[] contents)
        {
            var annotatedMessage = new AmqpAnnotatedMessage(AmqpMessageBody.FromData(new ReadOnlyMemory<byte>[] { new byte[] { 0x11, 0x22, 0x33 } }));
            annotatedMessage.ApplicationProperties.Add("TestProp", propertyStream);

            using AmqpMessage message = ToAmqpMessage(annotatedMessage);

            Assert.That(message, Is.Not.Null, "The AMQP message should have been created.");
            Assert.That(message.ApplicationProperties, Is.Not.Null, "The AMQP message should have a set of application properties.");

            var propertyKey = annotatedMessage.ApplicationProperties.Keys.First();
            var containsValue = message.ApplicationProperties.Map.TryGetValue(propertyKey, out object streamValue);

            Assert.That(containsValue, Is.True, "The message properties did not contain the property.");
            Assert.That(streamValue, Is.InstanceOf<ArraySegment<byte>>(), "The message property stream was not read correctly.");
            Assert.That(contents, Is.EqualTo(((ArraySegment<byte>)streamValue).ToArray()), "The property value did not match.");
        }

        [Test]
        [TestCaseSource(nameof(BinaryPropertyTestCases))]
        public void ToAmqpMessageTranslatesBinaryApplicationProperties(object property, object contents)
        {
            var annotatedMessage = new AmqpAnnotatedMessage(AmqpMessageBody.FromData(new ReadOnlyMemory<byte>[] { new byte[] { 0x11, 0x22, 0x33 } }));
            annotatedMessage.ApplicationProperties.Add("TestProp", property);

            using AmqpMessage message = ToAmqpMessage(annotatedMessage);

            Assert.That(message, Is.Not.Null, "The AMQP message should have been created.");
            Assert.That(message.ApplicationProperties, Is.Not.Null, "The AMQP message should have a set of application properties.");

            var propertyKey = annotatedMessage.ApplicationProperties.Keys.First();
            var containsValue = message.ApplicationProperties.Map.TryGetValue(propertyKey, out object streamValue);

            Assert.That(containsValue, Is.True, "The message properties did not contain the property.");
            Assert.That(streamValue, Is.InstanceOf<ArraySegment<byte>>(), "The message property stream was not read correctly.");
            Assert.That(contents, Is.EqualTo(((ArraySegment<byte>)streamValue).ToArray()), "The property value did not match.");
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

            Assert.That(annotatedMessage, Is.Not.Null, "The message should have been created.");
            Assert.That(annotatedMessage.ApplicationProperties.Any(), Is.True, "The message should have a set of application properties.");

            var containsValue = annotatedMessage.ApplicationProperties.TryGetValue(propertyKey, out var messageValue);
            Assert.That(containsValue, Is.True, $"The message properties should contain the property.");
            Assert.That(contents, Is.EqualTo(messageValue), "The property value was incorrect.");
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

            Assert.That(annotatedMessage, Is.Not.Null, "The message should have been created.");
            Assert.That(annotatedMessage.ApplicationProperties.Any(), Is.True, "The message should have a set of application properties.");

            var containsValue = annotatedMessage.ApplicationProperties.TryGetValue(propertyKey, out var messageValue);
            Assert.That(containsValue, Is.True, $"The message properties should contain the property.");
            Assert.That(propertyValue.Skip(1).Take(2), Is.EqualTo(messageValue), "The property value was incorrect.");
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

            Assert.That(annotatedMessage, Is.Not.Null, "The message should have been created.");
            Assert.That(annotatedMessage.ApplicationProperties.Any(), Is.False, "The message should not have a set of application properties.");

            var containsValue = annotatedMessage.ApplicationProperties.TryGetValue(typeDescriptor.ToString(), out var messageValue);
            Assert.That(containsValue, Is.False, "The message properties should not contain the described property.");
        }

        [Test]
        public void TimeToLiveIsOverriddenOnReceivedMessageByAbsoluteExpiryTime()
        {
            var amqpMessage =
                ToAmqpMessage(new AmqpAnnotatedMessage(AmqpMessageBody.FromValue(5)));

            amqpMessage.Properties.CreationTime = DateTime.UtcNow;
            amqpMessage.Properties.AbsoluteExpiryTime = DateTime.MaxValue;
            amqpMessage.Header.Ttl = (uint)TimeSpan.FromDays(49).TotalMilliseconds;

            var annotatedMessage = FromAmqpMessage(amqpMessage);

            // The expected TTL will disregard the TTL set on the header and instead calculate it based on expiry time and creation time.
            var expectedTtl = amqpMessage.Properties.AbsoluteExpiryTime - amqpMessage.Properties.CreationTime;
            Assert.That(annotatedMessage.Header.TimeToLive, Is.EqualTo(expectedTtl));
        }

        [Test]
        public void TimeToLiveIsNotOverriddenWhenNoAbsoluteExpiryTimePresent()
        {
            var amqpMessage =
                ToAmqpMessage(new AmqpAnnotatedMessage(AmqpMessageBody.FromValue(5)));

            amqpMessage.Properties.CreationTime = DateTime.UtcNow;
            amqpMessage.Header.Ttl = (uint)TimeSpan.FromDays(49).TotalMilliseconds;

            var annotatedMessage = FromAmqpMessage(amqpMessage);

            Assert.That(annotatedMessage.Header.TimeToLive, Is.EqualTo(TimeSpan.FromDays(49)));
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

            Assert.That(amqpMessage.Header.Ttl, Is.EqualTo(uint.MaxValue));
            Assert.That(amqpMessage.Properties.AbsoluteExpiryTime, Is.EqualTo(amqpMessage.Properties.CreationTime + TimeSpan.FromDays(100)));

            var output = FromAmqpMessage(amqpMessage);

            Assert.That(output.Header.TimeToLive, Is.EqualTo(TimeSpan.FromDays(100)));
            Assert.That(output.Properties.CreationTime!.Value.UtcDateTime, Is.EqualTo(amqpMessage.Properties.CreationTime));
            Assert.That(output.Properties.AbsoluteExpiryTime!.Value.UtcDateTime, Is.EqualTo(amqpMessage.Properties.AbsoluteExpiryTime));
        }

        [Test]
        public void AbsoluteExpiryTimeAndCreationTimeNotSetWhenNoTtl()
        {
            var input = new AmqpAnnotatedMessage(AmqpMessageBody.FromValue(5));
            var amqpMessage = ToAmqpMessage(input);

            Assert.That(amqpMessage.Header.Ttl, Is.Null);
            Assert.That(amqpMessage.Properties.CreationTime, Is.Null);
            Assert.That(amqpMessage.Properties.AbsoluteExpiryTime, Is.Null);
        }

        [Test]
        public void AbsoluteExpiryTimeAndCreationTimeSetOnMessageWhenSetExplicitly()
        {
            var input = new AmqpAnnotatedMessage(AmqpMessageBody.FromValue(5));
            var now = DateTime.UtcNow;
            input.Properties.CreationTime = now;
            input.Properties.AbsoluteExpiryTime = now + TimeSpan.FromDays(1);
            var amqpMessage = ToAmqpMessage(input);

            Assert.That(amqpMessage.Header.Ttl, Is.Null);
            Assert.That(amqpMessage.Properties.CreationTime, Is.EqualTo(now));
            Assert.That(amqpMessage.Properties.AbsoluteExpiryTime, Is.EqualTo(now + TimeSpan.FromDays(1)));
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

            Assert.That(amqpMessage.Header.Ttl, Is.EqualTo(TimeSpan.FromDays(7).TotalMilliseconds));
            Assert.That(amqpMessage.Properties.AbsoluteExpiryTime, Is.EqualTo(amqpMessage.Properties.CreationTime + TimeSpan.FromDays(7)));
        }

        private static void AssertCommonProperties(AmqpAnnotatedMessage message)
        {
            Assert.That(message.ApplicationProperties["applicationKey"], Is.EqualTo("applicationValue"));
            Assert.That(message.DeliveryAnnotations["deliveryKey"], Is.EqualTo("deliveryValue"));
            Assert.That(message.MessageAnnotations["messageKey"], Is.EqualTo("messageValue"));
            Assert.That(message.Footer["footerKey"], Is.EqualTo("footerValue"));
            Assert.That(message.Header.DeliveryCount, Is.EqualTo(1));
            Assert.That(message.Header.Durable, Is.True);
            Assert.That(message.Header.FirstAcquirer, Is.True);
            Assert.That(message.Header.Priority, Is.EqualTo(1));
            Assert.That(message.Header.TimeToLive, Is.EqualTo(TimeSpan.FromSeconds(60)));
            // because AMQP only has millisecond resolution, allow for up to a 1ms difference when round-tripping
            Assert.That(message.Properties.CreationTime, Is.Not.Null);
            // AbsoluteExpiryTime is set based on TTL and CreationTime for outgoing messages
            Assert.That(message.Properties.CreationTime + TimeSpan.FromSeconds(60), Is.EqualTo(message.Properties.AbsoluteExpiryTime.Value).Within(1).Milliseconds);
            Assert.That(message.Properties.ContentEncoding, Is.EqualTo("compress"));
            Assert.That(message.Properties.ContentType, Is.EqualTo("application/json"));
            Assert.That(message.Properties.CorrelationId.ToString(), Is.EqualTo("correlationId"));
            Assert.That(message.Properties.GroupId, Is.EqualTo("groupId"));
            Assert.That(message.Properties.GroupSequence, Is.EqualTo(5));
            Assert.That(message.Properties.MessageId.ToString(), Is.EqualTo("messageId"));
            Assert.That(message.Properties.ReplyTo.ToString(), Is.EqualTo("replyTo"));
            Assert.That(message.Properties.ReplyToGroupId, Is.EqualTo("replyToGroupId"));
            Assert.That(message.Properties.Subject, Is.EqualTo("subject"));
            Assert.That(message.Properties.To.ToString(), Is.EqualTo("to"));
            Assert.That(Encoding.UTF8.GetString(message.Properties.UserId.Value.ToArray()), Is.EqualTo("userId"));
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
