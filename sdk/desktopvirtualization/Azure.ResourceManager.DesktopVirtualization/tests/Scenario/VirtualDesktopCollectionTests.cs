// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DesktopVirtualization.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.DesktopVirtualization.Tests.Tests
{
    public class VirtualDesktopCollectionTests : DesktopVirtualizationManagementClientBase
    {
        public VirtualDesktopCollectionTests() : base(true)
        {
        }

        public VirtualDesktopCollectionTests(bool isAsync) : base(isAsync)
        {
        }

        public VirtualDesktopCollectionTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        [TestCase]
        public async Task DesktopApplicationCrud()
        {
            string hostPoolName = "testDesktopApplicationCrudHP";
            string applicationGroupName = "testDesktopApplicationCrudAG";

            string resourceGroupName = Recording.GetVariable("DESKTOPVIRTUALIZATION_RESOURCE_GROUP", DefaultResourceGroupName);
            ResourceGroupResource rg = (ResourceGroupResource)await ResourceGroups.GetAsync(resourceGroupName);
            Assert.IsNotNull(rg);
            HostPoolCollection hostPoolCollection = rg.GetHostPools();
            HostPoolData hostPoolData = new HostPoolData(
                DefaultLocation,
                HostPoolType.Pooled,
                HostPoolLoadBalancerType.BreadthFirst,
                PreferredAppGroupType.Desktop);

            ArmOperation<HostPoolResource> opHostPoolCreate = await hostPoolCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                hostPoolName,
                hostPoolData);

            VirtualApplicationGroupCollection agCollection = rg.GetVirtualApplicationGroups();
            VirtualApplicationGroupData agData = new VirtualApplicationGroupData(DefaultLocation, opHostPoolCreate.Value.Data.Id, VirtualApplicationGroupType.Desktop);

            ArmOperation<VirtualApplicationGroupResource> opApplicationGroupCreate = await agCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                applicationGroupName,
                agData);

            Assert.IsNotNull(opApplicationGroupCreate);
            Assert.IsTrue(opApplicationGroupCreate.HasCompleted);
            Assert.AreEqual(opApplicationGroupCreate.Value.Data.Name, applicationGroupName);

            VirtualApplicationGroupResource desktopApplicationGroup = opApplicationGroupCreate.Value;

            VirtualDesktopCollection desktopCollection = desktopApplicationGroup.GetVirtualDesktops();

            AsyncPageable<VirtualDesktopResource> desktops = desktopCollection.GetAllAsync();

            Assert.IsNotNull(desktops);

            List<VirtualDesktopResource> desktopList = await desktops.ToEnumerableAsync();

            Assert.AreEqual(1, desktopList.Count);

            VirtualDesktopResource desktop = desktopList[0];

            await desktop.UpdateAsync(new VirtualDesktopPatch { Description = "Updated", FriendlyName = "UpdatedFriendlyName" });

            Response<VirtualDesktopResource> updatedDesktop = await desktopCollection.GetAsync(desktop.Id.Name);

            Assert.IsNotNull(updatedDesktop);

            Assert.AreEqual("Updated", updatedDesktop.Value.Data.Description);

            Assert.AreEqual("UpdatedFriendlyName", updatedDesktop.Value.Data.FriendlyName);

            Response<VirtualApplicationGroupResource> getOp = await agCollection.GetAsync(
                applicationGroupName);

            Assert.AreEqual(applicationGroupName, getOp.Value.Data.Name);

            VirtualApplicationGroupResource applicationGroup = getOp.Value;
            ArmOperation deleteOp = await applicationGroup.DeleteAsync(WaitUntil.Completed);

            Assert.IsNotNull(deleteOp);

            Assert.AreEqual(200, deleteOp.GetRawResponse().Status);

            deleteOp = await applicationGroup.DeleteAsync(WaitUntil.Completed);

            Assert.IsNotNull(deleteOp);

            Assert.AreEqual(204, deleteOp.GetRawResponse().Status);

            try
            {
                getOp = await agCollection.GetAsync(
                    applicationGroupName);
            }
            catch (RequestFailedException ex)
            {
                Assert.AreEqual(404, ex.Status);
            }

            await opHostPoolCreate.Value.DeleteAsync(WaitUntil.Completed);
        }
    }
}
