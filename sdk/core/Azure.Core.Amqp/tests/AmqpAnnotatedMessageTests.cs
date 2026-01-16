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

            Assert.That(message.Body.BodyType, Is.EqualTo(AmqpMessageBodyType.Data));
            Assert.That(message.Body.TryGetData(out IEnumerable<ReadOnlyMemory<byte>> body), Is.True);
            Assert.That(Encoding.UTF8.GetString(body.First().ToArray()), Is.EqualTo("some data"));
            Assert.That(message.ApplicationProperties["applicationKey"], Is.EqualTo("applicationValue"));
            Assert.That(message.DeliveryAnnotations["deliveryKey"], Is.EqualTo("deliveryValue"));
            Assert.That(message.MessageAnnotations["messageKey"], Is.EqualTo("messageValue"));
            Assert.That(message.Footer["footerKey"], Is.EqualTo("footerValue"));
            Assert.That(message.Header.DeliveryCount, Is.EqualTo(1));
            Assert.That(message.Header.Durable, Is.True);
            Assert.That(message.Header.FirstAcquirer, Is.True);
            Assert.That(message.Header.Priority, Is.EqualTo(1));
            Assert.That(message.Header.TimeToLive, Is.EqualTo(TimeSpan.FromSeconds(60)));
            Assert.That(message.Properties.AbsoluteExpiryTime, Is.EqualTo(time));
            Assert.That(message.Properties.ContentEncoding, Is.EqualTo("compress"));
            Assert.That(message.Properties.ContentType, Is.EqualTo("application/json"));
            Assert.That(message.Properties.CorrelationId.ToString(), Is.EqualTo("correlationId"));
            Assert.That(message.Properties.CreationTime, Is.EqualTo(time));
            Assert.That(message.Properties.GroupId, Is.EqualTo("groupId"));
            Assert.That(message.Properties.GroupSequence, Is.EqualTo(5));
            Assert.That(message.Properties.MessageId.ToString(), Is.EqualTo("messageId"));
            Assert.That(message.Properties.ReplyTo.ToString(), Is.EqualTo("replyTo"));
            Assert.That(message.Properties.ReplyToGroupId, Is.EqualTo("replyToGroupId"));
            Assert.That(message.Properties.Subject, Is.EqualTo("subject"));
            Assert.That(message.Properties.To.ToString(), Is.EqualTo("to"));
            Assert.That(Encoding.UTF8.GetString(message.Properties.UserId.Value.ToArray()), Is.EqualTo("userId"));
        }

        [Test]
        public void HeaderIsCreatedOnDemand()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);
            Assert.That(message.HasSection(AmqpMessageSection.Header), Is.False);

            message.Header.DeliveryCount = 99;
            Assert.That(message.HasSection(AmqpMessageSection.Header), Is.True);
            Assert.That(message.Header, Is.Not.Null);
        }

        [Test]
        public void DeliveryAnnotationsAreCreatedOnDemand()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);
            Assert.That(message.HasSection(AmqpMessageSection.DeliveryAnnotations), Is.False);

            message.DeliveryAnnotations.Add("test", new object());
            Assert.That(message.HasSection(AmqpMessageSection.DeliveryAnnotations), Is.True);
            Assert.That(message.DeliveryAnnotations, Is.Not.Null);
        }

        [Test]
        public void MessageAnnotationsAreCreatedOnDemand()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);
            Assert.That(message.HasSection(AmqpMessageSection.MessageAnnotations), Is.False);

            message.MessageAnnotations.Add("test", new object());
            Assert.That(message.HasSection(AmqpMessageSection.MessageAnnotations), Is.True);
            Assert.That(message.MessageAnnotations, Is.Not.Null);
        }

        [Test]
        public void PropertiesAreCreatedOnDemand()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);
            Assert.That(message.HasSection(AmqpMessageSection.Properties), Is.False);

            message.Properties.ContentType = "test/unit";
            Assert.That(message.HasSection(AmqpMessageSection.Properties), Is.True);
            Assert.That(message.Properties, Is.Not.Null);
        }

        [Test]
        public void ApplicationPropertiesAreCreatedOnDemand()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);
            Assert.That(message.HasSection(AmqpMessageSection.ApplicationProperties), Is.False);

            message.ApplicationProperties.Add("test", new object());
            Assert.That(message.HasSection(AmqpMessageSection.ApplicationProperties), Is.True);
            Assert.That(message.ApplicationProperties, Is.Not.Null);
        }

        [Test]
        public void FooterIsCreatedOnDemand()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);
            Assert.That(message.HasSection(AmqpMessageSection.Footer), Is.False);

            message.Footer.Add("test", new object());
            Assert.That(message.HasSection(AmqpMessageSection.Footer), Is.True);
            Assert.That(message.Footer, Is.Not.Null);
        }

        [Test]
        public void BodyIsDetectedByHasSection()
        {
            var message = new AmqpAnnotatedMessage(EmptyDataBody);

            message.Body = null;
            Assert.That(message.HasSection(AmqpMessageSection.Body), Is.False);

            message.Body = AmqpMessageBody.FromValue("this is a string value");
            Assert.That(message.HasSection(AmqpMessageSection.Body), Is.True);
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
