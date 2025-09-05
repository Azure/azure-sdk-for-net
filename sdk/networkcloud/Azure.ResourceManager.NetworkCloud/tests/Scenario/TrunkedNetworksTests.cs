// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.NetworkCloud.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.NetworkCloud.Tests.ScenarioTests
{
    public class TrunkedNetworksTests : NetworkCloudManagementTestBase
    {
        public TrunkedNetworksTests   (bool isAsync, RecordedTestMode mode) : base(isAsync, mode) {}
        public TrunkedNetworksTests  (bool isAsync) : base(isAsync) {}

        [Test, MaxTime(1800000)]
        [RecordedTest]
        public async Task TrunkedNetworks()
        {
            NetworkCloudTrunkedNetworkCollection collection = ResourceGroupResource.GetNetworkCloudTrunkedNetworks();
            string trunkedNetworkName = Recording.GenerateAssetName("trunkednetwork");
            string resourceGroupName = ResourceIdentifier.Parse(ResourceGroupResource.Id).ResourceGroupName;
            ResourceIdentifier trunkedNetworkResourceId = NetworkCloudTrunkedNetworkResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, resourceGroupName, trunkedNetworkName);
            NetworkCloudTrunkedNetworkResource trunkedNetwork = Client.GetNetworkCloudTrunkedNetworkResource(trunkedNetworkResourceId);

            // Create
            var listOfVlans = TestEnvironment.TrunkedNetworkVlans.Split(',');
            var vlans = new List<long>();
            foreach (var item in listOfVlans)
            {
                vlans.Add(long.Parse(item));
            }
            var isolationDomainIdStringList = TestEnvironment.IsolationDomainIds.Split(',');
            List<ResourceIdentifier> isolationDomainIds = new List<ResourceIdentifier>();
            foreach (string id in isolationDomainIdStringList)
            {
                isolationDomainIds.Add(new ResourceIdentifier(id));
            }

            NetworkCloudTrunkedNetworkData createData = new NetworkCloudTrunkedNetworkData
            (
                TestEnvironment.Location,
                new ExtendedLocation(TestEnvironment.ClusterExtendedLocation, "CustomLocation"),
                isolationDomainIds,
                vlans
            )
            {
                InterfaceName = TestEnvironment.InterfaceName,
                Tags =
                {
                    ["key1"] = "myvalue1",
                },
            };
            ArmOperation<NetworkCloudTrunkedNetworkResource> createResult = await collection.CreateOrUpdateAsync(WaitUntil.Completed, trunkedNetworkName, createData);
            Assert.AreEqual(trunkedNetworkName, createResult.Value.Data.Name);

            // Get
            var getResult = await trunkedNetwork.GetAsync();
            Assert.AreEqual(trunkedNetworkName, getResult.Value.Data.Name);

            // Update
            NetworkCloudTrunkedNetworkPatch patch = new NetworkCloudTrunkedNetworkPatch()
            {
                Tags =
                {
                    ["key1"] = "myvalue1",
                    ["key2"] = "myvalue2",
                },
            };
            NetworkCloudTrunkedNetworkResource updateResult = await trunkedNetwork.UpdateAsync(patch);
            Assert.AreEqual(patch.Tags, updateResult.Data.Tags);

            // List by Resource Group
            var listByResourceGroup = new List<NetworkCloudTrunkedNetworkResource>();
            await foreach (NetworkCloudTrunkedNetworkResource item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            // List by Subscription
            var listBySubscription = new List<NetworkCloudTrunkedNetworkResource>();
            await foreach (NetworkCloudTrunkedNetworkResource item in SubscriptionResource.GetNetworkCloudTrunkedNetworksAsync())
            {
                listBySubscription.Add(item);
            }
            Assert.IsNotEmpty(listBySubscription);

            // Delete
            var deleteResult = await trunkedNetwork.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
            Assert.IsTrue(deleteResult.HasCompleted);
        }
    }
}
