// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using Azure.Core.Serialization;
using Azure.Core;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Client;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Model;
using System.Text.Json;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Implementation
{
    internal class ServiceClient : IServiceClient
    {
        private readonly ReportingTestResultsClient _reportingTestResultsClient;
        private readonly ReportingTestRunsClient _reportingTestRunsClient;
        private readonly CloudRunMetadata _cloudRunMetadata;
        private static string AccessToken { get => $"Bearer {Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken)}"; set { } }
        private static string CorrelationId { get => Guid.NewGuid().ToString(); set { } }

        public ServiceClient(CloudRunMetadata cloudRunMetadata, ReportingTestResultsClient? reportingTestResultsClient = null, ReportingTestRunsClient? reportingTestRunsClient = null)
        {
            _cloudRunMetadata = cloudRunMetadata;
            _reportingTestResultsClient = reportingTestResultsClient ?? new ReportingTestResultsClient(_cloudRunMetadata.BaseUri);
            _reportingTestRunsClient = reportingTestRunsClient ?? new ReportingTestRunsClient(_cloudRunMetadata.BaseUri);
        }

        public TestRunDtoV2? PatchTestRunInfo(TestRunDtoV2 run)
        {
            Response apiResponse = _reportingTestRunsClient.PatchTestRunInfo(_cloudRunMetadata.WorkspaceId!, _cloudRunMetadata.RunId!, RequestContent.Create(run), ReporterConstants.s_aPPLICATION_JSON, AccessToken, CorrelationId);
            if (apiResponse.Content != null)
            {
                return apiResponse.Content!.ToObject<TestRunDtoV2>(new JsonObjectSerializer());
            }
            return null;
        }

        public TestRunShardDto? PatchTestRunShardInfo(int shardId, TestRunShardDto runShard)
        {
            Response apiResponse = _reportingTestRunsClient.PatchTestRunShardInfo(_cloudRunMetadata.WorkspaceId!, _cloudRunMetadata.RunId!, shardId.ToString(), RequestContent.Create(runShard), ReporterConstants.s_aPPLICATION_JSON, AccessToken, CorrelationId);
            if (apiResponse.Content != null)
            {
                return apiResponse.Content!.ToObject<TestRunShardDto>(new JsonObjectSerializer());
            }
            return null;
        }

        public void UploadBatchTestResults(UploadTestResultsRequest uploadTestResultsRequest)
        {
            _reportingTestResultsClient.UploadBatchTestResults(_cloudRunMetadata.WorkspaceId!, RequestContent.Create(JsonSerializer.Serialize(uploadTestResultsRequest)), AccessToken, CorrelationId, null);
        }

        public TestResultsUri? GetTestRunResultsUri()
        {
            Response response = _reportingTestRunsClient.GetTestRunResultsUri(_cloudRunMetadata.WorkspaceId!, _cloudRunMetadata.RunId!, AccessToken, CorrelationId, null);
            if (response.Content != null)
            {
                return response.Content!.ToObject<TestResultsUri>(new JsonObjectSerializer());
            }
            return null;
        }
    }
}
