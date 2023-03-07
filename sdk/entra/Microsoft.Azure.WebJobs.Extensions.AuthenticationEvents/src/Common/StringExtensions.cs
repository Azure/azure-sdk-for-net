// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>
    ///     Provides extension methods for performing operations on <see
    ///     cref="String"/> objects.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///     Matches two strings using ordinal ignore case and returns
        ///     boolean
        /// </summary>
        /// <param name="input">
        ///     The input string
        /// </param>
        /// <param name="compare">
        ///     The string to compare
        /// </param>
        /// <returns>
        ///     True if match
        /// </returns>
        public static bool EqualsOic(this string input, string compare)
            => String.Equals(input, compare, StringComparison.OrdinalIgnoreCase);

        /// <summary>
        ///     Returns true if the string collection contains the provided
        ///     string based on an ordinal case-insensitive comparison
        /// </summary>
        /// <param name="input">
        ///     The list to search through
        /// </param>
        /// <param name="compare">
        ///     The string to search for
        /// </param>
        /// <returns>
        ///     True if the list contains the provided string, false otherwise
        /// </returns>
        public static bool ContainsOic(this IEnumerable<string> input, string compare)
            => input.Any(element => element.EqualsOic(compare));

        /// <summary>
        ///     Returns true if the input string starts with the ordinal
        ///     case-insensitive compare string comparison
        /// </summary>
        /// <param name="input">
        ///     The input string
        /// </param>
        /// <param name="compare">
        ///     The string to compare
        /// </param>
        /// <returns>
        ///     True if the input string starts with the ordinal
        ///     case-insensitive compare string
        /// </returns>
        public static bool StartsWithOic(this string input, string compare)
            => input.StartsWith(compare, StringComparison.OrdinalIgnoreCase);

        /// <summary>
        ///     Returns true if the input string ends with the ordinal
        ///     case-insensitive compare string comparison
        /// </summary>
        /// <param name="input">
        ///     The input string
        /// </param>
        /// <param name="compare">
        ///     The string to compare
        /// </param>
        /// <returns>
        ///     True if the input string ends with the ordinal
        ///     case-insensitive compare string
        /// </returns>
        public static bool EndsWithOic(this string input, string compare)
            => input.EndsWith(compare, StringComparison.OrdinalIgnoreCase);

        /// <summary>
        ///     Check if string contains substring
        /// </summary>
        /// <param name="thisString">
        ///     String to check
        /// </param>
        /// <param name="innerString">
        ///     Substring to search for
        /// </param>
        /// <param name="comparison">
        ///     Comparison options
        /// </param>
        /// <returns>
        ///     True if thisString contains innerString
        /// </returns>
        public static bool Contains(this string thisString, string innerString, StringComparison comparison)
            => thisString?.IndexOf(innerString, comparison) >= 0;

        /// <summary>
        ///     This method checks whether a string has content which means that
        ///     it's non-null, non-empty, and not comprised only of whitespace.
        ///     It exists primarily because the following:
        ///     <code>
        ///         if (value.HasContent())
        ///     </code>
        ///     ...is not only more compact but easier to read than the
        ///     following when quickly scanning code due to the subject being in
        ///     front and not having to see/parse the not operator (!) squashed
        ///     between the parenthesis and variable name:
        ///     <code>
        ///         if (!String.IsNullOrWhitespace(value))
        ///     </code>
        /// </summary>
        /// <param name="value">
        ///     The string value being checked for content.
        /// </param>
        /// <returns>
        ///     True if the value has content; false otherwise.
        /// </returns>
        public static bool HasContent(this string value) => !value.HasNoContent();

        /// <summary>
        ///     This method checks whether a string has no content. That is, it
        ///     is null, empty or comprised only of whitespace. It is an alias
        ///     of <see cref="string.IsNullOrWhiteSpace(string)"/> and the
        ///     inverse of <see cref="HasContent(string)"/>.
        /// </summary>
        /// <param name="value">
        ///     The string value being checked for content.
        /// </param>
        /// <returns>
        ///     True if the value has no content; false otherwise.
        /// </returns>
        public static bool HasNoContent(this string value)
            => String.IsNullOrWhiteSpace(value);
    }
}
