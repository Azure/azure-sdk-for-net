// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Nodes;

namespace Azure.AI.AgentServer.Responses.Validators;

/// <summary>
/// Validation entry point for create response payloads.
/// </summary>
internal static class CreateResponsePayloadValidator
{
    private const string MalformedIdMessage = "Malformed identifier.";

    /// <summary> Validates a UTF-8 JSON payload. </summary>
    /// <param name="utf8Json">The UTF-8 JSON payload.</param>
    /// <returns>The validation result.</returns>
    public static ValidationResult Validate(ReadOnlySpan<byte> utf8Json)
    {
        try
        {
            using JsonDocument document = JsonDocument.Parse(utf8Json.ToArray());
            return Validate(document.RootElement);
        }
        catch (JsonException ex)
        {
            return ValidationResult.Failure([new ValidationError("$", ex.Message)]);
        }
    }

    /// <summary> Validates a JSON payload. </summary>
    /// <param name="element">The JSON payload.</param>
    /// <returns>The validation result.</returns>
    public static ValidationResult Validate(JsonElement element)
    {
        var errors = new List<ValidationError>();
        if (element.ValueKind != JsonValueKind.Object)
        {
            errors.Add(new ValidationError("$", $"Expected object, got {element.ValueKind}"));
            return ValidationResult.Failure(errors);
        }

        ValidateKnownFields(element, errors);
        ValidatePreviousResponseId(element, errors);
        return errors.Count == 0 ? ValidationResult.Success : ValidationResult.Failure(errors);
    }

    private static void ValidateKnownFields(JsonElement element, List<ValidationError> errors)
    {
        ValidateStringField(element, "model", errors);
        ValidateNumberField(element, "temperature", errors);
        ValidateNumberField(element, "top_p", errors);
        ValidateIntegerField(element, "max_output_tokens", errors);
        ValidateBooleanField(element, "parallel_tool_calls", errors);
        ValidateBooleanField(element, "stream", errors);
        ValidateBooleanField(element, "store", errors);
        ValidateBooleanField(element, "background", errors);
        ValidateInstructions(element, errors);
        ValidateTruncation(element, errors);
        ValidateTools(element, errors);

        if (element.TryGetProperty("metadata", out JsonElement metadata))
        {
            AddNestedErrors("$.metadata", MetadataValidator.Validate(metadata), errors);
        }

        if (element.TryGetProperty("input", out JsonElement input))
        {
            ValidateInput(input, "$.input", errors);
        }

        if (element.TryGetProperty("tool_choice", out JsonElement toolChoice))
        {
            ValidateToolChoice(toolChoice, "$.tool_choice", errors);
        }

        if (element.TryGetProperty("conversation", out JsonElement conversation))
        {
            ValidateConversation(conversation, "$.conversation", errors);
        }
    }

    private static void ValidateStringField(JsonElement element, string propertyName, List<ValidationError> errors)
    {
        if (element.TryGetProperty(propertyName, out JsonElement property)
            && property.ValueKind != JsonValueKind.String
            && property.ValueKind != JsonValueKind.Null)
        {
            errors.Add(new ValidationError($"$.{propertyName}", $"Expected string, got {property.ValueKind}"));
        }
    }

    private static void ValidateNumberField(JsonElement element, string propertyName, List<ValidationError> errors)
    {
        if (element.TryGetProperty(propertyName, out JsonElement property)
            && property.ValueKind != JsonValueKind.Number
            && property.ValueKind != JsonValueKind.Null)
        {
            errors.Add(new ValidationError($"$.{propertyName}", $"Expected number, got {property.ValueKind}"));
        }
    }

    private static void ValidateIntegerField(JsonElement element, string propertyName, List<ValidationError> errors)
    {
        if (!element.TryGetProperty(propertyName, out JsonElement property)
            || property.ValueKind == JsonValueKind.Null)
        {
            return;
        }

        if (property.ValueKind != JsonValueKind.Number || !property.TryGetInt64(out _))
        {
            errors.Add(new ValidationError($"$.{propertyName}", $"Expected integer, got {property.ValueKind}"));
        }
    }

    private static void ValidateBooleanField(JsonElement element, string propertyName, List<ValidationError> errors)
    {
        if (element.TryGetProperty(propertyName, out JsonElement property)
            && property.ValueKind is not (JsonValueKind.True or JsonValueKind.False or JsonValueKind.Null))
        {
            errors.Add(new ValidationError($"$.{propertyName}", $"Expected boolean, got {property.ValueKind}"));
        }
    }

    private static void ValidateInstructions(JsonElement element, List<ValidationError> errors)
    {
        if (element.TryGetProperty("instructions", out JsonElement instructions)
            && instructions.ValueKind is not (JsonValueKind.String or JsonValueKind.Array or JsonValueKind.Null))
        {
            errors.Add(new ValidationError("$.instructions", $"Expected string or array, got {instructions.ValueKind}"));
        }
    }

    private static void ValidateTruncation(JsonElement element, List<ValidationError> errors)
    {
        if (!element.TryGetProperty("truncation", out JsonElement truncation)
            || truncation.ValueKind == JsonValueKind.Null)
        {
            return;
        }

        if (truncation.ValueKind != JsonValueKind.String)
        {
            errors.Add(new ValidationError("$.truncation", $"Expected string, got {truncation.ValueKind}"));
            return;
        }

        if (truncation.GetString() is not ("auto" or "disabled"))
        {
            errors.Add(new ValidationError("$.truncation", "Expected 'auto' or 'disabled'."));
        }
    }

    private static void ValidateTools(JsonElement element, List<ValidationError> errors)
    {
        if (!element.TryGetProperty("tools", out JsonElement tools)
            || tools.ValueKind == JsonValueKind.Null)
        {
            return;
        }

        if (tools.ValueKind != JsonValueKind.Array)
        {
            errors.Add(new ValidationError("$.tools", $"Expected array, got {tools.ValueKind}"));
            return;
        }

        var index = 0;
        foreach (JsonElement tool in tools.EnumerateArray())
        {
            if (tool.ValueKind != JsonValueKind.Object)
            {
                errors.Add(new ValidationError($"$.tools[{index}]", $"Expected object, got {tool.ValueKind}"));
            }
            else if (!tool.TryGetProperty("type", out JsonElement type) || type.ValueKind != JsonValueKind.String)
            {
                errors.Add(new ValidationError($"$.tools[{index}].type", "Required discriminator 'type' is missing or not a string"));
            }

            index++;
        }
    }

    private static void ValidateInput(JsonElement input, string path, List<ValidationError> errors)
    {
        switch (input.ValueKind)
        {
            case JsonValueKind.String:
                return;

            case JsonValueKind.Array:
                var index = 0;
                foreach (JsonElement item in input.EnumerateArray())
                {
                    ValidateInputItem(item, $"{path}[{index}]", errors);
                    index++;
                }
                return;

            default:
                errors.Add(new ValidationError(path, $"Expected string or array, got {input.ValueKind}"));
                return;
        }
    }

    private static void ValidateInputItem(JsonElement item, string path, List<ValidationError> errors)
    {
        if (item.ValueKind != JsonValueKind.Object)
        {
            errors.Add(new ValidationError(path, $"Expected object, got {item.ValueKind}"));
            return;
        }

        if (IsMessageItem(item)
            && item.TryGetProperty("content", out JsonElement content)
            && content.ValueKind is not (JsonValueKind.String or JsonValueKind.Array))
        {
            errors.Add(new ValidationError($"{path}.content", $"Expected string or array, got {content.ValueKind}"));
            return;
        }

        AddNestedErrors(path, ItemValidator.Validate(NormalizeInputItem(item)), errors);
    }

    private static bool IsMessageItem(JsonElement item)
    {
        if (item.TryGetProperty("type", out JsonElement type)
            && type.ValueKind == JsonValueKind.String)
        {
            return type.GetString() == "message";
        }

        return item.TryGetProperty("role", out _);
    }

    private static JsonElement NormalizeInputItem(JsonElement item)
    {
        JsonObject normalized = JsonNode.Parse(item.GetRawText())!.AsObject();
        if (!normalized.TryGetPropertyValue("type", out JsonNode? typeNode) && normalized.ContainsKey("role"))
        {
            normalized["type"] = "message";
            typeNode = JsonValue.Create("message");
        }

        if (typeNode is JsonValue typeValue
            && typeValue.TryGetValue<string>(out string? type)
            && type == "message"
            && normalized.TryGetPropertyValue("content", out JsonNode? contentNode))
        {
            normalized["content"] = NormalizeMessageContent(contentNode);
        }

        return JsonDocument.Parse(normalized.ToJsonString()).RootElement.Clone();
    }

    private static JsonNode? NormalizeMessageContent(JsonNode? contentNode)
    {
        if (contentNode is JsonValue contentValue
            && contentValue.TryGetValue<string>(out string? contentString))
        {
            return new JsonArray(new JsonObject
            {
                ["type"] = "input_text",
                ["text"] = contentString,
            });
        }

        if (contentNode is JsonArray contentArray)
        {
            var normalized = new JsonArray();
            foreach (JsonNode? partNode in contentArray)
            {
                if (partNode is JsonObject partObject
                    && partObject.TryGetPropertyValue("type", out JsonNode? typeNode)
                    && typeNode is JsonValue typeValue
                    && typeValue.TryGetValue<string>(out string? type)
                    && type == "input_image"
                    && !partObject.ContainsKey("detail"))
                {
                    JsonObject clone = (JsonObject)partObject.DeepClone();
                    clone["detail"] = "auto";
                    normalized.Add(clone);
                }
                else
                {
                    normalized.Add(partNode?.DeepClone());
                }
            }

            return normalized;
        }

        return contentNode?.DeepClone();
    }

    private static void ValidateToolChoice(JsonElement toolChoice, string path, List<ValidationError> errors)
    {
        switch (toolChoice.ValueKind)
        {
            case JsonValueKind.String:
                var value = toolChoice.GetString();
                if (value is not ("auto" or "required" or "none"))
                {
                    errors.Add(new ValidationError(path, "Expected 'auto', 'required', 'none', or a tool choice object."));
                }
                return;

            case JsonValueKind.Object:
                AddNestedErrors(path, ToolChoiceParamValidator.Validate(toolChoice), errors);
                return;

            default:
                errors.Add(new ValidationError(path, $"Expected string or object, got {toolChoice.ValueKind}"));
                return;
        }
    }

    private static void ValidateConversation(JsonElement conversation, string path, List<ValidationError> errors)
    {
        switch (conversation.ValueKind)
        {
            case JsonValueKind.String:
            case JsonValueKind.Null:
                return;

            case JsonValueKind.Object:
                if (conversation.TryGetProperty("id", out JsonElement id)
                    && id.ValueKind != JsonValueKind.String
                    && id.ValueKind != JsonValueKind.Null)
                {
                    errors.Add(new ValidationError($"{path}.id", $"Expected string, got {id.ValueKind}"));
                }
                return;

            default:
                errors.Add(new ValidationError(path, $"Expected string or object, got {conversation.ValueKind}"));
                return;
        }
    }

    private static void AddNestedErrors(string prefix, ValidationResult result, List<ValidationError> errors)
    {
        if (result.IsValid)
        {
            return;
        }

        foreach (ValidationError error in result.Errors)
        {
            errors.Add(new ValidationError(CombinePath(prefix, error.Path), error.Message));
        }
    }

    private static string CombinePath(string prefix, string path)
    {
        if (path == "$")
        {
            return prefix;
        }

        return path.StartsWith("$.", StringComparison.Ordinal)
            ? prefix + path[1..]
            : prefix + path.TrimStart('$');
    }

    private static void ValidatePreviousResponseId(JsonElement element, List<ValidationError> errors)
    {
        if (element.ValueKind == JsonValueKind.Object
            && element.TryGetProperty("previous_response_id", out JsonElement previousResponseId)
            && previousResponseId.ValueKind == JsonValueKind.String)
        {
            string value = previousResponseId.GetString()!;
            if (!IdGenerator.IsValid(value, out _, allowedPrefixes: ["caresp"]))
            {
                errors.Add(new ValidationError("$.previous_response_id", MalformedIdMessage));
            }
        }
    }
}
