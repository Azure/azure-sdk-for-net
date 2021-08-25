// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// A sequence of four <see cref="PointF"/> representing a quadrilateral that outlines
    /// the text of an element in a recognized form. Coordinates are specified relative to the
    /// top-left of the original image, and points are ordered clockwise from the top-left corner
    /// relative to the text orientation. Units are in pixels for images and inches for PDF. The
    /// <see cref="LengthUnit"/> type of a recognized page can be found at <see cref="FormPage.Unit"/>.
    /// </summary>
    public readonly struct FieldBoundingBox
    {
        private readonly PointF[] _points;

        internal FieldBoundingBox(IReadOnlyList<float> boundingBox)
        {
            if (boundingBox.Count == 0)
            {
                _points = Array.Empty<PointF>();
                return;
            }

            int count = boundingBox.Count / 2;

            _points = new PointF[count];
            for (int i = 0; i < count; i++)
            {
                _points[i] = new PointF(boundingBox[2 * i], boundingBox[(2 * i) + 1]);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldBoundingBox"/> structure.
        /// </summary>
        /// <param name="points">The sequence of points defining this <see cref="FieldBoundingBox"/>.</param>
        internal FieldBoundingBox(IReadOnlyList<PointF> points)
        {
            _points = points?.ToArray();
        }

        /// <summary>
        /// </summary>
        internal PointF[] Points => _points ?? Array.Empty<PointF>();

        /// <summary>
        /// Gets one of the points that set the limits of this <see cref="FieldBoundingBox"/>.
        /// Coordinates are specified relative to the top-left of the original image, and points
        /// are ordered clockwise from the top-left corner relative to the text orientation.
        /// </summary>
        /// <param name="index">The 0-based index of the point to be retrieved.</param>
        /// <returns>A <see cref="PointF"/> corresponding to the specified <paramref name="index"/>.</returns>
        public PointF this[int index] => Points[index];

        /// <summary>
        /// Returns string representation for <see cref="FieldBoundingBox"/>.
        /// </summary>
        public override string ToString() => string.Join(",", Points.Select(p => p.ToString()).ToArray());
    }
}
