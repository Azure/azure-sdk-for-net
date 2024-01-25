// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ManagedNetworkFabric.Models;
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
            ResourceIdentifier l3IsolationDomainId = new ResourceIdentifier(TestEnvironment.Existing_L3ISD_ID);
            NetworkFabricL3IsolationDomainResource l3IsolationDomain = Client.GetNetworkFabricL3IsolationDomainResource(l3IsolationDomainId);

            TestContext.Out.WriteLine($"Entered into the ExternalNetwork tests....");
            TestContext.Out.WriteLine($"Provided ExternalNetwork name : {TestEnvironment.ExternalNetworkName}");

            l3IsolationDomain = await l3IsolationDomain.GetAsync();

            ResourceIdentifier externalNetworkResourceId = NetworkFabricExternalNetworkResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroupName, l3IsolationDomain.Data.Name, TestEnvironment.ExternalNetworkName);
            TestContext.Out.WriteLine($"externalNetworkResourceId: {externalNetworkResourceId}");
            NetworkFabricExternalNetworkResource externalNetwork = Client.GetNetworkFabricExternalNetworkResource(externalNetworkResourceId);

            TestContext.Out.WriteLine($"ExternalNetwork Test started.....");

            NetworkFabricExternalNetworkCollection collection = l3IsolationDomain.GetNetworkFabricExternalNetworks();

            // Create
            TestContext.Out.WriteLine($"PUT started.....");
            NetworkFabricExternalNetworkData data = new NetworkFabricExternalNetworkData(PeeringOption.OptionA)
            {
                Annotation = "annotation",
                OptionBProperties = new L3OptionBProperties()
                {
                    RouteTargets = new RouteTargetInformation()
                    {
                        ImportIPv4RouteTargets =
                        {
                            "65046:10039"
                        },
                        ImportIPv6RouteTargets =
                        {
                            "65046:10039"
                        },
                        ExportIPv4RouteTargets =
                        {
                            "65046:10039"
                        },
                        ExportIPv6RouteTargets =
                        {
                            "65046:10039"
                        },
                    },
                },
                OptionAProperties = new ExternalNetworkOptionAProperties()
                {
                    Mtu = 1500,
                    VlanId = 1001,
                    PeerAsn = 65047,
                    BfdConfiguration = new BfdConfiguration()
                    {
                        IntervalInMilliSeconds = 300,
                        Multiplier = 15,
                    },
                    PrimaryIPv4Prefix = "10.1.1.0/30",
                    PrimaryIPv6Prefix = "3FFE:FFFF:0:CD30::a0/127",
                    SecondaryIPv4Prefix = "10.1.1.4/30",
                    SecondaryIPv6Prefix = "3FFE:FFFF:0:CD30::a4/127",
                },
            };
            ArmOperation<NetworkFabricExternalNetworkResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, TestEnvironment.ExternalNetworkName, data);
            NetworkFabricExternalNetworkResource createResult = lro.Value;
            Assert.AreEqual(createResult.Data.Name, TestEnvironment.ExternalNetworkName);

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            NetworkFabricExternalNetworkResource getResult = await externalNetwork.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, TestEnvironment.ExternalNetworkName);

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<NetworkFabricExternalNetworkResource>();
            await foreach (NetworkFabricExternalNetworkResource item in collection.GetAllAsync())
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
