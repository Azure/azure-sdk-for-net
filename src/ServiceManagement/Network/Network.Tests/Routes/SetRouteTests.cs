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

    public class SetRouteTests
    {
        [Fact]
        [Trait("Feature", "Routes")]
        public void SetRouteWithNullRouteNameInParameters()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                try
                {
                    networkTestClient.Routes.SetRoute("MockRouteTableName", "MockRouteName", CreateParameters(null, "MockAddressPrefix", "MockNextHopType"));
                    Assert.True(false, "SetRoute should have thrown a CloudException when the parameters object's route name was null.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.Equal("Route name  is invalid.", e.Error.Message);
                    Assert.NotNull(e.Response);
                    Assert.Equal("Bad Request", e.Response.ReasonPhrase);
                    Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
                }
            }
        }
        [Fact]
        [Trait("Feature", "Routes")]
        public void SetRouteWithEmptyRouteNameInParameters()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                try
                {
                    networkTestClient.Routes.SetRoute("MockRouteTableName", "MockRouteName", CreateParameters("", "MockAddressPrefix", "MockNextHopType"));
                    Assert.True(false, "SetRoute should have thrown a CloudException when the parameters object's route name was empty.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.Equal("Route name  is invalid.", e.Error.Message);
                    Assert.NotNull(e.Response);
                    Assert.Equal("Bad Request", e.Response.ReasonPhrase);
                    Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
                }
            }
        }

        [Fact]
        [Trait("Feature", "Routes")]
        public void SetRouteWithNullAddressPrefixInParameters()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                try
                {
                    networkTestClient.Routes.SetRoute("MockRouteTableName", "MockRouteName", CreateParameters("MockRouteName", null, "VPNGateway"));
                    Assert.True(false, "SetRoute should have thrown a CloudException when the parameters object's address prefix was null.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.Equal("The address prefix is a mandatory parameter, but it is not specified.", e.Error.Message);
                    Assert.NotNull(e.Response);
                    Assert.Equal("Bad Request", e.Response.ReasonPhrase);
                    Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
                }
            }
        }
        [Fact]
        [Trait("Feature", "Routes")]
        public void SetRouteWithEmptyAddressPrefixInParameters()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                SetRouteParameters parameters = CreateParameters("MockRouteName", "", "VPNGateway");
                try
                {
                    networkTestClient.Routes.SetRoute("MockRouteTableName", "MockRouteName", parameters);
                    Assert.True(false, "SetRoute should have thrown a CloudException when the parameters object's address prefix was empty.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.Equal("The address prefix is a mandatory parameter, but it is not specified.", e.Error.Message);
                    Assert.NotNull(e.Response);
                    Assert.Equal("Bad Request", e.Response.ReasonPhrase);
                    Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
                }
            }
        }
        [Fact]
        [Trait("Feature", "Routes")]
        public void SetRouteWithInvalidAddressPrefixInParameters()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                SetRouteParameters parameters = CreateParameters("MockRouteName", "MockAddressPrefix", "VPNGateway");

                try
                {
                    networkTestClient.Routes.SetRoute("MockRouteTableName", "MockRouteName", parameters);
                    Assert.True(false, "SetRoute should have thrown a CloudException when the parameters object's address prefix was empty.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.Equal("The address prefix MockAddressPrefix is invalid. Please use valid CIDR notation.", e.Error.Message);
                    Assert.NotNull(e.Response);
                    Assert.Equal("Bad Request", e.Response.ReasonPhrase);
                    Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
                }
            }
        }

        [Fact]
        [Trait("Feature", "Routes")]
        public void SetRouteWithNullNextHopInParameters()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                SetRouteParameters parameters = CreateParameters("MockRouteName", "0.0.0.0/0", (NextHop)null);

                try
                {
                    networkTestClient.Routes.SetRoute("MockRouteTableName", "MockRouteName", parameters);
                    Assert.True(false, "SetRoute should have thrown a CloudException when the parameters object's next hop object was null.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.Equal("The next hop is a mandatory parameter, but it is not specified.", e.Error.Message);
                    Assert.NotNull(e.Response);
                    Assert.Equal("Bad Request", e.Response.ReasonPhrase);
                    Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
                }
            }
        }
        [Fact]
        [Trait("Feature", "Routes")]
        public void SetRouteWithNullNextHopTypeInParameters()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                SetRouteParameters parameters = CreateParameters("MockRouteName", "0.0.0.0/0", (string)null);

                try
                {
                    networkTestClient.Routes.SetRoute("MockRouteTableName", "MockRouteName", parameters);
                    Assert.True(false, "SetRoute should have thrown a CloudException when the parameters object's next hop type was null.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.Equal("The next hop type is invalid. Please use next hop types VPNGateway, VirtualAppliance, Internet, VNETLocal, Null.", e.Error.Message);
                    Assert.NotNull(e.Response);
                    Assert.Equal("Bad Request", e.Response.ReasonPhrase);
                    Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
                }
            }
        }
        [Fact]
        [Trait("Feature", "Routes")]
        public void SetRouteWithEmptyNextHopTypeInParameters()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                SetRouteParameters parameters = CreateParameters("MockRouteName", "0.0.0.0/0", "");

                try
                {
                    networkTestClient.Routes.SetRoute("MockRouteTableName", "MockRouteName", parameters);
                    Assert.True(false, "SetRoute should have thrown a CloudException when the parameters object's next hop type was empty.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.Equal("The next hop type is invalid. Please use next hop types VPNGateway, VirtualAppliance, Internet, VNETLocal, Null.", e.Error.Message);
                    Assert.NotNull(e.Response);
                    Assert.Equal("Bad Request", e.Response.ReasonPhrase);
                    Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
                }
            }
        }

        [Fact]
        [Trait("Feature", "Routes")]
        public void SetRouteWhenRouteNamesDontMatch()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                SetRouteParameters parameters = CreateParameters("MockRouteNameB", "MockAddressPrefix", "MockNextHopType");

                try
                {
                    networkTestClient.Routes.SetRoute("MockRouteTableName", "MockRouteNameA", parameters);
                    Assert.True(false, "SetRoute should have thrown a CloudException when the route name does not match the parameters object's route name.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.Equal("Route name MockRouteNameB is invalid.", e.Error.Message);
                    Assert.NotNull(e.Response);
                    Assert.Equal("Bad Request", e.Response.ReasonPhrase);
                    Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
                }
            }
        }

        [Fact]
        [Trait("Feature", "Routes")]
        public void SetRouteWhenRouteTableDoesntExist()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Routes.EnsureRouteTableDoesntExist("MockRouteTableName");

                SetRouteParameters parameters = CreateParameters("MockRouteTable", "0.0.0.0/0", "VPNGateway");

                try
                {
                    networkTestClient.Routes.SetRoute("MockRouteTableName", "MockRouteTable", parameters);
                    Assert.True(false, "SetRoute should have thrown a CloudException when the route table doesn't exist.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("ResourceNotFound", e.Error.Code);
                    Assert.Equal("The Route Table MockRouteTableName does not exist.", e.Error.Message);
                    Assert.Null(e.Response);
                }
            }
        }
        [Fact]
        [Trait("Feature", "Routes")]
        public void SetRoute()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Routes.EnsureRouteTableIsEmpty("MockRouteTableName");

                SetRouteParameters parameters = CreateParameters("MockRouteName", "0.0.0.0/0", "VPNGateway");

                AzureOperationResponse setResponse = networkTestClient.Routes.SetRoute("MockRouteTableName", "MockRouteName", parameters);
                Assert.NotNull(setResponse);
                Assert.Equal(HttpStatusCode.OK, setResponse.StatusCode);
                Assert.NotNull(setResponse.RequestId);
                Assert.NotEqual(0, setResponse.RequestId.Length);
            }
        }

        private SetRouteParameters CreateParameters(string routeName, string addressPrefix, string nextHopType)
        {
            NextHop nextHop = new NextHop()
            {
                Type = nextHopType,
            };
            return CreateParameters(routeName, addressPrefix, nextHop);
        }

        private SetRouteParameters CreateParameters(string routeName, string addressPrefix, NextHop nextHop)
        {
            return new SetRouteParameters()
            {
                Name = routeName,
                AddressPrefix = addressPrefix,
                NextHop = nextHop,
            };
        }
    }
}
