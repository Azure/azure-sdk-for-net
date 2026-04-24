// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Mirrors sample_voicelive_with_content_recording.py
//
// Enables recording of message content (prompts, completions, event payloads)
// inside span attributes.  Content is redacted by default to avoid leaking
// sensitive data into telemetry backends.
//
// Two ways to enable content recording — choose one:
//   (A) Environment variable (applies process-wide, picked up by the Lazy<bool>):
//         $env:OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT = "true"
//
//   (B) Client option (preferred when you need per-client control):
//         new VoiceLiveClientOptions { EnableContentRecording = true }
//
// SETUP:
//   $env:AZURE_VOICELIVE_ENDPOINT = "wss://..."
//   $env:AZURE_VOICELIVE_API_KEY  = "your-key"
//
// RUN:
//   dotnet run -- content-recording

using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Azure.AI.VoiceLive.Samples;

internal static class SampleWithContentRecording
{
    internal static async Task RunAsync()
    {
        using var tracerProvider = Sdk.CreateTracerProviderBuilder()
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("voicelive-sample"))
            .AddSource("Azure.AI.VoiceLive")
            .AddConsoleExporter()
            .Build();

        // Option B: enable content recording per-client via VoiceLiveClientOptions.
        // To use option A instead, set OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT=true
        // in the environment before starting the process (the env var is read once, lazily).
        var clientOptions = new VoiceLiveClientOptions { EnableContentRecording = true };

        await VoiceLiveSessionHelper.RunAsync(VoiceLiveSessionHelper.CreateClient(clientOptions));
    }
}
