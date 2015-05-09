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
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure;
using Microsoft.Azure.Management.Resources;
using Xunit;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net;
using Microsoft.Azure.Management.Resources.Models;

namespace ResourceGroups.Tests
{
    public class InMemoryProviderTests
    {
        public ResourceManagementClient GetResourceManagementClient(RecordedDelegatingHandler handler)
        {
            var token = new TokenCloudCredentials(Guid.NewGuid().ToString(), "abc123");
            handler.IsPassThrough = false;
            return new ResourceManagementClient(token).WithHandler(handler);
        }
        
        [Fact]
        public void ProviderGetValidateMessage()
        { 
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                   'namespace': 'Microsoft.Websites',
                   'registrationState': 'Registered',
                   'resourceTypes': [
                    {
                       'resourceType': 'sites',
                       'locations': [
                         'Central US'
                       ]
                     },
                     {
                       'resourceType': 'sites/pages',
                       'locations': [
                         'West US'
                       ]
                     }
                   ]   
                }")
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);

            var result = client.Providers.Get("Microsoft.Websites");

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal("Microsoft.Websites", result.Provider.Namespace);
            Assert.Equal("Registered", result.Provider.RegistrationState);
            Assert.Equal(2, result.Provider.ResourceTypes.Count);
            Assert.Equal("sites", result.Provider.ResourceTypes[0].Name);
            Assert.Equal(1, result.Provider.ResourceTypes[0].Locations.Count);
            Assert.Equal("Central US", result.Provider.ResourceTypes[0].Locations[0]);
        }

        [Fact]
        public void ProviderGetThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetResourceManagementClient(handler);

            Assert.Throws<ArgumentNullException>(() => client.Providers.Get(null));
        }

        [Fact]
        public void ProviderListValidateMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{ 'value' : [
                    {
                   'namespace': 'Microsoft.Websites',
                   'registrationState': 'Registered',
                   'resourceTypes': [
                    {
                       'resourceType': 'sites',
                       'locations': [
                         'Central US'
                       ]
                     },
                     {
                       'resourceType': 'sites/pages',
                       'locations': [
                         'West US'
                       ]
                     }
                   ]   
                }], 
                'nextLink': 'https://wa.com/subscriptions/subId/resources?$skiptoken=983fknw'}")
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);

            var result = client.Providers.List(null);

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal(1, result.Providers.Count());
            Assert.Equal("Microsoft.Websites", result.Providers[0].Namespace);
            Assert.Equal("Registered", result.Providers[0].RegistrationState);
            Assert.Equal(2, result.Providers[0].ResourceTypes.Count);
            Assert.Equal("sites", result.Providers[0].ResourceTypes[0].Name);
            Assert.Equal(1, result.Providers[0].ResourceTypes[0].Locations.Count);
            Assert.Equal("Central US", result.Providers[0].ResourceTypes[0].Locations[0]);
        }

        [Fact]
        public void ProviderRegisterValidate()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetResourceManagementClient(handler);

            var result = client.Providers.Register("Microsoft.Websites");

            // Validate headers
            Assert.Equal(HttpMethod.Post, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public void ProviderRegisterThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetResourceManagementClient(handler);

            Assert.Throws<ArgumentNullException>(() => client.Providers.Register(null));
        }

        [Fact]
        public void ProviderUnregisterValidate()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetResourceManagementClient(handler);

            var result = client.Providers.Unregister("Microsoft.Websites");

            // Validate headers
            Assert.Equal(HttpMethod.Post, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public void ProviderUnregisterThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetResourceManagementClient(handler);

            Assert.Throws<ArgumentNullException>(() => client.Providers.Unregister(null));
        }
    }
}
