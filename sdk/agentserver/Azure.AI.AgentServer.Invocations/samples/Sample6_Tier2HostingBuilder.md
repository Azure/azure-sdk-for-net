# Sample 6: Tier 2 — Builder with Full Control

This sample demonstrates the **Tier 2** developer experience for the Invocations protocol: use `AgentHost.CreateBuilder()` to get full control over service registration, handler construction, configuration, and tracing while still leveraging the Core framework infrastructure.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Invocations --prerelease
```

## Use the builder with a generic handler type

Register your handler type on the builder and let the DI container construct it:

```C# Snippet:Invocations_Sample6_BuilderGeneric
var builder = AgentHost.CreateBuilder();

// Register services that the handler depends on.
builder.Services.AddSingleton<ISummarizationService, OpenAISummarizationService>();

// Register the Invocations protocol with a concrete handler type.
builder.AddInvocations<SummarizationHandler>();

var app = builder.Build();
app.Run();
```

## Use the builder with a factory delegate

When you need full control over handler construction — for example, to set
properties that aren't part of the DI graph — use the factory overload:

```C# Snippet:Invocations_Sample6_BuilderWithFactory
var builder = AgentHost.CreateBuilder();

// Register services on the builder.
builder.Services.AddSingleton<ISummarizationService, OpenAISummarizationService>();

// Use a factory delegate for handler construction.
builder.AddInvocations(factory: sp =>
{
    var summarizer = sp.GetRequiredService<ISummarizationService>();
    return new SummarizationHandler(summarizer) { MaxTokens = 2000 };
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

```C# Snippet:Invocations_Sample6_SummarizationHandler
public class SummarizationHandler : InvocationHandler
{
    private readonly ISummarizationService _summarizer;

    public SummarizationHandler(ISummarizationService summarizer) => _summarizer = summarizer;

    public int MaxTokens { get; set; } = 1000;

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

## Test the endpoint

```bash
curl -X POST http://localhost:8088/invocations \
  -H "Content-Type: text/plain" \
  -d "Summarize the key benefits of Azure AI Foundry."
```

## When to use Tier 2

Use `AgentHost.CreateBuilder()` when you need to:
- **Compose multiple protocols** on a single host (Responses + Invocations)
- Use a **factory delegate** with full control over handler lifetime
- Override **shutdown timeout**, **port binding**, or **tracing** at the builder level
- Access the underlying `WebApplicationBuilder` for advanced configuration

For the simplest single-protocol experience, see [Tier 1 — Customize the One-Liner](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/samples/Sample5_Tier1HostingCustomize.md).
For adding agent endpoints to an existing app, see [Tier 3 — Self-Hosted](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/samples/Sample7_Tier3SelfHosting.md).
