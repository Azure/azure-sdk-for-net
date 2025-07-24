// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Provisioning.Utilities
{
    internal static class FormattableStringHelpers
    {
        public static GetPathPartsEnumerator GetFormattableStringFormatParts(ReadOnlySpan<char> format) => new GetPathPartsEnumerator(format);

        public ref struct GetPathPartsEnumerator
        {
            private ReadOnlySpan<char> _path;
            public Part Current { get; private set; }

            public GetPathPartsEnumerator(ReadOnlySpan<char> format)
            {
                _path = format;
                Current = default;
            }

            public readonly GetPathPartsEnumerator GetEnumerator() => this;

            public bool MoveNext()
            {
                var span = _path;
                if (span.Length == 0)
                {
                    return false;
                }

                var separatorIndex = span.IndexOfAny('{', '}');

                if (separatorIndex == -1)
                {
                    Current = new Part(span, true);
                    _path = ReadOnlySpan<char>.Empty;
                    return true;
                }

                var separator = span[separatorIndex];
                // Handle {{ and }} escape sequences
                if (separatorIndex + 1 < span.Length && span[separatorIndex + 1] == separator)
                {
                    Current = new Part(span.Slice(0, separatorIndex + 1), true);
                    _path = span.Slice(separatorIndex + 2);
                    return true;
                }

                var isLiteral = separator == '{';

                // Skip empty literals
                if (isLiteral && separatorIndex == 0 && span.Length > 1)
                {
                    separatorIndex = span.IndexOf('}');
                    if (separatorIndex == -1)
                    {
                        Current = new Part(span.Slice(1), true);
                        _path = ReadOnlySpan<char>.Empty;
                        return true;
                    }

                    Current = new Part(span.Slice(1, separatorIndex - 1), false);
                }
                else
                {
                    Current = new Part(span.Slice(0, separatorIndex), isLiteral);
                }

                _path = span.Slice(separatorIndex + 1);
                return true;
            }

            internal readonly ref struct Part
            {
                public Part(ReadOnlySpan<char> span, bool isLiteral)
                {
                    Span = span;
                    IsLiteral = isLiteral;
                }

                public ReadOnlySpan<char> Span { get; }
                public bool IsLiteral { get; }

                public void Deconstruct(out ReadOnlySpan<char> span, out bool isLiteral)
                {
                    span = Span;
                    isLiteral = IsLiteral;
                }

                public void Deconstruct(out ReadOnlySpan<char> span, out bool isLiteral, out int argumentIndex)
                {
                    span = Span;
                    isLiteral = IsLiteral;

                    if (IsLiteral)
                    {
                        argumentIndex = -1;
                    }
                    else
                    {
                        var formatSeparatorIndex = span.IndexOf(':');
                        var indexSpan = formatSeparatorIndex == -1 ? span : span.Slice(0, formatSeparatorIndex);
#if NET8_0_OR_GREATER
                        argumentIndex = int.Parse(indexSpan);
#else
                        argumentIndex = int.Parse(indexSpan.ToString());
#endif
                    }
                }
            }
        }
    }
}
