// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Azure.Core.Amqp.Tests
{
    public class AmqpAnnotatedMessageTests
    {
        private static readonly AmqpMessageBody EmptyDataBody = AmqpMessageBody.FromData(new ReadOnlyMemory<byte>[] { Array.Empty<byte>() });

        [Test]
        public void CanCreateAnnotatedMessage()
        {
            var message = new AmqpAnnotatedMessage(new AmqpMessageBody(new ReadOnlyMemory<byte>[] { Encoding.UTF8.GetBytes("some data") }));
            message.ApplicationProperties.Add("applicationKey", "applicationValue");
            message.DeliveryAnnotations.Add("deliveryKey", "deliveryValue");
            message.MessageAnnotations.Add("messageKey", "messageValue");
            message.Footer.Add("footerKey", "footerValue");
            message.Header.DeliveryCount = 1;
            message.Header.Durable = true;
            message.Header.FirstAcquirer = true;
            message.Header.Priority = 1;
            message.Header.TimeToLive = TimeSpan.FromSeconds(60);
            DateTimeOffset time = DateTimeOffset.Now.AddDays(1);
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

            Assert.AreEqual(AmqpMessageBodyType.Data, message.Body.BodyType);
            Assert.IsTrue(message.Body.TryGetData(out IEnumerable<ReadOnlyMemory<byte>> body));
            Assert.AreEqual("some data", Encoding.UTF8.GetString(body.First().ToArray()));
            Assert.AreEqual("applicationValue", message.ApplicationProperties["applicationKey"]);
            Assert.AreEqual("deliveryValue", message.DeliveryAnnotations["deliveryKey"]);
            Assert.AreEqual("messageValue", message.MessageAnnotations["messageKey"]);
            Assert.AreEqual("footerValue", message.Footer["footerKey"]);
            Assert.AreEqual(1, message.Header.DeliveryCount);
            Assert.IsTrue(message.Header.Durable);
            Assert.IsTrue(message.Header.FirstAcquirer);
            Assert.AreEqual(1, message.Header.Priority);
            Assert.AreEqual(TimeSpan.FromSeconds(60), message.Header.TimeToLive);
            Assert.AreEqual(time, message.Properties.AbsoluteExpiryTime);
            Assert.AreEqual("compress", message.Properties.ContentEncoding);
            Assert.AreEqual("application/json", message.Properties.ContentType);
            Assert.AreEqual("correlationId", message.Properties.CorrelationId.ToString());
            Assert.AreEqual(time, message.Properties.CreationTime);
            Assert.AreEqual("groupId", message.Properties.GroupId);
            Assert.AreEqual(5, message.Properties.GroupSequence);
            Assert.AreEqual("messageId", message.Properties.MessageId.ToString());
            Assert.AreEqual("replyTo", message.Properties.ReplyTo.ToString());
            Assert.AreEqual("replyToGroupId", message.Properties.ReplyToGroupId);
            Assert.AreEqual("subject", message.Properties.Subject);
            Assert.AreEqual("to", message.Properties.To.ToString());
            Assert.AreEqual("userId", Encoding.UTF8.GetString(message.Properties.UserId.Value.ToArray()));
        }

        [Test]
        public void HeaderIsCreatedOnDemand()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);
            Assert.False(message.HasSection(AmqpMessageSection.Header));

            message.Header.DeliveryCount = 99;
            Assert.True(message.HasSection(AmqpMessageSection.Header));
            Assert.NotNull(message.Header);
        }

        [Test]
        public void DeliveryAnnotationsAreCreatedOnDemand()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);
            Assert.False(message.HasSection(AmqpMessageSection.DeliveryAnnotations));

            message.DeliveryAnnotations.Add("test", new object());
            Assert.True(message.HasSection(AmqpMessageSection.DeliveryAnnotations));
            Assert.NotNull(message.DeliveryAnnotations);
        }

        [Test]
        public void MessageAnnotationsAreCreatedOnDemand()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);
            Assert.False(message.HasSection(AmqpMessageSection.MessageAnnotations));

            message.MessageAnnotations.Add("test", new object());
            Assert.True(message.HasSection(AmqpMessageSection.MessageAnnotations));
            Assert.NotNull(message.MessageAnnotations);
        }

        [Test]
        public void PropertiesAreCreatedOnDemand()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);
            Assert.False(message.HasSection(AmqpMessageSection.Properties));

            message.Properties.ContentType = "test/unit";
            Assert.True(message.HasSection(AmqpMessageSection.Properties));
            Assert.NotNull(message.Properties);
        }

        [Test]
        public void ApplicationPropertiesAreCreatedOnDemand()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);
            Assert.False(message.HasSection(AmqpMessageSection.ApplicationProperties));

            message.ApplicationProperties.Add("test", new object());
            Assert.True(message.HasSection(AmqpMessageSection.ApplicationProperties));
            Assert.NotNull(message.ApplicationProperties);
        }

        [Test]
        public void FooterIsCreatedOnDemand()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);
            Assert.False(message.HasSection(AmqpMessageSection.Footer));

            message.Footer.Add("test", new object());
            Assert.True(message.HasSection(AmqpMessageSection.Footer));
            Assert.NotNull(message.Footer);
        }

        [Test]
        public void BodyIsDetectedByHasSection()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);

            message.Body = null;
            Assert.False(message.HasSection(AmqpMessageSection.Body));

            message.Body = AmqpMessageBody.FromValue("this is a string value");
            Assert.True(message.HasSection(AmqpMessageSection.Body));
        }

        [Test]
        public void HasSectionValidatesTheSection()
        {
            var invalidSection = (AmqpMessageSection)int.MinValue;
            var message = new AmqpAnnotatedMessage(EmptyDataBody);

            Assert.Throws<ArgumentException>(() => message.HasSection(invalidSection));
        }
    }
}
