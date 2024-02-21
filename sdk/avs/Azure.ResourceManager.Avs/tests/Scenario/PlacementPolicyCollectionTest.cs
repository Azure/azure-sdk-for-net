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
    public class PlacementPolicyCollectionTest: AvsManagementTestBase
    {
        public PlacementPolicyCollectionTest(bool isAsync) : base(isAsync)
        {
        }

        protected async Task<PlacementPolicyCollection> GetPlacementPolicyCollectionAsync()
        {
            var privateCloudClusterResource = await getAvsPrivateCloudClusterResource();
            var policies = privateCloudClusterResource.GetPlacementPolicies();
            return policies;
        }

        [TestCase, Order(1)]
        [RecordedTest]
        [AsyncOnly]
        public async Task Create() {
            var collection = await GetPlacementPolicyCollectionAsync();
            string placementPolicyName = "policy1";
            PlacementPolicyData data = new PlacementPolicyData()
            {
                Properties = new VmHostPlacementPolicyProperties(new ResourceIdentifier[]
            {
new ResourceIdentifier($"/subscriptions/{DefaultSubscription.Data.SubscriptionId}/resourceGroups/{RESOURCE_GROUP_NAME}/providers/Microsoft.AVS/privateClouds/{PRIVATE_CLOUD_NAME}/clusters/{CLUSTER1_NAME}/virtualMachines/vm-1818")
            }, new string[]
            {"esx05-r20.p04.eastus.avs.azure.com"
            }, AvsPlacementPolicyAffinityType.Affinity)
            };
            ArmOperation<PlacementPolicyResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, placementPolicyName, data);
            Assert.AreEqual(placementPolicyName, lro.Value.Data.Name);
        }

        [TestCase, Order(2)]
        [RecordedTest]
        public async Task GetCollection()
        {
            var collection = await GetPlacementPolicyCollectionAsync();
            var policies = new List<PlacementPolicyResource>();
            // invoke the operation and iterate over the result
            await foreach (PlacementPolicyResource item in collection.GetAllAsync())
            {
                policies.Add(item);
            }

            Assert.IsTrue(policies.Any());
        }
    }
}
