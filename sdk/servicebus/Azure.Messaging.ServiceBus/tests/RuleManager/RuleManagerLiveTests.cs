// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Administration;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.RuleManager
{
    public class RuleManagerLiveTests : ServiceBusLiveTestBase
    {
        [Test]
        public async Task AddGetAndRemoveRules()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);

                ServiceBusRuleManager ruleManager = client.CreateRuleManager(scope.TopicName, scope.SubscriptionNames.First());
                var sqlRuleName = "sqlRule";
                var correlationRuleName = "correlationRule";

                var rules = await GetAllRulesAsync(ruleManager);
                Assert.That(rules.Count(), Is.EqualTo(1));
                var firstRule = rules[0];
                Assert.That(firstRule.Name, Is.EqualTo(RuleProperties.DefaultRuleName));
                Assert.That(firstRule.Action, Is.Null);

                await ruleManager.CreateRuleAsync(sqlRuleName, new SqlRuleFilter("price > 10"));

                var ruleOptions = new CreateRuleOptions(correlationRuleName)
                {
                    Filter = new CorrelationRuleFilter
                    {
                        CorrelationId = "correlationId",
                        Subject = "label",
                        MessageId = "messageId",
                        ApplicationProperties =
                            {
                                {"key1", "value1"}
                            },
                        ReplyTo = "replyTo",
                        ReplyToSessionId = "replyToSessionId",
                        SessionId = "sessionId",
                        To = "to"
                    },
                    Action = new SqlRuleAction("Set CorrelationId = 'newValue'")
                };
                await ruleManager.CreateRuleAsync(ruleOptions);

                rules = await GetAllRulesAsync(ruleManager);
                Assert.That(rules.Count, Is.EqualTo(3));

                var sqlRule = rules.FirstOrDefault(rule => rule.Name.Equals(sqlRuleName));
                Assert.NotNull(sqlRule);
                Assert.That(sqlRule.Action, Is.Null);
                Assert.IsInstanceOf<SqlRuleFilter>(sqlRule.Filter);
                Assert.That(((SqlRuleFilter)sqlRule.Filter).SqlExpression, Is.EqualTo("price > 10"));

                var correlationRule = rules.FirstOrDefault(rule => rule.Name.Equals(correlationRuleName));
                Assert.NotNull(correlationRule);
                Assert.IsInstanceOf<SqlRuleAction>(correlationRule.Action);
                var sqlRuleAction = correlationRule.Action as SqlRuleAction;
                Assert.NotNull(sqlRuleAction);
                Assert.That(sqlRuleAction.SqlExpression, Is.EqualTo("Set CorrelationId = 'newValue'"));
                Assert.IsInstanceOf<CorrelationRuleFilter>(correlationRule.Filter);
                var correlationRuleFilter = correlationRule.Filter as CorrelationRuleFilter;
                Assert.NotNull(correlationRuleFilter);
                Assert.That(correlationRuleFilter.CorrelationId, Is.EqualTo("correlationId"));
                Assert.That(correlationRuleFilter.Subject, Is.EqualTo("label"));
                Assert.That(correlationRuleFilter.MessageId, Is.EqualTo("messageId"));
                Assert.That(correlationRuleFilter.ReplyTo, Is.EqualTo("replyTo"));
                Assert.That(correlationRuleFilter.ReplyToSessionId, Is.EqualTo("replyToSessionId"));
                Assert.That(correlationRuleFilter.SessionId, Is.EqualTo("sessionId"));
                Assert.That(correlationRuleFilter.To, Is.EqualTo("to"));
                Assert.NotNull(correlationRuleFilter.ApplicationProperties);
                Assert.That(correlationRuleFilter.ApplicationProperties["key1"], Is.EqualTo("value1"));

                await ruleManager.DeleteRuleAsync(RuleProperties.DefaultRuleName);
                await ruleManager.DeleteRuleAsync(sqlRuleName);
                await ruleManager.DeleteRuleAsync(correlationRuleName);
                rules = await GetAllRulesAsync(ruleManager);
                Assert.That(rules.Count, Is.EqualTo(0));
            }
        }

        private async Task<List<RuleProperties>> GetAllRulesAsync(ServiceBusRuleManager ruleManager)
        {
            var rules = new List<RuleProperties>();
            await foreach (var rule in ruleManager.GetRulesAsync())
            {
                rules.Add(rule);
            }

            return rules;
        }

        [Test]
        public async Task ThrowIfAddSameRuleNameTwice()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);

                ServiceBusRuleManager ruleManager = client.CreateRuleManager(scope.TopicName, scope.SubscriptionNames.First());

                await ruleManager.CreateRuleAsync(new CreateRuleOptions
                {
                    Filter = new CorrelationRuleFilter { Subject = "yellow" },
                    Name = "CorrelationRuleFilter"
                });

                Assert.That(async () => await ruleManager.CreateRuleAsync(new CreateRuleOptions
                {
                    Filter = new CorrelationRuleFilter { Subject = "red" },
                    Name = "CorrelationRuleFilter"
                }), Throws.InstanceOf<ServiceBusException>());
            }
        }

        /// <summary>
        /// Subscription with default filter receives all messages.
        /// </summary>
        [Test]
        public async Task DefaultFilter()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);

                ServiceBusRuleManager ruleManager = client.CreateRuleManager(scope.TopicName, scope.SubscriptionNames.First());

                IEnumerable<RuleProperties> rulesProperties = await GetAllRulesAsync(ruleManager);
                Assert.That(rulesProperties.Count(), Is.EqualTo(1));
                Assert.That(rulesProperties.First().Name, Is.EqualTo(RuleProperties.DefaultRuleName));

                await SendMessages(client, scope.TopicName);

                var expectedOrders = Orders.ToList();
                await ReceiveAndAssertMessages(
                    client,
                    scope.TopicName,
                    scope.SubscriptionNames.First(),
                    expectedOrders);
            }
        }

        /// <summary>
        /// True boolean filter receives all messages.
        /// </summary>
        [Test]
        public async Task TrueRuleFilter()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);

                ServiceBusRuleManager ruleManager = client.CreateRuleManager(scope.TopicName, scope.SubscriptionNames.First());

                List<RuleProperties> ruleProperties = await GetAllRulesAsync(ruleManager);
                Assert.That(ruleProperties.Count(), Is.EqualTo(1));
                Assert.That(ruleProperties.First().Name, Is.EqualTo(RuleProperties.DefaultRuleName));

                await ruleManager.DeleteRuleAsync(RuleProperties.DefaultRuleName);

                ruleProperties = await GetAllRulesAsync(ruleManager);
                Assert.That(ruleProperties.Count(), Is.EqualTo(0));

                await ruleManager.CreateRuleAsync(new CreateRuleOptions
                {
                    Filter = new TrueRuleFilter(),
                    Name = "BooleanFilter"
                });

                ruleProperties = await GetAllRulesAsync(ruleManager);
                Assert.That(ruleProperties.Count() == 1, Is.True);
                Assert.That(ruleProperties.First().Name, Is.EqualTo("BooleanFilter"));

                await SendMessages(client, scope.TopicName);

                var expectedOrders = Orders.ToList();
                await ReceiveAndAssertMessages(
                    client,
                    scope.TopicName,
                    scope.SubscriptionNames.First(),
                    expectedOrders);
            }
        }

        /// <summary>
        /// False boolean filter does not receive any messages.
        /// </summary>
        [Test]
        public async Task FalseRuleFilter()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);

                ServiceBusRuleManager ruleManager = client.CreateRuleManager(scope.TopicName, scope.SubscriptionNames.First());

                List<RuleProperties> ruleProperties = await GetAllRulesAsync(ruleManager);
                Assert.That(ruleProperties.Count(), Is.EqualTo(1));
                Assert.That(ruleProperties.First().Name, Is.EqualTo(RuleProperties.DefaultRuleName));

                await ruleManager.DeleteRuleAsync(RuleProperties.DefaultRuleName);

                ruleProperties = await GetAllRulesAsync(ruleManager);
                Assert.That(ruleProperties.Count(), Is.EqualTo(0));

                await ruleManager.CreateRuleAsync(new CreateRuleOptions
                {
                    Filter = new FalseRuleFilter(),
                    Name = "BooleanFilter"
                });

                ruleProperties = await GetAllRulesAsync(ruleManager);
                Assert.That(ruleProperties.Count(), Is.EqualTo(1));
                Assert.That(ruleProperties.First().Name, Is.EqualTo("BooleanFilter"));

                await SendMessages(client, scope.TopicName);

                var receiver = client.CreateReceiver(scope.TopicName, scope.SubscriptionNames.First());
                var messages = await receiver.ReceiveMessagesAsync(Orders.Length, TimeSpan.FromSeconds(10));
                Assert.That(messages.Count(), Is.EqualTo(0));
            }
        }

        [Test]
        public async Task CorrelationRuleFilterOnTheMessageProperties()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);

                ServiceBusRuleManager ruleManager = client.CreateRuleManager(scope.TopicName, scope.SubscriptionNames.First());

                IEnumerable<RuleProperties> rulesProperties = await GetAllRulesAsync(ruleManager);
                Assert.That(rulesProperties.Count(), Is.EqualTo(1));

                Assert.That(rulesProperties.First().Name, Is.EqualTo(RuleProperties.DefaultRuleName));

                await ruleManager.DeleteRuleAsync(RuleProperties.DefaultRuleName);

                await ruleManager.CreateRuleAsync(new CreateRuleOptions
                {
                    Filter = new CorrelationRuleFilter { Subject = "red" },
                    Name = "CorrelationMsgPropertyRule"
                });

                rulesProperties = await GetAllRulesAsync(ruleManager);
                Assert.That(rulesProperties.Count(), Is.EqualTo(1));
                Assert.That(rulesProperties.First().Name, Is.EqualTo("CorrelationMsgPropertyRule"));

                await SendMessages(client, scope.TopicName);

                var expectedOrders = Orders.Where(c => c.Color == "red").ToList();
                await ReceiveAndAssertMessages(
                    client,
                    scope.TopicName,
                    scope.SubscriptionNames.First(),
                    expectedOrders);
            }
        }

        [Test]
        public async Task CorrelationRuleFilterOnTheUserProperties()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);

                ServiceBusRuleManager ruleManager = client.CreateRuleManager(scope.TopicName, scope.SubscriptionNames.First());

                IEnumerable<RuleProperties> rulesProperties = await GetAllRulesAsync(ruleManager);
                Assert.That(rulesProperties.Count(), Is.EqualTo(1));
                Assert.That(rulesProperties.First().Name, Is.EqualTo(RuleProperties.DefaultRuleName));

                await ruleManager.DeleteRuleAsync(RuleProperties.DefaultRuleName);

                await ruleManager.CreateRuleAsync(new CreateRuleOptions
                {
                    Filter = new CorrelationRuleFilter { ApplicationProperties = { { "color", "red" } } },
                    Name = "CorrelationUserPropertyRule"
                });

                rulesProperties = await GetAllRulesAsync(ruleManager);
                Assert.That(rulesProperties.Count(), Is.EqualTo(1));
                Assert.That(rulesProperties.First().Name, Is.EqualTo("CorrelationUserPropertyRule"));

                await SendMessages(client, scope.TopicName);

                var expectedOrders = Orders.Where(c => c.Color == "red").ToList();
                await ReceiveAndAssertMessages(
                    client,
                    scope.TopicName,
                    scope.SubscriptionNames.First(),
                    expectedOrders);
            }
        }

        [Test]
        public async Task CorrelationRuleFilterWithSqlRuleAction()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);

                ServiceBusRuleManager ruleManager = client.CreateRuleManager(scope.TopicName, scope.SubscriptionNames.First());

                IEnumerable<RuleProperties> rulesProperties = await GetAllRulesAsync(ruleManager);
                Assert.That(rulesProperties.Count(), Is.EqualTo(1));
                Assert.That(rulesProperties.First().Name, Is.EqualTo(RuleProperties.DefaultRuleName));

                await ruleManager.DeleteRuleAsync(RuleProperties.DefaultRuleName);

                await ruleManager.CreateRuleAsync(new CreateRuleOptions
                {
                    Filter = new CorrelationRuleFilter { ApplicationProperties = { { "Color", "blue" } } },
                    Action = new SqlRuleAction("Set Priority = 'high'"),
                    Name = "CorrelationRuleWithAction"
                });

                rulesProperties = await GetAllRulesAsync(ruleManager);
                Assert.That(rulesProperties.Count(), Is.EqualTo(1));
                Assert.That(rulesProperties.First().Name, Is.EqualTo("CorrelationRuleWithAction"));

                await SendMessages(client, scope.TopicName);

                var expectedOrders = Orders.Where(c => c.Color == "blue").ToList();
                var receivedMessages = await ReceiveAndAssertMessages(
                    client,
                    scope.TopicName,
                    scope.SubscriptionNames.First(),
                    expectedOrders);
                foreach (var message in receivedMessages)
                {
                    Assert.That(message.ApplicationProperties["priority"], Is.EqualTo("high"), "Priority of the receivedMessage is different than expected");
                }
            }
        }

        [Test]
        public async Task SqlRuleFilterOnTheMessageProperties()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);

                ServiceBusRuleManager ruleManager = client.CreateRuleManager(scope.TopicName, scope.SubscriptionNames.First());

                IEnumerable<RuleProperties> rulesProperties = await GetAllRulesAsync(ruleManager);
                Assert.That(rulesProperties.Count(), Is.EqualTo(1));
                Assert.That(rulesProperties.First().Name, Is.EqualTo(RuleProperties.DefaultRuleName));

                await ruleManager.DeleteRuleAsync(RuleProperties.DefaultRuleName);

                await ruleManager.CreateRuleAsync(new CreateRuleOptions
                {
                    Filter = new SqlRuleFilter("sys.Label = 'yellow'"),
                    Name = "SqlMsgPropertyRule"
                });
                ;

                rulesProperties = await GetAllRulesAsync(ruleManager);
                Assert.That(rulesProperties.Count(), Is.EqualTo(1));
                Assert.That(rulesProperties.First().Name, Is.EqualTo("SqlMsgPropertyRule"));

                await SendMessages(client, scope.TopicName);

                var expectedOrders = Orders.Where(c => c.Color == "yellow").ToList();
                await ReceiveAndAssertMessages(
                    client,
                    scope.TopicName,
                    scope.SubscriptionNames.First(),
                    expectedOrders);
            }
        }

        [Test]
        public async Task SqlRuleFilterOnTheUserProperties()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);

                ServiceBusRuleManager ruleManager = client.CreateRuleManager(scope.TopicName, scope.SubscriptionNames.First());

                IEnumerable<RuleProperties> rulesProperties = await GetAllRulesAsync(ruleManager);
                Assert.That(rulesProperties.Count(), Is.EqualTo(1));
                Assert.That(rulesProperties.First().Name, Is.EqualTo(RuleProperties.DefaultRuleName));

                await ruleManager.DeleteRuleAsync(RuleProperties.DefaultRuleName);

                await ruleManager.CreateRuleAsync(new CreateRuleOptions
                {
                    Filter = new SqlRuleFilter("Color = 'yellow'"),
                    Name = "SqlUserPropertyRule"
                });

                rulesProperties = await GetAllRulesAsync(ruleManager);
                Assert.That(rulesProperties.Count(), Is.EqualTo(1));
                Assert.That(rulesProperties.First().Name, Is.EqualTo("SqlUserPropertyRule"));

                await SendMessages(client, scope.TopicName);

                var expectedOrders = Orders.Where(c => c.Color == "yellow").ToList();
                await ReceiveAndAssertMessages(
                    client,
                    scope.TopicName,
                    scope.SubscriptionNames.First(),
                    expectedOrders);
            }
        }

        [Test]
        public async Task SqlRuleFilterWithAction()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);

                ServiceBusRuleManager ruleManager = client.CreateRuleManager(scope.TopicName, scope.SubscriptionNames.First());

                IEnumerable<RuleProperties> rulesProperties = await GetAllRulesAsync(ruleManager);
                Assert.That(rulesProperties.Count(), Is.EqualTo(1));
                Assert.That(rulesProperties.First().Name, Is.EqualTo(RuleProperties.DefaultRuleName));

                await ruleManager.DeleteRuleAsync(RuleProperties.DefaultRuleName);

                await ruleManager.CreateRuleAsync(new CreateRuleOptions
                {
                    Filter = new SqlRuleFilter("Color = 'blue'"),
                    Action = new SqlRuleAction("SET Priority = 'high'"),
                    Name = "SqlRuleWithAction"
                });

                rulesProperties = await GetAllRulesAsync(ruleManager);
                Assert.That(rulesProperties.Count(), Is.EqualTo(1));
                Assert.That(rulesProperties.First().Name, Is.EqualTo("SqlRuleWithAction"));

                await SendMessages(client, scope.TopicName);

                var expectedOrders = Orders.Where(c => c.Color == "blue").ToList();
                var receivedMessages = await ReceiveAndAssertMessages(
                    client,
                    scope.TopicName,
                    scope.SubscriptionNames.First(),
                    expectedOrders);
                foreach (var message in receivedMessages)
                {
                    Assert.That(message.ApplicationProperties["priority"], Is.EqualTo("high"), "Priority of the receivedMessage is different than expected");
                }
            }
        }

        [Test]
        public async Task SqlRuleFilterUsingANDOperator()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);

                ServiceBusRuleManager ruleManager = client.CreateRuleManager(scope.TopicName, scope.SubscriptionNames.First());

                IEnumerable<RuleProperties> rulesProperties = await GetAllRulesAsync(ruleManager);
                Assert.That(rulesProperties.Count(), Is.EqualTo(1));
                Assert.That(rulesProperties.First().Name, Is.EqualTo(RuleProperties.DefaultRuleName));

                await ruleManager.DeleteRuleAsync(RuleProperties.DefaultRuleName);

                await ruleManager.CreateRuleAsync(new CreateRuleOptions
                {
                    Filter = new SqlRuleFilter("Color = 'blue' and Quantity = 10"),
                    Name = "SqlRuleUsingOperator"
                });

                rulesProperties = await GetAllRulesAsync(ruleManager);
                Assert.That(rulesProperties.Count(), Is.EqualTo(1));
                Assert.That(rulesProperties.First().Name, Is.EqualTo("SqlRuleUsingOperator"));

                await SendMessages(client, scope.TopicName);

                var expectedOrders = Orders.Where(c => c.Color == "blue" && c.Quantity == 10).ToList();
                await ReceiveAndAssertMessages(
                    client,
                    scope.TopicName,
                    scope.SubscriptionNames.First(),
                    expectedOrders);
            }
        }

        [Test]
        public async Task SqlRuleFilterUsingOROperator()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);

                ServiceBusRuleManager ruleManager = client.CreateRuleManager(scope.TopicName, scope.SubscriptionNames.First());

                IEnumerable<RuleProperties> rulesProperties = await GetAllRulesAsync(ruleManager);
                Assert.That(rulesProperties.Count(), Is.EqualTo(1));
                Assert.That(rulesProperties.First().Name, Is.EqualTo(RuleProperties.DefaultRuleName));

                await ruleManager.DeleteRuleAsync(RuleProperties.DefaultRuleName);

                await ruleManager.CreateRuleAsync(new CreateRuleOptions
                {
                    Filter = new SqlRuleFilter("Color = 'blue' or Quantity = 10"),
                    Name = "SqlRuleUsingOperator"
                });

                rulesProperties = await GetAllRulesAsync(ruleManager);
                Assert.That(rulesProperties.Count(), Is.EqualTo(1));
                Assert.That(rulesProperties.First().Name, Is.EqualTo("SqlRuleUsingOperator"));

                await SendMessages(client, scope.TopicName);

                var expectedOrders = Orders.Where(c => c.Color == "blue" || c.Quantity == 10).ToList();
                await ReceiveAndAssertMessages(
                    client,
                    scope.TopicName,
                    scope.SubscriptionNames.First(),
                    expectedOrders);
            }
        }

        [Test]
        [TestCase(100)]
        [TestCase(150)]
        [TestCase(200)]
        [TestCase(201)]
        public async Task ManyRulesOnSubscription(int count)
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);

                ServiceBusRuleManager ruleManager = client.CreateRuleManager(scope.TopicName, scope.SubscriptionNames.First());

                List<RuleProperties> rulesProperties = await GetAllRulesAsync(ruleManager);
                Assert.That(rulesProperties.Count(), Is.EqualTo(1));
                Assert.That(rulesProperties.First().Name, Is.EqualTo(RuleProperties.DefaultRuleName));

                await ruleManager.DeleteRuleAsync(RuleProperties.DefaultRuleName);
                List<string> ruleNames = new();
                for (int i = 0; i < count; i++)
                {
                    var ruleName = $"CorrelationUserPropertyRule-{i}";
                    ruleNames.Add(ruleName);
                    await ruleManager.CreateRuleAsync(new CreateRuleOptions
                    {
                        Filter = new CorrelationRuleFilter { ApplicationProperties = { { "color", "red" } } },
                        Name = ruleName
                    });
                }

                ruleNames.Sort();
                rulesProperties = await GetAllRulesAsync(ruleManager);
                Assert.That(rulesProperties.Count, Is.EqualTo(count));

                // the rules are returned in name order
                for (int i = 0; i < count; i++)
                {
                    Assert.That(rulesProperties[i].Name, Is.EqualTo(ruleNames[i]));
                }

                await SendMessages(client, scope.TopicName);

                var expectedOrders = Orders.Where(c => c.Color == "red").ToList();
                await ReceiveAndAssertMessages(
                    client,
                    scope.TopicName,
                    scope.SubscriptionNames.First(),
                    expectedOrders);
            }
        }

        private Order[] Orders = new[]
            {
                new Order { Color = "blue", Quantity = 5, Priority = "low" },
                new Order { Color = "red", Quantity = 10, Priority = "high" },
                new Order { Color = "yellow", Quantity = 5, Priority = "low" },
                new Order { Color = "blue", Quantity = 10, Priority = "low" },
                new Order { Color = "blue", Quantity = 5, Priority = "high" },
                new Order { Color = "blue", Quantity = 10, Priority = "low" },
                new Order { Color = "red", Quantity = 5, Priority = "low" },
                new Order { Color = "red", Quantity = 10, Priority = "low" },
                new Order { Color = "red", Quantity = 5, Priority = "low" },
                new Order { Color = "yellow", Quantity = 10, Priority = "high" },
                new Order { Color = "yellow", Quantity = 5, Priority = "low" },
                new Order { Color = "yellow", Quantity = 10, Priority = "low" }
            };

        private async Task SendMessages(ServiceBusClient client, string topicName)
        {
            ServiceBusSender sender = client.CreateSender(topicName);

            for (int i = 0; i < Orders.Length; i++)
            {
                var message = new ServiceBusMessage(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(Orders[i])))
                {
                    CorrelationId = Orders[i].Priority,
                    Subject = Orders[i].Color,
                    ApplicationProperties =
                {
                    { "color", Orders[i].Color },
                    { "quantity", Orders[i].Quantity },
                    { "priority", Orders[i].Priority }
                }
                };
                await sender.SendMessageAsync(message);
            }
        }

        private async Task<IList<ServiceBusReceivedMessage>> ReceiveAndAssertMessages(
            ServiceBusClient client,
            string topicName,
            string subscriptionName,
            IEnumerable<Order> expectedOrders)
        {
            var receiver = client.CreateReceiver(topicName, subscriptionName);
            var receivedMessages = new List<ServiceBusReceivedMessage>();
            var messageEnum = expectedOrders.GetEnumerator();
            var remainingMessages = expectedOrders.Count();
            while (remainingMessages > 0)
            {
                var item = await receiver.ReceiveMessageAsync();
                receivedMessages.Add(item);
                messageEnum.MoveNext();
                Assert.That(item.Subject, Is.EqualTo(messageEnum.Current.Color));
                remainingMessages--;
            }
            Assert.That(remainingMessages, Is.EqualTo(0));

            return receivedMessages;
        }

        private class Order
        {
            public string Color { get; set; }

            public int Quantity { get; set; }

            public string Priority { get; set; }
        }
    }
}
