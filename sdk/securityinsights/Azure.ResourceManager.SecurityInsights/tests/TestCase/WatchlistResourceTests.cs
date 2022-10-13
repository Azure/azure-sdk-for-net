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
    public class WatchlistResourceTests : SecurityInsightsManagementTestBase
    {
        public WatchlistResourceTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<WatchlistResource> CreateWatchlistAsync(string watchName)
        {
            var collection = (await CreateResourceGroupAsync()).GetWatchlists(workspaceName);
            var input = ResourceDataHelpers.GetWatchlistData();
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, watchName, input);
            return lro.Value;
        }

        [TestCase]
        public async Task WatchlistResourceApiTests()
        {
            //1.Get
            var watchName = Recording.GenerateAssetName("testWatchlists-");
            var watch1 = await CreateWatchlistAsync(watchName);
            WatchlistResource watch2 = await watch1.GetAsync();

            ResourceDataHelpers.AssertWatchlistData(watch1.Data, watch2.Data);
            //2.Delete
            await watch1.DeleteAsync(WaitUntil.Completed);
        }
    }
}
