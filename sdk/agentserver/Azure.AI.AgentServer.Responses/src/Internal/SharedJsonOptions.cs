// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Provides a shared, thread-safe <see cref="JsonSerializerOptions"/> instance
/// configured for the Responses API wire format (snake_case, null handling,
/// TypeSpec model converters).
/// </summary>
internal static class SharedJsonOptions
{
    /// <summary>
    /// Shared <see cref="JsonSerializerOptions"/> with snake_case naming, null handling,
    /// <see cref="TypeSpecModelConverterFactory"/>, and <see cref="BinaryDataConverter"/>.
    /// Thread-safe — immutable after static initialization.
    /// </summary>
    public static JsonSerializerOptions Instance { get; } = CreateOptions();

    private static JsonSerializerOptions CreateOptions()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        };
        options.Converters.Add(new TypeSpecModelConverterFactory());
        options.Converters.Add(new BinaryDataConverter());
        return options;
    }
}
