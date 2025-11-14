// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Internal;
using System.Diagnostics.CodeAnalysis;

namespace System.ClientModel.Tests.ModelReaderWriterTests;

/// <summary>
/// Extension methods for JsonPatch.
/// </summary>
[Experimental("SCME0001")]
public static class JsonPatchExtensions
{
    /// <summary>
    /// Sets the value at the specified JSON path in the JsonPatch object.
    /// </summary>
    /// <param name="jsonPatch">The JsonPatch to set on.</param>
    /// <param name="jsonPath">The JSON path to set.</param>
    /// <param name="value">The <see cref="IJsonModel{T}"/> to write into the <paramref name="jsonPath"/>.</param>
    public static void Set<T>(ref this JsonPatch jsonPatch, ReadOnlySpan<byte> jsonPath, T value)
        where T : IJsonModel<T>
    {
        var writer = new ModelWriter<T>(value, ModelReaderWriterOptions.Json);
        using var reader = writer.ExtractReader();
        jsonPatch.Set(jsonPath, reader.ToBinaryData());
    }

    /// <summary>
    /// Appends the value to an array at the specified JSON path in the JsonPatch object.
    /// </summary>
    /// <param name="jsonPatch">The JsonPatch to set on.</param>
    /// <param name="jsonPath">The JSON path to set.</param>
    /// <param name="value">The <see cref="IJsonModel{T}"/> to write into the <paramref name="jsonPath"/>.</param>
    public static void Append<T>(ref this JsonPatch jsonPatch, ReadOnlySpan<byte> jsonPath, T value)
        where T : IJsonModel<T>
    {
        var writer = new ModelWriter<T>(value, ModelReaderWriterOptions.Json);
        using var reader = writer.ExtractReader();
        jsonPatch.Append(jsonPath, reader.ToBinaryData());
    }
}
