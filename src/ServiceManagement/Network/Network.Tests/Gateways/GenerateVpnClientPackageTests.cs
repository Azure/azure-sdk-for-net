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

    public class GenerateVpnClientPackageTests
    {
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "GenerateVpnClientPackage")]
        public void GenerateVpnClientPackageWithNotFoundNetworkName()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                const string networkName = "NotFoundNetworkName";
                GatewayGenerateVpnClientPackageParameters parameters = new GatewayGenerateVpnClientPackageParameters()
                {
                    ProcessorArchitecture = GatewayProcessorArchitecture.X86,
                };

                try
                {
                    networkTestClient.Gateways.GenerateVpnClientPackage(networkName, parameters);
                    Assert.True(false, "GenerateVpnClientPackage should have thrown a CloudException when the networkName was empty.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.Contains(networkName, e.Error.Message);
                    Assert.Contains("not valid or could not be found", e.Error.Message, StringComparison.InvariantCultureIgnoreCase);
                }
            }
        }
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "GenerateVpnClientPackage")]
        public void GenerateVpnClientPackageWithStaticRoutingConfiguration()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.EnsureSiteToSiteNetworkConfigurationExists();
                networkTestClient.Gateways.EnsureNoGatewayExists();

                const string networkName = "virtualNetworkSiteName";
                GatewayGenerateVpnClientPackageParameters parameters = new GatewayGenerateVpnClientPackageParameters()
                {
                    ProcessorArchitecture = GatewayProcessorArchitecture.Amd64,
                };

                try
                {
                    networkTestClient.Gateways.GenerateVpnClientPackage(networkName, parameters);
                    Assert.True(false, "GenerateVpnClientPackage should have thrown a CloudException when the networkName was empty.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.Contains("current provisioning status of the gateway prevents this operation", e.Error.Message, StringComparison.InvariantCultureIgnoreCase);
                }
            }
        }
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "GenerateVpnClientPackage")]
        public void GenerateVpnClientPackageWithStaticRoutingGatewayWithNoClientRootCertificates()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureStaticRoutingGatewayExists();

                GatewayGenerateVpnClientPackageParameters parameters = new GatewayGenerateVpnClientPackageParameters()
                {
                    ProcessorArchitecture = GatewayProcessorArchitecture.Amd64,
                };

                try
                {
                    networkTestClient.Gateways.GenerateVpnClientPackage(NetworkTestConstants.VirtualNetworkSiteName, parameters);
                    Assert.True(false, "GenerateVpnClientPackage should throw a CloudException when there are no client root certificates uploaded for this virtual network.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("ResourceNotFound", e.Error.Code);
                    Assert.Equal("There must be at least one client root certificate authority installed on the Gateway", e.Error.Message);
                    Assert.NotNull(e.Response);
                    Assert.Equal("Not Found", e.Response.ReasonPhrase);
                    Assert.Equal(HttpStatusCode.NotFound, e.Response.StatusCode);
                }
            }
        }
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "GenerateVpnClientPackage")]
        public void GenerateVpnClientPackageWithDynamicRoutingConfiguration()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.EnsurePointToSiteNetworkConfigurationExists();
                networkTestClient.Gateways.EnsureNoGatewayExists();

                GatewayGenerateVpnClientPackageParameters parameters = new GatewayGenerateVpnClientPackageParameters()
                {
                    ProcessorArchitecture = GatewayProcessorArchitecture.Amd64,
                };

                try
                {
                    networkTestClient.Gateways.GenerateVpnClientPackage(NetworkTestConstants.VirtualNetworkSiteName, parameters);
                    Assert.True(false, "GenerateVpnClientPackage should have thrown a CloudException when no gateway existed.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.Contains("current provisioning status of the gateway prevents this operation", e.Error.Message, StringComparison.InvariantCultureIgnoreCase);
                }
            }
        }
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "GenerateVpnClientPackage")]
        public void GenerateVpnClientPackageWithDynamicRoutingGatewayWithNoClientRootCertificates()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureDynamicRoutingGatewayExists();

                GatewayGenerateVpnClientPackageParameters parameters = new GatewayGenerateVpnClientPackageParameters()
                {
                    ProcessorArchitecture = GatewayProcessorArchitecture.Amd64,
                };

                try
                {
                    networkTestClient.Gateways.GenerateVpnClientPackage(NetworkTestConstants.VirtualNetworkSiteName, parameters);
                    Assert.True(false, "GenerateVpnClientPackage should throw a CloudException when there are no client root certificates uploaded for this virtual network.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("ResourceNotFound", e.Error.Code);
                    Assert.Equal("There must be at least one client root certificate authority installed on the Gateway", e.Error.Message);
                    Assert.NotNull(e.Response);
                    Assert.Equal("Not Found", e.Response.ReasonPhrase);
                    Assert.Equal(HttpStatusCode.NotFound, e.Response.StatusCode);
                }
            }
        }
    }
}
