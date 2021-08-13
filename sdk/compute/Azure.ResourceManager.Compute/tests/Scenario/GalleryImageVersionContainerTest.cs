// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Tests.Helpers;
using NUnit.Framework;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;

//checkifexits,createorupdate,get,getall,GetAllAsGenericResources,GetIfExist,StartCreateOrUpdate
namespace Azure.ResourceManager.Compute.Tests
{
    public class GalleryImageVersionContainerTest : ComputeTestBase
    {
        private ResourceGroup _resourceGroup;
        private Gallery _gallery;
        //private GalleryImage image = await container.CreateOrUpdateAsync(name, BasicGalleryImageData);
        private GalleryImage _galleryImage;
        public GalleryImageVersionContainerTest(bool isAsync)
           : base(isAsync , RecordedTestMode.Record)
        {
        }
        private GalleryImageVersionData BasicGalleryImageVersionData
        {
            get
            {
                var identifier = GalleryImageHelper.GetGalleryImageIdentifier(
                    Recording.GenerateAssetName("publisher"),
                    Recording.GenerateAssetName("offer"),
                    Recording.GenerateAssetName("sku"));
                return GalleryImageVersionHelper
            }
        }

        private async Task<GalleryImageVersionContainer> GetGalleryImageVersionContainerAsync()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            var galleryName = Recording.GenerateAssetName("testGallery_");
            var galleryImageName = Recording.GenerateAssetName("testGalleryImage_");
            var input = GalleryHelper.GetBasicGalleryData(DefaultLocation);
            var identifier = GalleryImageHelper.GetGalleryImageIdentifier(
                    Recording.GenerateAssetName("publisher"),
                    Recording.GenerateAssetName("offer"),
                    Recording.GenerateAssetName("sku"));
            var input_2 = GalleryImageHelper.GetBasicGalleryImageData(DefaultLocation, OperatingSystemTypes.Linux, identifier);
            _gallery = await _resourceGroup.GetGalleries().CreateOrUpdateAsync(galleryName, input);
            _galleryImage = await _gallery.GetGalleryImages().CreateOrUpdateAsync(galleryImageName, input_2);
            return _galleryImage.GetGalleryImageVersions();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var container = await GetGalleryImageVersionContainerAsync();
            var GalleryImageVersionName = Recording.GenerateAssetName("testGalleryImageVersion_");
            GalleryImageVersion imageVersion = await container.CreateOrUpdateAsync(GalleryImageVersionName, BasicGalleryImageVersionData);
            Assert.AreEqual(GalleryImageVersionName, imageVersion.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExists()
        {
            var container = await GetGalleryImageVersionContainerAsync();
            var GalleryImageVerrsionName = Recording.GenerateAssetName("testGalleryImageVersion_");
            GalleryImageVersion imageVersion = await container.CreateOrUpdateAsync(GalleryImageVerrsionName, BasicGalleryImageVersionData);
            Assert.IsTrue(await container.CheckIfExistsAsync(GalleryImageVerrsionName));
            Assert.IsFalse(await container.CheckIfExistsAsync(GalleryImageVerrsionName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.CheckIfExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var container = await GetGalleryImageVersionContainerAsync();
            var GalleryImageVerrsionName = Recording.GenerateAssetName("testGalleryImageVersion_");
            GalleryImageVersion imageversion = await container.CreateOrUpdateAsync(GalleryImageVerrsionName, BasicGalleryImageVersionData);
            GalleryImageVersion imageversion2 = await container.GetAsync(GalleryImageVerrsionName);

            GalleryImageHelper.AssertGalleryImage(imageversion.Data, imageversion2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var container = await GetGalleryImageVersionContainerAsync();
            var GalleryImageVersionName1 = Recording.GenerateAssetName("testGalleryImageVersion_");
            var GalleryImageVersionName2 = Recording.GenerateAssetName("testGalleryImageVersion_");
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

        [TestCase]
        [RecordedTest]
        public async Task StartCreateOrUpdate()
        {
            var container = await GetGalleryImageVersionContainerAsync();
            var GalleryImageVersionName = Recording.GenerateAssetName("testGalleryImageVersion_");
            var identifier = GalleryImageHelper.GetGalleryImageIdentifier(
        Recording.GenerateAssetName("publisher"),
        Recording.GenerateAssetName("offer"),
        Recording.GenerateAssetName("sku"));
            var input = GalleryImageHelper.GetBasicGalleryImageData(DefaultLocation, OperatingSystemTypes.Linux, identifier);
            //var groupOp = await container.StartCreateOrUpdateAsync(GalleryImageVersionName, input);
            //DedicatedHostGroup group = await groupOp.WaitForCompletionAsync();
            //Assert.AreEqual(groupName, group.Data.Name);
        }
    }
}
