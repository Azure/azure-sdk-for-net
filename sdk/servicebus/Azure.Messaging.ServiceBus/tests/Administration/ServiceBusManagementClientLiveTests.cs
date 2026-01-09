// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.Messaging.ServiceBus.Administration;
using Azure.Messaging.ServiceBus.Authorization;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Management
{
    [AsyncOnly]
    [NonParallelizable]
    [ClientTestFixture(ServiceBusAdministrationClientOptions.ServiceVersion.V2017_04, ServiceBusAdministrationClientOptions.ServiceVersion.V2021_05)]
    public class ServiceBusManagementClientLiveTests : RecordedTestBase<ServiceBusTestEnvironment>
    {
        // The authorization key needs to be exactly 44 ASCII encoded bytes.
        private const string SanitizedKeyValue = "SanitizedSanitizedSanitizedSanitizedSanitize";

        private readonly ServiceBusAdministrationClientOptions.ServiceVersion _serviceVersion;

        public ServiceBusManagementClientLiveTests(bool isAsync, ServiceBusAdministrationClientOptions.ServiceVersion serviceVersion) :
            base(isAsync: true)
        {
            SanitizedHeaders.Add("ServiceBusDlqSupplementaryAuthorization");
            SanitizedHeaders.Add("ServiceBusSupplementaryAuthorization");
            BodyRegexSanitizers.Add(
                new BodyRegexSanitizer(
                    "\\u003CPrimaryKey\\u003E.*\\u003C/PrimaryKey\\u003E")
                    {
                        Value = $"\u003CPrimaryKey\u003E{SanitizedKeyValue}\u003C/PrimaryKey\u003E"
                    });
            BodyRegexSanitizers.Add(
                new BodyRegexSanitizer(
                    "\\u003CSecondaryKey\\u003E.*\\u003C/SecondaryKey\\u003E")
                    {
                        Value = $"\u003CSecondaryKey\u003E{SanitizedKeyValue}\u003C/SecondaryKey\u003E"
                    });
            BodyRegexSanitizers.Add(
                new BodyRegexSanitizer(
                    "[^\\r](?<break>\\n)")
                {
                    GroupForReplace = "break",
                    Value = "\r\n"
                });
            _serviceVersion = serviceVersion;
        }

        private string GetNamespace(bool premium = false) => premium ? TestEnvironment.PremiumFullyQualifiedNamespace : TestEnvironment.FullyQualifiedNamespace;

        private ServiceBusAdministrationClientOptions CreateOptions() =>
            InstrumentClientOptions(new ServiceBusAdministrationClientOptions(_serviceVersion));

        private ServiceBusAdministrationClient CreateClient(bool premium = false) =>
            InstrumentClient(new ServiceBusAdministrationClient(GetNamespace(premium), TestEnvironment.Credential, CreateOptions()));

        private ServiceBusAdministrationClient CreateConnectionStringClient() =>
            InstrumentClient(
                new ServiceBusAdministrationClient(
                    TestEnvironment.ServiceBusConnectionString,
                    CreateOptions()));

        private ServiceBusAdministrationClient CreateSharedKeyTokenClient()
        {
            var properties = ServiceBusConnectionStringProperties.Parse(TestEnvironment.ServiceBusConnectionString);
            var credential = new AzureNamedKeyCredential(properties.SharedAccessKeyName, properties.SharedAccessKey);

            return InstrumentClient(
                new ServiceBusAdministrationClient(
                    TestEnvironment.FullyQualifiedNamespace,
                    credential,
                    CreateOptions()));
        }

        private ServiceBusAdministrationClient CreateSasTokenClient()
        {
            var properties = ServiceBusConnectionStringProperties.Parse(TestEnvironment.ServiceBusConnectionString);
            var resource = ServiceBusAdministrationClient.BuildAudienceResource(TestEnvironment.FullyQualifiedNamespace);
            var signature = new SharedAccessSignature(resource, properties.SharedAccessKeyName, properties.SharedAccessKey);
            var credential = new AzureSasCredential(signature.Value);

            return InstrumentClient(
                new ServiceBusAdministrationClient(
                    TestEnvironment.FullyQualifiedNamespace,
                    credential,
                    InstrumentClientOptions(new ServiceBusAdministrationClientOptions())));
        }

        [RecordedTest]
        [TestCase(false)]
        [TestCase(true)]
        public async Task BasicQueueCrudOperations(bool premium)
        {
            var queueName = nameof(BasicQueueCrudOperations).ToLower() + Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var client = CreateClient(premium);

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

            if (CanSetMaxMessageSize(premium))
            {
                queueOptions.MaxMessageSizeInKilobytes = 100000;
            }

            queueOptions.AuthorizationRules.Add(new SharedAccessAuthorizationRule(
                "allClaims",
                new[] { AccessRights.Manage, AccessRights.Send, AccessRights.Listen }));

            Response<QueueProperties> createdQueueResponse = await client.CreateQueueAsync(queueOptions);
            Response rawResponse = createdQueueResponse.GetRawResponse();
            Assert.Multiple(() =>
            {
                Assert.That(rawResponse.ClientRequestId, Is.Not.Null);
                Assert.That(rawResponse.ContentStream.CanRead, Is.True);
                Assert.That(rawResponse.ContentStream.Position, Is.EqualTo(0));
            });

            QueueProperties createdQueue = createdQueueResponse.Value;

            if (CanSetMaxMessageSize(premium))
            {
                Assert.That(createdQueue.MaxMessageSizeInKilobytes, Is.EqualTo(100000));
            }
            else if (_serviceVersion == ServiceBusAdministrationClientOptions.ServiceVersion.V2021_05)
            {
                // standard namespaces either use 256KB or 1024KB when in Canary
                Assert.That(createdQueue.MaxMessageSizeInKilobytes, Is.LessThanOrEqualTo(1024));
            }
            else
            {
                Assert.That(createdQueue.MaxMessageSizeInKilobytes, Is.Null);
            }

            AssertQueueOptions(queueOptions, createdQueue);

            Response<QueueProperties> getQueueResponse = await client.GetQueueAsync(queueOptions.Name);
            rawResponse = createdQueueResponse.GetRawResponse();
            Assert.That(rawResponse.ClientRequestId, Is.Not.Null);
            Assert.That(rawResponse.ContentStream.CanRead, Is.True);
            Assert.That(rawResponse.ContentStream.Position, Is.EqualTo(0));

            QueueProperties getQueue = getQueueResponse.Value;
            Assert.That(getQueue, Is.EqualTo(createdQueue));

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
            if (CanSetMaxMessageSize(premium))
            {
                getQueue.MaxMessageSizeInKilobytes = 10000;
            }

            QueueProperties updatedQueue = await client.UpdateQueueAsync(getQueue);

            if (Mode == RecordedTestMode.Playback)
            {
                // Auth rules use a randomly generated key, but we don't want to store
                // these in our test recordings, so we skip the auth rule comparison
                // when in playback mode.
                var rules = updatedQueue.AuthorizationRules;
                updatedQueue.AuthorizationRules = getQueue.AuthorizationRules.Clone();
                Assert.That(updatedQueue, Is.EqualTo(getQueue));
                updatedQueue.AuthorizationRules = rules;
            }
            else
            {
                Assert.That(updatedQueue, Is.EqualTo(getQueue));
            }
            Response<bool> isExistsResponse = await client.QueueExistsAsync(queueName);
            rawResponse = createdQueueResponse.GetRawResponse();

            Assert.Multiple(() =>
            {
                Assert.That(rawResponse.ClientRequestId, Is.Not.Null);
                Assert.That(rawResponse.ContentStream.CanRead, Is.True);
                Assert.That(rawResponse.ContentStream.Position, Is.EqualTo(0));
                Assert.That(isExistsResponse.Value, Is.True);
            });

            List<QueueProperties> queueList = new List<QueueProperties>();
            await foreach (QueueProperties queue in client.GetQueuesAsync())
            {
                queueList.Add(queue);
            }

            queueList = queueList.Where(e => e.Name.StartsWith(nameof(BasicQueueCrudOperations).ToLower())).ToList();
            Assert.Multiple(() =>
            {
                Assert.That(queueList, Has.Count.EqualTo(1), $"Expected 1 queue but {queueList.Count} queues returned");
                Assert.That(queueName, Is.EqualTo(queueList.First().Name));
            });

            await client.DeleteQueueAsync(updatedQueue.Name);

            Assert.That(
                   async () =>
                   await client.GetQueueAsync(queueOptions.Name),
                   Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.MessagingEntityNotFound));

            isExistsResponse = await client.QueueExistsAsync(queueName);
            Assert.That(isExistsResponse.Value, Is.False);
        }

        [RecordedTest]
        [TestCase(false, false)]
        [TestCase(false, true)]
        [TestCase(true, false)]
        [TestCase(true, true)]
        public async Task BasicTopicCrudOperations(bool premium, bool supportOrdering)
        {
            var topicName = nameof(BasicTopicCrudOperations).ToLower() + Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var client = CreateClient(premium);

            var options = new CreateTopicOptions(topicName)
            {
                AutoDeleteOnIdle = TimeSpan.FromHours(1),
                DefaultMessageTimeToLive = TimeSpan.FromDays(2),
                DuplicateDetectionHistoryTimeWindow = TimeSpan.FromMinutes(1),
                EnableBatchedOperations = true,
                EnablePartitioning = false,
                MaxSizeInMegabytes = 1024,
                RequiresDuplicateDetection = true,
                UserMetadata = nameof(BasicTopicCrudOperations),
                SupportOrdering = supportOrdering
            };

            if (CanSetMaxMessageSize(premium))
            {
                options.MaxMessageSizeInKilobytes = 100000;
            }

            options.AuthorizationRules.Add(new SharedAccessAuthorizationRule(
               "allClaims",
               new[] { AccessRights.Manage, AccessRights.Send, AccessRights.Listen }));

            Response<TopicProperties> createdTopicResponse = await client.CreateTopicAsync(options);
            Response rawResponse = createdTopicResponse.GetRawResponse();
            Assert.Multiple(() =>
            {
                Assert.That(rawResponse.ClientRequestId, Is.Not.Null);
                Assert.That(rawResponse.ContentStream.CanRead, Is.True);
                Assert.That(rawResponse.ContentStream.Position, Is.EqualTo(0));
            });

            TopicProperties createdTopic = createdTopicResponse.Value;

            if (CanSetMaxMessageSize(premium))
            {
                Assert.That(createdTopic.MaxMessageSizeInKilobytes, Is.EqualTo(100000));
            }
            else if (_serviceVersion == ServiceBusAdministrationClientOptions.ServiceVersion.V2021_05)
            {
                // standard namespaces either use 256KB or 1024KB when in Canary
                Assert.That(createdTopic.MaxMessageSizeInKilobytes, Is.LessThanOrEqualTo(1024));
            }
            else
            {
                Assert.That(createdTopic.MaxMessageSizeInKilobytes, Is.Null);
            }

            AssertTopicOptions(options, createdTopic);

            Response<TopicProperties> getTopicResponse = await client.GetTopicAsync(options.Name);

            rawResponse = getTopicResponse.GetRawResponse();
            Assert.That(rawResponse.ClientRequestId, Is.Not.Null);
            Assert.That(rawResponse.ContentStream.CanRead, Is.True);
            Assert.That(rawResponse.ContentStream.Position, Is.EqualTo(0));

            TopicProperties getTopic = getTopicResponse.Value;

            Assert.That(getTopic, Is.EqualTo(createdTopic));

            getTopic.EnableBatchedOperations = false;
            getTopic.DefaultMessageTimeToLive = TimeSpan.FromDays(3);
            getTopic.DuplicateDetectionHistoryTimeWindow = TimeSpan.FromMinutes(2);
            getTopic.EnableBatchedOperations = false;
            getTopic.MaxSizeInMegabytes = 1024;
            if (CanSetMaxMessageSize(premium))
            {
                getTopic.MaxMessageSizeInKilobytes = 10000;
            }

            Response<TopicProperties> updatedTopicResponse = await client.UpdateTopicAsync(getTopic);
            rawResponse = updatedTopicResponse.GetRawResponse();
            Assert.Multiple(() =>
            {
                Assert.That(rawResponse.ClientRequestId, Is.Not.Null);
                Assert.That(rawResponse.ContentStream.CanRead, Is.True);
                Assert.That(rawResponse.ContentStream.Position, Is.EqualTo(0));
            });

            TopicProperties updatedTopic = updatedTopicResponse.Value;
            Assert.That(updatedTopic, Is.EqualTo(getTopic));

            bool exists = await client.TopicExistsAsync(topicName);
            Assert.That(exists, Is.True);

            List<TopicProperties> topicList = new List<TopicProperties>();
            await foreach (TopicProperties topic in client.GetTopicsAsync())
            {
                topicList.Add(topic);
            }
            topicList = topicList.Where(e => e.Name.StartsWith(nameof(BasicTopicCrudOperations).ToLower())).ToList();
            Assert.Multiple(() =>
            {
                Assert.That(topicList, Has.Count.EqualTo(1), $"Expected 1 topic but {topicList.Count} topics returned");
                Assert.That(topicName, Is.EqualTo(topicList.First().Name));
            });

            Response response = await client.DeleteTopicAsync(updatedTopic.Name);
            Assert.Multiple(async () =>
            {
                Assert.That(response.ClientRequestId, Is.Not.Null);
                Assert.That(response.ContentStream.CanRead, Is.True);
                Assert.That(response.ContentStream.Position, Is.EqualTo(0));

                Assert.That(
                      async () =>
                      await client.GetTopicAsync(options.Name),
                      Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.MessagingEntityNotFound));
            });

            exists = await client.TopicExistsAsync(topicName);
            Assert.That(exists, Is.False);
        }

        private bool CanSetMaxMessageSize(bool premium)
        {
            return premium && _serviceVersion >= ServiceBusAdministrationClientOptions.ServiceVersion.V2021_05;
        }

        [RecordedTest]
        public async Task BasicSubscriptionCrudOperations()
        {
            var topicName = nameof(BasicSubscriptionCrudOperations).ToLower() + Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var subscriptionName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);

            var client = CreateClient();

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
            Assert.Multiple(() =>
            {
                Assert.That(rawResponse.ClientRequestId, Is.Not.Null);
                Assert.That(rawResponse.ContentStream.CanRead, Is.True);
                Assert.That(rawResponse.ContentStream.Position, Is.EqualTo(0));
            });

            SubscriptionProperties createdSubscription = createdSubscriptionResponse.Value;

            Assert.That(new CreateSubscriptionOptions(createdSubscription), Is.EqualTo(options));

            SubscriptionProperties getSubscription = await client.GetSubscriptionAsync(options.TopicName, options.SubscriptionName);
            Assert.That(new CreateSubscriptionOptions(getSubscription), Is.EqualTo(options));

            getSubscription.DefaultMessageTimeToLive = TimeSpan.FromDays(3);
            getSubscription.MaxDeliveryCount = 9;

            SubscriptionProperties updatedSubscription = await client.UpdateSubscriptionAsync(getSubscription);
            Assert.That(updatedSubscription, Is.EqualTo(getSubscription));

            bool exists = await client.SubscriptionExistsAsync(topicName, subscriptionName);
            Assert.That(exists, Is.True);

            List<SubscriptionProperties> subscriptionList = new List<SubscriptionProperties>();
            await foreach (Page<SubscriptionProperties> subscriptionPage in client.GetSubscriptionsAsync(topicName).AsPages())
            {
                Assert.Multiple(() =>
                {
                    Assert.That(subscriptionPage.GetRawResponse().ClientRequestId, Is.Not.Null);
                    Assert.That(subscriptionPage.GetRawResponse().ContentStream.CanRead, Is.True);
                    Assert.That(subscriptionPage.GetRawResponse().ContentStream.Position, Is.EqualTo(0));
                });
                subscriptionList.AddRange(subscriptionPage.Values);
            }
            subscriptionList = subscriptionList.Where(e => e.TopicName.StartsWith(nameof(BasicSubscriptionCrudOperations).ToLower())).ToList();
            Assert.Multiple(() =>
            {
                Assert.That(subscriptionList, Has.Count.EqualTo(1), $"Expected 1 subscription but {subscriptionList.Count} subscriptions returned");
                Assert.That(topicName, Is.EqualTo(subscriptionList.First().TopicName));
                Assert.That(subscriptionName, Is.EqualTo(subscriptionList.First().SubscriptionName));
            });

            await client.DeleteSubscriptionAsync(options.TopicName, options.SubscriptionName);

            Assert.That(
                  async () =>
                  await client.GetSubscriptionAsync(options.TopicName, options.SubscriptionName),
                  Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.MessagingEntityNotFound));

            await client.DeleteTopicAsync(options.TopicName);

            exists = await client.SubscriptionExistsAsync(topicName, subscriptionName);
            Assert.That(exists, Is.False);
        }

        [RecordedTest]
        public async Task BasicRuleCrudOperations()
        {
            var topicName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var subscriptionName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var client = CreateClient();
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
            Assert.That(new CreateRuleOptions(getRule1), Is.EqualTo(rule1));

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
            Assert.That(new CreateRuleOptions(getRule2), Is.EqualTo(rule2));

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
            Assert.That(new CreateRuleOptions(getRule3), Is.EqualTo(rule3));

            List<RuleProperties> ruleList = new List<RuleProperties>();
            await foreach (RuleProperties rule in client.GetRulesAsync(topicName, subscriptionName))
            {
                ruleList.Add(rule);
            }
            RuleProperties[] ruleArr = ruleList.ToArray();
            Assert.Multiple(() =>
            {
                Assert.That(ruleArr.Length, Is.EqualTo(3));
                Assert.That(new CreateRuleOptions(ruleArr[0]), Is.EqualTo(rule1));
                Assert.That(new CreateRuleOptions(ruleArr[1]), Is.EqualTo(rule2));
                Assert.That(new CreateRuleOptions(ruleArr[2]), Is.EqualTo(rule3));
            });

            ((CorrelationRuleFilter)getRule3.Filter).CorrelationId = "correlationIdModified";
            SubscriptionProperties sub = await client.GetSubscriptionAsync(topicName, subscriptionName);
            RuleProperties updatedRule3 = await client.UpdateRuleAsync(topicName, subscriptionName, getRule3);
            Assert.That(updatedRule3, Is.EqualTo(getRule3));

            bool exists = await client.RuleExistsAsync(topicName, subscriptionName, rule1.Name);
            Assert.That(exists, Is.True);

            await client.DeleteRuleAsync(topicName, subscriptionName, "rule1");
            Assert.That(
                  async () =>
                  await client.GetRuleAsync(topicName, subscriptionName, "rule1"),
                  Throws.InstanceOf<ServiceBusException>().And.Property(nameof(ServiceBusException.Reason)).EqualTo(ServiceBusFailureReason.MessagingEntityNotFound));

            exists = await client.RuleExistsAsync(topicName, subscriptionName, rule1.Name);
            Assert.That(exists, Is.False);

            await client.DeleteTopicAsync(topicName);
        }

        [RecordedTest]
        [LiveOnly]
        public async Task GetQueueRuntimeInfo()
        {
            var queueName = nameof(GetQueueRuntimeInfo).ToLower() + Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var mgmtClient = CreateClient();
            await using var sbClient = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);

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
            await receiver.DeadLetterMessageAsync(msg);

            List<QueueRuntimeProperties> runtimeInfoList = new List<QueueRuntimeProperties>();
            await foreach (QueueRuntimeProperties queueRuntimeInfo in mgmtClient.GetQueuesRuntimePropertiesAsync())
            {
                runtimeInfoList.Add(queueRuntimeInfo);
            }
            runtimeInfoList = runtimeInfoList.Where(e => e.Name.StartsWith(nameof(GetQueueRuntimeInfo).ToLower())).ToList();
            Assert.That(runtimeInfoList, Has.Count.EqualTo(1), $"Expected 1 queue but {runtimeInfoList.Count} queues returned");
            QueueRuntimeProperties runtimeInfo = runtimeInfoList.First();
            Assert.That(runtimeInfo, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(runtimeInfo.Name, Is.EqualTo(queueName));
                Assert.That(runtimeInfo.CreatedAt, Is.LessThan(runtimeInfo.UpdatedAt));
                Assert.That(runtimeInfo.UpdatedAt, Is.LessThan(runtimeInfo.AccessedAt));
                Assert.That(runtimeInfo.ActiveMessageCount, Is.EqualTo(1));
                Assert.That(runtimeInfo.DeadLetterMessageCount, Is.EqualTo(1));
                Assert.That(runtimeInfo.ScheduledMessageCount, Is.EqualTo(1));
                Assert.That(runtimeInfo.TotalMessageCount, Is.EqualTo(3));
                Assert.That(runtimeInfo.SizeInBytes > 0, Is.True);
            });

            QueueRuntimeProperties singleRuntimeInfo = await mgmtClient.GetQueueRuntimePropertiesAsync(runtimeInfo.Name);

            Assert.That(singleRuntimeInfo.AccessedAt, Is.EqualTo(runtimeInfo.AccessedAt));
            Assert.That(singleRuntimeInfo.CreatedAt, Is.EqualTo(runtimeInfo.CreatedAt));
            Assert.That(singleRuntimeInfo.UpdatedAt, Is.EqualTo(runtimeInfo.UpdatedAt));
            Assert.That(singleRuntimeInfo.TotalMessageCount, Is.EqualTo(runtimeInfo.TotalMessageCount));
            Assert.That(singleRuntimeInfo.ActiveMessageCount, Is.EqualTo(runtimeInfo.ActiveMessageCount));
            Assert.That(singleRuntimeInfo.DeadLetterMessageCount, Is.EqualTo(runtimeInfo.DeadLetterMessageCount));
            Assert.That(singleRuntimeInfo.ScheduledMessageCount, Is.EqualTo(runtimeInfo.ScheduledMessageCount));
            Assert.That(singleRuntimeInfo.SizeInBytes, Is.EqualTo(runtimeInfo.SizeInBytes));

            await mgmtClient.DeleteQueueAsync(queueName);
        }

        [RecordedTest]
        [LiveOnly]
        public async Task GetSubscriptionRuntimeInfoTest()
        {
            var topicName = nameof(GetSubscriptionRuntimeInfoTest).ToLower() + Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var subscriptionName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var client = CreateClient();
            await using var sbClient = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);

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
            await receiver.DeadLetterMessageAsync(msg);

            List<SubscriptionRuntimeProperties> runtimeInfoList = new List<SubscriptionRuntimeProperties>();
            await foreach (SubscriptionRuntimeProperties subscriptionRuntimeInfo in client.GetSubscriptionsRuntimePropertiesAsync(topicName))
            {
                runtimeInfoList.Add(subscriptionRuntimeInfo);
            }
            runtimeInfoList = runtimeInfoList.Where(e => e.TopicName.StartsWith(nameof(GetSubscriptionRuntimeInfoTest).ToLower())).ToList();
            Assert.That(runtimeInfoList, Has.Count.EqualTo(1), $"Expected 1 subscription but {runtimeInfoList.Count} subscriptions returned");
            SubscriptionRuntimeProperties runtimeInfo = runtimeInfoList.First();
            Assert.That(runtimeInfo, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(runtimeInfo.TopicName, Is.EqualTo(topicName));
                Assert.That(runtimeInfo.SubscriptionName, Is.EqualTo(subscriptionName));

                Assert.That(runtimeInfo.CreatedAt, Is.LessThan(runtimeInfo.UpdatedAt));
                Assert.That(runtimeInfo.UpdatedAt, Is.LessThan(runtimeInfo.AccessedAt));

                Assert.That(runtimeInfo.ActiveMessageCount, Is.EqualTo(1));
                Assert.That(runtimeInfo.DeadLetterMessageCount, Is.EqualTo(1));
                Assert.That(runtimeInfo.TotalMessageCount, Is.EqualTo(2));
            });

            SubscriptionRuntimeProperties singleRuntimeInfo = await client.GetSubscriptionRuntimePropertiesAsync(topicName, subscriptionName);

            Assert.Multiple(() =>
            {
                Assert.That(singleRuntimeInfo.CreatedAt, Is.EqualTo(runtimeInfo.CreatedAt));
                Assert.That(singleRuntimeInfo.AccessedAt, Is.EqualTo(runtimeInfo.AccessedAt));
                Assert.That(singleRuntimeInfo.UpdatedAt, Is.EqualTo(runtimeInfo.UpdatedAt));
                Assert.That(singleRuntimeInfo.SubscriptionName, Is.EqualTo(runtimeInfo.SubscriptionName));
                Assert.That(singleRuntimeInfo.TotalMessageCount, Is.EqualTo(runtimeInfo.TotalMessageCount));
                Assert.That(singleRuntimeInfo.ActiveMessageCount, Is.EqualTo(runtimeInfo.ActiveMessageCount));
                Assert.That(singleRuntimeInfo.DeadLetterMessageCount, Is.EqualTo(runtimeInfo.DeadLetterMessageCount));
                Assert.That(singleRuntimeInfo.TopicName, Is.EqualTo(runtimeInfo.TopicName));
            });

            List<TopicRuntimeProperties> topicRuntimePropertiesList = new List<TopicRuntimeProperties>();
            await foreach (TopicRuntimeProperties topicRuntime in client.GetTopicsRuntimePropertiesAsync())
            {
                topicRuntimePropertiesList.Add(topicRuntime);
            }
            topicRuntimePropertiesList = topicRuntimePropertiesList.Where(e => e.Name.StartsWith(nameof(GetSubscriptionRuntimeInfoTest).ToLower())).ToList();
            Assert.That(topicRuntimePropertiesList, Has.Count.EqualTo(1), $"Expected 1 subscription but {topicRuntimePropertiesList.Count} subscriptions returned");
            TopicRuntimeProperties topicRuntimeProperties = topicRuntimePropertiesList.First();
            Assert.That(topicRuntimeProperties, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(topicRuntimeProperties.Name, Is.EqualTo(topicName));
                Assert.That(topicRuntimeProperties.CreatedAt, Is.LessThan(topicRuntimeProperties.UpdatedAt));
                Assert.That(topicRuntimeProperties.UpdatedAt, Is.LessThan(topicRuntimeProperties.AccessedAt));

                Assert.That(topicRuntimeProperties.ScheduledMessageCount, Is.EqualTo(1));
            });

            TopicRuntimeProperties singleTopicRuntimeProperties = await client.GetTopicRuntimePropertiesAsync(topicName);

            Assert.Multiple(() =>
            {
                Assert.That(singleTopicRuntimeProperties.CreatedAt, Is.EqualTo(topicRuntimeProperties.CreatedAt));
                Assert.That(singleTopicRuntimeProperties.AccessedAt, Is.EqualTo(topicRuntimeProperties.AccessedAt));
                Assert.That(singleTopicRuntimeProperties.UpdatedAt, Is.EqualTo(topicRuntimeProperties.UpdatedAt));
                Assert.That(singleTopicRuntimeProperties.ScheduledMessageCount, Is.EqualTo(topicRuntimeProperties.ScheduledMessageCount));
                Assert.That(singleTopicRuntimeProperties.Name, Is.EqualTo(topicRuntimeProperties.Name));
            });

            await client.DeleteTopicAsync(topicName);
        }

        [RecordedTest]
        public async Task GetTopicRuntimeInfo()
        {
            var topicName = nameof(GetTopicRuntimeInfo).ToLower() + Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var subscriptionName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var client = CreateClient();

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
            Assert.That(runtimeInfoList, Has.Count.EqualTo(1), $"Expected 1 topic but {runtimeInfoList.Count} topics returned");
            TopicRuntimeProperties runtimeInfo = runtimeInfoList.First();
            Assert.That(runtimeInfo, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(runtimeInfo.Name, Is.EqualTo(topicName));
                Assert.That(runtimeInfo.CreatedAt, Is.LessThan(runtimeInfo.UpdatedAt));
                Assert.That(runtimeInfo.UpdatedAt, Is.LessThan(runtimeInfo.AccessedAt));
                Assert.That(runtimeInfo.SubscriptionCount, Is.EqualTo(1));
            });

            TopicRuntimeProperties singleTopicRI = await client.GetTopicRuntimePropertiesAsync(runtimeInfo.Name);

            Assert.Multiple(() =>
            {
                Assert.That(singleTopicRI.AccessedAt, Is.EqualTo(runtimeInfo.AccessedAt));
                Assert.That(singleTopicRI.CreatedAt, Is.EqualTo(runtimeInfo.CreatedAt));
                Assert.That(singleTopicRI.UpdatedAt, Is.EqualTo(runtimeInfo.UpdatedAt));
                Assert.That(singleTopicRI.SizeInBytes, Is.EqualTo(runtimeInfo.SizeInBytes));
                Assert.That(singleTopicRI.SubscriptionCount, Is.EqualTo(runtimeInfo.SubscriptionCount));
                Assert.That(singleTopicRI.ScheduledMessageCount, Is.EqualTo(runtimeInfo.ScheduledMessageCount));
            });

            await client.DeleteTopicAsync(topicName);
        }

        [RecordedTest]
        public async Task ThrowsIfEntityDoesNotExist()
        {
            var client = CreateClient();

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

        [RecordedTest]
        public async Task ThrowsIfEntityAlreadyExists()
        {
            var client = CreateClient();
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

        [RecordedTest]
        [LiveOnly]
        public async Task ForwardingEntity()
        {
            // queueName--Fwd to--> destinationName--fwd dlq to-- > dqlDestinationName
            var queueName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var destinationName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var dlqDestinationName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var mgmtClient = CreateClient();

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

            await using var sbClient = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
            ServiceBusSender sender = sbClient.CreateSender(queueName);
            await sender.SendMessageAsync(new ServiceBusMessage() { MessageId = "mid" });

            ServiceBusReceiver receiver = sbClient.CreateReceiver(destinationName);
            ServiceBusReceivedMessage msg = await receiver.ReceiveMessageAsync();
            Assert.That(msg, Is.Not.Null);
            Assert.That(msg.MessageId, Is.EqualTo("mid"));
            await receiver.DeadLetterMessageAsync(msg);

            receiver = sbClient.CreateReceiver(dlqDestinationName);
            msg = await receiver.ReceiveMessageAsync();
            Assert.That(msg, Is.Not.Null);
            Assert.That(msg.MessageId, Is.EqualTo("mid"));
            await receiver.CompleteMessageAsync(msg);

            await mgmtClient.DeleteQueueAsync(queueName);
            await mgmtClient.DeleteQueueAsync(destinationName);
            await mgmtClient.DeleteQueueAsync(dlqDestinationName);
        }

        [RecordedTest]
        public async Task SqlFilterParams()
        {
            var client = CreateClient();
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
            Assert.That(rule.Filter, Is.EqualTo(sqlFilter));

            await client.DeleteTopicAsync(topicName);
        }

        [RecordedTest]
        public async Task CorrelationFilterProperties()
        {
            var topicName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var subscriptionName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var client = CreateClient();

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
            Assert.Multiple(() =>
            {
                Assert.That(filter.ApplicationProperties, Has.Count.EqualTo(3));
                Assert.That(rule.Filter, Is.EqualTo(filter));
            });

            await client.DeleteTopicAsync(topicName);
        }

        [RecordedTest]
        public async Task GetNamespaceProperties()
        {
            var client = CreateClient();

            NamespaceProperties nsInfo = await client.GetNamespacePropertiesAsync();
            Assert.That(nsInfo, Is.Not.Null);
            // Assert.AreEqual(MessagingSku.Standard, nsInfo.MessagingSku);    // Most CI systems generally use standard, hence this check just to ensure the API is working.
            Assert.That(nsInfo.NamespaceType, Is.EqualTo(NamespaceType.Messaging)); // Common namespace type used for testing is messaging.
        }

        [RecordedTest]
        public async Task AuthenticateWithConnectionString()
        {
            var queueName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var topicName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var client = CreateConnectionStringClient();

            var queueOptions = new CreateQueueOptions(queueName);
            QueueProperties createdQueue = await client.CreateQueueAsync(queueOptions);

            AssertQueueOptions(queueOptions, createdQueue);

            var topicOptions = new CreateTopicOptions(topicName);
            TopicProperties createdTopic = await client.CreateTopicAsync(topicOptions);

            AssertTopicOptions(topicOptions, createdTopic);

            await client.DeleteQueueAsync(queueName);
            await client.DeleteTopicAsync(topicName);
        }

        [RecordedTest]
        public async Task AuthenticateWithSharedKeyCredential()
        {
            var queueName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var topicName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var client = CreateSharedKeyTokenClient();

            var queueOptions = new CreateQueueOptions(queueName);
            QueueProperties createdQueue = await client.CreateQueueAsync(queueOptions);

            AssertQueueOptions(queueOptions, createdQueue);

            var topicOptions = new CreateTopicOptions(topicName);
            TopicProperties createdTopic = await client.CreateTopicAsync(topicOptions);

            AssertTopicOptions(topicOptions, createdTopic);

            await client.DeleteQueueAsync(queueName);
            await client.DeleteTopicAsync(topicName);
        }

        [RecordedTest]
        public async Task AuthenticateWithSasCredential()
        {
            var queueName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var topicName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var client = CreateSharedKeyTokenClient();

            var queueOptions = new CreateQueueOptions(queueName);
            QueueProperties createdQueue = await client.CreateQueueAsync(queueOptions);

            AssertQueueOptions(queueOptions, createdQueue);

            var topicOptions = new CreateTopicOptions(topicName);
            TopicProperties createdTopic = await client.CreateTopicAsync(topicOptions);

            AssertTopicOptions(topicOptions, createdTopic);

            await client.DeleteQueueAsync(queueName);
            await client.DeleteTopicAsync(topicName);
        }

        [RecordedTest]
        public async Task ThrowsWhenAttemptingToUseDeadLetterPathOnQueueMethods()
        {
            var queueName = nameof(ThrowsWhenAttemptingToUseDeadLetterPathOnQueueMethods).ToLower() + Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var client = CreateClient();

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
            await client.CreateQueueAsync(queueOptions);

            Assert.That(
                async () =>
                    await client.GetQueueAsync(EntityNameFormatter.FormatDeadLetterPath(queueName)),
                Throws.InstanceOf<ArgumentException>().And.Property(nameof(Exception.InnerException))
                    .InstanceOf(typeof(RequestFailedException)));

            Assert.That(
                async () =>
                    await client.GetQueueRuntimePropertiesAsync(EntityNameFormatter.FormatDeadLetterPath(queueName)),
                Throws.InstanceOf<ArgumentException>().And.Property(nameof(Exception.InnerException))
                    .InstanceOf(typeof(RequestFailedException)));
        }

        [RecordedTest]
        public async Task ThrowsWhenAttemptingToUseDeadLetterPathOnTopicMethods()
        {
            var topicName = nameof(ThrowsWhenAttemptingToUseDeadLetterPathOnTopicMethods).ToLower() + Recording.Random.NewGuid().ToString("D").Substring(0, 8);
            var client = CreateClient();

            var options = new CreateTopicOptions(topicName)
            {
                AutoDeleteOnIdle = TimeSpan.FromHours(1),
                DefaultMessageTimeToLive = TimeSpan.FromDays(2),
                DuplicateDetectionHistoryTimeWindow = TimeSpan.FromMinutes(1),
                EnableBatchedOperations = true,
                EnablePartitioning = false,
                MaxSizeInMegabytes = 1024,
                RequiresDuplicateDetection = true,
                UserMetadata = nameof(BasicTopicCrudOperations),
            };
            await client.CreateTopicAsync(options);

            var subscriptionName = Recording.Random.NewGuid().ToString("D").Substring(0, 8);

            await client.CreateSubscriptionAsync(topicName, subscriptionName);

            Assert.That(
                async () =>
                    await client.GetTopicAsync(EntityNameFormatter.FormatDeadLetterPath(topicName)),
                Throws.InstanceOf<ArgumentException>().And.Property(nameof(Exception.InnerException))
                    .InstanceOf(typeof(RequestFailedException)));

            Assert.That(
                async () =>
                    await client.GetTopicRuntimePropertiesAsync(EntityNameFormatter.FormatDeadLetterPath(topicName)),
                Throws.InstanceOf<ArgumentException>().And.Property(nameof(Exception.InnerException))
                    .InstanceOf(typeof(RequestFailedException)));
        }

        private void AssertQueueOptions(CreateQueueOptions queueOptions, QueueProperties createdQueue)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(new CreateQueueOptions(createdQueue) { AuthorizationRules = queueOptions.AuthorizationRules.Clone(), MaxMessageSizeInKilobytes = queueOptions.MaxMessageSizeInKilobytes },
                                    Is.EqualTo(queueOptions));
                    Assert.That(new QueueProperties(queueOptions) { AuthorizationRules = createdQueue.AuthorizationRules, MaxMessageSizeInKilobytes = createdQueue.MaxMessageSizeInKilobytes }, Is.EqualTo(createdQueue));
                });
            }
            else
            {
                Assert.Multiple(() =>
                {
                    Assert.That(new CreateQueueOptions(createdQueue) { MaxMessageSizeInKilobytes = queueOptions.MaxMessageSizeInKilobytes },
                                    Is.EqualTo(queueOptions));
                    Assert.That(new QueueProperties(queueOptions) { MaxMessageSizeInKilobytes = createdQueue.MaxMessageSizeInKilobytes },
                        Is.EqualTo(createdQueue));
                });
            }
        }

        private void AssertTopicOptions(CreateTopicOptions options, TopicProperties createdTopic)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                Assert.Multiple(() =>
                {
                    // Auth rules use a randomly generated key, but we don't want to store
                    // these in our test recordings, so we skip the auth rule comparison
                    // when in playback mode.
                    Assert.That(new CreateTopicOptions(createdTopic) { AuthorizationRules = options.AuthorizationRules.Clone(), MaxMessageSizeInKilobytes = options.MaxMessageSizeInKilobytes }, Is.EqualTo(options));
                    Assert.That(new TopicProperties(options)
                    {
                        AuthorizationRules = createdTopic.AuthorizationRules.Clone(),
                        MaxMessageSizeInKilobytes = createdTopic.MaxMessageSizeInKilobytes
                    }, Is.EqualTo(createdTopic));
                });
            }
            else
            {
                Assert.Multiple(() =>
                {
                    Assert.That(new CreateTopicOptions(createdTopic) { MaxMessageSizeInKilobytes = options.MaxMessageSizeInKilobytes }, Is.EqualTo(options));
                    Assert.That(new TopicProperties(options) { MaxMessageSizeInKilobytes = createdTopic.MaxMessageSizeInKilobytes }, Is.EqualTo(createdTopic));
                });
            }
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
