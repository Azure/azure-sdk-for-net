// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol tests for B29 — Request payload validation.
/// Invalid payloads → HTTP 400 with <c>error.details[]</c> array.
/// Each detail: <c>type: "invalid_request_error"</c>, <c>code: "invalid_value"</c>, <c>param: "$.field"</c>.
/// </summary>
public class PayloadValidationProtocolTests : ProtocolTestBase
{
    // Validates: B29 — wrong field type → 400 with details[] containing field info
    [Test]
    public async Task POST_WrongFieldType_Returns400_WithDetailsArray()
    {
        // model should be a string, not a number
        var response = await PostResponsesAsync("{\"model\": 42}");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");

        // Top-level error shape
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));

        // B29: details[] array must be present
        Assert.That(error.TryGetProperty("details", out var details), Is.True, "error.details[] must be present for validation errors");
        Assert.That(details.ValueKind, Is.EqualTo(JsonValueKind.Array));
        Assert.That(details.GetArrayLength() >= 1, Is.True, "details[] must have at least one entry");

        // Each detail has: code, type, param
        var detail = details[0];
        Assert.That(detail.GetProperty("code").GetString(), Is.EqualTo("invalid_value"));
        Assert.That(detail.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));
    }

    // Validates: B29 — detail param contains JSON path
    [Test]
    public async Task POST_WrongFieldType_DetailParam_HasJsonPath()
    {
        var response = await PostResponsesAsync("{\"model\": 42}");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        using var doc = await ParseJsonAsync(response);
        var details = doc.RootElement.GetProperty("error").GetProperty("details");

        // The param should reference the invalid field path
        var foundModelParam = false;
        for (int i = 0; i < details.GetArrayLength(); i++)
        {
            var detail = details[i];
            if (detail.TryGetProperty("param", out var param))
            {
                var paramStr = param.GetString();
                if (paramStr is not null && paramStr.Contains("model"))
                {
                    foundModelParam = true;
                    break;
                }
            }
        }
        Assert.That(foundModelParam, Is.True, "details[] should contain a param referencing 'model'");
    }

    // Validates: B29 — multiple validation errors produce multiple details[]
    [Test]
    public async Task POST_MultipleErrors_Returns400_WithMultipleDetails()
    {
        // model is wrong type AND temperature is wrong type
        var response = await PostResponsesAsync(
            "{\"model\": 42, \"temperature\": \"hot\"}");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));

        var details = error.GetProperty("details");
        Assert.That(details.GetArrayLength() >= 2, Is.True,
            "Multiple validation errors should produce multiple details[] entries");
    }

    // Validates: B29 — valid payload does not trigger validation
    [Test]
    public async Task POST_ValidPayload_Returns200_NoValidationError()
    {
        var response = await PostResponsesAsync(new { model = "test" });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }
}
