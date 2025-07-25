// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace System.ClientModel.Primitives;

// TODO: do the UTF8 strings need to be unescaped?
internal static partial class JsonPointer
{
    public static ReadOnlyMemory<byte>[]? GetUtf8Array(this ReadOnlySpan<byte> json, ReadOnlySpan<byte> pointer)
    {
        byte[] array = json.ToArray();
        return GetUtf8ArrayCore(array, 0, pointer);
    }
    public static ReadOnlyMemory<byte>[]? GetUtf8Array(this ReadOnlySpan<byte> json)
        => GetUtf8Array(json, default);

    public static ReadOnlyMemory<byte>[]? GetUtf8Array(this ReadOnlyMemory<byte> json, ReadOnlySpan<byte> pointer)
    {
        int index;
        byte[] array;
        if (MemoryMarshal.TryGetArray(json, out var arraySegment))
        {
            array = arraySegment.Array!;
            index = arraySegment.Offset;
        }
        else
        {
            array = json.ToArray();
            index = 0;
        }
        return GetUtf8ArrayCore(array, index, pointer);
    }
    public static ReadOnlyMemory<byte>[]? GetUtf8Array(this ReadOnlyMemory<byte> json)
        => GetUtf8Array(json, default);

    public static ReadOnlyMemory<byte>[]? GetUtf8Array(this BinaryData json, ReadOnlySpan<byte> pointer)
        => GetUtf8Array(json.ToMemory(), pointer);

    public static ReadOnlyMemory<byte>[]? GetUtf8Array(this BinaryData json)
        => GetUtf8Array(json, default);

    private static ReadOnlyMemory<byte>[]? GetUtf8ArrayCore(byte[] jsonArray, int index, ReadOnlySpan<byte> pointer = default)
    {
        ReadOnlySpan<byte> jsonSpan = new(jsonArray, index, jsonArray.Length - index);

        var reader = pointer.IsEmpty ? new Utf8JsonReader(jsonSpan) : jsonSpan.Find(pointer);
        if (pointer.IsEmpty)
            _ = reader.Read();

        int elementCount = GetArrayLength(jsonArray, pointer);
        if (elementCount == 0)
            return Array.Empty<ReadOnlyMemory<byte>>();

        // Rent arrays from pool for offsets and lengths
        int[] offsets = ArrayPool<int>.Shared.Rent(elementCount);
        int[] lengths = ArrayPool<int>.Shared.Rent(elementCount);

        try
        {
            int elementIndex = 0;
            while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
            {
                if (reader.TokenType == JsonTokenType.String)
                {
                    // Use TokenStartIndex + 1 to skip opening quote, ValueSpan.Length for unquoted content
                    offsets[elementIndex] = (int)reader.TokenStartIndex + 1;
                    lengths[elementIndex] = reader.ValueSpan.Length;
                    elementIndex++;
                }
            }

            var result = new ReadOnlyMemory<byte>[elementCount];
            for (int i = 0; i < elementCount; i++)
            {
                int actualOffset = offsets[i] + index;
                result[i] = new ReadOnlyMemory<byte>(jsonArray, actualOffset, lengths[i]);
            }
            return result;
        }
        finally
        {
            ArrayPool<int>.Shared.Return(offsets);
            ArrayPool<int>.Shared.Return(lengths);
        }
    }
}
