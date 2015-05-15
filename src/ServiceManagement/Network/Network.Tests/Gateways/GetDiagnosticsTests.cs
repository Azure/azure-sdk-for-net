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
    using Microsoft.WindowsAzure.Management.Network.Models;
    using Xunit;

    public class GetDiagnosticsTests
    {
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "GetDiagnosticsTests")]
        public void GetDiagnosticsWithInvalidVirtualNetworkName()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                try
                {
                    networkTestClient.Gateways.GetDiagnostics("NotFoundVirtualNetworkName");
                    Assert.True(false, "Should have thrown a CloudException.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.Contains("NotFoundVirtualNetworkName", e.Error.Message);
                    Assert.Contains("not valid or could not be found", e.Error.Message);
                }
            }
        }
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "GetDiagnosticsTests")]
        public void GetDiagnostics()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Gateways.EnsureStaticRoutingGatewayExists();

                GatewayDiagnosticsStatus status = networkTestClient.Gateways.GetDiagnostics(NetworkTestConstants.VirtualNetworkSiteName);
                Assert.NotNull(status);
                Assert.Equal(GatewayDiagnosticsState.Ready, status.State);
            }
        }
    }
}
