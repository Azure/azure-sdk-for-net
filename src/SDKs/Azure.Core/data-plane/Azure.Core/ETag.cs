// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure
{
    public readonly struct ETag : IEquatable<ETag>
    {
        private readonly string _value;

        public ETag(string etag) => _value = etag;

        public static bool operator ==(ETag left, ETag right) => left.Equals(right);

        public static bool operator !=(ETag left, ETag right) => !left.Equals(right);

        public bool Equals(ETag other)
        {
            return string.Equals(_value, other._value);
        }

        public bool Equals(string other)
        {
            return string.Equals(_value, other);
        }

        public override bool Equals(object obj)
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
    }
}
