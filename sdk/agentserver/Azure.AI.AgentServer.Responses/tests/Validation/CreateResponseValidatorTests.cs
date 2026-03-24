// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.AI.AgentServer.Responses.Tests.Validation;

/// <summary>
/// Tests for CreateResponsePayloadValidator — required fields, type checks, ranges, enums, valid payloads.
/// Covers T012, T013, T014, T015, T019.
/// </summary>
public class CreateResponseValidatorTests
{
    private static ValidationResult Validate(string json)
    {
        using var doc = JsonDocument.Parse(json);
        return CreateResponsePayloadValidator.Validate(doc.RootElement);
    }

    // -----------------------------------------------------------------------
    // T012 — Required field validation
    // -----------------------------------------------------------------------

    [Test]
    public void MissingModel_IsValid()
    {
        // PW-006: model is optional — payloads without model are valid
        var result = Validate("""{"instructions": "hello" }""");

        Assert.That(result.IsValid, Is.True);
    }

    [Test]
    public void EmptyObject_IsValid()
    {
        // PW-006: model is optional — empty object is valid
        var result = Validate("{}");

        Assert.That(result.IsValid, Is.True);
    }

    // -----------------------------------------------------------------------
    // T013 — Type mismatch validation
    // -----------------------------------------------------------------------

    [Test]
    public void ModelAsNumber_ReturnsTypeError()
    {
        var result = Validate("""{ "model": 42 }""");

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$.model" && e.Message.Contains("string"));
    }

    [Test]
    public void TemperatureAsString_ReturnsTypeError()
    {
        var result = Validate("""{ "model": "gpt-4o", "temperature": "hot" }""");

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$.temperature" && e.Message.Contains("number"));
    }

    [Test]
    public void InstructionsAsNumber_ReturnsTypeError()
    {
        var result = Validate("""{ "model": "gpt-4o", "instructions": 123 }""");

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$.instructions");
    }

    [Test]
    public void ParallelToolCallsAsString_ReturnsTypeError()
    {
        var result = Validate("""{ "model": "gpt-4o", "parallel_tool_calls": "yes" }""");

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$.parallel_tool_calls" && e.Message.Contains("boolean"));
    }

    [Test]
    public void MaxOutputTokensAsString_ReturnsTypeError()
    {
        var result = Validate("""{ "model": "gpt-4o", "max_output_tokens": "big" }""");

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$.max_output_tokens" && e.Message.Contains("integer"));
    }

    [Test]
    public void NonObjectInput_ReturnsError()
    {
        var result = Validate(""" "just a string" """);

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$" && e.Message.Contains("object"));
    }

    [Test]
    public void ArrayInput_ReturnsError()
    {
        var result = Validate("[1, 2, 3]");

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$" && e.Message.Contains("object"));
    }

    // -----------------------------------------------------------------------
    // T014 — Numeric range validation
    // -----------------------------------------------------------------------

    [TestCase(0.0)]
    [TestCase(1.0)]
    [TestCase(2.0)]
    public void Temperature_ValidRange_Passes(double temp)
    {
        var result = Validate($$"""{ "model": "gpt-4o", "temperature": {{temp}} }""");
        Assert.That(result.IsValid, Is.True, string.Join("; ", result.Errors.Select(e => e.Message)));
    }

    [TestCase(0.0)]
    [TestCase(0.5)]
    [TestCase(1.0)]
    public void TopP_ValidRange_Passes(double topP)
    {
        var result = Validate($$"""{ "model": "gpt-4o", "top_p": {{topP}} }""");
        Assert.That(result.IsValid, Is.True, string.Join("; ", result.Errors.Select(e => e.Message)));
    }

    // -----------------------------------------------------------------------
    // T015 — Enum validation
    // -----------------------------------------------------------------------

    [Test]
    public void Truncation_ClosedEnum_AcceptsValidValues()
    {
        var result = Validate("""{ "model": "gpt-4o", "truncation": "auto" }""");
        Assert.That(result.IsValid, Is.True, string.Join("; ", result.Errors.Select(e => e.Message)));

        var result2 = Validate("""{ "model": "gpt-4o", "truncation": "disabled" }""");
        Assert.That(result2.IsValid, Is.True, string.Join("; ", result2.Errors.Select(e => e.Message)));
    }

    [Test]
    public void Truncation_ClosedEnum_RejectsUnknownValues()
    {
        var result = Validate("""{ "model": "gpt-4o", "truncation": "custom_value" }""");
        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$.truncation");
    }

    [Test]
    public void Truncation_WrongType_Rejected()
    {
        var result = Validate("""{ "model": "gpt-4o", "truncation": 42 }""");

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$.truncation");
    }

    // -----------------------------------------------------------------------
    // T019 — Valid payloads pass
    // -----------------------------------------------------------------------

    [Test]
    public void MinimalValidPayload_Passes()
    {
        var result = Validate("""{ "model": "gpt-4o" }""");
        Assert.That(result.IsValid, Is.True, string.Join("; ", result.Errors.Select(e => e.Message)));
    }

    [Test]
    public void FullValidPayload_Passes()
    {
        var result = Validate("""
        {
            "model": "gpt-4o",
            "instructions": "You are a helpful assistant.",
            "temperature": 0.7,
            "top_p": 0.9,
            "max_output_tokens": 1024,
            "parallel_tool_calls": true,
            "stream": true
        }
        """);
        Assert.That(result.IsValid, Is.True, string.Join("; ", result.Errors.Select(e => e.Message)));
    }

    [Test]
    public void ValidPayloadWithInput_Passes()
    {
        var result = Validate("""
        {
            "model": "gpt-4o",
            "input": "What is the meaning of life?"
        }
        """);
        Assert.That(result.IsValid, Is.True, string.Join("; ", result.Errors.Select(e => e.Message)));
    }

    // -----------------------------------------------------------------------
    // Validate(ReadOnlySpan<byte>) overload
    // -----------------------------------------------------------------------

    [Test]
    public void ValidateBytes_MinimalValidPayload_Passes()
    {
        var json = """{ "model": "gpt-4o" }"""u8;
        var result = CreateResponsePayloadValidator.Validate(json);
        Assert.That(result.IsValid, Is.True);
    }

    [Test]
    public void ValidateBytes_MissingModel_IsValid()
    {
        // PW-006: model is optional
        var json = """{ "instructions": "hello" }"""u8;
        var result = CreateResponsePayloadValidator.Validate(json);
        Assert.That(result.IsValid, Is.True);
    }
}
