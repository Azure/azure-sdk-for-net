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

// Core middleware: x-request-id correlation, x-platform-server header, request logging.
builder.Services.AddAgentServerCore();

// Invocations protocol: services and handler.
builder.Services.AddInvocationsServer();
builder.Services.AddScoped<InvocationHandler, SummarizationHandler>();

// Health probe.
builder.Services.AddHealthChecks();

// Observability: Microsoft OpenTelemetry distro with traces and metrics.
// Auto-detects Azure Monitor (APPLICATIONINSIGHTS_CONNECTION_STRING) and
// OTLP (OTEL_EXPORTER_OTLP_ENDPOINT) exporters from environment variables.
var otel = builder.Services.AddOpenTelemetry();
otel.UseMicrosoftOpenTelemetry(options => { });
otel.WithTracing(tracing =>
    {
        tracing.AddSource("Azure.AI.AgentServer.Invocations");
    })
    .WithMetrics(metrics =>
    {
        metrics.AddMeter("Azure.AI.AgentServer.Invocations");
    });

var app = builder.Build();

// Core middleware pipeline.
app.UseAgentServerCore();

// Health probe endpoint.
app.MapHealthChecks("/readiness");

// Your existing endpoints.
app.MapGet("/", () => "My existing app");

// Invocations protocol endpoints.
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

## Protect a self-hosted application

> **Warning:** The preceding minimal example does not configure authentication. The
> library trusts `x-agent-*` headers as supplied; they do not authenticate callers.
> Before exposing these endpoints, authenticate and authorize requests and remove or
> replace caller-supplied platform identity headers. See
> [Self-hosting and trusted headers](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Core/README.md#self-hosting-and-trusted-headers).

Use your application's existing authentication scheme and identity provider. The
following cookie-based example assumes the application already has a trusted sign-in
flow. It returns HTTP 401 instead of redirecting unauthenticated API requests.
Replace the earlier `AddInvocationsServer()` registration with:

```C# Snippet:Invocations_Sample7_AuthenticatedServices
// Use the application's existing authentication scheme in production.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Events.OnRedirectToLogin = context =>
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        };
    });
builder.Services.AddAuthorization();
builder.Services.AddInvocationsServer(options =>
{
    options.AllowedWebSocketOrigins.Add("https://client.example");
});
```

Replace, rather than append to, the earlier `UseAgentServerCore()` and
`MapInvocationsServer()` calls with the following ordered pipeline. Authenticate first,
then run your application's trusted-header normalization and lifecycle-path guard
**before** Core captures request headers. Endpoint authorization runs after Core and
protects the mapped Invocations routes.

The snippet marks the insertion point for that host-specific middleware; it does not
implement normalization or lifecycle authorization. Insert those checks there, or
ensure a trusted proxy establishes platform header values from authenticated identity
and blocks untrusted lifecycle requests before forwarding to the application. Keep the
separate health probe and other application route mappings from the earlier example.

```C# Snippet:Invocations_Sample7_AuthenticatedEndpoints
app.UseAuthentication();

// Insert trusted-header normalization and a lifecycle-path guard here
// unless a trusted proxy already enforces both.
app.UseAgentServerCore();

app.UseAuthorization();
app.MapInvocationsServer().RequireAuthorization();
```

`RequireAuthorization()` protects the entire route group, including HTTP invocations,
documentation endpoints, `/invocations_ws`, and the typed Voice
`/voice_conversation_engine` route when registered. If authentication is handled by
an upstream proxy instead, restrict host ingress so clients cannot bypass the proxy.
Configure authorization policies appropriate for the application; authentication alone
does not validate a caller-supplied `x-agent-user-id`.

### Lifecycle and health paths

`UseAgentServerCore()` handles POST requests to `/_agent/before-snapshot`,
`/_before_snapshot`, `/_agent/after-restore`, and `/_after_restore` in middleware,
before endpoint routing dispatch. They are not part of the Invocations route group:
its `RequireAuthorization()` does not protect them. The pipeline above also places
`UseAuthorization()` after Core, so a fallback policy there does not protect lifecycle
requests either. Block all four lifecycle paths at untrusted ingress, or insert
authentication/authorization or reject middleware at the marked point before Core.
Allow lifecycle requests only from trusted platform infrastructure.

`/readiness` is a separately mapped health probe, intentionally open by default; the
Invocations authorization requirement does not cover it. Preserve access for intended
health probes when applying broader restrictions.

This middleware ordering is available directly in **Tier 3**. Tier 1 and Tier 2 hosts
install `UseAgentServerCore()` inside `AgentHostBuilder.Build()`; middleware added to the
returned application is too late to normalize headers before Core captures them.
For those hosts, register an ASP.NET Core `IStartupFilter` that prepends authentication,
trusted-header normalization, and any lifecycle guard, or enforce normalization and
lifecycle restrictions in a trusted proxy that clients cannot bypass.

### WebSocket origin validation

`InvocationsServerOptions.AllowedWebSocketOrigins` applies to the Invocations WebSocket
routes, including the typed Voice route. Configure it through `AddInvocationsServer`,
`AddInvocations`, or `AddVoice` before starting the host.

- The empty default list disables origin validation, preserving existing clients.
- A nonempty list permits only a single, valid HTTP or HTTPS `Origin` whose scheme,
  host, and effective port match an entry. Scheme and host are case-insensitive;
  omitted default ports match explicit `:80` for HTTP or `:443` for HTTPS.
- Use origins such as `https://client.example` or `http://localhost:5000`, without
  paths, a trailing slash, credentials, query strings, or fragments. Wildcards and
  substring matches are not supported. Invalid entries never match.
- Invalid, multiple, or unlisted origins receive HTTP 403 before WebSocket acceptance.
- Requests **without** `Origin` remain allowed for server-to-server compatibility,
  even when a list is configured. This is not authentication, and does not replace
  authorization, TLS, or browser HTTP endpoint protections such as antiforgery.

## Test the endpoints

For the local, unauthenticated minimal example, your existing routes and the Invocations
endpoints coexist. With authorization enabled, use your application's authenticated client:

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
