using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Xunit;

namespace Networks.Tests
{
    using System;

    public class TestHelper
    {
        public static PublicIPAddress CreateDefaultPublicIpAddress(string name, string resourceGroupName, string domainNameLabel, string location,
            NetworkManagementClient nrpClient)
        {
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

            // Put nic1PublicIpAddress
            var putPublicIpAddressResponse = nrpClient.PublicIPAddresses.CreateOrUpdate(resourceGroupName, name, publicIp);
            Assert.Equal("Succeeded", putPublicIpAddressResponse.ProvisioningState);
            var getPublicIpAddressResponse = nrpClient.PublicIPAddresses.Get(resourceGroupName, name);

            return getPublicIpAddressResponse;
        }

        public static NetworkInterface CreateNetworkInterface(
            string name,
            string resourceGroupName,
            string publicIpAddressId,
            string subnetId,
            string location,
            string ipConfigName,
            NetworkManagementClient client)
        {
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
                             Id = subnetId
                         }
                    }
                }
            };

            if (!String.IsNullOrEmpty(publicIpAddressId))
            {
                nicParameters.IpConfigurations[0].PublicIPAddress = new PublicIPAddress() { Id = publicIpAddressId };
            }

            // Test NIC apis
            var putNicResponse = client.NetworkInterfaces.CreateOrUpdate(resourceGroupName, name, nicParameters);
            
            var getNicResponse = client.NetworkInterfaces.Get(resourceGroupName, name);
            Assert.Equal(getNicResponse.Name, name);

            // because its a single CA nic, primaryOnCA is always true
            Assert.Equal(getNicResponse.IpConfigurations[0].Primary, true);

            Assert.Equal(getNicResponse.ProvisioningState, "Succeeded");

            return getNicResponse;
        }

        public static VirtualNetwork CreateVirtualNetwork(string vnetName, string subnetName, string resourceGroupName, string location, NetworkManagementClient client)
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

            client.VirtualNetworks.CreateOrUpdate(resourceGroupName, vnetName, vnet);
            var getVnetResponse = client.VirtualNetworks.Get(resourceGroupName, vnetName);

            return getVnetResponse;
        }

        public static string GetChildLbResourceId(
            string subscriptionId,
            string resourceGroupName,
            string lbname,
            string childResourceType,
            string childResourceName)
        {
            return
                String.Format(
                    "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/loadBalancers/{2}/{3}/{4}",
                    subscriptionId,
                    resourceGroupName,
                    lbname,
                    childResourceType,
                    childResourceName);
        }
    }
}
