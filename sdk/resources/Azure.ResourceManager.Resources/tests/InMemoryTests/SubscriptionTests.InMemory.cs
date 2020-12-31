// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Tests;
using NUnit.Framework;

namespace ResourceGroups.Tests
{
    public class InMemorySubscriptionTests : ResourceOperationsTestsBase
    {
        public InMemorySubscriptionTests(bool isAsync) : base(isAsync)
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
        public async Task ListSubscriptionLocations()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{
	                'value': [{
		                'id': '/subscriptions/9167af2d-c13e-4d34-9a57-8f37dba6ff31/locations/eastasia',
		                'name': 'eastasia',
		                'displayName': 'East Asia',
                        'metadata': {
                            'longitude': '114.188',
		                    'latitude': '22.267'
                        }
	                },
	                {
		                'id': '/subscriptions/9167af2d-c13e-4d34-9a57-8f37dba6ff31/locations/southeastasia',
		                'name': 'southeastasia',
		                'displayName': 'Southeast Asia',
                        'metadata': {
                            'longitude': '103.833',
    		                'latitude': '1.283'
                        }
	                }]
                }".Replace("'", "\"");
            var header = new HttpHeader("x-ms-request-id", "1");
            mockResponse.AddHeader(header);
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            string subscriptionId = "9167af2d-c13e-4d34-9a57-8f37dba6ff31";

            var listLocationsResult = await client.Subscriptions.ListLocationsAsync(subscriptionId).ToEnumerableAsync();

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Get.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            // Validate result
            Assert.NotNull(listLocationsResult);
            Assert.AreEqual("/subscriptions/9167af2d-c13e-4d34-9a57-8f37dba6ff31/locations/eastasia", listLocationsResult.FirstOrDefault().Id);
            Assert.AreEqual("eastasia", listLocationsResult.FirstOrDefault().Name);
            Assert.AreEqual("East Asia", listLocationsResult.FirstOrDefault().DisplayName);
            Assert.AreEqual("114.188", listLocationsResult.FirstOrDefault().Metadata.Longitude);
            Assert.AreEqual("22.267", listLocationsResult.FirstOrDefault().Metadata.Latitude);
        }

        [Test]
        public async Task ListSubscriptions()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{
	                'value': [{
		                'id': '/subscriptions/38b598fc-e57a-423f-b2e7-dc0ddb631f1f',
		                'subscriptionId': '38b598fc-e57a-423f-b2e7-dc0ddb631f1f',
		                'displayName': 'Visual Studio Ultimate with MSDN',
		                'state': 'Disabled',
		                'subscriptionPolicies': {
			                'locationPlacementId': 'Public_2014-09-01',
			                'quotaId': 'MSDN_2014-09-01'
		                }
	                },
	                {
		                'id': '/subscriptions/9167af2d-c13e-4d34-9a57-8f37dba6ff31',
		                'subscriptionId': '9167af2d-c13e-4d34-9a57-8f37dba6ff31',
		                'displayName': 'Subscription-1',
		                'state': 'Enabled',
		                'subscriptionPolicies': {
			                'locationPlacementId': 'Internal_2014-09-01',
			                'quotaId': 'Internal_2014-09-01'
		                }
	                },
	                {
		                'id': '/subscriptions/78814224-3c2d-4932-9fe3-913da0f278ee',
		                'subscriptionId': '78814224-3c2d-4932-9fe3-913da0f278ee',
		                'displayName': 'Cloud Tools Development',
		                'state': 'Enabled',
		                'subscriptionPolicies': {
			                'locationPlacementId': 'Internal_2014-09-01',
			                'quotaId': 'Internal_2014-09-01'
		                }
	                }]
                }".Replace("'", "\"");
            var header = new HttpHeader("x-ms-request-id", "1");
            mockResponse.AddHeader(header);
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            var listSubscriptionsResult = await client.Subscriptions.ListAsync().ToEnumerableAsync();

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Get.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            // Validate result
            Assert.NotNull(listSubscriptionsResult);
            Assert.AreEqual("/subscriptions/38b598fc-e57a-423f-b2e7-dc0ddb631f1f", listSubscriptionsResult.FirstOrDefault().Id);
            Assert.AreEqual("38b598fc-e57a-423f-b2e7-dc0ddb631f1f", listSubscriptionsResult.FirstOrDefault().SubscriptionId);
            Assert.AreEqual("Visual Studio Ultimate with MSDN", listSubscriptionsResult.FirstOrDefault().DisplayName);
            Assert.AreEqual("Disabled", listSubscriptionsResult.FirstOrDefault().State.ToString());
            Assert.NotNull(listSubscriptionsResult.FirstOrDefault().SubscriptionPolicies);
            Assert.AreEqual("Public_2014-09-01", listSubscriptionsResult.FirstOrDefault().SubscriptionPolicies.LocationPlacementId);
            Assert.AreEqual("MSDN_2014-09-01", listSubscriptionsResult.FirstOrDefault().SubscriptionPolicies.QuotaId);
        }

        [Test]
        public async Task GetSubscription()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{
	                'id': '/subscriptions/38b598fc-e57a-423f-b2e7-dc0ddb631f1f',
	                'subscriptionId': '38b598fc-e57a-423f-b2e7-dc0ddb631f1f',
	                'displayName': 'Visual Studio Ultimate with MSDN',
	                'state': 'Disabled',
                    'tags': {
                        'tagsTestKey': 'tagsTestValue'
                    },
	                'subscriptionPolicies': {
		                'locationPlacementId': 'Public_2014-09-01',
		                'quotaId': 'MSDN_2014-09-01'
                    }
                }".Replace("'", "\"");
            var header = new HttpHeader("x-ms-request-id", "1");
            mockResponse.AddHeader(header);
            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(mockResponse);
            var client = GetResourceManagementClient(mockTransport);

            string subscriptionId = "9167af2d-c13e-4d34-9a57-8f37dba6ff31";

            var getSubscriptionResult = (await client.Subscriptions.GetAsync(subscriptionId)).Value;

            // Validate headers
            var request = mockTransport.Requests[0];
            Assert.AreEqual(HttpMethod.Get.Method, request.Method.Method);
            Assert.IsTrue(request.Headers.Contains("Authorization"));

            // Validate result
            Assert.NotNull(getSubscriptionResult);
            Assert.AreEqual("/subscriptions/38b598fc-e57a-423f-b2e7-dc0ddb631f1f", getSubscriptionResult.Id);
            Assert.AreEqual("38b598fc-e57a-423f-b2e7-dc0ddb631f1f", getSubscriptionResult.SubscriptionId);
            Assert.AreEqual("Visual Studio Ultimate with MSDN", getSubscriptionResult.DisplayName);
            Assert.AreEqual("Disabled", getSubscriptionResult.State.ToString());
            Assert.NotNull(getSubscriptionResult.SubscriptionPolicies);
            Assert.AreEqual("Public_2014-09-01", getSubscriptionResult.SubscriptionPolicies.LocationPlacementId);
            Assert.AreEqual("MSDN_2014-09-01", getSubscriptionResult.SubscriptionPolicies.QuotaId);
            Assert.NotNull(getSubscriptionResult.Tags);
            Assert.True(getSubscriptionResult.Tags.ContainsKey("tagsTestKey"));
            Assert.AreEqual("tagsTestValue", getSubscriptionResult.Tags["tagsTestKey"]);
        }
    }
}
