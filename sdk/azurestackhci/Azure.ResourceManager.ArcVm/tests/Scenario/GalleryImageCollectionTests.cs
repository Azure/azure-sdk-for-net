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
    public class GalleryImageCollectionTests: ArcVmManagementTestBase
    {
        public GalleryImageCollectionTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        // Gallery image download is very expensive and can take time depending on network speed.
        // So before running live / record please make sure the test region have the capacity for create a new one.
        //[PlaybackOnly("Live test for gallery image is not necessary")]
        [RecordedTest]
        public async Task CreateGetList()
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
