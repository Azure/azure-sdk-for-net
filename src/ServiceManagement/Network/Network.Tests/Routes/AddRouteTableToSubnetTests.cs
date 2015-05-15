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

    public class AddRouteTableToSubnetTests
    {
        [Fact]
        [Trait("Feature", "Routes")]
        [Trait("Operation", "AddRouteTableToSubnet")]
        public void AddRouteTableToSubnetWithNonExistantVNetName()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.EnsureNoNetworkConfigurationExists();
                networkTestClient.Routes.EnsureRouteTableExists("MockRouteTableName");

                AddRouteTableToSubnetParameters parameters = new AddRouteTableToSubnetParameters()
                {
                    RouteTableName = "MockRouteTableName"
                };

                try
                {
                    networkTestClient.Routes.AddRouteTableToSubnet(NetworkTestConstants.VirtualNetworkSiteName, NetworkTestConstants.WideVNetSubnetName, parameters);
                    Assert.True(false, "AddRouteTableToSubnet should have thrown a CloudException when the parameters object's route table name was empty.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("ResourceNotFound", e.Error.Code);
                    Assert.Equal("The virtual network virtualNetworkSiteName does not exist.", e.Error.Message);
                    Assert.Null(e.Response);
                }
            }
        }

        [Fact]
        [Trait("Feature", "Routes")]
        [Trait("Operation", "AddRouteTableToSubnet")]
        public void AddRouteTableToSubnetWithNonExistantSubnetName()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.EnsureWideVNetNetworkConfigurationExists();
                networkTestClient.Routes.EnsureRouteTableExists("MockRouteTableName");

                AddRouteTableToSubnetParameters parameters = new AddRouteTableToSubnetParameters()
                {
                    RouteTableName = "MockRouteTableName"
                };

                try
                {
                    networkTestClient.Routes.AddRouteTableToSubnet(NetworkTestConstants.VirtualNetworkSiteName, "NonExistantSubnetName", parameters);
                    Assert.True(false, "AddRouteTableToSubnet should have thrown a CloudException when the subnetName did not exist in the current vnet.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("ResourceNotFound", e.Error.Code);
                    Assert.Equal("Subnet name NonExistantSubnetName was not found in Virtual Network virtualNetworkSiteName.", e.Error.Message);
                    Assert.Null(e.Response);
                }
            }
        }

        [Fact]
        [Trait("Feature", "Routes")]
        [Trait("Operation", "AddRouteTableToSubnet")]
        public void AddRouteTableToSubnetWithNullRouteTableName()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                AddRouteTableToSubnetParameters parameters = new AddRouteTableToSubnetParameters()
                {
                    RouteTableName = null
                };

                try
                {
                    networkTestClient.Routes.AddRouteTableToSubnet(NetworkTestConstants.VirtualNetworkSiteName, NetworkTestConstants.WideVNetSubnetName, parameters);
                    Assert.True(false, "AddRouteTableToSubnet should have thrown a CloudException when the parameters object's route table name was null.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.Equal("Route Table name is null or empty.", e.Error.Message);
                    Assert.NotNull(e.Response);
                    Assert.Equal("Bad Request", e.Response.ReasonPhrase);
                    Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
                }
            }
        }
        [Fact]
        [Trait("Feature", "Routes")]
        [Trait("Operation", "AddRouteTableToSubnet")]
        public void AddRouteTableToSubnetWithEmptyRouteTableName()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                AddRouteTableToSubnetParameters parameters = new AddRouteTableToSubnetParameters()
                {
                    RouteTableName = ""
                };

                try
                {
                    networkTestClient.Routes.AddRouteTableToSubnet(NetworkTestConstants.VirtualNetworkSiteName, NetworkTestConstants.WideVNetSubnetName, parameters);
                    Assert.True(false, "AddRouteTableToSubnet should have thrown a CloudException when the parameters object's route table name was empty.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.Equal("Route Table name is null or empty.", e.Error.Message);
                    Assert.NotNull(e.Response);
                    Assert.Equal("Bad Request", e.Response.ReasonPhrase);
                    Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
                }
            }
        }
        [Fact]
        [Trait("Feature", "Routes")]
        [Trait("Operation", "AddRouteTableToSubnet")]
        public void AddRouteTableToSubnetWithNonExistantRouteTableName()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.EnsureWideVNetNetworkConfigurationExists();
                networkTestClient.Routes.EnsureRouteTableDoesntExist("NonExistantRouteTableName");

                AddRouteTableToSubnetParameters parameters = new AddRouteTableToSubnetParameters()
                {
                    RouteTableName = "NonExistantRouteTableName"
                };

                try
                {
                    networkTestClient.Routes.AddRouteTableToSubnet(NetworkTestConstants.VirtualNetworkSiteName, NetworkTestConstants.WideVNetSubnetName, parameters);
                    Assert.True(false, "AddRouteTableToSubnet should have thrown a CloudException when the parameters object's route table name didn't exist.");
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
        [Trait("Operation", "AddRouteTableToSubnet")]
        public void AddRouteTableToSubnet()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.EnsureWideVNetNetworkConfigurationExists();
                networkTestClient.Routes.EnsureRouteTableExists("MockRouteTableName");

                AddRouteTableToSubnetParameters parameters = new AddRouteTableToSubnetParameters()
                {
                    RouteTableName = "MockRouteTableName"
                };

                networkTestClient.Routes.AddRouteTableToSubnet(NetworkTestConstants.VirtualNetworkSiteName, NetworkTestConstants.WideVNetSubnetName, parameters);

                GetRouteTableForSubnetResponse response = networkTestClient.Routes.GetRouteTableForSubnet(NetworkTestConstants.VirtualNetworkSiteName, NetworkTestConstants.WideVNetSubnetName);
                Assert.NotNull(response);
                Assert.Equal("MockRouteTableName", response.RouteTableName);
            }
        }
    }
}
