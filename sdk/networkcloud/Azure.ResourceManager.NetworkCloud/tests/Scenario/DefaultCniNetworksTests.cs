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
    public class DefaultCniNetworksTests : NetworkCloudManagementTestBase
    {
        public DefaultCniNetworksTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) {}
        public DefaultCniNetworksTests(bool isAsync) : base(isAsync) {}

        [Test]
        public async Task DefaultCniNetworks()
        {
            string defaultCniNetworkName = TestEnvironment.DefaultCniNetworkName;
            DefaultCniNetworkCollection collection = ResourceGroupResource.GetDefaultCniNetworks();
            ResourceIdentifier defaultCniNetworkResourceId = DefaultCniNetworkResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, ResourceGroupResource.Id.Name, defaultCniNetworkName);
            DefaultCniNetworkResource defaultCniNetwork = Client.GetDefaultCniNetworkResource(defaultCniNetworkResourceId);

            // Create
            DefaultCniNetworkData data =
            new DefaultCniNetworkData
            (
                TestEnvironment.Location,
                new ExtendedLocation(TestEnvironment.ClusterExtendedLocation, "CustomLocation"),
                TestEnvironment.L3IsolationDomainId,
                TestEnvironment.L3Vlan
            )
            {
                IPv4ConnectedPrefix = TestEnvironment.L3Ipv4Prefix,
                IPv6ConnectedPrefix = TestEnvironment.L3Ipv6Prefix,
                Tags =
                {
                    ["key1"] = "myvalue1",
                },
            };
            ArmOperation<DefaultCniNetworkResource> createResult = await collection.CreateOrUpdateAsync(WaitUntil.Completed, defaultCniNetworkName, data);
            Assert.AreEqual(defaultCniNetworkName, createResult.Value.Data.Name);

            // Get
            DefaultCniNetworkResource getResult = await defaultCniNetwork.GetAsync();
            Assert.AreEqual(defaultCniNetworkName, getResult.Data.Name);

            // Update
            DefaultCniNetworkPatch patch = new DefaultCniNetworkPatch()
            {
                Tags =
                {
                    ["key1"] = "myvalue1",
                    ["key2"] = "myvalue2",
                },
            };
            DefaultCniNetworkResource updateResult = await defaultCniNetwork.UpdateAsync(patch);
            Assert.AreEqual(patch.Tags, updateResult.Data.Tags);

            // List by Resource Group
            var listByResourceGroup = new List<DefaultCniNetworkResource>();
            await foreach (var item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            // List by Subscription
            var listBySubscription = new List<DefaultCniNetworkResource>();
            await foreach (var item in SubscriptionResource.GetDefaultCniNetworksAsync())
            {
                listBySubscription.Add(item);
            }
            Assert.IsNotEmpty(listBySubscription);

            // Delete
            var deleteResult = await defaultCniNetwork.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResult.HasCompleted);
        }
    }
}