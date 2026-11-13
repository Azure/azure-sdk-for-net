// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Text;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol conformance tests for the <c>x-agent-response-id</c> request header (B38).
/// When the header is present, the library MUST use its value as the response ID
/// instead of generating one. The value MUST be validated as a well-formed caresp_ ID.
/// </summary>
public class ResponseIdHeaderTests : ProtocolTestBase
{
    // ── Default mode ──

    [Test]
    public async Task POST_Default_WithAgentResponseIdHeader_UsesHeaderValueAsResponseId()
    {
        var customId = IdGenerator.NewResponseId();
        var response = await PostWithHeaderAsync(
            new { model = "test" },
            "x-agent-response-id", customId);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(response);
        Assert.That(doc.RootElement.GetProperty("id").GetString(), Is.EqualTo(customId));
    }

    [Test]
    public async Task POST_Default_WithoutAgentResponseIdHeader_GeneratesCarespId()
    {
        var response = await PostResponsesAsync(new { model = "test" });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(response);
        var id = doc.RootElement.GetProperty("id").GetString();
        Assert.That(id, Does.StartWith("caresp_"));
    }

    [Test]
    public async Task POST_Default_WithEmptyAgentResponseIdHeader_GeneratesCarespId()
    {
        var response = await PostWithHeaderAsync(
            new { model = "test" },
            "x-agent-response-id", "");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(response);
        var id = doc.RootElement.GetProperty("id").GetString();
        Assert.That(id, Does.StartWith("caresp_"));
    }

    [Test]
    public async Task POST_Default_WithInvalidAgentResponseIdHeader_Returns400()
    {
        var response = await PostWithHeaderAsync(
            new { model = "test" },
            "x-agent-response-id", "not-a-valid-id");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    [Test]
    public async Task POST_Default_WithWrongPrefixAgentResponseIdHeader_Returns400()
    {
        // Valid format but wrong prefix (msg_ instead of caresp_)
        var wrongPrefixId = IdGenerator.NewId("msg");
        var response = await PostWithHeaderAsync(
            new { model = "test" },
            "x-agent-response-id", wrongPrefixId);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    // ── Streaming mode ──

    [Test]
    public async Task POST_Streaming_WithAgentResponseIdHeader_UsesHeaderValueAsResponseId()
    {
        var customId = IdGenerator.NewResponseId();
        var response = await PostWithHeaderAsync(
            new { model = "test", stream = true },
            "x-agent-response-id", customId);

        var events = await ParseSseAsync(response);
        var createdEvent = events.First(e => e.EventType == "response.created");
        using var doc = JsonDocument.Parse(createdEvent.Data);
        var id = doc.RootElement.GetProperty("response").GetProperty("id").GetString();
        Assert.That(id, Is.EqualTo(customId));
    }

    [Test]
    public async Task POST_Streaming_WithInvalidAgentResponseIdHeader_Returns400()
    {
        var response = await PostWithHeaderAsync(
            new { model = "test", stream = true },
            "x-agent-response-id", "bad-id-value");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    // ── Background mode ──

    [Test]
    public async Task POST_Background_WithAgentResponseIdHeader_UsesHeaderValueAsResponseId()
    {
        var customId = IdGenerator.NewResponseId();
        var response = await PostWithHeaderAsync(
            new { model = "test", background = true },
            "x-agent-response-id", customId);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        using var doc = await ParseJsonAsync(response);
        Assert.That(doc.RootElement.GetProperty("id").GetString(), Is.EqualTo(customId));
    }

    // ── Handler receives the correct ResponseId on context ──

    [Test]
    public async Task POST_Default_WithAgentResponseIdHeader_HandlerContextHasCorrectResponseId()
    {
        var customId = IdGenerator.NewResponseId();
        await PostWithHeaderAsync(
            new { model = "test" },
            "x-agent-response-id", customId);

        Assert.That(Handler.LastContext, Is.Not.Null);
        Assert.That(Handler.LastContext!.ResponseId, Is.EqualTo(customId));
    }

    // ── Helper ──

    private Task<HttpResponseMessage> PostWithHeaderAsync(
        object payload, string headerName, string headerValue)
    {
        var json = JsonSerializer.Serialize(payload);
        var request = new HttpRequestMessage(HttpMethod.Post, "/responses")
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };
        request.Headers.TryAddWithoutValidation(headerName, headerValue);
        return Client.SendAsync(request);
    }
}
