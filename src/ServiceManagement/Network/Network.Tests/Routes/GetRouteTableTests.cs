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
    using Microsoft.WindowsAzure.Management.Network.Models;
    using Xunit;

    public class GetRouteTableTests
    {
        [Fact]
        [Trait("Feature", "Routes")]
        public void GetRouteTableWithNonExistantTableName()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Routes.EnsureRouteTableDoesntExist("NonExistantRouteTableName");

                try
                {
                    networkTestClient.Routes.GetRouteTable("NonExistantRouteTableName");
                    Assert.True(false, "GetRouteTable should throw a CloudException when the route table name is empty.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("ResourceNotFound", e.Error.Code);
                    Assert.Equal("The Route Table NonExistantRouteTableName does not exist.", e.Error.Message);
                    Assert.Equal("Not Found", e.Response.ReasonPhrase);
                    Assert.Equal(HttpStatusCode.NotFound, e.Response.StatusCode);
                }
            }
        }

        [Fact]
        [Trait("Feature", "Routes")]
        public void GetRouteTable()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Routes.EnsureRouteTableExists("MockName");

                GetRouteTableResponse getResponse = networkTestClient.Routes.GetRouteTable("MockName");
                Assert.NotNull(getResponse);

                RouteTable routeTable = getResponse.RouteTable;
                Assert.NotNull(routeTable);
                Assert.Equal("MockName", routeTable.Name);
                Assert.Equal("MockLabel", routeTable.Label);
                Assert.Equal(NetworkTestConstants.WideVNetLocation, routeTable.Location);
                Assert.Equal(RouteTableState.Created, routeTable.RouteTableState);
            }
        }
    }
}
