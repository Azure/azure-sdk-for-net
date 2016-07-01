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
    public class OfferTests
    {
        public AzureStackClient GetAzureStackAdminClient(RecordedDelegatingHandler handler)
        {
            var token = new TokenCloudCredentials(Guid.NewGuid().ToString(), "abc123");
            handler.IsPassThrough = false;
            return new AzureStackClient(new Uri("https://armuri"), token, "2015-11-01").WithHandler(handler);
        }

        [Fact]
        public void GetOffer()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'id': '/subscriptions/ade8c959-cf50-475a-83f1-5851c07902de/resourceGroups/TestRG/providers/Microsoft.Subscriptions.Admin/offers/TestOffer',
                    'name': 'TestOffer',
                    'type': 'Microsoft.Subscriptions.Admin/offers',
                    'location': 'local',
                    'properties': {
                        'name': 'TestOffer',
                        'displayName': 'TestOffer',
                        'state': 'Private',
                        'subscriptionCount': 0,
                        'maxSubscriptionsPerAccount': 2,
                        'basePlanIds': [
                            '/subscriptions/ADE8C959-CF50-475A-83F1-5851C07902DE/resourceGroups/TestRG/providers/Microsoft.Subscriptions.Admin/plans/TestPlan'
                        ],
                        'addonPlans': [
                        ]
                    }
                }")
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = this.GetAzureStackAdminClient(handler);

            var result = client.ManagedOffers.Get("TestRG", "TestOffer");

            // Validate Headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal("TestOffer", result.Offer.Name);
            Assert.Equal("local", result.Offer.Location);
            Assert.Equal(0, result.Offer.Properties.SubscriptionCount);
            Assert.Equal(2, result.Offer.Properties.MaxSubscriptionsPerAccount);
            Assert.Equal(AccessibilityState.Private, result.Offer.Properties.State);
            Assert.Equal("/subscriptions/ADE8C959-CF50-475A-83F1-5851C07902DE/resourceGroups/TestRG/providers/Microsoft.Subscriptions.Admin/plans/TestPlan", result.Offer.Properties.BasePlanIds[0]);
            Assert.Equal(0, result.Offer.Properties.AddonPlans.Count);
        }

        [Fact]
        public void CreateOrUpdateOffer()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'id': '/subscriptions/ade8c959-cf50-475a-83f1-5851c07902de/resourceGroups/TestRG/providers/Microsoft.Subscriptions.Admin/offers/TestOffer',
                    'name': 'TestOffer',
                    'type': 'Microsoft.Subscriptions.Admin/offers',
                    'location': 'local',
                    'properties': {
                        'name': 'TestOffer',
                        'displayName': 'TestOffer',
                        'state': 'Private',
                        'subscriptionCount': 0,
                        'maxSubscriptionsPerAccount': 2,
                        'basePlanIds': [
                            '/subscriptions/ADE8C959-CF50-475A-83F1-5851C07902DE/resourceGroups/TestRG/providers/Microsoft.Subscriptions.Admin/plans/TestPlan'
                        ],
                        'addonPlans': [
                        ]
                    }
                }")
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = this.GetAzureStackAdminClient(handler);

            var result = client.ManagedOffers.CreateOrUpdate(
                "TestRG",
                new ManagedOfferCreateOrUpdateParameters()
                {
                    Offer = new AdminOfferModel()
                            {
                                Name = "TestOffer",
                                Location = "local",
                                Properties = new AdminOfferPropertiesDefinition()
                                             {
                                                 Name = "TestOffer",
                                                 DisplayName = "TestOffer",
                                                 BasePlanIds = new[] { "/subscriptions/ADE8C959-CF50-475A-83F1-5851C07902DE/resourceGroups/TestRG/providers/Microsoft.Subscriptions.Admin/plans/TestPlan" },
                                                 MaxSubscriptionsPerAccount = 2,
                                                 State = AccessibilityState.Private
                                             }
                            }
                }
            );

            // Validate Headers
            Assert.Equal(HttpMethod.Put, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal("TestOffer", result.Offer.Name);
            Assert.Equal("local", result.Offer.Location);
            Assert.Equal(0, result.Offer.Properties.SubscriptionCount);
            Assert.Equal(2, result.Offer.Properties.MaxSubscriptionsPerAccount);
            Assert.Equal(AccessibilityState.Private, result.Offer.Properties.State);
            Assert.Equal("/subscriptions/ADE8C959-CF50-475A-83F1-5851C07902DE/resourceGroups/TestRG/providers/Microsoft.Subscriptions.Admin/plans/TestPlan", result.Offer.Properties.BasePlanIds[0]);
            Assert.Equal(0, result.Offer.Properties.AddonPlans.Count);
        }

        [Fact]
        public void DeleteOffer()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = this.GetAzureStackAdminClient(handler);

            var result = client.ManagedOffers.Delete("TestRG", "TestOffer");

            // Validate headers
            Assert.Equal(HttpMethod.Delete, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

        }
    }
}
