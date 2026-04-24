// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// VoiceLive Telemetry Samples
// ─────────────────────────────────────────────────────────────────────────────
// Demonstrates four OpenTelemetry configurations for VoiceLive.
// Each sample mirrors the corresponding Python sample from the Python SDK repo.
//
// SETUP:
//   $env:AZURE_VOICELIVE_ENDPOINT = "wss://..."
//   $env:AZURE_VOICELIVE_API_KEY  = "your-key"   # or omit for DefaultAzureCredential
//   $env:AZURE_VOICELIVE_MODEL    = "gpt-4o-realtime-preview"
//
// RUN:
//   dotnet run -- console               # Console exporter (default)
//   dotnet run -- azure-monitor         # Azure Monitor / Application Insights
//   dotnet run -- custom-attributes     # Custom span attributes via processor
//   dotnet run -- content-recording     # Enable message content recording

using Azure.AI.VoiceLive.Samples;

string sample = args.Length > 0 ? args[0] : "console";

await (sample switch
{
    "console"           => SampleWithConsoleTracing.RunAsync(),
    "azure-monitor"     => SampleWithAzureMonitorTracing.RunAsync(),
    "custom-attributes" => SampleWithCustomAttributes.RunAsync(),
    "content-recording" => SampleWithContentRecording.RunAsync(),
    _ => throw new ArgumentException(
        $"Unknown sample '{sample}'. Choose: console, azure-monitor, custom-attributes, content-recording")
});
