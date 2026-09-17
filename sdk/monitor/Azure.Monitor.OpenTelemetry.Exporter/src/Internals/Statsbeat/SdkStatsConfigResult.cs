// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat
{
    /// <summary>
    /// Outcome of an SDKStats configuration fetch. Tells the caller
    /// whether to honor the remote control plane (<see cref="UseConnectionString"/>), respect a remote
    /// kill switch (<see cref="Disabled"/>), or fall back to the legacy region-derived
    /// Statsbeat ingestion endpoint (<see cref="Fallback"/>).
    /// </summary>
    internal enum SdkStatsConfigStatus
    {
        /// <summary>
        /// Configuration was retrieved successfully and instructs the client to send SDK
        /// statistics to <see cref="SdkStatsConfigResult.ConnectionString"/>.
        /// </summary>
        UseConnectionString,
        UseUrl = UseConnectionString,

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
    /// Result of an SDKStats configuration fetch.
    /// <see cref="ConnectionString"/> is only meaningful when <see cref="Status"/> is
    /// <see cref="SdkStatsConfigStatus.UseConnectionString"/>.
    /// </summary>
    internal readonly struct SdkStatsConfigResult
    {
        public SdkStatsConfigResult(SdkStatsConfigStatus status, string? connectionString)
        {
            Status = status;
            ConnectionString = connectionString;
        }

        public SdkStatsConfigStatus Status { get; }

        public string? ConnectionString { get; }
        public string? Url => ConnectionString;

        internal static SdkStatsConfigResult UseConnectionString(string connectionString) =>
            new SdkStatsConfigResult(SdkStatsConfigStatus.UseConnectionString, connectionString);

        internal static SdkStatsConfigResult Disabled() => new SdkStatsConfigResult(SdkStatsConfigStatus.Disabled, null);

        internal static SdkStatsConfigResult Fallback() => new SdkStatsConfigResult(SdkStatsConfigStatus.Fallback, null);
    }
}
