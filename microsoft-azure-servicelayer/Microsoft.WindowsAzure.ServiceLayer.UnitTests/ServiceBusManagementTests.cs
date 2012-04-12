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
using Microsoft.WindowsAzure.ServiceLayer.Http;
using Microsoft.WindowsAzure.ServiceLayer.UnitTests.ServiceBusTests;
using Windows.Foundation;
using Xunit;

namespace Microsoft.WindowsAzure.ServiceLayer.UnitTests
{
    /// <summary>
    /// Tests for the service bus management.
    /// </summary>
    public class ServiceBusManagementTests
    {
        /// <summary>
        /// Comparer for the QueueInfo type.
        /// </summary>
        private class InternalQueueInfoComparer : IEqualityComparer<QueueDescription>
        {
            bool IEqualityComparer<QueueDescription>.Equals(QueueDescription x, QueueDescription y)
            {
                return x.DefaultMessageTimeToLive == y.DefaultMessageTimeToLive &&
                    x.DuplicateDetectionHistoryTimeWindow == y.DuplicateDetectionHistoryTimeWindow && 
                    x.EnableBatchedOperations == y.EnableBatchedOperations &&
                    x.EnableDeadLetteringOnMessageExpiration == y.EnableDeadLetteringOnMessageExpiration &&
                    x.LockDuration == y.LockDuration &&
                    x.MaximumDeliveryCount == y.MaximumDeliveryCount &&
                    x.MaximumSizeInMegabytes == y.MaximumSizeInMegabytes &&
                    x.MessageCount == y.MessageCount &&
                    x.RequiresDuplicateDetection == y.RequiresDuplicateDetection &&
                    x.RequiresSession == y.RequiresSession &&
                    x.SizeInBytes == y.SizeInBytes;
            }

            int IEqualityComparer<QueueDescription>.GetHashCode(QueueDescription obj)
            {
                return obj.GetHashCode();
            }
        }

        /// <summary>
        /// Comparer for the TopicInfo type.
        /// </summary>
        private class InternalTopicInfoComparer : IEqualityComparer<TopicDescription>
        {
            bool IEqualityComparer<TopicDescription>.Equals(TopicDescription x, TopicDescription y)
            {
                return x.DefaultMessageTimeToLive == y.DefaultMessageTimeToLive &&
                    x.DuplicateDetectionHistoryTimeWindow == y.DuplicateDetectionHistoryTimeWindow &&
                    x.EnableBatchedOperations == y.EnableBatchedOperations &&
                    x.MaximumSizeInMegabytes == y.MaximumSizeInMegabytes &&
                    x.RequiresDuplicateDetection == y.RequiresDuplicateDetection &&
                    x.SizeInBytes == y.SizeInBytes;
            }

            int IEqualityComparer<TopicDescription>.GetHashCode(TopicDescription obj)
            {
                return obj.GetHashCode();
            }
        }

        /// <summary>
        /// Comparer for the SubscriptionInfo type.
        /// </summary>
        private class InternalSubscriptionInfoComparer : IEqualityComparer<SubscriptionDescription>
        {
            bool IEqualityComparer<SubscriptionDescription>.Equals(SubscriptionDescription x, SubscriptionDescription y)
            {
                return
                    x.LockDuration == y.LockDuration &&
                    x.MaximumDeliveryCount == y.MaximumDeliveryCount &&
                    x.MessageCount == y.MessageCount &&
                    x.RequiresSession == y.RequiresSession;
            }

            int IEqualityComparer<SubscriptionDescription>.GetHashCode(SubscriptionDescription obj)
            {
                return obj.GetHashCode();
            }
        }

        IServiceBusService Service { get { return Configuration.ServiceBus; } }
        IEqualityComparer<QueueDescription> QueueInfoComparer { get; set; }
        IEqualityComparer<TopicDescription> TopicInfoComparer { get; set; }
        IEqualityComparer<SubscriptionDescription> SubscriptionInfoComparer { get; set; }

        public ServiceBusManagementTests()
        {
            QueueInfoComparer = new InternalQueueInfoComparer();
            TopicInfoComparer = new InternalTopicInfoComparer();
            SubscriptionInfoComparer = new InternalSubscriptionInfoComparer();
        }

        private Dictionary<string, T> GetItems<T>(
            Func<IAsyncOperation<IEnumerable<T>>> getItems,
            Func<T, string> getName)
        {
            Dictionary<string, T> items = new Dictionary<string,T>(StringComparer.OrdinalIgnoreCase);

            foreach (T item in getItems().AsTask<IEnumerable<T>>().Result)
            {
                string itemName = getName(item);
                items.Add(itemName, item);
            }

            return items;
        }

        private void TestRule<FILTER>(Func<FILTER> createFilter, Func<FILTER, string> getContent) where FILTER : IRuleFilter
        {
            FILTER filter = createFilter();
            string originalContent = getContent(filter);
            string ruleName = "rule." + Guid.NewGuid().ToString();
            RuleSettings settings = new RuleSettings(filter, null);
            RuleInfo rule = Service.CreateRuleAsync(UsesUniqueSubscriptionAttribute.TopicName, UsesUniqueSubscriptionAttribute.SubscriptionName, ruleName, settings)
                .AsTask<RuleInfo>().Result;

            Assert.True(rule.Action is EmptyRuleAction);
            Assert.True(rule.Filter is FILTER);

            string newContent = getContent((FILTER)rule.Filter);
            Assert.True(string.Equals(originalContent, newContent, StringComparison.Ordinal));
        }

        private void TestAction<ACTION>(Func<ACTION> createAction, Func<ACTION, string> getContent) where ACTION : IRuleAction
        {
            ACTION action = createAction();
            string originalContent = getContent(action);
            string ruleName = "rule." + Guid.NewGuid().ToString();
            RuleSettings settings = new RuleSettings(new SqlRuleFilter("1=1"), action);
            RuleInfo rule = Service.CreateRuleAsync(UsesUniqueSubscriptionAttribute.TopicName, UsesUniqueSubscriptionAttribute.SubscriptionName, ruleName, settings)
                .AsTask<RuleInfo>().Result;

            Assert.IsType<ACTION>(rule.Action);

            string newContent = getContent((ACTION)rule.Action);
            Assert.True(string.Equals(originalContent, newContent, StringComparison.Ordinal));
        }

        /// <summary>
        /// Tests listing items in the given range.
        /// </summary>
        /// <typeparam name="TInfo">Item type.</typeparam>
        /// <param name="createItem">Method for creating an item.</param>
        /// <param name="listItems">Method for listing items in a range.</param>
        /// <param name="deleteItem">Method for deleting an item.</param>
        /// <param name="getName">Method for getting item's name.</param>
        private void TestListItemsInRange<TInfo>(
            Func<IAsyncOperation<TInfo>> createItem,
            Func<int, int, IAsyncOperation<IEnumerable<TInfo>>> listItems,
            Func<TInfo, IAsyncAction> deleteItem,
            Func<TInfo, string> getName)
        {
            // Create 3 items
            const int itemCount = 3;
            Dictionary<string, TInfo> createdItems = new Dictionary<string, TInfo>(StringComparer.OrdinalIgnoreCase);

            for (int i = 0; i < itemCount; i++)
            {
                TInfo item = createItem().AsTask().Result;
                string name = getName(item);
                createdItems.Add(name, item);
            }

            try
            {
                // Read all items one by one. Because tests are executed in random order,
                // we cannot assume that the items we've created will be the only items
                // on the server.
                Dictionary<string, TInfo> allItems = new Dictionary<string, TInfo>(StringComparer.OrdinalIgnoreCase);

                for (; ; )
                {
                    List<TInfo> readItems = new List<TInfo>(listItems(allItems.Count, 1).AsTask().Result);

                    if (readItems.Count == 0)
                    {
                        break;
                    }
                    Assert.Equal(readItems.Count, 1);
                    TInfo item = readItems[0];
                    string name = getName(item);

                    Assert.False(allItems.ContainsKey(name));
                    allItems.Add(name, item);
                }

                Assert.True(allItems.Count >= createdItems.Count);

                // Confirm that we've read everything we had created.
                foreach (TInfo createdItem in createdItems.Values)
                {
                    Assert.True(allItems.ContainsKey(getName(createdItem)));
                }

                // Request more items that present in the database.
                {
                    List<TInfo> items = new List<TInfo>(
                        listItems(0, allItems.Count + 1).AsTask().Result);
                    Assert.Equal(items.Count, allItems.Count);
                }
            }
            finally
            {
                // Delete all items we have created.
                foreach (TInfo item in createdItems.Values)
                {
                    deleteItem(item).AsTask().Wait();
                }
            }
        }

        /// <summary>
        /// Tests specifying invalid arguments in list items method.
        /// </summary>
        /// <typeparam name="T">Item type.</typeparam>
        /// <param name="listItems">List items method.</param>
        private void TestInvalidArgsInListItems<T>(Func<int, int, IAsyncOperation<IEnumerable<T>>> listItems)
        {
            Assert.Throws<ArgumentException>(() => listItems(-1, 1));
            Assert.Throws<ArgumentException>(() => listItems(0, 0));
            Assert.Throws<ArgumentException>(() => listItems(0, -1));
        }

        /// <summary>
        /// Tests null arguments in queue management API.
        /// </summary>
        [Fact]
        public void NullArgsInQueues()
        {
            QueueSettings validSettings = new QueueSettings();
            Assert.Throws<ArgumentNullException>(() => Service.CreateQueueAsync(null));
            Assert.Throws<ArgumentException>(() => Service.CreateQueueAsync(""));
            Assert.Throws<ArgumentException>(() => Service.CreateQueueAsync(" "));
            Assert.Throws<ArgumentNullException>(() => Service.CreateQueueAsync(null, validSettings));
            Assert.Throws<ArgumentException>(() => Service.CreateQueueAsync("", validSettings));
            Assert.Throws<ArgumentException>(() => Service.CreateQueueAsync(" ", validSettings));
            Assert.Throws<ArgumentNullException>(() => Service.CreateQueueAsync("foo", null));
            Assert.Throws<ArgumentNullException>(() => Service.GetQueueAsync(null));
            Assert.Throws<ArgumentException>(() => Service.GetQueueAsync(""));
            Assert.Throws<ArgumentException>(() => Service.GetQueueAsync(" "));
            Assert.Throws<ArgumentNullException>(() => Service.DeleteQueueAsync(null));
            Assert.Throws<ArgumentException>(() => Service.DeleteQueueAsync(""));
            Assert.Throws<ArgumentException>(() => Service.DeleteQueueAsync(" "));
        }

        /// <summary>
        /// Tests full lifecycle of a queue.
        /// </summary>
        [Fact]
        public void QueueLifecycle()
        {
            // Create a queue.
            string queueName = Configuration.GetUniqueQueueName();
            QueueDescription newQueue = Service.CreateQueueAsync(queueName).AsTask<QueueDescription>().Result;

            // Confirm that the queue can be obtained from the server
            QueueDescription storedQueue = Service.GetQueueAsync(queueName).AsTask<QueueDescription>().Result;
            Assert.Equal<QueueDescription>(storedQueue, newQueue, QueueInfoComparer);

            // Confirm that the queue can be obtained in the list
            Dictionary<string, QueueDescription> queues = GetItems(
                () => { return Service.ListQueuesAsync(); },
                (queue) => { return queue.Name; });

            Assert.True(queues.ContainsKey(queueName));
            Assert.Equal<QueueDescription>(newQueue, queues[queueName], QueueInfoComparer);

            // Delete the queue
            Service.DeleteQueueAsync(queueName).AsTask().Wait();
            queues = GetItems(
                () => { return Service.ListQueuesAsync(); },
                (queue) => { return queue.Name; });

            Assert.False(queues.ContainsKey(queueName));
        }

        /// <summary>
        /// Tests listing queues in the given range.
        /// </summary>
        [Fact]
        public void ListQueuesInRange()
        {
            TestListItemsInRange<QueueDescription>(
                () => Service.CreateQueueAsync(Configuration.GetUniqueQueueName()),
                (firstItem, count) => Service.ListQueuesAsync(firstItem, count),
                queue => Service.DeleteQueueAsync(queue.Name),
                queue => queue.Name);
        }

        /// <summary>
        /// Tests specifying invalid arguments in ListQueues method.
        /// </summary>
        [Fact]
        public void ListQueuesInvalidArgs()
        {
            TestInvalidArgsInListItems<QueueDescription>(
                (firstItem, count) => Service.ListQueuesAsync(firstItem, count));
        }

        /// <summary>
        /// Tests specifying range when listing topics.
        /// </summary>
        [Fact]
        public void ListTopicsInRange()
        {
            TestListItemsInRange<TopicDescription>(
                () => Service.CreateTopicAsync(Configuration.GetUniqueTopicName()),
                (firstItem, count) => Service.ListTopicsAsync(firstItem, count),
                topic => Service.DeleteTopicAsync(topic.Name),
                topic => topic.Name);
        }

        /// <summary>
        /// Tests specifying invalid arguments when listing topics.
        /// </summary>
        [Fact]
        public void ListTopicsInvalidArgs()
        {
            TestInvalidArgsInListItems<TopicDescription>(
                (firstItem, count) => Service.ListTopicsAsync(firstItem, count));
        }

        /// <summary>
        /// Tests specifying range when listing subscriptions.
        /// </summary>
        [Fact]
        [UsesUniqueTopic]
        public void ListSubscriptionsInRange()
        {
            string topicName = UsesUniqueTopicAttribute.TopicName;

            TestListItemsInRange<SubscriptionDescription>(
                () => Service.CreateSubscriptionAsync(topicName, Configuration.GetUniqueSubscriptionName()),
                (firstItem, count) => Service.ListSubscriptionsAsync(topicName, firstItem, count),
                subscription => Service.DeleteSubscriptionAsync(topicName, subscription.Name),
                subscription => subscription.Name);
        }

        /// <summary>
        /// Tests specifying invalid arguments when listing subscriptions.
        /// </summary>
        [Fact]
        public void ListSubscriptionsInvalidArgs()
        {
            TestInvalidArgsInListItems<SubscriptionDescription>(
                (firstItem, count) => Service.ListSubscriptionsAsync("test", firstItem, count));

            Assert.Throws<ArgumentNullException>(() => Service.ListSubscriptionsAsync(null, 1, 1));
            Assert.Throws<ArgumentException>(() => Service.ListSubscriptionsAsync("", 1, 1));
            Assert.Throws<ArgumentException>(() => Service.ListSubscriptionsAsync(" ", 1, 1));
        }

        /// <summary>
        /// Tests specifying ranges when listing rules.
        /// </summary>
        [Fact]
        [UsesUniqueSubscription]
        public void ListRulesInRange()
        {
            string topicName = UsesUniqueSubscriptionAttribute.TopicName;
            string subscriptionName = UsesUniqueSubscriptionAttribute.SubscriptionName;

            TestListItemsInRange<RuleInfo>(
                () =>
                {
                    RuleSettings settings = new RuleSettings(new TrueRuleFilter("1=1"), null);
                    return Service.CreateRuleAsync(topicName, subscriptionName, Configuration.GetUniqueRuleName(), settings);
                },
                (firstItem, count) => Service.ListRulesAsync(topicName, subscriptionName, firstItem, count),
                rule => Service.DeleteRuleAsync(topicName, subscriptionName, rule.Name),
                rule => rule.Name);
        }

        /// <summary>
        /// Tests specifying invalid arguments when listing rules.
        /// </summary>
        [Fact]
        public void ListRulesInvalidArgs()
        {
            TestInvalidArgsInListItems<RuleInfo>(
                (firstItem, count) => Service.ListRulesAsync("topic", "subscription", firstItem, count));

            Assert.Throws<ArgumentNullException>(() => Service.ListRulesAsync(null, "subscription", 0, 1));
            Assert.Throws<ArgumentException>(() => Service.ListRulesAsync("", "subscription", 0, 1));
            Assert.Throws<ArgumentException>(() => Service.ListRulesAsync(" ", "subscription", 0, 1));
            Assert.Throws<ArgumentNullException>(() => Service.ListRulesAsync("topic", null, 0, 1));
            Assert.Throws<ArgumentException>(() => Service.ListRulesAsync("topic", "", 0, 1));
            Assert.Throws<ArgumentException>(() => Service.ListRulesAsync("topic", " ", 0, 1));

            Assert.Throws<ArgumentException>(() => Service.ListRulesAsync("topic", "subscription", -1, 1));
            Assert.Throws<ArgumentException>(() => Service.ListRulesAsync("topic", "subscripiton", 0, 0));
        }

        /// <summary>
        /// Verifies that using an existing name for a new queue result in an exception.
        /// </summary>
        [Fact]
        [UsesUniqueQueue]
        public void CreateQueueDuplicateName()
        {
            // Create a queue
            string queueName = UsesUniqueQueueAttribute.QueueName;

            Task t = Service.CreateQueueAsync(queueName).AsTask();
            Assert.Throws<AggregateException>(() => t.Wait());
        }

        /// <summary>
        /// Tests getting a missing queue.
        /// </summary>
        [Fact]
        public void GetMissingQueue()
        {
            string queueName = Configuration.GetUniqueQueueName();
            Task t = Service.GetQueueAsync(queueName).AsTask();
            Assert.Throws<AggregateException>(() => t.Wait());
        }

        /// <summary>
        /// Tests deleting a missing queue.
        /// </summary>
        [Fact]
        public void DeleteMissingQueue()
        {
            string queueName = Configuration.GetUniqueQueueName();
            Task t = Service.DeleteQueueAsync(queueName).AsTask();
            Assert.Throws<AggregateException>(() => t.Wait());
        }

        /// <summary>
        /// Verifies creation of the queue with all non-default parameters
        /// </summary>
        [Fact]
        public void CreateQueueWithNonDefaultParams()
        {
            string queueName = Configuration.GetUniqueQueueName();
            QueueSettings settings = new QueueSettings();

            settings.DefaultMessageTimeToLive = TimeSpan.FromHours(24);
            settings.DuplicateDetectionHistoryTimeWindow = TimeSpan.FromDays(2);
            settings.EnableBatchedOperations = false;
            settings.EnableDeadLetteringOnMessageExpiration = true;
            settings.LockDuration = TimeSpan.FromMinutes(3);
            settings.MaximumDeliveryCount = 5;
            settings.MaximumSizeInMegabytes = 2048;
            settings.RequiresDuplicateDetection = true;
            settings.RequiresSession = true;

            QueueDescription queueInfo = Service.CreateQueueAsync(queueName, settings).AsTask<QueueDescription>().Result;
            try
            {
                Assert.Equal(queueInfo.DefaultMessageTimeToLive, settings.DefaultMessageTimeToLive.Value);
                Assert.Equal(queueInfo.DuplicateDetectionHistoryTimeWindow, settings.DuplicateDetectionHistoryTimeWindow.Value);
                Assert.Equal(queueInfo.EnableBatchedOperations, settings.EnableBatchedOperations.Value);
                Assert.Equal(queueInfo.EnableDeadLetteringOnMessageExpiration, settings.EnableDeadLetteringOnMessageExpiration.Value);
                Assert.Equal(queueInfo.LockDuration, settings.LockDuration.Value);
                Assert.Equal(queueInfo.MaximumDeliveryCount, settings.MaximumDeliveryCount.Value);
                Assert.Equal(queueInfo.MaximumSizeInMegabytes, settings.MaximumSizeInMegabytes.Value);
                Assert.Equal(queueInfo.RequiresDuplicateDetection, settings.RequiresDuplicateDetection.Value);
                Assert.Equal(queueInfo.RequiresSession, settings.RequiresSession.Value);
            }
            finally
            {
                Service.DeleteQueueAsync(queueName).AsTask().Wait();
            }
        }

        /// <summary>
        /// Tests throwing ArgumentNullException for topic management API.
        /// </summary>
        [Fact]
        public void NullArgsInTopics()
        {
            TopicSettings validSettings = new TopicSettings();

            Assert.Throws<ArgumentNullException>(() => Service.CreateTopicAsync(null));
            Assert.Throws<ArgumentException>(() => Service.CreateTopicAsync(""));
            Assert.Throws<ArgumentException>(() => Service.CreateTopicAsync(" "));
            Assert.Throws<ArgumentNullException>(() => Service.CreateTopicAsync(null, validSettings));
            Assert.Throws<ArgumentException>(() => Service.CreateTopicAsync("", validSettings));
            Assert.Throws<ArgumentException>(() => Service.CreateTopicAsync(" ", validSettings));
            Assert.Throws<ArgumentNullException>(() => Service.CreateTopicAsync("foo", null));
            Assert.Throws<ArgumentNullException>(() => Service.GetTopicAsync(null));
            Assert.Throws<ArgumentException>(() => Service.GetTopicAsync(""));
            Assert.Throws<ArgumentException>(() => Service.GetTopicAsync(" "));
            Assert.Throws<ArgumentNullException>(() => Service.DeleteTopicAsync(null));
            Assert.Throws<ArgumentException>(() => Service.DeleteQueueAsync(""));
            Assert.Throws<ArgumentException>(() => Service.DeleteQueueAsync(" "));
        }

        /// <summary>
        /// Tests the complete lifecycle of a topic.
        /// </summary>
        [Fact]
        public void TopicLifecycle()
        {
            // Create a topic
            string topicName = Configuration.GetUniqueTopicName();
            TopicDescription newTopic = Service.CreateTopicAsync(topicName).AsTask<TopicDescription>().Result;

            // Confirm that the topic can be obtained from the server.
            TopicDescription storedTopic = Service.GetTopicAsync(topicName).AsTask<TopicDescription>().Result;
            Assert.Equal<TopicDescription>(storedTopic, newTopic, TopicInfoComparer);

            // Conmfirm that the topic can be obtained in the list.
            Dictionary<string, TopicDescription> topics = GetItems(
                () => { return Service.ListTopicsAsync(); },
                (t) => { return t.Name; });
            Assert.True(topics.ContainsKey(topicName));
            Assert.Equal(newTopic, topics[topicName], TopicInfoComparer);

            // Delete the topic.
            Service.DeleteTopicAsync(topicName).AsTask().Wait();
            topics = GetItems(
                () => { return Service.ListTopicsAsync(); },
                (t) => { return t.Name; });

            Assert.False(topics.ContainsKey(topicName));
        }

        /// <summary>
        /// Tests creating two topics with identical names.
        /// </summary>
        [Fact]
        [UsesUniqueTopic]
        public void CreateTopicDuplicateName()
        {
            // Create a topic
            string topicName = UsesUniqueTopicAttribute.TopicName;

            Task t = Service.CreateTopicAsync(topicName).AsTask();
            Assert.Throws<AggregateException>(() => t.Wait());
        }

        /// <summary>
        /// Tests getting a missing topic.
        /// </summary>
        [Fact]
        public void GetMissingTopic()
        {
            string topicName = Configuration.GetUniqueTopicName();
            Task t = Service.GetTopicAsync(topicName).AsTask() ;
            Assert.Throws<AggregateException>(() => t.Wait());
        }

        /// <summary>
        /// Tests deleting a missing topic.
        /// </summary>
        [Fact]
        public void DeleteMissingTopic()
        {
            string topicName = Configuration.GetUniqueTopicName();
            Task t = Service.DeleteTopicAsync(topicName).AsTask();
            Assert.Throws<AggregateException>(() => t.Wait());
        }

        /// <summary>
        /// Tests creation of a topic with all non-default parameters.
        /// </summary>
        [Fact]
        public void CreateTopicWithNonDefaultParams()
        {
            string topicName = Configuration.GetUniqueTopicName();
            TopicSettings settings = new TopicSettings();

            settings.DefaultMessageTimeToLive = TimeSpan.FromHours(24);
            settings.DuplicateDetectionHistoryTimeWindow = TimeSpan.FromDays(2);
            settings.EnableBatchedOperations = false;
            settings.MaximumSizeInMegabytes = 2048;
            settings.RequiresDuplicateDetection = true;

            TopicDescription topic = Service.CreateTopicAsync(topicName, settings).AsTask<TopicDescription>().Result;
            try
            {
                Assert.Equal(settings.DefaultMessageTimeToLive.Value, topic.DefaultMessageTimeToLive);
                Assert.Equal(settings.DuplicateDetectionHistoryTimeWindow.Value, topic.DuplicateDetectionHistoryTimeWindow);
                Assert.Equal(settings.EnableBatchedOperations.Value, topic.EnableBatchedOperations);
                Assert.Equal(settings.MaximumSizeInMegabytes.Value, topic.MaximumSizeInMegabytes);
                Assert.Equal(settings.RequiresDuplicateDetection.Value, topic.RequiresDuplicateDetection);
            }
            finally
            {
                Service.DeleteTopicAsync(topicName).AsTask().Wait();
            }
        }

        /// <summary>
        /// Tests ArgumentNullException for subscription parameters.
        /// </summary>
        [Fact]
        public void InvalidArgsInSubscriptions()
        {
            SubscriptionSettings validSettings = new SubscriptionSettings();

            Assert.Throws<ArgumentNullException>(() => Service.ListSubscriptionsAsync(null));
            Assert.Throws<ArgumentException>(() => Service.ListSubscriptionsAsync(""));
            Assert.Throws<ArgumentException>(() => Service.ListSubscriptionsAsync(" "));
            Assert.Throws<ArgumentNullException>(() => Service.CreateSubscriptionAsync(null, "test"));
            Assert.Throws<ArgumentException>(() => Service.CreateSubscriptionAsync("", "test"));
            Assert.Throws<ArgumentException>(() => Service.CreateSubscriptionAsync(" ", "test"));
            Assert.Throws<ArgumentNullException>(() => Service.CreateSubscriptionAsync("test", null));
            Assert.Throws<ArgumentException>(() => Service.CreateSubscriptionAsync("test", ""));
            Assert.Throws<ArgumentException>(() => Service.CreateSubscriptionAsync("test", " "));
            Assert.Throws<ArgumentNullException>(() => Service.CreateSubscriptionAsync(null, "test", validSettings));
            Assert.Throws<ArgumentException>(() => Service.CreateSubscriptionAsync("", "test", validSettings));
            Assert.Throws<ArgumentException>(() => Service.CreateSubscriptionAsync(" ", "test", validSettings));
            Assert.Throws<ArgumentNullException>(() => Service.CreateSubscriptionAsync("test", null, validSettings));
            Assert.Throws<ArgumentException>(() => Service.CreateSubscriptionAsync("test", "", validSettings));
            Assert.Throws<ArgumentException>(() => Service.CreateSubscriptionAsync("test", " ", validSettings));
            Assert.Throws<ArgumentNullException>(() => Service.CreateSubscriptionAsync("test", "test", null));
            Assert.Throws<ArgumentNullException>(() => Service.GetSubscriptionAsync(null, "test"));
            Assert.Throws<ArgumentException>(() => Service.GetSubscriptionAsync("", "test"));
            Assert.Throws<ArgumentException>(() => Service.GetSubscriptionAsync(" ", "test"));
            Assert.Throws<ArgumentNullException>(() => Service.GetSubscriptionAsync("test", null));
            Assert.Throws<ArgumentException>(() => Service.GetSubscriptionAsync("test", ""));
            Assert.Throws<ArgumentException>(() => Service.GetSubscriptionAsync("test", " "));
            Assert.Throws<ArgumentNullException>(() => Service.DeleteSubscriptionAsync(null, "test"));
            Assert.Throws<ArgumentException>(() => Service.DeleteSubscriptionAsync("", "test"));
            Assert.Throws<ArgumentException>(() => Service.DeleteSubscriptionAsync(" ", "test"));
            Assert.Throws<ArgumentNullException>(() => Service.DeleteSubscriptionAsync("test", null));
            Assert.Throws<ArgumentException>(() => Service.DeleteSubscriptionAsync("test", ""));
            Assert.Throws<ArgumentException>(() => Service.DeleteSubscriptionAsync("test", " "));
        }

        /// <summary>
        /// Tests the complete lifetime of a subscription.
        /// </summary>
        [Fact]
        [UsesUniqueTopic]
        public void SubscriptionLifecycle()
        {
            string topicName = UsesUniqueTopicAttribute.TopicName;
            string subscriptionName = Configuration.GetUniqueSubscriptionName();

            // Create a subscription.
            SubscriptionDescription newSubscription = Service.CreateSubscriptionAsync(topicName, subscriptionName).AsTask().Result;

            // Confirm that the subscription can be obtained from the server.
            SubscriptionDescription storedSubscription = Service.GetSubscriptionAsync(topicName, subscriptionName).AsTask().Result;
            Assert.Equal(storedSubscription, newSubscription, SubscriptionInfoComparer);

            // Confirm that the subscription appears in the list.
            Dictionary<string, SubscriptionDescription> subscriptions = GetItems(
                () => { return Service.ListSubscriptionsAsync(topicName); },
                (s) => { return s.Name; });
            Assert.True(subscriptions.ContainsKey(subscriptionName));
            Assert.Equal(newSubscription, subscriptions[subscriptionName], SubscriptionInfoComparer);

            // Delete the subscription.
            Service.DeleteSubscriptionAsync(topicName, subscriptionName).AsTask().Wait();
            subscriptions = GetItems(
                () => { return Service.ListSubscriptionsAsync(topicName); },
                (s) => { return s.Name; });
                
            Assert.False(subscriptions.ContainsKey(subscriptionName));
        }

        /// <summary>
        /// Tests creating two subscriptions with identical names.
        /// </summary>
        [Fact]
        [UsesUniqueTopic]
        public void CreateSubscriptionDuplicateName()
        {
            string topicName = UsesUniqueTopicAttribute.TopicName;
            string subscriptionName = Configuration.GetUniqueSubscriptionName();

            Service.CreateSubscriptionAsync(topicName, subscriptionName).AsTask().Wait();
            Task<SubscriptionDescription> task = Service.CreateSubscriptionAsync(topicName, subscriptionName).AsTask();
            Assert.Throws<AggregateException>(() => task.Wait());
        }

        /// <summary>
        /// Tests getting a non-existing subscription from an existing topic.
        /// </summary>
        [Fact]
        [UsesUniqueTopic]
        public void GetMissingSubscription()
        {
            string topicName = UsesUniqueTopicAttribute.TopicName;
            string subscriptionName = Configuration.GetUniqueSubscriptionName();

            Task<SubscriptionDescription> task = Service.GetSubscriptionAsync(topicName, subscriptionName).AsTask();
            Assert.Throws<AggregateException>(() => task.Wait());
        }

        /// <summary>
        /// Tests getting a subscription from a non-existing topic.
        /// </summary>
        [Fact]
        public void GetSubscriptionFromMissingTopic()
        {
            string topicName = Configuration.GetUniqueTopicName();
            string subscriptionName = Configuration.GetUniqueSubscriptionName();

            Task<SubscriptionDescription> task = Service.GetSubscriptionAsync(topicName, subscriptionName).AsTask();
            Assert.Throws<AggregateException>(() => task.Wait());
        }

        /// <summary>
        /// Tests getting all subscriptions from a non-existing topic.
        /// </summary>
        [Fact]
        public void ListSubscriptionsInMissingTopic()
        {
            string topicName = Configuration.GetUniqueTopicName();

            List<SubscriptionDescription> subscriptions = new List<SubscriptionDescription>(
                Service.ListSubscriptionsAsync(topicName).AsTask<IEnumerable<SubscriptionDescription>>().Result);
            Assert.Equal(subscriptions.Count, 0);
        }

        /// <summary>
        /// Tests deleting a non-existing subscription.
        /// </summary>
        [Fact]
        [UsesUniqueTopic]
        public void DeleteMissingSubscription()
        {
            string topicName = UsesUniqueTopicAttribute.TopicName;
            string subscriptionName = Configuration.GetUniqueSubscriptionName();

            Task task = Service.DeleteSubscriptionAsync(topicName, subscriptionName).AsTask();
            Assert.Throws<AggregateException>(() => task.Wait());
        }

        /// <summary>
        /// Tests subscribing to a queue.
        /// </summary>
        [Fact]
        [UsesUniqueQueue]
        public void SubscribeToQueue()
        {
            string queueName = UsesUniqueQueueAttribute.QueueName;
            string subscriptionName = Configuration.GetUniqueSubscriptionName();

            Assert.Throws<AggregateException>(() => Service.CreateSubscriptionAsync(queueName, subscriptionName).AsTask().Wait());
        }

        /// <summary>
        /// Tests null argument exceptions in rule methods.
        /// </summary>
        [Fact]
        public void InvalidArgsInRules()
        {
            RuleSettings validSettings = new RuleSettings(new SqlRuleFilter("1=1"), null);
            Assert.Throws<ArgumentNullException>(() => Service.CreateRuleAsync(null, "test", "test", validSettings));
            Assert.Throws<ArgumentException>(() => Service.CreateRuleAsync("", "test", "test", validSettings));
            Assert.Throws<ArgumentException>(() => Service.CreateRuleAsync(" ", "test", "test", validSettings));
            Assert.Throws<ArgumentNullException>(() => Service.CreateRuleAsync("test", null, "test", validSettings));
            Assert.Throws<ArgumentException>(() => Service.CreateRuleAsync("test", "", "test", validSettings));
            Assert.Throws<ArgumentException>(() => Service.CreateRuleAsync("test", " ", "test", validSettings));
            Assert.Throws<ArgumentNullException>(() => Service.CreateRuleAsync("test", "test", null, validSettings));
            Assert.Throws<ArgumentException>(() => Service.CreateRuleAsync("test", "test", "", validSettings));
            Assert.Throws<ArgumentException>(() => Service.CreateRuleAsync("test", "test", " ", validSettings));
            Assert.Throws<ArgumentNullException>(() => Service.CreateRuleAsync("test", "test", "test", null));

            Assert.Throws<ArgumentNullException>(() => Service.ListRulesAsync(null, "test"));
            Assert.Throws<ArgumentException>(() => Service.ListRulesAsync("", "test"));
            Assert.Throws<ArgumentException>(() => Service.ListRulesAsync(" ", "test"));
            Assert.Throws<ArgumentNullException>(() => Service.ListRulesAsync("test", null));
            Assert.Throws<ArgumentException>(() => Service.ListRulesAsync("test", ""));
            Assert.Throws<ArgumentException>(() => Service.ListRulesAsync("test", " "));

            Assert.Throws<ArgumentNullException>(() => Service.GetRuleAsync(null, "test", "test"));
            Assert.Throws<ArgumentException>(() => Service.GetRuleAsync("", "test", "test"));
            Assert.Throws<ArgumentException>(() => Service.GetRuleAsync(" ", "test", "test"));
            Assert.Throws<ArgumentNullException>(() => Service.GetRuleAsync("test", null, "test"));
            Assert.Throws<ArgumentException>(() => Service.GetRuleAsync("test", "", "test"));
            Assert.Throws<ArgumentException>(() => Service.GetRuleAsync("test", " ", "test"));
            Assert.Throws<ArgumentNullException>(() => Service.GetRuleAsync("test", "test", null));
            Assert.Throws<ArgumentException>(() => Service.GetRuleAsync("test", "test", ""));
            Assert.Throws<ArgumentException>(() => Service.GetRuleAsync("test", "test", " "));

            Assert.Throws<ArgumentNullException>(() => Service.DeleteRuleAsync(null, "test", "test"));
            Assert.Throws<ArgumentException>(() => Service.DeleteRuleAsync("", "test", "test"));
            Assert.Throws<ArgumentException>(() => Service.DeleteRuleAsync(" ", "test", "test"));
            Assert.Throws<ArgumentNullException>(() => Service.DeleteRuleAsync("test", null, "test"));
            Assert.Throws<ArgumentException>(() => Service.DeleteRuleAsync("test", "", "test"));
            Assert.Throws<ArgumentException>(() => Service.DeleteRuleAsync("test", " ", "test"));
            Assert.Throws<ArgumentNullException>(() => Service.DeleteRuleAsync("test", "test", null));
            Assert.Throws<ArgumentException>(() => Service.DeleteRuleAsync("test", "test", ""));
            Assert.Throws<ArgumentException>(() => Service.DeleteRuleAsync("test", "test", " "));

            Assert.Throws<ArgumentNullException>(() => new SqlRuleFilter(null));
            Assert.Throws<ArgumentException>(() => new SqlRuleFilter(""));
            Assert.Throws<ArgumentException>(() => new SqlRuleFilter(" "));
            Assert.Throws<ArgumentNullException>(() => new TrueRuleFilter(null));
            Assert.Throws<ArgumentException>(() => new TrueRuleFilter(""));
            Assert.Throws<ArgumentException>(() => new TrueRuleFilter(" "));
            Assert.Throws<ArgumentNullException>(() => new FalseRuleFilter(null));
            Assert.Throws<ArgumentException>(() => new FalseRuleFilter(""));
            Assert.Throws<ArgumentException>(() => new FalseRuleFilter(" "));

            Assert.Throws<ArgumentNullException>(() => new SqlRuleAction(null));
            Assert.Throws<ArgumentException>(() => new SqlRuleAction(""));
            Assert.Throws<ArgumentException>(() => new SqlRuleAction(" "));
        }

        /// <summary>
        /// Tests SQL rule filters.
        /// </summary>
        [Fact]
        [UsesUniqueSubscription]
        public void SqlRuleFilter()
        {
            TestRule<SqlRuleFilter>(
                () => { return new SqlRuleFilter("1=1"); },
                (rf) => { return rf.Expression; });
        }

        /// <summary>
        /// Tests true rule filters.
        /// </summary>
        [Fact]
        [UsesUniqueSubscription]
        public void TrueRuleFilter()
        {
            TestRule<TrueRuleFilter>(
                () => { return new TrueRuleFilter("1=1"); },
                (rf) => { return rf.Expression; });
        }

        /// <summary>
        /// Tests false rule filters.
        /// </summary>
        [Fact]
        [UsesUniqueSubscription]
        public void FalseRuleFilter()
        {
            TestRule<FalseRuleFilter>(
                () => { return new FalseRuleFilter("1=1"); },
                (rf) => { return rf.Expression; });
        }

        /// <summary>
        /// Tests correlation rule filters.
        /// </summary>
        [Fact]
        [UsesUniqueSubscription]
        public void CorrelationRuleFilter()
        {
            TestRule<CorrelationRuleFilter>(
                () => { return new CorrelationRuleFilter("abc"); },
                (rf) => { return rf.CorrelationId; });
        }

        /// <summary>
        /// Tests empty rule action.
        /// </summary>
        [Fact]
        [UsesUniqueSubscription]
        public void EmptyRuleAction()
        {
            TestAction<EmptyRuleAction>(() => new EmptyRuleAction(), (a) => { return string.Empty; });
        }

        /// <summary>
        /// Tests SQL rule action.
        /// </summary>
        [Fact]
        [UsesUniqueSubscription]
        public void SqlRuleAction()
        {
            TestAction<SqlRuleAction>(() => new SqlRuleAction("set x=y"), (a) => { return a.Action; });
        }

        /// <summary>
        /// Tests complete lifecycle of a rule.
        /// </summary>
        [Fact]
        [UsesUniqueSubscription]
        public void RuleLifecycle()
        {
            // Create rule.
            SqlRuleFilter filter = new SqlRuleFilter("1=1");
            RuleSettings settings = new RuleSettings(filter, null);
            string ruleName = "testrule." + Guid.NewGuid().ToString();
            RuleInfo rule = Service.CreateRuleAsync(UsesUniqueSubscriptionAttribute.TopicName, UsesUniqueSubscriptionAttribute.SubscriptionName, ruleName, settings)
                .AsTask<RuleInfo>().Result;

            Assert.True(string.Equals(ruleName, rule.Name, StringComparison.OrdinalIgnoreCase));

            // Read the rule
            RuleInfo savedRule = Service.GetRuleAsync(UsesUniqueSubscriptionAttribute.TopicName, UsesUniqueSubscriptionAttribute.SubscriptionName, ruleName)
                .AsTask<RuleInfo>().Result;
            Assert.True(string.Equals(ruleName, savedRule.Name, StringComparison.OrdinalIgnoreCase));
            Assert.True(savedRule.Action is EmptyRuleAction);
            Assert.True(savedRule.Filter is SqlRuleFilter);
            Assert.True(string.Equals(((SqlRuleFilter)savedRule.Filter).Expression, filter.Expression, StringComparison.Ordinal));

            // Read from the list.
            Dictionary<string, RuleInfo> allRules = GetItems<RuleInfo>(
                () => { return Service.ListRulesAsync(UsesUniqueSubscriptionAttribute.TopicName, UsesUniqueSubscriptionAttribute.SubscriptionName); },
                (r) => { return r.Name; });
            Assert.True(allRules.ContainsKey(ruleName));

            // Delete the rule.
            Service.DeleteRuleAsync(UsesUniqueSubscriptionAttribute.TopicName, UsesUniqueSubscriptionAttribute.SubscriptionName, ruleName).AsTask().Wait();
            allRules = GetItems<RuleInfo>(
                () => { return Service.ListRulesAsync(UsesUniqueSubscriptionAttribute.TopicName, UsesUniqueSubscriptionAttribute.SubscriptionName); },
                (r) => { return r.Name; });
            Assert.False(allRules.ContainsKey(ruleName));
        }

        /// <summary>
        /// Tests passing invalid arguments in creating a service.
        /// </summary>
        [Fact]
        public void InvalidArgsInCreateService()
        {
            Assert.Throws<ArgumentNullException>(() => ServiceBusService.Create(null, "user", "password"));
            Assert.Throws<ArgumentException>(() => ServiceBusService.Create("", "user", "password"));
            Assert.Throws<ArgumentException>(() => ServiceBusService.Create(" ", "user", "password"));
            Assert.Throws<ArgumentNullException>(() => ServiceBusService.Create("namespace", null, "password"));
            Assert.Throws<ArgumentException>(() => ServiceBusService.Create("namespace", "", "password"));
            Assert.Throws<ArgumentException>(() => ServiceBusService.Create("namespace", " ", "password"));
            Assert.Throws<ArgumentNullException>(() => ServiceBusService.Create("namespace", "user", null));

            IHttpHandler validHandler = new HttpDefaultHandler();
            Assert.Throws<ArgumentNullException>(() => ServiceBusService.Create(null, validHandler));
            Assert.Throws<ArgumentException>(() => ServiceBusService.Create("", validHandler));
            Assert.Throws<ArgumentException>(() => ServiceBusService.Create(" ", validHandler));
            Assert.Throws<ArgumentNullException>(() => ServiceBusService.Create("namespace", null));
        }
    }
}
