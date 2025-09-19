// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    /// <summary>
    /// Provides resource provider detection utilities shared across the exporter.
    /// Uses the same logic as AzureMonitorStatsbeat.SetResourceProviderDetails.
    /// </summary>
    internal static class ResourceProviderHelper
    {
        /// <summary>
        /// Determines the compute type/resource provider for the current environment.
        /// This method follows the exact same order as AzureMonitorStatsbeat.SetResourceProviderDetails.
        /// </summary>
        /// <param name="platform">Platform interface for accessing environment variables</param>
        /// <returns>Resource provider string (functions, appsvc, aks, vm, unknown)</returns>
        public static string DetermineResourceProvider(IPlatform platform)
        {
            var functionsWorkerRuntime = platform.GetEnvironmentVariable(EnvironmentVariableConstants.FUNCTIONS_WORKER_RUNTIME);
            if (functionsWorkerRuntime != null)
            {
                return "functions";
            }

            var appSvcWebsiteName = platform.GetEnvironmentVariable(EnvironmentVariableConstants.WEBSITE_SITE_NAME);
            if (appSvcWebsiteName != null)
            {
                return "appsvc";
            }

            var aksArmNamespaceId = platform.GetEnvironmentVariable(EnvironmentVariableConstants.AKS_ARM_NAMESPACE_ID);
            if (aksArmNamespaceId != null)
            {
                return "aks";
            }

            var vmMetadata = AzureMonitorStatsbeat.GetVmMetadataResponse();
            if (vmMetadata != null)
            {
                return "vm";
            }

            return "unknown";
        }
    }
}
