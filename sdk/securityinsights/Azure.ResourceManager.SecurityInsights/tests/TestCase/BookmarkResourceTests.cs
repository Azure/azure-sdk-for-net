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
    public class BookmarkResourceTests : SecurityInsightsManagementTestBase
    {
        public BookmarkResourceTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<ResourceGroupResource> GetResourceGroupAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup;
        }

        private async Task<SecurityInsightsBookmarkResource> CreateBookmarkAsync(OperationalInsightsWorkspaceSecurityInsightsResource operationalInsights, string bookmarkName)
        {
            var collection = operationalInsights.GetSecurityInsightsBookmarks();
            var input = ResourceDataHelpers.GetBookmarkData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, bookmarkName, input);
            return lro.Value;
        }

        [TestCase]
        public async Task BookmarkResourceApiTests()
        {
            //0.prepare
            var resourceGroup = await GetResourceGroupAsync();
            var workspaceName = groupName + "ws";
            var ResourceID = CreateResourceIdentifier("db1ab6f0-4769-4b27-930e-01e2ef9c123c", groupName, workspaceName);
            var operationalInsights = new OperationalInsightsWorkspaceSecurityInsightsResource(Client, ResourceID);
            //1.Get
            var bookmarkName = "6a8d6ea6-04d5-49d7-8169-ffca8b0ced59";
            var bookmark1 = await CreateBookmarkAsync(operationalInsights, bookmarkName);
            SecurityInsightsBookmarkResource bookmark2 = await bookmark1.GetAsync();

            ResourceDataHelpers.AssertBookmarkData(bookmark1.Data, bookmark2.Data);
            //2.Delete
            await bookmark1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
