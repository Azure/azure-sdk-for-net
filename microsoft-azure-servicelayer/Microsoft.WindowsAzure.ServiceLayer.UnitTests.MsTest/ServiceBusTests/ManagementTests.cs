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
using Microsoft.WindowsAzure.ServiceLayer.Http;
using Windows.Foundation;

namespace Microsoft.WindowsAzure.ServiceLayer.UnitTests.MsTest.ServiceBusTests
{
    /// <summary>
    /// Tests for the service bus management.
    /// </summary>
    [TestClass]
    public class ManagementTests
    {
        /// <summary>
        /// Comparer for the QueueInfo type.
        /// </summary>
        private class InternalQueueInfoComparer : IEqualityComparer<QueueInfo>
        {
            bool IEqualityComparer<QueueInfo>.Equals(QueueInfo x, QueueInfo y)
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

            int IEqualityComparer<QueueInfo>.GetHashCode(QueueInfo obj)
            {
                return obj.GetHashCode();
            }
        }

        /// <summary>
        /// Comparer for the TopicInfo type.
        /// </summary>
        private class InternalTopicInfoComparer : IEqualityComparer<TopicInfo>
        {
            bool IEqualityComparer<TopicInfo>.Equals(TopicInfo x, TopicInfo y)
            {
                return x.DefaultMessageTimeToLive == y.DefaultMessageTimeToLive &&
                    x.DuplicateDetectionHistoryTimeWindow == y.DuplicateDetectionHistoryTimeWindow &&
                    x.EnableBatchedOperations == y.EnableBatchedOperations &&
                    x.MaximumSizeInMegabytes == y.MaximumSizeInMegabytes &&
                    x.RequiresDuplicateDetection == y.RequiresDuplicateDetection &&
                    x.SizeInBytes == y.SizeInBytes;
            }

            int IEqualityComparer<TopicInfo>.GetHashCode(TopicInfo obj)
            {
                return obj.GetHashCode();
            }
        }

        /// <summary>
        /// Comparer for the SubscriptionInfo type.
        /// </summary>
        private class InternalSubscriptionInfoComparer : IEqualityComparer<SubscriptionInfo>
        {
            bool IEqualityComparer<SubscriptionInfo>.Equals(SubscriptionInfo x, SubscriptionInfo y)
            {
                return
                    x.LockDuration == y.LockDuration &&
                    x.MaximumDeliveryCount == y.MaximumDeliveryCount &&
                    x.MessageCount == y.MessageCount &&
                    x.RequiresSession == y.RequiresSession;
            }

            int IEqualityComparer<SubscriptionInfo>.GetHashCode(SubscriptionInfo obj)
            {
                return obj.GetHashCode();
            }
        }

        IServiceBusService Service { get { return Configuration.ServiceBus; } }
        IEqualityComparer<QueueInfo> QueueInfoComparer { get; set; }
        IEqualityComparer<TopicInfo> TopicInfoComparer { get; set; }
        IEqualityComparer<SubscriptionInfo> SubscriptionInfoComparer { get; set; }

        public ManagementTests()
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
            using (UniqueSubscription subscription = new UniqueSubscription())
            {
                FILTER filter = createFilter();
                string originalContent = getContent(filter);
                string ruleName = "rule." + Guid.NewGuid().ToString();
                RuleSettings settings = new RuleSettings(filter, null);
                RuleInfo rule = Service.CreateRuleAsync(subscription.TopicName, subscription.SubscriptionName, ruleName, settings)
                    .AsTask<RuleInfo>().Result;

                Assert.IsTrue(rule.Action is EmptyRuleAction);
                Assert.IsTrue(rule.Filter is FILTER);

                string newContent = getContent((FILTER)rule.Filter);
                Assert.AreEqual(originalContent, newContent, false, CultureInfo.InvariantCulture);
            }
        }

        private void TestAction<ACTION>(Func<ACTION> createAction, Func<ACTION, string> getContent) where ACTION : IRuleAction
        {
            using (UniqueSubscription subscription = new UniqueSubscription())
            {
                ACTION action = createAction();
                string originalContent = getContent(action);
                string ruleName = "rule." + Guid.NewGuid().ToString();
                RuleSettings settings = new RuleSettings(new SqlRuleFilter("1=1"), action);
                RuleInfo rule = Service.CreateRuleAsync(subscription.TopicName, subscription.SubscriptionName, ruleName, settings)
                    .AsTask<RuleInfo>().Result;

                Assert.IsTrue(rule.Action is ACTION);

                string newContent = getContent((ACTION)rule.Action);
                Assert.AreEqual(originalContent, newContent, false, CultureInfo.InvariantCulture);
            }
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
                    Assert.AreEqual(readItems.Count, 1);
                    TInfo item = readItems[0];
                    string name = getName(item);

                    Assert.IsFalse(allItems.ContainsKey(name));
                    allItems.Add(name, item);
                }

                Assert.IsTrue(allItems.Count >= createdItems.Count);

                // Confirm that we've read everything we had created.
                foreach (TInfo createdItem in createdItems.Values)
                {
                    Assert.IsTrue(allItems.ContainsKey(getName(createdItem)));
                }

                // Request more items that present in the database.
                {
                    List<TInfo> items = new List<TInfo>(
                        listItems(0, allItems.Count + 1).AsTask().Result);
                    Assert.AreEqual(items.Count, allItems.Count);
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
            Assert.ThrowsException<ArgumentException>(() => listItems(-1, 1));
            Assert.ThrowsException<ArgumentException>(() => listItems(0, 0));
            Assert.ThrowsException<ArgumentException>(() => listItems(0, -1));
        }

        /// <summary>
        /// Tests null arguments in queue management API.
        /// </summary>
        [TestMethod]
        public void NullArgsInQueues()
        {
            QueueSettings validSettings = new QueueSettings();
            Assert.ThrowsException<ArgumentNullException>(() => Service.CreateQueueAsync(null));
            Assert.ThrowsException<ArgumentException>(() => Service.CreateQueueAsync(""));
            Assert.ThrowsException<ArgumentException>(() => Service.CreateQueueAsync(" "));
            Assert.ThrowsException<ArgumentNullException>(() => Service.CreateQueueAsync(null, validSettings));
            Assert.ThrowsException<ArgumentException>(() => Service.CreateQueueAsync("", validSettings));
            Assert.ThrowsException<ArgumentException>(() => Service.CreateQueueAsync(" ", validSettings));
            Assert.ThrowsException<ArgumentNullException>(() => Service.CreateQueueAsync("foo", null));
            Assert.ThrowsException<ArgumentNullException>(() => Service.GetQueueAsync(null));
            Assert.ThrowsException<ArgumentException>(() => Service.GetQueueAsync(""));
            Assert.ThrowsException<ArgumentException>(() => Service.GetQueueAsync(" "));
            Assert.ThrowsException<ArgumentNullException>(() => Service.DeleteQueueAsync(null));
            Assert.ThrowsException<ArgumentException>(() => Service.DeleteQueueAsync(""));
            Assert.ThrowsException<ArgumentException>(() => Service.DeleteQueueAsync(" "));
        }

        /// <summary>
        /// Tests full lifecycle of a queue.
        /// </summary>
        [TestMethod]
        public void QueueLifecycle()
        {
            // Create a queue.
            string queueName = Configuration.GetUniqueQueueName();
            QueueInfo newQueue = Service.CreateQueueAsync(queueName).AsTask<QueueInfo>().Result;

            // Confirm that the queue can be obtained from the server
            QueueInfo storedQueue = Service.GetQueueAsync(queueName).AsTask<QueueInfo>().Result;
            Assert.IsTrue(QueueInfoComparer.Equals(storedQueue, newQueue));

            // Confirm that the queue can be obtained in the list
            Dictionary<string, QueueInfo> queues = GetItems(
                () => { return Service.ListQueuesAsync(); },
                (queue) => { return queue.Name; });

            Assert.IsTrue(queues.ContainsKey(queueName));
            Assert.IsTrue(QueueInfoComparer.Equals(newQueue, queues[queueName]));

            // Delete the queue
            Service.DeleteQueueAsync(queueName).AsTask().Wait();
            queues = GetItems(
                () => { return Service.ListQueuesAsync(); },
                (queue) => { return queue.Name; });

            Assert.IsFalse(queues.ContainsKey(queueName));
        }

        /// <summary>
        /// Tests listing queues in the given range.
        /// </summary>
        [TestMethod]
        public void ListQueuesInRange()
        {
            TestListItemsInRange<QueueInfo>(
                () => Service.CreateQueueAsync(Configuration.GetUniqueQueueName()),
                (firstItem, count) => Service.ListQueuesAsync(firstItem, count),
                queue => Service.DeleteQueueAsync(queue.Name),
                queue => queue.Name);
        }

        /// <summary>
        /// Tests specifying invalid arguments in ListQueues method.
        /// </summary>
        [TestMethod]
        public void ListQueuesInvalidArgs()
        {
            TestInvalidArgsInListItems<QueueInfo>(
                (firstItem, count) => Service.ListQueuesAsync(firstItem, count));
        }

        /// <summary>
        /// Tests specifying range when listing topics.
        /// </summary>
        [TestMethod]
        public void ListTopicsInRange()
        {
            TestListItemsInRange<TopicInfo>(
                () => Service.CreateTopicAsync(Configuration.GetUniqueTopicName()),
                (firstItem, count) => Service.ListTopicsAsync(firstItem, count),
                topic => Service.DeleteTopicAsync(topic.Name),
                topic => topic.Name);
        }

        /// <summary>
        /// Tests specifying invalid arguments when listing topics.
        /// </summary>
        [TestMethod]
        public void ListTopicsInvalidArgs()
        {
            TestInvalidArgsInListItems<TopicInfo>(
                (firstItem, count) => Service.ListTopicsAsync(firstItem, count));
        }

        /// <summary>
        /// Tests specifying range when listing subscriptions.
        /// </summary>
        [TestMethod]
        public void ListSubscriptionsInRange()
        {
            using (UniqueTopic topic = new UniqueTopic())
            {
                TestListItemsInRange<SubscriptionInfo>(
                    () => Service.CreateSubscriptionAsync(topic.TopicName, Configuration.GetUniqueSubscriptionName()),
                    (firstItem, count) => Service.ListSubscriptionsAsync(topic.TopicName, firstItem, count),
                    subscription => Service.DeleteSubscriptionAsync(topic.TopicName, subscription.Name),
                    subscription => subscription.Name);
            }
        }

        /// <summary>
        /// Tests specifying invalid arguments when listing subscriptions.
        /// </summary>
        [TestMethod]
        public void ListSubscriptionsInvalidArgs()
        {
            TestInvalidArgsInListItems<SubscriptionInfo>(
                (firstItem, count) => Service.ListSubscriptionsAsync("test", firstItem, count));

            Assert.ThrowsException<ArgumentNullException>(() => Service.ListSubscriptionsAsync(null, 1, 1));
            Assert.ThrowsException<ArgumentException>(() => Service.ListSubscriptionsAsync("", 1, 1));
            Assert.ThrowsException<ArgumentException>(() => Service.ListSubscriptionsAsync(" ", 1, 1));
        }

        /// <summary>
        /// Tests specifying ranges when listing rules.
        /// </summary>
        [TestMethod]
        public void ListRulesInRange()
        {
            using (UniqueSubscription subscription = new UniqueSubscription())
            {
                string topicName = subscription.TopicName;
                string subscriptionName = subscription.SubscriptionName;

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
        }

        /// <summary>
        /// Tests specifying invalid arguments when listing rules.
        /// </summary>
        [TestMethod]
        public void ListRulesInvalidArgs()
        {
            TestInvalidArgsInListItems<RuleInfo>(
                (firstItem, count) => Service.ListRulesAsync("topic", "subscription", firstItem, count));

            Assert.ThrowsException<ArgumentNullException>(() => Service.ListRulesAsync(null, "subscription", 0, 1));
            Assert.ThrowsException<ArgumentException>(() => Service.ListRulesAsync("", "subscription", 0, 1));
            Assert.ThrowsException<ArgumentException>(() => Service.ListRulesAsync(" ", "subscription", 0, 1));
            Assert.ThrowsException<ArgumentNullException>(() => Service.ListRulesAsync("topic", null, 0, 1));
            Assert.ThrowsException<ArgumentException>(() => Service.ListRulesAsync("topic", "", 0, 1));
            Assert.ThrowsException<ArgumentException>(() => Service.ListRulesAsync("topic", " ", 0, 1));

            Assert.ThrowsException<ArgumentException>(() => Service.ListRulesAsync("topic", "subscription", -1, 1));
            Assert.ThrowsException<ArgumentException>(() => Service.ListRulesAsync("topic", "subscripiton", 0, 0));
        }

        /// <summary>
        /// Verifies that using an existing name for a new queue result in an exception.
        /// </summary>
        [TestMethod]
        public void CreateQueueDuplicateName()
        {
            using (UniqueQueue queue = new UniqueQueue())
            {
                Task t = Service.CreateQueueAsync(queue.QueueName).AsTask();
                Assert.ThrowsException<AggregateException>(() => t.Wait());
            }
        }

        /// <summary>
        /// Tests getting a missing queue.
        /// </summary>
        [TestMethod]
        public void GetMissingQueue()
        {
            string queueName = Configuration.GetUniqueQueueName();
            Task t = Service.GetQueueAsync(queueName).AsTask();
            Assert.ThrowsException<AggregateException>(() => t.Wait());
        }

        /// <summary>
        /// Tests deleting a missing queue.
        /// </summary>
        [TestMethod]
        public void DeleteMissingQueue()
        {
            string queueName = Configuration.GetUniqueQueueName();
            Task t = Service.DeleteQueueAsync(queueName).AsTask();
            Assert.ThrowsException<AggregateException>(() => t.Wait());
        }

        /// <summary>
        /// Verifies creation of the queue with all non-default parameters
        /// </summary>
        [TestMethod]
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

            QueueInfo queueInfo = Service.CreateQueueAsync(queueName, settings).AsTask<QueueInfo>().Result;
            try
            {
                Assert.AreEqual(queueInfo.DefaultMessageTimeToLive, settings.DefaultMessageTimeToLive.Value);
                Assert.AreEqual(queueInfo.DuplicateDetectionHistoryTimeWindow, settings.DuplicateDetectionHistoryTimeWindow.Value);
                Assert.AreEqual(queueInfo.EnableBatchedOperations, settings.EnableBatchedOperations.Value);
                Assert.AreEqual(queueInfo.EnableDeadLetteringOnMessageExpiration, settings.EnableDeadLetteringOnMessageExpiration.Value);
                Assert.AreEqual(queueInfo.LockDuration, settings.LockDuration.Value);
                Assert.AreEqual(queueInfo.MaximumDeliveryCount, settings.MaximumDeliveryCount.Value);
                Assert.AreEqual(queueInfo.MaximumSizeInMegabytes, settings.MaximumSizeInMegabytes.Value);
                Assert.AreEqual(queueInfo.RequiresDuplicateDetection, settings.RequiresDuplicateDetection.Value);
                Assert.AreEqual(queueInfo.RequiresSession, settings.RequiresSession.Value);
            }
            finally
            {
                Service.DeleteQueueAsync(queueName).AsTask().Wait();
            }
        }

        /// <summary>
        /// Tests throwing ArgumentNullException for topic management API.
        /// </summary>
        [TestMethod]
        public void NullArgsInTopics()
        {
            TopicSettings validSettings = new TopicSettings();

            Assert.ThrowsException<ArgumentNullException>(() => Service.CreateTopicAsync(null));
            Assert.ThrowsException<ArgumentException>(() => Service.CreateTopicAsync(""));
            Assert.ThrowsException<ArgumentException>(() => Service.CreateTopicAsync(" "));
            Assert.ThrowsException<ArgumentNullException>(() => Service.CreateTopicAsync(null, validSettings));
            Assert.ThrowsException<ArgumentException>(() => Service.CreateTopicAsync("", validSettings));
            Assert.ThrowsException<ArgumentException>(() => Service.CreateTopicAsync(" ", validSettings));
            Assert.ThrowsException<ArgumentNullException>(() => Service.CreateTopicAsync("foo", null));
            Assert.ThrowsException<ArgumentNullException>(() => Service.GetTopicAsync(null));
            Assert.ThrowsException<ArgumentException>(() => Service.GetTopicAsync(""));
            Assert.ThrowsException<ArgumentException>(() => Service.GetTopicAsync(" "));
            Assert.ThrowsException<ArgumentNullException>(() => Service.DeleteTopicAsync(null));
            Assert.ThrowsException<ArgumentException>(() => Service.DeleteQueueAsync(""));
            Assert.ThrowsException<ArgumentException>(() => Service.DeleteQueueAsync(" "));
        }

        /// <summary>
        /// Tests the complete lifecycle of a topic.
        /// </summary>
        [TestMethod]
        public void TopicLifecycle()
        {
            // Create a topic
            string topicName = Configuration.GetUniqueTopicName();
            TopicInfo newTopic = Service.CreateTopicAsync(topicName).AsTask<TopicInfo>().Result;

            // Confirm that the topic can be obtained from the server.
            TopicInfo storedTopic = Service.GetTopicAsync(topicName).AsTask<TopicInfo>().Result;
            Assert.IsTrue(TopicInfoComparer.Equals(storedTopic, newTopic));

            // Conmfirm that the topic can be obtained in the list.
            Dictionary<string, TopicInfo> topics = GetItems(
                () => { return Service.ListTopicsAsync(); },
                (t) => { return t.Name; });
            Assert.IsTrue(topics.ContainsKey(topicName));
            Assert.IsTrue(TopicInfoComparer.Equals(newTopic, topics[topicName]));

            // Delete the topic.
            Service.DeleteTopicAsync(topicName).AsTask().Wait();
            topics = GetItems(
                () => { return Service.ListTopicsAsync(); },
                (t) => { return t.Name; });

            Assert.IsFalse(topics.ContainsKey(topicName));
        }

        /// <summary>
        /// Tests creating two topics with identical names.
        /// </summary>
        [TestMethod]
        public void CreateTopicDuplicateName()
        {
            using (UniqueTopic topic = new UniqueTopic())
            {
                Task t = Service.CreateTopicAsync(topic.TopicName).AsTask();
                Assert.ThrowsException<AggregateException>(() => t.Wait());
            }
        }

        /// <summary>
        /// Tests getting a missing topic.
        /// </summary>
        [TestMethod]
        public void GetMissingTopic()
        {
            string topicName = Configuration.GetUniqueTopicName();
            Task t = Service.GetTopicAsync(topicName).AsTask() ;
            Assert.ThrowsException<AggregateException>(() => t.Wait());
        }

        /// <summary>
        /// Tests deleting a missing topic.
        /// </summary>
        [TestMethod]
        public void DeleteMissingTopic()
        {
            string topicName = Configuration.GetUniqueTopicName();
            Task t = Service.DeleteTopicAsync(topicName).AsTask();
            Assert.ThrowsException<AggregateException>(() => t.Wait());
        }

        /// <summary>
        /// Tests creation of a topic with all non-default parameters.
        /// </summary>
        [TestMethod]
        public void CreateTopicWithNonDefaultParams()
        {
            string topicName = Configuration.GetUniqueTopicName();
            TopicSettings settings = new TopicSettings();

            settings.DefaultMessageTimeToLive = TimeSpan.FromHours(24);
            settings.DuplicateDetectionHistoryTimeWindow = TimeSpan.FromDays(2);
            settings.EnableBatchedOperations = false;
            settings.MaximumSizeInMegabytes = 2048;
            settings.RequiresDuplicateDetection = true;

            TopicInfo topic = Service.CreateTopicAsync(topicName, settings).AsTask<TopicInfo>().Result;
            try
            {
                Assert.AreEqual(settings.DefaultMessageTimeToLive.Value, topic.DefaultMessageTimeToLive);
                Assert.AreEqual(settings.DuplicateDetectionHistoryTimeWindow.Value, topic.DuplicateDetectionHistoryTimeWindow);
                Assert.AreEqual(settings.EnableBatchedOperations.Value, topic.EnableBatchedOperations);
                Assert.AreEqual(settings.MaximumSizeInMegabytes.Value, topic.MaximumSizeInMegabytes);
                Assert.AreEqual(settings.RequiresDuplicateDetection.Value, topic.RequiresDuplicateDetection);
            }
            finally
            {
                Service.DeleteTopicAsync(topicName).AsTask().Wait();
            }
        }

        /// <summary>
        /// Tests ArgumentNullException for subscription parameters.
        /// </summary>
        [TestMethod]
        public void InvalidArgsInSubscriptions()
        {
            SubscriptionSettings validSettings = new SubscriptionSettings();

            Assert.ThrowsException<ArgumentNullException>(() => Service.ListSubscriptionsAsync(null));
            Assert.ThrowsException<ArgumentException>(() => Service.ListSubscriptionsAsync(""));
            Assert.ThrowsException<ArgumentException>(() => Service.ListSubscriptionsAsync(" "));
            Assert.ThrowsException<ArgumentNullException>(() => Service.CreateSubscriptionAsync(null, "test"));
            Assert.ThrowsException<ArgumentException>(() => Service.CreateSubscriptionAsync("", "test"));
            Assert.ThrowsException<ArgumentException>(() => Service.CreateSubscriptionAsync(" ", "test"));
            Assert.ThrowsException<ArgumentNullException>(() => Service.CreateSubscriptionAsync("test", null));
            Assert.ThrowsException<ArgumentException>(() => Service.CreateSubscriptionAsync("test", ""));
            Assert.ThrowsException<ArgumentException>(() => Service.CreateSubscriptionAsync("test", " "));
            Assert.ThrowsException<ArgumentNullException>(() => Service.CreateSubscriptionAsync(null, "test", validSettings));
            Assert.ThrowsException<ArgumentException>(() => Service.CreateSubscriptionAsync("", "test", validSettings));
            Assert.ThrowsException<ArgumentException>(() => Service.CreateSubscriptionAsync(" ", "test", validSettings));
            Assert.ThrowsException<ArgumentNullException>(() => Service.CreateSubscriptionAsync("test", null, validSettings));
            Assert.ThrowsException<ArgumentException>(() => Service.CreateSubscriptionAsync("test", "", validSettings));
            Assert.ThrowsException<ArgumentException>(() => Service.CreateSubscriptionAsync("test", " ", validSettings));
            Assert.ThrowsException<ArgumentNullException>(() => Service.CreateSubscriptionAsync("test", "test", null));
            Assert.ThrowsException<ArgumentNullException>(() => Service.GetSubscriptionAsync(null, "test"));
            Assert.ThrowsException<ArgumentException>(() => Service.GetSubscriptionAsync("", "test"));
            Assert.ThrowsException<ArgumentException>(() => Service.GetSubscriptionAsync(" ", "test"));
            Assert.ThrowsException<ArgumentNullException>(() => Service.GetSubscriptionAsync("test", null));
            Assert.ThrowsException<ArgumentException>(() => Service.GetSubscriptionAsync("test", ""));
            Assert.ThrowsException<ArgumentException>(() => Service.GetSubscriptionAsync("test", " "));
            Assert.ThrowsException<ArgumentNullException>(() => Service.DeleteSubscriptionAsync(null, "test"));
            Assert.ThrowsException<ArgumentException>(() => Service.DeleteSubscriptionAsync("", "test"));
            Assert.ThrowsException<ArgumentException>(() => Service.DeleteSubscriptionAsync(" ", "test"));
            Assert.ThrowsException<ArgumentNullException>(() => Service.DeleteSubscriptionAsync("test", null));
            Assert.ThrowsException<ArgumentException>(() => Service.DeleteSubscriptionAsync("test", ""));
            Assert.ThrowsException<ArgumentException>(() => Service.DeleteSubscriptionAsync("test", " "));
        }

        /// <summary>
        /// Tests the complete lifetime of a subscription.
        /// </summary>
        [TestMethod]
        public void SubscriptionLifecycle()
        {
            using (UniqueTopic topic = new UniqueTopic())
            {
                string topicName = topic.TopicName;
                string subscriptionName = Configuration.GetUniqueSubscriptionName();

                // Create a subscription.
                SubscriptionInfo newSubscription = Service.CreateSubscriptionAsync(topicName, subscriptionName).AsTask().Result;

                // Confirm that the subscription can be obtained from the server.
                SubscriptionInfo storedSubscription = Service.GetSubscriptionAsync(topicName, subscriptionName).AsTask().Result;
                Assert.IsTrue(SubscriptionInfoComparer.Equals(storedSubscription, newSubscription));

                // Confirm that the subscription appears in the list.
                Dictionary<string, SubscriptionInfo> subscriptions = GetItems(
                    () => { return Service.ListSubscriptionsAsync(topicName); },
                    (s) => { return s.Name; });
                Assert.IsTrue(subscriptions.ContainsKey(subscriptionName));
                Assert.IsTrue(SubscriptionInfoComparer.Equals(newSubscription, subscriptions[subscriptionName]));

                // Delete the subscription.
                Service.DeleteSubscriptionAsync(topicName, subscriptionName).AsTask().Wait();
                subscriptions = GetItems(
                    () => { return Service.ListSubscriptionsAsync(topicName); },
                    (s) => { return s.Name; });

                Assert.IsFalse(subscriptions.ContainsKey(subscriptionName));
            }
        }

        /// <summary>
        /// Tests creating two subscriptions with identical names.
        /// </summary>
        [TestMethod]
        public void CreateSubscriptionDuplicateName()
        {
            using (UniqueSubscription subscription = new UniqueSubscription())
            {
                Task<SubscriptionInfo> task = Service.CreateSubscriptionAsync(subscription.TopicName, subscription.SubscriptionName).AsTask();
                Assert.ThrowsException<AggregateException>(() => task.Wait());
            }
        }

        /// <summary>
        /// Tests getting a non-existing subscription from an existing topic.
        /// </summary>
        [TestMethod]
        public void GetMissingSubscription()
        {
            using (UniqueTopic topic = new UniqueTopic())
            {
                string topicName = topic.TopicName;
                string subscriptionName = Configuration.GetUniqueSubscriptionName();

                Task<SubscriptionInfo> task = Service.GetSubscriptionAsync(topicName, subscriptionName).AsTask();
                Assert.ThrowsException<AggregateException>(() => task.Wait());
            }
        }

        /// <summary>
        /// Tests getting a subscription from a non-existing topic.
        /// </summary>
        [TestMethod]
        public void GetSubscriptionFromMissingTopic()
        {
            string topicName = Configuration.GetUniqueTopicName();
            string subscriptionName = Configuration.GetUniqueSubscriptionName();

            Task<SubscriptionInfo> task = Service.GetSubscriptionAsync(topicName, subscriptionName).AsTask();
            Assert.ThrowsException<AggregateException>(() => task.Wait());
        }

        /// <summary>
        /// Tests getting all subscriptions from a non-existing topic.
        /// </summary>
        [TestMethod]
        public void ListSubscriptionsInMissingTopic()
        {
            string topicName = Configuration.GetUniqueTopicName();

            List<SubscriptionInfo> subscriptions = new List<SubscriptionInfo>(
                Service.ListSubscriptionsAsync(topicName).AsTask<IEnumerable<SubscriptionInfo>>().Result);
            Assert.AreEqual(subscriptions.Count, 0);
        }

        /// <summary>
        /// Tests deleting a non-existing subscription.
        /// </summary>
        [TestMethod]
        public void DeleteMissingSubscription()
        {
            using (UniqueTopic topic = new UniqueTopic())
            {
                string topicName = topic.TopicName;
                string subscriptionName = Configuration.GetUniqueSubscriptionName();

                Task task = Service.DeleteSubscriptionAsync(topicName, subscriptionName).AsTask();
                Assert.ThrowsException<AggregateException>(() => task.Wait());
            }
        }

        /// <summary>
        /// Tests subscribing to a queue.
        /// </summary>
        [TestMethod]
        public void SubscribeToQueue()
        {
            using (UniqueQueue queue = new UniqueQueue())
            {
                string queueName = queue.QueueName;
                string subscriptionName = Configuration.GetUniqueSubscriptionName();

                Assert.ThrowsException<AggregateException>(() => Service.CreateSubscriptionAsync(queueName, subscriptionName).AsTask().Wait());
            }
        }

        /// <summary>
        /// Tests null argument exceptions in rule methods.
        /// </summary>
        [TestMethod]
        public void InvalidArgsInRules()
        {
            RuleSettings validSettings = new RuleSettings(new SqlRuleFilter("1=1"), null);
            Assert.ThrowsException<ArgumentNullException>(() => Service.CreateRuleAsync(null, "test", "test", validSettings));
            Assert.ThrowsException<ArgumentException>(() => Service.CreateRuleAsync("", "test", "test", validSettings));
            Assert.ThrowsException<ArgumentException>(() => Service.CreateRuleAsync(" ", "test", "test", validSettings));
            Assert.ThrowsException<ArgumentNullException>(() => Service.CreateRuleAsync("test", null, "test", validSettings));
            Assert.ThrowsException<ArgumentException>(() => Service.CreateRuleAsync("test", "", "test", validSettings));
            Assert.ThrowsException<ArgumentException>(() => Service.CreateRuleAsync("test", " ", "test", validSettings));
            Assert.ThrowsException<ArgumentNullException>(() => Service.CreateRuleAsync("test", "test", null, validSettings));
            Assert.ThrowsException<ArgumentException>(() => Service.CreateRuleAsync("test", "test", "", validSettings));
            Assert.ThrowsException<ArgumentException>(() => Service.CreateRuleAsync("test", "test", " ", validSettings));
            Assert.ThrowsException<ArgumentNullException>(() => Service.CreateRuleAsync("test", "test", "test", null));

            Assert.ThrowsException<ArgumentNullException>(() => Service.ListRulesAsync(null, "test"));
            Assert.ThrowsException<ArgumentException>(() => Service.ListRulesAsync("", "test"));
            Assert.ThrowsException<ArgumentException>(() => Service.ListRulesAsync(" ", "test"));
            Assert.ThrowsException<ArgumentNullException>(() => Service.ListRulesAsync("test", null));
            Assert.ThrowsException<ArgumentException>(() => Service.ListRulesAsync("test", ""));
            Assert.ThrowsException<ArgumentException>(() => Service.ListRulesAsync("test", " "));

            Assert.ThrowsException<ArgumentNullException>(() => Service.GetRuleAsync(null, "test", "test"));
            Assert.ThrowsException<ArgumentException>(() => Service.GetRuleAsync("", "test", "test"));
            Assert.ThrowsException<ArgumentException>(() => Service.GetRuleAsync(" ", "test", "test"));
            Assert.ThrowsException<ArgumentNullException>(() => Service.GetRuleAsync("test", null, "test"));
            Assert.ThrowsException<ArgumentException>(() => Service.GetRuleAsync("test", "", "test"));
            Assert.ThrowsException<ArgumentException>(() => Service.GetRuleAsync("test", " ", "test"));
            Assert.ThrowsException<ArgumentNullException>(() => Service.GetRuleAsync("test", "test", null));
            Assert.ThrowsException<ArgumentException>(() => Service.GetRuleAsync("test", "test", ""));
            Assert.ThrowsException<ArgumentException>(() => Service.GetRuleAsync("test", "test", " "));

            Assert.ThrowsException<ArgumentNullException>(() => Service.DeleteRuleAsync(null, "test", "test"));
            Assert.ThrowsException<ArgumentException>(() => Service.DeleteRuleAsync("", "test", "test"));
            Assert.ThrowsException<ArgumentException>(() => Service.DeleteRuleAsync(" ", "test", "test"));
            Assert.ThrowsException<ArgumentNullException>(() => Service.DeleteRuleAsync("test", null, "test"));
            Assert.ThrowsException<ArgumentException>(() => Service.DeleteRuleAsync("test", "", "test"));
            Assert.ThrowsException<ArgumentException>(() => Service.DeleteRuleAsync("test", " ", "test"));
            Assert.ThrowsException<ArgumentNullException>(() => Service.DeleteRuleAsync("test", "test", null));
            Assert.ThrowsException<ArgumentException>(() => Service.DeleteRuleAsync("test", "test", ""));
            Assert.ThrowsException<ArgumentException>(() => Service.DeleteRuleAsync("test", "test", " "));

            Assert.ThrowsException<ArgumentNullException>(() => new SqlRuleFilter(null));
            Assert.ThrowsException<ArgumentException>(() => new SqlRuleFilter(""));
            Assert.ThrowsException<ArgumentException>(() => new SqlRuleFilter(" "));
            Assert.ThrowsException<ArgumentNullException>(() => new TrueRuleFilter(null));
            Assert.ThrowsException<ArgumentException>(() => new TrueRuleFilter(""));
            Assert.ThrowsException<ArgumentException>(() => new TrueRuleFilter(" "));
            Assert.ThrowsException<ArgumentNullException>(() => new FalseRuleFilter(null));
            Assert.ThrowsException<ArgumentException>(() => new FalseRuleFilter(""));
            Assert.ThrowsException<ArgumentException>(() => new FalseRuleFilter(" "));

            Assert.ThrowsException<ArgumentNullException>(() => new SqlRuleAction(null));
            Assert.ThrowsException<ArgumentException>(() => new SqlRuleAction(""));
            Assert.ThrowsException<ArgumentException>(() => new SqlRuleAction(" "));
        }

        /// <summary>
        /// Tests SQL rule filters.
        /// </summary>
        [TestMethod]
        public void SqlRuleFilter()
        {
            TestRule<SqlRuleFilter>(
                () => { return new SqlRuleFilter("1=1"); },
                (rf) => { return rf.Expression; });
        }

        /// <summary>
        /// Tests true rule filters.
        /// </summary>
        [TestMethod]
        public void TrueRuleFilter()
        {
            TestRule<TrueRuleFilter>(
                () => { return new TrueRuleFilter("1=1"); },
                (rf) => { return rf.Expression; });
        }

        /// <summary>
        /// Tests false rule filters.
        /// </summary>
        [TestMethod]
        public void FalseRuleFilter()
        {
            TestRule<FalseRuleFilter>(
                () => { return new FalseRuleFilter("1=1"); },
                (rf) => { return rf.Expression; });
        }

        /// <summary>
        /// Tests correlation rule filters.
        /// </summary>
        [TestMethod]
        public void CorrelationRuleFilter()
        {
            TestRule<CorrelationRuleFilter>(
                () => { return new CorrelationRuleFilter("abc"); },
                (rf) => { return rf.CorrelationId; });
        }

        /// <summary>
        /// Tests empty rule action.
        /// </summary>
        [TestMethod]
        public void EmptyRuleAction()
        {
            TestAction<EmptyRuleAction>(() => new EmptyRuleAction(), (a) => { return string.Empty; });
        }

        /// <summary>
        /// Tests SQL rule action.
        /// </summary>
        [TestMethod]
        public void SqlRuleAction()
        {
            TestAction<SqlRuleAction>(() => new SqlRuleAction("set x=y"), (a) => { return a.Action; });
        }

        /// <summary>
        /// Tests complete lifecycle of a rule.
        /// </summary>
        [TestMethod]
        public void RuleLifecycle()
        {
            using (UniqueSubscription subscription = new UniqueSubscription())
            {
                // Create rule.
                SqlRuleFilter filter = new SqlRuleFilter("1=1");
                RuleSettings settings = new RuleSettings(filter, null);
                string ruleName = "testrule." + Guid.NewGuid().ToString();
                RuleInfo rule = Service.CreateRuleAsync(subscription.TopicName, subscription.SubscriptionName, ruleName, settings)
                    .AsTask<RuleInfo>().Result;

                Assert.AreEqual(ruleName, rule.Name, true, CultureInfo.InvariantCulture);

                // Read the rule
                RuleInfo savedRule = Service.GetRuleAsync(subscription.TopicName, subscription.SubscriptionName, ruleName)
                    .AsTask<RuleInfo>().Result;
                Assert.AreEqual(ruleName, savedRule.Name, true, CultureInfo.InvariantCulture);
                Assert.IsTrue(savedRule.Action is EmptyRuleAction);
                Assert.IsTrue(savedRule.Filter is SqlRuleFilter);
                Assert.AreEqual(((SqlRuleFilter)savedRule.Filter).Expression, filter.Expression, true, CultureInfo.InvariantCulture);

                // Read from the list.
                Dictionary<string, RuleInfo> allRules = GetItems<RuleInfo>(
                    () => { return Service.ListRulesAsync(subscription.TopicName, subscription.SubscriptionName); },
                    (r) => { return r.Name; });
                Assert.IsTrue(allRules.ContainsKey(ruleName));

                // Delete the rule.
                Service.DeleteRuleAsync(subscription.TopicName, subscription.SubscriptionName, ruleName).AsTask().Wait();
                allRules = GetItems<RuleInfo>(
                    () => { return Service.ListRulesAsync(subscription.TopicName, subscription.SubscriptionName); },
                    (r) => { return r.Name; });
                Assert.IsFalse(allRules.ContainsKey(ruleName));
            }
        }

        /// <summary>
        /// Tests passing invalid arguments in creating a service.
        /// </summary>
        [TestMethod]
        public void InvalidArgsInCreateService()
        {
            Assert.ThrowsException<ArgumentNullException>(() => ServiceBusService.Create(null, "user", "password"));
            Assert.ThrowsException<ArgumentException>(() => ServiceBusService.Create("", "user", "password"));
            Assert.ThrowsException<ArgumentException>(() => ServiceBusService.Create(" ", "user", "password"));
            Assert.ThrowsException<ArgumentNullException>(() => ServiceBusService.Create("namespace", null, "password"));
            Assert.ThrowsException<ArgumentException>(() => ServiceBusService.Create("namespace", "", "password"));
            Assert.ThrowsException<ArgumentException>(() => ServiceBusService.Create("namespace", " ", "password"));
            Assert.ThrowsException<ArgumentNullException>(() => ServiceBusService.Create("namespace", "user", null));

            IHttpHandler validHandler = new HttpDefaultHandler();
            Assert.ThrowsException<ArgumentNullException>(() => ServiceBusService.Create(null, validHandler));
            Assert.ThrowsException<ArgumentException>(() => ServiceBusService.Create("", validHandler));
            Assert.ThrowsException<ArgumentException>(() => ServiceBusService.Create(" ", validHandler));
            Assert.ThrowsException<ArgumentNullException>(() => ServiceBusService.Create("namespace", null));
        }
    }
}
