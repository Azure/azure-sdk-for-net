// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Invocations.Tests.Snippets;
using Azure.AI.AgentServer.Invocations.Voice;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

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

    [Test]
    public async Task SampleVoice1_TypedRelay_ExplicitlyAcknowledgesAndReplies()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddAgentServerCore();
        builder.Services.AddVoice<Snippets.SampleVoice1Snippets.VoiceSupportHandler>();
        await using var app = builder.Build();
        app.UseAgentServerCore();
        app.MapInvocationsServer();
        await app.StartAsync();
        var wsClient = app.GetTestServer().CreateWebSocketClient();
        using var ws = await wsClient.ConnectAsync(
            new Uri(app.GetTestServer().BaseAddress, "invocations_ws"),
            CancellationToken.None);

        await SendJsonAsync(ws, new
        {
            type = "session.start",
            id = "m_start",
            ts = "2026-08-13T00:00:00.000Z",
            protocol_version = "1.0",
            reconnect = false,
            response_timeouts = new
            {
                first_output_ms = 5000,
                idle_ms = 8000,
                max_duration_ms = 60000,
            },
        });
        var ready = await ReceiveJsonAsync(ws);
        Assert.That(ready.GetProperty("type").GetString(), Is.EqualTo("session.ready"));

        await SendJsonAsync(ws, new
        {
            type = "user.message",
            id = "m_user",
            ts = "2026-08-13T00:00:01.000Z",
            item_id = "in_1",
            content = new[] { new { type = "input_text", text = "hello" } },
        });

        var responseTypes = new List<string>();
        string? outputText = null;
        while (!responseTypes.Contains("response.done", StringComparer.Ordinal))
        {
            var frame = await ReceiveJsonAsync(ws);
            var type = frame.GetProperty("type").GetString()!;
            responseTypes.Add(type);
            if (type == "response.output_text.done")
            {
                outputText = frame.GetProperty("text").GetString();
            }
        }

        Assert.Multiple(() =>
        {
            Assert.That(responseTypes, Is.EqualTo(new[]
            {
                "response.created",
                "response.output_text.done",
                "response.done",
            }));
            Assert.That(outputText, Is.EqualTo("You said: hello"));
        });
        await ws.CloseOutputAsync(
            System.Net.WebSockets.WebSocketCloseStatus.NormalClosure,
            "done",
            CancellationToken.None);
    }

    [Test]
    public async Task SampleVoice1_OpenResponseTimeoutCancelsApplicationGeneration()
    {
        DelayedVoiceSupportHandler.Reset();
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddAgentServerCore();
        builder.Services.AddVoice<DelayedVoiceSupportHandler>();
        await using var app = builder.Build();
        app.UseAgentServerCore();
        app.MapInvocationsServer();
        await app.StartAsync();
        var wsClient = app.GetTestServer().CreateWebSocketClient();
        using var ws = await wsClient.ConnectAsync(
            new Uri(app.GetTestServer().BaseAddress, "invocations_ws"),
            CancellationToken.None);

        await SendJsonAsync(ws, new
        {
            type = "session.start",
            id = "m_start",
            ts = "2026-08-13T00:00:00.000Z",
            protocol_version = "1.0",
            reconnect = false,
            response_timeouts = new
            {
                first_output_ms = 5000,
                idle_ms = 8000,
                max_duration_ms = 60000,
            },
        });
        _ = await ReceiveJsonAsync(ws);
        await SendJsonAsync(ws, new
        {
            type = "user.message",
            id = "m_user",
            ts = "2026-08-13T00:00:01.000Z",
            item_id = "in_1",
            content = new[] { new { type = "input_text", text = "hello" } },
        });
        await DelayedVoiceSupportHandler.Started.Task.WaitAsync(TimeSpan.FromSeconds(2));
        var created = await ReceiveJsonAsync(ws).WaitAsync(TimeSpan.FromSeconds(2));
        Assert.That(created.GetProperty("type").GetString(), Is.EqualTo("response.created"));

        try
        {
            await SendJsonAsync(ws, new
            {
                type = "response.timeout",
                id = "m_timeout",
                ts = "2026-08-13T00:00:02.000Z",
                response_id = created.GetProperty("response_id").GetString(),
                stage = "first_output",
            });

            await DelayedVoiceSupportHandler.Cancelled.Task.WaitAsync(TimeSpan.FromSeconds(2));
        }
        finally
        {
            await ws.CloseOutputAsync(
                System.Net.WebSockets.WebSocketCloseStatus.NormalClosure,
                "done",
                CancellationToken.None);
        }
    }

    [Test]
    public async Task SampleVoice1_ResponseCreatedPreservesInputOrder()
    {
        OrderedVoiceSupportHandler.Reset();
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddAgentServerCore();
        builder.Services.AddVoice<OrderedVoiceSupportHandler>();
        await using var app = builder.Build();
        app.UseAgentServerCore();
        app.MapInvocationsServer();
        await app.StartAsync();
        var wsClient = app.GetTestServer().CreateWebSocketClient();
        using var ws = await wsClient.ConnectAsync(
            new Uri(app.GetTestServer().BaseAddress, "invocations_ws"),
            CancellationToken.None);

        await StartVoiceSessionAsync(ws);
        await SendVoiceUserMessageAsync(ws, "m_first", "in_1", "first");
        await OrderedVoiceSupportHandler.FirstStarted.Task.WaitAsync(TimeSpan.FromSeconds(2));
        await SendVoiceUserMessageAsync(ws, "m_second", "in_2", "second");

        try
        {
            var firstCreated = await ReceiveJsonAsync(ws).WaitAsync(TimeSpan.FromSeconds(2));
            Assert.Multiple(() =>
            {
                Assert.That(firstCreated.GetProperty("type").GetString(), Is.EqualTo("response.created"));
                Assert.That(
                    firstCreated.GetProperty("in_reply_to")[0].GetString(),
                    Is.EqualTo("in_1"));
            });
        }
        finally
        {
            OrderedVoiceSupportHandler.ReleaseFirst.TrySetResult();
            await ws.CloseOutputAsync(
                System.Net.WebSockets.WebSocketCloseStatus.NormalClosure,
                "done",
                CancellationToken.None);
        }
    }

    [Test]
    public async Task SampleVoice1_GenerationFailureOpensResponseBeforeError()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddAgentServerCore();
        builder.Services.AddVoice<FailingVoiceSupportHandler>();
        await using var app = builder.Build();
        app.UseAgentServerCore();
        app.MapInvocationsServer();
        await app.StartAsync();
        var wsClient = app.GetTestServer().CreateWebSocketClient();
        using var ws = await wsClient.ConnectAsync(
            new Uri(app.GetTestServer().BaseAddress, "invocations_ws"),
            CancellationToken.None);

        await StartVoiceSessionAsync(ws);
        await SendVoiceUserMessageAsync(ws, "m_failure", "in_1", "fail");
        var created = await ReceiveJsonAsync(ws).WaitAsync(TimeSpan.FromSeconds(2));
        var error = await ReceiveJsonAsync(ws).WaitAsync(TimeSpan.FromSeconds(2));

        Assert.Multiple(() =>
        {
            Assert.That(created.GetProperty("type").GetString(), Is.EqualTo("response.created"));
            Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("error"));
            Assert.That(
                error.GetProperty("response_id").GetString(),
                Is.EqualTo(created.GetProperty("response_id").GetString()));
        });
        await ws.CloseOutputAsync(
            System.Net.WebSockets.WebSocketCloseStatus.NormalClosure,
            "done",
            CancellationToken.None);
    }

    private static async Task StartVoiceSessionAsync(System.Net.WebSockets.WebSocket ws)
    {
        await SendJsonAsync(ws, new
        {
            type = "session.start",
            id = "m_start",
            ts = "2026-08-13T00:00:00.000Z",
            protocol_version = "1.0",
            reconnect = false,
            response_timeouts = new
            {
                first_output_ms = 5000,
                idle_ms = 8000,
                max_duration_ms = 60000,
            },
        });
        var ready = await ReceiveJsonAsync(ws).WaitAsync(TimeSpan.FromSeconds(2));
        Assert.That(ready.GetProperty("type").GetString(), Is.EqualTo("session.ready"));
    }

    private static Task SendVoiceUserMessageAsync(
        System.Net.WebSockets.WebSocket ws,
        string messageId,
        string itemId,
        string text) =>
        SendJsonAsync(ws, new
        {
            type = "user.message",
            id = messageId,
            ts = "2026-08-13T00:00:01.000Z",
            item_id = itemId,
            content = new[] { new { type = "input_text", text } },
        });

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

    private sealed class DelayedVoiceSupportHandler : Snippets.SampleVoice1Snippets.VoiceSupportHandler
    {
        public DelayedVoiceSupportHandler()
            : base(NullLogger<Snippets.SampleVoice1Snippets.VoiceSupportHandler>.Instance)
        {
        }

        public static TaskCompletionSource Started { get; private set; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public static TaskCompletionSource Cancelled { get; private set; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public static void Reset()
        {
            Started = new(TaskCreationOptions.RunContinuationsAsynchronously);
            Cancelled = new(TaskCreationOptions.RunContinuationsAsynchronously);
        }

        protected override async Task<string> GenerateAnswerAsync(
            string input,
            CancellationToken cancellationToken)
        {
            Started.TrySetResult();
            try
            {
                await Task.Delay(Timeout.InfiniteTimeSpan, cancellationToken);
                return input;
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                Cancelled.TrySetResult();
                throw;
            }
        }
    }

    private sealed class OrderedVoiceSupportHandler : Snippets.SampleVoice1Snippets.VoiceSupportHandler
    {
        public OrderedVoiceSupportHandler()
            : base(NullLogger<Snippets.SampleVoice1Snippets.VoiceSupportHandler>.Instance)
        {
        }

        public static TaskCompletionSource FirstStarted { get; private set; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public static TaskCompletionSource ReleaseFirst { get; private set; } =
            new(TaskCreationOptions.RunContinuationsAsynchronously);

        public static void Reset()
        {
            FirstStarted = new(TaskCreationOptions.RunContinuationsAsynchronously);
            ReleaseFirst = new(TaskCreationOptions.RunContinuationsAsynchronously);
        }

        protected override async Task<string> GenerateAnswerAsync(
            string input,
            CancellationToken cancellationToken)
        {
            if (input == "first")
            {
                FirstStarted.TrySetResult();
                await ReleaseFirst.Task.WaitAsync(cancellationToken);
            }
            return $"You said: {input}";
        }
    }

    private sealed class FailingVoiceSupportHandler : Snippets.SampleVoice1Snippets.VoiceSupportHandler
    {
        public FailingVoiceSupportHandler()
            : base(NullLogger<Snippets.SampleVoice1Snippets.VoiceSupportHandler>.Instance)
        {
        }

        protected override Task<string> GenerateAnswerAsync(
            string input,
            CancellationToken cancellationToken) =>
            Task.FromException<string>(new InvalidOperationException("generation failed"));
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
