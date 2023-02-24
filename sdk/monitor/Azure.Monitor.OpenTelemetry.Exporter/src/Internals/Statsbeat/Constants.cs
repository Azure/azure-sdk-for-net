// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat
{
    internal class Constants
    {
        internal const string Statsbeat_Ikey_NonEU = "00000000-0000-0000-0000-000000000000";

        internal const string Statsbeat_Ikey_EU = "00000000-0000-0000-0000-000000000000";

        internal static readonly HashSet<string> s_EU_Endpoints = new()
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

        internal static string Statsbeat_ConnectionString_EU => $"InstrumentationKey={Statsbeat_Ikey_EU};IngestionEndpoint=https://EU.in.applicationinsights.azure.com/";

        internal static string Statsbeat_ConnectionString_NonEU => $"InstrumentationKey={Statsbeat_Ikey_NonEU};IngestionEndpoint=https://NonEU.in.applicationinsights.azure.com/";
    }
}
