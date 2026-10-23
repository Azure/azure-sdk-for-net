// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.AI.AgentServer.Responses.Tests.Validation;

/// <summary>
/// Tests for codegen pipeline correctness.
/// Verifies that generated validators match the API specification.
/// Covers T052–T055.
/// </summary>
public class CodegenPipelineTests
{
    // -----------------------------------------------------------------------
    // T052 — Codegen idempotency
    // -----------------------------------------------------------------------

    [Test]
    public void CreateResponsePayloadValidator_Validate_ReturnsValidationResult()
    {
        // Smoke test: the generated CreateResponsePayloadValidator exists and works
        var json = """{"model":"gpt-4o"}""";
        using var doc = JsonDocument.Parse(json);
        var result = CreateResponsePayloadValidator.Validate(doc.RootElement);

        Assert.That(result.IsValid, Is.True);
    }

    [Test]
    public void CreateResponsePayloadValidator_Validate_ByteOverload_Works()
    {
        var bytes = System.Text.Encoding.UTF8.GetBytes("""{"model":"gpt-4o"}""");
        var result = CreateResponsePayloadValidator.Validate(bytes);

        Assert.That(result.IsValid, Is.True);
    }

    // -----------------------------------------------------------------------
    // T053 — Overlay application: model is optional (PW-006)
    // -----------------------------------------------------------------------

    [Test]
    public void CreateResponsePayloadValidator_MissingModel_IsValid()
    {
        // PW-006: model is now optional — overlay no longer marks it required
        var json = """{"instructions":"hello"}""";
        using var doc = JsonDocument.Parse(json);
        var result = CreateResponsePayloadValidator.Validate(doc.RootElement);

        Assert.That(result.IsValid, Is.True);
    }

    [Test]
    public void CreateResponsePayloadValidator_WithModel_Passes()
    {
        var json = """{"model":"gpt-4o"}""";
        using var doc = JsonDocument.Parse(json);
        var result = CreateResponsePayloadValidator.Validate(doc.RootElement);

        Assert.That(result.IsValid, Is.True);
    }

    // -----------------------------------------------------------------------
    // T054 — Closed enum detection: closed enums reject unknown values
    // -----------------------------------------------------------------------

    [Test]
    public void CreateResponsePayloadValidator_ClosedEnum_Truncation_RejectsUnknown()
    {
        // 'truncation' is a closed enum: ["auto", "disabled"]
        // Unknown values should be rejected
        var json = """{"model":"gpt-4o","truncation":"unknown_value"}""";
        using var doc = JsonDocument.Parse(json);
        var result = CreateResponsePayloadValidator.Validate(doc.RootElement);

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path.Contains("truncation"));
    }

    [Test]
    public void CreateResponsePayloadValidator_ClosedEnum_Truncation_AcceptsValidValue()
    {
        var json = """{"model":"gpt-4o","truncation":"auto"}""";
        using var doc = JsonDocument.Parse(json);
        var result = CreateResponsePayloadValidator.Validate(doc.RootElement);

        Assert.That(result.IsValid, Is.True);
    }

    // -----------------------------------------------------------------------
    // T055 — Extensible enum detection: extensible enums accept any string
    // -----------------------------------------------------------------------

    [Test]
    public void OutputItemValidator_ExtensibleEnum_Type_AcceptsUnknownValue()
    {
        // OutputItem.type is an extensible enum (anyOf pattern)
        // Unknown type values should be accepted (forward compatibility)
        var json = """{"type":"some_future_type","id":"item_1"}""";
        using var doc = JsonDocument.Parse(json);
        var result = OutputItemValidator.Validate(doc.RootElement);

        // Unknown discriminator values should pass (default case returns Success)
        Assert.That(result.IsValid, Is.True);
    }

    [Test]
    public void OutputItemValidator_ExtensibleEnum_Type_AcceptsKnownValue()
    {
        // Known type "function_call" dispatches to the function call validator
        var json = """{"type":"function_call","id":"item_1","call_id":"call_1","name":"get_weather","arguments":"{}","status":"completed"}""";
        using var doc = JsonDocument.Parse(json);
        var result = OutputItemValidator.Validate(doc.RootElement);

        Assert.That(result.IsValid, Is.True);
    }

    [Test]
    public void CreateResponsePayloadValidator_UnknownFields_Accepted()
    {
        // Unknown/additional fields should always be silently accepted
        var json = """{"model":"gpt-4o","some_future_field":"value","nested":{"a":1}}""";
        using var doc = JsonDocument.Parse(json);
        var result = CreateResponsePayloadValidator.Validate(doc.RootElement);

        Assert.That(result.IsValid, Is.True);
    }

    [Test]
    public void ResponseValidator_Exists_And_ValidatesResponse()
    {
        // Verify ResponseValidator exists and can validate a response object
        var json = """{"id":"resp_1","model":"gpt-4o","object":"response","output":[],"status":"completed"}""";
        using var doc = JsonDocument.Parse(json);
        var result = ResponseValidator.Validate(doc.RootElement);

        // Should at least be able to parse it (may have required fields we're missing)
        Assert.That(result, Is.Not.Null);
    }

    // -----------------------------------------------------------------------
    // T056 — Scalar $ref properties keep their number/integer kind check.
    // Properties typed with the OpenAI scalars (OpenAI.numeric, OpenAI.integer) are emitted as
    // a bare $ref with no inline type. If the generator does not resolve it, the kind check is
    // dropped and a non-numeric value passes validation, then fails in the model reader.
    // -----------------------------------------------------------------------

    private static ValidationResult ValidateWith(string validator, string json)
    {
        using var doc = JsonDocument.Parse(json);
        return validator switch
        {
            "LogProb" => LogProbValidator.Validate(doc.RootElement),
            "TopLogProb" => TopLogProbValidator.Validate(doc.RootElement),
            "RealtimeMCPHTTPError" => RealtimeMCPHTTPErrorValidator.Validate(doc.RootElement),
            "RealtimeMCPProtocolError" => RealtimeMCPProtocolErrorValidator.Validate(doc.RootElement),
            "ResponseUsageInputTokensDetails" => ResponseUsageInputTokensDetailsValidator.Validate(doc.RootElement),
            "ResponseUsageOutputTokensDetails" => ResponseUsageOutputTokensDetailsValidator.Validate(doc.RootElement),
            _ => throw new ArgumentException($"Unknown validator '{validator}'.", nameof(validator)),
        };
    }

    [TestCase("LogProb", """{"bytes":[],"logprob":"bad","token":"a","top_logprobs":[]}""", "$.logprob", "Expected number")]
    [TestCase("TopLogProb", """{"bytes":[],"logprob":"bad","token":"a"}""", "$.logprob", "Expected number")]
    [TestCase("RealtimeMCPHTTPError", """{"code":"404","message":"m","type":"http_error"}""", "$.code", "Expected integer")]
    [TestCase("RealtimeMCPProtocolError", """{"code":"-32600","message":"m","type":"protocol_error"}""", "$.code", "Expected integer")]
    [TestCase("ResponseUsageOutputTokensDetails", """{"reasoning_tokens":"many"}""", "$.reasoning_tokens", "Expected integer")]
    [TestCase("ResponseUsageInputTokensDetails", """{"cached_tokens":"many","cache_write_tokens":0}""", "$.cached_tokens", "Expected integer")]
    [TestCase("ResponseUsageInputTokensDetails", """{"cached_tokens":0,"cache_write_tokens":"many"}""", "$.cache_write_tokens", "Expected integer")]
    public void ScalarRefProperty_NonNumericValue_Rejected(string validator, string json, string path, string message)
    {
        var result = ValidateWith(validator, json);

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == path && e.Message.StartsWith(message, StringComparison.Ordinal));
    }

    [TestCase("LogProb", """{"bytes":[],"logprob":-0.5,"token":"a","top_logprobs":[]}""")]
    [TestCase("TopLogProb", """{"bytes":[],"logprob":-0.5,"token":"a"}""")]
    [TestCase("RealtimeMCPHTTPError", """{"code":404,"message":"m","type":"http_error"}""")]
    [TestCase("RealtimeMCPProtocolError", """{"code":-32600,"message":"m","type":"protocol_error"}""")]
    [TestCase("ResponseUsageOutputTokensDetails", """{"reasoning_tokens":12}""")]
    [TestCase("ResponseUsageInputTokensDetails", """{"cached_tokens":3,"cache_write_tokens":0}""")]
    public void ScalarRefProperty_NumericValue_Accepted(string validator, string json)
    {
        var result = ValidateWith(validator, json);

        Assert.That(result.IsValid, Is.True);
    }

    [Test]
    public void CreateResponsePayloadValidator_InputOutputTextNonNumericLogprob_Rejected()
    {
        // The request path reaches LogProbValidator/TopLogProbValidator through input items.
        var json = """
        {
            "model": "gpt-4o",
            "input": [
                {
                    "type": "message",
                    "role": "assistant",
                    "content": [
                        {
                            "type": "output_text",
                            "text": "hi",
                            "annotations": [],
                            "logprobs": [
                                {
                                    "token": "a",
                                    "bytes": [],
                                    "logprob": "bad",
                                    "top_logprobs": [ { "token": "a", "bytes": [], "logprob": "bad" } ]
                                }
                            ]
                        }
                    ]
                }
            ]
        }
        """;
        using var doc = JsonDocument.Parse(json);
        var result = CreateResponsePayloadValidator.Validate(doc.RootElement);

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$.input[0].content[0].logprobs[0].logprob");
        XAssert.Contains(result.Errors, e => e.Path == "$.input[0].content[0].logprobs[0].top_logprobs[0].logprob");
    }

    [Test]
    public void CreateResponsePayloadValidator_InputOutputTextNumericLogprob_Accepted()
    {
        var json = """
        {
            "model": "gpt-4o",
            "input": [
                {
                    "type": "message",
                    "role": "assistant",
                    "content": [
                        {
                            "type": "output_text",
                            "text": "hi",
                            "annotations": [],
                            "logprobs": [
                                {
                                    "token": "a",
                                    "bytes": [],
                                    "logprob": -0.25,
                                    "top_logprobs": [ { "token": "a", "bytes": [], "logprob": -0.25 } ]
                                }
                            ]
                        }
                    ]
                }
            ]
        }
        """;
        using var doc = JsonDocument.Parse(json);
        var result = CreateResponsePayloadValidator.Validate(doc.RootElement);

        Assert.That(result.IsValid, Is.True);
    }

    [Test]
    public void CreateResponsePayloadValidator_InputMcpListToolsNonNumericErrorCode_Rejected()
    {
        // The request path reaches RealtimeMCPHTTPErrorValidator through an mcp_list_tools input item.
        var json = """
        {
            "model": "gpt-4o",
            "input": [
                {
                    "type": "mcp_list_tools",
                    "server_label": "s",
                    "tools": [],
                    "error": { "type": "http_error", "code": "404", "message": "m" }
                }
            ]
        }
        """;
        using var doc = JsonDocument.Parse(json);
        var result = CreateResponsePayloadValidator.Validate(doc.RootElement);

        Assert.That(result.IsValid, Is.False);
        XAssert.Contains(result.Errors, e => e.Path == "$.input[0].error.code");
    }
}
