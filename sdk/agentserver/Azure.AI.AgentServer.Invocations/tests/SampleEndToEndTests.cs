// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Invocations.Tests.Snippets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OpenAI;
using OpenAI.Responses;

#pragma warning disable OPENAI001 // The OpenAI Responses API is experimental.

namespace Azure.AI.AgentServer.Invocations.Tests;

/// <summary>
/// End-to-end tests that validate every Invocations sample handler (Samples 1–7)
/// works correctly when wired into a real ASP.NET Core test server. Each test
/// registers the actual handler class from the sample snippets, sends an HTTP
/// request, and asserts on the response content.
/// </summary>
[TestFixture]
public class SampleEndToEndTests
{
    // ═══════════════════════════════════════════════════════════════════
    //  Sample 1: Echo Handler — basic POST /invocations
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Sample1_EchoHandler_EchoesInput()
    {
        await using var env = await CreateTestServerAsync<Sample1Snippets.EchoHandler>();

        var response = await env.Client.PostAsync("/invocations",
            new StringContent("Hello from test", Encoding.UTF8));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await response.Content.ReadAsStringAsync();
        Assert.That(body, Is.EqualTo("You said: Hello from test"));
    }

    [Test]
    public async Task Sample1_EchoHandler_ReturnsInvocationIdHeader()
    {
        await using var env = await CreateTestServerAsync<Sample1Snippets.EchoHandler>();

        var response = await env.Client.PostAsync("/invocations",
            new StringContent("test", Encoding.UTF8));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Headers.Contains("x-agent-invocation-id"), Is.True);
        Assert.That(response.Headers.Contains("x-agent-session-id"), Is.True);
    }

    // ═══════════════════════════════════════════════════════════════════
    //  Sample 2: Document Analysis — Long-Running with GET/Cancel
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Sample2_DocumentAnalysis_Returns202WithRetryAfter()
    {
        await using var env = await CreateTestServerAsync<Sample2Snippets.DocumentAnalysisHandler>();

        var json = """{"DocumentUrl":"https://example.com/doc.pdf"}""";
        var response = await env.Client.PostAsync("/invocations",
            new StringContent(json, Encoding.UTF8, "application/json"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Accepted));
        Assert.That(response.Headers.Contains("Retry-After"), Is.True);

        var body = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(body);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("running"));
        Assert.That(doc.RootElement.TryGetProperty("invocation_id", out _), Is.True);
    }

    [Test]
    public async Task Sample2_DocumentAnalysis_GetReturnsRunningThenCompleted()
    {
        await using var env = await CreateTestServerAsync<Sample2Snippets.DocumentAnalysisHandler>();

        // Trigger analysis
        var json = """{"DocumentUrl":"https://example.com/doc.pdf"}""";
        var postResponse = await env.Client.PostAsync("/invocations",
            new StringContent(json, Encoding.UTF8, "application/json"));
        var postBody = await postResponse.Content.ReadAsStringAsync();
        using var postDoc = JsonDocument.Parse(postBody);
        var invocationId = postDoc.RootElement.GetProperty("invocation_id").GetString()!;

        // Poll immediately — should be running
        var getResponse = await env.Client.GetAsync($"/invocations/{invocationId}");
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var getBody = await getResponse.Content.ReadAsStringAsync();
        using var getDoc = JsonDocument.Parse(getBody);
        Assert.That(getDoc.RootElement.GetProperty("status").GetString(), Is.EqualTo("running"));
    }

    [Test]
    public async Task Sample2_DocumentAnalysis_CancelReturns200()
    {
        await using var env = await CreateTestServerAsync<Sample2Snippets.DocumentAnalysisHandler>();

        // Trigger analysis
        var json = """{"DocumentUrl":"https://example.com/doc.pdf"}""";
        var postResponse = await env.Client.PostAsync("/invocations",
            new StringContent(json, Encoding.UTF8, "application/json"));
        var postBody = await postResponse.Content.ReadAsStringAsync();
        using var postDoc = JsonDocument.Parse(postBody);
        var invocationId = postDoc.RootElement.GetProperty("invocation_id").GetString()!;

        // Cancel
        var cancelResponse = await env.Client.PostAsync(
            $"/invocations/{invocationId}/cancel", null);
        Assert.That(cancelResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        // Verify cancelled
        var getResponse = await env.Client.GetAsync($"/invocations/{invocationId}");
        var getBody = await getResponse.Content.ReadAsStringAsync();
        using var getDoc = JsonDocument.Parse(getBody);
        Assert.That(getDoc.RootElement.GetProperty("status").GetString(), Is.EqualTo("cancelled"));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  Sample 3: Streaming Handler — SSE code generation
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Sample3_CodeGenHandler_StreamsTokensAsSse()
    {
        await using var env = await CreateTestServerAsync<Sample3Snippets.CodeGenHandler>();

        var json = """{"Prompt":"Write a calculator"}""";
        var response = await env.Client.PostAsync("/invocations",
            new StringContent(json, Encoding.UTF8, "application/json"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content.Headers.ContentType?.MediaType,
            Is.EqualTo("text/event-stream"));

        var body = await response.Content.ReadAsStringAsync();

        // Parse SSE events
        var dataLines = body.Split('\n')
            .Where(l => l.StartsWith("data: "))
            .Select(l => l["data: ".Length..])
            .ToList();

        Assert.That(dataLines, Has.Count.GreaterThanOrEqualTo(2));

        // Last event should be "done"
        using var lastDoc = JsonDocument.Parse(dataLines[^1]);
        Assert.That(lastDoc.RootElement.GetProperty("type").GetString(), Is.EqualTo("done"));

        // Token events should produce code
        var tokens = dataLines
            .Select(d => JsonDocument.Parse(d))
            .Where(d => d.RootElement.GetProperty("type").GetString() == "token")
            .Select(d => d.RootElement.GetProperty("content").GetString())
            .ToList();

        var fullCode = string.Join("", tokens);
        Assert.That(fullCode, Does.Contain("class Calculator"));
        Assert.That(fullCode, Does.Contain("Add"));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  Sample 4: Multi-Turn Travel Planner — session-based conversation
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Sample4_TravelPlanner_FirstTurn_WelcomeMessage()
    {
        await using var env = await CreateTestServerAsync<Sample4Snippets.TravelPlannerHandler>();

        var json = """{"Message":"I want to visit Tokyo"}""";
        var response = await env.Client.PostAsync("/invocations",
            new StringContent(json, Encoding.UTF8, "application/json"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(body);

        Assert.That(doc.RootElement.GetProperty("turn").GetInt32(), Is.EqualTo(1));
        Assert.That(doc.RootElement.GetProperty("reply").GetString(),
            Does.Contain("I want to visit Tokyo"));
        Assert.That(doc.RootElement.GetProperty("reply").GetString(),
            Does.Contain("plan a trip"));
    }

    [Test]
    public async Task Sample4_TravelPlanner_MultiTurn_TracksSessionState()
    {
        await using var env = await CreateTestServerAsync<Sample4Snippets.TravelPlannerHandler>();

        // Turn 1
        var json1 = """{"Message":"I want to visit Tokyo"}""";
        var response1 = await env.Client.PostAsync("/invocations",
            new StringContent(json1, Encoding.UTF8, "application/json"));
        var body1 = await response1.Content.ReadAsStringAsync();
        using var doc1 = JsonDocument.Parse(body1);
        var sessionId = doc1.RootElement.GetProperty("session_id").GetString()!;

        // Turn 2 — use same session via query parameter (Invocations resolves
        // session ID from ?agent_session_id=)
        var response2 = await env.Client.PostAsync(
            $"/invocations?agent_session_id={sessionId}",
            new StringContent(
                """{"Message":"For 5 days"}""", Encoding.UTF8, "application/json"));
        var body2 = await response2.Content.ReadAsStringAsync();
        using var doc2 = JsonDocument.Parse(body2);

        Assert.That(doc2.RootElement.GetProperty("turn").GetInt32(), Is.EqualTo(2));
        Assert.That(doc2.RootElement.GetProperty("reply").GetString(),
            Does.Contain("For 5 days"));
        Assert.That(doc2.RootElement.GetProperty("reply").GetString(),
            Does.Contain("1 topic"));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  Sample 5: Summarization Handler — Tier 1 Hosting with DI
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Sample5_SummarizationHandler_ReturnsSummary()
    {
        await using var env = await CreateTestServerAsync<Sample5Snippets.SummarizationHandler>(
            services =>
            {
                services.AddSingleton<Sample5Snippets.ISummarizationService,
                    Sample5Snippets.OpenAISummarizationService>();
            });

        var response = await env.Client.PostAsync("/invocations",
            new StringContent("Some long document text that needs summarizing",
                Encoding.UTF8, "text/plain"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(body);

        Assert.That(doc.RootElement.GetProperty("summary").GetString(),
            Does.Contain("Summary of"));
        Assert.That(doc.RootElement.TryGetProperty("invocation_id", out _), Is.True);
        Assert.That(doc.RootElement.TryGetProperty("session_id", out _), Is.True);
    }

    // ═══════════════════════════════════════════════════════════════════
    //  Sample 6: Summarization Handler — Tier 2 Builder
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Sample6_SummarizationHandler_ReturnsSummary()
    {
        await using var env = await CreateTestServerAsync<Sample6Snippets.SummarizationHandler>(
            services =>
            {
                services.AddSingleton<Sample6Snippets.ISummarizationService,
                    Sample6Snippets.OpenAISummarizationService>();
            });

        var response = await env.Client.PostAsync("/invocations",
            new StringContent("Document content to summarize",
                Encoding.UTF8, "text/plain"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(body);

        Assert.That(doc.RootElement.GetProperty("summary").GetString(),
            Does.Contain("Summary of"));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  Sample 7: Summarization Handler — Tier 3 Self-Hosting
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task Sample7_SummarizationHandler_ReturnsSummary()
    {
        await using var env = await CreateTestServerAsync<Sample7Snippets.SummarizationHandler>(
            services =>
            {
                services.AddSingleton<Sample7Snippets.ISummarizationService,
                    Sample7Snippets.OpenAISummarizationService>();
            });

        var response = await env.Client.PostAsync("/invocations",
            new StringContent("Summarize this content please",
                Encoding.UTF8, "text/plain"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(body);

        Assert.That(doc.RootElement.GetProperty("summary").GetString(),
            Does.Contain("Summary of"));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  README WebSocket sample — invocations_ws end-to-end
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task ReadMe_WebSocketEchoHandler_EchoesTextFrame_AndClosesCleanly()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddInvocationsServer();
        builder.Services.AddScoped<InvocationHandler, Snippets.ReadMeSnippets.WebSocketEchoHandler>();

        var app = builder.Build();
        app.UseWebSockets();
        app.MapInvocationsServer();
        await app.StartAsync();
        try
        {
            var server = app.GetTestServer();
            var wsClient = server.CreateWebSocketClient();
            var uri = new Uri(server.BaseAddress, "invocations_ws");
            using var ws = await wsClient.ConnectAsync(uri, CancellationToken.None);

            var payload = Encoding.UTF8.GetBytes("ping");
            await ws.SendAsync(payload, System.Net.WebSockets.WebSocketMessageType.Text,
                endOfMessage: true, CancellationToken.None);

            var buffer = new byte[1024];
            var received = await ws.ReceiveAsync(buffer, CancellationToken.None);
            Assert.That(received.MessageType, Is.EqualTo(System.Net.WebSockets.WebSocketMessageType.Text));
            Assert.That(Encoding.UTF8.GetString(buffer, 0, received.Count), Is.EqualTo("ping"));

            await ws.CloseOutputAsync(System.Net.WebSockets.WebSocketCloseStatus.NormalClosure,
                "client done", CancellationToken.None);

            var close = await ws.ReceiveAsync(buffer, CancellationToken.None);
            Assert.That(close.MessageType, Is.EqualTo(System.Net.WebSockets.WebSocketMessageType.Close));
            Assert.That(ws.CloseStatus, Is.EqualTo(System.Net.WebSockets.WebSocketCloseStatus.NormalClosure));
        }
        finally
        {
            await app.StopAsync();
        }
    }

    // ═══════════════════════════════════════════════════════════════════
    //  Sample WS1: WebSocket Echo — HTTP and WS on the same handler
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task SampleWs1_EchoAgentHandler_RespondsOverHttp()
    {
        await using var env = await CreateTestServerAsync<Snippets.SampleWs1Snippets.EchoAgentHandler>(
            configureServerSide: true);

        var response = await env.Client.PostAsync("/invocations",
            new StringContent("Hello over HTTP", Encoding.UTF8, "text/plain"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await response.Content.ReadAsStringAsync();
        Assert.That(body, Is.EqualTo("You said: Hello over HTTP"));
    }

    [Test]
    public async Task SampleWs1_EchoAgentHandler_EchoesOverWebSocket()
    {
        await using var env = await CreateTestServerAsync<Snippets.SampleWs1Snippets.EchoAgentHandler>(
            configureServerSide: true);

        var wsClient = env.Server.CreateWebSocketClient();
        var uri = new Uri(env.Server.BaseAddress, "invocations_ws");
        using var ws = await wsClient.ConnectAsync(uri, CancellationToken.None);

        await ws.SendAsync(
            Encoding.UTF8.GetBytes("Hello over WebSocket"),
            System.Net.WebSockets.WebSocketMessageType.Text,
            endOfMessage: true,
            CancellationToken.None);

        var buffer = new byte[1024];
        var received = await ws.ReceiveAsync(buffer, CancellationToken.None);
        Assert.That(received.MessageType, Is.EqualTo(System.Net.WebSockets.WebSocketMessageType.Text));
        Assert.That(Encoding.UTF8.GetString(buffer, 0, received.Count), Is.EqualTo("Hello over WebSocket"));

        await ws.CloseOutputAsync(
            System.Net.WebSockets.WebSocketCloseStatus.NormalClosure,
            "client done",
            CancellationToken.None);

        var close = await ws.ReceiveAsync(buffer, CancellationToken.None);
        Assert.That(close.MessageType, Is.EqualTo(System.Net.WebSockets.WebSocketMessageType.Close));
        Assert.That(ws.CloseStatus, Is.EqualTo(System.Net.WebSockets.WebSocketCloseStatus.NormalClosure));
    }

    // ═══════════════════════════════════════════════════════════════════
    //  Sample WS2: WebSocket Bidirectional Streaming
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task SampleWs2_BidirectionalStreaming_StreamsTokensAndHandlesBye()
    {
        await using var env = await CreateTestServerAsync<Snippets.SampleWs2Snippets.BidirectionalStreamingHandler>(
            configureServerSide: true);

        var wsClient = env.Server.CreateWebSocketClient();
        var uri = new Uri(env.Server.BaseAddress, "invocations_ws");
        using var ws = await wsClient.ConnectAsync(uri, CancellationToken.None);

        var ready = await ReceiveJsonAsync(ws);
        Assert.That(ready.GetProperty("type").GetString(), Is.EqualTo("ready"));

        await SendJsonAsync(ws, new { type = "prompt", id = "p1", text = "anything" });

        // Read until we observe a 'done' for p1 — the streamer pushes
        // 25 token frames before signalling done.
        var sawDone = false;
        var tokenCount = 0;
        for (int i = 0; i < 60 && !sawDone; i++)
        {
            var frame = await ReceiveJsonAsync(ws);
            switch (frame.GetProperty("type").GetString())
            {
                case "token":
                    Assert.That(frame.GetProperty("id").GetString(), Is.EqualTo("p1"));
                    tokenCount++;
                    break;
                case "done":
                    Assert.That(frame.GetProperty("id").GetString(), Is.EqualTo("p1"));
                    sawDone = true;
                    break;
                default:
                    Assert.Fail($"Unexpected frame type: {frame.GetProperty("type").GetString()}");
                    break;
            }
        }

        Assert.That(sawDone, Is.True, "Expected a 'done' frame for prompt p1.");
        Assert.That(tokenCount, Is.GreaterThan(0), "Expected at least one token frame before 'done'.");

        await SendJsonAsync(ws, new { type = "bye" });

        // SDK should close cleanly after the handler returns from 'bye'.
        var buffer = new byte[256];
        var close = await ws.ReceiveAsync(buffer, CancellationToken.None);
        Assert.That(close.MessageType, Is.EqualTo(System.Net.WebSockets.WebSocketMessageType.Close));
        Assert.That(ws.CloseStatus, Is.EqualTo(System.Net.WebSockets.WebSocketCloseStatus.NormalClosure));
    }

    [Test]
    public async Task SampleWs2_BidirectionalStreaming_CancelInterruptsInFlight()
    {
        await using var env = await CreateTestServerAsync<Snippets.SampleWs2Snippets.BidirectionalStreamingHandler>(
            configureServerSide: true);

        var wsClient = env.Server.CreateWebSocketClient();
        var uri = new Uri(env.Server.BaseAddress, "invocations_ws");
        using var ws = await wsClient.ConnectAsync(uri, CancellationToken.None);

        // Drain "ready".
        await ReceiveJsonAsync(ws);

        await SendJsonAsync(ws, new { type = "prompt", id = "p1", text = "anything" });

        // Wait for the first token so we know the streamer is running.
        var firstFrame = await ReceiveJsonAsync(ws);
        Assert.That(firstFrame.GetProperty("type").GetString(), Is.EqualTo("token"));
        Assert.That(firstFrame.GetProperty("id").GetString(), Is.EqualTo("p1"));

        await SendJsonAsync(ws, new { type = "cancel", id = "p1" });

        // We may receive a few more in-flight tokens before the cancel takes
        // effect — keep reading until we see the 'cancelled' frame.
        var sawCancelled = false;
        for (int i = 0; i < 40 && !sawCancelled; i++)
        {
            var frame = await ReceiveJsonAsync(ws);
            if (frame.GetProperty("type").GetString() == "cancelled" &&
                frame.GetProperty("id").GetString() == "p1")
            {
                sawCancelled = true;
            }
        }

        Assert.That(sawCancelled, Is.True,
            "Expected the handler to report 'cancelled' for the in-flight prompt.");

        await SendJsonAsync(ws, new { type = "bye" });
    }

    private static async Task<JsonElement> ReceiveJsonAsync(System.Net.WebSockets.WebSocket ws)
    {
        var buffer = new byte[8192];
        var received = await ws.ReceiveAsync(buffer, CancellationToken.None);
        Assert.That(received.MessageType, Is.EqualTo(System.Net.WebSockets.WebSocketMessageType.Text),
            $"Expected text frame, got {received.MessageType} (close status: {ws.CloseStatus}, desc: {ws.CloseStatusDescription}).");
        using var doc = JsonDocument.Parse(buffer.AsMemory(0, received.Count));
        return doc.RootElement.Clone();
    }

    private static Task SendJsonAsync<T>(System.Net.WebSockets.WebSocket ws, T payload)
    {
        var bytes = JsonSerializer.SerializeToUtf8Bytes(payload);
        return ws.SendAsync(
            bytes,
            System.Net.WebSockets.WebSocketMessageType.Text,
            endOfMessage: true,
            CancellationToken.None);
    }

    // ═══════════════════════════════════════════════════════════════════
    //  Sample 8: Resilient Research — Task ⇄ Stream bridge
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task ResilientResearch_StreamsEventsAsSse()
    {
        await using var env = await CreateResilientResearchServerAsync();

        var request = new HttpRequestMessage(HttpMethod.Post, "/invocations")
        {
            Content = new StringContent(
                """{"Topic":"quantum computing"}""", Encoding.UTF8, "application/json"),
        };
        request.Headers.TryAddWithoutValidation("Accept", "text/event-stream");
        var response = await env.Client.SendAsync(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content.Headers.ContentType?.MediaType,
            Is.EqualTo("text/event-stream"));

        var rawSse = await response.Content.ReadAsStringAsync();
        var events = ParseSseEvents(rawSse);

        // Real model token deltas are forwarded as `token` events, terminating with `done`.
        Assert.That(events, Has.Count.GreaterThanOrEqualTo(3));
        Assert.That(events, Has.Some.Matches<SseEvent>(e => e.Type == "token"),
            "Stream should include model token events from the real ResponsesClient.");
        Assert.That(events[^1].Type, Is.EqualTo("done"));

        // The SSE layer appends a protocol `event: done` terminator (Python parity) so a client
        // can distinguish a clean stream-end from a dropped connection.
        Assert.That(rawSse, Does.Contain("event: done"),
            "Clean stream close should emit a protocol `event: done` terminator frame.");

        for (int i = 1; i < events.Count; i++)
        {
            Assert.That(events[i].Cursor, Is.GreaterThan(events[i - 1].Cursor));
        }
    }

    [Test]
    public async Task ResilientResearch_PostWithoutSseAccept_Returns202WithInvocationId()
    {
        await using var env = await CreateResilientResearchServerAsync();

        // No Accept: text/event-stream → the handler returns 202 + an invocation id to resume.
        var response = await env.Client.PostAsync("/invocations",
            new StringContent("""{"Topic":"async start"}""", Encoding.UTF8, "application/json"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Accepted));
        using var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        Assert.That(doc.RootElement.GetProperty("invocation_id").GetString(), Is.Not.Empty);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("running"));
    }

    [Test]
    public async Task ResilientResearch_Get_ResumesFromCursor()
    {
        // RESUME is GET /invocations/{id} — it re-attaches to the EXISTING durable stream
        // after the supplied cursor. It must NOT start a new run (the protocol's read path).
        await using var env = await CreateResilientResearchServerAsync();

        var invocationId = "research-resume-" + Guid.NewGuid().ToString("N");

        // Start the turn and stream all events live (producer runs to completion).
        var start = new HttpRequestMessage(HttpMethod.Post, "/invocations")
        {
            Content = new StringContent(
                """{"Topic":"resume test"}""", Encoding.UTF8, "application/json"),
        };
        start.Headers.TryAddWithoutValidation("Accept", "text/event-stream");
        start.Headers.Add("x-agent-invocation-id", invocationId);
        var startResponse = await env.Client.SendAsync(start);
        var original = ParseSseEvents(await startResponse.Content.ReadAsStringAsync());
        Assert.That(original, Has.Count.GreaterThanOrEqualTo(3));
        for (int i = 0; i < original.Count; i++)
        {
            Assert.That(original[i].Cursor, Is.EqualTo(i + 1));
        }

        // Resume via GET after the 2nd cursor — yields only the remaining tail (replay, not rerun).
        int resumeAfter = original[1].Cursor;
        var resume = new HttpRequestMessage(HttpMethod.Get,
            $"/invocations/{invocationId}?last_event_id={resumeAfter}");
        resume.Headers.TryAddWithoutValidation("Accept", "text/event-stream");
        var resumeResponse = await env.Client.SendAsync(resume);

        Assert.That(resumeResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var replayed = ParseSseEvents(await resumeResponse.Content.ReadAsStringAsync());

        Assert.That(replayed, Has.Count.EqualTo(original.Count - 2),
            "GET resume after the 2nd cursor should yield only the remaining events.");
        Assert.That(replayed[0].Cursor, Is.EqualTo(resumeAfter + 1));
        Assert.That(replayed[^1].Type, Is.EqualTo("done"));
    }

    [Test]
    public async Task ResilientResearch_Get_UnknownInvocation_Returns404()
    {
        await using var env = await CreateResilientResearchServerAsync();

        var request = new HttpRequestMessage(HttpMethod.Get, "/invocations/does-not-exist");
        request.Headers.TryAddWithoutValidation("Accept", "text/event-stream");
        var response = await env.Client.SendAsync(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound),
            "Resuming a stream that was never created should 404.");
    }

    [Test]
    public async Task ResilientResearch_SecondTurnSameSession_DoesNotConflict()
    {
        // The research task is session-scoped and steerable: a second POST on the SAME
        // session id must start/steer the next turn, never fault with a conflict (which a
        // one-shot registration would do once the first turn completes).
        await using var env = await CreateResilientResearchServerAsync();
        var sessionId = "research-multi-" + Guid.NewGuid().ToString("N")[..8];

        var first = await env.Client.PostAsync(
            $"/invocations?agent_session_id={sessionId}",
            new StringContent("""{"Topic":"first turn"}""", Encoding.UTF8, "application/json"));
        Assert.That(first.StatusCode, Is.EqualTo(HttpStatusCode.Accepted));

        var second = await env.Client.PostAsync(
            $"/invocations?agent_session_id={sessionId}",
            new StringContent("""{"Topic":"second turn"}""", Encoding.UTF8, "application/json"));
        Assert.That(second.StatusCode, Is.EqualTo(HttpStatusCode.Accepted),
            "A second turn on the same session must be accepted (steered/queued), not conflict.");
    }

    // ═══════════════════════════════════════════════════════════════════
    //  Sample 9: Resilient Multi-turn — steerable durable conversation
    // ═══════════════════════════════════════════════════════════════════

    [Test]
    public async Task ResilientMultiturn_SingleTurn_ReturnsReply()
    {
        await using var env = await CreateResilientMultiturnServerAsync();
        var sessionId = "conv-single-" + Guid.NewGuid().ToString("N")[..8];

        var json = """{"Message":"What is Rust?"}""";
        var response = await env.Client.PostAsync(
            $"/invocations?agent_session_id={sessionId}",
            new StringContent(json, Encoding.UTF8, "application/json"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var body = await response.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(body);

        Assert.That(doc.RootElement.GetProperty("turn").GetInt32(), Is.EqualTo(1));
        Assert.That(doc.RootElement.GetProperty("reply").GetString(), Does.Contain("What is Rust?"));
    }

    [Test]
    public async Task ResilientMultiturn_MultipleRurns_AccumulatesContext()
    {
        await using var env = await CreateResilientMultiturnServerAsync();
        var sessionId = "conv-test-multi-" + Guid.NewGuid().ToString("N")[..8];

        // Turn 1
        var response1 = await env.Client.PostAsync(
            $"/invocations?agent_session_id={sessionId}",
            new StringContent("""{"Message":"Hello"}""", Encoding.UTF8, "application/json"));
        var body1 = await response1.Content.ReadAsStringAsync();
        using var doc1 = JsonDocument.Parse(body1);
        Assert.That(doc1.RootElement.GetProperty("turn").GetInt32(), Is.EqualTo(1));

        // Turn 2
        var response2 = await env.Client.PostAsync(
            $"/invocations?agent_session_id={sessionId}",
            new StringContent("""{"Message":"Tell me more"}""", Encoding.UTF8, "application/json"));
        var body2 = await response2.Content.ReadAsStringAsync();
        using var doc2 = JsonDocument.Parse(body2);
        Assert.That(doc2.RootElement.GetProperty("turn").GetInt32(), Is.EqualTo(2));

        // Turn 3
        var response3 = await env.Client.PostAsync(
            $"/invocations?agent_session_id={sessionId}",
            new StringContent("""{"Message":"Wrap up"}""", Encoding.UTF8, "application/json"));
        var body3 = await response3.Content.ReadAsStringAsync();
        using var doc3 = JsonDocument.Parse(body3);
        Assert.That(doc3.RootElement.GetProperty("turn").GetInt32(), Is.EqualTo(3));
    }

    [Test]
    public async Task ResilientMultiturn_Steering_ConcurrentInputQueuesAsSteering()
    {
        // Genuinely exercise steering: fire a second input on the same session WHILE the
        // first turn is still running. The durable engine queues the second input as a
        // steering message (run.IsQueued == true on at least one response), and the
        // producer observes ctx.PendingInputCount > 0 and wraps up the in-flight turn.
        await using var env = await CreateResilientMultiturnServerAsync();
        var sessionId = "conv-test-steer-" + Guid.NewGuid().ToString("N")[..8];

        // Warm up the host (JIT, routing, task-engine lease/store paths) with a throwaway
        // turn on a separate session so the timed concurrency window below is not skewed by
        // first-request cold-start jitter (which would otherwise let the second input land
        // after the first turn already finished).
        using (var warmup = await env.Client.PostAsync(
            $"/invocations?agent_session_id=warmup-{Guid.NewGuid():N}",
            new StringContent("""{"Message":"warm up"}""", Encoding.UTF8, "application/json")))
        {
            Assert.That(warmup.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        var content1 = new StringContent(
            """{"Message":"Write a long essay"}""", Encoding.UTF8, "application/json");
        var content2 = new StringContent(
            """{"Message":"Actually just one sentence"}""", Encoding.UTF8, "application/json");

        // Start turn 1 (the producer loops ~100ms so it stays in-flight), then fire the
        // second input concurrently to land while turn 1 is still running.
        var task1 = env.Client.PostAsync($"/invocations?agent_session_id={sessionId}", content1);
        await Task.Delay(20);
        var task2 = env.Client.PostAsync($"/invocations?agent_session_id={sessionId}", content2);

        var responses = await Task.WhenAll(task1, task2);
        Assert.That(responses[0].StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(responses[1].StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var bodies = new List<JsonElement>();
        bool anyQueued = false;
        bool anyInterrupted = false;
        foreach (var resp in responses)
        {
            using var doc = JsonDocument.Parse(await resp.Content.ReadAsStringAsync());
            var root = doc.RootElement.Clone();
            bodies.Add(root);
            if (root.TryGetProperty("is_queued", out var q) && q.GetBoolean())
            {
                anyQueued = true;
            }
            if (root.GetProperty("reply").GetString()!.Contains("interrupted"))
            {
                anyInterrupted = true;
            }
        }

        // The concurrent input was steered: it was queued and/or it caused the in-flight
        // turn to wrap up early (observed PendingInputCount > 0).
        Assert.That(anyQueued || anyInterrupted, Is.True,
            "A concurrent same-session input should be queued as steering or interrupt the in-flight turn.");

        // The two turns are distinct and ordered.
        var turns = bodies.Select(b => b.GetProperty("turn").GetInt32()).OrderBy(t => t).ToArray();
        Assert.That(turns, Is.EqualTo(new[] { 1, 2 }),
            "Steered conversation should produce two sequential turns.");
    }

    [Test]
    public async Task ResilientMultiturn_DoneMessage_TerminatesAndClearsSessionHistory()
    {
        // Python parity: tests/e2e/test_resilient_multiturn.py::test_session_workflow_done_clears_history.
        // A "done" message returns a terminal (finished) result whose summary reports the messages
        // exchanged so far, and clears the named-namespace session history + turn_count so a
        // subsequent turn on the same session starts fresh (turn == 1 again).
        await using var env = await CreateResilientMultiturnServerAsync();
        var sessionId = "conv-done-" + Guid.NewGuid().ToString("N")[..8];

        // Two real turns accumulate session state (turn_count → 2).
        await env.Client.PostAsync($"/invocations?agent_session_id={sessionId}",
            new StringContent("""{"Message":"Tokyo trip"}""", Encoding.UTF8, "application/json"));
        var t2 = await env.Client.PostAsync($"/invocations?agent_session_id={sessionId}",
            new StringContent("""{"Message":"Budget please"}""", Encoding.UTF8, "application/json"));
        using (var d2 = JsonDocument.Parse(await t2.Content.ReadAsStringAsync()))
        {
            Assert.That(d2.RootElement.GetProperty("turn").GetInt32(), Is.EqualTo(2));
        }

        // "done" terminates the session: finished == true and a summary reply.
        var done = await env.Client.PostAsync($"/invocations?agent_session_id={sessionId}",
            new StringContent("""{"Message":"done"}""", Encoding.UTF8, "application/json"));
        Assert.That(done.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using (var dDone = JsonDocument.Parse(await done.Content.ReadAsStringAsync()))
        {
            Assert.That(dDone.RootElement.GetProperty("finished").GetBoolean(), Is.True,
                "a 'done' message must return a terminal (finished) result");
            Assert.That(dDone.RootElement.GetProperty("reply").GetString(),
                Does.Contain("Session complete"),
                "the terminal result should summarize the completed session");
        }

        // The next turn on the same session starts fresh — history + turn_count were cleared.
        var reopened = await env.Client.PostAsync($"/invocations?agent_session_id={sessionId}",
            new StringContent("""{"Message":"new topic"}""", Encoding.UTF8, "application/json"));
        using (var dNew = JsonDocument.Parse(await reopened.Content.ReadAsStringAsync()))
        {
            Assert.That(dNew.RootElement.GetProperty("turn").GetInt32(), Is.EqualTo(1),
                "after 'done' cleared the session, a new turn must restart the turn counter at 1");
            Assert.That(dNew.RootElement.GetProperty("finished").GetBoolean(), Is.False);
        }
    }

    // ═══════════════════════════════════════════════════════════════════
    //  Resilient Sample Helpers — SSE parsing + server factories
    // ═══════════════════════════════════════════════════════════════════

    private record SseEvent(int Cursor, string Type, string Content);

    private static List<SseEvent> ParseSseEvents(string sseBody)
    {
        var events = new List<SseEvent>();
        string? currentId = null;
        string? currentEvent = null;

        foreach (var line in sseBody.Split('\n'))
        {
            if (line.StartsWith("id: "))
            {
                currentId = line["id: ".Length..];
            }
            else if (line.StartsWith("event: "))
            {
                currentEvent = line["event: ".Length..];
            }
            else if (line.StartsWith("data: "))
            {
                // Protocol terminator frames (`event: done` / `event: superseded`) carry an SSE
                // `event:` field and no domain cursor — they mark clean stream-end vs. a dropped
                // connection and are not domain events, so skip them from the domain-event list.
                if (currentEvent is not null)
                {
                    currentEvent = null;
                    currentId = null;
                    continue;
                }

                var data = line["data: ".Length..];
                using var doc = JsonDocument.Parse(data);
                var root = doc.RootElement;

                int cursor = currentId != null && int.TryParse(currentId, out var c) ? c : 0;
                string type = root.TryGetProperty("Type", out var t) ? t.GetString() ?? ""
                    : root.TryGetProperty("type", out var t2) ? t2.GetString() ?? ""
                    : "";
                string content = root.TryGetProperty("Content", out var ct) ? ct.GetString() ?? ""
                    : root.TryGetProperty("content", out var ct2) ? ct2.GetString() ?? ""
                    : "";

                events.Add(new SseEvent(cursor, type, content));
                currentId = null;
            }
        }

        return events;
    }

    /// <summary>
    /// Creates a test server for the Resilient Research sample. The producer is the
    /// documented snippet method (<c>RunResearchAsync</c>) driven by a REAL OpenAI
    /// <see cref="ResponsesClient"/> whose transport is redirected to an in-process mock
    /// backend that returns canned OpenAI Responses SSE — so the snippet code runs exactly
    /// as in production while staying deterministic and offline.
    /// </summary>
    private static async Task<TestEnv> CreateResilientResearchServerAsync()
    {
        var checkpointStore = new Snippets.SampleResilientResearchSnippets.CheckpointStore(
            Path.Combine(Path.GetTempPath(), "research-checkpoints-" + Guid.NewGuid().ToString("N")[..8]));
        var model = CreateMockResponsesClient();

        var env = await CreateTestServerAsync<Snippets.SampleResilientResearchSnippets.ResilientResearchHandler>(
            services =>
            {
                // In-memory replay with a TTL so retained streams are reclaimed.
                services.AddEventStreams(o => o.UseInMemoryReplay(
                    cursor: payload => ((Snippets.SampleResilientResearchSnippets.ResearchEvent)payload).Cursor,
                    ttl: TimeSpan.FromMinutes(5)));

                services.AddResilientTasks()
                    .AddMultiTurnTask<Snippets.SampleResilientResearchSnippets.ResearchRequest,
                             Snippets.SampleResilientResearchSnippets.ResearchResult>(
                        "research",
                        (provider, ctx, ct) => Snippets.SampleResilientResearchSnippets.RunResearchAsync(
                            provider.GetRequiredService<IEventStreamRegistry>(), model, "test-model", ctx, checkpointStore,
                            numPhases: 2, callsPerPhase: 2,
                            interPhaseCooldown: TimeSpan.Zero,
                            intraPhaseCooldown: TimeSpan.Zero,
                            ct: ct),
                        steerable: true);
            });

        return env;
    }

    /// <summary>
    /// A real OpenAI <see cref="ResponsesClient"/> whose HTTP transport is redirected to an
    /// in-process mock that emits canned OpenAI Responses SSE. The SDK genuinely parses the
    /// streaming protocol — only the network hop is replaced.
    /// </summary>
    private static ResponsesClient CreateMockResponsesClient() =>
        new ResponsesClient(
            new ApiKeyCredential("unused-key"),
            new OpenAIClientOptions
            {
                Endpoint = new Uri("http://mock-openai-backend"),
                Transport = new HttpClientPipelineTransport(
                    new HttpClient(new MockStreamingBackendHandler())),
            });

    /// <summary>
    /// Mock backend returning a canned OpenAI Responses SSE stream with a short text delta,
    /// matching the streaming format the SDK expects.
    /// </summary>
    private sealed class MockStreamingBackendHandler : HttpMessageHandler
    {
        // Canned SSE modeled on a real Azure Foundry OpenAI Responses stream captured from
        // gpt-5.4-nano. Field shapes — sequence_number on every event, multiple
        // output_text.delta frames, phase/annotations/logprobs members — mirror the live wire
        // format so the deterministic test exercises the same multi-token streaming path the
        // live test does.
        private const string ItemId = "msg_mock0001";
        private const string ResponseId = "resp_mock0001";
        private static readonly string[] s_deltas = { "Findings:", " deterministic", " mock", " output." };

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            int seq = 0;
            var sb = new StringBuilder();
            string fullText = string.Concat(s_deltas);
            string textJson = JsonSerializer.Serialize(fullText);

            AppendSseEvent(sb, "response.created",
                "{\"type\":\"response.created\",\"sequence_number\":" + seq++ + ",\"response\":{\"id\":\"" + ResponseId + "\",\"object\":\"response\",\"created_at\":1782863171,\"status\":\"in_progress\",\"model\":\"test-model\",\"output\":[],\"parallel_tool_calls\":true,\"metadata\":{}}}");
            AppendSseEvent(sb, "response.in_progress",
                "{\"type\":\"response.in_progress\",\"sequence_number\":" + seq++ + ",\"response\":{\"id\":\"" + ResponseId + "\",\"object\":\"response\",\"status\":\"in_progress\",\"model\":\"test-model\",\"output\":[]}}");
            AppendSseEvent(sb, "response.output_item.added",
                "{\"type\":\"response.output_item.added\",\"sequence_number\":" + seq++ + ",\"output_index\":0,\"item\":{\"id\":\"" + ItemId + "\",\"type\":\"message\",\"status\":\"in_progress\",\"content\":[],\"phase\":\"final_answer\",\"role\":\"assistant\"}}");
            AppendSseEvent(sb, "response.content_part.added",
                "{\"type\":\"response.content_part.added\",\"sequence_number\":" + seq++ + ",\"item_id\":\"" + ItemId + "\",\"output_index\":0,\"content_index\":0,\"part\":{\"type\":\"output_text\",\"annotations\":[],\"logprobs\":[],\"text\":\"\"}}");

            foreach (var delta in s_deltas)
            {
                AppendSseEvent(sb, "response.output_text.delta",
                    "{\"type\":\"response.output_text.delta\",\"sequence_number\":" + seq++ + ",\"item_id\":\"" + ItemId + "\",\"output_index\":0,\"content_index\":0,\"logprobs\":[],\"delta\":" + JsonSerializer.Serialize(delta) + "}");
            }

            AppendSseEvent(sb, "response.output_text.done",
                "{\"type\":\"response.output_text.done\",\"sequence_number\":" + seq++ + ",\"item_id\":\"" + ItemId + "\",\"output_index\":0,\"content_index\":0,\"logprobs\":[],\"text\":" + textJson + "}");
            AppendSseEvent(sb, "response.content_part.done",
                "{\"type\":\"response.content_part.done\",\"sequence_number\":" + seq++ + ",\"item_id\":\"" + ItemId + "\",\"output_index\":0,\"content_index\":0,\"part\":{\"type\":\"output_text\",\"annotations\":[],\"logprobs\":[],\"text\":" + textJson + "}}");
            AppendSseEvent(sb, "response.output_item.done",
                "{\"type\":\"response.output_item.done\",\"sequence_number\":" + seq++ + ",\"output_index\":0,\"item\":{\"id\":\"" + ItemId + "\",\"type\":\"message\",\"status\":\"completed\",\"phase\":\"final_answer\",\"role\":\"assistant\",\"content\":[{\"type\":\"output_text\",\"annotations\":[],\"logprobs\":[],\"text\":" + textJson + "}]}}");
            AppendSseEvent(sb, "response.completed",
                "{\"type\":\"response.completed\",\"sequence_number\":" + seq++ + ",\"response\":{\"id\":\"" + ResponseId + "\",\"object\":\"response\",\"status\":\"completed\",\"model\":\"test-model\",\"output\":[{\"id\":\"" + ItemId + "\",\"type\":\"message\",\"status\":\"completed\",\"role\":\"assistant\",\"content\":[{\"type\":\"output_text\",\"text\":" + textJson + "}]}],\"usage\":{\"input_tokens\":12,\"output_tokens\":8,\"total_tokens\":20}}}");

            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(sb.ToString(), Encoding.UTF8, "text/event-stream"),
            });
        }

        private static void AppendSseEvent(StringBuilder sb, string eventType, string data)
        {
            sb.Append("event: ").AppendLine(eventType);
            sb.Append("data: ").AppendLine(data.Trim());
            sb.AppendLine();
        }
    }

    /// <summary>
    /// Creates a test server for the Resilient Multiturn sample using the documented
    /// steerable producer snippet method (<c>RunConversationTurnAsync</c>) with a
    /// deterministic stubbed reply.
    /// </summary>
    private static async Task<TestEnv> CreateResilientMultiturnServerAsync()
    {
        return await CreateTestServerAsync<Snippets.SampleResilientMultiturnSnippets.ResilientMultiturnHandler>(
            services =>
            {
                services.AddResilientTasks()
                    .AddMultiTurnTask<Snippets.SampleResilientMultiturnSnippets.ConversationInput,
                                      Snippets.SampleResilientMultiturnSnippets.ConversationOutput>(
                        "conversation",
                        (ctx, ct) => Snippets.SampleResilientMultiturnSnippets.RunConversationTurnAsync(
                            ctx,
                            (history, msg, c) => Task.FromResult($"Turn reply: You said \"{msg}\""),
                            ct),
                        steerable: true);
            });
    }

    // ═══════════════════════════════════════════════════════════════════
    //  Test Infrastructure
    // ═══════════════════════════════════════════════════════════════════

    /// <summary>
    /// Creates an in-memory ASP.NET Core test server with the specified
    /// <see cref="InvocationHandler"/> registered, matching the Tier 3
    /// self-hosted pattern used throughout the Invocations tests.
    /// </summary>
    /// <param name="configureServices">Optional service configuration callback.</param>
    /// <param name="configureServerSide">
    /// When <c>true</c>, also calls <c>app.UseWebSockets()</c> so handlers can
    /// accept <c>/invocations_ws</c> upgrade requests. Production code wires
    /// this through <c>Core.AgentHostMiddlewareExtensions.UseAgentServerCore</c>;
    /// tests build <see cref="WebApplication"/> directly, so the WS samples
    /// must opt in explicitly.
    /// </param>
    private static async Task<TestEnv> CreateTestServerAsync<THandler>(
        Action<IServiceCollection>? configureServices = null,
        bool configureServerSide = false)
        where THandler : InvocationHandler
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddInvocationsServer();
        builder.Services.AddScoped<InvocationHandler, THandler>();
        configureServices?.Invoke(builder.Services);

        var app = builder.Build();
        if (configureServerSide)
        {
            app.UseWebSockets();
        }
        app.MapInvocationsServer();
        await app.StartAsync();

        return new TestEnv(app);
    }

    /// <summary>
    /// Disposable wrapper around the test application and its HTTP client.
    /// </summary>
    private sealed class TestEnv : IAsyncDisposable
    {
        private readonly WebApplication _app;

        public TestEnv(WebApplication app)
        {
            _app = app;
            Client = app.GetTestClient();
        }

        public HttpClient Client { get; }

        public TestServer Server => _app.GetTestServer();

        public async ValueTask DisposeAsync()
        {
            Client.Dispose();
            await _app.StopAsync();
            await _app.DisposeAsync();
        }
    }
}
