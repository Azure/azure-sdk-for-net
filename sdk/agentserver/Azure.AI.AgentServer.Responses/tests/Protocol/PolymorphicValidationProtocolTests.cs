// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Tests.Helpers;

namespace Azure.AI.AgentServer.Responses.Tests.Protocol;

/// <summary>
/// Protocol tests for polymorphic validation gaps — verifies that the full HTTP pipeline
/// correctly returns HTTP 400 with validation errors when polymorphic union properties
/// receive invalid types on POST /responses.
/// Covers T022 (US1), T031/T032 (US2).
/// </summary>
public class PolymorphicValidationProtocolTests : ProtocolTestBase
{
    // T022: POST /responses with "input": 42 returns HTTP 400
    [Test]
    public async Task POST_Input42_Returns400_WithValidationError()
    {
        var response = await PostResponsesAsync("""{"model": "gpt-4o", "input": 42}""");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));

        // Check details contain input-related error
        Assert.That(error.TryGetProperty("details", out var details), Is.True, "error.details[] must be present");
        Assert.That(details.ValueKind, Is.EqualTo(JsonValueKind.Array));
        Assert.That(details.GetArrayLength() >= 1, Is.True, "details[] must have at least one entry");

        var foundInputParam = false;
        for (int i = 0; i < details.GetArrayLength(); i++)
        {
            if (details[i].TryGetProperty("param", out var param))
            {
                var paramStr = param.GetString();
                if (paramStr is not null && paramStr.Contains("input"))
                {
                    foundInputParam = true;
                    break;
                }
            }
        }
        Assert.That(foundInputParam, Is.True, "details[] should contain a param referencing 'input'");
    }

    // T031: POST /responses with "tool_choice": 123 returns HTTP 400
    [Test]
    public async Task POST_ToolChoice123_Returns400_WithValidationError()
    {
        var response = await PostResponsesAsync("""{"model": "gpt-4o", "tool_choice": 123}""");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));

        Assert.That(error.TryGetProperty("details", out var details), Is.True, "error.details[] must be present");
        Assert.That(details.ValueKind, Is.EqualTo(JsonValueKind.Array));
        Assert.That(details.GetArrayLength() >= 1, Is.True);

        var foundToolChoiceParam = false;
        for (int i = 0; i < details.GetArrayLength(); i++)
        {
            if (details[i].TryGetProperty("param", out var param))
            {
                var paramStr = param.GetString();
                if (paramStr is not null && paramStr.Contains("tool_choice"))
                {
                    foundToolChoiceParam = true;
                    break;
                }
            }
        }
        Assert.That(foundToolChoiceParam, Is.True, "details[] should contain a param referencing 'tool_choice'");
    }

    // T032: POST /responses with "conversation": 42 returns HTTP 400
    [Test]
    public async Task POST_Conversation42_Returns400_WithValidationError()
    {
        var response = await PostResponsesAsync("""{"model": "gpt-4o", "conversation": 42}""");

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        using var doc = await ParseJsonAsync(response);
        var error = doc.RootElement.GetProperty("error");
        Assert.That(error.GetProperty("type").GetString(), Is.EqualTo("invalid_request_error"));

        Assert.That(error.TryGetProperty("details", out var details), Is.True, "error.details[] must be present");
        Assert.That(details.ValueKind, Is.EqualTo(JsonValueKind.Array));
        Assert.That(details.GetArrayLength() >= 1, Is.True);

        var foundConversationParam = false;
        for (int i = 0; i < details.GetArrayLength(); i++)
        {
            if (details[i].TryGetProperty("param", out var param))
            {
                var paramStr = param.GetString();
                if (paramStr is not null && paramStr.Contains("conversation"))
                {
                    foundConversationParam = true;
                    break;
                }
            }
        }
        Assert.That(foundConversationParam, Is.True, "details[] should contain a param referencing 'conversation'");
    }
}
