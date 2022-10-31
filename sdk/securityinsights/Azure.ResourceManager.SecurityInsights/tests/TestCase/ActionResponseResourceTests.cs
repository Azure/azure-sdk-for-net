// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.OperationalInsights;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecurityInsights.Models;
using Azure.ResourceManager.SecurityInsights.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityInsights.Tests.TestCase
{
    public class ActionResponseResourceTests : SecurityInsightsManagementTestBase
    {
        public ActionResponseResourceTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
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
        private async Task<ActionResponseResource> GetActionResponseResourceAsync(ResourceGroupResource resourceGroup, string workspaceName, string actionResopnseName)
        {
            var collection = resourceGroup.GetSecurityInsightsAlertRules(workspaceName);
            var alertRulesName = Recording.GenerateAssetName("testAlertRule-");
            var input = ResourceDataHelpers.GetSecurityInsightsAlertRuleData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, alertRulesName, input);
            var alertRules = lro.Value;
            var actionCollection =  alertRules.GetActionResponses();
            var actionInput = ResourceDataHelpers.GetActionResponseData(resourceGroup.Data.Name);
            var lroa = await actionCollection.CreateOrUpdateAsync(WaitUntil.Completed, actionResopnseName, actionInput);
            return lroa.Value;
        }

        [TestCase]
        public async Task ActionResponseResourceApiTests()
        {
            //0.prepare
            var resourceGroup = await GetResourceGroupAsync();
            var workspace = await GetWorkspaceResourceAsync(resourceGroup);
            SentinelOnboardingStateResource sOS = await GetSentinelOnboardingStateResourceAsync(resourceGroup, workspace.Data.Name);
            //1.Get
            var actionName = Recording.GenerateAssetName("testactionResponse");
            var actionResponse = await GetActionResponseResourceAsync(resourceGroup, workspace.Data.Name, actionName);
            ActionResponseResource engine2 = await actionResponse.GetAsync();

            ResourceDataHelpers.AssertActionResponseData(actionResponse.Data, engine2.Data);
            //2.Delete
            await actionResponse.DeleteAsync(WaitUntil.Completed);
        }
    }
}
