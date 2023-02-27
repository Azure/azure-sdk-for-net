// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Monitor.OpenTelemetry.Exporter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
                            .AddAzureMonitorTraceExporter());

            builder.WithMetrics(b => b
                            .AddAspNetCoreInstrumentation()
                            .AddHttpClientInstrumentation()
                            .AddAzureMonitorMetricExporter());

            services.AddLogging(logging =>
            {
                AzureMonitorOpenTelemetryOptions logExporterOptions = new();
                if (configureAzureMonitorOpenTelemetry != null)
                {
                    configureAzureMonitorOpenTelemetry(logExporterOptions);
                }

                if (logExporterOptions.EnableLogs)
                {
                    logging.AddOpenTelemetry(builderOptions =>
                    {
                        builderOptions.IncludeFormattedMessage = true;
                        builderOptions.ParseStateValues = true;
                        builderOptions.IncludeScopes = false;
                        builderOptions.AddAzureMonitorLogExporter(o => logExporterOptions.SetValueToExporterOptions(o));
                    });
                }
            });

            ServiceDescriptor? sdkTracerProviderServiceRegistration = null;
            ServiceDescriptor? sdkMeterProviderServiceRegistration = null;

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
            }

            if (sdkTracerProviderServiceRegistration?.ImplementationFactory == null ||
                sdkMeterProviderServiceRegistration?.ImplementationFactory == null)
            {
                throw new InvalidOperationException("OpenTelemetry SDK has changed its registration mechanism.");
            }

            // We looped through the registered services so that we can take over
            // the SDK registrations.

            services.Remove(sdkTracerProviderServiceRegistration);
            services.Remove(sdkMeterProviderServiceRegistration);

            // Now we register our own services for TracerProvider & MeterProvider
            // so that we can return no-op versions when it isn't enabled.

            services.AddSingleton(sp =>
            {
                var options = sp.GetRequiredService<IOptionsMonitor<AzureMonitorOpenTelemetryOptions>>().Get("");
                if (!options.EnableTraces)
                {
                    return new NoopTracerProvider();
                }
                else
                {
                    options.SetValueToExporterOptions(sp);
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
                    options.SetValueToExporterOptions(sp);
                    var sdkProviderWrapper = sp.GetRequiredService<SdkProviderWrapper>();
                    sdkProviderWrapper.SdkMeterProvider = (MeterProvider)sdkMeterProviderServiceRegistration.ImplementationFactory(sp);
                    return sdkProviderWrapper.SdkMeterProvider;
                }
            });

            // SdkProviderWrapper is here to make sure the SDK services get properly
            // shutdown when the service provider is disposed.
            services.AddSingleton<SdkProviderWrapper>();

            return services;
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

            public void Dispose()
            {
                this.SdkTracerProvider?.Dispose();
                this.SdkMeterProvider?.Dispose();
            }
        }
    }
}
