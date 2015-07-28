using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Networks.Tests
{
    public class GatewayOperationsTests
    {
        // Tests Resource:-VirtualNetworkGateway 6 APIs:-
        [Fact(Skip = "TODO: Autorest")]
        public void VirtualNetworkGatewayOperationsApisTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start())
            {
                

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
                    GatewayType = VirtualNetworkGatewayType.Vpn,
                    VpnType = VpnType.RouteBased,
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
                Console.WriteLine("Gateway details:- GatewayLocation: {0}, GatewayId:{1}, GatewayName={2}, GatewayType={3}, VpnType={4}",
                    getVirtualNetworkGatewayResponse.Location,
                    getVirtualNetworkGatewayResponse.Id, getVirtualNetworkGatewayResponse.Name,
                    getVirtualNetworkGatewayResponse.GatewayType, getVirtualNetworkGatewayResponse.VpnType);
                Assert.Equal(VirtualNetworkGatewayType.Vpn, getVirtualNetworkGatewayResponse.GatewayType);
                Assert.Equal(VpnType.RouteBased, getVirtualNetworkGatewayResponse.VpnType);

                // 3A. ResetVirtualNetworkGateway API
                var resetVirtualNetworkGatewayResponse = networkResourceProviderClient.VirtualNetworkGateways.Reset(resourceGroupName, virtualNetworkGatewayName, virtualNetworkGateway);
                Assert.Equal("Succeeded", resetVirtualNetworkGatewayResponse.ProvisioningState);

                // 3B. GetVirtualNetworkgateway API after ResetVirtualNetworkGateway API was called
                getVirtualNetworkGatewayResponse = networkResourceProviderClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);
                Console.WriteLine("Gateway details:- GatewayLocation: {0}, GatewayId:{1}, GatewayName={2}, GatewayType={3} ",
                    getVirtualNetworkGatewayResponse.Location,
                    getVirtualNetworkGatewayResponse.Id, getVirtualNetworkGatewayResponse.Name,
                    getVirtualNetworkGatewayResponse.GatewayType);

                // 4. ListVitualNetworkGateways API
                var listVirtualNetworkGatewayResponse = networkResourceProviderClient.VirtualNetworkGateways.List(resourceGroupName);
                Console.WriteLine("ListVirtualNetworkGateways count ={0} ", listVirtualNetworkGatewayResponse.Count());
                Assert.Equal(1, listVirtualNetworkGatewayResponse.Count());

                // 5A. DeleteVirtualNetworkGateway API
                networkResourceProviderClient.VirtualNetworkGateways.Delete(resourceGroupName, virtualNetworkGatewayName);

                // 5B. ListVitualNetworkGateways API after deleting VirtualNetworkGateway
                listVirtualNetworkGatewayResponse = networkResourceProviderClient.VirtualNetworkGateways.List(resourceGroupName);
                Console.WriteLine("ListVirtualNetworkGateways count ={0} ", listVirtualNetworkGatewayResponse.Count());
                Assert.Equal(0, listVirtualNetworkGatewayResponse.Count());
            }
        }

        // Tests Resource:-LocalNetworkGateway 5 APIs:-
        [Fact(Skip = "TODO: Autorest")]
        public void LocalNettworkGatewayOperationsApisTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start())
            {
                

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
                Assert.Equal("Succeeded", putLocalNetworkGatewayResponse.ProvisioningState);

                // 2. GetLocalNetworkGateway API
                var getLocalNetworkGatewayResponse = networkResourceProviderClient.LocalNetworkGateways.Get(resourceGroupName, localNetworkGatewayName);
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

                putLocalNetworkGatewayResponse = networkResourceProviderClient.LocalNetworkGateways.CreateOrUpdate(resourceGroupName, localNetworkGatewayName, getLocalNetworkGatewayResponse);
                Assert.Equal("Succeeded", putLocalNetworkGatewayResponse.ProvisioningState);

                // 3B. GetLocalNetworkGateway API after Updating LocalNetworkGateway LocalNetworkAddressSpace from "192.168.0.0/16" => "200.168.0.0/16"
                getLocalNetworkGatewayResponse = networkResourceProviderClient.LocalNetworkGateways.Get(resourceGroupName, localNetworkGatewayName);
                getLocalNetworkGatewayResponse.Location = location;
                Console.WriteLine("Local Network Gateway details:- GatewayLocation: {0}, GatewayId:{1}, GatewayName={2} GatewayIpAddress={3} LocalNetworkAddressSpace={4}",
                    getLocalNetworkGatewayResponse.Location, getLocalNetworkGatewayResponse.Id,
                    getLocalNetworkGatewayResponse.Name, getLocalNetworkGatewayResponse.GatewayIpAddress,
                    getLocalNetworkGatewayResponse.LocalNetworkAddressSpace.AddressPrefixes[0].ToString());
                Assert.Equal(newAddressPrefixes, getLocalNetworkGatewayResponse.LocalNetworkAddressSpace.AddressPrefixes[0].ToString());

                // 4. ListLocalNetworkGateways API
                var listLocalNetworkGatewayResponse = networkResourceProviderClient.LocalNetworkGateways.List(resourceGroupName);
                Console.WriteLine("ListLocalNetworkGateways count ={0} ", listLocalNetworkGatewayResponse.Count());
                Assert.Equal(1, listLocalNetworkGatewayResponse.Count());

                // 5A. DeleteLocalNetworkGateway API
                networkResourceProviderClient.LocalNetworkGateways.Delete(resourceGroupName, localNetworkGatewayName);

                // 5B. ListLocalNetworkGateways API after DeleteLocalNetworkGateway API was called
                listLocalNetworkGatewayResponse = networkResourceProviderClient.LocalNetworkGateways.List(resourceGroupName);
                Console.WriteLine("ListLocalNetworkGateways count ={0} ", listLocalNetworkGatewayResponse.Count());
                Assert.Equal(0, listLocalNetworkGatewayResponse.Count());
            }
        }

        // Tests Resource:-VirtualNetworkGatewayConnection 5 APIs:-
        [Fact(Skip = "TODO: Autorest")]
        public void VirtualNetworkGatewayConnectionOperationsApisTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start())
            {
                

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
                    GatewayType = VirtualNetworkGatewayType.Vpn,
                    VpnType = VpnType.RouteBased,
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
                var getVirtualNetworkGatewayResponse = networkResourceProviderClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);

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
                    LocalNetworkAddressSpace = new AddressSpace()
                    {
                        AddressPrefixes = new List<string>()
                        {
                            "192.168.0.0/16",
                        }
                    }
                };

                var putLocalNetworkGatewayResponse = networkResourceProviderClient.LocalNetworkGateways.CreateOrUpdate(resourceGroupName, localNetworkGatewayName, localNetworkGateway);
                Assert.Equal("Succeeded", putLocalNetworkGatewayResponse.ProvisioningState);
                var getLocalNetworkGatewayResponse = networkResourceProviderClient.LocalNetworkGateways.Get(resourceGroupName, localNetworkGatewayName);
                getLocalNetworkGatewayResponse.Location = location;

                // C. CreaetVirtualNetworkGatewayConnection API
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

                // 3A. UpdateVirtualNetworkGatewayConnection API :- RoutingWeight = 3 => 4, SharedKey = "abc"=> "xyz"
                virtualNetworkGatewayConneciton.RoutingWeight = 4;
                virtualNetworkGatewayConneciton.SharedKey = "xyz";

                putVirtualNetworkGatewayConnectionResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.CreateOrUpdate(resourceGroupName, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConneciton);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayConnectionResponse.ProvisioningState);

                // 3B. GetVirtualNetworkGatewayConnection API after Updating RoutingWeight = 3 => 4, SharedKey = "abc"=> "xyz"
                getVirtualNetworkGatewayConnectionResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.Get(resourceGroupName, VirtualNetworkGatewayConnectionName);
                Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, ConnectionType={6} RoutingWeight={7} SharedKey={8}",
                    getVirtualNetworkGatewayConnectionResponse.Location, getVirtualNetworkGatewayConnectionResponse.Id,
                    getVirtualNetworkGatewayConnectionResponse.Name,
                    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGateway1.Id,
                    getVirtualNetworkGatewayConnectionResponse.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.LocalNetworkGateway2.Id,
                    getVirtualNetworkGatewayConnectionResponse.ConnectionType, getVirtualNetworkGatewayConnectionResponse.RoutingWeight,
                    getVirtualNetworkGatewayConnectionResponse.SharedKey);
                Assert.Equal(4, getVirtualNetworkGatewayConnectionResponse.RoutingWeight);
                Assert.Equal("xyz", getVirtualNetworkGatewayConnectionResponse.SharedKey);

                // 4. ListVitualNetworkGatewayConnections API
                var listVirtualNetworkGatewayConectionResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.List(resourceGroupName);
                Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.Count());
                Assert.Equal(1, listVirtualNetworkGatewayConectionResponse.Count());

                // 5A. DeleteVirtualNetworkGatewayConnection API
                networkResourceProviderClient.VirtualNetworkGatewayConnections.Delete(resourceGroupName, VirtualNetworkGatewayConnectionName);

                // 5B. ListVitualNetworkGatewayConnections API after DeleteVirtualNetworkGatewayConnection API called
                listVirtualNetworkGatewayConectionResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.List(resourceGroupName);
                Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.Count());
                Assert.Equal(0, listVirtualNetworkGatewayConectionResponse.Count());

            }
        }

        // Tests Resource:-VirtualNetworkGatewayConnectionSharedKey 3 APIs:-
        [Fact(Skip = "TODO: Autorest")]
        public void VirtualNetworkGatewayConnectionSharedKeyOperationsApisTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start())
            {
                

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
                    GatewayType = VirtualNetworkGatewayType.Vpn,
                    VpnType = VpnType.RouteBased,
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
                var getVirtualNetworkGatewayResponse = networkResourceProviderClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);

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

                var putLocalNetworkGatewayResponse = networkResourceProviderClient.LocalNetworkGateways.CreateOrUpdate(resourceGroupName, localNetworkGatewayName, localNetworkGateway);
                Assert.Equal("Succeeded", putLocalNetworkGatewayResponse.ProvisioningState);
                var getLocalNetworkGatewayResponse = networkResourceProviderClient.LocalNetworkGateways.Get(resourceGroupName, localNetworkGatewayName);
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
                var putVirtualNetworkGatewayConnectionResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.CreateOrUpdate(resourceGroupName, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConneciton);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayConnectionResponse.ProvisioningState);

                // SetVirtualNetworkGatewayConnectionSharedKey API on created connection above:- virtualNetworkGatewayConneciton
                string connectionSharedKeyName = VirtualNetworkGatewayConnectionName;
                var connectionSharedKey = new ConnectionSharedKey()
                {
                    Value = "TestSharedKeyValue"
                };

                var putConnectionSharedKeyResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.SetSharedKey(resourceGroupName, connectionSharedKeyName, connectionSharedKey);
                Assert.NotNull(putConnectionSharedKeyResponse);

                // 2. GetVirtualNetworkGatewayConnectionSharedKey API
                var getconnectionSharedKeyResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.GetSharedKey(resourceGroupName, connectionSharedKeyName);
                Console.WriteLine("ConnectionSharedKey details:- Value: {0}", getconnectionSharedKeyResponse.Value);

                // 3A. VirtualNetworkGatewayConnectionResetSharedKey API
                var connectionResetSharedKey = new ConnectionResetSharedKey()
                {
                    Properties = new ConnectionResetSharedKeyPropertiesFormat
                    {
                        KeyLength = 50
                    }
                };
                var resetConnectionResetSharedKeyResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.ResetSharedKey(resourceGroupName, connectionSharedKeyName, connectionResetSharedKey);
                Assert.NotNull(resetConnectionResetSharedKeyResponse);

                // 3B. GetVirtualNetworkGatewayConnectionSharedKey API after VirtualNetworkGatewayConnectionResetSharedKey API was called
                getconnectionSharedKeyResponse = networkResourceProviderClient.VirtualNetworkGatewayConnections.GetSharedKey(resourceGroupName, connectionSharedKeyName);
                Console.WriteLine("ConnectionSharedKey details:- Value: {0}", getconnectionSharedKeyResponse.Value);
            }
        }
    }
}