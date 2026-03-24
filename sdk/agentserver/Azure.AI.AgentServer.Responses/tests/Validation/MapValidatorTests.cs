// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.AI.AgentServer.Responses.Tests.Validation;

/// <summary>
/// Tests for map and opaque-object validators — verifies that MetadataValidator,
/// ResponsePromptVariablesValidator, VectorStoreFileAttributesValidator, and opaque-object
/// validators perform meaningful validation (value-kind checks, map value validation).
/// Covers US5 — Fix No-Op Validators for Union and Map Types.
/// </summary>
public class MapValidatorTests
{
    private static ValidationResult ValidateElement(string json, Func<JsonElement, ValidationResult> validator)
    {
        using var doc = JsonDocument.Parse(json);
        return validator(doc.RootElement);
    }

    // =======================================================================
    // MetadataValidator (additionalProperties: {type: string})
    // =======================================================================

    // T047: MetadataValidator rejects string input (expected object)
    [Test]
    public void Metadata_RejectsString()
    {
        var result = ValidateElement("\"not-an-object\"", MetadataValidator.Validate);

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$" && e.Message.Contains("object"));
    }

    // T048: MetadataValidator accepts empty object {}
    [Test]
    public void Metadata_AcceptsEmptyObject()
    {
        var result = ValidateElement("{}", MetadataValidator.Validate);

        Assert.That(result.IsValid, Is.True);
    }

    // T049: MetadataValidator rejects object with non-string values {"key": 42}
    [Test]
    public void Metadata_RejectsNonStringValues()
    {
        var result = ValidateElement("""{"key": 42}""", MetadataValidator.Validate);

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$.key" && e.Message.Contains("string"));
    }

    // Additional: MetadataValidator accepts object with string values
    [Test]
    public void Metadata_AcceptsStringValues()
    {
        var result = ValidateElement("""{"key": "value", "another": "data"}""", MetadataValidator.Validate);

        Assert.That(result.IsValid, Is.True);
    }

    // Additional: MetadataValidator accepts null values (map values can be null)
    [Test]
    public void Metadata_AcceptsNullValues()
    {
        var result = ValidateElement("""{"key": null}""", MetadataValidator.Validate);

        Assert.That(result.IsValid, Is.True);
    }

    // =======================================================================
    // ResponsePromptVariablesValidator (additionalProperties: anyOf[string, InputTextContent, InputImageContent, InputFileContent])
    // =======================================================================

    // T050: ResponsePromptVariablesValidator rejects number input
    [Test]
    public void ResponsePromptVariables_RejectsNumber()
    {
        var result = ValidateElement("42", ResponsePromptVariablesValidator.Validate);

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$" && e.Message.Contains("object"));
    }

    // T051: ResponsePromptVariablesValidator accepts {"var1": "value1"}
    [Test]
    public void ResponsePromptVariables_AcceptsStringValues()
    {
        var result = ValidateElement("""{"var1": "value1"}""", ResponsePromptVariablesValidator.Validate);

        Assert.That(result.IsValid, Is.True);
    }

    // Additional: ResponsePromptVariablesValidator accepts object values (InputTextContent etc.)
    [Test]
    public void ResponsePromptVariables_AcceptsObjectValues()
    {
        var result = ValidateElement("""{"var1": {"type": "input_text", "text": "hello"}}""", ResponsePromptVariablesValidator.Validate);

        Assert.That(result.IsValid, Is.True);
    }

    // Additional: ResponsePromptVariablesValidator rejects number value in map
    [Test]
    public void ResponsePromptVariables_RejectsNumberValue()
    {
        var result = ValidateElement("""{"var1": 42}""", ResponsePromptVariablesValidator.Validate);

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$.var1");
    }

    // =======================================================================
    // VectorStoreFileAttributesValidator (additionalProperties: anyOf[string, number, boolean])
    // =======================================================================

    // T052: VectorStoreFileAttributesValidator rejects string input
    [Test]
    public void VectorStoreFileAttributes_RejectsString()
    {
        var result = ValidateElement("\"not-an-object\"", VectorStoreFileAttributesValidator.Validate);

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$" && e.Message.Contains("object"));
    }

    // T053: VectorStoreFileAttributesValidator accepts object
    [Test]
    public void VectorStoreFileAttributes_AcceptsObject()
    {
        var result = ValidateElement("""{"tag": "important", "score": 0.95, "active": true}""",
            VectorStoreFileAttributesValidator.Validate);

        Assert.That(result.IsValid, Is.True);
    }

    // Additional: VectorStoreFileAttributesValidator rejects object with invalid values
    [Test]
    public void VectorStoreFileAttributes_RejectsArrayValue()
    {
        var result = ValidateElement("""{"tags": [1, 2, 3]}""",
            VectorStoreFileAttributesValidator.Validate);

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$.tags");
    }

    // =======================================================================
    // MCPListToolsToolAnnotationsValidator (type: object, no properties — opaque)
    // =======================================================================

    // T054: MCPListToolsToolAnnotationsValidator rejects array input
    [Test]
    public void MCPListToolsToolAnnotations_RejectsArray()
    {
        var result = ValidateElement("[]", MCPListToolsToolAnnotationsValidator.Validate);

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$" && e.Message.Contains("object"));
    }

    // Additional: MCPListToolsToolAnnotationsValidator accepts object
    [Test]
    public void MCPListToolsToolAnnotations_AcceptsObject()
    {
        var result = ValidateElement("{}", MCPListToolsToolAnnotationsValidator.Validate);

        Assert.That(result.IsValid, Is.True);
    }

    // =======================================================================
    // MCPListToolsToolInputSchemaValidator (type: object, no properties — opaque)
    // =======================================================================

    // T055: MCPListToolsToolInputSchemaValidator rejects string input
    [Test]
    public void MCPListToolsToolInputSchema_RejectsString()
    {
        var result = ValidateElement("\"not-an-object\"", MCPListToolsToolInputSchemaValidator.Validate);

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$" && e.Message.Contains("object"));
    }

    // =======================================================================
    // ResponseFormatJsonSchemaSchemaValidator (additionalProperties: {})
    // =======================================================================

    // T056: ResponseFormatJsonSchemaSchemaValidator rejects number input
    [Test]
    public void ResponseFormatJsonSchemaSchema_RejectsNumber()
    {
        var result = ValidateElement("123", ResponseFormatJsonSchemaSchemaValidator.Validate);

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$" && e.Message.Contains("object"));
    }

    // Additional: ResponseFormatJsonSchemaSchemaValidator accepts object
    [Test]
    public void ResponseFormatJsonSchemaSchema_AcceptsObject()
    {
        var result = ValidateElement("""{"type": "object", "properties": {}}""",
            ResponseFormatJsonSchemaSchemaValidator.Validate);

        Assert.That(result.IsValid, Is.True);
    }
}
