// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Message
{
    public class MessageTests : ServiceBusTestBase
    {
        [Test]
        [TestCase(null)]
        [TestCase("123")]
        [TestCase("jøbber-nå")]
        public void MessageToString(string id)
        {
            var message = new ServiceBusMessage();
            if (id != null)
            {
                message.MessageId = id;
            }
            var result = message.ToString();
            Assert.AreEqual($"{{MessageId:{id}}}", result);
        }

        [Test]
        public void SettingNullMessageIdThrows()
        {
            var message = new ServiceBusMessage();
            Assert.That(() => message.MessageId = null, Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void SettingEmptyMessageIdThrows()
        {
            var message = new ServiceBusMessage();
            Assert.That(() => message.MessageId = "", Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void SetMessageBodyToString()
        {
            var messageBody = "some message";
            var message = new ServiceBusMessage(messageBody);
            Assert.AreEqual(message.Body.ToString(), messageBody);
            Assert.AreEqual(message.Body.ToString(), messageBody);

            message = new ServiceBusMessage(messageBody, Encoding.UTF32);
            Assert.AreEqual(message.Body.ToString(Encoding.UTF32), messageBody);
            Assert.AreNotEqual(message.Body.ToString(), messageBody);
        }
    }
}
