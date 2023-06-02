// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals.Statsbeat
{
    internal static class ResourceProvider
    {
        internal static ResourceProviderDetails GetResourceProviderDetails(IPlatform platform, IVmMetadataProvider vmMetadataProvider)
        {
            try
            {
                var appSvcWebsiteName = platform.GetEnvironmentVariable("WEBSITE_SITE_NAME");
                if (appSvcWebsiteName != null)
                {
                    var appSvcWebsiteHostName = platform.GetEnvironmentVariable("WEBSITE_HOME_STAMPNAME");

                    return new ResourceProviderDetails
                    {
                        ResourceProvider = "appsvc",
                        ResourceProviderId = string.IsNullOrEmpty(appSvcWebsiteHostName)
                                                ? appSvcWebsiteName
                                                : appSvcWebsiteName + "/" + appSvcWebsiteHostName,
                        OperatingSystem = platform.GetOSPlatformName(),
                    };
                }

                var functionsWorkerRuntime = platform.GetEnvironmentVariable("FUNCTIONS_WORKER_RUNTIME");
                if (functionsWorkerRuntime != null)
                {
                    return new ResourceProviderDetails
                    {
                        ResourceProvider = "functions",
                        ResourceProviderId = platform.GetEnvironmentVariable("WEBSITE_HOSTNAME"),
                        OperatingSystem = platform.GetOSPlatformName(),
                    };
                }

                var vmMetadata = vmMetadataProvider.GetVmMetadataResponse();
                if (vmMetadata != null)
                {
                    return new ResourceProviderDetails
                    {
                        ResourceProvider = "vm",
                        ResourceProviderId = vmMetadata.vmId + "/" + vmMetadata.subscriptionId,
                        OperatingSystem = vmMetadata.osType?.ToLower(CultureInfo.InvariantCulture)
                                            ?? platform.GetOSPlatformName(),
                    };
                }
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.WriteWarning("ErrorGettingResourceProviderData", ex);
            }

            return new ResourceProviderDetails
            {
                ResourceProvider = "unknown",
                ResourceProviderId = "unknown",
                OperatingSystem = platform.GetOSPlatformName(),
            };
        }

        internal class ResourceProviderDetails
        {
            public string? ResourceProvider;

            public string? ResourceProviderId;

            public string? OperatingSystem;
        }
    }
}
