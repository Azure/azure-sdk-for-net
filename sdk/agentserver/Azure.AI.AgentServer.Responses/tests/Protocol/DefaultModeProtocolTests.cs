// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol conformance tests for default mode (stream=false, background=false).
/// All assertions use HttpClient + JsonDocument only — no SDK model types in assertions.
/// </summary>
public class DefaultModeProtocolTests : ProtocolTestBase
{
    [Test]
    public async Task POST_Responses_Returns200_WithJsonContentType()
    {
        var response = await PostResponsesAsync(new { model = "test-model" });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content.Headers.ContentType?.MediaType, Is.EqualTo("application/json"));
    }

    [Test]
    public async Task POST_Responses_Returns_ResponseObject_WithRequiredFields()
    {
        var response = await PostResponsesAsync(new { model = "test-model" });

        using var doc = await ParseJsonAsync(response);
        var root = doc.RootElement;

        // Required top-level fields per the spec
        Assert.That(root.TryGetProperty("id", out var id), Is.True);
        Assert.That(string.IsNullOrEmpty(id.GetString()), Is.False);

        Assert.That(root.GetProperty("object").GetString(), Is.EqualTo("response"));

        Assert.That(root.TryGetProperty("created_at", out var createdAt), Is.True);
        Assert.That(createdAt.ValueKind, Is.EqualTo(JsonValueKind.Number));

        Assert.That(root.TryGetProperty("status", out _), Is.True);
        Assert.That(root.TryGetProperty("model", out _), Is.True);
        Assert.That(root.TryGetProperty("output", out var output), Is.True);
        Assert.That(output.ValueKind, Is.EqualTo(JsonValueKind.Array));
    }

    [Test]
    public async Task POST_Responses_Returns_CompletedStatus()
    {
        var response = await PostResponsesAsync(new { model = "test-model" });

        using var doc = await ParseJsonAsync(response);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));
    }

    [Test]
    // Validates: B22 — Model propagation (response.model matches request model)
    public async Task POST_Responses_Model_MatchesRequestedModel()
    {
        var response = await PostResponsesAsync(new { model = "gpt-4.1-nano" });

        using var doc = await ParseJsonAsync(response);
        Assert.That(doc.RootElement.GetProperty("model").GetString(), Is.EqualTo("gpt-4.1-nano"));
    }

    [Test]
    // Validates that output_text (a client SDK convenience property) is NOT returned by the server.
    public async Task POST_Responses_OutputText_NotReturnedByServer()
    {
        Handler.EventFactory = (req, ctx, ct) => TextEchoStream(req, ctx);

        var response = await PostResponsesAsync(new { model = "test", input = "Hello world" });

        using var doc = await ParseJsonAsync(response);
        // output_text is a client SDK convenience property; the server should never return it.
        Assert.That(doc.RootElement.TryGetProperty("output_text", out _), Is.False);
    }

    [Test]
    // Validates: B6 — Metadata round-trip (metadata key-value preserved through response lifecycle)
    public async Task POST_Responses_Metadata_RoundTrips()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleStream(ctx, req);

        var response = await PostResponsesAsync(new { model = "test", metadata = new { key1 = "value1", key2 = "value2" } });

        using var doc = await ParseJsonAsync(response);
        var metadata = doc.RootElement.GetProperty("metadata");
        Assert.That(metadata.GetProperty("key1").GetString(), Is.EqualTo("value1"));
        Assert.That(metadata.GetProperty("key2").GetString(), Is.EqualTo("value2"));
    }

    [Test]
    public async Task POST_Responses_ExtraFields_AreIgnored()
    {
        // Forward compatibility: extra unknown fields in the request should not cause errors
        var response = await PostResponsesAsync(
            "{\"model\":\"test\",\"unknown_future_field\":\"some_value\",\"another_field\":42}");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(response);
        Assert.That(doc.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));
    }

    // ── Helper event factories ─────────────────────────────────

    private static async IAsyncEnumerable<ResponseStreamEvent> SimpleStream(
        ResponseContext ctx,
        CreateResponse? request = null,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(ctx, request ?? new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();
        yield return stream.EmitCompleted();
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> TextEchoStream(
        CreateResponse request,
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(ctx, request);

        yield return stream.EmitCreated();

        var message = stream.AddOutputItemMessage();
        yield return message.EmitAdded();

        var text = message.AddTextContent();
        yield return text.EmitAdded();

        // Input is BinaryData containing raw JSON — deserialize the string value
        var inputText = request.Input is not null
            ? JsonSerializer.Deserialize<string>(request.Input)
            : "Hello!";
        var echoText = $"Echo: {inputText}";
        yield return text.EmitDelta(echoText);
        yield return text.EmitTextDone(echoText);

        yield return text.EmitDone();
        yield return message.EmitDone();

        yield return stream.EmitCompleted();
    }
}
