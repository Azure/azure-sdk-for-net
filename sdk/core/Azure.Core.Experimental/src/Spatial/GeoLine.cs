// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.GeoJson
{
    /// <summary>
    /// Represents a line geometry that consists of multiple coordinates.
    /// </summary>
    public sealed class GeoLine : GeoObject
    {
        /// <summary>
        /// Initializes new instance of <see cref="GeoLine"/>.
        /// </summary>
        /// <param name="coordinates">The collection of <see cref="GeoPosition"/> that make up the line.</param>
        public GeoLine(IEnumerable<GeoPosition> coordinates): this(coordinates, null, DefaultProperties)
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="GeoLine"/>.
        /// </summary>
        /// <param name="coordinates">The collection of <see cref="GeoPosition"/> that make up the line.</param>
        /// <param name="boundingBox">The <see cref="GeoBoundingBox"/> to use.</param>
        /// <param name="additionalProperties">The set of additional properties associated with the <see cref="GeoObject"/>.</param>
        public GeoLine(IEnumerable<GeoPosition> coordinates, GeoBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> additionalProperties): base(boundingBox, additionalProperties)
        {
            Positions = coordinates.ToArray();
        }

        /// <summary>
        /// Gets the list of <see cref="GeoPosition"/> that compose this line.
        /// </summary>
        public IReadOnlyList<GeoPosition> Positions { get; }
    }
}