````markdown
# Sample 5: Tier 1 Customization — Services, Configuration, and Tracing

This sample shows the **customization surface** of `ResponsesServer.Run<THandler>()`. The one-line entry point accepts an optional `configure` callback that gives you access to the underlying `AgentHostBuilder`, so you can register services, read configuration, and add custom tracing — all while keeping the Tier 1 zero-config experience.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Responses --prerelease
```

## Register custom services

Inject your own services into the handler via the `configure` callback:

```C# Snippet:Responses_Sample5_CustomServices
ResponsesServer.Run<KnowledgeHandler>(configure: builder =>
{
    builder.Services.AddSingleton<IKnowledgeBase, WikiKnowledgeBase>();
});
```

The handler receives services through constructor injection:

```C# Snippet:Responses_Sample5_KnowledgeHandler
public class KnowledgeHandler : IResponseHandler
{
    private readonly IKnowledgeBase _kb;

    public KnowledgeHandler(IKnowledgeBase kb) => _kb = kb;

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

        // Use the injected service to produce the answer.
        var question = request.GetInputText();
        var answer = await _kb.SearchAsync(question, cancellationToken);

        yield return text.EmitDelta(answer);
        yield return text.EmitDone(answer);

        yield return message.EmitContentDone(text);
        yield return message.EmitDone();
        yield return stream.EmitCompleted();
    }
}
```

## Add configuration and tracing

Use the builder to read configuration, set a shutdown timeout, and add a custom tracing source:

```C# Snippet:Responses_Sample5_ConfigAndTracing
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

```C# Snippet:Responses_Sample5_WebAppAccess
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

If you need to compose **multiple protocols** (Responses + Invocations), go to Tier 2 with `AgentHost.CreateBuilder()`.

````