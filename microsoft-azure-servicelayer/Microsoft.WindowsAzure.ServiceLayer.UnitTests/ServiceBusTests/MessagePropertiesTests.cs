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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.ServiceLayer.ServiceBus;
using Xunit;

namespace Microsoft.WindowsAzure.ServiceLayer.UnitTests.ServiceBusTests
{
    /// <summary>
    /// Tests for message properties.
    /// </summary>
    public sealed class MessagePropertiesTests
    {
        /// <summary>
        /// Tests setting and reading message properties.
        /// </summary>
        [Fact]
        [UsesUniqueQueue]
        public void MessageProperties()
        {
            string queueName = UsesUniqueQueueAttribute.QueueName;
            DateTimeOffset originalDateTime = DateTimeOffset.Now;
            BrokeredMessageSettings messageSettings = BrokeredMessageSettings.CreateFromText("text/plain", "This is a test.");

            messageSettings.Properties.Add("StringProperty", "Test");
            messageSettings.Properties.Add("BoolPropertyTrue", true);
            messageSettings.Properties.Add("BoolPropertyFalse", false);
            messageSettings.Properties.Add("NullProperty", null);
            messageSettings.Properties.Add("NumberProperty", 123);
            messageSettings.Properties.Add("TimeProperty", originalDateTime);

            Configuration.ServiceBus.SendMessageAsync(queueName, messageSettings).AsTask().Wait();
            BrokeredMessageInfo message = Configuration.ServiceBus.GetQueueMessageAsync(queueName, TimeSpan.FromSeconds(10)).AsTask().Result;

            Assert.NotEqual(message.Properties, null);
            Assert.True(message.Properties.ContainsKey("StringProperty"));
            Assert.True(message.Properties.ContainsKey("BoolPropertyTrue"));
            Assert.True(message.Properties.ContainsKey("BoolPropertyFalse"));
            Assert.True(message.Properties.ContainsKey("NumberProperty"));
            Assert.True(message.Properties.ContainsKey("TimeProperty"));
            // The server does not store/return null properties.
            Assert.False(message.Properties.ContainsKey("NullProperty"));

            Assert.Equal((string)message.Properties["StringProperty"], "Test", StringComparer.Ordinal);
            Assert.Equal((bool)message.Properties["BoolPropertyTrue"], true);
            Assert.Equal((bool)message.Properties["BoolPropertyFalse"], false);
            Assert.Equal(Convert.ToInt32(message.Properties["NumberProperty"]), 123);

            // Times must be identical to a second.
            DateTimeOffset readDateTime = (DateTimeOffset)message.Properties["TimeProperty"];
            Assert.Equal(originalDateTime.Year, readDateTime.Year);
            Assert.Equal(originalDateTime.Month, readDateTime.Month);
            Assert.Equal(originalDateTime.Day, readDateTime.Day);
            Assert.Equal(originalDateTime.Hour, readDateTime.Hour);
            Assert.Equal(originalDateTime.Minute, readDateTime.Minute);
            Assert.Equal(originalDateTime.Second, readDateTime.Second);
        }

        /// <summary>
        /// Tests that properties of unsupported types are rejected.
        /// </summary>
        [Fact]
        [UsesUniqueQueue]
        public void InvalidPropertyType()
        {
            string queueName = UsesUniqueQueueAttribute.QueueName;
            BrokeredMessageSettings messageSettings = BrokeredMessageSettings.CreateFromText("text/plain", "This is a test.");
            
            messageSettings.Properties.Add("TestProperty", new int[] { 1, 2, 3});
            Assert.Throws<InvalidCastException>(() => Configuration.ServiceBus.SendMessageAsync(queueName, messageSettings));
        }
    }
}
