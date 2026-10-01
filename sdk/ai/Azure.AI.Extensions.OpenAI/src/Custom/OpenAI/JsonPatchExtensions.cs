// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;

#pragma warning disable SCME0001

namespace Azure.AI.Extensions.OpenAI;

internal static partial class JsonPatchExtensions
{
    public static string? GetStringEx(this ref JsonPatch patch, ReadOnlySpan<byte> jsonPath)
        => patch.IsRemoved(jsonPath)
            || !patch.TryGetJson(jsonPath, out ReadOnlyMemory<byte> jsonBytes)
            || jsonBytes.IsEmpty
                ? null
                : patch.GetString(jsonPath);

    public static T? GetJsonModelEx<T>(this ref JsonPatch patch, ReadOnlySpan<byte> jsonPath, ModelReaderWriterContext? readerContext = null)
        where T : class, IJsonModel<T>
    {
        if (patch.IsRemoved(jsonPath) || !patch.TryGetJson(jsonPath, out ReadOnlyMemory<byte> jsonBytes) || jsonBytes.IsEmpty)
        {
            return null;
        }
        readerContext ??= AzureAIExtensionsOpenAIContext.Default;
        return ModelReaderWriter.Read<T>(BinaryData.FromBytes(jsonBytes), ModelSerializationExtensions.WireOptions, readerContext);
    }

    public static void SetOrClearEx(this ref JsonPatch patch, ReadOnlySpan<byte> jsonPath, ReadOnlySpan<byte> jsonRemovalPath, string? value)
    {
        if (value is null)
        {
            patch.Remove(jsonRemovalPath);
        }
        else
        {
            // Use encoded JSON so replacing an existing nested string patch keeps
            // its quotes and escaping, rather than treating the value as raw JSON.
            patch.Set(jsonPath, SerializeJsonString(value));
        }
    }

    internal static BinaryData SerializeJsonString(string value)
    {
        using MemoryStream stream = new();
        using (Utf8JsonWriter writer = new(stream))
        {
            writer.WriteStringValue(value);
        }
        return BinaryData.FromBytes(stream.ToArray());
    }

    public static void SetOrClearEx<T>(
        this ref JsonPatch patch,
        ReadOnlySpan<byte> jsonPath,
        ReadOnlySpan<byte> jsonRemovalPath,
        T? value,
        ModelReaderWriterContext? writerContext = null)
            where T : IJsonModel<T>
    {
        if (value is null)
        {
            patch.Remove(jsonRemovalPath);
        }
        else
        {
            writerContext ??= AzureAIExtensionsOpenAIContext.Default;
            patch.Set(jsonPath, ModelReaderWriter.Write(value, ModelSerializationExtensions.WireOptions, writerContext));
        }
    }
}
