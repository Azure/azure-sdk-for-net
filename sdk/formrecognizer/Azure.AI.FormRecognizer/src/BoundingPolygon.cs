// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    /// <summary>
    /// A sequence of <see cref="PointF"/> representing a polygon that outlines an element in
    /// a recognized document. Coordinates are specified relative to the top-left of the page,
    /// and points are ordered clockwise from the left relative to the element orientation. Units
    /// are in pixels for images and inches for PDF. The <see cref="LengthUnit"/> type of a recognized
    /// page can be found at <see cref="DocumentPage.Unit"/>.
    /// </summary>
    public readonly struct BoundingPolygon
    {
        private readonly PointF[] _points;

        internal BoundingPolygon(IReadOnlyList<float> boundingPolygon)
        {
            if (boundingPolygon.Count == 0)
            {
                _points = Array.Empty<PointF>();
                return;
            }

            int count = boundingPolygon.Count / 2;

            _points = new PointF[count];
            for (int i = 0; i < count; i++)
            {
                _points[i] = new PointF(boundingPolygon[2 * i], boundingPolygon[(2 * i) + 1]);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BoundingPolygon"/> structure.
        /// </summary>
        /// <param name="points">The sequence of points defining this <see cref="BoundingPolygon"/>.</param>
        internal BoundingPolygon(IReadOnlyList<PointF> points)
        {
            _points = points?.ToArray();
        }

        internal PointF[] Points => _points ?? Array.Empty<PointF>();

        /// <summary>
        /// Gets one of the points that set the limits of this <see cref="BoundingPolygon"/>.
        /// Coordinates are specified relative to the top-left of the original image, and points
        /// are ordered clockwise from the left relative to the text orientation.
        /// </summary>
        /// <param name="index">The 0-based index of the point to be retrieved.</param>
        /// <returns>A <see cref="PointF"/> corresponding to the specified <paramref name="index"/>.</returns>
        public PointF this[int index] => Points[index];

        /// <summary>
        /// Returns string representation for <see cref="BoundingPolygon"/>.
        /// </summary>
        public override string ToString() => string.Join(",", Points.Select(p => p.ToString()).ToArray());
    }
}
