// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Mirrors sample_voicelive_with_azure_monitor_tracing.py
//
// Exports VoiceLive spans to Azure Monitor (Application Insights).
// The connection string can be supplied via the environment variable
// APPLICATIONINSIGHTS_CONNECTION_STRING or passed directly to AddAzureMonitorTraceExporter.
//
// SETUP:
//   $env:AZURE_VOICELIVE_ENDPOINT              = "wss://..."
//   $env:AZURE_VOICELIVE_API_KEY               = "your-key"
//   $env:APPLICATIONINSIGHTS_CONNECTION_STRING = "InstrumentationKey=...;..."
//
// RUN:
//   dotnet run -- azure-monitor

using Azure.Monitor.OpenTelemetry.Exporter;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Azure.AI.VoiceLive.Samples;

internal static class SampleWithAzureMonitorTracing
{
    internal static async Task RunAsync()
    {
        string connectionString = Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING")
            ?? throw new InvalidOperationException(
                "Set APPLICATIONINSIGHTS_CONNECTION_STRING to your Application Insights connection string.");

        using var tracerProvider = Sdk.CreateTracerProviderBuilder()
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("voicelive-sample"))
            .AddSource("Azure.AI.VoiceLive")
            .AddAzureMonitorTraceExporter(o => o.ConnectionString = connectionString)
            .Build();

        await VoiceLiveSessionHelper.RunAsync(VoiceLiveSessionHelper.CreateClient());
    }
}
