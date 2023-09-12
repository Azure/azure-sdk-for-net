// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;

using Azure.Core;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry;
using OpenTelemetry.PersistentStorage.Abstractions;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage;
using System.Diagnostics.CodeAnalysis;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using System.Collections.Generic;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class HttpPipelineHelper
    {
        private const string RetryAfterHeaderName = "Retry-After";

        internal static int MinimumRetryInterval = 60000;

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

        internal static ExportResult IsSuccess(HttpMessage httpMessage)
        {
            if (httpMessage.HasResponse && httpMessage.Response.Status == ResponseStatusCodes.Success)
            {
                return ExportResult.Success;
            }

            return ExportResult.Failure;
        }

        internal static ExportResult HandleFailures(HttpMessage httpMessage, PersistentBlobProvider blobProvider, ConnectionVars connectionVars, TelemetryItemOrigin origin, bool isAadEnabled)
        {
            ExportResult result = ExportResult.Failure;
            int statusCode = 0;
            byte[]? content;

            if (!httpMessage.HasResponse)
            {
                // HttpRequestException
                if (TryGetRequestContent(httpMessage.Request.Content, out content))
                {
                    result = blobProvider.SaveTelemetry(content);
                }
            }
            else
            {
                statusCode = httpMessage.Response.Status;
                switch (statusCode)
                {
                    case ResponseStatusCodes.PartialSuccess:
                        // Parse retry-after header
                        // Send Failed Messages To Storage
                        if (TryGetTrackResponse(httpMessage, out TrackResponse? trackResponse))
                        {
                            content = HttpPipelineHelper.GetPartialContentForRetry(trackResponse, httpMessage.Request.Content);
                            if (content != null)
                            {
                                result = blobProvider.SaveTelemetry(content);
                            }
                        }
                        break;
                    case ResponseStatusCodes.RequestTimeout:
                    case ResponseStatusCodes.ResponseCodeTooManyRequests:
                    case ResponseStatusCodes.ResponseCodeTooManyRequestsAndRefreshCache:
                    case ResponseStatusCodes.Unauthorized:
                    case ResponseStatusCodes.Forbidden:
                    case ResponseStatusCodes.InternalServerError:
                    case ResponseStatusCodes.BadGateway:
                    case ResponseStatusCodes.ServiceUnavailable:
                    case ResponseStatusCodes.GatewayTimeout:
                        // Send Messages To Storage
                        if (TryGetRequestContent(httpMessage.Request.Content, out content))
                        {
                            result = blobProvider.SaveTelemetry(content);
                        }
                        break;
                    default:
                        // Log Non-Retriable Status and don't retry or store;
                        break;
                }
            }

            AzureMonitorExporterEventSource.Log.TransmissionFailed(
                origin: origin,
                statusCode: statusCode,
                isAadEnabled: isAadEnabled,
                connectionVars: connectionVars,
                requestEndpoint: httpMessage.Request.Uri.Host,
                willRetry: (result == ExportResult.Success),
                response: httpMessage.HasResponse ? httpMessage.Response : null);

            return result;
        }

        internal static void HandleFailures(HttpMessage httpMessage, PersistentBlob blob, PersistentBlobProvider blobProvider, ConnectionVars connectionVars, bool isAadEnabled)
        {
            int statusCode = 0;
            bool willRetry = true;

            if (httpMessage.HasResponse)
            {
                statusCode = httpMessage.Response.Status;
                switch (statusCode)
                {
                    case ResponseStatusCodes.PartialSuccess:
                        // Parse retry-after header
                        // Send Failed Messages To Storage
                        // Delete existing file
                        if (TryGetTrackResponse(httpMessage, out TrackResponse? trackResponse))
                        {
                            var content = GetPartialContentForRetry(trackResponse, httpMessage.Request.Content);
                            if (content != null)
                            {
                                blob.TryDelete();
                                blobProvider.SaveTelemetry(content);
                            }
                        }
                        break;
                    case ResponseStatusCodes.RequestTimeout:
                    case ResponseStatusCodes.ResponseCodeTooManyRequests:
                    case ResponseStatusCodes.ResponseCodeTooManyRequestsAndRefreshCache:
                    case ResponseStatusCodes.Unauthorized:
                    case ResponseStatusCodes.Forbidden:
                    case ResponseStatusCodes.InternalServerError:
                    case ResponseStatusCodes.BadGateway:
                    case ResponseStatusCodes.ServiceUnavailable:
                    case ResponseStatusCodes.GatewayTimeout:
                        break;
                    default:
                        willRetry = false;
                        break;
                }
            }

            AzureMonitorExporterEventSource.Log.TransmissionFailed(
                origin: TelemetryItemOrigin.Storage,
                isAadEnabled: isAadEnabled,
                statusCode: statusCode,
                connectionVars: connectionVars,
                requestEndpoint: httpMessage.Request.Uri.Host,
                willRetry: willRetry,
                response: httpMessage.HasResponse ? httpMessage.Response : null);
        }
    }
}
