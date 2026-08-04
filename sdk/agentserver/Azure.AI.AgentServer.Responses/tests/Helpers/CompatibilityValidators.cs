// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Validators;

namespace Azure.AI.AgentServer.Responses.Tests.Helpers;

internal static class InputParamValidator
{
    public static ValidationResult Validate(JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.String)
        {
            return ValidationResult.Success;
        }

        if (element.ValueKind != JsonValueKind.Array)
        {
            return ValidationResult.Failure(new[] { new ValidationError("$", "Expected string or array.") });
        }

        var errors = new List<ValidationError>();
        var index = 0;
        foreach (JsonElement item in element.EnumerateArray())
        {
            if (item.ValueKind != JsonValueKind.Object)
            {
                errors.Add(new ValidationError($"$[{index}]", $"Expected object, got {item.ValueKind}"));
            }
            else
            {
                ValidationResult result = ItemValidator.Validate(item);
                foreach (ValidationError error in result.Errors)
                {
                    errors.Add(new ValidationError($"$[{index}]" + (error.Path == "$" ? string.Empty : error.Path[1..]), error.Message));
                }
            }

            index++;
        }

        return errors.Count == 0 ? ValidationResult.Success : ValidationResult.Failure(errors);
    }
}

internal static class ConversationParamValidator
{
    public static ValidationResult Validate(JsonElement element)
        => element.ValueKind is JsonValueKind.String or JsonValueKind.Object or JsonValueKind.Null
            ? ValidationResult.Success
            : ValidationResult.Failure(new[] { new ValidationError("$", "Expected string or object.") });
}
