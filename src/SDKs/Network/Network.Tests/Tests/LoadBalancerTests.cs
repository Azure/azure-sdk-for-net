// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;

namespace Networks.Tests
{
    using System;
    using System.Linq;

    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    using SubResource = Microsoft.Azure.Management.Network.Models.SubResource;

    public class LoadBalancerTests
    {
        [Fact(Skip="Disable tests")]
        public void LoadBalancerApiTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {               
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);
                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/loadBalancers");

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(
                    resourceGroupName,
                    new ResourceGroup
                        {
                        Location = location
                    });

                // Create lbPublicIP
                string lbPublicIpName = TestUtilities.GenerateName();
                string lbDomaingNameLabel = TestUtilities.GenerateName();

                var lbPublicIp = TestHelper.CreateDefaultPublicIpAddress(
                    lbPublicIpName,
                    resourceGroupName,
                    lbDomaingNameLabel,
                    location,
                    networkManagementClient);

                // Create the LoadBalancer
                var lbName = TestUtilities.GenerateName();
                var frontendIpConfigName = TestUtilities.GenerateName();
                var backEndAddressPoolName = TestUtilities.GenerateName();
                var loadBalancingRuleName = TestUtilities.GenerateName();
                var probeName = TestUtilities.GenerateName();
                var inboundNatRule1Name = TestUtilities.GenerateName();
                var inboundNatRule2Name = TestUtilities.GenerateName();
                var inboundNatRule3Name = TestUtilities.GenerateName();

                // Populate the loadBalancerCreateOrUpdateParameter
                var loadBalancer = new LoadBalancer()
                {
                    Location = location,
                    FrontendIPConfigurations = new List<FrontendIPConfiguration>()
                    {
                        new FrontendIPConfiguration()
                        {
                            Name = frontendIpConfigName,
                            PublicIPAddress = new PublicIPAddress()
                            {
                                Id = lbPublicIp.Id
                            }
                        }
                    },
                    BackendAddressPools = new List<BackendAddressPool>()
                    {
                        new BackendAddressPool()
                        {
                            Name = backEndAddressPoolName,
                        }
                    },
                    LoadBalancingRules = new List<LoadBalancingRule>()
                    {
                        new LoadBalancingRule()
                        {
                            Name = loadBalancingRuleName,
                            FrontendIPConfiguration = new SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 80,
                            BackendPort = 80,
                            EnableFloatingIP = false,
                            IdleTimeoutInMinutes = 15,
                            BackendAddressPool = new SubResource()
                            {
                                Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "backendAddressPools", backEndAddressPoolName)
                            },
                            Probe = new SubResource()
                            {
                                Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId, 
                                resourceGroupName, lbName, "probes", probeName)
                            }
                        }
                    },
                    Probes = new List<Probe>()
                    {
                        new Probe()
                        {
                            Name = probeName,
                            Protocol = ProbeProtocol.Http,
                            Port = 80,
                            RequestPath = "healthcheck.aspx",
                            IntervalInSeconds = 10,
                            NumberOfProbes = 2
                        }
                    },
                    InboundNatRules = new List<InboundNatRule>()
                    {
                        new InboundNatRule()
                        {
                            Name = inboundNatRule1Name,
                            FrontendIPConfiguration = new SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 3389,
                            BackendPort = 3389,
                            IdleTimeoutInMinutes = 15,
                            EnableFloatingIP = false
                        },
                        new InboundNatRule()
                        {
                            Name = inboundNatRule2Name,
                            FrontendIPConfiguration = new SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 3390,
                            BackendPort = 3389,
                            IdleTimeoutInMinutes = 15,
                            EnableFloatingIP = false,
                        }
                    }
                };

                // Create the loadBalancer
                var putLoadBalancer = networkManagementClient.LoadBalancers.CreateOrUpdate(resourceGroupName,lbName, loadBalancer);
                
                var getLoadBalancer = networkManagementClient.LoadBalancers.Get(resourceGroupName, lbName);

                // Verify the GET LoadBalancer
                Assert.Equal(lbName, getLoadBalancer.Name);
                Assert.Equal("Succeeded", getLoadBalancer.ProvisioningState);
                Assert.Equal(frontendIpConfigName, getLoadBalancer.FrontendIPConfigurations[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.FrontendIPConfigurations[0].ProvisioningState);
                Assert.Equal(lbPublicIp.Id, getLoadBalancer.FrontendIPConfigurations[0].PublicIPAddress.Id);
                Assert.Null(getLoadBalancer.FrontendIPConfigurations[0].PrivateIPAddress);
                Assert.Equal(getLoadBalancer.InboundNatRules[0].Id, getLoadBalancer.FrontendIPConfigurations[0].InboundNatRules[0].Id);
                Assert.Equal(getLoadBalancer.InboundNatRules[1].Id, getLoadBalancer.FrontendIPConfigurations[0].InboundNatRules[1].Id);
                Assert.Equal(backEndAddressPoolName, getLoadBalancer.BackendAddressPools[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.BackendAddressPools[0].ProvisioningState);
                Assert.Equal(getLoadBalancer.LoadBalancingRules[0].Id, getLoadBalancer.BackendAddressPools[0].LoadBalancingRules[0].Id);
                Assert.Equal(loadBalancingRuleName, getLoadBalancer.LoadBalancingRules[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancingRules[0].ProvisioningState);
                Assert.Equal(15, getLoadBalancer.LoadBalancingRules[0].IdleTimeoutInMinutes);
                Assert.Equal(probeName, getLoadBalancer.Probes[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.Probes[0].ProvisioningState);
                Assert.Equal(getLoadBalancer.Probes[0].Id, getLoadBalancer.LoadBalancingRules[0].Probe.Id);
                Assert.Equal("Succeeded", getLoadBalancer.InboundNatRules[0].ProvisioningState);
                Assert.Equal(inboundNatRule1Name, getLoadBalancer.InboundNatRules[0].Name);
                Assert.Equal("Tcp", getLoadBalancer.InboundNatRules[0].Protocol);
                Assert.Equal(3389, getLoadBalancer.InboundNatRules[0].FrontendPort);
                Assert.Equal("Succeeded", getLoadBalancer.InboundNatRules[1].ProvisioningState);
                Assert.Equal(3390, getLoadBalancer.InboundNatRules[1].FrontendPort);
                Assert.Equal(15, getLoadBalancer.InboundNatRules[1].IdleTimeoutInMinutes);
                Assert.NotNull(getLoadBalancer.ResourceGuid);
                
                // Verify List LoadBalancer
                var listLoadBalancer = networkManagementClient.LoadBalancers.List(resourceGroupName);
                Assert.Equal(1, listLoadBalancer.Count());
                Assert.Equal(lbName, listLoadBalancer.First().Name);
                Assert.Equal(getLoadBalancer.Etag, listLoadBalancer.First().Etag);

                // Verify List LoadBalancer subscription
                var listLoadBalancerSubscription = networkManagementClient.LoadBalancers.ListAll();
                Assert.NotEqual(0, listLoadBalancerSubscription.Count());
                Assert.Collection(listLoadBalancerSubscription, item => Assert.Equal(lbName, item.Name));
                Assert.NotNull(listLoadBalancerSubscription.First().Name);
                Assert.NotNull(listLoadBalancerSubscription.First().Etag);

                // Verify List BackendAddressPools in LoadBalancer
                var listLoadBalancerBackendAddressPools = networkManagementClient.LoadBalancerBackendAddressPools.List(resourceGroupName, lbName);
                Assert.Equal(1, listLoadBalancerBackendAddressPools.Count());
                Assert.Equal(backEndAddressPoolName, listLoadBalancerBackendAddressPools.First().Name);
                Assert.NotNull(listLoadBalancerBackendAddressPools.First().Etag);

                // Verify Get BackendAddressPool in LoadBalancer
                var getLoadBalancerBackendAddressPool = networkManagementClient.LoadBalancerBackendAddressPools.Get(resourceGroupName, lbName, backEndAddressPoolName);
                Assert.Equal(backEndAddressPoolName, getLoadBalancerBackendAddressPool.Name);
                Assert.NotNull(getLoadBalancerBackendAddressPool.Etag);

                // Verify List FrontendIPConfigurations in LoadBalancer
                var listLoadBalancerFrontendIPConfigurations = networkManagementClient.LoadBalancerFrontendIPConfigurations.List(resourceGroupName, lbName);
                Assert.Equal(1, listLoadBalancerFrontendIPConfigurations.Count());
                Assert.Equal(frontendIpConfigName, listLoadBalancerFrontendIPConfigurations.First().Name);
                Assert.NotNull(listLoadBalancerFrontendIPConfigurations.First().Etag);

                // Verify Get FrontendIPConfiguration in LoadBalancer
                var getLoadBalancerFrontendIPConfiguration = networkManagementClient.LoadBalancerFrontendIPConfigurations.Get(resourceGroupName, lbName, frontendIpConfigName);
                Assert.Equal(frontendIpConfigName, getLoadBalancerFrontendIPConfiguration.Name);
                Assert.NotNull(getLoadBalancerFrontendIPConfiguration.Etag);

                // Verify List LoadBalancingRules in LoadBalancer
                var listLoadBalancerLoadBalancingRules = networkManagementClient.LoadBalancerLoadBalancingRules.List(resourceGroupName, lbName);
                Assert.Equal(1, listLoadBalancerLoadBalancingRules.Count());
                Assert.Equal(loadBalancingRuleName, listLoadBalancerLoadBalancingRules.First().Name);
                Assert.NotNull(listLoadBalancerLoadBalancingRules.First().Etag);

                // Verify Get LoadBalancingRule in LoadBalancer
                var getLoadBalancerLoadBalancingRule = networkManagementClient.LoadBalancerLoadBalancingRules.Get(resourceGroupName, lbName, loadBalancingRuleName);
                Assert.Equal(loadBalancingRuleName, getLoadBalancerLoadBalancingRule.Name);
                Assert.NotNull(getLoadBalancerLoadBalancingRule.Etag);

                // Verify List NetworkInterfaces in LoadBalancer
                var listLoadBalancerNetworkInterfaces = networkManagementClient.LoadBalancerNetworkInterfaces.List(resourceGroupName, lbName);
                Assert.Equal(0, listLoadBalancerNetworkInterfaces.Count());

                // Verify List Probes in LoadBalancer
                var listLoadBalancerProbes = networkManagementClient.LoadBalancerProbes.List(resourceGroupName, lbName);
                Assert.Equal(1, listLoadBalancerProbes.Count());
                Assert.Equal(probeName, listLoadBalancerProbes.First().Name);
                Assert.NotNull(listLoadBalancerProbes.First().Etag);

                // Verify Get Probe in LoadBalancer
                var getLoadBalancerProbe = networkManagementClient.LoadBalancerProbes.Get(resourceGroupName, lbName, probeName);
                Assert.Equal(probeName, getLoadBalancerProbe.Name);
                Assert.NotNull(getLoadBalancerProbe.Etag);

                // Prepare the third InboundNatRule
                var inboundNatRule3Params = new InboundNatRule()
                {
                    FrontendIPConfiguration = new SubResource()
                    {
                        Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                    },
                    Protocol = TransportProtocol.Tcp,
                    FrontendPort = 3391,
                    BackendPort = 3389,
                    IdleTimeoutInMinutes = 15,
                    EnableFloatingIP = false,
                };

                // Verify Put InboundNatRule in LoadBalancer
                var putInboundNatRule = networkManagementClient.InboundNatRules.CreateOrUpdate(resourceGroupName, lbName, inboundNatRule3Name, inboundNatRule3Params);
                Assert.Equal(inboundNatRule3Name, putInboundNatRule.Name);
                Assert.Equal(TransportProtocol.Tcp, putInboundNatRule.Protocol);
                Assert.Equal(3391, putInboundNatRule.FrontendPort);
                Assert.Equal(3389, putInboundNatRule.BackendPort);
                Assert.Equal(15, putInboundNatRule.IdleTimeoutInMinutes);
                Assert.Equal(false, putInboundNatRule.EnableFloatingIP);

                // Verify Get InboundNatRule in LoadBalancer
                var getInboundNatRule = networkManagementClient.InboundNatRules.Get(resourceGroupName, lbName, inboundNatRule3Name);
                Assert.Equal(inboundNatRule3Name, getInboundNatRule.Name);
                Assert.Equal(TransportProtocol.Tcp, getInboundNatRule.Protocol);
                Assert.Equal(3391, getInboundNatRule.FrontendPort);
                Assert.Equal(3389, getInboundNatRule.BackendPort);
                Assert.Equal(15, getInboundNatRule.IdleTimeoutInMinutes);
                Assert.Equal(false, getInboundNatRule.EnableFloatingIP);

                // Verify List InboundNatRules in LoadBalancer
                var listInboundNatRules = networkManagementClient.InboundNatRules.List(resourceGroupName, lbName);
                Assert.Equal(3, listInboundNatRules.Count());
                Assert.Collection(listInboundNatRules,
                    item => Assert.Equal(inboundNatRule1Name, item.Name),
                    item => Assert.Equal(inboundNatRule2Name, item.Name),
                    item => Assert.Equal(inboundNatRule3Name, item.Name)
                );

                // Delete InboundNatRule in LoadBalancer
                networkManagementClient.InboundNatRules.Delete(resourceGroupName, lbName, inboundNatRule3Name);

                // Delete LoadBalancer
                networkManagementClient.LoadBalancers.Delete(resourceGroupName, lbName);

                // Verify Delete
                listLoadBalancer = networkManagementClient.LoadBalancers.List(resourceGroupName);
                Assert.Equal(0, listLoadBalancer.Count());

                // Delete all PublicIPAddresses
                networkManagementClient.PublicIPAddresses.Delete(resourceGroupName, lbPublicIpName);
            }
        }

        [Fact(Skip="Disable tests")]
        public void LoadBalancerApiTestWithDynamicIp()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                var location = ResourcesManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/loadBalancers");
                
                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                // Create Vnet
                string vnetName = TestUtilities.GenerateName();
                string subnetName = TestUtilities.GenerateName();

                var vnet = TestHelper.CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location,
                    networkManagementClient);
                
                // Create the LoadBalancer
                var lbName = TestUtilities.GenerateName();
                var frontendIpConfigName = TestUtilities.GenerateName();
                var backEndAddressPoolName = TestUtilities.GenerateName();
                var loadBalancingRuleName = TestUtilities.GenerateName();
                var probeName = TestUtilities.GenerateName();
                var inboundNatRule1Name = TestUtilities.GenerateName();
                var inboundNatRule2Name = TestUtilities.GenerateName();

                // Populate the loadBalancerCreateOrUpdateParameter
                var loadbalancerparamater = new LoadBalancer()
                {
                    Location = location,
                    FrontendIPConfigurations = new List<FrontendIPConfiguration>()
                    {
                        new FrontendIPConfiguration()
                        {
                            Name = frontendIpConfigName,
                            PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                            Subnet = vnet.Subnets[0]
                        }
                    },
                    BackendAddressPools = new List<BackendAddressPool>()
                    {
                        new BackendAddressPool()
                        {
                            Name = backEndAddressPoolName,
                        }
                    },
                    LoadBalancingRules = new List<LoadBalancingRule>()
                    {
                        new LoadBalancingRule()
                        {
                            Name = loadBalancingRuleName,
                            FrontendIPConfiguration = new SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 80,
                            BackendPort = 80,
                            EnableFloatingIP = false,
                            IdleTimeoutInMinutes = 15,
                            BackendAddressPool = new SubResource()
                            {
                                Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "backendAddressPools", backEndAddressPoolName)
                            },
                            Probe = new SubResource()
                            {
                                Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId, 
                                resourceGroupName, lbName, "probes", probeName)
                            }
                        }
                    },
                    Probes = new List<Probe>()
                    {
                        new Probe()
                        {
                            Name = probeName,
                            Protocol = ProbeProtocol.Http,
                            Port = 80,
                            RequestPath = "healthcheck.aspx",
                            IntervalInSeconds = 10,
                            NumberOfProbes = 2
                        }
                    },
                    InboundNatRules = new List<InboundNatRule>()
                    {
                        new InboundNatRule()
                        {
                            Name = inboundNatRule1Name,
                            FrontendIPConfiguration = new SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 3389,
                            BackendPort = 3389,
                            IdleTimeoutInMinutes = 15,
                            EnableFloatingIP = false,
                        },
                        new InboundNatRule()
                        {
                            Name = inboundNatRule2Name,
                            FrontendIPConfiguration = new SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 3390,
                            BackendPort = 3389,
                            IdleTimeoutInMinutes = 15,
                            EnableFloatingIP = false,
                        }
                    }
                };

                // Create the loadBalancer
                var putLoadBalancer = networkManagementClient.LoadBalancers.CreateOrUpdate(resourceGroupName, lbName, loadbalancerparamater);
                
                var getLoadBalancer = networkManagementClient.LoadBalancers.Get(resourceGroupName, lbName);

                // Verify the GET LoadBalancer
                Assert.Equal(lbName, getLoadBalancer.Name);
                Assert.Equal("Succeeded", getLoadBalancer.ProvisioningState);
                Assert.Equal(frontendIpConfigName, getLoadBalancer.FrontendIPConfigurations[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.FrontendIPConfigurations[0].ProvisioningState);
                Assert.Equal(vnet.Subnets[0].Id, getLoadBalancer.FrontendIPConfigurations[0].Subnet.Id);
                Assert.NotNull(getLoadBalancer.FrontendIPConfigurations[0].PrivateIPAddress);
                Assert.Equal(getLoadBalancer.InboundNatRules[0].Id, getLoadBalancer.FrontendIPConfigurations[0].InboundNatRules[0].Id);
                Assert.Equal(getLoadBalancer.InboundNatRules[1].Id, getLoadBalancer.FrontendIPConfigurations[0].InboundNatRules[1].Id);
                Assert.Equal(backEndAddressPoolName, getLoadBalancer.BackendAddressPools[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.BackendAddressPools[0].ProvisioningState);
                Assert.Equal(getLoadBalancer.LoadBalancingRules[0].Id, getLoadBalancer.BackendAddressPools[0].LoadBalancingRules[0].Id);
                Assert.Equal(loadBalancingRuleName, getLoadBalancer.LoadBalancingRules[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancingRules[0].ProvisioningState);
                Assert.Equal(probeName, getLoadBalancer.Probes[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.Probes[0].ProvisioningState);
                Assert.Equal(getLoadBalancer.Probes[0].Id, getLoadBalancer.LoadBalancingRules[0].Probe.Id);
                Assert.Equal("Succeeded", getLoadBalancer.InboundNatRules[0].ProvisioningState);
                Assert.Equal(inboundNatRule1Name, getLoadBalancer.InboundNatRules[0].Name);
                Assert.Equal("Tcp", getLoadBalancer.InboundNatRules[0].Protocol);
                Assert.Equal(3389, getLoadBalancer.InboundNatRules[0].FrontendPort);
                Assert.Equal("Succeeded", getLoadBalancer.InboundNatRules[1].ProvisioningState);
                Assert.Equal(3390, getLoadBalancer.InboundNatRules[1].FrontendPort);

                // Verify List LoadBalancer
                var listLoadBalancer = networkManagementClient.LoadBalancers.List(resourceGroupName);
                Assert.Equal(1, listLoadBalancer.Count());
                Assert.Equal(lbName, listLoadBalancer.First().Name);
                Assert.Equal(getLoadBalancer.Etag, listLoadBalancer.First().Etag);

                // Verify List LoadBalancer subscription
                var listLoadBalancerSubscription = networkManagementClient.LoadBalancers.ListAll();
                Assert.NotEqual(0, listLoadBalancerSubscription.Count());
                Assert.NotNull(listLoadBalancerSubscription.First().Name);
                Assert.NotNull(listLoadBalancerSubscription.First().Etag);

                // Delete LoadBalancer
                networkManagementClient.LoadBalancers.Delete(resourceGroupName, lbName);

                // Verify Delete
                listLoadBalancer = networkManagementClient.LoadBalancers.List(resourceGroupName);
                Assert.Equal(0, listLoadBalancer.Count());

                // Delete VirtualNetwork
                networkManagementClient.VirtualNetworks.Delete(resourceGroupName, vnetName);
            }
        }

        [Fact(Skip="Disable tests")]
        public void LoadBalancerApiTestWithStaticIp()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                var location = ResourcesManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/loadBalancers");

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                // Create Vnet
                string vnetName = TestUtilities.GenerateName();
                string subnetName = TestUtilities.GenerateName();

                var vnet = TestHelper.CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location,
                    networkManagementClient);

                // Create the LoadBalancer
                var lbName = TestUtilities.GenerateName();
                var frontendIpConfigName = TestUtilities.GenerateName();
                var backEndAddressPoolName = TestUtilities.GenerateName();
                var loadBalancingRuleName = TestUtilities.GenerateName();
                var probeName = TestUtilities.GenerateName();
                var inboundNatRule1Name = TestUtilities.GenerateName();
                var inboundNatRule2Name = TestUtilities.GenerateName();

                // Populate the loadBalancerCreateOrUpdateParameter
                var loadbalancerparamater = new LoadBalancer()
                {
                    Location = location,
                    FrontendIPConfigurations = new List<FrontendIPConfiguration>()
                    {
                        new FrontendIPConfiguration()
                        {
                            Name = frontendIpConfigName,
                            PrivateIPAllocationMethod = IPAllocationMethod.Static,
                            PrivateIPAddress = "10.0.0.38",
                            Subnet = vnet.Subnets[0]
                        }
                    },
                    BackendAddressPools = new List<BackendAddressPool>()
                    {
                        new BackendAddressPool()
                        {
                            Name = backEndAddressPoolName,
                        }
                    },
                    LoadBalancingRules = new List<LoadBalancingRule>()
                    {
                        new LoadBalancingRule()
                        {
                            Name = loadBalancingRuleName,
                            FrontendIPConfiguration = new SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 80,
                            BackendPort = 80,
                            EnableFloatingIP = false,
                            BackendAddressPool = new SubResource()
                            {
                                Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "backendAddressPools", backEndAddressPoolName)
                            },
                            Probe = new SubResource()
                            {
                                Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId, 
                                resourceGroupName, lbName, "probes", probeName)
                            }
                        }
                    },
                    Probes = new List<Probe>()
                    {
                        new Probe()
                        {
                            Name = probeName,
                            Protocol = ProbeProtocol.Http,
                            Port = 80,
                            RequestPath = "healthcheck.aspx",
                            IntervalInSeconds = 10,
                            NumberOfProbes = 2
                        }
                    },
                    InboundNatRules = new List<InboundNatRule>()
                    {
                        new InboundNatRule()
                        {
                            Name = inboundNatRule1Name,
                            FrontendIPConfiguration = new SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 3389,
                            BackendPort = 3389,
                            EnableFloatingIP = false,
                        },
                        new InboundNatRule()
                        {
                            Name = inboundNatRule2Name,
                            FrontendIPConfiguration = new SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 3390,
                            BackendPort = 3389,
                            EnableFloatingIP = false,
                        }
                    }
                };

                // Create the loadBalancer
                var putLoadBalancer = networkManagementClient.LoadBalancers.CreateOrUpdate(resourceGroupName, lbName, loadbalancerparamater);

                var getLoadBalancer = networkManagementClient.LoadBalancers.Get(resourceGroupName, lbName);

                // Verify the GET LoadBalancer
                Assert.Equal(lbName, getLoadBalancer.Name);
                Assert.Equal("Succeeded", getLoadBalancer.ProvisioningState);
                Assert.Equal(frontendIpConfigName, getLoadBalancer.FrontendIPConfigurations[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.FrontendIPConfigurations[0].ProvisioningState);
                Assert.Equal(vnet.Subnets[0].Id, getLoadBalancer.FrontendIPConfigurations[0].Subnet.Id);
                Assert.NotNull(getLoadBalancer.FrontendIPConfigurations[0].PrivateIPAddress);
                Assert.Equal("10.0.0.38", getLoadBalancer.FrontendIPConfigurations[0].PrivateIPAddress);
                Assert.Equal(getLoadBalancer.InboundNatRules[0].Id, getLoadBalancer.FrontendIPConfigurations[0].InboundNatRules[0].Id);
                Assert.Equal(getLoadBalancer.InboundNatRules[1].Id, getLoadBalancer.FrontendIPConfigurations[0].InboundNatRules[1].Id);
                Assert.Equal(backEndAddressPoolName, getLoadBalancer.BackendAddressPools[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.BackendAddressPools[0].ProvisioningState);
                Assert.Equal(getLoadBalancer.LoadBalancingRules[0].Id, getLoadBalancer.BackendAddressPools[0].LoadBalancingRules[0].Id);
                Assert.Equal(loadBalancingRuleName, getLoadBalancer.LoadBalancingRules[0].Name);
                Assert.Equal(LoadDistribution.Default, getLoadBalancer.LoadBalancingRules[0].LoadDistribution);
                Assert.Equal(4, getLoadBalancer.LoadBalancingRules[0].IdleTimeoutInMinutes);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancingRules[0].ProvisioningState);
                Assert.Equal(probeName, getLoadBalancer.Probes[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.Probes[0].ProvisioningState);
                Assert.Equal(getLoadBalancer.Probes[0].Id, getLoadBalancer.LoadBalancingRules[0].Probe.Id);
                Assert.Equal("Succeeded", getLoadBalancer.InboundNatRules[0].ProvisioningState);
                Assert.Equal(inboundNatRule1Name, getLoadBalancer.InboundNatRules[0].Name);
                Assert.Equal("Tcp", getLoadBalancer.InboundNatRules[0].Protocol);
                Assert.Equal(3389, getLoadBalancer.InboundNatRules[0].FrontendPort);
                Assert.Equal("Succeeded", getLoadBalancer.InboundNatRules[1].ProvisioningState);
                Assert.Equal(3390, getLoadBalancer.InboundNatRules[1].FrontendPort);
                Assert.Equal(4, getLoadBalancer.InboundNatRules[1].IdleTimeoutInMinutes);

                // Verify List LoadBalancer
                var listLoadBalancer = networkManagementClient.LoadBalancers.List(resourceGroupName);
                Assert.Equal(1, listLoadBalancer.Count());
                Assert.Equal(lbName, listLoadBalancer.First().Name);
                Assert.Equal(getLoadBalancer.Etag, listLoadBalancer.First().Etag);

                // Verify List LoadBalancer subscription
                var listLoadBalancerSubscription = networkManagementClient.LoadBalancers.ListAll();
                Assert.NotEqual(0, listLoadBalancerSubscription.Count());
                Assert.NotNull(listLoadBalancerSubscription.First().Name);
                Assert.NotNull(listLoadBalancerSubscription.First().Etag);

                // Delete LoadBalancer
                networkManagementClient.LoadBalancers.Delete(resourceGroupName, lbName);

                // Verify Delete
                listLoadBalancer = networkManagementClient.LoadBalancers.List(resourceGroupName);
                Assert.Equal(0, listLoadBalancer.Count());

                // Delete VirtualNetwork
                networkManagementClient.VirtualNetworks.Delete(resourceGroupName, vnetName);
            }
        }

        [Fact(Skip="Disable tests")]
        public void LoadBalancerApiTestWithDistributionPolicy()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                var location = ResourcesManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/loadBalancers");

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                // Create Vnet
                string vnetName = TestUtilities.GenerateName();
                string subnetName = TestUtilities.GenerateName();

                var vnet = TestHelper.CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location,
                    networkManagementClient);

                // Create the LoadBalancer
                var lbName = TestUtilities.GenerateName();
                var frontendIpConfigName = TestUtilities.GenerateName();
                var backEndAddressPoolName = TestUtilities.GenerateName();
                var loadBalancingRuleName = TestUtilities.GenerateName();
                var probeName = TestUtilities.GenerateName();
                var inboundNatRule1Name = TestUtilities.GenerateName();
                var inboundNatRule2Name = TestUtilities.GenerateName();

                // Populate the loadBalancerCreateOrUpdateParameter
                var loadbalancerparamater = new LoadBalancer()
                {
                    Location = location,
                    FrontendIPConfigurations = new List<FrontendIPConfiguration>()
                    {
                        new FrontendIPConfiguration()
                        {
                            Name = frontendIpConfigName,
                            PrivateIPAllocationMethod = IPAllocationMethod.Static,
                            PrivateIPAddress = "10.0.0.38",
                            Subnet = vnet.Subnets[0]
                        }
                    },
                    BackendAddressPools = new List<BackendAddressPool>()
                    {
                        new BackendAddressPool()
                        {
                            Name = backEndAddressPoolName,
                        }
                    },
                    LoadBalancingRules = new List<LoadBalancingRule>()
                    {
                        new LoadBalancingRule()
                        {
                            Name = loadBalancingRuleName,
                            FrontendIPConfiguration = new SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 80,
                            BackendPort = 80,
                            EnableFloatingIP = false,
                            BackendAddressPool = new SubResource()
                            {
                                Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "backendAddressPools", backEndAddressPoolName)
                            },
                            Probe = new SubResource()
                            {
                                Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId, 
                                resourceGroupName, lbName, "probes", probeName)
                            }
                        }
                    },
                    Probes = new List<Probe>()
                    {
                        new Probe()
                        {
                            Name = probeName,
                            Protocol = ProbeProtocol.Http,
                            Port = 80,
                            RequestPath = "healthcheck.aspx",
                            IntervalInSeconds = 10,
                            NumberOfProbes = 2
                            
                        }
                    },
                    InboundNatRules = new List<InboundNatRule>()
                    {
                        new InboundNatRule()
                        {
                            Name = inboundNatRule1Name,
                            FrontendIPConfiguration = new SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 3389,
                            BackendPort = 3389,
                            EnableFloatingIP = false,
                        },
                        new InboundNatRule()
                        {
                            Name = inboundNatRule2Name,
                            FrontendIPConfiguration = new SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 3390,
                            BackendPort = 3389,
                            EnableFloatingIP = false,
                        }
                    }
                };

                // Create the loadBalancer
                networkManagementClient.LoadBalancers.CreateOrUpdate(resourceGroupName, lbName, loadbalancerparamater);
                
                var getLoadBalancer = networkManagementClient.LoadBalancers.Get(resourceGroupName, lbName);

                // Verify the GET LoadBalancer
                Assert.Equal(lbName, getLoadBalancer.Name);
                Assert.Equal("Succeeded", getLoadBalancer.ProvisioningState);
                Assert.Equal(frontendIpConfigName, getLoadBalancer.FrontendIPConfigurations[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.FrontendIPConfigurations[0].ProvisioningState);
                Assert.Equal(vnet.Subnets[0].Id, getLoadBalancer.FrontendIPConfigurations[0].Subnet.Id);
                Assert.NotNull(getLoadBalancer.FrontendIPConfigurations[0].PrivateIPAddress);
                Assert.Equal("10.0.0.38", getLoadBalancer.FrontendIPConfigurations[0].PrivateIPAddress);
                Assert.Equal(getLoadBalancer.InboundNatRules[0].Id, getLoadBalancer.FrontendIPConfigurations[0].InboundNatRules[0].Id);
                Assert.Equal(getLoadBalancer.InboundNatRules[1].Id, getLoadBalancer.FrontendIPConfigurations[0].InboundNatRules[1].Id);
                Assert.Equal(backEndAddressPoolName, getLoadBalancer.BackendAddressPools[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.BackendAddressPools[0].ProvisioningState);
                Assert.Equal(getLoadBalancer.LoadBalancingRules[0].Id, getLoadBalancer.BackendAddressPools[0].LoadBalancingRules[0].Id);
                Assert.Equal(loadBalancingRuleName, getLoadBalancer.LoadBalancingRules[0].Name);
                Assert.Equal(LoadDistribution.Default, getLoadBalancer.LoadBalancingRules[0].LoadDistribution);
                Assert.Equal(4, getLoadBalancer.LoadBalancingRules[0].IdleTimeoutInMinutes);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancingRules[0].ProvisioningState);
                Assert.Equal(probeName, getLoadBalancer.Probes[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.Probes[0].ProvisioningState);
                Assert.Equal(getLoadBalancer.Probes[0].Id, getLoadBalancer.LoadBalancingRules[0].Probe.Id);
                Assert.Equal("Succeeded", getLoadBalancer.InboundNatRules[0].ProvisioningState);
                Assert.Equal(inboundNatRule1Name, getLoadBalancer.InboundNatRules[0].Name);
                Assert.Equal("Tcp", getLoadBalancer.InboundNatRules[0].Protocol);
                Assert.Equal(3389, getLoadBalancer.InboundNatRules[0].FrontendPort);
                Assert.Equal("Succeeded", getLoadBalancer.InboundNatRules[1].ProvisioningState);
                Assert.Equal(3390, getLoadBalancer.InboundNatRules[1].FrontendPort);
                Assert.Equal(4, getLoadBalancer.InboundNatRules[1].IdleTimeoutInMinutes);

                // Verify List LoadBalancer
                var listLoadBalancer = networkManagementClient.LoadBalancers.List(resourceGroupName);
                Assert.Equal(1, listLoadBalancer.Count());
                Assert.Equal(lbName, listLoadBalancer.First().Name);
                Assert.Equal(getLoadBalancer.Etag, listLoadBalancer.First().Etag);

                // Do another put after changing the distribution policy
                loadbalancerparamater.LoadBalancingRules[0].LoadDistribution = LoadDistribution.SourceIP;
                networkManagementClient.LoadBalancers.CreateOrUpdate(resourceGroupName, lbName, loadbalancerparamater);
                getLoadBalancer = networkManagementClient.LoadBalancers.Get(resourceGroupName, lbName);
                
                Assert.Equal(LoadDistribution.SourceIP, getLoadBalancer.LoadBalancingRules[0].LoadDistribution);

                loadbalancerparamater.LoadBalancingRules[0].LoadDistribution = LoadDistribution.SourceIPProtocol;
                networkManagementClient.LoadBalancers.CreateOrUpdate(resourceGroupName, lbName, loadbalancerparamater);
                getLoadBalancer = networkManagementClient.LoadBalancers.Get(resourceGroupName, lbName);
                
                Assert.Equal(LoadDistribution.SourceIPProtocol, getLoadBalancer.LoadBalancingRules[0].LoadDistribution);

                // Delete LoadBalancer
                networkManagementClient.LoadBalancers.Delete(resourceGroupName, lbName);

                // Verify Delete
                listLoadBalancer = networkManagementClient.LoadBalancers.List(resourceGroupName);
                Assert.Equal(0, listLoadBalancer.Count());

                // Delete VirtualNetwork
                networkManagementClient.VirtualNetworks.Delete(resourceGroupName, vnetName);
            }
        }

        [Fact(Skip="Disable tests")]
        public void CreateEmptyLoadBalancer()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                var location = ResourcesManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/loadBalancers");

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(
                    resourceGroupName,
                    new ResourceGroup
                        {
                        Location = location
                    });

                // Create the empty LoadBalancer
                var lbname = TestUtilities.GenerateName();
                
                // Populate the loadBalancerCreateOrUpdateParameter
                var loadbalancerparamater = new LoadBalancer()
                {
                    Location = location,
                };

                // Create the loadBalancer
                var putLoadBalancer = networkManagementClient.LoadBalancers.CreateOrUpdate(resourceGroupName, lbname, loadbalancerparamater);
                
                var getLoadBalancer = networkManagementClient.LoadBalancers.Get(resourceGroupName, lbname);

                // Verify the GET LoadBalancer
                Assert.Equal(lbname, getLoadBalancer.Name);
                Assert.Equal("Succeeded", getLoadBalancer.ProvisioningState);
                Assert.False(getLoadBalancer.FrontendIPConfigurations.Any());
                Assert.False(getLoadBalancer.BackendAddressPools.Any());
                Assert.False(getLoadBalancer.LoadBalancingRules.Any());
                Assert.False(getLoadBalancer.Probes.Any());
                Assert.False(getLoadBalancer.InboundNatRules.Any());

                // Delete LoadBalancer
                networkManagementClient.LoadBalancers.Delete(resourceGroupName, lbname);

                // Verify Delete
                var listLoadBalancer = networkManagementClient.LoadBalancers.List(resourceGroupName);
                Assert.Equal(0, listLoadBalancer.Count());
            }
        }

        [Fact(Skip="Disable tests")]
        public void UpdateLoadBalancerRule()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                var location = ResourcesManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/loadBalancers");

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(
                    resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                // Create Vnet
                string vnetName = TestUtilities.GenerateName();
                string subnetName = TestUtilities.GenerateName();

                var vnet = TestHelper.CreateVirtualNetwork(
                    vnetName,
                    subnetName,
                    resourceGroupName,
                    location,
                    networkManagementClient);

                // Create the LoadBalancer with an lb rule and no probe
                var lbname = TestUtilities.GenerateName();
                var frontendIpConfigName = TestUtilities.GenerateName();
                var backEndAddressPoolName = TestUtilities.GenerateName();
                var loadBalancingRuleName = TestUtilities.GenerateName();
                var probeName = TestUtilities.GenerateName();

                // Populate the loadBalancerCreateOrUpdateParameter
                var loadbalancerparamater = new LoadBalancer()
                {
                    Location = location,
                    FrontendIPConfigurations = new List<FrontendIPConfiguration>()
                    {
                        new FrontendIPConfiguration()
                        {
                            Name = frontendIpConfigName,
                            PrivateIPAllocationMethod = IPAllocationMethod.Static,
                            PrivateIPAddress = "10.0.0.38",
                            Subnet = vnet.Subnets[0]
                        }
                    },
                    BackendAddressPools = new List<BackendAddressPool>()
                    {
                        new BackendAddressPool()
                        {
                            Name = backEndAddressPoolName,
                        }
                    },
                    LoadBalancingRules = new List<LoadBalancingRule>()
                    {
                        new LoadBalancingRule()
                        {
                            Name = loadBalancingRuleName,
                            FrontendIPConfiguration = new SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbname, "frontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 80,
                            BackendPort = 80,
                            EnableFloatingIP = false,
                            BackendAddressPool = new SubResource()
                            {
                                Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbname, "backendAddressPools", backEndAddressPoolName)
                            }
                        }
                    },
                };

                // Create the loadBalancer
                networkManagementClient.LoadBalancers.CreateOrUpdate(resourceGroupName, lbname, loadbalancerparamater);
                
                var getLoadBalancer = networkManagementClient.LoadBalancers.Get(resourceGroupName, lbname);

                // Verify the GET LoadBalancer
                Assert.Equal(lbname, getLoadBalancer.Name);
                Assert.Equal("Succeeded", getLoadBalancer.ProvisioningState);
                Assert.Equal(1, getLoadBalancer.FrontendIPConfigurations.Count);
                Assert.Equal(1, getLoadBalancer.BackendAddressPools.Count);
                Assert.Equal(1, getLoadBalancer.LoadBalancingRules.Count);
                Assert.False(getLoadBalancer.Probes.Any());
                Assert.False(getLoadBalancer.InboundNatRules.Any());

                // Add a Probe to the lb rule
                getLoadBalancer.Probes = new List<Probe>()
                                                          {
                                                              new Probe()
                                                                  {
                                                                      Name = probeName,
                                                                      Protocol = ProbeProtocol.Http,
                                                                      Port = 80,
                                                                      RequestPath =
                                                                          "healthcheck.aspx",
                                                                      IntervalInSeconds = 10,
                                                                      NumberOfProbes = 2
                                                                  }
                                                          };

                getLoadBalancer.LoadBalancingRules[0].Probe = new SubResource()
                                                                               {
                                                                                   Id =
                                                                                       TestHelper.GetChildLbResourceId(
                                                                                           networkManagementClient.SubscriptionId,
                                                                                           resourceGroupName,
                                                                                           lbname,
                                                                                           "probes",
                                                                                           probeName)
                                                                               };

                // update load balancer
                var putLoadBalancer = networkManagementClient.LoadBalancers.CreateOrUpdate(resourceGroupName, lbname, getLoadBalancer);
                
                getLoadBalancer = networkManagementClient.LoadBalancers.Get(resourceGroupName, lbname);

                // Verify the GET LoadBalancer
                Assert.Equal(lbname, getLoadBalancer.Name);
                Assert.Equal("Succeeded", getLoadBalancer.ProvisioningState);
                Assert.Equal(1, getLoadBalancer.FrontendIPConfigurations.Count);
                Assert.Equal(1, getLoadBalancer.BackendAddressPools.Count);
                Assert.Equal(1, getLoadBalancer.LoadBalancingRules.Count);
                Assert.Equal(1, getLoadBalancer.Probes.Count);
                Assert.Equal(getLoadBalancer.Probes[0].Id, getLoadBalancer.LoadBalancingRules[0].Probe.Id);
                Assert.False(getLoadBalancer.InboundNatRules.Any());

                // Delete LoadBalancer
                networkManagementClient.LoadBalancers.Delete(resourceGroupName, lbname);

                // Verify Delete
                var listLoadBalancer = networkManagementClient.LoadBalancers.List(resourceGroupName);
                Assert.Equal(0, listLoadBalancer.Count());

                // Delete VirtualNetwork
                networkManagementClient.VirtualNetworks.Delete(resourceGroupName, vnetName);
            }
        }
        
        [Fact(Skip="Disable tests")]
        public void LoadBalancerApiNicAssociationTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/loadBalancers");

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(
                    resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                // Create lbPublicIP
                string lbPublicIpName = TestUtilities.GenerateName();
                string lbDomaingNameLabel = TestUtilities.GenerateName();

                var lbPublicIp = TestHelper.CreateDefaultPublicIpAddress(
                    lbPublicIpName,
                    resourceGroupName,
                    lbDomaingNameLabel,
                    location,
                    networkManagementClient);

                // Create Vnet
                string vnetName = TestUtilities.GenerateName();
                string subnetName = TestUtilities.GenerateName();

                var vnet = TestHelper.CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location,
                    networkManagementClient);

                // Create Nics
                string nic1name = TestUtilities.GenerateName();
                string nic2name = TestUtilities.GenerateName();
                string nic3name = TestUtilities.GenerateName();

                var nic1 = TestHelper.CreateNetworkInterface(
                    nic1name,
                    resourceGroupName,
                    null,
                    vnet.Subnets[0].Id,
                    location,
                    "ipconfig",
                    networkManagementClient);

                var nic2 = TestHelper.CreateNetworkInterface(
                    nic2name,
                    resourceGroupName,
                    null,
                    vnet.Subnets[0].Id,
                    location,
                    "ipconfig",
                    networkManagementClient);

                var nic3 = TestHelper.CreateNetworkInterface(
                    nic3name,
                    resourceGroupName,
                    null,
                    vnet.Subnets[0].Id,
                    location,
                    "ipconfig",
                    networkManagementClient);

                // Create the LoadBalancer
                var lbName = TestUtilities.GenerateName();
                var frontendIpConfigName = TestUtilities.GenerateName();
                var backEndAddressPoolName = TestUtilities.GenerateName();
                var loadBalancingRuleName = TestUtilities.GenerateName();
                var probeName = TestUtilities.GenerateName();
                var inboundNatRule1Name = TestUtilities.GenerateName();
                var inboundNatRule2Name = TestUtilities.GenerateName();

                // Populate the loadBalancerCreateOrUpdateParameter
                var loadBalancer = new LoadBalancer()
                {
                    Location = location,
                    FrontendIPConfigurations = new List<FrontendIPConfiguration>()
                    {
                        new FrontendIPConfiguration()
                        {
                            Name = frontendIpConfigName,
                            PublicIPAddress = new PublicIPAddress()
                            {
                                Id = lbPublicIp.Id
                            }
                        }
                    },
                    BackendAddressPools = new List<BackendAddressPool>()
                    {
                        new BackendAddressPool()
                        {
                            Name = backEndAddressPoolName,
                        }
                    },
                    LoadBalancingRules = new List<LoadBalancingRule>()
                    {
                        new LoadBalancingRule()
                        {
                            Name = loadBalancingRuleName,
                            FrontendIPConfiguration = new SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 80,
                            BackendPort = 80,
                            EnableFloatingIP = false,
                            IdleTimeoutInMinutes = 15,
                            BackendAddressPool = new SubResource()
                            {
                                Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "backendAddressPools", backEndAddressPoolName)
                            },
                            Probe = new SubResource()
                            {
                                Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId, 
                                resourceGroupName, lbName, "probes", probeName)
                            }
                        }
                    },
                    Probes = new List<Probe>()
                    {
                        new Probe()
                        {
                            Name = probeName,
                            Protocol = ProbeProtocol.Http,
                            Port = 80,
                            RequestPath = "healthcheck.aspx",
                            IntervalInSeconds = 10,
                            NumberOfProbes = 2
                        }
                    },
                    InboundNatRules = new List<InboundNatRule>()
                    {
                        new InboundNatRule()
                        {
                            Name = inboundNatRule1Name,
                            FrontendIPConfiguration = new SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 3389,
                            BackendPort = 3389,
                            IdleTimeoutInMinutes = 15,
                            EnableFloatingIP = false
                        },
                        new InboundNatRule()
                        {
                            Name = inboundNatRule2Name,
                            FrontendIPConfiguration = new SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 3390,
                            BackendPort = 3389,
                            IdleTimeoutInMinutes = 15,
                            EnableFloatingIP = false,
                        }
                    }
                };

                // Create the loadBalancer
                var putLoadBalancer = networkManagementClient.LoadBalancers.CreateOrUpdate(resourceGroupName, lbName, loadBalancer);
                
                var getLoadBalancer = networkManagementClient.LoadBalancers.Get(resourceGroupName, lbName);

                // Associate the nic with LB
                nic1.IpConfigurations.First().LoadBalancerBackendAddressPools = new List<BackendAddressPool>
                                                                                    {
                                                                                        getLoadBalancer.BackendAddressPools.First()
                                                                                    };

                nic1.IpConfigurations.First().LoadBalancerInboundNatRules = new List<InboundNatRule>
                                                                                    {
                                                                                        getLoadBalancer.InboundNatRules.First()
                                                                                    };

                nic2.IpConfigurations.First().LoadBalancerBackendAddressPools = new List<BackendAddressPool>
                                                                                    {
                                                                                        getLoadBalancer.BackendAddressPools.First()
                                                                                    };

                nic3.IpConfigurations.First().LoadBalancerInboundNatRules = new List<InboundNatRule>
                                                                                    {
                                                                                        getLoadBalancer.InboundNatRules[1]
                                                                                    };

                // Put Nics
                networkManagementClient.NetworkInterfaces.CreateOrUpdate(resourceGroupName, nic1name, nic1);
                networkManagementClient.NetworkInterfaces.CreateOrUpdate(resourceGroupName, nic2name, nic2);
                networkManagementClient.NetworkInterfaces.CreateOrUpdate(resourceGroupName, nic3name, nic3);

                // Get Nics
                nic1 = networkManagementClient.NetworkInterfaces.Get(resourceGroupName, nic1name);
                nic2 = networkManagementClient.NetworkInterfaces.Get(resourceGroupName, nic2name);
                nic3 = networkManagementClient.NetworkInterfaces.Get(resourceGroupName, nic3name);

                // Verify the associations
                getLoadBalancer = networkManagementClient.LoadBalancers.Get(resourceGroupName, lbName);
                Assert.Equal(2, getLoadBalancer.BackendAddressPools.First().BackendIPConfigurations.Count);
                Assert.True(getLoadBalancer.BackendAddressPools.First().BackendIPConfigurations.Any(ipconfig => string.Equals(ipconfig.Id, nic1.IpConfigurations[0].Id, StringComparison.OrdinalIgnoreCase)));
                Assert.True(getLoadBalancer.BackendAddressPools.First().BackendIPConfigurations.Any(ipconfig => string.Equals(ipconfig.Id, nic2.IpConfigurations[0].Id, StringComparison.OrdinalIgnoreCase)));
                Assert.Equal(nic1.IpConfigurations[0].Id, getLoadBalancer.InboundNatRules.First().BackendIPConfiguration.Id);
                Assert.Equal(nic3.IpConfigurations[0].Id, getLoadBalancer.InboundNatRules[1].BackendIPConfiguration.Id);

                // Verify List NetworkInterfaces in LoadBalancer// Verify List NetworkInterfaces in LoadBalancer
                var listLoadBalancerNetworkInterfaces = networkManagementClient.LoadBalancerNetworkInterfaces.List(resourceGroupName, lbName);
                Assert.Equal(3, listLoadBalancerNetworkInterfaces.Count());

                // Delete LoadBalancer
                networkManagementClient.LoadBalancers.Delete(resourceGroupName, lbName);

                // Verify Delete
                var listLoadBalancer = networkManagementClient.LoadBalancers.List(resourceGroupName);
                Assert.Equal(0, listLoadBalancer.Count());

                // Delete all NetworkInterfaces
                networkManagementClient.NetworkInterfaces.Delete(resourceGroupName, nic1name);
                networkManagementClient.NetworkInterfaces.Delete(resourceGroupName, nic2name);
                networkManagementClient.NetworkInterfaces.Delete(resourceGroupName, nic3name);

                // Delete all PublicIPAddresses
                networkManagementClient.PublicIPAddresses.Delete(resourceGroupName, lbPublicIpName);
            }
        }

        [Fact(Skip="Disable tests")]
        public void LoadBalancerNatPoolTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);
                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/loadBalancers");

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(
                    resourceGroupName,
                    new ResourceGroup { Location = location });

                // Create lbPublicIP
                string lbPublicIpName = TestUtilities.GenerateName();
                string lbDomaingNameLabel = TestUtilities.GenerateName();

                var lbPublicIp = TestHelper.CreateDefaultPublicIpAddress(
                    lbPublicIpName,
                    resourceGroupName,
                    lbDomaingNameLabel,
                    location,
                    networkManagementClient);

                // Create the LoadBalancer
                var lbName = TestUtilities.GenerateName();
                var frontendIpConfigName = TestUtilities.GenerateName();
                var inboundNatPool1Name = TestUtilities.GenerateName();
                var inboundNatPool2Name = TestUtilities.GenerateName();

                 var loadBalancer = new LoadBalancer()
                {
                    Location = location,
                    FrontendIPConfigurations = new List<FrontendIPConfiguration>()
                    {
                        new FrontendIPConfiguration()
                        {
                            Name = frontendIpConfigName,
                            PublicIPAddress = new PublicIPAddress ()
                            {
                                Id = lbPublicIp.Id
                            }
                        }
                    },
                    InboundNatPools = new List<InboundNatPool>()
                    {
                       new InboundNatPool()
                        {
                            Name = inboundNatPool1Name,
                            BackendPort = 81,
                            FrontendPortRangeStart = 100,
                            FrontendPortRangeEnd = 105,
                            FrontendIPConfiguration = new SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                        } 
                    }
                };

                // Create the loadBalancer
                networkManagementClient.LoadBalancers.CreateOrUpdate(
                    resourceGroupName,
                    lbName,
                    loadBalancer);
                
                var getLoadBalancer = networkManagementClient.LoadBalancers.Get(resourceGroupName, lbName);

                // Verify the GET LoadBalancer
                Assert.Equal(lbName, getLoadBalancer.Name);
                Assert.Equal("Succeeded", getLoadBalancer.ProvisioningState);
                Assert.Equal(frontendIpConfigName, getLoadBalancer.FrontendIPConfigurations[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.FrontendIPConfigurations[0].ProvisioningState);

                // Verify the nat pool
                Assert.Equal(1, getLoadBalancer.InboundNatPools.Count);
                Assert.Equal(inboundNatPool1Name, getLoadBalancer.InboundNatPools[0].Name);
                Assert.Equal(81, getLoadBalancer.InboundNatPools[0].BackendPort);
                Assert.Equal(100, getLoadBalancer.InboundNatPools[0].FrontendPortRangeStart);
                Assert.Equal(105, getLoadBalancer.InboundNatPools[0].FrontendPortRangeEnd);
                Assert.Equal(TransportProtocol.Tcp, getLoadBalancer.InboundNatPools[0].Protocol);
                Assert.Equal(TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName), getLoadBalancer.InboundNatPools[0].FrontendIPConfiguration.Id);

                Assert.Equal(getLoadBalancer.InboundNatPools[0].Id, getLoadBalancer.FrontendIPConfigurations[0].InboundNatPools[0].Id);

                // Add a new nat pool
                var natpool2 = new InboundNatPool()
                        {
                            Name = inboundNatPool2Name,
                            BackendPort = 81,
                            FrontendPortRangeStart = 107,
                            FrontendPortRangeEnd = 110,
                            FrontendIPConfiguration = new SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                        };
                getLoadBalancer.InboundNatPools.Add(natpool2);

                networkManagementClient.LoadBalancers.CreateOrUpdate(
                   resourceGroupName,
                   lbName,
                   getLoadBalancer);

                // Verify the nat pool
                Assert.Equal(2, getLoadBalancer.InboundNatPools.Count);

                // Delete LoadBalancer
                networkManagementClient.LoadBalancers.Delete(resourceGroupName, lbName);

                // Verify Delete
                var listLoadBalancer = networkManagementClient.LoadBalancers.List(resourceGroupName);
                Assert.Equal(0, listLoadBalancer.Count());

                // Delete all PublicIPAddresses
                networkManagementClient.PublicIPAddresses.Delete(resourceGroupName, lbPublicIpName);
             }
        }
    }
}
