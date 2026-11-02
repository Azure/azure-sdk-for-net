// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.MultiEndpoint;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.NetworkSdkStats;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat
{
    internal sealed class AzureMonitorStatsbeat : IDisposable
    {
        private static readonly Meter s_attachMeter = new(StatsbeatConstants.AttachStatsbeatMeterName, "1.0");
        private static readonly double s_timestampToTicks = (double)TimeSpan.TicksPerSecond / Stopwatch.Frequency;

        internal string? _statsbeat_ConnectionString;

        private string? _resourceProviderId;

        private string? _resourceProvider;

        private static string? s_runtimeVersion => SdkVersionUtils.GetVersion(typeof(object));

        private static string s_attachMode => SdkVersionUtils.SdkVersionPrefix != null ? "IntegratedAuto" : "Manual";

        private string _operatingSystem;

        private readonly string _customer_Ikey;

        private readonly IPlatform _platform;

        private readonly ObservableGauge<int> _attachInstrument;
        internal readonly MultiEndpointStatsbeat? _multiEndpointStats;

        private readonly bool _isRoutingOnly;
        private readonly bool _collectOtherStats;

        internal readonly int _networkExportIntervalMilliseconds;

        internal readonly TimeSpan _attachEmissionInterval;

        private readonly string? _connectionStringOverride;

        internal MeterProvider? _statsbeatMeterProvider;

        private volatile bool _isDisposed;

        // Monotonic throttle for the Attach observable gauge so it emits at most once per
        // AttachEmissionInterval even though the shared reader collects every 15 min.
        private long _lastAttachEmissionTicks = -1;

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

        internal static readonly Regex s_endpoint_pattern = new("^https?://(?:www\\.)?([^/.-]+)");

        internal AzureMonitorStatsbeat(
            ConnectionVars connectionStringVars,
            IPlatform platform,
            System.Net.Http.HttpMessageHandler? sdkStatsConfigHttpHandler = null,
            bool multiEndpointEnabled = false)
        {
            _platform = platform;
            _isRoutingOnly = connectionStringVars.IsUnconfigured;

            _operatingSystem = platform.GetOSPlatformName();

            _networkExportIntervalMilliseconds = ResolveIntervalMilliseconds(
                platform,
                EnvironmentVariableConstants.APPLICATIONINSIGHTS_STATS_SHORT_EXPORT_INTERVAL,
                StatsbeatConstants.NetworkStatsbeatInterval);

            _attachEmissionInterval = ResolveInterval(
                platform,
                EnvironmentVariableConstants.APPLICATIONINSIGHTS_STATS_LONG_EXPORT_INTERVAL,
                StatsbeatConstants.AttachEmissionInterval);

            var connectionStringOverride = platform.GetEnvironmentVariable(EnvironmentVariableConstants.APPLICATIONINSIGHTS_STATS_CONNECTION_STRING);
            _connectionStringOverride = string.IsNullOrWhiteSpace(connectionStringOverride) ? null : connectionStringOverride;
            var routeToDistroEndpoint =
                AppContext.TryGetSwitch(StatsbeatConstants.RouteSdkStatsToDistroEndpointSwitchName, out var enabled)
                && enabled;
            _collectOtherStats = !_isRoutingOnly
                && (_connectionStringOverride != null || routeToDistroEndpoint
                    || GetStatsbeatConnectionString(connectionStringVars.IngestionEndpoint) != null);

            _customer_Ikey = connectionStringVars.InstrumentationKey;

            if (multiEndpointEnabled)
            {
                _multiEndpointStats = new MultiEndpointStatsbeat(
                    _connectionStringOverride, connectionStringVars.IngestionEndpoint,
                    sdkStatsConfigHttpHandler, _attachEmissionInterval, CreateAttachMeasurement);
            }

            // IEnumerable<Measurement<T>> overload lets the callback yield zero measurements
            // while throttled - see GetAttachStatsbeat. Created up-front for both code paths
            // so that any background MeterProvider that comes online later (distro path)
            // immediately picks it up.
            Func<IEnumerable<Measurement<int>>> collectAttach = _multiEndpointStats == null
                ? GetAttachStatsbeat : _multiEndpointStats.GetMeasurements;
            _attachInstrument = s_attachMeter.CreateObservableGauge(StatsbeatConstants.AttachStatsbeatMetricName, collectAttach);

            if (_collectOtherStats)
            {
                try
                {
                    NetworkSdkStatsManager = new NetworkSdkStatsManager(connectionStringVars, platform);
                }
                catch
                {
                    // Internal telemetry - swallow.
                }
            }

            if (_multiEndpointStats != null)
            {
                if (routeToDistroEndpoint && _connectionStringOverride == null)
                {
                    _configInitializationTask = Task.Run(InitializeMultiEndpointAsync);
                }
                else
                {
                    _multiEndpointStats.Initialize();
                    CompleteMultiEndpointInitialization();
                }
                return;
            }

            // Explicit destination override (spec: connectionString) wins over both the
            // distro-routed and region-derived endpoints.
            if (_connectionStringOverride != null)
            {
                _statsbeat_ConnectionString = _connectionStringOverride;
                BuildMeterProvider(_statsbeat_ConnectionString);
                ScheduleInitialAttachFlush();
                return;
            }

            if (routeToDistroEndpoint)
            {
                // Distro path: fetch the remote configuration in the background. The
                // MeterProvider is built either from the config-supplied url (success path)
                // or from the legacy region-derived endpoint (control-plane unavailable).
                // The only no-emission case is an explicit remote kill switch
                // (`enabled: false`). The constructor must NOT throw because that would
                // break the customer's exporter pin path.
                var configUrl = StatsbeatConstants.SdkStatsConfigUrl_NonEU;
                var ingestionEndpoint = connectionStringVars.IngestionEndpoint;
                _configInitializationTask = Task.Run(() =>
                    InitializeFromConfigAsync(configUrl, ingestionEndpoint, sdkStatsConfigHttpHandler));
                return;
            }

            // A routing-only host has no configured region. Use the existing non-EU default,
            // without choosing a destination from an individual customer's telemetry.
            _statsbeat_ConnectionString = _isRoutingOnly
                ? StatsbeatConstants.Statsbeat_ConnectionString_NonEU
                : GetStatsbeatConnectionString(connectionStringVars.IngestionEndpoint);
            if (_statsbeat_ConnectionString == null)
            {
                throw new InvalidOperationException("Could not find a matching endpoint to initialize Statsbeat.");
            }

            BuildMeterProvider(_statsbeat_ConnectionString);
            ScheduleInitialAttachFlush();
        }

        internal void ObserveAttach(EndpointRouteBatch batch)
            => _multiEndpointStats?.Observe(batch, GetTimestampTicks());

        internal static long GetTimestampTicks()
            => (long)(Stopwatch.GetTimestamp() * s_timestampToTicks);

        private async Task InitializeMultiEndpointAsync()
        {
            try
            {
                await _multiEndpointStats!.InitializeAsync().ConfigureAwait(false);
                CompleteMultiEndpointInitialization();
            }
            catch (Exception ex)
            {
                _multiEndpointStats!.Dispose();
                AzureMonitorExporterEventSource.Log.StatsbeatFailed(ex);
            }
        }

        private void CompleteMultiEndpointInitialization()
        {
            if (_isDisposed)
            {
                _multiEndpointStats!.Dispose();
                return;
            }

            _statsbeat_ConnectionString = _multiEndpointStats!.DefaultConnectionString;
            if (_multiEndpointStats.HasDestination)
            {
                try
                {
                    BuildMeterProvider(_statsbeat_ConnectionString);
                    ScheduleInitialAttachFlush();
                }
                catch
                {
                    _multiEndpointStats.Dispose();
                    throw;
                }
            }
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
                        connectionString = BuildConnectionStringFromHost(result.Url!, GetSdkStatsInstrumentationKey(ingestionEndpoint));
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

        internal static string BuildConnectionStringFromHost(string host, string instrumentationKey)
        {
            // Build a Breeze-compatible connection string from the config-supplied host.
            // The transmitter appends the standard /v2.1/track path. The distro changes only
            // where SDK statistics are sent, not whose they are, so the envelope keeps the
            // same SDK statistics instrumentation key the legacy endpoint receives.
            var trimmed = host.TrimEnd('/');
            if (!trimmed.StartsWith("http://", StringComparison.OrdinalIgnoreCase)
                && !trimmed.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                trimmed = "https://" + trimmed;
            }
            return "InstrumentationKey=" + instrumentationKey + ";IngestionEndpoint=" + trimmed + "/";
        }

        /// <summary>
        /// Returns the SDK statistics instrumentation key for the customer's region.
        /// The distro collector uses one host for both keys; unknown regions default to non-EU.
        /// </summary>
        internal static string GetSdkStatsInstrumentationKey(string ingestionEndpoint)
            => IsEuRegion(ingestionEndpoint)
                ? StatsbeatConstants.Statsbeat_InstrumentationKey_EU
                : StatsbeatConstants.Statsbeat_InstrumentationKey_NonEU;

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

        private void BuildMeterProvider(string? connectionString)
        {
            // One MeterProvider for both long and short-interval stats. The reader runs at
            // the Network (15 min) cadence. Delta temporality + the Attach throttle keep the
            // long-interval instruments on their native 24 hr cadence. EnableStatsbeat=false
            // avoids a recursive Statsbeat construction inside the transmitter we're about to
            // attach.
            var attachView = _multiEndpointStats != null
                ? new MetricStreamConfiguration { CardinalityLimit = MultiEndpointStatsbeat.CardinalityLimit }
                : null;

            var builder = Sdk.CreateMeterProviderBuilder()
                .AddMeter(StatsbeatConstants.AttachStatsbeatMeterName);

            if (_collectOtherStats && (_multiEndpointStats == null || _multiEndpointStats.DefaultConnectionString != null))
            {
                builder.AddMeter(
                    StatsbeatConstants.FeatureStatsbeatMeterName,
                    StatsbeatConstants.DistroFeatureSdkStatsMeterName,
                    StatsbeatConstants.NetworkSdkStatsMeterName,
                    StatsbeatConstants.DistroNetworkSdkStatsMeterName);
            }

            var meterProvider = builder
                // Another stats owner's reader must not consume this owner's Attach throttle.
                .AddView(instrument => instrument.Meter.Name != StatsbeatConstants.AttachStatsbeatMeterName
                    ? null : ReferenceEquals(instrument, _attachInstrument) ? attachView : MetricStreamConfiguration.Drop)
                .AddReader(_multiEndpointStats?.CreateReader(_networkExportIntervalMilliseconds)
                    ?? new PeriodicExportingMetricReader(
                        AzureMonitorMetricExporter.CreateForInternalTelemetry(CreateExporterOptions(connectionString!)),
                        _networkExportIntervalMilliseconds)
                    { TemporalityPreference = MetricReaderTemporalityPreference.Delta })
                .Build();

            // A full fence, so the disposed flag below cannot be read before this is visible.
            Interlocked.Exchange(ref _statsbeatMeterProvider, meterProvider);

            if (!_isDisposed)
            {
                return;
            }

            // The distro path builds this from a background config fetch, which can land after a
            // short-lived process has already disposed us. Whichever side takes the provider here
            // owns it, so it is disposed once and never orphaned.
            var orphaned = Interlocked.Exchange(ref _statsbeatMeterProvider, null);
            if (orphaned != null)
            {
                DisposeInBackground(orphaned);
            }
        }

        internal static AzureMonitorExporterOptions CreateExporterOptions(string connectionString)
        {
            var exporterOptions = new AzureMonitorExporterOptions
            {
                DisableOfflineStorage = true,
                ConnectionString = connectionString,
                EnableStatsbeat = false,
            };

            // Disposing this meter provider exports once more on the process exit path.
            exporterOptions.Retry.NetworkTimeout = ShutdownPersistence.PersistOnShutdownConfig.InternalTelemetryNetworkTimeout;

            return exporterOptions;
        }

        private static int ResolveIntervalMilliseconds(IPlatform platform, string envVarName, int defaultMilliseconds)
        {
            var value = platform.GetEnvironmentVariable(envVarName);
            // Guard the seconds->milliseconds multiplication against int overflow: a value
            // above int.MaxValue/1000 would wrap to a negative interval and break the reader.
            if (int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var seconds)
                && seconds > 0
                && seconds <= int.MaxValue / 1000)
            {
                return seconds * 1000;
            }

            return defaultMilliseconds;
        }

        private static TimeSpan ResolveInterval(IPlatform platform, string envVarName, TimeSpan defaultInterval)
        {
            var value = platform.GetEnvironmentVariable(envVarName);
            if (int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var seconds) && seconds > 0)
            {
                return TimeSpan.FromSeconds(seconds);
            }

            return defaultInterval;
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
                var wait = Stopwatch.StartNew();
                do
                {
                    await Task.Delay(TimeSpan.FromMinutes(1)).ConfigureAwait(false);
                    if (SdkVersionUtils.IsHydrated)
                        break;
                } while (!SdkVersionUtils.IsHydrated && wait.Elapsed < TimeSpan.FromMinutes(5));

                _statsbeatMeterProvider?.ForceFlush();
            });
        }

        internal static string? GetStatsbeatConnectionString(string ingestionEndpoint)
        {
            // Legacy path: maps the customer's ingestion region to the internal Application
            // Insights resource hosting Statsbeat. Returns null for unknown regions so the
            // caller can throw and leave Statsbeat disabled. (The distro path uses
            // the runtime collector configuration instead of this.)
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

        internal static bool IsEuRegion(string ingestionEndpoint)
        {
            var patternMatch = s_endpoint_pattern.Match(ingestionEndpoint);
            return patternMatch.Success
                && StatsbeatConstants.s_EU_Endpoints.Contains(patternMatch.Groups[1].Value);
        }

        private IEnumerable<Measurement<int>> GetAttachStatsbeat()
            => GetAttachStatsbeat(GetTimestampTicks());

        internal IEnumerable<Measurement<int>> GetAttachStatsbeat(long nowTicks)
        {
            // Emit at most once per AttachEmissionInterval. Delta temporality means
            // skipped intervals don't produce an exported metric point.
            long previousTicks = Volatile.Read(ref _lastAttachEmissionTicks);
            if (previousTicks >= 0
                && nowTicks - previousTicks < _attachEmissionInterval.Ticks)
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
                measurement = CreateAttachMeasurement(_customer_Ikey);
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

        private Measurement<int> CreateAttachMeasurement(string customerIkey)
        {
            if (_resourceProvider == null)
            {
                SetResourceProviderDetails(_platform);
            }

            return new Measurement<int>(1,
                new("rp", _resourceProvider),
                new("rpId", _resourceProviderId),
                new("attach", s_attachMode),
                new("cikey", customerIkey),
                new("runtimeVersion", s_runtimeVersion),
                new("language", "dotnet"),
                new("version", SdkVersionUtils.GetVersion()),
                new("os", _operatingSystem));
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

                // osType takes precedence when IMDS reports a concrete value; when it is
                // null/empty or the literal "Unknown", fall back to the running process OS
                // (already captured in _operatingSystem via the constructor) per spec.
                _operatingSystem = ResolveOperatingSystem(vmMetadata.osType, _operatingSystem);

                return;
            }

            _resourceProvider = "unknown";
            _resourceProviderId = "unknown";
        }

        /// <summary>
        /// Determines the effective "os" dimension. Per the SDKStats spec, the IMDS
        /// <c>azInst_osType</c> takes precedence over the running process OS, except when it
        /// is null/empty or the literal "Unknown" (case-insensitive), in which case the
        /// running process OS (<paramref name="processOperatingSystem"/>) is used.
        /// </summary>
        internal static string ResolveOperatingSystem(string? vmOsType, string processOperatingSystem)
        {
            if (!string.IsNullOrEmpty(vmOsType)
                && !string.Equals(vmOsType, "unknown", StringComparison.OrdinalIgnoreCase))
            {
                return vmOsType!.ToLower(CultureInfo.InvariantCulture);
            }

            return processOperatingSystem;
        }

        public void Dispose()
        {
            _isDisposed = true;

            var meterProvider = Interlocked.Exchange(ref _statsbeatMeterProvider, null);
            if (meterProvider == null)
            {
                _multiEndpointStats?.Dispose();
                return;
            }

            DisposeInBackground(meterProvider);
        }

        private static void DisposeInBackground(MeterProvider meterProvider)
        {
            // Disposing the meter provider exports one last time, which would put an ingestion round
            // trip on the process exit path. Statsbeat is internal telemetry with no offline storage
            // behind it, so losing that final export is preferable to delaying exit for it.
            _ = Task.Run(() =>
            {
                try
                {
                    meterProvider.Dispose();
                }
                catch (Exception)
                {
                    // The process is going away; there is nothing useful to report.
                }
            });
        }
    }
}
