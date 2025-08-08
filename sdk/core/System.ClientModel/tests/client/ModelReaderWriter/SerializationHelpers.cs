// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;

namespace System.ClientModel.Tests.ModelReaderWriterTests
{
    internal static class SerializationHelpers
    {
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
    }
}
