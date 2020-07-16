// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Core.Spatial
{
    /// <summary>
    /// Represents a point geometry.
    /// </summary>
    public sealed class GeoPoint : GeoObject
    {
        /// <summary>
        /// Initializes new instance of <see cref="GeoPoint"/>.
        /// </summary>
        /// <param name="coordinate">The position of the point.</param>
        public GeoPoint(GeometryCoordinate coordinate): this(coordinate, null, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="GeoPoint"/>.
        /// </summary>
        /// <param name="coordinate">The position of the point.</param>
        /// <param name="boundingBox">The <see cref="GeoBoundingBox"/> to use.</param>
        /// <param name="additionalProperties">The set of additional properties associated with the <see cref="GeoObject"/>.</param>
        public GeoPoint(GeometryCoordinate coordinate, GeometryBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> additionalProperties):
            this(
                new GeoCoordinate(coordinate),
                boundingBox.HasValue ? new GeoBoundingBox(boundingBox.Value) : (GeoBoundingBox?)null,
                additionalProperties)
        {
            Coordinate = new GeoCoordinate(coordinate);
        }

        /// <summary>
        /// Initializes new instance of <see cref="GeoPoint"/>.
        /// </summary>
        /// <param name="coordinate">The position of the point.</param>
        public GeoPoint(GeographyCoordinate coordinate): this(coordinate, null, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="GeoPoint"/>.
        /// </summary>
        /// <param name="coordinate">The position of the point.</param>
        /// <param name="boundingBox">The <see cref="GeographyBoundingBox"/> to use.</param>
        /// <param name="additionalProperties">The set of additional properties associated with the <see cref="GeoObject"/>.</param>
        public GeoPoint(GeographyCoordinate coordinate, GeographyBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> additionalProperties):
            this(new GeoCoordinate(coordinate),
                boundingBox.HasValue ? new GeoBoundingBox(boundingBox.Value) : (GeoBoundingBox?)null,
                additionalProperties)
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
