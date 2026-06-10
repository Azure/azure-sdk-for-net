// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
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

        internal static Regex s_endpoint_pattern => new("^https?://(?:www\\.)?([^/.-]+)");

        internal AzureMonitorStatsbeat(ConnectionVars connectionStringVars, IPlatform platform)
        {
            _platform = platform;

            _operatingSystem = platform.GetOSPlatformName();

            _customer_Ikey = connectionStringVars.InstrumentationKey;

            // The Attach gauge is created up-front for both code paths so that any
            // background MeterProvider that comes online later (distro path) immediately
            // picks it up.
            s_myMeter.CreateObservableGauge(StatsbeatConstants.AttachStatsbeatMetricName, () => GetAttachStatsbeat());

            var routeToDistroEndpoint =
                AppContext.TryGetSwitch(StatsbeatConstants.RouteSdkStatsToDistroEndpointSwitchName, out var enabled)
                && enabled;

            if (routeToDistroEndpoint)
            {
                // Distro path: fetch the remote configuration in the background. The
                // MeterProvider is only built if the config responds with enabled=true and
                // a valid url. On any failure, SDK statistics stay disabled for the
                // process — the constructor must NOT throw because that would break the
                // customer's exporter pin path.
                var configUrl = GetSdkStatsConfigUrl(connectionStringVars.IngestionEndpoint);
                _ = Task.Run(() => InitializeFromConfigAsync(configUrl));
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

        private async Task InitializeFromConfigAsync(string configUrl)
        {
            try
            {
                var config = await SdkStatsConfigFetcher.FetchAsync(configUrl).ConfigureAwait(false);
                if (config == null || string.IsNullOrEmpty(config.url))
                {
                    // FetchAsync has already logged the reason; stay disabled.
                    return;
                }

                // Build a Breeze-compatible connection string from the config-supplied
                // host. The transmitter appends the standard /v2.1/track path; the
                // placeholder iKey is required by ConnectionStringParser but is ignored
                // server-side by this endpoint family.
                var host = config.url!.TrimEnd('/');
                if (!host.StartsWith("http://", StringComparison.OrdinalIgnoreCase)
                    && !host.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                {
                    host = "https://" + host;
                }
                _statsbeat_ConnectionString =
                    "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=" + host + "/";

                BuildMeterProvider(_statsbeat_ConnectionString);
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

        private void BuildMeterProvider(string connectionString)
        {
            // EnableStatsbeat=false avoids a recursive Statsbeat construction inside the
            // transmitter we're about to attach.
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
                .AddReader(new PeriodicExportingMetricReader(new AzureMonitorMetricExporter(exporterOptions), StatsbeatConstants.GeneralStatsbeatInterval)
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
            // attach metric emission, the AttachStatsbeatInterval above (24 hours by
            // default) takes over sending metrics.
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

        private Measurement<int> GetAttachStatsbeat()
        {
            try
            {
                if (_resourceProvider == null)
                {
                    SetResourceProviderDetails(_platform);
                }

                return
                    new Measurement<int>(1,
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
                return new Measurement<int>();
            }
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
