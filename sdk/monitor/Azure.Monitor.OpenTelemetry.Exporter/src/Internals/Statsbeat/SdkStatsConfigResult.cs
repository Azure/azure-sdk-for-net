// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat
{
    /// <summary>
    /// Outcome of an <see cref="SdkStatsConfigFetcher.FetchAsync"/> call. Tells the caller
    /// whether to honor the remote control plane (<see cref="UseUrl"/>), respect a remote
    /// kill switch (<see cref="Disabled"/>), or fall back to the legacy region-derived
    /// Statsbeat ingestion endpoint (<see cref="Fallback"/>).
    /// </summary>
    internal enum SdkStatsConfigStatus
    {
        /// <summary>
        /// Configuration was retrieved successfully and instructs the client to send SDK
        /// statistics to <see cref="SdkStatsConfigResult.Url"/>.
        /// </summary>
        UseUrl,

        /// <summary>
        /// Configuration was retrieved successfully and explicitly disables SDK statistics
        /// for this process. The control plane has spoken; do not emit.
        /// </summary>
        Disabled,

        /// <summary>
        /// Configuration could not be retrieved (network failure, timeout, 4xx/5xx, parse
        /// error, schema mismatch, missing/empty <c>url</c>). The caller should fall back
        /// to the legacy region-derived Statsbeat endpoint so SDK statistics keep flowing
        /// in the absence of a working control plane.
        /// </summary>
        Fallback,
    }

    /// <summary>
    /// Result of an <see cref="SdkStatsConfigFetcher.FetchAsync"/> call.
    /// <see cref="Url"/> is only meaningful when <see cref="Status"/> is
    /// <see cref="SdkStatsConfigStatus.UseUrl"/>.
    /// </summary>
    internal readonly struct SdkStatsConfigResult
    {
        public SdkStatsConfigResult(SdkStatsConfigStatus status, string? url)
        {
            Status = status;
            Url = url;
        }

        public SdkStatsConfigStatus Status { get; }

        public string? Url { get; }

        internal static SdkStatsConfigResult UseUrl(string url) => new SdkStatsConfigResult(SdkStatsConfigStatus.UseUrl, url);

        internal static SdkStatsConfigResult Disabled() => new SdkStatsConfigResult(SdkStatsConfigStatus.Disabled, null);

        internal static SdkStatsConfigResult Fallback() => new SdkStatsConfigResult(SdkStatsConfigStatus.Fallback, null);
    }
}
