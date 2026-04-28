// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenTelemetry;
using OpenTelemetry.Trace;

namespace Azure.AI.VoiceLive.Samples;

internal static class TelemetryEnablementSample
{
    internal static async Task RunAsync()
    {
        #region Snippet:VoiceLiveTelemetryEnablement
        // Subscribe to the "Azure.AI.VoiceLive" ActivitySource.
        // Tracing activates automatically — no separate instrumentor is needed.
        using var tracerProvider = Sdk.CreateTracerProviderBuilder()
            .AddSource("Azure.AI.VoiceLive")
            .AddConsoleExporter()
            .Build();
        #endregion

        await VoiceLiveSessionHelper.RunAsync(VoiceLiveSessionHelper.CreateClient());
    }
}
