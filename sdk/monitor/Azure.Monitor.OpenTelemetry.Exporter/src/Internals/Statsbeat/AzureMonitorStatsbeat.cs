// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.NetworkSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat
{
    internal sealed class AzureMonitorStatsbeat : IDisposable
    {
        private static readonly Meter s_myMeter = new(StatsbeatConstants.AttachStatsbeatMeterName, "1.0");

        internal string? _statsbeat_ConnectionString;

        private string? _resourceProviderId;

        private string? _resourceProvider;

        private static string? s_runtimeVersion => SdkVersionUtils.GetVersion(typeof(object));

        private static string s_attachMode => SdkVersionUtils.SdkVersionPrefix != null ? "IntegratedAuto" : "Manual";

        private string _operatingSystem;

        private readonly string _customer_Ikey;

        private readonly IPlatform _platform;

        internal MeterProvider? _statsbeatMeterProvider;

        // Wall-clock throttle for the Attach observable gauge so it emits at most once per
        // AttachEmissionInterval even though the shared reader collects every 15 min.
        private long _lastAttachEmissionTicks;

        /// <summary>
        /// Records Network SDKStats on the shared statsbeat <see cref="MeterProvider"/>.
        /// </summary>
        internal NetworkSdkStatsManager? NetworkSdkStatsManager { get; }

        /// <summary>
        /// Background task that fetches the SDK statistics configuration and builds the
        /// distro-path <see cref="MeterProvider"/>. Exposed for tests to await deterministic
        /// completion; <see langword="null"/> when the legacy path is taken.
        /// </summary>
        internal Task? _configInitializationTask;

        internal static Regex s_endpoint_pattern => new("^https?://(?:www\\.)?([^/.-]+)");

        internal AzureMonitorStatsbeat(
            ConnectionVars connectionStringVars,
            IPlatform platform,
            System.Net.Http.HttpMessageHandler? sdkStatsConfigHttpHandler = null)
        {
            _platform = platform;

            _operatingSystem = platform.GetOSPlatformName();

            _customer_Ikey = connectionStringVars.InstrumentationKey;

            // IEnumerable<Measurement<T>> overload lets the callback yield zero measurements
            // while throttled - see GetAttachStatsbeat. Created up-front for both code paths
            // so that any background MeterProvider that comes online later (distro path)
            // immediately picks it up.
            s_myMeter.CreateObservableGauge(StatsbeatConstants.AttachStatsbeatMetricName, GetAttachStatsbeat);

            try
            {
                NetworkSdkStatsManager = new NetworkSdkStatsManager(connectionStringVars, platform);
            }
            catch
            {
                // Internal telemetry - swallow.
            }

            var routeToDistroEndpoint =
                AppContext.TryGetSwitch(StatsbeatConstants.RouteSdkStatsToDistroEndpointSwitchName, out var enabled)
                && enabled;

            if (routeToDistroEndpoint)
            {
                // Distro path: fetch the remote configuration in the background. The
                // MeterProvider is built either from the config-supplied url (success path)
                // or from the legacy region-derived endpoint (control-plane unavailable).
                // The only no-emission case is an explicit remote kill switch
                // (`enabled: false`). The constructor must NOT throw because that would
                // break the customer's exporter pin path.
                var configUrl = GetSdkStatsConfigUrl(connectionStringVars.IngestionEndpoint);
                var ingestionEndpoint = connectionStringVars.IngestionEndpoint;
                _configInitializationTask = Task.Run(() =>
                    InitializeFromConfigAsync(configUrl, ingestionEndpoint, sdkStatsConfigHttpHandler));
                return;
            }

            // Legacy path: pick the existing Application Insights internal resource based
            // on the customer's ingestion region. If the region isn't recognized, throw to
            // preserve historical behavior.
            _statsbeat_ConnectionString = GetStatsbeatConnectionString(connectionStringVars.IngestionEndpoint);
            if (_statsbeat_ConnectionString == null)
            {
                throw new InvalidOperationException("Could not find a matching endpoint to initialize Statsbeat.");
            }

            BuildMeterProvider(_statsbeat_ConnectionString);
            ScheduleInitialAttachFlush();
        }

        private async Task InitializeFromConfigAsync(
            string configUrl,
            string ingestionEndpoint,
            System.Net.Http.HttpMessageHandler? httpHandler)
        {
            try
            {
                var result = await SdkStatsConfigFetcher.FetchAsync(configUrl, httpHandler).ConfigureAwait(false);

                string connectionString;
                switch (result.Status)
                {
                    case SdkStatsConfigStatus.UseUrl:
                        connectionString = BuildConnectionStringFromHost(result.Url!);
                        break;
                    case SdkStatsConfigStatus.Disabled:
                        // Explicit remote kill switch. Honor it: do not build the
                        // MeterProvider. FetchAsync already logged the reason.
                        return;
                    case SdkStatsConfigStatus.Fallback:
                    default:
                        // Control plane unavailable or returned an incomplete contract.
                        // Fall back to the legacy region-derived endpoint so SDK statistics
                        // keep flowing. Unknown regions default to non-EU.
                        connectionString = GetLegacyFallbackConnectionString(ingestionEndpoint);
                        break;
                }

                _statsbeat_ConnectionString = connectionString;
                BuildMeterProvider(connectionString);
                ScheduleInitialAttachFlush();
            }
            catch (Exception ex)
            {
                // Defensive — the fetcher already swallows its own exceptions, but if
                // construction of the MeterProvider itself throws, leave SDK statistics off
                // rather than letting the unhandled exception escape the background task.
                AzureMonitorExporterEventSource.Log.SdkStatsConfigFetchFailed(
                    configUrl,
                    $"MeterProvider build failed: {ex.GetType().Name}");
            }
        }

        private static string BuildConnectionStringFromHost(string host)
        {
            // Build a Breeze-compatible connection string from the config-supplied host.
            // The transmitter appends the standard /v2.1/track path; the placeholder iKey
            // is required by ConnectionStringParser but is ignored server-side by the
            // distro endpoint family.
            var trimmed = host.TrimEnd('/');
            if (!trimmed.StartsWith("http://", StringComparison.OrdinalIgnoreCase)
                && !trimmed.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                trimmed = "https://" + trimmed;
            }
            return "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=" + trimmed + "/";
        }

        /// <summary>
        /// Returns the legacy AI internal Statsbeat connection string for the customer's
        /// region. Unknown regions default to non-EU. Used by the distro path when the
        /// remote configuration cannot be obtained, so SDK statistics keep flowing on the
        /// same endpoint that non-distro callers have always used.
        /// </summary>
        internal static string GetLegacyFallbackConnectionString(string ingestionEndpoint)
        {
            var legacy = GetStatsbeatConnectionString(ingestionEndpoint);
            return legacy ?? StatsbeatConstants.Statsbeat_ConnectionString_NonEU;
        }

        private void BuildMeterProvider(string connectionString)
        {
            // One MeterProvider for both long and short-interval stats. The reader runs at
            // the Network (15 min) cadence. Delta temporality + the Attach throttle keep the
            // long-interval instruments on their native 24 hr cadence. EnableStatsbeat=false
            // avoids a recursive Statsbeat construction inside the transmitter we're about to
            // attach.
            var exporterOptions = new AzureMonitorExporterOptions
            {
                DisableOfflineStorage = true,
                ConnectionString = connectionString,
                EnableStatsbeat = false,
            };

            _statsbeatMeterProvider = Sdk.CreateMeterProviderBuilder()
                .AddMeter(StatsbeatConstants.AttachStatsbeatMeterName)
                .AddMeter(StatsbeatConstants.FeatureStatsbeatMeterName)
                .AddMeter(StatsbeatConstants.DistroFeatureSdkStatsMeterName)
                .AddMeter(StatsbeatConstants.NetworkSdkStatsMeterName)
                .AddMeter(StatsbeatConstants.DistroNetworkSdkStatsMeterName)
                .AddReader(new PeriodicExportingMetricReader(new AzureMonitorMetricExporter(exporterOptions), StatsbeatConstants.NetworkStatsbeatInterval)
                { TemporalityPreference = MetricReaderTemporalityPreference.Delta })
                .Build();
        }

        private void ScheduleInitialAttachFlush()
        {
            // Wait 1 minute before sending the startup SDK stats attach signal to ensure
            // we don't collect data from very short-lived apps that could spam the stats.
            // If the version information is not yet available, wait up to five minutes —
            // it really should be done in one minute or less (whenever the first Export
            // call occurs, and otel does metrics at least once a minute). After the first
            // attach metric emission, the AttachEmissionInterval (24 hours by default)
            // takes over sending metrics.
            _ = Task.Run(async () =>
            {
                DateTime giveUpTime = DateTime.Now.AddMinutes(5);
                do
                {
                    await Task.Delay(TimeSpan.FromMinutes(1)).ConfigureAwait(false);
                    if (SdkVersionUtils.IsHydrated)
                        break;
                } while (!SdkVersionUtils.IsHydrated && giveUpTime > DateTime.Now);

                _statsbeatMeterProvider?.ForceFlush();
            });
        }

        internal static string? GetStatsbeatConnectionString(string ingestionEndpoint)
        {
            // Legacy path: maps the customer's ingestion region to the internal Application
            // Insights resource hosting Statsbeat. Returns null for unknown regions so the
            // caller can throw and leave Statsbeat disabled. (The distro path uses
            // GetSdkStatsConfigUrl + the runtime config endpoint instead of this.)
            var patternMatch = s_endpoint_pattern.Match(ingestionEndpoint);
            if (!patternMatch.Success)
            {
                return null;
            }

            var endpoint = patternMatch.Groups[1].Value;
            if (StatsbeatConstants.s_EU_Endpoints.Contains(endpoint))
            {
                return StatsbeatConstants.Statsbeat_ConnectionString_EU;
            }

            if (StatsbeatConstants.s_non_EU_Endpoints.Contains(endpoint))
            {
                return StatsbeatConstants.Statsbeat_ConnectionString_NonEU;
            }

            return null;
        }

        internal static string GetSdkStatsConfigUrl(string ingestionEndpoint)
        {
            // Distro path: pick the EU or non-EU configuration endpoint based on the
            // customer's ingestion region. Unknown regions default to non-EU.
            var patternMatch = s_endpoint_pattern.Match(ingestionEndpoint);
            if (patternMatch.Success
                && StatsbeatConstants.s_EU_Endpoints.Contains(patternMatch.Groups[1].Value))
            {
                return StatsbeatConstants.SdkStatsConfigUrl_EU;
            }

            return StatsbeatConstants.SdkStatsConfigUrl_NonEU;
        }

        private IEnumerable<Measurement<int>> GetAttachStatsbeat()
        {
            // Emit at most once per AttachEmissionInterval. Delta temporality means
            // skipped intervals don't produce an exported metric point.
            long previousTicks = Volatile.Read(ref _lastAttachEmissionTicks);
            long nowTicks = DateTime.UtcNow.Ticks;
            if (previousTicks != 0
                && nowTicks - previousTicks < StatsbeatConstants.AttachEmissionInterval.Ticks)
            {
                yield break;
            }

            // CAS before doing any work so a racing reader can't double-emit.
            if (Interlocked.CompareExchange(ref _lastAttachEmissionTicks, nowTicks, previousTicks) != previousTicks)
            {
                yield break;
            }

            Measurement<int> measurement;
            try
            {
                if (_resourceProvider == null)
                {
                    SetResourceProviderDetails(_platform);
                }

                measurement = new Measurement<int>(1,
                    new("rp", _resourceProvider),
                    new("rpId", _resourceProviderId),
                    new("attach", s_attachMode),
                    new("cikey", _customer_Ikey),
                    new("runtimeVersion", s_runtimeVersion),
                    new("language", "dotnet"),
                    // We don't memoize this version because it can be updated up to a minute into the application startup
                    new("version", SdkVersionUtils.GetVersion()),
                    new("os", _operatingSystem));
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.StatsbeatFailed(ex);
                // Rewind the throttle so we retry on the next collection.
                Volatile.Write(ref _lastAttachEmissionTicks, previousTicks);
                yield break;
            }

            yield return measurement;
        }

        internal static VmMetadataResponse? GetVmMetadataResponse()
        {
            try
            {
                // Prevent internal HTTP operations from being instrumented.
                using (var scope = SuppressInstrumentationScope.Begin())
                {
                    using (var httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(2) })
                    {
                        httpClient.DefaultRequestHeaders.Add("Metadata", "True");
                        var responseString = httpClient.GetStringAsync(StatsbeatConstants.AMS_Url);
                        VmMetadataResponse? vmMetadata;
#if NET
                        vmMetadata = JsonSerializer.Deserialize<VmMetadataResponse>(responseString.Result, SourceGenerationContext.Default.VmMetadataResponse);
#else
                        vmMetadata = JsonSerializer.Deserialize<VmMetadataResponse>(responseString.Result);
#endif

                        return vmMetadata;
                    }
                }
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.VmMetadataFailed(ex);
                return null;
            }
        }

        private void SetResourceProviderDetails(IPlatform platform)
        {
            var functionsWorkerRuntime = platform.GetEnvironmentVariable(EnvironmentVariableConstants.FUNCTIONS_WORKER_RUNTIME);
            if (functionsWorkerRuntime != null)
            {
                _resourceProvider = "functions";
                _resourceProviderId = platform.GetEnvironmentVariable(EnvironmentVariableConstants.WEBSITE_HOSTNAME);

                return;
            }

            var appSvcWebsiteName = platform.GetEnvironmentVariable(EnvironmentVariableConstants.WEBSITE_SITE_NAME);
            if (appSvcWebsiteName != null)
            {
                _resourceProvider = "appsvc";
                _resourceProviderId = appSvcWebsiteName;
                var appSvcWebsiteHostName = platform.GetEnvironmentVariable(EnvironmentVariableConstants.WEBSITE_HOME_STAMPNAME);
                if (!string.IsNullOrEmpty(appSvcWebsiteHostName))
                {
                    _resourceProviderId += "/" + appSvcWebsiteHostName;
                }

                return;
            }

            var aksArmNamespaceId = platform.GetEnvironmentVariable(EnvironmentVariableConstants.AKS_ARM_NAMESPACE_ID);
            if (aksArmNamespaceId != null)
            {
                _resourceProvider = "aks";
                _resourceProviderId = aksArmNamespaceId;

                return;
            }

            var vmMetadata = GetVmMetadataResponse();

            if (vmMetadata != null)
            {
                _resourceProvider = "vm";
                _resourceProviderId = _resourceProviderId = vmMetadata.vmId + "/" + vmMetadata.subscriptionId;

                // osType takes precedence.
                _operatingSystem = vmMetadata.osType?.ToLower(CultureInfo.InvariantCulture) ?? "unknown";

                return;
            }

            _resourceProvider = "unknown";
            _resourceProviderId = "unknown";
        }

        public void Dispose()
        {
            _statsbeatMeterProvider?.Dispose();
        }
    }
}
