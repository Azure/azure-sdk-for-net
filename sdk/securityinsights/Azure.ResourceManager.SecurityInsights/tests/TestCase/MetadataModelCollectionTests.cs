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
    public class MetadataModelCollectionTests : SecurityInsightsManagementTestBase
    {
        public MetadataModelCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }
        private async Task<ResourceGroupResource> GetResourceGroupAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup;
        }
        #region workspace
        private WorkspaceCollection GetWorkspaceCollectionAsync(ResourceGroupResource resourceGroup)
        {
            return resourceGroup.GetWorkspaces();
        }
        #endregion

        #region Onboard
        private SentinelOnboardingStateCollection GetSentinelOnboardingStateCollectionAsync(ResourceGroupResource resourceGroup, string workspaceName)
        {
            return resourceGroup.GetSentinelOnboardingStates(workspaceName);
        }
        #endregion
        private MetadataModelCollection GetMetadataCollectionAsync(ResourceGroupResource resourceGroup, string workspaceName)
        {
            var groupName = resourceGroup.Data.Name;
            return resourceGroup.GetMetadataModels(workspaceName);
        }

        [TestCase]
        [RecordedTest]
        public async Task MetadataApiTests()
        {
            //1.CreateorUpdate
            var resourceGroup = await GetResourceGroupAsync();
            var groupName = resourceGroup.Data.Name;
            var workspaceCollection = GetWorkspaceCollectionAsync(resourceGroup);
            var workspaceName1 = groupName + "-ws";
            var workspaceInput = GetWorkspaceData();
            var lrow = await workspaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, workspaceName1, workspaceInput);
            WorkspaceResource workspace = lrow.Value;
            var collection = GetMetadataCollectionAsync(resourceGroup,workspaceName1);
            var onboardCollection = GetSentinelOnboardingStateCollectionAsync(resourceGroup, workspaceName1);
            var onboardName = "default";
            var onboardInput = ResourceDataHelpers.GetSentinelOnboardingStateData();
            var lroo = await onboardCollection.CreateOrUpdateAsync(WaitUntil.Completed, onboardName, onboardInput);
            SentinelOnboardingStateResource onboard1 = lroo.Value;
            var name = Recording.GenerateAssetName("TestFrontDoor");
            var name2 = Recording.GenerateAssetName("TestFrontDoor");
            var name3 = Recording.GenerateAssetName("TestFrontDoor");
            var input = ResourceDataHelpers.GetMetadataModelData(DefaultSubscription.Data.Id, groupName, workspaceName1);
            var input2 = ResourceDataHelpers.GetMetadataModelData(DefaultSubscription.Data.Id, groupName, workspaceName1);
            var input3 = ResourceDataHelpers.GetMetadataModelData(DefaultSubscription.Data.Id, groupName, workspaceName1);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            MetadataModelResource model1 = lro.Value;
            Assert.AreEqual(name, model1.Data.Name);
            //2.Get
            MetadataModelResource model2 = await collection.GetAsync(name);
            ResourceDataHelpers.AssertMetadataModelData(model1.Data, model2.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, input2);
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name3, input3);
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
