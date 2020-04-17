// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Filters;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.RuleManager
{
    public class RuleManagerLiveTests : ServiceBusLiveTestBase
    {
        [Test]
        public async Task CorrelationFilterTestCase()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusRuleManager ruleManager = client.CreateRuleManager(scope.TopicName, scope.SubscriptionNames.First());

                var rulesDescriptiontest = await ruleManager.GetRulesAsync();
                Assert.True(rulesDescriptiontest.Count() == 1);

                await ruleManager.RemoveRuleAsync(RuleDescription.DefaultRuleName);

                await ruleManager.AddRuleAsync(new RuleDescription
                {
                    Filter = new CorrelationFilter { Label = "Red" },
                    Name = "RedCorrelation"
                });

                var rulesDescription = await ruleManager.GetRulesAsync();
                Assert.True(rulesDescription.Count() == 1);
                Assert.AreEqual("RedCorrelation", rulesDescription.First().Name);

                ServiceBusSender sender = client.CreateSender(scope.TopicName);
                var messageId1 = Guid.NewGuid().ToString();
                await sender.SendAsync(new ServiceBusMessage { MessageId = messageId1, Label = "Blue" });

                var messageId2 = Guid.NewGuid().ToString();
                await sender.SendAsync(new ServiceBusMessage { MessageId = messageId2, Label = "Red" });

                await using var receiver = client.CreateReceiver(scope.TopicName, scope.SubscriptionNames.First());

                var messages = await receiver.ReceiveBatchAsync(2);
                Assert.NotNull(messages);
                Assert.True(messages.Count == 1);
                Assert.AreEqual(messageId2, messages.First().MessageId);
            }
        }

        [Test]
        public async Task SqlFilterTestCase()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusRuleManager ruleManager = client.CreateRuleManager(scope.TopicName, scope.SubscriptionNames.First());

                var rulesDescriptiontest = await ruleManager.GetRulesAsync();
                Assert.True(rulesDescriptiontest.Count() == 1);

                await ruleManager.RemoveRuleAsync(RuleDescription.DefaultRuleName);

                await ruleManager.AddRuleAsync(new RuleDescription
                {
                    Filter = new SqlFilter("Color = 'RedSql'"),
                    Name = "RedSql"
                });

                var rulesDescription = await ruleManager.GetRulesAsync();
                Assert.True(rulesDescription.Count() == 1);
                Assert.AreEqual("RedSql", rulesDescription.First().Name);

                ServiceBusSender sender = client.CreateSender(scope.TopicName);
                var messageId1 = Guid.NewGuid().ToString();
                await sender.SendAsync(new ServiceBusMessage
                {
                    MessageId = messageId1,
                    Label = "BlueSql",
                    Properties = { { "color", "BlueSql" } }
                });

                var messageId2 = Guid.NewGuid().ToString();
                await sender.SendAsync(new ServiceBusMessage
                {
                    MessageId = messageId2,
                    Label = "RedSql",
                    Properties = { { "color", "RedSql" } }
                });

                await using var receiver = client.CreateReceiver(scope.TopicName, scope.SubscriptionNames.First());

                var messages = await receiver.ReceiveBatchAsync(2);
                Assert.NotNull(messages);
                Assert.True(messages.Count == 1);
                Assert.AreEqual(messageId2, messages.First().MessageId);
            }
        }
    }
}
