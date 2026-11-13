// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol tests for conversation + store interactions.
/// <c>conversation</c> + <c>store=false</c> is accepted — reads history, doesn't write it.
/// The response is ephemeral (GET returns 404).
/// </summary>
public class ConversationStoreProtocolTests : ProtocolTestBase
{
    // Validates: conversation (string ID) + store=false → 200 with SSE stream, GET → 404
    [Test]
    public async Task POST_StoreFalse_WithConversationStringId_Returns200_Ephemeral()
    {
        var response = await PostResponsesAsync(new
        {
            model = "test",
            store = false,
            stream = true,
            conversation = "conv_abc123"
        });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content.Headers.ContentType?.MediaType, Is.EqualTo("text/event-stream"));

        var events = await ParseSseAsync(response);
        XAssert.Contains(events, e => e.EventType == "response.completed");

        // Extract response ID from first event and verify ephemeral (GET → 404)
        using var doc = JsonDocument.Parse(events[0].Data);
        var responseId = doc.RootElement.GetProperty("response").GetProperty("id").GetString()!;
        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    // Validates: conversation (object) + store=false → 200 with SSE stream, GET → 404
    [Test]
    public async Task POST_StoreFalse_WithConversationObject_Returns200_Ephemeral()
    {
        var response = await PostResponsesAsync(new
        {
            model = "test",
            store = false,
            stream = true,
            conversation = new { id = "conv_xyz789" }
        });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        Assert.That(response.Content.Headers.ContentType?.MediaType, Is.EqualTo("text/event-stream"));

        var events = await ParseSseAsync(response);
        XAssert.Contains(events, e => e.EventType == "response.completed");

        // Extract response ID and verify ephemeral (GET → 404)
        using var doc = JsonDocument.Parse(events[0].Data);
        var responseId = doc.RootElement.GetProperty("response").GetProperty("id").GetString()!;
        var getResponse = await GetResponseAsync(responseId);
        Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }

    // Validates: store=true + conversation is allowed (unchanged)
    [Test]
    public async Task POST_StoreTrue_WithConversation_IsAllowed()
    {
        var response = await PostResponsesAsync(new
        {
            model = "test",
            store = true,
            conversation = "conv_abc123"
        });

        // Should not be 400 — conversation + store=true is valid
        Assert.That(response.StatusCode, Is.Not.EqualTo(HttpStatusCode.BadRequest));
    }

    // Validates: store=false without conversation is allowed (unchanged)
    [Test]
    public async Task POST_StoreFalse_WithoutConversation_IsAllowed()
    {
        var response = await PostResponsesAsync(new
        {
            model = "test",
            store = false
        });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    // ── Conversation ID round-trip tests ──

    [Test]
    public async Task POST_Default_WithConversationString_RoundTripsInResponse()
    {
        var response = await PostResponsesAsync(new
        {
            model = "test",
            conversation = "conv_abc123"
        });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(response);
        var conv = doc.RootElement.GetProperty("conversation");
        Assert.That(conv.GetProperty("id").GetString(), Is.EqualTo("conv_abc123"));
    }

    [Test]
    public async Task POST_Default_WithConversationObject_RoundTripsInResponse()
    {
        var response = await PostResponsesAsync(new
        {
            model = "test",
            conversation = new { id = "conv_xyz789" }
        });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(response);
        var conv = doc.RootElement.GetProperty("conversation");
        Assert.That(conv.GetProperty("id").GetString(), Is.EqualTo("conv_xyz789"));
    }

    [Test]
    public async Task POST_Streaming_WithConversationString_RoundTripsInCreatedEvent()
    {
        var response = await PostResponsesAsync(new
        {
            model = "test",
            stream = true,
            conversation = "conv_stream1"
        });

        var events = await ParseSseAsync(response);
        var createdEvent = events.First(e => e.EventType == "response.created");
        using var doc = JsonDocument.Parse(createdEvent.Data);
        var conv = doc.RootElement.GetProperty("response").GetProperty("conversation");
        Assert.That(conv.GetProperty("id").GetString(), Is.EqualTo("conv_stream1"));
    }

    [Test]
    public async Task POST_Streaming_WithConversationObject_RoundTripsInCreatedEvent()
    {
        var response = await PostResponsesAsync(new
        {
            model = "test",
            stream = true,
            conversation = new { id = "conv_stream2" }
        });

        var events = await ParseSseAsync(response);
        var createdEvent = events.First(e => e.EventType == "response.created");
        using var doc = JsonDocument.Parse(createdEvent.Data);
        var conv = doc.RootElement.GetProperty("response").GetProperty("conversation");
        Assert.That(conv.GetProperty("id").GetString(), Is.EqualTo("conv_stream2"));
    }

    [Test]
    public async Task POST_Streaming_ConversationStamped_OnCompletedEvent()
    {
        var response = await PostResponsesAsync(new
        {
            model = "test",
            stream = true,
            conversation = "conv_completed1"
        });

        var events = await ParseSseAsync(response);
        var completedEvent = events.First(e => e.EventType == "response.completed");
        using var doc = JsonDocument.Parse(completedEvent.Data);
        var conv = doc.RootElement.GetProperty("response").GetProperty("conversation");
        Assert.That(conv.GetProperty("id").GetString(), Is.EqualTo("conv_completed1"));
    }

    [Test]
    public async Task POST_Streaming_ConversationStamped_OnAllLifecycleEvents()
    {
        var response = await PostResponsesAsync(new
        {
            model = "test",
            stream = true,
            conversation = "conv_lifecycle1"
        });

        var events = await ParseSseAsync(response);

        // Check every response.* lifecycle event that embeds a response snapshot
        var lifecycleEventTypes = new[] { "response.created", "response.in_progress", "response.completed" };
        foreach (var eventType in lifecycleEventTypes)
        {
            var evt = events.FirstOrDefault(e => e.EventType == eventType);
            if (evt is null)
                continue;

            using var doc = JsonDocument.Parse(evt.Data);
            Assert.That(
                doc.RootElement.TryGetProperty("response", out var resp), Is.True,
                $"{eventType} should have a 'response' property");
            var conv = resp.GetProperty("conversation");
            Assert.That(
                conv.GetProperty("id").GetString(),
                Is.EqualTo("conv_lifecycle1"),
                $"Conversation ID not stamped on {eventType}");
        }
    }

    [Test]
    public async Task POST_Background_WithConversationString_RoundTripsInResponse()
    {
        var response = await PostResponsesAsync(new
        {
            model = "test",
            background = true,
            conversation = "conv_bg1"
        });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(response);
        var conv = doc.RootElement.GetProperty("conversation");
        Assert.That(conv.GetProperty("id").GetString(), Is.EqualTo("conv_bg1"));
    }

    [Test]
    public async Task POST_Default_WithoutConversation_ResponseHasNullConversation()
    {
        var response = await PostResponsesAsync(new { model = "test" });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(response);
        // conversation should be absent or null when not provided
        if (doc.RootElement.TryGetProperty("conversation", out var conv))
        {
            Assert.That(conv.ValueKind, Is.EqualTo(JsonValueKind.Null));
        }
    }
}
