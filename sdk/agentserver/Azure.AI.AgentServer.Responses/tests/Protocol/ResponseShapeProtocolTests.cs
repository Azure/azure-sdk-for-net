using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol conformance tests for the Models.Response object shape.
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
        Assert.IsTrue(root.TryGetProperty("id", out _), "Missing 'id'");
        Assert.IsTrue(root.TryGetProperty("object", out _), "Missing 'object'");
        Assert.IsTrue(root.TryGetProperty("created_at", out _), "Missing 'created_at'");
        Assert.IsTrue(root.TryGetProperty("status", out _), "Missing 'status'");
        Assert.IsTrue(root.TryGetProperty("model", out _), "Missing 'model'");
        Assert.IsTrue(root.TryGetProperty("output", out _), "Missing 'output'");
    }

    [Test]
    public async Task Response_OutputMessage_HasRequiredFields()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);

        var response = await PostResponsesAsync(new { model = "test-model" });
        using var doc = await ParseJsonAsync(response);

        var output = doc.RootElement.GetProperty("output");
        Assert.IsTrue(output.GetArrayLength() > 0, "Expected at least one output item");

        var firstItem = output[0];
        Assert.AreEqual("output_message", firstItem.GetProperty("type").GetString());
        Assert.IsTrue(firstItem.TryGetProperty("id", out _), "Output item missing 'id'");
        Assert.IsTrue(firstItem.TryGetProperty("role", out _), "Output item missing 'role'");
        Assert.IsTrue(firstItem.TryGetProperty("content", out _), "Output item missing 'content'");
        Assert.AreEqual("assistant", firstItem.GetProperty("role").GetString());

        var content = firstItem.GetProperty("content");
        Assert.IsTrue(content.GetArrayLength() > 0, "Expected at least one content part");

        var firstContent = content[0];
        Assert.AreEqual("output_text", firstContent.GetProperty("type").GetString());
        Assert.IsTrue(firstContent.TryGetProperty("text", out _), "Content part missing 'text'");
    }

    [Test]
    public async Task Response_OutputText_ComputedCorrectly()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleTextStream(ctx);

        var response = await PostResponsesAsync(new { model = "test-model" });
        using var doc = await ParseJsonAsync(response);

        var outputText = doc.RootElement.GetProperty("output_text").GetString();
        Assert.AreEqual("Hello", outputText);
    }

    [Test]
    public async Task Response_Object_IsAlwaysResponse()
    {
        Handler.EventFactory = (req, ctx, ct) => SimpleStream(ctx);

        var response = await PostResponsesAsync(new { model = "any-model" });
        using var doc = await ParseJsonAsync(response);

        Assert.AreEqual("response", doc.RootElement.GetProperty("object").GetString());
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
        IResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(ctx, new CreateResponse { Model = "test" });
        yield return stream.EmitCreated();
        yield return stream.EmitCompleted();
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> SimpleTextStream(
        IResponseContext ctx,
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
