// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Hci.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Hci.Tests
{
    public class MarketplaceGalleryImageOperationTests: HciManagementTestBase
    {
        public MarketplaceGalleryImageOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        // Marketplace gallery image download is very expensive and can take time depending on network speed.
        // Test is live only because it consistently exceeds the global ten seconds timeout.
        [LiveOnly]
        [RecordedTest]
        public async Task MarketplaceGalleryImageGetDelete()
        {
            var marketplaceMarketplaceGalleryImage = await CreateMarketplaceGalleryImageAsync();

            MarketplaceGalleryImageResource marketplaceMarketplaceGalleryImageFromGet = await marketplaceMarketplaceGalleryImage.GetAsync();
            if (await RetryUntilSuccessOrTimeout(() => ProvisioningStateSucceeded(marketplaceMarketplaceGalleryImageFromGet), TimeSpan.FromSeconds(3000)))
            {
                Assert.AreEqual(marketplaceMarketplaceGalleryImageFromGet.Data.Name, marketplaceMarketplaceGalleryImage.Data.Name);
                Assert.AreEqual(marketplaceMarketplaceGalleryImageFromGet.Data.OSType, OperatingSystemType.Windows);
            }
            Assert.AreEqual(marketplaceMarketplaceGalleryImageFromGet.Data.ProvisioningState, ProvisioningStateEnum.Succeeded);

            await marketplaceMarketplaceGalleryImageFromGet.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase(null)]
        [TestCase(true)]
        // Marketplace gallery image download is very expensive and can take time depending on network speed.
        // Test is live only because it consistently exceeds the global ten seconds timeout.
        [LiveOnly]
        [RecordedTest]
        public async Task MarketplaceGalleryImageSetTags(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            var marketplaceMarketplaceGalleryImage = await CreateMarketplaceGalleryImageAsync();

            var tags = new Dictionary<string, string>()
            {
                { "key", "value" }
            };
            MarketplaceGalleryImageResource updatedMarketplaceGalleryImage = await marketplaceMarketplaceGalleryImage.SetTagsAsync(tags);
            if (await RetryUntilSuccessOrTimeout(() => ProvisioningStateSucceeded(updatedMarketplaceGalleryImage), TimeSpan.FromSeconds(100)))
            {
                Assert.AreEqual(tags, updatedMarketplaceGalleryImage.Data.Tags);
            }
            Assert.AreEqual(updatedMarketplaceGalleryImage.Data.ProvisioningState, ProvisioningStateEnum.Succeeded);
        }
    }
}
