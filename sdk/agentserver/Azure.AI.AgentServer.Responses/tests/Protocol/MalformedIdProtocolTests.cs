// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol tests for B40 — Malformed response ID validation.
/// All endpoints taking {id} must validate the ID format before lookup.
/// Malformed IDs return HTTP 400 with code: "invalid_parameters" and
/// param: "responseId{value}", not 404.
/// </summary>
public class MalformedIdProtocolTests : ProtocolTestBase
{
    // ════════════════════════════════════════════════════════════════
    // GET /responses/{id} — malformed ID returns 400
    // ════════════════════════════════════════════════════════════════

    [TestCase("totally-invalid")]
    [TestCase("resp_abc123")]
    [TestCase("caresp_tooshort")]
    public async Task GET_MalformedId_Returns400_WithInvalidParameters(string badId)
    {
        var response = await GetResponseAsync(badId);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("message").GetString(), Is.EqualTo("Malformed identifier."));
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("invalid_parameters"));
        Assert.That(error.GetProperty("param").GetString(), Is.EqualTo($"responseId{{{badId}}}"));
    }

    // ════════════════════════════════════════════════════════════════
    // GET /responses/{id}?stream=true — malformed ID returns 400
    // ════════════════════════════════════════════════════════════════

    [Test]
    public async Task GET_SSE_MalformedId_Returns400_WithInvalidParameters()
    {
        var badId = "not-a-valid-id";
        var response = await GetResponseStreamAsync(badId);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("invalid_parameters"));
        Assert.That(error.GetProperty("param").GetString(), Is.EqualTo($"responseId{{{badId}}}"));
    }

    // ════════════════════════════════════════════════════════════════
    // POST /responses/{id}/cancel — malformed ID returns 400
    // ════════════════════════════════════════════════════════════════

    [Test]
    public async Task Cancel_MalformedId_Returns400_WithInvalidParameters()
    {
        var badId = "resp_abc123";
        var response = await CancelResponseAsync(badId);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("message").GetString(), Is.EqualTo("Malformed identifier."));
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("invalid_parameters"));
        Assert.That(error.GetProperty("param").GetString(), Is.EqualTo($"responseId{{{badId}}}"));
    }

    // ════════════════════════════════════════════════════════════════
    // DELETE /responses/{id} — malformed ID returns 400
    // ════════════════════════════════════════════════════════════════

    [Test]
    public async Task Delete_MalformedId_Returns400_WithInvalidParameters()
    {
        var badId = "garbage-id-value";
        var response = await Client.DeleteAsync($"/responses/{badId}");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("message").GetString(), Is.EqualTo("Malformed identifier."));
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("invalid_parameters"));
        Assert.That(error.GetProperty("param").GetString(), Is.EqualTo($"responseId{{{badId}}}"));
    }

    // ════════════════════════════════════════════════════════════════
    // GET /responses/{id}/input_items — malformed ID returns 400
    // ════════════════════════════════════════════════════════════════

    [Test]
    public async Task InputItems_MalformedId_Returns400_WithInvalidParameters()
    {
        var badId = "caresp_tooshort";
        var response = await Client.GetAsync($"/responses/{badId}/input_items");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("message").GetString(), Is.EqualTo("Malformed identifier."));
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("invalid_parameters"));
        Assert.That(error.GetProperty("param").GetString(), Is.EqualTo($"responseId{{{badId}}}"));
    }

    // ════════════════════════════════════════════════════════════════
    // Valid IDs still work (regression guard)
    // ════════════════════════════════════════════════════════════════

    [Test]
    public async Task GET_ValidFormatButUnknown_Returns404_Not400()
    {
        // Create a valid-format ID that doesn't exist
        var validId = IdGenerator.NewResponseId();
        var response = await GetResponseAsync(validId);

        // Valid format → passes B40 → reaches lookup → 404
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
    }
}
