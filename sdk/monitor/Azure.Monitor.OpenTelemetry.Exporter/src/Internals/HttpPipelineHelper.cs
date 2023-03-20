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
using OpenTelemetry.Extensions.PersistentStorage.Abstractions;
using OpenTelemetry.Extensions.PersistentStorage;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.PersistentStorage;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class HttpPipelineHelper
    {
        private const string RetryAfterHeaderName = "Retry-After";

        internal static int MinimumRetryInterval = 60000;

        internal static int GetItemsAccepted(HttpMessage message)
        {
            return GetTrackResponse(message).ItemsAccepted.GetValueOrDefault();
        }

        internal static TrackResponse GetTrackResponse(HttpMessage message)
        {
            using (JsonDocument document = JsonDocument.Parse(message.Response.ContentStream, default))
            {
                var value = TrackResponse.DeserializeTrackResponse(document.RootElement);
                return Response.FromValue(value, message.Response);
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

            return false;
        }

        internal static byte[]? GetRequestContent(RequestContent? content)
        {
            if (content == null)
            {
                return null;
            }

            using MemoryStream st = new MemoryStream();

            content.WriteTo(st, CancellationToken.None);

            return st.ToArray();
        }

        internal static byte[]? GetPartialContentForRetry(TrackResponse trackResponse, RequestContent? content)
        {
            if (content == null)
            {
                return null;
            }

            string? partialContent = null;
            var fullContent = Encoding.UTF8.GetString(GetRequestContent(content)).Split('\n');
            foreach (var error in trackResponse.Errors)
            {
                if (error != null && error.Index != null)
                {
                    if (error.Index >= fullContent.Length || error.Index < 0)
                    {
                        // TODO: log
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
                            partialContent = fullContent[(int)error.Index];
                        }
                        else
                        {
                            partialContent += '\n' + fullContent[(int)error.Index];
                        }
                    }
                }
            }

            if (partialContent == null)
            {
                return null;
            }

            return Encoding.UTF8.GetBytes(partialContent);
        }

        internal static ExportResult IsSuccess(HttpMessage httpMessage)
        {
            if (httpMessage.HasResponse && httpMessage.Response.Status == ResponseStatusCodes.Success)
            {
                return ExportResult.Success;
            }

            return ExportResult.Failure;
        }

        internal static void HandleFailures(HttpMessage httpMessage, PersistentBlob blob, PersistentBlobProvider blobProvider)
        {
            int statusCode = 0;
            bool shouldRetry = true;

            if (httpMessage.HasResponse)
            {
                statusCode = httpMessage.Response.Status;
                switch (statusCode)
                {
                    case ResponseStatusCodes.PartialSuccess:
                        // Parse retry-after header
                        // Send Failed Messages To Storage
                        // Delete existing file
                        TrackResponse trackResponse = GetTrackResponse(httpMessage);
                        var content = GetPartialContentForRetry(trackResponse, httpMessage.Request.Content);
                        if (content != null)
                        {
                            blob.TryDelete();
                            blobProvider?.SaveTelemetry(content);
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
                        shouldRetry = false;
                        break;
                }
            }

            if (shouldRetry)
            {
                AzureMonitorExporterEventSource.Log.WriteWarning("FailedToTransmitFromStorage", $"Error code is {statusCode}: Telemetry is stored offline for retry");
            }
            else
            {
                AzureMonitorExporterEventSource.Log.WriteWarning("FailedToTransmitFromStorage", $"Error code is {statusCode}: Telemetry is dropped");
            }
        }
    }
}
