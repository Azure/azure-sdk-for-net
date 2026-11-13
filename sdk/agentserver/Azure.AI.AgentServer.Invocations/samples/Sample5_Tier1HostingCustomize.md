# Sample 5: Tier 1 — Customize the One-Liner

This sample shows the **customization surface** of `InvocationsServer.Run<THandler>()`. The one-line entry point accepts an optional `configure` callback that gives you access to the underlying `AgentHostBuilder`, so you can register services, read configuration, and add custom tracing — all while keeping the Tier 1 zero-config experience.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Invocations --prerelease
```

## Register custom services

Inject your own services into the handler via the `configure` callback:

```C# Snippet:Invocations_Sample5_CustomServices
InvocationsServer.Run<SummarizationHandler>(configure: builder =>
{
    builder.Services.AddSingleton<ISummarizationService, OpenAISummarizationService>();
});
```

The handler receives services through constructor injection:

```C# Snippet:Invocations_Sample5_SummarizationHandler
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

        // Use the injected service to produce the summary.
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

## Use a factory delegate for full control

When your handler needs constructor parameters that cannot be resolved through DI,
use the `Func<IServiceProvider, InvocationHandler>` overload for full control over
handler construction:

```C# Snippet:Invocations_Sample5_FactoryDelegate
InvocationsServer.Run(
    factory: sp =>
    {
        var summarizer = sp.GetRequiredService<ISummarizationService>();
        var maxTokens = int.Parse(
            sp.GetRequiredService<IConfiguration>()["MaxTokens"] ?? "1000");
        return new SummarizationHandler(summarizer) { MaxTokens = maxTokens };
    },
    configure: builder =>
    {
        builder.Services.AddSingleton<ISummarizationService, OpenAISummarizationService>();
    });
```

## Add configuration and tracing

Use the builder to read configuration, set a shutdown timeout, and add a custom tracing source:

```C# Snippet:Invocations_Sample5_ConfigAndTracing
InvocationsServer.Run<SummarizationHandler>(configure: builder =>
{
    // Register custom services.
    builder.Services.AddSingleton<ISummarizationService, OpenAISummarizationService>();

    // Read typed configuration from appsettings.json or environment variables.
    builder.Services.Configure<SummarizationOptions>(
        builder.Configuration.GetSection("Summarization"));

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

```C# Snippet:Invocations_Sample5_WebAppAccess
InvocationsServer.Run<SummarizationHandler>(configure: builder =>
{
    builder.Services.AddSingleton<ISummarizationService, OpenAISummarizationService>();

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
curl -X POST http://localhost:8088/invocations \
  -H "Content-Type: text/plain" \
  -d "Summarize the key benefits of Azure AI Foundry."
```

## When to use the configure callback

Use `InvocationsServer.Run<THandler>(configure: ...)` when you need:
- **Custom services** injected into your handler (databases, HTTP clients, AI model clients)
- **Typed configuration** from appsettings.json or environment variables
- **Custom tracing** sources for your business logic
- **ASP.NET Core customization** (CORS, authentication, middleware)

Use `InvocationsServer.Run(factory: ...)` when you need:
- **Full control** over handler construction with non-DI parameters
- **Runtime decisions** about which handler implementation to create

For more control, see [Tier 2 — Builder](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/samples/Sample6_Tier2HostingBuilder.md) and [Tier 3 — Self-Hosted](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/samples/Sample7_Tier3SelfHosting.md).
