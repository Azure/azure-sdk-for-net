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
            ResourceIdentifier networkFabricId = new ResourceIdentifier(TestEnvironment.Existing_NotProvisioned_NF_ID);

            string networkFabricName = networkFabricId.Name;

            TestContext.Out.WriteLine($"Entered into the NetworkToNetworkInterConnects tests....");
            TestContext.Out.WriteLine($"Provided NetworkFabric name : {networkFabricName}");

            NetworkFabricResource networkFabric = Client.GetNetworkFabricResource(networkFabricId);
            networkFabric = await networkFabric.GetAsync();

            ResourceIdentifier networkToNetworkInterconnectId = NetworkToNetworkInterconnectResource.CreateResourceIdentifier(subscriptionId, ResourceGroupResource.Id.Name, networkFabricName, TestEnvironment.NetworkToNetworkInterConnectName);
            TestContext.Out.WriteLine($"networkToNetworkInterconnectId: {networkToNetworkInterconnectId}");
            NetworkToNetworkInterconnectResource nni = Client.GetNetworkToNetworkInterconnectResource(networkToNetworkInterconnectId);

            TestContext.Out.WriteLine($"NNI Test started.....");

            NetworkToNetworkInterconnectCollection collection = networkFabric.GetNetworkToNetworkInterconnects();

            #region NNI create Test
            // Create
            TestContext.Out.WriteLine($"PUT started.....");

            NetworkToNetworkInterconnectData data = new NetworkToNetworkInterconnectData(NetworkFabricBooleanValue.True)
            {
                NniType = NniType.CE,
                IsManagementType = IsManagementType.True,
                Layer2Configuration = new Layer2Configuration()
                {
                    Mtu = 1500
                },
                OptionBLayer3Configuration = new NetworkToNetworkInterconnectOptionBLayer3Configuration()
                {
                    PeerAsn = 61234,
                    VlanId = 1234,
                    PrimaryIPv4Prefix = "10.0.0.12/30",
                    PrimaryIPv6Prefix = "4FFE:FFFF:0:CD30::a8/127",
                    SecondaryIPv4Prefix = "40.0.0.14/30",
                    SecondaryIPv6Prefix = "6FFE:FFFF:0:CD30::ac/127",
                },
                ImportRoutePolicy = new ImportRoutePolicyInformation()
                {
                    ImportIPv4RoutePolicyId = new ResourceIdentifier(TestEnvironment.ExistingRoutePolicyId),
                },
                ExportRoutePolicy = new ExportRoutePolicyInformation()
                {
                    ExportIPv4RoutePolicyId = new ResourceIdentifier(TestEnvironment.ExistingRoutePolicyId),
                }
            };
            ArmOperation<NetworkToNetworkInterconnectResource> createResult = await collection.CreateOrUpdateAsync(WaitUntil.Completed, TestEnvironment.NetworkToNetworkInterConnectName, data);
            Assert.AreEqual(createResult.Value.Data.Name, TestEnvironment.NetworkToNetworkInterConnectName);

            #endregion

            NetworkToNetworkInterconnectResource networkToNetworkInterconnect = Client.GetNetworkToNetworkInterconnectResource(networkToNetworkInterconnectId);

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            NetworkToNetworkInterconnectResource getResult = await networkToNetworkInterconnect.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, TestEnvironment.NetworkToNetworkInterConnectName);

            // List
            TestContext.Out.WriteLine($"GET - List by Fabric started.....");
            var listByResourceGroup = new List<NetworkToNetworkInterconnectResource>();
            NetworkToNetworkInterconnectCollection collectionOp = networkFabric.GetNetworkToNetworkInterconnects();
            await foreach (NetworkToNetworkInterconnectResource item in collectionOp.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            // Delete
            TestContext.Out.WriteLine($"DELETE started.....");
            ArmOperation deleteResponse = await networkToNetworkInterconnect.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResponse.HasCompleted);
        }
    }
}
