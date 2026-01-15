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
            Assert.That(opApplicationGroupCreate.HasCompleted, Is.True);
            Assert.That(applicationGroupName, Is.EqualTo(opApplicationGroupCreate.Value.Data.Name));

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

            Assert.That(opCreate.Value.Data.Name, Is.EqualTo("testRemoteApplicationCrudAG/notepad"));
            Assert.That(opCreate.Value.Data.Description, Is.EqualTo("Note Pad"));

            Response<VirtualApplicationResource> opGet = await railApplications.GetAsync("notepad");

            Assert.IsNotNull(opGet);

            Assert.That(opGet.Value.Data.FilePath, Is.EqualTo("c:\\notepad.exe"));
            Assert.That(opGet.Value.Data.IconPath, Is.EqualTo("c:\\notepad.exe"));
            Assert.That(opGet.Value.Data.Description, Is.EqualTo("Note Pad"));

            applicationData.Description = "NotePad";

            ArmOperation<VirtualApplicationResource> opUpdate = await railApplications.CreateOrUpdateAsync(WaitUntil.Completed, "notepad", applicationData);

            Assert.IsNotNull(opUpdate);

            Assert.That(opUpdate.Value.Data.Name, Is.EqualTo("testRemoteApplicationCrudAG/notepad"));
            Assert.That(opUpdate.Value.Data.Description, Is.EqualTo("NotePad"));

            ArmOperation opDelete = await opUpdate.Value.DeleteAsync(WaitUntil.Completed);

            Assert.IsNotNull(opDelete);

            Assert.That(opDelete.GetRawResponse().Status, Is.EqualTo(200));

            opDelete = await opUpdate.Value.DeleteAsync(WaitUntil.Completed);

            Assert.IsNotNull(opDelete);

            Assert.That(opDelete.GetRawResponse().Status, Is.EqualTo(204));

            try
            {
                await railApplications.GetAsync("notepad");
            }
            catch (RequestFailedException ex)
            {
                Assert.That(ex.Status, Is.EqualTo(404));
            }

            await opApplicationGroupCreate.Value.DeleteAsync(WaitUntil.Completed);
            await opHostPoolCreate.Value.DeleteAsync(WaitUntil.Completed);
        }
    }
}
