// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    public class IncidentResourceTests : SecurityInsightsManagementTestBase
    {
        public IncidentResourceTests(bool isAsync)
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
        private async Task<IncidentResource> CreateIncidentAsync(ResourceGroupResource resourceGroup, string workspaceName, string incidentName)
        {
            var collection = resourceGroup.GetIncidents(workspaceName);
            var input = ResourceDataHelpers.GetIncidentData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, incidentName, input);
            return lro.Value;
        }

        [TestCase]
        public async Task IncidentResourceApiTests()
        {
            //0.prepare
            var resourceGroup = await GetResourceGroupAsync();
            var workspace = await GetWorkspaceResourceAsync(resourceGroup);
            SentinelOnboardingStateResource sOS = await GetSentinelOnboardingStateResourceAsync(resourceGroup, workspace.Data.Name);
            //1.Get
            var incidentName = Recording.GenerateAssetName("testIncidents-");
            var incident1 = await CreateIncidentAsync(resourceGroup, workspace.Data.Name, incidentName);
            IncidentResource incident2 = await incident1.GetAsync();

            ResourceDataHelpers.AssertIncidentData(incident1.Data, incident2.Data);
            //2.Delete
            await incident1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
