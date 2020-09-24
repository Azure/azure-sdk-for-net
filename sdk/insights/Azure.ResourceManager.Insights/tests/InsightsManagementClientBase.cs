// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.ResourceManager.TestFramework;

namespace Azure.ResourceManager.Insights.Tests
{
    [RunFrequency(RunTestFrequency.Manually)]
    public abstract class InsightsManagementClientBase : ManagementRecordedTestBase<InsightsManagementTestEnvironment>
    {
        protected static readonly string RgName = "rg1";

        protected InsightsManagementClientBase(bool isAsync, RecordedTestMode mode)
            : base(isAsync, mode)
        { }

        public AlertRulesOperations AlertRulesOperations { get; set; }
        public AlertRuleIncidentsOperations AlertRuleIncidentsOperations { get; set; }

        protected void InitializeBase()
        {
            var InsightsManagementClient = GetInsightsManagementClient();
            AlertRulesOperations = InsightsManagementClient.AlertRules;
            AlertRuleIncidentsOperations = InsightsManagementClient.AlertRuleIncidents;
        }

        internal virtual InsightsManagementClient GetInsightsManagementClient(string expectedJson = null)
        {
            return CreateClient<InsightsManagementClient>(this.TestEnvironment.SubscriptionId,
                TestEnvironment.Credential,
                Recording.InstrumentClientOptions(new InsightsManagementClientOptions()));
        }
    }
}
