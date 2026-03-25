# Sample 2: Tier 2 — Builder with Multi-Protocol Composition

This sample demonstrates the **Tier 2** developer experience: use `AgentHost.CreateBuilder()` to compose multiple protocols, customize health checks, configure tracing, and control shutdown behavior. The builder gives you the same infrastructure as Tier 1 with full control over composition.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Responses --prerelease
dotnet add package Azure.AI.AgentServer.Invocations --prerelease
```

## Compose protocols on a single host

This example builds a customer support agent that exposes both protocols — the Responses API for streaming chat and Invocations for ticket submission:

```C# Snippet:Hosting_Sample2_Compose
using Azure.AI.AgentServer.Invocations;
using Azure.AI.AgentServer.Responses;

var builder = AgentHost.CreateBuilder(args);

// Register the Responses protocol for streaming chat.
builder.AddResponses<ChatHandler>();

// Register the Invocations protocol for ticket submission.
builder.AddInvocations<TicketHandler>();

// Customize health checks — add a readiness check for the knowledge base.
builder.ConfigureHealth(health =>
{
    health.AddCheck("knowledge_base", () =>
        HealthCheckResult.Healthy());
});

// Add a custom tracing source for your business logic.
builder.ConfigureTracing(tracing =>
{
    tracing.AddSource("CustomerSupport.BusinessLogic");
});

var app = builder.Build();
app.Run();
```

## Handler implementations

The chat handler streams responses via the Responses API:

```C# Snippet:Hosting_Sample2_ChatHandler
public class ChatHandler : IResponseHandler
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

        var reply = "Hello! I'm the support agent. How can I help you today?";
        yield return text.EmitDelta(reply);
        yield return text.EmitDone(reply);

        yield return message.EmitContentDone(text);
        yield return message.EmitDone();
        yield return stream.EmitCompleted();
    }
}
```

The ticket handler accepts structured JSON via the Invocations protocol:

```C# Snippet:Hosting_Sample2_TicketHandler
public class TicketHandler : InvocationHandler
{
    public override async Task HandleAsync(
        HttpRequest request,
        HttpResponse response,
        InvocationContext context,
        CancellationToken cancellationToken)
    {
        var ticket = await request.ReadFromJsonAsync<TicketInput>(cancellationToken);

        await response.WriteAsJsonAsync(new
        {
            ticket_id = context.InvocationId,
            subject = ticket?.Subject,
            status = "created"
        }, cancellationToken);
    }
}

public record TicketInput(string Subject, string Description);
```

## Endpoints

The composed server exposes endpoints for both protocols on a single port:
- `POST /responses` — Chat via the Responses API (streaming SSE)
- `GET /responses/{id}` — Retrieve a previous response
- `POST /invocations` — Submit a support ticket
- `GET /healthy` — Health endpoint (shared)

## When to use Tier 2

Use `AgentHost.CreateBuilder()` when you need to:
- Host **multiple protocols** on a single server
- Add **custom health checks**, tracing sources, or middleware
- Override **shutdown timeout** or **port binding**
- Access the underlying `WebApplicationBuilder` for advanced configuration
