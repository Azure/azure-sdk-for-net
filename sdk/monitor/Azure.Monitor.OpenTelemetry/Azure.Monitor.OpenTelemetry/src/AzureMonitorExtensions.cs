// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Azure.Monitor.OpenTelemetry
{
    /// <summary>
    /// Extension methods for setting up Azure Monitor in an <see cref="IServiceCollection" />.
    /// </summary>
    public static class AzureMonitorExtensions
    {
        /// <summary>
        /// Adds Azure Monitor into service collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddAzureMonitor(this IServiceCollection services)
        {
            services.TryAddSingleton<IConfigureOptions<AzureMonitorOptions>,
                                    DefaultAzureMonitorOptions>();
            return services.AddAzureMonitor(o => o = new AzureMonitorOptions());
        }

        /// <summary>
        /// Adds Azure Monitor into service collection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <param name="options">The <see cref="AzureMonitorOptions" /> instance for configuration.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddAzureMonitor(this IServiceCollection services, AzureMonitorOptions options)
        {
            options ??= new AzureMonitorOptions();
            return services.AddAzureMonitor(o => o.Clone(options));
        }

        /// <summary>
        /// Adds Azure Monitor into service collection.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/>.</param>
        /// <param name="configureAzureMonitor">Callback action for configuring <see cref="AzureMonitorOptions"/>.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddAzureMonitor(this IServiceCollection services, Action<AzureMonitorOptions> configureAzureMonitor)
        {
            return AzureMonitorImplementations.AddAzureMonitorWithAction(services, configureAzureMonitor);
        }
    }
}
