# Sample 12: Image generation

This sample shows how to build a handler that returns generated images using the `image_generation_call` output item type. The result can be delivered as **base64-encoded image data** — clients decode it to get the raw bytes (PNG, JPEG, WebP, etc.).

The sample demonstrates three patterns:
1. **Simple** — return a complete image in one shot
2. **Streaming** — send partial (progressive) images as the generation proceeds
3. **Full event control** — manually emit each lifecycle event

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Responses --prerelease
```

## Implement the handler

Use the `OutputItemImageGenCall()` convenience generator to emit the entire image generation lifecycle. The generator handles all inner events (`in_progress`, `generating`, `completed`, `done`) automatically:

```C# Snippet:Responses_Sample12_ImageHandlerConvenience
public class ImageHandler : ResponseHandler
{
    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var stream = new ResponseEventStream(context, request);

        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        // Generate an image (in a real handler, this would call a model or service).
        byte[] imageBytes = await GenerateImageAsync(cancellationToken);
        string resultBase64 = Convert.ToBase64String(imageBytes);

        foreach (var evt in stream.OutputItemImageGenCall(resultBase64))
            yield return evt;

        yield return stream.EmitCompleted();
    }

    private static Task<byte[]> GenerateImageAsync(CancellationToken cancellationToken)
    {
        // Placeholder: return a 1x1 red PNG.
        byte[] png =
        [
            0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A, 0x00, 0x00, 0x00, 0x0D,
            0x49, 0x48, 0x44, 0x52, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01,
            0x08, 0x02, 0x00, 0x00, 0x00, 0x90, 0x77, 0x53, 0xDE, 0x00, 0x00, 0x00,
            0x0C, 0x49, 0x44, 0x41, 0x54, 0x08, 0xD7, 0x63, 0xF8, 0xCF, 0xC0, 0x00,
            0x00, 0x00, 0x03, 0x00, 0x01, 0x36, 0x28, 0x19, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x49, 0x45, 0x4E, 0x44, 0xAE, 0x42, 0x60, 0x82,
        ];
        return Task.FromResult(png);
    }
}
```

## With streaming partial images

When generating high-resolution images, you can stream partial (progressive) renders so the client can show a preview. Use the builder API directly — the convenience generator doesn't support partials because the final result isn't known until after all partials complete:

```C# Snippet:Responses_Sample12_ImageHandlerStreaming
public class StreamingImageHandler : ResponseHandler
{
    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var stream = new ResponseEventStream(context, request);

        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        var ig = stream.AddOutputItemImageGenCall();
        yield return ig.EmitAdded();
        yield return ig.EmitInProgress();
        yield return ig.EmitGenerating();

        // Stream progressive renders as they become available.
        await foreach (string partialBase64 in GeneratePartialsAsync(cancellationToken))
        {
            yield return ig.EmitPartialImage(partialBase64);
        }

        // Final full-quality image (available only after generation completes).
        byte[] finalImage = await RenderFinalAsync(cancellationToken);
        yield return ig.EmitCompleted();
        yield return ig.EmitDone(Convert.ToBase64String(finalImage));

        yield return stream.EmitCompleted();
    }

    private static async IAsyncEnumerable<string> GeneratePartialsAsync(
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        // In a real handler, each yield would be a progressively higher-quality render.
        for (int i = 0; i < 2; i++)
        {
            await Task.Delay(10, cancellationToken);
            yield return Convert.ToBase64String(OnePxPng);
        }
    }

    private static Task<byte[]> RenderFinalAsync(CancellationToken cancellationToken) =>
        Task.FromResult(OnePxPng);

    // Minimal 1×1 red PNG for demonstration.
    private static readonly byte[] OnePxPng =
    [
        0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A, 0x00, 0x00, 0x00, 0x0D,
        0x49, 0x48, 0x44, 0x52, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01,
        0x08, 0x02, 0x00, 0x00, 0x00, 0x90, 0x77, 0x53, 0xDE, 0x00, 0x00, 0x00,
        0x0C, 0x49, 0x44, 0x41, 0x54, 0x08, 0xD7, 0x63, 0xF8, 0xCF, 0xC0, 0x00,
        0x00, 0x00, 0x03, 0x00, 0x01, 0x36, 0x28, 0x19, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x49, 0x45, 0x4E, 0x44, 0xAE, 0x42, 0x60, 0x82,
    ];
}
```

## With full event control

When you need fine-grained control — for example, to set custom properties, interleave non-event work, or control timing — use the builder API directly:

```C# Snippet:Responses_Sample12_ImageHandlerFullControl
public class ImageHandlerFullControl : ResponseHandler
{
    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var stream = new ResponseEventStream(context, request);

        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        var ig = stream.AddOutputItemImageGenCall();
        yield return ig.EmitAdded();
        yield return ig.EmitInProgress();
        yield return ig.EmitGenerating();

        // Optional: stream partial images for progressive rendering.
        byte[] partial = await RenderLowResAsync(cancellationToken);
        yield return ig.EmitPartialImage(Convert.ToBase64String(partial));

        // Final high-resolution result.
        byte[] finalImage = await RenderFullResAsync(cancellationToken);
        yield return ig.EmitCompleted();
        yield return ig.EmitDone(Convert.ToBase64String(finalImage));

        yield return stream.EmitCompleted();
    }

    private static Task<byte[]> RenderLowResAsync(CancellationToken cancellationToken) =>
        Task.FromResult(OnePxPng);

    private static Task<byte[]> RenderFullResAsync(CancellationToken cancellationToken) =>
        Task.FromResult(OnePxPng);

    private static readonly byte[] OnePxPng =
    [
        0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A, 0x00, 0x00, 0x00, 0x0D,
        0x49, 0x48, 0x44, 0x52, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01,
        0x08, 0x02, 0x00, 0x00, 0x00, 0x90, 0x77, 0x53, 0xDE, 0x00, 0x00, 0x00,
        0x0C, 0x49, 0x44, 0x41, 0x54, 0x08, 0xD7, 0x63, 0xF8, 0xCF, 0xC0, 0x00,
        0x00, 0x00, 0x03, 0x00, 0x01, 0x36, 0x28, 0x19, 0x00, 0x00, 0x00, 0x00,
        0x00, 0x49, 0x45, 0x4E, 0x44, 0xAE, 0x42, 0x60, 0x82,
    ];
}
```

## Start the server

```C# Snippet:Responses_Sample12_StartServer
ResponsesServer.Run<ImageHandler>();
```

## Test the endpoint

```bash
curl -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{"model": "image-gen", "input": "Draw a cat"}' \
  --no-buffer
```

The response body contains an `image_generation_call` item in the `output` array. The `result` field holds the base64-encoded image. When streaming (`"stream": true`), the same data appears in the `response.output_item.done` SSE event. Clients decode it to get the raw image bytes:

```python
import base64
# result = the "result" field from the output item
with open("image.png", "wb") as f:
    f.write(base64.b64decode(result))
```

In .NET:

```csharp
byte[] imageBytes = Convert.FromBase64String(result);
File.WriteAllBytes("image.png", imageBytes);
```
