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

    public class ResetSharedKeyTests
    {
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "ResetSharedKey")]
        public void ResetSharedKey()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.SetNetworkConfiguration(NetworkTestConstants.SiteToSiteNetworkConfigurationParameters);

                networkTestClient.Gateways.CreateGateway(NetworkTestConstants.VirtualNetworkSiteName, NetworkTestConstants.CreateStaticRoutingGatewayParameters());

                GatewayGetSharedKeyResponse firstGetResponse = networkTestClient.Gateways.GetSharedKey(NetworkTestConstants.VirtualNetworkSiteName, NetworkTestConstants.LocalNetworkSiteName);
                string firstSharedKey = firstGetResponse.SharedKey;

                GatewayResetSharedKeyParameters parameters = new GatewayResetSharedKeyParameters()
                {
                    KeyLength = 128,
                };
                GatewayGetOperationStatusResponse resetResponse = networkTestClient.Gateways.ResetSharedKey(NetworkTestConstants.VirtualNetworkSiteName, NetworkTestConstants.LocalNetworkSiteName, parameters);
                Assert.NotNull(resetResponse);
                Assert.Equal(HttpStatusCode.OK, resetResponse.HttpStatusCode);

                GatewayGetSharedKeyResponse secondGetResponse = networkTestClient.Gateways.GetSharedKey(NetworkTestConstants.VirtualNetworkSiteName, NetworkTestConstants.LocalNetworkSiteName);
                string secondSharedKey = secondGetResponse.SharedKey;

                Assert.NotEqual(firstSharedKey, secondSharedKey);
            }
        }
    }
}
