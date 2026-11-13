// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.AI.AgentServer.Responses.Validators;

/// <summary>
/// Custom metadata constraint validation: max 16 pairs, keys max 64 chars, values max 512 chars.
/// </summary>
internal static partial class MetadataValidator
{
    private const int MaxPairs = 16;
    private const int MaxKeyLength = 64;
    private const int MaxValueLength = 512;

    static partial void ValidateCustom(JsonElement element, List<ValidationError> errors)
    {
        if (element.ValueKind != JsonValueKind.Object)
            return;

        var count = 0;
        foreach (var kvp in element.EnumerateObject())
        {
            count++;

            if (kvp.Name.Length > MaxKeyLength)
            {
                errors.Add(new ValidationError(
                    $"$.{kvp.Name}",
                    $"Metadata key must not exceed {MaxKeyLength} characters (got {kvp.Name.Length})."));
            }

            if (kvp.Value.ValueKind == JsonValueKind.String)
            {
                var valueLength = kvp.Value.GetString()!.Length;
                if (valueLength > MaxValueLength)
                {
                    errors.Add(new ValidationError(
                        $"$.{kvp.Name}",
                        $"Metadata value must not exceed {MaxValueLength} characters (got {valueLength})."));
                }
            }
        }

        if (count > MaxPairs)
        {
            errors.Add(new ValidationError(
                "$",
                $"Metadata cannot contain more than {MaxPairs} key-value pairs (got {count})."));
        }
    }
}
