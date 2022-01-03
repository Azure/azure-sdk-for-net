// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Azure.Core;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal static class HttpPipelineHelper
    {
        private const string RetryAfterHeaderName = "Retry-After";

        internal const int MinimumRetryInterval = 6000;

        internal static byte[] GetRequestContent(RequestContent content)
        {
            using MemoryStream st = new MemoryStream();

            content.WriteTo(st, CancellationToken.None);

            return st.ToArray();
        }

        internal static int GetRetryInterval(HttpMessage message)
        {
            if (message.Response.Headers.TryGetValue(RetryAfterHeaderName, out var retryAfterValue))
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

        internal static string GetPartialContentFromBreeze(TrackResponse response, string content)
        {
            string partialContent = null;
            var contentArray = content.Split('\n');
            foreach (var error in response.Errors)
            {
                if (error != null)
                {
                    if (error.Index != null && error.Index >= contentArray.Length || error.Index < 0)
                    {
                        // log
                        continue;
                    }

                    if (error.StatusCode == ResponseStatusCodes.RequestTimeout ||
                    error.StatusCode == ResponseStatusCodes.ServiceUnavailable ||
                    error.StatusCode == ResponseStatusCodes.InternalServerError ||
                    error.StatusCode == ResponseStatusCodes.ResponseCodeTooManyRequests ||
                    error.StatusCode == ResponseStatusCodes.ResponseCodeTooManyRequestsAndRefreshCache)
                    {
                        if (string.IsNullOrEmpty(partialContent))
                        {
                            partialContent = contentArray[(int)error.Index];
                        }
                        else
                        {
                            partialContent += Environment.NewLine + contentArray[(int)error.Index];
                        }
                    }
                }
            }

            return partialContent;
        }
    }
}
