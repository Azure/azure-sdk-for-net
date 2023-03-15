// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;

using Azure.Core;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

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

        internal static bool TryGetRetryIntervalTimespan(Response httpResponse, out TimeSpan retryAfter)
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
    }
}
