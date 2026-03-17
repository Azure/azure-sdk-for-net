using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// E2E protocol tests for developer Models.Response construction control (US1).
/// Validates FR-001 (full replacement), FR-004 (Models.Response property exposure).
/// These tests verify that handler-set Models.Response properties survive through the
/// orchestration pipeline and appear in the final HTTP response.
/// </summary>
public class ResponseConstructionControlTests : ProtocolTestBase
{
    // ── T022: Custom Metadata via events.Response ──────────────

    [Test]
    public async Task POST_Responses_HandlerSetsCustomMetadata_PreservedInResponse()
    {
        // Handler sets custom Metadata via events.Response before EmitCreated (FR-004)
        // → final response contains handler's metadata values
        Handler.EventFactory = (req, ctx, ct) => CustomMetadataStream(req, ctx);

        var response = await PostResponsesAsync(new { model = "test" });

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        using var doc = await ParseJsonAsync(response);

        // Handler created its own Metadata with handler_key — should appear in response
        Assert.IsTrue(doc.RootElement.TryGetProperty("metadata", out var metadata),
            "Expected 'metadata' property in response");
        Assert.AreEqual(JsonValueKind.Object, metadata.ValueKind);
        Assert.AreEqual("from_handler", metadata.GetProperty("handler_key").GetString());
    }

    [Test]
    public async Task POST_Responses_Background_HandlerSetsCustomMetadata_PreservedInGetResponse()
    {
        // Same as above but in background+store mode — metadata preserved through persistence
        Handler.EventFactory = (req, ctx, ct) => CustomMetadataStream(req, ctx);

        var createResponse = await PostResponsesAsync(new { model = "test", background = true, store = true });
        using var createDoc = await ParseJsonAsync(createResponse);
        var responseId = createDoc.RootElement.GetProperty("id").GetString()!;

        await WaitForBackgroundCompletionAsync(responseId);

        var getResponse = await GetResponseAsync(responseId);
        Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode);
        using var getDoc = await ParseJsonAsync(getResponse);

        Assert.IsTrue(getDoc.RootElement.TryGetProperty("metadata", out var metadata),
            "Expected 'metadata' in GET response");
        Assert.AreEqual("from_handler", metadata.GetProperty("handler_key").GetString());
    }

    // ── T023: Custom Instructions via events.Response ─────────

    [Test]
    public async Task POST_Responses_Streaming_HandlerSetsCustomInstructions_PreservedInCreatedEvent()
    {
        // Handler sets custom Instructions via events.Response before EmitCreated (FR-004)
        // → response.created SSE event contains handler's instructions
        Handler.EventFactory = (req, ctx, ct) => CustomInstructionsStream(req, ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        var events = await ParseSseAsync(response);

        var createdEvent = events.First(e => e.EventType == "response.created");
        using var doc = JsonDocument.Parse(createdEvent.Data);
        var responseObj = doc.RootElement.GetProperty("response");

        var instructions = responseObj.GetProperty("instructions").GetString();
        Assert.AreEqual("Custom handler instructions", instructions);
    }

    [Test]
    public async Task POST_Responses_Default_HandlerSetsCustomInstructions_PreservedInFinalResponse()
    {
        // Same as above but in default mode — instructions preserved in final response
        Handler.EventFactory = (req, ctx, ct) => CustomInstructionsStream(req, ctx);

        var response = await PostResponsesAsync(new { model = "test" });

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        using var doc = await ParseJsonAsync(response);

        var instructions = doc.RootElement.GetProperty("instructions").GetString();
        Assert.AreEqual("Custom handler instructions", instructions);
    }

    // ── T024: Raw ResponseCreatedEvent with custom fields ─────

    [Test]
    public async Task POST_Responses_RawResponseCreatedEvent_CustomMetadataPreservedInFinalResponse()
    {
        // Handler emits raw ResponseCreatedEvent with custom fields (no ResponseEventStream)
        // → persisted Models.Response preserves those fields (FR-001 full replacement)
        Handler.EventFactory = (req, ctx, ct) => RawEventStream(ctx);

        var response = await PostResponsesAsync(new { model = "test" });

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        using var doc = await ParseJsonAsync(response);

        // Handler set raw_key in the raw event's Models.Response — should appear in response
        Assert.IsTrue(doc.RootElement.TryGetProperty("metadata", out var metadata));
        Assert.AreEqual("raw_value", metadata.GetProperty("raw_key").GetString());
    }

    [Test]
    public async Task POST_Responses_Streaming_RawResponseCreatedEvent_CustomMetadataPreservedInSseEvents()
    {
        // Same as above but in streaming mode — custom metadata appears in SSE event snapshots
        Handler.EventFactory = (req, ctx, ct) => RawEventStream(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        var events = await ParseSseAsync(response);

        var createdEvent = events.First(e => e.EventType == "response.created");
        using var doc = JsonDocument.Parse(createdEvent.Data);
        var responseObj = doc.RootElement.GetProperty("response");

        Assert.IsTrue(responseObj.TryGetProperty("metadata", out var metadata));
        Assert.AreEqual("raw_value", metadata.GetProperty("raw_key").GetString());
    }

    // ── Helper event factories ─────────────────────────────────

    private static async IAsyncEnumerable<ResponseStreamEvent> CustomMetadataStream(
        CreateResponse request,
        IResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(ctx, request);
        // Handler initializes Metadata and sets custom value via Models.Response property (FR-004)
        stream.Response.Metadata = new Metadata();
        stream.Response.Metadata.AdditionalProperties["handler_key"] = "from_handler";
        yield return stream.EmitCreated();
        yield return stream.EmitCompleted();
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> CustomInstructionsStream(
        CreateResponse request,
        IResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(ctx, request);
        // Handler sets custom instructions via Models.Response property (FR-004)
        stream.Response.Instructions = BinaryData.FromObjectAsJson("Custom handler instructions");
        yield return stream.EmitCreated();
        yield return stream.EmitCompleted();
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> RawEventStream(
        IResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        // Handler constructs raw events without using ResponseEventStream (FR-001)
        var response = new Models.Response(ctx.ResponseId, "test")
        {
            Metadata = new Metadata(),
            Status = ResponseStatus.InProgress,
        };
        response.Metadata.AdditionalProperties["raw_key"] = "raw_value";
        yield return new ResponseCreatedEvent(0, response);

        response.SetCompleted();
        yield return new ResponseCompletedEvent(1, response);
    }
}
