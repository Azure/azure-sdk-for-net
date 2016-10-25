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
    public class PlanTests
    {
        public AzureStackClient GetAzureStackAdminClient(RecordedDelegatingHandler handler)
        {
            var token = new TokenCloudCredentials(Guid.NewGuid().ToString(), "abc123");
            handler.IsPassThrough = false;
            return new AzureStackClient(new Uri("https://armuri"), token, "2015-11-01").WithHandler(handler);
        }

        [Fact]
        public void GetPlan()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'id': '/subscriptions/7354d868-a0a8-47b0-9566-6e753aec1754/resourceGroups/TestRG/providers/Microsoft.Subscriptions.Admin/plans/TestPlan',
                    'name': 'TestPlan',
                    'type': 'Microsoft.Subscriptions.Admin/plans',
                    'location': 'local',
                    'properties': {
                        'name': 'TestPlan',
                        'displayName': 'TestPlan',
                        'subscriptionCount': 0,
                        'quotaIds': [
                            '/subscriptions/7354d868-a0a8-47b0-9566-6e753aec1754/providers/Microsoft.Sql.Admin/locations/local/quotas/Default_BasicTierQuota'
                        ]
                    }
                }")
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = this.GetAzureStackAdminClient(handler);

            var result = client.ManagedPlans.Get("TestRG", "TestPlan");
            
            // Validate Headers
            Assert.Equal(HttpMethod.Get, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal("TestPlan", result.Plan.Name);
            Assert.Equal("local", result.Plan.Location);
            Assert.Equal(0, result.Plan.Properties.SubscriptionCount);
            Assert.Equal("/subscriptions/7354d868-a0a8-47b0-9566-6e753aec1754/providers/Microsoft.Sql.Admin/locations/local/quotas/Default_BasicTierQuota", result.Plan.Properties.QuotaIds[0]);
        }

        [Fact]
        public void CreateOrUpdatePlan()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(@"{
                    'id': '/subscriptions/7354d868-a0a8-47b0-9566-6e753aec1754/resourceGroups/TestRG-3e1d9655-b0c4-487d-9b9e-027748e8914d/providers/Microsoft.Subscriptions.Admin/plans/TestPlan',
                    'name': 'TestPlan',
                    'type': 'Microsoft.Subscriptions.Admin/plans',
                    'location': 'local',
                    'properties': {
                        'name': 'TestPlan',
                        'displayName': 'TestPlan',
                        'subscriptionCount': 0,
                        'quotaIds': [
                            '/subscriptions/7354d868-a0a8-47b0-9566-6e753aec1754/providers/Microsoft.Sql.Admin/locations/local/quotas/Default_BasicTierQuota'
                        ]
                    }
                }")
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = this.GetAzureStackAdminClient(handler);

            var result = client.ManagedPlans.CreateOrUpdate(
                "TestRG",
                new ManagedPlanCreateOrUpdateParameters()
                {
                    Plan = new AdminPlanModel()
                           {
                               Location = "local",
                               Name = "TestPlan",
                               Properties = new AdminPlanPropertiesDefinition()
                                            {
                                                Name = "TestPlan",
                                                DisplayName = "TestPlan",
                                                QuotaIds = new []{"/subscriptions/7354d868-a0a8-47b0-9566-6e753aec1754/providers/Microsoft.Sql.Admin/locations/local/quotas/Default_BasicTierQuota"}
                                            }
                           }
                }
            );

            // Validate Headers
            Assert.Equal(HttpMethod.Put, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal("TestPlan", result.Plan.Name);
            Assert.Equal("local", result.Plan.Location);
            Assert.Equal(0, result.Plan.Properties.SubscriptionCount);
            Assert.Equal("/subscriptions/7354d868-a0a8-47b0-9566-6e753aec1754/providers/Microsoft.Sql.Admin/locations/local/quotas/Default_BasicTierQuota", result.Plan.Properties.QuotaIds[0]);
        }

        [Fact]
        public void DeletePlan()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var client = this.GetAzureStackAdminClient(handler);

            var result = client.ManagedPlans.Delete("TestRG", "TestPlan");

            // Validate headers
            Assert.Equal(HttpMethod.Delete, handler.Method);
            Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));

            // Validate result
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

        }
    }
}
