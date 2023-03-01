// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using OpenTelemetry.Logs;

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
            services.TryAddSingleton<IConfigureOptions<AzureMonitorOpenTelemetryOptions>,
                            DefaultAzureMonitorOpenTelemetryOptions>();
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

        internal static ILoggingBuilder AddAzureMonitorOpenTelemetryLogger(this ILoggingBuilder builder, Action<AzureMonitorOpenTelemetryOptions> configure)
        {
            builder.AddConfiguration();

            // builder.Services.TryAddEnumerable(
            //    ServiceDescriptor.Singleton<ILoggerProvider, AzureMonitorOpenTelemetryLoggerProvider>());

            builder.Services.TryAddEnumerable(
                ServiceDescriptor.Singleton<ILoggerProvider, AzureMonitorOpenTelemetryLoggerProvider>(
                    sp => new AzureMonitorOpenTelemetryLoggerProvider(sp)));

            LoggerProviderOptions.RegisterProviderOptions
                <AzureMonitorOpenTelemetryOptions, AzureMonitorOpenTelemetryLoggerProvider>(builder.Services);

            if (configure != null)
            {
                builder.Services.Configure(configure);
            }

            return builder;
        }
    }
}
