// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Logic;
using Azure.ResourceManager.OperationalInsights;
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
        private async Task<AutomationRuleResource> CreateAutomationRuleAsync(ResourceGroupResource resourceGroup, string workspaceName, string automationName, string workflowName)
        {
            var collection = resourceGroup.GetAutomationRules(workspaceName);
            var input = ResourceDataHelpers.GetAutomationRuleData(resourceGroup.Data.Name, workflowName);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, automationName, input);
            return lro.Value;
        }

        [TestCase]
        public async Task AutomationRuleResourceApiTests()
        {
            //0.prepare
            var resourceGroup = await GetResourceGroupAsync();
            var workspace = await GetWorkspaceResourceAsync(resourceGroup);
            SentinelOnboardingStateResource sOS = await GetSentinelOnboardingStateResourceAsync(resourceGroup, workspace.Data.Name);
            var workflowName = Recording.GenerateAssetName("workflow");
            var accountName = Recording.GenerateAssetName("integrationaccount");
            var integrationAccount = await GetIntegrationAccountResourceAsync(resourceGroup, accountName);
            var integrationAccountIdentifier = integrationAccount.Data.Id;
            var workfllowResource = await GetLogicWorkflowResourceAsync(resourceGroup, integrationAccountIdentifier, workflowName);
            //1.Get
            var automationName = Recording.GenerateAssetName("testAutomationRule-");
            var automation1 = await CreateAutomationRuleAsync(resourceGroup, workspace.Data.Name, automationName, workflowName);
            AutomationRuleResource automation = await automation1.GetAsync();

            ResourceDataHelpers.AssertAutomationRuleData(automation1.Data, automation.Data);
            //2.Delete
            await automation1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
