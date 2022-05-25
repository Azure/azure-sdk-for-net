using System.Net;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Net.Http;
using System;
using Microsoft.Rest;

namespace Networks.Tests
{
    public class NetworkManagerEffectiveConfigurationTests
    {
        public NetworkManagementClient GetResourceManagementClient(RecordedDelegatingHandler handler)
        {
            var subscriptionId = Guid.NewGuid().ToString();
            var token = new TokenCredentials(subscriptionId, "abc123");
            handler.IsPassThrough = false;
            var client = new NetworkManagementClient(token, handler);
            client.SubscriptionId = subscriptionId;
            return client;
        }

        //[Fact(Skip = "Disable tests")]
        [Fact]
        public void NetworkManagerEffectiveSecurityAdminConfigurationTest()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'skipToken': 'fake Skip Token',
                    'value': [
                        {
                            'id': '/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/ANMRG3495/providers/Microsoft.Network/networkManagers/ANM5741/securityAdminConfigurations/ANMSAC8168/ruleCollections/ANMSARC3926/rules/ANMAdminRule6932',
                            'configurationDescription': 'Sample Config Description',
                            'ruleCollectionDescription': 'Sample Collection Description',
                            'kind': 'Custom',
                            'properties': {
                                'displayName': '',
                                'description': '',
                                'priority': 100,
                                'protocol': 'Tcp',
                                'direction': 'Inbound',
                                'access': 'Allow',
                                'sources': [],
                                'destinations': [],
                                'sourcePortRanges': [],
                                'destinationPortRanges': [],
                                'provisioningState': 'Succeeded',
                                'resourceGuid': 'a44368d5-f99f-4f32-b82c-3888a106b6db'
                            },
                            'ruleCollectionAppliesToGroups': [
                                {
                                    'networkGroupId': '/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/ANMRG3495/providers/Microsoft.Network/networkManagers/ANM5741/networkGroups/ANMNG631'
                                }
                            ],
                            'ruleGroups': [
                                {
                                    'id': '/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/ANMRG3495/providers/Microsoft.Network/networkManagers/ANM5741/networkGroups/ANMNG631',
                                    'properties': {
                                        'displayName': '',
                                        'description': '',
                                        'memberType': 'Microsoft.Network/virtualNetworks',
                                        'provisioningState': 'Succeeded'
                                    }
                                }
                            ]
                        },
                        {
                            'id': '/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/ANMRG3495/providers/Microsoft.Network/networkManagers/ANM5741/securityAdminConfigurations/ANMSAC8168/ruleCollections/ANMSARC3926/rules/ANMAdminRule6932',
                            'configurationDescription': 'Sample Config Description',
                            'ruleCollectionDescription': 'Sample Collection Description',
                            'kind': 'Default',
                            'properties': {
                                'displayName': '',
                                'description': '',
                                'priority': 10,
                                'protocol': 'Tcp',
                                'flag': 'Internet',
                                'direction': 'Outbound',
                                'access': 'Allow',
                                'sources': [],
                                'destinations': [],
                                'sourcePortRanges': [],
                                'destinationPortRanges': [],
                                'provisioningState': 'Succeeded',
                                'resourceGuid': 'a44368d5-f99f-4f32-b82c-3888a106b6db'
                            },
                            'ruleCollectionAppliesToGroups': [
                                {
                                    'networkGroupId': '/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/ANMRG3495/providers/Microsoft.Network/networkManagers/ANM5741/networkGroups/ANMNG631'
                                }
                            ],
                            'ruleGroups': [
                                {
                                    'id': '/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/ANMRG3495/providers/Microsoft.Network/networkManagers/ANM5741/networkGroups/ANMNG631',
                                    'properties': {
                                        'displayName': '',
                                        'description': '',
                                        'memberType': 'Microsoft.Network/virtualNetworks',
                                        'provisioningState': 'Succeeded'
                                    }
                                }
                            ]
                        }
                    ]
                }")
            };

            string resourceGroupName = "ANMRG3495";
            string vnetName = "testVnet";
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var networkManagementClient = GetResourceManagementClient(handler);

            var parameter = new QueryRequestOptions();
            var effectiveResponse = networkManagementClient.ListNetworkManagerEffectiveSecurityAdminRules(parameter, resourceGroupName, vnetName);

            Assert.Equal(2, effectiveResponse.Value.Count);
            Assert.Equal("fake Skip Token", effectiveResponse.SkipToken);
            EffectiveSecurityAdminRule effectiveSecurityCustomAdminRule = (EffectiveSecurityAdminRule)effectiveResponse.Value[0];
            Assert.Equal("Sample Config Description", effectiveSecurityCustomAdminRule.ConfigurationDescription);
            Assert.Equal("Sample Collection Description", effectiveSecurityCustomAdminRule.RuleCollectionDescription);
            Assert.Equal(1, effectiveSecurityCustomAdminRule.RuleCollectionAppliesToGroups.Count);
            Assert.Equal("/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/ANMRG3495/providers/Microsoft.Network/networkManagers/ANM5741/networkGroups/ANMNG631",
                        effectiveSecurityCustomAdminRule.RuleCollectionAppliesToGroups[0].NetworkGroupId);
            Assert.Equal(1, effectiveSecurityCustomAdminRule.RuleGroups.Count);
            Assert.Equal("/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/ANMRG3495/providers/Microsoft.Network/networkManagers/ANM5741/networkGroups/ANMNG631",
                        effectiveSecurityCustomAdminRule.RuleGroups[0].Id);

            Assert.Equal("Tcp", effectiveSecurityCustomAdminRule.Protocol);
            Assert.Equal(100, effectiveSecurityCustomAdminRule.Priority);
            Assert.Equal("Inbound", effectiveSecurityCustomAdminRule.Direction);

            EffectiveDefaultSecurityAdminRule effectiveSecurityDefaultAdminRule = (EffectiveDefaultSecurityAdminRule)effectiveResponse.Value[1];
            Assert.Equal("Sample Config Description", effectiveSecurityDefaultAdminRule.ConfigurationDescription);
            Assert.Equal("Sample Collection Description", effectiveSecurityDefaultAdminRule.RuleCollectionDescription);
            Assert.Equal(1, effectiveSecurityDefaultAdminRule.RuleCollectionAppliesToGroups.Count);
            Assert.Equal("/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/ANMRG3495/providers/Microsoft.Network/networkManagers/ANM5741/networkGroups/ANMNG631",
                        effectiveSecurityDefaultAdminRule.RuleCollectionAppliesToGroups[0].NetworkGroupId);
            Assert.Equal(1, effectiveSecurityDefaultAdminRule.RuleGroups.Count);
            Assert.Equal("/subscriptions/08615b4b-bc9c-4a70-be1b-2ea10bc97b52/resourceGroups/ANMRG3495/providers/Microsoft.Network/networkManagers/ANM5741/networkGroups/ANMNG631",
                        effectiveSecurityDefaultAdminRule.RuleGroups[0].Id);

            Assert.Equal("Internet", effectiveSecurityDefaultAdminRule.Flag);
            Assert.Equal("Tcp", effectiveSecurityDefaultAdminRule.Protocol);
            Assert.Equal(10, effectiveSecurityDefaultAdminRule.Priority);
            Assert.Equal("Outbound", effectiveSecurityDefaultAdminRule.Direction);
        }

        //[Fact(Skip = "Disable tests")]
        [Fact]
        public void NetworkManagerEffectiveConnectivityConfigurationTest()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'value': [
                          {
                            'id': 'subscriptions/subscriptionA/resourceGroups/myResourceGroup/providers/Microsoft.Network/networkManagers/testNetworkManager/connectivityConfigurations/myTestConnectivityConfig',
                            'properties': {
                              'displayName': 'myTestConnectivityConfig',
                              'description': 'Sample Configuration',
                              'connectivityTopology': 'HubAndSpoke',
                              'hubs': [
                                {
                                    'resourceId':'/subscriptionB/resourceGroups/myResourceGroup/providers/Microsoft.Network/virtualNetworks/myHubVnet',
                                    'resourceType': 'Microsoft.Network/virtualNetworks'     
                                }
                              ],
                              'isGlobal': 'True',
                              'deleteExistingPeering': 'True',
                              'appliesToGroups': [
                                {
                                  'networkGroupId': '/subscriptions/subscriptionA/resourceGroup/myResourceGroup/providers/Microsoft.Network/networkManagers/testNetworkManager/networkGroups/group1',
                                  'useHubGateway': 'True',
                                  'groupConnectivity': 'None',
                                  'isGlobal': 'False'
                                }
                              ],
                              'provisioningState': 'Succeeded'
                            },
                            'configurationGroups': [
                              {
                                'id': '/subscriptions/subscriptionA/resourceGroup/myResourceGroup/providers/Microsoft.Network/networkManagers/testNetworkManager/networkGroups/group1',
                                'properties': {
                                  'displayName': 'My Network Group',
                                  'description': 'A group for all test Virtual Networks',
                                  'memberType': 'Microsoft.Network/virtualNetworks',
                                  'provisioningState': 'Succeeded'
                                }
                              }
                            ]
                         }
                     ],
                    'skipToken': 'FakeSkipTokenCode'
                }")
            };

            string resourceGroupName = "ANMRG3495";
            string vnetName = "testVnet";
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var networkManagementClient = GetResourceManagementClient(handler);

            var parameter = new QueryRequestOptions();
            var effectiveResponse = networkManagementClient.ListNetworkManagerEffectiveConnectivityConfigurations(parameter, resourceGroupName, vnetName);

            Assert.Equal(1, effectiveResponse.Value.Count);
            Assert.Equal("FakeSkipTokenCode", effectiveResponse.SkipToken);
            EffectiveConnectivityConfiguration effectiveConnectivityConfig = effectiveResponse.Value[0];
            Assert.Equal("HubAndSpoke", effectiveConnectivityConfig.ConnectivityTopology);
            Assert.Equal(1, effectiveConnectivityConfig.Hubs.Count);
            Assert.Equal("/subscriptionB/resourceGroups/myResourceGroup/providers/Microsoft.Network/virtualNetworks/myHubVnet", effectiveConnectivityConfig.Hubs[0].ResourceId);
            Assert.Equal("Microsoft.Network/virtualNetworks", effectiveConnectivityConfig.Hubs[0].ResourceType);
            Assert.Equal(1, effectiveConnectivityConfig.ConfigurationGroups.Count);
            Assert.Equal(
                "/subscriptions/subscriptionA/resourceGroup/myResourceGroup/providers/Microsoft.Network/networkManagers/testNetworkManager/networkGroups/group1",
                effectiveConnectivityConfig.ConfigurationGroups[0].Id);
            Assert.Equal(1, effectiveConnectivityConfig.AppliesToGroups.Count);
            Assert.Equal(
                "/subscriptions/subscriptionA/resourceGroup/myResourceGroup/providers/Microsoft.Network/networkManagers/testNetworkManager/networkGroups/group1",
                effectiveConnectivityConfig.AppliesToGroups[0].NetworkGroupId);
        }
    }
}