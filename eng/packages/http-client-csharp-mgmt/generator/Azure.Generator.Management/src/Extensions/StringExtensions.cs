// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Humanizer;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Management.Extensions
{
    internal static class StringExtensions
    {
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
        /// Change a word to its singular form.
        /// Notice that this function will treat this word as a whole word instead of only changing the last word if it contains multiple words. Please use <see cref="LastWordToSingular(string, bool)"/> instead.
        /// </summary>
        /// <param name="plural"></param>
        /// <param name="inputIsKnownToBePlural"></param>
        /// <returns></returns>
        public static string ToSingular(this string plural, bool inputIsKnownToBePlural = true)
        {
            return plural.Singularize(inputIsKnownToBePlural);
        }

        public static string LastWordToSingular(this string plural, bool inputIsKnownToBePlural = true)
        {
            var words = plural.SplitByCamelCase();
            var lastWord = words.Last();
            var lastWordSingular = lastWord.ToSingular(inputIsKnownToBePlural);
            if (inputIsKnownToBePlural || lastWord != lastWordSingular)
            {
                return $"{string.Join("", words.SkipLast(1))}{lastWordSingular}";
            }
            return plural;
        }
    }
}
