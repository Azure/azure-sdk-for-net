// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Resources.Tests;
using NUnit.Framework;

namespace ResourceGroups.Tests
{
    public class InMemoryResourceTests : ResourceOperationsTestsBase
    {
        public InMemoryResourceTests(bool isAsync) : base(isAsync)
        {
        }

        public ResourcesManagementClient GetResourceManagementClient(HttpPipelineTransport transport)
        {
            ResourcesManagementClientOptions options = new ResourcesManagementClientOptions();
            options.Transport = transport;

            return CreateClient<ResourcesManagementClient>(
                TestEnvironment.SubscriptionId,
                new TestCredential(), options);
        }

        [Test]
        public async Task ResourceGetValidateMessage()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{
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
                }".Replace("'", "\"");
            var header = new HttpHeader("x-ms-request-id", "1");
            mockResponse.AddHeader(header);
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            var result = (await client.Resources.GetAsync("foo", "Microsoft.Web", string.Empty, "Sites", "site1", "2014-01-04")).Value;

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Get.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            // Validate result
            Assert.AreEqual("South Central US", result.Location);
            Assert.AreEqual("site1", result.Name);
            Assert.AreEqual("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1", result.Id);
            Assert.AreEqual("Dedicated", JsonDocument.Parse(JsonSerializer.Serialize(result.Properties)).RootElement.GetProperty("computeMode").GetString());
            Assert.AreEqual("Succeeded", JsonDocument.Parse(JsonSerializer.Serialize(result.Properties)).RootElement.GetProperty("provisioningState").GetString());
            Assert.AreEqual("F1", result.Sku.Name);
            Assert.AreEqual("Free", result.Sku.Tier);
            Assert.AreEqual("F1", result.Sku.Size);
            Assert.AreEqual("F", result.Sku.Family);
            Assert.AreEqual(0, result.Sku.Capacity);
        }

        [Test]
        public async Task ResourceGetByIdValidateMessage()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{
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
                }".Replace("'", "\"");
            var header = new HttpHeader("x-ms-request-id", "1");
            mockResponse.AddHeader(header);
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            var result = (await client.Resources.GetByIdAsync("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1", "2014-01-04")).Value;

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Get.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            // Validate result
            Assert.AreEqual("South Central US", result.Location);
            Assert.AreEqual("site1", result.Name);
            Assert.AreEqual("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1", result.Id);
            Assert.AreEqual("Dedicated", JsonDocument.Parse(JsonSerializer.Serialize(result.Properties)).RootElement.GetProperty("computeMode").GetString());
            Assert.AreEqual("Succeeded", JsonDocument.Parse(JsonSerializer.Serialize(result.Properties)).RootElement.GetProperty("provisioningState").GetString());
            Assert.AreEqual("F1", result.Sku.Name);
            Assert.AreEqual("Free", result.Sku.Tier);
            Assert.AreEqual("F1", result.Sku.Size);
            Assert.AreEqual("F", result.Sku.Family);
            Assert.AreEqual(0, result.Sku.Capacity);
        }

        [Test]
        public async Task ResourceGetWorksWithoutProvisioningState()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{
                  'id': '/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1',
                  'name': 'site1',
                  'location': 'South Central US',
                   'properties': {
                        'name':'site1',
	                    'siteMode': 'Standard',
                        'computeMode':'Dedicated'
                    }
                }".Replace("'", "\"");

            var header = new HttpHeader("x-ms-request-id", "1");
            mockResponse.AddHeader(header);
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            string resourceName = "site1";
            string resourceProviderNamespace = "Microsoft.Web";
            string resourceProviderApiVersion = "2014-01-04";
            string resourceType = "Sites";
            var result = (await client.Resources.GetAsync(
                "foo",
                resourceProviderNamespace,
                "",
                resourceType,
                resourceName,
                resourceProviderApiVersion)).Value;

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Get.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            // Validate result
            Assert.AreEqual("South Central US", result.Location);
            Assert.AreEqual("site1", result.Name);
            Assert.AreEqual("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1", result.Id);
            Assert.AreEqual("Dedicated", JsonDocument.Parse(JsonSerializer.Serialize(result.Properties)).RootElement.GetProperty("computeMode").GetString());
            JsonElement exsit = new JsonElement();
            Assert.IsFalse(JsonDocument.Parse(JsonSerializer.Serialize(result.Properties)).RootElement.TryGetProperty("provisionState", out exsit));
        }

        [Test]
        public async Task ResourceListValidateMessage()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{ 'value' : [
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
                    }]}".Replace("'", "\"");
            var header = new HttpHeader("x-ms-request-id", "1");
            mockResponse.AddHeader(header);
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            var result = await client.Resources.ListByResourceGroupAsync("foo", "$filter=resourceType eq 'Sites'").ToEnumerableAsync();

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Get.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            // Validate result
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("South Central US", result.First().Location);
            Assert.AreEqual("site1", result.First().Name);
            Assert.AreEqual("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1", result.First().Id);
            Assert.AreEqual("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1", result.First().Id);
            Assert.AreEqual("Dedicated", JsonDocument.Parse(JsonSerializer.Serialize(result.First().Properties)).RootElement.GetProperty("computeMode").GetString());
            Assert.AreEqual("Succeeded", JsonDocument.Parse(JsonSerializer.Serialize(result.First().Properties)).RootElement.GetProperty("provisioningState").GetString());
        }

        [Test]
        public async Task ResourceListForResourceGroupValidateMessage()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{ 'value' : [
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
                    }]}".Replace("'", "\"");
            var header = new HttpHeader("x-ms-request-id", "1");
            mockResponse.AddHeader(header);
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            var result = await client.Resources.ListByResourceGroupAsync("foo", "$filter=resourceType eq 'Sites'").ToEnumerableAsync();

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Get.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            // Validate result
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("South Central US", result.First().Location);
            Assert.AreEqual("site1", result.First().Name);
            Assert.AreEqual("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1", result.First().Id);
            Assert.AreEqual("/subscriptions/12345/resourceGroups/foo/providers/Microsoft.Web/Sites/site1", result.First().Id);
            Assert.Null(result.First().Properties);
        }

        [Test]
        public async Task ResourceGetThrowsExceptions()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.NoContent);
            var content = JsonDocument.Parse("{}").RootElement.ToString();
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            try
            {
                await client.Resources.GetAsync(null, null, null, null, null, null);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
            }
        }

        [Test]
        public async Task ResourceCreateOrUpdateValidateMessage()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{
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
                }".Replace("'", "\"");
            var header = new HttpHeader("x-ms-request-id", "1");
            mockResponse.AddHeader(header);
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            var raw = await client.Resources.StartCreateOrUpdateAsync(
                "foo",
                "Microsoft.Web",
                string.Empty,
                "sites",
                "site3",
                "2014-01-04",
                new GenericResource
                {
                    Location = "South Central US",
                    Tags = { { "department", "finance" }, { "tagname", "tagvalue" } },
                    Properties = @"{
                        'name':'site3',
	                    'siteMode': 'Standard',
                        'computeMode':'Dedicated'
                    }"
                }
            );
            var result = (await WaitForCompletionAsync(raw)).Value;

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Put.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            // Validate payload
            Stream stream = new MemoryStream();
            await request.Content.WriteToAsync(stream, default);
            stream.Position = 0;
            var resquestContent = new StreamReader(stream).ReadToEnd();
            var json = JsonDocument.Parse(resquestContent).RootElement;
            Assert.AreEqual("South Central US", json.GetProperty("location").GetString());
            Assert.AreEqual("finance", json.GetProperty("tags").GetProperty("department").GetString());
            Assert.AreEqual("tagvalue", json.GetProperty("tags").GetProperty("tagname").GetString());

            // Validate result
            Assert.AreEqual("South Central US", result.Location);
            Assert.AreEqual("Succeeded", JsonDocument.Parse(JsonSerializer.Serialize(result.Properties)).RootElement.GetProperty("provisioningState").GetString());
            Assert.AreEqual("Dedicated", JsonDocument.Parse(JsonSerializer.Serialize(result.Properties)).RootElement.GetProperty("computeMode").GetString());
            Assert.AreEqual("finance", result.Tags["department"]);
            Assert.AreEqual("tagvalue", result.Tags["tagname"]);
        }

        [Test]
        public async Task ResourceCreateOrUpdateWithIdentityValidateMessage()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{
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
                }".Replace("'", "\"");
            var header = new HttpHeader("x-ms-request-id", "1");
            mockResponse.AddHeader(header);
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            var raw = await client.Resources.StartCreateOrUpdateAsync(
                "foo",
                "Microsoft.Web",
                string.Empty,
                "sites",
                "site3",
                "2014-01-04",
                new GenericResource
                {
                    Location = "South Central US",
                    Tags = { { "department", "finance" }, { "tagname", "tagvalue" } },
                    Properties = @"{
                        'name':'site3',
	                    'siteMode': 'Standard',
                        'computeMode':'Dedicated'
                    }",
                    Identity = new Identity { Type = ResourceIdentityType.SystemAssigned }
                }
            );
            var result = (await WaitForCompletionAsync(raw)).Value;

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Put.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            // Validate payload
            Stream stream = new MemoryStream();
            await request.Content.WriteToAsync(stream, default);
            stream.Position = 0;
            var resquestContent = new StreamReader(stream).ReadToEnd();
            var json = JsonDocument.Parse(resquestContent).RootElement;
            Assert.AreEqual("South Central US", json.GetProperty("location").GetString());
            Assert.AreEqual("finance", json.GetProperty("tags").GetProperty("department").GetString());
            Assert.AreEqual("tagvalue", json.GetProperty("tags").GetProperty("tagname").GetString());

            // Validate result
            Assert.AreEqual("South Central US", result.Location);
            Assert.AreEqual("Succeeded", JsonDocument.Parse(JsonSerializer.Serialize(result.Properties)).RootElement.GetProperty("provisioningState").GetString());
            Assert.AreEqual("finance", result.Tags["department"]);
            Assert.AreEqual("tagvalue", result.Tags["tagname"]);
            Assert.AreEqual("Dedicated", JsonDocument.Parse(JsonSerializer.Serialize(result.Properties)).RootElement.GetProperty("computeMode").GetString());
            Assert.AreEqual("SystemAssigned", result.Identity.Type.ToString());
            Assert.AreEqual("foo", result.Identity.PrincipalId);
        }

        [Test]
        public async Task ResourceCreateForWebsiteValidatePayload()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = "{'location':'South Central US','properties':{'name':'csmr14v5efk0','state':'Running','hostNames':['csmr14v5efk0.antares-int.windows-int.net'],'webSpace':'csmrgqinwpwky-SouthCentralUSwebspace','selfLink':'https://antpreview1.api.admin-antares-int.windows-int.net:454/20130801/websystems/websites/web/subscriptions/abc123/webspaces/csmrgqinwpwky-SouthCentralUSwebspace/sites/csmr14v5efk0','repositorySiteName':'csmr14v5efk0','owner':null,'usageState':0,'enabled':true,'adminEnabled':true,'enabledHostNames':['csmr14v5efk0.antares-int.windows-int.net','csmr14v5efk0.scm.antares-int.windows-int.net'],'siteProperties':{'metadata':null,'properties':[],'appSettings':null},'availabilityState':0,'sslCertificates':[],'csrs':[],'cers':null,'siteMode':'Standard','hostNameSslStates':[{'name':'csmr14v5efk0.antares-int.windows-int.net','sslState':0,'ipBasedSslResult':null,'virtualIP':null,'thumbprint':null,'toUpdate':null,'toUpdateIpBasedSsl':null,'ipBasedSslState':0},{'name':'csmr14v5efk0.scm.antares-int.windows-int.net','sslState':0,'ipBasedSslResult':null,'virtualIP':null,'thumbprint':null,'toUpdate':null,'toUpdateIpBasedSsl':null,'ipBasedSslState':0}],'computeMode':1,'serverFarm':'DefaultServerFarm1','lastModifiedTimeUtc':'2014-02-21T00:49:30.477','storageRecoveryDefaultState':'Running','contentAvailabilityState':0,'runtimeAvailabilityState':0,'siteConfig':null,'deploymentId':'csmr14v5efk0','trafficManagerHostNames':[]}}".Replace("'", "\"");
            var header = new HttpHeader("x-ms-request-id", "1");
            mockResponse.AddHeader(header);
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            var raw = await client.Resources.StartCreateOrUpdateAsync(
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
            var result = (await WaitForCompletionAsync(raw)).Value;

            // Validate result
            Assert.AreEqual("South Central US", result.Location);
        }

        [Test]
        public async Task ResourceCreateByIdForWebsiteValidatePayload()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = "{'location':'South Central US','properties':{'name':'mySite','state':'Running','hostNames':['csmr14v5efk0.antares-int.windows-int.net'],'webSpace':'csmrgqinwpwky-SouthCentralUSwebspace','selfLink':'https://antpreview1.api.admin-antares-int.windows-int.net:454/20130801/websystems/websites/web/subscriptions/abc123/webspaces/csmrgqinwpwky-SouthCentralUSwebspace/sites/csmr14v5efk0','repositorySiteName':'csmr14v5efk0','owner':null,'usageState':0,'enabled':true,'adminEnabled':true,'enabledHostNames':['csmr14v5efk0.antares-int.windows-int.net','csmr14v5efk0.scm.antares-int.windows-int.net'],'siteProperties':{'metadata':null,'properties':[],'appSettings':null},'availabilityState':0,'sslCertificates':[],'csrs':[],'cers':null,'siteMode':'Standard','hostNameSslStates':[{'name':'csmr14v5efk0.antares-int.windows-int.net','sslState':0,'ipBasedSslResult':null,'virtualIP':null,'thumbprint':null,'toUpdate':null,'toUpdateIpBasedSsl':null,'ipBasedSslState':0},{'name':'csmr14v5efk0.scm.antares-int.windows-int.net','sslState':0,'ipBasedSslResult':null,'virtualIP':null,'thumbprint':null,'toUpdate':null,'toUpdateIpBasedSsl':null,'ipBasedSslState':0}],'computeMode':1,'serverFarm':'DefaultServerFarm1','lastModifiedTimeUtc':'2014-02-21T00:49:30.477','storageRecoveryDefaultState':'Running','contentAvailabilityState':0,'runtimeAvailabilityState':0,'siteConfig':null,'deploymentId':'csmr14v5efk0','trafficManagerHostNames':[]}}".Replace("'", "\"");
            var header = new HttpHeader("x-ms-request-id", "1");
            mockResponse.AddHeader(header);
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            var raw = await client.Resources.StartCreateOrUpdateByIdAsync(
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
            var result = (await WaitForCompletionAsync(raw)).Value;

            // Validate result
            Assert.AreEqual("South Central US", result.Location);
        }

        [Test]
        public async Task ResourceGetCreateOrUpdateDeleteAndExistsThrowExceptionWithoutApiVersion()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = JsonDocument.Parse("{}").RootElement.ToString();
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

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

            try
            {
                await client.Resources.GetAsync(
                "foo",
                resourceProviderNamespace,
                parentResourse,
                resourceType,
                resourceName,
                resourceProviderApiVersion);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
            }

            try
            {
                await client.Resources.CheckExistenceAsync(
                "foo",
                resourceProviderNamespace,
                parentResourse,
                resourceType,
                resourceName,
                resourceProviderApiVersion);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
            }
            try
            {
                await client.Resources.StartCreateOrUpdateAsync(
                "foo",
                resourceProviderNamespace,
                parentResourse,
                resourceType,
                resourceName,
                resourceProviderApiVersion,
                resource);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
            }
            try
            {
                await client.Resources.StartDeleteAsync(
                "foo",
                resourceProviderNamespace,
                parentResourse,
                resourceType,
                resourceName,
                resourceProviderApiVersion);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
            }
        }

        [Test]
        public async Task ResourceExistsValidateNoContentMessage()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.NoContent);
            var content = JsonDocument.Parse("{}").RootElement.ToString();
            var header = new HttpHeader("x-ms-request-id", "1");
            mockResponse.AddHeader(header);
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            string resourceName = "site3";
            string resourceProviderNamespace = "Microsoft.Web";
            string resourceProviderApiVersion = "2014-01-04";
            string resourceType = "sites";
            var result = await client.Resources.CheckExistenceAsync(
                "foo",
                resourceProviderNamespace,
                "",
                resourceType,
                resourceName,
                resourceProviderApiVersion);

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Head.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            // Validate result
            Assert.NotNull(result);
        }

        [Test]
        public async Task ResourceExistsValidateMissingMessage()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.NotFound);
            var header = new HttpHeader("x-ms-request-id", "1");
            mockResponse.AddHeader(header);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            string resourceName = Guid.NewGuid().ToString();
            string resourceProviderNamespace = "Microsoft.Web";
            string resourceProviderApiVersion = "2014-01-04";
            string resourceType = "sites";

            var result = await client.Resources.CheckExistenceAsync(
                "foo",
                resourceProviderNamespace,
                "",
                resourceType,
                resourceName,
                resourceProviderApiVersion);

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Head.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            // Validate result
            Assert.NotNull(result);
        }

        [Test]
        public async Task UriSupportsBaseUriWithPathTest()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.NotFound);
            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            string resourceName = Guid.NewGuid().ToString();
            string resourceProviderNamespace = "Microsoft.Web";
            string resourceProviderApiVersion = "2014-01-04";
            string resourceType = "sites";
            await client.Resources.CheckExistenceAsync("foo",
                resourceProviderNamespace,
                "",
                resourceType,
                resourceName,
                resourceProviderApiVersion);

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual("https://management.azure.com/subscriptions/" + TestEnvironment.SubscriptionId + "/resourcegroups/foo/providers/Microsoft.Web//sites/" + resourceName + "?api-version=2014-01-04", request.Uri.ToString());
        }

        [Test]
        public async Task ResourceDeleteValidateMessage()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = JsonDocument.Parse("{}").RootElement.ToString();
            var header = new HttpHeader("x-ms-request-id", "1");
            mockResponse.AddHeader(header);
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            string resourceName = "site3";
            string resourceProviderNamespace = "Microsoft.Web";
            string resourceProviderApiVersion = "2014-01-04";
            string resourceType = "sites";
            await client.Resources.StartDeleteAsync("foo",
                resourceProviderNamespace,
                "",
                resourceType,
                resourceName,
                resourceProviderApiVersion);

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Delete.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));
        }

        [Test]
        public async Task ResourceDeleteByIdValidateMessage()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = JsonDocument.Parse("{}").RootElement.ToString();

            var header = new HttpHeader("x-ms-request-id", "1");
            mockResponse.AddHeader(header);
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            await client.Resources.StartDeleteByIdAsync("/subscriptions/12345/resourceGroups/myGroup/Microsoft.Web/sites/mySite", "2014-01-04");

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Delete.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));
        }

        [Test]
        public async Task ResourceDeleteSupportNoContentReturnCode()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.NoContent);
            var content = JsonDocument.Parse("{}").RootElement.ToString();
            var header = new HttpHeader("x-ms-request-id", "1");
            mockResponse.AddHeader(header);
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            string resourceName = "site3";
            string resourceProviderNamespace = "Microsoft.Web";
            string resourceProviderApiVersion = "2014-01-04";
            string resourceType = "sites";

            try
            {
                await client.Resources.StartDeleteAsync("foo",
                resourceProviderNamespace,
                "",
                resourceType,
                resourceName,
                resourceProviderApiVersion);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
            }
        }
    }
}
