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
using Microsoft.AzureStack.AzureConsistentStorage.Models;
using Xunit;

namespace Microsoft.AzureStack.AzureConsistentStorage.Tests
{
    public class FarmTests : TestBase
    {
        private const string GetUriTemplate =
            "{0}/subscriptions/{1}/resourcegroups/{2}/providers/Microsoft.Storage.Admin/farms/{3}?" 
            + Constants.ApiVersionParameter;

        private const string ListUriTemplate =
           "{0}/subscriptions/{1}/resourcegroups/{2}/providers/Microsoft.Storage.Admin/farms?"
           + Constants.ApiVersionParameter;

        private const string GetEventQueryTemplate =
         "{0}/subscriptions/{1}/resourcegroups/{2}/providers/Microsoft.Storage.Admin/farms/{3}/geteventquery?"
         + Constants.ApiVersionParameter
         +"&$filter={4}";

        private const string LocationUriTemplate =
            "{0}/subscriptions/{1}/resourcegroups/{2}/providers/Microsoft.Storage.Admin/farms/{3}/nodes/{4}/operationresults/{5}?"
            + Constants.ApiVersionParameter;

        [Fact]
        public void GetFarm()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.FarmGetResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);

            var result = client.Farms.Get(Constants.ResourceGroupName, Constants.FarmId);

            // validate requestor
            Assert.Equal(handler.Method, HttpMethod.Get);

            var expectedUri = string.Format(
                GetUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId);

            Assert.Equal(handler.Uri.AbsoluteUri, expectedUri);

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);

            CompareExpectedResult(result.Farm);

            //TODO: deployment information?
        }

        [Fact]
        public void ListFarm()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.FarmListResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);

            var result = client.Farms.List(Constants.ResourceGroupName);

            // validate requestor
            Assert.Equal(handler.Method, HttpMethod.Get);

            var expectedUri = string.Format(
                ListUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName);

            Assert.Equal(handler.Uri.AbsoluteUri, expectedUri);

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);

            Assert.False(result.Farms == null);

            Assert.False(result.Farms[0] == null);

            CompareExpectedResult(result.Farms[0]);

            //TODO: deployment information?
        }

        [Fact]
        public void PatchFarm()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.FarmGetResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);

            var settings = new FarmSettings
            {
                SettingsPollingIntervalInSecond = 100
            };

            var farmReq = new FarmUpdateParameters
            {
                Farm = new FarmBase
                {
                    Settings = settings
                }
            };

            var result = client.Farms.Update(
                Constants.ResourceGroupName,
                Constants.FarmId,
                farmReq);

            // validate requestor
            Assert.Equal(handler.Method.Method, "PATCH", StringComparer.OrdinalIgnoreCase);

            var expectedUri = string.Format(
                GetUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId);

            Assert.Equal(handler.Uri.AbsoluteUri, expectedUri);

            CompareExpectedResult(result.Farm);
        }


        [Fact]
        public void LogCollect()
        {
            var response = new HttpResponseMessage(HttpStatusCode.Accepted);

            var subscriptionId = Guid.NewGuid().ToString();
            string locationUri = string.Format(
                LocationUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId,
                Constants.NodeId,
                Guid.NewGuid()
                );
            response.Headers.Add("Location", locationUri);

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.Accepted,
                SubsequentStatusCodeToReturn = HttpStatusCode.OK
            };

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);
            var result = client.Farms.CollectLog(
                Constants.ResourceGroupName,
                Constants.FarmId,
                new LogCollectParameters()
                );
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

            Assert.Equal(locationUri, handler.Uri.AbsoluteUri);
        }

        [Fact]
        public void OnDemandGc()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            var subscriptionId = Guid.NewGuid().ToString();
         
            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK,
            };

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);
            var result = client.Farms.OnDemandGc(
                Constants.ResourceGroupName,
                Constants.FarmId);
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);

        }

        private void CompareExpectedResult(FarmModel result)
        {
            // Validate response 
            Assert.Equal(result.Properties.HealthStatus, HealthStatus.Warning);


            Assert.Equal(60, result.Properties.Settings.SettingsPollingIntervalInSecond);
            Assert.Equal(80, result.Properties.Settings.HostStyleHttpPort);
            Assert.Equal(443, result.Properties.Settings.HostStyleHttpsPort);
            Assert.Equal("http://manage.wossportal.com;http://www.example.com", result.Properties.Settings.CorsAllowedOriginsList);
            Assert.Equal("contoso.com", result.Properties.Settings.DataCenterUriHostSuffixes);

            Assert.Equal("\\\\localhost\\db1\\settings", result.Properties.SettingsStore);
        }

        [Fact]
        public void GetEventQuery()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.EventQueryResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);
            var filter = "startTime eq '2015-05-10T18:02:00Z' and endTime eq '2015-05-28T18:02:00Z'";

            var result = client.Farms.GetEventQuery(
                Constants.ResourceGroupName,
                Constants.FarmId,
                filter
                );

            // validate requestor
            Assert.Equal(handler.Method, HttpMethod.Post);

            var expectedUri = string.Format(
                GetEventQueryTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId,
                Uri.EscapeDataString(filter));

            Assert.Equal(expectedUri, handler.Uri.AbsoluteUri);
            EventQueryResultValidator.ValidateGetEventQueryResult(result);
        }

    }
}