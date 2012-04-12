//
// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Microsoft.WindowsAzure.ServiceLayer.ServiceBus;

namespace Microsoft.WindowsAzure.ServiceLayer.UnitTests.MsTest.ServiceBusTests
{
    /// <summary>
    /// Tests for message properties.
    /// </summary>
    [TestClass]
    public sealed class MessagePropertiesTests
    {
        private string _queueName;                          // Test queue.
        private MessageReceiver _receiver;                  // Receiver for queue messages.

        /// <summary>
        /// Initializes the test.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            _queueName = Configuration.GetUniqueQueueName();
            Configuration.ServiceBus.CreateQueueAsync(_queueName).AsTask().Wait();
            _receiver = Configuration.ServiceBus.CreateMessageReceiver(_queueName);
        }

        /// <summary>
        /// Cleans up after test run.
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            Configuration.ServiceBus.DeleteQueueAsync(_queueName).AsTask().Wait();
            _queueName = null;
            _receiver = null;
        }

        /// <summary>
        /// Tests setting and reading message properties.
        /// </summary>
        [TestMethod]
        public void MessageProperties()
        {
            DateTimeOffset originalDateTime = DateTimeOffset.UtcNow;
            BrokeredMessageSettings messageSettings = MessageHelper.CreateMessage("This is a test.");

            messageSettings.Properties.Add("StringProperty", "Test");
            messageSettings.Properties.Add("BoolPropertyTrue", true);
            messageSettings.Properties.Add("BoolPropertyFalse", false);
            messageSettings.Properties.Add("NullProperty", null);
            messageSettings.Properties.Add("NumberProperty", 123);
            messageSettings.Properties.Add("TimeProperty", originalDateTime);

            Configuration.ServiceBus.SendMessageAsync(_queueName, messageSettings).AsTask().Wait();
            BrokeredMessageDescription message = _receiver.GetMessageAsync(TimeSpan.FromSeconds(10)).AsTask().Result;

            Assert.IsNotNull(message.Properties);
            Assert.IsTrue(message.Properties.ContainsKey("StringProperty"));
            Assert.IsTrue(message.Properties.ContainsKey("BoolPropertyTrue"));
            Assert.IsTrue(message.Properties.ContainsKey("BoolPropertyFalse"));
            Assert.IsTrue(message.Properties.ContainsKey("NumberProperty"));
            Assert.IsTrue(message.Properties.ContainsKey("TimeProperty"));
            // The server does not store/return null properties.
            Assert.IsFalse(message.Properties.ContainsKey("NullProperty"));

            Assert.AreEqual((string)message.Properties["StringProperty"], "Test", false, CultureInfo.InvariantCulture);
            Assert.AreEqual((bool)message.Properties["BoolPropertyTrue"], true);
            Assert.AreEqual((bool)message.Properties["BoolPropertyFalse"], false);
            Assert.AreEqual(Convert.ToInt32(message.Properties["NumberProperty"]), 123);

            // Times must be identical to a second.
            DateTimeOffset readDateTime = (DateTimeOffset)message.Properties["TimeProperty"];
            Assert.AreEqual(originalDateTime.Year, readDateTime.Year);
            Assert.AreEqual(originalDateTime.Month, readDateTime.Month);
            Assert.AreEqual(originalDateTime.Day, readDateTime.Day);
            Assert.AreEqual(originalDateTime.Hour, readDateTime.Hour);
            Assert.AreEqual(originalDateTime.Minute, readDateTime.Minute);
            Assert.AreEqual(originalDateTime.Second, readDateTime.Second);
        }

        /// <summary>
        /// Tests that properties of unsupported types are rejected.
        /// </summary>
        [TestMethod]
        public void InvalidPropertyType()
        {
            BrokeredMessageSettings messageSettings = MessageHelper.CreateMessage("This is a test.");
            
            messageSettings.Properties.Add("TestProperty", new int[] { 1, 2, 3});
            Assert.ThrowsException<InvalidCastException>(() => Configuration.ServiceBus.SendMessageAsync(_queueName, messageSettings));
        }
    }
}
