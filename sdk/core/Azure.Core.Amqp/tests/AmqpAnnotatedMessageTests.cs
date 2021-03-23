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
    }
}
