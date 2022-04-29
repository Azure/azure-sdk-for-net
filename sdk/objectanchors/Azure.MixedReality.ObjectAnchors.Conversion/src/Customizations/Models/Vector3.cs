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

        /// <summary>
        /// Creates a autorest-defined Vector3 given its Numerics equivalent.
        /// </summary>
        /// <param name="vector">The numerics vector.</param>
        internal Vector3(System.Numerics.Vector3 vector)
        {
            data = vector;
        }

        /// <summary>
        /// Creates a autorest-defined Vector3 given its fields.
        /// </summary>
        /// <param name="x">X component.</param>
        /// <param name="y">Y component.</param>
        /// <param name="z">Z component.</param>
        internal Vector3(float x, float y, float z)
        {
            data = new System.Numerics.Vector3(x, y, z);
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
        /// Assesses equality with another vector.
        /// </summary>
        /// <param name="other">The other vector being compared to.</param>
        /// <returns>Whether the two are equal.</returns>
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

        public static explicit operator System.Numerics.Vector3(Vector3 v) => v.data;
        public static explicit operator Vector3(System.Numerics.Vector3 v) => new Vector3(v);
    }
}
