// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ManagedNetworkFabric.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ManagedNetworkFabric.Tests
{
    public class NetworkToNetworkInterconnectTests : ManagedNetworkFabricManagementTestBase
    {
        public NetworkToNetworkInterconnectTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }
        public NetworkToNetworkInterconnectTests(bool isAsync) : base(isAsync) { }

        [Test]
        [RecordedTest]
        [AsyncOnly]
        public async Task NetworkToNetworkInterconnects()
        {
            string subscriptionId = TestEnvironment.SubscriptionId;
            string resourceGroupName = TestEnvironment.ResourceGroupName;
            ResourceIdentifier validNetworkFabricId = TestEnvironment.ValidNetworkFabricIdForNNI;
            string networkFabricName = TestEnvironment.ValidNetworkFabricNameForNNI;
            string networkToNetworkInterconnectName= TestEnvironment.NetworkToNetworkInterConnectName;

            TestContext.Out.WriteLine($"Entered into the NetworkToNetworkInterConnects tests....");
            TestContext.Out.WriteLine($"Provided NetworkFabric name : {networkFabricName}");

            NetworkFabricResource networkFabric = Client.GetNetworkFabricResource(validNetworkFabricId);
            networkFabric = await networkFabric.GetAsync();

            ResourceIdentifier networkToNetworkInterconnectId = NetworkToNetworkInterconnectResource.CreateResourceIdentifier(subscriptionId, ResourceGroupResource.Id.Name, networkFabricName, networkToNetworkInterconnectName);
            TestContext.Out.WriteLine($"networkToNetworkInterconnectId: {networkToNetworkInterconnectId}");
            NetworkToNetworkInterconnectResource nni = Client.GetNetworkToNetworkInterconnectResource(networkToNetworkInterconnectId);

            TestContext.Out.WriteLine($"NNI Test started.....");

            NetworkToNetworkInterconnectCollection collection = networkFabric.GetNetworkToNetworkInterconnects();

            // Create
            TestContext.Out.WriteLine($"PUT started.....");
            NetworkToNetworkInterconnectData data = new NetworkToNetworkInterconnectData()
            {
                IsManagementType = BooleanEnumProperty.True,
                UseOptionB = BooleanEnumProperty.False,
                Layer2Configuration = new Layer2Configuration(1500)
                {
                    PortCount = 10,
                },
                Layer3Configuration = new Layer3Configuration()
                {
                    ImportRoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.ManagedNetworkFabric/routePolicies/routePolicyName1",
                    ExportRoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.ManagedNetworkFabric/routePolicies/routePolicyName2",
                    PeerASN = 50272,
                    VlanId = 2064,
                    PrimaryIPv4Prefix = "172.31.0.0/31",
                    PrimaryIPv6Prefix = "3FFE:FFFF:0:CD30::a0/126",
                    SecondaryIPv4Prefix = "172.31.0.20/31",
                    SecondaryIPv6Prefix = "3FFE:FFFF:0:CD30::a4/126",
                },
            };
            ArmOperation<NetworkToNetworkInterconnectResource> createResult = await collection.CreateOrUpdateAsync(WaitUntil.Completed, networkToNetworkInterconnectName, data);
            Assert.AreEqual(createResult.Value.Data.Name, networkToNetworkInterconnectName);

            NetworkToNetworkInterconnectResource networkToNetworkInterconnect = Client.GetNetworkToNetworkInterconnectResource(networkToNetworkInterconnectId);

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            NetworkToNetworkInterconnectResource getResult = await networkToNetworkInterconnect.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, networkToNetworkInterconnectName);

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<NetworkToNetworkInterconnectResource>();
            NetworkToNetworkInterconnectCollection collectionOp = networkFabric.GetNetworkToNetworkInterconnects();
            await foreach (NetworkToNetworkInterconnectResource item in collectionOp.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            // Delete
            TestContext.Out.WriteLine($"DELETE started.....");
            var deleteResponse = await networkToNetworkInterconnect.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResponse.HasCompleted);
        }
    }
}
