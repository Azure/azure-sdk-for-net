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
    public class SentinelOnboardingStateResourceTests : SecurityInsightsManagementTestBase
    {
        public SentinelOnboardingStateResourceTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<ResourceGroupResource> GetResourceGroupAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup;
        }
        private WorkspaceCollection GetWorkspaceCollectionAsync(ResourceGroupResource resourceGroup)
        {
            return resourceGroup.GetWorkspaces();
        }
        private SentinelOnboardingStateCollection GetSentinelOnboardingStateCollectionAsync(ResourceGroupResource resourceGroup, string workspaceName)
        {
            return resourceGroup.GetSentinelOnboardingStates(workspaceName);
        }

        private async Task<SentinelOnboardingStateResource> CreateSentinelOnboardingStateResourceAsync(string onboardName)
        {
            var resourceGroup = await GetResourceGroupAsync();
            var groupName = resourceGroup.Data.Name;
            var workspaceCollection = GetWorkspaceCollectionAsync(resourceGroup);
            var workspaceName1 = groupName + "-ws";
            var workspaceInput = GetWorkspaceData();
            var lrow = await workspaceCollection.CreateOrUpdateAsync(WaitUntil.Completed, workspaceName1, workspaceInput);
            WorkspaceResource workspace = lrow.Value;
            var collection = GetSentinelOnboardingStateCollectionAsync(resourceGroup, workspaceName1);
            var input = ResourceDataHelpers.GetSentinelOnboardingStateData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, onboardName, input);
            return lro.Value;
        }

        [TestCase]
        public async Task SOStateResourceApiTests()
        {
            //1.Get
            var onboardName = "default";
            var onboard1 = await CreateSentinelOnboardingStateResourceAsync(onboardName);
            SentinelOnboardingStateResource Onboard2 = await onboard1.GetAsync();

            ResourceDataHelpers.AssertSentinelOnboardingStateData(onboard1.Data, Onboard2.Data);
            //2.Delete
            await onboard1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
