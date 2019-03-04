// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests.Diagnostics
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Xunit;

    public class SubscriptionClientDiagnosticsTests : DiagnosticsTests
    {
        protected override string EntityName => $"{TestConstants.NonPartitionedTopicName}/Subscriptions/{TestConstants.SubscriptionName}";
        private SubscriptionClient subscriptionClient;
        private bool disposed;

        [Fact]
        [DisplayTestMethodName]
        async Task AddRemoveGetFireEvents()
        {
            this.subscriptionClient = new SubscriptionClient(
                TestUtility.NamespaceConnectionString,
                TestConstants.NonPartitionedTopicName,
                TestConstants.SubscriptionName,
                ReceiveMode.ReceiveAndDelete);

            this.listener.Enable((name, queueName, id) => name.Contains("Rule"));

            var ruleName = Guid.NewGuid().ToString();
            await this.subscriptionClient.AddRuleAsync(ruleName, new TrueFilter());
            await this.subscriptionClient.GetRulesAsync();
            await this.subscriptionClient.RemoveRuleAsync(ruleName);

            Assert.True(this.events.TryDequeue(out var addRuleStart));
            AssertAddRuleStart(addRuleStart.eventName, addRuleStart.payload, addRuleStart.activity);

            Assert.True(this.events.TryDequeue(out var addRuleStop));
            AssertAddRuleStop(addRuleStop.eventName, addRuleStop.payload, addRuleStop.activity, addRuleStart.activity);

            Assert.True(this.events.TryDequeue(out var getRulesStart));
            AssertGetRulesStart(getRulesStart.eventName, getRulesStart.payload, getRulesStart.activity);

            Assert.True(this.events.TryDequeue(out var getRulesStop));
            AssertGetRulesStop(getRulesStop.eventName, getRulesStop.payload, getRulesStop.activity, getRulesStart.activity);

            Assert.True(this.events.TryDequeue(out var removeRuleStart));
            AssertRemoveRuleStart(removeRuleStart.eventName, removeRuleStart.payload, removeRuleStart.activity);

            Assert.True(this.events.TryDequeue(out var removeRuleStop));
            AssertRemoveRuleStop(removeRuleStop.eventName, removeRuleStop.payload, removeRuleStop.activity, removeRuleStart.activity);

            Assert.True(this.events.IsEmpty);
        }

        [Fact]
        [DisplayTestMethodName]
        async Task EventsAreNotFiredWhenDiagnosticsIsDisabled()
        {
            this.subscriptionClient = new SubscriptionClient(
                TestUtility.NamespaceConnectionString,
                TestConstants.NonPartitionedTopicName,
                TestConstants.SubscriptionName,
                ReceiveMode.ReceiveAndDelete);

            this.listener.Disable();

            var ruleName = Guid.NewGuid().ToString();
            await this.subscriptionClient.AddRuleAsync(ruleName, new TrueFilter());
            await this.subscriptionClient.GetRulesAsync();
            await this.subscriptionClient.RemoveRuleAsync(ruleName);

            Assert.True(this.events.IsEmpty);
        }

        protected override void Dispose(bool disposing)
        {
            if (this.disposed)
                return;

            if (disposing)
            {
                this.subscriptionClient?.CloseAsync().Wait(TimeSpan.FromSeconds(maxWaitSec));
            }

            this.disposed = true;

            base.Dispose(disposing);
        }

        protected void AssertAddRuleStart(string name, object payload, Activity activity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.AddRule.Start", name);
            AssertCommonPayloadProperties(payload);
            GetPropertyValueFromAnonymousTypeInstance<RuleDescription>(payload, "Rule");
            Assert.NotNull(activity);
            Assert.Null(activity.Parent);
        }

        protected void AssertAddRuleStop(string name, object payload, Activity activity, Activity addRuleActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.AddRule.Stop", name);
            AssertCommonStopPayloadProperties(payload);
            GetPropertyValueFromAnonymousTypeInstance<RuleDescription>(payload, "Rule");

            if (addRuleActivity != null)
            {
                Assert.Equal(addRuleActivity, activity);
            }
        }

        protected void AssertGetRulesStart(string name, object payload, Activity activity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.GetRules.Start", name);
            AssertCommonPayloadProperties(payload);
            Assert.NotNull(activity);
            Assert.Null(activity.Parent);
        }

        protected void AssertGetRulesStop(string name, object payload, Activity activity, Activity getRulesActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.GetRules.Stop", name);
            
            AssertCommonStopPayloadProperties(payload);
            GetPropertyValueFromAnonymousTypeInstance<IEnumerable<RuleDescription>>(payload, "Rules");

            if (getRulesActivity != null)
            {
                Assert.Equal(getRulesActivity, activity);
            }
        }

        protected void AssertRemoveRuleStart(string name, object payload, Activity activity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.RemoveRule.Start", name);
            AssertCommonPayloadProperties(payload);
            GetPropertyValueFromAnonymousTypeInstance<string>(payload, "RuleName");
            Assert.NotNull(activity);
            Assert.Null(activity.Parent);
        }

        protected void AssertRemoveRuleStop(string name, object payload, Activity activity, Activity removeRuleActivity)
        {
            Assert.Equal("Microsoft.Azure.ServiceBus.RemoveRule.Stop", name);

            AssertCommonStopPayloadProperties(payload);
            GetPropertyValueFromAnonymousTypeInstance<string>(payload, "RuleName");

            if (removeRuleActivity != null)
            {
                Assert.Equal(removeRuleActivity, activity);
            }
        }
    }
}
