// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetworkCloud.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.ResourceManager.NetworkCloud.Tests.ScenarioTests
{
    public class BareMetalMachinesTests : NetworkCloudManagementTestBase
    {
        public BareMetalMachinesTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) {}
        public BareMetalMachinesTests(bool isAsync) : base(isAsync) {}

        [Test]
        [RecordedTest]
        public async Task BareMetalMachines()
        {
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ClusterManagedRG);
            ResourceGroupResource clusterRGResource = Client.GetResourceGroupResource(resourceGroupResourceId);
            NetworkCloudBareMetalMachineCollection collection = clusterRGResource.GetNetworkCloudBareMetalMachines();

            // List by Resource Group
            var listByResourceGroup = new List<NetworkCloudBareMetalMachineResource>();
            await foreach (var item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            // List by Subscription
            var listBySubscription = new List<NetworkCloudBareMetalMachineResource>();
            await foreach (var item in SubscriptionResource.GetNetworkCloudBareMetalMachinesAsync())
            {
                listBySubscription.Add(item);
            }
            Assert.IsNotEmpty(listBySubscription);

            // Get
            var firstBMM = listByResourceGroup[0].Data;
            var bareMetalMachineName = firstBMM.Name;
            var getResult = await collection.GetAsync(bareMetalMachineName);
            Assert.AreEqual(bareMetalMachineName, getResult.Value.Data.Name);

            // Update
            NetworkCloudBareMetalMachineResource bareMetalMachine = Client.GetNetworkCloudBareMetalMachineResource(new ResourceIdentifier(firstBMM.Id));
            NetworkCloudBareMetalMachinePatch patch = new NetworkCloudBareMetalMachinePatch(){};
            var testKey = "test-key";
            var testValue = "test-value";
            patch.Tags.Add(testKey, testValue);

            foreach (var key in firstBMM.Tags.Keys)
            {
                patch.Tags.Add(key, firstBMM.Tags[key]);
            }
            ArmOperation<NetworkCloudBareMetalMachineResource> updateResult = await bareMetalMachine.UpdateAsync(WaitUntil.Completed, patch);
            Assert.AreEqual(patch.Tags, updateResult.Value.Data.Tags);

            patch.Tags.Remove(testKey);
            updateResult = await bareMetalMachine.UpdateAsync(WaitUntil.Completed, patch);
            Assert.AreEqual(patch.Tags, updateResult.Value.Data.Tags, "tag reversion failed");
        }
    }
}
