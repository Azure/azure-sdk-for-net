# Sample 3: Tier 3 — Self-Hosted in an Existing ASP.NET App

This sample demonstrates the **Tier 3** developer experience: you own the HTTP host and use the protocol libraries directly. This is useful when you have an existing ASP.NET Core application and want to add Invocations protocol endpoints alongside your own routes.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Invocations --prerelease
```

## Add the Invocations protocol to your existing app

```C# Snippet:Hosting_Sample3_SelfHost
var builder = WebApplication.CreateBuilder();

// Your existing services.
builder.Services.AddSingleton<MyExistingService>();

// Register the Invocations SDK services and your handler.
builder.Services.AddInvocationsServer();
builder.Services.AddScoped<InvocationHandler, SummaryHandler>();

var app = builder.Build();

// Your existing endpoints.
app.MapGet("/", () => "My existing app");
app.MapGet("/healthy", () => Results.Ok());

// Map the Invocations protocol endpoints.
app.MapInvocationsServer();

app.Run();
```

## Implement the handler

This handler summarizes text — a simple but realistic agent task:

```C# Snippet:Hosting_Sample3_SummaryHandler
public class SummaryHandler : InvocationHandler
{
    public override async Task HandleAsync(
        HttpRequest request,
        HttpResponse response,
        InvocationContext context,
        CancellationToken cancellationToken)
    {
        var input = await request.ReadFromJsonAsync<SummaryInput>(cancellationToken);
        var text = input?.Text ?? "";

        // In a real agent, call a summarization model here.
        var summary = text.Length > 100
            ? text[..100] + "..."
            : text;

        await response.WriteAsJsonAsync(new
        {
            invocation_id = context.InvocationId,
            summary,
            original_length = text.Length
        }, cancellationToken);
    }
}

public record SummaryInput(string Text);
```

## Test the endpoint

Your existing routes and the Invocations endpoints coexist:

```bash
# Your existing route
curl http://localhost:5000/

# The Invocations endpoint
curl -X POST http://localhost:5000/invocations \
  -H "Content-Type: application/json" \
  -d '{"text":"Azure AI Agent Server is a platform for building hosted agents..."}'
```

## When to use Tier 3

Use `WebApplication.CreateBuilder()` + `AddInvocationsServer()` + `MapInvocationsServer()` when you:
- Have an **existing ASP.NET Core application** and want to add agent endpoints
- Need **full control** over middleware, DI, port binding, and health probes
- Want to use the protocol SDK without the opinionated Core framework
