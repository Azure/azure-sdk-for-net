// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.OperationalInsights;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecurityInsights.Models;
using Azure.ResourceManager.SecurityInsights.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityInsights.Tests.TestCase
{
    public class AutomationRuleCollectionTests : SecurityInsightsManagementTestBase
    {
        public AutomationRuleCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }
        private async Task<ResourceGroupResource> GetResourceGroupAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup;
        }
        #region Workspace
        private OperationalInsightsWorkspaceCollection GetWorkspaceCollectionAsync(ResourceGroupResource resourceGroup)
        {
            return resourceGroup.GetOperationalInsightsWorkspaces();
        }
        private async Task<OperationalInsightsWorkspaceResource> GetWorkspaceResourceAsync(ResourceGroupResource resourceGroup)
        {
            var workspaceCollection = GetWorkspaceCollectionAsync(resourceGroup);
            var workspaceName1 = groupName + "-ws";
            var workspaceInput = GetWorkspaceData();
            var lrow = await workspaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, workspaceName1, workspaceInput);
            OperationalInsightsWorkspaceResource workspace = lrow.Value;
            return workspace;
        }
        #endregion
        #region Onboard
        private async Task<SecurityInsightsSentinelOnboardingStateResource> GetSentinelOnboardingStateResourceAsync(OperationalInsightsWorkspaceSecurityInsightsResource operationalInsights)
        {
            var onboardCollection = operationalInsights.GetSecurityInsightsSentinelOnboardingStates();
            var onboardName = "default";
            var onboardInput = ResourceDataHelpers.GetSentinelOnboardingStateData();
            var lroo = await onboardCollection.CreateOrUpdateAsync(WaitUntil.Completed, onboardName, onboardInput);
            SecurityInsightsSentinelOnboardingStateResource onboard1 = lroo.Value;
            return onboard1;
        }
        #endregion

        private SecurityInsightsAutomationRuleCollection GetAutomationRuleCollectionAsync(OperationalInsightsWorkspaceSecurityInsightsResource operationalInsights)
        {
            return operationalInsights.GetSecurityInsightsAutomationRules();
        }

        [TestCase]
        public async Task AutomationRuleCollectionApiTests()
        {
            //0.prepare
            var resourceGroup = await GetResourceGroupAsync();
            var workspace = await GetWorkspaceResourceAsync(resourceGroup);
            var workspaceName = groupName + "-ws";
            var ResourceID = CreateResourceIdentifier("db1ab6f0-4769-4b27-930e-01e2ef9c123c", groupName, workspaceName);
            var operationalInsights = new OperationalInsightsWorkspaceSecurityInsightsResource(Client, ResourceID);
            var sOS = await GetSentinelOnboardingStateResourceAsync(operationalInsights);
            //1.CreateOrUpdate
            var collection = GetAutomationRuleCollectionAsync(operationalInsights);
            var name = Recording.GenerateAssetName("automationrules-");
            var name2 = Recording.GenerateAssetName("automationrules-");
            var name3 = Recording.GenerateAssetName("automationrules-");
            var input = ResourceDataHelpers.GetAutomationRuleData(resourceGroup.Data.Name);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            SecurityInsightsAutomationRuleResource automation1 = lro.Value;
            Assert.AreEqual(name, automation1.Data.Name);
            //2.Get
            SecurityInsightsAutomationRuleResource automation2 = await collection.GetAsync(name);
            ResourceDataHelpers.AssertAutomationRuleData(automation1.Data, automation2.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3, input);
            int count = 0;
            await foreach (var num in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 3);
            //4Exists
            Assert.IsTrue(await collection.ExistsAsync(name));
            Assert.IsFalse(await collection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }
    }
}
