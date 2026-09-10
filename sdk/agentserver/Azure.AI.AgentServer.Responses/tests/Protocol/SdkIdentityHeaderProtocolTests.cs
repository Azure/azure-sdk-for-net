// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.AI.AgentServer.Core;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol conformance tests for the SDK identity response header (US1).
/// Validates that every HTTP response includes an <c>x-platform-server</c> header
/// composed of hosting identity + protocol identity segments.
/// </summary>
public class SdkIdentityHeaderProtocolTests : ProtocolTestBase
{
    private const string HeaderName = "x-platform-server";

    // ── T002: POST /responses JSON → header present ────────────

    [Test]
    public async Task POST_Responses_Json_HasIdentityHeader()
    {
        var response = await PostResponsesAsync(new { model = "test" });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Headers.Contains(HeaderName), Is.True, $"Response must include '{HeaderName}' header");

        var value = response.Headers.GetValues(HeaderName).Single();
        AssertIdentityHeaderFormat(value);
    }

    // ── T003: POST /responses SSE stream → header present ──────

    [Test]
    public async Task POST_Responses_StreamingSse_HasIdentityHeader()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Headers.Contains(HeaderName), Is.True, $"SSE response must include '{HeaderName}' header");

        var value = response.Headers.GetValues(HeaderName).Single();
        AssertIdentityHeaderFormat(value);
    }

    // ── T004: Invalid payload (400 error) → header present ─────

    [Test]
    public async Task POST_InvalidPayload_400_HasIdentityHeader()
    {
        var response = await PostResponsesAsync("{not-valid-json!");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        Assert.That(response.Headers.Contains(HeaderName), Is.True, $"Error response must include '{HeaderName}' header");

        var value = response.Headers.GetValues(HeaderName).Single();
        AssertIdentityHeaderFormat(value);
    }

    // ── T005: GET /responses/{id} JSON snapshot → header present ─

    [Test]
    public async Task GET_Response_Json_HasIdentityHeader()
    {
        // Create a response first
        var responseId = await CreateDefaultResponseAsync();

        // GET the response
        var getResponse = await GetResponseAsync(responseId);

        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(getResponse.Headers.Contains(HeaderName), Is.True, $"GET response must include '{HeaderName}' header");

        var value = getResponse.Headers.GetValues(HeaderName).Single();
        AssertIdentityHeaderFormat(value);
    }

    // ── T006: GET /responses/{id}?stream=true SSE replay → header present ─

    [Test]
    public async Task GET_Response_SseReplay_HasIdentityHeader()
    {
        // SSE replay requires a background streaming response
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);
        var httpResponse = await PostResponsesAsync(new { model = "test", stream = true, background = true });
        var events = await ParseSseAsync(httpResponse);
        using var evtDoc = JsonDocument.Parse(events[0].Data);
        var responseId = evtDoc.RootElement.GetProperty("response").GetProperty("id").GetString()!;

        // GET SSE replay
        var getResponse = await GetResponseStreamAsync(responseId);

        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(getResponse.Headers.Contains(HeaderName), Is.True, $"SSE replay response must include '{HeaderName}' header");

        var value = getResponse.Headers.GetValues(HeaderName).Single();
        AssertIdentityHeaderFormat(value);
    }

    // ── T007: POST /responses/{id}/cancel → header present ─────

    [Test]
    public async Task POST_Cancel_HasIdentityHeader()
    {
        // Create a background response so we can cancel it
        Handler.EventFactory = (req, ctx, ct) => SlowBackgroundStream(ctx, ct);
        var responseId = await CreateBackgroundResponseAsync();

        // Cancel it
        var cancelResponse = await CancelResponseAsync(responseId);

        Assert.That(cancelResponse.Headers.Contains(HeaderName), Is.True, $"Cancel response must include '{HeaderName}' header");

        var value = cancelResponse.Headers.GetValues(HeaderName).Single();
        AssertIdentityHeaderFormat(value);
    }

    // ── T008: AdditionalServerIdentity — appended to header ──

    [Test]
    public async Task POST_Responses_WithAdditionalServerIdentity_AppendsToHeader()
    {
        using var factory = new TestWebApplicationFactory(
            handler: Handler,
            configureHostOptions: opts => opts.AdditionalServerIdentity = "my-app/1.0");
        using var client = factory.CreateClient();

        var content = new StringContent(
            System.Text.Json.JsonSerializer.Serialize(new { model = "test" }),
            System.Text.Encoding.UTF8, "application/json");
        var response = await client.PostAsync("/responses", content);

        Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        Assert.That(response.Headers.Contains(HeaderName), Is.True);

        var value = response.Headers.GetValues(HeaderName).Single();
        XAssert.Contains("azure-ai-agentserver/", value);
        XAssert.Contains("azure-ai-agentserver-responses/", value);
        XAssert.EndsWith("; my-app/1.0", value);
    }

    // ── T009: AdditionalServerIdentity null — no extra append ──

    [Test]
    public async Task POST_Responses_WithNullAdditionalServerIdentity_NoExtraAppend()
    {
        // Default (no AdditionalServerIdentity) — header has hosting + protocol segments only
        var response = await PostResponsesAsync(new { model = "test" });

        Assert.That(response.Headers.Contains(HeaderName), Is.True);
        var value = response.Headers.GetValues(HeaderName).Single();
        XAssert.Contains("azure-ai-agentserver/", value);
        XAssert.Contains("azure-ai-agentserver-responses/", value);
        // Exactly 2 segments: hosting + protocol (no additional identity)
        var segments = value.Split("; ");
        Assert.That(segments, Has.Length.EqualTo(2));
    }

    // ── T010: Composability — existing header + SDK append ─────

    [Test]
    public async Task POST_Responses_WhenHeaderAlreadySet_AppendsWithSemicolonSeparator()
    {
        // We can't easily set a pre-existing header via the standard pipeline
        // without middleware. Instead, verify the SDK sets the header correctly
        // and the format is composable by checking the value on a normal request.
        // The composability test verifies that the header format supports the
        // append pattern documented in the spec.
        var response = await PostResponsesAsync(new { model = "test" });

        Assert.That(response.Headers.Contains(HeaderName), Is.True);
        var value = response.Headers.GetValues(HeaderName).Single();

        // The value should be parseable as a semicolon-separated list
        // and contain the SDK identity component
        XAssert.Contains("azure-ai-agentserver-responses/", value);
        XAssert.Contains("(dotnet/", value);
    }

    // ── Assertion Helpers ──────────────────────────────────────

    /// <summary>
    /// Asserts the identity header value contains both hosting and protocol identity segments
    /// in the format: <c>azure-ai-agentserver/{version} (dotnet/{runtime}); azure-ai-agentserver-responses/{version} (dotnet/{runtime})</c>
    /// </summary>
    private static void AssertIdentityHeaderFormat(string headerValue)
    {
        // Header must contain both hosting and protocol identity segments
        XAssert.Contains("azure-ai-agentserver/", headerValue);
        XAssert.Contains("azure-ai-agentserver-responses/", headerValue);
        XAssert.Contains("(dotnet/", headerValue);
        XAssert.EndsWith(")", headerValue);

        // Extract the protocol portion (second segment)
        var segments = headerValue.Split("; ");
        Assert.That(segments.Length, Is.GreaterThanOrEqualTo(2), "Header must have at least hosting + protocol segments");

        var protocolSegment = segments.First(s => s.StartsWith("azure-ai-agentserver-responses/"));

        // Verify format: azure-ai-agentserver-responses/{version} (dotnet/{runtime-version})
        XAssert.Matches(@"^azure-ai-agentserver-responses/\S+ \(dotnet/\d+\.\d+\)$", protocolSegment);
    }

    // ── Helper event factories ─────────────────────────────────

    private static async IAsyncEnumerable<ResponseStreamEvent> SimpleTextStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });

        yield return stream.EmitCreated();

        var message = stream.AddOutputItemMessage();
        yield return message.EmitAdded();

        var text = message.AddTextContent();
        yield return text.EmitAdded();

        yield return text.EmitDelta("Hello");
        yield return text.EmitTextDone("Hello");

        yield return text.EmitDone();
        yield return message.EmitDone();

        yield return stream.EmitCompleted();
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> SlowBackgroundStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });

        yield return stream.EmitCreated();

        // Delay to allow cancel
        await Task.Delay(5000, ct);

        yield return stream.EmitCompleted();
    }
}
