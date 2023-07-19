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
            TestContext.Out.WriteLine($"Entered into the L3IsolationDomain tests....");
            TestContext.Out.WriteLine($"Provided L3IsolationDomains name : {TestEnvironment.L3IsolationDomainName}");

            ResourceIdentifier l3IsolationDomainResourceId = L3IsolationDomainResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroupName, TestEnvironment.L3IsolationDomainName);
            TestContext.Out.WriteLine($"l3IsolationDomainResourceId: {l3IsolationDomainResourceId}");

            TestContext.Out.WriteLine($"L3IsolationDomains Test started.....");

            L3IsolationDomainCollection collection = ResourceGroupResource.GetL3IsolationDomains();

            // Create
            TestContext.Out.WriteLine($"PUT started.....");
            L3IsolationDomainData data = new L3IsolationDomainData(new AzureLocation(TestEnvironment.Location), new ResourceIdentifier(TestEnvironment.Provisioned_NF_ID))
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
            ArmOperation<L3IsolationDomainResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, TestEnvironment.L3IsolationDomainName, data);
            L3IsolationDomainResource createResult = lro.Value;
            Assert.AreEqual(createResult.Data.Name, TestEnvironment.L3IsolationDomainName);

            L3IsolationDomainResource l3IsolationDomain = Client.GetL3IsolationDomainResource(l3IsolationDomainResourceId);

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            L3IsolationDomainResource getResult = await l3IsolationDomain.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, TestEnvironment.L3IsolationDomainName);

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<L3IsolationDomainResource>();
            await foreach (L3IsolationDomainResource item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            /*            TestContext.Out.WriteLine($"GET - List by Subscription started.....");
                        var listBySubscription = new List<L3IsolationDomainResource>();
                        await foreach (L3IsolationDomainResource item in DefaultSubscription.GetL3IsolationDomainsAsync())
                        {
                            listBySubscription.Add(item);
                            Console.WriteLine($"Succeeded on id: {item}");
                        }
                        Assert.IsNotEmpty(listBySubscription);*/

          // Delete
            TestContext.Out.WriteLine($"DELETE started.....");
            ArmOperation deleteResponse = await l3IsolationDomain.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResponse.HasCompleted);

            // Update Admin State
            L3IsolationDomainResource l3IsolationDomainForPostAction = Client.GetL3IsolationDomainResource(new ResourceIdentifier(TestEnvironment.Existing_L3ISD_ID));
            TestContext.Out.WriteLine($"POST started.....");

            UpdateAdministrativeState body = new UpdateAdministrativeState()
            {
                State = EnableDisableState.Enable,
            };
            await l3IsolationDomainForPostAction.UpdateAdministrativeStateAsync(WaitUntil.Completed, body);

            body = new UpdateAdministrativeState()
            {
                State = EnableDisableState.Disable,
            };
            await l3IsolationDomainForPostAction.UpdateAdministrativeStateAsync(WaitUntil.Completed, body);
        }
    }
}
