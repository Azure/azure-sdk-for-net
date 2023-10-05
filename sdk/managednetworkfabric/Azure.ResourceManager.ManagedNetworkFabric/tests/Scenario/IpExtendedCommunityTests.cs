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
    public class IpExtendedCommunityTests : ManagedNetworkFabricManagementTestBase
    {
        public IpExtendedCommunityTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }
        public IpExtendedCommunityTests(bool isAsync) : base(isAsync) { }

        [Test]
        [RecordedTest]
        [AsyncOnly]
        public async Task IpExtendedCommunities()
        {
            TestContext.Out.WriteLine($"Provided  IpExtendedCommunityName name : {TestEnvironment.IpExtendedCommunityName}");

            ResourceIdentifier ipExtendedCommunityResourceId = NetworkFabricIPExtendedCommunityResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroupName, TestEnvironment.IpExtendedCommunityName);
            TestContext.Out.WriteLine($"ipExtendedCommunityResourceId: {ipExtendedCommunityResourceId}");

            // Get the collection of this IpExtendedCommunity
            NetworkFabricIPExtendedCommunityCollection collection = ResourceGroupResource.GetNetworkFabricIPExtendedCommunities();

            TestContext.Out.WriteLine($"IpExtendedCommunityTest started.....");

            // Create
            TestContext.Out.WriteLine($"PUT started.....");
            NetworkFabricIPExtendedCommunityData data = new NetworkFabricIPExtendedCommunityData(new AzureLocation(TestEnvironment.Location), new IPExtendedCommunityRule[] { new IPExtendedCommunityRule(CommunityActionType.Permit, 4155123341, new string[] { "1234:2345" }) })
            {
                Annotation = "annotation",
                Tags =
                {
                    ["keyID"] = "KeyValue",
                },
            };

            ArmOperation<NetworkFabricIPExtendedCommunityResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, TestEnvironment.IpExtendedCommunityName, data);
            NetworkFabricIPExtendedCommunityResource createResult = lro.Value;
            Assert.AreEqual(createResult.Data.Name, TestEnvironment.IpExtendedCommunityName);

            NetworkFabricIPExtendedCommunityResource ipExtendedCommunity = Client.GetNetworkFabricIPExtendedCommunityResource(ipExtendedCommunityResourceId);

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            NetworkFabricIPExtendedCommunityResource getResult = await ipExtendedCommunity.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, TestEnvironment.IpExtendedCommunityName);

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<NetworkFabricIPExtendedCommunityResource>();
            NetworkFabricIPExtendedCommunityCollection collectionOp = ResourceGroupResource.GetNetworkFabricIPExtendedCommunities();
            await foreach (NetworkFabricIPExtendedCommunityResource item in collectionOp.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            //List by subscription
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId);
            SubscriptionResource subscriptionResource = Client.GetSubscriptionResource(subscriptionResourceId);

            TestContext.Out.WriteLine($"GET - List by Subscription started.....");

            await foreach (NetworkFabricIPExtendedCommunityResource item in subscriptionResource.GetNetworkFabricIPExtendedCommunitiesAsync())
            {
                NetworkFabricIPExtendedCommunityData resourceData = item.Data;
                TestContext.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            TestContext.Out.WriteLine($"List by Subscription operation succeeded.");

            // Delete
            TestContext.Out.WriteLine($"DELETE started.....");
            var deleteResponse = await ipExtendedCommunity.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResponse.HasCompleted);
        }
    }
}
