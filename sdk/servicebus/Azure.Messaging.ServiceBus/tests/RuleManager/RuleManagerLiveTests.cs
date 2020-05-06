// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus.Filters;
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
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusRuleManager ruleManager = client.CreateRuleManager(scope.TopicName, scope.SubscriptionNames.First());
                var sqlRuleName = "sqlRule";
                var correlationRuleName = "correlationRule";

                var rules = (await ruleManager.GetRulesAsync()).ToList();
                Assert.AreEqual(1, rules.Count());
                var firstRule = rules[0];
                Assert.AreEqual(RuleDescription.DefaultRuleName, firstRule.Name);
                Assert.Null(firstRule.Action);

                await ruleManager.AddRuleAsync(sqlRuleName, new SqlFilter("price > 10"));

                var ruleDescription = new RuleDescription(correlationRuleName)
                {
                    Filter = new CorrelationFilter
                    {
                        CorrelationId = "correlationId",
                        Label = "label",
                        MessageId = "messageId",
                        Properties =
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
                await ruleManager.AddRuleAsync(ruleDescription);

                rules = (await ruleManager.GetRulesAsync()).ToList();
                Assert.AreEqual(3, rules.Count);

                var sqlRule = rules.FirstOrDefault(rule => rule.Name.Equals(sqlRuleName));
                Assert.NotNull(sqlRule);
                Assert.Null(sqlRule.Action);
                Assert.IsInstanceOf<SqlFilter>(sqlRule.Filter);
                Assert.AreEqual("price > 10", ((SqlFilter)sqlRule.Filter).SqlExpression);

                var correlationRule = rules.FirstOrDefault(rule => rule.Name.Equals(correlationRuleName));
                Assert.NotNull(correlationRule);
                Assert.IsInstanceOf<SqlRuleAction>(correlationRule.Action);
                var sqlRuleAction = correlationRule.Action as SqlRuleAction;
                Assert.NotNull(sqlRuleAction);
                Assert.AreEqual("Set CorrelationId = 'newValue'", sqlRuleAction.SqlExpression);
                Assert.IsInstanceOf<CorrelationFilter>(correlationRule.Filter);
                var correlationFilter = correlationRule.Filter as CorrelationFilter;
                Assert.NotNull(correlationFilter);
                Assert.AreEqual("correlationId", correlationFilter.CorrelationId);
                Assert.AreEqual("label", correlationFilter.Label);
                Assert.AreEqual("messageId", correlationFilter.MessageId);
                Assert.AreEqual("replyTo", correlationFilter.ReplyTo);
                Assert.AreEqual("replyToSessionId", correlationFilter.ReplyToSessionId);
                Assert.AreEqual("sessionId", correlationFilter.SessionId);
                Assert.AreEqual("to", correlationFilter.To);
                Assert.NotNull(correlationFilter.Properties);
                Assert.AreEqual("value1", correlationFilter.Properties["key1"]);

                await ruleManager.RemoveRuleAsync(RuleDescription.DefaultRuleName);
                await ruleManager.RemoveRuleAsync(sqlRuleName);
                await ruleManager.RemoveRuleAsync(correlationRuleName);
                rules = (await ruleManager.GetRulesAsync()).ToList();
                Assert.AreEqual(0, rules.Count());
            }
        }

        [Test]
        public async Task ThrowIfAddSameRuleNameTwice()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusRuleManager ruleManager = client.CreateRuleManager(scope.TopicName, scope.SubscriptionNames.First());

                await ruleManager.AddRuleAsync(new RuleDescription
                {
                    Filter = new CorrelationFilter { Label = "yellow" },
                    Name = "CorrelationFilter"
                });

                Assert.That(async () => await ruleManager.AddRuleAsync(new RuleDescription
                {
                    Filter = new CorrelationFilter { Label = "red" },
                    Name = "CorrelationFilter"
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
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusRuleManager ruleManager = client.CreateRuleManager(scope.TopicName, scope.SubscriptionNames.First());

                IEnumerable<RuleDescription> rulesDescription = await ruleManager.GetRulesAsync();
                Assert.AreEqual(1, rulesDescription.Count());
                Assert.AreEqual(RuleDescription.DefaultRuleName, rulesDescription.First().Name);

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
        public async Task TrueFilter()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusRuleManager ruleManager = client.CreateRuleManager(scope.TopicName, scope.SubscriptionNames.First());
                IEnumerable<RuleDescription> rulesDescription;

                rulesDescription = await ruleManager.GetRulesAsync();
                Assert.AreEqual(1, rulesDescription.Count());
                Assert.AreEqual(RuleDescription.DefaultRuleName, rulesDescription.First().Name);

                await ruleManager.RemoveRuleAsync(RuleDescription.DefaultRuleName);

                await ruleManager.AddRuleAsync(new RuleDescription
                {
                    Filter = new TrueFilter(),
                    Name = "BooleanFilter"
                });

                rulesDescription = await ruleManager.GetRulesAsync();
                Assert.True(rulesDescription.Count() == 1);
                Assert.AreEqual("BooleanFilter", rulesDescription.First().Name);

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
        public async Task FalseFilter()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusRuleManager ruleManager = client.CreateRuleManager(scope.TopicName, scope.SubscriptionNames.First());

                IEnumerable<RuleDescription> rulesDescription = await ruleManager.GetRulesAsync();
                Assert.AreEqual(1, rulesDescription.Count());
                Assert.AreEqual(RuleDescription.DefaultRuleName, rulesDescription.First().Name);

                await ruleManager.RemoveRuleAsync(RuleDescription.DefaultRuleName);

                await ruleManager.AddRuleAsync(new RuleDescription
                {
                    Filter = new FalseFilter(),
                    Name = "BooleanFilter"
                });

                rulesDescription = await ruleManager.GetRulesAsync();
                Assert.AreEqual(1, rulesDescription.Count());
                Assert.AreEqual("BooleanFilter", rulesDescription.First().Name);

                await SendMessages(client, scope.TopicName);

                var receiver = client.CreateReceiver(scope.TopicName, scope.SubscriptionNames.First());
                var messages = await receiver.ReceiveBatchAsync(Orders.Length, TimeSpan.FromSeconds(10));
                Assert.AreEqual(0, messages.Count());
            }
        }

        [Test]
        public async Task CorrelationFilterOnTheMessageProperties()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusRuleManager ruleManager = client.CreateRuleManager(scope.TopicName, scope.SubscriptionNames.First());

                IEnumerable<RuleDescription> rulesDescription = await ruleManager.GetRulesAsync();
                Assert.AreEqual(1, rulesDescription.Count());

                Assert.AreEqual(RuleDescription.DefaultRuleName, rulesDescription.First().Name);

                await ruleManager.RemoveRuleAsync(RuleDescription.DefaultRuleName);

                await ruleManager.AddRuleAsync(new RuleDescription
                {
                    Filter = new CorrelationFilter { Label = "red" },
                    Name = "CorrelationMsgPropertyRule"
                });

                rulesDescription = await ruleManager.GetRulesAsync();
                Assert.AreEqual(1, rulesDescription.Count());
                Assert.AreEqual("CorrelationMsgPropertyRule", rulesDescription.First().Name);

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
        public async Task CorrelationFilterOnTheUserProperties()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusRuleManager ruleManager = client.CreateRuleManager(scope.TopicName, scope.SubscriptionNames.First());

                IEnumerable<RuleDescription> rulesDescription = await ruleManager.GetRulesAsync();
                Assert.AreEqual(1, rulesDescription.Count());
                Assert.AreEqual(RuleDescription.DefaultRuleName, rulesDescription.First().Name);

                await ruleManager.RemoveRuleAsync(RuleDescription.DefaultRuleName);

                await ruleManager.AddRuleAsync(new RuleDescription
                {
                    Filter = new CorrelationFilter { Properties = { { "color", "red" } } },
                    Name = "CorrelationUserPropertyRule"
                });

                rulesDescription = await ruleManager.GetRulesAsync();
                Assert.AreEqual(1, rulesDescription.Count());
                Assert.AreEqual("CorrelationUserPropertyRule", rulesDescription.First().Name);

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
        public async Task CorrelationFilterWithSqlAction()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusRuleManager ruleManager = client.CreateRuleManager(scope.TopicName, scope.SubscriptionNames.First());

                IEnumerable<RuleDescription> rulesDescription = await ruleManager.GetRulesAsync();
                Assert.AreEqual(1, rulesDescription.Count());
                Assert.AreEqual(RuleDescription.DefaultRuleName, rulesDescription.First().Name);

                await ruleManager.RemoveRuleAsync(RuleDescription.DefaultRuleName);

                await ruleManager.AddRuleAsync(new RuleDescription
                {
                    Filter = new CorrelationFilter { Properties = { { "Color", "blue" } } },
                    Action = new SqlRuleAction("Set Priority = 'high'"),
                    Name = "CorrelationRuleWithAction"
                });

                rulesDescription = await ruleManager.GetRulesAsync();
                Assert.AreEqual(1, rulesDescription.Count());
                Assert.AreEqual("CorrelationRuleWithAction", rulesDescription.First().Name);

                await SendMessages(client, scope.TopicName);

                var expectedOrders = Orders.Where(c => c.Color == "blue").ToList();
                var receivedMessages = await ReceiveAndAssertMessages(
                    client,
                    scope.TopicName,
                    scope.SubscriptionNames.First(),
                    expectedOrders);
                foreach (var message in receivedMessages)
                {
                    Assert.AreEqual("high", message.Properties["priority"], "Priority of the receivedMessage is different than expected");
                }
            }
        }

        [Test]
        public async Task SqlFilterOnTheMessageProperties()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusRuleManager ruleManager = client.CreateRuleManager(scope.TopicName, scope.SubscriptionNames.First());

                IEnumerable<RuleDescription> rulesDescription = await ruleManager.GetRulesAsync();
                Assert.AreEqual(1, rulesDescription.Count());
                Assert.AreEqual(RuleDescription.DefaultRuleName, rulesDescription.First().Name);

                await ruleManager.RemoveRuleAsync(RuleDescription.DefaultRuleName);

                await ruleManager.AddRuleAsync(new RuleDescription
                {
                    Filter = new SqlFilter("sys.Label = 'yellow'"),
                    Name = "SqlMsgPropertyRule"
                });
                ;

                rulesDescription = await ruleManager.GetRulesAsync();
                Assert.AreEqual(1, rulesDescription.Count());
                Assert.AreEqual("SqlMsgPropertyRule", rulesDescription.First().Name);

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
        public async Task SqlFilterOnTheUserProperties()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusRuleManager ruleManager = client.CreateRuleManager(scope.TopicName, scope.SubscriptionNames.First());

                IEnumerable<RuleDescription> rulesDescription = await ruleManager.GetRulesAsync();
                Assert.AreEqual(1, rulesDescription.Count());
                Assert.AreEqual(RuleDescription.DefaultRuleName, rulesDescription.First().Name);

                await ruleManager.RemoveRuleAsync(RuleDescription.DefaultRuleName);

                await ruleManager.AddRuleAsync(new RuleDescription
                {
                    Filter = new SqlFilter("Color = 'yellow'"),
                    Name = "SqlUserPropertyRule"
                });

                rulesDescription = await ruleManager.GetRulesAsync();
                Assert.AreEqual(1, rulesDescription.Count());
                Assert.AreEqual("SqlUserPropertyRule", rulesDescription.First().Name);

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
        public async Task SqlFilterWithAction()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusRuleManager ruleManager = client.CreateRuleManager(scope.TopicName, scope.SubscriptionNames.First());

                IEnumerable<RuleDescription> rulesDescription = await ruleManager.GetRulesAsync();
                Assert.AreEqual(1, rulesDescription.Count());
                Assert.AreEqual(RuleDescription.DefaultRuleName, rulesDescription.First().Name);

                await ruleManager.RemoveRuleAsync(RuleDescription.DefaultRuleName);

                await ruleManager.AddRuleAsync(new RuleDescription
                {
                    Filter = new SqlFilter("Color = 'blue'"),
                    Action = new SqlRuleAction("SET Priority = 'high'"),
                    Name = "SqlRuleWithAction"
                });

                rulesDescription = await ruleManager.GetRulesAsync();
                Assert.AreEqual(1, rulesDescription.Count());
                Assert.AreEqual("SqlRuleWithAction", rulesDescription.First().Name);

                await SendMessages(client, scope.TopicName);

                var expectedOrders = Orders.Where(c => c.Color == "blue").ToList();
                var receivedMessages = await ReceiveAndAssertMessages(
                    client,
                    scope.TopicName,
                    scope.SubscriptionNames.First(),
                    expectedOrders);
                foreach (var message in receivedMessages)
                {
                    Assert.AreEqual("high", message.Properties["priority"], "Priority of the receivedMessage is different than expected");
                }
            }
        }

        [Test]
        public async Task SqlFilterUsingANDOperator()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusRuleManager ruleManager = client.CreateRuleManager(scope.TopicName, scope.SubscriptionNames.First());

                IEnumerable<RuleDescription> rulesDescription = await ruleManager.GetRulesAsync();
                Assert.AreEqual(1, rulesDescription.Count());
                Assert.AreEqual(RuleDescription.DefaultRuleName, rulesDescription.First().Name);

                await ruleManager.RemoveRuleAsync(RuleDescription.DefaultRuleName);

                await ruleManager.AddRuleAsync(new RuleDescription
                {
                    Filter = new SqlFilter("Color = 'blue' and Quantity = 10"),
                    Name = "SqlRuleUsingOperator"
                });

                rulesDescription = await ruleManager.GetRulesAsync();
                Assert.AreEqual(1, rulesDescription.Count());
                Assert.AreEqual("SqlRuleUsingOperator", rulesDescription.First().Name);

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
        public async Task SqlFilterUsingOROperator()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                ServiceBusRuleManager ruleManager = client.CreateRuleManager(scope.TopicName, scope.SubscriptionNames.First());

                IEnumerable<RuleDescription> rulesDescription = await ruleManager.GetRulesAsync();
                Assert.AreEqual(1, rulesDescription.Count());
                Assert.AreEqual(RuleDescription.DefaultRuleName, rulesDescription.First().Name);

                await ruleManager.RemoveRuleAsync(RuleDescription.DefaultRuleName);

                await ruleManager.AddRuleAsync(new RuleDescription
                {
                    Filter = new SqlFilter("Color = 'blue' or Quantity = 10"),
                    Name = "SqlRuleUsingOperator"
                });

                rulesDescription = await ruleManager.GetRulesAsync();
                Assert.AreEqual(1, rulesDescription.Count());
                Assert.AreEqual("SqlRuleUsingOperator", rulesDescription.First().Name);

                await SendMessages(client, scope.TopicName);

                var expectedOrders = Orders.Where(c => c.Color == "blue" || c.Quantity == 10).ToList();
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
                    Label = Orders[i].Color,
                    Properties =
                {
                    { "color", Orders[i].Color },
                    { "quantity", Orders[i].Quantity },
                    { "priority", Orders[i].Priority }
                }
                };
                await sender.SendAsync(message);
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
                foreach (var item in await receiver.ReceiveBatchAsync(Orders.Length).ConfigureAwait(false))
                {
                    receivedMessages.Add(item);
                    messageEnum.MoveNext();
                    Assert.AreEqual(messageEnum.Current.Color, item.Label);
                    remainingMessages--;
                }
            }
            Assert.AreEqual(0, remainingMessages);

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
