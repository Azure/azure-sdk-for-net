// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Mirrors sample_voicelive_with_console_tracing.py
//
// Registers the VoiceLive ActivitySource with OpenTelemetry and prints
// every completed span to the console.  No extra configuration is needed —
// tracing is active as soon as a listener subscribes to "Azure.AI.VoiceLive".
//
// SETUP:
//   $env:AZURE_VOICELIVE_ENDPOINT = "wss://..."
//   $env:AZURE_VOICELIVE_API_KEY  = "your-key"
//   $env:AZURE_VOICELIVE_MODEL    = "gpt-4o-realtime-preview"
//
// RUN:
//   dotnet run -- console

using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Azure.AI.VoiceLive.Samples;

internal static class SampleWithConsoleTracing
{
    internal static async Task RunAsync()
    {
        #region Snippet:VoiceLiveConsoleTracing
        using var tracerProvider = Sdk.CreateTracerProviderBuilder()
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("voicelive-sample"))
            .AddSource("Azure.AI.VoiceLive")
            .AddConsoleExporter()
            .Build();
        #endregion

        await VoiceLiveSessionHelper.RunAsync(VoiceLiveSessionHelper.CreateClient());
    }
}
