﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Administration;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Samples
{
    public class Sample07_CrudOperations : ServiceBusLiveTestBase
    {
        [Test]
        public async Task CreateQueue()
        {
#if !SNIPPET
            string queueName = Guid.NewGuid().ToString("D").Substring(0, 8);
            string connectionString = TestEnvironment.ServiceBusConnectionString;
#endif
            try
            {
                #region Snippet:CreateQueue
#if SNIPPET
                string connectionString = "<connection_string>";
                string queueName = "<queue_name>";
#endif
                var client = new ServiceBusAdministrationClient(connectionString);
                var options = new CreateQueueOptions(queueName)
                {
                    AutoDeleteOnIdle = TimeSpan.FromDays(7),
                    DefaultMessageTimeToLive = TimeSpan.FromDays(2),
                    DuplicateDetectionHistoryTimeWindow = TimeSpan.FromMinutes(1),
                    EnableBatchedOperations = true,
                    DeadLetteringOnMessageExpiration = true,
                    EnablePartitioning = false,
                    ForwardDeadLetteredMessagesTo = null,
                    ForwardTo = null,
                    LockDuration = TimeSpan.FromSeconds(45),
                    MaxDeliveryCount = 8,
                    MaxSizeInMegabytes = 2048,
                    RequiresDuplicateDetection = true,
                    RequiresSession = true,
                    UserMetadata = "some metadata"
                };

                options.AuthorizationRules.Add(new SharedAccessAuthorizationRule(
                    "allClaims",
                    new[] { AccessRights.Manage, AccessRights.Send, AccessRights.Listen }));

                QueueProperties createdQueue = await client.CreateQueueAsync(options);
                #endregion
                Assert.AreEqual(options, new CreateQueueOptions(createdQueue));
            }
            finally
            {
                await new ServiceBusAdministrationClient(connectionString).DeleteQueueAsync(queueName);
            }
        }

        [Test]
        public async Task GetUpdateDeleteQueue()
        {
            string queueName = Guid.NewGuid().ToString("D").Substring(0, 8);
            string connectionString = TestEnvironment.ServiceBusConnectionString;
            var client = new ServiceBusAdministrationClient(connectionString);
            var qd = new CreateQueueOptions(queueName);
            await client.CreateQueueAsync(qd);

            #region Snippet:GetQueue
            QueueProperties queue = await client.GetQueueAsync(queueName);
            #endregion
            #region Snippet:UpdateQueue
            queue.LockDuration = TimeSpan.FromSeconds(60);
            QueueProperties updatedQueue = await client.UpdateQueueAsync(queue);
            #endregion
            Assert.AreEqual(TimeSpan.FromSeconds(60), updatedQueue.LockDuration);
            #region Snippet:DeleteQueue
            await client.DeleteQueueAsync(queueName);
            #endregion
            Assert.That(
                  async () =>
                  await client.GetQueueAsync(queueName),
                  Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.MessagingEntityNotFound));
        }

        [Test]
        public async Task CreateTopicAndSubscription()
        {
#if !SNIPPET
            string topicName = Guid.NewGuid().ToString("D").Substring(0, 8);
            string subscriptionName = Guid.NewGuid().ToString("D").Substring(0, 8);
            string connectionString = TestEnvironment.ServiceBusConnectionString;
            var client = new ServiceBusAdministrationClient(connectionString);
#endif
            try
            {
                #region Snippet:CreateTopicAndSubscription
#if SNIPPET
                string connectionString = "<connection_string>";
                string topicName = "<topic_name>";
                var client = new ServiceBusManagementClient(connectionString);
#endif
                var topicOptions = new CreateTopicOptions(topicName)
                {
                    AutoDeleteOnIdle = TimeSpan.FromDays(7),
                    DefaultMessageTimeToLive = TimeSpan.FromDays(2),
                    DuplicateDetectionHistoryTimeWindow = TimeSpan.FromMinutes(1),
                    EnableBatchedOperations = true,
                    EnablePartitioning = false,
                    MaxSizeInMegabytes = 2048,
                    RequiresDuplicateDetection = true,
                    UserMetadata = "some metadata"
                };

                topicOptions.AuthorizationRules.Add(new SharedAccessAuthorizationRule(
                    "allClaims",
                    new[] { AccessRights.Manage, AccessRights.Send, AccessRights.Listen }));

                TopicProperties createdTopic = await client.CreateTopicAsync(topicOptions);

#if SNIPPET
                string subscriptionName = "<subscription_name>";
#endif
                var subscriptionOptions = new CreateSubscriptionOptions(topicName, subscriptionName)
                {
                    AutoDeleteOnIdle = TimeSpan.FromDays(7),
                    DefaultMessageTimeToLive = TimeSpan.FromDays(2),
                    EnableBatchedOperations = true,
                    UserMetadata = "some metadata"
                };
                SubscriptionProperties createdSubscription = await client.CreateSubscriptionAsync(subscriptionOptions);
                #endregion
                Assert.AreEqual(topicOptions, new CreateTopicOptions(createdTopic));
                Assert.AreEqual(subscriptionOptions, new CreateSubscriptionOptions(createdSubscription));
            }
            finally
            {
                await client.DeleteTopicAsync(topicName);
            }
        }

        [Test]
        public async Task GetUpdateDeleteTopicAndSubscription()
        {
            string topicName = Guid.NewGuid().ToString("D").Substring(0, 8);
            string subscriptionName = Guid.NewGuid().ToString("D").Substring(0, 8);
            string connectionString = TestEnvironment.ServiceBusConnectionString;
            var client = new ServiceBusAdministrationClient(connectionString);
            var topicOptions = new CreateTopicOptions(topicName);
            var subscriptionOptions = new CreateSubscriptionOptions(topicName, subscriptionName);
            await client.CreateTopicAsync(topicOptions);
            await client.CreateSubscriptionAsync(subscriptionOptions);
            #region Snippet:GetTopic
            TopicProperties topic = await client.GetTopicAsync(topicName);
            #endregion
            #region Snippet:GetSubscription
            SubscriptionProperties subscription = await client.GetSubscriptionAsync(topicName, subscriptionName);
            #endregion
            #region Snippet:UpdateTopic
            topic.UserMetadata = "some metadata";
            TopicProperties updatedTopic = await client.UpdateTopicAsync(topic);
            #endregion
            Assert.AreEqual("some metadata", updatedTopic.UserMetadata);

            #region Snippet:UpdateSubscription
            subscription.UserMetadata = "some metadata";
            SubscriptionProperties updatedSubscription = await client.UpdateSubscriptionAsync(subscription);
            #endregion
            Assert.AreEqual("some metadata", updatedSubscription.UserMetadata);

            // need to delete the subscription before the topic, as deleting
            // the topic would automatically delete the subscription
            #region Snippet:DeleteSubscription
            await client.DeleteSubscriptionAsync(topicName, subscriptionName);
            #endregion
            Assert.That(
                  async () =>
                  await client.GetSubscriptionAsync(topicName, subscriptionName),
                  Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.MessagingEntityNotFound));

            #region Snippet:DeleteTopic
            await client.DeleteTopicAsync(topicName);
            #endregion
            Assert.That(
                  async () =>
                  await client.GetTopicAsync(topicName),
                  Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.MessagingEntityNotFound));
        }
    }
}
