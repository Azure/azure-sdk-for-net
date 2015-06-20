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

                // A. Prerequisite:- Create PublicIPAddress(Gateway Ip) using Put PublicIPAddress API
                string publicIpName = TestUtilities.GenerateName();
                string domainNameLabel = TestUtilities.GenerateName();

                var nic1publicIp = TestHelper.CreateDefaultPublicIpAddress(publicIpName, resourceGroupName, domainNameLabel, location, networkResourceProviderClient);
                Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);


                // B.Prerequisite:- Create Virtual Network using Put VirtualNetwork API

                string vnetName = TestUtilities.GenerateName();
                string subnetName = "GatewaySubnet";

                var virtualNetwork = TestHelper.CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location, networkResourceProviderClient);

                var getSubnetResponse = networkResourceProviderClient.Subnets.Get(resourceGroupName, vnetName, subnetName);
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
                    GatewaySize = VirtualNetworkGatewaySize.Default,
                    GatewayType = VpnGatewayType.DynamicRouting,
                    IpConfigurations = new List<VirtualNetworkGatewayIpConfiguration>()
                    {
                        new VirtualNetworkGatewayIpConfiguration()
                        {
                             Name = ipConfigName,
                             PrivateIPAllocationMethod = IpAllocationMethod.Dynamic,
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

                var putVirtualNetworkGatewayResponse = networkResourceProviderClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, virtualNetworkGateway);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.ProvisioningState);

                // 2. GetVirtualNetworkGateway API
                var getVirtualNetworkGatewayResponse = networkResourceProviderClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);
                Console.WriteLine("Gateway details:- GatewayLocation: {0}, GatewayId:{1}, GatewayName={2}, GateaySize={3}, GatewayType={4} ",
                    getVirtualNetworkGatewayResponse.Location,
                    getVirtualNetworkGatewayResponse.Id, getVirtualNetworkGatewayResponse.Name,
                    getVirtualNetworkGatewayResponse.GatewaySize, getVirtualNetworkGatewayResponse.GatewayType);

                // 3A. UpdateVirtualNetworkGateway API :- GatewaySize update from Default -> HighPerformance
                virtualNetworkGateway.GatewaySize = VirtualNetworkGatewaySize.HighPerformance;

                putVirtualNetworkGatewayResponse = networkResourceProviderClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, virtualNetworkGateway);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.ProvisioningState);

                // 3B. GetVirtualNetworkgateway API after Updating GatewaySKU from Default -> HighPerformance
                getVirtualNetworkGatewayResponse = networkResourceProviderClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);
                Console.WriteLine("Gateway details:- GatewayLocation: {0}, GatewayId:{1}, GatewayName={2}, GateaySize={3}, GatewayType={4} ",
                    getVirtualNetworkGatewayResponse.Location,
                    getVirtualNetworkGatewayResponse.Id, getVirtualNetworkGatewayResponse.Name,
                    getVirtualNetworkGatewayResponse.GatewaySize, getVirtualNetworkGatewayResponse.GatewayType);
                Assert.Equal(VirtualNetworkGatewaySize.HighPerformance, getVirtualNetworkGatewayResponse.GatewaySize);

                // 4A. ResetVirtualNetworkGateway API
                try
                {
                    var resetVirtualNetworkGatewayResponse = networkResourceProviderClient.VirtualNetworkGateways.Reset(resourceGroupName, virtualNetworkGatewayName, virtualNetworkGateway);
                }
                catch (Exception ex)
                {
                    Assert.Equal("Accepted", ex.Message);
                }

                // 4B. GetVirtualNetworkgateway API after ResetVirtualNetworkGateway API was called
                getVirtualNetworkGatewayResponse = networkResourceProviderClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);
                Console.WriteLine("Gateway details:- GatewayLocation: {0}, GatewayId:{1}, GatewayName={2}, GateaySize={3}, GatewayType={4} ",
                    getVirtualNetworkGatewayResponse.Location,
                    getVirtualNetworkGatewayResponse.Id, getVirtualNetworkGatewayResponse.Name,
                    getVirtualNetworkGatewayResponse.GatewaySize, getVirtualNetworkGatewayResponse.GatewayType);

                // 5. ListVitualNetworkGateways API
                var listVirtualNetworkGatewayResponse = networkResourceProviderClient.VirtualNetworkGateways.List(resourceGroupName);
                Console.WriteLine("ListVirtualNetworkGateways count ={0} ", listVirtualNetworkGatewayResponse.Value.Count);
                Assert.Equal(1, listVirtualNetworkGatewayResponse.Value.Count);

                // 6A. DeleteVirtualNetworkGateway API
                networkResourceProviderClient.VirtualNetworkGateways.Delete(resourceGroupName, virtualNetworkGatewayName);

                // 6B. ListVitualNetworkGateways API after deleting VirtualNetworkGateway
                listVirtualNetworkGatewayResponse = networkResourceProviderClient.VirtualNetworkGateways.List(resourceGroupName);
                Console.WriteLine("ListVirtualNetworkGateways count ={0} ", listVirtualNetworkGatewayResponse.Value.Count);
                Assert.Equal(0, listVirtualNetworkGatewayResponse.Value.Count);
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
                string newGatewayIp = "192.168.3.5";

                var localNetworkGateway = new LocalNetworkGateway()
                {
                    Location = location,
                    Tags = new Dictionary<string, string>()
                        {
                           {"test","value"}
                        },
                    GatewayIpAddress = gatewayIp,
                    LocalNetworkSiteAddressSpace = new AddressSpace()
                    {
                        AddressPrefixes = new List<string>()
                        {
                            "192.168.0.0/16",
                        }
                    }
                };

                var putLocalNetworkGatewayResponse = networkResourceProviderClient.LocalNetworkGateways.CreateOrUpdate(resourceGroupName, localNetworkGatewayName, localNetworkGateway);
                Assert.Equal("Succeeded", putLocalNetworkGatewayResponse.ProvisioningState);

                // 2. GetLocalNetworkGateway API
                var getLocalNetworkGatewayResponse = networkResourceProviderClient.LocalNetworkGateways.Get(resourceGroupName, localNetworkGatewayName);
                Console.WriteLine("Local Network Gateway details:- GatewayLocation: {0}, GatewayId:{1}, GatewayName={2} ",
                    getLocalNetworkGatewayResponse.Location,
                    getLocalNetworkGatewayResponse.Id, getLocalNetworkGatewayResponse.Name);
                Assert.Equal(gatewayIp, getLocalNetworkGatewayResponse.GatewayIpAddress);

                // 3A. UpdateLocalNetworkgateway API :- GatewayIp from "10.0.3.4" => "10.0.3.5"
                localNetworkGateway.GatewayIpAddress = newGatewayIp;

                putLocalNetworkGatewayResponse = networkResourceProviderClient.LocalNetworkGateways.CreateOrUpdate(resourceGroupName, localNetworkGatewayName, localNetworkGateway);
                
                // 3B. GetLocalNetworkGateway API after Updating GatewayIp from "10.0.3.4" => "10.0.3.5"
                getLocalNetworkGatewayResponse = networkResourceProviderClient.LocalNetworkGateways.Get(resourceGroupName, localNetworkGatewayName);
                Console.WriteLine("Local Network Gateway details:- GatewayLocation: {0}, GatewayId:{1}, GatewayName={2} GatewayIpAddress={3}",
                    getLocalNetworkGatewayResponse.Location, getLocalNetworkGatewayResponse.Id,
                    getLocalNetworkGatewayResponse.Name, getLocalNetworkGatewayResponse.GatewayIpAddress);
                Assert.Equal(newGatewayIp, getLocalNetworkGatewayResponse.GatewayIpAddress);

                // 4. ListLocalNetworkGateways API
                var listLocalNetworkGatewayResponse = networkResourceProviderClient.LocalNetworkGateways.List(resourceGroupName);
                Console.WriteLine("ListLocalNetworkGateways count ={0} ", listLocalNetworkGatewayResponse.Value.Count);
                Assert.Equal(1, listLocalNetworkGatewayResponse.Value.Count);

                // 5A. DeleteLocalNetworkGateway API
                networkResourceProviderClient.LocalNetworkGateways.Delete(resourceGroupName, localNetworkGatewayName);

                // 5B. ListLocalNetworkGateways API after DeleteLocalNetworkGateway API was called
                listLocalNetworkGatewayResponse = networkResourceProviderClient.LocalNetworkGateways.List(resourceGroupName);
                Console.WriteLine("ListLocalNetworkGateways count ={0} ", listLocalNetworkGatewayResponse.Value.Count);
                Assert.Equal(0, listLocalNetworkGatewayResponse.Value.Count);
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
                // a. Create PublicIPAddress(Gateway Ip) using Put PublicIPAddress API
                string publicIpName = TestUtilities.GenerateName();
                string domainNameLabel = TestUtilities.GenerateName();

                var nic1publicIp = TestHelper.CreateDefaultPublicIpAddress(publicIpName, resourceGroupName, domainNameLabel, location, networkResourceProviderClient);
                Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);


                // b. Create Virtual Network using Put VirtualNetwork API
                string vnetName = TestUtilities.GenerateName();
                string subnetName = "GatewaySubnet";

                var virtualNetwork = TestHelper.CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location, networkResourceProviderClient);

                var getSubnetResponse = networkResourceProviderClient.Subnets.Get(resourceGroupName, vnetName, subnetName);
                Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Id);

                //c. CreateVirtualNetworkGateway API
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
                    GatewaySize = VirtualNetworkGatewaySize.Default,
                    GatewayType = VpnGatewayType.DynamicRouting,
                    IpConfigurations = new List<VirtualNetworkGatewayIpConfiguration>()
                    {
                        new VirtualNetworkGatewayIpConfiguration()
                        {
                             Name = ipConfigName,
                             PrivateIPAllocationMethod = IpAllocationMethod.Dynamic,
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

                var putVirtualNetworkGatewayResponse = networkResourceProviderClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, virtualNetworkGateway);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.ProvisioningState);

                //B. Create LocalNetworkGateway2
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
                    LocalNetworkSiteAddressSpace = new AddressSpace()
                    {
                        AddressPrefixes = new List<string>()
                        {
                            "192.168.0.0/16",
                        }
                    }
                };

                var putLocalNetworkGatewayResponse = networkResourceProviderClient.LocalNetworkGateways.CreateOrUpdate(resourceGroupName, localNetworkGatewayName, localNetworkGateway);
                Assert.Equal("Succeeded", putLocalNetworkGatewayResponse.ProvisioningState);

                // C. CreaetVirtualNetworkGatewayConnection API
                string VirtualNetworkGatewayConnectionName = TestUtilities.GenerateName();
                var virtualNetworkGatewayConneciton = new VirtualNetworkGatewayConnection()
                {
                    Location = location,
                    VirtualNetworkGateway1 = virtualNetworkGateway,
                    LocalNetworkGateway2 = localNetworkGateway,
                    ConnectionType = VirtualNetworkGatewayConnectionType.IPsec,
                    RoutingWeight = 3,
                    SharedKey = "abc"
                };
                var putVirtualNetworkGatewayConnectionResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.CreateOrUpdate(resourceGroupName, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConneciton);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayConnectionResponse.ProvisioningState);

                // 2. GetVirtualNetworkGatewayConnection API
                var getVirtualNetworkGatewayConnectionResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.Get(resourceGroupName, VirtualNetworkGatewayConnectionName);
                Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, ConnectionType={6} RoutingWeight={7} SharedKey={8}",
                    getVirtualNetworkGatewayConnectionResponse.Location, getVirtualNetworkGatewayConnectionResponse.Id,
                    getVirtualNetworkGatewayConnectionResponse.Name,
                    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGateway1.Id,
                    getVirtualNetworkGatewayConnectionResponse.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.LocalNetworkGateway2.Id,
                    getVirtualNetworkGatewayConnectionResponse.ConnectionType, getVirtualNetworkGatewayConnectionResponse.RoutingWeight,
                    getVirtualNetworkGatewayConnectionResponse.SharedKey);
                Assert.Equal(VirtualNetworkGatewayConnectionType.IPsec, getVirtualNetworkGatewayConnectionResponse.ConnectionType);
                Assert.Equal(3, getVirtualNetworkGatewayConnectionResponse.RoutingWeight);
                Assert.Equal("abc", getVirtualNetworkGatewayConnectionResponse.SharedKey);

                // 3A. UpdateVirtualNetworkGatewayConnection API :- ConnectionType = "IPSec" => Vnet2Vnet , RoutingWeight = 3 => 4, SharedKey = "abc"=> "xyz"
                virtualNetworkGatewayConneciton.ConnectionType = VirtualNetworkGatewayConnectionType.Vnet2Vnet;
                virtualNetworkGatewayConneciton.RoutingWeight = 4;
                virtualNetworkGatewayConneciton.SharedKey = "xyz";

                putVirtualNetworkGatewayConnectionResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.CreateOrUpdate(resourceGroupName, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConneciton);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayConnectionResponse.ProvisioningState);

                // 3B. GetVirtualNetworkGatewayConnection API after Updating ConnectionType = "IPSec" => Vnet2Vnet , RoutingWeight = 3 => 4, SharedKey = "abc"=> "xyz"
                getVirtualNetworkGatewayConnectionResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.Get(resourceGroupName, VirtualNetworkGatewayConnectionName);
                Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, ConnectionType={6} RoutingWeight={7} SharedKey={8}",
                    getVirtualNetworkGatewayConnectionResponse.Location, getVirtualNetworkGatewayConnectionResponse.Id,
                    getVirtualNetworkGatewayConnectionResponse.Name,
                    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGateway1.Id,
                    getVirtualNetworkGatewayConnectionResponse.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.LocalNetworkGateway2.Id,
                    getVirtualNetworkGatewayConnectionResponse.ConnectionType, getVirtualNetworkGatewayConnectionResponse.RoutingWeight,
                    getVirtualNetworkGatewayConnectionResponse.SharedKey);
                Assert.Equal(VirtualNetworkGatewayConnectionType.Vnet2Vnet, getVirtualNetworkGatewayConnectionResponse.ConnectionType);
                Assert.Equal(4, getVirtualNetworkGatewayConnectionResponse.RoutingWeight);
                Assert.Equal("xyz", getVirtualNetworkGatewayConnectionResponse.SharedKey);

                // 4. ListVitualNetworkGatewayConnections API
                var listVirtualNetworkGatewayConectionResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.List(resourceGroupName);
                Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.Value.Count);
                Assert.Equal(1, listVirtualNetworkGatewayConectionResponse.Value.Count);

                // 5A. DeleteVirtualNetworkGatewayConnection API
                networkResourceProviderClient.VirtualNetworkGatewayConnections.Delete(resourceGroupName, VirtualNetworkGatewayConnectionName);

                // 5B. ListVitualNetworkGatewayConnections API after DeleteVirtualNetworkGatewayConnection API called
                listVirtualNetworkGatewayConectionResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.List(resourceGroupName);
                Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.Value.Count);
                Assert.Equal(0, listVirtualNetworkGatewayConectionResponse.Value.Count);

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

                // a. Create PublicIPAddress(Gateway Ip) using Put PublicIPAddress API
                string publicIpName = TestUtilities.GenerateName();
                string domainNameLabel = TestUtilities.GenerateName();

                var nic1publicIp = TestHelper.CreateDefaultPublicIpAddress(publicIpName, resourceGroupName, domainNameLabel, location, networkResourceProviderClient);
                Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);

                // b. Create Virtual Network using Put VirtualNetwork API
                string vnetName = TestUtilities.GenerateName();
                string subnetName = "GatewaySubnet";

                var virtualNetwork = TestHelper.CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location, networkResourceProviderClient);

                var getSubnetResponse = networkResourceProviderClient.Subnets.Get(resourceGroupName, vnetName, subnetName);
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
                    GatewaySize = VirtualNetworkGatewaySize.Default,
                    GatewayType = VpnGatewayType.DynamicRouting,
                    IpConfigurations = new List<VirtualNetworkGatewayIpConfiguration>()
                    {
                        new VirtualNetworkGatewayIpConfiguration()
                        {
                             Name = ipConfigName,
                             PrivateIPAllocationMethod = IpAllocationMethod.Dynamic,
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

                var putVirtualNetworkGatewayResponse = networkResourceProviderClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, virtualNetworkGateway);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.ProvisioningState);

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
                    LocalNetworkSiteAddressSpace = new AddressSpace()
                    {
                        AddressPrefixes = new List<string>()
                        {
                            "192.168.0.0/16",
                        }
                    }
                };

                var putLocalNetworkGatewayResponse = networkResourceProviderClient.LocalNetworkGateways.CreateOrUpdate(resourceGroupName, localNetworkGatewayName, localNetworkGateway);
                Assert.Equal("Succeeded", putLocalNetworkGatewayResponse.ProvisioningState);

                // CreaetVirtualNetworkGatewayConnection API
                string VirtualNetworkGatewayConnectionName = TestUtilities.GenerateName();
                var virtualNetworkGatewayConneciton = new VirtualNetworkGatewayConnection()
                {
                    Location = location,
                    VirtualNetworkGateway1 = virtualNetworkGateway,
                    LocalNetworkGateway2 = localNetworkGateway,
                    ConnectionType = VirtualNetworkGatewayConnectionType.IPsec,
                    RoutingWeight = 3,
                    SharedKey = "abc"
                };
                var putVirtualNetworkGatewayConnectionResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.CreateOrUpdate(resourceGroupName, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConneciton);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayConnectionResponse.ProvisioningState);

                // SetVirtualNetworkGatewayConnectionSharedKey API on created connection above:- virtualNetworkGatewayConneciton
                string connectionSharedKeyName = VirtualNetworkGatewayConnectionName;
                var connectionSharedKey = new ConnectionSharedKey
                {
                    Properties = new ConnectionSharedKeyPropertiesFormat
                    {
                        Value = "TestSharedKeyValue"
                    }
                };

                var putConnectionSharedKeyResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.SetSharedKey(resourceGroupName, connectionSharedKeyName, connectionSharedKey);

                // 2. GetVirtualNetworkGatewayConnectionSharedKey API
                var getconnectionSharedKeyResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.GetSharedKey(resourceGroupName, connectionSharedKeyName);
                Console.WriteLine("ConnectionSharedKey details:- Value: {0}", getconnectionSharedKeyResponse);

                // 3A. VirtualNetworkGatewayConnectionResetSharedKey API
                var connectionResetSharedKey = new ConnectionResetSharedKey
                {
                    Properties = new ConnectionResetSharedKeyPropertiesFormat
                    {
                        KeyLength = 50
                    }
                };
                try
                {
                    networkResourceProviderClient.VirtualNetworkGatewayConnections.ResetSharedKey(resourceGroupName, connectionSharedKeyName, connectionResetSharedKey);
                }
                catch (Exception ex)
                {
                    Assert.Equal(ex.Message, "Accepted");
                }

                // 3B. GetVirtualNetworkGatewayConnectionSharedKey API after VirtualNetworkGatewayConnectionResetSharedKey API was called
                getconnectionSharedKeyResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.GetSharedKey(resourceGroupName, connectionSharedKeyName);
                Console.WriteLine("ConnectionSharedKey details:- Value: {0}", getconnectionSharedKeyResponse);
            }
        }
    }
}