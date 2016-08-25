// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------
using System.Collections.Generic;
using System.Net;
using System;
using System.Linq;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;
using Microsoft.Azure.Test.HttpRecorder;

namespace Networks.Tests
{   
    public class NetworkInterfaceTests
    {
        public NetworkInterfaceTests()
        {
            HttpMockServer.RecordsDirectory = "SessionRecords";
        }

        [Fact]
        public void NetworkInterfaceApiTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
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

                //if single CA, primary flag will be set
                Assert.True(getNicResponse.IpConfigurations[0].Primary);
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
        public void NetworkInterfaceMultiIpConfigTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
                string ipconfigName2 = TestUtilities.GenerateName();

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
                             Primary = true,
                             PublicIPAddress = new PublicIPAddress ()
                             {
                                 Id = getPublicIpAddressResponse.Id
                             },
                             Subnet = new Subnet()
                             {
                                 Id = getSubnetResponse.Id
                             }
                        },

                         new NetworkInterfaceIPConfiguration()
                        {
                             Name = ipconfigName2,
                             PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                             Primary = false,
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
                Assert.Equal(true, getNicResponse.IpConfigurations[0].Primary);
                Assert.Equal(2, getNicResponse.IpConfigurations.Count);
                Assert.Equal(ipConfigName, getNicResponse.IpConfigurations[0].Name);
                Assert.Equal(ipconfigName2, getNicResponse.IpConfigurations[1].Name);
                Assert.Equal(false, getNicResponse.IpConfigurations[1].Primary);
                Assert.Equal(getPublicIpAddressResponse.Id, getNicResponse.IpConfigurations[0].PublicIPAddress.Id);
                Assert.Equal(getSubnetResponse.Id, getNicResponse.IpConfigurations[0].Subnet.Id);
                Assert.Equal(getSubnetResponse.Id, getNicResponse.IpConfigurations[1].Subnet.Id);
                Assert.NotNull(getNicResponse.ResourceGuid);

                // Get all Nics
                var getListNicResponse = networkManagementClient.NetworkInterfaces.List(resourceGroupName);
                Assert.Equal(1, getListNicResponse.Count());
                Assert.Equal(getNicResponse.Name, getListNicResponse.First().Name);
                Assert.Equal(getNicResponse.Etag, getListNicResponse.First().Etag);
                Assert.Equal(getNicResponse.IpConfigurations[0].Etag, getListNicResponse.First().IpConfigurations[0].Etag);
                Assert.Equal(getNicResponse.IpConfigurations[1].Etag, getListNicResponse.First().IpConfigurations[1].Etag);

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
        public void AssertMultiIpConfigOnDifferentSubnetFails()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            using (MockContext context = MockContext.Start(this.GetType().FullName))
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

                // Create Vnet
                // Populate parameter for Put Vnet
                string vnetName = TestUtilities.GenerateName();
                string subnetName = TestUtilities.GenerateName();
                string subnetName2 = TestUtilities.GenerateName();

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

                    Subnets = new List<Subnet>()
                    {
                        new Subnet()
                        {
                            Name = subnetName,
                            AddressPrefix = "10.0.0.0/24",
                        },

                         new Subnet()
                        {
                            Name = subnetName2,
                            AddressPrefix = "10.0.1.0/24",
                        }
                    }
                };
                var putVnetResponse = networkManagementClient.VirtualNetworks.CreateOrUpdate(resourceGroupName, vnetName, vnet);

                var getSubnet1Response = networkManagementClient.Subnets.Get(resourceGroupName, vnetName, subnetName);

                var getSubnet2Response = networkManagementClient.Subnets.Get(resourceGroupName, vnetName, subnetName2);

                // Create Nic
                string nicName = TestUtilities.GenerateName();
                string ipConfigName = TestUtilities.GenerateName();
                string ipconfigName2 = TestUtilities.GenerateName();

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
                             Primary = true,
                             Subnet = new Subnet()
                             {
                                 Id = getSubnet1Response.Id
                             }
                        },

                         new NetworkInterfaceIPConfiguration()
                        {
                             Name = ipconfigName2,
                             PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                             Primary = false,
                             Subnet = new Subnet()
                             {
                                 Id = getSubnet2Response.Id
                             }
                        }
                    }
                };

                try
                {
                    // Test NIC apis
                    var putNicResponse = networkManagementClient.NetworkInterfaces.CreateOrUpdate(resourceGroupName, nicName, nicParameters);
                }

                catch (Exception ex)
                {
                    Assert.Contains("cannot belong to different subnets", ex.Message);
                }


            }
        }

        [Fact]
        public void NetworkInterfaceDnsSettingsTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
                        DnsServers = new List<string> { "1.0.0.1", "1.0.0.2" },
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
                Assert.True(getNicResponse.IpConfigurations[0].Primary);
                Assert.NotNull(getNicResponse.DnsSettings.InternalFqdn);

                // Delete Nic
                networkManagementClient.NetworkInterfaces.Delete(resourceGroupName, nicName);

                var getListNicResponse = networkManagementClient.NetworkInterfaces.List(resourceGroupName);
                Assert.Equal(0, getListNicResponse.Count());

                // Delete VirtualNetwork
                networkManagementClient.VirtualNetworks.Delete(resourceGroupName, vnetName);
            }
        }

        [Fact(Skip = "NRP check should be removed to check for multiple ipv4")]
        /// currently this test is failing because of nrp valdiation check:cannot have multiple IPv4 IpConfigurations if it specifies a Ipv6 IpConfigurations. Ipv4 Ipconfig Count: 2
        /// will remove ignore tag once the check in nrp is removed.
        public void NetworkInterfaceApiIPv6MultiCATest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/networkInterfaces", Network.Tests.Helpers.FeaturesInfo.Type.All);

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                // Create publicIP
                string publicIpName = TestUtilities.GenerateName();
                string domainNameLabel = TestUtilities.GenerateName();

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
                string nicName = TestUtilities.GenerateName("dualstacknic");
                string ipConfigName = TestUtilities.GenerateName("ipv4ipconfig");
                string ipv6IpConfigName = TestUtilities.GenerateName("ipv6ipconfig");
                string ipConfigName2 = TestUtilities.GenerateName("ipv4ipconfig2");

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
                             Primary = true,
                             Name = ipConfigName,
                             PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                             PrivateIPAddressVersion = IPVersion.IPv4,
                             Subnet = new Subnet()
                             {
                                 Id = getSubnetResponse.Id
                             }
                        },
                        new NetworkInterfaceIPConfiguration()
                        {
                             Name = ipv6IpConfigName,
                             PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                             PrivateIPAddressVersion = IPVersion.IPv6,
                        },

                       new NetworkInterfaceIPConfiguration()
                        {
                             Name = ipConfigName2,
                             PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                             PrivateIPAddressVersion = IPVersion.IPv4,
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
                Assert.Equal(ipConfigName, getNicResponse.IpConfigurations[0].Name);
                Assert.NotNull(getNicResponse.ResourceGuid);
                Assert.Equal(getSubnetResponse.Id, getNicResponse.IpConfigurations[0].Subnet.Id);
                Assert.Equal(IPVersion.IPv4, getNicResponse.IpConfigurations[0].PrivateIPAddressVersion);

                // Ipv6 specific asserts
                Assert.Equal(2, getNicResponse.IpConfigurations.Count);
                Assert.Equal(ipv6IpConfigName, getNicResponse.IpConfigurations[1].Name);
                Assert.Equal(true, getNicResponse.IpConfigurations[1].Primary);
                Assert.Equal(false, getNicResponse.IpConfigurations[0].Primary);
                Assert.Null(getNicResponse.IpConfigurations[1].Subnet);
                Assert.Equal(IPVersion.IPv6, getNicResponse.IpConfigurations[1].PrivateIPAddressVersion);

                // Get all Nics
                var getListNicResponse = networkManagementClient.NetworkInterfaces.List(resourceGroupName);
                Assert.Equal(1, getListNicResponse.Count());
                Assert.Equal(getNicResponse.Name, getListNicResponse.First().Name);
                Assert.Equal(getNicResponse.Etag, getListNicResponse.First().Etag);
                Assert.Equal(getNicResponse.IpConfigurations[0].Etag, getListNicResponse.First().IpConfigurations[0].Etag);
                Assert.Equal(getNicResponse.IpConfigurations[1].Etag, getListNicResponse.First().IpConfigurations[1].Etag);

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
        public void NetworkInterfaceDnsSettingsTestIdnsSuffix()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
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

                // IDnsSuffix is a read-only property, hence not specified below
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
                        DnsServers = new List<string> { "1.0.0.1", "1.0.0.2" },
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

                // IDnsSuffix is a read-only property. Ensure the response contains some value.
                Assert.NotNull(getNicResponse.DnsSettings.InternalDomainNameSuffix);

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

            using (var context = MockContext.Start(this.GetType().FullName))
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

        [Fact]
        public void NetworkInterfaceNetworkSecurityGroupTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = MockContext.Start(this.GetType().FullName))
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
                string networkSecurityGroupName = TestUtilities.GenerateName();
                string securityRule1 = TestUtilities.GenerateName();
                string securityRule2 = TestUtilities.GenerateName();

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

                // Create network security group
                string destinationPortRange = "123-3500";
                var networkSecurityGroup = new NetworkSecurityGroup()
                {
                    Location = location,
                    SecurityRules = new List<SecurityRule>()
                                    {
                                        new SecurityRule()
                                            {
                                                Name = securityRule1,
                                                Access = SecurityRuleAccess.Allow,
                                                Description = "Test security rule",
                                                DestinationAddressPrefix = "*",
                                                DestinationPortRange = destinationPortRange,
                                                Direction = SecurityRuleDirection.Inbound,
                                                Priority = 500,
                                                Protocol = SecurityRuleProtocol.Tcp,
                                                SourceAddressPrefix = "*",
                                                SourcePortRange = "655"
                                            }
                                    }
                };

                // Put Nsg
                var putNsgResponse = networkManagementClient.NetworkSecurityGroups.CreateOrUpdate(resourceGroupName, networkSecurityGroupName, networkSecurityGroup);
                Assert.Equal("Succeeded", putNsgResponse.ProvisioningState);

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
                                 Id = putVnetResponse.Subnets[0].Id
                             }
                        }
                    },
                    NetworkSecurityGroup = putNsgResponse
                };

                // Test NIC apis
                var putNicResponse = networkManagementClient.NetworkInterfaces.CreateOrUpdate(resourceGroupName, nicName, nicParameters);

                var getNicResponse = networkManagementClient.NetworkInterfaces.Get(resourceGroupName, nicName);
                Assert.Equal(getNicResponse.ProvisioningState, "Succeeded");

                var getNsgResponse = networkManagementClient.NetworkSecurityGroups.Get(resourceGroupName, networkSecurityGroupName);

                // Verify nic - nsg association
                Assert.Equal(getNicResponse.NetworkSecurityGroup.Id, getNsgResponse.Id);
                Assert.Equal(getNsgResponse.NetworkInterfaces[0].Id, getNicResponse.Id);

                // Delete Nic
                networkManagementClient.NetworkInterfaces.Delete(resourceGroupName, nicName);

                var getListNicResponse = networkManagementClient.NetworkInterfaces.List(resourceGroupName);
                Assert.Equal(0, getListNicResponse.Count());

                // Delete NSG
                networkManagementClient.NetworkSecurityGroups.Delete(resourceGroupName, networkSecurityGroupName);

                // Delete VirtualNetwork
                networkManagementClient.VirtualNetworks.Delete(resourceGroupName, vnetName);
            }
        }

        [Fact(Skip = "Need server side feature registration for subscriptions")]
        public void NetworkInterfaceEffectiveNetworkSecurityGroupTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = MockContext.Start(this.GetType().FullName))
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
                string networkSecurityGroupName = TestUtilities.GenerateName();
                string securityRule1 = TestUtilities.GenerateName();
                string securityRule2 = TestUtilities.GenerateName();

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

                // Create network security group
                string destinationPortRange = "123-3500";
                var networkSecurityGroup = new NetworkSecurityGroup()
                {
                    Location = location,
                    SecurityRules = new List<SecurityRule>()
                                    {
                                        new SecurityRule()
                                            {
                                                Name = securityRule1,
                                                Access = SecurityRuleAccess.Allow,
                                                Description = "Test security rule",
                                                DestinationAddressPrefix = "*",
                                                DestinationPortRange = destinationPortRange,
                                                Direction = SecurityRuleDirection.Inbound,
                                                Priority = 500,
                                                Protocol = SecurityRuleProtocol.Tcp,
                                                SourceAddressPrefix = "*",
                                                SourcePortRange = "655"
                                            }
                                    }
                };

                // Put Nsg
                var putNsgResponse = networkManagementClient.NetworkSecurityGroups.CreateOrUpdate(resourceGroupName, networkSecurityGroupName, networkSecurityGroup);
                Assert.Equal("Succeeded", putNsgResponse.ProvisioningState);

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
                                 Id = putVnetResponse.Subnets[0].Id
                             }
                        }
                    },
                    NetworkSecurityGroup = putNsgResponse
                };

                // Test NIC apis
                var putNicResponse = networkManagementClient.NetworkInterfaces.CreateOrUpdate(resourceGroupName, nicName, nicParameters);

                var getNicResponse = networkManagementClient.NetworkInterfaces.Get(resourceGroupName, nicName);
                Assert.Equal(getNicResponse.ProvisioningState, "Succeeded");

                var getNsgResponse = networkManagementClient.NetworkSecurityGroups.Get(resourceGroupName, networkSecurityGroupName);

                // Verify nic - nsg association
                Assert.Equal(getNicResponse.NetworkSecurityGroup.Id, getNsgResponse.Id);
                Assert.Equal(getNsgResponse.NetworkInterfaces[0].Id, getNicResponse.Id);

                // Get effective NSGs
                var effectiveNsgs = networkManagementClient.NetworkInterfaces.ListEffectiveNetworkSecurityGroups(resourceGroupName, nicName);
                Assert.NotNull(effectiveNsgs);

                // Delete Nic
                networkManagementClient.NetworkInterfaces.Delete(resourceGroupName, nicName);

                var getListNicResponse = networkManagementClient.NetworkInterfaces.List(resourceGroupName);
                Assert.Equal(0, getListNicResponse.Count());

                // Delete NSG
                networkManagementClient.NetworkSecurityGroups.Delete(resourceGroupName, networkSecurityGroupName);

                // Delete VirtualNetwork
                networkManagementClient.VirtualNetworks.Delete(resourceGroupName, vnetName);
            }
        }

        [Fact(Skip = "Need server side feature registration for subscriptions")]
        public void NetworkInterfaceEffectiveRouteTableTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = MockContext.Start(this.GetType().FullName))
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
                string routeTableName = TestUtilities.GenerateName();
                string route1Name = TestUtilities.GenerateName();

                var routeTable = new RouteTable() { Location = location, };
                routeTable.Routes = new List<Route>();

                var route1 = new Route()
                {
                    AddressPrefix = "192.168.1.0/24",
                    Name = route1Name,
                    NextHopIpAddress = "23.108.1.1",
                    NextHopType = RouteNextHopType.VirtualAppliance
                };

                routeTable.Routes.Add(route1);

                // Put RouteTable
                var putRouteTableResponse = networkManagementClient.RouteTables.CreateOrUpdate(resourceGroupName, routeTableName, routeTable);

                Assert.Equal("Succeeded", putRouteTableResponse.ProvisioningState);

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
                            RouteTable = putRouteTableResponse
                        }
                    }
                };

                var putVnetResponse = networkManagementClient.VirtualNetworks.CreateOrUpdate(resourceGroupName, vnetName, vnet);

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
                                 Id = putVnetResponse.Subnets[0].Id
                             }
                        }
                    }
                };

                // Test NIC apis
                var putNicResponse = networkManagementClient.NetworkInterfaces.CreateOrUpdate(resourceGroupName, nicName, nicParameters);

                var getNicResponse = networkManagementClient.NetworkInterfaces.Get(resourceGroupName, nicName);
                Assert.Equal(getNicResponse.ProvisioningState, "Succeeded");

                // Get effective NSGs
                var effectiveRouteTable = networkManagementClient.NetworkInterfaces.GetEffectiveRouteTable(resourceGroupName, nicName);
                Assert.NotNull(effectiveRouteTable);

                // Delete Nic
                networkManagementClient.NetworkInterfaces.Delete(resourceGroupName, nicName);

                var getListNicResponse = networkManagementClient.NetworkInterfaces.List(resourceGroupName);
                Assert.Equal(0, getListNicResponse.Count());

                // Delete routetable
                networkManagementClient.RouteTables.Delete(resourceGroupName, routeTableName);

                // Delete VirtualNetwork
                networkManagementClient.VirtualNetworks.Delete(resourceGroupName, vnetName);
            }
        }
    }
}