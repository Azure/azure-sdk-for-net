// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.MixedReality.ObjectAnchors.Conversion.Models
{
    /// <summary>
    /// The Vector4.
    /// </summary>
    internal partial class Vector4 : IEquatable<Vector4>
    {
        private System.Numerics.Vector4 data;

        /// <summary>
        /// Creates a autorest-defined Vector4 given its Numerics equivalent.
        /// </summary>
        /// <param name="vector">The numerics vector.</param>
        internal Vector4(System.Numerics.Vector4 vector)
        {
            data = vector;
        }

        /// <summary>
        /// Creates a autorest-defined Vector4 given its fields.
        /// </summary>
        /// <param name="x">X component.</param>
        /// <param name="y">Y component.</param>
        /// <param name="z">Z component.</param>
        /// <param name="w">W component.</param>
        internal Vector4(float x, float y, float z, float w)
        {
            data = new System.Numerics.Vector4(x, y, z, w);
        }

        /// <summary>
        /// X component.
        /// </summary>
        public float X { get { return data.X; } set { data.X = value; } }

        /// <summary>
        /// Y component.
        /// </summary>
        public float Y { get { return data.Y; } set { data.Y = value; } }

        /// <summary>
        /// Z component.
        /// </summary>
        public float Z { get { return data.Z; } set { data.Z = value; } }

        /// <summary>
        /// W component.
        /// </summary>
        public float W { get { return data.W; } set { data.W = value; } }

        /// <summary>
        /// Assesses equality with another vector.
        /// </summary>
        /// <param name="other">The other vector being compared to.</param>
        /// <returns>Whether the two are equal.</returns>
        public bool Equals(Vector4 other)
        {
            return this.data.Equals(other.data);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            return obj is Vector4 && this.Equals(obj as Vector4);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return data.GetHashCode();
        }

        public static implicit operator System.Numerics.Vector4(Vector4 v) => v.data;
        public static implicit operator Vector4(System.Numerics.Vector4 v) => new Vector4(v);
    }
}
