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
    public class InternalNetworkTests : ManagedNetworkFabricManagementTestBase
    {
        public InternalNetworkTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }
        public InternalNetworkTests(bool isAsync) : base(isAsync) { }

        [Test]
        [RecordedTest]
        [AsyncOnly]
        public async Task InternalNetworks()
        {
            ResourceIdentifier l3IsolationDomainId = new ResourceIdentifier(TestEnvironment.Existing_L3ISD_ID);
            NetworkFabricL3IsolationDomainResource l3IsolationDomain = Client.GetNetworkFabricL3IsolationDomainResource(l3IsolationDomainId);
            TestContext.Out.WriteLine($"Entered into the InternalNetwork tests....");
            TestContext.Out.WriteLine($"Provided InternalNetworks name : {TestEnvironment.InternalNetworkName}");

            l3IsolationDomain = await l3IsolationDomain.GetAsync();

            ResourceIdentifier internalNetworkResourceId = NetworkFabricInternalNetworkResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroupName, l3IsolationDomain.Data.Name, TestEnvironment.InternalNetworkName);
            TestContext.Out.WriteLine($"internalNetworkResourceId: {internalNetworkResourceId}");
            NetworkFabricInternalNetworkResource internalNetwork = Client.GetNetworkFabricInternalNetworkResource(internalNetworkResourceId);

            TestContext.Out.WriteLine($"InternalNetwork Test started.....");

            NetworkFabricInternalNetworkCollection collection = l3IsolationDomain.GetNetworkFabricInternalNetworks();

            // Create
            TestContext.Out.WriteLine($"PUT started.....");
            NetworkFabricInternalNetworkData data = new NetworkFabricInternalNetworkData(755)
            {
                Annotation = "annotation",
                Mtu = 1500,
                ConnectedIPv4Subnets =
                {
                    new ConnectedSubnet("100.0.0.0/24")
                    {
                        Annotation = "annotation",
                    }
                },
                IsMonitoringEnabled = IsMonitoringEnabled.True,
                Extension = StaticRouteConfigurationExtension.NoExtension,
                BgpConfiguration = new InternalNetworkBgpConfiguration()
                {
                    BfdConfiguration = new BfdConfiguration()
                    {
                        IntervalInMilliSeconds = 300,
                        Multiplier = 5,
                    },
                    DefaultRouteOriginate = NetworkFabricBooleanValue.True,
                    AllowAS = 10,
                    AllowASOverride = AllowASOverride.Enable,
                    PeerAsn = 61234,
                    IPv4ListenRangePrefixes =
                    {
                        "100.0.0.0/25"
                    },
                    IPv4NeighborAddress =
                    {
                        new NeighborAddress()
                        {
                            Address = "100.0.0.10",
                        }
                    },
                    Annotation = "annotation",
                },
                StaticRouteConfiguration = new InternalNetworkStaticRouteConfiguration()
                {
                    Extension = StaticRouteConfigurationExtension.NoExtension,
                    BfdConfiguration = new BfdConfiguration()
                    {
                        IntervalInMilliSeconds = 300,
                        Multiplier = 15,
                    },
                    IPv4Routes =
                    {
                        new StaticRouteProperties("100.0.0.0/24",new string[] { "20.0.0.1" })
                    },
                },
            };
            ArmOperation<NetworkFabricInternalNetworkResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, TestEnvironment.InternalNetworkName, data);
            NetworkFabricInternalNetworkResource createResult = lro.Value;
            Assert.AreEqual(createResult.Data.Name, TestEnvironment.InternalNetworkName);

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            NetworkFabricInternalNetworkResource getResult = await internalNetwork.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, TestEnvironment.InternalNetworkName);

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<NetworkFabricInternalNetworkResource>();
            await foreach (NetworkFabricInternalNetworkResource item in collection.GetAllAsync())
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
