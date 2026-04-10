# Sample 15: Structured outputs

This sample shows how to return structured data using the `structured_outputs` output item type. Use this when none of the existing output item types (message, function call, image, etc.) fit your needs — for example, returning analytics results, classification labels, form data, or any custom JSON payload.

The `structured_outputs` item carries a single `output` property, which is an arbitrary JSON object. Clients can deserialize it into their own strongly typed models or work with it as raw JSON.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Responses --prerelease
```

## Implement the handler

Use the `OutputItemStructuredOutputs()` convenience method to emit a complete structured output item in one call. The method takes a `BinaryData` parameter — serialize your object with `BinaryData.FromObjectAsJson()`:

```C# Snippet:Responses_Sample15_StructuredOutputHandler
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
        var result = new
        {
            sentiment = "positive",
            confidence = 0.95,
            topics = new[] { "product-quality", "customer-service" },
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

```C# Snippet:Responses_Sample15_StructuredOutputFullControl
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

```C# Snippet:Responses_Sample15_StartServer
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
    "topics": ["product-quality", "customer-service"]
  }
}
```
