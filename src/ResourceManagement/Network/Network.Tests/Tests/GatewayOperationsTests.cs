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
    using System.IO;
    using System.Security.Cryptography.X509Certificates;
    using Microsoft.Azure.Test.HttpRecorder;

    public class GatewayOperationsTests
    {
        public GatewayOperationsTests()
        {
            HttpMockServer.RecordsDirectory = "SessionRecords";
        }

        // Tests Resource:-VirtualNetworkGateway 6 APIs:-
        [Fact]
        public void VirtualNetworkGatewayOperationsApisTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
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

                //B.Prerequisite:-Create Virtual Network using Put VirtualNetwork API

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
                    },
                    Sku = new VirtualNetworkGatewaySku()
                    {
                        Name = VirtualNetworkGatewaySkuName.Basic,
                        Tier = VirtualNetworkGatewaySkuTier.Basic
                    }
                };

                var putVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, virtualNetworkGateway);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.ProvisioningState);

                // 2. GetVirtualNetworkGateway API
                var getVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);
                Console.WriteLine("Gateway details:- GatewayLocation:{0}, GatewayId:{1}, GatewayName:{2}, GatewayType:{3}, VpnType={4} GatewaySku: name-{5} Tier-{6}",
                    getVirtualNetworkGatewayResponse.Location,
                    getVirtualNetworkGatewayResponse.Id, getVirtualNetworkGatewayResponse.Name,
                    getVirtualNetworkGatewayResponse.GatewayType, getVirtualNetworkGatewayResponse.VpnType,
                    getVirtualNetworkGatewayResponse.Sku.Name, getVirtualNetworkGatewayResponse.Sku.Tier);
                Assert.Equal(VirtualNetworkGatewayType.Vpn, getVirtualNetworkGatewayResponse.GatewayType);
                Assert.Equal(VpnType.RouteBased, getVirtualNetworkGatewayResponse.VpnType);
                Assert.Equal(VirtualNetworkGatewaySkuTier.Basic, getVirtualNetworkGatewayResponse.Sku.Tier);

                // 3. ResizeVirtualNetworkGateway API
                getVirtualNetworkGatewayResponse.Sku = new VirtualNetworkGatewaySku()
                {
                    Name = VirtualNetworkGatewaySkuName.Standard,
                    Tier = VirtualNetworkGatewaySkuTier.Standard
                };
                putVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.ProvisioningState);

                getVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);
                Assert.Equal(VirtualNetworkGatewaySkuTier.Standard, getVirtualNetworkGatewayResponse.Sku.Tier);

                // 4A. ResetVirtualNetworkGateway API
                var resetVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.Reset(resourceGroupName, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse);
                //Assert.Equal("Succeeded", resetVirtualNetworkGatewayResponse.ProvisioningState);

                // 4B. GetVirtualNetworkgateway API after ResetVirtualNetworkGateway API was called
                getVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);

                Console.WriteLine("Gateway details:- GatewayLocation: {0}, GatewayId:{1}, GatewayName={2}, GatewayType={3} ",
                    getVirtualNetworkGatewayResponse.Location,
                    getVirtualNetworkGatewayResponse.Id, getVirtualNetworkGatewayResponse.Name,
                    getVirtualNetworkGatewayResponse.GatewayType);

                // 5. ListVitualNetworkGateways API
                var listVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.List(resourceGroupName);
                Console.WriteLine("ListVirtualNetworkGateways count ={0} ", listVirtualNetworkGatewayResponse.Count());
                Assert.Equal(1, listVirtualNetworkGatewayResponse.Count());

                // 6A. DeleteVirtualNetworkGateway API
                networkManagementClient.VirtualNetworkGateways.Delete(resourceGroupName, virtualNetworkGatewayName);

                // 6B. ListVitualNetworkGateways API after deleting VirtualNetworkGateway
                listVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.List(resourceGroupName);

                Console.WriteLine("ListVirtualNetworkGateways count ={0} ", listVirtualNetworkGatewayResponse.Count());
                Assert.Equal(0, listVirtualNetworkGatewayResponse.Count());
            }
        }

        // Tests Resource:-LocalNetworkGateway 5 APIs:-
        [Fact]
        public void LocalNettworkGatewayOperationsApisTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
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

        [Fact]
        public void VirtualNetworkGatewayConnectionWithBgpTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
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

                // Create a local network gateway with BGP
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
                    },
                    BgpSettings = new BgpSettings()
                    {
                        Asn = 1234,
                        BgpPeeringAddress = "192.168.0.1",
                        PeerWeight = 3
                    }
                };

                var putLocalNetworkGatewayResponse = networkManagementClient.LocalNetworkGateways.CreateOrUpdate(resourceGroupName, localNetworkGatewayName, localNetworkGateway);
                Assert.Equal("Succeeded", putLocalNetworkGatewayResponse.ProvisioningState);
                var getLocalNetworkGatewayResponse = networkManagementClient.LocalNetworkGateways.Get(resourceGroupName, localNetworkGatewayName);

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
                    },
                    Sku = new VirtualNetworkGatewaySku()
                    {
                        Name = "Standard",
                        Tier = "Standard"
                    },
                    BgpSettings = new BgpSettings()
                    {
                        Asn = 1337,
                        BgpPeeringAddress = null, // Gateway manager assigns this
                        PeerWeight = 5
                    }
                };

                var putVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, virtualNetworkGateway);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.ProvisioningState);
                Console.WriteLine("Virtual Network Gateway is deployed successfully.");
                var getVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);
                Assert.NotNull(getVirtualNetworkGatewayResponse);
                Assert.NotNull(getVirtualNetworkGatewayResponse.BgpSettings);
                Assert.False(string.IsNullOrEmpty(getVirtualNetworkGatewayResponse.BgpSettings.BgpPeeringAddress), "The gateway's CA should be populated");

                // Create a virtual network gateway connection with BGP enabled
                string VirtualNetworkGatewayConnectionName = TestUtilities.GenerateName();
                var virtualNetworkGatewayConneciton = new VirtualNetworkGatewayConnection()
                {
                    Location = location,
                    VirtualNetworkGateway1 = getVirtualNetworkGatewayResponse,
                    LocalNetworkGateway2 = getLocalNetworkGatewayResponse,
                    ConnectionType = VirtualNetworkGatewayConnectionType.IPsec,
                    RoutingWeight = 3,
                    SharedKey = "abc",
                    EnableBgp = true
                };
                var putVirtualNetworkGatewayConnectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.CreateOrUpdate(resourceGroupName, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConneciton);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayConnectionResponse.ProvisioningState);
                Assert.True(putVirtualNetworkGatewayConnectionResponse.EnableBgp, "Enabling BGP for this connection must succeed");

                // 2. GetVirtualNetworkGatewayConnection API
                var getVirtualNetworkGatewayConnectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.Get(resourceGroupName, VirtualNetworkGatewayConnectionName);
                Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, ConnectionType={6} RoutingWeight={7} SharedKey={8}" +
                    "ConnectionStatus={9}, EgressBytesTransferred={10}, IngressBytesTransferred={11}, EnableBgp={12}",
                    getVirtualNetworkGatewayConnectionResponse.Location, getVirtualNetworkGatewayConnectionResponse.Id,
                    getVirtualNetworkGatewayConnectionResponse.Name,
                    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGateway1.Id,
                    getVirtualNetworkGatewayConnectionResponse.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.LocalNetworkGateway2.Id,
                    getVirtualNetworkGatewayConnectionResponse.ConnectionType, getVirtualNetworkGatewayConnectionResponse.RoutingWeight,
                    getVirtualNetworkGatewayConnectionResponse.SharedKey, getVirtualNetworkGatewayConnectionResponse.ConnectionStatus,
                    getVirtualNetworkGatewayConnectionResponse.EgressBytesTransferred, getVirtualNetworkGatewayConnectionResponse.IngressBytesTransferred,
                    getVirtualNetworkGatewayConnectionResponse.EnableBgp);

                Assert.Equal(VirtualNetworkGatewayConnectionType.IPsec, getVirtualNetworkGatewayConnectionResponse.ConnectionType);
                Assert.True(getVirtualNetworkGatewayConnectionResponse.EnableBgp);

                // 4. ListVitualNetworkGatewayConnections API
                var listVirtualNetworkGatewayConectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.List(resourceGroupName);
                Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.Count());
                Assert.Equal(1, listVirtualNetworkGatewayConectionResponse.Count());

                // 5A. DeleteVirtualNetworkGatewayConnection API
                networkManagementClient.VirtualNetworkGatewayConnections.Delete(resourceGroupName, VirtualNetworkGatewayConnectionName);

                // 5B. ListVitualNetworkGatewayConnections API after DeleteVirtualNetworkGatewayConnection API called
                listVirtualNetworkGatewayConectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.List(resourceGroupName);
                Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.Count());
                Assert.Equal(0, listVirtualNetworkGatewayConectionResponse.Count());

            }
        }

        // Tests Resource:-VirtualNetworkGatewayConnection 5 APIs & Set-Remove default site
        [Fact]
        public void VirtualNetworkGatewayConnectionOperationsApisTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
                var putVirtualNetworkGatewayConnectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.CreateOrUpdate(resourceGroupName, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConneciton);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayConnectionResponse.ProvisioningState);

                // 2. GetVirtualNetworkGatewayConnection API
                var getVirtualNetworkGatewayConnectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.Get(resourceGroupName, VirtualNetworkGatewayConnectionName);
                Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, ConnectionType={6} RoutingWeight={7} SharedKey={8}" +
                    "ConnectionStatus={9}, EgressBytesTransferred={10}, IngressBytesTransferred={11}",
                    getVirtualNetworkGatewayConnectionResponse.Location, getVirtualNetworkGatewayConnectionResponse.Id,
                    getVirtualNetworkGatewayConnectionResponse.Name,
                    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGateway1.Id,
                    getVirtualNetworkGatewayConnectionResponse.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.LocalNetworkGateway2.Id,
                    getVirtualNetworkGatewayConnectionResponse.ConnectionType, getVirtualNetworkGatewayConnectionResponse.RoutingWeight,
                    getVirtualNetworkGatewayConnectionResponse.SharedKey, getVirtualNetworkGatewayConnectionResponse.ConnectionStatus,
                    getVirtualNetworkGatewayConnectionResponse.EgressBytesTransferred, getVirtualNetworkGatewayConnectionResponse.IngressBytesTransferred);

                Assert.Equal(VirtualNetworkGatewayConnectionType.IPsec, getVirtualNetworkGatewayConnectionResponse.ConnectionType);
                Assert.Equal(3, getVirtualNetworkGatewayConnectionResponse.RoutingWeight);
                Assert.Equal("abc", getVirtualNetworkGatewayConnectionResponse.SharedKey);

                // 2A. Remove Default local network site
                getVirtualNetworkGatewayResponse.GatewayDefaultSite = null;
                putVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.ProvisioningState);
                getVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);
                Assert.Null(getVirtualNetworkGatewayResponse.GatewayDefaultSite);
                Console.WriteLine("Default site removal from Virtual network gateway is successful.", getVirtualNetworkGatewayResponse.GatewayDefaultSite);

                // 3A. UpdateVirtualNetworkGatewayConnection API :- RoutingWeight = 3 => 4, SharedKey = "abc"=> "xyz"
                virtualNetworkGatewayConneciton.RoutingWeight = 4;
                virtualNetworkGatewayConneciton.SharedKey = "xyz";

                putVirtualNetworkGatewayConnectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.CreateOrUpdate(resourceGroupName, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConneciton);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayConnectionResponse.ProvisioningState);

                // 3B. GetVirtualNetworkGatewayConnection API after Updating RoutingWeight = 3 => 4, SharedKey = "abc"=> "xyz"
                getVirtualNetworkGatewayConnectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.Get(resourceGroupName, VirtualNetworkGatewayConnectionName);
                Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, ConnectionType={6} RoutingWeight={7} SharedKey={8}" +
                    "ConnectionStatus={9}, EgressBytesTransferred={10}, IngressBytesTransferred={11}",
                    getVirtualNetworkGatewayConnectionResponse.Location, getVirtualNetworkGatewayConnectionResponse.Id,
                    getVirtualNetworkGatewayConnectionResponse.Name,
                    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGateway1.Id,
                    getVirtualNetworkGatewayConnectionResponse.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.LocalNetworkGateway2.Id,
                    getVirtualNetworkGatewayConnectionResponse.ConnectionType, getVirtualNetworkGatewayConnectionResponse.RoutingWeight,
                    getVirtualNetworkGatewayConnectionResponse.SharedKey, getVirtualNetworkGatewayConnectionResponse.ConnectionStatus,
                    getVirtualNetworkGatewayConnectionResponse.EgressBytesTransferred, getVirtualNetworkGatewayConnectionResponse.IngressBytesTransferred);
                Assert.Equal(4, getVirtualNetworkGatewayConnectionResponse.RoutingWeight);
                Assert.Equal("xyz", getVirtualNetworkGatewayConnectionResponse.SharedKey);

                // 4. ListVitualNetworkGatewayConnections API
                var listVirtualNetworkGatewayConectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.List(resourceGroupName);
                Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.Count());
                Assert.Equal(1, listVirtualNetworkGatewayConectionResponse.Count());

                // 5A. DeleteVirtualNetworkGatewayConnection API
                networkManagementClient.VirtualNetworkGatewayConnections.Delete(resourceGroupName, VirtualNetworkGatewayConnectionName);

                // 5B. ListVitualNetworkGatewayConnections API after DeleteVirtualNetworkGatewayConnection API called
                listVirtualNetworkGatewayConectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.List(resourceGroupName);
                Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.Count());
                Assert.Equal(0, listVirtualNetworkGatewayConectionResponse.Count());

            }
        }

        // Tests Resource:-VirtualNetworkGatewayConnectionSharedKey 3 APIs:-
        [Fact]
        public void VirtualNetworkGatewayConnectionSharedKeyOperationsApisTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
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

                var getVirtualNetworkGatewayConnectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.Get(resourceGroupName, VirtualNetworkGatewayConnectionName);
                Assert.Equal("Succeeded", getVirtualNetworkGatewayConnectionResponse.ProvisioningState);
                Assert.Equal("abc", getVirtualNetworkGatewayConnectionResponse.SharedKey);

                // 2A. VirtualNetworkGatewayConnectionResetSharedKey API
                string connectionSharedKeyName = VirtualNetworkGatewayConnectionName;
                var connectionResetSharedKey = new ConnectionResetSharedKey()
                {
                    KeyLength = 50
                };
                var resetConnectionResetSharedKeyResponse = networkManagementClient.VirtualNetworkGatewayConnections.ResetSharedKey(resourceGroupName, connectionSharedKeyName, connectionResetSharedKey);

                // 2B. GetVirtualNetworkGatewayConnectionSharedKey API after VirtualNetworkGatewayConnectionResetSharedKey API was called
                var getconnectionSharedKeyResponse = networkManagementClient.VirtualNetworkGatewayConnections.GetSharedKey(resourceGroupName, connectionSharedKeyName);
                Console.WriteLine("ConnectionSharedKey details:- Value: {0}", getconnectionSharedKeyResponse.Value);
                Assert.NotEqual("abc", getconnectionSharedKeyResponse.Value);

                // 3A.SetVirtualNetworkGatewayConnectionSharedKey API on created connection above:- virtualNetworkGatewayConneciton
                var connectionSharedKey = new ConnectionSharedKey()
                {
                    Value = "TestSharedKeyValue"
                };
                var putConnectionSharedKeyResponse = networkManagementClient.VirtualNetworkGatewayConnections.SetSharedKey(resourceGroupName, connectionSharedKeyName, connectionSharedKey);

                // 3B. GetVirtualNetworkGatewayConnectionSharedKey API
                getconnectionSharedKeyResponse = networkManagementClient.VirtualNetworkGatewayConnections.GetSharedKey(resourceGroupName, connectionSharedKeyName);
                Console.WriteLine("ConnectionSharedKey details:- Value: {0}", getconnectionSharedKeyResponse.Value);
                Assert.Equal("TestSharedKeyValue", getconnectionSharedKeyResponse.Value);
            }
        }

        // Tests Resource:-VirtualNetworkGateway P2S APIs:-
        [Fact]
        public void VirtualNetworkGatewayP2SOperationsApisTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
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

                // Create LocalNetworkGateway to set as default site
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

                // 1.CreateVirtualNetworkGateway API

                // A.Prerequisite:-Create PublicIPAddress(Gateway Ip) using Put PublicIPAddress API
                string publicIpName = TestUtilities.GenerateName();
                string domainNameLabel = TestUtilities.GenerateName();

                var nic1publicIp = TestHelper.CreateDefaultPublicIpAddress(publicIpName, resourceGroupName, domainNameLabel, location, networkManagementClient);
                Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);


                // B.Prerequisite:-Create Virtual Network using Put VirtualNetwork API

                string vnetName = TestUtilities.GenerateName();
                string subnetName = "GatewaySubnet";

                var virtualNetwork = TestHelper.CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location, networkManagementClient);

                var getSubnetResponse = networkManagementClient.Subnets.Get(resourceGroupName, vnetName, subnetName);
                Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Id);

                // C.CreateVirtualNetworkGateway API with P2S client Address Pool defined
                string virtualNetworkGatewayName = TestUtilities.GenerateName();
                string ipConfigName = TestUtilities.GenerateName();
                string addressPrefixes = "192.168.0.0/16";
                string newAddressPrefixes = "200.168.0.0/16";

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
                    },
                    VpnClientConfiguration = new VpnClientConfiguration()
                    {
                        VpnClientAddressPool = new AddressSpace()
                        {
                            AddressPrefixes = new List<string>()
                            {
                                addressPrefixes
                            }
                        }
                    }
                };

                var putVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, virtualNetworkGateway);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.ProvisioningState);

                // 2.GetVirtualNetworkGateway API
                var getVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);
                Console.WriteLine("Gateway details:- GatewayLocation:{0}, GatewayId:{1}, GatewayName:{2}, GatewayType:{3}, VpnType={4} GatewaySku: name-{5} Tier-{6}",
                    getVirtualNetworkGatewayResponse.Location,
                    getVirtualNetworkGatewayResponse.Id, getVirtualNetworkGatewayResponse.Name,
                    getVirtualNetworkGatewayResponse.GatewayType, getVirtualNetworkGatewayResponse.VpnType,
                    getVirtualNetworkGatewayResponse.Sku.Name, getVirtualNetworkGatewayResponse.Sku.Tier);
                Assert.Equal(VirtualNetworkGatewayType.Vpn, getVirtualNetworkGatewayResponse.GatewayType);
                Assert.Equal(VpnType.RouteBased, getVirtualNetworkGatewayResponse.VpnType);
                Assert.Equal(VirtualNetworkGatewaySkuTier.Basic, getVirtualNetworkGatewayResponse.Sku.Tier);
                Assert.NotNull(getVirtualNetworkGatewayResponse.VpnClientConfiguration);
                Assert.NotNull(getVirtualNetworkGatewayResponse.VpnClientConfiguration.VpnClientAddressPool);
                Assert.True(getVirtualNetworkGatewayResponse.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes.Count == 1 &&
                    getVirtualNetworkGatewayResponse.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes[0].Equals(addressPrefixes), "P2S client Address Pool is not set on Gateway!");

                // 3.Update P2S VPNClient Address Pool
                getVirtualNetworkGatewayResponse.VpnClientConfiguration = new VpnClientConfiguration()
                {
                    VpnClientAddressPool = new AddressSpace()
                    {
                        AddressPrefixes = new List<string>()
                        {
                           newAddressPrefixes
                        }
                    }
                };
                getVirtualNetworkGatewayResponse.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes = new List<string>() { newAddressPrefixes };
                putVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.ProvisioningState);

                getVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);
                Assert.NotNull(getVirtualNetworkGatewayResponse.VpnClientConfiguration);
                Assert.NotNull(getVirtualNetworkGatewayResponse.VpnClientConfiguration.VpnClientAddressPool);
                Assert.True(getVirtualNetworkGatewayResponse.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes.Count == 1 &&
                    getVirtualNetworkGatewayResponse.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes[0].Equals(newAddressPrefixes), "P2S client Address Pool Update is Failed!");

                // 3.Add client Root certificate
                string clientRootCertName = "BrkLiteTestMSFTRootCA.cer";
                // [SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
                string samplePublicCertData = "MIIDUzCCAj+gAwIBAgIQRggGmrpGj4pCblTanQRNUjAJBgUrDgMCHQUAMDQxEjAQBgNVBAoTCU1pY3Jvc29mdDEeMBwGA1UEAxMVQnJrIExpdGUgVGVzdCBSb290IENBMB4XDTEzMDExOTAwMjQxOFoXDTIxMDExOTAwMjQxN1owNDESMBAGA1UEChMJTWljcm9zb2Z0MR4wHAYDVQQDExVCcmsgTGl0ZSBUZXN0IFJvb3QgQ0EwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQC7SmE+iPULK0Rs7mQBO/6a6B6/G9BaMxHgDGzAmSG0Qsyt5e08aqgFnPdkMl3zRJw3lPKGha/JCvHRNrO8UpeAfc4IXWaqxx2iBipHjwmHPHh7+VB8lU0EJcUe7WBAI2n/sgfCwc+xKtuyRVlOhT6qw/nAi8e5don/iHPU6q7GCcnqoqtceQ/pJ8m66cvAnxwJlBFOTninhb2VjtvOfMQ07zPP+ZuYDPxvX5v3nd6yDa98yW4dZPuiGO2s6zJAfOPT2BrtyvLekItnSgAw3U5C0bOb+8XVKaDZQXbGEtOw6NZvD4L2yLd47nGkN2QXloiPLGyetrj3Z2pZYcrZBo8hAgMBAAGjaTBnMGUGA1UdAQReMFyAEOncRAPNcvJDoe4WP/gH2U+hNjA0MRIwEAYDVQQKEwlNaWNyb3NvZnQxHjAcBgNVBAMTFUJyayBMaXRlIFRlc3QgUm9vdCBDQYIQRggGmrpGj4pCblTanQRNUjAJBgUrDgMCHQUAA4IBAQCGyHhMdygS0g2tEUtRT4KFM+qqUY5HBpbIXNAav1a1dmXpHQCziuuxxzu3iq4XwnWUF1OabdDE2cpxNDOWxSsIxfEBf9ifaoz/O1ToJ0K757q2Rm2NWqQ7bNN8ArhvkNWa95S9gk9ZHZLUcjqanf0F8taJCYgzcbUSp+VBe9DcN89sJpYvfiBiAsMVqGPc/fHJgTScK+8QYrTRMubtFmXHbzBSO/KTAP5rBTxse88EGjK5F8wcedvge2Ksk6XjL3sZ19+Oj8KTQ72wihN900p1WQldHrrnbixSpmHBXbHr9U0NQigrJp5NphfuU5j81C8ixvfUdwyLmTv7rNA7GTAD";
                VpnClientRootCertificate clientRootCert = new VpnClientRootCertificate()
                {
                    Name = clientRootCertName,
                    PublicCertData = samplePublicCertData
                };
                getVirtualNetworkGatewayResponse.VpnClientConfiguration.VpnClientRootCertificates = new List<VpnClientRootCertificate> { clientRootCert };

                putVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.ProvisioningState);

                // 4. Get client Root certificates
                getVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);
                Assert.NotNull(getVirtualNetworkGatewayResponse.VpnClientConfiguration);
                Assert.True(getVirtualNetworkGatewayResponse.VpnClientConfiguration.VpnClientRootCertificates.Count() == 1 &&
                    getVirtualNetworkGatewayResponse.VpnClientConfiguration.VpnClientRootCertificates[0].Name.Equals(clientRootCertName), "Vpn client Root certificate upload was Failed!");

                // 5.Generate P2S Vpnclient package
                var vpnClientParameters = new VpnClientParameters()
                {
                    ProcessorArchitecture = ProcessorArchitecture.Amd64
                };
                string packageUrl = networkManagementClient.VirtualNetworkGateways.Generatevpnclientpackage(resourceGroupName, virtualNetworkGatewayName, vpnClientParameters);
                //Assert.NotNull(packageUrl);
                //Assert.NotEmpty(packageUrl);
                //Console.WriteLine("Vpn client package Url = {0}", packageUrl);

                // 6.Delete client Root certificate
                getVirtualNetworkGatewayResponse.VpnClientConfiguration.VpnClientRootCertificates.Clear();

                putVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.ProvisioningState);

                getVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);
                Assert.True(getVirtualNetworkGatewayResponse.VpnClientConfiguration.VpnClientRootCertificates.Count() == 0);

                // 7. Get Vpn client revoked certificates
                Assert.True(getVirtualNetworkGatewayResponse.VpnClientConfiguration.VpnClientRevokedCertificates.Count() == 0);

                // 8. Try to revoke Vpn client certificate which is not there and verify proper error comes back
                string sampleCertThumpprint = "5405D9A8AB2A303D4E772C444BC88C3B97F55F78";
                VpnClientRevokedCertificate sampleClientCert = new VpnClientRevokedCertificate()
                {
                    Name = "sampleClientCert.cer",
                    Thumbprint = sampleCertThumpprint
                };
                getVirtualNetworkGatewayResponse.VpnClientConfiguration.VpnClientRevokedCertificates = new List<VpnClientRevokedCertificate> { sampleClientCert };

                putVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.ProvisioningState);
                getVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);
                Assert.True(getVirtualNetworkGatewayResponse.VpnClientConfiguration.VpnClientRevokedCertificates.Count() == 1);
                Assert.Equal(getVirtualNetworkGatewayResponse.VpnClientConfiguration.VpnClientRevokedCertificates[0].Name, "sampleClientCert.cer");

                // 9. Unrevoke previously revoked Vpn client certificate
                getVirtualNetworkGatewayResponse.VpnClientConfiguration.VpnClientRevokedCertificates.Clear();
                putVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.ProvisioningState);
                getVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);
                Assert.True(getVirtualNetworkGatewayResponse.VpnClientConfiguration.VpnClientRevokedCertificates.Count() == 0);
            }
        }


        // Tests Resource:-VirtualNetworkGateway ActiveActive Feature Test:-
        [Fact]
        public void VirtualNetworkGatewayActiveActiveFeatureTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
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

                // 1. Create Active-Active VirtualNetworkGateway

                // A. Prerequisite:- Create PublicIPAddress(Gateway Ip) using Put PublicIPAddress API
                string publicIpName1 = TestUtilities.GenerateName();
                string domainNameLabel1 = TestUtilities.GenerateName();

                var nic1publicIp1 = TestHelper.CreateDefaultPublicIpAddress(publicIpName1, resourceGroupName, domainNameLabel1, location, networkManagementClient);
                Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp1.Id);

                string publicIpName2 = TestUtilities.GenerateName();
                string domainNameLabel2 = TestUtilities.GenerateName();

                var nic1publicIp2 = TestHelper.CreateDefaultPublicIpAddress(publicIpName2, resourceGroupName, domainNameLabel2, location, networkManagementClient);
                Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp2.Id);

                //B.Prerequisite:-Create Virtual Network using Put VirtualNetwork API

                string vnetName = TestUtilities.GenerateName();
                string subnetName = "GatewaySubnet";

                var virtualNetwork = TestHelper.CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location, networkManagementClient);

                var getSubnetResponse = networkManagementClient.Subnets.Get(resourceGroupName, vnetName, subnetName);
                Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Id);

                // C. CreateVirtualNetworkGateway API
                string virtualNetworkGatewayName = TestUtilities.GenerateName();
                string ipConfigName1 = TestUtilities.GenerateName();
                VirtualNetworkGatewayIPConfiguration ipconfig1 = new VirtualNetworkGatewayIPConfiguration()
                {
                    Name = ipConfigName1,
                    PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                    PublicIPAddress = new SubResource()
                    {
                        Id = nic1publicIp1.Id
                    },
                    Subnet = new SubResource()
                    {
                        Id = getSubnetResponse.Id
                    }
                };

                string ipConfigName2 = TestUtilities.GenerateName();
                VirtualNetworkGatewayIPConfiguration ipconfig2 = new VirtualNetworkGatewayIPConfiguration()
                {
                    Name = ipConfigName2,
                    PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                    PublicIPAddress = new SubResource()
                    {
                        Id = nic1publicIp2.Id
                    },
                    Subnet = new SubResource()
                    {
                        Id = getSubnetResponse.Id
                    }
                };

                var virtualNetworkGateway = new VirtualNetworkGateway()
                {
                    Location = location,
                    Tags = new Dictionary<string, string>()
                        {
                           {"key","value"}
                        },
                    EnableBgp = false,
                    ActiveActive = true,
                    GatewayDefaultSite = null,
                    GatewayType = VirtualNetworkGatewayType.Vpn,
                    VpnType = VpnType.RouteBased,
                    IpConfigurations = new List<VirtualNetworkGatewayIPConfiguration>()
                    {
                        ipconfig1,
                        ipconfig2
                    },
                    Sku = new VirtualNetworkGatewaySku()
                    {
                        Name = VirtualNetworkGatewaySkuName.HighPerformance,
                        Tier = VirtualNetworkGatewaySkuTier.HighPerformance
                    }
                };

                var putVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, virtualNetworkGateway);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.ProvisioningState);

                // 2. GetVirtualNetworkGateway API
                var getVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);
                Console.WriteLine("Gateway details:- GatewayLocation:{0}, GatewayId:{1}, GatewayName:{2}, GatewayType:{3}, VpnType={4} GatewaySku: name-{5} Tier-{6} ActiveActive enabled-{7}",
                    getVirtualNetworkGatewayResponse.Location,
                    getVirtualNetworkGatewayResponse.Id, getVirtualNetworkGatewayResponse.Name,
                    getVirtualNetworkGatewayResponse.GatewayType, getVirtualNetworkGatewayResponse.VpnType,
                    getVirtualNetworkGatewayResponse.Sku.Name, getVirtualNetworkGatewayResponse.Sku.Tier,
                    getVirtualNetworkGatewayResponse.ActiveActive);
                Assert.Equal(VirtualNetworkGatewayType.Vpn, getVirtualNetworkGatewayResponse.GatewayType);
                Assert.Equal(VpnType.RouteBased, getVirtualNetworkGatewayResponse.VpnType);
                Assert.Equal(VirtualNetworkGatewaySkuTier.HighPerformance, getVirtualNetworkGatewayResponse.Sku.Tier);
                Assert.Equal(2, getVirtualNetworkGatewayResponse.IpConfigurations.Count);
                Assert.Equal(true, getVirtualNetworkGatewayResponse.ActiveActive);

                // 3. Update ActiveActive VirtualNetworkGateway to ActiveStandby
                getVirtualNetworkGatewayResponse.ActiveActive = false;
                getVirtualNetworkGatewayResponse.IpConfigurations.Remove(getVirtualNetworkGatewayResponse.IpConfigurations.First(config => config.Name.Equals(ipconfig2.Name)));
                putVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.ProvisioningState);

                getVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);
                Assert.Equal(false, getVirtualNetworkGatewayResponse.ActiveActive);
                Assert.Equal(1, getVirtualNetworkGatewayResponse.IpConfigurations.Count);

                // 4. Update ActiveStandby VirtualNetworkGateway to ActiveActive again
                getVirtualNetworkGatewayResponse.ActiveActive = true;
                getVirtualNetworkGatewayResponse.IpConfigurations.Add(ipconfig2);
                putVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.ProvisioningState);

                getVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);
                Assert.Equal(true, getVirtualNetworkGatewayResponse.ActiveActive);
                Assert.Equal(2, getVirtualNetworkGatewayResponse.IpConfigurations.Count);
            }
        }
    }
}