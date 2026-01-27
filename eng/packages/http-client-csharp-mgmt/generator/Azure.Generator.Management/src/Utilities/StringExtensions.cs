// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Management.Utilities
{
    internal static class StringExtensions
    {
        public static string FirstCharToLowerCase(this string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsLower(str[0]))
                return str;

            return string.Concat(char.ToLower(str[0]), str.AsSpan(1).ToString());
        }
        public static IEnumerable<string> SplitByCamelCase(this string camelCase)
        {
            return camelCase.Humanize().Split(' ').Select(w => w.FirstCharToUpperCase());
        }

        public static string FirstCharToUpperCase(this string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsUpper(str[0]))
                return str;

            return char.ToUpper(str[0]) + str.Substring(1);
        }

        /// <summary>
        /// Pluralizes a PascalCase string by splitting it into words, pluralizing only the last word,
        /// and joining them back together.
        /// </summary>
        /// <param name="value">The PascalCase string to pluralize.</param>
        /// <returns>The pluralized string.</returns>
        public static string PluralizeLastWord(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            var words = value.SplitByCamelCase().ToArray();

            // Pluralize only the last word
            words[words.Length - 1] = words[words.Length - 1].Pluralize(inputIsKnownToBeSingular: false);

            return string.Concat(words);
        }
    }
}
