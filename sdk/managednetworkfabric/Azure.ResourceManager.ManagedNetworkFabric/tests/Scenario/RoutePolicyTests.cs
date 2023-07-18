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
    public class RoutePolicyTests : ManagedNetworkFabricManagementTestBase
    {
        public RoutePolicyTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }
        public RoutePolicyTests(bool isAsync) : base(isAsync) { }

        [Test]
        [RecordedTest]
        [AsyncOnly]
        public async Task RoutePolicies()
        {
            string subscriptionId = TestEnvironment.SubscriptionId;
            string resourceGroupName = TestEnvironment.ResourceGroupName;
            string routePolicyName = TestEnvironment.RoutePolicyName;

            TestContext.Out.WriteLine($"Entered into the RoutePolicy tests....");
            TestContext.Out.WriteLine($"Provided routePolicyName name : {routePolicyName}");

            ResourceIdentifier routePolicyResourceId = RoutePolicyResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, routePolicyName);
            TestContext.Out.WriteLine($"routePolicyResourceId: {routePolicyResourceId}");

            TestContext.Out.WriteLine($"RoutePolicy Test started.....");

            RoutePolicyCollection collection = ResourceGroupResource.GetRoutePolicies();

            // Create
            TestContext.Out.WriteLine($"PUT started.....");
            RoutePolicyData data =
                new RoutePolicyData(new AzureLocation(TestEnvironment.Location), new RoutePolicyStatementProperties[]
                {
                    new RoutePolicyStatementProperties(7,new StatementConditionProperties()
                    {
                        IPCommunityIds =
                        {
                            "/subscriptions/61065ccc-9543-4b91-b2d1-0ce42a914507/resourceGroups/nfa-tool-ts-clisdktest-nfrg060523/providers/Microsoft.ManagedNetworkFabric/ipCommunities/nfa-tool-ts-sdk-ipCommunity061623"
                        },
                        IPExtendedCommunityIds =
                        {
                            "/subscriptions/61065ccc-9543-4b91-b2d1-0ce42a914507/resourceGroups/nfa-tool-ts-clisdktest-nfrg060523/providers/Microsoft.ManagedNetworkFabric/ipExtendedCommunities/nfa-tool-ts-sdk-ipExtendedCommunity061623"
                        },
                        IPPrefixId = "/subscriptions/61065ccc-9543-4b91-b2d1-0ce42a914507/resourceGroups/nfa-tool-ts-clisdktest-nfrg060523/providers/Microsoft.ManagedNetworkFabric/ipPrefixes/nfa-tool-ts-sdk-ipPrefix061623"
                    },
                    new StatementActionProperties(CommunityActionType.Permit)
                    {
                        LocalPreference = 20,
                        IPCommunityProperties = new ActionIPCommunityProperties()
                        {
                            AddIPCommunityIds =
                            {
                                "/subscriptions/61065ccc-9543-4b91-b2d1-0ce42a914507/resourceGroups/nfa-tool-ts-clisdktest-nfrg060523/providers/Microsoft.ManagedNetworkFabric/ipCommunities/nfa-tool-ts-sdk-ipCommunity061623"
                            },
                            DeleteIPCommunityIds =
                            {
                                "/subscriptions/61065ccc-9543-4b91-b2d1-0ce42a914507/resourceGroups/nfa-tool-ts-clisdktest-nfrg060523/providers/Microsoft.ManagedNetworkFabric/ipCommunities/nfa-tool-ts-sdk-ipCommunity061623"
                            },
                            SetIPCommunityIds =
                            {
                                "/subscriptions/61065ccc-9543-4b91-b2d1-0ce42a914507/resourceGroups/nfa-tool-ts-clisdktest-nfrg060523/providers/Microsoft.ManagedNetworkFabric/ipCommunities/nfa-tool-ts-sdk-ipCommunity061623"
                            }
                        },
                        IPExtendedCommunityProperties = new ActionIPExtendedCommunityProperties()
                        {
                            AddIPExtendedCommunityIds =
                            {
                                "/subscriptions/61065ccc-9543-4b91-b2d1-0ce42a914507/resourceGroups/nfa-tool-ts-clisdktest-nfrg060523/providers/Microsoft.ManagedNetworkFabric/ipExtendedCommunities/nfa-tool-ts-sdk-ipExtendedCommunity061623"
                            },
                            DeleteIPExtendedCommunityIds =
                            {
                                "/subscriptions/61065ccc-9543-4b91-b2d1-0ce42a914507/resourceGroups/nfa-tool-ts-clisdktest-nfrg060523/providers/Microsoft.ManagedNetworkFabric/ipExtendedCommunities/nfa-tool-ts-sdk-ipExtendedCommunity061623"
                            },
                            SetIPExtendedCommunityIds =
                            {
                                "/subscriptions/61065ccc-9543-4b91-b2d1-0ce42a914507/resourceGroups/nfa-tool-ts-clisdktest-nfrg060523/providers/Microsoft.ManagedNetworkFabric/ipExtendedCommunities/nfa-tool-ts-sdk-ipExtendedCommunity061623"
                            }
                        }
                    })
                    {
                        Annotation = "annotationValue",
                    }
                })
                {
                    Annotation = "annotationValue",
                    Tags =
                    {
                        ["key8254"] = "",
                    },
                };

            ArmOperation<RoutePolicyResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, routePolicyName, data);
            RoutePolicyResource createResult = lro.Value;
            Assert.AreEqual(createResult.Data.Name, routePolicyName);

            RoutePolicyResource routePolicy = Client.GetRoutePolicyResource(routePolicyResourceId);

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            RoutePolicyResource getResult = await routePolicy.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, routePolicyName);

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<RoutePolicyResource>();
            await foreach (RoutePolicyResource item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            TestContext.Out.WriteLine($"GET - List by Subscription started.....");
            var listBySubscription = new List<RoutePolicyResource>();
            await foreach (RoutePolicyResource item in DefaultSubscription.GetRoutePoliciesAsync())
            {
                listBySubscription.Add(item);
                Console.WriteLine($"Succeeded on id: {item}");
            }
            Assert.IsNotEmpty(listBySubscription);

            // Delete
            TestContext.Out.WriteLine($"DELETE started.....");
            var deleteResponse = await routePolicy.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResponse.HasCompleted);
        }
    }
}
