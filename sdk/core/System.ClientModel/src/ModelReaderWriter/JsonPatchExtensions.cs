// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Diagnostics.CodeAnalysis;

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
}
