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
    public class VirtualApplicationCollectionTests : DesktopVirtualizationManagementClientBase
    {
        public VirtualApplicationCollectionTests() : base(true)
        {
        }

        public VirtualApplicationCollectionTests(bool isAsync) : base(isAsync)
        {
        }

        public VirtualApplicationCollectionTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        [TestCase]
        public async Task RemoteApplicationCrud()
        {
            string hostPoolName = "testRemoteApplicationCrudHP";
            string applicationGroupName = "testRemoteApplicationCrudAG";

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
            VirtualApplicationGroupData agData = new VirtualApplicationGroupData(DefaultLocation, opHostPoolCreate.Value.Data.Id, VirtualApplicationGroupType.RemoteApp);

            ArmOperation<VirtualApplicationGroupResource> opApplicationGroupCreate = await agCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                applicationGroupName,
                agData);

            Assert.IsNotNull(opApplicationGroupCreate);
            Assert.IsTrue(opApplicationGroupCreate.HasCompleted);
            Assert.AreEqual(opApplicationGroupCreate.Value.Data.Name, applicationGroupName);

            VirtualApplicationGroupResource railApplicationGroup = opApplicationGroupCreate.Value;

            VirtualApplicationCollection railApplications = railApplicationGroup.GetVirtualApplications();

            AsyncPageable<VirtualApplicationResource> applications = railApplications.GetAllAsync();

            Assert.IsNotNull(applications);

            VirtualApplicationData applicationData = new VirtualApplicationData(VirtualApplicationCommandLineSetting.DoNotAllow);
            applicationData.FilePath = "c:\\notepad.exe";
            applicationData.IconPath = "c:\\notepad.exe";
            applicationData.Description = "Note Pad";
            applicationData.ShowInPortal = true;

            ArmOperation<VirtualApplicationResource> opCreate = await railApplications.CreateOrUpdateAsync(WaitUntil.Completed, "notepad", applicationData);

            Assert.IsNotNull(opCreate);

            Assert.AreEqual("testRemoteApplicationCrudAG/notepad", opCreate.Value.Data.Name);
            Assert.AreEqual("Note Pad", opCreate.Value.Data.Description);

            Response<VirtualApplicationResource> opGet = await railApplications.GetAsync("notepad");

            Assert.IsNotNull(opGet);

            Assert.AreEqual("c:\\notepad.exe", opGet.Value.Data.FilePath);
            Assert.AreEqual("c:\\notepad.exe", opGet.Value.Data.IconPath);
            Assert.AreEqual("Note Pad", opGet.Value.Data.Description);

            applicationData.Description = "NotePad";

            ArmOperation<VirtualApplicationResource> opUpdate = await railApplications.CreateOrUpdateAsync(WaitUntil.Completed, "notepad", applicationData);

            Assert.IsNotNull(opUpdate);

            Assert.AreEqual("testRemoteApplicationCrudAG/notepad", opUpdate.Value.Data.Name);
            Assert.AreEqual("NotePad", opUpdate.Value.Data.Description);

            ArmOperation opDelete = await opUpdate.Value.DeleteAsync(WaitUntil.Completed);

            Assert.IsNotNull(opDelete);

            Assert.AreEqual(200, opDelete.GetRawResponse().Status);

            opDelete = await opUpdate.Value.DeleteAsync(WaitUntil.Completed);

            Assert.IsNotNull(opDelete);

            Assert.AreEqual(204, opDelete.GetRawResponse().Status);

            try
            {
                await railApplications.GetAsync("notepad");
            }
            catch (RequestFailedException ex)
            {
                Assert.AreEqual(404, ex.Status);
            }

            await opApplicationGroupCreate.Value.DeleteAsync(WaitUntil.Completed);
            await opHostPoolCreate.Value.DeleteAsync(WaitUntil.Completed);
        }
    }
}
