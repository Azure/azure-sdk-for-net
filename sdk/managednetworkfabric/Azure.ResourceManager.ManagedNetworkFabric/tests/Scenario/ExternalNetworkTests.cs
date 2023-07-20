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
            L3IsolationDomainResource l3IsolationDomain = Client.GetL3IsolationDomainResource(l3IsolationDomainId);

            TestContext.Out.WriteLine($"Entered into the ExternalNetwork tests....");
            TestContext.Out.WriteLine($"Provided ExternalNetwork name : {TestEnvironment.ExternalNetworkName}");

            l3IsolationDomain = await l3IsolationDomain.GetAsync();

            ResourceIdentifier externalNetworkResourceId = ExternalNetworkResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroupName, l3IsolationDomain.Data.Name, TestEnvironment.ExternalNetworkName);
            TestContext.Out.WriteLine($"externalNetworkResourceId: {externalNetworkResourceId}");
            ExternalNetworkResource externalNetwork = Client.GetExternalNetworkResource(externalNetworkResourceId);

            TestContext.Out.WriteLine($"ExternalNetwork Test started.....");

            ExternalNetworkCollection collection = l3IsolationDomain.GetExternalNetworks();

            // Create
            TestContext.Out.WriteLine($"PUT started.....");
            ExternalNetworkData data = new ExternalNetworkData(PeeringOption.OptionA)
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
                OptionAProperties = new ExternalNetworkPropertiesOptionAProperties()
                {
                    Mtu = 1500,
                    VlanId = 1001,
                    PeerASN = 65047,
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
            ArmOperation<ExternalNetworkResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, TestEnvironment.ExternalNetworkName, data);
            ExternalNetworkResource createResult = lro.Value;
            Assert.AreEqual(createResult.Data.Name, TestEnvironment.ExternalNetworkName);

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            ExternalNetworkResource getResult = await externalNetwork.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, TestEnvironment.ExternalNetworkName);

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
