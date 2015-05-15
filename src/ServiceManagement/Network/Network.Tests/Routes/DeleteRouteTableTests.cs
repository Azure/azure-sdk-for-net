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

using Microsoft.Azure;

namespace Network.Tests.Routes
{
    using System.Net;
    using Xunit;

    public class DeleteRouteTableTests
    {
        [Fact]
        [Trait("Feature", "Routes")]
        public void DeleteRouteTableWithNonExistantTableName()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Routes.EnsureRouteTableDoesntExist("NonExistantRouteTableName");

                try
                {
                    networkTestClient.Routes.DeleteRouteTable("NonExistantRouteTableName");
                    Assert.True(false, "DeleteRouteTable should throw a CloudException when the route table name is empty.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("ResourceNotFound", e.Error.Code);
                    Assert.Equal("The Route Table NonExistantRouteTableName does not exist.", e.Error.Message);
                    Assert.Null(e.Response);
                }
            }
        }

        [Fact]
        [Trait("Feature", "Routes")]
        public void DeleteRouteTable()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Routes.EnsureRouteTableExists("MockName");

                AzureOperationResponse deleteResponse = networkTestClient.Routes.DeleteRouteTable("MockName");
                Assert.NotNull(deleteResponse);
                Assert.NotNull(deleteResponse.RequestId);
                Assert.NotEqual(0, deleteResponse.RequestId.Length);
                Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);
            }
        }
    }
}
