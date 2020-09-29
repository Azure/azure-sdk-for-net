// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using OpenTelemetry.Exporter.AzureMonitor.Models;

namespace OpenTelemetry.Exporter.AzureMonitor.HttpParsers
{
    /// <summary>
    /// HTTP Dependency parser that attempts to parse dependency as Azure Queue call.
    /// </summary>
    internal static class AzureQueueHttpParser
    {
        private static readonly string[] AzureQueueHostSuffixes =
            {
                ".queue.core.windows.net",
                ".queue.core.chinacloudapi.cn",
                ".queue.core.cloudapi.de",
                ".queue.core.usgovcloudapi.net",
            };

        private static readonly string[] AzureQueueSupportedVerbs = { "GET", "PUT", "OPTIONS", "HEAD", "DELETE", "POST" };

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

            if (!HttpParsingHelper.EndsWithAny(host, AzureQueueHostSuffixes))
            {
                return false;
            }

            ////
            //// Queue Service REST API: https://msdn.microsoft.com/en-us/library/azure/dd179423.aspx
            ////

            string account = host.Substring(0, host.IndexOf('.'));

            string verb;
            string nameWithoutVerb;

            // try to parse out the verb
            HttpParsingHelper.ExtractVerb(name, out verb, out nameWithoutVerb, AzureQueueSupportedVerbs);

            List<string> pathTokens = HttpParsingHelper.TokenizeRequestPath(nameWithoutVerb);
            string queueName = pathTokens.Count > 0 ? pathTokens[0] : string.Empty;

            httpDependency.Type = RemoteDependencyConstants.AzureQueue;

            return true;
        }
    }
}
