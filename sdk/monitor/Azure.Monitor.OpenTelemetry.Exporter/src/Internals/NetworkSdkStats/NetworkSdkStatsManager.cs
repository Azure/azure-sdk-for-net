// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.NetworkSdkStats
{
    /// <summary>
    /// Records short-interval Network SDKStats metrics for a single Azure Monitor exporter
    /// transmitter, including request outcomes, duration, and item delivery outcomes.
    /// </summary>
    /// <remarks>
    /// One <see cref="NetworkSdkStatsManager"/> is created per <see cref="Statsbeat.AzureMonitorStatsbeat"/>
    /// instance. The dimensions <c>rp</c>, <c>runtimeVersion</c>,
    /// <c>os</c>, <c>language</c>, and <c>endpoint</c> are captured at
    /// initialization time. Version and attach mode are read at recording time to reflect late resource initialization.
    /// The version identifies the recognized distro when available, otherwise the exporter package.
    /// The <c>host</c> dimension is added per recorded measurement, and
    /// <c>statusCode</c> / <c>exceptionType</c> are added for the relevant instruments.
    /// Routed requests use each participating customer's <c>cikey</c>. A shared request and its
    /// duration are recorded once per customer. Partial responses are attributed by envelope index.
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

        // A shared regional request counts once for each participating customer, not once per envelope.
        internal void TrackRequest(string? requestHost, int? statusCode, double? durationMs, INetworkSdkStatsBatch batch, string? exceptionType = null)
        {
            foreach (var pair in batch.ItemCountsByInstrumentationKey)
            {
                TrackCustomerRequest(requestHost, statusCode, durationMs, pair.Key, exceptionType, pair.Value);
            }
        }

        private void TrackCustomerRequest(string? requestHost, int? statusCode, double? durationMs, string? customerIkey, string? exceptionType, int itemCount)
        {
            if (durationMs.HasValue)
            {
                TrackDuration(requestHost, durationMs.Value, customerIkey);
            }
            if (!statusCode.HasValue)
            {
                TrackException(requestHost, exceptionType, customerIkey);
            }
            else if (statusCode == ResponseStatusCodes.Success)
            {
                TrackSuccess(requestHost, customerIkey, itemCount);
            }
            else
            {
                TrackResponseFailure(requestHost, statusCode.Value, customerIkey);
            }
        }

        internal void TrackBatchDisposition(string? requestHost, INetworkSdkStatsBatch batch, bool willRetry)
        {
            var counter = willRetry ? _meters.ItemRetryCount : _meters.ItemDroppedCount;
            if (!counter.Enabled)
            {
                return;
            }
            foreach (var pair in batch.ItemCountsByInstrumentationKey)
            {
                TrackItems(counter, requestHost, pair.Value, pair.Key);
            }
        }

        internal void TrackPartialSuccess(string? requestHost, TrackResult response, INetworkSdkStatsBatch batch, bool queuedRetrySubset, bool retainedOriginals = false)
        {
            var errors = response.Errors;
            if (response.ItemsReceived != batch.Count || response.ItemsAccepted is not int accepted
                || accepted < 0 || accepted > batch.Count || errors == null || errors.Count != batch.Count - accepted)
            {
                AzureMonitorExporterEventSource.Log.PartialContentResponseInvalid(batch.Count, "N/A", "206", "Inconsistent partial-response counts.");
                return;
            }

            var indexes = new HashSet<int>();
            var rejected = new Dictionary<string, (int Total, int Queued)>(StringComparer.Ordinal);
            foreach (var error in errors)
            {
                if (error?.Index is not int index || index < 0 || index >= batch.Count
                    || error.StatusCode == null || !indexes.Add(index))
                {
                    AzureMonitorExporterEventSource.Log.PartialContentResponseInvalid(batch.Count,
                        error?.Index?.ToString() ?? "N/A", error?.StatusCode?.ToString() ?? "N/A", "Invalid or duplicate partial-response index.");
                    return;
                }

                var key = batch.GetInstrumentationKey(index);
                if (key != null)
                {
                    rejected.TryGetValue(key, out var counts);
                    counts.Total++;
                    if (queuedRetrySubset && HttpPipelineHelper.IsPartialRetryableStatus(error.StatusCode))
                    {
                        counts.Queued++;
                    }
                    rejected[key] = counts;
                }
            }

            foreach (var pair in batch.ItemCountsByInstrumentationKey)
            {
                rejected.TryGetValue(pair.Key, out var counts);
                TrackPartialSuccessAccepted(requestHost, pair.Value - counts.Total, pair.Key);
                // If rewriting a replay blob failed, the entire original remains queued on disk.
                TrackItems(_meters.ItemRetryCount, requestHost, retainedOriginals ? pair.Value : counts.Queued, pair.Key);
                if (!retainedOriginals)
                {
                    TrackItems(_meters.ItemDroppedCount, requestHost, counts.Total - counts.Queued, pair.Key);
                }
            }

            var requestErrors = new HashSet<(string Key, int Status)>();
            foreach (var error in errors)
            {
                var key = batch.GetInstrumentationKey(error.Index!.Value);
                if (key == null)
                {
                    continue;
                }
                var status = error.StatusCode!.Value;
                if (status == ResponseStatusCodes.PartialSuccess || !requestErrors.Add((key, status)))
                {
                    continue;
                }
                if (NetworkSdkStatsHelper.IsRetryable(status))
                {
                    TrackRetry(requestHost, status, key);
                }
                else
                {
                    TrackException(requestHost, status.ToString(System.Globalization.CultureInfo.InvariantCulture), key);
                }
            }
        }

        /// <summary>
        /// Record a successful HTTP 200 transmission to the ingestion endpoint.
        /// </summary>
        /// <param name="requestHost">Host portion of the request URI (e.g. <c>westus-0.in.applicationinsights.azure.com</c>).</param>
        /// <param name="customerIkey">Routed customer key, or null to use the configured default.</param>
        /// <param name="itemCount">Accepted items belonging to the customer.</param>
        public void TrackSuccess(string? requestHost, string? customerIkey = null, int itemCount = 0)
        {
            if (!_meters.RequestSuccessCount.Enabled && !_meters.ItemSuccessCount.Enabled)
            {
                return;
            }

            try
            {
                var tags = BuildBaseTags(NetworkSdkStatsHelper.ExtractStampHost(requestHost), customerIkey);
                RecordSuccessCounter(_meters.RequestSuccessCount, 1, in tags);
                if (itemCount > 0)
                {
                    RecordSuccessCounter(_meters.ItemSuccessCount, itemCount, in tags);
                }
            }
            catch
            {
                // Network SDK stats are internal telemetry; never let a recording failure
                // propagate or emit log noise that customers might mistake for an exporter
                // issue.
            }
        }

        private static void RecordSuccessCounter(Counter<long> counter, int count, in TagList tags)
        {
            try
            {
                counter.Add(count, in tags);
            }
            catch
            {
                // A failed listener must not suppress a different instrument.
            }
        }

        /// <summary>
        /// A 206 with accepted items contributes one request success for their customer.
        /// </summary>
        public void TrackPartialSuccessAccepted(string? requestHost, int count, string? customerIkey = null)
        {
            if (count > 0)
            {
                TrackSuccess(requestHost, customerIkey);
                TrackItems(_meters.ItemSuccessCount, requestHost, count, customerIkey);
            }
        }

        private void TrackItems(Counter<long> counter, string? requestHost, int count, string? customerIkey)
        {
            if (count <= 0 || !counter.Enabled)
            {
                return;
            }

            try
            {
                counter.Add(count, BuildBaseTags(NetworkSdkStatsHelper.ExtractStampHost(requestHost ?? _ingestionHost), customerIkey));
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
        public void TrackDuration(string? requestHost, double durationMs, string? customerIkey = null)
        {
            if (!_meters.RequestDuration.Enabled)
            {
                return;
            }

            try
            {
                _meters.RequestDuration.Record(durationMs, BuildBaseTags(NetworkSdkStatsHelper.ExtractStampHost(requestHost ?? _ingestionHost), customerIkey));
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
        public void TrackResponseFailure(string? requestHost, int statusCode, string? customerIkey = null)
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
                TrackRetry(requestHost, statusCode, customerIkey);
            }
            else if (NetworkSdkStatsHelper.IsThrottle(statusCode))
            {
                TrackThrottle(requestHost, statusCode, customerIkey);
            }
            else
            {
                TrackFailure(requestHost, statusCode, customerIkey);
            }
        }

        /// <summary>
        /// Record a non-retryable, non-throttling failure response. Backs <c>Request_Failure_Count</c>.
        /// </summary>
        public void TrackFailure(string? requestHost, int statusCode, string? customerIkey = null)
        {
            if (!_meters.RequestFailureCount.Enabled)
            {
                return;
            }

            try
            {
                _meters.RequestFailureCount.Add(1, BuildStatusCodeTags(NetworkSdkStatsHelper.ExtractStampHost(requestHost), statusCode, customerIkey));
            }
            catch
            {
                // See TrackSuccess for rationale.
            }
        }

        /// <summary>
        /// Record a retryable response. Backs <c>Retry_Count</c>.
        /// </summary>
        public void TrackRetry(string? requestHost, int statusCode, string? customerIkey = null)
        {
            if (!_meters.RetryCount.Enabled)
            {
                return;
            }

            try
            {
                _meters.RetryCount.Add(1, BuildStatusCodeTags(NetworkSdkStatsHelper.ExtractStampHost(requestHost), statusCode, customerIkey));
            }
            catch
            {
                // See TrackSuccess for rationale.
            }
        }

        /// <summary>
        /// Record a throttling response. Backs <c>Throttle_Count</c>.
        /// </summary>
        public void TrackThrottle(string? requestHost, int statusCode, string? customerIkey = null)
        {
            if (!_meters.ThrottleCount.Enabled)
            {
                return;
            }

            try
            {
                _meters.ThrottleCount.Add(1, BuildStatusCodeTags(NetworkSdkStatsHelper.ExtractStampHost(requestHost), statusCode, customerIkey));
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
        public void TrackException(string? requestHost, string? exceptionType, string? customerIkey = null)
        {
            if (!_meters.ExceptionCount.Enabled)
            {
                return;
            }

            try
            {
                string host = NetworkSdkStatsHelper.ExtractStampHost(requestHost ?? _ingestionHost);
                _meters.ExceptionCount.Add(1, BuildExceptionTags(host, exceptionType, customerIkey));
            }
            catch
            {
                // See TrackSuccess for rationale.
            }
        }

        internal TagList BuildBaseTags(string host, string? customerIkey = null)
        {
            // Resource provider can require an Azure Instance Metadata Service probe; defer
            // until the first measurement is recorded (matches AzureMonitorStatsbeat).
            _resourceProvider ??= ResourceProviderHelper.DetermineResourceProvider(_platform);

            // Use the resource-provided distro version without the legacy label or truncated exporter fallback.
            var distroVersion = SdkVersionUtils.s_extensionVersionOverride;
            return new TagList
            {
                { "rp", _resourceProvider },
                { "attach", SdkVersionUtils.SdkVersionPrefix != null ? "IntegratedAuto" : "Manual" },
                { "cikey", customerIkey ?? _customerIkey },
                { "runtimeVersion", _runtimeVersion },
                { "os", _operatingSystem },
                { "language", Language },
                { "version", string.IsNullOrWhiteSpace(distroVersion) ? s_exporterVersion : distroVersion },
                { "endpoint", StatsbeatConstants.NetworkSdkStatsEndpointBreeze },
                { "host", host },
            };
        }

        private TagList BuildStatusCodeTags(string host, int statusCode, string? customerIkey)
        {
            var tags = BuildBaseTags(host, customerIkey);
            tags.Add("statusCode", statusCode);
            return tags;
        }

        private TagList BuildExceptionTags(string host, string? exceptionType, string? customerIkey)
        {
            var tags = BuildBaseTags(host, customerIkey);
            tags.Add("exceptionType", exceptionType ?? "unknown");
            return tags;
        }
    }
}
