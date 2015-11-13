using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;
using System;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;

namespace Networks.Tests
{
    using System.Linq;

    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    using SubResource = Microsoft.Azure.Management.Network.Models.SubResource;

    public class GatewayOperationsTests
    {
        // Tests Resource:-VirtualNetworkGateway 6 APIs:-
        [Fact(Skip = "TODO: Autorest")]
        public void VirtualNetworkGatewayOperationsApisTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = MockContext.Start())
            {
                

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/virtualnetworkgateways");

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });

                // 1. CreateVirtualNetworkGateway API

                // A. Prerequisite:- Create PublicIPAddress(Gateway Ip) using Put PublicIPAddress API
                string publicIpName = TestUtilities.GenerateName();
                string domainNameLabel = TestUtilities.GenerateName();

                var nic1publicIp = TestHelper.CreateDefaultPublicIpAddress(publicIpName, resourceGroupName, domainNameLabel, location, networkManagementClient);
                Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);


                // B.Prerequisite:- Create Virtual Network using Put VirtualNetwork API

                string vnetName = TestUtilities.GenerateName();
                string subnetName = "GatewaySubnet";

                var virtualNetwork = TestHelper.CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location, networkManagementClient);

                var getSubnetResponse = networkManagementClient.Subnets.Get(resourceGroupName, vnetName, subnetName);
                Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Id);

                // C. CreateVirtualNetworkGateway API
                string virtualNetworkGatewayName = TestUtilities.GenerateName();
                string ipConfigName = TestUtilities.GenerateName();

                var virtualNetworkGateway = new VirtualNetworkGateway()
                {
                    Location = location,
                    Tags = new Dictionary<string, string>()
                        {
                           {"key","value"}
                        },
                    EnableBgp = false,
                    GatewayDefaultSite = null,
                    GatewayType = VirtualNetworkGatewayType.Vpn,
                    VpnType = VpnType.RouteBased,
                    IpConfigurations = new List<VirtualNetworkGatewayIPConfiguration>()
                    {
                        new VirtualNetworkGatewayIPConfiguration()
                        {
                             Name = ipConfigName,
                             PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                             PublicIPAddress = new SubResource()
                             {
                                 Id = nic1publicIp.Id
                             },
                             Subnet = new SubResource()
                             {
                                 Id = getSubnetResponse.Id
                             }
                        }
                    }
                };

                var putVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, virtualNetworkGateway);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.ProvisioningState);

                // 2. GetVirtualNetworkGateway API
                var getVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);
                Console.WriteLine("Gateway details:- GatewayLocation: {0}, GatewayId:{1}, GatewayName={2}, GatewayType={3}, VpnType={4}",
                    getVirtualNetworkGatewayResponse.Location,
                    getVirtualNetworkGatewayResponse.Id, getVirtualNetworkGatewayResponse.Name,
                    getVirtualNetworkGatewayResponse.GatewayType, getVirtualNetworkGatewayResponse.VpnType);
                //Assert.Equal(VirtualNetworkGatewayType.Vpn, getVirtualNetworkGatewayResponse.GatewayType);
                //Assert.Equal(VpnType.RouteBased, getVirtualNetworkGatewayResponse.VpnType);

                // 3A. ResetVirtualNetworkGateway API
                var resetVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.Reset(resourceGroupName, virtualNetworkGatewayName, virtualNetworkGateway);
                Assert.Equal("Succeeded", resetVirtualNetworkGatewayResponse.ProvisioningState);

                // 3B. GetVirtualNetworkgateway API after ResetVirtualNetworkGateway API was called
                getVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);
                
                Console.WriteLine("Gateway details:- GatewayLocation: {0}, GatewayId:{1}, GatewayName={2}, GatewayType={3} ",
                    getVirtualNetworkGatewayResponse.Location,
                    getVirtualNetworkGatewayResponse.Id, getVirtualNetworkGatewayResponse.Name,
                    getVirtualNetworkGatewayResponse.GatewayType);

                // 4. ListVitualNetworkGateways API
                var listVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.List(resourceGroupName);
                Console.WriteLine("ListVirtualNetworkGateways count ={0} ", listVirtualNetworkGatewayResponse.Count());
                Assert.Equal(1, listVirtualNetworkGatewayResponse.Count());

                // 5A. DeleteVirtualNetworkGateway API
                networkManagementClient.VirtualNetworkGateways.Delete(resourceGroupName, virtualNetworkGatewayName);
                
                // 5B. ListVitualNetworkGateways API after deleting VirtualNetworkGateway
                listVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.List(resourceGroupName);
                
                Console.WriteLine("ListVirtualNetworkGateways count ={0} ", listVirtualNetworkGatewayResponse.Count());
                Assert.Equal(0, listVirtualNetworkGatewayResponse.Count());
            }
        }

        // Tests Resource:-LocalNetworkGateway 5 APIs:-
        [Fact(Skip = "TODO: Autorest")]
        public void LocalNettworkGatewayOperationsApisTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = MockContext.Start())
            {
                

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

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

                var putLocalNetworkGatewayResponse = networkManagementClient.LocalNetworkGateways.CreateOrUpdate(resourceGroupName, localNetworkGatewayName, localNetworkGateway);
                Assert.Equal("Succeeded", putLocalNetworkGatewayResponse.ProvisioningState);

                // 2. GetLocalNetworkGateway API
                var getLocalNetworkGatewayResponse = networkManagementClient.LocalNetworkGateways.Get(resourceGroupName, localNetworkGatewayName);
                getLocalNetworkGatewayResponse.Location = location;
                Console.WriteLine("Local Network Gateway details:- GatewayLocation: {0}, GatewayId:{1}, GatewayName={2} GatewayIpAddress={3} LocalNetworkAddressSpace={4}",
                    getLocalNetworkGatewayResponse.Location,
                    getLocalNetworkGatewayResponse.Id, getLocalNetworkGatewayResponse.Name,
                    getLocalNetworkGatewayResponse.GatewayIpAddress, getLocalNetworkGatewayResponse.LocalNetworkAddressSpace.AddressPrefixes[0].ToString());
                Assert.Equal(gatewayIp, getLocalNetworkGatewayResponse.GatewayIpAddress);
                Assert.Equal(addressPrefixes, getLocalNetworkGatewayResponse.LocalNetworkAddressSpace.AddressPrefixes[0].ToString());

                // 3A. UpdateLocalNetworkgateway API :- LocalNetworkGateway LocalNetworkAddressSpace from "192.168.0.0/16" => "200.168.0.0/16"
                getLocalNetworkGatewayResponse.LocalNetworkAddressSpace = new AddressSpace()
                {
                    AddressPrefixes = new List<string>()
                        {
                            newAddressPrefixes,
                        }
                };

                putLocalNetworkGatewayResponse = networkManagementClient.LocalNetworkGateways.CreateOrUpdate(resourceGroupName, localNetworkGatewayName, getLocalNetworkGatewayResponse);
                Assert.Equal("Succeeded", putLocalNetworkGatewayResponse.ProvisioningState);

                // 3B. GetLocalNetworkGateway API after Updating LocalNetworkGateway LocalNetworkAddressSpace from "192.168.0.0/16" => "200.168.0.0/16"
                getLocalNetworkGatewayResponse = networkManagementClient.LocalNetworkGateways.Get(resourceGroupName, localNetworkGatewayName);
                getLocalNetworkGatewayResponse.Location = location;
                Console.WriteLine("Local Network Gateway details:- GatewayLocation: {0}, GatewayId:{1}, GatewayName={2} GatewayIpAddress={3} LocalNetworkAddressSpace={4}",
                    getLocalNetworkGatewayResponse.Location, getLocalNetworkGatewayResponse.Id,
                    getLocalNetworkGatewayResponse.Name, getLocalNetworkGatewayResponse.GatewayIpAddress,
                    getLocalNetworkGatewayResponse.LocalNetworkAddressSpace.AddressPrefixes[0].ToString());
                Assert.Equal(newAddressPrefixes, getLocalNetworkGatewayResponse.LocalNetworkAddressSpace.AddressPrefixes[0].ToString());

                // 4. ListLocalNetworkGateways API
                var listLocalNetworkGatewayResponse = networkManagementClient.LocalNetworkGateways.List(resourceGroupName);
                Console.WriteLine("ListLocalNetworkGateways count ={0} ", listLocalNetworkGatewayResponse.Count());
                Assert.Equal(1, listLocalNetworkGatewayResponse.Count());

                // 5A. DeleteLocalNetworkGateway API
                networkManagementClient.LocalNetworkGateways.Delete(resourceGroupName, localNetworkGatewayName);
                
                // 5B. ListLocalNetworkGateways API after DeleteLocalNetworkGateway API was called
                listLocalNetworkGatewayResponse = networkManagementClient.LocalNetworkGateways.List(resourceGroupName);
                Console.WriteLine("ListLocalNetworkGateways count ={0} ", listLocalNetworkGatewayResponse.Count());
                Assert.Equal(0, listLocalNetworkGatewayResponse.Count());
            }
        }

        // Tests Resource:-VirtualNetworkGatewayConnection 5 APIs & Set-Remove default site
        [Fact(Skip = "TODO: Autorest")]
        public void VirtualNetworkGatewayConnectionOperationsApisTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = MockContext.Start())
            {
                

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                var location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/connections");

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });
                
                // 1. CreateVirtualNetworkGatewayConnection API

                //A. Create LocalNetworkGateway2
                string localNetworkGatewayName = TestUtilities.GenerateName();
                string gatewayIp = "192.168.3.4";

                var localNetworkGateway = new LocalNetworkGateway()
                {
                    Location = location,
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

                var putLocalNetworkGatewayResponse = networkManagementClient.LocalNetworkGateways.CreateOrUpdate(resourceGroupName, localNetworkGatewayName, localNetworkGateway);
                Assert.Equal("Succeeded", putLocalNetworkGatewayResponse.ProvisioningState);
                var getLocalNetworkGatewayResponse = networkManagementClient.LocalNetworkGateways.Get(resourceGroupName, localNetworkGatewayName);
                getLocalNetworkGatewayResponse.Location = location;

                // B. Prerequisite:- Create VirtualNetworkGateway1
                // a. Create PublicIPAddress(Gateway Ip) using Put PublicIPAddress API
                string publicIpName = TestUtilities.GenerateName();
                string domainNameLabel = TestUtilities.GenerateName();

                var nic1publicIp = TestHelper.CreateDefaultPublicIpAddress(publicIpName, resourceGroupName, domainNameLabel, location, networkManagementClient);
                Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);


                // b. Create Virtual Network using Put VirtualNetwork API
                string vnetName = TestUtilities.GenerateName();
                string subnetName = "GatewaySubnet";

                var virtualNetwork = TestHelper.CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location, networkManagementClient);

                var getSubnetResponse = networkManagementClient.Subnets.Get(resourceGroupName, vnetName, subnetName);
                Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Id);

                //c. CreateVirtualNetworkGateway API (Also, Set Default local network site)
                string virtualNetworkGatewayName = TestUtilities.GenerateName();
                string ipConfigName = TestUtilities.GenerateName();

                var virtualNetworkGateway = new VirtualNetworkGateway()
                {
                    Location = location,
                    Tags = new Dictionary<string, string>()
                        {
                           {"key","value"}
                        },
                    EnableBgp = false,
                    GatewayDefaultSite = new SubResource()
                        {
                            Id = getLocalNetworkGatewayResponse.Id
                        },
                    GatewayType = VirtualNetworkGatewayType.Vpn,
                    VpnType = VpnType.RouteBased,
                    IpConfigurations = new List<VirtualNetworkGatewayIPConfiguration>()
                    {
                        new VirtualNetworkGatewayIPConfiguration()
                        {
                             Name = ipConfigName,
                             PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                             PublicIPAddress = new SubResource()
                             {
                                 Id = nic1publicIp.Id
                             },
                             Subnet = new SubResource()
                             {
                                 Id = getSubnetResponse.Id
                             }
                        }
                    }
                };

                var putVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, virtualNetworkGateway);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.ProvisioningState);
                Console.WriteLine("Virtual Network Gateway is deployed successfully.");
                var getVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);
                Assert.NotNull(getVirtualNetworkGatewayResponse.GatewayDefaultSite);
                Console.WriteLine("Default site :{0} set at Virtual network gateway.", getVirtualNetworkGatewayResponse.GatewayDefaultSite);
                Assert.Equal(getVirtualNetworkGatewayResponse.GatewayDefaultSite.Id, getLocalNetworkGatewayResponse.Id);

                //// C. CreaetVirtualNetworkGatewayConnection API
                //string VirtualNetworkGatewayConnectionName = TestUtilities.GenerateName();
                //var virtualNetworkGatewayConneciton = new VirtualNetworkGatewayConnection()
                //{
                //    Location = location,
                //    Name = VirtualNetworkGatewayConnectionName,
                //    VirtualNetworkGateway1 = getVirtualNetworkGatewayResponse.VirtualNetworkGateway,
                //    LocalNetworkGateway2 = getLocalNetworkGatewayResponse.LocalNetworkGateway,
                //    ConnectionType = VirtualNetworkGatewayConnectionType.IPsec,
                //    RoutingWeight = 3,
                //    SharedKey = "abc"
                //};
                //var putVirtualNetworkGatewayConnectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.CreateOrUpdate(resourceGroupName, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConneciton);
                //Assert.Equal(HttpStatusCode.OK, putVirtualNetworkGatewayConnectionResponse.StatusCode);
                //Assert.Equal("Succeeded", putVirtualNetworkGatewayConnectionResponse.Status);

                //// 2. GetVirtualNetworkGatewayConnection API
                //var getVirtualNetworkGatewayConnectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.Get(resourceGroupName, VirtualNetworkGatewayConnectionName);
                //Assert.Equal(HttpStatusCode.OK, getVirtualNetworkGatewayConnectionResponse.StatusCode);
                //Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, ConnectionType={6} RoutingWeight={7} SharedKey={8}"+
                //    "ConnectionStatus={9}, EgressBytesTransferred={10}, IngressBytesTransferred={11}",
                //    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.Location, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.Id,
                //    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.Name,
                //    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.VirtualNetworkGateway1.Id,
                //    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.LocalNetworkGateway2.Id,
                //    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.ConnectionType, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.RoutingWeight,
                //    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.SharedKey, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.ConnectionStatus,
                //    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.EgressBytesTransferred, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.IngressBytesTransferred);

                //Assert.Equal(VirtualNetworkGatewayConnectionType.IPsec, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.ConnectionType);
                //Assert.Equal(3, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.RoutingWeight);
                //Assert.Equal("abc", getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.SharedKey);

                // 2A. Remove Default local network site
                getVirtualNetworkGatewayResponse.GatewayDefaultSite = null;
                putVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.ProvisioningState);
                getVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);
                Assert.Null(getVirtualNetworkGatewayResponse.GatewayDefaultSite);
                Console.WriteLine("Default site removal from Virtual network gateway is successful.", getVirtualNetworkGatewayResponse.GatewayDefaultSite);

                //// 3A. UpdateVirtualNetworkGatewayConnection API :- RoutingWeight = 3 => 4, SharedKey = "abc"=> "xyz"
                //virtualNetworkGatewayConneciton.RoutingWeight = 4;
                //virtualNetworkGatewayConneciton.SharedKey = "xyz";

                //putVirtualNetworkGatewayConnectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.CreateOrUpdate(resourceGroupName, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConneciton);
                //Assert.Equal(HttpStatusCode.OK, putVirtualNetworkGatewayConnectionResponse.StatusCode);
                //Assert.Equal("Succeeded", putVirtualNetworkGatewayConnectionResponse.Status);

                //// 3B. GetVirtualNetworkGatewayConnection API after Updating RoutingWeight = 3 => 4, SharedKey = "abc"=> "xyz"
                //getVirtualNetworkGatewayConnectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.Get(resourceGroupName, VirtualNetworkGatewayConnectionName);
                //Assert.Equal(HttpStatusCode.OK, getVirtualNetworkGatewayConnectionResponse.StatusCode);
                //Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, ConnectionType={6} RoutingWeight={7} SharedKey={8}" +
                //    "ConnectionStatus={9}, EgressBytesTransferred={10}, IngressBytesTransferred={11}",
                //    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.Location, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.Id,
                //    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.Name,
                //    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.VirtualNetworkGateway1.Id,
                //    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.LocalNetworkGateway2.Id,
                //    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.ConnectionType, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.RoutingWeight,
                //    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.SharedKey, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.ConnectionStatus,
                //    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.EgressBytesTransferred, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.IngressBytesTransferred);
                //Assert.Equal(4, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.RoutingWeight);
                //Assert.Equal("xyz", getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGatewayConnection.SharedKey);

                //// 4. ListVitualNetworkGatewayConnections API
                //var listVirtualNetworkGatewayConectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.List(resourceGroupName);
                //Assert.Equal(HttpStatusCode.OK, listVirtualNetworkGatewayConectionResponse.StatusCode);
                //Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.VirtualNetworkGatewayConnections.Count);
                //Assert.Equal(1, listVirtualNetworkGatewayConectionResponse.VirtualNetworkGatewayConnections.Count);

                //// 5A. DeleteVirtualNetworkGatewayConnection API
                //var deleteVirtualNetworkGatewayConnectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.Delete(resourceGroupName, VirtualNetworkGatewayConnectionName);
                //Assert.Equal(HttpStatusCode.OK, deleteVirtualNetworkGatewayConnectionResponse.StatusCode);

                //// 5B. ListVitualNetworkGatewayConnections API after DeleteVirtualNetworkGatewayConnection API called
                //listVirtualNetworkGatewayConectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.List(resourceGroupName);
                //Assert.Equal(HttpStatusCode.OK, listVirtualNetworkGatewayConectionResponse.StatusCode);
                //Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.VirtualNetworkGatewayConnections.Count);
                //Assert.Equal(0, listVirtualNetworkGatewayConectionResponse.VirtualNetworkGatewayConnections.Count);

            }
        }

        // Tests Resource:-VirtualNetworkGatewayConnectionSharedKey 3 APIs:-
        [Fact(Skip = "TODO: Autorest")]
        public void VirtualNetworkGatewayConnectionSharedKeyOperationsApisTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = MockContext.Start())
            {
                

                var resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

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

                // a. Create PublicIPAddress(Gateway Ip) using Put PublicIPAddress API
                string publicIpName = TestUtilities.GenerateName();
                string domainNameLabel = TestUtilities.GenerateName();

                var nic1publicIp = TestHelper.CreateDefaultPublicIpAddress(publicIpName, resourceGroupName, domainNameLabel, location, networkManagementClient);
                Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);

                // b. Create Virtual Network using Put VirtualNetwork API
                string vnetName = TestUtilities.GenerateName();
                string subnetName = "GatewaySubnet";

                var virtualNetwork = TestHelper.CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location, networkManagementClient);

                var getSubnetResponse = networkManagementClient.Subnets.Get(resourceGroupName, vnetName, subnetName);
                Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Id);

                // c. CreateVirtualNetworkGateway API
                string virtualNetworkGatewayName = TestUtilities.GenerateName();
                string ipConfigName = TestUtilities.GenerateName();

                var virtualNetworkGateway = new VirtualNetworkGateway()
                {
                    Location = location,
                    Tags = new Dictionary<string, string>()
                        {
                           {"key","value"}
                        },
                    EnableBgp = false,
                    GatewayDefaultSite = null,
                    GatewayType = VirtualNetworkGatewayType.Vpn,
                    VpnType = VpnType.RouteBased,
                    IpConfigurations = new List<VirtualNetworkGatewayIPConfiguration>()
                    {
                        new VirtualNetworkGatewayIPConfiguration()
                        {
                             Name = ipConfigName,
                             PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                             PublicIPAddress = new SubResource()
                             {
                                 Id = nic1publicIp.Id
                             },
                             Subnet = new SubResource()
                             {
                                 Id = getSubnetResponse.Id
                             }
                        }
                    }
                };

                var putVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, virtualNetworkGateway);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.ProvisioningState);
                var getVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);

                // Create LocalNetworkGateway2
                string localNetworkGatewayName = TestUtilities.GenerateName();
                string gatewayIp = "192.168.3.4";

                var localNetworkGateway = new LocalNetworkGateway()
                {
                    Location = location,
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

                var putLocalNetworkGatewayResponse = networkManagementClient.LocalNetworkGateways.CreateOrUpdate(resourceGroupName, localNetworkGatewayName, localNetworkGateway);
                Assert.Equal("Succeeded", putLocalNetworkGatewayResponse.ProvisioningState);
                var getLocalNetworkGatewayResponse = networkManagementClient.LocalNetworkGateways.Get(resourceGroupName, localNetworkGatewayName);
                getLocalNetworkGatewayResponse.Location = location;

                // CreaetVirtualNetworkGatewayConnection API
                string VirtualNetworkGatewayConnectionName = TestUtilities.GenerateName();
                var virtualNetworkGatewayConneciton = new VirtualNetworkGatewayConnection()
                {
                    Location = location,
                    VirtualNetworkGateway1 = getVirtualNetworkGatewayResponse,
                    LocalNetworkGateway2 = getLocalNetworkGatewayResponse,
                    ConnectionType = VirtualNetworkGatewayConnectionType.IPsec,
                    RoutingWeight = 3,
                    SharedKey = "abc"
                };
                var putVirtualNetworkGatewayConnectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.CreateOrUpdate(resourceGroupName, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConneciton);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayConnectionResponse.ProvisioningState);

                // SetVirtualNetworkGatewayConnectionSharedKey API on created connection above:- virtualNetworkGatewayConneciton
                string connectionSharedKeyName = VirtualNetworkGatewayConnectionName;
                var connectionSharedKey = new ConnectionSharedKey()
                {
                    Value = "TestSharedKeyValue"
                };

                var putConnectionSharedKeyResponse = networkManagementClient.VirtualNetworkGatewayConnections.SetSharedKey(resourceGroupName, connectionSharedKeyName, connectionSharedKey);
                // Assert.Equal("Succeeded", putConnectionSharedKeyResponse.Value);

                // 2. GetVirtualNetworkGatewayConnectionSharedKey API
                var getconnectionSharedKeyResponse = networkManagementClient.VirtualNetworkGatewayConnections.GetSharedKey(resourceGroupName, connectionSharedKeyName);
                Console.WriteLine("ConnectionSharedKey details:- Value: {0}", getconnectionSharedKeyResponse.Value);

                // 3A. VirtualNetworkGatewayConnectionResetSharedKey API
                var connectionResetSharedKey = new ConnectionResetSharedKey()
                {
                    KeyLength = 50
                };
                var resetConnectionResetSharedKeyResponse = networkManagementClient.VirtualNetworkGatewayConnections.ResetSharedKey(resourceGroupName, connectionSharedKeyName, connectionResetSharedKey);
                //Assert.Equal("Succeeded", resetConnectionResetSharedKeyResponse.Pro);

                // 3B. GetVirtualNetworkGatewayConnectionSharedKey API after VirtualNetworkGatewayConnectionResetSharedKey API was called
                getconnectionSharedKeyResponse = networkManagementClient.VirtualNetworkGatewayConnections.GetSharedKey(resourceGroupName, connectionSharedKeyName);
                Console.WriteLine("ConnectionSharedKey details:- Value: {0}", getconnectionSharedKeyResponse.Value);
            }
        }
    }
}