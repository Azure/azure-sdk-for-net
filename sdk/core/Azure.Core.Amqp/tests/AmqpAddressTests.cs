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
            Assert.AreEqual("address", address.ToString());
            Assert.AreEqual("address".GetHashCode(), address.GetHashCode());
            Assert.True(address.Equals(new AmqpAddress("address")));
            Assert.True(address.Equals((object)new AmqpAddress("address")));
            Assert.False(address.Equals(new AmqpMessageId("messageId2")));
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
