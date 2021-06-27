// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Core.GeoJson
{
    /// <summary>
    /// Represents a linear ring that's a part of a polygon
    /// </summary>
    public sealed class GeoLinearRing
    {
        /// <summary>
        /// Initializes new instance of <see cref="GeoLinearRing"/>.
        /// </summary>
        /// <param name="coordinates"></param>
        public GeoLinearRing(IEnumerable<GeoPosition> coordinates)
        {
            Argument.AssertNotNull(coordinates, nameof(coordinates));

            Coordinates = new GeoArray<GeoPosition>(coordinates.ToArray());

            if (Coordinates.Count < 4)
            {
                throw new ArgumentException("The linear ring is required to have at least 4 coordinates");
            }

            if (Coordinates[0] != Coordinates[Coordinates.Count - 1])
            {
                throw new ArgumentException("The first and last coordinate of the linear ring are required to be equal");
            }
        }

        /// <summary>
        /// Returns a view over the coordinates array that forms this linear ring.
        /// </summary>
        public GeoArray<GeoPosition> Coordinates { get; }
    }
}