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
    public class L2NetworksTests : NetworkCloudManagementTestBase
    {
        public L2NetworksTests   (bool isAsync, RecordedTestMode mode) : base(isAsync, mode) {}
        public L2NetworksTests  (bool isAsync) : base(isAsync) {}

        [Test, MaxTime(1800000)]
        public async Task L2Networks()
        {
            var l2NetworkCollection = ResourceGroupResource.GetL2Networks();
            var l2NetworkName = Recording.GenerateAssetName("l2network");

            var l2NetworkId = L2NetworkResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, ResourceIdentifier.Parse(ResourceGroupResource.Id).Name, l2NetworkName);
            var l2Network = Client.GetL2NetworkResource(l2NetworkId);

            // Create
            L2NetworkData data = new L2NetworkData(new AzureLocation(TestEnvironment.Location), new ExtendedLocation(TestEnvironment.ClusterExtendedLocation, "CustomLocation"), TestEnvironment.L2IsolationDomainId)
            {};
            ArmOperation<L2NetworkResource> l2NetworkResourceOp = await l2NetworkCollection.CreateOrUpdateAsync(WaitUntil.Completed, l2NetworkName, data);
            Assert.AreEqual(l2NetworkResourceOp.Value.Data.Name ,l2NetworkName);

            // Get
            L2NetworkResource getResult = await l2Network.GetAsync();
            Assert.AreEqual(getResult.Data.Name, l2NetworkName);

            // List by Resource Group
            var listByResourceGroup = new List<L2NetworkResource>();
            L2NetworkCollection collection = ResourceGroupResource.GetL2Networks();
            await foreach (L2NetworkResource item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            // List by Subscription
            var listBySubscription = new List<L2NetworkResource>();
              await foreach (L2NetworkResource item in SubscriptionResource.GetL2NetworksAsync())
            {
                listBySubscription.Add(item);
            }
            Assert.IsNotEmpty(listBySubscription);

            // Update
             L2NetworkPatch patch = new L2NetworkPatch()
            {
                Tags =
                    {
                        ["key1"] = "myvalue1",
                    },
            };
            L2NetworkResource updateResult = await l2Network.UpdateAsync(patch);
            Assert.AreEqual(updateResult.Data.Tags, patch.Tags);

            // Delete
            var deleteResponse = await l2Network.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResponse.HasCompleted);
        }
    }
}
