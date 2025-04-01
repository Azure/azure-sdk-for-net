// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using Azure.Monitor.OpenTelemetry.AspNetCore.Internals.AzureSdkCompat;
using Azure.Monitor.OpenTelemetry.AspNetCore.Internals.Profiling;
using Azure.Monitor.OpenTelemetry.Exporter;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources.Azure;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry.AspNetCore
{
    /// <summary>
    /// Extension methods for setting up Azure Monitor in an <see cref="OpenTelemetryBuilder" />.
    /// </summary>
    public static class OpenTelemetryBuilderExtensions
    {
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
        /// <para>The following vendored instrumentation is added for distributed tracing:</para>
        /// <list type="bullet">
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
        /// <para>The following vendored instrumentation is added for distributed tracing:</para>
        /// <list type="bullet">
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
                .AddDetector(new AzureContainerAppsResourceDetector())
                .AddDetector(new AzureVMResourceDetector());

            builder.ConfigureResource(configureResource);

            builder.WithTracing(b => b
                            .AddSource("Azure.*")
                            .AddVendorInstrumentationIfPackageNotReferenced()
                            .AddAspNetCoreInstrumentation()
                            .AddHttpClientInstrumentation(o => o.FilterHttpRequestMessage = (_) =>
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
                            .AddProcessor<ProfilingSessionTraceProcessor>());

            builder.WithMetrics(b => b.AddHttpClientAndServerMetrics());

            // Register a configuration action so that when
            // AzureMonitorExporterOptions is requested it is populated from
            // AzureMonitorOptions.
            builder.Services
                    .AddOptions<AzureMonitorExporterOptions>()
                    .Configure<IOptionsMonitor<AzureMonitorOptions>>((exporterOptions, azureMonitorOptions) =>
                    {
                        azureMonitorOptions.Get(Options.DefaultName).SetValueToExporterOptions(exporterOptions);
                    });

            // Register Azure SDK log forwarder in the case it was not registered by the user application.
            builder.Services.AddHostedService(sp =>
            {
                var logForwarderType = Type.GetType("Microsoft.Extensions.Azure.AzureEventSourceLogForwarder, Microsoft.Extensions.Azure", false);

                if (logForwarderType != null && sp.GetService(logForwarderType) != null)
                {
                    AzureMonitorAspNetCoreEventSource.Log.LogForwarderIsAlreadyRegistered();
                    return AzureEventSourceLogForwarder.Noop;
                }

                var loggerFactory = sp.GetRequiredService<ILoggerFactory>();
                var loggerFilterOptions = sp.GetRequiredService<IOptionsMonitor<LoggerFilterOptions>>().CurrentValue;
                return new AzureEventSourceLogForwarder(loggerFactory, loggerFilterOptions);
            });

            builder.Services.AddOptions<AzureMonitorOptions>()
                .Configure<IConfiguration>((options, config) =>
                {
                    // This is a temporary workaround for hotfix GHSA-vh2m-22xx-q94f.
                    // https://github.com/open-telemetry/opentelemetry-dotnet/security/advisories/GHSA-vh2m-22xx-q94f
                    // We are disabling the workaround set by OpenTelemetry.Instrumentation.AspNetCore v1.8.1 and OpenTelemetry.Instrumentation.Http v1.8.1.
                    // The OpenTelemetry Community is deciding on an official stance on this issue and we will align with that final decision.
                    // TODO: FOLLOW UP ON: https://github.com/open-telemetry/semantic-conventions/pull/961 (2024-04-26)
                    if (config[EnvironmentVariableConstants.ASPNETCORE_DISABLE_URL_QUERY_REDACTION] == null)
                    {
                        config[EnvironmentVariableConstants.ASPNETCORE_DISABLE_URL_QUERY_REDACTION] = Boolean.TrueString;
                    }

                    if (config[EnvironmentVariableConstants.HTTPCLIENT_DISABLE_URL_QUERY_REDACTION] == null)
                    {
                        config[EnvironmentVariableConstants.HTTPCLIENT_DISABLE_URL_QUERY_REDACTION] = Boolean.TrueString;
                    }

                    // If connection string is not set in the options, try to get it from configuration.
                    if (string.IsNullOrWhiteSpace(options.ConnectionString) && config[EnvironmentVariableConstants.APPLICATIONINSIGHTS_CONNECTION_STRING] != null)
                    {
                        options.ConnectionString = config[EnvironmentVariableConstants.APPLICATIONINSIGHTS_CONNECTION_STRING];
                    }
                });

            builder.UseAzureMonitorExporter();

            return builder;
        }

        private static TracerProviderBuilder AddVendorInstrumentationIfPackageNotReferenced(this TracerProviderBuilder tracerProviderBuilder)
        {
            try
            {
                var instrumentationAssembly = Assembly.Load(SqlClientInstrumentationPackageName);
                AzureMonitorAspNetCoreEventSource.Log.FoundInstrumentationPackageReference(SqlClientInstrumentationPackageName);
            }
            catch
            {
                AzureMonitorAspNetCoreEventSource.Log.NoInstrumentationPackageReference(SqlClientInstrumentationPackageName);
                tracerProviderBuilder.AddSqlClientInstrumentation();
                AzureMonitorAspNetCoreEventSource.Log.VendorInstrumentationAdded(SqlClientInstrumentationPackageName);
            }

            return tracerProviderBuilder;
        }

        private static MeterProviderBuilder AddHttpClientAndServerMetrics(this MeterProviderBuilder meterProviderBuilder)
        {
            return Environment.Version.Major >= 8 ?
                meterProviderBuilder.AddMeter("Microsoft.AspNetCore.Hosting").AddMeter("System.Net.Http")
                : meterProviderBuilder.AddAspNetCoreInstrumentation().AddHttpClientInstrumentation();
        }
    }
}
