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
    public class BookmarkCollectionTests : SecurityInsightsManagementTestBase
    {
        public BookmarkCollectionTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<BookmarkCollection> GetBookmarkCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetBookmarks(workspaceName);
        }

        [TestCase]
        public async Task BookmarkCollectionApiTests()
        {
            //1.CreateOrUpdate
            var collection = await GetBookmarkCollectionAsync();
            var name = Recording.GenerateAssetName("Bookmarks-");
            var name2 = Recording.GenerateAssetName("Bookmarks-");
            var name3 = Recording.GenerateAssetName("Bookmarks-");
            var input = ResourceDataHelpers.GetBookmarkData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            BookmarkResource bookmark1 = lro.Value;
            Assert.AreEqual(name, bookmark1.Data.Name);
            //2.Get
            BookmarkResource bookmark2 = await collection.GetAsync(name);
            ResourceDataHelpers.AssertBookmarkData(bookmark1.Data, bookmark2.Data);
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
