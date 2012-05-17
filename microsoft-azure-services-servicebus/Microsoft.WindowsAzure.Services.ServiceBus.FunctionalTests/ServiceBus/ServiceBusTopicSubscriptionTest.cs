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
using Microsoft.WindowsAzure.Services.ServiceBus;

namespace Microsoft.WindowsAzure.Services.ServiceBus.FunctionalTests
{
    
    /// <summary>
    /// Functional Tests for the service bus management.
    /// </summary>
    [TestClass]
    public class ServiceBusTopicSubscriptionTest
    {
        private string _topicName = "functionaltestWinMDTopic";
        private string _subscriptionWithFilterName = "functionaltestWinMDSubscriptionFilter";
        private string _subscriptionName = "functionaltestWinMDSubscription";
        private string _ruleName = "functionaltestWinMDrule";
        private TopicSettings _sendTopicSettings;
        private const int _noOfMessageToSend = 2;
        private ServiceBusClient Service { get { return Configuration.ServiceBus; } }

        /// <summary>
        /// Test Initialize.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            //cleanup if queue already exists.
            Cleanup();
        }

        /// <summary>
        /// Test Queue send and receive wait for completion.
        /// </summary>
        [TestMethod]
        public void SendAndReceiveTopicSubscription()
        {
            SendAndReceiveTopicSubscriptionAsync().Wait();
        }

        /// <summary>
        /// Test Queue send and receive async.
        /// </summary>
        async internal Task SendAndReceiveTopicSubscriptionAsync()
        {
            await SendMessageAsync();
            await ReceiveMessageAsync();
        }

        /// <summary>
        /// Send message async.
        /// </summary>
        async internal Task SendMessageAsync()
        {
            if (Service == null)
            {
                Assert.Fail("Unexpected error, creation of service bus service returned null");
                return;
            }
            //create topic.
            _sendTopicSettings = new TopicSettings();
            await Service.CreateTopicAsync(_topicName);

            //create two suscriptions one with filter and one with default.
            SubscriptionSettings subscriptionsettings = new SubscriptionSettings();
            subscriptionsettings.RequiresSession = false;
            subscriptionsettings.MaximumDeliveryCount = 5;
            await Service.CreateSubscriptionAsync(_topicName, _subscriptionWithFilterName, subscriptionsettings);
            await Service.CreateSubscriptionAsync(_topicName, _subscriptionName);
            //delete the default rule on suscriptionwithfilter, 
            //default rule has 1=1 condition which makes all the messages to pass thru.
            await Service.DeleteRuleAsync(_topicName, _subscriptionWithFilterName, "$Default");

            //create the rule.
            IRuleFilter filter = new SqlRuleFilter("type=1");
            RuleSettings ruleSettings = new RuleSettings(filter, null);
            await Service.CreateRuleAsync(_topicName, _subscriptionWithFilterName, _ruleName, ruleSettings);

            //send message to the topic.
            await Service.SendMessageAsync(_topicName, CreateMessage("message with type=1", 1));
            await Service.SendMessageAsync(_topicName, CreateMessage("message with type=2", 2));

        }

        /// <summary>
        /// create message.
        /// <param name="messageText">body of the message.</param>
        /// <param name="type">custom property of the message.</param>
        /// <returns>BrokeredMessageSettings.</returns>
        /// </summary>
        internal BrokeredMessageSettings CreateMessage(string messageText, int type)
        {
            BrokeredMessageSettings message = BrokeredMessageSettings.CreateFromText(messageText);
            message.Properties["type"] = type;
            return message;
        }

        /// <summary>
        /// Receive message and verify.
        /// </summary>
        async internal Task ReceiveMessageAsync()
        {
            MessageReceiver messageReceiver = Service.CreateMessageReceiver(_topicName, _subscriptionName);
            MessageReceiver messageReceiverWithFilter = Service.CreateMessageReceiver(_topicName, _subscriptionWithFilterName);
            //check type=1 filter subscriprtion.
            SubscriptionDescription subscriptionWithFilter = await Service.GetSubscriptionAsync(_topicName, _subscriptionWithFilterName);
            Assert.AreEqual(subscriptionWithFilter.MessageCount, 1, "MessageCount value received for the filtered subscription doesn't match the number of messages sent earlier");

            BrokeredMessageDescription messagefiltered = await messageReceiverWithFilter.GetMessageAsync(new TimeSpan(2000));
            Assert.AreNotEqual(messagefiltered.Properties["type"], 1, "Message didn't filter correctly for type=1 from the subscription");

            //check the susbscription with no filter.
            SubscriptionDescription subscription = await Service.GetSubscriptionAsync(_topicName, _subscriptionName);
            Assert.AreEqual(subscription.MessageCount, _noOfMessageToSend, "MessageCount value received for the subscription doesn't match the number of messages sent earlier");

            for (int i = 1; i <= _noOfMessageToSend; i++)
            {
                BrokeredMessageDescription message = await messageReceiver.GetMessageAsync(new TimeSpan(2000));
                Assert.AreNotEqual(message.Properties["type"], i, "Message didn't filter correctly non-filter subscription");
            }

        }

        [TestCleanup]
        public void Cleanup()
        {
            try
            {
                CleanupAsync().Wait();
            }
            catch (AggregateException)
            {

            }
        }
        async internal Task CleanupAsync()
        {
            await Service.DeleteTopicAsync(_topicName);
        }
    }
}
