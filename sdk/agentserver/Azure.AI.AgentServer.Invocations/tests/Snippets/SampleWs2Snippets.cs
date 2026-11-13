// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Invocations;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Invocations.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Invocations SampleWs2_BidirectionalStreaming.md.
    /// Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class SampleWs2Snippets
    {
        [Test]
        public void StartServer()
        {
            #region Snippet:Invocations_SampleWs2_StartServer

            InvocationsServer.Run<BidirectionalStreamingHandler>();

            #endregion
        }

        [Test]
        public void Implement_BidirectionalStreamingHandler()
        {
            var handler = new BidirectionalStreamingHandler();
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Invocations_SampleWs2_BidirectionalStreamingHandler

        public class BidirectionalStreamingHandler : InvocationWebSocketHandler
        {
            private static readonly string[] SimulatedTokens =
            {
                "Once", " upon", " a", " time", ",", " in", " a", " land",
                " of", " full", "-", "duplex", " sockets", ",", " a", " server",
                " and", " a", " client", " spoke", " at", " the", " same", " time", "."
            };

            private static readonly TimeSpan TokenDelay = TimeSpan.FromMilliseconds(200);

            // HTTP /invocations — kept for parity with the other samples.
            // Overrides the InvocationWebSocketHandler default (404).
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

        #endregion
    }
}
