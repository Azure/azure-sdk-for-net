// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol conformance tests for creation constraint validation (US4).
/// Validates that invalid <c>store × background</c> combinations are rejected
/// at creation time with correct error shapes.
/// </summary>
public class CreationConstraintTests : ProtocolTestBase
{
    // ── T026: background=true + store=false → 400 ────────────

    [Test]
    public async Task POST_BackgroundTrue_StoreFalse_Returns400_UnsupportedParameter()
    {
        var response = await PostResponsesAsync(new { model = "test", background = true, store = false });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("unsupported_parameter"));
        Assert.That(error.GetProperty("param").GetString(), Is.EqualTo("background"));
    }

    // ── T027: Valid stored combinations (C1-C4) → 200 ────────

    [TestCase(false, false)] // C1: default mode
    [TestCase(false, true)]  // C2: streaming
    [TestCase(true, false)]  // C3: background
    [TestCase(true, true)]   // C4: streaming + background
    public async Task POST_StoredCombinations_Returns200(bool background, bool stream)
    {
        var response = await PostResponsesAsync(new { model = "test", background, stream, store = true });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    // ── T028: Valid ephemeral combinations (C5-C6) → 200 ─────

    [TestCase(false)] // C5: ephemeral default
    [TestCase(true)]  // C6: ephemeral streaming
    public async Task POST_EphemeralNonBackground_Returns200(bool stream)
    {
        var response = await PostResponsesAsync(new { model = "test", background = false, stream, store = false });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    // ── T029: Rejected combinations (C7-C8) → 400 ────────────

    [TestCase(false)] // C7: background + store=false (non-streaming)
    [TestCase(true)]  // C8: background + store=false (streaming)
    public async Task POST_BackgroundWithStoreFalse_Returns400(bool stream)
    {
        var response = await PostResponsesAsync(new { model = "test", background = true, stream, store = false });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
        Assert.That(error.GetProperty("code").GetString(), Is.EqualTo("unsupported_parameter"));
    }

    // ── T030: Edge cases ──────────────────────────────────────

    [Test]
    public async Task POST_EmptyBody_Returns400()
    {
        var response = await PostResponsesAsync("");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
    }

    [Test]
    public async Task POST_InvalidJson_Returns400()
    {
        var response = await PostResponsesAsync("{not-valid-json!");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
    }

    [Test]
    public async Task POST_MissingModel_Returns200_ModelIsOptional()
    {
        // PW-006: model is optional — omitting it should succeed
        var response = await PostResponsesAsync("""{"instructions":"hello"}""");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task POST_UnknownFields_Returns200()
    {
        // Unknown fields should be ignored, not rejected
        var response = await PostResponsesAsync("""{"model":"test","unknown_field":"value","extra":42}""");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
}
