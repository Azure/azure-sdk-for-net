// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal static class OpenTelemetryBuilderServiceProviderExtensions
    {
        public static void EnsureSingleUseAzureMonitorExporterRegistration(this IServiceProvider serviceProvider)
        {
            var registrations = serviceProvider.GetServices<UseAzureMonitorExporterRegistration>();
            if (registrations.Count() > 1)
            {
                throw new NotSupportedException("Multiple calls to UseAzureMonitorExporter on the same IServiceCollection are not supported.");
            }
        }

        public static void EnsureNoUseAzureMonitorExporterRegistrations(this IServiceProvider serviceProvider)
        {
            var registrations = serviceProvider.GetServices<UseAzureMonitorExporterRegistration>();
            if (registrations.Any())
            {
                throw new NotSupportedException("Signal-specific AddAzureMonitorExporter / UseAzureMonitor methods and the cross-cutting UseAzureMonitorExporter method being invoked on the same IServiceCollection is not supported.");
            }
        }
    }
}
