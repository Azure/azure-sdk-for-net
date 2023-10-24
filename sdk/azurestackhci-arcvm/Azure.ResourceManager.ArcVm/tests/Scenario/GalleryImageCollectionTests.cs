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
        [RecordedTest]
        public async Task CreateGetList()
        {
            var location = AzureLocation.EastUS;
            var resourceGroup = await CreateResourceGroup(DefaultSubscription, "hci-galleryImage-rg", location);
            var galleryImageCollection = resourceGroup.GetGalleryImages();
            var galleryImageName = Recording.GenerateAssetName("hci-galleryImage");
            var galleryImage = await CreateGalleryImageAsync(resourceGroup, galleryImageName, location);
            var galleryImageData = galleryImage.Data;
            Assert.AreEqual(galleryImageData.Name, galleryImageName);
            Assert.AreEqual(galleryImageData.Location, location);

            GalleryImageResource galleryImageFromGet = await galleryImageCollection.GetAsync(galleryImageName);
            Assert.AreEqual(galleryImageFromGet.Data.Name, galleryImageName);
            Assert.AreEqual(galleryImageFromGet.Data.Location, location);

            await foreach (GalleryImageResource galleryImageFromList in galleryImageCollection)
            {
                Assert.AreEqual(galleryImageFromList.Data.Name, galleryImageName);
                Assert.AreEqual(galleryImageFromList.Data.Location, location);
            }
        }
    }
}
