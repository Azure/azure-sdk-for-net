// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.JobSubmission
{
    using System;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;

    /// <summary>
    /// This type generates the gateway Uri for an AzureHDInsight cluster given its DNS Name or Endpoint uri.
    /// </summary>
    internal static class GatewayUriResolver
    {
        private static Version unknownVersion = new Version(0, 0, 0, 0);
        private static Version version20 = new Version(2, 0, 0, 0);
        private const int AzureGatewayUriPortNumberVersion15AndBelow = 563;
        private const int AzureGatewayUriPortNumberVersion16AndAbove = 443;
        private const string AzureWellKnownClusterSuffix = ".azurehdinsight.net";

        /// <summary>
        /// Gets the Gateway Uri for Http Services accessible on an Azure HDInsight cluster.
        /// </summary>
        /// <param name="clusterDnsNameOrEndpoint">The DNS Name or Endpoint uri of an Azure HDInsight cluster.</param>
        /// <param name="version">The version of the HDInsight cluster.</param>
        /// <returns>The Gateway Uri for Http Services accessible on an Azure HDInsight cluster.</returns>
        public static Uri GetGatewayUri(string clusterDnsNameOrEndpoint, Version version)
        {
            clusterDnsNameOrEndpoint.ArgumentNotNullOrEmpty("clusterDnsNameOrUri");
            string computedEndpoint;
            string originalScheme = string.Empty;
            var index = clusterDnsNameOrEndpoint.IndexOf("://", StringComparison.OrdinalIgnoreCase);
            if (index >= 0)
            {
                computedEndpoint = "http://" + clusterDnsNameOrEndpoint.Substring(index + 3);
                originalScheme = clusterDnsNameOrEndpoint.Substring(0, index);
            }
            else
            {
                computedEndpoint = "http://" + clusterDnsNameOrEndpoint;
                originalScheme = "http";
            }

            Uri tempUri;

            if (!Uri.TryCreate(computedEndpoint, UriKind.Absolute, out tempUri))
            {
                throw new NotSupportedException("Unable to compute Uri for given endpoint");
            }

            if (tempUri.Port == 80)
            {
                if (tempUri.Host == "localhost")
                {
                    return new Uri(originalScheme + "://" + tempUri.Host + ":50111");
                }

                tempUri = new Uri("https://" + tempUri.Host);
            }

            if (tempUri.Host == "localhost")
            {
                tempUri = new Uri(originalScheme + "://" + tempUri.Host + ":" + tempUri.Port);
                return tempUri;
            }

            if (tempUri.Scheme != "https")
            {
                tempUri = new Uri("https://" + tempUri.Host + ":" + tempUri.Port);
            }

            if (!tempUri.Host.Contains("."))
            {
                tempUri = new Uri(tempUri.Scheme + "://" + tempUri.Host + AzureWellKnownClusterSuffix + ":" + tempUri.Port);
            }

            if (version > unknownVersion)
            {
                int gatewayPort = GetGatewayPort(version);
                tempUri = new Uri(tempUri.Scheme + "://" + tempUri.Host + ":" + gatewayPort);
            }

            return tempUri;
        }

        /// <summary>
        /// Gets the Gateway Uri for Http Services accessible on an Azure HDInsight cluster.
        /// </summary>
        /// <param name="clusterDnsNameOrEndpoint">The DNS Name or Endpoint uri of an Azure HDInsight cluster.</param>
        /// <returns>The Gateway Uri for Http Services accessible on an Azure HDInsight cluster.</returns>
        public static Uri GetGatewayUri(string clusterDnsNameOrEndpoint)
        {
            clusterDnsNameOrEndpoint.ArgumentNotNullOrEmpty("clusterDnsNameOrUri");
            return GetGatewayUri(clusterDnsNameOrEndpoint, unknownVersion);
        }

        private static int GetGatewayPort(Version version)
        {
            if (version.Major == version20.Major && version.Minor == version20.Minor)
            {
                return AzureGatewayUriPortNumberVersion15AndBelow;
            }

            return AzureGatewayUriPortNumberVersion16AndAbove;
        }
    }
}