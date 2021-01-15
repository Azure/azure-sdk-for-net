// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure
{
    /// <summary>
    /// Represents an HTTP ETag.
    /// </summary>
    [JsonConverter(typeof(ETagConverter))]
    public readonly struct ETag : IEquatable<ETag>
    {
        private const char QuoteCharacter = '"';
        private const string QuoteString = "\"";
        private const string WeakETagPrefix = "W/\"";
        private const string DefaultFormat = "G";
        private const string HeaderFormat = "H";
        private readonly string? _value;

        /// <summary>
        /// Creates a new instance of <see cref="ETag"/>.
        /// </summary>
        /// <param name="etag">The string value of the ETag.</param>
        public ETag(string etag)
        {
            _value = etag;
        }

        /// <summary>
        /// Compares equality of two <see cref="ETag"/> instances.
        /// </summary>
        /// <param name="left">The <see cref="ETag"/> to compare.</param>
        /// <param name="right">The <see cref="ETag"/> to compare to.</param>
        /// <returns><c>true</c> if values of both ETags are equal, otherwise <c>false</c>.</returns>
        public static bool operator ==(ETag left, ETag right) => left.Equals(right);

        /// <summary>
        /// Compares inequality of two <see cref="ETag"/> instances.
        /// </summary>
        /// <param name="left">The <see cref="ETag"/> to compare.</param>
        /// <param name="right">The <see cref="ETag"/> to compare to.</param>
        /// <returns><c>true</c> if values of both ETags are not equal, otherwise <c>false</c>.</returns>
        public static bool operator !=(ETag left, ETag right) => !left.Equals(right);

        /// <summary>
        /// Instance of <see cref="ETag"/> with the value. <code>*</code>
        /// </summary>
        public static readonly ETag All = new ETag("*");

        /// <inheritdoc />
        public bool Equals(ETag other)
        {
            return string.Equals(_value, other._value, StringComparison.Ordinal);
        }
        /// <summary>
        /// Indicates whether the value of current <see cref="ETag"/> is equal to the provided string.</summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the <paramref name="other">other</paramref> parameter; otherwise, false.</returns>
        public bool Equals(string? other)
        {
            return string.Equals(_value, other, StringComparison.Ordinal);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return (obj is ETag other) && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return _value.GetHashCodeOrdinal();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns>The string representation of this <see cref="ETag"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => ToString("G");

        /// <summary>
        /// Returns the string representation of the <see cref="ETag"/>.
        /// </summary>
        /// <param name="format">A format string. Valid values are "G" for standard format and "H" for header format.</param>
        /// <returns>The formatted string representation of this <see cref="ETag"/>. This includes outer quotes and the W/ prefix in the case of weak ETags.</returns>
        /// <example>
        /// <code>
        /// ETag tag = ETag.Parse("\"sometag\"");
        /// Console.WriteLine(tag.ToString("G"));
        /// // Displays: sometag
        /// Console.WriteLine(tag.ToString("H"));
        /// // Displays: "sometag"
        /// </code>
        /// </example>
        public string ToString(string format)
        {
            if (_value == null)
            {
                return "<null>";
            }

            var _needsQuoateWrap = !IsValidQuotedFormat(_value);

            return format switch
            {
                HeaderFormat => _needsQuoateWrap ?  $"{QuoteString}{_value}{QuoteString}" : _value,
                DefaultFormat => _value,
                _ => throw new ArgumentException("Invalid format string.")
            };
        }

        internal static ETag Parse(string value)
        {
            if (value == All._value)
            {
                return All;
            }
            else if (!IsValidQuotedFormat(value))
            {
                throw new ArgumentException("The value should be equal to * , be wrapped in quotes, or be wrapped in quotes prefixed by W/", nameof(value));
            }

            if (value.StartsWith(WeakETagPrefix, StringComparison.Ordinal))
            {
                return new ETag(value);
            }
            else
            {
                return new ETag(value.Trim(QuoteCharacter));
            }
        }

        private static bool IsValidQuotedFormat(string value) {
            return (value.StartsWith(QuoteString, StringComparison.Ordinal) || value.StartsWith(WeakETagPrefix, StringComparison.Ordinal)) &&
                value.EndsWith(QuoteString, StringComparison.Ordinal) || value == All._value;
        }
    }
}
