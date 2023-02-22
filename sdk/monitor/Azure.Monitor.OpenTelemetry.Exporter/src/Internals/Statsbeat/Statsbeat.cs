// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.RegularExpressions;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.ConnectionString;
using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal sealed class Statsbeat : IDisposable
    {
        internal const string StatsBeat_ConnectionString_NonEU = "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://NonEU.in.applicationinsights.azure.com/";

        internal const string StatsBeat_ConnectionString_EU = "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://EU.in.applicationinsights.azure.com/";

        private const string AMS_Url = "http://169.254.169.254/metadata/instance/compute?api-version=2017-08-01&format=json";

        internal const int AttachStatsBeatInterval = 86400000;

        private static readonly Meter s_myMeter = new("AttachStatsBeatMeter", "1.0");

        internal string? _statsBeat_ConnectionString;

        private string? _resourceProviderId;

        private string? _resourceProvider;

        private static string? s_runtimeVersion => SdkVersionUtils.GetVersion(typeof(object));

        private static string? s_sdkVersion => SdkVersionUtils.GetVersion(typeof(AzureMonitorTraceExporter));

        private static string s_operatingSystem = GetOS();

        private readonly string? _customer_Ikey;

        internal MeterProvider? _attachStatsBeatMeterProvider;

        internal static Regex s_endpoint_pattern = new("^https?://(?:www\\.)?([^/.-]+)");

        internal static readonly HashSet<string> EU_Endpoints = new()
        {
            "francecentral",
            "francesouth",
            "northeurope",
            "norwayeast",
            "norwaywest",
            "swedencentral",
            "switzerlandnorth",
            "switzerlandwest",
            "uksouth",
            "ukwest",
            "westeurope",
        };

        internal static readonly HashSet<string> Non_EU_Endpoints = new()
        {
            "australiacentral",
            "australiacentral2",
            "australiaeast",
            "australiasoutheast",
            "brazilsouth",
            "brazilsoutheast",
            "canadacentral",
            "canadaeast",
            "centralindia",
            "centralus",
            "chinaeast2",
            "chinaeast3",
            "chinanorth3",
            "eastasia",
            "eastus",
            "eastus2",
            "japaneast",
            "japanwest",
            "jioindiacentral",
            "jioindiawest",
            "koreacentral",
            "koreasouth",
            "northcentralus",
            "qatarcentral",
            "southafricanorth",
            "southcentralus",
            "southeastasia",
            "southindia",
            "uaecentral",
            "uaenorth",
            "westus",
            "westus2",
            "westus3",
        };

        internal Statsbeat(string? connectionString)
        {
            var parsedConnectionString = ConnectionStringParser.GetValues(connectionString);

            _statsBeat_ConnectionString = GetStatsbeatConnectionString(parsedConnectionString.IngestionEndpoint);

            // Initialize only if we are able to determine the correct region to send the data to.
            if (_statsBeat_ConnectionString == null)
            {
                throw new InvalidOperationException("Cannot initialize statsbeat");
            }

            _customer_Ikey = parsedConnectionString.InstrumentationKey;

            s_myMeter.CreateObservableGauge("AttachStatsBeat", () => GetAttachStatsBeat());

            // Configure for attach statsbeat which has collection
            // schedule of 24 hrs == 86400000 milliseconds.
            // TODO: Follow up in spec to confirm the behavior
            // in case if the app exits before 24hrs duration.
            var exporterOptions = new AzureMonitorExporterOptions();
            exporterOptions.DisableOfflineStorage = true;
            exporterOptions.ConnectionString = _statsBeat_ConnectionString;

            _attachStatsBeatMeterProvider = Sdk.CreateMeterProviderBuilder()
            .AddMeter("AttachStatsBeatMeter")
            .AddReader(new PeriodicExportingMetricReader(new AzureMonitorMetricExporter(exporterOptions), AttachStatsBeatInterval)
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

        internal static string? GetStatsbeatConnectionString(string ingestionEndpoint)
        {
            var patternMatch = s_endpoint_pattern.Match(ingestionEndpoint);
            string? statsBeatConnectionString = null;
            if (patternMatch.Success)
            {
                var endpoint = patternMatch.Groups[1].Value;
                if (EU_Endpoints.Contains(endpoint))
                {
                    statsBeatConnectionString = StatsBeat_ConnectionString_EU;
                }
                else if (Non_EU_Endpoints.Contains(endpoint))
                {
                    statsBeatConnectionString = StatsBeat_ConnectionString_NonEU;
                }
            }

            return statsBeatConnectionString;
        }

        private Measurement<int> GetAttachStatsBeat()
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
                AzureMonitorExporterEventSource.Log.WriteWarning("ErrorGettingStatsBeatData", ex);
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
                    var responseString = httpClient.GetStringAsync(AMS_Url);
                    var vmMetadata = JsonSerializer.Deserialize<VmMetadataResponse>(responseString.Result);

                    return vmMetadata;
                }
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.WriteInformational("Failed to get VM metadata details", ex.ToInvariantString());
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
            _attachStatsBeatMeterProvider?.Dispose();
        }
    }
}
