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
    public class ExternalNetworkTests : ManagedNetworkFabricManagementTestBase
    {
        public ExternalNetworkTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }
        public ExternalNetworkTests(bool isAsync) : base(isAsync) { }

        [Test]
        [RecordedTest]
        [AsyncOnly]
        public async Task ExternalNetworks()
        {
            string subscriptionId = TestEnvironment.SubscriptionId;
            string resourceGroupName = TestEnvironment.ResourceGroupName;
            ResourceIdentifier validL3IsolationDomainId = TestEnvironment.ValidL3IsolationDomainId;
            string l3IsolationDomainName = TestEnvironment.ValidL3IsolationDomainName;
            string externalNetworkName = TestEnvironment.ExternalNetworkName;

            TestContext.Out.WriteLine($"Entered into the ExternalNetwork tests....");
            TestContext.Out.WriteLine($"Provided ExternalNetwork name : {externalNetworkName}");

            L3IsolationDomainResource l3IsolationDomain = Client.GetL3IsolationDomainResource(validL3IsolationDomainId);
            l3IsolationDomain = await l3IsolationDomain.GetAsync();

            ResourceIdentifier externalNetworkResourceId = ExternalNetworkResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, l3IsolationDomain.Data.Name, externalNetworkName);
            TestContext.Out.WriteLine($"externalNetworkResourceId: {externalNetworkResourceId}");
            ExternalNetworkResource externalNetwork = Client.GetExternalNetworkResource(externalNetworkResourceId);

            TestContext.Out.WriteLine($"ExternalNetwork Test started.....");

            ExternalNetworkCollection collection = l3IsolationDomain.GetExternalNetworks();

            // Create
            TestContext.Out.WriteLine($"PUT started.....");
            ExternalNetworkData data = new ExternalNetworkData(PeeringOption.OptionA)
            {
                OptionBProperties = new OptionBProperties()
                {
                    ImportRouteTargets =
                    {
                        "65541:2001"
                    },
                    ExportRouteTargets =
                    {
                        "65531:2001"
                    },
                },
                OptionAProperties = new ExternalNetworkPropertiesOptionAProperties()
                {
                    Mtu = 1500,
                    VlanId = 524,
                    PeerASN = 65047,
                    BfdConfiguration = new BfdConfiguration(),
                    PrimaryIPv4Prefix = "172.23.1.0/31",
                    PrimaryIPv6Prefix = "3FFE:FFFF:0:CD30::a0/127",
                    SecondaryIPv4Prefix = "172.23.1.2/31",
                    SecondaryIPv6Prefix = "3FFE:FFFF:0:CD30::a4/127",
                },
                ImportRoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.ManagedNetworkFabric/routePolicies/routePolicyName",
                ExportRoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.ManagedNetworkFabric/routePolicies/routePolicyName",
            };
            ArmOperation<ExternalNetworkResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, externalNetworkName, data);
            ExternalNetworkResource createResult = lro.Value;
            Assert.AreEqual(createResult.Data.Name, externalNetworkName);

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            ExternalNetworkResource getResult = await externalNetwork.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, externalNetworkName);

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<ExternalNetworkResource>();
            await foreach (ExternalNetworkResource item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            // Delete
            TestContext.Out.WriteLine($"DELETE started.....");
            var deleteResponse = await externalNetwork.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResponse.HasCompleted);
        }
    }
}
