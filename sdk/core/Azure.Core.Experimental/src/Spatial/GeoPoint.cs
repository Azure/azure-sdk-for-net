// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Core.GeoJson
{
    /// <summary>
    /// Represents a point geometry.
    /// </summary>
    public sealed class GeoPoint : GeoObject
    {
        /// <summary>
        /// Initializes new instance of <see cref="GeoPoint"/>.
        /// </summary>
        /// <param name="longitude">The longitude of the point.</param>
        /// <param name="latitude">The latitude of the point.</param>
        public GeoPoint(double longitude, double latitude): this(new GeoPosition(longitude, latitude), null, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="GeoPoint"/>.
        /// </summary>
        /// <param name="longitude">The longitude of the point.</param>
        /// <param name="latitude">The latitude of the point.</param>
        /// <param name="altitude">The altitude of the point.</param>
        public GeoPoint(double longitude, double latitude, double? altitude): this(new GeoPosition(longitude, latitude, altitude), null, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="GeoPoint"/>.
        /// </summary>
        /// <param name="position">The position of the point.</param>
        public GeoPoint(GeoPosition position): this(position, null, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="GeoPoint"/>.
        /// </summary>
        /// <param name="position">The position of the point.</param>
        /// <param name="boundingBox">The <see cref="GeoBoundingBox"/> to use.</param>
        /// <param name="additionalProperties">The set of additional properties associated with the <see cref="GeoObject"/>.</param>
        public GeoPoint(GeoPosition position, GeoBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> additionalProperties): base(boundingBox, additionalProperties)
        {
            Position = position;
        }

        /// <summary>
        /// Gets position of the point.
        /// </summary>
        public GeoPosition Position { get; }
    }
}
