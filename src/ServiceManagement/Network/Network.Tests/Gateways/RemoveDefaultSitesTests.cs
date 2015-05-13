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

    public class RemoveDefaultSitesTests
    {
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "RemoveDefaultSites")]
        public void RemoveDefaultSitesWhenVirtualNetworkSiteNameDoesntExist()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                try
                {
                    networkTestClient.Gateways.RemoveDefaultSites("NonExistantVirtualNetworkSiteName");
                    Assert.True(false, "RemoveDefaultSites should throw an CloudException when virtualNetworkSiteName did not exist.");
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
        [Trait("Operation", "RemoveDefaultSites")]
        public void RemoveDefaultSitesWhenGatewayIsNotProvisioned()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.EnsureSiteToSiteNetworkConfigurationExists();

                networkTestClient.Gateways.EnsureNoGatewayExists();

                try
                {
                    networkTestClient.Gateways.RemoveDefaultSites(NetworkTestConstants.VirtualNetworkSiteName);
                    Assert.True(false, "RemoveDefaultSites should throw an CloudException when the gateway was not provisioned.");
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
        [Trait("Operation", "RemoveDefaultSites")]
        public void RemoveDefaultSitesWithStaticRoutingGateway()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureStaticRoutingGatewayExists();

                try
                {
                    networkTestClient.Gateways.RemoveDefaultSites(NetworkTestConstants.VirtualNetworkSiteName);
                    Assert.True(false, "RemoveDefaultSites should throw an CloudException when the gateway is a static routing gateway.");
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
        [Trait("Operation", "RemoveDefaultSites")]
        public void RemoveDefaultSitesWithDynamicRoutingGateway()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureDynamicRoutingGatewayExists();

                GatewayGetOperationStatusResponse response = networkTestClient.Gateways.RemoveDefaultSites(NetworkTestConstants.VirtualNetworkSiteName);
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.HttpStatusCode);
                Assert.NotNull(response.Id);
                Assert.Equal(GatewayOperationStatus.Successful, response.Status);
            }
        }
    }
}
