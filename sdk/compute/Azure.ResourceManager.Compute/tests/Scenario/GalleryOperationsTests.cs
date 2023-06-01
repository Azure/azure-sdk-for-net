// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Compute.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class GalleryOperationsTests : ComputeTestBase
    {
        private ResourceGroupResource _resourceGroup;

        public GalleryOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<GalleryResource> CreateGalleryAsync(string name)
        {
            _resourceGroup = await CreateResourceGroupAsync();
            var collection = _resourceGroup.GetGalleries();
            var input = ResourceDataHelper.GetBasicGalleryData(DefaultLocation);
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, input);
            return lro.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var name = Recording.GenerateAssetName("testGallery_");
            var gallery = await CreateGalleryAsync(name);
            await gallery.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var name = Recording.GenerateAssetName("testGallery_");
            var gallery = await CreateGalleryAsync(name);
            GalleryResource gallery2 = await gallery.GetAsync();

            ResourceDataHelper.AssertGallery(gallery.Data, gallery2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task Update()
        {
            var name = Recording.GenerateAssetName("testGallery_");
            var gallery = await CreateGalleryAsync(name);
            var description = "This is a gallery for test";
            var update = new GalleryPatch()
            {
                Description = description
            };
            var lro = await gallery.UpdateAsync(WaitUntil.Completed, update);
            GalleryResource updatedGallery = lro.Value;

            Assert.AreEqual(description, updatedGallery.Data.Description);
        }

        [RecordedTest]
        [TestCase(null)]
        [TestCase(true)]
        [TestCase(false)]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/36714")]
        public async Task SetTags(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            var name = Recording.GenerateAssetName("testGallery_");
            var gallery = await CreateGalleryAsync(name);
            var tags = new Dictionary<string, string>()
            {
                { "key", "value" }
            };
            GalleryResource updatedGallery = await gallery.SetTagsAsync(tags);

            Assert.AreEqual(tags, updatedGallery.Data.Tags);
        }
    }
}
