// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.SecurityInsights.Models;
using Azure.ResourceManager.SecurityInsights.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.SecurityInsights.Tests.TestCase
{
    public class TIligenceIndicatorResource : SecurityInsightsManagementTestBase
    {
        public TIligenceIndicatorResource(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<ResourceGroupResource> GetResourceGroupAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup;
        }

        private async Task<SecurityInsightsThreatIntelligenceIndicatorResource> CreateThreatIntelligenceAsync(OperationalInsightsWorkspaceSecurityInsightsResource operationalInsights, string watchName)
        {
            var collection = operationalInsights.GetSecurityInsightsThreatIntelligenceIndicators();
            var input = ResourceDataHelpers.GetThreatIntelligenceIndicatorData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, watchName, input);
            return lro.Value;
        }

        [TestCase]
        public async Task ThreatIntelligenceResourceApiTests()
        {
            //0.prepare
            var resourceGroup = await GetResourceGroupAsync();
            var workspaceName = groupName + "ws";
            var ResourceID = CreateResourceIdentifier("db1ab6f0-4769-4b27-930e-01e2ef9c123c", groupName, workspaceName);
            var operationalInsights = new OperationalInsightsWorkspaceSecurityInsightsResource(Client, ResourceID);
            //1.Get
            var watchName = Recording.GenerateAssetName("testThreatIntelligenceIndicator-");
            var watch1 = await CreateThreatIntelligenceAsync(operationalInsights, watchName);
            SecurityInsightsThreatIntelligenceIndicatorResource watch2 = await watch1.GetAsync();

            ResourceDataHelpers.AssertThreatIntelligenceIndicatorData(watch1.Data, watch2.Data);
            //2.Delete
            await watch1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
