# Azure AI VoiceLive Telemetry samples for .NET

This sample project demonstrates opt-in [OpenTelemetry](https://opentelemetry.io/)-based tracing for the Azure AI VoiceLive SDK, following [GenAI Semantic Conventions v1.34.0](https://opentelemetry.io/docs/specs/semconv/gen-ai/).

## Getting started

### Install dependencies

```bash
# Console tracing
dotnet add package Azure.AI.VoiceLive
dotnet add package OpenTelemetry
dotnet add package OpenTelemetry.Exporter.Console

# Azure Monitor tracing
dotnet add package Azure.Monitor.OpenTelemetry.Exporter
```

### Configure and enable tracing

Tracing activates automatically as soon as you subscribe to the `"Azure.AI.VoiceLive"` ActivitySource via `AddSource(...)`. No separate instrumentor class is needed.

```csharp
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

using var tracerProvider = Sdk.CreateTracerProviderBuilder()
    .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("voicelive-sample"))
    .AddSource("Azure.AI.VoiceLive")   // subscribe to VoiceLive spans
    .AddConsoleExporter()
    .Build();

// Run your VoiceLive code — spans are emitted automatically
var client = new VoiceLiveClient(new Uri(endpoint), credential);
var session = await client.StartSessionAsync(model);
```

### Enable content recording

Message payloads are **not** captured by default. Two ways to enable:

```csharp
// Option A: environment variable (process-wide)
// $env:OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT = "true"

// Option B: per-client option (preferred for fine-grained control)
var options = new VoiceLiveClientOptions { EnableContentRecording = true };
var client = new VoiceLiveClient(new Uri(endpoint), credential, options);
```

> **Warning:** Content recording may capture personal data (user speech transcripts, AI responses). Only enable in development or controlled environments.

### Disable tracing

Dispose the `TracerProvider` to stop exporting spans:

```csharp
tracerProvider.Dispose();
```

### Environment variables

| Variable | Required | Description |
|---|---|---|
| `AZURE_VOICELIVE_ENDPOINT` | **Yes** | VoiceLive endpoint URL (`wss://...`) |
| `AZURE_VOICELIVE_API_KEY` | No | API key. Omit to use `DefaultAzureCredential`. |
| `AZURE_VOICELIVE_MODEL` | No | Model deployment name. Defaults to `gpt-4o-realtime-preview`. |
| `OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT` | No | Set to `"true"` to record full message payloads in span events. **May contain personal data.** Defaults to `false`. |
| `AZURE_TRACING_GEN_AI_CONTENT_RECORDING_ENABLED` | No | Legacy equivalent of the above. If both are set and differ, content recording is disabled. |
| `APPLICATIONINSIGHTS_CONNECTION_STRING` | No | Required for the Azure Monitor sample. |

## Key concepts

### How it works

The VoiceLive SDK emits spans via `System.Diagnostics.ActivitySource` under the name `"Azure.AI.VoiceLive"`. The OpenTelemetry .NET SDK bridges `Activity` to OTel spans. No additional instrumentation package is required — just subscribe to the source with `AddSource("Azure.AI.VoiceLive")`.

1. **Connect span** — Created when the session starts, remains open for the entire session lifetime. Session-level metrics (turn count, audio bytes) are recorded on this span when the session ends.
2. **Send / Recv spans** — Each message sent or received creates a child span capturing the event type, message size, and (optionally) the full payload.
3. **First-token latency** — Measured from `response.create` to the first audio or text delta, recorded automatically.

### Span structure

```
connect (parent — open for the entire session lifetime)
├── send session.update
├── send conversation.item.create
├── send response.create
├── recv (session.created)
├── recv (response.audio.delta)   ← first-token latency recorded here
├── recv (response.audio.delta)
├── recv (response.done)          ← turn count incremented here
├── send response.cancel          ← interruption count incremented here
├── recv (error)                  ← error event recorded
└── close
```

### Span attributes

#### Standard GenAI Semantic Convention Attributes

| Attribute | Type | Description |
|---|---|---|
| `az.namespace` | string | Always `"Microsoft.CognitiveServices"` |
| `gen_ai.system` | string | Always `"az.ai.voicelive"` |
| `gen_ai.operation.name` | string | The operation: `connect`, `send`, `recv`, `close` |
| `gen_ai.request.model` | string | The model name (e.g., `gpt-4o-realtime-preview`) |
| `gen_ai.usage.input_tokens` | int | Input token count (from `response.done` usage) |
| `gen_ai.usage.output_tokens` | int | Output token count (from `response.done` usage) |
| `server.address` | string | Server hostname |
| `server.port` | int | Server port |
| `error.type` | string | Fully-qualified exception type name on error |

#### VoiceLive-Specific Attributes

| Attribute | Type | Scope | Description |
|---|---|---|---|
| `gen_ai.voice.session_id` | string | Connect span | Voice session ID from `session.created` |
| `gen_ai.voice.event_type` | string | Send/Recv spans | VoiceLive event type (e.g., `response.done`) |
| `gen_ai.voice.input_audio_format` | string | Connect span | Input audio format (e.g., `pcm16`) |
| `gen_ai.voice.output_audio_format` | string | Connect span | Output audio format |
| `gen_ai.voice.first_token_latency_ms` | float | Recv + Connect span | Milliseconds from `response.create` to first audio/text delta |
| `gen_ai.voice.turn_count` | int | Connect span | Completed response turns in the session |
| `gen_ai.voice.interruption_count` | int | Connect span | Number of `response.cancel` events sent |
| `gen_ai.voice.audio_bytes_sent` | int | Connect span | Total raw audio bytes sent |
| `gen_ai.voice.audio_bytes_received` | int | Connect span | Total raw audio bytes received |
| `gen_ai.voice.message_size` | int | Send/Recv spans | JSON byte length of each WebSocket message |

#### Span Events

| Event Name | When | Key Attributes |
|---|---|---|
| `gen_ai.input.messages` | On every send | `gen_ai.system`, `gen_ai.voice.event_type`, `gen_ai.event.content` (if content recording enabled) |
| `gen_ai.output.messages` | On every recv | `gen_ai.system`, `gen_ai.voice.event_type`, `gen_ai.event.content` (if content recording enabled) |
| `gen_ai.voice.error` | On server `error` events | `error.code`, `error.message` |
| `gen_ai.voice.rate_limits.updated` | On `rate_limits.updated` events | `gen_ai.voice.rate_limits` (JSON array) |

## Samples

Run with `dotnet run -- <sample-name>` from this directory:

| Argument | File | Description |
|---|---|---|
| `console` (default) | [SampleWithConsoleTracing.cs](SampleWithConsoleTracing.cs) | Console exporter — spans print to stdout |
| `azure-monitor` | [SampleWithAzureMonitorTracing.cs](SampleWithAzureMonitorTracing.cs) | Azure Monitor / Application Insights exporter |
| `custom-attributes` | [SampleWithCustomAttributes.cs](SampleWithCustomAttributes.cs) | Custom `BaseProcessor<Activity>` to inject app-specific tags |
| `content-recording` | [SampleWithContentRecording.cs](SampleWithContentRecording.cs) | Enable message content recording via `VoiceLiveClientOptions` |

### Console exporter (development)

```csharp
using var tracerProvider = Sdk.CreateTracerProviderBuilder()
    .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("voicelive-sample"))
    .AddSource("Azure.AI.VoiceLive")
    .AddConsoleExporter()
    .Build();
```

### Azure Monitor / Application Insights (production)

```csharp
using var tracerProvider = Sdk.CreateTracerProviderBuilder()
    .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("voicelive-sample"))
    .AddSource("Azure.AI.VoiceLive")
    .AddAzureMonitorTraceExporter(o => o.ConnectionString = connectionString)
    .Build();
```

### OTLP (Jaeger, Aspire Dashboard, etc.)

```csharp
using OpenTelemetry.Exporter;

using var tracerProvider = Sdk.CreateTracerProviderBuilder()
    .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("voicelive-sample"))
    .AddSource("Azure.AI.VoiceLive")
    .AddOtlpExporter()
    .Build();
```

### Custom span attributes

```csharp
private sealed class CustomAttributeProcessor : BaseProcessor<Activity>
{
    public override void OnStart(Activity activity)
    {
        activity.SetTag("custom.user_id", "user_123");
        activity.SetTag("custom.session_type", "voice_assistant");
    }
}

using var tracerProvider = Sdk.CreateTracerProviderBuilder()
    .AddSource("Azure.AI.VoiceLive")
    .AddProcessor(new CustomAttributeProcessor())
    .AddConsoleExporter()
    .Build();
```

## Troubleshooting

| Problem | Cause | Fix |
|---|---|---|
| No spans appear | `AddSource("Azure.AI.VoiceLive")` not called | Add `.AddSource("Azure.AI.VoiceLive")` to your `TracerProviderBuilder` |
| Spans created but not exported | No exporter configured | Add `.AddConsoleExporter()` or another exporter |
| Content not in span events | Content recording off by default | Set `OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT=true` or `VoiceLiveClientOptions { EnableContentRecording = true }` |
| Azure Monitor spans missing | Wrong or missing connection string | Set `APPLICATIONINSIGHTS_CONNECTION_STRING` |
| `InvalidOperationException` on startup | Missing endpoint env var | Set `AZURE_VOICELIVE_ENDPOINT` |

## Next steps

- See the main [Azure.AI.VoiceLive README](../../README.md) for general SDK usage and authentication.
- See the [BasicVoiceAssistant sample](../BasicVoiceAssistant/) for a non-telemetry usage example.
- Learn more about [OpenTelemetry .NET](https://opentelemetry.io/docs/languages/dotnet/) and [GenAI Semantic Conventions](https://opentelemetry.io/docs/specs/semconv/gen-ai/).
