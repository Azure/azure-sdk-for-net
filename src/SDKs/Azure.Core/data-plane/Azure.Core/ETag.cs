// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.ComponentModel;
using System.Text;

namespace Azure.Core
{
    public struct ETag : IEquatable<ETag>
    {
        byte[] _ascii;

        public ETag(string etag) => _ascii = Encoding.ASCII.GetBytes(etag);

        public bool Equals(ETag other)
        {
            return this._ascii == other._ascii;
        }

        public override int GetHashCode() => 0;

        public static bool operator ==(ETag left, ETag rigth)
            => left.Equals(rigth);

        public static bool operator !=(ETag left, ETag rigth)
            => !left.Equals(rigth);

        public override string ToString()
            => Encoding.ASCII.GetString(_ascii);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            if (obj is ETag other) return this == other;
            return false;
        }
    }
}
