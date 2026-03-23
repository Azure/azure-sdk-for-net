# Sample 1: Getting Started — Echo Handler

This sample shows the minimal implementation of `IResponseHandler` that echoes a message back to the caller.

## Implement the handler

```csharp
using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;

public class EchoHandler : IResponseHandler
{
    public async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        IResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(context, request);

        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        var message = stream.AddOutputItemMessage();
        yield return message.EmitAdded();

        var text = message.AddTextContent();
        yield return text.EmitAdded();

        yield return text.EmitDelta("Hello from the echo handler!");
        yield return text.EmitDone("Hello from the echo handler!");

        yield return message.EmitContentDone(text);
        yield return message.EmitDone();

        yield return stream.EmitCompleted();
    }
}
```

## Configure the server

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddResponsesServer();
builder.Services.AddScoped<IResponseHandler, EchoHandler>();

var app = builder.Build();
app.MapResponsesServer();
app.Run();
```

## Test the endpoint

```bash
curl -X POST http://localhost:5000/responses \
  -H "Content-Type: application/json" \
  -d '{"model": "echo"}' \
  --no-buffer
```
