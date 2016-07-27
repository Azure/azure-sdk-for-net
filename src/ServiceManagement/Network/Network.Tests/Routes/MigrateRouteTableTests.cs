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

namespace Network.Tests.Routes
{
    using System.Net;
    using Microsoft.Azure;
    using Microsoft.WindowsAzure.Management.Network.Models;
    using Xunit;

    public class MigrateRouteTableTests
    {
        [Fact]
        [Trait("Feature", "Routes")]
        public void ValdiateMigrationRouteTable()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Routes.EnsureRouteTableDoesntExist("MockName");

                CreateRouteTableParameters parameters = CreateParameters("MockName", null, NetworkTestConstants.WideVNetLocation);
                
                AzureOperationResponse createResponse = networkTestClient.Routes.CreateRouteTable(parameters);
                Assert.NotNull(createResponse);
                Assert.NotNull(createResponse.RequestId);
                Assert.NotEqual(0, createResponse.RequestId.Length);
                Assert.Equal(HttpStatusCode.OK, createResponse.StatusCode);

                // Test Validate migration call
                var response = networkTestClient.ValidateRouteTableMigration("MockName");
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                Assert.NotNull(response.ValidationMessages);
                Assert.Equal(0, response.ValidationMessages.Count);
            }
        }

        [Fact]
        [Trait("Feature", "Routes")]
        public void PrepareAndAbortMigrationRouteTable()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Routes.EnsureRouteTableDoesntExist("MockName");

                CreateRouteTableParameters parameters = CreateParameters("MockName", null, NetworkTestConstants.WideVNetLocation);

                AzureOperationResponse createResponse = networkTestClient.Routes.CreateRouteTable(parameters);
                Assert.NotNull(createResponse);
                Assert.NotNull(createResponse.RequestId);
                Assert.NotEqual(0, createResponse.RequestId.Length);
                Assert.Equal(HttpStatusCode.OK, createResponse.StatusCode);

                // Test Validate migration call
                var response = networkTestClient.ValidateRouteTableMigration("MockName");
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                Assert.NotNull(response.ValidationMessages);
                Assert.Equal(0, response.ValidationMessages.Count);

                // Prepare 
                OperationStatusResponse prepareVnetMigration = networkTestClient.PrepareRouteTableMigration("MockName");
                Assert.Equal(OperationStatus.Succeeded, prepareVnetMigration.Status);

                // Abort
                OperationStatusResponse abortVnetMigration = networkTestClient.AbortRouteTableMigration("MockName");
                Assert.Equal(OperationStatus.Succeeded, abortVnetMigration.Status);
            }
        }

        private CreateRouteTableParameters CreateParameters(string name, string label, string location)
        {
            return new CreateRouteTableParameters()
            {
                Name = name,
                Label = label,
                Location = location,
            };
        }
    }
}
