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

            ResourceIdentifier ipCommunityResourceId = NetworkFabricIPCommunityResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroupName, TestEnvironment.IpCommunityName);
            TestContext.Out.WriteLine($"IpCommunityResourceId: {ipCommunityResourceId}");

            // Get the collection of this IpCommunity
            NetworkFabricIPCommunityCollection collection = ResourceGroupResource.GetNetworkFabricIPCommunities();

            TestContext.Out.WriteLine($"IpCommunity Test started.....");

            // Create
            TestContext.Out.WriteLine($"PUT started.....");
            NetworkFabricIPCommunityData data = new NetworkFabricIPCommunityData(new AzureLocation(TestEnvironment.Location))
            {
                Annotation = "annotation",
                IPCommunityRules =
                {
                    new IPCommunityRule( CommunityActionType.Permit, 4155123341, new string[] { "1:1" })
                    {
                        WellKnownCommunities =
                        {
                            WellKnownCommunity.Internet
                        },
                    }
                },
                Tags =
                {
                    ["keyId"] = "KeyValue",
                },
            };

            ArmOperation<NetworkFabricIPCommunityResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, TestEnvironment.IpCommunityName, data);
            NetworkFabricIPCommunityResource createResult = lro.Value;
            NetworkFabricIPCommunityResource ipCommunity = Client.GetNetworkFabricIPCommunityResource(ipCommunityResourceId);
            Assert.AreEqual(createResult.Data.Name, TestEnvironment.IpCommunityName);

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            NetworkFabricIPCommunityResource getResult = await ipCommunity.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, TestEnvironment.IpCommunityName);

            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<NetworkFabricIPCommunityResource>();
            NetworkFabricIPCommunityCollection collectionOp = ResourceGroupResource.GetNetworkFabricIPCommunities();
            await foreach (NetworkFabricIPCommunityResource item in collectionOp.GetAllAsync())
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
