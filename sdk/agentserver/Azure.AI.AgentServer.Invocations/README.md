# Azure AI Agent Server Invocations library for .NET

Azure.AI.AgentServer.Invocations is a .NET library for building ASP.NET Core servers that implement the Azure AI Invocations protocol. Subclass `InvocationHandler`, register it with the hosting builder, and the library handles routing, session resolution, client header forwarding, and invocation lifecycle management.

[Source code][source] | [Package (NuGet)][nuget] | [Product documentation][product_doc]

## Getting started

### Install the package

Install the library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.AI.AgentServer.Invocations --prerelease
```

### Prerequisites

- An [Azure subscription](https://azure.microsoft.com/free/dotnet/)
- [.NET 8](https://dotnet.microsoft.com/download) or later
- The `Azure.AI.AgentServer.Core` package (installed automatically as a dependency)

### Configure the server

The fastest way to get running:

```C# Snippet:Invocations_ReadMe_Tier1
InvocationsServer.Run<EchoHandler>();
```

Where `EchoHandler` implements the Invocations protocol:

```C# Snippet:Invocations_ReadMe_EchoHandler
public class EchoHandler : InvocationHandler
{
    public override async Task HandleAsync(
        HttpRequest request, HttpResponse response,
        InvocationContext context, CancellationToken cancellationToken)
    {
        var input = await new StreamReader(request.Body).ReadToEndAsync(cancellationToken);
        await response.WriteAsync($"You said: {input}", cancellationToken);
    }
}
```

Alternatively, use `AgentHost.CreateBuilder()` for more control over service registration and middleware:

```C# Snippet:Invocations_ReadMe_ManualSetup
var builder = AgentHost.CreateBuilder();
builder.AddInvocations<EchoHandler>();
builder.Build().Run();
```

For more control over the host (adding services, configuring middleware, composing multiple protocols), see [Customizing the host](#customizing-the-host) below.

## Key concepts

### InvocationHandler

The abstract base class you subclass for HTTP-only handlers. Only `HandleAsync` is abstract — the remaining operations (`GetAsync`, `CancelAsync`, `GetOpenApiAsync`) return 404 by default and can be overridden as needed.

### InvocationWebSocketHandler

Derives from `InvocationHandler` and adds the abstract `HandleWebSocketAsync` method for the `/invocations_ws` endpoint. The inherited `HandleAsync` returns 404 by default, so a WebSocket-only handler does not need to implement `HandleAsync` — multi-protocol handlers override both. See the [WebSocket protocol section](#websocket-protocol-invocations_ws) below.

### InvocationContext

Provides request metadata to the handler. All properties are read-only and resolved before `HandleAsync` is called.

| Property | Type | Description |
|----------|------|-------------|
| `InvocationId` | `string` | Unique identifier for this invocation. Passed as the first argument to `GetAsync` and `CancelAsync`. Use as a key when storing per-invocation state. |
| `SessionId` | `string` | Resolved multi-turn session identifier. For `POST /invocations`, resolved from the `agent_session_id` query parameter, `FOUNDRY_AGENT_SESSION_ID` env var, or a generated UUID — in that order. For `GET` and `Cancel`, the query parameter is not used; the value comes from the env var or a generated UUID. |
| `ClientHeaders` | `IReadOnlyDictionary<string, string>` | Forwarded `x-client-*` headers from the original request — useful for propagating tracing context and client metadata. |
| `QueryParameters` | `IReadOnlyDictionary<string, StringValues>` | All query parameters from the incoming request. Per the invocation protocol spec, all query parameters are forwarded unchanged. |
| `PlatformContext` | `PlatformContext` | Platform context extracted from the `x-agent-user-id` and `x-agent-foundry-call-id` headers. Useful for multi-tenant scenarios where per-user data must be partitioned and the per-request call ID forwarded to 1P services. `PlatformContext.Empty` indicates no platform headers were present. |

### Customizing the host

When you need to add services, configure middleware, or compose multiple protocols on a single host, see the hosting tier samples:
- [Tier 1 hosting customization](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/samples/Sample5_Tier1HostingCustomize.md)
- [Tier 2 builder](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/samples/Sample6_Tier2HostingBuilder.md)
- [Tier 3 self-hosting](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/samples/Sample7_Tier3SelfHosting.md)

`InvocationsServerOptions` can be configured via the `AddInvocationsServer(options => { ... })` delegate on any tier. See the [Tier 3 self-hosting](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/samples/Sample7_Tier3SelfHosting.md) sample for a complete example.

### Handler lifetime

Handlers registered via `AddInvocations<THandler>()` or `InvocationsServer.Run<THandler>()` are resolved per request by default (scoped lifetime). Instance fields on your `InvocationHandler` subclass will not persist across requests. Store long-lived state in separate services or storage keyed by `InvocationContext.SessionId` or `InvocationContext.InvocationId`, or register a singleton handler explicitly if you require a single shared instance.

### WebSocket protocol (`invocations_ws`)

The same host that serves `POST /invocations` also exposes a WebSocket transport at `/invocations_ws`. Container authors do not install or import a second package — derive from `InvocationWebSocketHandler` and override `HandleWebSocketAsync`. The inherited `HandleAsync` returns 404 by default, so a WebSocket-only agent has no boilerplate; override `HandleAsync` too when you want HTTP and WebSocket on the same handler.

```C# Snippet:Invocations_ReadMe_WebSocketHandler
public class WebSocketEchoHandler : InvocationWebSocketHandler
{
    public override async Task HandleWebSocketAsync(
        WebSocket webSocket, InvocationContext context, CancellationToken cancellationToken)
    {
        var buffer = new byte[4096];
        while (webSocket.State == WebSocketState.Open && !cancellationToken.IsCancellationRequested)
        {
            var received = await webSocket.ReceiveAsync(buffer, cancellationToken);
            if (received.MessageType == WebSocketMessageType.Close)
            {
                break;
            }
            await webSocket.SendAsync(
                new ArraySegment<byte>(buffer, 0, received.Count),
                received.MessageType,
                received.EndOfMessage,
                cancellationToken);
        }
    }
}
```

What the SDK does for you when the registered handler derives from `InvocationWebSocketHandler`:

- Registers the `/invocations_ws` route on the same host as `/invocations` and `/readiness`.
- Calls `AcceptWebSocketAsync` before invoking your handler.
- Sends an RFC 6455 protocol-level Ping frame (opcode `0x9`) every `WS_KEEPALIVE_INTERVAL` seconds when the env var is set — Kestrel does this for us via `WebSocketOptions.KeepAliveInterval`, so the connection stays alive across upstream proxy / load-balancer idle timeouts without any extra application traffic. Disabled by default.
- Closes the connection cleanly on handler return (close code `1000` — `NormalClosure`) or maps an uncaught handler exception to close code `1011` (`InternalServerError`). Handler-initiated close codes are preserved unchanged.
- Emits a structured close-event log line carrying `session_id`, `close_code`, and `duration_ms`. No framework-level OpenTelemetry span is created for the connection — ASP.NET Core auto-propagates the inbound W3C trace context, so any spans your handler starts are parented correctly without a per-connection wrapper.
- When the registered handler is a plain `InvocationHandler` (not an `InvocationWebSocketHandler`), an upgrade attempt receives HTTP `404 Not Found` — the WS endpoint short-circuits with "endpoint not registered" semantics so a missing handler fails fast instead of accepting and immediately closing.

The session ID honours `FOUNDRY_AGENT_SESSION_ID` (matching the HTTP `POST /invocations` precedence, minus the query-param override which has no ergonomic equivalent on a long-lived WS connection), falling back to a generated UUID. Both transports on the same container therefore report the same session ID.

#### WebSocket configuration

| Environment variable | Default | Description |
|---|---|---|
| `WS_KEEPALIVE_INTERVAL` | unset → disabled | Integer seconds between RFC 6455 Ping frames. `0` (or unset) disables protocol-level keep-alive. |

## Examples

You can familiarise yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/samples).

## Troubleshooting

### Common errors

- **404 on invocation endpoint**: Ensure your handler is registered via `AddInvocations<THandler>()` on the builder. If you registered on `IServiceCollection` directly without mapping endpoints, the routes will not be created.
- **Handler not found**: The Invocations protocol requires `Azure.AI.AgentServer.Core` for the underlying host. If you see startup errors, verify that you are using `AgentHost.CreateBuilder()` or `InvocationsServer.Run<THandler>()`.

### Logging

The library emits OpenTelemetry traces via the `Azure.AI.AgentServer.Invocations` activity source. Enable ASP.NET Core logging in your application configuration to diagnose request routing issues.

## Next steps

- [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/samples) — Getting started, custom operations
- [Azure.AI.AgentServer.Core](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Core) — Shared hosting foundation
- [Azure.AI.AgentServer.Responses](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Responses) — Responses protocol implementation

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/src
[nuget]: https://www.nuget.org/packages/Azure.AI.AgentServer.Invocations
[product_doc]: https://learn.microsoft.com/azure/foundry/agents/concepts/hosted-agents
