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
    public class VirtualNetworkTests
    {
        [Fact]
        public void VirtualNetworkApiTest()
        {
            var handler = new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK};

            using (var context = UndoContext.Current)
            {
                context.Start();
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(handler);
                var networkResourceProviderClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);

                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/virtualNetworks");

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                string vnetName = TestUtilities.GenerateName();
                string subnet1Name = TestUtilities.GenerateName();
                string subnet2Name = TestUtilities.GenerateName();

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
                            Name = subnet1Name,
                            AddressPrefix = "10.0.1.0/24",
                        },
                        new Subnet()
                        {
                            Name = subnet2Name,
                            AddressPrefix = "10.0.2.0/24",
                        }
                    }
                };

                // Put Vnet
                var putVnetResponse = networkResourceProviderClient.VirtualNetworks.CreateOrUpdate(resourceGroupName, vnetName, vnet);
                Assert.Equal("Succeeded", putVnetResponse.ProvisioningState);

                // Get Vnet
                var getVnetResponse = networkResourceProviderClient.VirtualNetworks.Get(resourceGroupName, vnetName);
                Assert.Equal(vnetName, getVnetResponse.Name);
                Assert.Equal("Succeeded", getVnetResponse.ProvisioningState);
                Assert.Equal("10.1.1.1", getVnetResponse.DhcpOptions.DnsServers[0]);
                Assert.Equal("10.1.2.4", getVnetResponse.DhcpOptions.DnsServers[1]);
                Assert.Equal("10.0.0.0/16", getVnetResponse.AddressSpace.AddressPrefixes[0]);
                Assert.Equal(subnet1Name, getVnetResponse.Subnets[0].Name);
                Assert.Equal(subnet2Name, getVnetResponse.Subnets[1].Name);

                // Get all Vnets
                var getAllVnets = networkResourceProviderClient.VirtualNetworks.List(resourceGroupName);
                Assert.Equal(vnetName, getAllVnets.Value[0].Name);
                Assert.Equal("Succeeded", getAllVnets.Value[0].ProvisioningState);
                Assert.Equal("10.0.0.0/16", getAllVnets.Value[0].AddressSpace.AddressPrefixes[0]);
                Assert.Equal(subnet1Name, getAllVnets.Value[0].Subnets[0].Name);
                Assert.Equal(subnet2Name, getAllVnets.Value[0].Subnets[1].Name);

                // Get all Vnets in a subscription
                var getAllVnetInSubscription = networkResourceProviderClient.VirtualNetworks.ListAll();
                Assert.Equal(vnetName, getAllVnetInSubscription.Value[0].Name);
                Assert.Equal("Succeeded", getAllVnetInSubscription.Value[0].ProvisioningState);
                Assert.Equal("10.0.0.0/16", getAllVnetInSubscription.Value[0].AddressSpace.AddressPrefixes[0]);
                Assert.Equal(subnet1Name, getAllVnetInSubscription.Value[0].Subnets[0].Name);
                Assert.Equal(subnet2Name, getAllVnetInSubscription.Value[0].Subnets[1].Name);

                // Delete Vnet
                networkResourceProviderClient.VirtualNetworks.Delete(resourceGroupName, vnetName);

                // Get all Vnets
                getAllVnets = networkResourceProviderClient.VirtualNetworks.List(resourceGroupName);
                Assert.Equal(0, getAllVnets.Value.Count);
            }
        }
    }
}