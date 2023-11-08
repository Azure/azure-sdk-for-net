﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Azure.Monitor.OpenTelemetry.Exporter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.ResourceDetectors.Azure;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry.AspNetCore
{
    /// <summary>
    /// Extension methods for setting up Azure Monitor in an <see cref="OpenTelemetryBuilder" />.
    /// </summary>
    public static class OpenTelemetryBuilderExtensions
    {
        private const string AspNetCoreInstrumentationPackageName = "OpenTelemetry.Instrumentation.AspNetCore";
        private const string HttpClientInstrumentationPackageName = "OpenTelemetry.Instrumentation.Http";
        private const string SqlClientInstrumentationPackageName = "OpenTelemetry.Instrumentation.SqlClient";

        /// <summary>
        /// Configures Azure Monitor for logging, distributed tracing, and metrics.
        /// </summary>
        /// <param name="builder"><see cref="OpenTelemetryBuilder"/>.</param>
        /// <returns>The supplied <see cref="OpenTelemetryBuilder"/> for chaining calls.</returns>
        /// <remarks>
        /// <para>
        /// This method configures Azure Monitor for use with OpenTelemetry by adding the Azure Monitor exporter for logging,
        /// distributed tracing, and metrics. It also configures the OpenTelemetry logger to include formatted messages and
        /// parsed state values.
        /// </para>
        ///
        /// <para>The following vendored instrumentations are added for distributed tracing:</para>
        /// <list type="bullet">
        /// <item>ASP.NET Core.</item>
        /// <item>HTTP Client.</item>
        /// <item>SQL Client.</item>
        /// </list>
        /// </remarks>
        public static OpenTelemetryBuilder UseAzureMonitor(this OpenTelemetryBuilder builder)
        {
            builder.Services.TryAddSingleton<IConfigureOptions<AzureMonitorOptions>,
                        DefaultAzureMonitorOptions>();
            return builder.UseAzureMonitor(o => { });
        }

        /// <summary>
        /// Configures Azure Monitor for logging, distributed tracing, and metrics.
        /// </summary>
        /// <param name="builder"><see cref="OpenTelemetryBuilder"/>.</param>
        /// <param name="configureAzureMonitor">Callback action for configuring <see cref="AzureMonitorOptions"/>.</param>
        /// <returns>The supplied <see cref="OpenTelemetryBuilder"/> for chaining calls.</returns>
        /// <remarks>
        /// <para>
        /// This method configures Azure Monitor for use with OpenTelemetry by adding the Azure Monitor exporter for logging,
        /// distributed tracing, and metrics. It also configures the OpenTelemetry logger to include formatted messages and
        /// parsed state values.
        /// </para>
        ///
        /// <para>The following vendored instrumentations are added for distributed tracing:</para>
        /// <list type="bullet">
        /// <item>ASP.NET Core.</item>
        /// <item>HTTP Client.</item>
        /// <item>SQL Client.</item>
        /// </list>
        /// </remarks>
        public static OpenTelemetryBuilder UseAzureMonitor(this OpenTelemetryBuilder builder, Action<AzureMonitorOptions> configureAzureMonitor)
        {
            if (builder.Services == null)
            {
                throw new ArgumentNullException(nameof(builder.Services));
            }

            if (configureAzureMonitor != null)
            {
                builder.Services.Configure(configureAzureMonitor);
            }

            Action<ResourceBuilder> configureResource = (r) => r
                .AddAttributes(new[] { new KeyValuePair<string, object>("telemetry.distro.name", "Azure.Monitor.OpenTelemetry.AspNetCore") })
                .AddDetector(new AppServiceResourceDetector())
                .AddDetector(new AzureVMResourceDetector());

            builder.ConfigureResource(configureResource);

            builder.WithTracing(b => b
                            .AddSource("Azure.*")
                            .AddVendorInstrumentationIfPackageNotReferenced()
                            .AddAzureMonitorTraceExporter());

            builder.WithMetrics(b => b
                            .AddAzureMonitorMetricExporter());

            builder.Services.AddLogging(logging =>
            {
                logging.AddOpenTelemetry(builderOptions =>
                {
                    var resourceBuilder = ResourceBuilder.CreateDefault();
                    configureResource(resourceBuilder);
                    builderOptions.SetResourceBuilder(resourceBuilder);

                    builderOptions.IncludeFormattedMessage = true;
                    builderOptions.IncludeScopes = false;
                });
            });

            // Add AzureMonitorLogExporter to AzureMonitorOptions
            // once the service provider is available containing the final
            // AzureMonitorOptions.
            builder.Services.AddOptions<OpenTelemetryLoggerOptions>()
                    .Configure<IOptionsMonitor<AzureMonitorOptions>>((loggingOptions, azureOptions) =>
                    {
                        loggingOptions.AddAzureMonitorLogExporter(o => azureOptions.Get(Options.DefaultName).SetValueToExporterOptions(o));
                    });

            // Register a configuration action so that when
            // AzureMonitorExporterOptions is requested it is populated from
            // AzureMonitorOptions.
            builder.Services
                    .AddOptions<AzureMonitorExporterOptions>()
                    .Configure<IOptionsMonitor<AzureMonitorOptions>>((exporterOptions, azureMonitorOptions) =>
                    {
                        azureMonitorOptions.Get(Options.DefaultName).SetValueToExporterOptions(exporterOptions);
                    });

            return builder;
        }

        private static TracerProviderBuilder AddVendorInstrumentationIfPackageNotReferenced(this TracerProviderBuilder tracerProviderBuilder)
        {
            var vendorInstrumentationActions = new Dictionary<string, Action>
            {
                { AspNetCoreInstrumentationPackageName, () => tracerProviderBuilder.AddAspNetCoreInstrumentation() },
                { SqlClientInstrumentationPackageName, () => tracerProviderBuilder.AddSqlClientInstrumentation() },
                {
                    HttpClientInstrumentationPackageName,
                        () => tracerProviderBuilder.AddHttpClientInstrumentation(o => o.FilterHttpRequestMessage = (_) =>
                            {
                            // Azure SDKs create their own client span before calling the service using HttpClient
                            // In this case, we would see two spans corresponding to the same operation
                            // 1) created by Azure SDK 2) created by HttpClient
                            // To prevent this duplication we are filtering the span from HttpClient
                            // as span from Azure SDK contains all relevant information needed.
                            var parentActivity = Activity.Current?.Parent;
                            if (parentActivity != null && parentActivity.Source.Name.Equals("Azure.Core.Http"))
                            {
                                return false;
                            }

                            return true;
                            })
                },
            };

            foreach (var packageActionPair in vendorInstrumentationActions)
            {
                Assembly? instrumentationAssembly = null;

                try
                {
                    instrumentationAssembly = Assembly.Load(packageActionPair.Key);
                    AzureMonitorAspNetCoreEventSource.Log.FoundInstrumentationPackageReference(packageActionPair.Key);
                }
                catch
                {
                    AzureMonitorAspNetCoreEventSource.Log.NoInstrumentationPackageReference(packageActionPair.Key);
                }

                if (instrumentationAssembly == null)
                {
                    packageActionPair.Value.Invoke();
                    AzureMonitorAspNetCoreEventSource.Log.VendorInstrumentationAdded(packageActionPair.Key);
                }
            }

            return tracerProviderBuilder;
        }
    }
}
