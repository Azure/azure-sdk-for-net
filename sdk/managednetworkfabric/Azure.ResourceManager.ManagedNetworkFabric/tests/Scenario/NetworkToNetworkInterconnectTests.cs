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
            ResourceIdentifier networkFabricId = new ResourceIdentifier("/subscriptions/9531faa8-8c39-4165-b033-48697fe943db/resourceGroups/nfa-tool-ts-clisdktest-GA-nfrg071323/providers/Microsoft.ManagedNetworkFabric/networkFabrics/nfa-tool-ts-GA-nf071823-postTest");//TestEnvironment.Provisioned_NF_ID);

            string networkFabricName = networkFabricId.Name;
            string networkToNetworkInterconnectName = TestEnvironment.NetworkToNetworkInterConnectName;

            TestContext.Out.WriteLine($"Entered into the NetworkToNetworkInterConnects tests....");
            TestContext.Out.WriteLine($"Provided NetworkFabric name : {networkFabricName}");

            NetworkFabricResource networkFabric = Client.GetNetworkFabricResource(networkFabricId);
            networkFabric = await networkFabric.GetAsync();

            ResourceIdentifier networkToNetworkInterconnectId = NetworkToNetworkInterconnectResource.CreateResourceIdentifier(subscriptionId, ResourceGroupResource.Id.Name, networkFabricName, networkToNetworkInterconnectName);
            TestContext.Out.WriteLine($"networkToNetworkInterconnectId: {networkToNetworkInterconnectId}");
            NetworkToNetworkInterconnectResource nni = Client.GetNetworkToNetworkInterconnectResource(networkToNetworkInterconnectId);

            TestContext.Out.WriteLine($"NNI Test started.....");

            NetworkToNetworkInterconnectCollection collection = networkFabric.GetNetworkToNetworkInterconnects();

            #region NNI create Test
            // Create
            TestContext.Out.WriteLine($"PUT started.....");

            NetworkToNetworkInterconnectData data = new NetworkToNetworkInterconnectData(BooleanEnumProperty.True)
            {
                NniType = NniType.CE,
                IsManagementType = IsManagementType.True,
                Layer2Configuration = new Layer2Configuration()
                {
                    Mtu = 1500
                },
                OptionBLayer3Configuration = new NetworkToNetworkInterconnectPropertiesOptionBLayer3Configuration()
                {
                    PeerASN = 61234,
                    VlanId = 1234,
                    PrimaryIPv4Prefix = "10.0.0.12/30",
                    PrimaryIPv6Prefix = "4FFE:FFFF:0:CD30::a8/127",
                    SecondaryIPv4Prefix = "40.0.0.14/30",
                    SecondaryIPv6Prefix = "6FFE:FFFF:0:CD30::ac/127",
                },
                ImportRoutePolicy = new ImportRoutePolicyInformation()
                {
                    ImportIPv4RoutePolicyId = new ResourceIdentifier("/subscriptions/9531faa8-8c39-4165-b033-48697fe943db/resourceGroups/nfa-tool-ts-clisdktest-GA-nfrg071323/providers/Microsoft.ManagedNetworkFabric/routePolicies/nfa-tool-ts-GA-routePolicy071423"),
                },
                ExportRoutePolicy = new ExportRoutePolicyInformation()
                {
                    ExportIPv4RoutePolicyId = new ResourceIdentifier("/subscriptions/9531faa8-8c39-4165-b033-48697fe943db/resourceGroups/nfa-tool-ts-clisdktest-GA-nfrg071323/providers/Microsoft.ManagedNetworkFabric/routePolicies/nfa-tool-ts-GA-routePolicy071423"),
                }
            };
            ArmOperation<NetworkToNetworkInterconnectResource> createResult = await collection.CreateOrUpdateAsync(WaitUntil.Completed, networkToNetworkInterconnectName, data);
            Assert.AreEqual(createResult.Value.Data.Name, networkToNetworkInterconnectName);

            #endregion

/*            #region NNI update
            // invoke the operation
            NetworkToNetworkInterconnectPatch nniPatch = new NetworkToNetworkInterconnectPatch()
            {
                Layer2Configuration = new Layer2Configuration()
                {
                    Mtu = 1500,
                    Interfaces = //To-Do need to add the valid interface
                    {
                        new ResourceIdentifier("/subscriptions/1234ABCD-0A1B-1234-5678-123456ABCDEF/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/networkDevices/example-networkDevice/networkInterfaces/example-networkInterface")
                    },
                },
                OptionBLayer3Configuration = new OptionBLayer3Configuration()
                {
                    PeerASN = 2345,
                    VlanId = 1235,
                    PrimaryIPv4Prefix = "20.0.0.12/29",
                    PrimaryIPv6Prefix = "4FFE:FFFF:0:CD30::a8/127",
                    SecondaryIPv4Prefix = "20.0.0.14/29",
                    SecondaryIPv6Prefix = "6FFE:FFFF:0:CD30::ac/127",
                },
                NpbStaticRouteConfiguration = new NpbStaticRouteConfiguration()
                {
                    BfdConfiguration = new BfdConfiguration()
                    {
                        IntervalInMilliSeconds = 310,
                        Multiplier = 15,
                    },
                    IPv4Routes =
                    {
                        new StaticRouteProperties("20.0.0.11/30",new string[]
                        {
                            "21.20.20.10"
                        })
                    },
                    IPv6Routes =
                    {
                        new StaticRouteProperties("4FFE:FFFF:0:CD30::ac/127",new string[]
                        {
                            "5FFE:FFFF:0:CD30::ac"
                        })
                    },
                },
                ImportRoutePolicy = new ImportRoutePolicyInformation()
                {
                    ImportIPv4RoutePolicyId = new ResourceIdentifier("/subscriptions/1234ABCD-0A1B-1234-5678-123456ABCDEF/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/routePolicies/example-routePolicy1"),
                    ImportIPv6RoutePolicyId = new ResourceIdentifier("/subscriptions/1234ABCD-0A1B-1234-5678-123456ABCDEF/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/routePolicies/example-routePolicy1"),
                },
                ExportRoutePolicy = new ExportRoutePolicyInformation()
                {
                    ExportIPv4RoutePolicyId = new ResourceIdentifier("/subscriptions/1234ABCD-0A1B-1234-5678-123456ABCDEF/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/routePolicies/example-routePolicy1"),
                    ExportIPv6RoutePolicyId = new ResourceIdentifier("/subscriptions/1234ABCD-0A1B-1234-5678-123456ABCDEF/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/routePolicies/example-routePolicy1"),
                },
                EgressAclId = new ResourceIdentifier("/subscriptions/1234ABCD-0A1B-1234-5678-123456ABCDEF/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/accessControlLists/example-acl"),
                IngressAclId = new ResourceIdentifier("/subscriptions/1234ABCD-0A1B-1234-5678-123456ABCDEF/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/accessControlLists/example-acl"),
            };
            ArmOperation<NetworkToNetworkInterconnectResource> lro = await nni.UpdateAsync(WaitUntil.Completed, nniPatch);
            #endregion*/

            NetworkToNetworkInterconnectResource networkToNetworkInterconnect = Client.GetNetworkToNetworkInterconnectResource(networkToNetworkInterconnectId);

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            NetworkToNetworkInterconnectResource getResult = await networkToNetworkInterconnect.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, networkToNetworkInterconnectName);

            // List
            TestContext.Out.WriteLine($"GET - List by Fabric started.....");
            var listByResourceGroup = new List<NetworkToNetworkInterconnectResource>();
            NetworkToNetworkInterconnectCollection collectionOp = networkFabric.GetNetworkToNetworkInterconnects();
            await foreach (NetworkToNetworkInterconnectResource item in collectionOp.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

/*            // Post Action: Update Administrative State //TO-Do Not yet supported
            UpdateAdministrativeState body = new UpdateAdministrativeState()
            {
                State = EnableDisableState.Enable
            };
            ArmOperation<CommonPostActionResponseForStateUpdate> updateAdministrativeStateResponse = await networkToNetworkInterconnect.UpdateAdministrativeStateAsync(WaitUntil.Completed, body);
            CommonPostActionResponseForStateUpdate result = updateAdministrativeStateResponse.Value;

            //Post Action: Update NpbStaticRouteBFD Administrative state
            ArmOperation<CommonPostActionResponseForStateUpdate> updateBFDState = await networkToNetworkInterconnect.UpdateNpbStaticRouteBfdAdministrativeStateAsync(WaitUntil.Completed, body);*/

            // Delete
            TestContext.Out.WriteLine($"DELETE started.....");
            var deleteResponse = await networkToNetworkInterconnect.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResponse.HasCompleted);
        }
    }
}
