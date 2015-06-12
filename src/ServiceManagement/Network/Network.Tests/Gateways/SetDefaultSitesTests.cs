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

    public class SetDefaultSitesTests
    {
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "SetDefaultSites")]
        public void SetDefaultSitesWhenVirtualNetworkSiteNameDoesntExist()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                const string virtualNetworkSiteName = "NonExistantVirtualNetworkSiteName";
                GatewaySetDefaultSiteListParameters parameters = CreateParameters("localNetworkSiteName");

                try
                {
                    networkTestClient.Gateways.SetDefaultSites(virtualNetworkSiteName, parameters);
                    Assert.True(false, "SetDefaultSites should throw an CloudException when virtualNetworkSiteName did not exist.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.NotNull(e.Response);
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.True(e.Error.Message.Contains("virtual network name \'NonExistantVirtualNetworkSiteName\' is not valid"));
                    Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
                    Assert.Equal("Bad Request", e.Response.ReasonPhrase);
                }
            }
        }
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "SetDefaultSites")]
        public void SetDefaultSitesWhenGatewayIsNotProvisioned()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.EnsureSiteToSiteNetworkConfigurationExists();

                networkTestClient.Gateways.EnsureNoGatewayExists();

                const string virtualNetworkSiteName = NetworkTestConstants.VirtualNetworkSiteName;
                GatewaySetDefaultSiteListParameters parameters = CreateParameters("localNetworkSiteName");

                try
                {
                    networkTestClient.Gateways.SetDefaultSites(virtualNetworkSiteName, parameters);
                    Assert.True(false, "SetDefaultSites should throw an CloudException when the gateway was not provisioned.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.NotNull(e.Response);
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.True(e.Error.Message.Contains("current provisioning status of the gateway prevents this operation"));
                    Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
                    Assert.Equal("Bad Request", e.Response.ReasonPhrase);
                }
            }
        }
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "SetDefaultSites")]
        public void SetDefaultSitesWithStaticRoutingGateway()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureStaticRoutingGatewayExists();

                const string virtualNetworkSiteName = NetworkTestConstants.VirtualNetworkSiteName;
                GatewaySetDefaultSiteListParameters parameters = CreateParameters("localNetworkSiteName");

                try
                {
                    networkTestClient.Gateways.SetDefaultSites(virtualNetworkSiteName, parameters);
                    Assert.True(false, "SetDefaultSites should throw an CloudException when the gateway is a static routing gateway.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.NotNull(e.Response);
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.True(e.Error.Message.Contains("This operation is enabled only for the following gateway mode(s): BrooklynLite."));
                    Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
                    Assert.Equal("Bad Request", e.Response.ReasonPhrase);
                }
            }
        }
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "SetDefaultSites")]
        public void SetDefaultSitesWithDefaultSiteThatDoesNotExist()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureDynamicRoutingGatewayExists();

                const string virtualNetworkSiteName = NetworkTestConstants.VirtualNetworkSiteName;
                GatewaySetDefaultSiteListParameters parameters = CreateParameters("NonExistantLocalNetworkSite");

                try
                {
                    networkTestClient.Gateways.SetDefaultSites(virtualNetworkSiteName, parameters);
                    Assert.True(false, "SetDefaultSites should throw an CloudException when the default site is a non-existant local network site.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.NotNull(e.Response);
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.True(e.Error.Message.Contains("local network site name \'NonExistantLocalNetworkSite\' is not valid"));
                    Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
                    Assert.Equal("Bad Request", e.Response.ReasonPhrase);
                }
            }
        }
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "SetDefaultSites")]
        public void SetDefaultSitesWithDynamicRoutingGateway()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureDynamicRoutingGatewayExists();

                const string virtualNetworkSiteName = NetworkTestConstants.VirtualNetworkSiteName;
                GatewaySetDefaultSiteListParameters parameters = CreateParameters(NetworkTestConstants.LocalNetworkSiteName);

                GatewayGetOperationStatusResponse response = networkTestClient.Gateways.SetDefaultSites(virtualNetworkSiteName, parameters);
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.HttpStatusCode);
                Assert.NotNull(response.Id);
                Assert.Equal(GatewayOperationStatus.Successful, response.Status);

                GatewayGetResponse getResponse = networkTestClient.Gateways.GetGateway(virtualNetworkSiteName);
                Assert.NotNull(response);
                Assert.Equal(NetworkTestConstants.LocalNetworkSiteName, getResponse.DefaultSite.Name);
            }
        }

        private GatewaySetDefaultSiteListParameters CreateParameters(string defaultSite)
        {
            return new GatewaySetDefaultSiteListParameters()
            {
                DefaultSite = defaultSite,
            };
        }
    }
}
