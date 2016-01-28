//
//  <copyright file="ShareTests.cs" company="Microsoft">
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
using Microsoft.AzureStack.Management.StorageAdmin;
using Microsoft.AzureStack.Management.StorageAdmin.Models;
using Xunit;

namespace Microsoft.AzureStack.Management.StorageAdmin.Tests
{
    public class ShareTests : TestBase
    {
        private const string ListUriTemplate =
            "{0}/subscriptions/{1}/resourcegroups/{2}/providers/Microsoft.Storage.Admin/farms/{3}/shares?"
            +Constants.ApiVersionParameter;

        private const string GetUriTemplate =
            "{0}/subscriptions/{1}/resourcegroups/{2}/providers/Microsoft.Storage.Admin/farms/{3}/shares/{4}?"
            + Constants.ApiVersionParameter;

        [Fact]
        public void GetShare()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.ShareGetResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);

            var result = client.Shares.Get(Constants.ResourceGroupName, Constants.FarmId, Constants.ShareAName);

            // validate requestor
            Assert.Equal(handler.Method, HttpMethod.Get);

            var expectedUri = string.Format(
                GetUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId, 
                Uri.EscapeDataString(Constants.ShareAName)
                );

            Assert.Equal(handler.Uri.AbsoluteUri, expectedUri);

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);
            
            CompareExpectedResult(result.Share);
        }

        [Fact]
        public void ListShares()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.ShareListResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);

            var result = client.Shares.List(Constants.ResourceGroupName, Constants.FarmId);

            // validate requestor
            Assert.Equal(handler.Method, HttpMethod.Get);

            var expectedUri = string.Format(
                ListUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId);

            Assert.Equal(handler.Uri.AbsoluteUri, expectedUri);

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);

            Assert.True(result.Shares.Count > 1);

            CompareExpectedResult(result.Shares[0]);
        }

        private void CompareExpectedResult(ShareModel result)
        {
            Assert.Equal(result.Properties.ShareName, "smb1");

            Assert.Equal(result.Properties.UncPath, "\\\\localhost\\smb1");

            Assert.Equal(result.Properties.HealthStatus, HealthStatus.Warning);

            Assert.Equal(result.Properties.TotalCapacity, (ulong)500);

            Assert.Equal(result.Properties.UsedCapacity, (ulong)40);

            Assert.Equal(result.Properties.FreeCapacity, (ulong)460);
        }
    }
}