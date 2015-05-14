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
    using Xunit;

    public class GetIPsecParametersTests
    {
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "GetIPsecParameters")]
        public void GetIPsecParametersWithNonExistingVirtualNetworkName()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.EnsureNoNetworkConfigurationExists();

                try
                {
                    networkTestClient.Gateways.GetIPsecParameters("NonExistingVnetName", NetworkTestConstants.LocalNetworkSiteName);
                    Assert.True(false, "GetIPsecParameters should have thrown a CloudException when a virtual network site didn't exist for the provided name.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.Equal("The specified virtual network name \'NonExistingVnetName\' is not valid or could not be found.", e.Error.Message);
                    Assert.NotNull(e.Response);
                    Assert.Equal("Bad Request", e.Response.ReasonPhrase);
                    Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
                }
            }
        }

        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "GetIPsecParameters")]
        public void GetIPsecParametersWithNotProvisionedGateway()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureNoGatewayExists();
                networkTestClient.EnsureSiteToSiteNetworkConfigurationExists();

                try
                {
                    networkTestClient.Gateways.GetIPsecParameters(NetworkTestConstants.VirtualNetworkSiteName, NetworkTestConstants.LocalNetworkSiteName);
                    Assert.True(false, "GetIPsecParameters should have thrown a CloudException when the gateway wasn't provisioned.");
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

        [Fact(Skip = "Test failing. Dan needs to re-record these.")]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "GetIPsecParameters")]
        public void GetIPsecParametersWithStaticRoutingGatewayAndNonExistingLocalNetworkName()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureStaticRoutingGatewayExists();

                try
                {
                    networkTestClient.Gateways.GetIPsecParameters(NetworkTestConstants.VirtualNetworkSiteName, "NonExistingLocalNetworkName");
                    Assert.True(false, "GetIPsecParameters should have thrown a CloudException when a local network site didn't exist for the provided name.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("ResourceNotFound", e.Error.Code);
                    Assert.Equal("The specified local network site name \'NonExistingLocalNetworkName\' is not valid or could not be found.", e.Error.Message);
                    Assert.NotNull(e.Response);
                    Assert.Equal("Not Found", e.Response.ReasonPhrase);
                    Assert.Equal(HttpStatusCode.NotFound, e.Response.StatusCode);
                }
            }
        }
    }
}
