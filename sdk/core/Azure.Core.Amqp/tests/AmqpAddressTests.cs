// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Core.Amqp.Tests
{
    public class AmqpAddressTests
    {
        [Test]
        public void CanCreateFromString()
        {
            var address = new AmqpAddress("address");
            Assert.That(address.ToString(), Is.EqualTo("address"));
            Assert.That(address.GetHashCode(), Is.EqualTo("address".GetHashCode()));
            Assert.That(address, Is.EqualTo(new AmqpAddress("address")));
            Assert.That(address, Is.EqualTo((object)new AmqpAddress("address")));
            Assert.That(address.Equals(new AmqpMessageId("messageId2")), Is.False);
        }

        [Test]
        public void CannotCreateFromNullAddress()
        {
            Assert.That(
                () => new AmqpAddress(null),
                Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
