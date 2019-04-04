// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.Base.Buffers
{
    internal static class Transcoder
    {
        internal static bool TryUtf16ToUtf8(ReadOnlySpan<char> utf16, Span<byte> utf8, out int written)
        {
            unsafe
            {
                fixed (char* utf16Buffer = utf16)
                fixed (byte* utf8Buffer = utf8)
                {
                    int needed = Encoding.UTF8.GetByteCount(utf16Buffer, utf16.Length);
                    if (utf8.Length < needed)
                    {
                        written = 0;
                        return false;
                    }
                    written = Encoding.UTF8.GetBytes(utf16Buffer, utf16.Length, utf8Buffer, utf8.Length);
                    return true;
                }
            }
        }

        internal static bool TryUtf16ToAscii(ReadOnlySpan<char> utf16, Span<byte> ascii, out int written)
        {
            unsafe
            {
                fixed (char* utf16Buffer = utf16)
                fixed (byte* asciiBuffer = ascii)
                {
                    int needed = Encoding.ASCII.GetByteCount(utf16Buffer, utf16.Length);
                    if (ascii.Length < needed)
                    {
                        written = 0;
                        return false;
                    }
                    written = Encoding.ASCII.GetBytes(utf16Buffer, utf16.Length, asciiBuffer, ascii.Length);
                    return true;
                }
            }
        }

        internal static string AsciiToString(this ReadOnlySpan<byte> ascii)
        {
            unsafe
            {
                fixed (byte* asciiBuffer = ascii)
                    return Encoding.ASCII.GetString(asciiBuffer, ascii.Length);
            }
        }
    }
}
