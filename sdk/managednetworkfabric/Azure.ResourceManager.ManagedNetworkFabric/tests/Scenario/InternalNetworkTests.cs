// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ManagedNetworkFabric.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ManagedNetworkFabric.Tests.Scenario
{
    public class InternalNetworkTests : ManagedNetworkFabricManagementTestBase
    {
        public InternalNetworkTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }
        public InternalNetworkTests(bool isAsync) : base(isAsync) { }

        [Test]
        [RecordedTest]
        [AsyncOnly]
        public async Task InternalNetworks()
        {
            string subscriptionId = TestEnvironment.SubscriptionId;
            string resourceGroupName = TestEnvironment.ResourceGroupName;
            ResourceIdentifier validL3IsolationDomainId = TestEnvironment.ValidL3IsolationDomainId;
            string l3IsolationDomainName = TestEnvironment.ValidL3IsolationDomainName;
            string internalNetworkName = TestEnvironment.InternalNetworkName;

            TestContext.Out.WriteLine($"Entered into the InternalNetwork tests....");
            TestContext.Out.WriteLine($"Provided InternalNetworks name : {internalNetworkName}");

            L3IsolationDomainResource l3IsolationDomain = Client.GetL3IsolationDomainResource(validL3IsolationDomainId);
            l3IsolationDomain = await l3IsolationDomain.GetAsync();

            ResourceIdentifier internalNetworkResourceId = InternalNetworkResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, l3IsolationDomain.Data.Name, internalNetworkName);
            TestContext.Out.WriteLine($"internalNetworkResourceId: {internalNetworkResourceId}");
            InternalNetworkResource internalNetwork = Client.GetInternalNetworkResource(internalNetworkResourceId);

            TestContext.Out.WriteLine($"InternalNetwork Test started.....");

            InternalNetworkCollection collection = l3IsolationDomain.GetInternalNetworks();

            // Create
            TestContext.Out.WriteLine($"PUT started.....");
            InternalNetworkData data = new InternalNetworkData(501)
            {
                Mtu = 1500,
                ConnectedIPv4Subnets =
                {
                    new ConnectedSubnet()
                    {
                        Prefix = "10.1.1.1/24",
                    }
                },
                ConnectedIPv6Subnets =
                {
                    new ConnectedSubnet()
                    {
                        Prefix = "2fff::/59",
                    }
                },
                StaticRouteConfiguration = new StaticRouteConfiguration()
                {
                    BfdConfiguration = new BfdConfiguration(),
                    IPv4Routes =
                    {
                        new StaticRouteProperties("10.0.0.1/28",new string[]
                        {
                            "10.1.0.1"
                        })
                    },
                    IPv6Routes =
                    {
                        new StaticRouteProperties("2fff::/59",new string[]
                        {
                            "3ffe::"
                        })
                    },
                },
                BgpConfiguration = new BgpConfiguration(6)
                {
                    BfdConfiguration = new BfdConfiguration(),
                    DefaultRouteOriginate = BooleanEnumProperty.True,
                    AllowAS = 1,
                    AllowASOverride = AllowASOverride.Enable,
                    IPv4ListenRangePrefixes =
                    {
                        "10.1.1.0/28"
                    },
                    IPv6ListenRangePrefixes =
                    {
                        "2fff::/59"
                    },
                    IPv4NeighborAddress =
                    {
                        new NeighborAddress()
                        {
                            Address = "10.1.1.0",
                        }
                    },
                    IPv6NeighborAddress =
                    {
                        new NeighborAddress()
                        {
                            Address = "2fff::",
                        }
                    },
                },
                ImportRoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.ManagedNetworkFabric/routePolicies/routePolicyName1",
                ExportRoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.ManagedNetworkFabric/routePolicies/routePolicyName2",
            };
            ArmOperation<InternalNetworkResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, internalNetworkName, data);
            InternalNetworkResource createResult = lro.Value;
            Assert.AreEqual(createResult.Data.Name, internalNetworkName);

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            InternalNetworkResource getResult = await internalNetwork.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, internalNetworkName);

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<InternalNetworkResource>();
            await foreach (InternalNetworkResource item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            // Delete
            TestContext.Out.WriteLine($"DELETE started.....");
            var deleteResponse = await internalNetwork.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResponse.HasCompleted);
        }
    }
}
