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
    public class VirtualMachineTests : ConnectedVMwareTestBase
    {
        public VirtualMachineTests(bool isAsync) : base(isAsync)
        {
        }

        private async Task<VirtualMachineCollection> GetVirtualMachineCollectionAsync()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            return resourceGroup.GetVirtualMachines();
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateDelete()
        {
            var vmName = Recording.GenerateAssetName("testvm");
            var _virtualMachineCollection = await GetVirtualMachineCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var _placementProfile = new PlacementProfile()
            {
                ResourcePoolId = _resourcePoolId
            };
            var virtualMachineBody = new VirtualMachineData(DefaultLocation);
            virtualMachineBody.VCenterId = VcenterId;
            virtualMachineBody.ExtendedLocation = _extendedLocation;
            virtualMachineBody.PlacementProfile = _placementProfile;
            virtualMachineBody.TemplateId = _vmTemplateId;
            // create virtual machine
            VirtualMachineResource vm1 = (await _virtualMachineCollection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, virtualMachineBody)).Value;
            Assert.IsNotNull(vm1);
            Assert.AreEqual(vm1.Id.Name, vmName);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            var vmName = Recording.GenerateAssetName("testvm");
            var _virtualMachineCollection = await GetVirtualMachineCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var _placementProfile = new PlacementProfile()
            {
                ResourcePoolId = _resourcePoolId
            };
            var virtualMachineBody = new VirtualMachineData(DefaultLocation);
            virtualMachineBody.VCenterId = VcenterId;
            virtualMachineBody.ExtendedLocation = _extendedLocation;
            virtualMachineBody.PlacementProfile = _placementProfile;
            virtualMachineBody.TemplateId = _vmTemplateId;
            // create virtual machine
            VirtualMachineResource vm1 = (await _virtualMachineCollection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, virtualMachineBody)).Value;
            Assert.IsNotNull(vm1);
            Assert.AreEqual(vm1.Id.Name, vmName);
            // get virtual machine
            vm1 = await _virtualMachineCollection.GetAsync(vmName);
            Assert.AreEqual(vm1.Id.Name, vmName);
        }

        [TestCase]
        [RecordedTest]
        public async Task Exists()
        {
            var vmName = Recording.GenerateAssetName("testvm");
            var _virtualMachineCollection = await GetVirtualMachineCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var _placementProfile = new PlacementProfile()
            {
                ResourcePoolId = _resourcePoolId
            };
            var virtualMachineBody = new VirtualMachineData(DefaultLocation);
            virtualMachineBody.VCenterId = VcenterId;
            virtualMachineBody.ExtendedLocation = _extendedLocation;
            virtualMachineBody.PlacementProfile = _placementProfile;
            virtualMachineBody.TemplateId = _vmTemplateId;
            // create virtual machine
            VirtualMachineResource vm1 = (await _virtualMachineCollection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, virtualMachineBody)).Value;
            Assert.IsNotNull(vm1);
            Assert.AreEqual(vm1.Id.Name, vmName);
            // check for exists virtual machine
            bool exists = await _virtualMachineCollection.ExistsAsync(vmName);
            Assert.IsTrue(exists);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAll()
        {
            var vmName = Recording.GenerateAssetName("testvm");
            var _virtualMachineCollection = await GetVirtualMachineCollectionAsync();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                ExtendedLocationType = EXTENDED_LOCATION_TYPE
            };
            var _placementProfile = new PlacementProfile()
            {
                ResourcePoolId = _resourcePoolId
            };
            var virtualMachineBody = new VirtualMachineData(DefaultLocation);
            virtualMachineBody.VCenterId = VcenterId;
            virtualMachineBody.ExtendedLocation = _extendedLocation;
            virtualMachineBody.PlacementProfile = _placementProfile;
            virtualMachineBody.TemplateId = _vmTemplateId;
            // create virtual machine
            VirtualMachineResource vm1 = (await _virtualMachineCollection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, virtualMachineBody)).Value;
            Assert.IsNotNull(vm1);
            Assert.AreEqual(vm1.Id.Name, vmName);
            int count = 0;
            await foreach (var vm in _virtualMachineCollection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 1);
        }
    }
}
