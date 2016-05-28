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
    using System.Net;
    using Microsoft.WindowsAzure.Management.Network.Models;
    using Xunit;
    using System;
    using System.Linq;

    public class DiagnosticsV2Tests
    {
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "DiagnosticsV2")]
        public void DiagnosticsV2APIsTests()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                // 1.StartDiagnosticsV2 API
                // a.CreateVirtualnetworkGateway API
                string virtualNetworkSiteName = "coexistenceVirtualNetworkSiteName";
                string vnetGatewayName = "coexistenceVnetGateway";

                networkTestClient.EnsureNoNetworkConfigurationExists(virtualNetworkSiteName);

                networkTestClient.SetNetworkConfiguration(NetworkTestConstants.CoexistenceFeatureNetworkConfigurationParameters);
                NetworkListResponse listResponse = networkTestClient.ListNetworkConfigurations();
                Assert.NotNull(listResponse);
                Assert.True(listResponse.VirtualNetworkSites.Any(vnet => vnet.Name.Equals(virtualNetworkSiteName)),
                    "Virtual network:" + virtualNetworkSiteName + " is not found!");
                string vnetId = listResponse.First(vnet => vnet.Name.Equals(virtualNetworkSiteName)).Id;

                GatewayGetOperationStatusResponse response =
                    networkTestClient.Gateways.CreateVirtualNetworkGateway(
                        virtualNetworkSiteName,
                        new VirtualNetworkGatewayCreateParameters()
                        {
                            GatewayName = vnetGatewayName,
                            GatewayType = GatewayType.DynamicRouting
                        });
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.HttpStatusCode);

                // Listvirtualnetworkgateways API
                ListVirtualNetworkGatewaysResponse listVirtualNetworkGatewaysResponse = networkTestClient.Gateways.ListVirtualNetworkGateways();
                Assert.True(listVirtualNetworkGatewaysResponse.VirtualNetworkGateways.Count >= 1);
                Guid vnetGatewayId = listVirtualNetworkGatewaysResponse.VirtualNetworkGateways.First(vnetGateway => vnetGateway.GatewayName.Equals(vnetGatewayName)).GatewayId;

                // b.StartDiagnosticsV2 API
                StartGatewayPublicDiagnosticsParameters startParameters = new StartGatewayPublicDiagnosticsParameters()
                {
                    Operation = UpdateGatewayPublicDiagnosticsOperation.StartDiagnostics,
                    CustomerStorageName = "daschult20140611a",
                    // [SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
                    CustomerStorageKey = "EyXneSsrZJJbBT4bHL6p4KdO+S5YCtM75PAA1gVWd39vwHm2CHfosBRRDkJYJWpY2mpnYlMROpgqmEci6b3u0w==",
                    ContainerName = "hydra-test-diagnostics",
                    CaptureDurationInSeconds = "60",
                };

                GatewayGetOperationStatusResponse startResponse = networkTestClient.Gateways.StartDiagnosticsV2(vnetGatewayId.ToString(), startParameters);
                Assert.NotNull(startResponse);
                Assert.Equal(HttpStatusCode.OK, startResponse.HttpStatusCode);

                // 2.GetDiagnosticsV2 API
                GatewayDiagnosticsStatus startStatus = networkTestClient.Gateways.GetDiagnosticsV2(vnetGatewayId.ToString());
                Assert.NotNull(startStatus);
                Assert.Equal(HttpStatusCode.OK, startStatus.StatusCode);
                Assert.True(startStatus.DiagnosticsUrl != null, "The diagnostics url was null.");
                Assert.Equal(GatewayDiagnosticsState.InProgress, startStatus.State);

                // StopDiagnosticsV2 API
                StopGatewayPublicDiagnosticsParameters stopParameters = new StopGatewayPublicDiagnosticsParameters();

                GatewayOperationResponse gatewayOperationResponse = networkTestClient.Gateways.StopDiagnosticsV2(vnetGatewayId.ToString(), stopParameters);
                Assert.NotNull(gatewayOperationResponse);
                Assert.Equal(HttpStatusCode.Accepted, gatewayOperationResponse.StatusCode);

                GatewayDiagnosticsStatus stopStatus;
                do
                {
                    stopStatus = networkTestClient.Gateways.GetDiagnosticsV2(vnetGatewayId.ToString());
                    Assert.NotNull(stopStatus);

                } while (stopStatus.State != GatewayDiagnosticsState.Ready);

                Assert.Equal(GatewayDiagnosticsState.Ready, stopStatus.State);
                Assert.True(stopStatus.DiagnosticsUrl != null, "The diagnostics url was null.");
                Assert.True(1 <= stopStatus.DiagnosticsUrl.Length, "The diagnostics url was empty.");

                // Cleanup test setup at end
                response = networkTestClient.Gateways.DeleteVirtualNetworkGateway(vnetGatewayId.ToString());
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.HttpStatusCode);
            }
        }
    }
}
