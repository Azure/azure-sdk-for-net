// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.ConnectedVMwarevSphere.Models;
using Azure.ResourceManager.ConnectedVMwarevSphere.Tests.Helpers;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.ConnectedVMwarevSphere.Tests.tests.Tests
{
    public class VirtualMachineTemplateTests : ConnectedVMwareTestBase
    {
        public VirtualMachineTemplateTests(bool isAsync) : base(isAsync)
        {
        }

        private async Task<VirtualMachineTemplateCollection> GetVirtualMachineTemplateCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetVirtualMachineTemplates();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateDelete()
        {
            var vmtemplateName = Recording.GenerateAssetName("testvmtemplate");
            var _virtualMachineTemplateCollection = await GetVirtualMachineTemplateCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var virtualMachineTemplateBody = new VirtualMachineTemplateData(DefaultLocation);
            virtualMachineTemplateBody.MoRefId = "vm-70";
            virtualMachineTemplateBody.VCenterId = VcenterId;
            virtualMachineTemplateBody.ExtendedLocation = _extendedLocation;
            // create virtual machine template
            VirtualMachineTemplateResource vmtemplate1 = (await _virtualMachineTemplateCollection.CreateOrUpdateAsync(WaitUntil.Completed, vmtemplateName, virtualMachineTemplateBody)).Value;
            Assert.IsNotNull(vmtemplate1);
            Assert.AreEqual(vmtemplate1.Id.Name, vmtemplateName);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var vmtemplateName = Recording.GenerateAssetName("testvmtemplate");
            var _virtualMachineTemplateCollection = await GetVirtualMachineTemplateCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var virtualMachineTemplateBody = new VirtualMachineTemplateData(DefaultLocation);
            virtualMachineTemplateBody.MoRefId = "vm-74";
            virtualMachineTemplateBody.VCenterId = VcenterId;
            virtualMachineTemplateBody.ExtendedLocation = _extendedLocation;
            // create virtual machine template
            VirtualMachineTemplateResource vmtemplate1 = (await _virtualMachineTemplateCollection.CreateOrUpdateAsync(WaitUntil.Completed, vmtemplateName, virtualMachineTemplateBody)).Value;
            Assert.IsNotNull(vmtemplate1);
            Assert.AreEqual(vmtemplate1.Id.Name, vmtemplateName);
            // get vm template
            vmtemplate1 = await _virtualMachineTemplateCollection.GetAsync(vmtemplateName);
            Assert.AreEqual(vmtemplate1.Id.Name, vmtemplateName);
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            var vmtemplateName = Recording.GenerateAssetName("testvmtemplate");
            var _virtualMachineTemplateCollection = await GetVirtualMachineTemplateCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var virtualMachineTemplateBody = new VirtualMachineTemplateData(DefaultLocation);
            virtualMachineTemplateBody.MoRefId = "vm-72";
            virtualMachineTemplateBody.VCenterId = VcenterId;
            virtualMachineTemplateBody.ExtendedLocation = _extendedLocation;
            // create virtual machine template
            VirtualMachineTemplateResource vmtemplate1 = (await _virtualMachineTemplateCollection.CreateOrUpdateAsync(WaitUntil.Completed, vmtemplateName, virtualMachineTemplateBody)).Value;
            Assert.IsNotNull(vmtemplate1);
            Assert.AreEqual(vmtemplate1.Id.Name, vmtemplateName);
            // check for exists vm template
            bool exists = await _virtualMachineTemplateCollection.ExistsAsync(vmtemplateName);
            Assert.IsTrue(exists);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var vmtemplateName = Recording.GenerateAssetName("testvmtemplate");
            var _virtualMachineTemplateCollection = await GetVirtualMachineTemplateCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var virtualMachineTemplateBody = new VirtualMachineTemplateData(DefaultLocation);
            virtualMachineTemplateBody.MoRefId = "vm-11788";
            virtualMachineTemplateBody.VCenterId = VcenterId;
            virtualMachineTemplateBody.ExtendedLocation = _extendedLocation;
            // create virtual machine template
            VirtualMachineTemplateResource vmtemplate1 = (await _virtualMachineTemplateCollection.CreateOrUpdateAsync(WaitUntil.Completed, vmtemplateName, virtualMachineTemplateBody)).Value;
            Assert.IsNotNull(vmtemplate1);
            Assert.AreEqual(vmtemplate1.Id.Name, vmtemplateName);
            int count = 0;
            await foreach (var vmtemplate in _virtualMachineTemplateCollection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAllInSubscription()
        {
            var vmtemplateName = Recording.GenerateAssetName("testvmtemplate");
            var _virtualMachineTemplateCollection = await GetVirtualMachineTemplateCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var virtualMachineTemplateBody = new VirtualMachineTemplateData(DefaultLocation);
            virtualMachineTemplateBody.MoRefId = "vm-75";
            virtualMachineTemplateBody.VCenterId = VcenterId;
            virtualMachineTemplateBody.ExtendedLocation = _extendedLocation;
            // create virtual machine template
            VirtualMachineTemplateResource vmtemplate1 = (await _virtualMachineTemplateCollection.CreateOrUpdateAsync(WaitUntil.Completed, vmtemplateName, virtualMachineTemplateBody)).Value;
            Assert.IsNotNull(vmtemplate1);
            Assert.AreEqual(vmtemplate1.Id.Name, vmtemplateName);
            vmtemplate1 = null;
            await foreach (var vmtemplate in DefaultSubscription.GetVirtualMachineTemplatesAsync())
            {
                if (vmtemplate.Data.Name == vmtemplateName)
                {
                    vmtemplate1 = vmtemplate;
                }
            }
            Assert.NotNull(vmtemplate1);
        }
    }
}
