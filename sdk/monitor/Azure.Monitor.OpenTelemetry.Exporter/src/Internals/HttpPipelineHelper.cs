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
using OpenTelemetry.PersistentStorage.FileSystem;

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
        /// <returns>Telemetry that will be tried.</returns>
        internal static byte[]? GetPartialContentForRetry(TrackResponse trackResponse, RequestContent? content)
        {
            if (content == null)
            {
                return null;
            }

            string? partialContent = null;
            if (TryGetRequestContent(content, out var requestContent))
            {
                var telemetryItems = Encoding.UTF8.GetString(requestContent).Split('\n');
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
                        }
                        else
                        {
                            AzureMonitorExporterEventSource.Log.PartialContentResponseUnhandled(error);
                        }
                    }
                }
            }

            return partialContent == null
                ? null
                : Encoding.UTF8.GetBytes(partialContent);
        }

        internal static ExportResult IsSuccess(HttpMessage httpMessage, TelemetryCounter? telemetryCounter = null)
        {
            if (httpMessage.HasResponse && httpMessage.Response.Status == ResponseStatusCodes.Success)
            {
                CustomerSdkStatsHelper.TrackSuccess(telemetryCounter);
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
        /// <param name="telemetryCounter">Telemetry counter for tracking metrics.</param>
        /// <returns>TransmissionResult describing actions taken.</returns>
        internal static TransmissionResult ProcessTransmissionResult(HttpMessage httpMessage, PersistentBlobProvider? blobProvider, PersistentBlob? blob, ConnectionVars connectionVars, TelemetryItemOrigin origin, bool isAadEnabled, TelemetryCounter? telemetryCounter = null)
        {
            var result = CreateTransmissionResult();

            if (!httpMessage.HasResponse)
            {
                if (origin != TelemetryItemOrigin.Storage)
                {
                    HandleNetworkFailure(httpMessage, blobProvider, origin, ref result);

                    if (result.ExportResult == ExportResult.Success)
                    {
                        CustomerSdkStatsHelper.TrackRetry(telemetryCounter, (int)DropCode.ClientException, null);
                    }
                    else
                    {
                        CustomerSdkStatsHelper.TrackDropped(telemetryCounter, blobProvider != null);
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
                HandlePartialSuccess(httpMessage, blobProvider, blob, origin, ref result);
            }
            else if (IsRetriableStatus(result.StatusCode))
            {
                HandleRetriableFailure(httpMessage, blobProvider, origin, ref result);

                if (result.ExportResult == ExportResult.Success)
                {
                    CustomerSdkStatsHelper.TrackRetry(telemetryCounter, result.StatusCode, CustomerSdkStatsHelper.CategorizeStatusCode(result.StatusCode));
                }
                else
                {
                    CustomerSdkStatsHelper.TrackDropped(telemetryCounter, blobProvider != null);
                }
            }
            else
            {
                HandleNonRetriableFailure(blob, origin, ref result);
                CustomerSdkStatsHelper.TrackDropped(telemetryCounter, result.StatusCode, CustomerSdkStatsHelper.CategorizeStatusCode(result.StatusCode));
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

        private static void HandleNetworkFailure(HttpMessage httpMessage, PersistentBlobProvider? blobProvider, TelemetryItemOrigin origin, ref TransmissionResult result)
        {
            if (blobProvider != null && TryGetRequestContent(httpMessage.Request.Content, out var content))
            {
                result.ExportResult = blobProvider.SaveTelemetry(content);
                result.WillRetry = (result.ExportResult == ExportResult.Success);
                result.SavedToStorage = result.WillRetry;
            }
        }

        private static void HandlePartialSuccess(HttpMessage httpMessage, PersistentBlobProvider? blobProvider, PersistentBlob? blob, TelemetryItemOrigin origin, ref TransmissionResult result)
        {
            if (!TryGetTrackResponse(httpMessage, out TrackResponse? trackResponse))
            {
                return;
            }

            result.ItemsAccepted = trackResponse.ItemsAccepted;
            var partialContent = GetPartialContentForRetry(trackResponse, httpMessage.Request.Content);
            if (partialContent == null || blobProvider == null)
            {
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
    }
}
