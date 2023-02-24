// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.RegularExpressions;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat
{
    internal sealed class AzureMonitorStatsbeat : IDisposable
    {
        private static readonly Meter s_myMeter = new("AttachStatsbeatMeter", "1.0");

        internal string? _statsbeat_ConnectionString;

        private string? _resourceProviderId;

        private string? _resourceProvider;

        private static string? s_runtimeVersion => SdkVersionUtils.GetVersion(typeof(object));

        private static string? s_sdkVersion => SdkVersionUtils.GetVersion(typeof(AzureMonitorTraceExporter));

        private static string s_operatingSystem = GetOS();

        private readonly string? _customer_Ikey;

        internal MeterProvider? _attachStatsbeatMeterProvider;

        internal static Regex s_endpoint_pattern => new("^https?://(?:www\\.)?([^/.-]+)");

        internal AzureMonitorStatsbeat(ConnectionVars connectionStringVars)
        {
            _statsbeat_ConnectionString = GetStatsbeatConnectionString(connectionStringVars?.IngestionEndpoint);

            // Initialize only if we are able to determine the correct region to send the data to.
            if (_statsbeat_ConnectionString == null)
            {
                throw new InvalidOperationException("Cannot initialize statsbeat");
            }

            _customer_Ikey = connectionStringVars?.InstrumentationKey;

            s_myMeter.CreateObservableGauge("AttachStatsbeat", () => GetAttachStatsbeat());

            // Configure for attach statsbeat which has collection
            // schedule of 24 hrs == 86400000 milliseconds.
            // TODO: Follow up in spec to confirm the behavior
            // in case if the app exits before 24hrs duration.
            var exporterOptions = new AzureMonitorExporterOptions();
            exporterOptions.DisableOfflineStorage = true;
            exporterOptions.ConnectionString = _statsbeat_ConnectionString;

            _attachStatsbeatMeterProvider = Sdk.CreateMeterProviderBuilder()
            .AddMeter("AttachStatsbeatMeter")
            .AddReader(new PeriodicExportingMetricReader(new AzureMonitorMetricExporter(exporterOptions), Constants.AttachStatsbeatInterval)
            { TemporalityPreference = MetricReaderTemporalityPreference.Delta })
            .Build();
        }

        private static string GetOS()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return "windows";
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return "linux";
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return "osx";
            }

            return "unknown";
        }

        internal static string? GetStatsbeatConnectionString(string? ingestionEndpoint) // TODO: Rewrite
        {
            var patternMatch = s_endpoint_pattern.Match(ingestionEndpoint);
            string? statsbeatConnectionString = null;
            if (patternMatch.Success)
            {
                var endpoint = patternMatch.Groups[1].Value;
                if (Constants.s_EU_Endpoints.Contains(endpoint))
                {
                    statsbeatConnectionString = Constants.Statsbeat_ConnectionString_EU;
                }
                else if (Constants.s_non_EU_Endpoints.Contains(endpoint))
                {
                    statsbeatConnectionString = Constants.Statsbeat_ConnectionString_NonEU;
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
                    SetResourceProviderDetails();
                }

                return
                    new Measurement<int>(1,
                        new("rp", _resourceProvider),
                        new("rpId", _resourceProviderId),
                        new("attach", "sdk"),
                        new("cikey", _customer_Ikey),
                        new("runtimeVersion", s_runtimeVersion),
                        new("language", "dotnet"),
                        new("version", s_sdkVersion),
                        new("os", s_operatingSystem));
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.WriteWarning("ErrorGettingStatsbeatData", ex);
                return new Measurement<int>();
            }
        }

        private static VmMetadataResponse? GetVmMetadataResponse()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Metadata", "True");
                    var responseString = httpClient.GetStringAsync(Constants.AMS_Url);
                    var vmMetadata = JsonSerializer.Deserialize<VmMetadataResponse>(responseString.Result);

                    return vmMetadata;
                }
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.WriteInformational("Failed to get VM metadata details", ex);
                return null;
            }
        }

        private void SetResourceProviderDetails()
        {
            var appSvcWebsiteName = Environment.GetEnvironmentVariable("WEBSITE_SITE_NAME");
            if (appSvcWebsiteName != null)
            {
                _resourceProvider = "appsvc";
                _resourceProviderId = appSvcWebsiteName;
                var appSvcWebsiteHostName = Environment.GetEnvironmentVariable("WEBSITE_HOME_STAMPNAME");
                if (!string.IsNullOrEmpty(appSvcWebsiteHostName))
                {
                    _resourceProviderId += "/" + appSvcWebsiteHostName;
                }

                return;
            }

            var functionsWorkerRuntime = Environment.GetEnvironmentVariable("FUNCTIONS_WORKER_RUNTIME");
            if (functionsWorkerRuntime != null)
            {
                _resourceProvider = "functions";
                _resourceProviderId = Environment.GetEnvironmentVariable("WEBSITE_HOSTNAME");

                return;
            }

            var vmMetadata = GetVmMetadataResponse();

            if (vmMetadata != null)
            {
                _resourceProvider = "vm";
                _resourceProviderId = _resourceProviderId = vmMetadata.vmId + "/" + vmMetadata.subscriptionId;

                // osType takes precedence.
                s_operatingSystem = vmMetadata.osType.ToLower(CultureInfo.InvariantCulture);

                return;
            }

            _resourceProvider = "unknown";
            _resourceProviderId = "unknown";
        }

        public void Dispose()
        {
            _attachStatsbeatMeterProvider?.Dispose();
        }
    }
}
