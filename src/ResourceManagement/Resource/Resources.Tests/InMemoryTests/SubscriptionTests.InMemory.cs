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
using System.Collections.Generic;
using Microsoft.Azure;
using Microsoft.Azure.Management.Resources;
using Xunit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net;
using Microsoft.Azure.Management.Resources.Models;
using System.Runtime.Serialization.Formatters;
using Microsoft.Azure.Subscriptions;

namespace ResourceGroups.Tests
{
    public class InMemorySubscriptionTests
    {
        public SubscriptionClient GetSubscriptionClient(RecordedDelegatingHandler handler)
        {
            var token = new TokenCloudCredentials(Guid.NewGuid().ToString(), "abc123");
            handler.IsPassThrough = false;
            return new SubscriptionClient(token).WithHandler(handler);
        }

        [Fact]
        public void ListSubscriptionWorksWithNextLink()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'value': [
                          {
                        'id':'/subscriptions/38b598fc-e57a-423f-b2e7-dc0ddb631f1f',
                        'subscriptionId': '38b598fc-e57a-423f-b2e7-dc0ddb631f1f',
                        'displayName':'test-release-3',
                        'state': 'Enabled',
                        'subscriptionPolicies': 
                            {
                                'locationPlacementId':'Public_2014-09-01',
                                'quotaId':'MSDN'
                            }  
                          }
                        ],
                    'nextLink': 'https://wa.com/subscriptions/mysubid/resourcegroups/TestRG/deployments/test-release-3/operations?$skiptoken=983fknw'
                    }
                ")
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetSubscriptionClient(handler);

            var result = client.Subscriptions.List();

            response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'value': []
                    }")
            };

            handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            client = GetSubscriptionClient(handler);

            result = client.Subscriptions.ListNext(result.NextLink);

            // Validate body 
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));
            Assert.Equal("https://wa.com/subscriptions/mysubid/resourcegroups/TestRG/deployments/test-release-3/operations?$skiptoken=983fknw", handler.Uri.ToString());

            // Validate response 
            Assert.Equal(null, result.NextLink);
        }

    }
}
