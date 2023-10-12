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
    public class NetworkTapRuleTests : ManagedNetworkFabricManagementTestBase
    {
        public NetworkTapRuleTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }
        public NetworkTapRuleTests(bool isAsync) : base(isAsync) { }

        [Test]
        [RecordedTest]
        [AsyncOnly]
        public async Task NetworkTapRule()
        {
            TestContext.Out.WriteLine($"Entered into the NetworkTapRule tests....");
            TestContext.Out.WriteLine($"Provided TestEnvironment.NetworkTapRuleName name : {TestEnvironment.NetworkTapRuleName}");
            ResourceIdentifier networkTapRuleResourceId = NetworkTapRuleResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroupName, TestEnvironment.NetworkTapRuleName);
            TestContext.Out.WriteLine($"networkTapRuleResourceId: {networkTapRuleResourceId}");
            TestContext.Out.WriteLine($"NetworkTapRule Test started.....");
            NetworkTapRuleCollection collection = ResourceGroupResource.GetNetworkTapRules();

            // Create
            TestContext.Out.WriteLine($"PUT started.....");
            NetworkTapRuleData data = new NetworkTapRuleData(new AzureLocation("eastus"))
            {
                Annotation = "annotation",
                ConfigurationType = NetworkFabricConfigurationType.File,
                TapRulesUri = new Uri("https://microsoft.com/a"),
                MatchConfigurations =
                    {
                        new NetworkTapRuleMatchConfiguration()
                        {
                             MatchConfigurationName = "config1",
                            SequenceNumber = 10,
                            IPAddressType = NetworkFabricIPAddressType.IPv4,
                            MatchConditions =
                            {
                                new NetworkTapRuleMatchCondition()
                                {
                                    EncapsulationType = NetworkTapEncapsulationType.None,
                                    PortCondition = new NetworkFabricPortCondition(Layer4Protocol.Tcp)
                                    {
                                        PortType = NetworkFabricPortType.SourcePort,
                                        Ports =
                                            {
                                            "100"
                                            },
                                        PortGroupNames =
                                            {
                                            "example-portGroup1"
                                            },
                                    },
                                    ProtocolTypes =
                                        {
                                        "TCP"
                                        },
                                    VlanMatchCondition = new VlanMatchCondition()
                                    {
                                        Vlans =
                                            {
                                            "10"
                                            },
                                        InnerVlans =
                                            {
                                            "11-20"
                                            },
                                        VlanGroupNames =
                                            {
                                            "exmaple-vlanGroup"
                                            },
                                    },
                                    IPCondition = new IPMatchCondition()
                                    {
                                        SourceDestinationType = SourceDestinationType.SourceIP,
                                        PrefixType = IPMatchConditionPrefixType.Prefix,
                                        IPPrefixValues =
                                            {
                                            "10.10.10.10/20"
                                            },
                                        IPGroupNames =
                                            {
                                            "example-ipGroup"
                                            },
                                    },
                                }
                            },
                            Actions =
                            {
                                new NetworkTapRuleAction()
                                {
                                    TapRuleActionType = TapRuleActionType.Drop,
                                    Truncate = "100",
                                    IsTimestampEnabled = NetworkFabricBooleanValue.True,
                                    DestinationId = new ResourceIdentifier("/subscriptions/1234ABCD-0A1B-1234-5678-123456ABCDEF/resourcegroups/example-rg/providers/Microsoft.ManagedNetworkFabric/neighborGroups/example-neighborGroup"),
                                    MatchConfigurationName = "match1",
                                }
                            },
                        }
                    },
                DynamicMatchConfigurations =
                    {
                        new CommonDynamicMatchConfiguration()
                        {
                            IPGroups =
                            {
                                new MatchConfigurationIPGroupProperties()
                                {
                                    Name = "example-ipGroup1",
                                    IPAddressType = NetworkFabricIPAddressType.IPv4,
                                    IPPrefixes =
                                        {
                                        "10.10.10.10/30"
                                        },
                                }
                            },
                            VlanGroups =
                            {
                                new VlanGroupProperties()
                                {
                                    Name = "exmaple-vlanGroup",
                                    Vlans =
                                        {
                                        "10","100-200"
                                        },
                                }
                            },
                            PortGroups =
                            {
                                new PortGroupProperties()
                                {
                                    Name = "example-portGroup1",
                                    Ports =
                                        {
                                        "100-200"
                                        },
                                },
                                new PortGroupProperties()
                                {
                                    Name = "example-portGroup2",
                                    Ports =
                                        {
                                        "900","1000-2000"
                                        },
                                }
                            },
                        }
                    },
                PollingIntervalInSeconds = PollingIntervalInSecond.Thirty,
                Tags =
                    {
                        ["keyID"] = "keyValue",
                    },
            };
            TestContext.Out.WriteLine($" ########################################");
            ArmOperation<NetworkTapRuleResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, TestEnvironment.NetworkTapRuleName, data);
            TestContext.Out.WriteLine($" ########################################");
            NetworkTapRuleResource createResult = lro.Value;
            Assert.AreEqual(createResult.Data.Name, TestEnvironment.NetworkTapRuleName);

            // Update
            // Patch not supported now. Will enable it once supported.
            /*
            NetworkTapRulePatch patch = new NetworkTapRulePatch()
            {
                Annotation = "annotation",
                ConfigurationType = NetworkFabricConfigurationType.File,
                TapRulesUri = new Uri("https://microsoft.com/amdsdx"),
                MatchConfigurations =
                {
                    new NetworkTapRuleMatchConfiguration()
                    {
                        MatchConfigurationName = "ModifiedConfigName",
                        SequenceNumber = 10,
                        IPAddressType = NetworkFabricIPAddressType.IPv4,
                        MatchConditions =
                        {
                            new NetworkTapRuleMatchCondition()
                            {
                                EncapsulationType = NetworkTapEncapsulationType.None,
                                PortCondition = new NetworkFabricPortCondition(Layer4Protocol.Tcp)
                                {
                                    PortType = NetworkFabricPortType.SourcePort,
                                    Ports =
                                        {
                                        "100"
                                        },
                                    PortGroupNames =
                                        {
                                        "example-portGroup1"
                                        },
                                },
                                ProtocolTypes =
                                    {
                                    "TCP"
                                    },
                                VlanMatchCondition = new VlanMatchCondition()
                                {
                                    Vlans =
                                        {
                                        "10"
                                        },
                                    InnerVlans =
                                        {
                                        "11-20"
                                        },
                                    VlanGroupNames =
                                        {
                                        "exmaple-vlanGroup"
                                        },
                                },
                                IPCondition = new IPMatchCondition()
                                {
                                    SourceDestinationType = SourceDestinationType.SourceIP,
                                    PrefixType = IPMatchConditionPrefixType.Prefix,
                                    IPPrefixValues =
                                        {
                                        "10.10.10.10/20"
                                        },
                                    IPGroupNames =
                                        {
                                        "example-ipGroup"
                                        },
                                },
                            }
                        },
                        Actions =
                        {
                            new NetworkTapRuleAction()
                            {
                                TapRuleActionType = TapRuleActionType.Goto,
                                Truncate = "100",
                                IsTimestampEnabled = NetworkFabricBooleanValue.True,
                                DestinationId = new ResourceIdentifier("/subscriptions/1234ABCD-0A1B-1234-5678-123456ABCDEF/resourcegroups/example-rg/providers/Microsoft.ManagedNetworkFabric/neighborGroups/example-neighborGroup"),
                                MatchConfigurationName = "match1",
                            }
                        },
                    }
                },
                DynamicMatchConfigurations =
                {
                    new CommonDynamicMatchConfiguration()
                    {
                        IPGroups =
                        {
                            new MatchConfigurationIPGroupProperties()
                            {
                                Name = "example-ipGroup1",
                                IPAddressType = NetworkFabricIPAddressType.IPv4,
                                IPPrefixes =
                                    {
                                    "10.10.10.10/30"
                                    },
                        }
                    },
                    VlanGroups =
                    {
                        new VlanGroupProperties()
                        {
                            Name = "exmaple-vlanGroup",
                            Vlans =
                                {
                                "10","100-200"
                                },
                        }
                    },
                    PortGroups =
                    {
                        new PortGroupProperties()
                            {
                                Name = "example-portGroup1",
                                Ports =
                                    {
                                    "100-200"
                                    },
                            }
                        },
                    }
                },
                Tags =
                {
                ["keyID"] = "keyValue",
                },
            };
            NetworkTapRuleResource networkTapRule = Client.GetNetworkTapRuleResource(createResult.Data.Id);
            TestContext.Out.WriteLine($"PATCH - test started.");
            ArmOperation<NetworkTapRuleResource> lroPatch = await networkTapRule.UpdateAsync(WaitUntil.Completed, patch);
            NetworkTapRuleResource result = lroPatch.Value;
            NetworkTapRuleData resourceData = result.Data;
            Assert.AreEqual(resourceData.MatchConfigurations[0].MatchConfigurationName, "ModifiedConfigName");
            TestContext.Out.WriteLine($"PATCH - test completed.");
            */

            NetworkTapRuleResource ntpResource = Client.GetNetworkTapRuleResource(networkTapRuleResourceId);
            // Get
            TestContext.Out.WriteLine($"GET started.....");
            NetworkTapRuleResource getResult = await ntpResource.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, TestEnvironment.NetworkTapRuleName);

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<NetworkTapRuleResource>();
            await foreach (NetworkTapRuleResource item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            //List by subscription
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId);
            SubscriptionResource subscriptionResource = Client.GetSubscriptionResource(subscriptionResourceId);
            TestContext.Out.WriteLine($"GET - List by Subscription started.....");
            await foreach (NetworkTapRuleResource item in subscriptionResource.GetNetworkTapRulesAsync())
            {
                NetworkTapRuleData rData = item.Data;
                TestContext.WriteLine($"Succeeded on id: {rData.Id}");
            }
            TestContext.Out.WriteLine($"List by Subscription operation succeeded.");

            // Delete
            TestContext.Out.WriteLine($"DELETE started.....");
            var deleteResponse = await ntpResource.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResponse.HasCompleted);
        }
    }
}
