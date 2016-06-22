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
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using Microsoft.Azure;
using Microsoft.AzureStack.AzureConsistentStorage;
using Microsoft.AzureStack.AzureConsistentStorage.Models;
using Xunit;

namespace Microsoft.AzureStack.AzureConsistentStorage.Tests
{
    public class ServiceTests : TestBase
    {
        private const string TableServiceUriTemplate =
            "{0}/subscriptions/{1}/resourcegroups/{2}/providers/Microsoft.Storage.Admin/farms/{3}/tableservices/default?"
            + Constants.ApiVersionParameter;

        private const string QueueServiceUriTemplate =
            "{0}/subscriptions/{1}/resourcegroups/{2}/providers/Microsoft.Storage.Admin/farms/{3}/queueservices/default?"
            + Constants.ApiVersionParameter;

        private const string BlobServiceUriTemplate =
            "{0}/subscriptions/{1}/resourcegroups/{2}/providers/Microsoft.Storage.Admin/farms/{3}/blobservices/default?"
            + Constants.ApiVersionParameter;

        private const string ManagementServiceUriTemplate =
            "{0}/subscriptions/{1}/resourcegroups/{2}/providers/Microsoft.Storage.Admin/farms/{3}/managementservices/default?"
            + Constants.ApiVersionParameter;

        [Fact]
        public void GetTableService()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.TableServiceGetResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);

            var result = client.TableService.Get(Constants.ResourceGroupName, Constants.FarmId);

            // validate requestor
            Assert.Equal(handler.Method, HttpMethod.Get);

            var expectedUri = string.Format(
                TableServiceUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId);

            Assert.Equal(handler.Uri.AbsoluteUri, expectedUri);

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);

            CompareExpectedResult(result.Resource.TableService);
        }

        [Fact]
        public void GetQueueService()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.QueueServiceGetResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);

            var result = client.QueueService.Get(Constants.ResourceGroupName, Constants.FarmId);

            // validate requestor
            Assert.Equal(handler.Method, HttpMethod.Get);

            var expectedUri = string.Format(
                QueueServiceUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId);

            Assert.Equal(handler.Uri.AbsoluteUri, expectedUri);

            CompareExpectedResult(result.Resource.QueueService);
        }

        [Fact]
        public void PatchTableService()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.TableServiceGetResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);

            var settings = new TableServiceWritableSettings
            {
                FrontEndCallbackThreadsCount = 100
            };

            var patchParam = new TableServicePatchParameters
            {
                TableService = new TableServiceRequest()
                {
                    Settings = settings
                }
            };

            var result = client.TableService.Patch(
                Constants.ResourceGroupName,
                Constants.FarmId,
                patchParam);

            // validate requestor
            Assert.Equal(handler.Method.Method, "PATCH", StringComparer.OrdinalIgnoreCase);

            var expectedUri = string.Format(
                TableServiceUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId);

            Assert.Equal(handler.Uri.AbsoluteUri, expectedUri);

            CompareExpectedResult(result.Resource.TableService);
        }

        [Fact]
        public void PatchQueueService()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.QueueServiceGetResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);

            var settings = new QueueServiceWritableSettings
            {
                FrontEndCallbackThreadsCount = 100
            };

            var patchParam = new QueueServicePatchParameters
            {
                QueueService = new QueueServiceRequest()
                {
                    Settings = settings
                }
            };

            var result = client.QueueService.Patch(
                Constants.ResourceGroupName,
                Constants.FarmId,
                patchParam);

            // validate requestor
            Assert.Equal(handler.Method.Method, "PATCH", StringComparer.OrdinalIgnoreCase);

            var expectedUri = string.Format(
                QueueServiceUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId);

            Assert.Equal(handler.Uri.AbsoluteUri, expectedUri);

            CompareExpectedResult(result.Resource.QueueService);
        }

        [Fact]
        public void GetBlobService()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.BlobServiceGetResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);

            var result = client.BlobService.Get(Constants.ResourceGroupName, Constants.FarmId);

            // validate requestor
            Assert.Equal(handler.Method, HttpMethod.Get);

            var expectedUri = string.Format(
                BlobServiceUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId);

            Assert.Equal(handler.Uri.AbsoluteUri, expectedUri);

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);

            CompareExpectedResult(result.Resource.BlobService);
        }

        [Fact]
        public void PatchBlobService()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.BlobServiceGetResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);

            var settings = new BlobServiceWritableSettings
            {
                FrontEndCallbackThreadsCount = 100
            };

            var patchParam = new BlobServicePatchParameters
            {
                BlobService = new BlobServiceRequest()
                {
                    Settings = settings
                }
            };

            var result = client.BlobService.Patch(
                Constants.ResourceGroupName,
                Constants.FarmId,
                patchParam);

            // validate requestor
            Assert.Equal(handler.Method.Method, "PATCH", StringComparer.OrdinalIgnoreCase);

            var expectedUri = string.Format(
                BlobServiceUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId);

            Assert.Equal(handler.Uri.AbsoluteUri, expectedUri);

            CompareExpectedResult(result.Resource.BlobService);
        }

        [Fact]
        public void GetManagementService()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.ManagementServiceGetResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);

            var result = client.ManagementService.Get(Constants.ResourceGroupName, Constants.FarmId);

            // validate requestor
            Assert.Equal(handler.Method, HttpMethod.Get);

            var expectedUri = string.Format(
                ManagementServiceUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId);

            Assert.Equal(handler.Uri.AbsoluteUri, expectedUri);

            // Validate headers 
            Assert.Equal(HttpMethod.Get, handler.Method);

            CompareExpectedResult(result.Resource.ManagementService);
        }

        [Fact]
        public void PatchManagementService()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(ExpectedResults.ManagementServiceGetResponse)
            };

            var handler = new RecordedDelegatingHandler(response)
            {
                StatusCodeToReturn = HttpStatusCode.OK
            };

            var subscriptionId = Guid.NewGuid().ToString();

            var token = new TokenCloudCredentials(subscriptionId, Constants.TokenString);
            var client = GetClient(handler, token);

            var settings = new ManagementServiceWritableSettings
            {
                WacAccountGcFullScanIntervalInSeconds = 100
            };

            var patchParam = new ManagementServicePatchParameters
            {
                ManagementService = new ManagementServiceRequest()
                {
                    Settings = settings
                }
            };

            var result = client.ManagementService.Patch(
                Constants.ResourceGroupName,
                Constants.FarmId,
                patchParam);

            // validate requestor
            Assert.Equal(handler.Method.Method, "PATCH", StringComparer.OrdinalIgnoreCase);

            var expectedUri = string.Format(
                ManagementServiceUriTemplate,
                Constants.BaseUri,
                subscriptionId,
                Constants.ResourceGroupName,
                Constants.FarmId);

            Assert.Equal(handler.Uri.AbsoluteUri, expectedUri);

            CompareExpectedResult(result.Resource.ManagementService);
        }


        private void CompareExpectedResult(TableServiceResponse result)
        {
            // Validate response 
            Assert.Equal("1.0", result.Version);
            Assert.Equal(HealthStatus.Healthy, result.HealthStatus);
            Assert.Equal(1, result.Settings.FrontEndCallbackThreadsCount);
            Assert.Equal(10, result.Settings.FrontEndCpuBasedKeepAliveThrottlingCpuMonitorIntervalInSeconds);
            Assert.Equal(true, result.Settings.FrontEndCpuBasedKeepAliveThrottlingEnabled);
            Assert.Equal(10, result.Settings.FrontEndCpuBasedKeepAliveThrottlingPercentCpuThreshold);
            Assert.Equal(90.5, result.Settings.FrontEndCpuBasedKeepAliveThrottlingPercentRequestsToThrottle);
            Assert.Equal(100, result.Settings.FrontEndMaxMillisecondsBetweenMemorySamples);
            Assert.Equal("2;3", result.Settings.FrontEndMemoryThrottleThresholdSettings);
            Assert.Equal(true, result.Settings.FrontEndMemoryThrottlingEnabled);
            Assert.Equal(10, result.Settings.FrontEndMinimumThreadPoolThreads);
            Assert.Equal(11002, result.Settings.FrontEndHttpListenPort);
            Assert.Equal(11102, result.Settings.FrontEndHttpsListenPort);
            Assert.Equal(10, result.Settings.FrontEndThreadPoolBasedKeepAliveIOCompletionThreshold);
            Assert.Equal(80, result.Settings.FrontEndThreadPoolBasedKeepAlivePercentage);
            Assert.Equal(10, result.Settings.FrontEndThreadPoolBasedKeepAliveWorkerThreadThreshold);
            Assert.Equal(10, result.Settings.FrontEndThreadPoolBasedKeepAliveMonitorIntervalInSeconds);
            Assert.Equal(false, result.Settings.FrontEndUseSlaTimeInAvailability);

        }

        private void CompareExpectedResult(QueueServiceResponse result)
        {
            // Validate response 
            Assert.Equal("1.0", result.Version);
            Assert.Equal(HealthStatus.Healthy, result.HealthStatus);
            Assert.Equal(1, result.Settings.FrontEndCallbackThreadsCount);
            Assert.Equal(10, result.Settings.FrontEndCpuBasedKeepAliveThrottlingCpuMonitorIntervalInSeconds);
            Assert.Equal(true, result.Settings.FrontEndCpuBasedKeepAliveThrottlingEnabled);
            Assert.Equal(10, result.Settings.FrontEndCpuBasedKeepAliveThrottlingPercentCpuThreshold);
            Assert.Equal(90.5, result.Settings.FrontEndCpuBasedKeepAliveThrottlingPercentRequestsToThrottle);
            Assert.Equal(100, result.Settings.FrontEndMaxMillisecondsBetweenMemorySamples);
            Assert.Equal("2;3", result.Settings.FrontEndMemoryThrottleThresholdSettings);
            Assert.Equal(true, result.Settings.FrontEndMemoryThrottlingEnabled);
            Assert.Equal(10, result.Settings.FrontEndMinimumThreadPoolThreads);
            Assert.Equal(11001, result.Settings.FrontEndHttpListenPort);
            Assert.Equal(11101, result.Settings.FrontEndHttpsListenPort);
            Assert.Equal(10, result.Settings.FrontEndThreadPoolBasedKeepAliveIOCompletionThreshold);
            Assert.Equal(80, result.Settings.FrontEndThreadPoolBasedKeepAlivePercentage);
            Assert.Equal(10, result.Settings.FrontEndThreadPoolBasedKeepAliveWorkerThreadThreshold);
            Assert.Equal(10, result.Settings.FrontEndThreadPoolBasedKeepAliveMonitorIntervalInSeconds);
            Assert.Equal(false, result.Settings.FrontEndUseSlaTimeInAvailability);

        }

        private void CompareExpectedResult(BlobServiceResponse result)
        {
            // Validate response 
            Assert.Equal("1.0", result.Version);
            Assert.Equal(HealthStatus.Healthy, result.HealthStatus);
            Assert.Equal(10, result.Settings.BlobSvcContainerGcInterval);
            Assert.Equal(10, result.Settings.BlobSvcShallowGcInterval);
            Assert.Equal(50, result.Settings.BlobSvcStreamMapMinContainerOccupancyPercent);
            Assert.Equal(1, result.Settings.FrontEndCallbackThreadsCount);
            Assert.Equal(10, result.Settings.FrontEndCpuBasedKeepAliveThrottlingCpuMonitorIntervalInSeconds);
            Assert.Equal(true, result.Settings.FrontEndCpuBasedKeepAliveThrottlingEnabled);
            Assert.Equal(10, result.Settings.FrontEndCpuBasedKeepAliveThrottlingPercentCpuThreshold);
            Assert.Equal(90.5, result.Settings.FrontEndCpuBasedKeepAliveThrottlingPercentRequestsToThrottle);
            Assert.Equal(100, result.Settings.FrontEndMaxMillisecondsBetweenMemorySamples);
            Assert.Equal("2;3", result.Settings.FrontEndMemoryThrottleThresholdSettings);
            Assert.Equal(true, result.Settings.FrontEndMemoryThrottlingEnabled);
            Assert.Equal(10, result.Settings.FrontEndMinimumThreadPoolThreads);
            Assert.Equal(11002, result.Settings.FrontEndHttpListenPort);
            Assert.Equal(11102, result.Settings.FrontEndHttpsListenPort);
            Assert.Equal(10, result.Settings.FrontEndThreadPoolBasedKeepAliveIOCompletionThreshold);
            Assert.Equal(80, result.Settings.FrontEndThreadPoolBasedKeepAlivePercentage);
            Assert.Equal(10, result.Settings.FrontEndThreadPoolBasedKeepAliveWorkerThreadThreshold);
            Assert.Equal(10, result.Settings.FrontEndThreadPoolBasedKeepAliveMonitorIntervalInSeconds);
            Assert.Equal(false, result.Settings.FrontEndUseSlaTimeInAvailability);
        }

        private void CompareExpectedResult(ManagementServiceResponse result)
        {
            // Validate response 
            Assert.Equal("1.0", result.Version);
            Assert.Equal(HealthStatus.Healthy, result.HealthStatus);
            Assert.Equal(1, result.Settings.WacAccountGcFullScanIntervalInSeconds);
            Assert.Equal(1, result.Settings.WacContainerGcFullScanIntervalInSeconds);
            Assert.Equal(1, result.Settings.WacGcWaitPeriodInMilliseconds);
            Assert.Equal(1, result.Settings.WacHoldingPeriodInHours);
            Assert.Equal(1000, result.Settings.WacMaxGcThreadNumber);
            Assert.Equal(100, result.Settings.WacMaxCacheSize);
            Assert.Equal(100, result.Settings.WacMaxConnections);
            Assert.Equal("name1", result.Settings.HealthAccountName);
            Assert.Equal("key1", result.Settings.HealthAccountKey);
            Assert.Equal("name2", result.Settings.MetricsAccountName);
            Assert.Equal("key2", result.Settings.MetricsAccountKey);
        }
    }
}