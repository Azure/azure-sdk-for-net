// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
    public class GalleryImageVersionContainerTests : ComputeTestBase
    {
        private ResourceGroup _resourceGroup;
        private Gallery _gallery;
        private GalleryImage _galleryImage;
        private Disk _disk;
        protected GenericResourceContainer _genericResourceContainer;
        private VirtualMachine _VM;
        public GalleryImageVersionContainerTests(bool isAsync)
           : base(isAsync , RecordedTestMode.Record)
        {
        }
        private async Task<GalleryImageVersionContainer> GetGalleryImageVersionContainerAsync()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            /*var diskContainer = _resourceGroup.GetDisks();
            var diskName = Recording.GenerateAssetName("testDisk-");
            var diskInput = ResourceDataHelper.GetEmptyDiskData(DefaultLocation);
            _disk = await diskContainer.CreateOrUpdateAsync(diskName, diskInput);
            string diskID = _disk.Id;*/
            var galleryName = Recording.GenerateAssetName("testGallery_");
            var galleryImageName = Recording.GenerateAssetName("testGalleryImage_");
            var input = ResourceDataHelper.GetBasicGalleryData(DefaultLocation);
            var identifier = ResourceDataHelper.GetGalleryImageIdentifier(
                    Recording.GenerateAssetName("publisher"),
                    Recording.GenerateAssetName("offer"),
                    Recording.GenerateAssetName("sku"));
            var input_2 = ResourceDataHelper.GetBasicGalleryImageData(DefaultLocation, OperatingSystemTypes.Linux, identifier);
            _gallery = await _resourceGroup.GetGalleries().CreateOrUpdateAsync(galleryName, input);
            _galleryImage = await _gallery.GetGalleryImages().CreateOrUpdateAsync(galleryImageName, input_2);
            return _galleryImage.GetGalleryImageVersions();
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
            var input = new GenericResourceData()
            {
                Location = DefaultLocation,
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
            var input = new GenericResourceData()
            {
                Location = DefaultLocation,
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

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            var container = await GetGalleryImageVersionContainerAsync();
            /*var diskContainer = _resourceGroup.GetDisks();
            var diskName = Recording.GenerateAssetName("testDisk-");
            var diskInput = ResourceDataHelper.GetEmptyDiskData(DefaultLocation);
            _disk = await diskContainer.CreateOrUpdateAsync(diskName, diskInput);
            var GalleryImageVersionName = "1.0.0";
            var diskID = _disk.Id;
            var BasicGalleryImageVersionData = ResourceDataHelper.GetBasicGalleryImageVersionData(DefaultLocation,diskID);*/
            var VMContainer = _resourceGroup.GetVirtualMachines();
            var VMName = Recording.GenerateAssetName("testVM-");
            var vnet = await CreateVirtualNetwork();
            var nic = await CreateNetworkInterface(GetSubnetId(vnet));
            var VMInput = ResourceDataHelper.GetBasicLinuxVirtualMachineData(DefaultLocation, VMName, nic.Id);
            _VM = await VMContainer.CreateOrUpdateAsync(VMName, VMInput);
            var GalleryImageVersionName = "1.0.0";
            var VMID = _VM.Id;
            var BasicGalleryImageVersionData = ResourceDataHelper.GetBasicGalleryImageVersionData(DefaultLocation, VMID);
            GalleryImageVersion imageVersion = await container.CreateOrUpdateAsync(GalleryImageVersionName, BasicGalleryImageVersionData);
            Assert.AreEqual(GalleryImageVersionName, imageVersion.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckIfExists()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            var container = await GetGalleryImageVersionContainerAsync();
            var diskContainer = _resourceGroup.GetDisks();
            var diskName = Recording.GenerateAssetName("testDisk-");
            var diskInput = ResourceDataHelper.GetEmptyDiskData(DefaultLocation);
            _disk = await diskContainer.CreateOrUpdateAsync(diskName, diskInput);
            var GalleryImageVersionName = "1.0.0";
            var diskID = _disk.Id;
            var BasicGalleryImageVersionData = ResourceDataHelper.GetBasicGalleryImageVersionData(DefaultLocation, diskID);
            GalleryImageVersion imageVersion = await container.CreateOrUpdateAsync(GalleryImageVersionName, BasicGalleryImageVersionData);
            Assert.IsTrue(await container.CheckIfExistsAsync(GalleryImageVersionName));
            Assert.IsFalse(await container.CheckIfExistsAsync(GalleryImageVersionName + "1"));

            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await container.CheckIfExistsAsync(null));
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            var container = await GetGalleryImageVersionContainerAsync();
            var diskContainer = _resourceGroup.GetDisks();
            var diskName = Recording.GenerateAssetName("testDisk-");
            var diskInput = ResourceDataHelper.GetEmptyDiskData(DefaultLocation);
            _disk = await diskContainer.CreateOrUpdateAsync(diskName, diskInput);
            var GalleryImageVersionName = "1.0.0";
            var diskID = _disk.Id;
            var BasicGalleryImageVersionData = ResourceDataHelper.GetBasicGalleryImageVersionData(DefaultLocation, diskID);
            GalleryImageVersion imageversion = await container.CreateOrUpdateAsync(GalleryImageVersionName, BasicGalleryImageVersionData);
            GalleryImageVersion imageversion2 = await container.GetAsync(GalleryImageVersionName);

            ResourceDataHelper.AssertGalleryImageVersion(imageversion.Data, imageversion2.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            var container = await GetGalleryImageVersionContainerAsync();
            var diskContainer = _resourceGroup.GetDisks();
            var diskName = Recording.GenerateAssetName("testDisk-");
            var diskInput = ResourceDataHelper.GetEmptyDiskData(DefaultLocation);
            _disk = await diskContainer.CreateOrUpdateAsync(diskName, diskInput);
            var GalleryImageVersionName1 = "1.0.0";
            var GalleryImageVersionName2 = "1.0.0";
            var diskID = _disk.Id;
            var BasicGalleryImageVersionData = ResourceDataHelper.GetBasicGalleryImageVersionData(DefaultLocation, diskID);
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
            _resourceGroup = await CreateResourceGroupAsync();
            var container = await GetGalleryImageVersionContainerAsync();
            var diskContainer = _resourceGroup.GetDisks();
            var diskName = Recording.GenerateAssetName("testDisk-");
            var diskInput = ResourceDataHelper.GetEmptyDiskData(DefaultLocation);
            _disk = await diskContainer.CreateOrUpdateAsync(diskName, diskInput);
            var GalleryImageVersionName = "1.0.0";
            var diskID = _disk.Id;
            var BasicGalleryImageVersionData = ResourceDataHelper.GetBasicGalleryImageVersionData(DefaultLocation, diskID);
            GalleryImageVersion imageVersion = await container.CreateOrUpdateAsync(GalleryImageVersionName, BasicGalleryImageVersionData);
            Assert.AreEqual(GalleryImageVersionName, imageVersion.Data.Name);
        }
    }
}
