﻿using System.Collections.Generic;
using System.Linq;
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
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Networks.Tests
{
    public class NetworkInterfaceTests
    {
        [Fact(Skip = "TODO: Autorest")]
        public void NetworkInterfaceApiTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler);
                var networkResourceProviderClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(context, handler);

                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/networkInterfaces");
                
                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                // Create publicIP
                string publicIpName = TestUtilities.GenerateName();
                string domainNameLabel = TestUtilities.GenerateName();
                
                var publicIp = new PublicIpAddress()
                {
                    Location = location,
                    Tags = new Dictionary<string, string>()
                    {
                       {"key","value"}
                    },
                    PublicIPAllocationMethod = IpAllocationMethod.Dynamic,
                    DnsSettings = new PublicIpAddressDnsSettings()
                    {
                       DomainNameLabel = domainNameLabel
                    }
                };

                // Put PublicIPAddress
                var putPublicIpAddressResponse = networkResourceProviderClient.PublicIpAddresses.CreateOrUpdate(resourceGroupName, publicIpName, publicIp);
                Assert.Equal("Succeeded", putPublicIpAddressResponse.ProvisioningState);
                var getPublicIpAddressResponse = networkResourceProviderClient.PublicIpAddresses.Get(resourceGroupName, publicIpName);

                // Create Vnet
                // Populate parameter for Put Vnet
                string vnetName = TestUtilities.GenerateName();
                string subnetName = TestUtilities.GenerateName();

                var vnet = new VirtualNetwork()
                {
                    Location = location,

                    AddressSpace = new AddressSpace()
                    {
                        AddressPrefixes = new List<string>()
                    {
                        "10.0.0.0/16",
                    }
                    },
                    DhcpOptions = new DhcpOptions()
                    {
                        DnsServers = new List<string>()
                    {
                        "10.1.1.1",
                        "10.1.2.4"
                    }
                    },
                    Subnets = new List<Subnet>()
                    {
                        new Subnet()
                        {
                            Name = subnetName,
                            AddressPrefix = "10.0.0.0/24",
                        }
                    }
                };

                var putVnetResponse = networkResourceProviderClient.VirtualNetworks.CreateOrUpdate(resourceGroupName, vnetName, vnet);

                var getSubnetResponse = networkResourceProviderClient.Subnets.Get(resourceGroupName, vnetName, subnetName);

                // Create Nic
                string nicName = TestUtilities.GenerateName();
                string ipConfigName = TestUtilities.GenerateName();

                var nicParameters = new NetworkInterface()
                {
                    Location = location,
                    Tags = new Dictionary<string, string>()
                        {
                           {"key","value"}
                        },
                    IpConfigurations = new List<NetworkInterfaceIpConfiguration>()
                    {
                        new NetworkInterfaceIpConfiguration()
                        {
                             Name = ipConfigName,
                             PrivateIPAllocationMethod = IpAllocationMethod.Dynamic,
                             PublicIPAddress = new Microsoft.Azure.Management.Network.Models.SubResource()
                             {
                                 Id = getPublicIpAddressResponse.Id
                             },
                             Subnet = new Microsoft.Azure.Management.Network.Models.SubResource()
                             {
                                 Id = getSubnetResponse.Id
                             }
                        }
                    }
                };

                // Test NIC apis
                var putNicResponse = networkResourceProviderClient.NetworkInterfaces.CreateOrUpdate(resourceGroupName, nicName, nicParameters);

                var getNicResponse = networkResourceProviderClient.NetworkInterfaces.Get(resourceGroupName, nicName);
                Assert.Equal(getNicResponse.Name, nicName);
                Assert.Equal(getNicResponse.ProvisioningState, "Succeeded");
                Assert.Null(getNicResponse.VirtualMachine);
                Assert.Null(getNicResponse.MacAddress);
                Assert.Equal(1, getNicResponse.IpConfigurations.Count);
                Assert.Equal(ipConfigName, getNicResponse.IpConfigurations[0].Name);
                Assert.Equal(getPublicIpAddressResponse.Id, getNicResponse.IpConfigurations[0].Id);
                Assert.Equal(getSubnetResponse.Id, getNicResponse.IpConfigurations[0].Id);

                // Get all Nics
                var getListNicResponse = networkResourceProviderClient.NetworkInterfaces.List(resourceGroupName);
                Assert.Equal(1, getListNicResponse.Count());
                Assert.Equal(getNicResponse.Name, getListNicResponse.First().Name);
                Assert.Equal(getNicResponse.Etag, getListNicResponse.First().Etag);
                Assert.Equal(getNicResponse.IpConfigurations[0].Etag, getListNicResponse.First().IpConfigurations[0].Etag);

                // Get all Nics in subscription
                var listNicSubscription = networkResourceProviderClient.NetworkInterfaces.ListAll();
                Assert.Equal(1, getListNicResponse.Count());
                Assert.Equal(getNicResponse.Name, listNicSubscription.First().Name);
                Assert.Equal(getNicResponse.Etag, listNicSubscription.First().Etag);
                Assert.Equal(listNicSubscription.First().IpConfigurations[0].Etag, getListNicResponse.First().IpConfigurations[0].Etag);

                // Delete Nic
                networkResourceProviderClient.NetworkInterfaces.Delete(resourceGroupName, nicName);

                getListNicResponse = networkResourceProviderClient.NetworkInterfaces.List(resourceGroupName);
                Assert.Equal(0, getListNicResponse.Count());

                // Delete PublicIPAddress
                networkResourceProviderClient.PublicIpAddresses.Delete(resourceGroupName, publicIpName);

                // Delete VirtualNetwork
                networkResourceProviderClient.VirtualNetworks.Delete(resourceGroupName, vnetName);
            }
        }

        [Fact(Skip = "TODO: Autorest")]
        public void NetworkInterfaceDnsSettingsTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler);
                var networkResourceProviderClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(context, handler);

                // IDNS is supported only in centralus currently
                // var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/networkInterfaces");
                var location = "centralus";

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                // Create Vnet
                // Populate parameter for Put Vnet
                string vnetName = TestUtilities.GenerateName();
                string subnetName = TestUtilities.GenerateName();

                var vnet = new VirtualNetwork()
                {
                    Location = location,

                    AddressSpace = new AddressSpace()
                    {
                        AddressPrefixes = new List<string>()
                    {
                        "10.0.0.0/16",
                    }
                    },
                    DhcpOptions = new DhcpOptions()
                    {
                        DnsServers = new List<string>()
                    {
                        "10.1.1.1",
                        "10.1.2.4"
                    }
                    },
                    Subnets = new List<Subnet>()
                    {
                        new Subnet()
                        {
                            Name = subnetName,
                            AddressPrefix = "10.0.0.0/24",
                        }
                    }
                };

                var putVnetResponse = networkResourceProviderClient.VirtualNetworks.CreateOrUpdate(resourceGroupName, vnetName, vnet);

                var getSubnetResponse = networkResourceProviderClient.Subnets.Get(resourceGroupName, vnetName, subnetName);

                // Create Nic
                string nicName = TestUtilities.GenerateName();
                string ipConfigName = TestUtilities.GenerateName();

                var nicParameters = new NetworkInterface()
                {
                    Location = location,
                    Tags = new Dictionary<string, string>()
                        {
                           {"key","value"}
                        },
                    IpConfigurations = new List<NetworkInterfaceIpConfiguration>()
                    {
                        new NetworkInterfaceIpConfiguration()
                        {
                             Name = ipConfigName,
                             PrivateIPAllocationMethod = IpAllocationMethod.Dynamic,
                             Subnet = new Microsoft.Azure.Management.Network.Models.SubResource()
                             {
                                 Id = getSubnetResponse.Id
                             }
                        }
                    },
                    DnsSettings = new NetworkInterfaceDnsSettings()
                    {
                        DnsServers = new List<string> { "1.0.0.1" , "1.0.0.2"},
                        InternalDnsNameLabel = "idnstest",
                    }
                };

                // Test NIC apis
                var putNicResponse = networkResourceProviderClient.NetworkInterfaces.CreateOrUpdate(resourceGroupName, nicName, nicParameters);

                var getNicResponse = networkResourceProviderClient.NetworkInterfaces.Get(resourceGroupName, nicName);
                Assert.Equal(getNicResponse.Name, nicName);
                Assert.Equal(getNicResponse.ProvisioningState, "Succeeded");
                Assert.Null(getNicResponse.VirtualMachine);
                Assert.Null(getNicResponse.MacAddress);
                Assert.Equal(1, getNicResponse.IpConfigurations.Count);
                Assert.Equal(ipConfigName, getNicResponse.IpConfigurations[0].Name);
                Assert.Equal(2, getNicResponse.DnsSettings.DnsServers.Count);
                Assert.Contains("1.0.0.1", getNicResponse.DnsSettings.DnsServers);
                Assert.Contains("1.0.0.2", getNicResponse.DnsSettings.DnsServers);
                Assert.Equal("idnstest", getNicResponse.DnsSettings.InternalDnsNameLabel);
                Assert.Equal(0, getNicResponse.DnsSettings.AppliedDnsServers.Count);
                Assert.Null(getNicResponse.DnsSettings.InternalFqdn);

                // Delete Nic
                networkResourceProviderClient.NetworkInterfaces.Delete(resourceGroupName, nicName);

                var getListNicResponse = networkResourceProviderClient.NetworkInterfaces.List(resourceGroupName);
                Assert.Null(getListNicResponse);

                // Delete VirtualNetwork
                networkResourceProviderClient.VirtualNetworks.Delete(resourceGroupName, vnetName);
            }
        }
    }
}