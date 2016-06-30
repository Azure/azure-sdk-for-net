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

    public class VirtualNetworkPeeringTests
    {
        [Fact]
        public void VirtualNetworkPeeringApiTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                
                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                // var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/virtualNetworks");
                var location = "westus";

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                string vnetName = TestUtilities.GenerateName();
                string remoteVirtualNetworkName = TestUtilities.GenerateName();
                string vnetPeeringName = TestUtilities.GenerateName();
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
                var putVnetResponse = networkManagementClient.VirtualNetworks.CreateOrUpdate(resourceGroupName, vnetName, vnet);
                Assert.Equal("Succeeded", putVnetResponse.ProvisioningState);

                // Get Vnet
                var getVnetResponse = networkManagementClient.VirtualNetworks.Get(resourceGroupName, vnetName);
                Assert.Equal(vnetName, getVnetResponse.Name);
                Assert.NotNull(getVnetResponse.ResourceGuid);
                Assert.Equal("Succeeded", getVnetResponse.ProvisioningState);

                // Get all Vnets
                var getAllVnets = networkManagementClient.VirtualNetworks.List(resourceGroupName);

                vnet.AddressSpace.AddressPrefixes[0] = "10.1.0.0/16";
                vnet.Subnets[0].AddressPrefix = "10.1.1.0/24";
                vnet.Subnets[1].AddressPrefix = "10.1.2.0/24";
                var remoteVirtualNetwork = networkManagementClient.VirtualNetworks.CreateOrUpdate(resourceGroupName, remoteVirtualNetworkName, vnet);

                // Get Peerings in the vnet
                var listPeering = networkManagementClient.VirtualNetworkPeerings.List(resourceGroupName, vnetName);
                Assert.Equal(0, listPeering.Count());

                var peering = new VirtualNetworkPeering();
                peering.Name = vnetPeeringName;
                peering.RemoteVirtualNetwork = new Microsoft.Azure.Management.Network.Models.SubResource();
                peering.RemoteVirtualNetwork.Id = remoteVirtualNetwork.Id;
                peering.AllowForwardedTraffic = true;
                peering.AllowVirtualNetworkAccess = false;

                // Put peering in the vnet
                var putPeering = networkManagementClient.VirtualNetworkPeerings.CreateOrUpdate(resourceGroupName, vnetName, vnetPeeringName, peering);

                Assert.NotNull(putPeering.Etag);
                Assert.Equal(vnetPeeringName, putPeering.Name);
                Assert.Equal(remoteVirtualNetwork.Id, putPeering.RemoteVirtualNetwork.Id);
                Assert.Equal(peering.AllowForwardedTraffic, putPeering.AllowForwardedTraffic);
                Assert.Equal(peering.AllowVirtualNetworkAccess, putPeering.AllowVirtualNetworkAccess);
                Assert.Equal(false, putPeering.UseRemoteGateways);
                Assert.Equal(false, putPeering.AllowGatewayTransit);
                Assert.Equal(VirtualNetworkPeeringState.Initiated, putPeering.PeeringState);

                // get peering
                var getPeering = networkManagementClient.VirtualNetworkPeerings.Get(resourceGroupName, vnetName, vnetPeeringName);

                Assert.Equal(getPeering.Etag, putPeering.Etag);
                Assert.Equal(vnetPeeringName, getPeering.Name);
                Assert.Equal(remoteVirtualNetwork.Id, getPeering.RemoteVirtualNetwork.Id);
                Assert.Equal(peering.AllowForwardedTraffic, getPeering.AllowForwardedTraffic);
                Assert.Equal(peering.AllowVirtualNetworkAccess, getPeering.AllowVirtualNetworkAccess);
                Assert.Equal(false, getPeering.UseRemoteGateways);
                Assert.Equal(false, getPeering.AllowGatewayTransit);
                Assert.Equal(VirtualNetworkPeeringState.Initiated, getPeering.PeeringState);

                // list peering
                listPeering = networkManagementClient.VirtualNetworkPeerings.List(resourceGroupName, vnetName);

                Assert.Equal(1, listPeering.Count());
                Assert.Equal(listPeering.ElementAt(0).Etag, putPeering.Etag);
                Assert.Equal(vnetPeeringName, listPeering.ElementAt(0).Name);
                Assert.Equal(remoteVirtualNetwork.Id, listPeering.ElementAt(0).RemoteVirtualNetwork.Id);
                Assert.Equal(peering.AllowForwardedTraffic, listPeering.ElementAt(0).AllowForwardedTraffic);
                Assert.Equal(peering.AllowVirtualNetworkAccess, listPeering.ElementAt(0).AllowVirtualNetworkAccess);
                Assert.Equal(false, listPeering.ElementAt(0).UseRemoteGateways);
                Assert.Equal(false, listPeering.ElementAt(0).AllowGatewayTransit);
                Assert.Equal(VirtualNetworkPeeringState.Initiated, listPeering.ElementAt(0).PeeringState);

                // delete peering
                networkManagementClient.VirtualNetworkPeerings.Delete(resourceGroupName, vnetName, vnetPeeringName);
                listPeering = networkManagementClient.VirtualNetworkPeerings.List(resourceGroupName, vnetName);
                Assert.Equal(0, listPeering.Count());

                // Delete Vnet
                networkManagementClient.VirtualNetworks.Delete(resourceGroupName, vnetName);
                networkManagementClient.VirtualNetworks.Delete(resourceGroupName, remoteVirtualNetworkName);

                // Get all Vnets
                getAllVnets = networkManagementClient.VirtualNetworks.List(resourceGroupName);
                Assert.Equal(0, getAllVnets.Count());
            }
        }
    }
}