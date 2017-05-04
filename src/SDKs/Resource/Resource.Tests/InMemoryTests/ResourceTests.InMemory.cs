// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Test;
using Microsoft.Rest;
using Microsoft.Rest.Azure.OData;
using Newtonsoft.Json.Linq;
using Xunit;

namespace ResourceGroups.Tests
{
    public class InMemoryResourceTests
    {
        public ResourceManagementClient GetResourceManagementClient(RecordedDelegatingHandler handler)
        {
            var subscriptionId = Guid.NewGuid().ToString();
            var token = new TokenCredentials(subscriptionId, "abc123");
            var client = new ResourceManagementClient(token, handler);
            client.SubscriptionId = subscriptionId;
            handler.IsPassThrough = false;
            return client;
        }

        [Fact]
        public void ResourceGetValidateMessage()
        { 
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                  'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1',
                  'name': 'site1',
                  'location': 'South Central US',
                   'properties': {
                        'name':'site1',
	                    'siteMode': 'Standard',
                        'computeMode':'Dedicated',
                        'provisioningState':'Succeeded'
                   },
                   'sku': {
                        'name': 'F1',
                        'tier': 'Free',
                        'size': 'F1',
                        'family': 'F',
                        'capacity': 0
                    }
                }")
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);

            var result = client.Resources.Get("foo", "Microsoft.Web", string.Empty, "Sites", "site1", "2014-01-04");

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal("South Central US", result.Location);
            Assert.Equal("site1", result.Name);
            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1", result.Id);
            Assert.True(result.Properties.ToString().Contains("Dedicated"));
            Assert.Equal("Succeeded", (result.Properties as JObject)["provisioningState"]);
            Assert.Equal("F1", result.Sku.Name);
            Assert.Equal("Free", result.Sku.Tier);
            Assert.Equal("F1", result.Sku.Size);
            Assert.Equal("F", result.Sku.Family);
            Assert.Equal(0, result.Sku.Capacity);
        }

        [Fact]
        public void ResourceGetByIdValidateMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                  'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1',
                  'name': 'site1',
                  'location': 'South Central US',
                   'properties': {
                        'name':'site1',
	                    'siteMode': 'Standard',
                        'computeMode':'Dedicated',
                        'provisioningState':'Succeeded'
                   },
                   'sku': {
                        'name': 'F1',
                        'tier': 'Free',
                        'size': 'F1',
                        'family': 'F',
                        'capacity': 0
                    }
                }")
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);

            var result = client.Resources.GetById("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1", "2014-01-04");

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal("South Central US", result.Location);
            Assert.Equal("site1", result.Name);
            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1", result.Id);
            Assert.True(result.Properties.ToString().Contains("Dedicated"));
            Assert.Equal("Succeeded", (result.Properties as JObject)["provisioningState"]);
            Assert.Equal("F1", result.Sku.Name);
            Assert.Equal("Free", result.Sku.Tier);
            Assert.Equal("F1", result.Sku.Size);
            Assert.Equal("F", result.Sku.Family);
            Assert.Equal(0, result.Sku.Capacity);
        }

        [Fact]
        public void ResourceGetWorksWithoutProvisioningState()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                  'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1',
                  'name': 'site1',
                  'location': 'South Central US',
                   'properties': {
                        'name':'site1',
	                    'siteMode': 'Standard',
                        'computeMode':'Dedicated'
                    }
                }")
            };

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);
            var identity = new ResourceIdentity
            {
                ResourceName = "site1",
                ResourceProviderNamespace = "Microsoft.Web",
                ResourceProviderApiVersion = "2014-01-04",
                ResourceType = "Sites"
            };
            var result = client.Resources.Get(
                "foo",
                identity.ResourceProviderNamespace,
                "",
                identity.ResourceType,
                identity.ResourceName,
                identity.ResourceProviderApiVersion);

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal("South Central US", result.Location);
            Assert.Equal("site1", result.Name);
            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1", result.Id);
            Assert.True(result.Properties.ToString().Contains("Dedicated"));
            Assert.Null((result.Properties as JObject)["provisionState"]);
        }

        [Fact]
        public void ResourceListValidateMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{ 'value' : [
                    {
                      'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1',
                      'name': 'site1',
                      'resourceGroup': 'foo',
                      'location': 'South Central US',
                      'properties': 
                       { 
                          'name':'site1',
	                      'siteMode': 'Standard',
                          'computeMode':'Dedicated',
                          'provisioningState':'Succeeded'
                       }
                    },
                    {
                      'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1',
                      'name': 'site1',
                      'resourceGroup': 'foo',
                      'location': 'South Central US',
                      'properties': 
                       { 
                          'name':'site1',
	                      'siteMode': 'Standard',
                          'computeMode':'Dedicated'
                       }
                    }], 
                    'nextLink': 'https://wa.com/subscriptions/subId/resources?$skiptoken=983fknw'}")
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);

            var result = client.Resources.ListByResourceGroup("foo", new ODataQuery<GenericResourceFilter>(r => r.ResourceType == "Sites"));
            /*new ResourceListParameters
            {              
                ResourceType = "Sites"
            });*/

            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal(2, result.Count());
            Assert.Equal("South Central US", result.First().Location);
            Assert.Equal("site1", result.First().Name);
            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1", result.First().Id);
            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1", result.First().Id);
            Assert.True(result.First().Properties.ToString().Contains("Dedicated"));
            Assert.Equal("Succeeded", (result.First().Properties as JObject)["provisioningState"]);
        }

        [Fact]
        public void ResourceListForResourceGroupValidateMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{ 'value' : [
                    {
                      'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1',
                      'name': 'site1',
                      'resourceGroup': 'foo',
                      'location': 'South Central US'
                    },
                    {
                      'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1',
                      'name': 'site1',
                      'resourceGroup': 'foo',
                      'location': 'South Central US'
                    }], 
                    'nextLink': 'https://wa.com/subscriptions/subId/resources?$skiptoken=983fknw'}")
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);

            var result = client.Resources.ListByResourceGroup("foo", new ODataQuery<GenericResourceFilter>(r => r.ResourceType == "Sites"));


            // Validate headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal(2, result.Count());
            Assert.Equal("South Central US", result.First().Location);
            Assert.Equal("site1", result.First().Name);
            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1", result.First().Id);
            Assert.Equal("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1", result.First().Id);
            Assert.Null(result.First().Properties);
        }

        [Fact]
        public void ResourceGetThrowsExceptions()
        {
            var handler = new RecordedDelegatingHandler();
            var client = GetResourceManagementClient(handler);

            Assert.Throws<Microsoft.Rest.ValidationException>(() => client.Resources.Get(null, null, null, null, null, null));
        }

        [Fact]
        public void ResourceCreateOrUpdateValidateMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'location': 'South Central US',
                    'tags' : {
                        'department':'finance',
                        'tagname':'tagvalue'
                    },
                    'properties': {
                        'name':'site3',
	                    'siteMode': 'Standard',
                        'computeMode':'Dedicated',
                        'provisioningState':'Succeeded'
                    }
                }")
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);

            var result = client.Resources.CreateOrUpdate(
                "foo",
                "Microsoft.Web",
                string.Empty,
                "sites",
                "site3",
                "2014-01-04",
                new GenericResource
                {
                    Location = "South Central US",
                    Tags = new Dictionary<string, string>() { { "department", "finance" }, { "tagname", "tagvalue" } },
                    Properties = @"{
                        'name':'site3',
	                    'siteMode': 'Standard',
                        'computeMode':'Dedicated'
                    }"
                }
            );

            JObject json = JObject.Parse(handler.Request);

            // Validate headers
            Assert.Equal(HttpMethod.Put, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate payload
            Assert.Equal("South Central US", json["location"].Value<string>());
            Assert.Equal("finance", json["tags"]["department"].Value<string>());
            Assert.Equal("tagvalue", json["tags"]["tagname"].Value<string>());

            // Validate result
            Assert.Equal("South Central US", result.Location);
            Assert.Equal("Succeeded", (result.Properties as JObject)["provisioningState"]);
            Assert.Equal("finance", result.Tags["department"]);
            Assert.Equal("tagvalue", result.Tags["tagname"]);
            Assert.True(result.Properties.ToString().Contains("Dedicated"));
        }

        [Fact]
        public void ResourceCreateOrUpdateWithIdentityValidateMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'location': 'South Central US',
                    'tags' : {
                        'department':'finance',
                        'tagname':'tagvalue'
                    },
                    'properties': {
                        'name':'site3',
	                    'siteMode': 'Standard',
                        'computeMode':'Dedicated',
                        'provisioningState':'Succeeded'
                    },
                    'identity': {
                        'type': 'SystemAssigned',
                        'principalId': 'foo'
                    }
                }")
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);

            var result = client.Resources.CreateOrUpdate(
                "foo",
                "Microsoft.Web",
                string.Empty,
                "sites",
                "site3",
                "2014-01-04",
                new GenericResource
                {
                    Location = "South Central US",
                    Tags = new Dictionary<string, string>() { { "department", "finance" }, { "tagname", "tagvalue" } },
                    Properties = @"{
                        'name':'site3',
	                    'siteMode': 'Standard',
                        'computeMode':'Dedicated'
                    }",
                    Identity = new Identity { Type = ResourceIdentityType.SystemAssigned }
                }
            );

            JObject json = JObject.Parse(handler.Request);

            // Validate headers
            Assert.Equal(HttpMethod.Put, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate payload
            Assert.Equal("South Central US", json["location"].Value<string>());
            Assert.Equal("finance", json["tags"]["department"].Value<string>());
            Assert.Equal("tagvalue", json["tags"]["tagname"].Value<string>());

            // Validate result
            Assert.Equal("South Central US", result.Location);
            Assert.Equal("Succeeded", (result.Properties as JObject)["provisioningState"]);
            Assert.Equal("finance", result.Tags["department"]);
            Assert.Equal("tagvalue", result.Tags["tagname"]);
            Assert.True(result.Properties.ToString().Contains("Dedicated"));
            Assert.Equal("SystemAssigned", result.Identity.Type.ToString());
            Assert.Equal("foo", result.Identity.PrincipalId);
        }

        [Fact]
        public void ResourceCreateForWebsiteValidatePayload()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{'location':'South Central US','tags':null,'properties':{'name':'csmr14v5efk0','state':'Running','hostNames':['csmr14v5efk0.antares-int.windows-int.net'],'webSpace':'csmrgqinwpwky-SouthCentralUSwebspace','selfLink':'https://antpreview1.api.admin-antares-int.windows-int.net:454/20130801/websystems/websites/web/subscriptions/abc123/webspaces/csmrgqinwpwky-SouthCentralUSwebspace/sites/csmr14v5efk0','repositorySiteName':'csmr14v5efk0','owner':null,'usageState':0,'enabled':true,'adminEnabled':true,'enabledHostNames':['csmr14v5efk0.antares-int.windows-int.net','csmr14v5efk0.scm.antares-int.windows-int.net'],'siteProperties':{'metadata':null,'properties':[],'appSettings':null},'availabilityState':0,'sslCertificates':[],'csrs':[],'cers':null,'siteMode':'Standard','hostNameSslStates':[{'name':'csmr14v5efk0.antares-int.windows-int.net','sslState':0,'ipBasedSslResult':null,'virtualIP':null,'thumbprint':null,'toUpdate':null,'toUpdateIpBasedSsl':null,'ipBasedSslState':0},{'name':'csmr14v5efk0.scm.antares-int.windows-int.net','sslState':0,'ipBasedSslResult':null,'virtualIP':null,'thumbprint':null,'toUpdate':null,'toUpdateIpBasedSsl':null,'ipBasedSslState':0}],'computeMode':1,'serverFarm':'DefaultServerFarm1','lastModifiedTimeUtc':'2014-02-21T00:49:30.477','storageRecoveryDefaultState':'Running','contentAvailabilityState':0,'runtimeAvailabilityState':0,'siteConfig':null,'deploymentId':'csmr14v5efk0','trafficManagerHostNames':[]}}")
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);

            var result = client.Resources.CreateOrUpdate(
                "foo",
                "Microsoft.Web",
                string.Empty,
                "sites",
                "csmr14v5efk0",
                "2014-01-04",
                new GenericResource
                    {
                        Location = "South Central US",
                        Properties = @"{
                            'name':'csmr14v5efk0',
	                        'siteMode': 'Standard',
                            'computeMode':'Dedicated'
                        }"
                    }
                );

            // Validate result
            Assert.Equal("South Central US", result.Location);
        }

        [Fact]
        public void ResourceCreateByIdForWebsiteValidatePayload()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{'location':'South Central US','tags':null,'properties':{'name':'mySite','state':'Running','hostNames':['csmr14v5efk0.antares-int.windows-int.net'],'webSpace':'csmrgqinwpwky-SouthCentralUSwebspace','selfLink':'https://antpreview1.api.admin-antares-int.windows-int.net:454/20130801/websystems/websites/web/subscriptions/abc123/webspaces/csmrgqinwpwky-SouthCentralUSwebspace/sites/csmr14v5efk0','repositorySiteName':'csmr14v5efk0','owner':null,'usageState':0,'enabled':true,'adminEnabled':true,'enabledHostNames':['csmr14v5efk0.antares-int.windows-int.net','csmr14v5efk0.scm.antares-int.windows-int.net'],'siteProperties':{'metadata':null,'properties':[],'appSettings':null},'availabilityState':0,'sslCertificates':[],'csrs':[],'cers':null,'siteMode':'Standard','hostNameSslStates':[{'name':'csmr14v5efk0.antares-int.windows-int.net','sslState':0,'ipBasedSslResult':null,'virtualIP':null,'thumbprint':null,'toUpdate':null,'toUpdateIpBasedSsl':null,'ipBasedSslState':0},{'name':'csmr14v5efk0.scm.antares-int.windows-int.net','sslState':0,'ipBasedSslResult':null,'virtualIP':null,'thumbprint':null,'toUpdate':null,'toUpdateIpBasedSsl':null,'ipBasedSslState':0}],'computeMode':1,'serverFarm':'DefaultServerFarm1','lastModifiedTimeUtc':'2014-02-21T00:49:30.477','storageRecoveryDefaultState':'Running','contentAvailabilityState':0,'runtimeAvailabilityState':0,'siteConfig':null,'deploymentId':'csmr14v5efk0','trafficManagerHostNames':[]}}")
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);

            var result = client.Resources.CreateOrUpdateById(
                "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myGroup/Microsoft.Web/sites/mySite",
                "2014-01-04",
                new GenericResource
                {
                    Location = "South Central US",
                    Properties = @"{
                            'name':'mySite',
	                        'siteMode': 'Standard',
                            'computeMode':'Dedicated'
                        }"
                }
                );

            // Validate result
            Assert.Equal("South Central US", result.Location);
        }

        [Fact]
        public void ResourceGetCreateOrUpdateDeleteAndExistsThrowExceptionWithoutApiVersion()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);
            var resourceName = "site3";
            var resourceProviderNamespace = "Microsoft.Web";
            string resourceProviderApiVersion = null;
            var resourceType = "sites";
            var parentResourse = string.Empty;

            var resource = new GenericResource
                {
                    Location = "South Central US",
                    Properties = @"{
                                'name':'site3',
	                            'siteMode': 'Standard',
                                'computeMode':'Dedicated'
                            }"
                };


            Assert.Throws<Microsoft.Rest.ValidationException>(() => client.Resources.Get(
                "foo",
                resourceProviderNamespace,
                parentResourse,
                resourceType,
                resourceName,
                resourceProviderApiVersion));
            Assert.Throws<Microsoft.Rest.ValidationException>(() => client.Resources.CheckExistence(
                "foo",
                resourceProviderNamespace,
                parentResourse,
                resourceType,
                resourceName,
                resourceProviderApiVersion));
            Assert.Throws<Microsoft.Rest.ValidationException>(() => client.Resources.CreateOrUpdate(
                "foo",
                resourceProviderNamespace,
                parentResourse,
                resourceType,
                resourceName,
                resourceProviderApiVersion, 
                resource));
            Assert.Throws<Microsoft.Rest.ValidationException>(() => client.Resources.Delete(
                "foo",
                resourceProviderNamespace,
                parentResourse,
                resourceType,
                resourceName,
                resourceProviderApiVersion));
        }


        [Fact]
        public void ResourceExistsValidateNoContentMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.NoContent);
            response.Headers.Add("x-ms-request-id", "1");

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.NoContent };
            var client = GetResourceManagementClient(handler);

            var identity = new ResourceIdentity
            {
                ResourceName = "site3",
                ResourceProviderNamespace = "Microsoft.Web",
                ResourceProviderApiVersion = "2014-01-04",
                ResourceType = "sites"
            };
            var result = client.Resources.CheckExistence(
                "foo", 
                identity.ResourceProviderNamespace, 
                "",
                identity.ResourceType,
                identity.ResourceName,
                identity.ResourceProviderApiVersion);

            // Validate headers
            Assert.Equal(HttpMethod.Head, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal(true, result);
        }

        [Fact]
        public void ResourceExistsValidateMissingMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.NotFound);
            response.Headers.Add("x-ms-request-id", "1");

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.NotFound };
            var client = GetResourceManagementClient(handler);

            var identity = new ResourceIdentity
            {
                ResourceName = Guid.NewGuid().ToString(),
                ResourceProviderNamespace = "Microsoft.Web",
                ResourceProviderApiVersion = "2014-01-04",
                ResourceType = "sites"
            };
            var result = client.Resources.CheckExistence(
                "foo", 
                identity.ResourceProviderNamespace, 
                "",
                identity.ResourceType,
                identity.ResourceName,
                identity.ResourceProviderApiVersion);

            // Validate headers
            Assert.Equal(HttpMethod.Head, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal(false, result);
        }

        [Fact]
        public void UriSupportsBaseUriWithPathTest()
        {
            var response = new HttpResponseMessage(HttpStatusCode.NotFound);
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.NotFound };
            handler.IsPassThrough = false;
            var randomValue = Guid.NewGuid().ToString();
            var token = new TokenCredentials(randomValue, "abc123");
            var client = new ResourceManagementClient(new Uri("https://localhost:123/test/"), token, handler);
            client.SubscriptionId = randomValue;
            var identity = new ResourceIdentity
            {
                ResourceName = randomValue,
                ResourceProviderNamespace = "Microsoft.Web",
                ResourceProviderApiVersion = "2014-01-04",
                ResourceType = "sites"
            };
            client.Resources.CheckExistence("foo",
                identity.ResourceProviderNamespace,
                "",
                identity.ResourceType,
                identity.ResourceName,
                identity.ResourceProviderApiVersion);
            // Validate headers
            Assert.Equal("https://localhost:123/test/subscriptions/" + randomValue + "/resourcegroups/foo/providers/Microsoft.Web//sites/" + randomValue + "?api-version=2014-01-04", handler.Uri.AbsoluteUri);
        }

        [Fact]
        public void ResourceDeleteValidateMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);

            var identity = new ResourceIdentity
            {
                ResourceName = "site3",
                ResourceProviderNamespace = "Microsoft.Web",
                ResourceProviderApiVersion = "2014-01-04",
                ResourceType = "sites",
            };
            client.Resources.Delete("foo",
                identity.ResourceProviderNamespace,
                "",
                identity.ResourceType,
                identity.ResourceName,
                identity.ResourceProviderApiVersion);

            // Validate headers
            Assert.Equal(HttpMethod.Delete, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));
        }

        [Fact]
        public void ResourceDeleteByIdValidateMessage()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetResourceManagementClient(handler);

            client.Resources.DeleteById("/subscriptions/12345/resourceGroups/myGroup/Microsoft.Web/sites/mySite", "2014-01-04");

            // Validate headers
            Assert.Equal(HttpMethod.Delete, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));
        }

        [Fact]
        public void ResourceDeleteSupportNoContentReturnCode()
        {
            var response = new HttpResponseMessage(HttpStatusCode.NoContent);

            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.NoContent };
            var client = GetResourceManagementClient(handler);

            var identity = new ResourceIdentity
            {
                ResourceName = "site3",
                ResourceProviderNamespace = "Microsoft.Web",
                ResourceProviderApiVersion = "2014-01-04",
                ResourceType = "sites",
            };
            client.Resources.Delete("foo",
                identity.ResourceProviderNamespace,
                "",
                identity.ResourceType,
                identity.ResourceName,
                identity.ResourceProviderApiVersion);
        }

        [Fact (Skip = "Change test to account for LRO in MoveResources")]
        public void ResourcesMoveTest()
        {
            var response = new HttpResponseMessage(HttpStatusCode.Accepted)
            {
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
           
            var client = GetResourceManagementClient(handler);

            var resourceToMove = new ResourcesMoveInfo();
            resourceToMove.Resources = new List<string>();
            resourceToMove.TargetResourceGroup = "/subscriptions/" + Uri.EscapeDataString(client.SubscriptionId) + "/resourceGroups/resourceGroup1";

            var resource1 = "/subscriptions/" + Uri.EscapeDataString(client.SubscriptionId) + "/resourceGroups/resourceGroup0/providers/Microsoft.Web/website/website1";
            resourceToMove.Resources.Add(resource1);

            var resource2 = "/subscriptions/" + Uri.EscapeDataString(client.SubscriptionId) + "/resourceGroups/resourceGroup0/providers/Microsoft.Compute/hostservice/vm1";
            resourceToMove.Resources.Add(resource2);

            client.Resources.MoveResources("resourceGroup0", resourceToMove);

            // Validate headers 
            Assert.Equal(HttpMethod.Post, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            //Valid payload
            //Construct expected URL
            string expectedUrl = "/subscriptions/" + Uri.EscapeDataString(client.SubscriptionId) + "/resourceGroups/resourceGroup0/moveResources?";
            expectedUrl = expectedUrl + "api-version=2014-04-01-preview";
            string baseUrl = client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (expectedUrl[0] == '/')
            {
                expectedUrl = expectedUrl.Substring(1);
            }
            expectedUrl = baseUrl + "/" + expectedUrl;
            expectedUrl = expectedUrl.Replace(" ", "%20");

            Assert.Equal(expectedUrl, handler.Uri.ToString());
        }
    }
}
