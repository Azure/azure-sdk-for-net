// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;

namespace System.ClientModel.Primitives;

/// <summary>
/// Extension methods for JsonPatch.
/// </summary>
[Experimental("SCME0001")]
public static class JsonPatchExtensions
{
    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPatch"></param>
    /// <param name="jsonPath"></param>
    /// <param name="value"></param>
    public static void Set<T>(ref this JsonPatch jsonPatch, ReadOnlySpan<byte> jsonPath, T value)
        where T : IJsonModel<T>
    {
        var writer = new ModelWriter<T>(value, ModelReaderWriterOptions.Json);
        using var reader = writer.ExtractReader();
        jsonPatch.Set(jsonPath, reader.ToBinaryData());
    }

    /// <summary>
    /// .
    /// </summary>
    /// <param name="jsonPatch"></param>
    /// <param name="jsonPath"></param>
    /// <param name="value"></param>
    public static void Append<T>(ref this JsonPatch jsonPatch, ReadOnlySpan<byte> jsonPath, T value)
        where T : IJsonModel<T>
    {
        var writer = new ModelWriter<T>(value, ModelReaderWriterOptions.Json);
        using var reader = writer.ExtractReader();
        jsonPatch.Append(jsonPath, reader.ToBinaryData());
    }

    /// <summary>
    /// Serializes the JsonPatch to a JSON string representation in the specified format.
    /// Valid formats include:
    /// "J" for application/json
    /// "JP" for application/json-patch+json
    /// "JMP" for application/json-merge-patch+json
    /// </summary>
    /// <param name="patch">The patch to serialize.</param>
    /// <param name="format">The format to serialize into.</param>
    /// <returns></returns>
    public static string Serialize(this JsonPatch patch, string format = "J")
    {
        using UnsafeBufferSequence buffer = new();
        using Utf8JsonWriter writer = new(buffer);
        patch.WriteTo(writer);
        writer.Flush();
#if NET6_0_OR_GREATER
        return Encoding.UTF8.GetString(buffer.ExtractReader().ToBinaryData().ToMemory().Span);
#else
        return Encoding.UTF8.GetString(buffer.ExtractReader().ToBinaryData().ToArray());
#endif
    }
}
