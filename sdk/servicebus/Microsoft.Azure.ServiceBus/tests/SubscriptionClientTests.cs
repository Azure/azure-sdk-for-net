// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class SubscriptionClientTests : SenderReceiverClientTestBase
    {
        public static IEnumerable<object[]> TestPermutations => new object[][]
        {
            // Expected structure: { usePartitionedTopic, useSessionTopic }
            new object[] { false, false },
            new object[] { true, false }
        };

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task CorrelationFilterTestCase(bool partitioned, bool sessionEnabled)
        {
            await ServiceBusScope.UsingTopicAsync(partitioned, sessionEnabled, async (topicName, subscriptionName) =>
            {
                var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
                var subscriptionClient = new SubscriptionClient(
                    TestUtility.NamespaceConnectionString,
                    topicName,
                    subscriptionName,
                    ReceiveMode.ReceiveAndDelete);

                try
                {
                    try
                    {
                        await subscriptionClient.RemoveRuleAsync(RuleDescription.DefaultRuleName);
                    }
                    catch (Exception e)
                    {
                        TestUtility.Log($"Remove Default Rule failed with Exception: {e.Message}");
                    }

                    await subscriptionClient.AddRuleAsync(new RuleDescription
                    {
                        Filter = new CorrelationFilter { Label = "Red" },
                        Name = "RedCorrelation"
                    });

                    var messageId1 = Guid.NewGuid().ToString();
                    await topicClient.SendAsync(new Message { MessageId = messageId1, Label = "Blue" });
                    TestUtility.Log($"Sent Message: {messageId1}");

                    var messageId2 = Guid.NewGuid().ToString();
                    await topicClient.SendAsync(new Message { MessageId = messageId2, Label = "Red" });
                    TestUtility.Log($"Sent Message: {messageId2}");

                    var messages = await subscriptionClient.InnerSubscriptionClient.InnerReceiver.ReceiveAsync(maxMessageCount: 2);
                    Assert.NotNull(messages);
                    Assert.True(messages.Count == 1);
                    Assert.Equal(messageId2, messages.First().MessageId);
                }
                finally
                {
                    try
                    {
                        await subscriptionClient.RemoveRuleAsync("RedCorrelation");
                        await subscriptionClient.AddRuleAsync(RuleDescription.DefaultRuleName, new TrueFilter());
                    }
                    catch (Exception e)
                    {
                        TestUtility.Log($" Cleanup failed with Exception: {e.Message}");
                    }

                    await subscriptionClient.CloseAsync();
                    await topicClient.CloseAsync();
                }
            });
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task SqlFilterTestCase(bool partitioned, bool sessionEnabled)
        {
            await ServiceBusScope.UsingTopicAsync(partitioned, sessionEnabled, async (topicName, subscriptionName) =>
            {
                var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
                var subscriptionClient = new SubscriptionClient(
                    TestUtility.NamespaceConnectionString,
                    topicName,
                    subscriptionName,
                    ReceiveMode.ReceiveAndDelete);

                try
                {
                    try
                    {
                        await subscriptionClient.RemoveRuleAsync(RuleDescription.DefaultRuleName);
                    }
                    catch(Exception e)
                    {
                        TestUtility.Log($"Remove Default Rule failed with: {e.Message}");
                    }

                    await subscriptionClient.AddRuleAsync(new RuleDescription
                    {
                        Filter = new SqlFilter("Color = 'RedSql'"),
                        Name = "RedSql"
                    });

                    var messageId1 = Guid.NewGuid().ToString();
                    await topicClient.SendAsync(new Message
                    {
                        MessageId = messageId1,
                        Label = "BlueSql",
                        UserProperties = { { "color", "BlueSql" } }
                    });
                    TestUtility.Log($"Sent Message: {messageId1}");

                    var messageId2 = Guid.NewGuid().ToString();
                    await topicClient.SendAsync(new Message
                    {
                        MessageId = messageId2,
                        Label = "RedSql",
                        UserProperties = { { "color", "RedSql" } }
                    });
                    TestUtility.Log($"Sent Message: {messageId2}");

                    var messages = await subscriptionClient.InnerSubscriptionClient.InnerReceiver.ReceiveAsync(maxMessageCount: 2);
                    Assert.NotNull(messages);
                    Assert.True(messages.Count == 1);
                    Assert.Equal(messageId2, messages.First().MessageId);
                }
                finally
                {
                    try
                    {
                        await subscriptionClient.RemoveRuleAsync("RedSql");
                        await subscriptionClient.AddRuleAsync(RuleDescription.DefaultRuleName, new TrueFilter());
                    }
                    catch (Exception e)
                    {
                        TestUtility.Log($" Cleanup failed with Exception: {e.Message}");
                    }

                    await subscriptionClient.CloseAsync();
                    await topicClient.CloseAsync();
                }
            });
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task SqlActionTestCase(bool partitioned, bool sessionEnabled)
        {
            await ServiceBusScope.UsingTopicAsync(partitioned, sessionEnabled, async (topicName, subscriptionName) =>
            {
                var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
                var subscriptionClient = new SubscriptionClient(
                    TestUtility.NamespaceConnectionString,
                    topicName,
                    subscriptionName,
                    ReceiveMode.ReceiveAndDelete);

                try
                {
                    try
                    {
                        await subscriptionClient.RemoveRuleAsync(RuleDescription.DefaultRuleName);
                    }
                    catch
                    {
                        // ignored
                    }

                    await subscriptionClient.AddRuleAsync(new RuleDescription
                    {
                        Filter = new SqlFilter("Color = 'RedSqlAction'"),
                        Action = new SqlRuleAction("SET Color = 'RedSqlActionProcessed'"),
                        Name = "RedSqlAction"
                    });

                    var messageId1 = Guid.NewGuid().ToString();
                    await topicClient.SendAsync(new Message
                    {
                        MessageId = messageId1,
                        Label = "BlueSqlAction",
                        UserProperties = { { "color", "BlueSqlAction" } }
                    });
                    TestUtility.Log($"Sent Message: {messageId1}");

                    var messageId2 = Guid.NewGuid().ToString();
                    await topicClient.SendAsync(new Message
                    {
                        MessageId = messageId2,
                        Label = "RedSqlAction",
                        UserProperties = { { "color", "RedSqlAction" } }
                    });
                    TestUtility.Log($"Sent Message: {messageId2}");

                    var messages = await subscriptionClient.InnerSubscriptionClient.InnerReceiver.ReceiveAsync(maxMessageCount: 2);
                    Assert.NotNull(messages);
                    Assert.True(messages.Count == 1);
                    Assert.Equal(messageId2, messages.First().MessageId);
                    Assert.True(messages.First().UserProperties["color"].Equals("RedSqlActionProcessed"));
                }
                finally
                {
                    await subscriptionClient.RemoveRuleAsync("RedSqlAction");
                    await subscriptionClient.AddRuleAsync(RuleDescription.DefaultRuleName, new TrueFilter());
                    await subscriptionClient.CloseAsync();
                    await topicClient.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task GetRulesTestCase()
        {
            await ServiceBusScope.UsingTopicAsync(partitioned: false, sessionEnabled: false, async (topicName, subscriptionName) =>
            {
                var subscriptionClient = new SubscriptionClient(
                    TestUtility.NamespaceConnectionString,
                    topicName,
                    subscriptionName,
                    ReceiveMode.ReceiveAndDelete);
                var sqlRuleName = "sqlRule";
                var correlationRuleName = "correlationRule";

                try
                {
                    var rules = (await subscriptionClient.GetRulesAsync()).ToList();
                    Assert.Single(rules);
                    var firstRule = rules[0];
                    Assert.Equal(RuleDescription.DefaultRuleName, firstRule.Name);
                    Assert.IsAssignableFrom<SqlFilter>(firstRule.Filter);
                    Assert.Null(firstRule.Action);

                    await subscriptionClient.AddRuleAsync(sqlRuleName, new SqlFilter("price > 10"));

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
                    await subscriptionClient.AddRuleAsync(ruleDescription);

                    rules = (await subscriptionClient.GetRulesAsync()).ToList();
                    Assert.Equal(3, rules.Count);

                    var sqlRule = rules.FirstOrDefault(rule => rule.Name.Equals(sqlRuleName));
                    Assert.NotNull(sqlRule);
                    Assert.Null(sqlRule.Action);
                    Assert.IsType<SqlFilter>(sqlRule.Filter);
                    Assert.Equal("price > 10", ((SqlFilter) sqlRule.Filter).SqlExpression);

                    var correlationRule = rules.FirstOrDefault(rule => rule.Name.Equals(correlationRuleName));
                    Assert.NotNull(correlationRule);
                    Assert.IsType<SqlRuleAction>(correlationRule.Action);
                    var sqlRuleAction = correlationRule.Action as SqlRuleAction;
                    Assert.NotNull(sqlRuleAction);
                    Assert.Equal("Set CorrelationId = 'newValue'", sqlRuleAction.SqlExpression);
                    Assert.IsType<CorrelationFilter>(correlationRule.Filter);
                    var correlationFilter = correlationRule.Filter as CorrelationFilter;
                    Assert.NotNull(correlationFilter);
                    Assert.Equal("correlationId", correlationFilter.CorrelationId);
                    Assert.Equal("label", correlationFilter.Label);
                    Assert.Equal("messageId", correlationFilter.MessageId);
                    Assert.Equal("replyTo", correlationFilter.ReplyTo);
                    Assert.Equal("replyToSessionId", correlationFilter.ReplyToSessionId);
                    Assert.Equal("sessionId", correlationFilter.SessionId);
                    Assert.Equal("to", correlationFilter.To);
                    Assert.NotNull(correlationFilter.Properties);
                    Assert.Equal("value1", correlationFilter.Properties["key1"]);
                }
                finally
                {
                    // Attempt to cleanup rules that may or may not exist; ignore any exceptions, as they're expected.
                    var _ = Task.WhenAll(
                        subscriptionClient.RemoveRuleAsync(sqlRuleName),
                        subscriptionClient.RemoveRuleAsync(correlationRuleName)).ConfigureAwait(false);

                    await subscriptionClient.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task UpdatingPrefetchCountOnSubscriptionClientUpdatesTheReceiverPrefetchCount()
        {
            await ServiceBusScope.UsingTopicAsync(partitioned: false, sessionEnabled: false, async (topicName, subscriptionName) =>
            {
                var subscriptionClient = new SubscriptionClient(
                    TestUtility.NamespaceConnectionString,
                    topicName,
                    subscriptionName,
                    ReceiveMode.ReceiveAndDelete);

                try
                {
                    Assert.Equal(0, subscriptionClient.PrefetchCount);

                    subscriptionClient.PrefetchCount = 2;
                    Assert.Equal(2, subscriptionClient.PrefetchCount);
                    // Message receiver should be created with latest prefetch count (lazy load).
                    Assert.Equal(2, subscriptionClient.InnerSubscriptionClient.InnerReceiver.PrefetchCount);

                    subscriptionClient.PrefetchCount = 3;
                    Assert.Equal(3, subscriptionClient.PrefetchCount);
                    // Already created message receiver should have its prefetch value updated.
                    Assert.Equal(3, subscriptionClient.InnerSubscriptionClient.InnerReceiver.PrefetchCount);
                }
                finally
                {
                    await subscriptionClient.CloseAsync();
                }
            });
        }
    }
}