// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.MixedReality.ObjectAnchors.Conversion.Models
{
    /// <summary>
    /// The Quaternion.
    /// </summary>
    internal partial class Quaternion : IEquatable<Quaternion>
    {
        private System.Numerics.Quaternion data;

        internal Quaternion(System.Numerics.Quaternion quaternion)
        {
            data = quaternion;
        }

#pragma warning disable CA1801 // Review unused parameters
        internal Quaternion(float x, float y, float z, float w, bool isIdentity) : this(x, y, z, w)
#pragma warning restore CA1801 // Review unused parameters
        {
        }

        internal Quaternion(float x, float y, float z, float w)
        {
            data = new System.Numerics.Quaternion(x, y, z, w);
        }

        public float X { get { return data.X; } set { data.X = value; } }

        public float Y { get { return data.Y; } set { data.Y = value; } }

        public float Z { get { return data.Z; } set { data.Z = value; } }

        public float W { get { return data.W; } set { data.W = value; } }

        public bool IsIdentity { get => data.IsIdentity; }

        public bool Equals(Quaternion other)
        {
            return this.data.Equals(other.data);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            return obj is Quaternion && this.Equals(obj as Quaternion);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return data.GetHashCode();
        }

        public static implicit operator System.Numerics.Quaternion(Quaternion q) => q.data;
        public static implicit operator Quaternion(System.Numerics.Quaternion q) => new Quaternion(q);
    }
}
