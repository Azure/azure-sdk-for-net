// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.Monitor.OpenTelemetry
{
    /// <summary>
    /// Extension methods for setting up Azure Monitor OpenTelemetry in an <see cref="IServiceCollection" />.
    /// </summary>
    public static class AzureMonitorOpenTelemetryExtensions
    {
        /// <summary>
        /// Adds Azure Monitor OpenTelemetry into service collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddAzureMonitorOpenTelemetry(this IServiceCollection services)
        {
            return services.AddAzureMonitorOpenTelemetry(o => o = new AzureMonitorOpenTelemetryOptions());
        }

        /// <summary>
        /// Adds Azure Monitor OpenTelemetry into service collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <param name="options">The <see cref="AzureMonitorOpenTelemetryOptions" /> instance for configuration.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddAzureMonitorOpenTelemetry(this IServiceCollection services, AzureMonitorOpenTelemetryOptions options)
        {
            options ??= new AzureMonitorOpenTelemetryOptions();
            return services.AddAzureMonitorOpenTelemetry(o => o.Clone(options));
        }

        /// <summary>
        /// Adds Azure Monitor OpenTelemetry into service collection.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/>.</param>
        /// <param name="configureAzureMonitorOpenTelemetry">Callback action for configuring <see cref="AzureMonitorOpenTelemetryOptions"/>.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddAzureMonitorOpenTelemetry(this IServiceCollection services, Action<AzureMonitorOpenTelemetryOptions> configureAzureMonitorOpenTelemetry)
        {
            return AzureMonitorOpenTelemetryImplementations.AddAzureMonitorOpenTelemetryWithAction(services, configureAzureMonitorOpenTelemetry);
        }
    }
}
