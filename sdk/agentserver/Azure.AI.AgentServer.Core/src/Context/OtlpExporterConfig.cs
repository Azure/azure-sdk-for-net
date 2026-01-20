// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

namespace Azure.AI.AgentServer.Core.Context;

/// <summary>
/// Provides configuration for OpenTelemetry OTLP exporter.
/// </summary>
internal static class OtlpExporterConfig
{
    /// <summary>
    /// Attempts to configure OpenTelemetry OTLP exporter for telemetry collection.
    /// </summary>
    /// <param name="builder">The host application builder.</param>
    /// <param name="appConf">The application configuration.</param>
    /// <param name="azureMonitorEnabled">Whether Azure Monitor is already enabled.</param>
    /// <returns>A tuple indicating if OTLP exporter is enabled and the endpoint.</returns>
    public static (bool Enabled, string? OtelEndpoint) TryUseOpenTelemetryExporter(
        this IHostApplicationBuilder builder,
        AppConfiguration appConf,
        bool azureMonitorEnabled)
    {
        if (string.IsNullOrWhiteSpace(appConf.OpenTelemetryExporterEndpoint))
        {
            return (false, null);
        }

        var uri = new Uri(appConf.OpenTelemetryExporterEndpoint);
        var otel = builder.Services.AddOpenTelemetry();

        otel.WithTracing(b =>
        {
            if (!azureMonitorEnabled)
            {
                b.AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation();
            }

            b.AddOtlpExporter(o => o.Endpoint = uri);
        });

        otel.WithMetrics(b =>
        {
            if (!azureMonitorEnabled)
            {
                b.AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation();
            }

            b.AddOtlpExporter(o => { o.Endpoint = uri; });
        });

        return (true, appConf.OpenTelemetryExporterEndpoint);
    }
}
