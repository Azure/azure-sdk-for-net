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
using Azure.ResourceManager.SecurityInsights.Tests.Helpers;
using NUnit.Framework;

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
        private SecurityInsightsSentinelOnboardingStateCollection GetSentinelOnboardingStateCollectionAsync(OperationalInsightsWorkspaceSecurityInsightsResource operationalInsights)
        {
            return operationalInsights.GetSecurityInsightsSentinelOnboardingStates();
        }

        [TestCase]
        [RecordedTest]
        public async Task SentinelOnboardingStateApiTests()
        {
            //1.CreateorUpdate
            var resourceGroup = await GetResourceGroupAsync();
            var workspace = await GetWorkspaceResourceAsync(resourceGroup);
            var groupName = resourceGroup.Data.Name;
            var workspaceName = groupName + "-ws";
            var ResourceID = CreateResourceIdentifier("db1ab6f0-4769-4b27-930e-01e2ef9c123c", groupName, workspaceName);
            var operationalInsights = new OperationalInsightsWorkspaceSecurityInsightsResource(Client, ResourceID);
            var collection = GetSentinelOnboardingStateCollectionAsync(operationalInsights);
            var name = "default";
            var input = ResourceDataHelpers.GetSentinelOnboardingStateData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            SecurityInsightsSentinelOnboardingStateResource onboard1 = lro.Value;
            Assert.AreEqual(name, onboard1.Data.Name);
            //2.Get
            SecurityInsightsSentinelOnboardingStateResource onboard2 = await collection.GetAsync(name);
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
