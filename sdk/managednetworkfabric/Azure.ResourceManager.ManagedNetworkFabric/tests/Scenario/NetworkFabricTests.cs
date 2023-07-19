// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ManagedNetworkFabric.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Azure.ResourceManager.ManagedNetworkFabric.Tests.Scenario
{
    public class NetworkFabricTests : ManagedNetworkFabricManagementTestBase
    {
        public NetworkFabricTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }
        public NetworkFabricTests(bool isAsync) : base(isAsync) { }

        [Test]
        [RecordedTest]
        [AsyncOnly]
        public async Task NetworkFabrics()
        {
           NetworkFabricCollection collection = ResourceGroupResource.GetNetworkFabrics();
            //TO-DO:
            //string networkFabricNameForPostAction = TestEnvironment.NetworkFabricNameForPostAction;

            TestContext.Out.WriteLine($"Entered into the Network Fabric tests....");

            TestContext.Out.WriteLine($"Provided NetworkFabricControllerId : {TestEnvironment.Provisioned_NFC_ID}");
            TestContext.Out.WriteLine($"Provided NetworkFabric name : {TestEnvironment.NetworkFabricName}");

            ResourceIdentifier networkFabricResourceId = NetworkFabricResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroupName, TestEnvironment.NetworkFabricName);
            TestContext.Out.WriteLine($"networkFabricId: {networkFabricResourceId}");
            NetworkFabricResource networkFabric = Client.GetNetworkFabricResource(networkFabricResourceId);

            //ResourceIdentifier networkFabricResourceIdForPostAction = NetworkFabricResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroupName, networkFabricNameForPostAction);

            TestContext.Out.WriteLine($"networkFabricId: {networkFabricResourceId}");

            TestContext.Out.WriteLine($"Test started.....");

            #region Network Fabric create
            TestContext.Out.WriteLine($"PUT started.....");
            NetworkFabricData data = new NetworkFabricData(
                new AzureLocation("eastus2euap"),
                "fab3",
                new ResourceIdentifier(TestEnvironment.Provisioned_NFC_ID),
                7,
                "10.18.0.0/19",
                29249,
                new TerminalServerConfiguration()
                {
                    PrimaryIPv4Prefix = "10.0.0.12/30",
                    PrimaryIPv6Prefix = "4FFE:FFFF:0:CD30::a8/127",
                    SecondaryIPv4Prefix = "20.0.0.13/30",
                    SecondaryIPv6Prefix = "6FFE:FFFF:0:CD30::ac/127",
                    Username = "username",
                    Password = "xxxx",
                    SerialNumber = "123456",
                },
                new ManagementNetworkConfigurationProperties(
                    new VpnConfigurationProperties(PeeringOption.OptionA)
                    {
                        OptionBProperties = new OptionBProperties()
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
                        OptionAProperties = new VpnConfigurationPropertiesOptionAProperties()
                        {
                            PrimaryIPv4Prefix = "10.0.0.12/30",
                            PrimaryIPv6Prefix = "4FFE:FFFF:0:CD30::a8/127",
                            SecondaryIPv4Prefix = "20.0.0.13/30",
                            SecondaryIPv6Prefix = "6FFE:FFFF:0:CD30::ac/127",
                            Mtu = 1501,
                            VlanId = 3001,
                            PeerASN = 1235,
                            BfdConfiguration = new BfdConfiguration()
                            {
                                IntervalInMilliSeconds = 300,
                                Multiplier = 10,
                            },
                        },
                    },
                    new VpnConfigurationProperties(PeeringOption.OptionA)
                    {
                        OptionBProperties = new OptionBProperties()
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
                        OptionAProperties = new VpnConfigurationPropertiesOptionAProperties()
                        {
                            PrimaryIPv4Prefix = "10.0.0.14/30",
                            PrimaryIPv6Prefix = "2FFE:FFFF:0:CD30::a7/127",
                            SecondaryIPv4Prefix = "10.0.0.15/30",
                            SecondaryIPv6Prefix = "2FFE:FFFF:0:CD30::ac/127",
                            Mtu = 1500,
                            VlanId = 3000,
                            PeerASN = 61234,
                            BfdConfiguration = new BfdConfiguration()
                            {
                                IntervalInMilliSeconds = 300,
                                Multiplier = 5,
                            },
                        },
                    }
                ))
            {
                Annotation = "annotation",
                RackCount = 2,
                IPv6Prefix = "3FFE:FFFF:0:CD40::/59",
                Tags =
                {
                    ["keyID"] = "keyValue",
                },
            };
            ArmOperation<NetworkFabricResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, TestEnvironment.NetworkFabricName, data);
            #endregion

            //To-Do
/*            #region NetworkFabric Update
            NetworkFabricPatch patch = new NetworkFabricPatch()
            {
                Annotation = "annotation1",
                RackCount = 2,
                ServerCountPerRack = 8,
                IPv4Prefix = "10.18.0.0/17",
                IPv6Prefix = "3FFE:FFFF:0:CD40::/60",
                FabricASN = 12345,
                TerminalServerConfiguration = new NetworkFabricPatchablePropertiesTerminalServerConfiguration()
                {
                    PrimaryIPv4Prefix = "10.0.0.12/30",
                    PrimaryIPv6Prefix = "4FFE:FFFF:0:CD30::a8/127",
                    SecondaryIPv4Prefix = "40.0.0.14/30",
                    SecondaryIPv6Prefix = "6FFE:FFFF:0:CD30::ac/127",
                    Username = "username1",
                    Password = "xxxxxxxx",
                    SerialNumber = "1234567",
                },
                ManagementNetworkConfiguration = new ManagementNetworkConfigurationPatchableProperties()
                {
                    InfrastructureVpnConfiguration = new VpnConfigurationPatchableProperties()
                    {
                        //NetworkToNetworkInterconnectId = null,//new ResourceIdentifier("/subscriptions/1234ABCD-0A1B-1234-5678-123456ABCDEF/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/networkFabrics/example-fabric/networkToNetworkInterconnects/example-nni"),
                        PeeringOption = PeeringOption.OptionB,
                        OptionBProperties = new OptionBProperties()
                        {
                            RouteTargets = new RouteTargetInformation()
                            {
                                ImportIPv4RouteTargets =
                                {
                                    "65046:10050"
                                },
                                ImportIPv6RouteTargets =
                                {
                                    "65046:10050"
                                },
                                ExportIPv4RouteTargets =
                                {
                                    "65046:10050"
                                },
                                ExportIPv6RouteTargets =
                                {
                                    "65046:10050"
                                },
                            },
                        },
                        OptionAProperties = new VpnConfigurationPatchablePropertiesOptionAProperties()
                        {
                            PrimaryIPv4Prefix = "10.0.0.12/30",
                            PrimaryIPv6Prefix = "4FFE:FFFF:0:CD30::a8/127",
                            SecondaryIPv4Prefix = "20.0.0.13/30",
                            SecondaryIPv6Prefix = "6FFE:FFFF:0:CD30::ac/127",
                            Mtu = 1501,
                            VlanId = 3001,
                            PeerASN = 1235,
                            BfdConfiguration = new BfdConfiguration()
                            {
                                IntervalInMilliSeconds = 300,
                                Multiplier = 10,
                            },
                        },
                    },
                    WorkloadVpnConfiguration = new VpnConfigurationPatchableProperties()
                    {
                        //NetworkToNetworkInterconnectId = null,//new ResourceIdentifier("/subscriptions/1234ABCD-0A1B-1234-5678-123456ABCDEF/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/networkFabrics/example-fabric/networkToNetworkInterconnects/example-nni"),
                        PeeringOption = PeeringOption.OptionA,
                        OptionBProperties = new OptionBProperties()
                        {
                            RouteTargets = new RouteTargetInformation()
                            {
                                ImportIPv4RouteTargets =
                                {
                                    "65046:10051"
                                },
                                ImportIPv6RouteTargets =
                                {
                                    "65046:10051"
                                },
                                ExportIPv4RouteTargets =
                                {
                                    "65046:10051"
                                },
                                ExportIPv6RouteTargets =
                                {
                                    "65046:10051"
                                },
                            },
                        },
                        OptionAProperties = new VpnConfigurationPatchablePropertiesOptionAProperties()
                        {
                            PrimaryIPv4Prefix = "10.0.0.14/30",
                            PrimaryIPv6Prefix = "2FFE:FFFF:0:CD30::a7/126",
                            SecondaryIPv4Prefix = "10.0.0.15/30",
                            SecondaryIPv6Prefix = "2FFE:FFFF:0:CD30::ac/126",
                            Mtu = 1500,
                            VlanId = 3000,
                            PeerASN = 61234,
                            BfdConfiguration = new BfdConfiguration()
                            {
                                IntervalInMilliSeconds = 300,
                                Multiplier = 5,
                            },
                        },
                    },
                },
                Tags =
                {
                    ["keyID"] = "KeyValue",
                },
            };
            ArmOperation<NetworkFabricResource> patchlro = await networkFabric.UpdateAsync(WaitUntil.Completed, patch);
            NetworkFabricResource result = patchlro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            NetworkFabricData resourceData = result.Data;
            #endregion*/

            //NetworkFabricResource networkFabricForPostAction = Client.GetNetworkFabricResource(networkFabricResourceIdForPostAction);*/

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            NetworkFabricResource getResult = await networkFabric.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, TestEnvironment.NetworkFabricName);

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<NetworkFabricResource>();
            await foreach (NetworkFabricResource item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

/*            TestContext.Out.WriteLine($"GET - List by Subscription started.....");
            var listBySubscription = new List<NetworkFabricResource>();
            await foreach (NetworkFabricResource item in DefaultSubscription.GetNetworkFabricsAsync())
            {
                listBySubscription.Add(item);
            }
            Assert.IsNotEmpty(listBySubscription);*/

            // provision
            TestContext.Out.WriteLine($"POST - Provision started.....");
            ArmOperation<CommonPostActionResponseForDeviceUpdate> triggerProvision = await networkFabric.ProvisionAsync(WaitUntil.Completed);
            CommonPostActionResponseForDeviceUpdate triggerProvisionResult = triggerProvision.Value;
            Console.WriteLine(triggerProvisionResult);

            // Deprovision
            TestContext.Out.WriteLine($"POST - Deprovision started.....");
            ArmOperation<CommonPostActionResponseForDeviceUpdate> deProvisionResponse = await networkFabric.DeprovisionAsync(WaitUntil.Completed);
            Console.WriteLine(triggerProvisionResult);

            // Delete
            TestContext.Out.WriteLine($"DELETE started.....");
            ArmOperation deleteResponse = await networkFabric.DeleteAsync(WaitUntil.Completed);
        }
    }
}
