# Sample 1: Getting Started — Echo Handler

This sample shows the simplest implementation of `ResponseHandler` — an echo handler that returns the user's input back as a text response.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Responses --prerelease
```

## Implement the handler

```C# Snippet:Responses_Sample1_EchoHandler
public class EchoHandler : ResponseHandler
{
    public override IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        CancellationToken cancellationToken)
    {
        return new TextResponse(context, request,
            createText: async ct =>
            {
                var input = await context.GetInputTextAsync(cancellationToken: ct);
                return $"Echo: {input}";
            });
    }
}
```

## Start the server

```C# Snippet:Responses_Sample1_StartServer
ResponsesServer.Run<EchoHandler>();
```

## Test the endpoint

```bash
curl -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{"model": "echo", "input": "Hello, world!"}' \
  --no-buffer
```
