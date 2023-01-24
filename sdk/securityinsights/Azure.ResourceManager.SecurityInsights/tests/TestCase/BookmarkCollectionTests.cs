// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
    public class BookmarkCollectionTests : SecurityInsightsManagementTestBase
    {
        public BookmarkCollectionTests(bool isAsync)
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

        private SecurityInsightsBookmarkCollection GetBookmarkCollectionAsync(OperationalInsightsWorkspaceSecurityInsightsResource operationalInsights)
        {
            return operationalInsights.GetSecurityInsightsBookmarks();
        }

        [TestCase]
        public async Task BookmarkCollectionApiTests()
        {
            //0.prepare
            var resourceGroup = await GetResourceGroupAsync();
            var workspaceName = groupName + "-ws";
            var ResourceID = CreateResourceIdentifier("db1ab6f0-4769-4b27-930e-01e2ef9c123c", groupName, workspaceName);
            var operationalInsights = new OperationalInsightsWorkspaceSecurityInsightsResource(Client, ResourceID);
            var workspace = await GetWorkspaceResourceAsync(resourceGroup);
            var sOS = await GetSentinelOnboardingStateResourceAsync(operationalInsights);
            //1.CreateOrUpdate
            var collection = GetBookmarkCollectionAsync(operationalInsights);
            var name = "6a8d6ea6-04d5-49d7-8169-ffca8b0ced59";
            var name2 = "6a8d6ea6-04d5-49d7-8169-ffca8b0ced61";
            var name3 = "6a8d6ea6-04d5-49d7-8169-ffca8b0ced62";
            var input = ResourceDataHelpers.GetBookmarkData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            SecurityInsightsBookmarkResource bookmark1 = lro.Value;
            Assert.AreEqual(name, bookmark1.Data.Name);
            //2.Get
            SecurityInsightsBookmarkResource bookmark2 = await collection.GetAsync(name);
            ResourceDataHelpers.AssertBookmarkData(bookmark1.Data, bookmark2.Data);
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
            Assert.IsFalse(await collection.ExistsAsync("6a8d6ea6-04d5-49d7-8169-ffca8b0ced60"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }
    }
}
