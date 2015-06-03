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

    public class ResetGatewayTests
    {
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "ResetGateway")]
        public void ResetGatewayWithNonExistantVirtualNetworkName()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.EnsureNoNetworkConfigurationExists();

                try
                {
                    networkTestClient.Gateways.ResetGateway("NonExistantVirtualNetworkName", new ResetGatewayParameters());
                    Assert.True(false, "ResetGateway should have thrown a CloudException when the virtual network site did not exist.");
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
        [Trait("Operation", "ResetGateway")]
        public void ResetGatewayWhenGatewayIsNotProvisioned()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureNoGatewayExists();
                networkTestClient.EnsureSiteToSiteNetworkConfigurationExists();

                try
                {
                    networkTestClient.Gateways.ResetGateway(NetworkTestConstants.VirtualNetworkSiteName, new ResetGatewayParameters());
                    Assert.True(false, "ResetGateway should have thrown a CloudException when the virtual network gateway was not provisioned.");
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
        [Trait("Operation", "ResetGateway")]
        public void ResetStaticRoutingGateway()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureStaticRoutingGatewayExists();

                networkTestClient.Gateways.ResetGateway(NetworkTestConstants.VirtualNetworkSiteName, new ResetGatewayParameters());

                GatewayGetResponse response = networkTestClient.Gateways.GetGateway(NetworkTestConstants.VirtualNetworkSiteName);
                Assert.NotNull(response);
                Assert.Equal(GatewayProvisioningEventStates.Provisioned, response.State);
            }
        }
    }
}
