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

    public class SetIPsecParametersTests
    {
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "SetIPsecParameters")]
        public void SetIPsecParametersWithNonExistingVirtualNetworkName()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.EnsureNoNetworkConfigurationExists();

                try
                {
                    networkTestClient.Gateways.SetIPsecParameters("NonExistingVnetName", NetworkTestConstants.LocalNetworkSiteName, CreateParameters());
                    Assert.True(false, "SetIPsecParameters should have thrown a CloudException when a virtual network site didn't exist for the provided name.");
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
        [Trait("Operation", "SetIPsecParameters")]
        public void SetIPsecParametersWithStaticRoutingGateway()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureStaticRoutingGatewayExists();

                try
                {
                    networkTestClient.Gateways.SetIPsecParameters(NetworkTestConstants.VirtualNetworkSiteName, NetworkTestConstants.LocalNetworkSiteName, CreateParameters());
                    Assert.True(false, "SetIPsecParameters should have thrown a CloudException when a static routing gateway is provisioned.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.Equal("This operation is enabled only for the following gateway mode(s): BrooklynLite. ", e.Error.Message);
                    Assert.NotNull(e.Response);
                    Assert.Equal("Bad Request", e.Response.ReasonPhrase);
                    Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
                }
            }
        }

        [Fact(Skip = "Test failing. Dan needs to re-record these.")]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "SetIPsecParameters")]
        public void SetIPsecParametersWithDynamicRoutingGatewayAndNonExistantLocalNetworkSite()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureDynamicRoutingGatewayExists();

                try
                {
                    networkTestClient.Gateways.SetIPsecParameters(NetworkTestConstants.VirtualNetworkSiteName, "NonExistantLocalNetworkSite", CreateParameters());
                    Assert.True(false, "SetIPsecParameters should have thrown a CloudException when the local network site did not exist.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("ResourceNotFound", e.Error.Code);
                    Assert.Equal("The specified local network site name \'NonExistantLocalNetworkSite\' is not valid or could not be found.", e.Error.Message);
                    Assert.NotNull(e.Response);
                    Assert.Equal("Not Found", e.Response.ReasonPhrase);
                    Assert.Equal(HttpStatusCode.NotFound, e.Response.StatusCode);
                }
            }
        }

        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "SetIPsecParameters")]
        public void SetIPsecParameters()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureDynamicRoutingGatewayExists();

                GatewaySetIPsecParametersParameters setParameters = CreateParameters();
                GatewayGetOperationStatusResponse response = networkTestClient.Gateways.SetIPsecParameters(NetworkTestConstants.VirtualNetworkSiteName, NetworkTestConstants.LocalNetworkSiteName, setParameters);
                Assert.NotNull(response);
                Assert.NotNull(response.Id);
                Assert.Equal(HttpStatusCode.OK, response.HttpStatusCode);

                GatewayGetIPsecParametersResponse paramResponse = networkTestClient.Gateways.GetIPsecParameters(NetworkTestConstants.VirtualNetworkSiteName, NetworkTestConstants.LocalNetworkSiteName);
                Assert.NotNull(paramResponse);
                Assert.NotNull(paramResponse.IPsecParameters);
                Assert.Equal(EncryptionType.NoEncryption, paramResponse.IPsecParameters.EncryptionType);
                Assert.Equal(PfsGroup.PFS1, paramResponse.IPsecParameters.PfsGroup);
                Assert.Equal(0, paramResponse.IPsecParameters.SADataSizeKilobytes);
                Assert.Equal(0, paramResponse.IPsecParameters.SALifeTimeSeconds);
            }
        }

        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "SetIPsecParameters")]
        public void SetIPsecParametersWithNotProvisionedGateway()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureNoGatewayExists();
                networkTestClient.EnsureSiteToSiteNetworkConfigurationExists();

                try
                {
                    networkTestClient.Gateways.SetIPsecParameters(NetworkTestConstants.VirtualNetworkSiteName, NetworkTestConstants.LocalNetworkSiteName, CreateParameters());
                    Assert.True(false, "SetIPsecParameters should have thrown a CloudException when the gateway wasn't provisioned.");
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

        private static GatewaySetIPsecParametersParameters CreateParameters()
        {
            return new GatewaySetIPsecParametersParameters()
            {
                Parameters = new IPsecParameters()
                {
                    EncryptionType = EncryptionType.NoEncryption,
                    PfsGroup = PfsGroup.PFS1,
                    SADataSizeKilobytes = 0,
                    SALifeTimeSeconds = 0,
                }
            };
        }
    }
}
