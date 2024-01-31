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
    public class SentinelOnboardingStateResourceTests : SecurityInsightsManagementTestBase
    {
        public SentinelOnboardingStateResourceTests(bool isAsync)
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

        private async Task<SecurityInsightsSentinelOnboardingStateResource> CreateSentinelOnboardingStateResourceAsync(string onboardName)
        {
            var resourceGroup = await GetResourceGroupAsync();
            var workspace = await GetWorkspaceResourceAsync(resourceGroup);
            var groupName = resourceGroup.Data.Name;
            var workspaceName = groupName + "-ws";
            var ResourceID = CreateResourceIdentifier("db1ab6f0-4769-4b27-930e-01e2ef9c123c", groupName, workspaceName);
            var operationalInsights = new OperationalInsightsWorkspaceSecurityInsightsResource(Client, ResourceID);
            var collection = GetSentinelOnboardingStateCollectionAsync(operationalInsights);
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
            SecurityInsightsSentinelOnboardingStateResource Onboard2 = await onboard1.GetAsync();

            ResourceDataHelpers.AssertSentinelOnboardingStateData(onboard1.Data, Onboard2.Data);
            //2.Delete
            await onboard1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
