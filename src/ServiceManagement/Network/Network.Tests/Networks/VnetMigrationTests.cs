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

using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Azure;
using Microsoft.Azure.Test;
using Microsoft.Data.Edm.Csdl;
using Network.Tests.Networks.TestOperations;

namespace Network.Tests.Networks
{
    using System;
    using System.Net;
    using Microsoft.WindowsAzure.Management.Network.Models;
    using Xunit;

    public class VnetMigrationTests
    {
        [Fact]
        [Trait("Feature", "Networks")]
        public void ValidateVNetForMigration()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                string virtualNetworkName = "foo";
                var response = networkTestClient.ValidateVnetMigration(virtualNetworkName);
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                Assert.NotNull(response.ValidateVirtualNetworkMessages);
                Assert.Equal(1, response.ValidateVirtualNetworkMessages.Count);
                Assert.Equal("The virtual network foo does not exist.", response.ValidateVirtualNetworkMessages[0].Message);
            }
        }

        [Fact]
        [Trait("Feature", "Networks")]
        public void MigrateSimpleVNetConfiguration()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                OperationStatusResponse osResp = networkTestClient.SetNetworkConfiguration(NetworkTestConstants.SimpleMigrationNetworkConfigurationParameters);
                Assert.Equal(OperationStatus.Succeeded, osResp.Status);

                osResp = networkTestClient.PrepareVnetMigration(NetworkTestConstants.VirtualNetworkSiteName);
                Assert.Equal(OperationStatus.Succeeded, osResp.Status);

                NetworkListResponse response = networkTestClient.ListNetworkConfigurations();
                // BUG: Return "2" instead of "Prepared"
                // Re-record after the bug is fixed in Server.
                Assert.NotNull(response.VirtualNetworkSites.First().MigrationState);
                //Assert.Equal(IaasClassicToArmMigrationState.Prepared, response.VirtualNetworkSites.First().MigrationState);

                osResp = networkTestClient.CommitVnetMigration(NetworkTestConstants.VirtualNetworkSiteName);
                Assert.Equal(OperationStatus.Succeeded, osResp.Status);
            }
        }

        [Fact]
        [Trait("Feature", "Networks")]
        public void AbortSimpleVNetConfiguration()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                OperationStatusResponse osResp = networkTestClient.SetNetworkConfiguration(NetworkTestConstants.SimpleMigrationNetworkConfigurationParameters);
                Assert.Equal(OperationStatus.Succeeded, osResp.Status);

                osResp = networkTestClient.PrepareVnetMigration(NetworkTestConstants.VirtualNetworkSiteName);
                Assert.Equal(OperationStatus.Succeeded, osResp.Status);

                NetworkListResponse response = networkTestClient.ListNetworkConfigurations();
                // BUG: Return "2" instead of "Prepared"
                // Re-record after the bug is fixed in Server.
                Assert.NotNull(response.VirtualNetworkSites.First().MigrationState);
                //Assert.Equal(IaasClassicToArmMigrationState.Prepared, response.VirtualNetworkSites.First().MigrationState);

                osResp = networkTestClient.AbortVnetMigration(NetworkTestConstants.VirtualNetworkSiteName);
                Assert.Equal(OperationStatus.Succeeded, osResp.Status);
            }
        }
    }
}
