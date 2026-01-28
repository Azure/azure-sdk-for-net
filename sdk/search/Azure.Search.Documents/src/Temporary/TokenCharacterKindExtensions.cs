// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Search.Documents.Indexes.Models
{
    internal static partial class TokenCharacterKindExtensions
    {
        public static string ToSerialString(this TokenCharacterKind value) => value.ToString();

        public static TokenCharacterKind ToTokenCharacterKind(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "letter"))
                return TokenCharacterKind.Letter;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "digit"))
                return TokenCharacterKind.Digit;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "whitespace"))
                return TokenCharacterKind.Whitespace;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "punctuation"))
                return TokenCharacterKind.Punctuation;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "symbol"))
                return TokenCharacterKind.Symbol;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown TokenCharacterKind value.");
        }
    }
}
