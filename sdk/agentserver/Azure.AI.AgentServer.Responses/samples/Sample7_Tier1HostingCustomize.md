# Sample 7: Tier 1 — Customize the One-Liner

This sample shows the **customization surface** of `ResponsesServer.Run<THandler>()`. The one-line entry point accepts an optional `configure` callback that gives you access to the underlying `AgentHostBuilder`, so you can register services, read configuration, and add custom tracing — all while keeping the Tier 1 zero-config experience.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Responses --prerelease
```

## Register custom services

Inject your own services into the handler via the `configure` callback:

```C# Snippet:Responses_Sample7_CustomServices
ResponsesServer.Run<KnowledgeHandler>(configure: builder =>
{
    builder.Services.AddSingleton<IKnowledgeBase, WikiKnowledgeBase>();
});
```

The handler receives services through constructor injection:

```C# Snippet:Responses_Sample7_KnowledgeHandler
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

## Use a factory delegate for full control

When your handler needs constructor parameters that cannot be resolved through DI,
use the `Func<IServiceProvider, ResponseHandler>` overload for full control over
handler construction:

```C# Snippet:Responses_Sample7_FactoryDelegate
ResponsesServer.Run(
    factory: sp =>
    {
        var kb = sp.GetRequiredService<IKnowledgeBase>();
        return new KnowledgeHandler(kb);
    },
    configure: builder =>
    {
        builder.Services.AddSingleton<IKnowledgeBase, WikiKnowledgeBase>();
    });
```

## Add configuration and tracing

Use the builder to read configuration, set a shutdown timeout, and add a custom tracing source:

```C# Snippet:Responses_Sample7_ConfigAndTracing
ResponsesServer.Run<KnowledgeHandler>(configure: builder =>
{
    // Register custom services.
    builder.Services.AddSingleton<IKnowledgeBase, WikiKnowledgeBase>();

    // Read typed configuration from appsettings.json or environment variables.
    builder.Services.Configure<KnowledgeBaseOptions>(
        builder.Configuration.GetSection("KnowledgeBase"));

    // Add a custom OpenTelemetry tracing source.
    builder.ConfigureTracing(tracing =>
    {
        tracing.AddSource("MyAgent.BusinessLogic");
    });

    // Set a custom shutdown timeout (default is 30s).
    builder.ConfigureShutdown(TimeSpan.FromSeconds(10));
});
```

## Access the underlying WebApplication

For advanced scenarios, use `builder.WebApplicationBuilder` to configure middleware,
authentication, or CORS at the ASP.NET Core level:

```C# Snippet:Responses_Sample7_WebAppAccess
ResponsesServer.Run<KnowledgeHandler>(configure: builder =>
{
    builder.Services.AddSingleton<IKnowledgeBase, WikiKnowledgeBase>();

    // Add CORS support at the ASP.NET Core level.
    builder.WebApplicationBuilder.Services.AddCors(cors =>
    {
        cors.AddDefaultPolicy(policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
    });
});
```

## Test the endpoint

```bash
curl -X POST http://localhost:8088/responses \
  -H "Content-Type: application/json" \
  -d '{"model":"knowledge","input":"What is Azure AI Foundry?"}' \
  --no-buffer
```

## When to use the configure callback

Use `ResponsesServer.Run<THandler>(configure: ...)` when you need:
- **Custom services** injected into your handler (databases, HTTP clients, AI model clients)
- **Typed configuration** from appsettings.json or environment variables
- **Custom tracing** sources for your business logic
- **ASP.NET Core customization** (CORS, authentication, middleware)

Use `ResponsesServer.Run(factory: ...)` when you need:
- **Full control** over handler construction with non-DI parameters
- **Runtime decisions** about which handler implementation to create

For more control, see [Tier 2 — Builder](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/samples/Sample8_Tier2HostingBuilder.md) and [Tier 3 — Self-Hosted](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Responses/samples/Sample9_Tier3SelfHosting.md).
