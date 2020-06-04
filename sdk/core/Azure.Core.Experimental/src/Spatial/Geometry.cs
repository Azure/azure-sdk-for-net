// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Spatial
{
    /// <summary>
    /// A base type for all spatial types.
    /// </summary>
    public abstract class Geometry
    {
        internal static readonly GeometryProperties DefaultProperties = new GeometryProperties();

        /// <summary>
        /// The <see cref="GeometryProperties"/> associated with this <see cref="Geometry"/> instance.
        /// </summary>
        public GeometryProperties Properties { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="Geometry"/>.
        /// </summary>
        /// <param name="properties">The <see cref="GeometryProperties"/> to use.</param>
        protected Geometry(GeometryProperties properties)
        {
            Argument.AssertNotNull(properties, nameof(properties));

            Properties = properties;
        }
    }
}