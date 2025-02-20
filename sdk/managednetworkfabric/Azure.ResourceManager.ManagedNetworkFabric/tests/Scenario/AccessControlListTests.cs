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
    public class AccessControlListTests : ManagedNetworkFabricManagementTestBase
    {
        public AccessControlListTests(bool isAsync, RecordedTestMode mode) : base(isAsync, mode) { }
        public AccessControlListTests(bool isAsync) : base(isAsync) { }

        [Test]
        [RecordedTest]
        [AsyncOnly]
        public async Task AccessControlList()
        {
            TestContext.Out.WriteLine($"Entered into the AccessControlList tests....");
            TestContext.Out.WriteLine($"Provided TestEnvironment.AccessControlListName name : {TestEnvironment.AccessControlListName}");
            ResourceIdentifier accessControlListResourceId = NetworkFabricAccessControlListResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId, TestEnvironment.ResourceGroupName, TestEnvironment.AccessControlListName);
            TestContext.Out.WriteLine($"accessControlListResourceId: {accessControlListResourceId}");
            TestContext.Out.WriteLine($"AccessControlList Test started.....");
            NetworkFabricAccessControlListCollection collection = ResourceGroupResource.GetNetworkFabricAccessControlLists();

            // Create
            TestContext.Out.WriteLine($"PUT started.....");
            NetworkFabricAccessControlListData data = new NetworkFabricAccessControlListData(new AzureLocation("eastUs"))
            {
                Annotation = "annotation",
                ConfigurationType = NetworkFabricConfigurationType.File,
                AclsUri = new Uri("https://ACL-Storage-URL"),
                DefaultAction = CommunityActionType.Permit,
                MatchConfigurations =
                    {
                        new AccessControlListMatchConfiguration()
                        {
                            MatchConfigurationName = "example-match",
                            SequenceNumber = 123,
                            IPAddressType = NetworkFabricIPAddressType.IPv4,
                            MatchConditions =
                            {
                                new AccessControlListMatchCondition()
                                {
                                    EtherTypes =
                                        {
                                        "0x1"
                                        },
                                    Fragments =
                                        {
                                        "0xff00-0xffff"
                                        },
                                    IPLengths =
                                        {
                                        "4094-9214"
                                        },
                                    TtlValues =
                                        {
                                        "23"
                                        },
                                    DscpMarkings =
                                        {
                                        "32"
                                        },
                                    PortCondition = new AccessControlListPortCondition(Layer4Protocol.Tcp)
                                    {
                                        Flags =
                                            {
                                            "established"
                                            },
                                        PortType = NetworkFabricPortType.SourcePort,
                                        Ports =
                                            {
                                            "1-20"
                                            },
                                        PortGroupNames =
                                            {
                                            "example-portGroup"
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
                                            "20-30"
                                            },
                                        InnerVlans =
                                            {
                                            "30"
                                            },
                                        VlanGroupNames =
                                            {
                                            "example-vlanGroup"
                                            },
                                    },
                                    IPCondition = new IPMatchCondition()
                                    {
                                        SourceDestinationType = SourceDestinationType.SourceIP,
                                        PrefixType = IPMatchConditionPrefixType.Prefix,
                                        IPPrefixValues =
                                            {
                                            "10.20.20.20/12"
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
                                new AccessControlListAction()
                                {
                                    AclActionType = AclActionType.Count,
                                    CounterName = "example-counter",
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
                                    Name = "example-ipGroup",
                                    IPAddressType = NetworkFabricIPAddressType.IPv4,
                                    IPPrefixes =
                                        {
                                        "10.20.3.1/20"
                                        },
                                }
                            },
                            VlanGroups =
                            {
                                new VlanGroupProperties()
                                {
                                    Name = "example-vlanGroup",
                                    Vlans =
                                        {
                                        "20-30"
                                        },
                                }
                            },
                            PortGroups =
                            {
                                new PortGroupProperties()
                                {
                                    Name = "example-portGroup",
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
                        ["keyID"] = "KeyValue",
                    },
            };
            ArmOperation<NetworkFabricAccessControlListResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, TestEnvironment.AccessControlListName, data);
            NetworkFabricAccessControlListResource createResult = lro.Value;
            Assert.AreEqual(createResult.Data.Name, TestEnvironment.AccessControlListName);

            NetworkFabricAccessControlListResource accessControlList = Client.GetNetworkFabricAccessControlListResource(accessControlListResourceId);

            // Get
            TestContext.Out.WriteLine($"GET started.....");
            NetworkFabricAccessControlListResource getResult = await accessControlList.GetAsync();
            TestContext.Out.WriteLine($"{getResult}");
            Assert.AreEqual(getResult.Data.Name, TestEnvironment.AccessControlListName);

            // Patch not supported now. Will enable it once supported.
            /*
            NetworkFabricAccessControlListPatch patch = new NetworkFabricAccessControlListPatch()
            {
                ConfigurationType = NetworkFabricConfigurationType.File,
                AclsUri = new Uri("https://microsoft.com/a"),
                DefaultAction = CommunityActionType.Permit,
                MatchConfigurations =
                    {
                    new AccessControlListMatchConfiguration()
                    {
                        MatchConfigurationName = "example-match",
                        SequenceNumber = 123,
                        IPAddressType = NetworkFabricIPAddressType.IPv4,
                        MatchConditions =
                        {
                            new AccessControlListMatchCondition()
                            {
                            EtherTypes =
                                {
                                "0x1"
                                },
                            Fragments =
                                {
                                "0xff00-0xffff"
                                },
                            IPLengths =
                                {
                                "4094-9214"
                                },
                            TtlValues =
                                {
                                "23"
                                },
                            DscpMarkings =
                                {
                                "32"
                                },
                            PortCondition = new AccessControlListPortCondition(Layer4Protocol.Tcp)
                            {
                                Flags =
                                    {
                                    "established"
                                    },
                                PortType = NetworkFabricPortType.SourcePort,
                                Ports =
                                    {
                                    "1-20"
                                    },
                                PortGroupNames =
                                    {
                                    "example-portGroup"
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
                                    "20-30"
                                    },
                                InnerVlans =
                                    {
                                    "30"
                                    },
                                VlanGroupNames =
                                    {
                                    "example-vlanGroup"
                                    },
                            },
                            IPCondition = new IPMatchCondition()
                            {
                                SourceDestinationType = SourceDestinationType.SourceIP,
                                PrefixType = IPMatchConditionPrefixType.Prefix,
                                IPPrefixValues =
                                    {
                                    "10.20.20.20/12"
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
                            new AccessControlListAction()
                                {
                                    AclActionType = AclActionType.Count,
                                    CounterName = "example-counter",
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
                                    Name = "example-ipGroup",
                                    IPAddressType = NetworkFabricIPAddressType.IPv4,
                                    IPPrefixes =
                                        {
                                        "10.20.3.1/20"
                                        },
                                }
                            },
                            VlanGroups =
                            {
                                new VlanGroupProperties()
                                {
                                    Name = "example-vlanGroup",
                                    Vlans =
                                        {
                                        "20-30"
                                        },
                                }
                            },
                            PortGroups =
                            {
                                new PortGroupProperties()
                                {
                                    Name = "example-portGroup",
                                    Ports =
                                        {
                                        "100-200"
                                        },
                                }
                            },
                        }
                    },
                Annotation = "annotation",
                Tags =
                        {
                         ["keyID2"] = "KeyValue",
                        },
            };
            ArmOperation<NetworkFabricAccessControlListResource> lroPatch = await accessControlList.UpdateAsync(WaitUntil.Completed, patch);
            NetworkFabricAccessControlListResource result = lroPatch.Value;
            NetworkFabricAccessControlListData resourcePatchData = result.Data;
            Assert.IsTrue(resourcePatchData.Tags.Keys.Contains("keyID2"));
            */

            // List
            TestContext.Out.WriteLine($"GET - List by Resource Group started.....");
            var listByResourceGroup = new List<NetworkFabricAccessControlListResource>();
            await foreach (NetworkFabricAccessControlListResource item in collection.GetAllAsync())
            {
                listByResourceGroup.Add(item);
            }
            Assert.IsNotEmpty(listByResourceGroup);

            //List by subscription
            ResourceIdentifier subscriptionResourceId = SubscriptionResource.CreateResourceIdentifier(TestEnvironment.SubscriptionId);
            SubscriptionResource subscriptionResource = Client.GetSubscriptionResource(subscriptionResourceId);
            TestContext.Out.WriteLine($"GET - List by Subscription started.....");
            await foreach (NetworkFabricAccessControlListResource item in subscriptionResource.GetNetworkFabricAccessControlListsAsync())
            {
                NetworkFabricAccessControlListData resourceData = item.Data;
                TestContext.WriteLine($"Succeeded on id: {resourceData.Id}");
            }
            TestContext.Out.WriteLine($"List by Subscription operation succeeded.");

            // Delete
            TestContext.Out.WriteLine($"DELETE started.....");
            var deleteResponse = await accessControlList.DeleteAsync(WaitUntil.Completed);
            Assert.IsTrue(deleteResponse.HasCompleted);
        }
    }
}
