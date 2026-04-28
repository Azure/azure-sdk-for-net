# Telemetry Enablement

This sample shows the minimum code needed to enable OpenTelemetry tracing for an existing Azure AI VoiceLive application. No separate instrumentation class or feature flag is required — tracing activates as soon as you subscribe to the `"Azure.AI.VoiceLive"` ActivitySource.

## Enable tracing with minimal setup

```csharp
// Subscribe to the "Azure.AI.VoiceLive" ActivitySource.
// Tracing activates automatically — no separate instrumentor is needed.
using var tracerProvider = Sdk.CreateTracerProviderBuilder()
    .AddSource("Azure.AI.VoiceLive")
    .AddConsoleExporter()
    .Build();
```

Add these lines before creating your `VoiceLiveClient`. From that point on, all VoiceLive operations emit spans automatically — connecting, sending messages, receiving responses, and closing the session.

## Required packages

```bash
dotnet add package OpenTelemetry
dotnet add package OpenTelemetry.Exporter.Console
```

## Environment variables

| Variable | Required | Description |
|---|---|---|
| `AZURE_VOICELIVE_ENDPOINT` | **Yes** | VoiceLive endpoint URL |
| `AZURE_VOICELIVE_API_KEY` | **Yes** | API key |

## Next steps

- [Sample2_ConsoleTracing.md](Sample2_ConsoleTracing.md) — console tracing with service resource metadata
- [Sample3_AzureMonitorTracing.md](Sample3_AzureMonitorTracing.md) — export spans to Azure Monitor
- [Sample5_ContentRecording.md](Sample5_ContentRecording.md) — capture message payloads in spans
