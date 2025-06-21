// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ManagedNetworkFabric.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ManagedNetworkFabric.Tests.Scenario
{
    public class IpCommunityTests : ManagedNetworkFabricManagementTestBase
    {
        public IpCommunityTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }
        public IpCommunityTests(bool isAsync) : base(isAsync) { }

        [Test]
        [RecordedTest]
        [AsyncOnly]
        public async Task IpCommunitiesCRUD()
        {
            TestContext.Out.WriteLine($"Entered into the IP Community tests....");
            TestContext.Out.WriteLine($"Provided IP CommunityName name : {TestEnvironment.IpCommunityName}");
            TestContext.Out.WriteLine($"IpCommunity Test started.....");

            // Get the collection
            TestContext.Out.WriteLine($"Getting IP Community collection....");
            ResourceIdentifier resourceGroupId = ResourceGroupResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroupName);
            ResourceGroupResource resourceGroup = Client.GetResourceGroupResource(resourceGroupId);
            NetworkFabricIPCommunityCollection collection = resourceGroup.GetNetworkFabricIPCommunities();

            // Create
            TestContext.Out.WriteLine($"PUT started.....");
            string ipCommunityName = TestEnvironment.IpCommunityName;
            IPCommunityRule[] rules = new[]
            {
                new IPCommunityRule(CommunityActionType.Permit, 4155123341, new[] { "1:1" })
                {
                    WellKnownCommunities = { WellKnownCommunity.Internet }
                }
            };
            IPCommunityProperties properties = new IPCommunityProperties(rules)
            {
                Annotation = "annotation",
            };
            NetworkFabricIPCommunityData data = new NetworkFabricIPCommunityData(new AzureLocation(TestEnvironment.Location), properties)
            {
                Tags =
                {
                    ["keyId"] = "KeyValue",
                },
            };

            // Create the resource
            ArmOperation<NetworkFabricIPCommunityResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, ipCommunityName, data);
            NetworkFabricIPCommunityResource ipCommunity = lro.Value;
            Assert.AreEqual(ipCommunityName, ipCommunity.Data.Name);

            // Get the resource and verify
            TestContext.Out.WriteLine($"GET started.....");
            Response<NetworkFabricIPCommunityResource> response = await ipCommunity.GetAsync();
            NetworkFabricIPCommunityResource getResult = response.Value;
            Assert.AreEqual(ipCommunityName, getResult.Data.Name);

            // List by resource group
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            List<NetworkFabricIPCommunityResource> listByResourceGroup = new List<NetworkFabricIPCommunityResource>();
            await foreach (NetworkFabricIPCommunityResource item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId);
            SubscriptionResource subscriptionResource = Client.GetSubscriptionResource(subscriptionResourceId);

            TestContext.Out.WriteLine($"GET - List by Subscription started.....");

            await foreach (NetworkFabricIPCommunityResource item in subscriptionResource.GetNetworkFabricIPCommunitiesAsync())
            {
                NetworkFabricIPCommunityData resourceData = item.Data;
                TestContext.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            TestContext.Out.WriteLine($"List by Subscription operation succeeded.");

            // Delete
            TestContext.Out.WriteLine($"DELETE started.....");
            ArmOperation deleteResponse = await ipCommunity.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResponse.HasCompleted);
        }
    }
}
