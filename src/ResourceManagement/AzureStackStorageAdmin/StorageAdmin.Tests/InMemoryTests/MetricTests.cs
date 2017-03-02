//
//  <copyright file="MetricTests.cs" company="Microsoft">
//    Copyright (C) Microsoft. All rights reserved.
//  </copyright>
//

// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Net;
using System.Net.Http;
using Microsoft.Azure;
using Microsoft.AzureStack.AzureConsistentStorage;
using Microsoft.AzureStack.AzureConsistentStorage.Models;
using Xunit;

namespace Microsoft.AzureStack.AzureConsistentStorage.Tests
{
    public class MetricTests : TestBase
    {
        // {4} is metric defintion filter
        private const string FarmMetricDefinitionsUriTemplate =
            "{0}/subscriptions/{1}/resourcegroups/{2}/providers/Microsoft.Storage.Admin/farms/{3}/metricdefinitions"
            + "?" + Constants.ApiVersionParameter
            + "&$filter={4}";

        // {4} is metric filter
        private const string FarmMetricsUriTemplate =
            "{0}/subscriptions/{1}/resourcegroups/{2}/providers/Microsoft.Storage.Admin/farms/{3}/metrics"
            + "?" + Constants.ApiVersionParameter
            + "&$filter={4}";

        private const string SubResourceMetricDefinitionsUriTemplate =
            "{0}/subscriptions/{1}/resourcegroups/{2}/providers/Microsoft.Storage.Admin/farms/{3}/{4}/{5}/metricdefinitions"
            + "?" + Constants.ApiVersionParameter
            + "&$filter={6}";

        private const string SubResourceMetricsUriTemplate =
            "{0}/subscriptions/{1}/resourcegroups/{2}/providers/Microsoft.Storage.Admin/farms/{3}/{4}/{5}/metrics"
            + "?" + Constants.ApiVersionParameter
            + "&$filter={6}";


        [Fact]
        public void GetFarmMetricDefinitions()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.MetricDefinitionResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);

            var client = GetClient(handler, token);

            const string filter = "name";

            var result = client.Farms.GetMetricDefinitions(Constants.ResourceGroupName, Constants.FarmId, filter);

            // validate requestor
            Assert.Equal(handler.Method, HttpMethod.Get);

            var expectedUri = string.Format(
                FarmMetricDefinitionsUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId,
                filter);

            Assert.Equal(expectedUri, handler.Uri.AbsoluteUri);

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);

            CompareMetricDefinition(result);
        }

        [Fact]
        public void GetFarmMetrics()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.MetricResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);

            var client = GetClient(handler, token);

            const string filter = "name";

            var result = client.Farms.GetMetrics(Constants.ResourceGroupName, Constants.FarmId, filter);

            // validate requestor
            Assert.Equal(handler.Method, HttpMethod.Get);

            var expectedUri = string.Format(
                FarmMetricsUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId,
                filter);

            Assert.Equal(handler.Uri.AbsoluteUri, expectedUri);

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);

            CompareMetric(result);
        }

        [Fact]
        public void GetShareMetricDefinitions()
        {
            VerifyGetSubResourceMetricDefinitions(Constants.ShareType, Constants.ShareName,
                SubResourceMetricDefinitionsUriTemplate,
                (client, resourceGroup, farmId, subResourceName, filter) => client.Shares.GetMetricDefinitions(resourceGroup, farmId, subResourceName, filter));
        }

        [Fact]
        public void GetShareMetric()
        {
            VerifyGetSubResourceMetrics(Constants.ShareType, Constants.ShareName,
                SubResourceMetricsUriTemplate,
                (client, resourceGroup, farmId, subResourceName, filter) => client.Shares.GetMetrics(resourceGroup, farmId, subResourceName, filter));
        }

        [Fact]
        public void GetServiceMetricDefinitions()
        {
            VerifyGetSubResourceMetricDefinitions(Constants.TableServiceType, Constants.SingleInstanceName,
                SubResourceMetricDefinitionsUriTemplate,
                (client, resourceGroup, farmId, subResourceName, filter) => client.TableService.GetMetricDefinitions(resourceGroup, farmId, filter));

            VerifyGetSubResourceMetricDefinitions(Constants.BlobServiceType, Constants.SingleInstanceName,
               SubResourceMetricDefinitionsUriTemplate,
               (client, resourceGroup, farmId, subResourceName, filter) => client.BlobService.GetMetricDefinitions(resourceGroup, farmId, filter));
        }

        [Fact]
        public void GetServiceMetric()
        {
            VerifyGetSubResourceMetrics(Constants.TableServiceType, Constants.SingleInstanceName,
                SubResourceMetricsUriTemplate,
                (client, resourceGroup, farmId, subResourceName, filter) => client.TableService.GetMetrics(resourceGroup, farmId, filter));

            VerifyGetSubResourceMetrics(Constants.BlobServiceType, Constants.SingleInstanceName,
                SubResourceMetricsUriTemplate,
                (client, resourceGroup, farmId, subResourceName, filter) => client.BlobService.GetMetrics(resourceGroup, farmId, filter));
        }

        private void CompareMetricDefinition(MetricDefinitionsResult result)
        {
            Assert.True(result.Value.Count > 1);

            Assert.Equal(result.Value[0].Name.Value, "Total Requests");

            Assert.Equal(result.Value[0].Unit, MetricUnit.Count);

            Assert.True(result.Value[0].MetricAvailabilities.Count > 0);

            Assert.Equal(result.Value[0].MetricAvailabilities[0].Retention, TimeSpan.FromDays(1));

            Assert.Equal(result.Value[0].MetricAvailabilities[0].TimeGrain, TimeSpan.FromMinutes(1));

            Assert.Equal(result.Value[0].PrimaryAggregationType, MetricPrimaryAggregationType.Total);
        }

        private void CompareMetric(MetricsResult result)
        {
            Assert.True(result.Metrics.Count > 0);

            Assert.Equal(result.Metrics[0].Name.Value, "Availability");

            Assert.Equal(result.Metrics[0].Name.LocalizedValue, "Availability");

            Assert.Equal(result.Metrics[0].MetricUnit, MetricUnit.Count);

            Assert.Equal(result.Metrics[0].StartTime.Date, DateTime.Parse("2015-3-16").Date);

            Assert.Equal(result.Metrics[0].TimeGrain, TimeSpan.FromHours(1));
        }

        private void VerifyGetSubResourceMetricDefinitions(string subResourceType, string subResourceName, string metricsUriTemplate,
            Func<StorageAdminManagementClient, string, string, string, string, MetricDefinitionsResult> func)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.MetricDefinitionResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);

            var client = GetClient(handler, token);

            const string filter = "name";

            var result = func(client, Constants.ResourceGroupName, Constants.FarmId, subResourceName, filter);

            // validate requestor
            Assert.Equal(handler.Method, HttpMethod.Get);

            var expectedUri = string.Format(
                metricsUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId,
                subResourceType,
                Uri.EscapeDataString(subResourceName),
                filter);

            Assert.Equal(expectedUri, handler.Uri.AbsoluteUri);

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);

            CompareMetricDefinition(result);
        }

        
        private void VerifyGetSubResourceMetrics(string subResourceType, string subResourceName, string metricsUriTemplate,
            Func<StorageAdminManagementClient, string, string, string, string, MetricsResult> func)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.MetricResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);

            var client = GetClient(handler, token);

            const string filter = "name";

            var result = func(client, Constants.ResourceGroupName, Constants.FarmId, subResourceName, filter);

            // validate requestor
            Assert.Equal(handler.Method, HttpMethod.Get);

            var expectedUri = string.Format(
                metricsUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId,
                subResourceType,
                Uri.EscapeDataString(subResourceName),
                filter);

            Assert.Equal(handler.Uri.AbsoluteUri, expectedUri);

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);

            CompareMetric(result);
        }
    }
}