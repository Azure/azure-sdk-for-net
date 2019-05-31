// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest;
using Microsoft.Azure.Test.HttpRecorder;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Xunit;


namespace ResourceGroups.Tests
{
    public class InMemorySubscriptionTests
    {
        public SubscriptionClient GetSubscriptionClient(RecordedDelegatingHandler handler)
        {
            var subscriptionId = Guid.NewGuid().ToString();
            var token = new TokenCredentials(subscriptionId, "abc123");
            handler.IsPassThrough = false;
            var client = new SubscriptionClient(token, handler);
            HttpMockServer.Mode = HttpRecorderMode.Playback;
            return client;
        }

        [Fact]
        public void ListSubscriptionLocations()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
	                'value': [{
		                'id': '/subscriptions/9167af2d-c13e-4d34-9a57-8f37dba6ff31/locations/eastasia',
		                'name': 'eastasia',
		                'displayName': 'East Asia',
		                'longitude': '114.188',
		                'latitude': '22.267'
	                },
	                {
		                'id': '/subscriptions/9167af2d-c13e-4d34-9a57-8f37dba6ff31/locations/southeastasia',
		                'name': 'southeastasia',
		                'displayName': 'Southeast Asia',
		                'longitude': '103.833',
		                'latitude': '1.283'
	                }]
                }")
            };

            response.Headers.Add("x-ms-request-id", "1");

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetSubscriptionClient(handler);

            string subscriptionId = "9167af2d-c13e-4d34-9a57-8f37dba6ff31";

            var listLocationsResult = client.Subscriptions.ListLocations(subscriptionId);

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.NotNull(listLocationsResult);
            Assert.Equal("/subscriptions/9167af2d-c13e-4d34-9a57-8f37dba6ff31/locations/eastasia", listLocationsResult.FirstOrDefault().Id);
            Assert.Equal("eastasia", listLocationsResult.FirstOrDefault().Name);
            Assert.Equal("East Asia", listLocationsResult.FirstOrDefault().DisplayName);
            Assert.Equal("114.188", listLocationsResult.FirstOrDefault().Longitude);
            Assert.Equal("22.267", listLocationsResult.FirstOrDefault().Latitude);
        }

        [Fact]
        public void ListSubscriptions()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
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
                }")
            };

            response.Headers.Add("x-ms-request-id", "1");

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetSubscriptionClient(handler);

            var listSubscriptionsResult = client.Subscriptions.List();

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.NotNull(listSubscriptionsResult);
            Assert.Equal("/subscriptions/38b598fc-e57a-423f-b2e7-dc0ddb631f1f", listSubscriptionsResult.FirstOrDefault().Id);
            Assert.Equal("38b598fc-e57a-423f-b2e7-dc0ddb631f1f", listSubscriptionsResult.FirstOrDefault().SubscriptionId);
            Assert.Equal("Visual Studio Ultimate with MSDN", listSubscriptionsResult.FirstOrDefault().DisplayName);
            Assert.Equal("Disabled", listSubscriptionsResult.FirstOrDefault().State.ToString());
            Assert.NotNull(listSubscriptionsResult.FirstOrDefault().SubscriptionPolicies);
            Assert.Equal("Public_2014-09-01", listSubscriptionsResult.FirstOrDefault().SubscriptionPolicies.LocationPlacementId);
            Assert.Equal("MSDN_2014-09-01", listSubscriptionsResult.FirstOrDefault().SubscriptionPolicies.QuotaId);
        }

        [Fact]
        public void GetSubscription()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
	                'id': '/subscriptions/38b598fc-e57a-423f-b2e7-dc0ddb631f1f',
	                'subscriptionId': '38b598fc-e57a-423f-b2e7-dc0ddb631f1f',
	                'displayName': 'Visual Studio Ultimate with MSDN',
	                'state': 'Disabled',
	                'subscriptionPolicies': {
		                'locationPlacementId': 'Public_2014-09-01',
		                'quotaId': 'MSDN_2014-09-01'
	                }
                }")
            };

            response.Headers.Add("x-ms-request-id", "1");

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetSubscriptionClient(handler);

            string subscriptionId = "9167af2d-c13e-4d34-9a57-8f37dba6ff31";

            var getSubscriptionResult = client.Subscriptions.Get(subscriptionId);

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.NotNull(getSubscriptionResult);
            Assert.Equal("/subscriptions/38b598fc-e57a-423f-b2e7-dc0ddb631f1f", getSubscriptionResult.Id);
            Assert.Equal("38b598fc-e57a-423f-b2e7-dc0ddb631f1f", getSubscriptionResult.SubscriptionId);
            Assert.Equal("Visual Studio Ultimate with MSDN", getSubscriptionResult.DisplayName);
            Assert.Equal("Disabled", getSubscriptionResult.State.ToString());
            Assert.NotNull(getSubscriptionResult.SubscriptionPolicies);
            Assert.Equal("Public_2014-09-01", getSubscriptionResult.SubscriptionPolicies.LocationPlacementId);
            Assert.Equal("MSDN_2014-09-01", getSubscriptionResult.SubscriptionPolicies.QuotaId);
        }
    }
}
