// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.Messaging.EventHubs.Primitives
{
    internal static class EncodingExtensions
    {
        public static unsafe int GetBytes(this Encoding encoding, 
                                           ReadOnlySpan<char> src, 
                                           Span<byte> dest)
        {
            if (src.Length == 0)
            {
                return 0;
            }

            if (dest.Length == 0)
            {
                return 0;
            }

            fixed (char* charPointer = src)
            {
                fixed (byte* bytePointer = dest)
                {
                    return encoding.GetBytes(
                        chars: charPointer,
                        charCount: src.Length,
                        bytes: bytePointer,
                        byteCount: dest.Length);
                }
            }
        }

        public static unsafe int GetByteCount(this Encoding encoding, 
                                              ReadOnlySpan<char> src)
        {
            if (src.IsEmpty)
            {
                return 0;
            }

            fixed (char* charPointer = src)
            {
                return encoding.GetByteCount(chars: charPointer, count: src.Length);
            }
        }
    }
}
