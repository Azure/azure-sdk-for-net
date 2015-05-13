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
    using Microsoft.WindowsAzure.Management.Network.Models;
    using Xunit;

    public class ListRouteTablesTests
    {
        [Fact]
        [Trait("Feature", "Routes")]
        public void ListRouteTablesWhenNoTablesExist()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Routes.EnsureNoRouteTablesExist();

                ListRouteTablesResponse listResponse = networkTestClient.Routes.ListRouteTables();
                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.RouteTables);
                Assert.Equal(0, listResponse.RouteTables.Count);
            }
        }

        [Fact]
        [Trait("Feature", "Routes")]
        public void ListRouteTablesWhenOneTableExists()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Routes.EnsureRouteTableIsOnlyRouteTableInSubscription("MockRouteTableA");

                ListRouteTablesResponse listResponse = networkTestClient.Routes.ListRouteTables();
                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.RouteTables);
                Assert.Equal(1, listResponse.RouteTables.Count);

                RouteTable mockRouteTableA = listResponse.RouteTables[0];
                Assert.Equal("MockRouteTableA", mockRouteTableA.Name);
                Assert.Equal("MockLabel", mockRouteTableA.Label);
                Assert.Equal(NetworkTestConstants.WideVNetLocation, mockRouteTableA.Location);
                Assert.Equal(RouteTableState.Created, mockRouteTableA.RouteTableState);
            }
        }

        [Fact]
        [Trait("Feature", "Routes")]
        public void ListRouteTablesWhenTwoTablesExist()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Routes.EnsureNoRouteTablesExist();
                networkTestClient.Routes.EnsureRouteTableExists("MockRouteTableA");
                networkTestClient.Routes.EnsureRouteTableExists("MockRouteTableB");

                ListRouteTablesResponse listResponse = networkTestClient.Routes.ListRouteTables();
                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.RouteTables);
                Assert.Equal(2, listResponse.RouteTables.Count);

                RouteTable mockRouteTableA = listResponse.RouteTables[0];
                Assert.Equal("MockRouteTableA", mockRouteTableA.Name);
                Assert.Equal("MockLabel", mockRouteTableA.Label);
                Assert.Equal(NetworkTestConstants.WideVNetLocation, mockRouteTableA.Location);
                Assert.Equal(RouteTableState.Created, mockRouteTableA.RouteTableState);

                RouteTable mockRouteTableB = listResponse.RouteTables[1];
                Assert.Equal("MockRouteTableB", mockRouteTableB.Name);
                Assert.Equal("MockLabel", mockRouteTableB.Label);
                Assert.Equal(NetworkTestConstants.WideVNetLocation, mockRouteTableB.Location);
                Assert.Equal(RouteTableState.Created, mockRouteTableB.RouteTableState);
            }
        }
    }
}
