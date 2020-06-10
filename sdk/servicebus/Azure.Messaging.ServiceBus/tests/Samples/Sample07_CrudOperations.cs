// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Management;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Samples
{
    public class Sample07_CrudOperations : ServiceBusLiveTestBase
    {
        [Test]
        public async Task CreateQueue()
        {
            string queueName = Guid.NewGuid().ToString("D").Substring(0, 8);
            string connectionString = TestEnvironment.ServiceBusConnectionString;

            try
            {
                #region Snippet:CreateQueue
                //@@ string connectionString = "<connection_string>";
                //@@ string queueName = "<queue_name>";
                var client = new ServiceBusManagementClient(connectionString);
                var queueDescription = new QueueDescription(queueName)
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

                queueDescription.AuthorizationRules.Add(new SharedAccessAuthorizationRule(
                    "allClaims",
                    new[] { AccessRights.Manage, AccessRights.Send, AccessRights.Listen }));

                // The CreateQueueAsync method will return the created queue
                // which would include values for all of the
                // QueueDescription properties (the service will supply
                // default values for properties not included in the creation).
                QueueDescription createdQueue = await client.CreateQueueAsync(queueDescription);
                #endregion
                Assert.AreEqual(queueDescription, createdQueue);
            }
            finally
            {
                await new ServiceBusManagementClient(connectionString).DeleteQueueAsync(queueName);
            }
        }

        [Test]
        public async Task GetUpdateDeleteQueue()
        {
            string queueName = Guid.NewGuid().ToString("D").Substring(0, 8);
            string connectionString = TestEnvironment.ServiceBusConnectionString;
            var client = new ServiceBusManagementClient(connectionString);
            var qd = new QueueDescription(queueName);
            await client.CreateQueueAsync(qd);

            #region Snippet:GetQueue
            QueueDescription queueDescription = await client.GetQueueAsync(queueName);
            #endregion
            #region Snippet:UpdateQueue
            queueDescription.LockDuration = TimeSpan.FromSeconds(60);
            QueueDescription updatedQueue = await client.UpdateQueueAsync(queueDescription);
            #endregion
            Assert.AreEqual(TimeSpan.FromSeconds(60), updatedQueue.LockDuration);
            #region Snippet:DeleteQueue
            await client.DeleteQueueAsync(queueName);
            #endregion
            Assert.That(
                  async () =>
                  await client.GetQueueAsync(queueName),
                  Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.MessagingEntityNotFound));
        }


        [Test]
        public async Task CreateTopicAndSubscription()
        {
            string topicName = Guid.NewGuid().ToString("D").Substring(0, 8);
            string subscriptionName = Guid.NewGuid().ToString("D").Substring(0, 8);
            string connectionString = TestEnvironment.ServiceBusConnectionString;
            var client = new ServiceBusManagementClient(connectionString);

            try
            {
                #region Snippet:CreateTopicAndSubscription
                //@@ string connectionString = "<connection_string>";
                //@@ string topicName = "<topic_name>";
                //@@ var client = new ServiceBusManagementClient(connectionString);
                var topicDescription = new TopicDescription(topicName)
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

                topicDescription.AuthorizationRules.Add(new SharedAccessAuthorizationRule(
                    "allClaims",
                    new[] { AccessRights.Manage, AccessRights.Send, AccessRights.Listen }));

                TopicDescription createdTopic = await client.CreateTopicAsync(topicDescription);

                //@@ string subscriptionName = "<subscription_name>";
                var subscriptionDescription = new SubscriptionDescription(topicName, subscriptionName)
                {
                    AutoDeleteOnIdle = TimeSpan.FromDays(7),
                    DefaultMessageTimeToLive = TimeSpan.FromDays(2),
                    EnableBatchedOperations = true,
                    UserMetadata = "some metadata"
                };
                SubscriptionDescription createdSubscription = await client.CreateSubscriptionAsync(subscriptionDescription);
                #endregion
                Assert.AreEqual(topicDescription, createdTopic);
                Assert.AreEqual(subscriptionDescription, createdSubscription);
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
            var client = new ServiceBusManagementClient(connectionString);
            var td = new TopicDescription(topicName);
            var sd = new SubscriptionDescription(topicName, subscriptionName);
            await client.CreateTopicAsync(td);
            await client.CreateSubscriptionAsync(sd);
            #region Snippet:GetTopic
            TopicDescription topicDescription = await client.GetTopicAsync(topicName);
            #endregion
            #region Snippet:GetSubscription
            SubscriptionDescription subscriptionDescription = await client.GetSubscriptionAsync(topicName, subscriptionName);
            #endregion
            #region Snippet:UpdateTopic
            topicDescription.UserMetadata = "some metadata";
            TopicDescription updatedTopic = await client.UpdateTopicAsync(topicDescription);
            #endregion
            Assert.AreEqual("some metadata", updatedTopic.UserMetadata);

            #region Snippet:UpdateSubscription
            subscriptionDescription.UserMetadata = "some metadata";
            SubscriptionDescription updatedSubscription = await client.UpdateSubscriptionAsync(subscriptionDescription);
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
                  Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.MessagingEntityNotFound));

            #region Snippet:DeleteTopic
            await client.DeleteTopicAsync(topicName);
            #endregion
            Assert.That(
                  async () =>
                  await client.GetTopicAsync(topicName),
                  Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.MessagingEntityNotFound));
        }
    }
}
