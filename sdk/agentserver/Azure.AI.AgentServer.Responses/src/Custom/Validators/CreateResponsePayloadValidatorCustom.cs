// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.AI.AgentServer.Responses.Validators;

/// <summary>
/// Custom validation rules for <see cref="CreateResponsePayloadValidator"/>.
/// Adds ID format validation for body fields (<c>previous_response_id</c>)
/// as part of B29 payload validation.
/// </summary>
internal static partial class CreateResponsePayloadValidator
{
    private const string MalformedIdMessage = "Malformed identifier.";

    static partial void ValidateCustom(JsonElement element, List<ValidationError> errors)
    {
        // Validate previous_response_id format (if it's a string).
        // Deliberately validates prefix and length only — character-set validation is not
        // required. IDs with valid prefix/length but unexpected characters will return 404
        // from the provider, which is an acceptable outcome.
        if (element.TryGetProperty("previous_response_id", out var prevIdProp)
            && prevIdProp.ValueKind == JsonValueKind.String)
        {
            var value = prevIdProp.GetString()!;
            if (!IdGenerator.IsValid(value, out _, allowedPrefixes: ["caresp"]))
            {
                errors.Add(new ValidationError("$.previous_response_id", MalformedIdMessage));
            }
        }
    }
}
