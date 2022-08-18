﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Metrics;
using System.Net.Http;
using System.Text.Json;
using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class Statsbeat
    {
        private static readonly Meter s_myMeter = new("AttachStatsBeatMeter", "1.0");

        private const string StatsBeat_ConnectionString = "<StatsBeat_ConnectionString>";

        private const string AMS_Url = "http://169.254.169.254/metadata/instance/compute?api-version=2017-08-01&format=json";

        internal const int AttachStatsBeatInterval = 86400000;

        private static string s_resourceProviderId;

        private static string s_resourceProvider;

        private static string s_runtimeVersion => SdkVersionUtils.GetVersion(typeof(object));

        private static string s_sdkVersion => SdkVersionUtils.GetVersion(typeof(AzureMonitorTraceExporter));

        static Statsbeat()
        {
            s_myMeter.CreateObservableGauge("AttachStatsBeat", () => GetAttachStatsBeat());

            // Configure for attach statsbeat which has collection
            // schedule of 24 hrs == 86400000 milliseconds.
            // TODO: Follow up in spec to confirm the behavior
            // in case if the app exits before 24hrs duration.
            var exporterOptions = new AzureMonitorExporterOptions();
            exporterOptions.DisableOfflineStorage = true;
            exporterOptions.ConnectionString = StatsBeat_ConnectionString;

            Sdk.CreateMeterProviderBuilder()
            .AddMeter("AttachStatsBeatMeter")
            .AddReader(new PeriodicExportingMetricReader(new AzureMonitorMetricExporter(exporterOptions), AttachStatsBeatInterval)
            { TemporalityPreference = MetricReaderTemporalityPreference.Delta })
            .Build();
        }

        internal static string Customer_Ikey { get; set; }

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
                    new("cikey", Customer_Ikey),
                    new("runtimeVersion", s_runtimeVersion),
                    new("language", "dotnet"),
                    new("version", s_sdkVersion));
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
                AzureMonitorExporterEventSource.Log.WriteWarning("Failed to get VM metadata details", ex);
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

                return;
            }

            s_resourceProvider = "unknown";
            s_resourceProviderId = "unknown";
        }
    }
}
