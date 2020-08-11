// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests.Diagnostics
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Xunit;

    [Collection(nameof(DiagnosticsTests))]
    public class SubscriptionClientDiagnosticsTests : DiagnosticsTests
    {
        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task AddRemoveGetFireEvents()
        {
            await ServiceBusScope.UsingTopicAsync(partitioned: false, sessionEnabled: false, async (topicName, subscriptionName) =>
            {
                var subscriptionClient = new SubscriptionClient(TestUtility.NamespaceConnectionString, topicName, subscriptionName, ReceiveMode.ReceiveAndDelete);
                var eventQueue = this.CreateEventQueue();
                var entityName = $"{topicName}/Subscriptions/{subscriptionName}";

                try
                {
                    using (var listener = this.CreateEventListener(entityName, eventQueue))
                    using (var subscription = this.SubscribeToEvents(listener))
                    {
                        listener.Enable((name, queue, id) => name.Contains("Rule"));

                        var ruleName = Guid.NewGuid().ToString();
                        await subscriptionClient.AddRuleAsync(ruleName, new TrueFilter());
                        await subscriptionClient.GetRulesAsync();
                        await subscriptionClient.RemoveRuleAsync(ruleName);

                        Assert.True(eventQueue.TryDequeue(out var addRuleStart));
                        AssertAddRuleStart(entityName, addRuleStart.eventName, addRuleStart.payload, addRuleStart.activity);

                        Assert.True(eventQueue.TryDequeue(out var addRuleStop));
                        AssertAddRuleStop(entityName, addRuleStop.eventName, addRuleStop.payload, addRuleStop.activity, addRuleStart.activity);

                        Assert.True(eventQueue.TryDequeue(out var getRulesStart));
                        AssertGetRulesStart(entityName, getRulesStart.eventName, getRulesStart.payload, getRulesStart.activity);

                        Assert.True(eventQueue.TryDequeue(out var getRulesStop));
                        AssertGetRulesStop(entityName, getRulesStop.eventName, getRulesStop.payload, getRulesStop.activity, getRulesStart.activity);

                        Assert.True(eventQueue.TryDequeue(out var removeRuleStart));
                        AssertRemoveRuleStart(entityName, removeRuleStart.eventName, removeRuleStart.payload, removeRuleStart.activity);

                        Assert.True(eventQueue.TryDequeue(out var removeRuleStop));
                        AssertRemoveRuleStop(entityName, removeRuleStop.eventName, removeRuleStop.payload, removeRuleStop.activity, removeRuleStart.activity);

                        Assert.True(eventQueue.IsEmpty, "There were events present when none were expected");
                    }
                }
                finally
                {
                    await subscriptionClient.CloseAsync();
                }
            });
        }

        protected void AssertAddRuleStart(string entityName, string eventName, object payload, Activity activity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.AddRule.Start", eventName);
            AssertCommonPayloadProperties(entityName, payload);
            GetPropertyValueFromAnonymousTypeInstance<RuleDescription>(payload, "Rule");
            Assert.NotNull(activity);
            Assert.Null(activity.Parent);
        }

        protected void AssertAddRuleStop(string entityName, string eventName, object payload, Activity activity, Activity addRuleActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.AddRule.Stop", eventName);
            AssertCommonStopPayloadProperties(entityName, payload);
            GetPropertyValueFromAnonymousTypeInstance<RuleDescription>(payload, "Rule");

            if (addRuleActivity != null)
            {
                Assert.Equal(addRuleActivity, activity);
            }
        }

        protected void AssertGetRulesStart(string entityName, string eventName, object payload, Activity activity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.GetRules.Start", eventName);
            AssertCommonPayloadProperties(entityName, payload);
            Assert.NotNull(activity);
            Assert.Null(activity.Parent);
        }

        protected void AssertGetRulesStop(string entityName, string eventName, object payload, Activity activity, Activity getRulesActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.GetRules.Stop", eventName);

            AssertCommonStopPayloadProperties(entityName, payload);
            GetPropertyValueFromAnonymousTypeInstance<IEnumerable<RuleDescription>>(payload, "Rules");

            if (getRulesActivity != null)
            {
                Assert.Equal(getRulesActivity, activity);
            }
        }

        protected void AssertRemoveRuleStart(string entityName, string eventName, object payload, Activity activity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.RemoveRule.Start", eventName);
            AssertCommonPayloadProperties(entityName, payload);
            GetPropertyValueFromAnonymousTypeInstance<string>(payload, "RuleName");
            Assert.NotNull(activity);
            Assert.Null(activity.Parent);
        }

        protected void AssertRemoveRuleStop(string entityName, string eventName, object payload, Activity activity, Activity removeRuleActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.RemoveRule.Stop", eventName);

            AssertCommonStopPayloadProperties(entityName, payload);
            GetPropertyValueFromAnonymousTypeInstance<string>(payload, "RuleName");

            if (removeRuleActivity != null)
            {
                Assert.Equal(removeRuleActivity, activity);
            }
        }
    }
}
