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
        public static bool TryGetInstance(IPlatform platform, bool isAzureAppService, out IPerformanceCounterCollector? performanceCounterCollector)
        {
            try
            {
                var isWindows = platform.IsOSPlatform(OSPlatform.Windows);

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

                LiveMetricsExporterEventSource.Log.ResolvedPerformanceCounterCollector(isWindows, isAzureAppService, performanceCounterCollector.GetType().Name);
                return true;
            }
            catch (Exception ex)
            {
                // Since these are platform specific classes, exceptions could be thrown during constructor call.
                LiveMetricsExporterEventSource.Log.PerformanceCounterCollectorFactoryFailed(ex);
                performanceCounterCollector = null;
                return false;
            }
        }
    }
}
