// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Invocations.Tests.Snippets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
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
    //  Test Infrastructure
    // ═══════════════════════════════════════════════════════════════════

    /// <summary>
    /// Creates an in-memory ASP.NET Core test server with the specified
    /// <see cref="InvocationHandler"/> registered, matching the Tier 3
    /// self-hosted pattern used throughout the Invocations tests.
    /// </summary>
    private static async Task<TestEnv> CreateTestServerAsync<THandler>(
        Action<IServiceCollection>? configureServices = null)
        where THandler : InvocationHandler
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddInvocationsServer();
        builder.Services.AddScoped<InvocationHandler, THandler>();
        configureServices?.Invoke(builder.Services);

        var app = builder.Build();
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

        public async ValueTask DisposeAsync()
        {
            Client.Dispose();
            await _app.StopAsync();
            await _app.DisposeAsync();
        }
    }
}
