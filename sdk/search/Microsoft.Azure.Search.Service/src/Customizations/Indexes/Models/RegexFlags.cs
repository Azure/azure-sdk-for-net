// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using Microsoft.Azure.Search.Common;
    using Newtonsoft.Json;
    using Serialization;

    /// <summary>
    /// Defines flags that can be combined to control how regular expressions are used in the pattern analyzer and
    /// pattern tokenizer.
    /// <see href="http://docs.oracle.com/javase/6/docs/api/java/util/regex/Pattern.html#field_summary"/>
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<RegexFlags>))]
    public struct RegexFlags : IEquatable<RegexFlags>
    {
        private readonly string _value;

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

        private RegexFlags(string flags)
        {
            Throw.IfArgumentNull(flags, nameof(flags));
            _value = flags;
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
        public static RegexFlags operator |(RegexFlags lhs, RegexFlags rhs) => new RegexFlags($"{lhs}|{rhs}");

        /// <summary>
        /// Defines implicit conversion from string to RegexFlags.
        /// </summary>
        /// <param name="value">string to convert.</param>
        /// <returns>The string as a RegexFlags.</returns>
        public static implicit operator RegexFlags(string value) => new RegexFlags(value);

        /// <summary>
        /// Defines explicit conversion from RegexFlags to string.
        /// </summary>
        /// <param name="flags">RegexFlags to convert.</param>
        /// <returns>The RegexFlags as a string.</returns>
        public static explicit operator string(RegexFlags flags) => flags.ToString();

        /// <summary>
        /// Compares two RegexFlags values for equality.
        /// </summary>
        /// <param name="lhs">The first RegexFlags to compare.</param>
        /// <param name="rhs">The second RegexFlags to compare.</param>
        /// <returns>true if the RegexFlags objects are equal or are both null; false otherwise.</returns>
        public static bool operator ==(RegexFlags lhs, RegexFlags rhs) => Equals(lhs, rhs);

        /// <summary>
        /// Compares two RegexFlags values for inequality.
        /// </summary>
        /// <param name="lhs">The first RegexFlags to compare.</param>
        /// <param name="rhs">The second RegexFlags to compare.</param>
        /// <returns>true if the RegexFlags objects are not equal; false otherwise.</returns>
        public static bool operator !=(RegexFlags lhs, RegexFlags rhs) => !Equals(lhs, rhs);

        /// <summary>
        /// Compares the RegexFlags for equality with another RegexFlags.
        /// </summary>
        /// <param name="other">The RegexFlags with which to compare.</param>
        /// <returns><c>true</c> if the RegexFlags objects are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(RegexFlags other) => _value == other._value;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj) => obj is RegexFlags ? Equals((RegexFlags)obj) : false;

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode() => _value.GetHashCode();

        /// <summary>
        /// Returns a string representation of the RegexFlags.
        /// </summary>
        /// <returns>The RegexFlags as a string.</returns>
        public override string ToString() => _value;
    }
}
