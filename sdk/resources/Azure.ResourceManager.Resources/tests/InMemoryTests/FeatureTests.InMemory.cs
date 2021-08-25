// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Tests;
using NUnit.Framework;

namespace ResourceGroups.Tests
{
    public class InMemoryFeatureTests : ResourceOperationsTestsBase
    {
        public InMemoryFeatureTests(bool isAsync) : base(isAsync)
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
        public async Task RegisterFeature()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{
                      'name': 'Providers.Test/DONOTDELETEBETA',

                      'properties': {

                        'state': 'NotRegistered'

                      },

                      'id': '/subscriptions/fda3b6ba-8803-441c-91fb-6cc798cf6ea0/providers/Microsoft.Features/providers/Providers.Test/features/DONOTDELETEBETA',

                      'type': 'Microsoft.Features/providers/features'
                }".Replace("'", "\"");
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            string resourceProviderNamespace = "Providers.Test";

            string featureName = "DONOTDELETEBETA";

            var registerResult = await client.Features.RegisterAsync(resourceProviderNamespace, featureName);

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Post.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            //Valid payload
            //Construct expected URL
            string expectedUrl = "/subscriptions/" + Uri.EscapeDataString(TestEnvironment.SubscriptionId) + "/providers/Microsoft.Features/providers/" + Uri.EscapeDataString(resourceProviderNamespace) + "/features/" + Uri.EscapeDataString(featureName) + "/register?";
            expectedUrl = expectedUrl + "api-version=2015-12-01";
            string baseUrl = "https://management.azure.com";
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

            Assert.AreEqual(expectedUrl, request.Uri.ToString());
        }

        [Test]
        public async Task GetPreviewedFeatures()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{                    
                    'name': 'Providers.Test/DONOTDELETEBETA',
                    'properties': {
                    'state': 'NotRegistered'
                     },
                    'id': '/subscriptions/fda3b6ba-8803-441c-91fb-6cc798cf6ea0/providers/Microsoft.Features/providers/Providers.Test/features/DONOTDELETEBETA',
                    'type': 'Microsoft.Features/providers/features'  
              }
            ".Replace("'", "\"");

            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            string resourceProviderNamespace = "Providers.Test";

            string featureName = "DONOTDELETEBETA";

            // ----Verify API calls for get all features under current subid----
            var getResult = (await client.Features.GetAsync(resourceProviderNamespace, featureName)).Value;

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Get.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            //Valid payload
            //Construct expected URL
            string expectedUrl = "/subscriptions/" + Uri.EscapeDataString(TestEnvironment.SubscriptionId) + "/providers/Microsoft.Features/providers/" + Uri.EscapeDataString(resourceProviderNamespace) + "/features/" + Uri.EscapeDataString(featureName) + "?";
            expectedUrl = expectedUrl + "api-version=2015-12-01";
            string baseUrl = "https://management.azure.com";
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

            Assert.AreEqual(expectedUrl, request.Uri.ToString());
        }

        [Test]
        public async Task ListPreviewedFeatures()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            string contentString = @"{
                'value': [
                    {
                    'name': 'Providers.Test/DONOTDELETEBETA',
                    'properties': {
                    'state': 'NotRegistered'
                     },
                    'id': '/subscriptions/fda3b6ba-8803-441c-91fb-6cc798cf6ea0/providers/Microsoft.Features/providers/Providers.Test/features/DONOTDELETEBETA',
                    'type': 'Microsoft.Features/providers/features'   
                }
                ]}
            ";
            var content = JsonDocument.Parse(contentString.Replace("'", "\"")).RootElement.ToString();
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            string resourceProviderNamespace = "Providers.Test";

            //-------------Verify get all features within a resource provider
            var getResult = await client.Features.ListAsync(resourceProviderNamespace).ToEnumerableAsync();

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Get.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            //Valid payload
            //Construct expected URL
            string expectedUrl = "/subscriptions/" + Uri.EscapeDataString(TestEnvironment.SubscriptionId) + "/providers/Microsoft.Features/providers/" + Uri.EscapeDataString(resourceProviderNamespace) + "/features?";
            expectedUrl = expectedUrl + "api-version=2015-12-01";
            string baseUrl = "https://management.azure.com";
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

            Assert.AreEqual(expectedUrl, request.Uri.ToString());
        }

        [Test]
        public async Task ListAllPreviewedFeatures()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{                    
            'value': [
                    {
                    'name': 'Providers.Test/DONOTDELETEBETA',
                    'properties': {
                    'state': 'NotRegistered'
                     },
                    'id': '/subscriptions/fda3b6ba-8803-441c-91fb-6cc798cf6ea0/providers/Microsoft.Features/providers/Providers.Test/features/DONOTDELETEBETA',
                    'type': 'Microsoft.Features/providers/features'   
                }            
                ]}
            ".Replace("'", "\"");
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            //-------------Verify get all features within a resource provider
            var getResult = await client.Features.ListAllAsync().ToEnumerableAsync();

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Get.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            //Valid payload
            //Construct expected URL
            string expectedUrl = "/subscriptions/" + Uri.EscapeDataString(TestEnvironment.SubscriptionId) + "/providers/Microsoft.Features/features?";
            expectedUrl = expectedUrl + "api-version=2015-12-01";
            string baseUrl = "https://management.azure.com";
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

            Assert.AreEqual(expectedUrl, request.Uri.ToString());
        }
    }
}
