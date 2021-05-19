// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Azure.Core.GeoJson
{
    /// <summary>
    /// Represents a geometry that is composed of multiple <see cref="GeoPoint"/>.
    /// </summary>
    public sealed class GeoPointCollection : GeoObject, IReadOnlyList<GeoPoint>
    {
        /// <summary>
        /// Initializes new instance of <see cref="GeoPointCollection"/>.
        /// </summary>
        /// <param name="points">The collection of inner points.</param>
        public GeoPointCollection(IEnumerable<GeoPoint> points): this(points, null, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="GeoPointCollection"/>.
        /// </summary>
        /// <param name="points">The collection of inner points.</param>
        /// <param name="boundingBox">The <see cref="GeoBoundingBox"/> to use.</param>
        /// <param name="customProperties">The set of custom properties associated with the <see cref="GeoObject"/>.</param>
        public GeoPointCollection(IEnumerable<GeoPoint> points, GeoBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> customProperties): base(boundingBox, customProperties)
        {
            Argument.AssertNotNull(points, nameof(points));

            Points = points.ToArray();
        }

        /// <summary>
        ///
        /// </summary>
        internal IReadOnlyList<GeoPoint> Points { get; }

        /// <inheritdoc />
        public IEnumerator<GeoPoint> GetEnumerator()
        {
            return Points.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <inheritdoc />
        public int Count => Points.Count;

        /// <inheritdoc />
        public GeoPoint this[int index] => Points[index];

        /// <summary>
        /// Returns a view over the coordinates array that forms this geometry.
        /// </summary>
        public GeoArray<GeoPosition> Coordinates => new GeoArray<GeoPosition>(this);

        /// <inheritdoc />
        public override GeoObjectType Type { get; } = GeoObjectType.MultiPoint;
    }
}