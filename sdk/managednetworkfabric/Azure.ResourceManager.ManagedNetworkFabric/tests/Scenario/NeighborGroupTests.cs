// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ManagedNetworkFabric.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ManagedNetworkFabric.Tests.Scenario
{
    public class NeighborGroupTests : ManagedNetworkFabricManagementTestBase
    {
        public NeighborGroupTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }
        public NeighborGroupTests(bool isAsync) : base(isAsync) { }

        [Test]
        [RecordedTest]
        [AsyncOnly]
        public async Task NeighborGroup()
        {
            TestContext.Out.WriteLine($"Entered into the NeighborGroup tests....");
            TestContext.Out.WriteLine($"Provided TestEnvironment.NeighborGroupName name : {TestEnvironment.NeighborGroupName}");
            ResourceIdentifier neighborGroupResourceId = NetworkFabricNeighborGroupResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroupName, TestEnvironment.NeighborGroupName);
            TestContext.Out.WriteLine($"neighborGroupResourceId: {neighborGroupResourceId}");
            TestContext.Out.WriteLine($"NeighborGroup Test started.....");
            NetworkFabricNeighborGroupCollection collection = ResourceGroupResource.GetNetworkFabricNeighborGroups();

            // Create
            TestContext.Out.WriteLine($"PUT started.....");
            NetworkFabricNeighborGroupData data = new NetworkFabricNeighborGroupData(new AzureLocation("eastus"))
            {
                Annotation = "annotation",
                Destination = new NeighborGroupDestination()
                {
                    IPv4Addresses =
                    {
                        IPAddress.Parse("10.10.10.10"),IPAddress.Parse("20.10.10.10"),IPAddress.Parse("30.10.10.10"),IPAddress.Parse("40.10.10.10"),IPAddress.Parse("50.10.10.10"),IPAddress.Parse("60.10.10.10"),IPAddress.Parse("70.10.10.10"),IPAddress.Parse("80.10.10.10"),IPAddress.Parse("90.10.10.10")
                    },
                    IPv6Addresses =
                    {
                    "2F::/100"
                    },
                },
                Tags =
                {
                    ["key8107"] = "1234",
                },
            };
            ArmOperation<NetworkFabricNeighborGroupResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, TestEnvironment.NeighborGroupName, data);
            NetworkFabricNeighborGroupResource result = lro.Value;
            NetworkFabricNeighborGroupData resourceData = result.Data;
            Assert.AreEqual(resourceData.Name, TestEnvironment.NeighborGroupName);

            // Update
            NetworkFabricNeighborGroupPatch patch = new NetworkFabricNeighborGroupPatch()
            {
                Annotation = "Updating",
                Destination = new NeighborGroupDestination()
                {
                    IPv4Addresses =
                    {
                        IPAddress.Parse("10.10.10.10"),IPAddress.Parse("20.10.10.10"),IPAddress.Parse("30.10.10.10"),IPAddress.Parse("40.10.10.10"),IPAddress.Parse("50.10.10.10"),IPAddress.Parse("60.10.10.10"),IPAddress.Parse("70.10.10.10"),IPAddress.Parse("80.10.10.10"),IPAddress.Parse("90.10.10.10")
                    },
                    IPv6Addresses =
                        {
                            "2F::/100", "3F::/100"
                        },
                },
                Tags =
                {
                    ["key6025"] = "2345",
                },
            };
            NetworkFabricNeighborGroupResource networkFabricNeighborGroup = Client.GetNetworkFabricNeighborGroupResource(resourceData.Id);
            TestContext.Out.WriteLine($"PATCH - test started.");
            ArmOperation<NetworkFabricNeighborGroupResource> lroPatch = await networkFabricNeighborGroup.UpdateAsync(WaitUntil.Completed, patch);
            NetworkFabricNeighborGroupResource resultPatch = lroPatch.Value;
            NetworkFabricNeighborGroupData resourcePatchData = resultPatch.Data;
            Assert.AreEqual(resourcePatchData.Destination.IPv6Addresses.Count, 2);
            TestContext.Out.WriteLine($"PATCH - test completed.");

            NetworkFabricNeighborGroupResource ntpResource = Client.GetNetworkFabricNeighborGroupResource(neighborGroupResourceId);
            // Get
            TestContext.Out.WriteLine($"GET started.....");
            NetworkFabricNeighborGroupResource getResult = await ntpResource.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, TestEnvironment.NeighborGroupName);

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<NetworkFabricNeighborGroupResource>();
            await foreach (NetworkFabricNeighborGroupResource item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            //List by subscription
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId);
            SubscriptionResource subscriptionResource = Client.GetSubscriptionResource(subscriptionResourceId);
            TestContext.Out.WriteLine($"GET - List by Subscription started.....");
            await foreach (NetworkFabricNeighborGroupResource item in subscriptionResource.GetNetworkFabricNeighborGroupsAsync())
            {
                TestContext.WriteLine($"Succeeded on id: {item.Id}");
            }
            TestContext.Out.WriteLine($"List by Subscription operation succeeded.");

            // Delete
            TestContext.Out.WriteLine($"DELETE started.....");
            var deleteResponse = await networkFabricNeighborGroup.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResponse.HasCompleted);
        }
    }
}
