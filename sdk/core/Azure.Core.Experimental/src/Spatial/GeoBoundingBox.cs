// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Drawing;

namespace Azure.Core.Spatial
{
    /// <summary>
    /// Represents information about the coordinate range of the <see cref="GeoObject"/>.
    /// </summary>
    public readonly struct GeoBoundingBox : IEquatable<GeoBoundingBox>
    {
        internal double C1 { get; }
        internal double C2 { get; }
        internal double? C3 { get; }
        internal double C4 { get; }
        internal double C5 { get; }
        internal double? C6 { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="boundingBox"></param>
        public GeoBoundingBox(GeometryBoundingBox boundingBox)
        {
            C1 = boundingBox.MinX;
            C2 = boundingBox.MinY;
            C3 = boundingBox.MinZ;
            C4 = boundingBox.MaxX;
            C5 = boundingBox.MaxY;
            C6 = boundingBox.MaxZ;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="boundingBox"></param>
        public GeoBoundingBox(GeographyBoundingBox boundingBox)
        {
            C1 = boundingBox.West;
            C2 = boundingBox.South;
            C3 = boundingBox.MinAltitude;
            C4 = boundingBox.East;
            C5 = boundingBox.North;
            C6 = boundingBox.MaxAltitude;
        }

        /// <summary>
        /// Returns a geography representation of the bounding box.
        /// </summary>
        /// <returns>A <see cref="GeographyBoundingBox"/> object.</returns>
        public GeographyBoundingBox AsGeographyBoundingBox()
        {
            return new GeographyBoundingBox(C1, C2, C4, C5, C3, C6);
        }

        /// <summary>
        /// Returns a geometry representation of the bounding box.
        /// </summary>
        /// <returns>A <see cref="GeometryBoundingBox"/> object.</returns>
        public GeometryBoundingBox AsGeometryBoundingBox()
        {
            return new GeometryBoundingBox(C1, C2, C3, C4, C5, C6);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="GeoBoundingBox"/>.
        /// </summary>
        public GeoBoundingBox(double c1, double c2, double c3, double c4) : this(c1, c2, null, c3, c4, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="GeoBoundingBox"/>.
        /// </summary>
        public GeoBoundingBox(double c1, double c2, double? c3, double c4, double c5, double? c6)
        {
            C1 = c1;
            C2 = c2;
            C3 = c3;
            C4 = c4;
            C5 = c5;
            C6 = c6;
        }

        /// <inheritdoc />
        public bool Equals(GeoBoundingBox other)
        {
            return C1.Equals(other.C1) &&
                   C2.Equals(other.C2) &&
                   C4.Equals(other.C4) &&
                   C5.Equals(other.C5) &&
                   Nullable.Equals(C3, other.C3) &&
                   Nullable.Equals(C5, other.C5);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return obj is GeoBoundingBox other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return HashCodeBuilder.Combine(C1, C2, C3, C4, C5, C6);
        }


        /// <inheritdoc />
        public override string ToString()
        {
            if (C3 == null && C6 == null)
            {
                return $"[{C1}, {C2}, {C4}, {C5}]";
            }
            return $"[{C1}, {C2}, {C3}, {C4}, {C5}, {C6}]";
        }
    }
}