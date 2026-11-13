// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.AI.AgentServer.Responses.Tests.Validation;

/// <summary>
/// Tests for discriminator dispatch in generated validators — tools, input items, output items.
/// Covers T016.
/// </summary>
public class DiscriminatorDispatchTests
{
    private static ValidationResult ValidateElement(string json, Func<JsonElement, ValidationResult> validator)
    {
        using var doc = JsonDocument.Parse(json);
        return validator(doc.RootElement);
    }

    // -----------------------------------------------------------------------
    // Tool discriminator dispatch
    // -----------------------------------------------------------------------

    [Test]
    public void Tool_FunctionType_DispatchesToFunctionValidator()
    {
        var result = ValidateElement("""
        {
            "type": "function",
            "name": "get_weather",
            "parameters": {}
        }
        """, ToolValidator.Validate);

        // Should dispatch to FunctionToolValidator — may pass or fail
        // based on required fields, but should NOT fail on discriminator
        XAssert.DoesNotContain(result.Errors, e => e.Message.Contains("discriminator"));
    }

    [Test]
    public void Tool_MissingType_ReturnsDiscriminatorError()
    {
        var result = ValidateElement("""
        {
            "name": "get_weather"
        }
        """, ToolValidator.Validate);

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$.type" && e.Message.Contains("discriminator"));
    }

    [Test]
    public void Tool_TypeNotString_ReturnsDiscriminatorError()
    {
        var result = ValidateElement("""
        {
            "type": 42
        }
        """, ToolValidator.Validate);

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Message.Contains("discriminator"));
    }

    [Test]
    public void Tool_UnknownType_ReturnsSuccess()
    {
        // Decision D-7: unknown types return Success (forward compatible)
        var result = ValidateElement("""
        {
            "type": "future_tool_type_2027",
            "some_field": "value"
        }
        """, ToolValidator.Validate);

        Assert.That(result.IsValid, Is.True);
    }

    // -----------------------------------------------------------------------
    // OutputItem discriminator dispatch
    // -----------------------------------------------------------------------

    [Test]
    public void OutputItem_MessageType_Dispatches()
    {
        var result = ValidateElement("""
        {
            "type": "message",
            "id": "msg_123",
            "role": "assistant",
            "content": [],
            "status": "completed"
        }
        """, OutputItemValidator.Validate);

        // Should dispatch to OutputItemMessageValidator or OutputItemMessageValidator
        XAssert.DoesNotContain(result.Errors, e => e.Message.Contains("discriminator"));
    }

    [Test]
    public void OutputItem_MissingType_ReturnsError()
    {
        var result = ValidateElement("""
        {
            "id": "item_123"
        }
        """, OutputItemValidator.Validate);

        Assert.That(result.IsValid, Is.False);
    }

    [Test]
    public void OutputItem_UnknownType_ReturnsSuccess()
    {
        var result = ValidateElement("""
        {
            "type": "future_output_type"
        }
        """, OutputItemValidator.Validate);

        Assert.That(result.IsValid, Is.True);
    }
}
