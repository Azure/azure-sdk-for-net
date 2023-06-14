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
    public class TrunkedNetworksTests : NetworkCloudManagementTestBase
    {
        public TrunkedNetworksTests   (bool isAsync, RecordedTestMode mode) : base(isAsync, mode) {}
        public TrunkedNetworksTests  (bool isAsync) : base(isAsync) {}

        [Test, MaxTime(1800000)]
        public async Task TrunkedNetworks()
        {
            TrunkedNetworkCollection collection = ResourceGroupResource.GetTrunkedNetworks();
            string trunkedNetworkName = TestEnvironment.TrunkedNetworkName;
            string resourceGroupName = ResourceIdentifier.Parse(ResourceGroupResource.Id).ResourceGroupName;
            ResourceIdentifier trunkedNetworkResourceId = TrunkedNetworkResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, resourceGroupName, trunkedNetworkName);
            TrunkedNetworkResource trunkedNetwork = Client.GetTrunkedNetworkResource(trunkedNetworkResourceId);

            // Create
            var listOfVlans = TestEnvironment.TrunkedNetworkVlans.Split(',');
            var vlans = new List<long>();
            foreach (var item in listOfVlans)
            {
                vlans.Add(long.Parse(item));
            }
            TrunkedNetworkData createData = new TrunkedNetworkData
            (
                TestEnvironment.Location,
                new ExtendedLocation(TestEnvironment.ClusterExtendedLocation, "CustomLocation"),
                new string[]
                {
                TestEnvironment.L3IsolationDomainId,
                },
                vlans
            )
            {
                Tags =
                {
                    ["key1"] = "myvalue1",
                },
            };
            ArmOperation<TrunkedNetworkResource> createResult = await collection.CreateOrUpdateAsync(WaitUntil.Completed, trunkedNetworkName, createData);
            Assert.AreEqual(trunkedNetworkName, createResult.Value.Data.Name);

            // Get
            var getResult = await trunkedNetwork.GetAsync();
            Assert.AreEqual(trunkedNetworkName, getResult.Value.Data.Name);

            // Update
            TrunkedNetworkPatch patch = new TrunkedNetworkPatch()
            {
                Tags =
                {
                    ["key1"] = "myvalue1",
                    ["key2"] = "myvalue2",
                },
            };
            TrunkedNetworkResource updateResult = await trunkedNetwork.UpdateAsync(patch);
            Assert.AreEqual(patch.Tags, updateResult.Data.Tags);

            // List by Resource Group
            var listByResourceGroup = new List<TrunkedNetworkResource>();
            await foreach (TrunkedNetworkResource item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            // List by Subscription
            var listBySubscription = new List<TrunkedNetworkResource>();
            await foreach (TrunkedNetworkResource item in SubscriptionResource.GetTrunkedNetworksAsync())
            {
                listBySubscription.Add(item);
            }
            Assert.IsNotEmpty(listBySubscription);

            // Delete
            var deleteResult = await trunkedNetwork.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResult.HasCompleted);
        }
    }
}
