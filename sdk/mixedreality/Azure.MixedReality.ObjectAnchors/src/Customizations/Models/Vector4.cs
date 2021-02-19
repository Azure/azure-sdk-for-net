// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.MixedReality.ObjectAnchors.Models
{
    /// <summary> The Vector4. </summary>
    internal partial class Vector4 : IEquatable<Vector4>
    {
        internal System.Numerics.Vector4 data;

        internal Vector4(System.Numerics.Vector4 vector)
        {
            data = vector;
        }

        /// <summary> Initializes a new instance of Vector4. </summary>
        /// <param name="x"> . </param>
        /// <param name="y"> . </param>
        /// <param name="z"> . </param>
        /// <param name="w"> . </param>
        internal Vector4(float x, float y, float z, float w)
        {
            data = new System.Numerics.Vector4(x, y, z, w);
        }

        public float X { get { return data.X; } set { data.X = value; } }

        public float Y { get { return data.Y; } set { data.Y = value; } }

        public float Z { get { return data.Z; } set { data.Z = value; } }

        public float W { get { return data.W; } set { data.W = value; } }

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
    }
}
