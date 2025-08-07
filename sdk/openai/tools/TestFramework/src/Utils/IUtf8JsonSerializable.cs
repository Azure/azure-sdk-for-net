// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace OpenAI.TestFramework.Utils;

/// <summary>
/// Interface applied to types that can be serialized to JSON.
/// </summary>
public interface IUtf8JsonSerializable
{
    /// <summary>
    /// Writes this instance as JSON to the writer.
    /// </summary>
    /// <param name="writer">The writer to write to.</param>
    /// <param name="options">The options to use when writing.</param>
    void Write(Utf8JsonWriter writer, JsonSerializerOptions? options = null);
}
