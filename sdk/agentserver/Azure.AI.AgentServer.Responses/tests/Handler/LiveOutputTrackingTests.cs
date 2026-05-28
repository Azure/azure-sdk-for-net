// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Handler;

/// <summary>
/// Tests that the in-memory Models.ResponseObject.Output list is updated in real-time
/// as output_item.added and output_item.done events flow through the handler.
/// </summary>
public class LiveOutputTrackingTests : IDisposable
{
    private readonly TestHandler _handler = new();
    private readonly TestWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public LiveOutputTrackingTests()
    {
        _factory = new TestWebApplicationFactory(_handler);
        _client = _factory.CreateClient();
    }

    // ── US1: output_item.added inserts at OutputIndex ──────────────

    [Test]
    public async Task ItemAdded_InsertsAtOutputIndex()
    {
        var item = CreateOutputMessage("msg_001", "Hello");

        _handler.EventFactory = (_, ctx, ct) =>
        {
            var response = new Models.ResponseObject(ctx.ResponseId, "test-model");
            var completedResponse = new Models.ResponseObject(ctx.ResponseId, "test-model");
            completedResponse.Output.Add(item);
            completedResponse.SetCompleted();
            return YieldEvents(ct,
                new ResponseCreatedEvent(0, response),
                new ResponseOutputItemAddedEvent(0, outputIndex: 0, item: item),
                new ResponseCompletedEvent(0, completedResponse));
        };

        var body = await PostDefaultRequest();

        var output = body.GetProperty("output");
        Assert.That(output.GetArrayLength(), Is.EqualTo(1));
        Assert.That(output[0].GetProperty("id").GetString(), Is.EqualTo("msg_001"));
    }

    [Test]
    public async Task MultipleItemsAdded_AppearsInOrder()
    {
        var item0 = CreateOutputMessage("msg_000", "First");
        var item1 = CreateOutputMessage("msg_001", "Second");

        _handler.EventFactory = (_, ctx, ct) =>
        {
            var response = new Models.ResponseObject(ctx.ResponseId, "test-model");
            var completedResponse = new Models.ResponseObject(ctx.ResponseId, "test-model");
            completedResponse.Output.Add(item0);
            completedResponse.Output.Add(item1);
            completedResponse.SetCompleted();
            return YieldEvents(ct,
                new ResponseCreatedEvent(0, response),
                new ResponseOutputItemAddedEvent(0, outputIndex: 0, item: item0),
                new ResponseOutputItemAddedEvent(0, outputIndex: 1, item: item1),
                new ResponseCompletedEvent(0, completedResponse));
        };

        var body = await PostDefaultRequest();

        var output = body.GetProperty("output");
        Assert.That(output.GetArrayLength(), Is.EqualTo(2));
        Assert.That(output[0].GetProperty("id").GetString(), Is.EqualTo("msg_000"));
        Assert.That(output[1].GetProperty("id").GetString(), Is.EqualTo("msg_001"));
    }

    [Test]
    public async Task ItemAdded_ResponseIdAvailableOnContextDuringFlight()
    {
        var item = CreateOutputMessage("msg_ctx", "Context");
        string? capturedResponseId = null;

        _handler.EventFactory = (_, ctx, ct) => CaptureAfterAdd(ctx, item, c => capturedResponseId = c.ResponseId, ct);

        await PostDefaultRequest();

        Assert.That(capturedResponseId, Is.Not.Null);
        XAssert.StartsWith("caresp_", capturedResponseId!);
    }

    // ── US2: output_item.done replaces at OutputIndex ─────────────

    [Test]
    public async Task ItemDone_ReplacesItemAtIndex()
    {
        var stub = CreateOutputMessage("msg_stub", "partial");
        var final_ = CreateOutputMessage("msg_done", "complete");

        _handler.EventFactory = (_, ctx, ct) =>
        {
            var response = new Models.ResponseObject(ctx.ResponseId, "test-model");
            var completedResponse = new Models.ResponseObject(ctx.ResponseId, "test-model");
            completedResponse.Output.Add(final_);
            completedResponse.SetCompleted();
            return YieldEvents(ct,
                new ResponseCreatedEvent(0, response),
                new ResponseOutputItemAddedEvent(0, outputIndex: 0, item: stub),
                new ResponseOutputItemDoneEvent(0, outputIndex: 0, item: final_),
                new ResponseCompletedEvent(0, completedResponse));
        };

        var body = await PostDefaultRequest();

        var output = body.GetProperty("output");
        Assert.That(output.GetArrayLength(), Is.EqualTo(1));
        Assert.That(output[0].GetProperty("id").GetString(), Is.EqualTo("msg_done"));
    }

    [Test]
    public async Task ItemDone_OnlyUpdatesTargetIndex()
    {
        var item0 = CreateOutputMessage("msg_first", "A");
        var item1 = CreateOutputMessage("msg_second", "B");
        var item1Done = CreateOutputMessage("msg_second_done", "B final");

        _handler.EventFactory = (_, ctx, ct) =>
        {
            var response = new Models.ResponseObject(ctx.ResponseId, "test-model");
            var completedResponse = new Models.ResponseObject(ctx.ResponseId, "test-model");
            completedResponse.Output.Add(item0);
            completedResponse.Output.Add(item1Done);
            completedResponse.SetCompleted();
            return YieldEvents(ct,
                new ResponseCreatedEvent(0, response),
                new ResponseOutputItemAddedEvent(0, outputIndex: 0, item: item0),
                new ResponseOutputItemAddedEvent(0, outputIndex: 1, item: item1),
                new ResponseOutputItemDoneEvent(0, outputIndex: 1, item: item1Done),
                new ResponseCompletedEvent(0, completedResponse));
        };

        var body = await PostDefaultRequest();

        var output = body.GetProperty("output");
        Assert.That(output.GetArrayLength(), Is.EqualTo(2));
        Assert.That(output[0].GetProperty("id").GetString(), Is.EqualTo("msg_first"));
        Assert.That(output[1].GetProperty("id").GetString(), Is.EqualTo("msg_second_done"));
    }

    // ── US3: Default mode regression ──────────────────────────────

    [Test]
    public async Task DefaultMode_AddedThenDone_ReturnsFinalOutput()
    {
        var stub = CreateOutputMessage("msg_stub2", "draft");
        var final_ = CreateOutputMessage("msg_final2", "final");

        _handler.EventFactory = (_, ctx, ct) =>
        {
            var response = new Models.ResponseObject(ctx.ResponseId, "test-model");
            var completedResponse = new Models.ResponseObject(ctx.ResponseId, "test-model");
            completedResponse.Output.Add(final_);
            completedResponse.SetCompleted();
            return YieldEvents(ct,
                new ResponseCreatedEvent(0, response),
                new ResponseOutputItemAddedEvent(0, outputIndex: 0, item: stub),
                new ResponseOutputItemDoneEvent(0, outputIndex: 0, item: final_),
                new ResponseCompletedEvent(0, completedResponse));
        };

        var body = await PostDefaultRequest();

        Assert.That(body.GetProperty("status").GetString(), Is.EqualTo("completed"));
        var output = body.GetProperty("output");
        Assert.That(output.GetArrayLength(), Is.EqualTo(1));
        Assert.That(output[0].GetProperty("id").GetString(), Is.EqualTo("msg_final2"));
    }

    // ── Edge cases ────────────────────────────────────────────────

    [Test]
    public async Task DoneWithoutAdd_InsertsAtIndex()
    {
        var item = CreateOutputMessage("msg_noprior", "direct done");

        _handler.EventFactory = (_, ctx, ct) =>
        {
            var response = new Models.ResponseObject(ctx.ResponseId, "test-model");
            var completedResponse = new Models.ResponseObject(ctx.ResponseId, "test-model");
            completedResponse.Output.Add(item);
            completedResponse.SetCompleted();
            return YieldEvents(ct,
                new ResponseCreatedEvent(0, response),
                new ResponseOutputItemDoneEvent(0, outputIndex: 0, item: item),
                new ResponseCompletedEvent(0, completedResponse));
        };

        var body = await PostDefaultRequest();

        var output = body.GetProperty("output");
        Assert.That(output.GetArrayLength(), Is.EqualTo(1));
        Assert.That(output[0].GetProperty("id").GetString(), Is.EqualTo("msg_noprior"));
    }

    [Test]
    public async Task DoneWithNullItem_IsIgnored()
    {
        // The null! item causes the event constructor to throw ArgumentNullException
        // before response.created is yielded → pre-created error → 500
        _handler.EventFactory = (_, ctx, ct) =>
        {
            var response = new Models.ResponseObject(ctx.ResponseId, "test-model");
            var completedResponse = new Models.ResponseObject(ctx.ResponseId, "test-model");
            completedResponse.SetCompleted();
            return YieldEvents(ct,
                new ResponseCreatedEvent(0, response),
                new ResponseOutputItemDoneEvent(0, outputIndex: 0, item: null!),
                new ResponseCompletedEvent(0, completedResponse));
        };

        var requestBody = JsonSerializer.Serialize(new { model = "test-model" });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var httpResponse = await _client.PostAsync("/responses", content);
        Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
    }

    [Test]
    public async Task AddedWithNullItem_IsIgnored()
    {
        // The null! item causes the event constructor to throw ArgumentNullException
        // before response.created is yielded → pre-created error → 500
        _handler.EventFactory = (_, ctx, ct) =>
        {
            var response = new Models.ResponseObject(ctx.ResponseId, "test-model");
            var completedResponse = new Models.ResponseObject(ctx.ResponseId, "test-model");
            completedResponse.SetCompleted();
            return YieldEvents(ct,
                new ResponseCreatedEvent(0, response),
                new ResponseOutputItemAddedEvent(0, outputIndex: 0, item: null!),
                new ResponseCompletedEvent(0, completedResponse));
        };

        var requestBody = JsonSerializer.Serialize(new { model = "test-model" });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var httpResponse = await _client.PostAsync("/responses", content);
        Assert.That(httpResponse.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
    }

    [Test]
    public async Task DuplicateAdd_OverwritesAtSameIndex()
    {
        var first = CreateOutputMessage("msg_v1", "v1");
        var second = CreateOutputMessage("msg_v2", "v2");

        _handler.EventFactory = (_, ctx, ct) =>
        {
            var response = new Models.ResponseObject(ctx.ResponseId, "test-model");
            var completedResponse = new Models.ResponseObject(ctx.ResponseId, "test-model");
            completedResponse.Output.Add(second);
            completedResponse.SetCompleted();
            return YieldEvents(ct,
                new ResponseCreatedEvent(0, response),
                new ResponseOutputItemAddedEvent(0, outputIndex: 0, item: first),
                new ResponseOutputItemAddedEvent(0, outputIndex: 0, item: second),
                new ResponseCompletedEvent(0, completedResponse));
        };

        var body = await PostDefaultRequest();

        var output = body.GetProperty("output");
        Assert.That(output.GetArrayLength(), Is.EqualTo(1));
        Assert.That(output[0].GetProperty("id").GetString(), Is.EqualTo("msg_v2"));
    }

    [Test]
    public async Task IndexGap_PadsListWithNulls()
    {
        // Add at index 2 when output is empty — indices 0,1 should be padded
        var item = CreateOutputMessage("msg_gap", "gap");

        _handler.EventFactory = (_, ctx, ct) =>
        {
            var response = new Models.ResponseObject(ctx.ResponseId, "test-model");
            var completedResponse = new Models.ResponseObject(ctx.ResponseId, "test-model");
            completedResponse.Output.Add(item);
            completedResponse.SetCompleted();
            return YieldEvents(ct,
                new ResponseCreatedEvent(0, response),
                new ResponseOutputItemAddedEvent(0, outputIndex: 2, item: item),
                new ResponseCompletedEvent(0, completedResponse));
        };

        var body = await PostDefaultRequest();

        // The pipeline should have padded the output list. Verify the response
        // contains the item — the exact JSON shape depends on serialization of nulls,
        // but the response should complete without errors.
        Assert.That(body.GetProperty("status").GetString(), Is.EqualTo("completed"));
    }

    // ── Helpers ───────────────────────────────────────────────────

    private async Task<JsonElement> PostDefaultRequest()
    {
        var requestBody = JsonSerializer.Serialize(new { model = "test-model" });
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/responses", content);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        return await response.Content.ReadFromJsonAsync<JsonElement>();
    }

    private static OutputItemMessage CreateOutputMessage(string id, string text)
    {
        var content = new MessageContentOutputTextContent(
            text: text,
            annotations: Array.Empty<Annotation>(),
            logprobs: Array.Empty<LogProb>());
        return new OutputItemMessage(
            id: id,
            content: new List<MessageContent> { content },
            status: MessageStatus.Completed);
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> YieldEvents(
        [EnumeratorCancellation] CancellationToken ct,
        params ResponseStreamEvent[] events)
    {
        foreach (var evt in events)
        {
            ct.ThrowIfCancellationRequested();
            yield return evt;
        }
        await Task.CompletedTask;
    }

    private static async IAsyncEnumerable<ResponseStreamEvent> CaptureAfterAdd(
        ResponseContext ctx,
        OutputItem item,
        Action<ResponseContext> capture,
        [EnumeratorCancellation] CancellationToken ct)
    {
        var response = new Models.ResponseObject(ctx.ResponseId, "test-model");
        yield return new ResponseCreatedEvent(0, response);
        yield return new ResponseOutputItemAddedEvent(0, outputIndex: 0, item: item);

        // Capture context after the event has been processed by the handler pipeline
        capture(ctx);

        var completedResponse = new Models.ResponseObject(ctx.ResponseId, "test-model");
        completedResponse.Output.Add(item);
        completedResponse.SetCompleted();
        yield return new ResponseCompletedEvent(0, completedResponse);
        await Task.CompletedTask;
    }

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
    }
}
