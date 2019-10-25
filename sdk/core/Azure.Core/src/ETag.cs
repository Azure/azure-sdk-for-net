// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure
{
    /// <summary>
    /// Represents an HTTP ETag.
    /// </summary>
    public readonly struct ETag : IEquatable<ETag>
    {
        private const char QuoteCharacter = '"';
        private const string QuoteString = "\"";

        private readonly string _value;

        /// <summary>
        /// Creates a new instance of <see cref="ETag"/>.
        /// </summary>
        /// <param name="etag">The string value of the ETag.</param>
        public ETag(string etag) => _value = etag;

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
        public override string ToString()
        {
            return _value ?? "<null>";
        }

        internal static ETag Parse(string value)
        {
            if (value == All._value)
            {
                return All;
            }
            else if (value.StartsWith("W/", StringComparison.Ordinal))
            {
                throw new NotSupportedException("Weak ETags are not supported.");
            }
            else if (!value.StartsWith(QuoteString, StringComparison.Ordinal) ||
                     !value.EndsWith(QuoteString, StringComparison.Ordinal))
            {
                throw new ArgumentException("The value should be equal to * or be wrapped in quotes", nameof(value));
            }

            return new ETag(value.Trim(QuoteCharacter));
        }
    }
}
