// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using Newtonsoft.Json;
    using Serialization;

    /// <summary>
    /// Defines flags that can be combined to control how regular expressions are used in the pattern analyzer and
    /// pattern tokenizer.
    /// <see href="http://docs.oracle.com/javase/6/docs/api/java/util/regex/Pattern.html#field_summary"/>
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<RegexFlags>))]
    public sealed class RegexFlags : ExtensibleEnum<RegexFlags>
    {
        // MAINTENANCE NOTE: Keep these ordered the same as the table on this page:
        // http://docs.oracle.com/javase/6/docs/api/java/util/regex/Pattern.html#field_summary

        /// <summary>
        /// Enables canonical equivalence. <see href="http://docs.oracle.com/javase/6/docs/api/java/util/regex/Pattern.html#CANON_EQ"/>
        /// </summary>
        public static readonly RegexFlags CanonEq = new RegexFlags("CANON_EQ");

        /// <summary>
        /// Enables case-insensitive matching. <see href="http://docs.oracle.com/javase/6/docs/api/java/util/regex/Pattern.html#CASE_INSENSITIVE"/>
        /// </summary>
        public static readonly RegexFlags CaseInsensitive = new RegexFlags("CASE_INSENSITIVE");

        /// <summary>
        /// Permits whitespace and comments in the pattern. <see href="http://docs.oracle.com/javase/6/docs/api/java/util/regex/Pattern.html#COMMENTS"/>
        /// </summary>
        public static readonly RegexFlags Comments = new RegexFlags("COMMENTS");

        /// <summary>
        /// Enables dotall mode. <see href="http://docs.oracle.com/javase/6/docs/api/java/util/regex/Pattern.html#DOTALL"/>
        /// </summary>
        public static readonly RegexFlags DotAll = new RegexFlags("DOTALL");

        /// <summary>
        /// Enables literal parsing of the pattern. <see href="http://docs.oracle.com/javase/6/docs/api/java/util/regex/Pattern.html#LITERAL"/>
        /// </summary>
        public static readonly RegexFlags Literal = new RegexFlags("LITERAL");

        /// <summary>
        /// Enables multiline mode. <see href="http://docs.oracle.com/javase/6/docs/api/java/util/regex/Pattern.html#MULTILINE"/>
        /// </summary>
        public static readonly RegexFlags Multiline = new RegexFlags("MULTILINE");

        /// <summary>
        /// Enables Unicode-aware case folding. <see href="http://docs.oracle.com/javase/6/docs/api/java/util/regex/Pattern.html#UNICODE_CASE"/>
        /// </summary>
        public static readonly RegexFlags UnicodeCase = new RegexFlags("UNICODE_CASE");

        /// <summary>
        /// Enables Unix lines mode. <see href="http://docs.oracle.com/javase/6/docs/api/java/util/regex/Pattern.html#UNIX_LINES"/>
        /// </summary>
        public static readonly RegexFlags UnixLines = new RegexFlags("UNIX_LINES");

        private RegexFlags(string name) : base(name)
        {
            // Base class does all initialization.
        }

        /// <summary>
        /// Creates a new RegexFlags instance, or returns an existing instance if the given name matches that of a
        /// known regex flag.
        /// </summary>
        /// <param name="flagExpression">
        /// Name of the regex flag, or an expression comprised of two or more flags separated by vertical bars (|).
        /// </param>
        /// <returns>A RegexFlags instance with the given expression.</returns>
        public static RegexFlags Create(string flagExpression)
        {
            // Regex flags are purposefully open-ended. If we get one we don't recognize, just create a new object.
            return Lookup(flagExpression) ?? new RegexFlags(flagExpression);
        }

        /// <summary>
        /// Overloads the bitwise OR operator to combines two RegexFlags.
        /// </summary>
        /// <param name="lhs">The left-hand side of the OR expression.</param>
        /// <param name="rhs">The right-hand side of the OR expression.</param>
        /// <returns>
        /// A new RegexFlags that is the result of concatenating the two given RegexFlags, separated by a
        /// vertical bar (|).
        /// </returns>
        public static RegexFlags operator |(RegexFlags lhs, RegexFlags rhs)
        {
            if (lhs == null)
            {
                return rhs;
            }

            if (rhs == null)
            {
                return lhs;
            }

            return new RegexFlags(String.Format("{0}|{1}", lhs, rhs));
        }
    }
}
