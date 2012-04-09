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
        /// Gets the first message in the subscription.
        /// </summary>
        /// <param name="lockSpan">Locking interval.</param>
        /// <returns>Message.</returns>
        protected override BrokeredMessageInfo GetMessage(TimeSpan lockSpan)
        {
            return Configuration.ServiceBus.GetSubscriptionMessageAsync(_topicName, _subscriptionName, lockSpan).AsTask().Result;
        }

        /// <summary>
        /// Peeks the first message in the subscription.
        /// </summary>
        /// <param name="lockSpan">Lock interval.</param>
        /// <returns>Message or null, if none.</returns>
        protected override BrokeredMessageInfo PeekMessage(TimeSpan lockSpan)
        {
            return Configuration.ServiceBus.PeekSubscriptionMessageAsync(_topicName, _subscriptionName, lockSpan).AsTask().Result;
        }

        /// <summary>
        /// Unlocks previously locked message in the subscription.
        /// </summary>
        /// <param name="sequenceNumber">Sequence number of the locked message.</param>
        /// <param name="lockToken">Lock token of the message.</param>
        protected override void UnlockMessage(long sequenceNumber, string lockToken)
        {
            Configuration.ServiceBus.UnlockSubscriptionMessageAsync(_topicName, _subscriptionName, sequenceNumber, lockToken).AsTask().Wait();
        }

        /// <summary>
        /// Deletes previously locked subscription message.
        /// </summary>
        /// <param name="sequenceNumber">Sequence number of the previously locked message.</param>
        /// <param name="lockToken">Lock token of the message.</param>
        protected override void DeleteMessage(long sequenceNumber, string lockToken)
        {
            Configuration.ServiceBus.DeleteSubscriptionMessageAsync(_topicName, _subscriptionName, sequenceNumber, lockToken).AsTask().Wait();
        }

        /// <summary>
        /// Tests passing invalid null arguments into methods.
        /// </summary>
        [TestMethod]
        public void NullArgs()
        {
            TimeSpan validSpan = TimeSpan.FromSeconds(10);
            IServiceBusService serviceBus = Configuration.ServiceBus;

            Assert.ThrowsException<ArgumentNullException>(() => serviceBus.PeekSubscriptionMessageAsync(null, "subscription", validSpan));
            Assert.ThrowsException<ArgumentException>(() => serviceBus.PeekSubscriptionMessageAsync("", "subscription", validSpan));
            Assert.ThrowsException<ArgumentException>(() => serviceBus.PeekSubscriptionMessageAsync(" ", "subscription", validSpan));
            Assert.ThrowsException<ArgumentNullException>(() => serviceBus.PeekSubscriptionMessageAsync("topic", null, validSpan));
            Assert.ThrowsException<ArgumentException>(() => serviceBus.PeekSubscriptionMessageAsync("topic", "", validSpan));
            Assert.ThrowsException<ArgumentException>(() => serviceBus.PeekSubscriptionMessageAsync("topic", " ", validSpan));
            Assert.ThrowsException<ArgumentNullException>(() => serviceBus.GetSubscriptionMessageAsync(null, "subscription", validSpan));
            Assert.ThrowsException<ArgumentException>(() => serviceBus.GetSubscriptionMessageAsync("", "subscription", validSpan));
            Assert.ThrowsException<ArgumentException>(() => serviceBus.GetSubscriptionMessageAsync(" ", "subscription", validSpan));
            Assert.ThrowsException<ArgumentNullException>(() => serviceBus.GetSubscriptionMessageAsync("topic", null, validSpan));
            Assert.ThrowsException<ArgumentException>(() => serviceBus.GetSubscriptionMessageAsync("topic", "", validSpan));
            Assert.ThrowsException<ArgumentException>(() => serviceBus.GetSubscriptionMessageAsync("topic", " ", validSpan));

            Assert.ThrowsException<ArgumentNullException>(() => serviceBus.UnlockSubscriptionMessageAsync(null, "subscription", 0, "lockToken"));
            Assert.ThrowsException<ArgumentException>(() => serviceBus.UnlockSubscriptionMessageAsync("", "subscription", 0, "lockToken"));
            Assert.ThrowsException<ArgumentException>(() => serviceBus.UnlockSubscriptionMessageAsync(" ", "subscription", 0, "lockToken"));
            Assert.ThrowsException<ArgumentNullException>(() => serviceBus.UnlockSubscriptionMessageAsync("topic", null, 0, "lockToken"));
            Assert.ThrowsException<ArgumentException>(() => serviceBus.UnlockSubscriptionMessageAsync("topic", "", 0, "lockToken"));
            Assert.ThrowsException<ArgumentException>(() => serviceBus.UnlockSubscriptionMessageAsync("topic", " ", 0, "lockToken"));
            Assert.ThrowsException<ArgumentNullException>(() => serviceBus.UnlockSubscriptionMessageAsync("topic", "subscription", 0, null));
            Assert.ThrowsException<ArgumentException>(() => serviceBus.UnlockSubscriptionMessageAsync("topic", "subscription", 0, ""));
            Assert.ThrowsException<ArgumentNullException>(() => serviceBus.DeleteSubscriptionMessageAsync(null, "subscription", 0, "lockToken"));
            Assert.ThrowsException<ArgumentException>(() => serviceBus.DeleteSubscriptionMessageAsync("", "subscription", 0, "lockToken"));
            Assert.ThrowsException<ArgumentException>(() => serviceBus.DeleteSubscriptionMessageAsync(" ", "subscription", 0, "lockToken"));
            Assert.ThrowsException<ArgumentNullException>(() => serviceBus.DeleteSubscriptionMessageAsync("topic", null, 0, "lockToken"));
            Assert.ThrowsException<ArgumentException>(() => serviceBus.DeleteSubscriptionMessageAsync("topic", "", 0, "lockToken"));
            Assert.ThrowsException<ArgumentException>(() => serviceBus.DeleteSubscriptionMessageAsync("topic", " ", 0, "lockToken"));
            Assert.ThrowsException<ArgumentNullException>(() => serviceBus.DeleteSubscriptionMessageAsync("topic", "subscription", 0, null));
            Assert.ThrowsException<ArgumentException>(() => serviceBus.DeleteSubscriptionMessageAsync("topic", "subscription", 0, ""));
        }

        /// <summary>
        /// Tests getting a message from a non-existing topic.
        /// </summary>
        [TestMethod]
        public void GettingMessageFromNonExistingTopic()
        {
            Assert.ThrowsException<AggregateException>(
                () => Configuration.ServiceBus.GetSubscriptionMessageAsync(Configuration.GetUniqueTopicName(), _subscriptionName, TimeSpan.FromSeconds(10)).AsTask().Wait());
        }

        /// <summary>
        /// Tests getting a message from a non-existing subscription.
        /// </summary>
        [TestMethod]
        public void GettingMessageFromNonExistingSubscription()
        {
            Assert.ThrowsException<AggregateException>(
                () => Configuration.ServiceBus.GetSubscriptionMessageAsync(_topicName, Configuration.GetUniqueSubscriptionName(), TimeSpan.FromSeconds(10)).AsTask().Wait());
        }
    }
}
