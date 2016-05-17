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
    public class AcquisitionTests : TestBase
    {
        private const string GetUriTemplate =
            "{0}/subscriptions/{1}/resourcegroups/{2}/providers/Microsoft.Storage.Admin/farms/{3}/acquisitions/{4}?"
            + Constants.ApiVersionParameter;

        private const string ListUriTemplate =
            "{0}/subscriptions/{1}/resourcegroups/{2}/providers/Microsoft.Storage.Admin/farms/{3}/acquisitions?"
            + Constants.ApiVersionParameter
            + "&$filter={4}";

        [Fact]
        public void Get()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.AcquisitionGetResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);

            var client = GetClient(handler, token);

            var result = client.Acquisitions.Get(
                Constants.ResourceGroupName,
                Constants.FarmId,
                Constants.AcquisitionId);

            Assert.Equal(handler.Method, HttpMethod.Get);

            var expectedUri = string.Format(
                GetUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId,
                Constants.AcquisitionId);

            Assert.Equal(expectedUri, handler.Uri.AbsoluteUri );

            CompareExpectedResult(result.Acquisition);
        }

        [Fact]
        public void List()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.AcquisitionListResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);

            var client = GetClient(handler, token);

            var filter = "filter";

            var result = client.Acquisitions.List(
                Constants.ResourceGroupName,
                Constants.FarmId,
                filter);

            Assert.Equal(handler.Method, HttpMethod.Get);

            var expectedUri = string.Format(
                ListUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId,
                filter);

            Assert.Equal(expectedUri, handler.Uri.AbsoluteUri);

            CompareExpectedResult(result.Acquisitions[0]);
        }

        [Fact]
        public void Delete()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            var subscriptionId = Guid.NewGuid().ToString();

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);
            var result = client.Acquisitions.Delete(
                Constants.ResourceGroupName,
                Constants.FarmId,
                Constants.AcquisitionId
                );

            Assert.Equal(handler.Method, HttpMethod.Delete);

            var expectedUri = string.Format(
                GetUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId,
                Constants.AcquisitionId);

            Assert.Equal(expectedUri, handler.Uri.AbsoluteUri);

        }

        private void CompareExpectedResult(AcquisitionModel acquisition)
        {
            Assert.Equal("D6AE96E1-62B1-4F43-91F6-680E3990D76D", acquisition.Properties.AcquisitionId);
            Assert.Equal("blob3", acquisition.Properties.Blob);
            Assert.Equal("blob1", acquisition.Properties.Container);
            Assert.Equal("\\\\JUSTISUN-BLOB2\\blob\\mystorageaccount1\\blob1\\c9c61ccf-9db4-4543-bb9f-39510f1c4591.pageblob", acquisition.Properties.FilePath);
            Assert.Equal("mystorageaccount1", acquisition.Properties.StorageAccountName);
            Assert.Equal(AcquisitionStatus.Success, acquisition.Properties.Status);
            Assert.Equal(0, acquisition.Properties.MaximumBlobSize);
            Assert.Equal(new Guid("d6ae96e1-62b1-4f43-91f6-680e3990d76b"), acquisition.Properties.TenantSubscriptionId);

        }
    }
}
