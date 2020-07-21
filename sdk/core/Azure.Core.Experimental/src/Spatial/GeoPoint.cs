// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Core.Spatial
{
    /// <summary>
    /// Represents a point geometry.
    /// </summary>
    public sealed class GeoPoint : Geometry
    {
        /// <summary>
        /// Initializes new instance of <see cref="GeoPoint"/>.
        /// </summary>
        /// <param name="position">The position of the point.</param>
        public GeoPoint(GeometryCoordinate position): this(position, null, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="GeoPoint"/>.
        /// </summary>
        /// <param name="position">The position of the point.</param>
        /// <param name="boundingBox">The <see cref="GeoBoundingBox"/> to use.</param>
        /// <param name="additionalProperties">The set of additional properties associated with the <see cref="Geometry"/>.</param>
        public GeoPoint(GeometryCoordinate position, GeoBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> additionalProperties): this(new GeoCoordinate(position), boundingBox, additionalProperties)
        {
            Coordinate = new GeoCoordinate(position);
        }

        /// <summary>
        /// Initializes new instance of <see cref="GeoPoint"/>.
        /// </summary>
        /// <param name="position">The position of the point.</param>
        public GeoPoint(GeographyCoordinate position): this(position, null, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="GeoPoint"/>.
        /// </summary>
        /// <param name="position">The position of the point.</param>
        /// <param name="boundingBox">The <see cref="GeoBoundingBox"/> to use.</param>
        /// <param name="additionalProperties">The set of additional properties associated with the <see cref="Geometry"/>.</param>
        public GeoPoint(GeographyCoordinate position, GeoBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> additionalProperties): this(new GeoCoordinate(position), boundingBox, additionalProperties)
        {
        }

        internal GeoPoint(GeoCoordinate coordinate, GeoBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> additionalProperties): base(boundingBox, additionalProperties)
        {
            Coordinate = coordinate;
        }

        /// <summary>
        /// Gets position of the point.
        /// </summary>
        public GeoCoordinate Coordinate { get; }
    }
}
