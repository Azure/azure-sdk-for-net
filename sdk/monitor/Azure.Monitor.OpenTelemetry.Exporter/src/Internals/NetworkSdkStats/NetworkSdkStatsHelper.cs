// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.NetworkSdkStats
{
    /// <summary>
    /// Stateless helpers for Network SDKStats. Initial scope only exposes host extraction;
    /// the response-status classification helpers required by the failure / retry / throttle
    /// / exception instruments will be added alongside those instruments in a follow-up.
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
    }
}
