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

        private async Task<BookmarkResource> CreateBookmarkAsync(string bookmarkName)
        {
            var collection = (await CreateResourceGroupAsync()).GetBookmarks(workspaceName);
            var input = ResourceDataHelpers.GetBookmarkData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, bookmarkName, input);
            return lro.Value;
        }

        [TestCase]
        public async Task BookmarkResourceApiTests()
        {
            //1.Get
            var bookmark = Recording.GenerateAssetName("testBookmark-");
            var bookmark1 = await CreateBookmarkAsync(bookmark);
            BookmarkResource bookmark2 = await bookmark1.GetAsync();

            ResourceDataHelpers.AssertBookmarkData(bookmark1.Data, bookmark2.Data);
            //2.Delete
            await bookmark1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
