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

        [TestCase]
        public async Task DesktopApplicationGroupCrud()
        {
            string hostPoolName = "testDesktopApplicationGroupCrudHP";
            string applicationGroupName = "testDesktopApplicationGroupCrudAG";

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

            Response<VirtualApplicationGroupResource> getOp = await agCollection.GetAsync(
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

        [TestCase]
        public async Task RemoteApplicationGroupCrud()
        {
            string hostPoolName = "testRemoteApplicationGroupCrudHP";
            string applicationGroupName = "testRemoteApplicationGroupCrudAG";

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

            ArmOperation<VirtualApplicationGroupResource> op = await agCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                applicationGroupName,
                agData);

            Assert.IsNotNull(op);
            Assert.IsTrue(op.HasCompleted);
            Assert.AreEqual(op.Value.Data.Name, applicationGroupName);

            Response<VirtualApplicationGroupResource> getOp = await agCollection.GetAsync(
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

        [TestCase]
        public async Task RemoteApplicationGroupList0AG()
        {
            string hostPoolName = "testRemoteApplicationGroupList0AGHP";

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

            AsyncPageable<VirtualApplicationGroupResource> agListPaged = agCollection.GetAllAsync();

            List<VirtualApplicationGroupResource> agList = await agListPaged.ToEnumerableAsync<VirtualApplicationGroupResource>();

            Assert.AreEqual(0, agList.Count);

            await opHostPoolCreate.Value.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        public async Task RemoteApplicationGroupList1AG()
        {
            string hostPoolName = "testRemoteApplicationGroupList1AGHP";
            string applicationGroupName = "testRemoteApplicationGroupList1AGAG";

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

            ArmOperation<VirtualApplicationGroupResource> op = await agCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                applicationGroupName,
                agData);

            AsyncPageable<VirtualApplicationGroupResource> agListPaged = agCollection.GetAllAsync();

            IAsyncEnumerable<Page<VirtualApplicationGroupResource>> f = agListPaged.AsPages();

            var pageEnumerator = f.GetAsyncEnumerator();

            var b = await pageEnumerator.MoveNextAsync();

            Assert.IsTrue(b);

            Assert.AreEqual(1, pageEnumerator.Current.Values.Count);

            Assert.AreEqual(null, pageEnumerator.Current.ContinuationToken);

            await pageEnumerator.Current.Values[0].DeleteAsync(WaitUntil.Completed);

            await opHostPoolCreate.Value.DeleteAsync(WaitUntil.Completed);
        }

        public static List<TestCaseData> applicationGroupListData = new List<TestCaseData>
        {
            new TestCaseData(0),
            new TestCaseData(1),
            new TestCaseData(10),
        };

        [TestCaseSource("applicationGroupListData")]
        public async Task RemoteApplicationGroupList(
            int numberOfApplicationGroups)
        {
            string hostPoolName = "RemoteApplicationGroupListHP";
            string applicationGroupName = "RemoteApplicationGroupListAG";
            List<string> applicationGroupNameList = new List<string>();

            for (int i = 0; i < numberOfApplicationGroups; i++)
            {
                applicationGroupNameList.Add($"{applicationGroupName}{i}");
            }

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
            VirtualApplicationGroupData agData = new VirtualApplicationGroupData(
                DefaultLocation, opHostPoolCreate.Value.Data.Id, VirtualApplicationGroupType.RemoteApp);

            List<Task<ArmOperation<VirtualApplicationGroupResource>>> createTaskList = new List<Task<ArmOperation<VirtualApplicationGroupResource>>>();

            for (int i=0; i<numberOfApplicationGroups; i++)
            {
                createTaskList.Add(agCollection.CreateOrUpdateAsync(
                    WaitUntil.Started,
                    applicationGroupNameList[i],
                    agData));
            }

            if (createTaskList.Count > 0)
            {
                Task.WaitAll(createTaskList.ToArray());
            }

            AsyncPageable<VirtualApplicationGroupResource> agListPaged = agCollection.GetAllAsync();

            IAsyncEnumerable<Page<VirtualApplicationGroupResource>> f = agListPaged.AsPages();

            var pageEnumerator = f.GetAsyncEnumerator();

            await pageEnumerator.MoveNextAsync();
            Assert.IsNull(pageEnumerator.Current.ContinuationToken);
            Assert.AreEqual(numberOfApplicationGroups, pageEnumerator.Current.Values.Count);
        }
    }
}
