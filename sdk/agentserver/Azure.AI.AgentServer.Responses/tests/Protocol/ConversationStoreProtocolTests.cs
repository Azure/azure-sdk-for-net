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
}
