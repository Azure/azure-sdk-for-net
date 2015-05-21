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

namespace Network.Tests.Gateways
{
    using Hyak.Common;
    using Microsoft.Azure;
    using Microsoft.WindowsAzure.Management.Network.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Xunit;

    public class LocallNetworkGatewayTests
    {
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "LocalNetworkGateway")]
        public void LocalNetworkGatewayAPIsTests()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                string localnetGatewayName = "coexistenceLocalnetGateway";

                // 1.CreateLocalNetworkGateway API
                string addressSpace = "200.168.0.0/16";

                var param = new LocalNetworkGatewayCreateParameters()
                    {
                        AddressSpace = new LazyList<string>() { addressSpace },
                        GatewayName = localnetGatewayName,
                        IpAddress = "204.95.99.237",
                    };

                LocalNetworkGatewayCreateResponse localNetworkGatewayCreateResponse = networkTestClient.Gateways.CreateLocalNetworkGateway(param);
                Assert.NotNull(localNetworkGatewayCreateResponse);
                Assert.Equal(HttpStatusCode.OK, localNetworkGatewayCreateResponse.StatusCode);
                Assert.NotNull(localNetworkGatewayCreateResponse.LocalNetworkGatewayId);

                // 2.Listvirtualnetworkgateways API
                ListLocalNetworkGatewaysResponse listLocalNetworkGatewaysResponse = networkTestClient.Gateways.ListLocalNetworkGateways();
                Assert.NotNull(listLocalNetworkGatewaysResponse);
                Assert.Equal(HttpStatusCode.OK, listLocalNetworkGatewaysResponse.StatusCode);
                Assert.Equal(1, listLocalNetworkGatewaysResponse.LocalNetworkGateways.Count);

                ListLocalNetworkGatewaysResponse.LocalNetworkGateway localNetworkGateway = listLocalNetworkGatewaysResponse.LocalNetworkGateways.First();
                Assert.Equal(localnetGatewayName, localNetworkGateway.GatewayName);
                Assert.Equal("204.95.99.237", localNetworkGateway.IpAddress);
                Assert.True(localNetworkGateway.AddressSpace.Contains(addressSpace), "CreateLocalNetworkGateway API failed as AddressSpace parameter is not set properly!");

                string localnetGatewayId = listLocalNetworkGatewaysResponse.LocalNetworkGateways.First(localnetGateway =>
                    localnetGateway.GatewayName.Equals(localnetGatewayName)).Id.ToString();
                Assert.True(!string.IsNullOrEmpty(localnetGatewayId), "CreateLocalNetworkGateway API Failed as local network gateway: "
                    + localnetGatewayName + "not found!");

                // 3.UpdateLocalNetworkGateway API
                addressSpace = "200.168.0.0/24";
                UpdateLocalNetworkGatewayParameters parameters = new UpdateLocalNetworkGatewayParameters()
                {
                    AddressSpace = new List<string>(new string[] { addressSpace })
                };
                AzureOperationResponse updateLocalNetworkGatewayResponse = networkTestClient.Gateways.UpdateLocalNetworkGateway(localnetGatewayId, parameters);
                Assert.NotNull(updateLocalNetworkGatewayResponse);
                Assert.Equal(HttpStatusCode.OK, updateLocalNetworkGatewayResponse.StatusCode);

                // 4.GetLocalNetworkGateway API
                LocalNetworkGatewayGetResponse localNetworkGatewayGetResponse = networkTestClient.Gateways.GetLocalNetworkGateway(localnetGatewayId);
                Assert.NotNull(localNetworkGatewayGetResponse);
                Assert.Equal(HttpStatusCode.OK, localNetworkGatewayGetResponse.StatusCode);
                Assert.Equal(localnetGatewayName, localNetworkGatewayGetResponse.GatewayName);
                Assert.Equal("204.95.99.237", localNetworkGatewayGetResponse.IpAddress);
                Assert.True(localNetworkGatewayGetResponse.AddressSpace.Contains(addressSpace), "UpdateLocalNetworkGateway API failed!");

                // 5.DeleteLocalNetworkGateway API
                AzureOperationResponse deleteLocalNetworkGatewayResponse = networkTestClient.Gateways.DeleteLocalNetworkGateway(localnetGatewayId);
                Assert.NotNull(deleteLocalNetworkGatewayResponse);
                Assert.Equal(HttpStatusCode.OK, deleteLocalNetworkGatewayResponse.StatusCode);

                listLocalNetworkGatewaysResponse = networkTestClient.Gateways.ListLocalNetworkGateways();
                Assert.NotNull(listLocalNetworkGatewaysResponse);
                Assert.Equal(HttpStatusCode.OK, listLocalNetworkGatewaysResponse.StatusCode);
                Assert.Equal(0, listLocalNetworkGatewaysResponse.LocalNetworkGateways.Count);
                Assert.False(listLocalNetworkGatewaysResponse.LocalNetworkGateways.Any(localnetGateway => localnetGateway.GatewayName.Equals(localnetGatewayName)),
                "Local network gateway: " + localnetGatewayName + " is not deleted even after DeleteLocalNetworkGateway API call!");

            }
        }
    }
}
