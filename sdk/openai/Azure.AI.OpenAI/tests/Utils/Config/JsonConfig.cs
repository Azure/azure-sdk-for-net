// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

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
    /// <inheritdoc />
    public string? Key { get; init; }
    /// <inheritdoc />
    public string? Deployment { get; init; }
    /// <inheritdoc />
    public Uri? Endpoint { get; init; }

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
            return value.Deserialize<TVal>();
        }

        return default;
    }
}
