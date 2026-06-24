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
    public class GalleryImageOperationsTests : ComputeTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private GalleryResource _gallery;

        public GalleryImageOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<GalleryResource> CreateGalleryAsync(string galleryName)
        {
            _resourceGroup = await CreateResourceGroupAsync();
            var galleryInput = ResourceDataHelper.GetBasicGalleryData(DefaultLocation);
            var lro = await _resourceGroup.GetGalleries().CreateOrUpdateAsync(WaitUntil.Completed, galleryName, galleryInput);
            _gallery = lro.Value;
            return _gallery;
        }

        private async Task<GalleryImageResource> CreateGalleryImageAsync(string galleryImageName)
        {
            var galleryName = Recording.GenerateAssetName("testGallery_");
            _gallery = await CreateGalleryAsync(galleryName);
            var identifier = ResourceDataHelper.GetGalleryImageIdentifier(
                    Recording.GenerateAssetName("publisher"),
                    Recording.GenerateAssetName("offer"),
                    Recording.GenerateAssetName("sku"));
            var imageInput = ResourceDataHelper.GetBasicGalleryImageData(DefaultLocation, SupportedOperatingSystemType.Linux, identifier);
            var lro = await _gallery.GetGalleryImages().CreateOrUpdateAsync(WaitUntil.Completed, galleryImageName, imageInput);
            return lro.Value;
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var name = Recording.GenerateAssetName("testGallery_");
            var image = await CreateGalleryImageAsync(name);
            await image.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var name = Recording.GenerateAssetName("testGallery_");
            var image = await CreateGalleryImageAsync(name);
            GalleryImageResource image2 = await image.GetAsync();

            ResourceDataHelper.AssertGalleryImage(image.Data, image2.Data);
        }

        [TestCase]
        [RecordedTest]
        // TODO: Re-enable once the new mgmt generator emits patch-model serialization with all
        // properties Optional-gated (regardless of underlying model's required-ness). The new
        // generator faithfully serializes GalleryImageProperties' required fields (osState,
        // identifier) even when wrapped by GalleryImageUpdate, producing PATCH bodies like
        // {"properties":{...,"osState":"Generalized","identifier":null}} which Azure rejects
        // and which diverge from the AutoRest-era patch behavior.
        // Tracking: https://github.com/Azure/azure-sdk-for-net/issues/59095
        [Ignore("Generator regression: PATCH body emits required-but-unset osState/identifier from shared GalleryImageProperties. See #59095.")]
        public async Task Update()
        {
            var name = Recording.GenerateAssetName("testGallery_");
            var image = await CreateGalleryImageAsync(name);
            var description = "This is a gallery for test";
            var update = new GalleryImagePatch()
            {
                OSType = SupportedOperatingSystemType.Linux, // We have to put this here, otherwise we get a 409 Changing property 'galleryImage.properties.osType' is not allowed.
                Description = description
            };
            var lro = await image.UpdateAsync(WaitUntil.Completed, update);
            GalleryImageResource updatedGalleryImage = lro.Value;

            Assert.AreEqual(description, updatedGalleryImage.Data.Description);
        }

        [RecordedTest]
        [TestCase(null)]
        [TestCase(true)]
        // TODO: Re-enable once the new mgmt generator supports the equivalent of autorest.md's
        // `update-required-copy: GalleryImage: OSType`. The old hand-rolled SetTags copied OSType from
        // the current resource into the patch (otherwise Azure returns 409 on PATCH without osType).
        // The new generated SetTags sends only Tags, causing recording mismatch in playback and 409 in live.
        // Tracking: https://github.com/Azure/azure-sdk-for-net/issues/59095
        [TestCase(false, Ignore = "Generator regression: SetTags PATCH must include osType for GalleryImage. See TODO above.")]
        public async Task SetTags(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            var name = Recording.GenerateAssetName("testGallery_");
            var image = await CreateGalleryImageAsync(name);
            var tags = new Dictionary<string, string>()
            {
                { "key", "value" }
            };
            GalleryImageResource updatedGalleryImage = await image.SetTagsAsync(tags);

            Assert.AreEqual(tags, updatedGalleryImage.Data.Tags);
        }
    }
}
