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
    public class QuotaTests : TestBase
    {
        private const string ListUriTemplate =
            "{0}/subscriptions/{1}/providers/Microsoft.Storage.Admin/locations/{2}/quotas?"
            + Constants.ApiVersionParameter;

        private const string CreateOrUpdateOrDeleteOrGetUriTemplate =
           "{0}/subscriptions/{1}/providers/Microsoft.Storage.Admin/locations/{2}/quotas/{3}?"
           + Constants.ApiVersionParameter;
        
        
        [Fact]
        public void CreateQuota()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.QuotaGetResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);

            var quotaReq = new QuotaCreateOrUpdateParameters
            {
                Properties = new Quota
                {
                    CapacityInGB = 100,
                    NumberOfStorageAccounts = 10
                }
            };

            var result = client.Quotas.CreateOrUpdate(Constants.LocationName, Constants.QuotaName, quotaReq);

            var expectedUri = string.Format(
                CreateOrUpdateOrDeleteOrGetUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.LocationName,
                Constants.QuotaName);

            Assert.Equal(expectedUri, handler.Uri.AbsoluteUri);

            Assert.Equal(HttpMethod.Put, handler.Method);

            CompareExpectedResult(result.Quota, subscriptionId);
        }

        [Fact]
        public void GetQuota()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.QuotaGetResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);

            var result = client.Quotas.Get(Constants.LocationName, Constants.QuotaName);

            // validate requestor
            Assert.Equal(handler.Method, HttpMethod.Get);

            var expectedUri = string.Format(
                CreateOrUpdateOrDeleteOrGetUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.LocationName,
                Constants.QuotaName);

            Assert.Equal(handler.Uri.AbsoluteUri, expectedUri);
                        
            CompareExpectedResult(result.Quota, subscriptionId);            
        }

        [Fact]
        public void ListQuota()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.QuotaListResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);

            var result = client.Quotas.List(Constants.LocationName);

            // validate requestor
            Assert.Equal(handler.Method, HttpMethod.Get);

            var expectedUri = string.Format(
                ListUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.LocationName);

            Assert.Equal(handler.Uri.AbsoluteUri, expectedUri);
                        
            Assert.False(result.Quotas == null);

            Assert.False(result.Quotas[0] == null);

            CompareExpectedResult(result.Quotas[0], subscriptionId);            
        }

        [Fact]
        public void UpdateQuota()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.QuotaGetResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);

            var quotaReq = new QuotaCreateOrUpdateParameters
            {
                Properties = new Quota
                {
                    CapacityInGB = 100,
                    NumberOfStorageAccounts = 10
                }
            };

            var result = client.Quotas.CreateOrUpdate(
                Constants.LocationName,
                Constants.QuotaName,
                quotaReq);

            // validate requestor
            Assert.Equal(handler.Method, HttpMethod.Put);

            var expectedUri = string.Format(
                CreateOrUpdateOrDeleteOrGetUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.LocationName,
                Constants.QuotaName);

            Assert.Equal(handler.Uri.AbsoluteUri, expectedUri);

            CompareExpectedResult(result.Quota, subscriptionId);
        }

        [Fact]
        public void DeleteQuota()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            var subscriptionId = Guid.NewGuid().ToString();

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);

            var result = client.Quotas.Delete(
                Constants.LocationName,
                Constants.QuotaName);

            Assert.Equal(handler.Method, HttpMethod.Delete);

            var expectedUri = string.Format(
                CreateOrUpdateOrDeleteOrGetUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.LocationName,
                Constants.QuotaName);

            Assert.Equal(expectedUri, handler.Uri.AbsoluteUri);
        }

        private void CompareExpectedResult(QuotaModel result, string subscriptionId)
        {
            // Validate response 
            Assert.Equal(string.Format("{0}/{1}",Constants.LocationName, Constants.QuotaName), result.Name);
            Assert.Equal(Constants.LocationName, result.Location);
            Assert.Equal(100, result.Properties.CapacityInGB);
            Assert.Equal(10, result.Properties.NumberOfStorageAccounts);            
        }        
    }
}