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
            Assert.AreEqual("messageId", messageId.ToString());

            Assert.True(messageId.Equals(new AmqpMessageId("messageId")));
            Assert.True(messageId.Equals((object) new AmqpMessageId("messageId")));
            Assert.False(messageId.Equals(new AmqpMessageId("messageId2")));

            Assert.True(messageId.Equals("messageId"));
            Assert.False(messageId.Equals("messageId2"));
            Assert.False(messageId.Equals(Encoding.UTF8.GetBytes("messageId")));
            Assert.False(messageId.Equals(1));
            Assert.False(messageId.Equals(Guid.NewGuid()));
            Assert.False(messageId.Equals((object)"messageId"));
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
