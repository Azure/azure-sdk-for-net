// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using OpenTelemetry.Trace;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals;

/// <summary>
/// Factory for creating samplers based on configuration and environment variables.
/// </summary>
internal static class SamplerConfig
{
    private const string RateLimitedSamplerName = "microsoft.rate_limited";
    private const string FixedPercentageSamplerName = "microsoft.fixed_percentage";
    private const double DefaultTracesPerSecond = 5.0;

    /// <summary>
    /// Creates a sampler based on environment variables and configuration options.
    /// Environment variables take precedence over configuration options.
    /// </summary>
    /// <param name="options">The exporter options containing sampling configuration.</param>
    /// <returns>The configured sampler.</returns>
    public static Sampler CreateSampler(AzureMonitorExporterOptions options)
    {
        // First, try to get sampler configuration from environment variables
        var envSampler = Environment.GetEnvironmentVariable(EnvironmentVariableConstants.OTEL_TRACES_SAMPLER);
        var envSamplerArg = Environment.GetEnvironmentVariable(EnvironmentVariableConstants.OTEL_TRACES_SAMPLER_ARG);

        if (!string.IsNullOrEmpty(envSampler))
        {
            var sampler = CreateSamplerFromEnvironmentVariables(envSampler, envSamplerArg);
            if (sampler != null)
            {
                return sampler;
            }

            // If environment variables are invalid, log error and fall back to options
            AzureMonitorExporterEventSource.Log.UnsupportedSamplerEnvironmentVariable(envSampler, envSamplerArg);
        }

        // Fall back to configuration options
        return CreateSamplerFromOptions(options);
    }

    private static Sampler? CreateSamplerFromEnvironmentVariables(string? samplerName, string? samplerArg)
    {
        if (string.IsNullOrEmpty(samplerName) || string.IsNullOrEmpty(samplerArg))
        {
            return null;
        }

        switch (samplerName?.ToLowerInvariant())
        {
            case RateLimitedSamplerName:
                if (TryParseDouble(samplerArg, out var tracesPerSecond))
                {
                    return new RateLimitedSampler(tracesPerSecond);
                }
                return null; // Invalid argument

            case FixedPercentageSamplerName:
                if (TryParseDouble(samplerArg, out var samplingRatio) && samplingRatio >= 0.0 && samplingRatio <= 1.0)
                {
                    return new ApplicationInsightsSampler((float)samplingRatio);
                }
                return null; // Invalid argument

            default:
                return null; // Unsupported sampler name
        }
    }

    private static Sampler CreateSamplerFromOptions(AzureMonitorExporterOptions options)
    {
        if (options.TracesPerSecond.HasValue)
        {
            return new RateLimitedSampler(options.TracesPerSecond.Value);
        }

        // Use ApplicationInsightsSampler with the configured sampling ratio
        return new ApplicationInsightsSampler(options.SamplingRatio);
    }

    private static bool TryParseDouble(string? value, out double result)
    {
        result = 0.0;
        return !string.IsNullOrEmpty(value) && double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out result);
    }
}