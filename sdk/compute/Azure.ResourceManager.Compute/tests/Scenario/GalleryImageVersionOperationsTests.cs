// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Compute.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class GalleryImageVersionOperationsTests : VirtualMachineTestBase
    {
        private ResourceGroup _versionResourceGroup;
        private Gallery _gallery;
        private GalleryImage _galleryImage;
        private GalleryImageVersion _galleryImageVersion;
        public GalleryImageVersionOperationsTests(bool isAsync)
        : base(isAsync)// , RecordedTestMode.Record)
        {
        }

        private async Task<GalleryImageVersion> CreateGalleryImageVersionAsync(string galleryImageVersionName)
        {
            _versionResourceGroup = await CreateResourceGroupAsync();
            var galleryName = Recording.GenerateAssetName("testGallery");
            var galleryImageName = "1.0.0";
            var galleryInput = ResourceDataHelper.GetBasicGalleryData(DefaultLocation);
            var lroGallery = await _versionResourceGroup.GetGalleries().CreateOrUpdateAsync(galleryName, galleryInput);
            _gallery = lroGallery.Value;
            var identifier = ResourceDataHelper.GetGalleryImageIdentifier(
                    Recording.GenerateAssetName("publisher"),
                    Recording.GenerateAssetName("offer"),
                    Recording.GenerateAssetName("sku"));
            var imageInput = ResourceDataHelper.GetBasicGalleryImageData(DefaultLocation, OperatingSystemTypes.Linux, identifier);
            var vmContainer = _versionResourceGroup.GetVirtualMachines();
            var vmName = Recording.GenerateAssetName("testVM-");
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var vmInput = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            var lroVm = await vmContainer.CreateOrUpdateAsync(vmName, vmInput);
            var _vm = lroVm.Value;
            await _vm.DeallocateAsync();
            await _vm.GeneralizeAsync();
            var vmID = _vm.Id;
            var imageVersionInput = ResourceDataHelper.GetBasicGalleryImageVersionData(DefaultLocation, vmID);
            var lroGalleryImage = await _gallery.GetGalleryImages().CreateOrUpdateAsync(galleryImageName, imageInput);
            _galleryImage = lroGalleryImage.Value;
            var lroGalleryImageVersion =  await _galleryImage.GetGalleryImageVersions().CreateOrUpdateAsync(galleryImageVersionName, imageVersionInput);
            _galleryImageVersion = lroGalleryImageVersion.Value;
            return _galleryImageVersion;
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            var name = "1.0.0";
            var imageVersion = await CreateGalleryImageVersionAsync(name);
            await imageVersion.DeleteAsync();
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var name = "1.0.0";
            var imageVersion = await CreateGalleryImageVersionAsync(name);
            GalleryImageVersion imageVersion2 = await imageVersion.GetAsync();

            ResourceDataHelper.AssertGalleryImageVersion(imageVersion.Data, imageVersion2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task SetTags()
        {
            var name = "1.0.0";
            var imageVersion = await CreateGalleryImageVersionAsync(name);
            var tags = new Dictionary<string, string>()
            {
                { "key", "value" }
            };
            GalleryImageVersion updatedGalleryImageVersion = await imageVersion.SetTagsAsync(tags);

            Assert.AreEqual(tags, updatedGalleryImageVersion.Data.Tags);
        }
    }
}
