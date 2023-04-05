// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat
{
    internal sealed class AzureMonitorStatsbeat : IDisposable
    {
        private static readonly Meter s_myMeter = new(StatsbeatConstants.AttachStatsbeatMeterName, "1.0");

        internal string? _statsbeat_ConnectionString;

        private static string? s_runtimeVersion => SdkVersionUtils.GetVersion(typeof(object));

        private static string? s_sdkVersion => SdkVersionUtils.GetVersion(typeof(AzureMonitorTraceExporter));

        private readonly string? _customer_Ikey;

        private readonly ResourceProviderDetails _resourceProviderDetails;

        internal MeterProvider? _attachStatsbeatMeterProvider;

        internal static Regex s_endpoint_pattern => new("^https?://(?:www\\.)?([^/.-]+)");

        internal AzureMonitorStatsbeat(ConnectionVars connectionStringVars, IPlatform platform)
        {
            _statsbeat_ConnectionString = GetStatsbeatConnectionString(connectionStringVars?.IngestionEndpoint);

            // Initialize only if we are able to determine the correct region to send the data to.
            if (_statsbeat_ConnectionString == null)
            {
                throw new InvalidOperationException("Cannot initialize statsbeat");
            }

            _customer_Ikey = connectionStringVars?.InstrumentationKey;

            _resourceProviderDetails = GetResourceProviderDetails(platform);

            s_myMeter.CreateObservableGauge(StatsbeatConstants.AttachStatsbeatMetricName, () => GetAttachStatsbeat());

            // Configure for attach statsbeat which has collection
            // schedule of 24 hrs == 86400000 milliseconds.
            // TODO: Follow up in spec to confirm the behavior
            // in case if the app exits before 24hrs duration.
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
        }

        internal static string? GetStatsbeatConnectionString(string? ingestionEndpoint)
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
            return new Measurement<int>(1,
                        new("rp", _resourceProviderDetails.ResourceProvider),
                        new("rpId", _resourceProviderDetails.ResourceProviderId),
                        new("attach", "sdk"),
                        new("cikey", _customer_Ikey),
                        new("runtimeVersion", s_runtimeVersion),
                        new("language", "dotnet"),
                        new("version", s_sdkVersion),
                        new("os", _resourceProviderDetails.OperatingSystem));
        }

        private static VmMetadataResponse? GetVmMetadataResponse()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Metadata", "True");
                    var responseString = httpClient.GetStringAsync(StatsbeatConstants.AMS_Url);
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

        internal static ResourceProviderDetails GetResourceProviderDetails(IPlatform platform)
        {
            try
            {
                var appSvcWebsiteName = platform.GetEnvironmentVariable("WEBSITE_SITE_NAME");
                if (appSvcWebsiteName != null)
                {
                    var appSvcWebsiteHostName = platform.GetEnvironmentVariable("WEBSITE_HOME_STAMPNAME");

                    return new ResourceProviderDetails
                    {
                        ResourceProvider = "appsvc",
                        ResourceProviderId = string.IsNullOrEmpty(appSvcWebsiteHostName)
                                                ? appSvcWebsiteName
                                                : appSvcWebsiteName + "/" + appSvcWebsiteHostName,
                        OperatingSystem = platform.GetOSPlatformName(),
                    };
                }

                var functionsWorkerRuntime = platform.GetEnvironmentVariable("FUNCTIONS_WORKER_RUNTIME");
                if (functionsWorkerRuntime != null)
                {
                    return new ResourceProviderDetails
                    {
                        ResourceProvider = "functions",
                        ResourceProviderId = platform.GetEnvironmentVariable("WEBSITE_HOSTNAME"),
                        OperatingSystem = platform.GetOSPlatformName(),
                    };
                }

                var vmMetadata = GetVmMetadataResponse();
                if (vmMetadata != null)
                {
                    return new ResourceProviderDetails
                    {
                        ResourceProvider = "vm",
                        ResourceProviderId = vmMetadata.vmId + "/" + vmMetadata.subscriptionId,
                        OperatingSystem = vmMetadata.osType?.ToLower(CultureInfo.InvariantCulture),
                    };
                }
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.WriteWarning("ErrorGettingStatsbeatData", ex);
            }

            return new ResourceProviderDetails
            {
                ResourceProvider = "unknown",
                ResourceProviderId = "unknown",
                OperatingSystem = platform.GetOSPlatformName(),
            };
        }

        public void Dispose()
        {
            _attachStatsbeatMeterProvider?.Dispose();
        }

        internal struct ResourceProviderDetails
        {
            public string? ResourceProvider;

            public string? ResourceProviderId;

            public string? OperatingSystem;
        }
    }
}
