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
    public class L2NetworksTests : NetworkCloudManagementTestBase
    {
        public L2NetworksTests   (bool isAsync, RecordedTestMode mode) : base(isAsync, mode) {}
        public L2NetworksTests  (bool isAsync) : base(isAsync) {}

        [Test, MaxTime(1800000)]
        [RecordedTest]
        public async Task L2Networks()
        {
            var l2NetworkCollection = ResourceGroupResource.GetNetworkCloudL2Networks();
            var l2NetworkName = Recording.GenerateAssetName("l2network");

            var l2NetworkId = NetworkCloudL2NetworkResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, ResourceIdentifier.Parse(ResourceGroupResource.Id).Name, l2NetworkName);
            var l2Network = Client.GetNetworkCloudL2NetworkResource(l2NetworkId);

            // Create
            NetworkCloudL2NetworkData data = new NetworkCloudL2NetworkData(new AzureLocation(TestEnvironment.Location), new ExtendedLocation(TestEnvironment.ClusterExtendedLocation, "CustomLocation"), new ResourceIdentifier(TestEnvironment.L2IsolationDomainId))
            {};
            ArmOperation<NetworkCloudL2NetworkResource> l2NetworkResourceOp = await l2NetworkCollection.CreateOrUpdateAsync(WaitUntil.Completed, l2NetworkName, data);
            Assert.AreEqual(l2NetworkResourceOp.Value.Data.Name ,l2NetworkName);

            // Get
            NetworkCloudL2NetworkResource getResult = await l2Network.GetAsync();
            Assert.AreEqual(getResult.Data.Name, l2NetworkName);

            // List by Resource Group
            var listByResourceGroup = new List<NetworkCloudL2NetworkResource>();
            NetworkCloudL2NetworkCollection collection = ResourceGroupResource.GetNetworkCloudL2Networks();
            await foreach (NetworkCloudL2NetworkResource item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            // List by Subscription
            var listBySubscription = new List<NetworkCloudL2NetworkResource>();
              await foreach (NetworkCloudL2NetworkResource item in SubscriptionResource.GetNetworkCloudL2NetworksAsync())
            {
                listBySubscription.Add(item);
            }
            Assert.IsNotEmpty(listBySubscription);

            // Update
            NetworkCloudL2NetworkPatch patch = new NetworkCloudL2NetworkPatch()
            {
                Tags =
                    {
                        ["key1"] = "myvalue1",
                    },
            };
            NetworkCloudL2NetworkResource updateResult = await l2Network.UpdateAsync(patch);
            Assert.AreEqual(updateResult.Data.Tags, patch.Tags);

            // Delete
            var deleteResponse = await l2Network.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
            Assert.IsTrue(deleteResponse.HasCompleted);
        }
    }
}
