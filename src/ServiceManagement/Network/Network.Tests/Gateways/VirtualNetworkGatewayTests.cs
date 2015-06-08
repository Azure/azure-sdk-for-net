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
    using Microsoft.WindowsAzure.Management.Network.Models;
    using System;
    using System.Linq;
    using System.Net;
    using Xunit;

    public class VirtualNetworkGatewayTests
    {
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "VirtualNetworkGateway")]
        public void VirtualNetworkGatewayAPIsTests()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                string virtualNetworkSiteName = "coexistenceVirtualNetworkSiteName";
                string vnetGatewayName = "coexistenceVnetGateway";

                networkTestClient.EnsureNoNetworkConfigurationExists(virtualNetworkSiteName);

                // 1.CreateVirtualnetworkGateway API
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

                // 2.Listvirtualnetworkgateways API
                ListVirtualNetworkGatewaysResponse listVirtualNetworkGatewaysResponse = networkTestClient.Gateways.ListVirtualNetworkGateways();
                Assert.True(listVirtualNetworkGatewaysResponse.VirtualNetworkGateways.Count >= 1);
                string vnetGatewayId = listVirtualNetworkGatewaysResponse.VirtualNetworkGateways.First(vnetGateway => vnetGateway.GatewayName.Equals(vnetGatewayName)).GatewayId.ToString();

                // 3.Getvirtualnetworkgateway API
                VirtualNetworkGatewayGetResponse virtualNetworkGatewayGetResponse = networkTestClient.Gateways.GetVirtualNetworkGateway(vnetGatewayId);
                Assert.NotNull(virtualNetworkGatewayGetResponse);
                Assert.Equal(HttpStatusCode.OK, virtualNetworkGatewayGetResponse.StatusCode);
                Assert.Equal(vnetGatewayName, virtualNetworkGatewayGetResponse.GatewayName);
                Assert.Equal(GatewaySKU.Default, virtualNetworkGatewayGetResponse.GatewaySKU);
                Assert.Equal(GatewayType.DynamicRouting, virtualNetworkGatewayGetResponse.GatewayType);

                // 4.ResizeVirtualnetworkGateway API
                ResizeGatewayParameters parameters = new ResizeGatewayParameters()
                {
                    GatewaySKU = GatewaySKU.HighPerformance
                };
                response = networkTestClient.Gateways.ResizeVirtualNetworkGateway(vnetGatewayId, parameters);
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.HttpStatusCode);

                virtualNetworkGatewayGetResponse = networkTestClient.Gateways.GetVirtualNetworkGateway(vnetGatewayId);
                Assert.NotNull(virtualNetworkGatewayGetResponse);
                Assert.Equal(HttpStatusCode.OK, virtualNetworkGatewayGetResponse.StatusCode);
                Assert.Equal(vnetGatewayName, virtualNetworkGatewayGetResponse.GatewayName);
                Assert.Equal(GatewaySKU.HighPerformance, virtualNetworkGatewayGetResponse.GatewaySKU);

                // 5.ResetVirtualnetworkGateway API
                ResetGatewayParameters resetGatewayParameters = new ResetGatewayParameters();
                response = networkTestClient.Gateways.ResetVirtualNetworkGateway(vnetGatewayId, resetGatewayParameters);
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.HttpStatusCode);

                // 6.DeleteVirtualNetworkGateway API
                response = networkTestClient.Gateways.DeleteVirtualNetworkGateway(vnetGatewayId);
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.HttpStatusCode);

                listVirtualNetworkGatewaysResponse = networkTestClient.Gateways.ListVirtualNetworkGateways();
                Assert.False(listVirtualNetworkGatewaysResponse.VirtualNetworkGateways.Any(vnetGateway => vnetGateway.GatewayName.Equals(vnetGatewayName)),
                    "Virtual network: " + virtualNetworkSiteName + " gateway: " + vnetGatewayName + " is not deleted even after DeleteVirtualNetworkGateway API call!");
            }
        }

        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "VirtualNetworkGateway")]
        public void VirtualNetworkGatewayStandardSkuValidationTest()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                string virtualNetworkSiteName = "coexistenceVirtualNetworkSiteName";
                string vnetGatewayName = "coexistenceVnetGateway";

                networkTestClient.EnsureNoNetworkConfigurationExists(virtualNetworkSiteName);

                // 1.CreateVirtualnetworkGateway API with Standard Gateway SKU
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
                            GatewaySKU = GatewaySKU.Standard,
                            GatewayType = GatewayType.DynamicRouting
                        });
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.HttpStatusCode);

                // 2.Listvirtualnetworkgateways API
                ListVirtualNetworkGatewaysResponse listVirtualNetworkGatewaysResponse = networkTestClient.Gateways.ListVirtualNetworkGateways();
                Assert.True(listVirtualNetworkGatewaysResponse.VirtualNetworkGateways.Count >= 1);
                string vnetGatewayId = listVirtualNetworkGatewaysResponse.VirtualNetworkGateways.First(vnetGateway => vnetGateway.GatewayName.Equals(vnetGatewayName)).GatewayId.ToString();

                // 3.Getvirtualnetworkgateway API
                VirtualNetworkGatewayGetResponse virtualNetworkGatewayGetResponse = networkTestClient.Gateways.GetVirtualNetworkGateway(vnetGatewayId);
                Assert.NotNull(virtualNetworkGatewayGetResponse);
                Assert.Equal(HttpStatusCode.OK, virtualNetworkGatewayGetResponse.StatusCode);
                Assert.Equal(vnetGatewayName, virtualNetworkGatewayGetResponse.GatewayName);
                Assert.Equal(GatewaySKU.Standard, virtualNetworkGatewayGetResponse.GatewaySKU);
                Assert.Equal(GatewayType.DynamicRouting, virtualNetworkGatewayGetResponse.GatewayType);

                // 4.ResizeVirtualnetworkGateway API to HighPerformace Gateway SKU
                ResizeGatewayParameters parameters = new ResizeGatewayParameters()
                {
                    GatewaySKU = GatewaySKU.HighPerformance
                };
                response = networkTestClient.Gateways.ResizeVirtualNetworkGateway(vnetGatewayId, parameters);
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.HttpStatusCode);

                virtualNetworkGatewayGetResponse = networkTestClient.Gateways.GetVirtualNetworkGateway(vnetGatewayId);
                Assert.NotNull(virtualNetworkGatewayGetResponse);
                Assert.Equal(HttpStatusCode.OK, virtualNetworkGatewayGetResponse.StatusCode);
                Assert.Equal(vnetGatewayName, virtualNetworkGatewayGetResponse.GatewayName);
                Assert.Equal(GatewaySKU.HighPerformance, virtualNetworkGatewayGetResponse.GatewaySKU);

                // 5.ResizeVirtualnetworkGateway API to Standard Gateway SKU again
                parameters = new ResizeGatewayParameters()
                {
                    GatewaySKU = GatewaySKU.Standard
                };
                response = networkTestClient.Gateways.ResizeVirtualNetworkGateway(vnetGatewayId, parameters);
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.HttpStatusCode);

                virtualNetworkGatewayGetResponse = networkTestClient.Gateways.GetVirtualNetworkGateway(vnetGatewayId);
                Assert.NotNull(virtualNetworkGatewayGetResponse);
                Assert.Equal(HttpStatusCode.OK, virtualNetworkGatewayGetResponse.StatusCode);
                Assert.Equal(vnetGatewayName, virtualNetworkGatewayGetResponse.GatewayName);
                Assert.Equal(GatewaySKU.Standard, virtualNetworkGatewayGetResponse.GatewaySKU);

                // 6.DeleteVirtualNetworkGateway API
                response = networkTestClient.Gateways.DeleteVirtualNetworkGateway(vnetGatewayId);
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.HttpStatusCode);

                listVirtualNetworkGatewaysResponse = networkTestClient.Gateways.ListVirtualNetworkGateways();
                Assert.False(listVirtualNetworkGatewaysResponse.VirtualNetworkGateways.Any(vnetGateway => vnetGateway.GatewayName.Equals(vnetGatewayName)),
                    "Virtual network: " + virtualNetworkSiteName + " gateway: " + vnetGatewayName + " is not deleted even after DeleteVirtualNetworkGateway API call!");
            }
        }
    }
}
