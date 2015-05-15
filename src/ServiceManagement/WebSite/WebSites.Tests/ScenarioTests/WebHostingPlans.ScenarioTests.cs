//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Linq;
using System.Net;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Management.WebSites;
using Microsoft.WindowsAzure.Management.WebSites.Models;
using Microsoft.Azure.Test;
using Xunit;
using System.Net.Http;

namespace WebSites.Tests.ScenarioTests
{
    public class WebHostingPlansScenarioTests : TestBase
    {
        public WebSiteManagementClient GetWebSiteManagementClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = false;
            var token = new TokenCloudCredentials(Guid.NewGuid().ToString(), "abc123");
            var client = new WebSiteManagementClient(token).WithHandler(handler);
            client = client.WithHandler(handler);
            return client;
        }

        [Fact]
        public void ListWebHostingPlans()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(HttpPayload.ListWebHostingPlans)
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetWebSiteManagementClient(handler);

            var result = client.WebHostingPlans.List("space1");

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);

            // Validate response 
            Assert.NotNull(result.WebHostingPlans);
            Assert.Equal(1, result.WebHostingPlans.Count);
            Assert.NotNull(result.WebHostingPlans.ElementAt(0));
            Assert.Equal("Default1", result.WebHostingPlans.ElementAt(0).Name);
            Assert.Equal(SkuOptions.Standard, result.WebHostingPlans.ElementAt(0).SKU);
            Assert.Equal(1, result.WebHostingPlans.ElementAt(0).NumberOfWorkers);
            Assert.Equal("adminsite1", result.WebHostingPlans.ElementAt(0).AdminSiteName);
        }

        [Fact]
        public void GetWebHostingPlan()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(HttpPayload.GetWebHostingPlan)
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetWebSiteManagementClient(handler);

            var result = client.WebHostingPlans.Get("space1", "Default1");

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);

            // Validate response 
            Assert.NotNull(result);
            Assert.Equal("Default1", result.WebHostingPlan.Name);
            Assert.Equal(SkuOptions.Standard, result.WebHostingPlan.SKU);
            Assert.Equal(1, result.WebHostingPlan.NumberOfWorkers);
            Assert.Equal("adminsite1", result.WebHostingPlan.AdminSiteName);
        }

        [Fact]
        public void GetWebHostingPlanMetrics()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(HttpPayload.GetWebHostingPlanMetrics)
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetWebSiteManagementClient(handler);

            var result = client.WebHostingPlans.GetHistoricalUsageMetrics("space1", "Default1", 
                new WebHostingPlanGetHistoricalUsageMetricsParameters
                {
                    TimeGrain = "PT1M",
                IncludeInstanceBreakdown = true,
                });

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);

            // Validate response 
            Assert.NotNull(result);
            Assert.NotNull(result.UsageMetrics);
            Assert.NotNull(result.UsageMetrics[0]);
            Assert.NotNull(result.UsageMetrics[0].Data);
            Assert.Equal("CpuPercentage", result.UsageMetrics[0].Data.Name);
            Assert.NotNull(result.UsageMetrics[0].Data.Values);
            Assert.Equal("PT1M", result.UsageMetrics[0].Data.TimeGrain);
            Assert.Equal("6", result.UsageMetrics[0].Data.Values[0].Total);
            Assert.Equal("Average", result.UsageMetrics[0].Data.PrimaryAggregationType);

            // check instance level data
            Assert.NotNull(result.UsageMetrics[1]);
            Assert.NotNull(result.UsageMetrics[1].Data);
            Assert.Equal("CpuPercentage", result.UsageMetrics[1].Data.Name);
            Assert.NotNull(result.UsageMetrics[1].Data.Values);
            Assert.Equal("PT1M", result.UsageMetrics[1].Data.TimeGrain);
            Assert.Equal("6", result.UsageMetrics[1].Data.Values[0].Total);
            Assert.Equal("Instance", result.UsageMetrics[1].Data.PrimaryAggregationType);
        }
    }
}
