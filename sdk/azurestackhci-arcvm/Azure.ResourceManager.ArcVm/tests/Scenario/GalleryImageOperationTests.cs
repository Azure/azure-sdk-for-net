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
    public class GalleryImageOperationTests: ArcVmManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;

        private GalleryImageResource _galleryImage;

        public GalleryImageOperationTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        private async Task<GalleryImageResource> CreateGalleryImageAsync(string galleryImageName)
        {
            var location = AzureLocation.WestUS;
            _resourceGroup = await CreateResourceGroup(DefaultSubscription, "hci-dotnet-test-rg", location);
            _galleryImage = await CreateGalleryImageAsync(_resourceGroup, "hci-gallery-image", location);
            return _galleryImage;
        }

        [TestCase]
        [RecordedTest]
        public async Task GetDelete()
        {
            var galleryImageName = Recording.GenerateAssetName("hci-gallery-image");
            var galleryImage = await CreateGalleryImageAsync(galleryImageName);

            GalleryImageResource galleryImageFromGet = await galleryImage.GetAsync();
            Assert.AreEqual(galleryImageFromGet.Data.Name, galleryImageName);
            Assert.AreEqual(galleryImageFromGet.Data.OSType, OperatingSystemType.Linux);

            await galleryImageFromGet.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase(null)]
        [TestCase(true)]
        public async Task SetTags(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            var galleryImageName = Recording.GenerateAssetName("hci-gallery-image");
            var galleryImage = await CreateGalleryImageAsync(galleryImageName);
            var tags = new Dictionary<string, string>()
            {
                { "key", "value" }
            };
            GalleryImageResource updatedGalleryImage = await galleryImage.SetTagsAsync(tags);
            Assert.AreEqual(tags, updatedGalleryImage.Data.Tags);
        }
    }
}
