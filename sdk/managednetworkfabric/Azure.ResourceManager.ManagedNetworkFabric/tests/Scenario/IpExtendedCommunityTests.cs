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
    public class IpExtendedCommunityTests : ManagedNetworkFabricManagementTestBase
    {
        public IpExtendedCommunityTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }
        public IpExtendedCommunityTests(bool isAsync) : base(isAsync) { }

        [Test]
        [RecordedTest]
        [AsyncOnly]
        public async Task IpExtendedCommunities()
        {
            string subscriptionId = TestEnvironment.SubscriptionId;
            string resourceGroupName = TestEnvironment.ResourceGroupName;
            string IpExtendedCommunityName = TestEnvironment.IpExtendedCommunityName;

            TestContext.Out.WriteLine($"Entered into the IpExtendedCommunity tests....");
            TestContext.Out.WriteLine($"Provided IpExtendedCommunityName name : {IpExtendedCommunityName}");

            ResourceIdentifier ipExtendedCommunityResourceId = IPExtendedCommunityResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, IpExtendedCommunityName);
            TestContext.Out.WriteLine($"ipExtendedCommunityResourceId: {ipExtendedCommunityResourceId}");

            // Get the collection of this IpExtendedCommunity
            IPExtendedCommunityCollection collection = ResourceGroupResource.GetIPExtendedCommunities();

            TestContext.Out.WriteLine($"IpExtendedCommunityTest started.....");

            // Create
            TestContext.Out.WriteLine($"PUT started.....");
            IPExtendedCommunityData data = new IPExtendedCommunityData(new AzureLocation(TestEnvironment.Location))
            {
                Annotation = "annotationValue",
                Action = CommunityActionType.Permit,
                RouteTargets =
                {
                    "1234:5678"
                },
                Tags =
                {
                    ["key5054"] = "key",
                },
            };

            ArmOperation<IPExtendedCommunityResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, IpExtendedCommunityName, data);
            IPExtendedCommunityResource createResult = lro.Value;
            Assert.AreEqual(createResult.Data.Name, IpExtendedCommunityName);

            IPExtendedCommunityResource ipExtendedCommunity = Client.GetIPExtendedCommunityResource(ipExtendedCommunityResourceId);

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            IPExtendedCommunityResource getResult = await ipExtendedCommunity.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, IpExtendedCommunityName);

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<IPExtendedCommunityResource>();
            IPExtendedCommunityCollection collectionOp = ResourceGroupResource.GetIPExtendedCommunities();
            await foreach (IPExtendedCommunityResource item in collectionOp.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            TestContext.Out.WriteLine($"GET - List by Subscription started.....");
            var listBySubscription = new List<IPExtendedCommunityResource>();
            await foreach (IPExtendedCommunityResource item in DefaultSubscription.GetIPExtendedCommunitiesAsync())
            {
                listBySubscription.Add(item);
                Console.WriteLine($"Succeeded on id: {item}");
            }
            Assert.IsNotEmpty(listBySubscription);

            // Delete
            TestContext.Out.WriteLine($"DELETE started.....");
            var deleteResponse = await ipExtendedCommunity.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResponse.HasCompleted);
        }
    }
}
