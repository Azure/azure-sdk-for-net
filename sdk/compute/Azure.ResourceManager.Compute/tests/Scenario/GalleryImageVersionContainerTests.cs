// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Compute.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class GalleryImageVersionContainerTests : VirtualMachineTestBase
    {
        private Gallery _gallery;
        private GalleryImage _galleryImage;
        private VirtualMachine _vm;

        public GalleryImageVersionContainerTests(bool isAsync)
           : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<GalleryImageVersionContainer> GetGalleryImageVersionContainerAsync()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            var galleryName = Recording.GenerateAssetName("testGallery_");
            var galleryImageName = Recording.GenerateAssetName("testGalleryImage_");
            var galleryImageData = ResourceDataHelper.GetBasicGalleryData(DefaultLocation);
            var identifier = ResourceDataHelper.GetGalleryImageIdentifier(
                    Recording.GenerateAssetName("publisher"),
                    Recording.GenerateAssetName("offer"),
                    Recording.GenerateAssetName("sku"));
            var input = ResourceDataHelper.GetBasicGalleryImageData(DefaultLocation, OperatingSystemTypes.Linux, identifier);
            var lroGallery = await _resourceGroup.GetGalleries().CreateOrUpdateAsync(galleryName, galleryImageData);
            _gallery = lroGallery.Value;
            var lroGalleryImage = await _gallery.GetGalleryImages().CreateOrUpdateAsync(galleryImageName, input);
            _galleryImage = lroGalleryImage.Value;
            return _galleryImage.GetGalleryImageVersions();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var container = await GetGalleryImageVersionContainerAsync();
            var vmContainer = await GetVirtualMachineContainerAsync();
            var vmName = Recording.GenerateAssetName("testVM-");
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var vmInput = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            var lroVm = await vmContainer.CreateOrUpdateAsync(vmName, vmInput);
            _vm = lroVm.Value;
            await _vm.DeallocateAsync();
            await _vm.GeneralizeAsync();
            var vmID = _vm.Id;
            var BasicGalleryImageVersionData = ResourceDataHelper.GetBasicGalleryImageVersionData(DefaultLocation, vmID);
            var GalleryImageVersionName = "1.0.0";
            var lroImageVersion = await container.CreateOrUpdateAsync(GalleryImageVersionName, BasicGalleryImageVersionData);
            GalleryImageVersion imageVersion = lroImageVersion.Value;
            Assert.AreEqual(GalleryImageVersionName, imageVersion.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExists()
        {
            var container = await GetGalleryImageVersionContainerAsync();
            var vmContainer = await GetVirtualMachineContainerAsync();
            var vmName = Recording.GenerateAssetName("testVM-");
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var vmInput = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            var lroVm = await vmContainer.CreateOrUpdateAsync(vmName, vmInput);
            _vm = lroVm.Value;
            await _vm.DeallocateAsync();
            await _vm.GeneralizeAsync();
            var vmID = _vm.Id;
            var BasicGalleryImageVersionData = ResourceDataHelper.GetBasicGalleryImageVersionData(DefaultLocation, vmID);
            var GalleryImageVersionName = "1.0.0";
            var lroImageVersion = await container.CreateOrUpdateAsync(GalleryImageVersionName, BasicGalleryImageVersionData);
            GalleryImageVersion imageVersion = lroImageVersion.Value;
            Assert.IsTrue(await container.CheckIfExistsAsync(GalleryImageVersionName));
            Assert.IsFalse(await container.CheckIfExistsAsync(GalleryImageVersionName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.CheckIfExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var container = await GetGalleryImageVersionContainerAsync();
            var vmContainer = await GetVirtualMachineContainerAsync();
            var vmName = Recording.GenerateAssetName("testVM-");
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var vmInput = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            var lroVm = await vmContainer.CreateOrUpdateAsync(vmName, vmInput);
            _vm = lroVm.Value;
            await _vm.DeallocateAsync();
            await _vm.GeneralizeAsync();
            var vmID = _vm.Id;
            var BasicGalleryImageVersionData = ResourceDataHelper.GetBasicGalleryImageVersionData(DefaultLocation, vmID);
            var GalleryImageVersionName = "1.0.0";
            var lroImageVersion = await container.CreateOrUpdateAsync(GalleryImageVersionName, BasicGalleryImageVersionData);
            GalleryImageVersion imageversion = lroImageVersion.Value;
            GalleryImageVersion imageversion2 = await container.GetAsync(GalleryImageVersionName);

            ResourceDataHelper.AssertGalleryImageVersion(imageversion.Data, imageversion2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var container = await GetGalleryImageVersionContainerAsync();
            var vmContainer = await GetVirtualMachineContainerAsync();
            var vmName = Recording.GenerateAssetName("testVM-");
            var nic = await CreateBasicDependenciesOfVirtualMachineAsync();
            var vmInput = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, vmName, nic.Id);
            var lroVm = await vmContainer.CreateOrUpdateAsync(vmName, vmInput);
            _vm = lroVm.Value;
            await _vm.DeallocateAsync();
            await _vm.GeneralizeAsync();
            var vmID = _vm.Id;
            var BasicGalleryImageVersionData = ResourceDataHelper.GetBasicGalleryImageVersionData(DefaultLocation, vmID);
            var GalleryImageVersionName1 = "1.0.0";
            var GalleryImageVersionName2 = "1.0.1";
            var input1 = BasicGalleryImageVersionData;
            var input2 = BasicGalleryImageVersionData;
            _ = await container.CreateOrUpdateAsync(GalleryImageVersionName1, input1);
            _ = await container.CreateOrUpdateAsync(GalleryImageVersionName2, input2);
            int count = 0;
            await foreach (var galleryImageVersion in container.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }
    }
}
