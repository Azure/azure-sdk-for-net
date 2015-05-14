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

    public class SetSharedKeyTests
    {
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "SetSharedKey")]
        public void SetSharedKeyWithNullSharedKeyValue()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureStaticRoutingGatewayExists();

                GatewaySetSharedKeyParameters setParameters = new GatewaySetSharedKeyParameters()
                {
                    Value = null,
                };

                try
                {
                    networkTestClient.Gateways.SetSharedKey(NetworkTestConstants.VirtualNetworkSiteName, NetworkTestConstants.LocalNetworkSiteName, setParameters);
                    Assert.False(true, "SetSharedKey should have thrown a BadRequest CloudException when the shared key value was null.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                }
            }
        }
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "SetSharedKey")]
        public void SetSharedKeyWithEmptySharedKeyValue()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureStaticRoutingGatewayExists();

                GatewaySetSharedKeyParameters setParameters = new GatewaySetSharedKeyParameters()
                {
                    Value = "",
                };

                try
                {
                    networkTestClient.Gateways.SetSharedKey(NetworkTestConstants.VirtualNetworkSiteName, NetworkTestConstants.LocalNetworkSiteName, setParameters);
                    Assert.False(true, "SetSharedKey should have thrown a BadRequest CloudException when the shared key value was empty.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                }
            }
        }
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "SetSharedKey")]
        public void SetSharedKey()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureStaticRoutingGatewayExists();

                GatewayResetSharedKeyParameters resetParameters = new GatewayResetSharedKeyParameters()
                {
                    KeyLength = 128,
                };
                GatewayGetOperationStatusResponse resetResponse = networkTestClient.Gateways.ResetSharedKey(NetworkTestConstants.VirtualNetworkSiteName, NetworkTestConstants.LocalNetworkSiteName, resetParameters);
                Assert.NotNull(resetResponse);
                Assert.Equal(HttpStatusCode.OK, resetResponse.HttpStatusCode);

                const string sharedKeyToSet = "ABC";

                GatewayGetSharedKeyResponse firstGetResponse = networkTestClient.Gateways.GetSharedKey(NetworkTestConstants.VirtualNetworkSiteName, NetworkTestConstants.LocalNetworkSiteName);
                Assert.NotEqual(sharedKeyToSet, firstGetResponse.SharedKey);

                GatewaySetSharedKeyParameters setParameters = new GatewaySetSharedKeyParameters()
                {
                    Value = sharedKeyToSet,
                };


                GatewayGetOperationStatusResponse setResponse = networkTestClient.Gateways.SetSharedKey(NetworkTestConstants.VirtualNetworkSiteName, NetworkTestConstants.LocalNetworkSiteName, setParameters);
                Assert.NotNull(setResponse);
                Assert.Equal(HttpStatusCode.OK, setResponse.HttpStatusCode);


                GatewayGetSharedKeyResponse secondGetResponse = networkTestClient.Gateways.GetSharedKey(NetworkTestConstants.VirtualNetworkSiteName, NetworkTestConstants.LocalNetworkSiteName);
                Assert.Equal(sharedKeyToSet, secondGetResponse.SharedKey);
            }
        }
    }
}
