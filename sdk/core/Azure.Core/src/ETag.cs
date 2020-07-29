// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure
{
    /// <summary>
    /// Represents an HTTP ETag.
    /// </summary>
    public readonly struct ETag : IEquatable<ETag>
    {
        private const char QuoteCharacter = '"';
        private const string QuoteString = "\"";
        private const string WeakETagPrefix = "W/\"";
        private readonly string _value;
        private readonly bool _preserveRawValue;

        /// <summary>
        /// Creates a new instance of <see cref="ETag"/>.
        /// </summary>
        /// <param name="etag">The string value of the ETag.</param>
        public ETag(string etag)
        {
            _value = etag;
            _preserveRawValue = true;;
        }

        /// <summary>
        /// Creates a new instance of <see cref="ETag"/>.
        /// </summary>
        /// <param name="etag">The string value of the ETag.</param>
        /// <param name="preserveValue">Indicates whether the value of the etag should be preserved as is rather that formatted with wrapping quotes.</param>
        private ETag(string etag, bool preserveValue)
        {
            _value = etag;
            _preserveRawValue = preserveValue;;
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
            return _value?.GetHashCode() ?? 0;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns>The string representation of this <see cref="ETag"/>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            return _value ?? "<null>";
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns>The formatted string representation of this <see cref="ETag"/>. This includes outter quotes and the W/ prefix in the case of weak ETags.</returns>
        public string ToFormattedString()
        {
            if (_value == null)
            {
                return "<null>";
            }
            return _preserveRawValue ? _value : $"{QuoteString}{_value}{QuoteString}";
        }

        internal static ETag Parse(string value)
        {
            if (value == All._value)
            {
                return All;
            }
            else if (!(value.StartsWith(QuoteString, StringComparison.Ordinal) || value.StartsWith(WeakETagPrefix, StringComparison.Ordinal)) ||
                 !value.EndsWith(QuoteString, StringComparison.Ordinal))
            {
                throw new ArgumentException("The value should be equal to * , be wrapped in quotes, or be wrapped in quotes prefixed by W/", nameof(value));
            }

            if (value.StartsWith(WeakETagPrefix, StringComparison.Ordinal))
            {
                return new ETag(value, true);
            }
            else
            {
                return new ETag(value.Trim(QuoteCharacter), false);
            }
        }
    }
}
