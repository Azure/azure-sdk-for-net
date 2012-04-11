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
    /// Unit tests for topic/subscription messaging.
    /// </summary>
    public sealed class SubscriptionMessagingTests: MessagingTestsBase, IUseFixture<UniqueSubscriptionFixture>
    {
        private UniqueSubscriptionFixture _subscription;    // Unique topic/subscription fixture.
        private MessageReceiver _receiver;                  // Message receiver.

        /// <summary>
        /// Gets the receiver used for testing.
        /// </summary>
        public override MessageReceiver Receiver
        {
            get
            {
                if (_receiver == null)
                {
                    _receiver = Configuration.ServiceBus.CreateMessageReceiver(_subscription.TopicName, _subscription.SubscriptionName);
                }
                return _receiver;
            }
        }

        /// <summary>
        /// Gets the topics name used in tests.
        /// </summary>
        private string TopicName 
        { 
            get { return _subscription.TopicName; } 
        }

        /// <summary>
        /// Gets the subscription name used in tests.
        /// </summary>
        private string SubscriptionName
        {
            get { return _subscription.SubscriptionName; }
        }

        /// <summary>
        /// Gets the service bus interface.
        /// </summary>
        private IServiceBusService ServiceBus
        {
            get { return Configuration.ServiceBus; }
        }

        /// <summary>
        /// Sends a message to the subscription.
        /// </summary>
        /// <param name="settings">Message settings.</param>
        protected override void SendMessage(BrokeredMessageSettings settings)
        {
            Configuration.ServiceBus.SendMessageAsync(TopicName, settings).AsTask().Wait();
        }

        /// <summary>
        /// Assigns fixture to the class.
        /// </summary>
        /// <param name="data">Fixture.</param>
        void IUseFixture<UniqueSubscriptionFixture>.SetFixture(UniqueSubscriptionFixture data)
        {
            _subscription = data;
        }

        /// <summary>
        /// Tests passing invalid null arguments into methods.
        /// </summary>
        [Fact]
        public void NullArgs()
        {
            TimeSpan validSpan = TimeSpan.FromSeconds(10);
            Assert.Throws<ArgumentNullException>(() => ServiceBus.CreateMessageReceiver(null, "subscription"));
            Assert.Throws<ArgumentException>(() => ServiceBus.CreateMessageReceiver("", "subscription"));
            Assert.Throws<ArgumentException>(() => ServiceBus.CreateMessageReceiver(" ", "subscription"));

            Assert.Throws<ArgumentNullException>(() => ServiceBus.CreateMessageReceiver("topic", null));
            Assert.Throws<ArgumentException>(() => ServiceBus.CreateMessageReceiver("topic", ""));
            Assert.Throws<ArgumentException>(() => ServiceBus.CreateMessageReceiver("topic", " "));
        }

        /// <summary>
        /// Tests getting a message from a non-existing topic.
        /// </summary>
        [Fact]
        public void GettingMessageFromNonExistingTopic()
        {
            MessageReceiver receiver = Configuration.ServiceBus.CreateMessageReceiver(
                Configuration.GetUniqueTopicName(), SubscriptionName);

            Assert.Throws<AggregateException>(() => receiver.GetMessageAsync(TimeSpan.FromSeconds(10)).AsTask().Wait());
        }

        /// <summary>
        /// Tests getting a message from a non-existing subscription.
        /// </summary>
        [Fact]
        public void GettingMessageFromNonExistingSubscription()
        {
            MessageReceiver receiver = Configuration.ServiceBus.CreateMessageReceiver(
                TopicName, Configuration.GetUniqueSubscriptionName());
            Assert.Throws<AggregateException>(() => receiver.GetMessageAsync(TimeSpan.FromSeconds(10)).AsTask().Wait());
        }
    }
}
