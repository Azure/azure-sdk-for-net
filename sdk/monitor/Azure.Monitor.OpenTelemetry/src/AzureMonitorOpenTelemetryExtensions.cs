// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Monitor.OpenTelemetry.Exporter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

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
        /// <param name="services"><see cref="IServiceCollection"/>.</param>
        /// <param name="configuration"><see cref="IConfiguration"/>.</param>
        /// <returns><see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddAzureMonitorOpenTelemetry(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new AzureMonitorOpenTelemetryOptions();
            configuration.Bind(options);
            return services.AddAzureMonitorOpenTelemetry(options);
        }

        /// <summary>
        /// Adds Azure Monitor OpenTelemetry into service collection.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/>.</param>
        /// <param name="options">The <see cref="AzureMonitorOpenTelemetryOptions" /> instance for configuration.</param>
        /// <returns><see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddAzureMonitorOpenTelemetry(this IServiceCollection services, AzureMonitorOpenTelemetryOptions? options = null)
        {
            options ??= new AzureMonitorOpenTelemetryOptions();

            var builder = services.AddOpenTelemetry();

            if (!options.DisableTraces)
            {
                builder.WithTracing(b => b
                             .ValidateAndAddInstrumentation((i) => i.AddAspNetCoreInstrumentation(), options.Traces.DisableAspNetInstrumentation)
                             .AddAzureMonitorTraceExporter(o =>
                             {
                                 o.ConnectionString = options.ConnectionString;
                                 o.DisableOfflineStorage = options.DisableOfflineStorage;
                                 o.StorageDirectory = options.StorageDirectory;
                             }));
            }

            if (!options.DisableMetrics)
            {
                builder.WithMetrics(b => b
                             .ValidateAndAddInstrumentation((i) => i.AddAspNetCoreInstrumentation(), options.Metrics.DisableAspNetInstrumentation)
                             .AddAzureMonitorMetricExporter(o =>
                             {
                                 o.ConnectionString = options.ConnectionString;
                                 o.DisableOfflineStorage = options.DisableOfflineStorage;
                                 o.StorageDirectory = options.StorageDirectory;
                             }));
            }

            return services;
        }

        private static T ValidateAndAddInstrumentation<T>(this T builder, Action<T> configure, bool isDisabled)
        {
            if (!isDisabled)
            {
                configure(builder);
            }

            return builder;
        }
    }
}
