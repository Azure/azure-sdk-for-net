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
        private string addressSpace = "200.168.0.0/16";
        private string localNetworkGatewayIpAddress = "204.95.99.237";

        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "LocalNetworkGateway")]
        public void LocalNetworkGatewayAPIsTests()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                string localnetGatewayName = "coexistenceLocalnetGateway";

                // 1.CreateLocalNetworkGateway API
                var param = new LocalNetworkGatewayCreateParameters()
                    {
                        AddressSpace = new LazyList<string>() { addressSpace },
                        GatewayName = localnetGatewayName,
                        IpAddress = localNetworkGatewayIpAddress,
                    };

                LocalNetworkGatewayCreateResponse localNetworkGatewayCreateResponse = networkTestClient.Gateways.CreateLocalNetworkGateway(param);
                Assert.NotNull(localNetworkGatewayCreateResponse);
                Assert.Equal(HttpStatusCode.OK, localNetworkGatewayCreateResponse.StatusCode);
                Assert.NotNull(localNetworkGatewayCreateResponse.LocalNetworkGatewayId);

                // 2.Listvirtualnetworkgateways API
                ListLocalNetworkGatewaysResponse listLocalNetworkGatewaysResponse = networkTestClient.Gateways.ListLocalNetworkGateways();
                Assert.NotNull(listLocalNetworkGatewaysResponse);
                Assert.Equal(HttpStatusCode.OK, listLocalNetworkGatewaysResponse.StatusCode);

                ListLocalNetworkGatewaysResponse.LocalNetworkGateway localNetworkGateway = null;
                foreach (ListLocalNetworkGatewaysResponse.LocalNetworkGateway lng in listLocalNetworkGatewaysResponse.LocalNetworkGateways)
                {
                    if (localNetworkGatewayCreateResponse.LocalNetworkGatewayId.IndexOf(lng.Id.ToString(), StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        localNetworkGateway = lng;
                    }
                }

                Assert.True(localNetworkGateway != null, "The created local network gateway's ID should show up when local network gateways are listed");
                Assert.Equal(localnetGatewayName, localNetworkGateway.GatewayName);
                Assert.Equal(localNetworkGatewayIpAddress, localNetworkGateway.IpAddress);
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
                Assert.Equal(localNetworkGatewayIpAddress, localNetworkGatewayGetResponse.IpAddress);
                Assert.True(localNetworkGatewayGetResponse.AddressSpace.Contains(addressSpace), "UpdateLocalNetworkGateway API failed!");

                // 5.DeleteLocalNetworkGateway API
                AzureOperationResponse deleteLocalNetworkGatewayResponse = networkTestClient.Gateways.DeleteLocalNetworkGateway(localnetGatewayId);
                Assert.NotNull(deleteLocalNetworkGatewayResponse);
                Assert.Equal(HttpStatusCode.OK, deleteLocalNetworkGatewayResponse.StatusCode);

                listLocalNetworkGatewaysResponse = networkTestClient.Gateways.ListLocalNetworkGateways();
                Assert.NotNull(listLocalNetworkGatewaysResponse);
                Assert.Equal(HttpStatusCode.OK, listLocalNetworkGatewaysResponse.StatusCode);
                Assert.False(listLocalNetworkGatewaysResponse.LocalNetworkGateways.Any(localnetGateway => localnetGateway.GatewayName.Equals(localnetGatewayName)),
                "Local network gateway: " + localnetGatewayName + " is not deleted even after DeleteLocalNetworkGateway API call!");
            }
        }

        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "LocalNetworkGateway")]
        public void LocalNetworkGatewayAPITestsWithBgp()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                // CreateLocalNetworkGateway, with BGP settings
                string localNetworkGatewayName = "BgpLocalNetworkGateway";
                uint localNetworkGatewayAsn = 1234;
                string localNetworkGatewayBgpPeeringAddress = "192.168.1.2";
                int localNetworkGatewayPeerWeight = 5;

                LocalNetworkGatewayCreateParameters createParameters = new LocalNetworkGatewayCreateParameters()
                {
                    AddressSpace = new LazyList<string>() { addressSpace },
                    GatewayName = localNetworkGatewayName,
                    IpAddress = localNetworkGatewayIpAddress,
                    BgpSettings = new BgpSettings()
                    {
                        Asn = localNetworkGatewayAsn,
                        BgpPeeringAddress = localNetworkGatewayBgpPeeringAddress,
                        PeerWeight = localNetworkGatewayPeerWeight,
                    }
                };

                LocalNetworkGatewayCreateResponse localNetworkGatewayCreateResponse = networkTestClient.Gateways.CreateLocalNetworkGateway(createParameters);
                Assert.NotNull(localNetworkGatewayCreateResponse);
                Assert.Equal(HttpStatusCode.OK, localNetworkGatewayCreateResponse.StatusCode);
                Assert.NotNull(localNetworkGatewayCreateResponse.LocalNetworkGatewayId);
                
                // Call ListLocalNetworkGateways, find one with a matching name to get the ID
                ListLocalNetworkGatewaysResponse lngListResponse = networkTestClient.Gateways.ListLocalNetworkGateways();
                ListLocalNetworkGatewaysResponse.LocalNetworkGateway localNetworkGateway = null;

                foreach (ListLocalNetworkGatewaysResponse.LocalNetworkGateway lng in lngListResponse.LocalNetworkGateways)
                {
                    if (lng.GatewayName.Equals(localNetworkGatewayName))
                    {
                        localNetworkGateway = lng;
                        break;
                    }
                }

                Assert.NotNull(localNetworkGateway);
                string localNetworkGatewayId = localNetworkGateway.Id.ToString();

                // BgpSettings should be respected
                // If generated code would generate an equals method, that would have been convenient. 
                Assert.Equal(localNetworkGateway.BgpSettings.Asn, localNetworkGatewayAsn);
                Assert.True(localNetworkGateway.BgpSettings.BgpPeeringAddress.Equals(localNetworkGatewayBgpPeeringAddress));
                Assert.Equal(localNetworkGateway.BgpSettings.PeerWeight, localNetworkGatewayPeerWeight);

                // Try an update, with different BgpSettings
                localNetworkGatewayAsn = 5678;
                UpdateLocalNetworkGatewayParameters updateParameters = new UpdateLocalNetworkGatewayParameters()
                {
                    AddressSpace = new List<string>(new string[] { addressSpace }),
                    BgpSettings = new BgpSettings() 
                    {
                        Asn = localNetworkGatewayAsn,
                        BgpPeeringAddress = localNetworkGatewayBgpPeeringAddress,
                        PeerWeight = localNetworkGatewayPeerWeight
                    }
                };

                AzureOperationResponse updateLocalNetworkGatewayResponse = networkTestClient.Gateways.UpdateLocalNetworkGateway(localNetworkGatewayId, updateParameters);
                Assert.NotNull(updateLocalNetworkGatewayResponse);
                Assert.Equal(HttpStatusCode.OK, updateLocalNetworkGatewayResponse.StatusCode);

                // Call GetLocalNetworkGateway again, and make sure the updated ASN shows up
                LocalNetworkGatewayGetResponse lngGetResponse = networkTestClient.Gateways.GetLocalNetworkGateway(localNetworkGatewayId);
                Assert.NotNull(lngGetResponse);
                Assert.NotNull(lngGetResponse.BgpSettings);
                Assert.Equal(lngGetResponse.BgpSettings.Asn, localNetworkGatewayAsn);

                // Delete
                AzureOperationResponse deleteLocalNetworkGatewayResponse = networkTestClient.Gateways.DeleteLocalNetworkGateway(localNetworkGatewayId);
                Assert.NotNull(deleteLocalNetworkGatewayResponse);
                Assert.Equal(HttpStatusCode.OK, deleteLocalNetworkGatewayResponse.StatusCode);

                // Call list again and make sure the local network gateway isn't there anymore
                lngListResponse = networkTestClient.Gateways.ListLocalNetworkGateways();
                localNetworkGateway = null;

                foreach (ListLocalNetworkGatewaysResponse.LocalNetworkGateway lng in lngListResponse.LocalNetworkGateways)
                {
                    if (lng.GatewayName.Equals(localNetworkGatewayName))
                    {
                        localNetworkGateway = lng;
                        break;
                    }
                }

                Assert.Null(localNetworkGateway);
            }
        }
    }
}
