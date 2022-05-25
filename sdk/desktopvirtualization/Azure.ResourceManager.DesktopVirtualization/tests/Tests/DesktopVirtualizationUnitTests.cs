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
    [TestFixture]
    public class DesktopVirtualizationUnitTests : ManagementRecordedTestBase<DesktopVirtualizationManagementTestEnvironment>
    {
        public ArmClient armClient { get; set; }
        public Subscription Subscription { get; set; }
        public ResourceGroupCollection ResourceGroups { get; set; }

        public DesktopVirtualizationUnitTests() : base(true)
        {
        }

        public DesktopVirtualizationUnitTests(bool isAsync) : base(isAsync)
        {
        }

        public DesktopVirtualizationUnitTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public async Task InitializeClients()
        {
            armClient = GetArmClient();
            Subscription = await armClient.GetDefaultSubscriptionAsync();
            ResourceGroups = Subscription.GetResourceGroups();
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await InitializeClients();
            }
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [Test]
        public async Task WorkspaceCrud()
        {
            var workspaceName = "testWorkspaceCrudWS";
            var resourceGroupName = Recording.GetVariable("DESKTOPVIRTUALIZATION_RESOURCE_GROUP", "azsdkRG");
            var rg = (ResourceGroup)await ResourceGroups.GetAsync(resourceGroupName);
            Assert.IsNotNull(rg);
            var workspaceCollection = rg.GetVirtualWorkspaces();
            var workspaceData = new VirtualWorkspaceData(
                "brazilsouth");

            var opWorkspaceCreate = await workspaceCollection.CreateOrUpdateAsync(
                true,
                workspaceName,
                workspaceData);

            Assert.IsNotNull(opWorkspaceCreate);
            Assert.IsTrue(opWorkspaceCreate.HasCompleted);
            Assert.AreEqual(opWorkspaceCreate.Value.Data.Name, workspaceName);

            var getOp = await workspaceCollection.GetAsync(
                workspaceName);

            Assert.AreEqual(workspaceName, getOp.Value.Data.Name);

            workspaceData.FriendlyName = "Friendly Name";
            opWorkspaceCreate = await workspaceCollection.CreateOrUpdateAsync(
                true,
                workspaceName,
                workspaceData);

            Assert.IsNotNull(opWorkspaceCreate);
            Assert.IsTrue(opWorkspaceCreate.HasCompleted);
            Assert.AreEqual(opWorkspaceCreate.Value.Data.Name, workspaceName);
            Assert.AreEqual(opWorkspaceCreate.Value.Data.FriendlyName, "Friendly Name");

            getOp = await workspaceCollection.GetAsync(
                workspaceName);

            var workspace = getOp.Value;
            var deleteOp = await workspace.DeleteAsync(true);

            Assert.IsNotNull(deleteOp);

            Assert.AreEqual(200, deleteOp.GetRawResponse().Status);

            deleteOp = await workspace.DeleteAsync(true);

            Assert.IsNotNull(deleteOp);

            Assert.AreEqual(204, deleteOp.GetRawResponse().Status);

            try
            {
                getOp = await workspaceCollection.GetAsync(
                    workspaceName);
            }
            catch (Azure.RequestFailedException ex)
            {
                Assert.AreEqual(404, ex.Status);
            }
        }

        public static List<TestCaseData> hostPoolCrudTestData = new List<TestCaseData>
        {
            new TestCaseData(1, HostPoolType.Personal, LoadBalancerType.DepthFirst, LoadBalancerType.Persistent, PreferredAppGroupType.Desktop),
            new TestCaseData(2, HostPoolType.Personal, LoadBalancerType.DepthFirst, LoadBalancerType.Persistent, PreferredAppGroupType.RailApplications),
            new TestCaseData(3, HostPoolType.Personal, LoadBalancerType.BreadthFirst, LoadBalancerType.Persistent, PreferredAppGroupType.Desktop),
            new TestCaseData(4, HostPoolType.Personal, LoadBalancerType.BreadthFirst, LoadBalancerType.Persistent, PreferredAppGroupType.RailApplications),
            new TestCaseData(5, HostPoolType.Pooled, LoadBalancerType.DepthFirst, LoadBalancerType.DepthFirst, PreferredAppGroupType.Desktop),
            new TestCaseData(6, HostPoolType.Pooled, LoadBalancerType.DepthFirst, LoadBalancerType.DepthFirst, PreferredAppGroupType.RailApplications),
            new TestCaseData(7, HostPoolType.Pooled, LoadBalancerType.BreadthFirst, LoadBalancerType.BreadthFirst, PreferredAppGroupType.Desktop),
            new TestCaseData(8, HostPoolType.Pooled, LoadBalancerType.BreadthFirst, LoadBalancerType.BreadthFirst, PreferredAppGroupType.RailApplications)
        };

        [TestCaseSource("hostPoolCrudTestData")]
        public async Task HostPoolCrud(
            int caseNumber,
            HostPoolType hostPoolType,
            LoadBalancerType loadBalancerType,
            LoadBalancerType expectedLoadBalancerType,
            PreferredAppGroupType preferredAppGroupType)
        {
            var hostPoolName = $"testHostPoolCrud{caseNumber}";

            var resourceGroupName = Recording.GetVariable("DESKTOPVIRTUALIZATION_RESOURCE_GROUP", "azsdkRG");
            var rg = (ResourceGroup)await ResourceGroups.GetAsync(resourceGroupName);
            Assert.IsNotNull(rg);
            var hostPoolCollection = rg.GetHostPools();
            var hostPoolData = new HostPoolData(
                "brazilsouth",
                hostPoolType,
                loadBalancerType,
                preferredAppGroupType);

            var op = await hostPoolCollection.CreateOrUpdateAsync(
                true,
                hostPoolName,
                hostPoolData);

            Assert.IsNotNull(op);
            Assert.IsTrue(op.HasCompleted);
            Assert.AreEqual(op.Value.Data.Name, hostPoolName);

            var getOp = await hostPoolCollection.GetAsync(
                hostPoolName);

            Assert.AreEqual(hostPoolName, getOp.Value.Data.Name);
            Assert.AreEqual(hostPoolType, getOp.Value.Data.HostPoolType);
            Assert.AreEqual(expectedLoadBalancerType, getOp.Value.Data.LoadBalancerType);
            Assert.AreEqual(preferredAppGroupType, getOp.Value.Data.PreferredAppGroupType);

            hostPoolData.FriendlyName = "Friendly Name";
            op = await hostPoolCollection.CreateOrUpdateAsync(
                true,
                hostPoolName,
                hostPoolData);

            Assert.IsNotNull(op);
            Assert.IsTrue(op.HasCompleted);
            Assert.AreEqual(op.Value.Data.Name, hostPoolName);
            Assert.AreEqual(op.Value.Data.FriendlyName, "Friendly Name");
            Assert.AreEqual(hostPoolName, getOp.Value.Data.Name);
            Assert.AreEqual(hostPoolType, getOp.Value.Data.HostPoolType);
            Assert.AreEqual(expectedLoadBalancerType, getOp.Value.Data.LoadBalancerType);
            Assert.AreEqual(preferredAppGroupType, getOp.Value.Data.PreferredAppGroupType);

            getOp = await hostPoolCollection.GetAsync(
                hostPoolName);

            var hostPool = getOp.Value;
            var deleteOp = await hostPool.DeleteAsync(true);

            Assert.IsNotNull(deleteOp);

            Assert.AreEqual(200, deleteOp.GetRawResponse().Status);

            deleteOp = await hostPool.DeleteAsync(true);

            Assert.IsNotNull(deleteOp);

            Assert.AreEqual(204, deleteOp.GetRawResponse().Status);

            try
            {
                getOp = await hostPoolCollection.GetAsync(
                    hostPoolName);
            }
            catch (RequestFailedException ex)
            {
                Assert.AreEqual(404, ex.Status);
            }
        }

        [Test]
        public async Task DesktopApplicationGroupCrud()
        {
            var hostPoolName = "testDesktopApplicationGroupCrudHP";
            var applicationGroupName = "testDesktopApplicationGroupCrudAG";

            var resourceGroupName = Recording.GetVariable("DESKTOPVIRTUALIZATION_RESOURCE_GROUP", "azsdkRG");
            var rg = (ResourceGroup)await ResourceGroups.GetAsync(resourceGroupName);
            Assert.IsNotNull(rg);
            var hostPoolCollection = rg.GetHostPools();
            var hostPoolData = new HostPoolData(
                "brazilsouth",
                HostPoolType.Pooled,
                LoadBalancerType.BreadthFirst,
                PreferredAppGroupType.Desktop);

            var opHostPoolCreate = await hostPoolCollection.CreateOrUpdateAsync(
                true,
                hostPoolName,
                hostPoolData);

            var agCollection = rg.GetVirtualApplicationGroups();
            var agData = new VirtualApplicationGroupData("brazilsouth", opHostPoolCreate.Value.Data.Id, ApplicationGroupType.Desktop);

            var opApplicationGroupCreate = await agCollection.CreateOrUpdateAsync(
                true,
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
                true,
                applicationGroupName,
                agData);

            Assert.IsNotNull(opApplicationGroupCreate);
            Assert.IsTrue(opApplicationGroupCreate.HasCompleted);
            Assert.AreEqual(opApplicationGroupCreate.Value.Data.Name, applicationGroupName);
            Assert.AreEqual(opApplicationGroupCreate.Value.Data.FriendlyName, "Friendly Name");

            getOp = await agCollection.GetAsync(
                applicationGroupName);

            var applicationGroup = getOp.Value;
            var deleteOp = await applicationGroup.DeleteAsync(true);

            Assert.IsNotNull(deleteOp);

            Assert.AreEqual(200, deleteOp.GetRawResponse().Status);

            deleteOp = await applicationGroup.DeleteAsync(true);

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

            await opHostPoolCreate.Value.DeleteAsync(true);
        }

        [Test]
        public async Task DesktopApplicationCrud()
        {
            var hostPoolName = "testDesktopApplicationCrudHP";
            var applicationGroupName = "testDesktopApplicationCrudAG";

            var resourceGroupName = Recording.GetVariable("DESKTOPVIRTUALIZATION_RESOURCE_GROUP", "azsdkRG");
            var rg = (ResourceGroup)await ResourceGroups.GetAsync(resourceGroupName);
            Assert.IsNotNull(rg);
            var hostPoolCollection = rg.GetHostPools();
            var hostPoolData = new HostPoolData(
                "brazilsouth",
                HostPoolType.Pooled,
                LoadBalancerType.BreadthFirst,
                PreferredAppGroupType.Desktop);

            var opHostPoolCreate = await hostPoolCollection.CreateOrUpdateAsync(
                true,
                hostPoolName,
                hostPoolData);

            var agCollection = rg.GetVirtualApplicationGroups();
            var agData = new VirtualApplicationGroupData("brazilsouth", opHostPoolCreate.Value.Data.Id, ApplicationGroupType.Desktop);

            var opApplicationGroupCreate = await agCollection.CreateOrUpdateAsync(
                true,
                applicationGroupName,
                agData);

            Assert.IsNotNull(opApplicationGroupCreate);
            Assert.IsTrue(opApplicationGroupCreate.HasCompleted);
            Assert.AreEqual(opApplicationGroupCreate.Value.Data.Name, applicationGroupName);

            var desktopApplicationGroup = opApplicationGroupCreate.Value;

            var desktopCollection = desktopApplicationGroup.GetVirtualDesktops();

            AsyncPageable<VirtualDesktop> desktops = desktopCollection.GetAllAsync();

            Assert.IsNotNull(desktops);

            var desktopList = await desktops.ToEnumerableAsync();

            Assert.AreEqual(1, desktopList.Count);

            var desktop = desktopList[0];

            await desktop.UpdateAsync(new VirtualDesktopUpdateOptions { Description = "Updated", FriendlyName = "UpdatedFriendlyName" });

            var updatedDesktop = await desktopCollection.GetAsync(desktop.Id.Name);

            Assert.IsNotNull(updatedDesktop);

            Assert.AreEqual("Updated", updatedDesktop.Value.Data.Description);

            Assert.AreEqual("UpdatedFriendlyName", updatedDesktop.Value.Data.FriendlyName);

            var getOp = await agCollection.GetAsync(
                applicationGroupName);

            Assert.AreEqual(applicationGroupName, getOp.Value.Data.Name);

            var applicationGroup = getOp.Value;
            var deleteOp = await applicationGroup.DeleteAsync(true);

            Assert.IsNotNull(deleteOp);

            Assert.AreEqual(200, deleteOp.GetRawResponse().Status);

            deleteOp = await applicationGroup.DeleteAsync(true);

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

            await opHostPoolCreate.Value.DeleteAsync(true);
        }

        [Test]
        public async Task RemoteApplicationCrud()
        {
            var hostPoolName = "testRemoteApplicationCrudHP";
            var applicationGroupName = "testRemoteApplicationCrudAG";

            var resourceGroupName = Recording.GetVariable("DESKTOPVIRTUALIZATION_RESOURCE_GROUP", "azsdkRG");
            var rg = (ResourceGroup)await ResourceGroups.GetAsync(resourceGroupName);
            Assert.IsNotNull(rg);
            var hostPoolCollection = rg.GetHostPools();
            var hostPoolData = new HostPoolData(
                "brazilsouth",
                HostPoolType.Pooled,
                LoadBalancerType.BreadthFirst,
                PreferredAppGroupType.Desktop);

            var opHostPoolCreate = await hostPoolCollection.CreateOrUpdateAsync(
                true,
                hostPoolName,
                hostPoolData);

            var agCollection = rg.GetVirtualApplicationGroups();
            var agData = new VirtualApplicationGroupData("brazilsouth", opHostPoolCreate.Value.Data.Id, ApplicationGroupType.RemoteApp);

            var opApplicationGroupCreate = await agCollection.CreateOrUpdateAsync(
                true,
                applicationGroupName,
                agData);

            Assert.IsNotNull(opApplicationGroupCreate);
            Assert.IsTrue(opApplicationGroupCreate.HasCompleted);
            Assert.AreEqual(opApplicationGroupCreate.Value.Data.Name, applicationGroupName);

            var railApplicationGroup = opApplicationGroupCreate.Value;

            var railApplications = railApplicationGroup.GetVirtualApplications();

            AsyncPageable<VirtualApplication> applications = railApplications.GetAllAsync();

            Assert.IsNotNull(applications);

            var applicationData = new VirtualApplicationData(CommandLineSetting.DoNotAllow);
            applicationData.FilePath = "c:\\notepad.exe";
            applicationData.IconPath = "c:\\notepad.exe";
            applicationData.Description = "Note Pad";
            applicationData.ShowInPortal = true;

            var opCreate = await railApplications.CreateOrUpdateAsync(true, "notepad", applicationData);

            Assert.IsNotNull(opCreate);

            Assert.AreEqual("testRemoteApplicationCrudAG/notepad", opCreate.Value.Data.Name);
            Assert.AreEqual("Note Pad", opCreate.Value.Data.Description);

            var opGet = await railApplications.GetAsync("notepad");

            Assert.IsNotNull(opGet);

            Assert.AreEqual("c:\\notepad.exe", opGet.Value.Data.FilePath);
            Assert.AreEqual("c:\\notepad.exe", opGet.Value.Data.IconPath);
            Assert.AreEqual("Note Pad", opGet.Value.Data.Description);

            applicationData.Description = "NotePad";

            var opUpdate = await railApplications.CreateOrUpdateAsync(true, "notepad", applicationData);

            Assert.IsNotNull(opUpdate);

            Assert.AreEqual("testRemoteApplicationCrudAG/notepad", opUpdate.Value.Data.Name);
            Assert.AreEqual("NotePad", opUpdate.Value.Data.Description);

            var opDelete = await opUpdate.Value.DeleteAsync(true);

            Assert.IsNotNull(opDelete);

            Assert.AreEqual(200, opDelete.GetRawResponse().Status);

            opDelete = await opUpdate.Value.DeleteAsync(true);

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

            await opApplicationGroupCreate.Value.DeleteAsync(true);
            await opHostPoolCreate.Value.DeleteAsync(true);
        }

        [Test]
        public async Task RemoteApplicationGroupCrud()
        {
            var hostPoolName = "testRemoteApplicationGroupCrudHP";
            var applicationGroupName = "testRemoteApplicationGroupCrudAG";

            var resourceGroupName = Recording.GetVariable("DESKTOPVIRTUALIZATION_RESOURCE_GROUP", "azsdkRG");
            var rg = (ResourceGroup)await ResourceGroups.GetAsync(resourceGroupName);
            Assert.IsNotNull(rg);
            var hostPoolCollection = rg.GetHostPools();
            var hostPoolData = new HostPoolData(
                "brazilsouth",
                HostPoolType.Pooled,
                LoadBalancerType.BreadthFirst,
                PreferredAppGroupType.Desktop);

            var opHostPoolCreate = await hostPoolCollection.CreateOrUpdateAsync(
                true,
                hostPoolName,
                hostPoolData);

            var agCollection = rg.GetVirtualApplicationGroups();
            var agData = new VirtualApplicationGroupData("brazilsouth", opHostPoolCreate.Value.Data.Id, ApplicationGroupType.RemoteApp);

            var op = await agCollection.CreateOrUpdateAsync(
                true,
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
                true,
                applicationGroupName,
                agData);

            Assert.IsNotNull(op);
            Assert.IsTrue(op.HasCompleted);
            Assert.AreEqual(op.Value.Data.Name, applicationGroupName);
            Assert.AreEqual(op.Value.Data.FriendlyName, "Friendly Name");

            getOp = await agCollection.GetAsync(
                applicationGroupName);

            var applicationGroup = getOp.Value;
            var deleteOp = await applicationGroup.DeleteAsync(true);

            Assert.IsNotNull(deleteOp);

            Assert.AreEqual(200, deleteOp.GetRawResponse().Status);

            deleteOp = await applicationGroup.DeleteAsync(true);

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

            await opHostPoolCreate.Value.DeleteAsync(true);
        }
    }
}
