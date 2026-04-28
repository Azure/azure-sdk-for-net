// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Azure.AI.VoiceLive.Samples.Snippets;

public partial class TelemetrySnippets
{
    public void TelemetryEnablement()
    {
        #region Snippet:VoiceLiveTelemetryEnablement
        // Subscribe to the "Azure.AI.VoiceLive" ActivitySource.
        // Tracing activates automatically — no separate instrumentor is needed.
        using var tracerProvider = Sdk.CreateTracerProviderBuilder()
            .AddSource("Azure.AI.VoiceLive")
            .AddConsoleExporter()
            .Build();
        #endregion
    }

    public void ConsoleTracing()
    {
        #region Snippet:VoiceLiveConsoleTracing
        using var tracerProvider = Sdk.CreateTracerProviderBuilder()
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("voicelive-sample"))
            .AddSource("Azure.AI.VoiceLive")
            .AddConsoleExporter()
            .Build();
        #endregion
    }

    public void AzureMonitorTracing(string connectionString)
    {
        #region Snippet:VoiceLiveAzureMonitorTracing
        using var tracerProvider = Sdk.CreateTracerProviderBuilder()
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("voicelive-sample"))
            .AddSource("Azure.AI.VoiceLive")
            .AddAzureMonitorTraceExporter(o => o.ConnectionString = connectionString)
            .Build();
        #endregion
    }

    #region Snippet:VoiceLiveCustomAttributeProcessor
    private sealed class CustomAttributeProcessor : BaseProcessor<Activity>
    {
        public override void OnStart(Activity activity)
        {
            activity.SetTag("custom.user_id", "user_123");
            activity.SetTag("custom.session_type", "voice_assistant");
        }
    }
    #endregion

    public void CustomAttributes()
    {
        #region Snippet:VoiceLiveCustomAttributes
        using var tracerProvider = Sdk.CreateTracerProviderBuilder()
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("voicelive-sample"))
            .AddSource("Azure.AI.VoiceLive")
            .AddProcessor(new CustomAttributeProcessor())
            .AddConsoleExporter()
            .Build();
        #endregion
    }

    public void ContentRecording()
    {
        #region Snippet:VoiceLiveContentRecording
        // Option B: enable content recording per-client via VoiceLiveClientOptions.
        // To use option A instead, set OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT=true
        // in the environment before starting the process (the env var is read once, lazily).
        var clientOptions = new VoiceLiveClientOptions { EnableContentRecording = true };
        #endregion
    }
}
