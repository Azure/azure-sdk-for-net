// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel.Primitives;

#pragma warning disable SCME0001

namespace Azure.AI.Projects.OpenAI;

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
        readerContext ??= AzureAIProjectsOpenAIContext.Default;
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
            patch.Set(jsonPath, value);
        }
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
            writerContext ??= AzureAIProjectsOpenAIContext.Default;
            patch.Set(jsonPath, ModelReaderWriter.Write(value, ModelSerializationExtensions.WireOptions, writerContext));
        }
    }
}
