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
    public class HostPoolCollectionTests : DesktopVirtualizationManagementClientBase
    {
        public HostPoolCollectionTests() : base(true)
        {
        }

        public HostPoolCollectionTests(bool isAsync) : base(isAsync)
        {
        }

        public HostPoolCollectionTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public static List<TestCaseData> hostPoolCrudTestData = new List<TestCaseData>
        {
            new TestCaseData(1, HostPoolType.Personal, HostPoolLoadBalancerType.DepthFirst, HostPoolLoadBalancerType.Persistent, PreferredAppGroupType.Desktop),
            new TestCaseData(2, HostPoolType.Personal, HostPoolLoadBalancerType.DepthFirst, HostPoolLoadBalancerType.Persistent, PreferredAppGroupType.RailApplications),
            new TestCaseData(3, HostPoolType.Personal, HostPoolLoadBalancerType.BreadthFirst, HostPoolLoadBalancerType.Persistent, PreferredAppGroupType.Desktop),
            new TestCaseData(4, HostPoolType.Personal, HostPoolLoadBalancerType.BreadthFirst, HostPoolLoadBalancerType.Persistent, PreferredAppGroupType.RailApplications),
            new TestCaseData(5, HostPoolType.Pooled, HostPoolLoadBalancerType.DepthFirst, HostPoolLoadBalancerType.DepthFirst, PreferredAppGroupType.Desktop),
            new TestCaseData(6, HostPoolType.Pooled, HostPoolLoadBalancerType.DepthFirst, HostPoolLoadBalancerType.DepthFirst, PreferredAppGroupType.RailApplications),
            new TestCaseData(7, HostPoolType.Pooled, HostPoolLoadBalancerType.BreadthFirst, HostPoolLoadBalancerType.BreadthFirst, PreferredAppGroupType.Desktop),
            new TestCaseData(8, HostPoolType.Pooled, HostPoolLoadBalancerType.BreadthFirst, HostPoolLoadBalancerType.BreadthFirst, PreferredAppGroupType.RailApplications)
        };

        [TestCaseSource("hostPoolCrudTestData")]
        public async Task HostPoolCrud(
            int caseNumber,
            HostPoolType hostPoolType,
            HostPoolLoadBalancerType HostPoolLoadBalancerType,
            HostPoolLoadBalancerType expectedLoadBalancerType,
            PreferredAppGroupType preferredAppGroupType)
        {
            string hostPoolName = $"testHostPoolCrud{caseNumber}";

            string resourceGroupName = Recording.GetVariable("DESKTOPVIRTUALIZATION_RESOURCE_GROUP", DefaultResourceGroupName);
            ResourceGroupResource rg = (ResourceGroupResource)await ResourceGroups.GetAsync(resourceGroupName);
            Assert.IsNotNull(rg);
            HostPoolCollection hostPoolCollection = rg.GetHostPools();
            HostPoolData hostPoolData = new HostPoolData(
                DefaultLocation,
                hostPoolType,
                HostPoolLoadBalancerType,
                preferredAppGroupType);

            ArmOperation<HostPoolResource> op = await hostPoolCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                hostPoolName,
                hostPoolData);

            Assert.IsNotNull(op);
            Assert.IsTrue(op.HasCompleted);
            Assert.AreEqual(op.Value.Data.Name, hostPoolName);

            Response<HostPoolResource> getOp = await hostPoolCollection.GetAsync(
                hostPoolName);

            Assert.AreEqual(hostPoolName, getOp.Value.Data.Name);
            Assert.AreEqual(hostPoolType, getOp.Value.Data.HostPoolType);
            Assert.AreEqual(expectedLoadBalancerType, getOp.Value.Data.LoadBalancerType);
            Assert.AreEqual(preferredAppGroupType, getOp.Value.Data.PreferredAppGroupType);

            hostPoolData.FriendlyName = "Friendly Name";
            op = await hostPoolCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
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

            HostPoolResource hostPool = getOp.Value;
            ArmOperation deleteOp = await hostPool.DeleteAsync(WaitUntil.Completed);

            Assert.IsNotNull(deleteOp);

            Assert.AreEqual(200, deleteOp.GetRawResponse().Status);

            deleteOp = await hostPool.DeleteAsync(WaitUntil.Completed);

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
    }
}
