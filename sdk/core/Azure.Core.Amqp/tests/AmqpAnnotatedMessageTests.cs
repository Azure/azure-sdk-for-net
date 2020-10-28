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
        [Test]
        public void CopyConstructorCopies()
        {
            var message = new AmqpAnnotatedMessage(
                new BinaryData[] { BinaryData.FromString("some data") });
            message.ApplicationProperties.Add("applicationKey", "applicationValue");
            message.DeliveryAnnotations.Add("deliveryKey", "deliveryValue");
            message.MessageAnnotations.Add("messageKey", "messageValue");
            message.Footer.Add("footerKey", "footerValue");
            message.Header.DeliveryCount = 1;
            message.Header.Durable = true;
            message.Header.FirstAcquirer = true;
            message.Header.Priority = 1;
            message.Header.TimeToLive = TimeSpan.FromSeconds(60);
            message.Properties.AbsoluteExpiryTime = DateTimeOffset.Now.AddDays(1);
            message.Properties.ContentEncoding = "compress";
            message.Properties.ContentType = "application/json";
            message.Properties.CorrelationId = "correlationId";
            message.Properties.CreationTime = DateTimeOffset.Now;
            message.Properties.GroupId = "groupId";
            message.Properties.GroupSequence = 5;
            message.Properties.MessageId = "messageId";
            message.Properties.ReplyTo = "replyTo";
            message.Properties.ReplyToGroupId = "replyToGroupId";
            message.Properties.Subject = "subject";
            message.Properties.To = "to";
            message.Properties.UserId = BinaryData.FromString("userId");
            var copy = new AmqpAnnotatedMessage(message);
            Assert.AreEqual(((AmqpDataMessageBody)message.Body).Data.ToArray(), ((AmqpDataMessageBody)copy.Body).Data.ToArray());
            Assert.AreEqual(message.ApplicationProperties["applicationKey"], copy.ApplicationProperties["applicationKey"]);
            Assert.AreEqual(message.DeliveryAnnotations["deliveryKey"], copy.DeliveryAnnotations["deliveryKey"]);
            Assert.AreEqual(message.MessageAnnotations["messageKey"], copy.MessageAnnotations["messageKey"]);
            Assert.AreEqual(message.Footer["footerKey"], copy.Footer["footerKey"]);
            Assert.AreEqual(message.Header.DeliveryCount, copy.Header.DeliveryCount);
            Assert.AreEqual(message.Header.Durable, copy.Header.Durable);
            Assert.AreEqual(message.Header.FirstAcquirer, copy.Header.FirstAcquirer);
            Assert.AreEqual(message.Header.Priority, copy.Header.Priority);
            Assert.AreEqual(message.Header.TimeToLive, copy.Header.TimeToLive);
            Assert.AreEqual(message.Properties.AbsoluteExpiryTime, copy.Properties.AbsoluteExpiryTime);
            Assert.AreEqual(message.Properties.ContentEncoding, copy.Properties.ContentEncoding);
            Assert.AreEqual(message.Properties.ContentType, copy.Properties.ContentType);
            Assert.AreEqual(message.Properties.CorrelationId, copy.Properties.CorrelationId);
            Assert.AreEqual(message.Properties.AbsoluteExpiryTime, copy.Properties.AbsoluteExpiryTime);
            Assert.AreEqual(message.Properties.CreationTime, copy.Properties.CreationTime);
            Assert.AreEqual(message.Properties.GroupId, copy.Properties.GroupId);
            Assert.AreEqual(message.Properties.GroupSequence, copy.Properties.GroupSequence);
            Assert.AreEqual(message.Properties.MessageId, copy.Properties.MessageId);
            Assert.AreEqual(message.Properties.ReplyTo, copy.Properties.ReplyTo);
            Assert.AreEqual(message.Properties.ReplyToGroupId, copy.Properties.ReplyToGroupId);
            Assert.AreEqual(message.Properties.Subject, copy.Properties.Subject);
            Assert.AreEqual(message.Properties.To, copy.Properties.To);
            Assert.AreEqual(message.Properties.UserId, copy.Properties.UserId);
        }

        [Test]
        public void CopyConstructorThrowsIfNull()
        {
            Assert.That(
                () => new AmqpAnnotatedMessage(messageToCopy: null),
                Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
