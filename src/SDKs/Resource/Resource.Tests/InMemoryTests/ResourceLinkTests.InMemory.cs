// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
            var response = new HttpResponseMessage(HttpStatusCode.Created)
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

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.Created };
            var client = GetManagementLinkClient(handler);

            var result = client.ResourceLinks.CreateOrUpdate(
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
            Assert.Equal("myLink", result.Name);

            //Get resource link and validate properties

            var getResponse = new HttpResponseMessage(HttpStatusCode.OK)
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

            var getHandler = new RecordedDelegatingHandler(getResponse) { StatusCodeToReturn = HttpStatusCode.OK };
            client = GetManagementLinkClient(getHandler);
            var getResult = client.ResourceLinks.Get("/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm/providers/Microsoft.Resources/links/myLink");

            // Validate response
            Assert.Equal("/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm/providers/Microsoft.Resources/links/myLink", getResult.Id);
            Assert.Equal("/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm", getResult.Properties.SourceId);
            Assert.Equal("/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm2", getResult.Properties.TargetId);
            Assert.Equal("myLinkNotes", getResult.Properties.Notes);
            Assert.Equal("myLink", getResult.Name);

            //Delete resource link
            var deleteResponse = new HttpResponseMessage(HttpStatusCode.OK);
            deleteResponse.Headers.Add("x-ms-request-id", "1");
            var deleteHandler = new RecordedDelegatingHandler(deleteResponse) { StatusCodeToReturn = HttpStatusCode.OK };
            client = GetManagementLinkClient(deleteHandler);

            client.ResourceLinks.Delete("/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm/providers/Microsoft.Resources/links/myLink");

            // Validate headers
            Assert.Equal(HttpMethod.Delete, deleteHandler.Method);

            // Get a deleted link throws exception
            Assert.Throws<CloudException>(() => client.ResourceLinks.Get("/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm/providers/Microsoft.Resources/links/myLink"));
        }

        [Fact]
        public void ResourceLinkList()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'value': [
                        {
                            'id': '/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm/providers/Microsoft.Resources/links/myLink',
                            'name': 'myLink',
                            'properties': {
                                'sourceId': '/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm',
                                'targetId': '/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm2',
                                'notes': 'myLinkNotes'
                              }
                         },
                         {
                            'id': '/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Storage/storageAccounts/myAccount/providers/Microsoft.Resources/links/myLink2',
                            'name': 'myLink2',
                            'properties': {
                                'sourceId': '/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Storage/storageAccounts/myAccount',
                                'targetId': '/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Storage/storageAccounts/myAccount2',
                                'notes': 'myLinkNotes2'
                              }
                         }],
                      'nextLink': 'https://wa/subscriptions/subId/links?api-version=1.0&$skiptoken=662idk',
                }")
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetManagementLinkClient(handler);

            var result = client.ResourceLinks.ListAtSubscription();

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);

            // Validate result
            Assert.Equal(2, result.Count());
            Assert.Equal("myLink", result.First().Name);
            Assert.Equal("/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm/providers/Microsoft.Resources/links/myLink", result.First().Id);
            Assert.Equal("/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm", result.First().Properties.SourceId);
            Assert.Equal("/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm2", result.First().Properties.TargetId);
            Assert.Equal("myLinkNotes", result.First().Properties.Notes);
            Assert.Equal("https://wa/subscriptions/subId/links?api-version=1.0&$skiptoken=662idk", result.NextPageLink);

            // Filter by targetId

            var filteredResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'value': [
                        {
                            'id': '/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm/providers/Microsoft.Resources/links/myLink',
                            'name': 'myLink',
                            'properties': {
                                'sourceId': '/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm',
                                'targetId': '/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm2',
                                'notes': 'myLinkNotes'
                              }
                         }],
                      'nextLink': 'https://wa/subscriptions/subId/links?api-version=1.0&$skiptoken=662idk',
                }")
            };

            var filteredHandler = new RecordedDelegatingHandler(filteredResponse) { StatusCodeToReturn = HttpStatusCode.OK };
            client = GetManagementLinkClient(filteredHandler);
            var filteredResult = client.ResourceLinks.ListAtSubscription(new ODataQuery<ResourceLinkFilter>(f => f.TargetId == "/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm2"));

            // Validate result
            Assert.Equal(1, filteredResult.Count());
            Assert.Equal("myLink", filteredResult.First().Name);
            Assert.Equal("/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm/providers/Microsoft.Resources/links/myLink", filteredResult.First().Id);
            Assert.Equal("/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm", filteredResult.First().Properties.SourceId);
            Assert.Equal("/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm2", filteredResult.First().Properties.TargetId);
            Assert.Equal("myLinkNotes", filteredResult.First().Properties.Notes);
            Assert.Equal("https://wa/subscriptions/subId/links?api-version=1.0&$skiptoken=662idk", filteredResult.NextPageLink);
        }

        [Fact]
        public void ResourceLinkListAtSourceScope()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'value': [
                        {
                            'id': '/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm/providers/Microsoft.Resources/links/myLink',
                            'name': 'myLink',
                            'properties': {
                                'sourceId': '/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm',
                                'targetId': '/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm2',
                                'notes': 'myLinkNotes'
                              }
                         }],
                      'nextLink': 'https://wa/subscriptions/subId/links?api-version=1.0&$skiptoken=662idk',
                }")
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetManagementLinkClient(handler);

            var result = client.ResourceLinks.ListAtSourceScope("/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm");

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);

            // Validate result
            Assert.Equal(1, result.Count());
            Assert.Equal("myLink", result.First().Name);
            Assert.Equal("/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm/providers/Microsoft.Resources/links/myLink", result.First().Id);
            Assert.Equal("/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm", result.First().Properties.SourceId);
            Assert.Equal("/subscriptions/abc123/resourcegroups/myGroup/providers/Microsoft.Web/serverFarms/myFarm2", result.First().Properties.TargetId);
            Assert.Equal("myLinkNotes", result.First().Properties.Notes);
            Assert.Equal("https://wa/subscriptions/subId/links?api-version=1.0&$skiptoken=662idk", result.NextPageLink);
        }
    }
}
