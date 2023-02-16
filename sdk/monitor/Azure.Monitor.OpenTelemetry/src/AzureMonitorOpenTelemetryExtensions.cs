// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.Configuration;
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
        /// <param name="configuration"><see cref="IConfiguration"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddAzureMonitorOpenTelemetry(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new AzureMonitorOpenTelemetryOptions();
            configuration.Bind(options);
            return services.AddAzureMonitorOpenTelemetry(options);
        }

        /// <summary>
        /// Adds Azure Monitor OpenTelemetry into service collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <param name="enableTraces">Flag to enable/disable traces.</param>
        /// <param name="enableMetrics">Flag to enable/disable metrics.</param>
        /// <param name="enableLogs">Flag to enable/disable logs.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddAzureMonitorOpenTelemetry(this IServiceCollection services, bool enableTraces = true, bool enableMetrics = true, bool enableLogs = true)
        {
            return AzureMonitorOpenTelemetryImplementations.AddAzureMonitorOpenTelemetrySeperateOptions(services, enableTraces, enableMetrics, enableLogs);
        }

        /// <summary>
        /// Adds Azure Monitor OpenTelemetry into service collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <param name="options">The <see cref="AzureMonitorOpenTelemetryOptions" /> instance for configuration.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddAzureMonitorOpenTelemetry(this IServiceCollection services, AzureMonitorOpenTelemetryOptions options)
        {
            return AzureMonitorOpenTelemetryImplementations.AddAzureMonitorOpenTelemetryWithOptions(services, options);
        }

        /// <summary>
        /// Adds Azure Monitor OpenTelemetry into service collection.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/>.</param>
        /// <param name="configureAzureMonitorOpenTelemetry">Callback action for configuring <see cref="AzureMonitorOpenTelemetryOptions"/>.</param>
        /// <param name="name">Name which is used when retrieving options.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddAzureMonitorOpenTelemetry(this IServiceCollection services, Action<AzureMonitorOpenTelemetryOptions> configureAzureMonitorOpenTelemetry, string? name = null)
        {
            return AzureMonitorOpenTelemetryImplementations.AddAzureMonitorOpenTelemetryWithAction(services, configureAzureMonitorOpenTelemetry, name);
        }
    }
}
