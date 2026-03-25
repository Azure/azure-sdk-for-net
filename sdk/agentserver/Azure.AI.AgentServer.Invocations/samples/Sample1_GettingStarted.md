# Sample 1: Getting Started — Plain Text Echo

The simplest possible invocation handler: read plain text in, write plain text out.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Invocations --prerelease
```

## Implement the handler

```csharp
using Azure.AI.AgentServer.Invocations;

public class EchoHandler : InvocationHandler
{
    public override async Task HandleAsync(
        HttpRequest request, HttpResponse response,
        InvocationContext context, CancellationToken cancellationToken)
    {
        var input = await new StreamReader(request.Body).ReadToEndAsync(cancellationToken);
        await response.WriteAsync($"You said: {input}", cancellationToken);
    }
}
```

## Start the server

```csharp
AgentServer.Run<EchoHandler>(args);
```

## Test it

```bash
curl -X POST http://localhost:8088/invocations \
  -H "Content-Type: text/plain" \
  -d "Hello, agent!"
```

Response: `You said: Hello, agent!`
