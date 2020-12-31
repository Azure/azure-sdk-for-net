// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Tests;
using NUnit.Framework;

namespace ResourceGroups.Tests
{
    public class InMemoryProviderTests : ResourceOperationsTestsBase
    {
        public InMemoryProviderTests(bool isAsync) : base(isAsync)
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
        public async Task ProviderGetValidateMessage()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{
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
                }".Replace("'", "\"");
            mockResponse.SetContent(content);
            var header = new HttpHeader("x-ms-request-id", "1");
            mockResponse.AddHeader(header);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            var result = (await client.Providers.GetAsync("Microsoft.Websites", expand: "resourceTypes/aliases")).Value;

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Get.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            // Validate result
            Assert.AreEqual("Microsoft.Websites", result.Namespace);
            Assert.AreEqual("Registered", result.RegistrationState);
            Assert.AreEqual(2, result.ResourceTypes.Count);
            Assert.AreEqual("sites", result.ResourceTypes[0].ResourceType);
            Assert.AreEqual(1, result.ResourceTypes[0].Locations.Count);
            Assert.AreEqual("Central US", result.ResourceTypes[0].Locations[0]);
            Assert.AreEqual(2, result.ResourceTypes[0].Aliases.Count);
            Assert.AreEqual("Microsoft.Compute/virtualMachines/sku.name", result.ResourceTypes[0].Aliases[0].Name);
            Assert.AreEqual(1, result.ResourceTypes[0].Aliases[0].Paths.Count);
            Assert.AreEqual("properties.hardwareProfile.vmSize", result.ResourceTypes[0].Aliases[0].Paths[0].Path);
        }

        [Test]
        public async Task ProviderGetThrowsExceptions()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.NoContent);
            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            try
            {
                await client.Providers.GetAsync(null);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Value cannot be null"));
            }
        }

        [Test]
        public async Task ProviderListValidateMessage()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{ 'value' : [
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
                }]}".Replace("'", "\"");
            var header = new HttpHeader("x-ms-request-id", "1");
            mockResponse.AddHeader(header);
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            var result = await client.Providers.ListAsync(null).ToEnumerableAsync();

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Get.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            // Validate result
            Has.One.EqualTo(result);
            Assert.AreEqual("Microsoft.Websites", result.First().Namespace);
            Assert.AreEqual("Registered", result.First().RegistrationState);
            Assert.AreEqual(2, result.First().ResourceTypes.Count);
            Assert.AreEqual("sites", result.First().ResourceTypes[0].ResourceType);
            Assert.AreEqual(1, result.First().ResourceTypes[0].Locations.Count);
            Assert.AreEqual("Central US", result.First().ResourceTypes[0].Locations[0]);
        }

        [Test]
        public async Task ProviderRegisterValidate()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = JsonDocument.Parse("{}").RootElement.ToString();
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            var result = (await client.Providers.RegisterAsync("Microsoft.Websites")).Value;

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Post.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));
        }

        [Test]
        public async Task ProviderRegisterThrowsExceptions()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.NoContent);
            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            try
            {
                await client.Providers.RegisterAsync(null);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Value cannot be null"));
            }
        }

        [Test]
        public async Task ProviderUnregisterValidate()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = JsonDocument.Parse("{}").RootElement.ToString();
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            var result = (await client.Providers.UnregisterAsync("Microsoft.Websites")).Value;

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Post.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));
        }

        [Test]
        public async Task ProviderUnregisterThrowsExceptions()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.NoContent);
            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            try
            {
                await client.Providers.UnregisterAsync(null);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Value cannot be null"));
            }
        }
    }
}
