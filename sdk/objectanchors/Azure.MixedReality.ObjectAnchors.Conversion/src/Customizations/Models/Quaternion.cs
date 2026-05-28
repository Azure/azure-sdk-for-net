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

        /// <summary>
        /// Creates a autorest-defined Quaternion given its Numerics equivalent.
        /// </summary>
        /// <param name="quaternion">The numerics quaternion.</param>
        internal Quaternion(System.Numerics.Quaternion quaternion)
        {
            data = quaternion;
        }

        /// <summary>
        /// Creates a autorest-defined Quaternion given its fields.
        /// </summary>
        /// <param name="x">X component.</param>
        /// <param name="y">Y component.</param>
        /// <param name="z">Z component.</param>
        /// <param name="w">W component.</param>
        /// <param name="isIdentity">Unused.</param>
#pragma warning disable CA1801 // Review unused parameters
        internal Quaternion(float x, float y, float z, float w, bool isIdentity) : this(x, y, z, w)
#pragma warning restore CA1801 // Review unused parameters
        {
        }

        /// <summary>
        /// Creates a autorest-defined Quaternion given its fields.
        /// </summary>
        /// <param name="x">X component.</param>
        /// <param name="y">Y component.</param>
        /// <param name="z">Z component.</param>
        /// <param name="w">W component.</param>
        internal Quaternion(float x, float y, float z, float w)
        {
            data = new System.Numerics.Quaternion(x, y, z, w);
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
        /// Gets a value that indicates whether the current instance is the identity quaternion.
        /// </summary>
        public bool IsIdentity { get => data.IsIdentity; }

        /// <summary>
        /// Assesses equality with another quaternion.
        /// </summary>
        /// <param name="other">The other quaternion being compared to.</param>
        /// <returns>Whether the two are equal.</returns>
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
