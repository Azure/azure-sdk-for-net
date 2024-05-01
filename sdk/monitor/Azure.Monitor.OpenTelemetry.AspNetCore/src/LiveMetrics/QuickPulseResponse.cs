// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Monitor.OpenTelemetry.AspNetCore.Models;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.LiveMetrics
{
    internal readonly struct QuickPulseResponse
    {
        public QuickPulseResponse(bool success, ResponseHeaders? responseHeaders = null, CollectionConfigurationInfo? info = null)
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

                CollectionConfigurationInfo = info;
            }
        }

        public bool Success { get; }
        public string? ConfigurationEtag { get; }
        public bool Subscribed { get; }
        public CollectionConfigurationInfo? CollectionConfigurationInfo { get; }
    }
}
