// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

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
            DateTimeOffset.Parse("3/24/21").UtcDateTime,
            new DateTime[] {DateTimeOffset.Parse("3/24/21").UtcDateTime },
            DateTimeOffset.Parse("3/24/21"),
            new DateTimeOffset[] {DateTimeOffset.Parse("3/24/21") },
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
            new Dictionary<string, DateTime> {{ "key", DateTimeOffset.Parse("3/24/21").UtcDateTime } },
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
            Enumerable.Repeat(new object[] { DateTimeOffset.Parse("3/24/21").UtcDateTime, true }, 2),
            new List<IList<object>> { new List<object> { "first", 1}, new List<object> { "second", 2 } }
        };

        [Test]
        public void CanRoundTripDataMessage()
        {
            var message = new AmqpAnnotatedMessage(AmqpMessageBody.FromData(new ReadOnlyMemory<byte>[] { Encoding.UTF8.GetBytes("some data") }));
            DateTimeOffset time = DateTimeOffset.Now.AddDays(1);

            SetCommonProperties(message, time);

            message = AmqpAnnotatedMessage.FromBytes(message.ToBytes());
            Assert.AreEqual(AmqpMessageBodyType.Data, message.Body.BodyType);
            Assert.IsTrue(message.Body.TryGetData(out IEnumerable<ReadOnlyMemory<byte>> body));
            Assert.AreEqual("some data", Encoding.UTF8.GetString(body.First().ToArray()));

            AssertCommonProperties(message, time);
        }

        [Test]
        [TestCaseSource(nameof(s_amqpValues))]
        public void CanRoundTripValueBodyMessages(object value)
        {
            var message = new AmqpAnnotatedMessage(AmqpMessageBody.FromValue(value));
            DateTimeOffset time = DateTimeOffset.Now.AddDays(1);
            SetCommonProperties(message, time);

            message = AmqpAnnotatedMessage.FromBytes(message.ToBytes());

            Assert.IsTrue(message.Body.TryGetValue(out var receivedData));
            Assert.AreEqual(value, receivedData);
            AssertCommonProperties(message, time);
        }

        [Test]
        [TestCaseSource(nameof(s_amqpSequences))]
        public void CanRoundTripSequenceBodyMessages(IEnumerable<IList<object>> sequence)
        {
            var message = new AmqpAnnotatedMessage(AmqpMessageBody.FromSequence(sequence));
            DateTimeOffset time = DateTimeOffset.Now.AddDays(1);
            SetCommonProperties(message, time);

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
            AssertCommonProperties(message, time);
        }

        private static void AssertCommonProperties(AmqpAnnotatedMessage message, DateTimeOffset time)
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
            Assert.AreEqual(time.ToUnixTimeMilliseconds(), message.Properties.AbsoluteExpiryTime.Value.ToUnixTimeMilliseconds());
            Assert.AreEqual("compress", message.Properties.ContentEncoding);
            Assert.AreEqual("application/json", message.Properties.ContentType);
            Assert.AreEqual("correlationId", message.Properties.CorrelationId.ToString());
            Assert.AreEqual(time.ToUnixTimeMilliseconds(), message.Properties.CreationTime.Value.ToUnixTimeMilliseconds());
            Assert.AreEqual("groupId", message.Properties.GroupId);
            Assert.AreEqual(5, message.Properties.GroupSequence);
            Assert.AreEqual("messageId", message.Properties.MessageId.ToString());
            Assert.AreEqual("replyTo", message.Properties.ReplyTo.ToString());
            Assert.AreEqual("replyToGroupId", message.Properties.ReplyToGroupId);
            Assert.AreEqual("subject", message.Properties.Subject);
            Assert.AreEqual("to", message.Properties.To.ToString());
            Assert.AreEqual("userId", Encoding.UTF8.GetString(message.Properties.UserId.Value.ToArray()));
        }

        private static void SetCommonProperties(AmqpAnnotatedMessage message, DateTimeOffset time)
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
            message.Properties.AbsoluteExpiryTime = time;
            message.Properties.ContentEncoding = "compress";
            message.Properties.ContentType = "application/json";
            message.Properties.CorrelationId = new AmqpMessageId("correlationId");
            message.Properties.CreationTime = time;
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