// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.Core.Spatial
{
    /// <summary>
    /// A base type for all spatial types.
    /// </summary>
    public abstract class Geometry
    {
        internal static readonly IReadOnlyDictionary<string, object?> DefaultProperties = new ReadOnlyDictionary<string, object?>(new Dictionary<string, object?>());

        /// <summary>
        /// Initializes a new instance of <see cref="Geometry"/>.
        /// </summary>
        /// <param name="boundingBox">The <see cref="GeometryBoundingBox"/> to use.</param>
        /// <param name="additionalProperties">The set of additional properties associated with the <see cref="Geometry"/>.</param>
        protected Geometry(GeometryBoundingBox? boundingBox, IReadOnlyDictionary<string, object?> additionalProperties)
        {
            Argument.AssertNotNull(additionalProperties, nameof(additionalProperties));

            BoundingBox = boundingBox;
            AdditionalProperties = additionalProperties;
        }

        /// <summary>
        /// Represents information about the coordinate range of the <see cref="Geometry"/>.
        /// </summary>
        public GeometryBoundingBox? BoundingBox { get; }

        /// <summary>
        /// Gets a dictionary of additional properties associated with the <see cref="Geometry"/>.
        /// </summary>
        public IReadOnlyDictionary<string, object?> AdditionalProperties { get; }
    }
}