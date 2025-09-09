// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers.Text;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    internal static class SerializationHelpers
    {
#if NET8_0_OR_GREATER
        private static readonly int s_maxPropertyNameLength = 256;
#endif

        public static ReadOnlySpan<byte> SliceToStartOfPropertyName(this ReadOnlySpan<byte> jsonPath)
        {
            ReadOnlySpan<byte> local = jsonPath;
            if (local.IsEmpty)
                return ReadOnlySpan<byte>.Empty;

            if (local[0] != (byte)'$')
                return ReadOnlySpan<byte>.Empty;

            if (local.Length < 3)
                return ReadOnlySpan<byte>.Empty;

            if (local[1] == (byte)'.')
            {
                local = local.Slice(2);
            }
            else
            {
                if (local[1] != (byte)'[' || local.Length < 4 || (local[2] != (byte)'\'' && local[2] != (byte)'\"'))
                    return ReadOnlySpan<byte>.Empty;
                local = local.Slice(3);
            }
            return local;
        }

        public static string GetFirstPropertyName(this ReadOnlySpan<byte> jsonPath, out int bytesConsumed)
        {
            ReadOnlySpan<byte> local = SliceToStartOfPropertyName(jsonPath);

            for (bytesConsumed = 0; bytesConsumed < local.Length; bytesConsumed++)
            {
                byte current = local[bytesConsumed];
                if (current == (byte)'.')
                {
                    break;
                }
                else if (current == (byte)'\'' || current == (byte)'"')
                {
                    if (bytesConsumed + 1 < local.Length && local[bytesConsumed + 1] == ']')
                    {
                        break;
                    }
                }
            }

#if NET6_0_OR_GREATER
            string key = Encoding.UTF8.GetString(local.Slice(0, bytesConsumed));
#else
            string key = Encoding.UTF8.GetString(local.Slice(0, bytesConsumed).ToArray());
#endif

            bytesConsumed += jsonPath.Length - local.Length;
            return key;
        }

        [Experimental("SCM0001")]
        public static void WriteDictionaryWithPatch<T>(
            this Utf8JsonWriter writer,
            ModelReaderWriterOptions options,
            ref JsonPatch patch,
            ReadOnlySpan<byte> propertyName,
            ReadOnlySpan<byte> prefix,
            IDictionary<string, T> dictionary,
            Action<Utf8JsonWriter, T, ModelReaderWriterOptions> write,
            Func<T, JsonPatch>? getPatchFromItem)
        {
            if (!propertyName.IsEmpty)
                writer.WritePropertyName(propertyName);

            writer.WriteStartObject();
#if NET8_0_OR_GREATER
            Span<byte> buffer = stackalloc byte[s_maxPropertyNameLength];
#endif
            foreach (var item in dictionary)
            {
                if (getPatchFromItem is not null && getPatchFromItem(item.Value).TryGetJson("$"u8, out ReadOnlyMemory<byte> patchedJson))
                {
                    if (!patchedJson.IsEmpty)
                    {
                        writer.WritePropertyName(item.Key);
                        writer.WriteRawValue(patchedJson.Span);
                    }
                    continue;
                }

#if NET8_0_OR_GREATER
                int bytesWritten = Encoding.UTF8.GetBytes(item.Key.AsSpan(), buffer);
                bool patchContains = bytesWritten == s_maxPropertyNameLength
                    ? patch.Contains(prefix, Encoding.UTF8.GetBytes(item.Key))
                    : patch.Contains(prefix, buffer.Slice(0, bytesWritten));
#else
                bool patchContains = patch.Contains(prefix, Encoding.UTF8.GetBytes(item.Key));
#endif
                if (!patchContains)
                {
                    writer.WritePropertyName(item.Key);
                    write(writer, item.Value, options);
                }
            }

            patch.WriteTo(writer, prefix);
            writer.WriteEndObject();
        }

        public static bool TryGetIndex(ReadOnlySpan<byte> indexSlice, out int index, out int bytesConsumed)
        {
            index = -1;
            bytesConsumed = 0;

            if (indexSlice.IsEmpty || indexSlice[0] != (byte)'[')
                return false;

            indexSlice = indexSlice.Slice(1);
            if (indexSlice.IsEmpty || indexSlice[0] == (byte)'-')
                return false;

            int indexEnd = indexSlice.Slice(1).IndexOf((byte)']');
            if (indexEnd < 0)
                return false;

            return Utf8Parser.TryParse(indexSlice.Slice(0, indexEnd + 1), out index, out bytesConsumed);
        }
    }
}
