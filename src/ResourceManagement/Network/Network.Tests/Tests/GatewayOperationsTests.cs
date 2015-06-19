using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;
using Microsoft.Azure;
using System;
using Microsoft.Azure.Management.Network;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.Management.Network.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Networks.Tests
{
    public class GatewayOperationsTests
    {
        // Tests Resource:-VirtualNetworkGateway 6 APIs:-
        [Fact]
        public void VirtualNetworkGatewayOperationsApisTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(handler);
                var networkResourceProviderClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);

                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/virtualnetworkgateways");

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                // 1. CreateVirtualNetworkGateway API

                // A. Prerequisite:- Create PublicIPAddress(Gateway Ip) using Put PublicIpAddress API
                string publicIpName = TestUtilities.GenerateName();
                string domainNameLabel = TestUtilities.GenerateName();

                var nic1publicIp = TestHelper.CreateDefaultPublicIpAddress(publicIpName, resourceGroupName, domainNameLabel, location, networkResourceProviderClient);
                Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);


                // B.Prerequisite:- Create Virtual Network using Put VirtualNetwork API

                string vnetName = TestUtilities.GenerateName();
                string subnetName = "GatewaySubnet";

                var virtualNetwork = TestHelper.CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location, networkResourceProviderClient);

                var getSubnetResponse = networkResourceProviderClient.Subnets.Get(resourceGroupName, vnetName, subnetName);
                Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Subnet.Id);

                // C. CreateVirtualNetworkGateway API
                string virtualNetworkGatewayName = TestUtilities.GenerateName();
                string ipConfigName = TestUtilities.GenerateName();

                var virtualNetworkGateway = new VirtualNetworkGateway()
                {
                    Location = location,
                    Name = virtualNetworkGatewayName,
                    Tags = new Dictionary<string, string>()
                        {
                           {"key","value"}
                        },
                    EnableBgp = false,
                    GatewayType = VirtualNetworkGatewayType.Vpn,
                    VpnType = VpnType.RouteBased,
                    IpConfigurations = new List<VirtualNetworkGatewayIpConfiguration>()
                    {
                        new VirtualNetworkGatewayIpConfiguration()
                        {
                             Name = ipConfigName,
                             PrivateIpAllocationMethod = IpAllocationMethod.Dynamic,
                             PublicIpAddress = new ResourceId()
                             {
                                 Id = nic1publicIp.Id
                             },
                             Subnet = new ResourceId()
                             {
                                 Id = getSubnetResponse.Subnet.Id
                             }
                        }
                    }
                };

                var putVirtualNetworkGatewayResponse = networkResourceProviderClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, virtualNetworkGateway);
                Assert.Equal(HttpStatusCode.OK, putVirtualNetworkGatewayResponse.StatusCode);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.Status);

                // 2. GetVirtualNetworkGateway API
                var getVirtualNetworkGatewayResponse = networkResourceProviderClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);
                Assert.Equal(HttpStatusCode.OK, getVirtualNetworkGatewayResponse.StatusCode);
                Console.WriteLine("Gateway details:- GatewayLocation: {0}, GatewayId:{1}, GatewayName={2}, GatewayType={3}, VpnType={4}",
                    getVirtualNetworkGatewayResponse.VirtualNetworkGateway.Location,
                    getVirtualNetworkGatewayResponse.VirtualNetworkGateway.Id, getVirtualNetworkGatewayResponse.VirtualNetworkGateway.Name,
                    getVirtualNetworkGatewayResponse.VirtualNetworkGateway.GatewayType, getVirtualNetworkGatewayResponse.VirtualNetworkGateway.VpnType);
                //Assert.Equal(VirtualNetworkGatewayType.Vpn, getVirtualNetworkGatewayResponse.VirtualNetworkGateway.GatewayType);
                //Assert.Equal(VpnType.RouteBased, getVirtualNetworkGatewayResponse.VirtualNetworkGateway.VpnType);

                // 3A. ResetVirtualNetworkGateway API
                var resetVirtualNetworkGatewayResponse = networkResourceProviderClient.VirtualNetworkGateways.Reset(resourceGroupName, virtualNetworkGatewayName, virtualNetworkGateway);
                Assert.Equal(HttpStatusCode.OK, resetVirtualNetworkGatewayResponse.StatusCode);
                Assert.Equal("Succeeded", resetVirtualNetworkGatewayResponse.Status);

                // 3B. GetVirtualNetworkgateway API after ResetVirtualNetworkGateway API was called
                getVirtualNetworkGatewayResponse = networkResourceProviderClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);
                Assert.Equal(HttpStatusCode.OK, getVirtualNetworkGatewayResponse.StatusCode);
                Console.WriteLine("Gateway details:- GatewayLocation: {0}, GatewayId:{1}, GatewayName={2}, GatewayType={3} ",
                    getVirtualNetworkGatewayResponse.VirtualNetworkGateway.Location,
                    getVirtualNetworkGatewayResponse.VirtualNetworkGateway.Id, getVirtualNetworkGatewayResponse.VirtualNetworkGateway.Name,
                    getVirtualNetworkGatewayResponse.VirtualNetworkGateway.GatewayType);

                // 4. ListVitualNetworkGateways API
                var listVirtualNetworkGatewayResponse = networkResourceProviderClient.VirtualNetworkGateways.List(resourceGroupName);
                Assert.Equal(HttpStatusCode.OK, listVirtualNetworkGatewayResponse.StatusCode);
                Console.WriteLine("ListVirtualNetworkGateways count ={0} ", listVirtualNetworkGatewayResponse.VirtualNetworkGateways.Count);
                Assert.Equal(1, listVirtualNetworkGatewayResponse.VirtualNetworkGateways.Count);

                // 5A. DeleteVirtualNetworkGateway API
                var deleteVirtualNetworkGatewayResponse = networkResourceProviderClient.VirtualNetworkGateways.Delete(resourceGroupName, virtualNetworkGatewayName);
                Assert.Equal(HttpStatusCode.OK, deleteVirtualNetworkGatewayResponse.StatusCode);

                // 5B. ListVitualNetworkGateways API after deleting VirtualNetworkGateway
                listVirtualNetworkGatewayResponse = networkResourceProviderClient.VirtualNetworkGateways.List(resourceGroupName);
                Assert.Equal(HttpStatusCode.OK, listVirtualNetworkGatewayResponse.StatusCode);
                Console.WriteLine("ListVirtualNetworkGateways count ={0} ", listVirtualNetworkGatewayResponse.VirtualNetworkGateways.Count);
                Assert.Equal(0, listVirtualNetworkGatewayResponse.VirtualNetworkGateways.Count);
            }
        }

        // Tests Resource:-LocalNetworkGateway 5 APIs:-
        [Fact]
        public void LocalNettworkGatewayOperationsApisTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(handler);
                var networkResourceProviderClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);

                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/localNetworkGateways");

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                // 1. CreateLocalNetworkGateway API
                string localNetworkGatewayName = TestUtilities.GenerateName();
                string gatewayIp = "192.168.3.4";
                string addressPrefixes = "192.168.0.0/16";
                string newAddressPrefixes = "200.168.0.0/16";

                var localNetworkGateway = new LocalNetworkGateway()
                {
                    Location = location,
                    Name = localNetworkGatewayName,
                    Tags = new Dictionary<string, string>()
                        {
                           {"test","value"}
                        },
                    GatewayIpAddress = gatewayIp,
                    LocalNetworkAddressSpace = new AddressSpace()
                    {
                        AddressPrefixes = new List<string>()
                        {
                            addressPrefixes,
                        }
                    }
                };

                var putLocalNetworkGatewayResponse = networkResourceProviderClient.LocalNetworkGateways.CreateOrUpdate(resourceGroupName, localNetworkGatewayName, localNetworkGateway);
                Assert.Equal(HttpStatusCode.OK, putLocalNetworkGatewayResponse.StatusCode);
                Assert.Equal("Succeeded", putLocalNetworkGatewayResponse.Status);

                // 2. GetLocalNetworkGateway API
                var getLocalNetworkGatewayResponse = networkResourceProviderClient.LocalNetworkGateways.Get(resourceGroupName, localNetworkGatewayName);
                Assert.Equal(HttpStatusCode.OK, getLocalNetworkGatewayResponse.StatusCode);
                getLocalNetworkGatewayResponse.LocalNetworkGateway.Location = location;
                Console.WriteLine("Local Network Gateway details:- GatewayLocation: {0}, GatewayId:{1}, GatewayName={2} GatewayIpAddress={3} LocalNetworkAddressSpace={4}",
                    getLocalNetworkGatewayResponse.LocalNetworkGateway.Location,
                    getLocalNetworkGatewayResponse.LocalNetworkGateway.Id, getLocalNetworkGatewayResponse.LocalNetworkGateway.Name,
                    getLocalNetworkGatewayResponse.LocalNetworkGateway.GatewayIpAddress, getLocalNetworkGatewayResponse.LocalNetworkGateway.LocalNetworkAddressSpace.AddressPrefixes[0].ToString());
                Assert.Equal(gatewayIp, getLocalNetworkGatewayResponse.LocalNetworkGateway.GatewayIpAddress);
                Assert.Equal(addressPrefixes, getLocalNetworkGatewayResponse.LocalNetworkGateway.LocalNetworkAddressSpace.AddressPrefixes[0].ToString());

                // 3A. UpdateLocalNetworkgateway API :- LocalNetworkGateway LocalNetworkAddressSpace from "192.168.0.0/16" => "200.168.0.0/16"
                getLocalNetworkGatewayResponse.LocalNetworkGateway.LocalNetworkAddressSpace = new AddressSpace()
                {
                    AddressPrefixes = new List<string>()
                        {
                            newAddressPrefixes,
                        }
                };

                putLocalNetworkGatewayResponse = networkResourceProviderClient.LocalNetworkGateways.CreateOrUpdate(resourceGroupName, localNetworkGatewayName, getLocalNetworkGatewayResponse.LocalNetworkGateway);
                Assert.Equal(HttpStatusCode.OK, putLocalNetworkGatewayResponse.StatusCode);
                Assert.Equal("Succeeded", putLocalNetworkGatewayResponse.Status);

                // 3B. GetLocalNetworkGateway API after Updating LocalNetworkGateway LocalNetworkAddressSpace from "192.168.0.0/16" => "200.168.0.0/16"
                getLocalNetworkGatewayResponse = networkResourceProviderClient.LocalNetworkGateways.Get(resourceGroupName, localNetworkGatewayName);
                Assert.Equal(HttpStatusCode.OK, getLocalNetworkGatewayResponse.StatusCode);
                getLocalNetworkGatewayResponse.LocalNetworkGateway.Location = location;
                Console.WriteLine("Local Network Gateway details:- GatewayLocation: {0}, GatewayId:{1}, GatewayName={2} GatewayIpAddress={3} LocalNetworkAddressSpace={4}",
                    getLocalNetworkGatewayResponse.LocalNetworkGateway.Location, getLocalNetworkGatewayResponse.LocalNetworkGateway.Id,
                    getLocalNetworkGatewayResponse.LocalNetworkGateway.Name, getLocalNetworkGatewayResponse.LocalNetworkGateway.GatewayIpAddress,
                    getLocalNetworkGatewayResponse.LocalNetworkGateway.LocalNetworkAddressSpace.AddressPrefixes[0].ToString());
                Assert.Equal(newAddressPrefixes, getLocalNetworkGatewayResponse.LocalNetworkGateway.LocalNetworkAddressSpace.AddressPrefixes[0].ToString());

                // 4. ListLocalNetworkGateways API
                var listLocalNetworkGatewayResponse = networkResourceProviderClient.LocalNetworkGateways.List(resourceGroupName);
                Assert.Equal(HttpStatusCode.OK, listLocalNetworkGatewayResponse.StatusCode);
                Console.WriteLine("ListLocalNetworkGateways count ={0} ", listLocalNetworkGatewayResponse.LocalNetworkGateways.Count);
                Assert.Equal(1, listLocalNetworkGatewayResponse.LocalNetworkGateways.Count);

                // 5A. DeleteLocalNetworkGateway API
                var deleteLocalNetworkGatewayResponse = networkResourceProviderClient.LocalNetworkGateways.Delete(resourceGroupName, localNetworkGatewayName);
                Assert.Equal(HttpStatusCode.OK, deleteLocalNetworkGatewayResponse.StatusCode);

                // 5B. ListLocalNetworkGateways API after DeleteLocalNetworkGateway API was called
                listLocalNetworkGatewayResponse = networkResourceProviderClient.LocalNetworkGateways.List(resourceGroupName);
                Assert.Equal(HttpStatusCode.OK, listLocalNetworkGatewayResponse.StatusCode);
                Console.WriteLine("ListLocalNetworkGateways count ={0} ", listLocalNetworkGatewayResponse.LocalNetworkGateways.Count);
                Assert.Equal(0, listLocalNetworkGatewayResponse.LocalNetworkGateways.Count);
            }
        }

        // Tests Resource:-VirtualNetworkGatewayConnection 5 APIs:-
        [Fact]
        public void VirtualNetworkGatewayConnectionOperationsApisTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(handler);
                var networkResourceProviderClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);

                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/connections");

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                // 1. CreateVirtualNetworkGatewayConnection API

                // A. Prerequisite:- Create VirtualNetworkGateway1
                // a. Create PublicIPAddress(Gateway Ip) using Put PublicIpAddress API
                string publicIpName = TestUtilities.GenerateName();
                string domainNameLabel = TestUtilities.GenerateName();

                var nic1publicIp = TestHelper.CreateDefaultPublicIpAddress(publicIpName, resourceGroupName, domainNameLabel, location, networkResourceProviderClient);
                Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);


                // b. Create Virtual Network using Put VirtualNetwork API
                string vnetName = TestUtilities.GenerateName();
                string subnetName = "GatewaySubnet";

                var virtualNetwork = TestHelper.CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location, networkResourceProviderClient);

                var getSubnetResponse = networkResourceProviderClient.Subnets.Get(resourceGroupName, vnetName, subnetName);
                Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Subnet.Id);

                //c. CreateVirtualNetworkGateway API
                string virtualNetworkGatewayName = TestUtilities.GenerateName();
                string ipConfigName = TestUtilities.GenerateName();

                var virtualNetworkGateway = new VirtualNetworkGateway()
                {
                    Location = location,
                    Name = virtualNetworkGatewayName,
                    Tags = new Dictionary<string, string>()
                        {
                           {"key","value"}
                        },
                    EnableBgp = false,
                    GatewayType = VirtualNetworkGatewayType.Vpn,
                    VpnType = VpnType.RouteBased,
                    IpConfigurations = new List<VirtualNetworkGatewayIpConfiguration>()
                    {
                        new VirtualNetworkGatewayIpConfiguration()
                        {
                             Name = ipConfigName,
                             PrivateIpAllocationMethod = IpAllocationMethod.Dynamic,
                             PublicIpAddress = new ResourceId()
                             {
                                 Id = nic1publicIp.Id
                             },
                             Subnet = new ResourceId()
                             {
                                 Id = getSubnetResponse.Subnet.Id
                             }
                        }
                    }
                };

                var putVirtualNetworkGatewayResponse = networkResourceProviderClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, virtualNetworkGateway);
                Assert.Equal(HttpStatusCode.OK, putVirtualNetworkGatewayResponse.StatusCode);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.Status);
                var getVirtualNetworkGatewayResponse = networkResourceProviderClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);

                //B. Create LocalNetworkGateway2
                string localNetworkGatewayName = TestUtilities.GenerateName();
                string gatewayIp = "192.168.3.4";

                var localNetworkGateway = new LocalNetworkGateway()
                {
                    Location = location,
                    Name = localNetworkGatewayName,
                    Tags = new Dictionary<string, string>()
                        {
                           {"test","value"}
                        },
                    GatewayIpAddress = gatewayIp,
                    LocalNetworkAddressSpace = new AddressSpace()
                    {
                        AddressPrefixes = new List<string>()
                        {
                            "192.168.0.0/16",
                        }
                    }
                };

                var putLocalNetworkGatewayResponse = networkResourceProviderClient.LocalNetworkGateways.CreateOrUpdate(resourceGroupName, localNetworkGatewayName, localNetworkGateway);
                Assert.Equal(HttpStatusCode.OK, putLocalNetworkGatewayResponse.StatusCode);
                Assert.Equal("Succeeded", putLocalNetworkGatewayResponse.Status);
                var getLocalNetworkGatewayResponse = networkResourceProviderClient.LocalNetworkGateways.Get(resourceGroupName, localNetworkGatewayName);
                getLocalNetworkGatewayResponse.LocalNetworkGateway.Location = location;

                // C. CreaetVirtualNetworkGatewayConnection API
                string VirtualNetworkGatewayConnectionName = TestUtilities.GenerateName();
                var virtualNetworkGatewayConneciton = new VirtualNetworkGatewayConnection()
                {
                    Location = location,
                    Name = VirtualNetworkGatewayConnectionName,
                    VirtualNetworkGateway1 = getVirtualNetworkGatewayResponse.VirtualNetworkGateway,
                    LocalNetworkGateway2 = getLocalNetworkGatewayResponse.LocalNetworkGateway,
                    ConnectionType = VirtualNetworkGatewayConnectionType.IPsec,
                    RoutingWeight = 3,
                    SharedKey = "abc"
                };
                var putVirtualNetworkGatewayConnectionResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.CreateOrUpdate(resourceGroupName, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConneciton);
                Assert.Equal(HttpStatusCode.OK, putVirtualNetworkGatewayConnectionResponse.StatusCode);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayConnectionResponse.Status);

                // 2. GetVirtualNetworkGatewayConnection API
                var getVirtualNetworkGatewayConnectionResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.Get(resourceGroupName, VirtualNetworkGatewayConnectionName);
                Assert.Equal(HttpStatusCode.OK, getVirtualNetworkGatewayConnectionResponse.StatusCode);
                Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, ConnectionType={6} RoutingWeight={7} SharedKey={8}",
                    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.Location, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.Id,
                    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.Name,
                    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.VirtualNetworkGateway1.Id,
                    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.LocalNetworkGateway2.Id,
                    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.ConnectionType, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.RoutingWeight,
                    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.SharedKey);
                Assert.Equal(VirtualNetworkGatewayConnectionType.IPsec, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.ConnectionType);
                Assert.Equal(3, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.RoutingWeight);
                Assert.Equal("abc", getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.SharedKey);

                // 3A. UpdateVirtualNetworkGatewayConnection API :- RoutingWeight = 3 => 4, SharedKey = "abc"=> "xyz"
                virtualNetworkGatewayConneciton.RoutingWeight = 4;
                virtualNetworkGatewayConneciton.SharedKey = "xyz";

                putVirtualNetworkGatewayConnectionResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.CreateOrUpdate(resourceGroupName, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConneciton);
                Assert.Equal(HttpStatusCode.OK, putVirtualNetworkGatewayConnectionResponse.StatusCode);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayConnectionResponse.Status);

                // 3B. GetVirtualNetworkGatewayConnection API after Updating RoutingWeight = 3 => 4, SharedKey = "abc"=> "xyz"
                getVirtualNetworkGatewayConnectionResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.Get(resourceGroupName, VirtualNetworkGatewayConnectionName);
                Assert.Equal(HttpStatusCode.OK, getVirtualNetworkGatewayConnectionResponse.StatusCode);
                Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, ConnectionType={6} RoutingWeight={7} SharedKey={8}",
                    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.Location, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.Id,
                    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.Name,
                    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.VirtualNetworkGateway1.Id,
                    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.LocalNetworkGateway2.Id,
                    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.ConnectionType, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.RoutingWeight,
                    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.SharedKey);
                Assert.Equal(4, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.RoutingWeight);
                Assert.Equal("xyz", getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.SharedKey);

                // 4. ListVitualNetworkGatewayConnections API
                var listVirtualNetworkGatewayConectionResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.List(resourceGroupName);
                Assert.Equal(HttpStatusCode.OK, listVirtualNetworkGatewayConectionResponse.StatusCode);
                Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.VirtualNetworkGatewayConnections.Count);
                Assert.Equal(1, listVirtualNetworkGatewayConectionResponse.VirtualNetworkGatewayConnections.Count);

                // 5A. DeleteVirtualNetworkGatewayConnection API
                var deleteVirtualNetworkGatewayConnectionResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.Delete(resourceGroupName, VirtualNetworkGatewayConnectionName);
                Assert.Equal(HttpStatusCode.OK, deleteVirtualNetworkGatewayConnectionResponse.StatusCode);

                // 5B. ListVitualNetworkGatewayConnections API after DeleteVirtualNetworkGatewayConnection API called
                listVirtualNetworkGatewayConectionResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.List(resourceGroupName);
                Assert.Equal(HttpStatusCode.OK, listVirtualNetworkGatewayConectionResponse.StatusCode);
                Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.VirtualNetworkGatewayConnections.Count);
                Assert.Equal(0, listVirtualNetworkGatewayConectionResponse.VirtualNetworkGatewayConnections.Count);

            }
        }

        // Tests Resource:-VirtualNetworkGatewayConnectionSharedKey 3 APIs:-
        [Fact]
        public void VirtualNetworkGatewayConnectionSharedKeyOperationsApisTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = UndoContext.Current)
            {
                context.Start();

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(handler);
                var networkResourceProviderClient = NetworkManagementTestUtilities.GetNetworkResourceProviderClient(handler);

                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/connections");

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });


                // 1. SetVirtualNetworkGatewayConnectionSharedKey API

                // Pre-requsite:- CreateVirtualNetworkGatewayConnection first

                // Create VirtualNetworkGateway1

                // a. Create PublicIPAddress(Gateway Ip) using Put PublicIpAddress API
                string publicIpName = TestUtilities.GenerateName();
                string domainNameLabel = TestUtilities.GenerateName();

                var nic1publicIp = TestHelper.CreateDefaultPublicIpAddress(publicIpName, resourceGroupName, domainNameLabel, location, networkResourceProviderClient);
                Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);

                // b. Create Virtual Network using Put VirtualNetwork API
                string vnetName = TestUtilities.GenerateName();
                string subnetName = "GatewaySubnet";

                var virtualNetwork = TestHelper.CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location, networkResourceProviderClient);

                var getSubnetResponse = networkResourceProviderClient.Subnets.Get(resourceGroupName, vnetName, subnetName);
                Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Subnet.Id);

                // c. CreateVirtualNetworkGateway API
                string virtualNetworkGatewayName = TestUtilities.GenerateName();
                string ipConfigName = TestUtilities.GenerateName();

                var virtualNetworkGateway = new VirtualNetworkGateway()
                {
                    Location = location,
                    Name = virtualNetworkGatewayName,
                    Tags = new Dictionary<string, string>()
                        {
                           {"key","value"}
                        },
                    EnableBgp = false,
                    GatewayType = VirtualNetworkGatewayType.Vpn,
                    VpnType = VpnType.RouteBased,
                    IpConfigurations = new List<VirtualNetworkGatewayIpConfiguration>()
                    {
                        new VirtualNetworkGatewayIpConfiguration()
                        {
                             Name = ipConfigName,
                             PrivateIpAllocationMethod = IpAllocationMethod.Dynamic,
                             PublicIpAddress = new ResourceId()
                             {
                                 Id = nic1publicIp.Id
                             },
                             Subnet = new ResourceId()
                             {
                                 Id = getSubnetResponse.Subnet.Id
                             }
                        }
                    }
                };

                var putVirtualNetworkGatewayResponse = networkResourceProviderClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, virtualNetworkGateway);
                Assert.Equal(HttpStatusCode.OK, putVirtualNetworkGatewayResponse.StatusCode);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.Status);
                var getVirtualNetworkGatewayResponse = networkResourceProviderClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);

                // Create LocalNetworkGateway2
                string localNetworkGatewayName = TestUtilities.GenerateName();
                string gatewayIp = "192.168.3.4";

                var localNetworkGateway = new LocalNetworkGateway()
                {
                    Location = location,
                    Name = localNetworkGatewayName,
                    Tags = new Dictionary<string, string>()
                        {
                           {"test","value"}
                        },
                    GatewayIpAddress = gatewayIp,
                    LocalNetworkAddressSpace = new AddressSpace()
                    {
                        AddressPrefixes = new List<string>()
                        {
                            "192.168.0.0/16",
                        }
                    }
                };

                var putLocalNetworkGatewayResponse = networkResourceProviderClient.LocalNetworkGateways.CreateOrUpdate(resourceGroupName, localNetworkGatewayName, localNetworkGateway);
                Assert.Equal(HttpStatusCode.OK, putLocalNetworkGatewayResponse.StatusCode);
                Assert.Equal("Succeeded", putLocalNetworkGatewayResponse.Status);
                var getLocalNetworkGatewayResponse = networkResourceProviderClient.LocalNetworkGateways.Get(resourceGroupName, localNetworkGatewayName);
                getLocalNetworkGatewayResponse.LocalNetworkGateway.Location = location;

                // CreaetVirtualNetworkGatewayConnection API
                string VirtualNetworkGatewayConnectionName = TestUtilities.GenerateName();
                var virtualNetworkGatewayConneciton = new VirtualNetworkGatewayConnection()
                {
                    Location = location,
                    Name = VirtualNetworkGatewayConnectionName,
                    VirtualNetworkGateway1 = getVirtualNetworkGatewayResponse.VirtualNetworkGateway,
                    LocalNetworkGateway2 = getLocalNetworkGatewayResponse.LocalNetworkGateway,
                    ConnectionType = VirtualNetworkGatewayConnectionType.IPsec,
                    RoutingWeight = 3,
                    SharedKey = "abc"
                };
                var putVirtualNetworkGatewayConnectionResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.CreateOrUpdate(resourceGroupName, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConneciton);
                Assert.Equal(HttpStatusCode.OK, putVirtualNetworkGatewayConnectionResponse.StatusCode);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayConnectionResponse.Status);

                // SetVirtualNetworkGatewayConnectionSharedKey API on created connection above:- virtualNetworkGatewayConneciton
                string connectionSharedKeyName = VirtualNetworkGatewayConnectionName;
                var connectionSharedKey = new ConnectionSharedKey()
                {
                    Value = "TestSharedKeyValue"
                };

                var putConnectionSharedKeyResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.SetSharedKey(resourceGroupName, connectionSharedKeyName, connectionSharedKey);
                Assert.Equal(HttpStatusCode.OK, putConnectionSharedKeyResponse.StatusCode);
                Assert.Equal("Succeeded", putConnectionSharedKeyResponse.Status);

                // 2. GetVirtualNetworkGatewayConnectionSharedKey API
                var getconnectionSharedKeyResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.GetSharedKey(resourceGroupName, connectionSharedKeyName);
                Assert.Equal(HttpStatusCode.OK, getconnectionSharedKeyResponse.StatusCode);
                Console.WriteLine("ConnectionSharedKey details:- Value: {0}", getconnectionSharedKeyResponse.Value);

                // 3A. VirtualNetworkGatewayConnectionResetSharedKey API
                var connectionResetSharedKey = new ConnectionResetSharedKey()
                {
                    KeyLength = 50
                };
                var resetConnectionResetSharedKeyResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.ResetSharedKey(resourceGroupName, connectionSharedKeyName, connectionResetSharedKey);
                Assert.Equal(HttpStatusCode.OK, resetConnectionResetSharedKeyResponse.StatusCode);
                Assert.Equal("Succeeded", resetConnectionResetSharedKeyResponse.Status);

                // 3B. GetVirtualNetworkGatewayConnectionSharedKey API after VirtualNetworkGatewayConnectionResetSharedKey API was called
                getconnectionSharedKeyResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.GetSharedKey(resourceGroupName, connectionSharedKeyName);
                Assert.Equal(HttpStatusCode.OK, getconnectionSharedKeyResponse.StatusCode);
                Console.WriteLine("ConnectionSharedKey details:- Value: {0}", getconnectionSharedKeyResponse.Value);
            }
        }
    }
}