// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenTelemetry.Exporter.AzureMonitor.Models;

namespace OpenTelemetry.Exporter.AzureMonitor.HttpParsers
{
    /// <summary>
    /// HTTP Dependency parser that attempts to parse dependency as Azure Table call.
    /// </summary>
    internal static class AzureTableHttpParser
    {
        private static readonly string[] AzureTableHostSuffixes =
            {
                ".table.core.windows.net",
                ".table.core.chinacloudapi.cn",
                ".table.core.cloudapi.de",
                ".table.core.usgovcloudapi.net",
            };

        /// <summary>
        /// Tries parsing given dependency telemetry item.
        /// </summary>
        /// <param name="httpDependency">Dependency item to parse. It is expected to be of HTTP type.</param>
        /// <returns><code>true</code> if successfully parsed dependency.</returns>
        internal static bool TryParse(ref RemoteDependencyData httpDependency)
        {
            string name = httpDependency.Name;
            string host = httpDependency.Target;
            string url = httpDependency.Data;

            if (name == null || host == null || url == null)
            {
                return false;
            }

            if (!HttpParsingHelper.EndsWithAny(host, AzureTableHostSuffixes))
            {
                return false;
            }

            httpDependency.Type = RemoteDependencyConstants.AzureTable;

            return true;
        }
    }
}
