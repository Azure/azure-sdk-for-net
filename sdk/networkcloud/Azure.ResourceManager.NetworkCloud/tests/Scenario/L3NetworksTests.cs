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
        public async Task L3Networks()
        {
            var l3NetworkCollection = ResourceGroupResource.GetL3Networks();
            var l3NetworkName = TestEnvironment.L3NetworkName;

            var l3NetworkId = L3NetworkResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, ResourceIdentifier.Parse(ResourceGroupResource.Id).Name, l3NetworkName);
            var l3Network = Client.GetL3NetworkResource(l3NetworkId);

            // Create
            L3NetworkData data = new L3NetworkData(new AzureLocation(TestEnvironment.Location), new ExtendedLocation(TestEnvironment.ClusterExtendedLocation, "CustomLocation"), TestEnvironment.L3IsolationDomainId, TestEnvironment.L3Vlan)
            {
                IPv4ConnectedPrefix = TestEnvironment.L3Ipv4Prefix,
                IPv6ConnectedPrefix = TestEnvironment.L3Ipv6Prefix,
            };
            ArmOperation<L3NetworkResource> l3NetworkResourceOp = await l3NetworkCollection.CreateOrUpdateAsync(WaitUntil.Completed, l3NetworkName, data);
            Assert.AreEqual(l3NetworkResourceOp.Value.Data.Name ,l3NetworkName);

            // Get
            L3NetworkResource getResult = await l3Network.GetAsync();
            Assert.AreEqual(getResult.Data.Name, l3NetworkName);

            // List by Resource Group
            var listByResourceGroup = new List<L3NetworkResource>();
            L3NetworkCollection collection = ResourceGroupResource.GetL3Networks();
            await foreach (L3NetworkResource item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            // List by Subscription
            var listBySubscription = new List<L3NetworkResource>();
              await foreach (L3NetworkResource item in SubscriptionResource.GetL3NetworksAsync())
            {
                listBySubscription.Add(item);
            }
            Assert.IsNotEmpty(listBySubscription);

            // Update
             L3NetworkPatch patch = new L3NetworkPatch()
            {
                Tags =
                    {
                        ["key1"] = "myvalue1",
                    },
            };
            L3NetworkResource updateResult = await l3Network.UpdateAsync(patch);
            Assert.AreEqual(updateResult.Data.Tags, patch.Tags);

            // Delete
            var deleteResponse = await l3Network.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResponse.HasCompleted);
        }
    }
}