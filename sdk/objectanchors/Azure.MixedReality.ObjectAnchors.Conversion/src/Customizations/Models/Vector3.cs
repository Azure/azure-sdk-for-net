// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.MixedReality.ObjectAnchors.Conversion.Models
{
    /// <summary>
    /// The Vector3.
    /// </summary>
    internal partial class Vector3 : IEquatable<Vector3>
    {
        private System.Numerics.Vector3 data;

        internal Vector3(System.Numerics.Vector3 vector)
        {
            data = vector;
        }

        internal Vector3(float x, float y, float z)
        {
            data = new System.Numerics.Vector3(x, y, z);
        }

        public float X { get { return data.X; } set { data.X = value; } }

        public float Y { get { return data.Y; } set { data.Y = value; } }

        public float Z { get { return data.Z; } set { data.Z = value; } }

        public bool Equals(Vector3 other)
        {
            return this.data.Equals(other.data);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            return obj is Vector3 && this.Equals(obj as Quaternion);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return data.GetHashCode();
        }

        public bool IsNormalized()
        {
            return data.IsNormalized();
        }

        public static implicit operator System.Numerics.Vector3(Vector3 v) => v.data;
        public static implicit operator Vector3(System.Numerics.Vector3 v) => new Vector3(v);
    }
}
