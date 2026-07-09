// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.NetworkSdkStats
{
    /// <summary>
    /// Stateless helpers for Network SDKStats: stamp-host extraction and the breeze
    /// response-status classification (retryable / throttling) used by the failure /
    /// retry / throttle / exception instruments.
    /// </summary>
    internal static class NetworkSdkStatsHelper
    {
        /// <summary>
        /// Extract the stamp-specific host segment from an ingestion endpoint host name.
        /// </summary>
        public static string ExtractStampHost(string? requestHost)
        {
            if (string.IsNullOrEmpty(requestHost))
            {
                return "unknown";
            }

            // Strip a leading "www." if present, then return everything up to the first '.'.
            const string wwwPrefix = "www.";
            string host = requestHost!;
            if (host.StartsWith(wwwPrefix, System.StringComparison.OrdinalIgnoreCase))
            {
                host = host.Substring(wwwPrefix.Length);
            }

            int firstDot = host.IndexOf('.');
            return firstDot > 0 ? host.Substring(0, firstDot) : host;
        }

        /// <summary>
        /// Whether a breeze (HTTP) status code is retryable per the Network SDKStats spec:
        /// 401, 403, 408, 429, 500, 502, 503, or 504.
        /// </summary>
        public static bool IsRetryable(int statusCode) =>
            statusCode == ResponseStatusCodes.Unauthorized
            || statusCode == ResponseStatusCodes.Forbidden
            || statusCode == ResponseStatusCodes.RequestTimeout
            || statusCode == ResponseStatusCodes.ResponseCodeTooManyRequests
            || statusCode == ResponseStatusCodes.InternalServerError
            || statusCode == ResponseStatusCodes.BadGateway
            || statusCode == ResponseStatusCodes.ServiceUnavailable
            || statusCode == ResponseStatusCodes.GatewayTimeout;

        /// <summary>
        /// Whether a breeze (HTTP) status code is a throttling response per the Network SDKStats
        /// spec: 402 or 439.
        /// </summary>
        public static bool IsThrottle(int statusCode) =>
            statusCode == ResponseStatusCodes.PaymentRequired
            || statusCode == ResponseStatusCodes.ResponseCodeTooManyRequestsAndRefreshCache;
    }
}
