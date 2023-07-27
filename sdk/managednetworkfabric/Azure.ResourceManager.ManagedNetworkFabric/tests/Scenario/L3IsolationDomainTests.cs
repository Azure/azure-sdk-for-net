// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.ManagedNetworkFabric;
using Azure.ResourceManager.ManagedNetworkFabric.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ManagedNetworkFabric.Tests.Scenario
{
    public class L3IsolationDomainTests : ManagedNetworkFabricManagementTestBase
    {
        public L3IsolationDomainTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }
        public L3IsolationDomainTests(bool isAsync) : base(isAsync) { }

        [Test]
        [RecordedTest]
        [AsyncOnly]
        public async Task L3IsolationDomains()
        {
            string subscriptionId = TestEnvironment.SubscriptionId;
            string resourceGroupName = TestEnvironment.ResourceGroupName;
            string networkFabricId = TestEnvironment.ValidNetworkFabricId;
            string l3IsolationDomainName = TestEnvironment.L3IsolationDomainName;

            TestContext.Out.WriteLine($"Entered into the L3IsolationDomain tests....");
            TestContext.Out.WriteLine($"Provided L3IsolationDomains name : {l3IsolationDomainName}");

            ResourceIdentifier l3IsolationDomainResourceId = L3IsolationDomainResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, l3IsolationDomainName);
            TestContext.Out.WriteLine($"l3IsolationDomainResourceId: {l3IsolationDomainResourceId}");

            TestContext.Out.WriteLine($"L3IsolationDomains Test started.....");

            L3IsolationDomainCollection collection = ResourceGroupResource.GetL3IsolationDomains();

            // Create
            TestContext.Out.WriteLine($"PUT started.....");
            L3IsolationDomainData data = new L3IsolationDomainData(new AzureLocation("eastus"))
            {
                RedistributeConnectedSubnets = RedistributeConnectedSubnet.True,
                RedistributeStaticRoutes = RedistributeStaticRoute.False,
                AggregateRouteConfiguration = new AggregateRouteConfiguration()
                {
                    IPv4Routes =
                    {
                        new AggregateRoute()
                        {
                            Prefix = "10.0.0.1/27",
                        }
                    },
                    IPv6Routes =
                    {
                        new AggregateRoute()
                        {
                            Prefix = "2fff::/59",
                        }
                    }
                },
                ConnectedSubnetRoutePolicy = new L3IsolationDomainPatchPropertiesConnectedSubnetRoutePolicy()
                {
                    ExportRoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.ManagedNetworkFabric/routePolicies/routePolicyName2",
                },
                NetworkFabricId = networkFabricId
            };
            ArmOperation<L3IsolationDomainResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, l3IsolationDomainName, data);
            L3IsolationDomainResource createResult = lro.Value;
            Assert.AreEqual(createResult.Data.Name, l3IsolationDomainName);

            L3IsolationDomainResource l3IsolationDomain = Client.GetL3IsolationDomainResource(l3IsolationDomainResourceId);

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            L3IsolationDomainResource getResult = await l3IsolationDomain.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, l3IsolationDomainName);

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<L3IsolationDomainResource>();
            await foreach (L3IsolationDomainResource item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            TestContext.Out.WriteLine($"GET - List by Subscription started.....");
            var listBySubscription = new List<L3IsolationDomainResource>();
            await foreach (L3IsolationDomainResource item in DefaultSubscription.GetL3IsolationDomainsAsync())
            {
                listBySubscription.Add(item);
                Console.WriteLine($"Succeeded on id: {item}");
            }
            Assert.IsNotEmpty(listBySubscription);

            // Update Admin State
            TestContext.Out.WriteLine($"POST started.....");
            UpdateAdministrativeState body = new UpdateAdministrativeState()
            {
                State = AdministrativeState.Enable,
            };
            await l3IsolationDomain.UpdateAdministrativeStateAsync(WaitUntil.Started, body);

            body = new UpdateAdministrativeState()
            {
                State = AdministrativeState.Disable,
            };
            await l3IsolationDomain.UpdateAdministrativeStateAsync(WaitUntil.Started, body);

            // Delete
            TestContext.Out.WriteLine($"DELETE started.....");
            var deleteResponse = await l3IsolationDomain.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResponse.HasCompleted);
        }
    }
}
