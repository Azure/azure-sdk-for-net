// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.AI.OpenAI;

internal static partial class JsonPatchHelpers
{
    public static BinaryData? GetBytesOrDefaultEx(this JsonPatch patch, ReadOnlySpan<byte> path)
    {
        if (patch.Contains(path)
            && !patch.IsRemoved(path)
            && patch.TryGetJson(path, out ReadOnlyMemory<byte> bytes)
            && !bytes.IsEmpty)
        {
            return BinaryData.FromBytes(bytes);
        }
        return null;
    }

    public static T? GetDeserializedInstance<T>(this JsonPatch patch, ReadOnlySpan<byte> path, Func<JsonElement, ModelReaderWriterOptions, T> deserializationFunc)
        where T : IJsonModel<T>
    {
        if (patch.GetBytesOrDefaultEx(path) is BinaryData valueBytes)
        {
            using JsonDocument document = JsonDocument.Parse(valueBytes);
            return deserializationFunc.Invoke(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
        return default;
    }

    public static IReadOnlyList<T> GetDeserializedInstanceList<T>(this JsonPatch patch, ReadOnlySpan<byte> path, Func<JsonElement, ModelReaderWriterOptions, T> deserializationFunc)
        where T : IJsonModel<T>
    {
        List<T> instances = [];
        if (patch.GetBytesOrDefaultEx(path) is BinaryData valueBytes)
        {
            using JsonDocument document = JsonDocument.Parse(valueBytes);
            if (document.RootElement.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement element in document.RootElement.EnumerateArray())
                {
                    instances.Add(
                        deserializationFunc.Invoke(
                            element,
                            ModelSerializationExtensions.WireOptions));
                }
            }
        }
        return instances;
    }
}
