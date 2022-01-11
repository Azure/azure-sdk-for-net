// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ConnectedVMwarevSphere;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.ConnectedVMwarevSphere.Models;
using Azure.ResourceManager.ConnectedVMwarevSphere.Tests.Helpers;

namespace Azure.ResourceManager.ConnectedVMwarevSphere.Tests.tests.Tests
{
    public class VirtualMachineTests : ConnectedVMwareTestBase
    {
        private VirtualMachineCollection _virtualMachineCollection;
        public VirtualMachineTests(bool isAsync) : base(isAsync)
        {
        }

        [AsyncOnly]
        [TestCase]
        [RecordedTest]
        public async Task CreateDeleteVirtualMachine()
        {
            string vmName = Recording.GenerateAssetName("testvm");
            _virtualMachineCollection = _resourceGroup.GetVirtualMachines();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                Type = EXTENDED_LOCATION_TYPE
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
            //create virtual machine
            VirtualMachine vm1 = (await _virtualMachineCollection.CreateOrUpdateAsync(vmName, virtualMachineBody)).Value;
            Assert.IsNotNull(vm1);
            Assert.AreEqual(vm1.Id.Name, vmName);
        }
    }
}
