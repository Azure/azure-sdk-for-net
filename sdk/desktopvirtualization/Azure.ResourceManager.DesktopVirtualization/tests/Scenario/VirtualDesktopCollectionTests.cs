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

        [Test]
        public async Task DesktopApplicationCrud()
        {
            var hostPoolName = "testDesktopApplicationCrudHP";
            var applicationGroupName = "testDesktopApplicationCrudAG";

            var resourceGroupName = Recording.GetVariable("DESKTOPVIRTUALIZATION_RESOURCE_GROUP", "azsdkRG");
            var rg = (ResourceGroupResource)await ResourceGroups.GetAsync(resourceGroupName);
            Assert.IsNotNull(rg);
            var hostPoolCollection = rg.GetHostPools();
            var hostPoolData = new HostPoolData(
                "brazilsouth",
                HostPoolType.Pooled,
                LoadBalancerType.BreadthFirst,
                PreferredAppGroupType.Desktop);

            var opHostPoolCreate = await hostPoolCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                hostPoolName,
                hostPoolData);

            var agCollection = rg.GetVirtualApplicationGroups();
            var agData = new VirtualApplicationGroupData("brazilsouth", opHostPoolCreate.Value.Data.Id, ApplicationGroupType.Desktop);

            var opApplicationGroupCreate = await agCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                applicationGroupName,
                agData);

            Assert.IsNotNull(opApplicationGroupCreate);
            Assert.IsTrue(opApplicationGroupCreate.HasCompleted);
            Assert.AreEqual(opApplicationGroupCreate.Value.Data.Name, applicationGroupName);

            var desktopApplicationGroup = opApplicationGroupCreate.Value;

            var desktopCollection = desktopApplicationGroup.GetVirtualDesktops();

            AsyncPageable<VirtualDesktopResource> desktops = desktopCollection.GetAllAsync();

            Assert.IsNotNull(desktops);

            var desktopList = await desktops.ToEnumerableAsync();

            Assert.AreEqual(1, desktopList.Count);

            var desktop = desktopList[0];

            await desktop.UpdateAsync(new VirtualDesktopPatch { Description = "Updated", FriendlyName = "UpdatedFriendlyName" });

            var updatedDesktop = await desktopCollection.GetAsync(desktop.Id.Name);

            Assert.IsNotNull(updatedDesktop);

            Assert.AreEqual("Updated", updatedDesktop.Value.Data.Description);

            Assert.AreEqual("UpdatedFriendlyName", updatedDesktop.Value.Data.FriendlyName);

            var getOp = await agCollection.GetAsync(
                applicationGroupName);

            Assert.AreEqual(applicationGroupName, getOp.Value.Data.Name);

            var applicationGroup = getOp.Value;
            var deleteOp = await applicationGroup.DeleteAsync(WaitUntil.Completed);

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
