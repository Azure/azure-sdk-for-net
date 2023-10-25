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

            TestContext.Out.WriteLine($"Entered into the Network Fabric tests....");

            TestContext.Out.WriteLine($"Provided NetworkFabricControllerId : {TestEnvironment.Provisioned_NFC_ID}");
            TestContext.Out.WriteLine($"Provided NetworkFabric name : {TestEnvironment.NetworkFabricName}");

            ResourceIdentifier networkFabricResourceId = NetworkFabricResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroupName, TestEnvironment.NetworkFabricName);
            TestContext.Out.WriteLine($"networkFabricId: {networkFabricResourceId}");
            NetworkFabricResource networkFabric = Client.GetNetworkFabricResource(networkFabricResourceId);

            TestContext.Out.WriteLine($"Test started.....");

            #region Network Fabric create
            TestContext.Out.WriteLine($"PUT started.....");
            NetworkFabricData data = new NetworkFabricData(
                new AzureLocation(TestEnvironment.Location),
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
                        OptionAProperties = new VpnConfigurationOptionAProperties()
                        {
                            PrimaryIPv4Prefix = "10.0.0.12/30",
                            PrimaryIPv6Prefix = "4FFE:FFFF:0:CD30::a8/127",
                            SecondaryIPv4Prefix = "20.0.0.13/30",
                            SecondaryIPv6Prefix = "6FFE:FFFF:0:CD30::ac/127",
                            Mtu = 1501,
                            VlanId = 3001,
                            PeerAsn = 1235,
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
                        OptionAProperties = new VpnConfigurationOptionAProperties()
                        {
                            PrimaryIPv4Prefix = "10.0.0.14/30",
                            PrimaryIPv6Prefix = "2FFE:FFFF:0:CD30::a7/127",
                            SecondaryIPv4Prefix = "10.0.0.15/30",
                            SecondaryIPv6Prefix = "2FFE:FFFF:0:CD30::ac/127",
                            Mtu = 1500,
                            VlanId = 3000,
                            PeerAsn = 61234,
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

            //List by subscription
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId);
            SubscriptionResource subscriptionResource = Client.GetSubscriptionResource(subscriptionResourceId);

            TestContext.Out.WriteLine($"GET - List by Subscription started.....");

            await foreach (NetworkFabricResource item in subscriptionResource.GetNetworkFabricsAsync())
            {
                NetworkFabricData resourceData = item.Data;
                TestContext.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            TestContext.Out.WriteLine($"List by Subscription operation succeeded.");

            ResourceIdentifier networkFabricResourceId2 = NetworkFabricResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroupName, TestEnvironment.ExistingNetworkFabricName);
            TestContext.Out.WriteLine($"networkFabricId: {networkFabricResourceId2}");
            NetworkFabricResource networkFabric2 = Client.GetNetworkFabricResource(networkFabricResourceId2);

            // provision
            TestContext.Out.WriteLine($"POST - Provision started.....");
            ArmOperation<DeviceUpdateCommonPostActionResult> triggerProvision = await networkFabric2.ProvisionAsync(WaitUntil.Completed);
            DeviceUpdateCommonPostActionResult triggerProvisionResult = triggerProvision.Value;
            TestContext.Out.WriteLine(triggerProvisionResult);

            // Deprovision
            TestContext.Out.WriteLine($"POST - Deprovision started.....");
            ArmOperation<DeviceUpdateCommonPostActionResult> deProvisionResponse = await networkFabric2.DeprovisionAsync(WaitUntil.Completed);
            TestContext.Out.WriteLine(deProvisionResponse);

            // Delete
            TestContext.Out.WriteLine($"DELETE started.....");
            ArmOperation deleteResponse = await networkFabric.DeleteAsync(WaitUntil.Completed);
        }
    }
}
