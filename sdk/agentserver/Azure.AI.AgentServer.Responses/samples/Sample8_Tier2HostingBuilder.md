# Sample 8: Tier 2 — Builder with Full Control

This sample demonstrates the **Tier 2** developer experience for the Responses protocol: use `AgentHost.CreateBuilder()` to get full control over service registration, handler construction, configuration, and tracing while still leveraging the Core framework infrastructure.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Responses --prerelease
```

## Use the builder with a generic handler type

Register your handler type on the builder and let the DI container construct it:

```C# Snippet:Responses_Sample8_BuilderGeneric
var builder = AgentHost.CreateBuilder();

// Register services that the handler depends on.
builder.Services.AddSingleton<IKnowledgeBase, WikiKnowledgeBase>();

// Register the Responses protocol with a concrete handler type.
builder.AddResponses<KnowledgeHandler>();

var app = builder.Build();
app.Run();
```

## Use the builder with a factory delegate

When you need full control over handler construction — for example, to set
properties that aren't part of the DI graph — use the factory overload:

```C# Snippet:Responses_Sample8_BuilderWithFactory
var builder = AgentHost.CreateBuilder();

// Register services on the builder.
builder.Services.AddSingleton<IKnowledgeBase, WikiKnowledgeBase>();

// Use a factory delegate for handler construction.
builder.AddResponses(factory: sp =>
{
    var kb = sp.GetRequiredService<IKnowledgeBase>();
    return new KnowledgeHandler(kb);
});

// Configuration and tracing work the same way.
builder.ConfigureTracing(tracing =>
{
    tracing.AddSource("MyAgent.BusinessLogic");
});

builder.ConfigureShutdown(TimeSpan.FromSeconds(15));

var app = builder.Build();
app.Run();
```

## Handler implementation

The handler receives services through constructor injection regardless of
whether you use the generic or factory pattern:

```C# Snippet:Responses_Sample8_KnowledgeHandler
public class KnowledgeHandler : ResponseHandler
{
    private readonly IKnowledgeBase _kb;

    public KnowledgeHandler(IKnowledgeBase kb) => _kb = kb;

    public override IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
        CreateResponse request,
        ResponseContext context,
        CancellationToken cancellationToken)
    {
        return new TextResponse(context, request,
            createText: async ct =>
            {
                var question = await context.GetInputTextAsync(cancellationToken: ct);
                return await _kb.SearchAsync(question, ct);
            });
    }
}
```

## Test the endpoint

```bash
curl -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{"model":"knowledge","input":"What is Azure AI Foundry?"}' \
  --no-buffer
```

## When to use Tier 2

Use `AgentHost.CreateBuilder()` when you need to:
- **Compose multiple protocols** on a single host (Responses + Invocations)
- Use a **factory delegate** with full control over handler lifetime
- Override **shutdown timeout**, **port binding**, or **tracing** at the builder level
- Access the underlying `WebApplicationBuilder` for advanced configuration

For the simplest single-protocol experience, see [Tier 1 — Customize the One-Liner](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/samples/Sample7_Tier1HostingCustomize.md).
For adding agent endpoints to an existing app, see [Tier 3 — Self-Hosted](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/samples/Sample9_Tier3SelfHosting.md).
