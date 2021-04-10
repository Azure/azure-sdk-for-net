// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.TestFramework;

namespace Azure.ResourceManager.Insights.Tests
{
    [RunFrequency(RunTestFrequency.Manually)]
    public abstract class InsightsManagementClientBase : ManagementRecordedTestBase<InsightsManagementTestEnvironment>
    {
        protected static readonly string RgName = "rg1";

        protected InsightsManagementClientBase(bool isAsync)
            : base(isAsync)
        { }

        public AlertRulesOperations AlertRulesOperations { get; set; }
        public AlertRuleIncidentsOperations AlertRuleIncidentsOperations { get; set; }

        protected void InitializeBase()
        {
            var InsightsManagementClient = GetInsightsManagementClient();
            AlertRulesOperations = InsightsManagementClient.AlertRules;
            AlertRuleIncidentsOperations = InsightsManagementClient.AlertRuleIncidents;
        }

        protected InsightsManagementClient GetInsightsManagementClient()
        {
            var options = InstrumentClientOptions(new InsightsManagementClientOptions());
            CleanupPolicy = new ResourceGroupCleanupPolicy();
            options.AddPolicy(CleanupPolicy, HttpPipelinePosition.PerCall);

            return CreateClient<InsightsManagementClient>(
                TestEnvironment.SubscriptionId, TestEnvironment.Credential,options);
        }
    }
}
