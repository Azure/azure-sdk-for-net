# Sample 13: Image inputs

This sample shows how to build handlers that receive images as input. The Responses protocol supports three ways to send images:

1. **URL** — a public `https://` link to the image
2. **Base64 data URL** — the image bytes inline as `data:image/<format>;base64,<data>`
3. **File ID** — a path or identifier pointing to an image in a file store of your choice (uploaded separately)

The server library deserializes all three into `MessageContentInputImageContent`.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Responses --prerelease
```

## Handle URL image input

Clients send image URLs via the `input_image` content type. The handler receives these as `MessageContentInputImageContent` items with an `ImageUrl` property:

```C# Snippet:Responses_Sample13_ImageUrlHandler
public class ImageUrlHandler : ResponseHandler
{
    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var stream = new ResponseEventStream(context, request);

        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        // Retrieve the resolved input items and expand message content.
        var items = await context.GetInputItemsAsync(cancellationToken: cancellationToken);
        var imageUrls = items
            .OfType<ItemMessage>()
            .SelectMany(msg => msg.GetContentExpanded())
            .OfType<MessageContentInputImageContent>()
            .Where(img => img.ImageUrl != null)
            .Select(img => img.ImageUrl)
            .ToList();

        // Describe what we received (a real handler would call a vision model).
        string description = imageUrls.Count > 0
            ? $"I received {imageUrls.Count} image(s). First URL: {imageUrls[0]}"
            : "No images found in the input.";

        foreach (var evt in stream.OutputItemMessage(description))
            yield return evt;

        yield return stream.EmitCompleted();
    }
}
```

## Handle base64 image input

For inline images, clients send a data URL in the `image_url` field with the format `data:image/<format>;base64,<data>`. The handler can extract the raw bytes:

```C# Snippet:Responses_Sample13_ImageBase64Handler
public class ImageBase64Handler : ResponseHandler
{
    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var stream = new ResponseEventStream(context, request);

        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        var items = await context.GetInputItemsAsync(cancellationToken: cancellationToken);

        // Find all image content parts.
        var images = items
            .OfType<ItemMessage>()
            .SelectMany(msg => msg.GetContentExpanded())
            .OfType<MessageContentInputImageContent>()
            .Where(img => img.ImageUrl != null)
            .ToList();

        string reply;
        if (images.Count > 0 && DataUrl.TryDecodeBytes(images[0].ImageUrl, out byte[] imageBytes))
        {
            string? mediaType = DataUrl.GetMediaType(images[0].ImageUrl);
            reply = $"Received a {mediaType ?? "unknown"} image ({imageBytes.Length} bytes).";
        }
        else
        {
            reply = "No base64 images found in the input.";
        }

        foreach (var evt in stream.OutputItemMessage(reply))
            yield return evt;

        yield return stream.EmitCompleted();
    }
}
```

## Handle file ID image input

When clients upload images separately (to a blob store, file system, or any storage), they can reference them by `file_id`. The `file_id` is an opaque string — a file path, blob key, database record, or any identifier your store uses. The handler resolves it to the actual image bytes:

```C# Snippet:Responses_Sample13_ImageFileIdHandler
public class ImageFileIdHandler : ResponseHandler
{
    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var stream = new ResponseEventStream(context, request);

        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        var items = await context.GetInputItemsAsync(cancellationToken: cancellationToken);

        // Find image content parts that use file_id (a path in your file store).
        var images = items
            .OfType<ItemMessage>()
            .SelectMany(msg => msg.GetContentExpanded())
            .OfType<MessageContentInputImageContent>()
            .Where(img => img.FileId != null)
            .ToList();

        string reply = images.Count > 0
            ? $"Received {images.Count} image(s) by file ID. First: {images[0].FileId}"
            : "No file_id images found in the input.";

        foreach (var evt in stream.OutputItemMessage(reply))
            yield return evt;

        yield return stream.EmitCompleted();
    }
}
```

## Start the server

```C# Snippet:Responses_Sample13_StartUrlHandler
ResponsesServer.Run<ImageUrlHandler>();
```

## Test the endpoint

### Send an image URL

```bash
curl -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{
    "model": "vision",
    "input": [
      {
        "type": "message",
        "role": "user",
        "content": [
          {"type": "input_text", "text": "What is in this image?"},
          {"type": "input_image", "image_url": "https://example.com/photo.jpg", "detail": "auto"}
        ]
      }
    ]
  }' \
  --no-buffer
```

### Send a base64-encoded image

```bash
curl -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{
    "model": "vision",
    "input": [
      {
        "type": "message",
        "role": "user",
        "content": [
          {"type": "input_text", "text": "Describe this image"},
          {"type": "input_image", "image_url": "data:image/png;base64,iVBORw0KGgo=", "detail": "high"}
        ]
      }
    ]
  }' \
  --no-buffer
```

> **Tip**: The `detail` field is optional and defaults to `"auto"`. Use `"high"` for fine-grained analysis or `"low"` for faster processing with fewer tokens.

### Send an image by file ID

```bash
curl -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{
    "model": "vision",
    "input": [
      {
        "type": "message",
        "role": "user",
        "content": [
          {"type": "input_text", "text": "Analyze this photo"},
          {"type": "input_image", "file_id": "/images/landscape.png", "detail": "auto"}
        ]
      }
    ]
  }' \
  --no-buffer
```
