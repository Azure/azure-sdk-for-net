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

    public class StartDiagnosticsTests
    {
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "StartDiagnostics")]
        public void StartDiagnosticsWithNotFoundVirtualNetworkName()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                StartGatewayPublicDiagnosticsParameters parameters = new StartGatewayPublicDiagnosticsParameters()
                {
                    Operation = UpdateGatewayPublicDiagnosticsOperation.StartDiagnostics,
                    CustomerStorageName = "daschult20140611a",
                    // [SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
                    CustomerStorageKey = "EyXneSsrZJJbBT4bHL6p4KdO+S5YCtM75PAA1gVWd39vwHm2CHfosBRRDkJYJWpY2mpnYlMROpgqmEci6b3u0w==",
                    ContainerName = "hydra-test-diagnostics",
                    CaptureDurationInSeconds = "1",
                };

                const string virtualNetworkName = "NotFoundVirtualNetworkName";

                try
                {
                    networkTestClient.Gateways.StartDiagnostics(virtualNetworkName, parameters);
                    Assert.True(false, "UpdateDiagnostics should have thrown a CloudException when a virtual network name was provided that didn't exist.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.Contains(virtualNetworkName, e.Error.Message);
                    Assert.Contains("not valid or could not be found", e.Error.Message);
                }
            }
        }
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "StartDiagnostics")]
        public void StartDiagnosticsWithEmptyParameters()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.EnsureSiteToSiteNetworkConfigurationExists();

                StartGatewayPublicDiagnosticsParameters parameters = new StartGatewayPublicDiagnosticsParameters();

                try
                {
                    networkTestClient.Gateways.StartDiagnostics(NetworkTestConstants.VirtualNetworkSiteName, parameters);
                    Assert.True(false, "UpdateDiagnostics should have thrown a CloudException with an InternalError.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.True(e.Error.Message.Contains("CustomerStorageName was not valid."));
                }
            }
        }
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "StartDiagnostics")]
        public void StartDiagnosticsWithNoCustomerStorageName()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.EnsureSiteToSiteNetworkConfigurationExists();

                StartGatewayPublicDiagnosticsParameters parameters = new StartGatewayPublicDiagnosticsParameters()
                {
                    Operation = UpdateGatewayPublicDiagnosticsOperation.StartDiagnostics,
                    // [SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
                    CustomerStorageKey = "EyXneSsrZJJbBT4bHL6p4KdO+S5YCtM75PAA1gVWd39vwHm2CHfosBRRDkJYJWpY2mpnYlMROpgqmEci6b3u0w==",
                    ContainerName = "hydra-test-diagnostics",
                    CaptureDurationInSeconds = "1",
                };

                try
                {
                    networkTestClient.Gateways.StartDiagnostics(NetworkTestConstants.VirtualNetworkSiteName, parameters);
                    Assert.True(false, "UpdateDiagnostics should have thrown a CloudException.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.True(e.Error.Message.Contains("CustomerStorageName was not valid"));
                }
            }
        }
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "StartDiagnostics")]
        public void StartDiagnosticsWithNoCustomerStorageKey()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.EnsureSiteToSiteNetworkConfigurationExists();

                StartGatewayPublicDiagnosticsParameters parameters = new StartGatewayPublicDiagnosticsParameters()
                {
                    Operation = UpdateGatewayPublicDiagnosticsOperation.StartDiagnostics,
                    CustomerStorageName = "daschult20140611a",
                    ContainerName = "hydra-test-diagnostics",
                    CaptureDurationInSeconds = "1",
                };

                try
                {
                    networkTestClient.Gateways.StartDiagnostics(NetworkTestConstants.VirtualNetworkSiteName, parameters);
                    Assert.True(false, "UpdateDiagnostics should have thrown a CloudException.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.True(e.Error.Message.Contains("CustomerStorageKey was not valid"));
                }
            }
        }
        [Fact(Skip = "Test failing. Dan needs to re-record these.")]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "StartDiagnostics")]
        public void StartDiagnosticsWithNoContainerName()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureStaticRoutingGatewayExists();

                StartGatewayPublicDiagnosticsParameters startParameters = new StartGatewayPublicDiagnosticsParameters()
                {
                    Operation = UpdateGatewayPublicDiagnosticsOperation.StartDiagnostics,
                    CustomerStorageName = "daschult20140611a",
                    // [SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
                    CustomerStorageKey = "EyXneSsrZJJbBT4bHL6p4KdO+S5YCtM75PAA1gVWd39vwHm2CHfosBRRDkJYJWpY2mpnYlMROpgqmEci6b3u0w==",
                    CaptureDurationInSeconds = "1",
                };

                GatewayGetOperationStatusResponse startResponse = networkTestClient.Gateways.StartDiagnostics(NetworkTestConstants.VirtualNetworkSiteName, startParameters);
                Assert.NotNull(startResponse);
                Assert.Equal(HttpStatusCode.OK, startResponse.HttpStatusCode);

                GatewayDiagnosticsStatus stopStatus;
                do
                {
                    stopStatus = networkTestClient.Gateways.GetDiagnostics(NetworkTestConstants.VirtualNetworkSiteName);
                    Assert.NotNull(stopStatus);

                } while (stopStatus.State != GatewayDiagnosticsState.Ready);

                Assert.Equal(GatewayDiagnosticsState.Ready, stopStatus.State);
                Assert.True(stopStatus.DiagnosticsUrl != null, "The diagnostics url was null.");
                Assert.True(1 <= stopStatus.DiagnosticsUrl.Length, "The diagnostics url was empty.");
            }
        }
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "StartDiagnostics")]
        public void StartDiagnosticsWithNoCaptureDuration()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.EnsureSiteToSiteNetworkConfigurationExists();

                StartGatewayPublicDiagnosticsParameters parameters = new StartGatewayPublicDiagnosticsParameters()
                {
                    Operation = UpdateGatewayPublicDiagnosticsOperation.StartDiagnostics,
                    CustomerStorageName = "daschult20140611a",
                    // [SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
                    CustomerStorageKey = "EyXneSsrZJJbBT4bHL6p4KdO+S5YCtM75PAA1gVWd39vwHm2CHfosBRRDkJYJWpY2mpnYlMROpgqmEci6b3u0w==",
                    ContainerName = "hydra-test-diagnostics",
                };

                try
                {
                    networkTestClient.Gateways.StartDiagnostics(NetworkTestConstants.VirtualNetworkSiteName, parameters);
                    Assert.True(false, "UpdateDiagnostics should have thrown a CloudException.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.True(e.Error.Message.Contains("CaptureDurationInSeconds was not valid"));
                }
            }
        }
        [Fact(Skip = "Test failing. Dan needs to re-record these.")]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "StartDiagnostics")]
        public void StartDiagnostics()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureStaticRoutingGatewayExists();

                StartGatewayPublicDiagnosticsParameters startParameters = new StartGatewayPublicDiagnosticsParameters()
                {
                    Operation = UpdateGatewayPublicDiagnosticsOperation.StartDiagnostics,
                    CustomerStorageName = "daschult20140611a",
                    // [SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
                    CustomerStorageKey = "EyXneSsrZJJbBT4bHL6p4KdO+S5YCtM75PAA1gVWd39vwHm2CHfosBRRDkJYJWpY2mpnYlMROpgqmEci6b3u0w==",
                    ContainerName = "hydra-test-diagnostics",
                    CaptureDurationInSeconds = "300",
                };

                GatewayGetOperationStatusResponse startResponse = networkTestClient.Gateways.StartDiagnostics(NetworkTestConstants.VirtualNetworkSiteName, startParameters);
                Assert.NotNull(startResponse);
                Assert.Equal(HttpStatusCode.OK, startResponse.HttpStatusCode);

                GatewayDiagnosticsStatus startStatus = networkTestClient.Gateways.GetDiagnostics(NetworkTestConstants.VirtualNetworkSiteName);
                Assert.NotNull(startStatus);
                Assert.True(startStatus.DiagnosticsUrl != null, "The diagnostics url was null.");
                Assert.Equal(GatewayDiagnosticsState.InProgress, startStatus.State);

                StopGatewayPublicDiagnosticsParameters stopParameters = new StopGatewayPublicDiagnosticsParameters();

                try
                {
                    networkTestClient.Gateways.StopDiagnostics(NetworkTestConstants.VirtualNetworkSiteName, stopParameters);
                    Assert.True(false, "StopDiagnostics should throw a CloudException because the REST API is expecting a 202 (Accepted) status code, but GatewayManager is returning a 200 (OK).");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Null(e.Error.Code);
                    Assert.Null(e.Error.Message);
                    Assert.NotNull(e.Response);
                    Assert.Equal(HttpStatusCode.OK, e.Response.StatusCode);
                    Assert.Equal("OK", e.Response.ReasonPhrase);
                }

                GatewayDiagnosticsStatus stopStatus;
                do
                {
                    stopStatus = networkTestClient.Gateways.GetDiagnostics(NetworkTestConstants.VirtualNetworkSiteName);
                    Assert.NotNull(stopStatus);

                } while (stopStatus.State != GatewayDiagnosticsState.Ready);
                
                Assert.Equal(GatewayDiagnosticsState.Ready, stopStatus.State);
                Assert.True(stopStatus.DiagnosticsUrl != null, "The diagnostics url was null.");
                Assert.True(1 <= stopStatus.DiagnosticsUrl.Length, "The diagnostics url was empty.");
            }
        }
    }
}
