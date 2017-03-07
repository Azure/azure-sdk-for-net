// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Filters;
    using Xunit;

    public sealed class SubscriptionClientTests : SenderReceiverClientTestBase
    {
        public static IEnumerable<object> TestPermutations => new object[]
        {
            new object[] { Constants.NonPartitionedTopicName },
            new object[] { Constants.PartitionedTopicName }
        };

        string SubscriptionName => Constants.SubscriptionName;

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task CorrelationFilterTestCase(string topicName, int messageCount = 10)
        {
            var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
            var subscriptionClient = new SubscriptionClient(
                TestUtility.NamespaceConnectionString,
                topicName,
                this.SubscriptionName,
                ReceiveMode.ReceiveAndDelete);

            try
            {
                try
                {
                    await subscriptionClient.RemoveRuleAsync(SubscriptionClient.DefaultRule);
                }
                catch
                {
                    // ignored
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
                Assert.True(messageId2.Equals(messages.First().MessageId));
            }
            finally
            {
                await subscriptionClient.RemoveRuleAsync("RedCorrelation");
                await subscriptionClient.AddRuleAsync(SubscriptionClient.DefaultRule, new TrueFilter());
                await subscriptionClient.CloseAsync();
                await topicClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task SqlFilterTestCase(string topicName, int messageCount = 10)
        {
            var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
            var subscriptionClient = new SubscriptionClient(
                TestUtility.NamespaceConnectionString,
                topicName,
                this.SubscriptionName,
                ReceiveMode.ReceiveAndDelete);

            try
            {
                try
                {
                    await subscriptionClient.RemoveRuleAsync(SubscriptionClient.DefaultRule);
                }
                catch
                {
                    // ignored
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
                    Properties = { { "color", "BlueSql" } }
                });
                TestUtility.Log($"Sent Message: {messageId1}");

                var messageId2 = Guid.NewGuid().ToString();
                await topicClient.SendAsync(new Message
                {
                    MessageId = messageId2,
                    Label = "RedSql",
                    Properties = { { "color", "RedSql" } }
                });
                TestUtility.Log($"Sent Message: {messageId2}");

                var messages = await subscriptionClient.InnerSubscriptionClient.InnerReceiver.ReceiveAsync(maxMessageCount: 2);
                Assert.NotNull(messages);
                Assert.True(messages.Count == 1);
                Assert.True(messageId2.Equals(messages.First().MessageId));
            }
            finally
            {
                await subscriptionClient.RemoveRuleAsync("RedSql");
                await subscriptionClient.AddRuleAsync(SubscriptionClient.DefaultRule, new TrueFilter());
                await subscriptionClient.CloseAsync();
                await topicClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task SqlActionTestCase(string topicName, int messageCount = 10)
        {
            var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
            var subscriptionClient = new SubscriptionClient(
                TestUtility.NamespaceConnectionString,
                topicName,
                this.SubscriptionName,
                ReceiveMode.ReceiveAndDelete);

            try
            {
                try
                {
                    await subscriptionClient.RemoveRuleAsync(SubscriptionClient.DefaultRule);
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
                    Properties = { { "color", "BlueSqlAction" } }
                });
                TestUtility.Log($"Sent Message: {messageId1}");

                var messageId2 = Guid.NewGuid().ToString();
                await topicClient.SendAsync(new Message
                {
                    MessageId = messageId2,
                    Label = "RedSqlAction",
                    Properties = { { "color", "RedSqlAction" } }
                });
                TestUtility.Log($"Sent Message: {messageId2}");

                var messages = await subscriptionClient.InnerSubscriptionClient.InnerReceiver.ReceiveAsync(maxMessageCount: 2);
                Assert.NotNull(messages);
                Assert.True(messages.Count == 1);
                Assert.True(messageId2.Equals(messages.First().MessageId));
                Assert.True(messages.First().Properties["Color"].Equals("RedSqlActionProcessed"));
            }
            finally
            {
                await subscriptionClient.RemoveRuleAsync("RedSqlAction");
                await subscriptionClient.AddRuleAsync(SubscriptionClient.DefaultRule, new TrueFilter());
                await subscriptionClient.CloseAsync();
                await topicClient.CloseAsync();
            }
        }
    }
}