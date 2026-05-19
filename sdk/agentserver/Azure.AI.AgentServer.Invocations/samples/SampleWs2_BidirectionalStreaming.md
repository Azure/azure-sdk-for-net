# Sample WS2: Bidirectional Streaming — Concurrent Token Streams over WebSocket

Unlike the request/reply echo in [Sample WS1](SampleWs1_Echo.md), this sample exercises the **full-duplex** nature of WebSocket: the server and the client send and receive on the same socket **concurrently and independently**.

The handler runs two responsibilities in parallel:

1. **Reader** — consumes inbound JSON frames (prompts and control messages) on the main loop and dispatches them. Multiple prompts may arrive while previous ones are still streaming.
2. **Per-prompt streamer** — one fire-and-forget task per prompt; streams generated tokens back at its own pace. Multiple generations can run in parallel and run *independently* of any inbound traffic. A `cancel` control message interrupts an in-flight stream mid-flight.

> **Keep-alive is not an application concern.** The SDK configures Kestrel to send WebSocket protocol-level Ping frames (RFC 6455 opcode `0x9`) every `WS_KEEPALIVE_INTERVAL` seconds. That is enough to survive upstream proxy / load-balancer idle timeouts without your handler having to push any application-level heartbeats of its own.

## Wire protocol (JSON over text frames)

Inbound (client → server):

```json
{"type":"prompt","id":"p1","text":"..."}
{"type":"cancel","id":"p1"}
{"type":"bye"}
```

Outbound (server → client):

```json
{"type":"ready"}                              ← sent on connect
{"type":"token","id":"p1","token":"..."}
{"type":"done","id":"p1"}
{"type":"cancelled","id":"p1"}
{"type":"error","id":"p1","message":"..."}
```

## Prerequisites

```dotnetcli
dotnet add package Azure.AI.AgentServer.Invocations --prerelease
```

## Implement the handler

```C# Snippet:Invocations_SampleWs2_BidirectionalStreamingHandler
public class BidirectionalStreamingHandler : InvocationHandler
{
    private static readonly string[] SimulatedTokens =
    {
        "Once", " upon", " a", " time", ",", " in", " a", " land",
        " of", " full", "-", "duplex", " sockets", ",", " a", " server",
        " and", " a", " client", " spoke", " at", " the", " same", " time", "."
    };

    private static readonly TimeSpan TokenDelay = TimeSpan.FromMilliseconds(200);

    // HTTP /invocations — kept for parity with the other samples.
    public override async Task HandleAsync(
        HttpRequest request, HttpResponse response,
        InvocationContext context, CancellationToken cancellationToken)
    {
        var payload = await new StreamReader(request.Body).ReadToEndAsync(cancellationToken);
        await response.WriteAsync($"{{\"echo\":\"{payload}\"}}", cancellationToken);
    }

    // /invocations_ws — true full-duplex streaming.
    public override async Task HandleWebSocketAsync(
        WebSocket webSocket,
        InvocationContext context,
        CancellationToken cancellationToken)
    {
        // Send the initial "ready" greeting before the read loop starts.
        await SendJsonAsync(webSocket, new { type = "ready" }, cancellationToken);

        // Per-prompt cancellation sources — keyed by client-supplied id.
        var prompts = new ConcurrentDictionary<string, CancellationTokenSource>();

        using var connectionCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

        var buffer = new byte[4096];
        while (webSocket.State == WebSocketState.Open && !connectionCts.IsCancellationRequested)
        {
            WebSocketReceiveResult received;
            try
            {
                received = await webSocket.ReceiveAsync(buffer, connectionCts.Token);
            }
            catch (OperationCanceledException)
            {
                break;
            }

            if (received.MessageType == WebSocketMessageType.Close)
            {
                break;
            }
            if (received.MessageType != WebSocketMessageType.Text || received.Count == 0)
            {
                continue;
            }

            var json = Encoding.UTF8.GetString(buffer, 0, received.Count);
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;
            if (!root.TryGetProperty("type", out var typeProp))
            {
                await SendErrorAsync(webSocket, id: null, message: "missing 'type' field", connectionCts.Token);
                continue;
            }

            switch (typeProp.GetString())
            {
                case "prompt":
                    if (!root.TryGetProperty("id", out var idProp) ||
                        !root.TryGetProperty("text", out var textProp))
                    {
                        await SendErrorAsync(webSocket, id: null, message: "prompt requires 'id' and 'text'", connectionCts.Token);
                        continue;
                    }

                    var id = idProp.GetString() ?? Guid.NewGuid().ToString("N");
                    var text = textProp.GetString() ?? string.Empty;

                    // Spawn the generation task; the read loop continues serving
                    // new prompts and cancel messages in parallel — this is the
                    // defining property of full-duplex.
                    var perPromptCts = CancellationTokenSource.CreateLinkedTokenSource(connectionCts.Token);
                    prompts[id] = perPromptCts;
                    _ = StreamTokensAsync(webSocket, id, text, perPromptCts.Token)
                        .ContinueWith(t => prompts.TryRemove(id, out _), TaskScheduler.Default);
                    break;

                case "cancel":
                    if (root.TryGetProperty("id", out var cancelIdProp) &&
                        prompts.TryRemove(cancelIdProp.GetString() ?? string.Empty, out var cts))
                    {
                        cts.Cancel();
                    }
                    break;

                case "bye":
                    // Graceful client-initiated shutdown — exit the read loop.
                    connectionCts.Cancel();
                    break;

                default:
                    await SendErrorAsync(webSocket, id: null,
                        message: $"unknown type: {typeProp.GetString()}", connectionCts.Token);
                    break;
            }
        }

        // Drain in-flight prompts so we don't leak background tasks.
        foreach (var cts in prompts.Values)
        {
            cts.Cancel();
        }
    }

    private async Task StreamTokensAsync(
        WebSocket webSocket, string id, string text, CancellationToken cancellationToken)
    {
        try
        {
            foreach (var token in SimulatedTokens)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await SendJsonAsync(webSocket,
                    new { type = "token", id, token },
                    cancellationToken);
                await Task.Delay(TokenDelay, cancellationToken);
            }
            await SendJsonAsync(webSocket, new { type = "done", id }, cancellationToken);
        }
        catch (OperationCanceledException)
        {
            // Cancellation is reported as a separate frame so the client
            // can distinguish completion from interruption.
            try
            {
                await SendJsonAsync(webSocket, new { type = "cancelled", id }, CancellationToken.None);
            }
            catch
            {
                // Socket may already be gone — nothing to recover here.
            }
        }
        catch (Exception ex)
        {
            try
            {
                await SendErrorAsync(webSocket, id, ex.Message, CancellationToken.None);
            }
            catch
            {
                // Same — best-effort error reporting only.
            }
        }
    }

    private static Task SendJsonAsync<T>(WebSocket webSocket, T payload, CancellationToken cancellationToken)
    {
        var json = JsonSerializer.SerializeToUtf8Bytes(payload);
        return webSocket.SendAsync(
            json, WebSocketMessageType.Text, endOfMessage: true, cancellationToken);
    }

    private static Task SendErrorAsync(
        WebSocket webSocket, string? id, string message, CancellationToken cancellationToken)
        => SendJsonAsync(webSocket, new { type = "error", id, message }, cancellationToken);
}
```

## Start the server

```C# Snippet:Invocations_SampleWs2_StartServer
InvocationsServer.Run<BidirectionalStreamingHandler>();
```

## Drive it from a client

Using [`websocat`](https://github.com/vi/websocat) the server keeps streaming tokens for each prompt while you type the next one:

```bash
websocat ws://localhost:8088/invocations_ws
< {"type":"ready"}
> {"type":"prompt","id":"p1","text":"Tell me a story"}
< {"type":"token","id":"p1","token":"Once"}
< {"type":"token","id":"p1","token":" upon"}
> {"type":"prompt","id":"p2","text":"And another"}          ← starts before p1 finishes
< {"type":"token","id":"p2","token":"Once"}                 ← p2 begins streaming in parallel
< {"type":"token","id":"p1","token":" a"}
> {"type":"cancel","id":"p1"}
< {"type":"cancelled","id":"p1"}
< {"type":"token","id":"p2","token":" upon"}
< {"type":"done","id":"p2"}
> {"type":"bye"}
```

## Implementation notes

- **Read loop never blocks the streamer.** The streamer runs on a separately scheduled `Task` (the `_ = StreamTokensAsync(...)` discard). The read loop returns immediately so the next prompt or `cancel` is dispatched without waiting for the previous generation to finish.
- **Per-prompt cancellation.** Each streamer gets a `CancellationTokenSource` linked to the connection-level CTS. The handler keeps a `ConcurrentDictionary<string, CancellationTokenSource>` keyed by client-supplied prompt id so a `cancel` message can interrupt a single in-flight stream without affecting the others.
- **Graceful shutdown.** On `{"type":"bye"}` the handler cancels the connection-level CTS, breaks the read loop, drains any remaining streamers (their linked tokens inherit the cancel), and returns — the SDK then sends RFC 6455 close code `1000` (`NormalClosure`).
- **No application-level heartbeat.** Set `WS_KEEPALIVE_INTERVAL=30` in your container env to have Kestrel emit RFC 6455 Ping frames every 30 s. Idle connections stay alive across upstream proxy / load-balancer idle timeouts without any application traffic.
- **Concurrent writes.** `ClientWebSocket.SendAsync` is documented as "one send at a time" — `BidirectionalStreamingHandler` enforces this naturally because all writes (from the read loop and from the streamers) are serialised onto the same `WebSocket` via the framework's per-socket lock. For higher fan-out, gate writes through a `Channel<T>` or `SemaphoreSlim`.

## Configuration

| Environment variable | Default | Description |
|---|---|---|
| `WS_KEEPALIVE_INTERVAL` | unset → disabled | Integer seconds between RFC 6455 protocol-level Ping frames. `30` is a comfortable default for connections behind an idle-timeout-aware intermediary. |
