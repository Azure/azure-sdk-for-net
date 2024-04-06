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
    public class L3NetworksTests : NetworkCloudManagementTestBase
    {
        public L3NetworksTests   (bool isAsync, RecordedTestMode mode) : base(isAsync, mode) {}
        public L3NetworksTests  (bool isAsync) : base(isAsync) {}

        [Test, MaxTime(1800000)]
        [RecordedTest]
        public async Task L3Networks()
        {
            var l3NetworkCollection = ResourceGroupResource.GetNetworkCloudL3Networks();
            var l3NetworkName = Recording.GenerateAssetName("l3network");

            var l3NetworkId = NetworkCloudL3NetworkResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, ResourceIdentifier.Parse(ResourceGroupResource.Id).Name, l3NetworkName);
            var l3Network = Client.GetNetworkCloudL3NetworkResource(l3NetworkId);

            // Create
            NetworkCloudL3NetworkData data = new NetworkCloudL3NetworkData(new AzureLocation(TestEnvironment.Location), new ExtendedLocation(TestEnvironment.ClusterExtendedLocation, "CustomLocation"), new ResourceIdentifier(TestEnvironment.L3IsolationDomainId), TestEnvironment.L3Vlan)
            {
                IPv4ConnectedPrefix = TestEnvironment.L3Ipv4Prefix,
                IPv6ConnectedPrefix = TestEnvironment.L3Ipv6Prefix,
            };
            ArmOperation<NetworkCloudL3NetworkResource> NetworkCloudL3NetworkResourceOp = await l3NetworkCollection.CreateOrUpdateAsync(WaitUntil.Completed, l3NetworkName, data);
            Assert.AreEqual(NetworkCloudL3NetworkResourceOp.Value.Data.Name ,l3NetworkName);

            // Get
            NetworkCloudL3NetworkResource getResult = await l3Network.GetAsync();
            Assert.AreEqual(getResult.Data.Name, l3NetworkName);

            // List by Resource Group
            var listByResourceGroup = new List<NetworkCloudL3NetworkResource>();
            NetworkCloudL3NetworkCollection collection = ResourceGroupResource.GetNetworkCloudL3Networks();
            await foreach (NetworkCloudL3NetworkResource item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            // List by Subscription
            var listBySubscription = new List<NetworkCloudL3NetworkResource>();
              await foreach (NetworkCloudL3NetworkResource item in SubscriptionResource.GetNetworkCloudL3NetworksAsync())
            {
                listBySubscription.Add(item);
            }
            Assert.IsNotEmpty(listBySubscription);

            // Update
            NetworkCloudL3NetworkPatch patch = new NetworkCloudL3NetworkPatch()
            {
                Tags =
                    {
                        ["key1"] = "myvalue1",
                    },
            };
            NetworkCloudL3NetworkResource updateResult = await l3Network.UpdateAsync(patch);
            Assert.AreEqual(updateResult.Data.Tags, patch.Tags);

            // Delete
            var deleteResponse = await l3Network.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResponse.HasCompleted);
        }
    }
}
