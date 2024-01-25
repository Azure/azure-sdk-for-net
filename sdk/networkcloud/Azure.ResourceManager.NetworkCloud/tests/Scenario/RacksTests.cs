// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetworkCloud.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.ResourceManager.NetworkCloud.Tests.ScenarioTests
{
    public class RacksTests : NetworkCloudManagementTestBase
    {
        public RacksTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) {}
        public RacksTests(bool isAsync) : base(isAsync) {}

        [Test]
        [RecordedTest]
        public async Task Racks()
        {
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ClusterManagedRG);
            ResourceGroupResource clusterRGResource = Client.GetResourceGroupResource(resourceGroupResourceId);
            NetworkCloudRackCollection collection = clusterRGResource.GetNetworkCloudRacks();
            string rackName = "rackName";

            // List by Resource Group
            var listByResourceGroup = new List<NetworkCloudRackResource>();
            await foreach (var item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            // List by Subscription
            var listBySubscription = new List<NetworkCloudRackResource>();
            await foreach (var item in SubscriptionResource.GetNetworkCloudRacksAsync())
            {
                listBySubscription.Add(item);
            }
            Assert.IsNotEmpty(listBySubscription);

            // Get
            var firstRack = listByResourceGroup[0].Data;
            rackName = firstRack.Name;
            var getResult = collection.GetAsync(rackName);

            // Update: Add patch tags
            var originalTags = firstRack.Tags;
            var testKey = "test-key";
            var testValue = "test-value";
            NetworkCloudRackPatch patch = new NetworkCloudRackPatch()
            {
                Tags = {},
            };
            foreach (string key in originalTags.Keys)
            {
                patch.Tags.Add(key, originalTags[key]);
            }
            patch.Tags.Add(testKey, testValue);

            NetworkCloudRackResource rack = Client.GetNetworkCloudRackResource(firstRack.Id);
            var updateResult = await rack.UpdateAsync(WaitUntil.Completed, patch);
            Assert.AreEqual(testValue, updateResult.Value.Data.Tags[testKey]);

            // Update: Remove patched Tags
            patch.Tags.Remove(testKey);
            updateResult = await rack.UpdateAsync(WaitUntil.Completed, patch);
            try
            {
                var shouldNotPass = updateResult.Value.Data.Tags[testKey];
                Assert.Fail("test key-value pair still found in rack, but should have been removed");
            }
            catch (System.Exception e)
            {
                if (!(e is System.Collections.Generic.KeyNotFoundException))
                {
                    throw;
                }
            }
        }
    }
}
