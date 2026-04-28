# Content Recording

This sample demonstrates how to enable recording of message content (prompts, completions, event payloads) inside span attributes. Content is redacted by default to avoid leaking sensitive data into telemetry backends.

## Enable content recording per client

Pass `EnableContentRecording = true` through `VoiceLiveClientOptions` to capture message payloads for a specific client instance:

```C# Snippet:VoiceLiveContentRecording
// Option B: enable content recording per-client via VoiceLiveClientOptions.
// To use option A instead, set OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT=true
// in the environment before starting the process (the env var is read once, lazily).
var clientOptions = new VoiceLiveClientOptions { EnableContentRecording = true };
```

Then pass `clientOptions` when creating the `VoiceLiveClient`:

```csharp
var client = new VoiceLiveClient(endpoint, credential, clientOptions);
```

## Enable content recording process-wide

To enable content recording for all clients without modifying code, set the environment variable before starting the process:

```bash
# PowerShell
$env:OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT = "true"
```

> **Warning:** Content recording may capture personal data (user speech transcripts, AI responses). Only enable in development or controlled environments.

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
| `OTEL_INSTRUMENTATION_GENAI_CAPTURE_MESSAGE_CONTENT` | No | Set to `"true"` for process-wide content recording. |
| `AZURE_TRACING_GEN_AI_CONTENT_RECORDING_ENABLED` | No | Legacy equivalent. If both are set and differ, content recording is disabled. |

## See also

- [Sample2_ConsoleTracing.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/voicelive/Azure.AI.VoiceLive/samples/Sample2_ConsoleTracing.md) — basic console tracing setup
- [Sample4_CustomAttributes.md](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/voicelive/Azure.AI.VoiceLive/samples/Sample4_CustomAttributes.md) — attach custom tags to every span
