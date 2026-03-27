# Sample 6: Streaming OpenAI Proxy — Forward to an upstream server

This sample shows how to implement a `ResponseHandler` that acts as a **streaming proxy**: it receives requests from clients, forwards them to an upstream [OpenAI-compatible responses server](https://platform.openai.com/docs/api-reference/responses) using the [OpenAI .NET SDK](https://github.com/openai/openai-dotnet), and streams each event back as it arrives.

All input and output item types are preserved with full fidelity. Both model stacks are generated from TypeSpec and share the same JSON wire format, so translating between them uses a fluent `.Translate().To<T>()` helper:

```csharp
// Our Item → OpenAI ResponseItem (input)
ResponseItem openAiItem = ourItem.Translate().To<ResponseItem>();

// OpenAI StreamingResponseUpdate → our ResponseStreamEvent (output)
ResponseStreamEvent ourEvent = openAiUpdate.Translate().To<ResponseStreamEvent>();
```

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Responses --prerelease
dotnet add package OpenAI
```

## Wire-format translation helper

The `Translate().To<T>()` pattern round-trips through JSON to convert between model types that share the same wire format. Add this small helper to your project:

```C# Snippet:Responses_WireFormatTranslation
/// <summary>
/// Extension for translating between model types that share the same underlying
/// JSON wire contract. This works because both the Azure.AI.AgentServer.Responses
/// and OpenAI .NET SDK model stacks are generated from the same TypeSpec
/// definitions and produce identical JSON on the wire.
/// <para>
/// <strong>Important:</strong> Only use this for types whose JSON serialization
/// is wire-compatible. If the source and target types do not share the same JSON
/// schema (property names, discriminators, structure), deserialization will
/// silently produce incomplete objects or throw.
/// </para>
/// </summary>
/// <example>
/// <code>
/// // Azure Item → OpenAI ResponseItem
/// ResponseItem openAiItem = ourItem.Translate().To&lt;ResponseItem&gt;();
///
/// // OpenAI StreamingResponseUpdate → Azure ResponseStreamEvent
/// ResponseStreamEvent evt = update.Translate().To&lt;ResponseStreamEvent&gt;();
/// </code>
/// </example>
public static class WireFormatExtensions
{
    /// <summary>
    /// Serializes <paramref name="model"/> to its JSON wire format, returning
    /// an intermediate <see cref="WireFormatData"/> that can be deserialized
    /// as a different (wire-compatible) model type via
    /// <see cref="WireFormatData.To{T}"/>.
    /// </summary>
    public static WireFormatData Translate<T>(this T model) where T : IPersistableModel<T>
        => new(ModelReaderWriter.Write(model));
}

/// <summary>
/// Intermediate wire-format bytes produced by
/// <see cref="WireFormatExtensions.Translate{T}"/>.
/// Call <see cref="To{T}"/> to deserialize as the target model type.
/// </summary>
public readonly struct WireFormatData
{
    private readonly BinaryData _data;
    internal WireFormatData(BinaryData data) => _data = data;

    /// <summary>
    /// Deserializes the wire-format bytes as <typeparamref name="T"/>.
    /// The target type must share the same JSON wire contract as the
    /// source type that produced this data.
    /// </summary>
    public T To<T>() where T : IPersistableModel<T>
        => ModelReaderWriter.Read<T>(_data)!;
}
```

## Implement the handler

```C# Snippet:Responses_Sample6_StreamingProxyHandler
public class StreamingProxyHandler : ResponseHandler
{
    private readonly ResponsesClient _upstream;

    public StreamingProxyHandler(ResponsesClient upstream) => _upstream = upstream;

    public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        // Build the upstream request using the OpenAI .NET SDK.
        var options = new CreateResponseOptions()
        {
            Model = request.Model,
            Instructions = request.Instructions,
        };

        // Translate every input item with full fidelity. Both model stacks
        // are generated from TypeSpec and share the same JSON wire format,
        // so .Translate().To<T>() round-trips through JSON to convert:
        //   our Item → JSON → OpenAI ResponseItem.
        foreach (Item item in request.GetInputExpanded())
        {
            options.InputItems.Add(item.Translate().To<ResponseItem>());
        }

        // Stream from the upstream server. Each event is translated back
        // using the same pattern in reverse.
        await foreach (StreamingResponseUpdate update in
            _upstream.CreateResponseStreamingAsync(options, cancellationToken))
        {
            yield return update.Translate().To<ResponseStreamEvent>();
        }
    }
}
```

## Start the server

Register the OpenAI `ResponsesClient` as a singleton service. Set `UPSTREAM_ENDPOINT` to point at another responses server, or leave it unset to call OpenAI directly.

```C# Snippet:Responses_Sample6_StartServer
ResponsesServer.Run<StreamingProxyHandler>(configure: builder =>
{
    builder.Services.AddSingleton(new ResponsesClient(
        new ApiKeyCredential(
            Environment.GetEnvironmentVariable("OPENAI_API_KEY") ?? "your-api-key"),
        new OpenAIClientOptions
        {
            Endpoint = new Uri(
                Environment.GetEnvironmentVariable("UPSTREAM_ENDPOINT")
                    ?? "https://api.openai.com/v1")
        }));
});
```

## Test the endpoint

```bash
export OPENAI_API_KEY="sk-..."
# Optionally point to another local server:
# export UPSTREAM_ENDPOINT="http://localhost:8089"

curl -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{"model": "gpt-4o-mini", "input": "What is Azure AI Foundry?"}' \
  --no-buffer
```
