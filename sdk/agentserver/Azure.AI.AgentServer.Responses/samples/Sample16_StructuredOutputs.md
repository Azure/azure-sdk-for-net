# Sample 16: Structured outputs

Developers can return structured data from a handler in two ways:

1. **JSON in message text** — serialize the JSON payload as the text of a regular message output item. Many agent APIs use this approach, and clients can control the format via the `text` property on the create request (e.g., requesting `json_object` or `json_schema`). This is the simplest option when you only need one structured result per response.

2. **`structured_outputs` item** (shown below) — a first-class output item type designed specifically for structured data. This gives the server more control: it can return both unstructured messages and structured data in the same response, each as a separate output item. The server decides what to emit — or the developer can make it client-controlled by inspecting the request's tools or text format to decide which style to use.

Use the `structured_outputs` item when the existing output types (message, function call, image, etc.) don't fit your use case — for example, returning analytics results, classification labels, form data, or any custom JSON payload alongside a natural language summary.

The `structured_outputs` item carries a single `output` property, which is an arbitrary JSON object. Clients can deserialize it into their own strongly typed models or work with it as raw JSON.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Responses --prerelease
```

## Implement the handler

Use the `OutputItemStructuredOutputs()` convenience method to emit a complete structured output item in one call. The method takes a `BinaryData` parameter — serialize your object with `BinaryData.FromObjectAsJson()`. The payload shape is entirely up to you — analytics, file references, classification labels, or any combination:

```C# Snippet:Responses_Sample16_StructuredOutputHandler
public class StructuredOutputHandler : ResponseHandler
{
    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var stream = new ResponseEventStream(context, request);

        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        // Build structured data — any serializable object works.
        // This example returns analytics alongside generated file references
        // to demonstrate that the payload shape is entirely up to the developer.
        var result = new
        {
            sentiment = "positive",
            confidence = 0.95,
            topics = new[] { "product-quality", "customer-service" },
            files = new object[]
            {
                new { name = "report.pdf", url = "https://storage.example.com/files/report.pdf", mediaType = "application/pdf" },
                new { name = "chart.png", url = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUg...", mediaType = "image/png" },
            },
        };

        // Emit as a structured outputs item.
        foreach (var evt in stream.OutputItemStructuredOutputs(
            BinaryData.FromObjectAsJson(result)))
        {
            yield return evt;
        }

        yield return stream.EmitCompleted();
        await Task.CompletedTask;
    }
}
```

## Full event control

For more control, use `AddOutputItemStructuredOutputs()` to get a builder, then emit the `added` and `done` events yourself:

```C# Snippet:Responses_Sample16_StructuredOutputFullControl
public class StructuredOutputFullControlHandler : ResponseHandler
{
    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var stream = new ResponseEventStream(context, request);

        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        // Get a builder for explicit event control.
        var builder = stream.AddOutputItemStructuredOutputs();

        var payload = BinaryData.FromObjectAsJson(new
        {
            classification = "urgent",
            entities = new[]
            {
                new { name = "Order #12345", type = "order_id" },
                new { name = "2024-01-15", type = "date" },
            },
        });

        var item = new StructuredOutputsOutputItem(payload, builder.ItemId);
        yield return builder.EmitAdded(item);
        yield return builder.EmitDone(item);

        yield return stream.EmitCompleted();
        await Task.CompletedTask;
    }
}
```

## Run the server

```C# Snippet:Responses_Sample16_StartServer
ResponsesServer.Run<StructuredOutputHandler>();
```

## Test the endpoint

```bash
curl -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{"model": "test", "input": "Analyze this product review"}' \
  --no-buffer
```

The response body contains a `structured_outputs` item in the `output` array. The `output` field holds your JSON payload. When streaming (`"stream": true`), the same data appears in the `response.output_item.done` SSE event:

```json
{
  "type": "structured_outputs",
  "output": {
    "sentiment": "positive",
    "confidence": 0.95,
    "topics": ["product-quality", "customer-service"],
    "files": [
      { "name": "report.pdf", "url": "https://storage.example.com/files/report.pdf", "mediaType": "application/pdf" },
      { "name": "chart.png", "url": "data:image/png;base64,iVBORw0KGgoAAAANSUhEUg...", "mediaType": "image/png" }
    ]
  }
}
```
