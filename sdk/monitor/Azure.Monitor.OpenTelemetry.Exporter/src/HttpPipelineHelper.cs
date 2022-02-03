﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using Azure.Core;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry.Contrib.Extensions.PersistentStorage;

namespace Azure.Monitor.OpenTelemetry.Exporter
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

        internal static byte[] GetRequestContent(RequestContent content)
        {
            using MemoryStream st = new MemoryStream();

            content.WriteTo(st, CancellationToken.None);

            return st.ToArray();
        }

        internal static string GetPartialContentForRetry(TrackResponse response, HttpMessage message)
        {
            string partialContent = null;
            var fullContent = Encoding.UTF8.GetString(GetRequestContent(message.Request.Content))?.Split('\n');
            foreach (var error in response.Errors)
            {
                if (error != null)
                {
                    if (error.Index != null && error.Index >= fullContent.Length || error.Index < 0)
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
                            partialContent = fullContent[(int)error.Index];
                        }
                        else
                        {
                            partialContent += '\n' + fullContent[(int)error.Index];
                        }
                    }
                }
            }

            return partialContent;
        }

        internal static int SavePartialTelemetryToStorage(IPersistentStorage storage, HttpMessage message)
        {
            if (storage == null)
            {
                // log storage not initialized.
                return GetItemsAccepted(message);
            }

            TrackResponse response = GetTrackResponse(message);
            var partialContent = GetPartialContentForRetry(response, message);
            if (partialContent != null)
            {
                var retryInterval = GetRetryInterval(message);
                var blob = storage.CreateBlob(Encoding.UTF8.GetBytes(partialContent), retryInterval);
                if (blob != null)
                {
                    // log partial telemetry saved offline.
                    // unsuccessfull message will be logged by persistent storage.
                }
            }

            return response.ItemsAccepted.GetValueOrDefault();
        }

        internal static void SaveTelemetryToStorage(IPersistentStorage storage, HttpMessage message, bool readRetryHeader = false)
        {
            if (storage == null)
            {
                // log storage not initialized.
                return;
            }

            var content =  GetRequestContent(message.Request.Content);
            var retryInterval = MinimumRetryInterval;
            if (readRetryHeader)
            {
                retryInterval = GetRetryInterval(message);
            }

            var blob = storage.CreateBlob(content, retryInterval);
            if (blob != null)
            {
                // log telemetry saved offline.
                // unsuccessfull message will be logged by persistent storage.
            }
        }
    }
}
