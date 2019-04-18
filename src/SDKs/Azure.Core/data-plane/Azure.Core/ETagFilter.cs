// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure
{
    public struct ETagFilter : IEquatable<ETagFilter>
    {
        public ETag IfMatch;
        public ETag IfNoneMatch;

        public bool Equals(ETagFilter other)
            => IfMatch.Equals(other.IfMatch) && IfNoneMatch.Equals(other.IfNoneMatch);

        public static bool operator ==(ETagFilter left, ETagFilter rigth)
            => left.Equals(rigth);

        public static bool operator !=(ETagFilter left, ETagFilter rigth)
            => !left.Equals(rigth);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
            => IfMatch.GetHashCode() ^ IfNoneMatch.GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            if (obj is ETagFilter other) return this == other;
            return false;
        }
    }
}
