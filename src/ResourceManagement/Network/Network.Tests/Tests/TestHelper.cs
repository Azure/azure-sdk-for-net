using System.Collections.Generic;
using System.Net;
using Microsoft.Azure;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Xunit;

namespace Networks.Tests
{
    public class TestHelper
    {
        public static PublicIpAddress CreateDefaultPublicIpAddress(string name, string resourceGroupName, string domainNameLabel, string location,
            NetworkResourceProviderClient nrpClient)
        {
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

            // Put nic1PublicIpAddress
            var putPublicIpAddressResponse = nrpClient.PublicIpAddresses.CreateOrUpdate(resourceGroupName, name, publicIp);
            Assert.Equal("Succeeded", putPublicIpAddressResponse.PublicIpAddress.ProvisioningState);
            var getPublicIpAddressResponse = nrpClient.PublicIpAddresses.Get(resourceGroupName, name);

            return getPublicIpAddressResponse;
        }

        public static NetworkInterface CreateNetworkInterface(
            string name,
            string resourceGroupName,
            string publicIpAddressId,
            string subnetId,
            string location,
            string ipConfigName,
            NetworkResourceProviderClient client)
        {
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
                            Subnet = new SubResource()
                            {
                                Id = subnetId
                            }
                    }
                }
            };

            if (!string.IsNullOrEmpty(publicIpAddressId))
            {
                nicParameters.IpConfigurations[0].PublicIPAddress = new SubResource() { Id = publicIpAddressId };
            }

            // Test NIC apis
            var putNicResponse = client.NetworkInterfaces.CreateOrUpdate(resourceGroupName, name, nicParameters);

            var getNicResponse = client.NetworkInterfaces.Get(resourceGroupName, name);
            Assert.Equal(getNicResponse.Name, name);
            Assert.Equal(getNicResponse.ProvisioningState, "Succeeded");

            return getNicResponse;
        }

        public static VirtualNetwork CreateVirtualNetwork(string vnetName, string subnetName, string resourceGroupName, string location, NetworkResourceProviderClient client)
        {
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

            var putVnetResponse = client.VirtualNetworks.CreateOrUpdate(resourceGroupName, vnetName, vnet);
            var getVnetResponse = client.VirtualNetworks.Get(resourceGroupName, vnetName);

            return getVnetResponse;
        }
    }
}
