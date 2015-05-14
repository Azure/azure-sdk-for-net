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

    public class CreateRouteTableTests
    {
        [Fact]
        [Trait("Feature", "Routes")]
        public void CreateRouteTableWhenNameIsNull()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                CreateRouteTableParameters parameters = CreateParameters(null, "MockLabel", NetworkTestConstants.WideVNetLocation);

                try
                {
                    networkTestClient.Routes.CreateRouteTable(parameters);
                    Assert.True(false, "CreateRouteTable should have thrown a CloudException when the table name value was null.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.Equal("Route Table name is null or empty.", e.Error.Message);
                    Assert.Equal("Bad Request", e.Response.ReasonPhrase);
                    Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
                }
            }
        }
        [Fact]
        [Trait("Feature", "Routes")]
        public void CreateRouteTableWhenNameIsEmpty()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                CreateRouteTableParameters parameters = CreateParameters("", "MockLabel", NetworkTestConstants.WideVNetLocation);

                try
                {
                    networkTestClient.Routes.CreateRouteTable(parameters);
                    Assert.True(false, "CreateRouteTable should have thrown a CloudException when the table name value was empty.");
                }
                catch (Hyak.Common.CloudException e)
                {
                    Assert.Equal("BadRequest", e.Error.Code);
                    Assert.Equal("Route Table name is null or empty.", e.Error.Message);
                    Assert.Equal("Bad Request", e.Response.ReasonPhrase);
                    Assert.Equal(HttpStatusCode.BadRequest, e.Response.StatusCode);
                }
            }
        }
        [Fact]
        [Trait("Feature", "Routes")]
        public void CreateRouteTableWhenLabelIsNull()
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
            }
        }
        [Fact]
        [Trait("Feature", "Routes")]
        public void CreateRouteTableWhenLabelIsEmpty()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                networkTestClient.Routes.EnsureRouteTableDoesntExist("MockName");

                CreateRouteTableParameters parameters = CreateParameters("MockName", "", NetworkTestConstants.WideVNetLocation);

                AzureOperationResponse createResponse = networkTestClient.Routes.CreateRouteTable(parameters);
                Assert.NotNull(createResponse);
                Assert.NotNull(createResponse.RequestId);
                Assert.NotEqual(0, createResponse.RequestId.Length);
                Assert.Equal(HttpStatusCode.OK, createResponse.StatusCode);
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
