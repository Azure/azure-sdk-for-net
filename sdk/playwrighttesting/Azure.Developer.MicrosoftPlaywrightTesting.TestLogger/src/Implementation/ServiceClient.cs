// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Serialization;
using Azure.Core;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Client;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Interface;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Model;
using System.Text.Json;
using Azure.Core.Diagnostics;
using System.Diagnostics.Tracing;
using System.Net;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Implementation
{
    internal class ServiceClient : IServiceClient
    {
        private readonly TestReportingClient _testReportingClient;
        private readonly CloudRunMetadata _cloudRunMetadata;
        private readonly ICloudRunErrorParser _cloudRunErrorParser;
        private readonly ILogger _logger;
        private static string AccessToken { get => $"Bearer {Environment.GetEnvironmentVariable(ServiceEnvironmentVariable.PlaywrightServiceAccessToken)}"; set { } }
        private static string CorrelationId { get => Guid.NewGuid().ToString(); set { } }
        private static readonly JsonSerializerOptions _jsonSerializerOptions = new() { DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull };

        public ServiceClient(CloudRunMetadata cloudRunMetadata, ICloudRunErrorParser cloudRunErrorParser, TestReportingClient? testReportingClient = null, ILogger? logger = null)
        {
            _cloudRunMetadata = cloudRunMetadata;
            _cloudRunErrorParser = cloudRunErrorParser;
            _logger = logger ?? new Logger();
            AzureEventSourceListener listener = new(delegate (EventWrittenEventArgs eventData, string text)
            {
                _logger.Info($"[{eventData.Level}] {eventData.EventSource.Name}: {text}");
            }, EventLevel.Informational);
            var clientOptions = new TestReportingClientOptions();
            clientOptions.Diagnostics.IsLoggingEnabled = true;
            clientOptions.Diagnostics.IsTelemetryEnabled = true;
            clientOptions.Retry.MaxRetries = ServiceClientConstants.s_mAX_RETRIES;
            clientOptions.Retry.MaxDelay = TimeSpan.FromSeconds(ServiceClientConstants.s_mAX_RETRY_DELAY_IN_SECONDS);
            _testReportingClient = testReportingClient ?? new TestReportingClient(_cloudRunMetadata.BaseUri, clientOptions);
        }

        public TestRunDto? PatchTestRunInfo(TestRunDto run)
        {
            int statusCode;
            try
            {
                Response? apiResponse = _testReportingClient.PatchTestRunInfo(_cloudRunMetadata.WorkspaceId!, _cloudRunMetadata.RunId!, RequestContent.Create(JsonSerializer.Serialize(run)), AccessToken, CorrelationId);
                if (apiResponse.Status == (int)HttpStatusCode.OK)
                {
                    return apiResponse.Content!.ToObject<TestRunDto>(new JsonObjectSerializer());
                }
                statusCode = apiResponse.Status;
            }
            catch (RequestFailedException ex)
            {
                if (ex.Status == (int)HttpStatusCode.Conflict)
                {
                    var errorMessage = ReporterConstants.s_cONFLICT_409_ERROR_MESSAGE.Replace("{runId}", _cloudRunMetadata.RunId!);
                    _cloudRunErrorParser.PrintErrorToConsole(errorMessage);
                    _cloudRunErrorParser.TryPushMessageAndKey(errorMessage, ReporterConstants.s_cONFLICT_409_ERROR_MESSAGE_KEY);
                    throw new Exception(errorMessage);
                }
                else if (ex.Status == (int)HttpStatusCode.Forbidden)
                {
                    var errorMessage = ReporterConstants.s_fORBIDDEN_403_ERROR_MESSAGE.Replace("{workspaceId}", _cloudRunMetadata.WorkspaceId!);
                    _cloudRunErrorParser.PrintErrorToConsole(errorMessage);
                    _cloudRunErrorParser.TryPushMessageAndKey(errorMessage, ReporterConstants.s_fORBIDDEN_403_ERROR_MESSAGE_KEY);
                    throw new Exception(errorMessage);
                }
                statusCode = ex.Status;
            }
            HandleAPIFailure(statusCode, "PatchTestRun");
            return null;
        }

        public TestRunShardDto? PostTestRunShardInfo(TestRunShardDto runShard)
        {
            int statusCode;
            try
            {
                Response apiResponse = _testReportingClient.PostTestRunShardInfo(_cloudRunMetadata.WorkspaceId!, _cloudRunMetadata.RunId!, RequestContent.Create(runShard), ReporterConstants.s_aPPLICATION_JSON, AccessToken, CorrelationId);
                if (apiResponse.Status == (int)HttpStatusCode.OK)
                {
                    return apiResponse.Content!.ToObject<TestRunShardDto>(new JsonObjectSerializer());
                }
                statusCode = apiResponse.Status;
            }
            catch (RequestFailedException ex)
            {
                statusCode = ex.Status;
            }
            HandleAPIFailure(statusCode, "PostTestRunShardInfo");
            return null;
        }

        public void UploadBatchTestResults(UploadTestResultsRequest uploadTestResultsRequest)
        {
            int statusCode;
            try
            {
                Response apiResponse = _testReportingClient.UploadBatchTestResults(_cloudRunMetadata.WorkspaceId!, RequestContent.Create(JsonSerializer.Serialize(uploadTestResultsRequest)), AccessToken, CorrelationId, null);
                if (apiResponse.Status == (int)HttpStatusCode.OK)
                {
                    return;
                }
                statusCode = apiResponse.Status;
            }
            catch (RequestFailedException ex)
            {
                statusCode = ex.Status;
            }
            HandleAPIFailure(statusCode, "UploadBatchTestResults");
        }

        public TestResultsUri? GetTestRunResultsUri()
        {
            int statusCode;
            try
            {
                Response response = _testReportingClient.GetTestRunResultsUri(_cloudRunMetadata.WorkspaceId!, _cloudRunMetadata.RunId!, AccessToken, CorrelationId, null);
                if (response.Status == (int)HttpStatusCode.OK)
                {
                    return response.Content!.ToObject<TestResultsUri>(new JsonObjectSerializer());
                }
                statusCode = response.Status;
            }
            catch (RequestFailedException ex)
            {
                statusCode = ex.Status;
            }
            HandleAPIFailure(statusCode, "GetTestRunResultsUri");
            return null;
        }

        internal void HandleAPIFailure(int? statusCode, string operationName)
        {
            try
            {
                if (statusCode == null)
                    return;
                ApiErrorConstants.s_errorOperationPair.TryGetValue(operationName, out System.Collections.Generic.Dictionary<int, string>? errorObject);
                if (errorObject == null)
                    return;
                errorObject.TryGetValue((int)statusCode, out string? errorMessage);
                errorMessage ??= ReporterConstants.s_uNKNOWN_ERROR_MESSAGE;
                _cloudRunErrorParser.TryPushMessageAndKey(errorMessage, statusCode.ToString());
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
        }
    }
}
