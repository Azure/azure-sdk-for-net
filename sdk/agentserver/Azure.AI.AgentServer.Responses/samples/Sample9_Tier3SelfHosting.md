# Sample 9: Tier 3 — Self-Hosted in an Existing ASP.NET App

This sample demonstrates the **Tier 3** developer experience for the Responses protocol: you own the HTTP host and use `AddResponsesServer()` + `MapResponsesServer()` to add Responses API endpoints alongside your own routes. This is useful when you have an existing ASP.NET Core application and want to add agent endpoints without adopting the Core framework.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Responses --prerelease
```

## Add the Responses protocol to your existing app

```C# Snippet:Responses_Sample9_SelfHost
var builder = WebApplication.CreateBuilder();

// Your existing services.
builder.Services.AddSingleton<IKnowledgeBase, WikiKnowledgeBase>();

// Register the Responses SDK services and your handler.
builder.Services.AddResponsesServer();
builder.Services.AddScoped<ResponseHandler, KnowledgeHandler>();

var app = builder.Build();

// Your existing endpoints.
app.MapGet("/", () => "My existing app");
app.MapGet("/readiness", () => Results.Ok());

// Map the Responses protocol endpoints.
app.MapResponsesServer();

app.Run();
```

## Implement the handler

```C# Snippet:Responses_Sample9_KnowledgeHandler
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

## Test the endpoints

Your existing routes and the Responses endpoints coexist:

```bash
# Your existing route
curl http://localhost:5000/

# The Responses endpoint
curl -X POST http://localhost:5000/responses \
  -H "Content-Type: application/json" \
  -d '{"model":"knowledge","input":"What is Azure AI Foundry?"}' \
  --no-buffer
```

## When to use Tier 3

Use `WebApplication.CreateBuilder()` + `AddResponsesServer()` + `MapResponsesServer()` when you:
- Have an **existing ASP.NET Core application** and want to add agent endpoints
- Need **full control** over middleware, DI, port binding, and health probes
- Want to use the Responses SDK without the opinionated Core framework

For the simplest single-protocol experience, see [Tier 1 — Customize the One-Liner](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/samples/Sample7_Tier1HostingCustomize.md).
For composition with the Core builder, see [Tier 2 — Builder](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/samples/Sample8_Tier2HostingBuilder.md).
