// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ApplicationInsights.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ApplicationInsights.Tests.Scenario
{
    internal class ApplicationInsightsWorkbookResource_Test : ApplicationInsightsManagementTestBase
    {
        public ApplicationInsightsWorkbookResource_Test(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }
        public async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            return await CreateResourceGroup(await Client.GetDefaultSubscriptionAsync(), "RG_Application", AzureLocation.EastAsia);
        }
        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var resourceGroupName = resourceGroup.Data.Name;
            string subscriptionId = (await Client.GetDefaultSubscriptionAsync()).Data.SubscriptionId;
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = Client.GetResourceGroupResource(resourceGroupResourceId);
            ApplicationInsightsWorkbookCollection collection = resourceGroupResource.GetApplicationInsightsWorkbooks();
            string resourceName = "deadb33f-5e0d-4064-8ebb-1a4ed0313eb3";
            ApplicationInsightsWorkbookData data = new ApplicationInsightsWorkbookData(new AzureLocation("westus"))
            {
                DisplayName = "Sample workbook",
                SerializedData = "{\"version\":\"Notebook/1.0\",\"items\":[{\"type\":1,\"content\":\"{\"json\":\"## New workbook\\r\\n---\\r\\n\\r\\nWelcome to your new workbook.  This area will display text formatted as markdown.\\r\\n\\r\\n\\r\\nWe've included a basic analytics query to get you started. Use the `Edit` button below each section to configure it or add more sections.\"}\",\"halfWidth\":null,\"conditionalVisibility\":null},{\"type\":3,\"content\":\"{\"version\":\"KqlItem/1.0\",\"query\":\"union withsource=TableName *\\n| summarize Count=count() by TableName\\n| render barchart\",\"showQuery\":false,\"size\":1,\"aggregation\":0,\"showAnnotations\":false}\",\"halfWidth\":null,\"conditionalVisibility\":null}],\"isLocked\":false}",
                Category = "workbook",
                Description = "Sample workbook",
                Kind = WorkbookSharedTypeKind.Shared,
                Tags =
                  {
                ["TagSample01"] = "sample01",
                ["TagSample02"] = "sample02",
                  },
            };
            string sourceId = $"/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}";
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, resourceName, data, sourceId);
            var result = lro.Value;
            Assert.True(result is ApplicationInsightsWorkbookResource);
        }
    }
}
