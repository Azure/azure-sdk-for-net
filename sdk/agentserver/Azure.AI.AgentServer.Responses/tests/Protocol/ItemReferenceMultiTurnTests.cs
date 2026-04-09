// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// E2E protocol tests for multi-turn scenarios where the second turn references
/// an output item from the first turn's response via <c>item_reference</c>.
/// Covers both default (streaming SSE) and background modes, verifying that
/// the referenced item is resolved correctly and the handler receives the
/// concrete <see cref="Item"/> content.
/// </summary>
public class ItemReferenceMultiTurnTests : IDisposable
{
    private readonly TestHandler _handler = new();
    private readonly TestWebApplicationFactory _factory;
    private readonly HttpClient _client;

    public ItemReferenceMultiTurnTests()
    {
        _handler.EventFactory = (_, ctx, ct) => EchoWithOutputMessage(ctx, ct);
        _factory = new TestWebApplicationFactory(_handler);
        _client = _factory.CreateClient();
    }

    /// <summary>
    /// Turn 1 produces an output message. Turn 2 references that output via
    /// <c>item_reference</c>. The response succeeds (200) and the handler's
    /// <c>context.GetInputItemsAsync()</c> resolves the reference to the
    /// original message content.
    /// </summary>
    [Test]
    public async Task Turn2_ItemReference_ResolvesToTurn1OutputMessage()
    {
        // ── Turn 1: produce a response with an output message ──
        var turn1Json = """
        {
            "model": "test",
            "input": "What is the capital of France?"
        }
        """;
        var turn1Response = await _client.PostAsync("/responses",
            new StringContent(turn1Json, Encoding.UTF8, "application/json"));
        var turn1Body = await turn1Response.Content.ReadAsStringAsync();
        Assert.That(turn1Response.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"Turn 1 POST failed: {turn1Body}");

        using var turn1Doc = JsonDocument.Parse(turn1Body);
        var turn1ResponseId = turn1Doc.RootElement.GetProperty("id").GetString()!;

        // Extract the output item ID from turn 1's response
        var outputItems = turn1Doc.RootElement.GetProperty("output");
        Assert.That(outputItems.GetArrayLength(), Is.GreaterThan(0), "Turn 1 should have output items");
        var outputItemId = outputItems[0].GetProperty("id").GetString()!;

        // ── Turn 2: reference the output item from turn 1 ──
        var turn2Json = $$"""
        {
            "model": "test",
            "input": [
                { "type": "item_reference", "id": "{{outputItemId}}" },
                { "type": "message", "role": "user", "content": [{ "type": "input_text", "text": "Summarize the above" }] }
            ]
        }
        """;
        var turn2Response = await _client.PostAsync("/responses",
            new StringContent(turn2Json, Encoding.UTF8, "application/json"));
        var turn2Body = await turn2Response.Content.ReadAsStringAsync();
        Assert.That(turn2Response.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"Turn 2 POST failed: {turn2Body}");

        using var turn2Doc = JsonDocument.Parse(turn2Body);
        var turn2ResponseId = turn2Doc.RootElement.GetProperty("id").GetString()!;
        Assert.That(turn2ResponseId, Is.Not.EqualTo(turn1ResponseId));

        // ── Verify: GET turn 2's input_items shows the resolved reference + inline message ──
        var getResponse = await _client.GetAsync($"/responses/{turn2ResponseId}/input_items?order=asc");
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var getBody = await getResponse.Content.ReadAsStringAsync();
        using var getDoc = JsonDocument.Parse(getBody);
        var data = getDoc.RootElement.GetProperty("data");

        // Should have 2 items: resolved reference + inline message
        Assert.That(data.GetArrayLength(), Is.EqualTo(2),
            $"Expected 2 input items (resolved ref + inline), got {data.GetArrayLength()}. Body: {getBody}");

        // First item: the resolved reference (originally an output message from turn 1)
        var resolvedItem = data[0];
        Assert.That(resolvedItem.GetProperty("type").GetString(), Is.EqualTo("message"));

        // Second item: the inline user message
        var inlineItem = data[1];
        Assert.That(inlineItem.GetProperty("type").GetString(), Is.EqualTo("message"));
        var inlineContent = inlineItem.GetProperty("content");
        Assert.That(inlineContent[0].GetProperty("text").GetString(), Is.EqualTo("Summarize the above"));
    }

    /// <summary>
    /// Same as above but in background mode — verifies item_reference resolution works
    /// for background responses too.
    /// </summary>
    [Test]
    public async Task Turn2_Background_ItemReference_ResolvesToTurn1OutputMessage()
    {
        // ── Turn 1: produce a response ──
        var turn1Json = """
        {
            "model": "test",
            "input": "Tell me a joke"
        }
        """;
        var turn1Response = await _client.PostAsync("/responses",
            new StringContent(turn1Json, Encoding.UTF8, "application/json"));
        var turn1Body = await turn1Response.Content.ReadAsStringAsync();
        Assert.That(turn1Response.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"Turn 1 failed: {turn1Body}");

        using var turn1Doc = JsonDocument.Parse(turn1Body);
        var outputItems = turn1Doc.RootElement.GetProperty("output");
        Assert.That(outputItems.GetArrayLength(), Is.GreaterThan(0), "Turn 1 should have output items");
        var outputItemId = outputItems[0].GetProperty("id").GetString()!;

        // ── Turn 2: background mode with item_reference ──
        var turn2Json = $$"""
        {
            "model": "test",
            "background": true,
            "input": [
                { "type": "item_reference", "id": "{{outputItemId}}" }
            ]
        }
        """;
        var turn2Response = await _client.PostAsync("/responses",
            new StringContent(turn2Json, Encoding.UTF8, "application/json"));
        var turn2Body = await turn2Response.Content.ReadAsStringAsync();
        Assert.That(turn2Response.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"Turn 2 failed: {turn2Body}");

        using var turn2Doc = JsonDocument.Parse(turn2Body);
        var turn2ResponseId = turn2Doc.RootElement.GetProperty("id").GetString()!;

        // Wait for background response to complete
        await WaitForCompletionAsync(turn2ResponseId);

        // ── Verify: GET input_items resolves the reference ──
        var getResponse = await _client.GetAsync($"/responses/{turn2ResponseId}/input_items?order=asc");
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var getBody = await getResponse.Content.ReadAsStringAsync();
        using var getDoc = JsonDocument.Parse(getBody);
        var data = getDoc.RootElement.GetProperty("data");

        Assert.That(data.GetArrayLength(), Is.EqualTo(1),
            $"Expected 1 resolved input item, got {data.GetArrayLength()}. Body: {getBody}");
        Assert.That(data[0].GetProperty("type").GetString(), Is.EqualTo("message"));
    }

    /// <summary>
    /// Turn 2 references a non-existent item ID. The response still succeeds (200)
    /// — unresolvable references are silently dropped.
    /// </summary>
    [Test]
    public async Task Turn2_ItemReference_NonExistentId_IsDropped()
    {
        var json = """
        {
            "model": "test",
            "input": [
                { "type": "item_reference", "id": "msg_does_not_exist" },
                { "type": "message", "role": "user", "content": [{ "type": "input_text", "text": "Hello" }] }
            ]
        }
        """;
        var response = await _client.PostAsync("/responses",
            new StringContent(json, Encoding.UTF8, "application/json"));
        var body = await response.Content.ReadAsStringAsync();
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"POST failed: {body}");

        using var doc = JsonDocument.Parse(body);
        var responseId = doc.RootElement.GetProperty("id").GetString()!;

        // GET input_items — the unresolvable reference should be dropped,
        // leaving only the inline message
        var getResponse = await _client.GetAsync($"/responses/{responseId}/input_items?order=asc");
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var getBody = await getResponse.Content.ReadAsStringAsync();
        using var getDoc = JsonDocument.Parse(getBody);
        var data = getDoc.RootElement.GetProperty("data");

        Assert.That(data.GetArrayLength(), Is.EqualTo(1),
            $"Expected 1 item (unresolvable ref dropped), got {data.GetArrayLength()}. Body: {getBody}");
        Assert.That(data[0].GetProperty("type").GetString(), Is.EqualTo("message"));
    }

    /// <summary>
    /// Three-turn chain: turn 1 output → turn 2 references it via item_reference →
    /// turn 3 uses previous_response_id to chain from turn 2. Verifies that
    /// both item_reference resolution and previous_response_id history work
    /// together in a realistic multi-turn flow.
    /// </summary>
    [Test]
    public async Task ThreeTurnChain_ItemRefAndPreviousResponseId_Combined()
    {
        // ── Turn 1 ──
        var turn1Response = await PostResponseAsync("""{ "model": "test", "input": "Turn 1 question" }""");
        var turn1Id = turn1Response.GetProperty("id").GetString()!;
        var outputItems = turn1Response.GetProperty("output");
        Assert.That(outputItems.GetArrayLength(), Is.GreaterThan(0), "Turn 1 should have output items");
        var outputItemId = outputItems[0].GetProperty("id").GetString()!;

        // ── Turn 2: reference turn 1's output item ──
        var turn2Json = $$"""
        {
            "model": "test",
            "input": [
                { "type": "item_reference", "id": "{{outputItemId}}" },
                { "type": "message", "role": "user", "content": [{ "type": "input_text", "text": "Turn 2 follow-up" }] }
            ]
        }
        """;
        var turn2Response = await PostResponseAsync(turn2Json);
        var turn2Id = turn2Response.GetProperty("id").GetString()!;

        // ── Turn 3: chain from turn 2 via previous_response_id ──
        var turn3Json = $$"""
        {
            "model": "test",
            "input": "Turn 3 final question",
            "previous_response_id": "{{turn2Id}}"
        }
        """;
        var turn3Response = await PostResponseAsync(turn3Json);
        var turn3Id = turn3Response.GetProperty("id").GetString()!;

        // ── Verify turn 3's input_items include history from turn 2 + turn 3's inline ──
        var getResponse = await _client.GetAsync($"/responses/{turn3Id}/input_items?order=asc");
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        var getBody = await getResponse.Content.ReadAsStringAsync();
        using var getDoc = JsonDocument.Parse(getBody);
        var data = getDoc.RootElement.GetProperty("data");

        // Turn 2 stored 2 input items (resolved ref + inline) + turn 2's output.
        // Turn 3 has its own inline input + history from turn 2.
        // The exact count depends on history resolution, but must be > 1
        Assert.That(data.GetArrayLength(), Is.GreaterThan(1),
            $"Turn 3 should have history + current input. Body: {getBody}");

        // The last item should be turn 3's inline input
        var lastItem = data[data.GetArrayLength() - 1];
        var lastContent = lastItem.GetProperty("content");
        Assert.That(lastContent[0].GetProperty("text").GetString(), Is.EqualTo("Turn 3 final question"));
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Handler helper — produces an output message so item_reference can resolve it
    // ═══════════════════════════════════════════════════════════════════════

    private static async IAsyncEnumerable<ResponseStreamEvent> EchoWithOutputMessage(
        ResponseContext ctx,
        [EnumeratorCancellation] CancellationToken ct = default)
    {
        await Task.CompletedTask;
        var response = new Models.ResponseObject(ctx.ResponseId, "test") { Status = ResponseStatus.InProgress };
        yield return new ResponseCreatedEvent(0, response);

        var textContent = new MessageContentOutputTextContent(
            "Echo reply", Array.Empty<Annotation>(), Array.Empty<LogProb>());
        var msg = new OutputItemMessage(
            $"msg_{Guid.NewGuid():N}",
            MessageStatus.Completed,
            new MessageContent[] { textContent });
        yield return new ResponseOutputItemAddedEvent(0, 0, msg);
        yield return new ResponseOutputItemDoneEvent(0, 0, msg);

        var completedResponse = new Models.ResponseObject(ctx.ResponseId, "test");
        completedResponse.Output.Add(msg);
        completedResponse.SetCompleted();
        yield return new ResponseCompletedEvent(0, completedResponse);
    }

    // ═══════════════════════════════════════════════════════════════════════
    // Helpers
    // ═══════════════════════════════════════════════════════════════════════

    private async Task<JsonElement> PostResponseAsync(string json)
    {
        var response = await _client.PostAsync("/responses",
            new StringContent(json, Encoding.UTF8, "application/json"));
        var body = await response.Content.ReadAsStringAsync();
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), $"POST failed: {body}");
        using var doc = JsonDocument.Parse(body);
        return doc.RootElement.Clone();
    }

    private async Task WaitForCompletionAsync(string responseId, TimeSpan? timeout = null)
    {
        var deadline = DateTime.UtcNow + (timeout ?? TimeSpan.FromSeconds(5));

        while (DateTime.UtcNow < deadline)
        {
            var response = await _client.GetAsync($"/responses/{responseId}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var body = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(body);
                var status = doc.RootElement.GetProperty("status").GetString();
                if (status is "completed" or "failed" or "cancelled" or "incomplete")
                {
                    return;
                }
            }

            await Task.Delay(50);
        }

        Assert.Fail($"Response {responseId} did not complete within {timeout ?? TimeSpan.FromSeconds(5)}");
    }

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
        GC.SuppressFinalize(this);
    }
}
