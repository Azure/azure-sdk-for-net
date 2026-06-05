// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat
{
    internal static class StatsbeatConstants
    {
        internal const string Statsbeat_ConnectionString_NonEU = "InstrumentationKey=c4a29126-a7cb-47e5-b348-11414998b11e;IngestionEndpoint=https://westus-0.in.applicationinsights.azure.com/;LiveEndpoint=https://westus.livediagnostics.monitor.azure.com/";

        internal const string Statsbeat_ConnectionString_EU = "InstrumentationKey=7dc56bab-3c0c-4e9f-9ebb-d1acadee8d0f;IngestionEndpoint=https://westeurope-5.in.applicationinsights.azure.com/;LiveEndpoint=https://westeurope.livediagnostics.monitor.azure.com/";

        /// <summary>
        /// Distro-owned SDK statistics ingestion endpoint, non-EU. Used when the
        /// <see cref="RouteSdkStatsToDistroEndpointSwitchName"/> AppContext switch is enabled
        /// (typically by the Microsoft OpenTelemetry distro at startup) and the customer's
        /// connection string maps to a non-EU region (or is unknown).
        /// </summary>
        /// <remarks>
        /// The new endpoint accepts the same Breeze envelope format as the existing AI resource
        /// and does not require authentication; the placeholder instrumentation key in the
        /// connection string satisfies the connection-string parser but is ignored server-side.
        /// </remarks>
        internal const string SdkStats_ConnectionString_Distro_NonEU = "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://stats.monitor.azure.com/";

        /// <summary>
        /// Distro-owned SDK statistics ingestion endpoint, EU data boundary. Used when the
        /// <see cref="RouteSdkStatsToDistroEndpointSwitchName"/> AppContext switch is enabled
        /// and the customer's connection string maps to an EU region.
        /// </summary>
        internal const string SdkStats_ConnectionString_Distro_EU = "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://eu.stats.monitor.azure.com/";

        /// <summary>
        /// Process-wide <see cref="System.AppContext"/> switch name. When set to <c>true</c>,
        /// every <see cref="AzureMonitorStatsbeat"/> instance routes its SDK statistics to
        /// the distro-owned ingestion endpoints
        /// (<see cref="SdkStats_ConnectionString_Distro_NonEU"/> /
        /// <see cref="SdkStats_ConnectionString_Distro_EU"/>) instead of the existing
        /// Application Insights internal resources.
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
        /// 24 hrs == 86400000 milliseconds.
        /// </summary>
        internal const int GeneralStatsbeatInterval = 86400000;

        internal const string AttachStatsbeatMeterName = "AttachStatsbeatMeter";
        internal const string AttachStatsbeatMetricName = "Attach";

        internal const string FeatureStatsbeatMeterName = "FeatureStatsbeatMeter";
        internal const string FeatureStatsbeatMetricName = "Feature";

        /// <summary>
        /// Meter name used by the Microsoft OpenTelemetry distro to publish distro-owned Feature
        /// SDKStats. The distro owns a bit map separate from the classic Application Insights
        /// <see cref="FeatureStatsbeatMeterName"/> producer to avoid bit-space collisions; the
        /// Statsbeat <c>MeterProvider</c> subscribes to both so measurements from either producer
        /// flow through to the same Statsbeat ingestion resource.
        /// </summary>
        internal const string DistroFeatureSdkStatsMeterName = "MicrosoftOpenTelemetryFeatureSdkStatsMeter";
    }
}
