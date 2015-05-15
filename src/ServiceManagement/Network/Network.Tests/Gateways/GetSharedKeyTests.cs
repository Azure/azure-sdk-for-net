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

    public class GetSharedKeyTests
    {
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "GetSharedKey")]
        public void GetSharedKeyWhenNetworkConfigurationDoesNotExist()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.SetNetworkConfiguration(NetworkTestConstants.EmptyNetworkConfigurationParameters);

                try
                {
                    networkTestClient.Gateways.GetSharedKey(NetworkTestConstants.VirtualNetworkSiteName, NetworkTestConstants.LocalNetworkSiteName);
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                }
            }
        }

        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "GetSharedKey")]
        public void GetSharedKeyWhenGatewayIsNotProvisioned()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.SetNetworkConfiguration(NetworkTestConstants.SiteToSiteNetworkConfigurationParameters);

                try
                {
                    networkTestClient.Gateways.GetSharedKey(NetworkTestConstants.VirtualNetworkSiteName, NetworkTestConstants.LocalNetworkSiteName);
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                }
            }
        }

        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "GetSharedKey")]
        public void GetSharedKeyWhenGatewayIsProvisionedButNoSharedKeyHasBeenSet()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.SetNetworkConfiguration(NetworkTestConstants.SiteToSiteNetworkConfigurationParameters);

                networkTestClient.Gateways.CreateGateway(NetworkTestConstants.VirtualNetworkSiteName, NetworkTestConstants.CreateStaticRoutingGatewayParameters());

                GatewayGetSharedKeyResponse response = networkTestClient.Gateways.GetSharedKey(NetworkTestConstants.VirtualNetworkSiteName, NetworkTestConstants.LocalNetworkSiteName);
                Assert.NotNull(response);
                Assert.NotNull(response.SharedKey);
                Assert.NotEmpty(response.SharedKey);
            }
        }
    }
}
