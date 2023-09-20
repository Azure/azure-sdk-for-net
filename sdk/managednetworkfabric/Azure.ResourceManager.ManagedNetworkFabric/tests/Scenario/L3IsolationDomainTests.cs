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
    public class L3IsolationDomainTests : ManagedNetworkFabricManagementTestBase
    {
        public L3IsolationDomainTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }
        public L3IsolationDomainTests(bool isAsync) : base(isAsync) { }

        [Test]
        [RecordedTest]
        [AsyncOnly]
        public async Task L3IsolationDomains()
        {
            TestContext.Out.WriteLine($"Entered into the L3IsolationDomain tests....");
            TestContext.Out.WriteLine($"Provided L3IsolationDomains name : {TestEnvironment.L3IsolationDomainName}");

            ResourceIdentifier l3IsolationDomainResourceId = NetworkFabricL3IsolationDomainResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroupName, TestEnvironment.L3IsolationDomainName);
            TestContext.Out.WriteLine($"l3IsolationDomainResourceId: {l3IsolationDomainResourceId}");

            TestContext.Out.WriteLine($"L3IsolationDomains Test started.....");

            NetworkFabricL3IsolationDomainCollection collection = ResourceGroupResource.GetNetworkFabricL3IsolationDomains();

            // Create
            TestContext.Out.WriteLine($"PUT started.....");
            NetworkFabricL3IsolationDomainData data = new NetworkFabricL3IsolationDomainData(new AzureLocation(TestEnvironment.Location), new ResourceIdentifier(TestEnvironment.Provisioned_NF_ID))
            {
                Annotation = "annotation",
                RedistributeConnectedSubnets = RedistributeConnectedSubnet.True,
                RedistributeStaticRoutes = RedistributeStaticRoute.False,
                AggregateRouteConfiguration = new AggregateRouteConfiguration()
                {
                    IPv4Routes =
                    {
                        new AggregateRoute("10.0.0.0/24")
                    },
                    IPv6Routes =
                    {
                        new AggregateRoute("3FFE:FFFF:0:CD30::a0/29")
                    },
                },
                Tags =
                {
                    ["keyID"] = "KeyValue",
                },
            };
            ArmOperation<NetworkFabricL3IsolationDomainResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, TestEnvironment.L3IsolationDomainName, data);
            NetworkFabricL3IsolationDomainResource createResult = lro.Value;
            Assert.AreEqual(createResult.Data.Name, TestEnvironment.L3IsolationDomainName);

            NetworkFabricL3IsolationDomainResource l3IsolationDomain = Client.GetNetworkFabricL3IsolationDomainResource(l3IsolationDomainResourceId);

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            NetworkFabricL3IsolationDomainResource getResult = await l3IsolationDomain.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, TestEnvironment.L3IsolationDomainName);

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<NetworkFabricL3IsolationDomainResource>();
            await foreach (NetworkFabricL3IsolationDomainResource item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            //List by subscription
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId);
            SubscriptionResource subscriptionResource = Client.GetSubscriptionResource(subscriptionResourceId);

            TestContext.Out.WriteLine($"GET - List by Subscription started.....");

            await foreach (NetworkFabricL3IsolationDomainResource item in subscriptionResource.GetNetworkFabricL3IsolationDomainsAsync())
            {
                NetworkFabricL3IsolationDomainData resourceData = item.Data;
                TestContext.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            TestContext.Out.WriteLine($"List by Subscription operation succeeded.");

            // Delete
            TestContext.Out.WriteLine($"DELETE started.....");
            ArmOperation deleteResponse = await l3IsolationDomain.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResponse.HasCompleted);

            // Update Admin State
            NetworkFabricL3IsolationDomainResource l3IsolationDomainForPostAction = Client.GetNetworkFabricL3IsolationDomainResource(new ResourceIdentifier(TestEnvironment.Existing_L3ISD_ID));
            TestContext.Out.WriteLine($"POST started.....");

            UpdateAdministrativeStateContent content = new UpdateAdministrativeStateContent()
            {
                State = AdministrativeEnableState.Enable,
            };
            await l3IsolationDomainForPostAction.UpdateAdministrativeStateAsync(WaitUntil.Completed, content);

            content = new UpdateAdministrativeStateContent()
            {
                State = AdministrativeEnableState.Disable,
            };
            await l3IsolationDomainForPostAction.UpdateAdministrativeStateAsync(WaitUntil.Completed, content);
        }
    }
}
