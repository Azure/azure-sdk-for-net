// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("BoundingRegion")]
    [CodeGenSuppress(nameof(BoundingRegion), typeof(int), typeof(IEnumerable<float>))]
    [CodeGenSuppress("Polygon")]
    public readonly partial struct BoundingRegion : IEquatable<BoundingRegion>
    {
        /// <summary> Initializes a new instance of BoundingRegion. </summary>
        /// <param name="pageNumber"> 1-based page number of page containing the bounding region. </param>
        /// <param name="polygon"> Bounding polygon on the page, or the entire page if not specified. </param>
        internal BoundingRegion(int pageNumber, IReadOnlyList<float> polygon)
        {
            PageNumber = pageNumber;
            BoundingPolygon = ClientCommon.CovertToListOfPointF(polygon);
        }

        /// <summary>
        /// Initializes a new instance of BoundingRegion. Used by the <see cref="DocumentAnalysisModelFactory"/>.
        /// </summary>
        internal BoundingRegion(int pageNumber, IReadOnlyList<PointF> boundingPolygon)
        {
            PageNumber = pageNumber;
            BoundingPolygon = boundingPolygon;
        }

        /// <summary>
        /// 1-based page number of page containing the bounding region.
        /// </summary>
        public int PageNumber { get; }

        /// <summary>
        /// The bounding polygon that outlines this region. Units are in pixels for images and inches for
        /// PDF. The <see cref="LengthUnit"/> type of a recognized page can be found at <see cref="DocumentPage.Unit"/>.
        /// </summary>
        public IReadOnlyList<PointF> BoundingPolygon { get; }

        /// <summary>
        /// Indicates whether the current <see cref="BoundingRegion"/> is equal to another object of the same type.
        /// They are considered equal if they have the same type, the same <see cref="PageNumber"/>, and the same point
        /// coordinates in <see cref="BoundingPolygon"/>.
        /// </summary>
        /// <param name="obj">An object to compare with this <see cref="BoundingRegion"/>.</param>
        /// <returns><c>true</c> if the current <see cref="BoundingRegion"/> is equal to the <paramref name="obj"/> parameter; otherwise, <c>false</c>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is BoundingRegion other && Equals(other);

        /// <summary>
        /// Indicates whether the current <see cref="BoundingRegion"/> is equal to another object of the same type.
        /// They are considered equal if they have the same <see cref="PageNumber"/> and the same point coordinates
        /// in <see cref="BoundingPolygon"/>.
        /// </summary>
        /// <param name="other">An object to compare with this <see cref="BoundingRegion"/>.</param>
        /// <returns><c>true</c> if the current <see cref="BoundingRegion"/> is equal to the <paramref name="other"/> parameter; otherwise, <c>false</c>.</returns>
        public bool Equals(BoundingRegion other)
        {
            if (PageNumber != other.PageNumber)
            {
                return false;
            }

            if (BoundingPolygon == null)
            {
                return other.BoundingPolygon == null;
            }

            if (BoundingPolygon.Count != other.BoundingPolygon.Count)
            {
                return false;
            }

            // Since points in a polygon are cyclical, two polygons could still be considered the same
            // if points were shifted. For example, [(1,2),(3,4),(5,6),(7,8)] and [(7,8),(1,2),(3,4),(5,6)]
            // represent the same polygon. This, however, is not expected to happen since points returned
            // by the service are sorted in a deterministic order, so we're ignoring this scenario.
            for (int i = 0; i < BoundingPolygon.Count; i++)
            {
                if (BoundingPolygon[i] != other.BoundingPolygon[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            var builder = new HashCodeBuilder();

            builder.Add(PageNumber);

            foreach (PointF point in BoundingPolygon)
            {
                builder.Add(point.GetHashCode());
            }

            return builder.ToHashCode();
        }

        /// <summary>
        /// Returns a <c>string</c> representation of this <see cref="BoundingRegion"/>.
        /// </summary>
        /// <returns>A <c>string</c> representation of this <see cref="BoundingRegion"/>.</returns>
        public override string ToString()
        {
            string points = string.Join(",", BoundingPolygon.Select(p => p.ToString()));

            return $"Page: {PageNumber}, Polygon: {points}";
        }
    }
}
