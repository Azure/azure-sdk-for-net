using System.Collections.Generic;
using System.Net;
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
                PublicIpAllocationMethod = IpAllocationMethod.Dynamic,
                DnsSettings = new PublicIpAddressDnsSettings()
                {
                    DomainNameLabel = domainNameLabel
                }
            };

            // Put nic1PublicIpAddress
            var putPublicIpAddressResponse = nrpClient.PublicIpAddresses.CreateOrUpdate(resourceGroupName, name, publicIp);
            Assert.Equal(HttpStatusCode.OK, putPublicIpAddressResponse.StatusCode);
            Assert.Equal("Succeeded", putPublicIpAddressResponse.Status);
            var getPublicIpAddressResponse = nrpClient.PublicIpAddresses.Get(resourceGroupName, name);

            return getPublicIpAddressResponse.PublicIpAddress;
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
                Name = name,
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
                             Id = subnetId
                         }
                    }
                }
            };

            if (!string.IsNullOrEmpty(publicIpAddressId))
            {
                nicParameters.IpConfigurations[0].PublicIpAddress = new ResourceId() { Id = publicIpAddressId };
            }

            // Test NIC apis
            var putNicResponse = client.NetworkInterfaces.CreateOrUpdate(resourceGroupName, name, nicParameters);
            Assert.Equal(HttpStatusCode.OK, putNicResponse.StatusCode);

            var getNicResponse = client.NetworkInterfaces.Get(resourceGroupName, name);
            Assert.Equal(getNicResponse.NetworkInterface.Name, name);
            Assert.Equal(getNicResponse.NetworkInterface.ProvisioningState, Microsoft.Azure.Management.Resources.Models.ProvisioningState.Succeeded);

            return getNicResponse.NetworkInterface;
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
            Assert.Equal(HttpStatusCode.OK, putVnetResponse.StatusCode);
            var getVnetResponse = client.VirtualNetworks.Get(resourceGroupName, vnetName);

            return getVnetResponse.VirtualNetwork;
        }
    }
}
