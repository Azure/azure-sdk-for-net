// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Networks.Tests.Helpers;
using ResourceGroups.Tests;
using Xunit;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;

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
        private TestEnvironment _testEnvironment;

        private enum TestEnvironmentSettings
        {
            ClientRootCertName,
            SamplePublicCertData,
            SampleCertThumbprint
        }

        public GatewayOperationsTests()
        {
            HttpMockServer.RecordsDirectory = "SessionRecords";
            this._testEnvironment = TestEnvironmentFactory.GetTestEnvironment();

            // Initialize your custom data here
            // The following need to be populated if the test needs it - CertName, CertData, CertThumbprint
            // this._testEnvironment.ConnectionString.KeyValuePairs.Add(TestEnvironmentSettings.ClientRootCertName.ToString(), "CertificateName");
            // this._testEnvironment.ConnectionString.KeyValuePairs.Add(TestEnvironmentSettings.SamplePublicCertData.ToString(), "Base64 encoded certificate data");
            // this._testEnvironment.ConnectionString.KeyValuePairs.Add(TestEnvironmentSettings.SampleCertThumbprint.ToString(), "Certificate Thumbprint");
        }

        // Tests Resource:-VirtualNetworkGateway 6 APIs:-
        [Fact(Skip="Disable tests")]
        public void VirtualNetworkGatewayOperationsApisTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
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
                var resetVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.Reset(resourceGroupName, virtualNetworkGatewayName);
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
                Assert.Single(listVirtualNetworkGatewayResponse);

                // 6A. DeleteVirtualNetworkGateway API
                networkManagementClient.VirtualNetworkGateways.Delete(resourceGroupName, virtualNetworkGatewayName);

                // 6B. ListVitualNetworkGateways API after deleting VirtualNetworkGateway
                listVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.List(resourceGroupName);

                Console.WriteLine("ListVirtualNetworkGateways count ={0} ", listVirtualNetworkGatewayResponse.Count());
                Assert.Empty(listVirtualNetworkGatewayResponse);
            }
        }

        // Tests Resource:-LocalNetworkGateway 5 APIs:-
        [Fact(Skip="Disable tests")]
        public void LocalNettworkGatewayOperationsApisTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
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
                Assert.Single(listLocalNetworkGatewayResponse);

                // 5A. DeleteLocalNetworkGateway API
                networkManagementClient.LocalNetworkGateways.Delete(resourceGroupName, localNetworkGatewayName);

                // 5B. ListLocalNetworkGateways API after DeleteLocalNetworkGateway API was called
                listLocalNetworkGatewayResponse = networkManagementClient.LocalNetworkGateways.List(resourceGroupName);
                Console.WriteLine("ListLocalNetworkGateways count ={0} ", listLocalNetworkGatewayResponse.Count());
                Assert.Empty(listLocalNetworkGatewayResponse);
            }
        }

        [Fact(Skip="Disable tests")]
        public void VirtualNetworkGatewayConnectionWithBgpTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
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
                Assert.Single(listVirtualNetworkGatewayConectionResponse);

                // 5A. DeleteVirtualNetworkGatewayConnection API
                networkManagementClient.VirtualNetworkGatewayConnections.Delete(resourceGroupName, VirtualNetworkGatewayConnectionName);

                // 5B. ListVitualNetworkGatewayConnections API after DeleteVirtualNetworkGatewayConnection API called
                listVirtualNetworkGatewayConectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.List(resourceGroupName);
                Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.Count());
                Assert.Empty(listVirtualNetworkGatewayConectionResponse);

            }
        }

        // Tests Resource:-VirtualNetworkGatewayConnection with Ipsec Policies
        [Fact(Skip="Disable tests")]
        public void VirtualNetworkGatewayConnectionWithIpsecPoliciesTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
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
                        Name = VirtualNetworkGatewaySkuName.Standard,
                        Tier = VirtualNetworkGatewaySkuTier.Standard
                    }
                };

                var putVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, virtualNetworkGateway);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.ProvisioningState);
                Console.WriteLine("Virtual Network Gateway is deployed successfully.");
                var getVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);

                // C. CreaetVirtualNetworkGatewayConnection API - Ipsec policy and policybased TS enabled
                string VirtualNetworkGatewayConnectionName = TestUtilities.GenerateName();
                var virtualNetworkGatewayConnection = new VirtualNetworkGatewayConnection()
                {
                    Location = location,
                    VirtualNetworkGateway1 = getVirtualNetworkGatewayResponse,
                    LocalNetworkGateway2 = getLocalNetworkGatewayResponse,
                    ConnectionType = VirtualNetworkGatewayConnectionType.IPsec,
                    RoutingWeight = 3,
                    SharedKey = "abc"
                };

                virtualNetworkGatewayConnection.IpsecPolicies = new List<IpsecPolicy>()
                {
                    new IpsecPolicy()
                    {
                        IpsecEncryption = IpsecEncryption.AES128,
                        IpsecIntegrity = IpsecIntegrity.SHA256,
                        IkeEncryption = IkeEncryption.AES192,
                        IkeIntegrity = IkeIntegrity.SHA1,
                        DhGroup = DhGroup.DHGroup2,
                        PfsGroup = PfsGroup.PFS1,
                        SaDataSizeKilobytes = 1024,
                        SaLifeTimeSeconds = 300
                    }
                };
                virtualNetworkGatewayConnection.UsePolicyBasedTrafficSelectors = true;

                var putVirtualNetworkGatewayConnectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.CreateOrUpdate(resourceGroupName, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConnection);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayConnectionResponse.ProvisioningState);

                // 2. GetVirtualNetworkGatewayConnection API
                var getVirtualNetworkGatewayConnectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.Get(resourceGroupName, VirtualNetworkGatewayConnectionName);
                Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, " +
                    "IpsecPolicies Count={6}, UsePolicyBasedTS={7}",
                    getVirtualNetworkGatewayConnectionResponse.Location, getVirtualNetworkGatewayConnectionResponse.Id,
                    getVirtualNetworkGatewayConnectionResponse.Name,
                    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGateway1.Id,
                    getVirtualNetworkGatewayConnectionResponse.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.LocalNetworkGateway2.Id,
                    getVirtualNetworkGatewayConnectionResponse.IpsecPolicies.Count, getVirtualNetworkGatewayConnectionResponse.UsePolicyBasedTrafficSelectors);

                Assert.Equal(VirtualNetworkGatewayConnectionType.IPsec, getVirtualNetworkGatewayConnectionResponse.ConnectionType);
                Assert.Equal(virtualNetworkGatewayConnection.UsePolicyBasedTrafficSelectors, getVirtualNetworkGatewayConnectionResponse.UsePolicyBasedTrafficSelectors);
                Assert.Equal(virtualNetworkGatewayConnection.IpsecPolicies.Count, getVirtualNetworkGatewayConnectionResponse.IpsecPolicies.Count);
                Assert.Equal(virtualNetworkGatewayConnection.IpsecPolicies[0].IpsecEncryption, getVirtualNetworkGatewayConnectionResponse.IpsecPolicies[0].IpsecEncryption);
                Assert.Equal(virtualNetworkGatewayConnection.IpsecPolicies[0].IpsecIntegrity, getVirtualNetworkGatewayConnectionResponse.IpsecPolicies[0].IpsecIntegrity);
                Assert.Equal(virtualNetworkGatewayConnection.IpsecPolicies[0].IkeEncryption, getVirtualNetworkGatewayConnectionResponse.IpsecPolicies[0].IkeEncryption);
                Assert.Equal(virtualNetworkGatewayConnection.IpsecPolicies[0].IkeIntegrity, getVirtualNetworkGatewayConnectionResponse.IpsecPolicies[0].IkeIntegrity);
                Assert.Equal(virtualNetworkGatewayConnection.IpsecPolicies[0].DhGroup, getVirtualNetworkGatewayConnectionResponse.IpsecPolicies[0].DhGroup);
                Assert.Equal(virtualNetworkGatewayConnection.IpsecPolicies[0].PfsGroup, getVirtualNetworkGatewayConnectionResponse.IpsecPolicies[0].PfsGroup);
                Assert.Equal(virtualNetworkGatewayConnection.IpsecPolicies[0].SaDataSizeKilobytes, getVirtualNetworkGatewayConnectionResponse.IpsecPolicies[0].SaDataSizeKilobytes);
                Assert.Equal(virtualNetworkGatewayConnection.IpsecPolicies[0].SaLifeTimeSeconds, getVirtualNetworkGatewayConnectionResponse.IpsecPolicies[0].SaLifeTimeSeconds);

                // 3A. UpdateVirtualNetworkGatewayConnection API : update ipsec policies and disable TS
                virtualNetworkGatewayConnection.UsePolicyBasedTrafficSelectors = false;
                virtualNetworkGatewayConnection.IpsecPolicies = new List<IpsecPolicy>()
                {
                    new IpsecPolicy()
                    {
                        IpsecEncryption = IpsecEncryption.GCMAES256,
                        IpsecIntegrity = IpsecIntegrity.GCMAES256,
                        IkeEncryption = IkeEncryption.AES256,
                        IkeIntegrity = IkeIntegrity.SHA384,
                        DhGroup = DhGroup.DHGroup2048,
                        PfsGroup = PfsGroup.ECP384,
                        SaDataSizeKilobytes = 2048,
                        SaLifeTimeSeconds = 600
                    }
                };

                putVirtualNetworkGatewayConnectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.CreateOrUpdate(resourceGroupName, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConnection);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayConnectionResponse.ProvisioningState);

                // 3B. GetVirtualNetworkGatewayConnection API after Updating
                getVirtualNetworkGatewayConnectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.Get(resourceGroupName, VirtualNetworkGatewayConnectionName);
                Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, " +
                    "IpsecPolicies Count={6}, UsePolicyBasedTS={7}",
                    getVirtualNetworkGatewayConnectionResponse.Location, getVirtualNetworkGatewayConnectionResponse.Id,
                    getVirtualNetworkGatewayConnectionResponse.Name,
                    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGateway1.Id,
                    getVirtualNetworkGatewayConnectionResponse.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.LocalNetworkGateway2.Id,
                    getVirtualNetworkGatewayConnectionResponse.IpsecPolicies.Count, getVirtualNetworkGatewayConnectionResponse.UsePolicyBasedTrafficSelectors);

                Assert.Equal(virtualNetworkGatewayConnection.UsePolicyBasedTrafficSelectors, getVirtualNetworkGatewayConnectionResponse.UsePolicyBasedTrafficSelectors);
                Assert.Equal(virtualNetworkGatewayConnection.IpsecPolicies.Count, getVirtualNetworkGatewayConnectionResponse.IpsecPolicies.Count);
                Assert.Equal(virtualNetworkGatewayConnection.IpsecPolicies[0].IpsecEncryption, getVirtualNetworkGatewayConnectionResponse.IpsecPolicies[0].IpsecEncryption);
                Assert.Equal(virtualNetworkGatewayConnection.IpsecPolicies[0].IpsecIntegrity, getVirtualNetworkGatewayConnectionResponse.IpsecPolicies[0].IpsecIntegrity);
                Assert.Equal(virtualNetworkGatewayConnection.IpsecPolicies[0].IkeEncryption, getVirtualNetworkGatewayConnectionResponse.IpsecPolicies[0].IkeEncryption);
                Assert.Equal(virtualNetworkGatewayConnection.IpsecPolicies[0].IkeIntegrity, getVirtualNetworkGatewayConnectionResponse.IpsecPolicies[0].IkeIntegrity);
                Assert.Equal(virtualNetworkGatewayConnection.IpsecPolicies[0].DhGroup, getVirtualNetworkGatewayConnectionResponse.IpsecPolicies[0].DhGroup);
                Assert.Equal(virtualNetworkGatewayConnection.IpsecPolicies[0].PfsGroup, getVirtualNetworkGatewayConnectionResponse.IpsecPolicies[0].PfsGroup);
                Assert.Equal(virtualNetworkGatewayConnection.IpsecPolicies[0].SaDataSizeKilobytes, getVirtualNetworkGatewayConnectionResponse.IpsecPolicies[0].SaDataSizeKilobytes);
                Assert.Equal(virtualNetworkGatewayConnection.IpsecPolicies[0].SaLifeTimeSeconds, getVirtualNetworkGatewayConnectionResponse.IpsecPolicies[0].SaLifeTimeSeconds);

                // 4A. UpdateVirtualNetworkGatewayConnection API : remove ipsec policies
                virtualNetworkGatewayConnection.IpsecPolicies = null;

                putVirtualNetworkGatewayConnectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.CreateOrUpdate(resourceGroupName, VirtualNetworkGatewayConnectionName, virtualNetworkGatewayConnection);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayConnectionResponse.ProvisioningState);

                // 4B. GetVirtualNetworkGatewayConnection API after Updating
                getVirtualNetworkGatewayConnectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.Get(resourceGroupName, VirtualNetworkGatewayConnectionName);
                Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, " +
                    "IpsecPolicies Count={6}, UsePolicyBasedTS={7}",
                    getVirtualNetworkGatewayConnectionResponse.Location, getVirtualNetworkGatewayConnectionResponse.Id,
                    getVirtualNetworkGatewayConnectionResponse.Name,
                    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGateway1.Id,
                    getVirtualNetworkGatewayConnectionResponse.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.LocalNetworkGateway2.Id,
                    getVirtualNetworkGatewayConnectionResponse.IpsecPolicies.Count, getVirtualNetworkGatewayConnectionResponse.UsePolicyBasedTrafficSelectors);

                Assert.Equal(virtualNetworkGatewayConnection.UsePolicyBasedTrafficSelectors, getVirtualNetworkGatewayConnectionResponse.UsePolicyBasedTrafficSelectors);
                Assert.Equal(0, getVirtualNetworkGatewayConnectionResponse.IpsecPolicies.Count);

                // 4. ListVitualNetworkGatewayConnections API
                var listVirtualNetworkGatewayConectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.List(resourceGroupName);
                Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.Count());
                Assert.Single(listVirtualNetworkGatewayConectionResponse);

                // 5A. DeleteVirtualNetworkGatewayConnection API
                networkManagementClient.VirtualNetworkGatewayConnections.Delete(resourceGroupName, VirtualNetworkGatewayConnectionName);

                // 5B. ListVitualNetworkGatewayConnections API after DeleteVirtualNetworkGatewayConnection API called
                listVirtualNetworkGatewayConectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.List(resourceGroupName);
                Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.Count());
                Assert.Empty(listVirtualNetworkGatewayConectionResponse);
            }
        }

        // Tests Resource:-VirtualNetworkGatewayConnection 5 APIs & Set-Remove default site
        [Fact(Skip="Disable tests")]
        public void VirtualNetworkGatewayConnectionOperationsApisTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
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

                // 4A. ListVirtualNetworkGatewayConnections API
                var listVirtualNetworkGatewayConectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.List(resourceGroupName);
                Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.Count());
                Assert.Single(listVirtualNetworkGatewayConectionResponse);

                // 4B. VirtualNetworkGateway ListConnections API
                var virtualNetworkGatewayListConnectionsResponse = networkManagementClient.VirtualNetworkGateways.ListConnections(resourceGroupName, virtualNetworkGatewayName);
                Assert.Single(virtualNetworkGatewayListConnectionsResponse);
                Assert.Equal(VirtualNetworkGatewayConnectionName, virtualNetworkGatewayListConnectionsResponse.First().Name);

                // 5A. DeleteVirtualNetworkGatewayConnection API
                networkManagementClient.VirtualNetworkGatewayConnections.Delete(resourceGroupName, VirtualNetworkGatewayConnectionName);

                // 5B. ListVitualNetworkGatewayConnections API after DeleteVirtualNetworkGatewayConnection API called
                listVirtualNetworkGatewayConectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.List(resourceGroupName);
                Console.WriteLine("ListVirtualNetworkGatewayConnections count ={0} ", listVirtualNetworkGatewayConectionResponse.Count());
                Assert.Empty(listVirtualNetworkGatewayConectionResponse);

            }
        }

        // Tests Resource:-VirtualNetworkGatewayConnectionSharedKey 3 APIs:-
        [Fact(Skip="Disable tests")]
        public void VirtualNetworkGatewayConnectionSharedKeyOperationsApisTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
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
        [Fact(Skip="Disable tests")]
        public void VirtualNetworkGatewayP2SOperationsApisTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
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
                string clientRootCertName = this._testEnvironment.ConnectionString.KeyValuePairs[TestEnvironmentSettings.ClientRootCertName.ToString()];
                string samplePublicCertData = this._testEnvironment.ConnectionString.KeyValuePairs[TestEnvironmentSettings.SamplePublicCertData.ToString()];
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
                string sampleCertThumpprint = this._testEnvironment.ConnectionString.KeyValuePairs[TestEnvironmentSettings.SampleCertThumbprint.ToString()];
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
                Assert.Equal("sampleClientCert.cer", getVirtualNetworkGatewayResponse.VpnClientConfiguration.VpnClientRevokedCertificates[0].Name);

                // 9. Unrevoke previously revoked Vpn client certificate
                getVirtualNetworkGatewayResponse.VpnClientConfiguration.VpnClientRevokedCertificates.Clear();
                putVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.ProvisioningState);
                getVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);
                Assert.True(getVirtualNetworkGatewayResponse.VpnClientConfiguration.VpnClientRevokedCertificates.Count() == 0);
            }
        }


        // Tests Resource:-VirtualNetworkGateway ActiveActive Feature Test:-
        [Fact(Skip="Disable tests")]
        public void VirtualNetworkGatewayActiveActiveFeatureTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
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
                Assert.True(getVirtualNetworkGatewayResponse.ActiveActive);

                // 3. Update ActiveActive VirtualNetworkGateway to ActiveStandby
                getVirtualNetworkGatewayResponse.ActiveActive = false;
                getVirtualNetworkGatewayResponse.IpConfigurations.Remove(getVirtualNetworkGatewayResponse.IpConfigurations.First(config => config.Name.Equals(ipconfig2.Name)));
                putVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.ProvisioningState);

                getVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);
                Assert.False(getVirtualNetworkGatewayResponse.ActiveActive);
                Assert.Equal(1, getVirtualNetworkGatewayResponse.IpConfigurations.Count);

                // 4. Update ActiveStandby VirtualNetworkGateway to ActiveActive again
                getVirtualNetworkGatewayResponse.ActiveActive = true;
                getVirtualNetworkGatewayResponse.IpConfigurations.Add(ipconfig2);
                putVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.ProvisioningState);

                getVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);
                Assert.True(getVirtualNetworkGatewayResponse.ActiveActive);
                Assert.Equal(2, getVirtualNetworkGatewayResponse.IpConfigurations.Count);
            }
        }

        [Fact(Skip="Disable tests")]
        public void VirtualNetworkGatewayBgpRouteApiTest()
        {
            RecordedDelegatingHandler handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            RecordedDelegatingHandler handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                ResourceManagementClient resourcesClient = ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                NetworkManagementClient networkManagementClient = NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                string location = NetworkManagementTestUtilities.GetResourceLocation(resourcesClient, "Microsoft.Network/virtualnetworkgateways");

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName, new ResourceGroup { Location = location });

                string gatewaySubnetName = "GatewaySubnet";
                string gw1Name = TestUtilities.GenerateName();
                string vnet1Name = TestUtilities.GenerateName();
                string gw1IpName = TestUtilities.GenerateName();
                string gw1IpDomainNameLabel = TestUtilities.GenerateName();
                string gw1IpConfigName = TestUtilities.GenerateName();

                string gw2Name = TestUtilities.GenerateName();
                string vnet2Name = TestUtilities.GenerateName();
                string gw2IpName = TestUtilities.GenerateName();
                string gw2IpDomainNameLabel = TestUtilities.GenerateName();
                string gw2IpConfigName = TestUtilities.GenerateName();

                // Deploy two virtual networks with VPN gateways, in parallel
                List<Task> gatewayDeploymentTasks = new List<Task>
                {
                    Task.Factory.StartNew(() =>
                    {
                        PublicIPAddress gw1Ip = TestHelper.CreateDefaultPublicIpAddress(gw1IpName, resourceGroupName, gw1IpDomainNameLabel, location, networkManagementClient);
                        VirtualNetwork vnet1 = new VirtualNetwork()
                        {
                            Location = location,
                            AddressSpace = new AddressSpace()
                            {
                                AddressPrefixes = new List<string>()
                                {
                                    "10.1.0.0/16",
                                }
                            },
                            Subnets = new List<Subnet>()
                            {
                                new Subnet()
                                {
                                    Name = gatewaySubnetName,
                                    AddressPrefix = "10.1.1.0/24",
                                }
                            }
                        };

                        vnet1 = networkManagementClient.VirtualNetworks.CreateOrUpdate(resourceGroupName, vnet1Name, vnet1);
                        Subnet gw1Subnet = networkManagementClient.Subnets.Get(resourceGroupName, vnet1Name, gatewaySubnetName);
                        VirtualNetworkGatewayIPConfiguration ipconfig1 = new VirtualNetworkGatewayIPConfiguration()
                        {
                            Name = gw1IpConfigName,
                            PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                            PublicIPAddress = new SubResource() { Id = gw1Ip.Id },
                            Subnet = new SubResource() { Id = gw1Subnet.Id }
                        };

                        VirtualNetworkGateway gw1 = new VirtualNetworkGateway()
                        {
                            Location = location,
                            GatewayType = VirtualNetworkGatewayType.Vpn,
                            VpnType = VpnType.RouteBased,
                            IpConfigurations = new List<VirtualNetworkGatewayIPConfiguration>() { ipconfig1 },
                            Sku = new VirtualNetworkGatewaySku()
                            {
                                Name = VirtualNetworkGatewaySkuName.Standard,
                                Tier = VirtualNetworkGatewaySkuTier.Standard
                            },
                            BgpSettings = new BgpSettings()
                            {
                                Asn = 1337,
                                BgpPeeringAddress = null,
                                PeerWeight = 5
                            }
                        };

                        networkManagementClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, gw1Name, gw1);
                    }),
                    Task.Factory.StartNew(() =>
                    {
                        PublicIPAddress gw2Ip = TestHelper.CreateDefaultPublicIpAddress(gw2IpName, resourceGroupName, gw2IpDomainNameLabel, location, networkManagementClient);
                        VirtualNetwork vnet2 = new VirtualNetwork()
                        {
                            Location = location,
                            AddressSpace = new AddressSpace()
                            {
                                AddressPrefixes = new List<string>()
                                {
                                    "10.2.0.0/16",
                                }
                            },
                            Subnets = new List<Subnet>()
                            {
                                new Subnet()
                                {
                                    Name = gatewaySubnetName,
                                    AddressPrefix = "10.2.1.0/24",
                                }
                            }
                        };

                        vnet2 = networkManagementClient.VirtualNetworks.CreateOrUpdate(resourceGroupName, vnet2Name, vnet2);
                        Subnet gw2Subnet = networkManagementClient.Subnets.Get(resourceGroupName, vnet2Name, gatewaySubnetName);
                        VirtualNetworkGatewayIPConfiguration ipconfig1 = new VirtualNetworkGatewayIPConfiguration()
                        {
                            Name = gw2IpConfigName,
                            PrivateIPAllocationMethod = IPAllocationMethod.Dynamic,
                            PublicIPAddress = new SubResource() { Id = gw2Ip.Id },
                            Subnet = new SubResource() { Id = gw2Subnet.Id }
                        };

                        VirtualNetworkGateway gw2 = new VirtualNetworkGateway()
                        {
                            Location = location,
                            GatewayType = VirtualNetworkGatewayType.Vpn,
                            VpnType = VpnType.RouteBased,
                            IpConfigurations = new List<VirtualNetworkGatewayIPConfiguration>() { ipconfig1 },
                            Sku = new VirtualNetworkGatewaySku()
                            {
                                Name = VirtualNetworkGatewaySkuName.Standard,
                                Tier = VirtualNetworkGatewaySkuTier.Standard
                            },
                            BgpSettings = new BgpSettings()
                            {
                                Asn = 9001,
                                BgpPeeringAddress = null,
                                PeerWeight = 5
                            }
                        };

                        networkManagementClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, gw2Name, gw2);
                    })
                };

                Task.WaitAll(gatewayDeploymentTasks.ToArray());

                // Create a vnet to vnet connection between the two gateways
                // configure both gateways in parallel
                VirtualNetworkGateway gw1GetResponse = networkManagementClient.VirtualNetworkGateways.Get(resourceGroupName, gw1Name);
                VirtualNetworkGateway gw2GetResponse = networkManagementClient.VirtualNetworkGateways.Get(resourceGroupName, gw2Name);
                PublicIPAddress gw2IpResponse = networkManagementClient.PublicIPAddresses.Get(resourceGroupName, gw1IpName);
                string sharedKey = "chocolate";
                List<Task> gatewayConnectionTasks = new List<Task>
                {
                    Task.Factory.StartNew(() =>
                    {
                        string conn1Name = TestUtilities.GenerateName();
                        VirtualNetworkGatewayConnection gw1ToGw2Conn = new VirtualNetworkGatewayConnection()
                        {
                            Location = location,
                            VirtualNetworkGateway1 = gw1GetResponse,
                            VirtualNetworkGateway2 = gw2GetResponse,
                            ConnectionType = VirtualNetworkGatewayConnectionType.Vnet2Vnet,
                            RoutingWeight = 3,
                            SharedKey = sharedKey,
                            EnableBgp = true
                        };
                        networkManagementClient.VirtualNetworkGatewayConnections.CreateOrUpdate(resourceGroupName, conn1Name, gw1ToGw2Conn);
                    }),
                    Task.Factory.StartNew(() =>
                    {
                        string conn2Name = TestUtilities.GenerateName();
                        VirtualNetworkGatewayConnection gw2ToGw1Conn = new VirtualNetworkGatewayConnection()
                        {
                            Location = location,
                            VirtualNetworkGateway1 = gw2GetResponse,
                            VirtualNetworkGateway2 = gw1GetResponse,
                            ConnectionType = VirtualNetworkGatewayConnectionType.Vnet2Vnet,
                            RoutingWeight = 3,
                            SharedKey = sharedKey,
                            EnableBgp = true
                        };
                        networkManagementClient.VirtualNetworkGatewayConnections.CreateOrUpdate(resourceGroupName, conn2Name, gw2ToGw1Conn);
                    })
                };

                Task.WaitAll(gatewayConnectionTasks.ToArray());

                // get bgp info from gw1
                IEnumerable<GatewayRoute> learnedRoutes = networkManagementClient.VirtualNetworkGateways.GetLearnedRoutes(resourceGroupName, gw1Name).Value;
                Assert.True(learnedRoutes.Count() > 0, "At least one route should be learned from gw2");
                IEnumerable<GatewayRoute> advertisedRoutes = networkManagementClient.VirtualNetworkGateways.GetAdvertisedRoutes(resourceGroupName, gw1Name, gw2IpResponse.IpAddress).Value;
                Assert.True(learnedRoutes.Count() > 0, "At least one route should be advertised to gw2");
                IEnumerable<BgpPeerStatus> gw1Peers = networkManagementClient.VirtualNetworkGateways.GetBgpPeerStatus(resourceGroupName, gw1Name).Value;
                Assert.True(gw1Peers.Count() > 0, "At least one peer should be connected");
            }
        }

        [Fact(Skip = "Disable tests")]
        public void VirtualNetworkGatewayGenerateVpnProfileTest()
        {
            var handler1 = new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK};
            var handler2 = new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK};

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var resourcesClient =
                    ResourcesManagementTestUtilities.GetResourceManagementClientWithHandler(context, handler1);
                var networkManagementClient =
                    NetworkManagementTestUtilities.GetNetworkManagementClientWithHandler(context, handler2);

                var location =
                    NetworkManagementTestUtilities.GetResourceLocation(resourcesClient,
                        "Microsoft.Network/virtualnetworkgateways");

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = location
                    });


                // 1.CreateVirtualNetworkGateway
                // A.Prerequisite:-Create PublicIPAddress(Gateway Ip) using Put PublicIPAddress API
                string publicIpName = TestUtilities.GenerateName();
                string domainNameLabel = TestUtilities.GenerateName();
                var nic1publicIp = TestHelper.CreateDefaultPublicIpAddress(publicIpName, resourceGroupName,
                    domainNameLabel, location, networkManagementClient);
                Console.WriteLine("PublicIPAddress(Gateway Ip) :{0}", nic1publicIp.Id);


                // B.Prerequisite:-Create Virtual Network using Put VirtualNetwork API
                string vnetName = TestUtilities.GenerateName();
                string subnetName = "GatewaySubnet";

                var virtualNetwork = TestHelper.CreateVirtualNetwork(vnetName, subnetName, resourceGroupName, location,
                    networkManagementClient);
                var getSubnetResponse = networkManagementClient.Subnets.Get(resourceGroupName, vnetName, subnetName);
                Console.WriteLine("Virtual Network GatewaySubnet Id: {0}", getSubnetResponse.Id);

                // C.CreateVirtualNetworkGateway API with P2S client Address Pool defined
                string virtualNetworkGatewayName = TestUtilities.GenerateName();
                string ipConfigName = TestUtilities.GenerateName();
                string addressPrefixes = "192.168.0.0/16";
                string clientRootCertName = this._testEnvironment.ConnectionString.KeyValuePairs[TestEnvironmentSettings.ClientRootCertName.ToString()];
                string samplePublicCertData = this._testEnvironment.ConnectionString.KeyValuePairs[TestEnvironmentSettings.SamplePublicCertData.ToString()];
                VpnClientRootCertificate clientRootCert = new VpnClientRootCertificate()
                {
                    Name = clientRootCertName,
                    PublicCertData = samplePublicCertData
                };

                var virtualNetworkGateway = new VirtualNetworkGateway()
                {
                    Location = location,
                    Tags = new Dictionary<string, string>()
                    {
                        {"key", "value"}
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
                    VpnClientConfiguration = new VpnClientConfiguration()
                    {
                        VpnClientAddressPool = new AddressSpace()
                        {
                            AddressPrefixes = new List<string>()
                            {
                                addressPrefixes
                            },
                        }
                    },
                    Sku = new VirtualNetworkGatewaySku()
                    {
                        Name = VirtualNetworkGatewaySkuName.VpnGw2,
                        Tier = VirtualNetworkGatewaySkuTier.VpnGw2
                    }
                };

                var putVirtualNetworkGatewayResponse =
                    networkManagementClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName,
                        virtualNetworkGatewayName, virtualNetworkGateway);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.ProvisioningState);

                // 2.GetVirtualNetworkGateway API
                var getVirtualNetworkGatewayResponse =
                    networkManagementClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);
                Console.WriteLine(
                    "Gateway details:- GatewayLocation:{0}, GatewayId:{1}, GatewayName:{2}, GatewayType:{3}, VpnType={4} GatewaySku: name-{5} Tier-{6}",
                    getVirtualNetworkGatewayResponse.Location,
                    getVirtualNetworkGatewayResponse.Id, getVirtualNetworkGatewayResponse.Name,
                    getVirtualNetworkGatewayResponse.GatewayType, getVirtualNetworkGatewayResponse.VpnType,
                    getVirtualNetworkGatewayResponse.Sku.Name, getVirtualNetworkGatewayResponse.Sku.Tier);
                Assert.Equal(VirtualNetworkGatewayType.Vpn, getVirtualNetworkGatewayResponse.GatewayType);
                Assert.Equal(VpnType.RouteBased, getVirtualNetworkGatewayResponse.VpnType);
                Assert.Equal(VirtualNetworkGatewaySkuTier.VpnGw2, getVirtualNetworkGatewayResponse.Sku.Tier);
                Assert.NotNull(getVirtualNetworkGatewayResponse.VpnClientConfiguration);
                Assert.NotNull(getVirtualNetworkGatewayResponse.VpnClientConfiguration.VpnClientAddressPool);
                Assert.True(getVirtualNetworkGatewayResponse.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes
                                .Count == 1 &&
                            getVirtualNetworkGatewayResponse.VpnClientConfiguration.VpnClientAddressPool
                                .AddressPrefixes[0].Equals(addressPrefixes),
                    "P2S client Address Pool is not set on Gateway!");

                // Update P2S VPNClient Address Pool and add radius settings
                string newAddressPrefixes = "200.168.0.0/16";
                getVirtualNetworkGatewayResponse.VpnClientConfiguration = new VpnClientConfiguration()
                {
                    VpnClientAddressPool = new AddressSpace()
                    {
                        AddressPrefixes = new List<string>()
                        {
                            newAddressPrefixes
                        }
                    },
                    RadiusServerAddress = @"8.8.8.8",
                    RadiusServerSecret = @"TestRadiusSecret",
                };
                getVirtualNetworkGatewayResponse.VpnClientConfiguration.VpnClientAddressPool.AddressPrefixes = new List<string>() { newAddressPrefixes };
                putVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, getVirtualNetworkGatewayResponse);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.ProvisioningState);

                // 5.Generate P2S Vpnclient package
                var vpnClientParameters = new VpnClientParameters()
                {
                    RadiusServerAuthCertificate = samplePublicCertData,
                    AuthenticationMethod = AuthenticationMethod.EAPTLS
                };

                string packageUrl =
                    networkManagementClient.VirtualNetworkGateways.GenerateGatewayVpnProfile(resourceGroupName,
                        virtualNetworkGatewayName, vpnClientParameters);

                Assert.NotNull(packageUrl);
                Assert.NotEmpty(packageUrl);
                Console.WriteLine("Vpn client package Url from GENERATE operation = {0}", packageUrl);

                // Retry to get the package url using the get profile API
                string packageUrlFromGetOperation = networkManagementClient.VirtualNetworkGateways.GetGatewayVpnProfile(resourceGroupName, virtualNetworkGatewayName);
                Assert.NotNull(packageUrlFromGetOperation);
                Assert.NotEmpty(packageUrlFromGetOperation);
                Console.WriteLine("Vpn client package Url from GET operation = {0}", packageUrlFromGetOperation);
            }
        }

        [Fact(Skip = "Disable tests")]
        public void VirtualNetworkGatewayVpnDeviceConfigurationApisTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
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

                // CreateVirtualNetworkGatewayConnection API
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
                        Name = VirtualNetworkGatewaySkuName.Standard,
                        Tier = VirtualNetworkGatewaySkuTier.Standard
                    }
                };

                var putVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayName, virtualNetworkGateway);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayResponse.ProvisioningState);
                Console.WriteLine("Virtual Network Gateway is deployed successfully.");
                var getVirtualNetworkGatewayResponse = networkManagementClient.VirtualNetworkGateways.Get(resourceGroupName, virtualNetworkGatewayName);

                // C. CreaetVirtualNetworkGatewayConnection API - Ipsec policy and policybased TS enabled
                string virtualNetworkGatewayConnectionName = TestUtilities.GenerateName();
                var virtualNetworkGatewayConnection = new VirtualNetworkGatewayConnection()
                {
                    Location = location,
                    VirtualNetworkGateway1 = getVirtualNetworkGatewayResponse,
                    LocalNetworkGateway2 = getLocalNetworkGatewayResponse,
                    ConnectionType = VirtualNetworkGatewayConnectionType.IPsec,
                    RoutingWeight = 3,
                    SharedKey = "abc"
                };

                virtualNetworkGatewayConnection.IpsecPolicies = new List<IpsecPolicy>()
                {
                    new IpsecPolicy()
                    {
                        IpsecEncryption = IpsecEncryption.AES128,
                        IpsecIntegrity = IpsecIntegrity.SHA256,
                        IkeEncryption = IkeEncryption.AES192,
                        IkeIntegrity = IkeIntegrity.SHA1,
                        DhGroup = DhGroup.DHGroup2,
                        PfsGroup = PfsGroup.PFS1,
                        SaDataSizeKilobytes = 1024,
                        SaLifeTimeSeconds = 300
                    }
                };

                virtualNetworkGatewayConnection.UsePolicyBasedTrafficSelectors = true;

                var putVirtualNetworkGatewayConnectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.CreateOrUpdate(resourceGroupName, virtualNetworkGatewayConnectionName, virtualNetworkGatewayConnection);
                Assert.Equal("Succeeded", putVirtualNetworkGatewayConnectionResponse.ProvisioningState);

                // 2. GetVirtualNetworkGatewayConnection API
                var getVirtualNetworkGatewayConnectionResponse = networkManagementClient.VirtualNetworkGatewayConnections.Get(resourceGroupName, virtualNetworkGatewayConnectionName);
                Console.WriteLine("GatewayConnection details:- GatewayLocation: {0}, GatewayConnectionId:{1}, VirtualNetworkGateway1 name={2} & Id={3}, LocalNetworkGateway2 name={4} & Id={5}, " +
                                  "IpsecPolicies Count={6}, UsePolicyBasedTS={7}",
                    getVirtualNetworkGatewayConnectionResponse.Location, getVirtualNetworkGatewayConnectionResponse.Id,
                    getVirtualNetworkGatewayConnectionResponse.Name,
                    getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGateway1.Name, getVirtualNetworkGatewayConnectionResponse.VirtualNetworkGateway1.Id,
                    getVirtualNetworkGatewayConnectionResponse.LocalNetworkGateway2.Name, getVirtualNetworkGatewayConnectionResponse.LocalNetworkGateway2.Id,
                    getVirtualNetworkGatewayConnectionResponse.IpsecPolicies.Count, getVirtualNetworkGatewayConnectionResponse.UsePolicyBasedTrafficSelectors);

                // List supported Vpn Devices
                var supportedVpnDevices = networkManagementClient.VirtualNetworkGateways.SupportedVpnDevices(resourceGroupName, virtualNetworkGatewayName);
                Assert.NotNull(supportedVpnDevices);
                Assert.NotEmpty(supportedVpnDevices);

                // Parse the supported devices list
                // Then use the first device to get the configuration
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(supportedVpnDevices);
                XmlNode vendorNode = xmldoc.SelectSingleNode("//Vendor");
                XmlNode deviceNode = vendorNode.FirstChild;
                string vendorName = vendorNode.Attributes["name"].Value;
                string deviceName = deviceNode.Attributes["name"].Value;
                string firmwareVersion = deviceNode.FirstChild.Attributes["name"].Value;

                VpnDeviceScriptParameters scriptParams = new VpnDeviceScriptParameters()
                {
                    DeviceFamily = deviceName,
                    FirmwareVersion = firmwareVersion,
                    Vendor = vendorName
                };

                var vpnDeviceConfiguration =
                    networkManagementClient.VirtualNetworkGateways.VpnDeviceConfigurationScript(resourceGroupName, virtualNetworkGatewayConnectionName, scriptParams);

                Assert.NotNull(vpnDeviceConfiguration);
                Assert.NotEmpty(vpnDeviceConfiguration);
            }
        }
    }
}

