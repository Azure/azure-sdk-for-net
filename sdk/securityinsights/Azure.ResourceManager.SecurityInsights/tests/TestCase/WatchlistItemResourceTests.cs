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
    public class WatchlistItemResourceTests : SecurityInsightsManagementTestBase
    {
        public WatchlistItemResourceTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<ResourceGroupResource> GetResourceGroupAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup;
        }
        private async Task<SecurityInsightsWatchlistItemResource> CreateWatchlistItemAsync(OperationalInsightsWorkspaceSecurityInsightsResource operationalInsights, string itemName)
        {
            var collection = operationalInsights.GetSecurityInsightsWatchlists();
            var input = ResourceDataHelpers.GetWatchlistData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testWatchlists-"), input);
            var watchlistResource = lro.Value;
            var itemCollection = watchlistResource.GetSecurityInsightsWatchlistItems();
            var itemInput = ResourceDataHelpers.GetWatchlistItemData();
            var lroi = await itemCollection.CreateOrUpdateAsync(WaitUntil.Completed, itemName, itemInput);
            return lroi.Value;
        }

        [TestCase]
        public async Task WatchlistItemResourceApiTests()
        {
            //0.prepare
            var resourceGroup = await GetResourceGroupAsync();
            var workspaceName = groupName + "ws";
            var ResourceID = CreateResourceIdentifier("db1ab6f0-4769-4b27-930e-01e2ef9c123c", groupName, workspaceName);
            var operationalInsights = new OperationalInsightsWorkspaceSecurityInsightsResource(Client, ResourceID);
            //1.Get
            var itemName = "6d37a904-d199-43ff-892b-53653b784122";
            var item1 = await CreateWatchlistItemAsync(operationalInsights, itemName);
            SecurityInsightsWatchlistItemResource item2 = await item1.GetAsync();

            ResourceDataHelpers.AssertWatchlistItemData(item1.Data, item2.Data);
            //2.Delete
            await item1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
