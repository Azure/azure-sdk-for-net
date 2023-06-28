// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        public async Task IpCommunities()
        {
            string subscriptionId = TestEnvironment.SubscriptionId;
            string resourceGroupName = TestEnvironment.ResourceGroupName;
            string ipCommunityName = TestEnvironment.IpCommunityName;

            TestContext.Out.WriteLine($"Entered into the IpCommunity tests....");
            TestContext.Out.WriteLine($"Provided IpCommunityName name : {ipCommunityName}");

            ResourceIdentifier ipCommunityResourceId = IPCommunityResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, ipCommunityName);
            TestContext.Out.WriteLine($"IpCommunityResourceId: {ipCommunityResourceId}");

            // Get the collection of this IpCommunity
            IPCommunityCollection collection = ResourceGroupResource.GetIPCommunities();

            TestContext.Out.WriteLine($"IpCommunity Test started.....");

            // Create
            TestContext.Out.WriteLine($"PUT started.....");
            IPCommunityData data = new IPCommunityData(new AzureLocation(TestEnvironment.Location))
            {
                Annotation = "annotationValue",
                Action = CommunityActionType.Permit,
                WellKnownCommunities =
                {
                    WellKnownCommunity.Internet,WellKnownCommunity.LocalAS,WellKnownCommunity.NoExport,WellKnownCommunity.GShut
                },
                CommunityMembers =
                {
                    "1234:5678"
                },
                Tags =
                {
                    ["key2814"] = "",
                },
            };

            ArmOperation<IPCommunityResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, ipCommunityName, data);
            IPCommunityResource createResult = lro.Value;
            Assert.AreEqual(createResult.Data.Name, ipCommunityName);

            IPCommunityResource ipCommunity = Client.GetIPCommunityResource(ipCommunityResourceId);

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            IPCommunityResource getResult = await ipCommunity.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, ipCommunityName);

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<IPCommunityResource>();
            IPCommunityCollection collectionOp = ResourceGroupResource.GetIPCommunities();
            await foreach (IPCommunityResource item in collectionOp.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            TestContext.Out.WriteLine($"GET - List by Subscription started.....");
            var listBySubscription = new List<IPCommunityResource>();
            await foreach (IPCommunityResource item in DefaultSubscription.GetIPCommunitiesAsync())
            {
                listBySubscription.Add(item);
                Console.WriteLine($"Succeeded on id: {item}");
            }
            Assert.IsNotEmpty(listBySubscription);

            // Delete
            TestContext.Out.WriteLine($"DELETE started.....");
            var deleteResponse = await ipCommunity.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResponse.HasCompleted);
        }
    }
}
