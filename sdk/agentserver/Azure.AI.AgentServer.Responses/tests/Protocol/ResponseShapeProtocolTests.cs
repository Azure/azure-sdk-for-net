// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol conformance tests for the Models.ResponseObject object shape.
/// Validates required fields, computed properties, and structural invariants.
/// Validates: B31 — Required response fields
/// All assertions use HttpClient + JsonDocument only — no SDK model types in assertions.
/// </summary>
public class ResponseShapeProtocolTests : ProtocolTestBase
{
    [Test]
    public async Task Response_HasAllRequiredTopLevelFields()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);

        var response = await PostResponsesAsync(new { model = "test-model" });
        using var doc = await ParseJsonAsync(response);
        var root = doc.RootElement;

        // All required fields per the API spec
        Assert.That(root.TryGetProperty("id", out _), Is.True, "Missing 'id'");
        Assert.That(root.TryGetProperty("object", out _), Is.True, "Missing 'object'");
        Assert.That(root.TryGetProperty("created_at", out _), Is.True, "Missing 'created_at'");
        Assert.That(root.TryGetProperty("status", out _), Is.True, "Missing 'status'");
        Assert.That(root.TryGetProperty("model", out _), Is.True, "Missing 'model'");
        Assert.That(root.TryGetProperty("output", out _), Is.True, "Missing 'output'");
    }

    [Test]
    public async Task Response_OutputMessage_HasRequiredFields()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);

        var response = await PostResponsesAsync(new { model = "test-model" });
        using var doc = await ParseJsonAsync(response);

        var output = doc.RootElement.GetProperty("output");
        Assert.That(output.GetArrayLength() > 0, Is.True, "Expected at least one output item");

        var firstItem = output[0];
        Assert.That(firstItem.GetProperty("type").GetString(), Is.EqualTo("message"));
        Assert.That(firstItem.TryGetProperty("id", out _), Is.True, "Output item missing 'id'");
        Assert.That(firstItem.TryGetProperty("role", out _), Is.True, "Output item missing 'role'");
        Assert.That(firstItem.TryGetProperty("content", out _), Is.True, "Output item missing 'content'");
        Assert.That(firstItem.GetProperty("role").GetString(), Is.EqualTo("assistant"));

        var content = firstItem.GetProperty("content");
        Assert.That(content.GetArrayLength() > 0, Is.True, "Expected at least one content part");

        var firstContent = content[0];
        Assert.That(firstContent.GetProperty("type").GetString(), Is.EqualTo("output_text"));
        Assert.That(firstContent.TryGetProperty("text", out _), Is.True, "Content part missing 'text'");
    }

    [Test]
    public async Task Response_OutputText_NotReturnedByServer()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);

        var response = await PostResponsesAsync(new { model = "test-model" });
        using var doc = await ParseJsonAsync(response);

        // output_text is a client SDK convenience property; the server should never return it.
        Assert.That(doc.RootElement.TryGetProperty("output_text", out _), Is.False);
    }

    [Test]
    public async Task Response_Object_IsAlwaysResponse()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleStream(ctx);

        var response = await PostResponsesAsync(new { model = "any-model" });
        using var doc = await ParseJsonAsync(response);

        Assert.That(doc.RootElement.GetProperty("object").GetString(), Is.EqualTo("response"));
    }

    [Test]
    public async Task Response_CreatedAt_IsUnixEpochSeconds()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleStream(ctx);

        var beforeRequest = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        var response = await PostResponsesAsync(new { model = "test-model" });
        using var doc = await ParseJsonAsync(response);

        var afterRequest = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        var createdAt = doc.RootElement.GetProperty("created_at").GetInt64();

        // created_at should be a Unix epoch second within the request window
        XAssert.InRange(createdAt, beforeRequest, afterRequest);
    }

    // ── Helper event factories ─────────────────────────────────

    private static async IAsyncEnumerable<ResponseStreamEvent> SimpleStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();
        yield return stream.EmitCompleted();
    }

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
        yield return text.EmitDone("Hello");

        yield return message.EmitContentDone(text);
        yield return message.EmitDone();

        yield return stream.EmitCompleted();
    }
}
