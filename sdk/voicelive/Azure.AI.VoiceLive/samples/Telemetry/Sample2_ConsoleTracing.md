# Console Tracing

This sample demonstrates how to enable OpenTelemetry console tracing for the Azure AI VoiceLive SDK. Spans are printed to stdout as they complete, which is useful for local development and debugging.

## Subscribe to the VoiceLive ActivitySource

Tracing activates automatically when you subscribe to the `"Azure.AI.VoiceLive"` ActivitySource with `AddSource(...)`. No separate instrumentation class is needed.

```C# Snippet:VoiceLiveConsoleTracing
using var tracerProvider = Sdk.CreateTracerProviderBuilder()
    .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("voicelive-sample"))
    .AddSource("Azure.AI.VoiceLive")
    .AddConsoleExporter()
    .Build();
```

Once the `TracerProvider` is created, all VoiceLive client activity — connecting, sending messages, receiving responses — automatically emits spans to the console.

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
| `AZURE_VOICELIVE_MODEL` | No | Model deployment name. Defaults to `gpt-4o-realtime-preview`. |

## See also

- [Sample2_AzureMonitorTracing.md](Sample2_AzureMonitorTracing.md) — send spans to Azure Monitor
- [Sample3_CustomAttributes.md](Sample3_CustomAttributes.md) — attach custom tags to every span
- [Sample4_ContentRecording.md](Sample4_ContentRecording.md) — capture message payloads in spans
