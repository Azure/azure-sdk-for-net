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
//

namespace Network.Tests.Gateways
{
    using System;
    using System.Net;
    using Microsoft.WindowsAzure.Management.Network.Models;
    using Xunit;

    public class CreateGatewayTests
    {
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "CreateGateway")]
        public void CreateWhenGatewayTypeIsUnassigned()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.EnsureSiteToSiteNetworkConfigurationExists();

                GatewayGetOperationStatusResponse response =
                    networkTestClient.Gateways.CreateGateway(
                        NetworkTestConstants.VirtualNetworkSiteName,
                        new GatewayCreateParameters());
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.HttpStatusCode);

                GatewayGetResponse getGatewayResponse = networkTestClient.Gateways.GetGateway("virtualNetworkSiteName");
                Assert.NotNull(getGatewayResponse);
                Assert.Equal(GatewayType.StaticRouting, getGatewayResponse.GatewayType);
                Assert.Equal("Provisioned", getGatewayResponse.State);
                Assert.NotNull(getGatewayResponse.VipAddress);
                Assert.NotEmpty(getGatewayResponse.VipAddress);
            }
        }

        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "CreateGateway")]
        public void CreateStaticRoutingGateway()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.EnsureSiteToSiteNetworkConfigurationExists();

                GatewayGetOperationStatusResponse response =
                    networkTestClient.Gateways.CreateGateway(
                        NetworkTestConstants.VirtualNetworkSiteName,
                        NetworkTestConstants.CreateStaticRoutingGatewayParameters());
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.HttpStatusCode);

                GatewayGetResponse getGatewayResponse = networkTestClient.Gateways.GetGateway("virtualNetworkSiteName");
                Assert.NotNull(getGatewayResponse);
                Assert.Equal(GatewayType.StaticRouting, getGatewayResponse.GatewayType);
                Assert.Equal("Provisioned", getGatewayResponse.State);
                Assert.NotNull(getGatewayResponse.VipAddress);
                Assert.NotEmpty(getGatewayResponse.VipAddress);
            }
        }

        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "CreateGateway")]
        public void CreateDynamicGateway()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.EnsurePointToSiteNetworkConfigurationExists();

                networkTestClient.Gateways.CreateGateway(
                    NetworkTestConstants.VirtualNetworkSiteName,
                    NetworkTestConstants.CreateDynamicRoutingGatewayParameters());
                
                GatewayGetResponse response = networkTestClient.Gateways.GetGateway("virtualNetworkSiteName");
                Assert.NotNull(response);
                Assert.Equal(GatewayType.DynamicRouting, response.GatewayType);
            }
        }
    }
}
