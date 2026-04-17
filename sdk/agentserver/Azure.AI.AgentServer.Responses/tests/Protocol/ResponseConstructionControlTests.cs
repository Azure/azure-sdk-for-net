// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// E2E protocol tests for developer Models.ResponseObject construction control.
/// Validates B37 (full replacement), response property exposure.
/// These tests verify that handler-set Models.ResponseObject properties survive through the
/// orchestration pipeline and appear in the final HTTP response.
/// </summary>
public class ResponseConstructionControlTests : ProtocolTestBase
{
    // ── T022: Custom Metadata via events.Response ──────────────

    [Test]
    public async Task POST_Responses_HandlerSetsCustomMetadata_PreservedInResponse()
    {
        // Handler sets custom Metadata via events.Response before EmitCreated (B37)
        // → final response contains handler's metadata values
        Handler.EventFactory = (req, ctx, ct) => CustomMetadataStream(req, ctx);

        var response = await PostResponsesAsync(new { model = "test" });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(response);

        // Handler created its own Metadata with handler_key — should appear in response
        Assert.That(doc.RootElement.TryGetProperty("metadata", out var metadata), Is.True, "Expected 'metadata' property in response");
        Assert.That(metadata.ValueKind, Is.EqualTo(JsonValueKind.Object));
        Assert.That(metadata.GetProperty("handler_key").GetString(), Is.EqualTo("from_handler"));
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
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var getDoc = await ParseJsonAsync(getResponse);

        Assert.That(getDoc.RootElement.TryGetProperty("metadata", out var metadata), Is.True, "Expected 'metadata' in GET response");
        Assert.That(metadata.GetProperty("handler_key").GetString(), Is.EqualTo("from_handler"));
    }

    // ── T023: Custom Instructions via events.Response ─────────

    [Test]
    public async Task POST_Responses_Streaming_HandlerSetsCustomInstructions_PreservedInCreatedEvent()
    {
        // Handler sets custom Instructions via events.Response before EmitCreated (B37)
        // → response.created SSE event contains handler's instructions
        Handler.EventFactory = (req, ctx, ct) => CustomInstructionsStream(req, ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var events = await ParseSseAsync(response);

        var createdEvent = events.First(e => e.EventType == "response.created");
        using var doc = JsonDocument.Parse(createdEvent.Data);
        var responseObj = doc.RootElement.GetProperty("response");

        var instructions = responseObj.GetProperty("instructions").GetString();
        Assert.That(instructions, Is.EqualTo("Custom handler instructions"));
    }

    [Test]
    public async Task POST_Responses_Default_HandlerSetsCustomInstructions_PreservedInFinalResponse()
    {
        // Same as above but in default mode — instructions preserved in final response
        Handler.EventFactory = (req, ctx, ct) => CustomInstructionsStream(req, ctx);

        var response = await PostResponsesAsync(new { model = "test" });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(response);

        var instructions = doc.RootElement.GetProperty("instructions").GetString();
        Assert.That(instructions, Is.EqualTo("Custom handler instructions"));
    }

    // ── T024: Raw ResponseCreatedEvent with custom fields ─────

    [Test]
    public async Task POST_Responses_RawResponseCreatedEvent_CustomMetadataPreservedInFinalResponse()
    {
        // Handler emits raw ResponseCreatedEvent with custom fields (no ResponseEventStream)
        // → persisted Models.ResponseObject preserves those fields (B37 full replacement)
        Handler.EventFactory = (req, ctx, ct) => RawEventStream(ctx);

        var response = await PostResponsesAsync(new { model = "test" });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(response);

        // Handler set raw_key in the raw event's Models.ResponseObject — should appear in response
        Assert.That(doc.RootElement.TryGetProperty("metadata", out var metadata), Is.True);
        Assert.That(metadata.GetProperty("raw_key").GetString(), Is.EqualTo("raw_value"));
    }

    [Test]
    public async Task POST_Responses_Streaming_RawResponseCreatedEvent_CustomMetadataPreservedInSseEvents()
    {
        // Same as above but in streaming mode — custom metadata appears in SSE event snapshots
        Handler.EventFactory = (req, ctx, ct) => RawEventStream(ctx);

        var response = await PostResponsesAsync(new { model = "test", stream = true });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        var events = await ParseSseAsync(response);

        var createdEvent = events.First(e => e.EventType == "response.created");
        using var doc = JsonDocument.Parse(createdEvent.Data);
        var responseObj = doc.RootElement.GetProperty("response");

        Assert.That(responseObj.TryGetProperty("metadata", out var metadata), Is.True);
        Assert.That(metadata.GetProperty("raw_key").GetString(), Is.EqualTo("raw_value"));
    }

    // ── Helper event factories ─────────────────────────────────

    private static async IAsyncEnumerable<ResponseStreamEvent> CustomMetadataStream(
        CreateResponse request,
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(ctx, request);
        // Handler initializes Metadata and sets custom value via Models.ResponseObject property (B37)
        stream.Response.Metadata = new Metadata();
        stream.Response.Metadata.AdditionalProperties["handler_key"] = "from_handler";
        yield return stream.EmitCreated();
        yield return stream.EmitCompleted();
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> CustomInstructionsStream(
        CreateResponse request,
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var stream = new ResponseEventStream(ctx, request);
        // Handler sets custom instructions via Models.ResponseObject property (B37)
        stream.Response.Instructions = BinaryData.FromObjectAsJson("Custom handler instructions");
        yield return stream.EmitCreated();
        yield return stream.EmitCompleted();
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> RawEventStream(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        // Handler constructs raw events without using ResponseEventStream (B37)
        var response = new Models.ResponseObject(ctx.ResponseId, "test")
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
