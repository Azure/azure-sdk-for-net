// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol conformance tests for optional <c>model</c> field on <c>CreateResponse</c> (US4).
/// Validates that <c>model</c> can be omitted, resolved via default, and that explicit
/// values take precedence.
/// </summary>
public class OptionalModelProtocolTests : ProtocolTestBase
{
    // ── T037: No model + DefaultModel configured → uses default ──

    [Test]
    public async Task POST_NoModel_WithDefaultModel_UsesConfiguredDefault()
    {
        using var factory = new TestWebApplicationFactory(Handler, options =>
        {
            options.DefaultModel = "gpt-4o-default";
        });
        using var client = factory.CreateClient();

        var response = await client.PostAsync("/responses",
            new StringContent("""{"instructions":"hello"}""",
                System.Text.Encoding.UTF8, "application/json"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        Assert.That(doc.RootElement.GetProperty("model").GetString(), Is.EqualTo("gpt-4o-default"));
    }

    // ── T038: Explicit model overrides DefaultModel ─────────────

    [Test]
    public async Task POST_ExplicitModel_OverridesDefaultModel()
    {
        using var factory = new TestWebApplicationFactory(Handler, options =>
        {
            options.DefaultModel = "gpt-4o-default";
        });
        using var client = factory.CreateClient();

        var response = await client.PostAsync("/responses",
            new StringContent("""{"model":"gpt-4o","instructions":"hello"}""",
                System.Text.Encoding.UTF8, "application/json"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        Assert.That(doc.RootElement.GetProperty("model").GetString(), Is.EqualTo("gpt-4o"));
    }

    // ── T039: No model + no DefaultModel → empty string ─────────

    [Test]
    public async Task POST_NoModel_NoDefaultModel_UsesEmptyString()
    {
        var response = await PostResponsesAsync("""{"instructions":"hello"}""");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var doc = await ParseJsonAsync(response);
        Assert.That(doc.RootElement.GetProperty("model").GetString(), Is.EqualTo(""));
    }

    // ── T040: Streaming no model + DefaultModel → response.created has default ──

    [Test]
    public async Task POST_Streaming_NoModel_WithDefaultModel_CreatedEventHasDefault()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleStream(ctx, req);

        using var factory = new TestWebApplicationFactory(Handler, options =>
        {
            options.DefaultModel = "gpt-4o-streaming-default";
        });
        using var client = factory.CreateClient();

        var response = await client.PostAsync("/responses",
            new StringContent("""{"instructions":"hello","stream":true}""",
                System.Text.Encoding.UTF8, "application/json"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var body = await response.Content.ReadAsStringAsync();
        var events = SseParser.Parse(body);

        var createdEvent = events.First(e => e.EventType == "response.created");
        using var doc = JsonDocument.Parse(createdEvent.Data);
        var resp = doc.RootElement.GetProperty("response");
        Assert.That(resp.GetProperty("model").GetString(), Is.EqualTo("gpt-4o-streaming-default"));
    }

    // ── T041: model: "" (empty string) is valid and accepted ────

    [Test]
    public async Task POST_EmptyStringModel_IsAcceptedAsIs()
    {
        var response = await PostResponsesAsync("""{"model":"","instructions":"hello"}""");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        using var doc = await ParseJsonAsync(response);
        Assert.That(doc.RootElement.GetProperty("model").GetString(), Is.EqualTo(""));
    }

    // ── Helper event factories ─────────────────────────────────

    private static async IAsyncEnumerable<ResponseStreamEvent> SimpleStream(
        ResponseContext ctx,
        CreateResponse request,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(ctx, request);

        yield return stream.EmitCreated();
        yield return stream.EmitCompleted();
    }
}
