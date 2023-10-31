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
using NUnit.Framework;

namespace Azure.ResourceManager.ArcVm.Tests
{
    public class MarketplaceGalleryImageCollectionTests: ArcVmManagementTestBase
    {
        public MarketplaceGalleryImageCollectionTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        // Marketplace gallery image download is very expensive and can take time depending on network speed.
        // So before running live / record please make sure the test region have the capacity for create a new one.
        //[PlaybackOnly("Live test for marketplace gallery image is not necessary")]
        [RecordedTest]
        public async Task CreateGetList()
        {
            var location = AzureLocation.EastUS;

            var marketplaceGalleryImageCollection = ResourceGroup.GetMarketplaceGalleryImages();
            var marketplaceGalleryImage = await CreateMarketplaceGalleryImageAsync();
            if (await RetryUntilSuccessOrTimeout(() => ProvisioningStateSucceeded(marketplaceGalleryImage), TimeSpan.FromSeconds(3000)))
            {
                Assert.AreEqual(marketplaceGalleryImage.Data.Name, marketplaceGalleryImage.Data.Name);
                Assert.AreEqual(marketplaceGalleryImage.Data.OSType, OperatingSystemType.Windows);
            }
            Assert.AreEqual(marketplaceGalleryImage.Data.ProvisioningState, ProvisioningStateEnum.Succeeded);

            await foreach (MarketplaceGalleryImageResource marketplaceGalleryImageFromList in marketplaceGalleryImageCollection)
            {
                Assert.AreEqual(marketplaceGalleryImageFromList.Data.OSType, OperatingSystemType.Windows);
                Assert.AreEqual(marketplaceGalleryImageFromList.Data.Location, location);
            }
        }
    }
}
