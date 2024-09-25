// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.AI.OpenAI.Tests.Utils.Config;

/// <summary>
/// A configuration that is deserialized from JSON.
/// </summary>
public class JsonConfig : IConfiguration
{
    /// <summary>
    /// The default configuration key to use.
    /// </summary>
    public const string DEFAULT_CONFIG_NAME = "default";

    /// <summary>
    /// The JSON configuration to use when serializing and deserializing.
    /// </summary>
    public static readonly JsonSerializerOptions JSON_OPTIONS = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonOptions.SnakeCaseLower,
        DictionaryKeyPolicy = JsonOptions.SnakeCaseLower,
        WriteIndented = true,
        AllowTrailingCommas = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    };

    /// <inheritdoc />
    public Uri? Endpoint { get; init; }
    /// <inheritdoc />
    public string? Key { get; init; }
    /// <inheritdoc />
    public string? Deployment { get; init; }

    /// <summary>
    /// Json values that are not part of the class go here.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? ExtensionData { get; set; }

    /// <inheritdoc />
    public TVal? GetValue<TVal>(string key)
    {
        if (ExtensionData?.TryGetValue(key, out JsonElement value) == true)
        {
            return value.Deserialize<TVal>(JSON_OPTIONS);
        }

        return default;
    }
}
