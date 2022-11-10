// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityCenter.Tests
{
    internal class SubscriptionGovernanceRuleTests : SecurityCenterManagementTestBase
    {
        private SubscriptionGovernanceRuleCollection _subscriptionGovernanceRuleCollection => DefaultSubscription.GetSubscriptionGovernanceRules();
        public SubscriptionGovernanceRuleTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        [Ignore("lack required AssessmentKey")]
        public async Task CreateOrUpdate()
        {
            string AssessmentKey = "";
            string AssessmentValue = "";
            string ruleId = "ad9a8e26-29d9-4829-bb30-e597a58cdbb8";
            var data = new GovernanceRuleData()
            {
                DisplayName = "Admin's rule",
                Description = "A rule on critical recommendations",
                RemediationTimeframe = "7.00:00:00",
                IsGracePeriod = true,
                RulePriority = 200,
                IsDisabled = false,
                RuleType = GovernanceRuleType.Integrated,
                SourceResourceType = GovernanceRuleSourceResourceType.Assessments,
                ConditionSets =
                {
                    new BinaryData("{\"conditions\":[{\"property\":\"$.AssessmentKey\",\"value\":\"[\\\""+AssessmentKey+"\\\", \\\""+AssessmentValue+"\\\"]\",\"operator\":\"In\"}]}"),
                }
            };
            var list = await _subscriptionGovernanceRuleCollection.CreateOrUpdateAsync(WaitUntil.Completed, ruleId, data);
            Assert.IsNotNull(list);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var list = await _subscriptionGovernanceRuleCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsEmpty(list);
        }
    }
}
