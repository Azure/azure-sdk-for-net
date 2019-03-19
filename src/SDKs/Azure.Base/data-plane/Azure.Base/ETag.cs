// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Text;

namespace Azure
{
    public readonly struct ETag : IEquatable<ETag>
    {
        readonly byte[] _ascii;

        public ETag(string etag) => _ascii = Encoding.ASCII.GetBytes(etag);

        public bool Equals(ETag other)
        {
            if(_ascii == null) {
                if (other._ascii == null) return true;
                return false;
            }
            if (other._ascii == null) return false;
            
            return _ascii.AsSpan().SequenceEqual(other._ascii);
        }

        public static bool operator ==(ETag left, ETag rigth) => left.Equals(rigth);

        public static bool operator !=(ETag left, ETag rigth) => !left.Equals(rigth);

        public override string ToString() => _ascii == null ? "<null>" : Encoding.ASCII.GetString(_ascii);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            if (_ascii == null) return 0;
            int hash = 17;
            for (int i = 0; i < _ascii.Length; i+=2)
            {
                hash = hash * 23 + _ascii[i];
            }
            return hash;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            if (obj is ETag other) return this == other;
            return false;
        }
    }
}
