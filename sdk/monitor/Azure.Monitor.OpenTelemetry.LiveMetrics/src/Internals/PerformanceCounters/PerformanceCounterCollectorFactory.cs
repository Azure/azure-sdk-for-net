// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Diagnostics;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.PerformanceCounters
{
    internal static class PerformanceCounterCollectorFactory
    {
        private const string WEBSITE_ISOLATION_HYPERV = "hyperv";

        public static bool TryGetInstance(IPlatform platform, out IPerformanceCounterCollector? performanceCounterCollector)
        {
            try
            {
                var isWindows = platform.IsOSPlatform(OSPlatform.Windows);
                var isAzureAppService = IsAzureAppService(platform);

                if (isAzureAppService && isWindows)
                {
                    performanceCounterCollector = new AzureWebAppWindowsPerformanceCounterCollector();
                }
                else if (isWindows)
                {
                    performanceCounterCollector = new WindowsPerformanceCounterCollector();
                }
                else
                {
                    performanceCounterCollector = new NonWindowsPerformanceCounterCollector();
                }

                LiveMetricsExporterEventSource.Log.PerformanceCounterCollectorFactoryDecision(isWindows, isAzureAppService, performanceCounterCollector.GetType().Name);
                return true;
            }
            catch (Exception ex)
            {
                // Since these are platform specific classes, exceptions could be thrown during constructor call.
                // This shouldn't happen, but here we catch the exception.
                LiveMetricsExporterEventSource.Log.PerformanceCounterCollectorFactoryFailed(ex);
                performanceCounterCollector = null;
                return false;
            }
        }

        /// <summary>
        /// Evaluates environment variables specific to Azure Web App.
        /// </summary>
        /// <remarks>
        /// Presence of "WEBSITE_SITE_NAME" indicate web apps.
        /// "WEBSITE_ISOLATION"=="hyperv" indicate premium containers.
        /// In the case of premium containers, perf counters can be read using regular mechanism and hence this method returns false.
        /// </remarks>
        private static bool IsAzureAppService(IPlatform platform)
        {
            return !string.IsNullOrEmpty(platform.GetEnvironmentVariable(EnvironmentVariableConstants.WEBSITE_SITE_NAME))
                && platform.GetEnvironmentVariable(EnvironmentVariableConstants.WEBSITE_ISOLATION) != WEBSITE_ISOLATION_HYPERV;
        }
    }
}
