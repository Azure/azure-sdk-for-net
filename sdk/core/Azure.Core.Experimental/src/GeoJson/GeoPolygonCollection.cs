// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.GeoJson
{
    /// <summary>
    /// Represents a geometry that is composed of multiple <see cref="GeoPolygon"/>.
    /// </summary>
    public sealed class GeoPolygonCollection : GeoObject, IReadOnlyList<GeoPolygon>
    {
        /// <summary>
        /// Initializes new instance of <see cref="GeoPolygonCollection"/>.
        /// </summary>
        /// <param name="polygons">The collection of inner polygons.</param>
        public GeoPolygonCollection(IEnumerable<GeoPolygon> polygons): this(polygons, null, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="GeoPolygonCollection"/>.
        /// </summary>
        /// <param name="polygons">The collection of inner geometries.</param>
        /// <param name="boundingBox">The <see cref="GeoBoundingBox"/> to use.</param>
        /// <param name="customProperties">The set of custom properties associated with the <see cref="GeoObject"/>.</param>
        public GeoPolygonCollection(IEnumerable<GeoPolygon> polygons, GeoBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> customProperties): base(boundingBox, customProperties)
        {
            Argument.AssertNotNull(polygons, nameof(polygons));

            Polygons = polygons.ToArray();
        }

        internal IReadOnlyList<GeoPolygon> Polygons { get; }

        /// <inheritdoc />
        public IEnumerator<GeoPolygon> GetEnumerator()
        {
            return Polygons.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <inheritdoc />
        public int Count => Polygons.Count;

        /// <inheritdoc />
        public GeoPolygon this[int index] => Polygons[index];

        /// <summary>
        /// Returns a view over the coordinates array that forms this geometry.
        /// </summary>
        public GeoArray<GeoArray<GeoArray<GeoPosition>>> Coordinates => new GeoArray<GeoArray<GeoArray<GeoPosition>>>(this);

        /// <inheritdoc />
        public override GeoObjectType Type { get; } = GeoObjectType.MultiPolygon;
    }
}