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
            OperationalInsightsNetworkSecurityPerimeterRuleType? ruleType = default(OperationalInsightsNetworkSecurityPerimeterRuleType);
            OperationalInsightsNetworkSecurityPerimeterStatusCode? statusCode = default(OperationalInsightsNetworkSecurityPerimeterStatusCode);
            OperationalInsightsNetworkSecurityPerimeterProvisioningState? provisioningState = default(OperationalInsightsNetworkSecurityPerimeterProvisioningState);

            OperationalInsightsSummaryLogsData data = ArmOperationalInsightsModelFactory.OperationalInsightsSummaryLogsData(
                id: default,
                name: default,
                resourceType: default,
                systemData: default,
                ruleType: ruleType,
                displayName: default,
                description: default,
                isActive: default,
                statusCode: statusCode,
                provisioningState: provisioningState,
                ruleDefinition: default);

            Assert.AreEqual(default(OperationalInsightsNetworkSecurityPerimeterRuleType), data.RuleType.Value);
            Assert.AreEqual(default(OperationalInsightsNetworkSecurityPerimeterStatusCode), data.StatusCode.Value);
            Assert.AreEqual(default(OperationalInsightsNetworkSecurityPerimeterProvisioningState), data.ProvisioningState.Value);
#pragma warning restore CS0618
        }

        [Test]
        public void CorrectFactoryOverloadIsPreferredForSharedArguments()
        {
            OperationalInsightsSummaryLogsData emptyData = ArmOperationalInsightsModelFactory.OperationalInsightsSummaryLogsData();
            OperationalInsightsSummaryLogsData namedData = ArmOperationalInsightsModelFactory.OperationalInsightsSummaryLogsData(displayName: "display");

            Assert.IsNull(emptyData.SummaryLogsRuleType);
            Assert.AreEqual("display", namedData.DisplayName);
        }
    }
}
