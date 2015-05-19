//
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

using System;
using System.Linq;
using System.Net;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Management.WebSites;
using Microsoft.WindowsAzure.Management.WebSites.Models;
using Microsoft.Azure.Test;
using Xunit;
using System.Net.Http;

namespace WebSites.Tests.ScenarioTests
{
    public class HybridConnectionScenarioTests : TestBase
    {
        public WebSiteManagementClient GetWebSiteManagementClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = false;
            var token = new TokenCloudCredentials(Guid.NewGuid().ToString(), "abc123");
            var client = new WebSiteManagementClient(token).WithHandler(handler);
            client = client.WithHandler(handler);
            return client;
        }

        [Fact]
        public void GetHybridConnectionsTest()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(HttpPayload.GetHybridConnection)
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetWebSiteManagementClient(handler);

            var result = client.WebSites.GetHybridConnection("space1", "site1", "testhybrid1");

            Assert.True(result.HybridConnection.EntityName == "testhybrid1");
            Assert.True(result.HybridConnection.Hostname == "myhost1");
            Assert.Equal(result.HybridConnection.Port, 80);
        }

        [Fact]
        public void ListHybridConnectionsTest()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(HttpPayload.ListHybridConnections)
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetWebSiteManagementClient(handler);

            var result = client.WebSites.ListHybridConnections("space1", "site1");

            // Verify that we have two connections, one called "testhybrid1" and another called "testhybrid2"
            foreach (var connection in result.HybridConnections)
            {
                Assert.True(connection.EntityName == "testhybrid1" || connection.EntityName == "testhybrid2");
                Assert.True(connection.Hostname == "myhost1" || connection.Hostname == "myhost2");
                Assert.Equal(connection.Port, 80);
            }
        }
    }
}
