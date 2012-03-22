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
        UniqueSubscriptionFixture _subscription;            // Unique topic/subscription fixture.

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
        /// Gets the first message in the subscription.
        /// </summary>
        /// <param name="lockSpan">Locking interval.</param>
        /// <returns>Message.</returns>
        protected override BrokeredMessageInfo GetMessage(TimeSpan lockSpan)
        {
            return Configuration.ServiceBus.GetSubscriptionMessageAsync(TopicName, SubscriptionName, lockSpan).AsTask().Result;
        }

        /// <summary>
        /// Peeks the first message in the subscription.
        /// </summary>
        /// <param name="lockSpan">Lock interval.</param>
        /// <returns>Message or null, if none.</returns>
        protected override BrokeredMessageInfo PeekMessage(TimeSpan lockSpan)
        {
            return Configuration.ServiceBus.PeekSubscriptionMessageAsync(TopicName, SubscriptionName, lockSpan).AsTask().Result;
        }

        /// <summary>
        /// Unlocks previously locked message in the subscription.
        /// </summary>
        /// <param name="sequenceNumber">Sequence number of the locked message.</param>
        /// <param name="lockToken">Lock token of the message.</param>
        protected override void UnlockMessage(long sequenceNumber, string lockToken)
        {
            Configuration.ServiceBus.UnlockSubscriptionMessageAsync(TopicName, SubscriptionName, sequenceNumber, lockToken).AsTask().Wait();
        }

        /// <summary>
        /// Deletes previously locked subscription message.
        /// </summary>
        /// <param name="sequenceNumber">Sequence number of the previously locked message.</param>
        /// <param name="lockToken">Lock token of the message.</param>
        protected override void DeleteMessage(long sequenceNumber, string lockToken)
        {
            Configuration.ServiceBus.DeleteSubscriptionMessageAsync(TopicName, SubscriptionName, sequenceNumber, lockToken).AsTask().Wait();
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
            Assert.Throws<ArgumentNullException>(() => ServiceBus.PeekSubscriptionMessageAsync(null, "subscription", TimeSpan.FromSeconds(10)));
            Assert.Throws<ArgumentNullException>(() => ServiceBus.PeekSubscriptionMessageAsync("topic", null, TimeSpan.FromSeconds(10)));
            Assert.Throws<ArgumentNullException>(() => ServiceBus.GetSubscriptionMessageAsync(null, "subscription", TimeSpan.FromSeconds(10)));
            Assert.Throws<ArgumentNullException>(() => ServiceBus.GetSubscriptionMessageAsync("topic", null, TimeSpan.FromSeconds(10)));
            Assert.Throws<ArgumentNullException>(() => ServiceBus.UnlockSubscriptionMessageAsync(null, "subscription", 0, "lockToken"));
            Assert.Throws<ArgumentNullException>(() => ServiceBus.UnlockSubscriptionMessageAsync("topic", null, 0, "lockToken"));
            Assert.Throws<ArgumentNullException>(() => ServiceBus.UnlockSubscriptionMessageAsync("topic", "subscription", 0, null));
            Assert.Throws<ArgumentNullException>(() => ServiceBus.DeleteSubscriptionMessageAsync(null, "subscription", 0, "lockToken"));
            Assert.Throws<ArgumentNullException>(() => ServiceBus.DeleteSubscriptionMessageAsync("topic", null, 0, "lockToken"));
            Assert.Throws<ArgumentNullException>(() => ServiceBus.DeleteSubscriptionMessageAsync("topic", "subscription", 0, null));
        }

        /// <summary>
        /// Tests getting a message from a non-existing topic.
        /// </summary>
        [Fact]
        public void GettingMessageFromNonExistingTopic()
        {
            Assert.Throws<AggregateException>(
                () => Configuration.ServiceBus.GetSubscriptionMessageAsync(Configuration.GetUniqueTopicName(), SubscriptionName, TimeSpan.FromSeconds(10)).AsTask().Wait());
        }

        /// <summary>
        /// Tests getting a message from a non-existing subscription.
        /// </summary>
        [Fact]
        public void GettingMessageFromNonExistingSubscription()
        {
            Assert.Throws<AggregateException>(
                () => Configuration.ServiceBus.GetSubscriptionMessageAsync(TopicName, Configuration.GetUniqueSubscriptionName(), TimeSpan.FromSeconds(10)).AsTask().Wait());
        }
    }
}
