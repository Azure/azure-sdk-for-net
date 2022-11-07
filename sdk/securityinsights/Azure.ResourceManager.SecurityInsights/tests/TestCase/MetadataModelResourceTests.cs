// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecurityInsights.Models;
using Azure.ResourceManager.OperationalInsights.Models;
using Azure.ResourceManager.SecurityInsights.Tests.Helpers;
using NUnit.Framework;
using Azure.ResourceManager.OperationalInsights;

namespace Azure.ResourceManager.SecurityInsights.Tests.TestCase
{
    public class MetadataModelResourceTests : SecurityInsightsManagementTestBase
    {
        public MetadataModelResourceTests(bool isAsync)
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
        private MetadataModelCollection GetMetadataModelCollectionAsync(ResourceGroupResource resourceGroup, string workspaceName)
        {
            return resourceGroup.GetMetadataModels(workspaceName);
        }

        private async Task<MetadataModelResource> CreateMetadataModelResourceAsync(ResourceGroupResource resourceGroup,string modelName, string workspaceName)
        {
            var collection = GetMetadataModelCollectionAsync(resourceGroup, workspaceName);
            var groupName = resourceGroup.Data.Name;
            var input = ResourceDataHelpers.GetMetadataModelData(DefaultSubscription.Id, groupName, workspaceName);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, modelName, input);
            return lro.Value;
        }

        [TestCase]
        public async Task MetadataModelResourceApiTests()
        {
            //0.prepare
            var resourceGroup = await GetResourceGroupAsync();
            var workspace = await GetWorkspaceResourceAsync(resourceGroup);
            SentinelOnboardingStateResource sOS = await GetSentinelOnboardingStateResourceAsync(resourceGroup, workspace.Data.Name);
            //1.Get
            var modelName = Recording.GenerateAssetName("testMetaDataModel");
            var model1 = await CreateMetadataModelResourceAsync(resourceGroup, modelName, workspace.Data.Name);
            MetadataModelResource model2 = await model1.GetAsync();

            ResourceDataHelpers.AssertMetadataModelData(model1.Data, model2.Data);
            //2.Delete
            await model1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
