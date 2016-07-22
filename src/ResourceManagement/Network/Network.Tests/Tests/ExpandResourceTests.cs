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
    using Microsoft.Azure.Test.HttpRecorder;

    public class ExpandResourceTests
    {
        public ExpandResourceTests()
        {
            HttpMockServer.RecordsDirectory = "SessionRecords";
        }

        [Fact]
        public void ExpandResourceTest()
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

                // Get lb with expanded nics from nat rules
                getLoadBalancer = networkManagementClient.LoadBalancers.Get(resourceGroupName, lbName, "InboundNatRules/backendIPConfiguration");

                foreach (var natRule in getLoadBalancer.InboundNatRules)
                {
                    Assert.NotNull(natRule.BackendIPConfiguration);
                    Assert.NotNull(natRule.BackendIPConfiguration.Id);
                    Assert.NotNull(natRule.BackendIPConfiguration.Name);
                    Assert.NotNull(natRule.BackendIPConfiguration.Etag);
                    Assert.Equal(natRule.Id, natRule.BackendIPConfiguration.LoadBalancerInboundNatRules[0].Id);
                }

                // Get lb with expanded nics from pools
                getLoadBalancer = networkManagementClient.LoadBalancers.Get(resourceGroupName, lbName, "BackendAddressPools/backendIPConfigurations");
                
                foreach (var pool in getLoadBalancer.BackendAddressPools)
                {
                    foreach (var ipconfig in getLoadBalancer.BackendAddressPools.First().BackendIPConfigurations)
                    {
                        Assert.NotNull(ipconfig.Id);
                        Assert.NotNull(ipconfig.Name);
                        Assert.NotNull(ipconfig.Etag);
                        Assert.Equal(pool.Id, ipconfig.LoadBalancerBackendAddressPools[0].Id);
                    }
                }

                // Get lb with expanded publicip
                getLoadBalancer = networkManagementClient.LoadBalancers.Get(resourceGroupName, lbName, "FrontendIPConfigurations/PublicIPAddress");
                foreach (var ipconfig in getLoadBalancer.FrontendIPConfigurations)
                {
                    Assert.NotNull(ipconfig.PublicIPAddress);
                    Assert.NotNull(ipconfig.PublicIPAddress.Id);
                    Assert.NotNull(ipconfig.PublicIPAddress.Name);
                    Assert.NotNull(ipconfig.PublicIPAddress.Etag);
                    Assert.Equal(ipconfig.Id, ipconfig.PublicIPAddress.IpConfiguration.Id);
                }

                // Get NIC with expanded subnet
                nic1 = networkManagementClient.NetworkInterfaces.Get(resourceGroupName, nic1name, "IPConfigurations/Subnet");
                foreach (var ipconfig in nic1.IpConfigurations)
                {
                    Assert.NotNull(ipconfig.Subnet);
                    Assert.NotNull(ipconfig.Subnet.Id);
                    Assert.NotNull(ipconfig.Subnet.Name);
                    Assert.NotNull(ipconfig.Subnet.Etag);
                    Assert.NotEqual(0, ipconfig.Subnet.IpConfigurations.Count());
                }

                // Get subnet with expanded ipconfigurations
                var subnet = networkManagementClient.Subnets.Get(
                    resourceGroupName,
                    vnetName,
                    subnetName,
                    "IPConfigurations");

                foreach (var ipconfig in subnet.IpConfigurations)
                {
                    Assert.NotNull(ipconfig.Name);
                    Assert.NotNull(ipconfig.Id);
                    Assert.NotNull(ipconfig.Etag);
                    Assert.NotNull(ipconfig.PrivateIPAddress);
                }

                // Get publicIPAddress with expanded ipconfigurations
                var publicip = networkManagementClient.PublicIPAddresses.Get(
                    resourceGroupName,
                    lbPublicIpName,
                    "IPConfiguration");

                Assert.NotNull(publicip.IpConfiguration);
                Assert.NotNull(publicip.IpConfiguration.Id);
                Assert.NotNull(publicip.IpConfiguration.Name);
                Assert.NotNull(publicip.IpConfiguration.Etag);
                
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