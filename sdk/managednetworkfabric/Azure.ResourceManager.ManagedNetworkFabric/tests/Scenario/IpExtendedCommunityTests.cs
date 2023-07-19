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

            ResourceIdentifier ipExtendedCommunityResourceId = IPExtendedCommunityResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroupName, TestEnvironment.IpExtendedCommunityName);
            TestContext.Out.WriteLine($"ipExtendedCommunityResourceId: {ipExtendedCommunityResourceId}");

            // Get the collection of this IpExtendedCommunity
            IPExtendedCommunityCollection collection = ResourceGroupResource.GetIPExtendedCommunities();

            TestContext.Out.WriteLine($"IpExtendedCommunityTest started.....");

            // Create
            TestContext.Out.WriteLine($"PUT started.....");
            IPExtendedCommunityData data = new IPExtendedCommunityData(new AzureLocation(TestEnvironment.Location), new IPExtendedCommunityRule[] { new IPExtendedCommunityRule(CommunityActionType.Permit, 4155123341, new string[] { "1234:2345" }) })
            {
                Annotation = "annotation",
                Tags =
                {
                    ["keyID"] = "KeyValue",
                },
            };

            ArmOperation<IPExtendedCommunityResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, TestEnvironment.IpExtendedCommunityName, data);
            IPExtendedCommunityResource createResult = lro.Value;
            Assert.AreEqual(createResult.Data.Name, TestEnvironment.IpExtendedCommunityName);

            IPExtendedCommunityResource ipExtendedCommunity = Client.GetIPExtendedCommunityResource(ipExtendedCommunityResourceId);

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            IPExtendedCommunityResource getResult = await ipExtendedCommunity.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, TestEnvironment.IpExtendedCommunityName);

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<IPExtendedCommunityResource>();
            IPExtendedCommunityCollection collectionOp = ResourceGroupResource.GetIPExtendedCommunities();
            await foreach (IPExtendedCommunityResource item in collectionOp.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            /*            TestContext.Out.WriteLine($"GET - List by Subscription started.....");
                        var listBySubscription = new List<IPExtendedCommunityResource>();
                        await foreach (IPExtendedCommunityResource item in DefaultSubscription.GetIPExtendedCommunitiesAsync())
                        {
                            listBySubscription.Add(item);
                            Console.WriteLine($"Succeeded on id: {item}");
                        }
                        Assert.IsNotEmpty(listBySubscription);*/

            // Delete
            TestContext.Out.WriteLine($"DELETE started.....");
            var deleteResponse = await ipExtendedCommunity.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResponse.HasCompleted);
        }
    }
}
