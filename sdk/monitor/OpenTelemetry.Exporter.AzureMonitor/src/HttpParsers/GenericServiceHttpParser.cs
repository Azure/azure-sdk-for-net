// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using OpenTelemetry.Exporter.AzureMonitor.Models;

namespace OpenTelemetry.Exporter.AzureMonitor.HttpParsers
{
    /// <summary>
    /// HTTP Dependency parser that attempts to parse dependency as generic WCF or Web Service call.
    /// </summary>
    internal static class GenericServiceHttpParser
    {
        /// <summary>
        /// Tries parsing given dependency telemetry item.
        /// </summary>
        /// <param name="httpDependency">Dependency item to parse. It is expected to be of HTTP type.</param>
        /// <returns><code>true</code> if successfully parsed dependency.</returns>
        internal static bool TryParse(ref RemoteDependencyData httpDependency)
        {
            if (httpDependency.Data.EndsWith(".svc", StringComparison.OrdinalIgnoreCase))
            {
                httpDependency.Type = RemoteDependencyConstants.WcfService;
                return true;
            }

            if (httpDependency.Data.EndsWith(".asmx", StringComparison.OrdinalIgnoreCase))
            {
                httpDependency.Type = RemoteDependencyConstants.WebService;
                return true;
            }

            if (httpDependency.Data.IndexOf(".svc/", StringComparison.OrdinalIgnoreCase) != -1)
            {
                httpDependency.Type = RemoteDependencyConstants.WcfService;
                return true;
            }

            if (httpDependency.Data.IndexOf(".asmx/", StringComparison.OrdinalIgnoreCase) != -1)
            {
                httpDependency.Type = RemoteDependencyConstants.WebService;
                return true;
            }

            return false;
        }
    }
}
