// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Provisioning.Utilities
{
    internal static class FormattableStringHelpers
    {
        /// <summary>
        /// Parses the format from a <see cref="FormattableString"/> and returns an enumerator
        /// that yields the parts of the format.
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public static GetFormatPartsEnumerator GetFormattableStringFormatParts(ReadOnlySpan<char> format) => new GetFormatPartsEnumerator(format);

        public ref struct GetFormatPartsEnumerator
        {
            private ReadOnlySpan<char> _format;
            public Part Current { get; private set; }

            public GetFormatPartsEnumerator(ReadOnlySpan<char> format)
            {
                _format = format;
                Current = default;
            }

            public readonly GetFormatPartsEnumerator GetEnumerator() => this;

            public bool MoveNext()
            {
                if (_format.Length == 0)
                {
                    return false;
                }

                var separatorIndex = _format.IndexOfAny('{', '}');

                if (separatorIndex == -1)
                {
                    Current = new Part(_format, true);
                    _format = ReadOnlySpan<char>.Empty;
                    return true;
                }

                var separator = _format[separatorIndex];
                // Handle {{ and }} escape sequences
                if (separatorIndex + 1 < _format.Length && _format[separatorIndex + 1] == separator)
                {
                    Current = new Part(_format.Slice(0, separatorIndex + 1), true);
                    _format = _format.Slice(separatorIndex + 2);
                    return true;
                }

                var isLiteral = separator == '{';

                // Skip empty literals
                if (isLiteral && separatorIndex == 0 && _format.Length > 1)
                {
                    separatorIndex = _format.IndexOf('}');
                    if (separatorIndex == -1)
                    {
                        Current = new Part(_format.Slice(1), true);
                        _format = ReadOnlySpan<char>.Empty;
                        return true;
                    }

                    Current = new Part(_format.Slice(1, separatorIndex - 1), false);
                }
                else
                {
                    Current = new Part(_format.Slice(0, separatorIndex), isLiteral);
                }

                _format = _format.Slice(separatorIndex + 1);
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
