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
    public class VirtualApplicationGroupCollectionTests : DesktopVirtualizationManagementClientBase
    {
        public VirtualApplicationGroupCollectionTests() : base(true)
        {
        }

        public VirtualApplicationGroupCollectionTests(bool isAsync) : base(isAsync)
        {
        }

        public VirtualApplicationGroupCollectionTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        [Test]
        public async Task DesktopApplicationGroupCrud()
        {
            var hostPoolName = "testDesktopApplicationGroupCrudHP";
            var applicationGroupName = "testDesktopApplicationGroupCrudAG";

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

            var getOp = await agCollection.GetAsync(
                applicationGroupName);

            Assert.AreEqual(applicationGroupName, getOp.Value.Data.Name);

            agData.FriendlyName = "Friendly Name";
            opApplicationGroupCreate = await agCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                applicationGroupName,
                agData);

            Assert.IsNotNull(opApplicationGroupCreate);
            Assert.IsTrue(opApplicationGroupCreate.HasCompleted);
            Assert.AreEqual(opApplicationGroupCreate.Value.Data.Name, applicationGroupName);
            Assert.AreEqual(opApplicationGroupCreate.Value.Data.FriendlyName, "Friendly Name");

            getOp = await agCollection.GetAsync(
                applicationGroupName);

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

        [Test]
        public async Task RemoteApplicationGroupCrud()
        {
            var hostPoolName = "testRemoteApplicationGroupCrudHP";
            var applicationGroupName = "testRemoteApplicationGroupCrudAG";

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
            var agData = new VirtualApplicationGroupData("brazilsouth", opHostPoolCreate.Value.Data.Id, ApplicationGroupType.RemoteApp);

            var op = await agCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                applicationGroupName,
                agData);

            Assert.IsNotNull(op);
            Assert.IsTrue(op.HasCompleted);
            Assert.AreEqual(op.Value.Data.Name, applicationGroupName);

            var getOp = await agCollection.GetAsync(
                applicationGroupName);

            Assert.AreEqual(applicationGroupName, getOp.Value.Data.Name);

            agData.FriendlyName = "Friendly Name";
            op = await agCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                applicationGroupName,
                agData);

            Assert.IsNotNull(op);
            Assert.IsTrue(op.HasCompleted);
            Assert.AreEqual(op.Value.Data.Name, applicationGroupName);
            Assert.AreEqual(op.Value.Data.FriendlyName, "Friendly Name");

            getOp = await agCollection.GetAsync(
                applicationGroupName);

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
