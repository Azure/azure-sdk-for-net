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
    public class StorageAccountTests : TestBase
    {
        private const string ListUriTemplate =
            "{0}/subscriptions/{1}/resourcegroups/{2}/providers/Microsoft.Storage.Admin/farms/{3}/storageaccounts?"
            + Constants.ApiVersionParameter + "&summary={4}";

        private const string GetUriTemplate =
            "{0}/subscriptions/{1}/resourcegroups/{2}/providers/Microsoft.Storage.Admin/farms/{3}/storageaccounts/{4}?"
            + Constants.ApiVersionParameter;

        private const string UndeleteUriTemplate =
            "{0}/subscriptions/{1}/resourcegroups/{2}/providers/Microsoft.Storage.Admin/farms/{3}/storageaccounts/{4}?action=undelete&"
            + Constants.ApiVersionParameter;

        [Fact]
        public void ListStorageAccounts()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.StorageAccountListResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);

            var result = client.StorageAccounts.List(Constants.ResourceGroupName, Constants.FarmId, null, true);

            // validate requestor
            Assert.Equal(handler.Method, HttpMethod.Get);

            var expectedUri = string.Format(
                ListUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId,
                "true");

            Assert.Equal(handler.Uri.AbsoluteUri, expectedUri);

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);

            Assert.True(result.StorageAccounts.Count == 3);

            CompareExpectedListResultCommon(result);

            CompareExpectedListResultWacProperties(result, true);
        }

        [Fact]
        public void ListStorageAccountsFull()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.StorageAccountListResponseFull)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);

            var result = client.StorageAccounts.List(Constants.ResourceGroupName, Constants.FarmId, null, false);

            // validate requestor
            Assert.Equal(handler.Method, HttpMethod.Get);

            var expectedUri = string.Format(
                ListUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId,
                "false");

            Assert.Equal(handler.Uri.AbsoluteUri, expectedUri);

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);

            Assert.True(result.StorageAccounts.Count == 3);

            CompareExpectedListResultCommon(result);

            CompareExpectedListResultWacProperties(result, false);
        }

        [Fact]
        public void GetStorageAccount()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.StorageAccountGetResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);

            var result = client.StorageAccounts.Get(Constants.ResourceGroupName, Constants.FarmId, "myaccount");

            // validate requestor
            Assert.Equal(handler.Method, HttpMethod.Get);

            var expectedUri = string.Format(
                GetUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId,
                "myaccount");

            Assert.Equal(handler.Uri.AbsoluteUri, expectedUri);

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);

            CompareExpectedGetResult(result);
        }

        [Fact]
        public void UndeleteStorageAccounts()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);
            StorageAccountUndeleteParameters para = new StorageAccountUndeleteParameters();
            var result = client.StorageAccounts.Undelete(Constants.ResourceGroupName, Constants.FarmId, "myaccount", para);

            // validate requestor
            Assert.Equal(handler.Method, HttpMethod.Post);

            var expectedUri = string.Format(
                UndeleteUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId,
                "myaccount");

            Assert.Equal(handler.Uri.AbsoluteUri, expectedUri);

            // Validate headers 
            Assert.Equal(HttpMethod.Post, handler.Method);
        }

        private void CompareExpectedListResultCommon(StorageAccountListResponse response)
        {
            StorageAccountModel result = response.StorageAccounts[2];
            Assert.Equal(result.Properties.AccountType, StorageAccountType.StandardLRS);

            Assert.Equal(result.Properties.CreationTime, "Thu, 20 Aug 2015 16:09:18 GMT");

            Assert.Equal(result.Properties.TenantAccountName, "705mystorageaccount3");

            Assert.Equal(result.Properties.State, StorageAccountState.Created);

            Assert.Equal(result.Properties.PrimaryLocation, "DevFabric");

            Assert.Equal(result.Properties.StatusOfPrimary, RegionStatus.Available);

            result = response.StorageAccounts[0];

            Assert.Equal(result.Properties.AccountStatus, StorageAccountStatus.OutOfRetentionPeriod);

            Assert.NotNull(result.Properties.DeletedTime);

            Assert.Null(result.Properties.RecycledTime);

            Assert.Equal(result.Properties.CurrentOperation, StorageAccountOperation.Delete);

            Assert.Equal(result.Properties.PrimaryEndpoints.Count, 3);
        }

        private void CompareExpectedListResultWacProperties(StorageAccountListResponse response, bool isSummary)
        {
            StorageAccountModel result = response.StorageAccounts[2];
            if (isSummary)
            {
                Assert.Null(result.Properties.WacInternalState);
                Assert.Null(result.Properties.AccountId);
                Assert.Null(result.Properties.Permissions);
            }
            else
            {
                Assert.Equal(result.Properties.WacInternalState, WacAccountStates.Active);
                Assert.Equal(result.Properties.AccountId, (ulong)999);
                Assert.Equal(result.Properties.Permissions, WacAccountPermissions.Full);
            }
        }

        private void CompareExpectedGetResult(StorageAccountGetResponse response)
        {
            StorageAccountModel result = response.StorageAccount;
            Assert.Equal(result.Properties.AccountType, StorageAccountType.StandardLRS);

            Assert.Equal(result.Properties.CreationTime, "Thu, 20 Aug 2015 16:08:53 GMT");

            Assert.Equal(result.Properties.TenantAccountName, "705mystorageaccount1@2015-08-20T16:09:34.2006267Z");

            Assert.Equal(result.Properties.State, StorageAccountState.Created);

            Assert.Equal(result.Properties.PrimaryLocation, "DevFabric");

            Assert.Equal(result.Properties.StatusOfPrimary, RegionStatus.Available);

            result = response.StorageAccount;

            Assert.Equal(result.Properties.AccountStatus, StorageAccountStatus.OutOfRetentionPeriod);

            Assert.NotNull(result.Properties.DeletedTime);

            Assert.Null(result.Properties.RecycledTime);

            Assert.Equal(result.Properties.CurrentOperation, StorageAccountOperation.Delete);

            Assert.Equal(result.Properties.PrimaryEndpoints.Count, 3);

            Assert.NotNull(result.Properties.WacInternalState);
            Assert.NotNull(result.Properties.AccountId);
            Assert.NotNull(result.Properties.Permissions);
        }
    }
}