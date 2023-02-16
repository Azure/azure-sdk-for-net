// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Monitor.OpenTelemetry.Exporter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry
{
    internal class AzureMonitorOpenTelemetryImplementations
    {
        internal static IServiceCollection AddAzureMonitorOpenTelemetryWithOptions(IServiceCollection services, AzureMonitorOpenTelemetryOptions? options)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            options ??= new AzureMonitorOpenTelemetryOptions();
            var builder = services.AddOpenTelemetry();

            if (options.EnableTraces)
            {
                builder.WithTracing(b => b
                             .AddAspNetCoreInstrumentation()
                             .AddAzureMonitorTraceExporter(o =>
                             {
                                 o.ConnectionString = options.ConnectionString;
                                 o.DisableOfflineStorage = options.DisableOfflineStorage;
                                 o.StorageDirectory = options.StorageDirectory;
                             }));
            }

            if (options.EnableMetrics)
            {
                builder.WithMetrics(b => b
                             .AddAspNetCoreInstrumentation()
                             .AddAzureMonitorMetricExporter(o =>
                             {
                                 o.ConnectionString = options.ConnectionString;
                                 o.DisableOfflineStorage = options.DisableOfflineStorage;
                                 o.StorageDirectory = options.StorageDirectory;
                             }));
            }

            return services;
        }

#pragma warning disable CA1801 // Review unused parameters
        internal static IServiceCollection AddAzureMonitorOpenTelemetrySeperateOptions(IServiceCollection services, bool enableTraces = true, bool enableMetrics = true, bool enableLogs = true)
#pragma warning restore CA1801 // Review unused parameters
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            var builder = services.AddOpenTelemetry();

            // TODO: Remove the hard-coded ConnectionString.
            // If ConnectionString is not provided in config, exporter will throw.
            // Modify exporter to read from configuration.
            if (enableTraces)
            {
                builder.WithTracing(b => b
                             .AddAspNetCoreInstrumentation()
                             .AddAzureMonitorTraceExporter(o =>
                             {
                                 o.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
                             }));
            }

            if (enableMetrics)
            {
                builder.WithMetrics(b => b
                             .AddAspNetCoreInstrumentation()
                             .AddAzureMonitorMetricExporter(o =>
                             {
                                 o.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
                             }));
            }

            return services;
        }

        internal static IServiceCollection AddAzureMonitorOpenTelemetryWithAction(IServiceCollection services, Action<AzureMonitorOpenTelemetryOptions> configureAzureMonitorOpenTelemetry, string? name)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            name ??= Options.DefaultName;

            if (configureAzureMonitorOpenTelemetry != null)
            {
                services.Configure(name, configureAzureMonitorOpenTelemetry);
            }

            var builder = services.AddOpenTelemetry();

            builder.WithTracing(b => b
                            .AddAspNetCoreInstrumentation()
                            .AddAzureMonitorTraceExporter());

            builder.WithMetrics(b => b
                            .AddAspNetCoreInstrumentation()
                            .AddAzureMonitorMetricExporter());

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
                var options = sp.GetRequiredService<IOptionsMonitor<AzureMonitorOpenTelemetryOptions>>().Get(name);
                if (!options.EnableTraces)
                {
                    return new NoopTracerProvider();
                }
                else
                {
                    SetValueToExporterOptions(sp, options);
                    var sdkProviderWrapper = sp.GetRequiredService<SdkProviderWrapper>();
                    sdkProviderWrapper.SdkTracerProvider = (TracerProvider)sdkTracerProviderServiceRegistration.ImplementationFactory(sp);
                    return sdkProviderWrapper.SdkTracerProvider;
                }
            });

            services.AddSingleton(sp =>
            {
                var options = sp.GetRequiredService<IOptionsMonitor<AzureMonitorOpenTelemetryOptions>>().Get(name);
                if (!options.EnableMetrics)
                {
                    return new NoopMeterProvider();
                }
                else
                {
                    SetValueToExporterOptions(sp, options);
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

        private static void SetValueToExporterOptions(IServiceProvider sp, AzureMonitorOpenTelemetryOptions options)
        {
            var exporterOptions = sp.GetRequiredService<IOptionsMonitor<AzureMonitorExporterOptions>>().Get("");

            // TODO: Remove the hard-coded ConnectionString.
            // If ConnectionString is not provided in config, exporter will throw.
            // Modify exporter to include environment variable.
            exporterOptions.ConnectionString = options.ConnectionString ?? "InstrumentationKey=00000000-0000-0000-0000-000000000000";
            exporterOptions.DisableOfflineStorage = options.DisableOfflineStorage;
            exporterOptions.StorageDirectory = options.StorageDirectory;
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
