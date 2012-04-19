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
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Microsoft.WindowsAzure.ServiceLayer.ServiceBus;

namespace Microsoft.WindowsAzure.ServiceLayer.UnitTests.MsTest.ServiceBusTests
{
    /// <summary>
    /// Unit tests for topic/subscription messaging.
    /// </summary>
    [TestClass]
    public class SubscriptionMessagingTests: MessagingTestsBase
    {
        private static string _topicName;                   // Unique topic name.
        private static string _subscriptionName;            // Unique subscription name.
        private static MessageReceiver _receiver;           // Receiver for subscription messages.

        /// <summary>
        /// Gets the receiver.
        /// </summary>
        protected override MessageReceiver Receiver { get { return _receiver; } }

        /// <summary>
        /// Initializes the environment for all test methods in the class.
        /// </summary>
        /// <param name="ctx">Test context.</param>
        [ClassInitialize]
        public static void ClassInitialize(TestContext ctx)
        {
            _topicName = Configuration.GetUniqueTopicName();
            _subscriptionName = Configuration.GetUniqueSubscriptionName();

            Configuration.ServiceBus.CreateTopicAsync(_topicName).AsTask().Wait();
            Configuration.ServiceBus.CreateSubscriptionAsync(_topicName, _subscriptionName).AsTask().Wait();
            _receiver = Configuration.ServiceBus.CreateMessageReceiver(_topicName, _subscriptionName);
        }

        /// <summary>
        /// Cleans up the environment after running all test methods in the 
        /// class.
        /// </summary>
        [ClassCleanup]
        public static void ClassCleanUp()
        {
            Configuration.ServiceBus.DeleteTopicAsync(_topicName).AsTask().Wait();
            _topicName = null;
            _subscriptionName = null;
        }

        /// <summary>
        /// Sends a message to the subscription.
        /// </summary>
        /// <param name="settings">Message settings.</param>
        protected override void SendMessage(BrokeredMessageSettings settings)
        {
            Configuration.ServiceBus.SendMessageAsync(_topicName, settings).AsTask().Wait();
        }

        /// <summary>
        /// Tests passing invalid null arguments into methods.
        /// </summary>
        [TestMethod]
        public void NullArgs()
        {
            TimeSpan validSpan = TimeSpan.FromSeconds(10);
            ServiceBusClient serviceBus = Configuration.ServiceBus;

            Assert.ThrowsException<ArgumentNullException>(() => serviceBus.CreateMessageReceiver(null, "subscription"));
            Assert.ThrowsException<ArgumentException>(() => serviceBus.CreateMessageReceiver("", "subscription"));
            Assert.ThrowsException<ArgumentException>(() => serviceBus.CreateMessageReceiver(" ", "subscription"));

            Assert.ThrowsException<ArgumentNullException>(() => serviceBus.CreateMessageReceiver("topic", null));
            Assert.ThrowsException<ArgumentException>(() => serviceBus.CreateMessageReceiver("topic", ""));
            Assert.ThrowsException<ArgumentException>(() => serviceBus.CreateMessageReceiver("topic", " "));
        }

        /// <summary>
        /// Tests getting a message from a non-existing topic.
        /// </summary>
        [TestMethod]
        public void GettingMessageFromNonExistingTopic()
        {
            MessageReceiver receiver = Configuration.ServiceBus.CreateMessageReceiver(
                Configuration.GetUniqueTopicName(), _subscriptionName);

            Assert.ThrowsException<AggregateException>(() => receiver.GetMessageAsync(TimeSpan.FromSeconds(10)).AsTask().Wait());
        }

        /// <summary>
        /// Tests getting a message from a non-existing subscription.
        /// </summary>
        [TestMethod]
        public void GettingMessageFromNonExistingSubscription()
        {
            MessageReceiver receiver = Configuration.ServiceBus.CreateMessageReceiver(
                _topicName, Configuration.GetUniqueSubscriptionName());
            Assert.ThrowsException<AggregateException>(() => receiver.GetMessageAsync(TimeSpan.FromSeconds(10)).AsTask().Wait());
        }
    }
}
