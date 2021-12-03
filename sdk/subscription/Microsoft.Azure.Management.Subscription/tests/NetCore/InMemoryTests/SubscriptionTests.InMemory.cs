// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Rest;
using Microsoft.Azure.Test.HttpRecorder;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Xunit;
using Microsoft.Azure.Management.Subscription;
using Microsoft.Azure.Management.Subscription.Models;
using System.Collections.Generic;

namespace ResourceGroups.Tests
{
    public class InMemorySubscriptionTests
    {

        private const string subscriptionId = "d17ad3ae-320e-42ff-b5a1-705389c6063a";
        public SubscriptionClient GetSubscriptionClient(RecordedDelegatingHandler handler)
        {
            var subscriptionId = Guid.NewGuid().ToString();
            var token = new TokenCredentials(subscriptionId, "abc123");
            handler.IsPassThrough = false;
            var client = new SubscriptionClient(token, handler);
            HttpMockServer.Mode = HttpRecorderMode.Playback;
            return client;
        }
        
        /*[Fact]
        public void AcceptSubscriptionOwnership()
        {
            var location = @"/providers/Microsoft.Subscription/subscriptionOperations/ODdmYTU0MDktODc5YS00ZTEzLTg2MWItNTQ4ZjYxNzBlOTQw?api-version=2021-10-01";

            var response = new HttpResponseMessage(HttpStatusCode.Accepted);
            //response.Headers.Location = new Uri(location);
            response.Headers.Add("Location", location);
            response.Headers.Add("RetryAfter", "8");
            response.Headers.Add("x-ms-request-id", "1");

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.Accepted };
            var client = GetSubscriptionClient(handler);

            var requestBody = new AcceptOwnershipRequest(
                new AcceptOwnershipRequestProperties()
                {
                    DisplayName = "Test Subscription",
                    Tags = new Dictionary<string, string>()
                    {
                         { "tag1", "Messi" }, { "tag2", "Ronaldo" }, { "tag3", "Lebron"}
                    }
                });

            var result = client.Subscription.AcceptOwnership(subscriptionId, requestBody);
            Assert.Equal(HttpMethod.Post, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));
            //Assert.Equal(location, result.Location);
            Assert.Equal(8, result.RetryAfter);
        }*/
        
        [Fact]
        public void GetAcceptSubscriptionOwnershipStatus()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'subscriptionId': '" + subscriptionId + @"',
                    'acceptOwnershipState': 'Pending',
                    'billingOwner': 'abc@test.com',
                    'subscriptionTenantId': '6c541ca7-1cab-4ea0-adde-6305e1d534e2',
                    'displayName': 'Test Subscription',
                    'tags': {
                        'tag1': 'TagValue1'
                    }
                }")
            };
            response.Headers.Add("x-ms-request-id", "1");

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetSubscriptionClient(handler);

            var result = client.Subscription.AcceptOwnershipStatus(subscriptionId);
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            Assert.Equal(subscriptionId, result.SubscriptionId);
            Assert.Equal("Pending", result.AcceptOwnershipState);
            Assert.Equal("abc@test.com", result.BillingOwner);
            Assert.Equal("6c541ca7-1cab-4ea0-adde-6305e1d534e2", result.SubscriptionTenantId);
            Assert.Equal("Test Subscription", result.DisplayName);
        }

        [Fact]
        public void AddUpdatePolicyForTenant()
        {
            var response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent(@"{
                    'id': 'providers/Microsoft.Subscription/policies/default',
                    'name': 'default',
                    'type': 'providers/Microsoft.Subscription/policies',
                    'properties': {
                        'policyId': '291bba3f-e0a5-47bc-a099-3bdcb2a50a05',
                        'blockSubscriptionsLeavingTenant': true,
                        'blockSubscriptionsIntoTenant': true,
                        'exemptedPrincipals': [
                            'e879cf0f-2b4d-5431-109a-f72fc9868693',
                            '9792da87-c97b-410d-a97d-27021ba09ce6'
                        ]
                     }
                }")
            };
            response.Headers.Add("x-ms-request-id", "1");

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetSubscriptionClient(handler);

            var result = client.SubscriptionPolicy.AddUpdatePolicyForTenant(new PutTenantPolicyRequestProperties()
            {
                BlockSubscriptionsIntoTenant = true,
                BlockSubscriptionsLeavingTenant = true,
                ExemptedPrincipals = new List<Guid?>()
                {
                    Guid.Parse("e879cf0f-2b4d-5431-109a-f72fc9868693"),
                    Guid.Parse("9792da87-c97b-410d-a97d-27021ba09ce6")
                }
            });
            Assert.Equal(HttpMethod.Put, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            Assert.Equal("providers/Microsoft.Subscription/policies/default", result.Id);
            Assert.Equal("default", result.Name);
            Assert.Equal("providers/Microsoft.Subscription/policies", result.Type);
            Assert.Equal("291bba3f-e0a5-47bc-a099-3bdcb2a50a05", result.Properties.PolicyId);
            Assert.True(result.Properties.BlockSubscriptionsIntoTenant);
            Assert.True(result.Properties.BlockSubscriptionsLeavingTenant);
            Assert.Equal("e879cf0f-2b4d-5431-109a-f72fc9868693", result.Properties.ExemptedPrincipals[0].ToString());
            Assert.Equal("9792da87-c97b-410d-a97d-27021ba09ce6", result.Properties.ExemptedPrincipals[1].ToString());
        }
        [Fact]
        public void GetPolicyForTenant()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'id': 'providers/Microsoft.Subscription/policies/default',
                    'name': 'default',
                    'type': 'providers/Microsoft.Subscription/policies',
                    'properties': {
                        'policyId': '291bba3f-e0a5-47bc-a099-3bdcb2a50a05',
                        'blockSubscriptionsLeavingTenant': true,
                        'blockSubscriptionsIntoTenant': true,
                        'exemptedPrincipals': [
                            'e879cf0f-2b4d-5431-109a-f72fc9868693',
                            '9792da87-c97b-410d-a97d-27021ba09ce6'
                        ]
                       }
                 }")
            };
            response.Headers.Add("x-ms-request-id", "1");

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = GetSubscriptionClient(handler);

            var result = client.SubscriptionPolicy.GetPolicyForTenant();
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            Assert.Equal("providers/Microsoft.Subscription/policies/default", result.Id);
            Assert.Equal("default", result.Name);
            Assert.Equal("providers/Microsoft.Subscription/policies", result.Type);
            Assert.Equal("291bba3f-e0a5-47bc-a099-3bdcb2a50a05", result.Properties.PolicyId);
            Assert.True(result.Properties.BlockSubscriptionsIntoTenant);
            Assert.True(result.Properties.BlockSubscriptionsLeavingTenant);
            Assert.Equal("e879cf0f-2b4d-5431-109a-f72fc9868693", result.Properties.ExemptedPrincipals[0].ToString());
            Assert.Equal("9792da87-c97b-410d-a97d-27021ba09ce6", result.Properties.ExemptedPrincipals[1].ToString());
        }

        /*[Fact]
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
        }*/
    }
}
