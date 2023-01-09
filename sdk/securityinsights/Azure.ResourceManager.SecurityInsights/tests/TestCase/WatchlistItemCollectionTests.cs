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

        private async Task<ResourceGroupResource> GetResourceGroupAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup;
        }
        private async Task<SecurityInsightsWatchlistItemCollection> GetWatchlistItemCollectionAsync(OperationalInsightsWorkspaceSecurityInsightsResource operationalInsights)
        {
            var collection = operationalInsights.GetSecurityInsightsWatchlists();
            var input = ResourceDataHelpers.GetWatchlistData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, Recording.GenerateAssetName("testWatchlists-"), input);
            var watchlistResource =  lro.Value;
            return watchlistResource.GetSecurityInsightsWatchlistItems();
        }

        [TestCase]
        public async Task WatchlistItemCollectionApiTests()
        {
            //0.prepare
            var resourceGroup = await GetResourceGroupAsync();
            var workspaceName = groupName + "ws";
            var ResourceID = CreateResourceIdentifier("db1ab6f0-4769-4b27-930e-01e2ef9c123c", groupName, workspaceName);
            var operationalInsights = new OperationalInsightsWorkspaceSecurityInsightsResource(Client, ResourceID);
            //1.CreateOrUpdate
            var collection = await GetWatchlistItemCollectionAsync(operationalInsights);
            var name = "6d37a904-d199-43ff-892b-53653b784122";
            var name2 = "6d37a904-d199-43ff-892b-53653b784126";
            var name3 = "6d37a904-d199-43ff-892b-53653b784128";
            var input = ResourceDataHelpers.GetWatchlistItemData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            SecurityInsightsWatchlistItemResource item1 = lro.Value;
            Assert.AreEqual(name, item1.Data.Name);
            //2.Get
            SecurityInsightsWatchlistItemResource item2 = await collection.GetAsync(name);
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
            Assert.IsFalse(await collection.ExistsAsync("6d37a904-d199-43ff-892b-53653b784123"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await collection.ExistsAsync(null));
        }
    }
}
