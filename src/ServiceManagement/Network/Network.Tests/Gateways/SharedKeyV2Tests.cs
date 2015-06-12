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
    using System.Net;
    using Microsoft.WindowsAzure.Management.Network.Models;
    using Xunit;
    using System.Collections.Generic;
    using System;
    using System.Linq;
    using Hyak.Common;
    using Microsoft.Azure;

    public class SharedKeyV2Tests
    {
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "SharedKeyV2")]
        public void SharedKeyV2APIsTests()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                // 1.ResetSharedKeyV2 API:-
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
                string addressSpace = "200.168.0.0/16";

                var param = new LocalNetworkGatewayCreateParameters()
                {
                    AddressSpace = new LazyList<string>() { addressSpace },
                    GatewayName = localnetGatewayName,
                    IpAddress = "204.95.99.237",
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

                // d.ResetSharedKeyV2 API
                GatewayResetSharedKeyParameters resetParameters = new GatewayResetSharedKeyParameters()
                {
                    KeyLength = 128,
                };
                GatewayGetOperationStatusResponse resetResponse = networkTestClient.Gateways.ResetSharedKeyV2(vnetGatewayId.ToString(), localNetworkGatewayId, resetParameters);
                Assert.NotNull(resetResponse);
                Assert.Equal(HttpStatusCode.OK, resetResponse.HttpStatusCode);

                // 2.GetSharedKeyV2 API
                const string sharedKeyToSet = "MNO";
                GatewayGetSharedKeyResponse firstGetResponse = networkTestClient.Gateways.GetSharedKeyV2(vnetGatewayId.ToString(), localNetworkGatewayId);
                Assert.NotNull(firstGetResponse);
                Assert.Equal(HttpStatusCode.OK, firstGetResponse.StatusCode);
                Assert.NotEqual(sharedKeyToSet, firstGetResponse.SharedKey);

                // 3. SetSharedKeyV2 API
                GatewaySetSharedKeyParameters setParameters = new GatewaySetSharedKeyParameters()
                {
                    Value = sharedKeyToSet
                };

                GatewayGetOperationStatusResponse setResponse = networkTestClient.Gateways.SetSharedKeyV2(vnetGatewayId.ToString(), localNetworkGatewayId, setParameters);
                Assert.NotNull(setResponse);
                Assert.Equal(HttpStatusCode.OK, setResponse.HttpStatusCode);

                // GetSharedKeyV2 API after SetSharedKeyV2 API
                GatewayGetSharedKeyResponse secondGetResponse = networkTestClient.Gateways.GetSharedKeyV2(vnetGatewayId.ToString(), localNetworkGatewayId);
                Assert.NotNull(secondGetResponse);
                Assert.Equal(HttpStatusCode.OK, secondGetResponse.StatusCode);
                Assert.Equal(sharedKeyToSet, secondGetResponse.SharedKey);

                // Cleanup test setup at end
                gatewayGetOperationStatusResponse = networkTestClient.Gateways.DeleteGatewayConnection(vnetGatewayId.ToString(), localNetworkGatewayId);
                Assert.NotNull(gatewayGetOperationStatusResponse);
                Assert.Equal(HttpStatusCode.OK, gatewayGetOperationStatusResponse.HttpStatusCode);

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
