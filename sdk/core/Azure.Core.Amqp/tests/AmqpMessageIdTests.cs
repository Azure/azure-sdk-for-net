// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Azure.Core.Amqp.Tests
{
    public class AmqpMessageIdTests
    {
        [Test]
        public void CanCreateFromString()
        {
            var messageId = new AmqpMessageId("messageId");
            Assert.That(messageId.ToString(), Is.EqualTo("messageId"));

            Assert.That(messageId, Is.EqualTo(new AmqpMessageId("messageId")));
            Assert.That(messageId, Is.EqualTo((object)new AmqpMessageId("messageId")));
            Assert.That(messageId.Equals(new AmqpMessageId("messageId2")), Is.False);

            Assert.That(messageId.Equals("messageId"), Is.True);
            Assert.That(messageId.Equals("messageId2"), Is.False);
            Assert.That(messageId.Equals(Encoding.UTF8.GetBytes("messageId")), Is.False);
            Assert.That(messageId.Equals(1), Is.False);
            Assert.That(messageId.Equals(Guid.NewGuid()), Is.False);
            Assert.That(messageId.Equals((object)"messageId"), Is.False);
        }

        [Test]
        public void CannotCreateFromNullMessageId()
        {
            Assert.That(
                () => new AmqpMessageId(null),
                Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
