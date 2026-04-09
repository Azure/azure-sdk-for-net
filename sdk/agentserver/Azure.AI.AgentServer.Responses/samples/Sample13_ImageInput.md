# Sample 13: Image inputs

This sample shows how to build handlers that receive images as input. The Responses protocol supports three ways to send images:

1. **URL** — a public `https://` link to the image
2. **Base64 data URL** — the image bytes inline as `data:image/<format>;base64,<data>`
3. **File ID** — a previously uploaded file reference (not shown here)

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
        if (images.Count > 0 && IsBase64DataUrl(images[0].ImageUrl))
        {
            // Extract image bytes from the data URL.
            byte[] imageBytes = DecodeDataUrl(images[0].ImageUrl);
            reply = $"Received a base64 image ({imageBytes.Length} bytes).";
        }
        else
        {
            reply = "No base64 images found in the input.";
        }

        foreach (var evt in stream.OutputItemMessage(reply))
            yield return evt;

        yield return stream.EmitCompleted();
    }

    /// <summary>
    /// Checks whether the URI is a base64 data URL (e.g., "data:image/png;base64,...").
    /// </summary>
    private static bool IsBase64DataUrl(Uri uri)
        => uri.Scheme == "data";

    /// <summary>
    /// Extracts the raw image bytes from a base64 data URL.
    /// Expected format: <c>data:image/{format};base64,{base64data}</c>.
    /// </summary>
    private static byte[] DecodeDataUrl(Uri uri)
    {
        // The data URL format is: data:[<mediatype>][;base64],<data>
        string dataUrl = uri.OriginalString;
        int commaIndex = dataUrl.IndexOf(',');
        if (commaIndex < 0)
            throw new FormatException("Invalid data URL: missing comma separator.");

        string base64Part = dataUrl[(commaIndex + 1)..];
        return Convert.FromBase64String(base64Part);
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
