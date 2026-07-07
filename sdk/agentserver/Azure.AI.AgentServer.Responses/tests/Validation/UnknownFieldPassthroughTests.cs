// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.AI.AgentServer.Responses.Tests.Validation;

/// <summary>
/// Tests that unknown/additional fields are silently accepted (not rejected).
/// Covers T018.
/// </summary>
public class UnknownFieldPassthroughTests
{
    private static ValidationResult Validate(string json)
    {
        using var doc = JsonDocument.Parse(json);
        return CreateResponsePayloadValidator.Validate(doc.RootElement);
    }

    [Test]
    public void UnknownTopLevelField_Accepted()
    {
        var result = Validate("""
        {
            "model": "gpt-4o",
            "future_field_2027": true,
            "another_unknown": { "nested": "value" }
        }
        """);

        Assert.That(result.IsValid, Is.True, $"Unknown fields should be accepted. Errors: {string.Join("; ", result.Errors.Select(e => $"{e.Path}: {e.Message}"))}");
    }

    [Test]
    public void UnknownNestedField_Accepted()
    {
        var result = Validate("""
        {
            "model": "gpt-4o",
            "reasoning": {
                "effort": "high",
                "unknown_reasoning_field": 42
            }
        }
        """);

        Assert.That(result.IsValid, Is.True, $"Unknown nested fields should be accepted. Errors: {string.Join("; ", result.Errors.Select(e => $"{e.Path}: {e.Message}"))}");
    }

    [Test]
    public void AdditionalPropertiesInTools_Accepted()
    {
        var result = Validate("""
        {
            "model": "gpt-4o",
            "tools": [
                {
                    "type": "function",
                    "name": "get_weather",
                    "parameters": {},
                    "strict": false,
                    "future_tool_property": "v2"
                }
            ]
        }
        """);

        Assert.That(result.IsValid, Is.True, $"Unknown tool fields should be accepted. Errors: {string.Join("; ", result.Errors.Select(e => $"{e.Path}: {e.Message}"))}");
    }
}
