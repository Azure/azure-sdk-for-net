// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.AI.AgentServer.Responses.Tests.Validation;

/// <summary>
/// Tests for polymorphic union validators — verifies that string|object, string|array,
/// and multi-branch union validators correctly accept valid types and reject invalid types.
/// Covers US1 (input), US2 (tool_choice, conversation), US3 (tool-specific properties),
/// and US4 (tool call output content).
/// </summary>
public class PolymorphicValidatorTests
{
    // -----------------------------------------------------------------------
    // Helpers
    // -----------------------------------------------------------------------

    private static ValidationResult ValidateCreateResponse(string json)
    {
        using var doc = JsonDocument.Parse(json);
        return CreateResponsePayloadValidator.Validate(doc.RootElement);
    }

    private static ValidationResult ValidateElement(string json, Func<JsonElement, ValidationResult> validator)
    {
        using var doc = JsonDocument.Parse(json);
        return validator(doc.RootElement);
    }

    // =======================================================================
    // US1 — Reject Invalid Polymorphic Input Values on CreateResponse
    // =======================================================================

    // T014: InputParamValidator accepts string input
    [Test]
    public void InputParam_AcceptsString()
    {
        var result = ValidateElement("\"hello world\"", InputParamValidator.Validate);

        Assert.That(result.IsValid, Is.True);
    }

    // T015: InputParamValidator accepts array input
    [Test]
    public void InputParam_AcceptsArray()
    {
        var result = ValidateElement("[]", InputParamValidator.Validate);

        Assert.That(result.IsValid, Is.True);
    }

    // T016: InputParamValidator rejects number input
    [Test]
    public void InputParam_RejectsNumber()
    {
        var result = ValidateElement("42", InputParamValidator.Validate);

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$");
    }

    // T017: InputParamValidator rejects boolean input
    [Test]
    public void InputParam_RejectsBoolean()
    {
        var result = ValidateElement("true", InputParamValidator.Validate);

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$");
    }

    // T018: InputParamValidator rejects object input
    [Test]
    public void InputParam_RejectsObject()
    {
        var result = ValidateElement("{}", InputParamValidator.Validate);

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$");
    }

    // T019: CreateResponsePayloadValidator rejects "input": 42
    [Test]
    public void CreateResponse_Input42_ReturnsError()
    {
        var result = ValidateCreateResponse("""{"model": "gpt-4o", "input": 42}""");

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$.input");
    }

    // T020: CreateResponsePayloadValidator accepts "input": "hello"
    [Test]
    public void CreateResponse_InputString_IsValid()
    {
        var result = ValidateCreateResponse("""{"model": "gpt-4o", "input": "hello"}""");

        Assert.That(result.IsValid, Is.True);
    }

    // T021: CreateResponsePayloadValidator rejects "input": null (not nullable)
    [Test]
    public void CreateResponse_InputNull_ReturnsError()
    {
        // input is not marked nullable in the OpenAPI spec — null is invalid
        var result = ValidateCreateResponse("""{"model": "gpt-4o", "input": null}""");

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$.input");
    }

    // T021b: InputParamValidator validates array items — valid Item objects accepted
    [Test]
    public void InputParam_AcceptsValidItemArray()
    {
        // A valid function_call_output Item with all required fields
        var result = ValidateElement(
            """[{"type": "function_call_output", "call_id": "call_1", "output": "result"}]""",
            InputParamValidator.Validate);

        Assert.That(result.IsValid, Is.True);
    }

    // T021c: InputParamValidator validates array items — invalid items produce indexed errors
    [Test]
    public void InputParam_RejectsInvalidItemInArray()
    {
        // An array containing a number (not an Item object) — should fail item validation
        var result = ValidateElement(
            """[42]""",
            InputParamValidator.Validate);

        Assert.That(result.IsValid, Is.False);
        // Error path should contain array index
        XAssert.Contains(result.Errors, e => e.Path.Contains("[0]"));
    }

    // T021d: CreateResponse input array items are validated end-to-end
    [Test]
    public void CreateResponse_InputArrayWithInvalidItem_ReturnsIndexedError()
    {
        var result = ValidateCreateResponse(
            """{"model": "gpt-4o", "input": [{"type": "message", "role": "user", "content": "ok"}, "not-an-item-object"]}""");

        Assert.That(result.IsValid, Is.False);
        // Error should reference the second item in the array
        XAssert.Contains(result.Errors, e => e.Path.Contains("$.input[1]"));
    }

    // =======================================================================
    // US2 — Reject Invalid tool_choice and conversation Values
    // =======================================================================

    // T023: CreateResponsePayloadValidator accepts "tool_choice": "auto" (enum string)
    [Test]
    public void CreateResponse_ToolChoiceAuto_IsValid()
    {
        var result = ValidateCreateResponse("""{"model": "gpt-4o", "tool_choice": "auto"}""");

        Assert.That(result.IsValid, Is.True);
    }

    // T024: CreateResponsePayloadValidator accepts "tool_choice": {"type": "function", "name": "foo"} (discriminated object)
    [Test]
    public void CreateResponse_ToolChoiceObject_IsValid()
    {
        var result = ValidateCreateResponse("""{"model": "gpt-4o", "tool_choice": {"type": "function", "name": "foo"}}""");

        Assert.That(result.IsValid, Is.True);
    }

    // T025: CreateResponsePayloadValidator rejects "tool_choice": 42
    [Test]
    public void CreateResponse_ToolChoice42_ReturnsError()
    {
        var result = ValidateCreateResponse("""{"model": "gpt-4o", "tool_choice": 42}""");

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$.tool_choice");
    }

    // T026: CreateResponsePayloadValidator rejects "tool_choice": null (not nullable)
    [Test]
    public void CreateResponse_ToolChoiceNull_ReturnsError()
    {
        // tool_choice is not marked nullable in the OpenAPI spec — null is invalid
        var result = ValidateCreateResponse("""{"model": "gpt-4o", "tool_choice": null}""");

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$.tool_choice");
    }

    // T027: CreateResponsePayloadValidator accepts "conversation": "conv_abc123" (string)
    [Test]
    public void CreateResponse_ConversationString_IsValid()
    {
        var result = ValidateCreateResponse("""{"model": "gpt-4o", "conversation": "conv_abc123"}""");

        Assert.That(result.IsValid, Is.True);
    }

    // T028: CreateResponsePayloadValidator accepts "conversation": {"id": "conv_abc123"} (object)
    [Test]
    public void CreateResponse_ConversationObject_IsValid()
    {
        var result = ValidateCreateResponse("""{"model": "gpt-4o", "conversation": {"id": "conv_abc123"}}""");

        Assert.That(result.IsValid, Is.True);
    }

    // T029: CreateResponsePayloadValidator rejects "conversation": 42
    [Test]
    public void CreateResponse_Conversation42_ReturnsError()
    {
        var result = ValidateCreateResponse("""{"model": "gpt-4o", "conversation": 42}""");

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$.conversation");
    }

    // T030: ConversationParamValidator rejects array input
    [Test]
    public void ConversationParam_RejectsArray()
    {
        var result = ValidateElement("[]", ConversationParamValidator.Validate);

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$");
    }

    // =======================================================================
    // US3 — Reject Invalid Tool-Specific Polymorphic Properties
    // =======================================================================

    // T033: CodeInterpreterToolValidator accepts "container": "my-id" (string)
    [Test]
    public void CodeInterpreterTool_ContainerString_IsValid()
    {
        var result = ValidateElement(
            """{"type": "code_interpreter", "container": "my-id"}""",
            CodeInterpreterToolValidator.Validate);

        Assert.That(result.IsValid, Is.True);
    }

    // T034: CodeInterpreterToolValidator accepts "container": {"type": "auto"} (object)
    [Test]
    public void CodeInterpreterTool_ContainerObject_IsValid()
    {
        var result = ValidateElement(
            """{"type": "code_interpreter", "container": {"type": "auto"}}""",
            CodeInterpreterToolValidator.Validate);

        Assert.That(result.IsValid, Is.True);
    }

    // T035: CodeInterpreterToolValidator rejects "container": 42
    [Test]
    public void CodeInterpreterTool_Container42_ReturnsError()
    {
        var result = ValidateElement(
            """{"type": "code_interpreter", "container": 42}""",
            CodeInterpreterToolValidator.Validate);

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$.container");
    }

    // T036: MCPToolValidator rejects "allowed_tools": 42
    [Test]
    public void McpTool_AllowedTools42_ReturnsError()
    {
        var result = ValidateElement(
            """{"type": "mcp", "server_label": "test", "server_url": "https://example.com", "allowed_tools": 42}""",
            MCPToolValidator.Validate);

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$.allowed_tools");
    }

    // T037: MCPToolValidator rejects "require_approval": 42
    [Test]
    public void McpTool_RequireApproval42_ReturnsError()
    {
        var result = ValidateElement(
            """{"type": "mcp", "server_label": "test", "server_url": "https://example.com", "require_approval": 42}""",
            MCPToolValidator.Validate);

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$.require_approval");
    }

    // T038: FileSearchToolValidator rejects "filters": 42
    [Test]
    public void FileSearchTool_Filters42_ReturnsError()
    {
        var result = ValidateElement(
            """{"type": "file_search", "vector_store_ids": [], "filters": 42}""",
            FileSearchToolValidator.Validate);

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$.filters");
    }

    // T039: FileSearchToolValidator accepts "filters": null (nullable)
    [Test]
    public void FileSearchTool_FiltersNull_IsValid()
    {
        var result = ValidateElement(
            """{"type": "file_search", "vector_store_ids": [], "filters": null}""",
            FileSearchToolValidator.Validate);

        Assert.That(result.IsValid, Is.True);
    }

    // T040: FiltersValidator rejects string input (expected object)
    [Test]
    public void Filters_RejectsString()
    {
        var result = ValidateElement("\"not-an-object\"", FiltersValidator.Validate);

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$" && e.Message.Contains("object"));
    }

    // =======================================================================
    // US4 — Reject Invalid Tool Call Output Content
    // =======================================================================

    // T041: ToolCallOutputContentValidator accepts string
    [Test]
    public void ToolCallOutputContent_AcceptsString()
    {
        var result = ValidateElement("\"hello\"", ToolCallOutputContentValidator.Validate);

        Assert.That(result.IsValid, Is.True);
    }

    // T042: ToolCallOutputContentValidator accepts object
    [Test]
    public void ToolCallOutputContent_AcceptsObject()
    {
        var result = ValidateElement("{}", ToolCallOutputContentValidator.Validate);

        Assert.That(result.IsValid, Is.True);
    }

    // T043: ToolCallOutputContentValidator accepts array
    [Test]
    public void ToolCallOutputContent_AcceptsArray()
    {
        var result = ValidateElement("[]", ToolCallOutputContentValidator.Validate);

        Assert.That(result.IsValid, Is.True);
    }

    // T044: ToolCallOutputContentValidator rejects boolean
    [Test]
    public void ToolCallOutputContent_RejectsBoolean()
    {
        var result = ValidateElement("true", ToolCallOutputContentValidator.Validate);

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$");
    }

    // T045: ToolCallOutputContentValidator rejects number
    [Test]
    public void ToolCallOutputContent_RejectsNumber()
    {
        var result = ValidateElement("99", ToolCallOutputContentValidator.Validate);

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$");
    }

    // T046: Specific tool call output validator rejects "output": true
    [Test]
    public void FunctionCallOutput_OutputTrue_ReturnsError()
    {
        var result = ValidateElement(
            """{"type": "function_call_output", "call_id": "call_1", "output": true}""",
            FunctionToolCallOutputResourceValidator.Validate);

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$.output");
    }

    // T046b: FunctionToolCallOutputResource output array items are validated
    [Test]
    public void FunctionCallOutput_OutputArrayWithInvalidItem_ReturnsIndexedError()
    {
        // output is string | array<FunctionAndCustomToolCallOutput>
        // An array with an invalid item (number instead of object) should fail
        var result = ValidateElement(
            """{"type": "function_call_output", "call_id": "call_1", "output": [42]}""",
            FunctionToolCallOutputResourceValidator.Validate);

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path.Contains("$.output[0]"));
    }

    // T046c: FunctionToolCallOutputResource output as string still accepted
    [Test]
    public void FunctionCallOutput_OutputString_IsValid()
    {
        var result = ValidateElement(
            """{"type": "function_call_output", "call_id": "call_1", "output": "result text"}""",
            FunctionToolCallOutputResourceValidator.Validate);

        Assert.That(result.IsValid, Is.True);
    }
}
