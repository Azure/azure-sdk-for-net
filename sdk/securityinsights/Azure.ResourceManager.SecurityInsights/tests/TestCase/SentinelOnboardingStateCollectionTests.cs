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
    public class SentinelOnboardingStateCollectionTests : SecurityInsightsManagementTestBase
    {
        public SentinelOnboardingStateCollectionTests(bool isAsync)
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
        private SentinelOnboardingStateCollection GetSentinelOnboardingStateCollectionAsync(ResourceGroupResource resourceGroup, string workspaceName)
        {
            var groupName = resourceGroup.Data.Name;
            return resourceGroup.GetSentinelOnboardingStates(workspaceName);
        }

        [TestCase]
        [RecordedTest]
        public async Task SentinelOnboardingStateApiTests()
        {
            //1.CreateorUpdate
            var resourceGroup = await GetResourceGroupAsync();
            var groupName = resourceGroup.Data.Name;
            var workspaceCollection = GetWorkspaceCollectionAsync(resourceGroup);
            var workspaceName1 = groupName + "-ws";
            var workspaceInput = GetWorkspaceData();
            var lrow = await workspaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, workspaceName1, workspaceInput);
            WorkspaceResource workspace = lrow.Value;
            var collection = GetSentinelOnboardingStateCollectionAsync(resourceGroup, workspaceName1);
            var name = "default";
            var input = ResourceDataHelpers.GetSentinelOnboardingStateData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            SentinelOnboardingStateResource onboard1 = lro.Value;
            Assert.AreEqual(name, onboard1.Data.Name);
            //2.Get
            SentinelOnboardingStateResource onboard2 = await collection.GetAsync(name);
            ResourceDataHelpers.AssertSentinelOnboardingStateData(onboard1.Data, onboard2.Data);
            //3.GetAll
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            int count = 0;
            await foreach (var num in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
            //4Exists
            Assert.IsTrue(await collection.ExistsAsync(name));
            //Assert.IsFalse(await collection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }
    }
}
