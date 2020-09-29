// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenTelemetry.Exporter.AzureMonitor.Models;

namespace OpenTelemetry.Exporter.AzureMonitor.HttpParsers
{
    /// <summary>
    /// HTTP Dependency parser that attempts to parse dependency as Azure Service Bus call.
    /// </summary>
    internal static class AzureServiceBusHttpParser
    {
        private static readonly string[] AzureServiceBusHostSuffixes =
            {
                ".servicebus.windows.net",
                ".servicebus.chinacloudapi.cn",
                ".servicebus.cloudapi.de",
                ".servicebus.usgovcloudapi.net",
            };

        /// <summary>
        /// Tries parsing given dependency telemetry item.
        /// </summary>
        /// <param name="httpDependency">Dependency item to parse. It is expected to be of HTTP type.</param>
        /// <returns><code>true</code> if successfully parsed dependency.</returns>
        internal static bool TryParse(ref RemoteDependencyData httpDependency)
        {
            string host = httpDependency.Target;

            if (host == null)
            {
                return false;
            }

            if (!HttpParsingHelper.EndsWithAny(host, AzureServiceBusHostSuffixes))
            {
                return false;
            }

            httpDependency.Type = RemoteDependencyConstants.AzureServiceBus;

            return true;
        }
    }
}
