// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecurityInsights.Models;
using Azure.ResourceManager.SecurityInsights.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityInsights.Tests.TestCase
{
    public class AutomationRuleResourceTests : SecurityInsightsManagementTestBase
    {
        public AutomationRuleResourceTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<ResourceGroupResource> GetResourceGroupAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup;
        }

        private async Task<SecurityInsightsAutomationRuleResource> CreateAutomationRuleAsync(OperationalInsightsWorkspaceSecurityInsightsResource operationalInsights, string automationName)
        {
            var collection = operationalInsights.GetSecurityInsightsAutomationRules();
            var input = ResourceDataHelpers.GetAutomationRuleData(groupName);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, automationName, input);
            return lro.Value;
        }

        [TestCase]
        public async Task AutomationRuleResourceApiTests()
        {
            //0.prepare
            var resourceGroup = await GetResourceGroupAsync();
            var workspaceName = groupName + "ws";
            var ResourceID = CreateResourceIdentifier("db1ab6f0-4769-4b27-930e-01e2ef9c123c", groupName, workspaceName);
            var operationalInsights = new OperationalInsightsWorkspaceSecurityInsightsResource(Client, ResourceID);
            //var workfllowResource = await GetLogicWorkflowResourceAsync(resourceGroup, integrationAccountIdentifier, workflowName);
            //1.Get
            var automationName = Recording.GenerateAssetName("testautomationrule-");
            var automation1 = await CreateAutomationRuleAsync(operationalInsights, automationName);
            SecurityInsightsAutomationRuleResource automation = await automation1.GetAsync();

            ResourceDataHelpers.AssertAutomationRuleData(automation1.Data, automation.Data);
            //2.Delete
            await automation1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
