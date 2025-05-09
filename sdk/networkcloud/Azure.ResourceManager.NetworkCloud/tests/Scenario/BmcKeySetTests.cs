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
    public class BmcKeySetTests : NetworkCloudManagementTestBase
    {
        public BmcKeySetTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) {}
        public BmcKeySetTests(bool isAsync) : base(isAsync) {}

        [Test]
        [RecordedTest]
        public async Task BmcKeySet()
        {
            string bmcKeySetName = Recording.GenerateAssetName("bmckeyset");

            // retrieve a parent cluster
            NetworkCloudClusterResource cluster = Client.GetNetworkCloudClusterResource(TestEnvironment.ClusterId);
            cluster = await cluster.GetAsync();

            ResourceIdentifier bmcKeySetResourceId = NetworkCloudBmcKeySetResource.CreateResourceIdentifier(cluster.Id.SubscriptionId, cluster.Id.ResourceGroupName, cluster.Data.Name, bmcKeySetName);
            NetworkCloudBmcKeySetResource bmcKeySet = Client.GetNetworkCloudBmcKeySetResource(bmcKeySetResourceId);

            NetworkCloudBmcKeySetCollection collection = cluster.GetNetworkCloudBmcKeySets();

            // Create
            // Note: The UUIDs in this test are fake and was randomly generated for the test
            NetworkCloudBmcKeySetData data = new NetworkCloudBmcKeySetData
            (
                cluster.Data.Location,
                cluster.Data.ClusterExtendedLocation,
                "6f935d96-417e-4cf3-b099-30995848e8fd",
                TestEnvironment.DayFromNow,
                BmcKeySetPrivilegeLevel.ReadOnly,
                new KeySetUser[]
                {
                new KeySetUser("test-user", "test-user-description", new NetworkCloudSshPublicKey(TestEnvironment.BMCSSHPubicKey), "6f935d96-417e-4cf3-b099-30995848e8fb", null){}
                }
            )
            {
                Tags =
                {
                    ["key1"] = "myvalue1",
                },
            };
            ArmOperation<NetworkCloudBmcKeySetResource> createResult = await collection.CreateOrUpdateAsync(WaitUntil.Completed, bmcKeySetName, data);
            Assert.AreEqual(bmcKeySetName, createResult.Value.Data.Name);

            // Get
            var getResult = await bmcKeySet.GetAsync();
            Assert.AreEqual(bmcKeySetName, getResult.Value.Data.Name);

            // List by cluster
            var listByCluster = new List<NetworkCloudBmcKeySetResource>();
            await foreach (NetworkCloudBmcKeySetResource item in collection.GetAllAsync())
            {
                listByCluster.Add(item);
            }
            Assert.IsNotEmpty(listByCluster);

            // Update
            NetworkCloudBmcKeySetPatch patch = new NetworkCloudBmcKeySetPatch()
            {
                Tags =
                {
                    ["key1"] = "myvalue1",
                    ["key2"] = "myvalue2",
                },
            };
            ArmOperation<NetworkCloudBmcKeySetResource> updateResult = await bmcKeySet.UpdateAsync(WaitUntil.Completed, patch);
            Assert.AreEqual(patch.Tags, updateResult.Value.Data.Tags);

            // Delete
            var deleteResult = await bmcKeySet.DeleteAsync(WaitUntil.Completed, CancellationToken.None);
            Assert.IsTrue(deleteResult.HasCompleted);
        }
    }
}
