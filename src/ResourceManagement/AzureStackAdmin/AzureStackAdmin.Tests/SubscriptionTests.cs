// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Net;
using System.Net.Http;
using Microsoft.Azure;
using Microsoft.AzureStack.Management;
using Microsoft.AzureStack.Management.Models;
using Xunit;

namespace AzureStackAdmin.Tests
{
    public class SubscriptionTests
    {
        public AzureStackClient GetAzureStackAdminClient(RecordedDelegatingHandler handler)
        {
            var token = new TokenCloudCredentials(Guid.NewGuid().ToString(), "fake");
            handler.IsPassThrough = false;
            return new AzureStackClient(new Uri("https://armuri"), token, "2015-11-01").WithHandler(handler);
        }

        [Fact]
        public void GetSubscription()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'id': '/subscriptions/7B9E2B97-C218-4577-9582-6F390D5CD2E7/providers/Microsoft.Subscriptions/subscriptions/001f675f-daad-4357-993f-2203a22a1935',
                    'subscriptionId': '001f675f-daad-4357-993f-2203a22a1935',
                    'displayName': 'TestUser',
                    'owner': 'test@microsoft.com',
                    'tenantId': '4993704a-4e53-4e79-95dd-5f1747eb7554',
                    'offerId': '/subscriptions/7B9E2B97-C218-4577-9582-6F390D5CD2E7/resourceGroups/TestRG/providers/Microsoft.Subscriptions.Admin/offers/TestOffer',
                    'state': 'Enabled'
                }")
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = this.GetAzureStackAdminClient(handler);

            var result = client.ManagedSubscriptions.Get("001f675f-daad-4357-993f-2203a22a1935");
            
            // Validate Headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal("001f675f-daad-4357-993f-2203a22a1935", result.Subscription.SubscriptionId);
            Assert.Equal("/subscriptions/7B9E2B97-C218-4577-9582-6F390D5CD2E7/resourceGroups/TestRG/providers/Microsoft.Subscriptions.Admin/offers/TestOffer", result.Subscription.OfferId);
            Assert.Equal("test@microsoft.com", result.Subscription.Owner);
            Assert.Equal(SubscriptionState.Enabled, result.Subscription.State);
            Assert.Equal("4993704a-4e53-4e79-95dd-5f1747eb7554", result.Subscription.TenantId);
        }

        [Fact]
        public void CreateOrUpdateSubscription()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'id': '/subscriptions/7B9E2B97-C218-4577-9582-6F390D5CD2E7/providers/Microsoft.Subscriptions/subscriptions/001f675f-daad-4357-993f-2203a22a1935',
                    'subscriptionId': '001f675f-daad-4357-993f-2203a22a1935',
                    'displayName': 'TestUser',
                    'owner': 'test@microsoft.com',
                    'tenantId': '4993704a-4e53-4e79-95dd-5f1747eb7554',
                    'offerId': '/subscriptions/7B9E2B97-C218-4577-9582-6F390D5CD2E7/resourceGroups/TestRG/providers/Microsoft.Subscriptions.Admin/offers/TestOffer',
                    'state': 'Enabled'
                }")
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = this.GetAzureStackAdminClient(handler);

            var result = client.ManagedSubscriptions.CreateOrUpdate(
                new ManagedSubscriptionCreateOrUpdateParameters()
                {
                    Subscription = new AdminSubscriptionDefinition()
                                   {
                                       DisplayName = "TestUser",
                                       Id = "001f675f-daad-4357-993f-2203a22a1935",
                                       Owner = "test@microsoft.com",
                                       OfferId = "/subscriptions/7B9E2B97-C218-4577-9582-6F390D5CD2E7/resourceGroups/TestRG/providers/Microsoft.Subscriptions.Admin/offers/TestOffer",
                                       State = SubscriptionState.Enabled,
                                       TenantId = "4993704a-4e53-4e79-95dd-5f1747eb7554"
                                   }
                }
            );

            // Validate Headers
            Assert.Equal(HttpMethod.Put, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal("001f675f-daad-4357-993f-2203a22a1935", result.Subscription.SubscriptionId);
            Assert.Equal("/subscriptions/7B9E2B97-C218-4577-9582-6F390D5CD2E7/resourceGroups/TestRG/providers/Microsoft.Subscriptions.Admin/offers/TestOffer", result.Subscription.OfferId);
            Assert.Equal("test@microsoft.com", result.Subscription.Owner);
            Assert.Equal(SubscriptionState.Enabled, result.Subscription.State);
            Assert.Equal("4993704a-4e53-4e79-95dd-5f1747eb7554", result.Subscription.TenantId);
        }

        [Fact]
        public void DeleteSubscription()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = this.GetAzureStackAdminClient(handler);

            var result = client.ManagedSubscriptions.Delete("001f675f-daad-4357-993f-2203a22a1935");

            // Validate headers
            Assert.Equal(HttpMethod.Delete, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

        }
    }
}
