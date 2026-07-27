// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.OperationalInsights.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.OperationalInsights.Tests
{
    public class EnumCompatibilityTests
    {
        [Test]
        public void DefaultValuesSurviveCompatibilityConversions()
        {
#pragma warning disable CS0618
            OperationalInsightsNetworkSecurityPerimeterRuleType oldRuleType = default;
            OperationalInsightsSummaryLogsRuleType newRuleType = oldRuleType;
            Assert.AreEqual(oldRuleType, (OperationalInsightsNetworkSecurityPerimeterRuleType)newRuleType);

            OperationalInsightsNetworkSecurityPerimeterStatusCode oldStatusCode = default;
            OperationalInsightsSummaryLogsStatusCode newStatusCode = oldStatusCode;
            Assert.AreEqual(oldStatusCode, (OperationalInsightsNetworkSecurityPerimeterStatusCode)newStatusCode);

            OperationalInsightsNetworkSecurityPerimeterProvisioningState oldProvisioningState = default;
            OperationalInsightsSummaryLogsProvisioningState newProvisioningState = oldProvisioningState;
            Assert.AreEqual(oldProvisioningState, (OperationalInsightsNetworkSecurityPerimeterProvisioningState)newProvisioningState);
#pragma warning restore CS0618
        }

        [Test]
        public void FactoryPreservesDefaultCompatibilityValues()
        {
#pragma warning disable CS0618
            OperationalInsightsSummaryLogsData data = ArmOperationalInsightsModelFactory.OperationalInsightsSummaryLogsData(
                ruleType: default(OperationalInsightsNetworkSecurityPerimeterRuleType),
                statusCode: default(OperationalInsightsNetworkSecurityPerimeterStatusCode),
                provisioningState: default(OperationalInsightsNetworkSecurityPerimeterProvisioningState));

            Assert.AreEqual(default(OperationalInsightsNetworkSecurityPerimeterRuleType), data.RuleType.Value);
            Assert.AreEqual(default(OperationalInsightsNetworkSecurityPerimeterStatusCode), data.StatusCode.Value);
            Assert.AreEqual(default(OperationalInsightsNetworkSecurityPerimeterProvisioningState), data.ProvisioningState.Value);
#pragma warning restore CS0618
        }
    }
}
