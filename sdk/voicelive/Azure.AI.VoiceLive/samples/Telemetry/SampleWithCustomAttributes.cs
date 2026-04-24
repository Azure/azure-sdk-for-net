// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Mirrors sample_voicelive_with_console_tracing_custom_attributes.py
//
// Shows how to attach custom attributes to every VoiceLive span by registering
// a BaseProcessor<Activity> that sets tags in OnStart.  The processor runs
// before the exporter, so custom attributes appear in every exported span.
//
// SETUP:
//   $env:AZURE_VOICELIVE_ENDPOINT = "wss://..."
//   $env:AZURE_VOICELIVE_API_KEY  = "your-key"
//
// RUN:
//   dotnet run -- custom-attributes

using System.Diagnostics;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Azure.AI.VoiceLive.Samples;

internal static class SampleWithCustomAttributes
{
    // Tags every VoiceLive span with application-specific context.
    private sealed class CustomAttributeProcessor : BaseProcessor<Activity>
    {
        public override void OnStart(Activity activity)
        {
            activity.SetTag("custom.user_id", "user_123");
            activity.SetTag("custom.session_type", "voice_assistant");
        }
    }

    internal static async Task RunAsync()
    {
        using var tracerProvider = Sdk.CreateTracerProviderBuilder()
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("voicelive-sample"))
            .AddSource("Azure.AI.VoiceLive")
            .AddProcessor(new CustomAttributeProcessor())
            .AddConsoleExporter()
            .Build();

        await VoiceLiveSessionHelper.RunAsync(VoiceLiveSessionHelper.CreateClient());
    }
}
