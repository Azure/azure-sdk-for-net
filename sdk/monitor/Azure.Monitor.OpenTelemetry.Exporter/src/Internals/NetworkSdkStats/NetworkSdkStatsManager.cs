// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.NetworkSdkStats
{
    /// <summary>
    /// Records short-interval Network SDKStats metrics for a single Azure Monitor exporter
    /// transmitter. Initial scope only emits <c>Request_Success_Count</c>; additional
    /// instruments (failure / retry / throttle / exception / duration) will be added in
    /// follow-up changes.
    /// </summary>
    /// <remarks>
    /// One <see cref="NetworkSdkStatsManager"/> is created per <see cref="Statsbeat.AzureMonitorStatsbeat"/>
    /// instance. The dimensions <c>rp</c>, <c>attach</c>, <c>cikey</c>, <c>runtimeVersion</c>,
    /// <c>os</c>, <c>language</c>, <c>version</c>, and <c>endpoint</c> are captured at
    /// initialization time; the <c>host</c> dimension is added per recorded measurement.
    /// </remarks>
    internal sealed class NetworkSdkStatsManager
    {
        private const string Language = "dotnet";

        private readonly string _customerIkey;
        private readonly IPlatform _platform;
        private string? _resourceProvider;

        internal NetworkSdkStatsManager(ConnectionVars connectionVars, IPlatform platform)
        {
            _platform = platform;
            _customerIkey = string.IsNullOrEmpty(connectionVars?.InstrumentationKey) ? "N/A" : connectionVars!.InstrumentationKey;
        }

        /// <summary>
        /// Record a successful HTTP 200 transmission to the ingestion endpoint.
        /// </summary>
        /// <param name="requestHost">Host portion of the request URI (e.g. <c>westus-0.in.applicationinsights.azure.com</c>).</param>
        public void TrackSuccess(string? requestHost)
        {
            try
            {
                NetworkSdkStatsMeters.RequestSuccessCount.Add(1, BuildBaseTags(NetworkSdkStatsHelper.ExtractStampHost(requestHost)));
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
            if (count <= 0)
            {
                return;
            }

            try
            {
                NetworkSdkStatsMeters.RequestSuccessCount.Add(count, BuildBaseTags(NetworkSdkStatsHelper.ExtractStampHost(requestHost)));
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
                { "runtimeVersion", SdkVersionUtils.GetVersion(typeof(object)) },
                { "os", _platform.GetOSPlatformName() },
                { "language", Language },
                // Read on every recording so the exporter version reflects any late hydration
                // performed by ResourceExtensions (similar to AzureMonitorStatsbeat).
                { "version", SdkVersionUtils.GetVersion() },
                { "endpoint", StatsbeatConstants.NetworkSdkStatsEndpointBreeze },
                { "host", host },
            };
        }
    }
}
