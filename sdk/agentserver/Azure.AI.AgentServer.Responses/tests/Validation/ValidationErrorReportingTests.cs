// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.AI.AgentServer.Responses.Tests.Validation;

/// <summary>
/// Tests for multi-error reporting — all errors collected, field paths use $.field format.
/// Covers T017.
/// </summary>
public class ValidationErrorReportingTests
{
    private static ValidationResult Validate(string json)
    {
        using var doc = JsonDocument.Parse(json);
        return CreateResponsePayloadValidator.Validate(doc.RootElement);
    }

    [Test]
    public void MultipleErrors_AllCollected()
    {
        // temperature wrong type + model wrong type = at least 2 errors
        var result = Validate("""{ "model": 42, "temperature": "hot" }""");

        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Count >= 2,
            $"Expected at least 2 errors, got {result.Errors.Count}: {string.Join("; ", result.Errors.Select(e => e.Message))}");
    }

    [Test]
    public void ErrorPaths_UseDollarDotFormat()
    {
        var result = Validate("""{ "temperature": "hot" }""");

        foreach (var error in result.Errors)
        {
            XAssert.StartsWith("$", error.Path);
        }
    }

    [Test]
    public void ErrorMessages_AreHumanReadable()
    {
        // PW-006: model is optional, use invalid type to trigger errors
        var result = Validate("""{ "model": 42 }""");

        Assert.IsFalse(result.IsValid);
        foreach (var error in result.Errors)
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(error.Message));
            Assert.IsTrue(error.Message.Length > 5, $"Error message too short: '{error.Message}'");
        }
    }

    [Test]
    public void NestedArrayError_IncludesIndex()
    {
        // tools is an array of discriminated Tool objects — invalid tool should include path with index
        var result = Validate("""
        {
            "model": "gpt-4o",
            "tools": [
                { "type": "function", "name": "ok" },
                { "missing_type": true }
            ]
        }
        """);

        // The second tool is missing "type" discriminator
        Assert.IsFalse(result.IsValid);
        XAssert.Contains(result.Errors, e => e.Path.Contains("["));
    }
}
