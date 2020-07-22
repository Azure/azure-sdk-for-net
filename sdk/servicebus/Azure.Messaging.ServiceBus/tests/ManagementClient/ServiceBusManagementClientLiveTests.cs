// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Management;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.ManagementClient
{
    public class ServiceBusManagementClientLiveTests : ServiceBusLiveTestBase
    {
        [Test]
        public async Task BasicQueueCrudOperations()
        {
            var queueName = nameof(BasicQueueCrudOperations).ToLower() + Guid.NewGuid().ToString("D").Substring(0, 8);
            var client = new ServiceBusManagementClient(TestEnvironment.ServiceBusConnectionString);

            var queueDescription = new QueueDescription(queueName)
            {
                AutoDeleteOnIdle = TimeSpan.FromHours(1),
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
                UserMetadata = nameof(BasicQueueCrudOperations)
            };

            queueDescription.AuthorizationRules.Add(new SharedAccessAuthorizationRule(
                "allClaims",
                new[] { AccessRights.Manage, AccessRights.Send, AccessRights.Listen }));

            QueueDescription createdQueue = await client.CreateQueueAsync(queueDescription);
            Assert.AreEqual(queueDescription, createdQueue);

            QueueDescription getQueue = await client.GetQueueAsync(queueDescription.Name);
            Assert.AreEqual(queueDescription, getQueue);

            getQueue.EnableBatchedOperations = false;
            getQueue.MaxDeliveryCount = 9;
            getQueue.AuthorizationRules.Clear();
            getQueue.AuthorizationRules.Add(new SharedAccessAuthorizationRule(
                "noManage",
                new[] { AccessRights.Send, AccessRights.Listen }));

            QueueDescription updatedQueue = await client.UpdateQueueAsync(getQueue);
            Assert.AreEqual(getQueue, updatedQueue);

            bool isExists = await client.QueueExistsAsync(queueName);
            Assert.True(isExists);

            List<QueueDescription> queueList = new List<QueueDescription>();
            await foreach (QueueDescription queue in client.GetQueuesAsync())
            {
                queueList.Add(queue);
            }

            queueList = queueList.Where(e => e.Name.StartsWith(nameof(BasicQueueCrudOperations).ToLower())).ToList();
            Assert.True(queueList.Count == 1, $"Expected 1 queue but {queueList.Count} queues returned");
            Assert.AreEqual(queueList.First().Name, queueName);

            await client.DeleteQueueAsync(updatedQueue.Name);

            Assert.That(
                   async () =>
                   await client.GetQueueAsync(queueDescription.Name),
                   Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.MessagingEntityNotFound));

            isExists = await client.QueueExistsAsync(queueName);
            Assert.False(isExists);
        }

        [Test]
        public async Task BasicTopicCrudOperations()
        {
            var topicName = nameof(BasicTopicCrudOperations).ToLower() + Guid.NewGuid().ToString("D").Substring(0, 8);
            var client = new ServiceBusManagementClient(TestEnvironment.ServiceBusConnectionString);

            var topicDescription = new TopicDescription(topicName)
            {
                AutoDeleteOnIdle = TimeSpan.FromHours(1),
                DefaultMessageTimeToLive = TimeSpan.FromDays(2),
                DuplicateDetectionHistoryTimeWindow = TimeSpan.FromMinutes(1),
                EnableBatchedOperations = true,
                EnablePartitioning = false,
                MaxSizeInMegabytes = 2048,
                RequiresDuplicateDetection = true,
                UserMetadata = nameof(BasicTopicCrudOperations)
            };

            topicDescription.AuthorizationRules.Add(new SharedAccessAuthorizationRule(
               "allClaims",
               new[] { AccessRights.Manage, AccessRights.Send, AccessRights.Listen }));

            TopicDescription createdTopic = await client.CreateTopicAsync(topicDescription);
            Assert.AreEqual(topicDescription, createdTopic);

            TopicDescription getTopic = await client.GetTopicAsync(topicDescription.Name);
            Assert.AreEqual(topicDescription, getTopic);

            getTopic.EnableBatchedOperations = false;
            getTopic.DefaultMessageTimeToLive = TimeSpan.FromDays(3);

            TopicDescription updatedTopic = await client.UpdateTopicAsync(getTopic);
            Assert.AreEqual(getTopic, updatedTopic);

            bool exists = await client.TopicExistsAsync(topicName);
            Assert.True(exists);

            List<TopicDescription> topicList = new List<TopicDescription>();
            await foreach (TopicDescription topic in client.GetTopicsAsync())
            {
                topicList.Add(topic);
            }
            topicList = topicList.Where(e => e.Name.StartsWith(nameof(BasicTopicCrudOperations).ToLower())).ToList();
            Assert.True(topicList.Count == 1, $"Expected 1 topic but {topicList.Count} topics returned");
            Assert.AreEqual(topicList.First().Name, topicName);

            await client.DeleteTopicAsync(updatedTopic.Name);

            Assert.That(
                  async () =>
                  await client.GetTopicAsync(topicDescription.Name),
                  Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.MessagingEntityNotFound));

            exists = await client.TopicExistsAsync(topicName);
            Assert.False(exists);
        }

        [Test]
        public async Task BasicSubscriptionCrudOperations()
        {
            var topicName = nameof(BasicSubscriptionCrudOperations).ToLower() + Guid.NewGuid().ToString("D").Substring(0, 8);
            var subscriptionName = Guid.NewGuid().ToString("D").Substring(0, 8);

            var client = new ServiceBusManagementClient(TestEnvironment.ServiceBusConnectionString);

            await client.CreateTopicAsync(topicName);

            var subscriptionDescription = new SubscriptionDescription(topicName, subscriptionName)
            {
                AutoDeleteOnIdle = TimeSpan.FromHours(1),
                DefaultMessageTimeToLive = TimeSpan.FromDays(2),
                DeadLetteringOnMessageExpiration = true,
                EnableBatchedOperations = false,
                ForwardDeadLetteredMessagesTo = null,
                ForwardTo = null,
                LockDuration = TimeSpan.FromSeconds(45),
                MaxDeliveryCount = 8,
                RequiresSession = true,
                UserMetadata = nameof(BasicSubscriptionCrudOperations)
            };

            SubscriptionDescription createdSubscription = await client.CreateSubscriptionAsync(subscriptionDescription);
            Assert.AreEqual(subscriptionDescription, createdSubscription);

            SubscriptionDescription getSubscription = await client.GetSubscriptionAsync(subscriptionDescription.TopicName, subscriptionDescription.SubscriptionName);
            Assert.AreEqual(subscriptionDescription, getSubscription);

            getSubscription.DefaultMessageTimeToLive = TimeSpan.FromDays(3);
            getSubscription.MaxDeliveryCount = 9;

            SubscriptionDescription updatedSubscription = await client.UpdateSubscriptionAsync(getSubscription);
            Assert.AreEqual(getSubscription, updatedSubscription);

            bool exists = await client.SubscriptionExistsAsync(topicName, subscriptionName);
            Assert.True(exists);

            List<SubscriptionDescription> subscriptionList = new List<SubscriptionDescription>();
            await foreach (SubscriptionDescription subscription in client.GetSubscriptionsAsync(topicName))
            {
                subscriptionList.Add(subscription);
            }
            subscriptionList = subscriptionList.Where(e => e.TopicName.StartsWith(nameof(BasicSubscriptionCrudOperations).ToLower())).ToList();
            Assert.True(subscriptionList.Count == 1, $"Expected 1 subscription but {subscriptionList.Count} subscriptions returned");
            Assert.AreEqual(subscriptionList.First().TopicName, topicName);
            Assert.AreEqual(subscriptionList.First().SubscriptionName, subscriptionName);

            await client.DeleteSubscriptionAsync(subscriptionDescription.TopicName, subscriptionDescription.SubscriptionName);

            Assert.That(
                  async () =>
                  await client.GetSubscriptionAsync(subscriptionDescription.TopicName, subscriptionDescription.SubscriptionName),
                  Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.MessagingEntityNotFound));

            await client.DeleteTopicAsync(subscriptionDescription.TopicName);

            exists = await client.SubscriptionExistsAsync(topicName, subscriptionName);
            Assert.False(exists);
        }

        [Test]
        public async Task BasicRuleCrudOperations()
        {
            var topicName = Guid.NewGuid().ToString("D").Substring(0, 8);
            var subscriptionName = Guid.NewGuid().ToString("D").Substring(0, 8);
            var client = new ServiceBusManagementClient(TestEnvironment.ServiceBusConnectionString);
            await client.CreateTopicAsync(topicName);

            var rule1 = new RuleDescription
            {
                Filter = new TrueRuleFilter(),
                Name = "rule1"
            };
            await client.CreateSubscriptionAsync(
                new SubscriptionDescription(topicName, subscriptionName),
                rule1);
            RuleDescription getRule1 = await client.GetRuleAsync(topicName, subscriptionName, "rule1");
            Assert.AreEqual(rule1, getRule1);

            var sqlRuleFilter = new SqlRuleFilter("stringValue = @stringParam AND intValue = @intParam AND longValue = @longParam AND dateValue = @dateParam AND timeSpanValue = @timeSpanParam");
            sqlRuleFilter.Parameters.Add("@stringParam", "string");
            sqlRuleFilter.Parameters.Add("@intParam", 1);
            sqlRuleFilter.Parameters.Add("@longParam", (long)12);
            sqlRuleFilter.Parameters.Add("@dateParam", DateTime.UtcNow);
            sqlRuleFilter.Parameters.Add("@timeSpanParam", TimeSpan.FromDays(1));
            var rule2 = new RuleDescription
            {
                Name = "rule2",
                Filter = sqlRuleFilter,
                Action = new SqlRuleAction("SET a='b'")
            };
            await client.CreateRuleAsync(topicName, subscriptionName, rule2);
            RuleDescription getRule2 = await client.GetRuleAsync(topicName, subscriptionName, "rule2");
            Assert.AreEqual(rule2, getRule2);

            var correlationRuleFilter = new CorrelationRuleFilter()
            {
                ContentType = "contentType",
                CorrelationId = "correlationId",
                Label = "label",
                MessageId = "messageId",
                ReplyTo = "replyTo",
                ReplyToSessionId = "replyToSessionId",
                SessionId = "sessionId",
                To = "to"
            };
            correlationRuleFilter.Properties.Add("customKey", "customValue");
            var rule3 = new RuleDescription()
            {
                Name = "rule3",
                Filter = correlationRuleFilter,
                Action = null
            };
            await client.CreateRuleAsync(topicName, subscriptionName, rule3);
            RuleDescription getRule3 = await client.GetRuleAsync(topicName, subscriptionName, "rule3");
            Assert.AreEqual(rule3, getRule3);

            List<RuleDescription> ruleList = new List<RuleDescription>();
            await foreach (RuleDescription rule in client.GetRulesAsync(topicName, subscriptionName))
            {
                ruleList.Add(rule);
            }
            RuleDescription[] ruleArr = ruleList.ToArray();
            Assert.True(ruleArr.Length == 3);
            Assert.AreEqual(rule1, ruleArr[0]);
            Assert.AreEqual(rule2, ruleArr[1]);
            Assert.AreEqual(rule3, ruleArr[2]);

            ((CorrelationRuleFilter)getRule3.Filter).CorrelationId = "correlationIdModified";
            RuleDescription updatedRule3 = await client.UpdateRuleAsync(topicName, subscriptionName, getRule3);
            Assert.AreEqual(getRule3, updatedRule3);

            bool exists = await client.RuleExistsAsync(topicName, subscriptionName, rule1.Name);
            Assert.True(exists);

            await client.DeleteRuleAsync(topicName, subscriptionName, "rule1");
            Assert.That(
                  async () =>
                  await client.GetRuleAsync(topicName, subscriptionName, "rule1"),
                  Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.MessagingEntityNotFound));

            exists = await client.RuleExistsAsync(topicName, subscriptionName, rule1.Name);
            Assert.False(exists);

            await client.DeleteTopicAsync(topicName);
        }

        [Test]
        public async Task GetQueueRuntimeInfo()
        {
            var queueName = nameof(GetQueueRuntimeInfo).ToLower() + Guid.NewGuid().ToString("D").Substring(0, 8);
            var mgmtClient = new ServiceBusManagementClient(TestEnvironment.ServiceBusConnectionString);
            await using var sbClient = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

            QueueDescription description = await mgmtClient.CreateQueueAsync(queueName);

            // Changing Last Updated Time
            description.AutoDeleteOnIdle = TimeSpan.FromMinutes(100);
            QueueDescription updatedQueue = await mgmtClient.UpdateQueueAsync(description);

            // Populating 1 active message, 1 dead letter message and 1 scheduled message
            // Changing Last Accessed Time

            ServiceBusSender sender = sbClient.CreateSender(queueName);
            await sender.SendMessageAsync(new ServiceBusMessage() { MessageId = "1" });
            await sender.SendMessageAsync(new ServiceBusMessage() { MessageId = "2" });
            await sender.SendMessageAsync(new ServiceBusMessage() { MessageId = "3", ScheduledEnqueueTime = DateTime.UtcNow.AddDays(1) });

            ServiceBusReceiver receiver = sbClient.CreateReceiver(queueName);
            ServiceBusReceivedMessage msg = await receiver.ReceiveMessageAsync();
            await receiver.DeadLetterMessageAsync(msg.LockToken);

            List<QueueRuntimeInfo> runtimeInfoList = new List<QueueRuntimeInfo>();
            await foreach (QueueRuntimeInfo queueRuntimeInfo in mgmtClient.GetQueuesRuntimeInfoAsync())
            {
                runtimeInfoList.Add(queueRuntimeInfo);
            }
            runtimeInfoList = runtimeInfoList.Where(e => e.Name.StartsWith(nameof(GetQueueRuntimeInfo).ToLower())).ToList();
            Assert.True(runtimeInfoList.Count == 1, $"Expected 1 queue but {runtimeInfoList.Count} queues returned");
            QueueRuntimeInfo runtimeInfo = runtimeInfoList.First();
            Assert.NotNull(runtimeInfo);

            Assert.AreEqual(queueName, runtimeInfo.Name);
            Assert.True(runtimeInfo.CreatedAt < runtimeInfo.UpdatedAt);
            Assert.True(runtimeInfo.UpdatedAt < runtimeInfo.AccessedAt);
            Assert.AreEqual(1, runtimeInfo.CountDetails.ActiveMessageCount);
            Assert.AreEqual(1, runtimeInfo.CountDetails.DeadLetterMessageCount);
            Assert.AreEqual(1, runtimeInfo.CountDetails.ScheduledMessageCount);
            Assert.AreEqual(3, runtimeInfo.MessageCount);
            Assert.True(runtimeInfo.SizeInBytes > 0);

            QueueRuntimeInfo singleRuntimeInfo = await mgmtClient.GetQueueRuntimeInfoAsync(runtimeInfo.Name);

            Assert.AreEqual(runtimeInfo.AccessedAt, singleRuntimeInfo.AccessedAt);
            Assert.AreEqual(runtimeInfo.CreatedAt, singleRuntimeInfo.CreatedAt);
            Assert.AreEqual(runtimeInfo.UpdatedAt, singleRuntimeInfo.UpdatedAt);
            Assert.AreEqual(runtimeInfo.MessageCount, singleRuntimeInfo.MessageCount);
            Assert.AreEqual(runtimeInfo.CountDetails.ActiveMessageCount, singleRuntimeInfo.CountDetails.ActiveMessageCount);
            Assert.AreEqual(runtimeInfo.CountDetails.DeadLetterMessageCount, singleRuntimeInfo.CountDetails.DeadLetterMessageCount);
            Assert.AreEqual(runtimeInfo.CountDetails.ScheduledMessageCount, singleRuntimeInfo.CountDetails.ScheduledMessageCount);
            Assert.AreEqual(runtimeInfo.SizeInBytes, singleRuntimeInfo.SizeInBytes);

            await mgmtClient.DeleteQueueAsync(queueName);
        }

        [Test]
        public async Task GetSubscriptionRuntimeInfoTest()
        {
            var topicName = nameof(GetSubscriptionRuntimeInfoTest).ToLower() + Guid.NewGuid().ToString("D").Substring(0, 8);
            var subscriptionName = Guid.NewGuid().ToString("D").Substring(0, 8);
            var mgmtClient = new ServiceBusManagementClient(TestEnvironment.ServiceBusConnectionString);
            await using var sbClient = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

            TopicDescription topicDescription = await mgmtClient.CreateTopicAsync(topicName);

            // Changing Last Updated Time
            topicDescription.AutoDeleteOnIdle = TimeSpan.FromMinutes(100);
            await mgmtClient.UpdateTopicAsync(topicDescription);

            SubscriptionDescription subscriptionDescription = await mgmtClient.CreateSubscriptionAsync(topicName, subscriptionName);

            // Changing Last Updated Time for subscription
            subscriptionDescription.AutoDeleteOnIdle = TimeSpan.FromMinutes(100);
            await mgmtClient.UpdateSubscriptionAsync(subscriptionDescription);

            // Populating 1 active message, 1 dead letter message and 1 scheduled message
            // Changing Last Accessed Time

            ServiceBusSender sender = sbClient.CreateSender(topicName);
            await sender.SendMessageAsync(new ServiceBusMessage() { MessageId = "1" });
            await sender.SendMessageAsync(new ServiceBusMessage() { MessageId = "2" });
            await sender.SendMessageAsync(new ServiceBusMessage() { MessageId = "3", ScheduledEnqueueTime = DateTime.UtcNow.AddDays(1) });

            ServiceBusReceiver receiver = sbClient.CreateReceiver(topicName, subscriptionName);
            ServiceBusReceivedMessage msg = await receiver.ReceiveMessageAsync();
            await receiver.DeadLetterMessageAsync(msg.LockToken);

            List<SubscriptionRuntimeInfo> runtimeInfoList = new List<SubscriptionRuntimeInfo>();
            await foreach (SubscriptionRuntimeInfo subscriptionRuntimeInfo in mgmtClient.GetSubscriptionsRuntimeInfoAsync(topicName))
            {
                runtimeInfoList.Add(subscriptionRuntimeInfo);
            }
            runtimeInfoList = runtimeInfoList.Where(e => e.TopicName.StartsWith(nameof(GetSubscriptionRuntimeInfoTest).ToLower())).ToList();
            Assert.True(runtimeInfoList.Count == 1, $"Expected 1 subscription but {runtimeInfoList.Count} subscriptions returned");
            SubscriptionRuntimeInfo runtimeInfo = runtimeInfoList.First();
            Assert.NotNull(runtimeInfo);

            Assert.AreEqual(topicName, runtimeInfo.TopicName);
            Assert.AreEqual(subscriptionName, runtimeInfo.SubscriptionName);

            Assert.True(runtimeInfo.CreatedAt < runtimeInfo.UpdatedAt);
            Assert.True(runtimeInfo.UpdatedAt < runtimeInfo.AccessedAt);

            Assert.AreEqual(1, runtimeInfo.CountDetails.ActiveMessageCount);
            Assert.AreEqual(1, runtimeInfo.CountDetails.DeadLetterMessageCount);
            Assert.AreEqual(0, runtimeInfo.CountDetails.ScheduledMessageCount);
            Assert.AreEqual(2, runtimeInfo.MessageCount);

            SubscriptionRuntimeInfo singleRuntimeInfo = await mgmtClient.GetSubscriptionRuntimeInfoAsync(topicName, subscriptionName);

            Assert.AreEqual(runtimeInfo.CreatedAt, singleRuntimeInfo.CreatedAt);
            Assert.AreEqual(runtimeInfo.AccessedAt, singleRuntimeInfo.AccessedAt);
            Assert.AreEqual(runtimeInfo.UpdatedAt, singleRuntimeInfo.UpdatedAt);
            Assert.AreEqual(runtimeInfo.SubscriptionName, singleRuntimeInfo.SubscriptionName);
            Assert.AreEqual(runtimeInfo.MessageCount, singleRuntimeInfo.MessageCount);
            Assert.AreEqual(runtimeInfo.CountDetails.ActiveMessageCount, singleRuntimeInfo.CountDetails.ActiveMessageCount);
            Assert.AreEqual(runtimeInfo.CountDetails.DeadLetterMessageCount, singleRuntimeInfo.CountDetails.DeadLetterMessageCount);
            Assert.AreEqual(runtimeInfo.CountDetails.ScheduledMessageCount, singleRuntimeInfo.CountDetails.ScheduledMessageCount);
            Assert.AreEqual(runtimeInfo.TopicName, singleRuntimeInfo.TopicName);

            await mgmtClient.DeleteTopicAsync(topicName);
        }

        [Test]
        public async Task GetTopicRuntimeInfo()
        {
            var topicName = nameof(GetTopicRuntimeInfo).ToLower() + Guid.NewGuid().ToString("D").Substring(0, 8);
            var subscriptionName = Guid.NewGuid().ToString("D").Substring(0, 8);
            var client = new ServiceBusManagementClient(TestEnvironment.ServiceBusConnectionString);

            TopicDescription topicDescription = await client.CreateTopicAsync(topicName);

            // Changing Last Updated Time
            topicDescription.AutoDeleteOnIdle = TimeSpan.FromMinutes(100);
            await client.UpdateTopicAsync(topicDescription);

            await client.CreateSubscriptionAsync(topicName, subscriptionName);

            List<TopicRuntimeInfo> runtimeInfoList = new List<TopicRuntimeInfo>();
            await foreach (TopicRuntimeInfo topicRuntimeInfo in client.GetTopicsRuntimeInfoAsync())
            {
                runtimeInfoList.Add(topicRuntimeInfo);
            }
            runtimeInfoList = runtimeInfoList.Where(e => e.Name.StartsWith(nameof(GetTopicRuntimeInfo).ToLower())).ToList();
            Assert.True(runtimeInfoList.Count == 1, $"Expected 1 topic but {runtimeInfoList.Count} topics returned");
            TopicRuntimeInfo runtimeInfo = runtimeInfoList.First();
            Assert.NotNull(runtimeInfo);

            Assert.AreEqual(topicName, runtimeInfo.Name);
            Assert.True(runtimeInfo.CreatedAt < runtimeInfo.UpdatedAt);
            Assert.True(runtimeInfo.UpdatedAt < runtimeInfo.AccessedAt);
            Assert.AreEqual(1, runtimeInfo.SubscriptionCount);

            TopicRuntimeInfo singleTopicRI = await client.GetTopicRuntimeInfoAsync(runtimeInfo.Name);

            Assert.AreEqual(runtimeInfo.AccessedAt, singleTopicRI.AccessedAt);
            Assert.AreEqual(runtimeInfo.CreatedAt, singleTopicRI.CreatedAt);
            Assert.AreEqual(runtimeInfo.UpdatedAt, singleTopicRI.UpdatedAt);
            Assert.AreEqual(runtimeInfo.SizeInBytes, singleTopicRI.SizeInBytes);
            Assert.AreEqual(runtimeInfo.SubscriptionCount, singleTopicRI.SubscriptionCount);

            await client.DeleteTopicAsync(topicName);
        }

        [Test]
        public async Task ThrowsIfEntityDoesnotExist()
        {
            var client = new ServiceBusManagementClient(TestEnvironment.ServiceBusConnectionString);

            Assert.That(
                  async () =>
                  await client.GetQueueAsync("NonExistingPath"),
                  Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.MessagingEntityNotFound));

            Assert.That(
                  async () =>
                  await client.GetSubscriptionAsync("NonExistingTopic", "NonExistingPath"),
                  Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.MessagingEntityNotFound));

            Assert.That(
                  async () =>
                  await client.UpdateQueueAsync(new QueueDescription("NonExistingPath")),
                  Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.MessagingEntityNotFound));

            Assert.That(
                  async () =>
                  await client.UpdateTopicAsync(new TopicDescription("NonExistingPath")),
                  Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.MessagingEntityNotFound));

            Assert.That(
                  async () =>
                  await client.UpdateSubscriptionAsync(new SubscriptionDescription("NonExistingTopic", "NonExistingPath")),
                  Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.MessagingEntityNotFound));

            Assert.That(
                  async () =>
                  await client.DeleteQueueAsync("NonExistingPath"),
                  Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.MessagingEntityNotFound));

            Assert.That(
                  async () =>
                  await client.DeleteTopicAsync("NonExistingPath"),
                  Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.MessagingEntityNotFound));

            Assert.That(
                  async () =>
                  await client.DeleteSubscriptionAsync("NonExistingTopic", "NonExistingPath"),
                  Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.MessagingEntityNotFound));


            var queueName = Guid.NewGuid().ToString("D").Substring(0, 8);
            var topicName = Guid.NewGuid().ToString("D").Substring(0, 8);

            await client.CreateQueueAsync(queueName);
            await client.CreateTopicAsync(topicName);

            Assert.That(
                  async () =>
                  await client.GetQueueAsync(topicName),
                  Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.MessagingEntityNotFound));

            Assert.That(
                 async () =>
                 await client.GetTopicAsync(queueName),
                 Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.MessagingEntityNotFound));

            await client.DeleteQueueAsync(queueName);
            await client.DeleteTopicAsync(topicName);
        }

        [Test]
        public async Task ThrowsIfEntityAlreadyExists()
        {
            var client = new ServiceBusManagementClient(TestEnvironment.ServiceBusConnectionString);
            var queueName = Guid.NewGuid().ToString("D").Substring(0, 8);
            var topicName = Guid.NewGuid().ToString("D").Substring(0, 8);
            var subscriptionName = Guid.NewGuid().ToString("D").Substring(0, 8);

            await client.CreateQueueAsync(queueName);
            await client.CreateTopicAsync(topicName);
            await client.CreateSubscriptionAsync(topicName, subscriptionName);

            Assert.That(
                 async () =>
                 await client.CreateQueueAsync(queueName),
                 Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.MessagingEntityAlreadyExists));

            Assert.That(
                 async () =>
                 await client.CreateTopicAsync(topicName),
                 Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.MessagingEntityAlreadyExists));

            Assert.That(
                 async () =>
                 await client.CreateSubscriptionAsync(topicName, subscriptionName),
                 Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusException.FailureReason.MessagingEntityAlreadyExists));

            await client.DeleteQueueAsync(queueName);
            await client.DeleteTopicAsync(topicName);
        }

        [Test]
        public async Task ForwardingEntity()
        {
            // queueName--Fwd to--> destinationName--fwd dlq to-- > dqlDestinationName
            var queueName = Guid.NewGuid().ToString("D").Substring(0, 8);
            var destinationName = Guid.NewGuid().ToString("D").Substring(0, 8);
            var dlqDestinationName = Guid.NewGuid().ToString("D").Substring(0, 8);
            var mgmtClient = new ServiceBusManagementClient(TestEnvironment.ServiceBusConnectionString);

            await mgmtClient.CreateQueueAsync(dlqDestinationName);
            await mgmtClient.CreateQueueAsync(
                new QueueDescription(destinationName)
                {
                    ForwardDeadLetteredMessagesTo = dlqDestinationName
                });

            await mgmtClient.CreateQueueAsync(
                new QueueDescription(queueName)
                {
                    ForwardTo = destinationName
                });

            await using var sbClient = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
            ServiceBusSender sender = sbClient.CreateSender(queueName);
            await sender.SendMessageAsync(new ServiceBusMessage() { MessageId = "mid" });

            ServiceBusReceiver receiver = sbClient.CreateReceiver(destinationName);
            ServiceBusReceivedMessage msg = await receiver.ReceiveMessageAsync();
            Assert.NotNull(msg);
            Assert.AreEqual("mid", msg.MessageId);
            await receiver.DeadLetterMessageAsync(msg.LockToken);

            receiver = sbClient.CreateReceiver(dlqDestinationName);
            msg = await receiver.ReceiveMessageAsync();
            Assert.NotNull(msg);
            Assert.AreEqual("mid", msg.MessageId);
            await receiver.CompleteMessageAsync(msg.LockToken);

            await mgmtClient.DeleteQueueAsync(queueName);
            await mgmtClient.DeleteQueueAsync(destinationName);
            await mgmtClient.DeleteQueueAsync(dlqDestinationName);
        }

        [Test]
        public async Task SqlFilterParams()
        {
            var client = new ServiceBusManagementClient(TestEnvironment.ServiceBusConnectionString);
            var topicName = Guid.NewGuid().ToString("D").Substring(0, 8);
            var subscriptionName = Guid.NewGuid().ToString("D").Substring(0, 8);

            await client.CreateTopicAsync(topicName);
            await client.CreateSubscriptionAsync(topicName, subscriptionName);

            SqlRuleFilter sqlFilter = new SqlRuleFilter(
                "PROPERTY(@propertyName) = @stringPropertyValue " +
                "AND PROPERTY(intProperty) = @intPropertyValue " +
                "AND PROPERTY(longProperty) = @longPropertyValue " +
                "AND PROPERTY(boolProperty) = @boolPropertyValue " +
                "AND PROPERTY(doubleProperty) = @doublePropertyValue ")
            {
                Parameters =
                       {
                            { "@propertyName", "MyProperty" },
                            { "@stringPropertyValue", "string" },
                            { "@intPropertyValue", 3 },
                            { "@longPropertyValue", 3L },
                            { "@boolPropertyValue", true },
                            { "@doublePropertyValue", 3.0 },
                       }
            };

            RuleDescription rule = await client.CreateRuleAsync(topicName, subscriptionName, new RuleDescription("rule1", sqlFilter));
            Assert.AreEqual(sqlFilter, rule.Filter);

            await client.DeleteTopicAsync(topicName);
        }

        [Test]
        public async Task CorrelationFilterProperties()
        {
            var topicName = Guid.NewGuid().ToString("D").Substring(0, 8);
            var subscriptionName = Guid.NewGuid().ToString("D").Substring(0, 8);
            var client = new ServiceBusManagementClient(TestEnvironment.ServiceBusConnectionString);

            await client.CreateTopicAsync(topicName);
            await client.CreateSubscriptionAsync(topicName, subscriptionName);

            var filter = new CorrelationRuleFilter();
            filter.Properties.Add("stringKey", "stringVal");
            filter.Properties.Add("intKey", 5);
            filter.Properties.Add("dateTimeKey", DateTime.UtcNow);

            RuleDescription rule = await client.CreateRuleAsync(topicName, subscriptionName, new RuleDescription("rule1", filter));
            Assert.True(filter.Properties.Count == 3);
            Assert.AreEqual(filter, rule.Filter);

            await client.DeleteTopicAsync(topicName);
        }

        [Test]
        public async Task GetNamespaceProperties()
        {
            var client = new ServiceBusManagementClient(TestEnvironment.ServiceBusConnectionString);

            NamespaceProperties nsInfo = await client.GetNamespacePropertiesAsync();
            Assert.NotNull(nsInfo);
            // Assert.AreEqual(MessagingSku.Standard, nsInfo.MessagingSku);    // Most CI systems generally use standard, hence this check just to ensure the API is working.
            Assert.AreEqual(NamespaceType.Messaging, nsInfo.NamespaceType); // Common namespace type used for testing is messaging.
        }

        [Test]
        public async Task AuthenticateWithAAD()
        {
            var queueName = Guid.NewGuid().ToString("D").Substring(0, 8);
            var topicName = Guid.NewGuid().ToString("D").Substring(0, 8);
            var client = new ServiceBusManagementClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);

            QueueDescription queueDescription = new QueueDescription(queueName);
            QueueDescription createdQueue = await client.CreateQueueAsync(queueDescription);

            Assert.AreEqual(queueDescription, createdQueue);

            TopicDescription topicDescription = new TopicDescription(topicName);
            TopicDescription createdTopic = await client.CreateTopicAsync(topicDescription);

            Assert.AreEqual(topicDescription, createdTopic);

            await client.DeleteQueueAsync(queueName);
            await client.DeleteTopicAsync(topicName);
        }
    }
}
