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
                Assert.Equal(HttpStatusCode.OK, putVnetResponse.StatusCode);
                Assert.Equal("Succeeded", putVnetResponse.Status);

                // Get Vnet
                var getVnetResponse = networkResourceProviderClient.VirtualNetworks.Get(resourceGroupName, vnetName);
                Assert.Equal(HttpStatusCode.OK, getVnetResponse.StatusCode);
                Assert.Equal(vnetName, getVnetResponse.VirtualNetwork.Name);
                Assert.NotNull(getVnetResponse.VirtualNetwork.ResourceGuid);
                Assert.Equal(Microsoft.Azure.Management.Resources.Models.ProvisioningState.Succeeded, getVnetResponse.VirtualNetwork.ProvisioningState);
                Assert.Equal("10.1.1.1", getVnetResponse.VirtualNetwork.DhcpOptions.DnsServers[0]);
                Assert.Equal("10.1.2.4", getVnetResponse.VirtualNetwork.DhcpOptions.DnsServers[1]);
                Assert.Equal("10.0.0.0/16", getVnetResponse.VirtualNetwork.AddressSpace.AddressPrefixes[0]);
                Assert.Equal(subnet1Name, getVnetResponse.VirtualNetwork.Subnets[0].Name);
                Assert.Equal(subnet2Name, getVnetResponse.VirtualNetwork.Subnets[1].Name);

                // Get all Vnets
                var getAllVnets = networkResourceProviderClient.VirtualNetworks.List(resourceGroupName);
                Assert.Equal(HttpStatusCode.OK, getAllVnets.StatusCode);
                Assert.Equal(vnetName, getAllVnets.VirtualNetworks[0].Name);
                Assert.Equal(Microsoft.Azure.Management.Resources.Models.ProvisioningState.Succeeded, getAllVnets.VirtualNetworks[0].ProvisioningState);
                Assert.Equal("10.0.0.0/16", getAllVnets.VirtualNetworks[0].AddressSpace.AddressPrefixes[0]);
                Assert.Equal(subnet1Name, getAllVnets.VirtualNetworks[0].Subnets[0].Name);
                Assert.Equal(subnet2Name, getAllVnets.VirtualNetworks[0].Subnets[1].Name);

                // Get all Vnets in a subscription
                var getAllVnetInSubscription = networkResourceProviderClient.VirtualNetworks.ListAll();
                Assert.Equal(HttpStatusCode.OK, getAllVnetInSubscription.StatusCode);
                Assert.Equal(vnetName, getAllVnetInSubscription.VirtualNetworks[0].Name);
                Assert.Equal(Microsoft.Azure.Management.Resources.Models.ProvisioningState.Succeeded, getAllVnetInSubscription.VirtualNetworks[0].ProvisioningState);
                Assert.Equal("10.0.0.0/16", getAllVnetInSubscription.VirtualNetworks[0].AddressSpace.AddressPrefixes[0]);
                Assert.Equal(subnet1Name, getAllVnetInSubscription.VirtualNetworks[0].Subnets[0].Name);
                Assert.Equal(subnet2Name, getAllVnetInSubscription.VirtualNetworks[0].Subnets[1].Name);

                // Delete Vnet
                var deleteVnetResponse = networkResourceProviderClient.VirtualNetworks.Delete(resourceGroupName, vnetName);
                Assert.Equal(HttpStatusCode.OK, deleteVnetResponse.StatusCode);

                // Get all Vnets
                getAllVnets = networkResourceProviderClient.VirtualNetworks.List(resourceGroupName);
                Assert.Equal(HttpStatusCode.OK, getAllVnets.StatusCode);
                Assert.Equal(0, getAllVnets.VirtualNetworks.Count);
            }
        }
    }
}