// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Generator.Management.Models;

/// <summary> Constraints on the resource name from TypeSpec @pattern, @minLength, @maxLength decorators. </summary>
/// <param name="Pattern"> The regex pattern constraint for the resource name. </param>
/// <param name="MinLength"> The minimum length constraint for the resource name. </param>
/// <param name="MaxLength"> The maximum length constraint for the resource name. </param>
public record ArmResourceNameConstraints(
    string? Pattern,
    int? MinLength,
    int? MaxLength)
{
    internal static ArmResourceNameConstraints DeserializeNameConstraints(JsonElement element)
    {
        string? pattern = null;
        int? minLength = null;
        int? maxLength = null;

        if (element.TryGetProperty("pattern", out var patternElement))
        {
            var raw = patternElement.GetString();
            pattern = string.IsNullOrEmpty(raw) ? null : raw;
        }
        if (element.TryGetProperty("minLength", out var minLengthElement))
        {
            minLength = minLengthElement.GetInt32();
        }
        if (element.TryGetProperty("maxLength", out var maxLengthElement))
        {
            maxLength = maxLengthElement.GetInt32();
        }

        return new(pattern, minLength, maxLength);
    }
}
