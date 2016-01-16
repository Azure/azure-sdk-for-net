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

    public class LoadBalancerTests
    {
        [Fact]
        public void LoadBalancerApiTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(handler);
                var networkResourceProviderClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);
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
                    networkResourceProviderClient);

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
                    Name = lbName,
                    Location = location,
                    FrontendIpConfigurations = new List<FrontendIpConfiguration>()
                    {
                        new FrontendIpConfiguration()
                        {
                            Name = frontendIpConfigName,
                            PublicIpAddress = new ResourceId()
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
                            FrontendIPConfiguration = new ResourceId()
                                {
                                    Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 80,
                            BackendPort = 80,
                            EnableFloatingIP = false,
                            IdleTimeoutInMinutes = 15,
                            BackendAddressPool = new ResourceId()
                            {
                                Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, lbName, "backendAddressPools", backEndAddressPoolName)
                            },
                            Probe = new ResourceId()
                            {
                                Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId, 
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
                            FrontendIPConfiguration = new ResourceId()
                                {
                                    Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
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
                            FrontendIPConfiguration = new ResourceId()
                                {
                                    Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
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
                var putLoadBalancer = networkResourceProviderClient.LoadBalancers.CreateOrUpdate(resourceGroupName,lbName, loadBalancer);
                Assert.Equal(HttpStatusCode.OK, putLoadBalancer.StatusCode);

                var getLoadBalancer = networkResourceProviderClient.LoadBalancers.Get(resourceGroupName, lbName);

                // Verify the GET LoadBalancer
                Assert.Equal(lbName, getLoadBalancer.LoadBalancer.Name);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.ProvisioningState);
                Assert.Equal(frontendIpConfigName, getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].ProvisioningState);
                Assert.Equal(lbPublicIp.Id, getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].PublicIpAddress.Id);
                Assert.Null(getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].PrivateIpAddress);
                Assert.Equal(getLoadBalancer.LoadBalancer.InboundNatRules[0].Id, getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].InboundNatRules[0].Id);
                Assert.Equal(getLoadBalancer.LoadBalancer.InboundNatRules[1].Id, getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].InboundNatRules[1].Id);
                Assert.Equal(backEndAddressPoolName, getLoadBalancer.LoadBalancer.BackendAddressPools[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.BackendAddressPools[0].ProvisioningState);
                Assert.Equal(getLoadBalancer.LoadBalancer.LoadBalancingRules[0].Id, getLoadBalancer.LoadBalancer.BackendAddressPools[0].LoadBalancingRules[0].Id);
                Assert.Equal(loadBalancingRuleName, getLoadBalancer.LoadBalancer.LoadBalancingRules[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.LoadBalancingRules[0].ProvisioningState);
                Assert.Equal(15, getLoadBalancer.LoadBalancer.LoadBalancingRules[0].IdleTimeoutInMinutes);
                Assert.Equal(probeName, getLoadBalancer.LoadBalancer.Probes[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.Probes[0].ProvisioningState);
                Assert.Equal(getLoadBalancer.LoadBalancer.Probes[0].Id, getLoadBalancer.LoadBalancer.LoadBalancingRules[0].Probe.Id);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.InboundNatRules[0].ProvisioningState);
                Assert.Equal(inboundNatRule1Name, getLoadBalancer.LoadBalancer.InboundNatRules[0].Name);
                Assert.Equal("Tcp", getLoadBalancer.LoadBalancer.InboundNatRules[0].Protocol);
                Assert.Equal(3389, getLoadBalancer.LoadBalancer.InboundNatRules[0].FrontendPort);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.InboundNatRules[1].ProvisioningState);
                Assert.Equal(3390, getLoadBalancer.LoadBalancer.InboundNatRules[1].FrontendPort);
                Assert.Equal(15, getLoadBalancer.LoadBalancer.InboundNatRules[1].IdleTimeoutInMinutes);
                Assert.NotNull(getLoadBalancer.LoadBalancer.ResourceGuid);
                
                // Verify List LoadBalancer
                var listLoadBalancer = networkResourceProviderClient.LoadBalancers.List(resourceGroupName);
                Assert.Equal(1, listLoadBalancer.LoadBalancers.Count);
                Assert.Equal(lbName, listLoadBalancer.LoadBalancers[0].Name);
                Assert.Equal(getLoadBalancer.LoadBalancer.Etag, listLoadBalancer.LoadBalancers[0].Etag);

                // Verify List LoadBalancer subscription
                var listLoadBalancerSubscription = networkResourceProviderClient.LoadBalancers.ListAll();
                Assert.Equal(1, listLoadBalancerSubscription.LoadBalancers.Count);
                Assert.Equal(lbName, listLoadBalancerSubscription.LoadBalancers[0].Name);
                Assert.Equal(listLoadBalancerSubscription.LoadBalancers[0].Etag, listLoadBalancer.LoadBalancers[0].Etag);

                // Delete LoadBalancer
                var deleteLoadBalancer = networkResourceProviderClient.LoadBalancers.Delete(resourceGroupName, lbName);

                // Verify Delete
                listLoadBalancer = networkResourceProviderClient.LoadBalancers.List(resourceGroupName);
                Assert.Equal(0, listLoadBalancer.LoadBalancers.Count);

                // Delete all PublicIpAddresses
                var deletePublicIpAddress3Response = networkResourceProviderClient.PublicIpAddresses.Delete(resourceGroupName, lbPublicIpName);
                Assert.Equal(HttpStatusCode.OK, deletePublicIpAddress3Response.StatusCode);
            }
        }

        [Fact]
        public void LoadBalancerApiTestWithDynamicIp()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(handler);
                var networkResourceProviderClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);

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
                    networkResourceProviderClient);
                
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
                    Name = lbName,
                    Location = location,
                    FrontendIpConfigurations = new List<FrontendIpConfiguration>()
                    {
                        new FrontendIpConfiguration()
                        {
                            Name = frontendIpConfigName,
                            PrivateIpAllocationMethod = IpAllocationMethod.Dynamic,
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
                            FrontendIPConfiguration = new ResourceId()
                                {
                                    Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 80,
                            BackendPort = 80,
                            EnableFloatingIP = false,
                            IdleTimeoutInMinutes = 15,
                            BackendAddressPool = new ResourceId()
                            {
                                Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, lbName, "backendAddressPools", backEndAddressPoolName)
                            },
                            Probe = new ResourceId()
                            {
                                Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId, 
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
                            FrontendIPConfiguration = new ResourceId()
                                {
                                    Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
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
                            FrontendIPConfiguration = new ResourceId()
                                {
                                    Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
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
                var putLoadBalancer = networkResourceProviderClient.LoadBalancers.CreateOrUpdate(resourceGroupName, lbName, loadbalancerparamater);
                Assert.Equal(HttpStatusCode.OK, putLoadBalancer.StatusCode);

                var getLoadBalancer = networkResourceProviderClient.LoadBalancers.Get(resourceGroupName, lbName);

                // Verify the GET LoadBalancer
                Assert.Equal(lbName, getLoadBalancer.LoadBalancer.Name);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.ProvisioningState);
                Assert.Equal(frontendIpConfigName, getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].ProvisioningState);
                Assert.Equal(vnet.Subnets[0].Id, getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].Subnet.Id);
                Assert.NotNull(getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].PrivateIpAddress);
                Assert.Equal(getLoadBalancer.LoadBalancer.InboundNatRules[0].Id, getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].InboundNatRules[0].Id);
                Assert.Equal(getLoadBalancer.LoadBalancer.InboundNatRules[1].Id, getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].InboundNatRules[1].Id);
                Assert.Equal(backEndAddressPoolName, getLoadBalancer.LoadBalancer.BackendAddressPools[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.BackendAddressPools[0].ProvisioningState);
                Assert.Equal(getLoadBalancer.LoadBalancer.LoadBalancingRules[0].Id, getLoadBalancer.LoadBalancer.BackendAddressPools[0].LoadBalancingRules[0].Id);
                Assert.Equal(loadBalancingRuleName, getLoadBalancer.LoadBalancer.LoadBalancingRules[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.LoadBalancingRules[0].ProvisioningState);
                Assert.Equal(probeName, getLoadBalancer.LoadBalancer.Probes[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.Probes[0].ProvisioningState);
                Assert.Equal(getLoadBalancer.LoadBalancer.Probes[0].Id, getLoadBalancer.LoadBalancer.LoadBalancingRules[0].Probe.Id);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.InboundNatRules[0].ProvisioningState);
                Assert.Equal(inboundNatRule1Name, getLoadBalancer.LoadBalancer.InboundNatRules[0].Name);
                Assert.Equal("Tcp", getLoadBalancer.LoadBalancer.InboundNatRules[0].Protocol);
                Assert.Equal(3389, getLoadBalancer.LoadBalancer.InboundNatRules[0].FrontendPort);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.InboundNatRules[1].ProvisioningState);
                Assert.Equal(3390, getLoadBalancer.LoadBalancer.InboundNatRules[1].FrontendPort);

                // Verify List LoadBalancer
                var listLoadBalancer = networkResourceProviderClient.LoadBalancers.List(resourceGroupName);
                Assert.Equal(1, listLoadBalancer.LoadBalancers.Count);
                Assert.Equal(lbName, listLoadBalancer.LoadBalancers[0].Name);
                Assert.Equal(getLoadBalancer.LoadBalancer.Etag, listLoadBalancer.LoadBalancers[0].Etag);

                // Verify List LoadBalancer subscription
                var listLoadBalancerSubscription = networkResourceProviderClient.LoadBalancers.ListAll();
                Assert.Equal(1, listLoadBalancerSubscription.LoadBalancers.Count);
                Assert.Equal(lbName, listLoadBalancerSubscription.LoadBalancers[0].Name);
                Assert.Equal(listLoadBalancerSubscription.LoadBalancers[0].Etag, listLoadBalancer.LoadBalancers[0].Etag);

                // Delete LoadBalancer
                var deleteLoadBalancer = networkResourceProviderClient.LoadBalancers.Delete(resourceGroupName, lbName);

                // Verify Delete
                listLoadBalancer = networkResourceProviderClient.LoadBalancers.List(resourceGroupName);
                Assert.Equal(0, listLoadBalancer.LoadBalancers.Count);

                // Delete VirtualNetwork
                var deleteVnetResponse = networkResourceProviderClient.VirtualNetworks.Delete(resourceGroupName, vnetName);
                Assert.Equal(HttpStatusCode.OK, deleteVnetResponse.StatusCode);
            }
        }

        [Fact]
        public void LoadBalancerApiTestWithStaticIp()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(handler);
                var networkResourceProviderClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);

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
                    networkResourceProviderClient);

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
                    Name = lbName,
                    Location = location,
                    FrontendIpConfigurations = new List<FrontendIpConfiguration>()
                    {
                        new FrontendIpConfiguration()
                        {
                            Name = frontendIpConfigName,
                            PrivateIpAllocationMethod = IpAllocationMethod.Static,
                            PrivateIpAddress = "10.0.0.38",
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
                            FrontendIPConfiguration = new ResourceId()
                                {
                                    Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 80,
                            BackendPort = 80,
                            EnableFloatingIP = false,
                            BackendAddressPool = new ResourceId()
                            {
                                Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, lbName, "backendAddressPools", backEndAddressPoolName)
                            },
                            Probe = new ResourceId()
                            {
                                Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId, 
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
                            FrontendIPConfiguration = new ResourceId()
                                {
                                    Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
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
                            FrontendIPConfiguration = new ResourceId()
                                {
                                    Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
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
                var putLoadBalancer = networkResourceProviderClient.LoadBalancers.CreateOrUpdate(resourceGroupName, lbName, loadbalancerparamater);
                Assert.Equal(HttpStatusCode.OK, putLoadBalancer.StatusCode);

                var getLoadBalancer = networkResourceProviderClient.LoadBalancers.Get(resourceGroupName, lbName);

                // Verify the GET LoadBalancer
                Assert.Equal(lbName, getLoadBalancer.LoadBalancer.Name);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.ProvisioningState);
                Assert.Equal(frontendIpConfigName, getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].ProvisioningState);
                Assert.Equal(vnet.Subnets[0].Id, getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].Subnet.Id);
                Assert.NotNull(getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].PrivateIpAddress);
                Assert.Equal("10.0.0.38", getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].PrivateIpAddress);
                Assert.Equal(getLoadBalancer.LoadBalancer.InboundNatRules[0].Id, getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].InboundNatRules[0].Id);
                Assert.Equal(getLoadBalancer.LoadBalancer.InboundNatRules[1].Id, getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].InboundNatRules[1].Id);
                Assert.Equal(backEndAddressPoolName, getLoadBalancer.LoadBalancer.BackendAddressPools[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.BackendAddressPools[0].ProvisioningState);
                Assert.Equal(getLoadBalancer.LoadBalancer.LoadBalancingRules[0].Id, getLoadBalancer.LoadBalancer.BackendAddressPools[0].LoadBalancingRules[0].Id);
                Assert.Equal(loadBalancingRuleName, getLoadBalancer.LoadBalancer.LoadBalancingRules[0].Name);
                Assert.Equal(LoadDistribution.Default, getLoadBalancer.LoadBalancer.LoadBalancingRules[0].LoadDistribution);
                Assert.Equal(4, getLoadBalancer.LoadBalancer.LoadBalancingRules[0].IdleTimeoutInMinutes);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.LoadBalancingRules[0].ProvisioningState);
                Assert.Equal(probeName, getLoadBalancer.LoadBalancer.Probes[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.Probes[0].ProvisioningState);
                Assert.Equal(getLoadBalancer.LoadBalancer.Probes[0].Id, getLoadBalancer.LoadBalancer.LoadBalancingRules[0].Probe.Id);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.InboundNatRules[0].ProvisioningState);
                Assert.Equal(inboundNatRule1Name, getLoadBalancer.LoadBalancer.InboundNatRules[0].Name);
                Assert.Equal("Tcp", getLoadBalancer.LoadBalancer.InboundNatRules[0].Protocol);
                Assert.Equal(3389, getLoadBalancer.LoadBalancer.InboundNatRules[0].FrontendPort);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.InboundNatRules[1].ProvisioningState);
                Assert.Equal(3390, getLoadBalancer.LoadBalancer.InboundNatRules[1].FrontendPort);
                Assert.Equal(4, getLoadBalancer.LoadBalancer.InboundNatRules[1].IdleTimeoutInMinutes);

                // Verify List LoadBalancer
                var listLoadBalancer = networkResourceProviderClient.LoadBalancers.List(resourceGroupName);
                Assert.Equal(1, listLoadBalancer.LoadBalancers.Count);
                Assert.Equal(lbName, listLoadBalancer.LoadBalancers[0].Name);
                Assert.Equal(getLoadBalancer.LoadBalancer.Etag, listLoadBalancer.LoadBalancers[0].Etag);

                // Verify List LoadBalancer subscription
                var listLoadBalancerSubscription = networkResourceProviderClient.LoadBalancers.ListAll();
                Assert.Equal(1, listLoadBalancerSubscription.LoadBalancers.Count);
                Assert.Equal(lbName, listLoadBalancerSubscription.LoadBalancers[0].Name);
                Assert.Equal(listLoadBalancerSubscription.LoadBalancers[0].Etag, listLoadBalancer.LoadBalancers[0].Etag);

                // Delete LoadBalancer
                var deleteLoadBalancer = networkResourceProviderClient.LoadBalancers.Delete(resourceGroupName, lbName);

                // Verify Delete
                listLoadBalancer = networkResourceProviderClient.LoadBalancers.List(resourceGroupName);
                Assert.Equal(0, listLoadBalancer.LoadBalancers.Count);

                // Delete VirtualNetwork
                var deleteVnetResponse = networkResourceProviderClient.VirtualNetworks.Delete(resourceGroupName, vnetName);
                Assert.Equal(HttpStatusCode.OK, deleteVnetResponse.StatusCode);
            }
        }

        [Fact]
        public void LoadBalancerApiTestWithDistributionPolicy()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(handler);
                var networkResourceProviderClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);

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
                    networkResourceProviderClient);

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
                    Name = lbName,
                    Location = location,
                    FrontendIpConfigurations = new List<FrontendIpConfiguration>()
                    {
                        new FrontendIpConfiguration()
                        {
                            Name = frontendIpConfigName,
                            PrivateIpAllocationMethod = IpAllocationMethod.Static,
                            PrivateIpAddress = "10.0.0.38",
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
                            FrontendIPConfiguration = new ResourceId()
                                {
                                    Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 80,
                            BackendPort = 80,
                            EnableFloatingIP = false,
                            BackendAddressPool = new ResourceId()
                            {
                                Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, lbName, "backendAddressPools", backEndAddressPoolName)
                            },
                            Probe = new ResourceId()
                            {
                                Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId, 
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
                            FrontendIPConfiguration = new ResourceId()
                                {
                                    Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
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
                            FrontendIPConfiguration = new ResourceId()
                                {
                                    Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
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
                var putLoadBalancer = networkResourceProviderClient.LoadBalancers.CreateOrUpdate(resourceGroupName, lbName, loadbalancerparamater);
                Assert.Equal(HttpStatusCode.OK, putLoadBalancer.StatusCode);

                var getLoadBalancer = networkResourceProviderClient.LoadBalancers.Get(resourceGroupName, lbName);

                // Verify the GET LoadBalancer
                Assert.Equal(lbName, getLoadBalancer.LoadBalancer.Name);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.ProvisioningState);
                Assert.Equal(frontendIpConfigName, getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].ProvisioningState);
                Assert.Equal(vnet.Subnets[0].Id, getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].Subnet.Id);
                Assert.NotNull(getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].PrivateIpAddress);
                Assert.Equal("10.0.0.38", getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].PrivateIpAddress);
                Assert.Equal(getLoadBalancer.LoadBalancer.InboundNatRules[0].Id, getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].InboundNatRules[0].Id);
                Assert.Equal(getLoadBalancer.LoadBalancer.InboundNatRules[1].Id, getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].InboundNatRules[1].Id);
                Assert.Equal(backEndAddressPoolName, getLoadBalancer.LoadBalancer.BackendAddressPools[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.BackendAddressPools[0].ProvisioningState);
                Assert.Equal(getLoadBalancer.LoadBalancer.LoadBalancingRules[0].Id, getLoadBalancer.LoadBalancer.BackendAddressPools[0].LoadBalancingRules[0].Id);
                Assert.Equal(loadBalancingRuleName, getLoadBalancer.LoadBalancer.LoadBalancingRules[0].Name);
                Assert.Equal(LoadDistribution.Default, getLoadBalancer.LoadBalancer.LoadBalancingRules[0].LoadDistribution);
                Assert.Equal(4, getLoadBalancer.LoadBalancer.LoadBalancingRules[0].IdleTimeoutInMinutes);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.LoadBalancingRules[0].ProvisioningState);
                Assert.Equal(probeName, getLoadBalancer.LoadBalancer.Probes[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.Probes[0].ProvisioningState);
                Assert.Equal(getLoadBalancer.LoadBalancer.Probes[0].Id, getLoadBalancer.LoadBalancer.LoadBalancingRules[0].Probe.Id);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.InboundNatRules[0].ProvisioningState);
                Assert.Equal(inboundNatRule1Name, getLoadBalancer.LoadBalancer.InboundNatRules[0].Name);
                Assert.Equal("Tcp", getLoadBalancer.LoadBalancer.InboundNatRules[0].Protocol);
                Assert.Equal(3389, getLoadBalancer.LoadBalancer.InboundNatRules[0].FrontendPort);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.InboundNatRules[1].ProvisioningState);
                Assert.Equal(3390, getLoadBalancer.LoadBalancer.InboundNatRules[1].FrontendPort);
                Assert.Equal(4, getLoadBalancer.LoadBalancer.InboundNatRules[1].IdleTimeoutInMinutes);

                // Verify List LoadBalancer
                var listLoadBalancer = networkResourceProviderClient.LoadBalancers.List(resourceGroupName);
                Assert.Equal(1, listLoadBalancer.LoadBalancers.Count);
                Assert.Equal(lbName, listLoadBalancer.LoadBalancers[0].Name);
                Assert.Equal(getLoadBalancer.LoadBalancer.Etag, listLoadBalancer.LoadBalancers[0].Etag);

                // Do another put after changing the distribution policy
                loadbalancerparamater.LoadBalancingRules[0].LoadDistribution = LoadDistribution.SourceIP;
                putLoadBalancer = networkResourceProviderClient.LoadBalancers.CreateOrUpdate(resourceGroupName, lbName, loadbalancerparamater);
                getLoadBalancer = networkResourceProviderClient.LoadBalancers.Get(resourceGroupName, lbName);
                Assert.Equal(HttpStatusCode.OK, putLoadBalancer.StatusCode);

                Assert.Equal(LoadDistribution.SourceIP, getLoadBalancer.LoadBalancer.LoadBalancingRules[0].LoadDistribution);

                loadbalancerparamater.LoadBalancingRules[0].LoadDistribution = LoadDistribution.SourceIPProtocol;
                putLoadBalancer = networkResourceProviderClient.LoadBalancers.CreateOrUpdate(resourceGroupName, lbName, loadbalancerparamater);
                getLoadBalancer = networkResourceProviderClient.LoadBalancers.Get(resourceGroupName, lbName);
                Assert.Equal(HttpStatusCode.OK, putLoadBalancer.StatusCode);

                Assert.Equal(LoadDistribution.SourceIPProtocol, getLoadBalancer.LoadBalancer.LoadBalancingRules[0].LoadDistribution);

                // Delete LoadBalancer
                var deleteLoadBalancer = networkResourceProviderClient.LoadBalancers.Delete(resourceGroupName, lbName);

                // Verify Delete
                listLoadBalancer = networkResourceProviderClient.LoadBalancers.List(resourceGroupName);
                Assert.Equal(0, listLoadBalancer.LoadBalancers.Count);

                // Delete VirtualNetwork
                var deleteVnetResponse = networkResourceProviderClient.VirtualNetworks.Delete(resourceGroupName, vnetName);
                Assert.Equal(HttpStatusCode.OK, deleteVnetResponse.StatusCode);
            }
        }

        [Fact]
        public void CreateEmptyLoadBalancer()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(handler);
                var networkResourceProviderClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);

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
                    Name = lbname,
                    Location = location,
                };

                // Create the loadBalancer
                var putLoadBalancer = networkResourceProviderClient.LoadBalancers.CreateOrUpdate(resourceGroupName, lbname, loadbalancerparamater);
                Assert.Equal(HttpStatusCode.OK, putLoadBalancer.StatusCode);

                var getLoadBalancer = networkResourceProviderClient.LoadBalancers.Get(resourceGroupName, lbname);

                // Verify the GET LoadBalancer
                Assert.Equal(lbname, getLoadBalancer.LoadBalancer.Name);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.ProvisioningState);
                Assert.False(getLoadBalancer.LoadBalancer.FrontendIpConfigurations.Any());
                Assert.False(getLoadBalancer.LoadBalancer.BackendAddressPools.Any());
                Assert.False(getLoadBalancer.LoadBalancer.LoadBalancingRules.Any());
                Assert.False(getLoadBalancer.LoadBalancer.Probes.Any());
                Assert.False(getLoadBalancer.LoadBalancer.InboundNatRules.Any());

                // Delete LoadBalancer
                var deleteLoadBalancer = networkResourceProviderClient.LoadBalancers.Delete(resourceGroupName, lbname);

                // Verify Delete
                var listLoadBalancer = networkResourceProviderClient.LoadBalancers.List(resourceGroupName);
                Assert.Equal(0, listLoadBalancer.LoadBalancers.Count);
            }
        }

        [Fact]
        public void UpdateLoadBalancerRule()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(handler);
                var networkResourceProviderClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);

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
                    networkResourceProviderClient);

                // Create the LoadBalancer with an lb rule and no probe
                var lbname = TestUtilities.GenerateName();
                var frontendIpConfigName = TestUtilities.GenerateName();
                var backEndAddressPoolName = TestUtilities.GenerateName();
                var loadBalancingRuleName = TestUtilities.GenerateName();
                var probeName = TestUtilities.GenerateName();

                // Populate the loadBalancerCreateOrUpdateParameter
                var loadbalancerparamater = new LoadBalancer()
                {
                    Name = lbname,
                    Location = location,
                    FrontendIpConfigurations = new List<FrontendIpConfiguration>()
                    {
                        new FrontendIpConfiguration()
                        {
                            Name = frontendIpConfigName,
                            PrivateIpAllocationMethod = IpAllocationMethod.Static,
                            PrivateIpAddress = "10.0.0.38",
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
                            FrontendIPConfiguration = new ResourceId()
                                {
                                    Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, lbname, "frontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 80,
                            BackendPort = 80,
                            EnableFloatingIP = false,
                            BackendAddressPool = new ResourceId()
                            {
                                Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, lbname, "backendAddressPools", backEndAddressPoolName)
                            }
                        }
                    },
                };

                // Create the loadBalancer
                var putLoadBalancer = networkResourceProviderClient.LoadBalancers.CreateOrUpdate(resourceGroupName, lbname, loadbalancerparamater);
                Assert.Equal(HttpStatusCode.OK, putLoadBalancer.StatusCode);

                var getLoadBalancer = networkResourceProviderClient.LoadBalancers.Get(resourceGroupName, lbname);

                // Verify the GET LoadBalancer
                Assert.Equal(lbname, getLoadBalancer.LoadBalancer.Name);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.ProvisioningState);
                Assert.Equal(1, getLoadBalancer.LoadBalancer.FrontendIpConfigurations.Count);
                Assert.Equal(1, getLoadBalancer.LoadBalancer.BackendAddressPools.Count);
                Assert.Equal(1, getLoadBalancer.LoadBalancer.LoadBalancingRules.Count);
                Assert.False(getLoadBalancer.LoadBalancer.Probes.Any());
                Assert.False(getLoadBalancer.LoadBalancer.InboundNatRules.Any());

                // Add a Probe to the lb rule
                getLoadBalancer.LoadBalancer.Probes = new List<Probe>()
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

                getLoadBalancer.LoadBalancer.LoadBalancingRules[0].Probe = new ResourceId()
                                                                               {
                                                                                   Id =
                                                                                       GetChildLbResourceId(
                                                                                           networkResourceProviderClient.Credentials.SubscriptionId,
                                                                                           resourceGroupName,
                                                                                           lbname,
                                                                                           "probes",
                                                                                           probeName)
                                                                               };

                // update load balancer
                putLoadBalancer = networkResourceProviderClient.LoadBalancers.CreateOrUpdate(resourceGroupName, lbname, getLoadBalancer.LoadBalancer);
                Assert.Equal(HttpStatusCode.OK, putLoadBalancer.StatusCode);

                getLoadBalancer = networkResourceProviderClient.LoadBalancers.Get(resourceGroupName, lbname);

                // Verify the GET LoadBalancer
                Assert.Equal(lbname, getLoadBalancer.LoadBalancer.Name);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.ProvisioningState);
                Assert.Equal(1, getLoadBalancer.LoadBalancer.FrontendIpConfigurations.Count);
                Assert.Equal(1, getLoadBalancer.LoadBalancer.BackendAddressPools.Count);
                Assert.Equal(1, getLoadBalancer.LoadBalancer.LoadBalancingRules.Count);
                Assert.Equal(1, getLoadBalancer.LoadBalancer.Probes.Count);
                Assert.Equal(getLoadBalancer.LoadBalancer.Probes[0].Id, getLoadBalancer.LoadBalancer.LoadBalancingRules[0].Probe.Id);
                Assert.False(getLoadBalancer.LoadBalancer.InboundNatRules.Any());

                // Delete LoadBalancer
                var deleteLoadBalancer = networkResourceProviderClient.LoadBalancers.Delete(resourceGroupName, lbname);

                // Verify Delete
                var listLoadBalancer = networkResourceProviderClient.LoadBalancers.List(resourceGroupName);
                Assert.Equal(0, listLoadBalancer.LoadBalancers.Count);

                // Delete VirtualNetwork
                var deleteVnetResponse = networkResourceProviderClient.VirtualNetworks.Delete(resourceGroupName, vnetName);
                Assert.Equal(HttpStatusCode.OK, deleteVnetResponse.StatusCode);
            }
        }
        
        [Fact]
        public void LoadBalancerApiNicAssociationTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(handler);
                var networkResourceProviderClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);

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
                    networkResourceProviderClient);

                // Create Vnet
                string vnetName = TestUtilities.GenerateName();
                string subnetName = TestUtilities.GenerateName();

                var vnet = TestHelper.CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location,
                    networkResourceProviderClient);

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
                    networkResourceProviderClient);

                var nic2 = TestHelper.CreateNetworkInterface(
                    nic2name,
                    resourceGroupName,
                    null,
                    vnet.Subnets[0].Id,
                    location,
                    "ipconfig",
                    networkResourceProviderClient);

                var nic3 = TestHelper.CreateNetworkInterface(
                    nic3name,
                    resourceGroupName,
                    null,
                    vnet.Subnets[0].Id,
                    location,
                    "ipconfig",
                    networkResourceProviderClient);

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
                    Name = lbName,
                    Location = location,
                    FrontendIpConfigurations = new List<FrontendIpConfiguration>()
                    {
                        new FrontendIpConfiguration()
                        {
                            Name = frontendIpConfigName,
                            PublicIpAddress = new ResourceId()
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
                            FrontendIPConfiguration = new ResourceId()
                                {
                                    Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 80,
                            BackendPort = 80,
                            EnableFloatingIP = false,
                            IdleTimeoutInMinutes = 15,
                            BackendAddressPool = new ResourceId()
                            {
                                Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, lbName, "backendAddressPools", backEndAddressPoolName)
                            },
                            Probe = new ResourceId()
                            {
                                Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId, 
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
                            FrontendIPConfiguration = new ResourceId()
                                {
                                    Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
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
                            FrontendIPConfiguration = new ResourceId()
                                {
                                    Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
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
                var putLoadBalancer = networkResourceProviderClient.LoadBalancers.CreateOrUpdate(resourceGroupName, lbName, loadBalancer);
                Assert.Equal(HttpStatusCode.OK, putLoadBalancer.StatusCode);

                var getLoadBalancer = networkResourceProviderClient.LoadBalancers.Get(resourceGroupName, lbName);

                // Associate the nic with LB
                nic1.IpConfigurations.First().LoadBalancerBackendAddressPools = new List<ResourceId>
                                                                                    {
                                                                                        getLoadBalancer.LoadBalancer.BackendAddressPools.First()
                                                                                    };

                nic1.IpConfigurations.First().LoadBalancerInboundNatRules = new List<ResourceId>
                                                                                    {
                                                                                        getLoadBalancer.LoadBalancer.InboundNatRules.First()
                                                                                    };

                nic2.IpConfigurations.First().LoadBalancerBackendAddressPools = new List<ResourceId>
                                                                                    {
                                                                                        getLoadBalancer.LoadBalancer.BackendAddressPools.First()
                                                                                    };

                nic3.IpConfigurations.First().LoadBalancerInboundNatRules = new List<ResourceId>
                                                                                    {
                                                                                        getLoadBalancer.LoadBalancer.InboundNatRules[1]
                                                                                    };

                // Put Nics
                networkResourceProviderClient.NetworkInterfaces.CreateOrUpdate(resourceGroupName, nic1name, nic1);
                networkResourceProviderClient.NetworkInterfaces.CreateOrUpdate(resourceGroupName, nic2name, nic2);
                networkResourceProviderClient.NetworkInterfaces.CreateOrUpdate(resourceGroupName, nic3name, nic3);

                // Get Nics
                nic1 = networkResourceProviderClient.NetworkInterfaces.Get(resourceGroupName, nic1name).NetworkInterface;
                nic2 = networkResourceProviderClient.NetworkInterfaces.Get(resourceGroupName, nic2name).NetworkInterface;
                nic3 = networkResourceProviderClient.NetworkInterfaces.Get(resourceGroupName, nic3name).NetworkInterface;

                // Verify the associations
                getLoadBalancer = networkResourceProviderClient.LoadBalancers.Get(resourceGroupName, lbName);
                Assert.Equal(2, getLoadBalancer.LoadBalancer.BackendAddressPools.First().BackendIpConfigurations.Count);
                Assert.True(getLoadBalancer.LoadBalancer.BackendAddressPools.First().BackendIpConfigurations.Any(ipconfig => string.Equals(ipconfig.Id, nic1.IpConfigurations[0].Id, StringComparison.OrdinalIgnoreCase)));
                Assert.True(getLoadBalancer.LoadBalancer.BackendAddressPools.First().BackendIpConfigurations.Any(ipconfig => string.Equals(ipconfig.Id, nic2.IpConfigurations[0].Id, StringComparison.OrdinalIgnoreCase)));
                Assert.Equal(nic1.IpConfigurations[0].Id, getLoadBalancer.LoadBalancer.InboundNatRules.First().BackendIPConfiguration.Id);
                Assert.Equal(nic3.IpConfigurations[0].Id, getLoadBalancer.LoadBalancer.InboundNatRules[1].BackendIPConfiguration.Id);

                // Delete LoadBalancer
                var deleteLoadBalancer = networkResourceProviderClient.LoadBalancers.Delete(resourceGroupName, lbName);

                // Verify Delete
                var listLoadBalancer = networkResourceProviderClient.LoadBalancers.List(resourceGroupName);
                Assert.Equal(0, listLoadBalancer.LoadBalancers.Count);

                // Delete all NetworkInterfaces
                networkResourceProviderClient.NetworkInterfaces.Delete(resourceGroupName, nic1name);
                networkResourceProviderClient.NetworkInterfaces.Delete(resourceGroupName, nic2name);
                networkResourceProviderClient.NetworkInterfaces.Delete(resourceGroupName, nic3name);

                // Delete all PublicIpAddresses
                var deletePublicIpAddress3Response = networkResourceProviderClient.PublicIpAddresses.Delete(resourceGroupName, lbPublicIpName);
                Assert.Equal(HttpStatusCode.OK, deletePublicIpAddress3Response.StatusCode);
            }
        }

        [Fact]
        public void LoadBalancerNatPoolTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {

                context.Start();
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(handler);
                var networkResourceProviderClient =
                    NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);
                //var location = NetworkManagementTestUtilities.GetResourceLocation(
                //    resourcesClient,
                //    "Microsoft.Network/loadBalancers");
                
                var location = "westus";

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
                    networkResourceProviderClient);

                // Create the LoadBalancer
                var lbName = TestUtilities.GenerateName();
                var frontendIpConfigName = TestUtilities.GenerateName();
                var inboundNatPool1Name = TestUtilities.GenerateName();
                var inboundNatPool2Name = TestUtilities.GenerateName();

                 var loadBalancer = new LoadBalancer()
                {
                    Name = lbName,
                    Location = location,
                    FrontendIpConfigurations = new List<FrontendIpConfiguration>()
                    {
                        new FrontendIpConfiguration()
                        {
                            Name = frontendIpConfigName,
                            PublicIpAddress = new ResourceId()
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
                            FrontendIPConfiguration = new ResourceId()
                                {
                                    Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                        } 
                    }
                };

                // Create the loadBalancer
                var putLoadBalancer = networkResourceProviderClient.LoadBalancers.CreateOrUpdate(
                    resourceGroupName,
                    lbName,
                    loadBalancer);
                Assert.Equal(HttpStatusCode.OK, putLoadBalancer.StatusCode);

                var getLoadBalancer = networkResourceProviderClient.LoadBalancers.Get(resourceGroupName, lbName);

                // Verify the GET LoadBalancer
                Assert.Equal(lbName, getLoadBalancer.LoadBalancer.Name);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.ProvisioningState);
                Assert.Equal(frontendIpConfigName, getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].ProvisioningState);

                // Verify the nat pool
                Assert.Equal(1, getLoadBalancer.LoadBalancer.InboundNatPools.Count);
                Assert.Equal(inboundNatPool1Name, getLoadBalancer.LoadBalancer.InboundNatPools[0].Name);
                Assert.Equal(81, getLoadBalancer.LoadBalancer.InboundNatPools[0].BackendPort);
                Assert.Equal(100, getLoadBalancer.LoadBalancer.InboundNatPools[0].FrontendPortRangeStart);
                Assert.Equal(105, getLoadBalancer.LoadBalancer.InboundNatPools[0].FrontendPortRangeEnd);
                Assert.Equal(TransportProtocol.Tcp, getLoadBalancer.LoadBalancer.InboundNatPools[0].Protocol);
                Assert.Equal(GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName), getLoadBalancer.LoadBalancer.InboundNatPools[0].FrontendIPConfiguration.Id);

                Assert.Equal(getLoadBalancer.LoadBalancer.InboundNatPools[0].Id, getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].InboundNatPools[0].Id);

                // Add a new nat pool
                var natpool2 = new InboundNatPool()
                        {
                            Name = inboundNatPool2Name,
                            BackendPort = 81,
                            FrontendPortRangeStart = 107,
                            FrontendPortRangeEnd = 110,
                            FrontendIPConfiguration = new ResourceId()
                                {
                                    Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                        };
                getLoadBalancer.LoadBalancer.InboundNatPools.Add(natpool2);

                putLoadBalancer = networkResourceProviderClient.LoadBalancers.CreateOrUpdate(
                   resourceGroupName,
                   lbName,
                   getLoadBalancer.LoadBalancer);

                // Verify the nat pool
                Assert.Equal(2, getLoadBalancer.LoadBalancer.InboundNatPools.Count);

                // Delete LoadBalancer
                var deleteLoadBalancer = networkResourceProviderClient.LoadBalancers.Delete(resourceGroupName, lbName);

                // Verify Delete
                var listLoadBalancer = networkResourceProviderClient.LoadBalancers.List(resourceGroupName);
                Assert.Equal(0, listLoadBalancer.LoadBalancers.Count);

                // Delete all PublicIpAddresses
                var deletePublicIpAddress3Response = networkResourceProviderClient.PublicIpAddresses.Delete(resourceGroupName, lbPublicIpName);
                Assert.Equal(HttpStatusCode.OK, deletePublicIpAddress3Response.StatusCode);
            }
        }

        [Fact]
        public void LoadBalancerOutboundNatRuleTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {

                context.Start();
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(handler);
                var networkResourceProviderClient =
                    NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);
                //var location = NetworkManagementTestUtilities.GetResourceLocation(
                //    resourcesClient,
                //    "Microsoft.Network/loadBalancers");

                var location = "westus";

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
                    networkResourceProviderClient);

                // Create the LoadBalancer
                var lbName = TestUtilities.GenerateName();
                var frontendIpConfigName = TestUtilities.GenerateName();
                var outboundNatPool1Name = TestUtilities.GenerateName();
                var backendaddresspoolName = TestUtilities.GenerateName();
                var inboundNatRule1Name = TestUtilities.GenerateName();

                var loadBalancer = new LoadBalancer()
                {
                    Name = lbName,
                    Location = location,
                    FrontendIpConfigurations = new List<FrontendIpConfiguration>()
                    {
                        new FrontendIpConfiguration()
                        {
                            Name = frontendIpConfigName,
                            PublicIpAddress = new ResourceId()
                            {
                                Id = lbPublicIp.Id
                            }
                        }
                    },
                    BackendAddressPools = new List<BackendAddressPool>()
                    {
                        new BackendAddressPool()
                            {
                                Name = backendaddresspoolName
                            }
                    },
                    OutboundNatRules = new List<OutboundNatRule>()
                    {
                       new OutboundNatRule()
                        {
                            Name = outboundNatPool1Name,
                            AllocatedOutboundPorts = 1000,
                            BackendAddressPool = new ResourceId()
                                {
                                    Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, lbName, "backendAddressPools", backendaddresspoolName)
                                },
                            FrontendIpConfigurations = new List<ResourceId>()
                            {
                                new ResourceId()
                                {
                                    Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                                },
                            }
                        } 
                    },
                    InboundNatRules = new List<InboundNatRule>()
                    {
                        new InboundNatRule()
                        {
                            Name = inboundNatRule1Name,
                            FrontendIPConfiguration = new ResourceId()
                                {
                                    Id = GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 3389,
                            BackendPort = 3389,
                            IdleTimeoutInMinutes = 15,
                            EnableFloatingIP = false
                        },
                    }
                };

                // Create the loadBalancer
                var putLoadBalancer = networkResourceProviderClient.LoadBalancers.CreateOrUpdate(
                    resourceGroupName,
                    lbName,
                    loadBalancer);
                Assert.Equal(HttpStatusCode.OK, putLoadBalancer.StatusCode);

                var getLoadBalancer = networkResourceProviderClient.LoadBalancers.Get(resourceGroupName, lbName);

                // Verify the GET LoadBalancer
                Assert.Equal(lbName, getLoadBalancer.LoadBalancer.Name);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.ProvisioningState);
                Assert.Equal(frontendIpConfigName, getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].Name);
                Assert.Equal("Succeeded", getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].ProvisioningState);

                // Verify the nat pool
                Assert.Equal(1, getLoadBalancer.LoadBalancer.OutboundNatRules.Count);
                Assert.Equal(outboundNatPool1Name, getLoadBalancer.LoadBalancer.OutboundNatRules[0].Name);
                Assert.Equal(1000, getLoadBalancer.LoadBalancer.OutboundNatRules[0].AllocatedOutboundPorts);
                Assert.Equal(GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, lbName, "backendAddressPools", backendaddresspoolName), getLoadBalancer.LoadBalancer.OutboundNatRules[0].BackendAddressPool.Id);
                Assert.Equal(1, getLoadBalancer.LoadBalancer.OutboundNatRules[0].FrontendIpConfigurations.Count);
                Assert.Equal(GetChildLbResourceId(networkResourceProviderClient.Credentials.SubscriptionId,
                                    resourceGroupName, lbName, "frontendIPConfigurations", frontendIpConfigName), getLoadBalancer.LoadBalancer.OutboundNatRules[0].FrontendIpConfigurations[0].Id);

                Assert.Equal(getLoadBalancer.LoadBalancer.OutboundNatRules[0].Id, getLoadBalancer.LoadBalancer.FrontendIpConfigurations[0].OutboundNatRules[0].Id);
                Assert.Equal(getLoadBalancer.LoadBalancer.OutboundNatRules[0].Id, getLoadBalancer.LoadBalancer.BackendAddressPools[0].OutboundNatRule.Id);

                // Delete LoadBalancer
                var deleteLoadBalancer = networkResourceProviderClient.LoadBalancers.Delete(resourceGroupName, lbName);

                // Verify Delete
                var listLoadBalancer = networkResourceProviderClient.LoadBalancers.List(resourceGroupName);
                Assert.Equal(0, listLoadBalancer.LoadBalancers.Count);

                // Delete all PublicIpAddresses
                var deletePublicIpAddress3Response = networkResourceProviderClient.PublicIpAddresses.Delete(resourceGroupName, lbPublicIpName);
                Assert.Equal(HttpStatusCode.OK, deletePublicIpAddress3Response.StatusCode);
            }
        }

        private static string GetChildLbResourceId(
            string subscriptionId,
            string resourceGroupName,
            string lbname,
            string childResourceType,
            string childResourceName)
        {
            return
                string.Format(
                    "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/loadBalancers/{2}/{3}/{4}",
                    subscriptionId,
                    resourceGroupName,
                    lbname,
                    childResourceType,
                    childResourceName);
        }
    }
}