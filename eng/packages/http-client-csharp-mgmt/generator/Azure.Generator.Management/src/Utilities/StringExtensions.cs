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
        /// Pluralizes a PascalCase resource name by splitting it into words, pluralizing only the last word,
        /// and joining them back together.
        /// </summary>
        /// <param name="resourceName">The PascalCase resource name to pluralize.</param>
        /// <returns>The pluralized resource name.</returns>
        public static string PluralizeResourceName(this string resourceName)
        {
            if (string.IsNullOrEmpty(resourceName))
            {
                return resourceName;
            }

            var words = resourceName.SplitByCamelCase().ToArray();

            // Pluralize only the last word
            words[words.Length - 1] = words[words.Length - 1].Pluralize(inputIsKnownToBeSingular: false);

            return string.Concat(words);
        }
    }
}
