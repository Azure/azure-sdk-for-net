// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ArcVm.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ArcVm.Tests
{
    public class MarketplaceGalleryImageOperationTests: ArcVmManagementTestBase
    {
        public MarketplaceGalleryImageOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        // Marketplace gallery image download is very expensive and can take time depending on network speed.
        // So before running live / record please make sure the test region have the capacity for create a new one.
        //[PlaybackOnly("Live test for marketplace gallery image is not necessary")]
        [RecordedTest]
        public async Task GetDelete()
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
        // So before running live / record please make sure the test region have the capacity for create a new one.
        //[PlaybackOnly("Live test for marketplace gallery image is not necessary")]
        [RecordedTest]
        public async Task SetTags(bool? useTagResource)
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
