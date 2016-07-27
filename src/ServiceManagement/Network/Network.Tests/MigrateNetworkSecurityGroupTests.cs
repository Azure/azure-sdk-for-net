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

namespace Network.Tests.NetworkSecurityGroups
{
    using System.Net;
    using Microsoft.WindowsAzure.Management.Network;
    using Microsoft.WindowsAzure.Management.Network.Models;
    using Microsoft.Azure.Test;
    using Microsoft.WindowsAzure.Management.Compute;
    using Microsoft.WindowsAzure.Management.Storage;
    using Xunit;

    public class MigrateNetworkSecurityGroupTests
    {
        [Fact]
        [Trait("Feature", "NetworkSecurityGroups")]
        public void ValidateMigrationNetworkSecurityGroup()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                
                var networkClient = TestBase.GetServiceClient<NetworkManagementClient>();

                // setup
                string securityGroupName = TestUtilities.GenerateName();
                string securityGroupLabel = TestUtilities.GenerateName();
                string securityGroupLocation = NetworkTestConstants.WideVNetLocation;

                var nsgCreateParameters = CreateParameters(securityGroupName, securityGroupLabel, securityGroupLocation);
                networkClient.NetworkSecurityGroups.Create(nsgCreateParameters);
                
                // assert
                NetworkSecurityGroupGetResponse response = networkClient.NetworkSecurityGroups.Get(securityGroupName, null);
                Assert.Equal(securityGroupName, response.Name);
                Assert.Equal(securityGroupLabel, response.Label);
                Assert.Equal(securityGroupLocation, response.Location);

                // Validate migration
                var validateResponse = networkClient.NetworkSecurityGroups.ValidateMigration(securityGroupName);
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                // Delete the nsg
                var deleteResponse = networkClient.NetworkSecurityGroups.Delete(securityGroupName);
                Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);
            }
        }

        [Fact]
        [Trait("Feature", "NetworkSecurityGroups")]
        public void PrepareAndAbortMigrationNetworkSecurityGroup()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                var networkClient = TestBase.GetServiceClient<NetworkManagementClient>();

                // setup
                string securityGroupName = TestUtilities.GenerateName();
                string securityGroupLabel = TestUtilities.GenerateName();
                string securityGroupLocation = NetworkTestConstants.WideVNetLocation;

                var nsgCreateParameters = CreateParameters(securityGroupName, securityGroupLabel, securityGroupLocation);
                networkClient.NetworkSecurityGroups.Create(nsgCreateParameters);

                // assert
                NetworkSecurityGroupGetResponse response = networkClient.NetworkSecurityGroups.Get(securityGroupName, null);
                Assert.Equal(securityGroupName, response.Name);
                Assert.Equal(securityGroupLabel, response.Label);
                Assert.Equal(securityGroupLocation, response.Location);

                // Validate migration
                var validateResponse = networkClient.NetworkSecurityGroups.ValidateMigration(securityGroupName);
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                // prepare migration
                var prepareResponse = networkClient.NetworkSecurityGroups.PrepareMigration(securityGroupName);
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                // abort migration
                var abortResponse = networkClient.NetworkSecurityGroups.AbortMigration(securityGroupName);
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                // Delete the nsg
                var deleteResponse = networkClient.NetworkSecurityGroups.Delete(securityGroupName);
                Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);
            }
        }

        private NetworkSecurityGroupCreateParameters CreateParameters(string name, string label, string location)
        {
            return new NetworkSecurityGroupCreateParameters()
            {
                Name = name,
                Label = label,
                Location = location,
            };
        }
    }
}
