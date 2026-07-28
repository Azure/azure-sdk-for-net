// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Interop;

/// <summary>
/// Live resilience interop tests (T061, FR-084). These are authored-but-not-run in CI: they are
/// tagged <c>[Category("Live")]</c> so <c>TestCategory!=Live</c> excludes them, and each test
/// <see cref="Assert.Ignore(string)"/>s when the required live configuration is absent (which is
/// always the case in the CI/dev sandbox, since there are no live credentials there). They compile
/// as part of the normal test build and document the real-backend flows that only a live run can
/// exercise:
/// <list type="bullet">
/// <item>hosted provider auto-selection (Foundry task/response stores chosen from environment);</item>
/// <item>one resilient non-stream recovery path against a real backend;</item>
/// <item>one resilient streaming reconnect path against a real backend;</item>
/// <item>actionable failures when the hosted configuration is missing/incomplete.</item>
/// </list>
/// </summary>
/// <remarks>
/// Live configuration (all via environment variables; none are present in the sandbox):
/// <list type="bullet">
///   <item><c>FOUNDRY_PROJECT_ENDPOINT</c> — enables hosted task/response provider auto-selection.</item>
///   <item><c>AZURE_AGENTSERVER_FOUNDRY_ENDPOINT</c> / <c>AZURE_AGENTSERVER_FOUNDRY_MODEL</c> — a
///   reachable model deployment for genuine end-to-end streaming.</item>
///   <item><c>AGENTSERVER_TASKS_BACKEND=hosted|local</c> — override the task-store auto-selection.</item>
/// </list>
/// </remarks>
[TestFixture]
[Category("Live")]
public class ResilienceLiveTests
{
    private const string FoundryProjectEndpointVar = "FOUNDRY_PROJECT_ENDPOINT";
    private const string ModelEndpointVar = "AZURE_AGENTSERVER_FOUNDRY_ENDPOINT";
    private const string ModelDeploymentVar = "AZURE_AGENTSERVER_FOUNDRY_MODEL";
    private const string TasksBackendVar = "AGENTSERVER_TASKS_BACKEND";

    private static StringContent Json(object body)
        => new(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");

    private static string? Env(string name)
    {
        var value = Environment.GetEnvironmentVariable(name);
        return string.IsNullOrWhiteSpace(value) ? null : value;
    }

    private static void RequireHostedConfig()
    {
        if (Env(FoundryProjectEndpointVar) is null)
        {
            Assert.Ignore(
                $"Live test requires {FoundryProjectEndpointVar} (a Foundry project endpoint) so the "
                + "framework can auto-select the hosted task/response providers. Not set in this "
                + "environment — authored-but-not-run.");
        }
    }

    private static void RequireModelConfig()
    {
        if (Env(ModelEndpointVar) is null || Env(ModelDeploymentVar) is null)
        {
            Assert.Ignore(
                $"Live test requires {ModelEndpointVar} and {ModelDeploymentVar} to reach a real model "
                + "deployment. Not set in this environment — authored-but-not-run.");
        }
    }

    // ---- Hosted provider auto-selection ----

    [Test]
    public async Task HostedProviderAutoSelection_WhenFoundryEndpointSet_HostStartsResilient()
    {
        RequireHostedConfig();

        // With FOUNDRY_PROJECT_ENDPOINT set and no explicit store, the framework auto-selects the
        // hosted task/response providers; a resilient background host must start without a local
        // store override and accept a resilient background POST.
        using var factory = new TestWebApplicationFactory(
            new TestHandler { EventFactory = SimpleCompletedHandler },
            configureOptions: o => o.ResilientBackground = true);
        using var client = factory.CreateClient();

        var response = await client.PostAsync(
            "/responses",
            Json(new { model = Env(ModelDeploymentVar) ?? "test", store = true, background = true }));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
            "hosted auto-selection must let a resilient background POST be accepted");
    }

    // ---- Resilient non-stream recovery path ----

    [Test]
    public async Task ResilientNonStreamRecovery_CompletesAgainstRealBackend()
    {
        RequireHostedConfig();
        RequireModelConfig();

        using var factory = new TestWebApplicationFactory(
            new TestHandler { EventFactory = SimpleCompletedHandler },
            configureOptions: o => o.ResilientBackground = true);
        using var client = factory.CreateClient();

        var create = await client.PostAsync(
            "/responses",
            Json(new { model = Env(ModelDeploymentVar), input = "Hello", store = true, background = true }));
        Assert.That(create.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var doc = JsonDocument.Parse(await create.Content.ReadAsStringAsync());
        var id = doc.RootElement.GetProperty("id").GetString()!;

        // The resilient background turn reaches a terminal 'completed' — the recovery-capable path is
        // engaged even on the happy path (Row 1 Path A).
        await WaitForStatusAsync(client, id, "completed", TimeSpan.FromSeconds(60));
    }

    // ---- Resilient streaming reconnect path ----

    [Test]
    public async Task ResilientStreamingReconnect_ReplaysContiguousSuffixAgainstRealBackend()
    {
        RequireHostedConfig();
        RequireModelConfig();

        using var factory = new TestWebApplicationFactory(
            new TestHandler { EventFactory = SimpleStreamingHandler },
            configureOptions: o => o.ResilientBackground = true);
        using var client = factory.CreateClient();

        using var request = new HttpRequestMessage(HttpMethod.Post, "/responses")
        {
            Content = Json(new { model = Env(ModelDeploymentVar), input = "Stream please", stream = true, store = true, background = true }),
        };
        using var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        string? id = null;
        await using (var stream = await response.Content.ReadAsStreamAsync())
        using (var reader = new StreamReader(stream))
        {
            string? line;
            while ((line = await reader.ReadLineAsync()) is not null)
            {
                if (!line.StartsWith("data: ", StringComparison.Ordinal))
                {
                    continue;
                }

                using var evt = JsonDocument.Parse(line["data: ".Length..]);
                if (evt.RootElement.TryGetProperty("response", out var r)
                    && r.TryGetProperty("id", out var idProp))
                {
                    id = idProp.GetString();
                    break;
                }
            }
        }

        Assert.That(id, Is.Not.Null, "the streaming POST must yield a response id");

        // Reconnect with a cursor and replay a strict, contiguous suffix.
        var seqs = new List<long>();
        using var reconnect = await client.GetAsync(
            $"/responses/{id}?stream=true&starting_after=0",
            HttpCompletionOption.ResponseHeadersRead);
        Assert.That(reconnect.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        await using (var stream = await reconnect.Content.ReadAsStreamAsync())
        using (var reader = new StreamReader(stream))
        {
            string? line;
            while ((line = await reader.ReadLineAsync()) is not null)
            {
                if (!line.StartsWith("data: ", StringComparison.Ordinal))
                {
                    continue;
                }

                using var evt = JsonDocument.Parse(line["data: ".Length..]);
                if (evt.RootElement.TryGetProperty("sequence_number", out var seqProp))
                {
                    seqs.Add(seqProp.GetInt64());
                }

                if (evt.RootElement.TryGetProperty("type", out var typeProp)
                    && typeProp.GetString() is "response.completed" or "response.failed" or "response.incomplete")
                {
                    break;
                }
            }
        }

        for (var i = 1; i < seqs.Count; i++)
        {
            Assert.That(seqs[i], Is.EqualTo(seqs[i - 1] + 1),
                $"reconnect replay must be contiguous; got [{string.Join(",", seqs)}]");
        }
    }

    // ---- Actionable config-missing failure ----

    [Test]
    public void MissingHostedConfig_ForHostedBackend_FailsActionably()
    {
        // Force the hosted task backend but withhold the endpoint: the framework must fail loudly with
        // an actionable message rather than silently downgrading to a local store.
        if (!string.Equals(Env(TasksBackendVar), "hosted", StringComparison.OrdinalIgnoreCase)
            || Env(FoundryProjectEndpointVar) is not null)
        {
            Assert.Ignore(
                $"Live test requires {TasksBackendVar}=hosted WITHOUT {FoundryProjectEndpointVar} to "
                + "provoke the config-missing failure. Not configured in this environment.");
        }

        var ex = Assert.Catch(() =>
        {
            using var factory = new TestWebApplicationFactory(
                new TestHandler { EventFactory = SimpleCompletedHandler },
                configureOptions: o => o.ResilientBackground = true);
            using var client = factory.CreateClient();
        });

        Assert.That(ex, Is.Not.Null);
        Assert.That(
            ex!.ToString(),
            Does.Contain(FoundryProjectEndpointVar).Or.Contain("hosted").Or.Contain("endpoint"),
            "the failure must name the missing hosted configuration");
    }

    // ---- Handlers ----

    private static async IAsyncEnumerable<ResponseStreamEvent> SimpleCompletedHandler(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken ct)
    {
        await Task.CompletedTask;
        var response = new ResponseObject(context.ResponseId, request.Model ?? "test");
        yield return new ResponseCreatedEvent(0, response);
        response.SetCompleted();
        yield return new ResponseCompletedEvent(0, response);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> SimpleStreamingHandler(
        CreateResponse request,
        ResponseContext context,
        [EnumeratorCancellation] CancellationToken ct)
    {
        var stream = new ResponseEventStream(context, request);
        yield return stream.EmitCreated();
        yield return stream.EmitInProgress();
        foreach (var evt in stream.OutputItemMessage("Live stream token."))
        {
            yield return evt;
        }

        await context.ConversationChainMetadata.FlushAsync(ct);
        yield return stream.EmitCompleted();
    }

    private static async Task WaitForStatusAsync(HttpClient client, string responseId, string expected, TimeSpan timeout)
    {
        var deadline = DateTime.UtcNow + timeout;
        string? last = null;
        while (DateTime.UtcNow < deadline)
        {
            var get = await client.GetAsync($"/responses/{responseId}");
            if (get.StatusCode == HttpStatusCode.OK)
            {
                using var doc = JsonDocument.Parse(await get.Content.ReadAsStringAsync());
                last = doc.RootElement.GetProperty("status").GetString();
                if (last is "completed" or "failed" or "cancelled" or "incomplete")
                {
                    Assert.That(last, Is.EqualTo(expected));
                    return;
                }
            }

            await Task.Delay(200);
        }

        Assert.Fail($"Response '{responseId}' did not reach a terminal state within {timeout} (last: {last ?? "none"}).");
    }
}
