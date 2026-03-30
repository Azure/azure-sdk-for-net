# Sample 7: Tier 3 — Self-Hosted in an Existing ASP.NET App

This sample demonstrates the **Tier 3** developer experience for the Invocations protocol: you own the HTTP host and use `AddInvocationsServer()` + `MapInvocationsServer()` to add Invocations API endpoints alongside your own routes. This is useful when you have an existing ASP.NET Core application and want to add agent endpoints without adopting the Core framework.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Invocations --prerelease
```

## Add the Invocations protocol to your existing app

```C# Snippet:Invocations_Sample7_SelfHost
var builder = WebApplication.CreateBuilder();

// Your existing services.
builder.Services.AddSingleton<ISummarizationService, OpenAISummarizationService>();

// Register the Invocations SDK services and your handler.
builder.Services.AddInvocationsServer();
builder.Services.AddScoped<InvocationHandler, SummarizationHandler>();

var app = builder.Build();

// Your existing endpoints.
app.MapGet("/", () => "My existing app");
app.MapGet("/readiness", () => Results.Ok());

// Map the Invocations protocol endpoints.
app.MapInvocationsServer();

app.Run();
```

## Implement the handler

```C# Snippet:Invocations_Sample7_SummarizationHandler
public class SummarizationHandler : InvocationHandler
{
    private readonly ISummarizationService _summarizer;

    public SummarizationHandler(ISummarizationService summarizer) => _summarizer = summarizer;

    public override async Task HandleAsync(
        HttpRequest request, HttpResponse response,
        InvocationContext context, CancellationToken cancellationToken)
    {
        var input = await new StreamReader(request.Body).ReadToEndAsync(cancellationToken);

        var summary = await _summarizer.SummarizeAsync(input, cancellationToken);

        response.ContentType = "application/json";
        await response.WriteAsJsonAsync(new
        {
            invocation_id = context.InvocationId,
            session_id = context.SessionId,
            summary
        }, cancellationToken);
    }
}
```

## Test the endpoints

Your existing routes and the Invocations endpoints coexist:

```bash
# Your existing route
curl http://localhost:5000/

# The Invocations endpoint
curl -X POST http://localhost:5000/invocations \
  -H "Content-Type: text/plain" \
  -d "Summarize the key benefits of Azure AI Foundry."
```

## When to use Tier 3

Use `WebApplication.CreateBuilder()` + `AddInvocationsServer()` + `MapInvocationsServer()` when you:
- Have an **existing ASP.NET Core application** and want to add agent endpoints
- Need **full control** over middleware, DI, port binding, and health probes
- Want to use the Invocations SDK without the opinionated Core framework

For the simplest single-protocol experience, see [Tier 1 — Customize the One-Liner](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/samples/Sample5_Tier1HostingCustomize.md).
For composition with the Core builder, see [Tier 2 — Builder](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/samples/Sample6_Tier2HostingBuilder.md).
