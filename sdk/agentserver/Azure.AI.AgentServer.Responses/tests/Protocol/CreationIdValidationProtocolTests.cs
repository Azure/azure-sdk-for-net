// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol tests for malformed ID validation on POST /responses request body fields.
/// Validates that <c>previous_response_id</c> must conform to <c>caresp_*</c> format
/// when provided. Body field validation is caught by payload validation (B29) and uses
/// the <c>details[]</c> error shape with <c>code: "invalid_value"</c> and JSON-path
/// <c>param</c> notation (e.g., <c>$.previous_response_id</c>).
/// </summary>
public class CreationIdValidationProtocolTests : ProtocolTestBase
{
    // ════════════════════════════════════════════════════════════════
    // previous_response_id — malformed → 400 via B29 details[]
    // ════════════════════════════════════════════════════════════════

    [Test]
    public async Task POST_MalformedPreviousResponseId_Returns400()
    {
        var response = await PostResponsesAsync(new
        {
            model = "test",
            previous_response_id = "not-a-valid-id"
        });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));

        // B29: details[] contains the validation error with JSON-path param
        var details = error.GetProperty("details");
        Assert.That(details.GetArrayLength(), Is.GreaterThanOrEqualTo(1));

        var detail = FindDetail(details, "$.previous_response_id");
        Assert.That(detail, Is.Not.Null, "Expected detail with param $.previous_response_id");
        Assert.That(detail!.Value.GetProperty("message").GetString(), Is.EqualTo("Malformed identifier."));
        Assert.That(detail!.Value.GetProperty("code").GetString(), Is.EqualTo("invalid_value"));
    }

    [Test]
    public async Task POST_WrongPrefixPreviousResponseId_Returns400()
    {
        var response = await PostResponsesAsync(new
        {
            model = "test",
            previous_response_id = "resp_abc123"
        });

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        var details = error.GetProperty("details");

        var detail = FindDetail(details, "$.previous_response_id");
        Assert.That(detail, Is.Not.Null, "Expected detail with param $.previous_response_id");
        Assert.That(detail!.Value.GetProperty("message").GetString(), Is.EqualTo("Malformed identifier."));
        Assert.That(detail!.Value.GetProperty("code").GetString(), Is.EqualTo("invalid_value"));
    }

    // ════════════════════════════════════════════════════════════════
    // previous_response_id — valid format, not found → proceeds (OK or 404 from lookup)
    // ════════════════════════════════════════════════════════════════

    [Test]
    public async Task POST_ValidFormatPreviousResponseId_DoesNotReject()
    {
        // Valid format but doesn't exist — should NOT be rejected by format validation
        var validId = IdGenerator.NewResponseId();
        var response = await PostResponsesAsync(new
        {
            model = "test",
            previous_response_id = validId
        });

        // The response may succeed (200) if the server doesn't require the ID to exist,
        // or return an error for a different reason — but NOT with a malformed ID detail
        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            using var doc = await ParseJsonAsync(response);
            var error = doc.RootElement.GetProperty("error");
            if (error.TryGetProperty("details", out var details))
            {
                var detail = FindDetail(details, "$.previous_response_id");
                if (detail is not null)
                {
                    Assert.That(detail!.Value.GetProperty("message").GetString(),
                        Is.Not.EqualTo("Malformed identifier."),
                        "Valid-format previous_response_id must not be rejected as malformed");
                }
            }
        }
    }

    /// <summary>
    /// Finds a detail entry with the specified param path.
    /// </summary>
    private static JsonElement? FindDetail(JsonElement details, string param)
    {
        for (int i = 0; i < details.GetArrayLength(); i++)
        {
            var detail = details[i];
            if (detail.TryGetProperty("param", out var p) && p.GetString() == param)
            {
                return detail;
            }
        }

        return null;
    }
}
