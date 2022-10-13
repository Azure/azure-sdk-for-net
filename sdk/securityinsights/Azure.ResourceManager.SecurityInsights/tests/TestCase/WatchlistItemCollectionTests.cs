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
    public class WatchlistItemCollectionTests : SecurityInsightsManagementTestBase
    {
        public WatchlistItemCollectionTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<WatchlistItemCollection> GetWatchlistItemCollectionAsync()
        {
            var collection = (await CreateResourceGroupAsync()).GetWatchlists(workspaceName);
            var input = ResourceDataHelpers.GetWatchlistData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testWatchlists-"), input);
            var watchlistResource =  lro.Value;
            return watchlistResource.GetWatchlistItems();
        }

        [TestCase]
        public async Task WatchlistItemCollectionApiTests()
        {
            //1.CreateOrUpdate
            var collection = await GetWatchlistItemCollectionAsync();
            var name = Recording.GenerateAssetName("WatchlistItems-");
            var name2 = Recording.GenerateAssetName("WatchlistItems-");
            var name3 = Recording.GenerateAssetName("WatchlistItems-");
            var input = ResourceDataHelpers.GetWatchlistItemData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            WatchlistItemResource item1 = lro.Value;
            Assert.AreEqual(name, item1.Data.Name);
            //2.Get
            WatchlistItemResource item2 = await collection.GetAsync(name);
            ResourceDataHelpers.AssertWatchlistItemData(item1.Data, item2.Data);
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
            Assert.IsFalse(await collection.ExistsAsync(name + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }
    }
}
