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
    using Microsoft.WindowsAzure.Management.Network.Models;
    using Xunit;

    public class GetGatewayTests
    {
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "GetGateway")]
        public void GetGatewayWhenNetworkConfigurationDoesNotExist()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.SetNetworkConfiguration(NetworkTestConstants.EmptyNetworkConfigurationParameters);

                try
                {
                    networkTestClient.Gateways.GetGateway(NetworkTestConstants.VirtualNetworkSiteName);
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                }
            }
        }

        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "GetGateway")]
        public void GetGatewayWhenGatewayIsNotProvisioned()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.EnsureSiteToSiteNetworkConfigurationExists();
                networkTestClient.Gateways.EnsureNoGatewayExists();

                GatewayGetResponse response = networkTestClient.Gateways.GetGateway(NetworkTestConstants.VirtualNetworkSiteName);
                Assert.NotNull(response);
                Assert.Equal("NotProvisioned", response.State);
                Assert.Null(response.VipAddress);
            }
        }

        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "GetGateway")]
        public void GetGatewayWhenStaticRoutingGatewayExists()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureStaticRoutingGatewayExists();

                GatewayGetResponse response = networkTestClient.Gateways.GetGateway(NetworkTestConstants.VirtualNetworkSiteName);
                Assert.NotNull(response);
                Assert.Equal(GatewayType.StaticRouting, response.GatewayType);
                Assert.Equal("Provisioned", response.State);
                Assert.NotNull(response.VipAddress);
                Assert.NotEqual(0, response.VipAddress.Length);
                Assert.Equal(GatewaySKU.Default, response.GatewaySKU);
            }
        }

        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "GetGateway")]
        public void GetGatewayWhenDynamicRoutingGatewayExists()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureDynamicRoutingGatewayExists();

                GatewayGetResponse response = networkTestClient.Gateways.GetGateway(NetworkTestConstants.VirtualNetworkSiteName);
                Assert.NotNull(response);
                Assert.Equal(GatewayType.DynamicRouting, response.GatewayType);
                Assert.Equal("Provisioned", response.State);
                Assert.NotNull(response.VipAddress);
                Assert.NotEqual(0, response.VipAddress.Length);
            }
        }
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "GetGateway")]
        public void GetGatewayWhenDynamicRoutingGatewayHasDefaultSites()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureDynamicRoutingGatewayExists();
                networkTestClient.Gateways.SetDefaultSites(NetworkTestConstants.VirtualNetworkSiteName,
                    new GatewaySetDefaultSiteListParameters() { DefaultSite = NetworkTestConstants.LocalNetworkSiteName });

                GatewayGetResponse response = networkTestClient.Gateways.GetGateway(NetworkTestConstants.VirtualNetworkSiteName);
                Assert.NotNull(response);
                Assert.Equal(GatewayType.DynamicRouting, response.GatewayType);
                Assert.Equal("Provisioned", response.State);
                Assert.NotNull(response.VipAddress);
                Assert.NotEqual(0, response.VipAddress.Length);
                Assert.Equal(NetworkTestConstants.LocalNetworkSiteName, response.DefaultSite.Name);
            }
        }
    }
}
