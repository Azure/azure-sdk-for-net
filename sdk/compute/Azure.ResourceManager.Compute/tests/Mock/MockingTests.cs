// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.ResourceManager.Compute.Mocking;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources;
using Moq;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests.Mock
{
    public class MockingTests
    {
        [Test]
        public void Mocking_GetResourcesById()
        {
            #region mocking data
            var subscriptionId = Guid.NewGuid().ToString();
            var resourceGroupName = "myRg";
            var vmId = VirtualMachineResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, "myVm");
            var availablitySetId = AvailabilitySetResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, "mySet");
            #endregion

            #region mocking setup
            var clientMock = new Mock<ArmClient>();
            var clientExtensionMock = new Mock<ComputeArmClientMockingExtension>();
            var vmMock = new Mock<VirtualMachineResource>();
            var setMock = new Mock<AvailabilitySetResource>();
            // setup some data in the result
            vmMock.Setup(vm => vm.Id).Returns(vmId);
            setMock.Setup(set => set.Id).Returns(availablitySetId);
            // first mock: mock the same method in mocking extension class
            clientExtensionMock.Setup(e => e.GetVirtualMachineResource(vmId)).Returns(vmMock.Object);
            clientExtensionMock.Setup(e => e.GetAvailabilitySetResource(availablitySetId)).Returns(setMock.Object);
            // second mock: mock the GetCachedClient method on the "extendee"
            clientMock.Setup(c => c.GetCachedClient(It.IsAny<Func<ArmClient, ComputeArmClientMockingExtension>>())).Returns(clientExtensionMock.Object);
            #endregion

            // the mocking test
            var client = clientMock.Object;
            var vm = client.GetVirtualMachineResource(vmId);
            var set = client.GetAvailabilitySetResource(availablitySetId);

            Assert.AreEqual(vmId, vm.Id);
            Assert.AreEqual(availablitySetId, set.Id);
        }

        [Test]
        public async Task Mocking_GetCollectionAndCreate()
        {
            #region mocking data
            var subscriptionId = Guid.NewGuid().ToString();
            var resourceGroupName = "myRg";
            var setName = "mySet";
            var vmName = "myVm";
            var setId = AvailabilitySetResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, setName);
            var setData = ArmComputeModelFactory.AvailabilitySetData(setId, setName, platformFaultDomainCount: 10);
            var vmId = VirtualMachineResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, vmName);
            var vmData = ArmComputeModelFactory.VirtualMachineData(vmId, vmName, availabilitySetId: setId);
            #endregion

            #region mocking setup
            var rgMock = new Mock<ResourceGroupResource>();
            var rgExtensionMock = new Mock<ComputeResourceGroupMockingExtension>();
            // for availability set
            var setCollectionMock = new Mock<AvailabilitySetCollection>();
            var setMock = new Mock<AvailabilitySetResource>();
            var setLroMock = new Mock<ArmOperation<AvailabilitySetResource>>();
            // for virtual machine
            var vmCollectionMock = new Mock<VirtualMachineCollection>();
            var vmMock = new Mock<VirtualMachineResource>();
            var vmLroMock = new Mock<ArmOperation<VirtualMachineResource>>();
            // setup some data in the result
            setMock.Setup(set => set.Id).Returns(setId);
            setMock.Setup(set => set.Data).Returns(setData);
            vmMock.Setup(vm => vm.Id).Returns(vmId);
            vmMock.Setup(vm => vm.Data).Returns(vmData);
            // first mock: mock the same method in mocking extension class
            rgExtensionMock.Setup(e => e.GetAvailabilitySets()).Returns(setCollectionMock.Object);
            rgExtensionMock.Setup(e => e.GetVirtualMachines()).Returns(vmCollectionMock.Object);
            // second mock: mock the GetCachedClient method on the "extendee"
            rgMock.Setup(rg => rg.GetCachedClient(It.IsAny<Func<ArmClient, ComputeResourceGroupMockingExtension>>())).Returns(rgExtensionMock.Object);
            // setup the mock on the collection for CreateOrUpdate method
            setCollectionMock.Setup(c => c.CreateOrUpdateAsync(WaitUntil.Completed, setName, setData, default)).ReturnsAsync(setLroMock.Object);
            setLroMock.Setup(lro => lro.Value).Returns(setMock.Object);
            vmCollectionMock.Setup(c => c.CreateOrUpdateAsync(WaitUntil.Completed, vmName, vmData, default)).ReturnsAsync(vmLroMock.Object);
            vmLroMock.Setup(lro => lro.Value).Returns(vmMock.Object);
            #endregion

            // the mocking test
            var rg = rgMock.Object;
            var setCollection = rg.GetAvailabilitySets();
            var setLro = await setCollection.CreateOrUpdateAsync(WaitUntil.Completed, setName, setData);
            var setResource = setLro.Value;
            var vmCollection = rg.GetVirtualMachines();
            var vmLro = await vmCollection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, vmData);
            var vmResource = vmLro.Value;

            Assert.AreEqual(setId, setResource.Id);
            Assert.AreEqual(setData, setResource.Data);
            Assert.AreEqual(vmId, vmResource.Id);
            Assert.AreEqual(vmData, vmResource.Data);
        }

        [Test]
        public async Task Mocking_GetResourceByName()
        {
            #region mocking data
            var subscriptionId = Guid.NewGuid().ToString();
            var resourceGroupName = "myRg";
            var setName = "mySet";
            var setId = AvailabilitySetResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, setName);
            var setData = ArmComputeModelFactory.AvailabilitySetData(setId, setName, platformFaultDomainCount: 10);
            #endregion

            #region mocking setup
            var rgMock = new Mock<ResourceGroupResource>();
            var rgExtensionMock = new Mock<ComputeResourceGroupMockingExtension>();
            var setMock = new Mock<AvailabilitySetResource>();
            // setup some data in the result
            setMock.Setup(set => set.Id).Returns(setId);
            setMock.Setup(set => set.Data).Returns(setData);
            // first mock: mock the same method in mocking extension class
            rgExtensionMock.Setup(e => e.GetAvailabilitySetAsync(setName, default)).ReturnsAsync(Response.FromValue(setMock.Object, null));
            // second mock: mock the GetCachedClient method on the "extendee"
            rgMock.Setup(rg => rg.GetCachedClient(It.IsAny<Func<ArmClient, ComputeResourceGroupMockingExtension>>())).Returns(rgExtensionMock.Object);
            #endregion

            var rg = rgMock.Object;
            AvailabilitySetResource setResource = await rg.GetAvailabilitySetAsync(setName);

            Assert.AreEqual(setId, setResource.Id);
            Assert.AreEqual(setData, setResource.Data);
        }
    }
}
