// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.Messaging.EventHubs.Core
{
    /// <summary>
    ///   Encoding extensions used to provide a compatibility shim for encoding methods that are missing in .NET Standard 2.0.
    /// </summary>
    ///
    internal static class EncodingExtensions
    {
        /// <summary>
        ///   Encodes into a span of bytes a set of characters from the specified read-only span.
        /// </summary>
        ///
        /// <param name="encoding">The encoding to be used.</param>
        /// <param name="src">The span containing the set of characters to encode.</param>
        /// <param name="dest">The byte span to hold the encoded bytes.</param>
        ///
        /// <returns>The count of encoded bytes.</returns>
        ///
        /// <remarks>
        ///   The method was introduced as a compatibility shim for .NET Standard and can be replaced should the
        ///   SDK change targets to .NET Standard 2.1 or target frameworks that provides those methods out of the box.
        ///   During  reviews it was decided to not multi-target due to the added complexity.
        /// </remarks>
        ///
        /// <seealso href="https://docs.microsoft.com/dotnet/api/system.text.encoding.getbytes?view=netstandard-2.1#system-text-encoding-getbytes(system-readonlyspan((system-char))-system-span((system-byte)))" />
        ///
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

        /// <summary>
        ///   Calculates the number of bytes produced by encoding the characters in the specified character span.
        /// </summary>
        ///
        /// <param name="encoding">The encoding to be used.</param>
        /// <param name="src">The span of characters to encode.</param>
        ///
        /// <returns>The count of bytes produced by encoding the specified character span.</returns>
        ///
        /// <remarks>
        ///   The method was introduced as a compatibility shim for .NET Standard and can be replaced should the
        ///   SDK change targets to .NET Standard 2.1 or target frameworks that provides those methods out of the box.
        ///   During  reviews it was decided to not multi-target due to the added complexity.
        ///  </remarks>
        ///
        ///  <seealso href="https://docs.microsoft.com/dotnet/api/system.text.encoding.getbytes?view=netstandard-2.1#system-text-encoding-getbytes(system-readonlyspan((system-char))-system-span((system-byte)))" />
        ///
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
