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

        private async Task<WatchlistItemResource> CreateWatchlistItemAsync(string itemName)
        {
            var collection = (await CreateResourceGroupAsync()).GetWatchlists(workspaceName);
            var input = ResourceDataHelpers.GetWatchlistData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testWatchlists-"), input);
            var watchlistResource = lro.Value;
            var itemCollection = watchlistResource.GetWatchlistItems();
            var itemInput = ResourceDataHelpers.GetWatchlistItemData();
            var lroi = await itemCollection.CreateOrUpdateAsync(WaitUntil.Completed, itemName, itemInput);
            return lroi.Value;
        }

        [TestCase]
        public async Task WatchlistItemResourceApiTests()
        {
            //1.Get
            var itemName = Recording.GenerateAssetName("testWatchlistItems-");
            var item1 = await CreateWatchlistItemAsync(itemName);
            WatchlistItemResource item2 = await item1.GetAsync();

            ResourceDataHelpers.AssertWatchlistItemData(item1.Data, item2.Data);
            //2.Delete
            await item1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
