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
    public class RoutePolicyTests : ManagedNetworkFabricManagementTestBase
    {
        public RoutePolicyTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }
        public RoutePolicyTests(bool isAsync) : base(isAsync) { }

        [Test]
        [RecordedTest]
        [AsyncOnly]
        public async Task RoutePolicies()
        {
            TestContext.Out.WriteLine($"Entered into the RoutePolicy tests....");
            TestContext.Out.WriteLine($"Provided TestEnvironment.RoutePolicyName name : {TestEnvironment.RoutePolicyName}");

            ResourceIdentifier routePolicyResourceId = NetworkFabricRoutePolicyResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroupName, TestEnvironment.RoutePolicyName);
            TestContext.Out.WriteLine($"routePolicyResourceId: {routePolicyResourceId}");

            TestContext.Out.WriteLine($"RoutePolicy Test started.....");

            NetworkFabricRoutePolicyCollection collection = ResourceGroupResource.GetNetworkFabricRoutePolicies();

            // Create
            TestContext.Out.WriteLine($"PUT started.....");

            NetworkFabricRoutePolicyData data = new NetworkFabricRoutePolicyData(new AzureLocation(TestEnvironment.Location), new ResourceIdentifier("/subscriptions/1234ABCD-0A1B-1234-5678-123456ABCDEF/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/networkFabrics/example-fabric"))
            {
                Annotation = "annotation",
                Statements =
                {
                    new RoutePolicyStatementProperties(
                        7,
                        new StatementConditionProperties()
                        {
                            RoutePolicyConditionType = RoutePolicyConditionType.Or,
                            IPPrefixId = new ResourceIdentifier("/subscriptions/9531faa8-8c39-4165-b033-48697fe943db/resourceGroups/nfa-tool-ts-clisdktest-GA-nfcrg071323/providers/Microsoft.ManagedNetworkFabric/ipPrefixes/nfa-tool-ts-GA-sdk-ipPrefix071423"),
                        },
                        new StatementActionProperties(RoutePolicyActionType.Deny)
                        {
                            LocalPreference = 20,
                        })
                    {
                        Annotation = "annotation",
                    }
                },
                AddressFamilyType = AddressFamilyType.IPv4,
                Tags =
                {
                    ["keyID"] = "keyValue",
                },
            };
            ArmOperation<NetworkFabricRoutePolicyResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, TestEnvironment.RoutePolicyName, data);
            NetworkFabricRoutePolicyResource createResult = lro.Value;
            Assert.AreEqual(createResult.Data.Name, TestEnvironment.RoutePolicyName);

            NetworkFabricRoutePolicyResource routePolicy = Client.GetNetworkFabricRoutePolicyResource(routePolicyResourceId);

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            NetworkFabricRoutePolicyResource getResult = await routePolicy.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, TestEnvironment.RoutePolicyName);

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<NetworkFabricRoutePolicyResource>();
            await foreach (NetworkFabricRoutePolicyResource item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            // Delete
            TestContext.Out.WriteLine($"DELETE started.....");
            var deleteResponse = await routePolicy.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResponse.HasCompleted);
        }
    }
}
