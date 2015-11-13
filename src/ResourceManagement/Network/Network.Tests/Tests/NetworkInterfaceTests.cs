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
    using System.Linq;

    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public class NetworkInterfaceTests
    {
        [Fact]
        public void NetworkInterfaceApiTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = MockContext.Start())
            {
                
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

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
                
                var publicIp = new PublicIPAddress()
                {
                    Location = location,
                    Tags = new Dictionary<string, string>()
                    {
                       {"key","value"}
                    },
                    PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
                    DnsSettings = new PublicIPAddressDnsSettings()
                    {
                       DomainNameLabel = domainNameLabel
                    }
                };

                // Put PublicIPAddress
                var putPublicIpAddressResponse = networkManagementClient.PublicIPAddresses.CreateOrUpdate(resourceGroupName, publicIpName, publicIp);
                Assert.Equal("Succeeded", putPublicIpAddressResponse.ProvisioningState);

                var getPublicIpAddressResponse = networkManagementClient.PublicIPAddresses.Get(resourceGroupName, publicIpName);

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

                var putVnetResponse = networkManagementClient.VirtualNetworks.CreateOrUpdate(resourceGroupName, vnetName, vnet);

                var getSubnetResponse = networkManagementClient.Subnets.Get(resourceGroupName, vnetName, subnetName);

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
                    IpConfigurations = new List<NetworkInterfaceIPConfiguration>()
                    {
                        new NetworkInterfaceIPConfiguration()
                        {
                             Name = ipConfigName,
                             PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                             PublicIPAddress = new PublicIPAddress ()
                             {
                                 Id = getPublicIpAddressResponse.Id
                             },
                             Subnet = new Subnet()
                             {
                                 Id = getSubnetResponse.Id
                             }
                        }
                    }
                };

                // Test NIC apis
                var putNicResponse = networkManagementClient.NetworkInterfaces.CreateOrUpdate(resourceGroupName, nicName, nicParameters);
                
                var getNicResponse = networkManagementClient.NetworkInterfaces.Get(resourceGroupName, nicName);
                Assert.Equal(getNicResponse.Name, nicName);
                Assert.Equal(getNicResponse.ProvisioningState, "Succeeded");
                Assert.Null(getNicResponse.VirtualMachine);
                Assert.Null(getNicResponse.MacAddress);
                Assert.Equal(1, getNicResponse.IpConfigurations.Count);
                Assert.Equal(ipConfigName, getNicResponse.IpConfigurations[0].Name);
                Assert.Equal(getPublicIpAddressResponse.Id, getNicResponse.IpConfigurations[0].PublicIPAddress.Id);
                Assert.Equal(getSubnetResponse.Id, getNicResponse.IpConfigurations[0].Subnet.Id);
                Assert.NotNull(getNicResponse.ResourceGuid);

                // Get all Nics
                var getListNicResponse = networkManagementClient.NetworkInterfaces.List(resourceGroupName);
                Assert.Equal(1, getListNicResponse.Count());
                Assert.Equal(getNicResponse.Name, getListNicResponse.First().Name);
                Assert.Equal(getNicResponse.Etag, getListNicResponse.First().Etag);
                Assert.Equal(getNicResponse.IpConfigurations[0].Etag, getListNicResponse.First().IpConfigurations[0].Etag);

                // Get all Nics in subscription
                var listNicSubscription = networkManagementClient.NetworkInterfaces.ListAll();
                Assert.NotEqual(0, listNicSubscription.Count());

                // Delete Nic
                networkManagementClient.NetworkInterfaces.Delete(resourceGroupName, nicName);
                
                getListNicResponse = networkManagementClient.NetworkInterfaces.List(resourceGroupName);
                Assert.Equal(0, getListNicResponse.Count());

                // Delete PublicIPAddress
                networkManagementClient.PublicIPAddresses.Delete(resourceGroupName, publicIpName);
                
                // Delete VirtualNetwork
                networkManagementClient.VirtualNetworks.Delete(resourceGroupName, vnetName);
            }
        }

        [Fact]
        public void NetworkInterfaceDnsSettingsTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = MockContext.Start())
            {
                
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/networkInterfaces");
                
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

                var putVnetResponse = networkManagementClient.VirtualNetworks.CreateOrUpdate(resourceGroupName, vnetName, vnet);

                var getSubnetResponse = networkManagementClient.Subnets.Get(resourceGroupName, vnetName, subnetName);

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
                    IpConfigurations = new List<NetworkInterfaceIPConfiguration>()
                    {
                        new NetworkInterfaceIPConfiguration()
                        {
                             Name = ipConfigName,
                             PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                             Subnet = new Subnet()
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
                var putNicResponse = networkManagementClient.NetworkInterfaces.CreateOrUpdate(resourceGroupName, nicName, nicParameters);
                
                var getNicResponse = networkManagementClient.NetworkInterfaces.Get(resourceGroupName, nicName);
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
                Assert.NotNull(getNicResponse.DnsSettings.InternalFqdn);

                // Delete Nic
                networkManagementClient.NetworkInterfaces.Delete(resourceGroupName, nicName);
                
                var getListNicResponse = networkManagementClient.NetworkInterfaces.List(resourceGroupName);
                Assert.Equal(0, getListNicResponse.Count());

                // Delete VirtualNetwork
                networkManagementClient.VirtualNetworks.Delete(resourceGroupName, vnetName);
            }
        }

        [Fact]
        public void NetworkInterfaceEnableIPForwardingTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = MockContext.Start())
            {
                
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/networkInterfaces");
                
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

                var putVnetResponse = networkManagementClient.VirtualNetworks.CreateOrUpdate(resourceGroupName, vnetName, vnet);

                var getSubnetResponse = networkManagementClient.Subnets.Get(resourceGroupName, vnetName, subnetName);

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
                    IpConfigurations = new List<NetworkInterfaceIPConfiguration>()
                    {
                        new NetworkInterfaceIPConfiguration()
                        {
                             Name = ipConfigName,
                             PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                             Subnet = new Subnet()
                             {
                                 Id = getSubnetResponse.Id
                             }
                        }
                    },
                    EnableIPForwarding = false,
                };

                // Test NIC apis
                var putNicResponse = networkManagementClient.NetworkInterfaces.CreateOrUpdate(resourceGroupName, nicName, nicParameters);

                var getNicResponse = networkManagementClient.NetworkInterfaces.Get(resourceGroupName, nicName);
                Assert.Equal(getNicResponse.Name, nicName);
                Assert.Equal(getNicResponse.ProvisioningState, "Succeeded");
                Assert.Null(getNicResponse.VirtualMachine);
                Assert.Null(getNicResponse.MacAddress);
                Assert.Equal(1, getNicResponse.IpConfigurations.Count);
                Assert.Equal(ipConfigName, getNicResponse.IpConfigurations[0].Name);
                Assert.False(getNicResponse.EnableIPForwarding);

                getNicResponse.EnableIPForwarding = true;
                networkManagementClient.NetworkInterfaces.CreateOrUpdate(resourceGroupName, nicName, getNicResponse);
                getNicResponse = networkManagementClient.NetworkInterfaces.Get(resourceGroupName, nicName);
                Assert.Equal(getNicResponse.Name, nicName);
                Assert.True(getNicResponse.EnableIPForwarding);

                // Delete Nic
                networkManagementClient.NetworkInterfaces.Delete(resourceGroupName, nicName);

                var getListNicResponse = networkManagementClient.NetworkInterfaces.List(resourceGroupName);
                Assert.Equal(0, getListNicResponse.Count());

                // Delete VirtualNetwork
                networkManagementClient.VirtualNetworks.Delete(resourceGroupName, vnetName);
            }
        }
    }
}