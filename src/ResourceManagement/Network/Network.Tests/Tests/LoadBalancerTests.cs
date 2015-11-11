using System.Collections.Generic;
using System.Net;
using Microsoft.Rest.Azure;
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

    public class LoadBalancerTests
    {
        [Fact]
        public void LoadBalancerApiTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start())
            {
                
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(context, handler);
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
                            FrontendIPConfiguration = new Microsoft.Azure.Management.Network.Models.SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "FrontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 80,
                            BackendPort = 80,
                            EnableFloatingIP = false,
                            IdleTimeoutInMinutes = 15,
                            BackendAddressPool = new Microsoft.Azure.Management.Network.Models.SubResource()
                            {
                                Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "backendAddressPools", backEndAddressPoolName)
                            },
                            Probe = new Microsoft.Azure.Management.Network.Models.SubResource()
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
                            FrontendIPConfiguration = new Microsoft.Azure.Management.Network.Models.SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "FrontendIPConfigurations", frontendIpConfigName)
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
                            FrontendIPConfiguration = new Microsoft.Azure.Management.Network.Models.SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "FrontendIPConfigurations", frontendIpConfigName)
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
                Assert.Equal(TransportProtocol.Tcp, getLoadBalancer.InboundNatRules[0].Protocol);
                Assert.Equal(3389, getLoadBalancer.InboundNatRules[0].FrontendPort);
                Assert.Equal("Succeeded", getLoadBalancer.InboundNatRules[1].ProvisioningState);
                Assert.Equal(3390, getLoadBalancer.InboundNatRules[1].FrontendPort);
                Assert.Equal(15, getLoadBalancer.InboundNatRules[1].IdleTimeoutInMinutes);
                
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

                // Delete all PublicIPAddresses
                networkManagementClient.PublicIPAddresses.Delete(resourceGroupName, lbPublicIpName);
            }
        }

        [Fact]
        public void LoadBalancerApiTestWithDynamicIp()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start())
            {
                
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(context, handler);

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
                            FrontendIPConfiguration = new Microsoft.Azure.Management.Network.Models.SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "FrontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 80,
                            BackendPort = 80,
                            EnableFloatingIP = false,
                            IdleTimeoutInMinutes = 15,
                            BackendAddressPool = new Microsoft.Azure.Management.Network.Models.SubResource()
                            {
                                Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "backendAddressPools", backEndAddressPoolName)
                            },
                            Probe = new Microsoft.Azure.Management.Network.Models.SubResource()
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
                            FrontendIPConfiguration = new Microsoft.Azure.Management.Network.Models.SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "FrontendIPConfigurations", frontendIpConfigName)
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
                            FrontendIPConfiguration = new Microsoft.Azure.Management.Network.Models.SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "FrontendIPConfigurations", frontendIpConfigName)
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
                Assert.Equal(TransportProtocol.Tcp, getLoadBalancer.InboundNatRules[0].Protocol);
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

        [Fact]
        public void LoadBalancerApiTestWithStaticIp()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start())
            {
                
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(context, handler);

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
                            FrontendIPConfiguration = new Microsoft.Azure.Management.Network.Models.SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "FrontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 80,
                            BackendPort = 80,
                            EnableFloatingIP = false,
                            BackendAddressPool = new Microsoft.Azure.Management.Network.Models.SubResource()
                            {
                                Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "backendAddressPools", backEndAddressPoolName)
                            },
                            Probe = new Microsoft.Azure.Management.Network.Models.SubResource()
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
                            FrontendIPConfiguration = new Microsoft.Azure.Management.Network.Models.SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "FrontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 3389,
                            BackendPort = 3389,
                            EnableFloatingIP = false,
                        },
                        new InboundNatRule()
                        {
                            Name = inboundNatRule2Name,
                            FrontendIPConfiguration = new Microsoft.Azure.Management.Network.Models.SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "FrontendIPConfigurations", frontendIpConfigName)
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
                Assert.Equal(TransportProtocol.Tcp, getLoadBalancer.InboundNatRules[0].Protocol);
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

        [Fact]
        public void LoadBalancerApiTestWithDistributionPolicy()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start())
            {
                
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(context, handler);

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
                            FrontendIPConfiguration = new Microsoft.Azure.Management.Network.Models.SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "FrontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 80,
                            BackendPort = 80,
                            EnableFloatingIP = false,
                            BackendAddressPool = new Microsoft.Azure.Management.Network.Models.SubResource()
                            {
                                Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "backendAddressPools", backEndAddressPoolName)
                            },
                            Probe = new Microsoft.Azure.Management.Network.Models.SubResource()
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
                            FrontendIPConfiguration = new Microsoft.Azure.Management.Network.Models.SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "FrontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 3389,
                            BackendPort = 3389,
                            EnableFloatingIP = false,
                        },
                        new InboundNatRule()
                        {
                            Name = inboundNatRule2Name,
                            FrontendIPConfiguration = new Microsoft.Azure.Management.Network.Models.SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "FrontendIPConfigurations", frontendIpConfigName)
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
                Assert.Equal(TransportProtocol.Tcp, getLoadBalancer.InboundNatRules[0].Protocol);
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

        [Fact]
        public void CreateEmptyLoadBalancer()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start())
            {
                
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(context, handler);

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
                Assert.Equal(0, getLoadBalancer.FrontendIPConfigurations.Count);
                Assert.Equal(0, getLoadBalancer.BackendAddressPools.Count);
                Assert.Equal(0, getLoadBalancer.LoadBalancingRules.Count);
                Assert.Equal(0, getLoadBalancer.Probes.Count);
                Assert.Equal(0, getLoadBalancer.InboundNatRules.Count);

                // Delete LoadBalancer
                networkManagementClient.LoadBalancers.Delete(resourceGroupName, lbname);

                // Verify Delete
                var listLoadBalancer = networkManagementClient.LoadBalancers.List(resourceGroupName);

                Assert.NotNull(listLoadBalancer);

                Assert.Equal(0, listLoadBalancer.Count());
                Assert.True(string.IsNullOrEmpty(listLoadBalancer.NextPageLink));
            }
        }

        [Fact]
        public void UpdateLoadBalancerRule()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start())
            {
                
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(context, handler);

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
                            FrontendIPConfiguration = new Microsoft.Azure.Management.Network.Models.SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbname, "FrontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 80,
                            BackendPort = 80,
                            EnableFloatingIP = false,
                            BackendAddressPool = new Microsoft.Azure.Management.Network.Models.SubResource()
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

                getLoadBalancer.LoadBalancingRules[0].Probe = new Microsoft.Azure.Management.Network.Models.SubResource()
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
                networkManagementClient.LoadBalancers.CreateOrUpdate(resourceGroupName, lbname, getLoadBalancer);

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

        [Fact]
        public void LoadBalancerApiNicAssociationTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start())
            {
                
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(context, handler);

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
                            FrontendIPConfiguration = new Microsoft.Azure.Management.Network.Models.SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "FrontendIPConfigurations", frontendIpConfigName)
                                },
                            Protocol = TransportProtocol.Tcp,
                            FrontendPort = 80,
                            BackendPort = 80,
                            EnableFloatingIP = false,
                            IdleTimeoutInMinutes = 15,
                            BackendAddressPool = new Microsoft.Azure.Management.Network.Models.SubResource()
                            {
                                Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "backendAddressPools", backEndAddressPoolName)
                            },
                            Probe = new Microsoft.Azure.Management.Network.Models.SubResource()
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
                            FrontendIPConfiguration = new Microsoft.Azure.Management.Network.Models.SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "FrontendIPConfigurations", frontendIpConfigName)
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
                            FrontendIPConfiguration = new Microsoft.Azure.Management.Network.Models.SubResource()
                                {
                                    Id = TestHelper.GetChildLbResourceId(networkManagementClient.SubscriptionId,
                                    resourceGroupName, lbName, "FrontendIPConfigurations", frontendIpConfigName)
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
    }
}