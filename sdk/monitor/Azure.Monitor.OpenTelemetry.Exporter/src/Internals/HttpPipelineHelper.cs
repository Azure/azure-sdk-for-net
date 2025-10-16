// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using Azure.Core;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.CustomerSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry;
using OpenTelemetry.PersistentStorage.Abstractions;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class HttpPipelineHelper
    {
        private const string RetryAfterHeaderName = "Retry-After";

        internal static int MinimumRetryInterval = 60000;

        private static TransmissionResult CreateTransmissionResult() => new()
        {
            ExportResult = ExportResult.Failure,
            WillRetry = false,
            SavedToStorage = false,
            DeletedBlob = false,
            StatusCode = 0,
            ItemsAccepted = null
        };

        private static bool IsRetriableStatus(int statusCode) => statusCode == ResponseStatusCodes.RequestTimeout
                                                                                || statusCode == ResponseStatusCodes.ResponseCodeTooManyRequests
                                                                                || statusCode == ResponseStatusCodes.ResponseCodeTooManyRequestsAndRefreshCache
                                                                                || statusCode == ResponseStatusCodes.Unauthorized
                                                                                || statusCode == ResponseStatusCodes.Forbidden
                                                                                || statusCode == ResponseStatusCodes.InternalServerError
                                                                                || statusCode == ResponseStatusCodes.BadGateway
                                                                                || statusCode == ResponseStatusCodes.ServiceUnavailable
                                                                                || statusCode == ResponseStatusCodes.GatewayTimeout;

        internal static int GetItemsAccepted(HttpMessage message)
        {
            return TryGetTrackResponse(message, out var trackResponse)
                ? trackResponse.ItemsAccepted.GetValueOrDefault()
                : default;
        }

        internal static bool TryGetTrackResponse(HttpMessage message, [NotNullWhen(true)] out TrackResponse? trackResponse)
        {
            if (message.Response.ContentStream == null)
            {
                trackResponse = null;
                return false;
            }

            using (JsonDocument document = JsonDocument.Parse(message.Response.ContentStream, default))
            {
                var value = TrackResponse.DeserializeTrackResponse(document.RootElement);
                trackResponse = Response.FromValue(value, message.Response);
                return true;
            }
        }

        internal static int GetRetryInterval(Response httpResponse)
        {
            if (httpResponse != null && httpResponse.Headers.TryGetValue(RetryAfterHeaderName, out var retryAfterValue))
            {
                if (int.TryParse(retryAfterValue, out var delaySeconds))
                {
                    return (int)TimeSpan.FromSeconds(delaySeconds).TotalMilliseconds;
                }
                if (DateTimeOffset.TryParse(retryAfterValue, out DateTimeOffset delayTime))
                {
                    return (int)(delayTime - DateTimeOffset.Now).TotalMilliseconds;
                }
            }

            return MinimumRetryInterval;
        }

        internal static bool TryGetRetryIntervalTimespan(Response? httpResponse, out TimeSpan retryAfter)
        {
            if (httpResponse != null && httpResponse.Headers.TryGetValue(RetryAfterHeaderName, out var retryAfterValue))
            {
                if (int.TryParse(retryAfterValue, out var delaySeconds))
                {
                    retryAfter = TimeSpan.FromSeconds(delaySeconds);
                    return true;
                }
                if (DateTimeOffset.TryParse(retryAfterValue, out DateTimeOffset delayTime))
                {
                    retryAfter = (delayTime - DateTimeOffset.Now);
                    return true;
                }
            }

            retryAfter = default;
            return false;
        }

        internal static byte[] GetSerializedContent(IEnumerable<TelemetryItem> body)
        {
            using var content = new NDJsonWriter();
            foreach (var item in body)
            {
                content.JsonWriter.WriteObjectValue(item);
                content.WriteNewLine();
            }

            return content.ToBytes().ToArray();
        }

        internal static bool TryGetRequestContent(RequestContent? content, [NotNullWhen(true)] out byte[]? requestContent)
        {
            if (content == null)
            {
                requestContent = null;
                return false;
            }

            using MemoryStream st = new MemoryStream();

            content.WriteTo(st, CancellationToken.None);

            requestContent = st.ToArray();
            return true;
        }

        /// <summary>
        /// Parse a PartialSuccess response from ingestion.
        /// </summary>
        /// <param name="trackResponse"><see cref="TrackResponse"/> is the parsed response from ingestion.</param>
        /// <param name="content"><see cref="RequestContent"/> that was sent to ingestion.</param>
        /// <param name="successCounter">Counter of successfully sent telemetry.</param>
        /// <returns>Telemetry that will be tried.</returns>
        private static (byte[]? PartialContent, TelemetrySchemaTypeCounter? SuccessCounter, TelemetrySchemaTypeCounter? RetryCounter, TelemetrySchemaTypeCounter? DroppedCounter) ProcessPartialSuccessWithCounting(TrackResponse trackResponse, RequestContent? content, TelemetrySchemaTypeCounter? successCounter)
        {
            if (content == null || !TryGetRequestContent(content, out var requestContent))
            {
                return (null, null, null, null);
            }

            var telemetryItems = Encoding.UTF8.GetString(requestContent).Split('\n');
            var totalItems = telemetryItems.Length;

            if (totalItems == 0)
            {
                return (null, null, null, null);
            }

            successCounter ??= new TelemetrySchemaTypeCounter();
            var retryCounter = new TelemetrySchemaTypeCounter();
            var droppedCounter = new TelemetrySchemaTypeCounter();
            string? partialContent = null;

            foreach (var error in trackResponse.Errors)
            {
                if (error != null && error.Index != null)
                {
                    int errorIndex = (int)error.Index;
                    if (errorIndex >= telemetryItems.Length || errorIndex < 0)
                    {
                        AzureMonitorExporterEventSource.Log.PartialContentResponseInvalid(telemetryItems.Length, error);
                        continue;
                    }

                    var telemetryType = GetTelemetryTypeFromJson(telemetryItems[errorIndex]);
                    DecrementCounterByType(successCounter, telemetryType);

                    if (error.StatusCode == ResponseStatusCodes.RequestTimeout
                        || error.StatusCode == ResponseStatusCodes.ServiceUnavailable
                        || error.StatusCode == ResponseStatusCodes.InternalServerError
                        || error.StatusCode == ResponseStatusCodes.ResponseCodeTooManyRequests
                        || error.StatusCode == ResponseStatusCodes.ResponseCodeTooManyRequestsAndRefreshCache)
                    {
                        if (string.IsNullOrEmpty(partialContent))
                        {
                            partialContent = telemetryItems[errorIndex];
                        }
                        else
                        {
                            partialContent += '\n' + telemetryItems[errorIndex];
                        }

                        IncrementCounterByType(retryCounter, telemetryType);
                    }
                    else
                    {
                        AzureMonitorExporterEventSource.Log.PartialContentResponseUnhandled(error);
                        IncrementCounterByType(droppedCounter, telemetryType);
                    }
                }
            }

            byte[]? partialContentBytes = partialContent == null ? null : Encoding.UTF8.GetBytes(partialContent);

            return (
                partialContentBytes,
                HasAnyCount(successCounter) ? successCounter : null,
                HasAnyCount(retryCounter) ? retryCounter : null,
                HasAnyCount(droppedCounter) ? droppedCounter : null);
        }

        internal static ExportResult IsSuccess(HttpMessage httpMessage, TelemetrySchemaTypeCounter? telemetrySchemaTypeCounter = null)
        {
            if (httpMessage.HasResponse && httpMessage.Response.Status == ResponseStatusCodes.Success)
            {
                CustomerSdkStatsHelper.TrackSuccess(telemetrySchemaTypeCounter);
                // TODO: We need to decrypt the request content stream to find the info for transmission from storage.
                return ExportResult.Success;
            }

            return ExportResult.Failure;
        }

        /// <summary>
        /// Centralized handling of a transmission result (exporter or storage origin).
        /// Decides whether to persist for retry, delete existing storage blob, and logs telemetry.
        /// </summary>
        /// <param name="httpMessage">The HTTP message (request/response).</param>
        /// <param name="blobProvider">Optional blob provider used to save new blobs.</param>
        /// <param name="blob">Existing blob (when retransmitting from storage).</param>
        /// <param name="connectionVars">Connection vars for logging.</param>
        /// <param name="origin">Origin of telemetry (Exporter vs Storage).</param>
        /// <param name="isAadEnabled">If AAD auth is enabled.</param>
        /// <param name="telemetrySchemaTypeCounter">Telemetry counter for tracking metrics.</param>
        /// <returns>TransmissionResult describing actions taken.</returns>
        internal static TransmissionResult ProcessTransmissionResult(HttpMessage httpMessage, PersistentBlobProvider? blobProvider, PersistentBlob? blob, ConnectionVars connectionVars, TelemetryItemOrigin origin, bool isAadEnabled, TelemetrySchemaTypeCounter? telemetrySchemaTypeCounter = null)
        {
            var result = CreateTransmissionResult();

            if (!httpMessage.HasResponse)
            {
                if (origin != TelemetryItemOrigin.Storage)
                {
                    HandleNetworkFailure(httpMessage, blobProvider, origin, ref result);

                    if (result.ExportResult == ExportResult.Success)
                    {
                        CustomerSdkStatsHelper.TrackRetry(telemetrySchemaTypeCounter, (int)DropCode.ClientException, null);
                    }
                    else
                    {
                        CustomerSdkStatsHelper.TrackDropped(telemetrySchemaTypeCounter, blobProvider != null);
                    }
                }

                AzureMonitorExporterEventSource.Log.TransmissionFailed(
                    origin: origin,
                    statusCode: result.StatusCode,
                    isAadEnabled: isAadEnabled,
                    connectionVars: connectionVars,
                    requestEndpoint: httpMessage.Request.Uri.Host,
                    willRetry: result.WillRetry,
                    response: null);

                return result;
            }

            result.StatusCode = httpMessage.Response.Status;

            if (result.StatusCode == ResponseStatusCodes.PartialSuccess)
            {
                HandlePartialSuccess(httpMessage, blobProvider, blob, origin, ref result, telemetrySchemaTypeCounter);
            }
            else if (IsRetriableStatus(result.StatusCode))
            {
                HandleRetriableFailure(httpMessage, blobProvider, origin, ref result);

                if (result.ExportResult == ExportResult.Success)
                {
                    CustomerSdkStatsHelper.TrackRetry(telemetrySchemaTypeCounter, result.StatusCode, CustomerSdkStatsHelper.CategorizeStatusCode(result.StatusCode));
                }
                else
                {
                    CustomerSdkStatsHelper.TrackDropped(telemetrySchemaTypeCounter, blobProvider != null);
                }
            }
            else
            {
                HandleNonRetriableFailure(blob, origin, ref result);
                CustomerSdkStatsHelper.TrackDropped(telemetrySchemaTypeCounter, result.StatusCode, CustomerSdkStatsHelper.CategorizeStatusCode(result.StatusCode));
            }

            AzureMonitorExporterEventSource.Log.TransmissionFailed(
                origin: origin,
                statusCode: result.StatusCode,
                isAadEnabled: isAadEnabled,
                connectionVars: connectionVars,
                requestEndpoint: httpMessage.Request.Uri.Host,
                willRetry: result.WillRetry,
                response: httpMessage.Response);

            return result;
        }

        internal static string GetTelemetryTypeFromJson(string jsonItem)
        {
            try
            {
                using var doc = JsonDocument.Parse(jsonItem);
                if (doc.RootElement.TryGetProperty("name", out var nameElement))
                {
                    return nameElement.GetString() ?? "Unknown";
                }
            }
            catch
            {
                // Ignore parsing errors
            }
            return "Unknown";
        }

        internal static void IncrementCounterByType(TelemetrySchemaTypeCounter telemetrySchemaTypeCounter, string telemetryType)
        {
            switch (telemetryType)
            {
                case "Request":
                    telemetrySchemaTypeCounter._requestCount++;
                    break;
                case "RemoteDependency":
                    telemetrySchemaTypeCounter._dependencyCount++;
                    break;
                case "Exception":
                    telemetrySchemaTypeCounter._exceptionCount++;
                    break;
                case "Event":
                    telemetrySchemaTypeCounter._eventCount++;
                    break;
                case "Metric":
                    telemetrySchemaTypeCounter._metricCount++;
                    break;
                case "Message":
                    telemetrySchemaTypeCounter._traceCount++;
                    break;
                    // Unknown types are not tracked
            }
        }

        private static void HandleNetworkFailure(HttpMessage httpMessage, PersistentBlobProvider? blobProvider, TelemetryItemOrigin origin, ref TransmissionResult result)
        {
            if (blobProvider != null && TryGetRequestContent(httpMessage.Request.Content, out var content))
            {
                result.ExportResult = blobProvider.SaveTelemetry(content);
                result.WillRetry = (result.ExportResult == ExportResult.Success);
                result.SavedToStorage = result.WillRetry;
            }
        }

        private static void HandlePartialSuccess(HttpMessage httpMessage, PersistentBlobProvider? blobProvider, PersistentBlob? blob, TelemetryItemOrigin origin, ref TransmissionResult result, TelemetrySchemaTypeCounter? telemetrySchemaTypeCounter)
        {
            if (!TryGetTrackResponse(httpMessage, out TrackResponse? trackResponse))
            {
                return;
            }

            result.ItemsAccepted = trackResponse.ItemsAccepted;

            var (partialContent, successCounter, retryCounter, droppedCounter) = ProcessPartialSuccessWithCounting(trackResponse, httpMessage.Request.Content, telemetrySchemaTypeCounter);

            if (successCounter != null)
            {
                CustomerSdkStatsHelper.TrackSuccess(successCounter);
            }

            if (partialContent == null || blobProvider == null)
            {
                // No retry possible - track everything else as dropped
                if (retryCounter != null)
                {
                    CustomerSdkStatsHelper.TrackDropped(retryCounter, ResponseStatusCodes.PartialSuccess, "Partial success - no retry");
                }
                if (droppedCounter != null)
                {
                    CustomerSdkStatsHelper.TrackDropped(droppedCounter, ResponseStatusCodes.PartialSuccess, "Partial success - non-retriable");
                }

                return;
            }

            if (origin == TelemetryItemOrigin.Storage && blob != null)
            {
                if (blob.TryDelete())
                {
                    result.DeletedBlob = true;
                }
            }

            result.ExportResult = blobProvider.SaveTelemetry(partialContent);
            result.WillRetry = (result.ExportResult == ExportResult.Success);
            result.SavedToStorage = result.WillRetry;

            if (result.WillRetry && retryCounter != null)
            {
                CustomerSdkStatsHelper.TrackRetry(retryCounter, ResponseStatusCodes.PartialSuccess, "Partial success");
            }
            else if (retryCounter != null)
            {
                // Storage failed - track as dropped due to storage issues
                CustomerSdkStatsHelper.TrackDropped(retryCounter, (int)DropCode.ClientPersistenceIssue, "Storage failure");
            }

            // Track non-retriable errors as dropped
            if (droppedCounter != null)
            {
                CustomerSdkStatsHelper.TrackDropped(droppedCounter, ResponseStatusCodes.PartialSuccess, "Partial success - non-retriable");
            }
        }

        private static void HandleRetriableFailure(HttpMessage httpMessage, PersistentBlobProvider? blobProvider, TelemetryItemOrigin origin, ref TransmissionResult result)
        {
            if (origin != TelemetryItemOrigin.Storage)
            {
                if (blobProvider != null && TryGetRequestContent(httpMessage.Request.Content, out var content))
                {
                    result.ExportResult = blobProvider.SaveTelemetry(content);
                    result.WillRetry = (result.ExportResult == ExportResult.Success);
                    result.SavedToStorage = result.WillRetry;
                }
            }
            else if (origin == TelemetryItemOrigin.Storage)
            {
                result.WillRetry = true;
            }
        }

        private static void HandleNonRetriableFailure(PersistentBlob? blob, TelemetryItemOrigin origin, ref TransmissionResult result)
        {
            if (origin == TelemetryItemOrigin.Storage && blob != null)
            {
                if (blob.TryDelete())
                {
                    result.DeletedBlob = true;
                }
            }
        }

        private static void DecrementCounterByType(TelemetrySchemaTypeCounter telemetrySchemaTypeCounter, string telemetryType)
        {
            switch (telemetryType)
            {
                case "Request":
                    telemetrySchemaTypeCounter._requestCount = Math.Max(0, telemetrySchemaTypeCounter._requestCount - 1);
                    break;
                case "RemoteDependency":
                    telemetrySchemaTypeCounter._dependencyCount = Math.Max(0, telemetrySchemaTypeCounter._dependencyCount - 1);
                    break;
                case "Exception":
                    telemetrySchemaTypeCounter._exceptionCount = Math.Max(0, telemetrySchemaTypeCounter._exceptionCount - 1);
                    break;
                case "Event":
                    telemetrySchemaTypeCounter._eventCount = Math.Max(0, telemetrySchemaTypeCounter._eventCount - 1);
                    break;
                case "Metric":
                    telemetrySchemaTypeCounter._metricCount = Math.Max(0, telemetrySchemaTypeCounter._metricCount - 1);
                    break;
                case "Message":
                    telemetrySchemaTypeCounter._traceCount = Math.Max(0, telemetrySchemaTypeCounter._traceCount - 1);
                    break;
            }
        }

        private static bool HasAnyCount(TelemetrySchemaTypeCounter telemetrySchemaTypeCounter)
        {
            return telemetrySchemaTypeCounter._requestCount > 0 || telemetrySchemaTypeCounter._dependencyCount > 0 || telemetrySchemaTypeCounter._exceptionCount > 0 ||
                   telemetrySchemaTypeCounter._eventCount > 0 || telemetrySchemaTypeCounter._metricCount > 0 || telemetrySchemaTypeCounter._traceCount > 0;
        }
    }
}
