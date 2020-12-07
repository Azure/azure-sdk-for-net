// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Messaging.ServiceBus.Administration;
using Azure.Messaging.ServiceBus.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Management
{
    [AsyncOnly]
    [NonParallelizable]
    public class ServiceBusManagementClientLiveTests : RecordedTestBase<ServiceBusTestEnvironment>
    {
        public ServiceBusManagementClientLiveTests(bool isAsync) :
            base(isAsync: true)
        {
            Sanitizer = new ServiceBusRecordedTestSanitizer();
        }

        private string GetConnectionString() =>
            Mode == RecordedTestMode.Live ?
                TestEnvironment.ServiceBusConnectionString :
                TestEnvironment.OverrideServiceBusConnectionString;

        private ServiceBusAdministrationClient GetClient() =>
            InstrumentClient(
                new ServiceBusAdministrationClient(
                    GetConnectionString(),
                    InstrumentClientOptions(new ServiceBusAdministrationClientOptions())));

        private ServiceBusAdministrationClient GetAADClient() =>
            InstrumentClient(
                new ServiceBusAdministrationClient(
                    TestEnvironment.FullyQualifiedNamespace,
                    GetTokenCredential(),
                    InstrumentClientOptions(new ServiceBusAdministrationClientOptions())));

        private ServiceBusAdministrationClient GetSharedKeyTokenClient()
        {
            var properties = ServiceBusConnectionStringProperties.Parse(GetConnectionString());
            var credential = new ServiceBusSharedAccessKeyCredential(properties.SharedAccessKeyName, properties.SharedAccessKey);

            return InstrumentClient(
                new ServiceBusAdministrationClient(
                    TestEnvironment.FullyQualifiedNamespace,
                    credential,
                    InstrumentClientOptions(new ServiceBusAdministrationClientOptions())));
        }

        [Test]
        public async Task BasicQueueCrudOperations()
        {
            var queueName = nameof(BasicQueueCrudOperations).ToLower() + Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var client = GetClient();

            var queueOptions = new CreateQueueOptions(queueName)
            {
                AutoDeleteOnIdle = TimeSpan.FromHours(1),
                DefaultMessageTimeToLive = TimeSpan.FromDays(2),
                DuplicateDetectionHistoryTimeWindow = TimeSpan.FromMinutes(1),
                EnableBatchedOperations = false,
                DeadLetteringOnMessageExpiration = true,
                EnablePartitioning = false,
                ForwardDeadLetteredMessagesTo = null,
                ForwardTo = null,
                LockDuration = TimeSpan.FromSeconds(45),
                MaxDeliveryCount = 8,
                MaxSizeInMegabytes = 1024,
                RequiresDuplicateDetection = true,
                RequiresSession = false,
                UserMetadata = nameof(BasicQueueCrudOperations),
                Status = EntityStatus.Disabled
            };

            queueOptions.AuthorizationRules.Add(new SharedAccessAuthorizationRule(
                "allClaims",
                new[] { AccessRights.Manage, AccessRights.Send, AccessRights.Listen }));

            Response<QueueProperties> createdQueueResponse = await client.CreateQueueAsync(queueOptions);
            Response rawResponse = createdQueueResponse.GetRawResponse();
            Assert.NotNull(rawResponse.ClientRequestId);
            Assert.IsTrue(rawResponse.ContentStream.CanRead);
            Assert.AreEqual(0, rawResponse.ContentStream.Position);

            QueueProperties createdQueue = createdQueueResponse.Value;

            if (Mode == RecordedTestMode.Playback)
            {
                Assert.AreEqual(queueOptions, new CreateQueueOptions(createdQueue) { AuthorizationRules = queueOptions.AuthorizationRules.Clone() });
                Assert.AreEqual(createdQueue, new QueueProperties(queueOptions) { AuthorizationRules = createdQueue.AuthorizationRules });
            }
            else
            {
                Assert.AreEqual(queueOptions, new CreateQueueOptions(createdQueue));
                Assert.AreEqual(createdQueue, new QueueProperties(queueOptions));
            }
            Response<QueueProperties> getQueueResponse = await client.GetQueueAsync(queueOptions.Name);
            rawResponse = createdQueueResponse.GetRawResponse();
            Assert.NotNull(rawResponse.ClientRequestId);
            Assert.IsTrue(rawResponse.ContentStream.CanRead);
            Assert.AreEqual(0, rawResponse.ContentStream.Position);

            QueueProperties getQueue = getQueueResponse.Value;
            Assert.AreEqual(createdQueue, getQueue);

            getQueue.EnableBatchedOperations = false;
            getQueue.MaxDeliveryCount = 9;
            getQueue.AuthorizationRules.Clear();
            getQueue.AuthorizationRules.Add(new SharedAccessAuthorizationRule(
                "noManage",
                new[] { AccessRights.Send, AccessRights.Listen }));
            getQueue.EnableBatchedOperations = true;
            getQueue.Status = EntityStatus.Disabled;
            getQueue.AutoDeleteOnIdle = TimeSpan.FromMinutes(6);
            getQueue.MaxSizeInMegabytes = 1024;
            QueueProperties updatedQueue = await client.UpdateQueueAsync(getQueue);

            if (Mode == RecordedTestMode.Playback)
            {
                // Auth rules use a randomly generated key, but we don't want to store
                // these in our test recordings, so we skip the auth rule comparison
                // when in playback mode.
                var rules = updatedQueue.AuthorizationRules;
                updatedQueue.AuthorizationRules = getQueue.AuthorizationRules.Clone();
                Assert.AreEqual(getQueue, updatedQueue);
                updatedQueue.AuthorizationRules = rules;
            }
            else
            {
                Assert.AreEqual(getQueue, updatedQueue);
            }
            Response<bool> isExistsResponse = await client.QueueExistsAsync(queueName);
            rawResponse = createdQueueResponse.GetRawResponse();

            Assert.NotNull(rawResponse.ClientRequestId);
            Assert.IsTrue(rawResponse.ContentStream.CanRead);
            Assert.AreEqual(0, rawResponse.ContentStream.Position);
            Assert.True(isExistsResponse.Value);

            List<QueueProperties> queueList = new List<QueueProperties>();
            await foreach (QueueProperties queue in client.GetQueuesAsync())
            {
                queueList.Add(queue);
            }

            queueList = queueList.Where(e => e.Name.StartsWith(nameof(BasicQueueCrudOperations).ToLower())).ToList();
            Assert.True(queueList.Count == 1, $"Expected 1 queue but {queueList.Count} queues returned");
            Assert.AreEqual(queueList.First().Name, queueName);

            await client.DeleteQueueAsync(updatedQueue.Name);

            Assert.That(
                   async () =>
                   await client.GetQueueAsync(queueOptions.Name),
                   Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.MessagingEntityNotFound));

            isExistsResponse = await client.QueueExistsAsync(queueName);
            Assert.False(isExistsResponse.Value);
        }

        [Test]
        public async Task BasicTopicCrudOperations()
        {
            var topicName = nameof(BasicTopicCrudOperations).ToLower() + Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var client = GetClient();

            var options = new CreateTopicOptions(topicName)
            {
                AutoDeleteOnIdle = TimeSpan.FromHours(1),
                DefaultMessageTimeToLive = TimeSpan.FromDays(2),
                DuplicateDetectionHistoryTimeWindow = TimeSpan.FromMinutes(1),
                EnableBatchedOperations = true,
                EnablePartitioning = false,
                MaxSizeInMegabytes = 1024,
                RequiresDuplicateDetection = true,
                UserMetadata = nameof(BasicTopicCrudOperations)
            };

            options.AuthorizationRules.Add(new SharedAccessAuthorizationRule(
               "allClaims",
               new[] { AccessRights.Manage, AccessRights.Send, AccessRights.Listen }));

            Response<TopicProperties> createdTopicResponse = await client.CreateTopicAsync(options);
            Response rawResponse = createdTopicResponse.GetRawResponse();
            Assert.NotNull(rawResponse.ClientRequestId);
            Assert.IsTrue(rawResponse.ContentStream.CanRead);
            Assert.AreEqual(0, rawResponse.ContentStream.Position);

            TopicProperties createdTopic = createdTopicResponse.Value;

            if (Mode == RecordedTestMode.Playback)
            {
                // Auth rules use a randomly generated key, but we don't want to store
                // these in our test recordings, so we skip the auth rule comparison
                // when in playback mode.
                Assert.AreEqual(options, new CreateTopicOptions(createdTopic) { AuthorizationRules = options.AuthorizationRules.Clone() });
                Assert.AreEqual(createdTopic, new TopicProperties(options) { AuthorizationRules = createdTopic.AuthorizationRules.Clone() });
            }
            else
            {
                Assert.AreEqual(options, new CreateTopicOptions(createdTopic));
                Assert.AreEqual(createdTopic, new TopicProperties(options));
            }

            Response<TopicProperties> getTopicResponse = await client.GetTopicAsync(options.Name);

            rawResponse = getTopicResponse.GetRawResponse();
            Assert.NotNull(rawResponse.ClientRequestId);
            Assert.IsTrue(rawResponse.ContentStream.CanRead);
            Assert.AreEqual(0, rawResponse.ContentStream.Position);

            TopicProperties getTopic = getTopicResponse.Value;

            Assert.AreEqual(createdTopic, getTopic);

            getTopic.EnableBatchedOperations = false;
            getTopic.DefaultMessageTimeToLive = TimeSpan.FromDays(3);
            getTopic.DuplicateDetectionHistoryTimeWindow = TimeSpan.FromMinutes(2);
            getTopic.EnableBatchedOperations = false;
            getTopic.MaxSizeInMegabytes = 1024;

            Response<TopicProperties> updatedTopicResponse = await client.UpdateTopicAsync(getTopic);
            rawResponse = updatedTopicResponse.GetRawResponse();
            Assert.NotNull(rawResponse.ClientRequestId);
            Assert.IsTrue(rawResponse.ContentStream.CanRead);
            Assert.AreEqual(0, rawResponse.ContentStream.Position);

            TopicProperties updatedTopic = updatedTopicResponse.Value;
            Assert.AreEqual(getTopic, updatedTopic);

            bool exists = await client.TopicExistsAsync(topicName);
            Assert.True(exists);

            List<TopicProperties> topicList = new List<TopicProperties>();
            await foreach (TopicProperties topic in client.GetTopicsAsync())
            {
                topicList.Add(topic);
            }
            topicList = topicList.Where(e => e.Name.StartsWith(nameof(BasicTopicCrudOperations).ToLower())).ToList();
            Assert.True(topicList.Count == 1, $"Expected 1 topic but {topicList.Count} topics returned");
            Assert.AreEqual(topicList.First().Name, topicName);

            Response response = await client.DeleteTopicAsync(updatedTopic.Name);
            Assert.NotNull(response.ClientRequestId);
            Assert.IsTrue(response.ContentStream.CanRead);
            Assert.AreEqual(0, response.ContentStream.Position);

            Assert.That(
                  async () =>
                  await client.GetTopicAsync(options.Name),
                  Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.MessagingEntityNotFound));

            exists = await client.TopicExistsAsync(topicName);
            Assert.False(exists);
        }

        [Test]
        public async Task BasicSubscriptionCrudOperations()
        {
            var topicName = nameof(BasicSubscriptionCrudOperations).ToLower() + Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var subscriptionName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);

            var client = GetClient();

            await client.CreateTopicAsync(topicName);

            var options = new CreateSubscriptionOptions(topicName, subscriptionName)
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

            Response<SubscriptionProperties> createdSubscriptionResponse = await client.CreateSubscriptionAsync(options);
            Response rawResponse = createdSubscriptionResponse.GetRawResponse();
            Assert.NotNull(rawResponse.ClientRequestId);
            Assert.IsTrue(rawResponse.ContentStream.CanRead);
            Assert.AreEqual(0, rawResponse.ContentStream.Position);

            SubscriptionProperties createdSubscription = createdSubscriptionResponse.Value;

            Assert.AreEqual(options, new CreateSubscriptionOptions(createdSubscription));

            SubscriptionProperties getSubscription = await client.GetSubscriptionAsync(options.TopicName, options.SubscriptionName);
            Assert.AreEqual(options, new CreateSubscriptionOptions(getSubscription));

            getSubscription.DefaultMessageTimeToLive = TimeSpan.FromDays(3);
            getSubscription.MaxDeliveryCount = 9;

            SubscriptionProperties updatedSubscription = await client.UpdateSubscriptionAsync(getSubscription);
            Assert.AreEqual(getSubscription, updatedSubscription);

            bool exists = await client.SubscriptionExistsAsync(topicName, subscriptionName);
            Assert.True(exists);

            List<SubscriptionProperties> subscriptionList = new List<SubscriptionProperties>();
            await foreach (Page<SubscriptionProperties> subscriptionPage in client.GetSubscriptionsAsync(topicName).AsPages())
            {
                Assert.NotNull(subscriptionPage.GetRawResponse().ClientRequestId);
                Assert.IsTrue(subscriptionPage.GetRawResponse().ContentStream.CanRead);
                Assert.AreEqual(0, subscriptionPage.GetRawResponse().ContentStream.Position);
                subscriptionList.AddRange(subscriptionPage.Values);
            }
            subscriptionList = subscriptionList.Where(e => e.TopicName.StartsWith(nameof(BasicSubscriptionCrudOperations).ToLower())).ToList();
            Assert.True(subscriptionList.Count == 1, $"Expected 1 subscription but {subscriptionList.Count} subscriptions returned");
            Assert.AreEqual(subscriptionList.First().TopicName, topicName);
            Assert.AreEqual(subscriptionList.First().SubscriptionName, subscriptionName);

            await client.DeleteSubscriptionAsync(options.TopicName, options.SubscriptionName);

            Assert.That(
                  async () =>
                  await client.GetSubscriptionAsync(options.TopicName, options.SubscriptionName),
                  Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.MessagingEntityNotFound));

            await client.DeleteTopicAsync(options.TopicName);

            exists = await client.SubscriptionExistsAsync(topicName, subscriptionName);
            Assert.False(exists);
        }

        [Test]
        public async Task BasicRuleCrudOperations()
        {
            var topicName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var subscriptionName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var client = GetClient();
            await client.CreateTopicAsync(topicName);

            var rule1 = new CreateRuleOptions
            {
                Filter = new TrueRuleFilter(),
                Name = "rule1"
            };
            await client.CreateSubscriptionAsync(
                new CreateSubscriptionOptions(topicName, subscriptionName),
                rule1);
            RuleProperties getRule1 = await client.GetRuleAsync(topicName, subscriptionName, "rule1");
            Assert.AreEqual(rule1, new CreateRuleOptions(getRule1));

            var sqlRuleFilter = new SqlRuleFilter("stringValue = @stringParam AND intValue = @intParam AND longValue = @longParam AND dateValue = @dateParam AND timeSpanValue = @timeSpanParam");
            sqlRuleFilter.Parameters.Add("@stringParam", "string");
            sqlRuleFilter.Parameters.Add("@intParam", 1);
            sqlRuleFilter.Parameters.Add("@longParam", (long)12);
            sqlRuleFilter.Parameters.Add("@dateParam", Recording.Now.UtcDateTime);
            sqlRuleFilter.Parameters.Add("@timeSpanParam", TimeSpan.FromDays(1));
            var rule2 = new CreateRuleOptions
            {
                Name = "rule2",
                Filter = sqlRuleFilter,
                Action = new SqlRuleAction("SET a='b'")
            };
            await client.CreateRuleAsync(topicName, subscriptionName, rule2);
            RuleProperties getRule2 = await client.GetRuleAsync(topicName, subscriptionName, "rule2");
            Assert.AreEqual(rule2, new CreateRuleOptions(getRule2));

            var correlationRuleFilter = new CorrelationRuleFilter()
            {
                ContentType = "contentType",
                CorrelationId = "correlationId",
                Subject = "label",
                MessageId = "messageId",
                ReplyTo = "replyTo",
                ReplyToSessionId = "replyToSessionId",
                SessionId = "sessionId",
                To = "to"
            };
            correlationRuleFilter.ApplicationProperties.Add("customKey", "customValue");
            var rule3 = new CreateRuleOptions()
            {
                Name = "rule3",
                Filter = correlationRuleFilter,
                Action = null
            };
            await client.CreateRuleAsync(topicName, subscriptionName, rule3);
            RuleProperties getRule3 = await client.GetRuleAsync(topicName, subscriptionName, "rule3");
            Assert.AreEqual(rule3, new CreateRuleOptions(getRule3));

            List<RuleProperties> ruleList = new List<RuleProperties>();
            await foreach (RuleProperties rule in client.GetRulesAsync(topicName, subscriptionName))
            {
                ruleList.Add(rule);
            }
            RuleProperties[] ruleArr = ruleList.ToArray();
            Assert.True(ruleArr.Length == 3);
            Assert.AreEqual(rule1, new CreateRuleOptions(ruleArr[0]));
            Assert.AreEqual(rule2, new CreateRuleOptions(ruleArr[1]));
            Assert.AreEqual(rule3, new CreateRuleOptions(ruleArr[2]));

            ((CorrelationRuleFilter)getRule3.Filter).CorrelationId = "correlationIdModified";
            SubscriptionProperties sub = await client.GetSubscriptionAsync(topicName, subscriptionName);
            RuleProperties updatedRule3 = await client.UpdateRuleAsync(topicName, subscriptionName, getRule3);
            Assert.AreEqual(getRule3, updatedRule3);

            bool exists = await client.RuleExistsAsync(topicName, subscriptionName, rule1.Name);
            Assert.True(exists);

            await client.DeleteRuleAsync(topicName, subscriptionName, "rule1");
            Assert.That(
                  async () =>
                  await client.GetRuleAsync(topicName, subscriptionName, "rule1"),
                  Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.MessagingEntityNotFound));

            exists = await client.RuleExistsAsync(topicName, subscriptionName, rule1.Name);
            Assert.False(exists);

            await client.DeleteTopicAsync(topicName);
        }

        [Test]
        [LiveOnly]
        public async Task GetQueueRuntimeInfo()
        {
            var queueName = nameof(GetQueueRuntimeInfo).ToLower() + Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var mgmtClient = GetClient();
            await using var sbClient = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

            QueueProperties queue = await mgmtClient.CreateQueueAsync(queueName);
            queue = await mgmtClient.GetQueueAsync(queueName);
            // Changing Last Updated Time
            queue.AutoDeleteOnIdle = TimeSpan.FromMinutes(100);
            QueueProperties updatedQueue = await mgmtClient.UpdateQueueAsync(queue);

            // Populating 1 active message, 1 dead letter message and 1 scheduled message
            // Changing Last Accessed Time

            ServiceBusSender sender = sbClient.CreateSender(queueName);
            await sender.SendMessageAsync(new ServiceBusMessage() { MessageId = "1" });
            await sender.SendMessageAsync(new ServiceBusMessage() { MessageId = "2" });
            await sender.SendMessageAsync(new ServiceBusMessage() { MessageId = "3", ScheduledEnqueueTime = DateTime.UtcNow.AddDays(1) });

            ServiceBusReceiver receiver = sbClient.CreateReceiver(queueName);
            ServiceBusReceivedMessage msg = await receiver.ReceiveMessageAsync();
            await receiver.DeadLetterMessageAsync(msg.LockToken);

            List<QueueRuntimeProperties> runtimeInfoList = new List<QueueRuntimeProperties>();
            await foreach (QueueRuntimeProperties queueRuntimeInfo in mgmtClient.GetQueuesRuntimePropertiesAsync())
            {
                runtimeInfoList.Add(queueRuntimeInfo);
            }
            runtimeInfoList = runtimeInfoList.Where(e => e.Name.StartsWith(nameof(GetQueueRuntimeInfo).ToLower())).ToList();
            Assert.True(runtimeInfoList.Count == 1, $"Expected 1 queue but {runtimeInfoList.Count} queues returned");
            QueueRuntimeProperties runtimeInfo = runtimeInfoList.First();
            Assert.NotNull(runtimeInfo);

            Assert.AreEqual(queueName, runtimeInfo.Name);
            Assert.True(runtimeInfo.CreatedAt < runtimeInfo.UpdatedAt);
            Assert.True(runtimeInfo.UpdatedAt < runtimeInfo.AccessedAt);
            Assert.AreEqual(1, runtimeInfo.ActiveMessageCount);
            Assert.AreEqual(1, runtimeInfo.DeadLetterMessageCount);
            Assert.AreEqual(1, runtimeInfo.ScheduledMessageCount);
            Assert.AreEqual(3, runtimeInfo.TotalMessageCount);
            Assert.True(runtimeInfo.SizeInBytes > 0);

            QueueRuntimeProperties singleRuntimeInfo = await mgmtClient.GetQueueRuntimePropertiesAsync(runtimeInfo.Name);

            Assert.AreEqual(runtimeInfo.AccessedAt, singleRuntimeInfo.AccessedAt);
            Assert.AreEqual(runtimeInfo.CreatedAt, singleRuntimeInfo.CreatedAt);
            Assert.AreEqual(runtimeInfo.UpdatedAt, singleRuntimeInfo.UpdatedAt);
            Assert.AreEqual(runtimeInfo.TotalMessageCount, singleRuntimeInfo.TotalMessageCount);
            Assert.AreEqual(runtimeInfo.ActiveMessageCount, singleRuntimeInfo.ActiveMessageCount);
            Assert.AreEqual(runtimeInfo.DeadLetterMessageCount, singleRuntimeInfo.DeadLetterMessageCount);
            Assert.AreEqual(runtimeInfo.ScheduledMessageCount, singleRuntimeInfo.ScheduledMessageCount);
            Assert.AreEqual(runtimeInfo.SizeInBytes, singleRuntimeInfo.SizeInBytes);

            await mgmtClient.DeleteQueueAsync(queueName);
        }

        [Test]
        [LiveOnly]
        public async Task GetSubscriptionRuntimeInfoTest()
        {
            var topicName = nameof(GetSubscriptionRuntimeInfoTest).ToLower() + Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var subscriptionName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var client = GetClient();
            await using var sbClient = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

            await client.CreateTopicAsync(topicName);

            TopicProperties getTopic = await client.GetTopicAsync(topicName);

            // Changing Last Updated Time
            getTopic.AutoDeleteOnIdle = TimeSpan.FromMinutes(100);
            await client.UpdateTopicAsync(getTopic);

            SubscriptionProperties subscriptionDescription = await client.CreateSubscriptionAsync(topicName, subscriptionName);

            // Changing Last Updated Time for subscription
            subscriptionDescription.AutoDeleteOnIdle = TimeSpan.FromMinutes(100);
            await client.UpdateSubscriptionAsync(subscriptionDescription);

            // Populating 1 active message, 1 dead letter message and 1 scheduled message
            // Changing Last Accessed Time

            ServiceBusSender sender = sbClient.CreateSender(topicName);
            await sender.SendMessageAsync(new ServiceBusMessage() { MessageId = "1" });
            await sender.SendMessageAsync(new ServiceBusMessage() { MessageId = "2" });
            await sender.SendMessageAsync(new ServiceBusMessage() { MessageId = "3", ScheduledEnqueueTime = DateTime.UtcNow.AddDays(1) });

            ServiceBusReceiver receiver = sbClient.CreateReceiver(topicName, subscriptionName);
            ServiceBusReceivedMessage msg = await receiver.ReceiveMessageAsync();
            await receiver.DeadLetterMessageAsync(msg.LockToken);

            List<SubscriptionRuntimeProperties> runtimeInfoList = new List<SubscriptionRuntimeProperties>();
            await foreach (SubscriptionRuntimeProperties subscriptionRuntimeInfo in client.GetSubscriptionsRuntimePropertiesAsync(topicName))
            {
                runtimeInfoList.Add(subscriptionRuntimeInfo);
            }
            runtimeInfoList = runtimeInfoList.Where(e => e.TopicName.StartsWith(nameof(GetSubscriptionRuntimeInfoTest).ToLower())).ToList();
            Assert.True(runtimeInfoList.Count == 1, $"Expected 1 subscription but {runtimeInfoList.Count} subscriptions returned");
            SubscriptionRuntimeProperties runtimeInfo = runtimeInfoList.First();
            Assert.NotNull(runtimeInfo);

            Assert.AreEqual(topicName, runtimeInfo.TopicName);
            Assert.AreEqual(subscriptionName, runtimeInfo.SubscriptionName);

            Assert.True(runtimeInfo.CreatedAt < runtimeInfo.UpdatedAt);
            Assert.True(runtimeInfo.UpdatedAt < runtimeInfo.AccessedAt);

            Assert.AreEqual(1, runtimeInfo.ActiveMessageCount);
            Assert.AreEqual(1, runtimeInfo.DeadLetterMessageCount);
            Assert.AreEqual(2, runtimeInfo.TotalMessageCount);

            SubscriptionRuntimeProperties singleRuntimeInfo = await client.GetSubscriptionRuntimePropertiesAsync(topicName, subscriptionName);

            Assert.AreEqual(runtimeInfo.CreatedAt, singleRuntimeInfo.CreatedAt);
            Assert.AreEqual(runtimeInfo.AccessedAt, singleRuntimeInfo.AccessedAt);
            Assert.AreEqual(runtimeInfo.UpdatedAt, singleRuntimeInfo.UpdatedAt);
            Assert.AreEqual(runtimeInfo.SubscriptionName, singleRuntimeInfo.SubscriptionName);
            Assert.AreEqual(runtimeInfo.TotalMessageCount, singleRuntimeInfo.TotalMessageCount);
            Assert.AreEqual(runtimeInfo.ActiveMessageCount, singleRuntimeInfo.ActiveMessageCount);
            Assert.AreEqual(runtimeInfo.DeadLetterMessageCount, singleRuntimeInfo.DeadLetterMessageCount);
            Assert.AreEqual(runtimeInfo.TopicName, singleRuntimeInfo.TopicName);

            List<TopicRuntimeProperties> topicRuntimePropertiesList = new List<TopicRuntimeProperties>();
            await foreach (TopicRuntimeProperties topicRuntime in client.GetTopicsRuntimePropertiesAsync())
            {
                topicRuntimePropertiesList.Add(topicRuntime);
            }
            topicRuntimePropertiesList = topicRuntimePropertiesList.Where(e => e.Name.StartsWith(nameof(GetSubscriptionRuntimeInfoTest).ToLower())).ToList();
            Assert.True(topicRuntimePropertiesList.Count == 1, $"Expected 1 subscription but {topicRuntimePropertiesList.Count} subscriptions returned");
            TopicRuntimeProperties topicRuntimeProperties = topicRuntimePropertiesList.First();
            Assert.NotNull(topicRuntimeProperties);

            Assert.AreEqual(topicName, topicRuntimeProperties.Name);
            Assert.True(topicRuntimeProperties.CreatedAt < topicRuntimeProperties.UpdatedAt);
            Assert.True(topicRuntimeProperties.UpdatedAt < topicRuntimeProperties.AccessedAt);

            Assert.AreEqual(1, topicRuntimeProperties.ScheduledMessageCount);

            TopicRuntimeProperties singleTopicRuntimeProperties = await client.GetTopicRuntimePropertiesAsync(topicName);

            Assert.AreEqual(topicRuntimeProperties.CreatedAt, singleTopicRuntimeProperties.CreatedAt);
            Assert.AreEqual(topicRuntimeProperties.AccessedAt, singleTopicRuntimeProperties.AccessedAt);
            Assert.AreEqual(topicRuntimeProperties.UpdatedAt, singleTopicRuntimeProperties.UpdatedAt);
            Assert.AreEqual(topicRuntimeProperties.ScheduledMessageCount, singleTopicRuntimeProperties.ScheduledMessageCount);
            Assert.AreEqual(topicRuntimeProperties.Name, singleTopicRuntimeProperties.Name);

            await client.DeleteTopicAsync(topicName);
        }

        [Test]
        public async Task GetTopicRuntimeInfo()
        {
            var topicName = nameof(GetTopicRuntimeInfo).ToLower() + Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var subscriptionName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var client = GetClient();

            await client.CreateTopicAsync(topicName);

            TopicProperties getTopic = await client.GetTopicAsync(topicName);

            // Changing Last Updated Time
            getTopic.AutoDeleteOnIdle = TimeSpan.FromMinutes(100);
            await client.UpdateTopicAsync(getTopic);

            await client.CreateSubscriptionAsync(topicName, subscriptionName);

            List<TopicRuntimeProperties> runtimeInfoList = new List<TopicRuntimeProperties>();
            await foreach (TopicRuntimeProperties topicRuntimeInfo in client.GetTopicsRuntimePropertiesAsync())
            {
                runtimeInfoList.Add(topicRuntimeInfo);
            }
            runtimeInfoList = runtimeInfoList.Where(e => e.Name.StartsWith(nameof(GetTopicRuntimeInfo).ToLower())).ToList();
            Assert.True(runtimeInfoList.Count == 1, $"Expected 1 topic but {runtimeInfoList.Count} topics returned");
            TopicRuntimeProperties runtimeInfo = runtimeInfoList.First();
            Assert.NotNull(runtimeInfo);

            Assert.AreEqual(topicName, runtimeInfo.Name);
            Assert.True(runtimeInfo.CreatedAt < runtimeInfo.UpdatedAt);
            Assert.True(runtimeInfo.UpdatedAt < runtimeInfo.AccessedAt);
            Assert.AreEqual(1, runtimeInfo.SubscriptionCount);

            TopicRuntimeProperties singleTopicRI = await client.GetTopicRuntimePropertiesAsync(runtimeInfo.Name);

            Assert.AreEqual(runtimeInfo.AccessedAt, singleTopicRI.AccessedAt);
            Assert.AreEqual(runtimeInfo.CreatedAt, singleTopicRI.CreatedAt);
            Assert.AreEqual(runtimeInfo.UpdatedAt, singleTopicRI.UpdatedAt);
            Assert.AreEqual(runtimeInfo.SizeInBytes, singleTopicRI.SizeInBytes);
            Assert.AreEqual(runtimeInfo.SubscriptionCount, singleTopicRI.SubscriptionCount);
            Assert.AreEqual(runtimeInfo.ScheduledMessageCount, singleTopicRI.ScheduledMessageCount);

            await client.DeleteTopicAsync(topicName);
        }

        [Test]
        public async Task ThrowsIfEntityDoesNotExist()
        {
            var client = GetClient();

            Assert.That(
                async () =>
                await client.GetQueueAsync("NonExistingPath"),
                Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.MessagingEntityNotFound).
                    And.Property(nameof(Exception.InnerException)).InstanceOf(typeof(RequestFailedException)));

            Assert.That(
                async () =>
                await client.GetQueueAsync("NonExistingTopic"),
                Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.MessagingEntityNotFound).
                    And.Property(nameof(Exception.InnerException)).InstanceOf(typeof(RequestFailedException)));

            Assert.That(
                async () =>
                await client.GetSubscriptionAsync("NonExistingTopic", "NonExistingPath"),
                Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.MessagingEntityNotFound).
                    And.Property(nameof(Exception.InnerException)).InstanceOf(typeof(RequestFailedException)));

            Assert.That(
                  async () =>
                  await client.UpdateQueueAsync(new QueueProperties("NonExistingPath")),
                  Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.MessagingEntityNotFound).
                    And.Property(nameof(Exception.InnerException)).InstanceOf(typeof(RequestFailedException)));

            Assert.That(
                async () =>
                await client.UpdateTopicAsync(new TopicProperties("NonExistingPath")),
                Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.MessagingEntityNotFound).
                    And.Property(nameof(Exception.InnerException)).InstanceOf(typeof(RequestFailedException)));

            Assert.That(
                async () =>
                await client.UpdateSubscriptionAsync(new SubscriptionProperties("NonExistingTopic", "NonExistingPath")),
                Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.MessagingEntityNotFound).
                    And.Property(nameof(Exception.InnerException)).InstanceOf(typeof(RequestFailedException)));

            Assert.That(
                async () =>
                await client.DeleteQueueAsync("NonExistingPath"),
                Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.MessagingEntityNotFound).
                    And.Property(nameof(Exception.InnerException)).InstanceOf(typeof(RequestFailedException)));

            Assert.That(
                  async () =>
                  await client.DeleteTopicAsync("NonExistingPath"),
                  Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.MessagingEntityNotFound).
                    And.Property(nameof(Exception.InnerException)).InstanceOf(typeof(RequestFailedException)));

            Assert.That(
                async () =>
                await client.DeleteSubscriptionAsync("NonExistingTopic", "NonExistingPath"),
                Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.MessagingEntityNotFound).
                    And.Property(nameof(Exception.InnerException)).InstanceOf(typeof(RequestFailedException)));

            var queueName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var topicName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);

            await client.CreateQueueAsync(queueName);
            await client.CreateTopicAsync(topicName);

            Assert.That(
                async () =>
                await client.GetQueueAsync(topicName),
                Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.MessagingEntityNotFound).
                    And.Property(nameof(Exception.InnerException)).InstanceOf(typeof(RequestFailedException)));

            Assert.That(
                async () =>
                await client.GetTopicAsync(queueName),
                Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.MessagingEntityNotFound).
                    And.Property(nameof(Exception.InnerException)).InstanceOf(typeof(RequestFailedException)));

            await client.DeleteQueueAsync(queueName);
            await client.DeleteTopicAsync(topicName);
        }

        [Test]
        public async Task ThrowsIfEntityAlreadyExists()
        {
            var client = GetClient();
            var queueName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var topicName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var subscriptionName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);

            await client.CreateQueueAsync(queueName);
            await client.CreateTopicAsync(topicName);
            await client.CreateSubscriptionAsync(topicName, subscriptionName);

            Assert.That(
                async () =>
                await client.CreateQueueAsync(queueName),
                Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.MessagingEntityAlreadyExists));

            Assert.That(
                async () =>
                await client.CreateTopicAsync(topicName),
                Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.MessagingEntityAlreadyExists));

            Assert.That(
                async () =>
                await client.CreateSubscriptionAsync(topicName, subscriptionName),
                Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.MessagingEntityAlreadyExists));

            await client.DeleteQueueAsync(queueName);
            await client.DeleteTopicAsync(topicName);
        }

        [Test]
        [LiveOnly]
        public async Task ForwardingEntity()
        {
            // queueName--Fwd to--> destinationName--fwd dlq to-- > dqlDestinationName
            var queueName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var destinationName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var dlqDestinationName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var mgmtClient = GetClient();

            await mgmtClient.CreateQueueAsync(dlqDestinationName);
            await mgmtClient.CreateQueueAsync(
                new CreateQueueOptions(destinationName)
                {
                    ForwardDeadLetteredMessagesTo = dlqDestinationName
                });

            await mgmtClient.CreateQueueAsync(
                new CreateQueueOptions(queueName)
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
            var client = GetClient();
            var topicName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var subscriptionName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);

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

            RuleProperties rule = await client.CreateRuleAsync(
                topicName,
                subscriptionName,
                new CreateRuleOptions("rule1", sqlFilter));
            Assert.AreEqual(sqlFilter, rule.Filter);

            await client.DeleteTopicAsync(topicName);
        }

        [Test]
        public async Task CorrelationFilterProperties()
        {
            var topicName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var subscriptionName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var client = GetClient();

            await client.CreateTopicAsync(topicName);
            await client.CreateSubscriptionAsync(topicName, subscriptionName);

            var filter = new CorrelationRuleFilter();
            filter.ApplicationProperties.Add("stringKey", "stringVal");
            filter.ApplicationProperties.Add("intKey", 5);
            filter.ApplicationProperties.Add("dateTimeKey", Recording.Now.UtcDateTime);

            RuleProperties rule = await client.CreateRuleAsync(
                topicName,
                subscriptionName,
                new CreateRuleOptions("rule1", filter));
            Assert.True(filter.ApplicationProperties.Count == 3);
            Assert.AreEqual(filter, rule.Filter);

            await client.DeleteTopicAsync(topicName);
        }

        [Test]
        public async Task GetNamespaceProperties()
        {
            var client = GetClient();

            NamespaceProperties nsInfo = await client.GetNamespacePropertiesAsync();
            Assert.NotNull(nsInfo);
            // Assert.AreEqual(MessagingSku.Standard, nsInfo.MessagingSku);    // Most CI systems generally use standard, hence this check just to ensure the API is working.
            Assert.AreEqual(NamespaceType.Messaging, nsInfo.NamespaceType); // Common namespace type used for testing is messaging.
        }

        [Test]
        public async Task AuthenticateWithAAD()
        {
            var queueName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var topicName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var client = GetAADClient();

            var queueOptions = new CreateQueueOptions(queueName);
            QueueProperties createdQueue = await client.CreateQueueAsync(queueOptions);

            Assert.AreEqual(queueOptions, new CreateQueueOptions(createdQueue));

            var topicOptions = new CreateTopicOptions(topicName);
            TopicProperties createdTopic = await client.CreateTopicAsync(topicOptions);

            Assert.AreEqual(topicOptions, new CreateTopicOptions(createdTopic));

            await client.DeleteQueueAsync(queueName);
            await client.DeleteTopicAsync(topicName);
        }

        [Test]
        public async Task AuthenticateWithSharedKeyCredential()
        {
            var queueName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var topicName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var client = GetSharedKeyTokenClient();

            var queueOptions = new CreateQueueOptions(queueName);
            QueueProperties createdQueue = await client.CreateQueueAsync(queueOptions);

            Assert.AreEqual(queueOptions, new CreateQueueOptions(createdQueue));

            var topicOptions = new CreateTopicOptions(topicName);
            TopicProperties createdTopic = await client.CreateTopicAsync(topicOptions);

            Assert.AreEqual(topicOptions, new CreateTopicOptions(createdTopic));

            await client.DeleteQueueAsync(queueName);
            await client.DeleteTopicAsync(topicName);
        }

        private TokenCredential GetTokenCredential() =>
            Mode == RecordedTestMode.Playback ? new ServiceBusTestTokenCredential() : TestEnvironment.Credential;

        private class ServiceBusTestTokenCredential : TokenCredential
        {
            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return new ValueTask<AccessToken>(GetToken(requestContext, cancellationToken));
            }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return new AccessToken("TEST TOKEN " + string.Join(" ", requestContext.Scopes), DateTimeOffset.MaxValue);
            }
        }
    }
}
