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
    using Microsoft.WindowsAzure.Management.Network.Models;
    using Xunit;

    public class DeleteRouteTests
    {
        [Fact]
        [Trait("Feature", "Routes")]
        public void DeleteRouteWhenRouteTableDoesntExist()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Routes.EnsureRouteTableDoesntExist("NonExistantRouteTableName");

                try
                {
                    networkTestClient.Routes.DeleteRoute("NonExistantRouteTableName", "MockRouteName");
                    Assert.True(false, "DeleteRoute should throw a CloudException when the route table doesn't exist.");
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
        public void DeleteRouteWhenRouteDoesntExist()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Routes.EnsureRouteTableIsEmpty("MockRouteTableName");

                try
                {
                    networkTestClient.Routes.DeleteRoute("MockRouteTableName", "MockRouteName");
                    Assert.True(false, "DeleteRoute should throw a CloudException when the route doesn't exist.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("ResourceNotFound", e.Error.Code);
                    Assert.Equal("The Route MockRouteName does not exist.", e.Error.Message);
                    Assert.Null(e.Response);
                }
            }
        }

        [Fact]
        [Trait("Feature", "Routes")]
        public void DeleteRouteWhenRouteExists()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Routes.EnsureRouteIsOnlyRouteInRouteTable("MockRouteTableName", "MockRouteName");

                AzureOperationResponse deleteResponse = networkTestClient.Routes.DeleteRoute("MockRouteTableName", "MockRouteName");
                Assert.NotNull(deleteResponse);
                Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);
                Assert.NotNull(deleteResponse.RequestId);
                Assert.NotEqual(0, deleteResponse.RequestId.Length);

                GetRouteTableResponse getResponse = networkTestClient.Routes.GetRouteTableWithDetails("MockRouteTableName", "full");
                Assert.NotNull(getResponse);
                Assert.NotNull(getResponse.RouteTable);
                Assert.NotNull(getResponse.RouteTable.RouteList);
                Assert.Equal(0, getResponse.RouteTable.RouteList.Count);
            }
        }
    }
}