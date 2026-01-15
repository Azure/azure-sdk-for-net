// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Avs.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Avs.Tests.Scenario
{
    public class WorkloadNetworkVmGroupCollectionTest: AvsManagementTestBase
    {
        public WorkloadNetworkVmGroupCollectionTest(bool isAsync) : base(isAsync)
        {
        }

        [TestCase, Order(1)]
        [RecordedTest]
        public async Task GetCollection()
        {
            WorkloadNetworkVmGroupCollection collection = getWorkloadNetworkResource().GetWorkloadNetworkVmGroups();
            var workloadNetworksList = new List<WorkloadNetworkVmGroupResource>();
            await foreach (WorkloadNetworkVmGroupResource item in collection.GetAllAsync())
            {
                workloadNetworksList.Add(item);
            }

            Assert.That(workloadNetworksList.Any(), Is.True);
        }

        [TestCase, Order(2)]
        [RecordedTest]
        public async Task GetCollectionOld()
        {
            WorkloadNetworkVmGroupCollection collection = getWorkloadNetworkResourceOld().GetWorkloadNetworkVmGroups();
            var workloadNetworksList = new List<WorkloadNetworkVmGroupResource>();
            await foreach (WorkloadNetworkVmGroupResource item in collection.GetAllAsync())
            {
                workloadNetworksList.Add(item);
            }

            Assert.That(workloadNetworksList.Any(), Is.True);
        }

        [TestCase, Order(3)]
        [RecordedTest]
        public async Task GetResource()
        {
            WorkloadNetworkVmGroupCollection collection = getWorkloadNetworkResource().GetWorkloadNetworkVmGroups();
            WorkloadNetworkVmGroupResource result =  await collection.GetAsync(WORKLOAD_NETWORK_NAME);
            Assert.That(result.Data.Name, Is.EqualTo(WORKLOAD_NETWORK_NAME));
        }

        [TestCase, Order(4)]
        [RecordedTest]
        public async Task resourceExisits()
        {
            WorkloadNetworkVmGroupCollection collection = getWorkloadNetworkResource().GetWorkloadNetworkVmGroups();
            bool result = await collection.ExistsAsync(WORKLOAD_NETWORK_NAME);
            Assert.That(result, Is.True);
            result =  await collection.ExistsAsync("wn1");
            Assert.That(result, Is.False);
        }
        [TestCase, Order(5)]
        [RecordedTest]
        public async Task getIfExisits()
        {
            WorkloadNetworkVmGroupCollection collection = getWorkloadNetworkResource().GetWorkloadNetworkVmGroups();
            NullableResponse<WorkloadNetworkVmGroupResource> response = await collection.GetIfExistsAsync(WORKLOAD_NETWORK_NAME);
            WorkloadNetworkVmGroupResource result = response.HasValue ? response.Value : null;
            Assert.NotNull(result);
            Assert.That(result.Data.Name, Is.EqualTo(WORKLOAD_NETWORK_NAME));
        }
    }
}
