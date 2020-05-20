// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Spatial
{
    /// <summary>
    ///
    /// </summary>
    public class Geometry
    {
        private static readonly GeometryProperties DefaultProperties = new GeometryProperties();

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
}