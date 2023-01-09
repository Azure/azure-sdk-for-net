// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    public class IncidentResourceTests : SecurityInsightsManagementTestBase
    {
        public IncidentResourceTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<ResourceGroupResource> GetResourceGroupAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup;
        }
        private async Task<SecurityInsightsIncidentResource> CreateIncidentAsync(OperationalInsightsWorkspaceSecurityInsightsResource operationalInsights, string incidentName)
        {
            var collection = operationalInsights.GetSecurityInsightsIncidents();
            var input = ResourceDataHelpers.GetIncidentData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, incidentName, input);
            return lro.Value;
        }

        [TestCase]
        public async Task IncidentResourceApiTests()
        {
            //0.prepare
            var resourceGroup = await GetResourceGroupAsync();
            var workspaceName = groupName + "ws";
            var ResourceID = CreateResourceIdentifier("db1ab6f0-4769-4b27-930e-01e2ef9c123c", groupName, workspaceName);
            var operationalInsights = new OperationalInsightsWorkspaceSecurityInsightsResource(Client, ResourceID);
            //1.Get
            var incidentName = Recording.GenerateAssetName("testIncidents-");
            var incident1 = await CreateIncidentAsync(operationalInsights, incidentName);
            SecurityInsightsIncidentResource incident2 = await incident1.GetAsync();

            ResourceDataHelpers.AssertIncidentData(incident1.Data, incident2.Data);
            //2.Delete
            await incident1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
