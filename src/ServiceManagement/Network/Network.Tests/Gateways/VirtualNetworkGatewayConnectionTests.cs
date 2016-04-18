// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Network.Tests.Gateways
{
    using System;
    using System.Net;
    using Microsoft.WindowsAzure.Management.Network.Models;
    using Xunit;
    using System.Collections.Generic;
    using System.Linq;
    using Hyak.Common;
    using Microsoft.Azure;

    public class VirtualNetworkGatewayConnectionTests
    {
        private string addressSpace = "200.168.0.0/16";
        private string localNetworkGatewayIpAddress = "204.95.99.237";

        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "VirtualNetworkGatewayConnection")]
        public void VirtualNetworkGatewayConnectionWithBgpTest()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                string virtualNetworkSiteName = "gatewayVirtualNetworkSiteName";
                string vnetGatewayName = "bgpTestVirtualNetworkGateway";

                networkTestClient.SetNetworkConfiguration(NetworkTestConstants.GatewayNetworkConfigurationParameters);

                // Put a virtual network gateway with a feature set that allows BGP (dynamic routing, >= standard)
                GatewayGetOperationStatusResponse response = networkTestClient.Gateways.CreateVirtualNetworkGateway(
                    virtualNetworkSiteName,
                    new VirtualNetworkGatewayCreateParameters()
                    {
                        GatewayName = vnetGatewayName,
                        GatewayType = GatewayType.DynamicRouting,
                        GatewaySKU = GatewaySKU.Standard
                    });
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.HttpStatusCode);

                // Call list, make sure the virtual network gateway exists, then check for BgpSettings
                ListVirtualNetworkGatewaysResponse listVirtualNetworkGatewaysResponse = networkTestClient.Gateways.ListVirtualNetworkGateways();
                Assert.True(listVirtualNetworkGatewaysResponse.VirtualNetworkGateways.Count >= 1);
                ListVirtualNetworkGatewaysResponse.VirtualNetworkGateway vnetGateway = 
                    listVirtualNetworkGatewaysResponse.VirtualNetworkGateways.First(gw => gw.GatewayName.Equals(vnetGatewayName));
                Assert.NotNull(vnetGateway.BgpSettings);
                string virtualNetworkGatewayId = vnetGateway.GatewayId.ToString();

                // Create a local network gateway with BGP settings
                string localNetworkGatewayName = "bgpTestLocalNetworkGateway";
                var param = new LocalNetworkGatewayCreateParameters()
                {
                    AddressSpace = new LazyList<string>() { addressSpace },
                    GatewayName = localNetworkGatewayName,
                    IpAddress = localNetworkGatewayIpAddress,
                    BgpSettings = new BgpSettings()
                    {
                        Asn = 1234,
                        BgpPeeringAddress = "200.168.1.1",
                        PeerWeight = 5
                    }
                };

                LocalNetworkGatewayCreateResponse localNetworkGatewayCreateResponse = networkTestClient.Gateways.CreateLocalNetworkGateway(param);
                Assert.NotNull(localNetworkGatewayCreateResponse);
                Assert.Equal(HttpStatusCode.OK, localNetworkGatewayCreateResponse.StatusCode);

                ListLocalNetworkGatewaysResponse listLocalNetworkGatewaysResponse = networkTestClient.Gateways.ListLocalNetworkGateways();
                Assert.NotNull(listLocalNetworkGatewaysResponse);
                Assert.Equal(HttpStatusCode.OK, listLocalNetworkGatewaysResponse.StatusCode);
                ListLocalNetworkGatewaysResponse.LocalNetworkGateway localNetworkGateway = 
                    listLocalNetworkGatewaysResponse.LocalNetworkGateways.First(gw => gw.GatewayName.Equals(localNetworkGatewayName));
                string localNetworkGatewayId = localNetworkGateway.Id.ToString();

                // Create a connection from the virtual network gateway to the local network gateway
                // with BGP enabled
                string gatewayConnectionName = "bgpTestConnection";

                GatewayGetOperationStatusResponse gatewayGetOperationStatusResponse =
                   networkTestClient.Gateways.CreateGatewayConnection(
                    new GatewayConnectionCreateParameters()
                    {
                        ConnectedEntityId = localNetworkGatewayId,
                        GatewayConnectionName = gatewayConnectionName,
                        GatewayConnectionType = GatewayConnectionType.IPsec,
                        VirtualNetworkGatewayId = vnetGateway.GatewayId,
                        RoutingWeight = 3,
                        SharedKey = "abc",
                        EnableBgp = true
                    }
                    );
                Assert.NotNull(gatewayGetOperationStatusResponse);
                Assert.Equal(HttpStatusCode.OK, gatewayGetOperationStatusResponse.HttpStatusCode);

                GatewayConnectionGetResponse gatewayConnectionGetResponse = networkTestClient.Gateways.GetGatewayConnection(virtualNetworkGatewayId, localNetworkGatewayId);
                Assert.True(gatewayConnectionGetResponse.EnableBgp, "Connection should have BGP enabled");

                gatewayGetOperationStatusResponse = networkTestClient.Gateways.DeleteGatewayConnection(virtualNetworkGatewayId, localNetworkGatewayId);
                Assert.NotNull(gatewayGetOperationStatusResponse);
                Assert.Equal(HttpStatusCode.OK, gatewayGetOperationStatusResponse.HttpStatusCode);

                response = networkTestClient.Gateways.DeleteVirtualNetworkGateway(virtualNetworkGatewayId);
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.HttpStatusCode);

                AzureOperationResponse deleteLocalNetworkGatewayResponse = networkTestClient.Gateways.DeleteLocalNetworkGateway(localNetworkGatewayId);
                Assert.NotNull(deleteLocalNetworkGatewayResponse);
                Assert.Equal(HttpStatusCode.OK, deleteLocalNetworkGatewayResponse.StatusCode);
            }
        }

        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "VirtualNetworkGatewayConnection")]
        public void VirtualNetworkGatewayConnectionAPIsTests()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                // 1.CreateGatewayConnection API :-

                // a.CreateVirtualnetworkGateway API
                string virtualNetworkSiteName = "coexistenceVirtualNetworkSiteName";
                string vnetGatewayName = "coexistenceVnetGateway";

                networkTestClient.EnsureNoNetworkConfigurationExists(virtualNetworkSiteName);

                networkTestClient.SetNetworkConfiguration(NetworkTestConstants.CoexistenceFeatureNetworkConfigurationParameters);
                NetworkListResponse listResponse = networkTestClient.ListNetworkConfigurations();
                Assert.NotNull(listResponse);
                Assert.True(listResponse.VirtualNetworkSites.Any(vnet => vnet.Name.Equals(virtualNetworkSiteName)),
                    "Virtual network:" + virtualNetworkSiteName + " is not found!");
                string vnetId = listResponse.First(vnet => vnet.Name.Equals(virtualNetworkSiteName)).Id;

                GatewayGetOperationStatusResponse response =
                    networkTestClient.Gateways.CreateVirtualNetworkGateway(
                        virtualNetworkSiteName,
                        new VirtualNetworkGatewayCreateParameters()
                        {
                            GatewayName = vnetGatewayName,
                            GatewayType = GatewayType.DynamicRouting
                        });
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.HttpStatusCode);

                ListVirtualNetworkGatewaysResponse listVirtualNetworkGatewaysResponse = networkTestClient.Gateways.ListVirtualNetworkGateways();
                Assert.True(listVirtualNetworkGatewaysResponse.VirtualNetworkGateways.Count >= 1);
                Guid vnetGatewayId = listVirtualNetworkGatewaysResponse.VirtualNetworkGateways.First(vnetGateway => vnetGateway.GatewayName.Equals(vnetGatewayName)).GatewayId;

                // b.CreateLocalNetworkGateway API
                string localnetGatewayName = "coexistenceLocalnetGateway";

                var param = new LocalNetworkGatewayCreateParameters()
                {
                    AddressSpace = new LazyList<string>() { addressSpace },
                    GatewayName = localnetGatewayName,
                    IpAddress = localNetworkGatewayIpAddress,
                };

                LocalNetworkGatewayCreateResponse localNetworkGatewayCreateResponse = networkTestClient.Gateways.CreateLocalNetworkGateway(param);
                Assert.NotNull(localNetworkGatewayCreateResponse);
                Assert.Equal(HttpStatusCode.OK, localNetworkGatewayCreateResponse.StatusCode);
                Assert.NotNull(localNetworkGatewayCreateResponse.LocalNetworkGatewayId);

                ListLocalNetworkGatewaysResponse listLocalNetworkGatewaysResponse = networkTestClient.Gateways.ListLocalNetworkGateways();
                Assert.NotNull(listLocalNetworkGatewaysResponse);
                Assert.Equal(HttpStatusCode.OK, listLocalNetworkGatewaysResponse.StatusCode);
                Assert.Equal(1, listLocalNetworkGatewaysResponse.LocalNetworkGateways.Count);
                string localNetworkGatewayId = listLocalNetworkGatewaysResponse.LocalNetworkGateways.First(localnetGateway =>
                        localnetGateway.GatewayName.Equals(localnetGatewayName)).Id.ToString();

                // c.CreateGatewayConnection API
                string gatewayConnectionName = "coexistenceGatewayConnection";

                GatewayGetOperationStatusResponse gatewayGetOperationStatusResponse =
                   networkTestClient.Gateways.CreateGatewayConnection(
                    new GatewayConnectionCreateParameters()
                    {
                        ConnectedEntityId = localNetworkGatewayId,
                        GatewayConnectionName = gatewayConnectionName,
                        GatewayConnectionType = GatewayConnectionType.IPsec,
                        VirtualNetworkGatewayId = vnetGatewayId,
                        RoutingWeight = 3,
                        SharedKey = "abc"
                    }
                    );
                Assert.NotNull(gatewayGetOperationStatusResponse);
                Assert.Equal(HttpStatusCode.OK, gatewayGetOperationStatusResponse.HttpStatusCode);

                // 2.GetGatewayConnection API
                GatewayConnectionGetResponse gatewayConnectionGetResponse = networkTestClient.Gateways.GetGatewayConnection(vnetGatewayId.ToString(), localNetworkGatewayId);
                Assert.NotNull(gatewayConnectionGetResponse);
                Assert.Equal(HttpStatusCode.OK, gatewayConnectionGetResponse.StatusCode);
                Assert.Equal(vnetGatewayId, gatewayConnectionGetResponse.VirtualNetworkGatewayId);
                Assert.Equal(localNetworkGatewayId, gatewayConnectionGetResponse.ConnectedEntityId);
                Assert.Equal(gatewayConnectionName, gatewayConnectionGetResponse.GatewayConnectionName);
                Assert.Equal(GatewayConnectionType.IPsec, gatewayConnectionGetResponse.GatewayConnectionType);
                Assert.Equal(3, gatewayConnectionGetResponse.RoutingWeight);
                Assert.Equal("abc", gatewayConnectionGetResponse.SharedKey);

                // 3.UpdateGatewayConnection API
                gatewayGetOperationStatusResponse = networkTestClient.Gateways.UpdateGatewayConnection(
                     vnetGatewayId.ToString(), localNetworkGatewayId,
                     new UpdateGatewayConnectionParameters()
                     {
                         RoutingWeight = 4,
                         SharedKey = "xyz"
                     });
                Assert.NotNull(gatewayGetOperationStatusResponse);
                Assert.Equal(HttpStatusCode.OK, gatewayGetOperationStatusResponse.HttpStatusCode);

                // GetGatewayConnection API after UpdateGatewayConnection API
                gatewayConnectionGetResponse = networkTestClient.Gateways.GetGatewayConnection(vnetGatewayId.ToString(), localNetworkGatewayId);
                Assert.NotNull(gatewayConnectionGetResponse);
                Assert.Equal(HttpStatusCode.OK, gatewayConnectionGetResponse.StatusCode);
                Assert.Equal(4, gatewayConnectionGetResponse.RoutingWeight);
                Assert.Equal("xyz", gatewayConnectionGetResponse.SharedKey);

                // 4.ListGatewayConnections API
                GatewayListGatewayConnectionsResponse gatewayListGatewayConnectionsResponse = networkTestClient.Gateways.ListGatewayConnections();
                Assert.NotNull(gatewayListGatewayConnectionsResponse);
                Assert.Equal(HttpStatusCode.OK, gatewayListGatewayConnectionsResponse.StatusCode);
                Assert.Equal(1, gatewayListGatewayConnectionsResponse.VirtualNetworkGatewayConnections.Count);
                Assert.True(gatewayListGatewayConnectionsResponse.VirtualNetworkGatewayConnections.Any(vnetGatewayConnection =>
                    vnetGatewayConnection.GatewayConnectionName.Equals(gatewayConnectionName)), "Gateway connection " + gatewayConnectionName + " not found!");

                // 5.DeleteGatewayConnection API
                gatewayGetOperationStatusResponse = networkTestClient.Gateways.DeleteGatewayConnection(vnetGatewayId.ToString(), localNetworkGatewayId);
                Assert.NotNull(gatewayGetOperationStatusResponse);
                Assert.Equal(HttpStatusCode.OK, gatewayGetOperationStatusResponse.HttpStatusCode);

                gatewayListGatewayConnectionsResponse = networkTestClient.Gateways.ListGatewayConnections();
                Assert.False(gatewayListGatewayConnectionsResponse.VirtualNetworkGatewayConnections.Any(vnetGatewayConnection => vnetGatewayConnection.GatewayConnectionName.Equals(gatewayConnectionName)),
                    "Virtual network gateway connection: " + gatewayConnectionName + " is not deleted even after DeleteGatewayConnection API call!");

                // Cleanup test setup at end
                response = networkTestClient.Gateways.DeleteVirtualNetworkGateway(vnetGatewayId.ToString());
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.HttpStatusCode);

                AzureOperationResponse deleteLocalNetworkGatewayResponse = networkTestClient.Gateways.DeleteLocalNetworkGateway(localNetworkGatewayId);
                Assert.NotNull(deleteLocalNetworkGatewayResponse);
                Assert.Equal(HttpStatusCode.OK, deleteLocalNetworkGatewayResponse.StatusCode);
            }
        }
    }
}
