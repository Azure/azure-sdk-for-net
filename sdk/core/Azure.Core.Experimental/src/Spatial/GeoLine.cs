// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.Spatial
{
    /// <summary>
    /// Represents a line geometry that consists of multiple coordinates.
    /// </summary>
    public sealed class GeoLine : GeoObject
    {
        /// <summary>
        /// Initializes new instance of <see cref="GeoLine"/>.
        /// </summary>
        /// <param name="coordinates">The collection of <see cref="GeoCoordinate"/> that make up the line.</param>
        public GeoLine(IEnumerable<GeometryCoordinate> coordinates): this(coordinates, null, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="GeoLine"/>.
        /// </summary>
        /// <param name="coordinates">The collection of <see cref="GeoCoordinate"/> that make up the line.</param>
        /// <param name="boundingBox">The <see cref="GeoBoundingBox"/> to use.</param>
        /// <param name="additionalProperties">The set of additional properties associated with the <see cref="GeoObject"/>.</param>
        public GeoLine(IEnumerable<GeometryCoordinate> coordinates, GeoBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> additionalProperties): this(ConvertCoordinates(coordinates), boundingBox, additionalProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="GeoLine"/>.
        /// </summary>
        /// <param name="coordinates">The collection of <see cref="GeoCoordinate"/> that make up the line.</param>
        public GeoLine(IEnumerable<GeographyCoordinate> coordinates): this(coordinates, null, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="GeoLine"/>.
        /// </summary>
        /// <param name="coordinates">The collection of <see cref="GeoCoordinate"/> that make up the line.</param>
        /// <param name="boundingBox">The <see cref="GeoBoundingBox"/> to use.</param>
        /// <param name="additionalProperties">The set of additional properties associated with the <see cref="GeoObject"/>.</param>
        public GeoLine(IEnumerable<GeographyCoordinate> coordinates, GeoBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> additionalProperties): this(ConvertCoordinates(coordinates), boundingBox, additionalProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="GeoLine"/>.
        /// </summary>
        /// <param name="coordinates">The collection of <see cref="GeoCoordinate"/> that make up the line.</param>
        /// <param name="boundingBox">The <see cref="GeoBoundingBox"/> to use.</param>
        /// <param name="additionalProperties">The set of additional properties associated with the <see cref="GeoObject"/>.</param>
        internal GeoLine(IReadOnlyList<GeoCoordinate> coordinates, GeoBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> additionalProperties): base(boundingBox, additionalProperties)
        {
            Coordinates = coordinates;
        }

        /// <summary>
        ///
        /// </summary>
        public IReadOnlyList<GeoCoordinate> Coordinates { get; }

        internal static IReadOnlyList<GeoCoordinate> ConvertCoordinates(IEnumerable<GeometryCoordinate> coordinates)
        {
            Argument.AssertNotNull(coordinates, nameof(coordinates));

            return coordinates.Select(c => new GeoCoordinate(c)).ToArray();
        }

        internal static IReadOnlyList<GeoCoordinate> ConvertCoordinates(IEnumerable<GeographyCoordinate> coordinates)
        {
            Argument.AssertNotNull(coordinates, nameof(coordinates));

            return coordinates.Select(c => new GeoCoordinate(c)).ToArray();
        }
    }
}