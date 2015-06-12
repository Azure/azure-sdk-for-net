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
using System.Net;
using System.Net.Http;
using Microsoft.Azure;
using Microsoft.Azure.Test;
using Microsoft.Commerce.UsageAggregates;
using Microsoft.Commerce.UsageAggregates.Models;
using UsageAggregates.Tests;
using Xunit;

namespace ScenarioTests
{
    public class GetUsageForSubscription : TestBase
    {
        public UsageAggregationManagementClient GetUsageAggregationManagementClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = false;

            var token = new TokenCloudCredentials(Guid.NewGuid().ToString(), "abc123");
            UsageAggregationManagementClient client = new UsageAggregationManagementClient(token, new Uri("https://mn-azure/management/"));
            client = client.WithHandler(handler);
            return client;
        }

        private DateTime startDate = new DateTime(2016, 5, 1);
        private DateTime endDate = new DateTime(2016, 5, 2);
        
        [Fact]
        public void GetAggregate()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(HttpPayload.GetOneAggregates)
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetUsageAggregationManagementClient(handler);

            UsageAggregationGetResponse result = client.UsageAggregates.Get(startDate, endDate, AggregationGranularity.Daily,
                false, null);

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);

            Assert.Equal(1, result.UsageAggregations.Count);
        }
    }
}
