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
    public class NetworkInterfaceTests
    {
        [Fact]
        public void NetworkInterfaceApiTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(handler);
                var networkResourceProviderClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);

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
                    PublicIpAllocationMethod = IpAllocationMethod.Dynamic,
                    DnsSettings = new PublicIpAddressDnsSettings()
                    {
                       DomainNameLabel = domainNameLabel
                    }
                };

                // Put PublicIpAddress
                var putPublicIpAddressResponse = networkResourceProviderClient.PublicIpAddresses.CreateOrUpdate(resourceGroupName, publicIpName, publicIp);
                Assert.Equal(HttpStatusCode.OK, putPublicIpAddressResponse.StatusCode);
                Assert.Equal("Succeeded", putPublicIpAddressResponse.Status);
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
                Assert.Equal(HttpStatusCode.OK, putVnetResponse.StatusCode);

                var getSubnetResponse = networkResourceProviderClient.Subnets.Get(resourceGroupName, vnetName, subnetName);

                // Create Nic
                string nicName = TestUtilities.GenerateName();
                string ipConfigName = TestUtilities.GenerateName();

                var nicParameters = new NetworkInterface()
                {
                    Location = location,
                    Name = nicName,
                    Tags = new Dictionary<string, string>()
                        {
                           {"key","value"}
                        },
                    IpConfigurations = new List<NetworkInterfaceIpConfiguration>()
                    {
                        new NetworkInterfaceIpConfiguration()
                        {
                             Name = ipConfigName,
                             PrivateIpAllocationMethod = IpAllocationMethod.Dynamic,
                             PublicIpAddress = new ResourceId()
                             {
                                 Id = getPublicIpAddressResponse.PublicIpAddress.Id
                             },
                             Subnet = new ResourceId()
                             {
                                 Id = getSubnetResponse.Subnet.Id
                             }
                        }
                    }
                };

                // Test NIC apis
                var putNicResponse = networkResourceProviderClient.NetworkInterfaces.CreateOrUpdate(resourceGroupName, nicName, nicParameters);
                Assert.Equal(HttpStatusCode.OK, putNicResponse.StatusCode);

                var getNicResponse = networkResourceProviderClient.NetworkInterfaces.Get(resourceGroupName, nicName);
                Assert.Equal(getNicResponse.NetworkInterface.Name, nicName);
                Assert.Equal(getNicResponse.NetworkInterface.ProvisioningState, Microsoft.Azure.Management.Resources.Models.ProvisioningState.Succeeded);
                Assert.Null(getNicResponse.NetworkInterface.VirtualMachine);
                Assert.Null(getNicResponse.NetworkInterface.MacAddress);
                Assert.Equal(1, getNicResponse.NetworkInterface.IpConfigurations.Count);
                Assert.Equal(ipConfigName, getNicResponse.NetworkInterface.IpConfigurations[0].Name);
                Assert.Equal(getPublicIpAddressResponse.PublicIpAddress.Id, getNicResponse.NetworkInterface.IpConfigurations[0].PublicIpAddress.Id);
                Assert.Equal(getSubnetResponse.Subnet.Id, getNicResponse.NetworkInterface.IpConfigurations[0].Subnet.Id);
                Assert.NotNull(getNicResponse.NetworkInterface.ResourceGuid);

                // Get all Nics
                var getListNicResponse = networkResourceProviderClient.NetworkInterfaces.List(resourceGroupName);
                Assert.Equal(1, getListNicResponse.NetworkInterfaces.Count);
                Assert.Equal(getNicResponse.NetworkInterface.Name, getListNicResponse.NetworkInterfaces[0].Name);
                Assert.Equal(getNicResponse.NetworkInterface.Etag, getListNicResponse.NetworkInterfaces[0].Etag);
                Assert.Equal(getNicResponse.NetworkInterface.IpConfigurations[0].Etag, getListNicResponse.NetworkInterfaces[0].IpConfigurations[0].Etag);

                // Get all Nics in subscription
                var listNicSubscription = networkResourceProviderClient.NetworkInterfaces.ListAll();
                Assert.Equal(1, getListNicResponse.NetworkInterfaces.Count);
                Assert.Equal(getNicResponse.NetworkInterface.Name, listNicSubscription.NetworkInterfaces[0].Name);
                Assert.Equal(getNicResponse.NetworkInterface.Etag, listNicSubscription.NetworkInterfaces[0].Etag);
                Assert.Equal(listNicSubscription.NetworkInterfaces[0].IpConfigurations[0].Etag, getListNicResponse.NetworkInterfaces[0].IpConfigurations[0].Etag);

                // Delete Nic
                var deleteNicResponse = networkResourceProviderClient.NetworkInterfaces.Delete(resourceGroupName, nicName);
                Assert.Equal(HttpStatusCode.OK, deleteNicResponse.StatusCode);

                getListNicResponse = networkResourceProviderClient.NetworkInterfaces.List(resourceGroupName);
                Assert.Equal(0, getListNicResponse.NetworkInterfaces.Count);

                // Delete PublicIpAddress
                var deletePublicIpAddressResponse = networkResourceProviderClient.PublicIpAddresses.Delete(resourceGroupName, publicIpName);
                Assert.Equal(HttpStatusCode.OK, deletePublicIpAddressResponse.StatusCode);

                // Delete VirtualNetwork
                var deleteVnetResponse = networkResourceProviderClient.VirtualNetworks.Delete(resourceGroupName, vnetName);
                Assert.Equal(HttpStatusCode.OK, deleteVnetResponse.StatusCode);
            }
        }

        [Fact]
        public void NetworkInterfaceDnsSettingsTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(handler);
                var networkResourceProviderClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);

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

                var putVnetResponse = networkResourceProviderClient.VirtualNetworks.CreateOrUpdate(resourceGroupName, vnetName, vnet);
                Assert.Equal(HttpStatusCode.OK, putVnetResponse.StatusCode);

                var getSubnetResponse = networkResourceProviderClient.Subnets.Get(resourceGroupName, vnetName, subnetName);

                // Create Nic
                string nicName = TestUtilities.GenerateName();
                string ipConfigName = TestUtilities.GenerateName();

                var nicParameters = new NetworkInterface()
                {
                    Location = location,
                    Name = nicName,
                    Tags = new Dictionary<string, string>()
                        {
                           {"key","value"}
                        },
                    IpConfigurations = new List<NetworkInterfaceIpConfiguration>()
                    {
                        new NetworkInterfaceIpConfiguration()
                        {
                             Name = ipConfigName,
                             PrivateIpAllocationMethod = IpAllocationMethod.Dynamic,
                             Subnet = new ResourceId()
                             {
                                 Id = getSubnetResponse.Subnet.Id
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
                Assert.Equal(HttpStatusCode.OK, putNicResponse.StatusCode);

                var getNicResponse = networkResourceProviderClient.NetworkInterfaces.Get(resourceGroupName, nicName);
                Assert.Equal(getNicResponse.NetworkInterface.Name, nicName);
                Assert.Equal(getNicResponse.NetworkInterface.ProvisioningState, Microsoft.Azure.Management.Resources.Models.ProvisioningState.Succeeded);
                Assert.Null(getNicResponse.NetworkInterface.VirtualMachine);
                Assert.Null(getNicResponse.NetworkInterface.MacAddress);
                Assert.Equal(1, getNicResponse.NetworkInterface.IpConfigurations.Count);
                Assert.Equal(ipConfigName, getNicResponse.NetworkInterface.IpConfigurations[0].Name);
                Assert.Equal(2, getNicResponse.NetworkInterface.DnsSettings.DnsServers.Count);
                Assert.Contains("1.0.0.1", getNicResponse.NetworkInterface.DnsSettings.DnsServers);
                Assert.Contains("1.0.0.2", getNicResponse.NetworkInterface.DnsSettings.DnsServers);
                Assert.Equal("idnstest", getNicResponse.NetworkInterface.DnsSettings.InternalDnsNameLabel);
                Assert.Equal(0, getNicResponse.NetworkInterface.DnsSettings.AppliedDnsServers.Count);
                Assert.Null(getNicResponse.NetworkInterface.DnsSettings.InternalFqdn);

                // Delete Nic
                var deleteNicResponse = networkResourceProviderClient.NetworkInterfaces.Delete(resourceGroupName, nicName);
                Assert.Equal(HttpStatusCode.OK, deleteNicResponse.StatusCode);

                var getListNicResponse = networkResourceProviderClient.NetworkInterfaces.List(resourceGroupName);
                Assert.Equal(0, getListNicResponse.NetworkInterfaces.Count);

                // Delete VirtualNetwork
                var deleteVnetResponse = networkResourceProviderClient.VirtualNetworks.Delete(resourceGroupName, vnetName);
                Assert.Equal(HttpStatusCode.OK, deleteVnetResponse.StatusCode);
            }
        }

        [Fact]
        public void NetworkInterfaceEnableIPForwardingTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(handler);
                var networkResourceProviderClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);

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

                var putVnetResponse = networkResourceProviderClient.VirtualNetworks.CreateOrUpdate(resourceGroupName, vnetName, vnet);
                Assert.Equal(HttpStatusCode.OK, putVnetResponse.StatusCode);

                var getSubnetResponse = networkResourceProviderClient.Subnets.Get(resourceGroupName, vnetName, subnetName);

                // Create Nic
                string nicName = TestUtilities.GenerateName();
                string ipConfigName = TestUtilities.GenerateName();

                var nicParameters = new NetworkInterface()
                {
                    Location = location,
                    Name = nicName,
                    Tags = new Dictionary<string, string>()
                        {
                           {"key","value"}
                        },
                    IpConfigurations = new List<NetworkInterfaceIpConfiguration>()
                    {
                        new NetworkInterfaceIpConfiguration()
                        {
                             Name = ipConfigName,
                             PrivateIpAllocationMethod = IpAllocationMethod.Dynamic,
                             Subnet = new ResourceId()
                             {
                                 Id = getSubnetResponse.Subnet.Id
                             }
                        }
                    },
                    EnableIPForwarding = false,
                };

                // Test NIC apis
                var putNicResponse = networkResourceProviderClient.NetworkInterfaces.CreateOrUpdate(resourceGroupName, nicName, nicParameters);
                Assert.Equal(HttpStatusCode.OK, putNicResponse.StatusCode);

                var getNicResponse = networkResourceProviderClient.NetworkInterfaces.Get(resourceGroupName, nicName);
                Assert.Equal(getNicResponse.NetworkInterface.Name, nicName);
                Assert.Equal(getNicResponse.NetworkInterface.ProvisioningState, Microsoft.Azure.Management.Resources.Models.ProvisioningState.Succeeded);
                Assert.Null(getNicResponse.NetworkInterface.VirtualMachine);
                Assert.Null(getNicResponse.NetworkInterface.MacAddress);
                Assert.Equal(1, getNicResponse.NetworkInterface.IpConfigurations.Count);
                Assert.Equal(ipConfigName, getNicResponse.NetworkInterface.IpConfigurations[0].Name);
                Assert.False(getNicResponse.NetworkInterface.EnableIPForwarding);

                getNicResponse.NetworkInterface.EnableIPForwarding = true;
                networkResourceProviderClient.NetworkInterfaces.CreateOrUpdate(resourceGroupName, nicName, getNicResponse.NetworkInterface);
                getNicResponse = networkResourceProviderClient.NetworkInterfaces.Get(resourceGroupName, nicName);
                Assert.Equal(getNicResponse.NetworkInterface.Name, nicName);
                Assert.True(getNicResponse.NetworkInterface.EnableIPForwarding);

                // Delete Nic
                var deleteNicResponse = networkResourceProviderClient.NetworkInterfaces.Delete(resourceGroupName, nicName);
                Assert.Equal(HttpStatusCode.OK, deleteNicResponse.StatusCode);

                var getListNicResponse = networkResourceProviderClient.NetworkInterfaces.List(resourceGroupName);
                Assert.Equal(0, getListNicResponse.NetworkInterfaces.Count);

                // Delete VirtualNetwork
                var deleteVnetResponse = networkResourceProviderClient.VirtualNetworks.Delete(resourceGroupName, vnetName);
                Assert.Equal(HttpStatusCode.OK, deleteVnetResponse.StatusCode);
            }
        }
    }
}