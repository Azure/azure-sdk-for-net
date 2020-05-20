// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Spatial
{
    /// <summary>
    ///
    /// </summary>
    public class Geometry
    {
        private protected GeometryProperties DefaultProperties = new GeometryProperties();

        /// <summary>
        ///
        /// </summary>
        public GeometryProperties Properties { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="properties"></param>
        public Geometry(GeometryProperties? properties)
        {
            Properties = properties ?? DefaultProperties;
        }
    }

    /// <summary>
    ///
    /// </summary>
    public readonly struct GeoBoundingBox
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public GeoBoundingBox(GeoPosition min, GeoPosition max)
        {
            Min = min;
            Max = max;
        }

        /// <summary>
        ///
        /// </summary>
        public GeoPosition Min { get; }
        /// <summary>
        ///
        /// </summary>
        public GeoPosition Max { get; }
    }
}