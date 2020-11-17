// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest;
using Xunit;

namespace ResourceGroups.Tests
{
    public class InMemoryProviderTests
    {
        public ResourceManagementClient GetResourceManagementClient(RecordedDelegatingHandler handler)
        {
            var subscriptionId = Guid.NewGuid().ToString();
            var token = new TokenCredentials(subscriptionId, "abc123");
            handler.IsPassThrough = false;
            var client = new ResourceManagementClient(token, handler);
            client.SubscriptionId = subscriptionId;
            return client;
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
                       ], 
                       'aliases': [{
                           'name': 'Microsoft.Compute/virtualMachines/sku.name',
			               'paths': [{
                               'path': 'properties.hardwareProfile.vmSize',
                               'apiVersions': [
                                   '2015-05-01-preview',
                                   '2015-06-15',
                                   '2016-03-30',
                                   '2016-04-30-preview'
                               ]
                           }]
                       },
                       {
                           'name': 'Microsoft.Compute/virtualMachines/imagePublisher',
                           'paths': [{
                               'path': 'properties.storageProfile.imageReference.publisher',
                               'apiVersions': [
                                   '2015-05-01-preview',
                                   '2015-06-15',
                                   '2016-03-30',
                                   '2016-04-30-preview'
                               ]
                           }]
                       }]
                   },
                   {
                       'resourceType': 'sites/pages',
                       'locations': [
                         'West US'
                       ]
                   }]
                }")
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);

            var result = client.Providers.Get("Microsoft.Websites", expand: "resourceTypes/aliases");

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal("Microsoft.Websites", result.NamespaceProperty);
            Assert.Equal("Registered", result.RegistrationState);
            Assert.Equal(2, result.ResourceTypes.Count);
            Assert.Equal("sites", result.ResourceTypes[0].ResourceType);
            Assert.Equal(1, result.ResourceTypes[0].Locations.Count);
            Assert.Equal("Central US", result.ResourceTypes[0].Locations[0]);
            Assert.Equal(2, result.ResourceTypes[0].Aliases.Count);
            Assert.Equal("Microsoft.Compute/virtualMachines/sku.name", result.ResourceTypes[0].Aliases[0].Name);
            Assert.Equal(1, result.ResourceTypes[0].Aliases[0].Paths.Count);
            Assert.Equal("properties.hardwareProfile.vmSize", result.ResourceTypes[0].Aliases[0].Paths[0].Path);
        }

        [Fact]
        public void ProviderGetThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetResourceManagementClient(handler);

            Assert.Throws<Microsoft.Rest.ValidationException>(() => client.Providers.Get(null));
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
            Assert.Single(result);
            Assert.Equal("Microsoft.Websites", result.First().NamespaceProperty);
            Assert.Equal("Registered", result.First().RegistrationState);
            Assert.Equal(2, result.First().ResourceTypes.Count);
            Assert.Equal("sites", result.First().ResourceTypes[0].ResourceType);
            Assert.Equal(1, result.First().ResourceTypes[0].Locations.Count);
            Assert.Equal("Central US", result.First().ResourceTypes[0].Locations[0]);
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
        }

        [Fact]
        public void ProviderRegisterThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetResourceManagementClient(handler);

            Assert.Throws<Microsoft.Rest.ValidationException>(() => client.Providers.Register(null));
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
        }

        [Fact]
        public void ProviderUnregisterThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetResourceManagementClient(handler);

            Assert.Throws<Microsoft.Rest.ValidationException>(() => client.Providers.Unregister(null));
        }

        [Fact]
        public void ProviderManangementGroupRegisterValidate()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetResourceManagementClient(handler);

            var groupId = "TestGroup1Child1Child1";

            client.Providers.RegisterAtManagementGroupScope("Microsoft.Websites", groupId);

            // Validate headers
            Assert.Equal(HttpMethod.Post, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));
        }
    }
}
