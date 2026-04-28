# Custom Span Attributes

This sample demonstrates how to attach application-specific attributes to every VoiceLive span by registering a custom `BaseProcessor<Activity>`.

## Implement a custom processor

Create a class that derives from `BaseProcessor<Activity>` and override `OnStart` to set tags before the span is exported:

```csharp
private sealed class CustomAttributeProcessor : BaseProcessor<Activity>
{
    public override void OnStart(Activity activity)
    {
        activity.SetTag("custom.user_id", "user_123");
        activity.SetTag("custom.session_type", "voice_assistant");
    }
}
```

## Register the processor

Pass the processor to `AddProcessor` when building the `TracerProvider`:

```csharp
using var tracerProvider = Sdk.CreateTracerProviderBuilder()
    .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("voicelive-sample"))
    .AddSource("Azure.AI.VoiceLive")
    .AddProcessor(new CustomAttributeProcessor())
    .AddConsoleExporter()
    .Build();
```

The processor runs before the exporter, so every exported span (connect, send, recv, close) will include the custom tags.

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

## See also

- [Sample2_ConsoleTracing.md](Sample2_ConsoleTracing.md) — basic console tracing setup
- [Sample5_ContentRecording.md](Sample5_ContentRecording.md) — capture message payloads in spans
