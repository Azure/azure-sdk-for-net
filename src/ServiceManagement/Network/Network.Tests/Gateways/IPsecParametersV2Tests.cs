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

    public class IPsecParametersV2Tests
    {
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "IPsecParametersV2")]
        public void IPsecParametersV2APIsTests()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                // 1.SetIPsecParametersV2 API:-
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

                //d. SetIPsecParametersV2 API
                GatewaySetIPsecParametersParameters setParameters = CreateIPSecParameters();
                response = networkTestClient.Gateways.SetIPsecParametersV2(vnetGatewayId.ToString(), localNetworkGatewayId, setParameters);
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.HttpStatusCode);
                Assert.NotNull(response.Id);

                // 2.GetIPsecParametersV2 API
                GatewayGetIPsecParametersResponse paramResponse = networkTestClient.Gateways.GetIPsecParametersV2(vnetGatewayId.ToString(), localNetworkGatewayId);
                Assert.NotNull(paramResponse);
                Assert.Equal(HttpStatusCode.OK, paramResponse.StatusCode);
                Assert.NotNull(paramResponse.IPsecParameters);
                Assert.Equal(EncryptionType.NoEncryption, paramResponse.IPsecParameters.EncryptionType);
                Assert.Equal(PfsGroup.PFS1, paramResponse.IPsecParameters.PfsGroup);
                Assert.Equal(102400000, paramResponse.IPsecParameters.SADataSizeKilobytes); //Check for default value
                Assert.Equal(3600, paramResponse.IPsecParameters.SALifeTimeSeconds);  //Check for default value
                Assert.Equal("SHA1", paramResponse.IPsecParameters.HashAlgorithm);  //Check for default value

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

        private static GatewaySetIPsecParametersParameters CreateIPSecParameters()
        {
            return new GatewaySetIPsecParametersParameters()
            {
                Parameters = new IPsecParameters()
                {
                    EncryptionType = EncryptionType.NoEncryption,
                    PfsGroup = PfsGroup.PFS1,
                    SADataSizeKilobytes = 0,
                    SALifeTimeSeconds = 0,
                    HashAlgorithm = string.Empty
                }
            };
        }
    }
}
