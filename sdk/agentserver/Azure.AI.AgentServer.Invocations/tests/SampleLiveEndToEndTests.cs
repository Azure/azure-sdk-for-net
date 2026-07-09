// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Streaming;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Invocations.Tests.Snippets;
using Azure.Core;
using Azure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OpenAI;
using OpenAI.Responses;

#pragma warning disable OPENAI001 // The OpenAI Responses API is experimental.

namespace Azure.AI.AgentServer.Invocations.Tests;

/// <summary>
/// Live end-to-end tests for the resilient samples that call a real Azure AI Foundry
/// model. Excluded from CI (Category = "Live"). Unlike the deterministic E2E tests, these
/// genuinely stream tokens from the model through the documented durable producer methods,
/// validating the full Task⇄Stream bridge against a real backend.
/// </summary>
/// <remarks>
/// Requires environment variables (the model is reached with <see cref="DefaultAzureCredential"/>):
/// <list type="bullet">
///   <item><c>AZURE_AGENTSERVER_FOUNDRY_ENDPOINT</c> — Foundry project endpoint, e.g.
///   <c>https://rapida-5196-resource.services.ai.azure.com/api/projects/rapida-5196</c>.</item>
///   <item><c>AZURE_AGENTSERVER_FOUNDRY_MODEL</c> — model deployment, e.g. <c>gpt-5.4-nano</c>.</item>
/// </list>
/// Optional: <c>AZURE_AGENTSERVER_FOUNDRY_SCOPE</c> (token scope, default
/// <c>https://cognitiveservices.azure.com/.default</c>). The model is reached over the
/// Azure OpenAI-compatible <c>/openai/v1</c> surface on the resource host, so no
/// <c>api-version</c> is required.
/// </remarks>
[TestFixture]
[Category("Live")]
public class SampleLiveEndToEndTests
{
    private string _endpoint = string.Empty;
    private string _model = string.Empty;
    private string _scope = "https://cognitiveservices.azure.com/.default";

    [SetUp]
    public void Setup()
    {
        _endpoint = Environment.GetEnvironmentVariable("AZURE_AGENTSERVER_FOUNDRY_ENDPOINT") ?? string.Empty;
        _model = Environment.GetEnvironmentVariable("AZURE_AGENTSERVER_FOUNDRY_MODEL") ?? string.Empty;
        _scope = Environment.GetEnvironmentVariable("AZURE_AGENTSERVER_FOUNDRY_SCOPE")
            ?? "https://cognitiveservices.azure.com/.default";

        if (string.IsNullOrEmpty(_endpoint) || string.IsNullOrEmpty(_model))
        {
            Assert.Ignore(
                "Live tests require AZURE_AGENTSERVER_FOUNDRY_ENDPOINT and " +
                "AZURE_AGENTSERVER_FOUNDRY_MODEL environment variables to be set. " +
                "Example: AZURE_AGENTSERVER_FOUNDRY_ENDPOINT=https://rapida-5196-resource.services.ai.azure.com/api/projects/rapida-5196 " +
                "AZURE_AGENTSERVER_FOUNDRY_MODEL=gpt-5.4-nano");
        }
    }

    [Test]
    public async Task LiveResilientResearch_StreamsFromFoundry()
    {
        // Genuinely streams model output through the documented research producer, which
        // makes real OpenAI Responses streaming calls per sub-call.
        await using var env = await CreateLiveResearchServerAsync();

        var request = new HttpRequestMessage(HttpMethod.Post, "/invocations")
        {
            Content = new StringContent(
                """{"Topic":"benefits of TypeSpec for API design"}""",
                Encoding.UTF8, "application/json"),
        };
        request.Headers.TryAddWithoutValidation("Accept", "text/event-stream");
        var response = await env.Client.SendAsync(request);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content.Headers.ContentType?.MediaType,
            Is.EqualTo("text/event-stream"));

        var body = await response.Content.ReadAsStringAsync();
        Assert.That(body, Does.Contain("data: "));
        Assert.That(body, Does.Contain("\"token\""), "Stream should carry real model token events.");
        Assert.That(body, Does.Contain("\"done\""), "Stream should terminate with a done event.");
    }

    [Test]
    public async Task LiveResilientResearch_GetResumesFromCursor()
    {
        // RESUME is GET /invocations/{id} (not a re-POST). It re-attaches to the existing
        // durable stream after the supplied cursor.
        await using var env = await CreateLiveResearchServerAsync();

        var invocationId = "live-research-" + Guid.NewGuid().ToString("N");

        var start = new HttpRequestMessage(HttpMethod.Post, "/invocations")
        {
            Content = new StringContent(
                """{"Topic":"resumable streaming"}""", Encoding.UTF8, "application/json"),
        };
        start.Headers.TryAddWithoutValidation("Accept", "text/event-stream");
        start.Headers.Add("x-agent-invocation-id", invocationId);
        var startResponse = await env.Client.SendAsync(start);
        var original = ParseSse(await startResponse.Content.ReadAsStringAsync());
        Assert.That(original, Has.Count.GreaterThanOrEqualTo(2));

        int resumeAfter = original[0].Cursor;
        var resume = new HttpRequestMessage(HttpMethod.Get, $"/invocations/{invocationId}?last_event_id={resumeAfter}");
        resume.Headers.TryAddWithoutValidation("Accept", "text/event-stream");
        var resumeResponse = await env.Client.SendAsync(resume);
        Assert.That(resumeResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var replayed = ParseSse(await resumeResponse.Content.ReadAsStringAsync());

        Assert.That(replayed[0].Cursor, Is.EqualTo(resumeAfter + 1),
            "GET resume should yield only events after the supplied cursor.");
    }

    [Test]
    public async Task LiveResilientMultiturn_ConversationPersistsAcrossTurns()
    {
        await using var env = await CreateLiveMultiturnServerAsync();
        var sessionId = "live-conv-" + Guid.NewGuid().ToString("N")[..8];

        var response1 = await env.Client.PostAsync(
            $"/invocations?agent_session_id={sessionId}",
            new StringContent("""{"Message":"What is Rust?"}""", Encoding.UTF8, "application/json"));
        Assert.That(response1.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc1 = JsonDocument.Parse(await response1.Content.ReadAsStringAsync());
        Assert.That(doc1.RootElement.GetProperty("turn").GetInt32(), Is.EqualTo(1));

        var response2 = await env.Client.PostAsync(
            $"/invocations?agent_session_id={sessionId}",
            new StringContent("""{"Message":"Compare it to Go in one sentence."}""", Encoding.UTF8, "application/json"));
        Assert.That(response2.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc2 = JsonDocument.Parse(await response2.Content.ReadAsStringAsync());
        Assert.That(doc2.RootElement.GetProperty("turn").GetInt32(), Is.EqualTo(2));
        Assert.That(doc2.RootElement.GetProperty("reply").GetString(), Is.Not.Empty);
    }

    private static List<(int Cursor, string Type)> ParseSse(string body)
    {
        var events = new List<(int Cursor, string Type)>();
        int cursor = 0;
        foreach (var line in body.Split('\n'))
        {
            if (line.StartsWith("id: ", StringComparison.Ordinal))
            {
                int.TryParse(line["id: ".Length..].Trim(), out cursor);
            }
            else if (line.StartsWith("data: ", StringComparison.Ordinal))
            {
                using var doc = JsonDocument.Parse(line["data: ".Length..]);
                events.Add((cursor, doc.RootElement.GetProperty("Type").GetString() ?? string.Empty));
            }
        }

        return events;
    }

    // ═══════════════════════════════════════════════════════════════════
    //  Real-model token streaming (DefaultAzureCredential + chat completions)
    // ═══════════════════════════════════════════════════════════════════

    /// <summary>
    /// Streams assistant tokens from the configured Foundry chat-completions deployment,
    /// authenticating with <see cref="DefaultAzureCredential"/>. Yields each content delta.
    /// </summary>
    private async IAsyncEnumerable<string> StreamModelTokensAsync(
        string prompt, [EnumeratorCancellation] CancellationToken ct)
    {
        var credential = new DefaultAzureCredential();
        AccessToken token = await credential.GetTokenAsync(
            new TokenRequestContext(new[] { _scope }), ct);

        using var http = new HttpClient();
        http.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Token);

        var url = $"{OpenAIv1Base()}/chat/completions";
        var requestBody = new
        {
            model = _model,
            stream = true,
            messages = new[]
            {
                new { role = "user", content = prompt },
            },
        };

        using var request = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = JsonContent.Create(requestBody),
        };

        using var response = await http.SendAsync(
            request, HttpCompletionOption.ResponseHeadersRead, ct);
        response.EnsureSuccessStatusCode();

        using var stream = await response.Content.ReadAsStreamAsync(ct);
        using var reader = new System.IO.StreamReader(stream);

        string? line;
        while ((line = await reader.ReadLineAsync(ct)) is not null)
        {
            if (!line.StartsWith("data:", StringComparison.Ordinal))
            {
                continue;
            }

            var payload = line["data:".Length..].Trim();
            if (payload.Length == 0 || payload == "[DONE]")
            {
                continue;
            }

            string? delta = TryExtractDelta(payload);
            if (!string.IsNullOrEmpty(delta))
            {
                yield return delta!;
            }
        }
    }

    private static string? TryExtractDelta(string ssePayload)
    {
        try
        {
            using var doc = JsonDocument.Parse(ssePayload);
            if (doc.RootElement.TryGetProperty("choices", out var choices)
                && choices.GetArrayLength() > 0
                && choices[0].TryGetProperty("delta", out var deltaEl)
                && deltaEl.TryGetProperty("content", out var contentEl))
            {
                return contentEl.GetString();
            }
        }
        catch (JsonException)
        {
            // Skip non-JSON keepalive frames.
        }

        return null;
    }

    private async Task<string> AggregateModelReplyAsync(string prompt, CancellationToken ct)
    {
        var sb = new StringBuilder();
        await foreach (var t in StreamModelTokensAsync(prompt, ct))
        {
            sb.Append(t);
        }

        return sb.ToString();
    }

    // ═══════════════════════════════════════════════════════════════════
    //  Live Server Factories (use documented producers with the real model)
    // ═══════════════════════════════════════════════════════════════════

    // Constructs a REAL OpenAI Responses client pointed at the Azure OpenAI-compatible
    // `/openai/v1` endpoint on the Foundry resource host. The AAD bearer token is supplied
    // as the API key, so the SDK sends `Authorization: Bearer <token>`; the v1 surface needs
    // no api-version query parameter.
    private ResponsesClient CreateLiveResponsesClient()
    {
        var credential = new DefaultAzureCredential();
        AccessToken token = credential.GetToken(
            new TokenRequestContext(new[] { _scope }), CancellationToken.None);

        return new ResponsesClient(
            new ApiKeyCredential(token.Token),
            new OpenAIClientOptions { Endpoint = new Uri(OpenAIv1Base()) });
    }

    // Derives the Azure OpenAI v1-compatible base (`https://{host}/openai/v1`) from the
    // configured Foundry endpoint, discarding any `/api/projects/...` project path.
    private string OpenAIv1Base()
    {
        var uri = new Uri(_endpoint);
        return $"{uri.Scheme}://{uri.Authority}/openai/v1";
    }

    private async Task<LiveTestEnv> CreateLiveResearchServerAsync()
    {
        ResponsesClient model = CreateLiveResponsesClient();
        var checkpointStore = new SampleResilientResearchSnippets.CheckpointStore(
            Path.Combine(Path.GetTempPath(), "live-research-" + Guid.NewGuid().ToString("N")));

        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddInvocationsServer();
        builder.Services.AddScoped<InvocationHandler,
            SampleResilientResearchSnippets.ResilientResearchHandler>();

        builder.Services.AddEventStreams(o => o.UseInMemoryReplay(
            cursor: payload => ((SampleResilientResearchSnippets.ResearchEvent)payload).Cursor,
            ttl: TimeSpan.FromMinutes(5)));

        builder.Services.AddResilientTasks()
            .AddMultiTurnTask<SampleResilientResearchSnippets.ResearchRequest,
                     SampleResilientResearchSnippets.ResearchResult>(
                "research",
                (provider, ctx, ct) => SampleResilientResearchSnippets.RunResearchAsync(
                    provider.GetRequiredService<IEventStreamRegistry>(), model, _model, ctx, checkpointStore,
                    numPhases: 2, callsPerPhase: 2, ct: ct),
                steerable: true);

        var app = builder.Build();
        app.MapInvocationsServer();
        await app.StartAsync();

        return new LiveTestEnv(app);
    }

    private async Task<LiveTestEnv> CreateLiveMultiturnServerAsync()
    {
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        builder.Services.AddInvocationsServer();
        builder.Services.AddScoped<InvocationHandler,
            SampleResilientMultiturnSnippets.ResilientMultiturnHandler>();

        builder.Services.AddResilientTasks()
            .AddMultiTurnTask<SampleResilientMultiturnSnippets.ConversationInput,
                              SampleResilientMultiturnSnippets.ConversationOutput>(
                "conversation",
                (ctx, ct) => SampleResilientMultiturnSnippets.RunConversationTurnAsync(
                    ctx,
                    (history, msg, c) => AggregateModelReplyAsync(msg, c),
                    ct),
                steerable: true);

        var app = builder.Build();
        app.MapInvocationsServer();
        await app.StartAsync();

        return new LiveTestEnv(app);
    }

    private sealed class LiveTestEnv : IAsyncDisposable
    {
        private readonly WebApplication _app;

        public LiveTestEnv(WebApplication app)
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
