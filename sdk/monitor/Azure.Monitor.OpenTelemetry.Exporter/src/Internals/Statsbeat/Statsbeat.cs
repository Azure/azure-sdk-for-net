// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable // TODO: remove and fix errors

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
    internal static class Statsbeat
    {
        internal const string StatsBeat_ConnectionString_NonEU = "<Non-EU-ConnectionString>";

        internal const string StatsBeat_ConnectionString_EU = "EU-ConnectionString";

        private const string AMS_Url = "http://169.254.169.254/metadata/instance/compute?api-version=2017-08-01&format=json";

        internal const int AttachStatsBeatInterval = 86400000;

        private static readonly Meter s_myMeter = new("AttachStatsBeatMeter", "1.0");

        private static bool s_isEnabled = true;

        internal static string s_statsBeat_ConnectionString;

        private static string s_resourceProviderId;

        private static string s_resourceProvider;

        private static string s_runtimeVersion => SdkVersionUtils.GetVersion(typeof(object));

        private static string s_sdkVersion => SdkVersionUtils.GetVersion(typeof(AzureMonitorTraceExporter));

        private static string s_operatingSystem = GetOS();

        private static string s_customer_Ikey;

        internal static MeterProvider s_attachStatsBeatMeterProvider;

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

        internal static void InitializeAttachStatsbeat(string connectionString)
        {
            // check whether it is disabled or already initialized.
            if (s_isEnabled && s_attachStatsBeatMeterProvider == null)
            {
                if (s_statsBeat_ConnectionString == null)
                {
                    var parsedConectionString = ConnectionStringParser.GetValues(connectionString);
                    SetCustomerIkey(parsedConectionString.InstrumentationKey);
                    SetStatsbeatConnectionString(parsedConectionString.IngestionEndpoint);
                }

                if (!s_isEnabled)
                {
                    // TODO: log
                    return;
                }

                s_myMeter.CreateObservableGauge("AttachStatsBeat", () => GetAttachStatsBeat());

                // Configure for attach statsbeat which has collection
                // schedule of 24 hrs == 86400000 milliseconds.
                // TODO: Follow up in spec to confirm the behavior
                // in case if the app exits before 24hrs duration.
                var exporterOptions = new AzureMonitorExporterOptions();
                exporterOptions.DisableOfflineStorage = true;
                exporterOptions.ConnectionString = s_statsBeat_ConnectionString;

                s_attachStatsBeatMeterProvider = Sdk.CreateMeterProviderBuilder()
                .AddMeter("AttachStatsBeatMeter")
                .AddReader(new PeriodicExportingMetricReader(new AzureMonitorMetricExporter(exporterOptions), AttachStatsBeatInterval)
                { TemporalityPreference = MetricReaderTemporalityPreference.Delta })
                .Build();
            }
        }

        internal static void SetCustomerIkey(string instrumentationKey)
        {
            s_customer_Ikey = instrumentationKey;
        }

        internal static void SetStatsbeatConnectionString(string ingestionEndpoint)
        {
            var patternMatch = s_endpoint_pattern.Match(ingestionEndpoint);
            if (patternMatch.Success)
            {
                var endpoint = patternMatch.Groups[1].Value;
                if (EU_Endpoints.Contains(endpoint))
                {
                    s_statsBeat_ConnectionString = StatsBeat_ConnectionString_EU;
                }
                else if (Non_EU_Endpoints.Contains(endpoint))
                {
                    s_statsBeat_ConnectionString = StatsBeat_ConnectionString_NonEU;
                }
                else
                {
                    // disable statsbeat
                    s_isEnabled = false;
                }
            }
        }

        private static Measurement<int> GetAttachStatsBeat()
        {
            if (s_resourceProvider == null)
            {
                SetResourceProviderDetails();
            }

            // TODO: Add os to the list
            return
                new Measurement<int>(1,
                    new("rp", s_resourceProvider),
                    new("rpId", s_resourceProviderId),
                    new("attach", "sdk"),
                    new("cikey", s_customer_Ikey),
                    new("runtimeVersion", s_runtimeVersion),
                    new("language", "dotnet"),
                    new("version", s_sdkVersion),
                    new("os", s_operatingSystem));
        }

        private static VmMetadataResponse GetVmMetadataResponse()
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
                AzureMonitorExporterEventSource.Log.WriteInformational("Failed to get VM metadata details", ex);
                return null;
            }
        }

        private static void SetResourceProviderDetails()
        {
            var appSvcWebsiteName = Environment.GetEnvironmentVariable("WEBSITE_SITE_NAME");
            if (appSvcWebsiteName != null)
            {
                s_resourceProvider = "appsvc";
                s_resourceProviderId = appSvcWebsiteName;
                var appSvcWebsiteHostName = Environment.GetEnvironmentVariable("WEBSITE_HOME_STAMPNAME");
                if (!string.IsNullOrEmpty(appSvcWebsiteHostName))
                {
                    s_resourceProviderId += "/" + appSvcWebsiteHostName;
                }

                return;
            }

            var functionsWorkerRuntime = Environment.GetEnvironmentVariable("FUNCTIONS_WORKER_RUNTIME");
            if (functionsWorkerRuntime != null)
            {
                s_resourceProvider = "functions";
                s_resourceProviderId = Environment.GetEnvironmentVariable("WEBSITE_HOSTNAME");

                return;
            }

            var vmMetadata = GetVmMetadataResponse();

            if (vmMetadata != null)
            {
                s_resourceProvider = "vm";
                s_resourceProviderId = s_resourceProviderId = vmMetadata.vmId + "/" + vmMetadata.subscriptionId;

                // osType takes precedence.
                s_operatingSystem = vmMetadata.osType.ToLower(CultureInfo.InvariantCulture);

                return;
            }

            s_resourceProvider = "unknown";
            s_resourceProviderId = "unknown";
        }
    }
}
