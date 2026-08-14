// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol tests for metadata constraints on POST /responses.
/// Spec: max 16 key-value pairs, keys max 64 chars, values max 512 chars.
/// Metadata constraints are validated as part of payload validation (B29) and
/// produce <c>details[]</c> entries with <c>code: "invalid_value"</c>.
/// </summary>
public class MetadataConstraintProtocolTests : ProtocolTestBase
{
    // ════════════════════════════════════════════════════════════════
    // Valid metadata passes through
    // ════════════════════════════════════════════════════════════════

    [Test]
    public async Task POST_WithValidMetadata_Returns200()
    {
        var metadata = new Dictionary<string, string>
        {
            ["key1"] = "value1",
            ["key2"] = "value2"
        };

        var response = await PostResponsesAsync(new { model = "test", metadata });
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task POST_With16MetadataPairs_Returns200()
    {
        var metadata = new Dictionary<string, string>();
        for (int i = 1; i <= 16; i++)
        {
            metadata[$"key{i}"] = $"value{i}";
        }

        var response = await PostResponsesAsync(new { model = "test", metadata });
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    // ════════════════════════════════════════════════════════════════
    // Too many pairs → 400
    // ════════════════════════════════════════════════════════════════

    [Test]
    public async Task POST_With17MetadataPairs_Returns400()
    {
        var metadata = new Dictionary<string, string>();
        for (int i = 1; i <= 17; i++)
        {
            metadata[$"key{i}"] = $"value{i}";
        }

        var response = await PostResponsesAsync(new { model = "test", metadata });
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
        XAssert.Contains("16", error.GetProperty("message").GetString()!);

        // B29: details[] with metadata path
        var details = error.GetProperty("details");
        Assert.That(details.GetArrayLength(), Is.GreaterThanOrEqualTo(1));
        var detail = details[0];
        Assert.That(detail.GetProperty("code").GetString(), Is.EqualTo("invalid_value"));
        XAssert.Contains("metadata", detail.GetProperty("param").GetString()!);
    }

    // ════════════════════════════════════════════════════════════════
    // Key too long → 400
    // ════════════════════════════════════════════════════════════════

    [Test]
    public async Task POST_WithKeyTooLong_Returns400()
    {
        var longKey = new string('k', 65);
        var metadata = new Dictionary<string, string>
        {
            [longKey] = "value"
        };

        var response = await PostResponsesAsync(new { model = "test", metadata });
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
        XAssert.Contains("64", error.GetProperty("message").GetString()!);
    }

    [Test]
    public async Task POST_WithKey64Chars_Returns200()
    {
        var exactKey = new string('k', 64);
        var metadata = new Dictionary<string, string>
        {
            [exactKey] = "value"
        };

        var response = await PostResponsesAsync(new { model = "test", metadata });
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    // ════════════════════════════════════════════════════════════════
    // Value too long → 400
    // ════════════════════════════════════════════════════════════════

    [Test]
    public async Task POST_WithValueTooLong_Returns400()
    {
        var longValue = new string('v', 513);
        var metadata = new Dictionary<string, string>
        {
            ["key"] = longValue
        };

        var response = await PostResponsesAsync(new { model = "test", metadata });
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
        XAssert.Contains("512", error.GetProperty("message").GetString()!);
    }

    [Test]
    public async Task POST_WithValue512Chars_Returns200()
    {
        var exactValue = new string('v', 512);
        var metadata = new Dictionary<string, string>
        {
            ["key"] = exactValue
        };

        var response = await PostResponsesAsync(new { model = "test", metadata });
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
}
