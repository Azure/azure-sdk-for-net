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
    using System.Net;
    using Microsoft.WindowsAzure.Management.Network.Models;
    using Xunit;

    public class ResizeGatewayTests
    {
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "ResizeGateway")]
        public void ResizeGatewayWithNonExistantVirtualNetworkName()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                try
                {
                    networkTestClient.Gateways.ResizeGateway("NonExistantVirtualNetworkName", new ResizeGatewayParameters());
                    Assert.True(false, "ResizeGateway should have thrown a CloudException when the virtual network site did not exist.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.Contains("NonExistantVirtualNetworkName", e.Error.Message);
                    Assert.Contains("not valid or could not be found", e.Error.Message);
                }
            }
        }

        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "ResizeGateway")]
        public void ResizeGatewayWithNotProvisionedGateway()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureNoGatewayExists();
                networkTestClient.EnsureSiteToSiteNetworkConfigurationExists();

                ResizeGatewayParameters parameters = new ResizeGatewayParameters()
                {
                    GatewaySKU = GatewaySKU.HighPerformance,
                };

                try
                {
                    networkTestClient.Gateways.ResizeGateway(NetworkTestConstants.VirtualNetworkSiteName, parameters);
                    Assert.True(false, "ResizeGateway should have thrown a CloudException when the virtual network gateway was not provisioned.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.Equal("The current provisioning status of the gateway prevents this operation.", e.Error.Message);
                    Assert.NotNull(e.Response);
                    Assert.Equal("Bad Request", e.Response.ReasonPhrase);
                    Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
                }
            }
        }

        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "ResizeGateway")]
        public void ResizeStaticRoutingGateway()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureStaticRoutingGatewayExists();

                ResizeGatewayParameters parameters = new ResizeGatewayParameters()
                {
                    GatewaySKU = GatewaySKU.HighPerformance,
                };

                try
                {
                    networkTestClient.Gateways.ResizeGateway(NetworkTestConstants.VirtualNetworkSiteName, parameters);
                    Assert.True(false, "ResizeGateway should have thrown a CloudException when it was run against a StaticRouting gateway.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.Equal("The current operation or request is invalid against Static-Routing gateway.", e.Error.Message);
                    Assert.NotNull(e.Response);
                    Assert.Equal("Bad Request", e.Response.ReasonPhrase);
                    Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
                }
            }
        }

        [Fact(Skip = "Test failing due to problems with RDFE. The API is correct, though, so I'll fix this later.")]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "ResizeGateway")]
        public void ResizeGatewayFromDefaultToHighPerformance()
        {
            ResizeGateway(GatewaySKU.Default, GatewaySKU.HighPerformance);
        }
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "ResizeGateway")]
        public void ResizeGatewayFromHighPerformanceToDefault()
        {
            ResizeGateway(GatewaySKU.HighPerformance, GatewaySKU.Default);
        }
        private void ResizeGateway(string startSKU, string targetSKU)
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureDynamicRoutingGatewayExists(startSKU);

                ResizeGatewayParameters parameters = new ResizeGatewayParameters()
                {
                    GatewaySKU = targetSKU,
                };

                GatewayGetOperationStatusResponse resizeResponse = networkTestClient.Gateways.ResizeGateway(NetworkTestConstants.VirtualNetworkSiteName, parameters);
                Assert.NotNull(resizeResponse);
                Assert.Equal(HttpStatusCode.OK, resizeResponse.HttpStatusCode);

                GatewayGetResponse response = networkTestClient.Gateways.GetGateway(NetworkTestConstants.VirtualNetworkSiteName);
                Assert.NotNull(response);
                Assert.Equal(GatewayProvisioningEventStates.Provisioned, response.State);
                Assert.Equal(targetSKU, response.GatewaySKU);
            }
        }
    }
}
