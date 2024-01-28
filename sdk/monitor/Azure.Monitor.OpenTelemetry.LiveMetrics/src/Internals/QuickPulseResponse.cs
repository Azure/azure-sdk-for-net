// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals
{
    internal readonly struct QuickPulseResponse
    {
        public QuickPulseResponse(bool success, ResponseHeaders? responseHeaders = null)
        {
            Success = success;

            if (success)
            {
                if (responseHeaders?.TryGetValue("x-ms-qps-configuration-etag", out string? etagValue) ?? false)
                {
                    ConfigurationEtag = etagValue;
                }

                if (responseHeaders?.TryGetValue("x-ms-qps-subscribed", out string? subscribedValue) ?? false)
                {
                    Subscribed = Convert.ToBoolean(subscribedValue);
                }
            }
        }

        public bool Success { get; }
        public string? ConfigurationEtag { get; }
        public bool Subscribed { get; }

        // TODO: Filtering parameters can be added here.
    }
}
