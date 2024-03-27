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
            var clientExtensionMock = new Mock<MockableComputeArmClient>();
            var vmMock = new Mock<VirtualMachineResource>();
            var setMock = new Mock<AvailabilitySetResource>();
            // setup some data in the result
            vmMock.Setup(vm => vm.Id).Returns(vmId);
            setMock.Setup(set => set.Id).Returns(availablitySetId);
            // first mock: mock the same method in mocking extension class
            clientExtensionMock.Setup(e => e.GetVirtualMachineResource(vmId)).Returns(vmMock.Object);
            clientExtensionMock.Setup(e => e.GetAvailabilitySetResource(availablitySetId)).Returns(setMock.Object);
            // second mock: mock the GetCachedClient method on the "extendee"
            clientMock.Setup(c => c.GetCachedClient(It.IsAny<Func<ArmClient, MockableComputeArmClient>>())).Returns(clientExtensionMock.Object);
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
            var rgExtensionMock = new Mock<MockableComputeResourceGroupResource>();
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
            rgMock.Setup(rg => rg.GetCachedClient(It.IsAny<Func<ArmClient, MockableComputeResourceGroupResource>>())).Returns(rgExtensionMock.Object);
            // setup the mock on the collection for CreateOrUpdate method
            setCollectionMock.Setup(c => c.CreateOrUpdateAsync(WaitUntil.Completed, setName, setData, default)).ReturnsAsync(setLroMock.Object);
            setLroMock.Setup(lro => lro.Value).Returns(setMock.Object);
            vmCollectionMock.Setup(c => c.CreateOrUpdateAsync(WaitUntil.Completed, vmName, vmData, default)).ReturnsAsync(vmLroMock.Object);
            vmLroMock.Setup(lro => lro.Value).Returns(vmMock.Object);
            #endregion

            // the mocking test
            var rg = rgMock.Object;
            var setCollection = rg.GetAvailabilitySets();
            var setLro = await setCollection.CreateOrUpdateAsync(WaitUntil.Completed, setName, setData, default);
            var setResource = setLro.Value;
            var vmCollection = rg.GetVirtualMachines();
            var vmLro = await vmCollection.CreateOrUpdateAsync(WaitUntil.Completed, vmName, vmData, default);
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
            var rgExtensionMock = new Mock<MockableComputeResourceGroupResource>();
            var setMock = new Mock<AvailabilitySetResource>();
            // setup some data in the result
            setMock.Setup(set => set.Id).Returns(setId);
            setMock.Setup(set => set.Data).Returns(setData);
            // first mock: mock the same method in mocking extension class
            rgExtensionMock.Setup(e => e.GetAvailabilitySetAsync(setName, default)).ReturnsAsync(Response.FromValue(setMock.Object, null));
            // second mock: mock the GetCachedClient method on the "extendee"
            rgMock.Setup(rg => rg.GetCachedClient(It.IsAny<Func<ArmClient, MockableComputeResourceGroupResource>>())).Returns(rgExtensionMock.Object);
            #endregion

            var rg = rgMock.Object;
            AvailabilitySetResource setResource = await rg.GetAvailabilitySetAsync(setName);

            Assert.AreEqual(setId, setResource.Id);
            Assert.AreEqual(setData, setResource.Data);
        }

        [Test]
        public async Task Mocking_PageableResultOnCollection()
        {
            #region mocking data
            var subscriptionId = Guid.NewGuid().ToString();
            var resourceGroupName = "myRg";
            var setName1 = "mySet1";
            var setName2 = "mySet2";
            var setId1 = AvailabilitySetResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, setName1);
            var setId2 = AvailabilitySetResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, setName2);
            var setData1 = ArmComputeModelFactory.AvailabilitySetData(setId1, setName1, platformFaultDomainCount: 10);
            var setData2 = ArmComputeModelFactory.AvailabilitySetData(setId2, setName2, platformUpdateDomainCount: 20);
            #endregion

            #region mocking setup
            var rgMock = new Mock<ResourceGroupResource>();
            var rgExtensionMock = new Mock<MockableComputeResourceGroupResource>();
            var setMock1 = new Mock<AvailabilitySetResource>();
            var setMock2 = new Mock<AvailabilitySetResource>();
            var setCollectionMock = new Mock<AvailabilitySetCollection>();
            // setup some data in the result
            setMock1.Setup(set => set.Id).Returns(setId1);
            setMock1.Setup(set => set.Data).Returns(setData1);
            setMock2.Setup(set => set.Id).Returns(setId2);
            setMock2.Setup(set => set.Data).Returns(setData2);
            // first mock: mock the same method in mocking extension class
            rgExtensionMock.Setup(e => e.GetAvailabilitySets()).Returns(setCollectionMock.Object);
            // second mock: mock the GetCachedClient method on the "extendee"
            rgMock.Setup(rg => rg.GetCachedClient(It.IsAny<Func<ArmClient, MockableComputeResourceGroupResource>>())).Returns(rgExtensionMock.Object);
            // setup the collection
            var setPageableResult = AsyncPageable<AvailabilitySetResource>.FromPages(new[] { Page<AvailabilitySetResource>.FromValues(new[] { setMock1.Object, setMock2.Object }, null, null) });
            setCollectionMock.Setup(c => c.GetAllAsync(default)).Returns(setPageableResult);
            #endregion

            var rg = rgMock.Object;
            var setCollection = rg.GetAvailabilitySets();
            var count = 0;
            await foreach (var set in setCollection.GetAllAsync())
            {
                switch (count)
                {
                    case 0:
                        Assert.AreEqual(setId1, set.Id);
                        Assert.AreEqual(setData1, set.Data);
                        break;
                    case 1:
                        Assert.AreEqual(setId2, set.Id);
                        Assert.AreEqual(setData2, set.Data);
                        break;
                    default:
                        Assert.Fail("We should only contain 2 items in the result");
                        break;
                }
                count++;
            }
        }

        [Test]
        public async Task Mocking_PageableResultOnExtension()
        {
            #region mocking data
            var subscriptionId = Guid.NewGuid().ToString();
            var setName1 = "mySet1";
            var setName2 = "mySet2";
            var setId1 = AvailabilitySetResource.CreateResourceIdentifier(subscriptionId, "myRg1", setName1);
            var setId2 = AvailabilitySetResource.CreateResourceIdentifier(subscriptionId, "myRg2", setName2);
            var setData1 = ArmComputeModelFactory.AvailabilitySetData(setId1, setName1, platformFaultDomainCount: 10);
            var setData2 = ArmComputeModelFactory.AvailabilitySetData(setId2, setName2, platformUpdateDomainCount: 20);
            #endregion

            #region mocking setup
            var subsMock = new Mock<SubscriptionResource>();
            var subsExtensionMock = new Mock<MockableComputeSubscriptionResource>();
            var setMock1 = new Mock<AvailabilitySetResource>();
            var setMock2 = new Mock<AvailabilitySetResource>();
            // setup some data in the result
            setMock1.Setup(set => set.Id).Returns(setId1);
            setMock1.Setup(set => set.Data).Returns(setData1);
            setMock2.Setup(set => set.Id).Returns(setId2);
            setMock2.Setup(set => set.Data).Returns(setData2);
            // first mock: mock the same method in mocking extension class
            var setPageableResult = AsyncPageable<AvailabilitySetResource>.FromPages(new[] { Page<AvailabilitySetResource>.FromValues(new[] { setMock1.Object, setMock2.Object }, null, null) });
            subsExtensionMock.Setup(e => e.GetAvailabilitySetsAsync(null, default)).Returns(setPageableResult);
            // second mock: mock the GetCachedClient method on the "extendee"
            subsMock.Setup(rg => rg.GetCachedClient(It.IsAny<Func<ArmClient, MockableComputeSubscriptionResource>>())).Returns(subsExtensionMock.Object);
            #endregion

            var subscription = subsMock.Object;
            var count = 0;
            await foreach (var set in subscription.GetAvailabilitySetsAsync())
            {
                switch (count)
                {
                    case 0:
                        Assert.AreEqual(setId1, set.Id);
                        Assert.AreEqual(setData1, set.Data);
                        break;
                    case 1:
                        Assert.AreEqual(setId2, set.Id);
                        Assert.AreEqual(setData2, set.Data);
                        break;
                    default:
                        Assert.Fail("We should only contain 2 items in the result");
                        break;
                }
                count++;
            }
        }
    }
}
