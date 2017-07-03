// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System.Text;
using Xunit;
using Fluent.Tests.Common;
using Azure.Tests;
using Microsoft.Azure.Management.ResourceManager.Fluent;

namespace Fluent.Tests.Network
{
    public class RouteTable
    {
        [Fact]
        public void CreateUpdate()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string testId = SdkContext.RandomResourceName("", 9);
                string resourceGroupName = "rg" + testId;
                string routeTableName = "rt" + testId;
                string networkName = "net" + testId;
                Region region = Region.USEast;
                string[] routeNames = new string[] { "route1", "route2", "route3" };

                #region Create
                var manager = TestHelper.CreateNetworkManager();
                var resource = manager.RouteTables
                    .Define(routeTableName)
                    .WithRegion(region)
                    .WithNewResourceGroup(resourceGroupName)
                    .DefineRoute(routeNames[0])
                        .WithDestinationAddressPrefix("10.0.0.0/24")
                        .WithNextHopToVirtualAppliance("10.1.0.4")
                        .Attach()
                    .DefineRoute(routeNames[1])
                        .WithDestinationAddressPrefix("10.0.1.0/24")
                        .WithNextHopToVirtualAppliance("10.1.0.5")
                        .Attach()
                    .Create();

                Assert.NotNull(resource);
                Assert.NotEmpty(resource.Routes);
                Assert.Equal(2, resource.Routes.Count);

                // Verify routes
                IRoute route;
                Assert.True(resource.Routes.TryGetValue(routeNames[0], out route));
                Assert.Equal(routeNames[0], route.Name);
                Assert.Equal("10.0.0.0/24", route.DestinationAddressPrefix);
                Assert.Equal(RouteNextHopType.VirtualAppliance, route.NextHopType);
                Assert.Equal("10.1.0.4", route.NextHopIPAddress);

                Assert.True(resource.Routes.TryGetValue(routeNames[1], out route));
                Assert.Equal(routeNames[1], route.Name);
                Assert.Equal("10.0.1.0/24", route.DestinationAddressPrefix);
                Assert.Equal(RouteNextHopType.VirtualAppliance, route.NextHopType);
                Assert.Equal("10.1.0.5", route.NextHopIPAddress);

                // Create a subnet that references the route table
                manager.Networks.Define(networkName)
                    .WithRegion(region)
                    .WithExistingResourceGroup(resourceGroupName)
                    .WithAddressSpace("10.0.0.0/22")
                    .DefineSubnet("subnet1")
                        .WithAddressPrefix("10.0.0.0/22")
                        .WithExistingRouteTable(resource)
                        .Attach()
                    .Create();

                var subnets = resource.Refresh().ListAssociatedSubnets();
                Assert.Equal(1, subnets.Count);
                Assert.Equal(resource.Id, subnets[0].RouteTableId);

                #endregion

                #region Read
                resource = manager.RouteTables.GetByResourceGroup(resourceGroupName, routeTableName);
                Assert.NotNull(resource);
                #endregion

                #region Update
                // Verify changing and adding routes
                resource = resource.Update()
                    .UpdateRoute(routeNames[0])
                        .WithDestinationAddressPrefix("10.0.0.0/25")
                        .WithNextHopToVirtualAppliance("10.1.0.6")
                        .Parent()
                    .DefineRoute(routeNames[2])
                        .WithDestinationAddressPrefix("10.0.2.0/24")
                        .WithNextHopToVirtualAppliance("10.1.0.7")
                        .Attach()
                    .Apply();

                Assert.NotEmpty(resource.Routes);
                Assert.Equal(3, resource.Routes.Count);
                Assert.True(resource.Routes.TryGetValue(routeNames[0], out route));
                Assert.Equal("10.0.0.0/25", route.DestinationAddressPrefix);
                Assert.Equal("10.1.0.6", route.NextHopIPAddress);

                Assert.True(resource.Routes.TryGetValue(routeNames[2], out route));
                Assert.Equal("10.0.2.0/24", route.DestinationAddressPrefix);
                Assert.Equal("10.1.0.7", route.NextHopIPAddress);

                // Verify removing last route
                resource = resource.Update()
                    .WithoutRoute(routeNames[0])
                    .WithoutRoute(routeNames[1])
                    .WithoutRoute(routeNames[2])
                    .WithTag("tag1", "value1")
                    .WithTag("tag2", "value2")
                    .Apply();
                Assert.True(resource.Tags.ContainsKey("tag1"));
                Assert.Empty(resource.Routes);
                #endregion

                #region Delete
                manager.ResourceManager.ResourceGroups.DeleteByName(resource.ResourceGroupName);
                #endregion
            }
        }

        public void Print(IRouteTable resource)
        {
            var info = new StringBuilder();
            info.Append("Route Table: ").Append(resource.Id)
                    .Append("Name: ").Append(resource.Name)
                    .Append("\n\tResource group: ").Append(resource.ResourceGroupName)
                    .Append("\n\tRegion: ").Append(resource.Region)
                   .Append("\n\tTags: ").Append(resource.Tags);

            // Output routes
            foreach (var route in resource.Routes.Values)
            {
                info.Append("\n\tRoute: ").Append(route.Name)
                    .Append("\n\t\tDestination address prefix: ").Append(route.DestinationAddressPrefix)
                    .Append("\n\t\tNext hop IP address: ").Append(route.NextHopIPAddress)
                    .Append("\n\t\tNext hop type: ").Append(route.NextHopType);
            }

            TestHelper.WriteLine(info.ToString());
        }
    }
}
