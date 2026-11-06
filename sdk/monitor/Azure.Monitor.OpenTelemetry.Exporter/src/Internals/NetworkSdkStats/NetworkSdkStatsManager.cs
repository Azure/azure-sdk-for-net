// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.NetworkSdkStats
{
    /// <summary>
    /// Records short-interval Network SDKStats metrics for a single Azure Monitor exporter
    /// transmitter: <c>Request_Success_Count</c>, <c>Request_Failure_Count</c>,
    /// <c>Request_Duration</c>, <c>Retry_Count</c>, <c>Throttle_Count</c>, and
    /// <c>Exception_Count</c>.
    /// </summary>
    /// <remarks>
    /// One <see cref="NetworkSdkStatsManager"/> is created per <see cref="Statsbeat.AzureMonitorStatsbeat"/>
    /// instance. The dimensions <c>rp</c>, <c>cikey</c>, <c>runtimeVersion</c>,
    /// <c>os</c>, <c>language</c>, and <c>endpoint</c> are captured at
    /// initialization time. The version identifies the exporter package, and attach mode is read at recording time.
    /// The <c>host</c> dimension is added per recorded measurement, and
    /// <c>statusCode</c> / <c>exceptionType</c> are added for the relevant instruments.
    /// </remarks>
    internal sealed class NetworkSdkStatsManager : IDisposable
    {
        private const string Language = "dotnet";
        private static readonly string? s_exporterVersion = SdkVersionUtils.GetVersion(typeof(AzureMonitorTraceExporter), truncate: false);

        private readonly string _customerIkey;
        private readonly NetworkSdkStatsMeters _meters;
        private readonly IPlatform _platform;
        private readonly string? _runtimeVersion;
        private readonly string _operatingSystem;
        private readonly string? _ingestionHost;
        private string? _resourceProvider;

        internal NetworkSdkStatsManager(ConnectionVars connectionVars, IPlatform platform, bool multiEndpointEnabled = false)
        {
            _platform = platform;
            _customerIkey = multiEndpointEnabled || string.IsNullOrEmpty(connectionVars?.InstrumentationKey)
                ? "N/A" : connectionVars!.InstrumentationKey;

            // Configured ingestion host, used as a best-effort host dimension when an exception
            // prevents us from observing the actual (possibly redirected) request host.
            if (connectionVars != null && Uri.TryCreate(connectionVars.IngestionEndpoint, UriKind.Absolute, out Uri? ingestionUri))
            {
                _ingestionHost = ingestionUri.Host;
            }

            // These dimensions are invariant for the process lifetime, so capture them
            // once instead of recomputing on every recorded measurement (matches
            // AzureMonitorStatsbeat, which caches the OS name at construction).
            _runtimeVersion = SdkVersionUtils.GetVersion(typeof(object), truncate: false);
            _operatingSystem = platform.GetOSPlatformName();
            _meters = new NetworkSdkStatsMeters();
        }

        internal bool Owns(Instrument instrument) => ReferenceEquals(instrument.Meter, _meters.Meter);

        public void Dispose() => _meters.Dispose();

        /// <summary>
        /// Record a successful HTTP 200 transmission to the ingestion endpoint.
        /// </summary>
        /// <param name="requestHost">Host portion of the request URI (e.g. <c>westus-0.in.applicationinsights.azure.com</c>).</param>
        public void TrackSuccess(string? requestHost)
        {
            if (!_meters.RequestSuccessCount.Enabled)
            {
                return;
            }

            try
            {
                _meters.RequestSuccessCount.Add(1, BuildBaseTags(NetworkSdkStatsHelper.ExtractStampHost(requestHost)));
            }
            catch
            {
                // Network SDK stats are internal telemetry; never let a recording failure
                // propagate or emit log noise that customers might mistake for an exporter
                // issue.
            }
        }

        /// <summary>
        /// Record accepted envelopes from a 206 Partial Success response. Per the Network
        /// SDKStats specification, accepted envelopes within a 206 response are counted
        /// toward <c>Request_Success_Count</c>.
        /// </summary>
        public void TrackPartialSuccessAccepted(string? requestHost, int count)
        {
            if (count <= 0 || !_meters.RequestSuccessCount.Enabled)
            {
                return;
            }

            try
            {
                _meters.RequestSuccessCount.Add(count, BuildBaseTags(NetworkSdkStatsHelper.ExtractStampHost(requestHost)));
            }
            catch
            {
                // See TrackSuccess for rationale.
            }
        }

        /// <summary>
        /// Record the duration of an attempted request, including requests that threw
        /// without a response. Backs the <c>Request_Duration</c> (avg) metric.
        /// </summary>
        public void TrackDuration(string? requestHost, double durationMs)
        {
            if (!_meters.RequestDuration.Enabled)
            {
                return;
            }

            try
            {
                _meters.RequestDuration.Record(durationMs, BuildBaseTags(NetworkSdkStatsHelper.ExtractStampHost(requestHost ?? _ingestionHost)));
            }
            catch
            {
                // See TrackSuccess for rationale.
            }
        }

        /// <summary>
        /// Classify a non-success top-level response and record the matching Network SDKStats
        /// instrument (<c>Retry_Count</c>, <c>Throttle_Count</c>, or <c>Request_Failure_Count</c>).
        /// HTTP 200 / 206 and 307 / 308 redirects are handled elsewhere and ignored here.
        /// </summary>
        public void TrackResponseFailure(string? requestHost, int statusCode)
        {
            // 200 (success) and 206 (partial success - per-envelope handling) are tracked
            // elsewhere. Redirects are followed by the pipeline and are not a terminal outcome.
            if (statusCode == ResponseStatusCodes.Success
                || statusCode == ResponseStatusCodes.PartialSuccess
                || statusCode == ResponseStatusCodes.TemporaryRedirect
                || statusCode == ResponseStatusCodes.PermanentRedirect)
            {
                return;
            }

            if (NetworkSdkStatsHelper.IsRetryable(statusCode))
            {
                TrackRetry(requestHost, statusCode);
            }
            else if (NetworkSdkStatsHelper.IsThrottle(statusCode))
            {
                TrackThrottle(requestHost, statusCode);
            }
            else
            {
                TrackFailure(requestHost, statusCode);
            }
        }

        /// <summary>
        /// Record a non-retryable, non-throttling failure response. Backs <c>Request_Failure_Count</c>.
        /// </summary>
        public void TrackFailure(string? requestHost, int statusCode)
        {
            if (!_meters.RequestFailureCount.Enabled)
            {
                return;
            }

            try
            {
                _meters.RequestFailureCount.Add(1, BuildStatusCodeTags(NetworkSdkStatsHelper.ExtractStampHost(requestHost), statusCode));
            }
            catch
            {
                // See TrackSuccess for rationale.
            }
        }

        /// <summary>
        /// Record a retryable response. Backs <c>Retry_Count</c>.
        /// </summary>
        public void TrackRetry(string? requestHost, int statusCode)
        {
            if (!_meters.RetryCount.Enabled)
            {
                return;
            }

            try
            {
                _meters.RetryCount.Add(1, BuildStatusCodeTags(NetworkSdkStatsHelper.ExtractStampHost(requestHost), statusCode));
            }
            catch
            {
                // See TrackSuccess for rationale.
            }
        }

        /// <summary>
        /// Record a throttling response. Backs <c>Throttle_Count</c>.
        /// </summary>
        public void TrackThrottle(string? requestHost, int statusCode)
        {
            if (!_meters.ThrottleCount.Enabled)
            {
                return;
            }

            try
            {
                _meters.ThrottleCount.Add(1, BuildStatusCodeTags(NetworkSdkStatsHelper.ExtractStampHost(requestHost), statusCode));
            }
            catch
            {
                // See TrackSuccess for rationale.
            }
        }

        /// <summary>
        /// Record an exception that occurred during the HTTP call (no response code received).
        /// Backs <c>Exception_Count</c>. When <paramref name="requestHost"/> is <c>null</c> the
        /// configured ingestion host is used as a best-effort value.
        /// </summary>
        public void TrackException(string? requestHost, string? exceptionType)
        {
            if (!_meters.ExceptionCount.Enabled)
            {
                return;
            }

            try
            {
                string host = NetworkSdkStatsHelper.ExtractStampHost(requestHost ?? _ingestionHost);
                _meters.ExceptionCount.Add(1, BuildExceptionTags(host, exceptionType));
            }
            catch
            {
                // See TrackSuccess for rationale.
            }
        }

        internal TagList BuildBaseTags(string host)
        {
            // Resource provider can require an Azure Instance Metadata Service probe; defer
            // until the first measurement is recorded (matches AzureMonitorStatsbeat).
            _resourceProvider ??= ResourceProviderHelper.DetermineResourceProvider(_platform);

            return new TagList
            {
                { "rp", _resourceProvider },
                { "attach", SdkVersionUtils.SdkVersionPrefix != null ? "IntegratedAuto" : "Manual" },
                { "cikey", _customerIkey },
                { "runtimeVersion", _runtimeVersion },
                { "os", _operatingSystem },
                { "language", Language },
                { "version", s_exporterVersion },
                { "endpoint", StatsbeatConstants.NetworkSdkStatsEndpointBreeze },
                { "host", host },
            };
        }

        private TagList BuildStatusCodeTags(string host, int statusCode)
        {
            var tags = BuildBaseTags(host);
            tags.Add("statusCode", statusCode);
            return tags;
        }

        private TagList BuildExceptionTags(string host, string? exceptionType)
        {
            var tags = BuildBaseTags(host);
            tags.Add("exceptionType", exceptionType ?? "unknown");
            return tags;
        }
    }
}
