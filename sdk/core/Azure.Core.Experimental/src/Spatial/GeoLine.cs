// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.Spatial
{
    /// <summary>
    /// Represents a line geometry that consists of multiple coordinates.
    /// </summary>
    public sealed class GeoLine : Geometry
    {
        /// <summary>
        /// Initializes new instance of <see cref="GeoLine"/>.
        /// </summary>
        /// <param name="positions">The collection of <see cref="GeoCoordinate"/> that make up the line.</param>
        public GeoLine(IEnumerable<GeoCoordinate> positions): this(positions, null, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="GeoLine"/>.
        /// </summary>
        /// <param name="positions">The collection of <see cref="GeoCoordinate"/> that make up the line.</param>
        /// <param name="boundingBox">The <see cref="GeoBoundingBox"/> to use.</param>
        /// <param name="additionalProperties">The set of additional properties associated with the <see cref="Geometry"/>.</param>
        public GeoLine(IEnumerable<GeoCoordinate> positions, GeoBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> additionalProperties): base(boundingBox, additionalProperties)
        {
            Argument.AssertNotNull(positions, nameof(positions));

            Positions = positions.ToArray();
        }

        /// <summary>
        ///
        /// </summary>
        public IReadOnlyList<GeoCoordinate> Positions { get; }
    }
}