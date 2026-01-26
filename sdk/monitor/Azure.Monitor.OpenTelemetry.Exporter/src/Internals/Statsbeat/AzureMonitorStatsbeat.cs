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

        internal MeterProvider? _attachStatsbeatMeterProvider;
        internal MeterProvider? _featureStatsbeatMeterProvider;

        internal static Regex s_endpoint_pattern => new("^https?://(?:www\\.)?([^/.-]+)");

        internal AzureMonitorStatsbeat(ConnectionVars connectionStringVars, IPlatform platform)
        {
            _platform = platform;

            _operatingSystem = platform.GetOSPlatformName();

            _statsbeat_ConnectionString = GetStatsbeatConnectionString(connectionStringVars.IngestionEndpoint);

            // Initialize only if we are able to determine the correct region to send the data to.
            if (_statsbeat_ConnectionString == null)
            {
                throw new InvalidOperationException("Could not find a matching endpoint to initialize Statsbeat.");
            }

            _customer_Ikey = connectionStringVars.InstrumentationKey;

            s_myMeter.CreateObservableGauge(StatsbeatConstants.AttachStatsbeatMetricName, () => GetAttachStatsbeat());

            // Configure for attach statsbeat which has collection
            // schedule of 24 hrs == 86400000 milliseconds.
            var exporterOptions = new AzureMonitorExporterOptions
            {
                DisableOfflineStorage = true,
                ConnectionString = _statsbeat_ConnectionString,
                EnableStatsbeat = false, // to avoid recursive Statsbeat.
            };

            _attachStatsbeatMeterProvider = Sdk.CreateMeterProviderBuilder()
                .AddMeter(StatsbeatConstants.AttachStatsbeatMeterName)
                .AddReader(new PeriodicExportingMetricReader(new AzureMonitorMetricExporter(exporterOptions), StatsbeatConstants.AttachStatsbeatInterval)
                { TemporalityPreference = MetricReaderTemporalityPreference.Delta })
                .Build();

            _featureStatsbeatMeterProvider = Sdk.CreateMeterProviderBuilder()
                .AddMeter(StatsbeatConstants.FeatureStatsbeatMeterName)
                .AddReader(new PeriodicExportingMetricReader(new AzureMonitorMetricExporter(exporterOptions), StatsbeatConstants.FeatureStatsbeatInterval)
                { TemporalityPreference = MetricReaderTemporalityPreference.Delta })
                .Build();

            // Wait 1 minute before sending the startup SDK stats attach signal to ensure we don't collect data from very short-lived apps that could spam the stats.
            // If the version information is not yet available, wait up to five minutes - it really should be done in one minute or less
            // (whenever the first Export call occurs, and otel does metrics at least once a minute).
            // After the first attach metric emission, the AttachStatsbeatInterval above (24 hours by default) takes over sending metrics.
            _ = Task.Run(async () =>
            {
                DateTime giveUpTime = DateTime.Now.AddMinutes(5);
                do
                {
                    await Task.Delay(TimeSpan.FromMinutes(1)).ConfigureAwait(false);
                    if (SdkVersionUtils.IsHydrated)
                        break;
                } while (!SdkVersionUtils.IsHydrated && giveUpTime > DateTime.Now);

                _attachStatsbeatMeterProvider?.ForceFlush();
            });
        }

        internal static string? GetStatsbeatConnectionString(string ingestionEndpoint)
        {
            var patternMatch = s_endpoint_pattern.Match(ingestionEndpoint);
            string? statsbeatConnectionString = null;
            if (patternMatch.Success)
            {
                var endpoint = patternMatch.Groups[1].Value;
                if (StatsbeatConstants.s_EU_Endpoints.Contains(endpoint))
                {
                    statsbeatConnectionString = StatsbeatConstants.Statsbeat_ConnectionString_EU;
                }
                else if (StatsbeatConstants.s_non_EU_Endpoints.Contains(endpoint))
                {
                    statsbeatConnectionString = StatsbeatConstants.Statsbeat_ConnectionString_NonEU;
                }
            }

            return statsbeatConnectionString;
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
            _attachStatsbeatMeterProvider?.Dispose();
            _featureStatsbeatMeterProvider?.Dispose();
        }
    }
}
