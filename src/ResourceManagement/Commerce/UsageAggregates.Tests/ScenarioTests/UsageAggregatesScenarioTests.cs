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
using Microsoft.Azure.Commerce.UsageAggregates;
using Microsoft.Azure.Commerce.UsageAggregates.Models;
using UsageAggregates.Tests;
using Xunit;

namespace UsageAggregatesTest.ScenarioTests
{
    public class UsageAggregatesScenarioTests : TestBase
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

        [Fact]
        public void GetAggregates()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(HttpPayload.GetThreeAggregates)
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetUsageAggregationManagementClient(handler);

            UsageAggregationGetResponse result = client.UsageAggregates.Get(startDate, endDate, AggregationGranularity.Daily,
                false, null);

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);

            Assert.Equal(3, result.UsageAggregations.Count);
        }


        [Fact]
        public void VerifyInfoFields()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(HttpPayload.AggregateInfoField)
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetUsageAggregationManagementClient(handler);

            UsageAggregationGetResponse result = client.UsageAggregates.Get(startDate, endDate, AggregationGranularity.Daily,
                false, null);

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);

            // Validate "infoFields":{"meteredRegion":"East","meteredService":"Database","meteredServiceType":"P3","project":"audittest"}
            InfoField infoFields = result.UsageAggregations[0].Properties.InfoFields;
            Assert.Equal("audittest", infoFields.Project);
        }

        [Fact]
        public void VerifyInstanceData()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(HttpPayload.AggregateInstanceData)
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetUsageAggregationManagementClient(handler);

            UsageAggregationGetResponse result = client.UsageAggregates.Get(startDate, endDate, AggregationGranularity.Daily,
                false, null);

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);

            string instanceData = result.UsageAggregations[0].Properties.InstanceData;
            
            Assert.False(string.IsNullOrEmpty(instanceData));

        }

        [Fact]
        public void VerifyTheDateFieldsRemainAsUniversalTime()
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

            UsageAggregation ua = result.UsageAggregations[0];

            DateTime expectedStartTime = new DateTime(2015, 6, 1, 11, 0, 0);
            DateTime expectedEndTime = new DateTime(2015, 6, 1, 12, 0, 0);

            Assert.True(expectedStartTime == ua.Properties.UsageStartTime, "expectedStartTime == ua.Properties.UsageStartTime");
            Assert.True(expectedEndTime == ua.Properties.UsageEndTime, "expectedEndTime == ua.Properties.UsageEndTime");
        }

        [Fact]
        public void ContinuationTokenShouldBeCorrectlyParsedFromNextLink()
        {
            const string expectedToken =
                "eyJyIjoiMjAxNTA2MDItNjM1Njg4NDMyMDAwMDAwMDAwIiwiaSI6IkhYSDhoekRQUnBFM3NZTVE1bDB5YW5MNTFsUWw3Nzdwd3FWMzhFdDFqb2pqS3Vza0JwSWNkQWozOXRuSjYwNjhqd0ZzYXBEUGhRa0VhSXJKOWtxMjNnPT0iLCJzIjoicEpWME0rRT0ifQ==";

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

            string actualToken = result.ContinuationToken;
            Assert.True(expectedToken.Equals(actualToken, StringComparison.OrdinalIgnoreCase), "The continuation token didn't match up");
        }

        [Fact]
        public void MeterResourceIdHandlesBothStringAndGuid()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(HttpPayload.GetAggregateWithNonGuidResourceId)
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var client = GetUsageAggregationManagementClient(handler);

            UsageAggregationGetResponse result = client.UsageAggregates.Get(startDate, endDate, AggregationGranularity.Daily,
                false, null);

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);

            UsageAggregation ua = result.UsageAggregations[0];

            Assert.True("AzureSql" == ua.Properties.MeterId, "AzureSql == ua.Properties.MeterId");
        }
    }
}
