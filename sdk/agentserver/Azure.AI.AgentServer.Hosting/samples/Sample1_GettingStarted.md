# Sample 1: Tier 1 — Zero-Config Startup

This sample demonstrates the **Tier 1** developer experience: one package, one line of code, and you have a fully spec-compliant hosted agent container. The framework handles port binding, health probes, OpenTelemetry, graceful shutdown, and protocol endpoints.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Responses --prerelease
```

## The entire Program.cs

```C# Snippet:Hosting_Sample1_StartServer
AgentHost.Run<QnAHandler>(args);
```

That's it. The framework configures everything else.

## Implement the handler

```C# Snippet:Hosting_Sample1_QnAHandler
public class QnAHandler : IResponseHandler
{
    public async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        IResponseContext context,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var stream = new ResponseEventStream(context, request);

        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();

        var message = stream.AddOutputItemMessage();
        yield return message.EmitAdded();

        var text = message.AddTextContent();
        yield return text.EmitAdded();

        // In a real agent, call your model or knowledge base here.
        var answer = "The Azure AI Foundry is a platform for building, " +
                     "deploying, and managing AI agents.";

        yield return text.EmitDelta(answer);
        yield return text.EmitDone(answer);

        yield return message.EmitContentDone(text);
        yield return message.EmitDone();
        yield return stream.EmitCompleted();
    }
}
```

## Running the server

```bash
dotnet run
```

The server starts on port 8088 (or the `PORT` environment variable) with:
- OpenTelemetry traces and metrics configured automatically
- A `/healthy` health endpoint for liveness probes
- The `x-platform-server` identity header on all responses
- Responses protocol endpoints at `/responses`

## Testing the server

```bash
curl -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{"model":"qna","input":"What is Azure AI Foundry?"}' \
  --no-buffer
```

## When to use Tier 1

Use `AgentHost.Run<THandler>()` when you have a **single-protocol agent** and need no customization. This covers the vast majority of hosted agent scenarios.
