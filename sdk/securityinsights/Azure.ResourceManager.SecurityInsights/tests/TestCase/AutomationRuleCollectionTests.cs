// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.OperationalInsights;
using Azure.ResourceManager.Logic;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecurityInsights.Models;
using Azure.ResourceManager.SecurityInsights.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityInsights.Tests.TestCase
{
    public class AutomationRuleCollectionTests : SecurityInsightsManagementTestBase
    {
        public AutomationRuleCollectionTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }
        private async Task<ResourceGroupResource> GetResourceGroupAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup;
        }
        #region Workspace
        private WorkspaceCollection GetWorkspaceCollectionAsync(ResourceGroupResource resourceGroup)
        {
            return resourceGroup.GetWorkspaces();
        }
        private async Task<WorkspaceResource> GetWorkspaceResourceAsync(ResourceGroupResource resourceGroup)
        {
            var workspaceCollection = GetWorkspaceCollectionAsync(resourceGroup);
            var workspaceName1 = groupName + "-ws";
            var workspaceInput = GetWorkspaceData();
            var lrow = await workspaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, workspaceName1, workspaceInput);
            WorkspaceResource workspace = lrow.Value;
            return workspace;
        }
        #endregion
        #region Onboard
        private SentinelOnboardingStateCollection GetSentinelOnboardingStateCollectionAsync(ResourceGroupResource resourceGroup, string workspaceName)
        {
            return resourceGroup.GetSentinelOnboardingStates(workspaceName);
        }
        private async Task<SentinelOnboardingStateResource> GetSentinelOnboardingStateResourceAsync(ResourceGroupResource resourceGroup, string workspaceName)
        {
            var onboardCollection = GetSentinelOnboardingStateCollectionAsync(resourceGroup, workspaceName);
            var onboardName = "default";
            var onboardInput = ResourceDataHelpers.GetSentinelOnboardingStateData();
            var lroo = await onboardCollection.CreateOrUpdateAsync(WaitUntil.Completed, onboardName, onboardInput);
            SentinelOnboardingStateResource onboard1 = lroo.Value;
            return onboard1;
        }
        #endregion

        #region IntegrationAccount
        private IntegrationAccountCollection GetIntegrationAccountCollectionAsync(ResourceGroupResource resourceGroup)
        {
            return resourceGroup.GetIntegrationAccounts();
        }
        private async Task<IntegrationAccountResource> GetIntegrationAccountResourceAsync(ResourceGroupResource resourceGroup, string accountName)
        {
            var accountCollection = GetIntegrationAccountCollectionAsync(resourceGroup);
            var accountInput = ResourceDataHelpers.GetIntegrationAccountData(resourceGroup);
            var lroo = await accountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, accountInput);
            IntegrationAccountResource account = lroo.Value;
            return account;
        }
        #endregion

        #region logic workflow
        private LogicWorkflowCollection GetLogicWorkflowCollectionAsync(ResourceGroupResource resourceGroup)
        {
            return resourceGroup.GetLogicWorkflows();
        }
        private async Task<LogicWorkflowResource> GetLogicWorkflowResourceAsync(ResourceGroupResource resourceGroup, ResourceIdentifier integrationAccountIdentifier, string workflowName)
        {
            var workflowCollection = GetLogicWorkflowCollectionAsync(resourceGroup);
            var workflowInput = ResourceDataHelpers.GetWorkflowData(resourceGroup, integrationAccountIdentifier, workflowName);
            var lroo = await workflowCollection.CreateOrUpdateAsync(WaitUntil.Completed, workflowName, workflowInput);
            LogicWorkflowResource workflow = lroo.Value;
            return workflow;
        }
        #endregion
        private AutomationRuleCollection GetAutomationRuleCollectionAsync(ResourceGroupResource resourceGroup, string workspaceName)
        {
            return resourceGroup.GetAutomationRules(workspaceName);
        }

        [TestCase]
        public async Task AutomationRuleCollectionApiTests()
        {
            //0.prepare
            var resourceGroup = await GetResourceGroupAsync();
            var workspace = await GetWorkspaceResourceAsync(resourceGroup);
            SentinelOnboardingStateResource sOS = await GetSentinelOnboardingStateResourceAsync(resourceGroup, workspace.Data.Name);
            var workflowName = Recording.GenerateAssetName("workflow");
            var accountName = Recording.GenerateAssetName("integrationaccount");
            var integrationAccount = await GetIntegrationAccountResourceAsync(resourceGroup, accountName);
            var integrationAccountIdentifier = integrationAccount.Data.Id;
            var workflowResource = await GetLogicWorkflowResourceAsync(resourceGroup, integrationAccountIdentifier, workflowName);
            //1.CreateOrUpdate
            var collection = GetAutomationRuleCollectionAsync(resourceGroup, workspace.Data.Name);
            var name = Recording.GenerateAssetName("AutomationRules-");
            var name2 = Recording.GenerateAssetName("AutomationRules-");
            var name3 = Recording.GenerateAssetName("AutomationRules-");
            var input = ResourceDataHelpers.GetAutomationRuleData(resourceGroup.Data.Name, workflowName);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            AutomationRuleResource automation1 = lro.Value;
            Assert.AreEqual(name, automation1.Data.Name);
            //2.Get
            AutomationRuleResource automation2 = await collection.GetAsync(name);
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
