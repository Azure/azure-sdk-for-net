// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Spatial
{
    /// <summary>
    ///
    /// </summary>
    public readonly struct GeometryBoundingBox
    {
        /// <summary>
        ///
        /// </summary>
        public double West { get; }
        /// <summary>
        ///
        /// </summary>
        public double South { get; }
        /// <summary>
        ///
        /// </summary>
        public double East { get; }
        /// <summary>
        ///
        /// </summary>
        public double North { get; }
        /// <summary>
        ///
        /// </summary>
        public double? MinAltitude { get; }
        /// <summary>
        ///
        /// </summary>
        public double? MaxAltitude { get; }

        /// <summary>
        ///
        /// </summary>
        public GeometryBoundingBox(double west, double south, double east, double north) : this(west, south, east, north, null, null)
        {
        }

        /// <summary>
        ///
        /// </summary>
        public GeometryBoundingBox(double west, double south, double east, double north, double? minAltitude, double? maxAltitude)
        {
            West = west;
            South = south;
            East = east;
            North = north;
            MinAltitude = minAltitude;
            MaxAltitude = maxAltitude;
        }
    }
}