// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.MixedReality.ObjectAnchors.Models
{
    /// <summary> The Quaternion. </summary>
    internal partial class Quaternion : IEquatable<Quaternion>
    {
        internal System.Numerics.Quaternion data;

        internal Quaternion(System.Numerics.Quaternion quaternion)
        {
            data = quaternion;
        }

        /// <summary> Initializes a new instance of Quaternion. </summary>
        /// <param name="x"> . </param>
        /// <param name="y"> . </param>
        /// <param name="z"> . </param>
        /// <param name="w"> . </param>
        /// <param name="isIdentity"> . </param>
#pragma warning disable CA1801 // Review unused parameters
        internal Quaternion(float x, float y, float z, float w, bool isIdentity) : this(x, y, z, w)
#pragma warning restore CA1801 // Review unused parameters
        {
        }

        /// <summary> Initializes a new instance of Quaternion. </summary>
        /// <param name="x"> . </param>
        /// <param name="y"> . </param>
        /// <param name="z"> . </param>
        /// <param name="w"> . </param>
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
    }
}
