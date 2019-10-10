// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Data;

namespace Azure
{
    public readonly struct ETag : IEquatable<ETag>
    {
        private const char QuoteCharacter = '"';
        private const string QuoteString = "\"";

        private readonly string _value;

        public ETag(string etag) => _value = etag;

        public static bool operator ==(ETag left, ETag right) => left.Equals(right);

        public static bool operator !=(ETag left, ETag right) => !left.Equals(right);

        public static readonly ETag All = new ETag("*");

        public bool Equals(ETag other)
        {
            return string.Equals(_value, other._value, StringComparison.Ordinal);
        }

        public bool Equals(string? other)
        {
            return string.Equals(_value, other, StringComparison.Ordinal);
        }

        public override bool Equals(object? obj)
        {
            return (obj is ETag other) && Equals(other);
        }

        public override int GetHashCode()
        {
            return _value?.GetHashCode() ?? 0;
        }

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
