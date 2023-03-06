// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat
{
    internal static class StatsbeatConstants
    {
        internal const string Statsbeat_ConnectionString_NonEU = "InstrumentationKey=c4a29126-a7cb-47e5-b348-11414998b11e;IngestionEndpoint=https://westus-0.in.applicationinsights.azure.com/;LiveEndpoint=https://westus.livediagnostics.monitor.azure.com/";

        internal const string Statsbeat_ConnectionString_EU = "InstrumentationKey=7dc56bab-3c0c-4e9f-9ebb-d1acadee8d0f;IngestionEndpoint=https://westeurope-5.in.applicationinsights.azure.com/;LiveEndpoint=https://westeurope.livediagnostics.monitor.azure.com/";

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
        internal const int AttachStatsbeatInterval = 86400000;
    }
}
