// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Azure.Core.GeoJson
{
    /// <summary>
    /// Represents a point geometry.
    /// </summary>
    /// <example>
    /// Creating a point:
    /// <code snippet="Snippet:CreatePoint" language="csharp">
    /// var point = new GeoPoint(-122.091954, 47.607148);
    /// </code>
    /// </example>
    [JsonConverter(typeof(GeoJsonConverter))]
    public sealed partial class GeoPoint : GeoObject
    {
        /// <summary>
        /// Initializes new instance of <see cref="GeoPoint"/>.
        /// </summary>
        public GeoPoint() : this(default, default)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="GeoPoint"/>.
        /// </summary>
        /// <param name="longitude">The longitude of the point.</param>
        /// <param name="latitude">The latitude of the point.</param>
        public GeoPoint(double longitude, double latitude) : this(new GeoPosition(longitude, latitude), null, DefaultProperties)
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
        /// <param name="customProperties">The set of custom properties associated with the <see cref="GeoObject"/>.</param>
        public GeoPoint(GeoPosition position, GeoBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> customProperties): base(boundingBox, customProperties)
        {
            Coordinates = position;
        }

        /// <summary>
        /// Gets position of the point.
        /// </summary>
        public GeoPosition Coordinates { get; }

        /// <inheritdoc />
        public override GeoObjectType Type { get; } = GeoObjectType.Point;
    }
}
