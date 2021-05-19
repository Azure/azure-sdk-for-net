// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.GeoJson
{
    /// <summary>
    /// Represents a line geometry that consists of multiple coordinates.
    /// </summary>
    public sealed class GeoLineString : GeoObject
    {
        /// <summary>
        /// Initializes new instance of <see cref="GeoLineString"/>.
        /// </summary>
        /// <param name="coordinates">The collection of <see cref="GeoPosition"/> that make up the line.</param>
        public GeoLineString(IEnumerable<GeoPosition> coordinates): this(coordinates, null, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="GeoLineString"/>.
        /// </summary>
        /// <param name="coordinates">The collection of <see cref="GeoPosition"/> that make up the line.</param>
        /// <param name="boundingBox">The <see cref="GeoBoundingBox"/> to use.</param>
        /// <param name="customProperties">The set of custom properties associated with the <see cref="GeoObject"/>.</param>
        public GeoLineString(IEnumerable<GeoPosition> coordinates, GeoBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> customProperties): base(boundingBox, customProperties)
        {
            Coordinates = new GeoArray<GeoPosition>(coordinates.ToArray());;
        }

        /// <summary>
        /// Returns a view over the coordinates array that forms this geometry.
        /// </summary>
        public GeoArray<GeoPosition> Coordinates { get; }

        /// <inheritdoc />
        public override GeoObjectType Type { get; } = GeoObjectType.LineString;
    }
}