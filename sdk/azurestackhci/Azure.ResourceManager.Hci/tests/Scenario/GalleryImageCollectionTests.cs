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
using NUnit.Framework;

namespace Azure.ResourceManager.Hci.Tests
{
    public class GalleryImageCollectionTests: HciManagementTestBase
    {
        public GalleryImageCollectionTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        // Gallery image download is very expensive and can take time depending on network speed.
        // Test is live only because it consistently exceeds the global ten seconds timeout.
        [LiveOnly]
        [RecordedTest]
        public async Task GalleryImageCreateGetList()
        {
            var location = AzureLocation.EastUS;

            var galleryImageCollection = ResourceGroup.GetGalleryImages();

            var galleryImage = await CreateGalleryImageAsync();
            if (await RetryUntilSuccessOrTimeout(() => ProvisioningStateSucceeded(galleryImage), TimeSpan.FromSeconds(100)))
            {
                Assert.AreEqual(galleryImage.Data.Name, galleryImage.Data.Name);
                Assert.AreEqual(galleryImage.Data.OSType, OperatingSystemType.Linux);
            }
            Assert.AreEqual(galleryImage.Data.ProvisioningState, ProvisioningStateEnum.Succeeded);

            await foreach (GalleryImageResource galleryImageFromList in galleryImageCollection)
            {
                Assert.AreEqual(galleryImageFromList.Data.OSType, OperatingSystemType.Linux);
                Assert.AreEqual(galleryImageFromList.Data.Location, location);
            }
        }
    }
}
