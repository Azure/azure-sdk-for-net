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
    public class GalleryImageVersionOperationsTests : ComputeTestBase
    {
        private ResourceGroup _resourceGroup;
        private Gallery _gallery;
        private GalleryImage _galleryImage;
        protected GenericResourceContainer _genericResourceContainer;
        private GalleryImageVersion _galleryImageVersion;
        public GalleryImageVersionOperationsTests(bool isAsync)
        : base(isAsync)// , RecordedTestMode.Record)
        {
        }

        protected async Task<GenericResource> CreateVirtualNetwork()
        {
            _genericResourceContainer = DefaultSubscription.GetGenericResources();
            var vnetName = Recording.GenerateAssetName("testVNet-");
            var subnetName = Recording.GenerateAssetName("testSubnet-");
            ResourceIdentifier vnetId = $"{_resourceGroup.Id}/providers/Microsoft.Network/virtualNetworks/{vnetName}";
            var addressSpaces = new Dictionary<string, object>()
            {
                { "addressPrefixes", new List<string>() { "10.0.0.0/16" } }
            };
            var subnet = new Dictionary<string, object>()
            {
                { "name", subnetName },
                { "properties", new Dictionary<string, object>()
                {
                    { "addressPrefix", "10.0.2.0/24" }
                } }
            };
            var subnets = new List<object>() { subnet };
            var input = new GenericResourceData(DefaultLocation)
            {
                Properties = new Dictionary<string, object>()
                {
                    { "addressSpace", addressSpaces },
                    { "subnets", subnets }
                }
            };
            return await _genericResourceContainer.CreateOrUpdateAsync(vnetId, input);
        }

        private async Task<GenericResource> CreateNetworkInterface(ResourceIdentifier subnetId)
        {
            _genericResourceContainer = DefaultSubscription.GetGenericResources();
            var nicName = Recording.GenerateAssetName("testNic-");
            ResourceIdentifier nicId = $"{_resourceGroup.Id}/providers/Microsoft.Network/networkInterfaces/{nicName}";
            var input = new GenericResourceData(DefaultLocation)
            {
                Properties = new Dictionary<string, object>()
                {
                    { "ipConfigurations", new List<object>()
                        {
                            new Dictionary<string, object>()
                            {
                                { "name", "internal" },
                                { "properties", new Dictionary<string, object>()
                                    {
                                        { "subnet", new Dictionary<string, object>() { { "id", subnetId.ToString() } } }
                                    }
                                }
                            }
                        }
                    }
                }
            };
            return await _genericResourceContainer.CreateOrUpdateAsync(nicId, input);
        }

        protected ResourceIdentifier GetSubnetId(GenericResource vnet)
        {
            var properties = vnet.Data.Properties as IDictionary<string, object>;
            var subnets = properties["subnets"] as IEnumerable<object>;
            var subnet = subnets.First() as IDictionary<string, object>;
            return subnet["id"] as string;
        }

        private async Task<GalleryImageVersion> CreateGalleryImageVersionAsync(string galleryImageVersionName)
        {
            _resourceGroup = await CreateResourceGroupAsync();
            var galleryName = Recording.GenerateAssetName("testGallery");
            var galleryImageName = "1.0.0";
            var galleryInput = ResourceDataHelper.GetBasicGalleryData(DefaultLocation);
            var lroGallery = await _resourceGroup.GetGalleries().CreateOrUpdateAsync(galleryName, galleryInput);
            _gallery = lroGallery.Value;
            var identifier = ResourceDataHelper.GetGalleryImageIdentifier(
                    Recording.GenerateAssetName("publisher"),
                    Recording.GenerateAssetName("offer"),
                    Recording.GenerateAssetName("sku"));
            var imageInput = ResourceDataHelper.GetBasicGalleryImageData(DefaultLocation, OperatingSystemTypes.Linux, identifier);
            var vmContainer = _resourceGroup.GetVirtualMachines();
            var vmName = Recording.GenerateAssetName("testVM-");
            var vnet = await CreateVirtualNetwork();
            var nic = await CreateNetworkInterface(GetSubnetId(vnet));
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
