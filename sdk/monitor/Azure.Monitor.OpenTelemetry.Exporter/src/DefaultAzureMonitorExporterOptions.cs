// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Azure.Monitor.OpenTelemetry.Exporter
{
    internal class DefaultAzureMonitorExporterOptions : IConfigureOptions<AzureMonitorExporterOptions>
    {
        private const string AzureMonitorExporterSectionFromConfig = "AzureMonitorExporter";
        private readonly IConfiguration? _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultAzureMonitorExporterOptions"/> class.
        /// </summary>
        /// <param name="configuration"><see cref="IConfiguration"/> from which configuration for Azure Monitor can be retrieved.</param>
        public DefaultAzureMonitorExporterOptions(IConfiguration? configuration = null)
        {
            _configuration = configuration;
        }

        public void Configure(AzureMonitorExporterOptions options)
        {
            try
            {
                if (_configuration != null)
                {
                    BindIConfigurationOptions(_configuration, options);

                    // IConfiguration can read from EnvironmentVariables or InMemoryCollection if configured to do so.
                    var connectionStringFromIConfig = _configuration[EnvironmentVariableConstants.APPLICATIONINSIGHTS_CONNECTION_STRING];
                    if (!string.IsNullOrEmpty(connectionStringFromIConfig))
                    {
                        options.ConnectionString = connectionStringFromIConfig;
                    }

                    // Sampler configuration via IConfiguration
                    var samplerFromConfig = _configuration[EnvironmentVariableConstants.OTEL_TRACES_SAMPLER];
                    var samplerArgFromConfig = _configuration[EnvironmentVariableConstants.OTEL_TRACES_SAMPLER_ARG];
                    ConfigureSamplingOptions(samplerFromConfig, samplerArgFromConfig, options);
                }

                // Environment Variable should take precedence.
                var connectionStringFromEnvVar = Environment.GetEnvironmentVariable(EnvironmentVariableConstants.APPLICATIONINSIGHTS_CONNECTION_STRING);
                if (!string.IsNullOrEmpty(connectionStringFromEnvVar))
                {
                    options.ConnectionString = connectionStringFromEnvVar;
                }

                // Explicit environment variables for sampler should override IConfiguration.
                var samplerTypeEnv = Environment.GetEnvironmentVariable(EnvironmentVariableConstants.OTEL_TRACES_SAMPLER);
                var samplerArgEnv = Environment.GetEnvironmentVariable(EnvironmentVariableConstants.OTEL_TRACES_SAMPLER_ARG);
                ConfigureSamplingOptions(samplerTypeEnv, samplerArgEnv, options);
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.ConfigureFailed(ex);
            }
        }

        private static void ConfigureSamplingOptions(string? samplerType, string? samplerArg, AzureMonitorExporterOptions options)
        {
            if (string.IsNullOrEmpty(samplerType) || string.IsNullOrEmpty(samplerArg))
            {
                return;
            }

            try
            {
                var samplerKey = samplerType!.Trim().ToLowerInvariant();
                string samplerArgValue = samplerArg ?? string.Empty; // ensure non-null for logging
                switch (samplerKey)
                {
                    case "microsoft.rate_limited":
                        if (double.TryParse(samplerArg, NumberStyles.Float, CultureInfo.InvariantCulture, out var tracesPerSecond))
                        {
                            if (tracesPerSecond >= 0)
                            {
                                options.TracesPerSecond = tracesPerSecond;
                            }
                            else
                            {
                                AzureMonitorExporterEventSource.Log.InvalidSamplerArgument(samplerKey, samplerArgValue);
                            }
                        }
                        else
                        {
                            AzureMonitorExporterEventSource.Log.InvalidSamplerArgument(samplerKey, samplerArgValue);
                        }
                        break;
                    case "microsoft.fixed_percentage":
                        if (double.TryParse(samplerArg, NumberStyles.Float, CultureInfo.InvariantCulture, out var ratio))
                        {
                            if (ratio >= 0.0 && ratio <= 1.0)
                            {
                                options.SamplingRatio = (float)ratio;
                            }
                            else
                            {
                                AzureMonitorExporterEventSource.Log.InvalidSamplerArgument(samplerKey, samplerArgValue);
                            }
                        }
                        else
                        {
                            AzureMonitorExporterEventSource.Log.InvalidSamplerArgument(samplerKey, samplerArgValue);
                        }
                        break;
                    default:
                        AzureMonitorExporterEventSource.Log.InvalidSamplerType(samplerType);
                        break;
                }
            }
            catch (Exception ex)
            {
                AzureMonitorExporterEventSource.Log.ConfigureFailed(ex);
            }
        }

        [UnconditionalSuppressMessage("Trimming", "IL2026", Justification = "Binding options is a known source of trim warnings; this is a deliberate usage.")]
        [UnconditionalSuppressMessage("AOT", "IL3050", Justification = "Binding options is a known source of AOT warnings; this is a deliberate usage.")]
        private static void BindIConfigurationOptions(IConfiguration configuration, AzureMonitorExporterOptions options)
        {
            configuration.GetSection(AzureMonitorExporterSectionFromConfig).Bind(options);
        }
    }
}
