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
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest;
using Newtonsoft.Json.Linq;

using Xunit;
using Microsoft.Rest.Azure.OData;

namespace ResourceGroups.Tests
{
    public class InMemoryResourceLinkTests
    {
        public ManagementLinkClient GetManagementLinkClient(RecordedDelegatingHandler handler)
        {
            var subscriptionId = Guid.NewGuid().ToString();
            var token = new TokenCredentials(subscriptionId, "abc123");
            handler.IsPassThrough = false;
            var client = new ManagementLinkClient(token, handler);
            client.SubscriptionId = subscriptionId;
            return client;
        }

        [Fact]
        public void ResourceLinkCRUD()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'id': '/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm/providers/Microsoft.Resources/links/myLink',
                    'name': 'myLink',
                    'properties': {
                        'sourceId': '/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm',
                        'targetId': '/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm2',
                        'notes': 'myLinkNotes'
                      }
                }")
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetManagementLinkClient(handler);

            var result = client.ResourceLinks.CreateOrUpdateById(
                linkId: "/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm/providers/Microsoft.Resources/links/myLink",
                parameters: new ResourceLink
                {
                    Properties = new ResourceLinkProperties
                    {
                        TargetId = "/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm2",
                        Notes = "myLinkNotes"
                    }
                });

            JObject json = JObject.Parse(handler.Request);

            // Validate headers
            Assert.Equal("application/json; charset=utf-8", handler.ContentHeaders.GetValues("Content-Type").First());
            Assert.Equal(HttpMethod.Put, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate payload
            Assert.Equal("/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm2", json["properties"]["targetId"].Value<string>());
            Assert.Equal("myLinkNotes", json["properties"]["notes"].Value<string>());

            // Validate response
            Assert.Equal("/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm/providers/Microsoft.Resources/links/myLink", result.Id);
            Assert.Equal("/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm", result.Properties.SourceId);
            Assert.Equal("/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm2", result.Properties.TargetId);
            Assert.Equal("myLinkNotes", result.Properties.Notes);
        }
    }
}
