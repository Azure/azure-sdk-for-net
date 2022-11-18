// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    internal static class SpanOfCharsExtensions
    {
        public static void AppendString(this ref Span<char> span, ref int offset, string str)
        {
#if NET6_0_OR_GREATER
            str.CopyTo(span[offset..]);
#else
            str.AsSpan().CopyTo(span.Slice(offset));
#endif
            offset += str.Length;
        }

        public static void AppendChar(this ref Span<char> span, ref int offset, char value)
        {
            span[offset] = value;
            offset++;
        }

        public static void AppendLong(this ref Span<char> span, ref int offset, long value, string? format = null, IFormatProvider? provider = null)
        {
#if NET6_0_OR_GREATER
            if (!value.TryFormat(span[offset..], out var charsWritten, format, provider))
            {
                throw new IndexOutOfRangeException();
            }
            offset += charsWritten;
#else
            var strValue = value.ToString(format, provider);
            strValue.AsSpan().CopyTo(span.Slice(offset));
            offset += strValue.Length;
#endif
        }
    }
}
