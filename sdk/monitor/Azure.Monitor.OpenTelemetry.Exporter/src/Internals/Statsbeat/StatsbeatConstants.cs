// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat
{
    internal static class StatsbeatConstants
    {
        internal const string Statsbeat_ConnectionString_NonEU = "InstrumentationKey=c4a29126-a7cb-47e5-b348-11414998b11e;IngestionEndpoint=https://westus-0.in.applicationinsights.azure.com/;LiveEndpoint=https://westus.livediagnostics.monitor.azure.com/";

        internal const string Statsbeat_ConnectionString_EU = "InstrumentationKey=7dc56bab-3c0c-4e9f-9ebb-d1acadee8d0f;IngestionEndpoint=https://westeurope-5.in.applicationinsights.azure.com/;LiveEndpoint=https://westeurope.livediagnostics.monitor.azure.com/";

        internal const string OneSettingsConfigUrl = "https://settings.sdk.monitor.azure.com/AzMonSDKDynamicConfiguration?namespaces=dotnet";
        internal const string OneSettingsFeatureSdkStats = "FEATURE_SDK_STATS";
        internal const string OneSettingsDefaultStatsConnectionString = "DEFAULT_STATS_CONNECTION_STRING";
        internal const string OneSettingsSupportedDataBoundaries = "SUPPORTED_DATA_BOUNDARIES";
        internal const string SdkStatsConfigUrl_NonEU = OneSettingsConfigUrl;
        internal const string SdkStatsConfigUrl_EU = OneSettingsConfigUrl;
        internal const int SdkStatsConfigVersion = 1;

        /// <summary>
        /// Process-wide <see cref="System.AppContext"/> switch name. When set to <c>true</c>,
        /// every <see cref="AzureMonitorStatsbeat"/> instance fetches SDK statistics
        /// routing from OneSettings at startup. Missing or invalid configuration falls
        /// back to the existing region-derived Breeze endpoint; only an explicit
        /// <c>FEATURE_SDK_STATS</c> disable turns SDK statistics off.
        /// </summary>
        /// <remarks>
        /// Intended to be set by the Microsoft OpenTelemetry distro before any
        /// <see cref="AzureMonitorMetricExporter"/> is constructed in the process. The switch
        /// is sticky for the process lifetime and applies to all <see cref="AzureMonitorStatsbeat"/>
        /// instances created after it is set, including the customer's own Azure Monitor
        /// exporter when running under the distro.
        /// </remarks>
        internal const string RouteSdkStatsToDistroEndpointSwitchName = "Azure.Monitor.OpenTelemetry.Exporter.RouteSdkStatsToDistroEndpoint";

        internal static readonly HashSet<string> s_EU_Endpoints = new()
        {
            "francecentral",
            "francesouth",
            "germanywestcentral",
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

        internal static readonly HashSet<string> s_non_EU_Endpoints = new()
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

        /// <summary>
        /// <see href="https://learn.microsoft.com/azure/virtual-machines/instance-metadata-service"/>.
        /// </summary>
        internal const string AMS_Url = "http://169.254.169.254/metadata/instance/compute?api-version=2017-08-01&format=json";

        /// <summary>
        /// 15 min == 900000 milliseconds. Cadence of the shared statsbeat reader.
        /// </summary>
        internal const int NetworkStatsbeatInterval = 900000;

        /// <summary>
        /// Min time between Attach observable gauge emissions (long-interval cadence
        /// while sharing the 15-min reader).
        /// </summary>
        internal static readonly TimeSpan AttachEmissionInterval = TimeSpan.FromHours(24);

        internal const string AttachStatsbeatMeterName = "AttachStatsbeatMeter";
        internal const string AttachStatsbeatMetricName = "Attach";

        internal const string FeatureStatsbeatMeterName = "FeatureStatsbeatMeter";
        internal const string FeatureStatsbeatMetricName = "Feature";

        /// <summary>
        /// Meter name for Network SDKStats (short interval - 15 min). Tracks request success,
        /// failure, retry, throttle, exception counts and request duration for outbound
        /// transmissions to the configured ingestion endpoint.
        /// </summary>
        internal const string NetworkSdkStatsMeterName = "NetworkSdkStatsMeter";

        /// <summary>
        /// Value of the <c>endpoint</c> dimension on Network SDKStats metrics published by the
        /// Azure Monitor / Application Insights exporter (Breeze ingestion).
        /// </summary>
        internal const string NetworkSdkStatsEndpointBreeze = "breeze";

        /// <summary>
        /// Meter name used by the Microsoft OpenTelemetry distro to publish distro-owned Feature
        /// SDKStats. The distro owns a bit map separate from the classic Application Insights
        /// <see cref="FeatureStatsbeatMeterName"/> producer to avoid bit-space collisions; the
        /// Statsbeat <c>MeterProvider</c> subscribes to both so measurements from either producer
        /// flow through to the same Statsbeat ingestion resource.
        /// </summary>
        internal const string DistroFeatureSdkStatsMeterName = "MicrosoftOpenTelemetryFeatureSdkStatsMeter";

        /// <summary>
        /// Meter name used by the Microsoft OpenTelemetry distro to publish distro-owned Network
        /// SDKStats. When the distro runs with a non-Azure-Monitor exporter (e.g. the Agent365
        /// exporter), the distro owns the Network signal and records request success/failure,
        /// retry, throttle, duration, and exception counters on this meter. The Statsbeat
        /// <c>MeterProvider</c> subscribes to it so those measurements flow through the same
        /// Statsbeat ingestion resource as the Attach and Feature signals.
        /// </summary>
        internal const string DistroNetworkSdkStatsMeterName = "MicrosoftOpenTelemetryNetworkSdkStatsMeter";
    }
}
