# Sample WS1: WebSocket Echo — HTTP and WebSocket on the Same Host

A single `InvocationHandler` can serve **both** the HTTP `POST /invocations` endpoint and the WebSocket `/invocations_ws` endpoint. Multi-protocol agents share one host, one session, and one process — no second package and no separate server to manage.

This sample wires a minimal echo handler that responds to both transports.

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Invocations --prerelease
```

## Implement the handler

```C# Snippet:Invocations_SampleWs1_EchoAgentHandler
public class EchoAgentHandler : InvocationHandler
{
    // POST /invocations — classic request/response echo.
    public override async Task HandleAsync(
        HttpRequest request,
        HttpResponse response,
        InvocationContext context,
        CancellationToken cancellationToken)
    {
        var input = await new StreamReader(request.Body).ReadToEndAsync(cancellationToken);
        await response.WriteAsync($"You said: {input}", cancellationToken);
    }

    // /invocations_ws — full-duplex echo. The SDK has already accepted
    // the upgrade; the handler owns the connection until it returns.
    public override async Task HandleWebSocketAsync(
        WebSocket webSocket,
        InvocationContext context,
        CancellationToken cancellationToken)
    {
        var buffer = new byte[4096];
        while (webSocket.State == WebSocketState.Open && !cancellationToken.IsCancellationRequested)
        {
            var received = await webSocket.ReceiveAsync(buffer, cancellationToken);

            if (received.MessageType == WebSocketMessageType.Close)
            {
                // Client initiated close — exit the loop and let the SDK
                // send the close frame back with NormalClosure (1000).
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

## Start the server

```C# Snippet:Invocations_SampleWs1_StartServer
InvocationsServer.Run<EchoAgentHandler>();
```

## Test the HTTP endpoint

```bash
curl -X POST http://localhost:8088/invocations \
  -H "Content-Type: text/plain" \
  -d "Hello over HTTP"
```

Response: `You said: Hello over HTTP`

## Test the WebSocket endpoint

The simplest way is the [`websocat`](https://github.com/vi/websocat) CLI:

```bash
websocat ws://localhost:8088/invocations_ws
> hello over websocket
hello over websocket            # ← server echo
> goodbye
goodbye
> ^D                            # client closes; server replies with code 1000
```

Or from a browser console:

```javascript
const ws = new WebSocket("ws://localhost:8088/invocations_ws");
ws.onmessage = (e) => console.log("echo:", e.data);
ws.onopen    = () => ws.send("hello from the browser");
```

## What the SDK does for you

- **Lazy route registration.** The `/invocations_ws` route is only active when the handler overrides `HandleWebSocketAsync`. Handlers that don't (Samples 1–7) return HTTP `404 Not Found` for upgrade attempts.
- **Accept the upgrade.** The SDK calls `AcceptWebSocketAsync` before invoking your handler — you receive an already-open `WebSocket`.
- **Map exit codes.** A clean return maps to RFC 6455 close code `1000` (`NormalClosure`); an uncaught handler exception maps to `1011` (`InternalServerError`). Handler-initiated `CloseAsync` codes are preserved unchanged.
- **Honour `FOUNDRY_AGENT_SESSION_ID`.** The session ID injected by the Foundry hosting platform is reused so HTTP and WS turns on the same container correlate to the same session. A fresh UUID is used when the env var is unset (local dev).
- **Emit a close-event log line.** A single structured log record is emitted at the end of every connection with `azure.ai.agentserver.invocations_ws.{session_id, close_code, duration_ms}` for log/trace correlation.

## Configuration

| Environment variable | Default | Description |
|---|---|---|
| `WS_KEEPALIVE_INTERVAL` | unset → disabled | Integer seconds between RFC 6455 protocol-level Ping frames. Set to a small positive value (e.g. `30`) to survive upstream proxy / load-balancer idle timeouts on quiet connections. |

## Next

See [Sample WS2 — Bidirectional Streaming](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/agentserver/Azure.AI.AgentServer.Invocations/samples/SampleWs2_BidirectionalStreaming.md) for a real full-duplex scenario where the server pushes tokens concurrently with reading client control messages.
