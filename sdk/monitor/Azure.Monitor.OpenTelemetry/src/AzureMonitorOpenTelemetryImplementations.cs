// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Monitor.OpenTelemetry.Exporter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using OpenTelemetry.Extensions.AzureMonitor;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry
{
    internal class AzureMonitorOpenTelemetryImplementations
    {
        internal static IServiceCollection AddAzureMonitorOpenTelemetryWithAction(IServiceCollection services, Action<AzureMonitorOpenTelemetryOptions> configureAzureMonitorOpenTelemetry)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configureAzureMonitorOpenTelemetry != null)
            {
                services.Configure(configureAzureMonitorOpenTelemetry);
            }

            var builder = services.AddOpenTelemetry();

            builder.WithTracing(b => b
                            .AddAspNetCoreInstrumentation()
                            .AddHttpClientInstrumentation()
                            .AddSqlClientInstrumentation()
                            .SetSampler(new ApplicationInsightsSampler(1.0F))
                            .AddAzureMonitorTraceExporter());

            builder.WithMetrics(b => b
                            .AddAspNetCoreInstrumentation()
                            .AddHttpClientInstrumentation()
                            .AddAzureMonitorMetricExporter());

            services.AddLogging(logging =>
            {
                logging.AddOpenTelemetry(builderOptions =>
                {
                    builderOptions.IncludeFormattedMessage = true;
                    builderOptions.ParseStateValues = true;
                    builderOptions.IncludeScopes = false;
                });
            });

            // Add AzureMonitorLogExporter to AzureMonitorOpenTelemetryOptions
            // once the service provider is available containing the final
            // AzureMonitorOpenTelemetryOptions.
            services.AddOptions<OpenTelemetryLoggerOptions>()
                    .Configure<IOptionsMonitor<AzureMonitorOpenTelemetryOptions>>((loggingOptions, azureOptions) =>
                    {
                        loggingOptions.AddAzureMonitorLogExporter(o => azureOptions.Get("").SetValueToExporterOptions(o));
                    });

            ServiceDescriptor? sdkTracerProviderServiceRegistration = null;
            ServiceDescriptor? sdkMeterProviderServiceRegistration = null;
            ServiceDescriptor? sdkLoggerProviderServiceRegistration = null;

            foreach (var service in services)
            {
                if (service.ServiceType == typeof(TracerProvider))
                {
                    sdkTracerProviderServiceRegistration = service;
                }
                else if (service.ServiceType == typeof(MeterProvider))
                {
                    sdkMeterProviderServiceRegistration = service;
                }
                else if (service.ServiceType == typeof(ILoggerProvider))
                {
                    var implementationFactory = service.ImplementationFactory;
                    if (implementationFactory != null && implementationFactory.Method.DeclaringType.Assembly == typeof(OpenTelemetryLoggerProvider).Assembly)
                    {
                        sdkLoggerProviderServiceRegistration = service;
                    }
                }
            }

            if (sdkTracerProviderServiceRegistration?.ImplementationFactory == null ||
                sdkMeterProviderServiceRegistration?.ImplementationFactory == null ||
                sdkLoggerProviderServiceRegistration?.ImplementationFactory == null)
            {
                throw new InvalidOperationException("OpenTelemetry SDK has changed its registration mechanism.");
            }

            // We looped through the registered services so that we can take over
            // the SDK registrations.

            services.Remove(sdkTracerProviderServiceRegistration);
            services.Remove(sdkMeterProviderServiceRegistration);
            services.Remove(sdkLoggerProviderServiceRegistration);

            // Register a configuration action so that when
            // AzureMonitorExporterOptions is requested it is populated from
            // AzureMonitorOpenTelemetryOptions.
            services
                .AddOptions<AzureMonitorExporterOptions>()
                .Configure<IOptionsMonitor<AzureMonitorOpenTelemetryOptions>>((exporterOptions, azureMonitorOptions) =>
                {
                    azureMonitorOptions.Get("").SetValueToExporterOptions(exporterOptions);
                });

            // Now we register our own services for TracerProvider,
            // MeterProvider, and LoggerProvider so that we can return no-op
            // versions when it isn't enabled.

            services.AddSingleton(sp =>
            {
                var options = sp.GetRequiredService<IOptionsMonitor<AzureMonitorOpenTelemetryOptions>>().Get("");
                if (!options.EnableTraces)
                {
                    return new NoopTracerProvider();
                }
                else
                {
                    var sdkProviderWrapper = sp.GetRequiredService<SdkProviderWrapper>();
                    sdkProviderWrapper.SdkTracerProvider = (TracerProvider)sdkTracerProviderServiceRegistration.ImplementationFactory(sp);
                    return sdkProviderWrapper.SdkTracerProvider;
                }
            });

            services.AddSingleton(sp =>
            {
                var options = sp.GetRequiredService<IOptionsMonitor<AzureMonitorOpenTelemetryOptions>>().Get("");
                if (!options.EnableMetrics)
                {
                    return new NoopMeterProvider();
                }
                else
                {
                    var sdkProviderWrapper = sp.GetRequiredService<SdkProviderWrapper>();
                    sdkProviderWrapper.SdkMeterProvider = (MeterProvider)sdkMeterProviderServiceRegistration.ImplementationFactory(sp);
                    return sdkProviderWrapper.SdkMeterProvider;
                }
            });

            services.AddSingleton(sp =>
            {
                var options = sp.GetRequiredService<IOptionsMonitor<AzureMonitorOpenTelemetryOptions>>().Get("");
                if (!options.EnableLogs)
                {
                    return new NoopLoggerProvider();
                }
                else
                {
                    var sdkProviderWrapper = sp.GetRequiredService<SdkProviderWrapper>();
                    sdkProviderWrapper.SdkLoggerProvider = (ILoggerProvider)sdkLoggerProviderServiceRegistration.ImplementationFactory(sp);
                    return sdkProviderWrapper.SdkLoggerProvider;
                }
            });

            // SdkProviderWrapper is here to make sure the SDK services get properly
            // shutdown when the service provider is disposed.
            services.AddSingleton<SdkProviderWrapper>();

            return services;
        }

        private sealed class NoopLoggerProvider : ILoggerProvider, ISupportExternalScope
        {
            public ILogger CreateLogger(string categoryName)
            {
                return NullLogger.Instance;
            }

            public void Dispose()
            {
            }

            public void SetScopeProvider(IExternalScopeProvider scopeProvider)
            {
            }
        }

        private sealed class NoopTracerProvider : TracerProvider
        {
        }

        private sealed class NoopMeterProvider : MeterProvider
        {
        }

        private sealed class SdkProviderWrapper : IDisposable
        {
            public TracerProvider? SdkTracerProvider;
            public MeterProvider? SdkMeterProvider;
            public ILoggerProvider? SdkLoggerProvider;

            public void Dispose()
            {
                this.SdkTracerProvider?.Dispose();
                this.SdkMeterProvider?.Dispose();
                this.SdkLoggerProvider?.Dispose();
            }
        }
    }
}
